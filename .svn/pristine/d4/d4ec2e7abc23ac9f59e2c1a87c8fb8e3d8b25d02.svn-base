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
       $("input").placeholder();
       $(".selects").selectCss();

       $(".closeBtn").click(function (event) {
           $(".greybox,.unbind-box").hide();
           return false;
       });

       $("#btnUpdateStatus").click(function (event) {
           if (DoUpdateStatus()) $(".greybox,.unbind-box").hide();
           return false;
       });

       $("#btnAddTrackingNo").click(function (event) {
           if (DoAddTrackingNo()) $(".greybox,.unbind-box").hide();
           return false;
       });

       DoSearch();
   });

function Search() {
    DoSearch();
}

function DoSearch() {
    $("#divNoData").hide();
    $("#kkpager").empty();

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

//get total count, page, 
function LoadTotal() {
    $.ajax({
        type: "Post",
        url: "../AjaxPages/shipOrderAjax.aspx",
        data: "{'action':'querycount','shiporderid':'" + shipOrderID
            + "','trackingno':'" + trackingNo
            + "','orderstatus':'" + orderStatus
            + "','beginTime':'" + beginTime
            + "','endTime':'" + endTime
            + "'}",
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
    else if (status == 1) { ShipStatus = 'To Be Shipping'; }
    else if (status == 2) { ShipStatus = 'Shipped'; }
    else if (status == 3) { ShipStatus = 'Completed'; }
    else if (status == -1) { ShipStatus = 'Cancelled'; }
    else if (status == -2) { ShipStatus = 'Return Goods'; }
    else ShipStatus = status.toString();
    return ShipStatus
}

function LoadShipOrderList() {
    $(".table").empty();
    $.ajax({
        type: "Post",
        url: "../AjaxPages/shipOrderAjax.aspx",
        data: "{'action':'query','shiporderid':'" + shipOrderID
                    + "','trackingno':'" + trackingNo
                    + "','orderstatus':'" + orderStatus
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

            $("#tblShipOrderList tbody").html("");

            // create head html and display it
            var htmlHead = '<tr style="border-right:#f2f2f2 1px solid ;border-left: #f2f2f2 1px solid;">' +
			               '<th width="100">Order #</th>' +
			               '<th width="130">Customer Order #</th>' +
				           '<th width="102">Order Date</th>' +
                           '<th width="70">Total Items</th>' +
                           '<th width="70">Total Price</th>' +
                           '<th width="100">Tracking #</th>' +
				           '<th width="85">Status</th>' +
                           '<th width="105">Action</th>' +
                           '</tr>';
            $(".table").append(htmlHead);

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

                var htmlShipOrder = '<tr>' +
			                          '  <td><span class="text"><a href="#">' + obj.ShipOrder_ID + '</a></span></td>' +
			                          '  <td><span class="text"><a href="#">' + obj.Tweebaa_OrderID + '</a></span></td>' +
                                      '  <td><span class="text">' + OrderDate.toLocaleString() + '</span></td>' +
				                      '  <td><span class="text">' + obj.Qty_Sum + '</span></td>' +
                                      '  <td><span class="text" style="text-align:right">$' + parseFloat(obj.Price_Sum).toFixed(2) + '</span></td>' +
                                      '  <td><span class="text">' + TrackingNo + '</span></td>' +
                                      '  <td><span class="text ">' + ShipStatus + '</span></td>' +
                                      '  <td><span class="text ">' +
                                      '    <select onchange="DoAction(' + obj.ShipOrder_ID + ', this);">' +
                                      '      <option value="0">Choose Action</option>' +
                                      '      <option value="1">Order Details</option>' +
                                      '      <option value="2">Update Status</option>' +
                                      '      <option value="3">Add Tracking </option>' +
                                      '    </select></span>' +
                                      '  </td>' +
                                      '</tr>';

                // display sub-total and details
                $(".table").append(htmlShipOrder);
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
    else if (actionType == "2") { $("#divUpdateStatus").show(); }
    else if (actionType == "3") { $("#divAddTrackingNo").show(); $("#txtAddTrackingNo").focus(); }
    else if (actionType == "4") DoCancelShipOrder(sShipOrderID);
    actionSelect.value = "0";
}

function DoShipOrderDetail(sShipOrderID) {
    //alert(document.location.pathname);
    //alert(document.domain);
    //alert(location.hostname);
    //alert(document.URL);
    //alert(document.location.href);
    //alert(document.location.host);
    //alert(document.location.hostname);
    //alert(document.location.origin);
    var url = document.location.origin + "/Home/HomeOrderDetailSupplier.aspx?id=" + sShipOrderID;
    $("<a>").attr("href", url).attr("target", "_blank")[0].click();
    //alert(sShipOrderID + " shipping order details comming soon...");
}

function DoUpdateStatus() {
    var sShipOrderID = shipOrderIDAction;
    var sStatus = $("#optUpdateStatus option:selected").val();
    var sStatusName = $("#optUpdateStatus option:selected").html();

    if (sStatus == null || sStatus == "") {
        alert("Please select the status you want to update!");
        $("#optUpdateStatus").focus();
        return false;
    }

    // confirm
    if (confirm("Are you sure you want to change the order status to \"" + sStatusName + "\" for order #" + sShipOrderID +"?") == false) return;

    // update ship order status
    var bSuccess = false;
    $.ajax({
        type: "Post",
        url: "../AjaxPages/shipOrderAjax.aspx",
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
        alert("Failed to Update Status!");
        $("#txtUpdateStatus").focus();
    }
    else {
        $(".greybox,.unbind-box").hide();
        DoSearch();
        alert("Order status has been successfully updated.");
    }
    return bSuccess;
}

function DoAddTrackingNo() {
    var sShipOrderID = shipOrderIDAction;
    var sTrackingNo = $.trim($("#txtAddTrackingNo").val());
    if (sTrackingNo == "") {
        alert("Please enter the Tracking #!");
        $("#txtAddTrackingNo").focus();
        return false;
    }

    // add the tracking no
    var bSuccess = false;
    $.ajax({
        type: "Post",
        url: "../AjaxPages/shipOrderAjax.aspx",
        data: "{'action':'addtrackingno','shiporderid':'" + sShipOrderID + "','trackingno':'" + sTrackingNo + "'}",
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
        alert("Failed to Add the Tracking #");
        $("#txtAddTrackingNo").focus();
    }
    else {
        $(".greybox,.unbind-box").hide();
        DoSearch();
        alert("Tracking # has been successfully added.");
    }
    return bSuccess;
}

