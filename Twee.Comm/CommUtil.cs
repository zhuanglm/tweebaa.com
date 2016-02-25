using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Twee.Comm;
using Twee.Model;
//using System.Deployment;
using System.Reflection;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace Twee.Comm
{
    public static class CommUtil
    {
        #region 数据类型转换扩展方法
        /*
         * Usage:
         * Random rnd = new Random();
            string[] coupon = new string[10];
            for (int i = 0; i < coupon.Length; i++) {
              coupon[i] = GenerateCoupon(10, rnd);
            }
            Console.WriteLine(String.Join(Environment.NewLine,coupon));
         */
        public static string GenerateCouponCode()
        {
            /*
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();*/
           return Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 10);
        }
        public static string ToDBDateFormat(string sDate)
        {
            // Convert yyyy/mm/dd or yyyy-mm-dd to mm/dd/yyyy 
            if (sDate.Length < 10) return sDate;
            if ((sDate.Substring(4, 1) == "-" && sDate.Substring(7, 1) == "-") ||
                 (sDate.Substring(4, 1) == "/" && sDate.Substring(7, 1) == "/"))
            {
                string sYYYY = sDate.Substring(0, 4);
                string sMM = sDate.Substring(5, 2);
                string sDD = sDate.Substring(8, 2);
                return sMM + "/" + sDD + "/" + sYYYY;
            }
            else
                return sDate;
        }

        public static string GetShortDesc(string descFull) 
        {
            // do no break a work
            string descShort = descFull;
            if (descFull.Length > 80)
            {
                descShort = Comm.CommUtil.Left(descFull, 80);
                //if (descFull.length > 80) 
                {

                    for (int i = 80; i > 0; i--)
                    {
                        string t = descShort.Substring(i - 1, 1);
                        if (t == " ") break;
                        descShort = descShort.Substring(0, i - 1);//  + t;
                    }
                }
            }
          
            return descShort;
        }
        public static int getExtraShoppingRewardPoint(float price)
        {
            int iRewardPoint = 0;
            if (price <= 25)
            {
                iRewardPoint = 100;
            }
            else if (price > 25 && price <= 50)
            {
                iRewardPoint = 200;
            }
            else if (price > 50 && price <= 100)
            {
                iRewardPoint = 300;
            }
            else if (price > 100 && price <= 200)
            {
                iRewardPoint = 400;
            }
            else if (price > 200 && price <= 300)
            {
                iRewardPoint = 500;
            }
            else if (price > 300 && price <= 400)
            {
                iRewardPoint = 600;
            }
            else if (price > 400)
            {
                iRewardPoint = 700;
            }
            return iRewardPoint;
        }
        public static string ToDBDateFormat(DateTime dt)
        {
            // mm/dd/yyyy hh:mm
            return dt.ToString("MM/dd/yyyy hh:mm:ss").Replace("-", "/");
        }


        /// <summary>
        /// 字符串转换为int
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static int ToInt(this string arg)
        {
            if (!string.IsNullOrEmpty(arg.Trim()))
            {
                return Convert.ToInt32(arg);
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 字符串转换为decimal
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string arg)
        {
            if (!string.IsNullOrEmpty(arg.Trim()))
            {
                return Convert.ToDecimal(arg);
            }
            else
            {
                return 0.00M;
            }

        }
        /// <summary>
        /// 字符串转换为DateTime
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string arg)
        {
            if (!string.IsNullOrEmpty(arg.Trim()))
            {
                return Convert.ToDateTime(arg);
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 将对象转换为字符串，null返回空
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static string ToNullString(this object arg)
        {
            if (arg != null && arg.ToString() != "undefined")
            {
                return arg.ToString().Trim();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 字符串转换为Guid
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static Guid? ToGuid(this string arg)
        {
            try
            {
                if (!string.IsNullOrEmpty(arg))
                {
                    Guid guid = new Guid(arg);
                    return guid;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;                
            }
           
        }

        /// <summary>
        /// 字符串空或null报错提示
        /// </summary>
        /// <param name="arg"></param>
        public static string ThrowError(this string arg,string message)
        {
            if (string.IsNullOrEmpty(arg))
            {
                throw new Exception(message);       
            }
            else
            {
                return arg;
            }
            
        }

        /// <summary>
        /// 订单状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string CheckState(string state)
        {
            // 0 为支付，1待发货，2已发货，3已完成，-1 已作废

            switch (state)
            {
                case "0":
                    return "未支付";
                case "1":
                    return "待发货";
                case "2":
                    return "已发货";
                case "3":
                    return "已完成";
                case "-1":
                    return "已作废";
                default:
                    return "未知";

            }
        }


        #endregion

        public static readonly string strwebAppDomain = ConfigurationManager.AppSettings.Get("webAppDomain").ToString();
        const string HTML_TAG_PATTERN = "<.*?>";

        /// <summary>
        ///  下面3个函数是作为数据同步用的
        /// </summary>
        /// <returns></returns>
        public static int SlaveID()
        {
            int iSlave = ConfigurationManager.AppSettings.Get("IsSlave").ToInt();
            return iSlave;
        }

        public static bool IsDALSync()
        {
            int IsSandbox = ConfigurationManager.AppSettings.Get("IsDebug").ToInt();
            if (IsSandbox == 1) return true;
            else return false;
        }
        public static string ConvertCommandParamatersToLiteralValues(SqlCommand cmd)
        {
            
            string query = cmd.CommandText;
            
            foreach (SqlParameter prm in cmd.Parameters)
            {
                switch (prm.SqlDbType)
                {
                    case SqlDbType.Bit:
                        int boolToInt = (bool)prm.Value ? 1 : 0;
                        query = query.Replace(prm.ParameterName, string.Format("{0}", (bool)prm.Value ? 1 : 0));
                        break;
                    case SqlDbType.Int:
                        query = query.Replace(prm.ParameterName, string.Format("{0}", prm.Value));
                        break;
                    case SqlDbType.VarChar:
                        query = query.Replace(prm.ParameterName, string.Format("'{0}'", prm.Value));
                        break;
                    default:
                        query = query.Replace(prm.ParameterName, string.Format("'{0}'", prm.Value));
                        break;
                }
            }
            return query;
        }
        ///////////////////////////

        /// <summary>
        ///  get version
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentVersion()
        {
            //return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            return DateTime.Now.ToString("yyMMddHHmmss");
        }
        public static string StripHTML(string inputString)
        {
            return Regex.Replace
              (inputString, HTML_TAG_PATTERN, string.Empty);
        }
        /// <summary>
        ///  验证是否登录,并返回UserGuid
        /// </summary>
        /// <returns></returns>
        public static Guid? IsLogion()
        {
            //CookiesHelper cookie = new Twee.Comm.CookiesHelper();
            //string userGuid = cookie.getCookie(ConfigurationManager.AppSettings.Get("cookieUserID").ThrowError("请先登录！").ToString());
            //string pwd      = cookie.getCookie(ConfigurationManager.AppSettings.Get("cookieUserPWD").ThrowError("请先登录！").ToString());
            //string email    = cookie.getCookie(ConfigurationManager.AppSettings.Get("cookieUserEmail").ThrowError("请先登录！").ToString());
            string sUserGuid = string.Empty;
            string sEmail = string.Empty;
            string sPwd = string.Empty;
            if (!GetUserLoginCookie(out sUserGuid, out sEmail, out sPwd)) return null;
            
            Guid? uGuid = sUserGuid.ToGuid();
            if (!string.IsNullOrEmpty(sUserGuid) && !string.IsNullOrEmpty(sPwd))
            {
                // set the cookie again
                SetUserLoginCookie(sUserGuid, sEmail, sPwd);
                return uGuid;
            }
            else
            {
               // "".ThrowError("请先登录！");
                return null;
            }
        }
 
        public static bool SetUserLoginCookie(string sUserGuid, string sUserEmail, string sUserPwd)
        {
            try
            {
                CookiesHelper cook = new CookiesHelper();
                string sCookieUserID = ConfigurationManager.AppSettings.Get("cookieUserID");
                string sCookieUserEmail = ConfigurationManager.AppSettings.Get("cookieUserEmail");
                string sCookieUserPwd = ConfigurationManager.AppSettings.Get("cookieUserPWD");
                bool b1 = cook.createCookie(sCookieUserID, sUserGuid, 30);
                bool b2 = cook.createCookie(sCookieUserEmail, sUserEmail, 30);
                bool b3 = cook.createCookie(sCookieUserPwd, sUserPwd, 1);
                return (b1 && b2);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static bool GetUserLoginCookie(out string sUserGuid, out string sUserEmail, out string sUserPwd)
        {
            sUserGuid = string.Empty;
            sUserEmail = string.Empty;
            sUserPwd = string.Empty;
            try
            {
                CookiesHelper ck = new CookiesHelper();
                string sCookieUserID = ConfigurationManager.AppSettings.Get("cookieUserID");
                string sCookieUserEmail = ConfigurationManager.AppSettings.Get("cookieUserEmail");
                string sCookieUserPwd = ConfigurationManager.AppSettings.Get("cookieUserPWD");
                sUserGuid = ck.getCookie(sCookieUserID);
                sUserEmail = ck.getCookie(sCookieUserEmail);
                sUserPwd = ck.getCookie(sCookieUserPwd);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static bool IsTestingGroup(string userGuid)
        {                                 /* dragon2934                            ckelly2@leivaire.com */

            string[] TestingGroupGuids = { "eff4dca6-fedc-4bd9-bbe5-79dec2bb39d8", "29a4d259-fde1-48db-9631-1004dbb213a5", "817f71f7-21ce-4a81-a4b0-15c2bbe2c515" };

            int index = Array.IndexOf(TestingGroupGuids, userGuid);
            if (index >= 0) return true;
            else return false;

        }

        /// <summary>
        /// 创建订单编号
        /// </summary>
        /// <returns></returns>
        public static string CreateOrderNum()
        {
            int iOrderSeq = DbHelperSQL.GetSeq("OrderNumber");
            //string orderNum = "Twee" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond;          
            string orderNum = "Twee" + iOrderSeq.ToString();         
            return orderNum;
        
        }

        /// <summary>
        /// create Tweebaa SKU number
        /// </summary>
        /// <returns></returns>
        public static string CreateTweebaaSKU()
        {
            int iSKU = DbHelperSQL.GetSeq("TweebaaSKU");
             return "3" + iSKU.ToString("000000000");

        }


        /// <summary>
        /// 获取产品图片完整路径
        /// </summary>
        /// <param name="img">图片的数据库路径</param>
        /// <returns></returns>
        public static string GetPic(string img)
        {
            string strHost = System.Configuration.ConfigurationManager.AppSettings["prdImgDomain"].ToString();
            img = strHost + img.Replace("big", "small");
            return img;

        }

        /// <summary>
        /// 返回产品id, 检查prdid中是否包含“_”，如果包含，说明该链接是分享链接，需要截取“_”前面的字符，
        /// 即为prdid,返回，同时输出分享链接在数据库的id
        /// </summary>
        /// <param name="urlPrdId">返回产品id</param>
        /// <param name="urlShareId">输出分享链接的id</param>
        /// <returns></returns>
        public static string GetUrlPrdId(string urlPrdId,out string urlShareId)
        {
            string pridId = urlPrdId;
            urlShareId = null;
            if (!string.IsNullOrEmpty(urlPrdId))
            {
                //_前面的为产品id,_后面的为分享链接的id
                if (pridId.IndexOf("_") > 0)
                {
                    int index= pridId.IndexOf("_");
                    pridId = pridId.Substring(0,index);
                    urlShareId = urlPrdId.Substring(index+1, urlPrdId.Length - index-1);//分享链接的id
                }
            }
            return pridId;
           
        
        }
        //public static Dictionary<string, string> GetUserGrateRatio()
        //{ 
        
        
        
        //}
        /// <summary>
        /// keywords seprated by "," or " " 
        /// return sql like where conditions
        /// </summary>
        public static string GetSqlLike(string sColName, string sKey)
        {

            StringBuilder sSqlLike = new StringBuilder();
  
            // Search for keywords which are seperated by comma or spaces
            string sTag = sKey.Replace(",", " ");  // replace comma to spaces
            while (sTag.IndexOf("  ") != -1)
            {   
                // padding spaces
                sTag = sTag.Replace("  ", " ");
            }

            string[] arrTag = sTag.Split(' ');
            if (arrTag.Length > 0)
            {
                for (int i = 0; i < arrTag.Length; i++)
                {
                    if (i > 0)
                    {
                        sSqlLike.Append(" and ");
                    }
                    sSqlLike.Append(sColName);
                    sSqlLike.Append(" like '%" + CommUtil.Quo(arrTag[i]) + "%'");
                }
            }
            return sSqlLike.ToString();
        }

        /// <summary>
        /// escape single quotation
        /// </summary>
        public static string Quo(string s)
        {
            string sOut = "";
            string sIn = s.Trim();

            foreach (char c in s)
            {
                sOut = sOut + c;
                if (c == '\'') sOut = sOut + c;
            }
            return sOut;
        }
        public static void SendDebugString(string sErrorText)
        {
            //Mail to All
            Mailhelper.SendMail("Debug Message From:" + strwebAppDomain, sErrorText, "long@leivaire.com");
            //Mailhelper.SendMail("Error Reporting From:" + strwebAppDomain, sErrorText, "jack@leivaire.com");
        }
        public static void GenernalErrorHandler(Exception exception)
        {
            var stringBuilder = new StringBuilder();

            while (exception != null)
            {
                stringBuilder.AppendLine(exception.Message);
                stringBuilder.AppendLine(exception.StackTrace);

                exception = exception.InnerException;
            }

            string sErrorText=stringBuilder.ToString();

            //Mail to All
            Mailhelper.SendMail("Error Reporting From:" + strwebAppDomain + " Machine:" + Environment.MachineName, sErrorText, "long@leivaire.com");
            Mailhelper.SendMail("Error Reporting From:" + strwebAppDomain + " Machine:" + Environment.MachineName, sErrorText, "jack@leivaire.com");
        }
        public static void GenernalErrorHandlerEx(Exception exception,string strMessage)
        {
            var stringBuilder = new StringBuilder();

            while (exception != null)
            {
                stringBuilder.AppendLine(exception.Message);
                stringBuilder.AppendLine(exception.StackTrace);

                exception = exception.InnerException;
            }

            string sErrorText = "Message:"+strMessage+ "<br>Error:"+stringBuilder.ToString();

            //Mail to All
            Mailhelper.SendMail("Error Reporting From:" + strwebAppDomain + " Machine:" + Environment.MachineName, sErrorText, "long@leivaire.com");
            Mailhelper.SendMail("Error Reporting From:" + strwebAppDomain + " Machine:" + Environment.MachineName, sErrorText, "jack@leivaire.com");

        }     
        public static bool isValidEmail(string sEmail)
        {
            //string strRegex =  @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            //      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            //      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            string sRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            Regex ret = new Regex(sRegex);
            return ret.IsMatch(sEmail);
        }

        public static string GetDummyGuid()
        {
            return "00000000-0000-0000-0000-000000000000";
        }


        public static bool IsTweebaaSku(string s)
        {
            if ( s.Length != 10) return false;
            string pattern = @"\d{10}";

            // Instantiate the regular expression object.
            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);

            // Match the regular expression pattern against a text string.
            return (reg.IsMatch(s));
        }

        public static string Left(string s, int iMaxLen)
        {
            if (string.IsNullOrEmpty(s)) return s;
            iMaxLen = Math.Abs(iMaxLen);

            return (s.Length <= iMaxLen? s : s.Substring(0, iMaxLen));
        }

        public static string GetShipPartnerName(int iShipPartener)
        {
            return Enum.GetName(typeof(ConfigParamter.ShipPartner), iShipPartener);
        }

        public static string GetProductStatusName(int iProductStatus)
        {
            string sProductStatusName = string.Empty;
            switch (iProductStatus)
            {
                case (int)ConfigParamter.PrdSate.draft:
                    sProductStatusName = "Draft";
                    break;
                case (int)ConfigParamter.PrdSate.review:
                    sProductStatusName = "Public Evaluation";
                    break;
                case (int)ConfigParamter.PrdSate.sale:
                    sProductStatusName = "Buy Now";
                    break;
                case (int)ConfigParamter.PrdSate.preSale:
                    sProductStatusName = "Test-Sale";
                    break;
                default:
                    break;
            }
            return sProductStatusName;
        }

        public static string GetOrderStatusName(int iOrderStatusID)
        {
            return Enum.GetName(typeof(ConfigParamter.OrderStatus), iOrderStatusID);
        }

        public static string GetInventoryStatusName(int iInventoryStatusID)
        {
            return Enum.GetName(typeof(ConfigParamter.InventoryState), iInventoryStatusID);
        }

        public static string GetShipOrderStatusName(int iShipOrderStatusID)
        {
            // use the same status as order 
            return Enum.GetName(typeof(ConfigParamter.OrderStatus), iShipOrderStatusID);
        }

        public static string GetTrackingLink(string sCarrierName, string sTrackingNo)
        {
            string sTrackingLink = string.Empty;
            string sCarrier = sCarrierName.Trim().Split(' ')[0].Trim().ToUpper();
            if (sCarrier == "FEDEX")
                sTrackingLink = "https://www.fedex.com/apps/fedextrack/?action=track&trackingnumber=" + sTrackingNo + "&cntry_code=us";
            else if (sCarrier == "DHL")
                sTrackingLink = "http://webtrack.dhlglobalmail.com/?mobile=&trackingnumber=" + sTrackingNo.Trim() + "&locale=en";

            return sTrackingLink;
        }

        public static string Name2URL(string sProduct)
        {
            //string cleanTitle = sProduct.Trim().ToLower();
            string cleanTitle = sProduct.Trim();
            string pattern = @"[\x00-\x19\x21-\x2F\x3A-\x40\x5B-\x60\x7B-\xFF]";
            string parsedStr = string.Empty;
            //parsedStr = Regex.Replace(cleanTitle, pattern, " ");
            parsedStr = Regex.Replace(cleanTitle, pattern, " ");
            return parsedStr.Replace("%20", "-").Replace(" ", "-");
        }
        public static string ReplaceSpecial(string strText, short iDirection)
        {
            //http://www.w3school.com.cn/tags/html_ref_urlencode.html

            string strRet = strText;
            if (iDirection == 1) //from name to URL
            {
                //replace  &  to _
                //strRet = strRet.Replace(" & ", "_");
                //strRet = strRet.Replace("/", "%2f");
                //strRet = strRet.Replace("'", "%27");
                strRet = strRet.Replace("&", "and");
                strRet = strRet.Replace("/", "and");
                strRet = strRet.Replace("Décor", "Decor");
                strRet = strRet.Replace("'", "");
                strRet = strRet.Replace(",", "");
                //strRet = strText;
                //strRet = Name2URL(strText);

            }
            else //from URL to name
            {
                strRet = strRet.Replace("-", " ");
                strRet = strRet.Replace("Decor", "Décor");
                //strRet = strRet.Replace("_", " ");
                //strRet = strRet.Replace("and", "&");
                //strRet = strRet.Replace("%2f", "/");
                //strRet = strRet.Replace("%27", "'");
                //strRet = strRet.Replace("A_A", "/");
                //strRet = strRet.Replace("_", " & ");
                //strRet = strRet.Replace("%2f", "/");
                //strRet = strRet.Replace("%27", "'");          
            }
            return strRet;
        }
    }
}
