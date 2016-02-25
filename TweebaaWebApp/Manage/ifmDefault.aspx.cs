using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;

namespace TweebaaWebApp.Manage
{
    public partial class ifmDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(WN.ToolBox.CookieHelper.GetCookie("cookadminguid")))
            //   
            if (!IsPostBack)
            {
                // PasswordHelper.ChkAdmlogin();
            }
        }
    }
}