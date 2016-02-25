using System;
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

namespace TweebaaWebApp2.Mgr.PageContentMgr
{
    public partial class PageContentCateMgr : System.Web.UI.Page
    {

        Twee.Mgr.PageContentMgr mgr = new Twee.Mgr.PageContentMgr();
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(PageContentCateMgr));

        }


        [AjaxPro.AjaxMethod]
        public string GetPageContentCateInfo(string sPageContentCateID)
        {
            DataTable dt = mgr.MgeGetPageContentCateInfo(sPageContentCateID);
            string sInfo = JsonConvert.SerializeObject(dt);
            return sInfo;
        }

        [AjaxPro.AjaxMethod]
        public int Add(string sName, string sActive)
        {

            int iAffectedRow = mgr.MgeAddPageContentCate(sName, sActive.ToInt());
            return iAffectedRow;
        }

        [AjaxPro.AjaxMethod]
        public int Update(string sID, string sName, string sActive)
        {
            int iAffectedRow = mgr.MgeUpdatePageContentCate(sID, sName, sActive.ToInt());
            return iAffectedRow;
        }

        [AjaxPro.AjaxMethod]
        public int Delete(string sID)
        {
            int iAffectedRow = mgr.MgeDeletePageContentCate(sID);
            return iAffectedRow;
        }
    }
}