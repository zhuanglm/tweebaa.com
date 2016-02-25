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
var picProductPath = "";
var picDesignImgPath = "/upload/UploadImg"
var picShareDesignImgPath = "https://tweebaa.com"

var templatePath = "https://tweebaa.com/Collage/TempImg/";
var backgroundPath = "/Collage/DesignBackgroundImg6";
var DecorationPath = "/Collage/DesignDecorationImg/";

var prdName = "";
var cate = "";
var state = "";
var step = "";
var pageDiv = 21;
var pageDecorationDiv = 16;
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

function Clone_Image(){

alert("clone");
}

function CloseDraftPopup() {

    $("#Save2Draft").parents(".greybox").hide();
}
function FavoriteCollage(sDesignID) {

    var _data = "{ action:'" + 'add_collage_favorite' + "',id:'" + sDesignID + "'}";

    $.ajax({
        type: "POST",
        url: '/AjaxPages/FavoriteAjax.aspx',
        data: _data,
        dataType: "text",
        success: function (resu) {
            if (resu == "success") {
                AlertEx("This item has been saved to your Favorites. To access, just log in to your account and select 'My Favorites'.");
                //                $("#labfav").html("Favorited successfully");              
                //                $("#tck5").parents(".greybox").show()
                //                $("#tck5").animate({ top: "2%" }, 300)
            }
            else if (resu == "-1") {
                AlertEx("Please login");
                //                $("#labfav").html("Please log in!");
                //                $("#tck5").parents(".greybox").show()
                //                $("#tck5").animate({ top: "2%" }, 300)
            }
            else {
                AlertEx("Failed to favorite");
                //                $("#labfav").html("Failed to favorite");
                //                $("#tck5").parents(".greybox").show()
                //                $("#tck5").animate({ top: "2%" }, 300)
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            AlertEx("Failed to favorite");
        }
    });


}

function generatShareEn(type, link, title, image, desc, record) {
    var shareUrl = "";
    var facebookAppID = "1591110677840145";
    //var descNoCR = desc.replace(/[\n\r]/g, "<br/>");

    var parmRecord = "";
    if(desc.length<1) desc=title;
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
                    "&redirect_uri=https://www.tweebaa.com/CloseWindow.htm";
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
    //jctest
    //return false;
}



function SaveCollageShareUrl2DB(type, prdid, prdname, prdimg, page, desc, isLogin, userGuid) {
    var shareUrl = "";
    var host = "https://www.tweebaa.com";//window.location.host;
    var title = encodeURIComponent(prdname);
    //var link = host + "/Product/" + page + "?id=" + prdid;
    var link = "https://www.tweebaa.com/Product/" + page + "?id=" + prdid;
    var image = prdimg;
    var _data = "{ action:'" + "share_collage"
                    + "',proid:'" + prdid
                    + "',url:'" + link
                    + "',isLogin:'" + isLogin
                    + "',userGuid:'" + userGuid
                    + "',type:'" + type + "'}";
    $.ajax({

        type: "POST",
        url: '/Product/CollageShareHandler.ashx',
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
    $("#shareToFacebook").unbind( "click" );
    $("#shareToFacebook").click(function () {
        shareUrl = SaveCollageShareUrl2DB(type, prdid, prdname, prdimg, page, desc, isLogin, userGuid);
        Log4Debug(shareUrl);
       // window.location.href = shareUrl;
       window.open(shareUrl, '_blank');
    });
}
if (type == "twitter") {
    $("#shareToTwitter").unbind( "click" );
    $("#shareToTwitter").click(function(){
        shareUrl = SaveCollageShareUrl2DB(type, prdid, prdname, prdimg, page, desc, isLogin, userGuid);
        //window.location.href = shareUrl;
        window.open(shareUrl, '_blank');
    });
}
if (type == "google") {
    $("#shareToGoogle").unbind( "click" );
    $("#shareToGoogle").click(function(){
        shareUrl = SaveCollageShareUrl2DB(type, prdid, prdname, prdimg, page, desc, isLogin, userGuid);
        window.open(shareUrl, '_blank');
       // window.location.href = shareUrl;
    });
}
if (type == "pinterest") {
    $("#shareToPinterest").unbind( "click" );
    $("#shareToPinterest").click(function(){
        shareUrl = SaveCollageShareUrl2DB(type, prdid, prdname, prdimg, page, desc, isLogin, userGuid);
        window.open(shareUrl, '_blank');
        //window.location.href = shareUrl;
    });
}
if (type == "email") {
    $("#shareToEmail").unbind( "click" );
    $("#shareToEmail").click(function(){
        shareUrl = SaveCollageShareUrl2DB(type, prdid, prdname, prdimg, page, desc, isLogin, userGuid);
        window.open(shareUrl, '_blank');
       // window.location.href = shareUrl;
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
    if (userid!=null && userid.length > 4) {
        isLogin = "1";
    }

    //alert(saleprice);
    //alert(persent);
    var saleprice = 0.01; // Need to update
    if (persent != "") {
        var getP = saleprice * persent;
        if(getP >0){
            $("#sharePercent").html("$" + getP);
        }else{
            $("#sharePercent").html("");
        }
    } else {
        $("#sharePercent").html("");
    }


    //  SetCollageShareLink(txt_id, name, img, page, desc, prdPrice, isLogin, userid)
    if (SetCollageShareLink(sID, sTitle, sImage, urlPage, sInspiration,saleprice, isLogin, userid) == true) {
    /*
        $("#share-tck2").parents(".greybox").show();
        $("#share-tck2").animate({ top: "2%" }, 300);*/
        $("#dialogShare").modal("show");
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
            } else if (curUrl.indexOf("collageshare.aspx") != -1) {
                window.location.href = "../user/login.aspx?op=collageshare";
            }
            else {
                // cannot come here
                loginNow = false;
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

    return img_src;//img_src.replace("UploadImg/", "");
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

       // LoadDesignData(sHtml);

        if (readonly == 2) {
            // RemoveDivBorder();
            var sUsername = $(xml).find('Username').text();
            var sCity = $(xml).find('City').text();
            var sCountry = $(xml).find('Country').text();
            var sTitle =RemoveCRLF( $(xml).find('Title').text());

            //picShareDesignImgPath
            var sShareImage =$(xml).find('Image').text();

            var sImage = picDesignImgPath + $(xml).find('Image').text();
            if(sShareImage.indexOf("http://") >=0){

            }else{
                //sImage = picDesignImgPath + sImage
                sShareImage = picShareDesignImgPath + sImage;
            }
            var sInspiration =RemoveCRLF( $(xml).find('Inspiration').text());
            $("#txtDesignerInfo").html(sUsername + "  " + sCity + "," + sCountry);

            var isValid = $("#DesignIsValid").val();


            var sProduct_IDs = $(xml).find('Product_IDS').text();
            /*
            var sProduct_ID2 = $(xml).find('Product_ID2').text();
            var sProduct_ID3 = $(xml).find('Product_ID3').text();
            var sProduct_ID4 = $(xml).find('Product_ID4').text();


            var sProduct_ID5 = $(xml).find('Product_ID5').text();
            var sProduct_ID6 = $(xml).find('Product_ID6').text();
            var sProduct_ID7 = $(xml).find('Product_ID7').text();
            var sProduct_ID8 = $(xml).find('Product_ID8').text();*/

            /*
            var html = '<a href="javascript:void(0)" onclick="ShareCollage(' + sID + ',\'' + sTitle + '\',\'' + sShareImage + '\',\'' + "CollageReview.aspx" + '\',\'' + sInspiration + '\')"  class="yellow-share fr">Share & Earn</a>';
            $("#link_share_earn").html(html);
            */
            $("#link_share_earn").click(function () {
                ShareCollage(sID , sTitle , sShareImage , "CollageReview.aspx" , sInspiration );
            });

            var isThisProductValid = 1;

            LoadProductsByIDs(sProduct_IDs);
            /*
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
            }*/
        }
    });

}
function LoadProductsByIDs(sProductIDs) {
    var iPage = 1;
    var isThisProductValid = 1;
    $.ajax({
        type: "Post",
        url: "CollageComments.ashx",
        data: "{'action':'load_products','cate':'" + cate
                    + "','prdName':'" + sProductIDs
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
            var iCurrent=i+1;
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
                /*
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
                }*/
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

                    /*
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
                    */

                    html = '<li class="item">';
                    html += '<a href="preSaleBuy.aspx?id=' + prd.prdGuid + sShareID + '" ><img class="img-responsive" src="' + imgPath + '" alt=""></a>';
                    html += '<div class="product-description-v2">';
                    html += '<div class="margin-bottom-5">';
                    html += '<h4 class="title-price"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + sShareID + '" >'+prd.name+'</a></h4>';
                    html += '<span class="title-price">$' + saleprice + '</span>';
                    html += '</div>';    
                    /*
                    html += '<ul class="list-inline product-ratings">';
                    html += '<li><i class="rating-selected fa fa-star"></i></li>';
                    html += '<li><i class="rating-selected fa fa-star"></i></li>';
                    html += '<li><i class="rating-selected fa fa-star"></i></li>';
                    html += '<li><i class="rating fa fa-star"></i></li>';
                    html += '<li><i class="rating fa fa-star"></i></li>';
                    html += '</ul>';   */ 
                    html += '</div>';
                    html += '</li>';

                }

                else if (prdState == "6") {
                    //等待上架中
                    /*
                    html = '<div class="item sale-success"><div class="box"><div class="pic-box"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + sShareID + '"   class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv" style="top:-110px"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a> <a href="#" style="display:none;" class="down" title="Download">Download</a> <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + saleprice + ')" class="share" title="Share">Share</a></div></div><div class="row row1"><a href="#">' + prd.name + '</a></div><div class="row row2"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + '"  class="imglink">' + prd.txtjj + '</a></div><div class="row row3 clearfix"><div class="zt1"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + '"  class="gotoShopCar" title="Add to Cart">Add to Cart</a> <del>$' + estimateprice + '</del> <strong class="color">$' + saleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt1"><div class="jdt"><span style="width:100%"></span></div><span class="fr">Waiting to be listed</span> <span class="color fl">Test-Sale Successful</span></div></div><i class="hot" style="display:none;"></i></div></div>';
                    */
                    html = '<li class="item">';
                    html += '<a href="preSaleBuy.aspx?id=' + prd.prdGuid + sShareID + '" ><img class="img-responsive" src="' + imgPath + '" alt=""></a>';
                    html += '<div class="product-description-v3">';
                    html += '<div class="margin-bottom-5">';
                    html += '<h4 class="title-price"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + sShareID + '" >'+prd.name+'</a></h4>';
                    html += '<span class="title-price">$' + saleprice + '</span>';
                    html += '</div>';    
                    /*
                    html += '<ul class="list-inline product-ratings">';
                    html += '<li><i class="rating-selected fa fa-star"></i></li>';
                    html += '<li><i class="rating-selected fa fa-star"></i></li>';
                    html += '<li><i class="rating-selected fa fa-star"></i></li>';
                    html += '<li><i class="rating fa fa-star"></i></li>';
                    html += '<li><i class="rating fa fa-star"></i></li>';
                    html += '</ul>';   */ 
                    html += '</div>';
                    html += '</li>';
                }

                else if (prdState == "7") {
                    //Test-Sale Failed     
                   //disable links and no
                    html = '<div class="item sale-failure"><div class="box"><div class="pic-box"><img src="' + imgPath + '" alt=""><div class="floatDiv" style="top:-110px"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a> <a href="#" style="display:none;" class="down" title="Download">Download</a> <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + saleprice + ')"  class="share" title="Share">Share</a></div></div><div class="row row1">' + prd.name + '</div><div class="row row2">' + prd.txtjj + '</div><div class="row row3 clearfix"><div class="zt2"><a class="fr waiting-btn" href="#">Contact</a> <del>$' + estimateprice + '</del> <strong class="color">$' + estimateprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><div class="jdt"><span></span></div><span class="fl">Test-Sale Failed</span></div></div><i class="hot" style="display:none;"></i></div></div>';

                }
                else if (prdState == "3") {
                    urlPage = "'saleBuy.aspx'";
                    //销售中
                   // html = '<div class="item sales-ing"><div class="box"><div class="pic-box"><a href="saleBuy.aspx?id=' + prd.prdGuid + sShareID + '"  class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')"  title="Favorite">Favorite</a> <a href="#" style="display:none;" class="down" title="Download">Download</a> <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')" class="share" title="Share & Earn">Share</a></div></div><div class="row row1"><a href="#">' + prd.name + '</a></div><div class="row row2"><a href="saleBuy.aspx?id=' + prd.prdGuid + '" class="imglink">' + prd.txtjj + '</a></div><div class="row row3 clearfix"><div class="zt2"><a href="preSaleBuy.aspx?id=' + prd.prdGuid + '"  class="gotoShopCar" title="Add to Cart">Add to Cart</a> <strong class="color">$' + minfinalsaleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><a href="javascript:;" class="loveNumber" title="like">' + prd.favoritecount + '</a></span> <span class="fl">Sold：' + prd.saleCount + ' pieces</span> <span class="color">Buy Now</span></div></div></div></div>';
                    html = '<li class="item">';
                    html += '<a href="SaleBuy.aspx?id=' + prd.prdGuid + sShareID + '" ><img class="img-responsive" src="' + imgPath + '" alt=""></a>';
                    html += '<div class="product-description-v2">';
                    html += '<div class="margin-bottom-5">';
                    html += '<h4 class="title-price"><a href="saleBuy.aspx?id=' + prd.prdGuid + sShareID + '" >'+prd.name+'</a></h4>';
                    html += '<span class="title-price">$' + saleprice + '</span>';
                    html += '</div>';    
                    /*
                    html += '<ul class="list-inline product-ratings">';
                    html += '<li><i class="rating-selected fa fa-star"></i></li>';
                    html += '<li><i class="rating-selected fa fa-star"></i></li>';
                    html += '<li><i class="rating-selected fa fa-star"></i></li>';
                    html += '<li><i class="rating fa fa-star"></i></li>';
                    html += '<li><i class="rating fa fa-star"></i></li>';
                    html += '</ul>';   */ 
                    html += '</div>';
                    html += '</li>';
                }

                $("#products_lists").append(html);
                // $minUl = getMinUl();
                // $minUl.append(html);

            }
            OwlCarousel.initOwlCarousel();

        },
        error: function (obj) {
            //alert("Load failed");
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
        var stotal = $(xml).find('total').text();
        Log4Debug("total=" + stotal);
        var iTotal = Math.ceil(stotal / pageDiv);
        //make pages
        var i = 0; 
        var html = '<li><a href="#" class="up">&lt;</a></li>';

        for (i = 1; i <= iTotal; i++) {
            if (i == 1) {
                html += '<li><a href="#" id="BN_' + i + '" class="on" onclick="BackgroundPageNavigate(' + i + ')" >' + i + '</a></li>';
            } else {

                html += '<li><a href="#" id="BN_' + i + '" onclick="BackgroundPageNavigate(' + i + ')">' + i + '</a></li>';
            }
        }
        html += '<li><a href="#" class="down">&gt;</a></li>';
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
        + "','pageDiv':'" + "16"
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


function BackgroundPageNavigate(iPage) {
    //previous page remove class
    $("#BN_" + iPrevPageBG).removeClass("on");
    LoadBackgroundImg(iPage);
    $("#BN_" + iPage).addClass("on");
    iPrevPageBG = iPage;
}
function DecorationPageNavigate(iPage,type) {
    //previous page remove class
    $("#DN_" + iPrevPageDe).removeClass("on");
    LoadDecorationImg(iPage,type);
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
      + "','pageDiv':'" + "16"
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
        
        //console.log("sid="+sID+" html="+sInnerHTML);
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
	                    var sTitle = RemoveCRLF($(this).find('Title').text());
	                    var sInspiration = RemoveCRLF($(this).find('Inspiration').text());
	                    var sUsername = $(this).find('Username').text();
	                    var sShareCount = $(this).find('ShareCount').text();
	                    var urlPage = "CollageReview.aspx";
	                   // console.log("stitle=" + sTitle);
	                    html += '<div class="item by-designer">';
	                    html += '<div class="box">';
	                    html += '<div class="pic-box">';
	                    html += '<a href="CollageReview.aspx?design_id=' + sID + '" class="imglink"><img height="224" src="' + sImage + '" alt=""></a>';
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
     if(iSortOrder==1){
        $("#spanSortType").html("Publish Time");
     }
     if(iSortOrder==2){
        $("#spanSortType").html("Name");
     }
     iSortBy=iSortOrder;
     DoSearch();

 }
 //----------------------------------------------------------------------------------------------------------------------------------------------------
 function load_category(cate_guid){
    $("#btnCategoryBack").show();
    document.getElementById("txtCategoryKeywords").value="";
    cate = cate_guid;
    prdName='';
    GetTotalCount();
}

 function Load_Category_list()
 {
     var szCategoryList=new Array("/images/main/Electronics.jpg",
     "/images/main/Apparel.jpg",
     "/images/main/Garden.jpg",
     "/images/main/Toys.jpg",
     "/images/main/Tools.jpg",
     "/images/main/Arts.jpg",
     "/images/main/Household.jpg",
     "/images/main/AUTOMOTIVE.jpg",
     "/images/main/pets.jpg",
     "/images/main/Sports.jpg",
     "/images/main/Office.jpg",
     "/images/main/Green.jpg",
     "/images/main/Clean.jpg",
     "/images/main/Children.jpg",   
     "/images/main/health.jpg"
     );
     var szGuid=new Array("'1608AC1B-786A-4596-9DEE-04FC45131332'",
     "'3EE6A6A4-933A-42BA-9C53-07F6AEE27ED2'",
     "'4036D9BF-F178-45BB-94F0-1693923AE9B5'",
     "'C9590D3C-F179-413A-AC5B-24DB7EEB2A1A'",
     "'5D01EB4D-7E33-4381-B993-45988262CB92'",
     "'B984BDA6-A0A7-4CD2-9EDD-6D1B33EFC3AD'",
     "'1382D416-6E2D-4708-8557-7F226EDBDC13'",
     "'f5527740-ed0e-4f9b-b7b9-a8222e5ea31c'",
     "'1F728092-0771-431D-81B2-A9B7D3DDE7FE'",
     "'EA786CE8-9664-48CC-A22D-B1BB5957F0E2'",
     "'1E12E85A-F86C-4243-8446-C5F33B19E454'",
     "'FDAC6A4C-86D4-4DBB-857C-F52831F846B1'",
     "'7DEE69E4-6103-4E16-A0CC-FB065473183D'",
     "'F66C02B2-3441-4D71-8328-5A5129E73D2A'",
     "'C781386B-DBD9-4257-9EB6-8D74ED61A9C1'"
     );                                             
     var html='';
     
     //html+='<div class="tab-pane fade in active" id="Pro1">';
     var catagory;
     for (catagory in szCategoryList)
     {
        if(catagory%4==0) html+='<div class="row margin-bottom-20">';
        html+='<div class="col-sm-3">';
        html+='<div class="thumbnails thumbnail-style thumbnail-kenburn">';
        html+='<div class="thumbnail-img">';
        html+='<div class="overflow-hidden">';
        html+='<a href="#" onclick="load_category('+szGuid[catagory]+')"><img class="img-responsive" src="'+szCategoryList[catagory]+ '"alt=""></a>';
        html+=' </div></div></div></div>';
        if(catagory%4==3) html+='</div>';
     }
     html+=' </div></div>';
     $("#ProductsList").html(html);
     $("#ProductsPage").hide();
}


 function load_decoration(cate_guid)
 {
    $("#btnDecorationBack").show();
    cate = cate_guid;
    LoadDecorationImgTotal(cate_guid);
    //GetTotalCount();
}

function Load_Decoration_html()
{
     var szDecorationList=new Array("/images/main/events.jpg",
     "/images/main/dec.jpg",
     "/images/main/arrows.jpg",
     "/images/main/background.jpg");
     
     var szGuid=new Array(4,2,3,5);

     var html='';
     var decoration;
     for (decoration in szDecorationList)
     {
        if(decoration%4==0) html+='<div class="row margin-bottom-20">';
        html+='<div class="col-sm-3">';
        html+='<div class="thumbnails thumbnail-style thumbnail-kenburn">';
        html+='<div class="thumbnail-img">';
        html+='<div class="overflow-hidden">';
        html+='<a href="#" onclick="load_decoration('+szGuid[decoration]+')"><img class="img-responsive" src="'+szDecorationList[decoration]+ '"alt=""></a>';
        html+=' </div></div></div></div>';
        if(decoration%4==3) html+='</div>';
     }
     html+=' </div></div>';
     $("#DecorationList").html(html);
     $("#DecorationPage").hide();
}


function LoadDecorationImgTotal(type) {
    $.ajax({
        type: "POST",
        url: "CollageLoadTemplate.ashx",
        data: "{ 'action':'" + "load_decoration_total"  + "','type':'" + type+ "'}",
        dataType: "xml"
    }).done(function (xml) {
        var stotal = $(xml).find('total').text();
        Log4Debug("total=" + stotal);
        var iTotal = Math.ceil(stotal / pageDecorationDiv);
        //make pages
        var i = 0; var html ='';
        if(iTotal>5) html+='<li><a href="#" class="up">&lt&lt;</a></li>';

        for (i = 1; i <= iTotal; i++) {
            if (i == 1) {
                html += '<li><a href="#" id="DN_' + i + '" class="on" onclick="DecorationPageNavigate(' + i +','+type+ ')" >' + i + '</a></li>';
            } else {

                html += '<li><a href="#" id="DN_' + i + '" onclick="DecorationPageNavigate(' + i + ','+type+')">' + i + '</a></li>';
            }
        }
        if(iTotal>5) html += '<li><a href="#" class="down">&gt&gt;</a></li>';
        $("#DecorationPage").hide();
        $("#DecorationPage").html(html);
        //load first page
        LoadDecorationImg(1,type);


    });
}
function LoadDecorationImg(iPage,type) {
    $.ajax({
        type: "POST",
        url: "CollageLoadTemplate.ashx",
        data: "{ 'action':'" + "load_decoration"
        + "','page':'" + iPage
        + "','pageDiv':'" + pageDecorationDiv
        + "','type':'" + type
        + "'}",
        dataType: "xml"
    }).done(function (xml) 
    {
        var html = "";
        var i=0;
        
        $(xml).find('Decoration').each(function () 
        {
            var sID = $(this).find('ID').text();
            var sImage = $(this).find('Image').text();
            if(i%4==0)
            {
                html += '<div class="row margin-bottom-20">';
            }
            html += '<div class="col-sm-3">';
            //html+='<a href="#" onclick="addElement(&apos;image&apos;,&apos;'+DecorationPath + sImage+'&apos;,&apos;'+sImage+'&apos;)">';
            html+='<a href="#" onclick="yourDesigner.addElement(&apos;image&apos;,&apos;'+DecorationPath + sImage+'&apos;,&apos;'+sImage+'&apos;)">';
            html+='<img class="load_decoration" id = "'+sImage+'"src="'+ DecorationPath + sImage +'" height="80px" width="80px"/>';
            html += '</a></div>';
            if(i%4==3)
            {
                html += '</div>';
            }
            i++;
        });
        $("#DecorationList").html(html);
        //$('.load_decoration').click(function () {
        //});
        $('.load_decoration').draggable({
            revert : true,
             opacity: 0.35
        });

         $('#divWorkingArea').droppable({
          drop: function( event, ui ) {
            var elem=ui.draggable;
            var sImage=elem.attr('src');
            var sImageName=elem.attr('id');
            yourDesigner.addElement('image',sImage,sImageName);
            }
         });

        $("#DecorationPage").show();
    });
}


function GetTotalCount() {
    $.ajax({
        type: "Post",
        url: "/AjaxPages/prdSaleAjax.aspx",
        data: "{'action':'reviewPrdCount_Collage','cate':'" + cate
                    + "','prdName':'" + prdName
                    + "','state':'" + step
                    + "','focusCateIDs':'"
                    + focusCateIDs
                    + "','orderby':'"
                    + orderby 
                    + "','page':'"
                    + page
                    + "'}",
        success: function (resu) {
            //showSearchResult(resu);
            Log4Debug("result=" + resu);

            if (resu > 0) 
            {
                iTotalPage = Math.ceil(resu / pageDiv);
                //make pages

                var i = 0; 

                var html = '';
                if(iTotalPage>5) html+='<li><a href="#" class="up" onclick="ProductPageNavigate(1,'+iTotalPage+')">&lt&lt;</a></li>';

                for (i = 1; i <6; i++) 
                {
                    if (i == 1) 
                    {
                        html += '<li><a href="#" id="PN_' + i + '" class="on" onclick="ProductPageNavigate(' + i +','+iTotalPage+ ')" >' + i + '</a></li>';
                    }
                     else if(i<=iTotalPage)
                     {
                        html += '<li><a href="#" id="PN_' + i + '" onclick="ProductPageNavigate(' + i +','+iTotalPage+ ')">' + i + '</a></li>';
                    }
                }
                if(iTotalPage>5)
                {
                    html += '<li><a href="#" onclick="ProductPageNavigate(' + (i +1)+ ','+iTotalPage+')">...</a></li>';
                    html += '<li><a href="#" class="down" onclick="ProductPageNavigate('+iTotalPage+','+iTotalPage+')">&gt&gt;</a></li>';
                }


                $("#ProductsPage").hide();
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


function GetProductsList(iPage) 
{
    $.ajax({
        type: "Post",
        url: "/AjaxPages/prdSaleAjax.aspx",
        data: "{'action':'reviewPrd_Collage','cate':'" + cate
                    + "','prdName':'" + prdName
                    + "','state':'" + step
                    +"','pageSize':'16','focusCateIDs':'" + focusCateIDs
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
                var imgPath = picProductPath + GetVirtualImgFolder(prd.fileurl.replace("big", "mid2"));
                imgPath = imgPath.replace(".jpg",".png");
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

                if(i%4==0){
                    html += '<div class="row margin-bottom-20">';
                }
                
               //imgPath=imgPath.replace("mid2","big");
                prdname=prdname.replace(new RegExp("\"","gm"),"&quot;");
                prdname=prdname.replace(new RegExp("\'","gm"),"");
                prdname=prdname+"|ID="+prd.prdGuid;
                var twbimg=imgPath;
                //twbimg=twbimg.replace("67.224.94.82","www.tweebaa.com");
                //twbimg=twbimg.replace("mid2","mid");
                html += '<div class="col-sm-3">';
                html+='<a href="#" onclick="yourDesigner.addElement(&apos;image&apos;,&apos;'+twbimg+'&apos;,&apos;'+prdname+'&apos;)">';
                html+='<img class = "load_products" id ='+prdname+' src="'+ imgPath +'" height="80px" width="80px"/>';
                html += '</a></div>';
                if(i%4==3){
                    html += '</div>';
                }

            }
            
            $("#ProductsList").html(html);
            $('.load_products').draggable({
                revert : true,
                 opacity: 0.35
            });

             $('#divWorkingArea').droppable({
              drop: function( event, ui ) {
                var elem=ui.draggable;
                var sImage=elem.attr('src');
                var sPrdName=elem.attr('id');
                yourDesigner.addElement('image',sImage,sPrdName);
                }
             });

            $("#ProductsPage").show();
        },
        error: function (obj) {
            //alert("Load failed");
        }
    });
}
//------------------------------------------------------
function ProductPageNavigate(iPage,iTotalPage) 
{
       if(iTotalPage>5)
       {
           var i = 0; 
           var html = '';
           html+='<li><a href="#" class="up" onclick="ProductPageNavigate(1,'+iTotalPage+')">&lt&lt;</a></li>';
           if(iPage>3)
           {
                html += '<li><a href="#" id="PN_' + iPage + '" onclick="ProductPageNavigate(' + (iPage-3) +','+iTotalPage+ ')" >...</a></li>';
           }
           var CurPage=iPage;
           if(iPage<3) CurPage=3;
           if(iPage>=iTotalPage-2) CurPage=iTotalPage-2;
           
           for (i = -2; i <=2; i++) 
           {
                html += '<li><a href="#" id="PN_' + (i+CurPage) + '" onclick="ProductPageNavigate(' + (i+CurPage) +','+iTotalPage+ ')" >' + (i+CurPage) + '</a></li>';
           }
           if(iPage<=iTotalPage-3)
           {
                html += '<li><a href="#" id="PN_' + iPage + '" onclick="ProductPageNavigate(' + (iPage+3) +','+iTotalPage+ ')" >...</a></li>';
           }
           html += '<li><a href="#" class="down" onclick="ProductPageNavigate('+iTotalPage+','+iTotalPage+')">&gt&gt;</a></li>';
            $("#ProductsPage").html(html);
       }       

    //previous page remove class
    $("#PN_" + iPrevPage).removeClass("on");
    GetProductsList(iPage);
    $("#PN_" + iPage).addClass("on");
    iPrevPage = iPage;
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
    cate='';
    GetTotalCount();
}


function AddText()
{
    var sText=$("#OwnText").val();
    if(sText.length>0)
    {
        yourDesigner.addElement('text',sText,sText,{colors:'#000000',font:'Arial'});
         document.getElementById('OwnText').value="";
    }
}
function UploadImg()
{
     $('#design-upload').click();
 }
 function Publish()
 {
        var txtUserID = $("#userID").val();
        if (txtUserID.length>2)
        {
            InputTitle();
        }
        else
        {
            $("#save_and_login").modal("show");
        }

 }
 function SaveAndLogin()
 {
            yourDesigner. save_draft();
            window.location.href = "/User/login.aspx";

 }
 function InputTitle()
 {
        var Base64Img= yourDesigner.getProductDataURL('png', '#ffffff');
        var html;
        html=" <img src='"+Base64Img+"' width='250' height = '250'>";
        $("#collage_thumbnail").html(html);
        $("#publish").modal("show");
 }
 
function PublishCollage() 
{
        var txtTitle=escapeHtml($("#collage_title").val());
        var txtUserID = $("#userID").val();
        if(txtTitle.length>=2 )//inputed title and logged in
        {
            var dataURL = yourDesigner.getProductDataURL('png', '#ffffff');
            var txtThumbnail;
            var txtProduct="";;
	    var product = yourDesigner.getProduct(false);
            if(product[0].elements.length<1)
            {
                $("#publish").modal("hide");
                return;
            }
            for(var i=0; i<product[0].elements.length;++i)
             {
	        var title = product[0].elements[i].title;
                var split=title.split("|ID=");
                if(split.length>1)
                {
                    var id=split[1];
                    txtProduct+=id;
                    txtProduct+="|";
                }
            }

            $.ajax({
                    type: "POST",
                    url: "CollageSaveFile.ashx",
                    data: {
                            'imgBase64': dataURL
                    }
            }).done(function(o) {
                    txtThumbnail = o;
                   // var txtDesignID = 88888;
                    var datastring =escapeHtml( $("#collage_title").val());
                    var txtTemplateID ="";
                    var txtDescription=escapeHtml($("#collage_description").val()) ;

                    $.ajax({
                            type: "POST",
                            url: "CollageSaveDraft.ashx",
                            data: "{'action':'save_publish','txtTitle':'" 
                            + txtTitle 
                            + "','txtDfaftInspiration':'" 
                            + txtDescription
                            + "','txtFormData':'" 
                            + '0' 
                            + "','txtTemplateID':'" 
                            + '0' 
                            + "','txtUserID':'" 
                            + txtUserID 
                            + "','txtThumbnail':'" 
                            + txtThumbnail     
                            + "','txtProducts':'" + txtProduct
                            + "'}"
                    }).done(function(o) {
                            Log4Debug('saved:' + o);
                            if (o == 1) {
                                    window.location.href = "/Product/CollageShare.aspx";
                                    // $("#save_draft_info").html("Your Draft Saved!");
                            } 
                    });
            });
        }
        else
        {
                var html;
                html="Enter title <text ><font color=red size =2>*More than 2 letters required</font></text>"
                $("#enter_collage_title").html(html);
        }


}

function pageSizeSelect(size) {
    pageDiv = size;
    $("#spanPageSize").html(size);
    DoSearch();
}