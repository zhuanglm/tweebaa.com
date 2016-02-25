<%@ Page Title=""  Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master" AutoEventWireup="true" CodeBehind="needPurchaseOrder.aspx.cs" Inherits="TweebaaWebApp2.Manage.needPurchaseOrder" %>
<%@ Register TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="server">
 当前位置：仓库管理 》推送产品信息
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="server">
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
                <asp:Button ID="btnSerch" runat="server" Text="查询" CssClass="btnSerch" OnClick="btnSerch_Click" />
                <asp:Button ID="btnSend" runat="server" Text="批量推送" Width="100" CssClass="btnSerch" OnClick="btnSendAll_Click" />
                <%-- <asp:Button ID="btnOutput" runat="server" Text="导出"  CssClass="btnSerch" OnClick="btnOutput_Click" />--%>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hidIds" runat="server" />
    <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="false" CssClass="gridData"
        CellPadding="4" GridLines="None"  Width="99%">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                      <input type="checkbox" name="BoxIdAll" id="BoxIdAll" onclick="onclicksel();" />  
                  
                </HeaderTemplate>
                <ItemTemplate>
                     <input id="BoxId" name="BoxId" value='<%#Eval("proid").ToString()+","+Eval("provideUser").ToString()+","+Eval("name").ToString()%>' type="checkbox" />  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="10%">
                <ItemTemplate>
                    <a href="../Manage/admPrdSale.aspx?state=3&id=<%#Eval("proid") %>" title="销售详情"
                        style="background-image: url(./css/xiangqing.png); background-repeat: no-repeat;
                        display: inline-block; height: 20px; width: 20px;">&nbsp;</a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="name" HeaderText="产品名称" ItemStyle-Width="30%" />
            <asp:TemplateField HeaderText="商品" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="25%">
                <ItemTemplate>
                    <div style="float: left; width: 100%;">
                        <a href="../Product/presaleBuy.aspx?/<%#Eval("proid") %>" target="_blank">
                            <img src='<%# GetPic(Eval("fileurl").ToString()) %>' alt="<%#Eval("name") %>" width="50px"
                                height="50px" />
                        </a>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="presaleendtime" HeaderText="预售结束时间" ItemStyle-Width="25%" />
            <asp:TemplateField HeaderText="推送仓库" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="15%">
                <ItemTemplate>
                    <asp:Button ID="btnSend" runat="server" Text="推送到仓库" OnClick="btnSend_Click"  CssClass="btnSerch" Width="110" />
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
    <webdiyer:aspnetpager id="AspNetPager1" cssclass="paginator" currentpagebuttonclass="cpb"
        runat="server" alwaysshow="True" firstpagetext="首页" lastpagetext="尾页" nextpagetext="下一页"
        prevpagetext="上一页" showcustominfosection="Left" showinputbox="Never" onpagechanging="AspNetPager1_PageChanging"
        custominfotextalign="Left" layouttype="Table">
</webdiyer:aspnetpager>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="server">
</asp:Content>
