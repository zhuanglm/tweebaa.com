﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="HomeProfile.aspx.cs" Inherits="TweebaaWebApp2.Home.HomeProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
 
    

    <!-- CSS Global Compulsory -->
    <link rel="stylesheet" href="../plugins/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="../css/shop.style.css">
    <link rel="stylesheet" href="../css/style.css">
     
    <!-- CSS Implementing Plugins -->
    <link rel="stylesheet" href="../plugins/line-icons/line-icons.css">
    <link rel="stylesheet" href="../plugins/font-awesome/css/font-awesome.min.css">
     <link rel="stylesheet" href="../plugins/sky-forms/version-2.0.1/css/custom-sky-forms.css">
    <link rel="stylesheet" href="../plugins/scrollbar/src/perfect-scrollbar.css">

   
   
    <!-- CSS Page Style -->
    <link rel="stylesheet" href="../css/pages/profile.css">

    <!-- Style Switcher -->
    <link rel="stylesheet" href="../css/plugins/style-switcher.css">

    <!-- CSS Theme -->
    <link rel="stylesheet" href="../css/theme-colors/default.css" id="style_color">

    <!-- CSS Customization -->
    <link rel="stylesheet" href="../css/custom.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
 <div class="col-md-9">
                <!--Profile Body-->
                <div class="profile-body">
          
                    <!--Service Block v3-->
                    <div class="row margin-bottom-30">
                        <div class="col-sm-4 sm-margin-bottom-20">
                            <div class="service-block-v3 service-block-gold2">
                                <i class="icon-trophy"></i>
                                <span class="service-heading">Available Tweebucks</span>
                                <span class="counter"><asp:Label ID="labSumCash" runat="server"></asp:Label></span>
                                <div class="row ">
                                    <div class="col-xs-12 service-in">
                                        <small>Redemption Value $<asp:Label ID="labSumCash2" runat="server"></asp:Label> </small> </div>
                                   
                                </div>
                                        
                            </div>
                        </div>
                        
                        <div class="col-sm-4">
                            <div class="service-block-v3 service-block-gold2">
                                <i class="icon-basket"></i>
                                <span class="service-heading"> SHOPPING REWARDS </span>
                                <span class="counter"><asp:Label ID="labSumShop" runat="server"></asp:Label></span>
                            
                                <div class="row">
                                    <div class="col-xs-12 service-in">
                                        <small>Redemption Value $<asp:Label ID="labSumShop2" runat="server"></asp:Label></small>
                                      
                                    </div>
                                    
                                </div>
                                     
                            </div>
                        </div>
                       <!-- 
                      <div class="col-sm-4">
                            <div class="service-block-v3 service-block-gold2">
                                <i class=" icon-diamond"></i>
                                <span class="service-heading">SHOPPING REWARDS</span>
                                <span class="counter"></span>
                              
                                <div class="row">
                                    <div class="col-xs-12 service-in">
                                        <small>Redemption Value $</small>
                                    </div>
                                    
                                </div>
                                     
                            </div>
                        </div>  -->
                    </div><!--/end row-->
                     <div class="row margin-bottom-10">
                    <div class="col-md-4 col-sm-6">
                          <!--Striped and Hover Rows-->     
                        <div class="panel margin-bottom-20">
                            <div class="panel-heading-sub">
                                <h3 class="panel-title"><i class="fa fa-pencil-square-o"></i>My Submission</h3>
                            </div>
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                       <th>My Submit Level</th>
                                       <th><asp:Label ID="labSubLevel" runat="server"></asp:Label></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Submit Points</td>
                                        <td><asp:Label ID="labSubPoint" runat="server"></asp:Label> </td>
                           
                                    </tr>
                                    <tr>
                                        <td>Eligible to earn today</td>
                                        <td><asp:Label ID="labSubRat" runat="server"></asp:Label></td>                                        
                                    </tr>
                                    
                                </tbody>
                            </table>
                        </div> </div>                  
                    <!--End Striped Rows-->
                     <div class="col-md-4 col-sm-6">
                          <!--Striped and Hover Rows-->     
                        <div class="panel margin-bottom-20">
                            <div class="panel-heading-eva">
                                <h3 class="panel-title"><i class="fa fa-check-square-o"></i>My Evaluations</h3>
                            </div>
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                       <th>My Evaluate Level</th>
                                       <th><asp:Label ID="labEvaluateLevel" runat="server"></asp:Label></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Evaluate Points</td>
                                        <td><asp:Label ID="labEvaluatePoint" runat="server"></asp:Label> </td>
                           
                                    </tr>
                                    <tr>
                                        <td>Eligible to earn today</td>
                                        <td><asp:Label ID="labEvaluateRat" runat="server"></asp:Label></td>                                        
                                    </tr>
                                    
                                </tbody>
                            </table>
                        </div> </div>                  
                    <!--End Striped Rows-->
                      <div class="col-md-4 col-sm-6">
                          <!--Striped and Hover Rows-->     
                        <div class="panel margin-bottom-20">
                            <div class="panel-heading-sha">
                                <h3 class="panel-title"><i class="fa fa-share-alt"></i>My Share</h3>
                            </div>
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                       <th>My Share Level</th>
                                       <th><asp:Label ID="labShareLevel" runat="server"></asp:Label></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Share Points</td>
                                        <td><asp:Label ID="labSharePoint" runat="server"></asp:Label> </td>
                           
                                    </tr>
                                    <tr>
                                        <td>Eligible to earn today</td>
                                        <td><asp:Label ID="labShareRat" runat="server"></asp:Label></td>                                        
                                    </tr>
                                    
                                </tbody>
                            </table>
                        </div> </div>                  
                    <!--End Striped Rows-->
                </div>
                <!-- End Service Blcoks Sampe v1 -->
                     <!-- Mixed Icon Styles -->
                      <div class="row margin-bottom-20">
                     <!--Profile Post-->
                        <div class="col-sm-12" style="display:none;">
                            <div class="panel panel-profile no-bg">
                                <div class="panel-heading overflow-h">
                                    <h2 class="panel-title heading-sm pull-left"><i class="fa fa-pencil"></i>Task Board</h2>
                                </div>
                                <div id="scrollbar" class="panel-body contentHolder">
                                    <div class="profile-post color-one">
                                        <span class="profile-post-numb">01</span>
                                        <div class="profile-post-in">
                                            <h3 class="heading-xs"><a href="#">Daily Check-In</a></h3>
                                            <p>Bonus +1 in EVERY ZONE! Just click Earnie each day!</p>
                                            <a rel="pop" class="btn btn-u btn-u-sm btn-u-blue disabled">Check in </a>
                                        </div>
                                    </div>
                                    <div class="profile-post color-two">
                                        <span class="profile-post-numb">02</span>
                                        <div class="profile-post-in">
                                            <h3 class="heading-xs"><a href="#">Browse Shop</a></h3>
                                            <p>Bonus Share Zone points - just brower 10 Tweebaa products/day. Must remain on each page AT LEAST 30 seconds for bonus 5 points per day.</p>
                                            <a rel="pop" class="btn btn-u btn-u-sm btn-u-red disabled">Browse Now </a>
                                        </div>
                                    </div>
                                    <div class="profile-post color-three">
                                        <span class="profile-post-numb">03</span>
                                        <div class="profile-post-in">
                                            <h3 class="heading-xs"><a href="#">Full Week Check-In</a></h3>
                                            <p>Bonus +10 in EVERY ZONE Check-in all 7 days/week</p>
                                            <a rel="pop" class="btn btn-u btn-u-sm btn-u-sea disabled">MON</a>
                                            <a rel="pop" class="btn btn-u btn-u-sm btn-u-sea disabled">TUE</a>
                                            <a rel="pop" class="btn btn-u btn-u-sm btn-u-default disabled">WED</a>
                                            <a rel="pop" class="btn btn-u btn-u-sm btn-u-default disabled">THU</a>
                                            <a rel="pop" class="btn btn-u btn-u-sm btn-u-default disabled">FRI</a>
                                            <a rel="pop" class="btn btn-u btn-u-sm btn-u-default disabled">SAT</a>
                                            <a rel="pop" class="btn btn-u btn-u-sm btn-u-default disabled">SUN</a>
                                        </div>
                                    </div>
                                    
                               
                                    <div class="profile-post color-seven">
                                        <span class="profile-post-numb">07</span>
                                        <div class="profile-post-in">
                                            <h3 class="heading-xs"><a href="#">Project Updates</a></h3>
                                            <p>New features of coming update</p>
                                        </div>
                                    </div>
                                </div>
                            </div>        
                        </div> </div>
                        <!--End Profile Post-->

                    <!--End Service Block v3-->
                   
                  
                </div>
                 </div>
                 <!-- JS Global Compulsory -->
<script src="../plugins/jquery/jquery.min.js"></script>
<script src="../plugins/jquery/jquery-migrate.min.js"></script>
<script src="../plugins/bootstrap/js/bootstrap.min.js"></script>
<!-- JS Implementing Plugins -->
<script src="../plugins/back-to-top.js"></script>
<script src="../plugins/counter/waypoints.min.js"></script>
<script src="../plugins/counter/jquery.counterup.min.js"></script>

<!-- Datepicker Form -->
<script src="../plugins/sky-forms/version-2.0.1/js/jquery-ui.min.js"></script>

<!-- Scrollbar -->
<script src="../plugins/scrollbar/src/jquery.mousewheel.js"></script>
<script src="../plugins/scrollbar/src/perfect-scrollbar.js"></script>

<!-- JS Customization -->
<script type="text/javascript" src="../js/custom.js"></script>

<!-- JS Page Level -->
<script src="../js/shop.app.js"></script>
<script src="../js/app.js"></script>
<script type="text/javascript" src="../js/plugins/datepicker.js"></script>
<script type="text/javascript" src="../js/plugins/style-switcher.js"></script>
<script>
    jQuery(document).ready(function () {
        App.init();
        App.initCounter();
        Datepicker.initDatepicker();
        StyleSwitcher.initStyleSwitcher();
    });
</script>
<script>
    jQuery(document).ready(function ($) {
        "use strict";
        $('.contentHolder').perfectScrollbar();
    });
</script>
<!--[if lt IE 9]>
    <script src="../plugins/respond.js"></script>
    <script src="../plugins/html5shiv.js"></script>
    <script src="../js/plugins/placeholder-IE-fixes.js"></script>
<![endif]-->

</asp:Content>