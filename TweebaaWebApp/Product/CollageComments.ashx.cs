using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Twee.Mgr;
using Twee.Model;
using System.Xml.Linq;
using System.Reflection;
using System.Web.Script.Serialization;
using Twee.Comm;
using Twee.Mgr;
using System.Data;
using Twee.Model;
using Newtonsoft.Json;


namespace TweebaaWebApp.Product
{
    /// <summary>
    /// Summary description for CollageComments
    /// </summary>
    public class CollageComments : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            Dictionary<string, object> dic = null;
            //context.Response.Write("Hello World");
            //get all parameter
            //String s = context.Request["imgBase64"];
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(context.Request.InputStream);
                string reviewInfo = sr.ReadToEnd();

                if (reviewInfo.Length > 0)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    dic = js.Deserialize<Dictionary<string, object>>(reviewInfo);

                    string action = dic["action"].ToString();
                    Twee.Mgr.CollageCommentMgr mgr = new CollageCommentMgr();
                    if (action.Equals("save_comment"))
                    {
                        Twee.Model.CollageComments comment = new Twee.Model.CollageComments();
                        comment.UserID = new Guid(dic["txtUserID"].ToString());

                        comment.CollageDesign_ID = int.Parse(dic["txtDesignID"].ToString());
                        comment.comments = dic["txtComments"].ToString();
                        comment.CreateTime = System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

                        
                        mgr.Add(comment);
                        context.Response.Write("1");
                    }

                    if (action.Equals("load_products"))
                    {
                        context.Response.Clear();
                        string prdName = dic["prdName"].ToNullString();
                        string cate = dic["cate"].ToNullString();
                        string state = dic["state"].ToNullString();
                        string focusCateIDs = dic["focusCateIDs"].ToNullString();
                        string orderby = dic["orderby"].ToNullString();
                        int page = dic["page"].ToNullString().ToInt();
                        orderby = orderby == "" ? "addtime desc" : orderby;

                        CollageDesignProductMgr mgr1 = new Twee.Mgr.CollageDesignProductMgr();

                        int startIndex = ConfigParamter.prdPageSize * (page - 1) + 1;
                        int endIndex = ConfigParamter.prdPageSize * page;
                        DataTable dt = mgr1.GetPrdSale(prdName, cate, focusCateIDs, state, orderby, startIndex, endIndex);
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            context.Response.Write("");
                            return;
                        }
                        List<Prd> listReviewPrd = mgr1.DataTableToList3(dt);
                        string prdInfo = JsonConvert.SerializeObject(listReviewPrd);
                        context.Response.Write(prdInfo);
                    }
                    if (action.Equals("load"))
                    {
                        string sPage = dic["page"].ToString();
                        int iFirst = (int.Parse(sPage) - 1) * 20+1;
                        int iLast = int.Parse(sPage) * 20;

                        List<Twee.Model.CollageComments> comments = mgr.GetListByPage("CollageDesign_ID=" + dic["txtDesignID"].ToString(),iFirst,iLast);
                        //make xml

                        XElement xml = new XElement("DesignsComments");
                        for (int i = 0; i < comments.Count; i++) // Loop with for.
                        {
                            XElement subXml = new XElement("comment");
                            XElement XmlID = new XElement("ID", comments[i].id);
                            XElement XmlText = new XElement("comments_text", comments[i].comments);
                            XElement XmlUser = new XElement("user_name", comments[i].UserName);
                            XElement XmlTime = new XElement("CreateTime", comments[i].CreateTime);
                            subXml.Add(XmlID);
                            subXml.Add(XmlText);
                            subXml.Add(XmlUser);
                            subXml.Add(XmlTime);
                            xml.Add(subXml);
                        }
                        context.Response.Write(xml);
                    }
                    if (action.Equals("load_comment_total"))
                    {
                        string sDesignID = dic["DesignID"].ToString();
                        int iTotal = mgr.GetCommentsTotal(sDesignID);

                        XElement xml = new XElement("Comments");

                        XElement XmlTotal = new XElement("Total", iTotal);

                        xml.Add(XmlTotal);
                        context.Response.Write(xml);
                    }
                }
                else
                {
                    context.Response.Write("2");
                }
            }
            catch (Exception e)
            {
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