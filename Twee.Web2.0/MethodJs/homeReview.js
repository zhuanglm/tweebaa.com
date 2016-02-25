
$.ajaxSetup({ cache: false });
var picPath = "https://tweebaa.com/";

$(document).ready(
    function () {
        DoSearch();
    }
);

var state = "";
var page = 1;
var recordCount = 0;
var pageCount = 0;
var begTime = $("#txtBeginTime").val();
var endTime = $("#txtEndTime").val();

function DoProductStatusChange() {
    state = $("#optProductStatus option:checked").val();
    DoSearch();
}

function DoSearch() {
    begTime = $("#txtBeginTime").val();
    endTime = $("#txtEndTime").val();

    $("#divNoData").hide();
    LoadGrandTotal();
    LoadCount();
    LoadPrd();
}

//获取总记录数、页数
function LoadCount() {
    $.ajax({
        type: "Post",
        url: "/AjaxPages/homeAjax.aspx",
        data: "{'action':'queryReviewcount','state':'" + state + "','begTime':'" + begTime + "','endTime':'" + endTime + "'}",
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
                    LoadPrd();
                    this.selectPage(n);  
                    return false;
                }
            });
        },
        error: function (obj) {
             
        }
    });
}

function LoadPrd() {
    $("#tbData").empty();
    $.ajax({
        type: "POST",
        url: '/AjaxPages/homeAjax.aspx',
        data: "{'action':'review','state':'" + state + "','page':'" + page + "','begTime':'" + begTime + "','endTime':'" + endTime + "'}",
        async: false,
        success: function (resu) {
            if (resu == "" || resu == "[]") {
                $("#kkpager").empty();
                $("#divNoData").show();
                return;
            }
            var obj = eval("(" + resu + ")");
            for (var i = 0; i < obj.length; i++) {
                var prd = obj[i];
                var stateTxt = "";
                var state = prd.wnstat;
                var price = prd.estimateprice.toFixed(2);
                var prdDesc = "'" + escape(prd.txtjj) + "'";
                var urlPage = "'presaleBuy.aspx'";

                var prdUrl = "../Product/submitReview.aspx?id=" + prd.prtguid;
                if (state == 0) { // cannot be 0 state
                    // for evaluate produts cannot come here
                    stateTxt = "Draft";
                    prdUrl = "../Product/prdReview.aspx?id=" + prd.prtguid;
                }
                if (state == 1) {
                    stateTxt = "Public Evaluating";
                    prdUrl = "../Product/submitReview.aspx?id=" + prd.prtguid;
                }
                if (state == 4) {
                    stateTxt = "Tweebaa Evaluating";
                    prdUrl = "../Product/submitReview.aspx?id=" + prd.prtguid;
                }
                if (state == 2) {
                    stateTxt = "Test-Sale";
                    prdUrl = "../Product/presaleBuy.aspx?id=" + prd.prtguid;
                }
                if (state == 3) {
                    stateTxt = "Buy Now";
                    urlPage = "'saleBuy.aspx'";
                    prdUrl = "../Product/saleBuy.aspx?id=" + prd.prtguid;
                    if (prd.MinFinalSalePrice != null)
                        price = prd.MinFinalSalePrice.toFixed(2);
                }
                if (state == 7) {
                    stateTxt = "Test-Sale Failed";
                    prdUrl = "../Product/presaleBuy.aspx?id=" + prd.prtguid;
                }
                var prdid = "'" + prd.prtguid + "'";
                var prdname = "'" + escape(prd.name) + "'";
                var prdimg = "'" + prd.fileurl + "'";
                var condent = prd.cmdtxt;
                //var time = prd.edttime.replace(/-/g, '/').substring(0, 10);
                var time = Date2MMDDYYYY(prd.edttime);

                var progress = 1;
                if (prd.reviewCount != null) progress = parseInt((prd.reviewCount / 300) * 100);
                if (progress < 1) progress = 1;

                var reviewCount = 0;
                if (prd.reviewCount != null) reviewCount = prd.reviewCount;

                //产品信息 
                var html = "";
                html += '<tr>';
                html += '<td style="width: 20%" class="hidden-sm"> <div><a href="' + prdUrl + '"><img src="' + picPath + prd.fileurl + '" alt="" width="100"></a></div></td>';  //SharePrd(id, name, img, page, desc)
                html += '<td style="width: 30%"><h5><a href="' + prdUrl + '">' + prd.name + '</a></h5> <h6> $' + price + '</h6> <h5> <small>Evaluate Date : ' + time + '</small></h5></td>';
                html += '<td style="width: 25%; vertical-align: middle; padding: 0 20px;"><h3 class="heading-xs"> ' + stateTxt + '</h3><div class="progress progress-u progress-xs"><div class="progress-bar progress-bar-blue" role="progressbar" aria-valuenow="76" aria-valuemin="0" aria-valuemax="100" style="width: ' + progress + '%"> </div></div><h3 class="heading-xs"> Evaluators: ' + reviewCount.toString() + '/300</h3></td>';
                html += '<td style="width: 20%; vertical-align: middle"><button class="btn rounded btn-default btn_mg" type="button" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + price + ')"><i class="fa fa-share-alt"></i></button></td>';
                html += '</tr>';

                //html = '<tr><td><a href="' + prdUrl + '" target="_blank" class="imglink fl"><img src="' + picPath + prd.fileurl + '" alt="" /></a><div class="pro-title fl" style="margin-left:20px;"><a href="' + prdUrl + '" target="_blank" >' + prd.name + '</a><p>Time：' + time + '</p></div></td> <td><div class="state-ing">' + stateTxt + '</div></td><td>' + condent + '</td><td><div class="btn-group" style=" display:none;"><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ')" class="share">Share</a></div></td></tr>';

                $("#tbData").append(html);
            }
        },
        error: function (obj) {
            //alert("Load failed");
        }
    });


}

//删除我的发布（评审中）
function DeletePrd(prdid) {
    if (!confirm("Sure to delete?")) {
        return;
    }
    if (prdid != null && prdid != "") {
        $.ajax({
            type: "POST",
            url: '/AjaxPages/homeAjax.aspx',
            data: "{'action':'delete','id':'" + prdid + "'}",
            success: function (resu) {
                if (resu == "True") {
                    alert("Delete successful!");
                }
                else {
                    alert("Delete failed!");
                }
                DoSearch()();
            },
            error: function (obj) {
                alert("Delete failed!");
            }
        });
    }
}

//分享动作
function SharePrd(id, name, img, page, desc) {
    name = unescape(name);
    if (SetShareLink(id, name, img, page, desc, 0.0) == true) {
        $("#share-tck2").parents(".greybox").show();
        $("#share-tck2").animate({ top: "2%" }, 300);
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

//get ground total of successful rate and earn gifts
function LoadGrandTotal() {
    var grandSuccessRate = 0;
    var grandEarnGiftCount = 0;
    $.ajax({
        type: "Post",
        url: "/AjaxPages/homeAjax.aspx",
        data: "{'action':'queryevaluategrandtotal'}",
        async: false,
        success: function (resu) {

            //          alert(resu);

            if (resu == "") {
                return;
            }

            var arry = new Array();
            arry = resu.split(",");
            grandSuccessRate = arry[0];
            grandEarnGiftCount = arry[1];
        },
        error: function (obj) {
            // alert("Load failed");
        }
    });
    $("#spnGrandSuccessRate").html(grandSuccessRate.toString());
    $("#spnGrandEarnGift").html(grandEarnGiftCount.toString());
}


function Date2MMDDYYYY(s) {
    var sRet = s.replace(/-/g, '/').substring(0, 10);
    if (sRet.substring(4, 5) == "/" && sRet.substring(7, 8) == "/") {
        sRet = s.substring(5, 7) + "/" + s.substring(8, 10) + "/" + s.substring(0, 4);
    }
    return sRet;
}

