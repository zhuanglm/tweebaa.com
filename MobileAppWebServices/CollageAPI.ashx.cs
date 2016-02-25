using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Twee.Mgr;
using Twee.Model;
using System.Xml.Linq;
using Twee.Comm;

namespace MobileAppWebServices
{
    /// <summary>
    /// Summary description for CollageAPI
    /// </summary>
    public class CollageAPI : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                
                String sGet=context.Request.QueryString["action"];
                //context.Response.Write("Hello World");
                if (sGet.Equals("load_template"))
                {
                    string sPage = context.Request.QueryString["page"].ToString();
                    string sPageDiv = context.Request.QueryString["pageDiv"].ToString();
                    int iPage = int.Parse(sPage);
                    int iFirst = (iPage - 1) * int.Parse(sPageDiv) + 1;
                    int iLast = iPage * int.Parse(sPageDiv);
                    Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                    List<Twee.Model.CollageTemplate> templates = mgr.GetListByPage("", iFirst, iLast);
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
                if (sGet.Equals("load_single_template"))
                {
                    //Load template from database
                    string sID = context.Request.QueryString["template_id"].ToString();
                    Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                    List<Twee.Model.CollageTemplate> templates = mgr.GetModelList("CollageTemp_ID=" + sID);
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
                if (sGet.Equals("load_template_total"))
                {
                    Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                    int iTotal = mgr.GetBackgroundImgTotal();
                    XElement xmlBackground = new XElement("CollageTemplate");
                    XElement subXml = new XElement("Template_total");
                    XElement XmlTotal = new XElement("total", iTotal);
                    subXml.Add(XmlTotal);
                    xmlBackground.Add(subXml);
                    context.Response.Write(xmlBackground);
                }
                if (sGet.Equals("load_background_total"))
                {
                    Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                    int iTotal = mgr.GetBackgroundImgTotal();
                    XElement xmlBackground = new XElement("CollageBackground");
                    XElement subXml = new XElement("background_total");
                    XElement XmlTotal = new XElement("total", iTotal);
                    subXml.Add(XmlTotal);
                    xmlBackground.Add(subXml);
                    context.Response.Write(xmlBackground);
                }
                if (sGet.Equals("load_decoration_total"))
                {
                    Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                    int iTotal = mgr.GetDecorationImgTotal();
                    XElement xml = new XElement("CollageDecoration");
                    XElement subXml = new XElement("decoration_total");
                    XElement XmlTotal = new XElement("total", iTotal);
                    subXml.Add(XmlTotal);
                    xml.Add(subXml);
                    context.Response.Write(xml);
                }
                if (sGet.Equals("load_background"))
                {
                    Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                    string sPage = context.Request.QueryString["page"].ToString();
                    string sPageDiv = context.Request.QueryString["pageDiv"].ToString();
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

                if (sGet.Equals("load_decoration"))
                {
                    Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                    string sPage = context.Request.QueryString["page"].ToString();
                    string sPageDiv = context.Request.QueryString["pageDiv"].ToString();
                    List<Twee.Model.CollageDecorationImg> DecorationImg = mgr.GetDecorationImg(sPage);
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
                if (sGet.Equals("load_sort_publish"))
                {
                    Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                    int iSort = context.Request.QueryString["sort_type"].ToString().ToInt();
                    string sSort = "";
                    if (iSort == 1)
                    {
                        sSort = " CollageDesign_Status=0 order by CollageDesign_PublishTime desc";
                    }
                    if (iSort == 2)
                    {
                        sSort = " CollageDesign_Status=0 order by CollageDesing_Title ";
                    }
                    List<Twee.Model.CollageDesign> templates = mgr.GetModelList(sSort);
                    //make xml

                    XElement xml = new XElement("CollageDesigns");
                    for (int i = 0; i < templates.Count; i++) // Loop with for.
                    {
                        XElement subXml = new XElement("design");
                        XElement XmlID = new XElement("ID", templates[i].id);
                        XElement XmlImg = new XElement("Image", templates[i].thumbnail);
                        XElement XmlTitle = new XElement("Title", templates[i].CollageDesing_Title);
                        XElement XmlInspiration = new XElement("Inspiration", templates[i].Inspiration);
                        XElement XmlUsername = new XElement("Username", templates[i].User_name);
                        XElement XmlCity = new XElement("City", templates[i].City);
                        XElement XmlCountry = new XElement("Country", templates[i].Country);
                        XElement XmlShareCount = new XElement("ShareCount", templates[i].ShareTotalCount);
                        subXml.Add(XmlID);
                        subXml.Add(XmlImg);
                        subXml.Add(XmlTitle);
                        subXml.Add(XmlInspiration);

                        subXml.Add(XmlUsername);
                        subXml.Add(XmlCity);
                        subXml.Add(XmlCountry);
                        subXml.Add(XmlShareCount);

                        xml.Add(subXml);
                    }
                    context.Response.Write(xml);
                }
                if (sGet.Equals("load_search_publish"))
                {
                    Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                    string sKeywords = context.Request.QueryString["txtKeywords"].ToString();
                    string sTitleLike = CommUtil.GetSqlLike("CollageDesing_Title", sKeywords.Trim());
                    string sTagLike = CommUtil.GetSqlLike("CollageDesign_Tag", sKeywords.Trim());
                    string sInspiration = CommUtil.GetSqlLike("CollageDesign_Inspiration", sKeywords.Trim());

                    string sLikes = "CollageDesign_Status=0 and (( " + sTitleLike + ") or (" + sTagLike + ") or (" + sInspiration + "))";
                    List<Twee.Model.CollageDesign> templates = mgr.GetModelList(sLikes);
                    //make xml

                    XElement xml = new XElement("CollageDesigns");
                    for (int i = 0; i < templates.Count; i++) // Loop with for.
                    {
                        XElement subXml = new XElement("design");
                        XElement XmlID = new XElement("ID", templates[i].id);
                        XElement XmlImg = new XElement("Image", templates[i].thumbnail);
                        XElement XmlTitle = new XElement("Title", templates[i].CollageDesing_Title);
                        XElement XmlInspiration = new XElement("Inspiration", templates[i].Inspiration);
                        XElement XmlUsername = new XElement("Username", templates[i].User_name);
                        XElement XmlCity = new XElement("City", templates[i].City);
                        XElement XmlCountry = new XElement("Country", templates[i].Country);
                        XElement XmlShareCount = new XElement("ShareCount", templates[i].ShareTotalCount);
                        subXml.Add(XmlID);
                        subXml.Add(XmlImg);
                        subXml.Add(XmlTitle);
                        subXml.Add(XmlInspiration);

                        subXml.Add(XmlUsername);
                        subXml.Add(XmlCity);
                        subXml.Add(XmlCountry);
                        subXml.Add(XmlShareCount);

                        xml.Add(subXml);
                    }
                    context.Response.Write(xml);
                }
                if (sGet.Equals("load_all_publish"))
                {
                    Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                    //Load All the published design
                    int iPage = int.Parse(context.Request.QueryString["page"].ToString());
                    if (iPage <= 0) iPage = 1;
                    int iPageDiv = int.Parse(context.Request.QueryString["pageDiv"].ToString());
                    int iFirst = (iPage - 1) * iPageDiv + 1;
                    int iLast = iPage * iPageDiv;
                    List<Twee.Model.CollageDesign> templates = mgr.GetListByPage("CollageDesign_Status=0", iFirst, iLast);
                    //make xml

                    XElement xml = new XElement("CollageDesigns");
                    for (int i = 0; i < templates.Count; i++) // Loop with for.
                    {
                        XElement subXml = new XElement("design");
                        XElement XmlID = new XElement("ID", templates[i].id);
                        XElement XmlImg = new XElement("Image", templates[i].thumbnail);
                        XElement XmlTitle = new XElement("Title", templates[i].CollageDesing_Title);
                        XElement XmlInspiration = new XElement("Inspiration", templates[i].Inspiration);
                        XElement XmlUsername = new XElement("Username", templates[i].User_name);
                        XElement XmlCity = new XElement("City", templates[i].City);
                        XElement XmlCountry = new XElement("Country", templates[i].Country);
                        XElement XmlShareCount = new XElement("ShareCount", templates[i].ShareTotalCount);
                        subXml.Add(XmlID);
                        subXml.Add(XmlImg);
                        subXml.Add(XmlTitle);
                        subXml.Add(XmlInspiration);

                        subXml.Add(XmlUsername);
                        subXml.Add(XmlCity);
                        subXml.Add(XmlCountry);
                        subXml.Add(XmlShareCount);

                        xml.Add(subXml);
                    }
                    context.Response.Write(xml);
                }
                if (sGet.Equals("load_my_draft_total"))
                {
                    Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                    string sUserID = context.Request.QueryString["user_id"].ToString();
                    //(CollageDesign_CreateUserGuid = 'eff4dca6-fedc-4bd9-bbe5-79dec2bb39d8' and CollageDesign_Status=1)
                    int iTotal = mgr.GetMyDraftTotal(sUserID);
                    //make xml

                    XElement xml = new XElement("MyDrafts");

                    XElement XmlTotal = new XElement("Total", iTotal);

                    xml.Add(XmlTotal);
                    context.Response.Write(xml);
                }
                if (sGet.Equals("load_my_draft"))
                {
                    Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                    //Load All the my draft design
                    string sUserID = context.Request.QueryString["user_id"].ToString();
                    int iPage = int.Parse(context.Request.QueryString["page"].ToString());
                    int iPageDiv = int.Parse(context.Request.QueryString["pageDiv"].ToString());
                    int iFirst = (iPage - 1) * iPageDiv + 1;
                    int iLast = iPage * iPageDiv;

                    List<Twee.Model.CollageDesign> templates = mgr.GetListByPage("CollageDesign_CreateUserGuid = '" + sUserID + "' and CollageDesign_Status=1", iFirst, iLast);
                    //make xml

                    XElement xml = new XElement("CollageDesigns");
                    for (int i = 0; i < templates.Count; i++) // Loop with for.
                    {
                        XElement subXml = new XElement("design");
                        XElement XmlID = new XElement("ID", templates[i].id);
                        XElement XmlImg = new XElement("Image", templates[i].thumbnail);
                        XElement XmlTitle = new XElement("Title", templates[i].CollageDesing_Title);
                        subXml.Add(XmlID);
                        subXml.Add(XmlImg);
                        subXml.Add(XmlTitle);
                        xml.Add(subXml);
                    }
                    context.Response.Write(xml);
                }

                if (sGet.Equals("load_my_publish_total"))
                {
                    Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                    string sUserID = context.Request.QueryString["user_id"].ToString();
                    //(CollageDesign_CreateUserGuid = 'eff4dca6-fedc-4bd9-bbe5-79dec2bb39d8' and CollageDesign_Status=1)
                    int iTotal = mgr.GetMyPublishTotal(sUserID);
                    //make xml

                    XElement xml = new XElement("MyPublishs");

                    XElement XmlTotal = new XElement("Total", iTotal);

                    xml.Add(XmlTotal);
                    context.Response.Write(xml);
                }
                if (sGet.Equals("load_my_publish"))
                {
                    Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                    //Load All the my draft design
                    string sUserID = context.Request.QueryString["user_id"].ToString();
                    int iPage = int.Parse(context.Request.QueryString["page"].ToString());
                    int iPageDiv = int.Parse(context.Request.QueryString["pageDiv"].ToString());
                    int iFirst = (iPage - 1) * iPageDiv + 1;
                    int iLast = iPage * iPageDiv;

                    List<Twee.Model.CollageDesign> templates = mgr.GetListByPage("CollageDesign_CreateUserGuid = '" + sUserID + "' and CollageDesign_Status=0", iFirst, iLast);
                    //make xml

                    XElement xml = new XElement("CollageDesigns");
                    for (int i = 0; i < templates.Count; i++) // Loop with for.
                    {
                        XElement subXml = new XElement("design");
                        XElement XmlID = new XElement("ID", templates[i].id);
                        XElement XmlImg = new XElement("Image", templates[i].thumbnail);
                        XElement XmlTitle = new XElement("Title", templates[i].CollageDesing_Title);
                        subXml.Add(XmlID);
                        subXml.Add(XmlImg);
                        subXml.Add(XmlTitle);
                        xml.Add(subXml);
                    }
                    context.Response.Write(xml);
                }
                if (sGet.Equals("load_single_design"))
                {
                    Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                    //Load All the my draft design
                    string sdesign_id = context.Request.QueryString["design_id"].ToString();


                    Twee.Model.CollageDesign templates = mgr.GetDesignByID(sdesign_id);
                    //make xml

                    XElement xml = new XElement("CollageDesigns");

                    XElement subXml = new XElement("design");
                    XElement XmlID = new XElement("ID", templates.id);
                    XElement XmlImg = new XElement("Image", templates.thumbnail);
                    XElement XmlTitle = new XElement("Title", templates.CollageDesing_Title);
                    XElement XmlHtml = new XElement("DesignData", templates.innerHTML);
                    XElement XmlData = new XElement("innerHTML", templates.TemplateHTML);

                    XElement XmlUsername = new XElement("Username", templates.User_name);
                    XElement XmlCity = new XElement("City", templates.City);
                    XElement XmlCountry = new XElement("Country", templates.Country);

                    XElement XmlProduct_ID1 = new XElement("Product_ID1", templates.Product_ID1);
                    XElement XmlProduct_ID2 = new XElement("Product_ID2", templates.Product_ID2);
                    XElement XmlProduct_ID3 = new XElement("Product_ID3", templates.Product_ID3);
                    XElement XmlProduct_ID4 = new XElement("Product_ID4", templates.Product_ID4);

                    XElement XmlProduct_ID5 = new XElement("Product_ID5", templates.Product_ID5);
                    XElement XmlProduct_ID6 = new XElement("Product_ID6", templates.Product_ID6);
                    XElement XmlProduct_ID7 = new XElement("Product_ID7", templates.Product_ID7);
                    XElement XmlProduct_ID8 = new XElement("Product_ID8", templates.Product_ID8);

                    XElement XmlInspiration = new XElement("Inspiration", templates.Inspiration);

                    subXml.Add(XmlID);
                    subXml.Add(XmlImg);
                    subXml.Add(XmlTitle);
                    subXml.Add(XmlHtml);
                    subXml.Add(XmlData);

                    subXml.Add(XmlUsername);
                    subXml.Add(XmlCity);
                    subXml.Add(XmlCountry);

                    subXml.Add(XmlInspiration);
                    subXml.Add(XmlProduct_ID1);
                    subXml.Add(XmlProduct_ID2);
                    subXml.Add(XmlProduct_ID3);
                    subXml.Add(XmlProduct_ID4);

                    subXml.Add(XmlProduct_ID5);
                    subXml.Add(XmlProduct_ID6);
                    subXml.Add(XmlProduct_ID7);
                    subXml.Add(XmlProduct_ID8);

                    xml.Add(subXml);

                    context.Response.Write(xml);
                }
            }
            catch (Exception e1)
            {


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