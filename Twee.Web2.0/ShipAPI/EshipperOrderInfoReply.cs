using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweebaaWebApp2.ShipAPI
{
    public class EshipperOrderInfoReply
    {
        public string OrderID;
        public string CarrierName;
        public string ServiceName;
        public string TrackingNumber;
        public string TrackingURL;
        public string StatusID;
        public string StatusName;
    }
}