using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Net;

namespace TweebaaWebApp.ShipAPI
{
    public static class ShipAPIComm
    {

        public static void AddAttr(XmlDocument doc, XmlElement elem, string sName, string sValue)
        {
            XmlAttribute attr = doc.CreateAttribute(sName);
            attr.Value = sValue;
            elem.Attributes.Append(attr);
        }

        public static string XmlToString(XmlDocument xmlDoc)
        {

            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                xmlDoc.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                return stringWriter.GetStringBuilder().ToString();
            }
        }


        public static string PostXml(string xml, string sUrl , string sContentType)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sUrl);


                //string s = "id="+Server.UrlEncode(xml);
                byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(xml);
                req.Method = "POST";

                //“application/x-www-form-urlencoded

                //req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                req.ContentType = sContentType + ";charset=utf-8";
                req.ContentLength = requestBytes.Length;
                Stream requestStream = req.GetRequestStream();
                requestStream.Write(requestBytes, 0, requestBytes.Length);
                requestStream.Close();


                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default);
                string backstr = sr.ReadToEnd();
                sr.Close();
                res.Close();
                return backstr;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static XmlElement AddElement(XmlDocument doc, XmlElement parent, string sName, string sText)
        {
            XmlElement child = doc.CreateElement(sName, doc.DocumentElement.NamespaceURI);
            if (sText == null) sText = string.Empty;
            child.InnerText = sText;
            parent.AppendChild(child);
            return child;
        }



    }
}