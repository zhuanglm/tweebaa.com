﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="prdSingleShare.aspx.cs" Inherits="TweebaaWebApp2.Product.prdSingleShare" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Share Tweebaa products:  Have fun AND earn rewards
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
   <link rel="stylesheet" href="../css/buyall.css" />
    <link rel="stylesheet" href="../css/shareall.css" />
    <link href="../css/multiSelect.css" rel="stylesheet" type="text/css" />
     <link href="../css/submit.css" rel="stylesheet" type="text/css" />
    <script src="../MethodJs/multiSelect.js" type="text/javascript"></script>
  <%--  <script src="../js/jquery.min.js" type="text/javascript"></script>--%>
    <%--<script src="../js/qtab.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
   <%-- <link rel="stylesheet" href="../css/selectCss.css" />--%>
   <%-- <script src="../js/jquery.placeholder.js" type="text/javascript"></script>--%>
  <%--  <script type="text/javascript" src="../js/selectNav.js"></script>--%>
    <%--<script type="text/javascript" src="../js/public.js"></script>--%>
    <!--script src="../MethodJs/prdCate.js" type="text/javascript"></script-->
    <script src="../MethodJs/prdByFocusCate.js" type="text/javascript"></script>
    <script src="../MethodJs/favorite.js" type="text/javascript"></script>
    <script src="../MethodJs/SearchByCate.js" type="text/javascript"></script>
    <script src="../MethodJs/share.js" type="text/javascript"></script>
    <script src="../MethodJs/prdShare.js" type="text/javascript"></script>
    <!--script src="../MethodJs/shareToSocialNetwork.js" type="text/javascript"></script-->

         <%--分页--%>    
    <script src="../js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="../js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

<!--=== Breadcrumbs v4 ===-->
    <div class="breadcrumbs-v4 share_back">
        <div class="container">
          <h1> Share products with your friends...</h1>
          <p>Earn cash and points for sharing on your social networks!</p>
            <ul class="breadcrumb-v4-in">
                <li><a href="/index.aspx">Home</a></li>
                <li><a href="/Product/prdSingleShare.aspx">Share</a></li>
                <li class="active">Welcome</li>
            </ul>
        </div><!--/end container-->
    </div> 
    <!--=== End Breadcrumbs v4 ===-->
 <!--=== Content Part ===-->
    <div class="content container">
        <div class="row">
            <div class="col-md-3 filter-by-block md-margin-bottom-60">
                <h1 class="share1">Filter By</h1>
                
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
                                          <input type="checkbox" name="option[]" value="1" onclick="DoSearch();"/><i></i>Twee-Tech Products (Electronics & Gadgets)
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

          

               
            </div>

            <div class="col-md-9">
                <div class="row margin-bottom-5">
                    <div class="col-sm-4 ">

                          <div class="input-group sort-list-search">
                    <input type="text" class="form-control" id="txtPrdname" placeholder="Search products...">
                    <span class="input-group-btn">
                        <button class="btn-u btn-u-share" type="button" onclick="DoSearch()"><i class="fa fa-search"></i></button>
                    </span>
                </div>
                    </div>
                    <div class="col-sm-8">
                        <ul class="list-inline clear-both">
                            <li class="grid-list-icons ">
                                <a href="#" onclick="show_by_list()"><i class="fa fa-th-list"></i></a>
                                <a href="#" onclick="show_by_grid()"><i class="fa fa-th"></i></a>
                            </li>
                              <li class="sort-list-btn">
                                <h3 style="margin-top:3px">Sort :</h3>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                       <span id="spnSortBy">By Ranking</span>  <span class="caret"></span>
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
			        <span class="i-want-design" id="searchResult"></span>
		        </div> 
                <div class="filter-results" id="prd_listings">
                </div><!--/end filter resilts-->

                <div class="text-center">
                <div id="kkpager" style="padding-right:150px;"></div>
                    <!-- <ul class="pagination pagination-v4" id="pageNav">
                    
                        <li><a href="#"><i class="fa fa-angle-left"></i></a></li>
                        <li><a href="#">1</a></li>
                        <li class="active"><a href="#">2</a></li>
                        <li><a href="#">3</a></li>
                        <li><a href="#"><i class="fa fa-angle-right"></i></a></li>
                        
                    </ul>      -->                                                       
                </div><!--/end pagination-->
            </div>
        </div><!--/end row-->
    </div><!--/end container-->    
       
    <% // share popup box %>
    <div class="greybox" style="margin-top:60px">
        <div id="share-tck2" class="tck">
             <a href="#" class="closeBtn" title="Close"></a>
             <h2 class="t">
                <span>Share & Earn</span>
            </h2>
             <div class="box">
                <div class="sharebox clearfix my-dietu">
                    <span class="fl t ">Share to </span>
                    
                        <% // include all share method  %>        
                        <!--#include file="../Include/ShareMethod.inc" -->
                                    
                    <!--a href="/Home/Index.aspx" class="share-media-set">Link My Account</a-->
                </div>
                <div class="ps clearfix">
                    <span class="fr"><a href="#"></a></span><span class="fl">You will earn  <!--span id="sharePercent"></span-->commission when your friend makes a purchase from your shared link. </span>
                </div>
            </div>
            <%--<div class="box">
                <div class="sharebox clearfix my-dietu">
                    <span class="fl t ">Share to </span>
                    <div class="bdsharebuttonbox fl">
                        <a href="javascript:void(0)" target="_blank" id="share1" class="bds_weixin" title="Facebook"></a>
                        <a href="javascript:void(0)" target="_blank" id="share2" class="bds_tsina"  title="Twitter"></a>
                        <a href="javascript:void(0)" target="_blank" id="share3" class="bds_sqq"  title="google"></a>
                        <a href="javascript:void(0)" target="_blank" class="bds_renren" data-cmd="renren" title="Wechat"></a>
                        <a href="javascript:void(0)" target="_blank" class="bds_douban" data-cmd="douban" title="Pinterest"></a>
                        <a href="javascript:void(0)" target="_blank" class="bds_mail"  data-cmd="mail" title="email"></a>
                    </div>
                    <script>window._bd_share_config = { "common": { "bdSnsKey": {}, "bdText": "", "bdMini": "2", "bdMiniList": false, "bdPic": "", "bdStyle": "0", "bdSize": "32" }, "share": {} }; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];</script>
                    <a href="#" class="share-media-set">Share Binding setting</a>
                </div>
                <div class="ps clearfix">
                    <span class="fr"><a href="#"></a></span><span class="fl">You will earn a commission if anyone makes a purchase from your shared link!</span>
                </div>
            </div>--%>
        </div>
    </div>
    <script>
           //关闭弹出框
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
    </script>
 
</asp:Content>