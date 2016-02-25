<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proPublicJudgeMgr.aspx.cs" 
 ValidateRequest="false" enableEventValidation="false" Inherits="TweebaaWebApp2.Mgr.proManager.proPublicJudgeMgr" %>

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
                <td class="title">Evaluation Status：<asp:HiddenField ID="hidState" runat="server" /></td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server" Width="120"></asp:DropDownList>
                </td>
                <td class="title">Upload Time：</td>
                <td colspan="3">
                    From：<input type="text" id="txtStartTime"   />
                    To：<input type="text" id="txtEndTime"  /> 
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <a id="btn" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" onclick="_search()">Search</a> 
                    <a id="A1" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="passAll()" style=" color:red;">Batch Evaluation Approval</a> 
                </td>
            </tr>
        </table>
    </fieldset>

    <div style=" margin:2px;">
   <table id="dg" title="Product Evaluation List" style="width:100%;height:auto"></table>
   </div>

        <div id="winView" title="Approve Reason">
                   <table id="sonTable" class="tbtable" style="width:480px;">
                       <tr class="head">
                           <td class="title" style=" width:80px;">Product Name：</td>
                           <td><input type="text" readonly="readonly" id="reasonProName" /><input type="hidden" id="reasonProid" /></td>
                       </tr>
                       <tr>
                           <td class="title"><span style="color:red;">*</span>Default Reason：</td>
                           <td>
                               <asp:DropDownList ID="passReason" runat="server" Width="300"></asp:DropDownList>
                           </td>
                       </tr>
                       <tr>
                           <td class="title">Reason：</td>
                           <td>
                               <textarea style="width:300px; height:100px; vertical-align:top;" id="passExReason" maxlength="200"></textarea>
                           </td>
                       </tr>
                       <tr>
                           <td colspan="2">
                               <a href="javascript:void(0)" onclick="passSingle()" class="easyui-linkbutton" data-options="iconCls:'icon-save'">Save</a>
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
                    data: eval(TweebaaWebApp2.Mgr.proManager.proPublicJudgeMgr.GetFirstCate().value),
                    onSelect: function (e) {
                        var selectedId = e.value;
                        $("#ddlTypeTwo").combobox("clear");
                        $("#ddlTypeThree").combobox("clear");
                        if (selectedId != "-1") {
                            var res = TweebaaWebApp2.Mgr.proManager.proPublicJudgeMgr.GetNextCate(selectedId).value;
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
                        if (selectedId != "-1") {
                            var res = TweebaaWebApp2.Mgr.proManager.proPublicJudgeMgr.GetNextCate(selectedId).value;
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
                    data: eval("[{value:'-1',text:'-ALL--'},{value:'1',text:'Evaluation'},{value:'8',text:'Evaluation Fail'}]"),
                    onSelect: function (e) {
                        $("#<%=hidType%>").val("").val(e.value);
                    }
                });
                $("#ddlState").combobox("setValue", "-1");


            })
        </script>


        <script type="text/javascript">
            var dataGridUrl = 'proPublicJudgeMgr.ashx?action=datagrid';
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
                        { field: 'prdguid', checkbox:true },
                        //{ field: 'prdguid', title: '产品ID', width: 80, hidden: true },
                        { field: 'prdname', title: 'Product Name', width: 100 },
                        { field: 'ranking', title: 'Ranking', width: 60, align: 'right'},
                        { field: 'prdcate', title: 'Product Categories', width: 100 },
                        { field: 'estimateprice', title: 'Estimate Price', width: 80, align:'right'},
                        { field: 'saleprice', title: 'Selling Price', width: 80, align:'right' },
                        { field: 'supplyprice', title: 'Supply Price', width: 80, align: 'right' },
                        { field: 'count1', title: 'Number of Supports', width: 80, align: 'right' },
                        { field: 'count0', title: 'Number of Rejects', width: 80, align: 'right' },
                        { field: 'wnstat', title: 'Evaluation Status', width: 80 },
                        { field: 'username', title: 'Suggester', width: 100 },
                        { field: 'addtime', title: 'Suggest Time', width: 100 },
                        {
                            field: '_edit', title: 'Operation', width: 150, formatter: function (value, row) {
                                return "<a href='javascript:void(0)' onclick=_view(this) dbkey='" + row.prdguid + "'>Check</a>&nbsp;&nbsp;<a href='javascript:void(0)' onclick=DoSupply(this) dbkey='" + row.prdguid + "'>Supply</a>&nbsp;&nbsp;<a href='javascript:void(0)' dbdown='" + row.count0 + "'  dbup='" + row.count1 + "' dbproname='" + row.prdname + "' dbkey='" + row.prdguid + "' onclick=OpenReason(this)>Approved</a>&nbsp;&nbsp;<a href='javascript:void(0)' dbkey='" + row.prdguid + "' onclick=proEdit(this)>Edit</a>&nbsp;&nbsp;<a href='javascript:void(0)' dbkey='" + row.prdguid + "' onclick=proDelete(this)>Delete</a>"
                            }
                        },
                        {
                            field: '_AssignSKUImage', title: ' ', width: 100, formatter: function (value, row) {
                                return "<a href='javascript:void(0)' onclick=DoAssignSKUImage(this) dbkey='" + row.prdguid + "'>Assign Image</a>"
                            }
                        },

                    ]]
                }).datagrid('getPager');	// get the pager of datagrid
            })

            function DoAssignSKUImage(obj) {
                var proid = $(obj).attr("dbkey");
                var url = "proManager/proAssignSkuImage.aspx?id=" + proid;
                window.parent._addTab('Assign SKU Image', url);
            }


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
                if (confirm("Confirm to batch approve without any verification?？")) {
                    var checkedItems = $('#dg').datagrid('getChecked');
                    if (checkedItems.length == 0) {
                        alert("Please select at least one");
                    } else {
                        var proids = '';
                        $.each(checkedItems, function (index, item) {
                            proids += "," + item.prdguid;
                        });
                        if (proids.length > 0) {
                            var res = TweebaaWebApp2.Mgr.proManager.proPublicJudgeMgr.PassAll(proids).value;
                            if (res == "success") {
                                alert("Approve Success！");
                                _search();
                            }
                            if (res == "fail") {
                                alert("Approve Fail！");
                            }
                            if (res == "error") {
                                alert("Server Error，Approve Fail！");
                            }
                        }
                    }
                }
            }

            function passSingle() {
                var proid = $("#reasonProid").val();
                var reasonid = $("#<%=passReason.ClientID%> option:selected").attr("value");
                var exreason = $("#passExReason").val();
                var adminid = $("#hidMgrAdminid").val();
                    if (proid.length > 0) {
                        var res = TweebaaWebApp2.Mgr.proManager.proPublicJudgeMgr.PassSingle(proid,reasonid,exreason,adminid).value;
                        if (res == "success") {
                            alert("Approve Success！");
                            $('#winView').window('close');
                            _search();
                        }
                        if (res == "fail") {
                            alert("Approve Fail！");
                        }
                        if (res == "error") {
                            alert("Server Error，Approve Fail！");
                        }
                    }
            }

            function proEdit(obj) {
                if (confirm("Confirm to edit selected product？")) {
                    var proid = $(obj).attr("dbkey");
                    var url = "proManager/proEdit.aspx?id=" + proid;
                    window.parent._addTab('Edit Product',url);
                }

            }

            function DoSupply(obj) {
                if (confirm("Confirm to supply for selected product？")) {
                    var proid = $(obj).attr("dbkey");
                    var url = "proManager/proSupply.aspx?id=" + proid;
                    window.parent._addTab('Supply', url);
                }

            }


            function proDelete(obj) {
                if (confirm("Confirm to delete selected product？")) {
                    var proid = $(obj).attr("dbkey");

                    if (proid.length > 0) {
                        var res = TweebaaWebApp2.Mgr.proManager.proPublicJudgeMgr.DeletePrd(proid).value;
                        if (res == "success") {
                            alert("Delete Success！");
                            _search();
                        }
                        if (res == "fail") {
                            alert("Delete Fail！");
                        }
                        if (res == "error") {
                            alert("Server Error，Delete Fail！");
                        }
                    }
                }
            
            }

            function OpenReason(obj) {
                var up;
                var down;
                
                up = parseInt($(obj).attr("dbup"));
                var count = parseInt($("#hidMgrConfigCount").val());
                down = parseInt($(obj).attr("dbdown"));
               
                if (isNaN(up)) up = 0;
                if (isNaN(down)) down = 0;
                var sParticipant = "Supports: " + up + "    Rejects: " + down + "\n";
                var sErrMsg = "";
                
                // check total target
                if ((up + down) < count) {
                    sErrMsg = sErrMsg + "Participants have not reached the target count: " + count; 
                }

                // check percentage of up 
                if ( (up + down) >= count && count > 0) {
                    var bili = parseFloat($("#hidMgrConfig1").val());
                    var sTargetPercentage = (bili * 100).toFixed(0) + '%';
                    var curBili = up / (up + down);
                    if (curBili < bili) {
                        if (sErrMsg.length == 0) sErrMsg = sErrMsg + "\n";
                        sErrMsg = sErrMsg + "Supports have not reached the target percentage: " + sTargetPercentage ;
                    }
                }

                if (sErrMsg.length > 0) {
                    var sConfirmMsg =  sErrMsg + "\n\nAre you sure you still want to approval this product ?";
                    if ( !confirm(sConfirmMsg)) return ;  
                } 

                var proname = $("#reasonProName");
                var proid = $("#reasonProid");
                proid.val('').val($(obj).attr("dbkey"));
                proname.val('').val($(obj).attr("dbproname"));
                $("#passExReason").val('');
                $('#winView').window('open');
            }


            function _view(obj) {
                var webAppDomain = '<%=webAppDomain%>Product/submitReview.aspx?id=' + $(obj).attr("dbkey");
                window.open(webAppDomain);
            }
	</script>
    </form>
</body>
</html>
