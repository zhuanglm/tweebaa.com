<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="shopCart2.aspx.cs" Inherits="TweebaaWebApp2.Product.shopCart2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <!-- CSS Customization -->
    <link rel="stylesheet" href="../css/custom.css">
    <script src="../js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../MethodJs/calculate.js" type="text/javascript"></script>
    <script src="../MethodJs/buy.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">
                Check out</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="../index.aspx">Home</a></li>
                <li><a href="#">Product</a></li>
                <li class="active">Shopping cart</li>
            </ul>
        </div>
        <!--/container-->
    </div>
    <!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->
    <!--=== Content Medium Part ===-->
    <div class="content margin-bottom-30">
        <div class="container">
            <form class="shopping-cart" action="#">
            <div>
                <div class="table-responsive">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>
                                    Product
                                </th>
                                <th>
                                    Price
                                </th>
                                <th>
                                    Qty
                                </th>
                                <th>
                                    Total
                                </th>
                                <th>aaa</th>
                            </tr>
                        </thead>
                        <tbody id="tabCart">
                            <tr>
                                <td class="product-in-table">
                                    <img class="img-responsive" src="images/shopimg.jpg" alt="">
                                    <div class="product-it-in">
                                        <h3>
                                            Double-Breasted
                                        </h3>
                                        <p class="shop-red">
                                            Test-sale</p>
                                        <span class="size-label-s">S</span><span class="color_label_s"></span> <span>
                                            <button class="btn btn-xs rounded btn-default" type="button">
                                                Favorite
                                            </button>
                                        </span>
                                    </div>
                                </td>
                                <td>
                                    $ 160.00
                                </td>
                                <td>
                                    <button type='button' class="quantity-button" name='subtract' onclick='javascript: subtractQty1();'
                                        value='-'>
                                        -</button>
                                    <input type='text' class="quantity-field" name='qty1' value="5" id='qty1' />
                                    <button type='button' class="quantity-button" name='add' onclick='javascript: document.getElementById("qty1").value++;'
                                        value='+'>
                                        +</button>
                                </td>
                                <td class="shop-red">
                                    $ 320.00
                                </td>
                                <td>
                                    <button type="button" class="close">
                                        <span>&times;</span><span class="sr-only">Close</span></button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="coupon-code">
                    <div class="row">
                        <div class="col-sm-4 sm-margin-bottom-30">
                            <h3>
                                Discount Code</h3>
                            <p>
                                Enter your coupon code</p>
                            <input class="form-control margin-bottom-10" name="code" type="text">
                            <button type="button" class="btn-u btn-u-sea-shop">
                                Apply Coupon</button>
                        </div>
                        <div class="col-sm-3 col-sm-offset-5">
                            <ul class="list-inline total-result">
                                <li>
                                    <h4>
                                        Subtotal:</h4>
                                    <div class="total-result-in">
                                        <span>$ &nbsp;&nbsp;<label id="labPayMoney1" style="margin-left: -10px;"></label></span>
                                    </div>
                                </li>
                                <li>
                                    <h4>
                                        Tax:</h4>
                                    <div class="total-result-in">
                                        <span>15%</span>
                                    </div>
                                </li>
                                <li>
                                    <h4>
                                        Shipping:</h4>
                                    <div class="total-result-in">
                                        <span class="text-right">$66.99-</span>
                                    </div>
                                </li>
                                <li class="divider"></li>
                                <li class="total-price">
                                    <h4>
                                        Total:</h4>
                                    <div class="total-result-in">
                                        <span>$ 1280.00</span>
                                    </div>
                                </li>
                                <li class="total-price">
                                    <h4>
                                    </h4>
                                    <br />
                                    <div class="total-result-in" style="font: 15px;">
                                        <button type="button" class="btn-u btn-u-sea-shop" onclick="CreateOrder()">
                                            Check Out</button>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            </form>
        </div>
        <!--/end container-->
    </div>
    <!--=== End Content Medium Part ===-->
</asp:Content>
