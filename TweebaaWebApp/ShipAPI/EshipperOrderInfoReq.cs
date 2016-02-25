using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweebaaWebApp.ShipAPI
{
    public class EshipperOrderInfoReq
    {   
        public string UserName { set; get; }
        public string Password { set; get; }
        public string OrderID {set;get;}
    }
}