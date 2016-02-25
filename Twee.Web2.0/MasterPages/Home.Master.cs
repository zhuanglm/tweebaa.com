using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using Twee.Mgr;
using AjaxPro;
using TweebaaWebApp2.Home;

namespace TweebaaWebApp2.MasterPages
{
    public partial class Home : System.Web.UI.MasterPage
    {
        public string _userHeadPic = "src=\"Images/84x84.jpg\" onerror=\"this.src='/Images/head_default.jpg'\"";
        public string _publishPic = string.Empty;
        public string _reviewPic = string.Empty;
        public string _sharePic = string.Empty;
        public string _qiaoDaoUserid = string.Empty;
        public int _userPublishLevel = 1;
        public int _userReviewLevel = 1;
        public int _userShareLevel = 1;
        public string _sCurVer = "0";
        public bool _IsUploadImg = false;
        public string[] strMenuActive=new string[6];
        public string[] strULActive = new string[6];
        protected void Page_Load(object sender, EventArgs e)
        {
            _sCurVer = CommUtil.GetCurrentVersion();

            //Utility.RegisterTypeForAjax(typeof(Index));
            CookiesHelper ck = new CookiesHelper();
            //string userGuid = ck.getCookie("jZvJvvjqCILHX7zjBWskQA");
            //string userEmail = ck.getCookie("jZvJvvjqCILHX7zjBWskQB");
            //string pwd = ck.getCookie("jZvJvvjqCILHX7zjBWskQC");
            string userGuid = string.Empty;
            string userEmail = string.Empty;
            string userPwd = string.Empty;
            CommUtil.GetUserLoginCookie(out userGuid, out userEmail, out userPwd);

            string url = Request.RawUrl;
            if (url.ToLower().IndexOf("accountsettings.aspx") >= 0)
            {
                _IsUploadImg = true;
            }

            //Add by Long 2016/01/19 for active menu
            for (int i = 0; i < 6; i++)
            {
                strMenuActive[i] = "";
                strULActive[i] = "";
            }
            if (url.IndexOf("HomeProfit.aspx") >= 0 ||
                url.IndexOf("HomeIntegral.aspx") >= 0 ||
                url.IndexOf("Shopping_Points.aspx") >= 0 ||
                url.IndexOf("HomeGiftReward.aspx") >= 0 ||
                url.IndexOf("SharePointRedeem.aspx") >= 0
                )
            {
                strMenuActive[0] = "active";
                strULActive[0] = "in";
            }
            
            if (url.IndexOf("HomeSupply.aspx") >= 0 ||
                url.IndexOf("HomeReview.aspx") >= 0 ||
                url.IndexOf("HomeShare.aspx") >= 0 ||
                url.IndexOf("MyCollage.aspx") >= 0 ||
                url.IndexOf("HomeCollageShare.aspx") >= 0 
                )
            {
                strMenuActive[1] = "active";
                strULActive[1] = "in";
            }
            if (url.IndexOf("HomeCollection.aspx") >= 0 ||
                url.IndexOf("HomeCollageFavorite.aspx") >= 0 
                )
            {
                strMenuActive[2] = "active";
                strULActive[2] = "in";
            }
            if (url.IndexOf("AccountSettings.aspx") >= 0 ||
                url.IndexOf("HomeAddress.aspx") >= 0
                )
            {
                strMenuActive[4] = "active";
                strULActive[4] = "in";
            }
            if (url.IndexOf("HomeProfile.aspx") >= 0 ||
                url.IndexOf("HomeShipOrder.aspx") >= 0 ||
                url.IndexOf("homeSupply.aspx") >= 0
                )
            {
                strMenuActive[5] = "active";
                strULActive[5] = "in";
            }
            if (!string.IsNullOrEmpty(userGuid) && !string.IsNullOrEmpty(userPwd))
            {
                UserMgr mgr = new UserMgr();
                Twee.Model.User user;
                bool islogion = mgr.IsLogionByID(userGuid, userPwd, out user);
                if (islogion == true && user != null)
                {
                    userName.InnerText = user.username;
                   // labUser2.InnerText = user.username;
                    spanLogion1.Visible = false;
                    if (!string.IsNullOrEmpty(user.headimg))
                        _userHeadPic = user.headimg;
                    _qiaoDaoUserid = userGuid;

                    if (user.headimg != "")
                    {
                        _userHeadPic = user.headimg;
                    
                        if (user.headimg.Contains("~/"))
                        {
                            _userHeadPic = user.headimg.Replace("~/", "/");
                        }

                        _userHeadPic = "src=\"" + _userHeadPic + "\" onerror=\"this.src='http://itweebaa.com" + _userHeadPic +"'\"";
                        
                    }
                    //spanLogion2.Visible = true;

                    ShoppingcartMgr cart = new ShoppingcartMgr();
                    //int cartCount = cart.GetRecordCount("userguid='" + userGuid + "'");
                    //labCartCount.Text = cartCount.ToString();

                    int cookCount = 0;
                    int loginCount = 0;
                    string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
                    string shopCartCookie = ck.getCookie(keyShopCart);
                    if (!string.IsNullOrEmpty(shopCartCookie))
                    {
                        string[] countStr = shopCartCookie.Split(',');
                        cookCount = countStr.Length;
                    }
                    userName.InnerText = user.username;
                    spanLogion1.Visible = false;
                    //loginCount = cart.GetRecordCount("userguid='" + userGuid + "'");
                    loginCount = cart.GetShoppingCartQtyCount("userguid='" + userGuid + "'");

                   // labCartCount.Text = (cookCount + loginCount).ToString();
                    //modify by Long as it doesn't match homepage
                    labCartCount.Text = loginCount.ToString();

                    Twee.Mgr.MoneyMgr moneyMgr = new Twee.Mgr.MoneyMgr();
                    //int fabu = (int)Twee.Comm.ConfigParamter.ShouYiType.myfabu;
                    //int pingshen = (int)Twee.Comm.ConfigParamter.ShouYiType.mypingshen;
                    //int fenxiang = (int)Twee.Comm.ConfigParamter.ShouYiType.myfenxiang;
                    //decimal _fabu = moneyMgr.GetShouYi(userGuid.ToString(), fabu.ToString())._DefaultToString("0.00").ToDecimal();//发布收益
                    //decimal _pingshen = moneyMgr.GetShouYi(userGuid.ToString(), pingshen.ToString())._DefaultToString("0.00").ToDecimal();//评审收益
                    //decimal _fenxiang = moneyMgr.GetShouYi(userGuid.ToString(), fenxiang.ToString())._DefaultToString("0.00").ToDecimal();//分享收益
                    //decimal sumCash = _fabu + _pingshen + _fenxiang;//总收益
                    //labSumCash.Text = sumCash.ToString();
                    /*
                    labSumCash.Text = Math.Round(moneyMgr.GetShouYi(userGuid.ToString(), "").ToDecimal(), 2).ToString();//总收益
                    labSumCash2.Text = labSumCash.Text;//总tweebucks
                    */
                    //总消费金额
                    OrderMgr order = new OrderMgr();
                    decimal shoppingMoney = order.GetSumShopMoney(userGuid, Twee.Comm.ConfigParamter.OrderStatus.Shipped);

                    // shopping gift reward
                    UserGiftRewardMgr giftMgr = new UserGiftRewardMgr();
                    int iGiftShoppingPoint = giftMgr.GetTotalShoppingRewardPoint(userGuid);

                    shoppingMoney += iGiftShoppingPoint;
                    /*
                    labSumShop.Text = Math.Round(shoppingMoney, 2).ToString();
                    labSumShop2.Text = Math.Round(shoppingMoney * 0.0125M, 2).ToString();
                    */


                    //等级
                    UserGradeCalMgr gradeCal = new UserGradeCalMgr();
                    Twee.Model.Usergrade userGrade = gradeCal.GetModel(userGuid.ToGuid().Value);
                    //labSumPoit.Text = (userGrade.publishintegral.Value + userGrade.shareintegral.Value + userGrade.reviewintegral.Value).ToString();
                    _publishPic = "../Images/level/submit-lv_" + userGrade.publishgrade + ".gif";  //images/va-lv8.png
                    _reviewPic = "../Images/level/evaluate-lv_" + userGrade.reviewgrade + ".gif"; //images/vb-lv5.png
                    _sharePic = "../Images/level/share-lv_" + userGrade.sharegrade + ".gif"; //images/vc-lv1.png
                    if (userGrade.publishgrade != null)
                    {
                        _userPublishLevel = (int)userGrade.publishgrade;
                        if (_userPublishLevel == 0) _userPublishLevel = 1;
                    }

                    if (userGrade.reviewgrade != null)
                    {
                        _userReviewLevel = (int)userGrade.reviewgrade;
                        if (_userReviewLevel == 0) _userReviewLevel = 1;
                    }
                    if (userGrade.sharegrade != null)
                    {
                        _userShareLevel = (int)userGrade.sharegrade;
                        if (_userShareLevel == 0) _userShareLevel = 1;
                    }
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('Please log in！')</script>");
                    Response.Redirect("~/User/login.aspx");
                    spanLogion2.Visible = false;
                }
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('Please log in！')</script>");

                string sParm = string.Empty;
                if (Request.RawUrl.ToLower().IndexOf("homeshiporder.aspx") != -1) sParm = "?op=HomeShipOrder";

                Response.Redirect("~/User/login.aspx" + sParm);
                spanLogion2.Visible = false;
            }
        }
    }
}