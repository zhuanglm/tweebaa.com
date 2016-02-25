<%@ Page Title=""  Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true"
    CodeBehind="AdmimManageStorage.aspx.cs" Inherits="TweebaaWebApp2.Manage.AdmimManageStorage" %>

<%@ Register TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
    当前位置：仓库管理 》仓库列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div style="width: 100%; text-align: left">
                <asp:LinkButton ID="lkbAdd" runat="server" PostBackUrl="adminAddStorage.aspx?type=1"
                    class="btnSerch" Style="color: White; width: 100px; line-height: 35px;" Text="&nbsp;&nbsp;添加仓库&nbsp;&nbsp; "></asp:LinkButton>
            </div>
            <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="False" DataKeyNames="storagGuid"
                Width="99%" CellPadding="4" ForeColor="#333333" GridLines="Both" RowStyle-HorizontalAlign="Center"
                OnRowDeleting="gridData_RowDeleting">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="adminAddStorage.aspx?type=2&id=<%#Eval("storagGuid") %>" class="edit"></a>
                            <asp:LinkButton CssClass="del" runat="server" OnClick="lkbDele_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="storagName" HeaderText="仓库名称" />
                    <asp:BoundField DataField="areaName" HeaderText="所在区域" />
                    <asp:TemplateField HeaderText="配送区域">
                        <ItemTemplate>
                            <%#GetSenaArea(Eval("sendArea").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="remarkTxt" HeaderText="备注" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr style="background: #507CD1; font-weight: bolder; height: 30px; color: White;
                            text-align: center;">
                            <td width="20%">
                                仓库名称
                            </td>
                            <td width="20%">
                                所在区域
                            </td>
                            <td width="40%">
                                配送区域
                            </td>
                            <td width="20%">
                                备注
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
                <SelectedRowStyle CssClass="selectedRowStyle" />
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
