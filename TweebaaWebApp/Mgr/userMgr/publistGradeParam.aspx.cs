using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;
using System.Configuration;
using System.Xml;

namespace TweebaaWebApp.Mgr.userMgr
{
    
    public partial class publistGradeParam : System.Web.UI.Page
    {
        public string webAppDomain = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(publistGradeParam));
            if (!IsPostBack)
            {
                webAppDomain = ConfigurationManager.AppSettings["webAppDomain"].Trim();
            }
            
        }
        [AjaxPro.AjaxMethod]
        public string DoublePoints()
        { 
            Twee.Mgr.WebsiteActivityMgr active=new Twee.Mgr.WebsiteActivityMgr();
            return active.DoublePointsForPublich() == true ? "success" : "fail";
        }
    }
}