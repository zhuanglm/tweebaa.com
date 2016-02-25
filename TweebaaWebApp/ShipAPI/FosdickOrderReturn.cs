using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweebaaWebApp.ShipAPI
{
    public class FosdickOrderReturn
    {
        public string sFosdickOrderNo { set; get; }     // Fosdick order number
        public string sExternalOrderNo { set; get; }    // External order number
        public string sSku { set; get; }                // Product sku
        public int iLineItem { set; get; }              // line item identifier on order
        public int? iExternalLineItem { set; get; }     // External line item identifier on order
        public DateTime? dtReturnDate { set; get; }     // Date returned
        public int iReturnedQty { set; get; }           // Quantity returned
        public int iQuality { set; get; }               // Quality (1/2/0)     // (1/2/0)
        public int iReturnReasonCode { set; get; }      // 
        public string sReturnReasonDesc { set; get; }   // Reason description
        public string sRequestedAction { set; get; }    // Replace/Refund/Do Nothing
        public DateTime dtLastUpdated { set; get; }     // Date last updated
    }
}