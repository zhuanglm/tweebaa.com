using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TweebaaWebApp2.MasterPages;
using System.Data;
using Twee.Comm;
using Twee.Mgr;


namespace TweebaaWebApp2.Product
{
    public partial class CheckoutShipping : BasePage
    {
        public string _displaySaved = "block";
        public string _displayShop = "none";
        public string _addressCartGudid = "";


        public bool _IsGuestChecout = false;

        public int _TweebaaDefaultShipMethodID = ConfigParamter.iTweebaaDefaultShipMethodID;

        public int _IsChangeAddr = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (Request.QueryString["cartids"] != null)
            {
                string cartIds = Request.QueryString["cartids"].ToString();
                string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
                CookiesHelper cookie = new CookiesHelper();
                cookie.createCookie(keyShopCart, cartIds, 1);
            }
            */
            Guid? userGuid;
            bool isLogion = CheckLogion(out userGuid);
            if (isLogion && userGuid != null)
            {
               

            }

            if (Request.QueryString["action"] != null && Request.QueryString["action"].ToString() == "change"){
                _IsChangeAddr = 1;
            }
            if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "guest")
            {

                _displaySaved = "none";
                _displayShop = "block";
                _IsGuestChecout = true;
                return;
            }
            if (!isLogion && _IsChangeAddr==0)
            {
                Response.Redirect("../User/loginGuest.aspx?op=CheckoutShipping");
            }
        }
    }
}