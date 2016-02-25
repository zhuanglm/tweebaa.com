//Ship Order details for supplier at the member center
var sShipOrderID = "";
$(document).ready(
   function () {
       var Request = new Object();
       Request = GetRequest();
       sShipOrderID = Request["id"];
       if (sShipOrderID == null || sShipOrderID == "") {
           return;
       }
       LoadShipOrderDetail(sShipOrderID);
   });

//ship order details
function LoadShipOrderDetail(sShipOrderID) {

    $.ajax({
        type: "Post",
        url: "/AjaxPages/shipOrderAjax.aspx",
        data: "{'action':'queryshiporderdetail','shiporderid':'" + sShipOrderID + "'}",
        success: function (resu) {
            //alert(resu);
            if (resu == "0") {
                return;
            }

            var data = eval("(" + resu + ")");
            var obj = data[0];
            var shipDate = new Date(obj.ShipOrder_Date);
            $("#labOrderDate").html(Date2String(shipDate));
            $("#labCustomerOrderNo").html(obj.OrderHead_GuidNo);
            $("#labShipOrderNo").html(sShipOrderID);
            $("#labShipOrderStatus").html(GetShipOrderStatusName(obj.ShipOrder_Status));
            $("#labShipMethod").html(obj.ShipMethod_Name);
            $("#labTrackingNo").html(obj.ShipOrder_TrackingNo);

            var sShipToName = obj.ShipTo_FirstName;
            if (obj.ShipTo_LastName != null) sShipToName = sShipToName + " " + obj.ShipTo_LastName;
            $("#labShipToName").html(sShipToName);
            $("#labShipToAddress").html(obj.ShipTo_Address1);
            $("#labShipToCityProvZip").html(obj.ShipTo_City + ", " + obj.ShipTo_ProvinceName + " " + obj.ShipTo_Zip);
            $("#labShipToCountry").html(GetCountryName(obj.ShipTo_CountryID));

            var sHeadHtml = '<tr style="border-right:#f2f2f2 1px solid ;border-left: #f2f2f2 1px solid; text-transform:uppercase;">' +
						'<th width="152"> OUR Item #</th>' +
						'<th width="152">YOUR Item #</th>' +
                        '<th width="70">QTY</th>' +
                        '<th width="130">Description</th>' +
						'<th width="85">Unit Price</th>' +
                        '<th width="85">Line Total</th>' +
                        '</tr>';

            $("#tbItemList").empty();
            $("#tbItemList").append(sHeadHtml);

            var dTotalPrice = 0.0;
            var dTotalShipFee = 0.0;

            for (var i = 0; i < data.length; i++) {
                obj = data[i];

                var sSupplierSku = "";
                if (obj.Item_SupplierSku != null) sSupplierSku = obj.Item_SupplierSku;

                var dPrice = parseFloat((obj.Item_WholeSalePrice * obj.Item_Quantity).toFixed(2));
                dTotalPrice = dTotalPrice + dPrice;

                var dSupplierShipFee = 0.0;
                if (obj.Item_SupplierShipFee != null) dSupplierShipFee = obj.Item_SupplierShipFee;
                dTotalShipFee = dTotalShipFee + dSupplierShipFee;

                var sItemHtml = '<tr>' +
						        '<td ><span class="text"> <a href="#">' + obj.Item_TweebaaSku + '</a></span></td>' +
						        '<td><span class="text">' + sSupplierSku + '</span></td>' +
                                '<td><span class="text">' + obj.Item_Quantity + '</span></td>' +
                                '<td><span class="text">' + obj.ProductName + '<br />' + obj.Item_Name + '</span></td>' +
                                '<td><span class="text">$' + parseFloat(obj.Item_WholeSalePrice).toFixed(2) + '</span></td>' +
                                '<td><span clasee="text">$' + dPrice.toFixed(2) + '</span></td>' +
                                '</tr>';
                $("#tbItemList").append(sItemHtml);
            }

            var sTotalHtml = '<tr>' +
						    '<td colspan="5" style="text-align:right; padding:0px; border:0; "><strong>Products :</strong></td>' +
                            '<td style="border:0;line-height:10px;text-align:right;padding-right: 28px;"><strong>$' + dTotalPrice.toFixed(2) + '</strong></td>' +
                            '</tr>';
            var sEstimatedShipFee = '<tr>' +
						            '<td colspan="5" style="text-align:right; border:0;line-height:10px;"><strong>Estimated shipping: </strong></td>' +
                                    '<td style="border:0; line-height:10px;text-align:right;padding-right: 28px;"><strong>$' + dTotalShipFee.toFixed(2) + '</strong></td>' +
                                    '</tr>';
            $("#tbItemList").append(sTotalHtml);
            $("#tbItemList").append(sEstimatedShipFee);
        },
        error: function (obj) {
            alert("Load failed");
        }
    });
}

function GetShipOrderStatusName(status) {
    // status
    var ShipStatus = "";
    if (status == 0) { ShipStatus = 'Un-Paid'; }
    else if (status == 1) { ShipStatus = 'Waiting To Ship'; }
    else if (status == 2) { ShipStatus = 'Shipped'; }
    else if (status == 3) { ShipStatus = 'Partially shipped'; }
    else if (status == -1) { ShipStatus = 'Cancelled'; }
    else if (status == -5) { ShipStatus = 'Returned'; }
    else ShipStatus = status.toString();
    return ShipStatus
}

function GetCountryName(iCountryID) {
    var sCountryName = "Other";
    if (iCountryID == 1) sCountryName = "USA";
    else if (iCountryID == 2) sCountryName = "CANADA";
    else if (iCountryID == 16) sCountryName = "CHINA";
    return sCountryName;
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

function Date2String(d) {
    var weekday = [ "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
    var month = ["Jan.", "Feb.", "Mar.", "Apr.", "May", "Jun.", "Jul.", "Aug.", "Sep.", "Oct.", "Nov.", "Dec."];
    var s = weekday[d.getDay()] + ", " + month[d.getMonth()] + " " + d.getDate() + ", " + d.getFullYear();
    return s;
}
