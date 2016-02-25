<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="TweebaaWebApp.Mgr.userMgr.users" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
    <fieldset>
        <legend>Condition Search</legend>
        <table class="tbtable" style="width: 100%;">
            <tr>
                <td class="title" style="width: 80px;">
                    Member Name：
                </td>
                <td style="width: 120px;">
                    <input type="text" id="txtUserName" maxlength="30" />
                </td>
                <td class="title" style="width: 80px;">
                    Email：
                </td>
                <td style="width: 120px;">
                    <input type="text" id="txtEmail" maxlength="30" />
                </td>
                <td class="title" style="width: 80px;">
                    Status：
                </td>
                <td style="width: 120px;">
                    <select id="selState" style="width: 100px;">
                    </select>
                </td>
            </tr>
            <tr>
                <td class="title">
                    Registration Time：
                </td>
                <td colspan="3">
                    From：<input type="text" id="txtStartTime" />
                    To：<input type="text" id="txtEndTime" />
                </td>
                <td colspan="2">
                    <a id="btn" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'"
                        onclick="_search()">Search</a>
                </td>
            </tr>
        </table>
    </fieldset>
    <div style="margin: 2px;">
        <table id="dg" title="Member List" style="width: 100%; height: 555px">
        </table>
    </div>
    <script type="text/javascript">
            $(function () {
                $("#txtUserName").textbox();
                $("#txtEmail").textbox();
                $("#selState").combobox({
                    valueField: 'value',
                    textField: 'text',
                    data: eval(<%=_userStatus%>)
                });
                $("#txtStartTime,#txtEndTime").datebox();
            })
    </script>
    <script type="text/javascript">
                
                    var dataGridUrl = 'users.ashx?action=datagrid';
                
                    $(function () {
                        var pager = $('#dg').datagrid({
                            rownumbers: true,
                            singleSelect: false,
                            url: dataGridUrl,
                            method: 'get',
                            pagination: true,
                            columns: [[
                               // { field: 'guid', checkbox: true },
                                { field: 'guid', title: 'Product ID', width: 80, hidden: true },
                                { field: 'username', title: 'Member Name', width: 100 },
                                { field: 'gender', title: 'Gender', width: 50 },
                                { field: 'email', title: 'Email', width: 150 },
                                { field: 'phone', title: 'Contact Method', width: 80 },
                                { field: 'regtime', title: 'Registration Time', width: 80 },
                                 { field: 'tuijieemail', title: 'Referrer Email', width: 80 },
                                  { field: 'knowway', title: 'Learn From', width: 80 },
                                //{ field: 'publishgrade', title: 'Submit Level', width: 80 },
                                //{ field: 'reviewgrade', title: 'Evaluate Level', width: 80 },
                                //{ field: 'sharegrade', title: 'Share Level', width: 80 },
                                //{ field: 'publishcount', title: 'Number of Submission', width: 80 },
                                //{ field: 'reviewhcount', title: 'Number of Evaluation', width: 80},
                               // { field: 'sharecount', title: 'Number of Share', width: 80 },
                                {
                                    field: '_edit', title: 'Operation', width: 170, formatter: function (value, row) {
                                        return "<a href='javascript:void(0)' onclick=_view(this) dbkey='" + row.guid + "'>Check Details</a>&nbsp;&nbsp;<a href='javascript:void(0)' onclick=_edit(this) dbkey='" + row.guid + "'>Edit Basic Info</a>&nbsp;&nbsp;<a href='javascript:void(0)' onclick=_remove(this) dbkey='" + row.guid + "'>Remove</a>"
                                    }
                                }
                            ]]
                        }).datagrid('getPager');	// get the pager of datagrid
                    })

                    function _search() {
                        var UserName = $("#txtUserName").textbox("getValue");
                        var Email = $("#txtEmail").textbox("getValue");
                        var startTime = $("#txtStartTime").datebox("getValue");
                        var endTime = $("#txtEndTime").datebox("getValue");
                        var state = $("#selState").combobox("getValue");
                        if (state == "--Please Select--")
                            state = "";

                        $('#dg').datagrid('load', {
                            "userName": UserName,
                            "email": Email,
                            "startTime": startTime,
                            "endTime": endTime,
                            "state": state
                        });
                    }

                    function _view(obj) {
                        var key = $(obj).attr("dbkey");
                        var url = "userMgr/usersView.aspx?id="+key;
                        window.parent._addTab('Check Member Details', url);
                    }

                    function _edit(obj) {
                        var key = $(obj).attr("dbkey");
                        var url = "userMgr/usersEdit.aspx?userid=" + key;
                        
                        window.parent._addTab('Edit Member Basic Info', url);
                    }
                    function _remove(obj) {
                        if (confirm("Confirm to delete selected user?")) {
                            var key = $(obj).attr("dbkey");
                            if (key.length > 0) {
                                var res = TweebaaWebApp.Mgr.userMgr.users.DeleteUser(key).value;
                                if (res == "success") {
                                    alert("Delete Success！");
                                    _search();
                                }
                                if (res == "fail") {
                                    alert("Delete Fail！");
                                }                               
                                if (res == "error") {
                                    alert("Server Error，Approve Fail！");
                                }
                            }
                        }
                       
                       
                    }


    </script>
    </form>
</body>
</html>
