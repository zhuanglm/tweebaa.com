<%@ Page Title=""  Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true" CodeBehind="admPrdReviewMain.aspx.cs" Inherits="TweebaaWebApp2.Manage.admPrdReviewMain" %>

<%@ Register  TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
<link href="css/grid.css" rel="stylesheet" type="text/css" />
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
当前位置：产品评审 》评审记录
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
  <table style="padding: 0px; margin: 0px;">
        <tr>
            <td>
                产品名称：
            </td>
            <td>
                <input id="txtName" type="text" class="t1" runat="server" />
            </td>
            <%-- <td>
                评审者：
            </td>
            <td>
                <input id="txtUser" type="text" class="t1" runat="server" />
            </td>--%>
            <td>
                评审类型：
            </td>
            <td>
                <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="false" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                    <asp:ListItem Value="">全部</asp:ListItem>
                    <asp:ListItem Value="0">支持</asp:ListItem>
                    <asp:ListItem Value="1">反对</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                评审时间：
            </td>
            <td>
                从
                <input id="txtDate1" type="text" class="t1" runat="server" onclick="WdatePicker()"  />到
                <input id="txtDate2" type="text" class="t1" runat="server" onclick="WdatePicker()"  />
            </td>
            <td style="padding-left: 5px; text-align: left;">
                <input type="button" id="btnSerch" runat="server" value="搜索" class="btnSerch" onserverclick="btnSerch_Click" />
                
            </td>
            <td>
            </td>
        </tr>
    </table>  
<asp:GridView ID="gridData" runat="server" AutoGenerateColumns="false" CssClass="gridData"
    CellPadding="4" GridLines="None" 
    EmptyDataText="暂无该数据"  Width="99%" >
    <Columns>
        <asp:TemplateField HeaderText="操作" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="12%" Visible="false" >
            <ItemTemplate>          
                <a href="admPrdReview.aspx?id=<%#Eval("prtguid")%>" title="评审详情" style="background-image: url(./css/xiangqing.png);
                    background-repeat: no-repeat; display: inline-block; height: 20px; width: 20px;">
                    &nbsp;</a> <a href="admPrdEdt.aspx?id=<%#Eval("prtguid") %>" title="设置" style="background-image: url(./css/edit.png);
                        background-repeat: no-repeat; display: inline-block; height: 20px; width: 20px;">
                        &nbsp;</a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="prdguid" HeaderText="编号" ReadOnly="true" Visible="false" />
 
        <asp:TemplateField HeaderText="商品" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="20%">
            <ItemTemplate>
                <div style="float: left; width: 100%;">
                    <div style="float: left; width: 30%;">
                        <a href="">
                            <%--<img src="../<%#Eval("fileurl") %>" alt="<%#Eval("name") %>" width="50px" height="50px" />--%>
                        </a>
                    </div>
                    <div style="float: left; padding-left: 0px; padding-top: 10px; width: 70%;">
                        <%#Eval("name")%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="username" HeaderText="评审用户" ItemStyle-Width="15%" />     
        <asp:TemplateField HeaderText="评审类型" ItemStyle-Width="15%">
         <ItemTemplate>
          <%#GetType(Eval("cmdtype"))%>
         </ItemTemplate>        
        </asp:TemplateField>
        <asp:BoundField DataField="cmdtxt" HeaderText="内容" ItemStyle-Width="35%" />
        <asp:BoundField DataField="edttime" HeaderText="评审时间" ItemStyle-Width="15%" />
       
    </Columns>
    <EmptyDataTemplate>
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr style="background: #507CD1; font-weight: bolder; height: 30px; color: White;
                text-align: center;">
                <td width="20%">
                     商品
                </td>
                <td width="10%">
                    评审用户
                </td>
                <td width="8%">
                    评审类型
                </td>
                <td width="8%">
                    内容
                </td>
                <td width="8%">
                    评审时间
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
    <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator"   CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" 
FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"   PrevPageText="上一页"  ShowCustomInfoSection="Left" 
ShowInputBox="Never" OnPageChanging="AspNetPager1_PageChanging"   CustomInfoTextAlign="Left" LayoutType="Table"  >
</webdiyer:AspNetPager>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>
