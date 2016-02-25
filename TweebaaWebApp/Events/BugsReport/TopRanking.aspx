<%@ Page Language="C#" MasterPageFile="~/MasterPages/EventsMasterPage.Master"  AutoEventWireup="true" CodeBehind="TopRanking.aspx.cs" Inherits="TweebaaWebApp.Events.BugsReport.TopRanking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/Css/index.css" />
    <link rel="stylesheet" href="/Css/home.css" />
    <link href="/Css/shareBox.css" rel="stylesheet" type="text/css" />
    <script src="/Js/jquery.min.js" type="text/javascript"></script>
    <script src="/Js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Js/jquery-hcheckbox.js"></script>
    <script src="/Js/selectNav.js" type="text/javascript"></script>
    <script src="/Js/homePage.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/Css/selectCss.css" />
     
     <link rel="stylesheet" href="/Css/find-bug.css" />

    <script src="/Js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Js/public.js"></script>
    <script src="/MethodJs/BugsTopRanking.js" type="text/javascript"></script>
    <script src="/MethodJs/share.js" type="text/javascript"></script>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">  

	<div class="w964">
<!-- Top Ranking here -->
<div class="bug-report">
    <h2>Top 50 Bug Finder</h2>

<div class="bug_table" >
    <table  id="tabCollection" >
            <tr>
                <th class="pro-name">
                    Selected Design
                </th>
                <th class="state">
                    Status
                </th>
                <!--
                <th class="price">
                    Price
                </th>
                -->
                <th class="operation">
                    Action
                </th>
            </tr>
        </table>
</div>
        <!--
            <div id="kkpager" >
           </div>     
           -->
</div>
<!-- Top Ranking here  -->
    </div>
</asp:Content>