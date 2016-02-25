var step = ""; //评审区产品状态：1大众评审；4推易吧评审；5评审失败
var page = 1; //页码
var orderby = "ranking desc"; //排序条件
var picPath = "https://tweebaa.com/";
var userShareLevel = 1;
var userShareRatio = 50;

$(document).ready(
   function () {
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

//排序
function orderBy(obj) {
    var orderStr = $(obj).html();
    if (orderStr == "By Ranking") { orderby = "ranking desc "; };
    if (orderStr == "By Time") { orderby = "addtime desc "; };
    if (orderStr == "By Price") { orderby = "saleprice desc "; };
    if (orderStr == "By Name") { orderby = "name asc "; };
    if (orderStr == "按销售数量") { orderby = "saleCount desc "; };
    if (orderStr == "按分享人数") { orderby = "shareCount desc "; };
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

function GetShortDesc(descFull) {
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

function GetUserShareGrade() {
    $.ajax({
        type: "Post",
        url: "../../AjaxPages/shareAjax.aspx",
        data: "{'action':'queryusersharegrade'}",
        async: false,
        success: function (resu) {
            var resuArr = resu.split(",");
            userShareLevel = parseInt(resuArr[0]);
            if (userShareLevel == 0) userShareLevel = 1;
            userShareRatio = parseInt(resuArr[1]);
        },
        error: function (obj) {
            // alert("Load failed");
        }
    });
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

    // get data count
    $.ajax({
        type: "Post",
        url: "../AjaxPages/prdShareAjax.aspx",
        async: false,
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
            // alert("Load failed");
        }
    });

    // get user share grade information
    GetUserShareGrade();

    // get and display product list
    $.ajax({
        type: "Post",
        url: "../AjaxPages/prdShareAjax.aspx",
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
                var prdid = "'" + prd.prdGuid + "'";
                var prdname = "'" + escape(prd.name) + "'";
                var imgPath = picPath + prd.fileurl.replace("big", "mid2");
                var prdimg = "'" + imgPath + "'";
                //var presaleendtime = prd.presaleendtime.replace(/-/g, '/').substring(0, 10);
                var time = prd.presaleendday;
                if (time == null || time == "") { time = "0"; }
                var prdState = prd.wnstat;

                var estimateprice = prd.estimateprice;
                if (estimateprice == null) { estimateprice = 0; }
                // convert to stand format of ####.## 
                estimateprice = parseFloat(estimateprice);
                estimateprice = estimateprice.toFixed(2);

                var saleprice = prd.saleprice;
                if (saleprice == null) { saleprice = 0; }
                // convert to stand format of ####.## 
                saleprice = parseFloat(saleprice);
                saleprice = saleprice.toFixed(2);

                var minfinalsaleprice = 0.00;
                if (prd.minfinalsaleprice != null) {
                    minfinalsaleprice = prd.minfinalsaleprice.toFixed(2);
                }

                var prdDesc = "'" + escape(prd.txtjj) + "'";

                var urlPage = "";
                var html = "";

                if (prdState == "2") { //预售中       
                    urlPage = "'presaleBuy.aspx'";

                    //html = '<div class="item sale-failure"><div class="box"><div class="pic-box"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink"><img  src="' + imgPath + '" alt=""></a><div class="floatDiv" style="top: -110px;"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a><a href="#" style="display:none;" class="down" title="Download">Download</a></div></div><div class="row row1"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></div><div class="row row2"><a  href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink">' + GetShortDesc(prd.txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt2"><span class="fr color">Test-Sale</span> <del>$' + estimateprice + '</del> <strong class="color">$' + saleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><span class="table"><table><tr><th colspan="5">Cash Reward Calculation For Example</th></tr><tr><td>All Wholesale</td><td></td><td>Level 3</td><td></td><td>Cash Reward</td></tr><tr><td>$6000</td><td>*</td><td>6%</td><td>=</td><td><b>$360</b></td></tr></table></span><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + +saleprice + ')" class="share-btn">Share & Earn</a></span><span class="fl">Shared <font class="share-color">' + prd.shareCount + '</font> times</span></div></div></div></div>';
                    html = '<div class="item sale-failure"><div class="box"><div class="pic-box"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink"><img  src="' + imgPath + '" alt=""></a><div class="floatDiv" style="top: -110px;"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a><a href="#" style="display:none;" class="down" title="Download">Download</a></div></div><div class="row row1"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></div><div class="row row2"><a  href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink">' + GetShortDesc(prd.txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt2"><span class="fr color">Test-Sale</span> <del>$' + estimateprice + '</del> <strong class="color">$' + saleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><span class="table">'
                          + '<table><tr><th colspan="5">Commission Example</th></tr>'
                          + '<tr><td>Your Friend&#39;s</td><td></td><td>Share</td><td></td><td>Cash</td></tr>'
                          + '<tr><td>Purchase</td><td></td><td>Level ' + userShareLevel + '</td><td></td><td>Reward</td></tr><tr><td>$' + saleprice + '</td><td>*</td><td>' + userShareRatio / 10 + '%</td><td>=</td><td><b>$' + (saleprice * userShareRatio / 1000).toFixed(2) + '</b></td></tr></table></span><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + +saleprice + ')" class="share-btn">Share & Earn</a></span></div></div></div></div>';
                }
                else if (prdState == "6") { //等待上架中  
                    urlPage = "'presaleBuy.aspx'";
                    //html = '<div class="item sale-success"><div class="box"><div class="pic-box"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv" style="top: -110px;"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a><a href="#" style="display:none;" class="down" title="Download">Download</a></div></div><div class="row row1"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></div><div class="row row2"><a  href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink">' + GetShortDesc(prd.txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt1"><span class="fr color">Waiting to be listed</span> <del>$' + estimateprice + '</del> <strong class="color">$' + saleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt1"><span class="fr"><span class="table">  <table><tr>  <th colspan="5">Cash Reward Calculation For Example</th></tr><tr>  <td>Sales Amount</td>  <td></td>  <td>Level 3</td>  <td></td>  <td>Cash Reward</td></tr><tr>  <td>$6000</td>  <td>*</td>  <td>6%</td>  <td>=</td>  <td><b>$360</b></td></tr>  </table></span><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + saleprice + ')" class="share-btn">Share & Earn</a></span><span class="fl">Shared <font class="share-color">' + prd.shareCount + '</font> times</span></div></div></div></div>';
                    html = '<div class="item sale-success"><div class="box"><div class="pic-box"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv" style="top: -110px;"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a><a href="#" style="display:none;" class="down" title="Download">Download</a></div></div><div class="row row1"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></div><div class="row row2"><a  href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink">' + GetShortDesc(prd.txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt1"><span class="fr color">Waiting to be listed</span> <del>$' + estimateprice + '</del> <strong class="color">$' + saleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt1"><span class="fr"><span class="table">'
                         + '<table><tr><th colspan="5">Commission Example</th></tr>'
                         + '<tr><td>Your Friend&#39;s</td><td></td><td>Share</td><td></td><td>Cash</td></tr>'
                         + '<tr><td>Purchase</td><td></td><td>Level ' + userShareLevel + '</td><td></td><td>Reward</td></tr><tr><td>$' + saleprice + '</td>  <td>*</td><td>' + userShareRatio / 10 + '%</td><td>=</td><td><b>$' + (saleprice * userShareRatio / 1000).toFixed(2) + '</b></td></tr>  </table></span><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + saleprice + ')" class="share-btn">Share & Earn</a></span></div></div></div></div>';
                }
                else if (prdState == "7") {  //预售失败   
                    urlPage = "'presaleBuy.aspx'";
                    //html = '<div class="item sale-failure"><div class="box"><div class="pic-box"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink"><img  src="' + imgPath + '" alt=""></a><div class="floatDiv" style="top: -110px;"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a><a href="#" style="display:none;" class="down" title="Download">Download</a></div></div><div class="row row1"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></div><div class="row row2"><a  href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink">' + GetShortDesc(prd.txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt2"><span class="fr color">Test-Sale Failed</span> <del>$' + estimateprice + '</del> <strong class="color">$' + saleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><span class="table"><table><tr><th colspan="5">Cash Reward Calculation For Example</th></tr><tr><td>All Wholesale</td><td></td><td>Level 3</td><td></td><td>Cash Reward</td></tr><tr><td>$6000</td><td>*</td><td>6%</td><td>=</td><td><b>$360</b></td></tr></table></span><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + saleprice + ')" class="share-btn">Share & Earn</a></span><span class="fl">Shared <font class="share-color">' + prd.shareCount + '</font> times</span></div></div></div></div>';
                    html = '<div class="item sale-failure"><div class="box"><div class="pic-box"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink"><img  src="' + imgPath + '" alt=""></a><div class="floatDiv" style="top: -110px;"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a><a href="#" style="display:none;" class="down" title="Download">Download</a></div></div><div class="row row1"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></div><div class="row row2"><a  href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink">' + GetShortDesc(prd.txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt2"><span class="fr color">Test-Sale Failed</span> <del>$' + estimateprice + '</del> <strong class="color">$' + saleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><span class="table">'
                         + '<table><tr><th colspan="5">Commission Example</th></tr>'
                         + '<tr><td>Your Friend&#39;s</td><td></td><td>Share</td><td></td><td>Cash</td></tr>'
                         + '<tr><td>Purchasee</td><td></td><td>Level ' + userShareLevel + '</td><td></td><td>Reward</td></tr><tr><td>$' + saleprice + '</td><td>*</td><td>' + userShareRatio / 10 + '%</td><td>=</td><td><b>$' + (saleprice * userShareRatio / 1000).toFixed(2) + '</b></td></tr></table></span><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + saleprice + ')" class="share-btn">Share & Earn</a></span></div></div></div></div>';
                }
                else if (prdState == "3") { //销售中  
                    urlPage = "'saleBuy.aspx'";
                    var priceMSRP = '<del>$' + estimateprice + '</del>&nbsp;&nbsp;';
                    if (estimateprice == saleprice) priceMSRP = "";
                    //html = '<div class="item sales-ing"><div class="box"><div class="pic-box"><a href="saleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a><a href="#" style="display:none;" class="down" title="Download">Download</a></div></div><div class="row row1"><a href="saleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></div><div class="row row2"><a  href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink">' + GetShortDesc(prd.txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt2"><a href="saleBuy.aspx?id=' + prd.prdGuid + '"><span class="fr color">Buy Now</span></a>' + priceMSRP + '<strong class="color">$' + minfinalsaleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><span class="table"><table><tr><th colspan="5">Cash Reward Calculation For Example</th></tr><tr><td>Sales Amount</td><td></td><td>Level 3</td><td></td><td>Cash Reward</td></tr><tr><td>$6000</td><td>*</td><td>6%</td> <td>=</td><td><b>$360</b></td></tr></table></span><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')" class="share-btn">Share & Earn</a></span><span class="fl">Shared <font class="share-color">' + prd.shareCount + '</font> times</span></div></div></div></div>';
                    html = '<div class="item sales-ing"><div class="box"><div class="pic-box"><a href="saleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a><a href="#" style="display:none;" class="down" title="Download">Download</a></div></div><div class="row row1"><a href="saleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></div><div class="row row2"><a  href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink">' + GetShortDesc(prd.txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt2"><a href="saleBuy.aspx?id=' + prd.prdGuid + '"><span class="fr color">Buy Now</span></a>' + priceMSRP + '<strong class="color">$' + minfinalsaleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><span class="table">'
                         + '<table><tr><th colspan="5">Commission Example</th></tr>'
                         + '<tr><td>Your Friend&#39;s</td><td></td><td>Share</td><td></td><td>Cash</td></tr>'
                         + '<tr><td>Purchase</td><td></td><td>Level ' + userShareLevel + '</td><td></td><td>Reward</td></tr><tr><td>$' + minfinalsaleprice + '</td><td>*</td><td>' + userShareRatio / 10 + '%</td> <td>=</td><td><b>$' + (minfinalsaleprice * userShareRatio / 1000).toFixed(2) + '</b></td></tr></table></span><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')" class="share-btn">Share & Earn</a></span></div></div></div></div>';
                }
                $minUl = getMinUl();
                $minUl.append(html);
            }
        },
        error: function (obj) {
            // alert("Load failed");
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

    //tip

    name = unescape(name);
    var tip = true;
    var userid = $("#hiduserid").val();
    var persent = $("#hidpersent").val();

    //alert(saleprice);
    //alert(persent);
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