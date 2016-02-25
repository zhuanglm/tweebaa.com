<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="shopping-cart-new.aspx.cs" Inherits="TweebaaWebApp.Product.shopping_cart_new" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

    <link rel="stylesheet" href="../Css/index.css" />
	<link rel="stylesheet" href="../Css/buyall.css" />
	<link rel="stylesheet" href="../Css/mycart-new.css" />
	<script src="../Js/jquery.min.js" type="text/javascript"></script>
	<script src="../Js/qtab.js" type="text/javascript"></script>
	<script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
	<link rel="stylesheet" href="../Css/selectCss.css" />
	<script src="../Js/jquery.placeholder.js" type="text/javascript"></script>
	<script type="text/javascript" src="../Js/selectNav.js"></script>
	<script type="text/javascript" src="../Js/public.js"></script>
	<script type="text/javascript" src="../Js/addnumber.js"></script>
	<script type="text/javascript" src="../Js/pop-up-cart.js"></script>
	<script type="text/javascript" src="../Js/shopcarFloat.js"></script>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">


   <!-- Shopping Cart -->
   <div class="w975 my-cart">
	      <div class="ct">
		My Shopping Cart
	</div>
	<div class="btntop">
 
			<a href="#" class="ctnshop-btn">Cotinue Shopping</a>
            <a href="#" class="settlement-btn">Check Out</a>
	
	</div>
	<div class="pro-list-box">
		 <table>
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

		 	<tr>
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
		 		
		 		
		 		
		 	</tr>
			
		 </table>


	</div>
	<div class="del-tips">
		Delete one item successfully, you can revoke the delete if it is a mistake. <a href="#">Revoke</a>
	</div>
</div>

   <!-- Check Out -->
   <div class="w975 btm"><ul class="fr"><li class="prict-total">
Subtotal:<strong> $0.00 </strong></a></li>
	<li>	<a class="checkout-btn" href="shopping-address.html" >
				Check Out
			</a></li></ul></div>

	

<!-- 浮动在线咨询 -->
<div id="floatALink" style="top:215px">
	<a href="#" class="zxzz">
		Online<br>Help</a>
	<a href="#" id="gotoTop">
		Back<br>to Top</a>
</div>
<!-- 浮动在线咨询 -->

<!-- Delete Items弹出框 -->
<div class="del-shop-tck">
	<a href="javascript:;" class="closeBtn"></a>
	<strong>Delete Items</strong>
	<p>
		Confirm to delete the item?
	</p>
	<a href="#" class="enter-del">
		Confirm
	</a>
	<a href="#" class="cancel-del">
		Cancel
	</a>
</div>

<!-- 支付方式 -->
<div class="payment-methods">
	<a href="javascript:;" class="closeBtn"></a>
	<p class="t">
		Payment Method
	</p>
	<ul class="clearfix">
		<li><label>
			<input type="radio" name="payGroup" checked="checked" />
			<img src="images/pay1.png" alt="" />
			</label>
		</li>
		<li><label>
			<input type="radio" name="payGroup"/>
			<img src="images/pay2.png" alt="" />
			</label>
		</li>
	</ul>
	<a href="#" class="gotoPay">
		Pay Now
	</a>
</div>

<div class="greybox">
	
</div>



	<script type="text/javascript">
	    //表单提示
	    $('input,textarea').placeholder();
	    //表单美化
	    $('.chklist').hcheckbox();

	    //Edit Color 尺寸
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
	    //显示 Favorite和Share

	    $("#mainsrp-itemlist .box").live('mouseenter', function (event) {
	        $(this).addClass('hover')
	        $(this).find(".floatDiv").stop().animate({ top: 0 }, 100)
	    }).live('mouseleave', function (event) {
	        $(this).removeClass('hover')
	        $(this).find(".floatDiv").stop().animate({ top: "-110px" }, 100)
	    });

	    // Select all
	    $(".all-select-btn").click(function (event) {
	        if (!$(this).attr('checked')) {
	            $(".checkbox,.all-select-btn").attr('checked', false)
	        } else {

	            $(".checkbox,.all-select-btn").attr("checked", true);
	        }
	    });
		
		
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
	                //zt1,zt2,zt3,zt4;对应 Product的4Status 
	                //zt1 Test-Sale Stage //zt2 Final-Sale //zt3 Test-Sale Successful//zt4Test-Sale Failed

	                //模拟信息结束

	                zt1 = '<div class="item presale-ing"><div class="box"><div class="pic-box"><a href="#" class="imglink"><img src="images/224x224.jpg" alt=""></a><div class="floatDiv"><a href="#" class="love" title="Favorite">Favorite</a> <a href="#" class="down" title="Save to Store">Save to Store</a> <a href="#" class="share" title="Share & Earn">Share & Earn</a></div></div><div class="row row1"><a href="#">Outdoor Lighting</a></div><div class="row row2">This is product description This is product description This is product description</div><div class="row row3 clearfix"><div class="zt1"><a href="javascript:;" class="gotoShopCar" title="Add to Cart">Add to Cart</a><del>$577.80</del> <strong class="color">$288.98</strong></div></div><div class="row row4 clearfix"><div class="zt1"><div class="jdt"><span style="width:50%"></span></div><span class="fr">30 days left</span> <span class="fl">Test-Sale:88pcs</span> <span class="color">Test-Sale Stage</span></div></div><i class="hot"></i></div></div>'

	                zt2 = '<div class="item sales-ing"><div class="box"><div class="pic-box"><a href="#" class="imglink"><img src="images/224x224.jpg" alt=""></a><div class="floatDiv"><a href="#" class="love" title="Favorite">Favorite</a> <a href="#" class="down" title="Save to Store">Save to Store</a> <a href="#" class="share" title="Share & Earn">Share & Earn</a></div></div><div class="row row1"><a href="#">Outdoor Lighting</a></div><div class="row row2">This is product description This is product description This is product description</div><div class="row row3 clearfix"><div class="zt2"><a href="javascript:;" class="gotoShopCar" title="Add to Cart">Add to Cart</a> <strong class="color">$288.98</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><a href="javascript:;" class="loveNumber" title="喜欢">100</a></span> <span class="fl">Sold：100pcs</span> <span class="color">Final-Sale</span></div></div></div></div>'

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
	        //点击More 加载
	        $(".down-mores").click(function () {
	            $minUl = getMinUl($(this).parents(".w964"));
	            loadMeinv($(this).parents(".w964"));
	            return false;
	        });

	    })
</script>

</asp:Content>
