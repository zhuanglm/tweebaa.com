﻿var prdID = "";
var publishuserGuid = "";//该产品的发布者id
var picPath = "http://itweebaa.com/";  //https://tweebaa.com/
  var iPageDiv = 20;


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
        url: "/AjaxPages/pwdAjax.aspx",
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
        url: "/AjaxPages/pwdAjax.aspx",
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
            var a = pics[0];
            if (a.indexOf("upload/") == -1) {
                //a = "upload/" + a;
                picPath = picPath + "upload/";
            }
            var picFullName = picPath + pics[0];

            //alert(baseInfo.pics);
            $("#midimg").attr("src", picPath + pics[0].replace("big", "mid"));
            $("#bigShowImg").attr("src", picPath + pics[0]);
            for (i = 0; i < pics.length; i++) {

                $("#imgBig" + (i + 1)).attr("src", picPath + pics[i]);
                $("#imgBig" + (i + 1)).attr("data-src", picPath + pics[i]);
                $("#imgSmall" + (i + 1)).attr("src", picPath + pics[i].replace("big", "mid"));
            }
            for (var j = 5; j >= pics.length + 1; j--) {
                $("#imgSmall" + j).hide();
            }
            LoadReviewInfo(1, 10);      //加载产品的评审信息 
            $("#htrfShare").bind("click", function () {
                SharePrdEx(prdID, baseInfo.name, pics[0], "submitReview.aspx", baseInfo.txtjj,escapeHtml(baseInfo.txtjj));
            })
            $("#htrfMySubplay").bind("click", function () {
                window.location.href = "../Home/Index.aspx?page=homeSupply&id=" + baseInfo.userID;
            })

            $("#hrefShare1").bind("click", function () {
                SharePrdEx(prdID, baseInfo.name, picFullName, "submitReview.aspx", baseInfo.txtjj,escapeHtml(baseInfo.txtjj));
            })
            var strtxt = "";
            try {
                strtxt = decodeURIComponent(baseInfo.txtinfo);
            } catch (e) {
                strtxt = baseInfo.txtinfo;
            }

            strtxt = strtxt.replace(/\+/g, " ");

            if (baseInfo.isUseTemp == 0) {
                /*
                if (baseInfo.videoUrl != null && baseInfo.videoUrl != "") {
                    if (baseInfo.videoUrl.toUpperCase().indexOf("HTTP") != -1 || baseInfo.videoUrl.toUpperCase().indexOf("WWW") != -1) {

                    }
                    else {

                    }
                }
                else {
                    $("#linkWatchVideo").hide();
                    $("#videoFrame").hide();
                    $("#CuPlayer").hide();
                }*/
                if (baseInfo.videoEmbed != null && baseInfo.videoEmbed != "") {
                    // added by jack cao for embed video like youtube
                    //$("#CuPlayer").html(baseInfo.videoEmbed);
                    //$("#divResponsiveVideo").html(baseInfo.videoEmbed); //change by Long 2016/01/6
                }
                else if (baseInfo.videoUrl != null && baseInfo.videoUrl != "") {
                    //  LoadVideo(picPath + baseInfo.videoUrl);
                }
                else {
                    $("#linkWatchVideo").hide();
                    $("#CuPlayer").hide();
                    $("#divVideo").hide();
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

            MasterSliderShowcase2.initMasterSliderShowcase2();

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

$(document).ready(function () {
    //加载产品信息

    LoadPrd();
});


   

 

//加载视频
function LoadVideo(videoPath) {
    var so = new SWFObject("../css/PlayerLite.swf", "CuPlayerV4", "560", "410", "9", "#000000");
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
    var so = new SWFObject("../css/PlayerLite.swf", "CuPlayerV4", "560", "410", "9", "#000000");
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
        url: "/AjaxPages/prdReviewAjax.aspx",
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
        url: "/AjaxPages/prdReviewAjax.aspx",
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

    if (document.getElementById("ckb1").checked == false && document.getElementById("ckb2").checked == false) { 
         $("#ckb12Error").show();
    }
    else {
        $("#ckb12Error").hide();
    }

    if (document.getElementById("ckb3").checked == false && document.getElementById("ckb4").checked == false) {
        $("#ckb34Error").show();
    }
    else {
        $("#ckb34Error").hide();
    }

    if (document.getElementById("ckb5").checked == false && document.getElementById("ckb6").checked == false) {
        $("#ckb56Error").show();
    }
    else {
        $("#ckb56Error").hide();
    }

    if (document.getElementById("ckb7").checked == false && document.getElementById("ckb8").checked == false) {
        $("#ckb78Error").show();
    }
    else {
        $("#ckb78Error").hide();
    }

    /*
    if ($('.chklist1').find(':checked').length != 1) { $('.chklist1').siblings("strong").show();  }
    else{ $('.chklist1').siblings("strong").hide(); }
    if ($('.chklist2').find(':checked').length != 1) { $('.chklist2').siblings("strong").show();  }
    else{  $('.chklist2').siblings("strong").hide(); }
    if ($('.chklist3').find(':checked').length != 1) { $('.chklist3').siblings("strong").show();  }
    else { $('.chklist3').siblings("strong").hide(); }
    if ($('.chklist4').find(':checked').length != 1) { $('.chklist4').siblings("strong").show(); }
    else { $('.chklist4').siblings("strong").hide(); }
    */

    if ($("#reason-case").val() == "") { $("#msgError").show(); }
    else { $("#msgError").hide(); }


    //if ($('.chklist1').find(':checked').length == 1 && $('.chklist2').find(':checked').length == 1 && $("#reason-case").val() != "" ) {
    // evaluater need to answer all questions and enter the reasons.
    if ( (document.getElementById("ckb1").checked || document.getElementById("ckb2").checked) &&
         (document.getElementById("ckb3").checked || document.getElementById("ckb4").checked) &&
         (document.getElementById("ckb5").checked || document.getElementById("ckb6").checked) &&
         (document.getElementById("ckb7").checked || document.getElementById("ckb8").checked) &&
         $("#reason-case").val() != "") {
      
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
        var verify = $("#txtVerify").val();
        //alert(verify);
        $.ajax({
            type: "Post",
            url: "/AjaxPages/prdReviewAjax.aspx",
            data: "{'action':'add','id':'" + prdID + "','verify':'" + verify + "','content':'" + escape(content) + "','cmdtype':'" + escape(cmdtype) + "','publishUser':'" + publishuserGuid + "'}",
            success: function (resu) {
                $(this).siblings("strong").hide();
                if (resu == "-2") {
                    alert("Sorry about that ~ you need to be logged in to your account before you can submit your Evaluation. Please log-in to continue.");
                    var proid = $("#hid_proid").val();
                    if (proid != "") {
                        window.location.href = "../User/login.aspx?op=submitreview&id=" + proid;
                    }
                }
                else if (resu == "-3") {
                    alert("Please enter the correct verification code!");
                    $("#txtVerify").focus();
                }
                else if (resu == "-1") {
                    alert("Each user can only review once");
                }
                else if (resu == "0") {
                    alert("Failed to review！");
                }
                else if (resu == "1") {
                    DoEvaluateSuccess();
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
/*
function SharePrdEx(id, name, img, page, desc) {

    if (SetShareLink(id, name, img, page, desc, 0.0) == true) {
        $("#share-tck2").parents(".greybox").show();
        $("#share-tck2").animate({ top: "2%" }, 300);
    }

}*/
function SharePrdEx(id, name, img, page, share_point_text,product_short_desc) {

    if (SetShareLink(id, name, img, page, share_point_text, product_short_desc) == true) {
        $("#share-tck2").parents(".greybox").show();
        $("#share-tck2").animate({ top: "2%" }, 300);
    }
}

//暂时屏蔽（临时功能）
function Delete() {
    $.ajax({
        type: "Post",
        url: "/AjaxPages/prdReviewAjax.aspx",
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


function DoClear() {
    $("#reason-case").val("");
    document.getElementById("ckb1").checked = false;
    document.getElementById("ckb2").checked = false;
    document.getElementById("ckb3").checked = false;
    document.getElementById("ckb4").checked = false;
    document.getElementById("ckb5").checked = false; 
    document.getElementById("ckb6").checked = false; 
    document.getElementById("ckb7").checked = false;
    document.getElementById("ckb8").checked = false;
    $("#txtVerify").val("");
    $("#ckb12Error").hide();
    $("#ckb34Error").hide();
    $("#ckb56Error").hide();
    $("#ckb78Error").hide();
    $("#msgError").hide();
}


function DoMsgKeyup() {
    if ($("#reason-case").val().length > 0) {
        $("#msgError").hide();
    }
}

        function LoadCommentsTotal() {
            var PrdID = $("#hid_proid").val();
            $.ajax({
                type: "POST",
                url: "/AjaxPages/prdReviewAjax.aspx",
                data: "{ 'action':'" + "load_comment_total"
                + "','PrdGuid':'" + PrdID
                + "'}"
            }).done(function (result) {
                
                var ss=result.split(":");
                var stotal = ss[0];
                var TotalRate = ss[1];
                var Ranking =0;
                if(stotal>0){
                  Ranking= Math.floor(TotalRate / stotal);
                }
                /////////////////////
                //show ranking
                /*
                var htmlRanking="";
                for(kk=0; kk<Ranking;kk++){
                    htmlRanking+='<li><i class="rating-selected fa fa-star"></i></li>';
                }
                if(Ranking < 5){
                    for(kk=Ranking;kk<5;kk++){
                        htmlRanking+='<li><i class="rating fa fa-star"></i></li>'; 
                    }
                }
                if(stotal > 0){
                    htmlRanking+='<li style="padding-left:20px;padding-right:20px;"><a href="javascript:void(0)" onclick="Jump2Reviews()">Total Reviews: '+stotal+'</a></li>';
                }*/
                //$("#ulRating").html(htmlRanking);
                //console.log("total=" + stotal);
                var iTotal = Math.ceil(stotal / iPageDiv);
                //make pages
                var i = 0; var html = '<a href="#" class="up">&lt;</a>';

                for (i = 1; i <= iTotal; i++) {
                    if (i == 1) {
                        html += '<a href="#" id="CN_' + i + '" class="on" onclick="CommentPageNavigate(' + i + ')" >' + i + '</a>';
                    } else {

                        html += '<a href="#" id="CN_' + i + '" onclick="CommentPageNavigate(' + i + ')">' + i + '</a>';
                    }
                }
                html += '<a href="#" class="down">&gt;</a>';
                if (iTotal > 0) {
                    $("#CommentsPage").html(html);
                    LoadComments(1);
                }
                $("#comment_count").html(stotal);
                //load first page
                

            });
        }

        function CommentPageNavigate(iPage) {
            $("#CN_" + iPrevPageMyDraft).removeClass("on");
            LoadComments(iPage);
            $("#CN_" + iPage).addClass("on");
            iPrevPageMyDraft = iPage;
        }
        function LoadComments(iPage) {
            var PrdID = $("#hid_proid").val();
            $.ajax({
                type: "POST",
                url: "/AjaxPages/prdReviewAjax.aspx",
                data: "{'action':'" + "load_Comments_By_Page"
                + "','PrdGuid':'" + PrdID
                + "','page':'" + iPage
                + "','pageDiv':'" + iPageDiv
                + "'}",
            }).done(function (resu) {
                var html = "";
                if (resu == "0" || resu == "") {
                    return;
                }
                var obj = eval("(" + resu + ")");
                for (var i = 0; i < obj.length; i++) {
                    var comments = obj[i];


                    //var sID = $(this).find('ID').text();
                    var comments_text = comments.cmdtxt;//').text();
                    var user_name = comments.username;
                    var CreateTime = comments.AddDate;
                   // var Rating = comments.Rates;
                    // var timesince = timeSince(CreateTime);
/*
                    html += '<div class="product-comment-dtl">';
                    html += '<h4>' + user_name + '<small>' + CreateTime + '</small></h4>';
                    html += '<p>' + comments_text + '</p>';

                    html += '</div>';
*/

                     html += '<div class="product-comment-in">';
                     html += '<div class="product-comment-dtl">';
                     html += '<h4>'+user_name+' <small>'+CreateTime+'</small></h4>';
                     html += '<p>'+comments_text+'</p>';
                     /*
                     html += '<ul class="list-inline product-ratings">';
                     html += '<li class="pull-right">';
                     html += '<ul class="list-inline">';
                     for(k=0;k<Rating;k++){
                         html += '<li><i class="rating-selected fa fa-star"></i></li>';
                     }
                     if(Rating <5){
                       for(k=Rating;k<5;k++){
                         html += '<li><i class="rating fa fa-star"></i></li>';
                        }
                     }

                     html += '</ul>';
                     html += '</li>';   
                     html += '</ul>';*/
                     html += '</div>';
                     html += '</div>';    
                    //console.log("html=" + html);
                }
                $("#ulCommentsList").html(html);
            });

        }