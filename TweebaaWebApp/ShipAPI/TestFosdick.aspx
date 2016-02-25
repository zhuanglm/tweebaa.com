<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestFosdick.aspx.cs" Inherits="TweebaaWebApp.ShipAPI.TestFosdick" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <% =HttpUtility.HtmlEncode(_sOrderXML) %><br />
    <% =HttpUtility.HtmlEncode(_sResponseXML) %><br />

    </div>
    </form>
</body>
</html>
