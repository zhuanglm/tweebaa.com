<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegCount.aspx.cs" Inherits="TweebaaWebApp.User.UserRegCount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    User Daily Registration Count ( Total: <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;Activated Total: <asp:Label ID="lblActivatedTotal" runat="server" Text=""></asp:Label> )
    <asp:GridView ID="gvwUserRegCount" runat="server" AutoGenerateColumns ="false" AllowPaging="false" AllowSorting="true">
    <Columns>
        <asp:BoundField DataField="Date" HeaderText="Date" 
                    DataFormatString="{0:MM'/'dd'/'yyyy}"  HtmlEncode="false" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundField DataField="Count" HeaderText="Count" HtmlEncode="false" ItemStyle-HorizontalAlign="Right" />
    </Columns>
    </asp:GridView>
    </form>
</body>
</html>
