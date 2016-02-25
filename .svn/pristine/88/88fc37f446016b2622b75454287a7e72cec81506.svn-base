<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="emailShare.aspx.cs" Inherits="TweebaaWebApp.Product.emailShare" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Tweebaa Email Share</title>
    <link rel="stylesheet" href="../Css/index.css" />
    <script src="../Js/jquery.min.js" type="text/javascript"></script>
    <script src="http://www.web63.cn/jss/apic.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
    <link rel="stylesheet" href="../css/selectCss.css" />
    <script src="../Js/jquery.placeholder2.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/public.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            // do not submit form when user presses enter key in the input field
            $('input').keypress(function (event) { return event.keyCode != 13; });
        });
        /*
        function Add(obj) {
             var len = $(".email").length;
             if (len > 20)
             return false;
             var htmlStr = '<div></br><input type=text class=email style="width:250px;"/><a href="javascript:void(0)" onclick="Reduce(this);">&nbsp;Remove</a></div>';
             $(htmlStr).insertAfter($(obj));
         }
        function Reduce(obj) {
             $(obj).parent().remove();
        }
        */
        function checkEmail() {
            var re = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
            var badEmailAddr = "";
            var emailAddrInput = $("#emailAddr").val().trimRight();

            // email addresses are separated by spaces and semicolon
            var emailAddr = emailAddrInput.replace(/ +/g, ';');  // replace one or more spaces to a single senicolon
            var emailAddrArr = emailAddr.split(";");
            for (var i = 0; i < emailAddrArr.length; i++) {
                //alert(emailAddrArr[i]);
                if (!re.test(emailAddrArr[i])) {
                    if (badEmailAddr != "") badEmailAddr = badEmailAddr + "\n";
                    badEmailAddr = badEmailAddr + emailAddrArr[i];
                } 
            }
            
            if (badEmailAddr != "") {
                alert("Email address not correct:\n\n" + badEmailAddr + "\n\nPlease enter valid email address.");
                $('#emailAddr').focus();
            }
            else if (emailAddr == "") {
                alert("Please input email address.");
                $('#emailAddr').focus();
            } 
            else {
                $("#hidEmail").val(emailAddr);
                $("#<%=Button1.ClientID%>").click();
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="top">
        <div class="w clearfix">
            <div class="fr">
            </div>
            <a href="#" class="logo">
                <img src="../images/logo.png" alt="" /></a>
        </div>
    </div>
    <!-- 登陆left -->
    <div class="share-main">
        <div class="w">
            <form action="">
            <div class="share-main-box fl">
                <h1>
                    
                    Share with your friends by email</h1>

                <div class="fl right">
                    <h2>
                        <asp:Label ID="labPrdID" runat="server" Text=""   Visible="false"></asp:Label>
                        <asp:Label ID="labShareLink" runat="server" Text=""   Visible="false"></asp:Label> 
                        <asp:Label ID="labPrdName" runat="server" Text=""></asp:Label>
                    </h2>
                </div>
                <div class="fl right">
                    <%--<img src="../images/emai-share.jpg" alt="" />--%>
                    <asp:Image ID="Image1" runat="server" Width="222" Height="222" />
                </div>
                <div class="fl right">
                    <asp:Label ID="labPrdDesc" runat="server" Text=""></asp:Label>

                <div>
                <br />
                <br /><h3><label for="textfield">
                Please Enter your name ( as you want your friends to see it)</label><br />
                <input type="text" class="email" style="width: 600px;" id="txtSender" name="txtSender" runat="server" /></h3>
                </div>
                    <h3><br />
                        <label for="textfield">
                            Please enter a personal message here</label><br />
                        <textarea id="txtMessage" cols="8" style="width: 600px; height: 100px;" runat="server"></textarea>
                    </h3>
                    <h3><label for="textfield">
                        Please enter your friends' email addresses (if more than one, seperate by semicolon (;) or spaces. ) </label>
                    <%--<input type="text" name="Emails" id="textfield" class="input" />--%>
                    <input type="hidden" id="hidEmail" runat="server" />
                    <input type="text" class="email" style="width: 600px;" id="emailAddr"/>
                    </h3>
                    <!--span class="add" style="width:150px;"><a href="javascript:void(0)" style="text-decoration:none;" onclick="Add(this)" >&nbsp;&nbsp;Add&nbsp;&nbsp;</a></span-->
                    <div class="box">
                        <div class="submit-box">
                            <div style="display: none;">
                                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /></div>
                                <br />
                            <input type="button" class="submit-btn send" value="Send Email" onclick="checkEmail()" />
                            <%--<a onclick="checkEmail()" class="yulanbtn" href="javascript:void(0)" style=" cursor:pointer; text-decoration-line:none;">Send Email</a>--%>
                        </div>
                    </div>
                </div>
            </div>
            </form>
        </div>
        <script type="text/javascript">
            $(".login-main").apic()


        </script>
    </div>
    <!-- foot -->

     <div class="footer" style="display:none">
        <div class="w clearfix">
            <div class="box">
                <div class="clearfix">
                    <%--<span class="fr tr">24 hours Hotline：400-888-666<br /> or Email:sales@tweebaa.com </span>--%>
                    <span class="fl"><a href="../College/AboutUs.aspx">About Us</a>｜<a href="../College/ContactUs.aspx">Contact
                        Us</a>｜<a href="../College/College.aspx#nav-ag">Privacy Policy</a>｜<a href="../College/College.aspx#nav-ag">Terms
                            and Conditions</a>｜<a href="../College/College.aspx#nav-faqq">FAQ</a> </span>
                </div>
                <div class="clearfix p pr">
                    <p>
                        Copyright: 2012-2015 Tweebaa Inc.</p>
                    <p>
                    </p>
                    <p class="gz">
                        Follow Us <a href="https://www.facebook.com/tweebaa" target="_blank">
                            <img src="../Images/wb25x25.png" alt="https://www.facebook.com/tweebaa" />
                        </a>
                        <a href="https://twitter.com/tweebaa" target="_blank">
                            <img src="../Images/wx25x25.png" alt="https://twitter.com/tweebaa" /></a>
                        <a href="https://www.google.com/+Tweebaa" target="_blank">
                            <img src="../Images/flat-circles_16.png" width="25" height="25" alt="https://www.google.com/+Tweebaa" /></a>
                        <a href="https://www.linkedin.com/company/tweebaa-inc-" target="_blank">
                            <img src="../Images/txwb25x25.png" alt="https://www.linkedin.com/company/tweebaa-inc-" />
                        </a>
                        <a href="https://instagram.com/tweebaa/" target="_blank"> 
                            <img src="../Images/share-instagram32x32.png" alt="https://instagram.com/tweebaa/" width="32" height="32" /></a>
                        <a href="https://pinterest.com/" target="_blank">
                            <img src="../Images/flat-circles_18.png" alt="https://pinterest.com/" width="25" height="25"/>
                        </a>
                    </p>
                    <div class="erweima" style="display: none;">
                        <img src="../Images/erweima.png" alt="" />
                    </div>
                </div>
          
            </div>
        </div>
 
        <div style=" width:100%; height:100%; text-align:center;  padding-top:60px; " style="display:none">
             <!-- Begin W3Counter Tracking Code -->
            <script type="text/javascript" src="https://www.w3counter.com/tracker.js"></script>
            <script type="text/javascript">
                w3counter(90812);
            </script>
            <noscript>
                <div>
                    <a href="http://www.w3counter.com">
                        <img src="https://www.w3counter.com/tracker.php?id=90812" style="border: 0" alt="W3Counter" /></a></div>
            </noscript>
            <!-- End W3Counter Tracking Code -->
        </div>
    </div>
    </form>
</body>
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
</html>
