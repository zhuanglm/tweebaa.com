<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uoloadProduct3.aspx.cs" Inherits="TweebaaWebApp.Product.uoloadProduct3" %>

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
                要求： Excel中不允许出现空行
            </span>
        </h3>
        
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
               假如当天导入了10个Excel，请在这10个Excel都导入完成之后，再使用【导入图片】按钮
            </span>
        </h3>
        <iframe src="uploadExcelPic.aspx" frameborder="0" width="100%" height="500">
        </iframe>
    </div>
    <label id="labErroe" runat="server">
    </label>
    </form>
</body>
</html>
