using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twee.Comm;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using Twee.Mgr;

namespace TweebaaWebApp.mobileApp
{
    /// <summary>
    /// Summary description for UCAPI
    /// </summary>
    public class UCAPI : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            //action=login&username="+sUsername+"&Passwrod="+sPasswrod

            String sAction = context.Request.Form["action"];
            if(sAction.Equals("login")){
                //Do Login
                String sUsername = context.Request.Form["username"];
                String sPass = context.Request.Form["Passwrod"];

                sPass = PasswordHelper.ToUpMd5(sPass);
                Twee.Mgr.UserMgr mgr = new Twee.Mgr.UserMgr();
                string resu = mgr.UserLogin(sUsername, sPass);

                JObject json = JObject.Parse(resu); //"{email:'" + email + "',userGuid:'" + userGuid + "'}";  
                string email = json["email"].ToString();
                string state = json["state"].ToString();
                string userGuid = json["userGuid"].ToString();
                context.Response.Clear();
                XElement xml = new XElement("mobileAppLogin");
                //XElement subXml = new XElement("template");
                
                if (state == "0")
                {
                    XElement XmlError = new XElement("error", "0");
                    //context.Response.Write("0");
                    
                    xml.Add(XmlError);
                    XElement XmlUserGuid = new XElement("UserGuid", userGuid);
                    xml.Add(XmlUserGuid);
                    context.Response.Write(xml);
                    return;
                }
                if (!string.IsNullOrEmpty(userGuid) && !string.IsNullOrEmpty(email))
                {
                    CookiesHelper cook = new CookiesHelper();
                    bool b1 = cook.createCookie("jZvJvvjqCILHX7zjBWskQA", userGuid, 30);
                    bool b2 = cook.createCookie("jZvJvvjqCILHX7zjBWskQB", email, 30);
                    bool b3 = cook.createCookie("jZvJvvjqCILHX7zjBWskQC", sPass, 1);
                    if (b1 && b2)
                    {
                        //context.Response.Write("1");
                    }
                    else
                    {
                       // context.Response.Write("1");
                    }
                    XElement XmlError = new XElement("error", "0");
                    //context.Response.Write("0");

                    xml.Add(XmlError);
                    XElement XmlUserGuid = new XElement("UserGuid", userGuid);
                    xml.Add(XmlUserGuid);
                    context.Response.Write(xml);
                   
                }
                else
                {
                    if (sUsername.Length > 3 && sUsername.Substring(0, 3).Equals("fb_"))
                    {
                        //this is facebook
                        XElement XmlError = new XElement("error", "2");
                        xml.Add(XmlError);
                        context.Response.Write(xml);
                    }
                    else if (sUsername.Length > 8 && sUsername.Substring(0, 8).Equals("twitter_"))
                    {

                        XElement XmlError = new XElement("error", "2");
                        xml.Add(XmlError);
                        context.Response.Write(xml);
                    }
                    else
                    {
                        XElement XmlError = new XElement("error", "1");
                        xml.Add(XmlError);
                        context.Response.Write(xml);
                    }

                    //context.Response.Write("0");
                }     
            }
            if (sAction.Equals("register"))
            {
                String sUsername = context.Request.Form["username"];
                String sPass = context.Request.Form["Passwrod"];
                String sEMail = context.Request.Form["e_mail"];

                //DO Register for mobile App


                string email = sEMail;// Request["Email"].ToString();
                string loginName = sUsername;// Request["LoginName"].ToString();
                string pass = sPass;// Request["Pass"].ToString();
                string country = "1";// Request["Country"].ToString();
                string tuijieEmail = "";// Request["TuiJieEmail"].ToString();
                string KnowWay = "99";// Request["KnowWay"].ToString();
                string Consent = "1";


                XElement xml = new XElement("mobileAppRegister");
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
                string resu = userMgr.RegUserNoActivation(loginName, user.email, user.phone, pass, country.ToInt(), user.knowwayid, user.tuijieEmail, (bool)user.consent);//{it:'1',strLoginGuid:'345a26d4-4dc3-4d36-a6ca-6b40ec9ed26d'}
                context.Response.Clear();
                JObject json = JObject.Parse(resu);
                string it = json["it"].ToString();
                if (it == "-1")
                {
                    XElement XmlError = new XElement("error", "-1");
                    xml.Add(XmlError);
                    context.Response.Write(xml);
                    //Response.Write(-1);//该邮箱已经注册过
                    return;
                }
                else if (it == "1" && json["strLoginGuid"].ToString() != "")
                {
                    //注册成功
                    string userGuid = json["strLoginGuid"].ToString();
                    bool b = AddGrade(userGuid.ToGuid().Value, user.email);
                    if (b == true)
                    {
                        //Response.Write(1);//注册成功并且添加会员等级信息成功
                        XElement XmlError = new XElement("error", "0");
                        xml.Add(XmlError);
                        XElement XmlUserGuid = new XElement("UserGuid", userGuid);
                        xml.Add(XmlUserGuid);
                        context.Response.Write(xml);
                        return;
                    }
                    else
                    {
                        XElement XmlError = new XElement("error", "-2");
                        xml.Add(XmlError);
                        context.Response.Write(xml);
                    }
                }
                else
                {
                    XElement XmlError = new XElement("error", "-2");
                    xml.Add(XmlError);
                    context.Response.Write(xml);
                }
            }
            if (sAction.Equals("save_ranking"))
            {
                String sUsername = context.Request.Form["username"];
                String sGametype = context.Request.Form["gametype"];
                String sScore = context.Request.Form["score"];
                Twee.Mgr.MobileAppGameRankingMgr mgr = new MobileAppGameRankingMgr();
                int iRet=mgr.AddGameScore(short.Parse(sGametype), sUsername, int.Parse(sScore));
                context.Response.Write(iRet);
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
            grade.shareintegral = 0;
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}