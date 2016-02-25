<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TweebaaWebApp.Home.Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--    <script src="../Js/input.js" type="text/javascript"></script>
    <link href="../Css/home.css" rel="stylesheet" type="text/css" />--%>

    <link rel="stylesheet" href="../css/index.css" />
	<link rel="stylesheet" href="../css/home.css" />
	<script src="../js/jquery.min.js" type="text/javascript"></script>
	<script src="../js/jquery.placeholder.js" type="text/javascript"></script>
	<script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
	<script src="../js/selectNav.js" type="text/javascript"></script>
	<script src="../js/homePage.js" type="text/javascript"></script>
	<link rel="stylesheet" href="../css/selectCss.css" />
	<script src="../js/selectCss.js" type="text/javascript"></script>
	<script type="text/javascript" src="../js/public.js"></script>
</head>
<body>
<script type="text/javascript">
    function GetMenu(pageUrl) {
        //$("#iframepage").attr("src", pageUrl);
        parent.document.getElementById('iframepage').src = pageUrl;
    }
</script>
   <div class="home-main fl">				
				<div class="home-index clearfix">
					<div class="item item1">
						<h3>
							<a href="javascript:void(0)" onclick="GetMenu('homeSupply.aspx')" class="fr des">Details></a>
							<strong>My Submit</strong>
						</h3>
						<p class="p1 tc">
							Income<a href="#"><b>$<%=_fabu %></b></a>
						</p>
						<p class="p2 tc">
							<a href="../Product/issue.aspx" target="_parent">Submit Now</a>
						</p>
						<p class="p3 tr">
							<a href="#">How to submit？</a>
						</p>
					</div>
					<div class="item item2">
						<h3>
							<a href="javascript:void(0)" onclick="GetMenu('HomeReview.aspx')" class="fr des">Details></a>
							<strong>My Evaluate</strong>
						</h3>
						<p class="p1 tc">
							Income<a href="#"><b>$<%=_pingshen %></b></a>
						</p>
						<p class="p2 tc">
							<a href="../Product/prdReviewAll.aspx" target="_parent">Evaluate Now</a>
						</p>
						<p class="p3 tr">
							<a href="#">How to Evaluate？</a>
						</p>
					</div>
					<div class="item item3">
						<h3>
							<a href="#" class="fr des">Details></a>
							<strong>My Share</strong>
						</h3>
						<p class="p1 tc">
							Income<a href="#"><b>$<%=_fenxiang %></b></a>
						</p>
						<p class="p2 tc">
							<a href="#">Share Now</a>
						</p>
						<p class="p3 tr">
							<a href="#">How to Share？</a>
						</p>
					</div>
					<div class="item item4">
						<h3>
							<a href="#" class="fr des">Details></a>
							<strong>My Orders</strong>
						</h3>
						<p class="p1 tc">
							Pending<a href="#"><b><%=_weizhifu %></b></a>　　Shipped<a href="#"><b><%=_yifahuo %></b></a>
						</p>
						<p class="p2 tc">
							<a href="../Product/prdSaleAll.aspx" target="_parent">Shop Now</a>
						</p>
						<p class="p3 tr">
							<a href="#">How to Shop？</a>
						</p>
					</div>
				</div>


			</div>
</body>
</html>
