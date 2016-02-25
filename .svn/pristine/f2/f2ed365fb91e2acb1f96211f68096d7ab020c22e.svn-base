using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MobileApp
{
    /// <summary>
    /// Summary description for GameAPI
    /// </summary>
    public class GameAPI : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
                StringBuilder strSql = new StringBuilder();
               


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

                        context.Response.Write(xml);
                    }
                    else
                    {
                        XElement xml = new XElement("mobileAppTheme");
                        XElement XmlError = new XElement("error", "1");
                        xml.Add(XmlError);
                        context.Response.Write(xml);
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
                        context.Response.Write(xml);
                    }
                    else
                    {
                        XElement xml = new XElement("mobileAppRound");
                        XElement XmlError = new XElement("error", "1");
                        xml.Add(XmlError);
                        context.Response.Write(xml);
                    }

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