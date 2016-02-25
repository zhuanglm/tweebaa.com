<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="evaluate-zone.aspx.cs" Inherits="TweebaaWebApp2.College.evaluate_zone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

  <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Evaluate Zone</h1>
            <ul class="pull-right breadcrumb">
        <li><a href="/index.aspx">Home</a></li>
                <li><a href="/College/Education.aspx">Education</a></li>
                <li class="active">Evaluate Zone</li>
            </ul>
        </div> 
    </div><!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->  
         <!--=== Search Block Version 2 ===
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
                     <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseTwo">Evaluate Zone Reward Points</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseFour">Gift Rewards</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseFive">How to Evaluate</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseSix">Become an "expert" Evaluator</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseSeven">Evaluator Rules</a></li>
                                       
                                    </ul>
                                </li>
                                             <li class="active dropdown-tree open-tree"><a class="dropdown-tree-a">Shop Zone</a>
                                   <ul class="category-level-2 dropdown-menu-tree">
                                        <li><a href="/College/shop-zone.aspx#collapseOne">
                                         About the SHOP Zone</a> </li>
                                       
                    <li><a href="/College/shop-zone.aspx#collapseTwo">Shop Details</a></li>
                    <li><a href="/College/shop-zone.aspx#collapseThree">More about “Test-Sale”</a></li>
                    <li><a href="/College/shop-zone.aspx#collapseFour">Payment Options</a></li>
                    <li><a href="/College/shop-zone.aspx#collapseFive">Return Policies</a></li>
                    <li><a href="/College/shop-zone.aspx#collapseSix">Cancellation Policy</a></li>
                    <li><a href="/College/shop-zone.aspx#collapseEight">Wholesale Orders</a></li>
                                       
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
                                     <dt class="p4"><span class="icon"></span>About the EVALUATE Zone</dt>
                                </a>
                            </h4>
							
                        </div>
						
                        <div id="collapseOne" class="panel-collapse collapse in">
                            <div class="panel-body">	
	            <p>Visit the<strong> Evaluate Zone</strong> and browse the many items that have been Suggestted
                by our members (see Suggest Zone). Success or failure of each item hinges on whether
                evaluators like YOU vote ‘yes’ or ‘no’ to advance items closer to the Tweebaa Shop.</p>

                <p>Evaluating is pretty easy…just find an ’evaluate’ item that interests you, then
                complete a 5 question survey. By evaluating and sharing your opinion, you have the
                power to assist in the growth and popularity of products. Your feedback will help
                identify new products that Tweebaa members want to buy, and as an evaluator of successful
                products you have potential to <strong><span style="color: #DD0011">EARN REWARDS!</span></strong></p> </div>
                        </div>
                        
                     </div>
                    <div class="panel panel-default">
					
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                                <dt class="p4"><span class="icon"></span>Evaluate Zone Reward Points</dt>
								</a>
                            </h4>
                        </div>
						
                        <div id="collapseTwo" class="panel-collapse collapse">
						
                            <div class="panel-body">
                             <dd class="dpn">
				     <ul>
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
            <li class="p5">The following table describes how to earn Evaluate Zone Reward Points:</li></ul>
            <br>
              <div class="panel panel-sea margin-bottom-40">
          <table class="table table-bordered etab">
                     <tbody>
                       <tr><th scope="row" width="30%"> 
                            For each completed<br /> evaluation
                        </th>
                        <td> You complete and Suggest the evaluation survey for a Tweebaa product. You can evaluate
                                            a maximum of ten Tweebaa products per day.
                                            <br />
                                            <strong>Note: </strong>Members may evaluate their own product submissions, but are
                                            not eligible for Evaluator rewards.
                                        </td>
                                        <td >
                                            +1 points
                                        </td>
                                    </tr>
                    
                    <tr>
<th scope="row" width="30%">   Each successful
                        </th>
                        <td> An evaluation is considered "successful" if you answer “Yes” to this evaluation
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
                                        <td >
                                            +15 points
                                        </td>
                                    </tr>
                              
                    <tr>
                      <th scope="row" width="30%"> 
                            Each inaccurate
                        </th>
                        <td> <span class="under">If you predicted Success: </span>From the date that you complete
                                            a product evaluation, if the product does NOT pass the Evaluation Stage within 30
                                            days, your evaluation is considered inaccurate. Note: If the product does pass Evaluation
                                            after the 30 days, you will still receive the 15-point reward for results.<br />
                                            <span class="under">If you did NOT predict Success: </span>From the date that you
                                            complete a product evaluation, if the product DOES pass the Evaluation stage within
                                            30 days, your evaluation is considered inaccurate.
                                        </td>
                                        <td >
                                            -1 point
                                        </td>
                                    </tr>
                             </tbody>
                </table></div>
                <br />
            <ul>    <li class="p5">In addition you can earn points in EVERY zone by checking in daily and
                    referring new members.
                </li></ul>
              <br />
                  <div class="panel panel-sea margin-bottom-40">
                   <table class="table table-bordered etab">
                     <tbody>
                       <tr><th scope="row" width="30%"> 
                  
                                Daily Check-In
                            </th>
                            <td>  Log in to your Member Account every day! For each day that you click on "Daily Check-In",
                                                you will earn one point in each zone.
                                            </td>
                                            <td>
                                                Bonus +1 point
                                            </td>
                                        </tr>
                                        <tr>
                                         <th scope="row" width="30%"> 
                                Daily Check-In
                            </th>
                                            <td>
                                                For each week that you check-in every day, you'll earn a BONUS 10 points in each
                                                zone!
                                            </td>
                                            <td>
                                                Bonus +10 point
                                            </td>
                                        </tr>
                                   
                        <tr>
                         <th scope="row" width="30%"> 
                                New member referral
                            </th>
                            <td>
                                Each time you refer a new Tweebaa member who registers, you will receive 30 points
                                                in all three Zones! New member must either (1) list your email address as the referring
                                                friend or (2) register from your shared link.
                                            </td>
                                            <td>
                                                Bonus +30 points
                                            </td>
                     </tr>
                       </tbody>          
                    </table>
                   </div>
               <br>
                <div class="ctitle">
                    <ul>
                        <li class="p7">Tweebaa reserves the right to deduct points or revoke membership for
                            failure to abide by terms of service.</li>
							</ul>
  
                            </div>
                </dd></div></div>            
                
</div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseFour">
                                    <dt class="p4"><span class="icon"></span>Evaluate Zone Gift Rewards</dt></a>
                            </h4>
                        </div>
                        
                        <div id="collapseFour" class="panel-collapse collapse">
                            <div class="panel-body">
                           <dd class="dpn">
				   <ul>
            <li class="p3">Gift Rewards are offered to our Evaluators, as a way to encourage
                participation and show our deep appreciation!<br /><br />
                For each product that passes Test-Sales Stage, Tweebaa will select 2 Evaluators (out of all Evaluators who accurately evaluated the product) to receive the evaluated product (up to $50 USD price **) as a free gift.<br /><br />
                **If the selling price of the evaluated product exceeds $50 USD, the two evaluators will receive a $50 merchandise credit instead (in the form of 4,000 Shopping Reward Points).

            </li></ul><br>
               <div class="panel panel-sea margin-bottom-40">
                          
                            <table class="table table-bordered etab">
                         
                                <tbody>
                                    <tr>
                                    <th scope="row" width="50%">  The 150th Evaluator to correctly predict success</th>
                                        <td>  Receive the item as a free gift!</td>
                                      
                                    </tr>
                                    <tr>
                                         <th scope="row" width="30%"> The 300th Evaluator to correctly predict success</th>
                                        <td>Receive the item as a free gift!</td>
                                       
                                    </tr>
                                             
                              
                                </tbody>
                            </table>
                        </div>
        
                <br>
                        <p>* In case of tie, the Evaluator(s) with longest membership will receive
                            gift rewards.</p>
     
                   </dd>
                    </div>
					</div>
                    </div>
					
					 <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseFive">
                                    <dt class="p4"><span class="icon"></span>How to Evaluate</dt></a>
                            </h4>
                        </div>
                        <div id="collapseFive" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <dd class="dpn">
						    <ul>
            <li>About the Evaluate Zone</li><li>As an Evaluator, you can take
                quick surveys (up to 10 each day) to tell us which items you like...which items
                you don't like...and offer additional comments. If you correctly predict "success"
                and the product eventually is “Tweebaa-approved” making it all the way to the Tweebaa
                Shop, you can earn cash and rewards.
                <br />
               </li> 
                <li>How to Evaluate</li>
                
                <li class="p3">It's easy to become a Tweebaa Evaluator.
                    If you're good at it, you can earn ongoing cash plus free gifts! Here's how:
                    <br />
                    <br />
                    <strong>Step 1:</strong> Select the EVALUATE link at the top of the page<br />
                    <br />
                    <img src="../images/college/evaprocess-1.png" width="100%"><br />
                    <br />
                    <strong>Step 2: </strong>Browse the products that need evaluations and select one
                    that interests you; click on it to see more details.<br />
                    <br />
                    <img src="../images/college/evaprocess-2.jpg" width="100%"><br />
                    <br />
                    <strong>Step 3: </strong>Answer the brief survey questions ~ tell us what you think!<br />
                    <br />
                    <img src="../images/college/evaprocess-3.jpg" width="100%"><br />
            Careful you don’t carelessly support ALL the products you evaluate…you
                can lose points for incorrect predictions!
                <br><br>
            <strong>Step 4: </strong>Click on the “Evaluate” button to submit your
                responses.<br />
                <br />
                When you evaluate products,
                    keep in mind these criteria for Tweebaa Shop items (after all, only Tweebaa Shop
                    items are eligible for commission rewards:<br />
                    <img src="../images/college/check-mark.png" width="15" height="14">
                    Tweebaa Shop items are unique (you can’t find them just anywhere…)<br />
                    <img src="../images/college/check-mark.png" width="15" height="14">
                    Tweebaa Shop items are priced competitively (we don’t think you’ll find them cheaper
                    anywhere else…but if you do, please tell us!)<br><br>
          <strong>Step 5：</strong> Continue to evaluate other products or log in
                to the Member Center to check the status of your evaluated products. <br>
           Come back every day! You may submit up to 10 surveys each day. As you gain experience and points in the Evaluate
                Zone, you can increase your earnings! <br> <br>
           Share evaluation products! Encourage others to evaluate too and help
                the product advance.) </li></ul>
        </dd>
                                
                            </div>
                        </div>
                    </div>

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseSix">
                                         <dt class="p4"><span class="icon"></span>Become an "expert" Evaluator<br /></dt>
                                </a>
                            </h4>
                        </div>
						
                        <div id="collapseSix" class="panel-collapse collapse">
						
                            <div class="panel-body">
   <ul><li class="p3">If you have a good eye for product, it takes just minutes each day to
                hone your Evaluator skills and climb the success ladder. The better you are at evaluating,
                the higher your evaluation level and the higher your potential commission will be.</li></ul>
           
                            </div>
                        </div>
                    </div>

					
					

					
					
					                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseSeven">
                                         <dt class="p4"><span class="icon"></span>Evaluator Rules<br /></dt>
                                </a>
                            </h4>
                        </div>
						
                        <div id="collapseSeven" class="panel-collapse collapse">
						
                            <div class="panel-body">
   <ul>
       
            <li class="p10">Each evaluation consists of a 5 question survey. You must answer all
                5 questions.</li><br>
            <li class="p10">There is one survey question which will determine the accuracy of your
                evaluation. Your evaluation must be Accurate in order to earn points, gift rewards,
                and cash rewards. The question is simply: "Do you believe this product will advance
                to the Tweebaa Shop? (Yes/No)". If you answer "Yes" and the product eventually advances
                to the Tweebaa Shop, your evaluation is Accurate. Also, if you answer “No” and the
                product does NOT advance to the Tweebaa Shop, your evaluation is Accurate. Only
                Accurate evaluators are eligible for commission and gift rewards, and those are
                only rewarded when the evaluated product passes Test Sale stage (becoming “Tweebaa-Approved”).
            </li><br>
            <li class="p10">Please thoughtfully give your comments, because your suggestions are
                very important to Tweebaa. </li><br>
            <li class="p10">Inappropriate or threatening language in your evaluation is not acceptable.
                Tweebaa reserves the right to deduct reward points OR cancel your Tweebaa membership.</li><br>
            <li class="p10">Evaluators’ comments represent evaluator opinions and do not reflect
                the opinions of Tweebaa. Tweebaa assumes no responsibility for any members' comments.</li><br>
            <li class="p10">Tweebaa reserves the right to remove any and all survey content without notice to the Evaluator or any other party.</li>
               
   
           </ul>
                            </div>
                        </div>
                    </div>
                </div><!--/acc-v1-->
                </div><!--/acc-v1-->
    		</div><!--/col-md-9-->
            

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
