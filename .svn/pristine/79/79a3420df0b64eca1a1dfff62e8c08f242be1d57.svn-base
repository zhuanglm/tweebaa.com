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
    public partial class proSupply : System.Web.UI.Page
    {
        public string _sPrdGuid = string.Empty;
        Twee.Mgr.PrdMgr prdMgr = new Twee.Mgr.PrdMgr();

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(proSupply));

            if (string.IsNullOrEmpty(Request["id"]))
                return;
            else
                _sPrdGuid = Request["id"].Trim();
            // test _sPrdGuid = "12d1ba33-3c7d-4f29-b418-44c2684b4ccb";
            if (!IsPostBack)
            {
                ShowItemList();
            }
        }


        private bool ShowItemList()
        {

            // clear the gird data view
            gdvItem.DataSource = null;
            gdvItem.DataBind();

            lblProductGuid.Text = _sPrdGuid;
            Twee.Model.Prd prdModel = prdMgr.GetModel((Guid)_sPrdGuid.ToGuid());
            lblProductName.Text = prdModel.name;
            
            lblEstimatePrice.Text = string.Empty;
            if (prdModel.estimateprice != null)
                lblEstimatePrice.Text = ((decimal)prdModel.estimateprice).ToString("$#0.00");

            lblSalePrice.Text = string.Empty;
            if (prdModel.saleprice != null)
                lblSalePrice.Text = ((decimal)prdModel.saleprice).ToString("$#0.00");

            lblMinimumOrderQuantity.Text = string.Empty;
            if (prdModel.moq != null)
                lblMinimumOrderQuantity.Text = prdModel.moq._ObjToString();

            DataTable dt = prdMgr.MgeGetProductSupplyList(_sPrdGuid);
            if (dt == null) return false;
            if (dt.Rows.Count == 0) return false;
            DataRow dr = dt.Rows[0];

            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add(new DataColumn("RuleID", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("TweeBaaSku", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("SupplierSku", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("SpecType", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("SpecName", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("Color", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("SalePrice", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("WholesalePrice", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("SupplierShipFee", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("Weight", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("PackageLength", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("PackageWidth", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("PackageHeight", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("PackageWeight", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("SupplierName", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("SupplierStatus", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("SupplierEmail", typeof(string)));
            foreach (DataRow drItem in dt.Rows)
            {
                DataRow drGrid = dtGrid.NewRow();
                drGrid["RuleID"] = drItem["id"]._ObjToString();
                drGrid["TweebaaSku"] = drItem["prosku"]._ObjToString();
                drGrid["SupplierSku"] = drItem["SupplierSku"]._ObjToString();
                drGrid["SpecType"] = drItem["SpecType"]._ObjToString();
                drGrid["SpecName"] = drItem["SpecName"]._ObjToString();
                drGrid["Color"] = drItem["Color"]._ObjToString();
                if (drItem["SalePrice"] != DBNull.Value)
                {
                    drGrid["SalePrice"] = decimal.Parse(drItem["SalePrice"].ToString()).ToString("$#0.00");
                }
                if (drItem["WholesalePrice"] != DBNull.Value)
                {
                    drGrid["WholesalePrice"] = decimal.Parse(drItem["WholesalePrice"].ToString()).ToString("$#0.00");
                }
                if (drItem["SupplierShipFee"] != DBNull.Value)
                {
                    drGrid["SupplierShipFee"] = decimal.Parse(drItem["SupplierShipFee"].ToString()).ToString("$#0.00");
                }
                drGrid["Weight"] = drItem["proWeight"]._ObjToString();
                drGrid["PackageLength"] = drItem["PackageLength"]._ObjToString();
                drGrid["PackageWidth"] = drItem["PackageWidth"]._ObjToString();
                drGrid["PackageHeight"] = drItem["PackageHeight"]._ObjToString();
                drGrid["PackageWeight"] = drItem["PackageWeight"]._ObjToString();
                drGrid["SupplierName"] = drItem["SupplierName"]._ObjToString();
                drGrid["SupplierEmail"] = drItem["SupplierEmail"]._ObjToString();
                drGrid["SupplierStatus"] = string.Empty;
                if (drItem["SupplierStatus"] != DBNull.Value) {
                    drGrid["SupplierStatus"] = CommUtil.GetInventoryStatusName((int)drItem["SupplierStatus"]);
                }
                //drGrid["TrackingNo"] = "<a target=\"_blank\" href=\"" + CommUtil.GetTrackingLink(sCarrierName, sTrackingNo) + "\">" + sTrackingNo + "</a>";

                dtGrid.Rows.Add(drGrid);
                //dtGrid.Rows.Add("aaa", "bbb");
            }

            gdvItem.Visible = true;
            gdvItem.AutoGenerateColumns = false;
            gdvItem.DataSource = dtGrid;
            gdvItem.DataBind();

            return true;
        }

        protected void gdvItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
            }
//            e.Row.Cells[3].Visible = false;  // file guid column
//            e.Row.Cells[4].Visible = false;  // image rule id column
        }

        private int GetColumnIndexByName(GridView grid, string name)
        {
            foreach (DataControlField col in grid.Columns)
            {
                if (col.HeaderText.ToLower().Trim() == name.ToLower().Trim())
                {
                    return grid.Columns.IndexOf(col);
                }
            }

            return -1;
        }

        protected void btnEditItem_Click(object sender, EventArgs e)
        {
        }

        protected void btnDeleteItem_Click(object sender, EventArgs e)
        {
            Button btnDelete = sender as Button;
            int rowIndex = Convert.ToInt32(btnDelete.Attributes["RowIndex"]);
            GridViewRow row = gdvItem.Rows[rowIndex];

            int iRuleID = int.Parse(row.Cells[0].Text);
            proRulesMgr ruleMgr = new proRulesMgr();
            
            string sErrMsg = string.Empty;
            bool bOK = ruleMgr.MgeDelete(iRuleID, out sErrMsg);
            if (bOK)
            {
                Response.Write("<script>alert('Selected item has been deleted successfully!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Delete Error: " +  sErrMsg + "!');</script>");
            }
            ShowItemList();

        }
        protected void gdvItem_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        [AjaxPro.AjaxMethod]
        public string GetSpecTypeList()
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
        public string GetCountryList()
        {
            try
            {
                CountryMgr countryMgr = new CountryMgr();
                DataSet ds = countryMgr.GetAllList();
                string sInfo = JsonConvert.SerializeObject(ds.Tables[0]);
                return sInfo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [AjaxPro.AjaxMethod]
        public string GetUserGuid(string sEmail, string sPassword)
        {
            try
            {
                UserMgr userMgr = new UserMgr();
                string sUserGuid = userMgr.GetUserGuid(sEmail, sPassword);
                return sUserGuid;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [AjaxPro.AjaxMethod]
        public string IsTweebaaSKUExist(string sTweebaaSKU)
        {
            try
            {
                PrdMgr prdMgr = new PrdMgr();
                bool bExist = prdMgr.IsTweebaaSKUExist(sTweebaaSKU);

                return bExist ? "1" : "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        [AjaxPro.AjaxMethod]
        public string GetProvinceList(string sCountryID)
        {
            try
            {   int iCurCountryID = int.Parse(sCountryID);
                ProvinceMgr countryMgr = new ProvinceMgr();
                DataSet ds = countryMgr.GetList(" countryId =" + iCurCountryID.ToString());
                string sInfo = JsonConvert.SerializeObject(ds.Tables[0]);
                return sInfo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [AjaxPro.AjaxMethod]
        public string UpdateSupply(
                    int iRuleID,
                    string sPrdGuid,
                    string sSupplierEmail,
                    string sSupplierPassword,
                    string sSupplierUserGuid,
                    string sTweebaaSKU,
                    string sSupplierSKU,
                    string sSpecType,
                    string sSpecName,
                    string sSalePrice,  // sale price of this rule 
                    string sWholesalePrice,
                    string sSupplierShipFee,
                    string sMinQty,
                    string sColor,
                    string sWeight,
                    string sPackageWeight,
                    string sPackageLength,
                    string sPackageWidth,
                    string sPackageHeight,
                    string sShipToCountry,
                    string sShipFromSupplierID,
                    string sShipFromCompanyName,
                    string sShipFromContactName,
                    string sShipFromAddress,
                    string sShipFromZip,
                    string sShipFromCity,
                    string sShipFromCountry,
                    string sShipFromProvince,
                    string sShipFromPhone,
                    string sShipFromEmail,
                    string sShipFromWebSite,
                    string sShipMethodName
            )
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("select ShipFrom_ID,  SupplierShipMethodName from wn_prorules ");
                sSql.Append(" where id=" + iRuleID.ToString());
                DataSet ds = DbHelperSQL.Query(sSql.ToString());
                if (ds == null || ds.Tables.Count <= 0) return "Rule ID: " + iRuleID.ToString() + " does not exist!";
                DataTable dt = ds.Tables[0];
                if (dt == null || dt.Rows.Count <= 0) return "Rule ID: " + iRuleID.ToString() + " does not exist!";
                DataRow dr = dt.Rows[0];

                int iShipFromID = dr["ShipFrom_ID"].ToString().ToInt();
                string sOldShipMethidName = dr["SupplierShipMethodName"]._ObjToString();
                int iProductUploadBatchNo = 0;

                bool bOK = false;
                DB db = new DB();
                db.DBConnect();
                db.DBBeginTrans();
                string sErrMsg = string.Empty;

                // updat Ship from
                sSql.Clear();
                sSql.Append("update wn_ShipFrom set ");
                sSql.Append(" ShipFrom_CompanyName ='" + CommUtil.Quo(sShipFromCompanyName) + "'," );
                sSql.Append(" ShipFrom_Address1 ='" + CommUtil.Quo(sShipFromAddress) + "',");
                sSql.Append(" ShipFrom_ContactName ='" + CommUtil.Quo(sShipFromContactName) + "',");
                sSql.Append(" ShipFrom_Phone ='" + CommUtil.Quo(sShipFromPhone) + "'," );
                sSql.Append(" ShipFrom_Email ='" + CommUtil.Quo(sShipFromEmail) + "'," );
                sSql.Append(" ShipFrom_WebSite ='" + CommUtil.Quo(sShipFromWebSite) + "'," );
                sSql.Append(" ShipFrom_City ='" + CommUtil.Quo(sShipFromCity) + "'," );
                sSql.Append(" ShipFrom_Zip ='" + CommUtil.Quo(sShipFromZip) + "'," );
                sSql.Append(" Province_ID =" + sShipFromProvince + ",");
                sSql.Append(" Country_ID =" + sShipFromCountry + "," );
                sSql.Append(" ShipFrom_ShipToCountries ='" + CommUtil.Quo(sShipToCountry) + "'" );
                sSql.Append(" where ShipFrom_ID=" + iShipFromID);
                int iAffectedRow = db.DBExecute(sSql.ToString());

                // update ship method for all countries
                bOK = UpdateShipMethod( db, iShipFromID, sShipMethodName, sOldShipMethidName, sShipToCountry, out sErrMsg);

                bOK = SaveShipToCountry(db, sPrdGuid, sSupplierUserGuid, sShipToCountry, iProductUploadBatchNo, out sErrMsg);
                if (!bOK) return sErrMsg;

                // product rules  
                sSql.Clear();
                sSql.Append("update wn_proRules set " );
                sSql.Append(" suppliersku='" + CommUtil.Quo(sSupplierSKU) + "'," );
                sSql.Append(" color='" + CommUtil.Quo(sColor) + "',");
                sSql.Append(" proweight='" + CommUtil.Quo(sWeight) + "',");
                sSql.Append(" PackageWeight='" + CommUtil.Quo(sPackageWeight) + "',");
                sSql.Append(" PackageLength='" + CommUtil.Quo(sPackageLength) + "',");
                sSql.Append(" PackageWidth='" + CommUtil.Quo(sPackageWidth) + "',");
                sSql.Append(" PackageHeight='" + CommUtil.Quo(sPackageHeight) + "',");
                sSql.Append(" prostock='" + CommUtil.Quo(sMinQty) + "',");
                sSql.Append(" proruletitle=" + int.Parse(sSpecType).ToString() + ",");
                sSql.Append(" prorule='" + CommUtil.Quo(sSpecName) + "',");
                sSql.Append(" SupplierShipFee=" + sSupplierShipFee + ",");
                sSql.Append(" WholeSalePrice=" + sWholesalePrice + ",");
                sSql.Append(" SupplierShipMethodName='" + sShipMethodName + "'");
                sSql.Append(" where id=" + iRuleID.ToString());
                iAffectedRow = db.DBExecute(sSql.ToString());

                // update price
                sSql.Clear();
                sSql.Append("update wn_prdPrice set price =" + sSalePrice );
                sSql.Append(" where prdGuid ='" + sPrdGuid + "'" );
                sSql.Append("   and ruleid =" + iRuleID.ToString() );
                sSql.Append("   and p1 <=1 ");
                iAffectedRow = db.DBExecute(sSql.ToString());

                db.DBCommitTrans();
                db.DBDisconnect();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private int AddShipInfo(DB db, string ShipFrom_CompanyName, string ShipFrom_Address1, string ShipFrom_ContactName, string ShipFrom_Phone, string ShipFrom_Email, string ShipForm_WebSite, string ShipFrom_City, string Province_ID, string ShipFrom_Zip, string Country_ID, string Supplier_Address, string userguid, string SupperID, int iProductUploadBatchNo, string ShiptoCountries, out bool bIsNewShipFrom)
        {

            string sqlCount = "select ShipFrom_ID,ShipFrom_CompanyName from wn_ShipFrom where ShipFrom_CompanyName=N'" + CommUtil.Quo(ShipFrom_CompanyName) + "' and  ShipFrom_Phone='" + ShipFrom_Phone + "'";
            DataSet dsCount = db.DBQuery(sqlCount);
            if (dsCount != null && dsCount.Tables.Count > 0 && dsCount.Tables[0].Rows.Count > 0)
            {
                int iOldShipFromID = dsCount.Tables[0].Rows[0]["ShipFrom_ID"].ToString().ToInt();
                bIsNewShipFrom = false;
                return iOldShipFromID;
            }

            int iNewShipFromID = db.DBGetSeq("ShipFrom");
            string sql = "insert into dbo.wn_ShipFrom (ShipFrom_ID, ShipFrom_CompanyName,ShipFrom_Address1,ShipFrom_Address2,ShipFrom_ContactName,ShipFrom_Phone,ShipFrom_Email,ShipFrom_WebSite,ShipFrom_City,Province_ID,ShipFrom_Zip,Country_ID, ShipFrom_AddDate,ShipFrom_IsActive,userguid,Supplier_ID, ShipFrom_ShipToCountries, ProductUploadBatchNo) values (" + iNewShipFromID + ",N'" + CommUtil.Quo(ShipFrom_CompanyName) + "',N'" + CommUtil.Quo(ShipFrom_Address1) + "','',N'" + CommUtil.Quo(ShipFrom_ContactName) + "','" + ShipFrom_Phone + "','" + ShipFrom_Email + "','" + ShipForm_WebSite + "','" + ShipFrom_City + "','" + Province_ID + "','" + ShipFrom_Zip + "','" + Country_ID + "', GETDATE(),1,'" + userguid + "','" + SupperID + "','" + ShiptoCountries + "'," + iProductUploadBatchNo.ToString() + ");";
            int resu = db.DBExecute(sql);
            bIsNewShipFrom = true;
            return iNewShipFromID;

        }


        private bool AddShipMethod(DB db, int iShipFromID, string sShipFromName, int iProductUploadBatchNo, string sShipToCountries, out string sErrMsg)
        {
            int iShipMethodID = -1;
            sErrMsg = string.Empty;

            StringBuilder sSql = new StringBuilder();
            sSql.Append("select a.ShipMethod_ID from wn_ShipMethod a inner join wn_ShipFrom2ShipMethod b on a.ShipMethod_ID = b.ShipMethod_ID");
            sSql.Append(" where a.ShipMethod_Name =N'" + CommUtil.Quo(sShipFromName) + "'");
            sSql.Append("  and b.ShipFrom_ID=" + iShipFromID.ToString());

            DataSet dsCount = db.DBQuery(sSql.ToString());
            if (dsCount != null && dsCount.Tables.Count > 0 && dsCount.Tables[0].Rows.Count > 0)
            {
                iShipMethodID = dsCount.Tables[0].Rows[0]["ShipMethod_ID"].ToString().ToInt();
                return true;
            }

            // Add new ship method for all countries
            string[] sShipToCountryArr = sShipToCountries.Split(',');
            foreach (string sShipToCountry in sShipToCountryArr)
            {
                string sCountryID = sShipToCountry.ToUpper();

                bool bFreeShip = sCountryID.IndexOf("FREE") == -1 ? false : true;
                sCountryID = sCountryID.Replace("FREE", "").Trim();

 
                // ship method
                sSql.Clear();
                iShipMethodID = db.DBGetSeq("ShipMethodID");
                sSql.Append(" INSERT INTO wn_ShipMethod (ShipMethod_ID, ShipPartner_ID, ShipCarrier_ID, ShipMethod_ServiceID, ShipMethod_Name, ShipMethod_ShipToCountryID, ShipMethod_IsFree, ShipMethod_IsActive, ProductUploadBatchNo)");
                sSql.Append(" VALUES( ");
                sSql.Append(iShipMethodID.ToString() + "," +
                    ((int)ConfigParamter.ShipPartner.DropShipper).ToString() + "," +
                    "1,0,N'" + CommUtil.Quo(sShipFromName) + "'," +
                    sCountryID + "," +
                    (bFreeShip ? "1," : "0,") +
                    "1," +
                    iProductUploadBatchNo.ToString() + ")");
                int resu = db.DBExecute(sSql.ToString());

                // insert Shipfrom2ShipMethod
                sSql.Clear();
                sSql.Append("insert into wn_ShipFrom2ShipMethod(ShipFrom_ID, ShipMethod_ID, ProductUploadBatchNo) values(" +
                    iShipFromID.ToString() + "," +
                    iShipMethodID.ToString() + "," +
                    iProductUploadBatchNo.ToString() + ")");
                resu = db.DBExecute(sSql.ToString());
            }

            return true;
        }





        private bool SaveShipToCountry(DB db, string sPrdGuid, string sSupplierUserGuid, string sShipToCountries, long iProductUploadBatchNo, out string sErrMsg)
        {
            sErrMsg = string.Empty;
            StringBuilder sSql = new StringBuilder();
            try {
                // remove current ship to country of this supplier for this product
                sSql.Append("delete from wn_ProductShipToCountry ");
                sSql.Append(" where prdguid ='" + sPrdGuid + "'");
                sSql.Append("   and userGuid ='" + sSupplierUserGuid + "'");
                int iCnt = db.DBExecute(sSql.ToString());
            
                // Add new ship to countries
                string[] sShipToCountryArr = sShipToCountries.Split(',');
                foreach (string sShipToCountry in sShipToCountryArr)
                {
                    string sCountryID = sShipToCountry.ToUpper();

                    bool bFreeShip = sCountryID.IndexOf("FREE") == -1 ? false : true;
                    sCountryID = sCountryID.Replace("FREE", "").Trim();

                    sSql.Clear();
                    sSql.Append("select country, code from wn_country where id=" + sCountryID);
                    DataSet ds = db.DBQuery(sSql.ToString());
                    DataRow dr = ds.Tables[0].Rows[0];

                    string sCountryCode = dr["code"].ToString();
                    string sCountryName = dr["country"].ToString();

                    sSql.Clear();
                    sSql.Append("insert into wn_ProductShipToCountry(prdGuid, userGuid, Country_ID, Country_Code, Country_Name, ProductShipToCountry_IsFree, ProductShipToCountry_CreateDate, ProductUploadBatchNo) " +
                                " VALUES(" +
                                "'" + sPrdGuid + "'," +
                                "'" + sSupplierUserGuid + "'," +
                                sCountryID + "," +
                                "'" + sCountryCode + "'," +
                                "'" + sCountryName + "'," +
                                (bFreeShip ? "1" : "0") + "," +
                                "getdate()," +
                                iProductUploadBatchNo.ToString() + ")");
                     iCnt = db.DBExecute(sSql.ToString());
                }
                return true;
            }
            catch (Exception ex) {
                sErrMsg = ex.Message;
                db.DBRollbackTrans();
                db.DBConnect();
                return false;
            }
        }

        [AjaxPro.AjaxMethod]
        public string GetRuleInfo(string sPrdGuid, string sTweebaaSKU)
        {
            try
            {
                proRulesMgr ruleMgr = new proRulesMgr();
                DataTable dt = ruleMgr.MgeGetRuleInfo(sPrdGuid, sTweebaaSKU);
                string sInfo = JsonConvert.SerializeObject(dt);
                return sInfo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [AjaxPro.AjaxMethod]
        public string GetTweebaaSKU(int iRuleID)
        {
            try
            {
                proRulesMgr ruleMgr = new proRulesMgr();
                proRules model = ruleMgr.GetModel(iRuleID);
                string sPrdGuid = model.proid;
                string sTweebaaSKU = model.prosku;
                return sTweebaaSKU;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [AjaxPro.AjaxMethod]
        public string GetSupplierUserGuid(int iRuleID)
        {
            try
            {
                proRulesMgr ruleMgr = new proRulesMgr();
                proRules model = ruleMgr.GetModel(iRuleID);
                string sSupplierUserGuid = model.userid;
                return sSupplierUserGuid;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        [AjaxPro.AjaxMethod]
        public string GetRuleSalePrice(int iRuleID, int intQty)
        {
            try
            {
                PrdPriceMgr priceMgr = new PrdPriceMgr();
                decimal? dPrice = priceMgr.GetSalePrice(iRuleID, intQty);
                if (dPrice != null) return ((decimal)dPrice).ToString("#0.00");
                else return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [AjaxPro.AjaxMethod]
        public string GetShipFromInfo(int iShipFromID)
        {
            try
            {
                PrdMgr prdMgr = new PrdMgr();
                DataTable dt = prdMgr.MgeGetShipFromInfo(iShipFromID);
                string sInfo = JsonConvert.SerializeObject(dt);
                return sInfo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [AjaxPro.AjaxMethod]
        public string GetShipMethod(int iShipFromID)
        {
            try
            {
                PrdMgr prdMgr = new PrdMgr();
                DataTable dt = prdMgr.MgeGetShipMethod(iShipFromID);
                string sInfo = JsonConvert.SerializeObject(dt);
                return sInfo;
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
        public string GetNewTweebaaSKU()
        {
            try
            {
                string sNewTweebaaSKU = CommUtil.CreateTweebaaSKU();
                return sNewTweebaaSKU; 
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [AjaxPro.AjaxMethod]
        public string SaveNewSupply(
                    string sPrdGuid,
                    string sSupplierEmail,
                    string sSupplierPassword,
                    string sSupplierUserGuid,
                    string sTweebaaSKU,
                    string sSupplierSKU,
                    string sSpecType,
                    string sSpecName,
                    string sSalePrice,  // sale price of this rule 
                    string sWholesalePrice,
                    string sSupplierShipFee,
                    string sMinQty,
                    string sColor,
                    string sWeight,
                    string sPackageWeight,
                    string sPackageLength,
                    string sPackageWidth,
                    string sPackageHeight,
                    string sShipToCountry,
                    string sShipFromSupplierID,
                    string sShipFromCompanyName,
                    string sShipFromContactName,
                    string sShipFromAddress,
                    string sShipFromZip,
                    string sShipFromCity,
                    string sShipFromCountry,
                    string sShipFromProvince,
                    string sShipFromPhone,
                    string sShipFromEmail,
                    string sShipFromWebSite,
                    string sShipMethodName
            )
        {
            try
            {
                //Twee.Model.Prd prdModel = prdMgr.GetModel((Guid)sPrdGuid.ToGuid());

                DB db = new DB();
                db.DBConnect();
                db.DBBeginTrans();
                string sErrMsg = string.Empty;

                int iProductUploadBatchNo = db.DBGetSeq("ProductUploadBatchNo");
                // shipping from 
                bool bIsNewShipFrom = true;
                int ShipFrom_ID = AddShipInfo(db, sShipFromCompanyName, sShipFromAddress, sShipFromContactName, sShipFromPhone, sShipFromEmail, sShipFromWebSite, sShipFromCity, sShipFromProvince, sShipFromZip, sShipFromCountry, sShipFromAddress, sSupplierUserGuid.ToString(), sShipFromSupplierID, iProductUploadBatchNo, sShipToCountry, out bIsNewShipFrom);

                // shipping method
                bool bOK = AddShipMethod(db, ShipFrom_ID, sShipMethodName, iProductUploadBatchNo, sShipToCountry, out sErrMsg);

                bOK = SaveShipToCountry(db, sPrdGuid, sSupplierUserGuid, sShipToCountry, iProductUploadBatchNo, out sErrMsg);
                if (!bOK) return sErrMsg;

                // product rules    
                proRulesMgr ruleMgr = new proRulesMgr();
                proRules rules = new proRules();
                rules.ShipFrom_ID = ShipFrom_ID;
                rules.prosku = sTweebaaSKU;
                rules.suppliersku = sSupplierSKU;
                rules.proid = sPrdGuid;
                rules.userid = sSupplierUserGuid;
                rules.procolor = sColor;

                rules.proweight = sWeight;
                // rules.prolength = "0";
                // rules.prowidth  = "0";
                // rules.proheight = "0";

                //rules.proboxweight = proboxweight;
                //rules.proboxlength = proboxlength;
                //rules.proboxwidth = proboxwidth;
                //rules.proboxheight = proboxheight;

                rules.packageweight = sPackageWeight;
                rules.packagelength = sPackageLength;
                rules.packagewidth = sPackageWidth;
                rules.packageheight = sPackageHeight;

                rules.prostock = sMinQty;
                rules.ShipPartner_ID = (int)(ConfigParamter.ShipPartner.DropShipper);
                rules.proruletitle = int.Parse(sSpecType);
                rules.prorule = sSpecName;
                rules.UpLoadBatchNo = iProductUploadBatchNo; // upload batch number
                rules.isCustomerFreeShip = 0;
                rules.SupplierShipFee = decimal.Parse(sSupplierShipFee);
                rules.WholeSalePrice = sWholesalePrice;
                rules.SupplierShipMethodName = sShipMethodName;
                //rules.barcode = UPCCode;

                int iNewRuleID = ruleMgr.Add(rules);

                // price  
                Prdprice priceModel = new Prdprice();
                priceModel.edttime = DateTime.Now;
                priceModel.p1 = 1;
                priceModel.p2 = 10000;
                priceModel.prdguid = (Guid)sPrdGuid.ToGuid();
                priceModel.price = decimal.Parse(sSalePrice);
                priceModel.ruleid = iNewRuleID;
                priceModel.UpLoadBatchNo = iProductUploadBatchNo;
                PrdPriceMgr priceMgr = new PrdPriceMgr();
                priceMgr.Add2(priceModel);

                // basic supplier info 供货单基本信息
                proDetailsMgr proDetailsMgr = new proDetailsMgr();
                Twee.Model.proDetails modelOld = new Twee.Model.proDetails();
                modelOld = proDetailsMgr.GetModel(sPrdGuid, sSupplierUserGuid);
                if (modelOld == null)
                {
                    Twee.Model.proDetails modelNew = new Twee.Model.proDetails();
                    modelNew.proid = sPrdGuid;
                    modelNew.proright = 1;
                    modelNew.proaddress = "1";
                    modelNew.proexample = 1;
                    modelNew.proexampleprice = null;
                    modelNew.prosmallnum = "1";
                    modelNew.promodelnum = " ";
                    modelNew.prostock = 1;
                    modelNew.stocknum = null;
                    modelNew.state = (int)ConfigParamter.InventoryState.submit;
                    modelNew.userid = sSupplierUserGuid;
                    modelNew.UpLoadBatchNo = iProductUploadBatchNo;

                    proDetailsMgr.Add2(modelNew);
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


        private bool UpdateShipMethod(DB db, int iShipFromID, string sNewShipMethodName, string sOldShipMethodName, string sShipToCountries, out string sErrMsg)
        {
            int iShipMethodID = -1;
            sErrMsg = string.Empty;
            string sShipToCountryIDList = string.Empty;
            int iAffectedRow = 0;
            StringBuilder sSql = new StringBuilder();

            // Add new ship method for all countries
            string[] sShipToCountryArr = sShipToCountries.Split(',');
            foreach (string sShipToCountry in sShipToCountryArr)
            {
                string sCountryID = sShipToCountry.ToUpper();

                bool bFreeShip = sCountryID.IndexOf("FREE") == -1 ? false : true;
                sCountryID = sCountryID.Replace("FREE", "").Trim();
                
                // set the ship to country list
                if (sShipToCountryIDList != string.Empty) sShipToCountryIDList += ",";
                sShipToCountryIDList += sCountryID;

                sSql.Clear();
                sSql.Append("select a.ShipMethod_ID from wn_ShipMethod a inner join wn_ShipFrom2ShipMethod b on a.ShipMethod_ID = b.ShipMethod_ID");
                sSql.Append(" where a.ShipMethod_Name =N'" + CommUtil.Quo(sOldShipMethodName) + "'");
                sSql.Append("  and b.ShipFrom_ID=" + iShipFromID.ToString());

                DataSet dsCount = db.DBQuery(sSql.ToString());
                if (dsCount != null && dsCount.Tables.Count > 0 && dsCount.Tables[0].Rows.Count > 0)
                {
                    iShipMethodID = dsCount.Tables[0].Rows[0]["ShipMethod_ID"].ToString().ToInt();
                    sSql.Clear();
                    sSql.Append("update wn_ShipMethod set ");
                    sSql.Append("ShipMethod_Name ='" + CommUtil.Quo(sNewShipMethodName) + "',");
                    sSql.Append("ShipMethod_IsFree =" + (bFreeShip?"1":"0") );
                    sSql.Append(" where ShipMethod_ID=" + iShipMethodID.ToString());
                    iAffectedRow = db.DBExecute(sSql.ToString());
                }
                else
                {
                    // add new ship method and Shipfrom2Shipmethod for this country
 
                    // ship method
                    sSql.Clear();
                    iShipMethodID = db.DBGetSeq("ShipMethodID");
                    sSql.Append(" INSERT INTO wn_ShipMethod (ShipMethod_ID, ShipPartner_ID, ShipCarrier_ID, ShipMethod_ServiceID, ShipMethod_Name, ShipMethod_ShipToCountryID, ShipMethod_IsFree, ShipMethod_IsActive, ProductUploadBatchNo)");
                    sSql.Append(" VALUES( ");
                    sSql.Append(iShipMethodID.ToString() + "," +
                        ((int)ConfigParamter.ShipPartner.DropShipper).ToString() + "," +
                        "1,0,N'" + CommUtil.Quo(sNewShipMethodName) + "'," +
                        sCountryID + "," +
                        (bFreeShip ? "1," : "0,") +
                        "1," +
                        "0)");
                    iAffectedRow = db.DBExecute(sSql.ToString());

                    // insert Shipfrom2ShipMethod
                    sSql.Clear();
                    sSql.Append("insert into wn_ShipFrom2ShipMethod(ShipFrom_ID, ShipMethod_ID, ProductUploadBatchNo) values(" +
                        iShipFromID.ToString() + "," +
                        iShipMethodID.ToString() + "," +
                        "0)");
                    iAffectedRow = db.DBExecute(sSql.ToString());
                }
            }
            // delete ShipFrom2ShipMethod for not shipped country
            sSql.Clear();    
            sSql.Append("delete from wn_Shipfrom2ShipMethod ");
            sSql.Append(" where ShipFrom_ID = " + iShipFromID.ToString());
            sSql.Append(" and ShipMethod_ID in ( select ShipMethod_ID from wn_ShipMethod where ShipMethod_ShipToCountryID not in (" + sShipToCountryIDList + "))");
            iAffectedRow = db.DBExecute(sSql.ToString());

            return true;
        }
    }
}