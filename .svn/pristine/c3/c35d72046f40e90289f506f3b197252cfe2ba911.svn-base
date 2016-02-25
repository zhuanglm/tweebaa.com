
$.ajaxSetup({ cache: false });

//var picCollagePath = "http://www.tweebaa.com/images801/CollageImg";

var state = "";
var page = 1;
var recordCount = 0;
var pageCount = 0;


//获取总记录数、页数
function loadBugsCount() {
    var sKeyword ="";

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
    var head = '<tr><td>Type</td><td>Username</td><td>Title</td><td>Publish Time</td><td>Status</td><td>Action</td></tr>';
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
                var bugsID = bugs.BugsReport_ID;
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

                html = '<tr><td width="100">';
                html += bugstype + "</td><td>";
                html += bugs.username + "</td><td>";
                html += bugs.BugsTitle + "</td><td>";
                html += bugs.CreateTime + "</td><td>";
                html += status + "</td><td>";
                html += "Points:<input type='text' id='points_" + i + "' />&nbsp;";
                html += '<a href="javascript:void(0)" onclick="give_points(' + i + ')">Give Points</a> &nbsp;&nbsp;&nbsp;';
                html += '<a href="javascript:void(0)" onclick="not_a_bugs(' + bugsID + ',0)">Not A Bug</a>&nbsp;&nbsp;&nbsp;';
                html += '<a href="javascript:void(0)" onclick="Dulplicate(' + bugsID + ',0)">Dulplicate</a>';
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


function fixed(bug_id,jump) {
    $.ajax({
        type: "POST",
        url: '/Events/BugsReport/BugsHandler.ashx',
        data: "{'action':'fixed'"
                + ",'txtID':'" + bug_id
                 + "'}",
        success: function (resu) {
            //prdSaleInfo = resu;
            if (resu == "") {
                return;
            }
            if(jump==1)
                window.location.href = "index.aspx";
        },
        error: function (obj) {
            prdSaleInfo = "";
        }
    });
}
function Closed(bug_id, jump) {
    $.ajax({
        type: "POST",
        url: '/Events/BugsReport/BugsHandler.ashx',
        data: "{'action':'Closed'"
                + ",'txtID':'" + bug_id
                 + "'}",
        success: function (resu) {
            //prdSaleInfo = resu;
            if (resu == "") {
                return;
            }
            if (jump == 1)
                window.location.href = "index.aspx";
        },
        error: function (obj) {
            prdSaleInfo = "";
        }
    });
}
function Dulplicate(bug_id, jump) {
    $.ajax({
        type: "POST",
        url: '/Events/BugsReport/BugsHandler.ashx',
        data: "{'action':'Dulplicate'"
                + ",'txtID':'" + bug_id
                 + "'}",
        success: function (resu) {
            //prdSaleInfo = resu;
            if (resu == "") {
                return;
            }
            if (jump == 1)
                window.location.href = "index.aspx";
        },
        error: function (obj) {
            prdSaleInfo = "";
        }
    });
}
function not_a_bugs(bug_id, jump) {
    $.ajax({
        type: "POST",
        url: '/Events/BugsReport/BugsHandler.ashx',
        data: "{'action':'not_a_bugs'"
                + ",'txtID':'" + bug_id
                 + "'}",
        success: function (resu) {
            //prdSaleInfo = resu;
            if (resu == "") {
                return;
            }
            if (jump == 1)
                window.location.href = "index.aspx";
        },
        error: function (obj) {
            prdSaleInfo = "";
        }
    });
}

function give_points(bug_id, txt_id, jump) {
    var sPoint = $("#points_" + txt_id).val();
    var sUserID = $("#Admin_userID").val();
    $.ajax({
        type: "POST",
        url: '/Events/BugsReport/BugsHandler.ashx',
        data: "{'action':'give_points'"
                + ",'txtID':'" + bug_id
                + "','txtPoint':'" + sPoint
                + "','txtUserID':'" + sUserID
                 + "'}",
        success: function (resu) {
            //prdSaleInfo = resu;
            if (resu == "") {
                return;
            }
            /*
            if (jump == 1)
            window.location.href = "index.aspx";
            */
            alert("give points ok");
        },
        error: function (obj) {
            prdSaleInfo = "";
        }
    });

}