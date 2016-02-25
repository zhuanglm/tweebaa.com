<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="CollageCreate.aspx.cs" Inherits="TweebaaWebApp.Product.CollageCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

	<link rel="stylesheet" href="../css/index.css" />
	<link rel="stylesheet" href="../css/selectCss.css" />
<!--	<script src="../js/jquery.min.js" type="text/javascript"></script> -->
	<script src="../js/qtab.js" type="text/javascript"></script>
	<script type="text/javascript" src="../js/public.js"></script>
	<link rel="stylesheet" href="../css/shareall.css" />
	<link rel="stylesheet" href="../css/jquery.bigcolorpicker.css" />
	<script type="text/javascript" src="../js/jquery.bigcolorpicker.min.js"></script>
	<script src="../js/selectCss.js" type="text/javascript"></script>
	<script src="../js/jquery.placeholder2.js" type="text/javascript"></script>
	<script src="../js/myLv2.js" type="text/javascript"></script>
    <!-- Add by Long -->
    <script type="text/javascript" src="../js/jquery-ui.js" ></script>
    <script type="text/javascript" src="../js/jquery.cookie.js" ></script>
    <script type="text/javascript" src="../js/jquery.mousewheel.min.js" ></script>
    <script type="text/javascript" src="../js/jquery.iviewer.js" ></script>
    <script type="text/javascript" src="../js/html2canvas.js" ></script>
    <script type="text/javascript" src="../js/CollageDesign.js" ></script>
    <style>
        		.DivSelected{
        			border:4px solid #000000;
        		}	
        		#zoom_range
        		{
        			margin-top:3px;
        			width:120px;
        		}
        		.margin_left_10
        		{
        		  margin-left:10px;  
        		} 
        		#Save2Draft
        		{
        		    padding-left:20px;
        		}
        		
    </style>
    <link rel="stylesheet" href="../css/jquery.iviewer.css" />
    <!-- Add by Long EOF-->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">   

<div class="h10"></div>



<div class="found-main">
	<div class="w975 mbx">
		<a href="/index.aspx">Homepage</a> > <a href="/Product/prdSingleShare.aspx">Share</a> > <a href="/Product/collageShare.aspx">Collage</a> > <b class="l">Create</b>
	</div>
	
	<div class="w975 clearfix">

<table cellpadding="0" cellspacing="0">
<tr>
<td valign="top" style="vertical-align:top">

<!-- 左边功能按钮 -->
<div class="top-button">
				<div class="fun-btn" >
                  <!-- 右边小图 -->
                    <div class="fr" >
						<ul class="mini-img">
							<li class="on" onclick="change2png()">
								<img id="imgPngsrc" height="67" src="../images/67x67.png" alt="" />
							</li>
							<li onclick="change2jpg()">
								<img id ="imgJpgsrc" height="67" src="../images/67x67.png" alt="" />
							</li>
                            
                            </ul></div>
					 <ul style="width:520px; height:24px;">
					 	<li>
					 		<a href="#" id="fun-fabu" data-con-id="my-dietu" class="js-fun">Submit</a>
					 	</li>
					 	<li>
					 		<a href="#" id="fun-newPro" class="js-fun">New</a>
					 	</li>
					 	<li>
					 		<a href="#" id="fun-open" data-con-id="dietu-moban" class="js-fun">Open</a>
					 	</li>
					 	<li>
					 		<a href="#" id="fun-save" class="js-fun">Save</a>
					 	</li>
                        <!--
				         <li>
					 		<a href="#" id="fun-save" class="js-fun">Save</a>
					 	</li>
                        -->
				
					 </ul>
                   
				</div>
                 <!-- 右上角功能按钮 -->
				<div class="fun-btn2 fl">
                        <a href="#" id="fun-del">Remove</a>
						<a href="#" id="fun-cz">Flip</a>
						<a href="#" id="fun-zy">Flop</a>
						<!--a href="#" id="fun-up">Forward</a>
						<a href="#" id="fun-down">Backward</a-->
                        <a href="#" id="fun-down">Original Size</a>
						<a href="#" id="fun-reset">Fit</a>

				</div>  
                           <!-- 放大图片功能 -->
                <div id="fun-btn2" class="fr">
						<div class="fun-amplify">
							<span class="fr txt">Zoom</span>
						
						  <input type="range" min=1 max=10 value=5 id="zoom_range" step=1 oninput="ZoomUpdate(value)">
							<!--<s></s> -->
                            		</span>
						</div>  </div>   


            </div>
            <div class="clearfix"></div>

<div class="assemble-box fl" >
			<div class="box clearfix">
				<div class="bj-box fr" id="canvas">

					<div class="clear"></div>
					<div id="bj-main">

						
<!-- working area -->				
<form id="canvas_form">
<div class="wrapper" >
<input type="hidden" name="templateID" id="templateID" value="<%=templateID %>" />
<input type="hidden" name="userID" id="userID" value="<%=_userid %>" />


<div id="design_workarea">
<%=templateHTML%>
</div>
		<input type="hidden" name="imgData" id="imgData" />
		 <div id="viewer" class="viewer"></div>
		<input type="hidden" name="viewer_src" id="viewer_src"/>            
		<input type="hidden" name="viewer_x"  id="viewer_x"/>
		<input type="hidden" name="viewer_y"  id="viewer_y"/>            
		<input type="hidden" name="viewer_w"  id="viewer_w"/>
		<input type="hidden" name="viewer_h"  id="viewer_h"/>
		 <div id="viewer2" class="viewer" ></div>
		<input type="hidden" name="viewer2_src" id="viewer2_src"/>            
		<input type="hidden" name="viewer2_x"  id="viewer2_x"/>
		<input type="hidden" name="viewer2_y"  id="viewer2_y"/>            
		<input type="hidden" name="viewer2_w"  id="viewer2_w"/>
		<input type="hidden" name="viewer2_h"  id="viewer2_h"/>
		<input type="hidden" name="viewer3_src" id="viewer3_src"/>            
		<input type="hidden" name="viewer3_x"  id="viewer3_x"/>
		<input type="hidden" name="viewer3_y"  id="viewer3_y"/>            
		<input type="hidden" name="viewer3_w"  id="viewer3_w"/>
		<input type="hidden" name="viewer3_h"  id="viewer3_h"/>
		<input type="hidden" name="viewer4_src" id="viewer4_src"/>            
		<input type="hidden" name="viewer4_x"  id="viewer4_x"/>
		<input type="hidden" name="viewer4_y"  id="viewer4_y"/>            
		<input type="hidden" name="viewer4_w"  id="viewer4_w"/>
		<input type="hidden" name="viewer4_h"  id="viewer4_h"/>
<input type="hidden" name="txtDesignID" id="txtDesignID" value="0" />
<input type="hidden" name="ProductID_1" id="ProductID_1" value="" />
<input type="hidden" name="ProductID_2" id="ProductID_2" value="" />
<input type="hidden" name="ProductID_3" id="ProductID_3" value="" />
<input type="hidden" name="ProductID_4" id="ProductID_4" value="" />
		<input type="hidden" name="viewer5_src" id="viewer5_src"/>            
		<input type="hidden" name="viewer5_x"  id="viewer5_x"/>
		<input type="hidden" name="viewer5_y"  id="viewer5_y"/>            
		<input type="hidden" name="viewer5_w"  id="viewer5_w"/>
		<input type="hidden" name="viewer5_h"  id="viewer5_h"/>
		<input type="hidden" name="viewer6_src" id="viewer6_src"/>            
		<input type="hidden" name="viewer6_x"  id="viewer6_x"/>
		<input type="hidden" name="viewer6_y"  id="viewer6_y"/>            
		<input type="hidden" name="viewer6_w"  id="viewer6_w"/>
		<input type="hidden" name="viewer6_h"  id="viewer6_h"/>
		<input type="hidden" name="viewer7_src" id="viewer7_src"/>            
		<input type="hidden" name="viewer7_x"  id="viewer7_x"/>
		<input type="hidden" name="viewer7_y"  id="viewer7_y"/>            
		<input type="hidden" name="viewer7_w"  id="viewer7_w"/>
		<input type="hidden" name="viewer7_h"  id="viewer7_h"/>
		<input type="hidden" name="viewer8_src" id="viewer8_src"/>            
		<input type="hidden" name="viewer8_x"  id="viewer8_x"/>
		<input type="hidden" name="viewer8_y"  id="viewer8_y"/>            
		<input type="hidden" name="viewer8_w"  id="viewer8_w"/>
		<input type="hidden" name="viewer8_h"  id="viewer8_h"/>
<input type="hidden" name="ProductID_5" id="ProductID_5" value="" />
<input type="hidden" name="ProductID_6" id="ProductID_6" value="" />
<input type="hidden" name="ProductID_7" id="ProductID_7" value="" />
<input type="hidden" name="ProductID_8" id="ProductID_8" value="" />
</div>
</form>		
<!-- working area EOF-->
						
					</div>
				</div>
				

			</div>
		</div>
</td>
<td style="padding-left:6px;">
<div class="pic-select fr">
			  <div class="tab clearfix" style=" height:30px;">
				<!--  <a href="#" class="fr helplink">User Guide</a> -->
			  	  <ul class="fl">
			  	  	   <li>
			  	  	   	  Category
			  	  	   </li>
			  	  	   <li>
			  	  	   	  Decoration
			  	  	   	   <i class="remove-btn"></i>
			  	  	   </li>
			  	  	   <li>
			  	  	   	  Background
			  	  	   	   <i class="remove-btn"></i>
			  	  	   </li>
			  	  	  
			  	  </ul>
			  </div>
			  <div class="tabCon">
			  	  <div class="box">
			  	  	   <!--<div class="select-box clearfix">

			  	  	   	   <div class="price-select fl pr">
			  	  	   	   	  <span id="price-select">Price</span>
							  <dl>
							  	  <dd>
							  	  	<a href="#">USD100</a>
							  	  </dd>
							  	  <dd>
							  	  	 <a href="#">200</a>
							  	  </dd>
							  	  <dd>
							  	  	 <a href="#">2000</a>
							  	  </dd>
							  	  <dd>
							  	  	 <a href="#">Rich people</a>
							  	  </dd>
							  </dl>
			  	  	   	   </div>
			  	  	   	   <span class="pro-color fl">
			  	  	   	   	    Color
			  	  	   	   	    <i class="select-color">
			  	  	   	   	    	<s id="select-color"></s>
			  	  	   	   	    </i>
			  	  	   	   </span>
			  	  	   </div-->
						
			  	  	   <!-- Category别 -->
			  	  	   <div class="tab-ele-list">
                       		<div class="fl">
                            <input type="text" id="txtCategoryKeywords" class="text fl" /> &nbsp;&nbsp;
			  	  	   	   <input type="button" class="so-btn fl margin_left_10" id="btnCategorySearch" value="Search" />
                           </div>
				  	  	   	<div class="fl search-main-box search-main-box2">
					  	  	   	    <ul class="clearfix" id="ProductsList">

					  	  	   	    	
					  	  	   	    </ul>
					  	  	</div>
				  	  	   <div class="fr page tr" id="ProductsPage">
								
							</div>
			  	  	   </div>
			  	  	   <!-- 装饰元素 -->
			  	  	   <div class="tab-ele-list">
				  	  	   	<div class="search-main-box search-main-box2">
					  	  	   	    <ul class="clearfix" id="DecorationList">
					  	  	   	    	
					  	  	   	    </ul>
					  	  	</div>
				  	  	   <div class="page tr" id="DecorationPage">
							</div>
			  	  	   </div>

			  	  	   <!-- 背景图案 -->
			  	  	   <div class="tab-ele-list">
				  	  	   	<div class="search-main-box">
					  	  	   	    <ul class="clearfix" id="BackgroundList">
					  	  	   	    </ul>
					  	  	</div>
				  	  	   <div class="page tr"  id="BackgroundPage">
							</div>
			  	  	   </div>
			  	  </div>
			  </div>
		</div>
</td>
</tr>
</table>
		
		
	</div>

</div>




<!-- Submit我的叠图 -->
<div class="greybox">
	<div id="my-dietu" class="tck">
		 <a href="#" class="close-Btn" title="Close"></a>
		 <h2 class="t">
		 	 Publish my collage design
		 </h2>
		 <table class="my-dietu">
		 	<tr>
		 		<td class="t">
		 			Title
		 		</td>
		 		<td>
		 			<input type="text" maxlength="20" class="text jstxt" id="txtPublishTitle" placeholder="For ex：new function flippable Kitty Litty">
		 		</td>
		 	</tr>
		 	<tr>
		 		<td class="t">
		 			Tags
		 		</td>
		 		<td>
		 			<input type="text" maxlength="20" class="text jstxt" id="txtPublishTag" placeholder="For ex：new function flippable Kitty Litty">
		 		</td>
		 	</tr>
		 	<tr>
		 		<td class="t">
		 			Inspiration
		 		</td>
		 		<td>
		 			<div class="pr" id="tishi">
				 				<p class="tishi">
				 					Flippable Kitty Litty's new features as below<br>
									1.Can flip and return back to original position；<br/>2.comes with tools；<br />3. not occupy space as the space is small after folded<br>
				 				</p>
				 		<textarea name="txtPublishInspiration" id="txtPublishInspiration" rows="4" maxlength="200"></textarea>
				 	</div>
		 		</td>
		 	</tr>
		 	<!--
		 	<tr>
		 		<td class="t">
		 			Share
		 		</td>
		 		<td>
		 			<div class="bdsharebuttonbox"><a href="#" class="bds_weixin" data-cmd="weixin" title="Wechat "></a><a href="#" class="bds_tsina" data-cmd="tsina" title="Twitter"></a><a href="#" class="bds_sqq" data-cmd="sqq" title="QQ"></a><a href="#" class="bds_renren" data-cmd="renren" title="Facebook"></a><a href="#" class="bds_douban" data-cmd="douban" title="Pinterest"></a><a href="#" class="bds_mail" data-cmd="mail" title="email"></a></div>
					<script>					    window._bd_share_config = { "common": { "bdSnsKey": {}, "bdText": "", "bdMini": "2", "bdMiniList": false, "bdPic": "", "bdStyle": "0", "bdSize": "32" }, "share": {} }; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];</script>
		 		</td>
		 	</tr>
            -->
		 	<tr>
		 		<td class="t"></td>
		 		<td>
		 			<a href="#" onclick="SavePublish()" class="liji-share">
		 				Publish Now
		 			</a>
		 			<a href="#" class="quxiao js-close">Cancel</a>
		 		</td>
		 	</tr>
		 </table>
	</div>
</div>


<!-- Save 2 Draft 我的叠图 -->
<div class="greybox"  >
	<div  id="Save2Draft" class="tck">

		 <a href="#" class="close-Btn" title="Close"></a>
		 <h2 class="t">
		 	 Save my collage design
		 </h2>

		 <table class="my-dietu">
		 	<tr>
		 		<td class="t">
		 			Title
		 		</td>
		 		<td>
		 			<input type="text" id="txtDraftTitle" maxlength="20" class="text jstxt" placeholder="For ex：new function flippable Kitty Litty">
		 		</td>
		 	</tr>
		 	<tr>
		 		<td class="t">
		 			Tags
		 		</td>
		 		<td>
		 			<input type="text" maxlength="20" class="text jstxt" id="txtDraftTags" placeholder="For ex：new function flippable Kitty Litty">
		 		</td>
		 	</tr>
		 	<tr>
		 		<td class="t">
		 			Inspiration
		 		</td>
		 		<td>
		 			<div class="pr" id="Div2">
				 				<p class="tishi">
				 					Flippable Kitty Litty's new features as below<br>
									1.Can flip and return back to original position；<br/>2.comes with tools；<br />3. not occupy space as the space is small after folded<br>
				 				</p>
				 		<textarea name="" id="txtDfaftInspiration" rows="4" maxlength="200"></textarea>
				 	</div>
		 		</td>
		 	</tr>
		 	<tr>
		 		<td colspan="2">
		 			<div id="save_draft_info"></div>
		 		</td>
		 	</tr>
		 	<tr>
		 		<td class="t"></td>
		 		<td>
		 			<a href="#" onclick="SaveDraft()" class="liji-share">
		 				Save Now
		 			</a>
		 			<a href="#" onclick="CloseDraftPopup()" class="quxiao js-close">Cancel</a>
		 		</td>
		 	</tr>
		 </table>
	</div>
</div>

<div class="greybox">
    <div  id="loading" class="tck"> 
         <a href="#" class="close-Btn" title="Close"></a>
		 <h2 class="t">
		 	 Save data,please wait.....
		 </h2>
    </div>
</div>

<!-- 叠图模板，Save，Submit -->
<div class="greybox"  >
	<div id="dietu-moban" class="tck">
        <a href="#" class="close-Btn" title="Close"></a>
		<div class="tab">
			<span>Collage Template</span>
			<span>My Draft</span>
			<span>My Publish</span>
		</div>
		<div class="tabConBox">
			<div class="tabCon hid">
				 <div class="page2 tr">
				 	 <ul class="fr" id="TemplatePageList">

				 	 </ul>
				 </div>
				 <ul class="pic-list clearfix" id="CollageTemplate">
				 	 
				 </ul>
				 <div class="btn-group">
				 	 <a href="#" class="enter">
		 				Confirm
		 			</a>
		 			<a href="#" class="quxiao js-close">Cancel</a>
				 </div> 
			</div>
			<div class="tabCon hid">
				 <div class="page2 tr">
				 	 <ul class="fr" id="MyDraftPageList">
				 	 	
				 	 </ul>
				 </div>
				 <ul class="pic-list clearfix" id="MyDraftList">
				 	
				 </ul>
				 <div class="btn-group">
				 	 <a href="#" class="enter">
		 				Confirm
		 			</a>
		 			<a href="#" class="quxiao js-close">Cancel</a>
				 </div> 
			</div>
			<div class="tabCon hid">
				 <div class="page2 tr">
				 	 <ul class="fr" id="MyPublishPageList">
				 	 
				 	 </ul>
				 </div>
				 <ul class="pic-list clearfix" id="MyPublishList">
				 </ul>
				 <div class="btn-group">
				 	 <a href="#" class="enter">
		 				Confirm
		 			</a>
		 			<a href="#" class="quxiao js-close">Cancel</a>
				 </div> 
			</div>
		</div>
	</div>
</div>



<script type="text/javascript">



var isLogin = "<%=isLogion %>";


//
$(document).ready(function () {
    // get total count

    GetTotalCount();
    // GetProductsList();
    //Load background image and decoration
    LoadBackgroundImgTotal();
    LoadDecorationImgTotal();
    Log4Debug('cookie='+ $.cookie("back2Collage"));

    if("<%=isLogion %>"=="True" && $.cookie("back2Collage")>=1){
        //
        

        //Open Save Draft Dialog
        var paramString=$.cookie("collage_draft_data");
       /*
        var jsonString = '{"' + paramString.replace(/[&=]/g, function(a, b) {
            return (a == "&" ? ",\"" : "\":");
        }) + '}';
        var object = $.parseJSON(jsonString);
        */
        Log4Debug("back from login, template data="+paramString);
       // LoadDraft(paramString,1);
        LoadDesignData(paramString);
        //
         //finally , we reset the cookie

        

    }

        InitIViewer();


        $("#in").click(function(){ 
        console.log(" zoom in??");
        iCurrentDiv.iviewer('zoom_by', 1); });
        $("#out").click(function(){ iCurrentDiv.iviewer('zoom_by', -1); });
        $("#fun-reset").click(function(){ iCurrentDiv.iviewer('fit'); });
        $("#fun-down").click(function(){ iCurrentDiv.iviewer('set_zoom', 100); });
        $("#update").click(function(){ iCurrentDiv.iviewer('update_container_info'); });

        $("#fun-cz").click(function () { console.log(" fit_height??"); iCurrentDiv.iviewer('fit_height'); });
        $("#fun-zy").click(function(){ iCurrentDiv.iviewer('fit_width'); });
        $("#fun-open").click(function(){ 
            OpenTemplateDialog();
         });
         $("#fun-fabu").click(function(){ 
            PublishMyDesign();
         });
         
        $("#fun-newPro").click(function(){ 
            iv1.iviewer('reset_image'); 
            iv2.iviewer('reset_image'); 
            iv3.iviewer('reset_image'); 
            iv4.iviewer('reset_image'); 
        });

        $("#btnCategorySearch").click(function(){ 
            DoCategorySearch();
         });

  $("#fun-del").click(function()
                  {
                  	 iCurrentDiv.iviewer('reset_image'); 
                  });
                  
            
$('#viewer').on( "click", function() {
	iCurrentDiv.removeClass("DivSelected");
    iCurrentDiv=iv1;
     iCurrentDiv.addClass("DivSelected");
     //change image
    var objsrc1=iv1.iviewer("get_img_src");
     $("#imgPngsrc").attr("src",get_png_name(objsrc1));
     $("#imgJpgsrc").attr("src",objsrc1);
});  
$('#viewer2').on( "click", function() {
	iCurrentDiv.removeClass("DivSelected");
    iCurrentDiv=iv2;
     iCurrentDiv.addClass("DivSelected");
          //change image
    var objsrc1=iv2.iviewer("get_img_src");
     $("#imgPngsrc").attr("src",get_png_name(objsrc1));
     $("#imgJpgsrc").attr("src",objsrc1);
});                 
$('#viewer3').on( "click", function() {
	iCurrentDiv.removeClass("DivSelected");
    iCurrentDiv=iv3;
     iCurrentDiv.addClass("DivSelected");
          //change image
    var objsrc1=iv3.iviewer("get_img_src");
     $("#imgPngsrc").attr("src",get_png_name(objsrc1));
     $("#imgJpgsrc").attr("src",objsrc1);
});  
$('#viewer4').on( "click", function() {
	iCurrentDiv.removeClass("DivSelected");
    iCurrentDiv=iv4;
     iCurrentDiv.addClass("DivSelected");
          //change image
    var objsrc1=iv4.iviewer("get_img_src");
     $("#imgPngsrc").attr("src",get_png_name(objsrc1));
     $("#imgJpgsrc").attr("src",objsrc1);
});  
$('#viewer5').on( "click", function() {
	iCurrentDiv.removeClass("DivSelected");
    iCurrentDiv=iv5;
     iCurrentDiv.addClass("DivSelected");
          //change image
    var objsrc1=iv5.iviewer("get_img_src");
     $("#imgPngsrc").attr("src",get_png_name(objsrc1));
     $("#imgJpgsrc").attr("src",objsrc1);
});  
$('#viewer6').on( "click", function() {
	iCurrentDiv.removeClass("DivSelected");
    iCurrentDiv=iv6;
     iCurrentDiv.addClass("DivSelected");
          //change image
    var objsrc1=iv6.iviewer("get_img_src");
     $("#imgPngsrc").attr("src",get_png_name(objsrc1));
     $("#imgJpgsrc").attr("src",objsrc1);
});  

$('#viewer7').on( "click", function() {
	iCurrentDiv.removeClass("DivSelected");
    iCurrentDiv=iv7;
     iCurrentDiv.addClass("DivSelected");
          //change image
    var objsrc1=iv7.iviewer("get_img_src");
     $("#imgPngsrc").attr("src",get_png_name(objsrc1));
     $("#imgJpgsrc").attr("src",objsrc1);
});  

$('#viewer8').on( "click", function() {
	iCurrentDiv.removeClass("DivSelected");
    iCurrentDiv=iv8;
     iCurrentDiv.addClass("DivSelected");
          //change image
    var objsrc1=iv8.iviewer("get_img_src");
     $("#imgPngsrc").attr("src",get_png_name(objsrc1));
     $("#imgJpgsrc").attr("src",objsrc1);
});  

$('#fun-save').on( "click", function() {
    $("#loading").parents(".greybox").show();
    $("#loading").animate({ top: "2%" }, 300);
    //check login
    if(isLogin=="False"){
        //save data and template ID
        var template_id=$("#templateID").val();
        $.cookie("back2Collage", 1);
        $.cookie("templateID",template_id );
        var datastring = $("#canvas_form").serialize();
        $.cookie("collage_draft_data",datastring);
        window.location.href="/User/login.aspx?op=CollageCreate";
    }

	//var html=$("#canvas").html();
	//$("#innerHTMLDIV").val(html);
	//console.log("html="+html);
    SaveDataBeforePublish();

html2canvas($("#canvas"), {
    onrendered: function(canvas) {
        // canvas is the final rendered <canvas> element
        //console.log('canvas='+canvas.in);
        //$("#canvas_img").append(canvas);
        console.log('canvas='+canvas.toDataURL("image/png"));
        //console.log('canvas='+canvas.innerHTML());
        var dataURL = canvas.toDataURL("image/png");
       // $("#imgData").val(html);
       // $("#canvas_form").submit();
        console.log("sending post data to server");
        //create Json string


        $.ajax({
                      type: "POST",
                      url: "CollageSaveFile.ashx",
					  data: { 
                      'imgBase64': dataURL
					  }
        }).done(function(o) {
          console.log('saved:'+o); 
             $("#imgData").val(o);
             $("#loading").parents(".greybox").hide();
          //Popup Save2Draft
           // $("#Save2Draft").dialog("open");
                $("#Save2Draft").parents(".greybox").show();
                $("#Save2Draft").animate({ top: "2%" }, 300);

        });

        

    }
});    

    
   //$("#canvas_form").submit();
    
});                             
 	




});




   
 

    window.onload = function () {
        // 图片位置居中
        changeImg($(".mini-img > li "))
        changeImg($(".h60"))
    }

    //选择Color
    $("#select-color").bigColorpicker(function (el, color) {
        $(el).css("background-color", color);
    });



    //表单提示
    $('.jstxt').placeholder();

    // select 美化
    $(".selects").selectCss();
    //产品特色
    $("#tishi").click(function () {
        //$(this).find('.tishi').hide();
        $("#tese").focus();
    })
    $("#txtPublishInspiration").focus(function (event) {
        $("#txtPublishInspiration").keypress(function (event) {
            $(this).siblings('.tishi').hide();
        });

    });
    $("#txtPublishInspiration").blur(function (event) {
        if ($(this).val() == "") {
            $(this).siblings('.tishi').show();
        };
    });

      $("#txtDfaftInspiration").focus(function (event) {
        $("#txtDfaftInspiration").keypress(function (event) {
            $(this).siblings('.tishi').hide();
        });

    });
    $("#txtDfaftInspiration").blur(function (event) {
        if ($(this).val() == "") {
            $(this).siblings('.tishi').show();
        };
    });
    //左边功能按钮弹出框
    //查看协议
    $(".js-fun").click(function (event) {
        var objClick = $(this)
        var tckObj = "#" + objClick.attr('data-con-id');
        $(tckObj).parents(".greybox").show()

        $(tckObj).animate({ top: "2%" }, 300)

        return false;
    });
    $(".close-Btn,.js-close").click(function (event) {
        var thisPa = $(this).parents(".tck")
        thisPa.animate({
            top: "-500px"
        },
				300, function () {
				    thisPa.parents(".greybox").hide()

				});
        return false;

    });
    //Open模板，Save，Submit
    $("#dietu-moban").qTab({
        tabT: ".tab span", //tab title
        tabCon: ".tabCon", //tab Con
        addclass: "on"
    })

    $("#dietu-moban .pic-list > li").live('mouseenter', function (event) {
        $(this).addClass('on')
    }).live('mouseleave', function (event) {
        $(this).removeClass('on')
    });

    $("#dietu-moban").find('s').live('click', function (event) {
        $(this).parent().remove();
    });


    //选择价格

    $(".select-box").myLv2({
        obje1: ".price-select",
        obje2: ".price-select dl"
    })
    $(".price-select").find('a').click(function (event) {
        $("#price-select").text($(this).text())
    });


    //右边图片选择

    $(".pic-select").qTab({
        tabT: ".tab li", //tab title
        tabCon: ".tab-ele-list", //tab Con
        addclass: "on"
    })

</script>


    

</asp:Content>