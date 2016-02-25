<%@ Page Title=""  Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true"
    CodeBehind="admOrderInfo.aspx.cs" Inherits="TweebaaWebApp2.Manage.admOrderInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <%--选项卡--%>
    <link href="css/orderCss/admTab.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="js/admTab.js" type="text/javascript"></script>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
    <ul class="tabs" id="tabs">
        <li><a href="">订单</a></li>
        <li><a href="">物流/支付</a></li>
        <li><a href="">会员</a></li>
    </ul>
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
                            <asp:Label ID="labEnd" runat="server"></asp:Label>
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
                            <asp:Label ID="labLogistics" runat="server"></asp:Label>
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
                    <tr>
                        <td width="15%">
                            <asp:Label ID="labPro" runat="server" Text="裙子"></asp:Label>
                        </td>
                        <td width="20%">
                            <asp:Label ID="labPrice" runat="server" Text="108"></asp:Label>
                        </td>
                        <td width="10%">
                            <asp:Label ID="labNumber" runat="server" Text="2"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="labMoney" runat="server" Text="216"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </li>
        <li class="tab_con"></li>
        <li class="tab_con"></li>
    </ul>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>
