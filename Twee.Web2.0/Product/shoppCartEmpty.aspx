﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="shoppCartEmpty.aspx.cs" Inherits="TweebaaWebApp2.Product.shoppCartEmpty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
  <!-- Meta -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    
    

    <!-- CSS Global Compulsory -->
    <link rel="stylesheet" href="../plugins/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="../css/shop.style.css">
     
    <!-- CSS Implementing Plugins -->
    <link rel="stylesheet" href="../plugins/line-icons/line-icons.css">
    <link rel="stylesheet" href="../plugins/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="../plugins/scrollbar/src/perfect-scrollbar.css">

   
    <!-- CSS Page Style -->    
    <link rel="stylesheet" href="../css/pages/page_404_error.css">

    <!-- Style Switcher -->
    <link rel="stylesheet" href="../css/plugins/style-switcher.css">

    <!-- CSS Theme -->
    <link rel="stylesheet" href="../css/theme-colors/default.css" id="style_color">

    <!-- CSS Customization -->
    <link rel="stylesheet" href="../css/custom.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

        
         <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Shopping Cart Empty</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="../index.aspx">Home</a></li>
                <li><a href="#">Pages</a></li>
                <li class="active">Shopping Cart Empty</li>
            </ul>
        </div> 
    </div><!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->  
        
      <!--=== Content Part ===-->
    <div class="container content">		
        <!--Error Block-->
        <div class="row">
            <div class="col-md-7 col-md-offset-2">
                <div class="error-v1">
                 <span>Your Shopping cart is empty</span> 
               <span class="error-v1-title2 "> <img src="../images/tw-cry.png"></span>
               
               <a class="btn-u btn-bordered rounded" href="prdSaleAll.aspx">Go to Shop</a></div>
               
            </div>
        </div>
        <!--End Error Block-->
    </div>	
    <!--=== End Content Part ===-->


<script src="../plugins/jquery/jquery.min.js"></script>
<script src="../plugins/jquery/jquery-migrate.min.js"></script>
<script src="../plugins/bootstrap/js/bootstrap.min.js"></script>
<!-- JS Implementing Plugins -->
<script src="../plugins/back-to-top.js"></script>

<!-- JS Page Level -->
<script src="../js/shop.app.js"></script>
<script src="../js/app.js"></script>
<script type="text/javascript" src="../js/plugins/style-switcher.js"></script>
<script>
    jQuery(document).ready(function () {
        App.init();
        StyleSwitcher.initStyleSwitcher();
    });
</script>


</asp:Content>
