<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestEShipper.aspx.cs" Inherits="TweebaaWebApp2.ShipAPI.TestEShipper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <% = HttpUtility.HtmlEncode(_sXML)%>
    <br />
    <% = HttpUtility.HtmlEncode(_sResponse)%>
    <br />
    <% = _sResponse %>
    < br/> 
    <% = _sShipMethod%> 
    </div>
    </form>
</body>
</html>
