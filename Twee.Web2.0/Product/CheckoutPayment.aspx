<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="CheckoutPayment.aspx.cs" Inherits="TweebaaWebApp2.Product.CheckoutPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">    <!-- Meta -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">


    <!-- CSS Global Compulsory -->
    <link rel="stylesheet" href="/plugins/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="/css/shop.style.css">
     
    <!-- CSS Implementing Plugins -->
    <link rel="stylesheet" href="/plugins/line-icons/line-icons.css">
    <link rel="stylesheet" href="/plugins/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="/plugins/scrollbar/src/perfect-scrollbar.css">
    <link rel="stylesheet" href="/plugins/jquery-steps/css/custom-jquery.steps.css">

   <!-- <link rel="stylesheet" href="plugins/sky-forms/version-2.0.1/css/sky-forms.css"> -->
    <link rel="stylesheet" href="/css/pages/log-reg-v3.css">  
    <!-- Style Switcher -->
    <link rel="stylesheet" href="/css/plugins/style-switcher.css">

    <!-- CSS Theme -->
    <link rel="stylesheet" href="/css/theme-colors/default.css" id="style_color">

    <!-- CSS Customization -->
    <link rel="stylesheet" href="/css/custom.css">


     <script src="../MethodJs/calculate.js" type="text/javascript"></script>
  

    <script type="text/javascript" src="/js/jquery.cookie.js"></script>
    <script type="text/javascript" src="/js/jquery.popupoverlay.js"></script>

    <script type="text/javascript" src="/js/jquery.base64.js"></script>
    <script src="/MethodJs/userAddress.js" type="text/javascript"></script>
    <script src="/MethodJs/calculate.js" type="text/javascript"></script>
    <script src="/MethodJs/ExtraShipping.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/css/mycart-new.css" />
     <script src="/js/jquery.mask.js" type="text/javascript"></script>
    <style>
        #cvv_popup
        {
            background-color:White;
            padding:20px;
        }
        #divErrorCreditCard
        {
            color:#ff0000;
            font-size:16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

           <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Checkout Payment</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="/index.aspx">Home</a></li>
                <li><a href="/Product/prdSaleAll.aspx">Product</a></li>
                <li class="active">Checkout Payment</li>
            </ul>
        </div><!--/container-->
    </div><!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->

         <!--=== Content Medium Part ===-->
    <div class="content margin-bottom-30">
                <div id="payform" style="display: none;">
    </div>
        <div class="container"> <div class="col-md-12">
        <!--  removed by Long 2016/01/18 as paymemt form can't submit
        <form class="shopping-cart" action="#" novalidate="novalidate">
        -->
 <div role="application" class="wizard clearfix" id="steps-uid-0">
<div class="steps clearfix"><ul role="tablist">
<li role="tab" class="first done" aria-disabled="false" ><a id="steps-uid-0-t-0" href="javascript:void(0)"  aria-controls="steps-uid-0-p-0"><span class="current-info audible">current step: </span><span class="number">1.</span> 
                     <div class="overflow-h">
                            <h2>Shopping Cart</h2>
                          <i class="fa fa-shopping-cart"></i>
                        </div>    
                    </a></li><li role="tab" class="done" aria-disabled="true" ><a id="steps-uid-0-t-1"  href="javascript:void(0)" aria-controls="steps-uid-0-p-1"><span class="number">2.</span> 
                     <div class="overflow-h">
                            <h2>Address</h2>
                          <i class="fa fa-map-marker"></i>
                        </div>    
                    </a></li><li role="tab" class="done" aria-disabled="true" ><a id="steps-uid-0-t-2" href="javascript:void(0)"  aria-controls="steps-uid-0-p-2"><span class="number">3.</span> 
                        <div class="overflow-h">
                        <i class="fa fa-truck"></i>
                            <h2>Confirmation</h2>
                           
                        
                        </div>    
                    </a></li><li role="tab" class="current last" aria-disabled="true" aria-selected="true"><a id="steps-uid-0-t-3" href="javascript:void(0)" aria-controls="steps-uid-0-p-3"><span class="number">4.</span> 
                        <div class="overflow-h">
                            <h2>Payment</h2>
                            <i class="fa fa-money"></i>
                        </div>    
                    </a></li></ul></div>
                
<div class="content clearfix">
 <section>
   <div class="row">
                             <!-- choose pay ment -->   
                            <div class="col-md-6 md-margin-bottom-50">
                                <h2 class="title-type">Please select a payment method</h2>
                                <!-- Accordion -->
                                <div class="accordion-v2">
                                    <div class="panel-group" id="accordion">
                                    
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">
                                                        <i class="fa fa-credit-card"></i>
                                                        Pay by Credit Card
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseOne" class="panel-collapse collapse in">
                                            <form id="frmPaybyCreditCard" action="/Checkout/OrderConfirmation.aspx" method="post">
                                                <input type="hidden" name="IsCreditCard" value="1" />
                                                <input type="hidden" id="txtGuidNO" name="txtGuidNO" value="<%=strGuidNo %>" />
                                              <input type="hidden" id="hidAddressId" name="hidAddressId" value="<%=txtShippingAddrID %>" />
                                              <input type="hidden" id="hidBillingAddressId" name="hidBillingAddressId" value="<%=txtBillingAddrID %>" />

                                                <div class="panel-body cus-form-horizontal">
                                                    <div class="form-group">
                                                        <label class="col-sm-5 no-col-space control-label">Cardholder First Name</label>
                                                        <div class="col-sm-7">
                                                            <input type="text" class="form-control required" name="cardholder_firstname" id="cardholder_firstname" placeholder="">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-sm-5 no-col-space control-label">Cardholder Last Name</label>
                                                        <div class="col-sm-7">
                                                            <input type="text" class="form-control required" name="cardholder_lastname" id="cardholder_lastname" placeholder="">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-sm-5 no-col-space control-label">Card Number</label>
                                                        <div class="col-sm-7">
                                                            <input type="text" class="form-control required creditcardnumber" name="cardnumber" id="cardnumber" onchange="ChangeCreditCardType()" placeholder="">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-sm-5 no-col-space control-label">We accept</label>
                                                        <div class="col-sm-7">
                                                            <ul class="list-inline payment-type">
                                                                
                                                                <li><i class="fa fa-cc-visa"></i></li>
                                                                <li><i class="fa fa-cc-mastercard"></i></li>
                                                                <!--
                                                                <li><i class="fa fa-cc-discover"></i></li>
                                                                <li><i class="fa fa-cc-amex"></i></li> -->
                                                            </ul>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-sm-5">Expiration Date</label>
                                                        <div class="col-sm-7 input-small-field">
                                                            <input type="text" name="mm" style="width:60px;display: inline;" id="expire_mm" maxlength="2" placeholder="MM" class="form-control required sm-margin-bottom-20">
                                                           <span class="slash">/</span>
                                                           <input type="text" name="yy" style="width:60px;display: inline;" id="expire_yy" maxlength="2" placeholder="YY" class="form-control required">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-sm-5 no-col-space control-label">CSC</label>
                                                        <div class="col-sm-7 input-small-field">
                                                            <input type="text" name="number" id="number_csc" maxlength="4" placeholder="" class="form-control required">
                                                            <a href="#" class="cvv_popup_open">What's this?</a>
                                                        </div>
                                                    </div>
                                                    <div class="form-group" id="divErrorCreditCard">
                                                    </div>
                                                    <div class="form-group">
                                               
                                                      <button class="btn-u btn-u-lg rounded btn-u-blue fr" type="button" onclick="DoCreditCardPay()">Submit Order</button>
                                                    </div>
                                                </div>
                                                </form>
                                            </div>
                                        </div> 
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                                                        <i class="fa fa-paypal"></i>
                                                        Pay by PayPal
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseTwo" class="panel-collapse collapse in">
                                                <div class="form-group" id="divErrorPaypal">
                                                 </div>
                                                <div class="content margin-left-10" style="padding-left:14px;padding-bottom:20px;margin-top:-15px;">
                                                    <a href="#"  onclick="DoPaypalPayment()"><img src="/images/PP_logo_h_150x38.png" alt="PayPal"></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- End Accordion -->    
                            </div>
                <div class="col-md-6">
                                <h2 class="title-type">FAQ</h2>
                                <!-- Accordion -->
                                <div class="accordion-v2 plus-toggle">
                                    <div class="panel-group" id="accordion-v2">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion-v2" href="#collapseOne-v2">
                                                        What payments methods can I use?
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseOne-v2" class="panel-collapse collapse in">
                                                <div class="panel-body">
                                                  <!-- Tweebaa accepts most major credit cards including Mastercard, Visa.   If you prefer, you may pay with an existing PayPal account.  Tweebaa does NOT store any of your credit-card information.-->
                                                  Tweebaa accepts Mastercard, Visa and existing PayPal accounts as forms of payment. Tweebaa does NOT store any of your credit card information.
                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion-v2" href="#collapseTwo-v2">
                                                   What types of discounts are available?
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseTwo-v2" class="panel-collapse collapse">
                                                <div class="panel-body">
   It pays to become a Tweebaa member.  Members can accumulate commissions and points, which can be redeemed for merchandise discounts.<br><br>
 <span class="text-border text-border-red">➢	Shopping Reward Points </span>- Members earn Shopping Reward Points with every purchase.  They can be redeemed at checkout (400 points = $5.00).<br>  <br>  
 <span class="text-border text-border-red">➢	TweeBucks </span> – Members earn TweeBucks commissions by suggesting, evaluating or sharing Tweebaa products.  TweeBucks can be redeemed for cash; or they can be applied just like cash at checkout.<br><br>  
 <span class="text-border text-border-red">➢	Share Reward Points </span> – Members earn Share Points by taking part in Tweebaa activities, like sharing products and playing games on Tweebaa APP.  They have a redemption value of $0.01 per point (ex:  1,000 Share points = $10.00 discount).

                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion-v2" href="#collapseThree-v2">
                                                   What are the shipping rates?
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseThree-v2" class="panel-collapse collapse">
                                                <div class="panel-body">
                                     Select Tweebaa items have FREE SHIPPING (you may select expedited shipping for additional fee).  For items which do not have FREE SHIPPING, please refer to the following ship rate table:
             
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th>Merchandise Total (USD)<br>
<em style="font-size:10px;">Excluding “Free Shipping” items</em>
</th>
                                        <th>Standard Shipping Charge</th>
                                     
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Up to $15.00</td>
                                        <td>$5.50</td>
                                 
                                    </tr>
                                    <tr>
                                        <td>$15.01 – $25.00</td>
                                        <td>$6.50</td>
                                   
                                    </tr>
                                    <tr>
                                        <td>$25.01 – $35.00</td>
                                        <td>$7.50</td>
                            
                                    </tr>
                                    <tr>
                                        <td>$45.01 – $55.00</td>
                                        <td>$10.50</td>
                                       
                                    </tr>
                                    
                                       <tr>
                                        <td>$55.01 – $75.00</td>
                                        <td>$11.50</td>
                                       
                                    </tr>
                                 <tr>
                                        <td>$75.01 – $100.00</td>
                                        <td>$13.50</td>
                                       
                                    </tr>
                                   <tr>
                                        <td>$100.01 – $150.00</td>
                                        <td>$16.50</td>
                                    </tr>   
                                          <tr>
                                        <td>$150.00 and over</td>
                                        <td>add 12% of merchandise total</td>
                                    </tr>     
                                </tbody>
                            </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion-v2" href="#collapseFour-v2">
                                                        How long will it take to get my order?
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseFour-v2" class="panel-collapse collapse">
                                                <div class="panel-body">
                                  <span class="text-border text-border-red">“Test-Sale” items </span> – if you ordered a “Test-Sale” item, please expect longer lead-times.  Test-Sale items are brand-new to the Tweebaa shop, and have 60 days to meet a pre-set sales quota.  If that quota is met within 60 days, all the Test Sale orders are “ON”.  If the quota is NOT met, you will receive a FULL REFUND of the Test Sale purchase.
                                  <br>
            <span class="text-border text-border-red">“Buy Now” items</span> – these items typically ship out within 24 hours; allow up to 10 days for shipping. 
                                                </div>
                                            </div>
                                        </div> 
                                                      <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion-v3" href="#collapseFour-v3">
                                                   Return policy.
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseFour-v3" class="panel-collapse collapse">
                                                <div class="panel-body">
                                 Tweebaa offers customers a thirty-day satisfaction guarantee. If you are unhappy with your Tweebaa purchase for any reason, you can return it for a full refund.  
                                                </div>
                                            </div>
                                        </div>             
                                    </div>
                                </div>
                                <!-- End Accordion -->    
                            </div>          

                        </div>
   </section>
</div> 
</div>
<!--
</form>
-->
</div>

</div>

</div>


<script type="text/javascript">
    function ChangeCreditCardType() {


    }
    function CheckIsValidVisaMasterCard(cardnumber) {
    /*
   {
        name: 'visa',
        pattern: /^4/,
        valid_length: [16]
      }, {
        name: 'mastercard',
        pattern: /^5[1-5]/,
        valid_length: [16]
      }, 
    */
            if(cardnumber.length <16){
                return false;
            }
             var visa = /^4/;
             var mastercard = /^5[1-5]/;

             if (visa.test(cardnumber) == false && mastercard.test(cardnumber) == false) {
                 return false;
             }
             return true;

        }
        function DoCreditCardPay() {
        

        var orderNo = $("#txtGuidNO").val();
        var txtcardholder_firstname = $("#cardholder_firstname").val();
        var txtcardholder_lastname = $("#cardholder_lastname").val();
        var txtcardnumber = $("#cardnumber").val();
        if(!CheckIsValidVisaMasterCard(txtcardnumber)){
            AlertEx("Invalid Visa Or MasterCard");
            return false;
        }
        var txtexpire_mm = $("#expire_mm").val();
        var txtexpire_yy = $("#expire_yy").val();
        var txtCSC = $("#number_csc").val();

        //check data input first
        if (txtcardholder_firstname.length < 2) {
        $("#divErrorCreditCard").html("Please input First name");
        $("#cardholder_firstname").focus();
        // $("#cardholder_firstname").val("Please input First name");
        return;
        }
        if (txtcardholder_lastname.length < 2) {
        $("#divErrorCreditCard").html("Please input Last name");
        $("#cardholder_lastname").focus();
        return;
        }
        if (txtcardnumber.length < 12) {
        $("#divErrorCreditCard").html("Please input Card Number");
        $("#cardnumber").focus();
        return;
        }
        if (txtexpire_mm.length < 2) {
        $("#divErrorCreditCard").html("Please input two digital month");
        $("#expire_mm").focus();
        return;
        }
        if (parseInt(txtexpire_mm) > 12 || parseInt(txtexpire_mm) <= 0) {
        $("#divErrorCreditCard").html("Invalid Month");
        $("#expire_mm").focus();
        return;

        }
        if (txtexpire_yy.length < 2) {
        $("#divErrorCreditCard").html("Please input two digital year");
        $("#expire_yy").focus();
        return;
        }
        /*
        if (txtexpire_yy.length < 2) {
        $("#divErrorCreditCard").html("Please input two digital year");
        return;
        }*/
        if (txtCSC.length < 3) {
            $("#divErrorCreditCard").html("Please input CSC number");
            $("#number_csc").focus();
            return;
        }
        Loading(true);
        var txtShippingAddrID = $("#hidAddressId").val();
        var txtBillingAddrID = $("#hidBillingAddressId").val();

        //check OrderNo valide ??
        if (orderNo.length == 12) {
            var _data = "{ action:'DoCreditCardPayment"
                + "',guidno:'" + orderNo
                + "',cardholder_firstname:'" + txtcardholder_firstname
                + "',cardholder_lastname:'" + txtcardholder_lastname
                + "',cardnumber:'" + txtcardnumber
                + "',expire_mm:'" + txtexpire_mm
                + "',expire_yy:'" + txtexpire_yy
                + "',csc:'" + number_csc
                + "',ShippingAddressID:'" + txtShippingAddrID
                + "',BillingAddressID:'" + txtBillingAddrID
                + "'}";
            $.ajax({
                type: "POST",
                url: '/AjaxPages/payMoneyPaypalAjax.aspx',
                data: _data,
                success: function (result) {
                    var p = result.split("|");
                    var resu = p[0];
                    if (resu == "-1") {
                        $("#divErrorCreditCard").html("Do Payment Error -1");
                        Loading(false);
                        return;
                    } else if (resu == "-2") {
                        $("#divErrorCreditCard").html("Invalid Order Number");
                        Loading(false);
                        return;
                    } else if (resu == "-3") {
                        $("#divErrorCreditCard").html("Do Payment Error -3");
                        Loading(false);
                        return;
                    }
                    else if (resu == "") {
                        $("#divErrorCreditCard").html("Do Payment Error return null?");
                        Loading(false);
                        return;
                    }
                    else if (resu != "") {
                        //window.location.href="/Product/CheckoutPayment.aspx
                        //$("#payform").append(resu);
                        var code = parseInt(resu);
                        if (code < 50) {
                            $("#frmPaybyCreditCard").submit();
                        } else {
                            $("#divErrorCreditCard").html("Payment Error! " + p[1]);
                            Loading(false);
                        }
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $("#divErrorCreditCard").html("Do Payment Error: msg= " + thrownError);
                    Loading(false);
                }
            });
        } else {
            $("#divErrorCreditCard").html("Invalid Order Number");
            Loading(false);
        }
    }

    function DoPaypalPayment() {
        Loading(true);
        var orderNo = $("#txtGuidNO").val();
        //check OrderNo valide ??
        if (orderNo.length == 12) {
            var _data = "{ action:'DoPaypalPayment"
                + "',guidno:'" + orderNo
                + "'}";
            $.ajax({
                type: "POST",
                url: '/AjaxPages/payMoneyPaypalAjax.aspx',
                data: _data,
                success: function (resu) {
                    if (resu == "-1") {
                        $("#divErrorPaypal").html("Do Payment Error");
                        Loading(false);
                        return;
                    }
                    else if (resu == "") {
                        $("#divErrorPaypal").html("Do Payment Error");
                        Loading(false);
                        return;
                    }
                    else if (resu != "") {
                        //window.location.href="/Product/CheckoutPayment.aspx
                        $("#payform").append(resu);
                        
                    }
                },
                error: function (msg) {
                    $("#divErrorPaypal").html("Do Payment Error");
                    Loading(false);
                }
            });
        } else {
            $("#divErrorPaypal").html("Invalid Order Number");
            Loading(false);
        }
    }


    //保存hidBillingAddressId到Cookie里
    $(document).ready(function () {
        //console.log("ready!");
        $.cookie("guidno", "<%=strGuidNo %>", { expires: 1 });
        $.cookie("hidAddressId", "<%=txtShippingAddrID %>", { expires: 1 });
        $.cookie("hidBillingAddressId", "<%=txtBillingAddrID %>", { expires: 1 });

        // Initialize the plugin
        $('#cvv_popup').popup();

        $('.creditcardnumber').mask('0000000000000000');
        $('#expire_mm').mask('00');
        $('#expire_yy').mask('00');
        $('#number_csc').mask('0000');
    });
</script>

<!-- Add content to the popup -->
  <div id="cvv_popup">
      <div>
        <img src="/images/cvv.gif" />
    </div>
    <div style="padding-top:20px;text-align:center;" >
        <!-- Add an optional button to close the popup -->
        <button class="cvv_popup_close">Close</button>
    </div>

  </div>

</asp:Content>
