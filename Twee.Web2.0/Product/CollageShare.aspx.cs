using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp2.Product
{
    public partial class CollageShare : TweebaaWebApp2.MasterPages.BasePage
    {
        private Guid? userGuid;
        public string _userid = string.Empty;
        public string _persent = string.Empty; //根据用户等级取分享比例
        public bool isLogion=false;
        protected void Page_Load(object sender, EventArgs e)
        {
            isLogion = CheckLogion(out userGuid);

            if (null != userGuid)
            {
                // _popbox = "none;";
                _userid = userGuid.ToString();
                var persent = new Twee.Mgr.UserGradeCalMgr().GetUserGrade(userGuid).Rows[0]["sratio"];
                if (null != persent && !Convert.IsDBNull(persent))
                    _persent = (((int)persent) / 1000).ToString();
            }
            else
            {
                _userid = "";
                _persent = "";

            }
        }
    }
}