using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweebaaWebApp.ShipAPI
{
    public class FosdickOrderCancelResponse
    {
        public bool   bReqSuccess       { get; set; }   // identify if the request is success or not
        public string sReqErrMsg        { get; set; }   // this will be set if request is not successful  
        public bool   bCancelSuccess    { get; set; }   // indentify if the order is canceled successfully
        public string sFosdickOrderNo   { get; set; }   // the canceled order number 
        public string sCancelMsg        { get; set; }   // message for the cancel  
        public string sIdentifier       { get; set; }   // order identfieer
        public string sReqXML           { get; set; }
        public string sResponseXML      { get; set; }
    }
}