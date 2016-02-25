﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShipOrder.aspx.cs" Inherits="TweebaaWebApp.Mgr.ShipOrderMgr.ShipOrder" %>

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
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" id="hidMgrConfig1" runat="server" />
        <input type="hidden" id="hidMgrConfigCount" runat="server" />
        <input type="hidden" id="hidMgrAdminid" runat="server" />
 
    <fieldset>
        <legend><strong>Search Conditions</strong></legend>

        <table class="tbtable" style="width:100%;">
            <tr>
                <td class="title" style="width:80px">Shipping Order #: </td>
                <td><input type="text" id="txtShipOrderID" class="txt" placeholder="Shipping Order #" style="width:150px"/>
                </td>
                <td class="title" style="width:80px">Tweebaa Order #: </td>
                <td><input type="text" id="txtTweebaaOrderID" class="txt" placeholder="Tweebaa Order #" style="width:150px"/>
                </td>
                <td class="title" style="width:80px">Partner Order #: </td>
                <td><input type="text" id="txtPartnerOrderID" class="txt" placeholder="Partner Order #" style="width:150px"/>
                </td>
            </tr>
            <tr>
                <td class="title">Success：</td>
                <td>
                    <asp:DropDownList ID="ddlSuccess" runat="server" Width="120"></asp:DropDownList>
                </td>
                <td class="title">Shipping Date：</td>
                <td colspan=3>
                    From：<input type="text" id="txtStartTime" />
                    To：<input type="text" id="txtEndTime"  /> 
                </td>
             </tr>
            <tr>
                <td colspan="6">
                    <a id="btnSearch" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" onclick="DoSearch()"><b>Search</b></a> 
                </td>
            </tr>
        </table>
    </fieldset>

    <div style=" margin:2px;">
    <table style="width:100%;height:auto">
     <tr>
     <td style="width:100%">
       <table id="dg" title="Shipping Order List" style="width:100%;height:auto"></table>
     </td>
     </tr>   
     </table>
     </div>

    </form>
    <script type="text/javascript">
        // to search by enter key
        $('#txtShipOrderID').keyup(function (event) {
           if (event.which == 13) {
               DoSearch();
               $('#txtShipOrderID').focus();
           }
        });
        $('#txtTweebaaOrderID').keyup(function (event) {
            if (event.which == 13) {
                DoSearch();
                $('#txtTweebaaOrderID').focus();
            }
        });
        $('#txtPartnerOrderID').keyup(function (event) {
            if (event.which == 13) {
                DoSearch();
                $('#txtPartnerOrderID').focus();
            }
        });

        $("#txtStartTime,#txtEndTime").datebox({
            onChange: function (e) { DoSearch(); }    
        });
        $("#txtEndTime,#txtEndTime").datebox({
            onChange: function (e) { DoSearch(); }
        });

        $("#ddlSuccess").combobox({
            valueField: 'value',
            textField: 'text',
            data: eval("[{value:'-1',text:'All'},{value:'1',text:'Yes'},{value:'0',text:'No'}]"),
            onSelect: function (e) {
                DoSearch();
            }
        });
        $("#ddlSuccess").combobox("setValue", "-1");

        // first search       
        DoSearch();

        function DoSearch()
        {
            var sShipOrderID = $('#txtShipOrderID').val();
            var sTweebaaOrderID = $('#txtTweebaaOrderID').val();
            var sPartnerOrderID = $('#txtPartnerOrderID').val();
            var sStartTime = $('#txtStartTime').datebox("getValue");
            var sEndTime = $('#txtEndTime').datebox("getValue");
            var sSuccess = $('#ddlSuccess').combobox("getValue");
            if (sSuccess == "-1") sSuccess = "";

            LoadShipOrderList(sShipOrderID, sTweebaaOrderID, sPartnerOrderID, sStartTime, sEndTime, sSuccess);
        }
        function LoadShipOrderList(sShipOrderID, sTweebaaOrderID, sPartnerOrderID, sStartTime, sEndTime, sSuccess) {
            var dataGridUrl = 'ShipOrder.ashx?action=ShipOrderListDatagrid' +
                          '&ShipOrderID=' + sShipOrderID +
                          '&TweebaaOrderID=' + sTweebaaOrderID +
                          '&PartnerOrderID=' + sPartnerOrderID +
                          '&StartTime=' + sStartTime +
                          '&EndTime=' + sEndTime +
                          '&Success=' + sSuccess;
                           
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
                      { field: 'ShipOrderID', checkbox: true },
                      { field: 'ShipOrder_ID', title: 'Shipping Order #' },
                      { field: 'OrderHead_GuidNo', title: 'Tweebaa Order #', width: 200 },
                      { field: 'ShipPartner_Name', title: 'Shipping Partner', width: 120 },
                      { field: 'ShipOrder_Date', title: 'Shipping Date' },
                      { field: 'ShipOrder_Success', title: 'Success', align:'center' },
                      { field: 'ShipOrder_PartnerOrderID', title: 'Partner Order #' },
                      { field: 'ShipOrder_ErrMsg', title: 'Error Message' },
                      {
                        field: '_edit', title: 'Operation', width: 250, formatter: function (value, row) {
                              return "<a href='javascript:void(0)' onclick=ShowShipOrderDetail(this) dbkey='" + row.ShipOrderID + "'>Detail</a>&nbsp;&nbsp;<a href='javascript:void(0)' dbkey='" + row.ShipOrderID + "' onclick=CancelShipOrder(this)>Cancel</a>"
                        }
                      }
                    ]]
                }).datagrid('getPager'); // get the pager of datagrid
            })
          }

          function ShowShipOrderDetail(obj) {
              var sShipOrderID  = $(obj).attr("dbkey");
              alert(sShipOrderID);
          }

          function CancelShipOrder(obj) {
              var sShipOrderID = $(obj).attr("dbkey");
              alert(sShipOrderID);
          }

    </script>
</body>
</html>
