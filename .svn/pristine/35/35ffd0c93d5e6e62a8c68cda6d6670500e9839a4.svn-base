<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="resetpwd3.aspx.cs" Inherits="TweebaaWebApp2.User.resetpwd3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
   <!-- <link rel="stylesheet" href="assets/plugins/sky-forms/version-2.0.1/css/sky-forms.css"> -->
    <link rel="stylesheet" href="/css/pages/log-reg-v3.css">  
    	<script src="/js/jquery.placeholder2.js" type="text/javascript"></script>	
    <script src="/MethodJs/updatePwd.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

 <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Password Retrieval</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="../index.aspx">Home</a></li>
                <li><a href="#">Login</a></li>
                <li class="active">Password Retrieval</li>
            </ul>
        </div><!--/container-->
    </div><!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->

        <!-- log-reg-v3 -->
        <div class="log-reg-v3 content margin-bottom-30">
        <div class="container">
            <div class="row">
                
            <div class="col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                  <!--
                    <form id="sky-form4" class="log-reg-block sky-form">
                    -->
                         <p>Your Member account has been verified. Please reset your password below.</p><br/>

                        <div class="login-input reg-input">
    <section>
                                <label class="input">
                                    <input type="password" name="password" maxlength="10" placeholder="Password" id="password" class="form-control userPwd">
                                    <span class="error">Must contain numbers and letters</span>
					                <span class="ok">ok</span>
                                </label>
                            </section>                                
                            <section>
                                <label class="input">
                                    <input type="password" name="passwordConfirm" maxlength="10" placeholder="Confirm password" class="form-control userPwd2">
					                <span class="error" id="pwdError1">Passwords do not match</span>
                                    <span class="error" id="pwdError2">Must contain numbers and letters</span>
					                <span class="ok">ok</span>
                                </label>
                            </section>                              
                      
                      
                            <button class="btn-u btn-u-sea-shop btn-block margin-bottom-20 rounded" onclick="ResetPwd()">Reset Password</button>                      
                        </div>

                  
                     <!--  
                    </form>
                    -->
                    <div class="margin-bottom-20"></div>
                   
                </div>
            </div><!--/end row-->
        <!-- Footer Version 3 -->
           </div><!--/end container-->
    </div>

    <div class="greybox" id="greybox" style="display: none;">
	<div class="reg-ok-box">
		<div class="box pr">
			<a  href="javascript:void(0);" onclick="$('#greybox').css('display','none'); " class="closeBtn" title="Close"></a>
			<h2><label id="labTitle1">Success!</label></h2>
			<p>
				<label id="labMessage1">Your password has been reset.</label> 
			</p>
			<div>
				<a  href="javascript:void(0);"  class="returnLogin" onclick="$('#greybox').css('display','none'); window.location.href = 'login.aspx';">Login to Tweebaa</a>
			</div>
		</div>
	</div>
</div>

    <div class="greybox" id="greybox2" style="display: none;">
	<div class="reg-ok-box">
		<div class="box pr">
			<a href="javascript:void(0);" class="closeBtn" title="Close" onclick="onclick="$('#greybox2').css('display','none');""></a>
			<h2><label id="labTitle2">Reset password</label></h2>
			<p>
				<label id="labMessage2"></label> 
			</p>
			<div>
				<a  href="javascript:void(0);"  class="returnLogin" onclick="$('#greybox2').css('display','none');">Submit</a>
			</div>
		</div>
	</div>
</div>

</asp:Content>
