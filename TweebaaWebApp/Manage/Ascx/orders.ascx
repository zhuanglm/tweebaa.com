<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="orders.ascx.cs" Inherits="TweebaaWebApp.Manage.Ascx.orders" %>
<%@ Register TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
<asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
        <div id="main_c" style="border: none;">
            <table style="padding: 0px; margin: 0px;">
                <tr>
                    <td style="width: 80px;">
                        订单日期：
                    </td>
                    <td>
                        从&nbsp;<asp:TextBox ID="txtTime1" class="t1" runat="server" onClick="WdatePicker()"></asp:TextBox>&nbsp;
                        到&nbsp;<asp:TextBox ID="txtTime2" class="t1" runat="server" onClick="WdatePicker()" ></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                        <asp:DropDownList ID="ddlType" runat="server">
                            <asp:ListItem Value="0">订单号</asp:ListItem>
                            <asp:ListItem Value="1">会员</asp:ListItem>
                            <asp:ListItem Value="2">收货人</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;：
                    </td>
                    <td>
                        <asp:TextBox ID="txtCode" class="t1" runat="server"></asp:TextBox>
                    </td>
                    <td style="padding-left: 5px; text-align: left;">
                        <asp:Button ID="btnSerch" runat="server" Text="搜索" CssClass="btnSerch" OnClick="btnSerch_Click" />
                        <asp:Button ID="btnOutput" runat="server" Text="导出" CssClass="btnSerch" OnClick="btnOutput_Click" Visible="false" />
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="false" CssClass="gridData"
                CellPadding="4" GridLines="None" OnRowDataBound="gridData_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="操作" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="9%">
                        <ItemTemplate>
                            <a href="javascript:void(0)" onclick='showBoxInfo("<%#Eval("guid") %>")' title="详情"
                                style="background-image: url(./css/xiangqing.png); background-repeat: no-repeat;
                                display: inline-block; height: 20px; width: 20px;">&nbsp;</a> <a href="./admOrderPrint1.aspx?guid=<%#Eval("guid") %>"
                                    title="打印购物单" style="display: inline-block; height: 20px; width: 20px;" target="_blank">
                                    购</a> <a href="./admOrderPrint2.aspx?guid=<%#Eval("guid") %>" title="打印配送单" style="display: inline-block;
                                        height: 20px; width: 20px;" target="_blank">配</a> <a href="./admOrderPrint3.aspx?id=1"
                                            title="打印快递单" target="_blank" style="display: inline-block; height: 20px; width: 20px;
                                            display: none;">递</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="guid" HeaderText="编号" ReadOnly="true" Visible="false" />
                    <asp:TemplateField HeaderText="订单号" ItemStyle-Width="12%">
                        <ItemTemplate>
                            <a href="javascript:void(0);" onmouseover="mouseOver()" id="hrfCode">
                                <%#Eval("guidno")%></a>
                            <p id="pUpdate">
                                <a href="javascript:void(0)" onclick='showBoxUpPrice("<%#Eval("guid") %>",0)'>改价</a>
                                <a href="javascript:void(0)" onclick='showBoxUpPrice("<%#Eval("guid") %>",1)'>支付</a>
                                <a href="javascript:void(0)" onclick='showBoxSend("<%#Eval("guid") %>")'>发货</a>
                                <a href="javascript:void(0)" onclick='showBoxConfirm("<%#Eval("guid") %>",0)'>完成</a>
                                <a href="javascript:void(0)" onclick='showBoxConfirm("<%#Eval("guid") %>",1)'>作废</a>
                            </p>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:BoundField DataField="name" HeaderText="商品" ItemStyle-Width="20%" />--%>
                    <asp:TemplateField HeaderText="商品" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="25%">
                        <ItemTemplate>
                            <div style="float: left; width: 100%;">
                                <div runat="server" id="divImg"  style="float: left; " >
                                     <asp:Label ID="labImg" runat="server" Text='<%# GetImg(Eval("guid").ToString(),Eval("name").ToString(),Eval("pid").ToString())%>'></asp:Label>
                                   
                                </div>
                                <div style="float: left; padding-left: 0px; padding-top: 10px; width: 70%;">
                                    <%#Eval("name")%>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="收货人" ItemStyle-Width="25%">
                        <ItemTemplate>
                            <%#Eval("reciveName") + "[" + Eval("recivePhone")+"]"%><br />
                            <%#Eval("address1")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态" ItemStyle-Width="13%" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Twee.Comm.CommUtil.CheckState(Eval("wnstat").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="idx" HeaderText="商品数量" Visible="false" />
                    <asp:TemplateField HeaderText="金额" ItemStyle-Width="10%">
                        <ItemTemplate>
                            商品：<%#Eval("sumProMoney")%><br />
                            物流：<%#Eval("logisticscost")%><br />
                            结算：<%# Twee.Comm.CommUtil.ToDecimal(Eval("sumProMoney").ToString()) + Twee.Comm.CommUtil.ToDecimal(Eval("logisticscost").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="username" HeaderText="会员" />
            <asp:BoundField DataField="phone" HeaderText="电话" />
            <asp:BoundField DataField="email" HeaderText="邮箱" />
            <asp:BoundField DataField="buydanJia" HeaderText="单价" />--%>
                    <asp:BoundField DataField="addtime" HeaderText="下单时间" />
                </Columns>
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
            <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
                runat="server" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" OnPageChanging="AspNetPager1_PageChanging"
                CustomInfoTextAlign="Left" LayoutType="Table">
            </webdiyer:AspNetPager>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>