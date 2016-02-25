using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp.Events.BugsReport
{
    public partial class BugsReportPost : TweebaaWebApp.MasterPages.BasePage
    {
        private Guid? userGuid;
        public string _userid = string.Empty;
        public string _persent = string.Empty; //根据用户等级取分享比例
        public string _popbox = "block;";

        public HttpResponse response;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);

            if (null != userGuid)
            {
                _popbox = "none;";
                _userid = userGuid.ToString();
                var persent = new Twee.Mgr.UserGradeCalMgr().GetUserGrade(userGuid).Rows[0]["sratio"];
                if (null != persent && !Convert.IsDBNull(persent))
                    _persent = (((int)persent) / 1000).ToString();
            }
            else
            {
                _userid = "";
                _persent = "";

                //go to user login
                var response = base.Response;
                response.Redirect("http://tweebaa.com/User/login.aspx?op=BugsPost");
            }

        }
    }
}