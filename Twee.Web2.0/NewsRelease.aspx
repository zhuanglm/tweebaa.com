﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="NewsRelease.aspx.cs" Inherits="TweebaaWebApp2.NewsRelease" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
<%=gs_pageTitle %>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
<meta name="keywords" content="<%=gs_SEOKeyword %>">
<meta name="description" content="<%=gs_SEOMetaTag %>"> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

           <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left"><%=gs_pageTitle %></h1>
            <ul class="pull-right breadcrumb">
                <li><a href="/index.aspx">Home</a></li>
                <li class="active">News Release</li>
            </ul>
        </div>
    </div><!--/breadcrumbs-->
      <!--=== Content Part ===-->
    <div class="container content">		
            <h1><%=gs_pageTitle %></h1>

        <div>
        <%=gs_pageDescription %>
        </div>
    </div>


</asp:Content>