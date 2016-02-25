using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using Twee.Comm;
using Twee.Mgr;
using System.Data;

namespace TweebaaWebApp2.AjaxPages
{
    public partial class SNSAjax : System.Web.UI.Page
    {
        private static string action = "";
        private Guid? userGuid;
        Dictionary<string, object> dic = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
            string cartInfo = sr.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            dic = js.Deserialize<Dictionary<string, object>>(cartInfo);
            action = dic["action"].ToString();
            if (action == "BindFaceBook")
            {
                //首先检查数据库里是否存在这个用户
                string sName = dic["name"].ToString();
                string sEMail = dic["email"].ToString();
                string sID = dic["id"].ToString();
                Twee.Mgr.UserMgr userMgr2 = new Twee.Mgr.UserMgr();

                if (sEMail == "undefined" || sEMail.Length < 10)
                {
                    sEMail = sID + "@facebook.com";
                }


                if (userMgr2.ExistsBySNSLogin(sEMail,"100"))
                {
                    //用户登录
                    DoSNSLogin(sEMail, sName);
                    Response.Write("0");
                    return;
                }
                else
                {
                    //注册这个用户并登录
                    //注册
                    //这个邮箱是否存在？
                    if (userMgr2.ExistsByEmail(sEMail))
                    {
                        //Response.Write("1");
                        DoLoginWithTweebaaAccount(sEMail);
                        Response.Write("0");
                        return;
                    }
                    if (DoSNSRegister(sEMail, sName))
                    {
                        //Do Login
                        DoSNSLogin(sEMail, sName);
                        Response.Write("0");
                        return;
                    }
                    Response.Write("2");
                    return;
                }

            }
        }
        private void DoLoginWithTweebaaAccount(string sEmail)
        {
            Twee.Mgr.UserMgr mgr = new Twee.Mgr.UserMgr();
            DataTable dt = mgr.GetUserInfo4SNSLogin(sEmail);
            //CookiesHelper cook = new CookiesHelper();
            //bool b1 = cook.createCookie("jZvJvvjqCILHX7zjBWskQA", dt.Rows[0]["guid"].ToString(), 30);
            //bool b2 = cook.createCookie("jZvJvvjqCILHX7zjBWskQB", sEmail, 30);
            //bool b3 = cook.createCookie("jZvJvvjqCILHX7zjBWskQC", dt.Rows[0]["pwd"].ToString(), 1);
            CommUtil.SetUserLoginCookie(dt.Rows[0]["guid"].ToString(), sEmail, dt.Rows[0]["pwd"].ToString());
        
        }
        private void DoSNSLogin(string sEmail, string sName)
        {

            string pass = "";
            int ii = sEmail.IndexOf("@");
            if (ii > 0)
            {
                pass = sEmail.Substring(0, ii) + "_fb_" + sName;
            }
            string eamil = sEmail;
            string pwd = pass;
            pwd = PasswordHelper.ToUpMd5(pwd);
            Twee.Mgr.UserMgr mgr = new Twee.Mgr.UserMgr();
            string resu = mgr.UserLogin(eamil, pwd);

            JObject json = JObject.Parse(resu); //"{email:'" + email + "',userGuid:'" + userGuid + "'}";  
            string email = json["email"].ToString();
            string state = json["state"].ToString();
            string userGuid = json["userGuid"].ToString();
            Response.Clear();
            if (state == "0")
            {
                Response.Write("0");
                return;
            }
            if (!string.IsNullOrEmpty(userGuid) && !string.IsNullOrEmpty(email))
            {
                //CookiesHelper cook = new CookiesHelper();
                //bool b1 = cook.createCookie("jZvJvvjqCILHX7zjBWskQA", userGuid, 30);
                //bool b2 = cook.createCookie("jZvJvvjqCILHX7zjBWskQB", email, 30);
                //bool b3 = cook.createCookie("jZvJvvjqCILHX7zjBWskQC", pwd, 1);
                //if (b1 && b2)
                if (CommUtil.SetUserLoginCookie(userGuid, email, pwd))
                {
                    Response.Write("0");
                }
                else
                {
                    Response.Write("0");
                }
            }
            else
            {
                Response.Write("3");
            }        
        }
        private bool DoSNSRegister(string sEmail, string sName)
        {
            string pass = "";
            int ii = sEmail.IndexOf("@");
            if (ii > 0)
            {
                pass = sEmail.Substring(0, ii) + "_fb_" + sName;
            }
            string email = sEmail;
            string loginName = sName;
            
            string country = "1"; //USA
            string tuijieEmail = "";
            string KnowWay = "100";
            string Consent = "1";


            Twee.Model.User user = new Twee.Model.User();
            user.email = email;
            user.phone = "";
            user.username = loginName;
            user.pwd = pass;
            user.knowwayid = int.Parse(KnowWay);
            user.tuijieEmail = tuijieEmail;
            user.consent = (Consent.ToLower() == "true") ? true : false;
            //user.countryid = country.ToInt();
            Twee.Mgr.UserMgr userMgr = new Twee.Mgr.UserMgr();
            string resu = userMgr.SNSRegUser(loginName, user.email, user.phone, pass, country.ToInt(), user.knowwayid, user.tuijieEmail, (bool)user.consent);//{it:'1',strLoginGuid:'345a26d4-4dc3-4d36-a6ca-6b40ec9ed26d'}
            Response.Clear();
            JObject json = JObject.Parse(resu);
            string it = json["it"].ToString();
            if (it == "-1")
            {
                //Response.Write(-1);//该邮箱已经注册过
                return true;
            }
            else if (it == "1" && json["strLoginGuid"].ToString() != "")
            {
                //注册成功
               
                 return true;
                
            }
            else
            {
                //Response.Write(0);//注册失败
                return false;
            }

        }

        private bool AddGrade(Guid userGuid, string email)
        {
            UserGradeCalMgr gradeMgr = new UserGradeCalMgr();
            Twee.Model.Usergrade grade = new Twee.Model.Usergrade();
            grade.userguid = userGuid;
            grade.publishgrade = 0;
            grade.publishintegral = 0;
            grade.publishcount = 0;
            grade.reviewgrade = 0;
            grade.reviewintegral = 0;
            grade.reviewhcount = 0;
            grade.sharegrade = 0;
            grade.shareintegral = 50; //新注册会员给50点积分
            grade.sharecount = 0;
            grade.updatetime = DateTime.Now;
            bool b = gradeMgr.Add(grade);
            if (b == false)
            {
                Twee.Mgr.UserMgr userMgr = new Twee.Mgr.UserMgr();
                bool resu = userMgr.Delete(userGuid, email);
            }
            return b;

        }
    }
}