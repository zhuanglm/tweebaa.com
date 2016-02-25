using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweebaaWebApp.ShipAPI
{
    public class FosdickOrder
    {
        public string sOrderHeadGuidNo { set; get; }
        public string sTest { set; get; }
        public string sExternalID { set; get; }
        public decimal dSubTotal { set; get; }
        public decimal dDiscounts { set; get; }
        public decimal dPostage { set; get; }
        public decimal dTax { set; get; }
        public decimal dTotal { set; get; }
        public decimal dMxSubtotal { set; get; }
        public decimal dMxTax { set; get; }
        public decimal dMxTotal { set; get; }
        public string sAdCode { set; get; }
        public string sPaymentType { set; get; }
        public string sCCNumber { set; get; }
        public string sCCMonth { set; get; }
        public string sCCYear { set; get; }
        public string sCCV { set; get; }
        public string sShipFirstName { set; get; }
        public string sShipLastName { set; get; }
        public string sShipAddress1 { set; get; }
        public string sShipAddress2 { set; get; }
        public string sShipCity { set; get; }
        public string sShipState { set; get; }
        public string sShipZip { set; get; }
        public string sShipCountry { set; get; }
        public string sShipPhone { set; get; }
        public string sEmail { set; get; }
        public string sUseAsBilling { set; get; }  // y or n
        public string sBillFirstName { set; get; }
        public string sBillLastName { set; get; }
        public string sBillAddress1 { set; get; }
        public string sBillAddress2 { set; get; }
        public string sBillCity { set; get; }
        public string sBillState { set; get; }
        public string sBillZip { set; get; }
        public string sBillCountry { set; get; }
        public string sBillPhone { set; get; }
        public List<FosdickOrderItem> ItemList;

        public void Clear()
        {
            sOrderHeadGuidNo = "";
            sTest = "";
            sExternalID ="";
            dSubTotal = 0;
            dDiscounts = 0;
            dPostage = 0;
            dTax = 0;
            dTotal =0;
            dMxSubtotal = 0;
            dMxTax = 0;
            dMxTotal = 0;
            sAdCode = "";
            sPaymentType ="";
            sCCNumber = "";
            sCCMonth = "";
            sCCYear = "";
            sCCV = "";
            sShipFirstName = "";
            sShipLastName = "";
            sShipAddress1 = "";
            sShipAddress2 = "";
            sShipCity = "";
            sShipState = "";
            sShipZip = "";
            sShipCountry = "";
            sShipPhone = "";
            sEmail = "";
            sUseAsBilling = "";
            sBillFirstName = "";
            sBillLastName = "";
            sBillAddress1 = "";
            sBillAddress2 = "";
            sBillCity = "";
            sBillState = "";
            sBillZip ="";
            sBillCountry = "";
            sBillPhone = "";
            ItemList.Clear();
        }
    }
}