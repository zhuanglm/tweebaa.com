﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ExtraShipping.aspx.cs" Inherits="TweebaaWebApp2.Product.ExtraShipping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">
                Shipping Fee Inquiry</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="/index.aspx">Home</a></li>
                <li><a href="/Product/prdSaleAll.aspx">Product</a></li>
                <li class="active">Shipping Fee Inquiry</li>
            </ul>
        </div>
        <!--/container-->
    </div>
    <!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->
    <!--=== Content Medium Part ===-->
        <div class="shop-product">
            <div class="container">

<div id="divForm" style="display:<%=_divForm%>">
<form action="/Product/ExtraShipping.aspx?action=send" method="post">
<input type="hidden" value="<%=lblProductID %>" name="lblProductID" />
<input type="hidden" value="<%=lblShippingAddr %>" name="lblShippingAddr" />
<input type="hidden" value="<%=lblSKU %>" name="lblSKU" />

    <div id="divProduct1">Product You are interesting:<br />Product name: <%=lblProductName %>
    <br />SKU#: <%=lblSKU%><br />
    </div><br />
    <div id="divShippingAddr" style="padding:20px 0px">Your Shipping Address:<br /><%=lblShippingAddr%></div><br />
    <div>Tweebaa's Customer Service Team will be happy to provide you a shipping rate to the above address. We will respond within one business day. To continue, please confirm your click below 
    </div>
    <div style="padding:20px 0px"><input type="submit" name="submit" value="Continue" /></div>
</form>
    </div>


<div id="divMessage" style="display:<%=_divMessage%>">
 Your inquiry has been Sent!

 <div class="margin-top-20">
    <button class="btn btn-default" onclick="window.location.href='/Product/prdSaleAll.aspx'">Continue Shopping</button>
 </div>
</div>

</div>
</div>

</asp:Content>