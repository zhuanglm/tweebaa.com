﻿var picPath = "https://tweebaa.com/";

var page = 1;
var collage_recordCount = 0;
var collage_pageCount =20;
var type = "";       // share type
var begTime = "";
var endTime = "";
var totalProductShareVisitCount = 0;
var totalProductShareSoldQuantity = 0;
var totalMoney =0.00;

$(document).ready(
   function () {
       $(".datepicker").datepicker({
           nextText: ">",
           prevText: "<"
       });
       DoSearchCollageShare();
       loadGrandTotal();
       //       load_collage_design_Count(); //for collage design
       //       
       //       $('.select-list_collage').hide();
       //       //add by long for collage design 
       //       //ç«™å†…æ¶ˆæ¯
       //       $("#s_data_collage").click(function (event) {
       //           $(this).addClass('active').siblings('.select-list_collage').show();
       //       })
       //       $("#s_data_collage .select-box_collage").mouseleave(function (event) {
       //           $(this).find('.select-list_collage').hide();
       //           $("#s_data_collage").removeClass('active')
       //       });
       //       $(".select-list_collage a").click(function (event) {
       //           $("#s_data_collage").attr('s-data', $(this).attr('s-data'))
       //           $("#s_data_collage").text($(this).text())
       //           $(this).parents(".select-list_collage").hide();
       //           $("#s_data_collage").removeClass('active')
       //           return false;
       //       });
       //       //

   });



//获取总记录数、页数
function load_collage_design_Count() {
    begTime = $("#txtCollageBegin").val();
    endTime = $("#txtCollageEnd").val();
    $.ajax({
        type: "Post",
        url: "/AjaxPages/shareAjax.aspx",
        data: "{'action':'queryhomecount_collage','type':'" + type + "','begTime':'" + begTime + "','endTime':'" + endTime + "'}",
        success: function (resu) {
            if (resu == "") {
                return;
            }
            var arry = new Array();
            arry = resu.split(",");
            collage_recordCount = arry[0];
            collage_pageCount = arry[1];
            /*
            kkpager.generPageHtml({
            pagerid: 'dvCollage',
            lang: {
            firstPageText: 'First',
            firstPageTipText: 'First',
            lastPageText: 'Last',
            lastPageTipText: 'Last',
            prePageText: 'Prev',
            prePageTipText: 'Prev',
            nextPageText: 'Next',
            nextPageTipText: 'Next'
            }
            ,
            pno: 1,
            total: collage_pageCount, //总页码
            //总数据条数
            totalRecords: collage_recordCount,
            mode: 'click', //默认值是link，可选link或者click
            click: function (n) {
            page_collage = n;
            loadCollageMeinv();
            this.selectPage(n); //手动选中按钮
            return false;
            }
            });
            */

            var iPerPage = collage_recordCount % collage_pageCount;
            if (iPerPage == 0) {
                iPerPage = collage_recordCount / collage_pageCount;
            } else {
                iPerPage = ceil(collage_recordCount / collage_pageCount);
            }
            kkpager.generPageHtml({
                pno: 1,
                total: collage_pageCount, //总页码
                totalRecords: collage_recordCount,     //总数据条数
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
                    loadCollageMeinv();
                    this.selectPage(n); //手动选中按钮
                    return false;
                }
            });
            // loadCollageMeinv(1);

        },
        error: function (obj) {
            // alert("Load failed");
        }
    });
}

function DoSearchCollageShare() {
 totalProductShareVisitCount = 0;
 totalProductShareSoldQuantity = 0;
 totalMoney =0.00;
    $("#divNoData").hide();
    $("#kkpager").empty();

    begTime = $("#txtBeginTime").val();
    endTime = $("#txtEndTime").val();

    page = 1;

    //loadGrandTotal();
    load_collage_design_Count();
    loadCollageMeinv();

    // pno does not work, have to select page 1 here
    if (collage_recordCount > 0) kkpager.selectPage(page);

}


function loadCollageMeinv(page_collage) {
    $("#tblCollageDesignList").empty();
    // $("#tableShare").append('<tr> <th width="80"> Date</th><th width="118">Product Name </th><th width="100">Promote Via </th> <th width="180">Website Link</th><th width="135">Income Amount($)</th><th> From</th></tr>');
    //$("#tableShare").append('<tr> <th width="430">Product Name </th><th width="100">Website Link</th> <th width="180">Promote Via </th><th> Visits</th><th> Buyers</th><th width="60">Income($)</th></tr>');         
    //$("#tableShare").append('<tr><th>Date</th><th>Product Name</th><th>Promote Via</th><th>Website Link</th><th>Income Amount（$</th><th>From</th></tr>
    $("#tblCollageDesignList").append('<tr><th>Date</th><th>Design Name</th><th>Promote Via </th><th> Visits</th><th> Buyers</th><th>Income Amount($)</th><th> Copy Share Link</th></tr>');
    begTime = $("#txtBeginTime").val();
    endTime = $("#txtEndTime").val();

    var order = "";
    $.ajax({
        type: "Post",
        url: "/AjaxPages/shareAjax.aspx",
        data: "{'action':'query_collage','type':'" + type
                    + "','beginTime':'" + begTime
                    + "','endTime':'" + endTime
                    + "','order':'" + order
                    + "','page':'" + page_collage
                    + "'}",
        success: function (resu) {
            if (resu == "") {
                return;
            }

            var obj = eval("(" + resu + ")");
            for (var i = 0; i < obj.length; i++) {
                var prd = obj[i];
                var prdid = "'" + prd.prdguid + "'";
                var mymoney = prd.prdsumMoney;
                if (mymoney == null) {
                    mymoney = 0;
                }else{
                    mymoney=parseFloat(mymoney).toFixed(2);
                }
                var time = prd.addtime.replace(/-/g, '/').substring(0, 10);
                var state = prd.wnstat;
                var prdUrl = "../Product/submitReview.aspx?id=" + prd.prdguid;
                var copyText = "'" + prd.shareurl + "'";
                if (state == 0) {
                    prdUrl = "../Product/prdReview.aspx?id=" + prd.prdguid;
                }
                if (state == 2) {
                    prdUrl = "../Product/presaleBuy.aspx?id=" + prd.prdguid;
                }
                if (state == 3) {
                    prdUrl = "../Product/saleBuy.aspx?id=" + prd.prdguid;
                }

                //var html = '<tr><td><span class="text">' + time + '</span></td><td><span class="text"><a href="">' + prd.name + '</a></span></td><td><span class="icon"><a href=""><img src="../Images/ico_15.png" alt=""></a></span></td><td><span class="text"><a href="">' + prd.shareurl + '</a></span></td><td><span class="text">＋' + mymoney + '</span></td><td><span class="text">Earnings</span></td></tr>';
                //var html = '<tr><td><span class="text">' + time + '</span></td><td><span class="text"><a href="">' + prd.name + '</a></span></td><td><span class="icon">'+prd.sharetype+'</span></td><td><span class="text"><a href="">' + prd.shareurl + '</a></span></td><td><span class="text">＋' + mymoney + '</span></td><td><span class="text">Earnings</span></td></tr>';
                //var html = '<tr><td><a href="' + prd.shareurl + '" target="_blank" class="imglink fl"><img src="' + picPath + prd.fileurl.replace("big", "small") + '" alt="' + prd.name + '" /></a><div class="pro-title fl" style="width:120px; margin-left:20px;"><a href="' + prd.shareurl + '" target="_blank">' + prd.name + '</a><p>Submitted on：<br/>' + time + '</p></div></td><td><span class="text"><a href="' + prd.shareurl + '" target="_blank">' + prd.shareurl.substring(0, 35) + "..." + '</a></span></td><td><span class="icon">' + prd.sharetype + '</span></td><td><span class="text">' + prd.visitcount + '</span></td><td><span class="text">' + prd.successcount + '</span></td><td><span class="text">＋' + mymoney + '</span></td></tr>';
                // var html = '<tr><td><a href="' + prdUrl + '" target="_blank" class="imglink fl"><img src="' + picPath + prd.fileurl.replace("big", "small") + '" alt="' + prd.name + '" /></a><div class="pro-title fl" style="width:120px; margin-left:20px;"><a href="' + prdUrl + '" target="_blank">' + prd.name + '</a><p>Submitted on：<br/>' + time + '</p></div></td><td><span class="text"><a href="' + prd.shareurl + '" target="_blank">' + prd.shareurl.substring(0, 35) + "..." + '</a></span></td><td><span class="icon">' + prd.sharetype + '</span></td><td><span class="text">' + prd.visitcount + '</span></td><td><span class="text">' + prd.successcount + '</span></td><td><span class="text">＋' + mymoney + '</span></td></tr>';
                //html = '<tr><td><a href="' + prdUrl + '"  target="_blank" class="imglink fl"><img src="' + picPath + prd.fileurl + '" alt="' + prdname + '" /></a><div class="pro-title fl" style="width:120px; margin-left:20px;"><a href="' + prdUrl + '" target="_blank">' + prd.name + '</a><p>Submitted on：<br/>' + time + '</p></div></td><td style="width:200px;"><div class="state-ing">' + stateTxt + '</div><div class="jdt"><span style="width: 50%;"></span></div><div class="participant">	supporters : 0/' + reviewCount + '</div></td><td><div class="btn-group"><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ')" class="share">Share</a><a href="../Product/issue.aspx?action=edit&id=' + prd.prdguid + '" target="_blank" >Edit</a><a href="javascript:void(0)" onclick=" DeletePrd(' + prdid + ')" >Delete</a></div></td></tr>';
                 
                var html = "";
                html += '<tr><td>' + time + '</td>'
                        + '<td style="width:30%;">' + prd.CollageDesing_Title + '</td>'
                        + '<td>' + prd.sharetype + '</td>'
                        + '<td>' + prd.visitcount + '</td>'
                        + '<td>' + prd.successcount + '</td>'
                        + '<td>' + mymoney + '</td>'
                        + '<td style="width:130pxc" >&nbsp;&nbsp;<input type="button"  class="submit simple"  style="color:white;border:none;width:50px;height:25px;" value="Copy" onclick="CopyToClip(' + copyText + ')" /></td></tr>';
                $("#tblCollageDesignList").append(html);
            }
            //$("#tableShare").append("</tbody>");
        },
        error: function (obj) {
            //alert("Load failed");
        }
    });
}
/////////////////////////////////////////////////////////////////////

function DoShareTypeChange() {
    type = $("#optShareType option:selected").val();
    DoSearchCollageShare();
}



//get ground total of visit counts, sold quantity and share commission
function loadGrandTotal() {
    var grandTotalShareVisitCount = 0;
    var grandTotalShareSoldQuantity = 0;
    var grandTotalShareCommission = 0.0;
    $.ajax({
        type: "Post",
        url: "/AjaxPages/shareAjax.aspx",
        data: "{'action':'queryhomeCollagetotal'}",
        async: false,
        success: function (resu) {
            if (resu == "") {
                return;
            }

            var arry = new Array();
            arry = resu.split(",");
            grandTotalShareVisitCount = arry[0];
            grandTotalShareSoldQuantity = arry[1];
            grandTotalShareCommission = parseFloat(arry[2]);
        },
        error: function (obj) {
            // alert("Load failed");
        }
    });
    $("#spnGrandTotalShareClick").html(grandTotalShareVisitCount.toString());
    $("#spnGrandTotalShareSoldQty").html(grandTotalShareSoldQuantity.toString());
    $("#spnGrandTotalShareCommission").html(grandTotalShareCommission.toFixed(2));
}


//get total count, page, visit counts and sold quantity
function loadTotal() {
    $.ajax({
        type: "Post",
        url: "/AjaxPages/shareAjax.aspx",
        data: "{'action':'queryhomecount','type':'" + type + "','begTime':'" + begTime + "','endTime':'" + endTime + "'}",
        async: false,
        success: function (resu) {
            if (resu == "") {
                return;
            }

            var arry = new Array();
            arry = resu.split(",");
            recordCount = arry[0];
            pageCount = arry[1];
            totalProductShareVisitCount = arry[2];
            totalProductShareSoldQuantity = arry[3];
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
                    loadMeinv();
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


// Copy text as text
function CopyToClip(txtCopy) {
    var input = document.createElement('textarea');
    document.body.appendChild(input);
    input.value = txtCopy;
    input.focus();
    input.select();
    document.execCommand('Copy');

    var userAgent = navigator.userAgent;
    if (userAgent.indexOf('Chrome') > 0) {
        input.remove();
    }
    else {
        input.style.display = "none";
        //.hide();
    }
    alert("Share link has been copied to the clipboard.");
}

function DoExpandShareDetail(idx, detailCount) {
    for (var i = 0; i < detailCount; i++) {

        var id = "#tr" + (i + idx).toString();
        if ($(id).css("display") == "none") $(id).show();
        else $(id).hide();
    }
    //else $(id).show();
}