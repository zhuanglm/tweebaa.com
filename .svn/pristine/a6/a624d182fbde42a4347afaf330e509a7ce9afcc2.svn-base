using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using System.Data;
using AjaxPro;
using Twee.Comm;
using System.IO;

namespace TweebaaWebApp2.Games.SlotMachine
{
    public partial class index : TweebaaWebApp2.MasterPages.BasePage
    {
        private Guid? userGuid;
        public string _userid = string.Empty;
        public string _share_points = "0";

        private int iCredit = 60;
        private int MaxCount = 10;
        int[] WinningNumber={0,1,2,3,4,5,6,7,8,9,10};
      //  private int g_StopNumber = 0;
        private int g_WinnerNum = 0;
        private int g_WinnerNum2 = 0;
 /*
    'No win!',
    '5 Share Points! 1',
    '10 Share Points! 2',
    '25 Share Points! 3',
    '50 Share points! 4',
    '100 Share Points! 8',
    '150 Share Points! 10',
    'TweeBot! 12',
    'Podillow! 14',
    'ExerSeat! 16',
    'Kitty Litty! 20'*/

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(TweebaaWebApp2.Games.SlotMachine.index), this.Page);

            bool isLogion = CheckLogion(out userGuid);

            if (null != userGuid)
            {
               // _popbox = "none;";
                _userid = userGuid.ToString();
               // _share_points = _userid;
                /*
                var persent = new Twee.Mgr.UserGradeCalMgr().GetUserGrade(userGuid).Rows[0]["sratio"];
                if (null != persent && !Convert.IsDBNull(persent))
                    _persent = (((int)persent) / 1000).ToString();*/
                UserGradeCalMgr gradeCal = new UserGradeCalMgr();
                //Twee.Model.Usergrade userGrade = gradeCal.GetModel(userGuid.Value);
                DataTable dt = gradeCal.GetUserGrade(userGuid.Value);
                _share_points = dt.Rows[0]["shareintegral"].ToString();
               // _share_points = _share_points;
                /*
                string sSql = "SELECT   top 10     a.username, b.AddDate, c.SlotMachinePrizeText";
                sSql = sSql + " FROM            wn_user AS a INNER JOIN ";
                sSql = sSql + " wn_SlotMachineLucky AS b ON a.guid = b.UserGuid LEFT OUTER JOIN ";
                sSql = sSql + "  wn_SlotMachinePrize AS c ON b.SlotMachinePrizeID = c.SlotMachinePrize_ID ";
                sSql = sSql + " ORDER BY b.SlotMachinePrizeID desc,b.AddDate DESC";
                DataSet ds = DbHelperSQL.Query(sSql);
                if (ds == null || ds.Tables.Count == 0)
                {

                }
                else
                {

                    DataTable dt2 = ds.Tables[0];

                    gvwTrackingReport.DataSource = dt2;
                    gvwTrackingReport.DataBind();
                }*/
            }
            else
            {
                _userid = "";
               // _persent = "";

                //go to user login
                /*
                var response = base.Response;
                response.Redirect("/User/login.aspx?op=slot_machine");*/
            }
        

        }

        [AjaxPro.AjaxMethod]
        public int SlotMachineUpdateCredit()
        {
            //写SlotMachine 流水表？

            /* write in table wn_points */
            UserGradeCalMgr gradeCal = new UserGradeCalMgr();
           // _userid = _share_points.ToString();
            bool isLogion = CheckLogion(out userGuid);

            if (null != userGuid)
            {
                int iRet = gradeCal.SlotMachineUpdateCredit(userGuid.ToString(), iCredit);
                return iRet;
            }
            else
            {
                return -2;
            }

        }
        [AjaxPro.AjaxMethod]
        public int SlotMachineCheckCredit()
        {
            int iRet = 1;
           bool isLogion = CheckLogion(out userGuid);

           if (null != userGuid)
           {

              // if (_share_points != null && _share_points.ToString().Length > 0)
               
                   _userid = userGuid.ToString();
                   // if (userGuid == null) return -1;
                   UserGradeCalMgr gradeCal = new UserGradeCalMgr();
                   //Twee.Model.Usergrade userGrade = gradeCal.GetModel(userGuid.Value);
                   DataTable dt = gradeCal.GetUserGrade(new Guid(_userid));
                   _share_points = dt.Rows[0]["shareintegral"].ToString();



                   //
                   //return 1;
                   int iPoint = Int32.Parse(_share_points);
                   if (iPoint < iCredit)
                   {

                       return 0;
                   }
                   return iRet;
              
           }
           else
           {
               return -1;
           }

        }


        //Math.random(); 
        [AjaxPro.AjaxMethod]
        public int SlotMachineCreatRandomNumber()
        {
            Random rnd = new Random();
            int random = rnd.Next(1);

            return random;
        }
        [AjaxPro.AjaxMethod]
        public int SlotMachineCreatRandomNumberMax(int Max)
        {
            Random rnd = new Random();
            int random = rnd.Next(0, Max);

            return random;
        }
        [AjaxPro.AjaxMethod]
        public int SlotMachineCreatRandomNumberWithIndex(int Max,int index,string strItem)
        {
            int iWinnerNum = 0;
            int iRet = 0;
            string[] sItem = strItem.Split(',');

            bool isLogion = CheckLogion(out userGuid);

            if (index == 1)
            {
                Random rnd = new Random();
                int random = rnd.Next(0, 1000);
                /*
                 * 根据概率来决定Reward
                 */
                /*
        'No win!',
        '5 Share Points!',
        '10 Share Points!',
        '25 Share Points!',
        '50 Share points!',
        '100 Share Points!',
        '150 Share Points!',
        'TweeBot!',
        'Podillow!',
        'ExerSeat!',
        'Kitty Litty!'*/
                iRet = rnd.Next(0, Max);

                iRet = WinningNumber[0];
                iWinnerNum = 0;
                /*
                 * 0.01%
                 */
                /*
                1	30 Share Points	30%	30%			300/1000																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																									
                2	50 Share Points	20%	20%			200/1000																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																									
                3	100 Share Points	10%	10%		100/1000																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																										
                4	200 Share Points	5%	5%		50/1000																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																										
                5	1000 Share Points	1%	1%	    10/1000																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																											
 																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																											
                8	Kitty litty	1%	1%				10/1000																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																								
                9	Podillow	1%	0%			    10/1000																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																								
                10	Smart Watch	0.50%	0.00%		5/1000																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																										
                6	Tweebot	0.50%	0.50%		    5/1000																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																								
               7	Exerseat	0.10%	0.00%       1/1000	
                 * */

                if (random == 999)
                {
                    iRet = 0;// WinningNumber[7]; //1/1000	
                    iWinnerNum = 0;// 7;
                }
                if (random < 999 && random >= 994)  //5/1000
                {
                    iRet = 0;// WinningNumber[6];
                    iWinnerNum = 0;// 6;
                }
                if (random < 994 && random >= 990)  //5/1000
                {
                    iRet = 0;// WinningNumber[10];
                    iWinnerNum = 0; // 10;
                }

                if (random < 990 && random >= 980) //10/1000	
                {
                    iRet = 0;// WinningNumber[9];
                    iWinnerNum = 0;// 9;
                }

                if (random < 980 && random >= 970)  // 8	Kitty litty	1%	1%				10/1000	
                {
                    iRet = 0;// WinningNumber[8];
                    iWinnerNum = 0;// 8;
                }

                if (random < 970 && random >= 960) //5	1000 Share Points	1%	1%	    10/1000	
                {
                    iRet = WinningNumber[5];
                    iWinnerNum = 5;
                }
                if (random < 960 && random >= 910) //4	200 Share Points	5%	5%		50/1000	
                {
                    iRet = WinningNumber[4];
                    iWinnerNum = 4;
                }

                if (random < 910 && random >= 810) // 3	100 Share Points	10%	10%		100/1000	
                {
                    iRet = WinningNumber[3];
                    iWinnerNum = 3;
                }
                if (random < 810 && random >= 610) // 2	50 Share Points	20%	20%			200/1000	
                {
                    iRet = WinningNumber[2];
                    iWinnerNum = 2;
                }
                if (random < 610 && random >= 310) // 1	30 Share Points	30%	30%			300/1000	
                {
                    iRet = WinningNumber[1];
                    iWinnerNum = 1;
                }
                //for test
                //iRet = WinningNumber[0];
                //check the stop number
                ///////////////
                /*
                iRet = WinningNumber[2];
                iWinnerNum = 2;*/
                /////////////////
                for (int i = 0; i < sItem.Length; i++)
                {
                    string s = sItem[i];
                    s = s.Replace("img", "");
                    int k = s.ToInt();
                    if (k == iRet)
                    {
                        iRet = i;
                        break;

                    }
                }
               // g_StopNumber = iRet;
                WriteWinningNumber(iWinnerNum, userGuid.ToString());
            }
            else
            {
                g_WinnerNum = ReadWinningNumber(userGuid.ToString());
                if (g_WinnerNum != null && g_WinnerNum.ToString().Length > 0)
                {
                    int iStop = g_WinnerNum;
                    //iRet = Session["StopNumber"].ToString().ToInt();
                    if (iStop > 0)
                    {
                        for (int i = 0; i < sItem.Length; i++)
                        {
                            string s = sItem[i];
                            s = s.Replace("img", "");
                            int k = s.ToInt();
                            if (k == iStop)
                            {
                                iRet = i;
                                break;

                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (index == 2 && i != iStop)
                            {
                                iRet = i;
                                //g_WinnerNum2 = iRet;
                                WriteWinningNumber2(iRet, userGuid.ToString());
                                break;
                            }
                            if (index == 3)
                            {
                                int k1 = ReadWinningNumber2(userGuid.ToString());
                                if (i != iStop && i != k1)
                                {
                                    iRet = i;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    iRet = 0;
                }
                
            }
            if (iRet == 0)
            {
                iRet = MaxCount - 1;//返回最后一个
            }
            else
            {
                iRet = iRet - 1;
            }
            return iRet;
        }
        [AjaxPro.AjaxMethod]
        public string SlotMachinCheckResult()
        {
/*
    if (that.items1[that.result1].id == 'gold-64') {
        ec++;
    }
    if (that.items2[that.result2].id == 'gold-64') {
        ec++;
    }
    if (that.items3[that.result3].id == 'gold-64') {
        ec++;
    }
 */
            UserGradeCalMgr gradeCal = new UserGradeCalMgr();
            bool isLogion = CheckLogion(out userGuid);
            //Twee.Model.Usergrade userGrade = gradeCal.GetModel(userGuid.Value);
            DataTable dt = gradeCal.GetUserGrade(userGuid);
            _share_points = dt.Rows[0]["shareintegral"].ToString();
            g_WinnerNum = ReadWinningNumber(userGuid.ToString());
            if (_share_points != null && _share_points.Length > 0 && g_WinnerNum != null && g_WinnerNum.ToString().Length > 0)
            {
                //判断StopNumber
                //写库
                int iWinNumber = g_WinnerNum;// int.Parse(g_WinnerNum.ToString());

                gradeCal.SlotMachineSaveLuckyWinner(userGuid.ToString(), iWinNumber);
                string s=g_WinnerNum.ToString();
/*
 更新积分
 *     '5 Share Points!',
    '10 Share Points!',
    '25 Share Points!',
    '50 Share points!',
    '100 Share Points!',
    '150 Share Points!',
 * 
 */             int iAddPoints=0;
                int OriginalPoints = int.Parse(_share_points.ToString());
                /*
  30 Share Points
50 Share Points
100 Share Points
200 Share points
1000 Share Points
Tweebot
Exerseat
Kitty Litty
Podillow
Smart Watch
                 * */
                if(iWinNumber==1){
                    iAddPoints = 30;//30 Share Points
                }
                if (iWinNumber == 2)
                {
                    iAddPoints = 50; //50 Share Points
                }
                if (iWinNumber == 3)
                {
                    iAddPoints = 100; //100 Share Points
                }
                if (iWinNumber == 4)
                {
                    iAddPoints = 200; //200 Share points
                }
                if (iWinNumber == 5)
                {
                    iAddPoints = 1000; //1000 Share Points
                }
                /*
                if (iWinNumber == 6)
                {
                    iAddPoints = 150;
                }*/
                OriginalPoints = OriginalPoints + iAddPoints;
                _share_points = OriginalPoints.ToString(); //update Session
                return s + ":" + OriginalPoints.ToString();
            }
            return "0" + ":" + _share_points.ToString();
        }

        private void WriteWinningNumber(int WinNumber,string strUserGuid)
        {
            string strFile = Server.MapPath("~/cache/") + strUserGuid + ".txt";
            File.WriteAllText(strFile, WinNumber.ToString());
        }
        private int ReadWinningNumber(string strUserGuid)
        {
            string strFile = Server.MapPath("~/cache/") + strUserGuid + ".txt";
            string sNumber = File.ReadAllText(strFile);
            return sNumber.ToInt();
        }
        private void WriteWinningNumber2(int WinNumber, string strUserGuid)
        {
            string strFile = Server.MapPath("~/cache/") + strUserGuid + "_2.txt";
            File.WriteAllText(strFile, WinNumber.ToString());
        }
        private int ReadWinningNumber2(string strUserGuid)
        {
            string strFile = Server.MapPath("~/cache/") + strUserGuid + "_2.txt";
            string sNumber = File.ReadAllText(strFile);
            return sNumber.ToInt();
        }
    }
}