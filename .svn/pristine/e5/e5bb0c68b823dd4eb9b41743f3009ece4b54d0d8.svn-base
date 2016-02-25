<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true" CodeBehind="admPrdCateAdd.aspx.cs" Inherits="TweebaaWebApp.Manage.admPrdCateAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">  
   
    <link rel="stylesheet" type="text/css" href="css/admin.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
 当前位置：类别管理 》添加类别| <a class="aFind" href="admPrdCate2.aspx" target="_self">转至类别管理</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

      <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
     <table class="rightcontfont">
          <tr>
                <td style=" height:40px;">
                    父类名称：
                </td>
                <td>
                   <asp:DropDownList ID="parType0" runat="server" Width="237"  AutoPostBack="true"
                        onselectedindexchanged="parType_SelectedIndexChanged"></asp:DropDownList>
                   <asp:DropDownList ID="parType1" runat="server" Width="237"  AutoPostBack="true"
                        onselectedindexchanged="parType1_SelectedIndexChanged"></asp:DropDownList>
                   <%--<asp:DropDownList ID="parType2" runat="server" Width="237"></asp:DropDownList>--%>

                  <%-- <select name="pid" id="parType" runat="server"  style=" width:237px;">                        
                   </select>
                   <select name="pid" id="parType1" runat="server"  style=" width:237px;">                        
                   </select>   
                   <select name="pid" id="parType2" runat="server"  style=" width:237px;">                        
                   </select>      --%>

                </td>
            </tr>
            <tr>
                <td style=" height:40px;">
                    子类名称：
                </td>
                <td>
                    <input class="input_tx" id="txtName" type="text" runat="server" />
                </td>
            </tr>
            
            <tr>
                <td style=" height:40px;"> 
                    排序：
                </td>
                <td>
                    <input class="input_tx" id="txtOrder" type="text" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style=" text-align:right">
                  <asp:Button ID="btnAdd" runat="server" Text="添加" CssClass="btnSerch" OnClick="btnAdd_Click" />
                </td>
            </tr>
        </table>
          </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>
