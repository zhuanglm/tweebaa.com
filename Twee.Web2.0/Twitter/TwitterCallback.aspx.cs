﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitterizer;
using Twee.Mgr;
using System.Data;
using Twee.Comm;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TweebaaWebApp2.Twitter
{
    public partial class TwitterCallback : System.Web.UI.Page
    {
        public static string consumerKey = "DCLGWLbqMtsf7sPP1bj4vaeQ6";
        public static string consumerSecret = "E6mE6PWaRTcZn4tAyYqegAinmnFj3bYxJWJzFU671sUoca42LX";

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * Oauth_token=xxx & oauth_verifier=xxx
             */
            /*
            OAuthTokenResponse accessTokenResponse = OAuthUtility.GetAccessTokenDuringCallback(consumerKey, consumerSecret);
            AccessTokenLabel.Text = accessTokenResponse.Token;
            AccessSecretLabel.Text = accessTokenResponse.TokenSecret;
            ScreenNameLabel.Text = accessTokenResponse.ScreenName;
            UserIdLabel.Text = accessTokenResponse.UserId.ToString();
             * */
            OAuthTokenResponse accessTokenResponse = OAuthUtility.GetAccessToken(consumerKey, consumerSecret,
                                                                                 Request.QueryString["oauth_token"],
                                                                                 Request.QueryString["oauth_verifier"]);

            //Twee.Comm.CommHelper.WrtLog("name=" + accessTokenResponse.ScreenName + " id=" + accessTokenResponse.UserId.ToString());

            Twee.Mgr.UserMgr userMgr2 = new Twee.Mgr.UserMgr();
            string email = accessTokenResponse.UserId.ToString() + "@twitter.com";
            string screenName = accessTokenResponse.ScreenName;
            if (userMgr2.ExistsBySNSLogin(email, "101"))
            {
                //用户登录
                DoSNSLogin(email, screenName);
                Response.Redirect("/index.aspx");
            }
            else
            {
                //注册这个用户并登录
                //注册
                //这个邮箱是否存在？Twitter 拿不到EMail, 所以不用做这一步
                /*
                if (userMgr2.ExistsByEmail(email))
                {
                    //Response.Write("1");
                    DoLoginWithTweebaaAccount(email);
                    Response.Write("0");
                    return;
                }*/
                if (DoSNSRegister(email, screenName))
                {
                    //Do Login
                    DoSNSLogin(email, screenName);
                    Response.Redirect("/index.aspx");
                    return;
                }
                Response.Write("/404.aspx");
                return;
            }
        }

  private void DoSNSLogin(string sEmail, string sName)
        {

            string pass = "";
            int ii = sEmail.IndexOf("@");
            if (ii > 0)
            {
                pass = sEmail.Substring(0, ii) + "_tw_" + sName;
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
               // Response.Write("0");
                return;
            }
            if (!string.IsNullOrEmpty(userGuid) && !string.IsNullOrEmpty(email))
            {
                //CookiesHelper cook = new CookiesHelper();
                //bool b1 = cook.createCookie("jZvJvvjqCILHX7zjBWskQA", userGuid, 30);
                //bool b2 = cook.createCookie("jZvJvvjqCILHX7zjBWskQB", email, 30);
                //bool b3 = cook.createCookie("jZvJvvjqCILHX7zjBWskQC", pwd, 1);
                CommUtil.SetUserLoginCookie(userGuid, email, pwd);
                
                /*
                if (b1 && b2)
                {
                    Response.Write("0");
                }
                else
                {
                    Response.Write("0");
                }*/
            }
            else
            {
                //Response.Write("3");
            }
        }
        private bool DoSNSRegister(string sEmail, string sName)
        {
            string pass = "";
            int ii = sEmail.IndexOf("@");
            if (ii > 0)
            {
                pass = sEmail.Substring(0, ii) + "_tw_" + sName;
            }
            string email = sEmail;
            string loginName = sName;

            string country = "1"; //USA
            string tuijieEmail = "";
            string KnowWay = "101"; //Twitter
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