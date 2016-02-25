<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admArticleEdt.aspx.cs"  MasterPageFile="~/Manage/mstMyAdm.Master"
Inherits="TweebaaWebApp.Manage.Article.admArticleEdt" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">


    <script src="../Js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Kindeditor/kindeditor-4.1.10/kindeditor-all-min.js" type="text/javascript"></script>
    <script src="../../Kindeditor/kindeditor-4.1.10/lang/zh_CN.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
 当前位置：文章管理 》<asp:Label ID="labTitle" runat="server" Text=""></asp:Label>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
<asp:Label ID="labid" runat="server" Text="" style="display:none;"></asp:Label>
<table>

   <tr>
     <td>文章类别：</td>
     <td>
         <asp:DropDownList ID="ddlType" runat="server">
         </asp:DropDownList>
     </td>
     <td></td>
   </tr>
    <tr>
     <td>文章标题：</td>
     <td>
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        <span id="Span1" style=" color:red;">*</span>
     </td>
     <td></td>
   </tr>
   <tr>
     <td>文章状态：</td>
     <td>
       <asp:DropDownList ID="ddlState" runat="server">
                <asp:ListItem Value="1" Text="启用" Selected="True"></asp:ListItem>
                <asp:ListItem Value="0" Text="停用"></asp:ListItem>
       </asp:DropDownList>
     </td>
     <td></td>
   </tr>
   <tr>
     <td>阅读数：</td>
     <td>
        <asp:TextBox ID="txtReadCount" runat="server" Width=60></asp:TextBox>
     </td>
     <td></td>
   </tr>
   <tr>
    <tr>
     <td>内容：</td>
     <td>
         <textarea id="txtcontent" runat="server" name="content" style="width:700px;height:500px;"></textarea>
     </td>
     <td></td>
   </tr>
    <tr>
     <td>
     </td>
     <td>
         <asp:Button ID="btnAdd" runat="server" Text="添加" CssClass="btnSerch" 
             onclick="btnAdd_Click" OnClientClick="javascript:return vali()" />
         <asp:Button ID="btnEdit" runat="server" Text="修改" CssClass="btnSerch" 
             onclick="btnEdit_Click" OnClientClick="javascript:return vali()" />
     </td>
     <td></td>
   </tr>
</table>

<script type="text/javascript">

    var editor;
    KindEditor.ready(function (K) {
        editor = K.create('#<%=txtcontent.ClientID %>');
    });

    function vali() {
        var title = document.getElementById('<%=txtTitle.ClientID %>').value;
        var count = document.getElementById('<%=txtReadCount.ClientID %>').value;
        if (title == "") {
            alert('标题为必填项');
            return false;
        }
        if (editor.isEmpty()) {
            alert("内容为必填项");
            return false;
        }
        if (count == "") {
            document.getElementById('<%=txtReadCount.ClientID %>').value = "0";
        }

    }
    
</script>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>




