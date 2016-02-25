﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twee.Mgr;
using Twee.Model;
using System.Xml.Linq;
using System.Web.Script.Serialization;
using Twee.Comm;
using System.Data;

namespace TweebaaWebApp2.Product
{
    /// <summary>
    /// Summary description for CollageLoadDesign
    /// </summary>
    public class CollageLoadDesign : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
           // context.Response.Write("Hello World");

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

                Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();

                if (dic["action"].Equals("load_sort_publish"))
                {
                    int iSort = dic["sort_type"].ToString().ToInt();
                    string sSort = "";
                    if (iSort == 1)
                    {
                        sSort = " CollageDesign_Status=2 order by CollageDesign_PublishTime desc";
                    }
                    if (iSort == 2)
                    {
                        sSort = " CollageDesign_Status=2 order by CollageDesing_Title ";
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
                if (dic["action"].Equals("load_search_publish"))
                {
                    string sKeywords = dic["txtKeywords"].ToString();
                    string sTitleLike = CommUtil.GetSqlLike("CollageDesing_Title", sKeywords.Trim());
                    string sTagLike = CommUtil.GetSqlLike("CollageDesign_Tag", sKeywords.Trim());
                    string sInspiration = CommUtil.GetSqlLike("CollageDesign_Inspiration", sKeywords.Trim());

                    string sLikes = "CollageDesign_Status=2 and (( " + sTitleLike + ") or (" + sTagLike + ") or (" + sInspiration + "))";
                   
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
                if (dic["action"].Equals("load_publish_total"))
                {
                    string sKeyword = dic["Keyword"].ToString();
                    int iTotal = mgr.GetSearchTotal(sKeyword);
                    context.Response.Write(iTotal);

                }
                if (dic["action"].Equals("load_all_publish"))
                {
                    //Load All the published design
                    int iPage = int.Parse(dic["page"].ToString());
                    if (iPage <= 0) iPage = 1;
                    int iPageDiv = int.Parse(dic["pageDiv"].ToString());
                    
                    int iSort = dic["SortOrder"].ToString().ToInt();
                   /*
                    string sSort = "";
                    if (iSort == 1)
                    {
                        sSort = " order by CollageDesign_PublishTime desc";
                    }
                    if (iSort == 2)
                    {
                        sSort = "  order by CollageDesing_Title ";
                    }*/
                    


                    string sKeywords = dic["keyword"].ToString();
                    string sWhere = "";
                    if (sKeywords.Length > 0)
                    {
                        string sTitleLike = CommUtil.GetSqlLike("CollageDesing_Title", sKeywords.Trim());
                        string sTagLike = CommUtil.GetSqlLike("CollageDesign_Tag", sKeywords.Trim());
                        string sInspiration = CommUtil.GetSqlLike("CollageDesign_Inspiration", sKeywords.Trim());
                        sWhere = "CollageDesign_Status=2 and (( " + sTitleLike + ") or (" + sTagLike + ") or (" + sInspiration + "))";
                    }
                    else
                    {
                        sWhere = "CollageDesign_Status=2";
                    }
                   // sWhere=sWhere;

                    int iFirst = (iPage - 1) * iPageDiv + 1;
                    int iLast = iPage * iPageDiv;
                    //                                             GetListByPage(string strWhere,int iSortType, int iFirst, int iLast)
                    DataSet ds = mgr.GetDatasetListByPage(sWhere, iSort, iFirst, iLast);
                    //make xml
                    DataTable dt = ds.Tables[0];

                    XElement xml = new XElement("CollageDesigns");
                    for (int i = 0; i < dt.Rows.Count; i++) // Loop with for.
                    {
                        DataRow dr = dt.Rows[i];
                        XElement subXml = new XElement("design");
                        XElement XmlID = new XElement("ID", dr["CollageDesign_ID"].ToString());
                        XElement XmlImg = new XElement("Image", dr["CollageDesign_ThumbnailFileName"].ToString());
                        XElement XmlTitle = new XElement("Title", dr["CollageDesing_Title"].ToString());
                        XElement XmlInspiration = new XElement("Inspiration", dr["CollageDesign_Inspiration"].ToString());
                        XElement XmlUsername = new XElement("Username", dr["username"].ToString());
                        /*
                        XElement XmlCity = new XElement("City", templates[i].City);
                        XElement XmlCountry = new XElement("Country", templates[i].Country);
                        XElement XmlShareCount = new XElement("ShareCount", templates[i].ShareTotalCount);*/
                        subXml.Add(XmlID);
                        subXml.Add(XmlImg);
                        subXml.Add(XmlTitle);
                        subXml.Add(XmlInspiration);

                        subXml.Add(XmlUsername);
                        /*
                        subXml.Add(XmlCity);
                        subXml.Add(XmlCountry);
                        subXml.Add(XmlShareCount);*/

                        xml.Add(subXml);
                    }
                    context.Response.Write(xml);
                }
                if (dic["action"].Equals("load_my_draft_total"))
                {
                    string sUserID = dic["user_id"].ToString();
                    //(CollageDesign_CreateUserGuid = 'eff4dca6-fedc-4bd9-bbe5-79dec2bb39d8' and CollageDesign_Status=1)
                    int iTotal = mgr.GetMyDraftTotal(sUserID);
                    //make xml

                    XElement xml = new XElement("MyDrafts");
                    
                    XElement XmlTotal = new XElement("Total", iTotal);
                        
                     xml.Add(XmlTotal);
                    context.Response.Write(xml);
                }
                if (dic["action"].Equals("load_my_draft"))
                {
                    //Load All the my draft design
                    string sUserID = dic["user_id"].ToString();
                    int iPage =int.Parse(dic["page"].ToString());
                    int  iPageDiv = int.Parse(dic["pageDiv"].ToString());
                    int iFirst = (iPage - 1) * iPageDiv + 1;
                    int iLast = iPage * iPageDiv;

                    List<Twee.Model.CollageDesign> templates = mgr.GetListByPage("CollageDesign_CreateUserGuid = '" + sUserID+"' and CollageDesign_Status=1",1,iFirst,iLast);
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

                if (dic["action"].Equals("load_my_publish_total"))
                {
                    string sUserID = dic["user_id"].ToString();
                    //(CollageDesign_CreateUserGuid = 'eff4dca6-fedc-4bd9-bbe5-79dec2bb39d8' and CollageDesign_Status=1)
                    int iTotal = mgr.GetMyPublishTotal(sUserID);
                    //make xml

                    XElement xml = new XElement("MyPublishs");

                    XElement XmlTotal = new XElement("Total", iTotal);

                    xml.Add(XmlTotal);
                    context.Response.Write(xml);
                }
                if (dic["action"].Equals("load_my_publish"))
                {
                    //Load All the my draft design
                    string sUserID = dic["user_id"].ToString();
                    int iPage = int.Parse(dic["page"].ToString());
                    int iPageDiv = int.Parse(dic["pageDiv"].ToString());
                    int iFirst = (iPage - 1) * iPageDiv + 1;
                    int iLast = iPage * iPageDiv;

                    List<Twee.Model.CollageDesign> templates = mgr.GetListByPage("CollageDesign_CreateUserGuid = '" + sUserID + "' and CollageDesign_Status=2",1,iFirst,iLast);
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
                if(dic["action"].Equals("load_single_design_freestyle")){
                    //Load Free Style Design
                    string sdesign_id = dic["design_id"].ToString();
                    DataSet ds = mgr.GetFreeStyleDesignByID(sdesign_id);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        XElement xml = new XElement("CollageDesigns");

                        DataRow dr = ds.Tables[0].Rows[0];
                        XElement subXml = new XElement("design");
                        XElement XmlID = new XElement("ID", dr["CollageDesign_ID"].ToString());
                        XElement XmlImg = new XElement("Image", dr["CollageDesign_ThumbnailFileName"].ToString());
                        XElement XmlTitle = new XElement("Title", dr["CollageDesing_Title"].ToString());
                        XElement XmlHtml = new XElement("innerHTML", dr["CollageDesign_HTML"].ToString());
                        XElement XmlData = new XElement("DesignData", dr["CollageDesign_JsonData"].ToString());

                        XElement XmlUsername = new XElement("Username", dr["username"].ToString());
                        XElement XmlCity = new XElement("City", dr["CityName"].ToString());
                        XElement XmlCountry = new XElement("Country", dr["country"].ToString());

                        //XElement XmlProduct_IDS = new XElement("Product_IDS", templates.Product_ids);
                        /*
                        XElement XmlProduct_ID2 = new XElement("Product_ID2", templates.Product_ID2);
                        XElement XmlProduct_ID3 = new XElement("Product_ID3", templates.Product_ID3);
                        XElement XmlProduct_ID4 = new XElement("Product_ID4", templates.Product_ID4);

                        XElement XmlProduct_ID5 = new XElement("Product_ID5", templates.Product_ID5);
                        XElement XmlProduct_ID6 = new XElement("Product_ID6", templates.Product_ID6);
                        XElement XmlProduct_ID7 = new XElement("Product_ID7", templates.Product_ID7);
                        XElement XmlProduct_ID8 = new XElement("Product_ID8", templates.Product_ID8);
                        */
                        XElement XmlInspiration = new XElement("Inspiration", dr["CollageDesign_Inspiration"].ToString());

                        subXml.Add(XmlID);
                        subXml.Add(XmlImg);
                        subXml.Add(XmlTitle);
                        subXml.Add(XmlHtml);
                        subXml.Add(XmlData);

                        subXml.Add(XmlUsername);
                        subXml.Add(XmlCity);
                        subXml.Add(XmlCountry);

                        subXml.Add(XmlInspiration);
                        //subXml.Add(XmlProduct_IDS);
                        /*
                        subXml.Add(XmlProduct_ID2);
                        subXml.Add(XmlProduct_ID3);
                        subXml.Add(XmlProduct_ID4);

                        subXml.Add(XmlProduct_ID5);
                        subXml.Add(XmlProduct_ID6);
                        subXml.Add(XmlProduct_ID7);
                        subXml.Add(XmlProduct_ID8);
                        */
                        xml.Add(subXml);

                        context.Response.Write(xml);
                    }
                }
                if (dic["action"].Equals("load_single_design"))
                {
                    //Load All the my draft design
                    string sdesign_id = dic["design_id"].ToString();


                    Twee.Model.CollageDesign templates = mgr.GetDesignByID(sdesign_id);
                    //make xml

                    XElement xml = new XElement("CollageDesigns");

                    XElement subXml = new XElement("design");
                    XElement XmlID = new XElement("ID", templates.id);
                    XElement XmlImg = new XElement("Image", templates.thumbnail);
                    XElement XmlTitle = new XElement("Title", templates.CollageDesing_Title);
                    XElement XmlHtml = new XElement("innerHTML", templates.innerHTML);
                    XElement XmlData = new XElement("DesignData", templates.TemplateHTML);

                    XElement XmlUsername = new XElement("Username", templates.User_name);
                    XElement XmlCity = new XElement("City", templates.City);
                    XElement XmlCountry = new XElement("Country", templates.Country);

                    XElement XmlProduct_IDS = new XElement("Product_IDS", templates.Product_ids);
                    /*
                    XElement XmlProduct_ID2 = new XElement("Product_ID2", templates.Product_ID2);
                    XElement XmlProduct_ID3 = new XElement("Product_ID3", templates.Product_ID3);
                    XElement XmlProduct_ID4 = new XElement("Product_ID4", templates.Product_ID4);

                    XElement XmlProduct_ID5 = new XElement("Product_ID5", templates.Product_ID5);
                    XElement XmlProduct_ID6 = new XElement("Product_ID6", templates.Product_ID6);
                    XElement XmlProduct_ID7 = new XElement("Product_ID7", templates.Product_ID7);
                    XElement XmlProduct_ID8 = new XElement("Product_ID8", templates.Product_ID8);
                    */
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
                    subXml.Add(XmlProduct_IDS);
                    /*
                    subXml.Add(XmlProduct_ID2);
                    subXml.Add(XmlProduct_ID3);
                    subXml.Add(XmlProduct_ID4);

                    subXml.Add(XmlProduct_ID5);
                    subXml.Add(XmlProduct_ID6);
                    subXml.Add(XmlProduct_ID7);
                    subXml.Add(XmlProduct_ID8);
                    */
                    xml.Add(subXml);
                    
                    context.Response.Write(xml);
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