<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TweebaaWebApp2.Mgr.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Mgr/css/login.css" rel="stylesheet" type="text/css" />
    <script src="/Mgr/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Mgr/js/cloud.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
            $(window).resize(function () { $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 }); })
        })
    </script>
</head>
<body style="background-color: #1c77ac; background-image: url(/Mgr/images/light.png); background-repeat: no-repeat; background-position: center top; overflow: hidden;">



    <div id="mainBody">
        <div id="cloud1" class="cloud"></div>
        <div id="cloud2" class="cloud"></div>
    </div>


    <div class="logintop">
        <span>Welcome to backend management system GUI</span>
        <ul>
            <li><a href="#">Home</a></li>
            <li><a href="#">Help</a></li>
            <li><a href="#">About</a></li>
        </ul>
    </div>

    <div class="loginbody">

        <span class="systemlogo"></span>
        <form runat="server" id="from1">
            <div class="loginbox">
                <ul>
                    <li>
                        <input name="txtName" id="txtName" runat="server" type="text" maxlength="20" class="loginuser" value="" /></li>
                    <li>
                        <input name="txtPwd" id="txtPwd" runat="server" type="password" maxlength="20" class="loginpwd" value="" /></li>
                    <li>
                        <asp:Button ID="BtnLogin" runat="server" Text="Login" CssClass="loginbtn"
                            OnClientClick="javascript:return login()" OnClick="BtnLogin_Click" />
                        <label>
                            <asp:CheckBox ID="chk" runat="server" />
                            Remember me</label>
                    </li>
                </ul>


            </div>
                </form>
    </div>

 
    
    
    <div class="loginbm">Welcome to backend management system</div>
    <script type="text/javascript">
        function login() {
            var name = $("#txtName").val();
            var pwd = $("#txtPwd").val();
            if (name == null) {
                alert('Username cannot be blank'); return false;
            }
            if (pwd == null) {
                alert('Password cannot be blank'); return false;
            }
        }
    </script>
</body>
</html>
