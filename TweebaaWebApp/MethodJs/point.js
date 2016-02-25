﻿$(document).ready(
   function () {
       loadPoint();
       loadPointShop();
   }
);

var page = 1;
var type = "";
var totalCount = 0;
var pageCount = 0;

function serch(obj) {

    $("#divNoDataRewardPoint").hide();        
    var bAllRewardPoint = false;
    var bSubmitRewardPoint = false;
    var bEvaluateRewardPoint = false;
    var bShareRewardPoint = false;

    if ($("#ckb0").attr("checked")) bAllRewardPoint = true;
    if ($("#ckb1").attr("checked")) bSubmitRewardPoint = true;
    if ($("#ckb2").attr("checked")) bEvaluateRewardPoint = true;
    if ($("#ckb3").attr("checked")) bShareRewardPoint = true;
    if (obj == "ckb0") bAllRewardPoint = !bAllRewardPoint;
    if (obj == "ckb1") bSubmitRewardPoint = !bSubmitRewardPoint;
    if (obj == "ckb2") bEvaluateRewardPoint = !bEvaluateRewardPoint;
    if (obj == "ckb3") bShareRewardPoint = !bShareRewardPoint;
    type = "";
    if (bAllRewardPoint) type = "";
    else {
        if (bSubmitRewardPoint) type += "1,";
        if (bEvaluateRewardPoint) type += "2,";
        if (bShareRewardPoint) type += "3,";
    }

 //      alert(bAllRewardPoint + " " + bSubmitRewardPoint + " " + bEvaluateRewardPoint + " " + bShareRewardPoint);
    if (type.length > 0) type = type.substring(0, type.length - 1);
    $("#kkpager").empty();
    page = 1;
    loadPoint();
    //kkpager.selectPage(1);
}

function loadPoint() {
    $("#profit-data").empty();
    var _data = "{ action:'queryPoint',page:'" + page + "',type:'" + type + "'}";
    $.ajax({
        type: "POST",
        url: '../AjaxPages/homeAjax.aspx',
        dataType: "json",
        data: _data,
        async: false,
        success: function (resu) {
            if (resu == "" || resu == null) {
                $("#kkpager").empty();
                $("#divNoDataRewardPoint").show();
                return;
            }
            var data = eval(resu);
            var dataCount2 = data[data.length - 2];
            var dataCount1 = data[data.length - 1];
            totalCount = dataCount2.totalCount;
            pageCount = dataCount1.pageCount;
            var typeName = "";
            for (var i = 0; i < data.length - 2; i++) {
                var obj = data[i];
                if (obj.type == "1") {
                    typeName = "Submit Reward points";
                }
                if (obj.type == "2") {
                    typeName = "Evaluate Reward points";
                }
                if (obj.type == "3") {
                    typeName = "Share Reward points";
                }
                //                if (obj.type == "4") {
                //                    type = "Shopping Reward points";
                //                }
                if (obj.type == "5") {
                    typeName = "Browse Reward points";
                }
                var remark = obj.remark;
                if (remark == null) {
                    remark = "";
                }
                var time = ChangeTime(obj.addTime);
                var tr = '<tr><td>' + time + '</td> <td>+' + obj.point + '</td><td><i class="blue">' + typeName + '</i></td><td>' + remark + '</td></tr>';
                if (obj.type != "4") {
                    $("#profit-data").append(tr);
                }
            }

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
                },
                pno: 1,
                total: pageCount,           //总页码
                totalRecords: totalCount,   //总数据条数
                mode: 'click', //默认值是link，可选link或者click
                click: function (n) {
                    page = n;
                    loadPoint();
                    //手动选中按钮
                    this.selectPage(n);
                    return false;
                }
            }, true);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //alert("aa");
        }
    });
};

function loadPointShop() {   
    var type = "4";
    var _data = "{ action:'shopPoint',page:'" + page + "',type:'" + type + "'}";
    $.ajax({
        type: "POST",
        url: '../AjaxPages/homeAjax.aspx',
        dataType: "json",
        data: _data,
        success: function (resu) {

            if (resu == "" || resu == null) {
                return;
            }
            var data = eval(resu);
            var dataCount2 = data[data.length - 2];
            var totalCount = dataCount2.totalCount;
            var dataCount1 = data[data.length - 1];
            var pageCount = dataCount1.pageCount;
            var type = "";

            for (var i = 0; i < data.length - 2; i++) {
                var obj = data[i];
                var time = ChangeTime(obj.addTime);
                var remark = obj.remark;
                if (remark == null) {
                    remark = "";
                }              
                var tr = '<tr><td>' + time + '</td> <td>+' + obj.point + '</td><td><i class="blue">Order ID：' + obj.orderNo + '</i></td><td>' + remark + '</td></tr>';
                $("#profit-data2").append(tr);
            }
            kkpager2.generPageHtml({
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
                totalRecords: totalCount, //总数据条数
                mode: 'click', //默认值是link，可选link或者click
                click: function (n) {
                    page = n;
                    loadPointShop();
                    //手动选中按钮
                    this.selectPage(n);
                    return false;
                }
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //alert("aa");
        }
    });
};

function ChangeTime(strTime) {
    var _usaTime = "";
    if (strTime != null && strTime.length > 0) {
        var i = strTime.indexOf("T");
        var usaFormat = strTime.substring(0, i);
        var usaArray = usaFormat.split('-');
        var _year = usaArray[0];
        var _month = usaArray[1];
        var _day = usaArray[2];
        //_usaTime = _month + "/" + _day + "/" + _year;
        _usaTime = _year + "/" + _month + "/" + _day;
        return _usaTime;
    }
    return "";
}