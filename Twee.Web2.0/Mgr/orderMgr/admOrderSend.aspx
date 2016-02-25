<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admOrderSend.aspx.cs" Inherits="TweebaaWebApp2.Mgr.orderMgr.admOrderSend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>   
    <link href="../css/order.css" rel="stylesheet" type="text/css" />
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
                                    Order Information
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td width="11%">
                                    Order Id：
                                </td>
                                <td width="22%">    
                                <asp:Label ID="labCode" runat="server"></asp:Label>
                                </td>
                                <td width="15%">
                                    Order time：
                                </td>
                                <td align="left">
                                <asp:Label ID="labBegin" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="11%">
                                    Product Charges：
                                </td>
                                <td width="22%">
                                  <asp:Label ID="labSum" runat="server"></asp:Label> $
                                </td>
                                <td width="15%">
                                    Shipping Charges：
                                </td>
                                <td align="left">
                                      <asp:Label ID="labLogistics" runat="server" Text="0"></asp:Label> ￥
                                </td>
                            </tr>
                          <%--  <tr>
                                <td width="11%">
                                    满减优惠(Discount)：
                                </td>
                                <td width="22%">
                                </td>
                                <td width="15%">
                                    Coupon：
                                </td>
                                <td align="left">
                                </td>
                            </tr>--%>
                           <%-- <tr>
                                <td width="11%">
                                    Previous Price Change：
                                </td>
                                <td width="22%">
                                <asp:Label ID="labUpPriceTime" runat="server"></asp:Label>
                                </td>
                                <td width="15%">
                                    Price Change Remark：
                                </td>
                                <td align="left">
                                <asp:Label ID="labUpMessage" runat="server"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr>
                                <td width="11%">
                                    Grand Total：
                                </td>
                                <td colspan="3">
                                  <asp:Label ID="txtAmount" runat="server"></asp:Label>
                                  <%--  <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>--%>
                                     $
                                </td>
                            </tr>
                          
                        </tbody>
                    </table>
               
                
             
                    <table class="tableStyle">
                        <thead>
                            <tr>
                                <th colspan="4">
                                    Order Information
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td width="11%">
                                    Recipient：
                                </td>
                                <td  colspan="3">
                                <asp:Label ID="labReciveName" runat="server"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr>
                                <td width="11%">
                                    Buyer Selection：
                                </td>
                                <td width="22%">
                                    Express
                                </td>
                                <td width="15%">
                                    Buyer Message：
                                </td>
                                <td align="left">
                                    
                                </td>
                            </tr>
                            <tr>
                                <td width="11%">
                                    Courier Companies：
                                </td>
                                <td  colspan="3">
                                 <asp:DropDownList ID="droWuliu" runat="server">
                                   <asp:ListItem Value="040efbee-6ddc-4f9a-ae80-be7f04c318f0">FedEx</asp:ListItem>
                                   <asp:ListItem>UPS</asp:ListItem>
                                   <asp:ListItem>DHL</asp:ListItem>
                                 </asp:DropDownList>
                                </td>
                                
                            </tr>
                            <tr>
                                <td width="11%">
                                    Tracking Number：
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
           <asp:Button ID="btnSend" runat="server"  Text=" Deliver " CssClass="bt_style" OnClick="btnSend_Click" />          
           <%--<asp:Button ID="btnClose" runat="server"  Text=" Close " CssClass="bt_style" />--%>
        </div>
    </div>
     </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
