using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using Twee.Model;
using Twee.Comm;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using log4net;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace TweebaaWebApp.AjaxPages
{
    public partial class shipOrderAjax : System.Web.UI.Page
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string sAction = "";
        Dictionary<string, object> dic = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
            string sRequestInfo = sr.ReadToEnd();
            //string prdID = Request.Params.Get("id");
            //action = Request.Params.Get("action");
            JavaScriptSerializer js = new JavaScriptSerializer();
            dic = js.Deserialize<Dictionary<string, object>>(sRequestInfo);
            //string prdID = dic["id"].ToString();
            //string shareUrlId = "";
            //prdID = CommUtil.GetUrlPrdId(prdID, out shareUrlId);
            
            sAction = dic["action"].ToString();

            if (!string.IsNullOrEmpty(sAction))
            {
                if (sAction == "query")
                {
                    QueryShipOrderList();//查询列表
                }
                else if (sAction == "querycount")
                {
                    QueryShipOrderListCount();
                }
                else if (sAction == "querycountbystatus")
                {
                    QueryShipOrderCountByStatus();
                }
                else if (sAction == "updatestatus")
                {
                    UpdateStatus();
                }
                else if (sAction == "queryshiporderdetail")
                {
                    QueryShipOrderDetail();
                }
                else if (sAction == "QueryTrackingLink")
                {
                    QueryTrackingLink();
                }
                else if (sAction == "SaveShipment")
                {
                    SaveShipment();
                }
                else if (sAction == "SaveReturn")
                {
                    SaveReturn();
                }


            }
            else
            {
                Response.Clear();
                Response.Write("error");
                return;
            }          
        }  // end of Page_Load


        private void QueryTrackingLink()
        {
            try
            {
                Response.Clear();

                string sCarrierName = dic["CarrierName"].ToNullString();
                string sTrackingNo = dic["TrackingNo"].ToNullString();
                TweebaaWebApp2.ShipAPI.ShipOrder so = new TweebaaWebApp2.ShipAPI.ShipOrder();
                string sTrackingLink = CommUtil.GetTrackingLink(sCarrierName, sTrackingNo);

                Response.Write(sTrackingLink);
            }
            catch (Exception)
            {
                Response.Write("0");
            }
        }



        private void QueryShipOrderCountByStatus()
        {
            try
            {
                Response.Clear();

                ShipOrderMgr mgr = new ShipOrderMgr();
                DataSet ds = mgr.GetShipOrderCountByStatus();
                if (ds == null || ds.Tables.Count == 0)
                {
                    Response.Write("0");
                    return;
                }

                DataTable dt = ds.Tables[0];
                if (dt == null || dt.Rows.Count == 0)
                {
                    Response.Write("0");
                    return;
                }
                string sShipOrderSum = JsonConvert.SerializeObject(dt);
                Response.Write(sShipOrderSum);
            }
            catch (Exception)
            {
                Response.Write("0");
            }
        }



        private void QueryShipOrderDetail()
        {
            try
            {
                Response.Clear();
                string sShipOrderID = dic["shiporderid"].ToNullString();

                ShipOrderMgr mgr = new ShipOrderMgr();
                DataSet ds = mgr.GetShipOrderDetailSupplier(sShipOrderID);
                if (ds == null || ds.Tables.Count == 0)
                {
                    Response.Write("0");
                    return;
                }

                DataTable dt = ds.Tables[0];
                if (dt == null || dt.Rows.Count == 0)
                {
                    Response.Write("0");
                    return;
                }
                string sShipOrderDetail = JsonConvert.SerializeObject(dt);
                Response.Write(sShipOrderDetail);
            }
            catch (Exception)
            {
                Response.Write("0");
            }
        }

        
        private void QueryShipOrderList()
        {
            try
            {
                Response.Clear();
                string sShipOrderID = dic["shiporderid"].ToNullString();
                string sTrackingNo = dic["trackingno"].ToNullString();
                string sShipOrderStatus = dic["orderstatus"].ToNullString(); 
                string sStartTime = dic["beginTime"].ToString();
                string sEndTime = dic["endTime"].ToString();
                int iPage = dic["page"].ToNullString().ToInt();

                int iStartRow = ConfigParamter.prdPageSize * (iPage - 1) + 1;
                int iEndRow = ConfigParamter.prdPageSize * iPage;
                int iTotalCount = 0;

                ShipOrderMgr mgr = new ShipOrderMgr();
                DataTable dt = mgr.GetShipOrderList(sShipOrderID, sTrackingNo, sShipOrderStatus, sStartTime, sEndTime, iStartRow, iEndRow, out iTotalCount);
                if (dt == null || dt.Rows.Count == 0)
                {
                    Response.Write("0");
                    return;
                }
                string sShipOrderList = JsonConvert.SerializeObject(dt);
                Response.Write(sShipOrderList);
            }
            catch (Exception)
            {
                Response.Write("0");
            }

        }

        private void QueryShipOrderListCount()
        {
            try
            {
                Response.Clear();
                string sShipOrderID = dic["shiporderid"].ToNullString();
                string sTrackingNo = dic["trackingno"].ToNullString();
                string sShipOrderStatus = dic["orderstatus"].ToNullString();
                string sStartTime = dic["beginTime"].ToString();
                string sEndTime = dic["endTime"].ToString();

                ShipOrderMgr mgr = new ShipOrderMgr();
                int iStartRow = 1;
                int iEndRow = 1;
                int iTotalCount;
                DataTable dt = mgr.GetShipOrderList(sShipOrderID, sTrackingNo, sShipOrderStatus, sStartTime, sEndTime, iStartRow, iEndRow, out iTotalCount);
                Response.Write(iTotalCount);
            }
            catch (Exception ex)
            {
                Response.Write("0");
            }

        }

        private void UpdateStatus()
        {
            try
            {
                Response.Clear();
                int iShipOrderID = dic["shiporderid"].ToNullString().ToInt();
                int iStatus = dic["status"].ToString().ToInt();
 
                ShipOrderMgr mgr = new ShipOrderMgr();
                DB db = new DB();
                
                db.DBConnect();
                db.DBBeginTrans();
                int iCnt = mgr.UpdateShipOrderStatus(db, iShipOrderID, iStatus, DateTime.Now);
                db.DBCommitTrans();
                db.DBDisconnect();

                Response.Write(iCnt);
            }
            catch (Exception ex)
            {
                Response.Write("0");
            }

        }

        private void SaveShipment()
        {
            try
            {
                Response.Clear();
                int iShipOrderID = dic["ShipOrderID"].ToNullString().ToInt();
                string sShippedDate = dic["ShippedDate"].ToNullString();
                string sTrackingNo = dic["TrackingNo"].ToNullString();
                string sCarrierName = dic["CarrierName"].ToNullString();

                ShipOrderMgr mgr = new ShipOrderMgr();
                DB db = new DB();

                db.DBConnect();
                db.DBBeginTrans();

                int iShipPartnerID = (int)ConfigParamter.ShipPartner.DropShipper;
                string sErrMsg = string.Empty;

                bool bOK = mgr.SaveShipment(db, iShipOrderID, iShipPartnerID, sShippedDate, sTrackingNo, sCarrierName, out sErrMsg);

                if (bOK) db.DBCommitTrans();
                else db.DBRollbackTrans();
                db.DBDisconnect();

                Response.Write("1");
            }
            catch (Exception ex)
            {
                Response.Write("0");
            }

        }

        private void SaveReturn()
        {
            try
            {
                Response.Clear();
                int iShipOrderID = dic["ShipOrderID"].ToNullString().ToInt();
                string sReturnDate = dic["ReturnDate"].ToNullString();
                string sReturnQuality = dic["ReturnQuality"].ToNullString();
                string sReturnReasonCode = dic["ReturnReasonCode"].ToNullString();
                string sReturnReasonDesc = dic["ReturnReasonDesc"].ToNullString();
                string sReturnAction = dic["ReturnAction"].ToNullString();

                ShipOrderMgr mgr = new ShipOrderMgr();
                DB db = new DB();

                db.DBConnect();
                db.DBBeginTrans();

                int iShipPartnerID = (int)ConfigParamter.ShipPartner.DropShipper;
                string sErrMsg = string.Empty;

                bool bOK = mgr.SaveReturn(db, iShipOrderID, iShipPartnerID, sReturnDate, sReturnReasonCode, sReturnReasonDesc, sReturnAction, out sErrMsg);

                if (bOK) db.DBCommitTrans();
                else db.DBRollbackTrans();
                db.DBDisconnect();

                Response.Write("1");
            }
            catch (Exception ex)
            {
                Response.Write("0");
            }

        }

    }
}