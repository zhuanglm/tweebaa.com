using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Compilation;
using System.Web.UI;
//using AdventureWorksModel;
using Twee.Mgr;


    public class PreSaleRouteHandler: IRouteHandler
    {
        public PreSaleRouteHandler() { }


        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
           // AdventureWorksEntities awe = new AdventureWorksEntities();
            string prd_name = requestContext.RouteData.Values["product_name"] as string;
            PrdMgr mgr = new PrdMgr();
            string prd_id = mgr.GetProductID(prd_name);


            HttpContext.Current.Items["id"] = prd_id;

            return BuildManager.CreateInstanceFromVirtualPath("~/Product/presaleBuy.aspx", typeof(Page)) as Page;
        }
    }
