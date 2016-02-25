using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp2.Home
{
    public partial class HomeAdress : TweebaaWebApp2.MasterPages.BasePage
    {
        private Guid? userGuid;
        public string strComeFrom = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //from=shop
            if (string.IsNullOrEmpty(Request["from"]))
            {

            }
            else
            {
                //用户从Add 2 Cart 来，应该回到Checkout page
                strComeFrom = "?from="+Request["from"].ToString();
            }
            bool isLogion = CheckLogion(out userGuid);
            if (null != userGuid)
            {
                // _userid = userGuid.ToString();
            }
            else
            {
                //go to user login
                var response = base.Response;
                response.Redirect("/User/login.aspx?op=HomeAddress");
            }
        }
    }
}