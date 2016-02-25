using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace TweebaaWebApp.Mgr.mgrcomm
{
    public  class mgrHelper
    {
        /// <summary>
        /// 读取Mgr下的配置文件
        /// </summary>
        /// <param name="configPath"></param>
        /// <returns></returns>
        public static string _MgrReadConfig( string configPath)
        {
            if (string.IsNullOrEmpty(configPath))
                return string.Empty;

            StreamReader sr = new StreamReader(configPath, Encoding.Default);
            StringBuilder str = new StringBuilder();
            string line;
            while ((line = sr.ReadLine()) != null) 
            {
                str.Append(line.ToString());
            }
            return str.ToString();
        
        }
    }
}