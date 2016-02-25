using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;                                                                                                                      
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using Twee.Comm;

namespace TweebaaWebApp2.ShipAPI
{
    public class FosdickAPI
    {
        private const string sLiveUrl = "https://www.unitycart.com/tweebaa/cart/ipost.asp";
        private const string sOrderCancelUrl = "https://www.customerstatus.com/xmlcancel.asp";
        private const string sRestfulApi = "https://www.customerstatus.com/fosdickapi";
        private const string sClientCode = "H4B52G57e";
        private const string sMoneyFormat = "#0.00";
        private const string sQtyFormat = "#0";
        private const string sUserName = "CLIENTTEST";
        private const string sPassword = "TESTPW22415";
        private const string sLiveUserName = "TWE299EBA";
        private const string sLivePassword = "4rEteSPayu";
        private const int iMaxLenSku = 12;   // max length of sku number
        private const int iMaxLenFirstName = 16;
        private const int iMaxLenLastName = 22;
        private const int iMaxLenAdress1 = 30;
        private const int iMaxLenAdress2 = 30;
        private const int iMaxLenAdress3 = 30;
        private const int iMaxLenCity = 13;
        private const int iMaxLenPhone = 20;
        private const int iMaxLenFax = 20;
        private const int iMaxLenZip = 11;
        private const int iMaxlenEmai = 100;


        // Order cancel test,  USERNAME: CLIENTTEST /  PASSWORD: TESTPW22415

        public List<FosdickShipmentDetail> GetShipmentDetailList(FosdickShipmentDetailReq req, bool bIsTest)
        {
            try
            {
                StringBuilder sParm = new StringBuilder();
                if (req.iPage != null && req.iPerPage != null)
                {
                    sParm.Append("&page=" + req.iPage);
                    sParm.Append("&per_page=" + req.iPerPage);
                }
                if (req.dtUpdatedSince != null) sParm.Append("&updated_at_min=" + GetDateTimeString((DateTime)req.dtUpdatedSince));
                if (req.dtUpdatedBefore != null) sParm.Append("&updated_at_max=" + GetDateTimeString((DateTime)req.dtUpdatedBefore));
                if (req.dtShippedSince != null) sParm.Append("&shipped_at_min=" + GetDateTimeString((DateTime)req.dtShippedSince));
                if (req.dtShippedBefore != null) sParm.Append("&shipped_at_max=" + GetDateTimeString((DateTime)req.dtShippedBefore));
                if (req.sFosdickOrderNo != null && req.sFosdickOrderNo != string.Empty) sParm.Append("&fosdick_order_num=" + req.sFosdickOrderNo);
                if (req.sExternalOrderNo != null && req.sExternalOrderNo != string.Empty) sParm.Append("&external_order_num=" + req.sExternalOrderNo);

                if (sParm.Length > 0) sParm[0] = '?'; // replace frist & to ?
                string responseText = WebApi("shipmentdetail.json" + sParm.ToString(), bIsTest);

                List<FosdickShipmentDetail> shipmentDetailList = new List<FosdickShipmentDetail>();

                // SetTestShipmentDetail(shipmentDetailList);

                JArray ja = JArray.Parse(responseText);
                foreach (JObject jo in ja)
                {
                    FosdickShipmentDetail shipmentDetail = new FosdickShipmentDetail();
                    DateTime dtTemp;
                    shipmentDetailList.Add(shipmentDetail);
                    shipmentDetail.sFosdickOrderNo = jo["fosdick_order_num"].ToString();
                    shipmentDetail.iFosdickLineNo = jo["fosdick_line_num"].ToString().ToInt();
                    shipmentDetail.sSku = jo["sku"].ToString();
                    shipmentDetail.iQty = jo["quantity"].ToString().ToInt();
                    shipmentDetail.sExternalOrderNo = jo["external_order_num"].ToString();
                    shipmentDetail.iExternalLineNo = jo["external_line_num"].ToString().ToInt();
                    shipmentDetail.sExternalSku = jo["external_sku"].ToString();
                    if (DateTime.TryParse(jo["ship_date"].ToString(), out dtTemp)) shipmentDetail.dtShipDate = dtTemp;
                    shipmentDetail.trackingList = new List<FosdickShipmentTracking>();

                    foreach (JObject joTracking in jo["trackings"])
                    {
                        FosdickShipmentTracking tracking = new FosdickShipmentTracking();
                        shipmentDetail.trackingList.Add(tracking);
                        tracking.sTrackingNo = joTracking["tracking_num"].ToString();
                        tracking.sCarrierCode = joTracking["carrier_code"].ToString();
                        tracking.sCarrierName = joTracking["carrier_name"].ToString();
                    }
                }
                return shipmentDetailList;
            }
            catch (Exception ex)
            {
                throw new Exception("Get Shipment Detail List Error: " + ex.Message);
            }
        }

        private void SetTestShipmentDetail(List<FosdickShipmentDetail> shipmentDetailList)
        {
            FosdickShipmentDetail shipmentDetailTest = new FosdickShipmentDetail();
            shipmentDetailList.Add(shipmentDetailTest);
            shipmentDetailTest.sFosdickOrderNo = "F12345";
            shipmentDetailTest.iFosdickLineNo = 912;
            shipmentDetailTest.sSku = "9129120000";
            shipmentDetailTest.iQty = 912;
            shipmentDetailTest.sExternalOrderNo = "10009999";
            shipmentDetailTest.iExternalLineNo = 0;
            shipmentDetailTest.sExternalSku = "200008888";
            shipmentDetailTest.dtShipDate = DateTime.Now;
            shipmentDetailTest.trackingList = new List<FosdickShipmentTracking>();

            for (int jj = 0; jj < 2; jj++)
            {
                FosdickShipmentTracking tracking = new FosdickShipmentTracking();
                shipmentDetailTest.trackingList.Add(tracking);
                tracking.sTrackingNo = "Tracking" + jj.ToString();
                tracking.sCarrierCode = jj.ToString();
                tracking.sCarrierName = "Fedex" + jj.ToString();
            }
        }



        public List<FosdickShipment> GetShipmentList(FosdickShipmentReq req, bool bIsTest)
        {
            try
            {
                StringBuilder sParm = new StringBuilder();
                if (req.iPage != null && req.iPerPage != null)
                {
                    sParm.Append("&page=" + req.iPage);
                    sParm.Append("&per_page=" + req.iPerPage);
                }
                if (req.dtUpdatedSince != null) sParm.Append("&updated_at_min=" + GetDateTimeString((DateTime)req.dtUpdatedSince));
                if (req.dtUpdatedBefore != null) sParm.Append("&updated_at_max=" + GetDateTimeString((DateTime)req.dtUpdatedBefore));
                if (req.dtShippedSince != null) sParm.Append("&shipped_at_min=" + GetDateTimeString((DateTime)req.dtShippedSince));
                if (req.dtShippedBefore != null) sParm.Append("&shipped_at_max=" + GetDateTimeString((DateTime)req.dtShippedBefore));
                if (req.sFosdickOrderNo != null && req.sFosdickOrderNo != string.Empty) sParm.Append("&fosdick_order_num=" + req.sFosdickOrderNo);
                if (req.sExternalOrderNo != null && req.sExternalOrderNo != string.Empty) sParm.Append("&external_order_num=" + req.sExternalOrderNo);

                if (sParm.Length > 0) sParm[0] = '?'; // replace frist & to ?
                string responseText = WebApi("shipments.json" + sParm.ToString(), bIsTest);

                List<FosdickShipment> shipmentList = new List<FosdickShipment>();
                JArray ja = JArray.Parse(responseText);
                foreach (JObject jo in ja)
                {
                    FosdickShipment shipment = new FosdickShipment();
                    DateTime dtTemp;
                    shipmentList.Add(shipment);
                    shipment.sFosdickOrderNo = jo["fosdick_order_num"].ToString();
                    shipment.sExternalOrderNo = jo["external_order_num"].ToString();
                    if (DateTime.TryParse(jo["ship_date"].ToString(), out dtTemp)) shipment.dtShipDate = dtTemp;
                    shipment.trackingList = new List<FosdickShipmentTracking>();

                    foreach (JObject joTracking in jo["trackings"])
                    {
                        FosdickShipmentTracking tracking = new FosdickShipmentTracking();
                        shipment.trackingList.Add(tracking);
                        tracking.sTrackingNo = joTracking["tracking_num"].ToString();
                        tracking.sCarrierCode = joTracking["carrier_code"].ToString();
                        tracking.sCarrierName = joTracking["carrier_name"].ToString();
                    }
                }
                return shipmentList;
            }
            catch (Exception ex)
            {
                throw new Exception("Get Shipment List Error: " + ex.Message);
            }
        }


        public List<FosdickOrderReturn> GetOrderReturnList(FosdickOrderReturnReq req, bool bIsTest)
        {
            try
            {
                StringBuilder sParm = new StringBuilder();
                if (req.iPage != null && req.iPerPage != null)
                {
                    sParm.Append("&page=" + req.iPage);
                    sParm.Append("&per_page=" + req.iPerPage);
                }
                if (req.dtUpdatedSince != null) sParm.Append("&updated_at_min=" + GetDateTimeString((DateTime)req.dtUpdatedSince));
                if (req.dtUpdatedBefore != null) sParm.Append("&updated_at_max=" + GetDateTimeString((DateTime)req.dtUpdatedBefore));
                if (req.dtReturnedSince != null) sParm.Append("&returned_at_min=" + GetDateTimeString((DateTime)req.dtReturnedSince));
                if (req.dtReturnedBefore != null) sParm.Append("&returned_at_max=" + GetDateTimeString((DateTime)req.dtReturnedBefore));


                if (sParm.Length > 0) sParm[0] = '?'; // replace frist & to ?
                string responseText = WebApi("returns.json" + sParm.ToString(), bIsTest);

                List<FosdickOrderReturn> orderReturnList = new List<FosdickOrderReturn>();
                JArray ja = JArray.Parse(responseText);

                //SetTestReturnInfoList(orderReturnList);  // jctest

                foreach (JObject jo in ja)
                {
                    FosdickOrderReturn orderReturn = new FosdickOrderReturn();
                    int iTemp;
                    DateTime dtTemp;
                    orderReturnList.Add(orderReturn);
                    orderReturn.sFosdickOrderNo = jo["fosdick_order_num"].ToString();
                    orderReturn.sExternalOrderNo = jo["external_order_num"].ToString();
                    orderReturn.sSku = jo["sku"].ToString();
                    orderReturn.iLineItemNo = jo["line_item"].ToString().ToInt();
                    if (Int32.TryParse(jo["external_line_item"].ToString(), out iTemp)) orderReturn.iExternalLineItemNo =  iTemp;
                    if (DateTime.TryParse(jo["return_date"].ToString(), out dtTemp)) orderReturn.dtReturnDate = dtTemp;
                    orderReturn.iReturnedQuantity = jo["quantity_returned"].ToString().ToInt();
                    orderReturn.iQuality = jo["quality"].ToString().ToInt();
                    orderReturn.sReturnReasonCode = jo["reason_code"].ToString();
                    orderReturn.sReturnReasonDesc = jo["reason_description"].ToString();
                    orderReturn.sActionRequested = jo["action_requested"].ToString();
                    orderReturn.dtLastUpdated = DateTime.Parse(jo["updated_at"].ToString());
                }
                return orderReturnList;
            }
            catch (Exception ex)
            {
                throw new Exception("Get Order Return Info Error: " + ex.Message);
            }
        }

        private void SetTestReturnInfoList(List<FosdickOrderReturn> orderReturnList)
        {
            FosdickOrderReturn orderReturn = new FosdickOrderReturn();
            orderReturnList.Add(orderReturn);
            orderReturn.sFosdickOrderNo = "fosdick912";
            orderReturn.sExternalOrderNo = "10000912";
            orderReturn.sSku = "1234567890";
            orderReturn.iLineItemNo = 0;
            orderReturn.iExternalLineItemNo = 0;
            orderReturn.dtReturnDate = DateTime.Now;
            orderReturn.iReturnedQuantity = 912;
            orderReturn.iQuality = 2;
            orderReturn.sReturnReasonCode = "reasoncode";
            orderReturn.sReturnReasonDesc = "reason Desc";
            orderReturn.sActionRequested = "Action no";
            orderReturn.dtLastUpdated = DateTime.Now;
        }

        public List<FosdickInventoryProduct> GetInventoryList(FosdickInventoryReq req, bool bIsTest)
        {
            try
            {
                StringBuilder sParm = new StringBuilder();
                if (req.iPage != null && req.iPerPage != null)
                {
                    sParm.Append("&page=" + req.iPage);
                    sParm.Append("&per_page=" + req.iPerPage);
                }
                if (req.dtUpdatedSince != null)
                {
                    sParm.Append("&updated_at_min=" + GetDateTimeString((DateTime)req.dtUpdatedSince));
                }
                if (req.dtUpdatedBefore != null)
                {
                    sParm.Append("&updated_at_max=" + GetDateTimeString((DateTime)req.dtUpdatedBefore));
                }

                if (sParm.Length > 0) sParm[0] = '?'; // replace frist & to ?
                string responseText = WebApi("inventory.json" + sParm.ToString(),  bIsTest);

                List<FosdickInventoryProduct> productList = new List<FosdickInventoryProduct>();
                JArray ja = JArray.Parse(responseText);

                SetTestInventoryInfoList(productList);   // jctest

                foreach (JObject jo in ja)
                {
                    FosdickInventoryProduct product = new FosdickInventoryProduct();
                    productList.Add(product);
                    product.sSku = jo["sku"].ToString();
                    product.bAvailable = (jo["available"].ToString().ToLower() == "true") ? true : false;
                    product.iStockQtyCT = jo["ct_quantity"].ToString().ToInt();
                    product.iStockQtyNV = jo["nv_quantity"].ToString().ToInt();
                    product.iStockQtyOther = jo["other_quantity"].ToString().ToInt();
                    product.iOrderCommittedQty = jo["committed"].ToString().ToInt();
                    product.iTotalAvailableQty = jo["available_quantity"].ToString().ToInt();
                    product.dtLastUpdated = DateTime.Parse(jo["updated_at"].ToString());
                }
                return productList;
            }
            catch (Exception ex)
            {
                throw new Exception("Get Inventory Info Error: " + ex.Message);
            }
        }

        private void SetTestInventoryInfoList(List<FosdickInventoryProduct> InventoryInfoList)
        {
            FosdickInventoryProduct product = new FosdickInventoryProduct();
            InventoryInfoList.Add(product);
            product.sSku = "1234567890";
            product.bAvailable = true;
            product.iStockQtyCT = 300;
            product.iStockQtyNV = 200;
            product.iStockQtyOther = 100;
            product.iOrderCommittedQty = 50;
            product.iTotalAvailableQty = 600;
            product.dtLastUpdated = DateTime.Now;
        }


        private string WebApi(string sReq,  bool bIsTest)
        {
            string sReqUrl = sRestfulApi + "/" + sReq;
            try
            {
                HttpWebRequest request = WebRequest.Create(sReqUrl) as HttpWebRequest;
                
                String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(sLiveUserName + ":" + sLivePassword));
                if (bIsTest)
                {
                    encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(sUserName + ":" + sPassword));
                }
                
                request.Headers.Add("Authorization", "Basic " + encoded);
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                    }

                    WebHeaderCollection header = response.Headers;
                    var encoding = ASCIIEncoding.ASCII;
                    using (var reader = new StreamReader(response.GetResponseStream(), encoding))
                    {
                        string responseText = reader.ReadToEnd();
                        return responseText;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Web Api Error: " + e.Message);
            }
        }

        public FosdickOrderResponse Order(FosdickOrder order)
        {
            string sOrderXML = CreateOrderXML(order);
            string sResponseXML = SendXML(sOrderXML, sLiveUrl);
            FosdickOrderResponse response = ParseOrderResponse(sResponseXML);
            response.sReqXML = sOrderXML;
            response.sResponseXML = sResponseXML;
            return response;
        }


        public string SendXML(string sXML, string sUrl)
        {
            return ShipAPIComm.PostXml(sXML, sUrl, "application/x-www-form-urlencoded");
        }

        public FosdickOrderResponse ParseOrderResponse(string sOrderResponse)
        {
            FosdickOrderResponse response = new FosdickOrderResponse();
            if (sOrderResponse == string.Empty)
            {
                return response;
            }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sOrderResponse);
                XmlNodeList xnExternalIDList = doc.GetElementsByTagName("OrderResponse");
                if (xnExternalIDList.Count > 0)
                {
                    response.sExternalID = xnExternalIDList[0].Attributes["ExternalID"].Value;
                }

                XmlNodeList xnSuccessCodeList = doc.GetElementsByTagName("SuccessCode");
                if (xnSuccessCodeList.Count > 0)
                {
                    string sSuccessCode = xnSuccessCodeList[0].InnerXml.ToLower();
                    response.bSuccess = (sSuccessCode == "true") ? true : false;
                }

                XmlNodeList xnOrderNoList = doc.GetElementsByTagName("OrderNumber");
                if (xnOrderNoList.Count > 0)
                {
                    response.sOrderNo = xnOrderNoList[0].InnerXml;
                }

                XmlNodeList xnErrCodeList = doc.GetElementsByTagName("ErrorCode");
                if (xnErrCodeList.Count > 0)
                {
                    response.sErrCode = xnErrCodeList[0].InnerXml;
                }

                XmlNodeList xnErrList = doc.GetElementsByTagName("Error");
                if (xnErrList.Count > 0)
                {
                    response.ErrList = new List<string>();
                    foreach (XmlNode node in xnErrList)
                    {
                        response.ErrList.Add(node.InnerText);
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                return response;
            }
        }

        public string CreateOrderXML(FosdickOrder order)
        {

            XmlDocument doc = new XmlDocument();

            //xml declaration
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //-------------------------------------------------------
            // make order post
            //-------------------------------------------------------
            XmlElement elemOrderPost = doc.CreateElement(string.Empty, "UnitycartOrderPost", null);
            ShipAPIComm.AddAttr(doc, elemOrderPost, "xml:lang", "en-US");
            doc.AppendChild(elemOrderPost);

            // client code
            XmlElement elemClientCode = ShipAPIComm.AddElement(doc, elemOrderPost, "ClientCode", sClientCode);
            if (order.sTest.ToUpper() == "Y")
            {
                XmlElement elemTest = ShipAPIComm.AddElement(doc, elemOrderPost, "Test", order.sTest.ToUpper());
            }
            XmlElement elemOrder = ShipAPIComm.AddElement(doc, elemOrderPost, "Order", string.Empty);

            // parameters of order
            ShipAPIComm.AddElement(doc, elemOrder, "ExternalID", order.sExternalID);
            ShipAPIComm.AddElement(doc, elemOrder, "AdCode", order.sAdCode);
            //ShipAPIComm.AddElement(doc, elemOrder, "Subtotal", order.dSubTotal.ToString(sMoneyFormat));
            //ShipAPIComm.AddElement(doc, elemOrder, "Discount", order.dDiscounts.ToString(sMoneyFormat));
            //ShipAPIComm.AddElement(doc, elemOrder, "Postage", order.dPostage.ToString(sMoneyFormat));
            //ShipAPIComm.AddElement(doc, elemOrder, "Tax", order.dTax.ToString(sMoneyFormat));
            //ShipAPIComm.AddElement(doc, elemOrder, "Total", order.dTotal.ToString(sMoneyFormat));

            // we do not need to set price, all prices must be set to zero
            ShipAPIComm.AddElement(doc, elemOrder, "Subtotal", "0");
            ShipAPIComm.AddElement(doc, elemOrder, "Discount", "0");
            ShipAPIComm.AddElement(doc, elemOrder, "Postage", "0");

            if (order.sShipMethodCode != string.Empty)
            {
                ShipAPIComm.AddElement(doc, elemOrder, "ShippingMethod", order.sShipMethodCode);
            }

            ShipAPIComm.AddElement(doc, elemOrder, "Tax", "0");
            ShipAPIComm.AddElement(doc, elemOrder, "Total", "0");

            ShipAPIComm.AddElement(doc, elemOrder, "ShipFirstname", CommUtil.Left(order.sShipFirstName, iMaxLenFirstName));
            if (order.sShipLastName != string.Empty)
            {
                ShipAPIComm.AddElement(doc, elemOrder, "ShipLastname", CommUtil.Left(order.sShipLastName, iMaxLenLastName));
            }
            else
            {
                ShipAPIComm.AddElement(doc, elemOrder, "ShipLastname", CommUtil.Left(order.sShipFirstName, iMaxLenFirstName));
            }

            ShipAPIComm.AddElement(doc, elemOrder, "ShipAddress1", CommUtil.Left(order.sShipAddress1, iMaxLenAdress1));
            if (order.sShipAddress2 != null && order.sShipAddress2 != string.Empty)
            {
                ShipAPIComm.AddElement(doc, elemOrder, "ShipAddress2", CommUtil.Left(order.sShipAddress2, iMaxLenAdress2));
            }
            ShipAPIComm.AddElement(doc, elemOrder, "ShipCity", CommUtil.Left(order.sShipCity, iMaxLenCity));
            ShipAPIComm.AddElement(doc, elemOrder, "ShipState", order.sShipState);
            ShipAPIComm.AddElement(doc, elemOrder, "ShipZip", CommUtil.Left(order.sShipZip, iMaxLenZip));
            ShipAPIComm.AddElement(doc, elemOrder, "ShipPhone", CommUtil.Left(order.sShipPhone, iMaxLenPhone));
            ShipAPIComm.AddElement(doc, elemOrder, "ShipCountry", order.sShipCountry);
            ShipAPIComm.AddElement(doc, elemOrder, "Email", CommUtil.Left(order.sEmail, iMaxlenEmai));
            ShipAPIComm.AddElement(doc, elemOrder, "PaymentType", order.sPaymentType);
            ShipAPIComm.AddElement(doc, elemOrder, "UseAsBilling", order.sUseAsBilling);
            if (order.sUseAsBilling.ToLower() == "n")
            {
                ShipAPIComm.AddElement(doc, elemOrder, "BillFirstname", CommUtil.Left(order.sBillFirstName, iMaxLenFirstName));
                ShipAPIComm.AddElement(doc, elemOrder, "BillLastname", CommUtil.Left(order.sBillLastName, iMaxLenLastName));
                ShipAPIComm.AddElement(doc, elemOrder, "BillAddress1", CommUtil.Left(order.sBillAddress1, iMaxLenAdress1));
                if (order.sBillAddress2 != null && order.sBillAddress2 != string.Empty)
                {
                    ShipAPIComm.AddElement(doc, elemOrder, "BillAddress2", CommUtil.Left(order.sBillAddress2, iMaxLenAdress2));
                }
                ShipAPIComm.AddElement(doc, elemOrder, "BillCity", CommUtil.Left(order.sBillCity, iMaxLenCity));
                ShipAPIComm.AddElement(doc, elemOrder, "BillState", order.sBillState);
                ShipAPIComm.AddElement(doc, elemOrder, "BillZip", CommUtil.Left(order.sBillZip, iMaxLenZip));
                ShipAPIComm.AddElement(doc, elemOrder, "BillPhone", CommUtil.Left(order.sBillPhone, iMaxLenPhone));
                ShipAPIComm.AddElement(doc, elemOrder, "BillCountry", order.sBillCountry);
            }

            if (order.ItemList != null)
            {
                // items
                XmlElement elemItems = ShipAPIComm.AddElement(doc, elemOrder, "Items", string.Empty);
                int iIdx = 0;
                foreach (FosdickOrderItem item in order.ItemList)
                {
                    iIdx++;
                    XmlElement elemItem = ShipAPIComm.AddElement(doc, elemItems, "Item", string.Empty);
                    ShipAPIComm.AddElement(doc, elemItem, "Inv", CommUtil.Left(item.sInv, iMaxLenSku));
                    ShipAPIComm.AddElement(doc, elemItem, "Qty", item.dQty.ToString(sQtyFormat));
                    //ShipAPIComm.AddElement(doc, elemItem, "PricePer", item.dPricePer.ToString(sMoneyFormat));
                    ShipAPIComm.AddElement(doc, elemItem, "PricePer", "0");
                }
            }

            return ShipAPIComm.XmlToString(doc);
        }

        public FosdickOrderCancelResponse OrderCancel(string sFosdickOrderNo)
        {
            string sOrderCancelXML = CreateOrderCancelXML(sFosdickOrderNo);
            string sResponseXML = SendXML(sOrderCancelXML, sOrderCancelUrl);
            FosdickOrderCancelResponse response = ParseOrderCancelResponse(sResponseXML);
            response.sReqXML = sOrderCancelXML;
            response.sResponseXML = sResponseXML;
            return response;
        }

        public string CreateOrderCancelXML(string sFosdickOrderNo)
        {
            XmlDocument doc = new XmlDocument();

            //xml declaration
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //-------------------------------------------------------
            // make order cancel request
            //-------------------------------------------------------
            XmlElement elemCustomerStatusRequest = doc.CreateElement(string.Empty, "CustomerStatusRequest", null);
            ShipAPIComm.AddAttr(doc, elemCustomerStatusRequest, "xml:lang", "en-US");
            doc.AppendChild(elemCustomerStatusRequest);


            // user name/password/request
            XmlElement elemUserName = ShipAPIComm.AddElement(doc, elemCustomerStatusRequest, "UserName", sLiveUserName);
            XmlElement elemPassword = ShipAPIComm.AddElement(doc, elemCustomerStatusRequest, "Password", sLivePassword);
            XmlElement elemRequest = ShipAPIComm.AddElement(doc, elemCustomerStatusRequest, "Request", string.Empty);

            // request cancel order
            XmlElement elemOrderCancel = ShipAPIComm.AddElement(doc, elemRequest, "CancelOrder", sFosdickOrderNo);

            return ShipAPIComm.XmlToString(doc);

        }



        public FosdickOrderCancelResponse ParseOrderCancelResponse(string sOrderCancelResponse)
        {

            FosdickOrderCancelResponse response = new FosdickOrderCancelResponse();
            if (sOrderCancelResponse == string.Empty)
            {
                return response;
            }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sOrderCancelResponse);
                XmlNodeList xnStatusResponses = doc.SelectNodes("CustomerStatusResponse");
                if (xnStatusResponses.Count > 0)
                {
                    XmlNode xnStatusResponse = xnStatusResponses[0];

                    // statussuccess code
                    XmlNode xnStatusSuccessCode = xnStatusResponse.SelectSingleNode(".//SuccessCode");
                    if (xnStatusSuccessCode != null) response.bReqSuccess = (xnStatusSuccessCode.InnerText == "1") ? true : false;

                    // Message
                    XmlNode xnMsg = xnStatusResponse.SelectSingleNode(".//Message");
                    if (xnMsg != null) response.sReqErrMsg = xnMsg.InnerText;

                    // get order cancel info
                    if (response.bReqSuccess)
                    {
                        XmlNode xnCancelResponse = xnStatusResponse.SelectSingleNode(".//RequestResponse");
                        if (xnCancelResponse != null)
                        {
                            XmlNode xnCancelSuccessCode = xnCancelResponse.SelectSingleNode(".//SuccessCode");
                            XmlNode xnCancelIdentifier = xnCancelResponse.SelectSingleNode(".//Identifier");
                            XmlNode xnCancelMsg = xnCancelResponse.SelectSingleNode(".//Message");
                            XmlNode xnCancelOrder = xnCancelResponse.SelectSingleNode(".//Oder");

                            response.bCancelSuccess = (xnCancelSuccessCode.InnerText == "1") ? true : false;
                            if (xnCancelIdentifier != null) response.sIdentifier = xnCancelIdentifier.InnerText;
                            if (xnCancelMsg != null) response.sCancelMsg = xnCancelMsg.InnerText;
                            if (response.bCancelSuccess)
                            {
                                if (xnCancelOrder != null)
                                {
                                    XmlNode xnCancelOrderNo = xnCancelOrder.SelectSingleNode(".//OderNumber");
                                    if (xnCancelOrderNo != null) response.sFosdickOrderNo = xnCancelOrderNo.InnerText;
                                }
                            }
                        }
                    }

                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string GetServerTimeZoneString()
        {
            // tweebaa database and IIS server are all GST-5:00
            return "-05:00";
        }

        private string GetDateTimeString(DateTime dt)
        {
            return dt.ToString("yyyy-MM-ddTHH:mm:ss") + GetServerTimeZoneString();
        }
    }
}