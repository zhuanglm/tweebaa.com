<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventorySearch.aspx.cs"
    Inherits="TweebaaWebApp2.Mgr.Inventory.InventorySearch" %>

<%@ Register TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/mgr.css" rel="stylesheet" />
    <link href="../css/aspnetpager.css" rel="stylesheet" />
    <link href="../ui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../ui/themes/demo.css" rel="stylesheet" type="text/css" />
    <link href="../ui/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../ui/jquery.min.js" type="text/javascript"></script>
    <script src="../ui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../ui/easyloader.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <fieldset>
        <legend>Supply Search</legend>
        <table class="tbtable" style="width:850px;">
            <tr>
                <td  class="title" style="width:100px;">
                    Product Name
                </td>
                <td >
                    <input type="text" runat="server" id="txtproName" style="width: 200px; " />
                </td>
                <td  class="title" style="width:100px;">
                    Supply Status
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server" Width="150">
                    </asp:DropDownList>
                </td>
                <td class="title" style="width:100px;">
                    Supply Time
                </td>
                <td style="width:450px;">
                    From
                    <input id="txtDateStart" type="text" style="width: 100px;" runat="server" onclick="WdatePicker()" />
                    <br />To&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="txtDateEnd" type="text" style="width: 100px;" runat="server" onclick="WdatePicker()" />
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Search Supply" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <fieldset>
        <legend>Supply List</legend>
        <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            Width="800px">
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Supplier Product Name" ControlStyle-Width="250">
                    <ControlStyle Width="250px"></ControlStyle>
                </asp:BoundField>
                <asp:BoundField DataField="username" HeaderText="Supplier Name" ControlStyle-Width="250">
                    <ControlStyle Width="250px"></ControlStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Supply Status" ControlStyle-Width="80">
                    <ItemTemplate>
                        <%#GetState(Eval("state").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="createtime" HeaderText="Supply Time" ControlStyle-Width="120">
                    <ControlStyle Width="100px"></ControlStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <a href="javascript:void(0)" onclick="_view(this)" detailid=<%#Eval("id") %>>Verify</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
            <tr style="color:White;background-color:#006699;font-weight:bold;">
			<th scope="col">Supplier Product Name</th><th scope="col">Supplier Name</th><th scope="col">Supply Status</th><th scope="col">Supply Time</th><th scope="col">Action</th>
		</tr>
        <tr style="color:#000066;">
			<td colspan="5">No Data!</td>
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
            runat="server" AlwaysShow="True" FirstPageText="First" LastPageText="Last" NextPageText="Next"
            PrevPageText="Previous" ShowCustomInfoSection="Left" showinputbox="Never" OnPageChanging="AspNetPager1_PageChanging"
            CustomInfoTextAlign="Left" LayoutType="Table">
        </webdiyer:AspNetPager>
    </fieldset>

        <script type="text/javascript">
            $(function () {
                $("#txtDateStart,#txtDateEnd").datebox();
            })

            function _view(obj) {
                var id = $(obj).attr("detailid");
                var url = "Inventory/InventoryReview.aspx?detailid=" + id;
                window.parent._addTab('Supply Evaluation', url);
            }
        </script>
    </form>
</body>
</html>
