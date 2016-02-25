<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true"
    CodeBehind="admPatent.aspx.cs" Inherits="TweebaaWebApp.Manage.admPatent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
    当前位置：专利管理 》申请列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <table style="padding: 0px; margin: 0px;">
                <tr>
                    <td>
                        用户名：
                    </td>
                    <td>
                        <input id="txtname" type="text" class="t1" runat="server" />
                    </td>
                    <td style="width: 60px;">
                        Email：
                    </td>
                    <td>
                        <input id="txtEmail_s" type="text" class="t1" />
                    </td>
                    <td style="padding-left: 5px; text-align: left;">
                        <input type="button" id="Button1" runat="server" value="搜索" class="btnSerch" onserverclick="btnSerch_Click" />
                        <input type="button" id="btnReset" runat="server" value="清空" class="btnSerch" onserverclick="btnReset_Click" />
                        <%--<asp:Button ID="btnReset" runat="server" Text=" 清 空 " OnClick="btnReset_Click" />--%>
                        <%--  <a id="aFind" class="aFind" href="javascript:void(0)">Search</a> <a id="aAll" class="aAll"
                    href="javascript:void(0)">Refresh</a>--%>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="False" DataKeyNames="guid"
                CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="gridData_RowDeleting"
                OnRowEditing="gridData_RowEditing" OnRowUpdating="gridData_RowUpdating" OnRowCancelingEdit="gridData_RowCancelingEdit"
                OnRowDataBound="gridData_RowDataBound" Width="99%">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="guid" HeaderText="编号" ReadOnly="true" />
                    <asp:BoundField DataField="guid" Visible="false" />
                    <asp:BoundField DataField="userguid" Visible="false" />
                    <asp:BoundField DataField="username" HeaderText="会员" />
                    <asp:BoundField DataField="patentname" HeaderText="专利名称" />
                    <%-- <asp:BoundField DataField="patentcode" HeaderText="专利编号" />--%>
                    <asp:TemplateField HeaderText="专利编号">
                        <ItemTemplate>
                            <%--<asp:LinkButton ID="lkbCode" runat="server" PostBackUrl="admPatentInfo.aspx?id=<%#Eval('patentcode') %>"><%#Eval("patentcode") %></asp:LinkButton>--%>
                            <a href='admPatentInfo.aspx?id=<%# Eval("guid") %>'>
                                <%#Eval("patentcode") %></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="createtime" HeaderText="创建时间" ReadOnly="true" />
                    <asp:CommandField HeaderText="选择" ShowSelectButton="True" />
                    <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" CssClass="Freezing" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
    <div id="page">
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbcurrentpage1" runat="server" Text="当前页:"></asp:Label>
                    <asp:Label ID="lbCurrentPage" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lbFenGe" runat="server" Text="/"></asp:Label>
                    <asp:Label ID="lbPageCount" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="recordscount" runat="server" Text="总条数:"></asp:Label>
                    <asp:Label ID="lbRecordCount" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Fistpage" runat="server" CommandName="" Text="首页" OnClick="PagerBtnCommand_OnClick" />
                    <asp:Button ID="Prevpage" runat="server" CommandName="prev" Text="上一页" OnClick="PagerBtnCommand_OnClick" />
                    <asp:Button ID="Nextpage" runat="server" CommandName="next" Text="下一页" OnClick="PagerBtnCommand_OnClick" />
                    <asp:Button ID="Lastpage" runat="server" CommandName="last" Text="尾页" key="last"
                        OnClick="PagerBtnCommand_OnClick" />
                </td>
                <td>
                    <asp:Label ID="lbjumppage" runat="server" Text="跳转到第"></asp:Label>
                    <asp:TextBox ID="GotoPage" runat="server" Width="25px"></asp:TextBox>
                    <asp:Label ID="lbye" runat="server" Text="页"></asp:Label>
                    <asp:Button ID="Jump" runat="server" Text="跳转" CommandName="jump" OnClick="PagerBtnCommand_OnClick" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
