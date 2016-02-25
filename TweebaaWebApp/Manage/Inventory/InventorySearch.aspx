﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventorySearch.aspx.cs"
    Inherits="TweebaaWebApp.Manage.Inventory.InventorySearch" %>

<%@ Register TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <fieldset style="font-size: 13px; padding: 5px;">
        <legend style="font-size: 14px; font-weight: bold;">供货搜索</legend>
        <table style="width: 800;">
            <tr>
                <td width="100" style="font-weight: bold; text-align: center;">
                    产品名称：
                </td>
                <td width="200">
                    <input type="text" runat="server" id="txtproName" style="width: 200px;" />
                </td>
                <td width="100" style="font-weight: bold; text-align: center;">
                    供货状态：
                </td>
                <td width="100">
                    <asp:DropDownList ID="ddlStatus" runat="server" Width="80">
                    </asp:DropDownList>
                </td>
                <td width="100" style="font-weight: bold; text-align: center;">
                    供货时间：
                </td>
                <td width="350">
                    从
                    <input id="txtDateStart" type="text" style="width: 100px;" runat="server" onclick="WdatePicker()" />
                    到
                    <input id="txtDateEnd" type="text" style="width: 100px;" runat="server" onclick="WdatePicker()" />
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="搜索供货" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <fieldset style="font-size: 13px; padding: 5px;">
        <legend style="font-size: 14px; font-weight: bold;">供货列表</legend>
        <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            Width="800px">
            <Columns>
                <asp:BoundField DataField="name" HeaderText="供货商品名称" ControlStyle-Width="250">
                    <ControlStyle Width="250px"></ControlStyle>
                </asp:BoundField>
                <asp:BoundField DataField="username" HeaderText="供货商名称" ControlStyle-Width="250">
                    <ControlStyle Width="250px"></ControlStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="供货状态" ControlStyle-Width="80">
                    <ItemTemplate>
                        <%#GetState(Eval("state").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="createtime" HeaderText="供货时间" ControlStyle-Width="120">
                    <ControlStyle Width="100px"></ControlStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <a href="#">评审</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
            <tr style="color:White;background-color:#006699;font-weight:bold;">
			<th scope="col">供货商品名称</th><th scope="col">供货商名称</th><th scope="col">供货状态</th><th scope="col">供货时间</th><th scope="col">操作</th>
		</tr>
        <tr style="color:#000066;">
			<td colspan="5">没有数据！</td>
		</tr>
            </EmptyDataTemplate>

            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
            runat="server" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
            PrevPageText="上一页" ShowCustomInfoSection="Left" showinputbox="Never" OnPageChanging="AspNetPager1_PageChanging"
            CustomInfoTextAlign="Left" LayoutType="Table">
        </webdiyer:AspNetPager>
    </fieldset>
    </form>
</body>
</html>
