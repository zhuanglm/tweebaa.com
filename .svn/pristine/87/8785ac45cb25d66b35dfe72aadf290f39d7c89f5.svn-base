<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="prdSingleShare.aspx.cs" Inherits="TweebaaWebApp.Product.prdSingleShare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Share Tweebaa products:  Have fun AND earn rewards
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">   
    <link rel="stylesheet" href="../Css/shareall.css" />
    <link href="../Css/multiSelect.css" rel="stylesheet" type="text/css" />
     <link href="../Css/submit.css" rel="stylesheet" type="text/css" />
    <script src="../MethodJs/multiSelect.js" type="text/javascript"></script>
  <%--  <script src="../Js/jquery.min.js" type="text/javascript"></script>--%>
    <%--<script src="../Js/qtab.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
   <%-- <link rel="stylesheet" href="../Css/selectCss.css" />--%>
   <%-- <script src="../Js/jquery.placeholder.js" type="text/javascript"></script>--%>
  <%--  <script type="text/javascript" src="../Js/selectNav.js"></script>--%>
    <%--<script type="text/javascript" src="../Js/public.js"></script>--%>
    <!--script src="../MethodJs/prdCate.js" type="text/javascript"></script-->
    <script src="../MethodJs/SearchByCate.js" type="text/javascript"></script>
    <script src="../MethodJs/share.js" type="text/javascript"></script>
    <script src="../MethodJs/prdShare.js" type="text/javascript"></script>
    <!--script src="../MethodJs/shareToSocialNetwork.js" type="text/javascript"></script-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <% // include google share  %>
    <!--#include file="../include/googleshare.inc" -->
    <input type="hidden" id="hidpersent" value="<%=_persent %>" />
    <input type="hidden" id="hiduserid" value="<%=_userid %>" />
<div class="list-banner share-all">
	 <ul><li><img src="../images/share-banner.jpg" width="295" height="129" alt=""/></li>
     <li class="p1">Share products with your friends...</li><li class="p2">Earn cash and points for sharing on your social networks!</li></ul>
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
        <div class="select1 fl pr">
                <h1>
                    By Category</h1>
                <!--<div class="select1-nav bdccc">
                    <em class="sjx"></em>
                    <ul>
                    </ul>
                </div>-->
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
                        </tbody></table> 
                        </div></div>
   <% // remove unmatched two /div by jack cao %>
        <!--/div>
    </div-->
    <!-- select 筛选 -->
    <!-- 筛选显示 -->
    <div class="w964" style="display: none;">

        <div class="select-show clearfix tc">
            <span class="first"><a href="javascript:void(0)" class="first on">Show All</a> </span>
            <span><a href="javascript:void(0)">Multi-products</a> </span><span class="last"><a
                href="javascript:void(0)" class="last">Single product</a> </span>
        </div>
    </div>
   
    <!-- <div class="w964">
        <div class="select-show clearfix tc">
       
           	<span class="first">
				<a href="CollageShare.aspx" class="first">Collage</a>
			</span>
			<span class="last">
				<a href="prdSingleShare.aspx" class="last on">Single Product</a>
			</span>
            -->
                <!--
                <span class="last"><a href="prdSingleShare.aspx"
                    class="last">Single Share</a> </span>
        </div>
      
    </div>-->
 
    <!-- 筛选显示 -->
    <!-- 筛选排序 -->
    <div class="w964">
       <div class="result-select fl">				
			<span class="i-want-design" id="searchResult"></span>
		</div> 
    <div id="selectnav" class="clearfix">
      <div class="select-search bdccc fl">
                <input type="text" class="txt" placeholder="Input key words" id="txtPrdname" />
                <div class="select2 fr bdccc pr" style="display: none;">
                    <h2 s-data="0">
                        按分类搜索</h2>
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
                  Sort By</h3>
                <ul>
                    <li><a href="#" sort-data="1" onclick="orderBy(this)">By Ranking</a> </li>
                    <li><a href="#" sort-data="2" onclick="orderBy(this)">By Time</a> </li>
                    <li><a href="#" sort-data="3" onclick="orderBy(this)">By Price</a> </li>
                    <li><a href="#" sort-data="4" onclick="orderBy(this)">By Name</a> </li>
                    <!--li><a href="#" sort-data="3" onclick="orderBy(this)">By Evaluations</a> </li>
                    <li><a href="#" sort-data="4" onclick="orderBy(this)">By Shares</a> </li-->
                </ul>
            </div>
            <div class="result-select fl" style="display:none;">
                <div class="chklist fl">
                    <input type="checkbox" value="1" style="display: none;">
                    <label class="checkbox">
                        Pre-Sale</label>
                </div>
                <div class="chklist fl">
                    <input type="checkbox" value="1" style="display: none;">
                    <label class="checkbox">
                        Pre-Sale Success</label>
                </div>
                <div class="chklist fl">
                    <input type="checkbox" value="1" style="display: none;">
                    <label class="checkbox">
                        Pre-Sale Failed</label>
                </div>
                <div class="chklist fl">
                    <input type="checkbox" value="1" style="display: none;">
                    <label class="checkbox">
                        Final Sale</label>
                </div>
            </div>
        </div>
    </div>
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
    <!-- 浮动在线咨询 -->
   <%-- <div id="floatALink" style="display: none;">
        <a href="#" class="dietu">Multi-products<br>
            Share</a> <a href="#" class="zxzz">Online<br>
                Help</a> <a href="#" id="gotoTop">Back<br>
                    Top</a>
    </div>--%>
    <!-- 浮动在线咨询 -->
    <!-- 未登录分享弹出框 -->
    <div class="greybox">
        <div id="share-tck" class="tck">
            <a href="#" class="closeBtn" title="Close"></a>
            <div class="tc title">
                <h2>
                    Welcome to Tweebaa's Share & Earn
                </h2>
                <p>
                    Simply register as Tweebaa memeber by type in email address，all shared link's product
                    purchase will bring you
                    <br />
                </p>
            </div>
            <div class="tc bili">
                <span class="item"><b>5% Cash</b><br />
                    According to your level<br />
                    can get maximum 5% cash rewards </span><span class="item"><b>5% Discount</b><br />
                        Your friends will get 5% discount once they  makes a purchase from via your shared link<br />
                    </span>
            </div>
            <div class="tc go-share">
                <a href="#" class="jiaru">Join Now</a> <a href="#" class="go-share-btn">Continue but
                    no cash rewards</a>
            </div>
            <div class="tc tips">
                After you registered as Tweebaa partner, you will learn more on how to earn more
                income.</div>
        </div>
    </div>
    </div>

    <!-- 登录分享弹出框 -->
    <%--<div class="greybox">
	<div id="share-tck2" class="tck">
		<a href="#" class="closeBtn" title="关闭"></a>
		 <h2 class="t">
		 	  <span>有偿分享</span>
		 </h2>
		 <div class="box">
		 	 <div class="areabox">
		 	 	 <textarea>我在@推易吧发现了一个很有新意的产品（产品名称默认）。这个东东好用又方便，价格还超实惠，快来看看吧，还有5%的折扣呢.</textarea>
		 	 	 <div class="zishu">
			 	 	 13/140
			 	 </div>
		 	 </div>
		 	 <div class="sharebox clearfix my-dietu">
		 	 	  <a href="#" class="go-share-btn fr">
		 	 	  	 立即分享
		 	 	  </a>
		 	 	  <span class="fl t ">
		 	 	  	Share
		 	 	  </span>
		 	 	  <div class="bdsharebuttonbox fl"><a href="#" class="bds_weixin" data-cmd="weixin" title="分享到微信"></a><a href="#" class="bds_tsina" data-cmd="tsina" title="分享到新浪微博"></a><a href="#" class="bds_sqq" data-cmd="sqq" title="分享到QQ好友"></a><a href="#" class="bds_renren" data-cmd="renren" title="分享到人人网"></a><a href="#" class="bds_douban" data-cmd="douban" title="分享到豆瓣网"></a><a href="#" class="bds_mail" data-cmd="mail" title="分享到邮件分享"></a></div>
					<script>					    window._bd_share_config = { "common": { "bdSnsKey": {}, "bdText": "", "bdMini": "2", "bdMiniList": false, "bdPic": "", "bdStyle": "0", "bdSize": "32" }, "share": {} }; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];</script>
				  <a href="#" class="share-media-set">分享绑定设置</a>
		 	 </div>
		 	 <div class="ps clearfix">
		 	 	  <span class="fr">
		 	 	  	  你也可以尝试体验 <a href="#">叠图分享</a> 哦！
		 	 	  </span>
		 	 	  <span class="fl">
		 	 	  	  你的朋友通过该链接购买后，你会获得X元返利
		 	 	  </span>
		 	 </div>
		 </div>
	</div>
</div>--%>
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
                    <!--a href="/Home/Index.aspx" class="share-media-set">Link My Account</a-->
                </div>
                <div class="ps clearfix">
                    <span class="fr"><a href="#"></a></span><span class="fl">You will earn  <!--span id="sharePercent"></span-->commission when your friend makes a purchase from your shared link. </span>
                </div>
            </div>
            <%--<div class="box">
                <div class="sharebox clearfix my-dietu">
                    <span class="fl t ">Share to </span>
                    <div class="bdsharebuttonbox fl">
                        <a href="javascript:void(0)" target="_blank" id="share1" class="bds_weixin" title="Facebook"></a>
                        <a href="javascript:void(0)" target="_blank" id="share2" class="bds_tsina"  title="Twitter"></a>
                        <a href="javascript:void(0)" target="_blank" id="share3" class="bds_sqq"  title="google"></a>
                        <a href="javascript:void(0)" target="_blank" class="bds_renren" data-cmd="renren" title="Wechat"></a>
                        <a href="javascript:void(0)" target="_blank" class="bds_douban" data-cmd="douban" title="Pinterest"></a>
                        <a href="javascript:void(0)" target="_blank" class="bds_mail"  data-cmd="mail" title="email"></a>
                    </div>
                    <script>window._bd_share_config = { "common": { "bdSnsKey": {}, "bdText": "", "bdMini": "2", "bdMiniList": false, "bdPic": "", "bdStyle": "0", "bdSize": "32" }, "share": {} }; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];</script>
                    <a href="#" class="share-media-set">Share Binding setting</a>
                </div>
                <div class="ps clearfix">
                    <span class="fr"><a href="#"></a></span><span class="fl">You will earn a commission if anyone makes a purchase from your shared link!</span>
                </div>
            </div>--%>
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
    </div>  <% // missing a div added bu jack cao %>

    <!-- share landing page 弹出框 -->
<div class="popbox" style="display:<%=_popbox%>">
<div class="tcksnow">
<a href="#" class="closeBtn" title="Close"></a>
<div class="thalfc">
<ul><li class="cr"><img src="../images/Layer_247-2.png" width="49" height="50" alt=""></li>
<li class="c1 s">SHARE
</li>
<li class="c2">Perhaps the most exciting part of shopping on Tweebaa is sharing great products with  <br>your friends and earning income.  </li>
</ul>
</div>
<div class="tanmain clearfix">
<div class="lanleft">
<ul><li class="pb1">Sharers earn commissions and points.</li>
<li> <a href="/College/College.aspx" class="btng" >Learn more about sharing ></a></li>
<!--
<li> <a href="/Product/collageCreate.aspx" class="btng" >Create My Collage Design ></a></li>
-->
<li> <a href="#" class="every"></a></li>
</ul>
</div>
<div class="lanright">
<ul><li class="btm share" onclick="hidePopup()" style="cursor:pointer;">Start Sharing</li></ul>
<li class="share-man"></li>
<li class="sltxt s">The Sharer</li>
<li class="stxt">
Sociable & entrepreneurial.  <br/>
Sharers proclaim great Tweebaa<br/>products to their friends.<br/><br/><br/>
Do not show this message again.<input type="checkbox" name="cbCheck" onclick="hidePopup();SavePopupCookie('SharersPopup')" />
</li>
</div>
</div></div></div>

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
            $(this).addClass('hover').parent().css('zIndex', '100');
            $(this).find(".floatDiv").stop().animate({ top: 0 }, 100)
        }).live('mouseleave', function (event) {
            $(this).removeClass('hover').parent().css('zIndex', '');
            $(this).find(".floatDiv").stop().animate({ top: "-110px" }, 100)
        });

        $(".share-btn").live('mouseenter', function (event) {
            $(this).siblings().show();
        }).live('mouseleave', function (event) {
            $(this).siblings().hide();
        });
        $(".closeBtn,.go-share-btn").click(function () {
            $(this).parents(".greybox").hide();
            return false;
        })
        //模拟点击分享按钮，随机 登陆 和未登录状态 。
        //    $(".share-btn").live('click', function (event) {
        //        var shareTck = ["#share-tck2", "#share-tck"]
        //        var thisb = $(shareTck[parseInt(Math.random() * 2)])
        //        thisb.animate({ top: "2%" }, 300);
        //        thisb.parent().show()
        //        return false;
        //    });

        //snow加landingpage
        $(".closeBtn").click(function () {
            $(this).parents(".popbox").hide();
            return false;
        })
        //登陆后弹出分享框
        $(".share-btn").live('click', function (event) {
            //var shareTck = ["#share-tck2", "#share-tck"]
            //var thisb = $(shareTck[parseInt(Math.random() * 2)])
            $("#share-tck2").animate({ top: "2%" }, 300);
            $("#share-tck2").parent().show()
            return false;
        });

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

        //隐藏弹出 框
        function hidePopup() {
            $(".popbox").hide();
        }
    </script>
</asp:Content>
