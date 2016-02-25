<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="login.aspx.cs" Inherits="TweebaaWebApp.User.logion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Log in to start earning 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="../Css/index.css" />
    <link rel="stylesheet" href="../Css/selectCss.css" />
    <script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
    <%--<script src="http://www.web63.cn/jss/apic.js" type="text/javascript"></script>--%>
    <script src="../Js/apic.js"></script>
    <script src="../Js/login.js" type="text/javascript"></script>
    <script src="../Js/jquery.placeholder2.js" type="text/javascript"></script>

    <script type="text/javascript" src="../Js/public.js"></script>
    <script src="../MethodJs/logion.js" type="text/javascript"></script>
    <style type="text/css">
        a:hover {
         text-decoration:none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <div style="clear: both;"></div>
    <div class="login-main">
        <div class="w">
            <input type="hidden" id="redirectTip" value="<%=op %>" />
            <input type="hidden" id="redirectArg" value="<%=args %>" />

            <table style="width:975px;">
                <tr>
                    <td style="margin-right:50px;">
                        <div class="fl flashbox">
                            <div class="screen hid pr">
                           <ul>
					<li>
						<a href="#"><img src="../images/430x360.png" alt="" /></a>
					</li>
					<li>
						<a href="#"><img src="../images/430x360b.png" alt="" /></a>
					</li>
					<li>
						<a href="#"><img src="../images/430x360c.png" alt="" /></a>
					</li>
	                 <li>
						<a href="#"><img src="../images/430x360d.png" alt="" /></a>
					</li>
				</ul>

                            </div>
                            <div class="dian tc">
                                <span class="active"></span><span></span><span></span>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="login-main-box fr">
                            <%--<div class="other-login" style="height: 110px;">
                                <h2>Social Media Login</h2>
                                <p class="tc">
                                    <a href="#">
                                        <img src="../Images/flat-circles_03s.png" alt="" /></a> <a href="#">
                                            <img src="../Images/flat-circles_05s.png" alt="" /></a> <a href="#">
                                                <img src="../Images/flat-circles_13s.png" alt="" /></a><a href="#">
                                                    <img src="../Images/flat-circles_07s.png" alt="" /></a> <a href="#">
                                </p>
                            </div>--%>
                        <h1>Login</h1>
                            <div class="box">
                                <%--<div class="tipsbox">
					 <div class="tips-error">
					 	Please enter a valid email address
					 </div>
				    </div>--%>
                                <div class="item user">
                                    <input type="text" id="txtEmail" placeholder="Email / User Name" class="email" />
                                   <!-- <span style="padding-left:5px;" id="logEmail">Email：</span> -->
                                   
                                </div>
                                <div class="item pwd">
                                    <input type="password" id="txtPwd" placeholder="Password" class="userPwd"/>
                                     <!--  <span style="padding-left:5px;" id="Span1">Password：</span> -->
                                </div>
                                <div class="submit-box" style="padding-bottom: 10px; padding-top: 5px;">
                                    <table style="width: 300px;">
                                        <tr>
                                            <td>
                                                <input type="checkbox" value='1' />&nbsp;Remember Me</td>
                                            <td style="text-align: left;"><a href="resetpwd.aspx" style="color: red; padding: 0px;">Forgot Password</a></td>
                                        </tr>
                                    </table>


                                </div>
                                <div class="submit-box" style="width: 400px; padding: 0px;">
                                    <table style="width: 300px;">
                                        <tr>
                                            <td>
                                                <input id="btnLogin" type="button" class="submit-btn send" value="Login" onclick="LogionFuc()" style="width: 130px;" /></td>
                                            <td style="text-align: left; vertical-align: middle;"><a href="register.aspx">Register</a></td>
                                        </tr>
                                    </table>
                                    <%--<input type="button" class="submit-btn send" value="Login" onclick="LogionFuc()" style="width: 130px;" />
                            Not Registered?<a href="register.aspx">Join Now</a>--%>
                                </div>
                                <div class="submit-box" style="padding-bottom: 10px; padding-top: 5px; display:none">
                                    <table style="width: 300px;">
                                        <tr>
                                          <fb:login-button scope="public_profile,email" onlogin="FBCheckLoginState();"></fb:login-button>
                                        </tr>
                                     </table>
                                 </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <script type="text/javascript">
            $(".login-main").apic()
        </script>
        <!-- 弹出注册失败窗口 -->
        <div class="greybox" id="greybox" style="display: none;">
            <div class="reg-ok-box">
                <div class="box pr">
                    <a href="javascript:void(0);" class="closeBtn" title="Close" onclick="$('#greybox').css('display','none');"></a>
                    <h2>
                        <label id="labTitle">
                            Logon failure</label></h2>
                    <p>
                        <label id="labMessage">
                        </label>
                        <%--<label id="labError"></label>--%><br />
                    </p>
                    <div>
                        <a href="javascript:void(0);" class="returnLogin" onclick="$('#greybox').css('display','none');">Close</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both;"></div>
    <script src="../Js/FacebookAPI.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("body").keydown(function (evt) {
                evt = (evt) ? evt : ((window.event) ? window.event : "");
                var k = window.event?evt.keyCode : evt.which;
                if (k == 13) {
                    var email = $("#txtEmail").val();
                    var pwd = $("#txtPwd").val();
                    if (email == "" || pwd == "") {
                        alert("please input email or pwd");
                        return;
                    }
                    $("#btnLogin").click();
                }
            });
        })

    </script>
</asp:Content>
