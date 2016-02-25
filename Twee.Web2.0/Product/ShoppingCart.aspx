<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="TweebaaWebApp2.Product.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <!-- Meta -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    
    

    <!-- CSS Global Compulsory -->
    <link rel="stylesheet" href="/plugins/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="/css/shop.style.css">
     
    <!-- CSS Implementing Plugins -->
    <link rel="stylesheet" href="/plugins/line-icons/line-icons.css">
    <link rel="stylesheet" href="/plugins/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="/plugins/scrollbar/src/perfect-scrollbar.css">
    <link rel="stylesheet" href="/plugins/jquery-steps/css/custom-jquery.steps.css">

   <!-- <link rel="stylesheet" href="plugins/sky-forms/version-2.0.1/css/sky-forms.css"> -->
    <link rel="stylesheet" href="/css/pages/log-reg-v3.css">  
    <!-- Style Switcher -->
    <link rel="stylesheet" href="/css/plugins/style-switcher.css">

    <!-- CSS Theme -->
    <link rel="stylesheet" href="/css/theme-colors/default.css" id="style_color">

    <!-- CSS Customization -->
    <link rel="stylesheet" href="/css/custom.css">


     <script src="../MethodJs/calculate.js" type="text/javascript"></script>
    <script src="../MethodJs/buy.js" type="text/javascript"></script>


    <script src="/MethodJs/userAddress.js" type="text/javascript"></script>
    <script src="/MethodJs/calculate.js" type="text/javascript"></script>
    <script src="/MethodJs/ExtraShipping.js" type="text/javascript"></script>
    <script src="../MethodJs/favorite.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/css/mycart-new.css" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

<input type="hidden" id="hid_previous_shoppingcart_count" /> <!-- add by Long for save shopping cart number 2015/12/30 -->
           <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Shopping Cart</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="/index.aspx">Home</a></li>
                <li><a href="#">Product</a></li>
                <li class="active">Shopping Cart</li>
            </ul>
        </div><!--/container-->
    </div><!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->

         <!--=== Content Medium Part ===-->
    <div class="content margin-bottom-30">
        <div class="container"> <div class="col-md-12">

<div role="application" class="wizard clearfix" id="steps-uid-0">
<div class="steps clearfix"><ul role="tablist"><li role="tab" class="first current" aria-disabled="false" aria-selected="true"><a id="steps-uid-0-t-0" href="javascript:void(0)" aria-controls="steps-uid-0-p-0"><span class="current-info audible">current step: </span><span class="number">1.</span> 
                     <div class="overflow-h">
                            <h2>Shopping Cart</h2>
                          <i class="fa fa-shopping-cart"></i>
                        </div>    
                    </a></li><li role="tab" class="disabled" aria-disabled="true"><a id="steps-uid-0-t-1" href="javascript:void(0)"  aria-controls="steps-uid-0-p-1"><span class="number">2.</span> 
                     <div class="overflow-h">
                            <h2>Address</h2>
                          <i class="fa fa-map-marker"></i>
                        </div>    
                    </a></li><li role="tab" class="disabled" aria-disabled="true"><a id="steps-uid-0-t-2" href="javascript:void(0)"  aria-controls="steps-uid-0-p-2"><span class="number">3.</span> 
                        <div class="overflow-h">
                        <i class="fa fa-truck"></i>
                            <h2>Confirmation</h2>
                           
                        
                        </div>    
                    </a></li><li role="tab" class="disabled last" aria-disabled="true"><a id="steps-uid-0-t-3" href="javascript:void(0)"  aria-controls="steps-uid-0-p-3"><span class="number">4.</span> 
                        <div class="overflow-h">
                            <h2>Payment</h2>
                            <i class="fa fa-money"></i>
                        </div>    
                    </a></li></ul></div>
<div class="content clearfix">
	  <div class="row" id="divTestsaleMessage" style="display:none">
                    <div class="col-md-12">
                        <div class="alert alert-warning fade in">
                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                            <h4><strong>Improntant Message!</strong> </h4>
                            <p>Test-Sale products have a test period of up to 60 days to reach a target sales number, and delivery may take up to 90 days total. 
If you order an item that does NOT reach the target, your order for that item will be cancelled and you will receive 100% refund. 
In the meantime, you can cancel any Test-Sale order up until the day we actually ship.  
</p>
  <!-- <p>
                          <a class="btn-u btn-u-xs  rounded-4x" href="#">Acknowledged </a>
                            </p> -->
                      
                        </div>
                    </div>
        
                </div>

 <form class="shopping-cart" action="#">
                <div >

                      <section>
                       <div class="table-responsive">
                        <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>
                                    Product
                                </th>
                                <th>
                                    SKU#
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
                                <th></th>
                            </tr>
                        </thead>
                                <tbody id="tabCart">
                                
                                </tbody>
                            </table>
                            
                            

                                               
                        </div>
                      

                      </section>

                </div>
            </form>
</div></div>

           
    </div>  
<div class="col-sm-4 col-sm-offset-8">                        <!--Order Summery-->
                                 <div class="cartMiniTable">
                               <!--  <h3>Summery</h3>-->  
                <table id="cart-summary" class="table">
                
                  
                    <tr>
                        <td class="tdn tdl btop" style="font-size:18px;"> Sub-Total</td>
                        <td class="tdn tdr btop" id="total-price">$<label id="labPayMoney1"></label></td>
                    </tr>
                
                </table>
                
                  
            </div></div> 
           
             <div class="col-sm-5 col-sm-offset-7 txt-right fr margin-bottom-20" >
                                     
                                             <button type="button" class="btn-u btn-u-lg btn-u-white rounded-4x" onclick="window.location.href='/Product/prdSaleAll.aspx'">
                               Continue Shopping</button>
                                               <button type="button" class="btn-u btn-u-lg btn-u-orange rounded-4x " onclick="Loading(true);CreateOrder2Shipping();">
                                            Process To Checkout</button>
</div>
             
      
      </div><!--/end container-->
    </div>
    <!--=== End Content Medium Part ===-->     


<script type="text/javascript" src="/plugins/sky-forms/version-2.0.1/js/jquery.validate.min.js"></script>
<!-- Master Slider -->
<script type="text/javascript" src="/plugins/master-slider/quick-start/masterslider/masterslider.min.js"></script>
<script src="/plugins/master-slider/quick-start/masterslider/jquery.easing.min.js"></script>
<!-- Scrollbar -->
<script src="/plugins/scrollbar/src/jquery.mousewheel.js"></script>
<script src="/plugins/scrollbar/src/perfect-scrollbar.js"></script>
<script src="/plugins/jquery.parallax.js"></script>

<!-- JS Customization -->
<script src="/js/custom.js"></script>
<!-- JS Page Level -->
<script src="/js/shop.app.js"></script>


<script src="/js/forms/product-quantity.js"></script>
<script type="text/javascript" src="/js/plugins/style-switcher.js"></script>
<script>
    jQuery(document).ready(function () {
        App.init();

        StyleSwitcher.initStyleSwitcher();

    });
</script>
<!--[if lt IE 9]>
    <script src="plugins/respond.js"></script>
    <script src="plugins/html5shiv.js"></script>
    <script src="js/plugins/placeholder-IE-fixes.js"></script>
<![endif]-->

<script type="text/javascript">


  


    $(".show-all-address").find("li").mouseenter(function (event) {
        $(this).addClass('on')
    }).mouseleave(function (event) {
        $(this).removeClass('on')
    });

    //物流选择 
    $(".select-wuliu .showUl").click(function (event) {
        $(this).siblings('ul').show();
    });

    $(".select-wuliu").mouseleave(function (event) {
        $(this).find("ul").hide();
    });

    function EnableGotoPayButton() {
        $(".gotoPay").html("Agree & Proceed to Payment &nbsp;&nbsp;");
        $(".gotoPay").removeAttr("disabled");
        $("#btnCheckout").removeClass("btnDisabled");
    }
 

  
    function GoBack() {
        window.location.href = "../Product/ShoppingCart.aspx";
    }
    $("#hid_previous_shoppingcart_count").val($("#labCartCount").html());
    </script>


</asp:Content>
