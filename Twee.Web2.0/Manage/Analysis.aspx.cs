using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Twee.Mgr;

namespace TweebaaWebApp2.Manage
{
    public partial class Analysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getUserReg();
            getUserLogin();
            getUserReview();
        }

        private void getUserReg()
        {
            int intsum = 0;
            System.Text.StringBuilder sbHtml = new System.Text.StringBuilder();
            AnalysisMgr u = new AnalysisMgr();
            string key = System.Configuration.ConfigurationManager.AppSettings["strKey"].ToString();
            string model = u.GetUserReg(key);
            //Response.Write("<br><br><br><br>" + model);
            JObject jo = (JObject)JsonConvert.DeserializeObject((string)JsonConvert.DeserializeObject(model));
            string it = jo["it"].ToString();
            if (it == "1")
            {
                // Response.Write(jo);
                if (jo["data"].ToString().Length > 0)
                {
                    //Response.Write(jo["data"]);
                    JArray jary = JArray.Parse(jo["data"].ToString());
                    if (jary.Count > 0)
                    {

                        sbHtml.Append("<table cellpadding='0' cellspacing='0' >");
                        sbHtml.Append("<tr>");
                        for (int i = 0; i < jary.Count; i++)
                        {
                            sbHtml.Append("<td>");
                            int h1 = int.Parse(jary[i]["collect"].ToString()) * 1;
                            intsum = intsum + h1;
                            sbHtml.Append("<div  style='height:" + h1.ToString() + "px;'>");
                            sbHtml.Append("<h1>" + h1.ToString() + "个</h1>");
                            sbHtml.Append("<h2 style='top:" + (h1 + 1).ToString() + "px'>" + DateTime.Parse(jary[i]["dt"].ToString()).ToString("yyyy-MM-dd") + "</h2>");
                            sbHtml.Append("</div>");
                            sbHtml.Append("</td>");
                        }
                        sbHtml.Append("</tr>");
                        sbHtml.Append("</table>");
                    }
                }
                dvUserReg.InnerHtml = sbHtml.ToString();
                lbUserReg.InnerText = "共" + intsum.ToString() + "人";
            }
        }
        private void getUserLogin()
        {
            int intsum = 0;
            System.Text.StringBuilder sbHtml = new System.Text.StringBuilder();
            AnalysisMgr u = new AnalysisMgr();
            string key = System.Configuration.ConfigurationManager.AppSettings["strKey"].ToString();
            string model = u.GetUserLog(key);
            //Response.Write("<br><br><br><br>" + model);
            JObject jo = (JObject)JsonConvert.DeserializeObject((string)JsonConvert.DeserializeObject(model));
            string it = jo["it"].ToString();
            if (it == "1")
            {
                // Response.Write(jo);
                if (jo["data"].ToString().Length > 0)
                {
                    //Response.Write(jo["data"]);
                    JArray jary = JArray.Parse(jo["data"].ToString());
                    if (jary.Count > 0)
                    {
                        sbHtml.Append("<table cellpadding='0' cellspacing='0' >");
                        sbHtml.Append("<tr>");
                        for (int i = 0; i < jary.Count; i++)
                        {
                            sbHtml.Append("<td>");
                            int h1 = int.Parse(jary[i]["collect"].ToString()) * 1;
                            intsum = intsum + h1;
                            sbHtml.Append("<div style='height:" + h1.ToString() + "px;'>");
                            sbHtml.Append("<h1>" + h1.ToString() + "次</h1>");
                            sbHtml.Append("<h2 style='top:" + (h1 + 1).ToString() + "px'>" + DateTime.Parse(jary[i]["dt"].ToString()).ToString("yyyy-MM-dd") + "</h2>");
                            sbHtml.Append("</div>");
                            sbHtml.Append("</td>");
                        }
                        sbHtml.Append("</tr>");
                        sbHtml.Append("</table>");
                    }
                }
                dvUserLog.InnerHtml = sbHtml.ToString();
                lbUserLog.InnerText = "共" + intsum.ToString() + "次";
            }
        }


        private void getUserReview()
        {
            int intsum = 0;
            System.Text.StringBuilder sbHtml = new System.Text.StringBuilder();
            AnalysisMgr u = new AnalysisMgr();
            string key = System.Configuration.ConfigurationManager.AppSettings["strKey"].ToString();
            
            string model = u.GetUserReview(key);
            //Response.Write("<br><br><br><br>" + model);
            JObject jo = (JObject)JsonConvert.DeserializeObject((string)JsonConvert.DeserializeObject(model));
            string it = jo["it"].ToString();
            if (it == "1")
            {
                // Response.Write(jo);
                if (jo["data"].ToString().Length > 0)
                {
                    //Response.Write(jo["data"]);
                    JArray jary = JArray.Parse(jo["data"].ToString());
                    if (jary.Count > 0)
                    {
                        sbHtml.Append("<table cellpadding='0' cellspacing='0' >");
                        sbHtml.Append("<tr>");
                        for (int i = 0; i < jary.Count; i++)
                        {
                            sbHtml.Append("<td>");
                            int h1 = int.Parse(jary[i]["collect"].ToString()) * 1;
                            intsum = intsum + h1;
                            sbHtml.Append("<div  style='height:" + h1.ToString() + "px;'>");
                            sbHtml.Append("<h1>" + h1.ToString() + "个</h1>");
                            sbHtml.Append("<h2 style='top:" + (h1 + 1).ToString() + "px'>" + DateTime.Parse(jary[i]["dt"].ToString()).ToString("yyyy-MM-dd") + "</h2>");
                            sbHtml.Append("</div>");
                            sbHtml.Append("</td>");
                        }
                        sbHtml.Append("</tr>");
                        sbHtml.Append("</table>");
                    }
                }
                dvUserReview.InnerHtml = sbHtml.ToString();
                lbUserReview.InnerText = "共" + intsum.ToString() + "次";
            }
        }
    }
}