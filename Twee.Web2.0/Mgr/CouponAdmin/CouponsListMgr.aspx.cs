using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;

namespace TweebaaWebApp2.Mgr.CouponAdmin
{
    public partial class CouponsListMgr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(CouponsListMgr));
        }
        [AjaxPro.AjaxMethod]
        public bool DoDeleteCoupon(string sID)
        {
            int iID = int.Parse(sID);
            Twee.Mgr.CouponMgr mgr = new Twee.Mgr.CouponMgr();
            bool iAffectedRow = mgr.Delete(iID);
            return iAffectedRow;
        }
        [AjaxPro.AjaxMethod]
        public bool DoActiveCoupon(string sID)
        {
            //int iID = int.Parse(sID);
            Twee.Mgr.CouponMgr mgr = new Twee.Mgr.CouponMgr();
            mgr.ChangeCouponStatus(true,sID);
            return true;
        }
        [AjaxPro.AjaxMethod]
        public bool DoDeActiveCoupon(string sID)
        {
            int iID = int.Parse(sID);
            Twee.Mgr.CouponMgr mgr = new Twee.Mgr.CouponMgr();
            mgr.ChangeCouponStatus(false,sID);
            return true;
        }
    }
}