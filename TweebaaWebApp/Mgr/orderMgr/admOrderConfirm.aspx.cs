using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using System.Data;
using Twee.Comm;

namespace TweebaaWebApp.Mgr.orderMgr
{
    public partial class admOrderConfirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string type = Request.QueryString["action"];
                labConfirm.Text = type == "0" ? "确认完成?" : "确认作废?";
            }

        }
        /// <summary>
        /// 废除订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_ok_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["action"]) && !string.IsNullOrEmpty(Request.QueryString["guid"]))
            {
                string action = Request.QueryString["action"].ToString().Trim();
                string guid = Request.QueryString["guid"].ToString().Trim();
                Dictionary<string, string> dicArg = new Dictionary<string, string>();
                dicArg["amountMoney"] = "";
                dicArg["upPriceMeassage"] = "";
                dicArg["expressCompanyGuid"] = "";
                dicArg["expressNo"] = "";
                OrderMgr order = new OrderMgr();

                if (action == "0")
                {
                    bool bResult = order.MgeUpDateInfo(dicArg, 4, new Guid(guid));
                    if (bResult)
                    {
                        /*  该逻辑已经写在存储过程Shop_UpdateShopingPointAndTweebuck
                        DataTable dt = order.GetPointInfoByHeadGuid(guid);
                        if (dt!=null&&dt.Rows.Count>0)
	                    {
                            PointMgr pointMgr = new PointMgr();
                            Twee.Model.Point point = new Twee.Model.Point();
                            point.userId = dt.Rows[0]["userguid"].ToString().ToGuid().Value;                                ;
                            point.orderNo = dt.Rows[0]["guidno"].ToString();
                            point.remark = point.orderNo;
                            var sum = dt.AsEnumerable().Sum(s => s.Field<decimal>("money"));
                            if (sum.ToString()!="")
                            {                             
                                point.point = sum.ToString().ToDecimal();
                                point.type = "4";//购物积分
                                point.addTime = DateTime.Now;
                                point.state = 1;
                                pointMgr.Add(point);
                            }
                            
	                    }     */                
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert1", "alert('操作成功')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert2", "alert('操作失败')", true);
                    }
                }
                if (action == "1")
                {
                    bool bResult = order.MgeUpDateInfo(dicArg, 5, new Guid(guid));
                    if (bResult)
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert3", "alert('操作成功')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert4", "alert('操作失败')", true);
                    }
                }
            }

        }
    
    }
}