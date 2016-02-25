﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="Shopping_Points.aspx.cs" Inherits="TweebaaWebApp2.Home.Shopping_Points" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
My Shopping Point
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="../css/index.css" />
    <link rel="stylesheet" href="../css/home.css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/custom.js"></script>
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <script src="../js/selectNav.js" type="text/javascript"></script>
    <script src="../js/homePage.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../css/selectCss.css" />
    <script src="../js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/public.js"></script>
    <script src="../MethodJs/shopping_point.js" type="text/javascript"></script>
     <script src="../js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="../js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />
     <link rel="stylesheet" href="../plugins/sky-forms/version-2.0.1/css/custom-sky-forms.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

<div class="col-md-9">
            <h2><i class="fa fa-shopping-cart"></i> Shopping Points</h2>
                <!--Profile Body-->
                <div class="profile-body">   

                    <!--Service Block v3-->
                    <div class="row content-boxes-v2 margin-bottom-20">
 
                 <div class="col-md-4">              
                        <div class="service-block-v3 service-block-gold2">  
                        


                                <span class="service-heading"> Shopping Rewards Redemption Value </span>

                                <i class="icon-basket"></i>
                                
                                <span class="counter">$<asp:Label ID="labSumShop2" runat="server"></asp:Label> </span>
                            
                                <div class="row">
                                    <div class="col-xs-12 service-in">
                                        <small>You have <asp:Label ID="labAvailablePoint" runat="server"></asp:Label> points <br />
                                        <asp:Label ID="labSumShopPending" runat="server"></asp:Label> points pending
                                        </small>
                                        <br />(400 points = $5.00)
                                        
                                      
                                    </div>
                                    
                                </div>

                                      </div></div>

                   
                </div>
                <!--Table Bordered--> 
           <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="icon-basket-loaded"></i> Shopping Points Summary</h3>
                            </div>
                            <div class="panel-body sky-form">        
               
                                         <section class="col-md-3" style="padding-left:0px;">
                                            <label class="input">
                                                <i class="icon-append fa fa-calendar"></i>
                                                <input type="text" name="start" id="txtBeginTime" placeholder="Start date" class="datepicker">
                                            </label>
                                        </section>
                                        <section class="col-md-3" style="padding-left:0px;">
                                            <label class="input">
                                                <i class="icon-append fa fa-calendar"></i>
                                                <input type="text" name="finish" id="txtEndTime" placeholder="End Date" class="datepicker">
                                            </label>
                                        </section>
                                   
                    
                      <section class="col-md-4" style="padding-left:0px;"> 
                      <button class="btn btn-default" type="button" onclick="serch()">Search</button>
                        </section>
                           
                  
                            <div class="margin-bottom-10 "></div>
                  <table class="table table-bordered">
             
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Reward points</th>
                            <th>Related order</th>
                            <th class="hidden-sm">Remarks</th>
                            
                        </tr>
                    </thead>
                    <tbody id="profit-data2">
                                       
                                    </tbody>
                                    <!--  
                    <tbody>
                        <tr>
                            <td class="hidden-sm">1</td>
                            <td>33</td>
                            <td>#TWEE8923455</td>
                            <td  class="hidden-sm">$22.66</td>
                            <td>Jun / 12 / 2015</td>
                        </tr>
                        <tr>
                            <td class="hidden-sm">2</td>
                            <td>33</td>
                            <td>#TWEE8923455</td>
                            <td  class="hidden-sm">$22.66</td>
                            <td>Jun / 12 / 2015</td>
                        </tr>
                        <tr>
                            <td class="hidden-sm">3</td>
                            <td>33</td>
                            <td>#TWEE8923455</td>
                            <td  class="hidden-sm">$22.66</td>
                            <td>Jun / 12 / 2015</td>
                        </tr>
                        <tr>
                            <td class="hidden-sm">4</td>
                             <td>33</td>
                           <td>#TWEE8923455</td>
                            <td  class="hidden-sm">$22.66</td>
                            <td>Jun / 12 / 2015</td>
                        </tr>
                    </tbody> -->
                </table>
                      </div>
                        </div> 
                  <div class="text-right">
                  <!--
                                <ul class="pagination">
                                    <li><a href="#">«</a></li>
                                    <li><a href="#">1</a></li>
                                    <li class="active"><a href="#">2</a></li>
                                    <li><a href="#">3</a></li>
                                    <li><a href="#">4</a></li>
                                    <li><a href="#">»</a></li>
                                </ul>
                                -->
                                 <div id="kkpager" >
                                </div>
                            </div>      

                </div>
                 </div>
<!-- Datepicker Form -->
<script src="/plugins/sky-forms/version-2.0.1/js/jquery-ui.min.js"></script>
<script src="/plugins/counter/waypoints.min.js"></script>
<script src="/plugins/counter/jquery.counterup.min.js"></script>

<script type="text/javascript" src="/js/plugins/datepicker.js"></script>

<script>
    jQuery(document).ready(function () {

        Datepicker.initDatepicker();
        $(".datepicker").datepicker({
            nextText: ">",
            prevText: "<"
        });

 
    });
</script>
</asp:Content>
