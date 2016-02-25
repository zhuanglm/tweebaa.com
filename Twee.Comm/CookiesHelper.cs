using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web;

namespace Twee.Comm
{
    public class CookiesHelper
    {
        /// <summary>
        /// 读取Cookies,如果cookies已经存在，返回值，如果不存在返回null
        /// </summary>
        /// <param name="strName">Cookie 主键</param>
        /// <code>Cookie ck = new Cookie();</code>
        /// <code>ck.getCookie("主键");</code>
        public  string getCookie(string strName)
        {
            HttpCookie Cookie = System.Web.HttpContext.Current.Request.Cookies[strName];
            if (Cookie != null)
                return Cookie.Value.ToString();
            else
                return null;
        }

        /// <summary>
        /// 删除Cookies
        /// </summary>
        /// <param name="strName">Cookie 主键</param>
        /// <code>Cookie ck = new Cookie();</code>
        /// <code>ck.delCookie("主键");</code>
        public bool delCookie(string strName)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                Cookie.Expires = DateTime.Now.AddDays(-1);
                System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 创建Cookies
        /// </summary>
        /// <param name="strName">Cookie 主键</param>
        /// <param name="strValue">Cookie 键值</param>
        /// <param name="strDay">Cookie 天数</param>
        /// <code>Cookie ck = new Cookie();</code>
        /// <code>ck.setCookie("主键","键值","天数");</code>
        public bool createCookie(string strName, string strValue, double strDay)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                Cookie.Expires = DateTime.Now.AddDays(strDay);
                //Cookie.Expires = DateTime.Now.AddMinutes(1);
                Cookie.Value = strValue;
                System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 创建Cookies，设置过期时间N分
        /// </summary>
        /// <param name="strName">Cookie 主键</param>
        /// <param name="strValue">Cookie 键值</param>
        /// <param name="strDay">Cookie 分钟</param>
        /// <code>Cookie ck = new Cookie();</code>
        /// <code>ck.setCookie("主键","键值","分钟数");</code>
        public bool createCookieByMinute(string strName, string strValue, double minute)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                Cookie.Expires = DateTime.Now.AddMinutes(minute);
                Cookie.Value = strValue;
                System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
