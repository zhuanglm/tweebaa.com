﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Manage/mstMyAdm.Master" CodeBehind="admArticleType.aspx.cs" Inherits="TweebaaWebApp.Manage.Article.admArticleType" %>

<%@ Register  TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
<link href="../css/grid.css" rel="stylesheet" type="text/css" />
    <link href="../layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <script src="../Js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../layer/layer.min.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
 当前位置：文章管理 》文章类别
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
        <table style="padding: 0px; margin: 0px;">
                <tr>
                    <td>
                        类别名称：
                    </td>
                    <td>
                        <input id="txtName" type="text" class="t1" runat="server" />
                    </td> 
                    <td>状态：</td>
                    <td>
                        <asp:DropDownList ID="ddlState" runat="server">
                        <asp:ListItem Value="1" Text="启用" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="0" Text="停用"></asp:ListItem>
                        </asp:DropDownList>
                    </td>                       
                    <td>
                        创建时间：
                    </td>
                    <td>
                        从
                        <input id="txtDateStart" type="text" class="t1" runat="server" onClick="WdatePicker()" /> 到
                        <input id="txtDateEnd" type="text" class="t1" runat="server" onClick="WdatePicker()" />
                    </td>
                    <td style="padding-left: 5px; text-align: left;">
                        <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="btnSerch" 
                            onclick="btnSearch_Click" />
                            <input type="button" value="添加" class="btnSerch" onclick="openDiag('','add')" />
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
       
       <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="false" CssClass="gridData"
        CellPadding="4" GridLines="None" 
       ShowFooter="true" Width="99%" onrowcommand="gridData_RowCommand" >
        <Columns>
            <asp:TemplateField >
                <ItemTemplate>
                    <td style=" display:none;"><%#Eval("id")%></td>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="typename" HeaderText="类别名称"  />
            <asp:BoundField DataField="loginNo" HeaderText="创建人"  />
            <asp:BoundField DataField="createtime" HeaderText="创建时间" />
            <asp:TemplateField HeaderText="状态">
                <ItemTemplate>
                    <%#Eval("state").ToString().Trim()=="1"?"启用":"停用"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="修改">
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="openDiag(<%#Eval("id") %>,'edit')">修改</a>
                    <asp:LinkButton ID="linkDelete" runat="server" OnClientClick="deleteVali();" CommandArgument='<%# Eval("Id") %>' CommandName="_Delete">删除</asp:LinkButton>
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
       
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr style="background: #507CD1; font-weight: bolder; height: 30px; color: White;
                    text-align: center;">
                    <td style="display:none;">
                        
                    </td>
                    <td width="20%">
                        类别名称
                    </td>
                    <td width="15%">
                        创建人
                    </td>
                    <td width="15%">
                        状态
                    </td>
                    <td>
                        创建时间
                    </td>
                    <td>
                       修改
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

<script type="text/javascript">

    function openDiag(id, op) {
        var option = "";
        if (op == "edit") {
            option = "修改操作";
        }
        if (op == "add") {
            option = "添加操作";
        }
        var url = "admArticleTypeEdt.aspx?op=" + op + "&id=" + id;
        $.layer({
            type: 2,
            shade: [0],
            fix: false,
            title: option,
            maxmin: false,
            iframe: { src: url },
            area: ['400px', '250px'],
            close: function (index) {
               
            }
        });
    }

    function search() {
        document.getElementById('<%=btnSearch.ClientID %>').click();
    }

    function deleteVali() {
        if (confirm('确定删除该项?'))
            return true;
        else
            return false;
    }
    
</script>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>
