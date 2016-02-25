using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using Twee.Comm;

namespace TweebaaWebApp2.Mgr.productShare
{
    /// <summary>
    /// Summary description for productShare
    /// </summary>
    public class productShare : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (string.IsNullOrEmpty(context.Request["action"]))
                context.Response.Write(string.Empty);
            string action=context.Request["action"].ToString().Trim();
            switch (action)
            {
                case "initdatagrid":
                    context.Response.Write(InitData(context));
                    break;
                case "datagrid":
                    context.Response.Write(GridData(context));
                    break;
                default:
                    context.Response.Write(string.Empty);
                    break;
            }
        }

        private string InitData(HttpContext context)
        {
            int pageSize = int.Parse(context.Request["rows"]);
            int index = int.Parse(context.Request["page"]) - 1;
            int startId = pageSize * index + 1;
            int endId = startId + pageSize - 1;
            string proName = string.Empty;
            string proUser = string.Empty;
            string startTime = string.Empty;
            string endTime = string.Empty;
            string cate = string.Empty;
            string state = string.Empty;//评审状态
            if (!string.IsNullOrEmpty(context.Request["proName"]))
                proName = context.Request["proName"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["proUser"]))
                proUser = context.Request["proUser"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["startTime"]))
                startTime = context.Request["startTime"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["endTime"]))
                endTime = context.Request["endTime"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["cate"]))
                cate = context.Request["cate"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["state"]))
                state = context.Request["state"].ToString().Trim();

            Twee.Mgr.ShareMgr mgr = new Twee.Mgr.ShareMgr();
            int totalCount = 0;
            string strWhere = "";
            string strOrderBy = "";

            //var dt = mgr.MgeGetPersonShare(strWhere, strOrderBy, startId, endId, out totalCount);
            var dt = mgr.MgeGetPersonShare(strWhere, strOrderBy, startId, endId, out totalCount);
            
            //if (dt == null || dt.Rows.Count == 0)
            //    return string.Empty;
            StringBuilder json = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                json.AppendFormat(",{0}  \"prdguid\":\"{2}\",\"prdname\":\"{3}\",\"sharetype\":\"{4}\",\"addtime\":\"{5}\",\"sharer\":\"{6}\",\"visitcount\":\"{7}\",\"successcount\":\"{8}\",\"shareurl\":\"{9}\"  {1}", "{", "}"
                    , row["prtguid"]._ObjToString(),
                    row["name"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["sharetype"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    ((DateTime)row["addtime"]).ToString("MM/dd/yyyy hh:mm"),
                    row["username"]._ObjToString(),
                    row["visitcount"]._ObjToString(),
                    row["successcount"]._ObjToString(),
                    row["shareurl"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;")
                    );
            }
            string temp_json = string.Empty;
            if (!string.IsNullOrEmpty(json.ToString()))
                temp_json = json.ToString().Substring(1);
            string res = "{\"total\":" + totalCount + ",\"rows\":[" + temp_json + "]}";
            return res;
        }

        private string GridData(HttpContext context)
        {
            int pageSize = int.Parse(context.Request["rows"]);
            int index = int.Parse(context.Request["page"]) - 1;
            int startId = pageSize * index + 1;
            int endId = startId + pageSize - 1;
            string proName = string.Empty;
            string sharer = string.Empty;
            string startTime = string.Empty;
            string endTime = string.Empty;
            string shareType= string.Empty;
            string cate = string.Empty;
            string state = string.Empty;//评审状态
            if (!string.IsNullOrEmpty(context.Request["proName"]))
                proName = context.Request["proName"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["sharer"]))
                sharer = context.Request["sharer"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["startTime"]))
                startTime = context.Request["startTime"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["endTime"]))
                endTime = context.Request["endTime"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["cate"]))
                cate = context.Request["cate"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["state"]))
                state = context.Request["state"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["shareType"]))
                shareType = context.Request["shareType"].ToString().Trim();

            Twee.Mgr.ShareMgr mgr = new Twee.Mgr.ShareMgr();
            int totalCount = 0;
            string strWhere = "";
            string strOrderBy = "";

            // product name
            if (!string.IsNullOrEmpty(proName))
            {
                string sPrdNameSqlLike = CommUtil.GetSqlLike("wn_prd.name", proName);
                string sPrdTagSqlLike = CommUtil.GetSqlLike("wn_prd.txtTag", proName);
                // wn_share TT  prd p
                strWhere = " T.prtguid in ( select prdguid from wn_prd where ((" + sPrdNameSqlLike + ") or (" + sPrdTagSqlLike + ")))";
            }

            // sharer
            if (!string.IsNullOrEmpty(sharer))
            {
                string sSharerSqlLike = CommUtil.GetSqlLike("wn_user.username", sharer);
                if (strWhere != string.Empty) strWhere = strWhere + " and ";
                strWhere = strWhere +  " T.userGuid in ( select userGuid from wn_user where " + sSharerSqlLike + ")";
            }
            
            // share type
            if (!string.IsNullOrEmpty(shareType))
            {
                if (strWhere != string.Empty) strWhere = strWhere + " and ";
                strWhere = strWhere + " T.sharetype='" + shareType + "'";
            }

            if (!string.IsNullOrEmpty(startTime.Trim()))
            {
                string sStartTime = CommUtil.ToDBDateFormat(startTime.Trim());
                if (strWhere != string.Empty) strWhere = strWhere + " and ";
                strWhere = strWhere + " T.addtime>='" + sStartTime + " 0:00'";
            }

            if (!string.IsNullOrEmpty(endTime.Trim()))
            {
                string sEndTime = CommUtil.ToDBDateFormat(endTime.Trim());
                if (strWhere != string.Empty) strWhere = strWhere + " and ";
                strWhere = strWhere + " T.addtime<='" + sEndTime + " 23:59'" ;
            }

            var dt = mgr.MgeGetPersonShare(strWhere, strOrderBy, startId, endId, out totalCount);
            //if (dt == null || dt.Rows.Count == 0)
            //    return string.Empty;
            StringBuilder json = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {

                json.AppendFormat(",{0}  \"prdguid\":\"{2}\",\"prdname\":\"{3}\",\"sharetype\":\"{4}\",\"sharer\":\"{5}\",\"addtime\":\"{6}\",\"visitcount\":\"{7}\",\"successcount\":\"{8}\",\"shareurl\":\"{9}\"  {1}", "{", "}"
                    , row["prtguid"]._ObjToString(),
                    row["name"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["sharetype"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["username"]._ObjToString(),
                    ((DateTime)row["addtime"]).ToString("MM/dd/yyyy hh:mm"),
                    row["visitcount"]._ObjToString(),
                    row["successcount"]._ObjToString(),
                    row["shareurl"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;")
                    );
            }
            string temp_json = string.Empty;
            if (!string.IsNullOrEmpty(json.ToString()))
                temp_json = json.ToString().Substring(1);
            string res = "{\"total\":" + totalCount + ",\"rows\":[" + temp_json + "]}";
            return res;
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