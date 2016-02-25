using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Twee.Mgr;
using System.Configuration;
using System.Security.Cryptography;

namespace TweebaaWebApp2.mobileApp
{
    /// <summary>
    /// Summary description for GameAPI
    /// </summary>
    public class GameAPI : IHttpHandler
    {
        private int IsSlave = System.Configuration.ConfigurationManager.AppSettings.Get("IsSlave").ToInt(); //System.Configuration.ConfigurationManager.ConnectionStrings["IsSlave"].ToString().ToInt();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            XMLCache xmlCache=new XMLCache();

                StringBuilder strSql = new StringBuilder();
                String sXMLTag = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
                sXMLTag = sXMLTag + System.Environment.NewLine;
                try
                {

                    String sGet = context.Request.QueryString["action"];
                    if (sGet.Equals("save_tracking"))
                    {
                        /*
                         * $URL/GameAPI.ashx?action=save_tracking&layer=find_diff&plat_form=android&screen=1024x768
                         */

                        String sLayer = context.Request.QueryString["layer"];
                        String plat_form = context.Request.QueryString["plat_form"];
                        String screen = context.Request.QueryString["screen"];

                        //StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into wn_MobileAppTracking(");
                        strSql.Append("GameLayer,PlatForm,ScreenSize,TrackingDate)");
                        strSql.Append(" values (");
                        strSql.Append("@GameLayer,@PlatForm,@ScreenSize,@TrackingDate)");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
                    new SqlParameter("@GameLayer",SqlDbType.NVarChar,50),
                    new SqlParameter("@PlatForm",SqlDbType.NVarChar,50),
                    new SqlParameter("@ScreenSize",SqlDbType.NVarChar,50),
                    new SqlParameter("@TrackingDate",SqlDbType.DateTime,8)
					};

                        parameters[0].Value = sLayer;
                        parameters[1].Value = plat_form;
                        parameters[2].Value = screen;
                        parameters[3].Value = DateTime.Now;


                        object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);


                    }
                    if (sGet.Equals("load_theme"))
                    {
                        strSql.Append("select  top 1 a.theme_id,b.theme_name, b.theme_img FROM  wn_MobileAppGameTheme AS a LEFT OUTER JOIN wn_MobileAppGameThemeInfo AS b ON a.theme_id = b.theme_id where a.Is_Activity=1 order by a.theme_id desc");

                        DataSet ds = DbHelperSQL.Query(strSql.ToString());
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            XElement xml = new XElement("mobileAppTheme");
                            XElement XmlError = new XElement("error", "0");
                            xml.Add(XmlError);
                            XElement Xmltheme_id = new XElement("theme_id", ds.Tables[0].Rows[0]["theme_id"]);
                            xml.Add(Xmltheme_id);

                            XElement Xmltheme_name = new XElement("theme_name", ds.Tables[0].Rows[0]["theme_name"]);
                            xml.Add(Xmltheme_name);
                            XElement Xmltheme_img = new XElement("theme_img", ds.Tables[0].Rows[0]["theme_img"]);
                            xml.Add(Xmltheme_img);

                            context.Response.Write(sXMLTag);context.Response.Write(xml); context.Response.Write(System.Environment.NewLine);
                        }
                        else
                        {
                            XElement xml = new XElement("mobileAppTheme");
                            XElement XmlError = new XElement("error", "1");
                            xml.Add(XmlError);
                            context.Response.Write(sXMLTag);context.Response.Write(xml); context.Response.Write(System.Environment.NewLine);
                        }
                    }
                    if (sGet.Equals("load_top_ranking"))
                    {
                      string sCacheFile = sGet + "_" + xmlCache.GetHourString();
                    //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                    //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                      if (xmlCache.IsXmlFileExists(sCacheFile))
                      {
                          // Twee.Comm.CommHelper.WrtLog("111111111");
                          xmlCache.ReadCacheXML(context, sCacheFile);
                      }
                      else
                      {
                          //string sTop = context.Request.QueryString["top"].ToString();
                          /*
                          strSql.Append("SELECT        TOP (10) a.ranking_id, a.game_type_id, a.game_player_guid, a.game_score, a.submit_date, b.username");
                          strSql.Append(" FROM            wn_MobileAppGameRanking AS a INNER JOIN");
                          strSql.Append("     wn_user AS b ON a.game_player_guid = b.guid ");
                          strSql.Append("ORDER BY a.game_score DESC");
                          */
                          strSql.Append("SELECT        b.username, a.score,b.guid");
                          strSql.Append(" FROM            wn_user AS b INNER JOIN");
                          strSql.Append("   (SELECT        TOP (10) game_player_guid, SUM(game_score) AS score");
                          strSql.Append("     FROM            wn_MobileAppGameRanking");
                          strSql.Append("     GROUP BY game_player_guid");
                           strSql.Append("    ORDER BY score DESC) AS a ON b.guid = a.game_player_guid");
                          DataSet ds = DbHelperSQL.Query(strSql.ToString());
                          if (ds.Tables[0].Rows.Count > 0)
                          {
                              XElement xml = new XElement("mobileAppTopRanking");
                              /*
                               XElement XmlError = new XElement("error", "0");
                               xml.Add(XmlError);
                               XElement Xmlround = new XElement("Rankings");
                               xml.Add(Xmlround);*/
                              for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                              {

                                  if (ds.Tables[0].Rows[i]["username"].ToString().Length >= 2)
                                  {
                                      XElement XmlRank = new XElement("Ranking");

                                      XElement XmlGame_Type_ID = new XElement("game_type_id", "0");
                                      XmlRank.Add(XmlGame_Type_ID);

                                      XElement XmlUsername = new XElement("username", ds.Tables[0].Rows[i]["username"]);
                                      XmlRank.Add(XmlUsername);
                                      XElement XmlGame_Score = new XElement("game_score", ds.Tables[0].Rows[i]["score"]);
                                      XmlRank.Add(XmlGame_Score);

                                      xml.Add(XmlRank);
                                  }
                                  //XElement Xmlround_info = new XElement("round_info", ds.Tables[0].Rows[i]["round_info"]);
                                  //Xmlround.Add(Xmlround_info);
                              }
                              if (ds.Tables[0].Rows.Count < 10)
                              {
                                  for (int i = ds.Tables[0].Rows.Count; i <= 10; i++)
                                  {

                                      XElement XmlRank = new XElement("Ranking");

                                      XElement XmlGame_Type_ID = new XElement("game_type_id", "0");
                                      XmlRank.Add(XmlGame_Type_ID);

                                      XElement XmlUsername = new XElement("username", "");
                                      XmlRank.Add(XmlUsername);
                                      XElement XmlGame_Score = new XElement("game_score", "");
                                      XmlRank.Add(XmlGame_Score);

                                      xml.Add(XmlRank);
                                  }
                              }
                              /*
                              context.Response.Write(sXMLTag);context.Response.Write(xml); context.Response.Write(System.Environment.NewLine);*/
                              xmlCache.WriteCacheXML(context, xml, sCacheFile);
                          }
                          else
                          {

                              XElement xml = new XElement("mobileAppTopRanking");
                              XElement XmlError = new XElement("error", "1");
                              xml.Add(XmlError);
                              context.Response.Write(sXMLTag); context.Response.Write(xml); context.Response.Write(System.Environment.NewLine);
                          }
                      }
                    }
                    if (sGet.Equals("load_round"))
                    {
                        string sThemeID = context.Request.QueryString["theme_id"].ToString();
                        strSql.Append("SELECT a.round_id,b.round_step,b.round_type, b.round_info FROM wn_MobileAppGameRound AS a LEFT OUTER JOIN wn_MobileAppGameRoundInfo AS b ON a.round_id = b.round_id WHERE a.theme_id =" + sThemeID);

                        DataSet ds = DbHelperSQL.Query(strSql.ToString());
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            XElement xml = new XElement("mobileAppRound");
                            XElement XmlError = new XElement("error", "0");
                            xml.Add(XmlError);
                            XElement Xmlround = new XElement("round", new XAttribute("total", ds.Tables[0].Rows.Count));
                            xml.Add(Xmlround);
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {


                                XElement Xmlround_id = new XElement("round_id", ds.Tables[0].Rows[i]["round_id"]);
                                Xmlround.Add(Xmlround_id);

                                XElement Xmlround_step = new XElement("round_step", ds.Tables[0].Rows[i]["round_step"]);
                                Xmlround.Add(Xmlround_step);
                                XElement Xmlround_type = new XElement("round_type", ds.Tables[0].Rows[i]["round_type"]);
                                Xmlround.Add(Xmlround_type);

                                XElement Xmlround_info = new XElement("round_info", ds.Tables[0].Rows[i]["round_info"]);
                                Xmlround.Add(Xmlround_info);
                            }
                            context.Response.Write(sXMLTag);context.Response.Write(xml); context.Response.Write(System.Environment.NewLine);
                        }
                        else
                        {
                            XElement xml = new XElement("mobileAppRound");
                            XElement XmlError = new XElement("error", "1");
                            xml.Add(XmlError);
                            context.Response.Write(sXMLTag);context.Response.Write(xml); context.Response.Write(System.Environment.NewLine);
                        }

                    }
                    if (sGet.Equals("Get_check_in_days"))
                    {
                        string sUserID = context.Request.QueryString["UserID"].ToString();

                        string date = DateTime.Now.ToString();
                       // StringBuilder strSql = new StringBuilder();
                        strSql.Append(string.Format("select top 7 createtime,DATEDIFF(dd,createtime,'{1}') as diff from wn_userQianDao  where userid='{0}' order by createtime desc;", sUserID, date));
                        DataSet ds = DbHelperSQL.Query(strSql.ToString());
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            DataTable dt = ds.Tables[0];
                            //return dt;
                            XElement xml = new XElement("mobileAppGetDailyCheckIn");
                            XElement XmlResult = new XElement("result",  ds.Tables[0].Rows.Count);
                            xml.Add(XmlResult);

                            XElement XmlResults = new XElement("results");
                            xml.Add(XmlResults);

                            /////////////
                            DateTime signDate = Convert.ToDateTime(dt.Rows[0]["createtime"].ToString());
                            TimeSpan ts = DateTime.Now.Subtract(signDate);
                            int dd = ts.Days;

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                                XElement Xmlcreatetime = new XElement("createtime", ds.Tables[0].Rows[i]["createtime"]);
                                XmlResults.Add(Xmlcreatetime);



                                string dateStr = dt.Rows[i]["createtime"].ToString();
                                DateTime time = Convert.ToDateTime(dateStr);

                                if (IsInSameWeek(time, DateTime.Now))
                                {
                                    XElement Xmldiff = new XElement("SameWeek", "1");
                                    XmlResults.Add(Xmldiff);
                                }
                                else
                                {
                                    XElement Xmldiff = new XElement("SameWeek", "0");
                                    XmlResults.Add(Xmldiff);
                                }
                                //week date
                                int year = time.Year;
                                int month = time.Month;
                                int day = time.Day;
                                string s_weekday=CaculateWeekDay(year, month, day);
                                XElement XmWeekDay = new XElement("WeekDay", s_weekday);
                                XmlResults.Add(XmWeekDay);
                            }
                            context.Response.Write(sXMLTag); context.Response.Write(xml); context.Response.Write(System.Environment.NewLine);
                        }
                        else
                        {
                            XElement xml = new XElement("mobileAppGetDailyCheckIn");
                            XElement XmlError = new XElement("result", "0");
                            xml.Add(XmlError);
                            context.Response.Write(sXMLTag); context.Response.Write(xml); context.Response.Write(System.Environment.NewLine);
                        }
                        //return null;

                    }
                    if (sGet.Equals("daily_check_in"))
                    {
                        //get user id
                        string sUserID = context.Request.QueryString["UserID"].ToString();
                        string sRet = SaveQianDao(sUserID);

                        XElement xml = new XElement("mobileAppCheckIn");
                        XElement XmlError = new XElement("result", sRet);
                        xml.Add(XmlError);
                        context.Response.Write(sXMLTag);context.Response.Write(xml); context.Response.Write(System.Environment.NewLine);
                    }
                    if (sGet.Equals("Event_Board"))
                    {
                        Twee.Mgr.PageContentMgr mgr = new PageContentMgr();
                        DataTable dt = mgr.getNewsReleaseForMobileApp();
                        if (dt == null)
                        {
                            XElement xml = new XElement("mobileAppNewsRelease");
                            XElement XmlError = new XElement("result", "0");
                            xml.Add(XmlError);
                            context.Response.Write(sXMLTag); context.Response.Write(xml); context.Response.Write(System.Environment.NewLine);



                        }
                        else
                        {
                            XElement xml = new XElement("mobileAppNewsRelease");
                            XElement XmlTotal = new XElement("result", dt.Rows.Count);

                            XElement XmlNews = new XElement("News");
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                XElement XmlTitle = new XElement("Title", dt.Rows[i]["PageContent_PageTitle"].ToString());

                                //
                                string sWebDomain = ConfigurationManager.AppSettings.Get("webAppDomain");
                                string sLinks = sWebDomain + "NewsRelease/" + dt.Rows[i]["PageContent_SeoTitle"].ToString();
                                XElement XmlLink = new XElement("Link", sLinks);
                                XmlNews.Add(XmlTitle);
                                XmlNews.Add(XmlLink);

                            }
                            xml.Add(XmlTotal);
                            xml.Add(XmlNews);
                            context.Response.Write(sXMLTag); context.Response.Write(xml); context.Response.Write(System.Environment.NewLine);

                        }
                    }
                    if (sGet.Equals("Save_Spin_Request"))
                    {

                        string sRandom=Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 10);
                        

                        //存数据到数据库
                        string sTemp ="29"+sRandom.Substring(2,6)+"34";

                        string sMd5 = PasswordHelper.ToUpMd5(sTemp);
                        string sTime = System.DateTime.Now.ToString();
                        string sSql = "insert into wn_MobileAppSpinLucky(Md5_CheckSum,Is_Lock,SpinDate) values('" + sMd5 + "',0,'"+sTime+"')";
                        DbHelperSQL.Query(sSql);
                        context.Response.Write(sRandom);
                        if (IsSlave == 1)
                        {
                            
                            TweebaaWebService.MobileAppDBWebService ws = new TweebaaWebService.MobileAppDBWebService();
                            ws.SaveSpinRequestCompleted += new TweebaaWebService.SaveSpinRequestCompletedEventHandler(ws_SaveSpinRequestCompleted);
                            ws.SaveSpinRequestAsync(sMd5, sTime);
                        }
                    }
                    if (sGet.Equals("Save_Spin"))
                    {
                        //post date
                        string sUserID=context.Request.Form["UserID"];
                        if (sUserID.Length > 10)
                        {
                            string sPrizeID = context.Request.Form["PrizeID"];
                            string sMd5 = context.Request.Form["Md5"];
                            string sSql = "update wn_MobileAppSpinLucky set Is_Lock=1,UserGuid='" + sUserID + "',Spin_PrizeID=" + sPrizeID + ",LastUpdateDate='" + System.DateTime.Now.ToString() + "' where Is_Lock=0 and Md5_CheckSum='" + sMd5 + "'";
                            DbHelperSQL.Query(sSql);
                            context.Response.Write("0");

                            //如果是Tweebuck ，在需要增加到Account 中
/*
 1	1 Powerup
2	1 Points
3	10 Points
4	50 Points
5	100 Tweebaa Points
6	5 Tweebucks
7	10 Tweebucks
8	1 Free Wonder Cup
9	1 Free Tweebot
 */
                            if (sPrizeID.ToInt() == 6 || sPrizeID.ToInt()==7)
                            {
                                string sAccount="";
                                if (sPrizeID.ToInt() == 6) sAccount = "5";
                                if (sPrizeID.ToInt() == 7) sAccount = "10";

                                //insert into 

 			                    // write commision details to save 流水 
                                sSql = "insert into wn_Profit(type,userId,[money],prdId,orderNo,state,remark,addTime,shareLevel,CommissionRate) values('App Daily Spin Reward','" + sUserID + "','" + sAccount + "',null,null,4,'App Daily Spin Reward',getdate(),0,0)";
                                DbHelperSQL.Query(sSql);
			                    /* 更新用户表 */
                                sSql = "update wn_usergrade set tweebuck=tweebuck+" + sAccount + " where userguid='" + sUserID + "'";
                                DbHelperSQL.Query(sSql);

                            }
                            if (IsSlave == 1)
                            {
                                
                                TweebaaWebService.MobileAppDBWebService ws = new TweebaaWebService.MobileAppDBWebService();
                                ws.SaveSpinCompleted += new TweebaaWebService.SaveSpinCompletedEventHandler(ws_SaveSpinCompleted);
                                ws.SaveSpinAsync(sUserID, sMd5, sPrizeID);
                            }

                        }
                        else
                        {
                            context.Response.Write("-1");
                        }

                    }
                    if (sGet.Equals("Load_Spin_Lucky"))
                    {

                        string sCacheFile = sGet + "_" + xmlCache.GetHourString();
                        //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                        //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                        if (xmlCache.IsXmlFileExists(sCacheFile))
                        {
                            // Twee.Comm.CommHelper.WrtLog("111111111");
                            xmlCache.ReadCacheXML(context, sCacheFile);
                        }
                        else
                        {
                            string sSql = "SELECT   top 10     a.username, b.SpinDate, c.AppPrize_Text";
                            sSql = sSql + " FROM            wn_user AS a INNER JOIN ";
                            sSql = sSql + " wn_MobileAppSpinLucky AS b ON a.guid = b.UserGuid LEFT OUTER JOIN ";
                            sSql = sSql + "  wn_mobileAppPrize AS c ON b.Spin_PrizeID = c.AppPrize_ID ";
                            sSql = sSql + " ORDER BY b.SpinDate DESC";

                            DataSet ds = DbHelperSQL.Query(sSql.ToString());
                            DataTable dt = ds.Tables[0];
                            if (dt == null)
                            {
                                /*
                                XElement xml = new XElement("mobileAppSpinLucky");
                                XElement XmlError = new XElement("result", "0");
                                xml.Add(XmlError);
                                context.Response.Write(sXMLTag); context.Response.Write(xml); context.Response.Write(System.Environment.NewLine);
                                */
                                XElement xml = new XElement("mobileAppSpinLucky");
                                // XElement XmlTotal = new XElement("result", dt.Rows.Count);
                                // xml.Add(XmlTotal);
                                // XElement Xmlresults = new XElement("results");

                                for (int i = 0; i < 10; i++)
                                {
                                    XElement XmlSpinLucky = new XElement("SpinLucky");
                                    XElement XmlUsername = new XElement("username", " ");
                                    XElement XmlPrize = new XElement("Prize", " ");
                                    XElement XmlDate = new XElement("SpinDate", " ");
                                    XmlSpinLucky.Add(XmlUsername);
                                    XmlSpinLucky.Add(XmlPrize);
                                    XmlSpinLucky.Add(XmlDate);
                                    xml.Add(XmlSpinLucky);
                                }
                                // xml.Add(Xmlresults);

                                //context.Response.Write(sXMLTag); context.Response.Write(xml); context.Response.Write(System.Environment.NewLine);
                                xmlCache.WriteCacheXML(context, xml, sCacheFile);


                            }
                            else
                            {
                                XElement xml = new XElement("mobileAppSpinLucky");
                               // XElement XmlTotal = new XElement("result", dt.Rows.Count);
                               // xml.Add(XmlTotal);
                               // XElement Xmlresults = new XElement("results");
                                
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    XElement XmlSpinLucky = new XElement("SpinLucky");
                                    XElement XmlUsername = new XElement("username", dt.Rows[i]["username"].ToString());
                                    XElement XmlPrize = new XElement("Prize", dt.Rows[i]["AppPrize_Text"].ToString());
                                    XElement XmlDate = new XElement("SpinDate", dt.Rows[i]["SpinDate"].ToString());
                                    XmlSpinLucky.Add(XmlUsername);
                                    XmlSpinLucky.Add(XmlPrize);
                                    XmlSpinLucky.Add(XmlDate);
                                    xml.Add(XmlSpinLucky);
                                }
                                if (dt.Rows.Count < 10)
                                {
                                    for (int i = dt.Rows.Count; i <= 10; i++)
                                    {
                                        XElement XmlSpinLucky = new XElement("SpinLucky");
                                        XElement XmlUsername = new XElement("username", " ");
                                        XElement XmlPrize = new XElement("Prize", " ");
                                        XElement XmlDate = new XElement("SpinDate", " ");
                                        XmlSpinLucky.Add(XmlUsername);
                                        XmlSpinLucky.Add(XmlPrize);
                                        XmlSpinLucky.Add(XmlDate);
                                        xml.Add(XmlSpinLucky);
                                    }
                                }
                               // xml.Add(Xmlresults);
                                
                                //context.Response.Write(sXMLTag); context.Response.Write(xml); context.Response.Write(System.Environment.NewLine);
                                xmlCache.WriteCacheXML(context, xml, sCacheFile);
                            }
                        }
                    }
                    if(sGet.Equals("hot_sale")){
                        //select top 1 * from mytable order by newid()

                        string sCacheFile = sGet + "_" + xmlCache.GetDateString() ;
                        //string sWebCache=Server.MapPath("~" + "/cache/"+sCacheFile+".xml");
                        //Twee.Comm.CommHelper.WrtLog("cache=" + sCacheFile);
                        if (xmlCache.IsXmlFileExists(sCacheFile))
                        {
                            // Twee.Comm.CommHelper.WrtLog("111111111");
                            xmlCache.ReadCacheXML(context, sCacheFile);
                        }
                        else
                        {
                            string sSql = "select top 4 * from wn_MobileAppPromotions order by newid()";
                            DataSet ds = DbHelperSQL.Query(sSql.ToString());
                            DataTable dt = ds.Tables[0];
                            if (dt == null)
                            {
                                XElement xml = new XElement("mobileAppHotSale");
                                XElement XmlError = new XElement("result", "0");
                                xml.Add(XmlError);
                                /* context.Response.Write(sXMLTag); context.Response.Write(xml); context.Response.Write(System.Environment.NewLine);*/

                                xmlCache.WriteCacheXML(context, xml, sCacheFile);

                            }
                            else
                            {
                                XElement xml = new XElement("mobileAppHotSale");
                                XElement XmlTotal = new XElement("result", dt.Rows.Count);

                                XElement XmlHotsale = new XElement("HotSales");
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    XElement XmlImage = new XElement("Image", dt.Rows[i]["promote_image"].ToString());

                                    //
                                    string sWebDomain = ConfigurationManager.AppSettings.Get("webAppDomain");
                                    string sLinks = sWebDomain + "Product/saleBuy.aspx?id=" + dt.Rows[i]["promote_product_guid"].ToString();
                                    XElement XmlLink = new XElement("Link", sLinks);
                                    XmlHotsale.Add(XmlImage);
                                    XmlHotsale.Add(XmlLink);

                                }
                                xml.Add(XmlTotal);
                                xml.Add(XmlHotsale);
                                // context.Response.Write(sXMLTag); context.Response.Write(xml); context.Response.Write(System.Environment.NewLine);
                                xmlCache.WriteCacheXML(context, xml, sCacheFile);

                            }
                        }

                    }
                   
                }
                catch (Exception ee)
                {
                    context.Response.Write("-1");
                    Twee.Comm.CommUtil.GenernalErrorHandler(ee);
                }
        }

        void ws_SaveSpinCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void ws_SaveSpinRequestCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }


        public string SaveQianDao(string userid)
        {
            try
            {
                userQianDaoMgr mgr = new userQianDaoMgr();
                bool isContinuous7 = false;
                int? datdiff = mgr.GetRecentlySingDay(userid, out isContinuous7);

                if (datdiff == null || datdiff > 0)
                {
                    Twee.Model.userQianDao model = new Twee.Model.userQianDao();
                    model.userid = userid.Trim();
                    model.createtime = System.DateTime.Now;
                    int resu = mgr.Add(model);

                    if (resu > 0)
                    {
                        string strMes = "";
                        //修改积分 奖励10分
                        UserGradeCalMgr userMgr = new UserGradeCalMgr();
                        int point = 1;
                        // Usergrade modelGrade = userMgr.GetModel(userid.ToGuid().Value);
                        DateTime dtNow = DateTime.Now;
                        bool isSau = IsSatuDay(dtNow.Year, dtNow.Month, dtNow.Day);
                        if (isContinuous7 == true && isSau == true)
                        {
                            //modelGrade.publishintegral += 10;
                            //modelGrade.shareintegral += 10;
                            //modelGrade.reviewintegral += 10;
                            point = 10;
                            strMes = "1"; //strMes = "Congratulations, you have continuous attendance for a week, get 10 bonus points";
                        }

                        else
                        {
                            //modelGrade.publishintegral += 1;
                            //modelGrade.shareintegral += 1;
                            //modelGrade.reviewintegral += 1;     
                            point = 1;
                            strMes = "2"; //strMes = "Congratulations, You have signed in successfully, get 1 bonus points";

                        }
                        //userMgr.Update(modelGrade);
                        userMgr.UserQianDaoIntegralCal(userid.ToGuid().Value, point);
                        //BindDayImg(userid.ToGuid().Value.ToString());
                        return strMes;
                    }
                }
                else if (datdiff.Value == 0)
                {
                    return "0";
                }
                return "-1";
            }
            catch (Exception ex)
            {
                return "-1";
            }
        }
        private bool IsInSameWeek(DateTime dtS, DateTime dtE)
        {
            //return ((dtE - new DateTime(1752, 12, 31)).Ticks / (7 * 24 * 60 * 60 * 10000000L) == (dtS - new DateTime(1752, 12, 31)).Ticks / (7 * 24 * 60 * 60 * 10000000L));

            return ((dtE - new TimeSpan(Convert.ToInt32(dtE.DayOfWeek), 0, 0, 0) - dtE.TimeOfDay) == (dtS - new TimeSpan(Convert.ToInt32(dtS.DayOfWeek), 0, 0, 0) - dtS.TimeOfDay));
        }
        protected bool IsSatuDay(int y, int m, int d)
        {
            if (m == 1 || m == 2)
            {
                m += 12;
                y--;         //把一月和二月看成是上一年的十三月和十四月，例：如果是2004-1-10则换算成：2003-13-10来代入公式计算。
            }
            int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400) % 7;
            if (week == 5)
            {
                return true;
            }
            return false;
        }
        protected string CaculateWeekDay(int y, int m, int d)
        {
            if (m == 1 || m == 2)
            {
                m += 12;
                y--;         //把一月和二月看成是上一年的十三月和十四月，例：如果是2004-1-10则换算成：2003-13-10来代入公式计算。
            }
            int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400) % 7;
            
            string weekstr = "";
            switch (week)
            {
                case 6: weekstr = "sun";  break;//星期日
                case 0: weekstr = "mon";  break;//星期一
                case 1: weekstr = "tue";  break;//星期二
                case 2: weekstr = "wed";  break;//星期三
                case 3: weekstr = "thu";  break;//星期四
                case 4: weekstr = "fri";  break;//星期五
                case 5: weekstr = "sat";  break;//星期六

            }
            return weekstr;
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