using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Twee.Comm
{
    public static class PasswordHelper
    {
        /// <summary> /// 密码强度 /// </summary> 
        public enum Strength
        {
            Invalid = 0, //无效密码 
            Weak = 1,    //低强度密码   
            Normal = 2,  //中强度密码 
            Strong = 3   //高强度
        }

        /// <summary> /// 计算密码强度 /// </summary> 
        /// <param name="password">密码字符串</param> 
        /// <returns></returns> 
        public static Strength PasswordStrength(string password)
        {
            //空字符串强度值为0  
            if (password == "")
                return Strength.Invalid;
            //字符统计    
            int iNum = 0, iLtt = 0, iSym = 0;
            foreach (char c in password)
            {
                if (c >= '0' && c <= '9')
                    iNum++;
                else if (c >= 'a' && c <= 'z')
                    iLtt++;
                else if (c >= 'A' && c <= 'Z')
                    iLtt++;
                else iSym++;
            }
            if (iLtt == 0 && iSym == 0)
                return Strength.Weak; //纯数字密码   
            if (iNum == 0 && iLtt == 0)
                return Strength.Weak; //纯符号密码
            if (iNum == 0 && iSym == 0)
                return Strength.Weak; //纯字母密码 
            if (password.Length <= 6)
                return Strength.Weak;   //长度不大于6的密码 
            if (iLtt == 0) return Strength.Normal; //数字和符号构成的密码  
            if (iSym == 0) return Strength.Normal; //数字和字母构成的密码    
            if (iNum == 0) return Strength.Normal; //字母和符号构成的密码 
            if (password.Length <= 10) return Strength.Normal; //长度不大于10的密码
            return Strength.Strong; //由数字、字母、符号构成的密码 
        }

        #region  密码加密
        /**/
        /// <summary>  
        /// 转半角的函数(DBC case)   
        /// </summary>   
        /// <param name="input">任意字符串</param>   
        /// <returns>半角字符串</returns>   
        ///<remarks>   
        ///全角空格为12288，半角空格为32   
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248   
        ///</remarks>   
        private static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// 转大写
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string ToUp(string input)
        {
            string s = ToDBC(input);
            System.Text.StringBuilder sb = new StringBuilder();
            char[] c = s.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                sb.Append(c[i].ToString().ToUpper());
            }
            return sb.ToString();
        }

        public static string ToUpMd5(string strTxt)
        {
            strTxt = ToUp(strTxt);
            string sMD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strTxt, "MD5");
            //sMD5 = ToUp(sMD5);
            return sMD5;
        }
        #endregion

        #region 检查登录
        public static void ChkAdmlogin()
        {
            string rootUrl = System.Configuration.ConfigurationManager.AppSettings["rootUrl"].ToString();
            CookiesHelper ck = new CookiesHelper();
            string loginuserguid = ck.getCookie("d3W6CMlVTocElurgOlGWVQ");
            string loginuserguid2 = ck.getCookie("IbrcVLdyQPQ6NgFoHFzfA");
            if (!string.IsNullOrEmpty(loginuserguid)
                && !string.IsNullOrEmpty(loginuserguid2)
                )
            {
                if (PasswordHelper.Md5Verify(loginuserguid, loginuserguid2))
                {

                }
                else
                {
                    System.Web.HttpContext.Current.Response.Redirect(rootUrl + "Manage/adminLogin.htm");
                    // Response.Write("你的帐号发生异常请，登陆 <a href='../login.aspx'>登陆</a>");
                }
            }
            else
                System.Web.HttpContext.Current.Response.Redirect(rootUrl + "Manage/adminLogin.htm");
        }
        /*
         * //Commented by Long 2016/01/21
        public static void ChkUserlogin(string curUrl, string curWord)
        {
            string rootUrl = System.Configuration.ConfigurationManager.AppSettings["rootUrl"].ToString();
           CookiesHelper ck = new CookiesHelper();
            string loginuserguid = ck.getCookie("jZvJvvjqCILHX7zjBWskQA");
            string loginuserguid2 = ck.getCookie("WaW8NVlOPgTshKOEbfT6BBIYygS7DLpmKqHDUqu0BgQ");
            if (!string.IsNullOrEmpty(loginuserguid)
                && !string.IsNullOrEmpty(loginuserguid2)
                )
            {
                if (PasswordHelper.Md5Verify(loginuserguid, loginuserguid2))
                {

                }
                else
                {

                    System.Web.HttpContext.Current.Response.Redirect(rootUrl + "Manage/adminLogin.htm");
                    // Response.Write("你的帐号发生异常请，登陆 <a href='../login.aspx'>登陆</a>");
                }
            }
            else
                System.Web.HttpContext.Current.Response.Redirect(rootUrl + "login.aspx?curUrl=" + System.Web.HttpContext.Current.Server.UrlEncode(curUrl) + "&curWord=" + System.Web.HttpContext.Current.Server.UrlEncode(curWord));
        }
        public static bool ChkUserlogin()
        {
            string rootUrl = System.Configuration.ConfigurationManager.AppSettings["rootUrl"].ToString();
            CookiesHelper ck = new CookiesHelper();
            string loginuserguid = ck.getCookie("jZvJvvjqCILHX7zjBWskQA");
            string loginuserguid2 = ck.getCookie("WaW8NVlOPgTshKOEbfT6BBIYygS7DLpmKqHDUqu0BgQ");
            if (!string.IsNullOrEmpty(loginuserguid)
                && !string.IsNullOrEmpty(loginuserguid2)
                )
            {
                if (PasswordHelper.Md5Verify(loginuserguid, loginuserguid2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }*/
        #endregion


        #region  md5签名
        /// <summary> 
        /// 签名字符串
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <returns>签名结果</returns>
        public static string Md5Sign(string prestr)
        {
            string key = System.Configuration.ConfigurationManager.AppSettings["EncryptKey"].ToString();//密钥
            string _input_charset = "utf-8";//编码格式
            StringBuilder sb = new StringBuilder(32);
            prestr = prestr + key;
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <param name="sign">签名结果</param>
        /// <param name="key">密钥</param>
        /// <param name="_input_charset">编码格式</param>
        /// <returns>验证结果</returns>
        public static bool Md5Verify(string prestr, string sign)
        {
            string key = System.Configuration.ConfigurationManager.AppSettings["EncryptKey"].ToString();//密钥
            string mysign = Md5Sign(prestr);
            if (mysign == sign)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
