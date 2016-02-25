using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using Twee.Comm;
namespace TweebaaWebApp2.Mgr.CouponAdmin
{
    /// <summary>
    /// Summary description for CouponAdminHandler
    /// </summary>
    public class CouponAdminHandler : IHttpHandler
    {
       
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            try
            {
                string sAction="";
                if(context.Request.Form.AllKeys.Contains("action")){
                     sAction = context.Request.Form["action"].ToString();
                }else{
                    sAction = context.Request["action"];
                }
                if (sAction == "loadCoupons")
                {
                    /*
                     *  + '&Couponcode=' + encodeURIComponent(sUserName)
                             + '&Status=' + sStatus
                             + '&StartDate=' + sStartDate
                             + '&EndDate=' + sEndDate;
                     */
                    int iPageSize = int.Parse(context.Request["rows"]);
                    int iPage = int.Parse(context.Request["page"]) - 1;
                    int iStartIdx = iPageSize * iPage + 1;
                    int iEndIdx = iStartIdx + iPageSize - 1;
                    int iTotalCount = 0;
                    //string strSQL = "select * from wn_Coupons order by date_modified desc";
                    string strWhere = " where 1=1";
                    if (!string.IsNullOrEmpty(context.Request["Couponcode"]) && context.Request["Couponcode"].ToString().Length > 0)
                    {
                        strWhere +=" and "+ Twee.Comm.CommUtil.GetSqlLike("coupon_code", context.Request["Couponcode"].ToString());
 
                    }
                    if (!string.IsNullOrEmpty(context.Request["Status"]) && context.Request["Status"].ToString().Length > 0)
                    {
                        strWhere += " and coupon_active=" + context.Request["Status"].ToString();
                    }
                    if (!string.IsNullOrEmpty(context.Request["StartDate"]) && context.Request["StartDate"].ToString().Length > 0)
                    {
                        strWhere += " and coupon_start_date<=" + context.Request["StartDate"].ToString();
                    }

                    if (!string.IsNullOrEmpty(context.Request["EndDate"]) && context.Request["EndDate"].ToString().Length > 0)
                    {
                        strWhere += " and coupon_expire_date>=" + context.Request["EndDate"].ToString();
                    }
                    Twee.Mgr.CouponMgr mgr = new Twee.Mgr.CouponMgr();
                    var dt = mgr.MgeGetPageCoupons(false, iStartIdx, iEndIdx, out iTotalCount, strWhere);

                    //if (dt == null || dt.Rows.Count == 0)
                    //    return string.Empty;
                    StringBuilder json = new StringBuilder();
                    foreach (DataRow row in dt.Rows)
                    {
                        /*
                                            { field: 'coupon_start_date', title: 'Start Time', width: 180 },
                                            { field: 'coupon_expire_date', title: 'Expire Time', width: 180 },
                                            { field: 'coupon_title', title: 'Coupon Name', width: 100 },
                                            { field: 'coupon_code', title: 'Coupon Code', width: 100 },
                                            { field: 'coupon_amount', title: 'Coupon Amount', width: 200 },
                         */
                        string coupon_amount = row["coupon_amount"]._ObjToString();
                        if (float.Parse(coupon_amount) < 1)
                        {
                            float f1 = float.Parse(coupon_amount) * 100;
                            coupon_amount = f1.ToString() + "%";
                        }
                        json.AppendFormat(",{0}  \"coupon_id\":\"{2}\",\"coupon_start_date\":\"{3}\",\"coupon_expire_date\":\"{4}\",\"coupon_title\":\"{5}\",\"coupon_code\":\"{6}\",\"coupon_amount\":\"{7}\",\"Active\":\"{8}\" {1}", "{", "}"
                            , row["coupon_id"]._ObjToString(),
                            row["coupon_start_date"]._ObjToString(),
                            row["coupon_expire_date"]._ObjToString(),
                            row["coupon_title"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                            row["coupon_code"]._ObjToString(),
                            coupon_amount,
                            (row["coupon_active"]._ObjToString() == "1") ? "Yes" : "No"
                            );
                    }
                    string temp_json = string.Empty;
                    if (!string.IsNullOrEmpty(json.ToString()))
                        temp_json = json.ToString().Substring(1);
                    string res = "{\"total\":" + iTotalCount.ToString() + ",\"rows\":[" + temp_json + "]}";
                    context.Response.Write( res);


                }
                if (sAction == "AddEdit")
                {
                    string coupon_id = context.Request.Form["coupon_id"].ToString();
                    if (string.IsNullOrEmpty(coupon_id) || coupon_id.Length == 0)
                    {
                        coupon_id = "0";
                    }
                    string coupon_name = context.Request.Form["coupon_name"].ToString();
                    string coupon_amount = context.Request.Form["coupon_amount"].ToString();
                    string coupon_min_order = context.Request.Form["coupon_min_order"].ToString();
                    string coupon_free_ship = context.Request.Form["coupon_free_ship"].ToString();
                    string coupon_code = context.Request.Form["coupon_code"].ToString();
                    string coupon_uses_coupon = context.Request.Form["coupon_uses_coupon"].ToString();
                    string coupon_uses_user = context.Request.Form["coupon_uses_user"].ToString();
                    string coupon_products = context.Request.Form["coupon_products"].ToString();
                    string coupon_categories = context.Request.Form["coupon_categories"].ToString();
                    string coupon_start_date = context.Request.Form["coupon_start_date"].ToString();
                    string coupon_expire_date = context.Request.Form["coupon_expire_date"].ToString();

                    if (string.IsNullOrEmpty(coupon_uses_coupon) || coupon_uses_coupon.Length == 0)
                    {
                        coupon_uses_coupon = "0";
                    }
                    if (string.IsNullOrEmpty(coupon_uses_user) || coupon_uses_user.Length == 0)
                    {
                        coupon_uses_user = "0";
                    }

                    Twee.Model.Coupons coupon = new Twee.Model.Coupons();
                    coupon.CouponActive = 1;
                    if (coupon_amount.Contains("%"))
                    {
                        coupon.CouponAmount = float.Parse(coupon_amount.Replace("%","")) / 100;
                    }
                    else
                    {
                        coupon.CouponAmount = float.Parse(coupon_amount);
                    }
                    coupon.CouponName = coupon_name;
                    coupon.CouponMinimumOrder = float.Parse(coupon_min_order);
                    coupon.CouponID = int.Parse(coupon_id);
                    if (int.Parse(coupon_free_ship) == 1)
                    {
                        coupon.CouponType = 'F';
                    }
                    else
                    {
                        coupon.CouponType = 'C';
                    }
                    if (coupon_code.Trim().Length < 1)
                    {
                        coupon_code = Twee.Comm.CommUtil.GenerateCouponCode();
                    }
                    coupon.CouponCode = coupon_code;
                    coupon.UsesPerCoupon = short.Parse(coupon_uses_coupon);
                    coupon.UsesPerUser = short.Parse(coupon_uses_user);
                    if (coupon_products.Length > 0)
                    {
                        coupon.IsRestrictToCustomers = 1;
                        coupon.restrict_to_products = coupon_products;
                    }
                    else
                    {
                        coupon.IsRestrictToCustomers = 0;
                        coupon.restrict_to_products = coupon_products;
                    }
                    if (coupon_categories.Length > 0)
                    {
                        coupon.IsRestrictToCategories = 1;
                        coupon.restrict_to_categories = coupon_categories;
                    }
                    else
                    {
                        coupon.IsRestrictToCategories = 0;
                        coupon.restrict_to_categories = coupon_categories;
                    }

                    coupon.CouponStartDate = Convert.ToDateTime(coupon_start_date);
                    coupon.CouponExpireDate = Convert.ToDateTime(coupon_expire_date);

                    Twee.Mgr.CouponMgr mgr = new Twee.Mgr.CouponMgr();
                    if (int.Parse(coupon_id) > 0)
                    {

                        mgr.Update(coupon);
                    }
                    else
                    {
                        mgr.CouponAdd(coupon);
                    }
                    context.Response.Write("1");
                }
            }
            catch (Exception e)
            {
                context.Response.Write("0");
                Twee.Comm.CommUtil.GenernalErrorHandler(e);
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}