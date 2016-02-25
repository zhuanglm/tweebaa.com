var pics1 = "";
var pics2 = "";
var pics3 = ""; ;
var i = 0;
var id = "";
function uplod() {
    $("#iframeUpload").contents().find("#upload1").click();
}
function send(value) {
    var picjson = {
        'pics': value
    };
    XD.sendMessage(parent, picjson); //区别在这里，第一个参数
}
//删除图片(索引)
function send2(value) {
    var picjson = {
        'deleid': value
    };
    XD.sendMessage(parent, picjson);
}
//移动图片(现在索引+","+新索引)
function send3(value) {
    var picjson = {
        'moveid': value
    };
    XD.sendMessage(parent, picjson);
}

var callback = function (data) {
    var resu = jsonToStr(data)
    if (resu.indexOf("UploadImg") > 0) {
        i += 1;
        var id = "img" + i;
        document.getElementById(id).setAttribute("src", data.pics.replace("big", "small"));
        //$E('hid1').value = jsonToStr(data);
    }
    else {
        document.getElementById("pro-web").value = data.pics;
    }

}
$(document).ready(function () {
    XD.receiveMessage(callback);

})
XD.receiveMessage(callback);
addEvent($E('trigger'), 'click', send);

function getImg(imgValue) {
    if (imgValue.indexOf('resInt') > 0) {
        var obj = eval("(" + imgValue + ")"); //转换为json对象
        var resInt = obj.resInt;
        var message = obj.message; //原图路径(大)
        var message2 = obj.message2; //中
        var message3 = obj.message3; //小
        if (resInt != "1") {
            alert(message);
        }
        else {
            for (var i = 1; i < 6; i++) {
                var imgId = "#img" + i;
                if ($(imgId).attr("src") == "" || $(imgId).attr("src") == null) {
                    $(imgId).attr("src", message3);                 
                    send(message);
                    $("#iframeUpload").attr("src", "fileControlEn.aspx");
                    return;
                }
            }
        }
        $("#iframeUpload").attr("src", "fileControlEn.aspx");
    }
}

function uplod2() {
    $("#iframeVideo").contents().find("#upload1").click();
}
function getVideo(videoValue) {
    if (videoValue.indexOf('resInt') > 0) {
        var obj = eval("(" + videoValue + ")"); //转换为json对象
        var resInt = obj.resInt;
        var playFile = obj.playFile; //播放路径
        var imgFile = obj.imgFile; //图片路径    
        var message = obj.message; //错误消息
        if (resInt != "1") {
            alert(message);
        }
        else {
            $("#pro-web").val(playFile);
            $("#hidVideo").val(playFile);
            send(playFile);
            $("#iframeVideo").attr("src", "videoControlEn.aspx");
            return;
        }
        $("#iframeVideo").attr("src", "videoControlEn.aspx");
    }
}


function getdata() {

    alert($("#hid1").val());

}
