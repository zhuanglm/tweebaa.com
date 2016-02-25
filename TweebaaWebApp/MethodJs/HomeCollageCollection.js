﻿
$.ajaxSetup({ cache: false });

var picPath = "https://tweebaa.com/CollageImg";
$(document).ready(function () {
    loadCount();
    LoadPrd();
}
);

var state = "";
var page = 1;
var recordCount = 0;
var pageCount = 0;
var begTime = $("#txtBegTime").val();
var endTime = $("#txtEndTime").val();

//获取总记录数、页数
function loadCount() {
    $.ajax({
        type: "Post",
        url: "../AjaxPages/FavoriteAjax.aspx",
        data: "{'action':'queryhomecount_collage','state':'" + state + "','begTime':'" + begTime + "','endTime':'" + endTime + "'}",
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
                    loadCount();
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

//查询我的收藏
var prdSaleInfo = "";
function LoadPrd() {
    $(".collection-list").empty();
    //$(".collection-list.tr").empty();   
    var head = '<tr><th class="pro-name">Selected Design</th><th class="operation">Action</th> </tr>';
    $(".collection-list").append(head);

    $.ajax({
        type: "POST",
        url: '../AjaxPages/FavoriteAjax.aspx',
        data: "{'action':'query_collage','begTime':'" + begTime + "','endTime':'" + endTime + "','state':'" + state + "','page':'" + page + "'}",
        success: function (resu) {
            if (resu == "") {
                return;
            }
            var obj = eval("(" + resu + ")");
            for (var i = 0; i < obj.length; i++) {
                var prd = obj[i];
                var prdid = "'" + prd.CollageDesign_ID + "'";
                var guid = "'" + prd.guid + "'";
                var prdname = "'" + prd.CollageDesing_Title + "'";
                var prdimg = "'" + picPath + prd.CollageDesign_ThumbnailFileName + "'";
                var time = prd.edttime.replace(/-/g, '/').substring(0, 10);
                var stat = prd.wnstat;
                var reviewCount = prd.reviewCount;
                var summoney = prd.summoney;
                var presaleendtime = prd.presaleendtime;
                if (reviewCount == null) {
                    reviewCount = 0;
                }
                if (summoney == null) {
                    summoney = 0;
                }

                // convert summoney to ##.00 format
                summoney = summoney.toFixed(2);

                if (presaleendtime == null) {
                    presaleendtime = "";
                }

                //var estimatePrice = prd.estimateprice.toFixed(2);
                //if (estimatePrice == null) { estimatePrice = 0; }

                /// 【屏蔽:-1】【草稿:0】【评审中(大众):1】【预售:2】【销售:3】【评审中(推易吧):4】【评审失败(推易吧):5】
                var tdPriceHtml = "";
                var tdStatHtml = "";
                var prdUrl = "";
                var urlPage = "''";

                // Public Evaluating progress bar
                var maxReviewCount = 300;
                var reviewProgress = (reviewCount / maxReviewCount) * 100;
                if (reviewProgress < 1) reviewProgress = 1;

                // set sale count
                //alert(prd.saleCount + " " + prd.presaleforward);
                var saleCount = 0;
                if (prd.saleCount != null) saleCount = prd.saleCount;

                // set preview sale forward count
                var preSaleForward = 0;
                if (prd.presaleforward != null) preSaleForward = prd.presaleforward;

                // test sale progress
                var testSaleProgress = 0;
                if (preSaleForward == 0) {
                    testSaleProgress = 0;
                }
                else {
                    testSaleProgress = (saleCount / preSaleForward) * 100;
                    if (testSaleProgress < 1) testSaleProgress = 1; // minimum 1%
                }
                //alert(saleCount + " " + preSaleForward + " " + testSaleProgress);
                /*
                if (stat == "1") {
                    stat = "Public Evaluating";
                    tdStatHtml = '<div class="state-ing">' + stat + '</div><div class="jdt"><span style="width: ' + reviewProgress + '%;"></span></div><div class="participant">Participants: ' + reviewCount + '</div>';
                    prdUrl = "../Product/submitReview.aspx?id=" + prd.prtguid;
                    urlPage = "'submitReview.aspx'";
                }
                else if (stat == "2") {
                    stat = "Test Sale";
                    var leftDays = "";
                    if (prd.presaleendday <= 0) "Time Over";
                    else if (prd.presaleendday == 1) leftDays = prd.presaleendday + " Day Left";
                    else leftDays = prd.presaleendday + " Days Left";

                    var testSaleInfo = "Sold: " + saleCount + "  Target: " + preSaleForward;
                    var shoppingCartUrl = "../Product/presaleBuy.aspx?id=" + prd.prtguid;

                    //tdStatHtml = '<div class="state-ing">' + stat + '</div><div class="jdt"><span style="width: 50%;"></span></div><div class="participant">已支持金额：' + summoney + ' <br />剩余时间：' + presaleendtime + '</div>';
                    //tdStatHtml = '<div class="state-ing">' + stat + '</div><div class="jdt"><span style="width: ' + testSaleProgress + '%;"></span></div><div class="participant">Total amount: ' + summoney + ' <br />Remain time: ' + presaleendtime + '</div>';
                    tdStatHtml = '<div class="state-ing">' + stat + '</div><div class="state-ing">' + leftDays + '</div><div class="jdt"><span style="width: ' + testSaleProgress + '%;"></span></div><div class="participant">' + testSaleInfo + '</div>';
                    //tdPriceHtml = '<span class="pre-sale-price">$<strong>' + estimatePrice + '</strong></span><a href="' + shoppingCartUrl + '" target="_top" class="add-car" ></a>';
                    prdUrl = "../Product/CollageReview.aspx?id=" + prd.prtguid;
                    urlPage = "'submitReview.aspx'";
                }
                else if (stat == "3") {
                    stat = "Final Sale";
                    tdStatHtml = '<div class="state-ing">' + stat + '</div>';
                    tdPriceHtml = '<span class="sale-price">$<strong>' + estimatePrice + '</strong></span><a href="#" class="add-car"></a>';
                    prdUrl = "../Product/saleBuy.aspx?id=" + prd.prtguid;
                    urlPage = "'saleBuy.aspx'";
                }
                else if (stat == "4") {
                    stat = "Tweebaa Evaluating";
                    tdStatHtml = '<div class="state-ing">' + stat + '</div>';
                    prdUrl = "../Product/submitReview.aspx?id=" + prd.prtguid;
                    urlPage = "'submitReview.aspx'";
                }
                else if (stat == "5") {
                    stat = "Failure of the project";
                    tdStatHtml = '<div class="state-ing">' + stat + '</div>';
                }
                //产品信息 
                 */
                var prdDesc = "'" + escape(prd.CollageDesign_Inspiration) + "'";

                html = '<tr><td><a href="' + prdUrl + '" target="_blank" class="imglink fl"><img src="' + picPath + prd.fileurl + '" alt="" /></a><div class="pro-title fl" style="margin-left:20px;"><a href="' + prdUrl + '" target="_blank">' + prd.CollageDesing_Title + '</a><p>	Favorite time： <br/>' + prd.edttime.replace("T", " ").substring(0, 16) + '</p>	</div></td><td><div class="btn-group"><a  href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" class="share">Share</a><a href="javascript:void(0)" onclick=" DeletePrd(' + guid + ')">Delete</a></div></td></tr>';

                $(".collection-list").append(html);
            }
        },
        error: function (obj) {
            //alert("Load failed");
        }
    });
}

//通过prdGuid查询预售信息：已预售数量、金额、预售结束时间
function GerPreSaleInfo(prdGuid) {
    var endTime = "";
    $.ajax({
        type: "POST",
        url: '../AjaxPages/FavoriteAjax.aspx',
        data: "{'action':'querysale','id':'" + prdGuid + "'}",
        success: function (resu) {
            prdSaleInfo = resu;
            //return resu;
        },
        error: function (obj) {
            prdSaleInfo = "";
        }
    });
}


//删除我的收藏
function DeletePrd(prdid) {
    if (!confirm("Sure to delete?")) {
        return;
    }
    if (prdid != null && prdid != "") {
        $.ajax({
            type: "POST",
            url: '../AjaxPages/FavoriteAjax.aspx',
            data: "{'action':'delete','id':'" + prdid + "'}",
            success: function (resu) {
                if (resu == "1") {
                    alert("Delete successful!");
                    LoadPrd();
                    page = 1;
                }
                else {
                    alert("Delete failed!");
                }

            },
            error: function (obj) {
                alert("Delete failed!");
            }
        });
    }
}

//分享动作
function SharePrd(id, name, img, page, desc) {

    if (SetShareLink(id, name, img, page, desc, 0.0) == true) {
        $("#share-tck2").parents(".greybox").show();
        $("#share-tck2").animate({ top: "2%" }, 300);
    }

    /*
    $("#share1").bind("click", function () {
    dofristshare_prdSaleAll("sina", id, name, img, page);
    });
    $("#share2").bind("click", function () {
    dofristshare_prdSaleAll("tx", id, name, img, page);
    });
    $("#share3").bind("click", function () {
    dofristshare_prdSaleAll("rr", id, name, img, page);
    });
    $("#share4").bind("click", function () {
    dofristshare_prdSaleAll("qzone", id, name, img, page);
    });
    $("#share5").bind("click", function () {
    dofristshare_prdSaleAll("douban", id, name, img, page);
    });
    */
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