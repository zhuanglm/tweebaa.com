<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prdSupplyChecklist.aspx.cs" Inherits="TweebaaWebApp.Product.prdSupplyChecklist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../Js/jquery-1.9.1.min.js"></script>
    <link rel="stylesheet" href="../css/index.css" />
	<link rel="stylesheet" href="../css/home.css" />
	<script src="../js/jquery.min.js" type="text/javascript"></script>
	<script src="../js/jquery.placeholder.js" type="text/javascript"></script>
	<script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
	<script src="../js/selectNav.js" type="text/javascript"></script>
	<script src="../js/homePage.js" type="text/javascript"></script>
	<link rel="stylesheet" href="../css/selectCss.css" />
	<script src="../js/selectCss.js" type="text/javascript"></script>
	<%--<script type="text/javascript" src="../js/public.js"></script>--%>
    <script src="../Manage/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="collection-main">
					<h2 class="t">
						我的供货单
					</h2>
					<div class="collection-select clearfix">
						<span class="fl">
						 	供货单状态
						 </span>

						<div class="select-box fl pr">
							<h3 id="s-data" s-data="-1" class="">全部</h3>
							<ul class="select-list" style="display: none;">
								<li>
									<a s-data="0" href="#">草稿</a>
								</li>
								<li>
									<a s-data="1" href="#">审核中</a>
								</li>
								<li>
									<a s-data="3" href="#">未采纳</a>
								</li>
								<li>
									<a s-data="2" href="#">已采纳</a>
								</li>
								
							</ul>
						</div>
						<span class="fl">上传时间</span>
						<input type="text" id="startTime" onClick="WdatePicker()" class="time-text" value="">
						<span class="fl">到</span>
						<input type="text" id="endTime" onClick="WdatePicker()" class="time-text" value="">
						<input type="submit" value="确认" class="submit">
					</div>
					<table cellspacing="0" cellpadding="0" border="0" class="supply-checklist">
						<tbody><tr>
							<th class="pro-img">我供货的产品</th>
							<th class="pro-infor">我供货的产品</th>
							<th class="state">供应价格</th>
							<th class="price">状态</th>
							<th class="time">发布时间</th>
							<th class="operation">操作</th>
						</tr>
						<tr>
							<td class="pro-img">
								<div class="imgbox fl">
									<a href="#"><img alt="" src="images/106x112.jpg"></a>
								</div>
							</td>
							<td class="pro-infor">
								<div class="infor-box fl">
									<div class="row1">
										<a href="#">猫砂盆KittyLitty</a>
									</div>
									<div class="row2">
										产品货号:&nbsp;QL-SD-8808
									</div>
									<div class="row3">
										产品所在地：中国 加拿大  
									</div>
									<div class="row4 clearfix">
										<i style="background-color: #C4DF9B;"></i>
										<i style="background-color: #BD8CBF;"></i>
										<i style="background-color: #6DCFF6;"></i>
									</div>
									<div class="row5 clearfix">
										<span>S</span><span>M</span><span>L</span>
									</div>
								</div>
							</td>
							<td class="state">
								<div>
									<strong>$50.99</strong>
									<p>
										至
									</p>
									<strong>$90.99</strong>
									<div class="ps">
										1000pcs起订
									</div>
								</div>
							</td>
							<td class="price">提交审核</td>
							<td class="time">2014-08-01</td>
							<td class="operation">
								<a href="#">查看详情</a>
							</td>
						</tr>
						<tr>
							<td class="pro-img">
								<div class="imgbox fl">
									<a href="#"><img alt="" src="images/106x112.jpg"></a>
								</div>
							</td>
							<td class="pro-infor">
								<div class="infor-box fl">
									<div class="row1">
										<a href="#">猫砂盆KittyLitty</a>
									</div>
									<div class="row2">
										产品货号:&nbsp;QL-SD-8808
									</div>
									<div class="row3">
										产品所在地：中国 加拿大  
									</div>
									<div class="row4 clearfix">
										<i style="background-color: #C4DF9B;"></i>
										<i style="background-color: #BD8CBF;"></i>
										<i style="background-color: #6DCFF6;"></i>
									</div>
									<div class="row5 clearfix">
										<span>S</span><span>M</span><span>L</span>
									</div>
								</div>
							</td>
							<td class="state">
								<div>
									<strong>$50.99</strong>
									<p>
										至
									</p>
									<strong>$90.99</strong>
									<div class="ps">
										1000pcs起订
									</div>
								</div>
							</td>
							<td class="price">草稿</td>
							<td class="time">2014-08-01</td>
							<td class="operation">
								<a href="#">发布</a>
								<a href="#">编辑</a>
								<a href="#">删除</a>
							</td>
						</tr>
						<tr>
							<td class="pro-img">
								<div class="imgbox fl">
									<a href="#"><img alt="" src="images/106x112.jpg"></a>
								</div>
							</td>
							<td class="pro-infor">
								<div class="infor-box fl">
									<div class="row1">
										<a href="#">猫砂盆KittyLitty</a>
									</div>
									<div class="row2">
										产品货号:&nbsp;QL-SD-8808
									</div>
									<div class="row3">
										产品所在地：中国 加拿大  
									</div>
									<div class="row4 clearfix">
										<i style="background-color: #C4DF9B;"></i>
										<i style="background-color: #BD8CBF;"></i>
										<i style="background-color: #6DCFF6;"></i>
									</div>
									<div class="row5 clearfix">
										<span>S</span><span>M</span><span>L</span>
									</div>
								</div>
							</td>
							<td class="state">
								<div>
									<strong>$50.99</strong>
									<p>
										至
									</p>
									<strong>$90.99</strong>
									<div class="ps">
										1000pcs起订
									</div>
								</div>
							</td>
							<td class="price">未采纳</td>
							<td class="time">2014-08-01</td>
							<td class="operation">
								<a href="#">未采纳原因
									<span class="thistips" style="margin-left: -59px;">
										价格没有足够的优势
										<i></i>
									</span>
								</a>
								<a href="#">删除</a>
							</td>
						</tr>
						<tr>
							<td class="pro-img">
								<div class="imgbox fl">
									<a href="#"><img alt="" src="images/106x112.jpg"></a>
								</div>
							</td>
							<td class="pro-infor">
								<div class="infor-box fl">
									<div class="row1">
										<a href="#">猫砂盆KittyLitty</a>
									</div>
									<div class="row2">
										产品货号:&nbsp;QL-SD-8808
									</div>
									<div class="row3">
										产品所在地：中国 加拿大  
									</div>
									<div class="row4 clearfix">
										<i style="background-color: #C4DF9B;"></i>
										<i style="background-color: #BD8CBF;"></i>
										<i style="background-color: #6DCFF6;"></i>
									</div>
									<div class="row5 clearfix">
										<span>S</span><span>M</span><span>L</span>
									</div>
								</div>
							</td>
							<td class="state">
								<div>
									<strong>$50.99</strong>
									<p>
										至
									</p>
									<strong>$90.99</strong>
									<div class="ps">
										1000pcs起订
									</div>
								</div>
							</td>
							<td class="price">已采纳</td>
							<td class="time">2014-08-01</td>
							<td class="operation">
								<a href="#">查看状态
									<span class="thistips" style="margin-left: -53px;">
										预售中，等待进货
										<i></i>
									</span>
								</a>
								<a href="#">查看详情</a>
							</td>
						</tr>
					</tbody></table>
					<div class="page tr">
						<a class="up" href="#">&lt;</a>
						<a href="#">1</a>
						<a href="#">2</a>
						<a class="on" href="#">3</a>
						<a href="#">4</a>
						<a href="#">5</a>
						<a href="#">6</a>
						<a href="#">7</a>
						<a href="#">8</a>
						<a class="down" href="#">&gt;</a>
					</div>
				</div>
    </div>
    </form>
</body>
</html>
