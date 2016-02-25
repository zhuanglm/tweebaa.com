<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master" AutoEventWireup="true" CodeBehind="admPrdCate2.aspx.cs" Inherits="TweebaaWebApp.Manage.admPrdCate2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="css/prdcate/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="css/prdcate/JQuery-ui.js" type="text/javascript"></script>
    <script src="css/prdcate/JQuery.MenuTree.js" type="text/javascript"></script>
    <link href="css/prdcate/styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $('#menu1').menuTree();

            $('#menu2').menuTree({
                expandSpeed: 1000,
                collapseSpeed: 1000,
                expandEasing: 'easeOutBounce',
                collapseEasing: 'easeOutBounce',
                parentMenuTriggerCallback: false,
                multiOpenedSubMenu: true
            });
            $('#menu3').menuTree({
                expandedNode: '2.1'
            }, function (rel) {
                alert(rel);
            });
        });
    </script>
    <script type="text/javascript">
        function redic() {

        }
        function delePcat(id) {

            var hidID = document.getElementById("<%=hidID.ClientID %>");
            hidID.value = id;
            //alert(hidID.value);
            document.getElementById("<%=delebtn.ClientID %>").click();

        }
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
    当前位置：类别管理 》类别列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <ul id="browser" class="filetree">
    </ul>
    <div style="width: 100%; text-align: left">
        <a href="admPrdCateAdd.aspx" class="btnSerch" style="color: White; line-height: 30px;
           padding:10px 20px; width: 70px;">添加类别</a>
     
    </div>
       <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div id="menu2" class="menuTree">
                <ul>
                    <div style="float: left; width: 900px; height: 30px; padding-left: 0px; font-size: 17px;
                        font-weight: bolder; background: #EBF0F4;">
                        <div style="float: left; width: 300px;">
                            操作</div>
                        <div style="float: left; width: 300px;">
                            名称</div>
                        <div style="float: left; width: 300px;">
                            排序</div>
                    </div>
                    <asp:Repeater runat="server" ID="rptypelist1" OnItemDataBound="rptypelist_ItemDataBound">
                        <ItemTemplate>
                            <li class="parent"><a style="cursor: pointer;">
                                <div style="float: left; width: 900px; height: 30px; border-bottom: 1px dashed #CCC;">
                                    <div style="float: left; width: 300px;">
                                        <img src="css/edit.png" onclick="window.open('admPrdCateAdd.aspx?prtGuid=<%#Eval("prtGuid") %>&guid=<%#Eval("guid")%>&layer=<%#Eval("layer")%>'); "
                                            style="cursor: pointer;" />
                                        <img src="css/delete.png" onclick="delePcat('<%#Eval("guid") %>')" style="cursor: pointer;" />
                                    </div>
                                    <div style="float: left; width: 300px; cursor: pointer;">
                                        <%#Eval("name")%></div>
                                    <div style="float: left; width: 300px; cursor: pointer;">
                                        <%#Eval("idx") %></div>
                                </div>
                            </a>
                                <ul>
                                    <asp:Repeater runat="server" ID="rptypelist2" OnItemDataBound="rptypelist2_ItemDataBound">
                                        <ItemTemplate>
                                            <li class="parent"><a class="parent" href="#">
                                                <div style="float: left; width: 900px; height: 30px; border-bottom: 1px dashed #CCC;">
                                                    <div style="float: left; width: 300px;">
                                                        <img src="css/edit.png" onclick="window.open('admPrdCateAdd.aspx?prtGuid=<%#Eval("prtGuid") %>&guid=<%#Eval("guid") %>&layer=<%#Eval("layer")%>');"
                                                            style="cursor: pointer;" />
                                                        <img src="css/delete.png" onclick="delePcat('<%#Eval("guid") %>')" style="cursor: pointer;" /></div>
                                                    <div style="float: left; width: 280px; padding-left: 20px; cursor: pointer;">
                                                        <%#Eval("name")%></div>
                                                    <div style="float: left; width: 280px; padding-left: 20px; cursor: pointer;">
                                                        <%#Eval("idx") %></div>
                                                </div>
                                            </a>
                                                <ul>
                                                    <asp:Repeater runat="server" ID="rptypelist3">
                                                        <ItemTemplate>
                                                            <li class="child"><a href="#">
                                                                <div style="float: left; width: 900px; height: 30px; border-bottom: 1px dashed #CCC;">
                                                                    <div style="float: left; width: 300px;">
                                                                        <img src="css/edit.png" onclick="window.open('admPrdCateAdd.aspx?prtGuid=<%#Eval("prtGuid") %>&guid=<%#Eval("guid")%>&layer=<%#Eval("layer")%>');"
                                                                            style="cursor: pointer;" />
                                                                        <img src="css/delete.png" onclick="delePcat('<%#Eval("guid") %>')" style="cursor: pointer;" /></div>
                                                                    <div style="float: left; width: 260px; padding-left: 40px; cursor: pointer;">
                                                                        <%#Eval("name")%></div>
                                                                    <div style="float: left; width: 260px; padding-left: 40px; cursor: pointer;">
                                                                        <%#Eval("idx") %></div>
                                                                </div>
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                            </li>
                                            </ul> </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <input type="button" id="delebtn" runat="server" onserverclick="delete_click" style="display: none;" />
            <input type="hidden" id="hidID" runat="server" />         
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>
