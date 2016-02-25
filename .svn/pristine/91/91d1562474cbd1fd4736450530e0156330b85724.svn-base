
$(document).ready(function () {
    ///、、
    $("#btnOk").unbind().bind("click", function () {
        if (chkBtn()) {
            //
            var txtValidateCode = $("#txtValidateCode").val();
            var txtNo = $("#txtNo").val();
            var txtPass = $("#txtPassword").val();
            var data = "strNameEmailTel: '"
                    + escape(txtNo)
                    + "', strPass: '"
                    + escape(txtPass)
                    + "', strValidateCode: '"
                    + escape(txtValidateCode)
                    + "'";
            alert(data);
            $.ajaxpost({
                onbeforeSend: function () {
                    load = $.popup({
                        icoType: 20,
                        msg: "加载中……",
                        showMask: true
                    });
                },
                onsuccess: function (jsondata) { loginsuccess(data); }
                        , data: data
                        , method: "Servers/Administrator.asmx/AdministratorLogin"
            }/// 

            );
            //
        }
    });
    function loginsuccess(json) {
        switch (json.it) {
            case "-98":
                $.popupClose(load);
                adderror($("#txtValidateCode"), "验证码错误");
                $.popup({
                    msg: "Sorry,请输入正确的验证码！",
                    showMask: true,
                    second: 3,
                    secondWord: "秒后关闭"
                });
                break;
            case "1":
                for (var o in json) {
                    setCookie(o, unescape(json[o]));
                }
                window.location.href = "ifmDefault.aspx";
                break;
            default:
                $.popupClose(load);
                $.popup({
                    msg: "Sorry,登录失败，请检查用户名和密码！",
                    showMask: true,
                    second: 3,
                    secondWord: "秒后关闭"
                });
                break;
        }
    }
});
