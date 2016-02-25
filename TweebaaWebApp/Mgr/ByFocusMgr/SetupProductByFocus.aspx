<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetupProductByFocus.aspx.cs" Inherits="TweebaaWebApp.Mgr.ByFocusMgr.SetupProductByFocus" %>

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
                <td style="width:300px">
                    <strong>Product Name or Keywords: </strong><input type="text" id="txtKeyword" class="txt" placeholder="Please search by product name or keywords" style="width:300px"/>
                </td>
                <td style="width:140px">
                    <strong>&nbsp;Product Status: </strong><asp:DropDownList ID="ddlProductStatus" runat="server" Width="120"></asp:DropDownList>
                </td>
                <td> 
                   <input id="chkDispHasNotFocusCate" type="checkbox" /><strong>Only search products without By Focus Category</strong>
                </td>
             </tr>
            <tr>
                <td colspan="3">
                    <a id="btnSearch" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" onclick="DoSearch()"><b>Search</b></a> 
                </td>
            </tr>
        </table>
    </fieldset>

    <div style=" margin:2px;">
    <table style="width:100%;height:auto">
     <tr>
     <td style="width:70%">
       <table id="dg" title="By Focus Category List" style="width:100%;height:auto"></table>
     </td>
     <td style="width:5%"></td>
     <td style="vertical-align:top">
            <p><strong>By Focus Categories</strong></p>
            <div id="chkFocusCateList"></div><br />
            <a href="javascript:void(0)" onclick="DoSelectAll(true)" class="easyui-linkbutton">Select All</a>
            <a href="javascript:void(0)" onclick="DoSelectAll(false)" class="easyui-linkbutton">Un-Select All</a><br /><br />
            <a href="javascript:void(0)" onclick="DoSave()" class="easyui-linkbutton">Save</a>
     </td>
     </tr>   
     </table>
     </div>
    </form>
    <script type="text/javascript">
        // to search by enter key
        $('#txtKeyword').keyup(function (event) {
           if (event.which == 13) {
               DoSearch();
               $('#txtKeyword').focus();

           }
        });

        LoadProductStatusDdl();
        LoadProductFocusCateList('', false, '-1');
        LoadFocusCateCheckboxList();

        function DoSearch()
        {
            var sKeyword = $('#txtKeyword').val();
            var sDispHasNotFocusCate = $('#chkDispHasNotFocusCate').prop('checked');
            var sProductStatusID = $('#ddlProductStatus').combobox("getValue");

            LoadProductFocusCateList(sKeyword, sDispHasNotFocusCate, sProductStatusID);
        }
   
        function DoSave() {

            var checkedProduct = $('#dg').datagrid('getChecked');
            if (checkedProduct.length == 0) {
                alert('Please select products you want to save!');
                return;
            }
 
            var productIDs = '';
            $.each(checkedProduct, function (index, product) {
                if (productIDs.length > 0) productIDs += ',';
                productIDs += product.ProductGuid;
            });

            var confirmMsg = '';
            var focusCateIDs = '';
            $('[id*=chkFocusCateList] input:checked').each(function () {
                if (focusCateIDs.length > 0) focusCateIDs += ',';
                focusCateIDs += $(this).val();
            });
            if (focusCateIDs != '') {
                confirmMsg = 'Are you sure you want to set the By Focus Category to selected products?';
            } else {
                confirmMsg = 'Are you sure you want to remove the By Focus Category from selectyed products?';
            }
            if ( confirm(confirmMsg) != true) return;

            var res = TweebaaWebApp.Mgr.ByFocusMgr.SetupProductByFocus.SaveProductFocusCate(productIDs, focusCateIDs);
            
            // reload list
            DoSearch();
         }

        function DoSelectAll(bSelect) {
            var items = $('#chkFocusCateList').find('INPUT[type=checkbox]')
            items.each(function () {
                $(this).prop('checked', bSelect);
            })
        }

        function LoadFocusCateCheckboxList() {
            var res = TweebaaWebApp.Mgr.ByFocusMgr.SetupProductByFocus.GetFocusCateList();
            var obj = eval(res.value);
            var sHtml = "";
            for (var i=0; i<obj.length; i++) {
               var sHtml =  sHtml + "<input type='checkbox' id='chkFocusCate' value='" + obj[i].FocusCateID + "' />"+ obj[i].Name + " <br/>";
            }
            $("#chkFocusCateList").html(sHtml);
        }

        function LoadProductStatusDdl() {
            $("#ddlProductStatus").combobox({
                valueField: 'value',
                textField: 'text',
                data: eval("[" +
                        "{value:'-1',text:'All'}," +
                        "{value:'1',text:'Evaluate'}," +
                        "{value:'2',text:'Test-Sale'}," +
                        "{value:'3',text:'Buy Now'}]"),
                onSelect: function (e) {
                    DoSearch();
                }
            });
            $("#ddlProductStatus").combobox("setValue", "-1");
        }


        function RemoveSpecialChar(str) {
            // why need remove ! in the string?
            // becauese the special char will make the datagrid cloumn header not align with data
            str = str.replace(/!/g, '');
            return str;
        }

        function LoadProductFocusCateList(sKeyword, bDispHasNotFocusCate, sProductStatusID) {
            var dataGridUrl = 'ByFocusCateMgr.ashx?action=ProductByFocusCateDatagrid&keyword='
                             + encodeURIComponent(sKeyword)
                             + '&DispHasNotFocusCate=' + bDispHasNotFocusCate
                             + '&ProductStatusId=' + sProductStatusID;
            var pageListArr = [20, 40, 60, 80, 100];
 
            var res = TweebaaWebApp.Mgr.ByFocusMgr.SetupProductByFocus.GetFocusCateColumnNameList();
            var obj = eval(res.value);
            var colStruct = [];
            var colItems = [];
            
            var productGuidItem = { field: 'ProductGuid', checkbox: true };
            var productNameItem = { field: 'ProductName', title: 'Product Name', width: 200};

            colStruct.pop();
            colItems.push(productGuidItem);
            colItems.push(productNameItem);
            for (var i = 0; i < obj.length; i++) {
                var menuItem = {
                    field: RemoveSpecialChar(obj[i].ColumnName),
                    title: RemoveSpecialChar(obj[i].ColumnName),
                        align: 'center'
                      };
                colItems.push(menuItem);
            }
            colStruct.push(colItems);
            //var columnStruct = [[{ field: 'ProductGuid', checkbox: true }, {field: 'ProductName', title: 'Product Name', width: 200 } s ]];
            $(function () {
                var pager = $('#dg').datagrid({
                    rownumbers: true,
                    singleSelect: false,
                    url: dataGridUrl,
                    pageNumber: 1,
                    method: 'get',
                    pagination: true,
                    pageSize: 20,
                    pageList: pageListArr,
                    columns: colStruct
                }).datagrid('getPager'); // get the pager of datagrid
            })
        }

    </script>
</body>
</html>
