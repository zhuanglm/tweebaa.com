﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="TweebaaWebApp.Mgr.sysManager.Manager" %>

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
        table
        {
            border: 1px solid #95B8E7;
            border-collapse: collapse;
        }
        table tr td
        {
            border: 1px solid #95B8E7;
            border-collapse: collapse;
            padding: 3px;
        }
        .title
        {
            background: 1px solid #95B8E7;
            font-weight: bold;
            color: #0e2d5f;
            width: 80px;
        }
    </style>
</head>
<body style="padding: 2px;">
    <form id="form1" runat="server">
    <asp:HiddenField ID="hidID" runat="server" />
    <input type="hidden" id="hidDataXml" value="" />
    <div>
        <table>
            <tr>
                <td class="title">
                    Login Name：
                </td>
                <td>
                    <input type="text" id="txtName" maxlength="20" runat="server" />
                </td>
                <td style="color: Red;">
                    *
                </td>
            </tr>
            <tr>
                <td class="title">
                    Login Password：
                </td>
                <td>
                    <input type="password" id="txtPwd" maxlength="20" runat="server" />
                </td>
                <td style="color: Red; width: 100px;">
                    *
                </td>
            </tr>
            <tr>
                <td class="title">
                    Admin Role：
                </td>
                <td>
                    <asp:DropDownList ID="selRole" runat="server" Width="100">
                    <asp:ListItem Value="1" Text="Super Administrator"></asp:ListItem>
                    <asp:ListItem Value="2" Text="General Administrator"></asp:ListItem>
                    </asp:DropDownList>
                   <%-- <select id="selRole" style="width: 100px;" runat="server">
                        <option value="1">Super Administrator</option>
                        <option value="2">General Administrator</option>
                    </select>--%>
                </td>
                <td style="color: Red;">
                    *
                </td>
            </tr>
            <tr>
                <td class="title">
                    Enable or Not：
                </td>
                <td>
                    <asp:DropDownList ID="selState" runat="server" Width="100">
                    <asp:ListItem Value="1" Text="Enable"></asp:ListItem>
                    <asp:ListItem Value="0" Text="Disable"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="color: Red;">
                    *
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:LinkButton ID="linkBtnRegister" runat="server" OnClientClick="javascript:return verfy()" OnClick="linkBtnRegister_Click">Registration Administrator</asp:LinkButton>
                    <asp:LinkButton ID="linkBtnSave" runat="server" OnClientClick="javascript:return _edit()" >Save Edit</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#txtName").textbox();
            $("#txtPwd").textbox();
            $("#selState").combobox();
            $("#selRole").combobox();
            $('#<%=linkBtnRegister.ClientID %>').linkbutton();
            $('#<%=linkBtnSave.ClientID %>').linkbutton();
        })
       

        function verfy() {
            var name = $("#txtName").textbox("getValue");
            var pwd = $("#txtPwd").textbox("getValue");
            if (name == null || $.trim(name) == "" || pwd == null || $.trim(pwd) == "") {
                alert("Login Name and Password cannot be blank");
                return false;
            }
            else {
                return true;
            }
        }
        function _edit() {
            if (verfy()) {
                var name = $("#txtName").textbox("getValue");
                var pwd = $("#txtPwd").textbox("getValue");
                var selRole = $('#<%=selRole.ClientID %>').combobox("getValue");
                var selState = $('#<%=selState.ClientID %>').combobox("getValue");
                var id = $("#<%=hidID.ClientID %>").val();
                var res = TweebaaWebApp.Mgr.sysManager.Manager.Save(id, name, pwd, selRole, selState).value;
                if (res == "success")
                    alert("Edit Success");
                else
                    alert("Edit Fail");
                return false;
            } else {
                return false;
            }

        }
    </script>
</body>
</html>
