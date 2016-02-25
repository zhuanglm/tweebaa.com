using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using Twee.Comm;

namespace TweebaaWebApp2.Mgr.PageContentMgr
{
    /// <summary>
    /// Summary description for PageContentHandler
    /// </summary>
    public class PageContentHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (string.IsNullOrEmpty(context.Request["action"]))
                context.Response.Write(string.Empty);
            string sAction = context.Request["action"].ToString().Trim();
            switch (sAction)
            {
                case "PageContentCateDatagrid":
                    context.Response.Write(PageContentCateGridData(context));
                    break;
                case "PageContentDatagrid":
                    context.Response.Write(PageContentGridData(context));
                    break;
                default:
                    context.Response.Write(string.Empty);
                    break;
            }
        }

        private string PageContentCateGridData(HttpContext context)
        {
            int iPageSize = int.Parse(context.Request["rows"]);
            int iPage = int.Parse(context.Request["page"]) - 1;
            int iStartIdx = iPageSize * iPage + 1;
            int iEndIdx = iStartIdx + iPageSize - 1;

            Twee.Mgr.PageContentMgr mgr = new Twee.Mgr.PageContentMgr();
            int iTotalCount = 0;

            //var dt = mgr.MgeGetPersonShare(strWhere, strOrderBy, startId, endId, out totalCount);
            var dt = mgr.MgeGetPageContentCate(false, iStartIdx, iEndIdx, out iTotalCount);

            //if (dt == null || dt.Rows.Count == 0)
            //    return string.Empty;
            StringBuilder json = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                json.AppendFormat(",{0}  \"PageContentCateID\":\"{2}\",\"Name\":\"{3}\",\"Active\":\"{4}\" {1}", "{", "}"
                    , row["PageContentCate_ID"]._ObjToString(),
                    row["PageContentCate_Name"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    (row["PageContentCate_IsActive"]._ObjToString() == "1") ? "Yes" : "No"
                    );
            }
            string temp_json = string.Empty;
            if (!string.IsNullOrEmpty(json.ToString()))
                temp_json = json.ToString().Substring(1);
            string res = "{\"total\":" + iTotalCount.ToString() + ",\"rows\":[" + temp_json + "]}";
            return res;
        }


        private string PageContentGridData(HttpContext context)
        {
            int iPageSize = int.Parse(context.Request["rows"]);
            int iPage = int.Parse(context.Request["page"]) - 1;
            int iStartIdx = iPageSize * iPage + 1;
            int iEndIdx = iStartIdx + iPageSize - 1;

            Twee.Mgr.PageContentMgr mgr = new Twee.Mgr.PageContentMgr();
            int iTotalCount = 0;

            //string sSearchKeyword = context.Request["keyword"].ToString().Trim();
            //bool bSearchHasNotFocusCate = context.Request["DispHasNotFocusCate"].ToString().Trim() == "true" ? true : false;
            //int iProductStatusId = context.Request["ProductStatusId"].ToString().ToInt();

            //var dt = mgr.MgeGetPersonShare(strWhere, strOrderBy, startId, endId, out totalCount);
            var dt = mgr.MgeGetPageContent(iStartIdx, iEndIdx, out iTotalCount);

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
                    if (sColName == "PageContent_PageDescription")
                    {
                        sColValue = sColValue.Replace("\n", "").Replace("\t", "");
                    }
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