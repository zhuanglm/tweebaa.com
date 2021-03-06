﻿
var beginTime = $("#txtBeginTime").val();
var endTime = $("#txtEndTime").val();


$(document).ready(
   function () {
       /*
       var Request = new Object();
       Request = GetRequest();
       state = Request["state"];*/
       DoSearch();
   });
function DoSearch() {
    beginTime = $("#txtBeginTime").val();
    endTime = $("#txtEndTime").val();
    $("#divNoData").hide();
    loadCount();
    loadSearchResult();
}

function loadSearchResult() {

    var beginTime = $("#txtBeginTime").val();
    var endTime = $("#txtEndTime").val();
    
    if (beginTime == undefined) beginTime = "";
    if (endTime == undefined) endTime = "";

    $.ajax({
        type: "Post",
        url: "/AjaxPages/HomeSharePointRedeem.aspx",
        data: "{'action':'query','beginTime':'" + beginTime
                    + "','endTime':'" + endTime + "'}",
        async: false,
        success: function (resu) {
            if (resu == "") {
                $("#redeemBody").html("");
                return;
            }
            var sHtml = "";
            var obj = eval("(" + resu + ")");

            for (var i = 0; i < obj.length; i++) {
                var data = obj[i];

                sHtml = sHtml + "<tr><td>$" + data.PointsRedeem / 100 + " Discount </td>";
                sHtml = sHtml + "<td>Order:<a target='_blank' href='/Home/HomeOrderInfo.aspx?headguid=" + data.OrderHeadGuid + "'>" + data.guidno + "</td>";
                sHtml = sHtml + "<td>" + data.RedeemDate.substring(0,10) + "</td></tr>";
            }
            $("#redeemBody").html(sHtml);
        },
        error: function (obj) {
            // alert("Load failed");
        }
    });
}

//获取总记录数、页数
function loadCount() {
    $("#kkpager").empty();
    var beginTime = $("#txtBeginTime").val();
    var endTime = $("#txtEndTime").val();
    if (beginTime == undefined) beginTime = "";
    if (endTime == undefined) endTime = "";

    $.ajax({
        type: "Post",
        url: "/AjaxPages/HomeSharePointRedeem.aspx",
        data: "{'action':'query_amount','beginTime':'" + beginTime
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