<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="shopCart.aspx.cs" Inherits="TweebaaWebApp.Product.shopCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Shopping Cart - purchase, share and earn on Tweebaa
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

   
    <link rel="stylesheet" href="../Css/buyall.css" />   
   <%-- <link href="../Css/mycart.css" rel="stylesheet" type="text/css" />--%>
    <link href="../Css/mycart-new.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Js/addnumber.js"></script>  
    <script type="text/javascript" src="../Js/shopcarFloat.js"></script>
    <script src="../MethodJs/buy.js" type="text/javascript"></script>
    <script src="../MethodJs/calculate.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <!-- 购物车 -->
    <div class="w975 my-cart">      
        <div class="ct">
		  My Shopping Cart
	    </div>
        <div class="btntop"> 
			<a href="javascript:void(0);" class="ctnshop-btn" onclick="ContinuShop()">Continue Shopping</a>
           <a href="javascript:void(0);" onclick="CreateOrder()" class="settlement-btn">Check Out</a>
           <script type="text/javascript">
               function ContinuShop() {
                   var lastPage = document.referrer;
                   if (lastPage.indexOf('Buy')>0) {
                       window.history.back(-1);
                   }
                   else {
                       window.location.href = "prdSaleAll.aspx";
                   }
               }
           </script>
	    </div>   

       <div class="pro-list-box">
		 <table id="tabCart">
		 	<tr>
		 		<th colspan="2" class="first">
					
					<span class="name-t">Items</span>
		 		</th>

		 		<th>
		 			Price
		 		</th>
		 		
		 		<th>
		 			Subtotal
		 		</th>
		 	
		 	</tr>

		 	<%--<tr>
		 		<td class="first" style="width:25px;overflow:hidden">
		 	
		 		</td>
		 		<td class="pro-des">
		 			<div class="pro-des-box">
                    <div class="leftimg">
		 				<a href="#" class="imglink"><img src="images/88x88.png" alt="" /></a>
                        <a href="#" class="delthis">Delete</a></div>
                       
			 			<div class="des">
			 			  <p class="baobei-name"> <a href="#"> New Fashion Leather Shoeuuuuu<em>(Test-Sale)</em> </a> </p>
			 			  <p class="size ">Color：Black<br />Size：43</span>
		 				  <p class="addfav">
			 					<a href="#">Move to Favorite</a>
			 				</p>
			 			</div>
		 			</div>
		 		</td>
		 		
		 		<td class="baobei-number">
                <span>$22.88 X </span>
		 			<span class="number-box">
		 				<a href="javascript:;" class="jian-btn"></a>
		 				<a href="javascript:;" class="jia-btn"></a>
		 				<input type="text" value="1" class="num"/>
                       
		 			</span>
		 		</td>

		 		<td>
		 			<div class="red">

		 				<strong>$555.00</strong>
		 			</div>
		 		</td>
		 		
		 		
		 		
		 	</tr>--%>
			
		 </table>


	</div>

        <div class="del-tips">
            Delete one item successfully, you can revoke the delete if it is a mistake. <a href="#">
                Revoke</a>
        </div>
    </div>
    <!-- 结算 -->
    		<div class="w975 btm">
               <ul class="fr">
                   <li class="prict-total">
                      <div style="margin-left: -100px;">Subtotal:<strong> $&nbsp;&nbsp;<label id="labPayMoney1" style="margin-left: -10px;"></label></strong></div>
                   </li>
          	       <li>	
                     <a class="checkout-btn" href="javascript:void(0);" onclick="CreateOrder()" >
				       Check Out
			         </a>
                    </li>
                </ul>
             </div>

    <%--<div class="settlement-box" style="display:none;">
        <div class="w975 pr">
            <div class="fr">
                <span class="select-nubmer fl">Selected Items <strong>
                    <label id="labPayCount">
                    </label>
                </strong>Pieces </span><span class="prict-total fl">Grand Total (S/H not included)：<strong>
                    $<label id="labPayMoney2" style="margin-left: -10px;"></label>
                </strong></span><a href="#" onclick="CreateOrder()" class="settlement-btn fl">Check
                    Out </a>
            </div>
            <label>
                <input type="checkbox" class="all-select-btn" onclick="CheckAll(this)" />
                Select all
            </label>
            <a href="javascript:void(0);" onclick="DeletShopCartAll()">Delete</a><a href="javascript:void(0);"
                onclick="FavoritePrdAll()">Move to Favorite</a><a href="#" style="display: none;">Share
                    & Earn</a>
            <!-- 购物车弹出框 -->
            <div class="pop-up-cart" style="display: none;">
                <a href="#" class="btn leftBtn"></a><a href="#" class="btn rightBtn"></a><i class="icon-sjx">
                </i>
                <div class="box hid">
                    <ul>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>--%>
    <br />
    <br />
    <div class="w975 jstab" style="display: none;">
        <div class="tab-sc clearfix">
            <a href="#" class="fr gotomy">Go to my Favorite>></a>
            <div class="tab fl">
                <a href="javascript:;" class="active">Favorited</a> <a href="javascript:;">Recent Viewed</a>
            </div>
        </div>
    </div>
    <!-- 筛选排序 -->
    <!-- 列表	 -->
    <div class="w964 recent-collection jstabcon" id="mainsrp-itemlist" style="display: none;">
        <div class="m-itemlist">
            <div class="items clearfix">
            </div>
            <div class="down-more tc">
                <a href="#" class="down-mores">View More</a>
            </div>
        </div>
    </div>
    <div class="w964 recent-viewed jstabcon" id="mainsrp-itemlist" style="display: none;">
        <div class="m-itemlist">
            <div class="items clearfix">
            </div>
            <div class="down-more tc">
                <a href="#" class="down-mores">View More</a>
            </div>
        </div>
    </div>
   
    <!-- 删除商品弹出框 -->
    <div class="del-shop-tck">
        <a href="javascript:;" class="closeBtn"></a><strong>Delete Items</strong>
        <p>
            Confirm to delete the item?
        </p>
        <a href="#" class="enter-del">Confirm </a><a href="#" class="cancel-del">Cancel
        </a>
    </div>
    <!-- 支付方式 -->
    <div class="payment-methods">
        <a href="javascript:;" class="closeBtn"></a>
        <p class="t">
            支付方式选择
        </p>
        <ul class="clearfix">
            <li>
                <label>
                    <input type="radio" name="payGroup" checked="checked" />
                    <img src="../Images/pay1.png" alt="" />
                </label>
            </li>
            <li>
                <label>
                    <input type="radio" name="payGroup" />
                    <img src="../Images/pay2.png" alt="" />
                </label>
            </li>
        </ul>
        <a href="#" class="gotoPay">Pay Now </a>
    </div>
    <div class="greybox">
    </div>
    <script type="text/javascript">
        //表单提示
        $('input, textarea').placeholder();
        //表单美化
        //$('.chklist').hcheckbox();

        //编辑 颜色 尺寸
        $(".color-size").mouseenter(function (event) {
            $(this).addClass('on')
        }).mouseleave(function (event) {
            $(this).removeClass('on').find('.change-colorsize').hide();
        });
        $(".icon-bj").click(function (event) {
            $(this).siblings('.change-colorsize').show();
        });
        $(".chima").find("span").click(function (event) {
            $(this).addClass('on').siblings('span').removeClass('on')
        });
        $(".chima").find("a").click(function (event) {
            $(this).parents(".color-size").removeClass('on').find('.change-colorsize').hide();

            return false;
        });
        //显示 收藏和分享

        $("#mainsrp-itemlist .box").live('mouseenter', function (event) {
            $(this).addClass('hover')
            $(this).find(".floatDiv").stop().animate({ top: 0 }, 100)
        }).live('mouseleave', function (event) {
            $(this).removeClass('hover')
            $(this).find(".floatDiv").stop().animate({ top: "-110px" }, 100)
        });

        // 全选
        //        $(".all-select-btn").click(function (event) {
        //            if (!$(this).attr('checked')) {
        //                $(".checkbox,.all-select-btn").attr('checked', false)
        //            } else {

        //                $(".checkbox,.all-select-btn").attr("checked", true);
        //            }
        //        });
		
		
    </script>
    <!-- 无线加载js -->
    <script type="text/javascript">
        $(function () {
            //url data function dataType
            function loadMeinv(obj) {

                for (var i = 0; i < 4; i++) {//每次加载4条信息
                    var html = "";

                    //以下是模拟信息
                    var html, zt1, zt2, zt3, zt4;
                    //zt1,zt2,zt3,zt4;对应产品的4中状态 
                    //zt1 预售中 //zt2 销售中 //zt3 预售成功 //zt4预售失败

                    //模拟信息结束

                    zt1 = '<div class="item presale-ing"><div class="box"><div class="pic-box"><a href="#" class="imglink"><img src="../Images/224x224.jpg" alt=""></a><div class="floatDiv"><a href="#" class="love" title="收藏">收藏</a> <a href="#" class="down" title="资料下载">资料下载</a> <a href="#" class="share" title="有偿分享">有偿分享</a></div></div><div class="row row1"><a href="#">伸缩雨伞桶，车载雨伞收纳桶收纳盒</a></div><div class="row row2">该产品的简述该产品的简述该产品的简述该产品的简述该产品的简述该产品的简述该产品的简述该产品的简述</div><div class="row row3 clearfix"><div class="zt1"><a href="javascript:;" class="gotoShopCar" title="加入购物车">加入购物车</a><del>$577.80</del> <strong class="color">$288.98</strong></div></div><div class="row row4 clearfix"><div class="zt1"><div class="jdt"><span style="width:50%"></span></div><span class="fr">还剩30天</span> <span class="fl">预售:88件</span> <span class="color">预售中</span></div></div><i class="hot"></i></div></div>'

                    zt2 = '<div class="item sales-ing"><div class="box"><div class="pic-box"><a href="#" class="imglink"><img src="../Images/224x224.jpg" alt=""></a><div class="floatDiv"><a href="#" class="love" title="收藏">收藏</a> <a href="#" class="down" title="资料下载">资料下载</a> <a href="#" class="share" title="有偿分享">有偿分享</a></div></div><div class="row row1"><a href="#">伸缩雨伞桶，车载雨伞收纳桶收纳盒</a></div><div class="row row2">该产品的简述该产品的简述该产品的简述该产品的简述该产品的简述该产品的简述该产品的简述该产品的简述</div><div class="row row3 clearfix"><div class="zt2"><a href="javascript:;" class="gotoShopCar" title="加入购物车">加入购物车</a> <strong class="color">$288.98</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><a href="javascript:;" class="loveNumber" title="喜欢">100</a></span> <span class="fl">已售：100件</span> <span class="color">销售中</span></div></div></div></div>'

                    var ztArrhtml = [zt1, zt2]

                    html = ztArrhtml[parseInt(Math.random() * 2)]

                    $minUl = getMinUl(obj);
                    $minUl.append(html);
                }
            }
            loadMeinv($(".jstabcon").eq(0));
            loadMeinv($(".jstabcon").eq(1));
            //无限加载
            $(window).on("scroll", function () {
                $minUl = getMinUl();
                if ($minUl.height() <= $(window).scrollTop() + $(window).height()) {
                    //如果要鼠标滚动就加载，
                    //loadMeinv();//加载新图片
                }
            })
            function getMinUl(obj) {
                var $arrUl = $(obj).find('.items')
                var $minUl = $arrUl.eq(0);
                $arrUl.each(function (index, elem) {
                    if ($(elem).height() < $minUl.height()) {
                        $minUl = $(elem);
                    }
                });
                return $minUl;
            }
            //点击更多加载
            $(".down-mores").click(function () {
                $minUl = getMinUl($(this).parents(".w964"));
                loadMeinv($(this).parents(".w964"));
                return false;
            });

        })
    </script>
</asp:Content>
