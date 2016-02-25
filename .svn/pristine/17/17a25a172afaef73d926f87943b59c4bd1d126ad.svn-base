using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using Twee.Mgr;
using TweebaaWebApp2.MasterPages;

namespace TweebaaWebApp2.AjaxPages
{
    /// <summary>
    /// 安全设置Ajax处理方法
    /// </summary>
    public partial class homeSafeAjax : BasePage
    {
        private Guid? userGuid;
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string action = "";
        Dictionary<string, object> dic = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);
            if (isLogion == false)
            {
                Response.Write("-1");
                return;
            }
            else
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
                string info = sr.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                dic = js.Deserialize<Dictionary<string, object>>(info);
                action = dic["action"].ToString();
                if (action.Equals("query"))
                {
                    GetCurrentUser();
                }
                else if (action.Equals("modifyPhone"))
                {
                    ModifyPhone();
                }
                else if (action.Equals("modifyEmail"))
                {
                    ModifyEmail();
                }
                else if (action.Equals("modifyPwd"))
                {
                    ModifyPwd();
                }
                else if (action.Equals("updatepwd"))
                {
                    UpdatePwd();
                }
            }
        }

        private void GetCurrentUser()
        {
            // 获取当前用户邮箱
            string userEmail = new CookiesHelper().getCookie("jZvJvvjqCILHX7zjBWskQB");
            var userMgr = new UserMgr();
            var user = userMgr.GetModel(userGuid.Value, userEmail);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Response.Write(js.Serialize(user));
        }

        private void ModifyPhone()
        {
            var phone = dic["phone"].ToString();
            // 获取当前用户邮箱
            string userEmail = new CookiesHelper().getCookie("jZvJvvjqCILHX7zjBWskQB");
            var userMgr = new UserMgr();
            var user = userMgr.GetModel(userGuid.Value, userEmail);
            user.phone = phone;
            if (userMgr.Update(user))
            {
                Response.Write("1");
            }
            else
            {
                Response.Write("0");
            }
        }

        private void ModifyEmail()
        {
            try
            {
                var email = dic["email"].ToString();
                Twee.Mgr.UserMgr mgr = new Twee.Mgr.UserMgr();
                if (mgr.ExistsByEmail(email))
                {
                    Response.Write("-2");
                    return;
                }                   
                Mailhelper.SendUpdateEmail(userGuid.Value.ToString(), email);
                Response.Write("1");
            }
            catch (Exception)
            {
                Response.Write("0");
            }
        }

        private void ModifyPwd()
        {
            var pwd = dic["pwd"].ToString();
            // 获取当前用户邮箱
            string userEmail = new CookiesHelper().getCookie("jZvJvvjqCILHX7zjBWskQB");
            var userMgr = new UserMgr();
            var user = userMgr.GetModel(userGuid.Value, userEmail);
            user.pwd = pwd;
            userMgr.Update(user);

            Response.Write("1");
        }
        //会员中心修改密码
        private void UpdatePwd()
        {
            if (dic.Keys.Contains("newPwd"))
	        {
                string userEmail = new CookiesHelper().getCookie("jZvJvvjqCILHX7zjBWskQB");
                var userMgr = new UserMgr();
                var user = userMgr.GetModel(userGuid.Value, userEmail);
                 string oldPwd = dic["pwd"].ToString();
                 if (PasswordHelper.ToUpMd5(oldPwd)!=user.pwd)
                 {
                     Response.Write("2");
                     return;
                 }
	             string newPwd=dic["newPwd"].ToString();
                 UserMgr mgr = new UserMgr();
                 bool b = mgr.UpdatePwdByID(userGuid.Value.ToString(), newPwd);
                 if (b)
                 {
                     Response.Write("1");
                     return;
                 }
                 else
                 {
                     Response.Write("0");
                     return;
                 }                  
	        }
            Response.Write("0");
           
        }
    }
}