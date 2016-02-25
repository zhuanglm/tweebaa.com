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
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace TweebaaWebApp2.Paypal
{
    public partial class notify : TweebaaWebApp2.MasterPages.BasePage
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public string out_trade_no;
        public string strMessage = "No Message";
        private Guid? userGuid;

        //for GTM e-commerce tracking
        public float fOrderTotal = 0;
        public string strSuccess = "false"; //for 
        public string strTransactionData = ""; 


        protected void Page_Load(object sender, EventArgs e)
        {
            //Twee.Comm.CommHelper.WrtLog("IPN works11111111111111111111111111111111111");
            
            int IsSandbox = ConfigurationManager.AppSettings.Get("IsPaypal_Sandbox").ToInt();

            try
            {

                string strResponse;

                //int isSandbox = 0;
                string authToken = "";
                
                bool isLogion = CheckLogion(out userGuid);
                bool IsTestingGroup = Twee.Comm.CommUtil.IsTestingGroup(userGuid.ToString()); //如果是测试用户
                Twee.Comm.CommHelper.WrtLog("Paypal Notify page isLogion ==" + isLogion + " IsTestingGroup==" + IsTestingGroup);
                if (IsSandbox == 1 || (isLogion && IsTestingGroup))
                {
                    authToken = "UBQI2Ev4Ad_oY5UYgkK8-x7m6bHIOyeGeeWEA8Cffro6_TmZ0st9FAlCM64";
                }
                else
                {
                    authToken = "uRmpgJfPOdjvzdbesYpNtzQ1kbmEPNsg8Taoax3n9eAbhMHIzysr3tGuq28";
                }
                // Sandbox 
                //string authToken = "UBQI2Ev4Ad_oY5UYgkK8-x7m6bHIOyeGeeWEA8Cffro6_TmZ0st9FAlCM64";

                //log all $POST ??
                /*
                foreach (string key in Request.Form.Keys)
                {
                    Twee.Comm.CommHelper.WrtLog("IPN POST"+Request.Form[key]);
                }
                //log all $GET
                foreach (string key in Request.QueryString.Keys)
                {
                    Twee.Comm.CommHelper.WrtLog("IPN GET"+Request.QueryString[key]);
                }
                 * 
                 * IPN works11111111111111111111111111111111111
IPN paypal return Form values:
  mc_gross = 27.52
  protection_eligibility = Eligible
  address_status = confirmed
  item_number1 = Twee10000291
  payer_id = BEU793MS9JPMC
  tax = 3.17
  address_street = 1 Maire-Victorin
  payment_date = 19:00:19 Oct 11, 2015 PDT
  payment_status = Completed
  charset = windows-1252
  address_zip = M5A 1E1
  mc_shipping = 0.00
  mc_handling = 0.00
  first_name = test
  mc_fee = 1.10
  address_country_code = CA
  address_name = test buyer
  notify_version = 3.8
  custom = Twee10000291
  payer_status = verified
  business = dragon2934-facilitator@hotmail.com
  address_country = Canada
  num_cart_items = 1
  mc_handling1 = 0.00
  address_city = Toronto
  verify_sign = ARFp0p7IdLQc587UEQSF0WM6My-LAI0ByRkrTxQ9u4HBCwo2i5r8rVh3
  payer_email = dragon2934-buyer@hotmail.com
  mc_shipping1 = 0.00
  txn_id = 0H165213A8086921X
  payment_type = instant
  last_name = buyer
  address_state = Ontario
  item_name1 = PODillow
  receiver_email = dragon2934-facilitator@hotmail.com
  payment_fee = 1.10
  quantity1 = 1
  receiver_id = NNMV9QA6VRE2N
  txn_type = cart
  mc_gross_1 = 24.35
  mc_currency = USD
  residence_country = CA
  test_ipn = 1
  transaction_subject = Twee10000291
  payment_gross = 27.52
  ipn_track_id = 47c60513940
QueryString values:

notify return paypal return txToken=

                 * */
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("");
                //PayPal使用POST的方式发送过来的数据
                foreach (string key in Request.Form.Keys)
                {

/*
 * 
 $value = urlencode(stripslashes($value));
			$value = preg_replace('/(.*[^%^0^D])(%0A)(.*)/i','${1}%0D%0A${3}',$value);// IPN fix
			$req .= "&$key=$value";
 */
                    string strValue = Request.Form[key];
                    strValue = strValue.Replace("'", "\'");
                    strValue = Regex.Replace(strValue, "/(.*[^%^0^D])(%0A)(.*)/i", "{1}%0D%0A${3}");
                    builder.Append("&").Append(key).Append("=").Append(Request.Form[key]);
                    if (key == "custom") //This is Order Number
                    {
                        out_trade_no = Request.Form[key];
                        //Twee.Comm.CommHelper.WrtLog("out_trade_no =" + out_trade_no);
                    }
                }
                /*
                builder.AppendLine("QueryString values:");
                foreach (string key in Request.QueryString.Keys)
                {
                    builder.Append("  ").Append(key).Append(" = ").AppendLine(Request.QueryString[key]);
                }
                string values = builder.ToString();
                Twee.Comm.CommHelper.WrtLog("IPN paypal return " + values);
                */

                //必须要原样返回这些数据给PayPal，用于验证数据的来源和真实性
                //CURLOPT_POSTFIELDS => http_build_query(array(‘cmd’ => ‘_notify-validate’) + $ipn_post_data),
                //string txToken = Request.QueryString["tx"];
                //string query = "cmd=_notify-synch&tx=" + txToken + "&at=" + authToken;
                string query =  builder.ToString(); ;
                Twee.Comm.CommHelper.WrtLog("notify return paypal post back=" + query);
                //Post back to either sandbox or live  jctest
                string strPaypalGateway = "";
                if (IsSandbox == 1 || (isLogion && IsTestingGroup))
                {
                    strPaypalGateway = "https://www.sandbox.paypal.com/cgi-bin/webscr";
                }
                else
                {
                    strPaypalGateway = "https://www.paypal.com/cgi-bin/webscr";
                }
                Twee.Comm.CommHelper.WrtLog("gateway =" + strPaypalGateway);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strPaypalGateway);

                //Set values for the request back
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
               // req.ContentLength = query.Length;
                byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
                string strRequest = Encoding.ASCII.GetString(param);
                strRequest += "&cmd=_notify-validate";
                req.ContentLength = strRequest.Length;
                Twee.Comm.CommHelper.WrtLog("strRequest=" + strRequest);


                //Send the request to PayPal and get the response
                StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                streamOut.Write(strRequest);
                streamOut.Close();
                StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
                strResponse = streamIn.ReadToEnd();
                streamIn.Close();

                //Dictionary<string, string> results = new Dictionary<string, string>();
               // strMessage = strResponse;
                Twee.Comm.CommHelper.WrtLog("notify return response=" + strResponse);
                if (strResponse != "")
                {
                    //StringReader reader = new StringReader(strResponse);
                    //string line = reader.ReadLine();

                    if (strResponse == "VERIFIED")  //VERIFIED
                    {

                       // WriteCookie("out_trade_no", out_trade_no);
                        //Response.Cookies["out_trade_no"].Expires = DateTime.Now.AddMinutes(10d);
                        //Twee.Comm.CommHelper.WrtLog("IPN line:" + line + "out_trade_no " + out_trade_no + " Session[out_trade_no]=" + Response.Cookies["out_trade_no"]["Text"]);
                        /*
                        Twee.Comm.CommHelper.WrtLog("line:" + reader.ReadLine());
                        while ((line = reader.ReadLine()) != null)
                        {
                            results.Add(line.Split('=')[0], line.Split('=')[1]);
                            
                        }
                        //strMessage+="<p><h3>Your order has been received.</h3></p>";
                        Twee.Comm.CommHelper.WrtLog("out_trade_no" + results["custom"]);
                        out_trade_no = results["custom"];*/
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
                        OrderMgr orderMgr = new OrderMgr();
                        int iState = orderMgr.GetOrderState(out_trade_no);
                        CommHelper.WrtLog("at notify.aspx.c state=" + iState);
                        if (!string.IsNullOrEmpty(out_trade_no) && iState==0)
                        {
                            // CommHelper.WrtLog("orderconfirmation page out_trade_no=" + out_trade_no);
                            //1. 修改库存
                            PrdStoragMgr Storag = new PrdStoragMgr();
                           // OrderMgr orderMgr = new OrderMgr();
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


                            ///Add by Long for Share Point Redeem
                            ///
                            Twee.Mgr.UserGradeCalMgr gradeMgr = new UserGradeCalMgr();
                            ///???? 在那里运行??  gradeMgr.UpdateShopingPoint(out_trade_no); //以前为啥放在后台 ???
                            gradeMgr.SharePointRedeem(out_trade_no);
                            //////////////////
                            // submit shipping order  jctest
                            SubmitShipOrder(out_trade_no);

                            //Send E-mail 
                            Twee.Mgr.CheckoutTmpMgr mgr = new CheckoutTmpMgr();

                            Twee.Model.CheckoutTmp model = mgr.GetCheckoutTmp(out_trade_no);
                            string txt_useremail = model.shipping_useremail;
                            string txt_shipping_details = model.Shipping_details;
                            string txt_order_extra = "";
                            string txt_order_total = "";
                            string txt_username = model.shipping_username;
                            if (txt_username.Length < 10)
                            {
                                //guest checkout,we need to get their username as Shelley's Request
                                txt_username = orderMgr.GetGuestCheckoutUsernameByOrderno(out_trade_no);
                            }
                            string txt_carts_id = model.ShoppingCartID;
                            txt_carts_id = txt_carts_id.Replace("'", "");
                            CommHelper.WrtLog(" try to delete shopping carts" + txt_carts_id);
                            
                            DeletShopCartList(txt_carts_id);
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
                            /*
                            byte[] data = Convert.FromBase64String(txt_order_extra);
                            txt_order_extra = Encoding.UTF8.GetString(data);

                            // CommHelper.WrtLog("txt_order_total=" + txt_order_total);
                            byte[] data1 = Convert.FromBase64String(txt_order_total);
                            txt_order_total = Encoding.UTF8.GetString(data1);
                            //remove <select
                        
                            //获取shipping fee
                            string ss1 = "<td id=\"shipfee0\" class=\"pro-price\" style=\"display:none\">";
                            int ii = txt_order_total.IndexOf(ss1);
                            float fshipping_fee = 0.0f;
                            int jj = 0;
                            if (ii > 0)
                            {
                                jj = txt_order_total.IndexOf("</td>", ii);
                                if (jj > ii)
                                {
                                    string ss = txt_order_total.Substring(ii + ss1.Length, jj - ii - ss1.Length);
                                    fshipping_fee = float.Parse(ss.Replace("$", ""));
                                }
                            }
                            //将所有的option 列为一个数组



                            while (txt_order_total.IndexOf("<select") > 0)
                            {
                                //获取</select>后面的内容
                                string s6 = "</select>";
                                ii = txt_order_total.IndexOf(s6);
                                s6 = txt_order_total.Substring(ii + s6.Length, txt_order_total.Length - ii - s6.Length);

                                int i = txt_order_total.IndexOf("<select");
                                // int j = txt_order_total.IndexOf("selected");
                                string s1 = txt_order_total.Substring(0, i);
                                string s2 = txt_order_total.Substring(i, txt_order_total.Length - i);
                                //删除</option>后面的所有内容

                                string s3 = ""; string s4 = "";
                                while (s2.IndexOf("<option") > 0)
                                {
                                    //获取Value及Text
                                    s3 = "value=\"";
                                    ii = s2.IndexOf(s3);
                                    if (ii > 0)
                                    {
                                        jj = s2.IndexOf("\"", ii + s3.Length);
                                        if (jj > ii)
                                        {
                                            s4 = s2.Substring(ii + s3.Length, jj - ii - s3.Length);
                                            s2 = s2.Substring(jj, s2.Length - jj - 1);
                                            //检查这个是否为shipping fee
                                            string[] s5 = s4.Split(' ');
                                            if (s5.Length == 2)
                                            {
                                                if (float.Parse(s5[1]) == fshipping_fee)
                                                {
                                                    //获取shipping text
                                                    ii = s2.IndexOf("</option>");
                                                    s2 = s2.Substring(0, ii);
                                                    break;
                                                }
                                            }
                                        }
                                    }

                                }
                                int k = s2.IndexOf(">");
                                s2 = s2.Substring(k + 1, s2.Length - k - 1);
                                txt_order_total = s1 + s2 + s6;
                            }
                            /////////////////////////////////////
                            */

                            //Added By Lance 2016-02-08
                            TransactionInfo transinfo = new TransactionInfo();
                            strSuccess = "true";
                            transinfo = orderMgr.GetTransactionInfo4GA(out_trade_no);
                            fOrderTotal = transinfo.Revenue;
                            var serializer = new JavaScriptSerializer();
                            strTransactionData = JsonConvert.SerializeObject(transinfo.items);
                            CommHelper.WrtLog("orderconfirmation page out_trade_no=" + out_trade_no);
                            CommHelper.WrtLog("orderconfirmation page order_total =" + fOrderTotal.ToString());
                            CommHelper.WrtLog("orderconfirmation page transaction_data =" + strTransactionData);
                            Mailhelper.SendOrderConfirmationEmail("lance@leivaire.com", out_trade_no, "strOrderTotal" + fOrderTotal.ToString(), "strTransactionData" + strTransactionData, txt_order_total, txt_username, "Paypal");
                            
                            txt_order_total = orderMgr.CreateOrderConfirmationEmailBody(out_trade_no);
                            Mailhelper.SendOrderConfirmationEmail(txt_useremail, out_trade_no, txt_shipping_details, txt_order_extra, txt_order_total, txt_username, "Paypal");

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
                                //Twee.Comm.CommHelper.WrtLog("cookie2 = " + sErrorText);
                            }

                            //redirect to Order Confirmation page

                            /*
                            var response = base.Response;
                            response.Redirect("/Checkout/OrderConfirmation.aspx?order=" + out_trade_no);
                            */
                        }
                        else
                        {
                            //CommHelper.WrtLog("out_trade_no null");
                        }
                    }
                    else if (strResponse == "INVALID")
                    {
                        // Log for manual investigation
                        //Response.Write("Unable to retrive transaction detail");
                        //send e-mail ?
                        CommHelper.WrtLog("Paypal IPN invalid?why?");
                    }
                    else
                    {
                        CommHelper.WrtLog("Paypal IPN return else????");
                    }
                }
                else
                {
                    //unknown error
                    CommHelper.WrtLog("Unknown ERROR????");

                }
            }
            catch (Exception e1)
            {

                Twee.Comm.CommUtil.GenernalErrorHandler(e1);
            }

            /*
            string strFormValues;
            string strNewValue;
            string strResponse;
            //创建回复的 request
            //在 Sandbox 情况下， 设置：
            // WebRequest.Create("https://www.sandbox.paypal.com/cgi-bin/webscr");
            HttpWebRequest req = (HttpWebRequest)
            //WebRequest.Create("https://www.sandbox.paypal.com/cgi-bin/webscr");
            WebRequest.Create("https://www.paypal.com/cgi-bin/webscr");
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
            //确认 IPN 是否合法
            if (strResponse == "VERIFIED")
            {
                //付款成功
                //检查付款状态
                //检查 txn_id 是否已经处理过
                //检查 receiver_email 是否是您的 PayPal 账户中的 EMAIL 地址
                //检查付款金额和货币单位是否正确
                //处理这次付款， 包括写数据库               

                string out_trade_no = HttpContext.Current.Request["item_number"].ToString().Trim();
                CommHelper.WrtLog("paypal notify page out_trade_no=" + out_trade_no);
                if (!string.IsNullOrEmpty(out_trade_no))
                {
                    //1. 修改库存
                    PrdStoragMgr Storag = new PrdStoragMgr();
                    OrderMgr orderMgr = new OrderMgr();
                    bool b1 = orderMgr.UpdateOrderState(out_trade_no, 1);
                    if (b1 == true)
                    {
                        Response.Write("修改订单状态成功！");
                    }
                    else
                    {
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

            }
            else if (strResponse == "INVALID")
            {
                //付款失败

                //string paypalInfo = strFormValues;
                //string dt = System.DateTime.Now.ToString();
                //string sql = "insert into paypal (notify,createtime) values ('INVALID','" + dt + "')";
                //Twee.Comm.DbHelperSQL.ExecuteSql(sql);

                Application["test"] = "INVALID";
                Response.Redirect("~/weclome.aspx");
            }
            else
            {
                Application["test"] = "no data paypal";
            }*/
        }

        public void WriteCookie(string name, string value)
        {
            var cookie = new HttpCookie(name, value);
            HttpContext.Current.Response.Cookies.Set(cookie);
        }

        private void SubmitShipOrder(string sOrderNo)
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
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(e);
                //Response.Write("0");
            }

        }
    }
}