﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using AjaxPro;
using System.Configuration;
using Twee.Comm;
using System.Xml;
using Newtonsoft.Json;

namespace TweebaaWebApp.Mgr.ByFocusMgr
{
    public partial class SetupProductByFocus : System.Web.UI.Page
    {
        public string webAppDomain = string.Empty;
        Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(SetupProductByFocus));
            if (!IsPostBack)
            {
                webAppDomain = ConfigurationManager.AppSettings["webAppDomain"].Trim();
                XmlNode configNode = mgrcomm.MgrConfigHelper.GetXmlNodeById("40");
                if (null != configNode)
                {
                    //// hidMgrConfig1.Value = configNode.Attributes["text"].Value.ToString();
                    //// hidMgrConfigCount.Value = configNode.Attributes["count"].Value.ToString();
                }

                Twee.Model.MgrUser adm = Session["CURRENT_USER"] as Twee.Model.MgrUser;
            }
        }

        [AjaxPro.AjaxMethod]
        public string GetFocusCateColumnNameList()
        {
            DataTable dt = mgr.MgeGetFocusCateColumnNameList();
            string sInfo = JsonConvert.SerializeObject(dt);
            return sInfo;
        }

        [AjaxPro.AjaxMethod]
        public string GetFocusCateList()
        {
            DataTable dt = mgr.MgeGetFocusCateList();
            string sInfo = JsonConvert.SerializeObject(dt);
            return sInfo;
        }

        [AjaxPro.AjaxMethod]
        public bool SaveProductFocusCate(string sProductIDs,  string sFocusCateIDs)
        {
            bool bRet = mgr.MgeSaveProducFocusCate(sProductIDs,  sFocusCateIDs);
            return bRet;
        }

    
    }
}