var flag = "ok";
var smsStr = "";
// JavaScript Document
$(function () {
    // $("form :input.required").each(function(){
    //     var $required = $("<strong class='high'> *</strong>"); //创建元素
    //     $(this).parent().append($required); //然后将它追加到文档中
    // });
    $("form").each(function (index, el) {
        var THIS = $(this)
        //文本框失去焦点后
        THIS.find(':input').blur(function () {
            var $parent = $(this).parent();
            $parent.find(".error,.ok").hide();
            //验证用户名  yourname
            if ($(this).is('.yourname')) {

                if (this.value == "" || this.value.length < 2 || this.value.length > 20) {
                    flag = "error";
                    $parent.find(".error").show();

                } else {
                    if (isNaN($.trim(this.value).split("")[0])) {
                        flag = "ok";
                        $parent.find(".ok").css('display', 'block');
                    }
                    else {
                        flag = "error";
                        $parent.find(".error").show();
                    }

                }
            }
            //验证密码
            var psw1 = 0;
            var psw2 = 0;
            var reg = /^([a-z]+(?=[0-9])|[0-9]+(?=[a-z]))[a-z0-9]+$/ig;
            if ($(this).is('.userPwd')) {
                psw1 = this.value
                if (this.value == "" || this.value.length < 6 || this.value.length > 20 || reg.test(psw1) == false) {
                    flag = "error";
                    $parent.find(".error").show();
                } else {
                    flag = "ok";
                    $parent.find(".ok").css('display', 'block');
                }
            }
            if ($(this).is('.userPwd2')) {
                psw2 = this.value
                pwdError2
                if (this.value == "" || ($(".userPwd").val() != psw2)) {
                    flag = "error";
                    $("#pwdError1").show();
                    return;
                }
                if (reg.test(psw2) == false) {
                    flag = "error";
                    $("#pwdError2").show();
                    return;
                }             
                else {
                    flag = "ok";
                    $parent.find(".ok").css('display', 'block');
                }

            }
            //验证邮件
            if ($(this).is('.email')) {
                if (this.value == "" || (this.value != "" && !/.+@.+\.[a-zA-Z]{2,4}$/.test(this.value) && !/^1\d{10}$/.test(this.value))) {
                    flag = "error";
                    $parent.find(".error").show();
                } else {
                    flag = "ok";
                    $parent.find(".ok").css('display', 'block');
                }

                //判断类型

                if (/^1\d{10}$/.test(this.value)) {
                    $(".yzm-style").hide();
                    $(".yzm-style").eq(1).show()
                    $("#yzm-style").text('手机验证码')
                } else {
                    $(".yzm-style").hide();
                    $(".yzm-style").eq(0).show()
                    $("#yzm-style").text('验证码')
                }

            }
        }).keyup(function () {
            $(this).triggerHandler("blur");
        }).focus(function () {
            $(this).triggerHandler("blur");
        }); //end blur


        //提交，最终验证。
        THIS.find('.send').click(function () {
            THIS.find(" :input").trigger('blur');
            var numError = THIS.find('.onError').length;
            if (flag != "error") {
                ResetPwd();
            }
            //            else {
            //                alert("Please enter the correct password");
            //            }

        });

        //重置
        $('#res').click(function () {
            $(".formtips").remove();
        });

        function trim(str) {
            return str.replace(/(^\s*)|(\s*$)/g, "");
        }
    });
})

//重置密码
function ResetPwd() {
    var Request = new Object();
    Request = GetRequest();
    var user = Request["id"];
    var type = Request["type"]; //eamil、phone
    if (user == null || user == "" || user == null || type == "") {
        alert("Verification message has been sent. Please follow the directions in the email message to reset your password.");
        return;
    }
    else {
        var _data ="user=" + user + "&pwd=" + $(".userPwd").val() + "&type=" + type;
        $.ajax({
            type: "POST",
            url: '../AjaxPages/updatePwdAjax.aspx',
            data: _data,
            success: function (msg) {
                if (msg == "success") {
                    $("#labMessage1").html("Your password has been reset.");
                    $("#greybox").show();
                   
                    return;
                }
                else {
                    $("#labMessage2").html("Change the password failed");
                    $("#greybox2").show();                  
                    return;
                }
            },
            error: function (msg) {
                $("#labMessage2").html("Change the password failed");
                $("#greybox2").show();
                return;
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
 