<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="play12.aspx.cs" Inherits="TweebaaWebApp.upload.play12" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <%-- <%=SelPlay(@"PlayVideo/3Dgames.mp4", 500, 400)%>--%>
    <%=SelPlay(@"D:\TweebaaWebFile\TweebaaWebFile\PlayVideo\3Dgames.avi", 500, 400)%>
    </div>
    </form>
</body>
</html>
