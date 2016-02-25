<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageContentMgr.aspx.cs" Inherits="TweebaaWebApp2.Mgr.PageContentMgr.PageContentMgr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<% 
Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
Response.AppendHeader("Expires", "0"); // Proxies.
%>
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
   <table id="dg" title="Page Content List" style="width:100%;height:auto"></table>
     </div>

   <div id="winEdit" title="Add/Edit Page Content">
     <table class="tbtable" style="width:100%;">
        <tr>
            <td class="title" style="text-align:right; width:150px">ID: </td>
            <td><input type="text" readonly="readonly" id="txtEditID" style="width:100%" /></td>
        </tr>
        <tr>
            <td class="title" style="text-align:right;"  >Page Title: </td>
            <td><input type="text" id="txtEditPageTitle" maxlength="1024" style="width:100%" /></td>
        </tr>
        <tr>
            <td class="title" style="text-align:right;" >Category: </td>
            <td><select id="optEditCate">
            </select>
            </td>
        </tr>
        <tr>
            <td class="title" style="text-align:right;" >SEO Title: </td>
            <td><input type="text" id="txtEditSeoTitle" maxlength="1024" style="width:100%" /></td>
        </tr>
        <tr>
            <td class="title" style="text-align:right;" >SEO Key Words: </td>
            <td><input type="text" id="txtEditSeoKeyWord" maxlength="1024" style="width:100%" /></td>
        </tr>
        <tr>
            <td class="title" style="text-align:right;" >SEO Meta Tags: </td>
            <td><input type="text" id="txtEditSeoMetaTag" maxlength="1024" style="width:100%" /></td>
        </tr>
        <tr>
            <td class="title" style="text-align:right;" >Page Description: </td>
            <td>
               <div>
                    <textarea id="txtEditPageDescription" style="width: 680px; height: 350px;" runat="server"></textarea>
                    <script type="text/javascript">
                        var editor;
                        KindEditor.ready(function (K) {
                            editor = K.create('#' + document.getElementById("txtEditPageDescription").id, {
                                langType: 'en',
                                cssPath: '../../Kindeditor/kindeditor-4.1.10/plugins/code/prettify.css',
                                uploadJson: '../../Kindeditor/kindeditor-4.1.10/asp.net/upload_json.ashx',
                                fileManagerJson: '../../Kindeditor/kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                                allowFileManager: true,
                                afterCreate: function () {
                                    var self = this;
                                    K.ctrl(document, 13, function () {
                                        self.sync();
                                        K('form[name=example]')[0].submit();
                                    });
                                    K.ctrl(self.edit.doc, 13, function () {
                                        self.sync();
                                        K('form[name=example]')[0].submit();
                                    });
                                }
                            });
                        });
                    </script>
                </div>

            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center" >
            <a id="hrefEdit" href="javascript:void(0)" onclick="DoSaveEdit()" class="easyui-linkbutton">Save Edit</a>
            <a id="hrefAdd" href="javascript:void(0)" onclick="DoSaveAdd()" class="easyui-linkbutton">Add</a>
            </td>
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

         LoadPageContent();

         function LoadPageContent() {
             var dataGridUrl = 'PageContentHandler.ashx?action=PageContentDatagrid';
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
                    { field: 'PageContentID', checkbox: true },
                    { field: 'PageContent_PageTitle', title: 'Page Title', width: 200 },
                    { field: 'PageContentCate_Name', title: 'Category', width: 100 },
                    { field: 'PageContent_SeoTitle', title: 'SEO Title', width: 100 },
                    { field: 'PageContent_SeoKeyWord', title: 'SEO Key Words', width: 100 },
                    { field: 'PageContent_SeoMetaTag', title: 'SEO Meta Tags', width: 100 },
                    {
                        field: '_edit', title: 'Operation', width: 250, formatter: function (value, row) {
                            return "<a href='javascript:void(0)' onclick=DoView(this) dbkey='" + row.PageContent_ID + "'>View</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick=DoEdit(this) dbkey='" + row.PageContent_ID + "'>Edit</a>&nbsp;&nbsp;&nbsp;&nbsp;"
                                 + "<a href='javascript:void(0)' onclick=DoDelete(this) dbkey='" + row.PageContent_ID + "'>Delete</a>"
                        }
                    }
                ]]
                 }).datagrid('getPager'); // get the pager of datagrid
             })
         }

         function DoView(obj) {
             var sID = $(obj).attr("dbkey");
             window.open("/page.aspx?id=" + sID, "_blank");
         }

         function DoDelete(obj) {
             var sID = $(obj).attr("dbkey");

             if (!confirm("Are you sure you want to delete ?")) return;
             var res = TweebaaWebApp2.Mgr.PageContentMgr.PageContentMgr.Delete(sID);
             LoadPageContent();
         }


         function DoEdit(obj) {
             var id = $(obj).attr("dbkey");
             $("#txtEditID").val(id);
             var res = TweebaaWebApp2.Mgr.PageContentMgr.PageContentMgr.GetPageContentInfo(id);
             var obj = eval(res.value)[0];
             $("#txtEditPageContentCateID").val(obj.PageContentCate_ID);
 
             $("#txtEditPageTitle").val(obj.PageContent_PageTitle);
             $("#txtEditSeoTitle").val(obj.PageContent_SeoTitle);
             $("#txtEditSeoKeyWord").val(obj.PageContent_SeoKeyWord);
             $("#txtEditSeoMetaTag").val(obj.PageContent_SeoMetaTag);
             editor.html(obj.PageContent_PageDescription);
 
             LoadPageContentCateList("#optEditCate", obj.PageContentCate_ID);
             $("#hrefEdit").show();
             $("#hrefAdd").hide();
             $('#winEdit').window('open');
         }

         function DoMenuAdd() {

             $("#txtEditID").val("");
             LoadPageContentCateList("#optEditCate", "1");
             $("#txtEditPageTitle").val("");
             $("#txtEditSeoTitle").val("");
             $("#txtEditSeoKeyWord").val("");
             $("#txtEditSeoMetaTag").val("");
             editor.html("");

             $("#hrefEdit").hide();
             $("#hrefAdd").show();
             $('#winEdit').window('open');
         }

         function CheckInput() {
             // page title and page description are must input fields
             var sPageTitle = $("#txtEditPageTitle").val();

             if (sPageTitle.trim() == "") {
                alert ("Please input page title!");
                $("#txtEditPageTitle").focus();
                return false;
             }

            var sPageDescription = editor.html();
            if (sPageDescription.trim() == "") {
                alert ("Please input page description!");
                $("#txtEditPageDescription").focus();
                editor.focus();
                return false;
             }
            return true;
         }


         function DoSaveAdd() {
             if (!CheckInput()) return;

             var sCateID = $("#optEditCate option:selected").val();
             var sPageTitle = $("#txtEditPageTitle").val();
             var sSeoTitle = $("#txtEditSeoTitle").val();
             var sSeoKeyWord = $("#txtEditSeoKeyWord").val();
             var sSeoMetaTag = $("#txtEditSeoMetaTag").val();
             var sPageDescription = editor.html();

             var res = TweebaaWebApp2.Mgr.PageContentMgr.PageContentMgr.Add(parseInt(sCateID), sPageTitle, sPageDescription, sSeoTitle, sSeoKeyWord, sSeoMetaTag);
             LoadPageContent();
             $('#winEdit').window('close');

         }

         function DoSaveEdit() {
             if (!CheckInput()) return;

             var sID = $("#txtEditID").val();
             var sCateID = $("#optEditCate option:selected").val();
             var sPageTitle = $("#txtEditPageTitle").val();
             var sSeoTitle = $("#txtEditSeoTitle").val();
             var sSeoKeyWord = $("#txtEditSeoKeyWord").val();
             var sSeoMetaTag = $("#txtEditSeoMetaTag").val();
             var sPageDescription = editor.html();

             var res = TweebaaWebApp2.Mgr.PageContentMgr.PageContentMgr.Update(parseInt(sID), parseInt(sCateID), sPageTitle, sPageDescription, sSeoTitle, sSeoKeyWord, sSeoMetaTag);
             LoadPageContent();
             $('#winEdit').window('close');

             //            alert(res.value);
         }


         function LoadPageContentCateList(sDropDownListID, iCurCateID) {
             $(sDropDownListID).html('');
             var res = TweebaaWebApp2.Mgr.PageContentMgr.PageContentMgr.GetPageContentCateList();
             var cateList = eval(res.value);
             var htmlOption = '';
             for (var i = 0; i < cateList.length; i++) {
                 var cate = cateList[i];
                 var selected = '';
                 if (iCurCateID == cate.PageContentCate_ID) selected = 'selected';
                 htmlOption += '<option value="' + cate.PageContentCate_ID + '" ' + selected + ' >' + cate.PageContentCate_Name + '</option>';
             }             
             $(sDropDownListID).html(htmlOption);
         }
	</script>
    </form>
</body></html>

