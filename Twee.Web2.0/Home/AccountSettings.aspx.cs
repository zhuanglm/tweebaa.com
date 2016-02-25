﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;
using Twee.Comm;
using Twee.Mgr;
using System.IO;

namespace TweebaaWebApp2.Home
{
    public partial class AccountSettings : TweebaaWebApp2.MasterPages.BasePage
    {
        private Guid? userGuid;

        private static char[] constant =   
      {   
        '0','1','2','3','4','5','6','7','8','9',  
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'   
      };

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(AccountSettings));
            bool isLogion = CheckLogion(out userGuid);
            if (isLogion == false)
            {
                Response.Write("<script type='text/javascript'>alert('please login first !');top.location='../user/login.aspx';</script>");
                return;
            }
            hidUserid.Value = userGuid.ToString();
            Bind();

            string userEmail = new CookiesHelper().getCookie("jZvJvvjqCILHX7zjBWskQB");
            var userMgr = new UserMgr();
            var user = userMgr.GetModel(userGuid.Value, userEmail);

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                string ext = Path.GetExtension(file.FileName);
                if (ext == ".jpg" || ext == ".png" || ext == ".gif" || ext == ".jpeg")
                {


                    if (!string.IsNullOrEmpty(file.FileName))
                    {
                        var directory = Server.MapPath("~/headimgs");
                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }
                        string strNow = System.DateTime.Now.ToString("HHmmss");
                        var fileName = string.Format("{0}_{1}{2}", user.username,strNow, Path.GetExtension(file.FileName));
                        var path = Path.Combine(directory, fileName);
                        file.SaveAs(path);
                        if (userMgr.UpdateHeadImg(userGuid.Value.ToString(), "~/headimgs/" + fileName))
                        {

                            //imgUserHead.ImageUrl = "../headimgs/" + fileName;

                            // imgUserHead.ImageUrl = "../headimgs/" + fileName;

                            //Response.Write("~/headimgs/" + fileName);
                        }
                        else
                        {
                            //Response.Write("0");
                        }
                    }
                }else{

                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('Please choose only .jpg, .png and .gif image types!')", true);
                    return;
                }
            }
            else
            {

                //imgUserHead.ImageUrl = user.headimg;

               // imgUserHead.ImageUrl = user.headimg;

            }
        }

        public void Bind()
        {
            var model = new Twee.Mgr.accountBind().GetModel(userGuid.ToString().Trim());
            if (model != null)
            {
                txtFirstName.Value = model.firstName;
                txtLastName.Value = model.lastName;
                txtEmail.Value = model.email;
                txtPayPalAccount.Value = model.account;
                hidUserid.Value = model.userid;
                hidAccountId.Value = model.id.ToString();
                hidOption.Value = "update";
            }
            else
            {
                hidOption.Value = "add";
                hidAccountId.Value = string.Empty;
            }

        }

        public static string NoHTML(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "",
              RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "",
              RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

        /// <summary>
        /// 生成随机验证码
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GenerateRandomNumber(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }


        [AjaxPro.AjaxMethod]
        public string GetCode(string email, string userid)
        {
            if (string.IsNullOrEmpty(email))
                return "noemail";
            string code = GenerateRandomNumber(4);
            string emailTitle = "PayPal account bind verification code ";
            string emailBody = "The PayPal account bind verification code is : " + code;
            try
            {
                Twee.Model.accountBindVerfyCode model = new Twee.Model.accountBindVerfyCode();
                model.code = code;
                model.userid = userid;
                model.createtime = DateTime.Now;
                Twee.Mgr.AccountBindVerfyCodeMgr mgr = new Twee.Mgr.AccountBindVerfyCodeMgr();
                mgr.Add(model);
                if (Twee.Comm.Mailhelper.SendMail(emailTitle, emailBody, email))
                {
                    return "emailsuccess";
                }
                else
                {
                    return "emailfail";
                }
            }
            catch (Exception ex)
            {
                return "fail";
            }
        }

        [AjaxPro.AjaxMethod]
        public string Save(string option, string userid, string firstName, string lastName, string account, string email, string code)
        {
            if (string.IsNullOrEmpty(userid))
                return "nouser";
            string _firstName = NoHTML(firstName);
            string _lastName = NoHTML(lastName);
            string _account = NoHTML(account);
            var verfyCode = new Twee.Mgr.AccountBindVerfyCodeMgr().GetLastModelByUserid(userid);
            if (null == verfyCode)
            {
                return "nodata";
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(verfyCode.code) && verfyCode.code.Trim().ToUpper() == code.ToUpper())
                    {
                        Twee.Model.accountBind acModel = new Twee.Model.accountBind();
                        acModel.userid = userid;
                        acModel.firstName = _firstName;
                        acModel.lastName = _lastName;
                        acModel.email = email;
                        acModel.account = _account;
                        acModel.status = 1;
                        acModel.createtime = DateTime.Now;
                        if (option == "add")
                        {
                            new Twee.Mgr.accountBind().Add(acModel);
                            new Twee.Mgr.AccountBindVerfyCodeMgr().Delete(verfyCode.id);
                            return "addsuccess";
                        }
                        else if (option == "update")
                        {
                            new Twee.Mgr.accountBind().Update(acModel);
                            new Twee.Mgr.AccountBindVerfyCodeMgr().Delete(verfyCode.id);
                            return "updatesuccess";
                        }
                        else
                        {
                            return "nooption";
                        }
                    }
                    else
                    {
                        return "codeerror";
                    }
                }
                catch (Exception ex)
                {
                    return "fail";
                }
            }

        }

        [AjaxPro.AjaxMethod]
        public string Unbind(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
                return "nodata";
            try
            {
                new Twee.Mgr.accountBind().UnbindAccount(id);
                return "success";
            }
            catch (Exception ex)
            {
                return "fail";
            }
        }
    }
}