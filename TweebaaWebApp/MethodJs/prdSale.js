var step = ""; //评审区产品状态：1大众评审；4推易吧评审；5评审失败
var page = 1; //页码
var orderby = "ranking desc "; //排序条件
var picPath = "https://tweebaa.com/";
$(document).ready(
   function () {

       $("#presale_popup1").hide();

       var Request = new Object();
       Request = GetRequest();
       step = Request["step"];
       if (step == null) {
           step = "";
       }
       loadByFocus();
       LoadSearchByCate();
       loadMeinv("");
       //无限加载
       $(window).on("scroll", function () {
           $minUl = getMinUl();
           //if ($minUl.height() <= $(window).scrollTop() + $(window).height()) {
           if ($(document).height() == $(window).scrollTop() + $(window).height()) {
               // auto load next page if scroll to the end of the page
               page = page + 1;
               loadMeinv(); //加载新图片
           }
       })
       //点击更多加载
       $("#down-more").click(function () {
           page = page + 1;
           $minUl = getMinUl();
           loadMeinv("");
           return false;
       });

       // to search by enter key
       $("#txtPrdname").keyup(function (event) {
           if (event.which == 13) {
               serch();
               $("#txtPrdname").focus();

           }
       });

   });

   function RemoveMouseover() {
       $('#mainsrp-itemlist .presale-ing').poshytip('disable');

   }
   function LoadPresaleMouseOver() {

       var i = $.cookie("presale_popshow");

       if (i == undefined || i < 1 || isNaN(i)) {


            var dvPresal = $('#mainsrp-itemlist .presale-ing');
            if (dvPresal != null) {
                dvPresal.poshytip({
                    className: 'presale_popup',
                    bgImageFrameSize: 11,
                    alignY: 'bottom',
                    content: function (updateCallback) {
                        var sHtml = $('#presale_popup1').html();
                        //Log4Debug(sHtml);
                        return sHtml;
                    }
                });
            }
        }

   }
//排序
function orderBy(obj) {
    var orderStr = $(obj).html();
    if (orderStr == "By Ranking") { orderby = "ranking desc "; };
    if (orderStr == "By Time") { orderby = "addtime desc "; };
    if (orderStr == "By Price") { orderby = "saleprice desc "; };
    if (orderStr == "By Name") { orderby = "name asc "; };
    if (orderStr == "By Evaluators") { orderby = "saleCount desc "; };
    if (orderStr == "By clicks") { orderby = "saleCount desc "; };
    $("#mainsrp-itemlist .items").empty();
    page = 1;
    loadMeinv("");
}
function serch() {
    page = 1;
    $("#mainsrp-itemlist .items").empty();
    loadMeinv("");
}
function SerchPrdByCate(cateID) {
    $("#mainsrp-itemlist .items").empty();
    loadMeinv(cateID);

}

function loadByFocus() {
    //var byFocus =["Twee-Tech Products (Electronics & Gadgets)", "Aha! Products (Daily Problem Solvers)", "Novel-twee (Unique products to evoke smiles)", "Un-Breathable (Prices that take your breath away)"];
    //var byFocusHtml=""
    //for (var i=0; i<byFocus.length; i++) {
    //     byFocusHtml = byFocusHtml +
    //       '<label><input type="checkbox" name="optByFocus[]" value="' + i.toString() + '" />' + byFocus[i] + '</label>' + '\n';
    //    $("div.multiselect").html(byFocusHtml);
    //}
    $.ajax({
        type: "Post",
        url: "../../AjaxPages/prdReviewAjax.aspx",
        data: "{'action':'getFocusCate'}",
        success: function (resu) {
            if (resu == "") {
                return;
            }
            var obj = eval("(" + resu + ")");
            var byFocusHtml = "";
            for (var i = 0; i < obj.length; i++) {
                var focusCate = obj[i];
                var focusCateID = focusCate.focusCateID;
                var focusCateName = focusCate.name;
                var focusCateNote = focusCate.note;
                byFocusHtml = byFocusHtml +
                     '<label>&nbsp;<input type="checkbox" name="optByFocus" onclick="serch();" value="' + focusCateID.toString() + '" />&nbsp;' + focusCateName + " " + focusCateNote + '</label>' + '\n';
            }
            $("div.multiselect").html(byFocusHtml);
        },
        error: function (obj) {
            // alert("Load failed");
        }
    });

}

function GetShortDesc(descFull) 
{
    // do no break a work
    var descShort = descFull.substring(0, 80);
    if (descFull.length > 80) {
        for (var i = 80; i < descFull.length; i++) {
            var t = descFull.substring(i, i + 1);
            if (t == " ") break;
            descShort = descShort + t;
        }
    }
    return descShort;
}

function showSearchResult(count) {
    var cntProduct = parseInt(count);
    searchResultHtml = "Your search matched " + cntProduct + " result";
    if (cntProduct > 1) searchResultHtml = searchResultHtml + "s";
    searchResultHtml = searchResultHtml + "."
    $("#searchResult").html(searchResultHtml);
}

function loadMeinv(cateID) {
    var prdName = $("#txtPrdname").val();
    var cate = cateID;
    var state = step;

    //orderBy = orderBy == "" ? "addtime desc " : orderBy;
    if ( orderby == null || orderby == "") orderby = "ranking desc ";

    // get three level category ID
    var prdCate1 = $("#prdType1 option:selected").val();
    var prdCate2 = $("#prdType2 option:selected").val();
    var prdCate3 = $("#prdType3 option:selected").val();

    if (prdCate1 == "-1") prdCate1 = "";
    if (prdCate2 == "-1") prdCate2 = "";
    if (prdCate3 == "-1") prdCate3 = "";

    // get multiple selected by focus category
    var focusCateIDs = [];
    $("#chkBoxList input:checkbox:checked").map(function () {
        focusCateIDs.push($(this).val());
    });

    // get total count
    $.ajax({
        type: "Post",
        url: "../AjaxPages/prdSaleAjax.aspx",
        data: "{'action':'reviewPrdCount','cate':'" + cate
                    + "','prdName':'" + prdName
                    + "','state':'" + step
                    + "','focusCateIDs':'" + focusCateIDs
                    + "','prdCate1':'" + prdCate1
                    + "','prdCate2':'" + prdCate2
                    + "','prdCate3':'" + prdCate3
                    + "','orderby':'"
                    + orderby + "','page':'"
                    + page
                    + "'}",
        success: function (resu) {
            showSearchResult(resu);
        },
        error: function (obj) {
            //alert("Load failed");
        }
    });




    // get/show paging data list
    $.ajax({
        type: "Post",
        url: "../AjaxPages/prdSaleAjax.aspx",
        data: "{'action':'reviewPrd','cate':'" + cate
                    + "','prdName':'" + prdName
                    + "','state':'" + step
                    + "','focusCateIDs':'" + focusCateIDs
                    + "','prdCate1':'" + prdCate1
                    + "','prdCate2':'" + prdCate2
                    + "','prdCate3':'" + prdCate3
                    + "','orderby':'"
                    + orderby + "','page':'"
                    + page
                    + "'}",
        success: function (resu) {
            if (resu == "") {
                return;
            }
            var obj = eval("(" + resu + ")");

            for (var i = 0; i < obj.length; i++) {
                var prd = obj[i];

                var ishot = "none;";
                var IsFreeShipping = "none";
                var IsLimitedTime = "none";
                var IsComingSoon = "none";
                //alert(prd.IsFreeShipping); alert(prd.IsLimitedTime); alert(prd.IsComingSoon);
                if (prd.hottip == "yes")
                    ishot = "block;";
                if (prd.IsFreeShipping == true)
                    IsFreeShipping = "block;";
                if (prd.IsLimitedTime == true)
                    IsLimitedTime = "block;";
                if (prd.IsComingSoon == true)
                    IsComingSoon = "block;";

                var tagIco = '<i class="hot"  style="display:' + ishot + '"></i><i class="freeship" style="display:' + IsFreeShipping + '"></i><i class="limited" style="display:' + IsLimitedTime + '"></i><i class="comesoon" style="display:' + IsComingSoon + '"></i>';

                var prdid = "'" + prd.prdGuid + "'";
                var prdname = "'" + escape(prd.name) + "'";
                var imgPath = picPath + prd.fileurl.replace("big", "mid2");
                var prdimg = "'" + imgPath + "'";
                //var presaleendtime = prd.presaleendtime.replace(/-/g, '/').substring(0, 10);
                var time = prd.presaleendday;
                if (time == null || time == "") { time = "0"; }
                var prdState = prd.wnstat;
                var estimateprice = prd.estimateprice.toFixed(2);
                var saleprice = prd.saleprice.toFixed(2);
                if (estimateprice == null) { estimateprice = 0.00; }
                if (saleprice == null) { saleprice = 0.00; }

                var favoriteCount = 0;
                if (prd.favoriteCount != null) favoriteCount = prd.favoriteCount

                var minfinalsaleprice = 0.00;
                if (prd.minfinalsaleprice != null) {
                    minfinalsaleprice = prd.minfinalsaleprice.toFixed(2);
                }
                var html = "";
                var urlPage = "'presaleBuy.aspx'";

                var prdDesc = "'" + escape(prd.txtjj) + "'";

                //var productNameStyle = 'style="height:35px; line-height:110%"';

                if (prdState == "2") {
                    //预售中

                    // progress
                    var testSaleProgress = (prd.saleCount / prd.presaleForward) * 100;
                    if (testSaleProgress < 1) testSaleProgress = 1;
                    if (testSaleProgress > 100) testSaleProgress = 100;
                    var testSaleLeftCount = prd.presaleForward - prd.saleCount;

                    // left days
                    var leftDays = "";
                    if (time <= 0) leftDays = " Time Over";
                    else leftDays = " Days left: " + time;

                    html = '<div class="item presale-ing">'
                    html += '<div class="box"><div class="pic-box">';
                    html += '<a href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink">';
                    html += '<img src="' + imgPath + '" alt=""></a><div class="floatDiv">';
                    html += '<a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')"  title="Favorite">Favorite</a> ';
                    html += '<a href="#" style="display:none;" class="down" title="Download">Download</a> ';
                    html += '<a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" class="share" title="Share & Earn">Share</a>';
                    html += '</div></div><div class="row row1"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></div>';
                    html += '<div class="row row2">'
                    html += '<a href="presaleBuy.aspx?id=' + prd.prdGuid + '"  class="imglink">' + GetShortDesc(prd.txtjj) + '...Read more</a></div>';
                    html += '<div class="row row3 clearfix"><div class="zt1"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '"  class="gotoShopCar" title="Add to Cart">Add to Cart</a>';
                    html += '<del>$' + estimateprice + '</del> <strong class="color">$' + saleprice + '</strong><img src="../Images/hour-glass.png" style="float:right; margin-right:7px;" /></div></div><div class="row row4 clearfix"><div class="zt1"><div class="jdt"><span style="width:' + testSaleProgress + '%"></span></div><span class="fr">' + leftDays + '</span> <span class="fl">Test-Sale Units left: ' + testSaleLeftCount + '</span> </div></div>' + tagIco + '</div></div>';
                    html += '';

                }

                else if (prdState == "6") {
                    //等待上架中
                    html = '<div class="item sale-success"><div class="box"><div class="pic-box"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv" style="top:-110px"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a> <a href="#" style="display:none;" class="down" title="Download">Download</a> <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + saleprice + ')" class="share" title="Share">Share</a></div></div><div class="row row1"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></div><div class="row row2"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '"  class="imglink">' + GetShortDesc(prd.txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt1"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '"  class="gotoShopCar" title="Add to Cart">Add to Cart</a> <del>$' + estimateprice + '</del> <strong class="color">$' + saleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt1"><div class="jdt"><span style="width:100%"></span></div><span class="fr">Waiting to be listed</span> <span class="color fl">Test-Sale Successful</span></div></div>' + tagIco + '</div></div>';
                }

                else if (prdState == "7") {
                    //Test-Sale Failed     
                    html = '<div class="item sale-failure"><div class="box"><div class="pic-box"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '"  class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv" style="top:-110px"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a> <a href="#" style="display:none;" class="down" title="Download">Download</a> <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + saleprice + ')"  class="share" title="Share">Share</a></div></div><div class="row row1"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></div><div class="row row2"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '" class="imglink">' + GetShortDesc(prd.txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt2"><a class="fr waiting-btn" href="#">Contact</a> <del>$' + estimateprice + '</del> <strong class="color">$' + estimateprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><div class="jdt"><span></span></div><span class="fl">Test-Sale Failed</span></div></div>' + tagIco + '</div></div>';

                }
                else if (prdState == "3") {
                    urlPage = "'saleBuy.aspx'";
                    //销售中               
                    var priceMSRP = '<del>$' + estimateprice + '</del>&nbsp;&nbsp;';
                    if (estimateprice == saleprice) priceMSRP = "";
                    //html = '<div class="item sales-ing"><div class="box"><div class="pic-box"><a href="saleBuy.aspx?id=' + prd.prdGuid + '"  class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')"  title="Favorite">Favorite</a> <a href="#" style="display:none;" class="down" title="Download">Download</a> <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')" class="share" title="Share & Earn">Share</a></div></div><div class="row row1"><a href="#">' + prd.name + '</a></div><div class="row row2"><a href="saleBuy.aspx?id=' + prd.prdGuid + '" class="imglink">' + GetShortDesc(prd.txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt2"><a href="saleBuy.aspx?id=' + prd.prdGuid + '"  class="gotoShopCar" title="Add to Cart">Add to Cart</a>' + priceMSRP + '<strong class="color">$' + minfinalsaleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><a href="javascript:;" class="loveNumber" title="like">' + favoriteCount + '</a></span> <span class="fl">Sold：' + prd.saleCount + ' pieces</span><a href="saleBuy.aspx?id=' + prd.prdGuid + '"><span class="color">Buy Now</span></a></div></div>' + tagIco + '</div></div>';
                    html = '<div class="item sales-ing"><div class="box"><div class="pic-box"><a href="saleBuy.aspx?id=' + prd.prdGuid + '"  class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')"  title="Favorite">Favorite</a> <a href="#" style="display:none;" class="down" title="Download">Download</a> <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')" class="share" title="Share & Earn">Share</a></div></div><div class="row row1" ><a href="saleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></div><div class="row row2"><a href="saleBuy.aspx?id=' + prd.prdGuid + '" class="imglink">' + GetShortDesc(prd.txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt2"><a href="saleBuy.aspx?id=' + prd.prdGuid + '"  class="gotoShopCar" title="Add to Cart">Add to Cart</a>' + priceMSRP + '<strong class="color">$' + minfinalsaleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><a href="javascript:;" class="loveNumber" title="like">' + favoriteCount + '</a></span><a href="saleBuy.aspx?id=' + prd.prdGuid + '"><span class="color">Buy Now</span></a></div></div>' + tagIco + '</div></div>';
                }


                $minUl = getMinUl();
                $minUl.append(html);

            }

            LoadPresaleMouseOver();
        },
        error: function (obj) {
            //alert("Load failed");
        }
    });

}

function getMinUl() {
    var $arrUl = $("#mainsrp-itemlist .items");
    var $minUl = $arrUl.eq(0);
    $arrUl.each(function (index, elem) {
        if ($(elem).height() < $minUl.height()) {
            $minUl = $(elem);
        }
    });
    return $minUl;
}








//分享动作
function SharePrd(id, name, img, page, desc, saleprice) {
    var cur_url = window.location.href.toLowerCase();
    
    name = unescape(name);
    var tip = true;
    var userid = $("#hiduserid").val();
    var persent = $("#hidpersent").val();
    if (persent != "") {
        var getP = saleprice * persent;
        $("#sharePercent").html("$" + getP);
    } else {
        $("#sharePercent").html("$0");
    }

    if (SetShareLink(id, name, img, page, desc, saleprice) == true) {
        $("#share-tck2").parents(".greybox").show();
        $("#share-tck2").animate({ top: "2%" }, 300);
    }
}


//Favorite    
function FavoritePrd(prdID) {

    var _data = "{ action:'" + 'add' + "',id:'" + prdID + "'}";   
    $.ajax({
        type: "POST",
        url: '../AjaxPages/FavoriteAjax.aspx',
        data: _data,
        dataType: "text",
        success: function (resu) {
            if (resu == "success") {
                alert("This item has been saved to your Favorites. To access, just log in to your account and select 'My Favorites'.");
            }
            else if (resu == "-1") {
                alert("Please log in!");
            }
            else {
                alert("Failed to favorite");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Failed to favorite");
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