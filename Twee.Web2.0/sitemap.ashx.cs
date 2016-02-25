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
using System.Text.RegularExpressions;

namespace TweebaaWebApp2
{
    /// <summary>
    /// Summary description for sitemap
    /// </summary>
    public class sitemap : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string[] str_static_page = new string[28]{
                "https://tweebaa.com/College/Suggest-zone.aspx",
                "https://tweebaa.com/College/evaluate-zone.aspx",
                "https://tweebaa.com/College/shopping_reward.aspx",
                "https://tweebaa.com/College/shop-zone.aspx",
                "https://tweebaa.com/College/share-zone.aspx",
                "https://tweebaa.com/College/ShoppingRewardPoints.aspx",
                "https://tweebaa.com/College/College.aspx",
                "https://tweebaa.com/College/AboutUs.aspx",
                "https://tweebaa.com/College/ContactUs.aspx",
                "https://tweebaa.com/College/Privacy_Policy.aspx",
                "https://www.tweebaa.com/College/General_Terms_ofUse.aspx",
                "https://www.tweebaa.com/College/evaluate_comission.aspx",
                "https://www.tweebaa.com/College/submitter_comission.aspx",
                "https://www.tweebaa.com/College/sharer_commission.aspx",
                "https://www.tweebaa.com/College/comission_chart.aspx",
                "https://tweebaa.com/College/TweeBuck.aspx",
                "https://tweebaa.com/Product/prdSaleAll.aspx",
                "https://tweebaa.com/Product/prdPreSale.aspx?step=2",
                "https://tweebaa.com/Product/prdSale.aspx?step=3",
                "https://tweebaa.com/Product/prdReviewAll.aspx",
                "https://www.tweebaa.com/Games/SlotMachine/rules.aspx",
                "https://www.tweebaa.com/Games/SlotMachine/index.aspx",
                "https://tweebaa.com/Product/prdSingleShare.aspx",
                "https://tweebaa.com/Product/CollageShare.aspx",
                "https://www.tweebaa.com/Events/Tweebot/Vote.aspx",
                "https://www.tweebaa.com/Events/Tweebot/Improvement.aspx",
                "https://www.tweebaa.com/Events/Tweebot/rules.aspx",
                "https://www.tweebaa.com/Events/Tweebot/"
           };
            context.Response.Clear();

            context.Response.ContentType = "text/xml";
            string tempPath = AppDomain.CurrentDomain.BaseDirectory;// System.Configuration.ConfigurationManager.AppSettings["FolderPath"];
            using (XmlTextWriter writer = new XmlTextWriter(tempPath + @"\sitemap.xml", Encoding.UTF8))
            {

                writer.WriteStartDocument();

                writer.WriteStartElement("urlset");

                writer.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");

                /*writer.WriteAttributeString("xmlns:xsi", "https://www.w3.org/2001/XMLSchema-instance");

                writer.WriteAttributeString("xsi:schemaLocation", "https://www.google.com/schemas/sitemap/0.84 https://www.google.com/schemas/sitemap/0.84/sitemap.xsd");
                */
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

                    writer.WriteElementString("changefreq", "weekly");

                    writer.WriteElementString("priority", "0.4096");

                    writer.WriteEndElement();

                }

                Twee.Mgr.PrdMgr mgr = new PrdMgr();

                DataSet ds = mgr.GetList("wnStat=2");

                //adp1.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int LIntCtr = 0; LIntCtr <= ds.Tables[0].Rows.Count - 1; LIntCtr++)
                    {

                        writer.WriteStartElement("url");

                        string sName = ds.Tables[0].Rows[LIntCtr]["name"].ToString();
                        string sCleanName = AppndHyphen2Name(sName);
                        string sId = ds.Tables[0].Rows[LIntCtr]["prdGuid"].ToString();
                        string sURL = sCleanName + @"-prdguid-" + sId;
                        writer.WriteElementString("loc", "https://tweebaa.com/Product/presaleBuy/" + HttpUtility.UrlPathEncode(sURL) + "");

                        //writer.WriteElementString("loc", "https://tweebaa.com/Product/presaleBuy/" + HttpUtility.UrlPathEncode(ds.Tables[0].Rows[LIntCtr]["name"].ToString()));

                        writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));

                        writer.WriteElementString("changefreq", "weekly");

                        writer.WriteElementString("priority", "1.00");

                        writer.WriteEndElement();

                    }

                }
                ds = mgr.GetList("wnStat=3");

                //adp1.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int LIntCtr = 0; LIntCtr <= ds.Tables[0].Rows.Count - 1; LIntCtr++)
                    {

                        writer.WriteStartElement("url");

                        string sName = ds.Tables[0].Rows[LIntCtr]["name"].ToString();
                        string sCleanName = AppndHyphen2Name(sName);
                        string sId = ds.Tables[0].Rows[LIntCtr]["prdGuid"].ToString();
                        string sURL = sCleanName + @"-prdguid-" + sId;
                        writer.WriteElementString("loc", "https://tweebaa.com/Product/saleBuy/" + HttpUtility.UrlPathEncode(sURL) + "");
                        //writer.WriteElementString("loc", "https://tweebaa.com/Product/saleBuy/" + HttpUtility.UrlPathEncode(ds.Tables[0].Rows[LIntCtr]["name"].ToString()) + "");

                        writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));

                        writer.WriteElementString("changefreq", "weekly");

                        writer.WriteElementString("priority", "1.00");

                        writer.WriteEndElement();

                    }

                }

                //Add Category list 3 levels
                string sCategory1 = string.Empty;
                string sCategory2 = string.Empty;
                string sCategory3 = string.Empty;

                ds = mgr.GetCategorybyLevel(0);
                //adp1.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Add level-1 category
                    for (int LIntCtr = 0; LIntCtr <= ds.Tables[0].Rows.Count - 1; LIntCtr++)
                    {
                        writer.WriteStartElement("url");

                        string sName = ds.Tables[0].Rows[LIntCtr]["name"].ToString();
                        sCategory1 = CategoryName2URL(sName);
                        //sCategory0 = sName;
                        string sCatID1 = ds.Tables[0].Rows[LIntCtr]["guid"].ToString();
                        string sURL = sCategory1 + @"/" + sCatID1;
                        writer.WriteElementString("loc", "https://tweebaa.com/Product/category.aspx/" + HttpUtility.UrlPathEncode(sURL) + "");
                        writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));
                        writer.WriteElementString("changefreq", "weekly");
                        writer.WriteElementString("priority", "1.00");
                        writer.WriteEndElement();

                        //Add level-2 category
                        DataSet ds1 = mgr.GetSubCtgryList(sCatID1);
                        for (int LIntCtr1 = 0; LIntCtr1 <= ds1.Tables[0].Rows.Count - 1; LIntCtr1++)
                        {
                            writer.WriteStartElement("url");
                            string sName1 = ds1.Tables[0].Rows[LIntCtr1]["name"].ToString();
                            sCategory2 = CategoryName2URL(sName1);
                            //sCategory1 = sName1;
                            string sCatID2 = ds1.Tables[0].Rows[LIntCtr1]["guid"].ToString();
                            string sURL1 = sCategory1 + @"/" + sCategory2 + @"/" + sCatID1 + @"/" + sCatID2;
                            writer.WriteElementString("loc", "https://tweebaa.com/Product/category.aspx/" + HttpUtility.UrlPathEncode(sURL1) + "");
                            //writer.WriteElementString("loc", "https://tweebaa.com/Product/saleBuy/" + HttpUtility.UrlPathEncode(ds.Tables[0].Rows[LIntCtr]["name"].ToString()) + "");
                            writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));
                            writer.WriteElementString("changefreq", "weekly");
                            writer.WriteElementString("priority", "1.00");
                            writer.WriteEndElement();

                            //Add level-3 cateogry
                            DataSet ds2 = mgr.GetSubCtgryList(sCatID2);
                            for (int LIntCtr2 = 0; LIntCtr2 <= ds2.Tables[0].Rows.Count - 1; LIntCtr2++)
                            {
                                writer.WriteStartElement("url");
                                string sName2 = ds2.Tables[0].Rows[LIntCtr2]["name"].ToString();
                                sCategory3 = CategoryName2URL(sName2);
                                //sCategory2 = sName2;
                                string sCatID3 = ds2.Tables[0].Rows[LIntCtr2]["guid"].ToString();
                                string sURL2 = sCategory1 + @"/" + sCategory2 + @"/" + sCategory3 + @"/" + sCatID1 + @"/" + sCatID2 + @"/" + sCatID3;
                                writer.WriteElementString("loc", "https://tweebaa.com/Product/category.aspx/" + HttpUtility.UrlPathEncode(sURL2) + "");
                                //writer.WriteElementString("loc", "https://tweebaa.com/Product/saleBuy/" + HttpUtility.UrlPathEncode(ds.Tables[0].Rows[LIntCtr]["name"].ToString()) + "");
                                writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));
                                writer.WriteElementString("changefreq", "weekly");
                                writer.WriteElementString("priority", "1.00");
                                writer.WriteEndElement();
                            }

                        }
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

        public string AppndHyphen2Name(string sProduct)
        {
            string cleanTitle = sProduct.Trim().ToLower();
            string pattern = @"[\x00-\x19\x21-\x2F\x3A-\x40\x5B-\x60\x7B-\xFF]";
            string parsedStr = string.Empty;
            parsedStr = Regex.Replace(cleanTitle, pattern, "");
            return parsedStr.Replace("%20", "-").Replace(" ", "-");
        }
        
        public string CategoryName2URL(string sCatName)
        {

           // string cleanTitle = sCatName.Trim().ToLower();
            string cleanTitle = sCatName.Trim();
            cleanTitle = cleanTitle.Replace("Children/Infant", "Children and Infant");
            cleanTitle = cleanTitle.Replace("Green / Eco Products", "Green and Eco Products");
            cleanTitle = cleanTitle.Replace("Décor", "Decor");

            //replace all special characters
            cleanTitle = cleanTitle.Replace("&", "and");
            cleanTitle = cleanTitle.Replace("/", "and");
            cleanTitle = cleanTitle.Replace("'", "");
            cleanTitle = cleanTitle.Replace(",", "");

            string pattern = @"[\x00-\x19\x21-\x2F\x3A-\x40\x5B-\x60\x7B-\xFF]";
            string parsedStr = string.Empty;
            parsedStr = Regex.Replace(cleanTitle, pattern, "");
            return parsedStr.Replace("%20", "-").Replace(" ", "-");
        }
    }
}