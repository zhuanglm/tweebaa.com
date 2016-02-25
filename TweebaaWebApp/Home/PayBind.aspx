<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayBind.aspx.cs" Inherits="TweebaaWebApp.Home.PayBind" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../css/index.css" />
	<link rel="stylesheet" href="../css/home.css" />
    <link rel="stylesheet" href="../Css/c.css" />
	<script src="../js/jquery.min.js" type="text/javascript"></script>
	<script src="../js/jquery.placeholder.js" type="text/javascript"></script>

	<script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
	<script src="../js/selectNav.js" type="text/javascript"></script>
	<script src="../js/homePage.js" type="text/javascript"></script>
	<link rel="stylesheet" href="../css/selectCss.css" />
	<script src="../js/selectCss.js" type="text/javascript"></script>
	<script type="text/javascript" src="../js/public.js"></script>
	<script type="text/javascript" src="../js/home-safe.js"></script>
       <script src="../js/bind.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="binding-main"><!--safe-main-->

               <!--表单-->
                <div class="form">
				<h2 class="t">我的绑定账户</h2>
                
                <h3>安全提示：</h3>
              	<p class="tip">
你正在访问推易吧金融安全网页，为了更好的为你提供服务，请你填写真实身份信息。请放心操作，我们会严格保密你的隐私信息。</p>

                <form action="">
                	<table cellspacing="0" cellpadding="0" border="0" widht="100%">
                    
                    <tbody><tr>
			<td class="t">
				绑定支付宝
			</td>
			<td>
			   <img  src="../Images/b_03.png">
			</td>
		</tr>
        
		<tr>
			<td class="t">
				姓名<span class="h">*</span>
			</td>
			<td>
			<input type="text" id="txtname"  runat="server" placeholder="请正确填写身份证上的姓名" class="txt textZip">
				<span class="error">请输入姓名</span>
				<span class="ok">ok</span>
			</td>
		</tr>
		<tr>
			<td class="t">
				身份证号码<span class="h">*</span>
			</td>
			<td>
				<input type="text" id="txtcode" runat="server" placeholder="4201***********1045" class="txt sf">
				<span class="error">请输入正确的身份证号码</span>
				<span class="ok">ok</span>
			</td>
		</tr>
		<tr>
			<td class="t">
				支付宝帐号<span class="h">*</span>
			</td>
			<td>
               <input type="text" id="txtpayaccount" runat="server" placeholder="请正确填写支付宝账号" class="txt areaall">
				<span class="error">请输入支付宝帐号</span>
				<span class="ok">ok</span>
			</td>
		</tr>
		<tr>
			<td class="t">
				绑定手机号<span class="h">*</span>
			</td>
			<td>
				<input type="text" id="txtphone" runat="server" placeholder="请正确填写支付宝绑定手机号码" class="txt name" />
				<span class="error">收货人姓名应为2-25个字符，一个汉字为两个字符</span>
				<span class="ok">ok</span>
                
			</td>
		</tr>
		<tr>
			<td class="t">
				手机验证码<span class="h">*</span>
			</td>
			<td>
				<input type="text" id="txtphonecode" runat="server" class="txtphoneNum" />
				<span class="error">手机13412345678</span>
				<span class="ok">ok</span>
                <input type="button" class="send" value="获取验证码" onclick="Send()" />
			</td>
		</tr>
        
        <tr>
			<td class="t">
			</td>
			<td>
                 <input type="hidden" runat="server" id="hidagree" value="" />
				<input type="checkbox" id="chkagree"  class="checkbox">&nbsp;&nbsp;我已阅读并同意<a class="blue" href="javascript:void(0)" onclick="openDiag()">《推易吧收益协议》</a>
			<script type="text/javascript">
			    $(function () {
			        $("#chkagree").click(function () {
			            if ($(this).attr("checked") == "checked") {
			                $("#hidagree").val("1");
			            }
			        });
			    })
            </script>
            </td>
		</tr>
        
		
		<tr>
			<td class="t">
				
			</td>
			<td>
				<%--<input type="button" class="send bind" value="绑&nbsp;定" id="bind">--%>
                
        <asp:Button ID="btnBind" runat="server" Text="绑  定" CssClass="send bind" 
                    OnClientClick="javascript:return verfy()" onclick="btnBind_Click" />
            </td>
		</tr>

	</tbody></table>
                
                </form>
                </div>
			</div>
    </form>

    <script type="text/javascript">
        function isCardNo(card) {
            // 身份证号码为15位或者18位，15位时全为数字，18位前17位为数字，最后一位是校验位，可能为数字或字符X  
            var reg = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;
            if (reg.test(card) === false) {
                alert("身份证输入不合法");
                return false;
            }
        }

        function openDiag() {
            parent.document.getElementById("test").click();
        }

        function verfy() {
            var name = $("#txtname").val();
            if (null == name || name == "") {
                alert('请填写您的姓名');return false;
            }
            var txtcode = $("#txtcode").val();
            if (null == txtcode || txtcode == "" || isCardNo(txtcode)==false) {
                alert('请填写您的正确的身份证号码'); return false;
            }
            var txtpayaccount = $("#txtpayaccount").val();
            if (null == txtpayaccount || txtpayaccount == "") {
                alert('请填写您的支付宝账号'); return false;
            }
            var txtphone = $("#txtphone").val();
            if (null == txtphone || txtphone == "") {
                alert('请填写您的手机号'); return false;
            }
            var txtphonecode = $("#txtphonecode").val();
            if (null == txtphonecode || txtphonecode == "") {
                alert('请填写您的手机验证码'); return false;
            }
            var chk = $("#chkagree").attr("checked");
            if (chk == null || chk != "checked") {
                alert('您必须接受推易吧收益协议'); return false;
            }

        }
        function Send() {
            var txtphone = $("#txtphone").val();
            if (null == txtphone || txtphone == "") {
                alert('请填写您的手机号');
            }
            else {
                var _data = 'action=bind&phone=' + txtphone;
                $.ajax({
                    type: "POST",
                    url: '../AjaxPages/payBindAjax.aspx',
                    data: _data,
                    success: function (msg) {
                        if (msg == "-1") {
                            alert("短信发送失败，请检查输入是号码是否正确");
                        }
                    },
                    error: function (msg) {
                        alert("短信发送失败，请检查输入是号码是否正确");
                    }
                });
            }
        }
        

    </script>

</body>
</html>
