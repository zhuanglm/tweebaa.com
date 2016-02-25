﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerList.aspx.cs" Inherits="TweebaaWebApp.Mgr.sysManager.ManagerList" %>
<%@ Register TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../ui/themes/demo.css" rel="stylesheet" type="text/css" />
    <link href="../ui/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../css/aspnetpager.css" rel="stylesheet" type="text/css" />
    <script src="../ui/jquery.min.js" type="text/javascript"></script>
    <script src="../ui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../ui/easyloader.js" type="text/javascript"></script>
    <style type="text/css">
        .tbtable
        {
            border: 1px solid #95B8E7;
            border-collapse: collapse;
            width:800px;
            margin:2px;
        }
        .tbtable tr td
        {
            border: 1px solid #95B8E7;
            border-collapse: collapse;
            padding: 3px;
        }
        .title
        {
            background: #eff5ff;
            font-weight: bold;
            color: #0e2d5f;
            width: 80px;
            text-align:center;
            border: 1px solid #95B8E7;
        }
        fieldset
        {
            padding: 0px;
        }
        fieldset legend
        {
            font-size: 13px;
            color: #0e2d5f;
            padding: 0px;
        }
    </style>
</head>
<body style="padding: 2px;">
    <form id="form1" runat="server">
    <fieldset>
        <legend>Condition Search</legend>
        <table class="tbtable">
            <tr>
                <td class="title" style=" width:100px;">
                    Username：
                </td>
                <td>
                    <input type="text" id="txtName" maxlength="20" runat="server" />
                </td>
                <td class="title">
                    Registration Date：
                </td>
                <td style=" width:325px;">
                    From：<input id="ddStart" type="text" runat="server" />To：
                    <input id="ddEnd" type="text" runat="server" />
                </td>
                <td>
                    <asp:LinkButton ID="btn" runat="server" onclick="btn_Click">Search</asp:LinkButton>  
                </td>
            </tr>
        </table>

        
    </fieldset>
    <div style=" margin:2px;"></div>
    <table class="easyui-datagrid" title="Administrator List" >
    <thead>
		<tr>
			<th data-options="field:'1'">Username</th>
			<th data-options="field:'2'">User Role</th>
			<th data-options="field:'3'">Enable or Not</th>
            <th data-options="field:'4'">Creation Date</th>
            <th data-options="field:'5'">Operation</th>
		</tr>
    </thead>
    <tbody style=" display:none;">
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
           <tr>
               <td><%#Eval("loginNo") %></td>
               <td><%#Eval("role").ToString().Trim() == "1" ? "Super Administrator" : "General Administrator"%></td>
               <td><%#Eval("wnstat").ToString()=="1"?"Enabled":"Disabled" %></td>
               <td><%#Eval("createtime") %></td>
               <td>
                  <a href="javascript:void(0)" onclick="_edit(this)" dbkey="<%#Eval("guid") %>">Edit</a>
                  <a href="javascript:void(0)" onclick="_delete(this)" dbkey="<%#Eval("guid") %>">Delete</a>
               </td>
           </tr>
        </ItemTemplate>
        </asp:Repeater>
	</tbody>
</table>

    </div>
<webdiyer:AspNetPager CssClass="pages" CurrentPageButtonClass="cpb"  ID="AspNetPager1" runat="server" AlwaysShow="True"
        FirstPageText="Home" LastPageText="Last" NextPageText="Next" PrevPageText="Previous"  OnPageChanging="AspNetPager1_PageChanging">
</webdiyer:AspNetPager>


    <script type="text/javascript">
        $(function () {
            $("#txtName").textbox();
            $('#<%=btn.ClientID %>').linkbutton({
                iconCls: 'icon-search'
            });
            $('#ddStart,#ddEnd').datebox({
                required: false
            });
        })
        

        function _delete(obj) {
            if (confirm("Confirm to delete selected items？")) {
                var guid = $(obj).attr("dbkey");
                var res = TweebaaWebApp.Mgr.sysManager.ManagerList.DeleteUser(guid).value;
                if (res == "success") {
                    alert('Delete Success');
                    window.location.reload();
                }
                if (res == "fail") {
                    alert("Delete Fail");
                }
                if (res == "error") {
                    alert("Server Error，Delete Fail！");
                }
            }
        }

        function _edit(obj) {
            var guid = $(obj).attr("dbkey");
            var url = "sysManager/Manager.aspx?id=" + guid;
            window.parent._addTab("Edit Administrator Info", url);
        }
    </script>
    </form>
</body>
</html>
