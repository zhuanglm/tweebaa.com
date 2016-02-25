<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadVideo.aspx.cs" Inherits="TweebaaWebApp.upload.UploadVideo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>上传媒体</title>
<style type="text/css">

.MailList
{
 width:800px; height:auto; overflow:hidden;
}
.ItemCss
{
 width:242px; height:230px; float:left; overflow:hidden;margin:20px 10px 0px 10px;
}
.ItemImgCss
{
    width:240px; height:180px; overflow:hidden;border:solid 1px #D4D0C8;
}
.ItemTCss
{
 width:240px; height:16px; font-weight:bold; overflow:hidden; margin-top:5px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        标题：<asp:TextBox ID="txtTitle" runat="server" Width="358px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle"
            ErrorMessage="标题不为空"></asp:RequiredFieldValidator>
       <br />
        <asp:FileUpload ID="FileUpload1" runat="server" Width="339px" />
        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="上传视频" Width="70px" />
        文件类型<span style="color:Red;">(.asf|.flv|.avi|.mpg|.3gp|.mov|.wmv|.rm|.rmvb)</span>
            <asp:RegularExpressionValidator ID="imagePathValidator" runat="server" ErrorMessage="文件类型不正确"
            ValidationGroup="vgValidation" Display="Dynamic" ValidationExpression="^[a-zA-Z]:(\\.+)(.asf|.flv|.avi|.mpg|.3gp|.mov|.wmv|.rm|.rmvb)$"
            ControlToValidate="FileUpload1">
            </asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1"
            ErrorMessage="文件不为空"></asp:RequiredFieldValidator></div>
        <div style=" height:0px; border-top:solid 1px red; font-size:0px;"></div>
        <div>上传列表....</div>
         <div>
            
                </div>
            
          
        </div>
    </form>
</body>
</html>
