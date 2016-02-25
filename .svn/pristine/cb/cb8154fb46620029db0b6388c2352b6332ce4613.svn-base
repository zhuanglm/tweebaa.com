using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;

namespace TweebaaWebApp2.Mgr.mgrcomm
{
    public class MgrConfigHelper
    {
        public static XmlDocument GetMgrConfigDoc()
        {
            XmlDocument doc = new XmlDocument();
            string path = AppDomain.CurrentDomain.BaseDirectory + "App_Data/MgrConfig.xml";
            doc.Load(path);
            return doc;
        }

        public static XmlNode GetXmlNodeById(string id)
        {
            XmlDocument doc = GetMgrConfigDoc();
            if (null == doc)
                return null;
            XmlNode node = doc.SelectSingleNode("/mgr/config[@id='"+id+"']");
            return node;
        }


    }
}