
/* 
power by luChangHan 2012-12-05
*/
function request(paras) {
    if (typeof (paras) == "undefined") {
        return "";
    }
    var url = location.href;
    var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
    var paraObj = {}
    for (i = 0; j = paraString[i]; i++) {
        paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
    }
    var returnValue = paraObj[paras.toLowerCase()];
    if (typeof (returnValue) == "undefined") {
        return "";
    } else {
        return returnValue;
    }
}

function openwindow(url, name, iWidth, iHeight) {
    var url; //转向网页的地址;
    var name; //网页名称，可为空;
    var iWidth; //弹出窗口的宽度;
    var iHeight; //弹出窗口的高度;
    var iTop = (window.screen.availHeight - 30 - iHeight) / 2; //获得窗口的垂直位置;
    var iLeft = (window.screen.availWidth - 10 - iWidth) / 2; //获得窗口的水平位置;
    window.open(url, name, 'height=' + iHeight + ',,innerHeight=' + iHeight + ',width=' + iWidth + ',innerWidth=' + iWidth + ',top=' + iTop + ',left=' + iLeft + ',toolbar=no,menubar=no,scrollbars=yes,resizeable=no,location=no,status=no');
}

/*全选*/
function chkAll(obj) {
    $("input[name='chk_list']").each(function () {
        $(this).prop("checked", obj.checked);
    });
}
/*读取选中的check*/
function getChks() {
    var strChks = "1";
    $("input[name='chk_list']").each(function () {
        if ($(this).prop("checked")) {
            // alert($(this).val());
            strChks = strChks + ",'" + $(this).val() + "'";
        }
    });
    return strChks;
}
var chars = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
function generateMixed(n) {
    var res = "";
    for (var i = 0; i < n; i++) {
        var id = Math.ceil(Math.random() * 35);
        res += chars[id];
    }
    return res;
}

var st;
function countDown(secs, secsWord, txt, id, callback) {
    //退出成功,20秒后自动转到首页 
    clearTimeout(st);
    var jumpTo = $(id);
    jumpTo.html(txt + "(<font>" + secs + '</font> ' + secsWord + ')');
    if (--secs > 0) {
        st = window.setTimeout("countDown(" + secs + ",'" + secsWord + "','" + txt + "','" + id + "'," + callback + ")", 1000);
    }
    else {
        callback();
    }
}



//1.$(function(){     
//2.        document.onkeydown = function(e){      
//3.            var ev = document.all ? window.event : e;     
//4.            if(ev.keyCode==13) {   
//5.                var dis = document.getElementById("complexSearch").style.display;                              
//6.                if("none"==dis){   
//7.                    /*高级搜索不显示*/  
//8.                    simpleSearch();   
//9.                }else if("block" == dis){   
//10.                    /*高级搜索显示*/  
//11.                    complexSearch();       
//12.                }                                            
//13.             }     
//14.        }   



function gotag2(objtag) {
    var objtop = $(objtag).offset().top;
    var scrolla = $(window).scrollTop();
    var cha = parseInt(objtop) + parseInt(100);
    var targetOffset = cha; //与上面的代码不同在与，只设置了滚动顶部为0而已。  
    $('html,body').animate(
               {
                   scrollTop: targetOffset
               }
               , 1000);
}