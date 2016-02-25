using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using AjaxPro;
using System.Configuration;
using Twee.Comm;

namespace TweebaaWebApp2.Mgr.orderMgr
{
    public partial class orderNoPay : System.Web.UI.Page
    {
        public ListItem firstItem = new ListItem() { Value = "--请选择--", Text = "--请选择--" };
        public string webAppDomain = string.Empty;

        Twee.Mgr.PrdCateMgr cateMgr = new Twee.Mgr.PrdCateMgr();

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(orderNoPay));
            if (!IsPostBack)
            {
                webAppDomain = ConfigurationManager.AppSettings["webAppDomain"].Trim();
            }
        }

        [AjaxPro.AjaxMethod]
        public string GetFirstCate()
        {
            var cateModelList = cateMgr.GetModelList(" layer=0");
            if (cateModelList == null || cateModelList.Count == 0)
                return "fail";
            StringBuilder json = new StringBuilder();
            foreach (var item in cateModelList)
            {
                json.AppendFormat(",{2}\"value\":\"{0}\",\"text\":\"{1}\"{3}", item.guid, item.name, "{", "}");
            }
            if (!string.IsNullOrEmpty(json.ToString()))
                return "[{\"value\":\"--请选择--\",\"text\":\"--请选择--\"}" + json.ToString() + "]";
            else
                return "fail";
        }

        [AjaxPro.AjaxMethod]
        public string GetNextCate(string parentId)
        {
            if (string.IsNullOrEmpty(parentId))
                return "fail";
            var sonModelList = cateMgr.GetModelList(" prtGuid='" + parentId + "'");
            if (sonModelList == null || sonModelList.Count == 0)
                return "fail";
            StringBuilder json = new StringBuilder();
            foreach (var item in sonModelList)
            {
                json.AppendFormat(",{2}\"value\":\"{0}\",\"text\":\"{1}\"{3}", item.guid, item.name, "{", "}");
            }
            if (!string.IsNullOrEmpty(json.ToString()))
                return "[{\"value\":\"--请选择--\",\"text\":\"--请选择--\"}" + json.ToString() + "]";
            else
                return "fail";
        }

        [AjaxPro.AjaxMethod]
        public string NoPay(string ids)
        {
            try
            {
                var res = new Twee.Mgr.PrdMgr().PreSalePassAll(ids, "unknown");
                if (res > 0)
                    return "success";
                else
                    return "fail";
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        [AjaxPro.AjaxMethod]
        public string UpState(string id, int state)
        {
            try
            {
                Twee.Mgr.OrderMgr mgr = new Twee.Mgr.OrderMgr();
                if (mgr.UpdateOrderState(id, -3))
                {
                    return "success";
                }
                return "fail";
            }
            catch (Exception)
            {
                return "error";
            }
        }
 
        [AjaxPro.AjaxMethod]
        public string SendWarehouseShipOrder(string sTweebaaOrderID, string sOrderStatus, string sPassword)
        {
            try
            {
                // check password
                if (sPassword != "EdmundJack" + DateTime.Now.Day.ToString())
                {
                    return "Error: Password is not correct!";
                }

                // for Amazon order need to change order status from unpadi to waiting to ship
                int iOrderStatus = int.Parse(sOrderStatus);
                if (iOrderStatus == (int)ConfigParamter.OrderStatus.UnPaid)
                {
                    Twee.Mgr.OrderMgr mgr = new Twee.Mgr.OrderMgr();
                    if (!mgr.UpdateOrderState(sTweebaaOrderID, (int)ConfigParamter.OrderStatus.WaitingToShip))
                    {
                        return "Error: Failed to update order status!";
                    }
                }

                // send warhouse ship order
                ShipAPI.ShipOrder so = new ShipAPI.ShipOrder();
                List<ShipAPI.ShipOrderResult> resultList = so.ReSendWarehousePurchaseOrder(sTweebaaOrderID, false);

                // parse results
                StringBuilder sResult = new StringBuilder();
                if (resultList != null)
                {
                    foreach (ShipAPI.ShipOrderResult result in resultList)
                    {
                        sResult.Append("Tweebaa Shipping Order ID: " + result.iShipOrderID.ToString() + "\n");
                        sResult.Append("Shipping Partner Order ID: " + result.sPartnerOrderID + "\n");
                        sResult.Append("Shipping Partner Name: " + result.sPartnerName + "\n");
                        sResult.Append("Error message: " + result.sErrMsg + "\n");
                    }
                }
                else
                {
                    sResult.Append("No results");
                }
                return sResult.ToString();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [AjaxPro.AjaxMethod]
        public string GetOrderStatus(string sOrderID)
        {
            try
            {
                Twee.Mgr.OrderMgr mgr = new Twee.Mgr.OrderMgr();
                int iOrderStatus = mgr.GetOrderState(sOrderID);
                return iOrderStatus.ToString();
            }
            catch (Exception)
            {
                return "error";
            }
        }

        [AjaxPro.AjaxMethod]
        public string GetOrderEmail(string sOrderID)
        {
            try
            {
                Twee.Mgr.OrderMgr mgr = new Twee.Mgr.OrderMgr();
                string sEmail = mgr.GetOrderEmail(sOrderID);
                if (!string.IsNullOrEmpty(sEmail)) 
                    return sEmail;
                else 
                    return "";
                
            }
            catch (Exception)
            {
                return "error";
            }
        }

        [AjaxPro.AjaxMethod]
        public string GetWarehouseShipOrderID(string sOrderID)
        {
            try
            {
                Twee.Mgr.OrderMgr mgr = new Twee.Mgr.OrderMgr();
                int iShopOrderID = mgr.MgeGetWarehouseShipOrderID(sOrderID);
                return iShopOrderID.ToString();
            }
            catch (Exception)
            {
                return "error";
            }
        }

    }
}