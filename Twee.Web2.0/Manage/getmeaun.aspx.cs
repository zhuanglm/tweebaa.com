﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Twee.Comm;

namespace TweebaaWebApp2.Manage
{
    public partial class getmeaun : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                ///*act:lst,add,get,edt,del*/
                string act = CommHelper.GetString(Request.Form["wnType"], true);              
                switch (act)
                {
                    case "2"://读取菜单
                        getMenu();
                        break;
                    default:
                        getMenu();
                        break;
                }
            }
        }

        /// <summary>
        /// 读取菜单
        /// </summary>
        private void getMenu()
        {
            string rootUrl = System.Configuration.ConfigurationManager.AppSettings["rootUrl"].ToString() + "Manage/css/";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string strPath = Server.MapPath("~") + @"\Manage\menu.xml";
            Response.Write(strPath);
            //sb.Append(strPath);
            XmlNodeList ndLst = XmlHelper.GetXmlNodeListByXpath(strPath, "/wnData/m1");
            foreach (XmlNode nd in ndLst)
            {
                sb.Append("<div title=\"" + nd.Attributes["title"].Value.ToString() + "\">");
                XmlNodeList lst = nd.ChildNodes;
                foreach (XmlNode n in lst)
                {
                    sb.Append("<a href=\"javascript:void(0);\" src=\"" + n.Attributes["src"].Value.ToString() + "\" class=\"cs-navi-tab\" title=\"" + n.Attributes["title"].Value.ToString() + "\"><img src=\"" + rootUrl + n.Attributes["img"].Value.ToString() + "\" /></a>");
                }
                sb.Append("</div>");
            }

            Response.Clear();
            Response.Write(sb.ToString());
            Response.End();
        }

    }
}