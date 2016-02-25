using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;
using Twee.Mgr;
using Twee.Comm;

namespace TweebaaWebApp.Mgr.proManager
{
    public partial class proCheck : System.Web.UI.Page
    {
        public ListItem firstItem = new ListItem() { Value = "-1", Text = "--ALL--" };
        public string webAppDomain = string.Empty;

        Twee.Mgr.PrdCateMgr cateMgr = new Twee.Mgr.PrdCateMgr();

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(proCheck));
            if (!IsPostBack)
            {
                webAppDomain = ConfigurationManager.AppSettings["webAppDomain"].Trim();
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
                return "[{\"value\":\"-1\",\"text\":\"--ALL--\"}" + json.ToString() + "]";
            else
                return "fail";
        }

        [AjaxPro.AjaxMethod]
        public string GetNextCate(string parentId)
        {
            if (string.IsNullOrEmpty(parentId))
                return "fail";
            var sonModelList = cateMgr.GetModelList(" prtGuid='" + parentId + "'");
            if (sonModelList == null || sonModelList.Count == 0)
                return "fail";
            StringBuilder json = new StringBuilder();
            foreach (var item in sonModelList)
            {
                json.AppendFormat(",{2}\"value\":\"{0}\",\"text\":\"{1}\"{3}", item.guid, item.name, "{", "}");
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
                var res = new Twee.Mgr.PrdMgr().InitPassAll(ids);
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
        public string PassSingle(string id,string proname,string userid)
        {
            try
            {
                var res = new Twee.Mgr.PrdMgr().InitPassSingle(id,proname,userid);
                if (res > 0)
                {
                    //UserGradeCalMgr grade = new UserGradeCalMgr();
                    //grade.MgePublishIntegralCal(userid.ToGuid().Value, id.ToGuid().Value, 1);//奖励5积分
                    return "success";
                }                   
                else
                    return "fail";
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        [AjaxPro.AjaxMethod]
        public string RefusePass(string proid,string proname,string userid, string reason)
        {
            try
            {
                var res = new Twee.Mgr.PrdMgr().RefusePass(proid,proname,userid,reason);
                if (res)
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