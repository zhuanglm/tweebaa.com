var prdID = "";
var publishuserGuid = "";//该产品的发布者id
var picPath = "https://tweebaa.com/";  //https://tweebaa.com/

function getPrdGuid(id) {

    // the prdID has two cases: 
    // normal case:  prdID = product Guid
    // share  case:  prdID = Product Guid + "_" + share Guid
    var iPos = prdID.indexOf('_');
    var prdGuid = prdID;
    if (iPos != -1) {
        prdGuid = prdID.substring(0, iPos);
    }
    return prdGuid;
}

$(document).ready(
//加载产品信息
function LoadPrd() {
    var Request = new Object();
    Request = GetRequest();
    prdID = Request["id"];
    if (prdID == null || prdID == "") {
        return;
    }

    // the prdID has two cases: 
    // normal case:  prdID = product Guid
    // share  case:  prdID = Product Guid + "_" + share Guid
    var prdGuid = getPrdGuid(prdID);

    // check if the user view the progress and the commemts
    // only need to pass the Product Guid 
    var bAllowToViewCommentAndProgress = false;
    $.ajax({
        type: "Post",
        url: "../../AjaxPages/pwdAjax.aspx",
        async: false,
        data: "{'action':'queryViewPreviewComment','id':'" + prdGuid + "'}",
        success: function (resu) {
            if (resu == "1") {
                bAllowToViewCommentAndProgress = true;
            }
        },
        error: function (obj) {
            alert(resu + "Load failed");
        }
    });

    // load product review info
    $.ajax({
        type: "Post",
        url: "../../AjaxPages/pwdAjax.aspx",
        data: "{'action':'review','id':'" + prdID + "'}",
        success: function (resu) {
            //var obj = eval("(" + resu + ")");
            //var baseInfo = obj.baseInfo[0];
            var baseInfo = eval("(" + resu + ")");
            publishuserGuid = baseInfo.userGuid;
            $("#labCateTile").html(baseInfo.catename);
            $("#pro-name").html(baseInfo.name); //产品名称 
            $("#pro-user").html(baseInfo.userName); //发布者

            var proWidth = $("#pro-name").width();
            if (proWidth > 510) {
                $("#pro-name").css("font-size", "20");
            }
            if (proWidth > 530) {
                $("#pro-name").css("font-size", "19");
            }

            var _usaTime = "";
            if (baseInfo.addtime != null && baseInfo.addtime.length > 0) {
                var i = baseInfo.addtime.indexOf("T");
                var usaFormat = baseInfo.addtime.substring(0, i);
                var usaArray = usaFormat.split('-');
                var _year = usaArray[0];
                var _month = usaArray[1];
                var _day = usaArray[2];
                _usaTime = _month + "/" + _day + "/" + _year;
            }
            $("#pro-time").html(_usaTime); //发布时间

            var txtBriefDesc = baseInfo.txtjj.replace(/[\n\r]/g, "<br/>");
            $("#pro-jl").html(txtBriefDesc); //卖点特色

            // convert to stand format of ####.## 
            var estimateprice = parseFloat(baseInfo.estimateprice);
            baseInfo.estimateprice = estimateprice.toFixed(2);

            $("#pro-price").html(baseInfo.estimateprice); //建议零售价             
            var pics = new Array(); //定义一数组 
            pics = baseInfo.pics.split(","); ////产品图片  

            // set the full path name of the picture
            var picFullName = picPath + pics[0];

            //alert(baseInfo.pics);
            $("#midimg").attr("src", picPath + pics[0].replace("big", "mid"));
            $("#bigShowImg").attr("src", picPath + pics[0]);
            for (i = 0; i < pics.length; i++) {
                $("#imgSmall" + (i + 1)).attr("src", picPath + pics[i].replace("big", "small"));
            }
            for (var j = 5; j >= pics.length + 1; j--) {
                $("#imgSmall" + j).hide();
            }
            LoadReviewInfo(1, 10);      //加载产品的评审信息 
            $("#htrfShare").bind("click", function () {
                SharePrd(prdID, baseInfo.name, pics[0], "submitReview.aspx", baseInfo.txtjj);
            })
            $("#htrfMySubplay").bind("click", function () {
                window.location.href = "../Home/Index.aspx?page=homeSupply&id=" + baseInfo.userID;
            })

            $("#hrefShare1").bind("click", function () {
                SharePrd(prdID, baseInfo.name, picFullName, "submitReview.aspx", baseInfo.txtjj);
            })
            var strtxt = "";
            try {
                strtxt = decodeURIComponent(baseInfo.txtinfo);
            } catch (e) {
                strtxt = baseInfo.txtinfo;
            }

            strtxt = strtxt.replace(/\+/g, " ");

            if (baseInfo.isUseTemp == 0) {
                if (baseInfo.videoUrl != null && baseInfo.videoUrl != "") {
                    if (baseInfo.videoUrl.toUpperCase().indexOf("HTTP") != -1 || baseInfo.videoUrl.toUpperCase().indexOf("WWW") != -1) {
                        $("#videoFrame").attr("src", unescape(baseInfo.videoUrl)); //  外部视频地址
                        $("#CuPlayer").hide();
                    }
                    else {
                        $("#videoFrame").hide();
                        LoadVideo(picPath + baseInfo.videoUrl);
                    }
                }
                else {
                    $("#videoFrame").hide();
                    $("#CuPlayer").hide();
                }
                $("#pro-info").html(strtxt);
            }

            if (baseInfo.isUseTemp == 1) {
                $(".itembox").html(strtxt);  
                if (baseInfo.videoUrl != null && baseInfo.videoUrl != "") {
                    if (baseInfo.videoUrl.toUpperCase().indexOf("HTTP") != -1 || baseInfo.videoUrl.toUpperCase().indexOf("WWW") != -1) {
                        $("#videoFrame2").attr("src", unescape(baseInfo.videoUrl)); //  外部视频地址
                        $("#CuPlayer2").hide();
                    }
                    else {
                        $("#videoFrame2").hide();
                        LoadVideo2(picPath + baseInfo.videoUrl);
                    }

                }
                else {
                    $("#h4Video").hide();
                }

            }

            // hide or show the comment and progress bar
            var disp = "none";
            if (bAllowToViewCommentAndProgress) {
                disp = "inline";
            }
            $("#hrfComments").css("display", disp);
            $("#reviewProgress").css("display", disp);
            $("#lblCurrentStatus").css("display", disp);

        },
        error: function (obj) {
            alert("Load failed");
        }
    });
    var reviewe = Request["reviewe"];
    if (reviewe == "all") {
        $('#hrfComments').click();
    }
}
);


   

 

//加载视频
function LoadVideo(videoPath) {
    var so = new SWFObject("../Css/PlayerLite.swf", "CuPlayerV4", "560", "410", "9", "#000000");
    so.addParam("allowfullscreen", "true");
    so.addParam("allowscriptaccess", "always");
    so.addParam("wmode", "opaque");
    so.addParam("quality", "high");
    so.addParam("salign", "lt");
    so.addVariable("videoDefault", videoPath); //视频文件地址
    so.addVariable("autoHide", "true");
    so.addVariable("hideType", "fade");
    so.addVariable("autoStart", "false");
    so.addVariable("holdImage", "start.jpg");
    so.addVariable("startVol", "60");
    so.addVariable("hideDelay", "60");
    so.addVariable("bgAlpha", "75");
    so.write("CuPlayer");
}
function LoadVideo2(videoPath) {
    var so = new SWFObject("../Css/PlayerLite.swf", "CuPlayerV4", "560", "410", "9", "#000000");
    so.addParam("allowfullscreen", "true");
    so.addParam("allowscriptaccess", "always");
    so.addParam("wmode", "opaque");
    so.addParam("quality", "high");
    so.addParam("salign", "lt");
    so.addVariable("videoDefault", videoPath); //视频文件地址
    so.addVariable("autoHide", "true");
    so.addVariable("hideType", "fade");
    so.addVariable("autoStart", "false");
    so.addVariable("holdImage", "start.jpg");
    so.addVariable("startVol", "60");
    so.addVariable("hideDelay", "60");
    so.addVariable("bgAlpha", "75");
    so.write("CuPlayer2");
}



//加载评审信息 
function LoadReviewInfo(startIndex,endIndex) {
    var ul = $(".pinglun-list");
    $.ajax({
        type: "Post",
        url: "../../AjaxPages/prdReviewAjax.aspx",
        data: "{'action':'query','id':'" + prdID + "','startIndex':'" + startIndex + "','endIndex':'" + endIndex + "'}",
        success: function (resu) {
            if (resu == "") {
                return;
            }
            ul.html("");
            var obj = eval("(" + resu + ")"); //转换为json对象
            var reviewCount = obj.length;
            for (var i = 0; i < obj.length; i++) {
                var li = document.createElement("li");
                var imgName = "../Images/level/evaluate-lv_" + obj[i].reviewgrade.toString() + ".gif";
                var strHtml = "<span class='fr time'>" + obj[i].edttime.replace("T", " ") + "</span><span class='fr people'><a href='javascript:void(0);' class='vip-lv vip-lv5'>" + obj[i].username + "</a>&nbsp;<img src='" + imgName +"'></img></span> <p class='fl'>" + obj[i].cmdtxt + "</p>";
                li.innerHTML = strHtml;
                ul.append(li);
            }
        },
        error: function (resu) {

        }
    });
}


//function check1() {
//    alert("111");
//    //$('#ckb4').removeAttr('checked');
//    $("#ckb2 input").removeAttr("checked");

//}

//发表评审
function SubmitReview() {
    if (prdID == "" || prdID == null) {
        return;
    }

    // get user login status

    var isLogin = true;

    $.ajax({
        type: "Post",
        url: "../../AjaxPages/prdReviewAjax.aspx",
        data: "{'action':'queryLogin'}",
        async: false,
        success: function (resu) {
            $(this).siblings("strong").hide();
            if (resu != "1") {
                isLogin = false;
                alert("Sorry about that ~ you need to be logged in to your account before you can submit your Evaluation. Please log-in to continue.");
                var proid = $("#hid_proid").val();
                if (proid != "") {
                    window.location.href = "../User/login.aspx?op=submitreview&id=" + proid;
                }
            }
        },
        error: function (resu) {
            alert("Failed to query login status！");
        }
    });

    // do not check if it is not login
    if (!isLogin ) return;

    if ($('.chklist1').find(':checked').length != 1) { $('.chklist1').siblings("strong").show();  }
    else{ $('.chklist1').siblings("strong").hide(); }
    if ($('.chklist2').find(':checked').length != 1) { $('.chklist2').siblings("strong").show();  }
    else{  $('.chklist2').siblings("strong").hide(); }
    if ($('.chklist3').find(':checked').length != 1) { $('.chklist3').siblings("strong").show();  }
    else { $('.chklist3').siblings("strong").hide(); }
    if ($('.chklist4').find(':checked').length != 1) { $('.chklist4').siblings("strong").show(); }
    else { $('.chklist4').siblings("strong").hide(); }
    if ($("#reason-case").val() == "") { $("#reason-case").siblings("strong").show(); }
    else {$("#reason-case").siblings("strong").hide(); }
    if ($('.chklist1').find(':checked').length == 1 && $('.chklist2').find(':checked').length == 1 && $("#reason-case").val() != "" ) {
      
        var content = $("#reason-case").val();      
        var cmdtype = "";
        if (document.getElementById("ckb1").checked) { cmdtype += ",1"; }
        if (document.getElementById("ckb2").checked) { cmdtype += ",2"; }
        if (document.getElementById("ckb3").checked) { cmdtype += ",3"; }
        if (document.getElementById("ckb4").checked) { cmdtype += ",4"; }
        if (document.getElementById("ckb5").checked) { cmdtype += ",5"; }
        if (document.getElementById("ckb6").checked) { cmdtype += ",6"; }
        if (document.getElementById("ckb7").checked) { cmdtype += ",7"; }
        if (document.getElementById("ckb8").checked) { cmdtype += ",8"; }
        cmdtype = cmdtype.replace(",", "");
        $.ajax({
            type: "Post",
            url: "../../AjaxPages/prdReviewAjax.aspx",
            data: "{'action':'add','id':'" + prdID + "','content':'" + escape(content) + "','cmdtype':'" + escape(cmdtype) + "','publishUser':'" + publishuserGuid + "'}",
            success: function (resu) {
                $(this).siblings("strong").hide();
                if (resu == "-2") {
                    alert("Sorry about that ~ you need to be logged in to your account before you can submit your Evaluation. Please log-in to continue.");
                    var proid = $("#hid_proid").val();
                    if (proid != "") {
                        window.location.href = "../User/login.aspx?op=submitreview&id=" + proid;
                    }
                }
                else if (resu == "-1") {
                    alert("Each user can only review once！");
                }
                else if (resu == "0") {
                    alert("Failed to review！");
                }
                else if (resu == "1") {
                    fubuFun($("#ps-ok"), "../Home/HomeReview.aspx");
                    //LoadReviewInfo();
                }
            },
            error: function (resu) {
                alert("Failed to review！");
            }
        });
    };
}

//分享动作
function SharePrd(id, name, img, page, desc) {

    if (SetShareLink(id, name, img, page, desc, 0.0) == true) {
        $("#share-tck2").parents(".greybox").show();
        $("#share-tck2").animate({ top: "2%" }, 300);
    }

}

//暂时屏蔽（临时功能）
function Delete() {
    $.ajax({
        type: "Post",
        url: "../../AjaxPages/prdReviewAjax.aspx",
        data: "{'action':'delete','id':'" + prdID + "'}",
        success: function (resu) {
            if (resu == "1") {
                alert("删除成功！");
            }
            else {
                alert("删除失败！");
            }
        },
        error: function (resu) {
            alert("删除失败！");
        }
    });
}