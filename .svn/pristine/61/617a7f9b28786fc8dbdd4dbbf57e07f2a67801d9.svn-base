using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Web;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Configuration;

namespace Twee.Comm
{
    /// <summary>
    /// 邮件类
    /// </summary>
    public static class Mailhelper
    {
        private static string strmailFrm = "service@tweebaa.com";
        private static string strmailHost = "smtp.gmail.com";
        private static string strmailPwd = "netx1170";

        public static bool SendMail(string mailsubject, string mailbody, string mailto)
        {           

            try
            {
                #region for qq
                //SmtpClient client = new SmtpClient(strmailHost);
                ////client.Port = 587;
                ////client.Port = 465;
                ////client.Port = 465;
                ////client.EnableSsl = false;
                //string mailFrom = strmailFrm; ;
                //client.Credentials = new NetworkCredential(mailFrom, strmailPwd);
                //MailMessage mail = new MailMessage();
                //mail.From = new MailAddress(mailFrom, "Tweebaa");
                //mail.To.Add(mailto);
                ////mail.CC.Add("827090105@qq.com");
                //mail.Priority = MailPriority.High;
                //mail.Subject = mailsubject;
                //mail.Body = mailbody;
                //mail.IsBodyHtml = true;
                //client.Send(mail);
                //client.Dispose();
                //return true;
                #endregion

                #region gmail
                SmtpClient client = new SmtpClient(strmailHost);
                client.Port = 587;
                client.EnableSsl = true;
                string mailFrom = strmailFrm; ;
                client.Credentials = new NetworkCredential(mailFrom, strmailPwd);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(mailFrom, "Tweebaa");
                mail.To.Add(mailto);
                // mail.CC.Add("827090105@qq.com");
                mail.Priority = MailPriority.Normal;
                mail.Subject = mailsubject;
                mail.Body = mailbody;
                mail.IsBodyHtml = true;
                client.Send(mail);
                return true;
                #endregion

                #region ali
                //SmtpClient client = new SmtpClient(strmailHost);
                //client.Port = 465;
                //client.EnableSsl = true;
                //string mailFrom = strmailFrm; ;
                //client.Credentials = new NetworkCredential(mailFrom, strmailPwd);
                //MailMessage mail = new MailMessage();
                //mail.From = new MailAddress(mailFrom, "Tweebaa");
                //mail.To.Add(mailto);
                //// mail.CC.Add("827090105@qq.com");
                //mail.Priority = MailPriority.Normal;
                //mail.Subject = mailsubject;
                //mail.Body = mailbody;
                //mail.IsBodyHtml = true;
                //client.Send(mail);
                //return true;
                #endregion

                #region zoho
                //SmtpClient client = new SmtpClient(strmailHost);
                //client.Port = 465;
                //client.EnableSsl = true;
                //string mailFrom = strmailFrm; ;
                //client.Credentials = new NetworkCredential(mailFrom, strmailPwd);
                //MailMessage mail = new MailMessage();
                //mail.From = new MailAddress(mailFrom, "Tweebaa Services");
                //mail.To.Add(mailto);
                //// mail.CC.Add("827090105@qq.com");
                //mail.Priority = MailPriority.Normal;
                //mail.Subject = mailsubject;
                //mail.Body = mailbody;
                //mail.IsBodyHtml = true;
                //client.UseDefaultCredentials = false;
                ////通过网络发送到Smtp服务器
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.Send(mail);
                //return true;
                #endregion
            }
            catch (Exception ex)
            {
                CommHelper.WrtLog(" mailsubject=" + mailsubject + " mailbody=" + mailbody + " mailto=" + mailto +" error="+ ex.Message.ToString());
                return false;
            }
        }

        public static bool SendMail(string mailsubject, string mailbody, string mailto, string attachmentfilename)
        {
            try
            {
                SmtpClient client = new SmtpClient(strmailHost);
                client.Port = 587;
                client.EnableSsl = true;
                string mailFrom = strmailFrm; ;
                client.Credentials = new NetworkCredential(mailFrom, strmailPwd);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(mailFrom, "Tweebaa");
                mail.To.Add(mailto);
                mail.Priority = MailPriority.Normal;
                mail.Subject = mailsubject;
                mail.Body = mailbody;
                mail.IsBodyHtml = true;
                mail.Attachments.Add(new Attachment(attachmentfilename));
                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                CommHelper.WrtLog(" mailsubject=" + mailsubject + " mailbody=" + mailbody + " mailto=" + mailto + " attachment=" + attachmentfilename + " error=" + ex.Message.ToString());
                return false;
            }
        }

        
        #region
        public static void SendRegEmail(string stremail, string strguid,string username)
        {
            string webAppDomain = System.Configuration.ConfigurationManager.AppSettings["webAppDomain"].ToString();
           // string activeurl = System.Configuration.ConfigurationManager.AppSettings["webAppDomain"].ToString() + "User/userActivation.htm?id=" + HttpContext.Current.Server.UrlEncode(strguid);
            //Modify by Long for mobile App Registration
            string activeurl = "https://www.tweebaa.com/User/userActivation.htm?id=" + HttpContext.Current.Server.UrlEncode(strguid);
            ArrayList a = new ArrayList();
            a = ReadHtmlFile("registerEmail.htm", new string[4] { "#useremail#," + stremail, "#activeurl#," + activeurl, "#url#," + webAppDomain , "#userename#,"+username });
            SendMail(a[0].ToString(), a[1].ToString(), stremail);
        }

        public static void SendOrderConfirmationEmail(string stremail, string orderNo, string txt_shipping_details, string txt_order_extra, string txt_order_total,string strUserName,string strPaymentMethod)
        {
            /*
            string webAppDomain = System.Configuration.ConfigurationManager.AppSettings["webAppDomain"].ToString();
            string activeurl = System.Configuration.ConfigurationManager.AppSettings["webAppDomain"].ToString() + "User/userActivation.htm?id=" + HttpContext.Current.Server.UrlEncode(strguid);
            */

           
             ArrayList a = new ArrayList();
             string sDate = System.DateTime.Now.ToShortDateString();
             a = ReadHtmlFile("OrderConfirmation.htm", new string[7]{ "#order_number#," + orderNo, 
                                                                        "#useremail#," + strUserName,
                                                                        "#order_date#," + sDate, 
                                                                        "#order_details#," + txt_order_total,
                                                                        "#order_extra#," + txt_order_extra,
                                                                        "#shipping_address#,"+txt_shipping_details,
                                                                        "#payment_method#,"+strPaymentMethod
             });
             //CommHelper.WrtLog("sending e-mail ..." + a[1].ToString());
            SendMail(a[0].ToString(), a[1].ToString(), stremail);

            //send e-mail to store owner
            SendMail(a[0].ToString(), a[1].ToString(), "service@tweebaa.com");
        }
        public static void SendActiveEmail(string stremail)
        {
            ArrayList a = new ArrayList();
            a = ReadHtmlFile("activeuser.htm", new string[1] { "#useremail#," + stremail });
            SendMail(a[0].ToString(), a[1].ToString(), stremail);
        }
        //public static void SendFindPassEmail(string stremail, string strguid)
        //{
        //    string activeurl = System.Configuration.ConfigurationManager.AppSettings["rootUrl"].ToString() + "resetpassword/" + HttpContext.Current.Server.UrlEncode(strguid);
        //    ArrayList a = new ArrayList();
        //    a = ReadHtmlFile("findpassword.htm", new string[2] { "#useremail#," + stremail, "#url#," + activeurl });
        //    SendMail(a[0].ToString(), a[1].ToString(), stremail);
        //}
        /// <summary>
        /// 找回密码邮件通知
        /// </summary>
        /// <param name="stremail"></param>
        /// <param name="strguid"></param>
        public static bool SendFindPassEmail(string username,string stremail, string strguid)
        {
            string webAppDomain = System.Configuration.ConfigurationManager.AppSettings["webAppDomain"].ToString();
            string activeurl = System.Configuration.ConfigurationManager.AppSettings["rootUrl"].ToString() + "User/resetpwd3.aspx?id=" + HttpContext.Current.Server.UrlEncode(strguid) + "&type=email";
            ArrayList a = new ArrayList();
            a = ReadHtmlFile("resetPwdEmail.htm", new string[4] { "#useremail#," + stremail, "#activeurl#," + activeurl, "#url#," + webAppDomain, "#username#," + username });
            bool b = SendMail(a[0].ToString(), a[1].ToString(), stremail);
            return b;
        }
        public static void SendAddPrd(string strGuid)
        {
            string s = "select email from dbo.wn_user u left join dbo.wn_prd p on u.guid=p.userGuid where p.prdGuid='" + strGuid + "'";
            string stremail = DbHelperSQL.GetSingle(s).ToString();
            string activeurl = System.Configuration.ConfigurationManager.AppSettings["rootUrl"].ToString() + "reviewproduct/" + HttpContext.Current.Server.UrlEncode(strGuid);
            ArrayList a = new ArrayList();
            a = ReadHtmlFile("addprd.htm", new string[2] { "#useremail#," + stremail, "#url#," + activeurl });
            SendMail(a[0].ToString(), a[1].ToString(), stremail);
        }
        /// <summary>
        /// 评审成功后，发邮件给主人
        /// </summary>
        /// <param name="strGuid"></param>
        public static void SendReviewproduct(string prdid)
        {
            string s = "select email from dbo.wn_user u left join dbo.wn_prd p on u.guid=p.userGuid where p.idx='" + prdid + "'";
            string stremail = DbHelperSQL.GetSingle(s).ToString();
            string activeurl = System.Configuration.ConfigurationManager.AppSettings["rootUrl"].ToString() + "reviewproduct/" + HttpContext.Current.Server.UrlEncode(prdid);
            ArrayList a = new ArrayList();
            a = ReadHtmlFile("reviewproduct.htm", new string[2] { "#useremail#," + stremail, "#url#," + activeurl });
            SendMail(a[0].ToString(), a[1].ToString(), stremail);
        }

        public static void SendExchangeEmail(string stremail, int intRes)
        {
            string strUrl = System.Configuration.ConfigurationManager.AppSettings["rootUrl"].ToString();
            string strTitle = "提现成功!";
            if (intRes == 5) strTitle = "提现拒绝";
            System.Text.StringBuilder strCont = new System.Text.StringBuilder();
            strCont.Append(" <div style='margin-left: 31px; margin-top: 14px; font-size: 16px; line-height: 20px;vertical-align: middle;'>"
                          + "<p><img src='" + strUrl + "en/skin1/img/email_log.gif' style='height: 70px; width: 203px;'/></p>"
                          + "<div>"
                          + "<p>  Hi (" + stremail + ") , </p>"
                          + "<p>Welcome to Tweebaa!</p>"
                          + "<p>"
                          + "  Thank you so much for your enthusiastic participation . We feel so"
                          + "  <br />"
                          + "  honored to have you in our Tweebaa family!"
                          + " </p>"
                          + " <p class='lastNode'>"
                          + " To activate your account, please click Activate account."
                          + " </p>"
                          + " <a style='display: block; color: #fff; font-size: 18px; background-color: #00B6EE; padding: 10px; width: 90px; text-align: center; font-weight: bold;' href='" + strUrl + "emailactive/'>Activate</a>"
                          + " <p class='lastNode' style='margin-top: 27px;'>"
                          + "   Cheers,<br />"
                          + "    Tweebaa team"
                          + " </p>"
                          + " <div style='margin-top: 62px; margin-bottom: 10px; font-size: 1px; background-color: #949494; width: 644px; height: 1px; overflow: hidden;'>"
                          + "   &nbsp;"
                          + " </div>"
                          + " <p style='font-weight: bold;'>"
                          + "   If you&rsquo;re experiencing difficulty with the link, please copy and paste the"
                          + "  link from the<br />"
                          + "   email into your browser&rsquo;s navigation bar instead."
                          + "  </p>"
                          + " <p>"
                          + strUrl + "emailactive"
                          + " </p>"
                          + "<p style=' font-size: 14px;'>"
                          + "  &copy; 2014 Tweebaa Inc., 3601 Hwy 7 East, HSBC Tower, Suite 302, Markham, ON L3R"
                          + " 0M3, Canada"
                          + " </p>"
                          + " </div>"
                          + "<br><br><br><br></div>");
            Mailhelper.SendMail(strTitle, strCont.ToString(), stremail);
        }

        /// <summary>
        /// 付款成功后，发email
        /// </summary>
        /// <param name="strOrderGuid"></param>
        public static void SendPaySucess(string strOrderGuid)
        {
            string s = "select email from dbo.wn_user u  where u.guid='" + strOrderGuid + "'";
            string stremail = DbHelperSQL.GetSingle(s).ToString();
            string activeurl = System.Configuration.ConfigurationManager.AppSettings["rootUrl"].ToString() + "order/detail/" + HttpContext.Current.Server.UrlEncode(strOrderGuid);
            ArrayList a = new ArrayList();
            a = ReadHtmlFile("paysucess.htm", new string[2] { "#useremail#," + stremail, "#url#," + activeurl });
            SendMail(a[0].ToString(), a[1].ToString(), stremail);
        }

        /// <summary>
        /// 绑定邮箱
        /// </summary>
        /// <param name="strguid"></param>
        /// <param name="stremail"></param>
        public static void SendUpdateEmail(string strguid, string stremail)
        {
            string url = System.Configuration.ConfigurationManager.AppSettings["webAppDomain"].ToString()
                + "User/updateEmail.aspx?id="
                + HttpContext.Current.Server.UrlEncode(strguid) + "&email=" + stremail;
            ArrayList a = new ArrayList();

            //get user name, modify by Long base on #issue 40
            string s = "select username from dbo.wn_user u  where u.guid='" + strguid + "'";
            string strUsername = DbHelperSQL.GetSingle(s).ToString();

            a = ReadHtmlFile("updateEmail.htm", new string[2] { "#Username#," + strUsername, "#url#," + url });
            SendMail(a[0].ToString(), a[1].ToString(), stremail);
        }
        #endregion

        /// <summary>
        /// 读取HTML文件
        /// </summary>
        /// <param name="temp">HttpContext.Current.Server.MapPath("./lucklist/Main.html");</param>
        /// <returns></returns>
        private static ArrayList ReadHtmlFile(string filename, string[] ReplaceString)
        {
            ArrayList lst = new ArrayList();
            string temp = System.Web.HttpContext.Current.Server.MapPath("~") + @"/User/" + filename;
            StreamReader sr = null;
            string str = "";
            try
            {
                sr = new StreamReader(temp, Encoding.GetEncoding("UTF-8"));
                str = sr.ReadToEnd(); // 读取文件 
                foreach (string RepString in ReplaceString)
                {
                    string[] data = RepString.Split(',');
                    if (data.Length > 1)
                    {
                        //data[0]为#Select3
                        //data[1]为替换字段 
                        if (data.Length == 2)
                        {
                            str = str.Replace(data[0], data[1]);
                        }
                        else
                        {
                            //Modify by Long 11/16/2015 如果data里面有","，则会出错
                            string strReplace = "";
                            for (int k = 1; k < data.Length; k++)
                            {
                                strReplace = strReplace + data[k];
                            }
                            str = str.Replace(data[0], strReplace);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                CommHelper.WrtLog(exp.Message);
            }
            finally
            {
                sr.Dispose();
                sr.Close();
            }
            string title = Regex.Match(str, @"<title>[^<]*</title>").Value;
            lst.Add(title.Replace("<title>", "").Replace("</title>", ""));
            lst.Add(str);
            return lst;
        }

        /// <summary>
        /// 后台产品状态发生变化时发送邮件方法
        /// </summary>
        /// <param name="htmlTemplePath"></param>
        /// <param name="emailTitle"></param>
        /// <param name="userEmail"></param>
        /// <param name="proNames"></param>
        /// <param name="replaceDic"></param>
        public static void SendMailForProductStatus(string htmlTemplePath, string emailTitle,string userEmail, Dictionary<string, string> replaceDic)
        {
                StreamReader sr = new StreamReader(htmlTemplePath, Encoding.Default);
                StringBuilder str = new StringBuilder();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    str.Append(line.ToString());
                }
                sr.Dispose();
                string htmlContent = str.ToString();
                if (replaceDic != null && replaceDic.Count > 0)
                {
                    foreach (var item in replaceDic)
                    {
                        htmlContent = htmlContent.Replace(item.Key, item.Value);
                    }
                }
                Twee.Comm.Mailhelper.SendMail(emailTitle, htmlContent, userEmail);
        }


    }
}
