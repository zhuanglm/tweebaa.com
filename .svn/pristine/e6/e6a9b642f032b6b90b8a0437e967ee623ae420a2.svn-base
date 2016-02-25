<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uoloadProduct.aspx.cs" Inherits="TweebaaWebApp.Product.uoloadProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>
            产品信息导入 <span style="font-size: 14px; color: Red; padding-left: 20px; font-weight: normal;">
                要求：<br />1. Excel中不允许出现空行；<br /> 2. 图片地址列和价格区间列不允许出现中文逗号和分号;
                <br />3.所有产品信息放在同一个Sheet区，命名为Sheet1，删除Excel中黄色Head列和图片，并删除其它的所有Sheet<br />
            </span>
        </h3>
        &nbsp;&nbsp;&nbsp;&nbsp;<strong>请选择导入人：</strong> &nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList
            ID="ddlUser" runat="server" Width="120" Height="25">
            <asp:ListItem Value="">--请选择--</asp:ListItem>
            <asp:ListItem Value="50ADAFF9-3F06-42DD-9A24-9000806AE2A3">李蔚</asp:ListItem>
            <asp:ListItem Value="D4BF7EB9-41F2-4D0B-B529-E6855FA23E37">李松</asp:ListItem>
            <asp:ListItem Value="C2B61B8C-9F9B-40A3-93D9-91F843D19E72">江艳</asp:ListItem>
            <asp:ListItem Value="DCD13F61-0495-46DB-835F-84E1C3450130">柳红</asp:ListItem>
            <asp:ListItem Value="96824761-38C3-4326-B6B9-72C4F632E4BF">万园园</asp:ListItem>
            <asp:ListItem Value="0BF748F5-4907-4D33-9235-12C0263D9A2F">Mac</asp:ListItem>
            <asp:ListItem Value="871516C6-7395-43E5-859A-E17645AA5799">Mindy</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;<strong>选择产品Excel：</strong> &nbsp;&nbsp;&nbsp;&nbsp;<asp:FileUpload
            ID="FileUpload1" Width="400" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="导入" Width="100" OnClick="Button1_Click" /><br />
        <br />
        <br />
        <br />
        <h3>
            产品图片导入 <span style="font-size: 14px; color: Red; padding-left: 20px; font-weight: normal;">
                要求：<br />1. 导入图片之前，将产品图片文件夹以姓名拼音缩写命名，发送给Edmund, 由Edmund将该文件夹存放在服务器上，例如：最终路径：D:\ProductImages\ydf。
                 <br />2. 导入前请检查确认产品Excel中的图片路径地址及图片名称和图片文件夹中的图片名称一致。<br />
            </span>
        </h3>
        <iframe src="http://192.168.1.10/Server/uploadExcelPic.aspx" frameborder="0" width="100%" height="500">
        </iframe>
    </div>
    <label id="labErroe" runat="server">
    </label>
    </form>
</body>
</html>
