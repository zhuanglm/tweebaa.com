﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="CheckoutConfirmation.aspx.cs" Inherits="TweebaaWebApp2.Product.CheckoutConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">


    

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
    <script src="../MethodJs/buy.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.cookie.js"></script>
    <script type="text/javascript" src="/js/jquery.base64.js"></script>
    <!--
    <script src="/MethodJs/userAddress.js" type="text/javascript"></script>
    -->
    <script src="/MethodJs/calculate.js" type="text/javascript"></script>
    <script src="/MethodJs/order.js?v=20151214" type="text/javascript"></script>
    <script src="/MethodJs/ExtraShipping.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/css/mycart-new.css" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">


           <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Checkout Confirmation</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="/index.aspx">Home</a></li>
                <li><a href="/Product/prdSaleAll.aspx">Product</a></li>
                <li class="active">Checkout Confirmation</li>
            </ul>
        </div><!--/container-->
    </div><!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->

         <!--=== Content Medium Part ===-->
    <div class="content margin-bottom-30">
        <div class="container"> <div class="col-md-12">
<!-- comments by Long: why Snow add this ? 2016/01/04
         <form class="shopping-cart" action="#" novalidate="novalidate">
         -->
 <div role="application" class="wizard clearfix" id="steps-uid-0">
<div class="steps clearfix"><ul role="tablist">
<li role="tab" class="first done" aria-disabled="false" ><a id="steps-uid-0-t-0" href="javascript:void(0)"  aria-controls="steps-uid-0-p-0"><span class="current-info audible">current step: </span><span class="number">1.</span> 
                     <div class="overflow-h">
                            <h2>Shopping Cart</h2>
                          <i class="fa fa-shopping-cart"></i>
                        </div>    
                    </a></li><li role="tab" class="done" aria-disabled="true" ><a id="steps-uid-0-t-1" href="javascript:void(0)"  aria-controls="steps-uid-0-p-1"><span class="number">2.</span> 
                     <div class="overflow-h">
                            <h2>Address</h2>
                          <i class="fa fa-map-marker"></i>
                        </div>    
                    </a></li><li role="tab" class="current" aria-disabled="true" aria-selected="true"><a id="steps-uid-0-t-2" href="javascript:void(0)"  aria-controls="steps-uid-0-p-2"><span class="number">3.</span> 
                        <div class="overflow-h">
                        <i class="fa fa-truck"></i>
                            <h2>Confirmation</h2>
                           
                        
                        </div>    
                    </a></li><li role="tab" class="disabled last" aria-disabled="true"><a id="steps-uid-0-t-3" href="javascript:void(0)"  aria-controls="steps-uid-0-p-3"><span class="number">4.</span> 
                        <div class="overflow-h">
                            <h2>Payment</h2>
                            <i class="fa fa-money"></i>
                        </div>    
                    </a></li></ul></div>
<div class="content clearfix">
 <div style="padding:20px 0px;">
                      
              

                     <section>
                     <div class="row">
                     <div class="col-md-6">

                     <div class="tag-box tag-box-v2 margin-bottom-40">
                            <h2>Shipping Address:  </h2>
 <table width="100%"><tr><td width="60%">   
                   
<div class="saved-address" >
                <section class="billing-info">
                      <p id="pAddress">

                <label id="labName"><%=labShippingName%>
                </label>
                <br />
                <label id="labAddress"><%=labShippingAddress %>
                </label>
                <br />
                <label id="labCountry"><%=labShippingCountry%>
                </label>
                <br />
                <label id="labCountryID" style="display: none"><%=labShippingCountryID %></label>
                <label id="labProvinceID" style="display: none"><%=labShippingProvinceID %></label>
                Zip: <label id="labZip"><%=labShippingZip %></label>
                <br />
                Phone: <label id="labPhone"><%=labShippingPhone %></label>
                <br />
                Email: <label id="labEmail"><%=labShippingEmail %></label>
		      <br />
           <input type="button" class="btn-u btn-u-sm rounded margin-top-20" value="Change Address" class="send" onclick="window.location.href='/Product/CheckoutShipping.aspx?action=change'" />

            </p>

            
            <script type="text/javascript">
                function change() {
                    $(".saved-address").hide();
                    $(".shop-address").show();
                }

            
            </script>
            
                </section>
                
                </div>

</td></tr></table>                    
                        
                        </div>
                      </div>
                       <div class="col-md-6">
                          <div class="tag-box tag-box-v2 margin-bottom-40" id="divBillingAddr">
                            <h2>Billing Address:</h2>
     
                   
<div class="saved-address" >
                <section class="billing-info">
                       <p id="pBillingAddress">

                <label id="labBillingName"><%=labBillingName%>
                </label>
                <br />
                <label id="labBillingAddress"><%=labBillingAddress%>
                </label>
                <br />
                <label id="labBillingCountry"><%=labBillingCountry%>
                </label>
                <br />
                <label id="labBillingCountryID" style="display: none"><%=labBillingCountryID%></label>
                <label id="labBillingProvinceID" style="display: none"><%=labBillingProvinceID%></label>
                Zip: <label id="labBillingZip"><%=labBillingZip%></label>
                <br />
                Phone: <label id="labBillingPhone"><%=labBillingPhone %></label>
                <br />
                Email: <label id="labBillingEmail"><%=labBillingEmail%></label>

              <div style="height:47px;">&nbsp;</div>
            </p>
            <!--
            <input type="button" value="Change" class="send" onclick="change()" />
            -->
            <script type="text/javascript">
                function change() {
                    $(".saved-address").hide();
                    $(".shop-address").show();
                }

            
            </script>
            
                </section>
                
                </div>
                        </div>
                      </div>
                     </div>
             
                      <form class="shopping-cart" id="frmConfirm" action="/Product/CheckoutPayment.aspx" method="post">
              <input type="hidden" id="hidAddressId" name="hidAddressId" value="<%=txtShippingAddrID %>" />
              <input type="hidden" id="hidBillingAddressId" name="hidBillingAddressId" value="<%=txtBillingAddrID %>" />
              <input type="hidden" id="hidCouponAmount" name ="hidCouponAmount" value="0" />

                        <div class="font-xs">

                <section>
		         <div class="row">
                    <div class="table-responsive col-md-12">
                            <table class="table table-striped">
                                <thead>
                                   <tr>
                                   <th class="pro-infor">Product</th>
                                   <th>Quantity</th>
                                   <th style="display:none">Shipping Fee</th>
                                   <th>Unit Price</th>
                                   <th>Shipping Method</th>
                                   
                                   <th >Sub-Total</th>

                                   <th style="display:none">Shipping Partner</th>
                                   </tr>
                                </thead>
                                <tbody id="tableOrder">
                                                  
                                </tbody>
                            </table>
				      <div  class="fr margin-bottom-45">

                        <button onclick="window.location.href='/Product/ShoppingCart.aspx';return false;" class="btn-u btn-u-sm rounded-4x">Update Shopping Cart</button> </div>
                        </div>
				</div>

                      
<!--
||||||| .r4363
                        <button onclick="window.location.href='/Product/ShoppingCart.aspx';return false;" class="btn-u btn-u-lg btn-u-shop rounded">Change Shopping Cart</button>
=======
                        <button onclick="window.location.href='/Product/ShoppingCart.aspx';return false;" class="btn-u btn-u-lg btn-u-white rounded">Change Shopping Cart</button>
>>>>>>> .r4368
-->
                       

                        <div style="padding:20px 0px;display:none">
                         <textarea  class="form-control" id="txtMessage" name="txtMessage"></textarea>
                        </div>
                </section>


                            <div class="row">
                            <div class="col-sm-4" id="extra_info_table">
<div class="accordion-v2">
                                    <div class="panel-group" id="accordion">
                                    
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">
                                                         <span style="color:Blue">Shopping Reward Points</span>
                                <p>Avallable <label id="labPoint">
                                                        <%=_shoppingPoint%></label> points. Redemption Value: $<label id="labPointMoney"><%=_shoppingPointMoney %></label></p>
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseOne" class="panel-collapse collapse">
                        <div class="cartMiniTable sm-margin-bottom-30">
                               
                                       <div class="input-group">
                                    <input type="text" class="form-control" id="txtPointMoney" onchange="ApplyShoppingPoint()" placeholder="Redemption Value: $0.00">
                                    <span class="input-group-btn">
                                        <button class="btn btn-danger" type="button" onclick="ApplyAllPoint()">Apply All</button>
                                    </span>
                            </div>
                        </div>                                           
                                            </div>
                                        </div> 
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                                                  
                                                            <span style="color:Blue">Tweebucks</span>
                                <p>Current Balance $<label id="labTweebucks" style="margin-left: 1px"><%=_extractionTweebuck %></label></p>
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseTwo" class="panel-collapse collapse">
                                   <!--Shopping Reward-->
                            <div class="cartMiniTable sm-margin-bottom-30">
                           
                                       <div class="input-group">
                                    <input type="text" class="form-control" id="txtTweebuck" onchange="ApplyTweebuck()"  placeholder="Redemption Value: $0.00">
                                    <span class="input-group-btn">
                                        <button class="btn btn-danger"onclick="ApplyAllTweebuck()"  type="button">Apply All</button>
                                    </span>
                            </div>
                            </div> <!--End Shopping Reward-->  
                                            </div>
                                        </div>

                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree">
                                                    
 <span style="color:Blue">Share Reward Points</span>
                                <p>Avallable <label id="labSharePoints">
                                                        <%=_sharePoint%></label> points. Redemption Value: $<label id="labSharePointsMoney"><%=_sharePointMoney%></label></p>
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseThree" class="panel-collapse collapse">
                                            <div class="cartMiniTable margin-bottom-30">
                               
                                                        <p style="color:#ff0000;">You can redeem Share points for discount! (up to 15% of total purchase amount)</p>
                                       <div class="input-group">
                                    <input type="text" class="form-control" id="txtSharePointMoney" onchange="ApplySharePoint()" placeholder="Redemption Value: $0.00">
                                    <span class="input-group-btn">
                                        <button class="btn btn-danger" onclick="ApplyAllSharePoint()" type="button">Apply All</button>
                                    </span>
                            </div>
                            </div> <!--End Shopping Reward-->
                                            </div>
                                        </div>

                                        <div class="panel panel-default">
                                        <div class="row" style="padding:10px;">
                                        <div class="col-sm-5">PROMO CODE</div>
                                        <div class="col-sm-6"><input type="text" id="txtPromoCode" onchange="CheckCouponCode()" /></div>
                                        </div>
                                        </div>
                                    </div>
                                </div>



                   


                            
     
                            
                            

                        </div>
                        <div class="col-sm-4">
                   <div style="display:none" id="divTestSaleAgreement">
                                       <h6>

Test-Sale Products have a test period of up to 60 days to reach a target sales number, and delivery may take up to 90 days total. 
<br /> If you order an item that does NOT reach the target, your order for that item will be cancelled and you will receive 100% refund. 
<br /> In the meantime, you can cancel any Test-Sale order up until the day we actually ship.
 <br />
Please click this box to acknowledge the Test-Sale lead time</h6><br />
                            <label>
                                <input type="checkbox" id="Acknowledged" style="vertical-align: middle; position: relative;  width:20px;
    height:20px;
    background:white;
    border-radius:5px;
    border:2px solid #555;
                                    top: -2px;" /> Acknowledged
                            </label>
 <br />

</div> 
                                     
                                     
                                </div>

                        <div class="col-sm-4">                        <!--Order Summery-->
                                 <div class="cartMiniTable">
                               <!--  <h3>Summery</h3>-->  
                <table id="cart-summary" class="table">
                    
                     <tbody>
                    <tr>
                        <td class="tdl">Sub-Total:</td>
                        <td class="price tdr">$<label id="labPrdMoney"></label></td>
                    </tr>
                    <tr>
                        <td class="tdl">Shipping:</td>
                        <td class="price tdr">$<label id="lablogistics2">0.00</label></td>
                    </tr>
                
                    <tr id="trTax">
                        <td class="tdl">Tax&nbsp;<label id="labTaxRate" style="display:none;">
                                            0%</label>:</td>
                        <td class="price tdr" id="total-tax">$<label id="labTax">0.00</label></td>
                    </tr>

                    <tr id="trTaxGST">
                        <td class="tdl">GST&nbsp;<label id="labTaxGSTRate" style="display:none;">
                                            0%</label>:</td>
                        <td class="price tdr" id="Td1">$<label id="labTaxGST">0.00</label></td>
                    </tr>
                    <tr id="trTaxHST">
                        <td class="tdl">HST&nbsp;<label id="labTaxHSTRate" style="display:none;">
                                            0%</label>:</td>
                        <td class="price tdr" id="Td2">$<label id="labTaxHST">0.00</label></td>
                    </tr>
                    <tr id="trTaxQST">
                        <td class="tdl">QST&nbsp;<label id="labTaxQSTRate" style="display:none;">
                                            0%</label>:</td>
                        <td class="price tdr" id="Td3">$<label id="labTaxQST">0.00</label></td>
                    </tr>
                    <tr>
                        <td class="tdn tdl"> Discount:</td>
                        <td class=" tdn tdr" id="Td4">$<label id="labDiscount">0.00</label></td>
                    </tr>
                    <tr>
                        <td class="tdn tdl"> Total:</td>
                        <td class="tdn tdr shop-black " id="total-price">$<label id="labPayMoney2"></label></td>
                    </tr>
                    </tbody>
                  
                </table>
                
                  
            </div>
            
 <div class="pull-right margin-bottom-30 col-md-12 ">

 <input type="hidden" id="guidno" name="guidno" />
 <button type="button" class="btn-u btn-u-orange btn-u-lg rounded-4x mrzero" onclick="OrderConfirm()" >
                                            Confirm and Proceed to Payment</button>
</div>
<hr />
<div class="txt-right margin-bottom-30"><h6>By clicking the “Confirm and Proceed to Payment” button, 
you are  placing a live order and agreeing to the Tweebaa Policies
and  <a href="/college/Arbitration_agreement.aspx">Arbitration Agreement. </a></h6></div>
            
            </div>
 </div>

            
</form>
                      </section>   
                <!--pay ment -->       
                  
<form id="frmVirtualPay" action="/Checkout/OrderConfirmation.aspx" method="post">
<input type="hidden" id="hidIsVirtualPay" name="hidIsVirtualPay" value="0" />
<input type="hidden" id="hidSerialNo" name="hidSerialNo" />
<input type="hidden" id="hidGuidNo" name="hidGuidNo" />
</form>
                   
                </div>
</div>           
  </div>           
 <!-- comments by Long: why Snow add this ? 2016/01/04               
</form>
-->
    </div>  
    
    
      </div><!--/end container-->
    </div>
    <!--=== End Content Medium Part ===-->     


<script type="text/javascript" src="/plugins/sky-forms/version-2.0.1/js/jquery.validate.min.js"></script>
<!-- Master Slider -->
<script type="text/javascript" src="/plugins/master-slider/quick-start/masterslider/masterslider.min.js"></script>
<script src="/plugins/master-slider/quick-start/masterslider/jquery.easing.min.js"></script>
<!-- Scrollbar -->
<script src="/plugins/scrollbar/src/jquery.mousewheel.js"></script>
<script src="/plugins/scrollbar/src/perfect-scrollbar.js"></script>
<script src="/plugins/jquery.parallax.js"></script>

<!-- JS Customization -->
<script src="/js/custom.js"></script>
<!-- JS Page Level -->
<script src="/js/shop.app.js"></script>

<script src="/js/forms/product-quantity.js"></script>
<script type="text/javascript" src="/js/plugins/style-switcher.js"></script>
<script>
    jQuery(document).ready(function () {
        App.init();
        StyleSwitcher.initStyleSwitcher();

    });

    function OrderConfirm() {
        ///DO Validation
        Loading(true);
        var iVerify = 0;
        var CustomShippingFee = 0;
        var iShipCountryID = $("#labCountryID").html();
        for (i = 0; i < iTotalProduct; i++) {
            var _data = "{ action:'" + "check_shipping_country_ex2" + "',CountryId:'" + iShipCountryID + "',proId:'" + products_in_cart[i] + "',RulesID:'" + rulesID_in_cart[i] + "',prosku:'" + sku_in_cart[i] + "'}";
            $.ajax({
                type: "POST",
                url: '/AjaxPages/shopCartAjax.aspx',
                data: _data,
                async: false,
                success: function (msg) {
                    if (msg == -1) {
                        //how to get user id
                        ExtraShippingHandleEx(products_in_cart[i], sku_in_cart[i], products_name_in_cart[i]);
                        //alert("Your cart contains item(s) that are not currently available for shipment to your country.\n Product name: " + products_in_cart[i] + " \n Please remove these item(s) from your cart in order to proceed. You may contact us at service@tweebaa.com for a shipping quote (on the item/s removed) to your destination.");
                        iVerify = 1;
                        // EnableGotoPayButton();
                        
                        return;
                    } else if (msg == -2) {

                        ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com", "This item has shipping country limited.\n  Please setup your shipping address first.");
                        window.location.href = "/Home/HomeAddress.aspx";
                        iVerify = 1;
                        return;
                    }
                    // CustomShippingFee = msg;

                },
                error: function (msg) {
                    //alert("Delete failed");
                }
            });
        }
        if (iVerify == 1) {
            Loading(false);
            return;
        }
        ////////////////////////Add by Long to verify Shipping Country EOF


        var addressId = $("#hidAddressId").val();
        if (addressId == "" || addressId == null) {
            ShowPopupDialogMessage("Delivery address","Please fill and save your delivery address！");
            Loading(false);
            return;
        }
        if (document.getElementById("Acknowledged").checked == false) {
            ShowPopupDialogMessage("Acknowledged","Please Acknowledge the reminder ！");
            Loading(false);
            return;
        }
        var pointMoney = $("#txtPointMoney").val();
        var tweebucks = $("#txtTweebuck").val();



        //产品金额
        var orderTotal = parseFloat($("#labPrdMoney").text()); // parseFloat($("#labPayMoney2").text());   
        var sumTweebucks = parseFloat($("#labTweebucks").text());
        var sumPointMoney = parseFloat($("#labPointMoney").text());
        //alert(pointMoney); alert(sumPointMoney); alert(orderTotal);
        if (pointMoney >= orderTotal || pointMoney > sumPointMoney) {
            ShowPopupDialogMessage("Invalid Shopping Points","Your input amount of shopping points is invalid, cannot be larger than or equal to the total amount or redemption value.");
            Loading(false);
            return;
        }
        if (tweebucks >= orderTotal || tweebucks > sumTweebucks) {
            ShowPopupDialogMessage("Invalid tweebuck","Your input tweebucks amount is invalid, cannot be larger than  or equal to the total amount or total tweebucks.");
            Loading(false);
            return;
        }

        ////Add by Long for Share Points Redeem
        var sharePointMoney = $("#txtSharePointMoney").val();
        var sumSharePoint = parseFloat($("#labSharePointsMoney").text());
        if (sharePointMoney >= orderTotal || sharePointMoney > sumSharePoint) {
            ShowPopupDialogMessage("Invalid Share Point","Your input Share Point amount is invalid, cannot be larger than  or equal to the total amount or total Share Points.");
            Loading(false);
            return;
        }
        ////Add by Long for Share Points Redeem EOF
        // $("#frmConfirm").submit();
        CreateOrderBeforePayment();

    }
</script>
<!--[if lt IE 9]>
    <script src="plugins/respond.js"></script>
    <script src="plugins/html5shiv.js"></script>
    <script src="js/plugins/placeholder-IE-fixes.js"></script>
<![endif]-->

<script type="text/javascript">


    function SaveDeliveryAddress() {
        var guid = $("#hidAddressId").val();
        if (guid == null || guid == "") {
            AddShipAddress();
        }
        else {
            UpdateShipAddress(guid);
        }

    }


    $(".show-all-address").find("li").mouseenter(function (event) {
        $(this).addClass('on')
    }).mouseleave(function (event) {
        $(this).removeClass('on')
    });

    //物流选择 
    $(".select-wuliu .showUl").click(function (event) {
        $(this).siblings('ul').show();
    });

    $(".select-wuliu").mouseleave(function (event) {
        $(this).find("ul").hide();
    });

    function EnableGotoPayButton() {
        $(".gotoPay").html("Agree & Proceed to Payment &nbsp;&nbsp;");
        $(".gotoPay").removeAttr("disabled");
        $("#btnCheckout").removeClass("btnDisabled");
    }



    //增加地址
    $(".add-new-address > a").click(function (event) {
        $(".greybox,.add-new-address-box").show();
        $(".add-new-address-box").find('h2').text("Add delivery address")
        $("#btnSave").unbind("click")
        $("#btnSave").bind("click", function () { AddAddress() });
        ClearForm();
        return false;
    });

    //编辑收货地址
    $(".change-address-btn").on('click', function (event) {
        $(".add-new-address-box").find('h2').text("Edit delivery address")
        $(".greybox,.add-new-address-box").show();
        return false;
    });

    function GoBack() {
        window.location.href = "../Product/ShoppingCart.aspx";
    }

    function ResetCouponDiscount() {
        $("#hidCouponAmount").val("0"); //reset it
        setTotalDiscount();

    }

    function getSubTotal() {
        var subTotal = $("#labPrdMoney").html();
        return parseFloat(subTotal);
    }

    function CheckCouponCode() {


        var txtCouponCode = $("#txtPromoCode").val();
        var totalMoney = getSubTotal();
        //check length
        if (txtCouponCode.length < 5) {
            ResetCouponDiscount();
        } else {
            //Query Database
                var _data = "{ action:'query_coupon_code"
                     + "',coupon_code:'" + txtCouponCode
                     + "',order_total:'" + totalMoney
                     +"'}";
                $.ajax({
                    type: "Post",
                    url: '/AjaxPages/payMoneyPaypalAjax.aspx',
                    async: false,
                    data: _data,
                    success: function (resu) {
                        if (resu < 0) {
                            ResetCouponDiscount();
                        }
                        if (resu == 0) {
                            AlertEx("Free shipping Coupon");
                        } else if (resu > 0) {
                            // AlertEx(resu);
                            if (resu < 1) {
                                //percentage
                                var p4 = parseFloat(totalMoney) * resu;
                                $("#hidCouponAmount").val(p4.toFixed(2));
                                /*
                                $("#labDiscount").html("-" + p4.toFixed(2));
                                var b = totalMoney - p4;
                                $("#labPayMoney2").html(b.toFixed(2));*/
                                setTotalDiscount();
                            } else {
                                var p4 = parseFloat(resu);
                                $("#hidCouponAmount").val(p4.toFixed(2));
                                /*
                                $("#labDiscount").html("-" + p4.toFixed(2));
                                var b = totalMoney - p4;
                                $("#labPayMoney2").html(b.toFixed(2));*/
                                setTotalDiscount();
                            }
                        } else if (resu == -1) {
                            AlertEx("Coupon Not Exists");
                        } else if (resu == -2) {
                            AlertEx("Coupon inactive");
                        } else if (resu == -3) {
                            AlertEx("Coupon not in valid date");
                        } else if (resu == -4) {
                            AlertEx("Coupon Can only use once");
                        } else if (resu == -5) {
                            AlertEx("Coupon can only let you use once");
                        } else if (resu == -6) {
                            AlertEx("Order total smaller than the coupon's min order request");
                        }
                    },
                    error: function (msg) {
                        // alert("请求失败");
                    }
                });
        }

    }

    function getTotalMoney() {
        //sub-total + Tax + Shipping
        var a1 = $("#labPrdMoney").text();
        var a2 = $("#labTax").text();
        /*
        var a3 = $("#labTaxGST").text();
        var a4 = $("#labTaxHST").text();
        var a5 = $("#labTaxQST").text();*/
        var a6 = $("#lablogistics2").text();
        var a = Number(a1) + Number(a2) + Number(a6);

        return a;
    }

    function setTotalDiscount(amount) {
        /*
        var p = $("#labDiscount").html();
        var p1 = parseFloat(p.replace("-",""));
        var p2 = p1 + amount;
        p1 = p2.toFixed(2);*/
        var p1 = $("#txtPointMoney").val();
        var p2 = $("#txtTweebuck").val();
        var p3 = $("#txtSharePointMoney").val();
        if (p1 == "") p1 = "0";
        if (p2 == "") p2 = "0";
        if (p3 == "") p3 = "0";
        var p5 = $("#hidCouponAmount").val();
        var p4 = parseFloat(p1) + parseFloat(p2) + parseFloat(p3)+parseFloat(p5);
        //p4 = parseFloat(p4).toFixed(2);
        if (p4 > 0)
            $("#labDiscount").html("-" + p4.toFixed(2));
        else
            $("#labDiscount").html("0.00");
        var b = getTotalMoney() - p4;
        $("#labPayMoney2").html(b.toFixed(2));

    }

    function ApplyShoppingPoint() {
        var pointMoney = Number($("#txtPointMoney").val());
        if (pointMoney < 0) pointMoney = 0;
        var orderTotal = Number($("#labPrdMoney").text());
        if (pointMoney <= orderTotal) {
            $("#txtPointMoney").val(pointMoney);
            //$("#labDiscount").html("-" + pointMoney);
            setTotalDiscount(pointMoney);
            //reduct total
            /*
            var a = getTotalMoney();
            var b = parseFloat(a) - parseFloat(pointMoney);
            $("#labPayMoney2").html(b.toFixed(2));*/
        }
        else {
            $("#txtPointMoney").val(orderTotal);
            //$("#labDiscount").html("-" + orderTotal);
            setTotalDiscount(orderTotal);
            //reduct total
            /*
            var a = getTotalMoney();
            var b = parseFloat(a) - parseFloat(orderTotal);
            $("#labPayMoney2").html(b.toFixed(2)); */
        }

    }
    function ApplyAllPoint() {
        var pointMoney = Number($("#labPointMoney").text());
        if (pointMoney < 0) pointMoney = 0;
        var orderTotal = Number($("#labPrdMoney").text());
        if (pointMoney <= orderTotal) {
            $("#txtPointMoney").val(pointMoney);
            //$("#labDiscount").html("-" + pointMoney);
            setTotalDiscount(pointMoney);
            //reduct total
            /*
            var a = getTotalMoney();
            var b = parseFloat(a) - parseFloat(pointMoney);
            $("#labPayMoney2").html(b.toFixed(2));*/
        }
        else {
            $("#txtPointMoney").val(orderTotal);
            //$("#labDiscount").html("-" + orderTotal);
            setTotalDiscount(orderTotal);
            //reduct total
            /*
            var a = getTotalMoney();
            var b = parseFloat(a) - parseFloat(orderTotal);
            $("#labPayMoney2").html(b.toFixed(2));*/
        }

    }

    function ApplyTweebuck() {

        var tweebucks = Number($("#txtTweebuck").val());
        if (tweebucks < 0) tweebucks = 0;
        var orderTotal = Number($("#labPrdMoney").text());
        if (tweebucks <= orderTotal) {
            $("#txtTweebuck").val(tweebucks);
            //$("#labDiscount").html("-" + tweebucks);
            setTotalDiscount(tweebucks);
            //reduct total
            /*
            var a = getTotalMoney();
            var b = parseFloat(a) - parseFloat(tweebucks);
            $("#labPayMoney2").html(b.toFixed(2));*/
        }
        else {
            $("#txtTweebuck").val(orderTotal);
            //$("#labDiscount").html("-" + orderTotal);
            setTotalDiscount(orderTotal);
            //reduct total
            /*
            var a = getTotalMoney();
            var b = parseFloat(a) - parseFloat(orderTotal);
            $("#labPayMoney2").html(b.toFixed(2));*/
        }
    }
    function ApplyAllTweebuck() {
        var tweebucks = Number($("#labTweebucks").text());
        if (tweebucks < 0) tweebucks = 0;
        var orderTotal = Number($("#labPrdMoney").text());
        if (tweebucks <= orderTotal) {
            $("#txtTweebuck").val(tweebucks);
            //$("#labDiscount").html("-" + tweebucks);
            setTotalDiscount(tweebucks);
            //reduct total
            /*
            var a = getTotalMoney();
            var b = parseFloat(a) - parseFloat(tweebucks);
            $("#labPayMoney2").html(b.toFixed(2));*/
        }
        else {
            $("#txtTweebuck").val(orderTotal);
            //$("#labDiscount").html("-" + orderTotal);
            setTotalDiscount(orderTotal);
            //reduct total
            /*
            var a = getTotalMoney();
            var b = parseFloat(a) - parseFloat(orderTotal);
            $("#labPayMoney2").html(b.toFixed(2));*/
        }
    }

    function ApplySharePoint() {
        var pointMoney = Number($("#txtSharePointMoney").val());
        var orderTotal = Number($("#labPrdMoney").text());  //User Sub Total
        if (pointMoney < 0) pointMoney = 0;
        //if >15%
        var _limit = Math.round(100 * orderTotal * 0.15) / 100; //Max
        if (pointMoney > _limit) {
            $("#txtSharePointMoney").val(_limit);
            //$("#labDiscount").html("-" + _limit);
            setTotalDiscount(_limit);
            //reduct total
            /*
            var a = getTotalMoney();
            var b = parseFloat(a) - parseFloat(_limit);
            $("#labPayMoney2").html(b.toFixed(2));*/
        } else {
            $("#txtSharePointMoney").val(pointMoney);
            //$("#labDiscount").html("-" + pointMoney);
            setTotalDiscount(pointMoney);
            //reduct total
            /*
            var a = getTotalMoney();
            var b = parseFloat(a) - parseFloat(pointMoney);
            $("#labPayMoney2").html(b.toFixed(2));*/
        }
    }
    function ApplyAllSharePoint() {
        var pointMoney = Number($("#labSharePointsMoney").text());
        var orderTotal = Number($("#labPrdMoney").text());  //User Sub Total
        if (pointMoney < 0) pointMoney = 0;
        //if >15%
        var _limit = Math.round(100 * orderTotal * 0.15) / 100; //Max
        if (pointMoney > _limit) {
            $("#txtSharePointMoney").val(_limit);
            //$("#labDiscount").html("-" + _limit);
            setTotalDiscount(_limit);
            //reduct total
            /*
            var a = getTotalMoney();
            var b = parseFloat(a) - parseFloat(_limit);
            $("#labPayMoney2").html(b.toFixed(2));*/
        } else {
            $("#txtSharePointMoney").val(pointMoney);
            //$("#labDiscount").html("-" + pointMoney);
            setTotalDiscount(pointMoney);
            //reduct total
            /*
            var a = getTotalMoney();
            var b = parseFloat(a) - parseFloat(pointMoney);
            $("#labPayMoney2").html(b.toFixed(2));*/
        }
    }

    //保存hidBillingAddressId到Cookie里
    $(document).ready(function () {
        //console.log("ready!");
        //name="hidAddressId" value="<%=txtShippingAddrID %>" />
        $.cookie("hidBillingAddressId", "<%=txtBillingAddrID %>", { expires: 1 });
        $.cookie("hidAddressId", "<%=txtShippingAddrID %>", { expires: 1 });

        if ("<%=txtBillingAddrID %>" == "<%=txtShippingAddrID %>") {
            $("#divBillingAddr").hide();
        }
    });

</script>


</asp:Content>
