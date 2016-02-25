<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="product3.ascx.cs" Inherits="TweebaaWebApp.Manage.Ascx.product3" %>
<%@ Register  TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
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
                发布者：
            </td>
            <td>
                <input id="txtUser" type="text" class="t1" runat="server" />
            </td>
           
            <td style="padding-left: 5px; text-align: left;">
         
          <asp:Button ID="btnSerch" runat="server" Text="搜索" CssClass="btnSerch" OnClick="btnSerch_Click" />
       
                <%-- <asp:Button ID="btnOutput" runat="server" Text="导出"  CssClass="btnSerch" OnClick="btnOutput_Click" />--%>
               
            </td>
            <td>
            </td>
        </tr>
    </table>
<asp:GridView ID="gridData" runat="server" AutoGenerateColumns="false" CssClass="gridData"
    CellPadding="4" GridLines="None"  OnRowDataBound="gridData_RowDataBound"
   Width="99%" >
    <Columns>
        <asp:TemplateField HeaderText="操作" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="10%">
            <ItemTemplate>               
                <%--<a href="" title="产品详情" style="background-image: url(./css/xiangqing.png); background-repeat: no-repeat;
                    display: inline-block; height: 20px; width: 20px;">&nbsp;</a>--%>
                <a href="../wnAdmin/admPrdSale.aspx?state=3&id=<%#Eval("prdguid") %>" title="销售详情"
                    style="background-image: url(./css/xiangqing.png); background-repeat: no-repeat;
                    display: inline-block; height: 20px; width: 20px;">&nbsp;</a> <a href="admPrdEdt.aspx?id=<%#Eval("prdguid") %>"
                        title="设置" style="background-image: url(./css/edit.png); background-repeat: no-repeat;
                        display: inline-block; height: 20px; width: 20px;">&nbsp;</a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="prdguid" HeaderText="编号" ReadOnly="true" Visible="false" />
        <%-- <asp:BoundField DataField="name" HeaderText="产品名称"  ItemStyle-Width="30%"  />   
            <asp:BoundField DataField="prdguid" HeaderText="图片"  ItemStyle-Width="15%"  />        --%>
        <asp:TemplateField HeaderText="商品" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="45%">
            <ItemTemplate>
                <div style="float: left; width: 100%;">
                    <div style="float: left; width: 35%; text-align: right;">
                          <a href="../newsaleproduct/<%#Eval("idx") %>" target="_blank">
                            <img src="../<%#Eval("fileurl") %>" alt="<%#Eval("name") %>" width="50px" height="50px" />
                        </a>                      
                    </div>
                    <div style="float: left; padding-left: 20px; padding-top: 10px; width: 35%;">
                        <%#Eval("name")%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="estimateprice" HeaderText="价格" ItemStyle-Width="15%" />
        <asp:BoundField DataField="count" HeaderText="销量" ItemStyle-Width="15%" />
        <asp:TemplateField HeaderText="销售总额" ItemStyle-Width="15%">
            <ItemTemplate>
                <%# GetSum(Eval("count"),Eval("estimateprice"))%>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr style="background: #507CD1; font-weight: bolder; height: 30px; color: White;
                text-align: center;">
                <td width="30%">
                    产品名称
                </td>
                <td width="15%">
                    图片
                </td>
                <td width="15%">
                    价格
                </td>
                <td width="15%">
                    销量
                </td>
                <td width="15%">
                    销售总额
                </td>
                <td width="10%">
                    操作
                </td>
            </tr>
            <tr>
                <td colspan="6" align="center" style="left: 40px; padding-top: 20px; border: 1px solid gray;
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

     <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator"   CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" 
FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"   PrevPageText="上一页"  ShowCustomInfoSection="Left" 
ShowInputBox="Never" OnPageChanging="AspNetPager1_PageChanging"   CustomInfoTextAlign="Left" LayoutType="Table"  >
</webdiyer:AspNetPager>
</ContentTemplate>
</asp:UpdatePanel>