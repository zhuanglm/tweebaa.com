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
    public partial class NewsRelease : System.Web.UI.Page
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
                string s_SEOTitle = HttpContext.Current.Items["SEO_Title"].ToString();
                PageContentMgr mgr=new PageContentMgr();
                DataTable dt = mgr.GetPageContentInfoBySEOTitle(s_SEOTitle);

                gs_SEOMetaTag = dt.Rows[0]["PageContent_SeoMetaTag"].ToString();
                gs_SEOKeyword = dt.Rows[0]["PageContent_SeoKeyWord"].ToString();
                gs_pageTitle = dt.Rows[0]["PageContent_PageTitle"].ToString();
                gs_pageDescription = dt.Rows[0]["PageContent_PageDescription"].ToString();
            }
		}
	}
}