<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productShareRecord.aspx.cs" 
 ValidateRequest="false" enableEventValidation="false" Inherits="TweebaaWebApp2.Mgr.productShare.productShareRecord" %>

<!DOCTYPE html>

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
                    Product Name：
                </td>
                <td style="width:120px;">
                    <input type="text" id="txtProName" maxlength="30" />
                </td>
                <td class="title">Share Type：<asp:HiddenField ID="hidShareType" runat="server" /></td>
                <td>
                    <asp:DropDownList ID="ddlShareType" runat="server" Width="120"></asp:DropDownList>
                </td>
   
                <!--td class="title" style=" width:110px;">
                    Product Categories(Level 1)： <asp:HiddenField ID="hidType" runat="server"/>
                </td>
                <td  style="width:110px;">
                    <asp:DropDownList ID="ddlTypeOne" runat="server" Width="120"></asp:DropDownList>
                </td>
                <td class="title" style=" width:110px;">
                    Product Categories(Level 2)：
                </td>
                <td style="width:110px;">
                    <asp:DropDownList ID="ddlTypeTwo" runat="server" Width="120"></asp:DropDownList>
                </td>
                <td class="title" style=" width:110px;">
                    <span style="color:red;">*</span>Product Categories(Level 3)：
                </td>
                <td style="width:110px;">
                    <asp:DropDownList ID="ddlTypeThree" runat="server" Width="120"></asp:DropDownList>
                </td-->
                <td colspan="4"></td>
            </tr>
            <tr>
                <td class="title">
                    Sharer：
                </td>
                <td style="width:120px;">
                    <input type="text" id="txtSharer" maxlength="30" />
                </td>
                <td class="title">Product Stats：<asp:HiddenField ID="hidState" runat="server" /></td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server" Width="120"></asp:DropDownList>
                </td>
                <td class="title">Share Time：</td>
                <td colspan="3">
                    From：<input type="text" id="txtStartTime"   />
                    To：<input type="text" id="txtEndTime"  /> 
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <a id="btn" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" onclick="_search()">Search</a> 
                </td>
            </tr>
        </table>
    </fieldset>

   <div style=" margin:2px;">
   <table id="dg" title="Product Share Record List" style="width:100%;height:auto"></table>
   </div>

        <script type="text/javascript">
            $(function () {
                $("#txtProName").textbox();
                $("#txtSharer").textbox();
                $('#winView').window({
                    collapsible: false,
                    minimizable: false,
                    maximizable: false,
                    modal: true
                });
                $('#winView').window('close');

/*
                $("#ddlTypeOne").combobox({
                    valueField: 'value',
                    textField: 'text',
                    data: eval(TweebaaWebApp2.Mgr.proManager.proPublicJudgeMgr.GetFirstCate().value),
                    onSelect: function (e) {
                        var selectedId = e.value;
                        $("#ddlTypeTwo").combobox("clear");
                        $("#ddlTypeThree").combobox("clear");
                        if (selectedId != "--Please Select--") {
                            var res = TweebaaWebApp2.Mgr.proManager.proPublicJudgeMgr.GetNextCate(selectedId).value;
                            if (res != "fail") {
                                $("#ddlTypeTwo").combobox("loadData", eval(res));
                                $("#<%=hidType.ClientID%>").val("").val(e.value);
                            } else {
                                $("#ddlTypeTwo").combobox("loadData", eval("[{value:'--Please Select--',text:'--Please Select--'}]"));
                                $("#ddlTypeThree").combobox("loadData", eval("[{value:'--Please Select--',text:'--Please Select--'}]"));
                            }
                        } else {
                            $("#ddlTypeTwo").combobox("loadData", eval("[{value:'--Please Select--',text:'--Please Select--'}]"));
                            $("#ddlTypeThree").combobox("loadData", eval("[{value:'--Please Select--',text:'--Please Select--'}]"));
                        }
                    }
                });
*/
/*                $("#ddlTypeTwo").combobox({
                    valueField: 'value',
                    textField: 'text',
                    onSelect: function (e) {
                        var selectedId = e.value;
                        $("#ddlTypeThree").combobox("clear");
                        if (selectedId != "--Please Select--") {
                            var res = TweebaaWebApp2.Mgr.proManager.proPublicJudgeMgr.GetNextCate(selectedId).value;
                            if (res != "fail") {
                                $("#ddlTypeThree").combobox("loadData", eval(res));
                                $("#<%=hidType.ClientID%>").val("").val(e.value);
                            } else {
                                $("#ddlTypeThree").combobox("loadData", eval("[{value:'--Please Select--',text:'--Please Select--'}]"));
                            }
                        } else {
                            $("#ddlTypeThree").combobox("loadData", eval("[{value:'--Please Select--',text:'--Please Select--'}]"));
                        }
                    }
                });
*/
                $("#txtStartTime,#txtEndTime").datebox();
                $("#txtEndTime,#txtEndTime").datebox();

                $("#ddlState").combobox({
                    valueField: 'value',
                    textField: 'text',
                    data: eval("[{value:'All',text:'All'},{value:'1',text:'Evaluation'},{value:'8',text:'Evaluation Fail'}]"),
                    onSelect: function (e) {
                        $("#<%=hidState%>").val("").val(e.value);
                    }
                });
                $("#ddlState").combobox("setValue", "All");

                $("#ddlShareType").combobox({
                    valueField: 'value',
                    textField: 'text',
                    data: eval("[" +
                        "{value:'All',text:'All'}," +
                        "{value:'facebook',text:'Facebook'}," +
                        "{value:'twitter',text:'Twitter'}," +
                        "{value:'google',text:'Google'}," +
                        "{value:'pinterest',text:'Pinterest'}," +
                        "{value:'email',text:'Email'}]"),
                    onSelect: function (e) {
                        $("#<%=hidShareType%>").val("").val(e.value);
                    }
                });
                $("#ddlShareType").combobox("setValue", "All");
            })
        </script>


        <script type="text/javascript">
            var dataGridUrl = 'productShare.ashx?action=datagrid';
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
                        { field: 'prdguid', checkbox: true },
                    //{ field: 'prdguid', title: '产品ID', width: 80, hidden: true },
                        {field: 'prdname', title: 'Product Name', width: 200 },
                        { field: 'sharetype', title: 'Share Type', width: 80 },
                        { field: 'sharer', title: 'Sharer', width: 160 },
                        { field: 'addtime', title: 'Share Time', width: 125 },
                        { field: 'visitcount', title: 'Visit Count', width: 80, align: 'right' },
                        { field: 'Success Count', title: 'Success Count', width: 110, align: 'right' },
                        { field: 'shareurl', title: 'Share URL', width: 200 }
//                        {
//                            field: '_edit', title: 'Operation', width: 150, formatter: function (value, row) {
//                                return "<a href='javascript:void(0)' onclick=_view(this) dbkey='" + row.prdguid + "'>Check</a>&nbsp;&nbsp;<a href='javascript:void(0)' dbdown='" + row.count0 + "'  dbup='" + row.count1 + "' dbproname='" + row.prdname + "' dbkey='" + row.prdguid + "' onclick=OpenReason(this)>Approved</a>&nbsp;&nbsp;<a href='javascript:void(0)' dbkey='" + row.prdguid + "' onclick=proEdit(this)>Edit</a>&nbsp;&nbsp;<a href='javascript:void(0)' dbkey='" + row.prdguid + "' onclick=proDelete(this)>Delete</a>"
//                            }
//                        }
                    ]]
                }).datagrid('getPager'); // get the pager of datagrid
            })

            function _search() {
                var proName = $("#txtProName").textbox("getValue");
                var sharer = $("#txtSharer").textbox("getValue");
                var startTime = $("#txtStartTime").datebox("getValue");
                var shareType = $("#ddlShareType").combobox("getValue");
                //var shareType = "email";
                var endTime = $("#txtEndTime").datebox("getValue");
                var state = $("#ddlState").combobox("getValue");
                
                if (shareType == "All") shareType = "";
                if (state =="All") state ="";
                
                $('#dg').datagrid('load', {
                    "proName": proName,
                    "sharer": sharer,
                    "startTime": startTime,
                    "endTime": endTime,
                    "shareType": shareType,
                    "state": state
                });
            }


	</script>
    </form>
</body>
</html>
