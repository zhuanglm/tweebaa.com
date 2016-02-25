﻿var picPathCollage1 = "http://itweebaa.com/upload/uploadImg";
var picPathCollage2 = "http://67.224.94.82/upload/uploadImg";

var entityMap = {
    '&': '&amp;',
    '<': '&lt;',
    '>': '&gt;',
    '"': '&quot;',
    "'": '&#39;',
    '/': '&#x2F;'
};
function Date2MMDDYYYY(s) {
    var sRet = s.replace(/-/g, '/').substring(0, 10);
    if (sRet.substring(4, 5) == "/" && sRet.substring(7, 8) == "/") {
        sRet = s.substring(5, 7) + "/" + s.substring(8, 10) + "/" + s.substring(0, 4);
    }
    return sRet;
}
function RemoveCRLF(strIn) {
    var str2 = strIn.replace(/\n|\r/g, "");
    str2 = escapeHtml(str2);
    return str2;
}

function GetShortDescEx(descFull,max_length) {
    // do no break a work
    if (descFull.length <= max_length) {
        return descFull;
    }
    var descShort = descFull.substring(0, max_length);
    //if (descFull.length > 80) 
    {
        for (var i = max_length; i > 0; i--) {
            var t = descShort.substring(i - 1, i);
            if (t == " ") break;
            descShort = descShort.substring(0, i - 1); //  + t;
        }
    }
    return descShort;
}
function IsValidAddress1(address1) {
    var filter = /^[a-zA-Z0-9-\/] ?([a-zA-Z0-9-\/]|[a-zA-Z0-9-\/] )*[a-zA-Z0-9-\/]$/;
    if (filter.test(address1)) {
        return true;
    }
    else {
        return false;
    }

}

function validateEmail(sEmail) {
    
    var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    if (filter.test(sEmail)){
    return true;
    }
    else{
    return false;
    }
};

function ReplaceSpecial(str) {
    var strRet = str;
    /*
                    strRet = strRet.Replace(" & ", "_");
                strRet = strRet.Replace("/", "#");
                strRet = strRet.Replace("'", "&#39;");
                */
    /*
    txtRet = txtRet.replace(" & ", "_");
    txtRet = txtRet.replace("/", "%2f");
    txtRet = txtRet.replace("'", "%27");
    */
    strRet = strRet.replace("&", "and");
    strRet = strRet.replace("/", "and");
    strRet = strRet.replace("Décor", "Decor");
    strRet = strRet.replace("'", "");
    strRet = strRet.replace(",", "");

    return strRet;
}
function escapeHtml(string) {
    return String(string).replace(/[&<>"'\/]/g, function fromEntityMap(s) {
        return entityMap[s];
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

function getExtraShoppingRewardPoint(price) {
    var iRewardPoint=0;
    if (price <= 25) {
        iRewardPoint = 100;
    } else if (price > 25 && price <= 50) {
        iRewardPoint = 200;
    } else if (price > 50 && price <= 100) {
        iRewardPoint = 300;
    } else if (price > 100 && price <= 200) {
        iRewardPoint = 400;
    } else if (price > 200 && price <= 300) {
        iRewardPoint = 500;
    } else if (price > 300 && price <= 400) {
        iRewardPoint = 600;
    } else if(price >400){
        iRewardPoint = 700;
    }
    var s = "Like this item?  If you purchase through this SPECIAL OFFER , you will earn BONUS " + iRewardPoint + " SHOPPING REWARD POINTS!";
    return s;

}

function CheckUserLogin() {

    var isUserLogin = false;

    // check if user is login or not\
    var _data = "{ action:'queryuserlogin'}";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/shareAjax.aspx',
        async: false,
        data: _data,
        dataType: "text",
        success: function (record) {
            //alert(record);
            if (record == "1") isUserLogin = true;
        }
    });
    return isUserLogin;
}


function timeSince(date) {

    if (typeof date !== 'object') {
        date = new Date(date);
    }

    var seconds = Math.floor((new Date() - date) / 1000);
    var intervalType;

    var interval = Math.floor(seconds / 31536000);
    if (interval >= 1) {
        intervalType = 'year';
    } else {
        interval = Math.floor(seconds / 2592000);
        if (interval >= 1) {
            intervalType = 'month';
        } else {
            interval = Math.floor(seconds / 86400);
            if (interval >= 1) {
                intervalType = 'day';
            } else {
                interval = Math.floor(seconds / 3600);
                if (interval >= 1) {
                    intervalType = "hour";
                } else {
                    interval = Math.floor(seconds / 60);
                    if (interval >= 1) {
                        intervalType = "minute";
                    } else {
                        interval = seconds;
                        intervalType = "second";
                    }
                }
            }
        }
    }
    if (interval < 0) interval = Math.abs(interval);
    if (interval > 1 || interval == 0) {
        intervalType += 's';
    }

    return interval + ' ' + intervalType;
}

/**
 * jQuery.browser.mobile (http://detectmobilebrowser.com/)
 * jQuery.browser.mobile will be true if the browser is a mobile device
 **/
 /*
(function(a){jQuery.browser.mobile=/android.+mobile|avantgo|bada/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)/|plucker|pocket|psp|symbian|treo|up.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(a)||/1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw-(n|u)|c55/|capi|ccwa|cdm-|cell|chtm|cldc|cmd-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc-s|devi|dica|dmob|do(c|p)o|ds(12|-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(-|_)|g1 u|g560|gene|gf-5|g-mo|go(.w|od)|gr(ad|un)|haie|hcit|hd-(m|p|t)|hei-|hi(pt|ta)|hp( i|ip)|hs-c|ht(c(-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i-(20|go|ma)|i230|iac( |-|/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |/)|klon|kpt |kwc-|kyo(c|k)|le(no|xi)|lg( g|/(k|l|u)|50|54|e-|e/|-[a-w])|libw|lynx|m1-w|m3ga|m50/|ma(te|ui|xo)|mc(01|21|ca)|m-cr|me(di|rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|-([1-8]|c))|phil|pire|pl(ay|uc)|pn-2|po(ck|rt|se)|prox|psio|pt-g|qa-a|qc(07|12|21|32|60|-[2-7]|i-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55/|sa(ge|ma|mm|ms|ny|va)|sc(01|h-|oo|p-)|sdk/|se(c(-|0|1)|47|mc|nd|ri)|sgh-|shar|sie(-|m)|sk-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h-|v-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl-|tdg-|tel(i|m)|tim-|t-mo|to(pl|sh)|ts(70|m-|m3|m5)|tx-9|up(.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|xda(-|2|g)|yas-|your|zeto|zte-/i.test(a.substr(0,4))})(navigator.userAgent||navigator.vendor||window.opera);
*/


function IsDate(s) {
    // MM/dd/yyyy format
    if (s.length != 10) return false;
    if (s.substring(2, 3) != "/" || s.substring(5, 6) != "/") return false;
    var sMM = s.substring(0, 2);
    var sDD = s.substring(3, 5);
    var sYYYY = s.substring(6, 10);
    if (!IsNumber(sMM) || !IsNumber(sDD) || !IsNumber(sYYYY)) return false;
    var dMM = parseInt(sMM);
    var dDD = parseInt(sDD);
    var dYYYY = parseInt(sYYYY);
    var d = new Date(dYYYY, dMM - 1, dDD);
    if (d.getFullYear() != dYYYY || d.getMonth() != dMM - 1 || d.getDate() != dDD) return false;
    return true;
}

function IsNumber(s) {
    if (s.length == 0) return false;
    for (var i = 0; i < s.length; i++) {
        var c = s.substring(i, i + 1);
        if (c < "0" || c > "9") return false;
    }
    return true;
}

function ShowPopupDialogMessage(title, message) {
    $("#labPopupTitle").html(title);
    $("#labPopupMessage").html(message);
    $("#divPopupMessageDialog").modal("show");
}
function AlertEx(message) {
    $("#labPopupTitle").html("Earn Play Shop --Tweebaa.com");
    $("#labPopupMessage").html(message);
    $("#divPopupMessageDialog").modal("show");
}