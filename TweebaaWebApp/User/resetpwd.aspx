<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="resetpwd.aspx.cs" Inherits="TweebaaWebApp.User.resetpwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="../Css/selectCss.css" />
    <script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
    <script src="../Js/jquery.placeholder2.js" type="text/javascript"></script>
     <script src="../Js/createCode.js" type="text/javascript"></script>
    <script src="../MethodJs/sendEmail.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <form action="">
    <div class="resetpwd-main">
        <div class="w">
            <h1>
                Password Retrieval
            </h1>
              <ul class="addtxt">To reset your password, just enter your email address below and we'll send you an email with further instructions.</ul>
            <form action="">
            <div class="reg-main">
                <table width="100%">
                    <tbody>
                        <tr>
                            <td class="t tr">
                                <strong>Email</strong>
                            </td>
                            <td>
                                <input type="text" class="txt email" placeholder="Please enter email address" id="txtEmail" />
                                <span class="error">Account you entered does not exist</span> <span class="ok">ok</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="t tr">
                                <strong id="yzm-style">Please enter the Code</strong>
                            </td>
                            <td>
                                <div class="email-yzm fl yzm-style">
                                    <input type="text" class="txt yzm" id="ValiCode1" />
                                     <span class="error" id="yzmerror">Verification code is incorrect</span> <span class="ok" id="yzmok">ok</span>
                                    <%--<img src="../../Images/yzm.png" alt="" class="fl" />
								<a href="#" class="fl resetYzm">看不清</a>--%>
                                    <div style="float: left;">
                                        <label id="code" style="float: left; width: 70px;font-size:18px; background-image: url(../../Images/yzm.png);">
                                        </label>
                                        <a href="javascript:void(0)" class="fl resetYzm" onclick="CreateCode()">Get another code</a>
                                    </div>
                                </div>
                                <span class="error">Verification code is incorrect</span> <span class="ok">ok</span>
                                <div class="tel-yzm fl yzm-style" id="smsCode">
                                    <input type="text" class="txt telyzm" id="ValiCode2" />
                                    <a href="javascript:;" class="msnicon fl pr" onclick="GetSmsCode(1)"><b>免费获取短信验证码</b> </a>
                                    <a href="javascript:;" class="voiceicon fl pr" onclick="GetSmsCode(2)"><b>免费获取语音验证码</b> </a>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="t tr">
                            </td>
                            <td>
                                <div class="submit-box">
                                   <%-- <a class="submit-btn send" >下一步</a>--%>
                                    <input type="button" class="submit-btn send" value="Submit" /> 
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            </form>
        </div>
    </div>
    </form>

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
    <!-- 弹出注册成功窗口 -->
    <div class="greybox" style="display: none;">
        <div class="reg-ok-box">
            <div class="box pr">
                <a href="#" class="closeBtn" title="Close"></a>
                <h2>
                    Registration Successful</h2>
                <p>
                   An verifcation email had been sent， 
                    <br />
                   for security purpose please activate via your email！
                </p>
                <div>
                    <a href="#" class="returnLogin" onclick="$('#greybox2').css('display','none'); window.location.href = 'login.aspx';">Verified, back to login</a>
                </div>
            </div>
        </div>
    </div>

    <!-- 弹出注册失败窗口 -->
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
        $(function () {

            $('input').placeholder();


        });
    </script>
    <script type="text/javascript">
        $(function () {
            //表单提示
            $("input.txt").placeholder();

            //手机验证码提示
            $(".tel-yzm > a.pr").mouseenter(function (event) {
                $(this).find("b").show();
            }).mouseleave(function (event) {
                $(this).find("b").hide();
            });
        })
    </script>
    <script src="../Js/resetpwd.js" type="text/javascript"></script>
</asp:Content>
