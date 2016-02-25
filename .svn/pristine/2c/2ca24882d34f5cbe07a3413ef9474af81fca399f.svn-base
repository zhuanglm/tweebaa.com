<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="issue.aspx.cs" Inherits="TweebaaWebApp.Product.issue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Submit Tweebaa products:  Have fun AND earn rewards
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <script src="../Js/util.js" type="text/javascript"></script>
    <script src="../Js/xd.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../Css/submit.css" /> 
    <link rel="stylesheet" href="../Css/selectCss.Css" />
    <script src="../Js/jquery.min.js" type="text/javascript"></script>
    <script src="../Js/jquery.placeholder2.js" type="text/javascript"></script>
    <script src="../Js/biaodan2.js" type="text/javascript"></script>
    <script src="../Js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/newfloat.js"></script>

    <link rel="stylesheet" href="../Kindeditor/kindeditor-4.1.10/themes/default/default.css" />
    <link href="../Kindeditor/kindeditor-4.1.10/plugins/code/prettify.css" rel="stylesheet"
        type="text/css" />
    <script charset="utf-8" src="../Kindeditor/kindeditor-4.1.10/kindeditor.js"></script>
    <script charset="utf-8" src="../Kindeditor/kindeditor-4.1.10/lang/zh_CN.js"></script>
    <script charset="utf-8" src="../Kindeditor/kindeditor-4.1.10/plugins/code/prettify.js"></script>
    <script type="text/javascript">
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('#' + document.getElementById('<%=txtDec.ClientID %>').id, {
                langType: 'en',
                cssPath: '../Kindeditor/kindeditor-4.1.10/plugins/code/prettify.css',
                uploadJson: '../Kindeditor/kindeditor-4.1.10/asp.net/upload_json.ashx',
                fileManagerJson: '../Kindeditor/kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                allowFileManager: false,              
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
            prettyPrint();
          
        });
       
    </script>
    <script src="../MethodJs/prd.js" type="text/javascript"></script>
    <script type="text/javascript">
        function showSupplierQuestion(yn) {
            var s = 'table-row';
            if (yn == 1) s = 'none';
            document.getElementById('supplierQ2').style.display = s;
            document.getElementById('supplierQ3').style.display = s;
            document.getElementById('supplierQ4').style.display = s;
            document.getElementById('supplierQ5').style.display = s;
            document.getElementById('supplierQ6').style.display = s;
            document.getElementById('supplierQ7').style.display = s;
        }
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
 
<%--   <div id="divTemp" style="display:none;">
    <%=str %>
   </div>--%>
    <div class="fabubox">
        <form action="">
        <div class="w950" >
            <h1>
  <%--              <span class="fr">
                    <strong class="important">Attention:All fields that have red stars (*) are required.</strong>
                    <a href="../College/College.aspx#nav-fa3" class="ys">Submission Demo</a> </span>--%>
                <span class="fr"><a href="../College/SubmitZone.aspx?page=submit-zone" class="ys">Learn How to Submit</a> </span>
                <table>
                    <tr>
                       
                        <td><strong>Product Submission</strong></td>
                        <td style="color:red; padding-left:50px;">All fields that have a red star (*) are required.</td>
                    </tr>
                </table>
                
                
                
            </h1>

            <!-- product producer info -->
            <!--div class="basic-infor">
                <span class="title">Supplier Information </span>
                <table border=1 style="visibility:visible;" name="tbSupplier">
                 </table>
            </div-->

            <!-- 产品基本信息 -->
            <div class="basic-infor">
                <span class="title" style="margin-top:-15px; margin-bottom:50px; position:absolute;">Product Information </span>
               <br />
                 <table border="1">
                    <tr>
                        <td class="t">
                            <b>＊</b>Product Name
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                        Enter the product name exactly as you wish it to be displayed on Tweebaa.</br> 
                                        TIP:  A descriptive product name can attract more attention.<br /><br />
                                        <u>Bad &nbsp; example</u>:   Litter Box<br />
                                        <u>Good example</u>:  Kitty Litty - flip-style, fast-cleaning cat litter box<br />
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td>
                            <div class="pr">
                                <i class="icon-btn bianji"></i>
                                <input type="text" maxlength="50" class="text jstxt" style="width: 605px;" id="pro-name"
                                    placeholder="Please enter product name here" onkeyup="limitLenth(this,50,'lnametip')" />
                            </div>
                            <div class="tr font1 txtnumertips">
                                Max 50 characters, only <label id="lnametip" style="color: Red">50 </label> characters left.
                            </div>
                        </td>
                    </tr>
                    <tr>
                    <td class="t">
                            <b>＊</b>Categories
                        </td>
                      <td colspan="2">
                      <table class="jackaddnew" id="tbPrdCate"> 
                      <tr style=" margin-bottom:20px;" id="trPrdCate1"> 
                         <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                        Please select categories of this product.
                                    </p>
                                </div>
                            </em>
                        </td>
                         <td>
                            <div class="clearfix product-categories" >
                                <div class="selectBox pr fl">
                                    <select name="" class="tag_select" id="prdType11" >
                                    </select>
                                </div>
                                <div class="selectBox pr fl">
                                    <select name="" class="tag_select" id="prdType12">
                                    </select>
                                </div>
                                <div class="selectBox pr fl">
                                    <select name="" class="tag_select" id="prdType13">
                                    </select>
                                </div>
                            </div>
                        </td></tr>

                        <!--tr style=" margin-bottom:20px;"> 
                         <td width="30">
                        <em class="delete">
                            </em>
                        </td>
                         <td>
                            <div class="clearfix product-categories" >
                                <div class="selectBox pr fl">
                                    <select name="" class="tag_select" id="Select1" >
                                    </select>
                                </div>
                                <div class="selectBox pr fl">
                                    <select name="" class="tag_select" id="Select2">
                                    </select>
                                </div>
                                <div class="selectBox pr fl">
                                    <select name="" class="tag_select" id="Select3">
                                    </select>
                                </div>
                            </div>
                        </td></tr-->
                        
                    
                        
                        </table>
                      
                      </td>
                    </tr>
                      <tr style=" margin-bottom:20px;"> 
                         <td colspan="3"><a href="#" class="add_btn" onclick="DoBtnAddAnotherCategory()">Add Another Category</a>
                        </td></tr>
                      <script type="text/javascript">

                          function  DoBtnAddAnotherCategory () {
                                var idx = AddAnotherCategory();
                                LoadPrdCate(idx);
                          }

                          function DeletePrdCate(idx) {
                              // just hide the tr when delete
                              $("#trPrdCate" + idx).hide();
                          }
                      </script>  
                    <tr>
                        <td class="t">
                            <b></b>Tags
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                        Enter tags of the product, max 10 tags.<br />
                                        Please seperate tags by comma or spaces. 
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td>
                            <div class="pr">
                                <i class="icon-btn bianji"></i>
                                <input type="text" id = "txtTag" maxlength="550" class="text jstxt" style="width: 605px;" 
                                    placeholder="Input your tags here" onkeyup="limitLenth(this,550,'lenTagTip')" />
                            </div>
                            <div class="tr font1 txtnumertips">
                                Max 550 characters, only <label id="lenTagTip" style="color: Red">550 </label> characters left.
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td class="t">
                            <b>＊</b>Brief Description
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>                                       
                                        Consider this section your “headline”.  It should grab readers’ attention and make them want to learn more about the product.
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td>
                            <div class="pr" id="tishi">
                                <p class="tishi">
                                    Sleek, modern electronic toaster with updated features.<br />
                                    Easy to operate and to clean.<br />
                                    Color: stainless steel<br />
                                </p>
                                <textarea name="" id="tese" rows="3" maxlength="450" onkeydown="hideTishi()" onkeyup="hideTishi();limitLenth(this,450,'ltesetip')"
                                    onfocus="hideTishi()"></textarea>
                            </div>
                            <div class="tr font1 txtnumertips">
                                <p>
                                    Max 450 characters, only <label id="ltesetip" style="color: Red">450</label> characters left.
                                </p>
                            </div>
                        </td>
                    </tr>
                   
                    <tr>
                        <td class="t">
                            <b>＊</b>Detailed Description
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                       <%-- Product description support HTML format, allows you to create and edit font, colour
                                        and layout.
                                        <br />
                                        This description is listed under the product page, please clearly describe your
                                        product style, function and images.

                                        The Product Description is displayed to the public on Tweebaa.  Clearly describe your 
                                        product to help secure positive evaluations and generate purchases.  <br />
                                        HTML is supported so that you can edit the font, color and layout to make an attractive description.


                                        <br />
                                         A complete product description is necessary to attract buyers.
                                        <br />--%>
                                        This is your opportunity to SELL YOUR PRODUCT!  The more descriptive you are, the better chance that the product will catch the attention of Tweebaa members and shoppers (leading to product SUCCESS).  Tell us about the features and benefits… how it works… and why people should purchase your clever product.  
                                        <br /><br />
                                        For best results:<br />
                                            •	Provide an abundance of information to share how great <br />
                                                &nbsp;&nbsp;&nbsp;the product is<br />
                                            •	Use correct grammar<br />
                                            •	Take care with punctuation<br />
                                            •	Use spell check<br /><br />
                                        <b>5000 characters limit</b>.
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td>
                            <%--<img src="../../Images/wb.png"  />--%>
                           
                            <textarea id="txtDec" name="txtDec" cols="100" rows="8" style="height: 400px; width: 680px;
                                visibility: hidden;" runat="server"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Features and Benefits
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <p>
                                    Would you like to call attention to particular features/attributes, or provide a list of product benefits?  Please list them here.  Include as many features as possible to help generate more positive evaluations, and bigger sales.<br /><br />
                                    Example:<br />
                                        •	Patented litter box makes clean-up easy!<br />
                                        •	Simple to use – just flip it to separate waste from litter<br />
                                        •	Economical – saves on litter expense<br />
                                        •	Easy assembly<br />
                                    </p>    
                                </div>
                            </em>
                        </td>
                        <td>
                            <div class="pr">
                                <i class="icon-btn bianji"></i>
                                <input type="text" maxlength="150"  class="text jstxt" style="width: 605px;" id="pro-des"
                                    onkeyup="limitLenth(this,150,'ldestip')" placeholder="Gives an even and complete toast" />                                
                            </div>
                            <div class="tr font1 txtnumertips">
                                Max 150 characters, only
                                <label id="ldestip" style="color: Red">
                                    150</label> characters left.
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

            <!-- 图片信息 -->
            <div class="basic-infor">
                <span class="title" style=" margin-top:-15px; margin-bottom:50px; position:absolute;">Images and Video </span>
               <br />
<%--                <table  cellspacing="0" cellpadding="0" border="0">
                  <tr>
                   <td><span style="color: black;">You may add up to 5 images (at least one image is required).</span></td>
                  </tr>
                  <tr>
                   <td><span style="color: black">Uploaded image must be Min 600x600 pixels; Max 1200x1200 pixels.</span></td>
                  </tr>
                </table>--%>
                <iframe src="/upload/uploadpicEn.aspx" id="frm1" frameborder="0" width="100%"
                    height="290" scrolling="no"></iframe><%--http://localhost:14160/UploadPicEn.aspx--%>
                    <%--https://tweebaa.com/uploadpicEn.aspx;/upload/uploadpicEn.aspx--%>
            </div>
            <!-- 价格区间 -->
			<div class="basic-infor price-infor">
                 <span class="title" style=" margin-top:-15px; margin-bottom:50px; position:absolute;">Pricing Information</span>
               <br />

				 <table>
				 	<tr>
				 		<td class="t"><b>＊</b>Suggested Selling Price</td>
				 		<td width="30">
				 			<em class="showbox">
				 				
				 				<div class="thistips"><i></i>
				 					<p>
				 						 Please list a suggested selling price (the price consumers/shoppers will pay for
                                        the product). This might take a little legwork. You can start by researching similar
                                        items, and checking their selling price at other websites or retailers. Another
                                        suggestion is to survey your friends and family to ask what they would pay for the
                                        item.
				 					</p>
				 				</div>
				 			</em>
				 		</td>
				 		<td width="570">
				 			<div class="pr fl" id="price-rmb">
				 				<input type="text" id="txtPrice" class="text price-rmb" style="width:100px; padding-right: 50px;" onkeyup="value=value.replace(/[^\d.]/g,'')" /><span class="wz">USD</span>
				 			</div>

				 		</td>
				 	</tr>
				 	
				 <tr>
				 		<td class="t"><b>＊</b>Supply Price</td>
				 		<td width="30">
				 			<em class="showbox">
				 				
				 				<div class="thistips"><i></i>
				 					<p>
				 						 List Supplier’s price to Tweebaa. If you’re not sure how to find the Supply Price,
                                        we suggest that you research multiple sources (try Alibaba.com to locate qualified
                                        manufacturers, or speak with a product sourcing agent) and choose the one with best
                                        pricing. We recommend that the supply price be about 1/3 the “Suggested Retail Price”
                                        or lower, so that we can pass along the best value to Tweebaa members.
				 					</p>
				 				</div>
				 			</em>
				 		</td>
				 		<td width="570">
				 			<div class="pr fl" id="price-rmb">
				 				<input type="text" id="txtSupplyPrice" class="text price-rmb" style="width:100px; padding-right: 50px;" onkeyup="value=value.replace(/[^\d.]/g,'')" /><span class="wz">USD</span>
				 			</div>

				 		</td>
			 	   </tr>
                     <tr>
				 		<td class="t"><b>＊</b>Min. Order Qty.</td>
				 		<td width="30">
				 			<em class="showbox">
				 				
				 				<div class="thistips"><i></i>
				 					<p>
				 						 Please prove the lowest minimum order quantity (MOQ).
				 					</p>
				 				</div>
				 			</em>
				 		</td>
				 		<td width="570">
				 			<div class="pr fl" id="price-rmb">
				 				<input type="text" id="txtMoq" class="text price-rmb" style="width:100px; padding-right: 50px;" onkeyup="value=value.replace(/[^\d.]/g,'')" /><span class="wz">Pieces</span>
				 			</div>

				 		</td>
				 	</tr>
				 	<tr>
				 		<td class="t"></td>
				 		<td width="30"></td>
				 		<td width="570"></td>
				 	</tr>
				 </table>
			</div>
			<!-- gonghuo -->
            <div class="basic-infor price-infor">
                <span class="title" style=" margin-top:-15px; margin-bottom:50px; position:absolute;">Supplier Information</span>
                 <br />
				 <table><tr>
				   <td class="su"  width="400" ><b>＊</b>Are you the product supplier? (you can manufacture or distribute) </td>
				 		<td  width="30">
			 			  <em class="showbox">
				 				
				 				<div class="thistips"><i></i>
				 					<p>Please select No if you are not the product supplier.
				 					</p>
				 				</div>
			 			  </em>
				 		</td>	
				 		 <td class="yeah" width="50"><input type="radio" ID="rdSupplierYes" name="rdSupplier"  onclick= "showSupplierQuestion(this.value);" value="1" checked  /> Yes  </td>
                         <td class="yeah" width="50"><input type="radio" ID="rdSupplierNo"  name="rdSupplier"  onclick= "showSupplierQuestion(this.value);" value="0" /> No </td>
				 		
				 	</tr></table>
				 <% //The hiden question for supplier %>
			     <table>	<tr id="supplierQ2" style="display: none;">
				 		<td class="sup"><b>＊</b>Who is the Supplier / Source?</td>
				 		<td width="30"><em class="showbox">
				 			<div class="thistips">
				 				<i></i>
				 				<p>Please provide the supplier name or source.
				 				</p>
								
				 			</div>
				 		</em></td>
				 		<td width="570">
				 			<div class="pr">
				 				<i class="icon-btn bianji"></i>
				 				<input type="text" maxlength="40" class="text jstxt"  id="txtSupplierName"  onkeyup="limitLenth(this,250,'suppliernametip')" placeholder="please enter the supplier name" />
				 			</div>
				 			<div class="tr font1 txtnumertips">
You entered 0 characters, only 20 characters left.							</div>	
				 		</td>
		 	  </tr></table>
                  <!--at least choose one-->
                 <table>
                   <tr  id="supplierQ3" style="display: none;"> 
                   <td class="long"  width="300" >Please provide AT LEAST one of the following:</td>
                   </tr>
                </table>

                 <table> <tr  id="supplierQ4" style="display: none;">
				 		<td class="sup">Supplier website </td>
				 		<td width="30"><em class="showbox">
				 			<div class="thistips">
				 				<i></i>
				 				<p>Please provice the supplier website.
				 				</p>
								
				 			</div>
				 		</em></td>
				 		<td width="570">
				 				<div class="pr" style="width: 390px;">
				 				<i class="icon-btn bianji"></i>
				 				<input type="text" class="text jstxt" placeholder="Please enter supplier website"  id="txtSupplierWebsite"  style="width:320px;"/>
				 			</div>
				 			
				 		</td>
		 	  </tr>
             <tr id="supplierQ5" style="display: none;">
	 		   <td class="sup"> Supplier Phone Number </td>
	 		   <td width="30"><em class="showbox">
				 			<div class="thistips">
				 				<i></i>
				 				<p>Please provide the supplier phone number.
				 				</p>
								
				 			</div>
				 		</em></td>
				 		<td width="570">
				 				<div class="pr" style="width: 390px;">
				 				<i class="icon-btn bianji"></i>
				 				<input type="text" class="text jstxt" placeholder="Please include the country code like +186 010 86888888"  id="txtSupplierPhone" style="width:320px;"/>
				 			</div>
				 			
				 		</td>
		 	  </tr> 
          <tr id="supplierQ6" style="display: none;">
				 		<td class="sup"> Supplier email </td>
	 		   <td width="30"><em class="showbox">
				 			<div class="thistips">
				 				<i></i>
				 				<p>Please provide the supplier email address.
				 				</p>
								
				 			</div>
				 		</em></td>
				 		<td width="570">
				 				<div class="pr" style="width: 390px;">
				 				<i class="icon-btn bianji"></i>
				 				<input type="text" class="text jstxt" placeholder="Please enter the email" id="txtSupplierEmail" style="width:320px;"/>
				 			</div>
				 			
				 		</td>
		 	  </tr>      
           <tr id="supplierQ7" style="display: none;">
				 		<td class="sup"> Supplier address</td>
	 		   <td width="30"><em class="showbox">
				 			<div class="thistips">
				 				<i></i>
				 				<p>Please provide the supplier address.
				 				</p>
								
				 			</div>
				 		</em></td>
	 		 <td width="570">
			   <div class="pr" id="Div4">
				 				<!--p class="thistip">Please provide the supplier address.<br /><br /> <br />
				 				</p-->
				 				<textarea name="" placeholder="Please provide the supplier address." id="txtSupplierAddress" rows="3" maxlength="200"  ></textarea>
				 			</div>
	 		   </td>
		 	  </tr>      
              </table>
                    
			     <table>	<tr>
				 		<td class="t"></td>
				 		<td width="30"></td>
				 		<td width="570"></td>
				 	</tr>
				 </table>                
			</div>
            <div style=" margin-top:-20px;">
             <input type="checkbox" id="ckbTemp"  onclick="UseTemp()"  />Use the submission template 
            </div>
          
            <div class="result tc">
                <%--<a href="#" class="btn clear-btn fr" >Clear</a> 
                <a href="javascript:void(0)" class="btn save-btn fr" onclick='addPrd2("save","0")'>Save</a>               
                <br />
                <a href="javascript:void(0)" class="yulanbtn" onclick='addPrd("save","1")'>Preview</a>--%>
                <%--<a href="#" class="btn return-btn fl">Back</a>--%>
                  <a href="javascript:void(0)" class="yulanbtn" onclick='addPrd2("save","0")'>Save</a> 
                  <a href="javascript:void(0)" class="yulanbtn" onclick='addPrd("save","0")'>Preview</a>
                  <a href="javascript:void(0)" class="yulanbtn" onclick='submitPrd()'>Submit</a>	
                  <a href="javascript:void(0)" class="yulanbtn" onclick="ClearInputFuc()">Clear</a>
                <script type="text/javascript">
                    function ClearInputFuc() {
                        $("input[type='text']").val("");
                        $("#tese").val("").html("");
                        editor.html("");
                        
                        // clear categories
                        var idx = 1;
                        while (true) {
                            var trPrdCateName = "#trPrdCate" + idx.toString();
                            var htmlTemp = $(trPrdCateName).html();
                            if (htmlTemp == null) break;
                            $("#prdType" + idx.toString() + "1").attr("value", "-1");
                            $("#prdType" + idx.toString() + "2").empty();
                            $("#prdType" + idx.toString() + "3").empty();
                            idx += 1;
                        }
                    }

                    
                </script>

            </div>
        </div>
        <input type="hidden" id="hidpic1" />
        <input type="hidden" id="hidpic2" />
        <input type="hidden" id="hidpic3" />
        <input type="hidden" id="hidpic4" />
        <input type="hidden" id="hidpic5" />
        <input type="hidden" id="hidvideo" />
        </form>
    </div>
  
    <!-- 清空 -->
    <div class="greybox">
        <div class="clearAllInfor">
            <a href="javascript:;" class="closeBtn"></a>
            <p>
                All fields will be cleared, you will need to re-enter all the data. Confirm to proceed?
            </p>
            <div class="tc">
                <a href="#" class="cancel-btn">Cancel</a> <a href="#" class="enter-btn">Confirm</a>
            </div>
        </div>
    </div>

     <!-- 发布成功 -->
    <div class="greybox" >
		<div id="fabu-ok" style="height:500px;">
			<div class="fubu-ok pr">
				<a href="#" class="closeBtn"></a>
				<h1 class="tc fb l2">Congratulation！<br />Product submitted successfully, it is in approval stage now.</h1>
				<ol class="clearfix">
					<li class="on">
						<em class="s"></em>						
					</li>
					<li>
						<em class="s"></em>						
					</li>
					<li class="third">
						<em>
							<b class="fb l2">$30Reward</b>
						</em>
						<i>
							<b class="fb l2">Commission</b>
						</i>
					</li>						
				</ol>
				<div class="clear"></div>
				<div class="txt tc">
					<span>Submit Product</span><span>Evaluation Passed</span><span>Test-Sale Passed</span><span>Final-Sale</span>
				</div>
			</div>
			<div class="hui">
				<span class="jxfb">
					<a href="issue.aspx">Submit More</a>
				</span>
				<span class="ckfb">
					<a href="../Home/Index.aspx?page=homeSubmit">See I submitted</a>
				</span>
				<span class="fx">
					<a href="../Home/Index.aspx">Member center</a>
				</span>
			</div>
			<div class="want-gh">
				We have lots of products waiting for you to supply!<a href="prdReviewStep2.aspx?step=supply">I want to Supply</a>
			</div>
			<div class="return-index">
				<a href="../index.aspx">Back to Home</a>
			</div>
			<div class="dao321 tc">
				<b class="dao15">15</b>seconds，returns to homepage automatically	
			</div>
		</div>
   </div>

     <%--发布模板--%>

    <div id="divTemp" style="display:none;">     
       <%--<div class="tabCon">
          <div class="itembox">--%>
        <div class="detailed fl">
            <h4>
                Detailed Description</h4>
            <p id="labDescriptionTemp" class="word-break" >
           <%-- <div id="labDescriptionTemp" style="width:700px;">
            style="word-break:break-word;"
            </div>--%>
               <%-- <label id="labDescriptionTemp" style="width:700px;">                
                
                </label>--%>
            </p>
            <h4>
                Features and Benefits</h4>
            <p id="labFeaturesTemp" class="word-break" >      
             <%--<div id="labFeaturesTemp" style="width:700px;">
             
             </div>   --%>        
              <%--  <label id="labFeaturesTemp" style="width:700px;"></label>--%>
            </p>
            <h4 id="h4Video">
                Videos</h4>
            <%--<img src="../Images/vedio.jpg"  />--%>

             <iframe id="videoFrame2" src=""  frameborder="5" width="500" height="500"></iframe> 
             <div class="video" id="CuPlayer2" style="margin: 0 auto;"></div>               
                        

        </div>
        <div class="picture fl">
            <ul class="ul-style">
                <li class="ul-style">
                    <img src="" alt="" id="imgTemp1" />
                </li>
                <li class="ul-style">
                    <img src=""  id="imgTemp2" />
                </li>
                <li class="ul-style">
                    <img src=""  id="imgTemp3" />
                </li>
                <li class="ul-style">
                    <img src=""  id="imgTemp4" />
                </li>
                 <li class="ul-style">
                    <img src=""  id="imgTemp5" />
                </li>
            </ul>
        </div>
   <%-- </div>   
       </div>--%>
     </div>


    <style type="text/css">       
        
        .tag_select2
        {
            display: block;
            float: left;
            color: black;
            width: 158px;
            height: 34px;
            line-height: 34px;
            color: #7D7D7D;
            font-size: 12px;
            margin-right: 8px;
        }
        .style1
        {
            height: 107px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            //表单提示
            $('.jstxt').placeholder();

            // select 美化
            $(".selects").selectCss();
            // 第一个价格显示
            $(".price-section").eq(0).show()
            //在线咨询 浮动
            $("#zxzz").smartFloat()


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

            //问好提示
            $(".showbox").mouseenter(function (event) {
                $(this).find(".thistips").show();
            }).mouseleave(function (event) {
                $(this).find(".thistips").hide();
            });


            //增加和减少 价格区间
            var jiaObj = $(".add-sale-btn").find('.jia')
            var jianObj = $(".add-sale-btn").find('.jian')
            var sectionNum = 0;
            jiaObj.click(function () {
                sectionNum++
                if (sectionNum >= 9) {
                    sectionNum = 9
                    alert("最多10个区间")
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
        })

        var setIntervalID; //ydf       

        //发布成功弹出
        function fubuFun(obj, urllink) {
            obj.parents(".greybox").show()
            obj.animate({ top: "5%" }, 300)
            //倒计时开始
            setIntervalID = setInterval(function () {
                var dao123 = parseInt(obj.find(".dao15").html())
                dao123--;
                obj.find(".dao15").html(dao123)
                if (dao123 == 0) {
                    window.location.assign(urllink)
                };
            }, 1000)
        }
    </script>
</asp:Content>
