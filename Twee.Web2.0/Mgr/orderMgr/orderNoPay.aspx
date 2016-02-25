<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderNoPay.aspx.cs" Inherits="TweebaaWebApp2.Mgr.orderMgr.orderNoPay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <%--弹出框--%>
    <link href="../css/jquery-webox.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-webox.js" type="text/javascript"></script>
    <script type="text/javascript">

        function showBoxInfo(id) {
            $.webox({
                height: 550,
                width: 980,
                bgvisibel: false,
                title: 'Order Details',
                iframe: 'admOrderInfo2.aspx?guid=' + id
            });

        }

        //Price Change/Payment
        function showBoxUpPrice(id, action) {
            $.webox({
                height: 400,
                width: 1000,
                bgvisibel: false,
                title: action == '0' ? 'Price Change' : 'Payment',
                iframe: 'admOrderUpPrice.aspx?guid=' + id + '&action=' + action
            });

        }

        //Delivery
        function showBoxSend(id) {
            $.webox({
                height: 580,
                width: 980,
                bgvisibel: false,
                title: 'Delivery',
                iframe: 'admOrderSend.aspx?guid=' + id
            });

        }
        //Confirm/Delete
        function showBoxConfirm(id, action) {
            $.webox({
                height: 130,
                width: 300,
                bgvisibel: false,
                title: action == '0' ? 'Confirm' : 'Delete',
                iframe: 'admOrderConfirm.aspx?guid=' + id + '&action=' + action
            });

        }

        function mouseOver() {
            document.getElementById("pUpdate").style.visibility = "";
        }
        function mouseOut() {
            document.getElementById("pUpdate").style.visibility = "hidden";
        }

    
    </script>
</head>
<body style="padding:2px;">
    <form id="form1" runat="server">
    <div>
    </div>
    <fieldset>
        <legend>Conditions Search</legend>
        <table class="tbtable" style="width: 100%;">
            <tr>
                <td class="title" style="width: 80px;">
                    Product Name：
                </td>
                <td style="width: 120px;">
                    <input type="text" id="txtProName" maxlength="30" />
                </td>
                <td class="title" style="width: 110px;">
                    Product Categories(Level 1)：
                    <asp:HiddenField ID="hidType" runat="server" />
                </td>
                <td style="width: 110px;">
                    <asp:DropDownList ID="ddlTypeOne" runat="server" Width="120">
                    </asp:DropDownList>
                </td>
                <td class="title" style="width: 110px;">
                    Product Categories(Level 2)：
                </td>
                <td style="width: 110px;">
                    <asp:DropDownList ID="ddlTypeTwo" runat="server" Width="120">
                    </asp:DropDownList>
                </td>
                <td class="title" style="width: 110px;">
                    <span style="color: red;">*</span>Product Categories(Level 3)：
                </td>
                <td style="width: 110px;">
                    <asp:DropDownList ID="ddlTypeThree" runat="server" Width="120">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="title">
                    Submitter：
                </td>
                <td>
                    <input type="text" id="txtProMan" />
                </td>
                <td class="title">
                    Order Status：<asp:HiddenField ID="hidState" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server" Width="120">
                    </asp:DropDownList>
                </td>
                <td class="title">
                    Order Time：
                </td>
                <td colspan="3">
                    From：<input type="text" id="txtStartTime" />
                    To：<input type="text" id="txtEndTime" />
                </td>
            </tr>
            <tr>
                <td colspan="1">
                    <a id="btn" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'"
                        onclick="_search()">Search</a>
                </td>
                <td colspan="7">
                    Send Warehouse Shipping Order Password: <input id="txtSendWarehouseShipOrderPwd" type="password" value="" />
                </td>
            </tr>
        </table>
    </fieldset>
    <div style="margin: 2px;">
        <table id="dg" title="Order List" style="width: auto; height: auto">
        </table>
    </div>
  
    <script type="text/javascript">
        $(function () {
            $("#txtProName").textbox();
            $("#txtProMan").textbox();
            $("#txtSendWarehouseShipOrderPwd").textbox();
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
                data: eval(TweebaaWebApp2.Mgr.orderMgr.orderNoPay.GetFirstCate().value),
                onSelect: function (e) {
                    var selectedId = e.value;
                    $("#ddlTypeTwo").combobox("clear");
                    $("#ddlTypeThree").combobox("clear");
                    if (selectedId != "--Please Select--") {
                        var res = TweebaaWebApp2.Mgr.orderMgr.orderNoPay.GetNextCate(selectedId).value;
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
            $("#ddlTypeTwo").combobox({
                valueField: 'value',
                textField: 'text',
                onSelect: function (e) {
                    var selectedId = e.value;
                    $("#ddlTypeThree").combobox("clear");
                    if (selectedId != "--Please Select--") {
                        var res = TweebaaWebApp2.Mgr.orderMgr.orderNoPay.GetNextCate(selectedId).value;
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
            $("#ddlTypeThree").combobox({
                valueField: 'value',
                textField: 'text',
                onSelect: function (e) {
                    var selectedId = e.value;
                    $("#<%=hidType.ClientID%>").val("").val(e.value);
                }
            });
            $("#txtStartTime,#txtEndTime").datebox();
            $("#ddlTypeOne").combobox("setValue", "--Please Select--");

            $("#ddlState").combobox({
                valueField: 'value',
                textField: 'text',


                //Order Status：0 Unpaid，1 waiting to ship，2Shipped，3Partially shipped，-1 Cancelled
                data: eval("[{value:'--Please Select--',text:'--Please Select--'},{value:'0',text:'Unpaid'},{value:'1',text:'Waiting To Ship'},{value:'2',text:'Shipped'},{value:'3',text:'Partially shipped'},{value:'-1',text:'Cancelled'},{value:'-2',text:'申请退货中'},{value:'-3',text:'退货中'},{value:'-4',text:'待退款'},{value:'-5',text:'退货完成'}]"),
                onSelect: function (e) {
                    $("#<%=hidType%>").val("").val(e.value);
                }
            });
            $("#ddlState").combobox("setValue", "--Please Select--");


        })
    </script>
    <script type="text/javascript">
        var dataGridUrl = 'order.ashx?action=nopay';
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
                        { field: 'guid', checkbox: true },
                        { field: 'guidno', title: 'Order ID', width: 110 },
                        { field: 'OrderStatus', title: 'Order Status', width: 100 },
                //{ field: 'name', title: 'Product Name', width: 80 },
                //        {field: 'address1', title: 'Recipient Address', width: 100 },
                        { field: 'reciveName', title: 'User Name', width: 80 },
                        {field: 'address1', title: 'Ship To Address', width: 120 },
                        { field: 'ShipToUserFirstName', title: 'Ship To First Name', width: 120 },
                        { field: 'ShipToUserLastName', title: 'Ship To Last Name', width: 120 },
                        { field: 'addtime', title: 'Order Time', width: 120 },
                        { field: 'logisticscost', title: 'Shipping Fee', width: 90, align: 'right',
                            formatter: function (val, row, idx) {
                                if (val == "") return val;
                                else return parseFloat(val).toFixed(2);
                            }
                        },
                        { field: 'sumProMoney', title: 'Total Price', width: 80, align: 'right',
                            formatter: function (val, row, idx) {
                                if (val == "") return val;
                                else return parseFloat(val).toFixed(2);
                            }
                        },
                        {
                            field: '_edit', title: 'Operation', width: 1400, formatter: function (value, row) {
                                var sOrderID = "'" + row.guidno + "'";
                                return "<a href='javascript:void(0)'  orderid='" + row.guidno +  "' onclick='DoSendWarehouseShippingOrder(this)'>Send Warehouse Shipping Order</a>&nbsp;&nbsp;<a href='javascript:void(0)'  w='1000' h='400' url='admOrderInfo.aspx?action=1&guid=" + row.guid + "' onclick='open_Dialog(this)'>Order Details</a>&nbsp;&nbsp;<a href='javascript:void(0)' title='Print Order' w='1000' h='400' url='admOrderPrint1.aspx?action=1&guid=" + row.guid + "' onclick='open_Dialog(this)'>Print Purchase Order</a>&nbsp;&nbsp;<a href='javascript:void(0)' title='Print Shipping Order' w='1000' h='400' url='admOrderPrint2.aspx?action=1&guid=" + row.guid + "' onclick='open_Dialog(this)'>Print Shipping Order</a>&nbsp;&nbsp;<a href='javascript:void(0)'  w='1000' h='400' url='admOrderUpPrice.aspx?action=0&guid=" + row.guid + "' onclick='open_Dialog(this)'>Change Price</a>&nbsp;&nbsp;<a href='javascript:void(0)'  w='1000' h='400' url='admOrderUpPrice.aspx?action=1&guid=" + row.guid + "' onclick='open_Dialog(this)'>Pay Order</a>&nbsp;&nbsp;<a href='javascript:void(0)'  w='1000' h='500' url='admOrderSend.aspx?guid=" + row.guid + "' onclick='open_Dialog(this)'>Shipping</a>&nbsp;&nbsp;<a href='javascript:void(0)'  w='300' h='130' url='admOrderConfirm.aspx?action=0&guid=" + row.guid + "' onclick='open_Dialog(this)'>Order Completed</a>&nbsp;&nbsp;<a href='javascript:void(0)' w='300' h='130' url='admOrderConfirm.aspx?action=1&guid=" + row.guid + "' onclick='open_Dialog(this)'>Discard Order</a>&nbsp;&nbsp;<a href='javascript:void(0)' dbkey='" + row.guidno + "' onclick=UpState(this,-3)>Goods Return Approval </a>&nbsp;&nbsp;<a href='javascript:void(0)' dbkey='" + row.guidno + "' onclick=UpState(this,-4)>Waiting to Refund</a>  ";
                            }
                        }
                    ]]
            }).datagrid('getPager'); // get the pager of datagrid
        })

        function DoSendWarehouseShippingOrder(obj) {
            // get Tweebaa Order ID
            var sOrderID = $(obj).attr("orderid");
            
            // get/check password 
            sPwd = $("#txtSendWarehouseShipOrderPwd").textbox("getValue");
            if (sPwd.trim() == "") {
                alert("Please input the password!");
                $("#txtSendWarehouseShipOrderPwd").textbox('clear').textbox('textbox').focus();
                return;
            } 

            // get order info of order status,email
            var sOrderStatus = TweebaaWebApp2.Mgr.orderMgr.orderNoPay.GetOrderStatus(sOrderID).value;
            var sOrderEmail = TweebaaWebApp2.Mgr.orderMgr.orderNoPay.GetOrderEmail(sOrderID).value;
            
            // get warehouse ship order of this order if this order has already been sent for warehouse shipping
            var sWarehouseShipOrderID = TweebaaWebApp2.Mgr.orderMgr.orderNoPay.GetWarehouseShipOrderID(sOrderID).value;
 
            // check/send unpaid Amazon order
            if (sOrderStatus == "0" && sOrderEmail == "amazon@tweebaa.com") { // un paid amazon order
                if (!confirm("Are you sure you want to send this Amazon order to warehouse for shipping?")) return;
                SendWarehouseShipOrder(sOrderStatus, sOrderID);
                return;
            }

            // waiting to ship but  have already send warehouse 
            if (sOrderStatus == "1" && sWarehouseShipOrderID != "-1") {  
                alert("This order has alreay been set to warehouse for shipping\nShipping Order #: " +  sWarehouseShipOrderID); 
                return;
            }

            // confirm and send for waiting to ship order 
            if (sOrderStatus == "1") {  // waiting to ship 
                if ( !confirm("Are you sure you want to send this order to warehouse for shipping?")) return;
                SendWarehouseShipOrder(sOrderStatus, sOrderID);
                return;
            }

            // other orders cannot be send warhouse for shipping
            alert("Cannot send warehouse shipping order for this order!\nHere only send warehouse shipping order for Amazon unpaid order or waiting to ship order!");
        }

        function SendWarehouseShipOrder(sOrderStatus, sOrderID) {
            
            // get password
            var sPwd = $("#txtSendWarehouseShipOrderPwd").textbox("getValue");
            
            // send
            var res = TweebaaWebApp2.Mgr.orderMgr.orderNoPay.SendWarehouseShipOrder(sOrderID, sOrderStatus, sPwd).value;
            
            // show result
            alert("Send Warehouse Shipping Order Results:\n\n" + res);
            if (res.substring(0, 5) != "Error") {
                $("#txtSendWarehouseShipOrderPwd").textbox('clear');
                _search();
            }
        }

        function _search() {
            var proName = $("#txtProName").textbox("getValue");
            var txtProMan = $("#txtProMan").textbox("getValue");
            var startTime = $("#txtStartTime").datebox("getValue");
            var endTime = $("#txtEndTime").datebox("getValue");
            var cate = $("#<%=hidType.ClientID%>").val();
            var state = $("#ddlState").combobox("getValue");
            if (cate == "--Please Select--")
                cate = "";
            if (state == "--Please Select--")
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
       
        function open_Dialog(obj) {
            var title = "";
            var url = $(obj).attr("url");
            var Width = $(obj).attr("w");
            var Height = $(obj).attr("h");
            var return_Value;
            if (document.all && window.print) {
                return_Value = window.showModalDialog(url, window, "dialogWidth:" + Width + "px;dialogHeight:" + Height + "px;center:yes;status:no;scroll:yes;help:no;");
                //alert(return_Value);
            }
            else
                window.open(url, "", "width=" + Width + "px,height=" + Height + "px,resizable=1,scrollbars=1");
        }
        function UpState(obj, state) {
            if (confirm("Confirm to return good？")) {
                var id = $(obj).attr("dbkey");
                if (id.length > 0) {
                    var res = TweebaaWebApp2.Mgr.orderMgr.orderNoPay.UpState(id, state).value;
                    if (res == "success") {
                        alert("Success！");
                        _search();
                    }
                    if (res == "fail") {
                        alert("Fail！");
                    }
                    if (res == "error") {
                        alert("Server Error！");
                    }
                }
            }

        }
    </script>
    </form>
</body>
</html>
