﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ComingSoon.aspx.cs" Inherits="TweebaaWebApp2.ComingSoon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

         <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Coming Soon</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="/index.aspx">Home</a></li>
                <li><a href="#">Pages</a></li>
                <li class="active">Coming Soon</li>
            </ul>
        </div> 
    </div><!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->  
        
      <!--=== Content Part ===-->
    <div class="container content">		
        <!--Error Block-->
        <div class="row">
            <p style="text-align:center"><img src="/images/comingsoon.png" /></p>
        </div>
    </div>
</asp:Content>