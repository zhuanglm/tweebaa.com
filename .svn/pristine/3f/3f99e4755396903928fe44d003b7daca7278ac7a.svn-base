using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Twee.Mgr;

namespace TweebaaWebApp
{
    /// <summary>
    /// Summary description for sitemap1
    /// </summary>
    public class sitemap1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string[] str_static_page=new string[17]{"http://tweebaa.com/College/WhyTweebaa.aspx?page=Why-tweebaa",
"http://tweebaa.com/College/TweebaaMember.aspx?page=Tweebaa-member",
"http://tweebaa.com/College/EarnWithTweebaa.aspx?page=earn-with-tweebaa",
"http://tweebaa.com/College/CashRewards.aspx?page=commission-rewards",
"http://tweebaa.com/College/ZoneRewardPoints.aspx?page=Zone-reward-points",
"http://tweebaa.com/College/ShoppingRewardPoints.aspx",
"http://tweebaa.com/College/ReferralRewards.aspx",
"http://tweebaa.com/College/SubmitZone.aspx?page=submit-zone",
"http://tweebaa.com/College/EvaluateZone.aspx?page=evaluate-zone",
"http://tweebaa.com/College/CollegeDetail.aspx?page=",
"http://tweebaa.com/College/TweeBuck.aspx",
"http://tweebaa.com/Product/prdSaleAll.aspx",
"http://tweebaa.com/Product/prdPreSale.aspx?step=2",
"http://tweebaa.com/Product/prdSale.aspx?step=3",
"http://tweebaa.com/Product/prdReviewAll.aspx",
"http://tweebaa.com/Product/prdSingleShare.aspx",
"http://tweebaa.com/Product/CollageShare.aspx"};
               context.Response.Clear();
 
        context.Response.ContentType = "text/xml";
        string tempPath = AppDomain.CurrentDomain.BaseDirectory;// System.Configuration.ConfigurationManager.AppSettings["FolderPath"];
        using (XmlTextWriter writer = new XmlTextWriter(tempPath+@"\sitemap.xml", Encoding.UTF8))
 
        {
 
            writer.WriteStartDocument();
 
            writer.WriteStartElement("urlset");
 
            writer.WriteAttributeString("xmlns", "http://www.google.com/schemas/sitemap/0.84");
 
            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
 
            writer.WriteAttributeString("xsi:schemaLocation", "http://www.google.com/schemas/sitemap/0.84 http://www.google.com/schemas/sitemap/0.84/sitemap.xsd");
 
            /*
            string dbstring = System.Configuration.ConfigurationManager.ConnectionStrings["database_con"].ConnectionString;
 
            SqlConnection connection = new SqlConnection(dbstring);
 
            connection.Open();
 
            SqlDataAdapter adp1 = new SqlDataAdapter("Select title,id from articles", connection);
            */
            
            //write static page
            for (int i = 0; i < str_static_page.Length; i++)
            {
                writer.WriteStartElement("url");

                writer.WriteElementString("loc", "" + str_static_page[i] + "");

                writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));

                writer.WriteElementString("changefreq", "daily");

                writer.WriteElementString("priority", "1.00");

                writer.WriteEndElement();

            }

            Twee.Mgr.PrdMgr mgr=new PrdMgr();

            DataSet ds = mgr.GetList("wnStat=2");
 
            //adp1.Fill(ds);
 
            if (ds.Tables[0].Rows.Count > 0)
 
            {
 
                for (int LIntCtr = 0; LIntCtr <= ds.Tables[0].Rows.Count - 1; LIntCtr++)
 
                {
 
                    writer.WriteStartElement("url");

                    writer.WriteElementString("loc", "http://tweebaa.com/Product/presaleBuy.aspx?id=" + ds.Tables[0].Rows[LIntCtr]["prdGuid"].ToString() + "");
 
                    writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));
 
                    writer.WriteElementString("changefreq", "daily");
 
                    writer.WriteElementString("priority", "1.00");
 
                    writer.WriteEndElement();
 
                }
 
            }
            DataSet ds1 = mgr.GetList("wnStat=3");

            //adp1.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int LIntCtr = 0; LIntCtr <= ds.Tables[0].Rows.Count - 1; LIntCtr++)
                {

                    writer.WriteStartElement("url");

                    writer.WriteElementString("loc", "http://tweebaa.com/Product/saleBuy.aspx?id=" + ds.Tables[0].Rows[LIntCtr]["prdGuid"].ToString() + "");

                    writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));

                    writer.WriteElementString("changefreq", "daily");

                    writer.WriteElementString("priority", "1.00");

                    writer.WriteEndElement();

                }

            }
            writer.WriteEndElement();
 
            writer.Flush();
 
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