var step = "";//评审区产品状态：1大众评审；4推易吧评审；5评审失败
var iTotalpage;
var iPageSize = 21;
var iShowType = 1; //1 Show by Grid, 2 show by List

var sCategory1 = "";    // 第1层目录的ID for search
var sCategory2 = "";    // 第2层目录的ID for search
var sCategory3 = "";    // 第3层目录的ID for search

var iPrevPage = 1; //页码
var orderby = "addtime desc "; //排序条件
var picPath = "https://tweebaa.com/";
$(document).ready(
   function () {
       var Request = new Object();
       Request = GetRequest();
       step = Request["step"];
       if (step == null) {
           step = "";
       }
       LoadByFocusCate();
       LoadCategoryTree();
       // LoadSearchByCate();
       loadMeinv("");
       //无限加载
       /*
       $(window).on("scroll", function () {
           $minUl = getMinUl();
           //if ($minUl.height() > $(window).scrollTop() + $(window).height()) {
           if ($(document).height() == $(window).scrollTop() + $(window).height()) {
               // auto load next page if scroll to the end of the page
               page = page + 1;
               loadMeinv(""); //加载新图片
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

   function ShowByPage(pageSize) {
       iPageSize = pageSize;
       $("#show_by_text").html(pageSize);
       loadMeinv("");
   }
   //排序
   function orderBy(obj) {
       var orderStr = $(obj).html();
       if (orderStr == "By Ranking") { orderby = " ranking desc "; };
       if (orderStr == "By Time") { orderby = " addtime desc "; };
       if (orderStr == "By Price") { orderby = " estimateprice desc "; };
       if (orderStr == "By Name") { orderby = " name asc "; };
       if (orderStr == "By Evaluator") { orderby = " reviewCount desc "; };
       if (orderStr == "By clicks") { orderby = " reviewCount desc "; };
       $("#sort_by_text").html(orderStr);
       //$("#mainsrp-itemlist .items").empty();
       page = 1;
       loadMeinv("");
   }
   function DoSearch() {
       page = 1;

       sCategory1 = ""; //need to reset it
       sCategory2 = ""; //need to reset it
       sCategory3 = ""; //need to reset it

       $("#mainsrp-itemlist .items").empty(); 
       loadMeinv("");
   }
   function SearchPrdByCate(cateID) {
       // search from 3 level categories
       $("#mainsrp-itemlist .items").empty();
       loadMeinv(cateID);
   
   }

   function show_by_list() {
       iShowType = 2;
       loadMeinv();
   }

   function show_by_grid() {
       iShowType = 1;
       loadMeinv();
   }
   function GetShortDesc(descFull) {
       // do no break a work
       var descShort = descFull.substring(0, 120);
       if (descFull.length > 120) {
           for (var i = 120; i < descFull.length; i++) {
               var t = descFull.substring(i, i + 1);
               if (t == " ") break;
               descShort = descShort + t;
           }
       }
       return descShort;
   }

   function showSearchResult(count) {
       var cntProduct = parseInt(count);
       iTotalpage = cntProduct;
       searchResultHtml = "Your search matched " + cntProduct + " result";
       if (cntProduct > 1) searchResultHtml = searchResultHtml + "s";
       searchResultHtml = searchResultHtml + "."
       $("#searchResult").html(searchResultHtml);

       //make page listing
       //var icount = iTotalpage / iPageDiv;
       var iTotal = Math.ceil(iTotalpage / iPageSize);
       //make pages
       /*
       
                        <li><a href="#">1</a></li>
                        <li class="active"><a href="#">2</a></li>
                        <li><a href="#">3</a></li>
                        
                        */
           if (iTotalpage > 0) {
               var i = 0; var html = '<li><a href="#" onclick="Prev_page()"><i class="fa fa-angle-left"></i></a></li>';

               for (i = 1; i <= iTotal; i++) {
                   if (i == 1) {
                       html += '<li id="BN_' + i + '" class="active"><a href="#"  onclick="ProductPageNavigate(' + i + ')" >' + i + '</a></li>';
                   } else {

                       html += '<li id="BN_' + i + '"><a href="#"  onclick="ProductPageNavigate(' + i + ')">' + i + '</a></li>';
                   }
               }

               html += '<li><a href="#" onclick="Next_page()"><i class="fa fa-angle-right"></i></a></li>';
               $("#pageNav").html(html);
           } else {
               $("#pageNav").html("");
           }
       }

       function Prev_page() {
           var ipage = iPrevPage - 1;
           if (ipage < 1) ipage = 1;
           ProductPageNavigate(ipage);
       }
       function Next_page() {
           var ipage = iPrevPage + 1;
           if (ipage > iTotalpage) ipage = iTotalpage;
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
       //    loadMeinv("");
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
           loadMeinv("");
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
               url: "/AjaxPages/prdReviewAjax.aspx",
               data: "{'action':'reviewPrd','cate':'" + ""
       + "','prdName':'" + escape(prdName)
       + "','state':'" + step
       + "','focusCateIDs':'" + focusCateIDs
       + "','prdCate1':'" + prdCate1
       + "','prdCate2':'" + prdCate2
       + "','prdCate3':'" + prdCate3
       + "','orderby':'"
       + orderby + "','page':'"
       + iPage + "','pageSize':'"
       + iPageSize
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
                       var prdid = "'" + prd.prdguid + "'";
                       var prdname = "'" + escape(prd.name) + "'";


                       var a = prd.fileurl.replace("big", "mid");
                       if (a.indexOf("upload/") == -1) a = "upload/" + a;
                       var imgPath = picPath + a;
                       var imgOnErrorPath = "http://itweebaa.com";
                       if (a.substring(0, 1) == "/") {
                           imgOnErrorPath = imgOnErrorPath + a;
                       } else {
                           imgOnErrorPath = imgOnErrorPath + "/" + a;
                       }
                       //var imgPath = picPath + ;
                       var prdimg = "'" + imgPath + "'";
                       var time = prd.addtime.replace(/-/g, '/').substring(0, 10);
                       //var classArr = ["review-ing", "supply-ing", "lose-ing"]
                       //状态1 评审中 //状态2 供货中 //状态3 失败
                       //var nowAddCLass = classArr[parseInt(Math.random() * 3)];
                       //状态1 评审中 状态4 供货中 //状态5 失败
                       var nowAddCLass = "review-ing";
                       if (step == "4") {
                           nowAddCLass = "supply-ing";
                       }
                       else if (step == "supply") {
                           nowAddCLass = "supply-ing";
                       }
                       else if (step == "5") {
                           nowAddCLass = "lose-ing";
                       }
                       //产品信息   
                       var reviewCount = prd.reviewCount;
                       if (reviewCount == null) {
                           reviewCount = 0;
                       }

                       var prdDesc = "'" + escape(prd.txtjj) + "'";
                       var prdDescShort = GetShortDesc(prd.txtjj) + "...Read more";

                       // convert to stand format of ####.## 
                       var estimateprice = parseFloat(prd.estimateprice);
                       prd.estimateprice = estimateprice.toFixed(2);

                       // favorite heart class
                       var favoriteHeartClass = "fa-heart-o";
                       if (prd.favoriteGuid != null && prd.favoriteGuid != "") favoriteHeartClass = "fa-heart";

                       var favoriteClassID = "favoriteClass" + i.toString();

                       var favoriteFunc = "FavoritePrdOnOff(" + prdid + ", '#" + favoriteClassID + "')";

                       if (iShowType == 1) {
                           ///////////////list by grid
                           if (i % 3 == 0) {
                               html = html + '<div class="row illustration-v2 margin-bottom-20">';
                           }
                           html = html + '<div class="col-md-4">';
                           html = html + '<div class="product-img product-img-brd">';
                           html = html + '<a href="submitReview.aspx?id=' + prd.prdguid + '" ><img class="full-width img-responsive" src="' + imgPath + '" onerror="this.src=\''+imgOnErrorPath+'\'" alt=""></a>';
                           //html = html + '<a class="product-review" href="submitReview.aspx?id=' + prd.prdguid + '">Quick review</a>';
                           html = html + '<span class="add-to-cart add-evaluate">';

                           // evaluate has not shopping cart
                           //html = html + '<a href="submitReview.aspx?id=' + prd.prdguid + '" ><i class="icon-custom rounded-x fa fa-check-square-o"></i></a>';

                           html = html + '<a href="javascript:void(0)" onclick="' + favoriteFunc + '"  ><i id="' + favoriteClassID + '" class="icon-custom rounded-x fa ' + favoriteHeartClass + '"></i></a>';
                           var shareText = getExtraShoppingRewardPoint(prd.estimateprice);
                           shareText = "'" + shareText + "'";
                           html = html + '<a href="javascript:void(0)" onclick="SharePrdEx(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + shareText + ',' + prdDesc + ')"><i class=" icon-custom rounded-x fa fa-share-alt"></i></a></span>';
                           html = html + '</div> ';
                           html = html + '<div class="product-description product-description-brd eval-height margin-bottom-20">';
                           html = html + '<div class="overflow-h">';
                           html = html + '<div class="margin-bottom-10">';
                           html = html + ' <h4 class="title-price"><a href="submitReview.aspx?id=' + prd.prdguid + '" >' + prd.name + '</a></h4>';
                           html = html + '</div>';
                           /* html = html + '<span class="gender"><a href="submitReview.aspx?id=' + prd.prdguid + '" >' + prdDescShort + '</a></span></div>';*/
                           html = html + '<div class="product-price">';
                           html = html + '<span class="eva-price ">$' + prd.estimateprice + '</span> ';
                           //html = html + '<span class="like-icon"><a data-original-title="Favorite" data-toggle="tooltip" data-placement="bottom" class="tooltips" href="javascript:void(0)" onclick="FavoritePrd(' + prdid + ')"><i class="fa fa-heart"></i></a></span>';
                           //html = html + '<span class="like-icon" ><a href="javascript:void(0)" onclick="SharePrdEx(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" ><i class="fa fa-share-alt"></i></a></span>';

                           html = html + '</div>';
                           html = html + '</div>';
                           html = html + '</div>';
                           html = html + '</div>';

                           if (i % 3 == 2) {
                               html = html + '</div>';
                           }
                           /////////////////list by grid EOF
                       } else {
                           html = html + '<div class="list-product-description product-description-brd margin-bottom-20">';
                           html = html + '<div class="row">';
                           html = html + '    <div class="col-sm-4">';
                           html = html + '        <a href="submitReview.aspx?id=' + prd.prdguid + '"><img class="img-responsive sm-margin-bottom-20" src="' + imgPath + '" alt=""></a>';
                           html = html + '    </div> ';
                           html = html + '    <div class="col-sm-8 product-description">';
                           html = html + '        <div class="overflow-h margin-bottom-5">';
                           html = html + '             <ul class="list-inline overflow-h">';
                           html = html + '                <li><h4 class="list-price"><a href="submitReview.aspx?id=' + prd.prdguid + '">' + prd.name + '</a></h4></li>';
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
                           html = html + '                <span class="title-price margin-right-10">$' + prd.estimateprice + '</span>';
                           // html = html + '                <span class="title-price line-through">$95.00</span>';
                           html = html + '            </div>';
                           html = html + '            <p class="margin-bottom-20">' + prdDescShort + '</p>';
                           html = html + '            <ul class="list-inline add-to-myevaluate margin-bottom-20">';
                           html = html + '                <li class="wishlist-in">';
                           html = html + '                    <i id="' + favoriteClassID + '" class="fa ' + favoriteHeartClass + '"></i>';
                           html = html + '                    <a href="javascript:void(0)" onclick="' + favoriteFunc + '">Add Favorite</a>';
                           html = html + '                </li>';
                           html = html + '                <li class="compare-in">';
                           html = html + '                    <i class="fa fa-share-alt"></i>';
                           var shareText = getExtraShoppingRewardPoint(prd.estimateprice);
                           shareText = "'" + shareText + "'";
                           html = html + '                    <a href="javascript:void(0)" onclick="SharePrdEx(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + shareText + ',' + prdDesc + ')" >Share & Earn</a>';
                           html = html + '                </li>';
                           html = html + '            </ul>';
                           html = html + '            <a  class="btn-u btn-u-sea rounded" href="submitReview.aspx?id=' + prd.prdguid + '" >Evaluate</a>';
                           html = html + '        </div>';
                           html = html + '    </div>';
                           html = html + '</div>';
                           html = html + '</div>';
                       }
                       //html = '<div class="item ' + nowAddCLass + '"><div class="box"><div class="pic-box"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="imglink"><img src="' + imgPath + '" alt="" /></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a><a href="javascript:void(0)" onclick="SharePrdEx(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" class="share" title="Share">Share</a></div></div><div class="row row1"><a href="submitReview.aspx?id=' + prd.prdguid + '" >' + prd.name + '</a></div><div class="row row22"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="imglink">' + prdDescShort + '</a></div><div class="row row3 clearfix"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="btn i-want-eview">Evaluate</a><a href="../Product/inventory.aspx?proid=' + prd.prdguid + '" class="btn competitive-supply">Supply</a><a href="?id=' + prd.prdguid + '" class="btn i-have-way">Solution</a><strong>$' + prd.estimateprice + '</strong></div><div class="row row4 clearfix" style="display:none;"><div class="eview-ok"><div class="state"><span class=zt1>Public Evaluating</span><span class=zt2>Tweebaa Evaluating</span></div><p><b>' + reviewCount + '</b> Evaluated</p></div><div class="fabu-time">Submitted on<p>' + time + '</p></div></div><div class="row row5 clearfix"><div class="eview-ok"><p><b>1666</b>Solutions</p></div><div class="lose">Reason not approved <br />No suitable supply channels</div></div></div></div>';
                       //html = '<div class="item ' + nowAddCLass + '"><div class="box"><div class="pic-box"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="imglink"><img src="' + imgPath + '" alt="" /></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a><a href="javascript:void(0)" onclick="SharePrdEx(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" class="share" title="Share">Share</a></div></div><div class="row row1"><a href="submitReview.aspx?id=' + prd.prdguid + '" >' + prd.name + '</a></div><div class="row row2"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="imglink">' + prd.txtjj + '</a></div><div class="row row3 clearfix"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="btn i-want-eview">Evaluate</a><a href="../Product/inventory.aspx?proid=' + prd.prdguid + '" class="btn competitive-supply">Supply</a><a href="?id=' + prd.prdguid + '" class="btn i-have-way">Solution</a><strong>$' + prd.estimateprice + '</strong></div><div class="row row4 clearfix"><div class="eview-ok"><div class="state"><span class=zt1>Public Evaluating</span><span class=zt2>Tweebaa Evaluating</span></div><p><b>' + reviewCount + '</b> Evaluated</p></div><div class="fabu-time">Submitted on<p>' + time + '</p></div></div><div class="row row5 clearfix"><div class="eview-ok"><p><b>1666</b>Solutions</p></div><div class="lose">Reason not approved <br />No suitable supply channels</div></div></div></div>';
                       //                   html += '<div class="item ' + nowAddCLass + '"><div class="box"><div class="pic-box">';
                       //                   html += '<a href="submitReview.aspx?id=' + prd.prdguid + '"  class="imglink"><img src="' + imgPath + '" alt="" /></a>';
                       //                   html += '<div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a>';
                       //                   html += '<a href="javascript:void(0)" onclick="SharePrdEx(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" class="share" title="Share">Share</a>';
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
       function loadMeinv(cateID) {      
       var prdName = $("#txtPrdname").val();
       var state = step;

       // get three level category ID
       var prdCate1 = sCategory1; 
       var prdCate2 = sCategory2; 
       var prdCate3 = sCategory3; 

       // get multiple selected by focus category
       var focusCateIDs = [];
       $("#ulByFocus input:checkbox:checked").map(function(){
       focusCateIDs.push($(this).val());
       });
      
       // get total record
       $.ajax({
       type: "Post",
       url: "/AjaxPages/prdReviewAjax.aspx",
       async: false,
       data: "{'action':'reviewPrdCount','cate':'" + cateID
       + "','prdName':'" + escape(prdName)
       + "','state':'" + step
       + "','focusCateIDs':'" + focusCateIDs
       + "','prdCate1':'" + prdCate1
       + "','prdCate2':'" + prdCate2
       + "','prdCate3':'" + prdCate3
       + "','orderby':'" + orderby 
       + "','page':'"   + "1"
       + "','pageSize':'" + iPageSize
       + "'}",
       success: function (resu) {
       showSearchResult(resu);
       },
       error: function (obj) {
       // alert("Load failed");
       }
       });
       LoadProductByPage(1);
      

       }
       function getMinUl() {
       //var $arrUl = $("#mainsrp-itemlist .items");
       var $minUl = $("#prd_listings");
       /*
       $arrUl.each(function (index, elem) {
       if ($(elem).height() < $minUl.height()) {
       $minUl = $(elem);
       }
       });*/
       return $minUl;
   }


    //分享动作  
   function SharePrdEx(id, name, img, page, share_text,desc) {
       name = unescape(name);
       if (SetShareLink(id, name, img, page, share_text, desc) == true) {
       /*
           $("#share-tck2").parents(".greybox").show();
           $("#share-tck2").animate({ top: "2%" }, 300);*/
           $("#dialogShareEvalute").modal("show");
       }
    }

//    //收藏    
//    function FavoritePrd(prdID) {       
//        var _data = "{ action:'" + 'add' + "',id:'" + prdID + "'}";
//        $.ajax({
//            type: "POST",
//            url: '../AjaxPages/FavoriteAjax.aspx',
//            data: _data,
//            dataType: "text",
//            success: function (resu) {
//                if (resu == "success") {
//                    alert("This item has been saved to your Favorites. To access, just log in to your account and select 'My Favorites'.");
//                }
//                else if (resu == "-1") {
//                    alert("Please log in!");
//                }
//                else {
//                    alert("Failed to favorite");
//                }
//            },
//            error: function (XMLHttpRequest, textStatus, errorThrown) {
//                alert("Failed to favorite");
//            }
//        });

//    }


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
}
*/
