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
    public partial class proTweeJudgeMgr : System.Web.UI.Page
    {
        public ListItem firstItem = new ListItem() { Value = "-1", Text = "--ALL--" };
        public string webAppDomain = string.Empty;

        Twee.Mgr.PrdCateMgr cateMgr = new Twee.Mgr.PrdCateMgr();

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(proTweeJudgeMgr));
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
                List<string> outList = new List<string>();
                var res = new Twee.Mgr.PrdMgr().TweePassAll(ids,out outList);
                if (res > 0 && outList == null)
                {
                    return "success";
                }
                else if (res > 0 && outList != null && outList.Count>0)
                {
                    string idsList = string.Empty;
                    outList.ForEach(s => {
                        idsList += "," + s;
                    });
                    return idsList.Substring(1);
                }
                else if (res == -200 && outList == null)
                {
                    return "noInventory";
                }
                else
                {
                    return "fail";
                }
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        [AjaxPro.AjaxMethod]
        public string PassSingle(string id)
        {
            try
            {
                var res = new Twee.Mgr.PrdMgr().TweePassSingle(id);
                if (res > 0)
                    return "success";
                else if (res == -200)
                    return "noInventory";
                else
                    return "fail";
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        [AjaxPro.AjaxMethod]
        public string NoPass(string id, string reason)
        {
            try
            {
                var res = new Twee.Mgr.PrdMgr().TweeNoPass(id,reason);
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
        public string SavePreSale(string ids,string prePrice,string order, string time)
        {
            try
            {
                string _time = DateTime.Parse(time).ToString("yyyy-MM-dd");
                var res = new Twee.Mgr.PrdMgr().TweeSavePreSaleOrderAndTime(ids, prePrice,order, _time);
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