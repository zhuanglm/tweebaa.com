using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Twee.Comm;
using Twee.Mgr;

namespace TweebaaWebApp2.ShipAPI
{
    public partial class TestShipOrder : System.Web.UI.Page
    {
        public List<ShipOrderResult> resultList;
        public string _sError;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtTweebaaOrderID.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtResult.Text = string.Empty;
            }
        }

  
        private void TestCancelShipOrder()
        {
            ShipOrder shipOrder = new ShipOrder();
            List<ShipOrderCancelResult> cancelResult = shipOrder.CancelShipPurchaseOrder("Twee201561595944520");
        }


        private void TestShipmentDetail()
        {
            FosdickAPI api = new FosdickAPI();
            FosdickShipmentDetailReq req = new FosdickShipmentDetailReq();
            req.iPage = 0;
            req.iPerPage = 3;
            req.dtUpdatedSince = new DateTime(2000, 1, 1);
            req.dtUpdatedBefore = DateTime.Now;
            req.dtShippedSince = new DateTime(2000, 1, 1);
            req.dtShippedBefore = DateTime.Now;
            req.sFosdickOrderNo = "99901201506460001";
            req.sExternalOrderNo = "9991001";
            
            List<FosdickShipmentDetail> list = api.GetShipmentDetailList(req, true);

        }


        private void TestShipment()
        {
            FosdickAPI api = new FosdickAPI();
            FosdickShipmentReq req = new FosdickShipmentReq();
            req.iPage = 0;
            req.iPerPage = 3;
            req.dtUpdatedSince = new DateTime(2000, 1, 1);
            req.dtUpdatedBefore = DateTime.Now;
            req.dtShippedSince = new DateTime(2000, 1, 1);
            req.dtShippedBefore = DateTime.Now;
            req.sFosdickOrderNo = "99901201506460001";
            req.sExternalOrderNo = "9991001";
            List<FosdickShipment> list = api.GetShipmentList(req, true);

        }

        private void TestOrderReturn()
        {
            FosdickAPI api = new FosdickAPI();
            FosdickOrderReturnReq req = new FosdickOrderReturnReq();
            req.iPage = 2;
            req.iPerPage = 3;
            req.dtUpdatedSince = new DateTime(2000, 1, 1);
            req.dtUpdatedBefore = DateTime.Now;
            req.dtReturnedSince = new DateTime(2000, 1, 1);
            req.dtReturnedBefore = DateTime.Now;
            List<FosdickOrderReturn> list = api.GetOrderReturnList(req, true);

        }




        private void TestInventory()
        {
            FosdickAPI api = new FosdickAPI();
            FosdickInventoryReq req = new FosdickInventoryReq();
            req.iPage = 2;
            req.iPerPage = 3;
            req.dtUpdatedSince = new DateTime(2000, 1, 1);
            req.dtUpdatedBefore = DateTime.Now;
            List<FosdickInventoryProduct> list = api.GetInventoryList(req, true);
        }

        protected void btnShipOrder_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty; 
            string sTweebaaOrderID = txtTweebaaOrderID.Text.Trim();
            if (sTweebaaOrderID.Length != 12 || sTweebaaOrderID.Substring(0, 4) != "Twee")
            {
                txtResult.Text = "Please enter a valid Tweebaa PO #";
                txtTweebaaOrderID.Focus();
                return;
            }
            
            if (txtPassword.Text != "laocao") {
                txtResult.Text = "Please enter a valid Password!";
                txtPassword.Focus();
                return;
            }
            
            try
            {
                ShipOrder so = new ShipOrder();

                //TestCancelShipOrder();
                //TestOrderReturn();
                
                resultList = so.ShipPurchaseOrder(sTweebaaOrderID, true);
                StringBuilder sResult = new StringBuilder();
                if (resultList != null)
                {
                    foreach (ShipOrderResult result in resultList)
                    {
                        sResult.Append("Tweebaa Shipping Order ID: " + result.iShipOrderID.ToString() + "\n");
                        sResult.Append("Shipping Partner Order ID: " + result.sPartnerOrderID + "\n");
                        sResult.Append("Shipping Partner Name: " + result.sPartnerName + "\n");
                        sResult.Append("Drop-Shipper Company Name: " + result.sDropShipperCompanyName + "\n");
                        sResult.Append("Error message: " + result.sErrMsg + "\n");
                    }
                }
                else {
                    sResult.Append(" No results");
                }
                txtResult.Text = sResult.ToString();
            }
            catch (Exception ex)
            {
                txtResult.Text = "Error:" + ex.Message;
            }
        }

        protected void btnWarehouseShipmentDetailUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ShipOrder so = new ShipOrder();
                bool bOK = so.WarehouseShipmentDetailUpdate((int)ConfigParamter.ShipPartner.Fosdick, false);
                txtResult.Text = bOK ? "Success" : "Failed";
            }
            catch (Exception ex)
            {
                txtResult.Text = "Error:" + ex.Message;
            }

        }
        protected void btnWarehouseReturnInfoUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ShipOrder so = new ShipOrder();
                bool bOK = so.WarehouseReturnInfoUpdate((int)ConfigParamter.ShipPartner.Fosdick, false);
                txtResult.Text = bOK ? "Success" : "Failed";
            }
            catch (Exception ex)
            {
                txtResult.Text = "Error:" + ex.Message;
            }

        }

        protected void btnWarehouseInventoryInfoUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ShipOrder so = new ShipOrder();
                bool bOK = so.WarehouseInventoryInfoUpdate((int)ConfigParamter.ShipPartner.Fosdick, false);
                txtResult.Text = bOK ? "Success" : "Failed";
            }
            catch (Exception ex)
            {
                txtResult.Text = "Error:" + ex.Message;
            }

        }

        protected void btnReSendWarehouseShippingOrder_Click(object sender, EventArgs e)
        {
            try
            {
                txtResult.Text = string.Empty;
                string sTweebaaOrderID = txtTweebaaOrderID.Text.Trim();
                if (sTweebaaOrderID.Length != 12 || sTweebaaOrderID.Substring(0, 4) != "Twee")
                {
                    txtResult.Text = "Please enter a valid Tweebaa PO #";
                    txtTweebaaOrderID.Focus();
                    return;
                }

                if (txtPassword.Text != "laocao")
                {
                    txtResult.Text = "Please enter a valid Password!";
                    txtPassword.Focus();
                    return;
                }
                
                ShipOrder so = new ShipOrder();
                List<ShipOrderResult> resultList = so.ReSendWarehousePurchaseOrder(sTweebaaOrderID, false);
 
                StringBuilder sResult = new StringBuilder();
                if (resultList != null)
                {
                    foreach (ShipOrderResult result in resultList)
                    {
                        sResult.Append("Tweebaa Shipping Order ID: " + result.iShipOrderID.ToString() + "\n");
                        sResult.Append("Shipping Partner Order ID: " + result.sPartnerOrderID + "\n");
                        sResult.Append("Shipping Partner Name: " + result.sPartnerName + "\n");
                        sResult.Append("Error message: " + result.sErrMsg + "\n");
                    }
                }
                else
                {
                    sResult.Append(" No results");
                }
                txtResult.Text = sResult.ToString();
            }
            catch (Exception ex)
            {
                txtResult.Text = "Error:" + ex.Message;
            }

        }


        protected void btnSendCustomerShipmentEmail_Click(object sender, EventArgs e)
        {
            try
            {
                txtResult.Text = string.Empty;
                string sShipOrderID = txtTweebaaOrderID.Text.Trim();
                if (sShipOrderID.Length != 8 )
                {
                    txtResult.Text = "Please enter a valid shipping order ID";
                    txtTweebaaOrderID.Focus();
                    return;
                }

                if (txtPassword.Text != "laocao")
                {
                    txtResult.Text = "Please enter a valid Password!";
                    txtPassword.Focus();
                    return;
                }

                int iShipOrderID = -1;
                int.TryParse(sShipOrderID, out iShipOrderID);
                if ( iShipOrderID == -1) {
                    txtResult.Text = "Please enter a valid shipping order ID";
                    txtTweebaaOrderID.Focus();
                    return;
                }

                ShipOrder so = new ShipOrder();
                string sCustomerShipmentEmailTemplate = so.ReadEmailTemplate("EmailCustomerShipment.html");
                string sErrMsg = string.Empty;
                bool bOK = so.SendCustomerShipmentEmail(iShipOrderID, sCustomerShipmentEmailTemplate, out sErrMsg);
                
                if (bOK )
                {
                    txtResult.Text = "Success: " + sErrMsg;
                }
                else
                {
                    txtResult.Text = "Failed: " + sErrMsg;
                }
            }
            catch (Exception ex)
            {
                txtResult.Text = "Error:" + ex.Message;
            }

        }
        protected void btnSetupProductShipToCountry_Click(object sender, EventArgs e)
        {
            string sErrMsg = string.Empty;

            if (txtPassword.Text != "laocao")
            {
                txtResult.Text = "Please enter a valid Password!";
                txtPassword.Focus();
                return;
            }

            StringBuilder sSql = new StringBuilder();
            sSql.Append("select distinct a.proid, a.userID, a.ShipFrom_ID, IsCustomerFreeShip, b.ShipFrom_ShipToCountries");
            sSql.Append(" from wn_prorules a ");
            sSql.Append(" inner join wn_ShipFrom b on b.ShipFrom_ID = a.ShipFrom_ID ");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                string sProID = dr["proid"].ToNullString();
                string sSupplierID = dr["userID"].ToNullString();
                int iIsCustomerFreeShip = 0;
                if (dr["IsCustomerFreeShip"] != DBNull.Value) iIsCustomerFreeShip = dr["IsCustomerFreeShip"].ToString().ToInt();
                string sShipToCountries = dr["ShipFrom_ShipToCountries"]._ObjToString();

                // add product ship to country 
                string[] sShipToCountryArr = sShipToCountries.Split(',');
                foreach (string sShipToCountry in sShipToCountryArr)
                {
                    string sCountryName = sShipToCountry.ToUpper();
                    int iCountryID = -1;
                    string sCountryCode = string.Empty;

                    bool bFreeShip = sCountryName.IndexOf("FREE") == -1 ? false : true;
                    sCountryName = sCountryName.Replace("FREE", "").Trim();
                    if (iIsCustomerFreeShip == 1) bFreeShip = true;

                    GetCountryInfo(sCountryName, out iCountryID, out sCountryCode);

                    if (iCountryID == -1)
                    {
                        sErrMsg = sErrMsg + "\n Country Error: ProID=" + sProID + " Country: " + sShipToCountries;
                    }

                    // insert product ship to country
                    AddProductShipToCountry(sProID, sSupplierID, iCountryID, sCountryCode, sCountryName, bFreeShip, 99999);
                }
            }
        }

        private void GetCountryInfo(string sCountryName, out int iCountryID, out string sCountryCode)
        {
            iCountryID = -1;
            sCountryCode = string.Empty;

            string sSql = "select * from wn_country where country ='" + sCountryName + "' or code = '" + sCountryName + "'";
            DataSet ds = DbHelperSQL.Query(sSql);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    iCountryID = dt.Rows[0]["id"].ToString().ToInt();
                    sCountryCode = dt.Rows[0]["code"].ToString();
                }
            }
        }

        // insert product ship to country
        private int  AddProductShipToCountry(string sPrdGuid, string sUserGuid, int iCountryID, string sCountryCode, string sCountryName, bool bFreeShip, int iProductUploadBatchNo)
        {
            int iAffectedRow = 0;
            
            // check if the recorded has alread existed
            string sSql = "select count(*) from wn_ProductShipToCountry where prdGuid='" + sPrdGuid +"' and userGuid ='" + sUserGuid + "' and Country_ID =" + iCountryID.ToString();
            int iCnt = DbHelperSQL.QueryCount(sSql);
            
            // insert a new one if not exist
            if (iCnt == 0)
            {
                sSql= "insert into wn_ProductShipToCountry(prdGuid, userGuid, Country_ID, Country_Code, Country_Name, ProductShipToCountry_IsFree, ProductShipToCountry_CreateDate, ProductUploadBatchNo) " +
                        " VALUES(" + 
                        "'" + sPrdGuid + "'," +
                        "'" + sUserGuid + "'," +
                        iCountryID.ToString() + "," +
                        "'" + sCountryCode + "'," +
                        "'" + sCountryName + "'," +
                        (bFreeShip?"1":"0") +  "," +
                        "getdate()," +
                        iProductUploadBatchNo.ToString() + ")";
                iAffectedRow = DbHelperSQL.ExecuteSql(sSql);
            }

            return iAffectedRow;
        }

    } // class
}  // name space