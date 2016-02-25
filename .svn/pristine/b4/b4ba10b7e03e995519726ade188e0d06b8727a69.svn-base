using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileAppWebServices
{
    /// <summary>
    /// Summary description for UCAPI
    /// </summary>
    public class UCAPI : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}