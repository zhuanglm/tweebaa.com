<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admArticleTypeEdt.aspx.cs" Inherits="TweebaaWebApp.Manage.Article.adminArticleTypeEdt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main_c">
    <asp:Label ID="labId" runat="server" Text="" Visible="false"></asp:Label>
      <table>
          <tr>
             <td>类别名称：</td>
             <td>
                 <asp:TextBox ID="txtTypeName" runat="server"></asp:TextBox>
             </td>
             <td>
                 <span id="tip" style=" color:red;">*</span>
             </td>
          </tr>
          <tr>
             <td>状态</td>
             <td>
                 <asp:DropDownList ID="ddlState" runat="server">
                        <asp:ListItem Value="1" Text="启用" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="0" Text="停用"></asp:ListItem>
                 </asp:DropDownList>
             </td>
             <td></td>
          </tr>
          <tr>
             <td>
                 <asp:Button ID="btnSave" runat="server" Text="修改" CssClass="btnSerch"  OnClientClick="javascript:return vali();"
                     onclick="btnSave_Click"  />
                 <asp:Button ID="btnAdd" runat="server" Text="添加" CssClass="btnSerch" OnClientClick="javascript:return vali();"
                     onclick="btnAdd_Click"  />
             </td>
             <td></td>
             <td></td>
          </tr>
      </table>
      </div>
    </form>
    <script type="text/javascript">
        function vali() {
            var name = document.getElementById('<%=txtTypeName.ClientID %>').value;
            if (name == "") {
                alert("类别名称为必填");
                return false;
            }
        }
        
    </script>
</body>
</html>



