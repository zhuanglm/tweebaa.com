var picPath = "https://tweebaa.com/";

$(document).ready(
function LoadInfo() {
    $.ajax({
        type: "Get",
        url: "../AjaxPages/indexAjax.aspx",
        data: "",
        success: function (resu) {
            var arry = new Array();
            arry = resu.split("@");
            var text = "";
            for (var i = 0; i < 3; i++) {
                if (i == 0) { text = "Submitted " }
                if (i == 1) { text = "Evaluated " }
                if (i == 2) { text = "Shared " }
                var data = eval(arry[i]);
                $(data).each(function (index) {
                    var obj = data[index];
                    var user = obj.username;
                    var name = obj.name;
                    var city = obj.CityName;
                    if (user != null && user != "") {
                        user = user.substring(0, 1) + " *** " + user.substring(user.length - 1, user.length);
                    }
                    if (name != null && name.length > 18) {
                        name = name.substring(0, 18) + "...";
                    }
                    if (city == null) {
                        city = "";
                    }
                    //$("#ul" + (i + 1)).append('<li><span class="name">' + user + '</span><span class="add">' + city + '</span> <span class="new">' + text + name + '</span></li>');
                    $("#ul" + (i + 1)).append('<li><span class="name">' + user + '</span><span class="new">' + text + name + '</span></li>');
                });
            }
            jQuery(".txtMarquee1-top").slide({ mainCell: ".bd ul", autoPage: true, effect: "topLoop", autoPlay: true, vis: 4 });
            jQuery(".txtMarquee2-top").slide({ mainCell: ".bd ul", autoPage: true, effect: "topLoop", autoPlay: true, vis: 4 });
            jQuery(".txtMarquee3-top").slide({ mainCell: ".bd ul", autoPage: true, effect: "topLoop", autoPlay: true, vis: 4 });
            var prdAll = eval(arry[3]);
            var prd0 = prdAll[0].ds; //评审
            var prd1 = prdAll[0].ds1; //预售
            var prd2 = prdAll[0].ds2; //销售
            var prd3 = prdAll[0].ds3; //竞价  
            var imgDoman = prdAll[1].imgDoman;
            var imgPath = "";
            var prdid = "";
            var prdimg = "";
            //var txt = "";

            //            txt = prd0[index].txtjj;
            //            if (txt.length > 32) {
            //                txt = txt.substring(0, 10);
            //            }
            var prdSharePage = "";
            var prdShareSalePrice = 0.0;
            var prdShareFunc = "";
            //评审中

            $(prd0).each(function (index) {
                /*
                
                imgPath = picPath + prd0[index].fileurl.replace("big", "mid2");
                prdimg = "'" + imgPath + "'";
                prdid = "'" + prd0[index].prdguid + "'";
                prdSharePage = "submitReview.aspx";
                prdSharePrice = prd0[index].estimateprice;
                prdShareFunc = "SharePrd(" + prdid + ", '" + escape(prd0[index].name) + "', " + prdimg + ",'" + prdSharePage + "','" + escape(prd0[index].txtjj) + "','" + prdSharePrice + "') ";
                var time = "2015/02/28";
                */
                if (prd0[index].fileurl == null) {
                    imgPath = "/images/spacer.gif";
                } else {
                    imgPath = picPath + prd0[index].fileurl.replace("big", "mid2");
                }
                prdimg = "'" + imgPath + "'";
                prdid = "'" + prd0[index].prdguid + "'";
                var saleCount = prd0[index].saleCount;
                if (saleCount == null) {
                    saleCount = 0;
                }

                var saleprice = prd0[index].saleprice;
                if (saleprice == null) {
                    saleprice = 0;
                }


                var minFinalSalePrice = prd0[index].saleprice; // prd0[index].MinFinalSalePrice;
                if (minFinalSalePrice == null) {
                    minFinalSalePrice = saleprice;
                }
                //if (minFinalSalePrice == 0) minFinalSalePrice=
                prdSharePage = "saleBuy.aspx";
                prdSharePrice = prd0[index].estimateprice; ; // minFinalSalePrice;
                prdShareFunc = "SharePrd(" + prdid + ", '" + escape(prd0[index].name) + "', " + prdimg + ",'" + prdSharePage + "','" + escape(prd0[index].txtjj) + "','" + prdSharePrice + "') ";

                var priceMSRP = '<del>$' + prd2[index].estimateprice.toFixed(2) + '</del>&nbsp;&nbsp;';

                var favoriteCount = prd2[index].FavoriteCount;
                if (favoriteCount == null) favoriteCount = 0;

                //var html0 = '<li><div class="item presale-ing"><div class="box"><div class="pic-box"><a href="presaleBuy.aspx?id=' + prd1[index].prdguid + '" target="_blank"  class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')"  title="Favorite">Favorite</a> <a href="#" class="down" title="Download">Download</a> <a href="javascript:void(0)" onclick="SharePrd(' + prdid + ',' + prd1[index].prdname + ',' + prdimg + ')" class="share" title="有偿Share">有偿Share</a></div></div><div class="row row1"><a href="#">' + prd1[index].name + '</a></div><div class="row row2"><a href="presaleBuy.aspx?id=' + prd1[index].prdguid + '" target="_blank" class="imglink">' + prd1[index].txtjj + '</a></div><div class="row row3 clearfix"><div class="zt1"><a href="presaleBuy.aspx?id=' + prd1[index].prdguid + '" target="_blank" class="gotoShopCar" title="加入购物车">加入购物车</a><del>$' + prd1[index].estimateprice + '</del> <strong class="color">$' + prd1[index].saleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt1"><div class="jdt"><span style="width:50%"></span></div><span class="fr">还剩' + time + '天</span> <span class="fl">预售:' + prd1[index].saleCount + '件</span> <span class="color">Test-Sale</span></div></div><i class="hot"></i></div></div></li>';
                //var html0 = '<li><div class="item review-ing"><div class="box"><div class="pic-box"><a href="./Product/submitReview.aspx?id=' + prd0[index].prdguid + '"  class="imglink"><img src="' + imgPath + '" alt="" /></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')" title="Favorite">Favorite</a><a href="javascript:void(0)" onclick="' + prdShareFunc + '" class="share" title="Share">Share</a></div></div><div class="row row1"><a href="./Product/submitReview.aspx?id=' + prd0[index].prdguid + '" >' + prd0[index].name + '</a></div><div class="row row2"><a href="./Product/submitReview.aspx?id=' + prd0[index].prdguid + '" class="imglink">' + prd0[index].txtjj + '</a></div><div class="row row3 clearfix"><a href="./Product/submitReview.aspx?id=' + prd0[index].prdguid + '"  class="btn i-want-eview">Evaluate</a><a href="../Product/inventory.aspx?proid=' + prd0[index].prdguid + '" class="btn competitive-supply">Supply</a><a href="?id=' + prd0[index].prdguid + '" class="btn i-have-way">Solution</a><strong>$' + prd0[index].estimateprice + '</strong></div><div class="row row4 clearfix"><div class="eview-ok"><div class="state"><span class="zt1">Public Evaluating</span><span class="zt2">Tweebaa Evaluating</span></div><p><b>' + prd0[index].reviewCount + '</b> Evaluated</p></div><div class="fabu-time">Submitted on:<p>' + time + '</p></div></div><div class="row row5 clearfix"><div class="eview-ok"><p><b>1666</b>Solutions</p></div><div class="lose">Reason not approved <br />No suitable supply channels</div></div></div></div>';
                //var html0 = '<li><div class="item sales-ing"><div class="box"><div class="pic-box"><a href="./Product/saleBuy.aspx?id=' + prd0[index].prdguid + '"  class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')"  title="Favorite">Favorite</a> <a href="javascript:void(0)" onclick="' + prdShareFunc + '" class="share" title="Share">Share</a></div></div><div class="row row1"><a href="#">' + prd0[index].name + '</a></div><div class="row row2"><a href="./Product/saleBuy.aspx?id=' + prd0[index].prdguid + '"  class="imglink">' + GetShortDesc(prd0[index].txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt2"><a href="./Product/presaleBuy.aspx?id=' + prd0[index].prdguid + '"  class="gotoShopCar" title="Add to cart">Add to cart</a>' + priceMSRP + '<strong class="color">$' + minFinalSalePrice.toFixed(2) + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><a href="javascript:;" class="loveNumber" title="like">' + favoriteCount + '</a></span> <span class="fl">Sold：' + saleCount + ' pieces</span> <span class="color">Buy Now </span></div></div></div></div></li>';
                var html0 = '<li><div class="item sales-ing"><div class="box"><div class="pic-box"><a href="./Product/saleBuy.aspx?id=' + prd0[index].prdguid + '"  class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')"  title="Favorite">Favorite</a> <a href="javascript:void(0)" onclick="' + prdShareFunc + '" class="share" title="Share">Share</a></div></div><div class="row row1"><a href="./Product/saleBuy.aspx?id=' + prd0[index].prdguid + '">' + prd0[index].name + '</a></div><div class="row row2"><a href="./Product/saleBuy.aspx?id=' + prd0[index].prdguid + '"  class="imglink">' + GetShortDesc(prd0[index].txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt2"><a href="./Product/presaleBuy.aspx?id=' + prd0[index].prdguid + '"  class="gotoShopCar" title="Add to cart">Add to cart</a>' + priceMSRP + '<strong class="color">$' + minFinalSalePrice.toFixed(2) + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><a href="javascript:;" class="loveNumber" title="like">' + favoriteCount + '</a></span><a href="./Product/saleBuy.aspx?id=' + prd0[index].prdguid + '"><span class="color">Buy Now </span></a></div></div></div></div></li>';
                $("#ulData").append(html0);
            });

            //Test-Sale
            $(prd1).each(function (index) {
                imgPath = picPath + prd1[index].fileurl.replace("big", "mid2");
                prdimg = "'" + imgPath + "'";
                prdid = "'" + prd1[index].prdguid + "'";
                var time = 1;
                var saleCount = prd1[index].saleCount;
                if (saleCount == null) {
                    saleCount = 0;
                }
                var saleprice = prd1[index].saleprice;
                if (saleprice == null) {
                    saleprice = 0;
                }

                // test sale share
                prdSharePrice = saleprice;
                prdSharePage = "presaleBuy.aspx";
                prdShareFunc = "SharePrd(" + prdid + ", '" + escape(prd1[index].name) + "', " + prdimg + ",'" + prdSharePage + "','" + escape(prd1[index].txtjj) + "','" + prdSharePrice + "') ";
                // test sale progress
                var testSaleTarget = prd1[index].presaleforward;
                var testSaleProgress = (saleCount / testSaleTarget) * 100;
                if (testSaleProgress < 1) testSaleProgress = 1;
                var testSaleLeftCount = testSaleTarget - saleCount;

                // test sale left day(s)
                var testSaleLeftDay = prd1[index].presaleendday;
                //alert(prd1[index].presaleendday);
                var testSaleLeftDayDisp = "";
                if (testSaleLeftDay <= 0) testSaleLeftDayDisp = "Time over";
                else testSaleLeftDayDisp = " Days left: " + testSaleLeftDay;


                //var html1 = '<li><div class="item presale-ing"><div class="box"><div class="pic-box"><a href="./Product/presaleBuy.aspx?id=' + prd1[index].prdguid + '" class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')"  title="Favorite">Favorite</a> <a href="javascript:void(0)" onclick="' + prdShareFunc + '" class="share" title="Share">Share</a></div></div><div class="row row1"><a href="#">' + prd1[index].name + '</a></div><div class="row row2"><a href="./Product/presaleBuy.aspx?id=' + prd1[index].prdguid + '"  class="imglink">' + GetShortDesc(prd1[index].txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt1"><a href="./Product/presaleBuy.aspx?id=' + prd1[index].prdguid + '"  class="gotoShopCar" title="Add to cart">Add to cart</a><del>$' + prd1[index].estimateprice + '</del> <strong class="color">$' + saleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt1"><div class="jdt"><span style="width:' + testSaleProgress + '%"></span></div><span class="fr">' + testSaleLeftDayDisp + '</span> <span class="fl">Test-Sale:' + saleCount + '/' + testSaleTarget + 'pieces</span></div></div><i class="hot"></i></div></div></li>';
                var html1 = '<li><div class="item presale-ing"><div class="box"><div class="pic-box"><a href="./Product/presaleBuy.aspx?id=' + prd1[index].prdguid + '" class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')"  title="Favorite">Favorite</a> <a href="javascript:void(0)" onclick="' + prdShareFunc + '" class="share" title="Share">Share</a></div></div><div class="row row1"><a href="./Product/presaleBuy.aspx?id=' + prd1[index].prdguid + '">' + prd1[index].name + '</a></div><div class="row row2"><a href="./Product/presaleBuy.aspx?id=' + prd1[index].prdguid + '"  class="imglink">' + GetShortDesc(prd1[index].txtjj) + '...Read more</a></div><div class="row row3 clearfix"><div class="zt1"><a href="./Product/presaleBuy.aspx?id=' + prd1[index].prdguid + '"  class="gotoShopCar" title="Add to cart">Add to cart</a><del>$' + prd1[index].estimateprice + '</del> <strong class="color">$' + saleprice + '</strong></div></div><div class="row row4 clearfix"><div class="zt1"><div class="jdt"><span style="width:' + testSaleProgress + '%"></span></div><span class="fr">' + testSaleLeftDayDisp + '</span> <span class="fl">Test-Sale Units left: ' + testSaleLeftCount + '</span></div></div><i class="hot"></i></div></div></li>';

                $("#ulData").append(html1);
            });
            //销售中
            /* temp remove by Long base on pre-sale 
            $(prd2).each(function (index) {
            if (prd2[index].fileurl == null) {
            imgPath = "/images/spacer.gif";
            } else {
            imgPath = picPath + prd2[index].fileurl.replace("big", "mid2");
            }
            prdimg = "'" + imgPath + "'";
            prdid = "'" + prd2[index].prdguid + "'";
            var saleCount = prd2[index].saleCount;
            if (saleCount == null) {
            saleCount = 0;
            }
            var saleprice = prd2[index].saleprice;
            if (saleprice == null) {
            saleprice = 0;
            }

            var minFinalSalePrice = prd2[index].MinFinalSalePrice;
            if (minFinalSalePrice == null) {
            minFinalSalePrice = saleprice;
            }
            prdSharePage = "saleBuy.aspx";
            prdSharePrice = minFinalSalePrice;
            prdShareFunc = "SharePrd(" + prdid + ", '" + escape(prd2[index].name) + "', " + prdimg + ",'" + prdSharePage + "','" + escape(prd2[index].txtjj) + "','" + prdSharePrice + "') ";

            var priceMSRP = '<del>$' + prd2[index].estimateprice.toFixed(2) + '</del>&nbsp;&nbsp;';

            var favoriteCount = prd2[index].FavoriteCount;
            if (favoriteCount == null) favoriteCount = 0;
            var html2 = '<li><div class="item sales-ing"><div class="box"><div class="pic-box"><a href="./Product/saleBuy.aspx?id=' + prd2[index].prdguid + '"  class="imglink"><img src="' + imgPath + '" alt=""></a><div class="floatDiv"><a href="javascript:void(0)" class="love" onclick="FavoritePrd(' + prdid + ')"  title="Favorite">Favorite</a> <a href="javascript:void(0)" onclick="' + prdShareFunc + '" class="share" title="Share">Share</a></div></div><div class="row row1"><a href="./Product/saleBuy.aspx?id=' + prd2[index].prdguid + '">' + prd2[index].name + '</a></div><div class="row row2"><a href="./Product/saleBuy.aspx?id=' + prd2[index].prdguid + '"  class="imglink">' + GetShortDesc(prd2[index].txtjj) + '...Read More</a></div><div class="row row3 clearfix"><div class="zt2"><a href="./Product/presaleBuy.aspx?id=' + prd2[index].prdguid + '"  class="gotoShopCar" title="Add to cart">Add to cart</a>' + priceMSRP + '<strong class="color">$' + minFinalSalePrice.toFixed(2) + '</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><a href="javascript:;" class="loveNumber" title="like">'+ favoriteCount + '</a></span> <span class="fl">Sold：' + saleCount + ' pieces</span> <span class="color">Buy Now </span></div></div></div></div></li>';
            $("#ulData").append(html2);
            });
            */
            $(".pro-show").slide({ mainCell: "ul", autoPlay: true, effect: "left", vis: 4, scroll: 4, autoPage: true, pnLoop: true });
        },
        error: function (obj) {
            // alert("Load failed");
        }
    });
}
)


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



