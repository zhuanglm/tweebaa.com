using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using Twee.Model;
using Twee.Comm;
using System.Data;
using AjaxPro;

namespace TweebaaWebApp.Home
{
    public partial class Home2 : System.Web.UI.Page
    {
        public string _qiaoDaoUserid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(Home2));
            if (!IsPostBack)
            {               
                Guid? userGuid = Twee.Comm.CommUtil.IsLogion();
                _qiaoDaoUserid = userGuid.Value.ToString();

                //等级
                UserGradeCalMgr gradeCal = new UserGradeCalMgr();
                //Twee.Model.Usergrade userGrade = gradeCal.GetModel(userGuid.Value);
                DataTable dt = gradeCal.GetUserGrade(userGuid);


               // strSql.Append(" select u.[userguid],u.[publishgrade],u.[publishintegral],u.[publishcount],u.[reviewgrade],u.[reviewintegral],u.[reviewhcount],u.[sharegrade] ,u.[shareintegral],u.[sharecount],u.[updatetime],p.commissionratio pratio,r.commissionratio1 rratio1,r.commissionratio2 rratio2 ,r.commissionratio3 rratio3,s.commissionratio sratio");
                int iPublishLevel = Int32.Parse(dt.Rows[0]["publishgrade"].ToString());
                int iReviewLevel = Int32.Parse(dt.Rows[0]["reviewgrade"].ToString());
                string s = dt.Rows[0]["sharegrade"].ToString();
                if (s.Length < 1) s = "0";
                int iShareLevel = Int32.Parse(s);
                if (iPublishLevel == 0) iPublishLevel = 1;
                if (iReviewLevel == 0) iReviewLevel = 1;
                if (iShareLevel == 0) iShareLevel = 1;

//                labSubLevel.Text = dt.Rows[0]["publishgrade"].ToString();
//                labEvaluateLevel.Text = dt.Rows[0]["reviewgrade"].ToString();
//                labShareLevel.Text = dt.Rows[0]["sharegrade"].ToString();
                labSubLevel.Text = iPublishLevel.ToString();
                labEvaluateLevel.Text = iReviewLevel.ToString();
                labShareLevel.Text = iShareLevel.ToString();

                labSubPoint.Text = dt.Rows[0]["publishintegral"].ToString();
                labEvaluatePoint.Text = dt.Rows[0]["reviewintegral"].ToString();
                labSharePoint.Text = dt.Rows[0]["shareintegral"].ToString();

    
                labSubRat.Text = "0."+dt.Rows[0]["pratio"].ToString()+"%";
                labEvaluateRat.Text = "0." + dt.Rows[0]["rratio1"].ToString() + "%";
                //labShareRat.Text = "0." + dt.Rows[0]["sratio"].ToString() + "%";
                labShareRat.Text =  dt.Rows[0]["sratio"].ToString().ToDecimal()/10 + "%";


                BindDayImg(userGuid.ToString());
                //labSubLevel.Text = userGrade.publishgrade.ToString();
                //labEvaluateLevel.Text = userGrade.reviewgrade.ToString();
                //labShareLevel.Text = userGrade.sharegrade.ToString();

                //labSubPoint.Text = userGrade.publishintegral.ToString();
                //labEvaluatePoint.Text = userGrade.reviewintegral.ToString();
                //labSharePoint.Text = userGrade.shareintegral.ToString();

                
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
                        int point=1;
                       // Usergrade modelGrade = userMgr.GetModel(userid.ToGuid().Value);
                        DateTime dtNow = DateTime.Now;
                        bool isSau = IsSatuDay(dtNow.Year, dtNow.Month, dtNow.Day);
                        if (isContinuous7 == true && isSau == true)
                        {
                            //modelGrade.publishintegral += 10;
                            //modelGrade.shareintegral += 10;
                            //modelGrade.reviewintegral += 10;
                            point=10;
                            strMes = "1"; //strMes = "Congratulations, you have continuous attendance for a week, get 10 bonus points";
                        }

                        else
                        {
                            //modelGrade.publishintegral += 1;
                            //modelGrade.shareintegral += 1;
                            //modelGrade.reviewintegral += 1;     
                            point=1;
                            strMes = "2"; //strMes = "Congratulations, You have signed in successfully, get 1 bonus points";
                           
                        }                      
                        //userMgr.Update(modelGrade);
                        userMgr.UserQianDaoIntegralCal(userid.ToGuid().Value,point);
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
            if (dt==null||dt.Rows.Count==0)
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
                    if (IsInSameWeek(time,DateTime.Now))
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
                case 6: weekstr = "Images/sun.png"; if (img1 != null) img1.Src = "Images/sun.png"; break;//星期日
                case 0: weekstr = "Images/mon.png"; if (img2 != null) img2.Src = "Images/mon.png"; break;//星期一
                case 1: weekstr = "Images/tue.png"; if (img3 != null) img3.Src = "Images/tue.png"; break;//星期二
                case 2: weekstr = "Images/wed.png"; if (img4 != null) img4.Src = "Images/wed.png"; break;//星期三
                case 3: weekstr = "Images/thu.png"; if (img5 != null) img5.Src = "Images/thu.png"; break;//星期四
                case 4: weekstr = "Images/fri.png"; if (img6 != null) img6.Src = "Images/fri.png"; break;//星期五
                case 5: weekstr = "Images/sat.png"; if (img7 != null) img7.Src = "Images/sat.png"; break;//星期六
                
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
            if (week==5)
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
        private  bool IsInSameWeek(DateTime dtS, DateTime dtE)
        {              
            //return ((dtE - new DateTime(1752, 12, 31)).Ticks / (7 * 24 * 60 * 60 * 10000000L) == (dtS - new DateTime(1752, 12, 31)).Ticks / (7 * 24 * 60 * 60 * 10000000L));

            return ((dtE - new TimeSpan(Convert.ToInt32(dtE.DayOfWeek), 0, 0, 0) - dtE.TimeOfDay) == (dtS - new TimeSpan(Convert.ToInt32(dtS.DayOfWeek), 0, 0, 0) - dtS.TimeOfDay)); 
        }
    }
}