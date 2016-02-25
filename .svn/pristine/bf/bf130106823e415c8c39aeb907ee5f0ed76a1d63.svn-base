using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;
using System.Configuration;
using System.Text;

namespace TweebaaWebApp2.Mgr.proManager
{
    public partial class proSaleMgr : System.Web.UI.Page
    {
        public ListItem firstItem = new ListItem() { Value = "-1", Text = "--ALL--" };
        public string webAppDomain = string.Empty;

        Twee.Mgr.PrdCateMgr cateMgr = new Twee.Mgr.PrdCateMgr();

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(proSaleMgr));
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

        /// <summary>
        /// 批量下架
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod]
        public string DownAll(string ids,string reason)
        {
            try
            {
                var res = new Twee.Mgr.PrdMgr().DownAll(ids,reason);
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

        /// <summary>
        /// 单个下架
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod]
        public string DownSaleSingle(string id,string reason)
        {
            try
            {
                var res = new Twee.Mgr.PrdMgr().DownSingle(id,reason);
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

    }
}