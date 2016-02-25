<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="HomeRewardGift.aspx.cs"
    Inherits="TweebaaWebApp.Home.HomeRewardGift" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link rel="stylesheet" href="../Css/index.css" />
	<link rel="stylesheet" href="../Css/home.css" />
    <link href="../Css/shareBox.css" rel="stylesheet" type="text/css" />
	<script src="../Js/jquery.min.js" type="text/javascript"></script>
	<script src="../Js/jquery.placeholder.js" type="text/javascript"></script>
	<script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
	<script src="../Js/selectNav.js" type="text/javascript"></script>
	<script src="../Js/homePage.js" type="text/javascript"></script>
	<link rel="stylesheet" href="../Css/selectCss.css" />
	<script src="../Js/selectCss.js" type="text/javascript"></script>
	<script type="text/javascript" src="../Js/public.js"></script>
    <script src="../MethodJs/homeRewardGift.js" type="text/javascript"></script>
    <script src="../MethodJs/share.js" type="text/javascript"></script>
      <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
     <%--分页--%>    
    <script src="../Js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="../Js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />
</head>
<body itemscope itemtype="http://schema.org/Product">
    <% // include google share  %>
    <!--#include file="../include/googleshare.inc" -->
    <form id="form1" runat="server">
      <div class="collection-main">
        <h2 class="t">
        My Gift Rewards
      </h2>
      
      <% // search  %>
      <div id="selectnav" class="clearfix" >
        <div class="select-search bdccc fl">
          <input type="text" class="txt" id="txtGiftName" placeholder="Please enter gift name" />
        </div>
        <div class="search-button fl">
            <button class="btn-search" type="submit" onclick="LoadRewardGift(); return false;"></button>
        </div> <br />
        <div class="fl">
          <span> Status</span>
          <select id="optStatus">
            <option value="-1">All</option>
            <option value=1>Prepare</option>
            <option value=2>Deliveried</option>
          </select>&nbsp;
          <span>Grant Date From&nbsp;</span>
          <input type="text" value="" class="time-text" id="txtBegTime" onclick="WdatePicker({ lang: 'en' })" />
          <span>&nbsp;To&nbsp;</span>
          <input type="text" value="" class="time-text"  id="txtEndTime" onclick="WdatePicker({ lang: 'en' })" />
        </div>
        <br /><br />
  
        <table class="gift-list" cellpadding="0" cellspacing="1" border="0" bgcolor="#f2f2f2" id="tabData" width="760px;" >
          <tr>
                <th>Grant Date</th>
                <th>Gift Name</th>
                <th>Source</th>
                <th>Status</th>
                <th>Remark</th>
           </tr>
        </table>
      </div>
     <div style=" clear:both;"></div>
     <div id="kkpager" style="  float:right; padding-right:150px;"></div>
   </form>
</body>
</html>
