<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="AccountSettings.aspx.cs" Inherits="TweebaaWebApp2.Home.AccountSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

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
    <script src="../js/reg.js" type="text/javascript"></script>
    <script type="text/javascript" src="../MethodJs/homeSafe.js"></script>

     <link rel="stylesheet" href="/plugins/sky-forms/version-2.0.1/css/custom-sky-forms.css">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

<div class="col-md-9">
         <h2><span aria-hidden="true" class="glyphicon glyphicon-user"></span> Account Setting</h2> 
  <div class="profile-body"> 
     <div class="tab-v1">
                            <ul class="nav nav-justified nav-tabs">

                                <li class="active"><a data-toggle="tab" href="#passwordTab">Security Setting</a></li>
                                <li><a data-toggle="tab" href="#payment">Payment Options</a></li>
                            <!--    <li><a data-toggle="tab" href="#settings">Notification Settings</a></li> -->
                            </ul>          
                            <div class="tab-content">
                              

                                <div id="passwordTab" class="profile-edit tab-pane fade in active">
                                
                                    <h2 class="heading-md">Manage your Security Settings</h2>
                                    <p class="t">Your personal information is kept confidential by Tweebaa</p>
                                    </br>
                                    <form class="sky-form" id="sky-form4" action="#">
                                        <dl class="dl-horizontal">
                                            <!--
                                            <dt>Username</dt>
                                            <dd>
                                                <section>
                                                    <label class="input">
                                                        <i class="icon-append fa fa-user"></i>
                                                        <input type="text" placeholder="Username" name="username">
                                                        <b class="tooltip tooltip-bottom-right">Needed to enter the website</b>
                                                    </label>
                                                </section>
                                            </dd>
                                            -->
                                            <dt>Email address</dt>
                                            <dd>
                                                <section>
                                                    <label class="input">
                                                        <i class="icon-append fa fa-envelope"></i>
                                                        <input type="email" placeholder="Please enter your new Email address if you want to change" name="email" id="txtEMail_new">
                                                        <b class="tooltip tooltip-bottom-right">Needed to verify your account</b>
                                                    </label>
                                                </section>
                                            </dd>
                                            <dt>Current password</dt>
                                            <dd>
                                                <section>
                                                    <label class="input">
                                                        <i class="icon-append fa fa-lock"></i>
                                                        <input type="password" id="txtOldPass" name="txtOldPass" placeholder="Please enter your current password">
                                                        <b class="tooltip tooltip-bottom-right">Don't forget your password</b>
                                                    </label>
                                                </section>
                                            </dd>

                                            <dt>New password</dt>
                                            <dd>
                                                <section>
                                                    <label class="input">
                                                        <i class="icon-append fa fa-lock"></i>
                                                        <input type="password" id="txtNewPass" name="txtNewPass" placeholder="Please enter your new assword">
                                                        <b class="tooltip tooltip-bottom-right">Don't forget your password</b>
                                                    </label>
                                                </section>
                                            </dd>
                                            <dt>Confirm Password</dt>
                                            <dd>
                                                <section>
                                                    <label class="input">
                                                        <i class="icon-append fa fa-lock"></i>
                                                        <input type="password" id="passwordConfirm" name="passwordConfirm" placeholder="Please enter your new password again">
                                                        <b class="tooltip tooltip-bottom-right">Don't forget your password</b>
                                                    </label>
                                                </section>
                                            </dd>    
                                        </dl>
                                     
                                        </br>
                                        <!--
                                        <section>
                                            <label class="checkbox"><input type="checkbox" id="terms" name="terms"><i></i><a href="#">I agree with the Terms and Conditions</a></label>
                                        </section>
                                        
                                        <button type="button" class="btn-u btn-u-default">Cancel</button>
                                        -->
                                        <button class="btn-u" type="submit" onclick="SaveAccountInfo();return false;">Save Changes</button>
                                    </form>    
                                    

                                </div>

                                <div id="payment" class="profile-edit tab-pane fade">
                                
                                <h2 class="heading-md">My payment method</h2>
                                <p class="tip">  You do not need to link your PayPal account to pay for Tweebaa purchases.  You would only need to link it to redeem commission earnings (“TweeBucks”) for cash.  Your PayPal info will be treated confidentially.</p>
                                  <form id="form1" class="sky-form" runat="server">
<input type="hidden" runat="server" id="hidUserid" />
<input type="hidden" runat="server" id="hidOption" />
<input type="hidden" runat="server" id="hidAccountId" />


        <dl class="dl-horizontal">
            <dt> Account Link</dt>
            <dd><section><img src="/images/paypal.jpg" /></section></dd>
                    
            <dt>Your first name <span style="color:red;">*</span></dt>
            <dd><section><input type="text" runat="server" id="txtFirstName" class="txt textZip" /></section></dd>

            <dt>Your last name <span style="color:red;">*</span></dt>
            <dd><section><input type="text" runat="server" id="txtLastName" class="txt textZip" /></section></dd>

            <dt>Paypal email address <span style="color:red;">*</span></dt>
            <dd><section><input type="text" runat="server" id="txtPayPalAccount" class="txt textZip" /></section></dd>

            <dt>Email <span style="color:red;">*</span></dt>
            <dd><section><input type="text" runat="server" id="txtEmail" class="txt textZip" />
                Click on "Get code" to send verification code to this email
            </section></dd>

            <dt>Verification code <span style="color:red;">*</span></dt>
            <dd><section><input type="text" runat="server" id="txtCode" class="txt textZip" />
                                <input type="button" onclick="Send()" value="Get code" class="send" style="cursor:pointer;">
                    <span style="color:red; display:none;" id="emailSendSuc">Email has been sent</span>
                    <span style="color:red; display:none;" id="emailSendFal">Email sent fail</span>
            </section></dd>
        </dl>

        <section>
            <label class="checkbox"><input type="checkbox" id="chk" /><i></i>
                  I have read and agree to <a href="/College/TweeBuck.aspx" target="_blank">TweeBuck Activities Terms & Conditions</a>
            </label>
        </section>
        </br>
        <button class="btn-u" type="submit" id="btnBind" onclick="javascript: Save();return false;">Link Account</button>
        <button class="btn-u" type="submit" id="btnUnBind" onclick="javascript: Unbind();return false;">Unbind Account</button>
	  	  <div class="margin-bottom-20 margin-top-20">
<img  src="../images/godaddy-secure-ssl.gif"  alt="godaddy-secure-ssl" width="20%"/></div>
    <div class="home-main binding  fl">
    <div class="binding-main">

        <script type="text/javascript">

            $(function () {
                UnbindShow();
            })

            function SaveAccountInfo() {
                //check whether need to update e-mail
                var email = $("#txtEMail_new").val();
                if (email != null && email.length > 0) {
                    modifyEmail();
                }
                UpdatePwd();
            }
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
                    var res = TweebaaWebApp2.Home.AccountSettings.Unbind(id).value;
                    if (res == "success") { AlertEx('Unbind account success .'); }
                    else { AlertEx('Unbind account fail .'); }
                }
            }

            function Save() {
                if (verfy()) {
                    var firstName = $.trim($("[id$='txtFirstName']").val());
                    var lastName = $.trim($("[id$='txtLastName']").val());
                    var account = $.trim($("[id$='txtPayPalAccount']").val());
                    var email = $.trim($("[id$='txtEmail']").val());
                    var code = $.trim($("[id$='txtCode']").val());
                    var op = $.trim($("[id$='hidOption']").val());
                    var userid = $.trim($("[id$='hidUserid']").val());
                    var res = TweebaaWebApp2.Home.AccountSettings.Save(op, userid, firstName, lastName, account, email, code).value;
                    if (res == "addsuccess") { AlertEx('bind account success !'); $("#txtCode").val(''); return false; }
                    if (res == "fail" || res == "nooption") { AlertEx('bind account fail !'); return false; }
                    if (res == "nouser") { AlertEx('please relogin !'); return false; }
                    if (res == "nodata") { AlertEx('please input verfinication code !'); return false; }
                    if (res == "codeerror") { AlertEx('verfinication code is wrong !'); return false; }
                    if (res == "updatesuccess") { AlertEx('update bind account success !'); $("#txtCode").val(''); return false; }
                }
            }

            function Send() {
                var userid = $("[id$='hidUserid']").val();
                var email = $.trim($("[id$=txtEmail]").val());
                console.log("email for paypal=" + email);
                if (email == '') { AlertEx('please input your email'); return false; }
                //对电子邮件的验证
                var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
                if (!myreg.test(email)) { AlertEx('please input correct email'); return false; }
                var res = TweebaaWebApp2.Home.AccountSettings.GetCode(email, userid).value;
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
                var firstName = $.trim($("[id$='txtFirstName']").val());
                var lastName = $.trim($("[id$='txtLastName']").val());
                var account = $.trim($("[id$='txtPayPalAccount']").val());
                var email = $.trim($("[id$='txtEmail']").val());
                var code = $.trim($("[id$='txtCode']").val());
                var chked = $("#chk").attr("checked");
                if (chked != 'checked') { AlertEx('please aggree to the agreement'); return false; }
                if (firstName == '') { AlertEx('please input first name'); return false; }
                if (lastName == '') { AlertEx('please input last name'); return false; }
                if (account == '') { AlertEx('please input paypal account'); return false; }
                if (email == '') { AlertEx('please input your email'); return false; }
                //对电子邮件的验证
                var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
                if (!myreg.test(email)) { AlertEx('please input correct email'); return false; }
                if (code == '') { AlertEx('please input verification code'); return false; }
                return true;
            }
        </script>
    </div></div>
    </form>
                                </div>

                                <div id="settings" class="profile-edit tab-pane fade">
                                    <h2 class="heading-md">Manage your Notifications.</h2>
                                    <p>Below are the notifications you may manage.</p>
                                    </br>
                                    <form class="sky-form" id="sky-form" action="#">
                                        <label class="toggle"><input type="checkbox" checked="" name="checkbox-toggle-1"><i></i>Email notification</label>
                                      
                                        <hr>
                                        <label class="toggle"><input type="checkbox" checked="" name="checkbox-toggle-1"><i></i>Send me email notification for the latest update</label>
                                        <hr>
                                        <label class="toggle"><input type="checkbox" checked="" name="checkbox-toggle-1"><i></i>Send me email notification when a user sends me message</label>
                                        <hr>
                                        <label class="toggle"><input type="checkbox" checked="" name="checkbox-toggle-1"><i></i>Receive our monthly newsletter</label>
                                        <hr>    
                                        <button type="button" class="btn-u btn-u-default">Reset</button>
                                        <button class="btn-u" type="submit">Save Changes</button>
                                    </form>    
                                </div>
                            </div>
               
                  </div>
                          
       </div>
                                 
                        </div>
 

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

    <script type="text/javascript">
        $(function () {
            $("#upload").change(function () {
                $("#upload-state").show();
                $("#personal-upload-form").submit();
            });
        });
    </script>
</asp:Content>


