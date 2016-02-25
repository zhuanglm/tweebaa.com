<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reviewGradeParam.aspx.cs" Inherits="TweebaaWebApp.Mgr.userMgr.reviewGradeParam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                    设置双倍积分：
                </td>
                <td style="width:120px;">
                    <input type="button"  value="设置双倍积分"  id="btnDouble" onclick="DoublePoints()" style=" width:150px;" disabled="disabled"   />

                </td>              
            </tr>          
        </table>
    </fieldset>
      <div style="margin: 2px;">
        <table id="dg" title="Review Grade Paramer" style="width: 100%; height: auto">
        </table>
    </div>
    <div id="winView" title="Approve Reason">
        <table id="sonTable" class="tbtable" style="width: 480px;">
            <tr class="head">
                <td class="title" style="width: 80px;">
                    等级：
                </td>
                <td>
                    <input type="text" readonly="readonly" id="reasonProName" /><input type="hidden"
                        id="reasonProid" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    <span style="color: red;">*</span>等级积分：
                </td>
                <td>
                     <input type="text" id="txtIntegral" />
                </td>
            </tr>
             <tr>
                <td class="title">
                    <span style="color: red;">*</span>评审奖励积分值：
                </td>
                <td>
                     <input type="text" id="txtReviewreward" />
                </td>
            </tr>
             <tr>
                <td class="title">
                    <span style="color: red;">*</span>佣金比例1(千分比)：
                </td>
                <td>
                     <input type="text" id="txtCommissionratio1" />
                </td>
            </tr>           
            <tr>
                <td colspan="2">
                    <a href="javascript:void(0)" onclick="passSingle()" class="easyui-linkbutton" data-options="iconCls:'icon-save'">
                        Save</a>
                </td>
            </tr>
        </table>
    </div>
     <script type="text/javascript">
         $(function () {
             $("#txtProName").textbox();
             $("#txtProMan").textbox();
             $('#winView').window({
                 collapsible: false,
                 minimizable: false,
                 maximizable: false,
                 modal: true
             });
             $('#winView').window('close');

         })
    </script>
      <script type="text/javascript">
          var dataGridUrl = 'users.ashx?action=dataReviewGrade';
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
                  //{ field: 'prdguid', title: '产品ID', width: 80, hidden: true },
                        {field: 'grade', title: '等级', width: 100 },
                        { field: 'integral', title: '等级积分', width: 100 },
                        { field: 'reviewreward', title: '评审区奖励积分值', width: 150, align: 'right' },
                        { field: 'commissionratio1', title: '佣金比例1', width: 100, align: 'right' },
                        { field: 'commissionratio2', title: '佣金比例2', width: 100, align: 'right' },
                        { field: 'commissionratio3', title: '佣金比例3', width: 100, align: 'right' },                     
                        {
                            field: '_edit', title: 'Operation', width: 150, formatter: function (value, row) {
                                return "<a href='javascript:void(0)'  dbkey='" + row.guid + "' onclick=Edit(this)>Edit</a>&nbsp;&nbsp;<a href='javascript:void(0)' dbkey='" + row.guid + "' onclick=Delete(this)>Delete</a>"
                            }
                        }
                    ]]
              }).datagrid('getPager'); // get the pager of datagrid
          })


          function Delete(obj) {
              if (confirm("Confirm to delete selected product？")) {
                  var proid = $(obj).attr("dbkey");

                  if (proid.length > 0) {
                      //                    var res = TweebaaWebApp.Mgr.proManager.proPublicJudgeMgr.DeletePrd(proid).value;
                      //                    if (res == "success") {
                      //                        alert("Delete Success！");
                      //                        _search();
                      //                    }
                      //                    if (res == "fail") {
                      //                        alert("Delete Fail！");
                      //                    }
                      //                    if (res == "error") {
                      //                        alert("Server Error，Delete Fail！");
                      //                    }
                  }
              }

          }

          function Edit(obj) {
              var guid = $(obj).attr("dbkey");
              $('#winView').window('open');
          }

          function DoublePoints() {
              var res = TweebaaWebApp.Mgr.userMgr.reviewGradeParam.DoublePoints().value;
              if (res == "success") {
                  alert("Success");
                  $("#btnDouble").attr("disabled", false); 
              } else {
                  alert("Fail");
              }

          }
        
    </script>
    </form>
</body>
</html>
