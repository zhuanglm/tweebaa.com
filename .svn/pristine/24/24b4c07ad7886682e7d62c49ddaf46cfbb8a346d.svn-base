<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayPalAccountBind.aspx.cs" Inherits="TweebaaWebApp.Home.PayPalAccountBind" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../css/index.css" />
	<link rel="stylesheet" href="../css/home.css" />
    <link rel="stylesheet" href="../Css/c.css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <style type="text/css">
        a:hover {
         text-decoration:none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="home-main binding  fl">
    <h2 class="t">My payment method</h2>
    <div class="binding-main">
     <h3>NOTE：</h3>
              	<p class="tip">  You do not need to link your PayPal account to pay for Tweebaa purchases.  You would only need to link it to redeem commission earnings (“TweeBucks”) for cash.  Your PayPal info will be treated confidentially.</p>
        <table cellspacing="0" cellpadding="0" border="0" widht="100%">
            <tr>
                <td class="t">
                    Account Link
                </td>
                <td colspan="2">
                    <img src="../Images/paypal.jpg" />
          
                </td>
            </tr>
            <tr>
                <td class="t" style="width:130px;">Your first name <span style="color:red;">*</span></td>
                <td>
                    <input type="hidden" runat="server" id="hidUserid" />
                    <input type="hidden" runat="server" id="hidOption" />
                    <input type="hidden" runat="server" id="hidAccountId" />
                    <input type="text" runat="server" id="txtFirstName" class="txt textZip" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="t">Your last name <span style="color:red;">*</span></td>
                <td>
                    <input type="text" runat="server" id="txtLastName" class="txt textZip" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="t">Paypal email address <span style="color:red;">*</span></td>
                <td>
                    <input type="text" runat="server" id="txtPayPalAccount" class="txt textZip" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="t">Email <span style="color:red;">*</span></td>
                <td>
                    <input type="text" runat="server" id="txtEmail" class="txt textZip" />
                </td>
                <td style="color:red;">Click on "Get code" to send verification code to this email</td>
            </tr>
            <tr>
                <td class="t">Verification code <span style="color:red;">*</span></td>
                <td>
                    <input type="text" runat="server" id="txtCode" class="txt textZip" />
                </td>
                <td>
                    <input type="button" onclick="Send()" value="Get code" class="send" style="cursor:pointer;">
                    <span style="color:red; display:none;" id="emailSendSuc">Email has been sent</span>
                    <span style="color:red; display:none;" id="emailSendFal">Email sent fail</span>
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="2">
                    <input type="checkbox" id="chk" />
                  I have read and agree to <a href="/College/TweeBuck.aspx" target="_blank">TweeBuck Activities Terms & Conditions</a>
                  <!--  <a href="#" target="_top" class="blue">
                        《TweeBaa Gains agreement》
                    </a> -->
                </td>
            </tr>
            <tr>
			<td class="t">
			</td>
			<td>
                 <input type="button" class="send bind" style="cursor:pointer;" id="btnBind" onclick="javascript: Save();" value="Link Account" />
            </td>
                <td>
                    <input type="button" class="send bind" style="cursor:pointer;" id="btnUnBind" onclick="javascript: Unbind();" value="Unbind Account" />
                </td>
		</tr>
        </table>
        <script type="text/javascript">

            $(function () {
                UnbindShow();
            })

            function UnbindShow() {
                var id = $.trim($("#hidAccountId").val());
                if (id == '') {
                    $("#btnUnBind").hide();
                } else {
                    $("#btnUnBind").show();
                }
            }

            function Unbind() {
                if (window.confirm("Are you sure unbind your current account ?")) {
                    var id = $.trim($("#hidAccountId").val());
                    var res = TweebaaWebApp.Home.PayPalAccountBind.Unbind(id).value;
                    if (res == "success") { alert('Unbind account success .'); }
                    else { alert('Unbind account fail .'); }
                }
            }

            function Save() {
                if (verfy()) {
                    var firstName = $.trim($("#txtFirstName").val());
                    var lastName = $.trim($("#txtLastName").val());
                    var account = $.trim($("#txtPayPalAccount").val());
                    var email = $.trim($("#txtEmail").val());
                    var code = $.trim($("#txtCode").val());
                    var op = $.trim($("#hidOption").val());
                    var userid = $.trim($("#hidUserid").val());
                    var res = TweebaaWebApp.Home.PayPalAccountBind.Save(op, userid, firstName, lastName, account, email, code).value;
                    if (res == "addsuccess") { alert('bind account success !'); $("#txtCode").val(''); return false; }
                    if (res == "fail" || res == "nooption") { alert('bind account fail !'); return false; }
                    if (res == "nouser") { alert('please relogin !'); return false; }
                    if (res == "nodata") { alert('please input verfinication code !'); return false; }
                    if (res == "codeerror") { alert('verfinication code is wrong !'); return false; }
                    if (res == "updatesuccess") { alert('update bind account success !'); $("#txtCode").val(''); return false; }
                }
            }

            function Send() {
                var userid = $("#hidUserid").val();
                var email = $.trim($("#txtEmail").val());
                if (email == '') { alert('please input your email'); return false; }
                //对电子邮件的验证
                var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
                if (!myreg.test(email)) { alert('please input correct email'); return false; }
                var res = TweebaaWebApp.Home.PayPalAccountBind.GetCode(email,userid).value;
                if (res == 'emailsuccess') {
                    $("#emailSendSuc").css("display", "block");
                } else {
                    $("#emailSendFal").css("display", "block");
                }
            }

            function filter(str) {
                str = str.replace(/<\/?[^>]*>/g, '');
                return str;
            }

            function verfy() {
                var firstName = $.trim($("#txtFirstName").val());
                var lastName = $.trim($("#txtLastName").val());
                var account = $.trim($("#txtPayPalAccount").val());
                var email = $.trim($("#txtEmail").val());
                var code = $.trim($("#txtCode").val());
                var chked = $("#chk").attr("checked");
                if (chked != 'checked') { alert('please aggree to the agreement'); return false; }
                if (firstName == '') { alert('please input first name'); return false; }
                if (lastName == '') { alert('please input last name'); return false; }
                if (account == '') { alert('please input paypal account'); return false; }
                if (email == '') { alert('please input your email'); return false; }
                //对电子邮件的验证
                var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
                if (!myreg.test(email)) { alert('please input correct email'); return false; }
                if (code == '') { alert('please input verification code'); return false; }
                return true;
            }
        </script>
    </div></div>
    </form>
</body>
</html>
