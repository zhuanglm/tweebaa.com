<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admOrderInfo.aspx.cs"
    Inherits="TweebaaWebApp2.Mgr.orderMgr.admOrderInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%--选项卡--%>   
    <link href="../css/admTab.css" rel="stylesheet" type="text/css" />   
    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../js/admTab.js" type="text/javascript"></script>
    <style type="text/css">
        .tableStyle
        {
            border: 1px solid #CCC;
            margin: 0 auto 10px;
            width: 98%;
        }
        .tableStyle th
        {
            background: #ebf0f4;
            font-weight: bold;
            padding: 10px;
            border-bottom: 1px solid #BFC4CA;
            text-align: center;
            white-space: nowrap;
        }
        .tableStyle td
        {
            padding: 8px;
            border-bottom: 1px dashed #CCC;
        }
        
        .tableStyle2
        {
            border: 1px solid #CCC;
            margin-left: 12px;
            width: 98%;
        }
        .tableStyle2 th
        {
            background: #ebf0f4;
            font-weight: bold;
            padding: 10px;
            border-bottom: 1px solid #BFC4CA;
            text-align: center;
            white-space: nowrap;
        }
        .tableStyle2 td
        {
            padding: 10px;
            border-bottom: 1px dashed #CCC;
            text-align: center;
        }
        
        .order2
        {
            background-color: #FFFCF3;
            border: 1px solid #F7E4A5;
            padding: 20px;
            margin: 0 24px 10px;
            font-size: 14px;
            color: #404040;
            overflow: hidden;
            width: 91%;
        }
        /*button*/
        .btn
        {
            background: url("css/bt-bg.gif") left 0;
            color: #717171;
            font-weight: bold;
            text-decoration: none;
            height: 30px;
            display: inline-block;
            cursor: pointer;
            margin-right: 5px;
            min-width: 50px;
        }
        .btn span
        {
            background: url("css/bt-bg.gif") right 0;
            padding: 6px 8px 6px 0;
            margin: 0 0 0 8px;
            display: inline-block;
            height: 16px;
            min-width: 50px;
        }
    </style>
</head>
<body style="overflow-x: hidden;">
    <form id="form1" runat="server">
    <ul class="tabs" id="tabs">
        <li><a href="">Order</a></li>
        <li><a href="">Shipment/Payment</a></li>
        <li><a href="">Member</a></li>
    </ul>
    <br />
    <div class="order2">
        <strong>Order Status：<asp:Label ID="lanState" runat="server"></asp:Label></strong>
        <div style="float: right; text-align: center;">
            <%--<a href="javascript:void(0);" class="btn" onclick="this.close();return false;"><span>关闭</span></a>--%>
        </div>
    </div>
    <ul class="tab_conbox" id="tab_conbox">
        <li class="tab_con">
            <table id="tabInfo1" cellspacing="0" cellpadding="0" border="0" class="tableStyle">
                <thead>
                    <tr>
                        <th colspan="4">
                            Order Information
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td width="15%">
                            Order ID:
                        </td>
                        <td width="20%">
                            <asp:Label ID="labCode" runat="server"></asp:Label>
                        </td>
                        <td width="10%">
                            Grand Total:
                        </td>
                        <td>
                            <asp:Label ID="labAmount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Start Time:
                        </td>
                        <td>
                            <asp:Label ID="labBegin" runat="server"></asp:Label>
                        </td>
                        <td>
                            End Time:
                        </td>
                        <td>
                            <asp:Label ID="labEnd" runat="server" Text="--"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Product Total Price:
                        </td>
                        <td>
                            <asp:Label ID="labSum" runat="server"></asp:Label>
                        </td>
                        <td>
                            Shipping Fees:
                        </td>
                        <td>
                            <asp:Label ID="labLogistics" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table id="tabInfo2" cellspacing="0" cellpadding="0" border="0" class="tableStyle2">
                <thead>
                    <tr>
                        <th width="55%">
                            Product
                        </th>
                        <th width="15%">
                            Unit Price（$）
                        </th>
                        <th width="15%">
                            Quantity
                        </th>
                        <th colspan="4">
                            Amount（$）
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repPro" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td width="15%">
                                    <asp:Label ID="labPro" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                                </td>
                                <td width="20%">
                                    <asp:Label ID="labPrice" runat="server" Text='<%#Eval("buydanJia") %>'></asp:Label>
                                </td>
                                <td width="10%">
                                    <asp:Label ID="labNumber" runat="server" Text='<%#Eval("quantity") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="labMoney" runat="server" Text='<%#Eval("proMoney") %>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </li>
        <li class="tab_con">
            <table id="tabInfo3" cellspacing="0" cellpadding="0" border="0" class="tableStyle">
                <thead>
                    <tr>
                        <th colspan="4">
                            Payment Information
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td width="20%">
                            Payment Method:
                        </td>
                        <td width="15%">
                            <asp:Label ID="labPayWay" runat="server" Text="货到付款(Pay after delivery)"></asp:Label>
                        </td>
                        <td width="20%">
                            Payment Time:
                        </td>
                        <td>
                            <asp:Label ID="labPayTime" runat="server" Text="--"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table id="tabInfo4" cellspacing="0" cellpadding="0" border="0" class="tableStyle">
                <thead>
                    <tr>
                        <th colspan="6">
                            Shipping Infomation
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td width="15%">
                            Recipient:
                        </td>
                        <td colspan="5">
                            <asp:Label ID="labRecivePeople" runat="server" Text="Buyer's Name"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                            Buyer Instruction:
                        </td>
                        <td colspan="5">
                            <asp:Label ID="labMessage" runat="server" Text="Very Good"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            Buyer Selected Shipping Method:
                        </td>
                        <td width="15%">
                            <asp:Label ID="labSelectSEndWay" runat="server" Text="Express"></asp:Label>
                        </td>
                        <td width="20%">
                            Shipping Courier:
                        </td>
                        <td width="15%">
                            <asp:Label ID="labTrueSendWay" runat="server" Text="--"></asp:Label>
                        </td>
                        <td width="15%">
                            Tracking Number:
                        </td>
                        <td width="15%">
                            <asp:Label ID="labExpressNo" runat="server" Text="--"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </li>
        <li class="tab_con">
            <table id="Table1" cellspacing="0" cellpadding="0" border="0" class="tableStyle">
                <thead>
                    <tr>
                        <th colspan="6">
                            Member Information
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td width="20%">
                            Member Name:
                        </td>
                        <td width="15%">
                            <asp:Label ID="labName" runat="server" Text="张三"></asp:Label>
                        </td>
                        <td width="20%">
                            Member ID:
                        </td>
                        <td>
                            <asp:Label ID="labPeaopleCode" runat="server" Text="0001"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            Email:
                        </td>
                        <td colspan="3">
                            <asp:Label ID="labEmail" runat="server" Text="123456@qq.com"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            Contact Number:
                        </td>
                        <td colspan="3">
                            <asp:Label ID="labPhone" runat="server" Text="13366666655"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </li>
    </ul>
    </form>
</body>
</html>
