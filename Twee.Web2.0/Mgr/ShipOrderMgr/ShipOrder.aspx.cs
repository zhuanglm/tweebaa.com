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

namespace TweebaaWebApp2.Mgr.ShipOrderMgr
{
    public partial class ShipOrder : System.Web.UI.Page
    {
        public string webAppDomain = string.Empty;

        Twee.Mgr.ShipOrderMgr mgr = new Twee.Mgr.ShipOrderMgr();
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(ShipOrder));
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
                ////hidMgrAdminid.Value = adm.guid.ToString();

//                int iTotalCount = 0;
//                var ddlBind = mgr.MgeGetFocusCateList(1, 20, out iTotalCount);
            }
        }

        [AjaxPro.AjaxMethod]
        public string WarehouseShipmentDetailUpdate()
        {
            try
            {
                ShipAPI.ShipOrder so = new ShipAPI.ShipOrder();
                bool bOK = so.WarehouseShipmentDetailUpdate((int)ConfigParamter.ShipPartner.Fosdick, false);
                if (bOK) return "1";
                else return "Failed to update warehouse shipment details.";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        [AjaxPro.AjaxMethod]
        public string WarehouseReturnStatusUpdate()
        {
            try
            {
                ShipAPI.ShipOrder so = new ShipAPI.ShipOrder();
                bool bOK = so.WarehouseReturnInfoUpdate((int)ConfigParamter.ShipPartner.Fosdick, false);
                if (bOK) return "1";
                else return "Failed to update warehouse return status.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}