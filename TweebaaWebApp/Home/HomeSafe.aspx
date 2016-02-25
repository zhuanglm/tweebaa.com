<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeSafe.aspx.cs" Inherits="TweebaaWebApp.Home.HomeSafe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />
    <title>Security Settings</title>
    <link rel="stylesheet" href="../css/index.css" />
    <link rel="stylesheet" href="../css/home.css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <script src="../js/selectNav.js" type="text/javascript"></script>
    <script src="../js/homePage.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../css/selectCss.css" />
    <script src="../js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/public.js"></script>
    <script type="text/javascript" src="../js/home-safe.js"></script>
    <script type="text/javascript" src="../MethodJs/register.js"></script>
    <script src="../Js/reg.js" type="text/javascript"></script>
    <script type="text/javascript" src="../MethodJs/homeSafe.js"></script>

</head>
<body>
    <div class="home-main fl">
        <div class="safe-main">
            <h2 class="t">Security Setting</h2>
            <p class="t">Your personal information is kept confidential by Tweebaa</p>
           <!--  Hide this bar base on issue #38
            <div class="your-account-level">
                <span class="t fl">Security Level </span><b class="fl">&nbsp; Low</b>
                <span class="jdt fl">
                    <i id="safe-level" style="width: 30%;"></i>
                </span>
            </div>
            -->
            <ul>
                <li style="display:none;">
                    <div id="phone-container" class="clearfix">
                        <i class="error"></i>
                        <b id="phone-safe-state">不安全</b>
                        <span id="phone">绑定手机号</span>
                        <b id="phone-state">未设置</b>
                        <a href="#" class="setBtn">设置</a>
                    </div>
                    <form>
                        <div class="setbox">
                            <table width="100%">
                                <tr>
                                    <td class="t">
                                        <strong>请输入手机号</strong>
                                    </td>
                                    <td>
                                        <input id="txtPhone" type="text" class="txt safe-tel" />
                                        <span class="error">请输入正确的手机号码</span>
                                        <span class="ok">ok</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <a id="btnPhoneNext" href="#" class="setbtn">下一步</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </form>
                </li>
                <li>
                    <div id="email-container" class="clearfix">
                        <i class="error"></i>
                        <b id="email-safe-state">Danger</b>
                        <span id="email">Email Address</span>
                        <b id="email-state" style=" width:150px;">Not Verify</b>
                        <a href="#" class="setBtn">Change email</a>
                    </div>
                    <form>
                        <div class="setbox">
                            <table width="100%">
                                <tr><td colspan="2"> To change the email address on your account, enter the NEW email address below, then we’ll send a verification email to that account</td></tr>
                                <tr>
                                    <td class="t">
                                        <strong>Email Address</strong>
                                    </td>
                                    <td>
                                        <input id="txtEmail" type="text" class="txt safe-email" />
                                        <span class="error">Please enter a valid email address</span>
                                        <span class="ok">ok</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <a id="btnEmail" href="#" class="setbtn">Verify email address</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </form>
                </li>
                <li>
                    <div class="clearfix">
                        <i class="ok"></i>
                        <b>Safe</b>
                        <span>Password</span>
                        <b style=" width:150px;">Already Setup</b>
                        <a href="#" class="setBtn">Change Password</a>
                    </div>
                    <form>
                        <div class="setbox" style="height: auto;">
                            <table width="100%">
                                <tr>
                                    <td class="t">
                                        <strong>Current Password</strong>
                                    </td>
                                    <td>
                                        <input type="password" class="txt" id="txtPwd" />
                                        <span class="error">Current Password</span>
                                        <span class="ok">ok</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="t">
                                        <strong>New Password</strong>
                                    </td>
                                    <td>
                                        <input type="password" class="txt set-pwd1" id="txtPwdNew1" />
                                       <%-- <span class="error">Retype Password</span>
                                        <span class="ok">ok</span>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="t">
                                        <strong>Retype Password</strong>
                                    </td>
                                    <td>
                                        <input type="password" class="txt set-pwd2" id="txtPwdNew2" />
                                        <%--<span class="error">Password not match</span>
                                        <span class="ok">ok</span>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="t">
                                        <strong>Verify Code</strong>
                                    </td>
                                    <td>
                                        <div class="email-yzm fl yzm-style">
                                            <input type="text" id="ValiCode1"  class="txt yzm" />                         
                                            <div style="float: left;">
                                                <label id="code" style="float: left; text-align:center; width: 70px; font-size:18px; letter-spacing:2px; color:Blue; line-height:28px;  font-weight:bold; font-family:Arial; font-style:italic; background-image: url(../Images/yzm.png);">
                                                </label>
                                                <a href="javascript:void(0)"  style=" color:#007fd8; width:120px;" onclick="CreateCode()">Get another code</a>
                                            </div>
                                        </div>


                                        <span class="error">Retype password</span>
                                        <span class="ok">ok</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <a href="javascript:;" onclick="UpdatePwd()" class="setbtn">Confirm</a>
                                    </td>
                                </tr>

                            </table>
                        </div>
                    </form>
                </li>
                <li style="display: none">
                    <div class="clearfix">
                        <i class="ok"></i>
                        <b>Safe</b>
                        <span>Security Question</span>
                        <b>Already Setup</b>
                        <a href="#" class="setBtn">Setting</a>
                    </div>
                    <form action="">
                        <div class="setbox">
                            <table width="100%">
                                <tr>
                                    <td class="t">
                                        <strong>Select security question</strong>
                                    </td>
                                    <td>

                                        <div class="safe-q-box pr">
                                            <i class="selectBtn"></i>
                                            <input type="text" class="txt safe-q" />
                                            <dl>
                                                <dd>
                                                    <a href="#">Your father name is</a>
                                                </dd>
                                                <dd>
                                                    <a href="#">Your mother name is</a>
                                                </dd>
                                                <dd>
                                                    <a href="#">Your birthday is</a>
                                                </dd>
                                                <dd>
                                                    <a href="#">Your favorite pet name is</a>
                                                </dd>
                                            </dl>
                                        </div>

                                        <span class="error">Please enter correct security question</span>
                                        <span class="ok">ok</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="t">
                                        <strong>Enter</strong>
                                    </td>
                                    <td>
                                        <input type="text" class="txt" />
                                        <span class="error">Enter correct answer</span>
                                        <span class="ok">ok</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <a href="#" class="setbtn" onclick="modifyPwd()">Confirm</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </form>
                </li>
            </ul>
        </div>
    </div>
</body>

<script type="text/javascript">
    $(function () {
        //显示设置内容
        $(".setBtn").each(function (index, el) {
            $(this).click(function () {

                console.log('index=' + index);
                if (!$(this).hasClass('on')) {
                    $(this).text('Hide')
                    $(this).addClass('on').parents("li").find(".setbox").show();
                } else {
                    if (index == 1) {
                        $(this).text('Change emai')
                    } else {
                        $(this).text('Change Password')
                    }
                    $(this).removeClass('on').parents("li").find(".setbox").hide();
                }
                return false;
            })

        });
        //问题下拉
        $(".selectBtn").click(function () {
            if (!$(this).siblings('dl').hasClass('db')) {
                $(this).siblings('dl').addClass('db').show();
            } else {
                $(this).siblings('dl').removeClass('db').hide();
            }

        })
        $(".safe-q-box").mouseleave(function (event) {
            $(this).find('dl').removeClass('db').hide();
        });
        $(".safe-q-box").find("dl a").click(function (event) {
            $(".safe-q").val($(this).text())

            return false;
        });
    })
</script>
</html>
