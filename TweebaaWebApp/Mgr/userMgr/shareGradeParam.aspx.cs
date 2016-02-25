using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;

namespace TweebaaWebApp.Mgr.userMgr
{
    public partial class shareGradeParam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(shareGradeParam));
        }
        [AjaxPro.AjaxMethod]
        public string DoublePoints()
        {
            Twee.Mgr.WebsiteActivityMgr active = new Twee.Mgr.WebsiteActivityMgr();
            return active.DoublePointsForShare() == true ? "success" : "fail";
        }
    }
}