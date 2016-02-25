﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="shop-zone.aspx.cs" Inherits="TweebaaWebApp2.College.shop_zone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
<!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Shop Zone</h1>
            <ul class="pull-right breadcrumb">
             <li><a href="/index.aspx">Home</a></li>
                <li><a href="/College/Education.aspx">Education</a></li>
                <li class="active">Shop</li>
            </ul>
        </div> 
    </div><!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->  
         <!--=== Search Block Version 2 ===-
    <div class="search-block-v2">
        <div class="container">
            <div class="col-md-6 col-md-offset-3">
                <h2>Search</h2>
                <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search words with regular expressions ...">
                    <span class="input-group-btn">
                        <button class="btn-u" type="button"><i class="fa fa-search"></i></button>
                    </span>    
                </div>
            </div>
        </div>    
    </div>  -->     
    <!--=== End Search Block Version 2 ===-->
      <!--=== Content Part ===-->
    <div class="container content">	
   <div class="row"> 
     	<div class="col-md-3">
             <!--new drop down catoryies-->
                <div class="panel-group" id="accordion-v2">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h2 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion-v2" href="#collapseTwo">
                                    TWEEBAA PROCESS
                                    <i class="fa fa-angle-down"></i>
                                </a>
                            </h2>
                        </div>
                  
                            <div id="collapseCategory" class="panel-collapse collapse in">
                        <div class="panel-body">
                            <ul class="nav nav-pills nav-stacked tree">
                                <li class="active dropdown-tree open-tree"><a class="dropdown-tree-a">  Suggest Zone</a>
                                   <ul class="category-level-2 dropdown-menu-tree">
                                        <li><a href="/College/Suggest-zone.aspx#collapseOne">
                                           About the Suggest Zone</a>
                                       
                      <li><a href="/College/Suggest-zone.aspx#collapseTwo">Suggest Zone Reward Points</a></li>
                    <li><a href="/College/Suggest-zone.aspx#collapseFour">Suggest Detail</a></li>
                    <li><a href="/College/Suggest-zone.aspx#collapseFive">How to select products for Tweebaa</a></li>
                    <li><a href="/College/Suggest-zone.aspx#collapseSix">Preparing your submission</a></li>
                    <li><a href="/College/Suggest-zone.aspx#collapseSeven">Suggest steps</a></li>
                    <li><a href="/College/Suggest-zone.aspx#collapseEight">Product Guidelines</a></li>
                                       
                                    </ul>
                                </li>
                                  <li class="active dropdown-tree open-tree"><a class="dropdown-tree-a">  Evaluate Zone</a>
                                   <ul class="category-level-2 dropdown-menu-tree">
                                        <li><a href="/College/evaluate-zone.aspx#collapseOne">
                                         About the EVALUATE Zone</a></li>    
                     <li><a href="/College/evaluate-zone.aspx#collapseTwo">Evaluate Zone Reward Points</a></li>
                    <li><a href="/College/evaluate-zone.aspx#collapseFour">Gift Rewards</a></li>
                    <li><a href="/College/evaluate-zone.aspx#collapseFive">How to Evaluate</a></li>
                    <li><a href="/College/evaluate-zone.aspx#collapseSix">Become an "expert" Evaluator</a></li>
                    <li><a href="/College/evaluate-zone.aspx#collapseSeven">Evaluator Rules</a></li>
                                       
                                    </ul>
                                </li>
                                             <li class="active dropdown-tree open-tree"><a class="dropdown-tree-a">Shop Zone</a>
                                   <ul class="category-level-2 dropdown-menu-tree">
                                        <li><a href="/College/shop-zone.aspx#collapseOne">
                                         About the SHOP Zone</a> </li>
                                       
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseTwo">Shop Details</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseThree">More about “Test-Sale”</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseFour">Payment Options</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseFive">Return Policies</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseSix">Cancellation Policy</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseEight">Wholesale Orders</a></li>
                                       
                                    </ul>
                                </li>

                                 <li class="active dropdown-tree open-tree"><a class="dropdown-tree-a">  Share Zone</a>
                                   <ul class="category-level-2 dropdown-menu-tree">
                                        <li><a href="/College/share-zone.aspx#collapseOne">
                                         About Share Zone</a>
                                            
                                        </li>
                   
                     <li><a href="/College/share-zone.aspx#collapseTwo">Share Zone Reward Points</a></li>
                    <li><a href="/College/share-zone.aspx#collapseFour">What is Share & Earn？</a></li>
                    <li><a href="/College/share-zone.aspx#collapseFive">How to Share & Earn</a></li>
                    <li><a href="/College/share-zone.aspx#collapseSix">How to Share a Purchase</a></li>
                    <li><a href="/College/share-zone.aspx#collapseSeven">Who else benefits from Sharing?</a></li>
                    <li><a href="/College/share-zone.aspx#collapseEight">Become an "Expert" Sharer</a></li>
                    <li><a href="/College/share-zone.aspx#collapseNight">Share examples</a></li>
                
                                       
                                    </ul>
                                </li>
                               
                            </ul>
                        </div>
                    </div>
                        <!--new drop down catoryies end-->
                    </div>
                </div><!--/end panel group-->
                <!-- End Contacts -->
            </div><!--/col-md-3-->
			
            <div class="col-md-9">
			
				
                <div class="panel-group acc-v1 margin-bottom-40" id="accordion">
			
				
                    <div class="panel panel-default">
					
                        <div class="panel-heading">
						
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseOne">
                                     <dt class="p4"><span class="icon"></span>About the SHOP Zone</dt>
                                </a>
                            </h4>
							
                        </div>
						
                        <div id="collapseOne" class="panel-collapse collapse in">
                            <div class="panel-body">
            
                    <h5><strong>Browse the Tweebaa Shop. Find cool products and great prices.</strong></h5>
                    <br />
                        <p span class="black"><strong>COOL PRODUCTS.</strong></p>
                        <p>Tweebaa products come from Tweebaa members. Members (like YOU) can VOTE on products
                        that you want to see in our store (see <a href="https://www.tweebaa.com/Product/prdReviewAll.aspx">Evaluate Zone</a>). Once a product
                        receives enough votes to advance to the Test-Sale stage, it is offered in limited
                        quantity as a further test. If enough shoppers purchase, the product is a WINNER
                        and advances to the Tweebaa Shop. YAY! A new product is born! Shop at Tweebaa and
                        you'll be on the cutting edge of new products.</p>
                       
                        <p span class="black"><strong>GREAT PRICES.</strong></p>
                        <p>At Tweebaa, our products are offered direct from the manufacturers... to you. We
                        eliminate the extra costs that other "middlemen" (like retailers) add.</p>

                        <p span class="black"><strong>SHARE & EARN.</strong></p>
                        <p>Perhaps the most exciting part of shopping on Tweebaa is sharing great products
                        with your friends and earning income. It may seem like a dream-come-true to shop
                        and earn money at the same time! Click here to learn more about earning money in
                        our <a href="https://www.tweebaa.com/Product/prdSingleShare.aspx">Share Zone.</a>
         
                        <p span class="black"><strong>TEAM TWEEBAA.</strong></p>
                        <p>Don’t forget that Tweebaa members benefit whenever a sale is made. Suggestters, Evaluators,
                        and Sharers (that’s You!) earn income on every purchase from the Tweebaa Shop. Everybody
                        Earns at Tweebaa!</p>

                
							</div>
                     </div>
                    </div>

					
					
					
					
					
					
                    <div class="panel panel-default">
					
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                                <dt class="p4"><span class="icon"></span>Shop Details</dt>
								</a>
                            </h4>
                        </div>
						
                        <div id="collapseTwo" class="panel-collapse collapse">
						
                            <div class="panel-body">

                
                    <h5><strong>The Tweebaa Shop is a great place to find new and unique products…</strong></h5>

               
                        <table width="100%" cellpadding="0" cellspacing="0" border="0" class="table-4">
                            <tbody>
                                <tr>
                                    <td style="width: 50%;">
                                        <strong class="black">BUY NOW ITEMS</strong>
                                    </td>
                                    <td>
                                        <strong class="black">TEST-SALE ITEMS</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        These items have garnered enthusiastic support from our evaluators and received
                                        our Tweebaa ‘seal of approval’ for quality and pricing. Backed by our 7-day guarantee,
                                        you can rest assured that you will be completely satisfied with your purchase or
                                        your money back!
                                    </td>
                                    <td>
                                        For an exclusive look at upcoming items, visit the Test-Sale area for limited-time
                                        deals! Test-Sale items must sell a certain quota within 60 days in order to advance
                                        to the Tweebaa Shop. Each Test-Sale purchase is a step towards becoming “Tweebaa
                                        Approved” and reaching the Tweebaa Shop.
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="img"><img src="../images/college/twe_approve.png" width="151" height="151"></div>
                                    </td>
                                    <td>
                                       <div id="img"> <img src="../images/college/hour_glass2.png" width="151" height="151"></div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                   
                    <br />
                
							
							
                            </div>
                        </div>
						
                    </div>

					
					
					
					
					
					
					
					
					
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseThree">
                                           <dt class="p4"><span class="icon"></span>More about “Test-Sale”</dt>
                                </a>
                            </h4>
                            
                        </div>
                        <div id="collapseThree" class="panel-collapse collapse">
                            <div class="panel-body">



                      
                    <p>If you want to have a sneak-peek at brand new Tweebaa items, check out
                        the “Limited-Time” products in the Tweebaa Shop.</p>
						
                    <p>Test-Sale items only have 60 days to meet a pre-set sales quota. Each
                        unit purchased is a step closer to reaching quota and will help determine if the
                        item is a "Pass" (and is added to the Tweebaa Shop).
                        </p>
                   
					
                    <span style="width: 45%; float: left;">
                        <img src="../images/college/shop-edu1.png" width="90%" ></span> <span style="width: 55%;float: left;"><span class="black">
                            <br />
                             <strong>TEST-SALE “PASSED” = Tweebaa Approved</strong></span><br />
                            <br />
                            If the Test-Sale quota is met in the designated time frame (60 days), the test sale
                            is a PASS and all the test-sale orders are ON (test-sale orders will be shipped;
                            ship time may extend 30-60 days after the Test-Sale goal is reached). Tweebaa will
                            notify buyers as soon as the 60-day time frame is over, and if Test-Sale is “Pass”,
                            we will provide an approximate ship date.
                            <br />
                            <br />
                            <span class="p17"><strong>TIPS:</strong> As a Tweebaa member, you can support Test-Sale
                                items that you like by SHARING them with your friends. And remember, if you share
                                and your friends purchase Tweebaa products from your shared link, you can also earn
                                rewards! (Learn more about <a href="#">Share Zone.</a>)</span><br />
                            <br />
                            After a Test-Sale item reaches the quota, it may take 30-60 days to bring inventory
                            to Tweebaa. During this delayed period, <span class="red">we will continue taking orders
                                and honor the limited-time Test-Sale pricing.</span><br />
                            <br />
                            <span class="black">
                                <br />
                                <strong>TEST-SALE “FAILED” </strong></span>
                            <br />
                            <br />
                            If the Test-Sale quota is NOT met in the designated time, the test sale is a FAIL
                            and all test-sale orders will be cancelled. <span class="red">Buyers will receive full
                                refunds of the purchase price. </span>Tweebaa will notify buyers as soon as
                            the 60-day time frame is over.<br />
                            If you order an item while it is in the Test-Sale stage, you may cancel the order
                            at any time, for any reason. (For further details on how to cancel an order, see
                            <a href="#">link to below info “Cancellation Policy”</a>). Keep in mind: a canceled
                            order is a canceled vote in support of the item. </span></li>
                    <br />
                    
               
                               
                            </div>
                        </div>
                    </div>

					
					
					
					
					
					
					
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseFour">
                                    <dt class="p4"><span class="icon"></span>Payment Options</dt></a>
                            </h4>
                        </div>
                        
                        <div id="collapseFour" class="panel-collapse collapse">
                            <div class="panel-body">
							

							          
                    <p  span style="color:#0066cc;"><strong>Credit Card</strong></p>
                        <p>Tweebaa accepts most major credit cards including Mastercard, Visa, Discover, and
                        American Express. If you prefer, you may pay with an existing PayPal account. All
                        payments are processed securely using PayPal merchant services. Tweebaa does NOT
                        store any of your credit-card information.</p>

                        <p span style="color:#0066cc;"><strong>TweeBucks</strong></p>
                        <p>If you have earned TweeBucks through Suggesting, evaluating or sharing Tweebaa products,
                        you may apply them JUST LIKE CASH at checkout.For more information about earning
                        commissions/Tweebucks, see <a href="/College/comission_chart.aspx">Commission Rewards</a>.</p>

                        <p span style="color:#0066cc;"><strong>Shopping Reward Points</strong></p>
                        <p>If you are a Tweebaa member, you can earn Shopping Reward Points with every purchase.
                        Those points may be redeemed at checkout (400 points = $5.00). For more information
                        about Shopping Reward Points, see <a href="/College/shopping_reward.aspx">Shopping Reward Points</a>.</p>

  
                            </div>
                        </div>
                    </div>

					
					
					
					
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseFive">
                                    <dt class="p4"><span class="icon"></span>Return Policies</dt></a>
                            </h4>
                        </div>
                        <div id="collapseFive" class="panel-collapse collapse">
                            <div class="panel-body">
						<ul>	        
                   <li> <p><span style="color:#0066cc;font-weight:bold;">Tweebaa</span> offers customers a thirty-day satisfaction guarantee. If you are
                        unhappy with your Tweebaa purchase for any reason, you can return it for a full
                        refund.</p></li>
      
                    <li><p>For return authorization, you must contact Tweebaa within 30 days of delivery
                        of the order. </p></li>
						
                    <li><p>All items must be returned in the same condition that they were received
                        to qualify for full refund. </p></li>
					<!--	
                    <li><p>Products shall be commercially available; not investment opportunities.</p></li>
					-->
                    <li><p>You are responsible for the return shipping cost, unless the return is
                        a result of Tweebaa error (such as damaged or incorrect items)</p></li>
						
                    <li><p>Upon Tweebaa’s receipt of your returned item, it may take up to one week
                        before you will receive a credit to the original form of payment.</p></li></ul>
                
                    <p><span style="color:#d60011;font-weight:bold;">How to return an order</strong></p>
                  
                      <p span class="black"><strong>Tweebaa Members:</strong></p>
                       <p> If you are a Tweebaa Member, simply log on to your Member Account and on the menu
                        bar (left side of page) select “Refund/Return” (under “My Shopping Cart”). Click
                        on the order, and then the item, that you wish to return. Tweebaa will issue you
                        a return authorization number and label, which should be affixed to the outside
                        of your return package.</p>
                 
                 
                        <p span class="black"><strong>Non-Members:</strong></p>
                        <p>If you selected “Checkout as Guest” when you placed your order, please notify us
                        by email (service@tweebaa.com) or the online inquiry form. Please specify the order
                        number and item you want to return in your request. Tweebaa will issue you a return
                        authorization number and label, which should be affixed to the outside of your return
                        package. </p>
              

                            </div>
                        </div>
                    </div>

					
					
					
					
					
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseSix">
                                         <dt class="p4"><span class="icon"></span>Cancellation Policy<br /></dt>
                                </a>
                            </h4>
                        </div>
                        <div id="collapseSix" class="panel-collapse collapse">
                            <div class="panel-body">
							
                    <ul>
                    <li><p>You may cancel an order under the following conditions:</p></li>
                    
                    <li><p>For “Buy Now” items with standard shipping time, you may only cancel
                        an order PRIOR to shipment. This will typically be within 24 hours from the time
                        order was placed (although it may be sooner in some cases). </li>
						
                    <li><p>For “Test-Sale” items, you may cancel your order at any time prior to
                        shipment. Lead times for these items will be longer than for “Buy Now” items. You
                        will be notified once Test-Sale reaches the “Pass” or “Fail” status, and if Test-Sale
                        has Passed, we will provide an estimated ship date for your general reference. You
                        may cancel Test-Sale orders at any time during the wait period.</li></ul>
						
                     <p><span style="color:#d60011;font-weight:bold;">How to cancel an order</span></p>
        
                        <p span class="black"><strong>Tweebaa Members:</strong></p>
                        <p>If you are a Tweebaa Member, simply log on to your Member Account, and on the menu
                        bar (left side of page) select “Refund/Return” (under “My Shopping Cart”). If your
                        order has not yet shipped, you can simply click the “Cancel Order” button, to trigger
                        a full refund to your original form of payment.</p>
                    

                        <p span class="black"><strong>Non-Members:</strong></p>
                        <p>If you selected “Checkout as Guest” when you placed your order, please notify us
                        by email (<a href="#">service@tweebaa.com</a>) or the online inquiry form. Please
                        specify the order number that you wish to cancel in your request. If the order has
                        not yet shipped, Tweebaa will issue you a full refund to your original form of payment.</p>

                            </div>
                        </div>
                    </div>

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseEight">
                                            <dt class="p4"><span class="icon"></span>Wholesale Orders</dt></a>
                            </h4>
                        </div>
                        <div id="collapseEight" class="panel-collapse collapse">
                            <div class="panel-body">
							
                
                    <p>Tweebaa would love to work with wholesalers! If you are a wholesaler
                        and have interest in any Tweebaa products, please contact us for additional information!
                        On our Shop page, you can simply click on the link for “Wholesale Inquiries”.</p>

                        <img src="../images/college/wholesale-1.png" width="100%" ><br />
                        <br />
                        <img src="../images/college/whole-s.png" width="60%"><br />
                     
        
                            </div>
                        </div>
                    </div>
                </div><!--/acc-v1-->
                <!-- End General Questions -->

    		</div><!--/col-md-9-->
		
        </div><!--/row-->

    </div>	
    <!--=== End Content Part ===-->

        <script type="text/javascript">

            $(document).ready(function () {
                // console.log("ready!");
                //get URL
                var a = window.location.href;
                var b = a.split("#");
                var c = b[1];
                $("#" + c).addClass("in");
            });
    </script>
</asp:Content>
