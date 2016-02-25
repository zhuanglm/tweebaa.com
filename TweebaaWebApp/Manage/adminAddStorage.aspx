<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true"
    CodeBehind="adminAddStorage.aspx.cs" Inherits="TweebaaWebApp.Manage.adminAddStorage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
    当前位置：仓库管理 》添加仓库 <a class="aFind" href="AdmimManageStorage.aspx" target="_self">转至仓库列表</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" border="0" class="tableStyle">
                <tr>
                    <td style="height: 40px; text-align: left;">
                        仓库名称：
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="txtName" CssClass="input_tx" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 40px; text-align: left;">
                        所属分区：
                    </td>
                    <td style="text-align: left;">
                        <asp:DropDownList ID="ddlBelogArea" runat="server" Width="120px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="height: 40px; text-align: left;">
                        配送区域：
                    </td>
                    <td style="text-align: left;">
                        <br />
                        <asp:CheckBoxList ID="ckbArea" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                            CellPadding="10">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td style="height: 40px; text-align: left;">
                        备注：
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="txtRem" CssClass="input_tx" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="btnSerch" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>
