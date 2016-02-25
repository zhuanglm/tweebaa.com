$(document).ready(function () {
//    $("[validity]").each(function () {
//        if ($(this).attr("validity").length > 0) {
//            var validity = $(this).attr("validity");
//            var value = $(this).val();
//            //
//            switch (validity) {
//                case "email":
//                    $(this).blur(function () {
//                        chkEmail(this, false);
//                    });
//                    break;
//                case "password":
//                    $(this).blur(function () {
//                        chkpassword(this, false);
//                    });
//                    break;
//                case "repassword":
//                    $(this).blur(function () {
//                        chkrepassword(this, false);
//                    });
//                    break;
//                case "request":
//                    $(this).blur(function () {
//                        chkRequest(this, false);
//                    });
//                    break;
//                case "ZIP":
//                    $(this).blur(function () {
//                        chkZIP(this, false);
//                    });
//                    break;
//                case "chkChk":
//                    $(this).blur(function () {
//                        chkChk(this, false);
//                    });
//                    break;
//                case "select":
//                    $(this).blur(function () {
//                        chkSelect(this, false);
//                    });
//                    break;
//                //                case "rad":  
//                //                    $(this).blur(function () {  
//                //                        chkSelect(this, false);  
//                //                    });  
//                //                    break;  
//                default:
//                    break;
//            }
//            //
//        }
//    });

});

function chkBtn(grp) {
    return true;
//    var b = 0;
//    $("[validity]").each(function () {
//        if ($(this).attr("validity").length > 0 && $(this).attr("grp") == grp) {
//            var validity = $(this).attr("validity");
//            var value = $(this).val();
//            //
//            switch (validity) {
//                case "email":
//                    b = b - (chkEmail(this, true) == true ? 0 : 1);
//                    break;
//                case "password":
//                    b = b - (chkpassword(this, true) == true ? 0 : 1);
//                    break;
//                case "repassword":
//                    b = b - (chkrepassword(this, true) == true ? 0 : 1);
//                    break;
//                case "request":
//                    b = b - (chkRequest(this, true) == true ? 0 : 1);
//                    break;
//                case "ZIP":
//                    b = b - (chkZIP(this, true) == true ? 0 : 1);
//                    break;
//                case "chkChk":
//                    b = b - (chkChk(this, true) == true ? 0 : 1);
//                    break;
//                case "select":
//                    b = b - (chkSelect(this, true) == true ? 0 : 1);
//                    break;
//                case "rad":
//                    b = b - (chkRad(this, true) == true ? 0 : 1);
//                    break;
//                default:
//                    break;
//            }
//            //
//        }
//    });
//    if (b < 0) {
//        return false;
//    }
//    else {
//        return true;
//    }
}
/*
email验证
*/
function chkEmail(obj, bl) {
    if ($(obj).val().length > 0) {
        //----
        var search_str = /^[\w\-\.]+@[\w\-\.]+(\.\w+)+$/;
        if (!search_str.test($(obj).val())) {
            adderror(obj, $(obj).attr("errortxt"));
            if (bl)
                $(obj).focus();
            return false;
        }
        else {
            addright(obj, "");
            return true;
        }
        //-----
    }
    else {
        adderror(obj, $(obj).attr("emptytxt"));
        return false;
    }
    return true;
}
/*
密码验证
密码为6~16个字符，区分大小写。
*/
function chkpassword(obj, bl) {
    if ($(obj).val().length > 0) {
        //----
        var search_str = /[a-zA-Z0-9]{6,16}/;
        if (!search_str.test($(obj).val())) {
            adderror(obj, $(obj).attr("errortxt"));
            if (bl)
                $(obj).focus();
            return false;
        }
        else {
            addright(obj, "");
            return true;
        }
        //-----
    }
    else {
        adderror(obj, $(obj).attr("emptytxt"));
        return false;
    }
    return true;
}
/*
再次密码验证
*/
function chkrepassword(obj, bl) {
    if ($(obj).val() != $("#txtPassword").val()) {
        //----
        adderror(obj, $(obj).attr("errortxt"));
        if (bl)
            $(obj).focus();
        return false;
        //-----
    }
    else {
        addright(obj, "");
        return true;
    }
}

/*
必填验证
*/
function chkRequest(obj, bl) {
    if ($(obj).val().length > 0) {
        var min = $(obj).attr("min");
        var max = $(obj).attr("max");
        if (typeof (min) == "undefined" || typeof (max) == "undefined") {
            //----
            addright(obj, "");
            return true;
            //-----
        }
        else {
            if ($(obj).val().length >= $(obj).attr("min") * 1 && $(obj).val().length <= $(obj).attr("max") * 1) {
                //----
                addright(obj, "");
                return true;
                //-----
            }
            else {
                //alert($(obj).val().length);
                adderror(obj, $(obj).attr("lengthtxt"));
                return false;
            }

        }

    }
    else {
        adderror(obj, $(obj).attr("emptytxt"));
        return false;
    }
    return true;
}
/*
ZIP验证,目前的验证方式是不能输入汉字
*/
function chkZIP(obj, bl) {
    if ($.trim($(obj).attr("emptytxt")).length > 0) {//需要验证空
        if ($(obj).val().length == 0) {
            //----
            adderror(obj, $(obj).attr("emptytxt"));
            return false;
            //-----
        }
    }
    var a = $(obj).val();
    if (/[\u4E00-\u9FA5]/i.test(a)) {//有汉字
        //----
        adderror(obj, $(obj).attr("errortxt"));
        return false;
        //-----
    } else {//无汉字
        addright(obj, "");
        return true;
    }
    return true;
}
/*
chklst,最少选择一个chklst
*/
function chkChk(obj, bl) {
    //alert($("input[type=checkbox][name='ckstore']:checked").length);
    if ($.trim($(obj).attr("emptytxt")).length > 0) {//需要验证空
        if ($("input[type=checkbox][name='ckstore']:checked").length == 0) {
            //----$("input[type=checkbox][name=11111][checked]").length
            adderror(obj, $(obj).attr("emptytxt"));
            return false;
            //-----
        }
        else {
            addright(obj, "");
            return true;
        }
    }
    return true;
}
/*
chklst,最少选择一个radio
*/
function chkRad(obj, bl) {
    //alert($("input[type=checkbox][name='ckstore']:checked").length);
    if ($.trim($(obj).attr("errortxt")).length > 0) {//需要验证空
        if (typeof ($('input[name="rad"]:checked').val()) == "undefined") {
            //----$("input[type=checkbox][name=11111][checked]").length
            adderror(obj, $(obj).attr("errortxt"));
            return false;
            //-----
        }
        else {
            addright(obj, "");
            return true;
        }
    }
    return true;
}
/*
必填验证
*/
function chkSelect(obj, bl) {
    //alert($(obj).val().length);
    if ($(obj).val().length > 0) {
        //----
        addright(obj, "");
        return true;
        //-----
    }
    else {
        adderror(obj, $(obj).attr("errortxt"));
        return false;
    }
    return true;
}
/*
增加错误
*/
function adderror(obj, text) {
    $(obj).removeClass("checkwrong").addClass("checkwrong");
    $(obj).val(text);
//    $(obj).css({
//        "color": "white",
//        "background-color": "#D6D6FF",
//        "font-family": "Arial",
//        "font-size": "20px",
//        "padding": "5px"
//    });
    //    if ($(obj).parent().find("label[class=error]").length == 0) {
    //        $(obj).parent().append("<label class='error'>" + text + "</label>");
    //        return;
    //    }
    //    else {
    //        $(obj).parent().find("label[class=error]").html(text);
    //    }
}
/*
移出错误，
增加正确
*/
function addright(obj, text) {
    //    $(obj).css({
    //        "color": "white",
    //        "background-color": "#D6D6FF",
    //        "font-family": "Arial",
    //        "font-size": "20px",
    //        "padding": "5px"
    //    });
    if ($(obj).parent().find("label[class=error]").length == 0) {
        // $(obj).next().remove();
        // $(obj).parent().append("<label class='error'>" + text + "</label>");
    }
    else {
        $(obj).parent().find("label[class=error]").remove();
    }
}

/*JQuery 限制文本框只能输入数字和小数点*/
$(function () {
    $(".inputNumber").keypress(function () {
        $(this).val($(this).val().replace(/[^0-9.]/g, ''));

    }).blur(function () {
        $(this).val($(this).val().replace(/[^0-9.]/g, ''));

    }).keyup(function () {
        $(this).val($(this).val().replace(/[^0-9.]/g, ''));

    }).bind("paste", function () {  //CTR+V事件处理     
        $(this).val($(this).val().replace(/[^0-9.]/g, ''));

    }).css("ime-mode", "disabled"); //CSS设置输入法不可用     
});