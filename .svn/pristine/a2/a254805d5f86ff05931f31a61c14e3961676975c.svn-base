<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true" CodeBehind="AdmimManageArea.aspx.cs" Inherits="TweebaaWebApp.Manage.AdmimManageArea" %>


<%@ Register TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
当前位置：仓库管理 》物流区域管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
         <input type="button" id="btnInsert" runat="server" value="添加物流区域" class="btnSerch"  style=" width:120px; height:30px;" onserverclick="btnInsert_Click" />
         <br /><br />
            <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="False" DataKeyNames="areaGuid"
                Width="99%" CellPadding="4" ForeColor="#333333" GridLines="Both" RowStyle-HorizontalAlign="Center"
                OnRowDeleting="gridData_RowDeleting" OnRowEditing="gridData_RowEditing" OnRowUpdating="gridData_RowUpdating"
                OnRowCancelingEdit="gridData_RowCancelingEdit" OnRowDataBound="gridData_RowDataBound">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="areaGuid" HeaderText="序号" ReadOnly="true" />
                    <%--        <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="lkbEdit" CssClass="edit" runat="server" OnClick="lkbEdit_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lkbDele" CssClass="del" runat="server" OnClick="lkbDele_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:BoundField DataField="areaName" HeaderText="地区名称" />
                    <asp:BoundField DataField="remarkTxt" HeaderText="备注" />
                    <asp:CommandField HeaderText="选择" ShowSelectButton="True" />
                    <asp:CommandField HeaderText="编辑" ShowEditButton="true" />
                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                </Columns>
                <EmptyDataTemplate>
                    <%--  <table cellpadding="0" cellspacing="0" width="100%">
                        <tr style="background: #507CD1; font-weight: bolder; height: 30px; color: White;
                            text-align: center;">
                            <td width="40%">
                                地区名称
                            </td>
                            <td width="60%">
                                备注
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10" align="center" style="left: 40px; padding-top: 20px; border: 1px solid gray;
                                font-size: 20px;">
                                暂无该数据<br />
                            </td>
                        </tr>
                    </table>--%>
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
