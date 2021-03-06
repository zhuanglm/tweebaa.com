﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using AjaxPro;
using Twee.Comm;

namespace TweebaaWebApp2.Mgr.ShipOrderMgr
{
    public partial class ShipOrderDetail : System.Web.UI.Page
    {
        string _sShipOrderID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(ShipOrderDetail));

            if (string.IsNullOrEmpty(Request["id"]))
                return;
            else
                _sShipOrderID = Request["id"].Trim();

            if (!IsPostBack)
            {
                ShowShipOrderDetail();
            }
        }

        private bool ShowShipOrderDetail()
        {
            Twee.Mgr.ShipOrderMgr soMgr = new Twee.Mgr.ShipOrderMgr();
            DataSet ds = soMgr.GetShipOrderDetailSupplier(_sShipOrderID);
            if (ds == null) return false;
            if (ds.Tables.Count == 0) return false;
            DataTable dt = ds.Tables[0];
            if (dt == null) return false;
            if (dt.Rows.Count == 0) return false;
            DataRow dr = dt.Rows[0];

            lblShipOrderID.Text = _sShipOrderID;
            lblTweebaaOrderID.Text = dr["OrderHead_GuidNo"]._ObjToString();
            lblCustomerOrderDate.Text = dr["OrderDate"]._ObjToString();
            lblShipPartnerOrderID.Text = dr["ShipOrder_PartnerOrderID"]._ObjToString();
            lblShipedDate.Text = dr["ShipOrder_ShippedDate"]._ObjToString();
            lblShipOrderStatus.Text = Twee.Comm.CommUtil.GetOrderStatusName(dr["ShipOrder_Status"]._ObjToString().ToInt());
            lblShipToName.Text = dr["ShipTo_FirstName"]._ObjToString() + " " + dr["ShipTo_LastName"]._ObjToString();
            lblShipToAddress.Text = dr["ShipTo_Address1"]._ObjToString();
            lblShipToCityProvinceZip.Text = dr["ShipTo_City"]._ObjToString() + ", " + dr["ShipTo_ProvinceName"]._ObjToString() + " " + dr["ShipTo_ZIP"]._ObjToString();
            lblShipToCountry.Text = dr["ShipTo_CountryName"]._ObjToString();
            lblShipToPhone.Text = dr["ShipTo_Phone"]._ObjToString();
            lblShipToEmail.Text = dr["ShipTo_Email"]._ObjToString();
            string xmlReq = Server.HtmlEncode(dr["ShipOrder_ReqXML"]._ObjToString());
            string xmlReponse = Server.HtmlEncode(dr["ShipOrder_ResponseXML"]._ObjToString());
            litReqXML.Text = xmlReq;
            litResponseXML.Text = xmlReponse;



            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add(new DataColumn("ProductName", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("TweebaaSKU", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("ItemTypeName", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("ItemName", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("ItemQuantity", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("ItemUnitPrice", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("ItemShipFee", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("TaxSum", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("TrackingNo", typeof(string)));
            dtGrid.Columns.Add(new DataColumn("CarrierName", typeof(string)));
            foreach (DataRow drItem in dt.Rows)
            {
                DataRow drGrid = dtGrid.NewRow();
                
                drGrid["ProductName"] = drItem["ProductName"]._ObjToString();
                drGrid["TweebaaSKU"] = drItem["Item_TweebaaSku"]._ObjToString();
                drGrid["ItemTypeName"] = drItem["Item_TypeName"]._ObjToString();
                drGrid["ItemName"] = drItem["Item_Name"]._ObjToString();
                drGrid["ItemQuantity"] = drItem["Item_Quantity"].ToString().ToDecimal().ToString("#0");
                drGrid["ItemUnitPrice"] = drItem["Item_UnitPrice"].ToString().ToDecimal().ToString("#0.00");
                drGrid["ItemShipFee"] = drItem["Item_ShipFee"].ToString().ToDecimal().ToString("#0.00");
                drGrid["TaxSum"] = drItem["TaxSum"].ToString().ToDecimal().ToString("#0.00");
                string sTrackingNo = drItem["ShipOrder_TrackingNo"]._ObjToString();
                string sCarrierName = drItem["ShipOrder_CarrierName"]._ObjToString();
                drGrid["TrackingNo"] = "<a target=\"_blank\" href=\"" + CommUtil.GetTrackingLink(sCarrierName, sTrackingNo) + "\">" + sTrackingNo + "</a>";
                drGrid["CarrierName"] = sCarrierName; 

                dtGrid.Rows.Add(drGrid);
                //dtGrid.Rows.Add("aaa", "bbb");
            }

            gdvProduct.Visible = true;
            gdvProduct.AutoGenerateColumns = false;
            gdvProduct.DataSource = dtGrid;
            gdvProduct.DataBind();

            return true;
        }
    }
}