using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Comm;
using Twee.Mgr;

namespace TweebaaWebApp.Mgr.orderMgr
{
    public partial class admOrderInfo : System.Web.UI.Page
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
                lanState.Text = CheckState(OrderInfoDic["wnstat"]);
                labBegin.Text = OrderInfoDic["addtime"].ToString();
                labEnd.Text = OrderInfoDic["wnstat"] == "3" ? OrderInfoDic["edttime"] : "未完成";
                if (OrderInfoDic["wnstat"].ToInt() > 0)
                {
                    labPayTime.Text = OrderInfoDic["payTime"];
                }
                else
                {
                    labPayTime.Text = "未支付";
                }
                labMessage.Text = OrderInfoDic["messageWord"].ToString();
      
                labExpressNo.Text = OrderInfoDic["expressNo"];
                labLogistics.Text = OrderInfoDic["logisticscost"];
                labSum.Text = OrderInfoDic["sumProMoney"]; //商品总价
                labAmount.Text = OrderInfoDic["amountMoney"];//最终结算  

                //收货人信息
                labRecivePeople.Text = OrderInfoDic["address1"].ToString();
                labName.Text = OrderInfoDic["userName"].ToString();
                labPhone.Text = OrderInfoDic["userPhone"].ToString();
               // labEmail.Text = OrderInfoDic["email"].ToString();
                labPeaopleCode.Text = "";

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
            //var pros = dt.Columns["proMoney"];
            //var sum = dt.Select().Select(row => row["proMoney"].ToString().ToDecimal()).Sum();
            //labSum.Text = sum.ToString();//商品总价
            //labAmount.Text = (labLogistics.Text.ToDecimal() + labSum.Text.ToDecimal()).ToString();

        }


        private string CheckState(string state)
        {
            // 0 为支付，1待发货，2已发货，3已完成，-1 已作废

            switch (state)
            {
                case "0":
                    return "未支付";
                case "1":
                    return "待发货";
                case "2":
                    return "已发货";
                case "3":
                    return "已完成";
                case "-1":
                    return "已作废";
                default:
                    return "未知";

            }
        }
    }
}