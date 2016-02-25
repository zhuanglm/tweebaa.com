var picPath = "https://tweebaa.com/";
var cartids = "";
$(document).ready(function () {
    LoadShopCart("");
//    var Request = new Object();
//    Request = GetRequest();
//    cartids = unescape(Request["cartids"]);  
//    if (cartids == "" || cartids == null || cartids == "undefined") {
//       $(".all-select-btn").attr("checked", "checked");
//    }

});


var preCount0 = 0; //预售商品数
var saleCount0 = 0; //销售商品数
var sumCount = 0;//总商品数
var sumPay = 0; //总金额

//加载购物车(原来4.16之前)
//function LoadShopCart(state) {
//    $("#tabCart").empty();
//    $("#tabCart").append('<tr><th colspan="3" class="first"><label><input type="checkbox" class="all-select-btn" onclick="CheckAll(this)"  />Select all</label><span class="name-t">Product Information</span></th><th></th><th>Unit Price(USD)</th><th>Quantity</th><th>Test/Final-Sale</th><th>Amount（USD）</th><th>Action</th></tr>');
// 
//    var _data = "{ action:'query',state:'" + state + "'}";
//    $.ajax({
//        type: "Post",
//        url: '../AjaxPages/shopCartAjax.aspx',
//        data: _data,
//        success: function (resu) {
//            if (resu == "-1") {
//                alert("Please login！");
//                return;
//            }
//            else if (resu == "0" || resu == "") {
//                return;
//            }
//            else {
//                var obj = eval("(" + resu + ")");
//                if (state == "") {
//                    sumCount = obj.length; //总件数
//                }
//                payCount = 0; payMoney = 0; sumPay = 0; //sumCount = 0; 
//                var preCount = 0;
//                var saleCount = 0;
//                var stateText = "Test-Sale";
//                var stateColor = "green";
//                for (var i = 0; i < obj.length; i++) {
//                    var cart = obj[i];

//                    if (cart.wnstat == "2") { preCount += 1; preCount0 = preCount; stateText = "Test-Sale"; stateColor = "red"; sumPay += cart.premoney; }
//                    if (cart.wnstat == "3") { saleCount += 1; saleCount0 = saleCount; stateText = "Final-Sale"; stateColor = "green"; sumPay += cart.money; }
//                    var cartGuid = "'" + cart.guid + "'";
//                    var prdguid = "'" + cart.prdguid + "'";
//                    var img = "";
//                    if (cart.fileurl != null) {
//                        img = picPath + cart.fileurl.replace("big", "small");
//                    }
//                    var ckb = '<input type="checkbox" class="checkbox" value="' + cart.guid + '"  onclick="SettleAccounts(this,' + i + ')" />';
//                    if (cartids != "" && cartids.indexOf(cart.guid) < 0) {
//                        ckb = '<input type="checkbox" class="checkbox" value="' + cart.guid + '"  onclick="SettleAccounts(this,' + i + ')" />';
//                    }
//                    var html = '<tr>'
//                    + '<td class="first" style="width:25px;overflow:hidden">' + ckb + '<input type="hidden" id="hidCartGuid' + i + '" value="' + cart.guid + '" /><input type="hidden" id="hidPrdGuid' + i + '" value="' + cart.prdguid + '" /></td>'
//		 		    + '<td class="pro-des" colspan="2"><div class="pro-des-box"><a href="#" class="imglink"><img src="' + img + '" alt="" /></a>'
//                    + '<div class="des"><p class="baobei-name"><a href="#">' + cart.name + '</a></p>'
//		 		    + '<p class="baobei-num"></p></div></div></td>'
//			 	    + '<td class="colorsize"><div class="color-size"><p><div style="float:left;">Color：</div><div style="float:left;width:24px;height:24px;background-color:' + cart.color + ';"></div><br /><div style="float:left;">Size : ' + cart.prorule + '</div></p><i class="icon-bj"></i><div class="change-colorsize"><i class="icon-sjx"></i>'
//		 		    + '<div class="pro-img fr"><img src="../Images/160x160.jpg" alt="" />+</div>'
//		 		    + '<table class="fl chima"><tr><td class="t">尺　　码</td><td><span class="on">M(小码预售哈)<i class="on-sjx"></i></span><span>L<i class="on-sjx"></i></span>'
//		 		    + '<span>S<i class="on-sjx"></i></span><span>XXl<i class="on-sjx"></i></span></td></tr>'
//		 	        + '<tr><td class="t">颜色分类</td><td class="imgstyle"><span class="on"><img src="../Images/30x30.jpg" alt="" /><i class="on-sjx"></i></span>'
//		 		    + '<span><img src="images/30x30.jpg" alt="" /><i class="on-sjx"></i></span><span><img src="images/30x30.jpg" alt="" /><i class="on-sjx"></i></span></td></tr>'
//		 		    + '<tr><td class="t"></td><td><a href="#" class="enter">确定</a><a href="#" class="cancel">取消</a></td></tr></table></div></div></td>'
//		 		    + '<td class="unit-price"><del>' + cart.estimateprice + '</del><br /><strong ><label id="labPrice' + i + '">' + cart.saleprice + '</label></strong></td>'
//		 		    + '<td class="baobei-number"><span class="number-box"><a href="javascript:;" class="jian-btn"></a><a href="javascript:;" class="jia-btn"></a><input type="text" value="' + cart.quantity + '" class="num" id="num"' + i + ' onkeyup="CaLMoney(this,' + cart.saleprice + ',' + i + ')" /></span></td>'
//		 		    + '<td><div class="' + stateColor + '">' + stateText + '</div></td><td><div class="red"><strong><label id="labSum' + i + '"/></label></strong></div></td>'
//		 		    + '<td><div class="funbtn"><a href="javascript:;" class="delthis" onclick="DeletShopCart(' + cartGuid + ')" >Delete</a><br /><a href="javascript:;" onclick="FavoritePrd(' + prdguid + ')">Favorite</a></div></td></tr>';
//                    $("#tabCart").append(html);
//                    if (cart.wnstat == "2") {
//                        $("#labSum" + i).html(accAdd(cart.premoney.toFixed(2), 0)); //预售商品金额
//                    }
//                    if (cart.wnstat == "3") {
//                        $("#labSum" + i).html(accAdd(cart.money.toFixed(2), 0)); //销售商品金额
//                    }
//                   
//                }
//                if (state == "2") {
//                    sumCount = preCount;
//                }
//                else if (state == "3") {
//                    sumCount = saleCount;
//                }
//                $("#labPreCount").text(preCount0); //购买预售商品数
//                $("#labSaleCount").text(saleCount0); //购买销售商品数
//                $("#labSumCount").text(sumCount);
//                $("#labPayMoney1").text(sumPay.toFixed(2));
//                $("#labPayMoney2").text(sumPay.toFixed(2));
//                $("#labPayCount").text(sumCount);
//                //payMoney = sumPay;
//                ReyCalMoney();
//                payCount = sumCount;
//                BindNumEvent();
//                return;
//            }

//        },
//        error: function (msg) {
//            alert("error");
//        }
//    });
//}


//加载购物车
function LoadShopCart(state) {
    $("#tabCart").empty();
    $("#tabCart").append('<tr><th colspan="2" class="first"><span class="name-t">Items</span></th><th>Price</th><th>Subtotal</th></tr> ');
    var _data = "{ action:'query',state:'" + state + "'}";
    $.ajax({
        type: "Post",
        url: '../AjaxPages/shopCartAjax.aspx',
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
                    if (cart.wnstat == "2") { stateText = "Test-Sale"; stateColor = "red"; sumPay += cart.premoney; price = cart.saleprice.toFixed(2); linkUrl = "../Product/presaleBuy.aspx?id=" + cart.prdguid }
                    if (cart.wnstat == "3") { stateText = "Buy Now"; stateColor = "green"; sumPay += cart.money; price = cart.price.toFixed(2); linkUrl = "../Product/saleBuy.aspx?id=" + cart.prdguid }
                    var cartGuid = "'" + cart.guid + "'";
                    var prdguid = "'" + cart.prdguid + "'";
                    var img = "";
                    if (cart.fileurl != null) {
                        img = picPath + cart.fileurl.replace("big", "small");
                    }
                    // var ckb = '<input type="checkbox" class="checkbox" value="' + cart.guid + '"  onclick="SettleAccounts(this,' + i + ')" />';
                    // if (cartids != "" && cartids.indexOf(cart.guid) < 0) {
                    // ckb = '<input type="checkbox" class="checkbox" value="' + cart.guid + '"  onclick="SettleAccounts(this,' + i + ')" />';
                    // }
                    //                    var html = '<tr>'
                    //                    + '<td class="first" style="width:25px;overflow:hidden">' + ckb + '<input type="hidden" id="hidCartGuid' + i + '" value="' + cart.guid + '" /><input type="hidden" id="hidPrdGuid' + i + '" value="' + cart.prdguid + '" /></td>'
                    //		 		    + '<td class="pro-des" colspan="2"><div class="pro-des-box"><a href="#" class="imglink"><img src="' + img + '" alt="" /></a>'
                    //                    + '<div class="des"><p class="baobei-name"><a href="#">' + cart.name + '</a></p>'
                    //		 		    + '<p class="baobei-num"></p></div></div></td>'
                    //			 	    + '<td class="colorsize"><div class="color-size"><p><div style="float:left;">Color：</div><div style="float:left;width:24px;height:24px;background-color:' + cart.color + ';"></div><br /><div style="float:left;">Size : ' + cart.prorule + '</div></p><i class="icon-bj"></i><div class="change-colorsize"><i class="icon-sjx"></i>'
                    //		 		    + '<div class="pro-img fr"><img src="../Images/160x160.jpg" alt="" />+</div>'
                    //		 		    + '<table class="fl chima"><tr><td class="t">尺　　码</td><td><span class="on">M(小码预售哈)<i class="on-sjx"></i></span><span>L<i class="on-sjx"></i></span>'
                    //		 		    + '<span>S<i class="on-sjx"></i></span><span>XXl<i class="on-sjx"></i></span></td></tr>'
                    //		 	        + '<tr><td class="t">颜色分类</td><td class="imgstyle"><span class="on"><img src="../Images/30x30.jpg" alt="" /><i class="on-sjx"></i></span>'
                    //		 		    + '<span><img src="images/30x30.jpg" alt="" /><i class="on-sjx"></i></span><span><img src="images/30x30.jpg" alt="" /><i class="on-sjx"></i></span></td></tr>'
                    //		 		    + '<tr><td class="t"></td><td><a href="#" class="enter">确定</a><a href="#" class="cancel">取消</a></td></tr></table></div></div></td>'
                    //		 		    + '<td class="unit-price"><del>' + cart.estimateprice + '</del><br /><strong ><label id="labPrice' + i + '">' + cart.saleprice + '</label></strong></td>'
                    //		 		    + '<td class="baobei-number"><span class="number-box"><a href="javascript:;" class="jian-btn"></a><a href="javascript:;" class="jia-btn"></a><input type="text" value="' + cart.quantity + '" class="num" id="num"' + i + ' onkeyup="CaLMoney(this,' + cart.saleprice + ',' + i + ')" /></span></td>'
                    //		 		    + '<td><div class="' + stateColor + '">' + stateText + '</div></td><td><div class="red"><strong><label id="labSum' + i + '"/></label></strong></div></td>'
                    //		 		    + '<td><div class="funbtn"><a href="javascript:;" class="delthis" onclick="DeletShopCart(' + cartGuid + ')" >Delete</a><br /><a href="javascript:;" onclick="FavoritePrd(' + prdguid + ')">Favorite</a></div></td></tr>';

                    cartids += "'" + cart.guid + "',";
                    var html = '<tr>'
                    + '<td class="first" style="width:25px;overflow:hidden"><input type="hidden" id="hidGuid' + i + '" value="' + cart.guid + '" /></td>'
                    + '<td class="pro-des"><div class="pro-des-box"><div class="leftimg">'
                    + '<a href="' + linkUrl + '" class="imglink"><img src="' + img + '" alt="" /></a>'
                    + '<a href="javascript:;" class="delthis" onclick="DeletShopCart(' + cartGuid + ')" >Delete</a></div>'
                    + '<div class="des">'
                    // + '<p class="baobei-name"> <a href="' + linkUrl + '">' + cart.name + '&nbsp;&nbsp;<em>(' + stateText + ')</em> </a> </p>';
                    if (cart.wnstat == "2") {
                        stateText = "Test-Sale";
                        //html += '<p class="baobei-name"> <a class="test-stips"  href="' + linkUrl + '">' + cart.name + '&nbsp;&nbsp;<em>(Test-Sale)</em><span>Test-Sale items must sell a certain quota within 60 days in order to advance to the Tweebaa Shop.  Only when quota is met will your order be fulfilled.  IF QUOTA IS NOT MET, YOU WILL RECEIVE FULL REFUND.  Longer lead-times will apply.</span> </a> </p>';
                        //html += '<p class="baobei-name"> <a class="test-stips" href="#"><em>(Test-Sale)</em><span>Test-Sale items must sell a certain quota within 60 days in order to advance to the Tweebaa Shop.  Only when quota is met will your order be fulfilled.  IF QUOTA IS NOT MET, YOU WILL RECEIVE FULL REFUND.  Longer lead-times will apply.</span></a></span> </a></p> ';
                        html += '<p class="baobei-name"> <a href="#">' + cart.name + '<span class="fl"><a class="test-stips" href="#tooltips"><em>(Test-Sale)</em><span>Test-Sale items must sell a certain quota within 60 days in order to advance to the Tweebaa Shop.  Only when quota is met will your order be fulfilled.  IF QUOTA IS NOT MET, YOU WILL RECEIVE FULL REFUND.  Longer lead-times will apply.</span></a></span> </a> </p>';
                    }
                    else {
                        html += '<p class="baobei-name"> <a href="' + linkUrl + '">' + cart.name + '&nbsp;&nbsp;<em>(' + stateText + ')</em> </a> </p>';
                    }
                    //+ '<p class="size ">Color：' + cart.color + '<br />Specs：' + cart.prorule + '</span>'
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
                return;
            }
        },
        error: function (msg) {
            //alert("error");
        }
    });
}

//购买数量
function BindNumEvent(cartGuid) {
    var objmoneys = $(".labSum"); //总金额控件
    var objNumberBox = $(".number-box");

    objNumberBox.each(function (index, el) {
        var reduceNumber = $(this).find(".jia-btn");
        var addNumber = $(this).find(".jian-btn");
        var objNumber = $(this).find(".num"); //数量

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
            objNumber.val(parseInt(objNumber.val()) + 1);
            $("#labSum" + index).text((parseInt(objNumber.val()) * price).toFixed(2));
            ReyCalMoney();
            UpdateNum($("#hidGuid"+index).val(), objNumber.val());
        })
        //减少
        reduceNumber.click(function () {
            objNumber.val(parseInt(objNumber.val()) - 1);
            if (parseInt(objNumber.val()) < 1) {
                objNumber.val(1);
            };
            //$("#labSum" + index).html("");           
            $("#labSum" + index).text((parseInt(objNumber.val()) * price).toFixed(2));
            ReyCalMoney();
            UpdateNum($("#hidGuid" + index).val(), objNumber.val());
        })
    });
}
//数量文本框keyup事件计算金额
function CaLMoney(objNumber, price,index) {
    $("#labSum" + index).text((parseInt($(objNumber).val()) * price).toFixed(2));
    ReyCalMoney();
    UpdateNum($("#hidGuid" + index).val(), $(objNumber).val());

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
function ActiveClass(obj,stat) {   
    $(obj).prevAll().removeClass();
    $(obj).nextAll().removeClass();
    $(obj).addClass("active");
    $("#tabCart").empty();
    LoadShopCart(stat);
}

//收藏
function FavoritePrd(prdID) {   
    var _data = "{ action:'" + 'add' + "',id:'" + prdID + "'}";
    $.ajax({
        type: "POST",
        url: '../AjaxPages/FavoriteAjax.aspx',
        data: _data,
        dataType: "text",
        success: function (resu) {
            if (resu == "success") {
                alert("This item has been saved to your Favorites. To access, just log in to your account and select 'My Favorites'.");
            }
            else if (resu == "-1") {
                alert("Please log in!");                
            }
            else {
                alert("Failed to favorite");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Failed to favorite");
        }
    });

}
//批量收藏
function FavoritePrdAll() {
   var id="";
   $(".checkbox").each(function (index, obj) {
       if ($(obj).attr("checked")) {
           id += $("#hidPrdGuid" + index).val() + ",";
       }
   });
   id = id.substr(0, id.length - 1);
   if (id!="") {
       FavoritePrd(id);
   }
   else {
       alert("Please choose to collect the product！");
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
//            url: '../AjaxPages/shopCartAjax.aspx',
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
        url: '../AjaxPages/shopCartAjax.aspx',
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
        url: '../AjaxPages/shopCartAjax.aspx',
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
    if (id=="") {
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
            url: '../AjaxPages/shopCartAjax.aspx',
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
    if (cartids == "" || cartids==null) {
        window.location.href = "shoppCartEmpty.aspx";
    }
    else {
        window.location.href = "shopOrder.aspx?cartids=" + escape(cartids);
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
        url: '../AjaxPages/orderAjax.aspx',
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

//改变购物车数量
function UpdateNum(guid, number) {
    if (guid == null || guid == "") {     
        return;
    }
    var _data = "{ action:'" + 'AddNum' + "',guid:'" + guid + "',number:'" + number + "'}";
    $.ajax({
        type: "POST",
        url: '../AjaxPages/shopCartAjax.aspx',
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