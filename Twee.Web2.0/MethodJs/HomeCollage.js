
$.ajaxSetup({ cache: false });

var picPath = "https://tweebaa.com/";
$(document).ready(function () {
    loadCount();
    loadGrandTotal();
    LoadMyCollage();
}
);
var state = "";
var page = 1;
var recordCount = 0;
var pageCount = 0;
var begTime = $("#txtBeginTime").val();
var endTime = $("#txtEndTime").val();

var iTotalClick = 0;
var iTotalSold =0.0;
var iTotalCommission=0.0;


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
    $("#spanTotalClick").html("0");
    $("#spanTotalSold").html("0.00");

    //loadCount();
    loadGrandTotal();
    LoadMyCollage();
}

//获取总记录数、页数
function loadCount() {
    $.ajax({
        type: "Post",
        url: "/AjaxPages/homeAjax.aspx",
        data: "{'action':'query_my_collage_count','begTime':'" + begTime + "','endTime':'" + endTime + "'}",
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
                    LoadMyCollage();
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


function LoadMyCollage() {
    $("#tbData").empty();
    $.ajax({
        type: "POST",
        url: '/AjaxPages/homeAjax.aspx',
        data: "{'action':'LoadMyCollage','page':'" + page + "','begTime':'" + begTime + "','endTime':'" + endTime + "'}",
        async: false,
        success: function (resu) {
            if (resu == "" || resu == "[]") {
                $("#kkpager").empty();
                $("#divNoData").show();
                return;
            }
            $("#tbData").html("");
            var obj = eval("(" + resu + ")");
            //var urlPage = "'CollageReview.aspx'";
            var prdUrl = "";
            var display = 'style="display:none;"';
            var html = "";
            for (var i = 0; i < obj.length; i++) {
                var prd = obj[i];
                var prdid = "'" + prd.CollageDesign_ID + "'";
                var prdname = "'" + prd.CollageDesing_Title + "'";
                var prdimg = "'" + picPathCollage1 + prd.CollageDesign_ThumbnailFileName + "'";

                var urlPage = "'/Product/CollageReview.aspx?design_id=" + prd.CollageDesign_ID + "'";
                var prdDesc = "'" + escape(prd.CollageDesign_Inspiration) + "'";

                var imgSrc = "https://tweebaa.com/upload/UploadImg" + prd.CollageDesign_ThumbnailFileName;
                var onErrorText = 'onerror="this.src=\'http://67.224.94.82/upload/UploadImg' + prd.CollageDesign_ThumbnailFileName + '\'"';

                //产品信息 
                if (prd.TotalSold == null) prd.TotalSold = "0.00";
                var flSold = parseFloat(prd.TotalSold) ;
                iTotalClick = iTotalClick + prd.Total_Viewed;
                iTotalSold = iTotalSold + flSold;
                // if (flSold == NaN) flSold = 0.00;
                html = html + '<tr><td style="width:35%"><h5><a href="/Product/CollageReview.aspx?design_id=' + prd.CollageDesign_ID + '"><img src="' + imgSrc + '"' + onErrorText + 'alt="" width="100">';
                html = html + '</a><br/>' + prd.CollageDesing_Title + '</h5>';
                html = html + '</td>';
                html = html + '<td style="width:15%; "><h5>' + prd.Total_Viewed + ' </h5></td>';
                html = html + '<td style="width:30%; "><h5>' + flSold.toFixed(2) + ' </h5></td>';
                html = html + '<td style="width:20%; "><button class="btn rounded btn-default btn_mg" type="button" onclick="ShareCollage(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" ><i class="fa fa-share-alt"></i></button>';
                html = html + '<button class="btn rounded btn-default btn_mg" type="button" onclick="DeleteCollage(\'' + prd.CollageDesign_ID + '\')"><i class="fa  fa-trash"></i></button></td>';
                html = html + '</tr>';
                html = html + '<tr>';
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

            }
            $("#spanTotalClick").html(iTotalClick);
            $("#spanTotalSold").html(iTotalSold);
            $("#tbData").html(html);
        },
        error: function (obj) {
            // alert("Load failed");
        }
    });


}


//删除我的发布（评审中）
function DeleteCollage(prdid) {
    if (!confirm("Sure to delete?")) {
        return;
    }
    if (prdid != null && prdid != "") {
        $.ajax({
            type: "POST",
            url: '/AjaxPages/homeAjax.aspx',
            data: "{'action':'delete_collage','id':'" + prdid + "'}",
            success: function (resu) {
                if (resu == "True") {
                    AlertEx("Delete successful! ");
                }
                else {
                    AlertEx("Delete failed!");
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