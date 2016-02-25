using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp2.Home
{
    public partial class HomeCollageFavorite : TweebaaWebApp2.MasterPages.BasePage
    {
        public string _userid = string.Empty;
        private Guid? userGuid;
        //public string _persent = string.Empty; //根据用户等级取分享比例
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);



            if (null != userGuid)
            {
                _userid = userGuid.ToString();
                //_userid = userGuid.ToString();

            }
            else
            {
                _userid = "";
               
            }
        }
    }
}