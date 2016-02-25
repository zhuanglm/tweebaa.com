using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweebaaWebApp2.ShipAPI
{
    public class EOrderResponse
    {
        public string sReqXml { set; get; }
        public string sResponseXml { set; get; }
        public string sOrderID { set; get; }                // partner Order No
        public string sMsg { set; get; }                    // normal message
        public string sPurchaseOrderNo { set; get; }        // tweebaa purchase order number
        public string sRefNo { set; get; }                  // reference number same as tweebaa purchase order number
        public string sErrMsg { set; get; }
        public bool   bSuccess { set; get; }
        public EOrderResponse()
        {
            bSuccess = false;
        }
    }

}