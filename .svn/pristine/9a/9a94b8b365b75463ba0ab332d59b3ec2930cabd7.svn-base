using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweebaaWebApp.ShipAPI
{
    public class EOrderProductInfoResponse
    {
        public bool bSuccess { set; get; }
        public string sErrMsg { set; get; }
        public string sProductNo { set; get; }
        public string sProductInStock { set; get; }     // Quantity of product physically in stock at the warehouse
        public string sProductInQueue { set; get; }     // Quantity of product required to fulfill existing open orders.        
        public string sProductQuarantined { set; get; } // Quantity of product quarantined due to defect. 
        public string sProductAvailable { set; get; }   // Quantity of product not committed and available for sale. This amount is calculated as (productInStock - productInQueue - productQuaratine). 
        public string sReqXml { set; get; }
        public string sResponseXml { set; get; }

        public EOrderProductInfoResponse()
        {
            bSuccess = false;
        }

    }
}