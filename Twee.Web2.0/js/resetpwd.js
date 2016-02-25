var flag = "ok";
var smsStr = "";
// JavaScript Document
$(function () {
    $("form").each(function (index, el) {
        var THIS = $(this)
        //文本框失去焦点后
        THIS.find(':input').blur(function () {
            var $parent = $(this).parent();
            $parent.find(".error,.ok").hide();

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
                    $("#yzm-style").text('Verification Code')
                } else {
                    $(".yzm-style").hide();
                    $(".yzm-style").eq(0).show()
                    $("#yzm-style").text('Verification Code')
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
                var codeType = $("#smsCode").is(":hidden");

                var Email = $("#txtEmail").val();
                //if (codeType == true) 
                {
                    //文字验证码
                    var codeStr1 = $("#ValiCode1").val();
                    var code = document.getElementById("code").innerText;
                    if (codeStr1 == "" || codeStr1.toUpperCase() != code) {
                        /*
                        $("#labMessage").html("Verification code input error");
                        $("#greybox2").show();*/
                        AlertEx("Verification code input error");
                        return;
                    }
                    else {
                        //发送邮件
                        //disable the button
                        THIS.find('.send').attr('disabled', 'disabled');
                        SendEmail(Email);
                    }
                } /*
                else {
                    //语音和短信验证码
                   
                    var codeStr2 = $("#ValiCode2").val();
                    if (codeStr2 == "" || codeStr2.toUpperCase() != smsStr) {
                        $("#labMessage").html("Verification code input error");
                        $("#greybox2").show();
                        return;
                    }
                    else {
                        window.location.href = "resetpwd3.aspx?id=" + Email + "&type=phone";
                    }
                }*/
            }
            else {
                //alert("失败");
            }

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

//获取短信验证码
function GetSmsCode(smsType) {
    var txtPhone = $("#txtEmail").val();
    var _data = 'Phone=' + txtPhone + '&smsType=' + smsType;
    $("#labTitle").html("获取验证码");
    $.ajax({
        type: "POST",
        url: '/AjaxPages/registerAjax.aspx',
        data: _data,
        success: function (msg) {
            if (msg != "" && msg != null && msg.length == 6) {
                smsStr = msg;
                // alert("验证码为：" + msg);             
                if (smsType == "1") {
                    $("#labMessage").html("短信验证码已发送，请查收");
                }
                else if (smsType == "2") {
                    $("#labMessage").html("语音验证码已发送，请接听");
                }
            }
            else {
                $("#labMessage").html(msg);
            }
            $("#greybox2").show();
        },
        error: function (msg) {
            $("#labMessage").html("获取失败，请重试");
            $("#greybox2").show();
        }
    });
}

