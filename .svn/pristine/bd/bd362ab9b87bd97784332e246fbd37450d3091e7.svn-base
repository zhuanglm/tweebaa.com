<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admArticle.aspx.cs" MasterPageFile="~/Manage/mstMyAdm.Master"
    Inherits="TweebaaWebApp.Manage.Article.admArticle" %>

<%@ Register TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link href="../css/grid.css" rel="stylesheet" type="text/css" />
    <link href="../layer/skin/layer.css" rel="stylesheet" type="text/css" />
    <script src="../Js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../layer/layer.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
    当前位置：文章管理 》文章内容
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <table style="padding: 0px; margin: 0px; width:98%">
        <tr>
            <td style=" width:100px; text-align:left;">
                文章类别：
            </td>
            <td style=" width:120px;">
                <asp:DropDownList ID="ddlType" runat="server">
                </asp:DropDownList>
            </td>
            <td style=" width:100px;text-align:left;">
                文章标题：
            </td>
            <td style=" width:120px;">
                <input id="txtName" type="text" class="t1" runat="server" />
            </td>
            <td style=" width:100px;text-align:left;">
                文章状态：
            </td>
            <td style=" width:120px;">
                <asp:DropDownList ID="ddlState" runat="server">
                    <asp:ListItem Value="1" Text="启用" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="0" Text="停用"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                创建时间：
            </td>
            <td colspan="3">
                从
                <input id="txtDateStart" type="text" class="t1" runat="server" onclick="WdatePicker()" />
                到
                <input id="txtDateEnd" type="text" class="t1" runat="server" onclick="WdatePicker()" />
            </td>

            <td colspan=2 style="padding-left: 5px; text-align: left;">
                <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="btnSerch" OnClick="btnSearch_Click" />
                <input type="button" value="添加" class="btnSerch" onclick="window.location.href='admArticleEdt.aspx?op=add'" />
                <asp:Button ID="btnDeleteAll" runat="server" Text="删除选中" CssClass="btnSerch" Width="80"
                    OnClientClick="javascript:return deleteAll()" OnClick="btnDeleteAll_Click" />
                <input type="hidden" runat="server" id="delids" />
            </td>
            <td>
            </td>
        </tr>
    </table>
    <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="false" CssClass="gridData"
        CellPadding="4" GridLines="None" ShowFooter="true" Width="99%" OnRowCommand="gridData_RowCommand">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input type="checkbox" name="BoxIdAll" id="BoxIdAll" onclick="onclicksel();" />
                </HeaderTemplate>
                <ItemTemplate>
                    <input id="BoxId" name="BoxId" class="del" value='<%#(Convert.ToString(Eval("id")))%>'
                        type="checkbox" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="title" HeaderText="文章标题" />
            <asp:BoundField DataField="typename" HeaderText="文章类别" />
            <asp:BoundField DataField="loginNo" HeaderText="创建人" />
            <asp:BoundField DataField="createtime" HeaderText="创建时间" />
            <asp:TemplateField HeaderText="状态">
                <ItemTemplate>
                    <%#Eval("state").ToString().Trim()=="1"?"启用":"停用"%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="readcount" HeaderText="阅读数" />
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <a href="admArticleEdt.aspx?op=view&id=<%#Eval("id") %>">查看</a> <a href="admArticleEdt.aspx?op=edit&id=<%#Eval("id") %>">
                        修改</a>
                    <asp:LinkButton ID="linkDelete" runat="server" OnClientClick="deleteVali();" CommandArgument='<%# Eval("Id") %>'
                        CommandName="_Delete">删除</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr style="background: #507CD1; font-weight: bolder; height: 30px; color: White;
                    text-align: center;">
                    <td style="display: none;">
                    </td>
                    <td width="20%">
                        文章类别
                    </td>
                    <td width="15%">
                        文章标题
                    </td>
                    <td width="15%">
                        创建人
                    </td>
                    <td>
                        创建时间
                    </td>
                    <td>
                        状态
                    </td>
                    <td>
                        阅读数
                    </td>
                    <td>
                        操作
                    </td>
                </tr>
                <tr>
                    <td colspan="9" align="center" style="left: 40px; padding-top: 20px; border: 1px solid gray;
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
    <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
        runat="server" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
        PrevPageText="上一页" ShowCustomInfoSection="Left" showinputbox="Never" OnPageChanging="AspNetPager1_PageChanging"
        CustomInfoTextAlign="Left" LayoutType="Table">
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

        function onclicksel() {
            var chkobj = document.getElementById("BoxIdAll");
            if (chkobj.checked == true) {
                selAll();
            }
            else {
                removeAll();
            }
        }

        function selAll() {
            var selobj = document.getElementsByName("BoxId");
            for (var i = 0; i < selobj.length; i++) {
                if (!selobj[i].disabled) {
                    selobj[i].checked = true;
                }
            }
        }

        function removeAll() {
            var selobj = document.getElementsByName("BoxId");
            for (var i = 0; i < selobj.length; i++) {
                selobj[i].checked = false;
            }
        }

        function deleteAll() {
            $("#<%=delids.ClientID %>").val('');
            var ids = '';
            $(".del").each(function () {
                if ($(this).attr('checked') == "checked") {
                    ids += ',' + $(this).val();
                }
            });
            if (ids == '') {
                alert('请至少选中一项');
                return false;
            }
            $("#<%=delids.ClientID %>").val(ids);
            alert($("#<%=delids.ClientID %>").val());
            return true;
        }

        $(function () { $("#<%=delids.ClientID %>").val(''); })


    
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>
