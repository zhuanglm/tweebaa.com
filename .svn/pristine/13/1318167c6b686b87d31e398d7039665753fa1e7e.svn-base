using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Twee.Model;
using Twee.Comm;

namespace Twee.Mgr
{
    public partial class ShipOrderMgr
    {
        private readonly Twee.DataMgr.ShipOrderDataMgr mgr = new DataMgr.ShipOrderDataMgr();

        public DataSet GetShipOrderCountByStatus()
        {
            return mgr.GetShipOrderCountByStatus();
        }
        
        public DataSet GetShipOrderInfo(string sOrderNo)
        {
            return mgr.GetShipOrderInfo(sOrderNo);
        }

        public DataSet GetShipOrderDetailSupplier(string sShipOrderID)
        {
            return mgr.GetShipOrderDetailSupplier(sShipOrderID);
        }

        public DataSet GetShipOrderShipmentDetail(int iShipOrderID)
        {
            return mgr.GetShipOrderShipmentDetail(iShipOrderID);
        }

        public DataSet GetShipOrderCancelInfo(string sOrderNo)
        {
            return mgr.GetShipOrderCancelInfo(sOrderNo);
        }

        //member center Shipping order list for drop-shipper
        public DataTable GetShipOrderList(string sShipOrderID, string sTrackingNo, string sShipOrderStatus, string sStartTime, string sEndTime, int iStartRow, int iEndRow, out int iTotalCount)
        {
            return mgr.GetShipOrderList(sShipOrderID, sTrackingNo, sShipOrderStatus, sStartTime, sEndTime, iStartRow, iEndRow, out iTotalCount);
        }
 
        public bool SaveShipment(DB db, int iShipOrderID, int iShipPartnerID, string sShippedDate, string sTrackingNo, string sCarrierName, out string sErrMsg)
        {
            return mgr.SaveShipment(db, iShipOrderID, iShipPartnerID, sShippedDate, sTrackingNo, sCarrierName, out sErrMsg);
        }

        public bool SaveReturn(DB db, int iShipOrderID, int iShipPartnerID, string sReturnDate, string sReasonCode, string sReasonDesc, string sAction, out string sErrMsg)
        {
            return mgr.SaveReturn(db, iShipOrderID, iShipPartnerID, sReturnDate, sReasonCode, sReasonDesc, sAction, out sErrMsg);
        }

        public int UpdateShipOrderStatus(DB db, int iShipOrderID, int iStatus, DateTime dtStatus)
        {
            return mgr.UpdateShipOrderStatus(db, iShipOrderID, iStatus, dtStatus);
        }

        public DataTable MgeGetShipOrderList(int iStartRow, int iEndRow, out int iTotalCount, string sShipOrderID, string sTweebaaOrderID, string sPartnerOrderID,
            string sStartTime, string sEndTime, string sSuccess, string sOrderStartTime, string sOrderEndTime, string sCustomerFirstName, string sCustomerLastName, string sShipToAddress)
        {
            return mgr.MgeGetShipOrderList(iStartRow, iEndRow, out iTotalCount, sShipOrderID, sTweebaaOrderID, sPartnerOrderID,
                sStartTime, sEndTime, sSuccess, sOrderStartTime, sOrderEndTime, sCustomerFirstName, sCustomerLastName, sShipToAddress);
        }
    
    }
}
