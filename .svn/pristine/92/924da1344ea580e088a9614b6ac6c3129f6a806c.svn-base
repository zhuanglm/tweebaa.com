using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Compilation;
using System.Web.UI;
//using AdventureWorksModel;
using Twee.Mgr;


public class NewsReleaseContentRouteHandler : IRouteHandler
{
    public NewsReleaseContentRouteHandler() { }
    public IHttpHandler GetHttpHandler(RequestContext requestContext)
    {
        // AdventureWorksEntities awe = new AdventureWorksEntities();
        string s_SEOTitle = requestContext.RouteData.Values["seo_title"] as string;
        /*
            PrdMgr mgr = new PrdMgr();
            string prd_id = mgr.GetProductID(prd_name);

            */
        HttpContext.Current.Items["SEO_Title"] = s_SEOTitle;
           
        return BuildManager.CreateInstanceFromVirtualPath("~/NewsRelease.aspx", typeof(Page)) as Page;
    }
}