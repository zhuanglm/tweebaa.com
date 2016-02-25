<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadProductExcelPic.aspx.cs" Inherits="TweebaaWebApp2.Product.UploadProductExcelPic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Upload Product Images</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <%-- &nbsp;&nbsp;&nbsp;<strong>请选择导入人：</strong>--%>
     <asp:DropDownList ID="ddlUser" runat="server" Width="120" Height="25" Visible="false">
            <asp:ListItem Value="">--请选择--</asp:ListItem>
            <asp:ListItem Value="lw">李蔚</asp:ListItem>
            <asp:ListItem Value="ls">李松</asp:ListItem>
            <asp:ListItem Value="jy">江艳</asp:ListItem>
            <asp:ListItem Value="lh">柳红</asp:ListItem>
            <asp:ListItem Value="wyy">万园园</asp:ListItem>
            <asp:ListItem Value="Mac">Mac</asp:ListItem>
            <asp:ListItem Value="Mindy">Mindy</asp:ListItem>
       </asp:DropDownList>      
      <asp:Button ID="btnUpload" runat="server" OnClick ="btnUpload_Click" Text="Start Upload Product Images" /><br /><br />
         <label id="labErroe" runat="server"></label>
    </div>
    </form>
</body>
</html>