using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Mgr;

namespace TweebaaWebApp.Manage
{
    public partial class admOrderPrint2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string guid = Request.QueryString["guid"];
            if (!string.IsNullOrEmpty(guid))
            {
                Guid orderGuid = new Guid(guid);
                if (!IsPostBack)
                {
                    BindOrderInfo(orderGuid);
                    BindOrderProInfo(orderGuid);

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
                labBegin.Text = OrderInfoDic["addtime"].ToString();
                labMessageWord.Text = OrderInfoDic["messageWord"].ToString();
                labRecive.Text = OrderInfoDic["address1"] + "  [" + OrderInfoDic["reciveName"] + " " + OrderInfoDic["recivePhone"] + "]";

            }
        }

        /// <summary>
        /// 订单产品详情信息
        /// </summary>
        /// <param name="orderGuid"></param>
        private void BindOrderProInfo(Guid orderGuid)
        {
            OrderMgr order = new OrderMgr();
            DataTable dt = order.MgeGetOrderProInfo(orderGuid);
            repPro.DataSource = dt;
            repPro.DataBind();


        }
    }
}