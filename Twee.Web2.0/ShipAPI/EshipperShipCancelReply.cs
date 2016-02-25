using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweebaaWebApp2.ShipAPI
{
    public class EshipperShipCancelReply
    {
        public string OrderID { set; get; }
        public string Message { set; get; }
        public string StatusID { set; get; }
    }
}