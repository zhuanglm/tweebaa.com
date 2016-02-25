//会员中心订单详情页面
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
       var head = '<tr style="border-right: #f2f2f2 1px solid; border-left: #f2f2f2 1px solid;"><th width="222">Product</th><th width="82">Description</th><th width="100">Status</th><th width="85">Unit Price</th><th width="70">Quantity</th><th width="90" style="display:none;">Discount</th><th>Total (USD)</th></tr>';
       $("#tdData").empty();
       $("#tdData").append(head);

       $.ajax({
           type: "Post",
           url: "../AjaxPages/orderAjax.aspx",
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
               $("#labdate").html(obj.orderTime.replace(/-/g, '/').substring(0, 10)); //订单日期
               $("#laborderNo").html(obj.orderNo); //订单号
               $("#labexpressNo").html(obj.expressNo); //快递单号
               $("#labexpressNoCompany").html(obj.expressNoCompany); //快递公司
               var shipFeeHtml = "";
               var shipFeeHtmlLeftSide = "";
               if (parseFloat(obj.expressprice) == 0) { shipFeeHtml = "Shipping: Free"; shipFeeHtmlLeftSide = "Free"; }
               else { 
                    shipFeeHtml = "Shipping: $"+ parseFloat(obj.expressprice).toFixed(2) ; 
                    shipFeeHtmlLeftSide = "$"+ parseFloat(obj.expressprice).toFixed(2);
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
               $("#labzip").html(obj.zip);

               var doman = obj.doman;
               var orderInfo = obj.orderInfo;

               var rowspan = orderInfo.length;
               $(orderInfo).each(function (index) {
                   var val = orderInfo[index];
                   var img = doman + val.fileurl.replace("big", "small");
                   var tr = "";
                   if (index == 0) {
                       tr = '<tr><td><span class="icon"><a href="#"><img src="' + img + '" alt="">' + val.name + '</a> </span></td><td width="100" style=" padding-left:20px;"><span class="text"><div style="float: left;margin-top:5px;">Color：</div><div style="background-color: ' + val.color + '; width: 20px; float: left; height: 20px;margin-top:5px;"/><br /><div style="float: left;margin-left:-65px;margin-top:10px;">Size：' + val.prosize + '</div> </span></td><td><span class="text">' + obj.orderState + '</span></td><td><span class="text">$' + val.saleprice + '</span></td><td><span class="text">' + val.quantity + '</span></td><td style="display:none;"><span class="text">打折<br />Discount30.00$</span></td><td rowspan="' + rowspan + '"><span class="text">$' + parseFloat(obj.prdMoney).toFixed(2) + '<br />(Discount: $' + parseFloat(obj.offMoney).toFixed(2) + ')<br />(' + shipFeeHtml + ')</span></td></tr>';
                   }
                   else {
                       tr = '<tr><td><span class="icon"><a href="#"><img src="' + img + '" alt="">' + val.name + '</a> </span></td><td width="100" style=" padding-left:20px;"><span class="text"><div style="float: left;margin-top:5px;">Color：</div><div style="background-color: ' + val.color + '; width: 20px; float: left; height: 20px;margin-top:5px;"/><br /><div style="float: left;margin-left:-65px;margin-top:10px;">Size：' + val.prosize + '</div> </span></td><td><span class="text">' + obj.orderState + '</span></td><td><span class="text">$' + val.saleprice + '</span></td><td><span class="text">' + val.quantity + '</span></td><td style="display:none;"><span class="text">打折<br />Discount30.00$</span></td></tr>';
                   }
                   $("#tdData").append(tr);
               });

           },
           error: function (obj) {
               alert("Load failed");
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