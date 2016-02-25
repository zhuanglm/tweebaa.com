var flag = "ok";
var isexit = false;
var smsStr = "";
// JavaScript Document
$(function () {
    $("form").each(function (index, el) {
        var THIS = $(this)
        //文本框失去焦点后
        THIS.find(':input').blur(function () {
            var $parent = $(this).parent();
            // $parent.find(".error,.ok").hide();
            //验证用户名  yourname
            //            if ($(this).is('.yourname')) {
            //                if (this.value == "" || this.value.length < 2 || this.value.length > 20) {
            //                    flag = "error";
            //                    $("#nameTip").show();
            //                    $("#nameOk").hide();
            //                }
            //                else {
            //                    if (isNaN($.trim(this.value).split("")[0])) {
            //                        flag = "ok";
            //                        $("#nameTip").hide();
            //                        $("#nameOk").show();
            //                    }
            //                    else {
            //                        flag = "error";
            //                        $("#nameTip").show();
            //                        $("#nameOk").hide();
            //                    }
            //                }
            //            }
            //验证密码
            var psw1 = 0;
            var psw2 = 0;
            if ($(this).is('.userPwd')) {
                psw1 = this.value;
                var reg = /^([a-z]+(?=[0-9])|[0-9]+(?=[a-z]))[a-z0-9]+$/ig;
                if (this.value == "" || this.value.length < 6 || this.value.length > 20 || reg.test(psw1) == false) {
                    flag = "error";
                    $("#pwdTip").show();
                    $("#pwdOk").hide();
                    //                    $parent.find(".error").show();
                    //                    $parent.find(".ok").hide();
                } else {
                    flag = "ok";
                    $("#pwdTip").hide();
                    $("#pwdOk").show();
                    //$parent.find(".ok").css('display', 'block');
                    //$parent.find(".error").hide();
                }
            }
            if ($(this).is('.userPwd2')) {
                psw2 = this.value

                if (this.value == "" || ($(".userPwd").val() != psw2)) {
                    flag = "error";
                    $parent.find(".error").show();
                    $parent.find(".ok").hide();
                } else {
                    flag = "ok";
                    $parent.find(".ok").css('display', 'block');
                    $parent.find(".error").hide();
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

            if (!($("#emailTip").is(":hidden") && $("#nameTip").is(":hidden") && $("#pwdTip").is(":hidden") && $("#pwdTip2").is(":hidden"))) {
                return;
            }
            if (document.getElementById("ckbAgree").checked == false) {
                $("#labTitle").html("Registration Agreement");
                $("#labMessage").html("You must agree to our Terms of Service");
                $("#greybox2").show();
                return;
            }

            if (document.getElementById("ckbConsent").checked == false) {
                $("#labTitle").html("Consent to receiving electronic communications");
                $("#labMessage").html("You must consent to receiving electronic communications");
                $("#greybox2").show();
                return;
            }
           
            var numError = THIS.find('.onError').length;
            var Email = $("#txtEmail").val();
//            if (Email == "" || Email == null || !/.+@.+\.[a-zA-Z]{2,4}$/.test(Email) && !/^1\d{10}$/.test(Email)) {
//                flag = "error";
//                $("#emailTip").html("Please enter a valid email address").show();
//                $("#emailOk").hide();
//                return;
//            }

            var LoginName = $("#txtLoginName").val();
//            if (LoginName == "" || LoginName.length < 2 || LoginName.length > 20 || !isNaN($.trim(LoginName).split("")[0])) {
//                flag = "error";
//                $("#nameTip").show();
//                return;
//            }

            if (flag != "error") {
                var regType = "1";
                var codeStr1 = $("#ValiCode1").val(); //文本验证码
                // var code = document.getElementById("code").innerText;
                var code = $("#code").html();
                if (codeStr1 == "" || codeStr1.toUpperCase() != code) {
                    $("#labTitle").html("Enter the verification code");
                    $("#labMessage").html("Verification code input error");
                    $("#greybox2").show();
                    return;
                }


                var Email = $("#txtEmail").val();
                var Pass = $("#txtPass").val();
                var PassAgain = $("#txtPassAgain").val();
                var Country = $("#WebContent_selectCountry  option:selected").val();


                var tuijieEmail = $("#txtReferrerEmail").val();
                var knowWay = $("#ddlway option:selected").val();

                //                var obj = document.getElementById("<%=selectCountry.ClientID %>"); //定位id
                //                var index = obj.selectedIndex; // 选中索引               
                //                var Country = obj.options[index].value; // 选中值

                var Consent = document.getElementById("chkConsent").checked;
                
                Apost(Email, LoginName, Pass, PassAgain, Country, tuijieEmail, knowWay, Consent);
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



//注册请求
function Apost(Email, LoginName, Pass, PassAgain, Country, tuijieEmail, knowWay, Consent) {
    var _data = 'Email=' + Email + "&LoginName=" + LoginName + "&Pass=" + Pass + "&Country=" + Country + "&TuiJieEmail=" + tuijieEmail + "&KnowWay=" + knowWay + "&Consent=" + Consent;
    $.ajax({
        type: "POST",
        url: '../AjaxPages/registerAjax.aspx',
        data: _data,
        success: function (msg) {
            $("#labTitle").html("User registration");
            if (msg == "1") {
               // $("#labMessage1").html("The activation email has been sent. <br> Please login and activate your account.");
                $("#greybox").show();
                return;
            }
            else if (msg == "-1") {
                $("#labMessage").html("The mailbox is already registered");
                $("#greybox2").show();
            }
            else {
                $("#labMessage").html("Registration failed, please try again later");
                $("#greybox2").show();
            }
        },
        error: function (msg) {
            $("#labMessage").html("Registration failed, please try again later");
            $("#greybox2").show();
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