﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="TweebaaWebApp2.Mgr.sysManager.Group" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../ui/themes/demo.css" rel="stylesheet" type="text/css" />
    <link href="../ui/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../ui/jquery.min.js" type="text/javascript"></script>
    <script src="../ui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../ui/easyloader.js" type="text/javascript"></script>
    <style type="text/css">
        table
        {
            border: 1px solid #95B8E7;
            border-collapse: collapse;
        }
        table tr td
        {
            border: 1px solid #95B8E7;
            width:135px;
            border-collapse: collapse;
            padding: 3px;
        }
        .title
        {
            background: 1px solid #95B8E7;
            font-weight: bold;
            color: #0e2d5f;
            width: 200px;
        }
    </style>
</head>
<body style="padding: 2px;">
    <form id="form1" runat="server">
    <asp:HiddenField ID="hidID" runat="server" />
    <input type="hidden" id="hidDataXml" value="" />
    <div>
        <table>
            <tr>
                <td class="title">
                    Group Name：
                </td>
                <td>
                    <input type="text" id="txtName" maxlength="20" runat="server" />
                </td>
                <td style="color: Red; width: 200px;">
                    *
                </td>
            </tr>
            <tr>
                <td class="title">
                    Group Description：
                </td>
                <td colspan="2">
                    <input style="width:300px" type="text" id="txtDes" maxlength="60" runat="server" />
                </td>
                
            </tr>
            
            <tr>
                <td class="title">
                    Enable or Not：
                </td>
                <td>
                    <asp:DropDownList ID="selState" runat="server" Width="100">
                    <asp:ListItem Value="1" Text="Enable"></asp:ListItem>
                    <asp:ListItem Value="0" Text="Disable"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="color: Red; width: 200px;">
                    *
                </td>
            </tr>
            <tr class="title">
               <td colspan="3">
                    Authoration Menu Items：<input id="hidSelect" name="groupSelect" type="hidden" runat="server" /> 
               </td> 
            </tr>
            <tr>
                <td colspan="3">
                     <ul id="tt" data-options="lines:true"></ul>
                </td>
            </tr>
                <td colspan="3" align="center">
                    <asp:LinkButton ID="linkBtnRegister" runat="server" OnClientClick="javascript:return verfy()" OnClick="linkBtnRegister_Click">Create User Group</asp:LinkButton>
                    <asp:LinkButton ID="linkBtnSave" runat="server" OnClientClick="javascript:return _edit()" >Save Edit</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#txtName").textbox();
            $("#txtDes").textbox();
            $("#selState").combobox();
            $("#hidSelect").textbox();
            $('#<%=linkBtnRegister.ClientID %>').linkbutton();
            $('#<%=linkBtnSave.ClientID %>').linkbutton();
        })
       
       $('#tt').tree({
          data: eval(<%=_treeJson %>),
          checkbox: true,
          onLoadSuccess:function(node,data){  
              
            },
          onClick:function(node){
            if(node.id>1000){
               //alert(node.id+" This function is:  "+ node.attributes.url);
               
               if(node.checked == true)
                    $("#tt").tree('uncheck',node.target);
               else
                    $("#tt").tree('check',node.target);
               
            }
            else {
                //alert(node.id+"<1000");
                var child = $("#tt").tree('getChildren',node.target);
	            if(child.length>0 && $("#tt").tree('getSelected').state=='closed'){
	                $("#tt").tree('expand',node.target);
	            }else if(child.length>0 && $("#tt").tree('getSelected').state=='open'){
	            	 $("#tt").tree('collapse',node.target);
	            }else{
	            	alert('Please assign authorized item');
	            	return false;
	            }
            }
             
          },
        });

         function getChecked(hidetextbox)
        {
            var arr = [];
           
            var checkeds = $('#tt').tree('getChecked', 'checked');
            for (var i = 0; i < checkeds.length; i++) {
                arr.push(checkeds[i].id);
            }
            //var str = "";
            //str = arr.join(',');
            //alert(str);
            //var hid = $('#' + hidetextbox)[0];
            //hid.value = str;
            var hid = $('#' + hidetextbox);
            hid.textbox('setValue',arr);

            return (arr);
        }

        function verfy() {
            var name = $("#txtName").textbox("getValue");
            var power = getChecked('hidSelect');
            //alert(name+": "+power);
            if (name == null || $.trim(name) == "" || power == null || $.trim(power) == "") {
                alert("Group Name and Authoration cannot be blank");
                return false;
            }
            else {
                return true;
            }
        }

        function listMove(main, follow, hidetextbox, isBack, index) {
            if (index < 0)
                return;
            var o = undefined;
            var source;
            var dest;
            var dddd;
            if (!isBack) {
                //使用getElementById在IE6中存在BUG 
                source = $('#' + main); // window.document.getElementById(main); 
                dest = $('#' + follow); //window.document.getElementById(follow); 
            }
            else {
                source = $('#' + follow); // window.document.getElementById(follow); 
                dest = $('#' + main); // window.document.getElementById(main); 
            }
            var hid = $('#' + hidetextbox)[0]; // document.getElementById(hidetextbox); 
            if (index != undefined) {
                var op = "option:eq(" + index + ")";
                source.find(op).each(function () {
                    dest.append("<option value='" + $(this).val() + "'>" + $(this).text() + "</option>");
                    $(this).remove();
                });
            }
            else {
                source.find("option:selected").each(function () {
                    $(this).remove();
                    dest.append("<option value='" + $(this).val() + "'>" + $(this).text() + "</option>");
                });
            }
            var str = "";
            //遍历Listbox，取得选中项的值 
            $('#' + main + ' option').each(function () {
                str += $(this).val() + ',';
            });
            alert(str);
            //hid.value = str;
        } 

        function _edit() {
            if (verfy()) {
                var name = $("#txtName").textbox("getValue");
                var des = $("#txtDes").textbox("getValue");
                var selState = $('#<%=selState.ClientID %>').combobox("getValue");
                var funcList = $("#hidSelect")[0];
                var id = $("#<%=hidID.ClientID %>").val();
                
                var res = TweebaaWebApp2.Mgr.sysManager.Group.Save(id, name, des, selState,funcList.value).value;
                if (res == "success")
                    alert("Edit Success");
                else
                    alert("Edit Fail");
                return false;
            } else {
                alert("No Save");
                return false;
            }

        }
    </script>
</body>
</html>
