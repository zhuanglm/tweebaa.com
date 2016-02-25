﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proSKUMgr.aspx.cs" Inherits="TweebaaWebApp2.Mgr.proManager.proSKUMgr" %>

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
                    Submitter：
                </td>
                <td>
                    <input type="text" id="txtProMan" />
                </td>
                <td class="title">Product Status：<asp:HiddenField ID="hidProductStatus" runat="server" /></td>
                <td>
                    <asp:DropDownList ID="ddlProductStatus" runat="server" Width="120"></asp:DropDownList>
                </td>
                <td class="title">Upload Time：</td>
                <td colspan="3">
                    From：<input type="text" id="txtStartTime"   />
                    To：<input type="text" id="txtEndTime"  /> 
                </td>
            </tr>
            <tr>
                <td class="title">
                    Tweebaa Sku #
                </td>
                <td>
                    <input type="text" id="txtTweebaaSku" maxlength="15"/>
                </td>
                <td class="title">
                    Ship Partner
                </td>
                <td><asp:HiddenField ID="hidShipPartner" runat="server" />
                      <asp:DropDownList ID="ddlShipPartner" runat="server" Width="120"></asp:DropDownList>
                </td>
                <td class="title" colspan=4>
                </td>
            </tr>
 
            <tr>
                <td colspan="8">
                    <a id="btn" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" onclick="DoSearch()">Search</a> 
                    <a id="btnWarehouseInventoryUpdate" style="margin-left:10px" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" onclick="DoWarehouseInventoryUpdate()">Warehouse Inventory Update</a> 
                </td>
            </tr>
        </table>
    </fieldset>

   <div style=" margin:2px;">
        <table id="dg" title="Product SKU List" style="width:100%;height:auto"></table>
   </div>

   <% // hidden field for rule ID %>
   <asp:HiddenField ID="hidEditRuleID" runat="server" />

   <div id="winEditSKU" title="Edit SKU Details">
     <table class="tbtable" style="width:400px;">
        <tr>
            <td class="title">Tweebaa SKU: </td>
            <td><input type="text" id="txtEditTweebaaSKU" style="width:300px" maxlength="10"/></td>
        </tr>
        <tr>
            <td class="title">Spec Type: </td>
            <td><asp:HiddenField ID="hidEditSpecTypeID" runat="server" />
                <asp:DropDownList ID="ddlEditSpecType" runat="server" Width="120"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="title">Spec Name: </td>
            <td><input type="text" id="txtEditSpecName" style="width:300px" maxlength="50" />
            </td>
        </tr>
        <tr>
            <td class="title">Wholesale Price: </td>
            <td><input type="text" id="txtEditWholesalePrice" maxlength="10" style="width:300px" /></td>
        </tr>
        <tr>
            <td class="title">Minimum Quantity: </td>
            <td><input type="text" id="txtEditMinimumQuantity" maxlength="5" style="width:300px" /></td>
        </tr>
        <tr>
            <td class="title">Color: </td>
            <td><input type="text" id="txtEditColor" maxlength="50" style="width:300px" /></td>
        </tr>
        <tr>
            <td class="title">Weight(lbs): </td>
            <td><input type="text" id="txtEditWeight" maxlength="50" style="width:300px" /></td>
        </tr>
        <tr>
            <td class="title">Package Length(inch): </td>
            <td><input type="text" id="txtEditPackageLength" maxlength="50" style="width:300px" /></td>
        </tr>
        <tr>
            <td class="title">Package Width(inch): </td>
            <td><input type="text" id="txtEditPackageWidth" maxlength="50" style="width:300px" /></td>
        </tr>
        <tr>
            <td class="title">Package Height(inch): </td>
            <td><input type="text" id="txtEditPackageHeight" maxlength="50" style="width:300px" /></td>
        </tr>
        <tr>
            <td class="title">Package Weight(lbs): </td>
            <td><input type="text" id="txtEditPackageWeight" maxlength="50" style="width:300px" /></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center" ><a href="javascript:void(0)" onclick="DoSaveEditSKU()" class="easyui-linkbutton">Save</a></td>
        </tr>
      </table>
    </div>

   <div id="winEditShipToCountry" title="Edit Ship To Country">
     <table id="tblShipToCountry" class="tbtable" style="width:400px;">
        <tr>
            <th>Select</th><th>Country</th><th>Free Shipping</th>
        </tr>
        <tr>
            <td><input id="Checkbox1" type="checkbox" /></td>
            <td>Country</td>
            <td><input id="Checkbox2" type="checkbox" /></td>
        </tr>
        <tr>
            <td colspan="3" style="text-align:center" ><a href="javascript:void(0)" onclick="DoSaveEditShipToCountry()" class="easyui-linkbutton">Save</a></td>
        </tr>

      </table>
    </div>



        <script type="text/javascript">
            $(function () {
                $("#txtProName").textbox();
                $("#txtProMan").textbox();
                $("#txtTweebaaSku").textbox();

                $('#winEditSKU').window({
                    collapsible: false,
                    minimizable: false,
                    maximizable: false,
                    left: 2,
                    top: 300,
                    modal: true
                });
                $('#winEditSKU').window('close');


                $('#winEditShipToCountry').window({
                    collapsible: false,
                    minimizable: false,
                    maximizable: false,
                    left: 2,
                    top: 300,
                    modal: true
                });
                $('#winEditShipToCountry').window('close');



                $("#ddlTypeOne").combobox({
                    valueField: 'value',
                    textField: 'text',
                    data: eval(TweebaaWebApp2.Mgr.proManager.proSKUMgr.GetFirstCate().value),
                    onSelect: function (e) {
                        var selectedId = e.value;
                        $("#ddlTypeTwo").combobox("clear");
                        $("#ddlTypeThree").combobox("clear");
                        if (selectedId != "-1") {
                            var res = TweebaaWebApp2.Mgr.proManager.proSKUMgr.GetNextCate(selectedId).value;
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
                            var res = TweebaaWebApp2.Mgr.proManager.proSKUMgr.GetNextCate(selectedId).value;
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


                $("#ddlProductStatus").combobox({
                    valueField: 'value',
                    textField: 'text',
                    data: eval("[{value:' ',text:'--ALL--'},{value:'2',text:'Test-Sales'},{value:'3',text:'Buy Now'}]"),
                    onSelect: function (e) {
                        $("#<%=hidProductStatus%>").val("").val(e.value);
                    }
                });
                $("#ddlProductStatus").combobox("setValue", " ");

                $("#ddlShipPartner").combobox({
                    valueField: 'value',
                    textField: 'text',
                    data: eval("[{value:' ',text:'--ALL--'},{value:'1',text:'Fosdick'},{value:'3',text:'Drop Shipper'}]"),
                    onSelect: function (e) {
                        $("#<%=hidShipPartner%>").val("").val(e.value);
                    }
                });
                $("#ddlShipPartner").combobox("setValue", " ");


            })
        </script>

        <script type="text/javascript">
            var dataGridUrl = 'proSKUMgr.ashx?Action=SKUDataGrid';
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
                        { field: '_editSKU', title: ' ', width: 140, formatter: function (value, row) {
                            return "<a href='javascript:void(0)' dbkey='" + row.RuleID + "' onclick=DoEditSKU(this)>Edit</a>&nbsp;&nbsp;<a href='javascript:void(0)' dbkey='" + row.RuleID + "' onclick=DoEditShipToCountry(this)>Ship To Country</a>"
                        }
                        },
                        {
                            field: '_AssignSKUImage', title: ' ', width: 100, formatter: function (value, row) {
                                return "<a href='javascript:void(0)' onclick=DoAssignSKUImage(this) dbkey='" + row.prdguid + "'>Assign Image</a>"
                            }
                        },
                    //{ field: 'prdguid', title: 'Product ID', width: 80, hidden: true },
                        {field: 'prdname', title: 'Name', width: 100 },
                        { field: 'ranking', title: 'Ranking', width: 60, align: 'right' },
                        { field: 'prdcate', title: 'Category', width: 100 },
                        { field: 'ShipPartner', title: 'Ship Partner', width: 100 },
                        { field: 'wnstat', title: 'Status', width: 80 },
                        { field: 'username', title: 'Submitter', width: 100 },
                        { field: 'TweebaaSKU', title: 'Tweebaa SKU', width: 100 },
                        { field: 'WholesalePrice', title: 'Wholesale Price', width: 110, align: 'right'
                                , formatter: function (val, row, idx) {
                                    if (val == "") return val;
                                    else return "$" + parseFloat(val).toFixed(2);
                                }
                        },
                        { field: 'SpecTypeName', title: 'Spec Type', width: 70 },
                        { field: 'SpecName', title: 'Spec Name', width: 80 },
                        { field: 'Color', title: 'Color', width: 60 },
                        { field: 'Weight', title: 'Weight(lbs)', width: 80, align: 'right' },
                        { field: 'PackageLength', title: 'PKG L(inch)', width: 80, align: 'right' },
                        { field: 'PackageWidth', title: 'PKG W(inch)', width: 80, align: 'right' },
                        { field: 'PackageHeight', title: 'PKG H(inch)', width: 80, align: 'right' },
                        { field: 'PackageWeight', title: 'PKG Weight(lbs)', width: 120, align: 'right' },
                        { field: 'MinimumQuantity', title: 'Minimum Qty', width: 100, align: 'right'
                           , formatter: function (val, row, idx) {
                               if (val == "") return val;
                               else return parseInt(val);
                           }
                        },
                        { field: 'InvLastUpdatedDate', title: 'Qty Updated Date', width: 160 },
                        { field: 'InvAvailable', title: 'Inventory Available', width: 140, align: 'center' },
                        { field: 'InvAvailableQuantity', title: 'Available Qty', width: 100, align: 'right'
                           , formatter: function (val, row, idx) {
                               if (val == "") return val;
                               else return parseInt(val);
                           }
                        },
                        { field: 'InvCommittedQuantity', title: 'Committed Qty', width: 100, align: 'right'
                            , formatter: function (val, row, idx) {
                                if (val == "") return val;
                                else return parseInt(val);
                            }
                        },
                        { field: 'InvStockQuantityInConnecticut', title: 'Connecticut Qty', width: 110, align: 'right'
                            , formatter: function (val, row, idx) {
                                if (val == "") return val;
                                else return parseInt(val);
                            }
                        },
                        { field: 'InvStockQuantityInNevada', title: 'Nevada Qty', width: 80, align: 'right'
                           , formatter: function (val, row, idx) {
                               if (val == "") return val;
                               else return parseInt(val);
                           }
                        },
                        { field: 'InvOtherQuantity', title: 'Other Qty', width: 80, align: 'right'
                           , formatter: function (val, row, idx) {
                               if (val == "") return val;
                               else return parseInt(val);
                           }
                        },

                    //{ field: 'estimateprice', title: 'Estimate Price', width: 80 },
                    //{ field: 'saleprice', title: 'Limited Time Price', width: 80 },
                        {field: 'count', title: 'Sold Qty', width: 80, align: 'right'
                        , formatter: function (val, row, idx) {
                            if (val == "") return val;
                            else return parseInt(val);
                        }
                    },
                        { field: 'saletotal', title: 'Total Sales', width: 100, align: 'right',
                            formatter: function (val, row, idx) {
                                if (val == "") return val;
                                else return "$" + parseFloat(val).toFixed(2);
                            }
                        },
                    //{ field: 'presaleforward', title: 'Limited Time Target', width: 80 },
                    //{ field: 'count1', title: 'Number of Rejects', width: 80 },
                        {field: 'addtime', title: 'Submit Time', width: 100 },
                    //   { field: 'stateremark', title: 'Evaluation Reason', width: 100 },
                        {field: '_edit', title: 'Operation', width: 170, formatter: function (value, row) {
                            //return "<a href='javascript:void(0)' onclick=_view(this) dbkey='" + row.prdguid + "'>Check</a>&nbsp;&nbsp;<a href='javascript:void(0)' dbkey='" + row.prdguid + "' dbproname='" + row.prdname + "' onclick=DownSingle(this)>Remove</a>&nbsp;&nbsp;<a href='javascript:void(0)' dbkey='" + row.prdguid + "' onclick=proEdit(this)>Edit</a>"
                            return "<a href='javascript:void(0)' dbkey='" + row.prdguid + "' onclick=DoEditProduct(this)>Edit Product</a>"
                        }
                    }
                    ]]
                }).datagrid('getPager'); // get the pager of datagrid
            })

            function DoSearch() {
                var proName = $("#txtProName").textbox("getValue");
                var tweebaaSku = $("#txtTweebaaSku").textbox("getValue");
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

                var status = $("#ddlProductStatus").combobox("getValue");
                if (status == "-1")
                    status = "";

                var shipPartnerID = $("#ddlShipPartner").combobox("getValue");

                $('#dg').datagrid('load', {
                    "ProductName": proName,
                    "ProductUser": txtProMan,
                    "StartTime": startTime,
                    "EndTime": endTime,
                    "CategoryID": cate,
                    "ProductStatus": status,
                    "TweebaaSku": tweebaaSku,
                    "ShipPartnerID": shipPartnerID
                });
            }

            function DoEditProduct(obj) {
                if (confirm("Are you sure you want to edit the selected product？")) {
                    var proid = $(obj).attr("dbkey");
                    var url = "proManager/proEdit.aspx?id=" + proid;
                    window.parent._addTab('Edit Product', url);
                }
            }

            function DoEditShipToCountry(obj) {

                // confirm
                if (!confirm("Are you sure you want to edit ship to country of the selected SKU？")) return;

                // get rule id of the spec
                var sRuleID = $(obj).attr("dbkey");
                $("#hidEditRuleID").val(sRuleID);

                // get spec type list
                var res = TweebaaWebApp2.Mgr.proManager.proSKUMgr.GetSKUShipToCountryList(sRuleID);
                var obj = eval(res.value);
                //alert(res.value);
                //alert(obj.length);
                var sHtml = '<tr><th>Select</th><th>Country</th><th>Free Shipping</th></tr>';

                for (var i = 0; i < obj.length; i++) {
                    // do not display "other" countries
                    if  (obj[i].id != 17 ) {
                        var sCountrySelected = obj[i].selected == "1" ? " checked " : "";
                        var sFreeShipSelected = obj[i].ProductShipToCountry_IsFree == "1" ? " checked " : "";
                        sHtml += '<tr>';
                        sHtml += '<td><input id="chkShipToCountry' + i.toString() + '"' +  sCountrySelected + ' type="checkbox"  value="' + obj[i].id + '" /></td>';
                        sHtml += '<td>' + obj[i].country +'</td>';
                        sHtml += '<td><input id="chkShipToCountryFree' + i.toString() + '"' + sFreeShipSelected + ' type="checkbox" /></td>';
                        sHtml += '</tr>';
                    }
                }
                sHtml += '<tr><td colspan="3" style="text-align:center" ><a href="javascript:void(0)" onclick="DoSaveEditShipToCountry()" class="easyui-linkbutton">Save</a></td></tr>';

                $("#tblShipToCountry").html(sHtml);

                // open popup            
                $('#winEditShipToCountry').window('open');


            }


            function DoEditSKU(obj) {
                
                // confirm
                if (!confirm("Are you sure you want to edit the selected SKU？")) return;
                
                // get rule id of the spec
                var sRuleID = $(obj).attr("dbkey");
                $("#hidEditRuleID").val(sRuleID);
 
                // get spec type list
                var resSKU = TweebaaWebApp2.Mgr.proManager.proSKUMgr.GetSKUDetail(sRuleID);
                var objSKU = eval(resSKU.value)[0];

                // load spec type combobox
                $("#ddlEditSpecType").combobox({
                    valueField: 'SpecTypeID',
                    textField: 'SpecTypeName',
                    data: eval(TweebaaWebApp2.Mgr.proManager.proSKUMgr.GetSpecTypeList().value),
                    onSelect: function (e) {
                        $("#<%=hidEditSpecTypeID%>").val("").val(e.value);
                    }
                });
                $("#ddlEditSpecType").combobox("setValue", objSKU.proruletitle);    // set the current spec type of combobox

                // show data
                $("#txtEditSpecName").val(objSKU.prorule);
                $("#txtEditTweebaaSKU").val(objSKU.prosku);
                if (objSKU.WholesalePrice != "") 
                    $("#txtEditWholesalePrice").val(parseFloat(objSKU.WholesalePrice).toFixed(2));
                else
                    $("#txtEditWholesalePrice").val(objSKU.WholesalePrice);

                $("#txtEditMinimumQuantity").val(objSKU.proMinimumStock);
                $("#txtEditColor").val(objSKU.color);
                $("#txtEditWeight").val(objSKU.proweight);
                $("#txtEditPackageLength").val(objSKU.PackageLength);
                $("#txtEditPackageWidth").val(objSKU.PackageWidth);
                $("#txtEditPackageHeight").val(objSKU.PackageHeight);
                $("#txtEditPackageWeight").val(objSKU.PackageWeight);

                // open popup            
                $('#winEditSKU').window('open');
            }

            function DoSaveEditSKU() {

                // get input
                var sRuleID = $("#hidEditRuleID").val();
                var sTweebaaSKU =$.trim($("#txtEditTweebaaSKU").val());
                var iSpecTypeID = parseInt($("#ddlEditSpecType").combobox("getValue"));
                var sSpecName = $.trim($("#txtEditSpecName").val());
                var sWholesalePrice = $.trim($("#txtEditWholesalePrice").val());
                var sMinimumStock = $.trim($("#txtEditMinimumQuantity").val());
                var sColor = $.trim($("#txtEditColor").val());
                var sWeight = $.trim($("#txtEditWeight").val());
                var sPackageLength = $.trim($("#txtEditPackageLength").val());
                var sPackageWidth = $.trim($("#txtEditPackageWidth").val());
                var sPackageHeight = $.trim($("#txtEditPackageHeight").val());
                var sPackageWeight = $.trim($("#txtEditPackageWeight").val());

                // check input
                if (sTweebaaSKU.length != 10) {
                    alert("Please enter a valid Tweebaa SKU #");
                    $("#txtEditTweebaaSKU").focus();
                    return;
                }

                if (sSpecName.length == 0) {
                    alert("Please enter the Spec Name!");
                    $("#txtEditSpecName").focus();
                    return;
                }

                // check whole sale price
                if (sWholesalePrice != "") {
                    if (!IsPositiveDecimal(sWholesalePrice)) {
                        alert("Please enter a valid Wholesale Price");
                        $("#txtEditWholesalePrice").focus();
                        return;
                    }
                }

                if (sMinimumStock.length == 0 || !IsNumber(sMinimumStock)) {
                    alert("Please enter a valid Minimum Quantity!");
                    $("#txtEditMinimumQuantity").focus();
                    return;
                }

                var iMinimumStock = parseInt(sMinimumStock);
                if (iMinimumStock < 0){
                    alert("Please enter a valid Minimum Quantity!");
                    $("#txtEditMinimumQuantity").focus();
                    return;
                }

                if (sColor.length == 0) {
                    alert("Please enter a valid Color");
                    $("#txtEditColor").focus();
                    return;
                }

                // check weight
                if (!IsPositiveDecimal(sWeight)) {
                    alert("Please enter a valid Weight");
                    $("#txtEditWeight").focus();
                    return;
                }
                dWeight = parseFloat(sWeight);

                // check package length
                if (!IsPositiveDecimal(sPackageLength)) {
                    alert("Please enter a valid Package Length");
                    $("#txtEditPackageLength").focus();
                    return;
                }

                // check package width
                if (!IsPositiveDecimal(sPackageWidth)) {
                    alert("Please enter a valid Package Width");
                    $("#txtEditPackageWidth").focus();
                    return;
                }

                // check package Height
                if (!IsPositiveDecimal(sPackageHeight)) {
                    alert("Please enter a valid Package Height");
                    $("#txtEditPackageHeight").focus();
                    return;
                }

                // check package Weight
                if (!IsPositiveDecimal(sPackageWeight)) {
                    alert("Please enter a valid Package Weight");
                    $("#txtEditPackageWeight").focus();
                    return;
                }

 
                if (!confirm("Are you sure you want to save?")) return;

                var res = TweebaaWebApp2.Mgr.proManager.proSKUMgr.SaveSKUDetail(sRuleID, sTweebaaSKU, iSpecTypeID, sSpecName, sWholesalePrice, sMinimumStock, sColor, dWeight.toFixed(2), sPackageLength, sPackageWidth, sPackageHeight, sPackageWeight);
                if (res.value == "1") {
                    alert("SKU details have been saved successfully!");
                    // close pupup
                    $('#winEditSKU').window('close');
                    DoSearch();
                }
                else {
                    alert("Failed to save the SKU details!");
                }
            }



            function DoWarehouseInventoryUpdate() {
                if (!confirm("Are you sure you want to update warehouse inventory?")) return;
                var res = TweebaaWebApp2.Mgr.proManager.proSKUMgr.WarehouseInventoryInfoUpdate();

                if (res.value == "1") {
                    alert("Warehouse inventory has been updated sucessfully");
                    DoSearch();
                }
                else
                    alert("Warehouse inventory update error: " + res.value);
            }

            function IsNumber(s) {
                if (s.length == 0) return false;
                for (var i = 0; i < s.length; i++) {
                    var c = s.substring(i, i + 1);
                    if (c < "0" || c > "9") return false;
                }
                return true;
            }

            function IsPositiveDecimal(s) {
                if (s.length == 0) return false;
                for (var i = 0; i < s.length; i++) {
                    var c = s.substring(i, i + 1);
                    if ((c < "0" || c > "9" ) && c!= "." && c!="-" && c!="+") return false;
                }

                var dVal = parseFloat(s);
                if (isNaN(dVal)) return false;

                if (dVal < 0) return false; 
                 
                return true;
            }

            function DoSaveEditShipToCountry() {
                
                if (!confirm("Are you sure you want to save?")) return;
                var i = 0;

                var sRuleID = $("#hidEditRuleID").val();
                //alert(sRuleID);
                var sData = "";

                while (true) {
                    var objCountry = $("#chkShipToCountry" + i.toString());
                    var sCountryID = objCountry.val();
                    if (sCountryID == undefined ) break;
                    var bCountrySelected = objCountry.is(":checked");
                    var bShipToCountryFree = $("#chkShipToCountryFree" + i.toString()).is(":checked");
                    //alert(sCountryID + " " + bCountrySelected + " " + bShipToCountryFree);
                    if (bCountrySelected) {
                        if (sData != "") sData = sData + ",";
                        sData = sData + sCountryID + " " + (bShipToCountryFree ? "FREE" : "");
                    }
                    i = i + 1;
                }

                var res = TweebaaWebApp2.Mgr.proManager.proSKUMgr.SaveShipToCountry(sRuleID, sData);

                if (res.value == "1") {
                    // close popup            
                    $('#winEditShipToCountry').window('close');
                    alert("Ship to countries have been updated");
                }
                else
                    alert("Ship to countries update error: " + res.value);
            }

            function DoAssignSKUImage(obj) {
                var proid = $(obj).attr("dbkey");
                var url = "proManager/proAssignSkuImage.aspx?id=" + proid;
                window.parent._addTab('Assign SKU Image', url);
            }

/*
            function _view(obj) {
                var webAppDomain = '<%=webAppDomain%>Product/submitReview.aspx?id=' + $(obj).attr("dbkey");
                window.open(webAppDomain);
            }
*/
	</script>

    </form>
</body>
</html>
