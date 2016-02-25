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
    public partial class admPrdSale : System.Web.UI.Page
    {
        private static int flag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["state"]))
                {
                    if (Request.QueryString["state"].ToString() == "2")
                    {
                        labUser.Text = "订购者：";
                        lanTime.Text = "订购时间：";
                    }
                    else
                    {
                        labUser.Text = "购买者：";
                        lanTime.Text = "购买时间：";
                    }
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string prdGuid = Request.QueryString["id"].ToString();
                BindData(prdGuid);
            }
            else
            {
                BindData("");
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string prdGuid = Request.QueryString["id"].ToString();
                BindData(prdGuid);
            }
            else
            {
                BindData("");
            }
        }
        protected void btnAll_Click(object sender, EventArgs e)
        {
            flag = 1;
            BindData("");
        }
        public void BindData(string prdGuid)
        {
            string state = "2";

            if (!string.IsNullOrEmpty(Request.QueryString["state"]))
            {
                state = Request.QueryString["state"].ToString();
            }
            string pName = txtName.Value.Trim();
            string user = txtUser.Value.Trim();
            string date1 = txtDate1.Value.Trim();
            string date2 = txtDate2.Value.Trim();

            string strWhere1 = " 1=1 ";
            string strWhere2 = " 1=1 ";

            if (!string.IsNullOrEmpty(prdGuid) && flag == 0)
            {
                strWhere1 += " and T.guid='" + prdGuid + "'";
            }
            if (!string.IsNullOrEmpty(user))
            {
                strWhere2 += " and u.username='" + user + "'";
            }
            if (!string.IsNullOrEmpty(date1))
            {
                strWhere2 += " and h.edttime>='" + date1 + "'";
            }
            if (!string.IsNullOrEmpty(date2))
            {
                strWhere2 += " and h.edttime<='" + date2 + "'";
            }
            if (!string.IsNullOrEmpty(pName))
            {
                strWhere2 = " p.name='" + pName + "'";
            }

            OrderMgr order = new OrderMgr();
            DataTable dt = order.MgeGetAllSale(strWhere1, strWhere2, "edttime desc", state, 0, 500);
            repData.DataSource = dt;
            repData.DataBind();
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}