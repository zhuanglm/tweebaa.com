<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true" CodeBehind="admUserEdit.aspx.cs" Inherits="TweebaaWebApp.Manage.admUserEdit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <%--选项卡--%>
    <link href="css/orderCss/admTab.css" rel="stylesheet" type="text/css" />
    <script src="../jquery-1.7.2/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="js/admTab.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
    当前位置：会员管理 | 会员详情 &nbsp;&nbsp;<a class="aFind" href="admUser.aspx" target="_self">转至用户列表</a>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <input type="hidden" id="txtData" runat="server" />
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <ul class="tabs" id="tabs">
                <li><a href="">修改信息</a></li>
            </ul>
            <ul class="tab_conbox" id="tab_conbox">
                <li class="tab_con">
                    <table class="rightcontfont">
                        <tr>
                            <td style="height: 40px;">
                                账户邮箱：
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" CssClass="input_tx" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px;">
                                密码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtPwd" CssClass="input_tx" runat="server"></asp:TextBox>
                                <span style="font-size: smaller;">不修改密码，请留空</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px;">
                                状态：
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlState" runat="server">
                                    <asp:ListItem Value="0">锁定</asp:ListItem>
                                    <asp:ListItem Value="1">正常</asp:ListItem>
                                    <asp:ListItem Value="2">待激活</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px;">
                                姓名：
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" CssClass="input_tx" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px;">
                                电话：
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhone" CssClass="input_tx" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px;">
                                出生日期：
                            </td>
                            <td>
                                <asp:TextBox ID="txtBirth" CssClass="input_tx" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="visibility: hidden;">
                            <td style="height: 40px;">
                                性别：
                            </td>
                            <td>
                                <asp:TextBox ID="txtSex" CssClass="input_tx" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="visibility: hidden;">
                            <td style="height: 40px;">
                                地址：
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddress" CssClass="input_tx" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: right">
                                <asp:Button ID="btnBack" runat="server" CssClass="btnSerch" Text="保 存" OnClick="btnSave_Click" />
                            </td>
                        </tr>
                    </table>
                </li>
            </ul>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>
