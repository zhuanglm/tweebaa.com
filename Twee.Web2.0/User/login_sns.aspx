<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="login_sns.aspx.cs" Inherits="TweebaaWebApp2.User.login_sns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Log in to start earning 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
<link rel="stylesheet" href="/css/pages/log-reg-v3.css"> 

    <link rel="stylesheet" href="../css/index.css" />
    <link rel="stylesheet" href="../css/selectCss.css" />
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>

    <script src="../js/apic.js"></script>
    <script src="../js/login.js" type="text/javascript"></script>
    <script src="../js/jquery.placeholder2.js" type="text/javascript"></script>
    <script src="../js/FacebookAPI.js" type="text/javascript"></script>
    <script src="../js/TwitterAPI.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/public.js"></script>
    <script src="../MethodJs/logion.js" type="text/javascript"></script>
    <style type="text/css">
        a:hover {
         text-decoration:none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
<div id="fb-root"></div>

        <!--=== Login ===-->
    <div class="log-reg-v3 content">
               <input type="hidden" id="redirectTip" value="<%=op %>" />
            <input type="hidden" id="redirectArg" value="<%=args %>" />
        <div class="container">
        
            <div class="row">
                <div class="col-md-5 md-margin-bottom-50">
                <!-- Magazine Slider -->
            <div class="carousel slide carousel-v2 margin-bottom-40" id="portfolio-carousel">
                <ol class="carousel-indicators mar-top">
                    <li class="active rounded-x" data-target="#portfolio-carousel" data-slide-to="0"></li>
                    <li class="rounded-x" data-target="#portfolio-carousel" data-slide-to="1"></li>
                   
                    <li class="rounded-x" data-target="#portfolio-carousel" data-slide-to="2"></li>
                     <li class="rounded-x" data-target="#portfolio-carousel" data-slide-to="3"></li>
                </ol>
                
                <div class="carousel-inner">
                    <div class="item active">
                        <img class="img-responsive imgcenter" src="/images/submit-login.png" alt="submit">
                          <div class="info-block-in">
                            <h3 class="txtcenter">Plant the seed of your product.</h3>
                            <p class="txtcenter">As a successful submitter you can enjoy the growth <br> of your product and be considered an expert  <br> in finding products while receiving income. </p>
                        </div>    
                    </div>
                    <div class="item">
                      <img class="img-responsive imgcenter" src="/images/evaluate-login.png" alt="evaluate">
                             <div class="info-block-in">
                            <h3 class="txtcenter">You are the sunshine and rain of  Tweebaa.</h3>
                            <p class="txtcenter">You can help the seed grow into a profitable product <br> while receiving an income.</p>
                        </div>  
                    </div>
                    <div class="item">
                        <img class="img-responsive imgcenter" src="/images/shop-login.png" alt="shopping">
                          <div class="info-block-in">
                            <h3 class="txtcenter" >Pick from wide selection of Tweebaa products.</h3>
                            <p class="txtcenter">Tweebaa offers a wide selection of competitively priced <br> quality products for delivery around the world.</p>
                        </div>   
                    </div>
                         <div class="item">
                        <img class="img-responsive imgcenter" src="/images/share-login.png" alt="share">
                              <div class="info-block-in">
                            <h3 class="txtcenter">Grow your potential utilizing your social networks.</h3>
                            <p class="txtcenter">By using the power of the internet, you can enjoy in the promotion and sales of your favorite products through your personal social media network, and earn in the process.</p>
                        </div>  
                    </div>
                </div>
                
            
            </div>
            <!-- End Magazine Slider -->
                 
                </div>

                <div class="col-md-5 col-sm-offset-1" id="divLoginMain">
                    <form id="sky-form1" class="log-reg-block sky-form" method="post">
                        <h2>Log in to your account</h2>

                        <section>
                            <label class="input login-input">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                    <input type="email" placeholder="Email Address" name="txtEmail" id="txtEmail" class="form-control">
                                </div>
                            </label>
                        </section>        
                        <section>
                            <label class="input login-input no-border-top">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                    <input type="password" placeholder="Password" name="password" id="txtPwd" class="form-control">
                                </div>    
                            </label>
                        </section>
                        <div class="row margin-bottom-15">
                            <div class="col-xs-6">
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"/>
                                    <i></i>
                                    Remember me
                                </label>
                            </div>
                            <div class="col-xs-6 text-right">
                                <a href="/User/resetpwd.aspx">Forget your Password?</a>
                            </div>
                        </div>
                        <button class="btn-u btn-u-sea-shop btn-block margin-bottom-20" onclick="LogionFuc();return false;">Log in</button>

                       
                        <div class="border-wings">
                            <span>or</span>
                        </div>
                            
                        <div class="row columns-space-removes">
                            <div class="col-lg-6 margin-bottom-10">
                            <!-- <div class="fb-login-button" data-max-rows="1" data-size="xlarge" data-show-faces="false" data-auto-logout-link="false"></div>  -->
                                <fb:login-button scope="public_profile,email" data-size="xlarge" onlogin="FBCheckLoginState();"></fb:login-button>
                               <!--  <button type="button" onclick="DoFBLogin()" class="btn-u btn-u-md btn-u-fb btn-block"><i class="fa fa-facebook"></i> Facebook Log In</button> -->
                            </button>

                            </div>
                            
                            <div class="col-lg-6">
                               <button type="button" onclick="DoTwitterLogin()" class="btn-u btn-u-md btn-u-tw btn-block"><i class="fa fa-twitter"></i> Twitter Log In</button>
                            </div>  
                           
                        </div>
                        
                        <div class="row" id="twitter_container"></div> 
                    </form>
                    
                    <div class="margin-bottom-20"></div>
                    <p class="text-center">Don't have account yet? Learn more and <a href="/User/register.aspx">Sign Up</a></p>
                </div>
            </div><!--/end row-->
        </div><!--/end container-->
    </div>
    <!--=== End Login ===-->   

</asp:Content>
