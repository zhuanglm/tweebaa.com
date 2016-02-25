using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Twee.Comm;

namespace TweebaaWebApp.Mgr.proManager
{
    /// <summary>
    /// proPublicJudgeMgr1 的摘要说明
    /// </summary>
    public class proPublicJudgeMgr1 : IHttpHandler
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
                case "tweedatagrid":
                    context.Response.Write(TweeGridData(context));
                    break;
                case "presaledatagrid":
                    context.Response.Write(PreSaleGridData(context));
                    break; 
                case "upsaledatagrid":
                    context.Response.Write(UpSaleGridData(context));
                    break;
                case "saleingdatagrid":
                    context.Response.Write(SaleingGridData(context));
                    break; 
                case "downdatagrid":
                    context.Response.Write(DownGridData(context));
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

            Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();
            int totalCount = 0;
            var dt = mgr.InitGetListReview(proName, proUser, state, cate, startTime, endTime, string.Empty, startId, endId, out totalCount);
            //if (dt == null || dt.Rows.Count == 0)
            //    return string.Empty;
            StringBuilder json = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                json.AppendFormat(",{0}  \"prdguid\":\"{2}\",\"prdname\":\"{3}\",\"prdcate\":\"{4}\",\"estimateprice\":\"{5}\",\"saleprice\":\"{6}\",\"wnstat\":\"{7}\",\"username\":\"{8}\",\"addtime\":\"{9}\",\"supplyprice\":\"{10}\",\"userid\":\"{11}\"  {1}", "{", "}"
                    , row["prdguid"]._ObjToString(),
                    row["name"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["cname"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    Math.Round((decimal)row["estimateprice"], 2)._ObjToString(),
                    row["saleprice"]._ObjToString(),
                    //row["count0"]._ObjToString(),
                    //row["count1"]._ObjToString(),
                    row["wnstat"]._ObjToString() == ((int)Twee.Comm.ConfigParamter.PrdSate.check).ToString() ? "初审中" : "初审失败",
                    row["username"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    ((DateTime)row["addtime"]).ToString("MM/dd/yyyy hh:mm"),
                    row["supplyPrice"]._ObjToString(),
                    row["userGuid"]._ObjToString()
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
            #region
            //            string res = @"{""total"":28,""rows"":[
//	{""productid"":""FI-SW-01"",""productname"":""Koi"",""unitcost"":10.00,""status"":""P"",""listprice"":36.50,""attr1"":""Large"",""itemid"":""EST-1""},
//	{""productid"":""K9-DL-01"",""productname"":""Dalmation"",""unitcost"":12.00,""status"":""P"",""listprice"":18.50,""attr1"":""Spotted Adult Female"",""itemid"":""EST-10""},
//	{""productid"":""RP-SN-01"",""productname"":""Rattlesnake"",""unitcost"":12.00,""status"":""P"",""listprice"":38.50,""attr1"":""Venomless"",""itemid"":""EST-11""},
//	{""productid"":""RP-SN-01"",""productname"":""Rattlesnake"",""unitcost"":12.00,""status"":""P"",""listprice"":26.50,""attr1"":""Rattleless"",""itemid"":""EST-12""},
//	{""productid"":""RP-LI-02"",""productname"":""Iguana"",""unitcost"":12.00,""status"":""P"",""listprice"":35.50,""attr1"":""Green Adult"",""itemid"":""EST-13""},
//	{""productid"":""FL-DSH-01"",""productname"":""Manx"",""unitcost"":12.00,""status"":""P"",""listprice"":158.50,""attr1"":""Tailless"",""itemid"":""EST-14""},
//	{""productid"":""FL-DSH-01"",""productname"":""Manx"",""unitcost"":12.00,""status"":""P"",""listprice"":83.50,""attr1"":""With tail"",""itemid"":""EST-15""},
//	{""productid"":""FL-DLH-02"",""productname"":""Persian"",""unitcost"":12.00,""status"":""P"",""listprice"":23.50,""attr1"":""Adult Female"",""itemid"":""EST-16""},
//	{""productid"":""FL-DLH-02"",""productname"":""Persian"",""unitcost"":12.00,""status"":""P"",""listprice"":89.50,""attr1"":""Adult Male"",""itemid"":""EST-17""},
//	{""productid"":""AV-CB-01"",""productname"":""Amazon Parrot"",""unitcost"":92.00,""status"":""P"",""listprice"":63.50,""attr1"":""Adult Male"",""itemid"":""EST-18""}
//]}";
             //{ field: 'prdguid', title: '产品ID', width: 80, hidden: true },
             //           { field: 'prdname', title: '产品名称', width: 80, sortable: true },
             //           { field: 'prdcate', title: '产品类别', width: 80, sortable: true },
             //           { field: 'estimateprice', title: '预估价格', width: 80, sortable: true },
             //           { field: 'saleprice', title: '销售价格', width: 80, sortable: true },
             //           { field: 'count0', title: '支持人数', width: 80, sortable: true },
             //           { field: 'count1', title: '反对人数', width: 80, sortable: true },
             //           { field: 'username', title: '发布者', width: 80, sortable: true },

            //int index = AspNetPager1.CurrentPageIndex - 1;
            //int startId = pageSize * index + 1;
            //int endId = startId + pageSize - 1;
            //DataTable dt = prd.MgeGetListReview(prdName, userName, "", "", startId, endId);
            #endregion

            int pageSize= int.Parse(context.Request["rows"]);
            int index = int.Parse(context.Request["page"])-1;
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

            Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();
            int totalCount = 0;
            var dt = mgr.MgeGetListReview(proName, proUser, state, cate, startTime, endTime, string.Empty, startId, endId,out totalCount);
            //if (dt == null || dt.Rows.Count == 0)
            //    return string.Empty;
            StringBuilder json = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                
                json.AppendFormat(",{0}  \"prdguid\":\"{2}\",\"prdname\":\"{3}\",\"prdcate\":\"{4}\",\"estimateprice\":\"{5}\",\"saleprice\":\"{6}\",\"count0\":\"{7}\",\"count1\":\"{8}\",\"wnstat\":\"{9}\",\"username\":\"{10}\",\"addtime\":\"{11}\",\"supplyprice\":\"{12}\"  {1}", "{", "}"
                    , row["prdguid"]._ObjToString(),
                    row["name"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["cname"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"), 
                    Math.Round((decimal)row["estimateprice"],2)._ObjToString(),
                    row["saleprice"]._ObjToString(),
                    row["count0"]._ObjToString(),
                    row["count1"]._ObjToString(),
                    row["wnstat"]._ObjToString() == ((int)Twee.Comm.ConfigParamter.PrdSate.review).ToString() ? "评审中" : "评审失败",
                    row["username"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    ((DateTime)row["addtime"]).ToString("MM/dd/yyyy hh:mm"),
                    row["supplyPrice"]._ObjToString()
                    );
            }
            string temp_json = string.Empty;
            if (!string.IsNullOrEmpty(json.ToString()))
                temp_json = json.ToString().Substring(1);
            string res = "{\"total\":" + totalCount + ",\"rows\":[" + temp_json + "]}";
            return res;
        }

        private string TweeGridData(HttpContext context)
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

            Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();
            int totalCount = 0;
            var dt = mgr.TweeMgeGetListReview(proName, proUser, state, cate, startTime, endTime, string.Empty, startId, endId, out totalCount);
            StringBuilder json = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                json.AppendFormat(",{0}  \"prdguid\":\"{2}\",\"prdname\":\"{3}\",\"prdcate\":\"{4}\",\"estimateprice\":\"{5}\",\"saleprice\":\"{6}\",\"count0\":\"{7}\",\"count1\":\"{8}\",\"wnstat\":\"{9}\",\"username\":\"{10}\",\"addtime\":\"{11}\",\"stateremark\":\"{12}\",\"presaleforward\":\"{13}\",\"presaleendtime\":\"{14}\"  {1}", "{", "}"
                    , row["prdguid"]._ObjToString(),
                    row["name"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["cname"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    Math.Round((decimal)row["estimateprice"],2)._ObjToString(),
                    row["saleprice"]._ObjToString(),
                    row["count0"]._ObjToString(),
                    row["count1"]._ObjToString(),
                    row["wnstat"]._ObjToString() == ((int)Twee.Comm.ConfigParamter.PrdSate.tweeReview).ToString() ? "评审中" : "评审失败",
                    row["username"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    ((DateTime)row["addtime"]).ToString("MM/dd/yyyy hh:mm"),
                    row["stateremark"]._ObjToString(),
                    row["presaleforward"]._ObjToString(),
                    row["presaleendtime"]._ObjToString()
                    );
            }
            string temp_json = string.Empty;
            if (!string.IsNullOrEmpty(json.ToString()))
                temp_json = json.ToString().Substring(1);
            string res = "{\"total\":" + totalCount + ",\"rows\":[" + temp_json + "]}";
            return res;
        }

        private string PreSaleGridData(HttpContext context)
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

            Func<string, string, string> saleTotalFuc = (count, price) => {
                if (string.IsNullOrEmpty(count) || string.IsNullOrEmpty(price))
                    return "0.00";
                if (string.IsNullOrEmpty(count.Trim()) || string.IsNullOrEmpty(price.Trim()))
                    return "0.00";
                return (decimal.Parse(count) * decimal.Parse(price)).ToString();
            };

            Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();
            int totalCount = 0;
            var dt = mgr.PreSaleMgeGetListReview(proName, proUser, state, cate, startTime, endTime, string.Empty, startId, endId, out totalCount);
            StringBuilder json = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                json.AppendFormat(",{0}  \"prdguid\":\"{2}\",\"prdname\":\"{3}\",\"prdcate\":\"{4}\",\"saleprice\":\"{5}\",\"count\":\"{6}\",\"saletotal\":\"{7}\",\"wnstat\":\"{8}\",\"username\":\"{9}\",\"addtime\":\"{10}\",\"stateremark\":\"{11}\",\"presaleforward\":\"{12}\",\"presaleendtime\":\"{13}\",\"hottip\":\"{14}\"  {1}", "{", "}"
                    , row["prdguid"]._ObjToString(),
                    row["name"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["cname"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["saleprice"]._ObjToString(),
                    row["count"]._ObjToString(),
                    saleTotalFuc(row["count"]._ObjToString(), row["saleprice"]._ObjToString()),
                    row["wnstat"]._ObjToString() == ((int)Twee.Comm.ConfigParamter.PrdSate.preSale).ToString() ? "评审中" : "评审失败",
                    row["username"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["addtime"]._ObjToString(),
                    row["stateremark"]._ObjToString(),
                     row["presaleforward"]._ObjToString(),
                     row["presaleendtime"]._ObjToString(),
                     row["hottip"]._ObjToString()
                    );
            }
            string temp_json = string.Empty;
            if (!string.IsNullOrEmpty(json.ToString()))
                temp_json = json.ToString().Substring(1);
            string res = "{\"total\":" + totalCount + ",\"rows\":[" + temp_json + "]}";
            return res;
        }

        private string UpSaleGridData(HttpContext context)
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

            Func<string, string, string> saleTotalFuc = (count, price) =>
            {
                if (string.IsNullOrEmpty(count) || string.IsNullOrEmpty(price))
                    return "0.00";
                if (string.IsNullOrEmpty(count.Trim()) || string.IsNullOrEmpty(price.Trim()))
                    return "0.00";
                return (decimal.Parse(count) * decimal.Parse(price)).ToString();
            };

            Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();
            int totalCount = 0;
            var dt = mgr.UpMgeGetListReview(proName, proUser, state, cate, startTime, endTime, string.Empty, startId, endId, out totalCount);
            StringBuilder json = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                json.AppendFormat(",{0}  \"prdguid\":\"{2}\",\"prdname\":\"{3}\",\"prdcate\":\"{4}\",\"saleprice\":\"{5}\",\"count\":\"{6}\",\"saletotal\":\"{7}\",\"wnstat\":\"{8}\",\"username\":\"{9}\",\"addtime\":\"{10}\",\"stateremark\":\"{11}\",\"presaleforward\":\"{12}\"  {1}", "{", "}"
                    , row["prdguid"]._ObjToString(),
                    row["name"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["cname"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["saleprice"]._ObjToString(),
                    row["count"]._ObjToString(),
                    saleTotalFuc(row["count"]._ObjToString(), row["saleprice"]._ObjToString()),
                    row["wnstat"]._ObjToString() == ((int)Twee.Comm.ConfigParamter.PrdSate.waitSale).ToString() ? "等待上架中" : "已拒绝上架",
                    row["username"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["addtime"]._ObjToString(),
                    row["stateremark"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["presaleforward"]._ObjToString()
                    );
            }
            string temp_json = string.Empty;
            if (!string.IsNullOrEmpty(json.ToString()))
                temp_json = json.ToString().Substring(1);
            string res = "{\"total\":" + totalCount + ",\"rows\":[" + temp_json + "]}";
            return res;
        }

        private string SaleingGridData(HttpContext context)
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
            string tweebaaSku = string.Empty;

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

            if (!string.IsNullOrEmpty(context.Request["tweebaaSku"]))
                tweebaaSku = context.Request["tweebaaSku"].ToString().Trim();

            Func<string, string, string> saleTotalFuc = (count, price) =>
            {
                if (string.IsNullOrEmpty(count) || string.IsNullOrEmpty(price))
                    return "0.00";
                if (string.IsNullOrEmpty(count.Trim()) || string.IsNullOrEmpty(price.Trim()))
                    return "0.00";
                return (decimal.Parse(count) * decimal.Parse(price)).ToString();
            };

            Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();
            int totalCount = 0;
            var dt = mgr.SaleingMgeGetList(proName, tweebaaSku, proUser, state, cate, startTime, endTime, string.Empty, startId, endId, out totalCount);
            StringBuilder json = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                json.AppendFormat(",{0}  \"prdguid\":\"{2}\",\"prdname\":\"{3}\",\"prdcate\":\"{4}\",\"count\":\"{5}\",\"saletotal\":\"{6}\",\"wnstat\":\"{7}\",\"username\":\"{8}\",\"addtime\":\"{9}\",\"stateremark\":\"{10}\"  {1}", "{", "}"
                    , row["prdguid"]._ObjToString(),
                    row["name"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["typeName"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["sumCount"]._ObjToString(),
                    row["sumMoney"]._ObjToString(),
                    row["wnstat"]._ObjToString() == ((int)Twee.Comm.ConfigParamter.PrdSate.sale).ToString() ? "销售中" : "",
                    row["username"]._ObjToString(),
                    row["addtime"]._ObjToString(),
                    row["stateremark"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;")
                    );
            }
            string temp_json = string.Empty;
            if (!string.IsNullOrEmpty(json.ToString()))
                temp_json = json.ToString().Substring(1);
            string res = "{\"total\":" + totalCount + ",\"rows\":[" + temp_json + "]}";
            return res;
        }

        private string DownGridData(HttpContext context)
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

            Func<string, string, string> saleTotalFuc = (count, price) =>
            {
                if (string.IsNullOrEmpty(count) || string.IsNullOrEmpty(price))
                    return "0.00";
                if (string.IsNullOrEmpty(count.Trim()) || string.IsNullOrEmpty(price.Trim()))
                    return "0.00";
                return (decimal.Parse(count) * decimal.Parse(price)).ToString();
            };

            Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();
            int totalCount = 0;
            var dt = mgr.DownMgeGetList(proName, proUser, state, cate, startTime, endTime, string.Empty, startId, endId, out totalCount);
            StringBuilder json = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                json.AppendFormat(",{0}  \"prdguid\":\"{2}\",\"prdname\":\"{3}\",\"prdcate\":\"{4}\",\"count\":\"{5}\",\"saletotal\":\"{6}\",\"wnstat\":\"{7}\",\"username\":\"{8}\",\"addtime\":\"{9}\",\"stateremark\":\"{10}\"  {1}", "{", "}"
                    , row["prdguid"]._ObjToString(),
                    row["name"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["typeName"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["sumCount"]._ObjToString(),
                    row["sumMoney"]._ObjToString(),
                    row["wnstat"]._ObjToString() == ((int)Twee.Comm.ConfigParamter.PrdSate.sale).ToString() ? "销售中" : "",
                    row["username"]._ObjToString(),
                    row["addtime"]._ObjToString(),
                    row["stateremark"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;")
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