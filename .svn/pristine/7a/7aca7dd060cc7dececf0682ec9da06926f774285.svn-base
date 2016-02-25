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
    public partial class admPatentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInfo();
            }
        }
        private void BindInfo()
        {
            string id = Request.QueryString["id"].ToString();

            PatentMgr patent = new PatentMgr();
            DataTable dt = patent.MgeGetInfo(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                labCode.Text = dt.Rows[0]["patentcode"].ToString();
                labName.Text = dt.Rows[0]["patentname"].ToString();
                labOnwer.Text = dt.Rows[0]["username"].ToString();
                labDate1.Text = dt.Rows[0]["createtime"].ToString();
                labContent.Text = dt.Rows[0]["patentcontent"].ToString();
            }

        }
    }
}