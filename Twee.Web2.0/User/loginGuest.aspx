﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="loginGuest.aspx.cs" Inherits="TweebaaWebApp2.User.loginGuest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
<link rel="stylesheet" href="/css/pages/log-reg-v3.css"> 
    <!-- CSS Theme -->
<link rel="stylesheet" href="/css/theme-colors/default.css" id="style_color">
     
    <script src="../MethodJs/logion.js" type="text/javascript"></script>
     <script src="/js/FacebookAPI.js" type="text/javascript"></script>
    <script src="/js/TwitterAPI.js" type="text/javascript"></script>

<style>
        #divFBButton .btn-u, #divFBButton .btn-block 
        {
            text-align: left;
        }
        /*
           #divFBButton .fb_iframe_widget
         {
             margin-left:-10px;
         }*/
      <% if(browserName!="Safari"){ %> 
         #divFBButton .fb_iframe_widget
         {
             margin-left:-10px;
         }
       <% }else{ %>    
           #divFBButton .fb_iframe_widget
         {
             margin-left:70px;
         }               
       <% } %>     
         .btn-u.btn-u-fb i, .btn-u.btn-u-tw i
         {
             margin-right:5px !important;
         }     
         /*
         #siteseal 
         {
             width:120px;
             height:120px;
         }
         #siteseal img
         {
             width:100px;
             height:100px;
         } */
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">    


               <input type="hidden" id="redirectTip" value="<%=op1 %>" />
            <input type="hidden" id="redirectArg" value="<%=args %>" />
           <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Select account</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="../index.aspx">Home</a></li>
                <li class="active">Select account</li>
            </ul>
        </div><!--/container-->
    </div><!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->

        <!-- log-reg-v3 -->
        <div class="log-reg-v3 content margin-bottom-30">
        <div class="container">



            <div class="row">
                
            <div class="col-md-4 ">
                      <form runat="server"  class="log-reg-block sky-form" onsubmit="return false;">
                        <h2>NOT A MEMBER (YET) </h2>
                        <div style="display:none"> <select name="slCountry" class="form-control" runat="server" id="selectCountry" ></select></div>
                        <div>
                        <p>Not a Tweebaa member?</p><br />
                        <p>Join now (It's FREE) ... and you can sart EARNING with this purchase!</p>
                        </div>

                       
                        <ul class="badge-lists noneli" >
                                <li>
                                     <button class="btn-u btn-u-sea-shop btn-block rounded margin-bottom-20" id="btnCreateAccount" onclick="window.location.href='/User/register.aspx';return false;">Create Account</button>
                        <span class="badge badge-sea rounded">FREE</span>
                                </li>
                              
                            </ul>
                  
                    </form>
                   
               
                </div>
                   <div class="col-md-4">
                    <form id="sky-form1" class="log-reg-block sky-form">
                        <h2>RETURNING MEMBERS</h2>

                        <section>
                            <label class="input login-input">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                    <input type="email" placeholder="Email Address" name="email" id="txtEmail" class="form-control">
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
                        <div class="row margin-bottom-5">
                            <div class="col-xs-12">
                                <label class="checkbox">
                                    <input type="checkbox" name="checkbox"/>
                                    <i></i>
                                    Remember me
                                </label>
                            </div>
                            <div class="col-xs-12 margin-bottom-10">
                                <a href="/User/resetpwd.aspx">Forget Your Password?</a>
                            </div>
                        </div>
                        <button class="btn-u btn-u-sea-shop btn-block margin-bottom-20 rounded" onclick="LogionFuc();return false;">Log in</button>
                        
                        <div class="border-wings">
                            <span>or</span>
                        </div>
                            
                        <div class="row columns-space-removes">
                            <div class="col-lg-12 margin-bottom-10" id="divFBButton">
                              <!--  <fb:login-button scope="public_profile,email" data-size="large" class="btn-u btn-u-md btn-u-fb btn-block" onlogin="FBCheckLoginState();"></fb:login-button> -->
                              <div class="btn-u btn-u-md btn-u-fb btn-block rounded" id="div1"> 
                              <fb:login-button scope="public_profile,email" data-size="large"  onlogin="FBCheckLoginState();">Facebook Log In</fb:login-button> 
                              </div> 
                            </div>
                            <div class="col-lg-12">
                            
                                <button type="button" onclick="DoTwitterLogin()" class="btn-u btn-u-md btn-u-tw btn-block rounded"><i class="fa fa-twitter"></i> Twitter Log In</button>
                            
                            </div>
                        </div>
                       
                    </form>
             
                </div>
                
                <div class="col-md-4">
     <div class="row">
     <form  class="log-reg-block sky-form" method="post" action="<%=sGuestCheckoutURL %>?type=guest">
                        <h2>CHECKOUT AS GUEST</h2>

        
                        <div class="row margin-bottom-5">
                            <div class="col-xs-12">
                                <label >
                          Don't have an account and you don't want to register? Checkout as a guest instead!
                                </label>
                            </div>
                        
                        </div>
                        <button class="btn-u btn-u-sea-shop btn-block margin-bottom-20 rounded" type="submit" onclick="Loading(true);CheckOut()"> Checkout as Guest</button>

                           

                    </form>
                  <!-- etrus<div class="ct"> <img src="../images/etrust_mark_header.gif" width="70%"></div>   -->
                     
     </div>
     <div class="row">
     <!--
    <span id="ddd"><script type="text/javascript" src="https://seal.godaddy.com/getSeal?sealID=QKFiCN9bnev4AWUXemzt7uT08mVEACGdfB421KfGA2SQBvO97n1zCYcA0v84"></script></span> 
    -->
 <span id="siteseal"><img src="/images/siteseal_gd_3_h_d_m.gif" alt="Godaddy Tweebaa SSL Certificate" /></span>
     </div>
                   
             
                </div>
             
                </div>
            </div><!--/end row-->
        <!-- Footer Version 3 -->
           </div><!--/end container-->
    </div>
        <script type="text/javascript">
        /*
            $(".login-main").apic();
            function Reg() {
                window.location.href = "../User/register.aspx";
            }*/
            function CheckOut() {
                window.location.href = "../Product/shopOrder.aspx?type=guest";
            }
    </script> <!-- 弹出注册成功窗口 -->
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

    <script type="text/javascript">
        var flag = "ok";
        function verfy(op, obj) {
            if ( document.readyState !== 'complete' ) return true; //We must wait for Document Load Ready
            var val = $(obj).val();
            if (op == "email") {
                if (!/.+@.+\.[a-zA-Z]{2,4}$/.test(val) && !/^1\d{10}$/.test(val)) {
                    flag = "error";
                    $("#emailTip").html("Please enter a valid email address").show();
                    $("#emailOk").hide();
                    return;
                }
            }

            if (op == "username") {
                if (val == "" || val.length < 2 || val.length > 20) {
                    flag = "error";
                    $("#nameTip").html("Username does not meet criteria").show();
                    $("#nameOk").hide();
                    return;
                }
            }

            var res = TweebaaWebApp2.User.loginGuest.verfy_account(op, val).value;
            if (res == "empty") {
                if (op == "email") {
                    flag = "error";
                    $("#emailTip").html("please input your email").show();
                    $("#emailOk").hide();
                }
                if (op == "username") {
                    flag = "error";
                    $("#nameTip").html("please input your username").show();
                    $("#nameOk").hide();
                }
                return false;
            }
            if (res == "fail") {
                if (op == "email") {
                    isexit = true;
                    $("#emailTip").html("The email has been registered").show();
                    $("#emailOk").hide();
                }
                if (op == "username") {
                    isexit = true;
                    $("#nameTip").html("The user name has been registered").show();
                    $("#nameOk").hide();
                }
                return false;
            }
            if (res == "success") {
                isexit = false;
                //$parent.find(".ok").css('display', 'block');
                if (op == "email") {
                    $("#emailOk").show();
                    $("#emailTip").hide();
                }
                if (op == "username") {
                    $("#nameOk").show();
                    $("#nameTip").hide();
                }
            }
            return true;
        }

        //加载验证码
        $(document).ready(function () {
            // check if there is a reference email ( ?ref= )
            // auto select friend if there is a reference email
            var parm = location.search;
            var refEmail = "";
            if (parm != null && parm != "") {
                var iPos = parm.indexOf("ref=");
                if (iPos != -1) {
                    refEmail = parm.substring(iPos + 4, parm.length);
                }
            }
            if (refEmail != "") {
                $("#ddlway").val("-2");  // by friend
                $("#firendDiv").show();
                $("#txtReferrerEmail").val(refEmail);
            }
            CreateCode();
            //hide every error first
            $("#nameTip").hide();
            $("#emailTip").hide();
            $("#pwdTip").hide();
            $("#pwdTip2").hide();
        });

        //生成验证码
        function CreateCode() {
            var code = "";
            var codeLength = 4; //验证码的长度  
            //var checkCode = document.getElementById("code");
            var random = new Array(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R',
        'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'); //随机数  
            for (var i = 0; i < codeLength; i++) {//循环操作  
                var index = Math.floor(Math.random() * 36); //取得随机数的索引（0~35）  
                //alert(index);
                code += random[index]; //根据索引取得随机数加到code上

            }
            //checkCode.innerText = code; //把code值赋给验证码
            $("#code").html(code);

        }

        //注册事件
        function CreateAccount() {
            //  alert('ooooo');
            $("#btnCreateAccount").attr('disabled','disabled');
            if (!($("#emailTip").is(":hidden") && $("#nameTip").is(":hidden") && $("#pwdTip").is(":hidden") && $("#pwdTip2").is(":hidden"))) {
                $("#btnCreateAccount").removeAttr('disabled');
                return;
            }
            if (document.getElementById("ckbAgree").checked == false) {
                $("#labTitle").html("Registration Agreement");
                $("#labMessage").html("You must agree to our Terms of Service");
                $("#greybox2").show();
                $("#btnCreateAccount").removeAttr('disabled');
                return;
            }
           
            //var numError = THIS.find('.onError').length;
            var Email = $("#txtEmail2").val();
//            if (Email == "" || Email == null || !/.+@.+\.[a-zA-Z]{2,4}$/.test(Email) && !/^1\d{10}$/.test(Email)) {
//                flag = "error";
//                $("#emailTip").html("Please enter a valid email address").show();
//                $("#emailOk").hide();
//                return;
//            }

            var LoginName = $("#txtLoginName").val();
//            if (LoginName == "" || LoginName.length < 2 || LoginName.length > 20 || !isNaN($.trim(LoginName).split("")[0])) {
//                flag = "error";
//                $("#nameTip").show();
//                return;
//            }

            if (flag != "error") {
                var regType = "1";
                var codeStr1 = $("#ValiCode1").val(); //文本验证码
                // var code = document.getElementById("code").innerText;
                var code = $("#code").html();
                if (codeStr1 == "" || codeStr1.toUpperCase() != code) {
                    $("#labTitle").html("Enter the verification code");
                    $("#labMessage").html("Verification code input error");
                    $("#greybox2").show();
                    $("#btnCreateAccount").removeAttr('disabled');
                    return;
                }


                var Email = $("#txtEmail2").val();
                var Pass = $("#txtPass").val();
                var PassAgain = $("#txtPassAgain").val();
                var Country = $("#WebContent_selectCountry  option:selected").val();


                var tuijieEmail = $("#txtReferrerEmail").val();
                var knowWay = $("#ddlway option:selected").val();

                //                var obj = document.getElementById("<%=selectCountry.ClientID %>"); //定位id
                //                var index = obj.selectedIndex; // 选中索引               
                //                var Country = obj.options[index].value; // 选中值

                var Consent = 0;// document.getElementById("ckbAgree").checked;

                Apost(Email, LoginName, Pass, PassAgain, Country, tuijieEmail, knowWay, Consent);
            }
        }
          //注册请求
        function Apost(Email, LoginName, Pass, PassAgain, Country, tuijieEmail, knowWay, Consent) {
            Loading(true);
            var _data = 'Email=' + Email + "&LoginName=" + LoginName + "&Pass=" + Pass + "&Country=" + Country + "&TuiJieEmail=" + tuijieEmail + "&KnowWay=" + knowWay + "&Consent=" + Consent;
            $.ajax({
                type: "POST",
                url: '/AjaxPages/registerAjax.aspx',
                data: _data,
                success: function (msg) {
                    Loading(false);
                    $("#labTitle").html("User registration");
                    if (msg == "1") {
                       // $("#labMessage1").html("The activation email has been sent. <br> Please login and activate your account.");
                        $("#greybox").show();
                        return;
                    }
                    else if (msg == "-1") {
                        $("#labMessage").html("The mailbox is already registered");
                        $("#greybox2").show();
                    }
                    else {
                        $("#labMessage").html("Registration failed, please try again later");
                        $("#greybox2").show();
                    }
                },
                error: function (msg) {
                    $("#labMessage").html("Registration failed, please try again later");
                    $("#greybox2").show();
                }
            });
        }
        //输入验证
        function ValiInput(Email, LoginName, Pass, PassAgain, code) {
            if (!ValiEmail(Email)) {
                $("#txtEmailTip").show();
                return false;
            }
            if (LoginName == "") {
                $("#txtLoginNameTip").show();
                return false;
            }
            if (Pass == "") {
                $("#txtPassTip").show();
                return false;
            }
            if (Pass != PassAgain) {
                $("#txtPassAgainTip").show();
                return false;
            }
            if (code == "" || code.toUpperCase() != $("#code").text()) {
                $("#txtCodeTip").show();
                return false;
            }
            return true;
        }
  </script>

</asp:Content>
