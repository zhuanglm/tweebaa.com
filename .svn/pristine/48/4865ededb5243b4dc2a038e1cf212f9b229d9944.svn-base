using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp2.Events.BugsReport
{
    public partial class admin : TweebaaWebApp2.MasterPages.BasePage
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

                if ("eff4dca6-fedc-4bd9-bbe5-79dec2bb39d8" == _userid || "7dc741b1-998b-4791-a047-65a9e3a4087f" == _userid)
                {
                }
                else
                {
                    response.Redirect("http://tweebaa.com/Events/BugsReport/index.aspx");
                }
            }
            else
            {
                response.Redirect("http://tweebaa.com/Events/BugsReport/index.aspx");

            }

        }
    }
}