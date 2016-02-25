<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="TweebaaWebApp2.Mgr.sysManager.Manager" %>

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
                    Login Name：
                </td>
                <td>
                    <input type="text" id="txtName" maxlength="20" runat="server" />
                </td>
                <td style="color: Red;width: 200px;">
                    *
                </td>
            </tr>
            <tr>
                <td class="title">
                    Login Password：
                </td>
                <td>
                    <input type="password" id="txtPwd1" maxlength="20" runat="server" />
                </td>
                <td style="color: Red; width: 100px;">
                    
                </td>
            </tr>
             <tr>
                <td class="title">
                    Re-enter Password：
                </td>
                <td>
                    <input id="txtPwd2" name="rpwd" type="password" class="easyui-validatebox" required="required" validType="equals['#txtPwd1']" />
                </td>
                <td style="color: Red; width: 100px;">
                    
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
                <td style="color: Red;">
                    
                </td>
            </tr>
            <tr class="title">
               <td colspan="3">
                    Authoration Group：<input id="hidSelect" name="groupSelect" type="hidden" runat="server" /> 
               </td> 
            </tr>
             <tr>
               <td >
                    Unselected Group：
               </td> 
               <td >
                    
               </td> 
               <td >
                    Selected Group：
               </td> 
            </tr>
            <tr >
                <td>
                    <select id="groupUnSelect" multiple="multiple" name="unSelected" ondblclick="listMove('groupSelect','groupUnSelect','hidSelect',true,this.selectedIndex)" 
                    size="8" style="height: 150px; width: 99%; ">
                    
                    </select>    
                </td> 
               <td align="center">
                    <button type="button" name="btnRDrop" id="btnRDrop1" onclick="listMove('groupSelect','groupUnSelect','hidSelect',false)"><<</button>
                    <button type="button" name="btnRAdd" id="btnRAdd1" onclick="listMove('groupSelect','groupUnSelect','hidSelect',true)">>></button>
                    
               </td> 
               <td>
                   <select id="groupSelect" multiple="multiple" name="Selected" ondblclick="listMove('groupSelect','groupUnSelect','hidSelect',false,this.selectedIndex)" 
                   size="8" style="height: 150px; width: 99%; color: Blue"> 
                    
                    </select>
               </td> 
            </tr>
            <tr>
                <td colspan="3">
                    <asp:LinkButton ID="linkBtnRegister" runat="server" OnClientClick="javascript:return verfy()" OnClick="linkBtnRegister_Click">Registration Administrator</asp:LinkButton>
                    <asp:LinkButton ID="linkBtnSave" runat="server" OnClientClick="javascript:return _edit(this)" >Save Edit</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#txtName").textbox();
            $("#txtPwd1").textbox();
            $("#txtPwd2").textbox();
            $("#selState").combobox();
            //$("#selRole").combobox();
            $('#<%=linkBtnRegister.ClientID %>').linkbutton();
            $('#<%=linkBtnSave.ClientID %>').linkbutton();
            // extend the 'equals' rule
            $.extend($.fn.validatebox.defaults.rules, {
                equals: {
		            validator: function(value,param){
			            return value == $(param[0]).val();
		            },
		            message: 'Field do not match.'
                }
            });
            load_group('groupUnSelect','groupSelect' );
           
        })
       

        function verfy() {
            var name = $("#txtName").textbox("getValue");
            var pwd = $("#txtPwd1").textbox("getValue");
            getSelected('hidSelect','groupSelect');
            var funcList = $("#hidSelect")[0];
            if (name == null || $.trim(name) == "" || pwd == null || $.trim(pwd) == "") {
                alert("Login Name and Password cannot be blank");
                return false;
            }
            else {
                return true;
            }
        }

        function verfy_edit() {
            var name = $("#txtName").textbox("getValue");
           
            if (name == null || $.trim(name) == "" ) {
                alert("Login Name cannot be blank");
                return false;
            }
            else {
                return true;
            }
        }

        function getSelected(hidetextbox,source)
        {
            var hid = $('#' + hidetextbox)[0]; // document.getElementById(hidetextbox);
            var str = "";
            //遍历Listbox，取得选中项的值 
            $('#' + source + ' option').each(function () {
                str += $(this).val() + ',';
            });
            hid.value = str;
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
           
        } 

        function _edit() {
            if (verfy_edit()) {
                var name = $("#txtName").textbox("getValue");
                var pwd = $("#txtPwd1").textbox("getValue");
                var selState = $('#<%=selState.ClientID %>').combobox("getValue");
                getSelected('hidSelect','groupSelect');
                var funcList = $("#hidSelect")[0];
                var id = $("#<%=hidID.ClientID %>").val();
                //var res = TweebaaWebApp2.Mgr.sysManager.Manager.Save(id, name, pwd, selRole, selState).value;
                var res = TweebaaWebApp2.Mgr.sysManager.Manager.Save(id, name, pwd, selState,funcList.value).value;
                if (res == "success")
                    alert("Edit Success");
                else if(res == "set group fail")
                    alert("Set authorized group fail");
                else
                    alert("Update Fail");
                return false;
            } else {
                return false;
            }

        }

        function load_group(main, follow) 
        {
            //alert("Call Success");
            var source;
            var dest;
            var group_unselected,group_selected;
            source = $('#' + main);
            dest = $('#' + follow);
            group_unselected = <%=_unselected%>;
            
            $.each(group_unselected,function(key,val){
                source.append("<option value='" + val.value + "'>" + val.text + "</option>");
            });

            group_selected = <%=_selected%>;
            $.each(group_selected,function(key,val){
                dest.append("<option value='" + val.value + "'>" + val.text + "</option>");
            });
        }


    </script>
</body>
</html>
