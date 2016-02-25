using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twee.Model;
using Twee.Mgr;
using System.Xml.Linq;
using System.Web.Script.Serialization;

namespace TweebaaWebApp.Product
{
    /// <summary>
    /// Summary description for CollageLoadTemplate
    /// </summary>
    public class CollageLoadTemplate : IHttpHandler
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

                Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                //context.Response.Write("Hello World");
                if (dic["action"].Equals("load_template"))
                {
                    string sPage = dic["page"].ToString();
                    string sPageDiv = dic["pageDiv"].ToString();
                    int iPage = int.Parse(sPage);
                    int iFirst = (iPage -1) * int.Parse(sPageDiv) + 1;
                    int iLast = iPage * int.Parse(sPageDiv);
                    List<Twee.Model.CollageTemplate> templates = mgr.GetListByPage("",iFirst,iLast);
                    //make xml

                    XElement xml = new XElement("CollageTemplates");
                    for (int i = 0; i < templates.Count; i++) // Loop with for.
                    {
                        XElement subXml = new XElement("template");
                        XElement XmlID = new XElement("ID", templates[i].id);
                        XElement XmlImg = new XElement("Image", templates[i].Thumbnail);
                        subXml.Add(XmlID);
                        subXml.Add(XmlImg);
                        xml.Add(subXml);
                    }
                    context.Response.Write(xml);
                }
                if (dic["action"].Equals("load_single_template"))
                {
                    //Load template from database
                    string sID = dic["template_id"].ToString();
                    List<Twee.Model.CollageTemplate> templates = mgr.GetModelList("CollageTemp_ID="+sID);
                    XElement xml = new XElement("CollageTemplates");
                    for (int i = 0; i < templates.Count; i++)
                    {
                        XElement subXml = new XElement("template");
                        XElement XmlID = new XElement("ID", templates[i].id);
                        XElement XmlHTML = new XElement("innerHTML", templates[i].innerHTML);
                        subXml.Add(XmlID);
                        subXml.Add(XmlHTML);
                        xml.Add(subXml);
                    }
                    context.Response.Write(xml);
                }
                if (dic["action"].Equals("load_template_total"))
                {
                    int iTotal = mgr.GetBackgroundImgTotal();
                    XElement xmlBackground = new XElement("CollageBackground");
                    XElement subXml = new XElement("background_total");
                    XElement XmlTotal = new XElement("total", iTotal);
                    subXml.Add(XmlTotal);
                    xmlBackground.Add(subXml);
                    context.Response.Write(xmlBackground);
                }
                if (dic["action"].Equals("load_background_total"))
                {
                    int iTotal = mgr.GetBackgroundImgTotal();
                    XElement xmlBackground = new XElement("CollageBackground");
                    XElement subXml = new XElement("background_total");
                    XElement XmlTotal = new XElement("total", iTotal);
                    subXml.Add(XmlTotal);
                    xmlBackground.Add(subXml);
                    context.Response.Write(xmlBackground);
                }
                if (dic["action"].Equals("load_decoration_total"))
                {
                    int iTotal = mgr.GetDecorationImgTotal("");
                    XElement xml = new XElement("CollageDecoration");
                    XElement subXml = new XElement("decoration_total");
                    XElement XmlTotal = new XElement("total", iTotal);
                    subXml.Add(XmlTotal);
                    xml.Add(subXml);
                    context.Response.Write(xml);
                }
                if (dic["action"].Equals("load_background"))
                {
                    string sPage = dic["page"].ToString();
                    string sPageDiv = dic["pageDiv"].ToString();
                    List<Twee.Model.CollageBackgroundImg> CollageBackgroundImg = mgr.GetBackgroundImg(sPage);
                    XElement xmlBackground = new XElement("CollageBackground");
                    for (int i = 0; i < CollageBackgroundImg.Count; i++) // Loop with for.
                    {
                        XElement subXml = new XElement("background");
                        XElement XmlID = new XElement("ID", CollageBackgroundImg[i].CollageBackgroundImg_ID);
                        XElement XmlImg = new XElement("Image", CollageBackgroundImg[i].CollageBackgroundImg_Name);
                        subXml.Add(XmlID);
                        subXml.Add(XmlImg);
                        xmlBackground.Add(subXml);
                    }
                    context.Response.Write(xmlBackground);
                }
                //xml_roots.Add(xmlBackground);

                if (dic["action"].Equals("load_decoration"))
                {
                    string sPage = dic["page"].ToString();
                    string sPageDiv = dic["pageDiv"].ToString();
                    List<Twee.Model.CollageDecorationImg> DecorationImg = mgr.GetDecorationImg(sPage, "");
                    XElement xmlDecoration = new XElement("CollageDecoration");
                    for (int i = 0; i < DecorationImg.Count; i++) // Loop with for.
                    {
                        XElement subXml = new XElement("Decoration");
                        XElement XmlID = new XElement("ID", DecorationImg[i].CollageDecorationImg_ID);
                        XElement XmlImg = new XElement("Image", DecorationImg[i].CollageDecorationImg_Name);
                        subXml.Add(XmlID);
                        subXml.Add(XmlImg);
                        xmlDecoration.Add(subXml);
                    }
                    context.Response.Write(xmlDecoration);
                }
            }
            catch (Exception e)
            {
                context.Response.Write("1");
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