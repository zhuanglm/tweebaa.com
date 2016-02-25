using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Collections;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Data.SqlClient;

namespace Twee.Comm
{
    /// <summary>
    /// 信息类
    /// </summary>
    public static class MessageHelper
    {
        public static bool AddMesage(string strtitle, string strDetail, string userguid, string urlguid)
        {
            using (SqlConnection con = new SqlConnection(DbHelperSQL.strConn))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into dbo.wn_message(title,detail,isready,prtguid) values(@title,@detail,0,@prtguid) ", con);
                    SqlParameter[] parameters = new SqlParameter[] { 
                                        new SqlParameter("@title",strtitle),
                                        new SqlParameter("@detail", strDetail),
                                        new SqlParameter("@prtguid",userguid)
                                    };
                    foreach (SqlParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    return cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception ex)
                {
                   CommHelper.WrtLog(ex.Message.ToString());
                    return false;
                }

            }
        }



        /// <summary>
        /// 读取HTML文件
        /// </summary>
        /// <param name="temp">HttpContext.Current.Server.MapPath("./lucklist/Main.html");</param>
        /// <returns></returns>
        public static ArrayList ReadHtmlFile(string filename, string[] ReplaceString)
        {
            ArrayList lst = new ArrayList();
            string temp = System.Web.HttpContext.Current.Server.MapPath("~") + @"\User\" + filename;
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
                        //data[0]为#Select3
                        //data[1]为替换字段 
                        str = str.Replace(data[0], data[1]);
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
    }
}
