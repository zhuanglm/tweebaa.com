<%@ Page Title=""  Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true" CodeBehind="admPrdReview.aspx.cs" Inherits="TweebaaWebApp2.Manage.admPrdReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
 <table style="padding: 0px; margin: 0px;">
        <tr>
            <td>
                产品名称：
            </td>
            <td>
                <input id="txtName" type="text" class="t1" runat="server" />
            </td>
           <%-- <td>
                评审者：
            </td>
            <td>
                <input id="txtUser" type="text" class="t1" runat="server" />
            </td>--%>
            <td>
             评审类型：           
            </td>
            <td>
              <asp:DropDownList ID="ddlType" runat="server"  AutoPostBack="false"
                    onselectedindexchanged="ddlType_SelectedIndexChanged">
                <asp:ListItem Value="">全部</asp:ListItem>
                <asp:ListItem Value="0">支持</asp:ListItem>
                <asp:ListItem Value="1">反对</asp:ListItem>                
              </asp:DropDownList>
            </td>
             <td>
               评审时间：
            </td>
            <td>
               从 <input id="txtDate1" type="text" class="t1" runat="server" onclick="WdatePicker()" />到
               <input id="txtDate2" type="text" class="t1" runat="server" onclick="WdatePicker()"  />
            </td>
            <td style="padding-left: 5px; text-align: left;">
         <input type="button" id="btnSerch" runat="server" value="搜索" class="btnSerch" onserverclick="btnSerch_Click" />
         <%-- <asp:Button ID="btnSerch" runat="server" Text="搜索" CssClass="btnSerch" OnClick="btnSerch_Click" />--%>
          <asp:Button ID="btnAll" runat="server" Text="查看所有产品评审" CssClass="btnSerch2" OnClick="btnAll_Click" />
       
         <%-- <asp:Button ID="btnOutput" runat="server" Text="导出"  CssClass="btnSerch" OnClick="btnOutput_Click" />--%>
        
         
         
            </td>
            <td>
            </td>
        </tr>
    </table>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    
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
                           评审用户
                        </th>
                         <th>
                           评审类型
                        </th>
                         <th>
                           内容
                        </th>
                        <th>
                           评审时间
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repData" runat="server">
                        <ItemTemplate>
                              <tr>
                               <%-- <td>                                   
                                    <input type="button" id="add1" onclick="" value="删除" class="input02" />
                                    <input type="button" id="Button1" onclick="" value="添加" class="input02" />
                                </td>--%>
                                <td>
                                  <%#Eval("name")%>
                                </td>
                                <td>
                                  <%#Eval("username")%>
                                </td>
                                <td>
                                  <%#Eval("cmdtype")%>
                                </td>
                                <td>
                                  <%#Eval("cmdtxt")%>
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