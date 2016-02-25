<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proAssignSkuImage.aspx.cs" Inherits="TweebaaWebApp2.Mgr.proManager.proAssignSkuImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <title></title>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <script src="../../js/util.js" type="text/javascript"></script>
    <script src="../../js/xd.js" type="text/javascript"></script>
     <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jquery.placeholder2.js" type="text/javascript"></script>
    <script src="../../js/biaodan2.js" type="text/javascript"></script>
    <script src="../../js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/newfloat.js"></script>
    <link href="../css/mgr.css" rel="stylesheet" />
    <link href="../css/aspnetpager.css" rel="stylesheet" />
    <link href="../ui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../ui/themes/demo.css" rel="stylesheet" type="text/css" />
    <link href="../ui/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../ui/jquery.min.js" type="text/javascript"></script>
    <script src="../ui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../ui/easyloader.js" type="text/javascript"></script>
</head>
<body style="padding: 2px;">
    <form id="form1" runat="server">
    <table class="tbtable" style="width: 100%;">
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left"> Product Guid</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblProductGuid" runat="server" ></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left"> Product Name</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblProductName" runat="server" ></asp:Label></td>
            <td></td>
        </tr>
    </table>
    <table class="tbtable" style="width: 100%;">
        <tr>
        <td><asp:GridView ID="gdvImage" runat="server" HeaderStyle-BackColor="#7FFFD4" 
                HeaderStyle-ForeColor="Black" AutoGenerateColumns="false" 
                onrowdatabound="gdvImage_RowDataBound"
                onselectedindexchanged="gdvImage_SelectedIndexChanged">
            <Columns>
                <asp:ImageField DataImageUrlField="ProductImage"></asp:ImageField>
                <asp:BoundField DataField="ImageURL" HeaderText="Image URL" ItemStyle-Width="150" />
                <asp:BoundField DataField="ImageIdx" HeaderText="Image Index" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="FileGuid" HeaderText="FileGuid" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center" Visible="true" />
                <asp:BoundField DataField="ImageRuleID" HeaderText="ImageRuleID" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center" Visible="true" />
                <asp:TemplateField HeaderText="Please Select SKU" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlSKU" runat="server" ></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Button ID="btnDeleteImage" runat="server" Text="Delete"  RowIndex='<%# Container.DisplayIndex %>' CausesValidation="False" OnClick="btnDeleteImage_Click"
                        OnClientClick="javascript:return ConfirmDeleteImage();" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView></td>
        </tr>
        <tr>
            <td >
                <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="False" OnClick="btnSave_Click" OnClientClick="javascript:return CheckInput();" />
            </td>
        </tr>
        <tr>
            <td >
                <asp:FileUpload ID="fupUploadImage" runat="server" />
                &nbsp;&nbsp;Image Index: <asp:TextBox ID="txtImageIdx" runat="server" MaxLength="3" style="width:60px; text-align:right"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtImageIdx" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"  ControlToValidate="txtImageIdx"    ErrorMessage="Image Idx is a required field." ForeColor="Red"></asp:RequiredFieldValidator>
                <br /><asp:Button ID="btnUploadImage" runat="server" Text="Upload Image" OnClick="btnUploadImage_Click" />
            </td>
        </tr>

    </table>

    <script type="text/javascript">
        $(document).ready(function () {
        });

        function ConfirmDeleteImage() {
            return (confirm("Are you sure you want to delete this image?"));
        }

        function CheckInput() {
            var sSelectedRuleIDArr = [];
            var sSelectedTextArr = [];

            var gdvImageID = "<%= gdvImage.ClientID %>";
            $('#' + gdvImageID + " select[id*='ddlSKU']:input").each(function (i, myInput) {
                if (myInput != null) {
                    var iSelectedIdx = myInput.selectedIndex;
                    var sSelectedVal = myInput.options[iSelectedIdx].value;
                    var sSelectedText = myInput.options[iSelectedIdx].text;
                    sSelectedRuleIDArr.push(sSelectedVal);
                    sSelectedTextArr.push(sSelectedText);
                }
            });

            for (var i = 0; i < sSelectedRuleIDArr.length; i++) {
                for (var j = i+1; j < sSelectedRuleIDArr.length; j++) {
                    if (sSelectedRuleIDArr[i] == sSelectedRuleIDArr[j] && sSelectedRuleIDArr[i] != "-1") {
                        alert(sSelectedTextArr[i] + " is duplicated!\nYou can only assign ONE image to each SKU!");
                        return false;
                    }
                }
            }

            if (!confirm("Are you sure you want to save?")) return false;

            return true;
        }
    </script>
    </form>
</body>
</html>
