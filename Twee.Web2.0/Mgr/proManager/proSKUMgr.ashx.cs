﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Twee.Comm;

namespace TweebaaWebApp2.Mgr.proManager
{
    /// <summary>
    /// Summary description for proSKUMgr1
    /// </summary>
    public class proSKUMgr1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (string.IsNullOrEmpty(context.Request["Action"]))
                context.Response.Write(string.Empty);

            string sAction = context.Request["Action"].ToString().Trim();
            switch (sAction)
            {
                case "SKUDataGrid":
                    context.Response.Write(SKUGridData(context));
                    break;
                default:
                    context.Response.Write(string.Empty);
                    break;
            }
        }

        private string SKUGridData(HttpContext context)
        {
            int iPageSize = int.Parse(context.Request["rows"]);
            int iIndex = int.Parse(context.Request["page"]) - 1;
            int iStartRow = iPageSize * iIndex + 1;
            int iEndRow = iStartRow + iPageSize - 1;
            string sProductName = string.Empty;
            string sProductUser = string.Empty;
            string sStartTime = string.Empty;
            string sEndTime = string.Empty;
            string sCategoryID = string.Empty;
            string sProductStatus = string.Empty;               
            string sTweebaaSKU = string.Empty;
            string sShipPartnerID = string.Empty;

            if (!string.IsNullOrEmpty(context.Request["ProductName"]))
                sProductName = context.Request["ProductName"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["ProductUser"]))
                sProductUser = context.Request["ProductUser"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["StartTime"]))
                sStartTime = context.Request["StartTime"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["endTime"]))
                sEndTime = context.Request["EndTime"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["CategoryID"]))
                sCategoryID = context.Request["CategoryID"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["ProductStatus"]))
                sProductStatus = context.Request["ProductStatus"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["TweebaaSKU"]))
                sTweebaaSKU = context.Request["TweebaaSKU"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["ShipPartnerID"]))
                sShipPartnerID = context.Request["ShipPartnerID"].ToString().Trim();

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
            var dt = mgr.SKUMgeGetList(sProductName, sTweebaaSKU, sShipPartnerID, sProductUser, sProductStatus, sCategoryID, sStartTime, sEndTime, string.Empty, iStartRow, iEndRow, out totalCount);
            StringBuilder json = new StringBuilder();
            
            foreach (DataRow row in dt.Rows)
            {
                json.AppendFormat(",{0}  \"prdguid\":\"{2}\",\"prdname\":\"{3}\",\"prdcate\":\"{4}\",\"count\":\"{5}\",\"saletotal\":\"{6}\",\"wnstat\":\"{7}\",\"username\":\"{8}\",\"addtime\":\"{9}\",\"stateremark\":\"{10}\",\"ranking\":\"{11}\"" +
                    ",\"TweebaaSKU\":\"{12}\"" +
                    ", \"ShipPartner\":\"{13}\"" +
                    ", \"SpecTypeName\":\"{14}\"" +
                    ", \"SpecName\":\"{15}\"" +
                    ", \"InvAvailable\":\"{16}\"" +
                    ", \"InvStockQuantityInConnecticut\":\"{17}\"" +
                    ", \"InvStockQuantityInNevada\":\"{18}\"" +
                    ", \"InvOtherQuantity\":\"{19}\"" +
                    ", \"InvCommittedQuantity\":\"{20}\"" +
                    ", \"InvAvailableQuantity\":\"{21}\"" +
                    ", \"InvLastUpdatedDate\":\"{22}\"" +
                    ", \"MinimumQuantity\":\"{23}\"" +
                    ", \"RuleID\":\"{24}\"" +
                    ", \"Color\":\"{25}\"" +
                    ", \"Weight\":\"{26}\"" +
                    ", \"PackageLength\":\"{27}\"" +
                    ", \"PackageWidth\":\"{28}\"" +
                    ", \"PackageHeight\":\"{29}\"" +
                    ", \"PackageWeight\":\"{30}\"" +
                    ", \"WholesalePrice\":\"{31}\"" +
                    " {1}", "{", "}"
                    , row["prdguid"]._ObjToString(),
                    row["name"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["typeName"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["sumCount"]._ObjToString(),
                    row["sumMoney"]._ObjToString(),
                    CommUtil.GetProductStatusName((int)(row["wnstat"]._ObjToString()._ToInt())),
                    row["username"]._ObjToString(),
                    row["addtime"]._ObjToString(),
                    row["stateremark"]._ObjToString().Replace(',', '，').Replace("\"", "&quot;"),
                    row["ranking"]._ObjToString(),
                    row["TweebaaSKU"]._ObjToString(),
                    CommUtil.GetShipPartnerName((int)row["ShipPartnerID"]),
                    row["SpecTypeName"]._ObjToString()._EscapeDoubleQuo(),
                    row["SpecName"]._ObjToString()._EscapeDoubleQuo(),
                    row["InventoryInfo_Available"]._ObjToString() == "1"? "Yes": "",
                    row["InventoryInfo_StockQuantityInConnecticut"]._ObjToString(),
                    row["InventoryInfo_StockQuantityInNevada"]._ObjToString(),
                    row["InventoryInfo_OtherQuantity"]._ObjToString(),
                    row["InventoryInfo_CommittedQuantity"]._ObjToString(),
                    row["InventoryInfo_AvailableQuantity"]._ObjToString(),
                    row["InventoryInfo_LastUpdatedDate"]._ObjToString(),
                    row["MinimumQuantity"]._ObjToString(),
                    row["RuleID"]._ObjToString(),
                    row["Color"]._ObjToString(),
                    row["Weight"]._ObjToString()._EscapeDoubleQuo(),
                    row["PackageLength"]._ObjToString()._EscapeDoubleQuo(),
                    row["PackageWidth"]._ObjToString()._EscapeDoubleQuo(),
                    row["PackageHeight"]._ObjToString()._EscapeDoubleQuo(),
                    row["PackageWeight"]._ObjToString()._EscapeDoubleQuo(),
                    row["WholesalePrice"]._ObjToString()
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