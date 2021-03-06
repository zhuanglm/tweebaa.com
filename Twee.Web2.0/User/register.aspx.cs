﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;
using System.Data;
using System.Text;

namespace TweebaaWebApp2.User
{
    public partial class register : TweebaaWebApp2.MasterPages.BasePage
    {
        public string _knowWay = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(register));
            Guid? userGuid;
            bool isLogion = CheckLogion(out userGuid);
            if (null != userGuid)
            {
                Response.Redirect("/User/Logined.aspx");
                return;
            }
            if (!IsPostBack)
            {
                Twee.Mgr.CountryMgr mgr = new Twee.Mgr.CountryMgr();
                DataSet ds = mgr.GetAllList();
                if (ds != null && ds.Tables.Count > 0)
                {
                    //DataSet ds22 = new DataSet();
                    DataTable dt = new DataTable("CountryTable");
                    dt.Columns.Add(new DataColumn("id", typeof(int)));
                    dt.Columns.Add(new DataColumn("country", typeof(string)));
                    
                    DataRow dr = dt.NewRow();
                    dr["id"] = 0;
                    dr["country"] = "-- Please select your country --";
                    dt.Rows.Add(dr);

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr1 = dt.NewRow();
                        dr1["id"] = ds.Tables[0].Rows[i]["id"];
                        dr1["country"] = ds.Tables[0].Rows[i]["country"];
                        dt.Rows.Add(dr1);
                    }

                    
                    //ds22.Tables.Add(dt);

                    selectCountry.DataSource = dt;// ds.Tables[0];
                    selectCountry.DataValueField = "id";
                    selectCountry.DataTextField = "country";
                    selectCountry.DataBind();
                }

                Twee.Mgr.knowTweeWayMgr wayMgr = new Twee.Mgr.knowTweeWayMgr();
                var wayDt = wayMgr.GetModelList(string.Empty);
                StringBuilder op = new StringBuilder();
                if (wayDt != null && wayDt.Count > 0)
                {
                    foreach (var item in wayDt)
                    {
                        op.AppendFormat("<option value='{0}'>{1}</option>", item.id.ToString(), item.way);
                    }
                }
                _knowWay = "<option value='-1' selected>-- How did you find out about our website? --</option><option value='-2'>Friend</option>" + op.ToString();
            }


            #region
            //http://www.ucpaas.com/page/doc/doc_errorcode4-1.jsp  错误码
            //string serverIp = "api.ucpaas.com";
            //string serverPort = "443";
            //string account = "7c13d6c3f03d69f6a556c61f7e55be70";//用户sid
            //string token = "31d148a81daf8b3e6df2fb259749f7bf";  //用户sid对应的token

            //string appId = "2f881a1fdf3349eaa2ef3fcd52583143"; //对应的应用id，非测试应用需上线使用
            //string clientNum = "60000000000001";
            //string clientpwd = "";
            //string friendName = "";
            //string clientType = "0";
            //string charge = "0";
            //string phone = "";
            //string date = "day";
            //uint start = 0;
            //uint limit = 100;
            //string toPhone = "13684939641";  //发送短信手机号码，群发逗号区分
            //string templatedId = "1424";     //短信模板id，需通过审核
            //string param = "";               //短信参数
            //string verifyCode = "1234";
            //string fromSerNum = "4000000000";
            //string toSerNum = "4000000000";
            //string maxallowtime = "60";

            //Twee.Comm.SMSSend sms = new Twee.Comm.SMSSend();


            //查询主账号
            //sms.QueryAccountInfo();

            //申请client账号
            //sms.CreateClient(friendName, clientType, charge, phone);

            //查询账号信息(账号)
            //sms.QueryClientNumber(clientNum);

            //查询账号信息(电话号码)
            //sms.QueryClientMobile(phone);

            //查询账号列表
            //sms.GetClient(start, limit);

            //删除一个账号
            //sms.DropClient(clientNum);

            //查询应用话单
            //sms.GetBillList(date);

            //查询账号话单
            //sms.GetClientBillList(clientNum, date);

            //账号充值
            //sms.ChargeClient(clientNum, clientType, charge);

            //回拨
            //string str0 = sms.CallBack(clientNum, toPhone, fromSerNum, toSerNum, maxallowtime);

            //短信
            //string templatedId = System.Configuration.ConfigurationManager.AppSettings["templatedId"].ToString();
            //string str = sms.SendSMS("13916876548", templatedId, "1234");

            //语音验证码
            //string str2 = sms.VoiceCode("13684939641", "6688");

            #endregion
        }

        [AjaxPro.AjaxMethod]
        public string verfy(string op, string str)
        {
            Twee.Mgr.UserMgr mgr = new Twee.Mgr.UserMgr();
            string retureString = "success";
            if (op == "email")
            {
                if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(str.Trim()))
                {
                    retureString = "empty";
                }
                else
                {
                    if (mgr.ExistsByEmail(str))
                        retureString = "fail";
                }
            }
            if (op == "username")
            {
                if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(str.Trim()))
                {
                    retureString = "empty";
                }
                else
                {
                    if (mgr.ExistsByUserName(str))
                        retureString = "fail";
                }
            }
            return retureString;
        }

    }
}