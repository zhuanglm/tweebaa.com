﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="HomeOrderDetailSupplier.aspx.cs" Inherits="TweebaaWebApp.Home.HomeOrderDetailSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
	<link rel="stylesheet" href="../css/index.css" />
	<link rel="stylesheet" href="../css/home.css" />
    <link rel="stylesheet" href="../css/c.css" />
	<script src="../js/jquery.min.js" type="text/javascript"></script>
	<script src="../js/jquery.placeholder.js" type="text/javascript"></script>
	<script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
	<script src="../js/selectNav.js" type="text/javascript"></script>
	<script src="../js/homePage.js" type="text/javascript"></script>
	<link rel="stylesheet" href="../css/selectCss.css" />
	<script src="../js/selectCss.js" type="text/javascript"></script>
	<script type="text/javascript" src="../js/public.js"></script>
	<script type="text/javascript" src="../js/home-safe.js"></script>
    <script src="../MethodJs/homeOrderDetailSupplier.js" type="text/javascript"></script>    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
<!-- 用户中心内容 -->
<div class="w967 home-page">
	<div class="wrap clearfix">
 <!-- to jack 从这里开始套 -->   		
<div class="home-main details fl">
<div class="details-main"><!--safe-main-->
<h2 class="t">ORDER INFORMATION DETAILS</h2>
  <div class="section clearfix">
             
                  <p><strong>Order Date: </strong><span id="labOrderDate"></span></p>
                  <p><strong>Customer Order Number: </strong><span id="labCustomerOrderNo"></span></p>
                  <p><strong> P.O. Number: </strong><span id="labShipOrderNo"></span></p>
                  <p><strong>Order Status: </strong> <span class="f14 blue"><span id="labShipOrderStatus"></span></span></p>
                  <p><strong>Shipping Info： </strong><span id="labShipMethod"></span></p>    
                  <p><strong>Tracking Number： </strong><a href="#" class="unline blue"><span id="labTrackingNo"></span></a></p>
                
               </div>
                   <br />
               <div class="section  clearfix">    
                   
                   <div class="fl" style="width:100%">
                <h3 class="f14">Shipping To</h3>
                <p><span id="labShipToName"></span><br><span id="labShipToAddress"></span><br><span id="labShipToCityProvZip"></span><br><span id="labShipToCountry"></span></p>
                
                </div>
             
           </div>

                <div class="section  clearfix">
               
                  <h3 class="t">Product Details</h3>
                 

                  <table id="tbItemList" width="100%" class="table">
					<tr style="border-right:#f2f2f2 1px solid ;border-left: #f2f2f2 1px solid; text-transform:uppercase;">
						<th width="152"> OUR Item #</th>                                                                                      
						<th width="152">YOUR Item #</th>
                        <th width="70">QTY</th>	
                         <th width="130">Description</th>	
						<th width="85">Unit Price</th>
                        <th width="85">Line Total</th>
                        
                 

					</tr>
                    
				   <tr>
						<td ><span class="text"> <a href="#">12345678</a></span></td>		
						<td><span class="text">12345678</span></td>
                     
                        <td><span class="text">1</span></td>
                        
                        <td><span class="text">2015 Winter shoe<br />Black/43</span></td>
                           <td><span class="text">$22.22 </span></td>
                        <td><span class="text">$22.22</span></td>
                   
        
                    </tr>
                    
                    <tr>
						<td ><span class="text"> <a href="#">12345678</a></span></td>		
						<td><span class="text">12345678</span></td>
                     
                        <td><span class="text">1</span></td>
                        
                        <td><span class="text">2015 Winter shoe<br />Black/43</span></td>
                           <td><span class="text">$22.22 </span></td>
                        <td><span class="text">$22.22</span></td>
                   
        
                    </tr>
              <tr>
						<td colspan="5" style="text-align:right; padding:0px; border:0; ">
							Total Products : 
                      
						</td>
                      <td style="border:0;line-height:10px;">$56.00</td>
                    </tr>
				
                     <tr>
						<td colspan="5" style="text-align:right; border:0;line-height:10px;">
							Estimated shipping: </td>
                      <td style="border:0; line-height:10px;">$9.9</td>
                    </tr>
                 
					
				</table>
               
               
                </div>
			</div>
		</div>
         <!-- to jack 从这里结束 -->   
	</div>
</div>

</asp:Content>
