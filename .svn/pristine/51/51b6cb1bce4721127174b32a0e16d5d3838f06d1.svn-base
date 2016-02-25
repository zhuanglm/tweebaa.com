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

namespace TweebaaWebApp2.Mgr.CashWithdrawMgr
{
    public partial class CashWithdrawMgr : System.Web.UI.Page
    {
        Twee.Mgr.ProfitMgr mgr = new Twee.Mgr.ProfitMgr();
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(CashWithdrawMgr));
        }

        [AjaxPro.AjaxMethod]
        public int Accept(string sID)
        {
            int iID = 0;
            if (!int.TryParse(sID, out iID) ) return 0;    
            int iAffectedRow = mgr.MgeAcceptCashWithdraw(iID);
            return iAffectedRow;
        }

        [AjaxPro.AjaxMethod]
        public int Reject(string sID)
        {
            int iID = 0;
            if (!int.TryParse(sID, out iID)) return 0;
            int iAffectedRow = mgr.MgeRejectCashWithdraw(iID);
            return iAffectedRow;
        }

        [AjaxPro.AjaxMethod]
        public int Request(string sID)
        {
            int iID = 0;
            if (!int.TryParse(sID, out iID)) return 0;
            int iAffectedRow = mgr.MgeRequestCashWithdraw(iID);
            return iAffectedRow;
        }

    }
}