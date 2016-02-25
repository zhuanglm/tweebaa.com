<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeReview.aspx.cs" Inherits="TweebaaWebApp.Home.HomeReview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" /> 
     <link rel="stylesheet" href="../Css/index.css"/>
	<link rel="stylesheet" href="../Css/home.css" />
	<script src="../Js/jquery.min.js" type="text/javascript"></script>
	<script src="../Js/jquery.placeholder.js" type="text/javascript"></script>
	<script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
	<script src="../Js/selectNav.js" type="text/javascript"></script>
	<script src="../Js/homePage.js" type="text/javascript"></script>
	<link rel="stylesheet" href="../Css/selectCss.css" />
	<script src="../Js/selectCss.js" type="text/javascript"></script>
	<script type="text/javascript" src="../Js/public.js"></script>
    <script src="../MethodJs/homeReview.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Manage/My97DatePicker/lang/en.js"></script>
       <%--分页--%>    
    <script src="../Js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="../Js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="home-main fl"> 
				<div class="collection-main">
					<h2 class="t">
						My Evaluations
					</h2>
                    <p>Evaluators complete simple, 5-question surveys to help

identify new products for the Tweebaa Shop.  Evaluators assist in the 

growth and popularity of products, with potential to earn 

commissions! <a class="learn" href="../College/EvaluateZone.aspx?page=evaluate-zone" target="_blank">Learn more</a> </p>
					<div class="collection-select clearfix" style="width:100%">
						<span class="fl">
						 	Product Status
						 </span>

						<div class="select-box fl pr" style="width:150px;">
							<h3 s-data="0" id="s-data" style="width:150px;">All</h3>							

                           <ul class="select-list" style=" width:140px;">
                                <li><a href="#" onclick="SetState(-1)">All</a> </li>
                                <li><a href="#" onclick="SetState(1)">Public Evaluating</a> </li>
                                <li><a href="#" onclick="SetState(4)">Tweebaa Evaluating</a> </li>    
                                <li><a href="#" onclick="SetState(2)">Test-Sale</a> </li>
                                <li><a href="#" onclick="SetState(3)">Buy Now</a> </li>
                                <li><a href="#" onclick="SetState(7)">Test-Sale Failed</a> </li><%--预售失败--%>
                            </ul>

						</div>
						<span class="fl">Evaluated on&nbsp;&nbsp;&nbsp;</span>
						<input type="text" value="" class="time-text" id="txtBegTime" onclick="WdatePicker({ lang: 'en' })" />
						<span class="fl">To</span>
						<input type="text" value="" class="time-text" id="txtEndTime" onclick="WdatePicker({lang:'en'})" />
						<input type="button" class="submit" value="Search" onclick="DoSearch()" />
					</div>
					<table class="collection-list">
						<tr>
							<th class="pro-name">Product</th>
                            <th class="state">Status</th>
							<!--th class="state">Participants</th-->
							<th class="price">My Evaluation Content</th>                           
							<th class="operation" >Action</th>
						</tr>
				 
					</table>
                    <div id="divNoData" style="display:none" >No product found! </div>
					<div class="page tr">
					   <div id="kkpager" style="float:right;"></div>
					</div>
				</div></div>
    </form>
</body>
</html>
