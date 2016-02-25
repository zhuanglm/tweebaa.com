<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashWithdrawMgr.aspx.cs" Inherits="TweebaaWebApp2.Mgr.CashWithdrawMgr.CashWithdrawMgr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
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

    <script src="../../Kindeditor/kindeditor-4.1.10/kindeditor-min.js" type="text/javascript"></script>
    <script charset="utf-8" src="../../Kindeditor/kindeditor-4.1.10/kindeditor.js"></script>
    <script charset="utf-8" src="../../Kindeditor/kindeditor-4.1.10/lang/zh_CN.js"></script>
    <script charset="utf-8" src="../../Kindeditor/kindeditor-4.1.10/plugins/code/prettify.js"></script>

</head>
<body style="padding:2px;">
    <form id="form1" runat="server">
        <input type="hidden" id="hidMgrConfig1" runat="server" />
        <input type="hidden" id="hidMgrConfigCount" runat="server" />
        <input type="hidden" id="hidMgrAdminid" runat="server" />
 
<fieldset>
        <legend>Condition Search</legend>
        <table class="tbtable" style="width:100%;">
            <tr>
                <td class="title" style="width:80px;">
                    User Name：
                </td>
                <td style="width:120px;">
                    <input type="text" id="txtUserName" maxlength="30" />
                </td>
                <td class="title">Status：<asp:HiddenField ID="hidStatus" runat="server" /></td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server" Width="120"></asp:DropDownList>
                </td>
                <td class="title">Request Date：</td>
                <td >
                    From：<input type="text" id="txtStartDate"   />
                    To：<input type="text" id="txtEndDate"  /> 
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <a id="btn" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" onclick="DoSearch()">Search</a> 
                </td>
            </tr>
        </table>
    </fieldset>


    <div style=" margin:2px;">
      <table id="dg" title="Cash Withdraw List" style="width:100%;height:auto"></table>
    </div>

    <script type="text/javascript">

        Init();
        DoSearch();

        function Init() {
            // text box
            $("#txtUserName").textbox();

            // date range            
            $("#txtStartDate,#txtEndDate").datebox();
            
            // status selection
            $("#ddlStatus").combobox({
                valueField: 'value',
                textField: 'text',
                data: eval("[{value:'-1',text:'--ALL--'},{value:'0',text:'Request'},{value:'1',text:'Accepted'},{value:'2',text:'Rejected'}]"),
                onSelect: function (e) {
                    $("#<%=hidStatus%>").val("").val(e.value);
                }
            });
            $("#ddlStatus").combobox("setValue", "-1");
        }

        function DoSearch() {
            if (!CheckInput()) return;
            LoadCashWithdrawList();
        }

        function LoadCashWithdrawList() {

            var sUserName = $("#txtUserName").textbox("getValue");
            
            var sStatus = $("#ddlStatus").combobox("getValue");
            if (sStatus == "-1") sStatus = "";

            var sStartDate = $("#txtStartDate").datebox("getValue");

            var sEndDate = $("#txtEndDate").datebox("getValue");

            var dataGridUrl = 'CashWithdrawHandler.ashx?action=CashWithdrawDatagrid'
                             + '&UserName=' + encodeURIComponent(sUserName)
                             + '&Status=' + sStatus
                             + '&StartDate=' + sStartDate
                             + '&EndDate=' + sEndDate;

            var pageListArr = [20, 40, 60, 80, 100];
            $(function () {
                var pager = $('#dg').datagrid({
                    rownumbers: true,
                    singleSelect: false,
                    url: dataGridUrl,
                    method: 'get',
                    pagination: true,
                    pageSize: 20,
                    pageList: pageListArr,
                    columns: [[
                    { field: 'CashWithdrawID', checkbox: true },
                    { field: 'addTime', title: 'Request Time', width: 180 },
                    { field: 'username', title: 'User Name', width: 100 },
                    { field: 'useremail', title: 'User Email', width: 200 },
                    { field: 'money', title: 'Amount (tweebucks)', width: 150, align: 'right' },
                    { field: 'state', title: 'Status', width: 100,
                        formatter: function (value, row) {
                            if (value == 0) return 'Request';
                            else if (value == 1) return 'Accepted';
                            else if (value == 2) return 'Rejected';
                        }
                    },
                    {
                        field: '_edit', title: 'Operation', width: 250, formatter: function (value, row) {
                            var sAccept = "<a href='javascript:void(0)' onclick=DoAccept(this) dbkey='" + row.id + "'>Accept</a>&nbsp;&nbsp;";
                            var sReject = "<a href='javascript:void(0)' onclick=DoReject(this) dbkey='" + row.id + "'>Reject</a>&nbsp;&nbsp;";
                            var sRequest = "<a href='javascript:void(0)' onclick=DoRequest(this) dbkey='" + row.id + "'>Request</a>&nbsp;&nbsp;";

                            if (row.state == 0)
                                return sAccept + sReject;
                            else if (row.state == 1)
                                return "";
                            else if (row.state == 2)
                                return sRequest;
                        }
                    }
                ]]
                 }).datagrid('getPager'); // get the pager of datagrid
             })
         }

         function DoAccept(obj) {
             var sID = $(obj).attr("dbkey");

             if (!confirm("Are you sure you want to accepet?")) return;
             var res = TweebaaWebApp2.Mgr.CashWithdrawMgr.CashWithdrawMgr.Accept(sID);
             LoadCashWithdrawList()
         }

         function DoReject(obj) {
             var sID = $(obj).attr("dbkey");

             if (!confirm("Are you sure you want to reject?")) return;
             var res = TweebaaWebApp2.Mgr.CashWithdrawMgr.CashWithdrawMgr.Reject(sID);
             LoadCashWithdrawList()
         }

         function DoRequest(obj) {
             var sID = $(obj).attr("dbkey");

             if (!confirm("Are you sure you want to put it back to request?")) return;
             var res = TweebaaWebApp2.Mgr.CashWithdrawMgr.CashWithdrawMgr.Request(sID);
             LoadCashWithdrawList()
         }

         function CheckInput() {
            var sStartDate = $("#txtStartDate").datebox("getValue");
            var sEndDate = $("#txtEndDate").datebox("getValue");
            if (sStartDate != "") {
                if (!IsDate(sStartDate)) {
                    alert("Please enter a valid start date!");
                    $("#txtStartDate").focus();
                    return false;
                }
            }
            if (sEndDate != "") {
                if (!IsDate(sEndDate)) {
                    alert("Please enter a valid end date!");
                    $("#txtEndDate").focus();
                    return false;
                }
            }
            return true;
        }

        function IsDate(s) {
            if (s.length != 10) return false;
            if (isNaN(Date.parse(s))) return false;
            return true;
        }
	</script>
    </form>
</body>
</html>

