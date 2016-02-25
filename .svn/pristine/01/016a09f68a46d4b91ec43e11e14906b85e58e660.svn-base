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
    public partial class PageContentMgr : System.Web.UI.Page
    {
        Twee.Mgr.PageContentMgr mgr = new Twee.Mgr.PageContentMgr();
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(PageContentMgr));
        }

        [AjaxPro.AjaxMethod]
        public string GetPageContentInfo(string sPageContentID)
        {
            int iPageContentID = -1;
            int.TryParse(sPageContentID, out iPageContentID);
            DataTable dt = mgr.MgeGetPageContentInfo(iPageContentID);
            string sInfo = JsonConvert.SerializeObject(dt);
            return sInfo;
        }

        [AjaxPro.AjaxMethod]
        public int Add(int iPageContentCateID, string sPageTitle, string sPageDesc, string sSeoTitle, string sSeoKeyWord, string sSeoMetaTag)
        {
            int iAffectedRow = mgr.MgeAddPageContent(iPageContentCateID, sPageTitle, sPageDesc, sSeoTitle, sSeoKeyWord, sSeoMetaTag);
            return iAffectedRow;
        }

        [AjaxPro.AjaxMethod]
        public int Update(int iPageContentID, int iPageContentCateID, string sPageTitle, string sPageDesc, string sSeoTitle, string sSeoKeyWord, string sSeoMetaTag)
        {
            int iAffectedRow = mgr.MgeUpdatePageContent(iPageContentID, iPageContentCateID, sPageTitle, sPageDesc, sSeoTitle, sSeoKeyWord, sSeoMetaTag);
            return iAffectedRow;
        }

        [AjaxPro.AjaxMethod]
        public int Delete(string sPageContentID)
        {
            int iPageContentID = -1;
            int.TryParse(sPageContentID, out iPageContentID);
            int iAffectedRow = mgr.MgeDeletePageContent(iPageContentID);
            return iAffectedRow;
        }

        [AjaxPro.AjaxMethod]
        public string GetPageContentCateList()
        {
            DataTable dt = mgr.MgeGetPageContentCateList();
            string sList = JsonConvert.SerializeObject(dt);
            return sList;
        }


    }
}