﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="shopping_reward.aspx.cs" Inherits="TweebaaWebApp2.College.shopping_reward" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Shopping Reward
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">


    <link rel="stylesheet" href="/css/pages/page_faq1.css">
    <link rel="stylesheet" href="/css/pages/pricing/pricing_v5.css"> 
    <link rel="stylesheet" href="/css/pages/pricing/pricing_v6.css"> 
    <link rel="stylesheet" href="/css/pages/pricing/pricing_v7.css"> 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
         <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Shopping Reward Points</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="/index.aspx">Home</a></li>
                <li><a href="/College/Education.aspx">Education</a></li>
                <li class="active">Shopping Reward Points </li>
            </ul>
        </div> 
    </div><!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->  
        
      <!--=== Content Part ===-->
    <div class="container content">	
  <h3 class="heading-sm">Things you should know about Shopping Reward Points: </h3>
  <p>They add up. – For every dollar you spend at Tweebaa.com (excluding shipping fees and taxes), you will earn one Shopping Reward Point. You’ll earn as follows: 
</p>
       
                <div class="row margin-bottom-20 margin-top-20">
   <div class="col-md-6">
    <div class="panel panel-red ">
                          
                            <table class="table table-hover table-bordered text-center">
                                <thead>
                                    <tr>
                                        <th style="text-align:right">Tweebaa Purchase Amount</th>
                                        <th style="text-align:right">Points Earned</th>
                                        <th style="text-align:right">Redemption Amount</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td style="text-align:right">$400.00</td>
                                        <td style="text-align:right">400</td>
                                        <td style="text-align:right">$5.00</td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:right">$800.00</td>
                                        <td style="text-align:right">800</td>
                                        <td style="text-align:right">$10.00</td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:right">$1,200.00</td>
                                        <td style="text-align:right">1200</td>
                                        <td style="text-align:right">$15.00</td>
                                    </tr>
                                  
                                </tbody>
                            </table>
                        </div>
    </div>  </div>
    
   <div class="tag-box tag-box-v4 margin-bottom-40">
  <dl class="dl-horizontal">
                                <dt>Browsing points. 
</dt>
                                <dd>If you browse 10 Tweebaa products per day, you can earn extra Browsing points! Details below.</dd>
                                <dt>Bonus points. </dt>
                                <dd>Keep an eye out for Bonus offers; certain Tweebaa products will earn DOUBLE Shopping Reward Points.</dd>
                              
                                <dt>Earning. </dt>
                                <dd>You must be logged in to your account when a purchase is made in order to earn Shopping Reward points. Points will automatically be added to your account upon completion of any purchase. Check your Member Account to see totals. </dd>
                                <dt>Redeeming. </dt>
                                <dd>You must be logged in to your account to redeem Shopping Reward Points. At checkout you will see any available points along with their redemption value; you can select to apply all or a portion of Shopping Reward discounts to your purchase amount. </dd>
                                <dt>Cha-ching! </dt>
                                <dd>Every 400 points in your account has a redemption value of $5.00.  </dd>
                                   <dt>They don’t last forever. </dt>
                                <dd>Shopping Reward Points expire 6 months from purchase. </dd>
                            </dl>  </div>
               
              
    <ul class="pager">
                   <li class="previous"><a class="rounded" href="commission.aspx">← Back to Commission</a></li>
                    </ul>
    </div>	
    <!--=== End Content Part ===-->

</asp:Content>
