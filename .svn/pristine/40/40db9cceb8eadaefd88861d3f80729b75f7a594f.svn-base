<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proTypeList.aspx.cs" Inherits="TweebaaWebApp2.Mgr.proManager.proTypeList" %>
<%@ Register TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
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
        <table class="tbtable">
            <tr>
                <td class="title" style=" width:100px;">
                    Category Name：
                </td>
                <td style="width:150px;">
                    <input type="text" id="txtTypeName" maxlength="30" runat="server" />
                </td>
                <td>
                    <asp:LinkButton ID="btn" runat="server" OnClick="btn_Click">Search</asp:LinkButton>  
                </td>
            </tr>
        </table>
    </fieldset>

         <div style=" margin:2px;">
    <table class="easyui-datagrid" title="Administrator List" >
    <thead>
		<tr>
			<th data-options="field:'1'">Category Name</th>
			<th data-options="field:'2'">Category Level</th>
            <th data-options="field:'3'">Category Status</th>
            <th data-options="field:'4'">Order</th>
            <th data-options="field:'5'">Operation</th>
		</tr>
    </thead>
    <tbody style=" display:none;">
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
           <tr>
               <td><%#Eval("name") %></td>
               <td><%#Eval("layer").ToString() %></td>
               <td><%#Eval("wnstate").ToString()=="1"?"Activated":"Suspended" %></td>
               <td><%#Eval("idx") %></td>
               <td>
                  <a href="javascript:void(0)" onclick="_view(this)" dbkey="<%#Eval("guid")%>" dbkeyname="<%#Eval("name")%>">Check Sub-categories</a>
                  <a href="javascript:void(0)" onclick="_edit(this)" dbkey="<%#Eval("guid") %>">Edit</a>
                  <a href="javascript:void(0)" onclick="_delete(this)" dbkey="<%#Eval("guid") %>">Delete</a>
               </td>
           </tr>
        </ItemTemplate>
        </asp:Repeater>
	</tbody>
</table>

             <!--模态窗口区-->
             <div id="winEdit" title="EditCategory Name">
                   <table class="tbtable" style="width:300px;">
                       <tr>
                           <td class="title">Category ID：</td>
                           <td><input type="text" readonly="readonly" id="editTypeId" /></td>
                       </tr>
                       <tr>
                           <td class="title">Category Name：</td>
                           <td><input type="text" id="editTypeName" maxlength="50" /></td>
                       </tr>
                       <tr>
                           <td colspan="2"><a href="javascript:void(0)" onclick="_editSave()" class="easyui-linkbutton">Save Edit</a></td>
                       </tr>
                   </table>
             </div>

             <div id="winView" title="Next Category Name">
                   <table id="sonTable" class="tbtable" style="width:300px;">
                       <tr class="head">
                           <td class="title">Selected Category：</td>
                           <td><input type="text" readonly="readonly" id="keyname" /></td>
                       </tr>
                       <%--<tr>
                           <td class="title">Next Category：</td>
                           <td></td>
                       </tr>--%>
                   </table>
             </div>

             <!--模态窗口区结束-->

    </div>
<webdiyer:AspNetPager CssClass="pages" CurrentPageButtonClass="cpb"  ID="AspNetPager1" runat="server" AlwaysShow="True"
        FirstPageText="Home" LastPageText="Last" NextPageText="Next" PrevPageText="Previous"  OnPageChanging="AspNetPager1_PageChanging">
</webdiyer:AspNetPager>

        <script type="text/javascript">
            $(function () {
                $("#txtTypeName").textbox();
                $('#<%=btn.ClientID%>').linkbutton({ iconCls: 'icon-search' });
                $('#winEdit').window({
                    collapsible: false,
                    minimizable: false,
                    maximizable: false,
                    modal: true
                });
                
                $('#winView').window({
                    collapsible: false,
                    minimizable: false,
                    maximizable: false,
                    modal: true
                });
                $('#winEdit').window('close');
                $('#winView').window('close');
             })

            function _delete(obj) {
                if(confirm("Confirm to delete selected？")){
                    var id = $(obj).attr("dbkey");
                    var res = TweebaaWebApp2.Mgr.proManager.proTypeList.DeleteType(id).value;
                    if (res == "success") {
                        alert("Delete Success"); window.location.reload();
                    }
                    if (res == "fail") {
                        alert("Delete Fail");
                    }
                    if (res == "error") {
                        alert("Server Issue，Delete Fail！");
                    }
                }
            }

            function _edit(obj) {
                var id = $(obj).attr("dbkey");
                $('#winEdit').window('open');
                $("#editTypeId").val(id);
                $("#editTypeName").val("");
            }

            function _editSave() {
                var id = $("#editTypeId").val();
                var name = $("#editTypeName").val();
                if (id == null || id.length == 0 || name == null || name.length == 0) {
                    alert("Category Name cannot be blank");
                }
                else {
                    var res = TweebaaWebApp2.Mgr.proManager.proTypeList.UpdateTypeName(id, name).value;
                    if (res == "success") {
                        alert("Edit Success"); window.location.reload();
                    }
                    if (res == "fail") {
                        alert("Edit Fail");
                    }
                    if (res == "error") {
                        alert("Server Issue，Edit Fail！");
                    }
                }

            }

            function _view(obj) {
                var id = $(obj).attr("dbkey");
                $("#keyname").val($(obj).attr("dbkeyname"));
                var res = TweebaaWebApp2.Mgr.proManager.proTypeList.GetSonTypeName(id).value;
                if (res == "nodata") {
                    $("#sonTable").find("tr[class!='head']").remove();
                    var nodata = "<tr><td class=\"title\">Next Level Category：</td><td style='color:red'>No Data</td></tr>";
                    $(nodata).appendTo($("#sonTable"))
                }
                else {
                    $("#sonTable").find("tr[class!='head']").remove();
                    $(res).appendTo($("#sonTable"));
                }
                $('#winView').window('open');
            }

        </script>

    </form>
</body>
</html>
