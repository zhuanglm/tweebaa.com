<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TweebaaWebApp.Home.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Center - Every earns</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Manage/layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Css/index.css?v=1" />
    <link rel="stylesheet" href="../Css/home.css?v=1" />
    <script src="../Js/jquery.min.js" type="text/javascript"></script>
    <script src="../Js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
    <script src="../Js/selectNav.js?v=<%=_sCurVer%>" type="text/javascript"></script>
    <script src="../Js/homePage.js?v=<%=_sCurVer%>" type="text/javascript"></script>
    <link rel="stylesheet" href="../Css/selectCss.css?v=1" />
    <script src="../Js/selectCss.js?v=<%=_sCurVer%>" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/public.js?v=<%=_sCurVer%>"></script>
    <link href="../Manage/layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <script src="../Manage/layer/layer.min.js" type="text/javascript"></script>
     <script src="../MethodJs/logion.js?v=<%=_sCurVer%>" type="text/javascript"></script>
</head>
<body>
    <form runat="server" id="Form1">
    <input type="button" id="test" value="test" style="display: none;" />
    <div class="top">
        <div class="w clearfix">
            <div class="fr r-nav">
                <div class="tr fr">
                    <%--<span class="fl"><a href="#" class="language"></a>  <a href="../index.aspx" class="language">
                        English</a> </span>--%>
                    <!-- 登陆前 -->
                    <span id="spanLogion1" runat="server"><a href="../User/login.aspx" class="login">Login</a>|<a
                        href="../User/register.aspx" class="reg">Register</a></span>
                    <!-- 登陆后 -->
                    <!-- 登陆后 -->
                    <span id="spanLogion2" runat="server" class="login-ok pr font1"><b>Hello
                        <label id="userName" onclick="GetMenu('Home2.aspx')" runat="server">
                        </label>
                    </b><span class="login-lv2">
                        <a href="../Home/Index.aspx?page=home2">My Account</a> 
                        <!--a href="#">My Income</a> 
                        <a href="../Home/Index.aspx?page=homeorder">My Order</a> 
                        <a href="../Home/Index.aspx?page=homeCollection">My Favorites</a> 
                        <a href="../Home/Index.aspx?page=homeShare">My Shares</a--> 
                        <a href="#" onclick="LogionOut()">Log Out</a>
                        <!--a href="../User/login.aspx">Change Account</a-->
                        </span></span>
                    <!-- 登陆后 -->
                   <%-- <span class="msn pr fl"><b class="dxx">100</b> <span class="msn-lv2"><a href="#"><font>
                        30</font>Unread Message</a> <a href="#"><font>4</font>Unread Message</a> </span>
                    </span>--%>
                    <div class="car pr fl" id="miniCar">
                        <a href="../Product/shopCart.aspx"> <b class="car-num"><asp:Label ID="labCartCount" runat="server"></asp:Label></b></a>
                        <div style="display:none;">
                        <div class="car-lv2">
                            <dl>
                                <dd>
                                    <a href="#" class="imglink fl">
                                        <img src="../Images/50x50.jpg"  />
                                    </a>
                                    <div class="r-con fr">
                                        <a href="#">秋冬新款真皮潮流单鞋 </a>
                                        <p>
                                            颜色：黑色 尺码：43
                                        </p>
                                        <b>$185.00元 × 4 </b>
                                    </div>
                                </dd>
                                <dd>
                                    <a href="#" class="imglink fl">
                                        <img src="../Images/50x50.jpg"  />
                                    </a>
                                    <div class="r-con fr">
                                        <a href="#">秋冬新款真皮潮流单鞋 </a>
                                        <p>
                                            颜色：黑色 尺码：43
                                        </p>
                                        <b>$185.00元 × 4 </b>
                                    </div>
                                </dd>
                                <dd>
                                    <a href="#" class="imglink fl">
                                        <img src="images/50x50.jpg"  />
                                    </a>
                                    <div class="r-con fr">
                                        <a href="#">秋冬新款真皮潮流单鞋 </a>
                                        <p>
                                            颜色：黑色 尺码：43
                                        </p>
                                        <b>$185.00元 × 4 </b>
                                    </div>
                                </dd>
                                <dd>
                                    <a href="#" class="imglink fl">
                                        <img src="images/50x50.jpg"  />
                                    </a>
                                    <div class="r-con fr">
                                        <a href="#">秋冬新款真皮潮流单鞋 </a>
                                        <p>
                                            颜色：黑色 尺码：43
                                        </p>
                                        <b>$185.00元 × 4 </b>
                                    </div>
                                </dd>
                            </dl>
                            <div class="price-total">
                                <span>总计金额 : $<b>528.39</b> </span><a href="#" class="settlement">去结算</a>
                            </div>
                            <s></s>
                        </div>
                            </div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <ul>
                    <li id="h1"><a href="../index.aspx">Home</a> </li>
                    <li id="h2"><a href="../Product/issueWelcome.aspx" id="hrfSubmit" runat="server">Submit</a>
                        <div class="lv2 clearfix">
                            <div class="btnbox">
                                <a href="../Product/issueWelcome.aspx">Submit</a>
                            </div>
                            <dl>
                                <dd>
                                    <a href="../College/SubmitZone.aspx">Learn to Submit</a>
                                </dd>
                                <dd>
                                    <a href="../Product/issueWelcome.aspx">Submit Now</a>
                                </dd>                                
                            </dl>
                        </div>
                    </li>
                    <li id="h3"><a href="../Product/prdReviewAll.aspx">Evaluate</a>
                        <div class="lv2 clearfix">
                            <div class="btnbox">
                                <a href="../Product/prdReviewAll.aspx">Evaluate</a>
                            </div>
                            <dl>
                                <dd>
                                    <a href="../College/EvaluateZone.aspx">Learn to Evaluate</a>
                                </dd>
                                <dd>
                                    <a href="../Product/prdReviewAll.aspx">Evaluate Now</a>
                                </dd>                               
                            </dl>
                        </div>
                    </li>
                    <li id="h5"><a href="../Product/prdSaleAll.aspx">Shop</a>
                        <div class="lv2 clearfix"  style="width:300px;" >
                            <div class="btnbox">
                                <a href="../Product/prdSaleAll.aspx">Shop Now </a>
                            </div>
                            <dl style="width:180px;">
                                <dd>
                                    <a href="">About Tweebaa products</a>
                                </dd>
                              
                                <dd>
                                    <a href="../College/ShoppingRewardPoints.aspx">Shopping Reward Points</a>
                                </dd>
                                <dd>
                                    <a href="../Product/prdSaleAll.aspx">Shop Now </a>
                                </dd>
                            </dl>
                        </div>
                    </li>
                    <li id="h4" style="margin-right: 15px;"><a href="../Product/prdSingleShare.aspx">Share</a>
                        <div class="lv2 clearfix"  style="width:280px;" >
                            <div class="btnbox">
                                <a href="../Product/prdSingleShare.aspx">Share Product </a>
                            </div>
                            <dl  style="width:170px;" >
                                <dd>
                                    <a href="../College/College.aspx">Learn to Share</a>
                                </dd>
                                <dd>
                                    <a href="">Express with Collage</a>
                                </dd>
                                <dd>
                                    <a href="../Product/prdSingleShare.aspx">Search items to Share</a>
                                </dd>
                            </dl>
                        </div>
                    </li>
                    <!--	   <li id="h6"><a href="../Product/prdReviewStep2.aspx?step=supply" id="hrfSupply" runat="server">
                        Supply</a>
                        <div class="lv2 clearfix">
                            <div class="btnbox">
                                <a href="../Product/prdReviewStep2.aspx?step=supply">Supply </a>
                            </div>
                            <dl>
                                <dd>
                                    <a href="../Product/prdReviewStep2.aspx?step=supply">Product Supply</a>
                                </dd>
                                <dd>
                                    <a href="../College/College.aspx#nav-supply">Benefits</a>
                                </dd>
                                <dd>
                                    <a href="../College/College.aspx#nav-supply">More Details</a>
                                </dd>
                            </dl>
                        </div>
                    </li> -->
                    <li id="h7"><a href="../College/College.aspx">Education</a>
                       <%-- <div class="lv2 clearfix" >
                            <div class="btnbox">
                                <a href="../College/College.aspx">Model </a>
                            </div>
                            <dl>
                                <dd>
                                    <a href="../College/College.aspx#nav1">How Tweebaa works?</a>
                                </dd>
                                <dd>
                                    <a href="../College/College.aspx#nav2">How to earn income?</a>
                                </dd>
                                <dd>
                                    <a href="../College/College.aspx#nav3">Tweebaa Features</a>
                                </dd>
                                <dd>
                                    <a href="../College/College.aspx#nav4">Reward Points System</a>
                                </dd>
                                <dd>
                                    <a href="../College/College.aspx#nav-fa">Submit Details</a>
                                </dd>
                                <dd>
                                    <a href="../College/College.aspx#nav-ping">Evaluate Details</a>
                                </dd>
                                <dd>
                                    <a href="../College/College.aspx#nav-share">Share Details</a>
                                </dd>
                                <dd>
                                    <a href="../College/College.aspx#nav-supply">Supply Details</a>
                                </dd>
                                <dd>
                                    <a href="../College/College.aspx#nav-shop">Shop Details</a>
                                </dd>
                                <dd>
                                    <a href="../College/College.aspx#nav-word">Glossary</a>
                                </dd>
                                <dd>
                                    <a href="../College/College.aspx#nav-faqq">FAQ</a>
                                </dd>
                                <dd>
                                    <a href="../College/College.aspx#nav-ag">Terms of Use</a>
                                </dd>
                            </dl>
                        </div>--%>
                    </li>
                </ul>
            </div>
            <a href="../index.aspx" class="logo">
                <img src="../Images/logo2.png" alt="tweebaa" /></a>
        </div>
    </div>
    <!-- 用户中心首页banner -->
    <div class="home-banner">
        <div class="w967 clearfix">
            <div class="user-infor fl">
                <div class="user-lv fr">
                    <p style="margin-bottom:0px;">
                        Hi<strong>&nbsp;<label id="labUser2" runat="server"></label></strong></p>
                    <ul>
                        <li class="va clearfix">
                            <!-- a href="#" class="icon-lv fl"><img src="<%=_publishPic %>"  /></a--> 
                            <!--<span class="jdt fl">
                             commment out the color bars as it's not indicating the progress.<i></i></span>--><span
                                class="per">Submitter Level <% =_userPublishLevel.ToString() %></span> 
                        </li>
                        <li class="vb clearfix">
                            <!--a href="#" class="icon-lv fl"><img src="<%=_reviewPic %>"  /></a-->                           
                            <!--<span class="jdt fl"><i style="width: 75%;">
                            </i></span>--> <span class="per">Evaluator Level <% =_userReviewLevel.ToString() %></span>
                        </li>
                        <li class="vc clearfix">
                            <!--a href="#" class="icon-lv fl"><img src="<%=_sharePic %>"  /></a--> 
                            <!--<span class="jdt fl"><i style="width: 15%;">
                            </i></span>--> <span class="per fl">Sharer Level <% =_userShareLevel.ToString() %></span> 
                        </li>
                    </ul>
                </div>
                <a href="javascript:void(0);" class="head-portrait fl" onclick="GetMenu('HomePersonalData.aspx')">
                    <img src="<%=_userHeadPic %>"  width="84" height="84" />
                </a>
            </div>
            <div class="integral-profit fr" style="text-align: center; display:none;">
                <div class="integral fl" style="padding-left: 20px; width: 150px;">
                    My Points <strong>
                       </strong>
                </div>
                <div class="profit fl" style="padding-left: 20px; width: 150px;">
                    My Available Cash <strong>$</strong>
                </div>
                <a href="javascript:void(0)" class="qiandao fr" style="padding-left: 0px; width: 200px;"
                    onclick="qiandaoFuc()"><span>Daily sign in </span></a>
                <input type="hidden" id="hidQianDaoUserid" value="<%=_qiaoDaoUserid %>" />
                <script type="text/javascript">
                    function qiandaoFuc() {
                        var userid = $("#hidQianDaoUserid").val();
                        if (userid != "") {
                            var res = TweebaaWebApp.Home.Index.SaveQianDao(userid).value;
                            if (res == "error") {
                                alert("Sign in failed");
                            } else if (res == "Haved") {
                                alert("Sorry, you have already signed in today");
                            } else {
                                alert(res);
                            }
                        }
                    }
                </script>
            </div>

            <%--<div class="integral-profit fr">
                  <div class="profit fl">Available Cash<strong>$<asp:Label ID="labSumCash" runat="server"></asp:Label></strong> </div>
                  <div class="integral fl">Store Credits<strong><asp:Label ID="labSumShop" runat="server"></asp:Label></strong> </div>
                  <div class="partner fl" style="display:none;" >Member points <strong> <asp:Label ID="labSumPoit" runat="server"></asp:Label></strong> </div>
                  <div class="qiandao fl" style="display:none;" onclick="qiandaoFuc()"> </div>
             </div>--%>
	         
           <div class="integral-profit fr">
                <div class="profit fl">
                    Available Tweebucks<strong><asp:Label ID="labSumCash" runat="server"></asp:Label></strong>
                    <span class="bl"> Redemption Value $<asp:Label ID="labSumCash2" runat="server"></asp:Label> USD</span>
                </div>
                <div class="integral fl">
                    AVAILABLE SHOPPING REWARDS<strong><asp:Label ID="labSumShop" runat="server"></asp:Label></strong> 
                    <span class="bl">Redemption Value $<asp:Label ID="labSumShop2" runat="server"></asp:Label>
                        USD</span>
                </div>               
            </div>
         </div>
       </div>
     
    <!-- 用户中心内容 -->
    <div class="home-page">
        <div class="w967">
            <div class="wrap clearfix">
                <div class="home-side-nav fl">
                    <div class="item">
                        <h2>
                            <a href="javascript:void(0);" onclick="GetMenu('Home2.aspx')">My Account</a><i></i></h2>
                        <dl>
                            <dt><a href="javascript:void(0);">My Rewards</a></dt>
                            <dd id="HomeProfit">
                                <a href="javascript:void(0);" onclick="GetMenu('HomeProfit.aspx')">Commission Rewards</a>
                            </dd>
                            <dd id="HomeIntegral">
                                <a href="javascript:void(0);" onclick="GetMenu('HomeIntegral.aspx')">Reward Points</a>
                            </dd>
                            <dd id="HomeGiftReward">
                                <a href="javascript:void(0);" onclick="GetMenu('HomeGiftReward.aspx')">Gift Rewards</a>
                            </dd>
                        </dl>
                        <dl>
                            <dt><a href="javascript:void(0);">My Activity</a></dt>
                            <dd id="homeSupply">
                                <a href="javascript:void(0);" onclick="GetMenu('homeSupply.aspx')">My Submissions</a>
                            </dd>
                            <dd id="HomeReview">
                                <a href="javascript:void(0);" onclick="GetMenu('HomeReview.aspx')">My Evaluations</a>
                            </dd>
                            <dd id="HomeShare">
                                <a href="javascript:void(0);" onclick="GetMenu('HomeShare3.aspx')">My Shares</a>
                            </dd>
                        </dl>
                        <!--
                           <div class="home-myCar">
                            <a href="../product/shopCart.aspx">My Collage Designs</a>
                        </div>
                        -->
                         <dl>
                            <dt><a href="javascript:void(0);">My Favorites</a></dt>
                            <dd id="HomeCollection">
                                <a href="javascript:void(0);" onclick="GetMenu('HomeCollection.aspx')">My Favorite Products</a>
                            </dd>
                            <!--
                            <dd id="HomeCollageCollection">
                                <a href="javascript:void(0);" onclick="GetMenu('HomeCollageCollection.aspx')">Collage Designs</a>
                            </dd>
                            -->
                        </dl>
                        <div class="home-myCar">
                            <a href="../product/shopCart.aspx">My Orders</a>
                        </div>
                        <dl>
                            <dt><a href="#"></a></dt>
                            <dd id="HomeOrder">
                                <a href="javascript:void(0);" onclick="GetMenu('HomeOrder.aspx?state=all')">All Orders</a>
                            </dd>
                            <%--  <dd>
                                <a href="javascript:void(0);" onclick="GetMenu('HomeOrder.aspx?state=0')">待付款</a>
                            </dd>
                            <dd>
                                <a href="javascript:void(0);" onclick="GetMenu('HomeOrder.aspx?state=1')">待发货</a>
                            </dd>
                            <dd>
                                <a href="#">待评价</a>
                            </dd>--%>
                             <dd id="HomeOrderRefund">
                                <a href="javascript:void(0);" onclick="GetMenu('HomeOrderRefund.aspx?state=all')">Refund/Return</a>
                            </dd>
                        </dl>
                       
                        <dl style="display: none;">
                            <dt><a href="javascript:void(0);">Customer Service</a></dt>
                            <dd>
                                <a href="javascript:void(0);">投诉</a>
                            </dd>
                            <dd>
                                <a href="#">举报</a>
                            </dd>
                            <dd>
                                <a href="#">我的咨询</a>
                            </dd>
                        </dl>
                        <dl>
                            <dt><a href="#">My Account</a></dt>
                            <%--<dd>
                                <a href="javascript:void(0);" onclick="GetMenu('HomeMsn.aspx')">站内消息</a>
                            </dd>--%>
                            <dd id="HomePersonalData">
                                <a href="javascript:void(0);" onclick="GetMenu('HomePersonalData.aspx')">My account setting</a>
                            </dd>
                            <dd id="HomeSafe">
                                <a href="javascript:void(0);" onclick="GetMenu('HomeSafe.aspx')">Security setting</a>
                            </dd>
                            <dd style="display: none;">
                                <a href="javascript:void(0);" onclick="GetMenu('HomeMedia.aspx')">My social media accounts</a>
                            </dd>
                            <dd style="display: none;">
                                <a href="javascript:void(0);" onclick="GetMenu('PayBind.aspx')">My Payment Method(s)</a>
                            </dd>
                            <dd id="PayPalAccountBind">
                                <a href="javascript:void(0);" onclick="GetMenu('PayPalAccountBind.aspx')">Link cash account</a>
                            </dd>
                            <dd id="HomeAdress">
                                <a href="javascript:void(0);" onclick="GetMenu('HomeAdress.aspx')">My shipping address</a>
                            </dd>
                        </dl>
                    </div>

                  
                    <div class="item" id="divSupply" style="display:none">
                        <%--<h2>
                            <a href="#">Supplier Channel</a><i></i></h2>--%>
                        <dl>
                            <dt><a href="javascript:void(0)">My quotations</a></dt>
                            <dd id="SupplyCheckList">
                                <a href="javascript:void(0);" onclick="GetMenu('SupplyCheckList.aspx')">My profile</a>
                            </dd>

                            <dd>
                                <a href="/Product/prdReviewStep2.aspx?step=supply" target="_top">Go to supply</a>
                            </dd>
                            <dd>
                                <a href="javascript:void(0);" onclick="GetMenu('HomeShipOrder.aspx')">Purchase orders</a>
                            </dd>

                           <%-- -- this is the original comment
                             <dd> /Product/prdReviewStep2.aspx?step=supply
                                <a href="#">正在预售</a>
                            </dd>
                            <dd>
                                <a href="#">正在销售</a>
                            </dd>
                            <dd>
                                <a href="#">已下架</a>
                            </dd>--%>
                        </dl>
                    </div>
                </div>

                <div class="home-main fl">
                    <iframe src="Home2.aspx" marginheight="0" marginwidth="0" frameborder="0" scrolling="yes"
                        width="900" height="1000" id="iframepage" name="iframepage"></iframe>
                </div>
            </div>
        </div>
    </div>
    <!-- foot -->
    <div class="footer">
        <div class="w clearfix">
            <div class="box">
                <div class="clearfix">
                  <span class="fl"><a href="../College/AboutUs.aspx">About  Us</a>｜<a href="../College/ContactUs.aspx">Contact Us</a>｜<a href="/College/Privacy_Policy.aspx">Privacy Policy</a>｜<a href="/College/Genernal_Terms_ofUse.aspx">Terms
                            and Conditions</a>｜<a href="../College/College.aspx#nav-faqq">FAQ</a> </span>
                </div>
                <div class="clearfix p pr">
                    <p>
                        Copyright：Tweebaa（China）
                    </p>
                    <p>
                    </p>
                            <p class="gz">
                        Follow Us <a href="https://www.youtube.com/channel/UCFosscOme7N79CJAc_TmGTA/feed" target="_blank">
                            <img src="/Images/flat-circles_22.png" alt="Tweebaa at YouTube" width="25" height="25"/>
                        </a>
                        <a href="https://www.facebook.com/tweebaa" target="_blank">
                            <img src="../Images/wb25x25.png" width="25" height="25"  alt="https://www.facebook.com/tweebaa" />
                        </a>
                        <a href="https://twitter.com/tweebaa" target="_blank">
                            <img src="../Images/wx25x25.png" width="25" height="25"  alt="https://twitter.com/tweebaa" /></a>
                        <a href="https://www.google.com/+Tweebaa" target="_blank">
                            <img src="../Images/flat-circles_16.png" width="25" height="25" alt="https://www.google.com/+Tweebaa" /></a>
                        <a href="https://www.linkedin.com/company/tweebaa-inc-" target="_blank">
                            <img src="../Images/txwb25x25.png" width="25" height="25" alt="https://www.linkedin.com/company/tweebaa-inc-" />
                        </a>
                        <a href="https://instagram.com/tweebaa/" target="_blank"> 
                            <img src="../Images/share-instagram32x32.png" alt="https://instagram.com/tweebaa/" width="32" height="32" /></a>
                        <a href="https://pinterest.com/" target="_blank">
                            <img src="../Images/flat-circles_18.png" alt="https://pinterest.com/" width="25" height="25"/>
                        </a>
                        <a href="https://tweebaa.wordpress.com/" target="_blank">
                            <img src="../Images/flat-circles_20.png" alt="Tweebaa at wordpress" width="25" height="25" />
                        </a>
                    </p>
                    <div class="erweima" style="display: none;">
                        <img src="../images/erweima.png"  />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- 浮动在线咨询 
    <div id="floatALink">
        <a href="#" class="zxzz">Online<br />
            Inqiry</a> <a href="#" class="help">Help<br />
                Center</a>
    </div>
    <!-- 浮动在线咨询 -->
    <!-- iframe自适应 -->
    <script language="javascript" type="text/javascript">
        var oldDD="0";
        function dyniframesize(down) {
            var pTar = null;
            if (document.getElementById) {
                pTar = document.getElementById(down);
            }
            else {
                eval('pTar = ' + down + ';');
            }
            if (pTar && !window.opera) {
                //begin resizing iframe 
                pTar.style.display = "block"
                if (pTar.contentDocument && pTar.contentDocument.body.offsetHeight) {
                    //ns6 syntax 
                    pTar.height = pTar.contentDocument.body.offsetHeight + 20;
                    //pTar.width = pTar.contentDocument.body.scrollWidth + 20;
                }
                else if (pTar.Document && pTar.Document.body.scrollHeight) {
                    //ie5+ syntax 
                    pTar.height = pTar.Document.body.scrollHeight;
                    //pTar.width = pTar.Document.body.scrollWidth;
                }
            }
        }

        function iFrameHeight() {
            var ifm = document.getElementById("iframepage");
            var subWeb = document.frames ? document.frames["iframepage"].document :
            ifm.contentDocument;
            if (ifm != null && subWeb != null) {
                ifm.height = subWeb.body.scrollHeight;
            }

        }
        function GetMenu(pageUrl) {
            $("#iframepage").attr("src", pageUrl);
            //get the id of the DD
            var i = pageUrl.indexOf(".aspx");
            var ddID = pageUrl.substring(0, i);
            if (oldDD == "0") {
                oldDD = ddID;
            } else {
                $("#" + oldDD).removeClass("on");
                oldDD = ddID;
            }
            console.log("1111=" + oldDD);
            $("#" + ddID).addClass("on");

            window.parent.window.scrollTo(0, 0);  // scroll top top
        }

        $(document).ready(
            function () {
                var Request = new Object();
                Request = GetRequest();
                var page = Request["page"];
                if (page == "homeorder") {
                    $("#iframepage").attr("src", "HomeOrder.aspx");
                }
                else if (page == "address") {
                    $("#iframepage").attr("src", "HomeAdress.aspx");
                }
                else if (page == "homeSupply") {
                    $("#iframepage").attr("src", "homeSupply.aspx");
                }
                else if (page == "homeReview") {
                    $("#iframepage").attr("src", "HomeReview.aspx");
                }
                else if (page == "homeSubmit") {
                    $("#iframepage").attr("src", "homeSupply.aspx");
                }
                else if (page == "homeCollection") {
                    $("#iframepage").attr("src", "homeCollection.aspx");
                }
                else if (page == "homeProfit") {
                    $("#iframepage").attr("src", "homeProfit.aspx");
                }
                else if (page == "homeShare") {
                    $("#iframepage").attr("src", "homeShare3.aspx");
                }

                ShowSupplyDiv(<% =_userSupplyPermission %>);
            }
        );


        function ShowSupplyDiv(userSupplyPermission)
        {
            if (userSupplyPermission == 1) $("#divSupply").show();
            else $("#divSupply").hide();
        }


        //接收URL参数
        function GetRequest() {
            var url = location.search; //获取url中"?"符后的字串
            var theRequest = new Object();
            if (url.indexOf("?") != -1) {
                var str = url.substr(1);
                strs = str.split("&");
                for (var i = 0; i < strs.length; i++) {
                    theRequest[strs[i].split("=")[0]] = (strs[i].split("=")[1]);
                }
            }
            return theRequest;
        }
    </script>
    <script type="text/javascript">
        $('#test').on('click', function () {
            $.layer({
                type: 2,
                title: '推易吧收益协议',
                maxmin: true,
                shadeClose: true, //开启点击遮罩关闭层
                area: ['600px', '500px'],
                offset: ['100px', ''],
                iframe: { src: 'Agreement.aspx' }
            });
        });
    </script>
    </form>
</body>
</html>
