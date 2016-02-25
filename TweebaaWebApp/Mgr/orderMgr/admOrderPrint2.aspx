<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admOrderPrint2.aspx.cs" Inherits="TweebaaWebApp.Mgr.orderMgr.admOrderPrint2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Print Delivery Order</title>
    <style>
     .body{ background-color:#EEF2FB}
    .td_frame{border-bottom:2px solid #000;padding:5px 0;}
	.td_frame td{padding:5px;}
	.td_frame p{height:30px;line-height:30px;}
    .tr td{border-bottom:2px solid #000;padding:5px 0;}
    
    .btn_print{background-color:#5473AE;height:26px;padding-top:5px;width:100%;text-align:center;text-decoration:none; }
    
    </style>
   
    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../js/jquery.PrintArea.js" type="text/javascript"></script>
</head>
<body class="body">
    <form id="form1" runat="server">
    
     <!--startprint-->
        <div>
            <div style="overflow: auto; overflow-x: hidden; *+height: 780px; height: 730px; width: 100%">
                <div id="myPrintArea">
                    <table class="table_frame" width="90%" cellspacing="0" cellpadding="0" border="0"
                        align="center">
                        <tr>
                            <td class="td_frame" height="100">
                            </td>
                        </tr>
                        <tr>
                            <td  style="border-bottom:2px solid #000;">
                                <table width="98%" style=" height:20px;" cellspacing="0" cellpadding="0" border="0" align="center">
                                    <tbody>
                                        <tr>
                                            <td style="height: 20px;">
                                                <h4> Order ID：<asp:Label ID="labCode" runat="server"></asp:Label></h4>
                                            </td>
                                            <td style="height: 20px;" align="left" width="30%">
                                                <h4> Order Date：<asp:Label ID="labBegin" runat="server"></asp:Label></h4>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_frame">
                                <table width="98%" cellspacing="0" cellpadding="0" border="0" align="center">
                                    <tbody>
                                        <tr class="table_data_title" height="30">
                                            <td width="10%" nowrap>
                                                No
                                            </td>
                                            <td width="10%" nowrap>
                                                Product ID
                                            </td>
                                            <td width="50%">
                                                Product Name
                                            </td>
                                            <td width="10%" nowrap>
                                                Unit Price($)
                                            </td>
                                            <td width="10%" nowrap>
                                                Quantity
                                            </td>
                                            <td width="10%" nowrap>
                                                Sub-Total($)
                                            </td>
                                        </tr>
                                         <asp:Repeater ID="repPro" runat="server">
                                        <ItemTemplate>
                                        <tr height="30">
                                          <tr height="30">
                                                <td nowrap>
                                                <%# Container.ItemIndex + 1%>
                                                </td>
                                                <td nowrap>
                                                </td>
                                                <td>
                                                <%#Eval("name") %>
                                                </td>
                                                <td nowrap>
                                                <%#Eval("buydanJia") %>
                                                </td>
                                                <td nowrap>
                                                <%#Eval("quantity") %>
                                                </td>
                                                <td nowrap>
                                                <%# Eval("proMoney") %>
                                                </td>
                                            </tr>
                                        </tr>
                                               </ItemTemplate>
                                    </asp:Repeater>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_frame">
                                <p>
                                    Recipient：<asp:Label ID="labRecive" runat="server"></asp:Label>
                                </p>
                                <p>
                                    Message：<asp:Label ID="labMessageWord" runat="server"></asp:Label>
                                </p>
                                <p>
                                    Buyer selected shipping method：
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_frame">
                                <p>
                                    Signature：
                                </p>
                            </td>
                        </tr>
                        <tr height="50">
                            <td align="right" style="padding-right: 230px;">
                                Powered by Leivaire
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
     <!--endprint-->  
        <div class="btn_print">       
        <a href="javascript:void(0);" id="btnPrint" class="btnPrint">   
            <img src="../images/btn_print.gif" style=" border:0px;" />
        </a>       
    </div>     
  
    </form>
</body>
</html>
<script type="text/javascript">
    $(function () {
        $("#btnPrint").bind("click", function () {
            $("#myPrintArea").printArea();
        });
    });  

</script> 
