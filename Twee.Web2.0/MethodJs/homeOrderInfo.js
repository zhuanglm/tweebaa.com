﻿//会员中心订单详情页面
var headguid = "";
$(document).ready(
   function () {
       var Request = new Object();
       Request = GetRequest();
       headguid = Request["headguid"];
       if (headguid == null || headguid == "") {
           return;
       }
       LoadOrderInfo(headguid);
   });

   //订单信息
   function LoadOrderInfo(headGuid) {
       $("#tdData").empty();
       $.ajax({
           type: "Post",
           url: "/AjaxPages/orderAjax.aspx",
           data: "{'action':'detial','headguid':'" + headGuid + "'}",
           success: function (resu) {
               if (resu == "") {
                   return;
               }
               //               var obj = eval("(" + resu + ")");
               //               var date = obj.orderTime.replace(/-/g, '/').substring(0, 10); //订单日期
               //               var orderNo = obj.orderNo; //订单号
               //               var expressNo = obj.expressNo; //快递单号
               //               var expressNoCompany = obj.expressNoCompany; //快递公司
               //               var expressprice = obj.expressprice; //快递费用（该费用为物流公司表配置费用，非实际物流费用）
               //               var phone = obj.phone; //收件人手机
               //               var tel = obj.tel; //收件人电话
               //               var username = obj.username; //收件人姓名
               //               var prdMoney = obj.prdMoney; //产品金额
               //               var orderMoney = obj.orderMoney; //订单总金额
               //               var orderState = obj.orderState; //订单状态

               var data = eval("(" + resu + ")");
               var obj = data[0];

               //$("#labOrder_date").html(obj.orderTime.replace(/-/g, '/').substring(0, 10)); //订单日期
               $("#labOrder_date").html(Date2MMDDYYYY(obj.orderTime));

               console.log("1=" + obj.orderTime + " 2=" + obj.orderTime.replace(/-/g, '/') + " 3=" + obj.orderTime.replace(/-/g, '/').substring(0, 10));
               $("#laborderNo").html(obj.orderNo); //订单号
               $("#labexpressNo").html(obj.expressNo); //快递单号
               $("#labexpressNoCompany").html(obj.expressNoCompany); //快递公司
               $("#labState").html(obj.orderState); ////订单状态
               var shipFeeHtml = "";
               var shipFeeHtmlLeftSide = "";
               if (parseFloat(obj.expressprice) == 0) { shipFeeHtml = "Shipping: Free"; shipFeeHtmlLeftSide = "Free"; }
               else {
                   shipFeeHtml = "Shipping: $" + parseFloat(obj.expressprice).toFixed(2);
                   shipFeeHtmlLeftSide = "$" + parseFloat(obj.expressprice).toFixed(2);
               }

               $("#labexpressprice").html(shipFeeHtmlLeftSide); //快递费用（该费用为物流公司表配置费用，非实际物流费用）               
               $("#labphone").html(obj.phone); //收件人手机
               if (obj.phone == "") {
                   $("#labtel").html(obj.tel); ;
               }
               //$("#labtel").html(obj.tel); //收件人电话
               $("#labusername").html(obj.username); //收件人姓名
               $("#labprdMoney").html(obj.prdMoney); //产品金额
               $("#laborderMoney").html(parseFloat(obj.orderMoney).toFixed(2)); //订单总金额
               $("#laborderMoney2").html(parseFloat(obj.orderMoney).toFixed(2)); //订单总金额
               $("#laborderState").html(obj.orderState); //订单状态

               $("#labaddress1").html(obj.proName + " " + obj.cityName);
               $("#labaddress2").html(obj.address);

               //
               $("#labShippingAddress1").html(obj.proName + " " + obj.cityName);
               $("#labShippingAddress2").html(obj.address);
               $("#labShippingAddress3").html(obj.proName + " " + obj.cityName);
               $("#labShippingAddress4").html(obj.address);

               $("#labzip").html(obj.zip);

               var doman = obj.doman;
               var orderInfo = obj.orderInfo;

               var rowspan = orderInfo.length;
               $(orderInfo).each(function (index) {
                   var val = orderInfo[index];
                   var img = doman + val.fileurl.replace("big", "small");
                   var tr = "";
                   var specDetail = "";
                   if (val.spectype != null) specDetail = specDetail + val.spectype;
                   if (val.specname != null) {
                       if (specDetail != "") specDetail = specDetail + " ";
                       specDetail = specDetail + val.specname;
                   }
                   tr += '<tr>';
                   tr += '<td style="width: 20%" class="hidden-sm"><div> <a href="#"><img src="' + img + '" alt="" width="100"></a></div> </td> ';
                   tr += '<td style="width: 40%"><h5> <a href="">' + val.name + '</a></h5><h5> <small>' + specDetail + '</small></h5><h6> $' + val.saleprice.toFixed(2) + '</h6> </td>';
                   tr += '<td style="width: 10%"> <a>X ' + val.quantity + ' </a></td>';
                   tr += '<td style="width: 15%"><span>$' + (val.saleprice * val.quantity).toFixed(2) + ' </span></td>';
                   tr += '</tr>';
                   $("#tdData").append(tr);
               });
               var tr2 = "";
               tr2 += '<tr>';
               tr2 += '<td colspan="4">';
               tr2 += '<div class="col-md-6 text-right" style="float: right">';
               tr2 += '<table width="100%" border="0" cellspacing="0" cellpadding="0" class="table table-bordered">';
               tr2 += '<tbody>';
               // tr2 += '<tr><td>Total (tax excl.)</td><td style="text-align:right"><span>$0.00</span></td></tr>';
 
               // subtotal should not include shipping fee == prdMoney
               tr2 += '<tr><td>Subtotal</td><td style="text-align:right"> <strong>$' + parseFloat(obj.prdMoney).toFixed(2) + ' </strong></td></tr>';

               if (parseFloat(obj.expressprice) == 0) { tr2 += '<tr><td>Shipping</td><td style="text-align:right"><span>Free</span></td></tr>'; }
               else { tr2 += '<tr><td>Shipping</td><td style="text-align:right"><span>$' + parseFloat(obj.expressprice).toFixed(2) + '</span></td></tr>'; }

               if (obj.userShopingAmount > 0) tr2 += '<tr><td>user Shoping Amount</td><td style="text-align:right"> <strong>-$' + parseFloat(obj.userShopingAmount).toFixed(2) + ' </strong></td></tr>';
               if (obj.useTweebuckAmount > 0) tr2 += '<tr><td>use Tweebuck Amount</td><td style="text-align:right"> <strong>-$' + parseFloat(obj.useTweebuckAmount).toFixed(2) + ' </strong></td></tr>';
               if (obj.useSharePointAmount > 0) tr2 += '<tr><td>use SharePoint Amount</td><td style="text-align:right"> <strong>-$' + parseFloat(obj.useSharePointAmount).toFixed(2) + ' </strong></td></tr>';

               tr2 += '<tr><td>Totals</td><td style="text-align:right"><span>$' + parseFloat(obj.orderMoney - obj.userShopingAmount - obj.useTweebuckAmount - obj.useSharePointAmount).toFixed(2) + ' </span> </td></tr> ';

               tr2 += '</tbody>';
               tr2 += '</table>';
               tr2 += '</div>';
               tr2 += '</td>';
               tr2 += '</tr>';
               $("#tdData").append(tr2);
           },
           error: function (obj) {
               alert("Load failed");
           }
       });
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
   }
   */

   function Date2MMDDYYYY(s) {
       var sRet = s.replace(/-/g, '/').substring(0, 10);
       if (sRet.substring(4, 5) == "/" && sRet.substring(7, 8) == "/") {
           sRet = s.substring(5, 7) + "/" + s.substring(8, 10) + "/" + s.substring(0, 4);
       }
       return sRet;
   }