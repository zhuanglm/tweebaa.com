<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admOrderSend.aspx.cs" Inherits="TweebaaWebApp.Manage.admOrderSend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/orderCss/order.css" rel="stylesheet" type="text/css" />
</head>
<body class="body">
    <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
       <div class="poptrade">
        <div id="fororder" class="bk">
          
                    <table class="tableStyle">
                        <thead>
                            <tr>
                                <th colspan="4">
                                    订单信息
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td width="11%">
                                    订单编号：
                                </td>
                                <td width="22%">    
                                <asp:Label ID="labCode" runat="server"></asp:Label>
                                </td>
                                <td width="15%">
                                    订单生成时间：
                                </td>
                                <td align="left">
                                <asp:Label ID="labBegin" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="11%">
                                    商品费用：
                                </td>
                                <td width="22%">
                                  <asp:Label ID="labSum" runat="server"></asp:Label> ￥
                                </td>
                                <td width="15%">
                                    快递费用：
                                </td>
                                <td align="left">
                                      <asp:Label ID="labLogistics" runat="server" Text="0"></asp:Label> ￥
                                </td>
                            </tr>
                          <%--  <tr>
                                <td width="11%">
                                    满减优惠：
                                </td>
                                <td width="22%">
                                </td>
                                <td width="15%">
                                    优惠券：
                                </td>
                                <td align="left">
                                </td>
                            </tr>--%>
                           <%-- <tr>
                                <td width="11%">
                                    上次改价：
                                </td>
                                <td width="22%">
                                <asp:Label ID="labUpPriceTime" runat="server"></asp:Label>
                                </td>
                                <td width="15%">
                                    改价备注：
                                </td>
                                <td align="left">
                                <asp:Label ID="labUpMessage" runat="server"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr>
                                <td width="11%">
                                    最终结算：
                                </td>
                                <td colspan="3">
                                  <asp:Label ID="txtAmount" runat="server"></asp:Label>
                                  <%--  <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>--%>
                                     ￥
                                </td>
                            </tr>
                          
                        </tbody>
                    </table>
               
                
             
                    <table class="tableStyle">
                        <thead>
                            <tr>
                                <th colspan="4">
                                    订单信息
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td width="11%">
                                    收货人：
                                </td>
                                <td  colspan="3">
                                <asp:Label ID="labReciveName" runat="server"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr>
                                <td width="11%">
                                    买家选择：
                                </td>
                                <td width="22%">
                                    顺丰快递
                                </td>
                                <td width="15%">
                                    买家留言：
                                </td>
                                <td align="left">
                                    
                                </td>
                            </tr>
                            <tr>
                                <td width="11%">
                                    物流公司：
                                </td>
                                <td  colspan="3">
                                 <asp:DropDownList ID="droWuliu" runat="server">
                                   <asp:ListItem Value="040efbee-6ddc-4f9a-ae80-be7f04c318f0">顺丰快递</asp:ListItem>
                                   <asp:ListItem>圆通快递</asp:ListItem>
                                   <asp:ListItem>申通快递</asp:ListItem>
                                 </asp:DropDownList>
                                </td>
                                
                            </tr>
                            <tr>
                                <td width="11%">
                                    快递单号：
                                </td>
                                <td colspan="3">
                                 <%--<asp:Label ID="labExpressNo" runat="server"></asp:Label>--%>
                                 <asp:TextBox ID="txtExpressNo" runat="server"></asp:TextBox>
                                </td>                               
                            </tr>                            
                        </tbody>
                    </table>
                        
           
        </div>
      
        
         <div class="bt_bk2" >
           <asp:Button ID="btnSend" runat="server"  Text=" 发 货 " CssClass="bt_style" OnClick="btnSend_Click" />          
           <%--<asp:Button ID="btnClose" runat="server"  Text=" 关 闭 " CssClass="bt_style" />--%>
        </div>
    </div>
     </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
