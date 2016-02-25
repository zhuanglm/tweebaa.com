﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="SubmitForm.aspx.cs" Inherits="TweebaaWebApp2.Product.SubmitForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Suggest Tweebaa products:  Have fun AND earn rewards
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

    <link rel="stylesheet" href="../css/submit.css" /> 
    <link rel="stylesheet" href="../css/selectCss.Css" />



    <link rel="stylesheet" href="/plugins/sky-forms/version-2.0.1/css/custom-sky-forms.css" /> 
    <link rel="stylesheet" href="/css/pages/log-reg-v3.css" />  

    <!-- CSS Page Style -->    
    <link rel="stylesheet" href="../css/pages/feature_timeline2.css" />
    
    <!-- style to hide spin button for input type=number -->
    <style type="text/css">
    input[type="number"]::-webkit-outer-spin-button,
    input[type="number"]::-webkit-inner-spin-button {
        -webkit-appearance: none;
        margin: 0;
    }
    input[type="number"] {
        -moz-appearance: textfield;
    }
    </style>

    <!-- Add Summernote HTML Editor -->
      <!-- add summernote 
  <link href="/summernote/dist/summernote.css" rel="stylesheet">
  <script src="/summernote/dist/summernote.js"></script>
  -->

   <link rel="stylesheet" href="../Kindeditor/kindeditor-4.1.10/themes/default/default.css" />
    <link href="../Kindeditor/kindeditor-4.1.10/plugins/code/prettify.css" rel="stylesheet"
        type="text/css" />
 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">



    <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Product Suggestion</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="../index.aspx">Home</a></li>
                <li><a href="SubmitForm.aspx">Suggest</a></li>
                <li class="active">Product Suggestion</li>
            </ul>
        </div><!--/container-->
    </div><!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->
    
  <!--=== Content Part ===-->
    <div class="container content">
           <!-- Begin Content -->
                      
                <!-- General 1 Forms -->
                <form action="#" class="sky-form"  id="sky-form1" >
                    <header>Product Information</header>
                    
                    <fieldset>
<section>
                                        <label class="label">Product Name<span class="color-red">*</span></label>
                                        <label class="input">
                                        
                                            <i class="icon-prepend fa fa-question-circle "></i>
                                            <input type="text" placeholder="Modern Toaster" maxlength="50" id="pro-name" onkeyup="limitLenth(this,50,'lnametip')">
                                            <b class="tooltip tooltip-top-left">
                                        Enter the product name exactly as you wish it to be displayed on Tweebaa.<br> 
                                        TIP:  A descriptive product name can attract more attention.<br>
                                        <u>Bad &nbsp; example</u>:   Litter Box<br>
                                        <u>Good example</u>:  Kitty Litty - flip-style, fast-cleaning cat litter box<br>
                                 </b>
                                        </label>
                              <p> <small class="txt-right">Max 50 characters, only <label id="lnametip"  class="color-red">50 </label> characters left. </small></p>

                                    </section>
                                    <section>
                                        <label class="label">Categories<span class="color-red">*</span></label>
                      
                        <div class="row" id="trPrdCate1">
                            <section class="col col-3">
                                <label class="select">
                                     <select name="" class="tag_select" id="prdType11" >
                                    </select><i></i>
                                </label>
                            </section>
                            <section class="col col-3">
                                <label class="select">
                                 <select name="" class="tag_select" id="prdType12">
                                    </select>
                                 <i></i>
                                </label>
                            </section>
                            <section class="col col-3">
                                <label class="select">
                                     <select name="" class="tag_select" id="prdType13">
                                    </select>
                                 <i></i>
                                </label>
                            </section>
                      
                        </div>
                      
                        <div id="tbPrdCate"></div>
                       <button class="btn-u rounded" onclick="DoBtnAddAnotherCategory(); return false;">Add More Categories</button> 
    </section>
 <section>
                                        <label class="label">Tags</label>
                                        <label class="input">
                                        <i class="icon-prepend fa fa-question-circle "></i>
                                         
                                            <input type="text" placeholder="Input your tags here" id = "txtTag" maxlength="550" name="max" onkeyup="limitLenth(this,550,'lenTagTip')">
                                            <b class="tooltip tooltip-top-left">
                                        
                                        Enter tags of the product, max 10 tags.<br>
                                        Please seperate tags by comma or spaces. 
                                    
                                 </b>
                                        </label>
                               <p> <small class="txt-right">Max 550 characters, only <label id="lenTagTip"  class="color-red">550 </label> characters left. </small></p>
       
                                    </section>


                                       <section>
                                        <label class="label">Brief Description<span class="color-red">*</span></label>
                                        <label class="textarea">
                                            <i class="icon-prepend fa fa-question-circle"></i>
                                            <textarea rows="3" id="txtBriefDesc"  onkeyup="limitLenth(this,450,'ltesetip')" maxlength="450"
                                    placeholder="Sleek, modern electronic toaster with updated features. Easy to operate and to clean. Color: stainless steel " name="max"></textarea>
                                            <b class="tooltip tooltip-top-left">Consider this section your “headline”.  It should grab readers’ attention and make them want to learn more about the product.</b>
                                        </label>
                                     
                                        <p> <small class="txt-right">
                                            Max 450 characters, only <label id="ltesetip" class="color-red">450</label> characters left.
                                            </small>
                                        </p>
                                  
                                    </section>
                                    
                
                                    
                                    
                                    
                                          
                                                  <section>
                                        <label class="label">Detailed Description<span class="color-red">*</span></label>
                                        <label class="textarea">
                                          
                                            <textarea rows="3" maxlength="5000" style="height: 400px;width:100%; visibility: hidden;" id="txtDec" runat="server"  name="txtDec" placeholder="Sleek, modern electronic toaster with updated features. 
Easy to operate and to clean. 
Color: stainless steel " ></textarea>

                                            <b class="tooltip tooltip-top-left">
                                        This is your opportunity to SELL YOUR PRODUCT!  The more descriptive you are, the better chance that the product will catch the attention of Tweebaa members and shoppers (leading to product SUCCESS).  Tell us about the features and benefits… how it works… and why people should purchase your clever product.  
                                        <br>
                                        For best results:<br>
                                            •	Provide an abundance of information to share how great <br>
                                                &nbsp;&nbsp;&nbsp;the product is<br>
                                            •	Use correct grammar<br>
                                            •	Take care with punctuation<br>
                                            •	Use spell check<br>
                                        <b>5000 characters limit</b>.
                                   </b>
                                        </label>
                                    </section>  
                            <section>
                 
                            <div class="inline-group" style="display:none">
                                <label class="checkbox" id="ckbTemp"  onclick="UseTemp()"><input type="checkbox" name="checkbox-inline" checked><i></i>Use the suggestion template</label>
                              
                            </div>
                        </section>                                         
                        </fieldset>
                        </form>
                      
                       <div class=" margin-bottom-20"></div>
           <!-- Begin Content -->     
         <!-- General 2Forms -->
         <form action="#" class="sky-form"  id="" > 
                    <header><span class="item">
                     
                        </span>Images and Video</header>
                    
                    <fieldset>

                   <section>
 <!--<label class="label">Update Video</label>-->
 <!-- 图片信息 -->
           
            <!--    <span class="title" style=" margin-top:-15px; margin-bottom:50px; position:absolute;">Images and Video </span> -->
             
<%--                <table  cellspacing="0" cellpadding="0" border="0">
                  <tr>
                   <td><span style="color: black;">You may add up to 5 images (at least one image is required).</span></td>
                  </tr>
                  <tr>
                   <td><span style="color: black">Uploaded image must be Min 600x600 pixels; Max 1200x1200 pixels.</span></td>
                  </tr>
                </table>--%>
                <iframe src="/upload/UploadPicEn.aspx" id="frm1" frameborder="0" width="100%"
                    height="240" scrolling="no"></iframe><%--http://localhost:14160/UploadPicEn.aspx--%>
                    <%--https://tweebaa.com/uploadpicEn.aspx;/upload/uploadpicEn.aspx--%>
           
</section>
<!--
     <section>
     <label class="label">Update Video</label>
       
                            <label for="file" class="input input-file">
                                <div class="button">
                                 
                                <input type="file" name="file" multiple onchange="this.parentNode.nextSibling.value = this.value">Browse</div>
                                  <i class="icon-prepend fa fa-question-circle "></i>
                                <input type="text" placeholder="Supports wmv, mov, mp4 and flv formats. Maximum size is 5mb" readonly>
                                
                                       <b class="tooltip tooltip-top-left">Although videos are not required, they can help you better explain the features,functions, solutions of your product help engage buyers to make a purchasing decision.
                            
                                   </b>
                            </label>
                        </section>
                                   
                                   
                                                  <section>
                                        <label class="label">Detailed Description</label>
                                        <label class="textarea">
                                            <i class="icon-prepend fa fa-question-circle"></i>
                                            <textarea rows="3" placeholder="Sleek, modern electronic toaster with updated features. 
Easy to operate and to clean. 
Color: stainless steel " name="max"></textarea>
                                            <b class="tooltip tooltip-top-left">
                                        This is your opportunity to SELL YOUR PRODUCT!  The more descriptive you are, the better chance that the product will catch the attention of Tweebaa members and shoppers (leading to product SUCCESS).  Tell us about the features and benefits… how it works… and why people should purchase your clever product.  
                                        <br>
                                        For best results:<br>
                                            •	Provide an abundance of information to share how great <br>
                                                &nbsp;&nbsp;&nbsp;the product is<br>
                                            •	Use correct grammar<br>
                                            •	Take care with punctuation<br>
                                            •	Use spell check<br>
                                        <b>5000 characters limit</b>.
                                   </b>
                                        </label>
                                    </section>-->                               
                        </fieldset>    
                        </form>
                    
                        <div class=" margin-bottom-20"></div>
                          <!-- General 3Forms -->
                <form action="#" class="sky-form"  id="sky-form2" >
                    <header><span class="item">
                        </span>Pricing Information</header>
                    
                    <fieldset>
                     <div class="row">
      <section class="col col-4">
       <label class="label">Suggested Selling Price ($)<span class="color-red">*</span></label>
       <label class="input">
      
        <i class="icon-prepend fa fa-question-circle"></i>
       <input type="number" step="0.01" min="0.01"  id="txtPrice" name="number"  onkeydown="LimitLen(this, 10);" onkeyup="LimitLen(this, 10); " onchange="value=value.replace(/[^\d.]/g,'');value=parseFloat(value).toFixed(2);" >
       <b class="tooltip tooltip-top-left">
 Please list a suggested selling price (the price consumers/shoppers will pay for the product). This might take a little legwork. You can start by researching similar items, and checking their selling price at other websites or retailers. Another
suggestion is to survey your friends and family to ask what they would pay for the item.
				 					</b>
      </label>
       </section>
        <section class="col col-4">
                                            <label class="label">Supply Price ($)<span class="color-red">*</span></label>
                                            <label class="input">
                                             
                                                <i class="icon-prepend fa fa-question-circle"></i>
                                                <input type="number" step="0.01" min="0.01" id="txtSupplyPrice" name="number" onkeydown="LimitLen(this, 10);" onkeyup="LimitLen(this, 10); " onchange="value=value.replace(/[^\d.]/g,'');value=parseFloat(value).toFixed(2);" />
                                                   <b class="tooltip tooltip-top-left">List Supplier’s price to Tweebaa. If you’re not sure how to find the Supply Price, we suggest that you research multiple sources (try Alibaba.com to locate qualified manufacturers, or speak with a product sourcing agent) and choose the one with best pricing. We recommend that the supply price be about 1/3 the “Suggested Retail Price” or lower, so that we can pass along the best value to Tweebaa members.
				 					
				 					</b>
                                            </label>
                                        </section>
                                        
           <section class="col col-4">
                                            <label class="label">Min. Order Qty.<span class="color-red">*</span></label>
                                            <label class="input">
                                            
                                                <i class="icon-prepend fa fa-question-circle"></i>
                                               <input type="number" step="1" min="1"  id="txtMoq" name="digits"  onkeydown="LimitLen(this, 10);" onkeyup="LimitLen(this, 10);" onchange="value=value.replace(/[^\d.]/g,'');value=parseInt(value);" />
                                                <b class="tooltip tooltip-top-left">Please prove the lowest minimum order quantity (MOQ).</b>
                                            </label>
                                        </section>                                                                     
                                    </div>                           
                        </fieldset>
                        </form>
                        <div class=" margin-bottom-20"></div>
    <!-- General 3Forms -->
                <form action="#" class="sky-form"  id="sky-form3" >
                    <header><span class="item">
                        </span>Supplier Information</header>
                    
                    <fieldset>
                     <section>
                            <label class="label">Are you the product supplier? (you can manufacture or distribute)</label>
                            <div class="inline-group">
                                <label class="radio"><input type="radio" ID="rdSupplierYes" name="rdSupplier"  onclick= "showSupplierQuestion(this.value);" value="1" checked><i class="rounded-x"></i> Yes</label>
                                <label class="radio"><input type="radio" ID="rdSupplierNo"  name="rdSupplier"  onclick= "showSupplierQuestion(this.value);" value="0" ><i class="rounded-x"></i>No</label>
</div></section>
</fieldset>
<fieldset id="supplierSection" style="display: none;">
                         <div class="row">
                         <section class="col col-8">
                                        <label class="label">Who is the Supplier / Source?<span class="color-red">*</span></label>
                                        <label class="input">
                                            <i class="icon-prepend fa fa-question-circle "></i>
                                         
                                            <input type="text" id="txtSupplierName" maxlength="250" onkeyup="limitLenth(this,250,'suppliernametip')" placeholder="Please provide the supplier name or source." name="max">
                                            <b class="tooltip tooltip-top-left"> Please provide the supplier name or source.</b>
                                        </label>
                                             <p> <small class="txt-right">Max 250 characters, only <label id="suppliernametip"  class="color-red"> 250 </label> characters left.</small></p>
                                    </section>  </div>                                         
                                    <div class="row">
                                         <section class="col col-8">
                                            <label class="label" style="color:red">Please provide AT LEAST ONE of the following: </label>
                                         </section>
                                    </div>
 
                                      <div class="row">
                                        <section class="col col-4">
                                            <label class="label">Supplier website</label>
                                            <label class="input">
                                                <i class="icon-append fa fa-globe"></i>
                                                <input type="url" id="txtSupplierWebsite" name="url">
                                            </label>
                                        </section>
                                        <section class="col col-4">                                          
                                        <label class="label">Supplier Phone Number</label>
                                        <label class="input">
                                            <i class="icon-append fa fa-phone"></i>
                                            <input type="tel" name="phone" id="txtSupplierPhone">
                                        </label>                                   
                                        </section>
                                             <section class="col col-4">                                          
                                        <label class="label">Supplier email</label>
                                            <label class="input">
                                                <i class="icon-append fa fa-envelope"></i>
                                                <input type="email" name="email" id="txtSupplierEmail">
                                            </label>                                 
                                        </section>
                                    </div>
                                      <div class="row">
                                     <section class="col col-9">
                                        <label class="label">Supplier address</label>
                                        <label class="textarea">
                                    
                                            <textarea rows="3" id="txtSupplierAddress" placeholder="Provide supplier address (if known)." ></textarea>
                                          
                                        </label>
                                       
                                    </section> 
                              </div>
                                                                                                   
                        </fieldset>
                <input type="hidden" id="hidpic1" />
                <input type="hidden" id="hidpic2" />
                <input type="hidden" id="hidpic3" />
                <input type="hidden" id="hidpic4" />
                <input type="hidden" id="hidpic5" />
                <input type="hidden" id="hidvideo" />                 
                         <footer>
                         <div class="row">
                <div class="col-sm-6 col-md-3"><button class="btn-u btn-block btn-lg rounded btn-u-blue margin-bottom-10" onclick='addPrd2("save","0");return false;'> Save</button> </div>  
                <div class="col-sm-6 col-md-3"><button class="btn-u btn-block btn-lg rounded btn-u-blue margin-bottom-10" onclick='addPrd("save","0");return false;'> Preview</button> </div> 
                <div class="col-sm-6 col-md-3"><button class="btn-u btn-block btn-lg rounded btn-u-orange margin-bottom-10" onclick='submitPrd();return false;'> Suggest</button> </div> 
                <div class="col-sm-6 col-md-3"><button class="btn-u btn-block btn-lg rounded btn-u-blue margin-bottom-10" onclick="ClearInputFuc();return false;"> Clear</button> </div>        
                
                       </div> 
                    </footer>
                        </form>                                
                     
                                 
                        </div>

<script type="text/javascript">

        function DoBtnAddAnotherCategory() {
            var idx = AddAnotherCategory();
            LoadPrdCate(idx);
        }

        function DeletePrdCate(idx) {
            // just hide the tr when delete
            $("#trPrdCate" + idx).hide();
        }

        function ClearInputFuc() {

            //fubuFun();
            //return;

            // clear upload images
            var imgFrame = $("#frm1");
            for (var i = 1; i <= 5; i++) {
                imgFrame.contents().find("#img" + i).removeAttr("src");
                imgFrame.contents().find("#img" + i).show();
            }

            // clear input 
            $("input[type='text']").val("");
            $("#pro-name").keyup();
            $("#txtTag").keyup();

            $("#txtBriefDesc").val("");
            $("#txtBriefDesc").keyup()

            // clear html editer
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

            $("#pro - web").val("");

            // clear supplier info
            //form.reset();
            $("#txtSupplierName").val("");
            $("#txtSupplierName").keyup();

            $("#txtSupplierWebsite").val("");
            $("#txtSupplierWebsite").keyup();

            $("#txtSupplierPhone").val("");
            $("#txtSupplierPhone").keyup();

            $("#txtSupplierEmail").val("");
            $("#txtSupplierEmail").keyup();
            
            $("#txtSupplierAddress").val("");
            $("#txtSupplierAddress").keyup();
        }

        jQuery(document).ready(function () {
            Validation.initValidation();
            Masking.initMasking();
         });
        /*
        jQuery(document).ready(function () {
            $('#txtDec').summernote({
                height: 200
            });

            $('form').on('submit', function (e) {
                e.preventDefault();
                alert($('.summernote').code());
            });
        });*/
</script> 

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
    <!--div class="greybox" >
		<div id="fabu-ok" style="height:500px;">
			<div class="fubu-ok pr">
				<a href="#" class="closeBtn"></a>
				<h1 class="tc fb l2">Congratulation！<br />Product suggested successfully, it is in approval stage now.</h1>
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
					<span>Suggest Product</span><span>Evaluation Passed</span><span>Test-Sale Passed</span><span>Final-Sale</span>
				</div>
			</div>
			<div class="hui">
				<span class="jxfb">
					<a href="SubmitForm.aspx">Suggest More</a>
				</span>
				<span class="ckfb">
					<a href="../Home/Index.aspx?page=homeSubmit">See I suggested</a>
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
   </div> -->

   <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog modalw">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button aria-hidden="true" data-dismiss="modal" class="close" type="button">×</button>
                                        <h2 id="myModalLabel" class="modal-title color-blue"> Product suggested successfull</h2><p>It is in approval stage now.</p>
                                    </div>
                                    <div class="modal-body">
                                        
                          
                <ul class="timeline-v2">
                    <li>
                      <time class="cbp_tmtime"><span></span></time>
                      <em class="cbp_tmicon cbp_sug rounded-x hidden-xs"></em>
                      <div class="cbp_tmlabel cbp_suggest">
                            <h2><a href="/Product/Product_Submit.aspx"><i class="icon-custom rounded-x fa fa-pencil-square-o icon-color-blue"></i></a>Suggest Product</h2>
                             
                        </div>
                    </li>
                     <li>
                      <time class="cbp_tmtime"><span></span></time>
                      <em class="cbp_tmicon rounded-x hidden-xs"></em>
                      <div class="cbp_tmlabel">
                            <h2><a href="/Product/prdReviewAll.aspx"><i class="icon-custom rounded-x fa fa-check-square-o"></i></a>Evaluation Passed</h2>    
                        </div>
                    </li>
                    
                       <li>
                      <time class="cbp_tmtime "><span >$30.00</span><span>Reward</span></time>
                      <em class="cbp_tmicon rounded-x hidden-xs"></em>
                      <div class="cbp_tmlabel">
                            <h2><a href="/Product/prdSaleAll.aspx"><i class="icon-custom rounded-x icon-basket-loaded"></i></a>Test-Sale Passed</h2>    
                        </div>
                    </li>
                             <li>
                      <time class="cbp_tmtime"><span>Whole life</span><span>Commission</span></time>
                      <em class="cbp_tmicon rounded-x hidden-xs"></em>
                      <div class="cbp_tmlabel">
                            <h2><a href="/Product/prdSaleAll.aspx"><i class="icon-custom rounded-x fa fa-shopping-cart"></i></a>Tweebaa Shop</h2>    
                        </div>
                    </li>
                </ul>
            
          
                      
                </div>
                <div class="modal-footer">
                <button data-dismiss="modal" class="btn-u btn-u-default rounded" type="button" onclick="location.href='/index.aspx';">Back to Home</button>
                <button class="btn-u rounded btn-u-blue" type="button" onclick="location.href='/product/SubmitForm.aspx';" >Suggest Another</button>
                                        
                    <button class="btn-u rounded" type="button"  onclick="location.href='/Home/HomeSupply.aspx';" >See My Suggestions</button>
                    <hr />
                        <p>Returning to homepage in <span id="spnWait15" class="color-red">15</span> seconds. </p>    
                
                </div>
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
            /*
            $("#txtPrice").mask("#######.##", { reverse: true });
            $("#txtSupplyPrice").mask("#######.##", { reverse: true });
            $("#txtMoq").mask("#########", { reverse: true });*/
            
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
        function fubuFun() {
            $("#myModal").modal("toggle");

            //倒计时开始
            setIntervalID = setInterval(function () {
                var wait15 = parseInt($("#spnWait15").html());
                wait15 --;
                $("#spnWait15").html(wait15);
                if (wait15 == 0) {
                    window.location.assign("/index.aspx");
                };
            }, 1000)
        }
     </script>        
     
         <script src="../js/xd.js" type="text/javascript"></script>
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

   
    <script src="../MethodJs/prd.js?v=2016020311" type="text/javascript"></script>
    <script type="text/javascript">
        function showSupplierQuestion(yn) {
            var s = 'block';
            if (yn == 1) s = 'none';
            document.getElementById('supplierSection').style.display = s;
        }
    </script>

    <!-- Validation Form -->
<script src="/plugins/sky-forms/version-2.0.1/js/jquery.validate.min.js"></script>
<!-- Masking Form -->
<script src="/plugins/sky-forms/version-2.0.1/js/jquery.maskedinput.min.js"></script>
<script src="/plugins/sky-forms/version-2.0.1/js/jquery.mask.js"></script>

    <script type="text/javascript" src="/js/plugins/masking.js"></script>
    <!--<script type="text/javascript" src="js/plugins/datepicker.js"></script>-->
    <script type="text/javascript" src="/js/plugins/validation.js"></script>

    <script src="../js/util.js" type="text/javascript"></script>
    <script src="../js/jquery.placeholder2.js" type="text/javascript"></script>
    <script src="../js/biaodan2.js" type="text/javascript"></script>
    <script src="../js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/newfloat.js"></script>
                   
</asp:Content>
