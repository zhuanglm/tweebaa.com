<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="prdSale.aspx.cs" Inherits="TweebaaWebApp.Product.prdSale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Shop Tweebaa for unique products and great prices, and you can earn
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="../Css/buyall.css" />
     <link rel="stylesheet" href="../Css/submit.css" />
    <link href="../Css/shareBox.css" rel="stylesheet" type="text/css" />
    <link href="../Css/multiSelect.css" rel="stylesheet" type="text/css" />
    <script src="../MethodJs/multiSelect.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
    <script src="../MethodJs/SearchByCate.js" type="text/javascript"></script>
    <script src="../MethodJs/prdSale.js" type="text/javascript"></script>
    <script src="../MethodJs/share.js" type="text/javascript"></script>
    <script src="../MethodJs/favorite.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <% // include google share  %>
    <!--#include file="../include/googleshare.inc" -->

    <input type="hidden" id="hidpersent" value="<%=_persent %>" />
    <input type="hidden" id="hiduserid" value="<%=_userid %>" />
<div class="list-banner buy-all">
	  <ul><li><img src="../images/shop-banner.jpg" width="295" height="129" alt=""/></li>
     <li class="p1"> The world is your store</li><li class="p2">Shop on Tweebaa to find amazing products at great prices!</li></ul>
</div>


      <!-- 筛选显示 -->
    <div class="w964">
   
        <div class="select-show clearfix tc">
            <span class="first"><a href="prdSaleAll.aspx" class="first ">All</a> </span>
            <span><a href="prdPreSale.aspx?step=2" >Limited Time</a> </span>
            <span class="last"><a href="prdSale.aspx?step=3" class="last on">Buy Now</a> </span>
         <div class="result-select fr" >

                <a href="#" class="i-want-wholesale">Wholesale Inquires</a>
            </div>
                  
        </div>
       

    </div>
    <!-- 筛选显示 -->
 
    <!-- select 筛选 -->
    <div class="w964">
        <div id="selectnav" class="clearfix fl">
          
            <div class="select1 fl pr bdccc " >
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
                <h1>
                    By Category</h1>
             
            </div>
            <table class="jackaddnew" border="0" cellspacing="0" cellpadding="0"> 
                      <tbody><tr style=" margin-bottom:20px;"> 
                        
                         <td>
                            <div class="clearfix product-categories">
                                <div class="selectBox pr fl">
                                    <select name="" class="tag_select" id="prdType1">
                                    <option value="-1">--Please select--</option><option value="1608ac1b-786a-4596-9dee-04fc45131332">Electronics &amp; Computers</option><option value="3ee6a6a4-933a-42ba-9c53-07f6aee27ed2">Fashion</option><option value="4036d9bf-f178-45bb-94f0-1693923ae9b5">Sports &amp; Outdoors</option><option value="b741b65a-4a64-4c8a-87b9-1b8857064a5b">EDmund 1</option><option value="f0ad0f37-cec0-4629-9c11-43044ca82f2a">Jack Test cate 1</option><option value="b984bda6-a0a7-4cd2-9edd-6d1b33efc3ad">Automotive.</option><option value="0d0dc9cd-a99a-4918-abaf-7bc0e8ee2b04">xx</option><option value="1382d416-6e2d-4708-8557-7f226edbdc13"> Kitchen &amp; Dining</option><option value="28c1292b-934f-4d99-a0e8-8aff3da85b64">XXYX 1</option><option value="c781386b-dbd9-4257-9eb6-8d74ed61a9c1">Health &amp; Beauty</option><option value="1f728092-0771-431d-81b2-a9b7d3dde7fe">Pet Supplies</option><option value="1e12e85a-f86c-4243-8446-c5f33b19e454">Home &amp; Garden</option><option value="479cea99-de6c-47b8-8eb3-d362551c9de1">yy</option><option value="7dee69e4-6103-4e16-a0cc-fb065473183d">Office Products</option></select>
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
                        
                        </tbody></table> 

       </div> </div>
    </div>
    <!-- select 筛选 -->

    <!-- 筛选排序 -->
    <div class="w964">
    
        <% // search result %>
        <div class="result-select fl">				
			<span class="i-want-design" id="searchResult"></span>
		</div> 
    <div id="selectnav" class="clearfix">
   <div class="select-search bdccc fl">
                <input type="text" class="txt" placeholder="Please search by product name or keywords"
                    id="txtPrdname" />
                <div class="select2 fr bdccc pr" style="display: none;">
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
    </div></div>
    <!-- 筛选排序 -->
    <!-- 列表	 -->
    <div class="w964 buy-page" id="mainsrp-itemlist">
        <div class="m-itemlist">
            <div class="items clearfix">
              
            </div>
            <div class="down-more tc">
                <a href="#" id="down-more">View More</a>
            </div>
        </div>
    </div>

    <!-- 评审失败弹出框 -->
    <div class="greybox">
        <div id="tck3" class="tck">
            <div class="pr">
                <a href="#" class="closeBtn" title="Close"></a>
                <h5>
                    <strong>I have solution</strong></h5>
                <div class="box">
                    <textarea name="" id="" cols="25" rows="7" placeholder="Please provide your solution target to the evaluation reason"></textarea>
                    <div>
                        <a href="#" class="iagree fr">Submit</a>
                        <p class="fl">
                            If you have not complete your member profile, please includes your contact information. Tweebaa will contact you after your submission. Thank you.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%-- 分享弹出ydf--%>
     <div class="greybox">
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
                    <span class="fr"><a href="#"></a></span><span class="fl">You will earn <span id="sharePercent"></span> comission when your friend  makes a purchase from your shared link. </span>
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
    <script type="text/javascript">
        //表单提示
        $('input, textarea').placeholder();
        //表单美化
        $('.chklist').hcheckbox();


        //筛选排序
        $(".sort-row").mouseenter(function (event) {
            $(this).find('ul').show();
        }).mouseleave(function (event) {
            $(this).find('ul').hide();
        });
        $(".sort-row").find("a").click(function () {
            $(this).parent("li").addClass('on').siblings('li').removeClass('on').parent("ul").hide();
            $(".sort-row > h3").attr('sort-data', $(this).attr('sort-data')).text($(this).text())
        })


        //显示 收藏和分享

        $("#mainsrp-itemlist .box").live('mouseenter', function (event) {
            $(this).addClass('hover')
            $(this).find(".floatDiv").stop().animate({ top: 0 }, 100)
        }).live('mouseleave', function (event) {
            $(this).removeClass('hover')
            $(this).find(".floatDiv").stop().animate({ top: "-110px" }, 100)
        });

		
    </script>
    
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
</asp:Content>
