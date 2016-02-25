using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweebaaWebApp.ShipAPI
{
    public class EOrderReq
    {
        public string sOrderHeadGuidNo { set; get; }
        public string sFromCompany { set; get; }
        public string sFromAddress { set; get; }
        public string sFromCity { set; get; }
        public string sFromState { set; get; }
        public string sFromZip { set; get; }
        public string sFromCountry { set; get; }
        public string sFromContact { set; get; }
        public string sFromPhone { set; get; }
        public string sFromEmail { set; get; }
        public string sToCompany { set; get; }
        public string sToAddress { set; get; }
        public string sToCity { set; get; }
        public string sToState { set; get; }
        public string sToZip { set; get; }
        public string sToCountry { set; get; }
        public string sToContact { set; get; }
        public string sToPhone { set; get; }
        
        public List<EOrderProduct> ProductList;

        public string sShipType { set; get; }
        public string sPaymentOption { set; get; }
        
        // Order Details
        public string sPurchaseOrderNo { set; get; }
        public string sSpecialInstruction { set; get; }
        public string sRefNo{ set; get; }
        public string sCodAmount { set; get; }
        public string sDateRequired { set; get; }

        public void Clear()
        {
            sOrderHeadGuidNo = "";
            sFromCompany = "";
            sFromAddress = "";
            sFromCity = "";
            sFromState = "";
            sFromZip = "";
            sFromCountry = "";
            sFromContact = "";
            sFromPhone = "";
            sFromEmail = "";
            sToCompany = "";
            sToAddress = "";
            sToCity = "";
            sToState = "";
            sToZip = "";
            sToCountry = "";
            sToContact = "";
            sToPhone = "";
        
            ProductList.Clear();

            sShipType = "";
            sPaymentOption = "";
        
            // Order Details
            sPurchaseOrderNo = "";
            sSpecialInstruction = "";
            sRefNo = "";
            sCodAmount = "";
            sDateRequired = "";
        }

    }
}