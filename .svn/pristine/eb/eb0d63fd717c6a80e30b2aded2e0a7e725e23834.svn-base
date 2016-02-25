<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proCateAddMgr.aspx.cs" Inherits="TweebaaWebApp.Mgr.proTypeMgr.proCateAddMgr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../ui/themes/demo.css" rel="stylesheet" type="text/css" />
    <link href="../ui/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../ui/jquery.min.js" type="text/javascript"></script>
    <script src="../ui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../ui/easyloader.js" type="text/javascript"></script>
    <style type="text/css">
    table{ border:1px solid #95B8E7; border-collapse:collapse;}
    table tr td{ border:1px solid #95B8E7; border-collapse:collapse; padding:3px;}
    .title{ background:1px solid #95B8E7; font-weight:bold;color:#0e2d5f;}
    </style>
</head>
<body style=" padding:2px; ">
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>

        <table>
            <tr>
               <td class="title">Main Category:</td>
               <td><asp:DropDownList ID="parType0" runat="server" Width="200"  AutoPostBack="true"  Height="20"
                        onselectedindexchanged="parType_SelectedIndexChanged"></asp:DropDownList>
                   </td>
            </tr>
             <tr>
               <td class="title"></td>
               <td><asp:DropDownList ID="parType1" runat="server" Width="200"  AutoPostBack="true" Height="20"
                        onselectedindexchanged="parType1_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
             <tr>
               <td class="title">Sub-Category：</td>
               <td><input  id="txtName" type="text" runat="server"  /></td>
            </tr>
             <tr>
               <td class="title">Order：</td>
               <td><input  id="txtOrder" type="text" runat="server"  /></td>
            </tr>
             <tr>
               <td class="title"></td>
               <td>
                   <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add Category" />
               </td>
            </tr>
        </table>
       </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
