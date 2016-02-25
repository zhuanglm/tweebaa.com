<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="resetpwd.aspx.cs" Inherits="TweebaaWebApp2.User.resetpwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">    <link rel="stylesheet" href="../css/selectCss.css" />
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <script src="../js/jquery.placeholder2.js" type="text/javascript"></script>
     <script src="../js/createCode.js" type="text/javascript"></script>
    <script src="../MethodJs/sendEmail.js?v=2016012611" type="text/javascript"></script>
        <link rel="stylesheet" href="/css/pages/log-reg-v3.css">
        <style type="text/css">  
    #code  
    {  
         text-align:center;
        font-family:Arial;  
        font-style:italic;  
        font-weight:bold;  
        border:0;  
        letter-spacing:2px;  
        color:blue;  
    }  
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
         <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Password Retrieval</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="../index.aspx">Home</a></li>
                <li><a href="/User/login.aspx">Login</a></li>
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
                    <form id="sky-form4" class="log-reg-block sky-form">
                         <p>To reset your password, just enter your email address below and we'll send you an email with further instructions.</p><br/>

                        <div class="login-input reg-input">
                                           
                            <section>
                                <label class="input">
                                    <input type="email" name="email" placeholder="Email address" id="txtEmail" class="form-control">
                                </label>
                                 <span class="error">Account you entered does not exist</span> <span class="ok">ok</span>
                            </section>                                
                      
                      
                                      <div class="row">
                                <div class="col-sm-6">
                                    <section>
                                        <label class="input">
                                            <input type="text" name="Verification" id="ValiCode1" placeholder="Verification" class="form-control">
                                        </label>
                                        <span class="error" id="yzmerror">Verification code is incorrect</span> <span class="ok" id="yzmok">ok</span>
                                    </section>
                                </div>
                                <div class="col-sm-6">
                                         <label id="code" style="float: left; width: 70px;font-size:18px; background-image: url(/images/yzm.png);">
                                        </label>
                                   <a style=" line-height:40px; cursor:pointer; padding-left:10px;" onclick="CreateCode()" >  Get another code </a>  
                                </div>
                            </div>                               
                        </div>

                   <!--
                        <label class="checkbox margin-bottom-20">
                            <input type="checkbox" name="checkbox"/>
                            <i></i>
                            I have read agreed with the <a href="#">terms &amp; conditions</a>
                        </label>
                       
                        <input type="text" class="txt telyzm" id="ValiCode2" />  -->
                        <input type="button" class="btn-u btn-u-sea-shop btn-block margin-bottom-20 submit-btn send  rounded" value="Submit" /> 
                        <!--
                        <button class="btn-u btn-u-sea-shop btn-block margin-bottom-20" type="submit">Create Account</button>
                        -->
                    </form>

                    <div class="margin-bottom-20"></div>
                    <p class="text-center">Already you have an account? <a href="/User/login.aspx" class="color-blue">Sign In</a></p>
                </div>
            </div><!--/end row-->
       
           </div><!--/end container-->
    </div>

    <div class="greybox" id="greybox2" style="display: none;">
	<div class="reg-ok-box">
		<div class="box pr">
			<a href="#" class="closeBtn" title="Close"></a>
			<h2><label id="labTitle">Reset Password</label></h2>
			<p>
				<label id="labMessage"></label>               	
			</p>
			<div>
				<a href="#" class="returnLogin" onclick="$('#greybox2').css('display','none');">Close</a>
			</div>
		</div>
	</div>

    </div>
    <script type="text/javascript">
    /*
        $(function () {
        
            $('input').placeholder();
          

        });*/
    </script>
    <script type="text/javascript">
        $(function () {
            //表单提示
           // $("input.txt").placeholder();

            //手机验证码提示
            /*
            $(".tel-yzm > a.pr").mouseenter(function (event) {
                $(this).find("b").show();
            }).mouseleave(function (event) {
                $(this).find("b").hide();
            });*/
        })
    </script>
    <script src="../js/resetpwd.js?v=20160126" type="text/javascript"></script>

</asp:Content>
