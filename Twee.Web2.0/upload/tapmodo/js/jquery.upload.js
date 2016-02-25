
function uplod() {
    $("#iframeUpload").contents().find("#upload1").click();
}
function getImg(imgValue) {
    if (imgValue.indexOf('resInt') > 0) {
        //alert(imgValue);
        var obj = eval("(" + imgValue + ")"); //转换为json对象
        var resInt = obj.resInt;
        var message = obj.message; //原图路径
        var message2 = obj.message2; //小图路径
        //alert("resInt:" + resInt);
        if (resInt != "1") {
            alert(message);
        }
        else {
            for (var i = 1; i < 6; i++) {
                var imgId = "#img" + i;
                //alert(imgId + "  , " + $(imgId).attr("src"));
                if ($(imgId).attr("src") == "" || $(imgId).attr("src") == null) {
                    $(imgId).attr("src", message2);
                    $("#iframeUpload").attr("src", "fileControl.aspx");
                    return;
                }
            }
        }
        $("#iframeUpload").attr("src", "fileControl.aspx");
    }
}


(function ($) {
    $.fn.extend({
        upload: function (options) {
            var defaults = { actionUrl: '', uploadUrl: '', imgurl: '', text: '&nbsp;' }
            var options = $.extend(defaults, options);
            this.each(function () {
                // + Math.random()
                options.text = $(this).attr("text");
                $(this).attr("boxAttr", "box" + getMath(10));
                init($(this), options);
            });
        },
        error: function () {
            //alert();
        },
        getfiles: function () {
            return $("#hidUploadLst").val().replace(",", "");
        }
    });
    function init(targetbox, options) {
        var id = $(targetbox).attr("boxAttr");
        var fmId = "fm" + id;
        var txtId = "txt" + id;
        var fileId = "file" + id;
        var htm = '';
        htm = ''
            + '<form id="' + fmId + '" name="' + fmId + '" action="' + options.actionUrl + '"  method="post" enctype="multipart/form-data">'
        + " <input type='text' name='" + txtId + "' id='" + txtId + "' class='txtField' /><input type='button' class='btnBrouse' value='" + options.text + "' />"
            + '<input class="fileField" type="file" id="' + fileId + '" name="' + fileId + '" />'
            + '</form>'
            + '';
        $(targetbox).html(htm);
        //
        if (options.imgurl.length > 0)
            $(targetbox).append('<img  src="' + options.imgurl + '" /><span class="dvTool" title="移出" onclick="$(this).prev().remove(); $(this).remove(); ">X</span>');
        //
        $(targetbox).find("input[type='file']").change(
        function () {
            change(targetbox, options);
        });
    };
    function change(targetbox, options) {
        $(targetbox).find("input[type='text']").val($(targetbox).find("input[type='file']").val());
        $(targetbox).append("<div class='loading'></div>");
        var id = $(targetbox).attr("boxAttr");
        var ifmId = "ifm" + id;
        $(targetbox).find("iframe").remove();
        var ifm = $('<iframe width="300" height="120" frameborder="0" id="' + ifmId + '" name="' + ifmId + '">');
        ifm.appendTo($(targetbox));
        var fmId = "fm" + id;
        // alert(fmId);
        $("#" + fmId).attr('target', ifmId);
        //alert($("#" + fmId).html());
        $("#" + fmId).submit();
        ifm.load(function () {
            var doc = $('#' + $(ifm).attr("id")).contents().find('body');
            //           alert(doc.html());
            var obj = eval('(' + doc.html() + ')');
            //alert(obj.resInt);
            if (obj.resInt == "1") {
                var h = '<img alt="' + obj.message + '" src="' + options.uploadUrl + obj.message2 + '" /><span class="dvTool" title="移出" onclick="$(\'#hidUploadLst\').val( $(\'#hidUploadLst\').val().replace($(this).prev().attr(\'alt\'),\'\')  );;$(this).prev().remove(); $(this).remove(); ">X</span>';
                $(targetbox).append(h);
                $("#hidUploadLst").val($("#hidUploadLst").val() + "," + obj.message);
            }
            else {
                alert(obj.message);
            }
            $(targetbox).find(".loading").remove();
        });
    };
    var getMath = function (n) {
        var chars = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
        var res = "";
        for (var i = 0; i < n; i++) {
            var id = Math.ceil(Math.random() * 35);
            res += chars[id];
        }
        return res;
    }

})(jQuery);

$(document).ready(function () {
    var hidImgs = "<input id='hidUploadLst' type='hidden' />";
    //var hidImgs = '<input id="hidUploadLst" type="text" />';
    $(document.body).append(hidImgs);
});