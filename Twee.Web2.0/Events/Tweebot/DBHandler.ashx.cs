using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Twee.Comm;
using Newtonsoft.Json;
using System.Net;

namespace TweebaaWebApp2.Events.Tweebot
{
    /// <summary>
    /// Summary description for DBHandler
    /// </summary>
    public class DBHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Dictionary<string, object> dic = null;
            StringBuilder strSql = new StringBuilder();
            string reviewInfo = "";
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(context.Request.InputStream);
                reviewInfo = sr.ReadToEnd();
                if (reviewInfo.Length > 10)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    dic = js.Deserialize<Dictionary<string, object>>(reviewInfo);
                    if (!dic.ContainsKey("action"))
                    {
                        return;
                    }
                    if (dic["action"].ToString().Equals("Load_Hotest_Video"))
                    {
                        // StringBuilder strSql = new StringBuilder();
                        strSql.Append("select top 10 tweebot_video_id,video_title,video_url,create_time,total_vote,u.username from wn_tweebot_video s left join wn_user u");
                        strSql.Append(" on s.userGuid=u.guid order by total_vote desc");

                        string sHTML = "";
                        DataSet ds = DbHelperSQL.Query(strSql.ToString());
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            string video_url = ds.Tables[0].Rows[i]["video_url"].ToString(); ;
                            int n = video_url.LastIndexOf(".");
                            var img_url = "";
                            if (video_url.Length < 2)
                            {
                                img_url = "/images/no_thumbnail.png";
                            }
                            else
                            {
                                img_url = "/upload/VideoImg/" + video_url.Substring(0, n) + ".jpg";
                            }
                            sHTML = sHTML + "<div class=\"item\">";
                            sHTML = sHTML + "<a href=\"#\">";
                            sHTML = sHTML + "<em class=\"overflow-hidden\">";
                            sHTML = sHTML + "<img class=\"img-responsive\" src=\"" + img_url + "\" alt=\"\">";
                            sHTML = sHTML + "</em>";
                            sHTML = sHTML + "<span>";
                            sHTML = sHTML + "<strong>" + ds.Tables[0].Rows[i]["video_title"].ToString() + "</strong>";
                            sHTML = sHTML + "<i>Submit by:" + ds.Tables[0].Rows[i]["username"].ToString() + "</i>";
                            sHTML = sHTML + "</span>";
                            sHTML = sHTML + "</a>";
                            sHTML = sHTML + "</div>";
                        }
                        context.Response.Write(sHTML);
                    }
                    if (dic["action"].ToString().Equals("post_vote"))
                    {
                        string txtVideo_id = dic["video_id"].ToString();
                        string txtComment = dic["txtComment"].ToString();
                        string txtUserGuid = dic["txtUserGuid"].ToString();
                        //get Ip address
                        string txtIp = GetVisitorIPAddress(false);

                        //check vote or not
                        strSql.Append("select count(*) as iCount from wn_tweebot_vote where tweebot_video_id=" + txtVideo_id + " and UserGuid='" + txtUserGuid + "'");
                        DataSet ds = DbHelperSQL.Query(strSql.ToString());

                        int iTotal = ds.Tables[0].Rows[0]["iCount"].ToString().ToInt();

                        if (iTotal == 0)
                        {
                            strSql.Clear();
                            SqlParameter[] parameters = {
                        new SqlParameter("@userGuid",SqlDbType.UniqueIdentifier,16),
                        new SqlParameter("@tweebot_video_id",SqlDbType.Int,4),
                        new SqlParameter("@tweebot_vote_comments",SqlDbType.NVarChar,500),
                        new SqlParameter("@tweebot_vote_ip",SqlDbType.NVarChar,50)

					    };

                            parameters[0].Value = new Guid(txtUserGuid);
                            parameters[1].Value = txtVideo_id;
                            parameters[2].Value = txtComment;
                            parameters[3].Value = txtIp;

                            string storedProcName = "spTweebotEventVote";

                            int iRet = DbHelperSQL.RunProcedure_NonQuery(storedProcName, parameters);

                            context.Response.Write("1");
                        }
                        else
                        {
                            context.Response.Write("0");

                        }

                    }
                    if (dic["action"].ToString().Equals("load_video_total"))
                    {


                        strSql.Append("select count(*) as iCount from wn_tweebot_video");
                        DataSet ds = DbHelperSQL.Query(strSql.ToString());

                        context.Response.Write(ds.Tables[0].Rows[0]["iCount"].ToString());

                    }
                    if (dic["action"].ToString().Equals("load_video"))
                    {
                        string orderby = dic["orderby"].ToString();
                        string spage = dic["page"].ToString();
                        string spageDiv = dic["pageDiv"].ToString();

                        int page = spage.ToInt();
                        int pageDiv = spageDiv.ToInt();

                        int startIndex = pageDiv * (page - 1) + 1;
                        int endIndex = pageDiv * page;

                        strSql.Append("select tweebot_video_id,video_title,video_url,create_time,total_vote,u.username from wn_tweebot_video s left join wn_user u");
                        strSql.Append(" on s.userGuid=u.guid");

                        DataSet ds = DbHelperSQL.Query(strSql.ToString());
                        DataTable dt = ds.Tables[0];
                        string prdInfo = JsonConvert.SerializeObject(dt);
                        context.Response.Write(prdInfo);
                    }
                    if (dic["action"].ToString().Equals("post_video"))
                    {
                        string txtVideoName = dic["txtVideoName"].ToString();
                        string txtVideoUrl = dic["txtVideoUrl"].ToString();
                        string txtDescription = dic["txtDescription"].ToString();
                        string txtUserGuid = dic["txtUserGuid"].ToString();

                        strSql.Append("insert into wn_tweebot_video(");
                        strSql.Append("userGuid,video_title,video_url,video_description,create_time,modify_time)");
                        strSql.Append(" values (");
                        strSql.Append("@userGuid,@video_title,@video_url,@video_description,@create_time,@modify_time)");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
                    new SqlParameter("@userGuid",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@video_title",SqlDbType.NVarChar,200),
                    new SqlParameter("@video_url",SqlDbType.NVarChar,50),
                    new SqlParameter("@video_description",SqlDbType.NVarChar,3000),
                    new SqlParameter("@create_time",SqlDbType.DateTime,8),
                    new SqlParameter("@modify_time",SqlDbType.DateTime,8)
					};

                        parameters[0].Value = new Guid(txtUserGuid);
                        parameters[1].Value = txtVideoName;
                        parameters[2].Value = txtVideoUrl;
                        parameters[3].Value = txtDescription;
                        parameters[4].Value = DateTime.Now;
                        parameters[5].Value = DateTime.Now;
                        object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
                        context.Response.Write("1");
                    }
                    if (dic["action"].ToString().Equals("post_suggestion"))
                    {
                        string idClassify = dic["idClassify"].ToString();
                        string txtTitle = dic["txtTitle"].ToString();
                        string txtDescription = dic["txtDescription"].ToString();
                        string txtUserGuid = dic["txtUserGuid"].ToString();

                        strSql.Append("insert into wn_tweebot_suggestion(");
                        strSql.Append("userGuid,type_id,suggestion_title,suggestion_description,create_time)");
                        strSql.Append(" values (");
                        strSql.Append("@userGuid,@type_id,@suggestion_title,@suggestion_description,@create_time)");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
                    new SqlParameter("@userGuid",SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@type_id",SqlDbType.SmallInt,4),
                    new SqlParameter("@suggestion_title",SqlDbType.NVarChar,200),
                    new SqlParameter("@suggestion_description",SqlDbType.NVarChar,3000),
                    new SqlParameter("@create_time",SqlDbType.DateTime,8)
					};

                        parameters[0].Value = new Guid(txtUserGuid);
                        parameters[1].Value = short.Parse(idClassify);
                        parameters[2].Value = txtTitle;
                        parameters[3].Value = txtDescription;
                        parameters[4].Value = DateTime.Now;

                        object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
                        context.Response.Write("1");
                    }
                    if (dic["action"].ToString().Equals("load_suggestion_total"))
                    {

                        strSql.Append("select count(*) as iCount from wn_tweebot_suggestion");
                        DataSet ds = DbHelperSQL.Query(strSql.ToString());

                        context.Response.Write(ds.Tables[0].Rows[0]["iCount"].ToString());

                    }
                    if (dic["action"].ToString().Equals("load_suggestion"))
                    {
                        string idClassify = dic["classify"].ToString();
                        string date = dic["date"].ToString();
                        string keyword = dic["keyword"].ToString();
                        string spage = dic["page"].ToString();
                        string spageDiv = dic["pageDiv"].ToString();

                        int page = spage.ToInt();
                        int pageDiv = spageDiv.ToInt();

                        int startIndex = pageDiv * (page - 1) + 1;
                        int endIndex = pageDiv * page;

                        strSql.Append("select suggestion_id,type_id,suggestion_title,create_time,u.username from wn_tweebot_suggestion s left join wn_user u");
                        strSql.Append(" on s.userGuid=u.guid");

                        DataSet ds = DbHelperSQL.Query(strSql.ToString());
                        DataTable dt = ds.Tables[0];
                        string prdInfo = JsonConvert.SerializeObject(dt);
                        context.Response.Write(prdInfo);
                    }
                    if (dic["action"].ToString().Equals("load_details"))
                    {
                        string txtID = dic["txtID"].ToString();
                        strSql.Append("select suggestion_id,type_id,suggestion_title,suggestion_description,create_time,u.username from wn_tweebot_suggestion s left join wn_user u");
                        strSql.Append(" on s.userGuid=u.guid");
                        strSql.Append(" where suggestion_id=" + txtID);
                        DataSet ds = DbHelperSQL.Query(strSql.ToString());
                        DataTable dt = ds.Tables[0];
                        string prdInfo = JsonConvert.SerializeObject(dt);
                        context.Response.Write(prdInfo);
                    }
                }
            }
            catch (Exception e)
            {
                context.Response.Write("0");
                Twee.Comm.CommUtil.GenernalErrorHandlerEx(e, reviewInfo);
                // context.Response.Write(e.Message);
                //context.Response.Write(e.StackTrace());
            }
        }
        public static string GetVisitorIPAddress(bool GetLan = false)
        {
            string visitorIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (String.IsNullOrEmpty(visitorIPAddress))
                visitorIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (string.IsNullOrEmpty(visitorIPAddress))
                visitorIPAddress = HttpContext.Current.Request.UserHostAddress;

            if (string.IsNullOrEmpty(visitorIPAddress) || visitorIPAddress.Trim() == "::1")
            {
                GetLan = true;
                visitorIPAddress = string.Empty;
            }

            if (GetLan)
            {
                if (string.IsNullOrEmpty(visitorIPAddress))
                {
                    //This is for Local(LAN) Connected ID Address
                    string stringHostName = Dns.GetHostName();
                    //Get Ip Host Entry
                    IPHostEntry ipHostEntries = Dns.GetHostEntry(stringHostName);
                    //Get Ip Address From The Ip Host Entry Address List
                    IPAddress[] arrIpAddress = ipHostEntries.AddressList;

                    try
                    {
                        visitorIPAddress = arrIpAddress[arrIpAddress.Length - 2].ToString();
                    }
                    catch
                    {
                        try
                        {
                            visitorIPAddress = arrIpAddress[0].ToString();
                        }
                        catch
                        {
                            try
                            {
                                arrIpAddress = Dns.GetHostAddresses(stringHostName);
                                visitorIPAddress = arrIpAddress[0].ToString();
                            }
                            catch
                            {
                                visitorIPAddress = "127.0.0.1";
                            }
                        }
                    }
                }
            }


            return visitorIPAddress;
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