using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Configuration;
using System.IO.Compression;
using System.IO;

namespace Twee.Web2._0
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            log4net.Config.XmlConfigurator.Configure();
            // Code that runs on application startup
            RegisterRoute(System.Web.Routing.RouteTable.Routes);
        }
        void RegisterRoute(System.Web.Routing.RouteCollection routes)
        {
  
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
 
	         // Here it is!
            //routes.Add(new EnableAbsoluteRouting());
 
	        // Rest of routing config goes here
	        //routes.MapRoute(...)
            routes.Add("Product/saleBuy", new System.Web.Routing.Route("Product/saleBuy/{product_name}", new ProductNameRouteHandler()));
            routes.Add("Product/presaleBuy", new System.Web.Routing.Route("Product/presaleBuy/{product_name}", new PreSaleRouteHandler()));
            routes.Add("NewsRelease", new System.Web.Routing.Route("NewsRelease/{seo_title}", new NewsReleaseContentRouteHandler()));
            routes.Add("Page", new System.Web.Routing.Route("Page/{seo_title}", new PageContentRouteHandler()));

        } 
        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }
        void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            /*
            HttpApplication app = sender as HttpApplication;
            string acceptEncoding = app.Request.Headers["Accept-Encoding"];
            Stream prevUncompressedStream = app.Response.Filter;

            if (app.Context.CurrentHandler == null)
                return;

            if (!(app.Context.CurrentHandler is System.Web.UI.Page ||
                app.Context.CurrentHandler.GetType().Name == "SyncSessionlessHandler") ||
                app.Request["HTTP_X_MICROSOFTAJAX"] != null)
                return;

            if (acceptEncoding == null || acceptEncoding.Length == 0)
                return;

            acceptEncoding = acceptEncoding.ToLower();

            if (acceptEncoding.Contains("deflate") || acceptEncoding == "*")
            {
                // deflate
                app.Response.Filter = new DeflateStream(prevUncompressedStream,
                    CompressionMode.Compress);
                app.Response.AppendHeader("Content-Encoding", "deflate");
            }
            else if (acceptEncoding.Contains("gzip"))
            {
                // gzip
                app.Response.Filter = new GZipStream(prevUncompressedStream,
                    CompressionMode.Compress);
                app.Response.AppendHeader("Content-Encoding", "gzip");
            }*/
        } 
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            /*
            
            HttpContext context = HttpContext.Current;
            context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
            HttpContext.Current.Response.AppendHeader("Content-encoding", "gzip");
            HttpContext.Current.Response.Cache.VaryByHeaders["Accept-encoding"] = true;
             */
            string s1= ConfigurationManager.AppSettings.Get("IsPaypal_Sandbox");
            int IsSandbox =int.Parse(s1);

            if (IsSandbox == 0)
            {
                //采用压缩
                

                
                /*
                if (!Request.Url.Host.StartsWith("www") && !Request.Url.IsLoopback)
                {
                    UriBuilder builder = new UriBuilder(Request.Url);
                    builder.Host = "https://www." + Request.Url.Host;
                    Response.StatusCode = 301;
                    Response.AddHeader("Location", builder.ToString());
                    Response.End();
                }*/
                /*
                if (HttpContext.Current.Request.IsSecureConnection.Equals(false) && HttpContext.Current.Request.IsLocal.Equals(false))
                {
                    Response.Redirect("https://" + Request.ServerVariables["HTTP_HOST"]
                + HttpContext.Current.Request.RawUrl);
                }*/
                /*
                HttpContext context = HttpContext.Current;
                context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
                HttpContext.Current.Response.AppendHeader("Content-encoding", "gzip");
                HttpContext.Current.Response.Cache.VaryByHeaders["Accept-encoding"] = true;*/

            }

        }
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.ToString();

            if (url.ToLower().Contains("mgr/") && !url.ToLower().Contains("mgr/index.aspx")
                && (url.ToLower().EndsWith(".aspx") || url.ToLower().Contains(".aspx?"))
                )
            {
                var user = Session["CURRENT_USER"] as Twee.Model.MgrUser;
                if (null == user)
                {
                    HttpContext.Current.Response.Redirect("~/Mgr/index.aspx?relogin=1");
                }
            }

        }
        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码
            //加下面代码，从而在SSL下可以保持 Session
            if (Request.IsSecureConnection) Response.Cookies["ASP.NET_SessionID"].Secure = false;
        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

        }

    }
}
