<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true" CodeBehind="admPrdSale.aspx.cs" Inherits="TweebaaWebApp.Manage.admPrdSale" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">  

      <link href="css/admin.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
 当前位置：产品管理 》产品详情| <a class="aFind" href="admPrd.aspx" target="_self">转至产品列表</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
   
    <table style="padding: 0px; margin: 0px;">
        <tr>
            <td>
                产品名称：
            </td>
            <td>
                <input id="txtName" type="text" class="t1" runat="server" />
            </td>
            <td>              
                <asp:Label ID="labUser" runat="server"></asp:Label>
            </td>
            <td>
                <input id="txtUser" type="text" class="t1" runat="server" />
            </td>
           
             <td>              
               <asp:Label ID="lanTime" runat="server"></asp:Label>
            </td>
            <td>
               从 <input id="txtDate1" type="text" class="t1" runat="server" />到
               <input id="txtDate2" type="text" class="t1" runat="server" />
            </td>
            <td style="padding-left: 5px; text-align: left;">
         
          <input type="button" id="btnSerch" runat="server" value="搜索" class="btnSerch"  onserverclick="btnSerch_Click" />
         <input type="button" id="btnAll" runat="server" value="显示全部" class="btnSerch2" style=" width:100px;" onserverclick="btnAll_Click" />
         <%-- <asp:Button ID="btnOutput" runat="server" Text="导出"  CssClass="btnSerch" OnClick="btnOutput_Click" />--%>
                 
            </td>
            <td>
            </td>
        </tr>
    </table>
   <table id="table1" cellspacing="0" cellpadding="0" border="0" class="tableStyle">
                <thead>
                    <tr>
                       <%-- <th>
                            操作
                        </th>--%>
                        <th>
                            产品名称
                        </th>
                        <th>
                            订单号
                        </th>
                        <th>
                           预订者
                        </th>
                         <th>
                           单价
                        </th>
                         <th>
                           数量
                        </th>
                        <th>
                           订单总额
                        </th>
                        <th>
                           预定时间
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repData" runat="server">
                        <ItemTemplate>
                            <tr id="workDay">
                               <%-- <td>                                   
                                    <input type="button" id="add1" onclick="" value="删除" class="input02" />
                                    <input type="button" id="Button1" onclick="" value="添加" class="input02" />
                                </td>--%>
                                <td>
                                  <%#Eval("name")%>
                                </td>
                                <td>
                                  <%#Eval("guidno")%>
                                </td>
                                <td>
                                  <%#Eval("username")%>
                                </td>
                                <td>
                                  <%#Eval("buydanJia")%>
                                </td>
                                <td>
                                  <%#Eval("quantity")%>
                                </td>
                                <td>
                                  <%#Eval("sunmAmount")%>
                                </td>
                                <td>
                                  <%#Eval("edttime")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>
