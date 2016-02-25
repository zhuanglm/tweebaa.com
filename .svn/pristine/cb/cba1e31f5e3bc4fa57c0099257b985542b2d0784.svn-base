<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="TweebaaWebApp2.Checkout.OrderConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
<!-- CSS Global Compulsory -->
<link rel="stylesheet" href="/css/pages/page_404_error.css">
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

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">


 <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Order Confirmation</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="/index.aspx">Home</a></li>
                <li><a href="#">Pages</a></li>
                <li class="active">Order Confirmation</li>
            </ul>
        </div> 
    </div><!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->  
        
      <!--=== Content Part ===-->
    <div class="container content">		
        <!--Error Block-->
        <div class="row">
            <div class="col-md-7 col-md-offset-2" style="<%=messageDisplay%>">
                <div class="error-v1">
                 <span>Thank you, your order has been placed.</span> 
               <span class="error-v1-title2 "> <img src="/images/mascot_confirm.png"></span>

                <h3>
                        An email confirmation has been sent to you.<br />
                        <br />
                        Order Number:
                        <%=out_trade_no%><br />
                 </h3>
               <!--
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>First Name</th>
                            <th class="hidden-sm">Last Name</th>
                            <th>Username</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1</td>
                            <td>Mark</td>
                            <td class="hidden-sm">Otto</td>
                            <td>@mdo</td>
                             <td>@fat</td>                       
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Jacob</td>
                            <td class="hidden-sm">Thornton</td>
                            <td>@fat</td>
                             <td>@fat</td>                          
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>Larry</td>
                            <td class="hidden-sm">the Bird</td>
                            <td>@twitter</td>
                             <td>@fat</td>                        
                        </tr>
                        <tr>
                            <td>4</td>
                            <td>htmlstream</td>
                            <td class="hidden-sm">Web Design</td>
                            <td>@htmlstream</td>
                             <td>@fat</td>                          
                        </tr>
                    </tbody>
                </table>     
                -->
               <a class="btn-u btn-bordered" href="/index.aspx">Back Home</a></div>
               
            </div>

            <div class="col-md-7 col-md-offset-2" style="<%=messageFreeClaim%>">
            <%=strFreeClaim%>
            </div>
            
        </div>
        <!--End Error Block-->
    </div>	
    <!--=== End Content Part ===-->
</asp:Content>
