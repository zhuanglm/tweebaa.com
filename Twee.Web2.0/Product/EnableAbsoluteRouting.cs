using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web;


    public class EnableAbsoluteRouting : RouteBase
    {
        // Quick way of configuring what port is used for each scheme binding, in case you want to use nonstandard ports
        private Dictionary<string, int> ports = new Dictionary<string,int>();
        private Dictionary<string, int> defaultPorts = new Dictionary<string, int> {
            { "http", 80 }, { "https", 443 }
        };
        public EnableAbsoluteRouting SetPort(string scheme, int port)
        {
            ports.Add(scheme, port);
            return this;
        }

        public override RouteData GetRouteData(HttpContextBase httpContext) { return null; }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            using (RouteTable.Routes.GetReadLock())
            {
                foreach (var routeBase in RouteTable.Routes)
                {
                    if (routeBase != this)
                    {
                        var vpd = routeBase.GetVirtualPath(requestContext, values);
                        if (vpd != null)
                            return EnsureCorrectScheme(requestContext, routeBase, vpd);
                    }
                }
            }
            return null;
        }

        private VirtualPathData EnsureCorrectScheme(RequestContext requestContext, RouteBase routeBase, VirtualPathData vpd)
        {
            var route = routeBase as Route;
            if (route != null)
            {
                string desiredScheme = GetDesiredScheme(route);
                if (desiredScheme != requestContext.HttpContext.Request.Url.Scheme)
                    vpd.VirtualPath = MakeAbsoluteUrl(requestContext, vpd.VirtualPath, desiredScheme);
            }
            return vpd;
        }

        private string GetDesiredScheme(Route route)
        {
            if ((route.DataTokens != null) && (route.DataTokens["scheme"] != null))
                return (string)route.DataTokens["scheme"];
            return "http";
        }

        private string MakeAbsoluteUrl(RequestContext requestContext, string virtualPath, string scheme)
        {
            return string.Format("{0}://{1}{2}{3}{4}{5}",
                scheme,
                requestContext.HttpContext.Request.Url.Host,
                GetPortSegmentOfUrl(scheme),
                requestContext.HttpContext.Request.ApplicationPath,
                requestContext.HttpContext.Request.ApplicationPath.EndsWith("/") ? "" : "/",
                virtualPath);
        }
        private string GetPortSegmentOfUrl(string scheme)
        {
            if (!ports.ContainsKey(scheme)) return "";
            if (ports[scheme] == defaultPorts[scheme]) return "";
            return ":" + ports[scheme];
        }
    }

