using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace TweebaaWebApp2.Product
{
    /// <summary>
    /// Summary description for CollageShareHandler
    /// </summary>
    public class CollageShareHandler : IHttpHandler
    {
        Dictionary<string, object> dic = null;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            // get action
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(context.Request.InputStream);
                string cartInfo = sr.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                dic = js.Deserialize<Dictionary<string, object>>(cartInfo);
                string action = dic["action"].ToString();
                
                // check if user is login
                if (action == "share_link_back")
                {
                    string txtShareID = dic["txtShareID"].ToString();
                    Twee.Mgr.CollageShareMgr mgr = new Twee.Mgr.CollageShareMgr();
                    mgr.AddPointsList(txtShareID);
                }
                if (action == "share_collage")
                {
                    string isLogin = dic["isLogin"].ToString();
                    if (isLogin == "1") // do share with login
                    {
                        string proid = dic["proid"].ToString();
                        string url = dic["url"].ToString();
                        string type = dic["type"].ToString();
                        string userGuid = dic["userGuid"].ToString();

                        Twee.Mgr.CollageShareMgr mgr = new Twee.Mgr.CollageShareMgr();
                        Twee.Model.CollageShare model = new Twee.Model.CollageShare();
                        model.guid = Guid.NewGuid();
                        model.prtguid = new Guid();
                        model.Sourcetype = 2;
                        model.CollageDesign_ID = int.Parse(proid);
                        model.userguid = new Guid(userGuid);
                        model.sharetype = type;
                        model.shareurl = url + "_" + model.guid;
                        model.addtime = System.DateTime.Now;
                        mgr.Add(model);
                        context.Response.Clear();
                        context.Response.Write(model.guid);
                        return;
                    }
                    else // not login
                    {
                        // return a empty share guid
                        // context.Response.Clear();
                        context.Response.Write("");
                        return;
                    }
                }
            }
            catch (Exception e1)
            {
                context.Response.Write("-1");

            }

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