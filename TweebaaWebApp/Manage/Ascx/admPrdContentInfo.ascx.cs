using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Mgr;

namespace TweebaaWebApp.Manage.Ascx
{
    public partial class admPrdContentInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (true)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    PrdMgr prd = new PrdMgr();
                    DataTable dt = prd.MgeGetPrdInfoByID(Request.QueryString["id"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        txtDesc.InnerHtml = dt.Rows[0]["txtinfo"].ToString();
                    }

                }
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdatePrdContent();
        }

        private void UpdatePrdContent()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                PrdMgr prd = new PrdMgr();
                Guid guid = new Guid(Request.QueryString["id"].ToString());
                bool b = prd.MgeUpdatePrdContent(guid, txtDesc.InnerHtml.ToString(), txtVideoUrl.Value.Trim());

            }

        }
   
    }
}