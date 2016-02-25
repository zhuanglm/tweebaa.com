using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Twee.Comm;

namespace Twee.DataMgr
{
    public class AnalysisDataMgr
    {        

        public string GetUserReg(string strKey)
        {
            DataSet ds = new DataSet();
            string intRes = "-100";//默认错误
            if (strKey != CommHelper.GetString(strKey, true))
                intRes = "-99";//非法调用
            else
            {
                //if (!WN.ToolBox.PasswordHelper.Md5Verify(jZvJvvjqCILHX7zjBWskQA, WaW8NVlOPgTshKOEbfT6BBIYygS7DLpmKqHDUqu0BgQ))
                if (false)
                    intRes = "-96";//cook安全级错误
                else
                {
                    System.Text.StringBuilder sbSql = new StringBuilder();
                    sbSql.Append("select COUNT(1) as collect,convert(nvarchar(22),regtime,102) as dt from wn_user group by convert(nvarchar(22),regtime,102) order by convert(nvarchar(22),regtime,102)");
                    ds = DbHelperSQL.Query(sbSql.ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                        intRes = "1";
                }
            }
            string strCountry = CommHelper.ToJsonString(ds);
            string s = "{it:'" + intRes + "',data:" + strCountry + "}";
            return Newtonsoft.Json.JsonConvert.SerializeObject(s);
        }

        public string GetUserLog(string strKey)
        {
            DataSet ds = new DataSet();
            string intRes = "-100";//默认错误
            if (strKey != CommHelper.GetString(strKey, true))
                intRes = "-99";//非法调用
            else
            {
                //if (!WN.ToolBox.PasswordHelper.Md5Verify(jZvJvvjqCILHX7zjBWskQA, WaW8NVlOPgTshKOEbfT6BBIYygS7DLpmKqHDUqu0BgQ))
                if (false)
                    intRes = "-96";//cook安全级错误
                else
                {
                    System.Text.StringBuilder sbSql = new StringBuilder();
                    sbSql.Append("select COUNT(1) as collect,convert(nvarchar(22),edtTime,102) as dt from dbo.wn_loginLog group by convert(nvarchar(22),edtTime,102) order by convert(nvarchar(22),edtTime,102)");
                    ds = DbHelperSQL.Query(sbSql.ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                        intRes = "1";
                }
            }
            string strCountry = CommHelper.ToJsonString(ds);
            string s = "{it:'" + intRes + "',data:" + strCountry + "}";
            return Newtonsoft.Json.JsonConvert.SerializeObject(s);
        }

        public string GetUserReview(string strKey)
        {
            DataSet ds = new DataSet();
            string intRes = "-100";//默认错误
            if (strKey != CommHelper.GetString(strKey, true))
                intRes = "-99";//非法调用
            else
            {
                //if (!WN.ToolBox.PasswordHelper.Md5Verify(jZvJvvjqCILHX7zjBWskQA, WaW8NVlOPgTshKOEbfT6BBIYygS7DLpmKqHDUqu0BgQ))
                if (false)
                    intRes = "-96";//cook安全级错误
                else
                {
                    System.Text.StringBuilder sbSql = new StringBuilder();
                    sbSql.Append("select COUNT(1) as collect,convert(nvarchar(22),edtTime,102) as dt from dbo.wn_review group by convert(nvarchar(22),edtTime,102) order by convert(nvarchar(22),edtTime,102)");
                    ds =DbHelperSQL.Query(sbSql.ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                        intRes = "1";
                }
            }
            string strCountry = CommHelper.ToJsonString(ds);
            string s = "{it:'" + intRes + "',data:" + strCountry + "}";
            return Newtonsoft.Json.JsonConvert.SerializeObject(s);
        }

    }
}
