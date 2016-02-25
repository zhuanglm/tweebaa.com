<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestShipOrder.aspx.cs" Inherits="TweebaaWebApp2.ShipAPI.TestShipOrder" %>
<%@ Import Namespace="TweebaaWebApp2.ShipAPI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p>
    Tweebaa PO # <asp:TextBox ID="txtTweebaaOrderID" runat="server"></asp:TextBox>
    Password <asp:TextBox ID="txtPassword"  TextMode="Password" runat="server"></asp:TextBox>
    <br /><asp:Button ID="btnShipOrder" runat="server" Text="Go" onclick="btnShipOrder_Click"></asp:Button>
    <br /><asp:Button ID="btnShipmentDetailUpdate" runat="server" Text="Warehouse Shipment Details Update" onclick="btnWarehouseShipmentDetailUpdate_Click"></asp:Button>
    <br /><asp:Button ID="btnReturnInfoUpdate" runat="server" Text="Warehouse Return Info Update" onclick="btnWarehouseReturnInfoUpdate_Click"></asp:Button>
    <br /><asp:Button ID="btnInventoryInfoUpdate" runat="server" Text="Warehouse Inventory Info Update" onclick="btnWarehouseInventoryInfoUpdate_Click"></asp:Button>
    <br /><asp:Button ID="btnReSendWarehouseShippingOrder" runat="server" Text="Re-Send Warehouse Shipping Order" onclick="btnReSendWarehouseShippingOrder_Click"></asp:Button>
    <br /><asp:Button ID="btnSendCustomerShipmentEmail" runat="server" Text="Send Customer Shipment Email" onclick="btnSendCustomerShipmentEmail_Click"></asp:Button>
    <br /><br /><asp:Button ID="btnSetupProductShipToCountry" runat="server" Text="Setup Product Ship To Country" onclick="btnSetupProductShipToCountry_Click"></asp:Button>
    </p>
    <div>
        <asp:TextBox ID="txtResult" runat="server" textMode ="MultiLine" width="500" Height="500"></asp:TextBox>
    </div>
    </form>
</body>
</html>
