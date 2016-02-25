using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twee.Model;
using Twee.Mgr;
using System.Web.Script.Serialization;

namespace TweebaaWebApp2.Product
{
    /// <summary>
    /// Summary description for CollageSaveDraft
    /// </summary>
    public class CollageSaveDraft : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Dictionary<string, object> dic = null;
            //context.Response.Write("Hello World");
            //get all parameter
            //String s = context.Request["imgBase64"];
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(context.Request.InputStream);
                string reviewInfo = sr.ReadToEnd();

                JavaScriptSerializer js = new JavaScriptSerializer();
                dic = js.Deserialize<Dictionary<string, object>>(reviewInfo);

                if (dic["action"].ToString().Equals("save_draft"))
                {
                    Twee.Model.CollageDesign design = new CollageDesign();
                    design.template_id = int.Parse(dic["txtTemplateID"].ToString());
                    design.status_id = 1;
                    design.cate_id = 1;
                    design.tags = dic["txtDraftTags"].ToString();
                    design.Inspiration = dic["txtDfaftInspiration"].ToString();
                    design.CollageDesing_Title = dic["txtTitle"].ToString();
                    design.guid = new Guid(dic["txtUserID"].ToString());
                    design.CreateTime = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
                    design.UpdateTime = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
                    design.PublishTime = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
                    design.innerHTML = dic["txtFormData"].ToString();
                    design.thumbnail = dic["txtThumbnail"].ToString();
                    design.Product_ID1 = dic["txtProduct1"].ToString();
                    design.Product_ID2 = dic["txtProduct2"].ToString();
                    design.Product_ID3 = dic["txtProduct3"].ToString();
                    design.Product_ID4 = dic["txtProduct4"].ToString();

                    design.Product_ID5 = dic["txtProduct5"].ToString();
                    design.Product_ID6 = dic["txtProduct6"].ToString();
                    design.Product_ID7 = dic["txtProduct7"].ToString();
                    design.Product_ID8 = dic["txtProduct8"].ToString();

                    Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                    mgr.Add(design);
                }
                if (dic["action"].ToString().Equals("save_draft_freestyle"))
                {
                    Twee.Model.CollageDesign design = new CollageDesign();
                    design.template_id = int.Parse(dic["txtTemplateID"].ToString());
                    design.status_id = 1;
                    design.cate_id = 1;
                    design.tags = dic["txtDraftTags"].ToString();
                    design.Inspiration = dic["txtDfaftInspiration"].ToString();
                    design.CollageDesing_Title = dic["txtTitle"].ToString();
                    design.guid = new Guid(dic["txtUserID"].ToString());
                    design.CreateTime = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
                    design.UpdateTime = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
                    design.PublishTime = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
                    design.innerHTML = dic["txtFormData"].ToString();
                    design.TemplateHTML = dic["txtDesignData"].ToString();
                    design.thumbnail = dic["txtThumbnail"].ToString();
                    design.Product_ID1 = dic["txtProduct1"].ToString();
                    design.Product_ID2 = dic["txtProduct2"].ToString();
                    design.Product_ID3 = dic["txtProduct3"].ToString();
                    design.Product_ID4 = dic["txtProduct4"].ToString();
                    design.Product_ID5 = dic["txtProduct5"].ToString();
                    design.Product_ID6 = dic["txtProduct6"].ToString();
                    design.Product_ID7 = dic["txtProduct7"].ToString();
                    design.Product_ID8 = dic["txtProduct8"].ToString();

                    Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                    mgr.Add_Free_Style(design);
                }
                if (dic["action"].Equals("save_publish"))
                {
                    //
                    Twee.Model.CollageDesign design = new CollageDesign();
                    design.template_id = int.Parse(dic["txtTemplateID"].ToString());
                    design.status_id = 2;
                    design.cate_id = 1;
                    //design.tags = dic["txtDraftTags"].ToString();
                    design.Inspiration = dic["txtDfaftInspiration"].ToString();
                    design.CollageDesing_Title = dic["txtTitle"].ToString();
                    design.guid = new Guid(dic["txtUserID"].ToString());
                    design.CreateTime = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
                    design.UpdateTime = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
                    design.PublishTime = System.DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
                    design.innerHTML = dic["txtFormData"].ToString();
                    design.thumbnail = dic["txtThumbnail"].ToString();
                    design.Product_ID1 = "";
                    design.Product_ID2 = "";
                    design.Product_ID3 = "";
                    design.Product_ID4 = "";
                    design.Product_ID5 = "";
                    design.Product_ID6 = "";
                    design.Product_ID7 = "";
                    design.Product_ID8 = "";
                    design.Product_ids = dic["txtProducts"].ToString();
                    Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                    /*if (dic["txtDesignID"].ToString().Length > 0)
                    {
                        int iDesignID = int.Parse(dic["txtDesignID"].ToString());
                        if (iDesignID > 0)
                        {
                            design.id = iDesignID;
                            mgr.Update(design);
                        }
                        else
                        {

                            mgr.Add(design);
                        }
                        
                    }
                    else*/
                    {
                        mgr.Add(design);
                    }

                }
                context.Response.Write("1");
            }
            catch (Exception e)
            {
               // context.Response.Write("0");
                context.Response.Write(e.Message);
                //context.Response.Write(e.StackTrace());
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