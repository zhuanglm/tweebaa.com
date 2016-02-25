<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usersView.aspx.cs" Inherits="TweebaaWebApp2.Mgr.userMgr.usersView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
</head>
<body style="padding: 2px;">
    <form id="form1" runat="server">
        <div id="tt" class="easyui-tabs" data-options="fit:true" style="height:500px;">
            <div title="Basic Information" style="padding: 2px;">
                <table class="tbtable" style="width:450px;">
                    <tr>
                        <td class="title" style="width: 100px;">Member Name：
                        </td>
                        <td style="width: 250px;">
                            <asp:Label ID="labName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="title" style="width: 100px;">Email：
                        </td>
                        <td style="width: 180px;">
                            <asp:Label ID="labEmail" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="title" style="width: 100px;">Gender：
                        </td>
                        <td style="width: 180px;">
                            <asp:Label ID="labSex" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="title" style="width: 100px;">Contact Method：
                        </td>
                        <td style="width: 180px;">
                            <asp:Label ID="labPhone" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="title" style="width: 100px;">Date of Birth：
                        </td>
                        <td style="width: 180px;">
                            <asp:Label ID="labBirthday" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                   
                    <tr>
                        <td class="title" style="width: 100px;">Recent Login Time：
                        </td>
                        <td style="width: 180px;">
                            <asp:Label ID="labLoginTime" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="title" style="width: 100px;">Registration Time：
                        </td>
                        <td style="width: 180px;">
                            <asp:Label ID="labRegTime" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    
                </table>
            </div>
            <div title="发布记录" data-options="closable:false" style="overflow: auto; ">
               <fieldset>
        <legend>Condition Search</legend>
        <table class="tbtable" style="width:100%;">
            <tr>
                <td class="title" style="width:80px;">
                    Product Name：
                </td>
                <td style="width:120px;">
                    <input type="text" id="PublistProName" maxlength="30" />
                </td>
                <td class="title" style="width:80px;">
                    Status：
                </td>
                <td style="width:120px;">
                    <select id="PublishState" style="width:120px;"></select>
                </td>
                <td class="title">Registration Time：</td>
                <td style="width:350px;">
                    From：<input type="text" id="PublistStartTime" class="date"  />
                    To：<input type="text" id="PublistEndTime" class="date"   /> 
                </td>
                <td>
                    <a id="A1" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" onclick="_Publishsearch()">Search</a> 
                </td>
            </tr>
        </table>
    </fieldset>

    <div style=" margin:2px;">
   <table id="dg_pubsh" title="Member List" style="width:100%;height:335px"></table>
   </div>

                <script type="text/javascript">
                    $(function () {
                        $("#PublistProName").textbox();
                        $("#PublishState").combobox({
                            valueField: 'value',
                            textField: 'text',
                            data: eval(<%=_publishStatus%>)
                        });
                        $(".date").datebox();
                    })
                </script>

            </div>

            <!--发布结束-->


            <div title="Member Evaluation Record" data-options="closable:false" style="padding: 20px; ">
                tab3    
            </div>
            <div title="Member Share Record" data-options="closable:false" style="padding: 20px; ">
                tab3    
            </div>
            <div title="Member Commission Record" data-options="closable:false" style="padding: 20px; ">
                tab3    
            </div>
        </div>


    </form>
</body>
</html>
