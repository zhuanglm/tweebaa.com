<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testBuy.aspx.cs" Inherits="TweebaaWebApp.testBuy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post"> 
        <input type="hidden" name="cmd" value="_xclick"> 
        <input type="hidden" name="business" value="lcs641389097-facilitator@126.com ">
        <input type="hidden" name="item_name" value="testname">
        <input type="hidden" name="item_number" value="1"> 
        <input type="hidden" name="currency_code" value="USD">
        <input type="hidden" name="amount" value="2"> 
        <input type="hidden" name="notify_url" value="http://www.tweebaa.com/testBuyNotify.aspx" />
        <%--<input type="hidden" name="cancel_return" value="客户取消交易后返回地址" />--%>
        <input type="hidden" name="return" value="http://192.168.1.107:87/WebForm1.aspx" />
        <input type="submit" value="PayPal"> 
</form>
</body>
</html>
