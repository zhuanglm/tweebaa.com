﻿var picPath = "https://tweebaa.com/";
var cartids = "";
var orderNo = "";
var iTotalProduct = 0;  // total number products in the shopping cart
var dropShipperFlatShipFeeTotalPrice = 0;  // total merchandise price of drop-shippers for flat shipping fee, do not include customer free shipping items
var dropShipperFlatShipFee = -1;           // drop shipper flat ship fee

var hasTestSaleItem = 0; //看看是否存在TestSale Item

// Create Base64 Object
var Base64 = { _keyStr: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=", encode: function (e) { var t = ""; var n, r, i, s, o, u, a; var f = 0; e = Base64._utf8_encode(e); while (f < e.length) { n = e.charCodeAt(f++); r = e.charCodeAt(f++); i = e.charCodeAt(f++); s = n >> 2; o = (n & 3) << 4 | r >> 4; u = (r & 15) << 2 | i >> 6; a = i & 63; if (isNaN(r)) { u = a = 64 } else if (isNaN(i)) { a = 64 } t = t + this._keyStr.charAt(s) + this._keyStr.charAt(o) + this._keyStr.charAt(u) + this._keyStr.charAt(a) } return t }, decode: function (e) { var t = ""; var n, r, i; var s, o, u, a; var f = 0; e = e.replace(/[^A-Za-z0-9\+\/\=]/g, ""); while (f < e.length) { s = this._keyStr.indexOf(e.charAt(f++)); o = this._keyStr.indexOf(e.charAt(f++)); u = this._keyStr.indexOf(e.charAt(f++)); a = this._keyStr.indexOf(e.charAt(f++)); n = s << 2 | o >> 4; r = (o & 15) << 4 | u >> 2; i = (u & 3) << 6 | a; t = t + String.fromCharCode(n); if (u != 64) { t = t + String.fromCharCode(r) } if (a != 64) { t = t + String.fromCharCode(i) } } t = Base64._utf8_decode(t); return t }, _utf8_encode: function (e) { e = e.replace(/\r\n/g, "\n"); var t = ""; for (var n = 0; n < e.length; n++) { var r = e.charCodeAt(n); if (r < 128) { t += String.fromCharCode(r) } else if (r > 127 && r < 2048) { t += String.fromCharCode(r >> 6 | 192); t += String.fromCharCode(r & 63 | 128) } else { t += String.fromCharCode(r >> 12 | 224); t += String.fromCharCode(r >> 6 & 63 | 128); t += String.fromCharCode(r & 63 | 128) } } return t }, _utf8_decode: function (e) { var t = ""; var n = 0; var r = c1 = c2 = 0; while (n < e.length) { r = e.charCodeAt(n); if (r < 128) { t += String.fromCharCode(r); n++ } else if (r > 191 && r < 224) { c2 = e.charCodeAt(n + 1); t += String.fromCharCode((r & 31) << 6 | c2 & 63); n += 2 } else { c2 = e.charCodeAt(n + 1); c3 = e.charCodeAt(n + 2); t += String.fromCharCode((r & 15) << 12 | (c2 & 63) << 6 | c3 & 63); n += 3 } } return t } }

$(document).ready(function () {

    //clear the cookie first
    ClearCookieCheckoutCookie();
    //
    var Request = new Object();
    Request = GetRequest();
    cartids = Request["cartids"];
    orderNo = Request["orderNo"];
    //LoadLogistics(); //收货地址
    //    if (cartids == null || cartids == "") {
    //        LoadOder();
    //        return;
    //    }
    if (orderNo != null || orderNo == "") {
        //$(".returnCar").hide();
        LoadOder();
        return;
    }
    LoadCheckCart();

});

function GetProductShipToCountryFree(sCountryID, sRuleID) {
    var _data = "{ action:'GetProductShipToCountryFree'," + "countryid:'" + sCountryID + "'," + "ruleid:'" + sRuleID + "'}";
    var sRetVal = "0";  // not free
    $.ajax({
        type: "POST",
        url: '/AjaxPages/shopCartAjax.aspx',
        data: _data,
        async: false,
        success: function (resu) {
            sRetVal = resu;
            return ;
        },
        error: function (msg) {
            alert("Failed to get product ship to country info");
        }
    });
    return sRetVal;
}


function GetShipFeeListByWeight(weight, countryid, zip) {
    var _data = "{ action:'GetShipFeeListByWeight'," + "weight:'" + weight + "'," + "countryid:'" + countryid + "'," + "zip:'" + zip + "'}";
    var retVal = "";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/shopCartAjax.aspx',
        data: _data,
        async: false,
        success: function (resu) {
            retVal = resu;
            return ;
        },
        error: function (msg) {
            alert("Failed to get shipping fee!");
        }
    });
    return retVal;
}

function GetDropShipperShipFeeList(countryid, totalPrice, shipfromid) {
    var _data = "{ action:'GetDropShipperShipFeeList'," + "countryid:'" + countryid + "'," + "totalprice:'" + totalPrice + "'," + "shipfromid:'" + shipfromid + "'}";
    //alert(_data);
    var retVal = "";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/shopCartAjax.aspx',
        data: _data,
        async: false,
        success: function (resu) {
            retVal = resu;
            return;
        },
        error: function (msg) {
            alert("Failed to get drop-shipper shipping fee!");
        }
    });
    return retVal;
}

function GetDropShipperFlatShipFee(countryid, totalPrice) {
    var _data = "{ action:'GetDropShipperFlatShipFee'," + "countryid:'" + countryid + "'," + "totalprice:'" + totalPrice + "'}";
    //alert(_data);
    var retVal = "";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/shopCartAjax.aspx',
        data: _data,
        async: false,
        success: function (resu) {
            retVal = resu;
            return;
        },
        error: function (msg) {
            alert("Failed to get drop-shipper flat shipping fee!");
        }
    });
    return retVal;
}





function GetProvinceTax(countryid, provinceid) {
    var _data = "{ action:'GetProvinceTax'," + "countryid:'" + countryid + "'," + "provinceid:'" + provinceid + "'}";
    var retVal = "";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/shopCartAjax.aspx',
        data: _data,
        async: false,
        success: function (resu) {
            retVal = resu;
            return;
        },
        error: function (msg) {
            alert("Failed to get province tax!");
        }
    });
    return retVal;
}



function SetShipMethod(cartid, prdid, shipMethodID, shipFee) {
    var _data = "{ action:'SetShipMethod'," + "cartid:'" + cartid + "', prdid:'" + prdid + "', shipmethodid:'" + shipMethodID + "',shipfee:'"+ shipFee + "'}";
    var retVal = "";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/shopCartAjax.aspx',
        data: _data,
        async: false,
        success: function (resu) {
            retVal = resu;
            return;
        },
        error: function (msg) {
            alert("Failed to set shipping method!");
        }
    });
    return retVal;
}

function ChangeShipMethod(cartid, shipMethodIDAndUnitShipFee, prdid, idx, countryID, provinceID, shipPartnerID) {

    // shipMethodID and unit shipping fee is seperated by a space
    var iPos = shipMethodIDAndUnitShipFee.indexOf(' ');
    var sShipMethodID = shipMethodIDAndUnitShipFee.substring(0, iPos);
    var sUnitShipFee = shipMethodIDAndUnitShipFee.substring(iPos+1, shipMethodIDAndUnitShipFee.length);
    var qty = $("#qty" + idx.toString()).html();

    var shipfee = 0;
    if (shipPartnerID == 3)  // drop-shipper
        shipfee = sUnitShipFee;
    else
        shipfee = sUnitShipFee * qty;
    
    shipfee = "$" + shipfee.toFixed(2);
    $("#shipfee" + idx.toString()).html(shipfee);
    CalcTotal(countryID, provinceID);
    SetShipMethod(cartid, prdid, sShipMethodID, shipfee);
}

function CalcTotal(countryID, provinceID) {

    // when checkout as guest, no address at first


    dropShipperFlatShipFee = 0;
    if (countryID != "") {
        if (dropShipperFlatShipFeeTotalPrice > 0) {
            dropShipperFlatShipFee = GetDropShipperFlatShipFee(countryID, dropShipperFlatShipFeeTotalPrice);
        }    
    }

    // total shipping fee is the sum of 
    // 1) drop-shipper flat shipping fee
    // 2) all shipping fee of other shipping partners
    var fShipFeeSum = parseFloat(dropShipperFlatShipFee);  // set to the drop-shipper flat shipping fee
    
    // add other shipping partner's shipping fee
    var fShipFee = 0;
    var sShipPartnerID = -1;
    for (var i = 0; i < iTotalProduct; i++) {
        sShipPartnerID = $("#shippartnerid" + i.toString()).html();
        if (sShipPartnerID != "3") { // 3: drop-shipper
            var kkk=$("#shipfee" + i.toString()).html();
            if(kkk==undefined){
                //没有??
            }else{
                fShipFee = parseFloat(kkk.replace("$", ""));
                fShipFeeSum += fShipFee;
            }
        } else if (sShipPartnerID == -1) { //Add by Long 这是Custom Shipping
            fShipFee = parseFloat($("#custom_shipping_fee" + i.toString()).html().replace("$", ""));
            fShipFeeSum += fShipFee;

        }
    }
    var fPriceSum = parseFloat($("#labPrdMoney").html().replace("$",""));

    // amount for calculate the tax
    var fTaxBase = fShipFeeSum + fPriceSum;

    // get province tax of the country
    var provinceTax = 0;
    if (!isNaN(parseInt(countryID))) {
        provinceTax = GetProvinceTax(countryID, provinceID);
    }
    // init tax and tax rates
    var fTaxRate = 0.0;
    var fTaxRateGST = 0.0;
    var fTaxRateHST = 0.0;
    var fTaxRateQST = 0.0;

    var fTaxTotal = 0.0;
    var fTaxGST = 0.0;
    var fTaxHST = 0.0;
    var fTaxQST = 0.0;

    // set rate if get the rate from server seccesfully
    if (provinceTax != "" && provinceTax != "0") {
        var objTaxArr = eval("(" + provinceTax + ")");
        var objTax = objTaxArr[0];
        fTaxRateGST = objTax.ProvinceTax_GST;
        fTaxRateHST = objTax.ProvinceTax_HST;
        fTaxRateQST = objTax.ProvinceTax_QST;
    }

    // calculate/show/show tax of each country 
    if (countryID == 2) // Canada 
    {
        fTaxGST = parseFloat((fTaxBase * fTaxRateGST).toFixed(2));
        fTaxHST = parseFloat((fTaxBase * fTaxRateHST).toFixed(2));
        fTaxQST = (fTaxGST + fTaxHST + fTaxBase) * fTaxRateQST;
        fTaxQST = parseFloat(fTaxQST.toFixed(2));

        fTaxTotal = fTaxGST + fTaxHST + fTaxQST;

        // show and hide
        $("#trTax").hide();
        if (fTaxRateGST > 0) { $("#trTaxGST").show(); $("#labTaxGSTRate").show(); }
        else { $("#trTaxGST").hide(); $("#labTaxGSTRate").hide(); }

        if (fTaxRateHST > 0) { $("#trTaxHST").show(); $("#labTaxHSTRate").show(); }
        else { $("#trTaxHST").hide(); $("#labTaxHSTRate").hide(); }

        if (fTaxRateQST > 0) { $("#trTaxQST").show(); $("#labTaxQSTRate").show(); }
        else { $("#trTaxQST").hide(); $("#labTaxQSTRate").hide(); }
    }
    else {   // other countries
        // show and hide
        $("#trTax").show();
        $("#labTaxRate").hide();  // do not display the 0% rate
        $("#trTaxGST").hide();
        $("#trTaxHST").hide();
        $("#trTaxQST").hide();
    }

    // set the tax rate and tax value
    $("#labTaxRate").text((fTaxRate * 100).toString() + "%");
    $("#labTaxGSTRate").text((fTaxRateGST * 100).toString() + "%");
    $("#labTaxHSTRate").text((fTaxRateHST * 100).toString() + "%");
    $("#labTaxQSTRate").text((fTaxRateQST * 100).toString() + "%");

    $("#labTax").text(fTaxTotal.toFixed(2));
    $("#labTaxGST").text(fTaxGST.toFixed(2));
    $("#labTaxHST").text(fTaxHST.toFixed(2));
    $("#labTaxQST").text(fTaxQST.toFixed(2));

    var fOrderTotal = fPriceSum + fShipFeeSum + fTaxTotal;
    
    $("#lablogistics1").html(fShipFeeSum.toFixed(2));
    $("#lablogistics2").html(fShipFeeSum.toFixed(2));
    $("#labTax").html(fTaxTotal.toFixed(2));
    $("#labPayMoney").html(fOrderTotal.toFixed(2));
    $("#labPayMoney2").html(fOrderTotal.toFixed(2));
}

//在收货地址页面显示要结算的购物车清单
var payMoney = "";
function LoadCheckCart() {
    var _data = "{ action:'query'," + "cartids:'" + cartids + "'}";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/shopCartAjax.aspx',
        async: false,
        data: _data,
        success: function (resu) {
            var thead = '<tr><th class="pro-infor" colspan="2" >Product Information</th><th class="pro-num">Quantity</th><th class="pro-price">Unit Price</th><th class="pro-zt">Shipping Method</th><th style="display:none" class="pro-price">Shipping Fee</th><th class="pro-total">Sub-Total</th><th style="display:none">Shipping Partner</th></tr>';
            if (resu == "-1") {
                // alert("Please login！");
                // return;
            }
            else if (resu == "") {
                $("#tableOrder").empty();
                $("#tableOrder").append(thead);
                return;
            }
            else if (resu != "") {
                payMoney = "";

                var obj = eval("(" + resu + ")");
                $("#labCount").text(obj.length);
                $("#labCount2").text(obj.length);
                $("#tableOrder").empty();
                //$("#tableOrder").append(thead);
                iTotalProduct = obj.length;
                var countryID = $("#labCountryID").text();
                var provinceID = $("#labProvinceID").text();
                var zip = $("#labZip").text();
                for (var i = 0; i < obj.length; i++) {
                    var cart = obj[i];
                    var cartguid = "'" + cart.guid + "'";
                    var prdguid = "'" + cart.prdguid + "'";
                    var img = (picPath + cart.fileurl).replace("big", "small");
                    var salseState = "";
                    var money = "";
                    var price = 0;
                    var linkUrl = "";

                    //var shipToCountry = cart.ShipFrom_ID; //Add by Long for shipping limition  commented by Jack Cao 2016/01/12

                    products_name_in_cart[i] = cart.name;
                    products_in_cart[i] = cart.prdguid;
                    rulesID_in_cart[i] = cart.proRulesID;
                    sku_in_cart[i] = cart.prosku;
                    // set ship method
                    var shipMethodID = -1;  // tweebaa default ship method ID;
                    if (cart.ShipMethod_ID != null && cart.ShipMethod_ID != "") {
                        shipMethodID = cart.ShipMethod_ID;
                    }

                    // set link url, price and money
                    if (cart.wnstat == "2") {
                        salseState = "&nbsp;<span style='color:red'>(Test-Sale)</span>";
                        linkUrl = "../Product/presaleBuy.aspx?id=" + cart.prdguid
                        price = cart.saleprice.toFixed(2);
                        money = cart.premoney;
                        hasTestSaleItem++;
                        //Show 
                        $("#divTestSaleAgreement").show();
                        $("#divTerms").hide();
                    }
                    else if (cart.wnstat == "3") {
                        //salseState = "Buy Now";
                        linkUrl = "../Product/saleBuy.aspx?id=" + cart.prdguid
                        price = cart.price.toFixed(2);
                        money = cart.money;
                        $('#Acknowledged').prop('checked', true);
                    }

                    ///////////////////////////////////
                    //////检查这个产品是否在Shipping List
                    //proRulesID
                    var iVerify = 0;
                    var CustomShippingFee = 0;
                    //Modify by Long 2016/01/20 as shipping can be different country countryID
                    var _data = "{ action:'" + "check_shipping_country_ex2" + "',CountryId:'" + countryID + "',proId:'" + cart.prdguid + "',RulesID:'" + cart.proRulesID + "',prosku:'" + cart.prosku + "'}";
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
                            CustomShippingFee = msg;

                        },
                        error: function (msg) {
                            //alert("Delete failed");
                        }
                    });

                    if (iVerify == 1) return;
                    //console.log("custom shipping fee=" + CustomShippingFee);
                    /////////////////////////////

                    var shipFeeHtml = "";
                    var shipFee = 0;
                    // get shipping fee list
                    if (CustomShippingFee > 0) {
                        //如果是Custom Shipping，则不需要再获取Shipping Fee了
                        shipFee = parseFloat(CustomShippingFee);
                        shipFeeHtml = '<select><option value="' + CustomShippingFee + '" selected="">Custom Shipping Fee </option></select>';
                    } else {
                        var shipFeeList = "";
                        // when check out as guest, no addres for country and zip at first
                        if (!isNaN(parseInt(countryID))) {
                            if (cart.ShipPartner_ID == 3) {  // 1: fosdicks 2: EOrder 3:Drop-shipper
                                shipFeeList = GetDropShipperShipFeeList(countryID, money, cart.ShipFrom_ID);

                                // do not include price if it is customer free 
                                // if (cart.IsCustomerFreeShip != 1) {
                                //     dropShipperFlatShipFeeTotalPrice += money;
                                // }
                            }
                            else
                                shipFeeList = GetShipFeeListByWeight(cart.proweight, countryID, zip);
                        }

                        if (shipFeeList != null && shipFeeList != "" && shipFeeList != "0") {
                            //alert(shipFeeList);
                            var shipFeeObj = eval("(" + shipFeeList + ")");
                            //alert(shipFeeObj);
                            if (shipFeeObj != null) {
                                // set default method as the first method
                                var bFind = false;
                                for (var j = 0; j < shipFeeObj.length; j++) {
                                    if (shipFeeObj[j].ShipMethod_ID == shipMethodID) {
                                        bFind = true;
                                        break;
                                    }
                                }
                                if (!bFind) shipMethodID = shipFeeObj[0].ShipMethod_ID;

                                // get the ship to country free info of this product
                                var sProductShipToCountryFree = GetProductShipToCountryFree(countryID, cart.proRulesID);


                                // out put item list
                                for (var j = 0; j < shipFeeObj.length; j++) {

                                    // special request for tweebot 2015-11-17 
                                    // set shipping fee to 7.95 for Tweebaa-Standard 2-7 Business Days ( shipmethod = 1)
                                    //if (shipFeeObj[j].ShipMethod_ID == "1" && cart.prdguid == '670bdf26-a935-4643-ac0e-ba24c2249107') {
                                    //    shipFeeObj[j].ShipFee_Total = 7.95;
                                    //}

                                    //if (j == 0) {
                                    //    shipFee = shipFeeObj[j].ShipFee_Total * cart.quantity;
                                    //    selected = " selected ";
                                    //}

                                    if (sProductShipToCountryFree == "0" && shipFeeObj[j].ShipMethod_ID == "1") // not free shipping to this country
                                    {
                                        shipFeeObj[j].ShipMethod_IsFree = 0;  // free shipping
                                        shipFeeObj[j].ShipMethod_Name = "Standard Shipping - up to 10 business days";
                                    }

                                    // special for gazoos 2016-01-11 
                                    // set shipping fee to 5.50 for Tweebaa-Standard 2-7 Business Days ( shipmethod = 1)
                                    if (shipFeeObj[j].ShipMethod_ID == "1" && cart.prdguid == 'a754a098-9676-4ed9-b85d-cbc585ff74b7') {
                                        shipFeeObj[j].ShipFee_Total = 5.50;
                                        ////shipFeeObj[j].ShipMethod_IsFree = 0;  // not free shipping
                                        ////shipFeeObj[j].ShipMethod_Name = "Tweebaa-Standard up to 10 business days";
                                    }


                                    var selected = "";

                                    if (shipFeeObj[j].ShipMethod_IsFree == 1)  // free 
                                        shipFeeObj[j].ShipFee_Total = 0.00;

                                    if (shipFeeObj[j].ShipMethod_ID == shipMethodID) {
                                        if (cart.ShipPartner_ID == 3) { // drop shipper

                                            shipFee = shipFeeObj[j].ShipFee_Total;

                                            if (shipFeeObj[j].ShipMethod_IsFree != 1 && cart.IsCustomerFreeShip != 1) {
                                                dropShipperFlatShipFeeTotalPrice += money;
                                            }
                                        }
                                        else
                                            shipFee = shipFeeObj[j].ShipFee_Total * cart.quantity;

                                        // set ship fee to zero if it is a customer free ship
                                        //if (cart.IsCustomerFreeShip == 1)
                                        //    shipFee = 0;
                                        selected = " selected ";
                                    }

                                    // ship method name
                                    var shipMethodName = "";
                                    if (shipFeeObj[j].ShipMethod_IsFree == 1) { // free  
                                        shipMethodName = shipFeeObj[j].ShipMethod_Name;
                                        shipFee = 0;
                                    }
                                    else {
                                        if (cart.ShipPartner_ID == 3) { // drop-shipper 
                                            if (cart.IsCustomerFreeShip == 1) {
                                                // drop-shipper free shipping
                                                shipMethodName = shipFeeObj[j].ShipMethod_Name + " Free Shipping";
                                                shipFee = 0;
                                            }
                                            else
                                                shipMethodName = shipFeeObj[j].ShipMethod_Name;
                                        }
                                        else {
                                            shipMethodName = '$' + shipFeeObj[j].ShipFee_Total.toFixed(2) + ' ea ' + shipFeeObj[j].ShipMethod_Name;
                                        }

                                    }
                                    shipFeeHtml = shipFeeHtml + '<option value="' + shipFeeObj[j].ShipMethod_ID + ' ' + shipFeeObj[j].ShipFee_Total + '"' + selected + '>' + shipMethodName + ' </option>';

                                    // set ship method and shipfee
                                    SetShipMethod(cart.guid, cart.prdguid, shipMethodID, shipFee.toString())

                                }
                                if (shipFeeHtml != "") shipFeeHtml = '<select onchange="ChangeShipMethod(' + cartguid + ', this.value,' + prdguid + ',' + i.toString() + ',' + countryID + ',' + provinceID + ',' + cart.ShipPartner_ID + ')">' + shipFeeHtml + '</select>';
                            }
                        }
                    }

                    orderName += cart.name + ":" + cart.quantity + "; ";
                    quantity += cart.quantity;
                    var off = "";
                    if (cart.estimateprice > cart.salePrice) {
                        off = accSub(cart.estimateprice, cart.salePrice);
                    }

                    var fltMoney = 0.0;
                    if (money.length > 0) {
                        fltMoney = parseFloat(money).toFixed(2);
                    }
                    /*****************
                    var html = '<tr><td class="first"><a href="' + linkUrl + '" class="imglink fr"><img src="' + img + '" alt="" width="55" height="55"/></a><br /><a href="javascript:void(0);" onclick="DeletShopCart(' + cartguid + ')"class="delete fr" >Delete</a></td>'
                    + '<td><div class="des-box"><a href="' + linkUrl + '#">' + cart.name + salseState + '  </a></div><div style="float:left; padding-left:15px;">Color：</div><div style="float:left;width:18px;height:18px;background-color:' + cart.color + '; "></div><div style="clear:both; text-align:left;padding-left:15px;">Specs：' + cart.prorule + '</div></td>'
                    + '<td id="qty' + i.toString() + '" class="pro-num">' + cart.quantity + '</td>'
                    + '<td class="pro-price">$' + price + '</td>'
                    + '<td class="pro-zt">' + shipFeeHtml + '</td>'
                    + '<td id="shipfee' + i.toString() + '" class="pro-price" style="display:none">$' + shipFee.toFixed(2) + '</td>'
                    + '<td class="td pro-total"><strong>$</strong><strong>' + money.toFixed(2) + '</strong></td>'
                    + '<td  id="shippartnerid' + i.toString() + '" style="display:none">' + cart.ShipPartner_ID + '</td></tr>';
                    *****************/

                    if (CustomShippingFee > 0) {
                        //如果这个是Custom Shipping, 则cart.ShipPartner_ID为-1
                        cart.ShipPartner_ID = -1;
                    }
                    var html = '<tr>'
                    + '<td class="product-in-table">'
                    + '<a href="' + linkUrl + '" ><img class="img-responsive" src="' + img + '" alt=""></a>'
                    + '<div class="product-it-in">'
                    + '<h3>' + cart.name + '</h3> '
                    + '<p class="shop-red">' + salseState + '</p>'
                    + '<span class="size-label-s">&nbsp;' + cart.prorule + '&nbsp;</span><span class="color_label_s" style="background-color:' + cart.color + ';"></span>'
                    + '</div>'
                    + '</td>'
                    // changed by jack Cao 2016/01/12 --> do not need the shipToCountry here
                    //+ '<td class="number-box"><span id="qty' + i.toString() + '">' + cart.quantity + '</span><input type="hidden" id="shipToCountry_' + i + '" value="' + shipToCountry + '"/></td>'
                    + '<td class="number-box"><span id="qty' + i.toString() + '">' + cart.quantity + '</span></td>'
                    + '<td id="shipfee' + i.toString() + '" class="pro-price" style="display:none">$' + shipFee.toFixed(2) + '</td>'
                    + '<td>$' + price + '</td>'
                    + '<td class="pro-zt">' + shipFeeHtml + '</td>'
                    + '<td class="shop-black">$' + money.toFixed(2) + '</td>'
                    + '<td  id="shippartnerid' + i.toString() + '" style="display:none">' + cart.ShipPartner_ID + '</td><input type="hidden" id="custom_shipping_fee' + i.toString() + '" value="' + CustomShippingFee + '" />'
                    + '</tr>';

                    $("#tableOrder").append(html);
                    if (cart.wnstat == "2") {
                        payMoney = accAdd(payMoney, cart.premoney);
                    }
                    if (cart.wnstat == "3") {
                        payMoney = accAdd(payMoney, cart.money);
                    }
                }
                $("#labPrdMoney").text(payMoney.toFixed(2));
                CalcTotal(countryID, provinceID);
                //Add by Long 2016/01/21
                GetFreePrdouctClaim();
            }
        },
        error: function (msg) {

        }
    });
}

function GetFreePrdouctClaim() {
    var _data = "{ action:'query_free_product"  + "',cartGuid:'" + escapeHtml(cartids)+ "'}";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/orderAjax.aspx',
        data: _data,
        success: function (resu) {
            if (resu == "0") {
                var iTotal = getTotalMoney();
                $("#labDiscount").html("-" + iTotal.toFixed(2));
                $("#labPayMoney2").html("0.00");
            }
        },
        error: function (msg) {
            alert("Query free product failed");
        }
    });
}

//删除购物车
var deleFlag = false;
function DeletShopCart(cartGuid) {
    if (!confirm(" Confirm to delete the item?")) {
        return;
    }
    var action = "delet";
    var _data = "{ action:'" + action + "',cartGuid:'" + cartGuid + "'}";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/shopCartAjax.aspx',
        data: _data,
        success: function (msg) {
            if (msg == "-1") {
                alert("Please login！");
                return;
            }
            else if (msg == "1") {
                deleFlag = true;
                LoadCheckCart();
                return;
            }
            else if (msg == "0") {
                alert("Delete failed");
                return;
            }
        },
        error: function (msg) {
            alert("Delete failed");
        }
    });
}


//加载订单信息
var guidno = ""; //订单编号*
var orderName = ""; //订单名称*
var quantity = 0;
function LoadOder() {
    var _data = "{ action:'query" + "',orderNo:'" + orderNo + "" + "'}";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/orderAjax.aspx',
        data: _data,
        success: function (resu) {
            if (resu == "-1") {
                //alert("Please login！");
                return;
            }
            else if (resu == "") {
                return;
            }
            else if (resu != "" && resu != "[]") {
                var obj = eval("(" + resu + ")");
                guidno = obj[0].guidno;
                $("#labCount").text(obj.length);
                $("#labCount2").text(obj.length);
                for (var i = 0; i < obj.length; i++) {
                    var order = obj[i];
                    var img = (picPath + order.fileurl).replace("big", "small");
                    var salseState = "";
                    var linkUrl = "";
                    if (order.prdStat == "2") {
                        salseState = "Test-Sale";
                        linkUrl = "../Product/presaleBuy.aspx?id=" + order.prdguid 
                    }
                    else if (order.prdStat == "3") {
                        salseState = "Buy Now";
                        linkUrl = "../Product/saleBuy.aspx?id=" + order.prdguid 
                    }
                    orderName += order.name + ":" + order.quantity+"; ";
                    quantity += order.quantity;
                    var off = "";
                    if (order.estimateprice > order.salePrice) {
                        off = accSub(order.estimateprice, order.salePrice);
                    }
                    var html = '<tr><td class="first"><a href="'+linkUrl+'" class="imglink fr"><img src="' + img + '" alt="" width="55" height="55"/></a></td>'
                    // + '<td><div class="des-box"><a href="#">' + cart.name + '  </a></div><div style="float:left; padding-left:15px;">Color：</div><div style="float:left;width:18px;height:18px;background-color:' + cart.color + '; "></div><div style="clear:both; text-align:left;padding-left:15px;">Specs：' + cart.prorule + '</div></td>'
                              + '<td><div class="des-box"><a href="'+linkUrl+'">' + order.name + ' </a></div><div style="float:left; padding-left:15px;">Color：</div><div style="float:left;width:18px;height:18px;background-color:' + order.color + '; "></div><div style="clear:both; text-align:left;padding-left:15px;">Specs：' + order.prorule + '</div></td>'
                              + '<td class="pro-zt">' + salseState + '</td>'
                              + '<td class="pro-num">' + order.quantity + '</td>'
                              + '<td class="pro-price">' + order.saleprice.toFixed(2) + '</td>'
                              + '<td class="pro-total"><strong>$</strong><strong>' + order.money.toFixed(2) + '</strong></td></tr>';
                    $("#tableOrder").append(html);
                    //payMoney += float.Parse(order.money);
                    payMoney = accAdd(payMoney, order.money);
                }
                $("#labPrdMoney").text(payMoney);
                var sumPay = accAdd(payMoney, curentLogistic, parseFloat($("#labTax").text())).toFixed(2);
                $("#labPayMoney").text(sumPay);
                $("#labPayMoney2").text(sumPay);
            }
        },
        error: function (msg) {

        }
    });
}
//加载物流信息
function LoadLogistics() {
    var _data = "{ action:'query" + "'}";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/expressAjax.aspx',
        data: _data,
        success: function (resu) {
            if (resu == "-1") {
                //alert("Please login！");
                //return;
            }
            else if (resu == "") {
                return;
            }
            else if (resu != "") {
                var obj = eval("(" + resu + ")");
                var payMoney = "";
                var str = "'on'";
                if (obj.length > 0) {
                    $("#lablogistics").text(obj[0].companyname + ' ' + obj[0].expressprice + ' $');                    
                    $("#lablogistics1").text(obj[0].expressprice);
                    $("#lablogistics2").text(obj[0].expressprice);
                    curentLogistic = obj[0].expressprice;
                }
                for (var i = 0; i < obj.length; i++) {
                    var item = obj[i];                    
                    var html = '<li value="' + item.guid + '" onmouseenter=" $(this).addClass(' + str + ')" onmouseleave=" $(this).removeClass(' + str + ')" onclick="LogisticsClick(this,' + item.expressprice + ')">' + item.companyname + ' ' + item.expressprice + ' $</li>';
                    $("#ullogistics").append(html);
                }
            }
        },
        error: function (msg) {

        }
    });
}
var curentLogistic = 0;
function LogisticsClick(li, price) {
    var THIS = $(li);
    THIS.parent().hide();
    $(li).removeClass('on');
    THIS.parent().siblings('h2').text(THIS.text());
    $("#lablogistics1").text(price);
    $("#lablogistics2").text(price);
    curentLogistic = price;
   // alert($("#labTax").text());
    var sumPay = accAdd(payMoney, price, parseFloat($("#labTax").text())).toFixed(2);
    $("#labPayMoney").text(sumPay);
    $("#labPayMoney2").text(sumPay);
}

//支付前创建订单(该方法没用)
var addressId = "";
var ordernum = "";
function CreateOrder() {
    if (addressId == "" || addressId == null) {
        alert("Please fill in delivery address ！");
        return;
    }
    var _data = "{ action:'" + 'add' + "',cartGuids:'" + cartids + "',message:'" + $("#txtMessage").val() + "',addressId:'" + addressId + "'}";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/orderAjax.aspx',
        data: _data,
        dataType: "text",
        success: function (resu) {
            if (resu != "0") {
                ordernum = resu;
               // alert(ordernum);
            }
            else {
                alert("创建订单失败");
                return false;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("创建订单失败");
            return false;
        }
    });

}

//支付宝支付
function AliyPay() {
    var orderMoney = $("#labPayMoney2").text(); //付款金额*
    var orderBody = ""; //订单描述
    var orderWebUrl = "https://tweebaa.com";
    var _data = "{ action:'pay"
                + "',guidno:'" + ordernum
                + "',orderName:'" + orderName
                + "',orderMoney:'" + orderMoney
                + "',orderBody:'" + orderBody
                + "',orderWebUrl:'" + orderWebUrl

                + "',cartGuids:'" + cartids
                + "',message:'" + $("#txtMessage").val()
                + "',addressId:'" + addressId             
                + "'}";
   
    $.ajax({
        type: "POST",
        url: '/AjaxPages/payMoneyAjax.aspx',
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
}

////////////////////
//The following function is add by long to save the checkout information
function ClearCookieCheckoutCookie() {
/*
    $.cookie("checkout_useremail", "");
    $.cookie("checkout_shipping_details", "");


    $.cookie("checkout_order_extra", "");

    $.cookie("checkout_order_details", "");
*/
}

function setCookies() {
    var txtEmail = $("#labEmail").val();
    $.cookie("checkout_useremail", txtEmail);

    var txtShipping = $("#labAddress").val() + "," + $("#labCountry").val();
    $.cookie("checkout_shipping_details", txtShipping);
/*
    var txtSubTotal = $("#labCount").val();
    $.cookie("checkout_sub_total", txtSubTotal);

    var txtShippingCost = $("#lablogistics2").val();
    $.cookie("checkout_shipping_cost", txtShippingCost);

    var txtSaleTax = $("#labTax").val();
    $.cookie("checkout_sale_tax", txtSaleTax);
*/
    var txtOrderExtra = Base64.encode($("#extra_info_table").html());
    $.cookie("checkout_order_extra", txtOrderExtra);

    var txtOderDetails = Base64.encode($("#tableOrderDetails").html());
    $.cookie("checkout_order_total", txtOderDetails);
}

//paypal支付
function PayPalPay() {  
   // setCookies();
    var orderMoney = $("#labPayMoney2").text(); //付款金额*
    var prdMoney = $("#labPrdMoney").text();//产品金额
    //orderMoney = orderMoney - Number($("#txtUse").val());

    var pointMoney = $("#txtPointMoney").val();
    var tweebucks = $("#txtTweebuck").val();

    //Add by Long for Share Points Redeem
    var sharePointMoney = $("#txtSharePointMoney").val();

    var sumUse = Number(pointMoney) + Number(tweebucks) + Number(sharePointMoney);
    if (sumUse > prdMoney) {
        //alert("Your input amount is invalid, cannot be larger than the total amount.");
        alert("Redeem amount cannot be more than the total amount of the product selling price.");
        return;
    }

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

/*
   url: '/AjaxPages/payMoneyPaypalAjax.aspx',
*/
    $.ajax({
        type: "POST",
        url: '/AjaxPages/payMoneyPaypalAjax.aspx',
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
}

function CreateOrderBeforePayment() {
    // setCookies();
    var orderMoney = $("#labPayMoney2").text(); //付款金额*
    var prdMoney = $("#labPrdMoney").text(); //产品金额
    //orderMoney = orderMoney - Number($("#txtUse").val());

    var pointMoney = $("#txtPointMoney").val();
    var tweebucks = $("#txtTweebuck").val();

    //Add by Long for Share Points Redeem
    var sharePointMoney = $("#txtSharePointMoney").val();

    var sumUse = Number(pointMoney) + Number(tweebucks) + Number(sharePointMoney);
    if (sumUse > prdMoney) {
        //alert("Your input amount is invalid, cannot be larger than the total amount.");
        alert("Redeem amount cannot be more than the total amount of the product selling price.");
        Loading(false);
        return;
    }

    var orderBody = ""; //订单描述
    var orderWebUrl = "https://www.tweebaa.com";
    var orderShipFee = $("#lablogistics2").text();  // total shipping fee
    var orderTax = $("#labTax").text();             // total tax
    var orderTaxGST = $("#labTaxGST").text();
    var orderTaxHST = $("#labTaxHST").text();
    var orderTaxQST = $("#labTaxQST").text();

    var txtUsername = $("#userName").text();
    var txtEmail = $("#labEmail").text();
    var txtShipping = $("#labAddress").html().replace("<br>", " ") + " , " + $("#labCountry").text() + " " + $("#labZip").text();
    var txtOrderExtra = Base64.encode($("#extra_info_table").html());
    var txtOderDetails = Base64.encode($("#tableOrder").html());

    var _data = "{ action:'CreateOrder"
                + "',guidno:'" + orderNo
                + "',orderName:'" + escapeHtml(orderName)
                + "',quantity:'" + quantity
                + "',orderMoney:'" + orderMoney
                + "',tweebuck:'" + $("#txtTweebuck").val()
                + "',pointMoney:'" + $("#txtPointMoney").val()
                + "',sharePointMoney:'" + sharePointMoney //Add by Long for Share Points Redeem
                + "',CouponAmount:'" + $("#hidCouponAmount").val() //Add by Long for Coupon
                + "',CouponCode:'" + $("#txtPromoCode").val() //Add by Long for Coupon
                + "',orderShipFee:'" + orderShipFee
                + "',orderTax:'" + orderTax
                + "',orderTaxGST:'" + orderTaxGST
                + "',orderTaxHST:'" + orderTaxHST
                + "',orderTaxQST:'" + orderTaxQST
                + "',tax_cart:'" + $("#labTax").text()
                + "',cartGuids:'" + escapeHtml(cartids)
                + "',message:'" + $("#txtMessage").val()
                + "',addressId:'" + $("#hidAddressId").val()
                + "',billingaddressId:'" + $("#hidBillingAddressId").val()
                + "',checkout_username:'" + escapeHtml(txtUsername)
                + "',checkout_useremail:'" + txtEmail
                + "',checkout_shipping_details:'" + txtShipping
                + "',checkout_order_extra:'" + txtOrderExtra
                + "',checkout_order_total:'" + txtOderDetails
    //+"',discount_amount:'" + discount_amount;
                + "'}";

    /*
    url: '/AjaxPages/payMoneyPaypalAjax.aspx',
    */
    $.ajax({
        type: "POST",
        url: '/AjaxPages/payMoneyPaypalAjax.aspx',
        data: _data,
        success: function (resu) {
            if (resu == "-1") {
                AlertEx("Create Oder Error ！");
                Loading(false);
                return;
            } else if (resu == "-2") {
                AlertEx("You can not claim Free Product with others ！");
                Loading(false);
                return;
            } else if (resu == "-3") {
                AlertEx("Check Free Product Error!");
                Loading(false);
                return;
            }
            else if (resu == "") {
                AlertEx("Create Oder Error ！");
                Loading(false);
                return;
            }
            else if (resu != "") {
                //window.location.href="/Product/CheckoutPayment.aspx
                // $("#payform").append(resu);
                if (resu.indexOf("|") > 0) {
                    //应该跳转??
                    var res = resu.split("|");
                    $("#hidIsVirtualPay").val(1);
                    $("#hidSerialNo").val(res[1]);
                    $("#hidGuidNo").val(res[0]);
                    $("#frmVirtualPay").submit();
                } else {
                    $("#guidno").val(resu);
                    $("#frmConfirm").submit();
                }
            }
        },
        error: function (msg) {
            alert("Create Oder Error ！");
            Loading(false);
        }
    });
}
//返回购物车
function GoBack() {  
    window.location.href = "shopCart.aspx?cartids=" + cartids;
}

//接收URL参数
/*
function GetRequest() {
    var url = location.search; //获取url中"?"符后的字串
    var theRequest = new Object();
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        strs = str.split("&");
        for (var i = 0; i < strs.length; i++) {
            theRequest[strs[i].split("=")[0]] = (strs[i].split("=")[1]);
        }
    }
    return theRequest;
}*/

function AddShipAddress() {

    var flag = "true";
    var countyid = $("#selectCountry  option:selected").val();
    var provinceid = $("#selectProvince  option:selected").val();
    var cityid = ""; // $("#selectCity  option:selected").val();
    var city = $("#txtShipCity").val(); //城市
    var zip = $("#txtShipZip").val(); //
    var address = $("#txtShipAddress").val();
    var address2 = $("#txtShipAddress2").val();
    var username = $("#txtShipName").val().trim();
    var lastName = $("#txtShipLastName").val(); //姓氏
    var phone = $("#txtShipPhone").val();
    var tel = $("#txtShipPhone").val();
    var isfirst = 1;
    //if ($("#ckbDefault").is(":checked")) {isfirst = 1;}

    var bAddressOK = CheckAddress(address);
    var bAddress2OK = CheckAddress(address2);
    if (!bAddressOK || !bAddress2OK) {
        alert("We cannot deliver to a PO Box.\nPlease change your delivery address!");
        if (!bAddressOK) $("#txtAddress").focus();
        else $("#txtAddress2").focus();
    }

    if (username == "" || username.length < 2) { $("#errorNmae").show(); flag = "false"; } else { $("#errorNmae").hide(); }
    if (lastName == "") { $("#errorlastName").show(); flag = "false"; } else { $("#errorlastName").hide(); }
    if (city == "") { $("#errorCity").show(); flag = "false"; } else { $("#errorCity").hide(); }
    if (zip == "") { $("#errorZip").show(); flag = "false"; } else { $("#errorZip").hide(); }
    if (address == "" || !bAddressOK || !bAddress2OK) { $("#errorAddress").show(); flag = "false"; } else { $("#errorAddress").hide(); }
    if (phone == "") { $("#errorPhone").show(); flag = "false"; } else { $("#errorPhone").hide(); }
    if (provinceid == "-1") { $("#errorArea").show(); flag = "false"; } else { $("#errorArea").hide(); }
    if (flag == "false") {
        return;
    }
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
                    + "',isfirst:'" + isfirst + "'}";
    $.ajax({
        type: "Post",
        url: '/AjaxPages/userAddressAjax.aspx',
        data: _data,
        async: false,
        success: function (resu) {
            if (resu == "-1") {
                alert("Please log in！");
                return;
            }
            else if (resu == "0") {
                alert("Failed to add！");
                return;
            }
            else {
                alert("Added successfully！");
                //$(".greybox,.add-new-address-box").hide();
                LoadShopaddress();

                // after adding address need to re-load the check cart because the counry and Zip will affect the shippping fee
                LoadCheckCart();

                ClearForm();
                EnableGotoPayButton();
                return;
            }
        }
    });
}
function UpdateShipAddress(guid) {
    var flag = "true";
    var countyid = $("#selectCountry  option:selected").val();
    var provinceid = $("#selectProvince  option:selected").val();
    var cityid = null; //  $("#selectCity  option:selected").val();
    var city = $("#txtShipCity").val(); //城市
    var zip = $("#txtShipZip").val();
    var address = $("#txtShipAddress").val();
    var address2 = $("#txtShipAddress2").val();
    var username = $("#txtShipName").val().trim();
    var lastName = $("#txtShipLastName").val(); //姓氏
    var tel = $("#txtShipPhone").val();
    var phone = $("#txtShipPhone").val();
    var isfirst = 1;
    //if ($("#ckbDefault").is(":checked")) { isfirst = 1;} else { isfirst = 0;}       
    //if (cityid == "-1" || cityid == "") { $("#errorArea").show(); }
    var bAddressOK = CheckAddress(address);
    var bAddress2OK = CheckAddress(address2);
    if (!bAddressOK || !bAddress2OK) {
        alert("We cannot deliver to a PO Box.\nPlease change your delivery address!");
        if (!bAddressOK) $("#txtShipAddress").focus();
        else $("#txtShipAddress2").focus();
    }

    if (city == "") { $("#errorCity").show(); flag = "false"; } else { $("#errorCity").hide(); }
    if (zip == "") { $("#errorZip").show(); flag = "false"; } else { $("#errorZip").hide(); }
    if (address == "" || !bAddressOK || !bAddress2OK) { $("#errorAddress").show(); flag = "false"; } else { $("#errorAddress").hide(); }
    if (username == "" || username.length < 2) { $("#errorNmae").show(); flag = "false"; } else { $("#errorNmae").hide(); }
    if (lastName == "") { $("#errorlastName").show(); flag = "false"; } else { $("#errorlastName").hide(); }
    if (phone == "") { $("#errorPhone").show(); flag = "false"; } else { $("#errorPhone").hide(); }
    if (provinceid == "-1") { $("#errorArea").show(); flag = "false"; } else { $("#errorArea").hide(); }
    if (flag == "false") {
        return;
    }
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
                    + "',isfirst:'" + isfirst + "'}";
    $.ajax({
        type: "Post",
        url: '/AjaxPages/userAddressAjax.aspx',
        data: _data,
        async: false,
        success: function (resu) {
            if (resu == "-1") {
                //alert("Please login！");
                return;
            }
            else if (resu == "0") {
                alert("Modify the failure！");
                return;
            }
            else {
                alert("Successful modification！");
                $(".greybox,.add-new-address-box").hide();
                $("#ulAddress1").empty();
                LoadShopaddress();

                // after updating, need to re-load the check cart because the counry and Zip will affect the shippping fee
                LoadCheckCart();

                EnableGotoPayButton();
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