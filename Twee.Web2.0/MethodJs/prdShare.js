﻿var step = ""; //评审区产品状态：1大众评审；4推易吧评审；5评审失败
var page = 1; //页码
var orderby = "ranking desc "; //排序条件
var iTotalPage = 0;
var iTotalRecord = 0;
var iPageSize = 21;
var iShowType = 1; //1 Show by Grid, 2 show by List

var sCategory1 = "";    // 第1层目录的ID for search
var sCategory2 = "";    // 第2层目录的ID for search
var sCategory3 = "";    // 第3层目录的ID for search

var iPrevPage = 1; //页码

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
       LoadByFocusCate();
       LoadSearchByCate();
       LoadCategoryTree();
       loadMeinv();

       // get user share grade information
       GetUserShareGrade();

       //无限加载
       /*
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
       */
       // to search by enter key
       $("#txtPrdname").keyup(function (event) {
           if (event.which == 13) {
               DoSearch();
               $("#txtPrdname").focus();

           }
       });

   });

   /////////////New function add by long for V2.0
   function ShowByPage(pageSize) {
       iPageSize = pageSize;
       $("#show_by_text").html(pageSize);
       loadMeinv();
   }

   function show_by_list() {
       iShowType = 2;
       loadMeinv();
   }

   function show_by_grid() {
       iShowType = 1;
       loadMeinv();
   }

   function Prev_page() {
       var ipage = iPrevPage - 1;
       if (ipage < 1) ipage = 1;
       ProductPageNavigate(ipage);
   }

   function Next_page() {
       var ipage = iPrevPage + 1;
       if (ipage > iTotalPage) ipage = iTotalPage;
       ProductPageNavigate(ipage);
   }

   function ProductPageNavigate(iPage) {
       $("#BN_" + iPrevPage).removeClass("active");
       LoadProductByPage(iPage);
       $("#BN_" + iPage).addClass("active");
       iPrevPage = iPage;
   }
   
   //function DoSearchByCategory(cate3) {
   //    sCategory3 = cate3;
   //    loadMeinv();
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
       loadMeinv();
   }

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

       $.ajax({
           type: "Post",
           url: "/AjaxPages/prdShareAjax.aspx",
           data: "{'action':'reviewPrd','cate':'" + ""
       + "','prdName':'" + escape(prdName)
       + "','state':'" + step
       + "','focusCateIDs':'" + focusCateIDs
       + "','prdCate1':'" + prdCate1
       + "','prdCate2':'" + prdCate2
       + "','prdCate3':'" + prdCate3
       + "','orderby':'" + orderby
       + "','page':'" + iPage
       + "','pageSize':'" + iPageSize
       + "'}",
           success: function (resu) {
               if (resu == "") {
                   //clear the contents
                   $("#prd_listings").html("");
                   return;
               }
               var obj = eval("(" + resu + ")");

               var urlPage = "'submitReview.aspx'";
               html = '';
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

                   //var html = "";
                   if (prdState == "2") {
                       //预售中

                       urlPage = "'presaleBuy.aspx'";
                       // progress

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
                               html = html + '<div class="row illustration-v2 margin-bottom-30">';
                           }


                           html = html + '<div class="col-md-4">';
                           html = html + '<div class="product-img product-img-brd">';
                           html = html + '<a href="presaleBuy.aspx?id=' + prd.prdGuid + '" ><img class="full-width img-responsive" src="' + imgPath + '" alt=""></a>';
                           //html = html + '<a class="product-review" href="presaleBuy.aspx?id=' + prd.prdGuid + '"  >Quick review</a>';
                           //html = html + '<a class="add-to-cart add-share" href="presaleBuy.aspx?id=' + prd.prdGuid + '"  ><i class="fa fa-shopping-cart"></i>Add to Cart</a>';
                           html = html + '<span class="add-to-cart add-share" >';
                           html = html + '<a href="presaleBuy.aspx?id=' + prd.prdGuid + '" > <i class="icon-custom rounded-x fa fa-shopping-cart"></i></a>';
                           html = html + '<a href="javascript:void(0)" onclick="' + favoriteFunc + '"> <i id="' + favoriteClassID + '" class="icon-custom rounded-x fa ' + favoriteHeartClass + '"></i> </a>';
                           var shareText = getExtraShoppingRewardPoint(minfinalsaleprice);
                           shareText = "'" + shareText + "'";
                           html = html + '<a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')"><i class=" icon-custom rounded-x fa fa-share-alt"></i></a></span>';
                           html = html + '</div>';
                           html = html + '<div class="product-description product-description-brd margin-bottom-30">';
                           html = html + '<div class="overflow-h">';
                           html = html + '<div class="pull-left margin-bottom-10">';
                           html = html + '<h4 class="title-price share-price"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '" >' + prd.name + '</a></h4>';
                           html = html + '<a href="presaleBuy.aspx?id=' + prd.prdGuid + '" >' + GetShortDesc(prd.txtjj) + '...Read more</a></div> <div class="product-price">';
                           html = html + '<span class="title-price" style="color:red">$' + saleprice + '</span>&nbsp;&nbsp;';
                           html = html + htmlEstimatePrice;

                           html = html + '<span class="time"><i class="fa fa-clock-o"></i> ' + leftDays + '</span>';

                           html = html + '  <div class="progress progress-u progress-xxs">';
                           html = html + '    <div class="progress-bar progress-bar-red" role="progressbar" aria-valuenow="' + testSaleProgress + '" aria-valuemin="0" aria-valuemax="100" style="width: ' + testSaleProgress + '%">';
                           html = html + '    </div>';
                           html = html + '  </div>';
                           html = html + '  <h3 class="heading-xs">Test-Sale  ';
                           //html = html + '<span class="like-icon-share"><a data-original-title="Favorite" data-toggle="tooltip" data-placement="bottom" class="tooltips" href="javascript:void(0)" onclick="FavoritePrd(' + prdid + ')" ><i class="fa fa-heart"></i></a></span>';
                           //html = html + '<span class="like-icon-share"><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')" ><i class="fa fa-share-alt"></i></a></span>';
                           html = html + '<span class="pull-right">Units left: ' + testSaleLeftCount + '</span></h3>';

                           html = html + '</div>';
                           //html = html + '<img src="../Images/hour-glass.png" style="float:right; margin-right:7px; margin-left:3px; height:18px" /><div class="zt1"><div class="jdt"><span style="width:' + testSaleProgress + '%"></span></div><span class="fr">' + leftDays + '</span> <span class="fl">Test-Sale Units left: ' + testSaleLeftCount + '</span> </div><div>' + tagIco + '</div>';
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
                           html = html + '<div class="product-description product-description-brd margin-bottom-30">';
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
                           html = html + '<div class="list-product-description product-description-brd margin-bottom-30">';
                           html = html + '<div class="row">';
                           html = html + '    <div class="col-sm-4">';
                           html = html + '        <a href="presaleBuy.aspx?id=' + prd.prdGuid + '"><img class="img-responsive sm-margin-bottom-20" src="' + imgPath + '" alt=""></a>';
                           html = html + '    </div> ';
                           html = html + '    <div class="col-sm-8 product-description">';
                           html = html + '        <div class="overflow-h margin-bottom-5">';
                           html = html + '             <ul class="list-inline overflow-h">';
                           html = html + '                <li><h4 class="title-price"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '" >' + prd.name + '</a></h4></li>';
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
                           html = html + '            <p class="margin-bottom-20"><a href="presaleBuy.aspx?id=' + prd.prdGuid + '">' + prdDescShort + '</a></p>';
                           html = html + '            <div class="margin-bottom-10">';
                           html = html + '                <span class="title-price margin-right-10"><strong style="color:red">$' + saleprice + '</strong>' + htmlEstimatePrice + '</span>';
                           // html = html + '                <span class="title-price line-through">$95.00</span>';

                           html = html + '<span class="time"><i class="fa fa-clock-o"></i> ' + leftDays + '</span>';

                           html = html + '  <div class="progress progress-u progress-xxs">';
                           html = html + '    <div class="progress-bar progress-bar-red" role="progressbar" aria-valuenow="' + testSaleProgress + '" aria-valuemin="0" aria-valuemax="100" style="width: ' + testSaleProgress + '%">';
                           html = html + '    </div>';
                           html = html + '  </div>';
                           html = html + '  <h3 class="heading-xs">Test-Sale  ';
                           html = html + '<span class="pull-right">Units left: ' + testSaleLeftCount + '</span></h3>';


                           html = html + '            </div>';
                           //html = html + '            <div class="zt1 "><div class="jdt"><span style="width:' + testSaleProgress + '%"></span></div><span class="fl">Test-Sale Units left: ' + testSaleLeftCount + '</span><span class="fl" style="margin-left:10px">' + leftDays + '</span><span class="fl" style="margin-left:5px"><img src="../Images/hour-glass.png" style="height:12px" /></span></div><div>' + tagIco + '</div>';
                           html = html + '            <ul class="list-inline add-to-wishlist margin-bottom-20" style="padding-top:10px;">';
                           html = html + '                <li class="wishlist-in">';
                           html = html + '                    <i id="' + favoriteClassID + '" class="fa ' + favoriteHeartClass + '"></i>';
                           html = html + '                    <a href="javascript:void(0)" onclick="' + favoriteFunc + '">Add Favorite</a>';
                           html = html + '                </li>';
                           html = html + '                <li class="compare-in">';
                           html = html + '                    <i class="fa fa-share-alt"></i>';
                           html = html + '                    <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')" >Share & Earn</a>';
                           html = html + '                </li>';
                           html = html + '            </ul>';
                           html = html + '            <a  class="btn-u btn-u-sea-shop" href="presaleBuy.aspx?id=' + prd.prdGuid + '"  ><i class="fa fa-shopping-cart"></i>Add to Cart</a>';
                           html = html + '        </div>';
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
                               html = html + '<div class="row illustration-v2 margin-bottom-30">';
                           }


                           html = html + '<div class="col-md-4">';
                           html = html + '<div class="product-img product-img-brd">';
                           html = html + '<a href="saleBuy.aspx?id=' + prd.prdGuid + '" ><img class="full-width img-responsive" src="' + imgPath + '" alt=""></a>';
                           //html = html + '<a class="product-review" href="saleBuy.aspx?id=' + prd.prdGuid + '" >Quick review</a>';
                           //html = html + '<a class="add-to-cart add-share" href="saleBuy.aspx?id=' + prd.prdGuid + '" ><i class="fa fa-shopping-cart"></i>Add to Cart</a>';
                           html = html + '<span class="add-to-cart add-share" >';
                           html = html + '<a href="presaleBuy.aspx?id=' + prd.prdGuid + '" > <i class="icon-custom rounded-x fa fa-shopping-cart"></i></a>';
                           html = html + '<a href="javascript:void(0)" onclick="' + favoriteFunc + '"> <i id="' + favoriteClassID + '" class="icon-custom rounded-x fa ' + favoriteHeartClass + '"></i> </a>';
                           html = html + '<a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')"><i class=" icon-custom rounded-x fa fa-share-alt"></i></a></span>';
                           html = html + '</div>';
                           html = html + '<div class="product-description product-description-brd margin-bottom-30">';
                           html = html + '<div class="overflow-h">';
                           html = html + '<div class="pull-left margin-bottom-10">';
                           html = html + '<h4 class="title-price share-price"><a href="saleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></h4>';
                           html = html + '<a href="saleBuy.aspx?id=' + prd.prdGuid + '">' + GetShortDesc(prd.txtjj) + '...Read more</a></div> <div class="product-price">';
                           html = html + '<span class="title-price" style="color:red">$' + minfinalsaleprice + '</span>';
                           html = html + htmlEstimatePrice;
                           //html = html + '<span class="like-icon-share"><a data-original-title="Favorite" data-toggle="tooltip" data-placement="bottom" class="tooltips" href="javascript:void(0)" onclick="FavoritePrd(' + prdid + ')" ><i class="fa fa-heart"></i></a></span>';
                           //html = html + '<span class="like-icon-share"><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')" ><i class="fa fa-share-alt"></i></a></span>';
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
                           html = html + '<div class="product-description product-description-brd margin-bottom-30">';
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
                           html = html + '<div class="list-product-description product-description-brd margin-bottom-30">';
                           html = html + '<div class="row">';
                           html = html + '    <div class="col-sm-4">';
                           html = html + '        <a href="saleBuy.aspx?id=' + prd.prdGuid + '"><img class="img-responsive sm-margin-bottom-20" src="' + imgPath + '" alt=""></a>';
                           html = html + '    </div> ';
                           html = html + '    <div class="col-sm-8 product-description">';
                           html = html + '        <div class="overflow-h margin-bottom-5">';
                           html = html + '             <ul class="list-inline overflow-h">';
                           html = html + '                <li><h4 class="title-price"><a href="saleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></h4></li>';
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
                           html = html + '                    <i id="' + favoriteClassID + '"class="fa ' + favoriteHeartClass + '"></i>';
                           html = html + '                    <a href="javascript:void(0)" onclick="' + favoriteFunc + '">Add Favorite</a>';
                           html = html + '                </li>';
                           html = html + '                <li class="compare-in">';
                           html = html + '                    <i class="fa fa-share-alt"></i>';
                           html = html + '                    <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" ></a>Share & Earn</a>';
                           html = html + '                </li>';
                           html = html + '            </ul>';
                           html = html + '            <a  class="btn-u btn-u-sea-shop" href="saleBuy.aspx?id=' + prd.prdGuid + '" ><i class="fa fa-shopping-cart"></i>Add to Cart</a>';
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
                               html = html + '<div class="row illustration-v2 margin-bottom-30">';
                           }


                           html = html + '<div class="col-md-4">';
                           html = html + '<div class="product-img product-img-brd">';
                           html = html + '<a href="saleBuy.aspx?id=' + prd.prdGuid + '" ><img class="full-width img-responsive" src="' + imgPath + '" alt=""></a>';
                           //html = html + '<a class="product-review" href="saleBuy.aspx?id=' + prd.prdGuid + '" >Quick review</a>';
                           //html = html + '<a class="add-to-cart add-share" href="saleBuy.aspx?id=' + prd.prdGuid + '" ><i class="fa fa-shopping-cart"></i>Add to Cart</a>';
                           html = html + '<span class="add-to-cart add-share" >';
                           html = html + '<a href="presaleBuy.aspx?id=' + prd.prdGuid + '" > <i class="icon-custom rounded-x fa fa-shopping-cart"></i></a>';
                           html = html + '<a href="javascript:void(0)" onclick="' + favoriteFunc + '"> <i id="' + favoriteClassID + '" class="icon-custom rounded-x fa ' + favoriteHeartClass + '"></i> </a>';
                           html = html + '<a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')"><i class=" icon-custom rounded-x fa fa-share-alt"></i></a></span>';
                           html = html + '</div>';
                           html = html + '<div class="product-description product-description-brd margin-bottom-30">';
                           html = html + '<div class="overflow-h">';
                           html = html + '<div class="pull-left margin-bottom-10">';
                           html = html + '<h4 class="title-price share-price"><a href="saleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></h4>';
                           html = html + '<a href="saleBuy.aspx?id=' + prd.prdGuid + '">' + GetShortDesc(prd.txtjj) + '...Read more</a></div> <div class="product-price">';
                           html = html + '<span class="title-price" style="color:red">$' + minfinalsaleprice + '</span>';
                           html = html + htmlEstimatePrice;
                           //html = html + '<span class="like-icon-share"><a data-original-title="Favorite" data-toggle="tooltip" data-placement="bottom" class="tooltips" href="javascript:void(0)" onclick="FavoritePrd(' + prdid + ')" ><i class="fa fa-heart"></i></a></span>';
                           //html = html + '<span class="like-icon-share"><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')" ><i class="fa fa-share-alt"></i></a></span>';
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
                           html = html + '<div class="product-description product-description-brd margin-bottom-30">';
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
                           html = html + '<div class="list-product-description product-description-brd margin-bottom-30">';
                           html = html + '<div class="row">';
                           html = html + '    <div class="col-sm-4">';
                           html = html + '        <a href="saleBuy.aspx?id=' + prd.prdGuid + '"><img class="img-responsive sm-margin-bottom-20" src="' + imgPath + '" alt=""></a>';
                           html = html + '    </div> ';
                           html = html + '    <div class="col-sm-8 product-description">';
                           html = html + '        <div class="overflow-h margin-bottom-5">';
                           html = html + '             <ul class="list-inline overflow-h">';
                           html = html + '                <li><h4 class="title-price"><a href="saleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></h4></li>';
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
                           html = html + '                    <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" ></a>Share & Earn</a>';
                           html = html + '                </li>';
                           html = html + '            </ul>';
                           html = html + '            <a  class="btn-u btn-u-sea-shop" href="saleBuy.aspx?id=' + prd.prdGuid + '" ><i class="fa fa-shopping-cart"></i>Add to Cart</a>';
                           html = html + '        </div>';
                           html = html + '    </div>';
                           html = html + '</div>';
                           html = html + '</div>';
                       }

                   } else if (prdState == "3") { //销售中 
                       urlPage = "'saleBuy.aspx'";
                       var priceMSRP = '<del style="color:grey">$' + estimateprice + '</del>&nbsp;&nbsp;';
                       if (iShowType == 1) {
                           ///////////////list by grid
                           if (i % 3 == 0) {
                               html = html + '<div class="row illustration-v2 margin-bottom-30">';
                           }


                           html = html + '<div class="col-md-4">';
                           html = html + '<div class="product-img product-img-brd">';
                           html = html + '<a href="saleBuy.aspx?id=' + prd.prdGuid + '" ><img class="full-width img-responsive" src="' + imgPath + '" alt=""></a>';
                           //html = html + '<a class="product-review" href="saleBuy.aspx?id=' + prd.prdGuid + '" >Quick review</a>';
                           //html = html + '<a class="add-to-cart add-share" href="saleBuy.aspx?id=' + prd.prdGuid + '" ><i class="fa fa-shopping-cart"></i>Add to Cart</a>';

                           html = html + '<span class="add-to-cart add-share" >';
                           html = html + '<a href="presaleBuy.aspx?id=' + prd.prdGuid + '" > <i class="icon-custom rounded-x fa fa-shopping-cart"></i></a>';
                           html = html + '<a href="javascript:void(0)" onclick="' + favoriteFunc + '"> <i id="' + favoriteClassID + '" class="icon-custom rounded-x fa ' + favoriteHeartClass + '"></i> </a>';
                           html = html + '<a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')"><i class=" icon-custom rounded-x fa fa-share-alt"></i></a></span>';

                           html = html + '</div>';
                           html = html + '<div class="product-description product-description-brd margin-bottom-30">';
                           html = html + '<div class="overflow-h">';
                           html = html + '<div class="pull-left margin-bottom-10">';
                           html = html + '<h4 class="title-price share-price"><a href="saleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></h4>';
                           html = html + '<a href="saleBuy.aspx?id=' + prd.prdGuid + '">' + GetShortDesc(prd.txtjj) + '...Read more</a></div> <div class="product-price">';
                           html = html + '<span class="title-price" style="color:red">$' + minfinalsaleprice + '</span>';
                           html = html + htmlEstimatePrice; 
                           //html = html + '<span class="like-icon-share"><a data-original-title="Favorite" data-toggle="tooltip" data-placement="bottom" class="tooltips" href="javascript:void(0)" onclick="FavoritePrd(' + prdid + ')" ><i class="fa fa-heart"></i></a></span>';
                           //html = html + '<span class="like-icon-share"><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')" ><i class="fa fa-share-alt"></i></a></span>';
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
                           html = html + '<div class="product-description product-description-brd margin-bottom-30">';
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
                           html = html + '<div class="list-product-description product-description-brd margin-bottom-30">';
                           html = html + '<div class="row">';
                           html = html + '    <div class="col-sm-4">';
                           html = html + '        <a href="saleBuy.aspx?id=' + prd.prdGuid + '"><img class="img-responsive sm-margin-bottom-20" src="' + imgPath + '" alt=""></a>';
                           html = html + '    </div> ';
                           html = html + '    <div class="col-sm-8 product-description">';
                           html = html + '        <div class="overflow-h margin-bottom-5">';
                           html = html + '             <ul class="list-inline overflow-h">';
                           html = html + '                <li><h4 class="title-price"><a href="saleBuy.aspx?id=' + prd.prdGuid + '">' + prd.name + '</a></h4></li>';
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
                           html = html + '            <p class="margin-bottom-20"><a href="saleBuy.aspx?id=' + prd.prdGuid + '">' + prdDescShort + '</a></p>';
                           html = html + '            <ul class="list-inline add-to-wishlist margin-bottom-20">';
                           html = html + '                <li class="wishlist-in">';
                           html = html + '                    <i id="' + favoriteClassID + '"class="fa ' + favoriteHeartClass + '"></i>';
                           html = html + '                    <a href="javascript:void(0)" onclick="' + favoriteFunc + '">Add Favorite</a>';
                           html = html + '                </li>';
                           html = html + '                <li class="compare-in">';
                           html = html + '                    <i class="fa fa-share-alt"></i>';
                           html = html + '                    <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + minfinalsaleprice + ')" >Share & Earn</a>';
                           html = html + '                </li>';
                           html = html + '            </ul>';
                           html = html + '            <a  class="btn-u btn-u-sea-shop" href="saleBuy.aspx?id=' + prd.prdGuid + '" ><i class="fa fa-shopping-cart"></i>Add to Cart</a>';
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
               // alert("Load failed");
           }
       });
   }
   /////////////New function add by long for V2.0 EOF
//排序
function orderBy(obj) {
    var orderStr = $(obj).html();
    if (orderStr == "By Ranking") { orderby = "ranking desc "; };
    if (orderStr == "By Time") { orderby = "addtime desc "; };
    if (orderStr == "By Price") { orderby = "saleprice desc "; };
    if (orderStr == "By Name") { orderby = "name asc "; };
    if (orderStr == "按销售数量") { orderby = "saleCount desc "; };
    if (orderStr == "按分享人数") { orderby = "shareCount desc "; };
    $("#spnSortBy").html(orderStr);
    $("#mainsrp-itemlist .items").empty();
    page = 1;
    loadMeinv();
}
function DoSearch() {
    page = 1;

    sCategory1 = ""; //need to reset it
    sCategory2 = ""; //need to reset it
    sCategory3 = ""; //need to reset it

    $("#mainsrp-itemlist .items").empty();
    loadMeinv();
}

//function SearchPrdByCate(cateID) {
//    $("#mainsrp-itemlist .items").empty();
//    loadMeinv(cateID);
//}

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
        url: "/AjaxPages/shareAjax.aspx",
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

function showSearchResult(count) {
    var cntProduct = parseInt(count);
    searchResultHtml = "Your search matched " + cntProduct + " result";
    if (cntProduct > 1) searchResultHtml = searchResultHtml + "s";
    searchResultHtml = searchResultHtml + "."
    $("#searchResult").html(searchResultHtml);

    iTotalRecord = count;
    iTotalPage = Math.ceil(count / iPageSize);

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
        total: iTotalPage, //总页码
        //总数据条数
        totalRecords: iTotalRecord,
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


function loadMeinv() {
    $("#kkpager").html("");
    $("#prd_listings").html("loading data....");
    var prdName = $("#txtPrdname").val();
    var cate = "";  // this is not used  by Jack Cao 2015-10-23
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

    // get data count
    $.ajax({
        type: "Post",
        url: "/AjaxPages/prdShareAjax.aspx",
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
                    + "','pageSize':'" + iPageSize
                    + "'}",
        success: function (resu) {
            showSearchResult(resu);
        },
        error: function (obj) {
            // alert("Load failed");
        }
    });



    // get and display product list
    /*
    $.ajax({
        type: "Post",
        url: "/AjaxPages/prdShareAjax.aspx",
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
                          +'<tr><td>Purchase</td><td></td><td>Level ' + userShareLevel + '</td><td></td><td>Reward</td></tr><tr><td>$' + saleprice + '</td><td>*</td><td>' + userShareRatio / 10 + '%</td><td>=</td><td><b>$' + (saleprice * userShareRatio / 1000).toFixed(2) + '</b></td></tr></table></span><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ',' + +saleprice + ')" class="share-btn">Share & Earn</a></span></div></div></div></div>';
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
    */
    LoadProductByPage(1);
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
} */    