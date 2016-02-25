﻿
var cartids = "";
$(document).ready(function () {
    LoadShopCart("");  

});

var preCount0 = 0; //预售商品数
var saleCount0 = 0; //销售商品数
var sumCount = 0; //总商品数
var sumPay = 0; //总金额

var hasTestSaleItem = 0;

//加载购物车
function LoadShopCart(state) {
    $("#tabCart").empty();
    hasTestSaleItem = 0;
    //$("#tabCart").append('<tr><th colspan="2" class="first"><span class="name-t">Items</span></th><th>Price</th><th>Subtotal</th></tr> ');
    var _data = "{ action:'query',state:'" + state + "'}";
    $.ajax({
        type: "Post",
        url: '/AjaxPages/shopCartAjax.aspx',
        data: _data,
        success: function (resu) {
            cartids = "";
            if (resu == "-1") {
                alert("Please login！");
                return;
            }
            else if (resu == "0" || resu == "") {
                window.location.href = "shoppCartEmpty.aspx";
                return;
            }
            else {
                var obj = eval("(" + resu + ")");
                payMoney = 0; sumPay = 0;
                var stateText = "Test-Sale";
                var stateColor = "green";
                for (var i = 0; i < obj.length; i++) {
                    var cart = obj[i];
                    var price = 0;
                    var linkUrl = "";
                    if (cart.wnstat == "2") { hasTestSaleItem = 1; stateText = "Test-Sale"; stateColor = "red"; sumPay += cart.premoney; price = cart.saleprice.toFixed(2); linkUrl = "../Product/presaleBuy.aspx?id=" + cart.prdguid }
                    if (cart.wnstat == "3") { stateText = "Buy Now"; stateColor = "green"; sumPay += cart.money; price = cart.price.toFixed(2); linkUrl = "../Product/saleBuy.aspx?id=" + cart.prdguid }
                    var cartGuid = "'" + cart.guid + "'";
                    var prdguid = "'" + cart.prdguid + "'";
                    var img = "";
                    if (cart.fileurl != null) {
                        img = picPath + cart.fileurl.replace("big", "small");
                    }
                    cartids += "'" + cart.guid + "',";

                    /**********************
                    var html = '<tr>'
                    + '<td class="first" style="width:25px;overflow:hidden"><input type="hidden" id="hidGuid' + i + '" value="' + cart.guid + '" /></td>'
                    + '<td class="pro-des"><div class="pro-des-box"><div class="leftimg">'
                    + '<a href="' + linkUrl + '" class="imglink"><img src="' + img + '" alt="" /></a>'
                    + '<a href="javascript:;" class="delthis" onclick="DeletShopCart(' + cartGuid + ')" >Delete</a></div>'
                    + '<div class="des">'
                    if (cart.wnstat == "2") {
                    stateText = "Test-Sale";
                    html += '<p class="baobei-name"> <a href="#">' + cart.name + '<span class="fl"><a class="test-stips" href="#tooltips"><em>(Test-Sale)</em><span>Test-Sale items must sell a certain quota within 60 days in order to advance to the Tweebaa Shop.  Only when quota is met will your order be fulfilled.  IF QUOTA IS NOT MET, YOU WILL RECEIVE FULL REFUND.  Longer lead-times will apply.</span></a></span> </a> </p>';
                    }
                    else {
                    html += '<p class="baobei-name"> <a href="' + linkUrl + '">' + cart.name + '&nbsp;&nbsp;<em>(' + stateText + ')</em> </a> </p>';
                    }
                    if (cart.color == "#fff") {
                    html = html + '<p class="size "><div style="float:left;font-size:13px; margin-top:-10px;">Color：</div><div style="float:left;width:18px;height:18px;margin-top:-10px; border:solid 1px gray;background-color:' + cart.color + ';"></div><div style="float:left;font-size:13px;margin-top:-10px;;margin-left:15px;">Specs: ' + cart.prorule + '</div></span>';
                    }
                    else {
                    html = html + '<p class="size "><div style="float:left;font-size:13px; margin-top:-10px;">Color：</div><div style="float:left;width:18px;height:18px;margin-top:-10px;background-color:' + cart.color + ';"></div><div style="float:left;font-size:13px;margin-top:-10px;;margin-left:15px;">Specs: ' + cart.prorule + '</div></span>';
                    }
                    html += '<br/><p class="addfav">'
                    + '<a href="javascript:;" onclick="FavoritePrd(' + prdguid + ');DeletShopCart2(' + cartGuid + ')">Move to Favorite</a>'
                    + '</p></div></div></td>'
                    + '<td class="baobei-number"><span>$<label id="labPrice' + i + '">' + price + '</label> X </span>'
                    + '<span class="number-box"><a href="javascript:;" class="jian-btn"></a><a href="javascript:;" class="jia-btn"></a><input type="text" value="' + cart.quantity + '" class="num" id="num"' + i + ' onkeyup="CaLMoney(this,' + cart.saleprice + ',' + i + ')" /> '
                    + '</span></td><td><div class="red"><strong>$<label id="labSum' + i + '"/></label></strong></div></td></tr> ';
                    ****************************************/




                    ///*********************************************               
                    sku_in_cart[i] = cart.prosku;
                    var html = '<tr>'
                    + '<td class="product-in-table"><input type="hidden" id="hidGuid' + i + '" value="' + cart.guid + '" />'
                    + '<a href="' + linkUrl + '"><img class="img-responsive" src="' + img + '" alt=""></a>'
                    //+ '<a style="float:left; clear:left; margin-left:40px" " href="javascript:;" class="delthis" onclick="DeletShopCart(' + cartGuid + ')" >Delete</a>'
                    + '<div class="product-it-in">'
                    + '<h3><a href="' + linkUrl + '">' + cart.name + '</a></h3> '
                    + '<p class="shop-red">' + stateText + '</p>'
                    + '<span class="size-label-s">&nbsp;' + cart.prorule + '&nbsp;</span><span class="color_label_s" style="background-color:' + cart.color + ';"></span>'
                    + ' <span> <button class="btn btn-xs rounded btn-default" type="button" onclick="FavoritePrd(' + prdguid + ')">Favorite </button> </span>'
                    + '</div>'
                    + ' </td>'
                    + '<td>' + cart.prosku + '</td>'
                    + '<td>$<label id="labPrice' + i + '">' + price + '</label></td>'
                    + '<td class="number-box">'
                    + '<button type="button" class="quantity-button-jian"   value="-">-</button>'
                    + '<input type="text" class="quantity-field" name="qty1" value="' + cart.quantity + '"  id="num' + i + '" onkeyup="CaLMoney(this,' + cart.saleprice + ',' + i + ')" maxlength="3" />'
                    + '<button type="button" class="quantity-button-jia"  value="+">+</button>'
                    + '</td>'
                    + '<td class="">$<label id="labSum' + i + '"/></label></td>'
                    + '<td class="vm">'
                    // + '<button type="button" class="close" onclick="DeletShopCart(' + cartGuid + ')" ><span>&times;</span><span class="sr-only">Close</span></button>'
                    + '<button class="btn rounded btn-default" type="button" onclick="DeletShopCart(' + cartGuid + ')" ><i class="fa fa-trash"></i> </button>';
+'</td>'
                    + '</tr>';
                    $("#tabCart").append(html);
                    if (cart.wnstat == "2") {
                        $("#labSum" + i).html(accAdd(cart.premoney, 0).toFixed(2)); //预售商品金额
                    }
                    if (cart.wnstat == "3") {
                        $("#labSum" + i).html(accAdd(cart.money, 0).toFixed(2)); //销售商品金额
                    }
                }
                //$("#labPayMoney1").text(sumPay.toFixed(2));
                ReyCalMoney();
                BindNumEvent(cart.guid);
                if (hasTestSaleItem == 1) {
                    $("#divTestsaleMessage").show();
                }
                return;
            }
        },
        error: function (msg) {
            //alert("error");
        }
    });
}

//Add by Long for re-calc shopping cart total number 2015/12/30
function getAllCartNumber() {
    var iTotal = 0;
    $("input[id^=num]").each(function () {
        //alert("yes");
        iTotal = iTotal +parseInt( $(this).val());
    });
    return iTotal;
}

//购买数量
function BindNumEvent(cartGuid) {
    var objmoneys = $(".labSum"); //总金额控件
    var objNumberBox = $(".number-box");

    objNumberBox.each(function (index, el) {
        var reduceNumber = $(this).find(".quantity-button-jian");
        var addNumber = $(this).find(".quantity-button-jia");
        var objNumber = $(this).find(".quantity-field"); //数量

        objNumber.keyup(function (event) {
            this.value = this.value.replace(/\D/g, '');
        }).change(function (event) {
            this.value = this.value.replace(/\D/g, '');
            this.value = parseInt(this.value);
        });
        var price = $("#labPrice" + index).text(); //单价
        var summoney = $("#labSum" + index).text(); //总金额     
        // 增加
        addNumber.click(function () {
            //alert(objNumber.val());
            var iNewQty = parseInt(objNumber.val()) + 1;
            if (iNewQty >= 999) iNewQty = 999;
            objNumber.val(iNewQty);
            $("#labSum" + index).text((parseInt(objNumber.val()) * price).toFixed(2));
            ReyCalMoney();
            UpdateNum($("#hidGuid" + index).val(), objNumber.val());

            //update shopping cart number, Add by Long 12/21/2015
            if (iNewQty <= 999) {
                var p = $("#labCartCount").html();
                var p1 = parseInt(p) + 1;
                $("#labCartCount").html(p1);
            }
        })
        //减少
        reduceNumber.click(function () {
            //alert(objNumber.val());
            objNumber.val(parseInt(objNumber.val()) - 1);
            if (parseInt(objNumber.val()) < 1) {
                objNumber.val(1);
            };
            //$("#labSum" + index).html("");      

            $("#labSum" + index).text((parseInt(objNumber.val()) * price).toFixed(2));
            ReyCalMoney();
            UpdateNum($("#hidGuid" + index).val(), objNumber.val());
            //update shopping cart number, Add by Long 12/21/2015
            if (parseInt(objNumber.val()) >= 1) {
                var p = $("#labCartCount").html();
                var p1 = parseInt(p) - 1;
                if (p1 >= 1) {
                    var iTotal = getAllCartNumber();
                    $("#labCartCount").html(iTotal);
                    /*
                    if (p1 >= $("#hid_previous_shoppingcart_count").val()) {
                        $("#labCartCount").html(p1);
                    } else {
                        // $("#labCartCount").html($("#hid_previous_shoppingcart_count").val());
                    }*/
                }
            }
        })
    });
}
//数量文本框keyup事件计算金额
function CaLMoney(objNumber, price, index) {
    if (parseInt($(objNumber).val()) > 0) {
        $("#labSum" + index).text((parseInt($(objNumber).val()) * price).toFixed(2));
        ReyCalMoney();
        UpdateNum($("#hidGuid" + index).val(), $(objNumber).val());

        //update shopping cart number, Add by Long 12/21/2015
        //if (iNewQty <= 999) 
        {
            //var p = $("#labCartCount").html();
            //var p1 = parseInt(p) + 1;
            $("#labCartCount").html($(objNumber).val());
        }
    } else {
        //alert("Zero is  not allow here");
        $(objNumber).val(1);
        $("#labSum" + index).text((parseInt($(objNumber).val()) * price).toFixed(2));
        ReyCalMoney();
        UpdateNum($("#hidGuid" + index).val(), $(objNumber).val());
    }
}
//checkBox点击事件改变数量和总金额
var payCount = 0;
var payMoney = 0;
function SettleAccounts(obj, index) {
    ReyCalMoney();
}
//全选、反选
function CheckAll(obj) {
    if ($(obj).attr('checked')) {
        //全选
        $(".checkbox,.all-select-btn").attr("checked", true);

    }
    if ($(obj).is(":checked") == false) {
        //取消全选
        $(".checkbox,.all-select-btn").attr('checked', false)
    }
    ReyCalMoney();
}


//菜单点击样式
function ActiveClass(obj, stat) {
    $(obj).prevAll().removeClass();
    $(obj).nextAll().removeClass();
    $(obj).addClass("active");
    $("#tabCart").empty();
    LoadShopCart(stat);
}

//收藏
/*
//comments by Long 2015/12/32 as dulplicate function at favorite.js
function FavoritePrd(prdID) {
var _data = "{ action:'" + 'add' + "',id:'" + prdID + "'}";
$.ajax({
type: "POST",
url: '/AjaxPages/FavoriteAjax.aspx',
data: _data,
dataType: "text",
success: function (resu) {
if (resu == "success") {
ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com", "This item has been saved to your Favorites. To access, just log in to your account and select 'My Favorites'.");
}
else if (resu == "-1") {
ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com", "Please log in!");
}
else {
ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com", "Failed to favorite");
}
},
error: function (XMLHttpRequest, textStatus, errorThrown) {
ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com", "Failed to favorite");
}
});

}
*/
//批量收藏
function FavoritePrdAll() {
    var id = "";
    $(".checkbox").each(function (index, obj) {
        if ($(obj).attr("checked")) {
            id += $("#hidPrdGuid" + index).val() + ",";
        }
    });
    id = id.substr(0, id.length - 1);
    if (id != "") {
        FavoritePrd(id);
    }
    else {
        ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com", "Please choose to collect the product！");
    }

}

//删除购物车
//function DeletShopCart(cartGuid) {
//    $(".greybox").show();
//    $(".del-shop-tck").show();
//    $(".closeBtn,.cancel-del").click(function (event) {
//        $(".greybox").hide();
//        $(this).parent().hide();
//        return;
//    });
//    $(".enter-del").click(function (event) {
//        $(".greybox").hide();
//        $(this).parent().hide();
//        var action = "delet";
//        var _data = "{ action:'" + action + "',cartGuid:'" + cartGuid + "'}";
//        $.ajax({
//            type: "POST",
//            url: '/AjaxPages/shopCartAjax.aspx',
//            data: _data,
//            success: function (msg) {
//                if (msg == "-1") {
//                    alert("Please login！");
//                    return;
//                }
//                else if (msg == "1") {
//                    //alert("删除成功！");               
//                    //$(".del-tips").show();
//                    LoadShopCart("");
//                    return;
//                }
//                else if (msg == "0") {
//                    alert("Delete failed");
//                    return;
//                }
//                deleFlag = "false";
//            },
//            error: function (msg) {
//                alert("Delete failed");
//            }
//        });
//    });
//}

function DeletShopCart(cartGuid) {
    if (!confirm(" Confirm to delete the item?")) {
        return;
    }

    //$(".greybox").hide();
    //$(this).parent().hide();
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
                //alert("删除成功！");               
                //$(".del-tips").show();
                //LoadShopCart("");
                window.location.href = window.location.href;
                return;
            }
            else if (msg == "0") {
                alert("Delete failed");
                return;
            }
            deleFlag = "false";
        },
        error: function (msg) {
            alert("Delete failed");
        }
    });
}
//不做提示
function DeletShopCart2(cartGuid) {
    var action = "delet";
    var _data = "{ action:'" + action + "',cartGuid:'" + cartGuid + "'}";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/shopCartAjax.aspx',
        data: _data,
        success: function (msg) {
            LoadShopCart("");
        },
        error: function (msg) {
        }
    });
}

//批量删除购物车
function DeletShopCartAll() {
    var id = "";
    $(".checkbox").each(function (index, obj) {
        if ($(obj).attr("checked")) {
            // id += "'" + $("#hidCartGuid" + index).val() + "',";
            id += $("#hidCartGuid" + index).val() + ",";
        }
    });
    id = id.substr(0, id.length - 1);
    if (id == "") {
        alert("Please select a product to delete！");
        return;
    }
    $(".greybox").show();
    $(".del-shop-tck").show();
    $(".closeBtn,.cancel-del").click(function (event) {
        $(".greybox").hide();
        $(this).parent().hide();
    });
    $(".enter-del").click(function (event) {
        $(".greybox").hide();
        $(this).parent().hide();

        var action = "deletlist";
        var _data = "{ action:'" + action + "',cartGuid:'" + id + "'}";
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
                    //alert("删除成功！");               
                    $(".del-tips").show();
                    LoadShopCart("");
                }
                else if (msg == "0") {
                    alert("Delete failed");
                    return;
                }
                deleFlag = "false";
            },
            error: function (msg) {
                alert("Delete failed");
            }
        });
    });
}

//结算：
function CreateOrder() {
    //alert(cartids);
    cartids = cartids.substring(0, cartids.length - 1);
    if (cartids == "" || cartids == null) {
        window.location.href = "shoppCartEmpty.aspx";
    }
    else {
        window.location.href = "shopOrder.aspx?cartids=" + escape(cartids);
    }


}

function CreateOrder2Shipping() {
    cartids = cartids.substring(0, cartids.length - 1);
    if (cartids == "" || cartids == null) {
        window.location.href = "shoppCartEmpty.aspx";
    }
    else {
        // window.location.href = "CheckoutShipping.aspx?cartids=" + escape(cartids);
        window.location.href = "CheckoutShipping.aspx" ;
    }
}

//结算：
//function CreateOrder() {
//    var cartGuids = "";
//    $(".checkbox").each(function (index, obj) {
//        if ($(obj).attr('checked')) {
//            cartGuids += "'" + $(obj).val() + "',";
//        }
//    });
//    if (cartGuids == "") {
//        alert("Please select item you want to check out!");
//        return;
//    }
//    cartGuids = cartGuids.substring(0, cartGuids.length - 1);
//    window.location.href = "shopOrder.aspx?cartids=" + escape(cartGuids);

//}



//结算：首先创建订单（暂且不采用这个逻辑）
function CreateOrder2() {
    var cartGuids = "";
    $(".checkbox").each(function (index, obj) {
        if ($(obj).attr('checked')) {
            cartGuids += $(obj).val() + ",";
        }
    });
    if (cartGuids == "") {
        alert("Please select item you want to favorite!");
        return;
    }
    cartGuids = cartGuids.substring(0, cartGuids.length - 1);
    var _data = "{ action:'" + 'add' + "',cartGuids:'" + cartGuids + "'}";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/orderAjax.aspx',
        data: _data,
        dataType: "text",
        success: function (resu) {
            if (resu == "1") {
                window.location.href = "shopAddress.aspx";
            }
            else {
                alert("Failed to create the order");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Failed to create the order");
        }
    });

}
//数量改变时重新结算总支付金额
function ReyCalMoney() {
    var objNumberBox = $(".number-box");
    var pay = 0;
    $(".number-box").each(function (index, obj) {
        pay = accAdd($("#labSum" + index).text(), pay);
    });
    $("#labPayMoney1").text(pay.toFixed(2));
    sumPay = pay.toFixed(2);
}

//数量改变时重新结算总支付金额
//function ReyCalMoney() { 
//    var objNumberBox = $(".number-box");
//    var objCheckbox= $(".checkbox");//......
//    var pay = 0;
//    $(".checkbox").each(function (index, obj) {
//        if ($(obj).attr("checked")) {          
//            pay = accAdd($("#labSum" + index).text(), pay);
//        }
//    });
//    $("#labPayMoney1").text(pay.toFixed(2));
//    //$("#labPayMoney2").text(pay.toFixed(2));
//    sumPay = pay.toFixed(2);
//}


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
}
*/
//改变购物车数量
function UpdateNum(guid, number) {
    if (guid == null || guid == "") {
        return;
    }
    var _data = "{ action:'" + 'AddNum' + "',guid:'" + guid + "',number:'" + number + "'}";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/shopCartAjax.aspx',
        data: _data,
        dataType: "text",
        success: function (resu) {
            if (resu == "1") {

            }
            else {

            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });

}