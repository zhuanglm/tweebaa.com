using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using Twee.Mgr;
using Twee.Comm;
using System.Configuration;
using Twee.Model;
using log4net;
using System.Reflection;

namespace TweebaaWebApp.Product
{
    public partial class OrderConfirmation : TweebaaWebApp.MasterPages.BasePage
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public string out_trade_no;
        public string strMessage="No Message";
        private Guid? userGuid;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                string strResponse;

                //int isSandbox = 0;
                string authToken = "uRmpgJfPOdjvzdbesYpNtzQ1kbmEPNsg8Taoax3n9eAbhMHIzysr3tGuq28";
                // Sandbox 
                //string authToken = "UBQI2Ev4Ad_oY5UYgkK8-x7m6bHIOyeGeeWEA8Cffro6_TmZ0st9FAlCM64";
                
                string txToken = Request.QueryString["tx"];
                string query = "cmd=_notify-synch&tx=" + txToken + "&at=" + authToken;

                //Post back to either sandbox or live  jctest
                //string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
                string strLive = "https://www.paypal.com/cgi-bin/webscr";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strLive);

                //Set values for the request back
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = query.Length;


                //Send the request to PayPal and get the response
                StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                streamOut.Write(query);
                streamOut.Close();
                StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
                strResponse = streamIn.ReadToEnd();
                streamIn.Close();

                Dictionary<string, string> results = new Dictionary<string, string>();
                strMessage = strResponse;
                if (strResponse != "")
                {
                    StringReader reader = new StringReader(strResponse);
                    string line = reader.ReadLine();
                    log.Info("line:" + line);
                    if (line == "SUCCESS")
                    {
                        log.Info("line:"+reader.ReadLine());
                        while ((line = reader.ReadLine()) != null)
                        {
                            results.Add(line.Split('=')[0], line.Split('=')[1]);

                        }
                        //strMessage+="<p><h3>Your order has been received.</h3></p>";
                        log.Info("out_trade_no"+results["custom"]);
                        out_trade_no = results["custom"];
                        //check 

                        /*
                        Response.Write("<b>Details</b><br>");
                        Response.Write("<li>Name: " + results["first_name"] + " " + results["last_name"] + "</li>");
                        Response.Write("<li>Item: " + results["item_name"] + "</li>");
                        Response.Write("<li>Amount: " + results["payment_gross"] + "</li>");
                        Response.Write("<hr>");
                        */
                        //付款成功
                        //检查付款状态
                        //检查 txn_id 是否已经处理过
                        //检查 receiver_email 是否是您的 PayPal 账户中的 EMAIL 地址
                        //检查付款金额和货币单位是否正确
                        //处理这次付款， 包括写数据库               

                        //out_trade_no = HttpContext.Current.Request["item_number"].ToString().Trim();
                        //strMessage += " out_trade_no " + out_trade_no;

                        if (!string.IsNullOrEmpty(out_trade_no))
                        {
                           // CommHelper.WrtLog("orderconfirmation page out_trade_no=" + out_trade_no);
                            //1. 修改库存
                            PrdStoragMgr Storag = new PrdStoragMgr();
                            OrderMgr orderMgr = new OrderMgr();
                            bool b1 = orderMgr.UpdateOrderState(out_trade_no, 1);
                            if (b1 == true)
                            {
                                CommHelper.WrtLog("update state ok");
                                strMessage += "修改订单状态成功！";
                            }
                            else
                            {
                                CommHelper.WrtLog("update state failed");
                                strMessage += "修改订单状态失败！";
                            }

                            bool b2 = Storag.UpdateStoragByOrder(out_trade_no.Trim());
                            if (b2 == true)
                            {
                                strMessage += "修改库存成功！";
                            }
                            else
                            {
                                strMessage += "修改库存失败！";
                            }

                            //Collage Share Split Commission
                            Twee.Mgr.CollageShareMgr shareMgr = new CollageShareMgr();
                            shareMgr.CollageSplitShareCommission(out_trade_no);

                            // submit shipping order  jctest
                            SubmitShipOrder(out_trade_no);
                            
                            //Send E-mail 
                            Twee.Mgr.CheckoutTmpMgr mgr = new CheckoutTmpMgr();

                            Twee.Model.CheckoutTmp model = mgr.GetCheckoutTmp(out_trade_no);
                            string txt_useremail = model.shipping_useremail;
                            string txt_shipping_details = model.Shipping_details;
                            string txt_order_extra = model.Shipping_order_extra;
                            string txt_order_total = model.Shipping_order_total;
                            string txt_username = model.shipping_username;
                            /*
                            HttpCookie checkout_useremail = new HttpCookie("checkout_useremail");
                            checkout_useremail = Request.Cookies["checkout_useremail"];
                            if (checkout_useremail != null)
                            {
                                txt_useremail = checkout_useremail.Value;

                            }

                            HttpCookie checkout_shipping_details = new HttpCookie("checkout_shipping_details");
                            checkout_shipping_details = Request.Cookies["checkout_shipping_details"];
                            if (checkout_shipping_details != null)
                            {
                                txt_shipping_details = checkout_shipping_details.Value;
                            }


                            HttpCookie checkout_order_extra = new HttpCookie("checkout_order_extra");
                            checkout_order_extra = Request.Cookies["checkout_order_extra"];
                            if (checkout_order_extra != null)
                            {
                                txt_order_extra = checkout_order_extra.Value;
                            }

                            HttpCookie checkout_order_total = new HttpCookie("checkout_order_total");
                            checkout_order_total = Request.Cookies["checkout_order_total"];
                            if (checkout_order_total != null)
                            {
                                txt_order_total = checkout_order_total.Value;

                            }
                             * */

                            //CommHelper.WrtLog("txt_order_extra=" + txt_order_extra);

                            byte[] data = Convert.FromBase64String(txt_order_extra);
                            txt_order_extra = Encoding.UTF8.GetString(data);

                            // CommHelper.WrtLog("txt_order_total=" + txt_order_total);
                            byte[] data1 = Convert.FromBase64String(txt_order_total);
                            txt_order_total = Encoding.UTF8.GetString(data1);
                            //remove <select
                            while (txt_order_total.IndexOf("<select") > 0)
                            {
                                int i = txt_order_total.IndexOf("<select");
                                int j = txt_order_total.IndexOf("selected");
                                string s1 = txt_order_total.Substring(0, i);
                                string s2 = txt_order_total.Substring(j, txt_order_total.Length - j);
                                s2 = s2.Replace("</option>", "");
                                s2 = s2.Replace("</select>", "");
                                //remove first >
                                int k = s2.IndexOf(">");
                                s2 = s2.Substring(k + 1, s2.Length - k - 1);
                                txt_order_total = s1 + s2;
                            }

                            /////////////////////////////////////

                            Mailhelper.SendOrderConfirmationEmail(txt_useremail, out_trade_no, txt_shipping_details, txt_order_extra, txt_order_total, txt_username);

                            //////Debug by Long for checkout lost cookie
                            try
                            {
                                /*
                                CookiesHelper cookie = new Twee.Comm.CookiesHelper();
                                string userCooklieGuid = cookie.getCookie(ConfigurationManager.AppSettings.Get("cookieUserID"));
                                
                                bool isLogion = CheckLogion(out userGuid);
                                Twee.Comm.CommHelper.WrtLog("cookie2 = " + userCooklieGuid + " isLogion=" + isLogion + " userGuid=" + userGuid.ToString());
                                */
                                //remove shopping cart
                                /*
                                CookiesHelper cookie_cart = new CookiesHelper();
                                string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
                                string cartGuids = cookie_cart.getCookie(keyShopCart);
                                //delete cookie?
                                cookie_cart.delCookie(keyShopCart);
                                //cookie_cart.createCookie(keyShopCart, "", -1);
                                DeletShopCartList(cartGuids);
                                Twee.Comm.CommHelper.WrtLog("try to remove shopping cart,id=" + cartGuids);
                                 * */
                            }
                            catch (Exception exception)
                            {
                                var stringBuilder = new StringBuilder();

                                while (exception != null)
                                {
                                    stringBuilder.AppendLine(exception.Message);
                                    stringBuilder.AppendLine(exception.StackTrace);

                                    exception = exception.InnerException;
                                }

                                string sErrorText = stringBuilder.ToString();
                                Twee.Comm.CommHelper.WrtLog("cookie2 = " + sErrorText);
                            }


                        }
                        else
                        {
                            //CommHelper.WrtLog("out_trade_no null");
                        }
                    }
                    else if (line == "FAIL")
                    {
                        // Log for manual investigation
                        Response.Write("Unable to retrive transaction detail");
                    }
                }
                else
                {
                    //unknown error
                    Response.Write("ERROR");

                }
            }
            catch (Exception e1)
            {

                Twee.Comm.CommUtil.GenernalErrorHandler(e1);
            }


            /*
        
            //创建回复的 request
            //在 Sandbox 情况下， 设置：
            // WebRequest.Create("https://www.sandbox.paypal.com/cgi-bin/webscr");
            HttpWebRequest req;
                //WebRequest.Create("https://www.sandbox.paypal.com/cgi-bin/webscr");

            if(isSandbox==1){
                req = (HttpWebRequest)WebRequest.Create("https://www.sandbox.paypal.com/cgi-bin/webscr");
            }else{
                req = (HttpWebRequest)WebRequest.Create("https://www.paypal.com/cgi-bin/webscr");
            }
            //设置 request 的属性
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] param = HttpContext.Current.Request.BinaryRead(
            HttpContext.Current.Request.ContentLength);
            strFormValues = Encoding.ASCII.GetString(param);
            //建议在此将接受到的信息记录到日志文件中以确认是否收到 IPN 信息
            strNewValue = strFormValues + "&cmd=_notify-validate";
            req.ContentLength = strNewValue.Length;
            //发送 request
            StreamWriter stOut = new StreamWriter(req.GetRequestStream(),
            System.Text.Encoding.ASCII);
            stOut.Write(strNewValue);
            stOut.Close();
            //回复 IPN 并接受反馈信息
            StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
            strResponse = stIn.ReadToEnd();
            stIn.Close();
            CommHelper.WrtLog("strResponse=" + strResponse);
            strMessage = strResponse;
            //确认 IPN 是否合法
            if (strResponse == "VERIFIED")
            {
                //付款成功
                //检查付款状态
                //检查 txn_id 是否已经处理过
                //检查 receiver_email 是否是您的 PayPal 账户中的 EMAIL 地址
                //检查付款金额和货币单位是否正确
                //处理这次付款， 包括写数据库               

                 out_trade_no = HttpContext.Current.Request["item_number"].ToString().Trim();


                if (!string.IsNullOrEmpty(out_trade_no))
                {
                    CommHelper.WrtLog("out_trade_no=" + out_trade_no);
                    //1. 修改库存
                    PrdStoragMgr Storag = new PrdStoragMgr();
                    OrderMgr orderMgr = new OrderMgr();
                    bool b1 = orderMgr.UpdateOrderState(out_trade_no, 1);
                    if (b1 == true)
                    {
                        CommHelper.WrtLog("update state ok");
                        Response.Write("修改订单状态成功！");
                    }
                    else
                    {
                        CommHelper.WrtLog("update state failed");
                        Response.Write("修改订单状态失败！");
                    }

                    bool b2 = Storag.UpdateStoragByOrder(out_trade_no.Trim());
                    if (b2 == true)
                    {
                        Response.Write("修改库存成功！");
                    }
                    else
                    {
                        Response.Write("修改库存失败！");
                    }


                }
                else
                {
                    CommHelper.WrtLog("out_trade_no null"  );
                }

            }
            else if (strResponse == "INVALID")
            {
                //付款失败

                //string paypalInfo = strFormValues;
                //string dt = System.DateTime.Now.ToString();
                //string sql = "insert into paypal (notify,createtime) values ('INVALID','" + dt + "')";
                //Twee.Comm.DbHelperSQL.ExecuteSql(sql);

                Application["test"] = "INVALID";
                //Response.Redirect("~/weclome.aspx");
            }
            else
            {
                Application["test"] = "no data paypal";
            }
             * */
        }


        private void SubmitShipOrder( string sOrderNo)
        {
            // one tweebaa purchase order may be shipped by multiple shipping order
            
            string sShipErrMsg = string.Empty;
            ShipAPI.ShipOrder shipOrder = new ShipAPI.ShipOrder();

            List<ShipAPI.ShipOrderResult> shipOrderResultList = shipOrder.ShipPurchaseOrder(sOrderNo, false);
            foreach (ShipAPI.ShipOrderResult shipOrderResult in shipOrderResultList)
            {
                if (!string.IsNullOrEmpty(shipOrderResult.sErrMsg))
                {

                    sShipErrMsg += "Shipping Order ID: " + shipOrderResult.iShipOrderID.ToString();
                    sShipErrMsg += "Shipping Partner: " + shipOrderResult.iPartnerID.ToString() + " - " + shipOrderResult.sPartnerName;
                    sShipErrMsg += "Error Message: " + shipOrderResult.sErrMsg;
                }
            }
            if (sShipErrMsg != string.Empty)
            {
                sShipErrMsg = "Shipping Error <br/>Purchase Order :" + sOrderNo + "<br/>" + sShipErrMsg;

                // send an email to CSC
                string sEmailSubject = out_trade_no.Trim() + " Shipping Error";
                Mailhelper.SendMail(sEmailSubject, sShipErrMsg, "cscshipping@tweebaa.com");
            }

        }

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