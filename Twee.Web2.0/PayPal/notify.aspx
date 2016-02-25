<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notify.aspx.cs" Inherits="TweebaaWebApp2.Paypal.notify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Paypal Notify</title>
</head>
<body>
<script type="text/javascript">
    var isSuccess = '<%=strSuccess%>';
    if (isSuccess === 'true') {
        var id = '<%=out_trade_no%>';
        var total = <%=fOrderTotal%>;
        //var jsonData = '<%=strTransactionData%>';
        //var transdata = JSON.parse(jsonData);
        window.dataLayer = window.dataLayer || []
        dataLayer.push({
            'transactionId': id,
            'transactionTotal': total
        });

        /*
        for (var i = 0; i < transdata.length; i++) {
            var item = transdata[i];
            dataLayer.push({
                'transactionProducts': [{
                    'sku': item.sku,
                    'name': item.name,
                    'price': item.price,
                    'quantity': item.qty
                }]
            });

            console.log(item.name);
        }
        */
    }

</script>
    <!-- Google Tag Manager -->
    <noscript>
        <iframe src="//www.googletagmanager.com/ns.html?id=GTM-N8594B" height="0" width="0"
            style="display: none; visibility: hidden"></iframe>
    </noscript>
    <script>        (function (w, d, s, l, i) {
            w[l] = w[l] || []; w[l].push({ 'gtm.start':
new Date().getTime(), event: 'gtm.js'
            }); var f = d.getElementsByTagName(s)[0],
j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : ''; j.async = true; j.src =
'//www.googletagmanager.com/gtm.js?id=' + i + dl; f.parentNode.insertBefore(j, f);
        })(window, document, 'script', 'dataLayer', 'GTM-N8594B');</script>
    <!-- End Google Tag Manager -->
    <div>

    </div>

    <form id="form1" runat="server">
    </form>
</body>
</html>
