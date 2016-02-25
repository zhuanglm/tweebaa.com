<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeShipOrder.aspx.cs" Inherits="TweebaaWebApp.Home.HomeShipOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
	<meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
	<title>Document</title>
	<link rel="stylesheet" href="../css/index.css" />
	<link rel="stylesheet" href="../css/home.css" />
    <link rel="stylesheet" href="../css/c.css" />
	<script src="../js/jquery.min.js" type="text/javascript"></script>
	<script src="../js/jquery.placeholder.js" type="text/javascript"></script>
	<script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
	<script src="../js/selectNav.js" type="text/javascript"></script>
	<script src="../js/homePage.js" type="text/javascript"></script>
	<link rel="stylesheet" href="../css/selectCss.css" />
	<script src="../js/selectCss.js" type="text/javascript"></script>
	<script type="text/javascript" src="../js/public.js"></script>
	<script type="text/javascript" src="../js/home-safe.js"></script>
	<script src="../MethodJs/homeShipOrder.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Manage/My97DatePicker/lang/en.js"  type="text/javascript"></script>
    <%--paging--%>
    <script src="../Js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="../Js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />

</head>
<body>
  <!-- 用户中心内容 -->
  <div class="w967 home-page">
	<div class="wrap clearfix">
	  <div class="home-main details  fl">
        <div class="details-main"><!--safe-main-->

          <% // header %>  
          <h2 class="t">Purchase Order Summary</h2>

          <div class="section">
            <% // search conditions %>
            <div class="collection-select clearfix" style="width:100%">

              <span class="fl" style="margin-left:10px">Order #&nbsp;</span>
              <input type="text" class="time-text" id="txtShipOrderID" />&nbsp;&nbsp;

              <span class="fl">Order Date &nbsp;</span>
              <input type="text" value="" class="time-text" id="txtBeginTime" onclick="WdatePicker({ lang: 'en' })" />
              <span class="fl">To</span>
              <input type="text" value="" class="time-text" id="txtEndTime" onclick="WdatePicker({ lang: 'en' })" />
              <div style=" width:100%; height:10px;"></div>
              
              <span class="fl" style="margin-left:10px">Tracking #&nbsp;</span>
              <input type="text" class="time-text" id="txtTrackingNo" />&nbsp;&nbsp;
              <span class="fl"">Status&nbsp;</span>
                <span class="fl"  >
            <select id="optStatus" style="height:24px; border:1px solid #ccc; border-radius:3px;" >
              <option value="" selected>All</option>
              <option value="1">To Be Shipping</option>
              <option value="2">Shipped</option>
              <option value="3">Completed</option>
              <option value="-1">Cancelled</option>
            </select>
          </span>
              <input  type="button" class="submit" value="Search" onclick="DoSearch()" />
              
            </div>
           
            <% // shipping order list table %>
            <table width="100%" class="table" id="tblShipOrderList" style="margin-top:10px;">
			  <tr style="border-right:#f2f2f2 1px solid ;border-left: #f2f2f2 1px solid;">
			    <th width="100">Order #</th>
			    <th width="130">Customer Order #</th>
				<th width="102">Order Date</th>
                <th width="70">Total Items</th>	
                <th width="70">Total Price</th>	                                                                                      
                <th width="100">Tracking #</th>	
				<th width="85">Status</th>
                <th width="105">Action</th>
              </tr>
              <!--tr>
			    <td><span class="text"><a href="#">12345678</a></span></td>
			    <td><span class="text"><a href="#">Twee12345678</a></span></td>
                <td><span class="text">14/08/2015</span></td>
				<td><span class="text">55</span></td>
                <td><span class="text">58.00</span></td>
                <td><span class="text">CP 234342888</span></td>
                <td><span class="text ">Shipping</span></td>
                <td><span class="text ">
                  <select>
                    <option value="0">Choose Action</option>
                    <option value="1">Order Details</option>
                    <option value="2">Update Status</option>
                    <option value="3">Add Tracking </option>
                    <option value="4">Cancel Order </option>
                  </select></span>
                </td>
              </tr-->
		    </table>

            <div id="divNoData" style="display:none" >No data found! </div>
            <div id="kkpager" style="float:right; padding-right:150px;"></div><br />

          </div>
        </div>
      </div>
	</div>
  </div>
 
  <div id="divAddTrackingNo" class="unbind-box">
	<a href="javascript:;" class="closeBtn"></a>
	<h2 class="t">Add Tracking </h2>
	<form action="">
	<table width="100%">
       <tr>
        <td><input id="txtAddTrackingNo" type="text"  class="txt textZip" placeholder="Please enter your Tracking #"/></td>
       </tr>
		<tr>
			<td>
		    <input  id="btnAddTrackingNo" type="button" value="OK" class="send cancel"/>
			</td>
		</tr>
	</table>
	</form>
</div>

  <div id="divUpdateStatus" class="unbind-box">
	<a href="javascript:;" class="closeBtn"></a>
	<h2 class="t">Update Status</h2>
	<form action="">
	<table width="100%">
       <tr>
            <td>
            <select id="optUpdateStatus" style="height:24px; border:1px solid #ccc; border-radius:3px;" >
              <option value="" selected >--Please Select</option>
              <option value="1">To Be Shipping</option>
              <option value="2">Shipped</option>
              <option value="3">Completed</option>
              <option value="-1">Cancelled</option>
            </select>
            </td>
       </tr>
		<tr>
			<td>
		    <input id="btnUpdateStatus" type="button" value="OK" class="send cancel"/>
			</td>
		</tr>
	</table>
	</form>
</div>


</body>
<script type="text/javascript">

//    $("input").placeholder()

//    // select 美化
//    $(".selects").selectCss();

//    $(function () {

////        //add tracking-----
////        $(".unbind").click(function (event) {
////            $(".greybox,.unbind-box").show();
////            $(".unbind-box").find('h2').text("Add Tracking")
////            return false;
////        });

//        $(".closeBtn,.cancel").click(function (event) {
//            $(".greybox,.unbind-box").hide();
//            return false;
//        });


//        //显示设置内容
//        $(".setBtn").each(function (index, el) {
//            $(this).click(function () {

//                if (!$(this).hasClass('on')) {
//                    $(this).text('收起')
//                    $(this).addClass('on').parents("li").find(".setbox").show();
//                } else {
//                    $(this).text('设置')
//                    $(this).removeClass('on').parents("li").find(".setbox").hide();
//                }
//                return false;
//            })

//        });
//        //问题下拉
//        $(".selectBtn").click(function () {
//            if (!$(this).siblings('dl').hasClass('db')) {
//                $(this).siblings('dl').addClass('db').show();
//            } else {
//                $(this).siblings('dl').removeClass('db').hide();
//            }

//        })
//        $(".safe-q-box").mouseleave(function (event) {
//            $(this).find('dl').removeClass('db').hide();
//        });
//        $(".safe-q-box").find("dl a").click(function (event) {
//            $(".safe-q").val($(this).text())

//            return false;
//        });
 //   })
</script>

</html>