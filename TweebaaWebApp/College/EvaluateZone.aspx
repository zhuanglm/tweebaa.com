<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="EvaluateZone.aspx.cs" Inherits="TweebaaWebApp.College.EvaluateZone" %>
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
        <a href="../index.aspx">Homepage</a> > <a href="College.aspx">Education</a>  > <b class="l">Evaluate Zone</b>
 </div>
 <div class="ctitle">
        <ul>
            <li class="p1">Evaluate Zone</li>
            <li class="line"></li>
           </ul>
            <div class="w975">
            <dl>
           
                <dt class="p4" ><span class="icon"></span>About the EVALUATE Zone<br />
                </dt>
                <dd>
            <li class="p3">Visit the Evaluate Zone and browse the many items that have been submitted
                by our members (see Submit Zone). Success or failure of each item hinges on whether
                evaluators like YOU vote ‘yes’ or ‘no’ to advance items closer to the Tweebaa Shop.
                <br />
                <br />
                Evaluating is pretty easy…just find an ’evaluate’ item that interests you, then
                complete a 5 question survey. By evaluating and sharing your opinion, you have the
                power to assist in the growth and popularity of products. Your feedback will help
                identify new products that Tweebaa members want to buy, and as an evaluator of successful
                products you have potential to EARN REWARDS!<br />
                <br />
                
            </li>
              </dd>
        </ul>
      
      
        <!--<div class="elist ">
<ul>
<li><a href="#" class="bli" > Submit Zone Reward Points </a></li>
<li> <a href="#" class="bli" >Submit Zone Commission rewards</a></li>
<li> <a href="#" class="bli" >How to select products for Tweebaa</a></li>
<li > <a href="#" class="bli" >Preparing your submission</a></li>
<li> <a href="#" class="bli" > Submit steps</a></li>

</ul>

</div> -->
        <dt class="p4" ><span class="icon"></span>Evaluate Zone Reward Points<br />
        </dt>
        <dd class="dpn">
            <li class="p3">You will earn evaluate zone reward points according to how often you
                evaluate and how accurate your evaluations are. There are 10 reward point levels
                in the Evaluate Zone; a member’s accrued points will determine his/her Evaluate
                Zone Level. If you evaluate a product that is eventually sold in the Tweebaa Shop,
                you MAY earn a free gift or a commission according to your Evaluate Zone level at
                the time you evaluated the product*.<br />
                <br />
                Each member can evaluate up to 10 products per day. To maximize your Evaluate Zone
                Reward points, select your evaluation products carefully as inaccurate evaluations
                may lead to lost points.</li>
            <li class="p7">*Commission percentage is based upon your Evaluate Zone Level at the
                time of Evaluation (not at the time of product sale). </li>
            <li class="p5">The following table describes how to earn Evaluate Zone Reward Points:</li>
            <div class="w967">
                <table cellpadding="0" cellspacing="0" border="0" class="table-1 sy3">
                    <tr>
                        <th>
                            For each completed
                            <br />
                            evaluation
                        </th>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="table-3">
                                <tbody>
                                    <tr>
                                        <td style="width: 660px; background: #fff">
                                            You complete and submit the evaluation survey for a Tweebaa product. You can evaluate
                                            a maximum of ten Tweebaa products per day.
                                            <br />
                                            <strong>Note: </strong>Members may evaluate their own product submissions, but are
                                            not eligible for Evaluator rewards.
                                        </td>
                                        <td style="width: 60px; background: #fff">
                                            +1 points
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Each successful
                        </th>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="table-3">
                                <tbody>
                                    <tr>
                                        <td style="width: 660px; background: #fff">
                                            An evaluation is considered "successful" if you answer “Yes” to this evaluation
                                            question and the product subsequently DOES advance:<br />
                                            <strong>"Do you believe this product will go to Tweebaa Shop eventually? (Yes/No)".
                                            </strong>
                                            <br />
                                            Since advancing to the Tweebaa Shop can take some time, it will require some patience
                                            to receive these result points!
                                            <br />
                                            <strong>Tip #1: </strong>Share evaluation products! Encourage others to evaluate
                                            too and help the product advance.)<br />
                                            <strong>Tip #2:</strong> Don’t carelessly support products…keep in mind that inaccurate
                                            evaluations will result in deducted points.
                                        </td>
                                        <td style="width: 60px; background: #fff">
                                            +15 points
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <th class="bor">
                            Each inaccurate
                        </th>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="table-3">
                                <tbody>
                                    <tr>
                                        <td style="width: 660px; background: #fff">
                                            <span class="under">If you predicted Success: </span>From the date that you complete
                                            a product evaluation, if the product does NOT pass the Evaluation Stage within 30
                                            days, your evaluation is considered inaccurate. Note: If the product does pass Evaluation
                                            after the 30 days, you will still receive the 15-point reward for results.<br />
                                            <span class="under">If you did NOT predict Success: </span>From the date that you
                                            complete a product evaluation, if the product DOES pass the Evaluation stage within
                                            30 days, your evaluation is considered inaccurate.
                                        </td>
                                        <td style="width: 60px; background: #fff">
                                            -1 point
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <li class="p5">In addition you can earn points in EVERY zone by checking in daily and
                    referring new members.<br />
                </li>
                </ul>
                <div class="w967">
                    <table cellpadding="0" cellspacing="0" border="0" class="table-1 sy3">
                        <tr>
                            <th>
                                Daily Check-In
                            </th>
                            <td>
                                <table width="100%" cellpadding="0" cellspacing="0" border="0" class="table-3">
                                    <tbody>
                                        <tr>
                                            <td style="width: 660px; background-color: #FFFFFF">
                                                Log in to your Member Account every day! For each day that you click on "Daily Check-In",
                                                you will earn one point in each zone.
                                            </td>
                                            <td style="width: 60px; background-color: #FFFFFF">
                                                Bonus +1 point
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 660px; background-color: #FFFFFF">
                                                For each week that you check-in every day, you'll earn a BONUS 10 points in each
                                                zone!
                                            </td>
                                            <td style="width: 60px; background-color: #FFFFFF">
                                                Bonus +10 point
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <th class="bor">
                                New member referral
                            </th>
                            <td>
                                <table width="100%" cellpadding="0" cellspacing="0" border="0" class="table-3">
                                    <tbody>
                                        <tr>
                                            <td style="width: 660px; background-color: #FFFFFF">
                                                Each time you refer a new Tweebaa member who registers, you will receive 30 points
                                                in all three Zones! New member must either (1) list your email address as the referring
                                                friend or (2) register from your shared link.
                                            </td>
                                            <td style="width: 60px; background-color: #FFFFFF">
                                                Bonus +30 points
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="ctitle">
                    <ul>
                        <li class="p7">Tweebaa reserves the right to deduct points or revoke membership for
                            failure to abide by terms of service.</li></ul>
        </dd>
        <dt class="p4" ><span class="icon"></span>Evaluate Zone Commission Rewards<br />
        </dt>
        <dd class="dpn">
            <ul>
                <li class="p3">Commission is earned in TweeBucks and redeemable for cash!</li></ul>
            <div class="award mt50">
                <dl class="award-2 clearfix">
                    <dt>
                        <img src="../Images/ico-14.png" width="109" height="109"></dt>
                    <dd>
                        <h4>
                            Evaluators earn…by taking surveys to rate potential Tweebaa products!</h4>
                        <div class="posR">
                            For a submission to advance from Evaluate Zone to Test-Sale Stage, it must receive
                            300 positive evaluations.
                            <br />
                            From all the product evaluators who accurately predicted success, TWO will be chosen
                            to receive a commission…
                            <br />
                            one is the member with highest Evaluator Zone points *, the other is the first Evaluator
                            to submit the products evaluation.
                            <br />
                            *In case of tie, the Evaluator with longest membership will receive commission.
                        </div>
                        <table width="830" cellpadding="0" cellspacing="1" border="0" bgcolor="#39cdab" class="mt10">
                            <tr>
                                <td width="250">
                                    When product is Tweebaa-Approved<br />
                                    (Excludes Test-Sale purchases)
                                </td>
                                <td>
                                    Two Evaluators will receive a lifetime commission of 0.2% to 0.65% of submitted
                                    product’s selling price in Tweebaa Shop. For commission level, please see Commission
                                    Chart. Commission is earned in TweeBucks and redeemable of cash!
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <li class="p5">Submit Zone Commission Chart</li>
                <table width="980" cellpadding="0" cellspacing="0" border="0" class="table-2 sy3 mt20">
                    <tr>
                        <th colspan="11">
                            Submitter Level-Points-Commission Chart
                        </th>
                    </tr>
                    <tr>
                        <th>
                            Submitter Level
                        </th>
                        <td>
                            1
                        </td>
                        <td>
                            2
                        </td>
                        <td>
                            3
                        </td>
                        <td>
                            4
                        </td>
                        <td>
                            5
                        </td>
                        <td>
                            6
                        </td>
                        <td>
                            7
                        </td>
                        <td>
                            8
                        </td>
                        <td>
                            9
                        </td>
                        <td>
                            10
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Points for next level
                        </th>
                        <td>
                            1
                        </td>
                        <td>
                            100
                        </td>
                        <td>
                            200
                        </td>
                        <td>
                            500
                        </td>
                        <td>
                            1000
                        </td>
                        <td>
                            2000
                        </td>
                        <td>
                            5000
                        </td>
                        <td>
                            10000
                        </td>
                        <td>
                            20000
                        </td>
                        <td>
                            40000
                        </td>
                    </tr>
                    <tr class="blueTxt">
                        <th>
                            Commission Ratio
                        </th>
                        <td>
                            0.20%
                        </td>
                        <td>
                            0.25%
                        </td>
                        <td>
                            0.30%
                        </td>
                        <td>
                            0.35%
                        </td>
                        <td>
                            0.40%
                        </td>
                        <td>
                            0.45%
                        </td>
                        <td>
                            0.50%
                        </td>
                        <td>
                            0.55%
                        </td>
                        <td>
                            0.60%
                        </td>
                        <td>
                            0.65%
                        </td>
                    </tr>
                </table>
            </div>
            <br /><li class="p8">Commission is earned in TweeBucks and redeemable for cash!</li>
        </dd>
        <dt class="p4" ><span class="icon"></span>Evaluate Zone Gift Rewards<br />
        </dt>
        <dd class="dpn">
            <li class="p3">Gift Rewards are offered to our Evaluators, as a way to encourage
                participation and show our deep appreciation!<br /><br />
                For each product that passes Test-Sales Stage, Tweebaa will select 2 Evaluators (out of all Evaluators who accurately evaluated the product) to receive the evaluated product (up to $50 USD price **) as a free gift.<br /><br />
                **If the selling price of the evaluated product exceeds $50 USD, the two evaluators will receive a $50 merchandise credit instead (in the form of 4,000 Shopping Reward Points).


            </li>
            <div class="w967">
                <table cellpadding="0" cellspacing="0" border="0" class="table-1 sy3">
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="table-3">
                                <tbody>
                                    <tr>
                                        <td style="width: 660px; background: #fff">
                                        The 150th Evaluator to correctly predict success
                                        </td>
                                        <td style="width: 260px; background: #fff">
                                            Receive the item as a free gift!
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="table-3">
                                <tbody>
                                    <tr>
                                        <td style="width: 660px; background: #fff">
                                          The 300th Evaluator to correctly predict success
                                        </td>
                                        <td style="width: 260px; background: #fff">
                                            Receive the item as a free gift!
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </table>
                </ul>
                <div class="ctitle">
                    <ul>
                        <li class="p7">* In case of tie, the Evaluator(s) with longest membership will receive
                            gift rewards.</li></ul>
        </dd>
        <dt class="p4" ><span class="icon"></span>How to Evaluate<br />
        </dt>
        <dd class="dpn">
            <li class="p5">About the Evaluate Zone</li><li class="p3">As an Evaluator, you can take
                quick surveys (up to 10 each day) to tell us which items you like...which items
                you don't like...and offer additional comments. If you correctly predict "success"
                and the product eventually is “Tweebaa-approved” making it all the way to the Tweebaa
                Shop, you can earn cash and rewards.
                <br />
                <li class="p5">How to Evaluate</li><li class="p3">It's easy to become a Tweebaa Evaluator.
                    If you're good at it, you can earn ongoing cash plus free gifts! Here's how:
                    <br />
                    <br />
                    <strong>Step 1:</strong> Select the EVALUATE link at the top of the page<br />
                    <br />
                    <img src="../Images/evaprocess-1.png" width="700" height="64"><br />
                    <br />
                    <strong>Step 2: </strong>Browse the products that need evaluations and select one
                    that interests you; click on it to see more details.<br />
                    <br />
                    <img src="../Images/evaprocess-2.jpg" width="700" height="396"><br />
                    <br />
                    <strong>Step 3: </strong>Answer the brief survey questions ~ tell us what you think!<br />
                    <br />
                    <img src="../Images/evaprocess-3.jpg" width="700" height="396"><br />
                </li>
            <li class="p8">Careful you don’t carelessly support ALL the products you evaluate…you
                can lose points for incorrect predictions!</li>
            <li class="p3"><strong>Step 4: </strong>Click on the “Evaluate” button to submit your
                responses.<br />
                <br />
                <li class="p8" style="line-height: 24px; height: 160px;">When you evaluate products,
                    keep in mind these criteria for Tweebaa Shop items (after all, only Tweebaa Shop
                    items are eligible for commission rewards:<br />
                    <img src="../Images/check-mark.png" width="15" height="14">
                    Tweebaa Shop items are unique (you can’t find them just anywhere…)<br />
                    <img src="../Images/check-mark.png" width="15" height="14">
                    Tweebaa Shop items are priced competitively (we don’t think you’ll find them cheaper
                    anywhere else…but if you do, please tell us!)</li>
            <li class="p3"><strong>Step 5：</strong> Continue to evaluate other products or log in
                to the Member Center to check the status of your evaluated products. </li>
            <li class="p8" style="line-height: 24px; height: 50px;">Come back every day! You may
                submit up to 10 surveys each day. As you gain experience and points in the Evaluate
                Zone, you can increase your earnings! </li>
            <li class="p8">Share evaluation products! Encourage others to evaluate too and help
                the product advance.) </li>
        </dd>
        <dt class="p4" ><span class="icon"></span>Become an "expert" Evaluator<br />
        </dt>
        <dd class="dpn">
            <li class="p3">If you have a good eye for product, it takes just minutes each day to
                hone your Evaluator skills and climb the success ladder. The better you are at evaluating,
                the higher your evaluation level and the higher your potential commission will be.</li></dd>
        <dt class="p4" ><span class="icon"></span>Evaluator Rules<br />
        </dt>
        <dd class="dpn">
            <li class="p10">Each evaluation consists of a 5 question survey. You must answer all
                5 questions.</li>
            <li class="p10">There is one survey question which will determine the accuracy of your
                evaluation. Your evaluation must be Accurate in order to earn points, gift rewards,
                and cash rewards. The question is simply: "Do you believe this product will advance
                to the Tweebaa Shop? (Yes/No)". If you answer "Yes" and the product eventually advances
                to the Tweebaa Shop, your evaluation is Accurate. Also, if you answer “No” and the
                product does NOT advance to the Tweebaa Shop, your evaluation is Accurate. Only
                Accurate evaluators are eligible for commission and gift rewards, and those are
                only rewarded when the evaluated product passes Test Sale stage (becoming “Tweebaa-Approved”).
            </li>
            <li class="p10">Please thoughtfully give your comments, because your suggestions are
                very important to Tweebaa. </li>
            <li class="p10">Inappropriate or threatening language in your evaluation is not acceptable.
                Tweebaa reserves the right to deduct reward points OR cancel your Tweebaa membership.</li>
            <li class="p10">Evaluators’ comments represent evaluator opinions and do not reflect
                the opinions of Tweebaa. Tweebaa assumes no responsibility for any members' comments.</li>
            <li class="p10">Tweebaa reserves the right to remove any and all survey content without
                notice to the Evaluator or any other party.</li>
        </dd></dl></div>
    </div>
    <div class="ebtn clearfix">
        <ul>
            <li><a href="College.aspx" class="bli">Back to Education home page</a></li>
        </ul>
    </div>
</asp:Content>
