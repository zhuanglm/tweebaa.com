using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using Twee.Comm;

namespace TweebaaWebApp2.Mgr.CashWithdrawMgr
{
    /// <summary>
    /// Summary description for CashWithdrawHandler
    /// </summary>
    public class CashWithdrawHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (string.IsNullOrEmpty(context.Request["action"]))
                context.Response.Write(string.Empty);
            string sAction = context.Request["action"].ToString().Trim();
            switch (sAction)
            {
                case "CashWithdrawDatagrid":
                    context.Response.Write(CashWithdrawGridData(context));
                    break;
                default:
                    context.Response.Write(string.Empty);
                    break;
            }
        }


        private string CashWithdrawGridData(HttpContext context)
        {
            int iPageSize = int.Parse(context.Request["rows"]);
            int iPage = int.Parse(context.Request["page"]) - 1;
            int iStartIdx = iPageSize * iPage + 1;
            int iEndIdx = iStartIdx + iPageSize - 1;

            // user name
            string sUserName = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["UserName"]))
                sUserName = context.Request["UserName"].ToString().Trim();
            
            // status
            string sStatus = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["Status"]))
                sStatus = context.Request["Status"].ToString().Trim();
            
            // start date
            string sStartDate = string.Empty;    
            if (!string.IsNullOrEmpty(context.Request["StartDate"]))
                sStartDate = context.Request["StartDate"].ToString().Trim();

            // end date
            string sEndDate = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["EndDate"]))
                sEndDate = context.Request["EndDate"].ToString().Trim();

            Twee.Mgr.ProfitMgr mgr = new Twee.Mgr.ProfitMgr();
            int iTotalCount = 0;

            //string sSearchKeyword = context.Request["keyword"].ToString().Trim();
            //bool bSearchHasNotFocusCate = context.Request["DispHasNotFocusCate"].ToString().Trim() == "true" ? true : false;
            //int iProductStatusId = context.Request["ProductStatusId"].ToString().ToInt();

            //var dt = mgr.MgeGetPersonShare(strWhere, strOrderBy, startId, endId, out totalCount);
            var dt = mgr.MgeGetCashWithdrawList(sUserName, sStatus, sStartDate, sEndDate, iStartIdx, iEndIdx, out iTotalCount);

            if (dt == null || dt.Rows.Count == 0) return "{\"total\":0,\"rows\":[]}";

            StringBuilder json = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                json.Append(",{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string sColName = dt.Columns[j].ColumnName;
                    if (j > 0) json.Append(",");
                    string sColValue = row[sColName].ToNullString();
                    json.Append("\"" + RemoveSpecialChar(sColName) + "\":\"" + sColValue.Replace(',', '，').Replace("\"", "&quot;") + "\"");
                }
                json.Append("}");
            }
            string temp_json = string.Empty;
            if (!string.IsNullOrEmpty(json.ToString()))
                temp_json = json.ToString().Substring(1);
            string res = "{\"total\":" + iTotalCount.ToString() + ",\"rows\":[" + temp_json + "]}";
            return res;
        }

        private string RemoveSpecialChar(string s)
        {
            return s.Replace("!", string.Empty);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}