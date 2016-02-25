<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master" AutoEventWireup="true" CodeBehind="admPrdCate.aspx.cs" Inherits="TweebaaWebApp.Manage.admPrdCate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
      <link href="../plugins/thems/jquery.treeview.css" rel="stylesheet" type="text/css" />
    <script src="../plugins/jquery.treeview.js" type="text/javascript"></script>
    <script src="js/admPrdCate.js" type="text/javascript"></script>
    <script src="../plugins/jquery.contextmenu.r2.js" type="text/javascript"></script>




    <link href="css/orderCss/order.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">


        function dele(id) {
            alert("aaa");

            PageMethods.DeleteCate(id, show);

        }

        function show(val) {
            //var prm = Sys.WebForms.PageRequestManager.getInstance();
            //prm._doPostBack('UpdatePanel1', '');
            //_doPostBack('UpdatePanel1', '');
            alert(val);

        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
        <ul id="browser" class="filetree">
    </ul>
    <div style="width: 100%; text-align: left">
        <a href="admPrdCateAdd.aspx">添加类别</a>
    </div>

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
      <asp:UpdatePanel runat="server" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
    <div class="poptrade" style=" background-color:White;">
        <div id="fororder" class="bk">
            <ul class="bk_1 clearfix" style=" list-style-type:none; margin-left:0px;">
                <li> 
                    <table class="hovertable" cellpadding="2" cellspacing="0" border="1">
                        <thead>
                            <tr style="background-color: #EBF0F4; height: 30px; vertical-align: middle; padding-left: 0px;">
                                <th>
                                    操作
                                </th>
                                <th>
                                    类别名称
                                </th>
                                <th style="text-align: center;">
                                    排序
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="rptypelist1" OnItemDataBound="rptypelist_ItemDataBound">
                                <ItemTemplate>
                                    <tr style="background: #F7F8F9; height: 20px;">
                                        <td width="220px" style=" padding:10px;">
                                            <a href="admPrdCateAdd.aspx?guid=<%#Eval("guid") %>" class="edit"></a> <a href="javascript:void(0);"
                                                onclick="dele('<%# Eval("guid") %>')" class="del"></a>
                                        </td>
                                        <td width="450px">
                                      
                                            &nbsp;
                                            <%#Eval("name")%>
                                        </td>
                                        <td style="">
                                            &nbsp;
                                          <span style=" margin:160px;"> <%#Eval("idx") %></span> 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="border: 0px;">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <asp:Repeater runat="server" ID="rptypelist2">
                                                    <ItemTemplate>
                                                        <tr style="height: 25px;">
                                                            <td width="220px">
                                                                <a href="admPrdCateAdd.aspx?guid=<%#Eval("guid") %>" class="edit"></a>
                                                                <a href="javascript:void(0);"  onclick="dele(<%#Eval("guid") %>)"
                                                                    class="del"></a>
                                                            </td>
                                                            <td width="451px">
                                                                &nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("name")%>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <%#Eval("idx") %>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </li>
            </ul>
        </div>
    </div>  
     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
     <div class="contextMenu" id="menu">
        <ul>
            <li class="rightmenu" id="wnstat0">编辑</li>
            <li class="rightmenu" id="wnstat1">删除</li>
            <li class="rightmenu" id="add">增加</li>
        </ul>
    </div>
    <div id="dvModel" style="display: none;">
        <table>
            <tr>
                <td>
                    category name
                </td>
                <td>
                    <input id="Text1" type="text" class="t1 txtName" />
                </td>
            </tr>
            <tr>
                <td>
                    排序
                </td>
                <td>
                    <input id="Text3" type="text" class="t1 txtIdx" />
                </td>
            </tr>
            <tr>
                <td>
                    状态
                </td>
                <td>
                    <select id="drpState" class="drpState">
                        <option value="1">正常</option>
                        <option value="0">禁用</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="javascript:void(0)" class="aAdd">Save</a> <a href="javascript:void(0)" class="aEsc">
                        Cancel</a>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
   
 
   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
       <input id="hGuid" type="hidden" />
    <input id="hGuid2" type="hidden" />
</asp:Content>
