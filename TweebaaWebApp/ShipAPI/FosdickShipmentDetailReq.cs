using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweebaaWebApp.ShipAPI
{
    public class FosdickShipmentDetailReq
    {
        public int? iPage { set; get; }                 // Page number of items to display
        public int? iPerPage { set; get; }              // The number of items to return per page (default: all returns returned)
        public DateTime? dtUpdatedSince { set; get; }   // Only retrieve shipments updated since
        public DateTime? dtUpdatedBefore { set; get; }  // Only retrieve shipments updated before
        public DateTime? dtShippedSince { set; get; }   // Only retrieve shipments shipped since
        public DateTime? dtShippedBefore { set; get; }  // Only retrieve shipments shipped before
        public string sFosdickOrderNo { set; get; }    // Search by Fosdick order number max 17 characters
        public string sExternalOrderNo { set; get; }   // Search by External order number max 50 characters
    }
}