<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="register.aspx.cs" Inherits="TweebaaWebApp.User.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Ready to start earning? Become a Tweebaa Member
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

    <link rel="stylesheet" href="../Css/index.css" />
	<link rel="stylesheet" href="../Css/selectCss.css" />
    <script src="../Js/jquery.min.js" type="text/javascript"></script>  
    <script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
    <script src="../Js/jquery.placeholder2.js" type="text/javascript"></script>
    <!--
    <script src="../Js/createCode.js" type="text/javascript"></script>
    -->
     <script src="../MethodJs/register.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <form runat="server" id="Form1">
    <div class="reg-main">
        <div class="w">
             <!-- <div class="other-login">
                <p class="t">
                    Login with social media account</p>
                <p class="tl">
                    <a href="#">
                        <img src="../Images/flat-circles_03.png" alt="" /></a> <a href="#">
                        <img src="../Images/flat-circles_05.png" alt="" /></a> <a href="#">
                        <img src="../Images/flat-circles_13.png" alt="" /></a> <a href="#">
                        <img src="../Images/flat-circles_07.png" alt="" />
                    </a>
                </p>
            /div>-->
	<h1>Ready to start earning?<span style="padding-left:10px; padding-bottom: 10px; font-size:20px;"> Become a Tweebaa Member...</span> </h1>
            <table width="100%">
                <tr>
				<td class="t tr"><strong>Country</strong></td>
				<td>
					<div class="selectBox pr fl">
                        <select name="" class="selects" runat="server" id="selectCountry" style="width:270px; height:42px;">
                            <%--<option selected="selected">China </option>
                            <option>United States</option>
                            <option>Canada</option>
                            <option>Russian Federation</option>
                            <option>Australia</option>--%>
                        </select>
		             </div>
					<span class="error">PLease enter your email address</span>
					
				</td>
			</tr>
                <tr>
                    <td class="t tr">
                        <strong>Email</strong>
                    </td>
                    <td>
                        <input type="text" class="txt email" placeholder="PLease enter your email address"
                            id="txtEmail" maxlength="50" onchange="verfy('email',this)" />
                        <span class="error" id="emailTip">Please enter a valid email address</span> <span class="ok" id="emailOk">ok</span>
                         
                    </td>
                </tr>

                
                <%--<tr>--%>
                <!--<tr>

                    <td class="t tr">


                        <strong>Were you referred by a friend?</strong>
                    </td>
                    <td>
                        <input type="text" class="txt email" placeholder="Tell us your friend's email so we can send a reward."
                            id="txtReferrerEmail" />
                       <%-- <span class="error">Please enter a valid email address</span> <span class="ok">ok</span>--%>
                    </td>
                </tr> -->
                <tr>
                    <td class="t tr">

                        <strong>Username</strong>
                    </td>
                    <td>
                        <input type="text" class="txt yourname" placeholder="2-20 characters, start with letter"
                            id="txtLoginName" maxlength="50" onchange="verfy('username',this)" />
                        <span class="error" id="nameTip">Username does not meet criteria</span> <span class="ok" id="nameOk">ok</span>
                    </td>
                </tr>
                <tr>
                    <td class="t tr">
                        <strong>Password</strong>
                    </td>
                    <td>
                        <input type="password" class="txt userPwd" placeholder="6-20 characters" id="txtPass" />
                        <span class="error" id="pwdTip">Must contain numbers and letters </span> <span class="ok" id="pwdOk">ok</span>
                    </td>
                </tr>
                <tr>
                    <td class="t tr">
                        <strong>Retype password</strong>
                    </td>
                    <td>
                        <input type="password" class="txt userPwd2" placeholder="Re-enter your password again"
                            id="txtPassAgain" />
                        <span class="error" id="pwdTip2">Password does not match</span> <span class="ok">ok</span>
                    </td>
                </tr>
                <tr>
                    <td class="t tr" style="width:150px;">
                        <strong>Where did you hear about Tweebaa</strong>
                    </td>
                    <td>
                        <select id="ddlway" style="width:270px; height:42px;" onchange="ChangeDDL(this)">
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
                    </td>
                </tr>
                <tr id="firendDiv" style="display:none;">
                    <td class="t tr">
                        <strong>your friend's email</strong>
                    </td>
                    <td>
                        <input type="text" class="txt email" placeholder="Tell us your friend's email so we can send a reward."
                            id="txtReferrerEmail" style="width:350px;" />
                       <%-- <span class="error">Please enter a valid email address</span> <span class="ok">ok</span>--%>
                    </td>
                </tr>
                <tr>
                    <td class="t tr">
                        <strong id="yzm-style">Verification</strong>
                    </td>
                    <td>
                        <div class="email-yzm fl yzm-style">
                            <input type="text" id="ValiCode1" placeholder="Verification" class="txt yzm" />
                            <%--<img src="../Images/yzm.png" alt="" class="fl" />--%>
                            <%-- <span id="code"></span>--%>
                            <div style="float: left;">
                                <label id="code" style="float: left; width: 70px; font-size:18px; background-image: url(../Images/yzm.png);">
                                </label>
                                <a href="javascript:void(0)" class="fl resetYzm" onclick="CreateCode()">Get another code</a>
                            </div>
                        </div>
                        <span class="error" id="errorCode">Verification code is incorrect</span> <span class="ok"
                            id="okCode">ok</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="t tr">
                      <div class="re-pwd tl">
                        <div class="chklist fl">
                          <input type="checkbox" value='1' id="ckbAgree" />
                          <label>I have read and agree to the terms outlined in</label>
                        </div>
                        <a href="/College/Genernal_Terms_ofUse.aspx" target="_blank">&nbsp;Tweebaa Terms and Conditions agreement&nbsp;</a>
                        <div class="chklist fl">
                          <input type="checkbox" value='1' id="chkConsent" />
                          <label><strong>I consent to receiving electronic communications from Tweebaa Inc. and its affiliates and subsidiaries in connection with the services offered by this website. I acknowledge that I may withdraw such consent at any time.</strong></label>
                        </div>
                      </div>
                   </td>
                </tr>
                <tr>
                </tr>
                    <td colspan=2>&nbsp; </td>
                <tr>
                    <td>&nbsp; </td>
                    <td>
                       <div class="submit-box">
                        <input type="button" class="submit-btn send"  value="Register" />
                        <%--onclick="RegFuc()" --%>
                        <span>Aleady a member? <a href="login.aspx">Login Now</a> </span>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
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
            $("input.txt").placeholder();
            //表单美化
            $('.chklist').hcheckbox();
            //手机验证码提示
            $(".tel-yzm > a.pr").mouseenter(function (event) {
                $(this).find("b").show()
            }).mouseleave(function (event) {
                $(this).find("b").hide()
            });
        })
    </script>
    <script src="../Js/reg.js" type="text/javascript"></script>

    <script type="text/javascript">
        function verfy(op, obj) {
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

            var res = TweebaaWebApp.User.register.verfy(op, val).value;
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
                         </script>
</asp:Content>
