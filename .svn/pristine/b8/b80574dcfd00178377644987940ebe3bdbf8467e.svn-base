<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true"
    CodeBehind="AdmimPrdStorage.aspx.cs" Inherits="TweebaaWebApp.Manage.AdmimPrdStorage" %>

<%@ Register TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
    当前位置：仓库管理 》库存查看
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <table style="padding: 0px; margin: 0px;">
                <tr>
                    <td>
                        产品名称：
                    </td>
                    <td>
                        <input id="txtName" type="text" class="t1" runat="server" />
                    </td>
                    <td>
                        &nbsp;&nbsp;所在仓库：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStora" runat="server" AutoPostBack="true" Width="156px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;&nbsp;库存：
                    </td>
                    <td colspan="2">
                        从<input id="txtNumber0" type="text" class="t1" runat="server" />到
                        <input id="txtNumber1" type="text" class="t1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        所在地区：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBelongArea" runat="server" AutoPostBack="true" Width="156px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;&nbsp;配送地区：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSendArea" runat="server" AutoPostBack="true" Width="156px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: left;">
                        &nbsp;&nbsp;显示警界:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPrompt" runat="server" Width="156px">
                            <asp:ListItem Value="false">全部库存</asp:ListItem>
                            <asp:ListItem Value="true">警界库存</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right;">
                        <asp:Button ID="btnSerch" runat="server" Text="搜索" CssClass="btnSerch" OnClick="btnSerch_Click" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="False" DataKeyNames="name"
                OnRowEditing="gridData_RowEditing" OnRowUpdating="gridData_RowUpdating" OnRowCancelingEdit="gridData_RowCancelingEdit"
                Width="99%" CellPadding="4" ForeColor="#333333" GridLines="Both" RowStyle-HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <%-- <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1%>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <%--     <asp:TemplateField HeaderText="操作" >
                        <ItemTemplate>
                            <asp:HiddenField ID="hidId" runat="server" Value='<%#Eval("psGuid") %>' />
                            <a href="adminAddStorage.aspx?id=<%#Eval("storagGuid") %>" class="edit"></a>
                            <%-- <asp:LinkButton ID="lkbEdit" CssClass="edit" runat="server" OnClick="lkbEdit_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lkbUpdate" CssClass="edit" runat="server" OnClick="lkbUpdate_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <%--  <asp:BoundField DataField="name" HeaderText="产品" ReadOnly="true" />--%>
                    <asp:TemplateField HeaderText="产品">
                        <ItemTemplate>
                            <asp:HiddenField ID="hidId" runat="server" Value='<%#Eval("psGuid") %>' />
                            <%#Eval("name")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="所在仓库">
                        <ItemTemplate>
                            <asp:Label ID="labStoraName" runat="server" Text='<%#Eval("storagName") %>'></asp:Label>
                            <asp:DropDownList ID="ddlStoraSelect" runat="server" Width="156px" Visible="false">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="belongAreaName" HeaderText="所在地区" ReadOnly="true" />
                    <asp:TemplateField HeaderText="配送区域">
                        <ItemTemplate>
                            <%#GetSenaArea(Eval("sendAreaName").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="number" HeaderText="现有库存" />
                    <asp:BoundField DataField="promptNumber" HeaderText="库存警界" />
                    <asp:CommandField HeaderText="选择" ShowSelectButton="True" />
                    <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr style="background: #507CD1; font-weight: bolder; height: 30px; color: White;
                            text-align: center;">
                            <td width="20%">
                                产品
                            </td>
                            <td width="15%">
                                所在仓库
                            </td>
                            <td width="20%">
                                所在地区
                            </td>
                            <td width="20%">
                                配送范围
                            </td>
                            <td width="15%">
                                现有库存
                            </td>
                            <td width="10%">
                                库存警界
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10" align="center" style="left: 40px; padding-top: 20px; border: 1px solid gray;
                                font-size: 20px;">
                                暂无该数据<br />
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <AlternatingRowStyle CssClass="alternatingRowStyle" />
                <EditRowStyle CssClass="editRowStyle" />
                <FooterStyle CssClass="footerStyle" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" CssClass="Freezing" />
                <PagerStyle CssClass="pagerStyle" />
                <RowStyle CssClass="rowStyle" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle CssClass="sortedAscendingCellStyle" />
                <SortedAscendingHeaderStyle CssClass="sortedAscendingHeaderStyle" />
                <SortedDescendingCellStyle CssClass="sortedDescendingCellStyle" />
                <SortedDescendingHeaderStyle CssClass="sortedDescendingHeaderStyle" />
            </asp:GridView>
            <%--            <webdiyer:AspNetPager CssClass="anpager" CurrentPageButtonClass="cpb" ID="AspNetPager1"
                Visible="true" AlwaysShow="true" runat="server" HorizontalAlign="Center" Width="100%"
                PageSize="1" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页，每页%PageSize%条"
                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" ShowCustomInfoSection="Right"
                OnPageChanging="AspNetPager1_PageChanging">
            </webdiyer:AspNetPager>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>
