using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Net;

namespace TweebaaWebApp.ShipAPI
{
    public class EOrderAPI
    {
        private const string _sLiveUrl = "http://www.e-order.ca/rpc2 ";
        private const string _sSchemaUrl = "http://www.e-order.ca/XMLSchema";
        private const string _sUserName = "tweebaaapi";
        private const string _sPassword = "tweebaaapipass";

        public EOrderProductInfoResponse ParseProductInfoResponse(string sResponseXml)
        {
            EOrderProductInfoResponse response = new EOrderProductInfoResponse();
            if (sResponseXml == string.Empty)
            {
                response.sErrMsg = "Parse Product Info Response Error: Empty Response";
                return response;
            }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sResponseXml);
                XmlNodeList xnErrorList = doc.GetElementsByTagName("Error");
                if (xnErrorList.Count > 0)
                {
                    response.sErrMsg = xnErrorList[0].Attributes["Message"].Value;
                    return response;
                }

                XmlNodeList xnProductInfoList = doc.GetElementsByTagName("ProductInformation");
                if (xnProductInfoList.Count > 0)
                {
                    response.sProductInStock = xnProductInfoList[0].Attributes["productInStock"].Value;
                    response.sProductInQueue = xnProductInfoList[0].Attributes["productInQueue"].Value;
                    response.sProductQuarantined = xnProductInfoList[0].Attributes["productQuarantined"].Value;
                    response.sProductAvailable = xnProductInfoList[0].Attributes["productAvailable"].Value;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.sErrMsg = "Parse Product Info Response Error: " + ex.Message;
                return response;
            }
        }



        public EOrderStatusResponse ParseOrderStatusResponse(string sResponseXml)
        {
            EOrderStatusResponse response = new EOrderStatusResponse();

            if (sResponseXml == string.Empty)
            {
                response.sErrMsg = "Parse Order Status Response Error: empty response";
                return response;
            }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sResponseXml);
                XmlNodeList xnErrorList = doc.GetElementsByTagName("Error");
                if (xnErrorList.Count > 0)
                {
                    response.sErrMsg = xnErrorList[0].Attributes["Message"].Value;
                    return response;
                }

                
                XmlNodeList xnOrderStatusResponseList = doc.GetElementsByTagName("OrderStatusResponse");
                if (xnOrderStatusResponseList.Count > 0)
                {
                    XmlNode xnOrderStatusResponse = xnOrderStatusResponseList[0];
                    if (xnOrderStatusResponse != null) response.sPartnerOrderID = xnOrderStatusResponse.Attributes["orderId"].Value;
                }

                // status
                XmlNodeList xnStatusList = doc.GetElementsByTagName("Status");
                if (xnStatusList.Count > 0) 
                {
                    response.sStatusID = xnStatusList[0].Attributes["statusId"].Value;
                    response.sStatusName = xnStatusList[0].Attributes["statusName"].Value;
                }
                // tracking URL
                XmlNodeList xnTrackingUrlList = doc.GetElementsByTagName("TrackingUrl"); ;
                if (xnTrackingUrlList.Count > 0)
                {
                    response.sTrackingUrl = xnTrackingUrlList[0].Attributes["url"].Value; ;
                }
                response.bSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                response.sErrMsg = "Parse Oder Status Response Error: " + ex.Message;
                return response;
            }
        }


        public string CreateProductInfoXml(EOrderProductInfoReq req)
        {
            XmlDocument doc = new XmlDocument();

            //xml declaration
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //-------------------------------------------------------
            // make schema
            //-------------------------------------------------------
            XmlElement elemEOrder = doc.CreateElement(string.Empty, "EOrder", _sSchemaUrl);
            ShipAPIComm.AddAttr(doc, elemEOrder, "username", _sUserName);
            ShipAPIComm.AddAttr(doc, elemEOrder, "password", _sPassword);
            doc.AppendChild(elemEOrder);

            //-------------------------------------------------------
            // Product info request 
            //-------------------------------------------------------
            XmlElement elemProductInfoReq = doc.CreateElement("ProductInfoRequest", doc.DocumentElement.NamespaceURI);
            elemEOrder.AppendChild(elemProductInfoReq);

            //-------------------------------------------------------
            // product number
            //-------------------------------------------------------
            XmlElement elemProductNo = doc.CreateElement("Product", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemProductNo, "productNumber", req.sProductNo);
            elemProductInfoReq.AppendChild(elemProductNo);
            
            return ShipAPIComm.XmlToString(doc);

        }



        public string CreateOrderStatusXml(EOrderStatusReq req)
        {
            XmlDocument doc = new XmlDocument();

            //xml declaration
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //-------------------------------------------------------
            // make schema
            //-------------------------------------------------------
            XmlElement elemEOrder = doc.CreateElement(string.Empty, "EOrder", _sSchemaUrl);
            ShipAPIComm.AddAttr(doc, elemEOrder, "username", _sUserName);
            ShipAPIComm.AddAttr(doc, elemEOrder, "password", _sPassword);
            doc.AppendChild(elemEOrder);

            //-------------------------------------------------------
            // Order status request 
            //-------------------------------------------------------
            XmlElement elemOrderStatusReq = doc.CreateElement("OrderStatusRequest", doc.DocumentElement.NamespaceURI);
            elemEOrder.AppendChild(elemOrderStatusReq);

            //-------------------------------------------------------
            // order id 
            //-------------------------------------------------------
            XmlElement elemOrderID = doc.CreateElement("Order", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemOrderID, "orderId", req.sPartnerOrderID);
            elemOrderStatusReq.AppendChild(elemOrderID);
            return ShipAPIComm.XmlToString(doc);

        }

        public EOrderStatusResponse OrderStatus(EOrderStatusReq order)
        {
            string sOrderStatusXml = CreateOrderStatusXml(order);
            string sResponseXml = SendXml(sOrderStatusXml);

            // fro testing
            //sResponseXml = "<EOrder xmlns=\"http://www.e-order.com/xml/XMLSchema\"> <OrderStatusResponse orderId=\"1\"> <Status statusId=\"7\" statusName=\"SHIPPED\" /> <TrackingUrl url=\"http://shipnow.purolator.com/shiponline/\"/> </OrderStatusResponse></EOrder>";
            
            EOrderStatusResponse response = ParseOrderStatusResponse(sResponseXml);
            response.sReqXml = sOrderStatusXml;
            response.sResponseXml = sResponseXml;
            return response;
        }

        public EOrderProductInfoResponse ProductInfo(EOrderProductInfoReq order)
        {
            string sProductInfoXml = CreateProductInfoXml(order);
            string sResponseXml = SendXml(sProductInfoXml);

            EOrderProductInfoResponse response = ParseProductInfoResponse(sResponseXml);
            response.sReqXml = sProductInfoXml;
            response.sResponseXml = sResponseXml;
            return response;
        }

        public EOrderResponse Order(EOrderReq order)
        {
            string sOrderXml = CreateOrderXml(order);
            string sResponseXml = SendXml(sOrderXml);
            EOrderResponse response = ParseOrderResponse(sResponseXml);
            response.sReqXml = sOrderXml;
            response.sResponseXml = sResponseXml;
            return response;
        }


        public EOrderResponse ParseOrderResponse(string sOrderResponse) 
        {
            EOrderResponse response = new EOrderResponse();
            if (sOrderResponse == string.Empty)
            {
                response.sErrMsg = "Parse Order Response Error: Empty Response";
                return response;
            }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sOrderResponse);
                
                // check error reply
                XmlNodeList xnErrList = doc.GetElementsByTagName("Error");
                if (xnErrList.Count > 0)
                {
                    response.sErrMsg = xnErrList[0].Attributes["Message"].Value;
                    response.bSuccess = false;
                    return response;
                }

                // normal - no error 
                XmlNodeList xnOrderList = doc.GetElementsByTagName("Order");
                if (xnOrderList.Count > 0)
                {
                    response.sOrderID = xnOrderList[0].Attributes["orderId"].Value;
                    response.sMsg = xnOrderList[0].Attributes["message"].Value;
                }

                XmlNodeList xnPoList = doc.GetElementsByTagName("PurchaseOrder");
                if (xnPoList.Count > 0)
                {
                    response.sPurchaseOrderNo = xnPoList[0].Attributes["number"].Value;
                }

                XmlNodeList xnRefList = doc.GetElementsByTagName("Reference");
                if (xnRefList.Count > 0)
                {
                    response.sRefNo = xnRefList[0].Attributes["number"].Value;
                }

                response.bSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                response.sErrMsg = "Parse Order Response Error: " + ex.Message;
                return response;
            }

        }


        public string SendXml(string sXml)
        {
            return ShipAPIComm.PostXml(sXml, _sLiveUrl, "txt/xml");
        }


        public string CreateOrderXml(EOrderReq req)
        {
            XmlDocument doc = new XmlDocument();

            //xml declaration
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //-------------------------------------------------------
            // make schema
            //-------------------------------------------------------
            XmlElement elemEOrder = doc.CreateElement(string.Empty, "EOrder", _sSchemaUrl);
            ShipAPIComm.AddAttr(doc, elemEOrder, "username", _sUserName);
            ShipAPIComm.AddAttr(doc, elemEOrder, "password", _sPassword);
            doc.AppendChild(elemEOrder);

            //-------------------------------------------------------
            // Order request 
            //-------------------------------------------------------
            XmlElement elemOrderReq = doc.CreateElement("OrderRequest", doc.DocumentElement.NamespaceURI);
            elemEOrder.AppendChild(elemOrderReq);

            //-------------------------------------------------------
            // from 
            //-------------------------------------------------------
            XmlElement elemFrom = doc.CreateElement("From", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemFrom, "company", req.sFromCompany); 
            ShipAPIComm.AddAttr(doc, elemFrom, "address", req.sFromAddress);
            ShipAPIComm.AddAttr(doc, elemFrom, "city", req.sFromCity);
            ShipAPIComm.AddAttr(doc, elemFrom, "state", req.sFromState);
            ShipAPIComm.AddAttr(doc, elemFrom, "zip", req.sFromZip);
            ShipAPIComm.AddAttr(doc, elemFrom, "country", req.sFromCountry);
            ShipAPIComm.AddAttr(doc, elemFrom, "contact", req.sFromContact);
            ShipAPIComm.AddAttr(doc, elemFrom, "phone", req.sFromPhone);
            ShipAPIComm.AddAttr(doc, elemFrom, "email", req.sFromEmail);
            elemOrderReq.AppendChild(elemFrom);

            //-------------------------------------------------------
            // To
            //-------------------------------------------------------
            XmlElement elemTo= doc.CreateElement("To", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemTo, "company", req.sToCompany);
            ShipAPIComm.AddAttr(doc, elemTo, "address", req.sToAddress);
            ShipAPIComm.AddAttr(doc, elemTo, "city", req.sToCity);
            ShipAPIComm.AddAttr(doc, elemTo, "state", req.sToState);
            ShipAPIComm.AddAttr(doc, elemTo, "zip", req.sToZip);
            ShipAPIComm.AddAttr(doc, elemTo, "country", req.sToCountry);
            ShipAPIComm.AddAttr(doc, elemTo, "contact", req.sToContact);
            ShipAPIComm.AddAttr(doc, elemTo, "phone", req.sToPhone);
            elemOrderReq.AppendChild(elemTo);

            //--------------------------------
            // Products
            //--------------------------------
            XmlElement elemProducts = doc.CreateElement("Products", doc.DocumentElement.NamespaceURI);
            foreach (EOrderProduct product in req.ProductList)
            {
                XmlElement elemProduct= doc.CreateElement("Product", doc.DocumentElement.NamespaceURI);
                ShipAPIComm.AddAttr(doc, elemProduct, "prod_no", product.sSku);
                ShipAPIComm.AddAttr(doc, elemProduct, "quantity", product.sQty);
                elemProducts.AppendChild(elemProduct);
 
            }
            elemOrderReq.AppendChild(elemProducts);

            //--------------------------------
            // Shipping
            //--------------------------------
            XmlElement elemShip = doc.CreateElement("Shipping", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemShip, "type", req.sShipType);
            elemOrderReq.AppendChild(elemShip);

            //--------------------------------
            // payment
            //--------------------------------
            XmlElement elemPayment = doc.CreateElement("Payment", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemPayment, "option", req.sPaymentOption);
            elemOrderReq.AppendChild(elemPayment);

            //--------------------------------
            // Order Details
            //--------------------------------
            XmlElement elemOrderDetails = doc.CreateElement("OrderDetails", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemOrderDetails, "po_number", req.sPurchaseOrderNo);
            ShipAPIComm.AddAttr(doc, elemOrderDetails, "special_instruction", req.sSpecialInstruction);
            ShipAPIComm.AddAttr(doc, elemOrderDetails, "ref_num", req.sRefNo);
            ShipAPIComm.AddAttr(doc, elemOrderDetails, "cod_amount", req.sCodAmount);
            //ShipAPIComm.AddAttr(doc, elemOrderDetails, "date_required", req.DateRequired);
            elemOrderReq.AppendChild(elemOrderDetails);

            
            return ShipAPIComm.XmlToString(doc);
        }

    }
}