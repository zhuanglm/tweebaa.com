var prdID = "";
$(document).ready(
   function () {
       var Request = new Object();
       Request = GetRequest();
       prdID = Request["id"];
       GetVisitCount();
   }
);

var second = 0;
var minute = 0;
var hour = 0;
window.setTimeout("interval();", 1000);
function interval() {
    second++;
    if (second==30) {
        AddVisit();
    }
   /* if (second == 60) {
        second = 0; minute += 1;
    }
    if (minute == 60) {
        minute = 0; hour += 1;
    }
    $("#labTime").text(hour + "时" + minute + "分" + second + "秒"); */   
    window.setTimeout("interval();", 1000);
}

function AddVisit() {
    var _data = "{'action':'addVisit','id':'" + prdID + "'}";
    $.ajax({
        type: "POST",
        url: '../AjaxPages/UserActivity.aspx',
        dataType: "json",
        data: _data,
        success: function (resu) {          
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {          
        }
    });
};

function GetVisitCount() {
    var _data = "{'action':'getCount'}";
    $.ajax({
        type: "POST",
        url: '../AjaxPages/UserActivity.aspx',
        data: _data,
        success: function (resu) {
            if (resu != "-1") {
                $("#labView").text(resu);
            }
            else {
                $("#divS1").hide();
                $("#divS2").hide();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
    
}

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