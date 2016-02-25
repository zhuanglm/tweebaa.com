using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TweebaaWebApp.ShipAPI
{
    public partial class TestEShipper : System.Web.UI.Page
    {
        public string _sXML = "";
        public string _sResponse = "";
        public string _sShipMethod = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            TestQuote();
            TestShip();
            TestOrderInfo();
            TestShipCancel();
        }



        private void TestQuote()
        {
            EshipperQuoteReq req = new EshipperQuoteReq();
            SetQuoteReq(req);
            EshipperAPI api = new EshipperAPI();
            List<EshipperQuoteReply> replyList = api.Quote(req);
        }

        private void TestShip()
        {
            EshipperShipReq req = new EshipperShipReq();
            SetShipReq(req);
            EshipperAPI api = new EshipperAPI();
            EshipperShipReply reply = api.Ship(req);
        }

        private void TestOrderInfo() {
            EshipperOrderInfoReq req = new EshipperOrderInfoReq();
            SetOrderInfoReq(req);
            EshipperAPI api = new EshipperAPI();
            EshipperOrderInfoReply reply = api.OrderInfo(req);
        }

        private void TestShipCancel()
        {
            EshipperShipCancelReq req = new EshipperShipCancelReq();
            SetShipCancelReq(req);
            EshipperAPI api = new EshipperAPI();
            EshipperShipCancelReply reply = api.ShipCancel(req);
        }


        private string GetTestQuoteReply() {
            return  "<Eshipper xmlns=\"http://www.eshipper.net/XMLSchema\" version=\"3.0.0\">  <QuoteReply> <quote carrierId=\"2\" carrierName=\"Purolator\" serviceId=\"4\" serviceName=\"Air\" modeTransport=\"A\" transitDays=\"1\" baseCharge=\"177.0\" fuelSurcharge=\"0.0\" totalCharge=\"177.0\" currency=\"CAD\"> </quote>  <quote carrierId=\"2\" carrierName=\"Purolator\" serviceId=\"13\" serviceName=\"Ground\" modeTransport=\"G\" transitDays=\"1\" baseCharge=\"28.650000000000002\" fuelSurcharge=\"0.0\" totalCharge=\"28.65\" currency=\"CAD\"> </quote>   <quote carrierId=\"1\" carrierName=\"Federal Express\" serviceId=\"1\" serviceName=\"Priority\" modeTransport=\"null\" transitDays=\"0\" baseCharge=\"46.27000045776367\" fuelSurcharge=\"6.25\" totalCharge=\"52.52\" currency=\"CAD\"> </quote>  <quote carrierId=\"1\" carrierName=\"Federal Express\" serviceId=\"3\" serviceName=\"Ground\" modeTransport=\"null\" transitDays=\"0\" baseCharge=\"30.739999771118164\" fuelSurcharge=\"0.0\" totalCharge=\"31.82\" currency=\"CAD\"> <Surcharge id=\"null\" name=\"Other\" amount=\"1.0800000429153442\"/> </quote>  <quote carrierId=\"3\" carrierName=\"Canada WorldWide\" serviceId=\"16\" serviceName=\"Air Freight\" modeTransport=\"null\" transitDays=\"0\" baseCharge=\"300.0\" fuelSurcharge=\"36.0\" totalCharge=\"336.0\" currency=\"CAD\"> </quote>     <quote carrierId=\"3\" carrierName=\"Canada WorldWide\" serviceId=\"15\" serviceName=\"Next Flight Out\" modeTransport=\"null\" transitDays=\"0\" baseCharge=\"165.0\" fuelSurcharge=\"19.8\" totalCharge=\"184.8\" currency=\"CAD\"> </quote>   </QuoteReply> </Eshipper> ";
        }

        private void SetOrderInfoReq(EshipperOrderInfoReq req)
        {
            req.UserName = "Isabella Fong";
            req.Password = "gabby123456";
            req.OrderID = "3793446";
        }

        private void SetShipCancelReq(EshipperShipCancelReq req)
        {
            req.UserName = "Isabella Fong";
            req.Password = "gabby123456";
            req.OrderID = "3793446";
        }


        private void SetQuoteReq(EshipperQuoteReq req)
        {
            req.UserName = "Isabella Fong";
            req.Password = "gabby123456";
            req.ServiceId = "1";
            req.FromId = "123";
            req.FromCompany = "Tweebaa Inc.";
            req.FromAddress1 = "3601 Hwy 7 East, Suite 302, HSBC Tower";
            req.FromAddress2 = "";
            req.FromCity = "Markham";
            req.FromState = "ON";
            req.FromCountry = "CA";
            req.FromZip = "L3R0M3";
            req.ToId = "234";
            req.ToCompany ="Lide Cao";
            req.ToAddress1 ="8 Harrington Cres.";
            req.ToAddress2 ="";
            req.ToCity ="Toronto";
            req.ToState ="ON";
            req.ToCountry="CA";
            req.ToZip ="M2M2Y5";
            req.PackageLength="5";
            req.PackageWidth ="10";
            req.PackageHeight="15";
            req.PackageWeight ="20";
            req.PickupContactName="Lide Cao";
            req.PickupPhoneNumber ="416-723-0947";
            req.PickupDate="2015-06-01";
            req.PickupTime ="13:15";
            req.PickupClosingTime="21:00";
            req.PickupLocation = "Front Door";
        }

        private void SetShipReq(EshipperShipReq req)
        {
            req.UserName = "Isabella Fong";
            req.Password = "gabby123456";
            req.ServiceId = "1";
            req.FromId = "123";
            req.FromCompany = "Tweebaa Inc.";
            req.FromAddress1 = "3601 Hwy 7 East, Suite 302, HSBC Tower";
            req.FromAddress2 = "";
            req.FromCity = "Markham";
            req.FromState = "ON";
            req.FromCountry = "CA";
            req.FromZip = "L3R0M3";
            req.FromPhoneNumber = "9054799969";
            req.FromAttention = "Riz";
            req.ToId = "234";
            req.ToCompany = "Lide Cao";
            req.ToAddress1 = "8 Harrington Cres.";
            req.ToAddress2 = "";
            req.ToCity = "Toronto";
            req.ToState = "ON";
            req.ToCountry = "CA";
            req.ToZip = "M2M2Y5";
            req.ToPhoneNumber = "4167230947";
            req.PackageLength = "5";
            req.PackageWidth = "10";
            req.PackageHeight = "15";
            req.PackageWeight = "20";
            req.PickupContactName = "Lide Cao";
            req.PickupPhoneNumber = "416-723-0947";
            req.PickupDate = "2015-06-01";
            req.PickupTime = "13:15";
            req.PickupClosingTime = "21:00";
            req.PickupLocation = "Front Door";
        }

    }
}