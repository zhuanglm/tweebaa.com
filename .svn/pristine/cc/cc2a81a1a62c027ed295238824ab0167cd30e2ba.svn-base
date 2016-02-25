using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;

namespace TweebaaWebApp2.Manage
{
    public partial class admOrderSend : System.Web.UI.Page
    {
        string guid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            guid = Request.QueryString["guid"];
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(guid))
                {
                    Guid orderGuid = new Guid(guid);
                    BindOrderInfo(orderGuid);

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
                labCode.Text = OrderInfoDic["guidno"];
                labSum.Text = OrderInfoDic["sumProMoney"];
                txtAmount.Text = OrderInfoDic["amountMoney"];//最终结算
                labBegin.Text = OrderInfoDic["addtime"];
                labLogistics.Text = OrderInfoDic["logisticscost"];

                labReciveName.Text = OrderInfoDic["address1"] + OrderInfoDic["recivZipCode"] + "," + OrderInfoDic["reciveName"] + "," + OrderInfoDic["recivePhone"];
                // labExpressNo.Text = OrderInfoDic["expressNo"];         
                //labUpPriceTime.Text = OrderInfoDic["upPriceTime"];
                //labUpMessage.Text = OrderInfoDic["upPriceMeassage"];
                //labUpPriceMessage.Text = OrderInfoDic["upPriceMeassage"];
            }

        }

        //发货
        protected void btnSend_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicArg = new Dictionary<string, string>();
            dicArg["amountMoney"] = "";
            dicArg["upPriceMeassage"] = "";
            dicArg["expressCompanyGuid"] = droWuliu.SelectedValue.Trim();
            dicArg["expressNo"] = txtExpressNo.Text.Trim();
            OrderMgr order = new OrderMgr();
            bool bResult = order.MgeUpDateInfo(dicArg, 3, new Guid(guid));
            if (bResult)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert1", "alert('操作成功')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert2", "alert('操作失败')", true);
            }
        }
    
    }
}