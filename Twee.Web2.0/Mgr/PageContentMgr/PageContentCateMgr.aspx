﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageContentCateMgr.aspx.cs" Inherits="TweebaaWebApp2.Mgr.PageContentMgr.PageContentCateMgr" %>

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
<body style="padding:2px;">
    <form id="form1" runat="server">
        <input type="hidden" id="hidMgrConfig1" runat="server" />
        <input type="hidden" id="hidMgrConfigCount" runat="server" />
        <input type="hidden" id="hidMgrAdminid" runat="server" />
 
    <fieldset>
        <legend>Operations</legend>
        <table class="tbtable" style="width:100%;">
            <tr>
                <td style="width:50px">
                    <a id="btnMenuAdd" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-add'" onclick="DoMenuAdd()">Add</a> 
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </fieldset>

    <div style=" margin:2px;">
   <table id="dg" title="Page Content Category List" style="width:100%;height:auto"></table>
     </div>

   <div id="winEdit" title="Edit Page Content Category">
     <table class="tbtable" style="width:400px;">
        <tr>
            <td class="title">ID: </td>
            <td><input type="text" readonly="readonly" id="txtEditID" style="width:300px" /></td>
        </tr>
        <tr>
            <td class="title">Name: </td>
            <td><input type="text" id="txtEditName" maxlength="50" style="width:300px" /></td>
        </tr>
        <tr>
            <td class="title">Active: </td>
            <td><input type="checkbox" id="chkEditActive" value="0" /></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center" ><a href="javascript:void(0)" onclick="DoSaveEdit()" class="easyui-linkbutton">Save Edit</a></td>
        </tr>
      </table>
    </div>

     <div id="winAdd" title="Add Page Content Category">
        <table class="tbtable" style="width:400px;">
            <tr>
                <td class="title">Name: </td>
                <td><input type="text" id="txtAddName" maxlength="50" style="width:300px" /></td>
            </tr>
            <tr>
                <td class="title">Active: </td>
                <td><input type="checkbox" id="chkAddActive" value="0" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center"><a href="javascript:void(0)" onclick="DoSaveAdd()" class="easyui-linkbutton">Add</a></td>
            </tr>
        </table>
    </div>
  
   <script type="text/javascript">
       $(function () {
           $('#winEdit').window({
               collapsible: false,
               minimizable: false,
               maximizable: false,
               left: 2,
               top: 300,
               modal: true
           });
           $('#winAdd').window({
               collapsible: false,
               minimizable: false,
               maximizable: false,
               left: 2,
               top: 300,
               modal: true
           });

           $('#winEdit').window('close');
           $('#winAdd').window('close');
       })
    </script>
     <script type="text/javascript">

         LoadPageContentCate();

         function LoadPageContentCate() {
             var dataGridUrl = 'PageContentHandler.ashx?action=PageContentCateDatagrid';
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
                    { field: 'PageContentCateID', checkbox: true },
                    { field: 'Name', title: 'Name', width: 200 },
                    { field: 'Active', title: 'Active', width: 80, align: 'center' },
                    {
                        field: '_edit', title: 'Operation', width: 250, formatter: function (value, row) {
                            return "<a href='javascript:void(0)' onclick=DoEdit(this) dbkey='" + row.PageContentCateID + "'>Edit</a>&nbsp;&nbsp;"
                                 + "<a href='javascript:void(0)' onclick=DoDelete(this) dbkey='" + row.PageContentCateID + "'>Delete</a>"
                        }
                    }
                ]]
                 }).datagrid('getPager'); // get the pager of datagrid
             })
         }

         function DoDelete(obj) {
             var id = $(obj).attr("dbkey");

             if (!confirm("Are you sure you want to delete the #" + id.toString() + "?")) return;
             var res = TweebaaWebApp2.Mgr.PageContentMgr.PageContentCateMgr.Delete(id);
             if (res.value == -1) {
                 alert("You cannot delete this category because it is in using!");
                 return; 
             }
             LoadPageContentCate();
         }


         function DoEdit(obj) {
             var id = $(obj).attr("dbkey");
             $("#txtEditID").val(id);
             var res = TweebaaWebApp2.Mgr.PageContentMgr.PageContentCateMgr.GetPageContentCateInfo(id);
             var obj = eval(res.value)[0];
             $("#txtEditName").val(obj.PageContentCate_Name);
             //$("chkEditActive").val(obj.Active);
             if (obj.PageContentCate_IsActive == "1") $("#chkEditActive")[0].checked = true;
             else $("#chkEditActive")[0].checked = false;

             $('#winEdit').window('open');
         }

         function DoMenuAdd() {
             $("#txtAddName").val("");
             $("#chkAddActive").val("1");
             $('#winAdd').window('open');
         }

         function DoSaveAdd() {
             var sName = $("#txtAddName").val();
             var sActive = $('#chkAddActive').is(":checked") ? "1" : "0";

             if (sName.length == 0) { alert("Please enter the Name!"); $("#txtAddName").focus(); return; }
             var res = TweebaaWebApp2.Mgr.PageContentMgr.PageContentCateMgr.Add(sName, sActive);
             LoadPageContentCate();
             $('#winAdd').window('close');
 
         }

         function DoSaveEdit() {
             var sID = $("#txtEditID").val();
             var sName = $("#txtEditName").val();
             var sActive = $('#chkEditActive').is(":checked") ? "1" : "0";

             if (sName.length == 0) { alert("Please enter the Name!"); $("#txtEditName").focus(); return; }
             var res = TweebaaWebApp2.Mgr.PageContentMgr.PageContentCateMgr.Update(sID, sName, sActive);
             LoadPageContentCate();
             $('#winEdit').window('close');

 //            alert(res.value);
         }

	</script>
    </form>
</body></html>
