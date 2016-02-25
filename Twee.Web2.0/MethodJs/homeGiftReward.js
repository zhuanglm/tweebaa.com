﻿
$.ajaxSetup({ cache: false });

var picPath = "https://tweebaa.com/";
$(document).ready(function () {
    $(".datepicker").datepicker({
        nextText: ">",
        prevText: "<"
    });

    //LoadGiftStatus();
    DoSearch();
}
);
var giftStatus = "";
var page = 1;
var recordCount = 0;
var pageCount = 0;

function DoSearch() {
    LoadGiftRewardList();
}


// retrieve total record count
function LoadCount() {
    var begTime = $("#txtBeginTime").val();
    var endTime = $("#txtEndTime").val();
    var giftName = $("#txtGiftName").val();
    var giftStatus = $("#optStatus").val();
    if (giftStatus == "-1") giftStatus = "";

    $.ajax({
        type: "Post",
        url: "/AjaxPages/homeAjax.aspx",
        data: "{'action':'queryGiftRewardCount','giftName':'" + giftName + "','giftStatus':'" + giftStatus + "','begTime':'" + begTime + "','endTime':'" + endTime + "'}",
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
                    nextPageText: 'Next',
                    nextPageTipText: 'Next',
                    currPageBeforeText: 'Current page ',
                    currPageAfterText: '',
                    totalInfoSplitStr: '/',
                    totalRecordsBeforeText: 'Total: ',
                    totalRecordsAfterText: '',
                    buttonTipBeforeText: 'Page ',
                    buttonTipAfterText: ''
                },
                pno: 1,
                total: pageCount, //总页码                //总数据条数
                totalRecords: recordCount,
                mode: 'click', //默认值是link，可选link或者click
                click: function (n) {
                    page = n;
                    LoadPrd();
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


function LoadGiftRewardList() {

    LoadCount();

    $("#giftList").empty();
    var begTime = $("#txtBeginTime").val();
    var endTime = $("#txtEndTime").val();
    var giftName = $("#txtGiftName").val();

    var giftStatus = $("#optStatus").val();
    if (giftStatus == "-1" || giftStatus == null ) giftStatus = "";

    $.ajax({
        type: "POST",
        url: '/AjaxPages/homeAjax.aspx',
        data: "{'action':'queryGiftRewardList','giftName':'" + giftName + "','giftStatus':'" + giftStatus + "','page':'" + page + "','begTime':'" + begTime + "','endTime':'" + endTime + "'}",
        success: function (resu) {
            if (resu == "") {
                return;
            }
            //$("#tabData tr").empty();
            $("#giftList").html("");
            //var head = '<tr><th style=" width:80px;" >Reward Date</th><th style=" width:160px;">Gift Reward</th><th>Gift Detail</th><th style=" width:80px;">Status</th></tr>';
            //$("#giftList").append(head);
            var obj = eval("(" + resu + ")");
            for (var i = 0; i < obj.length; i++) {
                var gift = obj[i];
                var grantDate = Date2MMDDYYYY(gift.UserGiftReward_GrantDate);

                // gift name
                var giftID = gift.Gift_ID;    // 1: product gift reward,  2: shopping reward point
                var giftName = ""
                if (giftID == 1) {
                    giftName = "(" + gift.UserGiftReward_Quantity + ") " + giftName + gift.ProductName;
                }
                else {
                    giftName = gift.Gift_Name;
                }


                // gift detail
                var giftDetail = "";
                var giftPoint = gift.UserGiftReward_ShoppingRewardPoint;
                var giftMoney = giftPoint / 80;
                var giftDetail = gift.Gift_Detail;
                giftDetail = giftDetail.replace("$$money", "$" + giftMoney.toString());
                giftDetail = giftDetail.replace("$$point", giftPoint.toString());
                giftName = giftName.replace("$$point", giftPoint.toString());
                giftDetail = "<a target='_Top' href='../product/salebuy.aspx?id=" + gift.ProductGuid + "'>" + gift.ProductName + "</a> " + giftDetail;

                // gift status
                var giftStatusID = gift.GiftStatus_ID;
                var giftStatus = gift.GiftStatus_Name;
                if (giftStatusID == 2) // shipped need a link to the Ship Order
                {
                    giftStatus = "<a href='#'>" + gift.GiftStatus_Name + "</a> ";
                }
                var prdGuid = gift.ProductGuid;
                var prdName = gift.ProductName;

               /* html = '<tr ><td>' + grantDate + '</td>' +
                       '<td>' + giftName + '</td>' +
                       '<td style="word-wrap:break-word; text-align:left">' + giftDetail + '</td>' + 
                       '<td>' + giftStatus + '</td>' +
                       '</tr>';
                */
                html = '<tr><td>' + giftName + '</td><td>' + giftStatus + '</td><td class="hidden-sm">' + giftDetail + '</td><td>' + grantDate + '</td></tr>';
                $("#giftList").append(html);
            }
        },
        error: function (obj) {
            // alert("Load failed");
        }
    });
}

function LoadGiftStatus() {
    $("#optStatus").empty();
    $("#optStatus").append($("<option></option>").val("-1").html("All"));
    $.ajax({
        type: "POST",
        url: '/AjaxPages/homeAjax.aspx',
        async: false,
        data: "{'action':'getGiftStatusList'}",
        success: function (resu) {
            if (resu == "") {
                return;
            }
            var obj = eval("(" + resu + ")");
            for (var i = 0; i < obj.length; i++) {
                var status = obj[i];
                $('#optStatus').append($('<option></option>').val(status.GiftStatus_ID).html(status.GiftStatus_Name));
            }
        },
        error: function (obj) {
            // alert("Load failed");
        }
    });
    $("#optStatus").val("-1");
}



function Date2MMDDYYYY(s) {
    var sRet = s.replace(/-/g, '/').substring(0, 10);
    if (sRet.substring(4, 5) == "/" && sRet.substring(7, 8) == "/") {
        sRet = s.substring(5, 7) + "/" + s.substring(8, 10) + "/" + s.substring(0, 4);
    }
    return sRet;
}