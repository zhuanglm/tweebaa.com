using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TweebaaWebApp.MasterPages;
using Twee.Comm;
using Twee.Model;
using Twee.Mgr;
using System.Reflection;
using System.Web.Script.Serialization;
using log4net;
using System.Text;
using System.Data;
using System.Configuration;

namespace TweebaaWebApp.AjaxPages
{
    public partial class payMoneyPaypalAjax : BasePage
    {
        private Guid? userGuid;
        private string cartIDs = string.Empty;
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string action = "";
        Dictionary<string, object> dic = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);
            //if (isLogion == false)
            //{
            //    Response.Write("-1");
            //    return;
            //}
            //else
            //{
            System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
            string cartInfo = sr.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            dic = js.Deserialize<Dictionary<string, object>>(cartInfo);
            action = dic["action"].ToString();
            string orderNo = dic["guidno"].ToString();
           
            //////Debug by Long for checkout lost cookie
            try
            {
                CookiesHelper cookie = new Twee.Comm.CookiesHelper();
                string userCooklieGuid = cookie.getCookie(ConfigurationManager.AppSettings.Get("cookieUserID"));
                Twee.Comm.CommHelper.WrtLog("cookie = " + userCooklieGuid);
            }
            catch (Exception e2)
            {

            }
            /////////////////////////////////////
            //
            if (action == "pay")
            {

                if (orderNo != "" && orderNo != "undefined")
                {
                    Paypal(orderNo);
                }
                else
                {
                    string GuidNo = "";
                    decimal tweebuck = dic["tweebuck"].ToString().ToDecimal();
                    decimal pointMoney = dic["pointMoney"].ToString().ToDecimal();
                    if (AddOrder(tweebuck,pointMoney,out GuidNo))
                    {
                        Paypal(GuidNo);
                    }
                }

            }

            //}
        }
        private void Paypal(string GuidNo)
        {
            OrderMgr orderNgr = new OrderMgr();
            orderNgr.GetOrderByOrserNo(GuidNo);


            ShoppingcartMgr shopMgr = new ShoppingcartMgr();
            DataTable dtPay = null; //shopMgr.GetMyCheckedShopCart(cartIDs, userGuid);
            if (userGuid==null)
            {
                dtPay = shopMgr.GetMyCheckedShopCart(cartIDs, null);
            }
            else
            {
                dtPay = shopMgr.GetMyCheckedShopCart("", userGuid);
            }
            StringBuilder sbPayData = new StringBuilder();

            string txt_username = dic["checkout_username"].ToString();
            string txt_useremail = dic["checkout_useremail"].ToString();
            string txt_shipping_details = dic["checkout_shipping_details"].ToString();
            string txt_order_extra = dic["checkout_order_extra"].ToString();
            string txt_order_total = dic["checkout_order_total"].ToString();
            decimal tweebuck = dic["tweebuck"].ToString().ToDecimal();
            decimal pointMoney = dic["pointMoney"].ToString().ToDecimal();
            Twee.Model.CheckoutTmp model = new Twee.Model.CheckoutTmp();
            model.Ordernum = GuidNo;
            model.shipping_useremail = txt_useremail;
            model.Shipping_details = txt_shipping_details;
            model.Shipping_order_extra = txt_order_extra;
            model.Shipping_order_total = txt_order_total;
            model.shipping_username = txt_username;
            Twee.Mgr.CheckoutTmpMgr mgr = new CheckoutTmpMgr();
            mgr.Add(model);

            int isSandBox = 0;
            if (isSandBox == 1)
            {
                sbPayData.Append("<form id='paypalsubmit'  action='https://www.sandbox.paypal.com/cgi-bin/webscr' method='POST' target='_top' >");
                //
            }
            else
            {
                sbPayData.Append("<form id='paypalsubmit'  action='https://www.paypal.com/cgi-bin/webscr' method='POST' target='_top' >");
            }
            sbPayData.Append("<input type='hidden' name='cmd' value='_cart'>");
            sbPayData.Append("<input type='hidden' name='custom' value='" + GuidNo + "'>");
            sbPayData.Append("<input type='hidden' name='upload' value='1'>");
            if (isSandBox == 1)
            {
                sbPayData.Append("<input type='hidden' name='business' value='dragon2934-facilitator@hotmail.com'>");
            }
            else
            {
                sbPayData.Append("<input type='hidden' name='business' value='online@tweebaa.com'>");
            }
            sbPayData.Append("<input type='hidden' name='currency_code' value='USD'>");
            //sbPayData.Append("<input type='hidden' name='tax_rate_1' value='" + dic["orderTaxHST"].ToString() + "'>");//税收
            //Modify by Long since the tax is NOT correct
            //sbPayData.Append("<input type='hidden' name='tax_1' value='" + dic["orderTax"].ToString() + "'>");//税收
            sbPayData.Append("<input type='hidden' name='tax_cart' value='" + dic["tax_cart"].ToString() + "'>");//税收  
            sbPayData.Append("<input type='hidden' name='shipping_1' value='" + dic["orderShipFee"].ToString() + "'>");//运费  
            sbPayData.Append("<input type='hidden' name='item_number_1' value='" + GuidNo + "'>");
            decimal discount_amount = tweebuck + pointMoney;
            if (discount_amount>0)
            {
                sbPayData.Append("<input type='hidden' name='discount_amount_1' value='" + discount_amount + "'>");
            } 
            if (isSandBox == 1)
            {
                sbPayData.Append("<input type='hidden' name='notify_url' value='http://tweebaa.com//Twee.WebPay/OrderConfirmation.aspx'>");
                sbPayData.Append("<input type='hidden' name='return_url' value='http://tweebaa.com//Twee.WebPay/OrderConfirmation.aspx'>");
            }
            else
            {
                sbPayData.Append("<input type='hidden' name='notify_url' value='http://www.tweebaa.com/PayPal/notify.aspx'>");
                sbPayData.Append("<input type='hidden' name='return_url' value='http://tweebaa.com/Product/OrderConfirmation.aspx'>");
            }

            for (int i = 0; i < dtPay.Rows.Count; i++)
            {
                int number = i + 1;
                sbPayData.Append("<input type='hidden' name='item_name_" + number + "' value='" + dtPay.Rows[i]["name"].ToString() + "'>");
                if (dtPay.Rows[i]["wnstat"].ToString() == "2")
                {
                    sbPayData.Append("<input type='hidden' name='amount_" + number + "' value='" + dtPay.Rows[i]["saleprice"].ToString() + "'>");
                }
                else
                {
                    sbPayData.Append("<input type='hidden' name='amount_" + number + "' value='" + dtPay.Rows[i]["price"].ToString() + "'>");
                }
                int quantity = dtPay.Rows[i]["quantity"].ToString().Substring(0, dtPay.Rows[i]["quantity"].ToString().IndexOf(".")).ToInt();
                sbPayData.Append("<input type='hidden' name='quantity_" + number + "' value='" + quantity + "'>");
            }
            sbPayData.Append("</form>");
            sbPayData.Append("<script>document.forms['paypalsubmit'].submit();</script>");
            DeletShopCartList(cartIDs);//创建订单后删除购物车
            Response.Write(sbPayData.ToString());
        }

        /// <summary>
        /// 支付(提交订单)
        /// </summary>
        private void PaypalByOrder(string GuidNo)
        {

            //请求参数
            string cmd = "_xclick";
            //string business = "641389097-facilitator@qq.com";//收款账号
            string business = "online@tweebaa.com";//收款账号            
            string lc = "US";//账号国家
            string item_name = dic["orderName"].ToString();
            string item_number = GuidNo;
            string amount = dic["orderMoney"].ToString();
            string currency_code = "USD";
            //string button_subtype = "services";
            string no_note = string.Empty;
            if (dic.ContainsKey("orderBody")) no_note = dic["orderBody"].ToString();
            string quantity = "1";// dic["quantity"].ToString();//(注意：如果这里数量大于1，订单总金额会乘以该数字，所以必须为1)
            string tax_rate = "";//税收
            string shipping = "";//运费
            string notify_url = "http://www.tweebaa.com//PayPal/notify.aspx";
            string return_url = "";
            string paymentaction = "authorization";

            //把请求参数打包成数组
            Dictionary<string, string> sParaTemp = new Dictionary<string, string>();
            sParaTemp.Add("cmd", cmd);
            sParaTemp.Add("business", business);
            sParaTemp.Add("lc", lc);
            sParaTemp.Add("item_name", item_name);
            sParaTemp.Add("item_number", item_number);
            sParaTemp.Add("amount", amount);
            sParaTemp.Add("currency_code", currency_code);
            sParaTemp.Add("no_note", no_note);
            sParaTemp.Add("quantity", quantity);
            sParaTemp.Add("tax_rate", tax_rate);
            sParaTemp.Add("shipping", shipping);
            sParaTemp.Add("notify_url", notify_url);
            sParaTemp.Add("return_url", return_url);
            sParaTemp.Add("paymentaction", paymentaction);

            //建立请求
            string sHtmlText = BuildRequest(sParaTemp, "POST");
            Response.Write(sHtmlText);
            //Add by Long for debug
            // CommHelper.WrtLog(sHtmlText);
        }

        /// <summary>
        /// 建立请求，以表单HTML形式构造（默认）
        /// </summary>
        /// <param name="sParaTemp">请求参数数组</param>
        /// <param name="strMethod">提交方式。两个值可选：post、get</param>
        /// <param name="strButtonValue">确认按钮显示文字</param>
        /// <returns>提交表单HTML文本</returns>
        public static string BuildRequest(Dictionary<string, string> sParaTemp, string strMethod)
        {
            //待请求参数数组     
            StringBuilder sbHtml = new StringBuilder();
            //sbHtml.Append("<form id='paypalsubmit'  action='https://www.paypal.com/cgi-bin/webscr' method='" + strMethod + "' target='_top' >");
            sbHtml.Append("<form id='paypalsubmit'  action='https://www.paypal.com/webapps/mpp/get-started/payment-authorization' method='" + strMethod + "' target='_top' >");

            foreach (KeyValuePair<string, string> temp in sParaTemp)
            {
                sbHtml.Append("<input type='hidden' name='" + temp.Key + "' value='" + temp.Value + "'/>");
            }
            //sbHtml.Append("<input type='submit' value='" + strButtonValue + "' style='display:none;'></form>");
            sbHtml.Append("</form>");
            sbHtml.Append("<script>document.forms['paypalsubmit'].submit();</script>");
            return sbHtml.ToString();
        }

        /// <summary>
        /// 从购物车选中支付数据添加到订单
        /// </summary>
        /// <param name="GuidNo">输出订单号</param>
        /// <returns></returns>
        private bool AddOrder(decimal tweebuck,decimal pointMoney,out string GuidNo)
        {
            GuidNo = "";
            try
            {
                string cartGuids = CommHelper.GetStrDecode(dic["cartGuids"].ToString());
                if (cartGuids == "" || cartGuids == "undefined")
                {
                    CookiesHelper cookie = new CookiesHelper();
                    string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
                    cartGuids = cookie.getCookie(keyShopCart);
                    cookie.createCookie(keyShopCart, "", -1);
                }
                cartIDs = cartGuids;
                if (!string.IsNullOrEmpty(cartGuids))
                {
                    string[] ids = cartGuids.Split(',');
                    Orderhead orderHead = new Orderhead();
                    orderHead.guid = Guid.NewGuid();
                    orderHead.addressguid = dic["addressId"].ToString().ToGuid().Value;//订单收货地址guid
                    orderHead.guidno = CommUtil.CreateOrderNum();//订单编号
                    GuidNo = orderHead.guidno;
                    orderHead.messageWord = dic["message"].ToString();//订单留言
                    orderHead.userguid = userGuid == null ? Guid.Empty : userGuid.Value;//订单user
                    orderHead.wnstat = 0;//订单状态

                    orderHead.logisticscost = Decimal.Parse(dic["orderShipFee"].ToString());
                    orderHead.taxSum = Decimal.Parse(dic["orderTax"].ToString());
                    orderHead.taxGST = Decimal.Parse(dic["orderTaxGST"].ToString());
                    orderHead.taxHST = Decimal.Parse(dic["orderTaxHST"].ToString());
                    orderHead.taxQST = Decimal.Parse(dic["orderTaxQST"].ToString());
                    orderHead.userShopingAmount = pointMoney;
                    orderHead.useTweebuckAmount = tweebuck;
                    List<OrderBody> listBody = new List<OrderBody>();
                    ShoppingcartMgr mgr = new ShoppingcartMgr();                   
                    PrdPriceMgr price = new PrdPriceMgr();
                    Guid? shareId = null;
                    for (int i = 0; i < ids.Length; i++)
                    {
                        string id = ids[i].ToString().Replace("'", "").Trim();
                        Shoppingcart shoppingcart = mgr.GetModel(id.ToGuid().Value);
                        if (shoppingcart != null)
                        {
                            if (shoppingcart.shareId!=null)
                            {
                                shareId = shoppingcart.shareId;
                            }                           
                            OrderBody orderBody = new OrderBody();
                            orderBody.guid = Guid.NewGuid();
                            orderBody.headGuid = orderHead.guid;//订单id
                            orderBody.prdGuid = shoppingcart.prdguid;//产品id
                            orderBody.quantity = shoppingcart.quantity;//产品数量
                            orderBody.idx = i;//该产品顺序号
                            orderBody.ruleid = shoppingcart.ruleid;//订单产品规格
                            //根据购买规格和数量获取对应销售价格
                            orderBody.buydanJia = price.GetSalePrice(orderBody.ruleid.Value, orderBody.quantity.Value);
                            orderBody.shareId = shareId;//分享链接的id
                            orderBody.logisticscost = shoppingcart.shipfee;
                            orderBody.shipmethodid = shoppingcart.shipmethodid;
                            listBody.Add(orderBody);
                        }
                    }
                    if (shareId != null)
                    {
                        for (int i = 0; i < listBody.Count; i++)
                        {
                            listBody[i].shareId = shareId;
                        }
                    }                   
                    OrderMgr orderMgr = new OrderMgr();
                    bool b = orderMgr.AddOrder(orderHead, listBody);
                    if (b)
                    {
                        //DeletShopCartList(cartGuids);//创建订单后删除购物车
                    }
                    return b;
                }
                else
                {
                    GuidNo = "";
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }


        /// <summary>
        /// 批量删除购物车
        /// </summary>
        private void DeletShopCartList(string cartGuids)
        {
            try
            {
                ShoppingcartMgr mgr = new ShoppingcartMgr();
                Shoppingcart shoppingcart = new Shoppingcart();
                mgr.DeleteList(cartGuids);
            }
            catch (Exception)
            {
                Response.Write("0");
            }

        }




    }
}