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

namespace TweebaaWebApp.ShipAPI
{
    public partial class TestShipOrder : System.Web.UI.Page
    {
        public List<ShipOrderResult> resultList;
        public string _sError;

        protected void Page_Load(object sender, EventArgs e)
        {
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
            
            List<FosdickShipmentDetail> list = api.GetShipmentDetailList(req);

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
            List<FosdickShipment> list = api.GetShipmentList(req);

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
            List<FosdickOrderReturn> list = api.GetOrderReturnList(req);

        }




        private void TestInventory()
        {
            FosdickAPI api = new FosdickAPI();
            FosdickInventoryReq req = new FosdickInventoryReq();
            req.iPage = 2;
            req.iPerPage = 3;
            req.dtUpdatedSince = new DateTime(2000, 1, 1);
            req.dtUpdatedBefore = DateTime.Now;
            List<FosdickInventoryProduct> list = api.GetInventoryList(req);
        }

        protected void btnShipOrder_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
            string sTweebaaOrderID = txtTweebaaOrderID.Text.Trim();
            if (sTweebaaOrderID.Length != 12 || sTweebaaOrderID.Substring(0, 4) != "Twee")
            {
                txtResult.Text = "Please enter a valid Tweebaa PO #";
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

    } // clase
}  // name space