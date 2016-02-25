using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;

namespace Twee.Comm
{
    public class CommHelper
    {
        /// <summary>
        ///  写入日志
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strTxt"></param>
        public static void WrtLog(string strTxt)
        {
            String dirPath = HttpContext.Current.Server.MapPath("~" + "/" + "log/");
            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff") + ".txt";

            if (!System.IO.Directory.Exists(dirPath)) { System.IO.Directory.CreateDirectory(dirPath); }
            StreamWriter sw = File.AppendText(dirPath + newFileName);
            sw.WriteLine(strTxt);
            sw.Flush();
            sw.Dispose();
            sw.Close();
        }

        /// <summary>
        /// 读取测试数据
        /// </summary>
        /// <returns></returns>
        public static DataSet GetTestData()
        {
            DataSet ds = new DataSet();
            object[] oResult = new object[2];

            DataTable tb = new DataTable();
            DataColumn totalRowNum = new DataColumn();
            totalRowNum.DataType = typeof(string);
            totalRowNum.ColumnName = "name";
            totalRowNum.DefaultValue = "1";
            tb.Columns.Add(totalRowNum);
            DataColumn totalRowNum2 = new DataColumn();
            totalRowNum2.DataType = typeof(string);
            totalRowNum2.ColumnName = "name2";
            totalRowNum2.DefaultValue = "1";
            tb.Columns.Add(totalRowNum2);
            for (int j = 0; j <= 2; j++)
            {
                oResult[0] = j.ToString();
                oResult[1] = j.ToString();
                tb.Rows.Add(oResult);
            }
            ds.Tables.Add(tb);
            return ds;
        }

        #region 数据类型转换
        /// <summary>
        /// 获取本机的上网IP
        /// </summary>
        /// <returns></returns>
        public static string GetConnectNetAddress()
        {

            //string strUrl = "http://www.ip138.com/ip2city.asp"; //获得IP的网址
            //Uri uri = new Uri(strUrl);
            //WebRequest webreq = WebRequest.Create(uri);
            //Stream s = webreq.GetResponse().GetResponseStream();
            //StreamReader sr = new StreamReader(s, Encoding.Default);
            //string all = sr.ReadToEnd(); //读取网站返回的数据 格式：您的IP地址是：[x.x.x.x]
            //int i = all.IndexOf("[") + 1;
            //string tempip = all.Substring(i, 15);
            //string ip = tempip.Replace("]", "").Replace(" ", "").Replace("<", "");
            return "";
        }
        public static string getDecFmt(decimal d)
        {
            return d.ToString("f2");
        }
        public static int GetInt(string str)
        {
            try
            {
                return int.Parse(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static decimal GetDec(string str)
        {
            try
            {
                return decimal.Parse(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// 对接收参数解码
        /// </summary>
        /// <param name="strReq">参数</param>
        /// <param name="isEdc">true解码，false不解码</param>
        /// <returns></returns>
        public static string GetString(string strReq, bool isEdc)
        {

            if (!string.IsNullOrEmpty(strReq))
            {
                strReq = strReq.Trim();
                if (isEdc)
                {
                    return HttpContext.Current.Server.UrlDecode(strReq.ToString());
                }
                else
                {
                    return strReq.ToString();
                }

            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 对接收参数解码
        /// </summary>
        /// <param name="strReq">参数</param>    
        /// <returns></returns>
        public static string GetStrDecode(string strReq)
        {

            if (!string.IsNullOrEmpty(strReq))
            {
                strReq = strReq.Trim();              
                return HttpContext.Current.Server.UrlDecode(strReq.ToString());               
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 对参数加密
        /// </summary>
        /// <param name="strReq">参数</param>    
        /// <returns></returns>
        public static string GetStrEncode(string strReq)
        {

            if (!string.IsNullOrEmpty(strReq))
            {
                strReq = strReq.Trim();
                return HttpContext.Current.Server.UrlEncode(strReq.ToString());
            }
            else
            {
                return "";
            }
        }

        //Microsoft.JScript.GlobalObject.escape
        public static string GetJsonStr(string strJS)
        {
            return HttpUtility.UrlPathEncode(strJS);
        }
        /// <summary>
        /// 截取指定长度的字符串
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="len">要截取的长度</param>
        /// <param name="flag">截取后是否加省略号(true加,false不加)</param>
        /// <returns></returns>
        public static string CutString(string str, int len)
        {
            bool flag = true;
            string _outString = "";
            int _len = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.ConvertToUtf32(str, i) >= Convert.ToInt32("4e00", 16) && Char.ConvertToUtf32(str, i) <= Convert.ToInt32("9fff", 16))
                {
                    _len += 2;
                    if (_len > len)//截取的长度若是最后一个占两个字节，则不截取
                    {
                        break;
                    }
                }
                else
                {
                    _len++;
                }


                try
                {
                    _outString += str.Substring(i, 1);
                }
                catch
                {
                    break;
                }
                if (_len >= len)
                {
                    break;
                }
            }
            if (str != _outString && flag == true)//判断是否添加省略号
            {
                _outString += "...";
            }
            return _outString;
        }
        public static string FilterHTML(string html)
        {
            System.Text.RegularExpressions.Regex regex1 =
                  new System.Text.RegularExpressions.Regex(@"<script[sS]+</script *>",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 =
                  new System.Text.RegularExpressions.Regex(@" href *= *[sS]*script *:",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 =
                  new System.Text.RegularExpressions.Regex(@" no[sS]*=",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 =
                  new System.Text.RegularExpressions.Regex(@"<iframe[sS]+</iframe *>",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 =
                  new System.Text.RegularExpressions.Regex(@"<frameset[sS]+</frameset *>",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 =
                  new System.Text.RegularExpressions.Regex(@"<img[^>]+>",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 =
                  new System.Text.RegularExpressions.Regex(@"</p>",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 =
                  new System.Text.RegularExpressions.Regex(@"<p>",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex9 =
                  new System.Text.RegularExpressions.Regex(@"<[^>]*>",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记 
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性 
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件 
            html = regex4.Replace(html, ""); //过滤iframe 
            html = regex5.Replace(html, ""); //过滤frameset 
            html = regex6.Replace(html, ""); //过滤frameset 
            html = regex7.Replace(html, ""); //过滤frameset 
            html = regex8.Replace(html, ""); //过滤frameset 
            html = regex9.Replace(html, "");
            html = html.Replace(" ", "");
            html = html.Replace("&nbsp;", "");
            html = html.Replace("&nbsp", "");
            html = html.Replace("</strong>", "");
            html = html.Replace("<strong>", "");
            html = Regex.Replace(html, "[\f\n\r\t\v]", "");  //过滤回车换行制表符
            return html;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intRes"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string ToJsonString(DataSet ds)
        {
            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append("[");
            //{name:'1'},{name:'2'},{name:'2'}]
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append(",{guid2:'" + PasswordHelper.Md5Sign(dr[0].ToString()) + "'");
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.Append("," + dc.ColumnName + ":'" + CommHelper.GetJsonStr(dr[dc].ToString()) + "'");
                }
                sb.Append("}");
            }
            sb.Append("]");
            sb.Replace(',', ' ', 0, 2);
            return sb.ToString();

        }


         /// <summary>
        /// MD5　32位加密
       /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string To32Md5(string str)
        {
            string cl = str;
            string pwd = "";
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符
                pwd = pwd + s[i].ToString("X");

            }
            return pwd;
        }

        /// <summary>
        /// MD5　32位加密(同java保持一致)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string To32Md52(string str)
        {
            byte[] data = Encoding.GetEncoding("GB2312").GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] OutBytes = md5.ComputeHash(data);

            string OutString = "";
            for (int i = 0; i < OutBytes.Length; i++)
            {
                OutString += OutBytes[i].ToString("x2");
            }
            return OutString.ToUpper();
        }

        //public static string To32Md5(string str)
        //{
        //    string cl = str;
        //    string pwd = "";
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] fromData = System.Text.Encoding.Default.GetBytes(cl);
        //    byte[] targetData = md5.ComputeHash(fromData);
        //    for (int i = 0; i < targetData.Length; i++)
        //    {
        //        // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符
        //        pwd = pwd + targetData[i].ToString("X");

        //    }
        //    return pwd;
        //}

       
    }
}
