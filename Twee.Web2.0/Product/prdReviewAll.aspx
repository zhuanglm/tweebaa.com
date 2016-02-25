﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="prdReviewAll.aspx.cs" Inherits="TweebaaWebApp2.Product.prdReviewAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Evaluate Tweebaa products: Have fun AND earn rewards
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
<%=TweebaaWebApp2.SEOTextDefine.PrdReviewAllSEOMeta %>
<link href="/css/multiSelect.css" rel="stylesheet" type="text/css" />
    <script src="/MethodJs/SearchByCate.js" type="text/javascript"></script>
    <script src="/MethodJs/multiSelect.js" type="text/javascript"></script>
   <%-- <script src="../js/qtab.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
   <%-- <link rel="stylesheet" href="/css/selectCss.css" />--%>
    <link href="/css/submit.css" rel="stylesheet" type="text/css" />
     <link href="/css/shareBox.css" rel="stylesheet" type="text/css" />
     <link href="/css/shareall.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.placeholder.js" type="text/javascript"></script>
   <%-- <script type="text/javascript" src="../js/selectNav.js"></script>--%>
    <script src="/MethodJs/prdByFocusCate.js" type="text/javascript"></script>
    <script src="/MethodJs/favorite.js" type="text/javascript"></script>
    <script src="/MethodJs/share.js?v=20160111" type="text/javascript"></script>
    <%--  <script src="/MethodJs/favorite.js" type="text/javascript"></script>--%>
    <script src="/MethodJs/prdReview.js?v=20160201" type="text/javascript"></script>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

 <!--=== Breadcrumbs v4 ===-->
    <div class="breadcrumbs-v4 evaluate_back">
        <div class="container">
            <h1>
<strong>Your opinion </strong> matters to Tweebaa...</h1>
<p>Earn cash and points for evaluating new products!</p>
            <ul class="breadcrumb-v4-in">
                <li><a href="/index.aspx">Home</a></li>
                <li><a href="/Product/prdReviewAll.aspx">Evaluate</a></li>
                <li class="active">Welcome</li>
            </ul>
        </div><!--/end container-->
    </div> 
    <!--=== End Breadcrumbs v4 ===-->
 <!--=== Content Part ===-->
    <div class="content container">
        <div class="row">
            <div class="col-md-3 filter-by-block md-margin-bottom-60">
           
             <!--new drop down catoryies-->
                <div class="panel-group" id="accordion-v2">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h2 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion-v2" href="#collapseCategory">
                                    Categories
                                    <i class="fa fa-angle-down"></i>
                                </a>
                            </h2>
                        </div>
                  
                            <div id="collapseCategory" class="panel-collapse collapse in">
                        <div class="panel-body" id="category_tree">
                            
                        </div>
                    </div>
                        <!--new drop down catoryies end-->
                    </div>
                </div><!--/end panel group-->
                
                 <!--by focus-->
                  <div class="panel-group" id="accordion">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h2 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseByFocus">
                                    By Focus
                                    <i class="fa fa-angle-down"></i>
                                </a>
                            </h2>
                        </div>
                        <div id="collapseByFocus" class="panel-collapse collapse in">
                            <div class="panel-body">
                                <ul class="list-unstyled checkbox-list" id="ulByFocus">
                                    <li>
                                        <label class="checkbox">
                                          <input type="checkbox" name="option[]" value="1" onclick="DoSearch();"/><i></i>Tech
                                          <!--  <small><a href="#">(23)</a></small> -->
                                        </label>
                                        

                                    </li>
                                    <li>
                                        <label class="checkbox">
                                            <input type="checkbox" name="option[]" value="2" onclick="DoSearch();"/> <i></i>Aha! Products (Daily Problem Solvers)
                                           <!--
                                             Novel-twee
                                            <small><a href="#">(4)</a></small>-->
                                        </label>
                                    </li>
                                    <li>
                                        <label class="checkbox">
                                            <input type="checkbox" name="option[]" value="3" onclick="DoSearch();"/><i></i>Novel-twee (Unique products to evoke smiles)
                                            
                                            <!-- Twee-Tech
                                            <small><a href="#">(11)</a></small>-->
                                        </label>
                                    </li>
                                    <li>
                                        <label class="checkbox">
                                            <input type="checkbox" name="option[]" value="4" onclick="DoSearch();"/><i></i>Un-Breathable (Prices that take your breath away)
                                           <!--
                                            <i></i>
                                            Un-Breathable
                                            <small><a href="#">(3)</a></small> -->
                                        </label>
                                    </li>
                                 
                                   
                                </ul>        
                            </div>
                        </div>
                    </div>
                </div><!--/end panel group-->

                <!-- 
                <div class="panel-group" id="accordion-v5">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h2 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion-v5" href="#collapseFive">
                                    Color
                                    <i class="fa fa-angle-down"></i>
                                </a>
                            </h2>
                        </div>
                        <div id="collapseFive" class="panel-collapse collapse in">
                            <div class="panel-body">
                                <ul class="list-inline product-color-list">
                                    <li><a href="#"><img src="images/colors/01.jpg" alt=""></a></li>
                                    <li><a href="#"><img src="images/colors/02.jpg" alt=""></a></li>
                                    <li><a href="#"><img src="images/colors/03.jpg" alt=""></a></li>
                                    <li><a href="#"><img src="images/colors/04.jpg" alt=""></a></li>
                                    <li><a href="#"><img src="images/colors/05.jpg" alt=""></a></li>
                                    <li><a href="#"><img src="images/colors/06.jpg" alt=""></a></li>
                                    <li><a href="#"><img src="images/colors/07.jpg" alt=""></a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                -->
                <!--/end panel group-->

              <!--
                <button type="button" class="btn-u btn-brd btn-brd-hover btn-u-lg btn-u-sea-shop btn-block">Reset</button>
                -->
            </div>

            <div class="col-md-9">
                <div class="row margin-bottom-5">
                    <div class="col-sm-4 ">

                          <div class="input-group sort-list-search">
                    <input type="text" class="form-control" id="txtPrdname" placeholder="Search products...">
                    <span class="input-group-btn">
                        <button class="btn-u" type="submit" onclick="DoSearch()"><i class="fa fa-search"></i></button>
                    </span>
                </div>
                    </div>
                    <div class="col-sm-8 hidden-col">
                        <ul class="list-inline clear-both">
                            <li class="grid-list-icons">
                                <a href="#" onclick="show_by_list()"><i class="fa fa-th-list"></i></a>
                                <a href="#" onclick="show_by_grid()"><i class="fa fa-th"></i></a>
                            </li>
                            <li class="sort-list-btn">
                                <h3 style="margin-top:3px">Sort :</h3>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                       <span id="sort_by_text">By Ranking</span>  <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu" role="menu">
                                        <li><a href="#" sort-data="0" onclick="orderBy(this)">By Ranking</a> </li>
                                        <li><a href="#" sort-data="1" onclick="orderBy(this)">By Time</a> </li>
                                        <li><a href="#" sort-data="2" onclick="orderBy(this)">By Price</a></li>
                                        <li><a href="#" sort-data="3" onclick="orderBy(this)">By Name</a></li>
     
                                    </ul>
                                </div>
                            </li>
                            <li class="sort-list-btn">
                                <h3 style="margin-top:3px">Show :</h3>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                        <span id="show_by_text">21</span> <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu" role="menu">
                                        <li><a href="#"  onclick="ShowByPage(21)">21</a></li>
                                        <li><a href="#" onclick="ShowByPage(12)">12</a></li>
                                        <li><a href="#" onclick="ShowByPage(6)">6</a></li>
                                        <li><a href="#" onclick="ShowByPage(3)">3</a></li>
                                    </ul>
                                </div>
                            </li>
                        </ul>
                    </div>    
                </div><!--/end result category-->

                 <div class="result-select">				
			<span class="text-highlights" id="searchResult"></span>
		</div> 
                <div class="filter-results" id="prd_listings">

                </div>

                <div class="text-center">
                    <ul class="pagination pagination-v2" id="pageNav">
                        
                    </ul>                                                            
                </div><!--/end pagination-->
            </div>
        </div><!--/end row-->
    </div><!--/end container-->    


  <div id="dialogShareEvalute" class="modal fade share-modal-sm" tabindex="-1" role="dialog" aria-labelledby="shareLabel" aria-hidden="true">
                            <div class="modal-dialog modal-sm">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button aria-hidden="true" data-dismiss="modal" onclick="$('#dialogShareEvalute').modal('hide')" class="close" type="button">×</button>
                                        <h4 id="shareLabel" class="modal-title">Share & Earn</h4>
                                    </div>
                                    <div class="modal-body">
                                    <!-- Social Links -->
                   <ul class="share_icon">
                   <!--
                                <li><a href="https://www.facebook.com/tweebaa" target="_blank" data-original-title="Facebook" class="rounded-x social_facebook"></a></li>
                                <li><a href="https://twitter.com/tweebaa" target="_blank" data-original-title="Twitter" class="rounded-x social_twitter"></a></li>
                                <li><a href="https://www.google.com/+Tweebaa" target="_blank" data-original-title="Goole Plus" class="rounded-x social_googleplus"></a></li>
                                
                                <li><a href="https://www.pinterest.com/tweebaa/" target="_blank" data-original-title="Pinterest" class="rounded-x social_pintrest"></a></li>
                                    <li><a href="" target="_blank" data-original-title="Email" class="rounded-x social_email"></a></li>
                 -->
                                <!--#include file="../Include/ShareMethod.inc" -->
                            </ul>
                            <p style="padding-top:20px;">Invite your friends to support this product by taking a short survey.</p>
                    <!-- End Social Links -->
                                    </div>
                                    
                                </div>
                            </div>
                        </div>  
 

    <%-- 收藏弹出ydf--%>
    <div class="greybox">
        <div id="tck5" class="tck">
            <div class="pr">
                <a href="#" class="closeBtn" title="Close"></a>
                <h5>
                    <strong>Favorite</strong></h5>
                <div class="box" style="text-align: center;">
                    <div>
                        <label id="labfav" style="font-weight: bolder; font-size: 16px;">
                        </label>
                    </div>
                </div>
            </div>
        </div>
    </div>


             

 <script type="text/javascript">
     //表单提示
     $('input, textarea').placeholder();
     //筛选排序
     $(".sort-row").mouseenter(function (event) {
         $(this).find('ul').show();
     }).mouseleave(function (event) {
         $(this).find('ul').hide();
     });
     $(".select-sort").find("a").click(function () {
         $(this).parent("li").addClass('on').siblings('li').removeClass('on').parent("ul").hide();
         $(".select-sort > div > h3").attr('sort-data', $(this).attr('sort-data')).text($(this).text())
     })
     //筛选显示 
     // $(".select-show").find("a").click(function(event) {
     // 	$(".select-show").find("a").removeClass('on')
     // 	$(this).addClass('on')
     // });

     //显示 收藏和分享

//     $("#mainsrp-itemlist .pic-box").live('mouseenter', function (event) {
//         $(this).find(".floatDiv").stop().animate({ top: 0 }, 100)
//     }).live('mouseleave', function (event) {
//         $(this).find(".floatDiv").stop().animate({ top: "-110px" }, 100)
//     });

//     $("#mainsrp-itemlist .box").live('mouseenter', function (event) {
//         $(this).addClass('hover')
//     }).live('mouseleave', function (event) {
//         $(this).removeClass('hover')
//     });

//     //我有办法弹出框
//     $(".i-have-way").live('click', function (event) {
//         var objClick = $(this)
//         $("#tck3").parents(".greybox").show()
//         $("#tck3").animate({ top: "2%" }, 300)
//         return false;
//     });

     //分享弹出框ydf
     // $(".share").live('click', function (event) {
     //            var objClick = $(this)
     //            alert(objClick.html);
     //            $("#tck4").parents(".greybox").show()
     //            $("#tck4").animate({ top: "2%" }, 300)
     //            return false;
     //  });

     //Close弹出框
     $('.closeBtn,.iagree').click(function (event) {
         var obj2 = $(this).parents(".tck")
         obj2.animate({
             top: "-500px"
         },
				300, function () {
				    obj2.parents(".greybox").hide()

				});
         return false;
     });

     //snow加landingpage
     $(".closeBtn").click(function () {
         $(this).parents(".popbox").hide();
         return false;
     })

     //隐藏弹出 框
     function hidePopup() {
         $(".popbox").hide();
     }

     //Add by Long 2016/01/08
     var IsMobile = $("#MobileBrowserFlag").val();
     if (IsMobile == 1) {
         //Mobile Browser
         $("#a_category").addClass("Collapsed");
         //panel-collapse collapse
         //panel-collapse collapse in
         $("#collapseCategory").removeClass("in");
         $("#collapseStatus").removeClass("in");
         $("#collapseByFocus").removeClass("in");
     }
    </script>
    
</asp:Content>