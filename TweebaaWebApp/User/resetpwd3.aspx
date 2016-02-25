<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="resetpwd3.aspx.cs" Inherits="TweebaaWebApp.User.resetpwd3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
	<script src="../Js/jquery.placeholder2.js" type="text/javascript"></script>	
    <script src="../MethodJs/updatePwd.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
<form action="">
<div class="resetpwd-main">
	<div class="w">
		<h1>
			Password Retrieval
		</h1>
		
		
		<div class="step3con tc">
			<p>
				<img src="../../Images/ok28x23.png" alt="" />Your Member account has been verified.  Please reset your password below.
			</p>
		</div>
		

		<table width="100%">
			
			<tr>
				<td class="t tr"><strong>Password</strong></td>
				<td>
					<input type="password" class="txt userPwd" placeholder="6-20 characters">
					<span class="error">Must contain numbers and letters</span>
					<span class="ok">ok</span>
				</td>
			</tr>
			<tr>
				<td class="t tr"><strong>Re-enter Password</strong></td>
				<td>
					<input type="password" class="txt userPwd2" placeholder="Re-enter your password again">
					<span class="error" id="pwdError1">Passwords do not match</span>
                    <span class="error" id="pwdError2">Must contain numbers and letters</span>
					<span class="ok">ok</span>
				</td>
			</tr>
		
			<tr>
				<td class="t tr"></td>
				<td>
					<div class="submit-box">
						<input type="button" class="submit-btn send" value="Finished" onclick="ResetPwd">
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
			<a  href="javascript:void(0);" class="closeBtn" title="Close"></a>
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

<script type="text/javascript">
    $(function () {
        //手机验证码提示
        $('input, textarea').placeholder();
        $(".tel-yzm > a.pr").mouseenter(function (event) {
            $(this).find("b").show()
        }).mouseleave(function (event) {
            $(this).find("b").hide()
        });

    });
</script>
</asp:Content>
