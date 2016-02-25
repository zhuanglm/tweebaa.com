﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="prdReviewAll.aspx.cs" Inherits="TweebaaWebApp.Product.prdReviewAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Evaluate Tweebaa products: Have fun AND earn rewards
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
</script>
    <link href="../Css/multiSelect.css" rel="stylesheet" type="text/css" />
    <script src="../MethodJs/SearchByCate.js" type="text/javascript"></script>
    <script src="../MethodJs/multiSelect.js" type="text/javascript"></script>
   <%-- <script src="../Js/qtab.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
   <%-- <link rel="stylesheet" href="../Css/selectCss.css" />--%>
    <link href="../Css/submit.css" rel="stylesheet" type="text/css" />
     <link href="../Css/shareBox.css" rel="stylesheet" type="text/css" />
    <script src="../Js/jquery.placeholder.js" type="text/javascript"></script>
   <%-- <script type="text/javascript" src="../Js/selectNav.js"></script>--%>
    <script src="../MethodJs/share.js" type="text/javascript"></script>
    <%--  <script src="../MethodJs/favorite.js" type="text/javascript"></script>--%>
    <script src="../MethodJs/prdReview.js" type="text/javascript"></script>
    <!--script src="../MethodJs/shareToSocialNetwork.js" type="text/javascript"></script-->
    <style>
        .
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

    <% // include google share  %>
    <!--#include file="../include/googleshare.inc" -->


<div class="list-banner ps-all" >
<ul><li><img src="../images/evaluate-banner.jpg" width="295" height="129" alt=""/></li>
<li class="p1">Your opinion matters to Tweebaa...</li><li class="p2">Earn cash and points for evaluating new products!</li></ul>
</div>
    <!-- select 筛选 -->
    <div class="w964">
    <div id="selectnav" class="clearfix fl">

         <div class="select1 fl pr bdccc" >

                <h1 onmouseover="ShowFocusCate(true);">By Focus</h1>
                    <div class="multiselect" id="chkBoxList" style="display:none" onmouseout="ShowFocusCate(false);"  onmouseover="ShowFocusCate(true);" >
                        <label><input type="checkbox" name="option[]" value="1" />Twee-Tech Products (Electronics & Gadgets)</label>
                        <label><input type="checkbox" name="option[]" value="2" />Aha! Products (Daily Problem Solvers)</label>
                        <label><input type="checkbox" name="option[]" value="3" />Novel-twee (Unique products to evoke smiles)</label>
                        <label><input type="checkbox" name="option[]" value="4" />Un-Breathable (Prices that take your breath away)</label>
                    </div>
           </div></div>

             <div class="clearfix choosecat">
    
            <div class=" select1 fl pr">
                <h1>By Category</h1>
            </div>
            <table class="jackaddnew" border="0" cellspacing="0" cellpadding="0"> 
                <tbody><tr style=" margin-bottom:20px;"> 
                        
                    <td>
                    <div class="clearfix product-categories">
                        <div class="selectBox pr fl">
                            <select name="" class="tag_select" id="prdType1">
                            </select>
                        </div>
                        <div class="selectBox pr fl">
                            <select name="" class="tag_select" id="prdType2">
                            </select>
                        </div>
                        <div class="selectBox pr fl">
                            <select name="" class="tag_select" id="prdType3">
                            </select>
                        </div>
                    </div>
                </td></tr>
              </tbody>
           </table>
    </div>
       
    </div>
    <!-- select 筛选 -->
    <!-- 筛选显示 -->
    <div class="w964">
 
        <div class="select-show clearfix tc" style="display:none;">
            <span class="first"><a href="prdReviewAll.aspx" class="first on">All</a> </span>
            <span style="width: 139px;"><a href="prdReviewStep1.aspx?step=1">Public Evaluating</a>
            </span><span style="width: 169px;"><a href="prdReviewStep2.aspx?step=4">Tweeebaa Evaluating</a>
            </span><span class="last"><a href="prdReviewStep3.aspx?step=5" class="last">Renew</a>
            </span>
        </div>
    </div>
    <div class="w964">
        <div class="result-select fl">				
			<span class="i-want-design" id="searchResult"></span>
		</div> 
    </div>
    <!-- 筛选显示 -->
    <!-- 筛选排序 -->
    <div class="w964">
    <div id="selectnav" class="clearfix">

   
         <!--   <div class="select1 fl pr bdccc">
                <h1>
                    By Category</h1>
                <div class="select1-nav bdccc">
                    <em class="sjx"></em>
                    <ul id="ulCate">
                    </ul>
                </div>
            </div>-->
           
            <div class="select-search bdccc fl" >
                <input type="text" class="txt" placeholder="Please search by product name or keywords"
                    id="txtPrdname"  />
                <div class="select2 fr bdccc pr" style="display:none;">
                    <h2 s-data="0">
                        By Category
                    </h2>
                    <ul class="select2-nav bdccc">
                        <li><a href="#" s-data="1">宠物用品</a> </li>
                        <li><a href="#" s-data="2">园艺用品</a> </li>
                        <li><a href="#" s-data="3">厨房收纳</a> </li>
                        <li><a href="#" s-data="4">居家日用</a> </li>
                        <li><a href="#" s-data="5">科技产品</a> </li>
                        <li><a href="#" s-data="6">户外探险</a> </li>
                        <li><a href="#" s-data="7">运动健身</a> </li>
                        <li><a href="#" s-data="8">节日商品</a> </li>
                    </ul>
                </div>
            </div> 
            <div class="search-button fl">
                <button class="btn-search" type="submit" onclick="serch()">
                </button>
            </div>
                   <div class="select-sort clearfix">
            <div class="sort-row fr pr">
                <h3 class="bdccc" sort-data="0">
                    Sort By
                </h3>
                <ul>
                    <li><a href="#" sort-data="1" onclick="orderBy(this)">By Ranking</a> </li>
                    <li><a href="#" sort-data="2" onclick="orderBy(this)">By Time</a> </li>
                    <li><a href="#" sort-data="3" onclick="orderBy(this)">By Price</a> </li>
                    <li><a href="#" sort-data="4" onclick="orderBy(this)">By Name</a> </li>
                    <!--li><a href="#" sort-data="3" onclick="orderBy(this)">By Evaluations</a> </li>
                    <li><a href="#" sort-data="4" onclick="orderBy(this)">By Clicks</a> </li-->
                </ul>
            </div>
        </div>
        </div>
 
    </div>
    <!-- 筛选排序 -->
    <!-- 列表	 -->
    <div class="w964" id="mainsrp-itemlist">
        <div class="m-itemlist">
            <div class="items clearfix">
            </div>
            <div class="down-more tc">
                <a href="#" id="down-more">View More</a>
            </div>
        </div>
    </div>
    <!-- 浮动在线咨询 -->
   <%-- <div id="floatALink" style="font-size:10px;">
        <a href="#" class="zxzz">Online<br>
            Help</a> <a href="#" id="gotoTop">Back<br>
                to Top</a>
    </div>--%>
    <!-- 浮动在线咨询 -->
    <!-- 评审失败弹出框 -->
    <div class="greybox">
        <div id="tck3" class="tck">
            <div class="pr">
                <a href="#" class="closeBtn" title="Close"></a>
                <h5>
                    <strong>Solution</strong></h5>
                <div class="box">
                    <textarea name="" id="" cols="25" rows="7" placeholder="Please provide your solution target to the failure evaluation reason"></textarea>
                    <div>
                        <a href="#" class="iagree fr">Submit</a>
                        <p class="fl">
                            If you have not complete your member profile, please includes your contact information.
                            Tweebaa will contact you after your submission. Thank you
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- 分享弹出ydf--%>
     <%--<div class="greybox">
        <div id="tck4" class="tck">
            <div class="pr">
                <a href="#" class="closeBtn" title="Close"></a>
                <h5>
                    <strong>Share</strong></h5>
                <div class="box" style="text-align: center;">
                    <a target="_blank"  id="share1" href="javascript:void(0)"><img src="../Images/flat-circles_03s.png" alt="facebook" /> </a> &nbsp; &nbsp; &nbsp; &nbsp;
                    <a target="_blank"  id="share2" href="javascript:void(0)"><img src="../Images/flat-circles_05s.png" alt="twitter" /> </a> &nbsp; &nbsp; &nbsp; &nbsp;
                    <a target="_blank"  id="share3" href="javascript:void(0)"><img src="../Images/flat-circles_13s.png" alt="google" /> </a> &nbsp; &nbsp; &nbsp; &nbsp;
                                  
                    <div>
                     
                    </div>
                </div>
            </div>
        </div>
    </div>--%>

     <div class="greybox">
        <div id="share-tck2" class="tck">
            <a href="#" class="closeBtn" title="Close"></a>
            <h2 class="t">
                <span>Share</span>
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
                    <span class="fr"><a href="#"></a></span><span class="fl">Invite your friends to support this product by taking a short survey.</span>
                </div>
            </div>         
        </div>
    </div>   

    <%-- 收藏弹出ydf--%>
    <div class="greybox">
        <div id="tck5" class="tck">
            <div class="pr">
                <a href="#" class="closeBtn" title="Close"></a>
                <h5>
                    <strong>Favorite</strong></h5>
                <div class="box" style="text-align: center;">
                    <div>
                        <label id="labfav" style="font-weight: bolder; font-size: 16px;">
                        </label>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!-- evaluate landing page 弹出框 -->
<div class="popbox" style="display:<%=_popbox%>">
<div class="tcksnow">
<a href="#" class="closeBtn" title="Close"></a>
<div class="thalfc">
<ul><li class="cr"><img src="../images/Layer_247-3.png" width="49" height="50" alt=""></li>
<li class="c1 e">EVALUATE
</li>
<li class="c2">Evaluators complete simple, 5-question surveys to help identify new products for the Tweebaa Shop. <br> Evaluators assist in the growth and popularity of products, with potential to earn commissions!</li>
</ul>
</div>
<div class="tanmain clearfix">
<div class="lanleft l">
<ul><li class="pb1">Evaluators can earn commissions, free gifts and reward points.</li>
<li> <a href="../College/EvaluateZone.aspx" class="btng" >Learn more about evaluating ></a></li>
<li> <a href="../College/EvaluateZone.aspx?cate=example" class="btng" >See an example evaluation ></a></li>
<li> <a href="../College/EarnWithTweebaa.aspx" class="every"></a></li>
</ul>
</div>
<div class="lanright">
<ul><li class="btme eval" onclick="hidePopup()" style="cursor:pointer;">Start Evaluating</li></ul>
<li class="eval-man"></li>
<li class="sltxt e">The Evaluator</li>
<li class="stxt">
Introspective & practical.<br/>
Evaluators share insights and<br/>opinions on new products.<br/><br/><br/>
Do not show this message again.<input type="checkbox" name="cbCheck" onclick="hidePopup();SavePopupCookie('EvaluatorsPopup')" /></li>
</div>
</div>
</div>



</div>


</div>
    <script type="text/javascript">
        //表单提示
        $('input, textarea').placeholder();
        //筛选排序
        $(".sort-row").mouseenter(function (event) {
            $(this).find('ul').show();
        }).mouseleave(function (event) {
            $(this).find('ul').hide();
        });
        $(".select-sort").find("a").click(function () {
            $(this).parent("li").addClass('on').siblings('li').removeClass('on').parent("ul").hide();
            $(".select-sort > div > h3").attr('sort-data', $(this).attr('sort-data')).text($(this).text())
        })
        //筛选显示 
        // $(".select-show").find("a").click(function(event) {
        // 	$(".select-show").find("a").removeClass('on')
        // 	$(this).addClass('on')
        // });

        //显示 收藏和分享

        $("#mainsrp-itemlist .pic-box").live('mouseenter', function (event) {
            $(this).find(".floatDiv").stop().animate({ top: 0 }, 100)
        }).live('mouseleave', function (event) {
            $(this).find(".floatDiv").stop().animate({ top: "-110px" }, 100)
        });

        $("#mainsrp-itemlist .box").live('mouseenter', function (event) {
            $(this).addClass('hover')
        }).live('mouseleave', function (event) {
            $(this).removeClass('hover')
        });

        //我有办法弹出框
        $(".i-have-way").live('click', function (event) {
            var objClick = $(this)
            $("#tck3").parents(".greybox").show()
            $("#tck3").animate({ top: "2%" }, 300)
            return false;
        });

        //分享弹出框ydf
       // $(".share").live('click', function (event) {
            //            var objClick = $(this)
            //            alert(objClick.html);
            //            $("#tck4").parents(".greybox").show()
            //            $("#tck4").animate({ top: "2%" }, 300)
            //            return false;
      //  });

        //Close弹出框
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

        //snow加landingpage
        $(".closeBtn").click(function () {
            $(this).parents(".popbox").hide();
            return false;
        })

        //隐藏弹出 框
        function hidePopup() {
            $(".popbox").hide();
        }

    </script>
    
</asp:Content>
