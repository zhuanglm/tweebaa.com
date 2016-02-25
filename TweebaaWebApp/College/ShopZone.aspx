﻿<%@ Page Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ShopZone.aspx.cs" Inherits="TweebaaWebApp.College.ShopZone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="../css/college-new.css" />
    <link rel="stylesheet" href="../css/selectCss.css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script src="../js/reg.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <script type="text/javascript" src="../js/jquery.xScroller.js"></script>
    <script type="text/javascript" src="../js/dragbox.js"></script>
    <script type="text/javascript" src="../js/public.js"></script>
    <script src="../js/custom.js"></script>
    <script type="text/javascript" src="../js/script.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

    <div class="w975 mbx">
        <a href="../index.aspx">Homepage</a> > <a href="College.aspx">Education</a> > <b class="l">Shop Zone</b>
    </div>
    <div class="ctitle">
        <ul>
            <li class="p1">Shop Zone</li>
            <li class="line"></li>
        </ul>
        <div class="w975">
            <dl>
                <dt class="p4"><span class="icon"></span>About the SHOP Zone<br />
                </dt>
                <dd>
                    <li class="p3">Browse the Tweebaa Shop. Find cool products and great prices.<br />
                        <br />
                        <span class="black"><strong>COOL PRODUCTS.</strong></span><br />
                        Tweebaa products come from Tweebaa members. Members (like YOU) can VOTE on products
                        that you want to see in our store (see <a href="#">Evaluate Zone</a>). Once a product
                        receives enough votes to advance to the Test-Sale stage, it is offered in limited
                        quantity as a further test. If enough shoppers purchase, the product is a WINNER
                        and advances to the Tweebaa Shop. YAY! A new product is born! Shop at Tweebaa and
                        you'll be on the cutting edge of new products.<br />
                        <br />
                        <span class="black"><strong>GREAT PRICES.</strong></span><br />
                        At Tweebaa, our products are offered direct from the manufacturers... to you. We
                        eliminate the extra costs that other "middlemen" (like retailers) add.
                        <br />
                        <br />
                        <span class="black"><strong>SHARE & EARN.</strong></span><br />
                        Perhaps the most exciting part of shopping on Tweebaa is sharing great products
                        with your friends and earning income. It may seem like a dream-come-true to shop
                        and earn money at the same time! Click here to learn more about earning money in
                        our <a href="#">Share Zone.</a><br />
                        <br />
                        <span class="black"><strong>TEAM TWEEBAA.</strong></span><br />
                        Don’t forget that Tweebaa members benefit whenever a sale is made. Submitters, Evaluators,
                        and Sharers (that’s You!) earn income on every purchase from the Tweebaa Shop. Everybody
                        Earns at Tweebaa!
                        <br />
                        <br />
                    </li>
                    </ul></dd>
                <dt class="p4"><span class="icon"></span>Shop Details<br />
                </dt>
                <dd class="dpn">
                    <li class="p3">The Tweebaa Shop is a great place to find new and unique products…<br />
                    </li>
                    <div class="w967">
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
                                        <img src="../Images/twe_approve.png" width="151" height="151">
                                    </td>
                                    <td>
                                        <img src="../Images/hour_glass2.png" width="151" height="151">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <br />
                </dd>
                <dt class="p4"><span class="icon"></span>More about “Test-Sale”<br />
                </dt>
                <dd class="dpn">
                    <li class="p3">If you want to have a sneak-peek at brand new Tweebaa items, check out
                        the “Limited-Time” products in the Tweebaa Shop.</li>
                    <li class="p3">Test-Sale items only have 60 days to meet a pre-set sales quota. Each
                        unit purchased is a step closer to reaching quota and will help determine if the
                        item is a "Pass" (and is added to the Tweebaa Shop).
                        <br />
                    </li>
                    <li class="p3 clearfix"><span style="width: 45%; float: left;">
                        <img src="../Images/shop-edu1.png" width="444" height="576"></span> <span style="width: 55%;
                            float: left;"><span class="black">
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
                    </ul>
                </dd>
                <dt class="p4"><span class="icon"></span>Payment Options<br />
                </dt>
                <dd class="dpn">
                    <li class="p3"><span class="black"><strong>Credit Card</strong></span><br />
                        Tweebaa accepts most major credit cards including Mastercard, Visa, Discover, and
                        American Express. If you prefer, you may pay with an existing PayPal account. All
                        payments are processed securely using PayPal merchant services. Tweebaa does NOT
                        store any of your credit-card information.
                        <br />
                        <br />
                        <span class="black"><strong>TweeBucks</strong></span><br />
                        If you have earned TweeBucks through submitting, evaluating or sharing Tweebaa products,
                        you may apply them JUST LIKE CASH at checkout.For more information about earning
                        commissions/Tweebucks, see <a href="#">Commission Rewards</a>.
                        <br />
                        <br />
                        <span class="black"><strong>Shopping Reward Points</strong></span><br />
                        If you are a Tweebaa member, you can earn Shopping Reward Points with every purchase.
                        Those points may be redeemed at checkout (400 points = $5.00). For more information
                        about Shopping Reward Points, see <a href="#">Shopping Reward Points</a>.
                        <br />
                        <br />
                    </li>
                    </ul>
                </dd>
                <dt class="p4"><span class="icon"></span>Return Policies<br />
                </dt>
                <dd class="dpn">
                    <li class="p3">Tweebaa offers customers a seven-day satisfaction guarantee. If you are
                        unhappy with your Tweebaa purchase for any reason, you can return it for a full
                        refund.<br />
                    </li>
                    <li class="p6">For return authorization, you must contact Tweebaa within 7 days of delivery
                        of the order. </li>
                    <li class="p6">All items must be returned in the same condition that they were received
                        to qualify for full refund. </li>
                    <li class="p6">Products shall be commercially available; not investment opportunities.</li>
                    <li class="p6">You are responsible for the return shipping cost, unless the return is
                        a result of Tweebaa error (such as damaged or incorrect items)</li>
                    <li class="p6">Upon Tweebaa’s receipt of your returned item, it may take up to one week
                        before you will receive a credit to the original form of payment.<br />
                    </li>
                    <li class="p3"><span class="black"><strong>How to return an order</strong></span><br />
                        <br />
                        Tweebaa Members:<br />
                        If you are a Tweebaa Member, simply log on to your Member Account and on the menu
                        bar (left side of page) select “Refund/Return” (under “My Shopping Cart”). Click
                        on the order, and then the item, that you wish to return. Tweebaa will issue you
                        a return authorization number and label, which should be affixed to the outside
                        of your return package.<br />
                    </li>
                    <li class="p3">
                        <br />
                        Non-Members:<br />
                        If you selected “Checkout as Guest” when you placed your order, please notify us
                        by email (service@tweebaa.com) or the online inquiry form. Please specify the order
                        number and item you want to return in your request. Tweebaa will issue you a return
                        authorization number and label, which should be affixed to the outside of your return
                        package. </li>
                </dd>
                <dt class="p4"><span class="icon"></span>Cancellation Policy<br />
                </dt>
                <dd class="dpn">
                    <li class="p3">You may cancel an order under the following conditions:<br />
                    </li>
                    <li class="p6">For “Buy Now” items with standard shipping time, you may only cancel
                        an order PRIOR to shipment. This will typically be within 24 hours from the time
                        order was placed (although it may be sooner in some cases). </li>
                    <li class="p6">For “Test-Sale” items, you may cancel your order at any time prior to
                        shipment. Lead times for these items will be longer than for “Buy Now” items. You
                        will be notified once Test-Sale reaches the “Pass” or “Fail” status, and if Test-Sale
                        has Passed, we will provide an estimated ship date for your general reference. You
                        may cancel Test-Sale orders at any time during the wait period.</li>
                    <li class="p3"><span class="black"><strong>How to cancel an order</strong></span><br />
                        <br />
                        Tweebaa Members:<br />
                        If you are a Tweebaa Member, simply log on to your Member Account, and on the menu
                        bar (left side of page) select “Refund/Return” (under “My Shopping Cart”). If your
                        order has not yet shipped, you can simply click the “Cancel Order” button, to trigger
                        a full refund to your original form of payment.<br />
                    </li>
                    <li class="p3">
                        <br />
                        Non-Members:<br />
                        If you selected “Checkout as Guest” when you placed your order, please notify us
                        by email (<a href="#">service@tweebaa.com</a>) or the online inquiry form. Please
                        specify the order number that you wish to cancel in your request. If the order has
                        not yet shipped, Tweebaa will issue you a full refund to your original form of payment.
                    </li>
                </dd>
                <dt class="p4"><span class="icon"></span>Wholesale Orders<br />
                </dt>
                <dd class="dpn">
                    <li class="p3">Tweebaa would love to work with wholesalers! If you are a wholesaler
                        and have interest in any Tweebaa products, please contact us for additional information!
                        On our Shop page, you can simply click on the link for “Wholesale Inquiries”.
                        <br />
                        <br />
                        <img src="../Images/wholesale-1.png" width="900" height="458"><br />
                        <br />
                        <img src="../Images/whole-s.png" width="600" height="500"><br />
                        <span class="black"></li>
                    </ul>
                </dd>
        </div>
    </div>
    <div class="ebtn clearfix">
        <ul>
            <li><a href="College.aspx" class="bli">Back to Education home page</a></li></ul>
    </div>

</asp:Content>
