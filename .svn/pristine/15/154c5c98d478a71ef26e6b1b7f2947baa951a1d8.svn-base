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
    public partial class EventsMasterPage : System.Web.UI.MasterPage
    {
        public string _popbox = "none;";
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.RawUrl;
            if (url.IndexOf("Buy") > 0)
            {
                _popbox = "block;";
            }

            CookiesHelper ck = new CookiesHelper();
            string userGuid = ck.getCookie("jZvJvvjqCILHX7zjBWskQA");
            string userEmail = ck.getCookie("jZvJvvjqCILHX7zjBWskQB");
            string pwd = ck.getCookie("jZvJvvjqCILHX7zjBWskQC");

            int cookCount = 0;
            int loginCount = 0;
            string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
            string shopCartCookie = ck.getCookie(keyShopCart);
            if (!string.IsNullOrEmpty(shopCartCookie))
            {
                string[] countStr = shopCartCookie.Split(',');                
                cookCount = countStr.Length;                
            }           
            
            if (!string.IsNullOrEmpty(userGuid) && !string.IsNullOrEmpty(pwd))
            {              
                UserMgr mgr = new UserMgr();
                Twee.Model.User user ;
                bool islogion = mgr.IsLogionByID(userGuid, pwd,out user);
                if (islogion==true && user != null)
                {
                   // Request.FilePath或RawUrl就行么
                    
                    if (url.IndexOf("Buy")>0)
                    {
                        _popbox = "none;";
                    }      

                    userName.InnerText = user.username;
                    spanLogion1.Visible = false;                      
                    hrfSupply.HRef = "../Product/prdReviewStep2.aspx?step=supply";

                    ShoppingcartMgr cart = new ShoppingcartMgr();
                    loginCount = cart.GetRecordCount("userguid='" + userGuid + "'");
                }
                else
                {                   
                    spanLogion2.Visible = false;
                    hrfSupply.HRef = "../Product/supplyLogin.aspx";
                }               
            }
            else
            {                
                spanLogion2.Visible = false;
                hrfSupply.HRef = "../Product/supplyLogin.aspx";
            }
            labCartCount.Text = (cookCount + loginCount).ToString();
            if (labCartCount.Text=="0")
            {
                hrefCart.HRef = "../Product/shoppCartEmpty.aspx.";
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

        protected void logionOut_click(object sender, EventArgs e)
        {
            CookiesHelper cook = new CookiesHelper();          
            bool b = cook.createCookie("jZvJvvjqCILHX7zjBWskQC", "", -1);
            Response.Redirect("../User/login.aspx");
               
            //HttpCookie aCookie;
            //string cookieName;
            //int limit = Request.Cookies.Count;
            //for (int i = 0; i < limit; i++)
            //{
            //    cookieName = Request.Cookies[i].Name;
            //    aCookie = new HttpCookie(cookieName);
            //    aCookie.Expires = DateTime.Now.AddDays(-1);
            //    Response.Cookies.Add(aCookie);
            //}

        }
    }
}