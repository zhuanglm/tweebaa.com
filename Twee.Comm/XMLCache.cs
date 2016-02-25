using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Twee.Comm;
using System.IO;

namespace Twee.Comm
{
    public class XMLCache
    {
         String sXMLTag="<?xml version=\"1.0\" encoding=\"UTF-8\"?>"+ System.Environment.NewLine;
          public XMLCache()
        {

        }
        public bool IsXmlFileExists(string sActionString){

            String strCacheFile = HttpContext.Current.Server.MapPath("~" + "/cache/"+sActionString+".xml");
            return System.IO.File.Exists(strCacheFile);
        }
        public bool IsJsonFileExists(string sActionString)
        {

            String strCacheFile = HttpContext.Current.Server.MapPath("~" + "/cache/" + sActionString + ".json");
            return System.IO.File.Exists(strCacheFile);
        }
        public void ReadCacheXML(HttpContext context, string sActionString)
        {
            String strCacheFile = HttpContext.Current.Server.MapPath("~" + "/cache/" + sActionString + ".xml"); 
            string contents = System.IO.File.ReadAllText(strCacheFile);
            context.Response.Write(contents);
            context.Response.Write(System.Environment.NewLine); 
        }
        public void ReadCacheJson(HttpContext context, string sActionString)
        {
            String strCacheFile = HttpContext.Current.Server.MapPath("~" + "/cache/" + sActionString + ".json");
            string contents = System.IO.File.ReadAllText(strCacheFile);
            context.Response.Write(contents);
            context.Response.Write(System.Environment.NewLine);
        }
        public void WriteJsonFile(HttpContext context, string sJson, string sActionString)
        {
            String strCacheFile = HttpContext.Current.Server.MapPath("~" + "/cache/" + sActionString + ".json");
            /*
            BinaryWriter bw;
            try
            {
                bw = new BinaryWriter(new FileStream(strCacheFile, FileMode.Create));
            }
            catch (IOException e)
            {
                //Console.WriteLine(e.Message + "\n Cannot create file.");
                Twee.Comm.CommUtil.GenernalErrorHandler(e);
                return;
            }
            try
            {
                bw.Write(sJson);
            }

            catch (IOException e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(e);
                return;
            }
            bw.Close();*/
            try
            {
                System.IO.File.WriteAllText(strCacheFile, sJson);
            }
            catch (Exception ee)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(ee);
            }

        }
        public bool IsHTMLFileExists(string sActionString)
        {

            String strCacheFile = HttpContext.Current.Server.MapPath("~" + "/cache/" + sActionString + ".html");
            return System.IO.File.Exists(strCacheFile);
        }
        public string ReadCacheHTML(string sActionString)
        {
            String strCacheFile = HttpContext.Current.Server.MapPath("~" + "/cache/" + sActionString + ".html");
            string contents = System.IO.File.ReadAllText(strCacheFile);
            return contents;
        }
        public void WriteCahceHTML(string strHTML, string sActionString)
        {
            try
            {
                String strCacheFile = HttpContext.Current.Server.MapPath("~" + "/cache/" + sActionString + ".html");
                System.IO.File.WriteAllText(strCacheFile, strHTML);
            }
            catch (Exception ee)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(ee);
            }
        }
        public void WriteCacheXML(HttpContext context,XElement xml,string sActionString)
        {
            String strCacheFile = HttpContext.Current.Server.MapPath("~" + "/cache/"+sActionString+".xml");
            //check file existings

            context.Response.Clear(); context.Response.Write(sXMLTag);
            context.Response.Write(xml);
            context.Response.Write(System.Environment.NewLine); 
            //save it to file
            xml.Save(strCacheFile);
            
        }
        public string GetYearString()
        {
            DateTime dateOnly = System.DateTime.Now;// .Date;
            return dateOnly.ToString("yyyy");
        }
        public string GetMonthString()
        {
            DateTime dateOnly = System.DateTime.Now;// .Date;
            return dateOnly.ToString("MM_yyyy");
        }
        public string GetDateString()
        {
            DateTime dateOnly = System.DateTime.Now;// .Date;
            return dateOnly.ToString("MM_dd_yyyy");
        }
        public string GetHourString()
        {
            DateTime dateOnly = System.DateTime.Now;// .Date;
            return dateOnly.ToString("MM_dd_yyyy_HH");
        }
        public string GetMinuteString()
        {
            DateTime dateOnly = System.DateTime.Now;// .Date;
            return dateOnly.ToString("MM_dd_yyyy_HH_mm");
        }
    }
}