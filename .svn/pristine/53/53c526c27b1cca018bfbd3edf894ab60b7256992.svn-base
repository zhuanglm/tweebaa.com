using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using Twee.Comm;

namespace TweebaaWebApp.Mgr.ByFocusMgr
{
    /// <summary>
    /// Summary description for ByFocusCateMgr1
    /// </summary>
    public class ByFocusCateMgr1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (string.IsNullOrEmpty(context.Request["action"]))
                context.Response.Write(string.Empty);
            string sAction=context.Request["action"].ToString().Trim();
            switch (sAction)
            {
                case "ByFocusCateDatagrid":
                    context.Response.Write(GridData(context));
                    break;
                case "ProductByFocusCateDatagrid":
                    context.Response.Write(ProductGridData(context));
                    break;
                default:
                    context.Response.Write(string.Empty);
                    break;
            }
        }

        private string GridData(HttpContext context)
        {
            int iPageSize = int.Parse(context.Request["rows"]);
            int iPage = int.Parse(context.Request["page"]) - 1;
            int iStartIdx = iPageSize * iPage + 1;
            int iEndIdx = iStartIdx + iPageSize - 1;

            Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();
            int iTotalCount = 0;

            //var dt = mgr.MgeGetPersonShare(strWhere, strOrderBy, startId, endId, out totalCount);
            var dt = mgr.MgeGetFocusCateList(iStartIdx, iEndIdx, out iTotalCount);
            
            //if (dt == null || dt.Rows.Count == 0)
            //    return string.Empty;
            StringBuilder json = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                json.AppendFormat(",{0}  \"FocusCateID\":\"{2}\",\"Name\":\"{3}\",\"Note\":\"{4}\",\"Active\":\"{5}\" {1}", "{", "}"
                    , row["FocusCateID"]._ObjToString(),
                    row["Name"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["Note"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    (row["Active"]._ObjToString()=="1")?"Yes":"No"
                    );
            }
            string temp_json = string.Empty;
            if (!string.IsNullOrEmpty(json.ToString()))
                temp_json = json.ToString().Substring(1);
            string res = "{\"total\":" + iTotalCount.ToString() + ",\"rows\":[" + temp_json + "]}";
            return res;
        }


        private string ProductGridData(HttpContext context)
        {
            int iPageSize = int.Parse(context.Request["rows"]);
            int iPage = int.Parse(context.Request["page"]) - 1;
            int iStartIdx = iPageSize * iPage + 1;
            int iEndIdx = iStartIdx + iPageSize - 1;

            Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();
            int iTotalCount = 0;

            string sSearchKeyword = context.Request["keyword"].ToString().Trim();
            bool bSearchHasNotFocusCate = context.Request["DispHasNotFocusCate"].ToString().Trim() == "true"?true:false;
            int iProductStatusId = context.Request["ProductStatusId"].ToString().ToInt();

            //var dt = mgr.MgeGetPersonShare(strWhere, strOrderBy, startId, endId, out totalCount);
            var dt = mgr.MgeGetProductFocusCateList(sSearchKeyword, bSearchHasNotFocusCate, iProductStatusId, iStartIdx, iEndIdx, out iTotalCount);

            if (dt == null || dt.Rows.Count == 0) return "{\"total\":0,\"rows\":[]}";
            
            StringBuilder json = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                json.Append(",{");
                for ( int j=0; j<dt.Columns.Count; j++) {
                    string sColName = dt.Columns[j].ColumnName;
                    if (j > 0) json.Append(",");
                    json.Append("\"" + RemoveSpecialChar(sColName) + "\":\"" +  row[sColName]._ObjToString().Replace(',', '，').Replace("\"", "&quot;") + "\"");
                }
                json.Append("}");
            }
            string temp_json = string.Empty;
            if (!string.IsNullOrEmpty(json.ToString()))
                temp_json = json.ToString().Substring(1);
            string res = "{\"total\":" + iTotalCount.ToString() + ",\"rows\":[" + temp_json + "]}";
            return res;
        }

        private string RemoveSpecialChar(string s) {
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