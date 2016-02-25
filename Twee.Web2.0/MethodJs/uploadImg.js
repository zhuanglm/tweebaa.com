//$.ajaxSetup({ cache: false });


var i = 0;
var piclist = "";
var videoTemp = "";
var inputError = "InputError";
var ajaxError = "AjaxError";
var prdIDSave = "";  // golbal variable to keep the saved product ID to prevent keep saving new product
var isUseTemp = 0;
function send(value) {
    var picjson = {
        'pics': value
    };
    XD.sendMessage($E('frm1').contentWindow, picjson);
}

var callback = function (data) {
    if (data.pics != null) {
        var resu = jsonToStr(data)
        //alert(resu);
        //添加产品图片
        if (resu.indexOf("UploadImg") > 0) {
            i += 1;
            var id = "hidpic" + i;
            $E(id).value = resu;
            piclist += "," + data.pics;
        }
        if (piclist.substring(0, 1) == ",") {
            piclist = piclist.replace(",", "");
        }
        if (resu.toUpperCase().indexOf("PlayVideo") != -1 || resu.toUpperCase().indexOf("HTTP") != -1 || resu.toUpperCase().indexOf("WWW.") != -1 || resu.indexOf("PlayVideo") != -1) {
            $E("hidvideo").value = data.pics;
            videoTemp = data.pics;
            //alert(videoTemp);
        }

    }
    //删除产品图片
    else if (data.deleid != null) {
        var index = parseInt(data.deleid) + 1;
        var deleID = "hidpic" + index;
        $E(deleID).value = ""; //传递过来的resu是从0开始传过来的索引
        var list = piclist.split(",");
        if (list.length > index - 1) {
            list = list.del(index - 1);
            piclist = list.join(",");
        }
    }
    //移动产品图片
    else if (data.moveid != null) {
        var nowindex = data.moveid.substr(0, 1);
        var newindex = data.moveid.substr(2, 1);
        var list = piclist.split(",");
        if (list.length >= nowindex && list.length > newindex) {
            var valueTemp = list[newindex];
            list[newindex] = list[nowindex];
            list[nowindex] = valueTemp;
            piclist = list.join(",");
        }
    }
    else {
        $E("hidvideo").value = resu;
        videoTemp = resu;
        //alert(videoTemp);
    }
};
XD.receiveMessage(callback);




//加载产品信息
$(document).ready(function () {
    var Request = new Object();
    Request = GetRequest();
    var prdID = Request["id"];
    if (prdID != null) {
        $.ajax({
            type: "POST",
            url: '/AjaxPages/pwdAjax.aspx',
            data: "{'action':'edit','id':'" + prdID + "'}",
            success: function (resu) {
                var obj = eval("(" + resu + ")"); //转换为json对象                
                var baseInfo = obj.baseInfo; //基本信息  
                //如下支持谷歌和火狐及其它浏览器
                var loadPics = baseInfo.pics.split(','); //加载产品图片           
                piclist = baseInfo.pics;
                $("#hidPics").val(piclist);
                $.each(loadPics, function (i, val) {
                    //alert(val);
                    send(val);
                    //alert(val);
                });
                videoTemp = baseInfo.videoUrl;
                $("#hidvideo").val(videoTemp);
                send(baseInfo.videoUrl); //产品视频 （是加密的）               
                XD.receiveMessage(callback);
            },
            error: function (obj) {
            }
        });
    }
    else {
    }
});


function SavePic() {   
    var Request = new Object();
    Request = GetRequest();
    var prdID = Request["id"];
    //alert(piclist);
    //alert(videoTemp);
    if (prdID != null) {
        $.ajax({
            type: "POST",
            url: '/AjaxPages/pwdAjax.aspx',
            //data: "{'action':'savePic','id':'" + prdID + ",'pics':'" + escape(piclist) + "'}",
            data: "{'action':'savePic','id':'" + prdID + "','pics':'" + piclist + "','video':'" + escape(videoTemp) + "'}",
            success: function (resu) {
                alert("success");
            },
            error: function (obj) {
                alert("false");
            }
        });
    }
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

//数组操作
Array.prototype.del = function (n) {//n表示第几项，从0开始算起。
    //prototype为对象原型，注意这里为对象增加自定义方法的方法。
    if (n < 0)//如果n<0，则不进行任何操作。
        return this;
    else
        return this.slice(0, n).concat(this.slice(n + 1, this.length));
    /*
　　　concat方法：返回一个新数组，这个新数组是由两个或更多数组组合而成的。
　　　　　　　　　这里就是返回this.slice(0,n)/this.slice(n+1,this.length)
　　 　　　　　　组成的新数组，这中间，刚好少了第n项。
　　　slice方法： 返回一个数组的一段，两个参数，分别指定开始和结束的位置。
　　*/
}

