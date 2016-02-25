using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twee.Mgr;
using System.Data;
using AjaxPro;



    public class AjaxSlotMachine
    {
        [AjaxPro.AjaxMethod()]
        public void SlotMachineUpdateCredit(int _currentCredit)
        {
            //写SlotMachine 流水表？
        }
        [AjaxPro.AjaxMethod()]
        public int SlotMachineCheckCredit()
        {
            int iRet = 1;

            /*
            UserGradeCalMgr gradeCal = new UserGradeCalMgr();
            //Twee.Model.Usergrade userGrade = gradeCal.GetModel(userGuid.Value);
            DataTable dt = gradeCal.GetUserGrade(userGuid.Value);
           // _share_points = dt.Rows[0]["shareintegral"].ToString();



            //
            int iPoint = Int32.Parse(_share_points);
            if (iPoint < 60)
            {

                return 0;
            }*/
            return iRet;

        }
    }
