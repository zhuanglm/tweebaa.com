using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Net;

namespace TweebaaWebApp2.ShipAPI
{
    public class EshipperAPI
    {
        private const string _sLiveUrl = "http://www.eshipper.com/rpc2";
        private const string _sTestUrl = "http://test.eshipper.com:2201/eshipper/rpc2";
        private const string _sSchemaUrl = "http://www.eshipper.net/XMLSchema";


        public string SendXML(string sXML) {
            return ShipAPIComm.PostXml(sXML, _sLiveUrl, "txt/xml");
        }


        public List<EshipperQuoteReply> Quote(EshipperQuoteReq req)
        {

            string sUrl = _sLiveUrl;

            // use three shipping method 
            List<EshipperQuoteReply> quoteList = new List<EshipperQuoteReply>();
            for (int i = 1; i <= 3; i++)
            {
                req.ServiceId = i.ToString();  // set eshipper shipping methid ID
                string xmlQuote = CreateQuoteXML(req);
                string reply = SendXML(xmlQuote);
                List<EshipperQuoteReply> quote = ParseQuoteReply(reply);
                foreach (EshipperQuoteReply eqr in quote)
                {
                    quoteList.Add(eqr);
                }
            }
            return quoteList;
        }

        public EshipperShipReply Ship(EshipperShipReq req)
        {
            string xmlShip = CreateShipXML(req);
            string xmlReply = SendXML(xmlShip);
            EshipperShipReply reply = ParseShipReply(xmlReply);
            return reply;
        }

        public EshipperShipCancelReply ShipCancel(EshipperShipCancelReq req)
        {
            string xmlShipCancel = CreateShipCancelXML(req);
            string xmlReply = SendXML(xmlShipCancel);
            EshipperShipCancelReply reply = ParseShipCancelReply(xmlReply);
            return reply;
        }

        public EshipperOrderInfoReply OrderInfo(EshipperOrderInfoReq req)
        {
            string xmlOrderInfo = CreateOrderInfoXML(req);
            string xmlReply = SendXML(xmlOrderInfo);
            EshipperOrderInfoReply reply = ParseOrderInfoReply(xmlReply);
            return reply;
        }
 
        public string CreateQuoteXML(EshipperQuoteReq req)
        {
            XmlDocument doc = new XmlDocument();
            
            //xml declaration
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //-------------------------------------------------------
            // make schema
            //-------------------------------------------------------
            XmlElement elemEshipper = doc.CreateElement(string.Empty, "EShipper", _sSchemaUrl);
            ShipAPIComm.AddAttr(doc, elemEshipper, "username", req.UserName);
            ShipAPIComm.AddAttr(doc, elemEshipper, "password", req.Password);
            ShipAPIComm.AddAttr(doc, elemEshipper, "version", "3.0.0"); 
            doc.AppendChild(elemEshipper);

            //-------------------------------------------------------
            // quote request 
            //-------------------------------------------------------
            XmlElement elemReq = doc.CreateElement("QuoteRequest", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemReq, "serviceId", req.ServiceId);
            ShipAPIComm.AddAttr(doc, elemReq, "stackable", "true");
            elemEshipper.AppendChild(elemReq);

            //-------------------------------------------------------
            // from 
            //-------------------------------------------------------
            XmlElement elemFrom = doc.CreateElement("From", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemFrom, "id", req.FromId);
            ShipAPIComm.AddAttr(doc, elemFrom, "company", req.FromCompany);
            ShipAPIComm.AddAttr(doc, elemFrom, "address1", req.FromAddress1);
            if (req.FromAddress2 != String.Empty)
            {
                ShipAPIComm.AddAttr(doc, elemFrom, "address2", req.FromAddress2);
            }
            ShipAPIComm.AddAttr(doc, elemFrom, "city", req.FromCity);
            ShipAPIComm.AddAttr(doc, elemFrom, "state", req.FromState);
            ShipAPIComm.AddAttr(doc, elemFrom, "country", req.FromCountry);
            ShipAPIComm.AddAttr(doc, elemFrom, "zip", req.FromZip);
            elemReq.AppendChild(elemFrom);

            //-------------------------------------------------------
            // To
            //-------------------------------------------------------
            XmlElement elemTo = doc.CreateElement("To", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemTo, "company", req.ToCompany);
            ShipAPIComm.AddAttr(doc, elemTo, "address1", req.ToAddress1);
            ShipAPIComm.AddAttr(doc, elemTo, "city", req.ToCity);
            ShipAPIComm.AddAttr(doc, elemTo, "state", req.ToState);
            ShipAPIComm.AddAttr(doc, elemTo, "country", req.ToCountry);
            ShipAPIComm.AddAttr(doc, elemTo, "zip", req.ToZip);
            elemReq.AppendChild(elemTo);

            //--------------------------------
            // COD is optionl
            //--------------------------------

            //----------------------------------------------------------------------------------------------
            // If type="Envelope" or type="Courier Pak" or type=”Package” package information is  required 
            // packages
            //----------------------------------------------------------------------------------------------
            XmlElement elemPackages = doc.CreateElement("Packages", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemPackages, "type", "Package");

            // package 1
            XmlElement elemPackage1 = doc.CreateElement("Package", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemPackage1, "length", req.PackageLength);
            ShipAPIComm.AddAttr(doc, elemPackage1, "width", req.PackageWidth);
            ShipAPIComm.AddAttr(doc, elemPackage1, "height", req.PackageHeight);
            ShipAPIComm.AddAttr(doc, elemPackage1, "weight", req.PackageWeight);
            //AddAttr(doc, elemPackage1, "type", "Pallet");
            //AddAttr(doc, elemPackage1, "freightClass", "70");
            //AddAttr(doc, elemPackage1, "mfcCode", "123456");
            //AddAttr(doc, elemPackage1, "insuranceAmount", "0.0");
            //AddAttr(doc, elemPackage1, "codAmount", "0.0");
            //AddAttr(doc, elemPackage1, "description", "desc.");
            elemPackages.AppendChild(elemPackage1);

            // package 2
            //XmlElement elemPackage2 = doc.CreateElement("Package", doc.DocumentElement.NamespaceURI);
            //AddAttr(doc, elemPackage2, "length", "15");
            //AddAttr(doc, elemPackage2, "width", "10");
            //AddAttr(doc, elemPackage2, "height", "12");
            //AddAttr(doc, elemPackage2, "weight", "10");
            //AddAttr(doc, elemPackage2, "type", "Pallet");
            //AddAttr(doc, elemPackage2, "freightClass", "70");
            //AddAttr(doc, elemPackage2, "insuranceAmount", "0.0");
            //AddAttr(doc, elemPackage2, "codAmount", "0.0");
            //AddAttr(doc, elemPackage2, "description", "desc.");
            //elemPackages.AppendChild(elemPackage2);

            elemReq.AppendChild(elemPackages);

            //--------------------------------
            // Pickup is optional
            //--------------------------------
            if (req.PickupContactName != string.Empty)
            {
                XmlElement elemPickup = doc.CreateElement("Pickup", doc.DocumentElement.NamespaceURI);
                ShipAPIComm.AddAttr(doc, elemPickup, "contactName", req.PickupContactName);
                ShipAPIComm.AddAttr(doc, elemPickup, "phoneNumber", req.PickupPhoneNumber);
                ShipAPIComm.AddAttr(doc, elemPickup, "pickupDate", req.PickupDate);
                ShipAPIComm.AddAttr(doc, elemPickup, "pickupTime", req.PickupTime);
                ShipAPIComm.AddAttr(doc, elemPickup, "closingTime", req.PickupClosingTime);
                ShipAPIComm.AddAttr(doc, elemPickup, "location", req.PickupLocation);
                elemReq.AppendChild(elemPickup);
            }

            return ShipAPIComm.XmlToString(doc);
        }


        public string CreateShipXML(EshipperShipReq req)
        {
            XmlDocument doc = new XmlDocument();

            //xml declaration
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //-------------------------------------------------------
            // make schema
            //-------------------------------------------------------
            XmlElement elemEshipper = doc.CreateElement(string.Empty, "EShipper", _sSchemaUrl);
            ShipAPIComm.AddAttr(doc, elemEshipper, "username", req.UserName);
            ShipAPIComm.AddAttr(doc, elemEshipper, "password", req.Password);
            ShipAPIComm.AddAttr(doc, elemEshipper, "version", "3.0.0");
            doc.AppendChild(elemEshipper);

            //-------------------------------------------------------
            // Shipping request 
            //-------------------------------------------------------
            XmlElement elemReq = doc.CreateElement("ShippingRequest", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemReq, "serviceId", req.ServiceId);
            ShipAPIComm.AddAttr(doc, elemReq, "stackable", "true");
            elemEshipper.AppendChild(elemReq);

            //-------------------------------------------------------
            // from 
            //-------------------------------------------------------
            XmlElement elemFrom = doc.CreateElement("From", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemFrom, "id", req.FromId);
            ShipAPIComm.AddAttr(doc, elemFrom, "company", req.FromCompany);
            ShipAPIComm.AddAttr(doc, elemFrom, "address1", req.FromAddress1);
            if (req.FromAddress2 != String.Empty)
            {
                ShipAPIComm.AddAttr(doc, elemFrom, "address2", req.FromAddress2);
            }
            ShipAPIComm.AddAttr(doc, elemFrom, "city", req.FromCity);
            ShipAPIComm.AddAttr(doc, elemFrom, "state", req.FromState);
            ShipAPIComm.AddAttr(doc, elemFrom, "country", req.FromCountry);
            ShipAPIComm.AddAttr(doc, elemFrom, "zip", req.FromZip);
            ShipAPIComm.AddAttr(doc, elemFrom, "phone", req.FromPhoneNumber);
            ShipAPIComm.AddAttr(doc, elemFrom, "attention", req.FromAttention);
            elemReq.AppendChild(elemFrom);

            //-------------------------------------------------------
            // To
            //-------------------------------------------------------
            XmlElement elemTo = doc.CreateElement("To", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemTo, "company", req.ToCompany);
            ShipAPIComm.AddAttr(doc, elemTo, "address1", req.ToAddress1);
            ShipAPIComm.AddAttr(doc, elemTo, "city", req.ToCity);
            ShipAPIComm.AddAttr(doc, elemTo, "state", req.ToState);
            ShipAPIComm.AddAttr(doc, elemTo, "country", req.ToCountry);
            ShipAPIComm.AddAttr(doc, elemTo, "zip", req.ToZip);
            ShipAPIComm.AddAttr(doc, elemTo, "phone", req.ToPhoneNumber);
            ShipAPIComm.AddAttr(doc, elemTo, "attention", req.ToAttention); 
            elemReq.AppendChild(elemTo);

            //--------------------------------
            // COD is optionl
            //--------------------------------

            //----------------------------------------------------------------------------------------------
            // If type="Envelope" or type="Courier Pak" or type=”Package” package information is  required 
            // packages
            //----------------------------------------------------------------------------------------------
            XmlElement elemPackages = doc.CreateElement("Packages", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemPackages, "type", "Package");

            // package 1
            XmlElement elemPackage1 = doc.CreateElement("Package", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemPackage1, "length", req.PackageLength);
            ShipAPIComm.AddAttr(doc, elemPackage1, "width", req.PackageWidth);
            ShipAPIComm.AddAttr(doc, elemPackage1, "height", req.PackageHeight);
            ShipAPIComm.AddAttr(doc, elemPackage1, "weight", req.PackageWeight);
            //AddAttr(doc, elemPackage1, "type", "Pallet");
            //AddAttr(doc, elemPackage1, "freightClass", "70");
            //AddAttr(doc, elemPackage1, "mfcCode", "123456");
            //AddAttr(doc, elemPackage1, "insuranceAmount", "0.0");
            //AddAttr(doc, elemPackage1, "codAmount", "0.0");
            //AddAttr(doc, elemPackage1, "description", "desc.");
            elemPackages.AppendChild(elemPackage1);

            // package 2
            //XmlElement elemPackage2 = doc.CreateElement("Package", doc.DocumentElement.NamespaceURI);
            //AddAttr(doc, elemPackage2, "length", "15");
            //AddAttr(doc, elemPackage2, "width", "10");
            //AddAttr(doc, elemPackage2, "height", "12");
            //AddAttr(doc, elemPackage2, "weight", "10");
            //AddAttr(doc, elemPackage2, "type", "Pallet");
            //AddAttr(doc, elemPackage2, "freightClass", "70");
            //AddAttr(doc, elemPackage2, "insuranceAmount", "0.0");
            //AddAttr(doc, elemPackage2, "codAmount", "0.0");
            //AddAttr(doc, elemPackage2, "description", "desc.");
            //elemPackages.AppendChild(elemPackage2);

            elemReq.AppendChild(elemPackages);

            //--------------------------------
            // Pickup is optional
            //--------------------------------
            if (req.PickupContactName != string.Empty)
            {
                XmlElement elemPickup = doc.CreateElement("Pickup", doc.DocumentElement.NamespaceURI);
                ShipAPIComm.AddAttr(doc, elemPickup, "contactName", req.PickupContactName);
                ShipAPIComm.AddAttr(doc, elemPickup, "phoneNumber", req.PickupPhoneNumber);
                ShipAPIComm.AddAttr(doc, elemPickup, "pickupDate", req.PickupDate);
                ShipAPIComm.AddAttr(doc, elemPickup, "pickupTime", req.PickupTime);
                ShipAPIComm.AddAttr(doc, elemPickup, "closingTime", req.PickupClosingTime);
                ShipAPIComm.AddAttr(doc, elemPickup, "location", req.PickupLocation);
                elemReq.AppendChild(elemPickup);
            }

            return ShipAPIComm.XmlToString(doc);
        }


        public string CreateShipCancelXML(EshipperShipCancelReq req)
        {
            XmlDocument doc = new XmlDocument();

            //xml declaration
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //-------------------------------------------------------
            // make schema
            //-------------------------------------------------------
            XmlElement elemEshipper = doc.CreateElement(string.Empty, "EShipper", _sSchemaUrl);
            ShipAPIComm.AddAttr(doc, elemEshipper, "username", req.UserName);
            ShipAPIComm.AddAttr(doc, elemEshipper, "password", req.Password);
            ShipAPIComm.AddAttr(doc, elemEshipper, "version", "3.0.0");
            doc.AppendChild(elemEshipper);

            //-------------------------------------------------------
            // Shipment cancel request 
            //-------------------------------------------------------
            XmlElement elemReq = doc.CreateElement("ShipmentCancelRequest", doc.DocumentElement.NamespaceURI);
            elemEshipper.AppendChild(elemReq);

            XmlElement elemOrder = doc.CreateElement("Order", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemOrder, "orderId", req.OrderID);
            elemReq.AppendChild(elemOrder);

            return ShipAPIComm.XmlToString(doc);
        }


        public string CreateOrderInfoXML(EshipperOrderInfoReq req)
        {
            XmlDocument doc = new XmlDocument();

            //xml declaration
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //-------------------------------------------------------
            // make schema
            //-------------------------------------------------------
            XmlElement elemEshipper = doc.CreateElement(string.Empty, "EShipper", _sSchemaUrl);
            ShipAPIComm.AddAttr(doc, elemEshipper, "username", req.UserName);
            ShipAPIComm.AddAttr(doc, elemEshipper, "password", req.Password);
            ShipAPIComm.AddAttr(doc, elemEshipper, "version", "3.0.0");
            doc.AppendChild(elemEshipper);

            //-------------------------------------------------------
            // Shipment cancel request 
            //-------------------------------------------------------
            XmlElement elemReq = doc.CreateElement("OrderInformationRequest", doc.DocumentElement.NamespaceURI);
            elemEshipper.AppendChild(elemReq);

            XmlElement elemOrder = doc.CreateElement("Order", doc.DocumentElement.NamespaceURI);
            ShipAPIComm.AddAttr(doc, elemOrder, "orderId", req.OrderID);
            //AddAttr(doc, elemReq, "detailed", "true");
            elemReq.AppendChild(elemOrder);

            return ShipAPIComm.XmlToString(doc);
        }



        public List<EshipperQuoteReply> ParseQuoteReply(string sQuoteReply)
        {
  
            List<EshipperQuoteReply> quoteReplyList = new List<EshipperQuoteReply>();
            if (sQuoteReply == string.Empty)
            {
                return quoteReplyList;
            }

            try { 
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sQuoteReply);
                XmlNodeList quoteList = doc.GetElementsByTagName("Quote");
                foreach (XmlNode node in quoteList)
                {
                    EshipperQuoteReply reply =  new EshipperQuoteReply();
                    quoteReplyList.Add(reply);

                    reply.CarrierId = int.Parse(node.Attributes["carrierId"].Value);
                    reply.CarrierName = node.Attributes["carrierName"].Value;
                    reply.ServiceId = int.Parse(node.Attributes["serviceId"].Value);
                    reply.ServiceName = node.Attributes["serviceName"].Value;
                    reply.ModeTransport =  node.Attributes["modeTransport"].Value;
                    reply.TransitDays = int.Parse(node.Attributes["transitDays"].Value);
                    reply.BaseCharge = Decimal.Parse(node.Attributes["baseCharge"].Value);
                    reply.FuelSurcharge = Decimal.Parse(node.Attributes["fuelSurcharge"].Value);
                    reply.TotalCharge = Decimal.Parse(node.Attributes["totalCharge"].Value);
                    reply.Currency = node.Attributes["currency"].Value;
                }
             }
             catch (Exception ex) 
             {
                return quoteReplyList;
             }
             return quoteReplyList;
         }

         public EshipperShipReply ParseShipReply(string sShipReply)
        {

            EshipperShipReply  reply  = new EshipperShipReply();
            if (sShipReply == string.Empty)
            {
                return reply;
            }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sShipReply);
                XmlNodeList orders = doc.GetElementsByTagName("Order");
                if ( orders.Count > 0 ) {
                    reply.OrderID = orders[0].Attributes["id"].Value;
                }

                XmlNodeList carriers = doc.GetElementsByTagName("Carrier");
                if ( carriers.Count > 0 ) {
                    reply.CarrierName = carriers[0].Attributes["carrierName"].Value;
                    reply.ServiceName = carriers[0].Attributes["serviceName"].Value;
                }

                XmlNodeList packages = doc.GetElementsByTagName("Package");
                if ( packages.Count > 0 ) {
                    reply.TrackingNUmber = packages[0].Attributes["trackingNumber"].Value;
                }

                XmlNodeList trackingURLs = doc.GetElementsByTagName("TrackingURL");
                if ( trackingURLs.Count > 0 ) {
                    reply.TrackingURL =  trackingURLs[0].InnerText;
                }

                return reply;
            }
            catch (Exception ex)
            {
                return reply;
            }
        }


        public EshipperShipCancelReply ParseShipCancelReply(string sShipCancelReply)
        {

            EshipperShipCancelReply reply = new EshipperShipCancelReply();
            if (sShipCancelReply == string.Empty)
            {
                return reply;
            }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sShipCancelReply);
                XmlNodeList orders = doc.GetElementsByTagName("Order");
                if (orders.Count > 0)
                {
                    reply.OrderID = orders[0].Attributes["orderId"].Value;
                    reply.Message = orders[0].Attributes["message"].Value;
                }

                XmlNodeList status = doc.GetElementsByTagName("Status");
                if (status.Count > 0)
                {
                    reply.StatusID = status[0].Attributes["statusId"].Value;
                }

                return reply;
            }
            catch (Exception ex)
            {
                return reply;
            }
        }
        public EshipperOrderInfoReply ParseOrderInfoReply(string sOrderInfoReply)
        {

            EshipperOrderInfoReply reply = new EshipperOrderInfoReply();
            if (sOrderInfoReply == string.Empty)
            {
                return reply;
            }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sOrderInfoReply);
                XmlNodeList orders = doc.GetElementsByTagName("Order");
                if (orders.Count > 0)
                {
                    reply.OrderID = orders[0].Attributes["id"].Value;
                }

                XmlNodeList carriers = doc.GetElementsByTagName("Carrier");
                if (carriers.Count > 0)
                {
                    reply.CarrierName = carriers[0].Attributes["carrierName"].Value;
                    reply.ServiceName = carriers[0].Attributes["serviceName"].Value;
                }

                XmlNodeList packages = doc.GetElementsByTagName("Package");
                if (packages.Count > 0)
                {
                    reply.TrackingNumber =  packages[0].Attributes["trackingNumber"].Value;
                }

                XmlNodeList trackingURLs = doc.GetElementsByTagName("TrackingURL");
                if (trackingURLs.Count > 0)
                {
                    reply.TrackingURL = trackingURLs[0].InnerXml;
                }

                XmlNodeList status = doc.GetElementsByTagName("Status");
                if (status.Count > 0)
                {
                    reply.StatusID = status[0].Attributes["statusId"].Value;
                    reply.StatusName = status[0].Attributes["statusName"].Value;
                }
                
                return reply;
            }
            catch (Exception ex)
            {
                return reply;
            }
        }

    }
}