﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="SpinLucky.aspx.cs" Inherits="TweebaaWebApp2.SpinLucky" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Spin Lucky 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

    <link rel="stylesheet" href="../css/index.css" />
	<link rel="stylesheet" href="../css/selectCss.css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>  
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <script src="../js/jquery.placeholder2.js" type="text/javascript"></script>
    <!--
    <script src="../js/createCode.js" type="text/javascript"></script>
    -->
     <script src="../MethodJs/register.js" type="text/javascript"></script>

     <style>
 .Grid {background-color: #fff; margin: 5px 0 10px 0; border: solid 1px #525252; border-collapse:collapse; font-family:Calibri; color: #474747;}
.Grid td {
      padding: 2px;
      border: solid 1px #c1c1c1; }
.Grid th  {
      padding : 4px 2px;
      color: #fff;
      background: #363670 url(Images/grid-header.png) repeat-x top;
      border-left: solid 1px #525252;
      font-size: 0.9em; }
.Grid .alt {
      background: #fcfcfc url(Images/grid-alt.png) repeat-x top; }
.Grid .pgr {background: #363670 url(Images/grid-pgr.png) repeat-x top; }
.Grid .pgr table { margin: 3px 0; }
.Grid .pgr td { border-width: 0; padding: 0 6px; border-left: solid 1px #666; font-weight: bold; color: #fff; line-height: 12px; }  
.Grid .pgr a { color: Gray; text-decoration: none; }
.Grid .pgr a:hover { color: #000; text-decoration: none; }
     </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

<form id="form1" runat="server">
    <div class="w975" style="padding:40px 0">  
        <asp:GridView ID="gvwTrackingReport" runat="server" AutoGenerateColumns="true" Width="90%"
                      AllowPaging="true" PageSize="20" OnPageIndexChanging="grid_PageIndexChanging"
                      CssClass="Grid"                    
                      AlternatingRowStyle-CssClass="alt"
                      PagerStyle-CssClass="pgr">



        </asp:GridView>
    </div>
</form>

</asp:Content>
