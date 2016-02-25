using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweebaaWebApp.ShipAPI
{
    public class FosdickOrderItem
    {
        public string sOrderBodyGuid { set; get; }
        public string sInv { set; get; }
        public decimal dQty { set; get; }
        public decimal dPricePer { set; get; }
    }
}