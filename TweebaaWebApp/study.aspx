<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="study.aspx.cs" Inherits="TweebaaWebApp.study" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    江西物流：<br />
       重量： <asp:TextBox ID="txt1" runat="server"></asp:TextBox>克&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       每克续重费用： <asp:TextBox ID="txt2" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       物流费总计： <asp:TextBox ID="txt3" runat="server"></asp:TextBox>
       
        <asp:Button ID="btn1" runat="server"  OnClick="btn1_click" Width="100" Text="江西"  /><br /><br />

      深圳物流：<br />
       重量： <asp:TextBox ID="txt11" runat="server"></asp:TextBox>克&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;        
       每克费用： <asp:TextBox ID="txt22" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
       物流费总计： <asp:TextBox ID="txt33" runat="server"></asp:TextBox>

       <asp:Button ID="btn2" runat="server"  OnClick="btn2_click" Width="100" Text="深圳" />
    </div>
    </form>
</body>
</html>
