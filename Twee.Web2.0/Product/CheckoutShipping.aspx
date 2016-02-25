﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="CheckoutShipping.aspx.cs" Inherits="TweebaaWebApp2.Product.CheckoutShipping" %>
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


     <script src="/js/jquery.mask.js" type="text/javascript"></script>

     <script src="../MethodJs/calculate.js" type="text/javascript"></script>
    <script src="../MethodJs/buy.js" type="text/javascript"></script>

    <script src="/MethodJs/userAddress.js?v=151223" type="text/javascript"></script>
    <script src="/MethodJs/calculate.js" type="text/javascript"></script>

    <script src="/MethodJs/ExtraShipping.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/css/mycart-new.css" />
    <style>
     #divShipping .invalid, #divBilling .invalid{ color: #8a1f11;
        font-weight: 400;
        border: 2px solid #eec5c7 !important;
        -webkit-transition: all 0.3s ease-in-out;
        -moz-transition: all 0.3s ease-in-out;
        -o-transition: all 0.3s ease-in-out;
        transition: all 0.3s ease-in-out;
    }
    .confirmation-modal .modal-dialog
    {
        width:30% !important;
    }
    </style>

    <script src="http://maps.google.com/maps/api/js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
<input type="hidden" id="hid_action_change" value="<%=_IsChangeAddr %>" />

<input type="hidden" id="hid_addrCity" />
<input type="hidden" id="hid_addrZip" />
<input type="hidden" id="hid_address1" />
<input type="hidden" id="hid_address2" />
<input type="hidden" id="hid_fistname" />
<input type="hidden" id="hid_lastname" />
<input type="hidden" id="hid_phone" />
<input type="hidden" id="hid_email" />
<input type="hidden" id="hid_countryID" />
<input type="hidden" id="hid_stateID" />
           <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Address</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="/index.aspx">Home</a></li>
                <li><a href="/Product/prdSaleAll.aspx">Product</a></li>
                <li class="active">Address</li>
            </ul>
        </div><!--/container-->
    </div><!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->

         <!--=== Content Medium Part ===-->
    <div class="content margin-bottom-30">
        <div class="container"> 
        <div class="col-md-12">
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
                    </a></li><li role="tab" class="current" aria-disabled="true" aria-selected="true"><a id="steps-uid-0-t-1" href="javascript:void(0)"  aria-controls="steps-uid-0-p-1"><span class="number">2.</span> 
                     <div class="overflow-h">
                            <h2>Address</h2>
                          <i class="fa fa-map-marker"></i>
                        </div>    
                    </a></li><li role="tab" class="disabled" aria-disabled="true"><a id="steps-uid-0-t-2" href="javascript:void(0)"  aria-controls="steps-uid-0-p-2"><span class="number">3.</span> 
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
<form class="shopping-cart" id="frmCheckoutShipping" action="/Product/CheckoutConfirmation.aspx" method="post">
                <div style="padding:20px 0px;">


                    <section class="billing-info">
                        <div class="row">
                            <div class="col-md-6 md-margin-bottom-40">
                                <h2 class="title-type">Shipping Address</h2>
                                <input type="hidden" id="hidAddressId" name="hidAddressId" />
                                <div class="billing-info-inputs checkbox-list" >
                                 <div class="shop-address" id="divShipping">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <input id="txtShipName" tabindex=1 type="text" placeholder="First Name" name="firstname" class="form-control required">
                                            <input id="txtShipEmail" onchange="VerifyEMail(this)" tabindex=3 type="text" placeholder="Email" name="email" class="form-control required email">
                                        </div>
                                        <div class="col-sm-6">
                                            <input id="txtShipLastName"  tabindex=2 type="text" placeholder="Last Name" name="lastname" class="form-control required">
                                            <input id="txtShipPhone" onchange="VerifyPhone(this)"  tabindex=4 type="tel" placeholder="Phone" name="phone" class="form-control required phone_us">
                                        </div>
                                    </div>
                                    <input id="txtShipAddress" onchange="VerifyAddress1(this)" tabindex=5 type="text" placeholder="Address Line 1" name="address1" class="form-control required">
                                    <input id="txtShipAddress2"  tabindex=6 type="text" placeholder="Address Line 2" name="address2" class="form-control required">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <input id="txtShipZip" onchange="GetCityStateByZipCode()"  tabindex=7 type="text" placeholder="Zip/Postal Code" name="zip" class="form-control required">
                                        </div>
                                        <div class="col-sm-6">
                                            <input id="txtShipCity" tabindex=8 type="text" placeholder="City" name="city" class="form-control required">
                                        </div>

                                    </div>
                                  <div class="row">
                                    <div class="col-sm-6">
                                    <select name="selectCountry" id="selectCountry" class="form-control"  style="width: 150px;">
                                    </select>
                                    </div>
                                    <div class="col-sm-6">
                                        <select name="selectProvince" id="selectProvince" class="form-control" style="width: 150px;">
                                    </select>
                                    </div>
                                   </div>

                                     <div class="row" style="padding-top:15px;">
                                    <div class="col-sm-6">
                                    <label class="checkbox text-left">
                                        <input type="checkbox" class="checkbox" id="ckbDefault" checked="checked" />
                                        <i></i>
                                        Set as Default
                                    </label>
                                    </div>
                                    <div class="col-sm-6" >
                                   
                            <input type="button" value="Save" id="btnSaveDeliveryAddr" class="btn btn-default form-control" onclick="SaveDeliveryAddress(1)" />
                         
                                    </div>
                                    </div>
           

                            </div>

<!-- shop address -->


       <div class="saved-address" >


                <section class="billing-info">
                      <!--
                      <p id="pAddress">

                <label id="labName">
                </label>
                <br />
                <label id="labAddress">
                </label>
                <br />
                <label id="labCountry">
                </label>
                <br />
                <label id="labCountryID" style="display: none"></label>
                <label id="labProvinceID" style="display: none"></label>
                Zip: <label id="labZip"></label>
                <br />
                Phone: <label id="labPhone"></label>
                <br />
                Email: <label id="labEmail"></label>
            </p>
            -->
            <div id="divSavedAddressList"></div>
            <br /><br />
            <button class="btn-u btn-u-sm rounded" onclick="change();return false;" >New Address</button>
            <br /><br />
            <script type="text/javascript">
                function change() {
                    $(".saved-address").hide();
                    $(".shop-address").show();
                }
                //                $(function () {
                //                    var _displaySaved="<%=_displaySaved %>";                    
                //                    if (_displaySaved=="none") {
                //                        $(".saved-address").hide();
                //                        $(".shop-address").show();
                //                    }
                //                    else {
                //                        $(".saved-address").show();
                //                        $(".shop-address").hide();
                //                 }
                //                 
                //                });
            
            </script>
            <!--
                      <div class="row">
                            <div class="col-md-6 md-margin-bottom-40">
                                <h2 class="title-type">Billing Address</h2>
                                <div class="billing-info-inputs checkbox-list">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <input id="txtName" type="text" placeholder="First Name" name="firstname" class="form-control required" />
                                            <input id="txtEmail" type="text" placeholder="Email" name="email" class="form-control required email" />
                                        </div>
                                        <div class="col-sm-6">
                                            <input id="txtLastName" type="text" placeholder="Last Name" name="lastname" class="form-control required" />
                                            <input id="txtPhone" type="tel" placeholder="Phone" name="phone" class="form-control required" />
                                        </div>
                                    </div>
                                    <input id="txtAddress"  type="text" placeholder="Address Line 1" name="address1" class="form-control required" />
                                    <input id="txtAddress2" type="text" placeholder="Address Line 2" name="address2" class="form-control required" />
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <input id="txtCity" type="text" placeholder="City" name="city" class="form-control required" />
                                        </div>
                                        <div class="col-sm-6">
                                            <input id="txtZip" type="text" placeholder="Zip/Postal Code" name="zip" class="form-control required" />
                                        </div>
                                    </div>
                                    
                                    <label class="checkbox text-left">
                                        <input type="checkbox" name="checkbox"/>
                                        <i></i>
                                        Ship item to the above billing address
                                    </label>
                                </div>
                            </div>

                            <div class="col-md-6" style="display:none;">
                                <h2 class="title-type">Shipping Address</h2>
                                <div class="billing-info-inputs checkbox-list">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <input id="Text1" type="text" placeholder="First Name" name="firstname" class="form-control">
                                            <input id="Text2" type="text" placeholder="Email" name="email" class="form-control email">
                                        </div>
                                        <div class="col-sm-6">
                                            <input id="Text3" type="text" placeholder="Last Name" name="lastname" class="form-control">
                                            <input id="Tel1" type="tel" placeholder="Phone" name="phone" class="form-control">
                                        </div>
                                    </div>
                                    <input id="Text4" type="text" placeholder="Address Line 1" name="address1" class="form-control">
                                    <input id="Text5" type="text" placeholder="Address Line 2" name="address2" class="form-control">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <input id="Text6" type="text" placeholder="City" name="city" class="form-control">
                                        </div>
                                        <div class="col-sm-6">
                                            <input id="Text7" type="text" placeholder="Zip/Postal Code" name="zip" class="form-control">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>    -->   
                </section>
                
                </div>


                <div class="row" style="padding-left:15px;">
                
    <label class="checkbox text-left">
 <input type="checkbox" class="checkbox" id="cbToggleBillingAddress"  />
<i></i>
                                        I have a different billing address
                                    </label>            
                </div>

                                </div>
                            </div>

                            <div class="col-md-6" id="divBilling">
                            <div class="row">
                                        <div class="col-sm-6">
                                <h2 class="title-type">Billing Address</h2> </div>
                                <div class="col-sm-6">
                                <!--  <label class="checkbox text-left">
                                        <input type="checkbox" name="checkbox" id="cbFillBilling" onclick="Fill_BillingAddress()"/>
                                        <i></i>
                                        Use my shipping address
                                    </label>
                                    -->
                                    </div>
                                    </div>
                                <div class="billing-info-inputs checkbox-list">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <input  type="text" tabindex=10 placeholder="First Name" id="billing_firstname" name="billing_firstname" class="form-control">
                                            <input  type="text" onchange="VerifyEMail(this)" tabindex=12 placeholder="Email" id="billing_email" name="billing_email" class="form-control email">
                                        </div>
                                        <div class="col-sm-6">
                                            <input  type="text" tabindex=11 placeholder="Last Name" id="billing_lastname" name="billing_lastname" class="form-control">
                                            <input  type="tel"  onchange="VerifyPhone(this)"  tabindex=13 placeholder="Phone" id="billing_phone" name="billing_phone" class="form-control phone_us">
                                        </div>
                                    </div>
                                    <input  type="text" tabindex=14 onchange="VerifyAddress1(this)" placeholder="Address Line 1" id="billing_address1" name="billing_address1" class="form-control">
                                    <input  type="text" tabindex=15 placeholder="Address Line 2" id="billing_address2" name="billing_address2" class="form-control">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <input id="billing_zip" tabindex=16 onchange="GetCityStateByZipCode_Billing()" type="text" placeholder="Zip/Postal Code" name="billing_zip" class="form-control">
                                        </div>
                                        <div class="col-sm-6">
                                            <input id="billing_city" tabindex=17 type="text" placeholder="City" name="billing_city" class="form-control">
                                        </div>


                                    </div>
                                    <div class="row">
                                    <div class="col-sm-6">
                                    <select name="billing_country" class="form-control" id="billing_country" style="width: 150px;">
                                    </select>
                                    </div>
                                    <div class="col-sm-6">
                                        <select name="billing_state" class="form-control" id="billing_state" style="width: 150px;">
                                    </select>
                                    </div>
                                    <!--
                                    <table>
                                      <tr>
                        <td class="t">
                            Country<span class="h">*</span>
                        </td>
                        <td>
                            <div class="clearfix" style="float: left;">
                                <div class="selectBox pr fl">
                                    
                                </div>
                                <div class="selectBox pr fl">
 
                                </div>
                            </div>
                            <span class="error" id="Span2" style="float: left;">Please select area</span><span
                                class="ok">ok</span>
                        </td>
                    </tr> </table> -->
                                    </div>
                                </div>
                            </div>
                        </div>  
                        
  <div class="pull-right" style="padding-top:20px;font: 15px;">

 <button type="button" class="btn-u btn-u-orange  btn-u-lg rounded" onclick="Loading(true);IsValidGoogleMapAddress()">
 <!--
||||||| .r4363
 <button type="button" class="btn-u btn-u-red  btn-u-lg rounded" onclick="Loading(true);OrderConfirmation()">
=======
 <button type="button" class="btn-u btn-u-blue  btn-u-lg rounded" onclick="Loading(true);OrderConfirmation()">
>>>>>>> .r4368 -->
                                            Next</button>
</div>                            
                    </section>
                    
             



                   
                </div>
            </form>
</div> 
</div>
<!-- comments by Long: why Snow add this ?
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

        $('.phone_us').mask('(000) 000-0000');


    });

    function VerifyAddress1(idInput) {
        var address1 = $(idInput).val();
        if (!IsValidAddress1(address1)) {
            ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com", "Address is invalid, please check");
        }
    }
    function VerifyPhone(idInput) {
        var phone = $(idInput).val();
        if (phone.length < 14) {
            ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com", "Phone number is invalid, please check");
        }
    }
    /*
    function CheckAddressIsValid(){
        if (!IsValidGoogleMapAddress()) {
           
        }
    }
    */
    function OrderConfirmation() {
        //data validattion
        //window.location.href = "/Product/CheckoutConfirmation.aspx";

        //首先检查是否是different billing address
        if (!$("#cbToggleBillingAddress").is(':checked')) {
            //billing address the same as shipping address
            //save it first ?
            if (!$('#divShipping').is(':visible')) {
                //alert("hide");
                //just copy shipping address 2 billing address
                Fill_BillingAddress();
            } else {
                //alert("show");
                //save address first
                SaveDeliveryAddress(0);
                //copy shipping address 2 billing address
                Fill_BillingAddress();
            }
            

        } else {
            /*
            if ($("#cbFillBilling").is(':checked')) {
                //Do not need to verify billing address
            } else {
            */
            //检查是否需要保持?
                if (!$('#divShipping').is(':visible')) {

                } else {
                    SaveDeliveryAddress(0);
                }
                
                if ($("#billing_firstname").val().length < 1) {
                    $("#billing_firstname").focus();
                    $("#billing_firstname").addClass("invalid");
                    $("#billing_firstname").placeholder("Please Enter First name");
                    Loading(false);
                    return;
                }
                if ($("#billing_lastname").val().length < 1) {
                    $("#billing_lastname").focus();
                    $("#billing_lastname").addClass("invalid");
                    Loading(false);
                    //$("#billing_firstname").placeholder("Please Enter Firstname");
                    return;
                }
                if ($("#billing_email").val().length < 1) {
                    $("#billing_email").focus();
                    $("#billing_email").addClass("invalid");
                    Loading(false);
                    //$("#billing_firstname").placeholder("Please Enter Firstname");
                    return;
                }
                if ($("#billing_phone").val().length < 1) {
                    $("#billing_phone").focus();
                    $("#billing_phone").addClass("invalid");
                    Loading(false);
                    //$("#billing_firstname").placeholder("Please Enter Firstname");
                    return;
                }
                if ($("#billing_address1").val().length < 1) {
                    $("#billing_address1").focus();
                    $("#billing_address1").addClass("invalid");
                    Loading(false);
                    //$("#billing_firstname").placeholder("Please Enter Firstname");
                    return;
                }
                if ($("#billing_zip").val().length < 1) {
                    $("#billing_zip").focus();
                    $("#billing_zip").addClass("invalid");
                    Loading(false);
                    //$("#billing_firstname").placeholder("Please Enter Firstname");
                    return;
                }
                if ($("#billing_city").val().length < 1) {
                    $("#billing_city").focus();
                    $("#billing_city").addClass("invalid");
                    Loading(false);
                    //$("#billing_firstname").placeholder("Please Enter Firstname");
                    return;
                }

                //reset billing state
                var iState = $("#billing_state").val();
                if (iState < 0) {
                    AlertEx("Please choose billing state!");
                    Loading(false);
                    return;
                }
                $("#billing_state").val(iState)
            //}
        }
        $("#frmCheckoutShipping").submit();
    }
    //$('#inputId').prop('readonly', true);
    function Fill_BillingAddress() {

        //if ($("#cbFillBilling").is(':checked')) 
        {
            //Fill Billing Address


            $("#billing_firstname").val($("#hid_fistname").val());
            $("#billing_lastname").val($("#hid_lastname").val());
            $("#billing_firstname").prop('readonly', true);
            $("#billing_lastname").prop('readonly', true);


            $("#billing_email").val($("#hid_email").val());
            $("#billing_email").prop('readonly', true);

            $("#billing_phone").val($("#hid_phone").val());
            $("#billing_phone").prop('readonly', true);

            $("#billing_address1").val($("#hid_address1").val());
            $("#billing_address1").prop('readonly', true);

            $("#billing_address2").val($("#hid_address2").val());
            $("#billing_address2").prop('readonly', true);


            $("#billing_zip").val($("#hid_addrZip").val());
            $("#billing_zip").prop('readonly', true);

            $("#billing_city").val($("#hid_addrCity").val());
            $("#billing_city").prop('readonly', true);

            var countryID=$("#hid_countryID").val();
            var sateID=$("#hid_stateID").val();

            $("#billing_country option[value=" + countryID + "]").attr("selected", "true"); //国家
            BindBillingProvince(countryID, sateID); //加载城市列表

        } /*else {
            // unchecked
            $("#billing_firstname").val("");
            $("#billing_lastname").val("");
            $("#billing_firstname").removeAttr('readonly');
            $("#billing_lastname").removeAttr('readonly');


            $("#billing_email").val("");
            $("#billing_email").removeAttr('readonly');

            $("#billing_phone").val("");
            $("#billing_phone").removeAttr('readonly');

            $("#billing_address1").val("");
            $("#billing_address1").removeAttr('readonly');

            $("#billing_address2").val("");
            $("#billing_address2").removeAttr('readonly');


            $("#billing_zip").val("");
            $("#billing_zip").removeAttr('readonly');

            $("#billing_city").val("");
            $("#billing_city").removeAttr('readonly');
        }*/
    }
</script>
<!--[if lt IE 9]>
    <script src="plugins/respond.js"></script>
    <script src="plugins/html5shiv.js"></script>
    <script src="js/plugins/placeholder-IE-fixes.js"></script>
<![endif]-->

<script type="text/javascript">

    function IsValidGoogleMapAddress() {
        var address1 = $("#txtShipAddress").val();
        if (address1.length < 10) {
            Loading(false);
            ShowPopupDialogMessage("Shipping Address", "Shipping Address invalid, please check");
            return;
        }
        //var address2 = $("#txtShipAddress2").val();
        var city = $("#txtShipCity").val();
        if (city.length < 4) {
            Loading(false);
            ShowPopupDialogMessage("Shipping Address", "Shipping City invalid, please check");
            return;
        }
        var zip = $("#txtShipZip").val();
        if (zip.length < 4) {
            Loading(false);
            ShowPopupDialogMessage("Shipping Address", "Shipping Zip / Post Code invalid, please check");
            return;
        }
       // var state = $("#selectProvince option:selected").text();
       // var country = $("#selectCountry option:selected").text();
        OrderConfirmation();
        /*

        //这个google map 不好用，会乱给地址
        var CurrentAddress = address1 + " " + address2 + "," + city + "," + state + " " + zip +" "+ country ;
        // Create a new Google geocoder
        var geocoder = new google.maps.Geocoder();
        geocoder.geocode({ 'address': CurrentAddress }, function (results, status) {

        // The code below only gets run after a successful Google service call has completed.
        // Because this is an asynchronous call, the validator has already returned a 'true' result
        // to supress an error message and then cancelled the form submission.  The code below
        // needs to fetch the true validation from the Google service and then re-execute the
        // jQuery form validator to display the error message.  Futhermore, if the form was
        // being submitted, the code below needs to resume that submit.

        // Google reported a valid geocoded address
        if (status == google.maps.GeocoderStatus.OK) {
        OrderConfirmation();
        // return true;
        } else {
        //return false;
        // ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com","Sorry we can find your address at Google Map,Please verify it!");
        Loading(false);
        $.confirm({
        title: "Confirmation required",
        text: "Sorry,we can not verify your address,would you still like to continue?",
        confirm: function () {
        //delete();
        OrderConfirmation();
        },
        cancel: function () {
        // nothing to do
        },
        confirmButton: "continue",
        cancelButton: "Cancel",
        post: false,
        confirmButtonClass: "btn-warning",
        cancelButtonClass: "btn-default",
        dialogClass: "modal-dialog"
        });
        }
        });
        */
    }
    function VerifyEMail(idInput) {
        var email = $(idInput).val();
        if (!validateEmail(email)) {
            ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com", "E-mail is invalid, Please check");

        }

    }
    function CheckZipcodeValid(zip) {
        var IsUS = isValidPostalCode(zip,"US");
        var IsCa = isValidPostalCode(zip, "CA");
        var IsCa1 = isValidPostalCode(zip, "CA1");
        if (IsUS || IsCa || IsCa1) {
            return true;
        } else {
            return false;
        }
    }
    function isValidPostalCode(postalCode, countryCode) {
        switch (countryCode) {
            case "US":
                postalCodeRegex = /^([0-9]{5})(?:[-\s]*([0-9]{4}))?$/;
                break;
            case "CA":
                postalCodeRegex = /^([A-Z][0-9][A-Z])\s*([0-9][A-Z][0-9])$/;
                break;
            case "CA1":
                postalCodeRegex = /^([A-Z][0-9][A-Z][0-9][A-Z][0-9])$/;
                break;
            default:
                postalCodeRegex = /^(?:[A-Z0-9]+([- ]?[A-Z0-9]+)*)?$/;
        }
        return postalCodeRegex.test(postalCode);
    }
    function GetCityStateByZipCode_Billing() {
        
        //

        var txtZip = $("#billing_zip").val();
        if (!CheckZipcodeValid(txtZip)) {
            ShowPopupDialogMessage("Invalid Data", "Invalid Zipcode or Postal code!");
            $("#billing_zip").focus();
            $("#billing_zip").addClass("invalid");
            return;
        }
        $("#billing_city").val("Getting Data...");
        Loading(true);
        
        if (txtZip.length >= 5) {
            var _data = "{ action:'QueryCityByZip"
                    + "',zip:'" + txtZip + "'}";
            $.ajax({
                type: "Post",
                url: '/AjaxPages/userAddressAjax.aspx',
                data: _data,
                async: false,
                success: function (resu) {
                    Loading(false);
                    if (resu.length > 0) {
                        var p = resu.split(":");
                        $("#billing_city").val(p[0]);
                        //Load Country first
                        /*
                        selects = $("#selectCountry");
                        $.each(selects, function (key, activity) {
                        // show me activity seelctec in each case
                        if ($(activity).html() == p[2]) {
                        //selected
                        $(activity).attr('selected', 'selected');
                        //load state/province
                        BindProvince($(activity).id, p[1]);
                        }
                        });*/
                        $("#billing_country").children("option").each(function () {
                            //alert(selectName + " " + $(this).html());
                            if ($(this).html() == p[2]) {
                                //selected
                                $(this).attr('selected', 'selected');
                                //load state/province
                                BindProvinceByName($(this).val(), p[1],"billing_state");
                            }
                        });
                        /*
                        $("#selectCountry option", this).each(function () {

                        //alert($(this).val());
                        if ($(this).html() == p[2]) {
                        //selected
                        $(this).attr('selected', 'selected');
                        //load state/province
                        BindProvince($(this).val(), p[1]);
                        }
                        });*/
                    }
                },
                error: function (obj) {
                    //alert("失败");
                    Loading(false);
                }
            });
        }

    }
    function GetCityStateByZipCode() {
        
        
        var txtZip = $("#txtShipZip").val();
        if (!CheckZipcodeValid(txtZip)) {
            ShowPopupDialogMessage("Invalid Data", "Invalid Zipcode or Postal code!");
            $("#txtShipZip").focus();
            $("#txtShipZip").addClass("invalid");
            return;
        }
        $("#txtShipCity").val("Getting Data...");
        Loading(true);
        if (txtZip.length >= 5) {
               var _data = "{ action:'QueryCityByZip"
                    + "',zip:'" + txtZip + "'}";
               $.ajax({
                   type: "Post",
                   url: '/AjaxPages/userAddressAjax.aspx',
                   data: _data,
                   async: false,
                   success: function (resu) {
                       Loading(false);
                       if (resu.length > 0) {
                           var p = resu.split(":");
                           $("#txtShipCity").val(p[0]);
                           //Load Country first
                           /*
                           selects = $("#selectCountry");
                           $.each(selects, function (key, activity) {
                               // show me activity seelctec in each case
                               if ($(activity).html() == p[2]) {
                                   //selected
                                   $(activity).attr('selected', 'selected');
                                   //load state/province
                                   BindProvince($(activity).id, p[1]);
                               }
                           });*/
                           $("#selectCountry").children("option").each(function () {
                               //alert(selectName + " " + $(this).html());
                               if ($(this).html() == p[2]) {
                                   //selected
                                   $(this).attr('selected', 'selected');
                                   //load state/province
                                   BindProvinceByName($(this).val(), p[1],"selectProvince");
                               }
                           });
                           /*
                           $("#selectCountry option", this).each(function () {

                               //alert($(this).val());
                               if ($(this).html() == p[2]) {
                                   //selected
                                   $(this).attr('selected', 'selected');
                                   //load state/province
                                   BindProvince($(this).val(), p[1]);
                               }
                           });*/
                       }
                   },
                   error: function (obj) {
                       //alert("失败");
                       Loading(false);
                   }
               });
        }

    }


    function SaveDeliveryAddress(reload_flag) {
        var guid = $("#hidAddressId").val();
        if (guid == null || guid == "") {
            AddShipAddress(reload_flag);
        }
        else {
            UpdateShipAddress(guid, reload_flag);
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
    $(".change-address-btn").click(function (event) {
        $(".add-new-address-box").find('h2').text("Edit delivery address")
        $(".greybox,.add-new-address-box").show();
        return false;
    });

    function GoBack() {
        window.location.href = "../Product/shopCart.aspx";
    }
    function AddShipAddress(reload_flag) {

        var flag = "true";
        var countyid = $("#selectCountry  option:selected").val();
        var provinceid = $("#selectProvince  option:selected").val();
        if (provinceid == -1) {
            alert("Please choose a State / Province");
            Loading(false);
            return;
        }
        var cityid = ""; // $("#selectCity  option:selected").val();
        var city = $("#txtShipCity").val(); //城市
        var zip = $("#txtShipZip").val(); //
        var address = $("#txtShipAddress").val();
        var address2 = $("#txtShipAddress2").val();
        var username = $("#txtShipName").val().trim();
        var lastName = $("#txtShipLastName").val(); //姓氏
        var phone = $("#txtShipPhone").val();
        var tel = $("#txtShipPhone").val();
        var email = $("#txtShipEmail").val();
        var isfirst = 1;
        //if ($("#ckbDefault").is(":checked")) {isfirst = 1;}
        if ($("#txtShipName").val().length < 1) {
            $("#txtShipName").focus();
            $("#txtShipName").addClass("invalid");
            $("#txtShipName").val("Please Enter First name");
            Loading(false);
            return;
        }
        if ($("#txtShipLastName").val().length < 1) {
            $("#txtShipLastName").focus();
            $("#txtShipLastName").addClass("invalid");
            $("#txtShipLastName").val("Please Enter Last name");
            Loading(false);
            return;
        }
        if ($("#txtShipEmail").val().length < 1) {
            $("#txtShipEmail").focus();
            $("#txtShipEmail").addClass("invalid");
            $("#txtShipEmail").val("Please Enter EMail Address");
            Loading(false);
            return;
        }
        if ($("#txtShipPhone").val().length < 1) {
            $("#txtShipPhone").focus();
            $("#txtShipPhone").addClass("invalid");
            $("#txtShipPhone").val("Please Enter Phone");
            Loading(false);
            return;
        }
        if ($("#txtShipAddress").val().length < 1) {
            $("#txtShipAddress").focus();
            $("#txtShipAddress").addClass("invalid");
            $("#txtShipAddress").placeholder("Please Enter Shipping Address");
            Loading(false);
            return;
        }
        if ($("#txtShipZip").val().length < 1) {
            $("#txtShipZip").focus();
            $("#txtShipZip").addClass("invalid");
            $("#txtShipZip").val("Please Enter Zip/Post Code");
            Loading(false);
            return;
        }
        if ($("#txtShipCity").val().length < 1) {
            $("#txtShipCity").focus();
            $("#txtShipCity").addClass("invalid");
            $("#txtShipCity").val("Please Enter City");
            Loading(false);
            return;
        }
        var bAddressOK = CheckAddress(address);
        var bAddress2OK = CheckAddress(address2);
        if (!bAddressOK || !bAddress2OK) {
            ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com","We cannot deliver to a PO Box.\nPlease change your delivery address!");
            if (!bAddressOK) $("#txtAddress").focus();
            else $("#txtAddress2").focus();
        }
        /*
        if (username == "" || username.length < 2) { $("#errorNmae").show(); flag = "false"; } else { $("#errorNmae").hide(); }
        if (lastName == "") { $("#errorlastName").show(); flag = "false"; } else { $("#errorlastName").hide(); }
        if (city == "") { $("#errorCity").show(); flag = "false"; } else { $("#errorCity").hide(); }
        if (zip == "") { $("#errorZip").show(); flag = "false"; } else { $("#errorZip").hide(); }
        if (address == "" || !bAddressOK || !bAddress2OK) { $("#errorAddress").show(); flag = "false"; } else { $("#errorAddress").hide(); }
        if (phone == "") { $("#errorPhone").show(); flag = "false"; } else { $("#errorPhone").hide(); }
        if (provinceid == "-1") { $("#errorArea").show(); flag = "false"; } else { $("#errorArea").hide(); }
        if (flag == "false") {
            return;
        }*/
        var _data = "{ action:'add"
                    + "',countyid:'" + countyid
                    + "',provinceid:'" + provinceid
                    + "',cityid:'" + cityid
                    + "',city:'" + city
                    + "',zip:'" + zip
                    + "',address:'" + address
                    + "',address2:'" + address2
                    + "',username:'" + username
                    + "',lastName:'" + lastName
                    + "',phone:'" + phone
                    + "',tel:'" + tel
                    + "',email:'" + email
                    + "',isfirst:'" + isfirst + "'}";
        $.ajax({
            type: "Post",
            url: '/AjaxPages/userAddressAjax.aspx',
            data: _data,
            async: false,
            success: function (resu) {
                if (resu == "-1") {
                    ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com", "Please log in！");

                    Loading(false);
                    return;
                }
                else if (resu == "0") {
                    ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com", "Failed to add address！");
                    Loading(false);
                    return;
                }
                else {
                    //alert("Added successfully！");
                    //$(".greybox,.add-new-address-box").hide();
                    //if(reload_flag==1)
                     LoadShopaddress();

                    // after adding address need to re-load the check cart because the counry and Zip will affect the shippping fee
                   // LoadCheckCart();

                    //ClearForm();
                    //EnableGotoPayButton();
                    return;
                }
            }
        });
    }
    function UpdateShipAddress(guid, reload_flag) {
        var flag = "true";
        var countyid = $("#selectCountry  option:selected").val();
        var provinceid = $("#selectProvince  option:selected").val();
        if (provinceid == -1) {
            ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com","Please choose a State / Province");
            Loading(false);
            return;
        }
        var cityid = null; //  $("#selectCity  option:selected").val();
        var city = $("#txtShipCity").val(); //城市
        var zip = $("#txtShipZip").val();
        var address = $("#txtShipAddress").val();
        var address2 = $("#txtShipAddress2").val();
        var username = $("#txtShipName").val().trim();
        var lastName = $("#txtShipLastName").val(); //姓氏
        var tel = $("#txtShipPhone").val();
        var phone = $("#txtShipPhone").val();
        var email = $("#txtShipEmail").val();
        var isfirst = 1;
        //if ($("#ckbDefault").is(":checked")) { isfirst = 1;} else { isfirst = 0;}       
        //if (cityid == "-1" || cityid == "") { $("#errorArea").show(); }

        if ($("#txtShipName").val().length < 1) {
            $("#txtShipName").focus();
            $("#txtShipName").addClass("invalid");
            $("#txtShipName").val("Please Enter First name");
            Loading(false);
            return;
        }
        if ($("#txtShipLastName").val().length < 1) {
            $("#txtShipLastName").focus();
            $("#txtShipLastName").addClass("invalid");
            $("#txtShipLastName").val("Please Enter Last name");
            Loading(false);
            return;
        }
        if ($("#txtShipEmail").val().length < 1) {
            $("#txtShipEmail").focus();
            $("#txtShipEmail").addClass("invalid");
            $("#txtShipEmail").val("Please Enter EMail Address");
            Loading(false);
            return;
        }
        if ($("#txtShipPhone").val().length < 1) {
            $("#txtShipPhone").focus();
            $("#txtShipPhone").addClass("invalid");
            $("#txtShipPhone").val("Please Enter Phone");
            Loading(false);
            return;
        }
        if ($("#txtShipAddress").val().length < 1) {
            $("#txtShipAddress").focus();
            $("#txtShipAddress").addClass("invalid");
            $("#txtShipAddress").placeholder("Please Enter Shipping Address");
            Loading(false);
            return;
        }
        if ($("#txtShipZip").val().length < 1) {
            $("#txtShipZip").focus();
            $("#txtShipZip").addClass("invalid");
            $("#txtShipZip").val("Please Enter Zip/Post Code");
            Loading(false);
            return;
        }
        if ($("#txtShipCity").val().length < 1) {
            $("#txtShipCity").focus();
            $("#txtShipCity").addClass("invalid");
            $("#txtShipCity").val("Please Enter City");
            Loading(false);
            return;
        }
         var bAddressOK = CheckAddress(address);
        var bAddress2OK = CheckAddress(address2);
        if (!bAddressOK || !bAddress2OK) {
            ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com", "We cannot deliver to a PO Box.\nPlease change your delivery address!");
            if (!bAddressOK) $("#txtShipAddress").focus();
            else $("#txtShipAddress2").focus();
        }
        /*
        if (city == "") { $("#errorCity").show(); flag = "false"; } else { $("#errorCity").hide(); }
        if (zip == "") { $("#errorZip").show(); flag = "false"; } else { $("#errorZip").hide(); }
        if (address == "" || !bAddressOK || !bAddress2OK) { $("#errorAddress").show(); flag = "false"; } else { $("#errorAddress").hide(); }
        if (username == "" || username.length < 2) { $("#errorNmae").show(); flag = "false"; } else { $("#errorNmae").hide(); }
        if (lastName == "") { $("#errorlastName").show(); flag = "false"; } else { $("#errorlastName").hide(); }
        if (phone == "") { $("#errorPhone").show(); flag = "false"; } else { $("#errorPhone").hide(); }
        if (provinceid == "-1") { $("#errorArea").show(); flag = "false"; } else { $("#errorArea").hide(); }
        if (flag == "false") {
            return;
        }*/
        var _data = "{ action:'update"
                    + "',guid:'" + guid
                    + "',countyid:'" + countyid
                    + "',provinceid:'" + provinceid
                    + "',cityid:'" + cityid
                    + "',city:'" + city
                    + "',zip:'" + zip
                    + "',address:'" + address
                    + "',address2:'" + address2
                    + "',username:'" + username
                    + "',lastName:'" + lastName
                    + "',phone:'" + phone
                    + "',tel:'" + tel
                    + "',email:'" + email
                    + "',isfirst:'" + isfirst + "'}";
        $.ajax({
            type: "Post",
            url: '/AjaxPages/userAddressAjax.aspx',
            data: _data,
            async: false,
            success: function (resu) {
                if (resu == "-1") {
                    //alert("Please login！");
                    Loading(false);
                    return;
                }
                else if (resu == "0") {
                    ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com", "Modify address the failure！");
                    Loading(false);
                    return;
                }
                else {
                   // alert("Successful modification！");
                    $(".greybox,.add-new-address-box").hide();
                    $("#ulAddress1").empty();
                    //if(reload_flag==1)
                    LoadShopaddress();

                    // after updating, need to re-load the check cart because the counry and Zip will affect the shippping fee
                    //LoadCheckCart();

                   // EnableGotoPayButton();
                    //ClearForm();
                    //window.location.href = window.location.href;
                    return;
                }
            }
        });
    }
    function CheckAddress(address) {
        // mantis #622 Either put a restriction so if system detects "PO Box" or "P.O. Box" in the ship address field it will create Error message
        //...OR put a bold warning that we cannot deliver to a PO Box.
        var addressLowerCase = address.toLowerCase();
        var patt = /(po|p.o.)\s{1,}(box)/g;
        var result = patt.test(addressLowerCase);
        return (!result);
    }

    //hide billing address first
    $("#divBilling").hide();
    $("#btnSaveDeliveryAddr").hide();

    $('#cbToggleBillingAddress').click(function () {
        if (!$(this).is(':checked')) {
            /*
            var ans = confirm("Are you sure?");
            $('#textbox1').val(ans);
            */
            //alert("uncheck");
            $("#divBilling").hide();
        } else {
            //alert("check");
            $("#divBilling").show();
        }
    });

    </script>
   



</asp:Content>