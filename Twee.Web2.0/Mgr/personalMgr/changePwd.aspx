<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changePwd.aspx.cs" Inherits="TweebaaWebApp2.Mgr.personalMgr.changePwd" %>

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
            width:135px;
            border-collapse: collapse;
            padding: 3px;
        }
        .title
        {
            background: 1px solid #95B8E7;
            font-weight: bold;
            color: #0e2d5f;
            width: 200px;
        }
    </style>
</head>
<body style="padding: 2px;">
    <form id="form1" runat="server">
    <div>
        <table>
            
            <tr>
                <td class="title">
                    Login Password：
                </td>
                <td>
                    <input type="password" id="txtPwd1" maxlength="20" runat="server" />
                </td>
                <td style="color: Red; width: 100px;">
                    *
                </td>
            </tr>
             <tr>
                <td class="title">
                    Re-enter Password：
                </td>
                <td>
                    <input id="txtPwd2" name="rpwd" type="password" class="easyui-validatebox" required="required" validType="equals['#txtPwd1']" />
                </td>
                <td style="color: Red; width: 100px;">
                    *
                </td>
            </tr>
            
            <tr>
                <td colspan="3">
                    <asp:LinkButton ID="linkBtnSave" runat="server" OnClientClick="javascript:return _edit(this)" >Save Edit</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
           
            $("#txtPwd1").textbox();
            $("#txtPwd2").textbox();
            
            $('#<%=linkBtnSave.ClientID %>').linkbutton();
            // extend the 'equals' rule
            $.extend($.fn.validatebox.defaults.rules, {
                equals: {
		            validator: function(value,param){
			            return value == $(param[0]).val();
		            },
		            message: 'Field do not match.'
                }
            });

        })
       

        function verfy() {
            
            var pwd = $("#txtPwd1").textbox("getValue");
            
            if (pwd == null || $.trim(pwd) == "") {
                alert("Login Password cannot be blank");
                return false;
            }
            else {
                return true;
            }
        }

        function _edit() {
            if (verfy()) {
                var pwd = $("#txtPwd1").textbox("getValue");
                
                var res = TweebaaWebApp2.Mgr.personalMgr.changePwd.Save(pwd).value;
                if (res == "success") {
                    alert("Edit Success");
                    return true;
                }
                else {
                    alert("Update Fail");
                    return false;
                }
            } else {
                return false;
            }

        }

    </script>
</body>
</html>
