using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweebaaWebApp.ShipAPI
{
    public class FosdickShipmentTracking
    {
        public string sTrackingNo { set; get; }     // Carrier tracking number
        public string sCarrierCode { set; get; }    // 2 character code for carrier
        public string sCarrierName { set; get; }    // Name of carrier
    }
}