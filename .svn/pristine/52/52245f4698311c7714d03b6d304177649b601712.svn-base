<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payCash.aspx.cs" Inherits="TweebaaWebApp2.Mgr.userMgr.payCash" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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

    <fieldset>
        <legend>Condition Search</legend>
         <table class="tbtable" style="width:100%;">
            <tr>
                <td class="title" style="width:80px;">
                    User Email：
                </td>
                <td style="width:120px;">
                    <input type="text" id="txtEmail" maxlength="30" />
                </td>
               
                <td class="title" style=" width:110px;">
                   State：
                </td>
                <td style="width:110px;">
                    <asp:DropDownList ID="ddlState" runat="server"  Width="150px">
                        <asp:ListItem Value="">--Please Select--</asp:ListItem>
                        <asp:ListItem Value="0">申请中</asp:ListItem>
                        <asp:ListItem Value="1">已提取</asp:ListItem>
                        <asp:ListItem Value="3">已拒绝</asp:ListItem>                        
                    </asp:DropDownList>
                </td>   
                
              
            </tr>   
            <tr>
               <td class="title" style=" width:110px;">
                   Time：
                </td>
                <td colspan="5">
                 From：<input type="text" id="txtStartTime"   />
                    To：<input type="text" id="txtEndTime"  />     
                   </td>     
            </tr>         
            <tr>
                <td colspan="6">
                    <a id="btn" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" onclick="_search()">Search</a>                     
                </td>
            </tr>
        </table>
   </fieldset>

      <div style="margin: 2px;">
        <table id="dg" title="User Cash" style="width: 100%; height: auto">
        </table>
       
    </div>
    
      <script type="text/javascript">
          $(function () {

              $('#winView').window({
                  collapsible: false,
                  minimizable: false,
                  maximizable: false,
                  modal: true
              });
              $('#winView').window('close');
              $("#txtEmail").textbox();
              $("#txtStartTime,#txtEndTime").datebox();

              $("#ddlState").combobox({
                  valueField: 'value',
                  textField: 'text',
                  data: eval("[{value:'--Please Select--',text:'--Please Select--'},{value:'0',text:'申请中'},{value:'1',text:'已提取'},{value:'2',text:'已拒绝'}]"),
                  onSelect: function (e) {

                  }
              });
              $("#ddlState").combobox("setValue", "--Please Select--");
          })
    </script>
    <script type="text/javascript">
        var dataGridUrl = 'users.ashx?action=payCash';
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
                        { field: 'id', checkbox: true },
                        { field: 'username', title: '会员', width: 100 },
                        { field: 'money', title: '提取金额', width: 100 },                      
                        { field: 'state', title: '提取状态', width: 100, align: 'right', formatter: function (value, rowData, rowIndex) {                            
                              if (value == 0) { return '申请中'; }
                              if (value == 1) { return '已提取'; }
                              if (value == 3) { return '已拒绝'; }
                          }
                        },
                        { field: 'paymentno', title: '收款账号', width: 180, align: 'right' },
                        { field: 'addTime', title: '申请日期', width: 250, align: 'right' },
                        { field: 'editTime', title: '处理日期', width: 250, align: 'right' },
                        {
                        field: '_edit', title: 'Operation', width: 130, formatter: function (value, row) {
                            return "<a href='javascript:void(0)'  dbkey='" + row.id + "' onclick=Approval(this)>Approval</a>"
                        }
                    }
                    ]]
            }).datagrid('getPager'); // get the pager of datagrid
        })

        function _search() {

            var email = $("#txtEmail").textbox("getValue");
            var startTime = $("#txtStartTime").datebox("getValue");
            var endTime = $("#txtEndTime").datebox("getValue");
            var state = $("#ddlState").combobox("getValue");          
            if (state == "--Please Select--")
                state = "";        
            $('#dg').datagrid('load', {
                "email": email,
                "startTime": startTime,
                "endTime": endTime,              
                "state": state
            });
        }


        function Approval(obj) {
            if (confirm("Confirm to approval?")) {
                var id = $(obj).attr("dbkey");

                var res = TweebaaWebApp2.Mgr.userMgr.payCash.Approval(id, 1).value;
                if (res == "success") {
                    alert("Approve Success！");
                    _search();
                }
                else {
                    alert("Approve failed！");
                }
            }
        }
       
    </script>
    </form>
</body>
</html>
