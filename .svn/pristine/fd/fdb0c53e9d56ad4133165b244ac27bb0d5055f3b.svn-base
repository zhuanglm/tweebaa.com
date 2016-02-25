<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeShare.aspx.cs" Inherits="TweebaaWebApp.Home.HomeShare" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <!-- add by long for paging since kkpager only support one item  -->
    <script src="../Js/jquery.paging.js" type="text/javascript"></script>
    <!-- add this style by long for add a collage -->
    <style>
    .select-list_collage {
      border: 1px solid #ccc;
      position: absolute;
      z-index: 9;
      left: 0;
      top: 15px;
      padding-top: 15px;
      width: 140px;
      display: none;
      border-radius: 3px;
      font-size: 11px;
      background-color: #fff;
      line-height: 24px;
    }
    .select-box_collage  h3 {
  width: 125px;
  height: 22px;
  line-height: 22px;
  background: url(../home/images/sjx1.png) 90% center no-repeat #fff;
  border: 1px solid #ccc;
  border-radius: 3px;
  font-size: 11px;
  padding-left: 15px;
  cursor: pointer;
  position: relative;
  z-index: 10;
  margin-bottom: 0px !important;
}
.select-list_collage a {
  color: #666;
  display: block;
  padding-left: 15px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">   
    <script>
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
        <div class="share-main mt20">
            <div class="share-tab" id="shareTab"><a href="#" class="on">Single Product</a><a href="#">Multi-Products</a>
            <a href="#">Order</a><a href="#">Collage Design</a><%--<span>Page：<a href="#">20</a> | <a href="#">40</a></span>--%></div>
           
            <div class="share-item" id="shareItem0" style="display: block;">

             <div class="collection-select clearfix"> 
                <span class="fl">Share Type </span>
                <div class="select-box fl pr">
                <h3 s-data="0" id="s-data">
                    All</h3>
                <ul class="select-list">
                    <li><a href="#" s-data="-1" onclick="SetState('-1')">All</a> </li>
                    <li><a href="#" s-data="1" onclick="SetState('Facebook')">Facebook</a> </li>
                    <li><a href="#" s-data="2" onclick="SetState('Google')">Google</a> </li>
                    <li><a href="#" s-data="3" onclick="SetState('Twitter')">Twitter</a> </li>
                    <li><a href="#" s-data="4" onclick="SetState('Pintest')">Pintest</a> </li>
                    <li><a href="#" s-data="5" onclick="SetState('Email')">Email</a> </li>

                </ul>
            </div>
                <span class="fr"><span class="fl">Share Date</span>
                   <input type="text" value="" class="time-text" id="txtBegin" onclick="WdatePicker({ lang: 'en' })" />
                   <span class="fl">To</span>
                   <input type="text" value="" class="time-text" id="txtEnd" onclick="WdatePicker({ lang: 'en' })" />
                   <input type="button" class="submit simple" value="Search"  id="btnSerch" onclick="loadMeinv()" />                
                </span>
            </div>
                <table width="100%" class="tb-list" cellpadding="0" cellspacing="1" border="0" bgcolor="#f2f2f2"
                    id="tableShare">
                    <tr>
                        <th>
                            Date
                        </th>
                        <th>
                            Product Name
                        </th>
                        <th>
                            Promote Via
                        </th>
                        <th>
                            Visits
                        </th>
                        <th>
                            Buyers
                        </th>
                        <th>
                            Income Amount（$）
                        </th>
                         <th>
                           Copy Share Link
                        </th>
                    </tr>
                </table>
                <div id="kkpager" style="float: right; padding-right: 100px;">
                </div>
            </div>

            <!-- collage design share -->
            <div class="share-item" id="shareItem3" style="display: block;">
                
               <div class="collection-select clearfix"> 
                <span class="fl">Share Type </span>
                <div class="select-box fl pr">
                <h3 s-data="0" id="s_data_collage">
                    All</h3>
                <ul class="select-list_collage">
                    <li><a href="#" s-data="-1" onclick="SetState('-1')">All</a> </li>
                    <li><a href="#" s-data="1" onclick="SetState('Facebook')">Facebook</a> </li>
                    <li><a href="#" s-data="2" onclick="SetState('Google')">Google</a> </li>
                    <li><a href="#" s-data="3" onclick="SetState('Twitter')">Twitter</a> </li>
                    <li><a href="#" s-data="4" onclick="SetState('Pintest')">Pintest</a> </li>
                    <li><a href="#" s-data="5" onclick="SetState('Email')">Email</a> </li>

                </ul>
            </div>
                <span class="fr"><span class="fl">Share Date</span>
                   <input type="text" value="" class="time-text" id="txtCollageBegin" onclick="WdatePicker({ lang: 'en' })" />
                   <span class="fl">To</span>
                   <input type="text" value="" class="time-text" id="txtCollageEnd" onclick="WdatePicker({ lang: 'en' })" />
                   <input type="button" class="submit simple" value="Search"  id="btnSubmitSearch" onclick="loadCollageMeinv()" />                
                </span>
            </div>
                <table width="100%" class="tb-list" cellpadding="0" cellspacing="1" border="0" bgcolor="#f2f2f2"
                    id="tblCollageDesignList">
                    <tr>
                        <th>
                            Date
                        </th>
                        <th>
                            Design Name
                        </th>
                        <th>
                            Promote Via
                        </th>
                        <th>
                            Visits
                        </th>
                        <th>
                            Buyers
                        </th>
                        <th>
                            Income Amount（$）
                        </th>
                         <th>
                           Copy Share Link
                        </th>
                    </tr>
                </table>
                <div id="dvCollage" class="pageBtnWrap" style="float: right; padding-right: 100px;">
                </div>


            </div>

            <!-- collage design share EOF -->
        </div>
    </div>
     </div>
    </form>
</body>
</html>
