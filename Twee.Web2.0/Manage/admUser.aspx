<%@ Page Title=""  Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true" CodeBehind="admUser.aspx.cs" Inherits="TweebaaWebApp2.Manage.admUser" %>

<%@ Register TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
     <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <link href="css/grid.css" rel="stylesheet" type="text/css" />
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
  当前位置：会员管理 》会员列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
  <table style="padding: 0px; margin: 0px;">
        <tr>
            <td>
                用户名称：
            </td>
            <td>
                <input id="txtUser" type="text" class="t1" runat="server" style=" width:100px;" />
            </td>
            <td>
                邮箱：
            </td>
            <td>
                <input id="txtEmail" type="text" class="t1" runat="server" style=" width:120px;" />
            </td>
            <td>
                注册时间：
            </td>
            <td>
                从：<input id="txtDate1" type="text" class="t1" runat="server" style=" width:100px;" onClick="WdatePicker()" />到：
                <input id="txtDate2" type="text" class="t1" runat="server" style=" width:100px;" onClick="WdatePicker()" />
            </td>
            <td>
                状态：
            </td>
            <td>                
                  <asp:DropDownList ID="ddlState" runat="server" Width="80px">
                    <asp:ListItem Value="">全部</asp:ListItem>
                    <asp:ListItem Value="0">锁定</asp:ListItem>
                    <asp:ListItem Value="1">正常</asp:ListItem>
                    <asp:ListItem Value="2">待激活</asp:ListItem>
                </asp:DropDownList>
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
        CellPadding="4" GridLines="None" OnRowDataBound="gridData_RowDataBound"
        EmptyDataText="暂无该数据" Width="99%">
        <Columns>
            <asp:TemplateField HeaderText="操作" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="6%">
                <ItemTemplate>
                    <a href="admUserInfo.aspx?id=<%#Eval("guid")%>" title="详情" style="background-image: url(./css/xiangqing.png);
                        background-repeat: no-repeat; display: inline-block; height: 20px; width: 20px;">
                        &nbsp;</a> <a href="admUserEdit.aspx?id=<%#Eval("guid") %>" title="设置" style="background-image: url(./css/edit.png);
                            background-repeat: no-repeat; display: inline-block; height: 20px; width: 20px;">
                            &nbsp;</a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="guid" HeaderText="编号" ReadOnly="true" Visible="false" />
            <asp:BoundField DataField="username" HeaderText="姓名" ItemStyle-Width="8%" />
            <asp:BoundField DataField="phone" HeaderText="电话" ItemStyle-Width="10%" />
            <asp:BoundField DataField="email" HeaderText="邮箱" ItemStyle-Width="15%" />
            <asp:BoundField DataField="publishgrade" HeaderText="发布等级" ItemStyle-Width="8%" />
            <asp:BoundField DataField="reviewgrade" HeaderText="评审等级" ItemStyle-Width="8%" />
            <asp:BoundField DataField="sharegrade" HeaderText="分享等级" ItemStyle-Width="8%" />
            <asp:BoundField DataField="publishcount" HeaderText="发布个数" ItemStyle-Width="8%" />
            <asp:BoundField DataField="reviewhcount" HeaderText="评审个数" ItemStyle-Width="8%" />
            <asp:BoundField DataField="sharecount" HeaderText="分享个数" ItemStyle-Width="8%" />
            <asp:BoundField DataField="acttime" DataFormatString="{0:yyyy-MM-dd}"  HeaderText="上次登录时间" />
            <%--<asp:TemplateField HeaderText="">
              <ItemTemplate>
               <%# string.Format("yyyy-MM-dd",Eval("acttime").ToString())%>
              
              </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr style="background: #507CD1; font-weight: bolder; height: 30px; color: White;
                    text-align: center;">
                    <td width="8%">
                        姓名
                    </td>
                    <td width="10%">
                        电话
                    </td>
                    <td width="15%">
                        邮箱
                    </td>
                    <td width="8%">
                        发布等级
                    </td>
                    <td width="8%">
                        评审等级
                    </td>
                    <td width="8%">
                        分享等级
                    </td>
                    <td width="8%">
                        发布个数
                    </td>
                    <td width="8%">
                        评审个数
                    </td>
                    <td width="8%">
                        分享个数
                    </td>
                    <td>
                        最近登录时间
                    </td>
                </tr>
                <tr>
                    <td colspan="10" align="center" style="left: 40px; padding-top: 20px; border: 1px solid gray;
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
<%--  <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" NumericButtonCount="6"
        UrlPaging="true" NumericButtonTextFormatString="[{0}]" CustomInfoHTML="第 <font color='red'><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页 显示 %StartRecordIndex%-%EndRecordIndex% 条"
        ShowCustomInfoSection="left" FirstPageText="首页" LastPageText="末页" NextPageText="下页"
        PrevPageText="上页" Font-Names="Arial" BackColor="#F8B500" AlwaysShow="true" ShowInputBox="Always"
        SubmitButtonText="跳转" SubmitButtonStyle="botton" OnPageChanged="AspNetPager1_PageChanged">
    </webdiyer:AspNetPager>--%>
    <%--CssClass="anpager"--%>
<%--    <webdiyer:AspNetPager  CssClass="paginator"   CurrentPageButtonClass="cpb" ID="AspNetPager1" Visible="true" AlwaysShow="true"
        runat="server" HorizontalAlign="Center" Width="100%" PageSize="10" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页，每页%PageSize%条"
        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" ShowCustomInfoSection="Right" OnPageChanging="AspNetPager1_PageChanging" >
    </webdiyer:AspNetPager>--%>

      <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator"   CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" 
FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"   PrevPageText="上一页"  ShowCustomInfoSection="Left" 
ShowInputBox="Never" OnPageChanging="AspNetPager1_PageChanging"   CustomInfoTextAlign="Left" LayoutType="Table"  >
</webdiyer:AspNetPager>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
    <%-- <div class="contextMenu" id="menu">
        <ul>
            <li class="rightmenu" id="wnstat0">锁定</li>
            <li class="rightmenu" id="wnstat1">正常</li>
            <li class="rightmenu" id="wnstat2">未激活</li>
        </ul>
    </div>
    <div id="dvModel" style="display: none;">
        <table>
            <tr>
                <td>
                    email
                </td>
                <td>
                    <input id="Text1" type="text" class="t1 txtEmail" readonly="readonly" />
                </td>
                <td>
                    Phone
                </td>
                <td>
                    <input id="Text2" type="text" class="t1 txtPhone" />
                </td>
            </tr>
            <tr>
                <td>
                    user name
                </td>
                <td>
                    <input id="Text3" type="text" class="t1 txtName" />
                </td>
                <td>
                    状态
                </td>
                <td>
                    <select class="drpState">
                        <option value="0">锁定</option>
                        <option value="1">正常</option>
                        <option value="2">未激活</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="javascript:void(0)" class="aEsc" >Cancel</a>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>
