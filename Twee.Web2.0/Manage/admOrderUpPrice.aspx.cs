using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;

namespace TweebaaWebApp2.Manage
{
    public partial class admOrderUpPrice : System.Web.UI.Page
    {
        string guid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            guid = Request.QueryString["guid"];
            string action = Request.QueryString["action"];

            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(guid))
                {
                    Guid orderGuid = new Guid(guid);
                    if (!IsPostBack)
                    {
                        BindOrderInfo(orderGuid);

                    }
                }
                if (!string.IsNullOrEmpty(action))
                {
                    if (action == "1")
                    {
                        trHide.Visible = false;
                        txtAmount.ReadOnly = true;
                        btnUpPrice.Visible = false;
                    }
                    else if (action == "0")
                    {
                        btnUpPay.Visible = false;
                    }

                }
            }

        }

        /// <summary>
        /// 订单信息
        /// </summary>
        /// <param name="orderGuid"></param>
        private void BindOrderInfo(Guid orderGuid)
        {
            OrderMgr order = new OrderMgr();
            Dictionary<string, string> OrderInfoDic = order.MgeGetAllInfo(orderGuid);
            if (OrderInfoDic != null)
            {
                labCode.Text = OrderInfoDic["guidno"];//订单号
                labSum.Text = OrderInfoDic["sumProMoney"];//商品费用
                labLogistics.Text = OrderInfoDic["logisticscost"]; //快递费用
                txtAmount.Text = OrderInfoDic["amountMoney"];//最终结算
                labBegin.Text = OrderInfoDic["addtime"];//下单时间          
                labUpPriceTime.Text = OrderInfoDic["upPriceTime"];
                labUpMessage.Text = OrderInfoDic["upPriceMeassage"];

                if (string.IsNullOrEmpty(OrderInfoDic["upPriceMeassage"]))
                {
                    trUpdate.Visible = false;
                }
            }

        }


        //改价
        protected void btnUpPrice_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicArg = new Dictionary<string, string>();
            dicArg["amountMoney"] = txtAmount.Text.Trim();
            dicArg["upPriceMeassage"] = txtUpPriceMessage.Text.Trim();
            dicArg["expressCompanyGuid"] = "";
            dicArg["expressNo"] = "";

            OrderMgr order = new OrderMgr();
            bool bResult = order.MgeUpDateInfo(dicArg, 1, new Guid(guid));
            if (bResult)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert1", "alert('改价成功')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert2", "alert('该功细节能待考虑')", true);
            }

        }

        //支付
        protected void btnUpPay_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicArg = new Dictionary<string, string>();
            dicArg["amountMoney"] = "";
            dicArg["upPriceMeassage"] = "";
            dicArg["expressCompanyGuid"] = "";
            dicArg["expressNo"] = "";
            OrderMgr order = new OrderMgr();
            bool bResult = order.MgeUpDateInfo(dicArg, 2, new Guid(guid));
            if (bResult)
            {

                //  Response.Write("<script>alert('支付成功！');parent.location.reload();</script>");
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert3", "alert('支付成功')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert4", "alert('支付失败')", true);
            }

        }
    }
}