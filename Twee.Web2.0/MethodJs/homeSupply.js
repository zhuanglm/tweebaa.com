﻿
$.ajaxSetup({ cache: false });

var picPath = "https://tweebaa.com/";
$(document).ready(function () {
    loadCount();
    loadGrandTotal();
    LoadPrd();
}
);
var state = "";
var page = 1;
var recordCount = 0;
var pageCount = 0;
var begTime = $("#txtBeginTime").val();
var endTime = $("#txtEndTime").val();

function DoProductStatusChange() {
    state = $("#optProductStatus option:selected").val();
    DoSearch();
}
//function SetState(prdstate) {
//    state = prdstate;
   
//    // need to search ALL product statge again
//    if (prdstate == -1) state = "";
//    DoSearch();
//}

function DoSearch() {
    $("#divNoData").hide();
    
    begTime = $("#txtBeginTime").val();
    endTime = $("#txtEndTime").val();


    //loadCount();
    loadGrandTotal();
    LoadPrd();
}

//获取总记录数、页数
function loadCount() {
    $.ajax({
        type: "Post",
        url: "/AjaxPages/homeAjax.aspx",
        data: "{'action':'queryhomecount','state':'" + state + "','begTime':'" + begTime + "','endTime':'" + endTime + "'}",
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


function LoadPrd() {
    $("#tbData").empty();
    $.ajax({
        type: "POST",
        url: '/AjaxPages/homeAjax.aspx',
        data: "{'action':'1','state':'" + state + "','page':'" + page + "','begTime':'" + begTime + "','endTime':'" + endTime + "'}",
        async: false,
        success: function (resu) {
            if (resu == "" || resu == "[]") {
                $("#kkpager").empty();
                $("#divNoData").show();
                return;
            }
            $("#tbData").html("");
            var obj = eval("(" + resu + ")");
            var urlPage = "'submitReview.aspx'";
            var prdUrl = "";
            var display = 'style="display:none;"';
            for (var i = 0; i < obj.length; i++) {
                var prd = obj[i];
                var stateTxt = "";
                var state = prd.wnstat;
                var price = 0;

                ///Add by Long base on issue #33,34,35
                var IsShare = 1;
                var IsEdit = 0;
                var IsDeleted = 1;
                if (state == 0 || state == -1 || state == 11 || state == 12 || state == 9 || state == 10) {
                    IsShare = 0;
                }
                if (state == 0 || state == 12) {
                    IsEdit = 1;
                }
                if (state == 0 || state == 12) {
                    IsDeleted = 1;
                }
                //Add by Long EOF

                if (state == 0) {
                    stateTxt = "Draft";
                    //prdUrl = "../Product/submitReview.aspx?id=" + prd.prdguid;
                    prdUrl = "/Product/SubmitForm.aspx?action=edit&id=" + prd.prdguid;  // only allow to edit
                    price = prd.estimateprice;
                }
                else if (state == 11) {   // 11: product submitted and waiting tweebaa's pending approval 
                    stateTxt = "Pending Approval";
                    prdUrl = "../Product/submitReview.aspx?id=" + prd.prdguid;
                    price = prd.estimateprice;
                }
                else if (state == 1) {
                    stateTxt = "Public Evaluating";
                    prdUrl = "../Product/submitReview.aspx?id=" + prd.prdguid;
                    price = prd.estimateprice;
                }
                else if (state == 4) {
                    stateTxt = "Tweebaa Evaluating";
                    prdUrl = "../Product/submitReview.aspx?id=" + prd.prdguid;
                    price = prd.estimateprice;
                }
                else if (state == 2) {
                    stateTxt = "Test-Sale";
                    urlPage = "presaleBuy.aspx";
                    prdUrl = "../Product/presaleBuy.aspx?id=" + prd.prdguid;
                    price = prd.estimateprice;
                }
                else if (state == 3) {
                    stateTxt = "Buy Now";
                    urlPage = "saleBuy.aspx";
                    prdUrl = "../Product/saleBuy.aspx?id=" + prd.prdguid;
                    price = prd.saleprice;
                }
                else if (state == 7) {
                    stateTxt = "Test-Sale Failed";
                    urlPage = "presaleBuy.aspx";
                    prdUrl = "../Product/presaleBuy.aspx?id=" + prd.prdguid;
                    price = prd.estimateprice;
                }

                var prdid = "'" + prd.prdguid + "'";
                var prdname = "'" + escape(prd.name) + "'";
                var prdimg = "'" + picPath + prd.fileurl + "'";
                var errorImg = "onerror=\"this.src='http://itweebaa.com" + prd.fileurl + "'\"";
                var time = prd.addtime.replace(/-/g, '/').substring(0, 10);
                var reviewCount = prd.reviewCount; //评审总数
                if (reviewCount == null) reviewCount = 0;
                var maxReview = 300;
                var progressBarPercent = (reviewCount / maxReview) * 100;
                if (reviewCount > 0 && progressBarPercent < 1) progressBarPercent = 1;
                if (progressBarPercent <= 0) progressBarPercent = 1;   // at lease 1 percentage

                var prdDesc = "'" + escape(prd.txtjj) + "'";

                var prdImgSrc = "/images/no_image.png";
                if (prd.fileurl != null && prd.fileurl != "") {
                    prdImgSrc = picPath + prd.fileurl;
                }

                //产品信息 
                var html = "";
                html += '<tr>';
                html += '<td style="width: 20%" class="hidden-sm"><div> <a href="' + prdUrl + '"><img '+errorImg +' src="' + prdImgSrc + '" alt="" width="100"></a> </div> </td>';

                html += '<td style="width: 30%"><h5><a href="' + prdUrl + '">' + prd.name + '</a></h5> <h6> $' + price.toFixed(2) + '<h5><small>Suggest time : ' + Date2MMDDYYYY(prd.addtime) + '</small></h5></td>';

                html += '<td style="width: 25%; vertical-align: middle; padding: 0 20px;"> <h3 class="heading-xs">' + stateTxt + '</h3> <div class="progress progress-u progress-xs"> <div class="progress-bar progress-bar-blue" role="progressbar" aria-valuenow="76" aria-valuemin="0" aria-valuemax="100" style="width: ' + progressBarPercent + '%"></div></div><h3 class="heading-xs"> Evaluators: ' + reviewCount + '/' + maxReview + '</h3></td>';

                html += '<td style="width: 20%; vertical-align: middle">';
                if (IsShare) {
                    //SharePrd_ShortDesc(id, name, img, page, desc, product_short_desc, saleprice)
                    html += '<button class="btn rounded btn-default btn_mg" type="button" onclick="SharePrd_ShortDesc(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + prdDesc + ',' + price.toFixed(2) + ')">';
                    html += ' <i class="fa fa-share-alt"></i>';
                    html += '</button>';
                }
                if (IsEdit) {
                    html += '<button class="btn rounded btn-default btn_mg" type="button" onclick="EditPrd(' + prdid + ')">';
                    //html += '<a class="btn rounded btn-default btn_mg" href="../Product/SubmitForm.aspx?action=edit&id=' + prd.prdguid + '" target="_blank" ></a>';
                    html += '<i class="fa  fa-pencil-square-o"></i>';
                    html += '</button>';
                }
                if (IsDeleted) {
                    html += '<button class="btn rounded btn-default btn_mg" type="button" onclick=" DeletePrd(' + prdid + ')">';
                    html += '<i class="fa  fa-trash"></i>';
                    html += '</button>';
                }
                html += '</td>';
                html += '</tr>';
                /*
                if (state == 0 || state == 1 || state == 11) {
                html = '<tr><td><a href="' + prdUrl + '"  target="_blank" class="imglink fl"><img src="' + picPath + prd.fileurl + '" alt="' + prdname + '" /></a><div class="pro-title fl" style="width:120px; margin-left:20px;"><a href="' + prdUrl + '" target="_blank">' + prd.name + '</a><p>Submitted on：<br/>' + time + '</p></div></td><td style="width:200px;"><div class="state-ing">' + stateTxt + '</div><div class="jdt"><span style="width: ' + progressBarPercent + '%;"></span></div><div class="participant">	Evaluators: ' + reviewCount + '/' + maxReview + '</div></td>';
                html += '<td><div class="btn-group">';
                if(IsShare==1)
                html += '<a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" class="share">Share</a>';
                if(IsEdit==1)
                html+='<a href="../Product/issue.aspx?action=edit&id=' + prd.prdguid + '" target="_blank" >Edit</a>';
                if(IsDeleted==1)
                html+='<a href="javascript:void(0)" onclick=" DeletePrd(' + prdid + ')" >Delete</a></div></td></tr>';
                }
                else {
                html = '<tr><td><a href="' + prdUrl + '"  target="_blank" class="imglink fl"><img src="' + picPath + prd.fileurl + '" alt="' + prdname + '" /></a><div class="pro-title fl" style="width:120px; margin-left:20px;"><a href="' + prdUrl + '" target="_blank">' + prd.name + '</a><p>Submitted on：<br/>' + time + '</p></div></td><td style="width:200px;"><div class="state-ing">' + stateTxt + '</div><div class="jdt"><span style="width: ' + progressBarPercent + '%;"></span></div><div class="participant">	Evaluators: ' + reviewCount + '/' + maxReview + '</div></td><td><div class="btn-group">';
                if (IsShare == 1)
                html += '<a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" class="share">Share</a>';
                if (IsDeleted == 1)
                html+='<a href="javascript:void(0)" onclick=" DeletePrd(' + prdid + ')" >Delete</a></div></td></tr>';
                }
                */
                $("#tbData").append(html);
            }
        },
        error: function (obj) {
            // alert("Load failed");
        }
    });


}

function EditPrd(prdid) {
    window.location.href = '../Product/SubmitForm.aspx?action=edit&id=' + prdid;
}

function Edit(url)
{
   window.open(url);
}

//删除我的发布（评审中）
function DeletePrd(prdid) {
    if (!confirm("Sure to delete?")) {
        return;
    }
    if (prdid != null && prdid!="") {
        $.ajax({
            type: "POST",
            url: '/AjaxPages/homeAjax.aspx',
            data: "{'action':'delete','id':'" + prdid + "'}",
            success: function (resu) {
                if (resu == "True") {
                    alert("Delete successful! ");
                }
                else {
                    alert("Delete failed!");
                }
                DoSearch();
            },
            error: function (obj) {
                alert("Delete failed!");
            }
        });
    }
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

//get ground total of test sale, final sale and suggest commission
function loadGrandTotal() {
    var grandTotalTestSaleCount = 0;
    var grandTotalFinalSaleCount = 0;
    var grandTotalSuggestCommission = 0.0;
    $.ajax({
        type: "Post",
        url: "/AjaxPages/homeAjax.aspx",
        data: "{'action':'querysuggestgrandtotal'}",
        async: false,
        success: function (resu) {

  //          alert(resu);

            if (resu == "") {
                return;
            }

            var arry = new Array();
            arry = resu.split(",");
            grandTotalTestSaleCount = arry[0];
            grandTotalFinalSaleCount = arry[1];
            grandTotalSuggestCommission = parseFloat(arry[2]);
        },
        error: function (obj) {
            // alert("Load failed");
        }
    });
    $("#spnGrandTotalTestSaleCount").html(grandTotalTestSaleCount.toString());
    $("#spnGrandTotalFinalSaleCount").html(grandTotalFinalSaleCount.toString());
    $("#spnGrandTotalSuggestCommission").html(grandTotalSuggestCommission.toFixed(2));
}


function Date2MMDDYYYY(s) {
    var sRet = s.replace(/-/g, '/').substring(0, 10);
    if (sRet.substring(4, 5) == "/" && sRet.substring(7, 8) == "/") {
        sRet = s.substring(5, 7) + "/" + s.substring(8, 10) + "/" + s.substring(0, 4);
    }
    return sRet;
}     