using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp.Product
{
    public partial class prdSale : TweebaaWebApp.MasterPages.BasePage
    {
        private Guid? userGuid;
        public string _userid = string.Empty;
        public string _persent = string.Empty; //根据用户等级取分享比例

        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);

            if (null != userGuid)
            {
                _userid = userGuid.ToString();
                var persent = new Twee.Mgr.UserGradeCalMgr().GetUserGrade(userGuid).Rows[0]["sratio"];
                if (null != persent && !Convert.IsDBNull(persent))
                    _persent = (((int)persent) / 1000).ToString();
            }

        }
    }
}