﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Twee.Mgr;
using Twee.Model;
using System.Xml.Linq;
using Twee.Comm;
using System.Data;
//using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;

namespace TweebaaWebApp2.mobileApp
{
    /// <summary>
    /// Summary description for CollageAPI
    /// </summary>
    public class CollageAPI : IHttpHandler
    {
        private int IsSlave = System.Configuration.ConfigurationManager.AppSettings.Get("IsSlave").ToInt(); //System.Configuration.ConfigurationManager.ConnectionStrings["IsSlave"].ToString().ToInt();

        private string ReplaceInvalidChar(string s)
        {
            s=s.Replace("<","&lt;");
            s=s.Replace(">","&gt;");
            s=s.Replace("\"","&quot;");
            s=s.Replace("'","&apos;");
            s=s.Replace("&","&amp;");
            string re = @"[^\x09\x0A\x0D\x20-\xD7FF\xE000-\xFFFD\x10000-x10FFFF]";
            return Regex.Replace(s, re, "");  
           // return s;
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String sXMLTag="<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            sXMLTag = sXMLTag + System.Environment.NewLine;
            XMLCache xmlCache = new XMLCache();
            try
            {
                //POST ??
                String sGet=context.Request.QueryString["action"];
                //Twee.Comm.CommHelper.WrtLog("action=" + sGet);
                //context.Response.Write("Hello World");
                if (sGet.Equals("Save_Collage"))
                {
                    //this is a post ?
                    //String sAction = context.Request.Form["action"];
                    /*
                                         IMG=服务器返回文件名&SaveType=(0:Draft,1:publish)&Designer=用户登录的ID&ItemTotal=用了多少
                    个Item&x1=xx&y1=xx&w1=xx&h1=xx&a1=xx&p1=P_(product id) &x2=….
                     * 
                     * "IMG=/CollageImg/2015_08_17_10_34_14.png&SaveType=2&title=xxxx&description=&xxxx&Designer=eff4dca6-fedc-4bd9-bbe5-79dec2bb39d8&ItemTotal=1&img1=UploadImg/mid2/20150606/20150606191456_7770.png&x1=142.259003&y1=459.736755&s1=1.000000&a1=0.000000&p1=3d7aeec0-5ece-4fad-975c-a58ef9464af1"
                     * 
                    */

                    String sCollage = Twee.Comm.CommUtil.Quo(context.Request.Form["collage"]);
                    //Twee.Comm.CommHelper.WrtLog("sCollage=" + sCollage);
                    String[] sFormData = sCollage.Split('&');


                    String sImg = sFormData[0].Split('=')[1]; //0
                    String sSaveType = sFormData[1].Split('=')[1]; //1 
                    String sTitle =Twee.Comm.CommUtil.Quo( sFormData[2].Split('=')[1]); //Title
                    String sDescription =Twee.Comm.CommUtil.Quo( sFormData[3].Split('=')[1]); //description
                    String sDesigner = sFormData[4].Split('=')[1]; //2 
                     
                    String sItemTotal = sFormData[5].Split('=')[1]; //3
                    //要存两个表 wn_CollageDesign 及 wn_CollageDesignProduct
                   // String sDesingData="templateID=0&userID="+sDesigner+"&imgData="+sImg;
                    StringCollection products_ids = new StringCollection();
                    for (int i = 1; i <= sItemTotal.ToInt(); i++)
                    {
                        /*
                    &viewer_src=%2Fimages801%2Fmid2%2F20150310%2F20150310181353_3869.jpg&viewer_x=5px&viewer_y=0px&viewer_w=200px&viewer_h=200px&viewer2_src=%2Fimages801%2Fmid2%2F20150224%2F20150224175416_1827.jpg&viewer2_x=0.5px&viewer2_y=0.5px&viewer2_w=149px&viewer2_h=149px&viewer3_src=%2Fimages801%2Fmid2%2F20150319%2F20150319133054_0787.jpg&viewer3_x=0.5px&viewer3_y=0.5px&viewer3_w=149px&viewer3_h=149px&viewer4_src=%2Fimages801%2Fmid2%2F20150606%2F20150606130933_9493.jpg&viewer4_x=20px&viewer4_y=20px&viewer4_w=160px&viewer4_h=160px&txtDesignID=0&ProductID_1=P_bd817f56-3d37-4263-8a78-38adf21dddae&ProductID_2=P_76a114a9-cc64-4f66-a7c4-6a93ce97ced8&ProductID_3=P_cbda0ab3-6b5d-4e58-9439-8c3fb09cf562&ProductID_4=P_df8630a7-cb30-492b-b86b-f0fd44aa4b92&viewer5_src=&viewer5_x=%5Bobject+Object%5D&viewer5_y=%5Bobject+Object%5D&viewer5_w=%5Bobject+Object%5D&viewer5_h=%5Bobject+Object%5D&viewer6_src=&viewer6_x=%5Bobject+Object%5D&viewer6_y=%5Bobject+Object%5D&viewer6_w=%5Bobject+Object%5D&viewer6_h=%5Bobject+Object%5D&viewer7_src=&viewer7_x=%5Bobject+Object%5D&viewer7_y=%5Bobject+Object%5D&viewer7_w=%5Bobject+Object%5D&viewer7_h=%5Bobject+Object%5D&viewer8_src=&viewer8_x=%5Bobject+Object%5D&viewer8_y=%5Bobject+Object%5D&viewer8_w=%5Bobject+Object%5D&viewer8_h=%5Bobject+Object%5D&ProductID_5=&ProductID_6=&ProductID_7=&ProductID_8=
                       img1为第一个产品图片文件名
x1 为第一个产品的x坐标
y1 为第一个产品的y坐标
w1 为第一个产品的宽度
h2 为第一个产品的高度
a1 为第一个产品的旋转角度
p1 为第一个产品的ID ，如果为Label，请使用”L_”+当前的ID(1,2,3…)
action=Save_Collage
sCollage=IMG=/CollageImg/2015_10_25_21_02_50.jpg&SaveType=2&title=冻豆腐&description=&Designer=c49ca2f6-6228-4785-8128-b97c0a7b6280&ItemTotal=2
                         * &img1=20150901/1a737128-ae7b-4978-81df-2102022d4b1a_0.jpg&x1=183.669022&y1=374.081177&s1=1.000000&a1=0.000000&p1=1a737128-ae7b-4978-81df-2102022d4b1a&img2=20150831/a808c487-1418-4221-8379-c85cf708c8de_0.jpg&x2=234.889786&y2=159.554626&s2=1.000000&a2=0.000000&p2=a808c487-1418-4221-8379-c85cf708c8de

                         * 
                         * */
                        /*
                         * 		[0]	"IMG=/CollageImg/2015_08_17_10_39_12.png"	string
            [1]	"SaveType=2"	string
            [2]	"Designer=eff4dca6-fedc-4bd9-bbe5-79dec2bb39d8"	string
            [3]	"ItemTotal=1"	string
            [4]	"img1=UploadImg/mid2/20150606/20150606191456_7770.png"	string
            [5]	"x1=142.259003"	string
            [6]	"y1=459.736755"	string
            [7]	"s1=1.000000"	string
            [8]	"a1=0.000000"	string
            [9]	"p1=3d7aeec0-5ece-4fad-975c-a58ef9464af1"	string
                         */
                        int iIndex = i  * 6 + 5;
                        String sProduct = sFormData[iIndex].Split('=')[1];
                        //Add Image
                        /*
                        sDesingData = sDesingData + "&viewer" + sIndex + "_src=" + context.Request.Form["img" + sIndex];
                        //Add x
                        sDesingData = sDesingData + "&x" + sIndex + "=" + context.Request.Form["x" + sIndex];
                        //Add y
                        sDesingData = sDesingData + "&y" + sIndex + "=" + context.Request.Form["y" + sIndex];
                        //Add s1 
                        sDesingData = sDesingData + "&s" + sIndex + "=" + context.Request.Form["s" + sIndex];
                        //Add H
                       // sDesingData = sDesingData + "&h" + sIndex + "=" + context.Request.Form["h" + sIndex];
                        //Add a1
                        sDesingData = sDesingData + "&a" + sIndex + "=" + context.Request.Form["a" + sIndex];
                        //Add p1
                        sDesingData = sDesingData + "&p" + sIndex + "=" + context.Request.Form["p" + sIndex];
                         * */

                        products_ids.Add(sProduct);

                    }
                     StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into wn_CollageDesign(");
                    strSql.Append("CollageTemp_ID,");
                    strSql.Append("CollageDesign_Status,");
                    strSql.Append("CollageCate_ID,");
                    strSql.Append("CollageDesing_Title,");
                    strSql.Append("CollageDesign_Tag,");
                    strSql.Append("CollageDesign_Inspiration,");
                    strSql.Append("CollageDesign_CreateUserGuid,");
                    strSql.Append("CollageDesign_CreateTime,");
                    strSql.Append("CollageDesign_UpdateTime,");
                    strSql.Append("CollageDesign_PublishTime,");
                    strSql.Append("CollageDesign_HTML,");
                    strSql.Append("CollageDesign_ThumbnailFileName,");
                    strSql.Append("Notify_Designer) values(");

                    strSql.Append("0,"); //CollageTemp_ID
                    strSql.Append(sSaveType + ","); //CollageDesign_Status
                    strSql.Append("0,"); //CollageCate_ID
                    strSql.Append("'" + sTitle + "',"); //CollageDesing_Title
                    strSql.Append("'',"); //CollageDesign_Tag
                    strSql.Append("'"+sDescription+"','"); //CollageDesign_Inspiration
                    strSql.Append(sDesigner.ToGuid()+"','");
                    strSql.Append(System.DateTime.Now.ToString()+"','");//CollageDesign_CreateTime
                    strSql.Append(System.DateTime.Now.ToString() + "','");//System.DateTime.Now.ToString()
                    strSql.Append(System.DateTime.Now.ToString() + "','");//System.DateTime.Now.ToString()
                    strSql.Append(sCollage + "','");//CollageDesign_HTML
                    strSql.Append(sImg+"',"); //CollageDesign_ThumbnailFileName
                    strSql.Append("0);select @@IDENTITY;");
                    object obj = DbHelperSQL.GetSingle(strSql.ToString());
                    if (obj == null)
                    {
                        // return 0;
                        context.Response.Write("0");
                    }
                    else
                    {
                        int iDesignID = Convert.ToInt32(obj);
                        //insert into wn_CollageDesignProduct

                        //Twee.Comm.CommHelper.WrtLog("total=" + products_ids.Count);
                        string sProducts = "";
                        for (int i = 0; i < products_ids.Count; i++)
                        {
                            //Is it a product ?
                            if (products_ids[i].Length > 10)
                            {
                                String pID = products_ids[i];
                                String pIndex=(i+1).ToString();
                                StringBuilder strSql2 = new StringBuilder();
                                strSql2.Append("insert into wn_CollageDesignProduct(");
                                strSql2.Append("CollageDesign_ID,prdGuid,iOrder)");
                                strSql2.Append(" values (");
                                strSql2.Append(iDesignID.ToString() + ",'"+pID.ToGuid()+"',"+pIndex+")");
                                //Twee.Comm.CommHelper.WrtLog(" sql=" + strSql2.ToString());
                                DbHelperSQL.GetSingle(strSql2.ToString());
                                sProducts = sProducts + pID + ",";
                            }
                        }
                        if (sProducts.Length > 2) sProducts = sProducts.Substring(0, sProducts.Length - 1);
                        
                        if (IsSlave == 1)
                        {

                            Twee.Comm.CommHelper.WrtLog("iDesignID=" + iDesignID.ToString() + " sProducts=" + sProducts + " IsSlave=" + IsSlave);

                            TweebaaWebService.MobileAppDBWebService ws = new TweebaaWebService.MobileAppDBWebService();

                            ws.SaveCollageExCompleted += new TweebaaWebService.SaveCollageExCompletedEventHandler(ws_SaveCollageExCompleted);
                            ws.SaveCollageExAsync(iDesignID.ToString(), sSaveType, sTitle, sDescription, sDesigner,
                                sCollage, sImg, sProducts);
                        }
                        context.Response.Write(iDesignID);
                    }


                }
                if (sGet.Equals("remove_my_collage"))
                {
                    String sUserID = context.Request.QueryString["user_id"].ToString();
                    String sDesignID = context.Request.QueryString["design_id"].ToString();

                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("update  wn_CollageDesign set CollageDesign_Status=6 where ");
                    strSql2.Append("CollageDesign_ID='" + sDesignID + "' and CollageDesign_CreateUserGuid='");
                    strSql2.Append(sUserID + "'");
                    DbHelperSQL.ExecuteSql(strSql2.ToString());
                    Twee.Comm.CommHelper.WrtLog(strSql2.ToString());
                    if (IsSlave == 1)
                    {

                        TweebaaWebService.MobileAppDBWebService ws = new TweebaaWebService.MobileAppDBWebService();
                        ws.MobileAppRemoveMyCollageCompleted += new TweebaaWebService.MobileAppRemoveMyCollageCompletedEventHandler(ws_MobileAppRemoveMyCollageCompleted);
                        ws.MobileAppRemoveMyCollageAsync(sDesignID, sUserID);
                    }


                }
                if (sGet.Equals("remove_favour"))
                {
                    String sUserID = context.Request.QueryString["user_id"].ToString();
                    String sDesignID = context.Request.QueryString["design_id"].ToString();

                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("delete from wn_favorite where ");
                    strSql2.Append("sourcetype=2 and CollageDesign_ID='"+sDesignID+"' and userguid='");
                    strSql2.Append( sUserID + "'");
                    object obj = DbHelperSQL.GetSingle(strSql2.ToString());
                    if (obj == null)
                    {
                        // return 0;
                        context.Response.Write("0");
                    }
                    else
                    {
                        int iID = Convert.ToInt32(obj);
                        
                        if (IsSlave == 1)
                        {
                            
                            TweebaaWebService.MobileAppDBWebService ws = new TweebaaWebService.MobileAppDBWebService();
                            ws.RemoveFavourCompleted += new TweebaaWebService.RemoveFavourCompletedEventHandler(ws_RemoveFavourCompleted);
                            ws.RemoveFavourAsync(sDesignID, sUserID);
                        }
                        context.Response.Write(iID);
                    }

                }
                if (sGet.Equals("save_favour"))
                {
                    String sUserID = context.Request.QueryString["user_id"].ToString();
                    String sDesignID = context.Request.QueryString["design_id"].ToString();

                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("insert into wn_favorite(");
                    strSql2.Append("sourcetype,CollageDesign_ID,edttime,userguid)");
                    strSql2.Append(" values (");
                    strSql2.Append("2" + ",'" + sDesignID + "','" + System.DateTime.Now.ToString() + "','" + sUserID + "');select @@IDENTITY;");
                    object obj = DbHelperSQL.GetSingle(strSql2.ToString());
                    if (obj == null)
                    {
                        // return 0;
                        context.Response.Write("0");
                    }
                    else
                    {
                        int iID = Convert.ToInt32(obj);
                        
                        if (IsSlave == 1)
                        {
                            
                            TweebaaWebService.MobileAppDBWebService ws = new TweebaaWebService.MobileAppDBWebService();
                            ws.SaveFavourCompleted += new TweebaaWebService.SaveFavourCompletedEventHandler(ws_SaveFavourCompleted);
                            ws.SaveFavourAsync(sDesignID, sUserID);
                        }
                        context.Response.Write(iID);
                    }
                }
                if (sGet.Equals("create_share_link"))
                {

                }
                if (sGet.Equals("load_category"))
                {
                     StringBuilder strSql0 = new StringBuilder();
                     strSql0.Append("SELECT  guid, name FROM wn_prdCate WHERE        (layer = 0)");
                     DataSet ds = DbHelperSQL.Query(strSql0.ToString());
                     XElement xml = new XElement("ProductCategory");
                     if (ds.Tables[0].Rows.Count > 0)
                     {
                         //二级目录
                         //XElement xml_0 = new XElement("category_1");
                         for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                         {

                             XElement XmlCatID = new XElement("category_1", new XAttribute("category_guid", ds.Tables[0].Rows[i]["guid"]), ds.Tables[0].Rows[i]["name"]);
                             xml.Add(XmlCatID);

                             StringBuilder strSql1 = new StringBuilder();
                             strSql1.Append("SELECT    guid, name FROM   wn_prdCate WHERE   prtGuid='" + ds.Tables[0].Rows[i]["guid"] + "'");
                             DataSet ds1 = DbHelperSQL.Query(strSql1.ToString());
                             if (ds1.Tables[0].Rows.Count > 0)
                             {
                                 //三级目录
                                 for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                                 {
                                     XElement XmlCatID1 = new XElement("category_2", new XAttribute("category_guid", ds1.Tables[0].Rows[j]["guid"]),
                                         ds1.Tables[0].Rows[j]["name"]);
                                     XmlCatID.Add(XmlCatID1);
                                     StringBuilder strSql2 = new StringBuilder();

                                     strSql2.Append("SELECT    guid, name FROM   wn_prdCate WHERE   prtGuid='" + ds1.Tables[0].Rows[j]["guid"] + "'");
                                     DataSet ds2 = DbHelperSQL.Query(strSql1.ToString());
                                     for (int k = 0; k < ds2.Tables[0].Rows.Count; k++)
                                     {
                                         XElement XmlCatID2 = new XElement("category_3", new XAttribute("category_guid", ds2.Tables[0].Rows[k]["guid"]),
                                             ds2.Tables[0].Rows[k]["name"]);
                                         XmlCatID1.Add(XmlCatID2);

                                     }
                                 }
                             }
                         }

                     }
                     context.Response.Clear();context.Response.Write(sXMLTag);
                     context.Response.Write(xml);
                     context.Response.Write(System.Environment.NewLine);return;
                }
                if (sGet.Equals("load_product_total"))
                {
                    try
                    {
                        context.Response.Clear();
                        string prdName = "";// context.Request.QueryString["prdName"].ToNullString();
                        string cate = "";// context.Request.QueryString["cate"].ToNullString();
                        string state = "";// context.Request.QueryString["state"].ToNullString();
                        string focusCateIDs = "";// context.Request.QueryString["focusCateIDs"].ToNullString();
                        string orderby = "";// context.Request.QueryString["orderby"].ToNullString();
                        //int page =  context.Request.QueryString["page"].ToNullString().ToInt();
                        orderby = orderby == "" ? "addtime desc" : orderby;



                        PrdMgr mgr = new PrdMgr();
                        int startIndex = 1;
                        int endIndex = int.MaxValue;
                        DataTable dt = mgr.MobileAppGetCollagePrd(prdName, cate, focusCateIDs, "", "", "", state, orderby, startIndex, endIndex);
                        XElement xmlBackground = new XElement("CollageProduct");
                        XElement subXml = new XElement("Product_total");
                        if (dt == null || dt.Rows.Count == 0)
                        {
                           
                            XElement XmlTotal = new XElement("total", 0);
                            subXml.Add(XmlTotal);
                            xmlBackground.Add(subXml);
                            context.Response.Write(xmlBackground);
                            return;
                        }

                        XElement XmlTotal1 = new XElement("total", dt.Rows.Count);
                        subXml.Add(XmlTotal1);
                        xmlBackground.Add(subXml);
                        context.Response.Clear();context.Response.Write(sXMLTag);
                        context.Response.Write(xmlBackground);
                        context.Response.Write(System.Environment.NewLine);return;
                        //context.Response.Write(dt.Rows.Count);
                    }
                    catch (Exception)
                    {
                        XElement xmlBackground = new XElement("CollageProduct");
                        XElement subXml = new XElement("Product_total");
                        XElement XmlTotal = new XElement("total", 0);
                        subXml.Add(XmlTotal);
                        xmlBackground.Add(subXml);
                        context.Response.Clear();context.Response.Write(sXMLTag);
                        context.Response.Write(xmlBackground);
                        context.Response.Write(System.Environment.NewLine);return;
                        
                    }
                }
                if (sGet.Equals("load_search_product"))
                {
                    try
                    {
                        context.Response.Clear();
                        string prdName = context.Request.QueryString["keyword"].ToNullString();
                        string cate = "";// context.Request.QueryString["cate"].ToNullString();
                        string state = "";// context.Request.QueryString["state"].ToNullString();
                        string focusCateIDs = "";// context.Request.QueryString["focusCateIDs"].ToNullString();
                        string orderby = "";// context.Request.QueryString["orderby"].ToNullString();
                        int page = context.Request.QueryString["page"].ToNullString().ToInt();
                        int pageDiv = context.Request.QueryString["pageDiv"].ToNullString().ToInt();
                        if (pageDiv < 1) pageDiv = 20;
                        //orderby = orderby == "" ? "addtime desc" : orderby;
                        orderby = orderby == "" && state == "" ? " wnstat desc" : orderby;

                        string sCacheFile = sGet + "_" + GetDateString() + "_" + context.Request.QueryString["keyword"].ToString() + "_" + context.Request.QueryString["page"].ToString();
                        //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                        //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                        if (xmlCache.IsXmlFileExists(sCacheFile))
                        {
                            // Twee.Comm.CommHelper.WrtLog("111111111");
                            xmlCache.ReadCacheXML(context, sCacheFile);
                        }
                        else
                        {
                            PrdMgr mgr = new PrdMgr();
                            int startIndex = pageDiv * (page - 1) + 1;
                            int endIndex = pageDiv * page;

                            //(string prdName, string cate, string focusCateIDs, string prdCate1, string prdCate2, string prdCate3, string state, string orderby, int startIndex, int endIndex)
                            DataTable dt = mgr.MobileAppGetCollagePrd(prdName, cate, focusCateIDs, "", "", "", state, orderby, startIndex, endIndex);

                            if (dt == null || dt.Rows.Count == 0)
                            {
                                //context.Response.Write("");
                                context.Response.Clear(); context.Response.Write(sXMLTag);
                                //context.Response.Write(xml);
                                context.Response.Write(System.Environment.NewLine);
                                return;
                            }
                            List<Prd> listReviewPrd = mgr.DataTableToList3(dt);
                            //string prdInfo = JsonConvert.SerializeObject(listReviewPrd);
                            //context.Response.Write(prdInfo);
                            XElement xml = new XElement("CollageProductLists");
                            for (int i = 0; i < listReviewPrd.Count; i++)
                            {
                                Prd p = listReviewPrd[i];
                                XElement subXml = new XElement("Product");
                                XElement XmlID = new XElement("ID", p.prdGuid.ToString());
                                String sImg = p.fileurl.Replace("big/", "mid2/");
                                // sImg = sImg.Replace(".jpg", ".png");
                                sImg = sImg.Replace("/upload/UploadImg/mid2/", "");
                                sImg = sImg.Replace("UploadImg/mid2/", "");
                                //remove /upload/UploadImg/mid2/
                                XElement XmlImg = new XElement("Image", sImg);
                                p.name = ReplaceInvalidChar(p.name);
                                XElement XmlName = new XElement("Name", p.name);
                                XElement XmlPrice = new XElement("price", "$"+p.saleprice);
                                String sDesc = p.txtjj;
                                if (sDesc.Length > 100) sDesc = p.txtjj.Substring(0, 100);
                                sDesc = ReplaceInvalidChar(sDesc);
                                XElement XmlShortDec = new XElement("Description", sDesc);
                                subXml.Add(XmlID);
                                subXml.Add(XmlImg);
                                subXml.Add(XmlName);
                                subXml.Add(XmlPrice);
                                subXml.Add(XmlShortDec);
                                xml.Add(subXml);

                            }
                            xmlCache.WriteCacheXML(context, xml, sCacheFile);
                            /*
                            context.Response.Clear();context.Response.Write(sXMLTag);
                            context.Response.Write(xml);
                            context.Response.Write(System.Environment.NewLine);return;
                             * */
                        }

                    }
                    catch (Exception)
                    {
                        context.Response.Write("");
                    }
                }
                if (sGet.Equals("load_product")){

                    try
                    {
                        context.Response.Clear();
                        string prdName = "";// context.Request.QueryString["prdName"].ToNullString();
                        string cate = "";// context.Request.QueryString["cate"].ToNullString();
                        string state = "";// context.Request.QueryString["state"].ToNullString();
                        string focusCateIDs = "";// context.Request.QueryString["focusCateIDs"].ToNullString();
                        string orderby = "";// context.Request.QueryString["orderby"].ToNullString();
                        int page = context.Request.QueryString["page"].ToNullString().ToInt();
                        int pageDiv = context.Request.QueryString["pageDiv"].ToNullString().ToInt();
                        if (pageDiv < 1) pageDiv = 20;
                        //orderby = orderby == "" ? "addtime desc" : orderby;
                        orderby = orderby == "" && state == "" ? " wnstat desc" : orderby;               
   
                    string sCacheFile = sGet +  "_" + context.Request.QueryString["cate_guid"].ToString() + "_" + context.Request.QueryString["page"].ToString();
                    //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                    //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                    if (xmlCache.IsXmlFileExists(sCacheFile))
                    {
                        // Twee.Comm.CommHelper.WrtLog("111111111");
                        xmlCache.ReadCacheXML(context, sCacheFile);
                    }
                    else
                    {
                        PrdMgr mgr = new PrdMgr();
                        int startIndex = pageDiv * (page - 1) + 1;
                        int endIndex = pageDiv * page;

                        //(string prdName, string cate, string focusCateIDs, string prdCate1, string prdCate2, string prdCate3, string state, string orderby, int startIndex, int endIndex)
                        DataTable dt = mgr.MobileAppGetCollagePrd(prdName, cate, focusCateIDs, context.Request.QueryString["cate_guid"].ToString(), "", "", state, orderby, startIndex, endIndex);

                        if (dt == null || dt.Rows.Count == 0)
                        {
                            //context.Response.Write("");
                            context.Response.Clear(); context.Response.Write(sXMLTag);
                            //context.Response.Write(xml);
                            context.Response.Write(System.Environment.NewLine); 
                            return;
                        }
                        List<Prd> listReviewPrd = mgr.DataTableToList3(dt);
                        //string prdInfo = JsonConvert.SerializeObject(listReviewPrd);
                        //context.Response.Write(prdInfo);
                        XElement xml = new XElement("CollageProductLists");
                        for (int i = 0; i < listReviewPrd.Count; i++)
                        {
                            Prd p = listReviewPrd[i];
                            XElement subXml = new XElement("Product");
                            XElement XmlID = new XElement("ID", p.prdGuid.ToString());
                            String sImg = p.fileurl.Replace("big/", "mid2/");
                            // sImg = sImg.Replace(".jpg", ".png");
                            sImg = sImg.Replace("/upload/UploadImg/mid2/", "");
                            sImg = sImg.Replace("UploadImg/mid2/", "");
                            //remove /upload/UploadImg/mid2/
                            XElement XmlImg = new XElement("Image", sImg);

                           // XNode cdata = doc.CreateCDataSection(p.name);
                            p.name = ReplaceInvalidChar(p.name);
                            XElement XmlName = new XElement("Name", p.name);
                            XElement XmlPrice = new XElement("price", "$"+p.saleprice);
                            String sDesc = p.txtjj;
                            if (sDesc.Length > 100) sDesc = p.txtjj.Substring(0, 100);
                            sDesc = ReplaceInvalidChar(sDesc);
                            XElement XmlShortDec = new XElement("Description", sDesc);
                            subXml.Add(XmlID);
                            subXml.Add(XmlImg);
                            subXml.Add(XmlName);
                            subXml.Add(XmlPrice);
                            subXml.Add(XmlShortDec);
                            xml.Add(subXml);

                        }
                        xmlCache.WriteCacheXML(context, xml, sCacheFile);
                        /*
                        context.Response.Clear();context.Response.Write(sXMLTag);
                        context.Response.Write(xml);
                        context.Response.Write(System.Environment.NewLine);return;
                         * */
                    }

                    }
                    catch (Exception e)
                    {
                        context.Response.Write("");
                        Twee.Comm.CommUtil.GenernalErrorHandler(e);
                    }
                }
                if (sGet.Equals("load_template"))
                {
                    string sPage = context.Request.QueryString["page"].ToString();
                    string sPageDiv = context.Request.QueryString["pageDiv"].ToString();
                    int iPage = int.Parse(sPage);
                    int iFirst = (iPage - 1) * int.Parse(sPageDiv) + 1;
                    int iLast = iPage * int.Parse(sPageDiv);
                    string sCacheFile = sGet + "_" + GetDateString() + "_" + context.Request.QueryString["page"].ToString() + "_" + context.Request.QueryString["pageDiv"].ToString();
                    //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                    //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                    if (xmlCache.IsXmlFileExists(sCacheFile))
                    {
                        // Twee.Comm.CommHelper.WrtLog("111111111");
                        xmlCache.ReadCacheXML(context, sCacheFile);
                    }
                    else
                    {

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
                        /*
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xml);
                    context.Response.Write(System.Environment.NewLine);return;*/
                        xmlCache.WriteCacheXML(context, xml, sCacheFile);
                    }
                }
                if (sGet.Equals("load_single_template"))
                {

                    //Load template from database
                    string sID = context.Request.QueryString["template_id"].ToString();
                    string sCacheFile = sGet + "_" + GetDateString() + "_" + sID;
                    //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                    //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                    if (xmlCache.IsXmlFileExists(sCacheFile))
                    {
                        // Twee.Comm.CommHelper.WrtLog("111111111");
                        xmlCache.ReadCacheXML(context, sCacheFile);
                    }
                    else
                    {
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
                        /*
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xml);
                    context.Response.Write(System.Environment.NewLine);return;*/
                        xmlCache.WriteCacheXML(context, xml, sCacheFile);
                    }
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
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xmlBackground);
                    context.Response.Write(System.Environment.NewLine);return;
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
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xmlBackground);
                    context.Response.Write(System.Environment.NewLine);return;
                }

                if (sGet.Equals("load_background"))
                {
                    
                    string sPage = context.Request.QueryString["page"].ToString();
                    string sPageDiv = context.Request.QueryString["pageDiv"].ToString();
                    string sCacheFile = sGet + "_" + GetDateString() + "_" + context.Request.QueryString["page"].ToString() + "_" + context.Request.QueryString["pageDiv"].ToString();
                    //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                    //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                    if (xmlCache.IsXmlFileExists(sCacheFile))
                    {
                        // Twee.Comm.CommHelper.WrtLog("111111111");
                        xmlCache.ReadCacheXML(context, sCacheFile);
                    }
                    else
                    {
                        Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
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
                        /*
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xmlBackground);
                    context.Response.Write(System.Environment.NewLine);return;*/
                        xmlCache.WriteCacheXML(context, xmlBackground, sCacheFile);
                    }
                }
                //xml_roots.Add(xmlBackground);
                if (sGet.Equals("load_decoration_total"))
                {
                    Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                    int iTotal = mgr.GetDecorationImgTotal("CollageDecorationImg_IsActive=2");
                    XElement xml = new XElement("CollageDecoration");
                    XElement subXml = new XElement("decoration_total");
                    XElement XmlTotal = new XElement("total", iTotal);
                    subXml.Add(XmlTotal);
                    xml.Add(subXml);
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xml);
                    context.Response.Write(System.Environment.NewLine);return;
                }
                if (sGet.Equals("load_decoration_Christmas"))
                {

                    string sPage = "1"; //context.Request.QueryString["page"].ToString();
                    string sPageDiv = "99";// context.Request.QueryString["pageDiv"].ToString();

                    string sCacheFile = sGet;// +"_" + context.Request.QueryString["page"].ToString() + "_" + context.Request.QueryString["pageDiv"].ToString();
                    //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                    //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                    if (xmlCache.IsXmlFileExists(sCacheFile))
                    {
                        // Twee.Comm.CommHelper.WrtLog("111111111");
                        xmlCache.ReadCacheXML(context, sCacheFile);
                    }
                    else
                    {
                        Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                        List<Twee.Model.CollageDecorationImg> DecorationImg = mgr.GetDecorationImg(sPage, sPageDiv, "CollageDecorationImg_IsActive=4");
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
                        /*
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xmlDecoration);
                    context.Response.Write(System.Environment.NewLine);return;*/
                        xmlCache.WriteCacheXML(context, xmlDecoration, sCacheFile);
                    }
                }
                if (sGet.Equals("load_decoration_Background"))
                {

                    string sPage = "1"; //context.Request.QueryString["page"].ToString();
                    string sPageDiv = "99";// context.Request.QueryString["pageDiv"].ToString();

                    string sCacheFile = sGet;// +"_" + context.Request.QueryString["page"].ToString() + "_" + context.Request.QueryString["pageDiv"].ToString();
                    //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                    //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                    if (xmlCache.IsXmlFileExists(sCacheFile))
                    {
                        // Twee.Comm.CommHelper.WrtLog("111111111");
                        xmlCache.ReadCacheXML(context, sCacheFile);
                    }
                    else
                    {
                        Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                        List<Twee.Model.CollageDecorationImg> DecorationImg = mgr.GetDecorationImg(sPage, sPageDiv, "CollageDecorationImg_IsActive=5");
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
                        /*
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xmlDecoration);
                    context.Response.Write(System.Environment.NewLine);return;*/
                        xmlCache.WriteCacheXML(context, xmlDecoration, sCacheFile);
                    }
                }
                if (sGet.Equals("load_decoration"))
                {
                    
                    string sPage = context.Request.QueryString["page"].ToString();
                    string sPageDiv = context.Request.QueryString["pageDiv"].ToString();

                    string sCacheFile = sGet + "_" + GetDateString() + "_" + context.Request.QueryString["page"].ToString() + "_" + context.Request.QueryString["pageDiv"].ToString();
                    //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                    //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                    if (xmlCache.IsXmlFileExists(sCacheFile))
                    {
                        // Twee.Comm.CommHelper.WrtLog("111111111");
                        xmlCache.ReadCacheXML(context, sCacheFile);
                    }
                    else
                    {
                        Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                        List<Twee.Model.CollageDecorationImg> DecorationImg = mgr.GetDecorationImg(sPage,sPageDiv, "CollageDecorationImg_IsActive=2");
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
                        /*
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xmlDecoration);
                    context.Response.Write(System.Environment.NewLine);return;*/
                        xmlCache.WriteCacheXML(context, xmlDecoration, sCacheFile);
                    }
                }

                if (sGet.Equals("load_artise_total"))
                {
                    Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                    int iTotal = mgr.GetDecorationImgTotal("CollageDecorationImg_IsActive=3");
                    XElement xml = new XElement("CollageDecoration");
                    XElement subXml = new XElement("decoration_total");
                    XElement XmlTotal = new XElement("total", iTotal);
                    subXml.Add(XmlTotal);
                    xml.Add(subXml);
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xml);
                    context.Response.Write(System.Environment.NewLine);return;
                }
                if (sGet.Equals("load_artise"))
                {
                    
                    string sPage = context.Request.QueryString["page"].ToString();
                    string sPageDiv = context.Request.QueryString["pageDiv"].ToString();
                    string sCacheFile = sGet + "_" + GetDateString() + "_" + context.Request.QueryString["page"].ToString() + "_" + context.Request.QueryString["pageDiv"].ToString();
                    //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                    //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                    if (xmlCache.IsXmlFileExists(sCacheFile))
                    {
                        // Twee.Comm.CommHelper.WrtLog("111111111");
                        xmlCache.ReadCacheXML(context, sCacheFile);
                    }
                    else
                    {
                        Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                        List<Twee.Model.CollageDecorationImg> DecorationImg = mgr.GetDecorationImg(sPage,sPageDiv, "CollageDecorationImg_IsActive=3");
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
                        /*
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xmlDecoration);
                    context.Response.Write(System.Environment.NewLine);return;*/
                        xmlCache.WriteCacheXML(context, xmlDecoration, sCacheFile);
                    }

                }
                if (sGet.Equals("load_sort_publish"))
                {
                    string sCacheFile = sGet + "_" + xmlCache.GetMinuteString() + "_" + context.Request.QueryString["sort_type"].ToString();
                    //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                    //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                      if (xmlCache.IsXmlFileExists(sCacheFile))
                      {
                          // Twee.Comm.CommHelper.WrtLog("111111111");
                          xmlCache.ReadCacheXML(context, sCacheFile);
                      }
                      else
                      {

                          int iSort = context.Request.QueryString["sort_type"].ToString().ToInt();
                          string sSort = "";
                          if (iSort == 1)
                          {
                              sSort = " CollageDesign_Status=2 order by CollageDesign_PublishTime desc";
                          }
                          if (iSort == 2)
                          {
                              sSort = " CollageDesign_Status=2 order by CollageDesing_Title ";
                          }

                          Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                          DataSet ds = mgr.GetCollageListForMobileApp(sSort);
                          DataTable dt = ds.Tables[0];
                          
                          //List<Twee.Model.CollageDesign> templates = mgr.GetModelList(sSort);
                          //make xml
                          if (dt.Rows.Count > 0)
                          {
                              XElement xml = new XElement("CollageDesigns");
                              for (int i = 0; i < dt.Rows.Count; i++) // Loop with for.
                              {
                                  DataRow dr = dt.Rows[i];
                                  XElement subXml = new XElement("design");
                                  XElement XmlID = new XElement("ID", dr["CollageDesign_ID"].ToString());
                                  XElement XmlImg = new XElement("Image", dr["CollageDesign_ThumbnailFileName"].ToString());
                                  XElement XmlTitle = new XElement("Title", dr["CollageDesing_Title"].ToString());
                                  XElement XmlInspiration = new XElement("Inspiration", dr["CollageDesign_Inspiration"].ToString());
                                  XElement XmlUsername = new XElement("Username",dr["username"].ToString());
                                  // XElement XmlCity = new XElement("City", templates[i].City);
                                  XElement XmlCountry = new XElement("Country", " ");
                                  String sShareCount = dr["shareCount"].ToString();
                                  if (String.IsNullOrEmpty(sShareCount)) sShareCount = "0";
                                  XElement XmlShareCount = new XElement("ShareCount", sShareCount);
                                  //get favour count ?
                                  /*
                                  String strSQL = "select count(*) as icount from wn_share where ColllageDesign_ID=" + dr["CollageDesign_ID"].ToString();
                                  DataSet ds2 = DbHelperSQL.Query(strSQL.ToString());*/
                                  String sLikeount = dr["favoriteCount"].ToString();
                                  if (String.IsNullOrEmpty(sLikeount)) sLikeount = "0";
                                  XElement XmlLikeCount = new XElement("LikeCount", sLikeount);

                                  subXml.Add(XmlID);
                                  subXml.Add(XmlImg);
                                  subXml.Add(XmlTitle);
                                  subXml.Add(XmlInspiration);

                                  subXml.Add(XmlUsername);
                                  //subXml.Add(XmlCity);
                                  subXml.Add(XmlLikeCount);
                                  subXml.Add(XmlCountry);
                                  subXml.Add(XmlShareCount);


                                  xml.Add(subXml);
                              }
                              /*
                          context.Response.Clear();context.Response.Write(sXMLTag);
                          context.Response.Write(xml);
                          context.Response.Write(System.Environment.NewLine);return;*/
                              xmlCache.WriteCacheXML(context, xml, sCacheFile);
                          }
                          else
                          {
                              context.Response.Clear(); context.Response.Write(sXMLTag);
                          }
                          //Twee.Comm.CommHelper.WrtLog("2222222222222");
                      }
                }
                if (sGet.Equals("load_search_publish"))
                {
                    Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                    string sKeywords = context.Request.QueryString["txtKeywords"].ToString();
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
                        //XElement XmlCity = new XElement("City", templates[i].City);
                        XElement XmlCountry = new XElement("Country", templates[i].Country);
                        XElement XmlShareCount = new XElement("ShareCount", templates[i].ShareTotalCount);
                        //get favour count ?
                        String strSQL = "select count(*) as icount from wn_share where ColllageDesign_ID=" + templates[i].id;
                        DataSet ds = DbHelperSQL.Query(strSQL.ToString());
                        String sLikeCount = ds.Tables[0].Rows[0]["icount"].ToString();
                        XElement XmlLikeCount = new XElement("LikeCount", sLikeCount);

                        subXml.Add(XmlID);
                        subXml.Add(XmlImg);
                        subXml.Add(XmlTitle);
                        subXml.Add(XmlInspiration);

                        subXml.Add(XmlUsername);
                        //subXml.Add(XmlCity);
                        subXml.Add(XmlLikeCount);
                        subXml.Add(XmlCountry);
                        subXml.Add(XmlShareCount);
                       

                        xml.Add(subXml);
                    }
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xml);
                    context.Response.Write(System.Environment.NewLine);return;
                }
                if (sGet.Equals("load_my_favour_total"))
                {
                    String strUser = context.Request.QueryString["user_id"].ToString();
                    String strSQL1 = "select CollageDesign_ID from wn_favorite where sourcetype=2 and userguid='" + strUser + "'";
                    DataSet ds = DbHelperSQL.Query(strSQL1.ToString());
                    int iTotal = ds.Tables[0].Rows.Count;
                   
                    XElement xml = new XElement("CollageMyFavour");
                    XElement subXml = new XElement("MyFavour_total");
                    XElement XmlTotal = new XElement("total", iTotal);
                    subXml.Add(XmlTotal);
                    xml.Add(subXml);
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xml);
                    context.Response.Write(System.Environment.NewLine);return;

                }
                if (sGet.Equals("load_my_favour"))
                {
                    //get my favour
                    String strUser = context.Request.QueryString["user_id"].ToString();
                    string sCacheFile = sGet + "_" + GetDateString() + "_" + strUser;
                    //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                    //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                    if (xmlCache.IsXmlFileExists(sCacheFile))
                    {
                       // Twee.Comm.CommHelper.WrtLog("111111111");
                        xmlCache.ReadCacheXML(context,sCacheFile);
                    }
                    else
                    {
                    String strSQL1 = "select DISTINCT CollageDesign_ID from wn_favorite where sourcetype=2 and userguid='" + strUser + "'";
                    DataSet ds1 = DbHelperSQL.Query(strSQL1.ToString());
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        String sIDs = "";
                        for (int k = 0; k < ds1.Tables[0].Rows.Count; k++)
                        {
                            sIDs = sIDs + ds1.Tables[0].Rows[k]["CollageDesign_ID"].ToString() + ",";

                        }
                        sIDs = sIDs.Substring(0, sIDs.Length - 1);

                        Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                        //Load All the published design
                        int iPage = int.Parse(context.Request.QueryString["page"].ToString());
                        if (iPage <= 0) iPage = 1;
                        int iPageDiv = int.Parse(context.Request.QueryString["pageDiv"].ToString());
                        int iFirst = (iPage - 1) * iPageDiv + 1;
                        int iLast = iPage * iPageDiv;
                        List<Twee.Model.CollageDesign> templates = mgr.GetListByPage("CollageDesign_ID in (" + sIDs + ") and CollageDesign_Status=2", 1,iFirst, iLast);
                        //make xml
                        if (templates.Count > 0)
                        {
                            XElement xml = new XElement("CollageDesigns");
                            for (int i = 0; i < templates.Count; i++) // Loop with for.
                            {
                                XElement subXml = new XElement("design");
                                XElement XmlID = new XElement("ID", templates[i].id);
                                XElement XmlImg = new XElement("Image", templates[i].thumbnail);
                                XElement XmlTitle = new XElement("Title", templates[i].CollageDesing_Title);
                                XElement XmlInspiration = new XElement("Inspiration", templates[i].Inspiration);
                                XElement XmlUsername = new XElement("Username", templates[i].User_name);
                                //XElement XmlCity = new XElement("City", templates[i].City);
                                XElement XmlCountry = new XElement("Country", templates[i].Country);
                                XElement XmlShareCount = new XElement("ShareCount", templates[i].ShareTotalCount);

                                //get favour count ?
                                String strSQL = "select count(*) as icount from wn_share where ColllageDesign_ID=" + templates[i].id;
                                DataSet ds = DbHelperSQL.Query(strSQL.ToString());
                                String sLikeCount = ds.Tables[0].Rows[0]["icount"].ToString();
                                XElement XmlLikeCount = new XElement("LikeCount", sLikeCount);

                                subXml.Add(XmlID);
                                subXml.Add(XmlImg);
                                subXml.Add(XmlTitle);
                                subXml.Add(XmlInspiration);

                                subXml.Add(XmlUsername);
                                // subXml.Add(XmlCity);
                                subXml.Add(XmlLikeCount);
                                subXml.Add(XmlCountry);
                                subXml.Add(XmlShareCount);


                                xml.Add(subXml);
                            }
                            /*
                            context.Response.Clear();context.Response.Write(sXMLTag);
                            context.Response.Write(xml);
                            context.Response.Write(System.Environment.NewLine);return;*/
                            xmlCache.WriteCacheXML(context, xml, sCacheFile);
                        }
                        else
                        {
                            context.Response.Clear(); context.Response.Write(sXMLTag); 

                        }

                      }
                    }
                }
                if (sGet.Equals("load_all_publish"))
                {
                    
                    //Load All the published design
                    int iPage = int.Parse(context.Request.QueryString["page"].ToString());
                    if (iPage <= 0) iPage = 1;
                    int iPageDiv = int.Parse(context.Request.QueryString["pageDiv"].ToString());
                    int iFirst = (iPage - 1) * iPageDiv + 1;
                    int iLast = iPage * iPageDiv;

                    string sCacheFile = sGet + "_" + GetDateString() + "_" + context.Request.QueryString["page"].ToString() + "_" + context.Request.QueryString["pageDiv"].ToString();
                    //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                    //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                    if (xmlCache.IsXmlFileExists(sCacheFile))
                    {
                       // Twee.Comm.CommHelper.WrtLog("load_all_publish 111111111");
                        xmlCache.ReadCacheXML(context,sCacheFile);
                    }
                    else
                    {
                        Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                        //Twee.Comm.CommHelper.WrtLog(" load_all_publish 222222");
                        List<Twee.Model.CollageDesign> templates = mgr.GetAllList("CollageDesign_Status=2");
                        //make xml
                       // Twee.Comm.CommHelper.WrtLog(" load_all_publish 333");
                        XElement xml = new XElement("CollageDesigns");
                        for (int i = 0; i < templates.Count; i++) // Loop with for.
                        {
                            XElement subXml = new XElement("design");
                            XElement XmlID = new XElement("ID", templates[i].id);
                            XElement XmlImg = new XElement("Image", templates[i].thumbnail);
                            XElement XmlTitle = new XElement("Title", templates[i].CollageDesing_Title);
                            XElement XmlInspiration = new XElement("Inspiration", templates[i].Inspiration);
                            XElement XmlUsername = new XElement("Username", templates[i].User_name);
                            // XElement XmlCity = new XElement("City", templates[i].City);
                            XElement XmlCountry = new XElement("Country", templates[i].Country);
                            XElement XmlShareCount = new XElement("ShareCount", templates[i].ShareTotalCount);

                            //get favour count ?
                            String strSQL = "select count(*) as icount from wn_share where ColllageDesign_ID=" + templates[i].id;
                            DataSet ds = DbHelperSQL.Query(strSQL.ToString());
                            String sLikeCount = ds.Tables[0].Rows[0]["icount"].ToString();
                            XElement XmlLikeCount = new XElement("LikeCount", sLikeCount);

                            subXml.Add(XmlID);
                            subXml.Add(XmlImg);
                            subXml.Add(XmlTitle);
                            subXml.Add(XmlInspiration);

                            subXml.Add(XmlUsername);
                            // subXml.Add(XmlCity);
                            subXml.Add(XmlLikeCount);
                            subXml.Add(XmlCountry);
                            subXml.Add(XmlShareCount);


                            xml.Add(subXml);
                        }
                       // Twee.Comm.CommHelper.WrtLog(" load_all_publish 444");
                        /*
                        context.Response.Clear(); context.Response.Write(sXMLTag);
                        context.Response.Write(xml);
                        context.Response.Write(System.Environment.NewLine);  return;
                         * */
                        xmlCache.WriteCacheXML(context, xml, sCacheFile);
                        //Twee.Comm.CommHelper.WrtLog("load_all_publish 2222");
                    }
                }
                if (sGet.Equals("load_my_draft_total"))
                {
                    
                    string sUserID = context.Request.QueryString["user_id"].ToString();
                    string sCacheFile = sGet + "_" + GetDateString() + "_" + sUserID;
                    //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                    //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                    if (xmlCache.IsXmlFileExists(sCacheFile))
                    {
                        // Twee.Comm.CommHelper.WrtLog("111111111");
                        xmlCache.ReadCacheXML(context, sCacheFile);
                    }
                    else
                    {

                        //(CollageDesign_CreateUserGuid = 'eff4dca6-fedc-4bd9-bbe5-79dec2bb39d8' and CollageDesign_Status=1)

                        //make xml
                        Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                        int iTotal = mgr.GetMyDraftTotal(sUserID);
                        XElement xml = new XElement("MyDrafts");

                        XElement XmlTotal = new XElement("Total", iTotal);

                        xml.Add(XmlTotal);
                        /*
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xml);
                    context.Response.Write(System.Environment.NewLine);return;*/
                        xmlCache.WriteCacheXML(context, xml, sCacheFile);
                    }
                }
                if (sGet.Equals("load_my_draft"))
                {
                    
                    //Load All the my draft design
                    string sUserID = context.Request.QueryString["user_id"].ToString();
                    int iPage = int.Parse(context.Request.QueryString["page"].ToString());
                    int iPageDiv = int.Parse(context.Request.QueryString["pageDiv"].ToString());
                    int iFirst = (iPage - 1) * iPageDiv + 1;
                    int iLast = iPage * iPageDiv;
                    string sCacheFile = sGet + "_" + GetDateString() + "_" +sUserID+"_"+ context.Request.QueryString["page"].ToString() + "_" + context.Request.QueryString["pageDiv"].ToString();
                    //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                    //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                    if (xmlCache.IsXmlFileExists(sCacheFile))
                    {
                        // Twee.Comm.CommHelper.WrtLog("111111111");
                        xmlCache.ReadCacheXML(context, sCacheFile);
                    }
                    else
                    {
                        Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                        List<Twee.Model.CollageDesign> templates = mgr.GetListByPage("CollageDesign_CreateUserGuid = '" + sUserID + "' and CollageDesign_Status=1",1, iFirst, iLast);
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
                        /*
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xml);
                    context.Response.Write(System.Environment.NewLine);return;*/
                        xmlCache.WriteCacheXML(context, xml, sCacheFile);
                    }
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
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xml);
                    context.Response.Write(System.Environment.NewLine);return;
                }

                if (sGet.Equals("load_publish_total"))
                {
                    Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
                    //string sUserID = context.Request.QueryString["user_id"].ToString();
                    //(CollageDesign_CreateUserGuid = 'eff4dca6-fedc-4bd9-bbe5-79dec2bb39d8' and CollageDesign_Status=1)
                    string sCacheFile = sGet + "_" + xmlCache.GetMinuteString() ;

                    if (xmlCache.IsXmlFileExists(sCacheFile))
                    {
                        // Twee.Comm.CommHelper.WrtLog("111111111");
                        xmlCache.ReadCacheXML(context, sCacheFile);
                    }
                    else
                    {
                        int iTotal = mgr.GetPublishTotal();
                        //make xml

                        XElement xml = new XElement("Published");

                        XElement XmlTotal = new XElement("Total", iTotal);

                        xml.Add(XmlTotal);
                        context.Response.Clear(); context.Response.Write(sXMLTag);
                        context.Response.Write(xml);
                        context.Response.Write(System.Environment.NewLine);  return;
                    }
                }
                if (sGet.Equals("load_my_publish"))
                {
                    
                    //Load All the my draft design
                    string sUserID = context.Request.QueryString["user_id"].ToString();
                    int iPage = int.Parse(context.Request.QueryString["page"].ToString());
                    int iPageDiv = int.Parse(context.Request.QueryString["pageDiv"].ToString());
                    int iFirst = (iPage - 1) * iPageDiv + 1;
                    int iLast = iPage * iPageDiv;
                    string sCacheFile = sGet + "_" + xmlCache.GetMinuteString() + "_" + sUserID + "_" + context.Request.QueryString["page"].ToString() + "_" + context.Request.QueryString["pageDiv"].ToString();
                    //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                    //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                    if (xmlCache.IsXmlFileExists(sCacheFile))
                    {
                        // Twee.Comm.CommHelper.WrtLog("111111111");
                        xmlCache.ReadCacheXML(context, sCacheFile);
                    }
                    else
                    {
                        Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();

                        DataSet ds = mgr.GetCollageListForMobileApp("CollageDesign_CreateUserGuid = '" + sUserID + "' and CollageDesign_Status=2 order by CollageDesign_ID desc");
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
                            // XElement XmlCity = new XElement("City", templates[i].City);
                            XElement XmlCountry = new XElement("Country", " ");
                            String sShareCount = dr["shareCount"].ToString();
                            if (String.IsNullOrEmpty(sShareCount)) sShareCount = "0";
                            XElement XmlShareCount = new XElement("ShareCount", sShareCount);
                            //get favour count ?
                            /*
                            String strSQL = "select count(*) as icount from wn_share where ColllageDesign_ID=" + dr["CollageDesign_ID"].ToString();
                            DataSet ds2 = DbHelperSQL.Query(strSQL.ToString());*/
                            String sLikeount = dr["favoriteCount"].ToString();
                            if (String.IsNullOrEmpty(sLikeount)) sLikeount = "0";
                            XElement XmlLikeCount = new XElement("LikeCount", sLikeount);

                            subXml.Add(XmlID);
                            subXml.Add(XmlImg);
                            subXml.Add(XmlTitle);
                            subXml.Add(XmlInspiration);

                            subXml.Add(XmlUsername);
                            //subXml.Add(XmlCity);
                            subXml.Add(XmlLikeCount);
                            subXml.Add(XmlCountry);
                            subXml.Add(XmlShareCount);


                            xml.Add(subXml);

                        }
                        /*
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xml);
                    context.Response.Write(System.Environment.NewLine);return;*/
                        xmlCache.WriteCacheXML(context, xml, sCacheFile);
                    }
                }
                if (sGet.Equals("load_single_design"))
                {
                    
                    //Load All the my draft design
                    string sdesign_id = context.Request.QueryString["design_id"].ToString();
                    string sCacheFile = sGet + "_" + GetDateString() + "_" + sdesign_id;
                    //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                    //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                    if (xmlCache.IsXmlFileExists(sCacheFile))
                    {
                        // Twee.Comm.CommHelper.WrtLog("111111111");
                        xmlCache.ReadCacheXML(context, sCacheFile);
                    }
                    else
                    {

                        Twee.Mgr.CollageDesignMgr mgr = new CollageDesignMgr();
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
                        /*
                    context.Response.Clear();context.Response.Write(sXMLTag);
                    context.Response.Write(xml);
                    context.Response.Write(System.Environment.NewLine);return;*/
                        xmlCache.WriteCacheXML(context, xml, sCacheFile);
                    }
                }
            }
            catch (Exception e1)
            {

                Twee.Comm.CommUtil.GenernalErrorHandler(e1);
            }
        }

        void ws_MobileAppRemoveMyCollageCompleted(object sender, TweebaaWebService.MobileAppRemoveMyCollageCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void ws_SaveCollageExCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Twee.Comm.CommHelper.WrtLog("ws_SaveCollageExCompleted");
            //throw new NotImplementedException();
        }

        void ws_SaveFavourCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void ws_RemoveFavourCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void ws_SaveCollageCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //throw new NotImplementedException();
           // Twee.Comm.CommHelper.WrtLog(e.Error.Message);

        }

        private string GetDateString()
        {
            DateTime dateOnly = System.DateTime.Now;// .Date;
            return dateOnly.ToString("MM_dd_yyyy");
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