<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="register_new.aspx.cs" Inherits="TweebaaWebApp2.User.register_new" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

      <link rel="stylesheet" href="/css/pages/log-reg-v3.css">  
    <link rel="stylesheet" href="/plugins/sky-forms/version-2.0.1/css/custom-sky-forms.css">
     <link rel="stylesheet" href="/plugins/sky-forms/version-2.0.1/css/sky-forms.css">
     <script type="text/javascript" src="/js/forms/reg.js"></script>
     <!-- Login Form -->
<script src="/plugins/sky-forms/version-2.0.1/js/jquery.form.min.js"></script>
<!-- Validation Form -->
<script src="/plugins/sky-forms/version-2.0.1/js/jquery.validate.min.js"></script>
<script>
    jQuery(document).ready(function () {
        App.init();
        RegForm.initRegForm();
        LoginForm.initLoginForm();
        ContactForm.initContactForm();
        CommentForm.initCommentForm();
        StyleSwitcher.initStyleSwitcher();
    });
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

<div class="log-reg-v3 content margin-bottom-30">
        <div class="container">
            <div class="row">
                
            <div class="col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                    <form id="sky-form4" class="log-reg-block sky-form" action="#">
                        <h2>Create New Account</h2>

                        <div class="login-input reg-input">
                      
                            <label class="select margin-bottom-15">
                                <select name="gender" class="form-control">
                                    <option value="0" selected disabled>Choose Your Country</option>
                                    <option value="1">USA</option>
                                    <option value="1">Canada</option>
                                
                                </select>
                            </label>
                       
                            <section>
                               <label class="input">
                                        <i class="icon-append fa fa-user"></i>
                                        <input type="text" name="username" placeholder="Username">
                                        <b class="tooltip tooltip-bottom-right">Enter your user name</b>
                                        </label>
                             </section>                            
                              <section>
                                    <label class="input">
                                        <i class="icon-append fa fa-envelope"></i>
                                        <input type="email" name="email" placeholder="Email address">
                                        <b class="tooltip tooltip-bottom-right">Enter your email address</b>
                                    </label>
                                </section>                               
                             <section>
                                    <label class="input">
                                        <i class="icon-append fa fa-lock"></i>
                                        <input type="password" name="password" placeholder="Password" id="password">
                                        <b class="tooltip tooltip-bottom-right">Don't forget your password</b>
                                    </label>
                                </section>                                
                             <section>
                                    <label class="input">
                                        <i class="icon-append fa fa-lock"></i>
                                        <input type="password" name="passwordConfirm" placeholder="Confirm password">
                                        <b class="tooltip tooltip-bottom-right">Don't forget your password</b>
                                    </label>
                                </section>
                                 <label class="select margin-bottom-15">
                                <select name="gender" class="form-control">
                                    <option value="-1" selected disabled>Where did you hear about Tweebaa</option>
                                    <option value="-2">Friend</option>
                                    <option value="1">Online Advertisement</option>
                                    <option value="2">Social Media post</option>
                                    <option value="3">Newspaper</option>
                                    <option value="4">Magazine</option>
                                    <option value="5">Tradeshow</option>
                                    <option value="7">Other</option>
                                
                                </select>
                            </label>
                                      <div class="row">
                                <div class="col-sm-6">
                                    <section>
                                        <label class="input">
                                            <input type="text" name="Verification" placeholder="Verification" class="form-control">
                                        </label>
                                    </section>
                                </div>
                                <div class="col-sm-6">
                                   <a style=" line-height:40px"> Get another code </a>  
                                </div>
                            </div>                               
                        </div>

                   
                        <label class="checkbox margin-bottom-20">
                            <input type="checkbox" name="checkbox"/>
                            <i></i>
                            <h6> I have read agreed with the <a href="#">terms &amp; conditions</a></h6>
                        </label>
                               <label class="checkbox margin-bottom-20">
                          <input type="checkbox" value='1' id="chkConsent" /><i></i>
                          <h6>I consent to receiving electronic communications from Tweebaa Inc. and its affiliates and subsidiaries in connection with the services offered by this website. I acknowledge that I may withdraw such consent at any time.</h6>
                        </label>
                        <button class="btn-u btn-u-sea-shop btn-block margin-bottom-20" type="submit">Create Account</button>
                    </form>

                    <div class="margin-bottom-20"></div>
                    <p class="text-center">Already you have an account? <a href="shop-ui-login.html">Sign In</a></p>
                </div>
            </div><!--/end row-->
        <!-- Footer Version 3 -->
           </div><!--/end container-->
    </div>
</asp:Content>
