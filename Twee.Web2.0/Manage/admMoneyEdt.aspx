<%@ Page Title=""  Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true"
    CodeBehind="admMoneyEdt.aspx.cs" Inherits="TweebaaWebApp2.Manage.admMoneyEdt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link href="css/orderCss/order.css" rel="stylesheet" type="text/css" />
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
    当前位置：佣金管理 》佣金支付 <a class="aFind" href="admCashLst.aspx" target="_self">转至佣金列表</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <table cellspacing="0" cellpadding="0" border="0" class="tableStyle">
        <tr>
            <td style="height: 40px; text-align: left; width: 100px;">
                会员名称：
            </td>
            <td style="text-align: left;">
                &nbsp;
                <asp:Label ID="txtName" runat="server"></asp:Label>
                <%-- <asp:TextBox ID="txtName" CssClass="input_tx" runat="server" Width="200px" Enabled="false" ></asp:TextBox>--%>
            </td>
        </tr>
        <tr>
            <td style="height: 40px; text-align: left; width: 100px;">
                收益类型：
            </td>
            <td style="text-align: left;">
                &nbsp;
                <asp:Label ID="txtType" runat="server"></asp:Label>
                <%--<asp:TextBox ID="txtType" CssClass="input_tx" runat="server" Width="200px" Enabled="false" ></asp:TextBox>
                --%>
            </td>
        </tr>
        <tr>
            <td style="height: 40px; text-align: left; width: 100px;">
                收益日期：
            </td>
            <td style="text-align: left;">
                &nbsp;
                <asp:Label ID="txtDate" runat="server"></asp:Label>
                <%--<asp:TextBox ID="txtDate" CssClass="input_tx" runat="server" Width="200px" Enabled="false" ></asp:TextBox>
                --%>
            </td>
        </tr>
        <tr>
            <td style="height: 40px; text-align: left; width: 100px;">
                领取金额：
            </td>
            <td style="text-align: left;">
                &nbsp;
                <asp:Label ID="txtMoney" runat="server"></asp:Label>
                <%-- <asp:TextBox ID="txtMoney" CssClass="input_tx" runat="server" Width="200px" Enabled="false" ></asp:TextBox>
                --%>
            </td>
        </tr>
        <tr>
            <td style="height: 40px; text-align: left; width: 100px;">
                领取账户：
            </td>
            <td style="text-align: left;">
                &nbsp;
                <asp:Label ID="txtCard" runat="server"></asp:Label>
                <%-- <asp:TextBox ID="txtCard" CssClass="input_tx" runat="server" Width="200px" Enabled="false" ></asp:TextBox>
                --%>
            </td>
        </tr>
        <%--  <tr>
                    <td style="height: 40px;text-align:left;">
                        支付密码：
                    </td>
                    <td style="text-align:left;">
                   <asp:TextBox ID="txtPayPwd" CssClass="input_tx" runat="server" Width="200px"  ></asp:TextBox>
                     
                    </td>
                </tr>--%>
        <tr>
            <td colspan="2" style="text-align: left; padding-left: 200px;">
                <asp:Button ID="btnAdd" runat="server" Text="支付" CssClass="btnSerch" OnClick="btnPay_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
    <input id="hprdguid" type="hidden" runat="server" class="hprdid" />
    <input id="hprdguid2" type="hidden" runat="server" class="hprdid2" />
</asp:Content>
