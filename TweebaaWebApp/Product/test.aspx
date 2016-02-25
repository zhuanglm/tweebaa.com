<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="TweebaaWebApp.Product.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/css.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
   <ul id="list1" style="width:620px;margin:40px auto 0 auto;">
	<li id="summary-stock">
		<div class="dt">配&nbsp;送&nbsp;至：</div>
		<div class="dd">
			<div id="store-selector">
				<div class="text"><div></div><b></b></div>                   
				<div onclick="$('#store-selector').removeClass('hover')" class="close"></div>
			</div><!--store-selector end-->
			<div id="store-prompt"><strong></strong></div><!--store-prompt end--->
		</div>
	</li>
</ul>
<script src="../Js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../Js/location.js" type="text/javascript"></script>
</body>
</html>
