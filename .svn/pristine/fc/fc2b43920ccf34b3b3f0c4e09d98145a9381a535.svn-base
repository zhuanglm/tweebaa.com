<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admOrderPay.aspx.cs" Inherits="TweebaaWebApp.Manage.admOrderPay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/orderCss/order.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="poptrade">
        <div id="fororder" class="bk">
            <ul class="bk_1 clearfix">
                <li>
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
                                <td width="10%">
                                    订单编号：
                                </td>
                                <td width="20%">
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
                                <td width="10%">
                                    商品费用：
                                </td>
                                <td width="20%">
                                    <asp:Label ID="labSum" runat="server"></asp:Label>
                                    ￥
                                </td>
                                <td width="15%">
                                    快递费用：
                                </td>
                                <td align="left">
                                    <asp:Label ID="labLogistics" runat="server" Text="0"></asp:Label>
                                    ￥
                                </td>
                            </tr>
                            <tr style="visibility: hidden;">
                                <td width="10%">
                                    满减优惠：
                                </td>
                                <td width="20%">
                                </td>
                                <td width="15%">
                                    优惠券：
                                </td>
                                <td align="left">
                                </td>
                            </tr>
                            <tr>
                                <td width="10%">
                                    上次改价：
                                </td>
                                <td width="20%">
                                    <asp:Label ID="labUpPriceTime" runat="server"></asp:Label>
                                </td>
                                <td width="15%">
                                    改价备注：
                                </td>
                                <td align="left">
                                    <asp:Label ID="labUpMessage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="10%">
                                    <em>*</em>最终结算：
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                                    ￥
                                </td>
                            </tr>
                            <tr id="trHide" runat="server">
                                <td width="10%">
                                    <em>*</em>改价备注：
                                </td>
                                <td colspan="3">
                                    <input type="text" value="" name="editfeememo" id="editfeememo" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </li>
            </ul>
        </div>
        <div class="bt_bk2">
            <asp:Button ID="btnUpPrice" runat="server" Text=" 改 价 " CssClass="bt_style" />
            <asp:Button ID="btnUpPay" runat="server" Text=" 改 价 " CssClass="bt_style" />
            <asp:Button ID="btnUpClose" runat="server" Text=" 关 闭 " CssClass="bt_style" />
        </div>
    </div>
    </form>
</body>
</html>
