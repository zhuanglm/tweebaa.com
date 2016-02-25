<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="HomeGiftReward.aspx.cs"
    Inherits="TweebaaWebApp.Home.HomeGiftReward" %>

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
    <script src="../MethodJs/homeGiftReward.js" type="text/javascript"></script>
    <script src="../MethodJs/share.js" type="text/javascript"></script>
      <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
     <%--分页--%>    
    <script src="../Js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="../Js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    </style>
</head>
<body itemscope itemtype="http://schema.org/Product">
    <% // include google share  %>
    <!--#include file="../include/googleshare.inc" -->
    <form id="form1" runat="server">
    <div class="home-main fl"> 
      <div class="collection-main">
        <h2 class="t">
        My Gift Rewards
        </h2>
        <p>Gift Rewards are offered to our members as a way to encourage participation and show our deep appreciation! <br />
        <a class="learn" href="../College/EvaluateZone.aspx?page=evaluate-zone" target="_blank">Learn more</a> </p>
      <% // search  %>
        <div class="collection-select clearfix">
          <span class="fl">Product Name</span>
          <input type="text" class="txt fl" id="txtGiftName" placeholder="Please enter gift name" style="width:300px; height:20px;border:1px solid #ccc; border-radius:3px;" />
          <span class="fl">&nbsp;&nbsp;&nbsp;Status </span>
          <span class="fl"  >
            <select id="optStatus" style="height:20px; border:1px solid #ccc; border-radius:3px;" >
              <option value="-1">All</option>
              <option value=1>Prepare</option>
              <option value=2>Deliveried</option>
            </select>
          </span><br />
          <span class="fl">Reward Date From&nbsp;</span>
          <input type="text" value="" class="time-text" id="txtBegTime" onclick="WdatePicker({ lang: 'en' })" />
          <span class="fl" >&nbsp;To&nbsp;</span>
          <input type="text" value="" class="time-text"  id="txtEndTime" onclick="WdatePicker({ lang: 'en' })" />
          <div class="search-button fl pr">
            <input class="submit" type="button" value="Search" onclick="LoadGiftRewardList(); return false;" />
          </div> 
        </div>
        <br />
        <table width="100%" class="tb-list" cellpadding="0" cellspacing="1" border="0" bgcolor="#f2f2f2" id="giftList">
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
     <div class="page tr" id="kkpager" style="  float:right; padding-right:150px;"></div>
     </div>
   </form>
</body>
</html>
