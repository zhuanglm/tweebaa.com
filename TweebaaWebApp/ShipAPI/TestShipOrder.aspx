<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestShipOrder.aspx.cs" Inherits="TweebaaWebApp.ShipAPI.TestShipOrder" %>
<%@ Import Namespace="TweebaaWebApp.ShipAPI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p>
    Tweebaa PO # <asp:TextBox ID="txtTweebaaOrderID" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnShipOrder" runat="server" Text="Go" onclick="btnShipOrder_Click"></asp:Button>
    </p>
    <div>
        <asp:TextBox ID="txtResult" runat="server" textMode ="MultiLine" width="500" Height="500"></asp:TextBox>
    </div>
    </form>
</body>
</html>
