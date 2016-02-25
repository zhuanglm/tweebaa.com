using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using AjaxPro;
using System.Configuration;
using Twee.Comm;
using System.Xml;
using Newtonsoft.Json;
using Twee.Mgr;
using Twee.Model;


namespace TweebaaWebApp2.Mgr.proManager
{
    public partial class proSKUMgr : System.Web.UI.Page
    {

        public ListItem firstItem = new ListItem() { Value = "-1", Text = "--ALL--" };
        public string webAppDomain = string.Empty;

        Twee.Mgr.PrdCateMgr cateMgr = new Twee.Mgr.PrdCateMgr();
        Twee.Mgr.PrdMgr prdMgr = new Twee.Mgr.PrdMgr();

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(proSKUMgr));
            if (!IsPostBack)
            {
                webAppDomain = ConfigurationManager.AppSettings["webAppDomain"].Trim();
            }
 
        }

        [AjaxPro.AjaxMethod]
        public string GetFirstCate()
        {
            var cateModelList = cateMgr.GetModelList(" layer=0");
            if (cateModelList == null || cateModelList.Count == 0)
                return "fail";
            StringBuilder json = new StringBuilder();
            foreach (var item in cateModelList)
            {
                json.AppendFormat(",{2}\"value\":\"{0}\",\"text\":\"{1}\"{3}", item.guid, item.name, "{", "}");
            }
            if (!string.IsNullOrEmpty(json.ToString()))
                return "[{\"value\":\"-1\",\"text\":\"--ALL--\"}" + json.ToString() + "]";
            else
                return "fail";
        }

        [AjaxPro.AjaxMethod]
        public string GetNextCate(string parentId)
        {
            if (string.IsNullOrEmpty(parentId))
                return "fail";
            var sonModelList = cateMgr.GetModelList(" prtGuid='" + parentId + "'");
            if (sonModelList == null || sonModelList.Count == 0)
                return "fail";
            StringBuilder json = new StringBuilder();
            foreach (var item in sonModelList)
            {
                json.AppendFormat(",{2}\"value\":\"{0}\",\"text\":\"{1}\"{3}", item.guid, item.name, "{", "}");
            }
            if (!string.IsNullOrEmpty(json.ToString()))
                return "[{\"value\":\"-1\",\"text\":\"--ALL--\"}" + json.ToString() + "]";
            else
                return "fail";
        }

        [AjaxPro.AjaxMethod]
        public string WarehouseInventoryInfoUpdate()
        {
            try
            {
                ShipAPI.ShipOrder so = new ShipAPI.ShipOrder();
                bool bOK = so.WarehouseInventoryInfoUpdate((int)ConfigParamter.ShipPartner.Fosdick, false);
                if (bOK) return "1";
                else return "Failed to update warehouse inventory.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [AjaxPro.AjaxMethod]
        public string GetSKUDetail(int iRuleID)
        {
            try
            {   
                
                DataTable dt = prdMgr.MgeGetProductSKUDetail(iRuleID);
                string sInfo = JsonConvert.SerializeObject(dt);
                return sInfo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [AjaxPro.AjaxMethod]
        public string GetSpecTypeList(int iRuleID)
        {
            try
            {

                DataTable dt = prdMgr.MgeGetProductSpecTypeList();
                string sInfo = JsonConvert.SerializeObject(dt);
                return sInfo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [AjaxPro.AjaxMethod]
        public string SaveSKUDetail(int iRuleID, string sTweebaaSKU, int iSpecTypeID, string sSpecName, string sWholeSalePrice, int iMinimumStock, string sColor, string sWeight, string sPackageLength, string sPackageWidth, string sPackageHeight, string sPackageWeight)
        {
            try
            {

                int iCnt = prdMgr.MgeSaveProductSKUDetail(iRuleID, sTweebaaSKU, iSpecTypeID, sSpecName, sWholeSalePrice, iMinimumStock, sColor, sWeight, sPackageLength, sPackageWidth, sPackageHeight, sPackageWeight);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [AjaxPro.AjaxMethod]
        public string GetSKUShipToCountryList(int iRuleID)
        {
            try
            {

                DataTable dt = prdMgr.MgeGetSKUShipToCountryList(iRuleID);
                string sInfo = JsonConvert.SerializeObject(dt);
                return sInfo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [AjaxPro.AjaxMethod]
        public string SaveShipToCountry(int iRuleID, string sData)
        {
            // sData format :
            // Country id + [ Free] + ,
            // example 1 Free, 2, 3 free 
            try
            {
                string[] sShipToCountryArr = sData.ToUpper().Split(',');
                StringBuilder sSql = new StringBuilder();


                DB db = new DB();
                db.DBConnect();
                db.DBBeginTrans();

                // get rule info
                sSql.Clear();
                sSql.Append("select proid, userid from wn_prorules where id = " + iRuleID.ToString());
                DataSet dsRule = db.DBQuery(sSql.ToString()) ;
                DataRow drRule = dsRule.Tables[0].Rows[0];
                string sPrdGuid = drRule["proid"]._ObjToString();
                string sUserGuid = drRule["userid"]._ObjToString();

                // remove all existing ship to country
                sSql.Clear();
                sSql.Append("delete from wn_ProductShipToCountry ");
                sSql.Append(" where prdGuid ='" + sPrdGuid + "' and userGuid ='" + sUserGuid + "'");
                int iAffectedRow = db.DBExecute(sSql.ToString());

                // insert all new ship to countries
                foreach (string sShipToCountry in sShipToCountryArr)
                {
                    int iCountryID = -1;
                    string sCountryCode = string.Empty;
                    string sCountryName = string.Empty;
                    bool bFreeShip = sShipToCountry.IndexOf("FREE") == -1 ? false : true;
                    iCountryID = Int32.Parse(sShipToCountry.Replace("FREE", "").Trim());
                    
                    // get country info
                    sSql.Clear();
                    sSql.Append("select id, code, country from wn_country where id = " + iCountryID.ToString());
                    DataSet ds = db.DBQuery(sSql.ToString()) ;
                    DataRow dr = ds.Tables[0].Rows[0];
                    sCountryCode = dr["code"]._ObjToString();
                    sCountryName = dr["country"]._ObjToString();

                    // insert product ship to country 
                    sSql.Clear();
                    sSql.Append("insert into wn_ProductShipToCountry(prdGuid, userGuid, Country_ID, Country_Code, Country_Name, ProductShipToCountry_IsFree, ProductShipToCountry_CreateDate, ProductUploadBatchNo) ");
                    sSql.Append(" values(");
                    sSql.Append("'" + sPrdGuid + "',");
                    sSql.Append("'" + sUserGuid + "'," );
                    sSql.Append(iCountryID.ToString() + "," );
                    sSql.Append("'" + sCountryCode + "'," );
                    sSql.Append("'" + sCountryName + "'," );
                    sSql.Append((bFreeShip?"1":"0") +  "," );
                    sSql.Append("getdate()," );
                    sSql.Append("99999)");
                    iAffectedRow = db.DBExecute(sSql.ToString());
                }
                db.DBCommitTrans();
                db.DBDisconnect();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // insert product ship to country
        private int AddProductShipToCountry(string sPrdGuid, string sUserGuid, int iCountryID, string sCountryCode, string sCountryName, bool bFreeShip, int iProductUploadBatchNo)
        {
            int iAffectedRow = 0;

            // check if the recorded has alread existed
            string sSql = "select count(*) from wn_ProductShipToCountry where prdGuid='" + sPrdGuid + "' and userGuid ='" + sUserGuid + "' and Country_ID =" + iCountryID.ToString();
            int iCnt = DbHelperSQL.QueryCount(sSql);

            // insert a new one if not exist
            if (iCnt == 0)
            {
                sSql = "insert into wn_ProductShipToCountry(prdGuid, userGuid, Country_ID, Country_Code, Country_Name, ProductShipToCountry_IsFree, ProductShipToCountry_CreateDate, ProductUploadBatchNo) " +
                        " VALUES(" +
                        "'" + sPrdGuid + "'," +
                        "'" + sUserGuid + "'," +
                        iCountryID.ToString() + "," +
                        "'" + sCountryCode + "'," +
                        "'" + sCountryName + "'," +
                        (bFreeShip ? "1" : "0") + "," +
                        "getdate()," +
                        iProductUploadBatchNo.ToString() + ")";
                iAffectedRow = DbHelperSQL.ExecuteSql(sSql);
            }

            return iAffectedRow;
        }


    }
}