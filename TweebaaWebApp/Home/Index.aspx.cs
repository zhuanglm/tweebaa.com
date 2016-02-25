using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using Twee.Mgr;
using Twee.Model;
using AjaxPro;
using System.Data;

namespace TweebaaWebApp.Home
{
    public partial class Index : System.Web.UI.Page
    {
        public string _userHeadPic = "images/84x84.jpg";
        public string _publishPic = string.Empty;
        public string _reviewPic = string.Empty;
        public string _sharePic = string.Empty;
        public string _qiaoDaoUserid = string.Empty;
        public int _userPublishLevel=1;
        public int _userReviewLevel=1;
        public int _userShareLevel=1;
        public int _userSupplyPermission = 0;
        public string _sCurVer = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            _sCurVer = CommUtil.GetCurrentVersion();

            Utility.RegisterTypeForAjax(typeof(Index));
            CookiesHelper ck = new CookiesHelper();
            string userGuid = ck.getCookie("jZvJvvjqCILHX7zjBWskQA");
            string userEmail = ck.getCookie("jZvJvvjqCILHX7zjBWskQB");
            string pwd = ck.getCookie("jZvJvvjqCILHX7zjBWskQC");
            if (!string.IsNullOrEmpty(userGuid) && !string.IsNullOrEmpty(pwd))
            {
                UserMgr mgr = new UserMgr();
                Twee.Model.User user;
                bool islogion = mgr.IsLogionByID(userGuid, pwd, out user);
                if (islogion == true && user != null)
                {
                    if (user.supplypermission != null) _userSupplyPermission = (int)user.supplypermission;
                    userName.InnerText = user.username;
                    labUser2.InnerText = user.username;
                    spanLogion1.Visible = false;
                    if (!string.IsNullOrEmpty(user.headimg))
                        _userHeadPic = user.headimg;
                    _qiaoDaoUserid = userGuid;

                    if (user.headimg != "")
                    {
                        _userHeadPic = user.headimg;
                    }
                    if (user.headimg.Contains("~/"))
                    {
                        _userHeadPic = user.headimg.Replace("~/","../");
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
                    loginCount = cart.GetRecordCount("userguid='" + userGuid + "'");

                    labCartCount.Text = (cookCount + loginCount).ToString();


                    Twee.Mgr.MoneyMgr moneyMgr = new Twee.Mgr.MoneyMgr();
                    //int fabu = (int)Twee.Comm.ConfigParamter.ShouYiType.myfabu;
                    //int pingshen = (int)Twee.Comm.ConfigParamter.ShouYiType.mypingshen;
                    //int fenxiang = (int)Twee.Comm.ConfigParamter.ShouYiType.myfenxiang;
                    //decimal _fabu = moneyMgr.GetShouYi(userGuid.ToString(), fabu.ToString())._DefaultToString("0.00").ToDecimal();//发布收益
                    //decimal _pingshen = moneyMgr.GetShouYi(userGuid.ToString(), pingshen.ToString())._DefaultToString("0.00").ToDecimal();//评审收益
                    //decimal _fenxiang = moneyMgr.GetShouYi(userGuid.ToString(), fenxiang.ToString())._DefaultToString("0.00").ToDecimal();//分享收益
                    //decimal sumCash = _fabu + _pingshen + _fenxiang;//总收益
                    //labSumCash.Text = sumCash.ToString();
                    //labSumCash.Text = Math.Round(moneyMgr.GetShouYi(userGuid.ToString(), "").ToDecimal(), 2).ToString();//总收益
                    //labSumCash2.Text = labSumCash.Text;//总tweebucks

                    Twee.Mgr.ProfitMgr profitMgr = new Twee.Mgr.ProfitMgr();
                    DataTable dt = profitMgr.GetTweebuck(userGuid.ToGuid().Value);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        decimal extractionTweebuck = dt.Rows[0]["ExtractionTweebuck"].ToString().ToDecimal();//可使用的tweebucks
                        labSumCash.Text = extractionTweebuck.ToString();//当前总剩余可用tweebucks
                        labSumCash2.Text = labSumCash.Text;
                    }

                    //总消费金额
                    /*
                    OrderMgr order = new OrderMgr();
                    decimal shoppingMoney = order.GetSumShopMoney(userGuid, 3);     
              
                    // shopping gift reward
                    UserGiftRewardMgr giftMgr = new UserGiftRewardMgr();
                    int iGiftShoppingPoint = giftMgr.GetTotalShoppingRewardPoint(userGuid);

                    shoppingMoney += iGiftShoppingPoint;
                    labSumShop.Text = Math.Round(shoppingMoney, 2).ToString();
                    labSumShop2.Text = Math.Round(shoppingMoney * 0.0125M, 2).ToString();*/
                   


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

                    labSumShop.Text = userGrade.shopingPoint.Value.ToString();
                    labSumShop2.Text = Math.Round(userGrade.shopingPoint.Value * 0.0125M, 2).ToString();
                    //DataTable dtShoppingPoint = gradeCal.GetUseShoppingPoint(userGuid);
                    //if (dtShoppingPoint != null && dtShoppingPoint.Rows.Count > 0)
                    //{
                    //    labSumShop2.Text = dtShoppingPoint.Rows[0][0].ToString() == "" ? "0.00" : dtShoppingPoint.Rows[0][0].ToString();
                    //}
                   
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
                Response.Redirect("~/User/login.aspx");
                spanLogion2.Visible = false;
            }
        }

        [AjaxPro.AjaxMethod]
        public string SaveQianDao(string userid)
        {
            try
            {
                userQianDaoMgr mgr = new userQianDaoMgr();
                bool isContinuous7 = false;
                int? datdiff = mgr.GetRecentlySingDay(userid,out isContinuous7);
                if (datdiff == null || datdiff>0)
                {
                    Twee.Model.userQianDao model = new Twee.Model.userQianDao();
                    model.userid = userid.Trim();
                    model.createtime = System.DateTime.Now;
                    int resu = mgr.Add(model);
                    if (resu>0)
                    {
                        string strMes = "";
                        //修改积分 奖励10分
                        UserGradeCalMgr userMgr = new UserGradeCalMgr();
                        Usergrade modelGrade = userMgr.GetModel(userid.ToGuid().Value);
                        if (isContinuous7==true)
                        {
                            modelGrade.publishintegral += 10;
                            modelGrade.shareintegral += 10;
                            modelGrade.reviewintegral += 10;
                            strMes = "Congratulations, you have continuous attendance for a week, get 10 bonus points";
                        }

                        else
                        {
                            modelGrade.publishintegral += 1;
                            modelGrade.shareintegral += 1;
                            modelGrade.reviewintegral += 1;
                            strMes = "Congratulations, You've just received your daily check-in points. We hope to see you again tomorrow.";
                        }
                        userMgr.Update(modelGrade);
                        return strMes;
                    }  
                }
                else if (datdiff.Value==0)
                {
                    return " You have already signed today!";                   
                }
                return "error";
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
    
    
    }
}