using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using System.Data;

namespace TweebaaWebApp2
{
    public partial class Page : System.Web.UI.Page
    {
        //string gs_SEOTitle;
        public string gs_SEOMetaTag;
        public string gs_SEOKeyword;
        public string gs_pageTitle;
        public string gs_pageDescription;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s_SEOTitle = "";
                bool m_bIsTitle = false;
                if (string.IsNullOrEmpty(Request["id"]))
                {
                    if (string.IsNullOrEmpty(HttpContext.Current.Items["id"].ToString()))
                    {
                        Response.Write("<script type='text/javascript'>alert('bad request')</script>");
                        Response.Redirect("~/College/College.aspx");
                        return;
                    }
                    else
                    {
                        s_SEOTitle = HttpContext.Current.Items["SEO_Title"].ToString();
                        m_bIsTitle = true;
                        //Request["id"] = proid;
                    }
                }
                else
                {

                    s_SEOTitle = Request["id"].Trim();
                }

                    
                PageContentMgr mgr = new PageContentMgr();
                DataTable dt = null;
                if (m_bIsTitle)
                {
                    dt = mgr.GetPageContentInfoBySEOTitle(s_SEOTitle);
                }
                else
                {
                    dt = mgr.GetPageContentInfoByPageID(s_SEOTitle);
                }
                gs_SEOMetaTag = dt.Rows[0]["PageContent_SeoMetaTag"].ToString();
                gs_SEOKeyword = dt.Rows[0]["PageContent_SeoKeyWord"].ToString();
                gs_pageTitle = dt.Rows[0]["PageContent_PageTitle"].ToString();
                gs_pageDescription = dt.Rows[0]["PageContent_PageDescription"].ToString();
            }
        }
    }
}