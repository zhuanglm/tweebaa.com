<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admOrderUpPrice.aspx.cs" Inherits="TweebaaWebApp2.Mgr.orderMgr.admOrderUpPrice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>   
    <link href="../css/order.css" rel="stylesheet" type="text/css" />
</head>
<body class="body" style="overflow:hidden;">
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
                                <td width="10%">
                                    Order ID：
                                </td>
                                <td width="20%">
                                <asp:Label ID="labCode" runat="server"></asp:Label>
                                </td>
                                <td width="15%">
                                    Order Time：
                                </td>
                                <td align="left">
                                 <asp:Label ID="labBegin" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="10%">
                                    Product Charges：
                                </td>
                                <td width="20%">
                                   <asp:Label ID="labSum" runat="server"></asp:Label> ￥
                                </td>
                                <td width="15%">
                                    Shipping Charges：
                                </td>
                                <td align="left">
                                    <asp:Label ID="labLogistics" runat="server" Text="0"></asp:Label> ￥
                                </td>
                            </tr>
                           <%-- <tr style=" visibility:hidden;">
                                <td width="10%">
                                    满减优惠 (Discount)：
                                </td>
                                <td width="20%">
                                </td>
                                <td width="15%">
                                    Coupon：
                                </td>
                                <td align="left">
                                </td>
                            </tr>--%>
                            <tr id="trUpdate" runat="server">
                                <td width="10%">
                                    Previous Price Change：
                                </td>
                                <td width="20%">
                                <asp:Label ID="labUpPriceTime" runat="server"></asp:Label>
                                </td>
                                <td width="15%">
                                    Price Change Remark：
                                </td>
                                <td align="left">
                                <asp:Label ID="labUpMessage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="10%">
                                    <em>*</em>Grand Total：
                                </td>
                                <td colspan="3">
                                     <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                                     $
                                </td>
                            </tr>
                            <tr id="trHide" runat="server">
                                <td width="10%">
                                    <em>*</em>Price Change Remark：
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtUpPriceMessage" runat="server"></asp:TextBox>
                                   
                                </td>
                            </tr>
                        </tbody>
                    </table>
                
        </div>      
        
         <div class="bt_bk2" >
           <asp:Button ID="btnUpPrice" runat="server"  Text=" Price Change " CssClass="bt_style" OnClick="btnUpPrice_Click" />
           <asp:Button ID="btnUpPay" runat="server"  Text=" Payment " CssClass="bt_style" OnClick="btnUpPay_Click" />

         <%-- <asp:Button ID="btnUpClose" Text=" Close " runat="server" CssClass="bt_style" OnClientClick="closeBox()" />--%>
         
        </div>
    </div>
     </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
<script type="text/javascript">
    function closeBox() {
        //        $('.webox', parent.document).css({ display: 'none' });
        //        $('.background').css({ display: 'none' });

    }



    //    在iframe中获取父窗口的元素
    //格式：$('#父窗口中的元素ID', parent.document).click();
    //实例：$('#btnOk', parent.document).click();
</script>
