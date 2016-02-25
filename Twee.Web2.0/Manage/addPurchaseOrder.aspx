<%@ Page Title=""  Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master" AutoEventWireup="true"
    CodeBehind="addPurchaseOrder.aspx.cs" Inherits="TweebaaWebApp2.Manage.Servers.addPurchaseOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="server">
    当前位置：仓库管理 》添加采购单
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="server">
    <table cellspacing="0" cellpadding="0" border="0" class="tableStyle">
        <tr>
            <td style="height: 40px; text-align: left;">
                产品名称：
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtPrdName" CssClass="input_tx" runat="server" Width="300px"></asp:TextBox>
            </td>
             <td style="height: 40px; text-align: left;">
                产品规格：
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtSku" CssClass="input_tx" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="height: 40px; text-align: left;">
                采购日期：
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtBarCode" CssClass="input_tx" runat="server" Width="300px"></asp:TextBox>
            </td>
             <td style="height: 40px; text-align: left;">
                计划发货日期：
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="TextBox2" CssClass="input_tx" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 40px; text-align: left;">
                计划到货日期：
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="TextBox4" CssClass="input_tx" runat="server" Width="300px"></asp:TextBox>
            </td>
             <td style="height: 40px; text-align: left;">
                审核日期：
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="TextBox5" CssClass="input_tx" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="height: 40px; text-align: left;">
                条形码：
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="TextBox1" CssClass="input_tx" runat="server" Width="300px"></asp:TextBox>
            </td>
             <td style="height: 40px; text-align: left;">
                采购数量：
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="TextBox3" CssClass="input_tx" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td colspan="4" style="height: 40px; text-align: left;">
                采购单价：
            </td>
            
        </tr>
       
        <tr>
            <td colspan="2" style="text-align: center;">
                <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="btnSerch" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="server">
</asp:Content>
