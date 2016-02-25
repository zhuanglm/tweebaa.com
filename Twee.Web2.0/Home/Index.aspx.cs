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

namespace TweebaaWebApp2.Home
{
    public partial class index : TweebaaWebApp2.MasterPages.BasePage
    {
        public string _userHeadPic = "images/84x84.jpg";
        public string _publishPic = string.Empty;
        public string _reviewPic = string.Empty;
        public string _sharePic = string.Empty;
        public string _qiaoDaoUserid = string.Empty;
        public int _userPublishLevel = 1;
        public int _userReviewLevel = 1;
        public int _userShareLevel = 1;
        public int _userSupplyPermission = 0;
        public string _sCurVer = "0";
        public float f1;
        public float f2;
        public float f3;

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(index));
            _sCurVer = CommUtil.GetCurrentVersion();


            CookiesHelper ck = new CookiesHelper();
            //string userGuid = ck.getCookie("jZvJvvjqCILHX7zjBWskQA");
            //string userEmail = ck.getCookie("jZvJvvjqCILHX7zjBWskQB");
            //string pwd = ck.getCookie("jZvJvvjqCILHX7zjBWskQC");
            string userGuid = string.Empty;
            string userEmail = string.Empty;
            string userPwd = string.Empty;
            CommUtil.GetUserLoginCookie(out userGuid, out userEmail, out userPwd);

            if (!string.IsNullOrEmpty(userGuid) && !string.IsNullOrEmpty(userPwd))
            {
                UserMgr mgr = new UserMgr();
                Twee.Model.User user;
                bool islogion = mgr.IsLogionByID(userGuid, userPwd, out user);
                if (islogion == true && user != null)
                {
                    if (user.supplypermission != null) _userSupplyPermission = (int)user.supplypermission;
                    /*
                    userName.InnerText = user.username;
                    labUser2.InnerText = user.username;
                    spanLogion1.Visible = false; */
                    if (!string.IsNullOrEmpty(user.headimg))
                        _userHeadPic = user.headimg;
                    _qiaoDaoUserid = userGuid;

                    if (user.headimg != "")
                    {
                        _userHeadPic = user.headimg;
                    }
                    if (user.headimg.Contains("~/"))
                    {
                        _userHeadPic = user.headimg.Replace("~/", "../");
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
                    //userName.InnerText = user.username;
                   // spanLogion1.Visible = false;
                    loginCount = cart.GetRecordCount("userguid='" + userGuid + "'");

                    //labCartCount.Text = (cookCount + loginCount).ToString();


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
                    DataTable dt2 = profitMgr.GetTweebuck(userGuid.ToGuid().Value);
                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        decimal extractionTweebuck = dt2.Rows[0]["ExtractionTweebuck"].ToString().ToDecimal();//可使用的tweebucks
                        labSumCash.Text = extractionTweebuck.ToString();//当前总剩余可用tweebucks
                        labSumCash2.Text = labSumCash.Text;
                    }

                    //总消费金额
                    
                    OrderMgr order = new OrderMgr();
                    decimal shoppingMoney = order.GetSumShopMoney(userGuid, ConfigParamter.OrderStatus.Shipped);    //change 3 --2 
                    decimal used_shopping_money = order.GetSumUsedShoppingPointsMoney(userGuid);
                    decimal shoppingMoneyPending = order.GetSumShopMoney(userGuid, ConfigParamter.OrderStatus.WaitingToShip);

                    //decimal bonusShoppingPoint = order.GetBonusShoppingPoint(userGuid);

                    //get bonus shopping point
                    decimal shoppingPendingBonus = order.GetBonusShoppingPoint(userGuid.ToString(), ConfigParamter.OrderStatus.WaitingToShip);//Bonus
                    decimal shoppingBobusMoney = order.GetBonusShoppingPoint(userGuid.ToString(), ConfigParamter.OrderStatus.Shipped);   //Bonus

                    // shopping gift reward
                    UserGiftRewardMgr giftMgr = new UserGiftRewardMgr();
                    int iGiftShoppingPoint = giftMgr.GetTotalShoppingRewardPoint(userGuid);

                    shoppingMoney += iGiftShoppingPoint;
                    shoppingMoney += shoppingBobusMoney;

                    shoppingMoneyPending += shoppingPendingBonus;

                    //shoppingMoney += bonusShoppingPoint;
                    shoppingMoney = shoppingMoney - used_shopping_money * 80;
                    labSumShop.Text = Math.Round(shoppingMoney, 2).ToString();
                    labSumShop2.Text = Math.Round(shoppingMoney * 0.0125M, 2).ToString();
                    labSumShopPending.Text = Math.Round(shoppingMoneyPending, 2).ToString();


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
                    /*
                    labSumShop.Text = userGrade.shopingPoint.Value.ToString();
                    labSumShop2.Text = Math.Round(userGrade.shopingPoint.Value * 0.0125M, 2).ToString();*/
                    //DataTable dtShoppingPoint = gradeCal.GetUseShoppingPoint(userGuid);
                    //if (dtShoppingPoint != null && dtShoppingPoint.Rows.Count > 0)
                    //{
                    //    labSumShop2.Text = dtShoppingPoint.Rows[0][0].ToString() == "" ? "0.00" : dtShoppingPoint.Rows[0][0].ToString();
                    //}



                    DataTable dt = gradeCal.GetUserGrade(userGuid.ToGuid().Value);

                    int iPublishLevel = Int32.Parse(dt.Rows[0]["publishgrade"].ToString());
                    int iReviewLevel = Int32.Parse(dt.Rows[0]["reviewgrade"].ToString());
                    string s = dt.Rows[0]["sharegrade"].ToString();
                    if (s.Length < 1) s = "0";
                    int iShareLevel = Int32.Parse(s);
                    if (iPublishLevel == 0) iPublishLevel = 1;
                    if (iReviewLevel == 0) iReviewLevel = 1;
                    if (iShareLevel == 0) iShareLevel = 1;


                    //<div style="width: 85%" aria-valuemax="100" aria-valuemin="0" aria-valuenow="85" role="progressbar" class="progress-bar progress-bar-blue"></div>
                    //<div style="width: 55%" aria-valuemax="100" aria-valuemin="0" aria-valuenow="85" role="progressbar" class="progress-bar progress-bar-u"></div></div>
                    //<div style="width: 25%" aria-valuemax="100" aria-valuemin="0" aria-valuenow="85" role="progressbar" class="progress-bar progress-bar-orange"></div>
                    /*
                     <asp:Label ID="labSubLevelPer" runat="server"></asp:Label>
<asp:Label ID="labEvaluateLevelPer" runat="server"></asp:Label>
<asp:Label ID="labShareLevelPer" runat="server"></asp:Label>
                     */

                    f1 = (float)iPublishLevel *100/ 10;
                    f2 = (float)iReviewLevel * 100 / 10;
                    f3 = (float)iShareLevel * 100 / 10;

                   

                    labSubLevel.Text = iPublishLevel.ToString();
                    labEvaluateLevel.Text = iReviewLevel.ToString();
                    labShareLevel.Text = iShareLevel.ToString();

                    labSubPoint.Text = dt.Rows[0]["publishintegral"].ToString();
                    labEvaluatePoint.Text = dt.Rows[0]["reviewintegral"].ToString();
                    labSharePoint.Text = dt.Rows[0]["shareintegral"].ToString();

                    labSubRat.Text = "0." + dt.Rows[0]["pratio"].ToString() + "%";
                    labEvaluateRat.Text = "0." + dt.Rows[0]["rratio1"].ToString() + "%";
                    labShareRat.Text = dt.Rows[0]["sratio"].ToString().ToDecimal() / 10 + "%";
                    /*
                    Twee.Mgr.ProfitMgr profitMgr = new Twee.Mgr.ProfitMgr();
                    DataTable dt2 = profitMgr.GetTweebuck(userGuid.Value);
                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        decimal extractionTweebuck = dt2.Rows[0]["ExtractionTweebuck"].ToString().ToDecimal();//可使用的tweebucks
                        labSumCash.Text = extractionTweebuck.ToString();//当前总剩余可用tweebucks
                        labSumCash2.Text = labSumCash.Text;
                    }


                    Twee.Model.Usergrade userGrade = gradeCal.GetModel(userGuid.Value);
                    labSumShop.Text = userGrade.shopingPoint.Value.ToString();
                    labSumShop2.Text = Math.Round(userGrade.shopingPoint.Value * 0.0125M, 2).ToString();
                     * */

                    BindDayImg(userGuid.ToString());
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('Please log in！')</script>");
                    Response.Redirect("~/User/login.aspx");
                    //spanLogion2.Visible = false;
                }
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('Please log in！')</script>");
                Response.Redirect("~/User/login.aspx");
                //spanLogion2.Visible = false;
            }
        }

        [AjaxPro.AjaxMethod]
        public string SaveQianDao(string userid)
        {
            try
            {
                userQianDaoMgr mgr = new userQianDaoMgr();
                bool isContinuous7 = false;
                int? datdiff = mgr.GetRecentlySingDay(userid, out isContinuous7);

                if (datdiff == null || datdiff > 0)
                {
                    Twee.Model.userQianDao model = new Twee.Model.userQianDao();
                    model.userid = userid.Trim();
                    model.createtime = System.DateTime.Now;
                    int resu = mgr.Add(model);

                    if (resu > 0)
                    {
                        string strMes = "";
                        //修改积分 奖励10分
                        UserGradeCalMgr userMgr = new UserGradeCalMgr();
                        int point = 1;
                        // Usergrade modelGrade = userMgr.GetModel(userid.ToGuid().Value);
                        DateTime dtNow = DateTime.Now;
                        bool isSau = IsSatuDay(dtNow.Year, dtNow.Month, dtNow.Day);
                        if (isContinuous7 == true && isSau == true)
                        {
                            //modelGrade.publishintegral += 10;
                            //modelGrade.shareintegral += 10;
                            //modelGrade.reviewintegral += 10;
                            point = 10;
                            strMes = "1"; //strMes = "Congratulations, you have continuous attendance for a week, get 10 bonus points";
                        }

                        else
                        {
                            //modelGrade.publishintegral += 1;
                            //modelGrade.shareintegral += 1;
                            //modelGrade.reviewintegral += 1;     
                            point = 1;
                            strMes = "2"; //strMes = "Congratulations, You have signed in successfully, get 1 bonus points";

                        }
                        //userMgr.Update(modelGrade);
                        userMgr.UserQianDaoIntegralCal(userid.ToGuid().Value, point);
                        //BindDayImg(userid.ToGuid().Value.ToString());
                        return strMes;
                    }
                }
                else if (datdiff.Value == 0)
                {
                    return " You already checked-in today. Please come back tomorrow!";
                }
                return "error";
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        [AjaxPro.AjaxMethod]
        public void BindDayImg(string userid)
        {
            userQianDaoMgr mgr = new userQianDaoMgr();
            DataTable dt = mgr.GetRecentlySingDay(userid);
            if (dt == null || dt.Rows.Count == 0)
            {
                return;
            }
            DateTime signDate = Convert.ToDateTime(dt.Rows[0]["createtime"].ToString());

            TimeSpan ts = DateTime.Now.Subtract(signDate);
            int dd = ts.Days;
            //if (dd<7)
            //{
            //    int num = CaculateWeekDay2(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string dateStr = dt.Rows[i]["createtime"].ToString();
                DateTime time = Convert.ToDateTime(dateStr);
                if (IsInSameWeek(time, DateTime.Now))
                {
                    int year = time.Year;
                    int month = time.Month;
                    int day = time.Day;
                    CaculateWeekDay(year, month, day);
                }

            }

            //}           

        }


        /// 基姆拉尔森计算公式计算日期
        /// </summary>
        /// <param name="y">年</param>
        /// <param name="m">月</param>
        /// <param name="d">日</param>
        /// <returns>星期几</returns>   
        protected string CaculateWeekDay(int y, int m, int d)
        {
            if (m == 1 || m == 2)
            {
                m += 12;
                y--;         //把一月和二月看成是上一年的十三月和十四月，例：如果是2004-1-10则换算成：2003-13-10来代入公式计算。
            }
            int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400) % 7;
            string weekstr = "";
            switch (week)
            {
                case 6: weekstr = "/Home/Images/sun.png"; if (img1 != null) img1.Src = "/Home/Images/sun.png"; break;//星期日
                case 0: weekstr = "/Home/Images/mon.png"; if (img2 != null) img2.Src = "/Home/Images/mon.png"; break;//星期一
                case 1: weekstr = "/Home/Images/tue.png"; if (img3 != null) img3.Src = "/Home/Images/tue.png"; break;//星期二
                case 2: weekstr = "/Home/Images/wed.png"; if (img4 != null) img4.Src = "/Home/Images/wed.png"; break;//星期三
                case 3: weekstr = "/Home/Images/thu.png"; if (img5 != null) img5.Src = "/Home/Images/thu.png"; break;//星期四
                case 4: weekstr = "/Home/Images/fri.png"; if (img6 != null) img6.Src = "/Home/Images/fri.png"; break;//星期五
                case 5: weekstr = "/Home/Images/sat.png"; if (img7 != null) img7.Src = "/Home/Images/sat.png"; break;//星期六

            }
            return weekstr;
        }

        /// <summary>
        /// 判断是否是周六
        /// </summary>
        /// <param name="y"></param>
        /// <param name="m"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        protected bool IsSatuDay(int y, int m, int d)
        {
            if (m == 1 || m == 2)
            {
                m += 12;
                y--;         //把一月和二月看成是上一年的十三月和十四月，例：如果是2004-1-10则换算成：2003-13-10来代入公式计算。
            }
            int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400) % 7;
            if (week == 5)
            {
                return true;
            }
            return false;
        }

        /// 基姆拉尔森计算公式计算日期
        /// </summary>
        /// <param name="y">年</param>
        /// <param name="m">月</param>
        /// <param name="d">日</param>
        /// <returns>星期几</returns>   
        protected int CaculateWeekDay2(int y, int m, int d)
        {
            if (m == 1 || m == 2)
            {
                m += 12;
                y--;         //把一月和二月看成是上一年的十三月和十四月，例：如果是2004-1-10则换算成：2003-13-10来代入公式计算。
            }
            int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400) % 7;
            string weekstr = "";
            int num = 0;
            switch (week)
            {
                case 0: weekstr = "星期一"; num = 6; break;
                case 1: weekstr = "星期二"; num = 5; break;
                case 2: weekstr = "星期三"; num = 4; break;
                case 3: weekstr = "星期四"; num = 6; break;
                case 4: weekstr = "星期五"; num = 2; break;
                case 5: weekstr = "星期六"; num = 1; break;
                case 6: weekstr = "星期日"; num = 7; break;
            }
            return num;
        }
        /// <summary>
        /// 判断是否在同一周
        /// </summary>
        /// <param name="dtS"></param>
        /// <param name="dtE"></param>
        /// <returns></returns>
        private bool IsInSameWeek(DateTime dtS, DateTime dtE)
        {
            //return ((dtE - new DateTime(1752, 12, 31)).Ticks / (7 * 24 * 60 * 60 * 10000000L) == (dtS - new DateTime(1752, 12, 31)).Ticks / (7 * 24 * 60 * 60 * 10000000L));

            return ((dtE - new TimeSpan(Convert.ToInt32(dtE.DayOfWeek), 0, 0, 0) - dtE.TimeOfDay) == (dtS - new TimeSpan(Convert.ToInt32(dtS.DayOfWeek), 0, 0, 0) - dtS.TimeOfDay));
        }
    }
}