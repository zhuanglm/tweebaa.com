﻿var step = "";  // "": ALL  2: Test-sale 3: Buy-now
var page = 1; //页码
var orderby = "ranking desc "; //排序条件

var sCategory1 = "";    // 第1层目录的ID for search
var sCategory2 = "";    // 第2层目录的ID for search
var sCategory3 = "";    // 第3层目录的ID for search

var sCatName1 = "";
var sCatName2 = "";
var sCatName3 = "";

var iShowType = 1;
var picPath = "https://tweebaa.com/";
var pageSize = 21;
var recordCount = 0;
var pageCount = 0;

$(document).ready(
   function () {
       var Request = new Object();
       Request = GetRequest();

       var action = Request["action"]; //ation=search
       if (action == null) {
           var sCate = $("#txtCateID").val();
           if (sCate.length > 10) {
               sCategory1 = $("#txtCateID").val();
           }
       } else {
           if (action == "search") {
               //get post category and keywords
               sCategory1 = $("#txtCateID").val();
               $("#txtPrdname").val($("#txtKeyword").val());
           }
       }
       step = Request["step"];
       if (step == null) {
           step = "";
       }

       LoadByFocusCate();
       //LoadCategoryTree();
       var lvlid1 = $("#txtCateIDLvL1").val();
       var lvlid2 = $("#txtCateIDLvL2").val();
       var lvlid3 = $("#txtCateIDLvL3").val();
       if (lvlid1 === undefined) lvlid1 = "";
       if (lvlid2 === undefined) lvlid2 = "";
       if (lvlid3 === undefined) lvlid3 = "";

       LoadCategoryTreeNodeOpen(lvlid1, lvlid2, lvlid3); //

       if (sCategory1.length > 10) {
           var iShow = $("#txtShowMain").val();
           if (iShow == 0) {
               DoSearchByCateID(sCategory1);
           }
       } else {
           //show main category ?
           var iShow = $("#txtShowMain").val();
           if (iShow == 0) {
               DoSearch();
           }
       }
       // to search by enter key
       $("#txtPrdname").keyup(function (event) {
           if (event.which == 13) {
               DoSearch();
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
    if (orderStr == "By Evaluators") { orderby = "saleCount desc "; };
    if (orderStr == "By clicks") { orderby = "saleCount desc "; };
    $("#spnSortBy").html(orderStr);
    $("#mainsrp-itemlist .items").empty();
    page = 1;
    DoSearch();
}

function showSearchResult(count) {

    var cntProduct = parseInt(count);
    searchResultHtml = "Your search matched " + cntProduct + " result";
    if (cntProduct > 1) searchResultHtml = searchResultHtml + "s";
    searchResultHtml = searchResultHtml + "."
    $("#searchResult").html(searchResultHtml);
    $("#searchResult").show();
    var iTotal = Math.ceil(count / pageSize);
    recordCount = count;
    pageCount = iTotal;
    
    // load first page
    LoadKKPager(1);

}

function LoadKKPager(page) {
    kkpager.generPageHtml({
        lang: {
            firstPageText: 'First',
            firstPageTipText: 'First',
            lastPageText: 'Last',
            lastPageTipText: 'Last',
            prePageText: 'Prev',
            prePageTipText: 'Prev',
            buttonTipBeforeText: 'Page ',
            buttonTipAfterText: '',
            nextPageText: 'Next',
            nextPageTipText: 'Next'
        }
                   ,
        pno: page,
        total: pageCount, //总页码
        //总数据条数
        totalRecords: recordCount,
        mode: 'click', //默认值是link，可选link或者click
        click: function (n) {
            page = n;
            LoadProductByPage(n);
            LoadKKPager(page);
            //this.selectPage(n); //手动选中按钮
            return false;
        }
    }, true);
    $("#topcontrol").trigger("click");
}

function DoSearchByCateID(sCat1) {
    page = 1;
    var iLevel = $("#iCategoryLeval").val();
    
    sCategory1 = ""; //need to reset it
    sCategory2 = ""; //need to reset it
    sCategory3 = ""; //need to reset it

    if (iLevel == 1) sCategory1 = sCat1;
    if (iLevel == 2) sCategory2 = sCat1;
    if (iLevel == 3) sCategory3 = sCat1;
    // consider user goes to product detail  page and press back button to the product list page
    /// shoud get the current search options.
    if ($("#ckbAll").is(":checked")) step = "";   // search all
    else if ($("#ckbLimited").is(":checked")) step = 2;  // search test-sale
    else if ($("#ckbBuyNow").is(":checked")) step = 3;     // search buy-now

    $("#divData").empty();
    LoadCount();
    LoadProductByPage(page);
}
function DoSearch() {
    page = 1;
    sCategory1 = ""; //need to reset it
    sCategory2 = ""; //need to reset it
    sCategory3 = ""; //need to reset it

    // consider user goes to product detail  page and press back button to the product list page
    /// shoud get the current search options.
    if ( $("#ckbAll").is(":checked") ) step = "" ;   // search all
    else if ($("#ckbLimited").is(":checked")) step = 2;  // search test-sale
    else if ($("#ckbBuyNow").is(":checked")) step = 3;     // search buy-now

    $("#divData").empty();
    LoadCount();
    LoadProductByPage(page);
}
//页大小选择

function pageSizeSelect(size) {
    pageSize = size;
    $("#spanPageSize").html(size);
    DoSearch();
}

function ckbAll(obj) {
        // all the tree check boxes should be radio button, now make them act like radio button
    //if ($(obj).attr('checked')) {
        step = "";
        $("#ckbAll").attr("checked", true);
        $("#ckbLimited").attr("checked", false);
        $("#ckbBuyNow").attr("checked", false);
        //}
    DoSearch();
}
function ckbLimeted(obj) {
    // all the tree check boxes should be radio button, now make them act like radio button
    // if ($(obj).attr('checked')) {
    step = 2;
        $("#ckbAll").attr("checked", false);
        $("#ckbLimited").attr("checked", true);
        $("#ckbBuyNow").attr("checked", false);
    //}
        DoSearch();
}
function ckbBuyNow(obj) {
    // all the tree check boxes should be radio button, now make them act like radio button
    //if ($(obj).attr('checked')) {
        step = 3;
        $("#ckbAll").attr("checked", false);
        $("#ckbLimited").attr("checked", false);
        $("#ckbBuyNow").attr("checked", true);
        //}

    DoSearch(); 
}

//function SearchPrdByCate(cateID) {
//    page = 1;
//    $("#mainsrp-itemlist .items").empty();
//   LoadCount(cateID);
//    LoadProductByPage(1);
//}

function DoSearchByCategory(cateID, layer) {
    page = 1;

    sCategory1 = "";
    sCategory2 = "";
    sCategory3 = ""; 

    if (layer == 1) sCategory1 = cateID; 
    else if (layer == 2) sCategory2 = cateID;
    else if (layer == 3) sCategory3 = cateID;
    //alert(cateID + " " + layer);
    //alert("1=" + sCategory1 + " 2=" + sCategory2 + " 3=" + sCategory3);
    

    var sLink = '<li><a href="/index.aspx">Home</a></li>';
    sLink = sLink + '<li><a href="/Product/prdSaleAll.aspx">Shop</a></li>';
    sLink = sLink + '<li><a href="/Product/Category.aspx">Category</a></li>';

    var sSubCategory = "";

    $.ajax({
        type: "GET",
        url: "/AjaxPages/prdCateAjax.aspx",
        data: "layer=-1",
        success: function (xml) {
            if (layer == 1) {
                sCategory1 = cateID;
                var node_lvl1 = $(xml).find('category_1').filter(function () {
                    return $(this).attr('category_guid') === sCategory1;
                });
                sCatName1 = node_lvl1.attr('category_name');
                sLink = sLink + '<li><a href="/Product/Category.aspx/' + Name2URL(ReplaceSpecial(sCatName1)) + '/' + sCategory1 + '">' + sCatName1 + '</a></li>';

                node_lvl1.children().each(function () {
                    console.log($(this).attr('category_name'));
                    console.log($(this).attr('category_guid'));
                    sSubCategory = sSubCategory + "<div class='sub_category'><a href='/Product/Category.aspx/";
                    sSubCategory = sSubCategory + Name2URL(ReplaceSpecial(sCatName1)) + "/";
                    sSubCategory = sSubCategory + Name2URL(ReplaceSpecial($(this).attr('category_name'))) + "/"
                    sSubCategory = sSubCategory + sCategory1 + "/";
                    sSubCategory = sSubCategory + $(this).attr('category_guid');
                    sSubCategory = sSubCategory + "'>";
                    sSubCategory = sSubCategory + ReplaceSpecial($(this).attr('category_name'));
                    sSubCategory = sSubCategory + "</a></div>";
                });

            }
            else if (layer == 2) {
                sCategory2 = cateID;
                var node_lvl2 = $(xml).find('category_2').filter(function () {
                    return $(this).attr('category_guid') === sCategory2;
                });
                sCatName2 = node_lvl2.attr('category_name');

                var node_lvl1 = $(xml).find('category_2').filter(function () {
                    return $(this).attr('category_guid') === sCategory2;
                }).parent();

                sCatName1 = node_lvl1.attr('category_name');
                sCategory1 = node_lvl1.attr('category_guid');
                sLink = sLink + '<li><a href="/Product/Category.aspx/' + Name2URL(ReplaceSpecial(sCatName1)) + '/' + sCategory1 + '">' + sCatName1 + '</a></li>';
                sLink = sLink + '<li><a href="/Product/Category.aspx/' + Name2URL(ReplaceSpecial(sCatName1)) + '/' + Name2URL(ReplaceSpecial(sCatName2)) + '/' + sCategory1 + '/' + sCategory2 + '">' + sCatName2 + '</a></li>';

                node_lvl2.children().each(function () {
                    console.log($(this).attr('category_name'));
                    console.log($(this).attr('category_guid'));
                    sSubCategory = sSubCategory + "<div class='sub_category'><a href='/Product/Category.aspx/";
                    sSubCategory = sSubCategory + Name2URL(ReplaceSpecial(sCatName1)) + "/";
                    sSubCategory = sSubCategory + Name2URL(ReplaceSpecial(sCatName2)) + "/";
                    sSubCategory = sSubCategory + Name2URL(ReplaceSpecial($(this).attr('category_name'))) + "/"
                    sSubCategory = sSubCategory + sCategory1 + "/";
                    sSubCategory = sSubCategory + sCategory2 + "/";
                    sSubCategory = sSubCategory + $(this).attr('category_guid');
                    sSubCategory = sSubCategory + "'>";
                    sSubCategory = sSubCategory + ReplaceSpecial($(this).attr('category_name'));
                    sSubCategory = sSubCategory + "</a></div>";
                });
            }
            else if (layer == 3) {
                sCategory3 = cateID;
                var node_lvl3 = $(xml).find('category_3').filter(function () {
                    return $(this).attr('category_guid') === sCategory3;
                });
                sCatName3 = node_lvl3.attr('category_name');

                var node_lvl2 = $(xml).find('category_3').filter(function () {
                    return $(this).attr('category_guid') === sCategory3;
                }).parent();
                sCategory2 = node_lvl2.attr('category_guid');
                sCatName2 = node_lvl2.attr('category_name');

                var node_lvl1 = $(xml).find('category_2').filter(function () {
                    return node_lvl2.attr('category_guid') === sCategory2;
                }).parent();
                sCategory1 = node_lvl1.attr('category_guid');
                sCatName1 = node_lvl1.attr('category_name');

                sLink = sLink + '<li><a href="/Product/Category.aspx/' + Name2URL(ReplaceSpecial(sCatName1)) + '/' + sCategory1 + '">' + sCatName1 + '</a></li>';
                sLink = sLink + '<li><a href="/Product/Category.aspx/' + Name2URL(ReplaceSpecial(sCatName1)) + '/' + Name2URL(ReplaceSpecial(sCatName2)) + '/' + sCategory1 + '/' + sCategory2 + '">' + sCatName2 + '</a></li>';
                sLink = sLink + '<li><a href="/Product/Category.aspx/' + Name2URL(ReplaceSpecial(sCatName1)) + '/' + Name2URL(ReplaceSpecial(sCatName2)) + '/' + Name2URL(ReplaceSpecial(sCatName3)) + '/' + sCategory1 + '/' + sCategory2 + '/' + sCategory3 + '">' + sCatName3 + '</a></li>';
            }

            $(".breadcrumb-v4-in").html(sLink);
            $("#id_sub_category").html(sSubCategory);

        },
        error: function (obj) {
            //alert("??");
        }
    });

    LoadCount();
    LoadProductByPage(1);
}

function GetShortDesc(descFull) 
{
    // do no break a work
    var descShort = descFull.substring(0, 80);
    //if (descFull.length > 80) 
    {
        for (var i = 80; i >0; i--) {
            var t = descShort.substring(i-1, i);
            if (t == " ") break;
            descShort = descShort.substring(0, i-1);//  + t;
        }
    }
    return descShort;
}
function show_by_list() {
    iShowType = 2;
    DoSearch();
}

function show_by_grid() {
    iShowType = 1;
    DoSearch();
}

var preSlaeCount = 0;
var saleCount = 0;

//function ProductPageNavigate(iPage) {
   // $("#BN_" + iPrevPage).removeClass("active");
//    LoadProductByPage(iPage);
    //$("#BN_" + iPage).addClass("active");
    //iPrevPage = iPage;
//}


function LoadProductByPage(iPage) {
    var prdName = $("#txtPrdname").val();
    var state = step;

    // get three level category ID
    var prdCate1 = sCategory1; 
    var prdCate2 = sCategory2; 
    var prdCate3 = sCategory3;


    // get multiple selected by focus category
    var focusCateIDs = [];
    $("#ulByFocus input:checkbox:checked").map(function () {
        focusCateIDs.push($(this).val());
    });

    // get/show paging data list
    $.ajax({
        type: "Post",
        url: "/AjaxPages/prdSaleAjax.aspx",
        data: "{'action':'reviewPrd','cate':'" + sCategory3
                    + "','prdName':'" + escape(prdName)
                    + "','state':'" + step
                    + "','focusCateIDs':'" + focusCateIDs
                    + "','prdCate1':'" + prdCate1
                    + "','prdCate2':'" + prdCate2
                    + "','prdCate3':'" + prdCate3
                    + "','orderby':'" + orderby
                    + "','page':'" + iPage
                    + "','pageSize':'" + pageSize
                    + "'}",
        success: function (resu) {
            if (resu == "") {
                //clear the contents
                $("#prd_listings").html("");
                // showSearchResult(0);
                return;
            }
            var obj = eval("(" + resu + ")");

            //showSearchResult(obj.length);

            var urlPage = "'submitReview.aspx'";
            html = '';
            for (var i = 0; i < obj.length; i++) {
                var prd = obj[i];
                var prdid = "'" + prd.prdGuid + "'";
                var prdname = "'" + escape(prd.name) + "'";
                var imgPath = picPath + prd.fileurl.replace("big", "mid");
                var prdimg = "'" + imgPath + "'";
                //var presaleendtime = prd.presaleendtime.replace(/-/g, '/').substring(0, 10);
                var time = prd.presaleendday;
                if (time == null || time == "") { time = "0"; }
                var prdState = prd.wnstat;


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
                var prdDescShort = GetShortDesc(prd.txtjj) + "...Read more";

                var urlPage = "";
                //var html = "";

                // do no display cross price if it is same as the sale price
                var htmlEstimatePrice = '';
                if (parseFloat(estimateprice) != parseFloat(saleprice)) {
                    htmlEstimatePrice = '<span class="title-price line-through-share" style="margin-left:5px; color:grey">$' + estimateprice + '</span>';
                }

                // favorite heart class
                var favoriteHeartClass = "fa-heart-o";
                if (prd.favoriteGuid != null && prd.favoriteGuid != "") favoriteHeartClass = "fa-heart";

                var favoriteClassID = "favoriteClass" + i.toString();

                var favoriteFunc = "FavoritePrdOnOff(" + prdid + ", '#" + favoriteClassID + "')";

                if (prdState == "2") {
                    //预售中

                    // progress

                    urlPage = "'presaleBuy.aspx'";

                    var testSaleProgress = (prd.saleCount / prd.presaleForward) * 100;
                    if (testSaleProgress < 1) testSaleProgress = 1;
                    if (testSaleProgress > 100) testSaleProgress = 100;
                    var testSaleLeftCount = prd.presaleForward - prd.saleCount;

                    // left days
                    var leftDays = "";
                    if (time <= 0) leftDays = " Time Over";
                    else leftDays = " Days left: " + time;
                    /*
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
                    html += '<del>$' + estimateprice + '</del> <strong class="color">$' + saleprice + '</strong><img src="../Images/hour-glass.png" style="float:right; margin-right:7px;" /></div></div><div class="row row4 clearfix">
                    <div class="zt1"><div class="jdt"><span style="width:' + testSaleProgress + '%"></span></div><span class="fr">' + leftDays + '</span> <span class="fl">Test-Sale Units left: ' + testSaleLeftCount + '</span> </div></div>' + tagIco + '</div></div>';
                    html += '';
                    */
                    if (iShowType == 1) {
                        ///////////////list by grid
                        if (i % 3 == 0) {
                            html = html + '<div class="row illustration-v2 margin-bottom-20">';
                        }

                        html = html + '<div class="col-md-4">';
                        html = html + '<div class="product-img product-img-brd">';
                        html = html + '<a href="/Product/presaleBuy.aspx?id=' + prd.prdGuid + '" ><img class="full-width img-responsive" src="' + imgPath + '" alt=""></a>';
                        //html = html + '<a class="product-review" href="presaleBuy.aspx?id=' + prd.prdGuid + '"  >Quick review</a>';
                        //html = html + '<a class="add-to-cart add-share" href="presaleBuy.aspx?id=' + prd.prdGuid + '"  ><i class="fa fa-shopping-cart"></i>Add to Cart</a>';
                        html = html + '<span class="add-to-cart" >';
                        html = html + '<a href="/Product/presaleBuy.aspx?id=' + prd.prdGuid + '" ><i class="icon-custom rounded-x fa fa-shopping-cart"></i></a>';
                        html = html + '<a href="javascript:void(0)" onclick="' + favoriteFunc + '"><i id="' + favoriteClassID + '" class="icon-custom rounded-x fa ' + favoriteHeartClass + '"></i> </a>';
                        var shareText = getExtraShoppingRewardPoint(minfinalsaleprice);
                        shareText = "'" + shareText + "'";
                        html = html + '<a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + shareText + ',' + prdDesc + ')"><i class=" icon-custom rounded-x fa fa-share-alt"></i></a>';
                        html = html + '</span>';


                        html = html + '</div>';
                        html = html + '<div class="product-description product-description-brd shop-height  margin-bottom-30">';
                        html = html + '<div class="overflow-h">';
                        html = html + '<div class=" margin-bottom-10">';
                        html = html + '<h4 class="title-price"><a href="/Product/presaleBuy.aspx?id=' + prd.prdGuid + '" >' + prd.name + '</a></h4>';
                        html = html + '</div> <div class="product-price">';
                   /*   html = html + '<a href="/Product/presaleBuy.aspx?id=' + prd.prdGuid + '" >' + GetShortDesc(prd.txtjj) + '...Read more</a></div> <div class="product-price">'; */

                        html = html + '<span class="title-price shop-red" >$' + saleprice + '</span>&nbsp;&nbsp;';
                        if (saleprice == estimateprice) {
                        } else {
                            html = html + '<del style="color:grey">$' + estimateprice + '</del>'
                        }
                        html = html + '<span class="time"><i class="fa fa-clock-o"></i> ' + leftDays + '</span>';

                        html = html + '  <div class="progress progress-u progress-xxs">';
                        html = html + '    <div class="progress-bar progress-bar-dark" role="progressbar" aria-valuenow="' + testSaleProgress + '" aria-valuemin="0" aria-valuemax="100" style="width: ' + testSaleProgress + '%">';
                        html = html + '    </div>';
                        html = html + '  </div>';
                        html = html + '  <h3 class="heading-xs">Test-Sale  ';
                        //html = html + '<span class="like-icon-share"><a data-original-title="Favorite" data-toggle="tooltip" data-placement="bottom" class="tooltips" href="javascript:void(0)" onclick="FavoritePrd(' + prdid + ')" ><i class="fa fa-heart"></i></a></span>';
                        //html = html + '<span class="like-icon-share"><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')" ><i class="fa fa-share-alt"></i></a></span>';
                        html = html + '<span class="pull-right">Units left: ' + testSaleLeftCount + '</span></h3>';

                        html = html + '</div>';
                        //html = html + '<img src="../Images/hour-glass.png" style="float:right; margin-left:3px;margin-right:3px;width:14px;height=18px" /><div class="zt1"><div class="jdt"><span style="width:' + testSaleProgress + '%"></span></div><span class="fr">' + leftDays + '</span> <span class="fl">Test-Sale Units left: ' + testSaleLeftCount + '</span> </div><div>' + tagIco + '</div>';
                        html = html + '</div>';
                       // html = html + '<div class="sharearn" style="margin-top:5px;"><a href="/College/sharer_commission.aspx" target="_blank"><span class="share"> Share & Earn</span> <span class="earn">Up to 10% commmission</span></a></div>';

                        html = html + '</div>';
                        html = html + '</div>';
                        /*
                        html = html + '<div class="col-md-4">';
                        html = html + '<div class="product-img product-img-brd">';
                        html = html + '<a href="submitReview.aspx?id=' + prd.prdguid + '" ><img class="full-width img-responsive" src="' + imgPath + '" alt=""></a>';
                        html = html + '<a class="product-review" href="submitReview.aspx?id=' + prd.prdguid + '">Quick review</a>';
                        html = html + '<a class="add-to-cart" href="submitReview.aspx?id=' + prd.prdguid + '" ><i class="fa fa-eye"></i>Evaluate</a>';
                        //  html = html + ' <div class="shop-rgba-dark-green rgba-banner"></div>';
                        html = html + '</div> ';
                        html = html + '<div class="product-description product-description-brd shop-height  margin-bottom-30">';
                        html = html + '<div class="overflow-h">';
                        html = html + '<div class="pull-left margin-bottom-10">';
                        html = html + ' <h4 class="title-price"><a href="submitReview.aspx?id=' + prd.prdguid + '" >' + prd.name + '</a></h4>';
                        html = html + '<span class="gender">' + prdDescShort + '</span></div>';
                        html = html + '<div class="product-price">';
                        html = html + '<span class="title-price"><strong>$' + prd.estimateprice + '</strong></span> ';
                        html = html + '<span class="like-icon"><a data-original-title="Favorite" data-toggle="tooltip" data-placement="bottom" class="tooltips" href="javascript:void(0)" onclick="FavoritePrd(' + prdid + ')"><i class="fa fa-heart"></i></a></span>';
                        html = html + '<span class="like-icon" ><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" ><i class="fa fa-share-alt"></i></a></span>';

                        html = html + '</div>';
                        html = html + '</div>';
                        html = html + '</div>';
                        html = html + '</div>';
                        */
                        if (i % 3 == 2) {
                            html = html + '</div>';
                        }
                        /////////////////list by grid EOF
                    } else {
                        html = html + '<div class="list-product-description product-description-brd shop-height  margin-bottom-30">';
                        html = html + '<div class="row">';
                        html = html + '    <div class="col-sm-4">';
                        html = html + '        <a href="/Product/presaleBuy.aspx?id=' + prd.prdGuid + '"><img class="img-responsive sm-margin-bottom-20" src="' + imgPath + '" alt=""></a>';
                        html = html + '    </div> ';
                        html = html + '    <div class="col-sm-8 product-description">';
                        html = html + '        <div class="overflow-h margin-bottom-5">';
                        html = html + '             <ul class="list-inline overflow-h">';
                        html = html + '                <li><h4 class="title-price"><a href="/Product/presaleBuy.aspx?id=' + prd.prdGuid + '" >' + prd.name + '</a></h4></li>';
                        /*
                        html = html + '                <li><span class="gender text-uppercase">'+prd.name+'</span></li>';
                       
                        html = html + '                <li class="pull-right">';
                        html = html + '                    <ul class="list-inline product-ratings">';
                        html = html + '                        <li><i class="rating-selected fa fa-star"></i></li>';
                        html = html + '                        <li><i class="rating-selected fa fa-star"></i></li>';
                        html = html + '                        <li><i class="rating-selected fa fa-star"></i></li>';
                        html = html + '                        <li><i class="rating fa fa-star"></i></li>';
                        html = html + '                        <li><i class="rating fa fa-star"></i></li>';
                        html = html + '                    </ul>';
                        html = html + '                </li>';
                        */
                        html = html + '            </ul>';
                        html = html + '            <p class="margin-bottom-20"><a href="/Product/presaleBuy.aspx?id=' + prd.prdGuid + '">' + prdDescShort + '</a></p>';
                        html = html + '            <div class="margin-bottom-10 product-price">';
                        html = html + '                <span class="title-price-shop margin-right-10"><strong>$' + saleprice + '</strong>' + htmlEstimatePrice + '</span>';
                        // html = html + '                <span class="title-price line-through">$95.00</span>';

                        html = html + '<span class="time"><i class="fa fa-clock-o"></i> ' + leftDays + '</span>';

                        html = html + '  <div class="progress progress-u progress-xxs">';
                        html = html + '    <div class="progress-bar progress-bar-red" role="progressbar" aria-valuenow="' + testSaleProgress + '" aria-valuemin="0" aria-valuemax="100" style="width: ' + testSaleProgress + '%">';
                        html = html + '    </div>';
                        html = html + '  </div>';
                        html = html + '  <h3 class="heading-xs">Test-Sale  ';
                        html = html + '<span class="pull-right">Units left: ' + testSaleLeftCount + '</span></h3>';

                        html = html + '            </div>';
                        //html = html + '            <div class="zt1" ><div class="jdt"><span style="width:' + testSaleProgress + '%"></span></div><span class="fl">Test-Sale Units left: ' + testSaleLeftCount + '</span><span class="fl" style="margin-left:10px">' + leftDays + '</span></div><div>' + tagIco + '</div><img src="../Images/hour-glass.png" style="float:left; margin-left:7px; height:18px" />';
                        html = html + '            <ul class="list-inline add-to-wishlist margin-bottom-20" style="padding-top:10px;">';
                        html = html + '                <li class="wishlist-in">';
                        html = html + '                    <i id="' + favoriteClassID + '"class="fa ' + favoriteHeartClass + '"></i>';
                        html = html + '                    <a href="javascript:void(0)" onclick="' + favoriteFunc + '">Add Favorite</a>';
                        html = html + '                </li>';
                        html = html + '                <li class="compare-in">';
                        html = html + '                    <i class="fa fa-share-alt"></i>';
                        var shareText = getExtraShoppingRewardPoint(minfinalsaleprice);
                        shareText = "'" + shareText + "'";
                        html = html + '                    <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + shareText + ',' + prdDesc + ')" >Share & Earn</a>';
                        html = html + '                </li>';
                        html = html + '            </ul>';
                        html = html + '            <a  class="btn-u btn-u-sea-shop" href="/Product/presaleBuy.aspx?id=' + prd.prdGuid + '"  ><i class="fa fa-shopping-cart"></i>&nbsp;&nbsp;Add to Cart</a>';
                        html = html + '        </div>';
                        //html = html + '<div class="sharearn" style="margin-top:5px;"><a href="/College/sharer_commission.aspx" target="_blank"><span class="share"> Share & Earn</span> <span class="earn">Up to 10% commmission</span></a></div>';
                        html = html + '    </div>';
                        html = html + '</div>';
                        html = html + '</div>';
                    }

                }

                else if (prdState == "6") {
                    //等待上架中
                    // html = '<div class="item sale-success"><div class="box"><div class="pic-box"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '"   class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv" style="top:-110px"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a> <a href="#" style="display:none;" class="down" title="Download">Download</a> <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + saleprice + ')" class="share" title="Share">Share</a></div></div><div class="row row1"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></div><div class="row row2"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '"  class="imglink">' + GetShortDesc(prd.txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt1"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '"  class="gotoShopCar" title="Add to Cart">Add to Cart</a> <del>$' + estimateprice + '</del> <strong class="color">$' + saleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt1"><div class="jdt"><span style="width:100%"></span></div><span class="fr">Waiting to be listed</span> <span class="color fl">Test-Sale Successful</span></div></div>' + tagIco + '</div></div>';
                    if (iShowType == 1) {
                        ///////////////list by grid
                        if (i % 3 == 0) {
                            html = html + '<div class="row illustration-v2 margin-bottom-20">';
                        }


                        html = html + '<div class="col-md-4">';
                        html = html + '<div class="product-img product-img-brd">';
                        html = html + '<a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '" ><img class="full-width img-responsive" src="' + imgPath + '" alt=""></a>';
                        //html = html + '<a class="product-review" href="saleBuy.aspx?id=' + prd.prdGuid + '" >Quick review</a>';
                        html = html + '<a class="add-to-cart add-share" href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '" ><i class="fa fa-shopping-cart"></i>&nbsp;&nbsp;Add to Cart</a>';
                        html = html + '</div>';
                        html = html + '<div class="product-description product-description-brd shop-height  margin-bottom-30">';
                        html = html + '<div class="overflow-h">';
                        html = html + '<div class=" margin-bottom-10">';
                        html = html + '<h4 class="title-price"><a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></h4>';
                        html = html + '</div> <div class="product-price">';
                      /*html = html + '<a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '">' + GetShortDesc(prd.txtjj) + '...Read more</a></div> <div class="product-price">'; */
                        html = html + '<span class="title-price">$' + minfinalsaleprice + '</span>';
                        html = html + htmlEstimatePrice + '<span class="like-icon-share"><a data-original-title="Favorite" data-toggle="tooltip" data-placement="bottom" class="tooltips" href="javascript:void(0)" onclick="' + favoriteFunc + '" ><i id="' + favoriteClassID + '" class="fa ' + favoriteHeartClass + '"></i></a></span>';
                        var shareText = getExtraShoppingRewardPoint(minfinalsaleprice);
                        shareText = "'" + shareText + "'";
                        html = html + '<span class="like-icon-share"><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + shareText + ',' + prdDesc + ')" ><i class="fa fa-share-alt"></i></a></span>';
                        html = html + '</div>';
                        html = html + '</div>';
                        html = html + '</div>';
                        html = html + '</div>';
                        /*
                        html = html + '<div class="col-md-4">';
                        html = html + '<div class="product-img product-img-brd">';
                        html = html + '<a href="submitReview.aspx?id=' + prd.prdguid + '" ><img class="full-width img-responsive" src="' + imgPath + '" alt=""></a>';
                        html = html + '<a class="product-review" href="submitReview.aspx?id=' + prd.prdguid + '">Quick review</a>';
                        html = html + '<a class="add-to-cart" href="submitReview.aspx?id=' + prd.prdguid + '" ><i class="fa fa-eye"></i>Evaluate</a>';
                        //  html = html + ' <div class="shop-rgba-dark-green rgba-banner"></div>';
                        html = html + '</div> ';
                        html = html + '<div class="product-description product-description-brd shop-height  margin-bottom-30">';
                        html = html + '<div class="overflow-h">';
                        html = html + '<div class="pull-left margin-bottom-10">';
                        html = html + ' <h4 class="title-price"><a href="submitReview.aspx?id=' + prd.prdguid + '" >' + prd.name + '</a></h4>';
                        html = html + '<span class="gender">' + prdDescShort + '</span></div>';
                        html = html + '<div class="product-price">';
                        html = html + '<span class="title-price"><strong>$' + prd.estimateprice + '</strong></span> ';
                        html = html + '<span class="like-icon"><a data-original-title="Favorite" data-toggle="tooltip" data-placement="bottom" class="tooltips" href="javascript:void(0)" onclick="FavoritePrd(' + prdid + ')"><i class="fa fa-heart"></i></a></span>';
                        html = html + '<span class="like-icon" ><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" ><i class="fa fa-share-alt"></i></a></span>';

                        html = html + '</div>';
                        html = html + '</div>';
                        html = html + '</div>';
                        html = html + '</div>';
                        */
                        if (i % 3 == 2) {
                            html = html + '</div>';
                        }
                        /////////////////list by grid EOF
                    } else {
                        html = html + '<div class="list-product-description product-description-brd shop-height  margin-bottom-30">';
                        html = html + '<div class="row">';
                        html = html + '    <div class="col-sm-4">';
                        html = html + '        <a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '"><img class="img-responsive sm-margin-bottom-20" src="' + imgPath + '" alt=""></a>';
                        html = html + '    </div> ';
                        html = html + '    <div class="col-sm-8 product-description">';
                        html = html + '        <div class="overflow-h margin-bottom-5">';
                        html = html + '             <ul class="list-inline overflow-h">';
                        html = html + '                <li><h4 class="title-price"><a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></h4></li>';
                        /*
                        html = html + '                <li><span class="gender text-uppercase">'+prd.name+'</span></li>';
                       
                        html = html + '                <li class="pull-right">';
                        html = html + '                    <ul class="list-inline product-ratings">';
                        html = html + '                        <li><i class="rating-selected fa fa-star"></i></li>';
                        html = html + '                        <li><i class="rating-selected fa fa-star"></i></li>';
                        html = html + '                        <li><i class="rating-selected fa fa-star"></i></li>';
                        html = html + '                        <li><i class="rating fa fa-star"></i></li>';
                        html = html + '                        <li><i class="rating fa fa-star"></i></li>';
                        html = html + '                    </ul>';
                        html = html + '                </li>';
                        */
                        html = html + '            </ul>';
                        html = html + '            <div class="margin-bottom-10">';
                        html = html + '                <span class="title-price margin-right-10"><strong>$' + minfinalsaleprice + '</strong></span>';
                        // html = html + '                <span class="title-price line-through">$95.00</span>';
                        html = html + '            </div>';
                        html = html + '            <p class="margin-bottom-20">' + prdDescShort + '</p>';
                        html = html + '            <ul class="list-inline add-to-wishlist margin-bottom-20">';
                        html = html + '                <li class="wishlist-in">';
                        html = html + '                    <i id="' + favoriteClassID + '" class="fa ' + favoriteHeartClass + '"></i>';
                        html = html + '                    <a href="javascript:void(0)" onclick="' + favoriteFunc + '">Add Favorite</a>';
                        html = html + '                </li>';
                        html = html + '                <li class="compare-in">';
                        html = html + '                    <i class="fa fa-share-alt"></i>';
                        var shareText = getExtraShoppingRewardPoint(minfinalsaleprice);
                        shareText = "'" + shareText + "'";
                        html = html + '                    <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + shareText + ',' + prdDesc + ')" >Share & Earn</a>';
                        html = html + '                </li>';
                        html = html + '            </ul>';
                        html = html + '            <a  class="btn-u btn-u-sea-shop" href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '" ><i class="fa fa-shopping-cart"></i>&nbsp;&nbsp;Add to Cart</a>';
                        html = html + '        </div>';
                        html = html + '    </div>';
                        html = html + '</div>';
                        html = html + '</div>';
                    }
                }

                else if (prdState == "7") {
                    //Test-Sale Failed     
                    // html = '<div class="item sale-failure"><div class="box"><div class="pic-box"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '"  class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv" style="top:-110px"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a> <a href="#" style="display:none;" class="down" title="Download">Download</a> <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + saleprice + ')"  class="share" title="Share">Share</a></div></div><div class="row row1"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></div><div class="row row2"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '" class="imglink">' + GetShortDesc(prd.txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt2"><a class="fr waiting-btn" href="#">Contact</a> <del>$' + estimateprice + '</del> <strong class="color">$' + estimateprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><div class="jdt"><span></span></div><span class="fl">Test-Sale Failed</span></div></div>' + tagIco + '</div></div>';
                    if (iShowType == 1) {
                        ///////////////list by grid
                        if (i % 3 == 0) {
                            html = html + '<div class="row illustration-v2 margin-bottom-20">';
                        }


                        html = html + '<div class="col-md-4">';
                        html = html + '<div class="product-img product-img-brd">';
                        html = html + '<a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '" ><img class="full-width img-responsive" src="' + imgPath + '" alt=""></a>';
                        //html = html + '<a class="product-review" href="saleBuy.aspx?id=' + prd.prdGuid + '" >Quick review</a>';
                        html = html + '<a class="add-to-cart add-share" href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '" ><i class="fa fa-shopping-cart"></i>&nbsp;&nbsp;Add to Cart</a>';
                        html = html + '</div>';
                        html = html + '<div class="product-description product-description-brd shop-height  margin-bottom-30">';
                        html = html + '<div class="overflow-h">';
                        html = html + '<div class=" margin-bottom-10">';
                        html = html + '<h4 class="title-price"><a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></h4>';
                        html = html + '  </div> <div class="product-price">';
          /*       html = html + '<a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '">' + GetShortDesc(prd.txtjj) + '...Read more</a></div> <div class="product-price">';  */
                        html = html + '<span class="title-price">$' + minfinalsaleprice + '</span>';
                        html = html + htmlEstimatePrice + '<span class="like-icon-share"><a data-original-title="Favorite" data-toggle="tooltip" data-placement="bottom" class="tooltips" href="javascript:void(0)" onclick="' + favoriteFunc + '" ><i id="' + favoriteClassID + '" class="fa ' + favoriteHeartClass + '"></i></a></span>';
                        html = html + '<span class="like-icon-share"><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')" ><i class="fa fa-share-alt"></i></a></span>';
                        html = html + '</div>';
                        html = html + '</div>';
                        html = html + '</div>';
                        html = html + '</div>';
                        /*
                        html = html + '<div class="col-md-4">';
                        html = html + '<div class="product-img product-img-brd">';
                        html = html + '<a href="submitReview.aspx?id=' + prd.prdguid + '" ><img class="full-width img-responsive" src="' + imgPath + '" alt=""></a>';
                        html = html + '<a class="product-review" href="submitReview.aspx?id=' + prd.prdguid + '">Quick review</a>';
                        html = html + '<a class="add-to-cart" href="submitReview.aspx?id=' + prd.prdguid + '" ><i class="fa fa-eye"></i>Evaluate</a>';
                        //  html = html + ' <div class="shop-rgba-dark-green rgba-banner"></div>';
                        html = html + '</div> ';
                        html = html + '<div class="product-description product-description-brd shop-height  margin-bottom-30">';
                        html = html + '<div class="overflow-h">';
                        html = html + '<div class="pull-left margin-bottom-10">';
                        html = html + ' <h4 class="title-price"><a href="submitReview.aspx?id=' + prd.prdguid + '" >' + prd.name + '</a></h4>';
                        html = html + '<span class="gender">' + prdDescShort + '</span></div>';
                        html = html + '<div class="product-price">';
                        html = html + '<span class="title-price"><strong>$' + prd.estimateprice + '</strong></span> ';
                        html = html + '<span class="like-icon"><a data-original-title="Favorite" data-toggle="tooltip" data-placement="bottom" class="tooltips" href="javascript:void(0)" onclick="FavoritePrd(' + prdid + ')"><i class="fa fa-heart"></i></a></span>';
                        html = html + '<span class="like-icon" ><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" ><i class="fa fa-share-alt"></i></a></span>';

                        html = html + '</div>';
                        html = html + '</div>';
                        html = html + '</div>';
                        html = html + '</div>';
                        */
                        if (i % 3 == 2) {
                            html = html + '</div>';
                        }
                        /////////////////list by grid EOF
                    } else {
                        html = html + '<div class="list-product-description product-description-brd shop-height  margin-bottom-30">';
                        html = html + '<div class="row">';
                        html = html + '    <div class="col-sm-4">';
                        html = html + '        <a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '"><img class="img-responsive sm-margin-bottom-20" src="' + imgPath + '" alt=""></a>';
                        html = html + '    </div> ';
                        html = html + '    <div class="col-sm-8 product-description">';
                        html = html + '        <div class="overflow-h margin-bottom-5">';
                        html = html + '             <ul class="list-inline overflow-h">';
                        html = html + '                <li><h4 class="title-price"><a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></h4></li>';
                        /*
                        html = html + '                <li><span class="gender text-uppercase">'+prd.name+'</span></li>';
                       
                        html = html + '                <li class="pull-right">';
                        html = html + '                    <ul class="list-inline product-ratings">';
                        html = html + '                        <li><i class="rating-selected fa fa-star"></i></li>';
                        html = html + '                        <li><i class="rating-selected fa fa-star"></i></li>';
                        html = html + '                        <li><i class="rating-selected fa fa-star"></i></li>';
                        html = html + '                        <li><i class="rating fa fa-star"></i></li>';
                        html = html + '                        <li><i class="rating fa fa-star"></i></li>';
                        html = html + '                    </ul>';
                        html = html + '                </li>';
                        */
                        html = html + '            </ul>';
                        html = html + '            <div class="margin-bottom-10">';
                        html = html + '                <span class="title-price margin-right-10"><strong>$' + minfinalsaleprice + '</strong></span>';
                        // html = html + '                <span class="title-price line-through">$95.00</span>';
                        html = html + '            </div>';
                        html = html + '            <p class="margin-bottom-20">' + prdDescShort + '</p>';
                        html = html + '            <ul class="list-inline add-to-wishlist margin-bottom-20">';
                        html = html + '                <li class="wishlist-in">';
                        html = html + '                    <i id="' + favoriteClassID + '" class="fa ' + favoriteHeartClass + '"></i>';
                        html = html + '                    <a href="javascript:void(0)" onclick="' + favoriteFunc + '">Add Favorite</a>';
                        html = html + '                </li>';
                        html = html + '                <li class="compare-in">';
                        html = html + '                    <i class="fa fa-share-alt"></i>';
                        html = html + '                    <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" >Share & Earn</a>';
                        html = html + '                </li>';
                        html = html + '            </ul>';
                        html = html + '            <a  class="btn-u btn-u-sea-shop" href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '" ><i class="fa fa-shopping-cart"></i>&nbsp;&nbsp;Add to Cart</a>';
                        html = html + '        </div>';
                        html = html + '    </div>';
                        html = html + '</div>';
                        html = html + '</div>';
                    }

                } else if (prdState == "3") { //销售中 
                    urlPage = "'saleBuy.aspx'";
                    //var priceMSRP = '<del>$' + estimateprice + '</del>&nbsp;&nbsp;';
                    if (iShowType == 1) {
                        ///////////////list by grid
                        if (i % 3 == 0) {
                            html = html + '<div class="row illustration-v2 margin-bottom-20">';
                        }


                        html = html + '<div class="col-md-4">';
                        html = html + '<div class="product-img product-img-brd">';
                        html = html + '<a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '" ><img class="full-width img-responsive" src="' + imgPath + '" alt=""></a>';
                        //html = html + '<a class="product-review" href="saleBuy.aspx?id=' + prd.prdGuid + '" >Quick review</a>';
                        //html = html + '<a class="add-to-cart add-share" href="saleBuy.aspx?id=' + prd.prdGuid + '" ><i class="fa fa-shopping-cart"></i>Add to Cart</a>';
                        html = html + '<span class="add-to-cart" >';
                        html = html + '<a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '"><i class="icon-custom rounded-x fa fa-shopping-cart"></i></a>';
                        html = html + '<a href="javascript:void(0)" onclick="' + favoriteFunc + '"><i id="' + favoriteClassID + '"class="icon-custom rounded-x fa ' + favoriteHeartClass + '"></i> </a>';
                        var shareText = getExtraShoppingRewardPoint(minfinalsaleprice);
                        shareText = "'" + shareText + "'";
                        html = html + '<a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + shareText + ',' + prdDesc + ')" ><i class=" icon-custom rounded-x fa fa-share-alt"></i></a>';
                        html = html + '</span>';

                        html = html + '</div>';
                        html = html + '<div class="product-description product-description-brd shop-height  shop-height margin-bottom-30">';
                        html = html + '<div class="overflow-h">';
                        html = html + '<div class="margin-bottom-10">';
                        html = html + '<h4 class="title-price"><a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></h4>';
                       html = html + '</div> <div class="product-price">'; 
                        /*     html = html + '<a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '">' + GetShortDesc(prd.txtjj) + '...Read more</a></div> <div class="product-price">';  */
                      
                        html = html + '<span class="title-price"">$' + minfinalsaleprice + '</span>';
                        html = html + htmlEstimatePrice;
                        //html = html + '<span class="like-icon-share"><a data-original-title="Favorite" data-toggle="tooltip" data-placement="bottom" class="tooltips" href="javascript:void(0)" onclick="FavoritePrd(' + prdid + ')" ><i class="fa fa-heart"></i></a></span>';
                        //html = html + '<span class="like-icon-share"><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')" ><i class="fa fa-share-alt"></i></a></span>';
                        html = html + '</div>';
                        html = html + '</div>';
                        //html = html + '<div class="sharearn" style="margin-top:5px;"><a href="/College/sharer_commission.aspx" target="_blank"><span class="share"> Share & Earn</span> <span class="earn">Up to 10% commmission</span></a></div>';
                        html = html + '</div>';

                        html = html + '</div>';
                        /*
                        html = html + '<div class="col-md-4">';
                        html = html + '<div class="product-img product-img-brd">';
                        html = html + '<a href="submitReview.aspx?id=' + prd.prdguid + '" ><img class="full-width img-responsive" src="' + imgPath + '" alt=""></a>';
                        html = html + '<a class="product-review" href="submitReview.aspx?id=' + prd.prdguid + '">Quick review</a>';
                        html = html + '<a class="add-to-cart" href="submitReview.aspx?id=' + prd.prdguid + '" ><i class="fa fa-eye"></i>Evaluate</a>';
                        //  html = html + ' <div class="shop-rgba-dark-green rgba-banner"></div>';
                        html = html + '</div> ';
                        html = html + '<div class="product-description product-description-brd shop-height  margin-bottom-30">';
                        html = html + '<div class="overflow-h">';
                        html = html + '<div class="pull-left margin-bottom-10">';
                        html = html + ' <h4 class="title-price"><a href="submitReview.aspx?id=' + prd.prdguid + '" >' + prd.name + '</a></h4>';
                        html = html + '<span class="gender">' + prdDescShort + '</span></div>';
                        html = html + '<div class="product-price">';
                        html = html + '<span class="title-price"><strong>$' + prd.estimateprice + '</strong></span> ';
                        html = html + '<span class="like-icon"><a data-original-title="Favorite" data-toggle="tooltip" data-placement="bottom" class="tooltips" href="javascript:void(0)" onclick="FavoritePrd(' + prdid + ')"><i class="fa fa-heart"></i></a></span>';
                        html = html + '<span class="like-icon" ><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" ><i class="fa fa-share-alt"></i></a></span>';

                        html = html + '</div>';
                        html = html + '</div>';
                        html = html + '</div>';
                        html = html + '</div>';
                        */
                        if (i % 3 == 2) {
                            html = html + '</div>';
                        }
                        /////////////////list by grid EOF
                    } else {
                        html = html + '<div class="list-product-description product-description-brd shop-height  margin-bottom-30">';
                        html = html + '<div class="row">';
                        html = html + '    <div class="col-sm-4">';
                        html = html + '        <a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '"><img class="img-responsive sm-margin-bottom-20" src="' + imgPath + '" alt=""></a>';
                        html = html + '    </div> ';
                        html = html + '    <div class="col-sm-8 product-description">';
                        html = html + '        <div class="overflow-h margin-bottom-5">';
                        html = html + '             <ul class="list-inline overflow-h">';
                        html = html + '                <li><h4 class="title-price"><a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></h4></li>';
                        /*
                        html = html + '                <li><span class="gender text-uppercase">'+prd.name+'</span></li>';
                       
                        html = html + '                <li class="pull-right">';
                        html = html + '                    <ul class="list-inline product-ratings">';
                        html = html + '                        <li><i class="rating-selected fa fa-star"></i></li>';
                        html = html + '                        <li><i class="rating-selected fa fa-star"></i></li>';
                        html = html + '                        <li><i class="rating-selected fa fa-star"></i></li>';
                        html = html + '                        <li><i class="rating fa fa-star"></i></li>';
                        html = html + '                        <li><i class="rating fa fa-star"></i></li>';
                        html = html + '                    </ul>';
                        html = html + '                </li>';
                        */
                        html = html + '            </ul>';
                        html = html + '            <div class="margin-bottom-10">';
                        html = html + '                <span class="title-price margin-right-10"><strong style="color:red">$' + minfinalsaleprice + '</strong>' + htmlEstimatePrice + '</span>';
                        // html = html + '                <span class="title-price line-through">$95.00</span>';
                        html = html + '            </div>';
                        html = html + '            <p class="margin-bottom-20"><a <a href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '">' + prdDescShort + '</a></p>';
                        html = html + '            <ul class="list-inline add-to-wishlist margin-bottom-20">';
                        html = html + '                <li class="wishlist-in">';
                        html = html + '                    <i id="' + favoriteClassID + '" class="fa ' + favoriteHeartClass + '"></i>';
                        html = html + '                    <a href="javascript:void(0)" onclick="' + favoriteFunc + '">Add Favorite</a>';
                        html = html + '                </li>';
                        html = html + '                <li class="compare-in">';
                        html = html + '                    <i class="fa fa-share-alt"></i>';
                        var shareText = getExtraShoppingRewardPoint(minfinalsaleprice);
                        shareText = "'" + shareText + "'";
                        html = html + '                    <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + shareText + ',' + prdDesc + ')" >Share & Earn</a>';
                        html = html + '                </li>';
                        html = html + '            </ul>';
                        html = html + '            <a  class="btn-u btn-u-sea-shop" href="/Product/saleBuy.aspx?id=' + prd.prdGuid + '" ><i class="fa fa-shopping-cart"></i>&nbsp;&nbsp;Add to Cart</a>';
                       // html = html + '<div class="sharearn" style="margin-top:5px;"><a href="/College/sharer_commission.aspx" target="_blank"><span class="share"> Share & Earn</span> <span class="earn">Up to 10% commmission</span></a></div>';
                        html = html + '        </div>';
                        html = html + '    </div>';

                        html = html + '</div>';
                        html = html + '</div>';
                    }
                }
                //html = '<div class="item ' + nowAddCLass + '"><div class="box"><div class="pic-box"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="imglink"><img src="' + imgPath + '" alt="" /></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" class="share" title="Share">Share</a></div></div><div class="row row1"><a href="submitReview.aspx?id=' + prd.prdguid + '" >' + prd.name + '</a></div><div class="row row22"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="imglink">' + prdDescShort + '</a></div><div class="row row3 clearfix"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="btn i-want-eview">Evaluate</a><a href="../Product/inventory.aspx?proid=' + prd.prdguid + '" class="btn competitive-supply">Supply</a><a href="?id=' + prd.prdguid + '" class="btn i-have-way">Solution</a><strong>$' + prd.estimateprice + '</strong></div><div class="row row4 clearfix" style="display:none;"><div class="eview-ok"><div class="state"><span class=zt1>Public Evaluating</span><span class=zt2>Tweebaa Evaluating</span></div><p><b>' + reviewCount + '</b> Evaluated</p></div><div class="fabu-time">Submitted on<p>' + time + '</p></div></div><div class="row row5 clearfix"><div class="eview-ok"><p><b>1666</b>Solutions</p></div><div class="lose">Reason not approved <br />No suitable supply channels</div></div></div></div>';
                //html = '<div class="item ' + nowAddCLass + '"><div class="box"><div class="pic-box"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="imglink"><img src="' + imgPath + '" alt="" /></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" class="share" title="Share">Share</a></div></div><div class="row row1"><a href="submitReview.aspx?id=' + prd.prdguid + '" >' + prd.name + '</a></div><div class="row row2"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="imglink">' + prd.txtjj + '</a></div><div class="row row3 clearfix"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="btn i-want-eview">Evaluate</a><a href="../Product/inventory.aspx?proid=' + prd.prdguid + '" class="btn competitive-supply">Supply</a><a href="?id=' + prd.prdguid + '" class="btn i-have-way">Solution</a><strong>$' + prd.estimateprice + '</strong></div><div class="row row4 clearfix"><div class="eview-ok"><div class="state"><span class=zt1>Public Evaluating</span><span class=zt2>Tweebaa Evaluating</span></div><p><b>' + reviewCount + '</b> Evaluated</p></div><div class="fabu-time">Submitted on<p>' + time + '</p></div></div><div class="row row5 clearfix"><div class="eview-ok"><p><b>1666</b>Solutions</p></div><div class="lose">Reason not approved <br />No suitable supply channels</div></div></div></div>';
                //                   html += '<div class="item ' + nowAddCLass + '"><div class="box"><div class="pic-box">';
                //                   html += '<a href="submitReview.aspx?id=' + prd.prdguid + '"  class="imglink"><img src="' + imgPath + '" alt="" /></a>';
                //                   html += '<div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a>';
                //                   html += '<a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" class="share" title="Share">Share</a>';
                //                   html += '</div></div>';
                //                   html += '<div class="row row1"><a href="submitReview.aspx?id=' + prd.prdguid + '" >' + prd.name + '</a></div><div class="row row2"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="imglink">' + prd.txtjj + '</a></div>';
                //                   html += '<div class="row row3 clearfix"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="btn i-want-eview">Evaluate</a><a href="../Product/inventory.aspx?proid=' + prd.prdguid + '" class="btn competitive-supply">Supply</a><a href="?id=' + prd.prdguid + '" class="btn i-have-way">Solution</a><strong>$' + prd.estimateprice + '</strong></div>';
                //                   html += '<div class="row row4 clearfix" style="display:none;"><div class="eview-ok"><div class="state"><span class=zt1>Public Evaluating</span><span class=zt2>Tweebaa Evaluating</span></div>';
                //                   html += '<p><b>' + reviewCount + '</b> Evaluated</p></div><div class="fabu-time">Submitted on<p>' + time + '</p></div></div>';
                //                   html += '<div class="row row5 clearfix"><div class="eview-ok"><p><b>1666</b>Solutions</p></div>';
                //                   html += '<div class="lose">Reason not approved <br />No suitable supply channels</div></div></div></div>';
                //                   alert(html);

            }
            dofristshare_prdSaleAllminUl = getMinUl();
            dofristshare_prdSaleAllminUl.html(html);
        },
        error: function (obj) {
            //alert("Load failed");
        }
    });

}
function LoadCount() {
    $("#kkpager").html("");
    $("#prd_listings").html("loading data....");
    var prdName = $("#txtPrdname").val();
    var cate = "";  // not used
    var state = step;
    // get three level category ID
    var prdCate1 = sCategory1 ;// $("#prdType1 option:selected").val();
    var prdCate2 = sCategory2 ; // $("#prdType2 option:selected").val();
    var prdCate3 = sCategory3; // $("#prdType3 option:selected").val();
    if (prdCate1 == "-1") prdCate1 = "";
    if (prdCate2 == "-1") prdCate2 = "";
    if (prdCate3 == "-1") prdCate3 = "";

    // get multiple selected by focus category
    var focusCateIDs = [];
    $("#ulByFocus input:checkbox:checked").map(function () {
        focusCateIDs.push($(this).val());
    });

    // get data count
    $.ajax({
        type: "Post",
        url: "/AjaxPages/prdSaleAjax.aspx",
        async: false,
        data: "{'action':'reviewPrdCount','cate':'" + cate
                    + "','prdName':'" + escape(prdName)
                    + "','state':'" + step
                    + "','focusCateIDs':'" + focusCateIDs
                    + "','prdCate1':'" + prdCate1
                    + "','prdCate2':'" + prdCate2
                    + "','prdCate3':'" + prdCate3
                    + "','orderby':'" + orderby
                    + "','page':'" + page
                    + "','pageSize':'" + pageSize
                    + "'}",
        success: function (resu) {
            showSearchResult(resu);
        },
        error: function (obj) {
            // alert("Load failed");
        }
    });

   

}
function getMinUl() {
    /*
    var $arrUl = $("#mainsrp-itemlist .items");
    var $minUl = $arrUl.eq(0);
    $arrUl.each(function (index, elem) {
    if ($(elem).height() < $minUl.height()) {
    $minUl = $(elem);
    }
    });*/
    var $minUl = $("#prd_listings");
    return $minUl;
}


//分享动作
/*
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
*/
function Name2URL(sURL)
{
    //string cleanTitle = sProduct.Trim().ToLower();
    //var cleanTitle = sProduct.Trim();
    var sRet = sURL;
    //var pattern = /[\x00-\x19\x21-\x2F\x3A-\x40\x5B-\x60\x7B-\xFF]/;
    var pattern = /\s+/g;
    sRet = sRet.replace(pattern, '-');
    //console.log(sRet);

    return sRet;

}

//接收URL参数
/*
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
}  */   