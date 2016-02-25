﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Tweebot.Master" AutoEventWireup="true" CodeBehind="vote_details.aspx.cs" Inherits="TweebaaWebApp2.Events.Tweebot.vote_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
<%=gs_video_title%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

    <link rel="stylesheet" href="/plugins/owl-carousel/owl-carousel/owl.carousel.css"> 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

      <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
         
            <ul class="pull-right breadcrumb">
                <li><a href="../index.aspx">Home</a></li>
                <li><a href="#">Vote</a></li>
                <li class="active">Video</li>
            </ul>
        </div>
    </div>
    <!--=== End Breadcrumbs ===-->  
       <!--=== Content Part ===-->
    <div class="container content"> 	
                  <input type="hidden" id="UserGuid" value="<%=_userid %>" />   
                  <input type="hidden" id="txtVoteID" value="<%=video_id %>" />   
    	<div class="row portfolio-item margin-bottom-20"> 
            <!-- Carousel -->
            <div class="col-md-8">
                    <div class="responsive-video margin-bottom-30">
                    <!--
                    <iframe src="http://player.vimeo.com/video/47911018" width="530" height="300" frameborder="0" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>
                    -->


    <video id="Tweebit_Video" poster="<%=gs_img_url %>" width="730" height="350" controls>
    <source src="/upload/PlayVideo/<%=gs_video_url %>" type="video/mp4">
  Sorry, your browser doesn't support embedded videos, 
  but don't worry, you can <a href="videofile.ogg">download it</a>
  and watch it with your favorite video player!
</video>


                </div>
            </div>
            <!-- End Carousel -->

            <!-- Content Info -->        
            <div class="col-md-4">
<% if (gs_IsShowVote)
   { %>

         <div class="tag-box tag-box-v6">
       
                <h2>Video Details</h2>
              
               <p>Submiter: <%=gs_submiter%><br>
               Submit time: <%=gs_lastupdate%> <br> 
               <hr>
               
               <%=gs_video_description%>
               
               </p>
                      
              
            </div>
    

           

                <textarea class="form-control" rows="7" id="txtComment"></textarea>
                <br>
             
                <button id="linkVote" onclick="submit_vote(<%=video_id %>); " class="rounded btn-u btn-u-lg btn-block btn-u-blue tooltips" data-toggle="tooltip" data-placement="left" title="" data-original-title="You’ll earn 5 Tweebaa “Share” Points per day by vote – PLUS – a chance to win a $500 shopping spree!">Place Your Vote</button>
                <!-- <p class="margin-top-20">Voting runs through Friday, March 18, 2016.</p> -->
                <hr>
                     <div>
                       <p>Tell your friends to vote; they’ll earn @ Tweebaa too!<br></p>
                       <button class="btn rounded btn-twitter" > <i class="fa fa-twitter"></i> </button>
                       <button class="btn rounded btn-facebook" ><i class="fa fa-facebook"></i> </button>
                       <!--
                       <button class="btn rounded btn-youtube" ><i class="fa fa fa-youtube-play"></i> Youtube</button>
                       -->
                       <button class="btn rounded btn-pinterest" ><i class="fa fa-pinterest"></i></button>
                         <button class="btn rounded btn-googleplus"><i class="fa fa fa-google-plus"></i></button>
                       <button class="btn rounded btn-macstore"><i class="fa fa fa-envelope"></i></button>
                                           </div>

<%}
   else
   {
        %>

        <!--
         <p>
                Write Your comments here before vote

                </p>
                <textarea class="form-control" rows="7" id="Textarea1"></textarea>
                <br>
             
                <a href="javascript:void(0)" onclick="submit_vote(); class="rounded btn-u btn-u-lg btn-block btn-u-blue">SUBMIT</a>
-->

<p>Please <a href="/User/login.aspx?op=tweebot_vote&id=<%=video_id %>">Login </a> to Vote!</p>
<!--
                 <p>
  Voting runs Monday, January 4, 2016 through Thursday, January 31, 2016

                </p>  
                -->  
                     <div>
                       <button class="btn rounded btn-twitter" > <i class="fa fa-twitter"></i>  </button>
                       <button class="btn rounded btn-facebook" ><i class="fa fa-facebook"></i> </button>
                       <!--
                       <button class="btn rounded btn-youtube" ><i class="fa fa fa-youtube-play"></i> Youtube</button>
                       -->
                       <button class="btn rounded btn-pinterest" ><i class="fa fa-pinterest"></i> </button>
                     </div>
<%} %>
            </div>
            <!-- End Content Info -->        
        </div><!--/row-->

      

        <div class="margin-bottom-20 clearfix"></div>    

        <!-- Recent Works -->
        <div class="owl-carousel-v1 owl-work-v1 margin-bottom-40">
            <div class="headline"><h2 class="pull-left">Hotest Video</h2>
                <div class="owl-navigation">
                    <div class="customNavigation">
                        <a class="owl-btn prev-v2"><i class="fa fa-angle-left"></i></a>
                        <a class="owl-btn next-v2"><i class="fa fa-angle-right"></i></a>
                    </div>
                </div>
            </div>

            <div class="owl-recent-works-v1" id="divHotestVideo">
          

             <!--
                <div class="item">
                    <a href="#">
                        <em class="overflow-hidden">
                            <img class="img-responsive" src="/images/main/2.jpg" alt="">
                        </em>    
                        <span>
                            <strong>Award Winning Agency</strong>
                            <i>Responsive Bootstrap Template</i>
                        </span>
                    </a>    
                </div>
                <div class="item">
                    <a href="#">
                        <em class="overflow-hidden">
                            <img class="img-responsive" src="/images/main/3.jpg" alt="">
                        </em>    
                        <span>
                            <strong>Wolf Moon Officia</strong>
                            <i>Pariatur prehe cliche reprehrit</i>
                        </span>
                    </a>    
                </div>
                <div class="item">
                    <a href="#">
                        <em class="overflow-hidden">
                            <img class="img-responsive" src="/images/main/4.jpg" alt="">
                        </em>    
                        <span>
                            <strong>Food Truck Quinoa Nesciunt</strong>
                            <i>Craft labore wes anderson cred</i>
                        </span>
                    </a>    
                </div>
                <div class="item">
                    <a href="#">
                        <em class="overflow-hidden">
                            <img class="img-responsive" src="/images/main/5.jpg" alt="">
                        </em>    
                        <span>
                            <strong>Happy New Year</strong>
                            <i>Anim pariatur cliche reprehenderit</i>
                        </span>
                    </a>    
                </div>
                <div class="item">
                    <a href="#">
                        <em class="overflow-hidden">
                            <img class="img-responsive" src="/images/main/1.jpg" alt="">
                        </em>    
                        <span>
                            <strong>Happy New Year</strong>
                            <i>Anim pariatur cliche reprehenderit</i>
                        </span>
                    </a>    
                </div>
                <div class="item">
                    <a href="#">
                        <em class="overflow-hidden">
                            <img class="img-responsive" src="/images/main/2.jpg" alt="">
                        </em>    
                        <span>
                            <strong>Award Winning Agency</strong>
                            <i>Responsive Bootstrap Template</i>
                        </span>
                    </a>    
                </div>
                <div class="item">
                    <a href="#">
                        <em class="overflow-hidden">
                            <img class="img-responsive" src="/images/main/3.jpg" alt="">
                        </em>    
                        <span>
                            <strong>Wolf Moon Officia</strong>
                            <i>Pariatur prehe cliche reprehrit</i>
                        </span>
                    </a>    
                </div>
                <div class="item">
                    <a href="#">
                        <em class="overflow-hidden">
                            <img class="img-responsive" src="/images/main/4.jpg" alt="">
                        </em>    
                        <span>
                            <strong>Food Truck Quinoa Nesciunt</strong>
                            <i>Craft labore wes anderson cred</i>
                        </span>
                    </a>    
                </div>
                <div class="item">
                    <a href="#">
                        <em class="overflow-hidden">
                            <img class="img-responsive" src="/images/main/5.jpg" alt="">
                        </em>    
                        <span>
                            <strong>Happy New Year</strong>
                            <i>Anim pariatur cliche reprehenderit</i>
                        </span>
                    </a>    
                </div>
                -->
            </div>
        </div>    
        <!-- End Recent Works -->
    </div><!--/container-->	 	
    <!--=== End Content Part ===-->

<script type="text/javascript">
    
    // A $( document ).ready() block.
    $(document).ready(function () {
        Load_Hotest_Video();


        $('#Tweebit_Video').bind('ended', function () { //should trigger once on any play and ended event
            //alert("Play End");
            $("#linkVote").removeAttr("disabled");
            //$('.playbtn').addClass('pausebtn'); //might also be $('#playbtn') ???
            //$('#linkVote').unbind('click', false);
            $('#linkVote').removeClass("btn-u-grey");
            $('#linkVote').addClass("btn-u-default");
        });

        $("#linkVote").html("Please Watch Video and Vote");

        $('#linkVote').attr('disabled', "disabled");
        $('#linkVote').removeClass("btn-u-default");
        $('#linkVote').addClass("btn-u-grey");
        var prdid = $("#txtVoteID").val();
        var prdname = "<%=gs_video_title%>";
        var prdimg = "https://tweebaa.com/<%=gs_img_url %>";
        var page = "https://tweebaa.com/Events/Tweebot/vote_details.aspx?";
        var desc = "<%=gs_video_description%>";
        // btnShareTwitter
        //Twitter

        $(".btn-twitter").unbind("click");
        $(".btn-twitter").click(function () {
            //(type, prdid, prdname, prdimg, page, desc) 
            shareUrl = CreateShareUrl("twitter", prdid, prdname, prdimg, page, desc);
            // Log4Debug(shareUrl);
            //window.location.href = shareUrl;
            window.open(shareUrl, '_blank');
        });
        $(".btn-facebook").unbind("click");
        $(".btn-facebook").click(function () {
            //(type, prdid, prdname, prdimg, page, desc) 
            shareUrl = CreateShareUrl("facebook", prdid, prdname, prdimg, page, desc);
            // Log4Debug(shareUrl);
            //window.location.href = shareUrl;
            window.open(shareUrl, '_blank');
        });
        $(".btn-pinterest").unbind("click");
        $(".btn-pinterest").click(function () {
            //(type, prdid, prdname, prdimg, page, desc) 
            shareUrl = CreateShareUrl("pinterest", prdid, prdname, prdimg, page, desc);
            // Log4Debug(shareUrl);
            //window.location.href = shareUrl;
            window.open(shareUrl, '_blank');
        });
        //
    });
</script>
<script type="text/javascript" src="/js/plugins/owl-recent-works.js"></script>
<script>

    jQuery(document).ready(function () {
    /*
        App.init();
        StyleSwitcher.initStyleSwitcher();
        OwlRecentWorks.initOwlRecentWorksV1();*/
    });


</script>
</asp:Content>