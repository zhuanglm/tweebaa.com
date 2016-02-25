<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="CollageShare.aspx.cs" Inherits="TweebaaWebApp2.Product.CollageShare" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="/css/buyall.css" />

    <link rel="stylesheet" href="/css/shareall.css" />
    <link href="/css/multiSelect.css" rel="stylesheet" type="text/css" />
     <link href="/css/submit.css" rel="stylesheet" type="text/css" />
     <link href="/css/shareBox.css" rel="stylesheet" type="text/css" />
     <link href="/css/shareall.css" rel="stylesheet" type="text/css" />

  
    <script src="../MethodJs/share.js?v=20160209" type="text/javascript"></script>

        <!-- CSS Theme -->
     <link rel="stylesheet" href="/css/theme-skins/dark.css">
          
    <script src="/js/jspage/kkpager.js" type="text/javascript"></script>
    <link href="/js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />

      <script type="text/javascript" src="/js/CollageDesign.js?v=20160209"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">


            <!--=== Breadcrumbs v4 ===-->
    <div class="breadcrumbs-v4 share_back">
        <div class="container">
          <h1> <strong>Share products</strong> with your friends...</h1>
          <p>Earn cash and points for sharing on your social networks!</p>
            <ul class="breadcrumb-v4-in">
                <li><a href="/index.aspx">Home</a></li>
                <li><a href="#">Share</a></li>
                <li class="active">Collage</li>
            </ul>
        </div><!--/end container-->
    </div> 
    <!--=== End Breadcrumbs v4 ===-->
 <!--=== Content Part ===-->
    <div class="content container">
        <div class="row">
            <div class="col-md-3 filter-by-block md-margin-bottom-60">
   <div class="row margin-bottom-40"><div class="col-md-12">
<button class="btn-u btn-brd rounded-4x btn-u-yellow btn-u-sm btn-block" onclick="window.location.href='/Product/collage.aspx'" type="button">Create New Collage</button>
</div></div>

    <div style="margin-top:6px;" class="row  margin-bottom-40">
	         <div class="col-md-6">
               <a  href="https://itunes.apple.com/ca/app/tweebaa/id1027840811?mt=8" 
			     alt="Tweebaa at Apple Store"><img src="/images/app.png" width="100%"></a></div>
			      <div class="col-md-6">
 <a   href="https://play.google.com/store/apps/details?id=com.Tweebaa.App.CollageApp" 
			     alt="Tweebaa at Google Play"><img src="/images/android2.png" width="100%"></a></div></div>
			         <div class="row  margin-bottom-40"><div class="col-md-12">
	     <a href="#" onclick="OpenVideo()"><img src="/images/earnie-share-2.png" width="80%" style=" padding-left:15%;" /></a>
</div></div>

            </div>

            <div class="col-md-9">
                <div class="row margin-bottom-5">
                    <div class="col-sm-4 ">

                          <div class="input-group sort-list-search">
                    <input type="text" class="form-control" placeholder="Search ..." id="txtSearch">
                    <span class="input-group-btn">
                        <button class="btn-u" type="button" onclick="DoKeywordSearch()"><i class="fa fa-search"></i></button>
                    </span>
                </div>
                    </div>
                    <div class="col-sm-8 hidden-col">
                        <ul class="list-inline clear-both">
                            <li class="grid-list-icons ">
                                <a href="#" onclick="show_by_list()"><i class=" fa fa-th-list"></i></a>
                                <a href="#" onclick="show_by_grid()"><i class="fa fa-th"></i></a>
                            </li>
                            <li class="sort-list-btn">
                                <h3>Sort By :</h3>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                        <span id="spanSortType">Publish Time</span> <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu" role="menu">
                                        <li><a href="#" onclick="Collage_orderBy(1)" sort-data="1">Publish Time</a></li>
                                        <li><a href="#" onclick="Collage_orderBy(2)" sort-data="2">Name</a></li>
                                    </ul>
                                </div>
                            </li>
                            <li class="sort-list-btn">
                                <h3>Show :</h3>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                        <span id="spanPageSize">21</span> <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu" role="menu">
                                        <li><a href="javascript:void(0);" onclick="pageSizeSelect(21)">21</a></li>
                                        <li><a href="javascript:void(0);" onclick="pageSizeSelect(12)">12</a></li>
                                        <li><a href="javascript:void(0);" onclick="pageSizeSelect(6)">6</a></li>
                                        <li><a href="javascript:void(0);" onclick="pageSizeSelect(3)">3</a></li>
                                    </ul>
                                </div>
                            </li>
                        </ul>
                    </div>    
                </div><!--/end result category-->

                <div class="result-select">				
			        <span class="text-highlights" id="searchResult"></span>
		        </div> 
 
                <!--/end result category-->
                <div class="filter-results" id="Collage_listings">

                </div><!--/end filter resilts-->

                <div class="text-center">
                    <div id="kkpager" style="padding-right:150px;"></div>                                                         
                </div><!--/end pagination-->
            </div>
        </div><!--/end row-->
    </div><!--/end container-->    


 

    <input type="hidden" id="hidpersent" value="<%=_persent %>" />
    <input type="hidden" id="hiduserid" value="<%=_userid %>" />
	<script type="text/javascript">

	    var sKeywords = "";
	    var iSortBy = 1;
	    var iListType = 1;
	    $(function () {
	        //url data function dataType
	        loadCollageTotal();
	        loadCollage(1);
	    });
	    $("#btnCloseBox").click(function () {
	        $(this).parents(".greybox").hide();
	        return false;
	    })

	    function loadCollageTotal() {
	        $("#kkpager").html("");
	        $("#prd_listings").html("loading data....");

	        $.ajax({
	            type: "POST",
                async : false,
	            url: "/Product/CollageLoadDesign.ashx",
	            data: "{ 'action':'" + "load_publish_total"
                    + "','Keyword':'" + sKeywords

	            + "'}"
	        }).done(function (resu) {
	            //showSearchResult(resu);
	            /*
	            var html = CreateCollageHtml(xml);
	            $("#Collage_listings").html(html);
	            */
	            //KKPager
	            showSearchResult(resu);
	        });

	    }
	    function showSearchResult(count) {

	        var cntProduct = parseInt(count);
	        searchResultHtml = "Your search matched " + cntProduct + " result";
	        if (cntProduct > 1) searchResultHtml = searchResultHtml + "s";
	        searchResultHtml = searchResultHtml + "."
	        $("#searchResult").html(searchResultHtml);

	        var iTotal = Math.ceil(count / pageDiv);
	        recordCount = count;
	        iTotalPage = iTotal;

	        // load first page
	        LoadKKPager(1);

	    }
	    function loadCollage(iPage) {
	        //iSortOrder
	        $.ajax({
	            type: "POST",
	            async: false,
	            url: "/Product/CollageLoadDesign.ashx",
	            data: "{ 'action':'" + "load_all_publish"
                    	+ "','page':'" + iPage
                        + "','pageDiv':'" + pageDiv
                        + "','keyword':'" + sKeywords
                        + "','SortOrder':'" + iSortBy
	                + "'}",
	            dataType: "xml"
	        }).done(function (xml) {
	            //showSearchResult(resu);
	            var html = CreateCollageHtml2(xml);
	            $("#Collage_listings").html(html);

	        });

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
	            totalRecords: recordCount,
	            mode: 'click', //默认值是link，可选link或者click
	            click: function (n) {
	                page = n;
	                loadCollage(n);
	                LoadKKPager(page);
	                //this.selectPage(n); //手动选中按钮
	                return false;
	            }
	        }, true);

	    }
	    function CreateCollageHtml2(xml) {
	        var html = "";
	        //$("#kkpager").html("");
	        //$("#Collage_listings").html("loading data....");
	        var iCount = 0;
	        $(xml).find('design').each(function () {
	            var sID = $(this).find('ID').text();
	            var sImage = $(this).find('Image').text();
	            var sShareImage = sImage;
	            var sOnErrorSrc = sImage;
	            if (sImage.length > 10 && sImage.indexOf("http://") >= 0) {

	            } else {
	                sImage = picDesignImgPath + sImage;
	                sShareImage = picShareDesignImgPath + sImage;
	                sOnErrorSrc = "http://itweebaa.com" + sImage;
	            }
	            //var sImage = picDesignImgPath + $(this).find('Image').text();
	            var sTitle = RemoveCRLF($(this).find('Title').text());
	            var sInspiration = RemoveCRLF($(this).find('Inspiration').text());
	            var sUsername = $(this).find('Username').text();
	            sUsername = sUsername.replace("$_$", "@");

	            var sShareCount = $(this).find('ShareCount').text();
	            var urlPage = "CollageReview.aspx";
	            // console.log("stitle=" + sTitle);

	            if (iListType == 1) {
	                //List by Grid
	                if (iCount % 3 == 0) {
	                    html += '<div class="row illustration-v2 margin-bottom-20">';
	                }
	                html += '<div class="col-md-4">';
	                html += '<div class="product-img product-img-brd">';
	                html += '<a href="CollageReview.aspx?design_id=' + sID + '" class="imglink"><img onerror="this.src=\''+sOnErrorSrc+'\'" class="full-width img-responsive" src="' + sImage + '" alt=""></a>';
	                html += '<span class="add-to-cart add-share" > <a href="javascript:void(0)" onclick="ShareCollage(' + sID + ',\'' + sTitle + '\',\'' + sShareImage + '\',\'' + urlPage + '\',\'' + sInspiration + '\')"><i class=" icon-custom rounded-x fa fa-share-alt"></i></a>';
	                html += '<a href="javascript:void(0)" onclick="FavoriteCollage(\'' + sID + '\')"> <i class="icon-custom rounded-x fa fa-heart-o"></i> </a>';
	                html += '</span>';
	                //html+='<div class="shop-rgba-dark-green rgba-banner"> Free shipping to USA</div>';
	                html += '</div> ';
	                html += '<div class="product-description product-description-brd share-height margin-bottom-30 ">';
	                html += '<div class="overflow-h">';
	                html += '<div class="pull-left margin-bottom-10">';
	                html += '<h4 class="title-price share-price h-auto"><a href="CollageReview.aspx?design_id=' + sID + '">' + sTitle + '</a></h4>';
	                html += '<span class="nogender">' + sInspiration + '</span></div>';

	                html += '</div>';
	                html += '<span class="designer">Designer: ' + sUsername + '</span>';
	                html += '</div>';
	                html += '</div>';
	                if (iCount % 3 == 2) {
	                    html += '</div>';
	                }
	                iCount++;
	            } else {
	                //List by List
	                html = html + '<div class="list-product-description product-description-brd share-height margin-bottom-30">';
	                html = html + '<div class="row">';
	                html = html + '    <div class="col-sm-4">';
	                html = html + '        <a href="CollageReview.aspx?design_id=' + sID + '"><img onerror="this.src=\'' + sOnErrorSrc + '\'" class="img-responsive sm-margin-bottom-20" src="' + sImage + '" alt=""></a>';
	                html = html + '    </div> ';
	                html = html + '    <div class="col-sm-8 product-description">';
	                html = html + '        <div class="overflow-h margin-bottom-5">';
	                html = html + '             <ul class="list-inline overflow-h">';
	                html = html + '                <li><h4 class="title-price"><a href="CollageReview.aspx?design_id=' + sID + '">' + sTitle + '</a></h4></li>';
	                html = html + '            <p class="margin-bottom-20"><a href="CollageReview.aspx?design_id=' + sID + '">Designer: ' + sUsername + '</a></p>';
	                html = html + '            <ul class="list-inline add-to-wishlist margin-bottom-20" style="padding-top:10px;">';
	                html = html + '                <li class="wishlist-in">';
	                html = html + '                    <i class="fa fa-heart-o"></i>';
	                html = html + '                    <a href="javascript:void(0)" onclick="FavoriteCollage(\'' + sID + '\')">Add Favorite</a>';
	                html = html + '                </li>';
	                html = html + '                <li class="compare-in">';
	                html = html + '                    <i class="fa fa-share-alt"></i>';
	                html = html + '                    <a href="javascript:void(0)" onclick="ShareCollage(' + sID + ',\'' + sTitle + '\',\'' + sImage + '\',\'' + urlPage + '\',\'' + sInspiration + '\')" >Share & Earn</a>';
	                html = html + '                </li>';
	                html = html + '            </ul>';
	                // html = html + '            <a  class="btn-u btn-u-sea-shop" href="presaleBuy.aspx?id=' + prd.prdGuid + '"  ><i class="fa fa-shopping-cart"></i>Add to Cart</a>';
	                html = html + '        </div>';
	                html = html + '    </div>';
	                html = html + '</div>';
	                html = html + '</div>';

	            }
	            /*
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
	            */

	            //console.log("html="+html);
	        });
	        return html;

	    }

	    function show_by_list() {
	        iListType = 2;
	        DoSearch();
	    }
	    function show_by_grid() {
	        iListType = 1;
	        DoSearch();
	    }
	    function DoKeywordSearch() {
	        sKeywords = $("#txtSearch").val();
	        DoSearch();
	    }
	    function DoSearch() {
	        page = 1;
	        $("#Collage_listings").empty();
	        loadCollageTotal();
	        loadCollage(1);
	    }
	    function OpenVideo() {
	        var iRand = getRandomInt(1, 100);
	        var iRet = iRand % 3;
	        var youtube = "";
	        if (iRet == 0) {
	            youtube = "https://www.youtube.com/embed/YpS88z4yEsU";
	        }
	        if (iRet == 1) {
	            youtube = "https://www.youtube.com/embed/3zn4qQqqW0Q";
	        }
	        if (iRet == 2) {
	            youtube = "https://www.youtube.com/embed/Gvqd8_nqh_Y";
	        }
	        $("#divResponsiveVideo").html('<iframe id="frmVideo" src="'+youtube+'" width="540" height="400" frameborder="0" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>');
	        $("#ModalVideo").modal("show");
	    }
	    function getRandomInt(min, max) {
	        return Math.floor(Math.random() * (max - min + 1)) + min;
	    }
	    function playPause() {
	        var myVideo = $("#prdVideo");
	        // if (myVideo.paused)
	        myVideo.get(0).play();
	        /*
	        else
	        myVideo.pause();*/
	    }
</script>

<div class="modal fade" style="top:50px;" id="ModalVideo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
            <div class="modal-dialog" style="width:600px;">
                <div class="modal-content">
                    <div class="modal-header">
                        <button aria-hidden="true" data-dismiss="modal" class="close" type="button" onclick='$("#ModalVideo").modal("hide");'>×</button>
                    </div>
                    <div class="modal-body">
                             
<div class="responsive-video" id="divResponsiveVideo">

<!--
    <iframe id="frmVideo" src="/Product/HomeVideo.aspx" width="840" height="400" frameborder="0" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>
    -->
</div>
                                     
                    </div>
                                 
                    </div>
            </div>
</div>


</asp:Content>
