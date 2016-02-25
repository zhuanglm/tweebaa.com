<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="homeSupply.aspx.cs"
    Inherits="TweebaaWebApp.Home.homeSupply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link rel="stylesheet" href="../Css/index.css" />
	<link rel="stylesheet" href="../Css/home.css?v=1" />
    <link href="../Css/shareBox.css" rel="stylesheet" type="text/css" />
	<script src="../Js/jquery.min.js" type="text/javascript"></script>
	<script src="../Js/jquery.placeholder.js" type="text/javascript"></script>
	<script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
	<script src="../Js/selectNav.js" type="text/javascript"></script>
	<script src="../Js/homePage.js" type="text/javascript"></script>
	<link rel="stylesheet" href="../Css/selectCss.css" />
	<script src="../Js/selectCss.js" type="text/javascript"></script>
	<script type="text/javascript" src="../Js/public.js"></script>
    <script src="../MethodJs/homeSupply.js" type="text/javascript"></script>
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
     <div class="home-main fl">
    <div class="collection-main">
        <h2 class="t">
           My Submissions
        </h2>
        <p>We are relying on Submitters (like YOU) to tell us about emerging items, useful gadgets and must-have consumer products.  If your product advances to the Twebaa Shop, you will earn a 

commission on all sales of the product for life! <a class="learn" href="../College/SubmitZone.aspx?page=submit-zone" target="_blank">Learn more</a> </p>
        <div class="collection-select clearfix" style="width:100%">
            <span class="fl">Product Status </span>
            <div class="select-box fl pr" >
                <h3 s-data="0" id="s-data">
                    All</h3>
                <ul class="select-list">
                               
                    <li><a href="#" onclick="SetState(-1)">All</a> </li>
                    <li><a href="#" onclick="SetState(0)">Draft</a> </li>
                    <li><a href="#" onclick="SetState(11)">Pending Approval</a> </li>
                    <li><a href="#" onclick="SetState(1)">Public Evaluating</a> </li>
                    <li><a href="#" onclick="SetState(4)">Tweebaa Evaluating</a> </li>    
                    <li><a href="#" onclick="SetState(2)">Test-Sale</a> </li>
                    <li><a href="#" onclick="SetState(3)">Buy Now</a> </li>
                    <li><a href="#" onclick="SetState(7)">Test-Sale Failed</a> </li><%--预售失败--%>
                </ul>
            </div>
           
            <span class="fl">Submitted on&nbsp;</span>
            <input type="text" value="" class="time-text" id="txtBegTime" onclick="WdatePicker({ lang: 'en' })" />
            <span class="fl">To</span>
            <input type="text" value="" class="time-text" id="txtEndTime" onclick="WdatePicker({ lang: 'en' })" />
            <input  type="button" class="submit" value="Search" onclick="DoSearch()" />
        </div>
      
        <table class="collection-list" id="tabData" style=" width:760px;" >
            <tr>
                <th class="pro-name"><%--colspan="2"--%>
                    Product
                </th>
                <th class="state">
                    Status
                </th>
                <th class="price" style="display:none;">
                    Income
                </th>
                <th class="operation">
                    Action
                </th>
            </tr>
            <%--  <tr>
                <td>
                    <a href="#" class="imglink fl">
                        <img src="images/102x107.jpg"  />
                    </a>
                </td>
                <td>
                    <div class="pro-title fl">
                        <a href="#">双肩包女韩版潮 PU钢琴双肩包女学院风可爱卡通书包休闲学生书包</a>
                        <p>
                            收藏时间：2014-08-01
                        </p>
                    </div>
                </td>
                <td>
                    <div class="state-ing">
                        大众评审中
                    </div>
                    <div class="jdt">
                        <span style="width: 50%;"></span>
                    </div>
                    <div class="participant">
                        支持人数 : 100/300
                    </div>
                </td>
                <td>
                    <span class="no-return">暂无收益<br />
                        继续努力 </span>
                </td>
                <td>
                    <div class="btn-group">
                        <a href="#" class="share">分享</a> <a href="#">编辑</a> <a href="#">删除</a>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="#" class="imglink fl">
                        <img src="images/102x107.jpg"  />
                    </a>
                </td>
                <td>
                    <div class="pro-title fl">
                        <a href="#">双肩包女韩版潮 PU钢琴双肩包女学院风可爱卡通书包休闲学生书包</a>
                        <p>
                            收藏时间：2014-08-01
                        </p>
                    </div>
                </td>
                <td>
                    <div class="state-ing">
                        大众评审中
                    </div>
                    <div class="jdt">
                        <span style="width: 50%;"></span>
                    </div>
                    <div class="participant">
                        已支持金额：30000
                        <br />
                        剩余时间：999小时
                    </div>
                </td>
                <td>
                    <span class="no-return">暂无收益<br />
                        继续努力 </span>
                </td>
                <td>
                    <div class="btn-group">
                        <a href="#" class="share">有偿分享</a>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="#" class="imglink fl">
                        <img src="images/102x107.jpg"  />
                    </a>
                </td>
                <td>
                    <div class="pro-title fl">
                        <a href="#">双肩包女韩版潮 PU钢琴双肩包女学院风可爱卡通书包休闲学生书包</a>
                        <p>
                            收藏时间：2014-08-01
                        </p>
                    </div>
                </td>
                <td>
                    <div class="state-ing">
                        销售中
                    </div>
                    <div class="participant">
                        销售总额：10005元
                        <br />
                        已售数量：2000个
                    </div>
                </td>
                <td>
                    <span class="pre-sale-price">$<strong>180.00</strong></span>
                </td>
                <td>
                    <div class="btn-group">
                        <a href="#" class="share">有偿分享</a>
                    </div>
                </td>
            </tr>--%>
        </table>
        
       <div id="divNoData" style="display:none" >No product found! </div>
       <div id="kkpager" style="  float:right; padding-right:150px;"></div><br />

    </div></div>

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
