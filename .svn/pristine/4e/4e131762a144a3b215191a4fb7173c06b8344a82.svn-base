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

namespace TweebaaWebApp.ShipAPI
{
    public class FosdickAPI
    {
        private const string sLiveUrl = "https://www.unitycart.com/tweebaa/cart/ipost.asp";
        private const string sOrderCancelUrl = "https://www.customerstatus.com/xmlcancel.asp";
        private const string sRestfulApi = "https://www.customerstatus.com/fosdickapi";
        private const string sClientCode = "H4B52G57e";
        private const string sMoneyFormat = "#0.00";
        private const string sQtyFormat = "#0";
        private const int iMaxLenSku = 12;   // max length of sku number
        private const string sUserName = "CLIENTTEST";
        private const string sPassword = "TESTPW22415";

        // Order cancel test,  USERNAME: CLIENTTEST /  PASSWORD: TESTPW22415

        public List<FosdickShipmentDetail> GetShipmentDetailList(FosdickShipmentDetailReq req)
        {
            try
            {
                StringBuilder sParm = new StringBuilder();
                if (req.iPage != null && req.iPerPage != null)
                {
                    sParm.Append("&page=" + req.iPage);
                    sParm.Append("&per_page=" + req.iPerPage);
                }
                if (req.dtUpdatedSince != null) sParm.Append("&updated_at_min=" + req.dtUpdatedSince._DateTimeToString());
                if (req.dtUpdatedBefore != null) sParm.Append("&updated_at_max=" + req.dtUpdatedBefore._DateTimeToString());
                if (req.dtShippedSince != null) sParm.Append("&shipped_at_min=" + req.dtShippedSince._DateTimeToString());
                if (req.dtShippedBefore != null) sParm.Append("&shipped_at_max=" + req.dtShippedBefore._DateTimeToString());
                if (req.sFosdickOrderNo != null && req.sFosdickOrderNo != string.Empty) sParm.Append("&fosdick_order_num=" + req.sFosdickOrderNo);
                if (req.sExternalOrderNo != null && req.sExternalOrderNo != string.Empty) sParm.Append("&external_order_num=" + req.sExternalOrderNo);

                if (sParm.Length > 0) sParm[0] = '?'; // replace frist & to ?
                string responseText = WebApi("shipmentdetail.json" + sParm.ToString());

                List<FosdickShipmentDetail> shipmentDetailList = new List<FosdickShipmentDetail>();
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


        public List<FosdickShipment> GetShipmentList(FosdickShipmentReq req)
        {
            try
            {
                StringBuilder sParm = new StringBuilder();
                if (req.iPage != null && req.iPerPage != null)
                {
                    sParm.Append("&page=" + req.iPage);
                    sParm.Append("&per_page=" + req.iPerPage);
                }
                if (req.dtUpdatedSince  != null) sParm.Append("&updated_at_min=" + req.dtUpdatedSince._DateTimeToString());
                if (req.dtUpdatedBefore != null) sParm.Append("&updated_at_max=" + req.dtUpdatedBefore._DateTimeToString());
                if (req.dtShippedSince  != null) sParm.Append("&shipped_at_min=" + req.dtShippedSince._DateTimeToString());
                if (req.dtShippedBefore != null) sParm.Append("&shipped_at_max=" + req.dtShippedBefore._DateTimeToString());
                if (req.sFosdickOrderNo  != null && req.sFosdickOrderNo  != string.Empty) sParm.Append("&fosdick_order_num=" + req.sFosdickOrderNo);
                if (req.sExternalOrderNo != null && req.sExternalOrderNo != string.Empty) sParm.Append("&external_order_num=" + req.sExternalOrderNo);

                if (sParm.Length > 0) sParm[0] = '?'; // replace frist & to ?
                string responseText = WebApi("shipments.json" + sParm.ToString());

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

        
        public List<FosdickOrderReturn> GetOrderReturnList(FosdickOrderReturnReq req)
        {
            try
            {
                StringBuilder sParm = new StringBuilder();
                if (req.iPage != null && req.iPerPage != null)
                {
                    sParm.Append("&page=" + req.iPage);
                    sParm.Append("&per_page=" + req.iPerPage);
                }
                if (req.dtUpdatedSince != null)  sParm.Append("&updated_at_min=" + req.dtUpdatedSince._DateTimeToString());
                if (req.dtUpdatedBefore != null) sParm.Append("&updated_at_max=" + req.dtUpdatedBefore._DateTimeToString());
                if (req.dtReturnedSince != null) sParm.Append("&returned_at_min=" + req.dtReturnedSince._DateTimeToString());
                if (req.dtReturnedBefore != null) sParm.Append("&returned_at_max=" + req.dtReturnedBefore._DateTimeToString());


                if (sParm.Length > 0) sParm[0] = '?'; // replace frist & to ?
                string responseText = WebApi("returns.json" + sParm.ToString());

                List<FosdickOrderReturn> orderReturnList = new List<FosdickOrderReturn>();
                JArray ja = JArray.Parse(responseText);
                foreach (JObject jo in ja)
                {
                    FosdickOrderReturn orderReturn = new FosdickOrderReturn();
                    int iTemp;
                    DateTime dtTemp;
                    orderReturnList.Add(orderReturn);
                    orderReturn.sFosdickOrderNo = jo["fosdick_order_num"].ToString();
                    orderReturn.sExternalOrderNo = jo["external_order_num"].ToString();
                    orderReturn.sSku = jo["sku"].ToString();
                    orderReturn.iLineItem = jo["line_item"].ToString().ToInt();
                    if (Int32.TryParse(jo["external_line_item"].ToString(), out iTemp)) orderReturn.iExternalLineItem = iTemp;
                    if (DateTime.TryParse(jo["return_date"].ToString(), out dtTemp)) orderReturn.dtReturnDate = dtTemp;
                    orderReturn.iReturnedQty = jo["quantity_returned"].ToString().ToInt();
                    orderReturn.iQuality = jo["quality"].ToString().ToInt();
                    orderReturn.iReturnReasonCode = jo["reason_code"].ToString().ToInt();
                    orderReturn.sReturnReasonDesc = jo["reason_description"].ToString();
                    orderReturn.sRequestedAction = jo["action_requested"].ToString();
                    orderReturn.dtLastUpdated = DateTime.Parse(jo["updated_at"].ToString());
                }
                return orderReturnList;
            }
            catch (Exception ex)
            {
                throw new Exception("Get Order Return Error: " + ex.Message);
            }
        }

        public List<FosdickInventoryProduct> GetInventoryList(FosdickInventoryReq req)
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
                    sParm.Append("&updated_at_min=" + req.dtUpdatedSince._DateTimeToString());
                }
                if (req.dtUpdatedBefore != null)
                {
                    sParm.Append("&updated_at_max=" + req.dtUpdatedBefore._DateTimeToString());
                }

                if ( sParm.Length > 0) sParm[0] = '?'; // replace frist & to ?
                string responseText = WebApi("inventory.json" + sParm.ToString());

                List<FosdickInventoryProduct> productList = new List<FosdickInventoryProduct>();
                JArray ja = JArray.Parse(responseText);
                foreach (JObject jo in ja)
                {
                    FosdickInventoryProduct product = new FosdickInventoryProduct();
                    productList.Add(product);
                    product.sSku = jo["sku"].ToString() ;
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
                throw new Exception("Get Inventory Error: " + ex.Message);
            }
        }

        private string WebApi(string sReq)
        {
            string sReqUrl = sRestfulApi + "/" + sReq;
            try
            {
                HttpWebRequest request = WebRequest.Create(sReqUrl) as HttpWebRequest;
                String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(sUserName + ":" + sPassword));
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
                throw new Exception( "Web Api Error: " + e.Message);
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

        public FosdickOrderResponse ParseOrderResponse(string sOrderResponse) {
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
                    response.bSuccess = (sSuccessCode == "true")?true:false;
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
                        response.ErrList.Add ( node.InnerText);
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
            XmlElement elemTest = ShipAPIComm.AddElement(doc, elemOrderPost, "Test", order.sTest.ToUpper());
            XmlElement elemOrder = ShipAPIComm.AddElement(doc, elemOrderPost, "Order", string.Empty);

            // parameters of order
            ShipAPIComm.AddElement(doc, elemOrder, "ExternalID", order.sExternalID);
            ShipAPIComm.AddElement(doc, elemOrder, "AdCode", order.sAdCode);
            ShipAPIComm.AddElement(doc, elemOrder, "Subtotal", order.dSubTotal.ToString(sMoneyFormat));
            ShipAPIComm.AddElement(doc, elemOrder, "Discount", order.dDiscounts.ToString(sMoneyFormat));
            ShipAPIComm.AddElement(doc, elemOrder, "Postage", order.dPostage.ToString(sMoneyFormat));
            ShipAPIComm.AddElement(doc, elemOrder, "Tax", order.dTax.ToString(sMoneyFormat));
            ShipAPIComm.AddElement(doc, elemOrder, "Total", order.dTotal.ToString(sMoneyFormat));
            ShipAPIComm.AddElement(doc, elemOrder, "ShipFirstname", order.sShipFirstName);
            ShipAPIComm.AddElement(doc, elemOrder, "ShipLastname", order.sShipLastName);
            ShipAPIComm.AddElement(doc, elemOrder, "ShipAddress1", order.sShipAddress1);
            if (order.sShipAddress2 != null && order.sShipAddress2 != string.Empty)
            {
                ShipAPIComm.AddElement(doc, elemOrder, "ShipAddress2", order.sShipAddress2);
            }
            ShipAPIComm.AddElement(doc, elemOrder, "ShipCity", order.sShipCity);
            ShipAPIComm.AddElement(doc, elemOrder, "ShipState", order.sShipState);
            ShipAPIComm.AddElement(doc, elemOrder, "ShipZip", order.sShipZip);
            ShipAPIComm.AddElement(doc, elemOrder, "ShipPhone", order.sShipPhone);
            ShipAPIComm.AddElement(doc, elemOrder, "ShipCountry", order.sShipCountry);
            ShipAPIComm.AddElement(doc, elemOrder, "Email", order.sEmail);
            ShipAPIComm.AddElement(doc, elemOrder, "PaymentType", order.sPaymentType);
            ShipAPIComm.AddElement(doc, elemOrder, "UseAsBilling", order.sUseAsBilling);
            if (order.sUseAsBilling.ToLower() == "n")
            {
                ShipAPIComm.AddElement(doc, elemOrder, "BillFirstname", order.sBillFirstName);
                ShipAPIComm.AddElement(doc, elemOrder, "BillLastname", order.sBillLastName);
                ShipAPIComm.AddElement(doc, elemOrder, "BillAddress1", order.sBillAddress1);
                if (order.sBillAddress2 != null && order.sBillAddress2 != string.Empty)
                {
                    ShipAPIComm.AddElement(doc, elemOrder, "BillAddress2", order.sBillAddress2);
                }
                ShipAPIComm.AddElement(doc, elemOrder, "BillCity", order.sBillCity);
                ShipAPIComm.AddElement(doc, elemOrder, "BillState", order.sBillState);
                ShipAPIComm.AddElement(doc, elemOrder, "BillZip", order.sBillZip);
                ShipAPIComm.AddElement(doc, elemOrder, "BillPhone", order.sBillPhone);
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
                    if ( item.sInv.Length > iMaxLenSku)
                        ShipAPIComm.AddElement(doc, elemItem, "Inv", item.sInv.Substring(0, iMaxLenSku));
                    else
                        ShipAPIComm.AddElement(doc, elemItem, "Inv" , item.sInv);
                    ShipAPIComm.AddElement(doc, elemItem, "Qty" , item.dQty.ToString(sQtyFormat));
                    ShipAPIComm.AddElement(doc, elemItem, "PricePer", item.dPricePer.ToString(sMoneyFormat));
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
            XmlElement elemUserName = ShipAPIComm.AddElement(doc, elemCustomerStatusRequest, "UserName", sUserName);
            XmlElement elemPassword = ShipAPIComm.AddElement(doc, elemCustomerStatusRequest, "Password", sPassword);
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
                    if ( xnStatusSuccessCode != null)  response.bReqSuccess = (xnStatusSuccessCode.InnerText == "1")? true:false;
                    
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
                                if ( xnCancelOrder != null) {
                                    XmlNode xnCancelOrderNo = xnCancelOrder.SelectSingleNode(".//OderNumber");
                                    if ( xnCancelOrderNo != null) response.sFosdickOrderNo = xnCancelOrderNo.InnerText;
                                } 
                            }
                        }
                    }

                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception( ex.Message);
            }
        }
    }
}