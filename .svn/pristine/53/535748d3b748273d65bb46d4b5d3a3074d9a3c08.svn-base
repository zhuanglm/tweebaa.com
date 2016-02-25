using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using System.Data;
using Twee.Comm;

namespace TweebaaWebApp.Home
{
    public partial class HomeOrderInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["headguid"]))
                {
                    GetOrderInfo(Request.QueryString["headguid"].ToString());
                }
             
               
            }
        }

        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="orderHead"></param>
        private void GetOrderInfo(string headGuid)
        {
            OrderMgr orderMgr = new OrderMgr();
            DataTable dtInfo = orderMgr.GetOrderHead(headGuid.ToGuid().Value,"");//订单头信息

            //labexpressNo.Text = dtInfo.Rows[0]["guidno"].ToString();
            //labusername.InnerText = dtInfo.Rows[0]["username"].ToString();
            //labaddress1.InnerText = dtInfo.Rows[0]["guidno"].ToString();
            //labaddress2.InnerText = dtInfo.Rows[0]["guidno"].ToString();

            //labexpressprice.InnerText = dtInfo.Rows[0]["expressprice"].ToString();
            //laborderMoney.InnerText = dtInfo.Rows[0]["guidno"].ToString();
            //labphone.InnerText = dtInfo.Rows[0]["phone"].ToString();
            //labprdMoney.InnerText = dtInfo.Rows[0]["guidno"].ToString();
            

            //sbSql.Append("select h.guidno,h.addtime,h.expressNo,h.wnstat,h.addressguid,a.phone,a.tel,a.username ,e.companyname,e.expressprice from  dbo.wn_orderhead h ");



        }
    }
}