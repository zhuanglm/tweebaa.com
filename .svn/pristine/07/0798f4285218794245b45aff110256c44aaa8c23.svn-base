var step = "";//评审区产品状态：1大众评审；4推易吧评审；5评审失败
var page = 1; //页码
var orderby = "ranking desc"; //排序条件
var picPath = "https://tweebaa.com/";
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
       if (orderStr == "By Ranking") { orderby = " ranking desc "; };
       if (orderStr == "By Time") { orderby = " addtime desc "; };
       if (orderStr == "By Price") { orderby = " estimateprice desc "; };
       if (orderStr == "By Name") { orderby = " name asc "; };
       if (orderStr == "By Evaluator") { orderby = " reviewCount desc "; };
       if (orderStr == "By clicks") { orderby = " reviewCount desc "; };
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
       // search from 3 level categories
       $("#mainsrp-itemlist .items").empty();
       loadMeinv(cateID);
   
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
       $("#chkBoxList input:checkbox:checked").map(function(){
            focusCateIDs.push($(this).val());
       });
      
       // get total record
       $.ajax({
           type: "Post",
           url: "../../AjaxPages/prdReviewAjax.aspx",
           async: false,
           data: "{'action':'reviewPrdCount','cate':'" + cateID
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

       $.ajax({
           type: "Post",
           url: "../../AjaxPages/prdReviewAjax.aspx",
           data: "{'action':'reviewPrd','cate':'" + cateID
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

               var urlPage = "'submitReview.aspx'";
               for (var i = 0; i < obj.length; i++) {
                   var prd = obj[i];
                   var prdid = "'" + prd.prdguid + "'";
                   var prdname = "'" + escape(prd.name) + "'";
                   var imgPath = picPath + prd.fileurl.replace("big", "mid2");
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
                   html = '<div class="item ' + nowAddCLass + '"><div class="box"><div class="pic-box"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="imglink"><img src="' + imgPath + '" alt="" /></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a><a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prdname + ',' + prdimg + ',' + urlPage + ',' + prdDesc + ')" class="share" title="Share">Share</a></div></div><div class="row row1"><a href="submitReview.aspx?id=' + prd.prdguid + '" >' + prd.name + '</a></div><div class="row row22"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="imglink">' + prdDescShort + '</a></div><div class="row row3 clearfix"><a href="submitReview.aspx?id=' + prd.prdguid + '"  class="btn i-want-eview">Evaluate</a><a href="../Product/inventory.aspx?proid=' + prd.prdguid + '" class="btn competitive-supply">Supply</a><a href="?id=' + prd.prdguid + '" class="btn i-have-way">Solution</a><strong>$' + prd.estimateprice + '</strong></div><div class="row row4 clearfix" style="display:none;"><div class="eview-ok"><div class="state"><span class=zt1>Public Evaluating</span><span class=zt2>Tweebaa Evaluating</span></div><p><b>' + reviewCount + '</b> Evaluated</p></div><div class="fabu-time">Submitted on<p>' + time + '</p></div></div><div class="row row5 clearfix"><div class="eview-ok"><p><b>1666</b>Solutions</p></div><div class="lose">Reason not approved <br />No suitable supply channels</div></div></div></div>';
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
                   dofristshare_prdSaleAllminUl = getMinUl();
                   dofristshare_prdSaleAllminUl.append(html);
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
   function SharePrd(id, name, img, page, desc) {
       name = unescape(name);
       if (SetShareLink(id, name, img, page, desc, 0.0) == true) {
           $("#share-tck2").parents(".greybox").show();
           $("#share-tck2").animate({ top: "2%" }, 300);
       }
    }

    //收藏    
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

