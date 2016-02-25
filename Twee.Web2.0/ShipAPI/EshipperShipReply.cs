using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweebaaWebApp2.ShipAPI
{
    public class EshipperShipReply
    {
        public string OrderID {set; get;}
        public string CarrierName { set; get; }
        public string ServiceName { set; get; }
        public string ReferenceCode { set; get; }
        public string ReferenceName { set; get; }
        public string TrackingNUmber { set; get; }
        public string ConfirmationNumber { set; get; }
        public string TrackingURL { set; get; }
    }
}