<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerOrders.ascx.cs" Inherits="TweebaaWebApp.Manage.Ascx.CustomerOrders" %>
<script runat="server">
    protected override void OnLoad(EventArgs e)
    {
        this.sqlDsOrders.SelectParameters["HeadGuId"].DefaultValue = this.HeadGuId;
        base.OnLoad(e);
    }
</script>
<asp:SqlDataSource ID="sqlDsOrders" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
    SelectCommand=" select b.headGuid, b.idx ,p.prdGuid,p.name, b.buydanJia,b.quantity,b.prdGuid, from  
 dbo.wn_orderBody b inner join dbo.wn_prd p on b.prdGuid=p.prdGuid where (b.headGuid=@HeadGuId) ">
    <SelectParameters>
        <asp:Parameter Name="HeadGuId" Type="String" DefaultValue="" />
    </SelectParameters>
</asp:SqlDataSource>

<asp:Repeater ID="List" runat="server">
    <HeaderTemplate>
        <table class="grid" cellspacing="0" rules="all" border="1" style="border-collapse: collapse;">
            <tr>
                <th scope="col">&nbsp;</th>
                <th scope="col">产品名称</th>
                <th scope="col">单价</th>
                <th scope="col">数量</th>
                <th scope="col" style="text-align: right;">金额</th>
                
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class='<%# (Container.ItemIndex%2==0) ? "row" : "altrow" %>'>
            <td class="rownum"><%# Container.ItemIndex+1 %></td>
            <td style="width: 80px;"><%# Eval("name")%></td>
            <td style="width: 80px;"><%# Eval("buydanJia")%></td>
            <td style="width: 80px;"><%# Eval("quantity")%></td>
              <td style="width: 80px;"></td>
<%--
            <td style="width: 100px;"><%# Eval("OrderDate","{0:dd/MM/yyyy}") %></td>
            <td style="width: 110px;"><%# Eval("RequiredDate", "{0:dd/MM/yyyy}")%></td>
            <td style="width: 50px; text-align: right;"><%# Eval("Freight","{0:F2}") %></td>
            <td style="width: 100px;"><%# Eval("ShippedDate", "{0:dd/MM/yyyy}")%></td>--%>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
