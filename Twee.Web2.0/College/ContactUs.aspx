<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="TweebaaWebApp2.College.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
<%=TweebaaWebApp2.SEOTextDefine.ContactUsSEOTitle %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
<%=TweebaaWebApp2.SEOTextDefine.ContactUsSEOMeta %>
  <!-- CSS Page Style -->    
    <link rel="stylesheet" href="/css/pages/page_faq1.css">
    <link rel="stylesheet" href="/css/pages/pricing/pricing_v5.css"> 
    <link rel="stylesheet" href="/css/pages/pricing/pricing_v6.css"> 
    <link rel="stylesheet" href="/css/pages/pricing/pricing_v7.css"> 
     <link rel="stylesheet" href="/css/pages/pricing/pricing_v2.css"> 
    <!-- CSS Page Style -->    
    <link rel="stylesheet" href="/css/pages/page_contact.css">
        <link rel="stylesheet" href="/plugins/sky-forms/custom-sky-forms.css">
        <!--
        <link rel="stylesheet" href="/plugins/sky-forms/sky-forms.css">
        -->
        <style>
      /**/
/* submited state */
/**/
.sky-form .message {
	display: none;
	color: #6fb679;
}
.sky-form .message i {
	display: block;
	margin: 0 auto 20px;
	width: 81px;
	height: 81px;
	border: 1px solid #6fb679;
	border-radius: 50%;
	font-size: 30px;
	line-height: 81px;
}
.sky-form.submited fieldset,
.sky-form.submited footer {
	display: none;
}
.sky-form.submited .message {
	display: block;
	padding: 25px 30px;
	background: rgba(255,255,255,.9);
	font: 300 18px/27px 'Open Sans', Helvetica, Arial, sans-serif;
	text-align: center;
}
  
        </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

      <!--=== Breadcrumbs v4 ===-->
    <div class="breadcrumbs-v4 contact_back">
        <div class="container">
            <h1>Contact Us</h1>
<p>We are always here to serve you better!</p>
            <ul class="breadcrumb-v4-in">
                <li><a href="../index.aspx">Home</a></li>
                <li><a href="#">Contact Us</a></li>
                <li class="active">Welcome</li>
            </ul>
        </div><!--/end container-->
    </div> 
    <!--=== End Breadcrumbs v4 ===-->
       <!--=== Content Part ===-->
    <div class="container content">     
      
         


                    
               <div class="row margin-bottom-30">
            <div class="col-md-12 mb-margin-bottom-30 tag-box tag-box-v6">     
		       <div class="margin-bottom-30">

			             <h4><strong>We are happy to answer all you questions and strive to provide the best customer service</strong> </h4>
<p>Please feel free to send an online request or write us an e-mail, we will get back to you within 8 business hours.</p><br />

			<p> <strong>How to place order or Check your order status:</strong> <a href="mailto:service@tweebaa.com" class="mail"> service@tweebaa.com</a></p><br />

		<p><strong>Wholesale Inquiry or Request quote for Bulk order: </strong> <a href="mailto:wholesale@tweebaa.com" class="mail"> wholesale@tweebaa.com</a></p><br />

		<p><strong>Want to be our supplier or Sell your products on Tweebaa:</strong>  <a href="mailto:supplier@tweebaa.com" class="mail">supplier@tweebaa.com</a></p><br />

		<p><strong>For any other inquiries, please contact us at:</strong> <a href="mailto:support@tweebaa.com" class="mail"> support@tweebaa.com</a></p>
</div>  
             <form class="sky-form form-horizontal <%=IsSubmit %>" method="post" action="/College/ContactUs.aspx?action=send" novalidate="novalidate" runat="server">

                    <fieldset class="no-padding">

                    <div class="row margin-bottom-20">
                        <div class="col-md-7 col-md-offset-0 " style="color:#ff0000;font-size:20px;">
                            <%=VerifyCodeError%>
                        </div>                
                    </div>
			  <div class="form-group">
                                <label for="inputEmail1" class="col-lg-1 control-label">Subject:</label>
                                <div class="col-lg-5">
                                   <select class="form-control" name="selSubject" id="selSubject" runat="server">
                        <option value="1">Order Inquiry</option>
                        <option value="2">Wholesale Inquiry</option>
                        <option value="3">Suppiler Inquiry</option>
                        <option  value="4">Other Inquiry</option>
                      
                    </select>
                                </div>
                            </div>
         

			  	  <div class="form-group">
                                <label  class="col-lg-1 control-label">Name<span class="color-red">*</span></label>
                                <div class="col-lg-5">
                <label class="input">
                                     
                                                <input type="text"   class="form-control" id="txtName" name="txtName" runat="server">
                                            </label>
                                </div>
                            </div>
				      	  <div class="form-group">
                                <label  class="col-lg-1 control-label">Company</label>
                                <div class="col-lg-5">
                <label class="input">
                           
                                                <input type="text"   class="form-control" id="txtCompany" name="txtCompany" runat="server">
                                            </label>
                                </div>
                            </div>

			 <div class="form-group">
                                <label  class="col-lg-1 control-label">Telephone</label>
                                <div class="col-lg-5">
                <label class="input">
                                           
                                                <input type="text"   class="form-control" id="txtTelphone" name="txtTelphone" runat="server">
                                            </label>
                                </div>
                            </div>

	 <div class="form-group">
                                <label  class="col-lg-1 control-label">Email<span class="color-red">*</span></label>
                                <div class="col-lg-5">
         <label class="input">
                                   
                                              <input type="text" class="form-control" id="txtEmail" name="txtEmail" runat="server" /> 
                                            </label>
                                </div>
                            </div>
 <div class="form-group">
                                <label  class="col-lg-1 control-label">Message<span class="color-red">*</span></label>
                                <div class="col-lg-8">
        <textarea rows="8" class="form-control" id="txtMessage" name="txtMessage" runat="server"></textarea>
                                </div>
                            </div>

  
	 <div class="form-group">
                                <label  class="col-lg-1 control-label">Verify<span class="color-red">*</span></label>
                                <div class="col-lg-5">
      <div style="width:auto;float:left"> <input type="text" style="width:80px;" class="form-control pull-left" id="txtVerify" name="txtVerify" maxlength="6" runat="server"/></div>
                           <div style="width:auto;float:left;padding-left:10px;padding-top:2px;"><img id="imgWaterMark" src="/Product/WaterMark.aspx?pn=<% =sPageName %>" class="pull-left" /></div>
                           <div style="width:auto;float:left;padding-left:10px;padding-top:2px;"><a href="javascript:void(0)" style="line-height:40px;" onclick="DoGetAnotherWaterMark(); return false;">Get another code</a></div>
                                            </label>
                                </div>
				
                            </div>  

 <div class="form-group">
                                <label  class="col-lg-1 control-label"></label>
                                <div class="col-lg-5">
        <p><button type="submit" class="btn-u rounded-4x" name="btnSend" id="btnSend" >Send Message</button></p>   
                                </div>
				
                            </div>  
				    	
                 
                    </fieldset>
                     <div class="message">
                        <i class="rounded-4x fa fa-check"></i>
                        <p>Your Message has been Sent,Thanks for Contact Us,We will reply you as soon as possilble！</p>
                    </div>
                </form>
            </div><!--/col-md-9-->
        </div><!--/row-->          
                    
                 <div class="row clients-page">
                 <div class="col-sm-4">
                <div class="tag-box tag-box-v3">
                     <h3>China Branch</h3>
                       <h4>Tweebaa (Shanghai) Co.,Ltd.</h4>
                          <ul class="list-unstyled who margin-bottom-30">
                          <!--
                    <li><a href="#"><i class="fa fa-home"></i>3601 Hwy 7 East , HSBC Tower Suite 302 ,  Markham , Ontario L3R 0M3 CANDA</a></li>
                    <li><a href="#"><i class="fa fa-phone-square"></i>Phone: 905-479-9969</a></li>
                    <li><a href="#"><i class="fa fa-phone"></i>Toll free: 1-877-479-3332</a></li>
                    <li><a href="#"><i class="fa fa-fax"></i>Fax: 905-479-9939</a></li>
                    <li><a href="#"><i class="fa fa-envelope"></i>Fax: 905-479-9939</a></li>
                    -->

<li><a href="#"><i class="fa fa-home"></i> Room 822, No. 355 Fute No. 1 (W) Road. <br />
 Gao Xiang Building, PuDong New Area.<br />
 Shanghai, 200131<br />
 China<br />
</a></li>

                </ul>
                </div>
            </div>
<!--
            <div class="col-sm-4">
                <div class="tag-box tag-box-v3">
                    <h3>USA Banch</h3>
                        
                          <ul class="list-unstyled who margin-bottom-30">
                    <li><a href="#"><i class="fa fa-home"></i>3601 Hwy 7 East , HSBC Tower Suite 302 , Markham , Ontario L3R 0M3 CANDA</a></li>
                    <li><a href="#"><i class="fa fa-phone-square"></i>Phone: 905-479-9969</a></li>
                    <li><a href="#"><i class="fa fa-phone"></i>Toll free: 1-877-479-3332</a></li>
                    <li><a href="#"><i class="fa fa-fax"></i>Fax: 905-479-9939</a></li>
                    <li><a href="#"><i class="fa fa-envelope"></i>Fax: 905-479-9939</a></li>
                </ul>
                </div>
            </div>
-->
                <div class="col-sm-4">
                <div class="tag-box tag-box-v3">
                    <h3>Canada Headquarters</h3>
                        
                          <ul class="list-unstyled who margin-bottom-30">
                    <li><a href="#"><i class="fa fa-home"></i> 3601 Hwy 7 East , HSBC Tower Suite 302 , Markham , Ontario L3R 0M3 CANDA</a></li>
                    <li><a href="#"><i class="fa fa-phone-square"></i> Phone: 905-479-9969</a></li>
                    <li><a href="#"><i class="fa fa-phone"></i> Toll free: 1-877-238-9898</a></li>
                    <li><a href="#"><i class="fa fa-fax"></i> Fax: 905-479-9939</a></li>
                </ul>
                    <p style="height:15px;">&nbsp;</p>
                </div>
            </div> 
                 </div>    
           
                <!-- End Clients Block-->     

        
    </div><!--/container-->     
    <!--=== End Content Part ===-->

    <script type="text/javascript" src="https://maps.google.com/maps/api/js?sensor=true"></script>
<script type="text/javascript" src="/plugins/gmap/gmap.js"></script>
<script type="text/javascript" src="/assets/js/forms/contact.js"></script>
<!-- JS Page Level -->

<script type="text/javascript" src="/js/pages/page_contacts.js"></script>
<script type="text/javascript" src="/js/forms/page_contact_form.js"></script>
<script type="text/javascript">
    jQuery(document).ready(function () {
        ContactPage.initMap();
       // ContactForm.initContactForm();
    });

    function DoGetAnotherWaterMark() {
        d= new Date();
        var sSource = '/Product/WaterMark.aspx?pn=<% =sPageName %>&dt=' + d.getTime();
        $("#imgWaterMark").attr("src", sSource);
    }
</script>
</asp:Content>
