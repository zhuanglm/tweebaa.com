<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true" CodeBehind="admCashLst.aspx.cs" Inherits="TweebaaWebApp.Manage.admCashLst" %>

<%@ Register  TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
 <%--   <script src="js/admCashLst.js" type="text/javascript"></script>
    <script src="../plugins/jquery.contextmenu.r2.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>   
    <link rel="stylesheet" type="text/css" href="Css/orderCss/grid.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
当前位置：佣金管理 》佣金列表    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
 
    <table style="padding: 0px; margin: 0px;">
        <tr>
            <td>
                会员名称：
            </td>
            <td>
                <input id="txtName" type="text" class="t1" runat="server"  style=" width:80px;" />
            </td>
            <td style="width:90px;">
                会员账号：
            </td>
            <td>
                <input id="txtEmail" type="text" class="t1" runat="server" style=" width:90px;" />
            </td>
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
                        <input id="txtDate1" type="text" class="t1" runat="server"  style=" width:100px" onClick="WdatePicker()" />到
                        <input id="txtDate2" type="text" class="t1" runat="server" style=" width:100px" onClick="WdatePicker()" />
                    </td>
            <td style="padding-left: 5px; text-align: left;">
                 <asp:Button ID="btnSerch" runat="server" Text="搜索" CssClass="btnSerch"  OnClick="btnSerch_Click" />
         
            </td>
            <td>
            </td>
        </tr>
    </table>
   <asp:UpdatePanel runat="server" ID="UpdatePanel2">
        <ContentTemplate>

    <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="false" CssClass="gridData"
    CellPadding="4" GridLines="None" AllowPaging="true" PageSize="5" OnRowDataBound="gridData_RowDataBound"
    EmptyDataText="暂无该数据"  Width="99%" >
    <Columns>
        <asp:TemplateField HeaderText="操作" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="12%">
            <ItemTemplate>              
               <a href="admMoneyEdt.aspx?id=<%#Eval("guid") %>" title="设置" style="background-image: url(./css/edit.png);
                        background-repeat: no-repeat; display: inline-block; height: 20px; width: 20px;">
                        &nbsp;</a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="guid" HeaderText="编号" ReadOnly="true" Visible="false" />      
       <asp:BoundField DataField="username" HeaderText="会员" ItemStyle-Width="15%" />
        <asp:BoundField DataField="amount" HeaderText="金额" ItemStyle-Width="15%" />
        <asp:BoundField DataField="" HeaderText="收益类型" ItemStyle-Width="15%" />       
        <asp:BoundField DataField="addtime" HeaderText="收益日期" ItemStyle-Width="15%" />
     
        <asp:TemplateField HeaderText="提取状态" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
          <ItemTemplate>
           <%#GetState(Eval("wnstate").ToString())%>
          </ItemTemplate>
        
        </asp:TemplateField>
        <asp:BoundField DataField="paymentno" HeaderText="收款账号" ItemStyle-Width="15%" />
      
    </Columns>
    <EmptyDataTemplate>
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr style="background: #507CD1; font-weight: bolder; height: 30px; color: White;
                text-align: center;">
                <td width="20%">
                    会员
                </td>
                <td width="10%">
                    金额
                </td>
                <td width="8%">
                    收益类型
                </td>
                <td width="8%">
                    收益日期
                </td>
                <td width="8%">
                    提取状态
                </td>
                <td width="8%">
                    收款账号
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

 </ContentTemplate>
    </asp:UpdatePanel>
  <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator"   CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" 
FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"   PrevPageText="上一页"  ShowCustomInfoSection="Left" 
ShowInputBox="Never" OnPageChanging="AspNetPager1_PageChanging"   CustomInfoTextAlign="Left" LayoutType="Table"  >
</webdiyer:AspNetPager>



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
   <%-- <div class="contextMenu" id="menu">
        <ul>
            <li class="rightmenu" id="wnstat0">确定兑换</li>
            <li class="rightmenu" id="wnstat1">拒绝兑换</li>
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
                    <a href="javascript:void(0)" class="aEsc" onclick="$.dialogs.close(null)">Cancel</a>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>
