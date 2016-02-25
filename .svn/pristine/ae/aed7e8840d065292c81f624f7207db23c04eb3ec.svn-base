<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="loginGuest.aspx.cs" Inherits="TweebaaWebApp.User.loginGuest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <%--<link rel="stylesheet" href="../Css/index.css" />--%>
    <script src="../Js/jquery.min.js" type="text/javascript"></script>
    <script src="http://www.web63.cn/jss/apic.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
    <link rel="stylesheet" href="../Css/selectCss.css" />
    <script src="../js/jquery.placeholder2.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/public.js"></script>
    <script src="../Js/login.js" type="text/javascript"></script>
    <script src="../MethodJs/logion.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <!-- 登陆left -->
    <div class="guest-main">
        <div class="w">
            <form action="">
            <input type="hidden" id="redirectTip" value="<%=op %>" />
            <input type="hidden" id="redirectArg" value="<%=args %>" />
            <div class="guest-main-box fl">
                <h1>Select Checkout Method</h1>
                <h2 style="margin-top:-28px;">Tweebaa Members</h2>
                <%--h3>--%>
                <div style=" padding-left:30px; font-size:13.5px;">
                 <strong>Log in and take advantage of these benefits:</strong><br />
                    · Earn Shopping Rewards (redeem for discounts)<br />
                    · Share this purchase and if your friends buy, you’ll earn commission rewards<br />
                    · Access additional members-only rewards<br />
                    · View previous orders & track existing orders
                </div>
                   
                 <%--</h3>--%>
                <div class="box">
                    <div class="tipsbox">
                        <div class="tips-error">
                            Please enter a valid email address
                        </div>
                    </div>
                    <div class="item user">
                        <input type="text" id="txtEmail" placeholder="Email" class="email" />
                        <span>Email</span>
                    </div>
                    <div class="item pwd">
                        <input type="password" id="txtPwd" placeholder="Password" class="userPwd" />
                        <span>Password</span>
                    </div>
                    <div class="re-pwd tl">
                        <a href="resetpwd.aspx" class="fr">Forgot Password</a>
                        <div class="chklist fl">
                            <input type="checkbox" value='1' />
                            <label>
                                Remember Me</label>
                        </div>
                    </div>
                    <div class="submit-box">
                        <input type="button" class="submit-btn send" value="Login" onclick="LogionFuc()" />
                        <span class="fr">Not Registered?<a href="register.aspx">Join Now</a> </span>
                    </div>
                </div>
            </div>
            </form>
        </div>
        <!-- 登陆right -->
        <div class="guest-right fl clearfix">
            <h1>New Customers</h1>
            <div style="font-size:13.5px;">
              Create a Tweebaa account and you can start EARNING!<br />
                · Earn Shopping Rewards (redeem for discounts)<br />
                · Participate in <a href="#" style="color: #2176BC">Submitting</a>, <a href="#" style="color: #18cbac">
                    Evaluating</a> and <a href="#" style="color: #ff825c">Sharing</a> &nbsp;&nbsp;products
                (earn TweeBucks and redeem for CASH!)
            </div>
              <br />
            <div class="submit-box">
                <input type="button" class="submit-btn send" value="Create an Account" onclick="reg()" />
                <input type="button" class="submit-btn send" value="Checkout as Guest" onclick="CheckOut()" />
            </div>
        </div>
        <script type="text/javascript">
            $(".login-main").apic();
            function Reg() {
                window.location.href = "../User/register.aspx";
            }
            function CheckOut() {
                window.location.href = "../Product/shopOrder.aspx?type=guest";
            }
    </script>
    </div>
    <script type="text/javascript">
        $(function () {
            //表单提示
            $("input").placeholder();
            //表单美化
            $('.chklist').hcheckbox();
            //关闭登录框
            $(".closeBtn").click(function () {
                $(this).parents(".greybox").hide()
            })
            //弹出登录框
            $("#minilogin").click(function (event) {
                $(".greybox").show();
                return false;
            });

        });
</script>
</asp:Content>
