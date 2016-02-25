<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usersEdit.aspx.cs" Inherits="TweebaaWebApp.Mgr.userMgr.usersEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
    <table class="tbtable" style="width:450px;">
                    <tr>
                        <td class="title" style="width: 100px;">Member Name：
                        </td>
                        <td style="width: 250px;">
                            <input type="hidden" id="userid" value="<%=_userId %>" />
                            <input id="labName" type="text" class="easyui-textbox" runat="server" />
                    </tr>
                    <tr>
                        <td class="title" style="width: 100px;">Email：
                        </td>
                        <td style="width: 180px;">
                            <input type="text" class="easyui-textbox" id="labEmail" runat="server" />

                        </td>
                    </tr>
           <tr>
                        <td class="title" style="width: 100px;">Password：
                        </td>
                        <td style="width: 180px;">
                            <input id="pwd" style="width:100px;" type="password" class="easyui-textbox" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="title" style="width: 100px;">Gender：
                        </td>
                        <td style="width: 180px;">
                            <select id="selSex" style="width:80px;"></select>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="title" style="width: 100px;">Contact Method：
                        </td>
                        <td style="width: 180px;">
                            <input type="text" class="easyui-textbox" id="labPhone" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="title" style="width: 100px;">Date of Birth：
                        </td>
                        <td style="width: 180px;">
                            <input type="text"  id="labBirthday" runat="server" />
                        </td>
                    </tr>
        <tr>
            <td colspan="2">
                <a id="A1" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="_save()">Save</a> 
            </td>
        </tr>
                </table>
        <script type="text/javascript">
            $(function () {
                $("#labBirthday").datebox();
                $("#selSex").combobox({
                    valueField: 'value',
                    textField: 'text',
                    data: eval(<%=_sex%>)
                });
            })

            function _save() {
                
                var id = $("#userid").val();
                var name = $("#labName").textbox("getValue");
                var Email = $("#labEmail").textbox("getValue");
                var pwd = $("#pwd").textbox("getValue");
                var Phone = $("#labPhone").textbox("getValue");
                var Birthday = $("#labBirthday").datebox("getValue");
                var sex = $("#selSex").combobox("getValue");
                if (sex == "--Please Select--")
                    sex = "";
                if (name == null || $.trim(name) == "") {
                    alert('The above field is required！'); return;
                }
                if (Email == null || $.trim(Email) == "") {
                    alert('The above field is required！'); return;
                }
                if (pwd == null || $.trim(pwd) == "") {
                    alert('The above field is required！'); return;
                }
                if (Phone == null || $.trim(Phone) == "") {
                    alert('The above field is required！'); return;
                }
                if (Birthday == null || $.trim(Birthday) == "") {
                    alert('The above field is required！'); return;
                }
                if (sex == null || $.trim(sex) == "") {
                    alert('The above field is required！'); return;
                }
                //string id, string name, string sex, string phone, string birthday, string pwd,string email
                var res = TweebaaWebApp.Mgr.userMgr.usersEdit.userSave(id, name, sex, Phone, Birthday, pwd, Email).value;
                if (res == "success") {
                    alert('Edit Success');
                } else {
                    alert('Edit Fail');
                }
            }


        </script>

        <%=_setSex %>

    </form>
</body>
</html>
