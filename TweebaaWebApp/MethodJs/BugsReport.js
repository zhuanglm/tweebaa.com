
$.ajaxSetup({ cache: false });

//var picCollagePath = "http://www.tweebaa.com/images801/CollageImg";
    $(document).ready(function () {
        loadBugsCount();
    
    }
);

var state = "";
var page = 1;
var recordCount = 0;
var pageCount = 0;

function DoSearch() {
    $("#kkpager").html();
    loadBugsCount();
}

//获取总记录数、页数
function loadBugsCount() {
    var sKeyword = $("#txtKeywords").val();

    $.ajax({
        type: "Post",
        url: "/Events/BugsReport/BugsHandler.ashx",
        data: "{'action':'querycount','sKeyword':'" + sKeyword
            + "'}",
        success: function (resu) {
            if (resu == "") {
                return;
            }
            var arry = new Array();
            arry = resu.split(",");
            recordCount = arry[0];
            pageCount = arry[1];
            //LoadBugs();
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
                isShowFirstPageBtn: true,
                total: pageCount, //总页码
                //总数据条数
                totalRecords: recordCount,
                mode: 'click', //默认值是link，可选link或者click
                click: function (n) {
                    page = n;
                    LoadBugs();
                    //LoadPrd();
                    this.selectPage(n); //手动选中按钮
                    return false;
                }
            });
            kkpager.click(1);

        },
        error: function (obj) {
            // alert("Load failed");
        }
    });
}

//查询我的收藏
var prdSaleInfo = "";
function LoadBugs() {
    var sKeyword = $("#txtKeywords").val();
    $("#tabCollection").empty();
    //$(".collection-list.tr").empty();   
    var head = '<tr><td  width="200">Type</td><td >Username</td><td  width="400">Title</td><td >Publish Time</td><td >Status</td> </tr>';
    $("#tabCollection").append(head);

    $.ajax({
        type: "POST",
        url: "/Events/BugsReport/BugsHandler.ashx",
        data: "{'action':'querydata','sKeyword':'" + sKeyword
        + "','page':'" + page + "'}",
        success: function (resu) {
            if (resu == "") {
                return;
            }
            var obj = eval("(" + resu + ")");
            for (var i = 0; i < obj.length; i++) {
                var bugs = obj[i];
                var bugstype;
                if (bugs.BugsType == 1) bugstype = "UI";
                if (bugs.BugsType == 2) bugstype = "Function";
                if (bugs.BugsType == 3) bugstype = "Suggestion";
                if (bugs.BugsType == 4) bugstype = "User Experience";

                var status = "open";
                if (bugs.status == 0) status = "open";
                if (bugs.status == 1) status = "Not a bug";
                if (bugs.status == 2) status = "dulplicate";
                if (bugs.status == 3) status = "fixed";
                if (bugs.status == 4) status = "Closed";
                if (bugs.status == 5) status = "in processing";
                html = '<tr><td>';
                html += bugstype + "</td><td>";
                html += bugs.username + "</td><td>";
                html += "<a href='BugsDetails.aspx?id=" + bugs.BugsReport_ID + "'>" + bugs.BugsTitle + "</a></td><td>";
                html += bugs.CreateTime + "</td><td>";
                html += status + "</td></tr>";
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

function PostABug(txtBrowser, bugsType, txtLevel, txtTitle, txtDescription, txtUserGuid) {
    var endTime = "";
    $.ajax({
        type: "POST",
        url: '/Events/BugsReport/BugsHandler.ashx',
        data: "{'action':'post_bug'"
        + ",'txtBrowser':'" + txtBrowser
        + "','bugsType':'" + bugsType
        + "','txtLevel':'" + txtLevel
        + "','txtTitle':'" + txtTitle
        + "','txtUserGuid':'" + txtUserGuid
        + "','txtDescription':'" + txtDescription
         + "'}",
        success: function (resu) {
            prdSaleInfo = resu;
            if (resu == "1") {
                alert("Your post saved, Thanks for submit,");
                window.location.href = "index.aspx";
            }
            //return resu;
        },
        error: function (obj) {
            prdSaleInfo = "";
        }
    });
}


