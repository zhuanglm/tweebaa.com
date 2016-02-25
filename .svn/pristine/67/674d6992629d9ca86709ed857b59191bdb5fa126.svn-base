var page = 1;
var recordCount = 0;
var pageCount = 0;
var shipOrderID = "";           // ship order id for search
var trackingNo = "";            // tracking for search
var orderStatus = "";           // order status for search
var shipOrderIDAction = "";     // ship order id for action
var beginTime = "";
var endTime = "";

$(document).ready(
   function () {
       $(".datepicker").datepicker({
           nextText: ">",
           prevText: "<"
       });
       DoSearch();
   });

function Search() {
    DoSearch();
}

function DoSearch() {

    $("#divNoData").hide();
    $("#kkpager").empty();
    $("#kkpager").show();

    //Show shipping order sum by status
    ShowShipOrderSumByStatus();


    shipOrderID = $("#txtShipOrderID").val();
    trackingNo = $("#txtTrackingNo").val();
    orderStatus = $("#optStatus option:selected").val();

    beginTime = $("#txtBeginTime").val();
    endTime = $("#txtEndTime").val();

    page = 1;
    LoadTotal();
    LoadShipOrderList();

    // pno does not work, have to select page 1 here
    if (recordCount > 0) kkpager.selectPage(page);
}


//Show shipping order sum by status
function ShowShipOrderSumByStatus() {
    $.ajax({
        type: "Post",
        url: "/AjaxPages/shipOrderAjax.aspx",
        data: "{'action':'querycountbystatus'}",
        async: false,
        success: function (resu) {

            if (resu == "" || resu == "[]" || resu == "0") {
                return;
            }

            var objList = eval("(" + resu + ")");

            var iToBeShipSum = 0;
            var iShippedSum = 0;
            //var iCompletedSum = 0;
            var iCancelSum = 0;
            for (var i = 0; i < objList.length; i++) {
                obj = objList[i];

                // status 
                var iStatus  = obj.ShipOrder_Status;
                if (iStatus == 1 )   iToBeShipSum += obj.ShipOrder_Count ;          // waiting to ship
                else if (iStatus == 2) iShippedSum += obj.ShipOrder_Count;          // shipped
                //else if (iStatus == 3) iCompletedSum += obj.ShipOrder_Count;      // completed
                else if (iStatus == -1 ) iCancelSum += obj.ShipOrder_Count;         // canceled 
            } // end of loop for each sum of status

            $("#spnToBeShipSum").html(iToBeShipSum.toString());
            $("#spnShippedSum").html(iShippedSum.toString());
            //$("#spnCompletedSum").html(iCompletedSum.toString());
            $("#spnCancelSum").html(iCancelSum.toString());


        }, // end of ajax success
        error: function (obj) {
            //alert("Load failed");
        }
    });
}

//get total count, page, 
function LoadTotal() {
    $.ajax({
        type: "Post",
        url: "/AjaxPages/shipOrderAjax.aspx",
        data: "{'action':'querycount','shiporderid':'" + shipOrderID
            + "','trackingno':'" + trackingNo
            + "','orderstatus':'" + orderStatus
            + "','beginTime':'" + beginTime
            + "','endTime':'" + endTime
            + "'}",
        async: false,
        success: function (resu) {
            if (resu == "" || resu == "0") {
                return;
            }

            var arry = new Array();
            arry = resu.split(",");
            recordCount = arry[0];
            pageCount = arry[1];
            kkpager.generPageHtml({
                pno: 1,
                total: pageCount, //总页码
                totalRecords: recordCount,     //总数据条数
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
                },
                mode: 'click', //默认值是link，可选link或者click
                click: function (n) {
                    page = n;
                    LoadShipOrderList();
                    this.selectPage(n); //手动选中按钮
                    return false;
                }
            });

            // pno does not work, have to select page 1 here
            //page = 1;
            //kkpager.selectPage(page);
        },
        error: function (obj) {
            // alert("Load failed");
        }
    });
}

function GetShipOrderStatusName(status) {
    // status
    var ShipStatus = "";
    if (status == 0) { ShipStatus = 'Un-Paid'; }
    else if (status == 1) { ShipStatus = 'Waiting to ship'; }
    else if (status == 2) { ShipStatus = 'Shipped'; }
    else if (status == 3) { ShipStatus = 'Partially shipped'; }
    else if (status == -1) { ShipStatus = 'Cancelled'; }
    else if (status == -5) { ShipStatus = 'Returned'; }
    //else if (status == -2) { ShipStatus = 'Return Goods'; }
    else ShipStatus = status.toString();
    return ShipStatus
}

function LoadShipOrderList() {
    $("#tblShipOrderList").html("");
    $.ajax({
        type: "Post",
        url: "/AjaxPages/shipOrderAjax.aspx",
        data: "{'action':'query','shiporderid':'" + shipOrderID
                    + "','trackingno':'" + trackingNo
                    + "','orderstatus':'" + orderStatus
                    + "','beginTime':'" + beginTime
                    + "','endTime':'" + endTime
                    + "','page':'" + page
                    + "'}",
        async: false,
        success: function (resu) {
            if (resu == "" || resu == "[]" || resu == "0") {
                $("#kkpager").hide();
                $("#divNoData").show();
                return;
            }


            // create head html and display it
            var htmlHead = '<tr >' +
			               '<th >Order #</th>' +
			               '<th width="140">Customer Order #</th>' +
				           '<th class="hidden-sm">Order Date</th>' +
                           '<th class="hidden-sm" style="text-align:center">Total Items</th>' +
                           '<th class="hidden-sm" style="text-align:center">Total Price</th>' +
                           '<th class="hidden-sm">Tracking #</th>' +
				           '<th>Status</th>' +
                           '<th>Action</th>' +
                           '</tr>';
            $("#tblShipOrderList").append(htmlHead);

            var objList = eval("(" + resu + ")");

            for (var i = 0; i < objList.length; i++) {
                obj = objList[i];

                // order date
                var OrderDate = new Date(obj.ShipOrder_Date);

                // tracking number
                var TrackingNo = "";
                if (obj.ShipOrder_TrackingNo != null) TrackingNo = obj.ShipOrder_TrackingNo;

                // status
                var ShipStatus = GetShipOrderStatusName(obj.ShipOrder_Status);

                // set status display class
                var StatusClass = "";
                if (obj.ShipOrder_Status == 1) StatusClass = "label label-warning";
                else if (obj.ShipOrder_Status == 2) StatusClass = "label label-info";
                else if (obj.ShipOrder_Status == 3) StatusClass = "label label-success";
                else StatusClass = "label label-danger";

                var supplierPriceSum = "";
                if (obj.SupplierPrice_Sum == null) supplierPriceSum = "Unknown";
                else supplierPriceSum = "$" + parseFloat(obj.SupplierPrice_Sum).toFixed(2);

                var htmlShipOrder = '<tr>' +
			                          '  <td><span ><a href="#">' + obj.ShipOrder_ID + '</a></span></td>' +
			                          '  <td><span ><a href="#">' + obj.Tweebaa_OrderID + '</a></span></td>' +
                                      '  <td nowrap><span >' + OrderDate.toLocaleString() + '</span></td>' +
				                      '  <td class="hidden-sm" style="text-align:center"><span >' + obj.Qty_Sum + '</span></td>' +
                                      '  <td class="hidden-sm" style="text-align:right"><span >' + supplierPriceSum + '</span></td>' +
                                      '  <td class="hidden-sm"><span >' + TrackingNo + '</span></td>' +
                                      '  <td><span class="' + StatusClass + '">' + ShipStatus + '</span></td>' +
                                      '  <td><span class="text ">' +
                                      '    <select onchange="DoAction(' + obj.ShipOrder_ID + ', this);">' +
                                      '      <option value="0">Choose Action</option>' +
                                      '      <option value="1">Order Details</option>' +
                                      '      <option value="2">Shipment</option>' +
                                      '      <option value="3">Return</option>' +
                                      '      <option value="4">Cancel</option>' +
                                      //'      <option value="5">Add Tracking </option>' +
                                      '    </select></span>' +
                                      '  </td>' +
                                      '</tr>';

                // display sub-total and details
                $("#tblShipOrderList").append(htmlShipOrder);
            } // end of loop for each shipping order
        }, // end of ajax success
        error: function (obj) {
            //alert("Load failed");
        }
    });
}

function DoAction(sShipOrderID, actionSelect) {
    shipOrderIDAction = sShipOrderID;
    var actionType = actionSelect.value;
    if (actionType == "1") DoShipOrderDetail(sShipOrderID);
    else if (actionType == "2") {
        $("#divShipment").modal("show");
        //$("#optUpdateStatus").focus();
    }
    else if (actionType == "3") {
        $("#divReturn").modal("show");
        //$("#optUpdateStatus").focus();
    }
    else if (actionType == "4") {
        DoCancelShipOrder(sShipOrderID);
    }
    actionSelect.value = "0";
}

function DoShipOrderDetail(sShipOrderID) {
    var url = document.location.origin + "/Home/HomeOrderDetailSupplier.aspx?id=" + sShipOrderID;
    $("<a>").attr("href", url).attr("target", "_blank")[0].click();
    //alert(sShipOrderID + " shipping order details comming soon...");
}

function DoCancelShipOrder() {
    var sShipOrderID = shipOrderIDAction;

    // confirm
    if (confirm("Are you sure you want to cancel the order : " + sShipOrderID +"?") == false) return;

    sStatus = "-1";

    // update ship order status
    var bSuccess = false;
    $.ajax({
        type: "Post",
        url: "/AjaxPages/shipOrderAjax.aspx",
        data: "{'action':'updatestatus','shiporderid':'" + sShipOrderID + "','status':'" + sStatus + "'}",
        async: false,
        success: function (resu) {
            if (resu == "1") {
                bSuccess = true;
                return;
            }
        },
        error: function (obj) {
            bSuccess = false;
        }
    });

    if (bSuccess == false) {
        alert("Failed to Cancel the Order!");
    }
    else {
        DoSearch();
        alert("Order has been cancelled successfully.");
    }
    return bSuccess;
}

function DoSaveShipment() {
    
    var sShipOrderID = shipOrderIDAction;
    var sShippedDate = $.trim($("#txtShipmentShippedDate").val());
    var sCarrierName = $.trim($("#txtShipmentCarrierName").val());
    var sTrackingNo = $.trim($("#txtShipmentTrackingNo").val());
    
    if (!IsDate(sShippedDate)) {
        alert("Please enter a valid shipped date mm/dd/yyyy!");
        $("#txtShipmentShippedDate").focus();
        return;
    }

    if (sTrackingNo == "") {
        alert("Please enter the Tracking #!");
        $("#txtShipmentTrackingNo").focus();
        return false;
    }

    if (sCarrierName == "") {
        alert("Please enter the Carrier Name!");
        $("#txtShipmentCarrierName").focus();
        return false;
    }

    // Save Shipment
    var bSuccess = false;
    var sAjaxData = "{'action':'SaveShipment'," +
                    "'ShipOrderID':'" + sShipOrderID + "'," +
                    "'ShippedDate':'" + sShippedDate + "'," +
                    "'TrackingNo':'" + sTrackingNo + "'," + 
                    "'CarrierName':'" + sCarrierName + "'}";
    $.ajax({
        type: "Post",
        url: "/AjaxPages/shipOrderAjax.aspx",
        data: sAjaxData,
        async: false,
        success: function (resu) {
            if (resu == "1") {
                bSuccess = true;
                return;
            }
        },
        error: function (obj) {
            bSuccess = false;
        }
    });

    if (bSuccess == false) {
        alert("Failed to save the shipment!");
        $("#txtShipmentShippedDate").focus();
    }
    else {
        $("#divShipment").modal('hide');
        DoSearch();
        alert("Shipment has been successfully saved.");
    }
    return bSuccess;
}


function DoSaveReturn() {

    var sShipOrderID = shipOrderIDAction;
    var sReturnDate = $.trim($("#txtReturnDate").val());
    var sReturnQuality = $("#optReturnQuality option:selected").val();
    var sReturnReasonCode =$.trim( $("#optReturnReason option:selected").val());
    var sReturnReasonDesc =$.trim( $("#optReturnReason option:selected").text());
    var sReturnAction =$.trim( $("#optReturnAction option:selected").val());

    if (!IsDate(sReturnDate)) {
        alert("Please enter a valid return date mm/dd/yyyy!");
        $("#txtReturnDate").focus();
        return;
    }

    if (sReturnQuality == "") {
        alert("Please select the return quality!");
        $("#optReturnQuality").focus();
        return false;
    }

    if (sReturnReasonCode == "") {
        alert("Please select the return reason!");
        $("#optReturnReason").focus();
        return false;
    }

    if (sReturnAction == "") {
        alert("Please select the return action!");
        $("#optReturnAction").focus();
        return false;
    }


    // Save return
    var bSuccess = false;
    var sAjaxData = "{'action':'SaveReturn'," +
                    "'ShipOrderID':'" + sShipOrderID + "'," +
                    "'ReturnDate':'" + sReturnDate + "'," +
                    "'ReturnQuality':'" + sReturnQuality + "'," +
                    "'ReturnReasonCode':'" + sReturnReasonCode + "'," +
                    "'ReturnReasonDesc':'" + sReturnReasonDesc + "'," +
                    "'ReturnAction':'" + sReturnAction + "'}";
    $.ajax({
        type: "Post",
        url: "/AjaxPages/shipOrderAjax.aspx",
        data: sAjaxData,
        async: false,
        success: function (resu) {
            if (resu == "1") {
                bSuccess = true;
                return;
            }
        },
        error: function (obj) {
            bSuccess = false;
        }
    });

    if (bSuccess == false) {
        alert("Failed to save the return!");
        $("#txtReturnDate").focus();
    }
    else {
        $("#divReturn").modal('hide');
        DoSearch();
        alert("Return has been successfully saved.");
    }
    return bSuccess;
}


