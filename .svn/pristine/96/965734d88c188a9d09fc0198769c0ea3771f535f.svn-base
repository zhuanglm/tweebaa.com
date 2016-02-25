<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeShare3.aspx.cs" Inherits="TweebaaWebApp.Home.HomeShare3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../css/index.css" />
    <link rel="stylesheet" href="../css/home.css" />
        <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script src="../js/custom.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <script src="../js/selectNav.js" type="text/javascript"></script>
    <script src="../js/homePage.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../css/selectCss.css" />
    <script src="../js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/public.js"></script>

    <script src="../MethodJs/homeShare.js" type="text/javascript"></script>
    <script src="../Manage/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Manage/My97DatePicker/lang/en.js"></script>
    <%--分页--%>
    <script src="../Js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="../Js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />
   
</head>
<body>
    <form id="form1" runat="server"> 
    <script type="text/javascript">
        //tabs
        $(document).ready(function () {
            function jq_tabs(str) {
                $("#" + str + "Tab a").mouseover(function () {
                    $("#" + str + "Tab a").removeClass("on");
                    $(this).addClass("on");
                    var key = $("#" + str + "Tab a").index(this);
                    $("[id^='" + str + "Item']").hide();
                    $("#" + str + "Item" + key).show();
                });
                $("#" + str + "Tab a").eq(0).trigger("mouseover");
            }
            jq_tabs("share");
        });
        </script>
 <div class="home-main fl"> 
    <div class="collection-main">
        <h2 class="t">My Shares</h2>
           <p>Perhaps the most exciting part of shopping on Tweebaa is

sharing great products with your friends and earning income. <a class="learn" href="../College/College.aspx" target="_blank">Learn more</a> </p>
        <div class="share-main mt20">
            <div class="share-tab" id="shareTab">
              <a href="#" class="on">Single Product</a><%--<a href="#">Multi-Products</a>--%>
              <!--<a href="#">Order</a> --><!--<a href="#">Collage Design</a> --><%--<span>Page：<a href="#">20</a> | <a href="#">40</a></span>--%>
            </div>
            <div class="share-item" id="shareItem0" style="display: block;">

             <div class="collection-select clearfix"> 
                <div style="width:100%;clear:both;">
                  <span class="fl">Share Type </span>
                  <div class="select-box fl pr">
                    <h3 s-data="0" id="s-data">
                      All</h3>
                    <ul class="select-list">
                      <li><a href="#" s-data="-1" onclick="SetState('-1')">All</a> </li>
                      <li><a href="#" s-data="1" onclick="SetState('Facebook')">Facebook</a> </li>
                      <li><a href="#" s-data="2" onclick="SetState('Google')">Google</a> </li>
                      <li><a href="#" s-data="3" onclick="SetState('Twitter')">Twitter</a> </li>
                      <li><a href="#" s-data="4" onclick="SetState('Pinterest')">Pinterest</a> </li>
                      <li><a href="#" s-data="5" onclick="SetState('Email')">Email</a> </li>
                    </ul>
                  </div>
                  <span class="fr"><span class="fl">Share Date</span>
                    <input type="text" value="" class="time-text" id="txtBegin" onclick="WdatePicker({ lang: 'en' })" />
                    <span class="fl">To</span>
                    <input type="text" value="" class="time-text" id="txtEnd" onclick="WdatePicker({ lang: 'en' })" />
                    <input type="button" class="submit simple" value="Search"  id="btnSearch" onclick="DoSearchProductShare();" />                
                  </span>
                </div>
              <% // Share detail list %>
              <table id="shareTable" width="100%" class="tb-list" cellpadding="1" cellspacing="1" border="0" bgcolor="#f2f2f2" style="border-collapse">
              <tr>
                <th width="250">PRODUCT</th>
                <th width="180">SOCIAL MEDIA</th>
                <th width="100">CLICKS</th>
                <th nowrap>QTY SOLD</th>
                <th nowrap>COPY LINK</th>
              </tr>
              <tbody  >
                <tr >
                  <td class="bc">TOTAL</td>
                  <td class="bc"></td>
                  <td class="bc">60</td>
                  <td class="bc">60</td>
                  <td class="bc">38</td>
                </tr>
              </tbody>
            </table>
            <% // end if share details %>

            <div id="divNoData" style="display:none" >No data found! </div>
            <div id="kkpager" style="float:right; padding-right:150px;"></div><br />
           </div>
         </div>
        </div>
    </div>
    </form>
</body>
</html>
