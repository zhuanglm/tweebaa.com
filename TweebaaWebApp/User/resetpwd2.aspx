<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="resetpwd2.aspx.cs" Inherits="TweebaaWebApp.User.resetpwd2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <script src="../Js/jquery.min.js" type="text/javascript"></script>  
    <script src="../MethodJs/sendEmail.js" type="text/javascript"></script>    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <div class="resetpwd-main">
        <div class="w">
            <h1>
                Password Retrieval
            </h1>
          
            <div class="step2con">
                <p>
                   Please check your email: <a href="" id="hrefEmail" class="l"><asp:Label ID="labEmail" runat="server"></asp:Label></a> and follow instructions to reset your password.
                    <%--<a href="#" class="l">Reset Password</a>--%><br />
                </p>
            
                <div class="submit-box">
                   <a href="javascript:void(0);" class="fl"  onclick="SendEmail2()">If you did not receive email, just click here to resend. </a> <a class="submit-btn send" href="javascript:void(0);" onclick="SendEmail2()">Email Verification</a> 
                </div>
            </div>
        </div>
    </div>
</asp:Content>
