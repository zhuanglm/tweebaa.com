
$.ajaxSetup({ cache: false });

//var picCollagePath = "http://www.tweebaa.com/images801/CollageImg";
$(document).ready(function () {
   // loadTopRankCount();
    LoadBugs();
}
);

var state = "";
var page = 1;
var recordCount = 0;
var pageCount = 0;


//获取总记录数、页数
function loadTopRankCount() {
    var sKeyword = "";

    $.ajax({
        type: "Post",
        url: "/Events/BugsReport/BugsHandler.ashx",
        data: "{'action':'query_rank_count','sKeyword':'" + sKeyword
            + "'}",
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
function LoadBugs() {
    var sKeyword = "";
    $("#tabCollection").empty();
    //$(".collection-list.tr").empty();   
    var head = '<tr><td>#</td><td >Username</td><td>Total Bugs Find</td><td >Total Points Earn</td></tr>';
    $("#tabCollection").append(head);

    $.ajax({
        type: "POST",
        url: "/Events/BugsReport/BugsHandler.ashx",
        data: "{'action':'query_rank_data','sKeyword':'" + sKeyword
        + "','page':'" + page + "'}",
        success: function (resu) {
            if (resu == "") {
                return;
            }
            var obj = eval("(" + resu + ")");
            for (var i = 0; i < obj.length; i++) {
                var bugs = obj[i];

                html = '<tr><td>';
                html += (i+1)+ "</td><td>";
                html += bugs.username + "</td><td>";
                html += bugs.total_num + "</td><td>";
                html += bugs.total_points + "</td></tr>";

                $("#tabCollection").append(html);
            }
        },
        error: function (obj) {
            //alert("Load failed");
        }
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


