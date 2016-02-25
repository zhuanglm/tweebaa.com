using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweebaaWebApp2.ShipAPI
{
    public class FosdickInventoryReq
    {
        public int? iPage { set; get; }                     // Page number of products to display. 0 based index.
        public int? iPerPage { set; get; }                  // The number of products to return per page (default: all products returned)
        public DateTime? dtUpdatedSince { set; get; }       // Only retrieve inventory updated since
        public DateTime? dtUpdatedBefore { set; get; }      // Only retrieve inventory updated before
    }
}