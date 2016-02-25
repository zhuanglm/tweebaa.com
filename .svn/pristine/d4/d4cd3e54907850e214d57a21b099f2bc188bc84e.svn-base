using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Comm
{
    public static class ConvertHelper
    {
        public static int? _ToInt(this string arg) {
            if (string.IsNullOrEmpty(arg))
                return null;
            return int.Parse(arg);
        }
        public static decimal? _ToDecimal(this string arg)
        {
            if (string.IsNullOrEmpty(arg))
                return null;
            return decimal.Parse(arg);
        }
        public static string _ObjToString(this object str) {
            if (null == str)
                return string.Empty;
            else
                return str.ToString().Trim();
        }

        public static string _DateTimeToString(this DateTime? str) {
            if (null == str)
                return string.Empty;
            else
                return Convert.ToDateTime ( str).ToString("yyyy-MM-dd");
        }

        public static string _DefaultToString(this string str, string defaultString) {
            if (string.IsNullOrEmpty(str))
                return defaultString;
            else
                return str.ToString();
        }

        public static string _EscapeDoubleQuo(this string str)
        {
            if (null == str)
                return string.Empty;
            else
                return str.Replace("\"", "\\\"");
        }
    }
}
