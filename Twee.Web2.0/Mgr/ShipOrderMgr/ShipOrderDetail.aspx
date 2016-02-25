﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShipOrderDetail.aspx.cs" Inherits="TweebaaWebApp2.Mgr.ShipOrderMgr.ShipOrderDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <title></title>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <script src="../../js/util.js" type="text/javascript"></script>
    <script src="../../js/xd.js" type="text/javascript"></script>
     <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jquery.placeholder2.js" type="text/javascript"></script>
    <script src="../../js/biaodan2.js" type="text/javascript"></script>
    <script src="../../js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/newfloat.js"></script>
    <link href="../css/mgr.css" rel="stylesheet" />
    <link href="../css/aspnetpager.css" rel="stylesheet" />
    <link href="../ui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../ui/themes/demo.css" rel="stylesheet" type="text/css" />
    <link href="../ui/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../ui/jquery.min.js" type="text/javascript"></script>
    <script src="../ui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../ui/easyloader.js" type="text/javascript"></script>
</head>
<body style="padding: 2px;">
    <form id="form1" runat="server">
    <table class="tbtable" style="width: 100%;">
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left"> Shipping Order #</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblShipOrderID" runat="server" ></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left">Tweebaa Order #</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblTweebaaOrderID" runat="server" ></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left">Customer Order Date</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblCustomerOrderDate" runat="server" ></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left">Shipping Order Status</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblShipOrderStatus" runat="server" ></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left">Shipping Partner Order #</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblShipPartnerOrderID" runat="server"></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left">Shipped Date</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblShipedDate" runat="server" ></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left">Ship To Name</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblShipToName" runat="server" ></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left">Ship To Address </td>
            <td style="white-space: nowrap;"><asp:Label ID="lblShipToAddress" runat="server" ></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left">Ship To City, Province, Zip</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblShipToCityProvinceZip" runat="server" ></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left">Ship To Country</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblShipToCountry" runat="server" ></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left">Ship To Phone #</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblShipToPhone" runat="server" ></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left">Ship To Email</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblShipToEmail" runat="server" ></asp:Label></td>
            <td></td>
        </tr>
    </table>
    <table class="tbtable" style="width: 100%;">
        <tr>
        <td><asp:GridView ID="gdvProduct" runat="server" HeaderStyle-BackColor="#7FFFD4" HeaderStyle-ForeColor="Black" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" ItemStyle-Width="150" />
                <asp:BoundField DataField="TweebaaSKU" HeaderText="Tweebaa SKU" ItemStyle-Width="100" ItemStyle-HorizontalAlign="center" />
                <asp:BoundField DataField="ItemTypeName" HeaderText="Spec Type" ItemStyle-Width="80" />
                <asp:BoundField DataField="ItemName" HeaderText="Spec Name" ItemStyle-Width="80" />
                <asp:BoundField DataField="ItemQuantity" HeaderText="Qty" ItemStyle-Width="40" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="ItemUnitPrice" HeaderText="Unit Price" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="ItemShipFee" HeaderText="Shipping Fee" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="TaxSum" HeaderText="Tax" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Right" />
                <asp:BoundField DataField="TrackingNo" HeaderText="Tracking #" ItemStyle-Width="160" HtmlEncode="False" />
                <asp:BoundField DataField="CarrierName" HeaderText="Carrier Name" ItemStyle-Width="120"  />
            </Columns>
        </asp:GridView></td>
        </tr>
    </table>
    <div>
      <h1>Shipping Order Request XML</h1>
      <asp:Literal ID="litReqXML" runat="server" />
    </div>
    <div>
      <h1>Shipping Order Response XML</h1>
      <asp:Literal ID="litResponseXML" runat="server" />
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
        });
    </script>
    </form>
</body>
</html>