<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="videoControl.aspx.cs" Inherits="TweebaaWebApp.upload.videoControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post" action="/Server/uploadVideo.ashx" enctype="multipart/form-data" >
    <div>
    <input  type="submit"  id="btnsub" />
       <input type="file" name="video" id="upload1" onchange="document.getElementById('btnsub').click()" /> 

    </div>
    </form>
</body>
</html>
