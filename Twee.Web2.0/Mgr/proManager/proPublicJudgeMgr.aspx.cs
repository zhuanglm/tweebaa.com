﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;
using System.Configuration;
using Twee.Comm;
using System.Xml;

namespace TweebaaWebApp2.Mgr.proManager
{
    public partial class proPublicJudgeMgr : System.Web.UI.Page
    {
        public ListItem firstItem = new ListItem() { Value = "-1", Text = "--ALL--" };
        public string webAppDomain = string.Empty;

        Twee.Mgr.PrdCateMgr cateMgr = new Twee.Mgr.PrdCateMgr();

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(proPublicJudgeMgr));
            if (!IsPostBack)
            {
                webAppDomain = ConfigurationManager.AppSettings["webAppDomain"].Trim();
                XmlNode configNode = mgrcomm.MgrConfigHelper.GetXmlNodeById("1");
                if (null != configNode)
                {
                    hidMgrConfig1.Value = configNode.Attributes["text"].Value.ToString();
                    hidMgrConfigCount.Value = configNode.Attributes["count"].Value.ToString();
                }

                Twee.Model.MgrUser adm = Session["CURRENT_USER"] as Twee.Model.MgrUser;
                hidMgrAdminid.Value = adm.iID.ToString();

                var ddlBind = new Twee.Mgr.mgrProStatusReasonMgr().GetModelList(" proStatusArea='"+(int)Twee.Comm.ConfigParamter.PrdSate.review+"'");
                passReason.DataSource = ddlBind;
                passReason.DataValueField = "id";
                passReason.DataTextField = "commreason";
                passReason.DataBind();
            }
            
        }

        [AjaxPro.AjaxMethod]
        public string GetFirstCate()
        {
            var cateModelList = cateMgr.GetModelList(" layer=0");
            if (cateModelList == null || cateModelList.Count == 0)
                return "fail";
            StringBuilder json = new StringBuilder();
            foreach (var item in cateModelList)
            {
                json.AppendFormat(",{2}\"value\":\"{0}\",\"text\":\"{1}\"{3}", item.guid, item.name, "{", "}");
            }
            if (!string.IsNullOrEmpty(json.ToString()))
                return "[{\"value\":\"-1\",\"text\":\"--ALL--\"}" + json.ToString()+ "]";
            else
                return "fail";
        }

        [AjaxPro.AjaxMethod]
        public string GetNextCate(string parentId)
        {
            if (string.IsNullOrEmpty(parentId))
                return "fail";
            var sonModelList = cateMgr.GetModelList(" prtGuid='"+parentId+"'");
            if (sonModelList == null || sonModelList.Count == 0)
                return "fail";
            StringBuilder json = new StringBuilder();
            foreach (var item in sonModelList)
            {
                json.AppendFormat(",{2}\"value\":\"{0}\",\"text\":\"{1}\"{3}",item.guid,item.name,"{","}");
            }
            if (!string.IsNullOrEmpty(json.ToString()))
                return "[{\"value\":\"-1\",\"text\":\"--ALL--\"}" + json.ToString() + "]";
            else
                return "fail";
        }

        [AjaxPro.AjaxMethod]
        public string PassAll(string ids)
        {
            try
            {
                var res = new Twee.Mgr.PrdMgr().PassAll(ids);
                if (res > 0)
                    return "success";
                else
                    return "fail";
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        [AjaxPro.AjaxMethod]
        public string PassSingle(string id,string reasonid,string exreason,string adminid)
        {
            try
            {
                var res = new Twee.Mgr.PrdMgr().PassSingle(id,reasonid,exreason,adminid);
                if (res > 0)
                    return "success";
                else
                    return "fail";
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        [AjaxPro.AjaxMethod]
        public string DeletePrd(string id)
        {
            try
            {
                var res = new Twee.Mgr.PrdMgr().MgeDelete(id.ToGuid().Value);
                if (res ==true)
                    return "success";
                else
                    return "fail";
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
    }
}