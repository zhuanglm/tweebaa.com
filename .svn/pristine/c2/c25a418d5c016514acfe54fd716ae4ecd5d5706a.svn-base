using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;

namespace TweebaaWebApp2.Mgr.userMgr
{
    public partial class reviewGradeParam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(reviewGradeParam));
        }
        [AjaxPro.AjaxMethod]
        public string DoublePoints()
        {
            Twee.Mgr.WebsiteActivityMgr active = new Twee.Mgr.WebsiteActivityMgr();
            return active.DoublePointsForReview() == true ? "success" : "fail";
        }
    }
}