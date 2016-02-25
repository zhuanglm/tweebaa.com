<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadProduct.aspx.cs" Inherits="TweebaaWebApp2.Product.UploadProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Upload Message: <label id="labError" runat="server"></label><br />
        <h3>
            Upload Product Attentions<span style="font-size: 14px; color: darkblue; padding-left: 20px; font-weight: normal;"><br />
            <br/>1) Check if local images have been copied to upload/LocalImage folder.
            <br/>2) Check if the first row has been copied and 300 characters has been added into the Brief Description and Detailed Description columns.
            <br/>3) Upload will stop if the Supplier ID is blank.
            </span>
        </h3>
        
        <br />
        <asp:Button ID="btnDelete" runat="server" Text="Delete Completed Images before New Upload" OnClick="btnDelete_Click" />
        <br /><br />
        <strong>Please select the Excel you want to upload：</strong> &nbsp;&nbsp;<asp:FileUpload ID="FileUpload1" Width="400" runat="server" />
        <br /><br />Password: <asp:TextBox ID="txtPwd"  TextMode="password" runat="server"></asp:TextBox>
        <br /><br /><asp:Button ID="btnUpload" runat="server" Text="Start Upload Product" OnClick="btnUpload_Click" /><br />
        <br />
        <br />
        <h3>
            Upload Product Images<span style="font-size: 14px; color: Red; padding-left: 20px; font-weight: normal;">
            Please use this button to upload all the product images
            </span>
        </h3>
          <iframe src="UploadProductExcelPic.aspx" frameborder="0" width="100%" height="500">
        </iframe>

    </div>
    </form>
</body>
</html>



