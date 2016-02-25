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
    public partial class admPeronReview : System.Web.UI.Page
    {
        private static int flag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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


        // public void BindData(string strWhere1, string strWhere2,string order,int satrtIndex,int endIndex)
        public void BindData(string prdGuid)
        {

            string pName = txtName.Value.Trim();
            string date1 = txtDate1.Value.Trim();
            string date2 = txtDate2.Value.Trim();
            string type = ddlType.SelectedValue;

            string strWhere1 = " 1=1 ";
            string strWhere2 = " 1=1 ";
            if (!string.IsNullOrEmpty(prdGuid) && flag == 0)
            {
                strWhere1 += " and prtguid='" + prdGuid + "'";
            }
            if (!string.IsNullOrEmpty(type))
            {
                strWhere1 += " and cmdtype='" + type + "'";
            }
            if (!string.IsNullOrEmpty(date1))
            {
                strWhere1 += " and T.edttime>='" + date1 + "'";
            }
            if (!string.IsNullOrEmpty(date2))
            {
                strWhere1 += " and T.edttime<='" + date2 + "'";
            }
            if (!string.IsNullOrEmpty(pName))
            {
                strWhere2 = " p.name='" + pName + "'";
            }

            ReviewMgr review = new ReviewMgr();
            DataTable dt = review.MgeGetAllReview(strWhere1, strWhere2, "edttime", 0, 500);
            repData.DataSource = dt;
            repData.DataBind();
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}