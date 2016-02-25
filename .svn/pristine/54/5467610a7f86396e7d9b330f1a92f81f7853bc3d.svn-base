<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="admPeronMoney.ascx.cs" Inherits="TweebaaWebApp2.Manage.Ascx.admPeronMoney" %>
<%@ Register  TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
<asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
        <div id="main_c" style="border: none;">
            <table style="padding: 0px; margin: 0px;">
        <tr>           
            <td>
                类型
            </td>
            <td>
                <asp:DropDownList ID="ddlType" runat="server" Width="100px" 
                    onselectedindexchanged="ddlType_SelectedIndexChanged">
                    <asp:ListItem Value="">全部</asp:ListItem>
                    <asp:ListItem Value="1">销售收益</asp:ListItem>
                    <asp:ListItem Value="2">评审收益</asp:ListItem>
                    <asp:ListItem Value="3">分享收益</asp:ListItem>
                </asp:DropDownList>
            </td>
           
            <td>
                状态
            </td>
            <td>
                <asp:DropDownList ID="ddlState" runat="server"  Width="100px" 
                    AutoPostBack="true" onselectedindexchanged="ddlState_SelectedIndexChanged" >
                    <asp:ListItem Value="">全部</asp:ListItem>
                    <asp:ListItem Value="0">未提取</asp:ListItem>
                    <asp:ListItem Value="1">申请中</asp:ListItem>
                    <asp:ListItem Value="2">已提取</asp:ListItem>
                    <asp:ListItem Value="-1">拒绝</asp:ListItem>
                </asp:DropDownList>
            </td>
             <td>
                       日期：
                    </td>
                    <td>
                        从
                        <input id="txtDate1" type="text" class="t1" runat="server"  style=" width:100px" onclick="WdatePicker()"  />到
                        <input id="txtDate2" type="text" class="t1" runat="server" style=" width:100px" onclick="WdatePicker()"  />
                    </td>
            <td style="padding-left: 5px; text-align: left;">
                 <asp:Button ID="btnSerch" runat="server" Text="搜索" CssClass="btnSerch"  OnClick="btnSerch_Click" />
         
            </td>
            <td>
            </td>
        </tr>
    </table>
            <table id="table1" cellspacing="0" cellpadding="0" border="0" class="tableStyle">
                <thead>
                    <tr>
                        <%-- <th>
                            操作
                        </th>--%>
                        <th>
                            金额
                        </th>
                        <th>
                            收益类型
                        </th>
                        <th>
                            收益日期
                        </th>
                        <th>
                            提取状态
                        </th>
                        <th>
                            收款账号
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repData" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Eval("amount")%>
                                </td>
                                <td>
                                    <%#Eval("wntype")%>
                                </td>
                                <td>
                                    <%#Eval("addtime")%>
                                </td>
                                <td>
                                    <%#Eval("wnstate")%>
                                </td>
                                <td>
                                    <%#Eval("paymentno")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>

                <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator"   CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" 
FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"   PrevPageText="上一页"  ShowCustomInfoSection="Left" 
ShowInputBox="Never" OnPageChanging="AspNetPager1_PageChanging"   CustomInfoTextAlign="Left" LayoutType="Table"  >
</webdiyer:AspNetPager>

        </div>
    </ContentTemplate>
</asp:UpdatePanel>