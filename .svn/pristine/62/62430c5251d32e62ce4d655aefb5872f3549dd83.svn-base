using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp2.ShipAPI
{
    public partial class TestEOrder : System.Web.UI.Page
    {
        public string _sOrderXml;
        public string _sResponseXml;
        protected void Page_Load(object sender, EventArgs e)
        {

            TestParseOrderResponse();
        }

        private void TestParseOrderResponse()
        {
            string sResponseXml = "<EOrder xmlns=\"http://www.e-order.com/xml/XMLSchema\"> <OrderResponse> <Order orderId=\"38229\" message=\"Your order has been submitted to Canada Worldwide for processing\"/> <PurchaseOrder number=\"2345\" /> <Reference number=\"9120\" /> </OrderResponse> </EOrder>";
            EOrderAPI api = new EOrderAPI();
            EOrderResponse response = api.ParseOrderResponse(sResponseXml);
        }

        private void TestOrder()
        {
            EOrderAPI api = new EOrderAPI();
            EOrderReq order = new EOrderReq();
            SetOrder(order);
            _sOrderXml = api.CreateOrderXml(order);
            _sResponseXml = api.SendXml(_sOrderXml);
            
        }

        private void TestProductInfo()
        {
            EOrderAPI api = new EOrderAPI();
            EOrderProductInfoReq req = new EOrderProductInfoReq();
            req.sProductNo = "MLC799";
            EOrderProductInfoResponse response = api.ProductInfo(req);
            _sOrderXml = response.sReqXml;
            _sResponseXml = response.sResponseXml;
        }


        private void TestOrderStatus()
        {
            EOrderAPI api = new EOrderAPI();
            EOrderStatusReq req = new EOrderStatusReq();
            req.sPartnerOrderID = "38168";
            EOrderStatusResponse response = api.OrderStatus(req);
            _sOrderXml = response.sReqXml;
            _sResponseXml = response.sResponseXml;
        }


        private void SetOrder(EOrderReq order)
        {
            // EOrder account
            // Customer Login:   demo2 / demo2 
            // Admin login:  tweebaa / twadmin
            order.sFromCompany = "Limitless Innovations, Inc.";
            order.sFromAddress = "4800 Metalmaster Way";
            order.sFromCity = "McHenry";
            order.sFromState = "IL";
            order.sFromZip = "60050";
            order.sFromCountry = "US";
            order.sFromContact = "Test Contact";
            order.sFromPhone = "(855) 843-4828";
            order.sFromEmail = "sales@limitlessinnovations.com";

            order.sToCompany = "Limitless Innovations, Inc.";
            order.sToAddress = "4800 Metalmaster Way";
            order.sToCity = "McHenry";
            order.sToState = "IL";
            order.sToZip = "60050";
            order.sToCountry = "US";
            order.sToContact = "Test Contact";
            order.sToPhone = "(855) 843-4828";

            
            order.ProductList = new List<EOrderProduct>();

            EOrderProduct product1 = new EOrderProduct();
            order.ProductList.Add(product1);
            product1.sName = "MFi Lightning Cable - Blacck/Red";
            product1.sSku = "MLC799";
            product1.sQty= "1";

            EOrderProduct product2 = new EOrderProduct();
            order.ProductList.Add(product2);
            product2.sName = "Clear Duct Tape - 12/PK";
            product2.sSku = "10030";
            product2.sQty= "2";


            order.sShipType = "Ground";
            order.sPaymentOption = "po";
            order.sPurchaseOrderNo = "2345";
            order.sSpecialInstruction = "";
            order.sRefNo = "9120";
            order.sCodAmount = "0.0";
            order.sDateRequired = "30-05-2015";
        }
    }
}