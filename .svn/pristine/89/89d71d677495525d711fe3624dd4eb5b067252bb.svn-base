<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="HomeGiftReward.aspx.cs" Inherits="TweebaaWebApp2.Home.HomeGiftReward" %>
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

     <%--paging--%>
    <script src="../js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="../js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />

     <script src="../MethodJs/homeGiftReward.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
<div class="col-md-9">
              <h2><em class="fa fa-gift"></em> Gift Rewards</h2>
              <!--Profile Body-->
                <div class="profile-body">  
                <div class="alert alert-warning fade in">
                    <button data-dismiss="alert" class="close" type="button">×</button>       
                  Gift Rewards are offered to our members as a way to encourage participation and show our deep appreciation!  
<a class="alert-link" target="_blank" href="../College/evaluate-zone.aspx#collapseFour"> Learn more </a> .
                </div> 
 <div class="panel panel-default">
                            <div class="panel-heading">
                              <h3 class="panel-title">Gift Rewards Summary</h3>
                            </div>
                            <div class="panel-body sky-form">  
                             <section class="col-md-3" style="padding-left:0px;"> 
                       <input type="txt" class="form-control" id="txtGiftName" placeholder="Product Name">
                        </section>
                                       <section class="col-md-3" style="padding-left:0px;">
                                            <label class="input">
                                                <i class="icon-append fa fa-calendar"></i>
                                                <input type="text" name="start" id="txtBeginTime" placeholder="Start date" class="datepicker">
                                            </label>
                                        </section>
                                        <section class="col-md-3" style="padding-left:0px;">
                                            <label class="input">
                                                <i class="icon-append fa fa-calendar"></i>
                                                <input type="text" name="finish" id="txtEndTime" placeholder="End date" class="datepicker">
                                            </label>
                                        </section>
                                   
                    
                      <section class="col-md-3" style="padding-left:0px;"> 
                      <button class="btn btn-default" type="button" onclick="DoSearch()">Search</button>
                        </section>
                       
                            <div class="margin-bottom-10 "></div>
                  <table class="table table-bordered">
               
                    <thead>
                        <tr>
                           
                            <th>Gift Reward</th>
                            <th class="hidden-sm">Status</th>
                            <th>Detail</th>
                            <th>Date</th>
                        </tr>
                    </thead>
                    <tbody id="giftList">
                        <tr>
                            <td>+10</td>
                            <td>Share Reward points</td>
                            <td class="hidden-sm">10 unique clicks on shared links</td>
                            <td>Jun / 3 / 2016</td>
                           
                        </tr>
                        <tr>
                            <td>+10</td>
                            <td>Share Reward points</td>
                            <td class="hidden-sm">10 unique clicks on shared links</td>
                            <td>Jun / 3 / 2016</td>
                        </tr>
                        <tr>
                           <td>+10</td>
                            <td>Share Reward points</td>
                            <td class="hidden-sm">10 unique clicks on shared links</td>
                            <td>Jun / 3 / 2016</td>
                        </tr>
                        <tr>
                            <td>+10</td>
                            <td>Share Reward points</td>
                            <td class="hidden-sm">10 unique clicks on shared links</td>
                            <td>Jun / 3 / 2016</td>
                        </tr>
                    </tbody>
                </table>
      </div>
       <div class="page tr" id="kkpager" style="float:right; padding-right:150px; height:auto"></div>

                      </div>
                        </div>  
  
                <!--div class="text-right">
                                <ul class="pagination">
                                    <li><a href="#">«</a></li>
                                    <li><a href="#">1</a></li>
                                    <li class="active"><a href="#">2</a></li>
                                    <li><a href="#">3</a></li>
                                    <li><a href="#">4</a></li>
                                    <li><a href="#">»</a></li>
                                </ul>
                            </div-->      

           
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
        //Datepicker.initDatepicker();
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
