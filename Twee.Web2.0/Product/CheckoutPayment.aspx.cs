using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp2.Product
{
    public partial class CheckoutPayment : System.Web.UI.Page
    {
        public string strGuidNo;
        public string txtShippingAddrID;
        public string txtBillingAddrID;

        protected void Page_Load(object sender, EventArgs e)
        {
/*
   var orderBody = ""; //订单描述
    var orderWebUrl = "https://www.tweebaa.com";
    var orderShipFee = $("#lablogistics2").text();  // total shipping fee
    var orderTax = $("#labTax").text();             // total tax
    var orderTaxGST = $("#labTaxGST").text();
    var orderTaxHST = $("#labTaxHST").text();
    var orderTaxQST = $("#labTaxQST").text();

    var txtUsername = $("#userName").text();
    var txtEmail = $("#labEmail").text();
    var txtShipping = $("#labAddress").html().replace("<br>"," ") + " , " + $("#labCountry").text()+" "+$("#labZip").text();  
    var txtOrderExtra = Base64.encode($("#extra_info_table").html());
    var txtOderDetails = Base64.encode($("#tableOrder").html());

    var _data = "{ action:'pay"
                + "',guidno:'" + orderNo
                + "',orderName:'" + orderName
                + "',quantity:'" + quantity
                + "',orderMoney:'" + orderMoney
                + "',tweebuck:'" + $("#txtTweebuck").val()
                + "',pointMoney:'" + $("#txtPointMoney").val()
                + "',sharePointMoney:'" + sharePointMoney //Add by Long for Share Points Redeem
                + "',orderShipFee:'" + orderShipFee
                + "',orderTax:'" + orderTax
                + "',orderTaxGST:'" + orderTaxGST
                + "',orderTaxHST:'" + orderTaxHST
                + "',orderTaxQST:'" + orderTaxQST
                + "',tax_cart:'" + $("#labTax").text()
                + "',cartGuids:'" + cartids
                + "',message:'" + $("#txtMessage").val()
                + "',addressId:'" + $("#hidAddressId").val()
                + "',checkout_username:'" + txtUsername
                + "',checkout_useremail:'" + txtEmail
                + "',checkout_shipping_details:'" + txtShipping
                + "',checkout_order_extra:'" + txtOrderExtra
                + "',checkout_order_total:'" + txtOderDetails
                //+"',discount_amount:'" + discount_amount;
                +"'}";


    $.ajax({
        type: "POST",
        url: '../AjaxPages/payMoneyPaypalAjax.aspx',
        data: _data,
        success: function (resu) {
            if (resu == "-1") {               
                return;
            }
            else if (resu == "") {               
                return;
            }
            else if (resu != "") {
                $("#payform").append(resu);
            }
        },
        error: function (msg) {
        }
    });
*/

            try
            {
                if (Request.Form.AllKeys.Contains("guidno"))
                {
                    strGuidNo = Request.Form["guidno"].ToString();
                }
                else
                {
                    //get it from cookie?
                    if (Request.Cookies["guidno"] != null)
                    {
                        strGuidNo = Request.Cookies["guidno"].Value;

                    }
                }
                if (Request.Form.AllKeys.Contains("hidAddressId"))
                {
                    txtShippingAddrID = Request.Form["hidAddressId"].ToString();
                }
                else
                {
                    //get it from cookie?
                    if (Request.Cookies["hidAddressId"] != null)
                    {
                        txtShippingAddrID = Request.Cookies["hidAddressId"].Value;

                    }
                }
                if (Request.Form.AllKeys.Contains("hidBillingAddressId"))
                {
                    txtBillingAddrID = Request.Form["hidBillingAddressId"].ToString();
                }
                else
                {
                    //get it from cookie?
                    if (Request.Cookies["hidBillingAddressId"] != null)
                    {
                        txtBillingAddrID = Request.Cookies["hidBillingAddressId"].Value;

                    }
                }

            }
            catch (Exception ee)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(ee);
            }
        }
    }
}