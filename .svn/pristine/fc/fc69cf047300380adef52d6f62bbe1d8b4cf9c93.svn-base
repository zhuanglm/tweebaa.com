<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="TweebaaWebApp2.User.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Ready to start earning? Become a Tweebaa Member
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

  <link rel="stylesheet" href="/css/pages/log-reg-v3.css">  
    <link rel="stylesheet" href="/plugins/sky-forms/version-2.0.1/css/custom-sky-forms.css">
     <link rel="stylesheet" href="/plugins/sky-forms/version-2.0.1/css/sky-forms.css">
     <!--
     <script type="text/javascript" src="/js/forms/reg.js"></script>
     -->
     <!-- Login Form -->
<script src="/plugins/sky-forms/version-2.0.1/js/jquery.form.min.js"></script>
<!-- Validation Form -->
<script src="/plugins/sky-forms/version-2.0.1/js/jquery.validate.min.js"></script>

<style>
.reg-ok-box div.pr {
    padding-top: 45px;
    padding-left: 40px;
    padding-right: 40px;
}
.reg-ok-box
{
    height:auto;
    padding-bottom:20px;
}
.error_text
{
    color:#ff0000;
}
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

                    
<div class="log-reg-v3 content margin-bottom-30">
        <div class="container">
            <div class="row">
                
            <div class="col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
<form id="sky_form4" class="log-reg-block sky-form"  runat="server">
                        <h2>Create Your Account</h2>

                        <div class="login-input reg-input">
                      
                            <label class="select margin-bottom-15">
                                <select name="slCountry"  runat="server" id="selectCountry" >
                           
                                </select>
                            </label>
                       
                            <section>
                               <label class="input" id="labUsername">
                                        <i class="icon-append fa fa-user"></i>
                                        <input type="text" name="username"  id="txtLoginName" maxlength="50" onchange="verfy('username',this)" placeholder="Username">
                                        <b class="tooltip tooltip-bottom-right">Enter your user name</b>
                                        </label>
                                    <p class="error_text" id="errorUsername"></p>
                             </section>                            
                              <section>
                                    <label class="input" id="labEmail">
                                        <i class="icon-append fa fa-envelope"></i>
                                        <input type="email" name="email" id="txtEmail" maxlength="50" onchange="verfy('email',this)" placeholder="Email address">
                                        <b class="tooltip tooltip-bottom-right">Enter your email address</b>
                                    </label>
                                    <p class="error_text" id="errorEmail"></p>
                                </section>                               
                             <section>
                                    <label class="input" id="labPassword">
                                        <i class="icon-append fa fa-lock"></i>
                                        <input type="password" name="password" maxlength="10" placeholder="Password" id="password" class="userPwd">
                                        <b class="tooltip tooltip-bottom-right">Please enter your password,min length is 6 and at least one number </b>
                                    </label>
                                </section>                                
                             <section>
                                    <label class="input" id="labPassAgain">
                                        <i class="icon-append fa fa-lock"></i>
                                        <input type="password" name="passwordConfirm" maxlength="10" id="txtPassAgain"  placeholder="Confirm password" class="userPwd2">
                                        <b class="tooltip tooltip-bottom-right">Please enter your password again</b>
                                    </label>
                                </section>
                                 <label class="select margin-bottom-15">
                                 <!--
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
                                -->
                                <select id="ddlway"   onchange="ChangeDDL(this)">
                               <%=_knowWay %>
                                 </select>
<script type="text/javascript">
    function ChangeDDL(obj) {
        var value = $(obj).find("option:selected").attr("value");
        if (value == "-2") {
            $("#firendDiv").show();
        } else {
            $("#firendDiv").hide();
        }
    }
 </script>
                            </label>
 <div class="row">
                                <div class="col-sm-6">
 <div id="firendDiv" style="display:none; ">
                    
        <input type="text" class="txt email" placeholder="Tell us your friend's email so we can send a reward."
            id="txtReferrerEmail" style="width:350px; padding-left:5px; color:Black" /> </div>
 </div>
 </div> 
                            
                                      <div class="row">
                                <div class="col-sm-4">
                                    <section>
                                        <label class="input">
                                            <input type="text" id="ValiCode1" name="Verification" placeholder="Verification" class="form-control">
                                        </label>
                                    </section>
                                </div>
                                <div class="col-sm-8">
                                <table cellspacing="4" cellpadding="4">
                                    <tr>
                                        <td>
 <label id="code" style="width: 70px; height:38px;padding-top:6px;font-size:18px; background-image: url(../images/yzm.png);">        </label>
                                        </td>
                                        <td style="padding-left:40px;"> &nbsp;&nbsp;<a href="javascript:void(0)" class="fl resetYzm" onclick="CreateCode()">Try a different code.</a></td>
                                    </tr>
                                </table>

                                   
                                </div>
                                
                            </div>                               
                        </div>

                   
                        <label class="checkbox margin-bottom-20">
                            <input type="checkbox" name="checkbox" value='1' id="ckbAgree"/>
                            <i></i>
                            <h6> I have read and agreed with the <a href="#">terms &amp; conditions</a></h6>
                        </label>
                               <label class="checkbox margin-bottom-20">
                          <input type="checkbox" value='1' id="chkConsent" /><i></i>
                          <h6>I consent to receiving electronic communications from Tweebaa Inc. and its affiliates and subsidiaries in connection with the services offered by this website. I acknowledge that I may withdraw such consent at any time.</h6>
                        </label>
                        <button class="btn-u btn-u-sea-shop btn-block margin-bottom-20 send rounded" id="btnRegister" type="submit">Create Account</button>

                     </form>
			      <div class="margin-bottom-20"></div>
                    <p class="text-center">Already you have an account? <a href="/User/login.aspx" class="color-blue">Sign In</a></p>
                </div>
            </div><!--/end row-->
        <!-- Footer Version 3 -->
           </div><!--/end container-->
    </div>
    

     <!-- 弹出注册成功窗口 -->
    <div class="greybox" id="greybox" style="display: none;">
        <div class="reg-ok-box">
            <div class="box pr">
                <a href="#" class="closeBtn" title="Close" onclick="$('#greybox').css('display','none');"></a>
                <h2>
                    Thanks for registering!</h2>
                <p style="text-align: left;">
                Please check your email for a verification link, <br />
				then come on back to complete your registration.

                    <label id="labMessage1">
                    </label>
                </p>
                <div>
                    <a href="#" class="returnLogin" onclick="$('#greybox').css('display','none');window.location.href='login.aspx'">
                        Back to Login</a>
                </div>
            </div>
        </div>
    </div>
    <!-- 弹出注册失败窗口 -->
    <div class="greybox" id="greybox2" style="display: none;">
        <div class="reg-ok-box">
            <div class="box pr">
                <a href="javascript:void(0);" class="closeBtn" title="Close" onclick="$('#greybox2').css('display','none');"></a>
                <h3>
                    <label id="labTitle">
                    </label>
                </h3>
                <p>
                    <label id="labMessage">
                    </label>
                </p>
                <div>
                    <a href="javascript:void(0);" class="returnLogin" onclick="$('#greybox2').css('display','none');">Close</a>
                </div>
            </div>
        </div>
    </div>
    <style type="text/css">
        #code
        {
            text-align: center;
            font-family: Arial;
            font-style: italic;
            font-weight: bold;
            border: 0;
            letter-spacing: 2px;
            color: blue;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            //表单提示
            /*
            $("input.txt").placeholder();
            //表单美化
            $('.chklist').hcheckbox();
            //手机验证码提示
            $(".tel-yzm > a.pr").mouseenter(function (event) {
                $(this).find("b").show()
            }).mouseleave(function (event) {
                $(this).find("b").hide()
            });*/
        })
    </script>

    <script src="/js/reg.js?v=20160209" type="text/javascript"></script>

    <script type="text/javascript">
        function verfy(op, obj) {
            var val = $(obj).val();
            if (op == "email") {
                if (!validateEmail(val)) {
                    flag = "error";
                    /*
                    $("#emailTip").html("Please enter a valid email address").show();
                    $("#emailOk").hide();*/
                    $("#txtEmail").addClass("invalid");
                    $("#labEmail").addClass("state-error");
                    $("#errorEmail").html("Please enter a valid email address");
                   // $("#txtEmail").focus();
                    return;
                } else {
                    $("#txtEmail").removeClass("invalid");
                    $("#labEmail").removeClass("state-error");
                    $("#errorEmail").html("");
                }
            }

            if (op == "username") {
                if (val == "" || val.length < 2 || val.length > 20 || val.indexOf("@") > 0) {
                    flag = "error";
                    /*
                    $("#nameTip").html("Invalid Username").show();
                    $("#nameOk").hide();
                    */
                    $("#txtLoginName").addClass("invalid");
                    $("#labUsername").addClass("state-error");
                    $("#errorUsername").html("Username invalid");
                    //$("#txtLoginName").focus();
                    return;
                } else {
                /*
                    $("#nameOk").show();
                    $("#nameTip").hide();*/
                    $("#txtLoginName").removeClass("invalid");
                    $("#labUsername").removeClass("state-error");
                    $("#errorUsername").html("");
                }
            }

            var res = TweebaaWebApp2.User.register.verfy(op, val).value;
            if (res == "empty") {
                if (op == "email") {
                    flag = "error";
                    /*
                    $("#emailTip").html("please input your email").show();
                    $("#emailOk").hide();*/
                    $("#txtEmail").addClass("invalid");
                    $("#labEmail").addClass("state-error");
                    $("#errorEmail").html("Please enter a valid email address");
                   // $("#txtEmail").focus();
                }
                if (op == "username") {
                    flag = "error";
                    /*
                    $("#nameTip").html("please input your username").show();
                    $("#nameOk").hide();
                    */
                    $("#txtLoginName").addClass("invalid");
                    $("#labUsername").addClass("state-error");
                    $("#errorUsername").html("Please input your username");
                    //$("#txtLoginName").focus();
                }
                return false;
            }
            if (res == "fail") {
                if (op == "email") {
                    isexit = true;
                    /*
                    $("#emailTip").html("The email has been registered").show();
                    $("#emailOk").hide();*/
                    $("#txtEmail").addClass("invalid");
                    $("#labEmail").addClass("state-error");
                    $("#errorEmail").html("This email has been registered");
                   // $("#txtEmail").focus();
                }
                if (op == "username") {
                    isexit = true;
                    /*
                    $("#nameTip").html("The user name has been registered").show();
                    $("#nameOk").hide();*/
                    $("#txtLoginName").addClass("invalid");
                    $("#labUsername").addClass("state-error");
                    $("#errorUsername").html("Username exists or invalid,please choose another one");
                    //$("#txtLoginName").focus();
                }
                return false;
            }
            if (res == "success") {
                isexit = false;
                //$parent.find(".ok").css('display', 'block');
                if (op == "email") {
                    $("#txtEmail").removeClass("invalid");
                    $("#labEmail").removeClass("state-error");
                    $("#errorEmail").html("");
                }
                if (op == "username") {
                /*
                    $("#nameOk").show();
                    $("#nameTip").hide();*/
                    $("#txtLoginName").removeClass("invalid");
                    $("#labUsername").removeClass("state-error");
                    $("#errorUsername").html("");
                }
            }
            return true;
        }
                         </script>




<script>
    jQuery(document).ready(function () {
        App.init();
        // RegForm.initRegForm();
        // LoginForm.initLoginForm();
        // ContactForm.initContactForm();
        // CommentForm.initCommentForm();
        StyleSwitcher.initStyleSwitcher();

        //if login, jump to already login page
        if (CheckUserLogin()) {
            window.location.href = "/User/Logined.aspx";
        }
    });
</script>
</asp:Content>
