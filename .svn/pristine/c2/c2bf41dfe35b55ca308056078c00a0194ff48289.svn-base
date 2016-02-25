var state = "";//订单状态
var page = 1;
var recordCount = 0;
var pageCount = 0;
var beginTime = $("#txtBegin").val();
var endTime = $("#txtEnd").val();


$(document).ready(
   function () {
       var Request = new Object();
       Request = GetRequest();
       state = Request["state"];
       DoSearch();
   });

   function SetState(orderState) {
       state = orderState;
       DoSearch();
   }

   //获取总记录数、页数
   function loadCount() {
       $("#kkpager").empty();      
       var beginTime = $("#txtBegin").val();
       var endTime = $("#txtEnd").val();
       $.ajax({
           type: "Post",
           url: "../AjaxPages/orderAjax.aspx",
           data: "{'action':'queryhomecount','state':'" + state + "','beginTime':'" + beginTime
                    + "','endTime':'" + endTime + "'}",
           async: false,
           success: function (resu) {
               if (resu == "") {
                   return;
               }
               var arry = new Array();
               arry = resu.split(",");
               recordCount = arry[0];
               pageCount = arry[1];
               kkpager.generPageHtml({
                   lang: {
                       firstPageText: 'First',
                       firstPageTipText: 'First',
                       lastPageText: 'Last',
                       lastPageTipText: 'Last',
                       prePageText: 'Prev',
                       prePageTipText: 'Prev',
                       buttonTipBeforeText: 'Page ',
                       buttonTipAfterText: '',
                       nextPageText: 'Next',
                       nextPageTipText: 'Next'
                   }
                   ,
                   pno: 1,
                   total: pageCount, //总页码
                   //总数据条数
                   totalRecords: recordCount,
                   mode: 'click', //默认值是link，可选link或者click
                   click: function (n) {
                       page = n;
                       loadMeinv();
                       this.selectPage(n); //手动选中按钮
                       return false;
                   }
               });
           },
           error: function (obj) {
               // alert("Load failed");
           }
       });   
   }

   function loadMeinv() {   
    $("#tdData").empty();
    var order = "";
    $.ajax({
        type: "Post",
        url: "../AjaxPages/orderAjax.aspx",
        data: "{'action':'queryhome','state':'" + state
                    + "','beginTime':'" + beginTime
                    + "','endTime':'" + endTime
                    + "','page':'" + page
                    + "'}",
        async: false,
        success: function (resu) {
            if (resu == "" || resu == "[]") {
                $("#kkpager").empty();
                $("#divNoData").show();
                return;
            }
            var obj = eval("(" + resu + ")");
            for (var i = 0; i < obj.length; i++) {
                var data = obj[i];
                //var date = data.date.replace(/-/g, '/').substring(0, 10);
                var date = data.date.substring(0, data.date.indexOf(" "));
                var orderNo = data.orderNo;
                var orderInfo = data.orderInfo;
                var doman = data.doman;
                var htmlData = "";
                var head = '<table width="100%" class="sum">  <tr><th colspan="6" style="background: #faf0f1;"><input type="checkbox" style="display:none;" value=' + data.headGuid + ' class="checkbox" />&nbsp;&nbsp;' + date + '&nbsp;&nbsp;&nbsp;&nbsp;Order Number：' + orderNo + ' <input type="button" value="有偿分享" class="button share" style="display:none;" /></th> </tr> ';
                htmlData += head;
                var rowspan = orderInfo.length;
                $(orderInfo).each(function (index) {
                    var val = orderInfo[index];
                    var img = doman + val.fileurl.replace("big", "small");
                    var tr = "";
                    if (index == 0) {
                        orderNo = "'" + orderNo + "'";
                        var shipFeeHtml = "";
                        if (data.expressprice == 0) shipFeeHtml = "(Shipping: Free)";
                        else {
                            var flExpress = parseFloat(data.expressprice); //modify by long, we should change to float first
                            shipFeeHtml = "(Shipping: $" + flExpress.toFixed(2) + ")";
                        }
                        //tr = '<tr><td><span class="icon"><a href="#"><img src="' + img + '" alt=""><strong>' + val.name + '</strong><br />颜色：黑色<br />尺码：43 </a></span></td><td width="82" valign="middle"><span class="text"><del>' + val.estimateprice + '</del><br />' + val.saleprice + '</span></td><td width="72" valign="middle"><span class="text">1</span></td><td width="78" valign="middle"><span class="text">退款/退货<br />投诉 </span></td><td rowspan="' + rowspan + '" valign="middle"><span class="text"><strong>' + data.orderMoney + '</strong><br />（优惠：$' + data.offMoney + '）<br />（物流费$' + data.expressprice + '）</span></td><td width="120" rowspan="' + rowspan + '" valign="middle"><span class="text">' + data.orderState + '<br /><a href="HomeOrderInfo.aspx?headguid=' + val.headGuid + '" target="_blank">Order Details</a><br />取消订单<br />查看物流</span></td>  </tr>';
                        //下面的暂且隐藏了【订单取消】【查看物流】功能
                        tr = '<tr><td width="300"><span class="icon"><a href="#"><img src="' + img + '" alt=""><strong>' + val.name + '</strong><br /><div style="float: left;margin-top:5px;">Color：</div><div style="background-color: ' + val.color + '; width: 20px; float: left; height: 20px;margin-top:5px;"/><br /><div style="float: left;margin-left:-65px;margin-top:10px;">Size：' + val.prosize + '</div> </a></span></td>'
                            + '<td width="82" valign="middle"><span class="text"><del>' + val.estimateprice + '</del><br />' + val.saleprice + '</span></td>'
                            + '<td width="72" valign="middle"><span class="text">' + val.quantity + '</span></td>'
                            + '<td width="78" valign="middle" style="display:none;"><span class="text">退款/退货<br />投诉 </span></td>'
                            + '<td rowspan="' + rowspan + '" valign="middle"><span class="text"><strong>' + data.orderMoney + '</strong><br />（Discount: $' + data.offMoney + '）<br /> ' + shipFeeHtml + '</span></td>';
                        if (data.wnstat == 0) {
                            //未支付订单    // Do not display unpaid orders
                            //tr += '<td width="120" rowspan="' + rowspan + '" valign="middle"><span class="text"><input type="button" value="Pay Now" class="button payNow" onclick="Pay(' + orderNo + ')"/><br /><a href="HomeOrderInfo.aspx?headguid=' + val.headGuid + '" target="_blank" class="blue" >Order Details</a><br/><a href="javascript:void(0);" class="blue" onclick="UpdateState(' + orderNo + ',-1)">Cancel Order</a></span></td></tr>';

                        }
                        else if (data.wnstat == 1) {
                            //【待发货订单】可以申请退货
                            tr += '<td width="120" rowspan="' + rowspan + '" valign="middle"><span class="text">' + data.orderState + '<br /><a href="HomeOrderInfo.aspx?headguid=' + val.headGuid + '" target="_blank" class="blue" >Order Details</a><br/><a href="javascript:void(0);" class="blue" onclick="UpdateState(' + orderNo + ',-2)">Return Good</a></span></td></tr>';
                        }
                        else if (data.wnstat == 3) {
                            //【已完成订单】可以申请退货和删除
                            tr += '<td width="120" rowspan="' + rowspan + '" valign="middle"><span class="text">' + data.orderState + '<br /><a href="HomeOrderInfo.aspx?headguid=' + val.headGuid + '" target="_blank" class="blue" >Order Details</a><br/><a href="javascript:void(0);" class="blue" onclick="UpdateState(' + orderNo + ',-2)">Return Good</a><br/><a href="javascript:void(0);" class="blue" onclick="UpdateState(' + orderNo + ',-6)">Delete</a></span></td></tr>';
                        }
                        else if (data.wnstat == -3) {
                            //退货中
                            tr += '<td width="120" rowspan="' + rowspan + '" valign="middle"><span class="text">' + data.orderState + '<br /><a href="HomeOrderInfo.aspx?headguid=' + val.headGuid + '" target="_blank" class="blue">Order Details</a><br/></span></td></tr>';
                        }
                        else {

                            // tr += '<td width="120" rowspan="' + rowspan + '" valign="middle"><span class="text">' + data.orderState + '<br /><a href="HomeOrderInfo.aspx?headguid=' + val.headGuid + '" target="_blank" class="blue">Order Details</a><br/></span></td></tr>';
                            if (data.wnstat == -1) {
                                tr += '<td width="120" rowspan="' + rowspan + '" valign="middle"><span class="text">' + data.orderState + '<br /><a href="HomeOrderInfo.aspx?headguid=' + val.headGuid + '" target="_blank" class="blue">Order Details</a><br/></span></td></tr>';
                            } else {
                                tr += '<td width="120" rowspan="' + rowspan + '" valign="middle"><span class="text">' + data.orderState + '<br /><a href="HomeOrderInfo.aspx?headguid=' + val.headGuid + '" target="_blank" class="blue">Order Details</a><br/><a href="javascript:void(0);" class="blue" onclick="UpdateState(' + orderNo + ',-1)">Cancel Order</a></span></td></tr>';
                            }
                        }
                    }
                    else {
                        tr = '<tr><td width="300"><span class="icon"><a href="#"><img src="' + img + '" alt=""><strong>' + val.name + '</strong><br /><div style="float: left;margin-top:5px;">Color：</div><div style="background-color: ' + val.color + '; width: 20px; float: left; height: 20px;margin-top:5px;"/><br /><div style="float: left;margin-left:-65px;margin-top:10px;">Size：' + val.prosize + '</div> </a></span></td>'
                            + '<td width="82" valign="middle"><span class="text"><del>' + val.estimateprice + '</del><br />' + val.saleprice + '</span></td>'
                            + '<td width="72" valign="middle"><span class="text">' + val.quantity + '</span></td>'
                            + '<td width="78" valign="middle" style="display:none;"><span class="text">退款/退货<br />投诉 </span></td></tr>';
                    }
                    htmlData += tr;
                });
                htmlData += '</table>';
                $("#tdData").append(htmlData);
            }
        },
        error: function (obj) {
            alert("Load failed");
        }
    });

}
function DoSearch() {
    beginTime = $("#txtBegin").val();
    endTime = $("#txtEnd").val();
    $("#divNoData").hide();
    loadCount();
    loadMeinv();
}

function Pay(orderNo) {
    window.parent.location.href = "../Product/shopOrder.aspx?orderNo=" + orderNo;
}
function UpdateState(orderNo, orderState) {

    var sureMess = "";
    var alertMess = "";
    if (orderState=="-1") {
        sureMess = "Are you sure to cancel the order?";
        alertMess = "Dear Value Customer:\n Your order " + orderNo + " has now been cancelled and your refund is being processed.\n Feel free to check your order status anytime through My Order. \n\nThank you for choosing Tweebaa!";
    }
    if (orderState == "-2") {
        sureMess = "Are you sure to apply for a refund?";
        alertMess = "Already apply for a refund, please wait for treatment!";
    }
    if (!window.confirm(sureMess)) {
        return;
    }
    $.ajax({
        type: "Post",
        url: "../AjaxPages/orderAjax.aspx",
        data: "{'action':'updateState','orderNo':'" + orderNo + "','state':'" + orderState + "'}",
        async: false,
        success: function (resu) {
            if (resu == "1") {
                alert(alertMess);
                DoSearch();
            }
        },
        error: function (obj) {

        }
    });
}
//全选、反选
function CheckAll(obj) {
   // $(".checkbox").attr("checked", $(obj).attr("checked"));
   // return;
    if ($(obj).attr("checked")==true) {
        //全选       
        $(".checkbox,.all-select-btn").attr('checked', 'checked');

    }
  
    if ($(obj).is(":checked") == false) {
        //取消全选
        $(".checkbox,.all-select-btn").attr('checked', false)
    }
}
//数量改变时重新结算总支付金额
function Delete() {  
    var ids ="";
    $(".checkbox").each(function (index, obj) {
        ids +="'"+ $(obj).attr('value') + "',";
    });
    if (!confirm(" Confirm to delete the item?")) {
        return;
    }
    var action = "delet";
    var _data = "{ action:'" + action + "',ids:'" + ids + "'}";
    $.ajax({
        type: "POST",
        url: '../AjaxPages/orderAjax.aspx',
        data: _data,
        async: false,
        success: function (msg) {
            if (msg == "-1") {
                alert("Please login！");
                return;
            }
            else if (msg == "1") {
                DoSearch();
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