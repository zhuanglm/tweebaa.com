using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TweebaaWebApp2.Mgr.CouponAdmin
{
    public partial class CouponAddEdit : System.Web.UI.Page
    {
        public string coupon_id;
        public string coupon_name = "";
        public string coupon_amount = "";
        public string coupon_min_order = "";
        public string coupon_free_ship = "";
        public string coupon_code = "";
        public string coupon_uses_coupon = "";
        public string coupon_uses_user = "";
        public string txtStartDate = "";
        public string txtEndDate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request["coupon_id"]))
            {

            }
            else
            {
                coupon_id = Request["coupon_id"].ToString();
                //Load Coupon
                Twee.Mgr.CouponMgr mgr = new Twee.Mgr.CouponMgr();
                DataTable dt = mgr.LoadSingleCoupon(coupon_id);
                if (dt.Rows.Count > 0)
                {

                    DataRow dr = dt.Rows[0];
                    coupon_name = dr["coupon_title"].ToString();
                    coupon_code = dr["coupon_code"].ToString();
                    coupon_amount = dr["coupon_amount"].ToString();
                    if (float.Parse(coupon_amount) < 1)
                    {
                        float f1 =float.Parse(coupon_amount) * 100;
                        coupon_amount = f1.ToString()+"%";
                    }
                    coupon_min_order = dr["coupon_minimum_order"].ToString();
                    coupon_free_ship = dr["coupon_type"].ToString();
                    if (coupon_free_ship == "F")
                    {
                        coupon_free_ship = "checked";
                    }
                    else
                    {
                        coupon_free_ship = "";
                    }
                    coupon_uses_coupon = dr["uses_per_coupon"].ToString();
                    if (coupon_uses_coupon == "0")
                    {
                        coupon_uses_coupon = "";
                    }
                    coupon_uses_user = dr["uses_per_user"].ToString();
                    if (coupon_uses_user == "0")
                    {
                        coupon_uses_user = "";
                    }
                    txtStartDate = dr["coupon_start_date"].ToString();
                    txtEndDate = dr["coupon_expire_date"].ToString();
                }
            }
        }
    }
}