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
    public partial class admOrderInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void BindInfo()
        {
            string guid = Request.QueryString["guid"];
            if (!string.IsNullOrEmpty(guid))
            {
                OrderMgr order = new OrderMgr();
                DataTable dt = order.MgeGetList("a.guid=" + guid);
                if (dt != null && dt.Rows.Count != 0)
                {
                    //    labCode.Text = dt.Rows[0]["guidno"].ToString();
                    //    labAmount.Text = dt.Rows[0]["guidno"].ToString();
                    //    labBegin.Text = dt.Rows[0]["guidno"].ToString();
                    //    labEnd.Text = dt.Rows[0]["guidno"].ToString();
                    //    labSum.Text = dt.Rows[0]["guidno"].ToString();
                    //    labLogistics.Text = dt.Rows[0]["guidno"].ToString();
                    //    labPro.Text = dt.Rows[0]["guidno"].ToString();
                    //    labPrice.Text = dt.Rows[0]["guidno"].ToString();
                    //    labNumber.Text = dt.Rows[0]["guidno"].ToString();
                    //    labMoney.Text = dt.Rows[0]["guidno"].ToString();               


                }
            }

        }
    }
}