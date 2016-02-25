<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" 
CodeBehind="CollageShare.aspx.cs" Inherits="TweebaaWebApp.Product.CollageShare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Share Tweebaa collages:  Have fun AND earn rewards
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

	<link rel="stylesheet" href="../css/index.css" />
	<link rel="stylesheet" href="../css/shareall.css" />

	<script src="../js/jquery.min.js" type="text/javascript"></script>
	<script src="../js/qtab.js" type="text/javascript"></script>
	<script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
	<link rel="stylesheet" href="../css/selectCss.css" />
	<script src="../js/jquery.placeholder.js" type="text/javascript"></script>
	<script type="text/javascript" src="../js/selectNav.js"></script>
	<script type="text/javascript" src="../js/public.js"></script>
    <style>
     #CollageShareItem .inline_block
     {
         display: inline-block;
     }
    </style>

    <script type="text/javascript" src="../js/CollageDesign.js"></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">  

<div class="list-banner share-all">
	 <ul>
     <li><img src="../Images/share-banner.jpg" width="295" height="129" alt=""/></li>
     <li class="p3">EXPRESS YOURSELF and discover EARNING POWER of Product Collages!</li>
     <li class="found-pic">
				<a href="collageCreate.aspx">Create Collage</a>
      </li>
      </ul>
	</div>
	<!-- select 筛选 -->
	<div class="w964">
		<div id="selectnav" class="clearfix">

			<div class="select-search bdccc fl">
				<input type="text" id="txtKeywords" class="txt" placeholder="Enter key words"/>

			</div>
			<div class="search-button fl">
				<button  onclick="DoCollageShareSearch()" class="btn-search" type="submit"></button>
			</div>
		</div>
	</div>
	<!-- select 筛选 -->

	
	<!-- 筛选显示 -->
	<div class="w964">
		<div class="select-show clearfix tc" >
			<!--span>
				<a href="share-2.html" class="first" style="display:none">All</a> <a href="prdSingleShare.aspx" class="first on">
			</span-->
			<span class="first">
				<a href="CollageShare.aspx" class="first on">Collage</a>
			</span>
			<span class="last">
				<a href="prdSingleShare.aspx" class="last">Single Product</a>
			</span>
		</div>
	</div>
	<!-- 筛选显示 -->

	<!-- 筛选排序 -->
	<div class="w964">
		<div class="select-sort clearfix">
			<div class="sort-row fr pr">
				<h3 class="bdccc" sort-data="0">Publish Time</h3>
				<ul>
					<li>
						<a href="#" onclick="Collage_orderBy(1)" sort-data="1">Publish Time</a>
					</li>
					<li>
						<a href="#" onclick="Collage_orderBy(2)" sort-data="2">Name</a>
					</li>
				</ul>
			</div>
	    </div>
	</div>
	<!-- 筛选排序 -->

	<!-- 列表	 -->
	<div class="w964 buy-page" id="mainsrp-itemlist" >
		<div class="m-itemlist" id="CollageShareItem">
			<div class="items inline_block">
				


			</div>
			<div class="down-more tc">
				<a href="#" id="down-more">View More</a>
			</div>
		</div>
	</div>


     <!-- 登录分享弹出框 -->
    
    <div class="greybox">
        <div id="share-tck2" class="tck">
             <a href="#" class="closeBtn" title="Close"></a>
             <h2 class="t">
                <span>Share & Earn</span>
            </h2>
             <div class="box">
                <div class="sharebox clearfix my-dietu">
                    <span class="fl t ">Share to </span>
                    <div class="bdsharebuttonbox fl">
                                                <a href="javascript:void(0);" target="_blank" id="shareToFacebook" title="Facebook"><img src="../Images/flat-circles_03.png" /></a>&nbsp;&nbsp;
                        <a href="javascript:void(0);" target="_blank" id="shareToTwitter" title="Twitter"><img src="../Images/flat-circles_05.png" /></a>&nbsp;&nbsp;
                        <a href="javascript:void(0);" target="_blank" id="shareToGoogle" title="Google"><img src="../Images/flat-circles_13.png" /></a>&nbsp;&nbsp;
                        <!--a href="javascript:void(0)" target="_blank" id="share4" title="Wechat"><img src="../Images/share-rss.png" /></a>&nbsp;&nbsp;-->
                        <a href="javascript:void(0);" target="_blank" id="shareToPinterest" title="Pinterest"><img src="../Images/share-pin.png" /></a>&nbsp;&nbsp;
                        
                        <a href="javascript:void(0)" target="_blank" id="shareToEmail" title="Email"><img src="../Images/share-mail.png" /></a>

                    </div>                  
                    <!--a href="/Home/Index.aspx" class="share-media-set">Link My Account</a-->
                </div>
                <div class="ps clearfix">
                    <span class="fr"><a href="#"></a></span><span class="fl">You will earn  <!--span id="sharePercent"></span-->commission when your friend makes a purchase from your shared link. </span>
                </div>
            </div>
            
        </div>
    </div>

    <input type="hidden" id="hidpersent" value="<%=_persent %>" />
    <input type="hidden" id="hiduserid" value="<%=_userid %>" />

	<script type="text/javascript">
	    var $minUl;
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
	    // to search by enter key
	    $("#txtKeywords").keyup(function (event) {
	        if (event.which == 13) {
	            DoCollageShareSearch();
	            $("#txtKeywords").focus();

	        }
	    });

	    function DoCollageShareSearch() {
	        var iPage = 1;
            var txtKeywords = $("#txtKeywords").val();

                    $.ajax({
	                type: "POST",
	                url: "CollageLoadDesign.ashx",
	                data: "{ 'action':'" + "load_search_publish"
                    	     + "','page':'" + iPage
                             + "','pageDiv':'" + pageDiv 
                             + "','txtKeywords':'" + txtKeywords 
	                        +"'}",
	                dataType: "xml"
	            }).done(function (xml) {
	                var html = CreateCollageHtml(xml);
	                
	                $minUl.html(html);
	            });
         }
	    //表单提示
	    $('input, textarea').placeholder();
	    //表单美化
	    $('.chklist').hcheckbox();


	    //筛选排序
	    $(".sort-row").mouseenter(function (event) {
	        $(this).find('ul').show();
	    }).mouseleave(function (event) {
	        $(this).find('ul').hide();
	    });
	    $(".sort-row").find("a").click(function () {
	        $(this).parent("li").addClass('on').siblings('li').removeClass('on').parent("ul").hide();
	        $(".sort-row > h3").attr('sort-data', $(this).attr('sort-data')).text($(this).text())
	    })


	    //显示 Favorite和分享

	    $("#mainsrp-itemlist .box").live('mouseenter', function (event) {
	        $(this).addClass('hover').parent().css('zIndex', '100');
	        $(this).find(".floatDiv").stop().animate({ top: 0 }, 100)
	    }).live('mouseleave', function (event) {
	        $(this).removeClass('hover').parent().css('zIndex', '');
	        $(this).find(".floatDiv").stop().animate({ top: "-110px" }, 100)
	    });

	    $(".share-btn").live('mouseenter', function (event) {
	        $(this).siblings().show();
	    }).live('mouseleave', function (event) {
	        $(this).siblings().hide();
	    });
	    $(".closeBtn,.go-share-btn").click(function () {
	        $(this).parents(".greybox").hide();
	        return false;
	    })
	    //模拟点击分享按钮，随机 登陆 和未登录状态 。

	    $(".share-btn").live('click', function (event) {
	        var shareTck = ["#share-tck2", "#share-tck"]
	        var thisb = $(shareTck[parseInt(Math.random() * 2)])
	        thisb.animate({ top: "2%" }, 300);
	        thisb.parent().show()
	        return false;
	    });


</script>

	<!-- 无线加载js -->
	<script type="text/javascript">
	    
	    $(function () {
	        //url data function dataType
	        var iPage = 1;
	        function loadMeinv(iPage) {

	            $.ajax({
	                type: "POST",
	                url: "CollageLoadDesign.ashx",
	                data: "{ 'action':'" + "load_all_publish"
                    	     + "','page':'" + iPage
                             + "','pageDiv':'" + pageDiv 
	                        +"'}",
	                dataType: "xml"
	            }).done(function (xml) {
	                var html = CreateCollageHtml(xml);
	                
	                $minUl = getMinUl();
	                $minUl.append(html);
	                // $("#CollageTemplate").html(html);



	            });

	        }
	        loadMeinv(0);
	        //无限加载
	        $(window).on("scroll", function () {
	            $minUl = getMinUl();
	            if ($minUl.height() <= $(window).scrollTop() + $(window).height()) {
	                //如果要鼠标滚动就加载，
	                //loadMeinv();//加载新图片
	            }
	        })

	        //点击更多加载
	        $("#down-more").click(function () {
	            $minUl = getMinUl();
	            loadMeinv();
	            return false;
	        });

	    })
</script>
</asp:Content>