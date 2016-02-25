/*
title: "你好",
msg: "msg",
okText: "okText",
cancelTxt: 'canceltext',
showMask: true,
sourceDiv:'',
icoType:'',
okCallback: function () { alert("ok"); },
cancelCallback: function () { alert("cnace"); }
second,秒
secondWord,秒后面的文字 
secondCallback:function(){}
*/

(function ($) {
    $.extend({
        popup: function (options) {
            //默认值
            var defaults = {
                icoType: 0,
                title: '',
                msg: "",
                css: 'wnBox',
                showMask: true,
                okCallback: null,
                cnacelCallback: null,
                secondCallback: null
            };
            var options = $.extend(defaults, options);
            var id = _generateMixed(5);
            var _boxId = _creat(options, id);
            $("#btnok" + id).unbind().bind("click", function () {
                if (options.okCallback) {
                    options.okCallback();
                }
                _close(id);
            });
            $("#btncancel" + id).unbind().bind("click", function () {
                if (options.cancelCallback) {
                    options.cancelCallback();
                }
                _close(id);
            });
            _drag(_boxId, 1);
            return _boxId;
        },
        popupClose: function (boxid) {
            var id = boxid.replace("box", "");
            var bg = "bg" + id, box = "box" + id;
            $("#" + bg).remove();
            $("#" + box).remove();
            clearTimeout(t);
        }
    });
    function _creat(options, id) {
        var title, border, msg, button, box;
        var _bgId = "bg" + id, _boxId = "box" + id, _borderId = "border" + id, _titleId = 'titleId' + id, _btnokid = "btnok" + id, _btncancelId = "btncancel" + id;
        //边框
        border = '<DIV  class="wnBorder wndrg"></div>';
        //如果有标题
        if (typeof (options.title) != "undefined")
            title = '<div id="' + _titleId + '" class="wnBoxTitle wndrg">' + options.title + '</div><a id="aclolse" class="close" href="javascript:void(0)" onclick="_close(\'' + id + '\')">X</a>';
        else
            title = "";
        if (options.sourceDiv) {
            if (oldhtml.length == 0)
                oldhtml = $("#" + options.sourceDiv).html();
            msg = oldhtml;
            $("#" + options.sourceDiv).html("");
        }
        else {
            //内容
            if (typeof (options.msg) != "undefined") {
                msg = ''
                + '<table class="wndrg_ddddd">'
                + '<tr>'
                + '<td class="wnBoxMain_text" >' + options.msg + '</td>'
                + '</tr>'
                + '</table>';
            }
            else
                msg = "";
        }
        //按钮
        var _buttonOk = "", _buttonCancel = "";
        if (typeof (options.okText) != "undefined")
            _buttonOk = '<A id="' + _btnokid + '" class="box_botton2"  href="javascript:void(0)">' + options.okText + '</A>&nbsp;';
        if (typeof (options.cancelTxt) != "undefined")
            _buttonCancel = '<A id="' + _btncancelId + '"class="box_botton3" href="javascript:void(0)" >' + options.cancelTxt + '</A>';
        if (typeof (options.okText) != "undefined" || typeof (options.cancelTxt) != "undefined")
            button = '<div class="wn_botton">' + _buttonOk + _buttonCancel + "</div>";
        else
            button = "";
        //插入背景
        if (typeof (options.showMask) != "undefined" && options.showMask == true)
            $("BODY").append('<div id="' + _bgId + '" class="wnBoxBg"></div>');
        //构造弹出box
        var _boxWi = "";
        if (typeof (options.maxWidth) == "undefined" || isNaN(options.maxWidth) || options.maxWidth == null)
            _boxWi = "";
        else
            _boxWi = "width:" + options.maxWidth + "px" + ";";
        box = ''
                 + '<DIV id="' + _boxId + '" class="' + options.css + '" style="' + _boxWi + '" >'
                 + border
                 + title
                 + '<div class="wnBoxMain">'
                 + msg
                 + button
                 + '</DIV>'
                 + '</DIV>'
                 + '';
        $("BODY").append(box);
        //浏览器可视窗口的高度和宽度，中间显示
        var w = $("#" + _boxId).css("width").toUpperCase().replace("PX", "");
        var h = $("#" + _boxId).css("height").toUpperCase().replace("PX", "");
        var _tar_left = ($(window).width() - w) / 2;
        var _tar_top = ($(window).height() - 150) / 2;
        if (options.sourceDiv) _tar_top = 80;
        $("#" + _boxId).css({
            "left": _tar_left,
            "top": _tar_top
        });
        $(".wn_botton").css({
            "width": w * 1 - 10
        });
        //        //如果动画形式 shitType,shitPx
        //        if (typeof (options.shitType) != "undefined" && options.shitType != null) {
        //            if (typeof (options.shitPx) != "undefined" || !isNaN(options.shitPx) || options.shitType != null)
        //                $("#" + _boxId).css({ top: "-200px" }).animate({
        //                    top: "200px"
        //                }, 500, "");
        //        };
        //如果有自动关闭 
        if (typeof (options.second) != "undefined") {
            _countDown(options.second, options.secondWord, options.msg, id, options.secondCallback);
        };
        //如果有定位area
        if (typeof (options.area) != "undefined") {
            var area_top = $("#" + options.area).offset().top;
            var area_left = $("#" + options.area).offset().left;
            var area_w = $("#" + options.area).css("width").toUpperCase().replace("PX", "");
            var area_h = $("#" + options.area).css("height").toUpperCase().replace("PX", "");

            var w = $("#" + _boxId).css("width").toUpperCase().replace("PX", "");
            var h = $("#" + _boxId).css("height").toUpperCase().replace("PX", "");
            var _tar_left = area_left + (area_w - w) / 2;
            var _tar_top = area_top + (area_h - 150) / 2;

            $("#" + _bgId).css({
                "width": area_w + "px",
                "height": area_h + "px",
                "top": area_top,
                "left": area_left,
                "position": "absolute"
            });
            $("#" + _boxId).css({
                "position": "absolute",
                "left": _tar_left,
                "top": _tar_top
            });

        }
        return _boxId;
    };
    _generateMixed = function (n) {
        var chars = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
        var res = "";
        for (var i = 0; i < n; i++) {
            var id = Math.ceil(Math.random() * 35);
            res += chars[id];
        }
        return res;
    };
    _drag = function (boxId, s) {
        //整个dia的宽高
        var dia_width = $("#" + boxId).css("width").toUpperCase().replace("PX", "");
        var dia_height = $("#" + boxId).css("height").toUpperCase().replace("PX", "");
        var new_x = ""; //目标位置
        var new_y = "";
        var orig_x = ""; //单击时的源位置
        var orig_y = "";
        var setLeft = ""; //单击时离元素最左上角的位置
        var offsetTop = "";
        if (typeof boxId == "string") boxId = document.getElementById(boxId);
        boxId.orig_index = boxId.style.zIndex;
        $(".wndrg").on('mousedown', function (a) {
            //移动时加个遮照，可不要
            boxId.style.zIndex = 10000;
            //document.getElementById("aclolse").style.zIndex = 999999;
            if (!a) a = window.event;
            setLeft = a.clientX + document.body.scrollLeft - boxId.offsetLeft;
            setTop = a.clientY + document.body.scrollTop - boxId.offsetTop;
            document.ondragstart = "return false;";
            document.onselectstart = "return false;";
            document.onselect = "document.selection.empty();";
            if (boxId.setCapture)
                boxId.setCapture();
            else if (window.captureEvents)
                window.captureEvents(Event.MOUSEMOVE | Event.MOUSEUP);
            document.onmousemove = function (a) {
                if (!a) a = window.event;
                new_x = _mousePosition(a).clientX - setLeft;
                new_y = a.clientY + document.body.scrollTop - setTop;
                //控制边界
                if (new_x < 0) new_x = 8;
                if (new_x > $(window).width() - dia_width) new_x = $(window).width() - dia_width;
                if (new_y > $(window).height() - dia_height) new_y = $(window).height() - dia_height;
                if (new_y < 0) new_y = 10;
                boxId.style.left = new_x.toString() + "px"; ;
                boxId.style.top = new_y.toString() + "px";
                //保存最后位置
                boxId.orig_x = parseInt(boxId.style.left) - _mousePosition(a).scrollLeft;
                boxId.orig_y = parseInt(boxId.style.top) - _mousePosition(a).scrollTop;
            }
            document.onmouseup = function () {
                if (boxId.releaseCapture)
                    boxId.releaseCapture();
                else if (window.captureEvents)
                    window.captureEvents(Event.MOUSEMOVE | Event.MOUSEUP);
                document.onmousemove = null;
                document.onmouseup = null;
                document.ondragstart = null;
                document.onselectstart = null;
                document.onselect = null;
                boxId.style.zIndex = boxId.orig_index;
            }
        });
        //        if (s) {
        //            var orig_scroll = window.onscroll ? window.onscroll : function () { };
        //            window.onscroll = function () {
        //                if (!isNaN(boxId.orig_x && boxId.orig_y)) {
        //                    orig_scroll();
        //                    boxId.style.left = boxId.orig_x + document.body.scrollLeft;
        //                    boxId.style.top = boxId.orig_y + document.body.scrollTop;
        //                }
        //            }
        // };
        window.onresize = function () {
            boxId.style.left = ($(window).width() - dia_width) / 2 + "px";
            boxId.style.top = ($(window).height() - dia_height) / 2 + "px";
        }
    };
    _mousePosition = function (ev) {
        var obj = { bodyX: '', bodyY: '', screenX: '', screenY: '', clientX: '', clientY: '', scrollLeft: '', scrollTop: '' };
        obj.screenX = ev.screenX; //相对于屏幕
        obj.screenY = ev.screenY;
        obj.clientX = ev.clientX; //相对浏览器窗口
        obj.clientY = ev.clientY;
        obj.scrollLeft = document.body.scrollLeft;
        obj.scrollTop = document.body.scrollTop;
        //相对于文档body
        obj.bodyX = ev.pageX || (ev.clientX + (document.documentElement.srcollLeft || document.body.scrollLeft));
        obj.bodyY = ev.pageY || (ev.clientY + (document.documentElement.scrollTop || document.body.scrollTop));
        return obj;
    };
    _countDown = function (secs, secsWord, txt, id, okCallback) {
        //退出成功,20秒后自动转到首页 
        clearTimeout(t);
        var jumpTo = $("#box" + id + " .wnBoxMain_text");
        //jumpTo.html(txt + "(<font>" + secs + '</font> ' + secsWord + ')');
        jumpTo.html(txt.replace("secondword", secs + secsWord));
        if (--secs > 0) {
            t = window.setTimeout("_countDown(" + secs + ",'" + secsWord + "','" + txt + "','" + id + "'," + okCallback + ")", 1000);
        }
        else {
            _close(id);
            if (okCallback)
                okCallback();
        }
    };
    //关闭事件
    _close = function (id) {
        var bg = "bg" + id, box = "box" + id;
        $("#" + bg).remove();
        $("#" + box).remove();
        clearTimeout(t);
    };
    var t;
    var oldhtml = "";
})(jQuery);