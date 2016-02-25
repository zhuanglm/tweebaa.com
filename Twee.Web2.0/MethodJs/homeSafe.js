$(document).ready(
   function () {
       loadSafe();

       $("#btnPhoneNext").click(modifyPhone);
       $("#btnEmail").click(modifyEmail);
   }
);

function loadSafe() {
    var _data = "{ action:'query'}";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/homeSafeAjax.aspx',
        dataType: "json",
        data: _data,
        success: function (resu) {
            if (resu == "-1") {
                AlertEx("You are not logged in！");
                return;
            }

            var pwdstrength = resu.pwdstrength | 0;
            $("#safe-level").css("width", (pwdstrength / 10.0) * 100 + "%");
            if (pwdstrength >= 5) {
                $("#safe-level").css("background-color", "yellow");
            } else if (pwdstrength == 10) {
                $("#safe-level").css("background-color", "green");
            }
            if (resu.phone) {
                $("#phone-container i:first").removeClass("error");
                $("#phone-container i:first").addClass("ok");
                $("#phone-safe-state").text("Safe");
                $("#phone").text(resu.phone);
                $("#phone-state").text("Has been set");
            }
            if (resu.email) {
                $("#email-container i:first").removeClass("error");
                $("#email-container i:first").addClass("ok");
                $("#email-safe-state").text("Safe");
                $("#email").text(resu.email);
                if (resu.wnstat == 1) {
                    $("#email-state").text("Has been set");
                } else {
                    $("#email-state").text("unauthorized");
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            AlertEx("status:" + XMLHttpRequest.status);
            AlertEx("readyState:" + XMLHttpRequest.readyState);
            AlertEx("textStatus:" + textStatus);

            AlertEx("There is no data!");
        }
    });
};

function modifyPhone() {
    var phone = $("#txtPhone").val();
    if (!phone) {
        AlertEx("Please enter the phone number！");
        return false;
    }

    var _data = "{ action:'modifyPhone', phone:'" + phone + "'}";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/homeSafeAjax.aspx',
        dataType: "json",
        data: _data,
        success: function (resu) {
            if (resu == "-1") {
                AlertEx("You are not logged in！");
                return;
            }

            if (resu == "1") {
                AlertEx("Change the phone successfully!")
            } else {
                AlertEx("Change the phone failure!")
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            AlertEx("status:" + XMLHttpRequest.status);
            AlertEx("readyState:" + XMLHttpRequest.readyState);
            AlertEx("textStatus:" + textStatus);

            AlertEx("Change the phone failure！");
        }
    });
}

function modifyEmail() {
    var email = $("#txtEMail_new").val();
    console.log("email=" + email);
    if (!email) {
        AlertEx("Please enter the email address！");
        return false;
    }

    var _data = "{ action:'modifyEmail', email:'" + email + "'}";
    $.ajax({
        type: "POST",
        async: false,
        url: '/AjaxPages/homeSafeAjax.aspx',
        dataType: "json",
        data: _data,
        success: function (resu) {
            if (resu == "-1") {
                AlertEx("You are not logged in！");
                return;
            }
            if (resu == "-2") {
                AlertEx("The email has been registered！");
                return;
            }
            if (resu == "1") {
                AlertEx("The confirmation email has been sent to your mailbox, please confirm to your mailbox!")
            } else {
                AlertEx("Change the mail failure!")
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            AlertEx("status:" + XMLHttpRequest.status);
            AlertEx("readyState:" + XMLHttpRequest.readyState);
            AlertEx("textStatus:" + textStatus);

            AlertEx("Change the mail failure！");
        }
    });
}
/*
function modifyPwd() {

    var email = $("#txtEmail").val();
    if (!email) {
        AlertEx("Please enter the email address！");
        return false;
    }

    var _data = "{ action:'modifyEmail', email:'" + email + "'}";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/homeSafeAjax.aspx',
        dataType: "json",
        data: _data,
        success: function (resu) {
            if (resu == "-1") {
                AlertEx("You are not logged in！");
                return;
            }

            if (resu == "1") {
                AlertEx("Change the email successfully!")
            } else {
                AlertEx("Change the mail failure!")
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            AlertEx("status:" + XMLHttpRequest.status);
            AlertEx("readyState:" + XMLHttpRequest.readyState);
            AlertEx("textStatus:" + textStatus);

            AlertEx("Change the mail failure！");
        }
    });
}
*/
function UpdatePwd() {

    var pwd = $("#txtOldPass").val();      
    if (pwd == null || pwd=="") {
        AlertEx("Please enter your current password!");
        return;
    }
    var pwdNew1 = $("#txtNewPass").val(); 
    var reg = /^([a-z]+(?=[0-9])|[0-9]+(?=[a-z]))[a-z0-9]+$/ig;
    if (pwdNew1 == "" || pwdNew1 == null || pwdNew1 < 6 || pwdNew1 > 20 || reg.test(pwdNew1) == false) {
        AlertEx("The new password must contain numbers and letters !");
        return;

    }
    var pwdNew2 = $("#passwordConfirm").val();
    if (pwdNew1 == null || pwdNew1=="") {
        AlertEx("Please enter your new password!");
        return;
    }  
    if (pwdNew1 != pwdNew2) {
        AlertEx("New Password not match!");
        return;
    }
    /*
    var codeStr1 = $("#ValiCode1").val(); //文本验证码   
    var code = $("#code").html();
    if (codeStr1 == "" || codeStr1.toUpperCase() != code) {
        AlertEx("Verification code input error");
        return;
    }*/

    var _data = "{ action:'updatepwd', pwd:'" + pwd + "', newPwd:'" + pwdNew1 + "'}";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/homeSafeAjax.aspx',
        dataType: "json",
        data: _data,
        success: function (resu) {
            if (resu == "-1") {
                AlertEx("Update password error,please try again later！");
                return;
            }
            if (resu == "2") {
                AlertEx("The current password input error！");
                return;
            }
            if (resu == "1") {
                AlertEx("Change the password successfully!");
                LogOutAndBack2Login();
            } else {
                AlertEx("Change the password failed!")
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            AlertEx("Change the mail failure！");
        }
    });

}

function LogOutAndBack2Login() {
    $.ajax({
        type: "POST",
        url: '/AjaxPages/logionAjax.aspx',
        data: 'Action=out',
        success: function (msg) {
            window.top.location.href = "../User/login.aspx";
        },
        error: function (msg) {
            window.top.location.href = "../User/login.aspx";
        }
    });
}