<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="shopOrder.aspx.cs" Inherits="TweebaaWebApp2.Product.shopOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">   
    <!-- **************************** -->
    <script type="text/javascript" src="/js/jquery.cookie.js"></script>
    <script type="text/javascript" src="/js/jquery.base64.js"></script>
    <script src="../MethodJs/userAddress.js" type="text/javascript"></script>
    <script src="../MethodJs/calculate.js" type="text/javascript"></script>
    <script src="../MethodJs/order.js?v=151125" type="text/javascript"></script>
    <script src="/MethodJs/ExtraShipping.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../css/mycart-new.css" />

<!--Start of Zopim Live Chat Script-->
<script type="text/javascript">
    window.$zopim || (function (d, s) {
        var z = $zopim = function (c) { z._.push(c) }, $ = z.s =
d.createElement(s), e = d.getElementsByTagName(s)[0]; z.set = function (o) {
    z.set.
_.push(o)
}; z._ = []; z.set._ = []; $.async = !0; $.setAttribute("charset", "utf-8");
        $.src = "//v2.zopim.com/?3SkhL2CFelNy1xITHgs9PrwP0JnHNM52"; z.t = +new Date; $.
type = "text/javascript"; e.parentNode.insertBefore($, e)
    })(document, "script");
</script>
<!--End of Zopim Live Chat Script-->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">
                Check Out</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="/index.aspx">Home</a></li>
                <li><a href="/Product/shopCart.aspx">Shopping Cart</a></li>
                <li class="active">Check Out</li>
            </ul>
        </div>
        <!--/container-->
    </div>
    <!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->
    <!--=== Content Medium Part ===-->
    <div class="content margin-bottom-30">
        <div class="container">

            <div id="payform" style="display: none;">
    </div>

            <form class="shopping-cart" action="#">
            <input type="hidden" id="hidAddressId" value="<%=_addressCartGudid %>" />
        <!-- shop address -->
        <div class="shop-address" >
            <div class="fir-address-box">
                <div class="title clearfix" style="text-align: left; padding-bottom: 0px; padding-top: 0px;">
                    <h2 class="t">
                        Delivery Address
                    </h2>
                </div>
                <table width="100%">
                    <tr>
                        <td class="t">
                            First Name<span class="h">*</span>
                        </td>
                        <td>
                            <input type="text" class="txt name" id="txtShipName" style="width: 150px;" placeholder="Input your first name" />
                            <span class="error" id="errorNmae">Receiver name have to be 2-25 characters</span>
                            <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Last Name<span class="h">*</span>
                        </td>
                        <td>
                            <input type="text" class="txt name" id="txtShipLastName" style="width: 150px;" placeholder="Input your last name" />
                            <span class="error" id="errorlastName">Receiver name have to be 2-25 characters</span>
                            <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Address line 1<span class="h">*</span>
                        </td>
                        <td>
                            <%--<textarea name="" class="txt areaall" id="txtShipAddress" placeholder="Choose from list, between 5-120 characters"></textarea>--%>
                            <input type="text" class="txt2 areaall" id="txtShipAddress" placeholder="Input your address" />
                            <span class="error" id="errorAddress">5-120 characters</span> <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Address line2<%--<span class="h">*</span>--%>
                        </td>
                        <td>
                            <%--<textarea name="" class="txt areaall" id="txtShipAddress2" placeholder="Choose from list, between 5-120 characters"></textarea>--%>
                            <input type="text" class="txt2 areaall" id="txtShipAddress2" placeholder="Input your address" />
                            <span class="error" id="Span1">5-120 characters</span> <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            City<span class="h">*</span>
                        </td>
                        <td>
                            <input type="text" class="txt name" id="txtShipCity" placeholder="Input city name" />
                            <span class="error" id="errorCity">Input city name</span> <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Zip/Postal Code<span class="h">*</span>
                        </td>
                        <td>
                            <input type="text" class="txt textZip" id="txtShipZip" />
                            <span class="error" id="errorZip">Input zip/postal code</span> <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Country<span class="h">*</span>
                        </td>
                        <td>
                            <div class="clearfix" style="float: left;">
                                <div class="selectBox pr fl">
                                    <select name="" id="selectCountry" style="width: 150px;">
                                    </select>
                                </div>
                                <div class="selectBox pr fl">
                                    <select name="" id="selectProvince" style="width: 150px;">
                                    </select>
                                </div>
                            </div>
                            <span class="error" id="errorArea" style="float: left;">Please select area</span><span
                                class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Phone<span class="h">*</span>
                        </td>
                        <td>
                            <input type="text" class="txt phoneNum" id="txtShipPhone" placeholder="Area code + tel/mobile number" />
                            <span class="error" id="errorPhone">Tel:(027-88888888)or Mobile:416 000 000 </span>
                            <span class="ok">ok</span>
                        </td>
                    </tr>
                     <% if (_IsGuestChecout)
                           { %>
                     <tr>
                        <td class="t">
                            Email<span class="h">*</span>
                        </td>
                        <td>
                            <input type="text" class="txt phoneNum" id="txtShipEmail" placeholder="Email" />
                            <span class="error" id="errorEmail">Input email</span>
                            <span class="ok">ok</span>
                        </td>
                    </tr>
                     <% } %>
                    <tr style="display: none;">
                        <td class="t">
                            Set as Default
                        </td>
                        <td>
                            <input type="checkbox" class="checkbox" id="ckbDefault" checked="checked" />
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                        </td>
                        <td>
                        <% if (_IsGuestChecout)
                           { %>
                            <input type="button" value="Save" id="btnSave" class="send" onclick="LoadCheckCart();" />&nbsp;
                        <% }
                           else
                           { %>
                            <input type="button" value="Save" id="btnSaveDeliveryAddr" class="send" onclick="SaveDeliveryAddress()" />
                            <input type="button" value="Cancel" id="btnCancel" class="send" onclick="CancelChangeAddress()" />
                         <%} %>
                        </td>
                    </tr>
                </table>

            </div>
        </div>
<!-- shop address -->


       <div class="saved-address" style="display:none" >
                <%--<div class="header-tags">
                    <div class="overflow-h">
                        <h2>
                            Shopping Cart</h2>
                        <p>
                            Review &amp; edit your product</p>
                        <i class="rounded-x fa fa-check"></i>
                    </div>
                </div>--%>

                <!--div class="title clearfix" style="text-align: left; padding-bottom: 0px; padding-top: 0px;">
                    <h2 class="t">
                        Delivery Address
                    </h2>
                </div-->

                <section class="billing-info">
                      <p id="pAddress">
                <div class="title clearfix" style="text-align: left; padding-bottom: 0px; padding-top: 0px;">
                    <h2 class="t">
                        Delivery Address
                    </h2>
                </div>
               <%--Jun cao<br />
                1800 Edmund ave,<br />
                toronto, Ontario, M3N2S5<br />
                Canada<br />
                Phone: 416229999<br />
                Email: cjunjun@gmail.com--%>
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

            <input type="button" value="Change" class="send" onclick="change()" />
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

                      <div class="row">
                            <div class="col-md-6 md-margin-bottom-40" style="display:none">
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
                                            <input id="name2" type="text" placeholder="First Name" name="firstname" class="form-control">
                                            <input id="email2" type="text" placeholder="Email" name="email" class="form-control email">
                                        </div>
                                        <div class="col-sm-6">
                                            <input id="surname2" type="text" placeholder="Last Name" name="lastname" class="form-control">
                                            <input id="phone2" type="tel" placeholder="Phone" name="phone" class="form-control">
                                        </div>
                                    </div>
                                    <input id="shippingAddress" type="text" placeholder="Address Line 1" name="address1" class="form-control">
                                    <input id="shippingAddress2" type="text" placeholder="Address Line 2" name="address2" class="form-control">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <input id="city2" type="text" placeholder="City" name="city" class="form-control">
                                        </div>
                                        <div class="col-sm-6">
                                            <input id="zip2" type="text" placeholder="Zip/Postal Code" name="zip" class="form-control">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>       
                </section>
                
                </div>
                <%--<div class="header-tags">
                    <div class="overflow-h">
                        <h2>
                            Billing info</h2>
                        <p>
                            Shipping and address infot</p>
                        <i class="rounded-x fa fa-home"></i>
                    </div>
                </div>--%>
                <br />
                <br />
                <br />
                <section>
                    <div class="table-responsive">
                            <table class="table table-striped">
                                <thead>
                                   <tr>
                                   <th class="pro-infor">Product Information</th>
                                   <th>Quantity</th>
                                   <th>Unit Price</th>
                                   <th>Shipping Method</th>
                                   <th style="display:none">Shipping Fee</th>
                                   <th >Sub-Total</th>
                                   <th style="display:none">Shipping Partner</th>
                                   </tr>
                                </thead>
                                <tbody id="tableOrder">
                                                  
                                </tbody>
                            </table>
                        </div>
                </section>
                <%-- <div class="header-tags">
                    <div class="overflow-h">
                        <h2>
                            Payment</h2>
                        <p>
                            Select Payment method</p>
                        <i class="rounded-x fa fa-credit-card"></i>
                    </div>
                </div>--%>
                <%--<section>
                     <div class="row">
                            <div class="col-md-6 md-margin-bottom-50">
                                <h2 class="title-type">Choose a payment method</h2>
                                <!-- Accordion -->
                                <div class="accordion-v2">
                                    <div class="panel-group" id="accordion">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">
                                                        <i class="fa fa-credit-card"></i>
                                                        Credit or Debit Card
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseOne" class="panel-collapse collapse in">
                                                <div class="panel-body cus-form-horizontal">
                                                    <div class="form-group">
                                                        <label class="col-sm-4 no-col-space control-label">Cardholder Name</label>
                                                        <div class="col-sm-8">
                                                            <input type="text" class="form-control required" name="cardholder" placeholder="">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-sm-4 no-col-space control-label">Card Number</label>
                                                        <div class="col-sm-8">
                                                            <input type="text" class="form-control required" name="cardnumber" placeholder="">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-sm-4 no-col-space control-label">Payment Types</label>
                                                        <div class="col-sm-8">
                                                            <ul class="list-inline payment-type">
                                                                <li><i class="fa fa-cc-paypal"></i></li>
                                                                <li><i class="fa fa-cc-visa"></i></li>
                                                                <li><i class="fa fa-cc-mastercard"></i></li>
                                                                <li><i class="fa fa-cc-discover"></i></li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-sm-4">Expiration Date</label>
                                                        <div class="col-sm-8 input-small-field">
                                                            <input type="text" name="mm" placeholder="MM" class="form-control required sm-margin-bottom-20">
                                                            <span class="slash">/</span>
                                                            <input type="text" name="yy" placeholder="YY" class="form-control required">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-sm-4 no-col-space control-label">CSC</label>
                                                        <div class="col-sm-8 input-small-field">
                                                            <input type="text" name="number" placeholder="" class="form-control required">
                                                            <a href="#">What's this?</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                                                        <i class="fa fa-paypal"></i>
                                                        Pay with PayPal
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseTwo" class="panel-collapse collapse">
                                                <div class="content margin-left-10">
                                                    <a href="#"><img src="www.paypalobjects.com/webstatic/en_US/i/buttons/PP_logo_h_150x38.png" alt="PayPal"></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- End Accordion -->    
                            </div>

                            <div class="col-md-6">
                                <h2 class="title-type">Frequently asked questions</h2>
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
                                                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam hendrerit, felis vel tincidunt sodales, urna metus rutrum leo, sit amet finibus velit ante nec lacus. Cras erat nunc, pulvinar nec leo at, rhoncus elementum orci. Nullam ut sapien ultricies, gravida ante ut, ultrices nunc.
                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion-v2" href="#collapseTwo-v2">
                                                        Can I use gift card to pay for my purchase?
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseTwo-v2" class="panel-collapse collapse">
                                                <div class="panel-body">
                                                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam hendrerit, felis vel tincidunt sodales, urna metus rutrum leo, sit amet finibus velit ante nec lacus. Cras erat nunc, pulvinar nec leo at, rhoncus elementum orci. Nullam ut sapien ultricies, gravida ante ut, ultrices nunc.    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion-v2" href="#collapseThree-v2">
                                                        Will I be charged when I place my order?
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseThree-v2" class="panel-collapse collapse">
                                                <div class="panel-body">
                                                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam hendrerit, felis vel tincidunt sodales, urna metus rutrum leo, sit amet finibus velit ante nec lacus. Cras erat nunc, pulvinar nec leo at, rhoncus elementum orci. Nullam ut sapien ultricies, gravida ante ut, ultrices nunc.    
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
                                                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam hendrerit, felis vel tincidunt sodales, urna metus rutrum leo, sit amet finibus velit ante nec lacus. Cras erat nunc, pulvinar nec leo at, rhoncus elementum orci. Nullam ut sapien ultricies, gravida ante ut, ultrices nunc.    
                                                </div>
                                            </div>
                                        </div>    
                                    </div>
                                </div>
                                <!-- End Accordion -->    
                            </div>
                        </div>
                 </section>--%>
                <div class="coupon-code">
                    <div class="row" id="extra_info_table">
                        <div class="col-sm-4 sm-margin-bottom-30">
                            <%-- <h3>
                                Discount Code</h3>
                            <p>
                                Enter your coupon code</p>
                            <input class="form-control margin-bottom-10" name="code" type="text">
                            <button type="button" class="btn-u btn-u-sea-shop">
                                Apply Coupon</button>--%>
                            <table width="100%" border="0" style="width: 390px; float: left;">
                                <tbody>
                                    <tr>
                                        <td colspan="2" style="width: 390px; text-align: left; padding-left: 20px; float: left;
                                            padding-bottom: 33px;">
                                            <div style="float: left; height: 35px; width: 100%;">
                                                <p style="padding-top: 10px; width: 200px; float: left; font-size: 14px;">
                                                    Use Shopping Reward Points?
                                                </p>
                                                <p style="font-size: 10px; padding-top: 0px; width: 170px; float: right; padding-right: 30px;
                                                    line-height: 15px;">
                                                    Available
                                                    <label id="labPoint">
                                                        <%=_shoppingPoint%></label>
                                                    points.<br />
                                                    Redemption Value:$<label id="labPointMoney"><%=_shoppingPointMoney %></label></p>
                                            </div>
                                            <br />
                                            <div style="float: left;">
                                                <input type="text" placeholder="Enter $ amount" id="txtPointMoney" onchange="ApplyShoppingPoint()" class="form-control margin-bottom-10"
                                                    style="width: 190px;" />&nbsp;&nbsp;
                                                <input type="button" value="Apply All" onclick="ApplyAllPoint()" class="btn-u btn-u-sea-shop"
                                                    style="width: 100px;" />
                                                <script type="text/javascript">

                                                    function getTotalMoney() {
                                                        //sub-total + Tax + Shipping
                                                        var a1 = $("#labPrdMoney").text();
                                                        var a2 = $("#labTax").text();
                                                        /*
                                                        var a3 = $("#labTaxGST").text();
                                                        var a4 = $("#labTaxHST").text();
                                                        var a5 = $("#labTaxQST").text();*/
                                                        var a6 = $("#lablogistics2").text();
                                                        var a = Number(a1) +   Number(a2) +   Number(a6);

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
                                                        if (p1=="") p1 = "0";
                                                        if (p2=="") p2 = "0";
                                                        if (p3=="") p3 = "0";
                                                        var p4 = parseFloat(p1) + parseFloat(p2) +parseFloat( p3);
                                                        p4 = parseFloat(p4).toFixed(2);
                                                        $("#labDiscount").html("-"+p4);

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
                                                            var a = getTotalMoney();
                                                            var b = parseFloat(a) - parseFloat(pointMoney);
                                                            $("#labPayMoney2").html(b.toFixed(2));
                                                        }
                                                        else {
                                                            $("#txtPointMoney").val(orderTotal);
                                                            //$("#labDiscount").html("-" + orderTotal);
                                                            setTotalDiscount(orderTotal);
                                                            //reduct total
                                                            var a = getTotalMoney();
                                                            var b = parseFloat(a) - parseFloat(orderTotal);
                                                            $("#labPayMoney2").html(b.toFixed(2));
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
                                                            var a = getTotalMoney();
                                                            var b = parseFloat(a) - parseFloat(pointMoney);
                                                            $("#labPayMoney2").html(b.toFixed(2));
                                                        }
                                                        else {
                                                            $("#txtPointMoney").val(orderTotal);
                                                            //$("#labDiscount").html("-" + orderTotal);
                                                            setTotalDiscount(orderTotal);
                                                            //reduct total
                                                            var a = getTotalMoney();
                                                            var b = parseFloat(a) - parseFloat(orderTotal);
                                                            $("#labPayMoney2").html(b.toFixed(2));
                                                        }

                                                    }
                                                </script>
                                            </div>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: left; padding-left: 20px; padding-bottom: 35px;">
                                            Use TweeBucks? Current Balance $<label id="labTweebucks" style="margin-left: 1px"><%=_extractionTweebuck %></label><br />
                                            <input type="text" placeholder="Enter $ amount" id="txtTweebuck" onchange="ApplyTweebuck()" class="form-control margin-bottom-10"
                                                style="width: 190px;" />&nbsp;&nbsp;
                                            <input type="button" value="Apply All" onclick="ApplyAllTweebuck()" class="btn-u btn-u-sea-shop"
                                                style="width: 100px;" />
                                            <script type="text/javascript">
                                                function ApplyTweebuck() {

                                                    var tweebucks = Number($("#txtTweebuck").val());
                                                    if (tweebucks < 0) tweebucks = 0;
                                                    var orderTotal = Number($("#labPrdMoney").text());
                                                    if (tweebucks <= orderTotal) {
                                                        $("#txtTweebuck").val(tweebucks);
                                                        //$("#labDiscount").html("-" + tweebucks);
                                                        setTotalDiscount(tweebucks);
                                                        //reduct total
                                                        var a = getTotalMoney();
                                                        var b = parseFloat(a) - parseFloat(tweebucks);
                                                        $("#labPayMoney2").html(b.toFixed(2));
                                                    }
                                                    else {
                                                        $("#txtTweebuck").val(orderTotal);
                                                        //$("#labDiscount").html("-" + orderTotal);
                                                        setTotalDiscount(orderTotal);
                                                        //reduct total
                                                        var a = getTotalMoney();
                                                        var b = parseFloat(a) - parseFloat(orderTotal);
                                                        $("#labPayMoney2").html(b.toFixed(2));
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
                                                        var a = getTotalMoney();
                                                        var b = parseFloat(a) - parseFloat(tweebucks);
                                                        $("#labPayMoney2").html(b.toFixed(2));
                                                    }
                                                    else {
                                                        $("#txtTweebuck").val(orderTotal);
                                                        //$("#labDiscount").html("-" + orderTotal);
                                                        setTotalDiscount(orderTotal);
                                                        //reduct total
                                                        var a = getTotalMoney();
                                                        var b = parseFloat(a) - parseFloat(orderTotal);
                                                        $("#labPayMoney2").html(b.toFixed(2));
                                                    }
                                                }
                                            </script>
                                            </td>
                                    </tr>

                                    <!-- Add by Long for share point redeem -->
                                    <tr>
                                        <td colspan="2" style="width: 390px; text-align: left; padding-left: 20px; float: left;
                                            padding-bottom: 33px;">
                                            <div style="float: left; height: 35px; width: 100%;">
                                                <p style="padding-top: 10px; width: 200px; float: left; font-size: 14px;">
                                                    Use Share Reward Points?
                                                </p>
                                                <p style="font-size: 10px; padding-top: 0px; width: 170px; float: right; padding-right: 30px;
                                                    line-height: 15px;">
                                                    Avallable
                                                    <label id="labSharePoints">
                                                        <%=_sharePoint%></label>
                                                    points.<br />
                                                    Redemption Value:$<label id="labSharePointsMoney"><%=_sharePointMoney%></label></p>
                                            </div>

                                            <div style="width:390px; float:left; color:#ff0000;">
                                                Can	only redeem	up to 15% of the total purchase amount!
                                                </div>
                                            <div style="float: left;">
                                                <input type="text" placeholder="Enter $ amount" id="txtSharePointMoney" onchange="ApplySharePoint()" class="form-control margin-bottom-10"
                                                    style="width: 190px;" />&nbsp;&nbsp;
                                                <input type="button" value="Apply All" onclick="ApplyAllSharePoint()" class="btn-u btn-u-sea-shop"
                                                    style="width: 100px;" />
                                                <script type="text/javascript">
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
                                                            var a = getTotalMoney();
                                                            var b = parseFloat(a) - parseFloat(_limit);
                                                            $("#labPayMoney2").html(b.toFixed(2));
                                                        } else {
                                                            $("#txtSharePointMoney").val(pointMoney);
                                                            //$("#labDiscount").html("-" + pointMoney);
                                                            setTotalDiscount(pointMoney);
                                                            //reduct total
                                                            var a = getTotalMoney();
                                                            var b = parseFloat(a) - parseFloat(pointMoney);
                                                            $("#labPayMoney2").html(b.toFixed(2));
                                                        }
                                                    }
                                                    function ApplyAllSharePoint() {
                                                        var pointMoney = Number($("#labSharePointsMoney").text());
                                                        var orderTotal = Number($("#labPrdMoney").text());  //User Sub Total
                                                        if (pointMoney < 0) pointMoney = 0;
                                                        //if >15%
                                                        var _limit = Math.round(100*orderTotal * 0.15) /100; //Max
                                                        if (pointMoney > _limit) {
                                                            $("#txtSharePointMoney").val(_limit);
                                                            //$("#labDiscount").html("-" + _limit);
                                                            setTotalDiscount(_limit);
                                                            //reduct total
                                                            var a = getTotalMoney();
                                                            var b = parseFloat(a) - parseFloat(_limit);
                                                            $("#labPayMoney2").html(b.toFixed(2));
                                                        } else {
                                                            $("#txtSharePointMoney").val(pointMoney);
                                                            //$("#labDiscount").html("-" + pointMoney);
                                                            setTotalDiscount(pointMoney);
                                                            //reduct total
                                                            var a = getTotalMoney();
                                                            var b = parseFloat(a) - parseFloat(pointMoney);
                                                            $("#labPayMoney2").html(b.toFixed(2));
                                                        }
                                                    }
                                                </script>
                                            </div>
                                            <!--div style="width:390px;float:left;color:#ff0000;">
                                            Can	only redeem	up to 15% of the total purchase amount!
                                            </div-->
                                            </td>
                                    </tr>
                                    
                                    
                                     <!-- Add by Long for share point redeem EOF-->
                                    <%--<tr id="tr2">
                                       <td colspan="2">Have promotional code?</td>
                                   </tr>--%>
                                </tbody>
                            </table>
                        </div>
                        <div class="col-sm-3 col-sm-offset-5">
                            <ul class="list-inline total-result">
                                <li>
                                    <h4>
                                        Sub-Total:</h4>
                                    <div class="total-result-in">
                                        <span>$<label id="labPrdMoney"></label></span>
                                    </div>
                                </li>
                                <li id="trTax">
                                    <h4>
                                        Tax&nbsp;<label id="labTaxRate" style="display:none;">
                                            0%</label>:</h4>
                                    <div class="total-result-in">
                                        <span>$<label id="labTax">0.00</label></span>
                                    </div>
                                </li>
                                <li id="trTaxGST">
                                    <h4>
                                        GST&nbsp;<label id="labTaxGSTRate" style="display:none;">
                                            0%</label>:</h4>
                                    <div class="total-result-in">
                                        <span>$<label id="labTaxGST" >0.00</label></span>
                                    </div>
                                </li>
                                <li id="trTaxHST">
                                    <h4>
                                        HST&nbsp;<label id="labTaxHSTRate" style="display:none;">
                                            0%</label>:</h4>
                                    <div class="total-result-in">
                                        <span>$<label id="labTaxHST">0.00</label></span>
                                    </div>
                                </li>
                                <li id="trTaxQST">
                                    <h4>
                                        QST&nbsp;<label id="labTaxQSTRate" style="display:none;">
                                            0%</label>:</h4>
                                    <div class="total-result-in">
                                        <span>$<label id="labTaxQST">0.00</label></span>
                                    </div>
                                </li>
                                <li>
                                    <h4>
                                        Shipping:</h4>
                                    <div class="total-result-in">
                                        <span class="text-right">$<label id="lablogistics2">0.00</label></span>
                                    </div>
                                </li>
                                <li>
                                    <h4>
                                        Discount:</h4>
                                    <div class="total-result-in">
                                        <span class="text-right">$<label id="labDiscount">0.00</label></span>
                                    </div>
                                </li>
                                <li class="divider"></li>
                                <li class="total-price">
                                    <h4>
                                        Total:</h4>
                                    <div class="total-result-in">
                                        <span>$<label id="labPayMoney2">
                                            </label>
                                        </span>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="row" style="text-align: right;">
                        <div style="line-height: 24px; color: #bf4547; padding: 5px 0; text-align: right;
                            width: 100%;">
                            <!--
                            *NOTICE: If your order contains TEST-SALE item(s) --- Test-Sale items have a test
                            period of 60 days.
                            <br />
                            If item(s) does not reach the Test-Sale goal, your order for that item(s) will be
                            cancelled and refunded 100%.
                            <br />
                            If your order contains BUY NOW item(s) --- Buy Now items do have an extended delivery
                            time during our initial launching stage.
                            <br />
                            Your order WILL be fulfilled, but longer lead-time will apply.
                            <br />-->
<div style="display:none" id="divTestSaleAgreement">
THANK YOU!  By supporting Tweebaa TEST-SALE PRODUCTS, you are helping our members earn rewards…and helping us bring unique, new products to our Shop!
<br />
You already know this…but our attorneys require us to mention it again. 
<br />
Test-Sale items have a test period of up to 60 days to reach a target sales number, and delivery may take up to 90 days total. 
<br /> If you order an item that does NOT reach the target, your order for that item will be cancelled and you will receive 100% refund. 
<br /> In the meantime, you can cancel any Test-Sale order up until the day we actually ship.
 <br />
Please click this box to acknowledge the Test-Sale lead time
                            <label>
                                <input type="checkbox" id="Acknowledged" style="vertical-align: middle; position: relative;  width:20px;
    height:20px;
    background:white;
    border-radius:5px;
    border:2px solid #555;
                                    top: -2px;" />Acknowledged
                            </label>
 <br />
</div>
<!--
<div id="divTerms"><strong>Select "Agree & Proceed to Payment" below to acknowledge these terms:</strong></div>
  -->                       

                        </div>
                        
                        <div class="row">
                                     <div class="col-sm-6 txt-left"><p class="color-blue"><strong> For your convenience, we accept both Paypal and Credit Card*</strong></br>
                                      *Credit Card payment will be processed by Paypal, Paypal account is not necessary</p>
                                     </div>
                        <div class="col-sm-6">
                        
                        <p style="color:#ff0000">The Tweebot estimated shipping date is Nov. 30 ,2015</p>

                        <div style="padding-top:11px;">
                        <a href="javascript:void(0);" class="gotoPay rounded" id="btnCheckout">Confirm & Process to Payment
                        <!--
                            <img src="https://www.paypalobjects.com/webstatic/en_US/i/buttons/cc-badges-ppmcvdam.png"
                                alt="Buy now with PayPal" class="gotoPay" />
                                -->
                        </a>
                        </div>
                        <div style="padding-top:0px;">
                        <a href="javascript:void(0);" class="returnCar rounded" onclick="GoBack()">Back to Cart</a>
                        </div>
                 </div>

                        </div>
                    </div>
                </div>
            </div>
            </form>
        </div>
        <!--/end container-->
    </div>
    <!--=== End Content Medium Part ===-->
    <!-- JS Global Compulsory -->
    <script src="../plugins/jquery/jquery.min.js"></script>
    <script src="../plugins/jquery/jquery-migrate.min.js"></script>
    <script src="../plugins/bootstrap/js/bootstrap.min.js"></script>
    <!-- JS Implementing Plugins -->
    <script src="../plugins/back-to-top.js"></script>
    <script src="../plugins/sky-forms/version-2.0.1/js/jquery.validate.min.js"></script>
    <script src="../plugins/jquery-steps/build/jquery.steps.js"></script>
    <!-- Master Slider -->
    <script src="../plugins/master-slider/quick-start/masterslider/masterslider.min.js"></script>
    <script src="../plugins/master-slider/quick-start/masterslider/jquery.easing.min.js"></script>
    <!-- Scrollbar -->
    <script src="../plugins/scrollbar/src/jquery.mousewheel.js"></script>
    <script src="../plugins/scrollbar/src/perfect-scrollbar.js"></script>
    <script src="../plugins/jquery.parallax.js"></script>
    <!-- JS Customization -->
    <script src="../js/custom.js"></script>
    <!-- JS Page Level -->
    <script src="../js/shop.app.js"></script>
    <script src="../js/forms/page_login.js"></script>
    <script src="../js/plugins/stepWizard.js"></script>
    <script src="../js/forms/product-quantity.js"></script>
    <script type="text/javascript" src="../js/plugins/style-switcher.js"></script>
    <script>
        jQuery(document).ready(function () {
            App.init();
            Login.initLogin();
           // StepWizard.initStepWizard();
            StyleSwitcher.initStyleSwitcher();

        });
</script>
    <!--[if lt IE 9]>
    <script src="../plugins/respond.js"></script>
    <script src="../plugins/html5shiv.js"></script>
    <script src="../js/plugins/placeholder-IE-fixes.js"></script>
<![endif]-->

 <script type="text/javascript">

     function CancelChangeAddress() {
         $(".saved-address").show();
         $(".shop-address").hide();
     }

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
     //点击结算
     $(".gotoPay").click(function (event) {

         $(".gotoPay").html("Encrypting and processing");
         $(".gotoPay").attr("disabled", "disabled");
         $("#btnCheckout").addClass("btnDisabled");
         //Add by Long to verify Shipping Country 
         /*
         var iVerify = 0;
         for (i = 0; i < iTotalProduct; i++) {
         var shipTo = $("#shipToCountry_" + i).val();
         var labCountryID = $("#labCountryID").html();
         var _data = "{ action:'" + "check_shipping_country" + "',shipToId:'" + shipTo + "',CountryID:'" + labCountryID + "'}";
         $.ajax({
         type: "POST",
         url: '/AjaxPages/shopCartAjax.aspx',
         data: _data,
         async: false,
         success: function (msg) {
         if (msg == 0) {
         //how to get user id
         ExtraShippingHandleEx(products_in_cart[i], sku_in_cart[i], products_name_in_cart[i]);
         //alert("Your cart contains item(s) that are not currently available for shipment to your country.\n Product name: " + products_in_cart[i] + " \n Please remove these item(s) from your cart in order to proceed. You may contact us at service@tweebaa.com for a shipping quote (on the item/s removed) to your destination.");
         iVerify = 1;
         EnableGotoPayButton();
         return;
         }

         },
         error: function (msg) {
         //alert("Delete failed");
         }
         });
         }
         if (iVerify == 1) return;*/
         var iVerify = 0;
         var CustomShippingFee = 0;
         for (i = 0; i < iTotalProduct; i++) {
             var _data = "{ action:'" + "check_shipping_country_ex" + "',proId:'" + products_in_cart[i] + "',RulesID:'" + rulesID_in_cart[i] + "',prosku:'" + sku_in_cart[i] + "'}";
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
                         alert("This item has shipping country limited.\n  Please setup your shipping address first.");
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
         if (iVerify == 1) return;
         ////////////////////////Add by Long to verify Shipping Country EOF


         var addressId = $("#hidAddressId").val();
         if (addressId == "" || addressId == null) {
             alert("Please fill and save your delivery address！");
             return;
         }
         if (document.getElementById("Acknowledged").checked == false) {
             alert("Please Acknowledge the reminder ！");
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
             alert("Your input amount of shopping points is invalid, cannot be larger than or equal to the total amount or redemption value.");
             return;
         }
         if (tweebucks >= orderTotal || tweebucks > sumTweebucks) {
             alert("Your input tweebucks amount is invalid, cannot be larger than  or equal to the total amount or total tweebucks.");
             return;
         }

         ////Add by Long for Share Points Redeem
         var sharePointMoney = $("#txtSharePointMoney").val();
         var sumSharePoint = parseFloat($("#labSharePointsMoney").text());
         if (sharePointMoney >= orderTotal || sharePointMoney > sumSharePoint) {
             alert("Your input Share Point amount is invalid, cannot be larger than  or equal to the total amount or total Share Points.");
             return;
         }
         ////Add by Long for Share Points Redeem EOF
         PayPalPay();

     });

     //支付方式里面的 去支付
     $(".payment-methods .gotoPay").click(function (event) {
         $(".payment-methods").hide()    
         if ($("#ckbPay1").attr("checked")) {
             AliyPay(); //支付宝支付
         }
         if ($("#ckbPay2").attr("checked")) {
             PayPalPay(); //paypal支付
         }
     });


     //增加地址
     $(".add-new-address > a").click(function (event) {
         $(".greybox,.add-new-address-box").show();
         $(".add-new-address-box").find('h2').text("Add Delivery Address")
         $("#btnSave").unbind("click")
         $("#btnSave").bind("click", function () { AddAddress() });
         ClearForm();
         return false;
     });
   
     //编辑收货地址
     $(".change-address-btn").live('click', function (event) {
         $(".add-new-address-box").find('h2').text("Edit Delivery Address")
         $(".greybox,.add-new-address-box").show();
         return false;
     });

     function GoBack() {
         window.location.href = "../Product/shopCart.aspx";
     }
/*
$( document ).ready(function() {
    <% if (_IsGuestChecout)
        { %>
                    $(".saved-address").css("visibility","hidden");
                    $(".shop-address").css("visibility","visible");
    <% }
        else
        { %>
                    $(".saved-address").css("visibility","visible");
                    $(".shop-address").css("visibility","hidden");
        <%} %>
});
*/
    </script>
    <script>
        function UseTweebuck() {
           
            $("#lab1").show();
            $("#lab2").show();
            $("#labTweebucks").show();
            $("#txtUse").show();
        }
        function chgTweebuck() {
            var used = $("#txtUse").val();
            var sum = Number($("#labTweebucks").text());
            var orderTotal = Number($("#labPayMoney2").text());
            if (used > sum || used > orderTotal) {
                $("#txtUse").val("")
                return;
            }
            if (used <= sum && used > orderTotal) {
                $("#txtUse").val("")
                return;
            }
        }
    </script>


</asp:Content>
