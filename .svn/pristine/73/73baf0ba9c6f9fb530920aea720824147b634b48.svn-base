using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp.ShipAPI
{
    public partial class TestFosdick : System.Web.UI.Page
    {
        public string _sOrderXML;
        public string _sResponseXML;
        protected void Page_Load(object sender, EventArgs e)
        {
            TestOrder();
        }

        private void TestOrder()
        {
            FosdickAPI api = new FosdickAPI();
            FosdickOrder order = new FosdickOrder();
            SetOrder(order);
            FosdickOrderResponse response = api.Order(order);
        }

        private void SetOrder(FosdickOrder order)
        {
            order.sTest = "y";
            order.sExternalID = "myID123453";
            order.sAdCode = "TEST";
            order.dSubTotal = 1158.00M;
            order.dDiscounts = 0;
            order.dPostage = 0;
            order.dTax = 11.00M;
            order.dTotal = 1169.00M;
            order.sShipFirstName = "Jack";
            order.sShipLastName = "Cao";
            order.sShipAddress1 = "3601 Highway 7 East";
            order.sShipAddress2 = "Suite 302 HSBC Tower";
            order.sShipCity = "Markham";
            order.sShipZip = "L3R0M3";
            order.sShipState = "ON";
            order.sShipCountry = "CA";
            order.sShipPhone = "905-479-9969";
            order.sEmail = "xxx@yyy.com";
            order.sPaymentType = "5"; // prepaid :do not need payment inforamtion and billing information
            order.sUseAsBilling = "y";

            order.ItemList = new List<FosdickOrderItem>();

            FosdickOrderItem item1 = new FosdickOrderItem();
            order.ItemList.Add(item1);
            item1.sInv = "Item00001";
            item1.dPricePer = 9.12M;
            item1.dQty = 100;

            FosdickOrderItem item2 = new FosdickOrderItem();
            order.ItemList.Add(item2);
            item2.sInv = "Item00002";
            item2.dPricePer = 1.23M;
            item2.dQty = 200;
        }
    }
}