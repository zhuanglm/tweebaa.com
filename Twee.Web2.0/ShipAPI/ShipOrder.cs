﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.IO;
using System.Globalization;
using Twee.Comm;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Newtonsoft.Json;
using System.Configuration;
using Twee.Mgr;

namespace TweebaaWebApp2.ShipAPI
{
    public class ShipOrder
    {
        #region common
        private string Quo(string s)
        {
            string sOut = "";
            string sIn = s.Trim();

            foreach (char c in s)
            {
                sOut = sOut + c;
                if (c == '\'') sOut = sOut + c;
            }
            return sOut;
        }

        private string GetCountryName(int iCountryID)
        {
            if (iCountryID == (int)(ConfigParamter.CountryID.USA)) return "US";
            else if (iCountryID == (int)(ConfigParamter.CountryID.Canada)) return "CA";
            else return "??";
        }


        public string ReadEmailTemplate(string sFileName)
        {
            string sFullFileName = System.Web.HttpContext.Current.Server.MapPath("~") + @"\ShipAPI\" + sFileName;
            StreamReader sr = null;
            string sEmailTemplate = string.Empty;
            try
            {
                sr = new StreamReader(sFullFileName, Encoding.GetEncoding("UTF-8"));
                sEmailTemplate = sr.ReadToEnd(); // read the file 
            }
            catch (Exception exp)
            {
                CommHelper.WrtLog(exp.Message);
            }
            finally
            {
                sr.Dispose();
                sr.Close();
            }

            return sEmailTemplate;
        }
        #endregion

        public string CreatePackListPDFReport(int iShipOrderID)
        {
            // load crystal report
            var crxRpt = new ReportDocument();
            string sRptFullFileName = System.Web.HttpContext.Current.Server.MapPath("~") + @"\ShipAPI\DropShipperOrderPackageList.rpt";
            crxRpt.Load(sRptFullFileName); 

            // set parameter
            ParameterFieldDefinitions crParameterFieldDefinitions ;
            ParameterFieldDefinition crParameterFieldDefinition ;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = iShipOrderID.ToString();
            crParameterFieldDefinitions = crxRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["ShipOrderID"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            // set database conection
            TableLogOnInfo logOnInfo;
            int IsSandbox = ConfigurationManager.AppSettings.Get("IsPaypal_Sandbox").ToInt();
            string sDBServerName = "";
            string sDBName = "";
            string sDBUserName = "";
            string sDBUserPassword = "";
            if (IsSandbox == 1)
            {
                 sDBServerName = System.Configuration.ConfigurationManager.AppSettings["DBServerName"];
                 sDBName = System.Configuration.ConfigurationManager.AppSettings["DBName"];
                 sDBUserName = System.Configuration.ConfigurationManager.AppSettings["DBUserName"];
                 sDBUserPassword = System.Configuration.ConfigurationManager.AppSettings["DBUserPassword"];
            }
            else if (IsSandbox == 2)
            {
                //strConn = "Data Source=192.168.1.100; Initial Catalog=TweebaaEn;User Id=sa;Password=Tweebaa@2012!2050;max pool size=1000";
                sDBServerName = "118.193.145.224";
                sDBName = "TweebaaEn";
                sDBUserName = "sa";
                sDBUserPassword = "Tweebaa@2012!2050@#$2016";
            }
            else
            {
                //strConn = "Data Source=192.168.1.100; Initial Catalog=TweebaaEn;User Id=sa;Password=Tweebaa@2012!2050;max pool size=1000";
                sDBServerName = "192.168.1.100";
                sDBName = "TweebaaEn";
                sDBUserName = "sa";
                sDBUserPassword = "Tweebaa@2012!2050@#$2016";
            }
            try
            {
                foreach (CrystalDecisions.CrystalReports.Engine.Table tb in crxRpt.Database.Tables)
                {
                    logOnInfo = tb.LogOnInfo;
                    logOnInfo.ReportName = crxRpt.Name;
                    logOnInfo.ConnectionInfo.ServerName = sDBServerName;
                    logOnInfo.ConnectionInfo.DatabaseName = sDBName;
                    logOnInfo.ConnectionInfo.UserID = sDBUserName;
                    logOnInfo.ConnectionInfo.Password = sDBUserPassword;
                    logOnInfo.TableName = tb.Name;
                    tb.ApplyLogOnInfo(logOnInfo);
                    tb.Location = tb.Name;
                }

                // export
                ExportOptions CrExportOptions ;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                string sPDFFullFileName = System.Web.HttpContext.Current.Server.MapPath("~") + @"\ShipOrderPackList\" + iShipOrderID.ToString() + " Packing List.pdf";
                CrDiskFileDestinationOptions.DiskFileName = sPDFFullFileName;
                CrExportOptions = crxRpt.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                }
                crxRpt.Export();
                return sPDFFullFileName;
            }
            catch (Exception ex)
            {
                CommUtil.GenernalErrorHandler(ex);
                throw;
            }
        }

        private bool SendDropShipperEmail(DropShipperOrder dropShipperOrder)
        {
            try
            {
                // create PO Packlist PDF report
                string sPDFFileName = CreatePackListPDFReport(dropShipperOrder.iShipOrderID);
 
                // read email template
                string sEmailTemplate = ReadEmailTemplate("EmailDropShipperShipOrder.html");

                // set email info
                //sEmailTemplate = sEmailTemplate.Replace("#OrderDate#", dropShipperOrder.dtOrderDate.ToLongDateString() + " " + dropShipperOrder.dtOrderDate.ToLongTimeString());
                CultureInfo ciUSA = new CultureInfo("en-US");
                sEmailTemplate = sEmailTemplate.Replace("#OrderDate#", dropShipperOrder.dtOrderDate.ToString("dddd, MMMM dd, yyyy h:mm:ss tt", ciUSA));
                sEmailTemplate = sEmailTemplate.Replace("#TweebaaOrder#", dropShipperOrder.sOrderHeadGuidNo);
                sEmailTemplate = sEmailTemplate.Replace("#ShipOrder#", dropShipperOrder.iShipOrderID.ToString());
                sEmailTemplate = sEmailTemplate.Replace("#SupplierID#", dropShipperOrder.sSupplierID);
                sEmailTemplate = sEmailTemplate.Replace("#ShipMethod#", dropShipperOrder.sShipMethodName);

                StringBuilder sShipTo = new StringBuilder();
                sShipTo.Append(dropShipperOrder.sToCompany + "<br/>");
                sShipTo.Append(dropShipperOrder.sToAddress + "<br/>");
                sShipTo.Append(dropShipperOrder.sToCity + "<br/>");
                sShipTo.Append(dropShipperOrder.sToState + " " + dropShipperOrder.sToZip + ", " + dropShipperOrder.sToCountry + "<br/>");
                sShipTo.Append(dropShipperOrder.sToPhone);
                sEmailTemplate = sEmailTemplate.Replace("#ShipTo#", sShipTo.ToString());

                decimal dTotalPrice = 0;
                decimal dTotalSupplierShipFee = 0;
                StringBuilder sOrderItem = new StringBuilder();
                foreach (DropShipperOrderItem item in dropShipperOrder.ItemList)
                {
                    decimal dLineTotal = Math.Round(item.dQty * item.dUnitPrice, 2);
                    sOrderItem.Append("<tr>");
                    sOrderItem.Append("<td style=\"border-top: #eee 1px solid; padding:30px 10px ;\">" + item.sTweebaaSku+ "</td>");
                    sOrderItem.Append("<td style=\"border-top: #eee 1px solid; \">" + item.sSupplierSku +"</td>");
                    sOrderItem.Append("<td style=\"border-top: #eee 1px solid; \">" + item.dQty.ToString("#0") + "</td>");
                    sOrderItem.Append("<td style=\"border-top: #eee 1px solid; \">" + item.sProductName + " <br/> " + item.sDesc + "</td>");
                    sOrderItem.Append("<td style=\"border-top: #eee 1px solid; \">$" + item.dUnitPrice.ToString("#0.00") + "</td>");
                    sOrderItem.Append("<td style=\"border-top: #eee 1px solid; \">$" + dLineTotal.ToString("#0.00") + "</td>");
                    sOrderItem.Append("</tr>");

                    dTotalPrice += dLineTotal;
                    //dTotalShipFee += item.dQty * item.dShipFee;
                    dTotalSupplierShipFee += item.dQty*item.dSupplierShipFee;
                }
                sEmailTemplate = sEmailTemplate.Replace("#TotalPrice#", dTotalPrice.ToString("#0.00"));
                sEmailTemplate = sEmailTemplate.Replace("#ShipFee#", dTotalSupplierShipFee.ToString("#0.00"));
                sEmailTemplate = sEmailTemplate.Replace("#OrderItem#", sOrderItem.ToString());
               // create package list report
                // attachek to email
                // send email
                string sTitle = "Tweebaa PO#: " + dropShipperOrder.iShipOrderID.ToString();

                //bool bSend = Twee.Comm.Mailhelper.SendMail(sTitle, sEmailTemplate, dropShipperOrder.sFromEmail, sPDFFileName);
                bool bSend = Twee.Comm.Mailhelper.SendMail(sTitle, sEmailTemplate, "shipping@tweebaa.com", sPDFFileName);
                Twee.Comm.Mailhelper.SendMail(sTitle, sEmailTemplate, "jack@leivaire.com", sPDFFileName);
                
            }
            catch(Exception ex)
            {
                CommUtil.GenernalErrorHandler(ex);
                return false;
            }
            return true;
        }

        #region send Drop Shipper Order
        private ShipOrderResult SendDropShipperOrder(DropShipperOrder dropShipperOrder)
        {

            int iSuccess = 1;

            ShipOrderResult result = new ShipOrderResult();
            result.iShipOrderID = dropShipperOrder.iShipOrderID;
            result.sPartnerOrderID = string.Empty;
            result.iPartnerID = (int)(ConfigParamter.ShipPartner.DropShipper);
            result.sPartnerName = ConfigParamter.ShipPartner.DropShipper.ToString();
            result.sDropShipperCompanyName = dropShipperOrder.sFromCompany;
            result.sErrMsg = string.Empty;

            // create db
            DB db = new DB();

            try
            {
                // connect and  start transaction
                db.DBConnect();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            try
            {
                db.DBBeginTrans();

                // insert order info
                StringBuilder sSql = new StringBuilder();
                sSql.Append("insert into wn_ShipOrder(ShipOrder_ID, OrderHead_GuidNo, ShipPartner_ID, ShipOrder_IsSuccess, ShipOrder_Date, ShipOrder_Status, ShipOrder_ReqXML, ShipOrder_ResponseXML, ShipOrder_ErrMsg, ShipOrder_PartnerOrderID, ShipOrder_WarehouseErrorCode, ShipOrder_WarehouseErrorDetail)");
                sSql.Append(" values(");
                sSql.Append(dropShipperOrder.iShipOrderID.ToString() + ",");                                             // ship order id
                sSql.Append("'" + dropShipperOrder.sOrderHeadGuidNo + "',");                            // Order Head Guid number ( not is the Head Guid)
                sSql.Append(((int)(ConfigParamter.ShipPartner.DropShipper)).ToString() + ",");          // ship partnar id
                sSql.Append(iSuccess.ToString() + ",");                                                 // ship order success or not
                sSql.Append("getdate(),");                                                              // Ship Order Date
                sSql.Append(((int)(ConfigParamter.DropshipperOrderStatus.Submitted)).ToString() + ","); // Use the droppershipper order status as the shipping order status
                sSql.Append("' ',");                                                                    // Ship Order request XML
                sSql.Append("' ',");                                                                    // Ship Order response XML
                sSql.Append("null,");                                                               // error message
                sSql.Append("' ',");                                         // Ship Order ID from ship partner
                sSql.Append("null,");                                                               // error code
                sSql.Append("null)");                                                               // error list  

                result.sPartnerOrderID = string.Empty;
                result.sErrMsg = string.Empty;
                db.DBExecute(sSql.ToString());

                // insert order item info
                string sOrderBodyGuidList = string.Empty;   // accumulate orderbody guid of all items 

                foreach (DropShipperOrderItem item in dropShipperOrder.ItemList)
                {
                    // accumulate guid of orderbody
                    if (sOrderBodyGuidList != string.Empty) sOrderBodyGuidList += ",";
                    sOrderBodyGuidList += "'" + item.sOrderBodyGuid + "'";
                    
                    sSql.Clear();
                    sSql.Append("insert into wn_ShipOrderItem(ShipOrder_ID, OrderHead_GuidNo, OrderBody_Guid)");
                    sSql.Append("values(");
                    sSql.Append(dropShipperOrder.iShipOrderID.ToString() + ",");
                    sSql.Append("'" + dropShipperOrder.sOrderHeadGuidNo + "',");
                    sSql.Append("'" + item.sOrderBodyGuid + "')");
                    db.DBExecute(sSql.ToString());
                }

                // update Orderbody when success
                if (iSuccess == 1)
                {
                    sSql.Clear();
                    sSql.Append("update wn_OrderBody set ShipOrder_ID=" + dropShipperOrder.iShipOrderID.ToString());
                    sSql.Append(" where guid in (" + sOrderBodyGuidList + ")");
                    int iRow = db.DBExecute(sSql.ToString());

                    // update order status of order head
                    // do not update order status because here just send PO to drop-shipper 
                    // iRow = UpdateOrderStatus(db, dropShipperOrder.sOrderHeadGuidNo, (int)(ConfigParamter.OrderStatus.Shipped));
                }

                db.DBCommitTrans();
                db.DBDisconnect();

            }
            catch (Exception ex)
            {
                db.DBRollbackTrans();
                db.DBDisconnect();
                throw new Exception(ex.Message);
            }

            // send email to drop-shipper
            try
            {
                SendDropShipperEmail(dropShipperOrder);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Send Warehouse Shipping order
        private ShipOrderResult SendWarehouseShipOrder(FosdickOrder warehouseOrder)
        {
            
            int iSuccess = 0;

            ShipOrderResult result = new ShipOrderResult();
            result.iShipOrderID = warehouseOrder.iShipOrderID;
            result.sPartnerOrderID = string.Empty;
            result.iPartnerID = (int)(ConfigParamter.ShipPartner.Fosdick);
            result.sPartnerName = ConfigParamter.ShipPartner.Fosdick.ToString();
            result.sDropShipperCompanyName = ConfigParamter.ShipPartner.Fosdick.ToString();
            result.sErrMsg = string.Empty;
 
            FosdickOrderResponse response;
            try
            {
                // send hip order to warhouse 
                FosdickAPI api = new FosdickAPI();
                response = api.Order(warehouseOrder);
                iSuccess = (response.bSuccess) ? 1 : 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            // create db
            DB db = new DB();

            try
            {
                // connect and  start transaction
                db.DBConnect();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            try
            {
                db.DBBeginTrans();

                result.iShipOrderID = warehouseOrder.iShipOrderID;

                // insert order info
                StringBuilder sSql = new StringBuilder();
                sSql.Append("insert into wn_ShipOrder(ShipOrder_ID, OrderHead_GuidNo, ShipPartner_ID, ShipOrder_IsSuccess, ShipOrder_Date, ShipOrder_Status, ShipOrder_ReqXML, ShipOrder_ResponseXML, ShipOrder_ErrMsg, ShipOrder_PartnerOrderID, ShipOrder_WarehouseErrorCode, ShipOrder_WarehouseErrorDetail)");
                sSql.Append(" values(");
                sSql.Append(warehouseOrder.iShipOrderID.ToString() + ",");                               // ship order id
                sSql.Append("'" + warehouseOrder.sOrderHeadGuidNo + "',");                               // Order Head Guid number ( not is the Head Guid)
                sSql.Append(((int)(ConfigParamter.ShipPartner.Fosdick)).ToString() + ",");              // ship partnar id
                sSql.Append(iSuccess.ToString() + ",");                                                 // ship order success or not
                sSql.Append("getdate(),");                                                              // Ship Order Date
                sSql.Append(((int)(ConfigParamter.DropshipperOrderStatus.Submitted)).ToString() + ","); // Use the droppershipper order status as the shipping order status
                sSql.Append("'" + Quo(response.sReqXML) + "',");                                         // Ship Order request XML
                sSql.Append("'" + Quo(response.sResponseXML) + "',");                                    // Ship Order response XML
                if (iSuccess == 1)
                {
                    sSql.Append("null,");                                                               // error message
                    sSql.Append("'" + response.sOrderNo + "',");                                         // Ship Order ID from ship partner
                    sSql.Append("null,");                                                               // error code
                    sSql.Append("null)");                                                               // error list  

                    result.sPartnerOrderID = response.sOrderNo;
                    result.sErrMsg = string.Empty;
                }
                else
                {
                    StringBuilder sErrDetail = new StringBuilder();
                    foreach (string s in response.ErrList)
                    {
                        sErrDetail.Append(s + "\n");
                    }
                    sSql.Append("'" + Quo(sErrDetail.ToString()) + "',");                       // error message    
                    sSql.Append("null,");                                                       // Ship Order ID from ship partner
                    sSql.Append("'" + Quo(response.sErrCode) + "',");                          // error code
                    sSql.Append("'" + Quo(sErrDetail.ToString()) + "')");                       // error list    

                    result.sPartnerOrderID = string.Empty;
                    result.sErrMsg = sErrDetail.ToString();

                }
                db.DBExecute(sSql.ToString());

                // insert order item info
                string sOrderBodyGuidList = string.Empty;   // accumulate orderbody guid of all items 
                foreach (FosdickOrderItem item in warehouseOrder.ItemList)
                {
                    // accumulate guid of orderbody
                    if (sOrderBodyGuidList != string.Empty) sOrderBodyGuidList += ",";
                    sOrderBodyGuidList += "'" + item.sOrderBodyGuid + "'";

                    sSql.Clear();
                    sSql.Append("insert into wn_ShipOrderItem(ShipOrder_ID, OrderHead_GuidNo, OrderBody_Guid)");
                    sSql.Append("values(");
                    sSql.Append(warehouseOrder.iShipOrderID.ToString() + ",");
                    sSql.Append("'" + warehouseOrder.sOrderHeadGuidNo + "',");
                    sSql.Append("'" + item.sOrderBodyGuid + "')");
                    db.DBExecute(sSql.ToString());

                }

                // update Orderbody when success
                if (iSuccess == 1)
                {
                    sSql.Clear();
                    sSql.Append("update wn_OrderBody set ShipOrder_ID=" + warehouseOrder.iShipOrderID.ToString());
                    sSql.Append(" where guid in (" + sOrderBodyGuidList + ")");
                    int iRow = db.DBExecute(sSql.ToString());

                    // update order status of order head
                    //iRow = UpdateOrderStatus(db, warehouseOrder.sOrderHeadGuidNo, (int)(ConfigParamter.OrderStatus.Shipped));
                }

                db.DBCommitTrans();
                db.DBDisconnect();

                return result;
            }
            catch (Exception ex)
            {
                db.DBRollbackTrans();
                db.DBDisconnect();
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Send EOrder Order
        private ShipOrderResult  SendEOrderOrder(EOrderReq eOrder)
        {
            ShipOrderResult result = new ShipOrderResult();
            result.iShipOrderID = eOrder.iShipOrderID;
            result.sPartnerOrderID = string.Empty;
            result.iPartnerID = (int)(ConfigParamter.ShipPartner.EOrder);
            result.sPartnerName = ConfigParamter.ShipPartner.EOrder.ToString();
            result.sDropShipperCompanyName = eOrder.sFromCompany;
            result.sErrMsg = string.Empty;
            int iSuccess = 0;
            EOrderResponse response;

            try
            {
                // send ship order to eOrder 
                EOrderAPI api = new EOrderAPI();
                response = api.Order(eOrder);
                iSuccess = (response.bSuccess) ? 1 : 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            // create db
            DB db = new DB();

            try
            {
                // connect and  start transaction
                db.DBConnect();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            try
            {
                db.DBBeginTrans();

                // set Ship Order ID
                result.iShipOrderID = eOrder.iShipOrderID;

                // insert order info
                StringBuilder sSql = new StringBuilder();
                sSql.Append("insert into wn_ShipOrder(ShipOrder_ID, OrderHead_GuidNo, ShipPartner_ID, ShipOrder_IsSuccess, ShipOrder_Date, ShipOrder_Status, ShipOrder_ReqXML, ShipOrder_ResponseXML, ShipOrder_ErrMsg, ShipOrder_PartnerOrderID ");
                sSql.Append(", ShipOrder_DropShipperPurchaseOrderNo, ShipOrder_DropShipperRefNo, ShipOrder_DropShipperMsg, ShipOrder_DropShipperErrMsg, ShipOrder_DropShipperStatusID, ShipOrder_DropShipperStatusName,ShipOrder_DropShipperTrackUrl)");
                sSql.Append(" values(");
                sSql.Append(eOrder.iShipOrderID.ToString() + ",");                                                 // ship order id
                sSql.Append("'" + eOrder.sOrderHeadGuidNo + "',");                                         // Order Head Guid number ( not is the Head Guid)
                sSql.Append(((int)(ConfigParamter.ShipPartner.EOrder)).ToString() + ",");                  // ship partnar id
                sSql.Append(iSuccess.ToString() + ",");                                                     // ship order success or not
                sSql.Append("getdate(),");                                                                  // Ship Order Date
                sSql.Append(((int)(ConfigParamter.DropshipperOrderStatus.Submitted)).ToString() + ",");     // status submitted
                sSql.Append("'" + Quo(response.sReqXml) + "',");                                            //Ship Order request XML
                sSql.Append("'" + Quo(response.sResponseXml) + "',");                                       // Ship Order response XML
                if (iSuccess == 1)
                {
                    int iStatusID = (int)(ConfigParamter.DropshipperOrderStatus.Submitted);
                    sSql.Append("null,");                                                           // err message
                    sSql.Append("'" + response.sOrderID + "',");                                 // Ship Order ID from ship partner
                    sSql.Append("'" + response.sPurchaseOrderNo + "',");                                              
                    sSql.Append("'" + response.sRefNo + "',");                                                       
                    sSql.Append("'" + Quo(response.sMsg) + "',");                                                    
                    sSql.Append("null,");
                    sSql.Append( iStatusID.ToString() + ",");                                                        //     DropShipperStatusID
                    sSql.Append( "'" + ConfigParamter.DropshipperOrderStatusNameEn[iStatusID].ToString() + "',");    //     DropShipperStatusName
                    sSql.Append("null)");                                                                            // track URL
                    result.sPartnerOrderID = response.sOrderID;
                    result.sErrMsg = string.Empty;
                }
                else
                {
                    sSql.Append("'" + Quo(response.sErrMsg) + "',");        // error message
                    sSql.Append("null,");                                   // Ship Order ID from ship partner
                    sSql.Append("null,");
                    sSql.Append("null,");
                    sSql.Append("null,");                                   // normal message
                    sSql.Append("'" + Quo(response.sErrMsg) + "',");
                    sSql.Append("null,");                                   //     DropShipperStatusID
                    sSql.Append("null, ");                                  //     DropShipperStatusName
                    sSql.Append("null)");                                   // track URL

                    result.sPartnerOrderID = string.Empty;
                    result.sErrMsg = response.sErrMsg;

                }
                db.DBExecute(sSql.ToString());



                // insert order item info
                string sOrderBodyGuidList = string.Empty;   // accumulate orderbody guid of all products 

                foreach (EOrderProduct product in eOrder.ProductList)
                {
                    // accumulate guid of orderbody
                    if (sOrderBodyGuidList != string.Empty) sOrderBodyGuidList += ",";
                    sOrderBodyGuidList += "'" + product.sOrderBodyGuid + "'";

                    sSql.Clear();
                    sSql.Append("insert into wn_ShipOrderItem(ShipOrder_ID, OrderHead_GuidNo, OrderBody_Guid)");
                    sSql.Append("values(");
                    sSql.Append(eOrder.iShipOrderID.ToString() + ",");
                    sSql.Append("'" + eOrder.sOrderHeadGuidNo + "',");
                    sSql.Append("'" + product.sOrderBodyGuid + "')");
                    db.DBExecute(sSql.ToString());
                }

                // update Orderbody when success
                if (iSuccess == 1)
                {
                    sSql.Clear();
                    sSql.Append("update wn_OrderBody set ShipOrder_ID=" + eOrder.iShipOrderID.ToString());
                    sSql.Append(" where guid in (" + sOrderBodyGuidList + ")");
                    int iRow = db.DBExecute(sSql.ToString());

                    // update order status of order head
                    //iRow = UpdateOrderStatus(db, eOrder.sOrderHeadGuidNo, (int)(ConfigParamter.OrderStatus.Shipped));
                }

                db.DBCommitTrans();
                db.DBDisconnect();

                return result;
            }
            catch (Exception ex)
            {
                db.DBRollbackTrans();
                db.DBDisconnect();
                throw new Exception(ex.Message);
            }
        }
        #endregion

        public List<ShipOrderResult> ShipPurchaseOrder(string sOrderNo, bool bIsTest)
        {
            ShipOrderMgr mgr = new ShipOrderMgr();
            DataSet ds = mgr.GetShipOrderInfo(sOrderNo);

            List<ShipOrderResult> resultList = new List<ShipOrderResult>(); 

            string sErrMsg = "";

            // check dataset and table count
            if (ds == null || ds.Tables.Count == 0)
            {
                sErrMsg = "Failed to get the order data set information of " + sOrderNo;
                throw new Exception(sErrMsg);
            }

            //_s = JsonConvert.SerializeObject(ds.Tables[0]);

            // check data table and row count
            DataTable dt = ds.Tables[0];
            if (dt == null || dt.Rows.Count == 0)
            {
                sErrMsg = "Failed to get the order data table information of " + sOrderNo;
                throw new Exception(sErrMsg);
            }

            // check order status
            int iOrderStatus = dt.Rows[0]["OrderStatus"].ToString().ToInt();
            if (iOrderStatus != (int)(ConfigParamter.OrderStatus.WaitingToShip))
            {
                sErrMsg = "Cannot Shipping! Order is not in status of Waiting To Ship!";
                throw new Exception(sErrMsg);
            }

            FosdickOrder warehouseOrder = new FosdickOrder();
            warehouseOrder.ItemList = new List<FosdickOrderItem>();


            DropShipperOrder dropShipperOrder = new DropShipperOrder();
            dropShipperOrder.ItemList = new List<DropShipperOrderItem>();
            dropShipperOrder.dtOrderDate = DateTime.Now;                    // set order date

            EOrderReq eOrder = new EOrderReq();
            eOrder.ProductList = new List<EOrderProduct>();

            int iPrevShipPartnerID = -1;
            int iPrevShipFromID = -1;

            // for each item in the order
            foreach (DataRow dr in dt.Rows)
            {
                int iShipPartnerID = dr["ShipPartner_ID"].ToString().ToInt();
                int iShipFromID = dr["ShipFrom_ID"].ToString().ToInt();

                //iShipPartnerID = (int)(ConfigParamter.ShipPartner.EOrder); // jctest

                if (iShipPartnerID == (int)(ConfigParamter.ShipPartner.Fosdick))
                {

                    // Tweebaa warehouse from fosdick
                    if (iShipPartnerID != iPrevShipPartnerID)
                    {
                        if (iPrevShipPartnerID != -1)
                        {
                            ShipOrderResult result = SendWarehouseShipOrder(warehouseOrder);
                            resultList.Add(result);
                            warehouseOrder.Clear();
                        }
                        warehouseOrder.sOrderHeadGuidNo = sOrderNo;
                        warehouseOrder.iShipOrderID = DbHelperSQL.GetSeq("ShipOrderID");
                        
  
                        warehouseOrder.sTest = (bIsTest? "y": "n");
 

                        warehouseOrder.sExternalID = warehouseOrder.iShipOrderID.ToString(); // should be the shipping order # but not the customer order # ( Twee...)
                        warehouseOrder.sAdCode = (bIsTest ? "TEST" : "DTC");
                        if (dr["ShipMethod_Code"] != DBNull.Value)
                        {
                            warehouseOrder.sShipMethodCode = dr["ShipMethod_Code"].ToString();
                        }
                        warehouseOrder.dTax = dr["TaxSum"].ToString().ToDecimal();  // the total amount tax of the order
                        warehouseOrder.dTotal += warehouseOrder.dTax;
                        warehouseOrder.sShipFirstName = dr["ShipTo_FirstName"].ToString();

                        // set first name
                        if (dr["ShipTo_LastName"] == DBNull.Value) warehouseOrder.sShipLastName = warehouseOrder.sShipFirstName;
                        else warehouseOrder.sShipLastName = dr["ShipTo_LastName"].ToString().Trim();
                        if (warehouseOrder.sShipLastName == string.Empty)
                        {
                            warehouseOrder.sShipLastName = warehouseOrder.sShipFirstName; 
                        }
                         warehouseOrder.sShipAddress1 = dr["ShipTo_Address1"].ToString();
                        warehouseOrder.sShipAddress2 = dr["ShipTo_Address2"].ToString();
                        warehouseOrder.sShipCity = dr["ShipTo_City"].ToString();
                        warehouseOrder.sShipZip = dr["ShipTo_Zip"].ToString();
                        warehouseOrder.sShipState = dr["ShipTo_ProvinceShortName"].ToString().TrimEnd();
                        warehouseOrder.sShipCountry = GetCountryName(dr["ShipTo_CountryID"].ToString().ToInt());
                        warehouseOrder.sShipPhone = dr["ShipTo_Phone"].ToString();
                        warehouseOrder.sEmail = "";
                        warehouseOrder.sPaymentType = "5"; // prepaid :do not need payment inforamtion and billing information
                        warehouseOrder.sUseAsBilling = "y";

                        warehouseOrder.ItemList = new List<FosdickOrderItem>();

                    }
                    // add item
                    FosdickOrderItem warehouseItem = new FosdickOrderItem();
                    warehouseOrder.ItemList.Add(warehouseItem);
                    warehouseItem.sOrderBodyGuid = dr["OrderBody_Guid"].ToString();
                    warehouseItem.sInv = dr["Item_TweebaaSku"].ToString();
                    warehouseItem.dQty = dr["Item_Quantity"].ToString().ToDecimal();
                    warehouseItem.dPricePer = dr["Item_UnitPrice"].ToString().ToDecimal();
                    warehouseOrder.dSubTotal += warehouseItem.dQty * warehouseItem.dPricePer; //+ dr["Item_ShipFee"].ToString().ToDecimal();
                    warehouseOrder.dDiscounts += 0;
                    warehouseOrder.dPostage += 0;
                    warehouseOrder.dTotal += warehouseItem.dQty * warehouseItem.dPricePer; // +dr["Item_ShipFee"].ToString().ToDecimal();

                }
                else if (iShipPartnerID == (int)(ConfigParamter.ShipPartner.EOrder))
                {
                    // tweebaa eOrder
                    if (iPrevShipFromID != dr["ShipFrom_ID"].ToString().ToInt())
                    {
                        if (iPrevShipFromID != -1)
                        {
                            ShipOrderResult result = SendEOrderOrder(eOrder);
                            resultList.Add(result);
                            eOrder.Clear();
                        }
                        // set eOrder info
                        eOrder.sOrderHeadGuidNo = sOrderNo;
                        eOrder.iShipOrderID =  DbHelperSQL.GetSeq("ShipOrderID");
                        eOrder.sFromCompany = dr["ShipFrom_CompanyName"].ToString();
                        eOrder.sFromAddress = dr["ShipFrom_Address1"].ToString();
                        eOrder.sFromCity = dr["ShipFrom_City"].ToString();
                        eOrder.sFromState = dr["ShipFrom_ProvinceShortName"].ToString().TrimEnd();
                        eOrder.sFromZip = dr["ShipFrom_Zip"].ToString();
                        eOrder.sFromCountry = GetCountryName(dr["ShipFrom_CountryID"].ToString().ToInt());
                        eOrder.sFromContact = dr["ShipFrom_ContactName"].ToString();
                        eOrder.sFromPhone = dr["ShipFrom_Phone"].ToString();
                        eOrder.sFromEmail = dr["ShipFrom_Email"].ToString();

                        eOrder.sToCompany = dr["ShipTo_FirstName"].ToString() + " " + dr["ShipTo_LastName"].ToString();
                        eOrder.sToContact = dr["ShipTo_FirstName"].ToString() + " " + dr["ShipTo_LastName"].ToString();
                        eOrder.sToAddress = dr["ShipTo_Address1"].ToString();
                        eOrder.sToCity = dr["ShipTo_City"].ToString();
                        eOrder.sToState = dr["ShipTo_ProvinceShortName"].ToString().TrimEnd();
                        eOrder.sToZip = dr["ShipTo_Zip"].ToString();
                        eOrder.sToCountry = GetCountryName(dr["ShipTo_CountryID"].ToString().ToInt());
                        eOrder.sToPhone = dr["ShipTo_Phone"].ToString();
                        // shipping type ( method)
                        if (dr["ShipMethod_Name"] != null)
                        {
                            eOrder.sShipType = dr["ShipMethod_Name"].ToString();
                        }
                        eOrder.sPaymentOption = "PO";  // fixed now
                        eOrder.sPurchaseOrderNo = sOrderNo;
                        eOrder.sSpecialInstruction = string.Empty;
                        eOrder.sRefNo = sOrderNo;
                        eOrder.sCodAmount = "0.0";
                    }
                    // add item into
                    EOrderProduct item = new EOrderProduct();
                    eOrder.ProductList.Add(item);
                    item.sOrderBodyGuid = dr["OrderBody_Guid"].ToString();
                    item.sName = dr["Item_Name"].ToString();
                    item.sSku = dr["Item_TweebaaSku"].ToString();
                    item.sQty = dr["Item_Quantity"].ToString();
                }
                else if (iShipPartnerID == (int)(ConfigParamter.ShipPartner.DropShipper))
                {
                    // tweebaa drop-shipper
                    if (iPrevShipFromID != dr["ShipFrom_ID"].ToString().ToInt())
                    {
                        if (iPrevShipFromID != -1)
                        {
                            ShipOrderResult result = SendDropShipperOrder(dropShipperOrder);
                            resultList.Add(result);
                            dropShipperOrder.Clear();
                        }
                        // set dropshipper Order info
                        dropShipperOrder.sOrderHeadGuidNo = sOrderNo;
                        dropShipperOrder.iShipOrderID = DbHelperSQL.GetSeq("ShipOrderID");
                        dropShipperOrder.sSupplierID = dr["Supplier_ID"].ToString();
                        dropShipperOrder.sFromCompany = dr["ShipFrom_CompanyName"].ToString();
                        dropShipperOrder.sFromAddress = dr["ShipFrom_Address1"].ToString();
                        dropShipperOrder.sFromCity = dr["ShipFrom_City"].ToString();
                        dropShipperOrder.sFromState = dr["ShipFrom_ProvinceShortName"].ToString().TrimEnd();
                        dropShipperOrder.sFromZip = dr["ShipFrom_Zip"].ToString();
                        dropShipperOrder.sFromCountry = GetCountryName(dr["ShipFrom_CountryID"].ToString().ToInt());
                        dropShipperOrder.sFromContact = dr["ShipFrom_ContactName"].ToString();
                        dropShipperOrder.sFromPhone = dr["ShipFrom_Phone"].ToString();
                        dropShipperOrder.sFromEmail = dr["ShipFrom_Email"].ToString();

                        dropShipperOrder.sToCompany = dr["ShipTo_FirstName"].ToString() + " " + dr["ShipTo_LastName"].ToString();
                        dropShipperOrder.sToContact = dr["ShipTo_FirstName"].ToString() + " " + dr["ShipTo_LastName"].ToString();
                        dropShipperOrder.sToAddress = dr["ShipTo_Address1"].ToString();
                        dropShipperOrder.sToCity = dr["ShipTo_City"].ToString();
                        dropShipperOrder.sToState = dr["ShipTo_ProvinceShortName"].ToString().TrimEnd();
                        dropShipperOrder.sToZip = dr["ShipTo_Zip"].ToString();
                        dropShipperOrder.sToCountry = GetCountryName(dr["ShipTo_CountryID"].ToString().ToInt());
                        dropShipperOrder.sToPhone = dr["ShipTo_Phone"].ToString();
                        // shipping type ( method)
                        if (dr["ShipMethod_Name"] != null)
                        {
                            dropShipperOrder.sShipMethodName = dr["ShipMethod_Name"].ToString();
                        }
                    }
                    // add item into
                    DropShipperOrderItem item = new DropShipperOrderItem();
                    dropShipperOrder.ItemList.Add(item);
                    item.sOrderBodyGuid = dr["OrderBody_Guid"].ToString();
                    item.sProductName = dr["ProductName"].ToNullString();
                    item.sDesc = dr["Item_Name"].ToString();
                    item.sTweebaaSku = dr["Item_TweebaaSku"].ToString();
                    item.sSupplierSku = dr["Item_SupplierSku"].ToString();
                    item.dQty = dr["Item_Quantity"].ToString().ToDecimal();

                    item.dUnitPrice = 0;
                    if (  dr["Item_WholeSalePrice"] != DBNull.Value)
                        item.dUnitPrice = dr["Item_WholeSalePrice"].ToString().ToDecimal();
                    
                    item.dSupplierShipFee = 0;
                    if ( dr["Item_SupplierShipFee"] != DBNull.Value) 
                        item.dSupplierShipFee = dr["Item_SupplierShipFee"].ToString().ToDecimal();

                    item.bIsCustomerFreeShip = false;
                    if (dr["Item_IsCustomerFreeShip"] != DBNull.Value)
                    {
                        if (dr["Item_IsCustomerFreeShip"].ToString().ToInt() == 1) item.bIsCustomerFreeShip = true;
                    }
                }
                iPrevShipPartnerID = dr["ShipPartner_ID"].ToString().ToInt();
                iPrevShipFromID = dr["ShipFrom_ID"].ToString().ToInt();
            } // for each order item

            if (dropShipperOrder.ItemList.Count > 0)
            {
                ShipOrderResult result = SendDropShipperOrder(dropShipperOrder);
                resultList.Add(result);
            }
            else if (warehouseOrder.ItemList.Count > 0)
            {
                ShipOrderResult result = SendWarehouseShipOrder(warehouseOrder);
                resultList.Add(result);
            }
            else if (eOrder.ProductList.Count > 0)
            {
                ShipOrderResult result = SendEOrderOrder(eOrder);
                resultList.Add(result);
            }

            return resultList;
        } // function

        public List<ShipOrderCancelResult> CancelShipPurchaseOrder(string sOrderNo)
        {
            ShipOrderMgr mgr = new ShipOrderMgr();
            DataSet ds = mgr.GetShipOrderCancelInfo(sOrderNo);

            List<ShipOrderCancelResult> resultList = new List<ShipOrderCancelResult>();

            string sErrMsg = "";

            // check dataset and table count
            if (ds == null || ds.Tables.Count == 0)
            {
                sErrMsg = "Failed to get the cancel order information of " + sOrderNo;
                throw new Exception(sErrMsg);
            }

            //_s = JsonConvert.SerializeObject(ds.Tables[0]);

            // check data table and row count
            DataTable dt = ds.Tables[0];
            if (dt == null || dt.Rows.Count == 0)
            {
                sErrMsg = "Failed to get the cancel order information of " + sOrderNo;
                throw new Exception(sErrMsg);
            }

            // for each item in the order
            foreach (DataRow dr in dt.Rows)
            {
                int iShipOrder_ID = dr["ShipOrder_ID"].ToString().ToInt();
                int iShipPartnerID = dr["ShipPartner_ID"].ToString().ToInt();
                string sPartnerOrderNo = dr["ShipOrder_PartnerOrderID"].ToString();

                if (iShipPartnerID == (int)(ConfigParamter.ShipPartner.Fosdick))
                {
                    ShipOrderCancelResult result = CancelWarehouseShipOrder(iShipOrder_ID, sOrderNo, sPartnerOrderNo);
                    resultList.Add(result);
                 }
                else if (iShipPartnerID == (int)(ConfigParamter.ShipPartner.EOrder))
                {
                    ShipOrderCancelResult result = CancelDropshipperShipOrder(iShipOrder_ID, sOrderNo, sPartnerOrderNo);  
                    resultList.Add(result);
                }
            } // for each shippong order of the Twee order

            return resultList;
        } // function
 
        private ShipOrderCancelResult CancelWarehouseShipOrder(int iShipOrderID, string sOrderNo, string sPartnerOrderNo)
        {
         
            int iReqSuccess = 0;
            int iCancelSuccess = 0;

            ShipOrderCancelResult result = new ShipOrderCancelResult();
            
            FosdickOrderCancelResponse response;
       
            try
            {
                // send hip order to warhouse 
                FosdickAPI api = new FosdickAPI();
                response = api.OrderCancel(sPartnerOrderNo);
                iReqSuccess = response.bReqSuccess?1:0;
                iCancelSuccess = response.bCancelSuccess?1:0;
                
                result.bReqSuccess = response.bReqSuccess;
                result.bCancelSuccess = response.bCancelSuccess;
                result.sReqErrMsg = response.sReqErrMsg;
                result.sCancelMsg = response.sCancelMsg;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            // create db
            DB db = new DB();

            try
            {
                // connect and  start transaction
                db.DBConnect();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            try
            {
                db.DBBeginTrans();

                // get new Ship Order ID
                int iShipOrderCancelID = db.DBGetSeq("ShipOrderCancelID");
                result.iShipOrderCancelID = iShipOrderCancelID;

                // insert order cancel info
                StringBuilder sSql = new StringBuilder();
                sSql.Append("insert into wn_ShipOrderCancel(ShipOrderCancel_ID, OrderHead_GuidNo, ShipPartner_ID, ShipOrderCancel_PartnerOrderID,  ShipOrderCancel_Date, ShipOrderCancel_IsReqSuccess, ShipOrderCancel_IsCancelSuccess, ShipOrderCancel_ReqErrMsg, ShipOrderCancel_CancelMsg, ShipOrderCancel_ReqXML, ShipOrderCancel_ResponseXML)");
                sSql.Append(" values(");
                sSql.Append(iShipOrderCancelID.ToString() + ",");                                   // ship order id
                sSql.Append("'" + sOrderNo + "',");                                                 // Order Head GuidNo ( not is the Guid of the order head)
                sSql.Append(((int)(ConfigParamter.ShipPartner.Fosdick)).ToString() + ",");          // ship partnar id
                sSql.Append("'" + sPartnerOrderNo + "',");                                          // order number from shipping partner
                sSql.Append("getdate(),");                                                          // Ship Order Date
                sSql.Append(iReqSuccess.ToString() + ",");                                          // ship order cancel request success or not
                sSql.Append(iCancelSuccess.ToString() + ",");                                       // ship order cancel success or not

                // request err message 
                if (response.sReqErrMsg != null && response.sReqErrMsg != string.Empty)     // request err message
                    sSql.Append("'" + Quo(response.sReqErrMsg) + "',");  
                else
                    sSql.Append("null,");
                
                // cancel message
                if (response.sCancelMsg != null && response.sCancelMsg != string.Empty)             // Cancel message
                    sSql.Append("'" + Quo(response.sCancelMsg) + "',");
                else
                    sSql.Append("null,");
                sSql.Append("'" + Quo(response.sReqXML) + "',");                                    // Ship Order request XML
                sSql.Append("'" + Quo(response.sResponseXML) + "')");                               // Ship Order response XML
                
                db.DBExecute(sSql.ToString());

                iCancelSuccess = 1;
                // update ship order status
                if (iCancelSuccess == 1)
                {
                    sSql.Clear();
                    sSql.Append("update wn_ShipOrder set ShipOrder_Status = " + ((int)ConfigParamter.DropshipperOrderStatus.Cancelled).ToString() ) ;
                    sSql.Append(" where ShipOrder_ID = " + iShipOrderID.ToString());
                    int iRow = db.DBExecute(sSql.ToString());
                
                    // update order status of order head
                    iRow = UpdateOrderStatus(db, sOrderNo, (int)(ConfigParamter.OrderStatus.Cancelled));
                }
       
                db.DBCommitTrans();
                db.DBDisconnect();

                return result;
            }
            catch (Exception ex)
            {
                db.DBRollbackTrans();
                db.DBDisconnect();
                throw new Exception(ex.Message);
            }
        }


        private int UpdateOrderStatus(DB db, string sOrderNo, int iStatus)
        {
            
            StringBuilder sSql = new StringBuilder();
            // update order status of order head
            try
            {
                sSql.Append("update wn_OrderHead set wnstat = " + iStatus.ToString());
                sSql.Append(" where guidno ='" + sOrderNo + "'");
                int iRow = db.DBExecute(sSql.ToString());
                return iRow;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private ShipOrderCancelResult CancelDropshipperShipOrder(int iShipOrderID, string sOrderNo, string sPartnerOrderNo)
        {
            ShipOrderCancelResult result = new ShipOrderCancelResult();

            // currently eOrder cannot cancel an order
            result.bReqSuccess = false;
            result.bCancelSuccess = false;
            result.sReqErrMsg = "EOrder cannot cancel an shipping order";
            result.sCancelMsg = "EOrder cannot cancel an shipping order";
            return result;
        }

        // this function is designed to update order shipment detail from warehouse
        public bool WarehouseShipmentDetailUpdate(int iShipPartnerID, bool bIsTest) 
        {
            FosdickShipmentDetailReq  req = new FosdickShipmentDetailReq();
            bool bSuccess = true;
            string sErrMsg = string.Empty;
            int iAffectedRow = 0;

            // get last updated date
            StringBuilder sSql = new StringBuilder();
            sSql.Append("select max(ShipmentDetailRequest_Date) as MaxRequestDate from wn_ShipmentDetailRequest where ShipmentDetailRequest_Success=1") ;
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            req.dtUpdatedSince = new DateTime(2015, 11, 18);
              
            if ( ds != null && ds.Tables.Count > 0 ) {
                DataTable dt = ds.Tables[0];
                if ( dt != null && dt.Rows.Count > 0 )  {
                    if ( dt.Rows[0]["MaxRequestDate"] != DBNull.Value) 
                        req.dtUpdatedSince = (DateTime)dt.Rows[0]["MaxRequestDate"];
                }
            }
      

            // request shipment details list from Fosdisck
            // now we only have forsdick an its ship partner_ID = ConfigParamter.ShipPartner.Fosdick = 1

            FosdickAPI api = new FosdickAPI();
            List<FosdickShipmentDetail>  detailList = new List<FosdickShipmentDetail>();
            try {
                detailList = api.GetShipmentDetailList(req, bIsTest); 
            }
            catch (Exception ex) {
                sErrMsg = ex.Message;
                bSuccess = false;
            }

            DB db = new DB();

            db.DBConnect();
            db.DBBeginTrans();
           
            int iShipmentDetailReqID = db.DBGetSeq("ShipmentDetailRequestID");

            // insert request
            sSql.Clear();
            sSql.Append("insert into wn_ShipmentDetailRequest(ShipmentDetailRequest_ID, ShipPartner_ID, ShipmentDetailRequest_Date, ShipmentDetailRequest_Success, ShipmentDetailRequest_DataCount, ShipmentDetailRequest_ErrMsg)");
            sSql.Append("VALUES(");
            sSql.Append(iShipmentDetailReqID.ToString() + ",");
            sSql.Append(iShipPartnerID.ToString() + ",");
            sSql.Append("getdate(),"); 
            sSql.Append(bSuccess?"1,":"0,");
            sSql.Append(detailList.Count.ToString() + ",");
            sSql.Append("'" + CommUtil.Quo(sErrMsg) + "')");
            iAffectedRow = db.DBExecute(sSql.ToString());


            foreach (FosdickShipmentDetail detail in detailList) {
                int iShipmentDetailID =  db.DBGetSeq("ShipmentDetailID");
                sSql.Clear();

                // insert shipment detail
                sSql.Append("insert into wn_ShipmentDetail");
                sSql.Append("(ShipmentDetail_ID");
                sSql.Append(",ShipPartner_ID");
                sSql.Append(",ShipmentDetailRequest_ID");
                sSql.Append(",ShipmentDetail_PartnerOrderID");
                sSql.Append(",ShipmentDetail_PartnerLineItemNo");
                sSql.Append(",ShipmentDetail_PartnerSku");
                sSql.Append(",ShipmentDetail_Quantity");
                sSql.Append(",ShipOrder_ID");
                sSql.Append(",Order_LineItemNo");
                sSql.Append(",TweebaaSku");
                sSql.Append(",ShipmentDetail_ShippedDate");
                sSql.Append(",ShipmentDetail_CreateDate)");
                sSql.Append("VALUES(");
                sSql.Append(iShipmentDetailID.ToString() +",");
                sSql.Append(iShipPartnerID.ToString() + ",");
                sSql.Append(iShipmentDetailReqID.ToString() + ",");
                sSql.Append("'" + CommUtil.Quo(detail.sFosdickOrderNo) + "',");
                sSql.Append(detail.iFosdickLineNo.ToString() + ",");
                sSql.Append("'" + CommUtil.Quo(detail.sSku) + "',");
                sSql.Append(detail.iQty.ToString() + ",");
                sSql.Append("'" + CommUtil.Quo(detail.sExternalOrderNo) + "',");
                sSql.Append(detail.iExternalLineNo.ToString() + ",");
                sSql.Append("'" + CommUtil.Quo(detail.sExternalSku) + "',");
                sSql.Append("'" +  CommUtil.ToDBDateFormat(detail.dtShipDate) + "',");
                sSql.Append("getdate())");
                iAffectedRow = db.DBExecute(sSql.ToString()); 

                // insert tracking
                
                foreach(FosdickShipmentTracking tracking in detail.trackingList) {
                    sSql.Clear();
                    sSql.Append("insert into wn_ShipmentDetailTracking(ShipmentDetail_ID,ShipmentDetailTracking_No,ShipmentDetailTracking_CarrierCode,ShipmentDetailTracking_CarrierName,ShipmentDetailTracking_CreateDate) ");
                    sSql.Append("VALUES(");
                    sSql.Append(iShipmentDetailID.ToString() + ",");
                    sSql.Append("'" + CommUtil.Quo(tracking.sTrackingNo) + "',");
                    sSql.Append("'" + CommUtil.Quo(tracking.sCarrierCode) + "',");
                    sSql.Append("'" + CommUtil.Quo(tracking.sCarrierName) + "',");
                    sSql.Append("getdate())");
                    iAffectedRow = db.DBExecute(sSql.ToString()); 
                }

                int iShipOrderID =  detail.sExternalOrderNo.ToInt();

                // update orderbody 
                sSql.Clear();
                sSql.Append("update wn_OrderBody set ShipmentDetail_ID=" + iShipmentDetailID.ToString() );
                sSql.Append(" where ShipOrder_ID =" + iShipOrderID.ToString() );
                sSql.Append("   and ruleid = ( select id from wn_proRules where prosku ='" + CommUtil.Quo(detail.sExternalSku) + "')");
                iAffectedRow = db.DBExecute(sSql.ToString()); 
            
                // update order status
                ShipOrderMgr soMgr = new ShipOrderMgr();

                soMgr.UpdateShipOrderStatus(db, iShipOrderID, (int)ConfigParamter.OrderStatus.Shipped, detail.dtShipDate);
            }

            db.DBCommitTrans();
            db.DBDisconnect();

            // read email template
            string sCustomerShipmentEmailTemplate = ReadEmailTemplate("EmailCustomerShipment.html");
            string sCustomerShipmentEmailErrMsg = string.Empty;
            // send customer shipment email
            foreach (FosdickShipmentDetail detail in detailList)
            {
                int iShipOrderID = detail.sExternalOrderNo.ToInt();
                bool bOK = SendCustomerShipmentEmail(iShipOrderID, sCustomerShipmentEmailTemplate, out sCustomerShipmentEmailErrMsg);
            }
 
            return true;
        }

        public bool SendCustomerShipmentEmail(int iShipOrderID, string sEmailTemplate, out string sErrMsg)
        {
            CultureInfo ciUSA = new CultureInfo("en-US");    // USA culture
            
            sErrMsg = string.Empty;

            ShipOrderMgr mgr = new ShipOrderMgr();
                
            // retrieve shpment customer email info
            DataSet ds = mgr.GetShipOrderShipmentDetail(iShipOrderID);
            if (ds == null || ds.Tables.Count == 0) {
                sErrMsg = "cannot get shipment details!";
                return false;
            }

            DataTable dt = ds.Tables[0];
            if (dt == null || dt.Rows.Count == 0) {
                sErrMsg = "cannot get shipment details!";
                return true;
            }

            DataRow drFirstRow = dt.Rows[0]; // first row

            // get ship to email address
            string sCustomerEmail = string.Empty;
            if ( drFirstRow["ShipToEmail"] != DBNull.Value) sCustomerEmail = drFirstRow["ShipToEmail"].ToString().Trim();
             if (sCustomerEmail == string.Empty) {
                sErrMsg = "No email address!";
                return false;
            }
 
           // set email templete
            string sEmailBody = sEmailTemplate;

            // customer name
            string sCustomerFirstName = drFirstRow["ShipToFirstName"].ToString().Trim().Split(' ')[0];
            string sCustomerName = drFirstRow["ShipToFirstName"].ToString();
            if (drFirstRow["ShipToLastName"] != DBNull.Value) sCustomerName = sCustomerName + " " + drFirstRow["ShipToLastName"].ToString();
            sEmailBody = sEmailBody.Replace("#CustomerFirstName#", sCustomerFirstName);  
            
            // tweebaa order #
            sEmailBody = sEmailBody.Replace("#TweebaaOrder#", drFirstRow["TweebaaOrderID"].ToString());

            // ship to
            StringBuilder sShipTo = new StringBuilder();
            sShipTo.Append("<strong>Ship To:</strong><br/>");
            sShipTo.Append(sCustomerName + "<br/>");
            sShipTo.Append(drFirstRow["ShipToAddress"].ToString() + "<br/>");
            sShipTo.Append(drFirstRow["ShipToCity"].ToString() + ", " + drFirstRow["ShipToProvinceName"].ToString() + " " + drFirstRow["ShipToZip"].ToString() + "<br/>");
            sShipTo.Append(drFirstRow["ShipToCountryName"].ToString() + "<br/>");
            sShipTo.Append(drFirstRow["ShipToPhone"].ToString());
            sEmailBody = sEmailBody.Replace("#ShipTo#", sShipTo.ToString());

  
            // shipment detail
            StringBuilder sShipmentDetail = new StringBuilder();
            string sShipMethod = string.Empty;
            string sTrackingNo = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                // product name & price
                sShipmentDetail.Append("<tr>");
                sShipmentDetail.Append("<td style=\"border-top: #eee 1px solid; padding:30px 10px ;\">" +  dr["ProductName"].ToString() + "</td>");
                sShipmentDetail.Append("<td style=\"border-top: #eee 1px solid; text-align:right; padding:10px 30px;\">" + dr["ShippedQuantity"].ToString().ToDecimal().ToString("#0") + "</td>");
                sShipmentDetail.Append("</tr>");
                sShipMethod = dr["CarrierName"].ToString();
                sTrackingNo = dr["TrackingNo"].ToString();
            }
            sEmailBody = sEmailBody.Replace("#ShipmentDetail#", sShipmentDetail.ToString());
            sEmailBody = sEmailBody.Replace("#ShipMethod#", sShipMethod);

            string sTrackingLink = CommUtil.GetTrackingLink(sShipMethod, sTrackingNo);
            if (sTrackingLink != string.Empty)
            {
                sEmailBody = sEmailBody.Replace("#TrackingNo#", "<a href=\"" + sTrackingLink + "\">" + sTrackingNo + "</a>");
            }
            else
            {
                sEmailBody = sEmailBody.Replace("#TrackingNo#", sTrackingNo);
            }
            string sTitle = "Your Tweebaa order had been shipped";

            //bool bSend = Twee.Comm.Mailhelper.SendMail(sTitle, sEmailTemplate, dropShipperOrder.sFromEmail, sPDFFileName);
            bool bSend = Twee.Comm.Mailhelper.SendMail(sTitle, sEmailBody, sCustomerEmail);
                 bSend = Twee.Comm.Mailhelper.SendMail(sTitle, sEmailBody, "jack@leivaire.com");
                 bSend = Twee.Comm.Mailhelper.SendMail(sTitle, sEmailBody, "service@tweebaa.com");
            
            // update shipping order customer shipment email sent date
            StringBuilder sSql = new StringBuilder();
            sSql.Append("update wn_ShipOrder set ShipOrder_ShipmentCustomerEmailSentDate = getdate() ");
            sSql.Append(" where ShipOrder_ID=" + iShipOrderID.ToString());
            int iAffectedRow = DbHelperSQL.ExecuteSql(sSql.ToString());
            return true;
        }



        // this function is designed to update order return info from warehouse
        public bool WarehouseReturnInfoUpdate(int iShipPartnerID, bool bIsTest)
        {
            FosdickOrderReturnReq req = new FosdickOrderReturnReq();
            bool bSuccess = true;
            string sErrMsg = string.Empty;
            int iAffectedRow = 0;

            // get last updated date
            StringBuilder sSql = new StringBuilder();
            sSql.Append("select max(ReturnInfoRequest_Date) as MaxRequestDate from wn_ReturnInfoRequest where ReturnInfoRequest_Success=1");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            req.dtUpdatedSince = new DateTime(2015, 11, 18);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["MaxRequestDate"] != DBNull.Value)
                        req.dtUpdatedSince = (DateTime)dt.Rows[0]["MaxRequestDate"];
                }
            }

            // request return infos list from Fosdisck
            // now we only have forsdick an its ship partner_ID = ConfigParamter.ShipPartner.Fosdick = 1

            FosdickAPI api = new FosdickAPI();
            List<FosdickOrderReturn> detailList = new List<FosdickOrderReturn>();
            try
            {
                detailList = api.GetOrderReturnList(req, bIsTest);
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
                bSuccess = false;
            }

            DB db = new DB();

            db.DBConnect();
            db.DBBeginTrans();

            int iReturnInfoReqID = db.DBGetSeq("ReturnInfoRequestID");

            // insert request
            sSql.Clear();

            sSql.Append("insert into wn_ReturnInfoRequest(ReturnInfoRequest_ID, ShipPartner_ID, ReturnInfoRequest_Date, ReturnInfoRequest_Success, ReturnInfoRequest_DataCount, ReturnInfoRequest_ErrMsg)");
            sSql.Append("VALUES(");
            sSql.Append(iReturnInfoReqID.ToString() + ",");
            sSql.Append(iShipPartnerID.ToString() + ",");
            sSql.Append("getdate(),");
            sSql.Append(bSuccess ? "1," : "0,");
            sSql.Append(detailList.Count.ToString() + ",");
            sSql.Append("'" + CommUtil.Quo(sErrMsg) + "')");
            iAffectedRow = db.DBExecute(sSql.ToString());


            foreach (FosdickOrderReturn detail in detailList)
            {
                int iReturnInfoID = db.DBGetSeq("ReturnInfoID");
                sSql.Clear();

                // insert return info
                sSql.Append("insert into wn_ReturnInfo");
                sSql.Append("(ReturnInfo_ID");
                sSql.Append(",ShipPartner_ID");
                sSql.Append(",ReturnInfoRequest_ID");
                sSql.Append(",ReturnInfo_PartnerOrderID");
                sSql.Append(",ReturnInfo_PartnerLineItemNo");
                sSql.Append(",ShipOrder_ID");
                sSql.Append(",TweebaaSku");
                sSql.Append(",Order_LineItemNo");
                sSql.Append(",ReturnInfo_ReturnDate");
                sSql.Append(",ReturnInfo_ReturnQuantity");
                sSql.Append(",ReturnInfo_Quality");
                sSql.Append(",ReturnInfo_ReasonCode");
                sSql.Append(",ReturnInfo_ReasonDesc");
                sSql.Append(",ReturnInfo_ActionRequested");
                sSql.Append(",ReturnInfo_LastUpdatedDate");
                sSql.Append(",ReturnInfo_CreateDate)");
                sSql.Append(" VALUES(");
                sSql.Append(iReturnInfoID.ToString() + ",");
                sSql.Append(iShipPartnerID.ToString() + ",");
                sSql.Append(iReturnInfoReqID.ToString() + ",");
                sSql.Append("'" + CommUtil.Quo(detail.sFosdickOrderNo) + "',");
                sSql.Append(detail.iLineItemNo.ToString() + ",");
                sSql.Append(detail.sExternalOrderNo + ",");
                sSql.Append("'" + CommUtil.Quo(detail.sSku) + "',");
                sSql.Append("'" + detail.iExternalLineItemNo.ToNullString() + "',"); 
                sSql.Append("'" + ((DateTime)(detail.dtReturnDate)).ToString("MM/dd/yyyy hh:mm:ss").Replace("-", "/") + "',");
                sSql.Append(detail.iReturnedQuantity.ToString() + ",");
                sSql.Append(detail.iQuality.ToString() + ",");
                sSql.Append("'" + CommUtil.Quo(detail.sReturnReasonCode) + "',");
                sSql.Append("'" + CommUtil.Quo(detail.sReturnReasonDesc) + "',");
                sSql.Append("'" + CommUtil.Quo(detail.sActionRequested) + "',");
                sSql.Append("'" + detail.dtLastUpdated.ToString("MM/dd/yyyy hh:mm:ss").Replace("-", "/") + "',");
                sSql.Append("getdate())");
                iAffectedRow = db.DBExecute(sSql.ToString());

                // update orderbody 
                sSql.Clear();
                sSql.Append("update wn_OrderBody set ReturnInfo_ID=" + iReturnInfoID.ToString());
                sSql.Append(" where ShipOrder_ID =" + detail.sExternalOrderNo);
                sSql.Append("   and ruleid = ( select id from wn_proRules where prosku ='" + CommUtil.Quo(detail.sSku) + "')");
                iAffectedRow = db.DBExecute(sSql.ToString());
            }

            db.DBCommitTrans();
            db.DBDisconnect();

            return true;
        }

        // this function is designed to update inventory info from warehouse
        public bool WarehouseInventoryInfoUpdate(int iShipPartnerID, bool bIsTest)
        {
            FosdickInventoryReq req = new FosdickInventoryReq();
            bool bSuccess = true;
            string sErrMsg = string.Empty;
            int iAffectedRow = 0;

            // get last updated date
            StringBuilder sSql = new StringBuilder();
            sSql.Append("select max(InventoryInfoRequest_Date) as MaxRequestDate from wn_InventoryInfoRequest where InventoryInfoRequest_Success=1");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            req.dtUpdatedSince = new DateTime(2015, 11, 18);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["MaxRequestDate"] != DBNull.Value)
                        req.dtUpdatedSince = (DateTime)dt.Rows[0]["MaxRequestDate"];
                }
            }

            // request inventory info list from Fosdisck
            // now we only have forsdick and its ship partner_ID = ConfigParamter.ShipPartner.Fosdick = 1

            FosdickAPI api = new FosdickAPI();
            List<FosdickInventoryProduct> detailList = new List<FosdickInventoryProduct>();
            try
            {
                detailList = api.GetInventoryList(req, bIsTest);
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
                bSuccess = false;
            }

            DB db = new DB();

            db.DBConnect();
            db.DBBeginTrans();

            int iInventoryInfoReqID = db.DBGetSeq("InventoryInfoRequestID");

            // insert request
            sSql.Clear();

            sSql.Append("insert into wn_InventoryInfoRequest(InventoryInfoRequest_ID, ShipPartner_ID, InventoryInfoRequest_Date, InventoryInfoRequest_Success, InventoryInfoRequest_DataCount, InventoryInfoRequest_ErrMsg)");
            sSql.Append(" VALUES(");
            sSql.Append(iInventoryInfoReqID.ToString() + ",");
            sSql.Append(iShipPartnerID.ToString() + ",");
            sSql.Append("getdate(),");
            sSql.Append(bSuccess ? "1," : "0,");
            sSql.Append(detailList.Count.ToString() + ",");
            sSql.Append("'" + CommUtil.Quo(sErrMsg) + "')");
            iAffectedRow = db.DBExecute(sSql.ToString());


            foreach (FosdickInventoryProduct detail in detailList)
            {
                int iInventoryInfoID = db.DBGetSeq("InventoryInfoID");
                sSql.Clear();

                // insert inventory info
                sSql.Append("insert into wn_InventoryInfo");
                sSql.Append("(InventoryInfo_ID");
                sSql.Append(",ShipPartner_ID");
                sSql.Append(",InventoryInfoRequest_ID");
                sSql.Append(",TweebaaSku");
                sSql.Append(",InventoryInfo_Available");
                sSql.Append(",InventoryInfo_StockQuantityInConnecticut");
                sSql.Append(",InventoryInfo_StockQuantityInNevada");
                sSql.Append(",InventoryInfo_OtherQuantity");
                sSql.Append(",InventoryInfo_CommittedQuantity");
                sSql.Append(",InventoryInfo_AvailableQuantity");
                sSql.Append(",InventoryInfo_LastUpdatedDate");
                sSql.Append(",InventoryInfo_CreateDate)"); 
                sSql.Append(" VALUES(");
                sSql.Append(iInventoryInfoID.ToString() + ",");
                sSql.Append(iShipPartnerID.ToString() + ",");
                sSql.Append(iInventoryInfoReqID.ToString() + ",");
                sSql.Append("'" + CommUtil.Quo(detail.sSku) + "',");
                sSql.Append(detail.bAvailable?"1,":"0,");
                sSql.Append(detail.iStockQtyCT.ToString() + ",");
                sSql.Append(detail.iStockQtyNV.ToString() + ",");
                sSql.Append(detail.iStockQtyOther.ToString() + ",");
                sSql.Append(detail.iOrderCommittedQty.ToString() + ",");
                sSql.Append(detail.iTotalAvailableQty.ToString() + ",");
                sSql.Append("'" + detail.dtLastUpdated.ToString("MM/dd/yyyy hh:mm:ss").Replace("-", "/") + "',");
                sSql.Append("getdate())");
                iAffectedRow = db.DBExecute(sSql.ToString());

                // update wn_proRules 
                sSql.Clear();
                sSql.Append("update wn_proRules set InventoryInfo_ID=" + iInventoryInfoID.ToString());
                sSql.Append(" where prosku ='" + CommUtil.Quo(detail.sSku) + "'");
                iAffectedRow = db.DBExecute(sSql.ToString());


                // check inventory level and send notification if reach at minimum stock quantity
                sSql.Clear();
                sSql.Append("select a.name, b.proMinimumStock ");
                sSql.Append(" from wn_prd a inner join wn_proRules b on b.proid = a.prdGuid ");
                sSql.Append(" where prosku ='" + CommUtil.Quo(detail.sSku) + "'");
                DataSet dsMinStock = db.DBQuery(sSql.ToString());
                if (dsMinStock != null && ds.Tables.Count > 0)
                {
                    DataTable dtMinStock = dsMinStock.Tables[0];
                    if (dtMinStock != null && dtMinStock.Rows.Count > 0)
                    {
                        DataRow drMinStock = dtMinStock.Rows[0];
                        if (drMinStock["proMinimumStock"] != DBNull.Value)
                        {
                            int iMinStock = drMinStock["proMinimumStock"].ToString().ToInt();
                            if (detail.iTotalAvailableQty < iMinStock)
                            {
                                // send low inventory notification email
                                string sTitle = "Low Inventory Stock Level Notification";
                                string sBody =  "Product Name: " + drMinStock["name"].ToString() + 
                                                "<br/>Tweebaa Sku: " + detail.sSku +
                                                "<br/>Minimum Quantity: " + iMinStock.ToString() +
                                                "<br/>Available Quantity: " + detail.iTotalAvailableQty.ToString();
                                bool bOK = Mailhelper.SendMail(sTitle, sBody, "service@tweebaa.com");
                                     bOK = Mailhelper.SendMail(sTitle, sBody, "jack@leivaire.com");
                            }
                        }
                    }
                }
            }

            db.DBCommitTrans();
            db.DBDisconnect();

            return true;
        }


        public List<ShipOrderResult> ReSendWarehousePurchaseOrder(string sOrderNo,  bool bIsTest)
        {
            ShipOrderMgr mgr = new ShipOrderMgr();
            DataSet ds = mgr.GetShipOrderInfo(sOrderNo);

            List<ShipOrderResult> resultList = new List<ShipOrderResult>();

            string sErrMsg = "";

            // check dataset and table count
            if (ds == null || ds.Tables.Count == 0)
            {
                sErrMsg = "Failed to get the order data set information of " + sOrderNo;
                throw new Exception(sErrMsg);
            }

            //_s = JsonConvert.SerializeObject(ds.Tables[0]);

            // check data table and row count
            DataTable dt = ds.Tables[0];
            if (dt == null || dt.Rows.Count == 0)
            {
                sErrMsg = "Failed to get the order data table information of " + sOrderNo;
                throw new Exception(sErrMsg);
            }

            // check order status
            int iOrderStatus = dt.Rows[0]["OrderStatus"].ToString().ToInt();
            if (iOrderStatus != (int)(ConfigParamter.OrderStatus.WaitingToShip))
            {
                sErrMsg = "Cannot Shipping! Order is not in status of Waiting To Ship!";
                throw new Exception(sErrMsg);
            }

            FosdickOrder warehouseOrder = new FosdickOrder();
            warehouseOrder.ItemList = new List<FosdickOrderItem>();

            int iPrevShipPartnerID = -1;
            int iPrevShipFromID = -1;

            // for each item in the order
            foreach (DataRow dr in dt.Rows)
            {
                int iShipPartnerID = dr["ShipPartner_ID"].ToString().ToInt();
                int iShipFromID = dr["ShipFrom_ID"].ToString().ToInt();

                //iShipPartnerID = (int)(ConfigParamter.ShipPartner.EOrder); // jctest

                if (iShipPartnerID == (int)(ConfigParamter.ShipPartner.Fosdick))
                {

                    // Tweebaa warehouse from fosdick
                    if (iShipPartnerID != iPrevShipPartnerID)
                    {
                        if (iPrevShipPartnerID != -1)
                        {
                            ShipOrderResult result = SendWarehouseShipOrder(warehouseOrder);
                            resultList.Add(result);
                            warehouseOrder.Clear();
                        }
                        warehouseOrder.sOrderHeadGuidNo = sOrderNo;
                        warehouseOrder.iShipOrderID = DbHelperSQL.GetSeq("ShipOrderID");


                        warehouseOrder.sTest = (bIsTest ? "y" : "n");


                        warehouseOrder.sExternalID = warehouseOrder.iShipOrderID.ToString(); // should be the shipping order # but not the customer order # ( Twee...)
                        warehouseOrder.sAdCode = (bIsTest ? "TEST" : "DTC");
                        if (dr["ShipMethod_Code"] != DBNull.Value)
                        {
                            warehouseOrder.sShipMethodCode = dr["ShipMethod_Code"].ToString();
                        }
                        warehouseOrder.dTax = dr["TaxSum"].ToString().ToDecimal();  // the total amount tax of the order
                        warehouseOrder.dTotal += warehouseOrder.dTax;
                        warehouseOrder.sShipFirstName = dr["ShipTo_FirstName"].ToString();

                        // set first name
                        if (dr["ShipTo_LastName"] == DBNull.Value) warehouseOrder.sShipLastName = warehouseOrder.sShipFirstName;
                        else warehouseOrder.sShipLastName = dr["ShipTo_LastName"].ToString().Trim();
                        if (warehouseOrder.sShipLastName == string.Empty)
                        {
                            warehouseOrder.sShipLastName = warehouseOrder.sShipFirstName;
                        }
                        warehouseOrder.sShipAddress1 = dr["ShipTo_Address1"].ToString();
                        warehouseOrder.sShipAddress2 = dr["ShipTo_Address2"].ToString();
                        warehouseOrder.sShipCity = dr["ShipTo_City"].ToString();
                        warehouseOrder.sShipZip = dr["ShipTo_Zip"].ToString();
                        warehouseOrder.sShipState = dr["ShipTo_ProvinceShortName"].ToString().TrimEnd();
                        warehouseOrder.sShipCountry = GetCountryName(dr["ShipTo_CountryID"].ToString().ToInt());
                        warehouseOrder.sShipPhone = dr["ShipTo_Phone"].ToString();
                        warehouseOrder.sEmail = "";
                        warehouseOrder.sPaymentType = "5"; // prepaid :do not need payment inforamtion and billing information
                        warehouseOrder.sUseAsBilling = "y";

                        warehouseOrder.ItemList = new List<FosdickOrderItem>();

                    }
                    // add item
                    FosdickOrderItem warehouseItem = new FosdickOrderItem();
                    warehouseOrder.ItemList.Add(warehouseItem);
                    warehouseItem.sOrderBodyGuid = dr["OrderBody_Guid"].ToString();
                    warehouseItem.sInv = dr["Item_TweebaaSku"].ToString();
                    warehouseItem.dQty = dr["Item_Quantity"].ToString().ToDecimal();
                    warehouseItem.dPricePer = dr["Item_UnitPrice"].ToString().ToDecimal();
                    warehouseOrder.dSubTotal += warehouseItem.dQty * warehouseItem.dPricePer; //+ dr["Item_ShipFee"].ToString().ToDecimal();
                    warehouseOrder.dDiscounts += 0;
                    warehouseOrder.dPostage += 0;
                    warehouseOrder.dTotal += warehouseItem.dQty * warehouseItem.dPricePer; // +dr["Item_ShipFee"].ToString().ToDecimal();

                }
                iPrevShipPartnerID = dr["ShipPartner_ID"].ToString().ToInt();
                iPrevShipFromID = dr["ShipFrom_ID"].ToString().ToInt();
            } // for each order item

            if (warehouseOrder.ItemList.Count > 0)
            {
                ShipOrderResult result = SendWarehouseShipOrder(warehouseOrder);
                resultList.Add(result);
            }

            return resultList;
        } // function

   }
}