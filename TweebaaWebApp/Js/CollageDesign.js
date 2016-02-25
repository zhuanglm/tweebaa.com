﻿
var iv1;
var iv2;
var iv3;
var iv4;
var iv5;
var iv6;
var iv7;
var iv8;

/*
var iTotalProducts = 0;
var iTotalFailedProduct = 0;
*/

var page = 1; //页码
var orderby = ""; //排序条件
var picPath = "/images801/";
var picProductPath = "https://tweebaa.com/";
var picDesignImgPath = "http://www.tweebaa.com/images801"

var templatePath = "http://www.tweebaa.com/Collage/TempImg/";
var backgroundPath = "/Collage/DesignBackgroundImg/";
var DecorationPath = "/Collage/DesignDecorationImg/";

var prdName = "";
var cate = "";
var state = "";
var step = "";
var pageDiv = 20;
var myDraftPageDiv = 8;
// get/show paging data list
var focusCateIDs = [];
var iTotalPage;
var iPrevPage = 1;
var iCurrentDiv;
var iCurrentZoom = 50;
var iPrevPageBG = 1;
var iPrevPageDe = 1;
var iPrevPageMyPublish = 1;
var iPrevPageMyDraft = 1;
var iPrevPageTemplate = 1;

var iSrcLoaded1 = 0;
var iSrcLoaded2 = 0;
var iSrcLoaded3 = 0;
var iSrcLoaded4 = 0;

var iSrcLoaded5 = 0;
var iSrcLoaded6 = 0;
var iSrcLoaded7 = 0;
var iSrcLoaded8 = 0;

/*
function IsThisProductAvailable(status) {
    if (status == 2 || status == 3 || status == 6) {
        return 1;
    } else {
    return 0;
    }

}
*/

function CloseDraftPopup() {

    $("#Save2Draft").parents(".greybox").hide();
}
function FavoriteCollage(sDesignID) {

    var _data = "{ action:'" + 'add_collage_favorite' + "',id:'" + sDesignID + "'}";

    $.ajax({
        type: "POST",
        url: '../AjaxPages/FavoriteAjax.aspx',
        data: _data,
        dataType: "text",
        success: function (resu) {
            if (resu == "success") {
                alert("This item has been saved to your Favorites. To access, just log in to your account and select 'My Favorites'.");
                //                $("#labfav").html("Favorited successfully");              
                //                $("#tck5").parents(".greybox").show()
                //                $("#tck5").animate({ top: "2%" }, 300)
            }
            else if (resu == "-1") {
                alert("Please login");
                //                $("#labfav").html("Please log in!");
                //                $("#tck5").parents(".greybox").show()
                //                $("#tck5").animate({ top: "2%" }, 300)
            }
            else {
                alert("Failed to favorite");
                //                $("#labfav").html("Failed to favorite");
                //                $("#tck5").parents(".greybox").show()
                //                $("#tck5").animate({ top: "2%" }, 300)
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Failed to favorite");
        }
    });


}

function generatShareEn(type, link, title, image, desc, record) {
    var shareUrl = "";
    var facebookAppID = "1591110677840145";
    //var descNoCR = desc.replace(/[\n\r]/g, "<br/>");

    var parmRecord = "";
    if (record != "") parmRecord = "&record=" + record;  // record = "" means it is share without login
    if (type == "facebook") {
        // always share big product image
        image = image.replace("/mid/", "/big/");
        image = image.replace("/mid2/", "/big/");
        image = image.replace("/small/", "/big/");

        //shareUrl = "http://www.facebook.com/share.php?url=" + link + "&title=" + title + "&content=utf8&pic=" + image + parmRecord + "&isshare=true";
        shareUrl = "https://www.facebook.com/dialog/feed?" +
                    "app_id=1591110677840145" +
                    "&display=page&caption=" + title +
                    "&link=" + link +
                    "&picture=" + image +
                    "&description=" + desc +
                    "&redirect_uri=http://www.tweebaa.com/CloseWindow.htm";
    }
    else if (type == "twitter") {
        shareUrl = "http://twitter.com/home/?status=" + link + "&title=" + title + "&pic=" + image + parmRecord + "&isshare=true";
    }
    else if (type == "google") {
        $("meta[property='og:title']").attr("content", escape(title));
        $("meta[property='og:image']").attr("content", escape(image));
        $("meta[property='og:description']").attr("content", escape(desc));
        shareUrl = "https://plus.google.com/share?url=" + link;
    }
    else if (type == "pinterest") {
        var newImageUrl = image.replace("https://tweebaa.com/UploadImg/", "http://www.tweebaa.com/images801/");
        shareUrl = "https://pinterest.com/pin/create/button/?url=" + link + "&description=" + title + " -- " + desc + "&media=" + escape(newImageUrl) + parmRecord + "&isshare=true";
    }
    //else if (type == "plurk") {
    //    shareUrl = "http://plurk.com/?qualifier=shares&status=" + link + "&title=" + title + "&pic=" + image + parmRecord + "&isshare=true";
    //}
    else if (type == "email") {
        shareUrl = "emailShare.aspx?id=" + link + "&name=" + title + "&img=" + escape(image);
        if (window.location.href.indexOf("/product/") == -1) {
            shareUrl = "../product/emailShare.aspx?link=" + link + "&name=" + title + "&img=" + escape(image) + "&desc=" + escape(desc);
        }
    }

    return shareUrl;
}

function CheckUserLogin() {

    var isUserLogin = false;
    // check if user is login or not\
    var _data = "{ action:'queryuserlogin'}";
    $.ajax({
        type: "POST",
        url: '../AjaxPages/shareAjax.aspx',
        async: false,
        data: _data,
        dataType: "text",
        success: function (record) {
            //alert(record);
            if (record == "1") isUserLogin = true;
        }
    });
    return isUserLogin;
    //jctest
    //return false;
}



function SaveCollageShareUrl2DB(type, prdid, prdname, prdimg, page, desc, isLogin, userGuid) {
    var shareUrl = "";
    var host = window.location.host;
    var title = encodeURIComponent(prdname);
    //var link = host + "/Product/" + page + "?id=" + prdid;
    var link = "http://www.tweebaa.com/Product/" + page + "?id=" + prdid;
    var image = prdimg;
    var _data = "{ action:'" + "share_collage"
                    + "',proid:'" + prdid
                    + "',url:'" + link
                    + "',isLogin:'" + isLogin
                    + "',userGuid:'" + userGuid
                    + "',type:'" + type + "'}";
    $.ajax({

        type: "POST",
        url: 'CollageShareHandler.ashx',
        data: _data,
        async: false,
        dataType: "text",
        success: function (record) {
            if (record == null)
                return;

            // It is a share without login if the reponse (record) is empty,
            //var link = host + "/Product/preSaleBuy.aspx?id=" + prdid + "_" + record;
            if (record != "") link = host + "/Product/" + page + "?design_id=" + prdid + "_" + record;
            else link = host + "/Product/" + page + "?design_id=" + prdid;
            //alert(link);
            shareUrl = generatShareEn(type, link, title, image, desc, record); //这个record是分享ID
        }
    });
    return shareUrl;
}
//分享接口
//sID, sTitle, sImage, urlPage, sInspiration,isLogin,userid
function GetCollageShareUrl(type, prdid, prdname, prdimg, page, desc, isLogin, userGuid) {
var shareUrl="";
if (type == "facebook") {
    $("#shareToFacebook").click(function () {
        shareUrl = SaveCollageShareUrl2DB(type, prdid, prdname, prdimg, page, desc, isLogin, userGuid);
        Log4Debug(shareUrl);
        window.location.href = shareUrl;
    });
}
if (type == "twitter") {
    $("#shareToTwitter").click(function(){
        shareUrl = SaveCollageShareUrl2DB(type, prdid, prdname, prdimg, page, desc, isLogin, userGuid);
        window.location.href = shareUrl;
    });
}
if (type == "google") {
    $("#shareToGoogle").click(function(){
        shareUrl = SaveCollageShareUrl2DB(type, prdid, prdname, prdimg, page, desc, isLogin, userGuid);
        window.location.href = shareUrl;
    });
}
if (type == "pinterest") {
    $("#shareToPinterest").click(function(){
        shareUrl = SaveCollageShareUrl2DB(type, prdid, prdname, prdimg, page, desc, isLogin, userGuid);
        window.location.href = shareUrl;
    });
}
if (type == "email") {
    $("#shareToEmail").click(function(){
        shareUrl = SaveCollageShareUrl2DB(type, prdid, prdname, prdimg, page, desc, isLogin, userGuid);
        window.location.href = shareUrl;
       // Log4Debug(shareUrl);
    });
}
                        

/*
    var shareUrl = "";

    shareUrl = SaveCollageShareUrl2DB(type, prdid, prdname, prdimg, page, desc, isLogin, userGuid);

    var host = window.location.host;
    var title = encodeURIComponent(prdname);
    //var link = host + "/Product/" + page + "?id=" + prdid;
    var link = "http://www.tweebaa.com/Product/" + page + "?id=" + prdid;
    var image = prdimg;
    var _data = "{ action:'" + "share_collage"
                    + "',proid:'" + prdid
                    + "',url:'" + link
                    + "',isLogin:'" + isLogin
                    + "',userGuid:'" + userGuid
                    + "',type:'" + type + "'}";
    $.ajax({

        type: "POST",
        url: 'CollageShareHandler.ashx',
        data: _data,
        async: false,
        dataType: "text",
        success: function (record) {
            if (record == null)
                return;

            // It is a share without login if the reponse (record) is empty,
            //var link = host + "/Product/preSaleBuy.aspx?id=" + prdid + "_" + record;
            if (record != "") link = host + "/Product/" + page + "?id=" + prdid + "_" + record;
            else link = host + "/Product/" + page + "?id=" + prdid;
            //alert(link);
            shareUrl = generatShareEn(type, link, title, image, desc, record); //这个record是分享ID
        }
    });
    return shareUrl;
*/
}
function ShareCollage(sID, sTitle, sImage, urlPage, sInspiration) {
    //tip
    var tip = true;
    var userid = $("#hiduserid").val();
    var persent = $("#hidpersent").val();
    var isLogin="0"
    if (userid.length > 4) {
        isLogin = "1";
    }

    //alert(saleprice);
    //alert(persent);
    var saleprice = 0.01; // Need to update
    if (persent != "") {
        var getP = saleprice * persent;
        $("#sharePercent").html("$" + getP);
    } else {
        $("#sharePercent").html("$0");
    }


    //  SetCollageShareLink(txt_id, name, img, page, desc, prdPrice, isLogin, userid)
    if (SetCollageShareLink(sID, sTitle, sImage, urlPage, sInspiration,saleprice, isLogin, userid) == true) {
        $("#share-tck2").parents(".greybox").show();
        $("#share-tck2").animate({ top: "2%" }, 300);
    }

}

//分享接口
function UserLoginForShare(prdid) {

    var curUrl = window.location.href.toLowerCase();
    loginNow = false;
    if (CheckUserLogin() == false) {
        if (confirm("Thanks for sharing! Before you proceed, would you like to log in?\nYou can receive reward points and commission if you log in first.\n\n  Press [OK] to go to log in or register as a member.\n  Press [Cancel] to continue to share as a guest.")) {
            loginNow = true;
            if (curUrl.indexOf("prdsaleall") != -1) {
                window.location.href = "../user/login.aspx?op=prdSaleAll";
            } else if (curUrl.indexOf("prdsale") != -1) {
                window.location.href = "../user/login.aspx?op=prdSale";
            } else if (curUrl.indexOf("prdpresale") != -1) {
                window.location.href = "../user/login.aspx?op=prdPreSale";
            }
            else if (curUrl.indexOf("submitreview") != -1) {
                window.location.href = "../user/login.aspx?op=submitreview&id=" + prdid;
            }
            else if (curUrl.indexOf("presalebuy") != -1) {
                window.location.href = "../user/login.aspx?op=preSaleBuy&id=" + prdid;
            }
            else if (curUrl.indexOf("salebuy") != -1) {
                window.location.href = "../user/login.aspx?op=saleBuy&id=" + prdid;
            }
            else if (curUrl.indexOf("prdreviewall") != -1) {
                window.location.href = "../user/login.aspx?op=prdReviewAll";
            }
            else if (curUrl.indexOf("prdsingleshare") != -1) {
                window.location.href = "../user/login.aspx?op=prdSingleShare";
            }
            else if (curUrl.indexOf("/home/homesupply.aspx") != -1) {
                window.parent.location.href = "../user/login.aspx?op=homeSupply";
            }
            else if (curUrl.indexOf("/home/homecollection.aspx") != -1) {
                window.parent.location.href = "../user/login.aspx?op=homeCollection";
            }
            else if (curUrl.indexOf("/home/homeprofit.aspx") != -1) {
                window.parent.location.href = "../user/login.aspx?op=homeProfit";
            }
            else if (curUrl.indexOf("index.aspx") != -1) {
                window.location.href = "../user/login.aspx?op=index";
            }
            else {
                // cannot come here
                loginNow = fasle;
            }
        }
        else loginNow = false;
    }
    return loginNow;
}

//sID, sTitle, sImage, urlPage, sInspiration, isLogin, userid
function SetCollageShareLink(txt_id, name, img, page, desc, prdPrice, isLogin, userid) {
    var shareUrl = ""

    // when share from a shared link, the id contains two parts:
    // prdID and previous share ID
    // they are seperated by "_"

    var prdid = txt_id;
    var sID = txt_id.toString();
    var iPos = sID.indexOf("_");
    if (iPos != -1) {
        prdid = sID.substring(0, iPos);
    }

    var loginNow = UserLoginForShare(prdid);
    if (loginNow == true) return false;

    //type, prdid, prdname, prdimg, page, desc,isLogin,userGuid
    shareUrl = GetCollageShareUrl("facebook", prdid, name, img, page, desc, isLogin, userid);
    //$("#shareToFacebook").attr("href", shareUrl);

    shareUrl = GetCollageShareUrl("twitter", prdid, name, img, page, desc,isLogin, userid);
   // $("#shareToTwitter").attr("href", shareUrl);

    shareUrl = GetCollageShareUrl("google", prdid, name, img, page, desc, isLogin, userid);
   // $("#shareToGoogle").attr("href", shareUrl);

    shareUrl = GetCollageShareUrl("pinterest", prdid, name, img, page, desc, isLogin, userid);
   // $("#shareToPinterest").attr("href", shareUrl);

    shareUrl = GetCollageShareUrl("email", prdid, name, img, page, desc, isLogin, userid);
   // $("#shareToEmail").attr("href", shareUrl);

    return true;
}

function GetVirtualImgFolder(img_src) {

    return img_src.replace("UploadImg/", "");
}
function IsAllImgLoaded() {
    if (iSrcLoaded1 == 1 && iSrcLoaded2 == 1 && iSrcLoaded3 == 1 && iSrcLoaded4 == 1) return true;
    return false;
}
function LoadDesignData(sHtml) {
    iSrcLoaded1 = 0;
    iSrcLoaded2 = 0;
    iSrcLoaded3 = 0;
    iSrcLoaded4 = 0;
    iSrcLoaded5 = 0;
    iSrcLoaded6 = 0;
    iSrcLoaded7 = 0;
    iSrcLoaded8 = 0;

    var dataArray = sHtml.split('&');
    var src = dataArray[3].split("=");
    var viewer_x = dataArray[4].split("=");
    var viewer_y = dataArray[5].split("=");
    var viewer_w = dataArray[6].split("=");
    var viewer_h = dataArray[7].split("=");
    var src1 = decodeURIComponent(src[1]);

    var srcViewer2 = dataArray[8].split("=");
    var srcViewer3 = dataArray[13].split("=");
    var srcViewer4 = dataArray[18].split("=");
    
    if (src.length < 1) iSrcLoaded1 = 1;
    if (srcViewer2[1].length < 1) iSrcLoaded2 = 1;
    if (srcViewer3[1].length < 1) iSrcLoaded3 = 1;
    if (srcViewer4[1].length < 1) iSrcLoaded4 = 1;



    iv1 = $("#viewer").iviewer({
        src: src1,
        update_on_resize: false,
        zoom_animation: false,
        mousewheel: false,
        onMouseMove: function (ev, coords) { },
        onStartDrag: function (ev, coords) { return false; }, //this image will not be dragged
        onDrag: function (ev, coords) { },
        onFinishLoad: function (e) {
            iv1.iviewer("update_css", viewer_x[1], viewer_y[1], viewer_w[1], viewer_h[1]);
            iSrcLoaded1 = 1;
            if (IsAllImgLoaded()) {
                DoPopupSaveDialog();
            }
        }
    });

    
    viewer_x = dataArray[9].split("=");
    viewer_y = dataArray[10].split("=");
    viewer_w = dataArray[11].split("=");
    viewer_h = dataArray[12].split("=");
    src1 = decodeURIComponent(srcViewer2[1]);

    
    iv2 = $("#viewer2").iviewer({
        src: src1,
        update_on_resize: false,
        zoom_animation: false,
        mousewheel: false,
        onMouseMove: function (ev, coords) { },
        onStartDrag: function (ev, coords) { return false; }, //this image will not be dragged
        onDrag: function (ev, coords) { },
        onFinishLoad: function (e) {
            iv2.iviewer("update_css", viewer_x[1], viewer_y[1], viewer_w[1], viewer_h[1]);
            iSrcLoaded2 = 1;
            if (IsAllImgLoaded()) {
                DoPopupSaveDialog();
            }
        }
    });

    src = dataArray[13].split("=");
    viewer_x = dataArray[14].split("=");
    viewer_y = dataArray[15].split("=");
    viewer_w = dataArray[16].split("=");
    viewer_h = dataArray[17].split("=");
    src1 = decodeURIComponent(src[1]);

    if (src.length < 1) iSrcLoaded3 = 1;
    iv3 = $("#viewer3").iviewer({
        src: src1,
        update_on_resize: false,
        zoom_animation: false,
        mousewheel: false,
        onMouseMove: function (ev, coords) { },
        onStartDrag: function (ev, coords) { return false; }, //this image will not be dragged
        onDrag: function (ev, coords) { },
        onFinishLoad: function (e) {
            iv3.iviewer("update_css", viewer_x[1], viewer_y[1], viewer_w[1], viewer_h[1]);
            iSrcLoaded3 = 1;
            if (IsAllImgLoaded()) {
                DoPopupSaveDialog();
            }
        }
    });
    src = dataArray[18].split("=");
    viewer_x = dataArray[19].split("=");
    viewer_y = dataArray[20].split("=");
    viewer_w = dataArray[21].split("=");
    viewer_h = dataArray[22].split("=");
    src1 = decodeURIComponent(src[1]);


    var txtDesignID=dataArray[23].split("=");
    var txtProduct1ID=dataArray[24].split("=");
    var txtProduct2ID=dataArray[25].split("=");
    var txtProduct3ID=dataArray[26].split("=");
    var txtProduct4ID=dataArray[27].split("=");

    $("#txtDesignID").val(txtDesignID);
    $("#ProductID_1").val(txtProduct1ID);
    $("#ProductID_2").val(txtProduct2ID);
    $("#ProductID_3").val(txtProduct3ID);
    $("#ProductID_4").val(txtProduct4ID);

    var txtProduct5ID=dataArray[48].split("=");
    var txtProduct6ID=dataArray[49].split("=");
    var txtProduct7ID=dataArray[50].split("=");
    var txtProduct8ID=dataArray[51].split("=");
    $("#ProductID_5").val(txtProduct5ID);
    $("#ProductID_6").val(txtProduct6ID);
    $("#ProductID_7").val(txtProduct7ID);
    $("#ProductID_8").val(txtProduct8ID);

    iv4 = $("#viewer4").iviewer({
        src: src1,
        update_on_resize: false,
        zoom_animation: false,
        mousewheel: false,
        onMouseMove: function (ev, coords) { },
        onStartDrag: function (ev, coords) { return false; }, //this image will not be dragged
        onDrag: function (ev, coords) { },
        onFinishLoad: function (e) {
            iv4.iviewer("update_css", viewer_x[1], viewer_y[1], viewer_w[1], viewer_h[1]);
            iSrcLoaded4 = 1;
            if (IsAllImgLoaded()) {
                DoPopupSaveDialog();
            }
        }
    });

    //have 5 div
    if (dataArray.length >= 32) {
        var srcViewer5 = dataArray[28].split("=");
        if (srcViewer5[1].length < 1) iSrcLoaded5 = 1;
        //create this item
        src = dataArray[28].split("=");
        viewer_x = dataArray[29].split("=");
        viewer_y = dataArray[30].split("=");
        viewer_w = dataArray[31].split("=");
        viewer_h = dataArray[32].split("=");
        src1 = decodeURIComponent(src[1]);

        iv5 = $("#viewer5").iviewer({
            src: src1,
            update_on_resize: false,
            zoom_animation: false,
            mousewheel: false,
            onMouseMove: function (ev, coords) { },
            onStartDrag: function (ev, coords) { return false; }, //this image will not be dragged
            onDrag: function (ev, coords) { },
            onFinishLoad: function (e) {
                iv5.iviewer("update_css", viewer_x[1], viewer_y[1], viewer_w[1], viewer_h[1]);
                iSrcLoaded5 = 1;
                if (IsAllImgLoaded()) {
                    DoPopupSaveDialog();
                }
            }
        });
    } else {
        iSrcLoaded5 = 1;
    }
    //have 6 div
    if (dataArray.length >= 37) {
        var srcViewer6 = dataArray[33].split("=");
        if (srcViewer6[1].length < 1) iSrcLoaded6 = 1;
        //create this item
        src = dataArray[33].split("=");
        viewer_x = dataArray[34].split("=");
        viewer_y = dataArray[35].split("=");
        viewer_w = dataArray[36].split("=");
        viewer_h = dataArray[37].split("=");
        src1 = decodeURIComponent(src[1]);

        iv6 = $("#viewer6").iviewer({
            src: src1,
            update_on_resize: false,
            zoom_animation: false,
            mousewheel: false,
            onMouseMove: function (ev, coords) { },
            onStartDrag: function (ev, coords) { return false; }, //this image will not be dragged
            onDrag: function (ev, coords) { },
            onFinishLoad: function (e) {
                iv6.iviewer("update_css", viewer_x[1], viewer_y[1], viewer_w[1], viewer_h[1]);
                iSrcLoaded6 = 1;
                if (IsAllImgLoaded()) {
                    DoPopupSaveDialog();
                }
            }
        });
    } else {
        iSrcLoaded6 = 1;
    }
    //have 7 div
    if (dataArray.length >= 42) {
        var srcViewer7 = dataArray[38].split("=");
        if (srcViewer7[1].length < 1) iSrcLoaded7 = 1;
        //create this item
        src = dataArray[38].split("=");
        viewer_x = dataArray[39].split("=");
        viewer_y = dataArray[40].split("=");
        viewer_w = dataArray[41].split("=");
        viewer_h = dataArray[42].split("=");
        src1 = decodeURIComponent(src[1]);

        iv7 = $("#viewer7").iviewer({
            src: src1,
            update_on_resize: false,
            zoom_animation: false,
            mousewheel: false,
            onMouseMove: function (ev, coords) { },
            onStartDrag: function (ev, coords) { return false; }, //this image will not be dragged
            onDrag: function (ev, coords) { },
            onFinishLoad: function (e) {
                iv7.iviewer("update_css", viewer_x[1], viewer_y[1], viewer_w[1], viewer_h[1]);
                iSrcLoaded7 = 1;
                if (IsAllImgLoaded()) {
                    DoPopupSaveDialog();
                }
            }
        });
    } else {
        iSrcLoaded7 = 1;
    }

    //have 8 div
    if (dataArray.length >= 47) {
        var srcViewer8 = dataArray[43].split("=");
        if (srcViewer8[1].length < 1) iSrcLoaded8 = 1;
        //create this item
        src = dataArray[43].split("=");
        viewer_x = dataArray[44].split("=");
        viewer_y = dataArray[45].split("=");
        viewer_w = dataArray[46].split("=");
        viewer_h = dataArray[47].split("=");
        src1 = decodeURIComponent(src[1]);

        iv8 = $("#viewer8").iviewer({
            src: src1,
            update_on_resize: false,
            zoom_animation: false,
            mousewheel: false,
            onMouseMove: function (ev, coords) { },
            onStartDrag: function (ev, coords) { return false; }, //this image will not be dragged
            onDrag: function (ev, coords) { },
            onFinishLoad: function (e) {
                iv8.iviewer("update_css", viewer_x[1], viewer_y[1], viewer_w[1], viewer_h[1]);
                iSrcLoaded8 = 1;
                if (IsAllImgLoaded()) {
                    DoPopupSaveDialog();
                }
            }
        });
    } else {
        iSrcLoaded8 = 1;
    }
    iCurrentDiv = iv1;

    make_item_draggable();
}


function make_item_draggable() {

    $(".draggable").draggable({

        revert: 'invalid',
        helper: 'clone',
        start: function () { //hide original when showing clone
            //$(this).hide();
        },
        stop: function () { //show original when hiding clone
            //$(this).show();
        }
    });
}
function DoPopupSaveDialog() {

    if ($.cookie("back2Collage") == 1 || $.cookie("back2Collage") == 2) {
        SaveDataBeforePublish();

        html2canvas($("#canvas"), {
            onrendered: function (canvas) {
                // canvas is the final rendered <canvas> element
                //console.log('canvas='+canvas.in);
                //$("#canvas_img").append(canvas);
                console.log('canvas=' + canvas.toDataURL("image/png"));
                //console.log('canvas='+canvas.innerHTML());
                var dataURL = canvas.toDataURL("image/png");
                // $("#imgData").val(html);
                // $("#canvas_form").submit();
                console.log("sending post data to server");
                //create Json string


                $.ajax({
                    type: "POST",
                    url: "CollageSaveFile.ashx",
                    data: {
                        'imgBase64': dataURL
                    }
                }).done(function (o) {
                    console.log('saved:' + o);
                    $("#imgData").val(o);

                    //Popup Save2Draft
                    // $("#Save2Draft").dialog("open");


                    //then popup SaveDialog
                    if ($.cookie("back2Collage") == 1) {
                        $("#Save2Draft").parents(".greybox").show();
                        $("#Save2Draft").animate({ top: "2%" }, 300);
                    }
                    //popup publish dialog
                    if ($.cookie("back2Collage") == 2) {

                    }
                    //finally , we reset the cookie
                    if ($.cookie("back2Collage") !== null) {
                        $.cookie("back2Collage", 0);
                        $.cookie("templateID", 0);
                    }

                });



            }
        });
    }
}
function LoadDesign(design_id, readonly) {

    $.ajax({
        type: "POST",
        url: "CollageLoadDesign.ashx",
        data: "{ 'action':'" + "load_single_design"
	      + "','design_id':'" + design_id
	      + "'}",
        dataType: "xml"
    }).done(function (xml) {
        var sID = $(xml).find('ID').text();
        var sHtml = $(xml).find('innerHTML').text();
        var sData = $(xml).find('DesignData').text();
        $("#templateID").val(sID);
        $("#design_workarea").html(sData);
        //Log4Debug("design data="+sHtml);
        $("#dietu-moban").parents(".greybox").hide();

        LoadDesignData(sHtml);

        if (readonly == 2) {
             RemoveDivBorder();
            var sUsername = $(xml).find('Username').text();
            var sCity = $(xml).find('City').text();
            var sCountry = $(xml).find('Country').text();
            var sTitle = $(xml).find('Title').text();
            var sImage = picDesignImgPath + $(xml).find('Image').text();
            var sInspiration = $(xml).find('Inspiration').text();
            $("#txtDesignerInfo").html(sUsername + "  " + sCity + "," + sCountry);

            var isValid = $("#DesignIsValid").val();


            var sProduct_ID1 = $(xml).find('Product_ID1').text();
            var sProduct_ID2 = $(xml).find('Product_ID2').text();
            var sProduct_ID3 = $(xml).find('Product_ID3').text();
            var sProduct_ID4 = $(xml).find('Product_ID4').text();


            var sProduct_ID5 = $(xml).find('Product_ID5').text();
            var sProduct_ID6 = $(xml).find('Product_ID6').text();
            var sProduct_ID7 = $(xml).find('Product_ID7').text();
            var sProduct_ID8 = $(xml).find('Product_ID8').text();

            var html = '<a href="javascript:void(0)" onclick="ShareCollage(' + sID + ',\'' + sTitle + '\',\'' + sImage + '\',\'' + "CollageReview.aspx" + '\',\'' + sInspiration + '\')"  class="yellow-share fr">Share & Earn</a>';
            $("#link_share_earn").html(html);
            var isThisProductValid = 1;
            if (sProduct_ID1.length > 10) {
                isThisProductValid=LoadProductsByID(sProduct_ID1, 1);
                $('#viewer').poshytip({
                    className: 'kuang92',
                    bgImageFrameSize: 11,
                    alignY: 'bottom',
                    content: function (updateCallback) {
                        var sHtml = $('#product_popup1').html();
                        Log4Debug(sHtml);
                        return sHtml;
                    }
                });
            }
            if (sProduct_ID2.length > 10) {
                LoadProductsByID(sProduct_ID2, 2);
                $('#viewer2').poshytip({
                    className: 'kuang92',
                    bgImageFrameSize: 11,
                    alignY: 'bottom',
                    content: function (updateCallback) {

                        return $('#product_popup2').html();
                    }
                });
            }
            if (sProduct_ID3.length > 10) {
                LoadProductsByID(sProduct_ID3, 3);
                $('#viewer3').poshytip({
                    className: 'kuang92',
                    bgImageFrameSize: 11,
                    alignY: 'bottom',
                    content: function (updateCallback) {

                        return $('#product_popup3').html();
                    }
                });
            }
            if (sProduct_ID4.length > 10) {
                LoadProductsByID(sProduct_ID4, 4);
                $('#viewer4').poshytip({
                    className: 'kuang92',
                    bgImageFrameSize: 11,
                    alignY: 'bottom',
                    content: function (updateCallback) {

                        return $('#product_popup4').html();
                    }
                });
            }
            if (sProduct_ID5.length > 10) {
                LoadProductsByID(sProduct_ID5, 5);
                $('#viewer5').poshytip({
                    className: 'kuang92',
                    bgImageFrameSize: 11,
                    alignY: 'bottom',
                    content: function (updateCallback) {

                        return $('#product_popup5').html();
                    }
                });
            }
            if (sProduct_ID6.length > 10) {
                LoadProductsByID(sProduct_ID6, 6);
                $('#viewer6').poshytip({
                    className: 'kuang92',
                    bgImageFrameSize: 11,
                    alignY: 'bottom',
                    content: function (updateCallback) {

                        return $('#product_popup6').html();
                    }
                });
            }

            if (sProduct_ID7.length > 10) {
                LoadProductsByID(sProduct_ID7, 7);
                $('#viewer7').poshytip({
                    className: 'kuang92',
                    bgImageFrameSize: 11,
                    alignY: 'bottom',
                    content: function (updateCallback) {

                        return $('#product_popup7').html();
                    }
                });
            }
            if (sProduct_ID8.length > 10) {
                LoadProductsByID(sProduct_ID8, 8);
                $('#viewer8').poshytip({
                    className: 'kuang92',
                    bgImageFrameSize: 11,
                    alignY: 'bottom',
                    content: function (updateCallback) {

                        return $('#product_popup8').html();
                    }
                });
            }
        }
    });

}


function LoadProductsByID(sProductID,iCurrent) {
    var iPage = 1;
    var isThisProductValid = 1;
    $.ajax({
        type: "Post",
        url: "CollageComments.ashx",
        data: "{'action':'load_products','cate':'" + cate
                    + "','prdName':'" + sProductID
                    + "','state':'" + step
                    + "','focusCateIDs':'" + focusCateIDs
                    + "','orderby':'"
                    + orderby + "','page':'"
                    + iPage
                    + "'}",
        success: function (resu) {

            if (resu == "") {
                return;
            }
            var obj = eval("(" + resu + ")");

            // set share id
            var sShareID = $("#txtShareID").val();
            if (sShareID != null && sShareID.length >= 16) {
                sShareID = "_" + sShareID;
            } else {
                sShareID = "";
            }
            for (var i = 0; i < obj.length; i++) {
                var prd = obj[i];

                var ishot = "none;";
                if (prd.hottip == "yes")
                    ishot = "block;";

                var prdid = "'" + prd.prdGuid + "'";
                var prdname = "'" + prd.name + "'";
                var imgPath = picProductPath + prd.fileurl.replace("big", "mid2");
                var prdimg = "'" + imgPath + "'";
                //var presaleendtime = prd.presaleendtime.replace(/-/g, '/').substring(0, 10);
                var time = prd.presaleendday;
                if (time == null || time == "") { time = "0"; }
                var prdState = prd.wnstat;

                if (prdState == 7) {
                    isThisProductValid = 0;
                }
                var estimateprice = prd.estimateprice.toFixed(2);
                var saleprice = prd.saleprice.toFixed(2);
                if (estimateprice == null) { estimateprice = 0.00; }
                if (saleprice == null) { saleprice = 0.00; }

                var minfinalsaleprice = 0.00;
                if (prd.minfinalsaleprice != null) {
                    minfinalsaleprice = prd.minfinalsaleprice.toFixed(2);
                }


                //change popup html
                if (isThisProductValid == 0) {
                    //disable link
                   
                    $("#product" + iCurrent + "_name").html( "Sorry,this item is no longer available" );
                    $("#product" + iCurrent + "_desc").html("");
                    $("#product" + iCurrent + "_price").html("");
                    $("#product" + iCurrent + "_img").html('<img width="150" src="' + imgPath + '" alt="" />');
                    $("#product" + iCurrent + "_add2cart").html('');
                    

                } else {
                    $("#product" + iCurrent + "_name").html('<a href="/Product/preSaleBuy.aspx?id=' + prd.prdGuid + sShareID + '">' + prd.name + '</a>');
                    $("#product" + iCurrent + "_desc").html(prd.txtjj.substring(0, 100));
                    $("#product" + iCurrent + "_price").html(saleprice);
                    $("#product" + iCurrent + "_img").html('<a href="/Product/preSaleBuy.aspx?id=' + prd.prdGuid + sShareID + '" class="imglink"><img width="150" src="' + imgPath + '" alt="" /></a>');
                    $("#product" + iCurrent + "_add2cart").html('<a href="/Product/preSaleBuy.aspx?id=' + prd.prdGuid + sShareID + '" class="gotoShopCar fr"></a>');
                }
                // $("#product1_img").attr("src", prdimg);
                //Log4Debug("img src=" + prdimg);
                var html = "";
                var urlPage = "'preSaleBuy.aspx'";

                var prdDesc = "'" + escape(prd.txtjj) + "'";
                if (prdState == "2") {
                    //预售中

                    // progress
                    var testSaleProgress = (prd.saleCount / prd.presaleForward) * 100;
                    if (testSaleProgress < 1) testSaleProgress = 1;
                    if (testSaleProgress > 100) testSaleProgress = 100;

                    // left days
                    var leftDays = "";
                    if (time == 1) leftDays = " 1 day left";
                    else if (time <= 0) leftDays = " Time Over";
                    else leftDays = time + " days left";

                    html = '<div class="item presale-ing">'
                    html += '<div class="box"><div class="pic-box">';
                    html += '<a href="preSaleBuy.aspx?id=' + prd.prdGuid + sShareID + '"   class="imglink">';
                    html += '<img src="' + imgPath + '" alt=""></a><div class="floatDiv">';
                    html += '<a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')"  title="Favorite">Favorite</a> ';
                    html += '<a href="#" style="display:none;" class="down" title="Download">Download</a> ';
                    html += '<a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" class="share" title="Share & Earn">Share</a>';
                    html += '</div></div><div class="row row1"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + sShareID + '" >' + prd.name + '</a></div>';
                    html += '<div class="row row2"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + sShareID + '"  class="imglink">' + prd.txtjj.substring(0, 90) + '</a></div>';
                    html += '<div class="row row3 clearfix"><div class="zt1"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + sShareID + '"  class="gotoShopCar" title="Add to Cart">Add to Cart</a>';
                    html += '<del>$' + estimateprice + '</del> <strong class="color">$' + saleprice + '</strong><img src="../Images/hour-glass.png" style="float:right; margin-right:7px;" /></div></div><div class="row row4 clearfix"><div class="zt1"><div class="jdt"><span style="width:' + testSaleProgress + '%"></span></div><span class="fr">' + leftDays + '</span> <span class="fl">Test-Sale:' + prd.saleCount + '/' + prd.presaleForward + ' pieces</span> </div></div><i class="hot"  style="display:' + ishot + '"></i></div></div>';
                    html += '';

                }

                else if (prdState == "6") {
                    //等待上架中
                    html = '<div class="item sale-success"><div class="box"><div class="pic-box"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + sShareID + '"   class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv" style="top:-110px"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a> <a href="#" style="display:none;" class="down" title="Download">Download</a> <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + saleprice + ')" class="share" title="Share">Share</a></div></div><div class="row row1"><a href="#">' + prd.name + '</a></div><div class="row row2"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + '"  class="imglink">' + prd.txtjj + '</a></div><div class="row row3 clearfix"><div class="zt1"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + '"  class="gotoShopCar" title="Add to Cart">Add to Cart</a> <del>$' + estimateprice + '</del> <strong class="color">$' + saleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt1"><div class="jdt"><span style="width:100%"></span></div><span class="fr">Waiting to be listed</span> <span class="color fl">Test-Sale Successful</span></div></div><i class="hot" style="display:none;"></i></div></div>';
                }

                else if (prdState == "7") {
                    //Test-Sale Failed     
                   //disable links and no
                    html = '<div class="item sale-failure"><div class="box"><div class="pic-box"><img src="' + imgPath + '" alt=""><div class="floatDiv" style="top:-110px"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a> <a href="#" style="display:none;" class="down" title="Download">Download</a> <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + saleprice + ')"  class="share" title="Share">Share</a></div></div><div class="row row1">' + prd.name + '</div><div class="row row2">' + prd.txtjj + '</div><div class="row row3 clearfix"><div class="zt2"><a class="fr waiting-btn" href="#">Contact</a> <del>$' + estimateprice + '</del> <strong class="color">$' + estimateprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><div class="jdt"><span></span></div><span class="fl">Test-Sale Failed</span></div></div><i class="hot" style="display:none;"></i></div></div>';

                }
                else if (prdState == "3") {
                    urlPage = "'saleBuy.aspx'";
                    //销售中
                    html = '<div class="item sales-ing"><div class="box"><div class="pic-box"><a href="saleBuy.aspx?id=' + prd.prdGuid + sShareID + '"  class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')"  title="Favorite">Favorite</a> <a href="#" style="display:none;" class="down" title="Download">Download</a> <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')" class="share" title="Share & Earn">Share</a></div></div><div class="row row1"><a href="#">' + prd.name + '</a></div><div class="row row2"><a href="saleBuy.aspx?id=' + prd.prdGuid + '" class="imglink">' + prd.txtjj + '</a></div><div class="row row3 clearfix"><div class="zt2"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + '"  class="gotoShopCar" title="Add to Cart">Add to Cart</a> <strong class="color">$' + minfinalsaleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><a href="javascript:;" class="loveNumber" title="like">' + prd.favoritecount + '</a></span> <span class="fl">Sold：' + prd.saleCount + ' pieces</span> <span class="color">Buy Now</span></div></div></div></div>';
                }


                // $minUl = getMinUl();
                // $minUl.append(html);

            }
            $("#products_lists").append(html);

        },
        error: function (obj) {
            //alert("Load failed");
        }
    });

}
function LoadMyPublish(iPage) {
    var sUserID = $("#userID").val();
    $.ajax({
        type: "POST",
        url: "CollageLoadDesign.ashx",
        data: "{ 'action':'" + "load_my_publish"
	      + "','user_id':'" + sUserID
	      + "','page':'" + iPage
          + "','pageDiv':'" + myDraftPageDiv
	      + "'}",
        dataType: "xml"
    }).done(function (xml) {
        var html = "";
        $(xml).find('design').each(function () {
            var sID = $(this).find('ID').text();
            var sImage = $(this).find('Image').text();
            var sTitle = $(this).find('Title').text();
            html += '<li><a href="#" onclick="LoadDesign(' + sID + ',0)"><img width="153" src="' + picDesignImgPath + sImage + '" alt=""></a></li>';
        });
        $("#MyPublishList").html(html);
        $("#dietu-moban").parents(".greybox").show();
        $("#dietu-moban").animate({ top: "2%" }, 300);

    });
}
function MyPublishPageNavigate(iPage) {
    //previous page remove class
    $("#MYPUBLISH_" + iPrevPageMyPublish).removeClass("on");
    LoadMyPublish(iPage);
    $("#MYPUBLISH_" + iPage).addClass("on");
    iPrevPageMyPublish = iPage;
}

function LoadBackgroundImgTotal() {
    $.ajax({
        type: "POST",
        url: "CollageLoadTemplate.ashx",
        data: "{ 'action':'" + "load_background_total" + "'}",
        dataType: "xml"
    }).done(function (xml) {
        var html = "";
        /*
        $(xml).find('background_total').each(function(){
        var stotal = $(this).find('total').text();
        });
        */
        var stotal = $(xml).find('total').text();
        Log4Debug("total=" + stotal);
        var iTotal = Math.ceil(stotal / pageDiv);
        //make pages
        var i = 0; var html = '<a href="#" class="up">&lt;</a>';

        for (i = 1; i <= iTotal; i++) {
            if (i == 1) {
                html += '<a href="#" id="BN_' + i + '" class="on" onclick="BackgroundPageNavigate(' + i + ')" >' + i + '</a>';
            } else {

                html += '<a href="#" id="BN_' + i + '" onclick="BackgroundPageNavigate(' + i + ')">' + i + '</a>';
            }
        }
        html += '<a href="#" class="down">&gt;</a>';
        $("#BackgroundPage").html(html);
        //load first page
        LoadBackgroundImg(1);


    });
}
function LoadBackgroundImg(iPage) {
    $.ajax({
        type: "POST",
        url: "CollageLoadTemplate.ashx",
        data: "{ 'action':'" + "load_background"
        + "','page':'" + iPage
        + "','pageDiv':'" + pageDiv
        + "'}",
        dataType: "xml"
    }).done(function (xml) {
        var html = "";
        $(xml).find('background').each(function () {
            var sID = $(this).find('ID').text();
            var sImage = $(this).find('Image').text();
            html += '<li><img class="draggable ui-widget-content" height="60" src="' + backgroundPath + sImage + '" id="B_' + sID + '" /></li>';
            // Log4Debug("html="+html);
        });

        $("#BackgroundList").html(html);
        make_item_draggable();

    });
}
function LoadDecorationImgTotal() {
    $.ajax({
        type: "POST",
        url: "CollageLoadTemplate.ashx",
        data: "{ 'action':'" + "load_decoration_total" + "'}",
        dataType: "xml"
    }).done(function (xml) {

        var html = "";
        /*
        $(xml).find('background_total').each(function(){
        var stotal = $(this).find('total').text();
        });
        */
        var stotal = $(xml).find('total').text();
        Log4Debug("total=" + stotal);
        var iTotal = Math.ceil(stotal / pageDiv);
        //make pages
        var i = 0; var html = '<a href="#" class="up">&lt;</a>';

        for (i = 1; i <= iTotal; i++) {
            if (i == 1) {
                html += '<a href="#" id="DN_' + i + '" class="on" onclick="DecorationPageNavigate(' + i + ')" >' + i + '</a>';
            } else {

                html += '<a href="#" id="DN_' + i + '" onclick="DecorationPageNavigate(' + i + ')">' + i + '</a>';
            }
        }
        html += '<a href="#" class="down">&gt;</a>';
        $("#DecorationPage").html(html);
        //load first page
        LoadDecorationImg(1);


    });
}
function LoadDecorationImg(iPage) {
    $.ajax({
        type: "POST",
        url: "CollageLoadTemplate.ashx",
        data: "{ 'action':'" + "load_decoration"
        + "','page':'" + iPage
        + "','pageDiv':'" + pageDiv
        + "'}",
        dataType: "xml"
    }).done(function (xml) {
        var html = "";
        $(xml).find('Decoration').each(function () {
            var sID = $(this).find('ID').text();
            var sImage = $(this).find('Image').text();
            html += '<li><img class="draggable ui-widget-content" height="60" src="' + DecorationPath + sImage + '" id="D_' + sID + '" /></li>';
            // Log4Debug("html="+html);
        });

        $("#DecorationList").html(html);
        make_item_draggable();


    });
}

function LoadMyPublishTotal() {
    var sUserID = $("#userID").val();
    $.ajax({
        type: "POST",
        url: "CollageLoadDesign.ashx",
        data: "{ 'action':'" + "load_my_publish_total"
      + "','user_id':'" + sUserID
      + "'}",
        dataType: "xml"
    }).done(function (xml) {
        var html = "";
        /*
        $(xml).find('background_total').each(function(){
        var stotal = $(this).find('total').text();
        });
        */
        var stotal = $(xml).find('Total').text();
        Log4Debug("total=" + stotal);
        var iTotal = Math.ceil(stotal / myDraftPageDiv);
        //make pages
        var i = 0; var html = '<li><a href="#" class="leftBtn"></a></li>';

        for (i = 1; i <= iTotal; i++) {
            if (i == 1) {
                html += '<li><a href="#" id="MYPUBLISH_' + i + '" class="on" onclick="MyPublishPageNavigate(' + i + ')" >' + i + '</a></li>';
            } else {

                html += '<li><a href="#" id="MYPUBLISH_' + i + '" onclick="MyPublishPageNavigate(' + i + ')">' + i + '</a></li>';
            }
        }
        html += '<li><a href="#" class="rightBtn"></a></li>';
        $("#MyPublishPageList").html(html);
        //load first page
        LoadMyPublish(1);


    });

}
function formatErrorMessage(jqXHR, exception) {

    if (jqXHR.status === 0) {
        return ('Not connected.\nPlease verify your network connection.');
    } else if (jqXHR.status == 404) {
        return ('The requested page not found. [404]');
    } else if (jqXHR.status == 500) {
        return ('Internal Server Error [500].');
    } else if (exception === 'parsererror') {
        return ('Requested JSON parse failed.');
    } else if (exception === 'timeout') {
        return ('Time out error.');
    } else if (exception === 'abort') {
        return ('Ajax request aborted.');
    } else {
        return ('Uncaught Error.\n' + jqXHR.responseText);
    }
}

function LoadMyDraftTotal() {
    var sUserID = $("#userID").val();
    if (sUserID.length < 2) {
        //not login, load dialog directly
       // $("#MyPublishList").html(html);
        $("#dietu-moban").parents(".greybox").show();
        $("#dietu-moban").animate({ top: "2%" }, 300);
    } else {
        $.ajax({
            type: "POST",
            url: "CollageLoadDesign.ashx",
            data: "{ 'action':'" + "load_my_draft_total"
          + "','user_id':'" + sUserID
          + "'}",
            dataType: "xml"
        }).done(function (xml) {
            var html = "";

            var stotal = $(xml).find('Total').text();
            Log4Debug("total=" + stotal);
            var iTotal = Math.ceil(stotal / myDraftPageDiv);
            //make pages
            var i = 0; var html = '<li><a href="#" class="leftBtn"></a></li>';

            for (i = 1; i <= iTotal; i++) {
                if (i == 1) {
                    html += '<li><a href="#" id="MYDRAFT_' + i + '" class="on" onclick="MyDraftPageNavigate(' + i + ')" >' + i + '</a></li>';
                } else {

                    html += '<li><a href="#" id="MYDRAFT_' + i + '" onclick="MyDraftPageNavigate(' + i + ')">' + i + '</a></li>';
                }
            }
            html += '<li><a href="#" class="rightBtn"></a></li>';
            $("#MyDraftPageList").html(html);
            //load first page
            LoadMyDraft(1);


        })
        .fail(function (xhr, err) {

            var responseTitle = $(xhr.responseText).filter('title').get(0);
            alert($(responseTitle).text() + "\n" + formatErrorMessage(xhr, err));
        });
    }
}

function DoCategorySearch() {
    var sKeywords = $("#txtCategoryKeywords").val();
    Log4Debug("keyword=" + sKeywords);
    if (sKeywords.length < 2) {
        Log4Debug("should popup ?");
        alert("Please input keywords");
        return;
    }
    // var prdName = $("#txtPrdname").val();
    prdName = sKeywords;
    GetTotalCount();
}
function LoadMyDraft(iPage) {
    var sUserID = $("#userID").val();
    $.ajax({
        type: "POST",
        url: "CollageLoadDesign.ashx",
        data: "{ 'action':'" + "load_my_draft"
	      + "','user_id':'" + sUserID
	      + "','page':'" + iPage
          + "','pageDiv':'" + myDraftPageDiv
	      + "'}",
        dataType: "xml"
    }).done(function (xml) {
        var html = "";
        $(xml).find('design').each(function () {
            var sID = $(this).find('ID').text();
            var sImage = $(this).find('Image').text();
            var sTitle = $(this).find('Title').text();
            html += '<li><a href="#" onclick="LoadDesign(' + sID + ',1)"><img width="153" src="' + picDesignImgPath + sImage + '" alt=""></a></li>';
        });
        $("#MyDraftList").html(html);
        LoadMyPublishTotal();
    });
}
function MyDraftPageNavigate(iPage) {
    //previous page remove class
    $("#MYDRAFT_" + iPrevPageMyDraft).removeClass("on");
    LoadMyDraft(iPage);
    $("#MYDRAFT_" + iPage).addClass("on");
    iPrevPageMyDraft = iPage;
}
function Log4Debug(s) {
    console.log(s);
}

function GetTotalCount() {
    $.ajax({
        type: "Post",
        url: "../AjaxPages/prdSaleAjax.aspx",
        data: "{'action':'reviewPrdCount','cate':'" + cate
                    + "','prdName':'" + prdName
                    + "','state':'" + step
                    + "','focusCateIDs':'" + focusCateIDs
                    + "','orderby':'"
                    + orderby + "','page':'"
                    + page
                    + "'}",
        success: function (resu) {
            //showSearchResult(resu);
            Log4Debug("result=" + resu);

            if (resu > 0) {
                iTotalPage = Math.ceil(resu / pageDiv);
                //make pages
                var i = 0; var html = '<a href="#" class="up">&lt;</a>';

                for (i = 1; i <= iTotalPage; i++) {
                    if (i == 1) {
                        html += '<a href="#" id="PN_' + i + '" class="on" onclick="ProductPageNavigate(' + i + ')" >' + i + '</a>';
                    } else {

                        html += '<a href="#" id="PN_' + i + '" onclick="ProductPageNavigate(' + i + ')">' + i + '</a>';
                    }
                }
                html += '<a href="#" class="down">&gt;</a>';
                $("#ProductsPage").html(html);
                //load first page
                GetProductsList(1);
            } else {
                alert("No Match Find");
            }
        },
        error: function (obj) {
            //alert("Load failed");
        }
    });
}
function ProductPageNavigate(iPage) {
    //previous page remove class
    $("#PN_" + iPrevPage).removeClass("on");
    GetProductsList(iPage);
    $("#PN_" + iPage).addClass("on");
    iPrevPage = iPage;
}
function BackgroundPageNavigate(iPage) {
    //previous page remove class
    $("#BN_" + iPrevPageBG).removeClass("on");
    LoadBackgroundImg(iPage);
    $("#BN_" + iPage).addClass("on");
    iPrevPageBG = iPage;
}
function DecorationPageNavigate(iPage) {
    //previous page remove class
    $("#DN_" + iPrevPageDe).removeClass("on");
    LoadDecorationImg(iPage);
    $("#DN_" + iPage).addClass("on");
    iPrevPageDe = iPage;
}
function get_png_name(jpg_name) {
    var i = jpg_name.lastIndexOf(".");
    var s = jpg_name.substring(0, i);
    return s + ".png";
}
function get_jpg_name(png_name) {
    return png_name.Replace("png.png", ".jpg");
}

function TemplatePageNavigate(iPage) {
    //previous page remove class
    $("#TN_" + iPrevPageTemplate).removeClass("on");
    LoadDecorationImgTotal(iPage);
    $("#TN_" + iPage).addClass("on");
    iPrevPageTemplate = iPage;
}
function LoadTemplateByPage(iPage) {
    $.ajax({
        type: "POST",
        url: "CollageLoadTemplate.ashx",
        data: "{ 'action':'" + "load_template"
      + "','page':'" + iPage
      + "','pageDiv':'" + pageDiv
      + "'}",
        dataType: "xml"
    }).done(function (xml) {
        var html = "";
        $(xml).find('template').each(function () {
            var sID = $(this).find('ID').text();
            var sImage = $(this).find('Image').text();
            html += '<li><a href="#" onclick="load_template(' + sID + ')"><img width="155" src="' + templatePath + sImage + '" id="' + sID + '" /></a></li>';
           // Log4Debug("html=" + html);
        });

        $("#CollageTemplate").html(html);
        LoadMyDraftTotal();

        // $("#dietu-moban").dialog("open");


    });
}

function SavePublish() {
    var txtDesignID = $("#txtDesignID").val();

    var txtTitle = $("#txtPublishTitle").val();
    var txtDraftTags = $("#txtPublishTag").val();
    var txtDfaftInspiration = $("#txtPublishInspiration").val();

    var datastring = $("#canvas_form").serialize();
    var txtTemplateID = $("#templateID").val();
    var txtUserID = $("#userID").val();
    var txtThumbnail = $("#imgData").val();

    var txtProduct1 = $("#ProductID_1").val();
    var txtProduct2 = $("#ProductID_2").val();
    var txtProduct3 = $("#ProductID_3").val();
    var txtProduct4 = $("#ProductID_4").val();

    var txtProduct5 = $("#ProductID_5").val();
    var txtProduct6 = $("#ProductID_6").val();
    var txtProduct7 = $("#ProductID_7").val();
    var txtProduct8 = $("#ProductID_8").val();

    $.ajax({
        type: "POST",
        url: "CollageSaveDraft.ashx",
        data: "{'action':'save_publish','txtTitle':'" + txtTitle + "','txtDraftTags':'" + txtDraftTags
     + "','txtDfaftInspiration':'" + txtDfaftInspiration
     + "','txtFormData':'" + datastring
     + "','txtTemplateID':'" + txtTemplateID
     + "','txtUserID':'" + txtUserID
     + "','txtThumbnail':'" + txtThumbnail
     + "','txtDesignID':'" + txtDesignID
     + "','txtProduct1':'" + txtProduct1
     + "','txtProduct2':'" + txtProduct2
     + "','txtProduct3':'" + txtProduct3
     + "','txtProduct4':'" + txtProduct4
     + "','txtProduct5':'" + txtProduct5
     + "','txtProduct6':'" + txtProduct6
     + "','txtProduct7':'" + txtProduct7
     + "','txtProduct8':'" + txtProduct8
     + "'}"
    }).done(function (o) {
        Log4Debug('saved:' + o);
        //$("#imgData").val(o);
        if (o == 1) {
            window.location.href = "/Product/CollageShare.aspx";
            // $("#save_draft_info").html("Your Draft Saved!");
        } else {
            $("#save_draft_info").html("Error: " + o);
        }

    });
}
function SaveDraft() {

    var txtTitle = $("#txtDraftTitle").val();
    var txtDraftTags = $("#txtDraftTags").val();
    var txtDfaftInspiration = $("#txtDfaftInspiration").val();

    var datastring = $("#canvas_form").serialize();
    var txtTemplateID = $("#templateID").val();
    var txtUserID = $("#userID").val();
    var txtThumbnail = $("#imgData").val();

    var txtProduct1 = $("#ProductID_1").val();
    var txtProduct2 = $("#ProductID_2").val();
    var txtProduct3 = $("#ProductID_3").val();
    var txtProduct4 = $("#ProductID_4").val();

    var txtProduct5 = $("#ProductID_5").val();
    var txtProduct6 = $("#ProductID_6").val();
    var txtProduct7 = $("#ProductID_7").val();
    var txtProduct8 = $("#ProductID_8").val();
     $.ajax({
        type: "POST",
        url: "CollageSaveDraft.ashx",
        data: "{'action':'save_draft', 'txtTitle':'" + txtTitle + "','txtDraftTags':'" + txtDraftTags
     + "','txtDfaftInspiration':'" + txtDfaftInspiration
     + "','txtFormData':'" + datastring
     + "','txtTemplateID':'" + txtTemplateID
     + "','txtUserID':'" + txtUserID
     + "','txtThumbnail':'" + txtThumbnail
     + "','txtProduct1':'" + txtProduct1
     + "','txtProduct2':'" + txtProduct2
     + "','txtProduct3':'" + txtProduct3
     + "','txtProduct4':'" + txtProduct4
      + "','txtProduct5':'" + txtProduct5
     + "','txtProduct6':'" + txtProduct6
     + "','txtProduct7':'" + txtProduct7
     + "','txtProduct8':'" + txtProduct8
     + "'}"
    }).done(function (o) {
        Log4Debug('saved:' + o);
        //$("#imgData").val(o);
        if (o == 1) {
            $("#save_draft_info").html("Your Draft Saved!");
        } else {
            $("#save_draft_info").html("Error: " + o);
        }

    });


}

function change2png() {
    var obj_src=$("#imgPngsrc").attr("src");
    iCurrentDiv.iviewer("change_src", obj_src);
}
function change2jpg() {
    var obj_src = $("#imgJpgsrc").attr("src");
    iCurrentDiv.iviewer("change_src", obj_src);
}

function SaveDataBeforePublish() {

    var w = iv1.iviewer("info", "width");
    var h = iv1.iviewer("info", "height");
    var x1 = iv1.iviewer("info", "left");
    var y1 = iv1.iviewer("info", "top");

    //Log4Debug("w="+w+" h="+h+" x="+x1+" y="+y1);

    $("#viewer_x").val(x1);
    $("#viewer_y").val(y1);
    $("#viewer_w").val(w);
    $("#viewer_h").val(h);

    var w2 = iv2.iviewer("info", "width");
    var h2 = iv2.iviewer("info", "height");
    var x2 = iv2.iviewer("info", "left");
    var y2 = iv2.iviewer("info", "top");

    $("#viewer2_x").val(x2);
    $("#viewer2_y").val(y2);
    $("#viewer2_w").val(w2);
    $("#viewer2_h").val(h2);


    var w3 = iv3.iviewer("info", "width");
    var h3 = iv3.iviewer("info", "height");
    var x3 = iv3.iviewer("info", "left");
    var y3 = iv3.iviewer("info", "top");

    $("#viewer3_x").val(x3);
    $("#viewer3_y").val(y3);
    $("#viewer3_w").val(w3);
    $("#viewer3_h").val(h3);

    var w4 = iv4.iviewer("info", "width");
    var h4 = iv4.iviewer("info", "height");
    var x4 = iv4.iviewer("info", "left");
    var y4 = iv4.iviewer("info", "top");

    $("#viewer4_x").val(x4);
    $("#viewer4_y").val(y4);
    $("#viewer4_w").val(w4);
    $("#viewer4_h").val(h4);


    //have 5 div
    var w = iv5.iviewer("info", "width");
    var h = iv5.iviewer("info", "height");
    var x = iv5.iviewer("info", "left");
    var y = iv5.iviewer("info", "top");

    $("#viewer5_x").val(x);
    $("#viewer5_y").val(y);
    $("#viewer5_w").val(w);
    $("#viewer5_h").val(h);

    //have 6 div

    var w = iv6.iviewer("info", "width");
    var h = iv6.iviewer("info", "height");
    var x = iv6.iviewer("info", "left");
    var y = iv6.iviewer("info", "top");

    $("#viewer6_x").val(x);
    $("#viewer6_y").val(y);
    $("#viewer6_w").val(w);
    $("#viewer6_h").val(h);
    //have 7 div
    var w = iv7.iviewer("info", "width");
    var h = iv7.iviewer("info", "height");
    var x = iv7.iviewer("info", "left");
    var y = iv7.iviewer("info", "top");

    $("#viewer7_x").val(x);
    $("#viewer7_y").val(y);
    $("#viewer7_w").val(w);
    $("#viewer7_h").val(h);
    //have 8 div
    var w = iv8.iviewer("info", "width");
    var h = iv8.iviewer("info", "height");
    var x = iv8.iviewer("info", "left");
    var y = iv8.iviewer("info", "top");

    $("#viewer8_x").val(x);
    $("#viewer8_y").val(y);
    $("#viewer8_w").val(w);
    $("#viewer8_h").val(h);

    RemoveDivBorder();
}

function PublishMyDesign(){
    
    //Load Wait dialog
    
    $("#loading").parents(".greybox").show();
    $("#loading").animate({ top: "2%" }, 300);

    //check login
    if(isLogin=="False"){
        //save data
        var template_id=$("#templateID").val();
        $.cookie("back2Collage", 2);
        $.cookie("templateID",template_id );
        var datastring = $("#canvas_form").serialize();
        $.cookie("collage_draft_data",datastring);
        window.location.href="/User/login.aspx?op=CollageCreate";
    }

	//var html=$("#canvas").html();
	//$("#innerHTMLDIV").val(html);
	//console.log("html="+html);
    SaveDataBeforePublish();

		html2canvas($("#canvas"), {
		    onrendered: function(canvas) {
		        var dataURL = canvas.toDataURL("image/png");
		        console.log("sending post data to server");
		        //create Json string
		
		
		        $.ajax({
					  type: "POST",
					  url: "CollageSaveFile.ashx",
					  data: { 
                      'imgBase64': dataURL
					  }
					}).done(function(o) {
					     console.log('saved:'+o); 
					     $("#imgData").val(o);
					   $("#loading").parents(".greybox").hide();

                        $("#my-dietu").parents(".greybox").show();
                        $("#my-dietu").animate({ top: "2%" }, 300);

					
					});

        

    	}
		});   //End of html2canvas



}
function ZoomUpdate(vol){
    //if(vol>iCurrentZoom){
        iCurrentDiv.iviewer('zoom_by', vol - iCurrentZoom);
        iCurrentZoom= vol;
     // }
}





function OpenTemplateDialog(){
    //load all template
    
    $.ajax({
      type: "POST",
      url: "CollageLoadTemplate.ashx",
      data: "{ 'action':'"+ "load_template_total" +"'}",
      dataType: "xml"
    }).done(function(xml) {
        var html="";
        var stotal = $(xml).find('total').text();
        var iTotal = Math.ceil(stotal / myDraftPageDiv);
            //make pages
        var i = 0; var html = '<li><a href="#" class="leftBtn"></a><li>';

        for (i = 1; i <= iTotal; i++) {
                if (i == 1) {
                    html += '<li><a href="#" id="TN_' + i + '" class="on" onclick="TemplatePageNavigate(' + i + ')" >' + i + '</a></li>';
                } else {

                    html += '<li><a href="#" id="TN_' + i + '" onclick="TemplatePageNavigate(' + i + ')">' + i + '</a></li>';
                }
         }
            html += '<li><a href="#" class="rightBtn"></a></li>';
            $("#TemplatePageList").html(html);
        
        LoadTemplateByPage(1);

    });

    
}



function load_template(template_id){
    //
    $("#dietu-moban").parents(".greybox").hide();
    //window.location.href = "/Product/collageCreate.aspx?templateID=" + template_id;
    
     $.ajax({
      type: "POST",
      url: "CollageLoadTemplate.ashx",
      data: "{ 'action':'"+ "load_single_template"
       + "','template_id':'"+template_id
       +"'}",
      dataType: "xml"
    }).done(function(xml) {
        //var html="";
	    var sID = $(xml).find('ID').text();
		var sInnerHTML = $(xml).find('innerHTML').text();
        $("#templateID").val(sID);
        $("#design_workarea").html(sInnerHTML);
        InitIViewer();
        make_item_draggable();
        //console.log("sid="+sID+" html="+sInnerHTML);
    });
    
}

function GetProductsList(iPage) {


    $.ajax({
        type: "Post",
        url: "../AjaxPages/prdSaleAjax.aspx",
        data: "{'action':'reviewPrd','cate':'" + cate
                    + "','prdName':'" + prdName
                    + "','state':'" + step
                    + "','focusCateIDs':'" + focusCateIDs
                    + "','orderby':'"
                    + orderby + "','page':'"
                    + iPage
                    + "'}",
        success: function (resu) {
            if (resu == "") {
                return;
            }
            var obj = eval("(" + resu + ")");

            var html = "";
            for (var i = 0; i < obj.length; i++) {
                var prd = obj[i];

                var ishot = "none;";
                if (prd.hottip == "yes")
                    ishot = "block;";

                var prdid = "'" + prd.prdGuid + "'";
                var prdname = "'" + prd.name + "'";
                var imgPath = picPath + GetVirtualImgFolder(prd.fileurl.replace("big", "mid2"));
                var prdimg = "'" + imgPath + "'";
                //var presaleendtime = prd.presaleendtime.replace(/-/g, '/').substring(0, 10);
                var time = prd.presaleendday;
                if (time == null || time == "") { time = "0"; }
                var prdState = prd.wnstat;
                var estimateprice = prd.estimateprice.toFixed(2);
                var saleprice = prd.saleprice.toFixed(2);
                if (estimateprice == null) { estimateprice = 0.00; }
                if (saleprice == null) { saleprice = 0.00; }

                var urlPage = "'preSaleBuy.aspx'";

                var prdDesc = "'" + escape(prd.txtjj) + "'";
                /*
                if (prdState == "2") {
                //预售中

                // progress
                var testSaleProgress = (prd.saleCount / prd.presaleForward) * 100;
                if (testSaleProgress < 1) testSaleProgress = 1;
                if (testSaleProgress > 100) testSaleProgress = 100;

                // left days
                var leftDays = "";
                if (time == 1) leftDays = " 1 day left";
                else if (time <= 0) leftDays = " Time Over";
                else leftDays = time + " days left";

                html = '<div class="item presale-ing">'
                html += '<div class="box"><div class="pic-box">';
                html += '<a href="preSaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink">';
                html += '<img src="' + imgPath + '" alt=""></a><div class="floatDiv">';
                html += '<a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')"  title="Favorite">Favorite</a> ';
                html += '<a href="#" style="display:none;" class="down" title="Download">Download</a> ';
                html += '<a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" class="share" title="Share & Earn">Share</a>';
                html += '</div></div><div class="row row1"><a href="#">' + prd.name + '</a></div>';
                html += '<div class="row row2"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + '"  class="imglink">' + prd.txtjj.substring(0, 90) + '</a></div>';
                html += '<div class="row row3 clearfix"><div class="zt1"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + '"  class="gotoShopCar" title="Add to Cart">Add to Cart</a>';
                html += '<del>$' + estimateprice + '</del> <strong class="color">$' + saleprice + '</strong><img src="../Images/hour-glass.png" style="float:right; margin-right:7px;" /></div></div><div class="row row4 clearfix"><div class="zt1"><div class="jdt"><span style="width:' + testSaleProgress + '%"></span></div><span class="fr">' + leftDays + '</span> <span class="fl">Test-Sale:' + prd.saleCount + '/' + prd.presaleForward + ' pieces</span> </div></div><i class="hot"  style="display:' + ishot + '"></i></div></div>';
                html += '';

                }

                else if (prdState == "6") {
                //等待上架中
                html = '<div class="item sale-success"><div class="box"><div class="pic-box"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv" style="top:-110px"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a> <a href="#" style="display:none;" class="down" title="Download">Download</a> <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + saleprice + ')" class="share" title="Share">Share</a></div></div><div class="row row1"><a href="#">' + prd.name + '</a></div><div class="row row2"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + '"  class="imglink">' + prd.txtjj + '</a></div><div class="row row3 clearfix"><div class="zt1"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + '"  class="gotoShopCar" title="Add to Cart">Add to Cart</a> <del>$' + estimateprice + '</del> <strong class="color">$' + saleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt1"><div class="jdt"><span style="width:100%"></span></div><span class="fr">Waiting to be listed</span> <span class="color fl">Test-Sale Successful</span></div></div><i class="hot" style="display:none;"></i></div></div>';
                }

                else if (prdState == "7") {
                //Test-Sale Failed     
                html = '<div class="item sale-failure"><div class="box"><div class="pic-box"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + '"  class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv" style="top:-110px"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a> <a href="#" style="display:none;" class="down" title="Download">Download</a> <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + saleprice + ')"  class="share" title="Share">Share</a></div></div><div class="row row1"><a href="#">' + prd.name + '</a></div><div class="row row2"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + '" class="imglink">' + prd.txtjj + '</a></div><div class="row row3 clearfix"><div class="zt2"><a class="fr waiting-btn" href="#">Contact</a> <del>$' + estimateprice + '</del> <strong class="color">$' + estimateprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><div class="jdt"><span></span></div><span class="fl">Test-Sale Failed</span></div></div><i class="hot" style="display:none;"></i></div></div>';

                }
                else if (prdState == "3") {
                urlPage = "'saleBuy.aspx'";
                //销售中
                html = '<div class="item sales-ing"><div class="box"><div class="pic-box"><a href="saleBuy.aspx?id=' + prd.prdGuid + '"  class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')"  title="Favorite">Favorite</a> <a href="#" style="display:none;" class="down" title="Download">Download</a> <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + saleprice + ')" class="share" title="Share & Earn">Share</a></div></div><div class="row row1"><a href="#">' + prd.name + '</a></div><div class="row row2"><a href="saleBuy.aspx?id=' + prd.prdGuid + '" class="imglink">' + prd.txtjj + '</a></div><div class="row row3 clearfix"><div class="zt2"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + '"  class="gotoShopCar" title="Add to Cart">Add to Cart</a> <strong class="color">$' + saleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><a href="javascript:;" class="loveNumber" title="like">100</a></span> <span class="fl">Sold：' + prd.saleCount + ' pieces</span> <span class="color">Final-Sale</span></div></div></div></div>';
                }
                */

                html += '<li>';
                html += '<div class="h60">';
                html += '<img height="60" class="draggable ui-widget-content" id="P_' + prd.prdGuid + '" src="' + imgPath + '" alt="" />';
                html += '</div>';
                // html += prdname;
                html += '</li>';


            }
            $("#ProductsList").html(html);
            //??

            make_item_draggable();
            /*
            $(".draggable").draggable({
            revert : function(event, ui) {
            // on older version of jQuery use "draggable"
            // $(this).data("draggable")
            return !event;
            // return (event !== false) ? false : true;
            }
            }); 
            */
        },
        error: function (obj) {
            //alert("Load failed");
        }
    });
}


function InitIViewer(){

      iv1 = $("#viewer").iviewer({
                       src: "",
                       update_on_resize: false,
                       zoom_animation: false,
                       mousewheel: false,
                       onMouseMove: function(ev, coords) { },
                       onStartDrag: function(ev, coords) { return false; }, //this image will not be dragged
                       onDrag: function(ev, coords) { },
                  });
        iv2 = $("#viewer2").iviewer(
        {
            src: ""
        });

        iv3 = $("#viewer3").iviewer(
        {
            src: ""
        });
        iv4 = $("#viewer4").iviewer(
        {
            src: ""
        });
    
        iv5 = $("#viewer5").iviewer(
        {
            src: ""
        });
        iv6 = $("#viewer6").iviewer(
        {
            src: ""
        });
        iv7 = $("#viewer7").iviewer(
        {
            src: ""
        });
        iv8 = $("#viewer8").iviewer(
        {
            src: ""
        });
		iCurrentDiv =iv1;

$( "#viewer" ).droppable({
      drop: function( event, ui ) {
      	var draggable_elem = ui.draggable;
      	draggable_elem.draggable({revert:true});
      	//old one remove active
      	iCurrentDiv.removeClass("DivSelected");
        RemoveInnerText("viewer");
      	 iCurrentDiv=iv1;
      	 //make it as active
      	 iCurrentDiv.addClass("DivSelected");
      	 //var objsrc 		= draggable_elem.find('.ui-widget-content').attr('src');
      	 var objsrc1 		= draggable_elem.attr('src');
         var obj_id1 		= draggable_elem.attr('id');
         $("#viewer img").attr("id", obj_id1);
      	 console.log(" 1="+objsrc1);
      	 $("#viewer img").attr("src", objsrc1);
         $("#viewer img").attr("id", obj_id1);
      	 $("#viewer_src").val(objsrc1);
         $("#ProductID_1").val(obj_id1);
         $("#imgPngsrc").attr("src",get_png_name(objsrc1));
         $("#imgJpgsrc").attr("src",objsrc1);

      	 //should change the image src ??

      }
    });
            
$( "#viewer2" ).droppable({
      drop: function( event, ui ) {
      	var draggable_elem = ui.draggable;
      	draggable_elem.draggable({revert:true});
      		iCurrentDiv.removeClass("DivSelected");
            RemoveInnerText("viewer2");
      	 iCurrentDiv=iv2;
      	 iCurrentDiv.addClass("DivSelected");
      	 //var objsrc 		= draggable_elem.find('.ui-widget-content').attr('src');
      	 var objsrc1 		= draggable_elem.attr('src');
         var obj_id1 		= draggable_elem.attr('id');
         $("#viewer2 img").attr("id", obj_id1);

      	 console.log(" 1="+objsrc1);
      	 $("#viewer2 img").attr("src", objsrc1);
      	 $("#viewer2_src").val(objsrc1);
         $("#ProductID_2").val(obj_id1);
      	 //should change the image src ??
         $("#imgPngsrc").attr("src",get_png_name(objsrc1));
         $("#imgJpgsrc").attr("src",objsrc1);

      }
    });                      

$( "#viewer3" ).droppable({
      drop: function( event, ui ) {
      	var draggable_elem = ui.draggable;
      	draggable_elem.draggable({revert:true});
      	iCurrentDiv.removeClass("DivSelected");
        RemoveInnerText("viewer3");
      	 iCurrentDiv=iv3;
      	 iCurrentDiv.addClass("DivSelected");
      	 //var objsrc 		= draggable_elem.find('.ui-widget-content').attr('src');
      	 var objsrc1 		= draggable_elem.attr('src');
         var obj_id1 		= draggable_elem.attr('id');
         $("#viewer3 img").attr("id", obj_id1);

      	 console.log(" 1="+objsrc1);
      	 $("#viewer3 img").attr("src", objsrc1);
      	 $("#viewer3_src").val(objsrc1);
         $("#ProductID_3").val(obj_id1);
      	 //should change the image src ??
         $("#imgPngsrc").attr("src",get_png_name(objsrc1));
         $("#imgJpgsrc").attr("src",objsrc1);

      }
    });                      
                
$( "#viewer4" ).droppable({
      drop: function( event, ui ) {
      	var draggable_elem = ui.draggable;
      	draggable_elem.draggable({revert:true});
      	iCurrentDiv.removeClass("DivSelected");
        RemoveInnerText("viewer4");
      	 iCurrentDiv=iv4;
      	 iCurrentDiv.addClass("DivSelected");
      	 //var objsrc 		= draggable_elem.find('.ui-widget-content').attr('src');
      	 var objsrc1 		= draggable_elem.attr('src');
      	 console.log(" 1="+objsrc1);
      	 $("#viewer4 img").attr("src", objsrc1);
         var obj_id1 		= draggable_elem.attr('id');
         $("#viewer4 img").attr("id", obj_id1);

      	 $("#viewer4_src").val(objsrc1);
         $("#ProductID_4").val(obj_id1);
      	 //should change the image src ??
         $("#imgPngsrc").attr("src",get_png_name(objsrc1));
         $("#imgJpgsrc").attr("src",objsrc1);

      }
    });                      
      
 $( "#viewer5" ).droppable({
      drop: function( event, ui ) {
      	var draggable_elem = ui.draggable;
      	draggable_elem.draggable({revert:true});
      	iCurrentDiv.removeClass("DivSelected");
        RemoveInnerText("viewer5");
      	 iCurrentDiv=iv5;
      	 iCurrentDiv.addClass("DivSelected");
      	 //var objsrc 		= draggable_elem.find('.ui-widget-content').attr('src');
      	 var objsrc1 		= draggable_elem.attr('src');
      	 console.log(" 1="+objsrc1);
      	 $("#viewer5 img").attr("src", objsrc1);
         var obj_id1 		= draggable_elem.attr('id');
         $("#viewer5 img").attr("id", obj_id1);

      	 $("#viewer5_src").val(objsrc1);
         $("#ProductID_5").val(obj_id1);
      	 //should change the image src ??
         $("#imgPngsrc").attr("src",get_png_name(objsrc1));
         $("#imgJpgsrc").attr("src",objsrc1);

      }
    });   
  $( "#viewer6" ).droppable({
      drop: function( event, ui ) {
      	var draggable_elem = ui.draggable;
      	draggable_elem.draggable({revert:true});
      	iCurrentDiv.removeClass("DivSelected");
        RemoveInnerText("viewer6");
      	 iCurrentDiv=iv6;
      	 iCurrentDiv.addClass("DivSelected");
      	 //var objsrc 		= draggable_elem.find('.ui-widget-content').attr('src');
      	 var objsrc1 		= draggable_elem.attr('src');
      	 console.log(" 1="+objsrc1);
      	 $("#viewer6 img").attr("src", objsrc1);
         var obj_id1 		= draggable_elem.attr('id');
         $("#viewer6 img").attr("id", obj_id1);

      	 $("#viewer6_src").val(objsrc1);
         $("#ProductID_6").val(obj_id1);
      	 //should change the image src ??
         $("#imgPngsrc").attr("src",get_png_name(objsrc1));
         $("#imgJpgsrc").attr("src",objsrc1);

      }
    });   
  $( "#viewer7" ).droppable({
      drop: function( event, ui ) {
      	var draggable_elem = ui.draggable;
      	draggable_elem.draggable({revert:true});
      	iCurrentDiv.removeClass("DivSelected");
        RemoveInnerText("viewer7");
      	 iCurrentDiv=iv7;
      	 iCurrentDiv.addClass("DivSelected");
      	 //var objsrc 		= draggable_elem.find('.ui-widget-content').attr('src');
      	 var objsrc1 		= draggable_elem.attr('src');
      	 console.log(" 1="+objsrc1);
      	 $("#viewer7 img").attr("src", objsrc1);
         var obj_id1 		= draggable_elem.attr('id');
         $("#viewer7 img").attr("id", obj_id1);

      	 $("#viewer7_src").val(objsrc1);
         $("#ProductID_7").val(obj_id1);
      	 //should change the image src ??
         $("#imgPngsrc").attr("src",get_png_name(objsrc1));
         $("#imgJpgsrc").attr("src",objsrc1);

      }
    });   
    
   $( "#viewer8" ).droppable({
      drop: function( event, ui ) {
      	var draggable_elem = ui.draggable;
      	draggable_elem.draggable({revert:true});
      	iCurrentDiv.removeClass("DivSelected");
        RemoveInnerText("viewer8");
      	 iCurrentDiv=iv8;
      	 iCurrentDiv.addClass("DivSelected");
      	 //var objsrc 		= draggable_elem.find('.ui-widget-content').attr('src');
      	 var objsrc1 		= draggable_elem.attr('src');
      	 console.log(" 1="+objsrc1);
      	 $("#viewer8 img").attr("src", objsrc1);
         var obj_id1 		= draggable_elem.attr('id');
         $("#viewer8 img").attr("id", obj_id1);

      	 $("#viewer8_src").val(objsrc1);
         $("#ProductID_8").val(obj_id1);
      	 //should change the image src ??
         $("#imgPngsrc").attr("src",get_png_name(objsrc1));
         $("#imgJpgsrc").attr("src",objsrc1);

      }
    });           
 }

 function RemoveDivBorder(){
    if($.cookie("back2Collage")!=null && $.cookie("back2Collage")>=1){
        //login back 2 Collage,no need to remove the border
    }else{
        $("#viewer").css('border',''); $("#viewer .innerDrag").css('display','none');
        $("#viewer2").css('border','');$("#viewer2 .innerDrag").css('display','none');
        $("#viewer3").css('border','');$("#viewer3 .innerDrag").css('display','none');
        $("#viewer4").css('border','');$("#viewer4 .innerDrag").css('display','none');
        $("#viewer5").css('border','');$("#viewer5 .innerDrag").css('display','none');
        $("#viewer6").css('border','');$("#viewer6 .innerDrag").css('display','none');
        $("#viewer7").css('border','');$("#viewer7 .innerDrag").css('display','none');
        $("#viewer8").css('border','');$("#viewer8 .innerDrag").css('display','none');
        Log4Debug("RemoveDivBorder");
        iCurrentDiv.removeClass("DivSelected");
    }
 }
 function RemoveInnerText(divID){
    Log4Debug("RemoveInnerText");
    $("#"+divID+" .innerDrag").css('display','none');
 /*
    var t1=$("#"+divID).html();
    if(t1!=null){
        var t2=t1.replace("Drag item here","");
        t2=t2.replace("Dragging item here","");
        $("#"+divID).html(t2);
    }
  */  
 }

 function CreateCollageHtml(xml){
    var html = "";
    $(xml).find('design').each(function () {
	                    var sID = $(this).find('ID').text();
	                    var sImage = picDesignImgPath + $(this).find('Image').text();
	                    var sTitle = $(this).find('Title').text();
	                    var sInspiration = $(this).find('Inspiration').text();
	                    var sUsername = $(this).find('Username').text();
	                    var sShareCount = $(this).find('ShareCount').text();
	                    var urlPage = "CollageReview.aspx";
	                   // console.log("stitle=" + sTitle);
	                    html += '<div class="item by-designer">';
	                    html += '<div class="box">';
	                    html += '<div class="pic-box">';
	                    html += '<a href="collageReview.aspx?design_id=' + sID + '" class="imglink"><img height="224" src="' + sImage + '" alt=""></a>';
	                    html += '<div class="floatDiv" style="top:-110px">';
	                    // html += '<a href="#" class="love" title="Favorite">Favorite</a><a href="#" class="down" title="Save to Store">Save to Store</a>';
	                    html += '<a href="javascript:void(0)" onclick="FavoriteCollage(\'' + sID + '\')" class="love" title="Favorite">Favorite</a>';
	                    html += '</div>';
	                    html += '</div>';
	                    html += '<div class="row row1"><a href="#">' + sTitle + '</a></div>';
	                    html += '<div class="row row2">'+sInspiration+'</div>';
	                    html += '<div class="row row3 clearfix">';
	                    html += '<div class="zt2">Designer：<a href="#">'+sUsername+'</a></div>';
	                    html += '</div>';
	                    html += '<div class="row row4 clearfix">';
	                    html += '<div class="zt2"><span class="fr"><span class="table">';
	                    html += '<table>';
	                    html += '<tr><th colspan="7">Reward Calculation For Example</th></tr>';
	                    html += '<tr><td>Sales</td><td></td><td>Level 3</td><td>Designer</td><td></td><td></td><td>Cash Rewards</td></tr>';
	                    html += '<tr><td>$60</td><td>*</td><td>6%</td><td>* 50%</td><td></td><td>=</td><td><b>$2.4</b></td></tr>';
	                    html += '</table>';
	                    html += '</span>';
	                    html += '<a href="javascript:void(0)" onclick="ShareCollage(' + sID + ',\'' + sTitle + '\',\'' + sImage + '\',\'' + urlPage + '\',\'' + sInspiration + '\')"  class="share-btn">Share & Earn</a></span>';
	                    html += '<span class="fl">Shared <font class="share-color">' + sShareCount + '</font>&nbsp;&nbsp;times</span>';
	                    html += '</div>';
	                    html += '</div>';
	                    html += '</div>';
	                    html += '</div>';
	                    
	                    
	                    //console.log("html="+html);
	                });
        return html;

 }

 function Collage_orderBy(iSortOrder){
 //1 -->publish time 2-->Name
         var iPage = 1;
        $.ajax({
	    type: "POST",
	    url: "CollageLoadDesign.ashx",
	    data: "{ 'action':'" + "load_sort_publish"
                    + "','page':'" + iPage
                    + "','pageDiv':'" + pageDiv 
                    + "','sort_type':'" + iSortOrder 
	            +"'}",
	    dataType: "xml"
	}).done(function (xml) {
	    var html = CreateCollageHtml(xml);
	                
	    $minUl.html(html);
	});

 }