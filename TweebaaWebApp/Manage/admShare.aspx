<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true" CodeBehind="admShare.aspx.cs" Inherits="TweebaaWebApp.Manage.admShare" %>
<%@ Register  TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <%-- <script src="js/admShare.js" type="text/javascript"></script>--%>
    <link href="css/grid.css" rel="stylesheet" type="text/css" />
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
 当前位置：分享记录 》产品分享列表 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                        分享方式：
                    </td>
                    <td>
                       <asp:DropDownList ID="dllType" runat="server">
                         <asp:ListItem>全部</asp:ListItem>
                         <asp:ListItem>QQ</asp:ListItem>
                         <asp:ListItem>微博</asp:ListItem>
                         <asp:ListItem>邮箱</asp:ListItem>
                       </asp:DropDownList>
                    </td>                        
                    <td>
                        分享时间：
                    </td>
                    <td>
                        从
                        <input id="txtDate1" type="text" class="t1" runat="server" onClick="WdatePicker()" />到
                        <input id="txtDate2" type="text" class="t1" runat="server" onClick="WdatePicker()" />
                    </td>
                    <td style="padding-left: 5px; text-align: left;">
                        <input type="button" id="btnSerch" runat="server" value="搜索" class="btnSerch" onserverclick="btnSerch_Click" />
                       
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
    <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="false" CssClass="gridData"
        CellPadding="4" GridLines="None"  OnRowDataBound="gridData_RowDataBound"
       ShowFooter="true" Width="99%" >
        <Columns>
            <asp:TemplateField HeaderText="操作" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="7%" Visible="false">
                <ItemTemplate>
                    <a href="../wnAdmin/admPrdSale.aspx?state=3&id=<%#Eval("prtguid") %>" title="销售详情"
                        style="background-image: url(./css/xiangqing.png); background-repeat: no-repeat;
                        display: inline-block; height: 20px; width: 20px;">&nbsp;</a> <a href="admPrdEdt.aspx?id=<%#Eval("prtguid") %>"
                            title="设置" style="background-image: url(./css/edit.png); background-repeat: no-repeat;
                            display: inline-block; height: 20px; width: 20px;">&nbsp;</a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="prtguid" HeaderText="编号" ReadOnly="true" Visible="false" />
            <asp:TemplateField HeaderText="商品" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="20%">
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
           <%-- <asp:BoundField DataField="shareurl" HeaderText="分享链接" ItemStyle-Width="20%" />--%>
            <asp:TemplateField  HeaderText="分享链接" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="20%">
              <ItemTemplate>
               <a href='<%#Eval("shareurl")%>' target="_blank"><%#Eval("shareurl")%></a>  
              </ItemTemplate>
            
            </asp:TemplateField>
            


            <asp:BoundField DataField="sharetype" HeaderText="分享方式" ItemStyle-Width="10%" />
            <asp:BoundField DataField="visitcount" HeaderText="被访问次数" ItemStyle-Width="10%" />
            <asp:BoundField DataField="successcount" HeaderText="产生销售次数" ItemStyle-Width="11%" />
            <asp:BoundField DataField="prdcount" HeaderText="产生销售件数" ItemStyle-Width="11%" />
            <asp:BoundField DataField="prdsumMoney" HeaderText="产生销售金额" ItemStyle-Width="11%" />            
       
       
        </Columns>
       
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr style="background: #507CD1; font-weight: bolder; height: 30px; color: White;
                    text-align: center;">
                    <td width="30%">
                        产品名称
                    </td>
                    <td width="15%">
                        分享链接
                    </td>
                    <td width="15%">
                        分享方式
                    </td>
                    <td width="15%">
                        被访问次数
                    </td>
                    <td width="15%">
                        产生销售次数
                    </td>
                    <td width="10%">
                        产生销售件数
                    </td>
                     <td width="10%">
                        产生销售金额
                    </td>                    
                </tr>
                <tr>
                    <td colspan="7" align="center" style="left: 40px; padding-top: 20px; border: 1px solid gray;
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>