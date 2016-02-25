using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twee.Comm;
using Twee.Mgr;
using System.Configuration;

namespace TweebaaWebApp2.MasterPages
{
    public class BasePage:System.Web.UI.Page
    {
        /// <summary>
        /// 验证用户登录
        /// </summary>
        /// <returns></returns>
        protected bool CheckLogion(out Guid? userguid)
        {
            try
            {
                CookiesHelper cookie = new Twee.Comm.CookiesHelper();
                string userGuid = cookie.getCookie(ConfigurationManager.AppSettings.Get("cookieUserID"));
                string pwd = cookie.getCookie(ConfigurationManager.AppSettings.Get("cookieUserPWD"));
                userguid = null;
                if (!string.IsNullOrEmpty(userGuid) && !string.IsNullOrEmpty(pwd))
                {
                    Guid? uGuid = userGuid.ToGuid();
                    UserMgr mgr = new UserMgr();
                    bool b = mgr.CheckLogion(uGuid.Value, pwd);
                    if (b==true)
                    {
                        userguid = uGuid;
                    }                  
                    return b;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}