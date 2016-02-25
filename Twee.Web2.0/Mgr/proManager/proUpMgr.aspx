﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proUpMgr.aspx.cs" Inherits="TweebaaWebApp2.Mgr.proManager.proUpMgr" %>

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
<body style="padding:2px;">
    <form id="form1" runat="server">
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
                <td class="title" style=" width:110px;">
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
                </td>
            </tr>
            <tr>
                <td class="title">
                    Suggester：
                </td>
                <td>
                    <input type="text" id="txtProMan" />
                </td>
                <td class="title">Added Status：<asp:HiddenField ID="hidState" runat="server" /></td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server" Width="120"></asp:DropDownList>
                </td>
                <td class="title">Upload Status：</td>
                <td colspan="3">
                    From：<input type="text" id="txtStartTime"   />
                    To：<input type="text" id="txtEndTime"  /> 
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <a id="btn" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" onclick="_search()">Search</a> 
                    <a id="A1" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="passAll()" style=" display:none;">Batch Approve and Add</a> 
                </td>
            </tr>
        </table>
    </fieldset>

   <div style=" margin:2px;">
        <table id="dg" title="Product Evaluation List" style="width:100%;height:auto"></table>
   </div>

        <div id="winView" title="Disapprove Reason">
                   <table id="sonTable" class="tbtable" style="width:300px;">
                       <tr class="head">
                           <td class="title" style=" width:80px;">Product Name：</td>
                           <td><input type="text" readonly="readonly" id="reasonProName" /><input type="hidden" id="reasonProid" /></td>
                       </tr>
                       <tr>
                           <td class="title"><span style="color:red;">*</span>Reason：</td>
                           <td>
                               <textarea style="width:200px; height:100px; vertical-align:top;" id="nopassReason" maxlength="200"></textarea>
                           </td>
                       </tr>
                       <tr>
                           <td colspan="2">
                               <a href="javascript:void(0)" onclick="noPassSave()" class="easyui-linkbutton" data-options="iconCls:'icon-save'">保存</a>
                           </td>
                       </tr>
                   </table>
             </div>

        <script type="text/javascript">
            $(function () {
                $("#txtProName").textbox();
                $("#txtProMan").textbox();
                $('#winView').window({
                    collapsible: false,
                    minimizable: false,
                    maximizable: false,
                    modal: true
                });
                $('#winView').window('close');

                $("#ddlTypeOne").combobox({
                    valueField: 'value',
                    textField: 'text',
                    data: eval(TweebaaWebApp2.Mgr.proManager.proUpMgr.GetFirstCate().value),
                    onSelect: function (e) {
                        var selectedId = e.value;
                        $("#ddlTypeTwo").combobox("clear");
                        $("#ddlTypeThree").combobox("clear");
                        if (selectedId != "-1") {
                            var res = TweebaaWebApp2.Mgr.proManager.proUpMgr.GetNextCate(selectedId).value;
                            if (res != "fail") {
                                $("#ddlTypeTwo").combobox("loadData", eval(res));
                                $("#<%=hidType.ClientID%>").val("").val(e.value);
                            } else {
                                $("#ddlTypeTwo").combobox("loadData", eval("[{value:'-1',text:'--ALL--'}]"));
                                $("#ddlTypeThree").combobox("loadData", eval("[{value:'-1',text:'--ALL--'}]"));
                            }
                        } else {
                            $("#ddlTypeTwo").combobox("loadData", eval("[{value:'-1',text:'--ALL--'}]"));
                            $("#ddlTypeThree").combobox("loadData", eval("[{value:'-1',text:'--ALL--'}]"));
                        }
                        $("#ddlTypeTwo").combobox("setValue", "-1");
                        $("#ddlTypeThree").combobox("setValue", "-1");
                    }
                });
                $("#ddlTypeTwo").combobox({
                    valueField: 'value',
                    textField: 'text',
                    data: eval("[{value:'-1',text:'--ALL--'}]"),
                    onSelect: function (e) {
                        var selectedId = e.value;
                        $("#ddlTypeThree").combobox("clear");
                        if (selectedId != "-1-") {
                            var res = TweebaaWebApp2.Mgr.proManager.proUpMgr.GetNextCate(selectedId).value;
                            if (res != "fail") {
                                $("#ddlTypeThree").combobox("loadData", eval(res));
                                $("#<%=hidType.ClientID%>").val("").val(e.value);
                            } else {
                                $("#ddlTypeThree").combobox("loadData", eval("[{value:'-1',text:'--ALL--'}]"));
                            }
                        } else {
                            $("#ddlTypeThree").combobox("loadData", eval("[{value:'-1',text:'--ALL--'}]"));
                        }
                        $("#ddlTypeThree").combobox("setValue", "-1");
                    }
                });
                $("#ddlTypeThree").combobox({
                    valueField: 'value',
                    textField: 'text',
                    data: eval("[{value:'-1',text:'--ALL--'}]"),
                    onSelect: function (e) {
                        var selectedId = e.value;
                        $("#<%=hidType.ClientID%>").val("").val(e.value);
                    }
                });
                $("#ddlTypeOne").combobox("setValue", "-1");
                $("#ddlTypeTwo").combobox("setValue", "-1");
                $("#ddlTypeThree").combobox("setValue", "-1");

                $("#txtStartTime,#txtEndTime").datebox();

                $("#ddlState").combobox({
                    valueField: 'value',
                    textField: 'text',
                    data: eval("[{value:'-1',text:'--ALL--'},{value:'6',text:'上架中'},{value:'10',text:'已拒绝上架'}]"),
                    onSelect: function (e) {
                        $("#<%=hidType%>").val("").val(e.value);
                    }
                });
                $("#ddlState").combobox("setValue", "-1");


            })
        </script>

        <script type="text/javascript">
            var dataGridUrl = 'proPublicJudgeMgr.ashx?action=upsaledatagrid';
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
                        //{ field: 'prdguid', title: 'Product ID', width: 80, hidden: true },
                        { field: 'prdname', title: 'Product Name', width: 100 },
                        { field: 'ranking', title: 'Ranking', width: 60, align: 'right' },
                        { field: 'prdcate', title: 'Product Categories', width: 100 },
                        //{ field: 'estimateprice', title: 'Estimate Price', width: 80 },
                        { field: 'saleprice', title: 'Test-Sale Price', width: 80, align:'right' },
                        { field: 'count', title: 'Sales', width: 80, align: 'right' },
                        { field: 'saletotal', title: 'Total Sales Amount', width: 80, align: 'right' },
                         { field: 'presaleforward', title: 'Test-Sale Target', width: 80 },
                        //{ field: 'count1', title: 'Number of Rejects', width: 80 },
                        { field: 'wnstat', title: 'Added Status', width: 80 },
                        { field: 'username', title: 'Suggester', width: 100 },
                        { field: 'addtime', title: 'Suggest Time', width: 100 },
                        { field: 'stateremark', title: 'Evaluation Reason', width: 100 },
                        {
                            field: '_edit', title: 'Operation', width: 350, formatter: function (value, row) {
                                return "<a href='javascript:void(0)' onclick=_view(this) dbkey='" + row.prdguid + "'>Check</a>&nbsp;&nbsp;<a href='javascript:void(0)'  dbkey='" + row.prdguid + "' onclick=passSingle(this)>Approve to add</a>&nbsp;&nbsp;<a href='javascript:void(0)' dbkey='" + row.prdguid + "' dbproname='" + row.prdname + "' onclick=noPass(this)>Reject to add</a>&nbsp;&nbsp;<a href='javascript:void(0)' dbkey='" + row.prdguid + "' onclick=proEdit(this)>Edit</a>"
                            }
                        }
                    ]]
                }).datagrid('getPager');	// get the pager of datagrid
            })

            function _search() {
                var proName = $("#txtProName").textbox("getValue");
                var txtProMan = $("#txtProMan").textbox("getValue");
                var startTime = $("#txtStartTime").datebox("getValue");
                var endTime = $("#txtEndTime").datebox("getValue");

                // allow to search multiple categories
                var cate = $("#<%=hidType.ClientID%>").val();
                var cate1 = $("#ddlTypeOne").combobox("getValue");
                var cate2 = $("#ddlTypeTwo").combobox("getValue");
                var cate3 = $("#ddlTypeThree").combobox("getValue");
                if (cate == "-1") cate = "";
                if (cate1 == "-1") cate1 = "";
                if (cate2 == "-1") cate2 = "";
                if (cate3 == "-1") cate3 = "";
                cate = cate1 + "," + cate2 + "," + cate3;

                var state = $("#ddlState").combobox("getValue");
                if (state == "-1")
                    state = "";

                $('#dg').datagrid('load', {
                    "proName": proName,
                    "proUser": txtProMan,
                    "startTime": startTime,
                    "endTime": endTime,
                    "cate": cate,
                    "state": state
                });
            }

            function passAll() {
                if (confirm("Confirm to approve and add selected products？")) {
                    var checkedItems = $('#dg').datagrid('getChecked');
                    if (checkedItems.length == 0) {
                        alert("Please select at least one");
                    } else {
                        var proids = '';
                        $.each(checkedItems, function (index, item) {
                            proids += "," + item.prdguid;
                        });
                        if (proids.length > 0) {
                            var res = TweebaaWebApp2.Mgr.proManager.proUpMgr.PassAll(proids).value;
                            if (res == "success") {
                                alert("Evaluate Success！");
                                _search();
                            }
                            if (res == "fail") {
                                alert("Evaluate Fail！");
                            }
                            if (res == "error") {
                                alert("Server Issue，Evaluate Fail！");
                            }
                        }
                    }
                }
            }

            function passSingle(obj) {
                if (confirm("Confirm to add selected products？")) {
                    var proid = $(obj).attr("dbkey");
                    if (proid.length > 0) {
                        var res = TweebaaWebApp2.Mgr.proManager.proUpMgr.PassSingle(proid).value;
                        if (res == "success") {
                            alert("Evaluate Success！");
                            _search();
                        }
                        if (res == "fail") {
                            alert("Evaluate Fail！");
                        }
                        if (res == "error") {
                            alert("Server Issue，Evaluate Fail！");
                        }
                    }
                }
            }

            function noPass(obj) {
                var proid = $("#reasonProid");
                var proname = $("#reasonProName");
                var proid = $("#reasonProid");
                proid.val('').val($(obj).attr("dbkey"));
                proname.val('').val($(obj).attr("dbproname"));
                $("#nopassReason").val('');
                $('#winView').window('open');
            }

            function noPassSave() {
                var proid = $("#reasonProid").val();
                var reason = $("#nopassReason").val();
                if (proid == null || reason == null || proid == "" || $.trim(reason) == "") {
                    alert("Please input Reason");
                } else {
                    var res = TweebaaWebApp2.Mgr.proManager.proUpMgr.NoPass(proid, reason).value;
                    if (res == "success") {
                        alert("Operation Success");
                        $('#winView').window('close');
                        _search();
                    } else {
                        alert("Operation Fail");
                    }
                }

            }

            function proEdit(obj) {
                if (confirm("Confirm to edit selected products？")) {
                    var proid = $(obj).attr("dbkey");
                    var url = "proManager/proEdit.aspx?id=" + proid;
                    window.parent._addTab('Edit Product', url);
                }
            }

            function _view(obj) {
                var webAppDomain = '<%=webAppDomain%>Product/submitReview.aspx?id=' + $(obj).attr("dbkey");
                window.open(webAppDomain);
            }
	</script>

    </form>
</body>

</html>