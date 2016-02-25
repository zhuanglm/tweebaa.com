<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admOrderInfo2.aspx.cs"
    Inherits="TweebaaWebApp.Manage.admOrderInfo2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%--选项卡--%>
    <link href="Css/orderCss/admTab.css" rel="stylesheet" type="text/css" />
    <script src="Js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="Js/admTab.js" type="text/javascript"></script>
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
        <li><a href="">订单</a></li>
        <li><a href="">物流/支付</a></li>
        <li><a href="">会员</a></li>
    </ul>
    <br />
    <div class="order2">
        <strong>订单状态：<asp:Label ID="lanState" runat="server"></asp:Label></strong>
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
                            订单信息
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td width="15%">
                            订单编号:
                        </td>
                        <td width="20%">
                            <asp:Label ID="labCode" runat="server"></asp:Label>
                        </td>
                        <td width="10%">
                            最终结算:
                        </td>
                        <td>
                            <asp:Label ID="labAmount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            生成时间:
                        </td>
                        <td>
                            <asp:Label ID="labBegin" runat="server"></asp:Label>
                        </td>
                        <td>
                            结束时间:
                        </td>
                        <td>
                            <asp:Label ID="labEnd" runat="server" Text="--"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            商品总价:
                        </td>
                        <td>
                            <asp:Label ID="labSum" runat="server"></asp:Label>
                        </td>
                        <td>
                            配送费用:
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
                            商品
                        </th>
                        <th width="15%">
                            单价（￥）
                        </th>
                        <th width="15%">
                            数量
                        </th>
                        <th colspan="4">
                            金额（￥）
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
                            支付信息
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td width="20%">
                            支付方式:
                        </td>
                        <td width="15%">
                            <asp:Label ID="labPayWay" runat="server" Text="货到付款"></asp:Label>
                        </td>
                        <td width="20%">
                            支付时间:
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
                            物流信息
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td width="15%">
                            收货人:
                        </td>
                        <td colspan="5">
                            <asp:Label ID="labRecivePeople" runat="server" Text="张三"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                            买家留言:
                        </td>
                        <td colspan="5">
                            <asp:Label ID="labMessage" runat="server" Text="很好"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            买家选择发货方式:
                        </td>
                        <td width="15%">
                            <asp:Label ID="labSelectSEndWay" runat="server" Text="空运"></asp:Label>
                        </td>
                        <td width="20%">
                            实际物流公司:
                        </td>
                        <td width="15%">
                            <asp:Label ID="labTrueSendWay" runat="server" Text="--"></asp:Label>
                        </td>
                        <td width="15%">
                            运单号:
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
                            会员信息
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td width="20%">
                            会员名称:
                        </td>
                        <td width="15%">
                            <asp:Label ID="labName" runat="server" Text="张三"></asp:Label>
                        </td>
                        <td width="20%">
                            会员编号:
                        </td>
                        <td>
                            <asp:Label ID="labPeaopleCode" runat="server" Text="0001"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            邮箱:
                        </td>
                        <td colspan="3">
                            <asp:Label ID="labEmail" runat="server" Text="123456@qq.com"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            联系电话:
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
