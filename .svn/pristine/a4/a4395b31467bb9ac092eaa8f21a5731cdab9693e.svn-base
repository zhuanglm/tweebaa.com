using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twee.Model;
using Twee.Mgr;
using System.Web.Script.Serialization;
using Twee.Comm;
using System.Data;
using Newtonsoft.Json;


namespace TweebaaWebApp.Events.BugsReport
{
    /// <summary>
    /// Summary description for BugsHandler
    /// </summary>
    public class BugsHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            Dictionary<string, object> dic = null;

            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(context.Request.InputStream);
                string reviewInfo = sr.ReadToEnd();

                JavaScriptSerializer js = new JavaScriptSerializer();
                dic = js.Deserialize<Dictionary<string, object>>(reviewInfo);

                if (dic["action"].ToString().Equals("post_bug"))
                {

                   string txtBrowser=dic["txtBrowser"].ToString();
                   string bugsType = dic["bugsType"].ToString();
                   string txtLevel=dic["txtLevel"].ToString();
                   string txtTitle=dic["txtTitle"].ToString();
                   string txtDescription=dic["txtDescription"].ToString();
                   string txtUserGuid = dic["txtUserGuid"].ToString();


                   Twee.Model.BugsReport model = new Twee.Model.BugsReport();
                   model.BrowserType = txtBrowser;
                   model.BugsType = short.Parse(bugsType);
                   model.BugsTitle = txtTitle;
                   model.BugsLevel = short.Parse(txtLevel);
                   model.BugsDescription = txtDescription;
                   model.CreateTime = System.DateTime.Now;
                   model.UserGuid = new Guid(txtUserGuid);

                   Twee.Mgr.BugsReportMgr mgr = new BugsReportMgr();
                   mgr.Add(model);
                   context.Response.Write("1");
                }
                if(dic["action"].ToString().Equals("querycount")){
                    //get total bugs amount
                    string sKeyword = dic["sKeyword"].ToString();
                    Twee.Mgr.BugsReportMgr mgr = new BugsReportMgr();
                    int recordCount = mgr.GetBugsTotal(sKeyword);
                    int pageCount = recordCount % ConfigParamter.pageSize == 0 ? recordCount / ConfigParamter.pageSize : recordCount / ConfigParamter.pageSize + 1;
                    context.Response.Clear();
                    context.Response.Write(recordCount + "," + pageCount);
                }
                if (dic["action"].ToString().Equals("querydata"))
                {
                    int page = dic["page"].ToNullString().ToInt();
                    int startIndex = ConfigParamter.pageSize * (page - 1) + 1;
                    int endIndex = ConfigParamter.pageSize * page;
                    string sKeyword = dic["sKeyword"].ToString();
                    BugsReportMgr mgr = new BugsReportMgr();
                    DataTable dt = mgr.GetBugsRecords( sKeyword, startIndex, endIndex);
                    string data = JsonConvert.SerializeObject(dt);
                    context.Response.Clear();
                    context.Response.Write(data);
                }


                if (dic["action"].ToString().Equals("query_rank_count"))
                {
                    //get total bugs amount

                    Twee.Mgr.BugsReportMgr mgr = new BugsReportMgr();
                    int recordCount = mgr.GetRankingTotal();
                    int pageCount = recordCount % ConfigParamter.pageSize == 0 ? recordCount / ConfigParamter.pageSize : recordCount / ConfigParamter.pageSize + 1;
                    context.Response.Clear();
                    context.Response.Write(recordCount + "," + pageCount);
                }
                if (dic["action"].ToString().Equals("query_rank_data"))
                {
                    int page = dic["page"].ToNullString().ToInt();
                    int startIndex = ConfigParamter.pageSize * (page - 1) + 1;
                    int endIndex = ConfigParamter.pageSize * page;
                    string sKeyword = dic["sKeyword"].ToString();
                    BugsReportMgr mgr = new BugsReportMgr();
                    DataTable dt = mgr.GetRankingRecords(sKeyword, startIndex, endIndex);
                    string data = JsonConvert.SerializeObject(dt);
                    context.Response.Clear();
                    context.Response.Write(data);
                }
                if (dic["action"].ToString().Equals("bug_details"))
                {
                    string sID = dic["txtID"].ToNullString();
                    BugsReportMgr mgr = new BugsReportMgr();
                    DataTable dt =  mgr.GetBugsDetails(sID);
                    string data = JsonConvert.SerializeObject(dt);
                    context.Response.Clear();
                    context.Response.Write(data);
                }

                if (dic["action"].ToString().Equals("Dulplicate"))
                {
                    string sID = dic["txtID"].ToNullString();
                    BugsReportMgr mgr = new BugsReportMgr();
                    if (mgr.UpdateBugStatus(sID, "2"))
                    {

                        context.Response.Write("1");
                    }
                    else
                    {
                        context.Response.Write("0");
                    }
                }

                if (dic["action"].ToString().Equals("not_a_bugs"))
                {
                    string sID = dic["txtID"].ToNullString();
                    BugsReportMgr mgr = new BugsReportMgr();
                    if (mgr.UpdateBugStatus(sID, "1"))
                    {

                        context.Response.Write("1");
                    }
                    else
                    {
                        context.Response.Write("0");
                    }
                }
                if (dic["action"].ToString().Equals("fixed"))
                {
                    string sID = dic["txtID"].ToNullString();
                    BugsReportMgr mgr = new BugsReportMgr();
                    if (mgr.UpdateBugStatus(sID, "3"))
                    {

                        context.Response.Write("1");
                    }
                    else
                    {
                        context.Response.Write("0");
                    }
                }
                if (dic["action"].ToString().Equals("Closed"))
                {
                    string sID = dic["txtID"].ToNullString();
                    BugsReportMgr mgr = new BugsReportMgr();
                    if (mgr.UpdateBugStatus(sID, "4"))
                    {

                        context.Response.Write("1");
                    }
                    else
                    {
                        context.Response.Write("0");
                    }
                }
                if (dic["action"].ToString().Equals("give_points"))
                {
                    string sID = dic["txtID"].ToNullString();
                    string sPoint = dic["txtPoint"].ToNullString();
                    string sUserID = dic["txtUserID"].ToNullString();
                    BugsReportMgr mgr = new BugsReportMgr();
                    int i=mgr.GiveUserPoints(sID, sPoint, "0", sUserID);
                    context.Response.Write(i);
                }
            }
            catch (Exception e)
            {
                context.Response.Write("0");
                // context.Response.Write(e.Message);
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