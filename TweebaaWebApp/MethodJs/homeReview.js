
$.ajaxSetup({ cache: false });
var picPath = "https://tweebaa.com/";

$(document).ready(function () {
    DoSearch();
}
);

var state = "";
var page = 1;
var recordCount = 0;
var pageCount = 0;
var begTime = $("#txtBegTime").val();
var endTime = $("#txtEndTime").val();

function SetState(prdstate) {
    state = prdstate;
    
    // need to search ALL product statge again
    if (prdstate == -1) state = "";
    DoSearch();
}

function DoSearch() {
    begTime = $("#txtBegTime").val();
    endTime = $("#txtEndTime").val();

    $("#divNoData").hide();
    loadCount();
    LoadPrd();
}

//获取总记录数、页数
function loadCount() {
    $.ajax({
        type: "Post",
        url: "../AjaxPages/homeAjax.aspx",
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
    $(".collection-list").empty();
    //$(".collection-list").append('<tr><th class="pro-name">Product</th><th class="state">Status</th><th class="state">Participants</th><th class="price">My Evaluation Content</th> <th class="operation" style=" display:none;">Action</th></tr>');
    $(".collection-list").append('<tr><th class="pro-name">Product</th><th class="state">Status</th><th class="price">My Evaluation Content</th> <th class="operation" style=" display:none;">Action</th></tr>');
    $.ajax({
        type: "POST",
        url: '../AjaxPages/homeAjax.aspx',
        data: "{'action':'review','state':'" + state + "','page':'" + page + "','begTime':'" + begTime + "','endTime':'" + endTime + "'}",
        async: false,
        success: function (resu) {
            if (resu == "" || resu=="[]") {
                $("#kkpager").empty();
                $("#divNoData").show();
                return;
            }
            var obj = eval("(" + resu + ")");
            for (var i = 0; i < obj.length; i++) {
                var prd = obj[i];
                var stateTxt = "";
                var state = prd.wnstat;

                var prdUrl = "../Product/submitReview.aspx?id=" + prd.prtguid;
                if (state == 0) {
                    stateTxt = "Draft";
                    prdUrl = "../Product/prdReview.aspx?id=" + prd.prtguid;
                }
                if (state == 1) {
                    stateTxt = "Public Evaluating";
                }
                if (state == 4) {
                    stateTxt = "Tweebaa Evaluating";
                }
                if (state == 2) {
                    stateTxt = "Test-Sale";
                    prdUrl = "../Product/presaleBuy.aspx?id=" + prd.prtguid;
                }
                if (state == 3) {
                    stateTxt = "Buy Now";
                    prdUrl = "../Product/saleBuy.aspx?id=" + prd.prtguid;
                }
                if (state == 7) {
                    stateTxt = "Test-Sale Failed";
                    prdUrl = "../Product/presaleBuy.aspx?id=" + prd.prtguid;
                }
                var prdid = "'" + prd.prtguid + "'";
                var prdname = "'" + escape(prd.name) + "'";
                var prdimg = "'" + prd.fileurl + "'";
                var condent = prd.cmdtxt;
                var time = prd.edttime.replace(/-/g, '/').substring(0, 10);
                //产品信息 
                //html = '<tr><td><a href="#" class="imglink fl"><img src="' + picPath + prd.fileurl + '" alt="" /></a><div class="pro-title fl" style="width:200px; margin-left:20px;"><a href="#">' + prd.name + '</a><p>Time：' + time + '</p></div></td><td><div class="state-ing">' + stateTxt + '</div><div class="jdt"><span style="width: 50%;"></span></div><div class="participant">Evaluation number:' + prd.reviewCount + '</div></td><td>' + content + '</td><td><div class="btn-group" style=" display:none;"><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ')" class="share">Share</a></div></td></tr>';
                //html = '<tr><td><a href="' + prdUrl + '" target="_blank" class="imglink fl"><img src="' + picPath + prd.fileurl + '" alt="" /></a><div class="pro-title fl" style="margin-left:20px;"><a href="' + prdUrl + '" target="_blank" >' + prd.name + '</a><p>Time：' + time + '</p></div></td> <td><div class="state-ing">' + stateTxt + '</div></td> <td><div class="participant">' + prd.reviewCount + '</div></td><td>' + content + '</td><td><div class="btn-group" style=" display:none;"><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ')" class="share">Share</a></div></td></tr>';
                html = '<tr><td><a href="' + prdUrl + '" target="_blank" class="imglink fl"><img src="' + picPath + prd.fileurl + '" alt="" /></a><div class="pro-title fl" style="margin-left:20px;"><a href="' + prdUrl + '" target="_blank" >' + prd.name + '</a><p>Time：' + time + '</p></div></td> <td><div class="state-ing">' + stateTxt + '</div></td><td>' + condent + '</td><td><div class="btn-group" style=" display:none;"><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ')" class="share">Share</a></div></td></tr>';

                $(".collection-list").append(html);
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
            url: '../AjaxPages/homeAjax.aspx',
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
function SharePrd(id, name, img) {

    name = unescape(name);

    $("#tck4").parents(".greybox").show()
    $("#tck4").animate({ top: "2%" }, 300)

    $("#share1").bind("click", function () {
        dofristshare("sina", id, name, img);
    });
    $("#share2").bind("click", function () {
        dofristshare("tx", id, name, img);
    });
    $("#share3").bind("click", function () {
        dofristshare("rr", id, name, img);
    });
    $("#share4").bind("click", function () {
        dofristshare("qzone", id, name, img);
    });
    $("#share5").bind("click", function () {
        dofristshare("douban", id, name, img);
    });

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