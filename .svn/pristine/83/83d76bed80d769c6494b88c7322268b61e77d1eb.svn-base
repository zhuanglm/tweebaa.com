
$.ajaxSetup({ cache: false });

var picPath = "https://tweebaa.com/";
$(document).ready(function () {
    LoadGiftStatus();
    LoadRewardGift();
}
);
var giftStatus = "";
var page = 1;
var recordCount = 0;
var pageCount = 0;

// retrieve total record count
function LoadCount() {
    var begTime = $("#txtBegTime").val();
    var endTime = $("#txtEndTime").val();
    var giftName = $("#txtGiftName").val();
    var giftStatus = $("#optStatus").val();
    if (giftStatus == "-1") giftStatus = "";

    $.ajax({
        type: "Post",
        url: "../AjaxPages/homeAjax.aspx",
        data: "{'action':'queryRewardGiftCount','giftName':'" + giftName + "','giftStatus':'" + giftStatus + "','begTime':'" + begTime + "','endTime':'" + endTime + "'}",
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
                    totalRecordsBeforeText: '',
                    totalRecordsAfterText: '条数据',
                    gopageBeforeText: ' 转到',
                    gopageButtonOkText: '确定',
                    gopageAfterText: '页',
                    buttonTipBeforeText: '第',
                    buttonTipAfterText: '页'
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


function LoadRewardGift() {

    LoadCount();

    $(".gift-list").empty();
    var begTime = $("#txtBegTime").val();
    var endTime = $("#txtEndTime").val();
    var giftName = $("#txtGiftName").val();

    var giftStatus = $("#optStatus").val();
    if (giftStatus == "-1") giftStatus = "";

    $.ajax({
        type: "POST",
        url: '../AjaxPages/homeAjax.aspx',
        data: "{'action':'queryRewardGift','giftName':'" + giftName + "','giftStatus':'" + giftStatus + "','page':'" + page + "','begTime':'" + begTime + "','endTime':'" + endTime + "'}",
        success: function (resu) {
            if (resu == "") {
                return;
            }
            //$("#tabData tr").empty();
            $("#tabData tbody").html("");
            var head = '<tr><th style=" width:200px;" >Grant Date</th><th>Gift Name</th><th>Source</th><th>Status</th><th>Remark</th></tr>';
            $(".gift-list").append(head);
            var obj = eval("(" + resu + ")");
            for (var i = 0; i < obj.length; i++) {
                var gift = obj[i];
                var grantDate = gift.UserRewardGift_GrantDate.replace(/-/g, '/').substring(0, 10);
                var giftName = gift.Gift_Name;
                var giftSource = gift.GiftSource_Name;
                var giftStatus = gift.GiftStatus_Name;
                var giftRemark = "";


                // set gidt list henl
                html = '<tr><td>' + grantDate + '</td>' +
                       '<td>' + giftName + '</td>' +
                       '<td>' + giftSource + '</td>' +
                       '<td>' + giftStatus + '</td>' +
                       '<td>' + giftRemark + '</td>' +
                       '</tr>';
                $(".gift-list").append(html);
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
        url: '../AjaxPages/homeAjax.aspx',
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



