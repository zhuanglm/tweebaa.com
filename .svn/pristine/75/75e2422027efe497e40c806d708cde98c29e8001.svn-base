<%@ Page Title=""  Language="C#"   AutoEventWireup="true"
    CodeBehind="admOrderConfirm.aspx.cs" Inherits="TweebaaWebApp2.Mgr.orderMgr.admOrderConfirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .body
        {
            text-align: center;
        }
        .btn
        {
            height: 20px;
            width: 35px;
        }
    </style>
</head>
<body class="body">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div>
                <div style="padding-top: 10px; text-align: center">
                    <div style="float: left; vertical-align: top; margin-left: 80px; margin-top: 0px;">
                        <img src="../images/confirm.gif" style="vertical-align: middle; border: 0;" />&nbsp;&nbsp;
                        <asp:Label ID="labConfirm" runat="server"></asp:Label>
                    </div>
                    <%--<div style=" float:left; vertical-align:bottom; margin-top:7px; margin-left:20px;" >--%>
                    <%--</div>--%>
                </div>
                <br />
                <div style="text-align: center">
                    <asp:Button ID="btn_ok" runat="server" Text="Confirm" OnClick="btn_ok_Click" CssClass="btn" />
                    <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="btn" Visible="false" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
