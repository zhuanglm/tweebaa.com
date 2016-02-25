<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="admPeronPublish.ascx.cs" Inherits="TweebaaWebApp.Manage.Ascx.admPeronPublish" %>
    <%@ Register  TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
<asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
        <div id="main_c" style="border: none;">
            <table style="padding: 0px; margin: 0px;">
                <tr>
                    <td>
                        产品名称：
                    </td>
                    <td>
                        <input id="txtName" type="text" class="t1" runat="server" />
                    </td>
                    <td>
                        状态：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="false" >
                            <asp:ListItem Value="0">全部</asp:ListItem>
                            <asp:ListItem Value="1">评审区</asp:ListItem>
                            <asp:ListItem Value="2">预售区</asp:ListItem>
                            <asp:ListItem Value="3">销售区</asp:ListItem>
                            <asp:ListItem Value="-1">被屏蔽</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        发布时间：
                    </td>
                    <td>
                        从
                        <input id="txtDate1" type="text" class="t1" runat="server" onclick="WdatePicker()"  />到
                        <input id="txtDate2" type="text" class="t1" runat="server" onclick="WdatePicker()"  />
                    </td>
                    <td style="padding-left: 5px; text-align: left;">
                        <input type="button" id="btnSerch" runat="server" value="搜索" class="btnSerch" onserverclick="btnSerch_Click" />
                      <%--  <asp:LinkButton ID="LinkButton1" PostBackUrl="~/Manage/admPeronReview.aspx" runat="server"
                            CssClass="btnSerch2" Text="查看所有产品评审"></asp:LinkButton>--%>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <table id="table1" cellspacing="0" cellpadding="0" border="0" class="tableStyle">
                <thead>
                    <tr>
                        <th>
                            产品
                        </th>
                        <th>
                            状态
                        </th>
                        <th>
                            价格
                        </th>
                        <th>
                            发布时间
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repData" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <div style="float: left; width: 100%;">
                                        <div style="float: left; width: 30%;">
                                            <a href="">
                                                <img src="../<%#Eval("fileurl") %>" alt="<%#Eval("name") %>" width="50px" height="50px" />
                                            </a>
                                        </div>
                                        <div style="float: left; padding-left: 0px; padding-top: 10px; width: 70%;">
                                            <%#Eval("name")%>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <%#Eval("wnstat")%>
                                </td>
                                <td>
                                    <%#Eval("wnstat")%>
                                </td>
                                <td>
                                    <%#Eval("addtime")%>
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