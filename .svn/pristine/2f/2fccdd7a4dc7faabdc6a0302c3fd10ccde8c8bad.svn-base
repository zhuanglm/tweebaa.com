using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Mgr;

namespace TweebaaWebApp2.Manage
{
    public partial class admMoneyEdt : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }

        }

        protected void btnPay_Click(object sender, EventArgs e)
        {

            //Response.Write("<script>alert('保存成功！')</script>");
            GetData();
        }

        public void GetData()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                MoneyMgr money = new MoneyMgr();
                DataTable dt = money.MgeGetListByPage(Request.QueryString["id"].ToString(), "", "", "", "", "", "", 0, 10, "");

                if (dt != null && dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["username"].ToString();
                    txtDate.Text = dt.Rows[0]["addtime"].ToString();
                    txtMoney.Text = dt.Rows[0]["amount"].ToString();
                    txtType.Text = dt.Rows[0]["wntype"].ToString();
                    txtCard.Text = dt.Rows[0]["paymentno"].ToString();
                }
            }

        } 
    }
}