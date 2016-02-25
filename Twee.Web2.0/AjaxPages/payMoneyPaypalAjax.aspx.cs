﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TweebaaWebApp2.MasterPages;
using Twee.Comm;
using Twee.Model;
using Twee.Mgr;
using System.Reflection;
using System.Web.Script.Serialization;
using log4net;
using System.Text;
using System.Data;
using System.Configuration;
using Moneris;
using System.Collections;

namespace TweebaaWebApp2.AjaxPages
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
            string orderNo = "";
            if (dic.ContainsKey("guidno")) orderNo=dic["guidno"].ToString();
           
            //////Debug by Long for checkout lost cookie
            /*
            try
            {
                CookiesHelper cookie = new Twee.Comm.CookiesHelper();
                string userCooklieGuid = cookie.getCookie(ConfigurationManager.AppSettings.Get("cookieUserID"));
               // Twee.Comm.CommHelper.WrtLog("cookie = " + userCooklieGuid);
            }
            catch (Exception e2)
            {

            }*/
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
                    decimal sharePointMoney = dic["sharePointMoney"].ToString().ToDecimal(); ////Add by Long for Share Points Redeem
                    if (AddOrder(tweebuck,pointMoney,sharePointMoney,out GuidNo))
                    {
                        Paypal(GuidNo);
                    }
                }

            }
            else if (action == "query_coupon_code")
            {
                string strCouponCode = dic["coupon_code"].ToString();
                string strOrderTotal = dic["order_total"].ToString();
                string strUserGuid = "";
                if (isLogion)
                {
                    strUserGuid = userGuid.ToNullString();// dic["userGuid"].ToString();
                }
                else
                {
                    strUserGuid = Twee.Comm.CommUtil.GetDummyGuid();
                }
                Twee.Mgr.CouponMgr mgr = new CouponMgr();
                Twee.Comm.CommHelper.WrtLog("1=" + strCouponCode + "  2=" + strOrderTotal + " 3=" + strUserGuid);
                float fRet = mgr.CheckCoupon(strCouponCode, strOrderTotal, strUserGuid);
                Response.Write(fRet);

            }
            else if (action == "CreateOrder")
            {
                /*
                if (orderNo != "" && orderNo != "undefined")
                {
                    Paypal(orderNo);
                }
                else
                {*/
                string GuidNo = "";
                decimal tweebuck = dic["tweebuck"].ToString().ToDecimal();
                decimal pointMoney = dic["pointMoney"].ToString().ToDecimal();
                decimal sharePointMoney = dic["sharePointMoney"].ToString().ToDecimal(); ////Add by Long for Share Points Redeem
                string strProducts = "";
                if (AddOrder2(tweebuck, pointMoney, sharePointMoney, out GuidNo, out strProducts))
                {


                    string txt_username = dic["checkout_username"].ToString();
                    string txt_useremail = dic["checkout_useremail"].ToString();
                    string txt_shipping_details = dic["checkout_shipping_details"].ToString();
                    string txt_order_extra = dic["checkout_order_extra"].ToString();
                    string txt_order_total = dic["checkout_order_total"].ToString();
                    /*
                    decimal tweebuck = dic["tweebuck"].ToString().ToDecimal();
                    decimal pointMoney = dic["pointMoney"].ToString().ToDecimal();
                    //
                    decimal sharePointMoney = dic["sharePointMoney"].ToString().ToDecimal(); ////Add by Long for Share Points Redeem
                    */
                    //如果用户使用Guest Checkout
                    if (txt_username.Length < 2 && txt_useremail.Length < 2)
                    {
                        CookiesHelper cookie = new CookiesHelper();
                        string keyAddress = System.Configuration.ConfigurationManager.AppSettings["cookieAddress"].ToString();
                        string addressCartGudid = cookie.getCookie(keyAddress);
                        if (!string.IsNullOrEmpty(addressCartGudid))
                        {
                            UserAddressMgr mgr1 = new UserAddressMgr();
                            DataTable dt1 = mgr1.GetAddressByGuid(addressCartGudid);
                            txt_useremail = dt1.Rows[0]["guest_e_mail"].ToString();
                        }

                    }

                    Twee.Model.CheckoutTmp model = new Twee.Model.CheckoutTmp();
                    model.Ordernum = GuidNo;
                    model.shipping_useremail = txt_useremail;
                    model.Shipping_details = txt_shipping_details;
                    model.Shipping_order_extra = txt_order_extra;
                    model.Shipping_order_total = txt_order_total;
                    model.shipping_username = txt_username;
                    model.ShoppingCartID = cartIDs;

                    Twee.Mgr.CheckoutTmpMgr mgr = new CheckoutTmpMgr();
                    mgr.Add(model);

                    //Add by Long 2016/01/20 做活动 / App / SlotMachine 免费送奖品
                   // userGuid == null ? Guid.Empty : userGuid.Value;
                    if (userGuid == null)
                    {
                        Response.Write(GuidNo);
                    }
                    else
                    {
                        //查数据库是否有活动记录
                        if (strProducts.Length <= 1)
                        {
                            Response.Write(GuidNo);
                        }
                        else
                        {
                            string[] ids = strProducts.Split(',');
                            Twee.Mgr.OrderMgr orderMgr = new OrderMgr();
                            DataTable freeProductID = orderMgr.GetFreeProductGuidForEvents(userGuid.ToString());
                            if (freeProductID == null)
                            {
                                //No Record
                                Response.Write(GuidNo);
                            }
                            else
                            {
                                bool bHaveFreeProduct = false;
                                ShoppingcartMgr mgrShopCart = new ShoppingcartMgr();
                                for (int i = 0; i < ids.Length; i++)
                                {
                                    string id = ids[i].ToString().Replace("'", "").Trim();
                                    id = id.Replace("&#39;", "");
                                    id = id.Replace("&#39;", "");
                                    if (id.Length == Guid.Empty.ToString().Length) // && id == freeProductID.Rows[0]["ProductGuid"].ToString())
                                    {
                                        Shoppingcart shoppingcart = mgrShopCart.GetModel(id.ToGuid().Value);
                                        if (shoppingcart != null && freeProductID.Rows[0]["ProductGuid"].ToString() == shoppingcart.prdguid.ToString())
                                         {
                                             bHaveFreeProduct = true;
                                         }
                                        
                                    }
                                }
                                if (!bHaveFreeProduct)
                                {
                                    Response.Write(GuidNo);
                                }
                                else if (bHaveFreeProduct && ids.Length > 2)
                                {
                                    Response.Write("-2");//只能Checkout Free Product，不能包括其他产品
                                }
                                else if ((bHaveFreeProduct && ids.Length == 1) || ( bHaveFreeProduct && ids.Length == 2 && ids[1].Length == 0))
                                {
                                    //update Order number
                                    orderMgr.UpdateFreeProductClaimOrderNo(freeProductID.Rows[0]["FreeProductID"].ToString(), GuidNo);
                                    Response.Write(GuidNo + "|" + freeProductID.Rows[0]["serial_code"].ToString());
                                }
                                else
                                {
                                    Response.Write("-3");
                                }
                            }
                        }
                    }
                    // Paypal(GuidNo);
                }
                else
                {
                    Response.Write("");
                    Twee.Comm.CommUtil.SendDebugString("Create Order error,why?");
                }
                //}

            }
            else if (action == "DoPaypalPayment")
            {
                string GuidNo = dic["guidno"].ToString();
                DoPaymentViaPaypal(orderNo);
            }
            else if (action == "DoCreditCardPayment")
            {
                try
                {
                    string GuidNo = dic["guidno"].ToString();
                    string txtcardholder_firstname = dic["cardholder_firstname"].ToString();
                    string txtcardholder_lastname = dic["cardholder_lastname"].ToString();
                    string txtcardnumber = dic["cardnumber"].ToString();
                    string txtexpire_mm = dic["expire_mm"].ToString();
                    string txtexpire_yy = dic["expire_yy"].ToString();
                    string number_csc = dic["csc"].ToString();
                    /*
                    string txtShippingAddrID=dic["ShippingAddressID"].ToString();
                    string txtBillingAddrID = dic["BillingAddressID"].ToString();
                    */
                    OrderMgr orderNgr = new OrderMgr();
                    DataTable dtOrder = orderNgr.GetOrderHead(Guid.Empty, GuidNo);


                    ShoppingcartMgr shopMgr = new ShoppingcartMgr();
                    DataTable dtPay = null; //shopMgr.GetMyCheckedShopCart(cartIDs, userGuid);
                    if (userGuid == null)
                    {
                        string cartGuids = "";// CommHelper.GetStrDecode(dic["cartGuids"].ToString());
                        if (cartGuids == "" || cartGuids == "undefined")
                        {
                            CookiesHelper cookie = new CookiesHelper();
                            string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
                            cartGuids = cookie.getCookie(keyShopCart);
                            // cookie.createCookie(keyShopCart, "", -1);
                        }
                        dtPay = shopMgr.GetMyCheckedShopCart(cartGuids, null);
                    }
                    else
                    {
                        dtPay = shopMgr.GetMyCheckedShopCart("", userGuid);
                    }
                    if (dtPay == null)
                    {
                        //Invalid order
                        Response.Write("-2");
                        return;
                    }
                    /*
                    StringBuilder sbPayData = new StringBuilder();

                    string txt_username = dic["checkout_username"].ToString();
                    string txt_useremail = dic["checkout_useremail"].ToString();
                    string txt_shipping_details = dic["checkout_shipping_details"].ToString();
                    string txt_order_extra = dic["checkout_order_extra"].ToString();
                    string txt_order_total = dic["checkout_order_total"].ToString();
                    decimal tweebuck = dic["tweebuck"].ToString().ToDecimal();
                    decimal pointMoney = dic["pointMoney"].ToString().ToDecimal();
                    //
                    decimal sharePointMoney = dic["sharePointMoney"].ToString().ToDecimal(); ////Add by Long for Share Points Redeem

                    //如果用户使用Guest Checkout
                    if (txt_username.Length < 2 && txt_useremail.Length < 2)
                    {
                        CookiesHelper cookie = new CookiesHelper();
                        string keyAddress = System.Configuration.ConfigurationManager.AppSettings["cookieAddress"].ToString();
                        string addressCartGudid = cookie.getCookie(keyAddress);
                        if (!string.IsNullOrEmpty(addressCartGudid))
                        {
                            UserAddressMgr mgr1 = new UserAddressMgr();
                            DataTable dt1 = mgr1.GetAddressByGuid(addressCartGudid);
                            txt_useremail = dt1.Rows[0]["guest_e_mail"].ToString();
                        }

                    }

                    Twee.Model.CheckoutTmp model = new Twee.Model.CheckoutTmp();
                    model.Ordernum = GuidNo;
                    model.shipping_useremail = txt_useremail;
                    model.Shipping_details = txt_shipping_details;
                    model.Shipping_order_extra = txt_order_extra;
                    model.Shipping_order_total = txt_order_total;
                    model.shipping_username = txt_username;
                    model.ShoppingCartID = cartIDs;

                    Twee.Mgr.CheckoutTmpMgr mgr = new CheckoutTmpMgr();
                    mgr.Add(model);
                    */

                    /********************* Post Request Variables ********************************/
                    bool IsTestingGroup = Twee.Comm.CommUtil.IsTestingGroup(userGuid.ToString());
                    string host = "";// "esqa.moneris.com"; 
                    string store_id = "";// "store5";  //e-Select Plus Store ID: monca83906
                    string api_token = "";// "yesguy";

                    if (IsTestingGroup)
                    {
                        host =  "esqa.moneris.com"; 
                        store_id =  "store5";  //e-Select Plus Store ID: monca83906
                        api_token =  "yesguy";
                    }
                    else
                    {
                        host = "www3.moneris.com";// "esqa.moneris.com"; 
                        store_id = "monca83906";// "store5";  //e-Select Plus Store ID: monca83906
                        api_token = "vBXo4OWdaiHsSltlj8OM";// "yesguy";
                    }
                    /********************* Transactional Variables *******************************/

                    string order_id = GuidNo;// "Need_Unique_Order_ID";

                    string pan = txtcardnumber;
                    string expdate = txtexpire_mm + txtexpire_yy;
                    string crypt = "7";

                    /********************* Billing/Shipping Variables ****************************/

                    string first_name = txtcardholder_firstname;
                    string last_name = txtcardholder_lastname;
                    // string company_name = "ProLine Inc.";
                    /*
                    string address = "623 Bears Ave";
                    string city = "Chicago";
                    string province = "Illinois";
                    string postal_code = "M1M2M1";
                    string country = "Canada";
                    string phone = "777-999-7777";
                    string fax = "777-999-7778";*/

                    //get tax and shipping
                    float taxGST = float.Parse(dtOrder.Rows[0]["taxGST"].ToString());
                    float taxHST = float.Parse(dtOrder.Rows[0]["taxHST"].ToString());
                    float taxQST = float.Parse(dtOrder.Rows[0]["taxQST"].ToString());

                    float fTax = taxGST + taxHST + taxQST;

                    string tax1 = fTax.ToString("0.00");
                    //string tax2 = "5.78";
                    //string tax3 = "4.56";
                    float ftShippingCost = float.Parse(dtOrder.Rows[0]["logisticscost"].ToString());
                    string shipping_cost = ftShippingCost.ToString("0.00");

                    /********************** Customer Information Object **************************/

                    CustInfo customer2 = new CustInfo();

                    //decimal discount_amount = tweebuck + pointMoney + sharePointMoney; //Modify by Long for Share Point Redeem
                    //NO discount send ??

                    float flTotal = 0.0f;
                    for (int i = 0; i < dtPay.Rows.Count; i++)
                    {



                        int quantity = dtPay.Rows[i]["quantity"].ToString().Substring(0, dtPay.Rows[i]["quantity"].ToString().IndexOf(".")).ToInt();

                        Hashtable i1 = new Hashtable();		//item hashtable #1

                        i1.Add("name", dtPay.Rows[i]["name"].ToString());
                        i1.Add("quantity", quantity.ToString());
                        i1.Add("product_code", dtPay.Rows[i]["prosku"].ToString());
                        if (dtPay.Rows[i]["wnstat"].ToString() == "2")
                        {
                            //sbPayData.Append("<input type='hidden' name='amount_" + number + "' value='" + dtPay.Rows[i]["saleprice"].ToString() + "'>");
                            i1.Add("extended_amount", dtPay.Rows[i]["saleprice"].ToString());
                            flTotal = flTotal + float.Parse(dtPay.Rows[i]["saleprice"].ToString());
                        }
                        else
                        {
                            //sbPayData.Append("<input type='hidden' name='amount_" + number + "' value='" + dtPay.Rows[i]["price"].ToString() + "'>");
                            i1.Add("extended_amount", dtPay.Rows[i]["price"].ToString());
                            flTotal = flTotal + float.Parse(dtPay.Rows[i]["price"].ToString());
                        }


                        customer2.SetItem(i1);
                    }
                    float tweebuck = float.Parse(dtOrder.Rows[0]["useTweebuckAmount"].ToString());
                    float pointMoney = float.Parse(dtOrder.Rows[0]["userShopingAmount"].ToString());
                    float sharePointMoney = float.Parse(dtOrder.Rows[0]["useSharePointAmount"].ToString());
                    //Add by Long 2016/01/15 for coupon redeem
                    float userCouponAmount = float.Parse(dtOrder.Rows[0]["useCouponAmount"].ToString());

                    if (tweebuck > 0)
                    {
                        Hashtable i1 = new Hashtable();		//item hashtable #1
                        i1.Add("name", "Tweebuck Discount ");
                        i1.Add("quantity", 1);
                        i1.Add("product_code", "Tweebuck");
                        i1.Add("extended_amount", tweebuck.ToString("0.00"));
                    }
                    if (pointMoney > 0)
                    {
                        Hashtable i1 = new Hashtable();		//item hashtable #1
                        i1.Add("name", "Shopping Point Discount");
                        i1.Add("quantity", 1);
                        i1.Add("product_code", "Shopping Point");
                        i1.Add("extended_amount", pointMoney.ToString("0.00"));
                    }
                    if (sharePointMoney > 0)
                    {
                        Hashtable i1 = new Hashtable();		//item hashtable #1
                        i1.Add("name", "Share Point Discount");
                        i1.Add("quantity", 1);
                        i1.Add("product_code", "share Point ");
                        i1.Add("extended_amount", sharePointMoney.ToString("0.00"));
                    }
                    if (userCouponAmount > 0)
                    {
                        Hashtable i1 = new Hashtable();		//item hashtable #1
                        i1.Add("name", "Coupon Discount");
                        i1.Add("quantity", 1);
                        i1.Add("product_code", dtOrder.Rows[0]["CouponCode"].ToString());
                        i1.Add("extended_amount", userCouponAmount.ToString("0.00"));
                    }


                    flTotal = flTotal + float.Parse(tax1) + float.Parse(shipping_cost) - tweebuck - pointMoney - sharePointMoney - userCouponAmount;
                    string amount = flTotal.ToString("0.00");

                    /******************************* Billing Hashtable ***************************/
                    /*
                    Twee.Model.Useraddress shippingAddr = new Useraddress();
                    Twee.Model.Useraddress billingAddr = new Useraddress();*/
                    Twee.Mgr.UserAddressMgr addrMgr = new UserAddressMgr();
                    // string txtShippingAddrID = dic["ShippingAddressID"].ToString();
                    // string txtBillingAddrID = dic["BillingAddressID"].ToString();
                    /*
                    DataTable shippingAddr = addrMgr.GetAddressByGuid(txtShippingAddrID);
                    DataTable billingAddr = addrMgr.GetAddressByGuid(txtBillingAddrID);*/
                    Hashtable b = new Hashtable();	//billing hashtable

                    //u.guid,prtguid,provinceid,u.cityid,countyid,zip,address,address2,u.username,lastName,u.phone,tel,isfirst,addtime,
                    //p.ProName,city ,users.email,c.country ,u.email as guest_e_mail
                    b.Add("first_name", first_name);
                    b.Add("last_name", last_name);
                    // b.Add("company_name", company_name);
                    b.Add("address", dtOrder.Rows[0]["BillingAddress1"].ToString() + " " + dtOrder.Rows[0]["BillingAddress2"]);
                    b.Add("city", dtOrder.Rows[0]["BillingCity"]);
                    b.Add("province", dtOrder.Rows[0]["BillingProvince"]);
                    b.Add("postal_code", dtOrder.Rows[0]["BillingZip"]);
                    b.Add("country", dtOrder.Rows[0]["BillingCountry"]);
                    b.Add("phone", dtOrder.Rows[0]["BillingPhone"]);

                    /*
                    b.Add("fax", fax);*/
                    b.Add("tax1", tax1);       //federal tax
                    /*
                    b.Add("tax2", tax2);        //prov tax
                    b.Add("tax3", tax3);        //luxury tax*/
                    b.Add("shipping_cost", shipping_cost);   //shipping cost  */

                    customer2.SetBilling(b);

                    /****************************** Shipping Hashtable ***************************/

                    Hashtable s = new Hashtable();	//shipping hashtable

                    s.Add("first_name", first_name);
                    s.Add("last_name", last_name);
                    //s.Add("company_name", company_name);
                    s.Add("address", dtOrder.Rows[0]["ShippingAddress1"] + " " + dtOrder.Rows[0]["ShippingAddress2"]);
                    s.Add("city", dtOrder.Rows[0]["ShippingCity"]);
                    s.Add("province", dtOrder.Rows[0]["ShippingProvince"]);
                    s.Add("postal_code", dtOrder.Rows[0]["ShippingZip"]);
                    s.Add("country", dtOrder.Rows[0]["ShippingCountry"]);
                    s.Add("phone", dtOrder.Rows[0]["ShippingPhone"]);
                    /*
                    s.Add("fax", fax);*/
                    s.Add("tax1", tax1);       //federal tax
                    /* s.Add("tax2", tax2);        //prov tax
                    s.Add("tax3", tax3);        //luxury tax*/
                    s.Add("shipping_cost", shipping_cost);   //shipping cost

                    customer2.SetShipping(s);

                    /************************* Order Line Item1 Hashtable ************************/


                    string email = "";
                    if (!string.IsNullOrEmpty(dtOrder.Rows[0]["ShippingEmail"].ToString()))
                    {
                        email = dtOrder.Rows[0]["ShippingEmail"].ToString();
                        customer2.SetEmail(email);
                    }




                    /*************** Miscellaneous Customer Information Methods *******************/


                    if (dtOrder.Rows[0]["messageWord"].ToString() != "Please leave your comments")
                        customer2.SetInstructions(dtOrder.Rows[0]["messageWord"].ToString());



                    /********************** Transactional Request Object **************************/

                    Purchase purchase = new Purchase(order_id, amount, pan, expdate, crypt);

                    /************************ Set Customer Information ***************************/

                    purchase.SetCustInfo(customer2);

                    /**************************** Https Post Request ***************************/

                    HttpsPostRequest mpgReq =
                        new HttpsPostRequest(host, store_id, api_token, purchase);

                    /******************************* Receipt ***********************************/



                    Receipt receipt = mpgReq.GetReceipt();
                    string responseCode = receipt.GetResponseCode();
                    int iCode = 0;
                    if (responseCode == "null" || string.IsNullOrEmpty(responseCode))
                    {
                        //Transaction was not sent for authorization

                        //Do Authorization
                        PreAuth preauth = new PreAuth(order_id, amount, pan, expdate, crypt);
                        //preauth.SetDynamicDescriptor("123456"); 
                        HttpsPostRequest preReq = new HttpsPostRequest(host, store_id, api_token, preauth);
                        Receipt pre_receipt = preReq.GetReceipt();
                        string strCode = pre_receipt.GetResponseCode();
                        if (strCode == "null" || string.IsNullOrEmpty(strCode))
                        {
                            Twee.Comm.CommUtil.SendDebugString("Pre Auth failed?");
                        }
                        else
                        {
                            if (int.Parse(strCode) < 50)
                            {
                                //Resend ??
                                mpgReq = new HttpsPostRequest(host, store_id, api_token, purchase);
                                receipt = mpgReq.GetReceipt();
                                responseCode = receipt.GetResponseCode();
                            }
                        }
                    }

                    try
                    {

                        iCode = int.Parse(responseCode);
                    }
                    catch (Exception ee)
                    {
                        Twee.Comm.CommUtil.SendDebugString("responseCode=" + responseCode + ee.Message);
                        iCode = 10000;
                    }
                    if (iCode < 50)
                    {
                        /*
                        Console.WriteLine("CardType = " + receipt.GetCardType());
                        Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
                        Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
                        Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
                        Console.WriteLine("TransType = " + receipt.GetTransType());
                        Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
                        Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                        Console.WriteLine("ISO = " + receipt.GetISO());
                        Console.WriteLine("BankTotals = " + receipt.GetBankTotals());
                        Console.WriteLine("Message = " + receipt.GetMessage());
                        Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
                        Console.WriteLine("Complete = " + receipt.GetComplete());
                        Console.WriteLine("TransDate = " + receipt.GetTransDate());
                        Console.WriteLine("TransTime = " + receipt.GetTransTime());
                        Console.WriteLine("Ticket = " + receipt.GetTicket());
                        Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                        Console.WriteLine("IsVisaDebit = " + receipt.GetIsVisaDebit());
                        */

                        //需要更新 TxnNumber & ReferenceNum
                        string strSQL = "update wn_orderhead set TxnNumber='" + receipt.GetTxnNumber() + "',ReferenceNum='" + receipt.GetReferenceNum() + "' where guidno='" + order_id + "'";
                        //Do Update
                        DbHelperSQL.ExecuteSql(strSQL);
                        Response.Write(responseCode + "|OK");
                    }
                    else
                    {
                        //declined --why?

                        Response.Write(responseCode + "|" + receipt.GetMessage());
                    }

                }
                catch (Exception e2)
                {
                    //Console.WriteLine(e);
                    Twee.Comm.CommUtil.GenernalErrorHandler(e2);
                    Response.Write("-3|Error");
                }



            }

            //}
        }

        private void DoPaymentViaPaypal(string GuidNo)
        {
            OrderMgr orderNgr = new OrderMgr();
            DataTable dtOrder = orderNgr.GetOrderHead(Guid.Empty, GuidNo);


            ShoppingcartMgr shopMgr = new ShoppingcartMgr();
            DataTable dtPay = null; //shopMgr.GetMyCheckedShopCart(cartIDs, userGuid);
            if (userGuid == null)
            {
                string cartGuids = "";// CommHelper.GetStrDecode(dic["cartGuids"].ToString());
                if (cartGuids == "" || cartGuids == "undefined")
                {
                    CookiesHelper cookie = new CookiesHelper();
                    string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
                    cartGuids = cookie.getCookie(keyShopCart);
                   // cookie.createCookie(keyShopCart, "", -1);
                }
                dtPay = shopMgr.GetMyCheckedShopCart(cartGuids, null);
            }
            else
            {
                dtPay = shopMgr.GetMyCheckedShopCart("", userGuid);
            }
            if (dtOrder.Rows.Count == 0)
            {

                Twee.Comm.CommUtil.SendDebugString(" dt Order rows =0, why?");
            }
            float tweebuck = float.Parse(dtOrder.Rows[0]["useTweebuckAmount"].ToString());
            float pointMoney = float.Parse(dtOrder.Rows[0]["userShopingAmount"].ToString());
            float sharePointMoney = float.Parse(dtOrder.Rows[0]["useSharePointAmount"].ToString());
            //Add by Long 2016/01/15 for coupon redeem
            string ss = dtOrder.Rows[0]["useCouponAmount"].ToString();
            if (ss.Length == 0) ss = "0";
            float userCouponAmount = float.Parse(dtOrder.Rows[0]["useCouponAmount"].ToString());

            float taxGST = float.Parse(dtOrder.Rows[0]["taxGST"].ToString());
            float taxHST = float.Parse(dtOrder.Rows[0]["taxHST"].ToString());
            float taxQST = float.Parse(dtOrder.Rows[0]["taxQST"].ToString());

            float fTax = taxGST + taxHST + taxQST;
            string tax1 = fTax.ToString("0.00");
            //string tax2 = "5.78";
            //string tax3 = "4.56";
            float fshipping_cost = float.Parse(dtOrder.Rows[0]["logisticscost"].ToString());
            string shipping_cost= fshipping_cost.ToString("0.00");
            StringBuilder sbPayData = new StringBuilder();

            int isSandBox = ConfigurationManager.AppSettings.Get("IsPaypal_Sandbox").ToInt();
            bool IsTestingGroup = Twee.Comm.CommUtil.IsTestingGroup(userGuid.ToString()); //如果是测试用户
            if (isSandBox == 1 || IsTestingGroup)
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
            if (isSandBox == 1 || IsTestingGroup)
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
            sbPayData.Append("<input type='hidden' name='tax_cart' value='" + tax1 + "'>");//税收  
            sbPayData.Append("<input type='hidden' name='shipping_1' value='" + shipping_cost + "'>");//运费  
            //sbPayData.Append("<input type='hidden' name='item_name' value='" + GuidNo + "'>");
            float discount_amount = tweebuck + pointMoney + sharePointMoney + userCouponAmount; //Modify by Long for Share Point Redeem
            /*
            Use discount_amount_cart to charge a single discount amount for the entire cart.

            Use discount_amount_x to set a discount amount associated with item x

            Use discount_rate_cart to charge a single discount percentage for the entire cart.
             */

            if (discount_amount > 0)
            {
                sbPayData.Append("<input type='hidden' name='discount_amount_1' value='" + discount_amount.ToString("0.00") + "'>");
                //sbPayData.Append("<input type='hidden' name='discount_amount_cart' value='" + discount_amount + "'>");
            }
            if (isSandBox == 1 || IsTestingGroup)
            {
                sbPayData.Append("<input type='hidden' name='notify_url' value='http://67.224.94.82/PayPal/notify.aspx'>");
                sbPayData.Append("<input type='hidden' name='return_url' value='http://67.224.94.82/Checkout/OrderConfirmation.aspx'>");

            }
            else
            {
                sbPayData.Append("<input type='hidden' name='notify_url' value='https://www.tweebaa.com/PayPal/notify.aspx'>");
                sbPayData.Append("<input type='hidden' name='return_url' value='https://www.tweebaa.com/Checkout/OrderConfirmation.aspx'>");

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
                sbPayData.Append("<input type='hidden' name='item_number_" + number + "' value='" + dtPay.Rows[i]["prosku"].ToString() + "'>");
            }
            sbPayData.Append("</form>");
            sbPayData.Append("<script>document.forms['paypalsubmit'].submit();</script>");
            //Comment by Long;不应该在这里删除购物车 DeletShopCartList(cartIDs);//创建订单后删除购物车
            Response.Write(sbPayData.ToString());
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
            //
            decimal sharePointMoney = dic["sharePointMoney"].ToString().ToDecimal(); ////Add by Long for Share Points Redeem
            //Add by Long 2016/01/15 for coupon redeem
            decimal userCouponAmount = dic["useCouponAmount"].ToString().ToDecimal();
            //如果用户使用Guest Checkout
            if (txt_username.Length < 2 && txt_useremail.Length < 2)
            {
                CookiesHelper cookie = new CookiesHelper();
                string keyAddress = System.Configuration.ConfigurationManager.AppSettings["cookieAddress"].ToString();
                string addressCartGudid = cookie.getCookie(keyAddress);
                if (!string.IsNullOrEmpty(addressCartGudid))
                {
                    UserAddressMgr mgr1 = new UserAddressMgr();
                    DataTable dt1 = mgr1.GetAddressByGuid(addressCartGudid);
                    txt_useremail = dt1.Rows[0]["guest_e_mail"].ToString();
                }

            }

            Twee.Model.CheckoutTmp model = new Twee.Model.CheckoutTmp();
            model.Ordernum = GuidNo;
            model.shipping_useremail = txt_useremail;
            model.Shipping_details = txt_shipping_details;
            model.Shipping_order_extra = txt_order_extra;
            model.Shipping_order_total = txt_order_total;
            model.shipping_username = txt_username;
            model.ShoppingCartID = cartIDs;

            Twee.Mgr.CheckoutTmpMgr mgr = new CheckoutTmpMgr();
            mgr.Add(model);

            int isSandBox = ConfigurationManager.AppSettings.Get("IsPaypal_Sandbox").ToInt();
            bool IsTestingGroup = Twee.Comm.CommUtil.IsTestingGroup(userGuid.ToString()); //如果是测试用户
            if (isSandBox == 1 || IsTestingGroup)
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
            if (isSandBox == 1 || IsTestingGroup)
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
            //sbPayData.Append("<input type='hidden' name='item_name' value='" + GuidNo + "'>");
            decimal discount_amount = tweebuck + pointMoney + sharePointMoney + userCouponAmount; //Modify by Long for Share Point Redeem
/*
Use discount_amount_cart to charge a single discount amount for the entire cart.

Use discount_amount_x to set a discount amount associated with item x

Use discount_rate_cart to charge a single discount percentage for the entire cart.
 */

            if (discount_amount>0)
            {
                sbPayData.Append("<input type='hidden' name='discount_amount_1' value='" + discount_amount + "'>");
                //sbPayData.Append("<input type='hidden' name='discount_amount_cart' value='" + discount_amount + "'>");
            }
            if (isSandBox == 1 || IsTestingGroup)
            {
                sbPayData.Append("<input type='hidden' name='notify_url' value='http://67.224.94.82/PayPal/notify.aspx'>");
                sbPayData.Append("<input type='hidden' name='return_url' value='http://67.224.94.82/Checkout/OrderConfirmation.aspx'>");

            }
            else
            {
                sbPayData.Append("<input type='hidden' name='notify_url' value='https://www.tweebaa.com/PayPal/notify.aspx'>");
                sbPayData.Append("<input type='hidden' name='return_url' value='https://www.tweebaa.com/Checkout/OrderConfirmation.aspx'>");

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
                sbPayData.Append("<input type='hidden' name='item_number_" + number + "' value='" + dtPay.Rows[i]["prosku"].ToString() + "'>");
            }
            sbPayData.Append("</form>");
            sbPayData.Append("<script>document.forms['paypalsubmit'].submit();</script>");
            //Comment by Long;不应该在这里删除购物车 DeletShopCartList(cartIDs);//创建订单后删除购物车
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
            string notify_url = "https://tweebaa.com/PayPal/notify.aspx";
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
        private bool AddOrder(decimal tweebuck,decimal pointMoney,decimal sharePointMoney,out string GuidNo)
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
                    orderHead.taxSum = dic["orderTax"].ToString().ToDecimal();
                    orderHead.taxGST = dic["orderTaxGST"].ToString().ToDecimal();
                    orderHead.taxHST = dic["orderTaxHST"].ToString().ToDecimal();
                    orderHead.taxQST = dic["orderTaxQST"].ToString().ToDecimal();
                    orderHead.userShopingAmount = pointMoney;
                    orderHead.useTweebuckAmount = tweebuck;
                    orderHead.useSharePointAmount = sharePointMoney;

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
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(e);
                return false;
            }

        }
        /*
         * 为了兼容老版本,增加这个函数
         */
        private bool AddOrder2(decimal tweebuck, decimal pointMoney, decimal sharePointMoney, out string GuidNo, out string strProducts)
        {
            GuidNo = "";
            try
            {
                string cartGuids =  CommHelper.GetStrDecode(dic["cartGuids"].ToString());
                if (cartGuids == "" || cartGuids == "undefined")
                {
                    CookiesHelper cookie = new CookiesHelper();
                    string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
                    cartGuids = cookie.getCookie(keyShopCart);
                  //  cookie.createCookie(keyShopCart, "", -1);
                }
                cartIDs = cartGuids;
                if (!string.IsNullOrEmpty(cartGuids))
                {
                    strProducts = cartGuids;
                    string[] ids = cartGuids.Split(',');
                    Orderhead orderHead = new Orderhead();
                    orderHead.guid = Guid.NewGuid();
                    orderHead.addressguid = dic["addressId"].ToString().ToGuid().Value;//订单收货地址guid

                    /*
                     * Fill Shipping Address to Orderhead
                     */
                    Twee.Mgr.UserAddressMgr addrMgr = new UserAddressMgr();
                    // string txtShippingAddrID = dic["ShippingAddressID"].ToString();
                    // string txtBillingAddrID = dic["BillingAddressID"].ToString();
                    if (dic["addressId"].ToString().Length < 10)
                    {
                        Twee.Comm.CommHelper.WrtLog("AddOrder2, address ID is null, why");
                    }
                    DataTable shippingAddr = addrMgr.GetAddressByGuid(dic["addressId"].ToString());
                    orderHead.ShippingFirstname = shippingAddr.Rows[0]["username"].ToString();
                    orderHead.ShippingLastname =  shippingAddr.Rows[0]["lastname"].ToString();
                    orderHead.ShippingAddress1 = shippingAddr.Rows[0]["address"].ToString();
                    orderHead.ShippingAddress2 = shippingAddr.Rows[0]["address2"].ToString();
                    orderHead.ShippingCity = shippingAddr.Rows[0]["city"].ToString();
                    orderHead.ShippingProvince = shippingAddr.Rows[0]["ProName"].ToString();
                    orderHead.ShippingCountry = shippingAddr.Rows[0]["country"].ToString();
                    string email="";
                    if(!string.IsNullOrEmpty(shippingAddr.Rows[0]["email"].ToString())){
                        email=shippingAddr.Rows[0]["email"].ToString();
                    }else{
                        email = shippingAddr.Rows[0]["guest_e_mail"].ToString();
                    }
                    orderHead.ShippingEmail = email;
                    orderHead.ShippingPhone = shippingAddr.Rows[0]["tel"].ToString();
                    orderHead.ShippingZip = shippingAddr.Rows[0]["zip"].ToString();

                    string billingAddrGuid = dic["billingaddressId"].ToString();
                    if (billingAddrGuid.Length < 10) billingAddrGuid = dic["addressId"].ToString(); //如果无效，则使用Shipping Address
                    DataTable billingAddr = addrMgr.GetAddressByGuid(billingAddrGuid);

                    orderHead.BillingFirstname = billingAddr.Rows[0]["username"].ToString();
                    orderHead.BillingLastname = billingAddr.Rows[0]["lastname"].ToString();
                    orderHead.BillingAddress1 = billingAddr.Rows[0]["address"].ToString();
                    orderHead.BillingAddress2 = billingAddr.Rows[0]["address2"].ToString();
                    orderHead.BillingCity = billingAddr.Rows[0]["city"].ToString();
                    orderHead.BillingProvince = billingAddr.Rows[0]["ProName"].ToString();
                    orderHead.BillingCountry = billingAddr.Rows[0]["country"].ToString();
                    string billing_email = "";
                    if (!string.IsNullOrEmpty(billingAddr.Rows[0]["email"].ToString()))
                    {
                        billing_email = billingAddr.Rows[0]["email"].ToString();
                    }
                    else
                    {
                        billing_email = billingAddr.Rows[0]["guest_e_mail"].ToString();
                    }
                    orderHead.BillingEmail = billing_email;
                    orderHead.BillingPhone = billingAddr.Rows[0]["phone"].ToString();
                    orderHead.BillingZip = billingAddr.Rows[0]["zip"].ToString();
                    /*
                     * Fill Billing Address to Orderhead
                     */

                    orderHead.guidno = CommUtil.CreateOrderNum();//订单编号
                    GuidNo = orderHead.guidno;
                    orderHead.messageWord = dic["message"].ToString();//订单留言
                    orderHead.userguid = userGuid == null ? Guid.Empty : userGuid.Value;//订单user
                    orderHead.wnstat = 0;//订单状态

                    orderHead.logisticscost = Decimal.Parse(dic["orderShipFee"].ToString());
                    orderHead.taxSum = dic["orderTax"].ToString().ToDecimal();
                    orderHead.taxGST = dic["orderTaxGST"].ToString().ToDecimal();
                    orderHead.taxHST = dic["orderTaxHST"].ToString().ToDecimal();
                    orderHead.taxQST = dic["orderTaxQST"].ToString().ToDecimal();


                    orderHead.userShopingAmount = pointMoney;
                    orderHead.useTweebuckAmount = tweebuck;
                    orderHead.useSharePointAmount = sharePointMoney;
                    //Add by Long 2016/01/15 for Coupon Redeem
                    orderHead.CouponAmount = dic["CouponAmount"].ToString();
                    orderHead.CouponCode = dic["CouponCode"].ToString();

                    List<OrderBody> listBody = new List<OrderBody>();
                    ShoppingcartMgr mgr = new ShoppingcartMgr();
                    PrdPriceMgr price = new PrdPriceMgr();
                    Guid? shareId = null;
                    for (int i = 0; i < ids.Length; i++)
                    {
                        string id = ids[i].ToString().Replace("'", "").Trim();
                        id = id.Replace("&#39;", "");
                        id = id.Replace("&#39;", "");
                        if (id.Length == Guid.Empty.ToString().Length)
                        {
                            Shoppingcart shoppingcart = mgr.GetModel(id.ToGuid().Value);
                            if (shoppingcart != null)
                            {
                                if (shoppingcart.shareId != null)
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
                                //Twee.Comm.CommUtil.SendDebugString("buydanjia=" + orderBody.buydanJia);
                                orderBody.shareId = shareId;//分享链接的id
                                orderBody.logisticscost = shoppingcart.shipfee;
                                orderBody.shipmethodid = shoppingcart.shipmethodid;
                                listBody.Add(orderBody);
                            }
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
                    bool b = orderMgr.AddOrder2(orderHead, listBody);
                    if (b)
                    {
                        //DeletShopCartList(cartGuids);//创建订单后删除购物车
                    }
                    return b;
                }
                else
                {
                    GuidNo = "";
                    strProducts = "";
                    return false;
                }

            }
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(e);
                strProducts = "";
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