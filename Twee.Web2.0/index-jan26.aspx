<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="index-jan26.aspx.cs" Inherits="TweebaaWebApp2.index_jan26" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
 <script src="MethodJs/share.js" type="text/javascript"></script>
 <script type="text/javascript" src="/MethodJs/favorite.js" ></script>
 <script type="text/javascript" src="/js/CollageDesign.js?v=2016020111" ></script>
 <style>
    .title-price
    {
        height:22px;
        overflow:hidden;
    }
 </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
<!--<div class="search-block " style="height:295px; background-color:#e3e3e3;">
        <div class="container">
	  <div class="row">
        <div class="col-lg-8">
        <img src="images/head/homepagePNG-s.png" class="fl margin-top-20">
        </div>
         <div class="col-lg-3">
             

                <div class="input-group" style="margin:125px 0 0 30px;">
                 
                  
                       <button class="btn btn-lg rounded-4x btn-info" type="button" data-toggle="modal" data-target="#ModalIntroVideo">Show me how in 1 miniute</button>
                  
                </div>

              
            </div>
		</div>
        </div>    
    </div> !-->

    
              <!--=== Slider ===-->
    <div class="tp-banner-container">
        <div class="tp-banner">
        
            <ul>
		
                <!-- college SLIDE  -->
                <li class="revolution-mch-1" data-transition="fade" data-slotamount="5" data-masterspeed="1000" data-title="EDUCAITON">
            
                    <img src="images/head/learn.jpg"  alt="darkblurbg"  data-bgfit="cover" data-bgposition="center top" data-bgrepeat="no-repeat">

                    <div class="tp-caption revolution-ch15 sft start"
                        data-x="center"
                        data-hoffset="0"
                        data-y="100"
                        data-speed="1000"
                        data-start="622"
                        data-easing="Back.easeInOut"
                        data-endeasing="Power1.easeIn"                        
                        data-endspeed="300"><span style="text-align:center">We are much more than E Commerce</span> </div>

                  
                    <div class="tp-caption revolution-ch14 sft"
                        data-x="center"
                        data-hoffset="0"
                        data-y="200"
                        data-speed="1400"
                        data-start="1000"
                        data-easing="Power4.easeOut"
                        data-endspeed="300"
                        data-endeasing="Power1.easeIn"
                        data-captionhidden="off"
                        style="z-index: 6">
                        <span style=""> Earn extra $$ by sharing, evaluating, playing or shopping with us.</span>
                      
                    </div>

                 
                    <div class="tp-caption sft collage"
                        data-x="center"
                        data-hoffset="0"
                        data-y="300"
                        data-speed="1600"
                        data-start="2000"
                        data-easing="Power4.easeOut"
                        data-endspeed="300"
                        data-endeasing="Power1.easeIn"
                        data-captionhidden="off"
                        style="z-index: 6">
                      <!-- <a href="/College/College.aspx"> <img src="images/head/learn-text.png"></a>  -->
			    <button class="btn btn-lg rounded-4x btn-info" type="button" data-toggle="modal" data-target="#ModalIntroVideo">Show me how in 1 miniute</button>
        
                    </div>
      

                </li>
                <!-- END SLIDE -->
              

                   <!-- SHARE & EARN MONEY SLIDE-->
                <li class="revolution-mch-1" data-transition="fade" data-slotamount="5" data-masterspeed="1000" data-title="SHARE & EARN MONEY">
                   
                    
                    <img src="images/head/share-bg.jpg"  alt="darkblurbg"  data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat">
                     <div class="tp-caption sft start nodsp"
                        data-x="left"
                        data-hoffset="-50"
                        data-y="0"
                        data-speed="1500"
                        data-start="100"
                        data-easing="Back.easeInOut"
                        data-endeasing="Power1.easeIn"                        
                        data-endspeed="300">
                    <img src="images/head/share.png">
                    </div>


                    <div class="tp-caption revolution-ch3 sft start"
                        data-x="right"
                        data-hoffset="35"
                        data-y="100"
                        data-speed="1500"
                        data-start="500"
                        data-easing="Back.easeInOut"
                        data-endeasing="Power1.easeIn"                        
                        data-endspeed="300">
                       <strong><span style="color: #faa54e">SHARE & EARN</span></strong>
                    </div>

			    <div class="tp-caption revolution-ch6 sft start"
                        data-x="right"
                        data-hoffset="35"
                        data-y="200"
                        data-speed="1500"
                        data-start="1000"
                        data-easing="Back.easeInOut"
                        data-endeasing="Power1.easeIn"                        
                        data-endspeed="300">
                      Share our products with you friends and <br /> gain unlimited earning potential 
                    </div>
              <!--      <div class="tp-caption revolution-ch7 sft"
                        data-x="right"
                        data-hoffset="35"
                        data-y="225"
                        data-speed="1500"
                        data-start="1500"
                        data-easing="Power4.easeOut"
                        data-endspeed="300"
                        data-endeasing="Power1.easeIn"
                        data-captionhidden="off"
                        style="z-index:6"> WHEN THEY BUY</div> 
                        
                <div class="tp-caption revolution-ch9 sft"
                        data-x="right"
                        data-hoffset="35"
                        data-y="290"
                        data-speed="1300"
                        data-start="2000"
                        data-easing="Power4.easeOut"
                        data-endspeed="310"
                        data-endeasing="Power1.easeIn"
                        data-captionhidden="off"
                        style="z-index:6"> Post, Tweet or email them products they’ll love</div>-->
                  
                    <div class="tp-caption sharebtn sft"
                        data-x="right"
                        data-hoffset="35"
                        data-y="320"
                        data-speed="1600"
                        data-start="2500"
                        data-easing="Power4.easeOut"
                        data-endspeed="300"
                        data-endeasing="Power1.easeIn"
                        data-captionhidden="off"
                        style="z-index: 6">
                      
                        <button onclick="window.location.href='/Product/prdSingleShare.aspx'" class="btn-u rounded btn-u-orange btn-u-lg shbtn" type="button">Share Now</button>
                    </div>
                </li>
                <!-- END SLIDE -->
             <!--tweebot SLIDE -->
                <li class="revolution-mch-1" data-transition="fade" data-slotamount="5" data-masterspeed="1000" data-title="TWEEBOT">
               
                    <img src="images/head/tweebot.jpg"  alt="everybodyearns"  data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat">
                <div class="tp-caption sft start nodsp"
                        data-x="left"
                        data-hoffset="-250"
                        data-y="0"
                        data-speed="1500"
                        data-start="100"
                        data-easing="Back.easeInOut"
                        data-endeasing="Power1.easeIn"                        
                        data-endspeed="300">
                     <img src="images/head/tweebot6.jpg">
                    </div>
                    <div class="tp-caption revolution-ch6 sft start tb2"
                        data-x="right"
                        data-hoffset="40"
                        data-y="100"
                        data-speed="1500"
                        data-start="500"
                        data-easing="Back.easeInOut"
                        data-endeasing="Power1.easeIn"                        
                        data-endspeed="300">
                     <strong><span style="color:#fff;">AT TWEEBAA YOU’LL FIND</span></strong>
                    </div>
                    
                         <div class="tp-caption revolution-ch8 sft start"
                        data-x="right"
                        data-hoffset="0"
                        data-y="110"
                        data-speed="1500"
                        data-start="800"
                        data-easing="Back.easeInOut"
                        data-endeasing="Power1.easeIn"                        
                        data-endspeed="300">
                     <strong><span style="color:#ec0000;">UNIQUE PRODUCTS LIKE</span></strong>
                     <br><img src="images/head/tbot-logo.png">
                    </div>

                   
                    <div class="tp-caption revolution-ch10 sft"
                        data-x="right"
                        data-hoffset="40"
                        data-y="290"
                        data-speed="1400"
                        data-start="2000"
                        data-easing="Power4.easeOut"
                        data-endspeed="300"
                        data-endeasing="Power1.easeIn"
                        data-captionhidden="off"
                        style="z-index: 6">A wireless, Bluetooth communicator that listens to you.
                    </div>

                  
                    <div class="tp-caption sft "
                        data-x="right"
                        data-hoffset="40"
                        data-y="330"
                        data-speed="1600"
                        data-start="1800"
                        data-easing="Power4.easeOut"
                        data-endspeed="300"
                        data-endeasing="Power1.easeIn"
                        data-captionhidden="off"
                        style="z-index: 6">
                        <a href="/Product/saleBuy.aspx?id=670bdf26-a935-4643-ac0e-ba24c2249107" class="btn-u btn-block btn-u-red btn-u-lg rounded buynow">BUY NOW</a>
                    
                    </div>
                </li>
                <!-- END SLIDE -->

                <!-- game SLIDE-->
                <li class="revolution-mch-1" data-transition="fade" data-slotamount="5" data-masterspeed="1000" data-title="TWEEBAA APP">
                
                    <img src="images/head/share-bg2.jpg"  alt="darkblurbg"  data-bgfit="cover" data-bgposition="center top" data-bgrepeat="no-repeat">
         <div class="tp-caption sft start nodsp"
                        data-x="right"
                        data-hoffset="280"
                        data-y="-40"
                        data-speed="1500"
                        data-start="100"
                        data-easing="Back.easeInOut"
                        data-endeasing="Power1.easeIn"                        
                        data-endspeed="300">
                 <img src="images/head/game2.jpg">
                    </div>
                    <div class="tp-caption revolution-ch5 sft start app"
                        data-x="left"
                        data-hoffset="0"
                        data-y="100"
                        data-speed="1500"
                        data-start="500"
                        data-easing="Back.easeInOut"
                        data-endeasing="Power1.easeIn"                        
                        data-endspeed="300">
                       <strong >PLAY & EARN</strong>
                    </div>

                    <div class="tp-caption revolution-ch4 sft"
                        data-x="left"
                        data-hoffset="0"
                        data-y="200"
                        data-speed="1400"
                        data-start="2000"
                        data-easing="Power4.easeOut"
                        data-endspeed="300"
                        data-endeasing="Power1.easeIn"
                        data-captionhidden="off"
                        style="z-index: 6">
                       DOWNLOAD THE TWEEBAA APP <br />ENJOY ENDLESS FUN & REWARDS
                    </div>

                    <div class="tp-caption gameicon sft"
                        data-x="left"
                        data-hoffset="20"
                        data-y="260"
                        data-speed="1600"
                        data-start="2800"
                        data-easing="Power4.easeOut"
                        data-endspeed="300"
                        data-endeasing="Power1.easeIn"
                        data-captionhidden="off"
                        style="z-index: 6">
                        <a href="https://play.google.com/store/apps/details?id=com.Tweebaa.App.CollageApp" style="margin-right:10px;"><img src="images/head/android.png"></a>
                       <a style="margin-right:10px;" href="https://itunes.apple.com/ca/app/tweebaa/id1027840811?mt=8"> <img src="images/head/AppStore.png"></a>
                      
             
        
                    </div>
                </li>
                <!-- END SLIDE -->  
               
               
           <!-- SLIDE DISCOVER SHOP-->
                <li class="revolution-mch-1" data-transition="fade" data-slotamount="5" data-masterspeed="1000" data-title="DISCOVER SHOP">
                 
                    <img src="images/head/share-bg2.jpg"  alt="darkblurbg"  data-bgfit="cover" data-bgposition="right top" data-bgrepeat="no-repeat">
                    <div class="tp-caption revolution-ch5 sft start nodsp"
                        data-x="right"
                        data-hoffset="500"
                        data-y="0"
                        data-speed="1500"
                        data-start="100"
                        data-easing="Back.easeInOut"
                        data-endeasing="Power1.easeIn"                        
                        data-endspeed="300">
                      <img src="images/head/shop2.jpg">
                    </div>

                    <div class="tp-caption revolution-ch5 sft start"
                        data-x="left"
                        data-hoffset="0"
                        data-y="120"
                        data-speed="1500"
                        data-start="500"
                        data-easing="Back.easeInOut"
                        data-endeasing="Power1.easeIn"                        
                        data-endspeed="300">
                       <strong><span style="color:#f59aa9"> SHOPPING & EARN</span></strong>
                    </div>

                    <div class="tp-caption revolution-ch4 sft"
                        data-x="left"
                        data-hoffset="0"
                        data-y="200"
                        data-speed="1400"
                        data-start="2000"
                        data-easing="Power4.easeOut"
                        data-endspeed="300"
                        data-endeasing="Power1.easeIn"
                        data-captionhidden="off"
                        style="z-index: 6"> EARN SHOPPING REWARDS ON ALL YOUR PURCHASE
                      
                    </div>

                 
                    <div class="tp-caption shopbtn sft"
                        data-x="left"
                        data-hoffset="0"
                        data-y="260"
                        data-speed="1600"
                        data-start="2800"
                        data-easing="Power4.easeOut"
                        data-endspeed="300"
                        data-endeasing="Power1.easeIn"
                        data-captionhidden="off"
                        style="z-index: 6">
                        <a href="/Product/prdSaleAll.aspx" class="btn-u btn-u-shop btn-u-lg rounded">Shop Now</a>
                    </div>
                </li>
                <!-- END SLIDE -->

               
            </ul>
            <div class="tp-bannertimer tp-bottom"></div>            
        </div>
    </div>
    <!--=== End Slider ===-->

      <div class="container content ">


       <!-- Pricing Table v6-plus-->
              <div class="row">
            <div class="col-md-12 col-width-full">
            <div class="heading">
                        <!--  <h2 class="fl">Shop and Earn Rewards</h2> -->
				<button class="btn-u btn-u-xs rounded-4x btn-u-default  mgtop15 fr margin-bottom-15" onclick="window.location.href='/Product/ShopIndex.aspx'" type="button">View All <i class="fa fa-chevron-circle-right"></i></button>
                       
                    </div>
            <h3><strong></strong> </h3>
    </div></div>
        <div class="row margin-bottom-20">
    <div class="col-md-3 col-width-full">
                   <a href="/Product/ShopIndex.aspx" style="text-decoration:none;">
                <div class="pricing-table-v6 v6-plus">
                    <div class="service-block service-block-red">
                        <i class="icon-custom icon-color-light rounded-x fa fa-shopping-cart"></i>
                        <h2 class="heading-md">SHOP</h2>
                        <p>Shop at Tweebaa. </p><p>
Discover cool products; <br>earn Shopping Rewards.</p>
                                  
                    </div>
                </div>
                </a>
               <button class="btn-u btn-brd rounded-4x btn-u-red btn-u-lg btn-block margin-bottom-40" type="button" onclick="window.location.href='/Product/ShopIndex.aspx'">Shop Now</button> 
               
            </div>
            
            <div class="col-md-9">
            
               <div class="row illustration-v2">
                       <%=strShopHtml%>
                    </div>
            </div>
            
   
        </div>
        <!-- End Pricing Table v6-plus -->
   
       <!-- Pricing Table v6-plus-->
   <div class="row">
            <div class="col-md-12 col-width-full">
            <div class="heading">
                       <!--   <h2 class="fl">Build Your Collage and Share</h2>-->
			      <button class="btn-u btn-u-xs rounded-4x btn-u-default  mgtop15 fr margin-bottom-15" onclick="window.location.href='/Product/CollageShare.aspx'"  type="button">View All <i class="fa fa-chevron-circle-right"></i></button>
                       
                    </div>
            <h3><strong></strong> </h3>
    </div></div>
        <div class="row margin-bottom-20">
    <div class="col-md-3 col-width-full">
                <a href="/Product/CollageShare.aspx" style="text-decoration:none;">
                <div class="pricing-table-v6 v6-plus">
                    <div class="service-block service-block-orange">
                       <i class="icon-custom icon-color-light rounded-x fa fa-share-alt"></i>
                        <h2 class="heading-md">SHARE</h2>
                      <p>Share items with friends.</p><p>
They’ll love your thoughtfulness, <br>
and you’ll earn CASH.</p>
                     
                    </div>
                </div>
                </a>
                  <button class="btn-u btn-brd rounded-4x btn-u-yellow btn-u-lg btn-block margin-bottom-40" type="button" onclick="window.location.href='/Product/CollageShare.aspx'" >Build Your Collage Now</button> 
            </div>
            
            <div class="col-md-9">
            
               <div class="row illustration-v2">
                       <%=strCollageHtml%>
                    </div>
            </div>
            
   
        </div>
        <!-- End Pricing Table v6-plus -->
        
        
        
             <!-- Pricing Table v6-plus-->
   <div class="row">
            <div class="col-md-12 col-width-full">
            <div class="heading">
                        <!--<h2 class="fl">EVALUATE A PRODUCT AND EARN</h2>--> 
				<button class="btn-u btn-u-xs rounded-4x btn-u-default  mgtop15 fr margin-bottom-15" onclick="window.location.href='/Product/prdReviewAll.aspx'" type="button">View All <i class="fa fa-chevron-circle-right"></i></button>
                       
                    </div>
            <h3><strong></strong> </h3>
    </div></div>
    <div class="row">
  <div class="col-md-3 col-width-full">
                <a href="/Product/prdReviewAll.aspx" style="text-decoration:none;">
                <div class="pricing-table-v6 v6-plus">
                    <div class="service-block service-block-sea">
                        <i class="icon-custom icon-color-light rounded-x fa fa-check-square-o"></i>
                        <h2 class="heading-md">EVALUATE</h2>
                     <p>Evaluate community products.</p><p>
It’s fun, and you can earn <br>cash and free gifts.</p>
                                
                    </div>
                </div>
                </a>
                  <button class="btn-u btn-brd rounded-4x btn-u-sea btn-u-lg btn-block margin-bottom-40" type="button" onclick="window.location.href='/Product/prdReviewAll.aspx'">Evaluate Now</button> 
            </div>
        <!-- End Pricing Table v6-plus -->
        <div class="col-md-9">
      <div class="row illustration-v2 margin-bottom-30">
                        <%=strEvaluteHtml %>

                    </div>   
                    </div></div>
         
           
             <!-- Pricing Table v6-plus-->
<div class="row">
            <div class="col-md-12 col-width-full">
            <div class="heading">
                       <!-- <h2 class="fl">SUGGEST A PRODUCT AND EARN</h2>-->
                       
                    </div>
            <h3><strong></strong> </h3>
    </div></div>
    <div class="row margin-bottom-40">
  <div class="col-md-3 col-width-full">
                <a href="/Product/Product_Submit.aspx" style="text-decoration:none;">
                <div class="pricing-table-v6 v6-plus">
                    <div class="service-block service-block-blue">
                   <i class="icon-custom icon-color-light rounded-x fa fa-pencil-square-o"></i>
                   <h2 class="heading-md">SUGGEST</h2>
                     <p>Tell us about cool products.</p><p>
If they reach our Tweebaa Shop, <br>
you’ll be rewarded </p>
                    </div>
                </div>
                </a>
                  <button class="btn-u btn-brd rounded-4x btn-u-blue btn-u-lg btn-block margin-bottom-40" type="button" onclick="window.location.href='/Product/Product_Submit.aspx'">Suggest Now</button> 
            </div>
        <!-- End Pricing Table v6-plus -->
        <div class="col-md-9">
      <div class="row illustration-v2 margin-bottom-30">
                          <!-- Youtube Video -->
                    <div class="col-md-6 ">
                        <div class="responsive-video margin-bottom-15">
                            <iframe width="100%" src="https://www.youtube.com/embed/-wgZN_l_R1A?rel=0" frameborder="0" allowfullscreen></iframe>
                        </div>
                        <span class="badge badge-blue rounded-2x margin-bottom-20">Chance to win whole life commission</span> 
                    </div>
                      <!-- Youtube Video -->
                    <div class="col-md-6">
                        <div class="responsive-video margin-bottom-15">
                            <iframe width="100%" src="https://www.youtube.com/embed/EjU_6GqCllA?rel=0" frameborder="0" allowfullscreen></iframe>
                        </div>
                         <span class="badge badge-blue rounded-2x margin-bottom-20">Chance to win whole life commission</span> 
                    </div>
                    </div>   
                    </div></div>      
                    
             
             <!-- Pricing Table v6-plus-->
<div class="row">
            <div class="col-md-12 col-width-full">
            <div class="heading">
                <!--        <h2 class="fl">Play and Earn</h2>-->
                       
                    </div>
            <h3><strong></strong> </h3>
    </div></div>
    <div class="row margin-bottom-40">
  <div class="col-md-3 col-width-full">
                <a href="/Games/SlotMachine/index.aspx" style="text-decoration:none;">
                <div class="pricing-table-v6 v6-plus">
                    <div class="service-block service-block-brown">
                   <i class="icon-custom icon-color-light rounded-x icon-game-controller"></i>
                   <h2 class="heading-md">PLAY & 
REDEEM</h2>
                     <p>Have a ball playing fun games 
</p><p>
and earning points with every win! </p>
                    </div>
                </div>
                </a>
            </div>
        <!-- End Pricing Table v6-plus -->
        <div class="col-md-9">
      <div class="row illustration-v2 margin-bottom-30">
                          <!-- Youtube Video -->
                    <div class="col-md-6">
                       <a href="/Games/SlotMachine/index.aspx" target="_blank"><img src="images/head/slot.jpg" width="100%" alt="Slot Machine" /></a>
                        <span class="badge badge-blue rounded-2x mgtop15 margin-bottom-20">Chance to win free products</span> 
                    </div>
                      <!-- Youtube Video -->
                    <div class="col-md-6">
                       <a data-toggle="modal" data-target="#divAppVideo"><img src="images/head/app.jpg" width="100%" alt="Tweebaa App" /></a>
                     <a href="/DownloadApp.aspx" target="_blank">  <span class="badge badge-blue rounded-2x mgtop15 margin-bottom-20">Play and earn points</span> </a>
                    </div>
                    </div>   
                    </div></div>      
                        
      
      </div>


      <div class="modal fade" style="top:50px;" id="ModalIntroVideo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
            <div class="modal-dialog" style="width:50%;">
              <div class="modal-content">
              <!--       <div class="modal-header">
                        <button aria-hidden="true" data-dismiss="modal" class="close" type="button" onclick="PauseVideo();">×</button>
                        <h4 id="myModalLabel" class="modal-title">Watch Video</h4>
                    </div>-->
                    <div class="modal-body modalframe" >
                             
<div class="responsive-video" id="divResponsiveVideo">
<iframe width="420" height="315" src="https://www.youtube.com/embed/51EO2szmdaQ?rel=0" frameborder="0" allowfullscreen></iframe>
<!--
    <iframe id="frmVideo" src="/Product/HomeVideo.aspx" width="840" height="400" frameborder="0" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>
    -->
</div>
                                     
                    </div>
                                 
                    </div>
            </div>
</div>


      <div class="modal fade" style="top:50px;" id="divAppVideo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
            <div class="modal-dialog" style="width:50%;">
              <div class="modal-content">
              <!--       <div class="modal-header">
                        <button aria-hidden="true" data-dismiss="modal" class="close" type="button" onclick="PauseVideo();">×</button>
                        <h4 id="myModalLabel" class="modal-title">Watch Video</h4>
                    </div>-->
                    <div class="modal-body modalframe" >
                             
<div class="responsive-video" id="divAppVideo1">
<iframe width="420" height="315" src="https://www.youtube.com/embed/3syy3GRVx4I" frameborder="0" allowfullscreen></iframe>
<!--
    <iframe id="frmVideo" src="/Product/HomeVideo.aspx" width="840" height="400" frameborder="0" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>
    -->
</div>
                                     
                    </div>
                                 
                    </div>
            </div>
</div>
</asp:Content>
