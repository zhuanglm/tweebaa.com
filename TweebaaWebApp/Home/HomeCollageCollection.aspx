<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeCollageCollection.aspx.cs" Inherits="TweebaaWebApp.Home.HomeCollageCollection" %>


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
    <script src="../MethodJs/homeCollageCollection.js" type="text/javascript"></script>
    <script src="../MethodJs/share.js" type="text/javascript"></script>

       <%--分页--%>    
    <script src="../Js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="../Js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />
</head>
<body itemscope itemtype="http://schema.org/Product">
    <% // include google share  %>
    <!--#include file="../include/googleshare.inc" -->
    <form id="form1" runat="server">
    <!-- 搜索 -->
    <div id="selectnav" class="clearfix" style=" display:none;">
        <div class="select-search bdccc fl">
            <input type="text" class="txt" placeholder="请输入搜索产品的名称，关键词" />
            <div class="select2 fr bdccc pr">
                <h2 s-data="0">
                    产品搜索
                </h2>
                <ul class="select2-nav bdccc">
                    <li><a href="#" s-data="1">我的发布</a> </li>
                    <li><a href="#" s-data="2">我的评审</a> </li>
                    <li><a href="#" s-data="3">我的分享</a> </li>
                    <li><a href="#" s-data="4">我的订单</a> </li>
                    <li><a href="#" s-data="5">我的收藏</a> </li>
                    <li><a href="#" s-data="6">我的浏览</a> </li>
                </ul>
            </div>
        </div>
        <div class="search-button fl">
            <button class="btn-search" type="submit">
            </button>
        </div>
    </div>
    <!-- 搜索over -->
     <div class="home-main fl">
    <div class="collection-main">
        <h2 class="t">
            My Favorite Collage Design
        </h2>
        <div class="collection-select clearfix">
            <span class="fl">Collage Design Search </span>
            <!--
            <div class="select-box fl pr">
                <h3 s-data="0" id="s-data">
                    All</h3>
                <ul class="select-list">
                    <li><a href="#" s-data="1">Tweebaa Evaluating</a> </li>
                    <li><a href="#" s-data="2">Public Evaluating</a> </li>
                    <li><a href="#" s-data="3">Tweeaa Approving</a> </li>
                    <li><a href="#" s-data="4">Test-Sale</a> </li>
                    <li><a href="#" s-data="5">Buy Now</a> </li>
                    <li><a href="#" s-data="6">Failed</a> </li>
                </ul>
            </div>
            -->
            <span class="fl">Selected on</span>
            <input type="text" value="" class="time-text" id="txtBegTime">
            <span class="fl">To</span>
            <input type="text" value="" class="time-text" id="txtEndTime">
            <input type="submit" class="submit" value="Search" />
        </div>
        <table class="collection-list" id="tabCollection" >
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

            <div id="kkpager" style="float:right; padding-right:180px;">
           </div>     </div>
    </div>
    <%-- 分享弹出ydf--%>
   
        <div id="share-tck2" class="tck">
            <a href="#" class="closeBtn" title="Close"></a>
            <h2 class="t">
                <span>Share & Earn</span>
            </h2>
             <div class="box">
                <div class="sharebox clearfix my-dietu">
                    <span class="fl t ">Share to </span>
                    <div class="bdsharebuttonbox fl">
                        <% // include all share method  %>        
                        <!--#include file="../include/sharemethod.inc" -->
                    </div>                  
                   <a href="#" style="display:none;" class="share-media-set">Share Binding setting</a>
                </div>
                <div class="ps clearfix">
                    <span class="fr"><a href="#"></a></span><span class="fl">You will earn  <!--span id="sharePercent"></span-->commission when your friend makes a purchase from your shared link. </span>
                </div>
            </div>         
        </div>

    <script type="text/javascript">

        //关闭弹出框
        $('.closeBtn,.iagree').click(function (event) {
            var obj2 = $(this).parents(".tck")
            obj2.animate({
                top: "-500px"
            },
				300, function () {
				    obj2.parents(".greybox").hide()

				});
            return false;
        });
    </script>
    </form>
</body>
</html>
