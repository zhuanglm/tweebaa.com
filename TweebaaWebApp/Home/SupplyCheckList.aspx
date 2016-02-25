<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplyCheckList.aspx.cs" Inherits="TweebaaWebApp.Home.SupplyCheckList" %>
<%@ Register  TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
.paginator { font: 12px Arial, Helvetica, sans-serif;padding:10px 20px 10px 0; margin: 0px;}
.paginator a {border:solid 1px #ccc;color:#0063dc;cursor:pointer;text-decoration:none;}
.paginator a:visited {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;}
.paginator .cpb {border:1px solid #F50;font-weight:700;color:#F50;background-color:#ffeee5;}
.paginator a:hover {border:solid 1px #F50;color:#f60;text-decoration:none;}
.paginator a,.paginator a:visited,.paginator .cpb,.paginator a:hover  
{float:left;height:16px;line-height:16px;min-width:10px;_width:10px;margin-right:5px;text-align:center;
 white-space:nowrap;font-size:12px;font-family:Arial,SimSun;padding:0 3px;}

    </style>
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
    <script src="../Manage/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="home-main fl">
    <div class="collection-main">
					<h2 class="t">
						My profile
					</h2>
					<div class="collection-select clearfix">
						<span class="fl">
						 	Product Stage
						 </span>

						<div class="select-box fl pr">
							<h3 id="s-data" s-data="-1" class="">All</h3>
							<ul class="select-list" style="display: none;">
								<li>
									<a s-data="0" href="#">Draft</a>
								</li>
								<li>
									<a s-data="1" href="#">Evaluating</a>
								</li>
								<li>
									<a s-data="3" href="#">Not Accepted</a>
								</li>
								<li>
									<a s-data="2" href="#">Accepted</a>
								</li>
								
							</ul>
						</div>
						<span class="fl">Submitted on</span>
						<input type="text" id="startTime" runat="server" class="time-text" value="" onClick="WdatePicker()" />
						<span class="fl">To</span>
						<input type="text" id="endTime" runat="server" class="time-text" value=""  onClick="WdatePicker()"/>
                        <input type="hidden" id="hidstate" value="" runat="server" />
                        <script type="text/javascript">
                            function seachFuc() {
                                var stype = $("#s-data").attr("s-data");
                                var start = $("#startTime").val();
                                var end = $("#endTime").val();
                                if (stype == "-1" && start == "" && end == "") {
                                    //alert('必须存在一个搜索条件');
                                    return false;
                                }
                                $("#hidstate").val(stype);
                            }
                        </script>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClientClick="javascript:return seachFuc()"  
                            CssClass ="submit" onclick="btnSearch_Click"/>
						<%--<input type="submit" value="确认" class="submit">--%>
					</div>
					<table cellspacing="0" cellpadding="0" border="0" class="supply-checklist">
						<tbody><tr>
							<th class="pro-img">Image</th>
							<th class="pro-infor">Product</th>
							<th class="state">Supply Price</th>
							<th class="price">Status</th>
							<th class="time">Submit Time</th>
							<th class="operation">Action</th>
						</tr>

                            <asp:Repeater ID="repGrid" runat="server">
                            <ItemTemplate>
                            <tr>
							<td class="pro-img">
								<div class="imgbox fl">
									<a href="javascript:void(0)"><img  src='<%#Eval("imgsrc") %>'></a>
								</div>
							</td>
							<td class="pro-infor">
								<div class="infor-box fl">
									<div class="row1">
                                        <%#Eval("proname")%>
										<%--<a href="#">猫砂盆KittyLitty</a>--%>
									</div>
									<div class="row2">
										Item #<%--产品货号--%>:&nbsp;<%#Eval("promodelnum")%>
									</div>
									<div class="row3">
										Product Location<%--产品所在地--%>：<%#Eval("proaddress")%>
									</div>
									<div class="row4 clearfix" id="allColor">
                                       <%#Eval("color")%>
										<%--<i style="background-color: #C4DF9B;"></i>
										<i style="background-color: #BD8CBF;"></i>
										<i style="background-color: #6DCFF6;"></i>--%>
									</div>
									<div class="row5 clearfix">
                                         <%#Eval("rule")%>
										<%--<span>S</span><span>M</span><span>L</span>--%>


                                        <script type="text/javascript">
                                            function changeColor(obj) {
                                                var ruleid = $(obj).attr("ruleid");
                                                $("#allColor").find("i[ruleid='" + ruleid + "']").css("display", "block");
                                                $("#allColor").find("i[ruleid!='" + ruleid + "']").css("display", "none");
                                            }
                                        </script>
									</div>
								</div>
							</td>
							<td class="state">
								<div>
									<strong>$<%#Eval("minprice")%></strong>
									<p>
										To
									</p>
									<strong>$<%#Eval("maxprice")%></strong>
									<div class="ps">
										MOQ:<%#Eval("prosmallnum")%> 
									</div>
								</div>
							</td>
							<td class="price"><%#Eval("state")%></td>
							<td class="time"><%#Eval("createtime")%></td>
							<td class="operation">
								<a href='../Product/inventory.aspx?proid=<%#Eval("proid") %>' target="_top">See Details</a>
                                <a href='../Product/inventory.aspx?proid=<%#Eval("proid") %>' target="_top">Edit</a>
							</td>
						</tr>
                            </ItemTemplate>
                            </asp:Repeater>
					</tbody></table>

                    <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator"   CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" 
FirstPageText="First"  LastPageText="Last" NextPageText="Next"   PrevPageText="Back"  ShowCustomInfoSection="Left" 
ShowInputBox="Never" OnPageChanging="AspNetPager1_PageChanging"   CustomInfoTextAlign="Left" LayoutType="Table"  >
</webdiyer:AspNetPager>

					<%--<div class="page tr">
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
					</div>--%>
				</div>
    </div>
    </form>

</body>
</html>
