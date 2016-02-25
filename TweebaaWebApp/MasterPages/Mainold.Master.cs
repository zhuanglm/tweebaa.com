using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using Twee.Mgr;

namespace TweebaaWebApp.MasterPages
{
    public partial class Mainold : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {          
            CookiesHelper ck = new CookiesHelper();
            string userGuid = ck.getCookie("jZvJvvjqCILHX7zjBWskQA");
            string userEmail = ck.getCookie("jZvJvvjqCILHX7zjBWskQB");
            if (!string.IsNullOrEmpty(userGuid)&&!string.IsNullOrEmpty(userEmail))
            {
                Guid guid = new Guid(userGuid);
                UserMgr mgr = new UserMgr();
                Twee.Model.User user = mgr.GetModel(guid, userEmail);
                userName.Text = user.username;
            }


            //CookiesHelper cook = new CookiesHelper();
            //if (string.IsNullOrEmpty(cook.getCookie("hshoppingcartcookguid")))
            //{
            //    string strguid = Guid.NewGuid().ToString();
            //    if (cook.createCookie("hshoppingcartcookguid", strguid, 30))
            //    {
            //        hshoppingcartcookguid.Value = strguid;
            //        hshoppingcartcookguid2.Value = WN.ToolBox.PasswordHelper.Md5Sign(strguid);
            //    }
            //    else
            //        Response.Redirect("error.aspx");
            //}
            //else
            //{
            //    hshoppingcartcookguid.Value = cook.getCookie("hshoppingcartcookguid");
            //    hshoppingcartcookguid2.Value = WN.ToolBox.PasswordHelper.Md5Sign(cook.getCookie("hshoppingcartcookguid"));
            //}
        }       
    }
}