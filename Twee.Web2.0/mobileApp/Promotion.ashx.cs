using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;


namespace TweebaaWebApp2.mobileApp
{
    /// <summary>
    /// Summary description for Promotion
    /// </summary>
    public class Promotion : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  top 1 promote_id,promote_product_guid,promote_text,promote_image from wn_MobileAppPromotions ORDER BY NEWID()");
                /*
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
                        new SqlParameter("@id", SqlDbType.Int,4)
                };
                parameters[0].Value = id;

                Twee.Model.Country model=new Twee.Model.Country();
                 * */
                DataSet ds = DbHelperSQL.Query(strSql.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    XElement xml = new XElement("mobileAppPromotion");
                    XElement XmlError = new XElement("error", "0");
                    xml.Add(XmlError);
                    XElement XmlProID = new XElement("Product_Guid", ds.Tables[0].Rows[0]["promote_product_guid"]);
                    xml.Add(XmlProID);
                    XElement XmlProText = new XElement("Promote_Text", ds.Tables[0].Rows[0]["promote_text"]);
                    xml.Add(XmlProText);
                    XElement XmlProImage = new XElement("Promote_Image", ds.Tables[0].Rows[0]["promote_image"]);
                    xml.Add(XmlProImage);
                    context.Response.Write(xml);
                }
                else
                {
                    XElement xml = new XElement("mobileAppPromotion");
                    XElement XmlError = new XElement("error", "1");
                    xml.Add(XmlError);
                    context.Response.Write(xml);
                }
            }
            catch (Exception e1)
            {
                XElement xml = new XElement("mobileAppPromotion");
                XElement XmlError = new XElement("error", "1");
                xml.Add(XmlError);
                context.Response.Write(xml);
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