﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Tweebot.Master" AutoEventWireup="true" CodeBehind="Vote.aspx.cs" Inherits="TweebaaWebApp2.Events.Tweebot.Vote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

    <!-- CSS Global Compulsory -->
    <link rel="stylesheet" href="/plugins/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="/css/shop.style.css">
    <link rel="stylesheet" href="/css/style.css">
     
    <!-- CSS Implementing Plugins -->
    <link rel="stylesheet" href="/plugins/line-icons/line-icons.css">
    <link rel="stylesheet" href="/plugins/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="/plugins/cube-portfolio/cubeportfolio/css/cubeportfolio.css">
    <link rel="stylesheet" href="/css/plugins/brand-buttons/brand-buttons.css">
    <link rel="stylesheet" href="/css/plugins/brand-buttons/brand-buttons-inversed.css">



    <!-- Style Switcher -->
    <link rel="stylesheet" href="/css/plugins/style-switcher.css">

    <!-- CSS Theme -->
    <link rel="stylesheet" href="/css/theme-colors/default.css" id="style_color">
      <link rel="stylesheet" href="/css/theme-skins/dark.css">

    <!-- CSS Customization -->
    <link rel="stylesheet" href="/css/custom.css">
    <style>
    .product-description .cbp-l-caption-desc
    {
        padding:2px;
        margin-top:5px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

    <!--=== Container Part ===-->
    <div class="content">
  
        <div class="fusion-portfolio wrapper-portfolio-fullwidth-text cbp-4-col cbp-caption-4-col">
          <div class="tag-box tag-box-v4">
                    <button type="button" class="close" data-dismiss="alert">×</button>
                    <h2 class="color-blue"><strong>Which of these videos should win $10,000 (and other cash and prizes)? You decide… </strong><br>
                  </h2>
                <p><strong>With each VOTE we’ll reward you with</strong><br>
                ✔ 5 Share points in your Tweebaa account (You could vote multiple videos per day but only allow vote once on any specific video per day. You will be award maximum 5 share point per day no matter how many video you voted)<br>
✔ chance to win a $500 shopping credit at www.tweebaa.com</p>
<em class="color-green">Come back every day (through March 31, 2016) to cast another vote!</em>
  
                </div>
                <div class="row">
            <div id="filters-container" class="cbp-l-filters-alignLeft col-md-9">
                <div data-filter="*" class="cbp-filter-item-active cbp-filter-item">All</div>
                <div data-filter=".buynow" class="cbp-filter-item">By Date</div>
                <div data-filter=".design" class="cbp-filter-item">By Vote</div>
                <div data-filter=".illustration" class="cbp-filter-item">By Submitter</div>
            </div>
            <div class="col-md-3">
              <form id="frmSearch" action="Vote.aspx?action=search" method="post">
              <div class="input-group" style="margin-top:10px;">

                    <input type="text" id="txtKeywords" name="txtKeywords" class="form-control" placeholder="Search words with regular expressions ...">
                    <span class="input-group-btn">
                        <button class="btn-u" onclick="frmSearch.submit()" type="button"><i class="fa fa-search"></i></button>
                    </span>

                </div>
                </form>
            </div>
</div>
            <div id="grid-container" class="cbp-l-grid-blog">
                <ul id="video_listings">
                <%=sHtml%>
                   
                 
                </ul>
            </div>
        </div><!--/End Wrapper Portfolio-->

        <div class="text-center">
           <ul class="pagination" id="pageNav">
          </ul>                                                   
        </div>
    </div>
    <!--=== End Container Part ===-->  
   
<!-- JS Global Compulsory -->
<script src="/plugins/jquery/jquery.min.js"></script>
<script src="/plugins/jquery/jquery-migrate.min.js"></script>
<script src="/plugins/bootstrap/js/bootstrap.min.js"></script>
<!-- JS Implementing Plugins -->
<script src="/plugins/back-to-top.js"></script>
<script type="text/javascript" src="/plugins/cube-portfolio/cubeportfolio/js/jquery.cubeportfolio.min.js"></script>
<!-- JS Customization -->
<script src="/js/custom.js"></script>
<!-- JS Page Level -->
<script src="/js/shop.app.js"></script>
<script type="text/javascript" src="/js/app.js"></script>
<script type="text/javascript" src="/js/plugins/cube-portfolio.js"></script>
<script type="text/javascript" src="/js/plugins/style-switcher.js"></script>

<script src="/js/plugins/owl-recent-works.js"></script> 

<script>
    jQuery(document).ready(function () {
       // App.init();
       // App.initParallaxBg();
        OwlRecentWorks.initOwlRecentWorksV1();
        //OwlCarousel.initOwlCarousel();
        //RevolutionSlider.initRSfullWidth();
        StyleSwitcher.initStyleSwitcher();
    });
</script>
<!--[if lt IE 9]>
    <script src="plugins/respond.js"></script>
    <script src="plugins/html5shiv.js"></script>
    <script src="js/plugins/placeholder-IE-fixes.js"></script>
<![endif]-->

       <script type="text/javascript">
           $(document).ready(function () {
               Load_video_total();
           });
   </script>   
</asp:Content>

