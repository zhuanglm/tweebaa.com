﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/SlotMachine.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TweebaaWebApp2.Games.SlotMachine.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <!--
  <link href='http://fonts.googleapis.com/css?family=Slackey' rel='stylesheet' type='text/css'/>
  <link type="text/css" rel="stylesheet" href="css/reset.css" /> -->
  <link type="text/css" rel="stylesheet" href="css/slot.css" />
   <style>
 .Grid {background-color: #fff; margin: 5px 0 10px 0; border: solid 1px #525252; border-collapse:collapse; font-family:Calibri; color: #474747;}
.Grid td {
      padding: 2px;
      border: solid 1px #c1c1c1; }
.Grid th  {
      padding : 4px 2px;
      color: #fff;
      background: #363670 url(/images/slot_machine/grid-header.png) repeat-x top;
      border-left: solid 1px #525252;
      font-size: 0.9em; }
.Grid .alt {
      background: #fcfcfc url(/images/slot_machine/grid-alt.png) repeat-x top; }
.Grid .pgr {background: #363670 url(/images/slot_machine/grid-pgr.png) repeat-x top; }
.Grid .pgr table { margin: 3px 0; }
.Grid .pgr td { border-width: 0; padding: 0 6px; border-left: solid 1px #666; font-weight: bold; color: #fff; line-height: 12px; }  
.Grid .pgr a { color: Gray; text-decoration: none; }
.Grid .pgr a:hover { color: #000; text-decoration: none; }
     </style>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
<input type="hidden" id="userGuid" value="<%=_userid %>" />
<form runat="server">


<section id="about" class="about-section section-first">
    
    <div class="container content">
    
      <div class="row margin-bottom-5 margin-top-20">
                    <div class="col-md-7 md-margin-bottom-30 " > 
                    <div class="spinslot"><img src="/images/slot_machine/laohuji4_04.jpg" /></div>
                    <div class="spinbg"><div class="spinslot">
   <div id="container">

      <div id="reels">
      <table cellpadding="0" cellspacing="0"  class="SlotArrow">
      <tr>
        <td  align="center" class="can1"><canvas id="canvas1"></canvas></td>
          <td  align="center" class="can2"><canvas id="canvas2"></canvas></td>
          <td align="center" class="can3"><canvas id="canvas3"></canvas></td>
      </tr>
      </table>
	

    <!--
	<div id="overlay">
	  <div id="winline"></div>
	</div>    -->
	<div id="results">
    <!--
	  <div id="score">
	    <span id="multiplier">0</span> x <img src="/Games/SlotMachine/img/gold-64.png"/>
	  </div> -->
	  <div id="status"></div>
	</div>

      </div>


    </div>                  
                    </div></div>
                    <div class="spinbtnbg">
                    <div class="spinbtn"><img id="play"  style="cursor:pointer"  src="/images/slot_machine/slots.png" /></div>
                    <div class="points">Only 60 points per spin! <a href="/College/College.aspx">earn points</a></div>
                    
                     <div class="mypoints" id="divMyPoints"><%=_share_points %></div>
                      <div class="rules"><a href="/Games/SlotMachine/rules.aspx">Official Rules</a></div>
                    </div>
                      
                <!--Basic Table-->
                 <div class="winner"><img src="/images/slot_machine/recent_winners.png" /></div>
                <table class="table rewardlist">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>DATE</th>
                            <th>PLAYER</th>
                            <th>PRIZE</th>
                          
                        </tr>
                    </thead>
                    <tbody id="idPrizeList">

                    <!--
                        <tr>
                            <td>1</td>
                            <td>02/10/2015</td>
                            <td>Mark</td>
                            <td>$1111</td>                          
                        </tr>
                        <tr>
                            <td>1</td>
                            <td>02/10/2015</td>
                            <td>Mark</td>
                            <td>$1111</td>   
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>02/10/2015</td>
                            <td>Mark</td>
                            <td>$1111</td>              
                        </tr>
                        <tr>
                            <td>4</td>
                          <td>02/10/2015</td>
                            <td>Mark</td>
                            <td>$1111</td>   
                         </tr>  
                          <tr>
                            <td>4</td>
                          <td>02/10/2015</td>
                            <td>Mark</td>
                            <td>$1111</td>   
                         </tr>  -->
                    </tbody>
                </table>
                <!--End Basic Table-->
                      
        </div>
                    <div class="col-md-5 md-margin-bottom-30">
                       <div class="slotext1 margin-bottom-15"><img src="/images/slot_machine/text_1.png"/></div>
                 <div class="funny-boxes funny-boxes-grey">
                    <div class="row">
                        <div class="col-md-5 funny-boxes-img">
                            <img class="img-responsive" src="/images/slot_machine/points_icon.png" alt="">
                       
                        </div>
                        <div class="col-md-7">
                            <p class="golden"> Redeem for <br>
· Discounts <br>
· Tweebaa game tips <br>
· SPIN of LUCKY SLOTS</p>
<button class="btn-u btn-u-spin rounded" type="button" onclick="window.location.href='/Games/SlotMachine/RewardsHowTo.aspx'"><span class="golden">How to Get & Redeem</span></button>
                        </div>
                    </div>                            
                </div>
                <div class="funny-boxes funny-boxes-grey">
                    <div class="row">
                        <div class="col-md-5 funny-boxes-img2">
                            <img class="img-responsive" src="/images/slot_machine/cash.png" alt="">
                       
                        </div>
                        <div class="col-md-7">
                            <p class="golden"> 
·Withdraw directly to your
    paypal account <br>
·Redeem for Free products <br></p>

<button class="btn-u btn-u-spin rounded" type="button" onclick="window.location.href='/Games/SlotMachine/RewardsHowTo.aspx'"><span class="golden">How to Get & Redeem</span></button>
                        </div>
                    </div>                            
                </div>
                
                       <div class="slotext1 margin-bottom-15"><img src="/images/slot_machine/text_2.png"/></div>
              <div class="funny-boxes funny-boxes-grey" style="padding:0px; ">
              <div class="title">Show me How to TweeBot !</div>
                        <div class="responsive-video md-margin-bottom-40">
                            <iframe width="100%" src="https://www.youtube.com/embed/P1SP900ExfU?rel=0" frameborder="0" allowfullscreen></iframe>
                        </div>
                    </div>
                    <div class="funny-boxes funny-boxes-grey" style="padding:0px;">
                     <div class="title">Buy ExerSeat at <span class="omg">50% 0ff</span> Price Now!
</div>
                        <div class="responsive-video md-margin-bottom-40">
                        
                            <iframe width="100%" src="https://www.youtube.com/embed/lIJ5b1ToKtI?rel=0" frameborder="0" allowfullscreen></iframe>
                           

                            
                        </div>
                    </div>
                    <div class="funny-boxes funny-boxes-grey">
               <div class="appimg margin-bottom-15"><img src="/images/slot_machine/get_app.png"/></div>
               <div class="appicon"><a href="https://itunes.apple.com/ca/app/tweebaa/id1027840811?mt=8" class="pr"><img src="/images/slot_machine/appstore-icons.png" width="160"/></a><a href="https://play.google.com/store/apps/details?id=com.Tweebaa.App.CollageApp" target="_blank"><img src="/images/slot_machine/android-icons.png" width="160"/></a></div>
                    </div>
                    </div>
                    
      </div>    
           <!-- Pricing Table v2-->
     <!--  <div class="row pricing-table-v2 no-space-pricing">
           
            <div class="col-md-4 col-sm-4 col-xs-6">
                <div class="pricing-v2 pricing-v2-brown">
                    <div class="pricing-v2-head text-center">
                      <i class="icon-custom icon-color-brown rounded-x fa fa-check-square-o"></i>
                       <h4 class="heading-md"> CASH $$$</h4>
                       <h5 class="text-center"><i>Directly to your Paypal Account </i></h5>
 
                    </div>
                
                    </div>
                </div>
            <div class="col-md-4 col-sm-4 col-xs-6">
                <div class="pricing-v2 pricing-v2-red">
                    <div class="pricing-v2-head text-center">
                      <i class="icon-custom icon-color-red rounded-x fa fa-shopping-cart"></i>
                        <h4 class="heading-md">Shopping Rewards</h4>
                        <h5 class="text-center"><i> Exchange for Free Tweebaa Products  </i></h5>
                    </div>
              
                 
                </div>
            </div>
            <div class="col-md-4 col-sm-4 col-xs-6">
                <div class="pricing-v2 pricing-v2-orange rounded-3">
                    <div class="pricing-v2-head text-center">
                        <i class="icon-custom icon-color-orange rounded-x fa fa-comments-o"></i>
                        <h4 class="heading-md">Share Points</h4>
                        <h5 class="text-center"><i> Redeem for: 1) Purchase Discount</i></h5> 
                    </div>
                
                 
                </div>
            </div>
        </div>  !--/row-->
        <!-- End Pricing Table v2--> 
    
        </div>            
</section>

      <!--=== Content Part ===-->
    <div class="container content">	

 <div id="viewport">
   

  </div>

  <script type="text/javascript" src="js/slot.js?v=20160128"></script>
  <script type="text/javascript">      $(function () { SlotGame(); });</script>
  <script type="text/javascript">
  
  </script>

  </div>

  </form>

  <script type="text/javascript">
      $(document).ready(function () {
          //console.log( "ready!" );

          $.ajax({
              type: "Post",
              url: "/Games/SlotMachine/SlotMachineDBHandle.ashx",
              data: "{'action':'load_lucky_winner'" + "}",
              success: function (resu) {
                  if (resu == 1) {
                      return;
                  }
                  var obj = eval("(" + resu + ")");
                  var html = "";
                  for (var i = 0; i < obj.length; i++) {
                      var data = obj[i];
                      html += '<tr>';
                      html += '<td>'+(i+1)+'</td>';
                      html += '<td>' + data.AddDate.substring(0,10) + '</td>';
                      html += '<td>'+data.username+'</td>';
                      html += '<td>'+data.SlotMachinePrizeText+'</td>';
                      html += '</tr>';
                  }
                  $("#idPrizeList").html(html);
              }
          });
      });
  </script>

</asp:Content>
