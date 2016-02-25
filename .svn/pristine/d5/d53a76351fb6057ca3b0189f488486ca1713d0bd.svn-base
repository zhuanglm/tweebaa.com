(function ($) {
    $.extend({
        ajaxpost: function (options) {
            var defaults = {
                onsuccess: function (data) { },
                onbeforeSend: function () { },
                oncomplete: function () { },
                onerror: function (XMLHttpRequest, textStatus, errorThrown) {
                    if (errorThrown || textStatus == "error" || textStatus == "parsererror" || textStatus == "notmodified") {
                        return;
                    }
                    if (textStatus == "timeout") {
                        return;
                    }
                },
                data: "",
                method: '',
                jsonkey: ",strKey:'BF0C4A1B-8289-4D25-A946-5D8FAE05B850'"
            };
            var options = $.extend(defaults, options);
            var webserviceurl = "http://localhost:4214/web/";
            $.ajax({
                type: "post",
                url: webserviceurl + "server/" + options.method,
                data: "{" + options.data + options.jsonkey + "}",
                contentType: "Application/Json",
                success: function (data) {
                    var json = eval('(' + data.d + ')');
                    var obj = eval('(' + json + ')');
                    options.onsuccess(obj);
                },
                complete: function (XMLHttpRequest, textStatus) {
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    options.onerror(XMLHttpRequest, textStatus, errorThrown);
                },
                beforeSend: function () { options.onbeforeSend(); },
                complete: function () { options.oncomplete(); }
            });
        }
    });
})(jQuery);