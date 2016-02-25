using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp.Product
{
    public partial class prdSingleShare : TweebaaWebApp.MasterPages.BasePage
    {
        private Guid? userGuid;
        public string _userid = string.Empty;
        public string _persent = string.Empty; //根据用户等级取分享比例
        public string _popbox = "block;";

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
                HttpCookie myCookie = new HttpCookie("SharersPopup");
                myCookie = Request.Cookies["SharersPopup"];

                try
                {
                    // Read the cookie information and display it.

                    if (myCookie != null && int.Parse(myCookie.Value.ToString()) > 0)
                    {
                        //design_id = myDesignID.Value.ToString();
                        _popbox = "none;";
                    }
                    else
                    {
                        _popbox = "block;";
                    }
                }
                catch (Exception e1)
                {

                }
            }

        }
    }
}