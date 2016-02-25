<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="inventory.aspx.cs" Inherits="TweebaaWebApp.Product.inventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
    
</asp:Content> 

<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

    <link href="../Css/submit.css" rel="stylesheet" type="text/css" />
    <link href="../Css/selectCss.Css" rel="stylesheet" type="text/css" />
    <%--<script src="../Js/jquery-hcheckbox.js" type="text/javascript"></script>--%>
    <script src="../Js/jquery.placeholder2.js" type="text/javascript"></script>
    <script src="../Js/biaodan2.js" type="text/javascript"></script>
    <script src="../Js/selectCss.js" type="text/javascript"></script>
    <script src="../Js/newfloat.js" type="text/javascript"></script>
    <script src="../Js/myLv2.js" type="text/javascript"></script>
    <script src="../Js/jquery.json-2.2.js" type="text/javascript"></script>
    <script src="../Kindeditor/kindeditor-4.1.10/kindeditor-min.js" type="text/javascript"></script>
    <script src="../Kindeditor/kindeditor-4.1.10/lang/zh_CN.js" type="text/javascript"></script>
    <script src="../Js/iColorPicker.js" type="text/javascript"></script>
    <style type="text/css">

    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
<input type="hidden" id="hidBarcode" value='<%=Barcode%>' />
<div class="fabubox fill-inventory">
		<form action="">
		<div class="w950" style=" width:1000px;">
			
			<div class="title">
				<span class="t"> 
					Product Supply Form  
				</span>
				<span class="txt">
					<a href="#">Current product name : <%=proName %></a>
					<%--<i>On 2014／2／22   20:20passed evaluation, now in price competitive stage for supply</i>--%>
				</span>

			</div>
			<div class="ps tc">
				<span>
					Please fill the form. We will consider different factors such as price, logistics etc to choose product supplier. Thank you for your cooperation！
				</span>
			</div>
			<!-- 产品基本信息 -->

			<div class="basic-infor">
				
				 <span class="title ">
				 	Product Basic Info
				 </span>
				 <table>
				 	<tr>
				 		<td class="t">Product Name</td>
				 		<td width="30"></td>
				 		<td width="570">
                        <input type="text" id="pro_id_record" value='<%=proId %>' style=" display:none;" />
                             <asp:PlaceHolder ID="ph_prodetailid" runat="server"></asp:PlaceHolder>
                            <label id="userId" style=" display:none;" value='<%=userId %>'></label>
                             <label id="proId" style=" display:none;" value='<%=proId %>'></label>
				 			<label id="proName" value='<%=proName %>'><%=proName %></label>
				 		</td>
				 	</tr>
				 	<tr>
				 		<td class="t">Product Category</td>
				 		<td width="30"></td>
				 		<td>
				 			<label id="proCate"><%=proCate %></label>
				 		</td>
				 	</tr>
				 	<tr>
				 		<td class="t"><b>＊</b>Intellectual Property</td>
				 		<td width="30"></td>
				 		<td width="570">
				 			<div class="radiolist" style="font-size:14px; ">
                                 <asp:PlaceHolder ID="ph_proRight" runat="server"></asp:PlaceHolder>
								<%--<input name='proRight' type="radio" value='1' /><label class="hRadio_Checked">自有产权</label>
								<input name='proRight' type="radio" value='2' /><label>授权经销</label>
								<input name='proRight' type="radio" value='3' /><label>无</label>--%>
							</div>
				 		</td>
				 	</tr>
				 	<tr>
				 		<td class="t"><b>＊</b>Country of Origin</td>
				 		<td width="30"><em class="showbox">
				 			<div class="thistips">
				 				<i></i>
				 				<p>
				 					Inventory Location.
				 				</p>
								
				 			</div>
				 		</em></td>
				 		<td width="570">
				 			<div class="selectBox pr fl">
		                            <select id="proAddress" name="" class="selects">
                                        <asp:PlaceHolder ID="ph_proAddress" runat="server"></asp:PlaceHolder>
		                            </select>                                   
		                    </div>
				 		</td>
				 	</tr>
				 	<tr>
				 		<td class="t"><b>＊</b>Product Sample</td>
				 		<td width="30"><em class="showbox">
				 			<div class="thistips">
				 				<i></i>
				 				<p>
				 					Product Name will show under the picture. Please try to put attractive product features to attract more people to evaluate. <br />For example： <br />Not Recommend：Kitty Litty <br />Recommend：Patent Design won't make your hand dirty plus flip the tray in seconds
				 				</p>
								
				 			</div>
				 		</em></td>
				 		<td width="570">
				 			<div id="rad_example" class="radiolist sample-price" style="font-size:14px; ">
                              <asp:PlaceHolder ID="hp_proExample" runat="server"></asp:PlaceHolder>
								<%--<input name='proExample' type="radio" value='1' checked/><label class="hRadio_Checked">免费样品</label>
								<input name='proExample' type="radio" value='2' /><label>收费样品</label>
								<span class="hideInput">
									￥<input type="text" id="proExamplePrice" style="width:45px;"/>
								</span>
								<input name='proExample' type="radio" value='3' /><label>不提供样品</label>--%>
							</div>

				 		</td>
				 	</tr>
				 	<tr>
				 		<td class="t"><b>＊</b>Minimum Order Quantity</td>
				 		<td width="30"><em class="showbox">
				 			<div class="thistips">
				 				<i></i>
				 				<p>
				 					Product Minimum Order.
				 				</p>
								
				 			</div>
				 		</em></td>
				 		<td width="570">
				 			<div class="pr fl">
				 				<i class="icon-btn bianji"></i>
                                <asp:PlaceHolder ID="ph_smallNum" runat="server"></asp:PlaceHolder>
				 				<%--<input type="text" class="text" id="smallNum" style="width:120px; padding-right: 50px;" onkeyup="value=value.replace(/[^\d.]/g,'')">--%>
				 			</div>
				 		</td>
				 	</tr>
				 	<tr>
				 		<td class="t"><b>＊</b>Product Item Number</td>
				 		<td width="30"><em class="showbox">
				 			<div class="thistips">
				 				<i></i>
				 				<p>
				 					Please input the product item number
				 				</p>
								
				 			</div>
				 		</em></td>
				 		<td width="570">
				 			<div class="pr fl">
				 				<i class="icon-btn bianji"></i>
                                <asp:PlaceHolder ID="ph_proNum" runat="server"></asp:PlaceHolder>
				 				<%--<input type="text" id="proNum" class="text" style="width:120px; padding-right: 50px;" >--%>
				 			    </div>
				 		</td>
				 	</tr>
				 	<tr>
				 		<td class="t"><b>＊</b>Any Inventory</td>
				 		<td width="30"><em class="showbox">
				 			<div class="thistips">
				 				<i></i>
				 				<p>
				 					Product Name will show under the picture. Please try to put attractive product features to attract more people to evaluate.  <br />For Example： <br />Not Recommend：Kitty Litty <br />Recommend：Patent Design won't make your hand dirty plus flip the tray in seconds
				 				</p>
								
				 			</div>
				 		</em></td>
				 		<td width="570">
				 			<div id="rad_stock" class="radiolist sample-price" style="font-size:14px; ">
                            <asp:PlaceHolder ID="ph_stock" runat="server"></asp:PlaceHolder>
								<%--<input name='stock' type="radio" value='1' checked/><label class="hRadio_Checked">有</label>
								<input name='stock' type="radio" value='2' /><label>无</label>
								<span class="hideInput">
									请输生产周期（天）<input type="text" id="stockNum" style="width:65px;"/>
								</span>--%>
								
							</div>
				 		</td>
				 	</tr>
				 </table>
			</div>

			<!-- 产品颜色 -->

			<!-- 规格及包装 -->
			<div class="basic-infor spe-packing" style=" padding-right:5px; padding-left:5px;">
				 	<span class="title ">
				 	Specification and Packaging
				    </span>
			
				 <table>
				 	<tr>
				 		<td class="t"><b>＊</b>Speicification</td>
				 		<td width="30"><em class="showbox">
				 			<div class="thistips">
				 				<i></i>
				 				<p>
				 					Please choose the best product packaging
				 				</p>
								
				 			</div>
				 		</em></td>
				 		<td width="570" id="proRule">
				 			<div class="selectBox pr fl" style=" z-index:100;">
		                            <select name="" class="selects" id="cima">
                                        <asp:PlaceHolder ID="ph_ruleddl" runat="server"></asp:PlaceHolder>
		                                <%--<option selected="selected" value="0">规格</option>
		                                <option value="1">型号</option>
		                                <option value="2">衣服尺码</option>
		                                <option value="3">其它</option>--%>
		                            </select>

                                    <span  id="span_color"><input type="text" id="colo2r" class="iColorPicker" style=" display:none;" /></span>
                                    <span style=" text-align:left;">
                                    <a href="javascript:void(0)" class="add-eg l" id="addRule" onclick="AddProRule()">Add</a>
                                    </span>
                                    
		                    </div>
		                    <div class="clear"></div>
                            <div id="ruleArea">
                                <asp:PlaceHolder ID="hp_ruleArea" runat="server"></asp:PlaceHolder>
                            </div>

                            <!--rule text start-->

                            <!--rule text end-->


		                    <%--<div class="eg-box">
		                    	<input type="text" class="txt"  value="example：10*10*10cm"  onfocus="if(this.value=='example：10*10*10cm')this.value='';this.style.color='#333'" onblur="if(this.value==''){this.value='example：10*10*10cm';this.style.color='#ccc'}"  /> <a href="#" class="add-eg l" id="add-eg">增加</a>
		                    </div>
		                    <div class="js-eg-box" tid="rule">
		                    	<input type="text" class="txt"  value="example：10*10*10cm"  onfocus="if(this.value=='example：10*10*10cm')this.value='';this.style.color='#333'" onblur="if(this.value==''){this.value='example：10*10*10cm';this.style.color='#ccc'}"  /><a href="#" class="del-parent l">删除</a>
		                    </div>--%>
				 		</td>
				 	</tr>
				 </table>
                 <div class="luru-ps">
                 	! Click add button to add details,and Please save it then fill the price area
                 </div>
				 <div class="luru-box" style=" width:98%;">
				 	 <div class="luru-t clearfix" style=" padding-left:5px;">
				 	 	  
						  <ul class="fl">
                             <li>
                                <a href="javascript:void(0)" class="jsBtn" onclick="addRuleTr2()">Add</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)" class="jsBtn" onclick="deleteRuleTr2()">Delete</a>
                            </li>
						  	<li>
						  		<a href="javascript:;" class="jsBtn">Input Supply To Tweebaa</a>
						  		<div class="p-tck">
						  			<a href="javascript:;" class="closeBtn"></a>
						  			<h5>Input Supply To Tweebaa</h5>
						  			<div class="kucun-num">Supply To Tweebaa：<input type="text" id="btntxtstock" /></div>
						  			<div class="btn-groups"><input type="button" class="enter" onclick="btntxtInputFuc('stock')" value="Confirm" />
						  				<a href="#" class="cancel l">Cancel</a>
						  			</div>
						  			<div class="wz">						  				
                                        Input product inventory quantity, then click <b>Save</b>，that quantity applied to all <font class="h"> chosen</font>	Selected product
						  			</div>
						  		</div>
						  	</li>
						  	<li>
						  		<a href="javascript:;" class="jsBtn">Input volume</a>
						  		<div class="p-tck">
						  			<a href="javascript:;" class="closeBtn"></a>
						  			<h5>Input LCL volume</h5>
						  			<div class="kucun-num">Individual box dims：<input type="text" id="btntxtprobulk" /></div>
						  			<div class="btn-groups">　　　　　<input type="button" class="enter" onclick="btntxtInputFuc('probulk')" value="Confirm" />
						  				<a href="#" class="cancel l">Cancel</a>
						  			</div>
						  			<div class="wz">						  				
                                        Input individual box dims，then click <b>Save</b>，that quantity applied to all  <font class="h">Chosen</font>	Selected product
						  			</div>
						  		</div>
						  	</li>
						  	<li>
						  		<a href="javascript:;" class="jsBtn">Input Product's weight</a>
						  		<div class="p-tck">
						  			<a href="javascript:;" class="closeBtn"></a>
						  			<h5>Input Product's weight</h5>
						  			<div class="kucun-num">Product's weight：<input type="text" id="btntxtproweight" /></div>
						  			<div class="btn-groups">　　　　　<input type="button" class="enter" onclick="btntxtInputFuc('proweight')" value="Confirm" />
						  				<a href="#" class="cancel l">Cancel</a>
						  			</div>
						  			<div class="wz">						  				
                                        Input carton weight，then click <b>Save</b>，that quantity will apply to others <font class="h">Chosen</font>	Selected product
						  			</div>
						  		</div>
						  	</li>
						  	<li>
						  		<a href="javascript:;" class="jsBtn">Input master carton dimension</a>
						  		<div class="p-tck">
						  			<a href="javascript:;" class="closeBtn"></a>
						  			<h5>Input master carton dimension</h5>
						  			<div class="kucun-num">Master carton weight：<input type="text" id="btntxtprobox" /></div>
						  			<div class="btn-groups">　　　　<input type="button" class="enter" onclick="btntxtInputFuc('probox')" value="Confirm" />
						  				<a href="#" class="cancel l">Cancel</a>
						  			</div>
						  			<div class="wz">	
                                        Input carton weight，then click <b>Save</b>，that quantity will apply to others <font class="h">Chosen</font>	Selected product
						  			</div>
						  		</div>
						  	</li>
						  	<li>
						  		<a href="javascript:;" class="jsBtn">Input Carton Weight</a>
						  		<div class="p-tck">
						  			<a href="javascript:;" class="closeBtn"></a>
						  			<h5>Input LCL carton weight</h5>
						  			<div class="kucun-num">Carton weight：<input type="text" id="btntxtproboxweight" /></div>
						  			<div class="btn-groups">　　　　　<input type="button" class="enter" onclick="btntxtInputFuc('proboxweight')" value="Confirm" />
						  				<a href="#" class="cancel l">Cancel</a>
						  			</div>
						  			<div class="wz">						  				
                                        Input carton weight，then click <b>save</b>，that quantity will apply to all <font class="h">Chosen</font>	Selected product
						  			</div>
						  		</div>
						  	</li>
                            
						  </ul>
				 	 </div>
				 	 <div class="clear"></div>
                     

				 	 <table id="tbRule">
				 	 	<tr id="tbHead">
                        <th style=" width:30px;">
                            <input type="checkbox" id="chkall" style="margin-left:2px; margin-top:15px;" onclick="chkAllFuc()" />
                            <script type="text/javascript">
                                function chkAllFuc() {
                                    var chkAll = $("#chkall").attr("checked");
                                    if (chkAll == "checked") {
                                        $("#tbRule").find("input[class='chk']").attr("checked", "checked");
                                    } else {
                                        $("#tbRule").find("input[class='chk']").removeAttr("checked");
                                    }
                                }
                            </script>
                            <span class="t">&nbsp;<em class="showbox">
				 	 			<div class="thistips">
				 				<i></i>
				 				<p>
				 					delete
				 				</p>
								
				 			</div>

				 	 		</em></span></th>
				 	 		<th style=" width:120px;"><span class="t">Specs<em class="showbox">
				 	 			<div class="thistips">
				 				<i></i>
				 				<p>
				 					Specs
				 				</p>
								
				 			</div>

				 	 		</em></span></th>
                            <th style=" width:60px;"><span class="t">Color<em class="showbox">
				 	 			<div class="thistips">
				 				<i></i>
				 				<p>
				 					Color
				 				</p>
								
				 			</div>

				 	 		</em></span></th>
                            <th style=" width:120px;"><span class="t">Bar code<em class="showbox">
				 	 			<div class="thistips">
				 				<i></i>
				 				<p>
				 					Bar code
				 				</p>
								
				 			</div>

				 	 		</em></span></th>
				 	 		<th style=" width:60px;"><span class="t">Supply to Tweebaa<em class="showbox">
				 	 			<div class="thistips">
				 				<i></i>
				 				<p>
				 					Quantity to Tweebaa, It must be a number
				 				</p>
								
				 			</div>

				 	 		</em></span></th>
				 	 		<th style=" width:100px;">(SKU)<em class="showbox"><div class="thistips">
				 				<i></i>
				 				<p>
				 					Unique Id (SKU)number
				 				</p>
								
				 			</div></em></th>
				 	 		<th style=" width:70px;">Volume<em class="showbox"><div class="thistips">
				 				<i></i>
				 				<p>
				 					Product's dimension
				 				</p>
								
				 			</div></em></th>
				 	 		<th style=" width:70px;"><span class="t">
				 	 			Product's weight<br />(kg)<em class="showbox"><div class="thistips">
				 				<i></i>
				 				<p>
				 					Product's weight
				 				</p>
								
				 			</div></em>
				 	 		</span>
								
				 	 		</th>
				 	 		<th style=" width:60px;"><span>
				 	 			Master carton dims<em class="showbox"><div class="thistips">
				 				<i></i>
				 				<p>
				 					How many pcs in each carton?
				 				</p>
								
				 			</div></em>
				 	 		</span></th>
				 	 		<th style=" width:70px;">Carton box dims<em class="showbox"><div class="thistips">
				 				<i></i>
				 				<p>
				 					dims：Lcm*Wcm*Hcm
				 				</p>
								
				 			</div></em></th>
				 	 		<th style=" width:70px;"><span>Carton weight(kg)  <em class="showbox"><div class="thistips">
				 				<i></i>
				 				<p>
				 					
									Weight per box, It must be a number
				 				</p>
								
				 			</div></em></span></th>
                            <th><span>Save <em class="showbox"><div class="thistips">
				 				<i></i>
				 				<p>
				 					save current data
				 				</p>
								
				 			</div></em></span></th>
                            <th><span>Pricing <em class="showbox"><div class="thistips">
				 				<i></i>
				 				<p>
                                  open price area
				 				</p>
								
				 			</div></em></span></th>
				 	 	</tr>
                        <%=_tbRuleTrHtml%>

				 	 </table>
				 </div>
			</div>

            <!--价格区间开始-->
            <div id="divPrice" class="p-tck p-tck2" style=" display:none;">
						  			<a href="javascript:;" class="closeBtn"></a>
						  			<h5>Input inventory of selected productQuantity<a  class="add-eg l" id="A1" onclick="AddPriceArea()" style=" cursor:pointer;">Add</a></h5>
						  			<dl id="pricedl" tips="">
						  				<%--<dd>
                                            从<input type='text' id='pricefrom' class='livetxt'  />
                                            到<input type='text' id='priceto' class='livetxt'   />
                                            ￥<input type='text' id='price' class='livetxt'  />
                                            <a href='javascript:void(0)' onclick='deletePriceArea(this)'>删除</a>
                                        </dd>--%>
						  			</dl>
						  			<div class="btn-groups">　<input type="button" class="enter" onclick="SavePriceArea()" value="Save" />
						  				<a href="#" class="cancel l">Cancel</a>
						  			</div>
						  			<div class="wz">			
                                        Input Supplier Price，then click <b>Save</b>，that quantity will apply to all <font class="h">Chosen</font>	Selected Product
						  			</div>
			</div>
            <!--价格区间结束-->
			
			<!-- 产品详情 -->
			<div class="basic-infor porduct-infor">
				<span class="title">
				 	Detailed Description
				 </span>
				 <table>
				 	<tr>
				 		<td  class="t"><b>＊</b>Material</td>
				 		<td width="30"></td>
				 		<td width="570">
                            <input type="text" id="proOtherId" style="display:none;" value='<%=proOtherId%>' />
				 			<input type="text" id="procaizhi" class="text" value='<%=proCaiZhi %>' placeholder="Product Material"  style="width:320px;">
				 		</td>
				 	</tr>
				 	<tr>
				 		<td class="t">
				 			Product Summary
				 		</td>
				 		<td>
				 			
				 		</td>
				 		<td>
                             <form name="example">
				 			<textarea id="procaizhicontent"  name="content" style="width:680px;height:250px;"><%=proCaiZhiContent %></textarea>
                                   <%--<script type="text/javascript">
                                       var editor;
                                       KindEditor.ready(function (K) {
                                           editor = K.create('#procaizhicontent', {
                                               allowFileManager: true,
                                               items: ['source', 'fontname', 'fontsize', 'forecolor', 'textcolor', 'bold', 'bgcolor', 'underline', 'removeformat', 'italic', 'insertunorderedlist',
                                                'preview', 'selectall', 'justifyleft', 'justifycenter', 'justifyright', 'emoticons', 'link', 'unlink', 'image']
                                           });
                                       });

                                    </script>--%>

                             <script type="text/javascript">
                                 var editor;
                                 KindEditor.ready(function (K) {
                                      editor = K.create('#procaizhicontent', {
                                         langType : 'en',
                                         cssPath: '../Kindeditor/kindeditor-4.1.10/plugins/code/prettify.css',
                                         uploadJson: '../Kindeditor/kindeditor-4.1.10/asp.net/upload_json.ashx',
                                         fileManagerJson: '../Kindeditor/kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                                         allowFileManager: true,
                                         afterCreate: function () {
                                             var self = this;
                                             K.ctrl(document, 13, function () {
                                                 self.sync();
                                                 K('form[name=example]')[0].submit();
                                             });
                                             K.ctrl(self.edit.doc, 13, function () {
                                                 self.sync();
                                                 K('form[name=example]')[0].submit();
                                             });
                                         }
                                     });
                                     //prettyPrint();
                                 });
	</script>
				 			<p class="tr ts">
				 				（5000 words max，will remind user after typed 4500 words）
				 			</p>
                                 </form>
				 		</td>
				 	</tr>

				 </table>
			</div>

			<!-- 产品详情 -->
			<div class="basic-infor warehouse-infor">
				 <div style="padding-left: 25px;">
					<span class="title">
					 	Warehouse Info
					 </span>
			     </div>
				 <table>
				 	<tr>
				 		<td class="t"><b>＊</b>Drop shipping provided?</td>
				 		<td width="30">
				 			<em class="showbox">
				 				<div class="thistips" style="display: none;">
				 					<i></i>
				 					<p>
				 						Drop shipping refers to supplier who can courier a single item to consumer directly.
				 					</p>
				 				</div>
				 			</em>

				 		</td>
				 		<td width="570">
				 			<div class="radiolist" style="font-size:14px; " id="rescind">
                                 <asp:PlaceHolder ID="ph_proSend" runat="server"></asp:PlaceHolder>
								<%--<input name="prosend" type="radio" value="1" checked="" style="display: none;"><label class="hRadio_Checked hRadio">提供</label>
								<input name="prosend" type="radio" value="2" style="display: none;"><label class="hRadio">不提供</label>--%>
								
							</div>
				 		</td>
				 	</tr>
				 	<tr id="fahuo-area">
				 		<td class="t"><b>＊</b>Sales Territory</td>
				 		<td width="30">
				 			<em class="showbox">
				 				<div class="thistips" style="display: none;">
				 					<i></i>
				 					<p>
				 						Supplier product can send To which country 
				 					</p>
				 				</div>
				 			</em>
				 		</td>
				 		<td width="570">
				 			<div id="chklist" tip="prosendarea" class="chklist address-box">
                                 <asp:PlaceHolder ID="ph_sendArea" runat="server"></asp:PlaceHolder>
									<%--<input type="checkbox" value="1"  style="display: none;"><label  class="checkbox" >
									仅限生产国 </label>
									<input type="checkbox"  style="display: none;" value="2"><label  class="checkbox">
									全世界</label>	
									<input type="checkbox"  style="display: none;" value="3"><label  class="checkbox">
									北美</label>
									<input type="checkbox"  style="display: none;" value="4"><label  class="checkbox">
									澳洲</label>
									<input type="checkbox"  style="display: none;" value="5"><label  class="checkbox">
									亚洲</label>
									</div>--%>
				 		</td>
				 	</tr>
				 	<tr id="haiwai1">
				 		<td class="t"><b>＊</b>Overseas Warehouse</td>
				 		<td width="30">
				 			<em class="showbox">
				 				<div class="thistips" style="display: none;">
				 					<i></i>
				 					<p>
                                         Overseas Warehouse refers to supplier has inventory in oversea warehouse 
				 						
				 					</p>
				 				</div>
				 			</em>
				 		</td>
				 		<td width="570">
				 			<div id="rad_cangku" class="radiolist sample-price" style="font-size:14px; ">
                            <asp:PlaceHolder ID="ph_outStock" runat="server"></asp:PlaceHolder>
								<%--<input name="prostockout" type="radio" value="1" checked="" style="display: none;"><label class="hRadio_Checked hRadio">提供</label>
								<input type="text" id="prostockoutinfo"  placeholder="国家，地区" class="jsinput"/>
								<input name="prostockout" type="radio" value="2" style="display: none;"><label class="hRadio">不提供</label>
								--%>
							</div>
				 		</td>
				 	</tr>
					<tr>
				 		<td class="t"><b>＊</b>After Sale Service</td>
				 		<td width="30">
				 			<em class="showbox">
				 				<div class="thistips" style="display: none;">
				 					<i></i>
				 					<p>
				 						Do we provide any refund or exchange policy? If yes, please state,
				 					</p>
				 				</div>
				 			</em>
				 		</td>
				 		<td width="570">
				 			<div id="rad_service" class="radiolist sample-price" style="font-size:14px; ">
                            <asp:PlaceHolder ID="ph_saleservice" runat="server"></asp:PlaceHolder>
								<%--<input name="prosaleservice" type="radio" value="11" checked="" style="display: none;"><label class="hRadio_Checked hRadio">提供</label>
								<input type="text" id="prosaleserviceinfo" placeholder="example 保修，无偿退换货等" class="jsinput"/>
								<input name="prosaleservice" type="radio" value="21" style="display: none;"><label class="hRadio">不提供</label>
								--%>
							</div>
				 		</td>
				 	</tr>
				 </table>
			</div>
			<div class="result tc">
				<a href="#" class="btn clear-btn fr" onclick="location.reload()">Clear</a>
				<%--<a href="javascript:void(0)" onclick="SendToServer('save')" class="btn save-btn fr">保存草稿</a>--%>
                <%=_saveBtn %>
				<a href="#" class="btn return-btn fl" onclick="javascript:history.go(-1)">Back</a>
				<%--<a href="javascript:void(0)" onclick="SendToServer('send')" class="yulanbtn">发送供货单</a>--%>
                <%=_submitBtn %>

			</div>
			
		</div>
		</form>
</div>


<!-- 发布成功 -->

<div class="greybox">
	<div class="clearAllInfor">
		<a href="javascript:;" class="closeBtn"></a>
		<p>
			Content will delete completley，you need to start all again。
			Confirm?
		</p>
		<div class="tc">
			<a href="#" class="cancel-btn">Cancel</a>
			<a href="#" class="enter-btn">Confirm</a>
		</div>
	</div>
</div>




<!-- 浮动在线咨询 -->
<div id="floatALink">
	<a href="#" class="zxzz">Online<br>Help</a>
	<a href="#" id="gotoTop">Back<br>Top</a>
</div>
<!-- 浮动在线咨询 -->



<!--html end-->

        <script type="text/javascript">
            ; (function ($) {
                $.fn.hcheckbox = function (options) {
                    $(':checkbox+label', this).each(function () {
                        $(this).addClass('checkbox');
                        if ($(this).prev().is(':disabled') == false) {
                            if ($(this).prev().is(':checked'))
                                $(this).addClass("checked");
                        } else {
                            $(this).addClass('disabled');
                        }
                    }).click(function (event) {
                        if (!$(this).prev().is(':checked')) {
                            $(this).addClass("checked");
                            $(this).prev()[0].checked = true;
                            var worldwide = $(this).html();
                            if ($.trim(worldwide) == "Worldwide") {
                                $(this).parent().find("input").each(function () {
                                    if ($(this).attr("value") != "2") {
                                        $(this).removeAttr("checked");
                                    }
                                });
                                $(this).parent().find("label").each(function () {
                                    if ($.trim($(this).html()) != "Worldwide") {
                                        $(this).attr("class", "checkbox"); 
                                    }
                                });
                                
                            } else {
                                $(this).parent().find("label").each(function () {
                                    if ($.trim($(this).html()) == "Worldwide") {
                                        $(this).attr("class", "checkbox");
                                        $(this).prev().eq(0).removeAttr("checked");
                                    }
                                });
                            }
                        }
                        else {
                            $(this).removeClass('checked');
                            $(this).prev()[0].checked = false;
                            //cheExtend();
                        }
                        event.stopPropagation();
                    }
                    ).prev().hide();
                }

                $.fn.hradio = function (options) {
                    var self = this;
                    return $(':radio+label', this).each(function () {
                        $(this).addClass('hRadio');
                        if ($(this).prev().is("checked"))
                            $(this).addClass('hRadio_Checked');
                    }).click(function (event) {
                        $(this).siblings().removeClass("hRadio_Checked");
                        if (!$(this).prev().is(':checked')) {
                            $(this).addClass("hRadio_Checked");
                            $(this).prev()[0].checked = true;
                        }

                        event.stopPropagation();
                    })
                    .prev().hide();
                }

            })(jQuery)
    </script>

 <script type="text/javascript">
        //表单提示
        $('input, textarea').placeholder();
        //表单美化
        $('#chklist').hcheckbox();


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
            $(this).addClass('hover')
            $(this).find(".floatDiv").stop().animate({ top: 0 }, 100)
        }).live('mouseleave', function (event) {
            $(this).removeClass('hover')
            $(this).find(".floatDiv").stop().animate({ top: "-110px" }, 100)
        });

		
    </script>

<script type="text/javascript">
        $(function () {
            //表单提示
            $('.jstxt,.jsinput').placeholder();

            // select 美化
            $(".selects").selectCss();
            // 第一个价格显示
            $(".price-section").eq(0).show()


            //录入弹出框
            $(".luru-t").find('li').each(function (index, el) {
                $(this).myLv2({
                    obje1: ".jsBtn",
                    obje2: ".p-tck"
                })
            });
            $(".closeBtn,.cancel").click(function (event) {
                $(this).parents(".p-tck").hide();
                return false;
            });

            $(".spe-packing").mouseenter(function (event) {
                $(this).addClass('on')
            }).mouseleave(function (event) {
                $(this).removeClass('on')
            });
            //ie7问题
            $(".spe-packing").addClass('on')
            setTimeout(function () {
                $(".spe-packing").hasClass('on')
            }, 200)

        });
</script>

<script type="text/javascript">
    $(function () {
        // 封面事件
        $(".fengmian .btn-group").find("a").click(function (event) {


            //获取新的数组
            var fmImgArr = []
            var imglen = $(".fengmian").find("img").length;
            for (var i = 0; i < imglen; i++) {
                var imgUrl = $(".fengmian").find("img").eq(i).attr("src")
                fmImgArr.push(imgUrl)
            };

            var nowindex = 0
            var nextindex = 1;

            if ($(this).is(".moveLeft")) {
                var thisindex = $(".fengmian .moveLeft").index(this);
                if (thisindex > 0) {
                    nowindex = thisindex
                    nextindex = thisindex - 1;
                    //刷新数组
                    changeArrIndex(fmImgArr, nowindex, nextindex);

                    //图片位置更新
                    for (var ii = 0; ii < fmImgArr.length; ii++) {
                        $(".fengmian").find("img").eq(ii).attr("src", fmImgArr[ii])
                    };
                };

            };


            if ($(this).is(".moveRight")) {
                var thisindex = $(".fengmian .moveRight").index(this);
                if (thisindex < imglen) {
                    nowindex = thisindex
                    nextindex = thisindex + 1;
                    //刷新数组
                    changeArrIndex(fmImgArr, nowindex, nextindex);

                    //图片位置更新
                    for (var ii = 0; ii < fmImgArr.length; ii++) {
                        $(".fengmian").find("img").eq(ii).attr("src", fmImgArr[ii])
                    };
                };
            }


            //删除图片
            if ($(this).is(".delthis")) {

                var thisindex = $(".fengmian .delthis").index(this);
                if (thisindex != 0) {
                    $(this).parents('dd').find("img").remove()
                    $(".fengmian").append($(this).parents('dd'))
                }
                else {
                    $(this).parents('dd').find("img").remove()
                    $(".fengmian").append($(this).parents('dd'))

                    $(".fengmian dd:first").addClass('first').siblings('dd').removeClass('first')
                }
            }
            return false;

        });


        function changeArrIndex(arrr, am, bm) {
            var mm = null;
            mm = arrr[am]
            arrr[am] = arrr[bm]
            arrr[bm] = mm
        }

    })
</script>

<script type="text/javascript">
    $(function () {
        $('.radiolist').hradio();
        //问好提示
        $(".showbox").mouseenter(function (event) {
            $(this).find(".thistips").show().parents("th").css('zIndex', '55000');
        }).mouseleave(function (event) {
            $(this).find(".thistips").hide().parents("th").css('zIndex', '1');
        });


        //增加和减少 价格区间
        var jiaObj = $(".add-sale-btn").find('.jia')
        var jianObj = $(".add-sale-btn").find('.jian')
        var sectionNum = 0;
        jiaObj.click(function () {
            sectionNum++
            if (sectionNum >= 9) {
                sectionNum = 9
                alert("Up to 10 interval")
            };
            $(".price-section").eq(sectionNum).show();
            console.log(sectionNum)
        });
        jianObj.click(function () {
            sectionNum--;
            if (sectionNum <= 0) {
                sectionNum = 0
            };
            $(".price-section").eq(sectionNum + 1).hide();

            console.log(sectionNum)
        })
        for (var iu = 0; iu < $(".price-section").length; iu++) {
            $(".price-section").eq(iu).css({
                zIndex: $(".price-section").length - iu + 5
            });
        };
        //产品特色
        $("#tishi").click(function () {
            //$(this).find('.tishi').hide();
            $("#tese").focus();
        })
        $("#tese").focus(function (event) {
            $("#tese").keypress(function (event) {
                $(this).siblings('.tishi').hide();
            });

        });


        $("#tese").blur(function (event) {
            if ($(this).val() == "") {
                $(this).siblings('.tishi').show();
            };
        });


        //清除弹出
        $(".clear-btn").click(function (event) {
            $(".clearAllInfor").parents(".greybox").show();
            return false;
        });

        $(".closeBtn,.cancel-btn,.enter-btn").click(function (event) {
            $(".greybox").hide();

            if ($(this).is(".enter-btn")) {
                window.location.reload();
            };
        });


        // 样品费用
        $("#rad_example").find('.hRadio').click(function (event) {
            if ($(this).attr("value") == 2) {

                $(this).siblings('span').show()
            } else {
                $("#proExamplePrice").val('');
                $(this).siblings('span').hide()
            }
        });

        // 是否有库存
        $("#rad_stock").find('.hRadio').click(function (event) {
            if ($(this).attr("value") == 2) {
                $(this).siblings('span').show()
            } else {
                $("#stockNum").val('');
                $(this).siblings('span').hide()
            }
        });


        // 海外仓库
        $("#rad_cangku").find('.hRadio').click(function (event) {
            if ($(this).attr("value") == 1) {
                $("#prostockoutinfo").show()
            } else {
                $("#prostockoutinfo").val('').hide();
                //$(this).siblings('span').hide()
            }
        });







        //售后服务
        $("#rad_service").find('.hRadio').click(function (event) {
            if ($(this).attr("value") == 1) {
                $("#prosaleserviceinfo").show();
            } else {
                $("#prosaleserviceinfo").val('').hide();
                //$(this).siblings('span').hide()

            }
        });



        //增加例子
        var egBox = '<div class="js-eg-box"><input type="text" class="txt" value="example：10*10*10cm" onfocus="if(this.value==\'example：10*10*10cm\')this.value=\'\';this.style.color=\'#333\'" onblur="if(this.value==\'\'){this.value=\'example：10*10*10cm\';this.style.color=\'#ccc\'}" /><a href="#" class="del-parent l">删除</a>'
        $("#add-eg").click(function (event) {
            $(".eg-box").after(egBox)
            $(".livetxt").placeholder()
            return false;
        });

        $(".del-parent").live('click', function (event) {
            $(this).parent().remove();
            return false;
        });

    })
</script>

    <script src="../MethodJs/inventory.js" type="text/javascript"></script>
    <script type="text/javascript">
        //首次加载页面时要显示的一些控件

        $(function () {
            //产品样品
            var proExamplePrice = $("#proExamplePrice").val();
            if (proExamplePrice != null && proExamplePrice.length > 0)
                $("#proExamplePrice").parent().css("display", "inline");


            //是否有库存
            var stock = $("#stockNum").val();
            if (stock != null && stock.length > 0)
                $("#stockNum").parent().css("display", "inline");

            //售后服务
            var sale = $("#prosaleserviceinfo").val();
            if (sale != null && sale.length > 0)
                $("#prosaleserviceinfo").show();
            else
                $("#prosaleserviceinfo").hide();



            //海外仓库
            var haiw = $("#prostockoutinfo").val();
            if (haiw != null && haiw.length > 0)
                $("#prostockoutinfo").show();
            else
                $("#prostockoutinfo").hide();
        })

        //Sales Territory 这里如果选中了全世界则其它选项都不能选中
        //function cheExtend() {
        //    $("#chklist").find("label").each(function () {
        //        var checkVal = $(this).attr('class');
        //        var checkHtml = $.trim($(this).html());
        //        if (checkHtml == "Worldwide" && checkVal == "checkbox checked") {
        //            $(this).parent().find('label').attr("class", "checkbox");
        //            $(this).attr("class", "checkbox checked");
        //        }
        //        if (checkHtml != "Worldwide" && checkVal == "checkbox checked") {
        //            $(this).parent().find('label').each(function () {
        //                if ($.trim($(this).html()) == "Worldwide") {
        //                    $(this).attr("class", "checkbox");
        //                    return false;
        //                }
        //            });
        //        }
        //    })
        //}

    </script>



    <%=edit_right_script%>

</asp:Content>

