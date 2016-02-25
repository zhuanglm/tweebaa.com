using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;

namespace TweebaaWebApp2.Events.Tweebot
{
    public partial class Submit_Suggestion : TweebaaWebApp2.MasterPages.BasePage
    {
        private Guid? userGuid;
        public string _userid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);

            if (null != userGuid)
            {
                _userid = userGuid.ToString();
            }
            else
            {
                //go to user login
                var response = base.Response;
                response.Redirect("/User/login.aspx?op=tweebot_suggestion");
            }
        }

    }
}