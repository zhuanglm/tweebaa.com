using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweebaaWebApp.ShipAPI
{
    public class EOrderStatusResponse
    {
        public bool bSuccess;
        public string sErrMsg;
        public string sPartnerOrderID;
        public string sStatusID;
        public string sStatusName;
        public string sTrackingUrl;
        public string sReqXml { set; get; }
        public string sResponseXml { set; get; }
        public EOrderStatusResponse()
        {
            bSuccess = false;
        }
     }
}