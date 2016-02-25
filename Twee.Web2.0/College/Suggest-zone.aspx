﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Suggest-zone.aspx.cs" Inherits="TweebaaWebApp2.College.Suggest_zone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Suggest Zone</h1>
            <ul class="pull-right breadcrumb">
             <li><a href="/index.aspx">Home</a></li>
                <li><a href="/College/Education.aspx">Education</a></li>
                <li class="active">Suggest Zone</li>
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
                                <li class="active dropdown-tree open-tree"><a class="dropdown-tree-a">Suggest Zone</a>
                                   <ul class="category-level-2 dropdown-menu-tree">
                                        <li><a href="/College/Suggest-zone.aspx#collapseOne">
                                           About the Suggest Zone</a>
                                       
                      <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseTwo">Suggest Zone Reward Points</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseFour">Suggest Detail</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseFive">How to select products for Tweebaa</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseSix">Preparing your suggestion</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseSeven">Suggest steps</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseEight">Product Guidelines</a></li>
                                       
                                    </ul>
                                </li>
                                  <li class="active dropdown-tree open-tree"><a class="dropdown-tree-a">Evaluate Zone</a>
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
                                       
                    <li><a href="/College/shop-zone.aspx#collapseTwo">Shop Details</a></li>
                    <li><a href="/College/shop-zone.aspx#collapseThree">More about “Test-Sale”</a></li>
                    <li><a href="/College/shop-zone.aspx#collapseFour">Payment Options</a></li>
                    <li><a href="/College/shop-zone.aspx#ollapseFive">Return Policies</a></li>
                    <li><a href="/College/shop-zone.aspx#collapseSix">Cancellation Policy</a></li>
                    <li><a href="/College/shop-zone.aspx#collapseEight">Wholesale Orders</a></li>
                                       
                                    </ul>
                                </li>

                                 <li class="active dropdown-tree open-tree"><a class="dropdown-tree-a">Share Zone</a>
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
                                     <dt class="p4"><span class="icon"></span>About the Suggest Zone</dt>
                                </a>
                            </h4>
                        </div>
						
                        <div id="collapseOne" class="panel-collapse collapse">
                            <div class="panel-body">
                     <p> <span class="badge badge-purple rounded">TIPS!</span>
							At <strong>Tweebaa</strong>, we strive to offer exciting products… and unbeatable prices…
							and we’d like YOU to help us discover them! We are relying on suggesters like you
							to tell us about emerging items, useful gadgets and must-have consumer products.
							After each product you Suggest, our Evaluators (Tweebaa members) will determine whether
							it has potential and advances to the Test-Sale stage. If enough orders are received
							during Test-Sale, the product will be sold in the Tweebaa Shop and you will earn
							a commission on all sales of the product for life!</p>
							
							<img src="../images/college/process-1.png" width="100%">

							<p>We believe that every individual has the power to find good consumer products. With
							a little practice, you might become an expert suggester and earn substantial income.</p>

							<p><i><b>Companies can suggest products, too!</b></i> If you are a Supplier (manufacturer,
							distributor, agent, etc.), Tweebaa offers you a platform to promote and sell your
							product to the worldwide market. Learn more about the Supply Zone. (Coming Soon!)</p>

							</div>
                   </div>
                 </div>

					
					
					
                    <div class="panel panel-default">
					
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                                <dt class="p4"><span class="icon"></span>Suggest Zone Reward Points</dt>
								</a>
                            </h4>
                        </div>
						
                        <div id="collapseTwo" class="panel-collapse collapse">
						
                            <div class="panel-body">

							
				<p>
				You will earn suggest zone reward points according to how often you suggest
                and how successful your products are in reaching the Tweebaa Shop. There are 10
                reward point levels in the suggest Zone; a member’s accrued points will determine
                his/her Suggest Zone Level. If you suggest a product that is eventually sold in the
                Tweebaa Shop, you will earn a commission according to your suggest Zone level at
                the time you suggested the product*.
				</p>
				<br />

            <h5><strong>The following table describes how to earn Suggest Zone Reward Points:</strong></h5>
            <div class="panel panel-blue margin-bottom-40">
                          
                            <table class="table table-bordered stab">
                         
                                <tbody>
                                    <tr>
                                    <th scope="row" width="30%"> For each approved suggestion</th>
                                        <td> You Suggest a new product on Tweebaa. After review by the Tweebaa team, it is determined
                                            that the submission falls within Tweebaa guidelines.</td><td> +5 points</td>
                                      
                                    </tr>
                                    <tr>
                                         <th scope="row" width="30%">When product is Tweebaa-Approved 
(Excludes Test-Sale purchases)</th>
                                        <td>Suggester of the product receives a lifetime commission of 0.5% to 0.95% of product’s selling price for Successful Purchases in Tweebaa Shop. For commission level, please see the Commission Chart. Commission is earned in TweeBucks and redeemable for cash!</td><td>Bonus +25 points</td>
                                       
                                    </tr>
                                              <tr>
                                         <th scope="row" width="30%">When product is Tweebaa-Approved 
(Excludes Test-Sale purchases)</th>
                                        <td>In order to become "Tweebaa-Approved", a product must first pass the evaluation
                                            stage (receive 300 positive evaluations) and then sell a designated number of "test-sale"
                                            orders (test-sale quantity will vary by product).</td>
                                       <td>Bonus +30 points</td>
                                    </tr>
                                  
                              
                                </tbody>
                            </table>
                        </div>
           
				<br />
                <br />
				
                <h5><strong>In addition you can earn points in EVERY zone by checking in daily and referring new members.</strong></h5>
                
                <table class="table table-bordered stab">
                         
                                <tbody>
                                    <tr>
                                    <th scope="row" width="30%"> Daily Check-In</th>
                                        <td>  Log in to your Member Account every day! For each day that you click on "Daily Check-In",
                                                you will earn one point in each zone.</td><td> Bonus +1 points</td>
                                      
                                    </tr>
                                    <tr>
                                         <th scope="row" width="30%"> Daily Check-In</th>
                                        <td>For each week that you check-in every day, you'll earn a BONUS 10 points in each
                                                zone!</td><td>Bonus +10 points</td>
                                       
                                    </tr>
                                              <tr>
                                    <th scope="row" width="30%"> New member referral</th>
                                        <td>    Each time you refer a new Tweebaa member who registers, you will receive 30 points
                                                in all three Zones! New members must either (1) list your email address as the referring
                                                friend or (2) register from your shared link.</td>
                                       <td>Bonus +30 points</td>
                                    </tr>
                                  
                              
                                </tbody>
                            </table>
                    
        
		<br />
		 <p style="color:#d60011;">*Commission percentage is based upon your Suggest Zone Level at the time of Submission (not at the time of product sale). </p>

				
							
                            </div>
                        </div>
						
                    </div>

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseFour">
                                    <dt class="p4"><span class="icon"></span>Suggest Detail</dt></a>
                            </h4>
                        </div>
                        
                        <div id="collapseFour" class="panel-collapse collapse">
                            <div class="panel-body">
                             <p>No matter if you are an individual, manufacturer or supplier, as a Tweebaa
                member you are invited to start Suggesting products and earning rewards.</p>
                
                <p>Every suggested product must pass through three stages (Public Evaluation, Tweebaa
                Review and Test-Sale) before it will be offered for sale in the Tweebaa Shop.</p>

                <p><strong>Evaluation:</strong> Items suggested by Tweebaa members will first enter
                our Evaluation Stage. This is where other members will weigh in on products they
                like…products they dislike…and their likelihood of purchasing (Note: see Evaluate
                Zone to learn how YOU can be an evaluator!). Once a product receives 300 favorable
                evaluations, it will move to Tweebaa Review stage.</p>

                <p><strong>Tweebaa Review: </strong>This is where Team Tweebaa will take a closer look
                at suggested products. We’ll review competition, pricing, availability and some
                other factors to ensure that the product meets Tweebaa criteria. We will contact
                the suggester too, to gather additional supply information needed for our review.</p>

                <p><strong>Test-Sale:</strong> If our Tweebaa Review deems a product worthy of advancing,
                the product will advance to the Test-Sale Stage. This is the true test of whether
                people will purchase. Each Test-Sale product will have 60 days to sell a pre-determined
                target quantity in order to pass or fail. The target quantities will vary by product
                and are based on different factors. If the product sells the target quantity within
                the 60-day time-frame, the item is officially TWEEBAA-APPROVED and will advance to the
                Tweebaa Shop. That means the suggester will begin earning! The suggester will receive
                30 TweeBucks upon passing the Test-Sale stage, and will begin to earn commissions on
                every sale of the product!</p>

            
                <img src="../images/college/process-2.png" width="100%"><br />
				
                <p>Successful suggesters can make a great income! It does take some work to gather
                submission information and create great descriptions...but once your submissions
                advance through the Tweebaa process and reach the Tweebaa Shop, there's no more
                work...just sit back and collect your commission (between 0.5% and 0.95%). Better
                yet, continue to Suggest even MORE products and watch the commissions grow!</p>
				<br />
                <p style="color:#d60011;font-weight:bold;">For best chance of success, select the right products!</p>
                            </div>
                        </div>
                    </div>

					
					
					
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseFive">
                                    <dt class="p4"><span class="icon"></span>How to select products for Tweebaa</dt></a>
                            </h4>
                        </div>
                        <div id="collapseFive" class="panel-collapse collapse">
                            <div class="panel-body">
							
                                 <p>To achieve success by Suggesting to Tweebaa, the key is to choose products
                that our members will SHARE. The members who share your suggested product become
                your sales force; they promote your suggestion to their friends, family and networks…and
                with every sale you will EARN.</p>

                 <p>Why do Tweebaa members share products? Some members share because it’s fun. Other
                members share because they can earn commission rewards. And still other members
                share because they feel fulfilled by spreading the word and helping their friends.
                </p>

                 <p>Fundamentally, members are sharing products because something about the products
                is inspiring and, well, shareable! Here are some tips for finding great Tweebaa
                products to Suggest. Compelling product features…</p>

		    <ul>

                <li class="p6"><strong>Unique</strong> – Members might not be compelled to share a basic
                    pillow – not too exciting, right? But what about a pillow that allows you to lounge
                    face-down and is perfect while sunbathing or getting a massage…now that’s different
                    and unique! (And it’s available on Tweebaa… check out Podillow!). Tweebaa members
                    love to be trend-setters by sharing unique products that aren’t available just anywhere.
                    <br />
                    <br />
                    <li class="p6"><strong>Problem solving </strong>– You have undoubtedly seen the “As
                        Seen on TV” commercials that promise to make you thinner, more beautiful, or make
                        life much easier. Key to the success of those TV products is their ability to solve
                        common, everyday problems. By identifying a problem and reminding consumers how
                        bothersome that particular problem is, the commercials create a sense of urgency
                        which translates to impulsive purchases. At Tweebaa, we call these “Aha! Products”.
                        Tweebaa members love to share problem-solving products that help make their friends
                        life easier!<br />
                        <br />
                        <li class="p6"><strong>Great prices </strong>–We love to offer super values at the Tweebaa
                            Shop. We call these products “unbreathable” because the prices take our breath away.
                            Would you consider a light bulb inspiring and shareable? No? (You can buy light
                            bulbs anywhere, right?) Ok what about the latest LED light bulb which normally sells
                            for $XX.00…Tweebaa priced at $xx.00. Is THAT inspiring and shareable? Yes! Tweebaa
                            members love a great bargain, and they love to help their friends save money.</li>
                                </ul>
                            </div>
                        </div>
                    </div>


					
					
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseSix">
                                         <dt class="p4"><span class="icon"></span>Preparing your suggestion<br /></dt>
                                </a>
                            </h4>
                        </div>
                        <div id="collapseSix" class="panel-collapse collapse">
                            <div class="panel-body">
                  <ul>
                <li class="p3">Once you’ve identified great Tweebaa products, you’ll need to spend some
                    time gathering user content: product images, supply source, and great descriptions. The quality
                    of your submission may be the difference between success and failure. A complete
                    submission with high-quality images and vivid description will help persuade Evaluators
                    to respond favorably and advance your submission to the Test-Sale stage. Take care
                    with your submission to present it in the most favorable light. A good suggester
                    thinks like an advertising executive… the more compelling the message, the more
                    people will pay attention to it.
                    <br />
					<br />
                </li>
				
				
                 <p style="color:#d60011;"><strong>Important note:</strong> Do NOT Suggest confidential information/content
                    on the suggested Form. Due to the nature of Tweebaa, suggested products will enter
                    a public evaluation stage with NO obligations to keep the suggested information
                    in confidence.</p>
					
					
					
                <li class="p3">We recommend that you prepare the following user content information before you begin
                    a product submission.</li>
					</ul>
					
					<ul>
					
            <li class="p10"><strong>Product name. </strong>A descriptive product name can attract
                more attention. For example, instead of “Litter Box”, use something more descriptive
                like “Kitty Litty – flip-style, fast-cleaning cat litter box”.</li>
            <br/><li class="p10"><strong>Tags.</strong> Tags can help to describe your product, and can
                enable a product to be found by browsing or searching. We use an informal tag system;
                simply type in keywords that apply to your product and/or the category in which
                your product belongs. For example, a face-down pillow for massage and sunbathing
                might have the following tags: summer, outdoors, beach, sand, pillow, massage, recreation.</li>
            <br/><li class="p10"><strong>Brief description.</strong> Consider this section your “headline”.
                It should grab attention and make them want to learn more about the product. It’s
                a short summary only; further details will be listed in the following two sections.</li>
				
            <br/>
			
			<li class="p10"><strong>Detailed description. </strong>This is your opportunity to SELL
                YOUR PRODUCT! The more descriptive you are, the better chance that the product will
                catch the attention of Tweebaa members and shoppers (leading to product success).
                Tell us what problem the product solves…how it works…and why people should purchase
                your clever product. Make sure you use professional product descriptions. For best
                results:</li></ul>
				
            <ul>
                <li class="p11">Provide an abundance of information to share how GREAT the product is!
                </li>
                <li class="p11">Use correct grammar. </li>
                <li class="p11">Take care with punctuation. </li>
                <li class="p11">Use spell check. </li>
            </ul>
			
            <br/>
		<ul>
			<li class="p10"><strong>Features and Benefits. </strong>In this section, you can call
                attention to particular features and attributes of the product, or provide a list
                of benefits. Include as many features as possible to help generate more positive
                evaluations and bigger sales. You can use a bulleted list to list the info clearly.</li>
				
            <br/>
			
			<li class="p10"><strong>Images.</strong> Make sure you have GREAT IMAGES. For best results:</li>
			</ul>
			
            <ul>
                <li class="p11">Image sizes must be between 600x600 pixels and 1200x1200 pixels. <span
                    class="p12">(see sidebar for guidance on how to size your images)</span> </li>
                <li class="p11">Make sure you have attractive photos which show the product in best
                    lighting and angle.</li>
                <li class="p11">White background is preferred.</li>
                <li class="p11">Do not include any text on images (no phone numbers, websites or offers).
                </li>
                <li class="p11">Clearly show the product benefits/solutions. </li>
                <li class="p11">You can include 5 images for each product submission (the more, the
                    better!).</li>
            </ul>
			
            <br/>
		<ul>	
			<li class="p10"><strong>Video.</strong> We suggest a demonstration video, 2 minutes
                or less, showing the product in use. If a picture is worth a thousand words, a video
                is priceless! We support the following formats (max 5 mb): wmv, mov, mp4, flv. Alternatively,
                you can list a URL which links to the video (ex: youtube).
				</li>
				
            <br/>
			<li class="p10"><strong>Supplier info.</strong> For every product that you Suggest, you'll
                need to find a supply source. If you are new to sourcing the product supply, don’t
                worry! Let Tweebaa show you how to find suppliers. It may take a little research
                but soon you will become a sourcing expert!</li></ul>
              <br />
                <u>Suggestions on finding Supply Source:</u>
            <br />
				<br />
                <ul><p><strong>Start with a product you love. </strong></p>
				
                
				<ol>
                    <li>Check out the packaging; chances are that it will list the name of the
                        manufacturer / distributor right on the package. Try contacting that company to
                        request wholesaler information. </li>
						<br />
                    <li>Try contacting Contract Manufacturers (companies that will manufacture
                        to your specifications). If you can provide them with product details/images and/or
                        sample, they should be able to quote you a manufacturing price. Try searching the
                        internet. If you have a dog leash, try searching for “dog leash manufacturers”.
                        You can narrow down results by including a geographic area, such as “dog leash manufacturers
                        USA”.</li>
						<br />
                    <li>Try searching on <a href="www.alibaba.html">www.alibaba.com </a> <b>or</b> <a href="http://www.thomasnet.com/">http://www.thomasnet.com</a> for additional manufacturing
                        resources. </li>
                </ol>
				 
				 <br />
				 <p><strong>Search for a product to love..</strong></p>	
						
					<ol>
                    <li>If you don’t have a particular product in mind yet, try selecting a
                        category, for example let’s say you want to choose the household/kitchen category.
                        Try going to www.alibaba.com and select the ‘Home & Garden’ category and ‘Tableware’
                        sub-category. A long list of available products will come up. You can scroll through
                        that list until you find something you like, or refine your search even further
                        by entering keyword, like ‘Pitcher’. See an item you like? Make sure it is compelling:
                        either unique, problem-solving, or great prices. Then just click on “Company Profile”
                        and you will be directed on how to contact that company for pricing information.</li>
						
						<br />
                    <li>When you start looking for cool products, you might be amazed at all
                        the resources. Craft shows. Catalogs. TV Shows like “Shark Tank”. Take a browse
                        through Pinterest or eBay. Specialty stores at your local shopping mall might turn
                       up some unique items. </li>
					</ol>	
                </ul>
            <br/>
			<ul>
			<li class="p10"><strong>Price.</strong> Set a reasonable selling price based on your
                supplier’s cost. This might take a little research. You can start by researching
                similar items, and checking their selling price.
                <br />
				<br />
                <p><strong>Here’s what the Suggest Form looks like:</strong></p><br />
                <img src="../images/college/submit-table.jpg" width="300" height="600"><br />
            </li></ul>
			
				<br />
                <p><strong>Tweebaa requires images between 600 and 1200 resolution to conform with our website
                and enable zoom-in feature.</strong></p>
				
				<p style="color:#d60011;">Need help sizing your images? </p>
                
				<p><strong>If your image is TOO SMALL…</strong></p>
               
                <p>Small images won’t look good on our website, and we want you to put your best foot
                forward so your product has greatest chance of success! Please visit the source/supplier
                to request larger images, or Of if you have a product sample yourself, take a photo
                with minimum 600x600 resolution.</p>
				
				<p><strong>If your image is TOO LARGE…</strong></p>
                

                <p>Open a photo-editing software (like Windows Paint), then open the image and click
                on “Resize”. You will probably have a choice to resize by Percentage or by Pixel.
                Select Pixel, and make sure you check the box which says “Maintain aspect ratio”.
                Then, whichever dimension is larger (either horizontal or vertical), enter 1200
                pixels. Save the image. </p>
					</div>
				</div>
			</div>

					
			
					
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseSeven">
                                            <dt class="p4"><span class="icon"></span>Suggest steps</dt>
								</a>
                            </h4>
                        </div>
                        <div id="collapseSeven" class="panel-collapse collapse">
                            <div class="panel-body"><ul>
                           <li class="p10">Click on “Suggest” and select the “Suggest a Product” button. You will
                be asked to “log in”, or if you are not a Tweebaa member, to “register”.</li>
            <br/><li class="p10">Follow instructions, completing each step of the suggest form.
            </li>
            <br/><li class="p10">If you are unable to complete your suggest at one time, you may click
                the “save” button and your work will be saved in your Member Account. Come back
                later when you’re ready to complete your submission.</li>
            <br/><li class="p10">After you finish entering all the information on the Submission Form,
                click the “Submit” button. (You also have options to “preview” or “save” your work.)</li>
            <br/><li class="p10">Once Tweebaa determines that the submission is complete and meets Tweebaa
                guidelines, it will advance to the Evaluation Stage where members will be asked
                to take a quick survey.</li>
            <br/><li class="p10">If the suggestion receives 300 positive evaluations, it will advance
                to the “Tweebaa Review” stage. Tweebaa will need additional information from the
                Supplier in order to complete the review.</li>
            <br/><li class="p9">Tweebaa will contact the Supplier to confirm pricing, availability, delivery
                lead time, MOQ, warehousing, etc. and execute a Supply Agreement.</li>
            <br/><li class="p9">If you are an individual Suggesting the product, Tweebaa will compare
                your Supplier price with that of other suppliers to ensure the most competitive
                pricing. </li></ul>
                            </div>
                        </div>
                    </div>
					
					 <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseEight">
                                            <dt class="p4"><span class="icon"></span>Product Guidelines</dt></a>
                            </h4>
                        </div>
                        <div id="collapseEight" class="panel-collapse collapse">
						
                            <div class="panel-body">
				    <ul>
                           <li class="p6">Tweebaa shall have the absolute right to decline any submission for any
                reason.</li><br />
            <li class="p6">All Products are tangible goods and are not an invention concept, business
                idea, service or method of doing business. </li>
				<br />
            <li class="p6">Products shall be commercially available; not investment opportunities.</li>
			<br />
            <li class="p6">Submissions will NOT be treated confidentially; do not Suggest any confidential
                information.</li>
				<br />
            <li class="p6">Products shall not be counterfeit or stolen items.</li><br />
            <li class="p6">Products shall not knowingly infringe upon any third party's intellectual
                property rights (patents, trademarks, copyrights).</li><br />
            <li class="p6">Products shall not violate any applicable law, statute, ordinance or
                regulation (including, but not limited to, those governing export control, consumer
                protection, unfair competition, anti-discrimination or false advertising).</li><br />
            <li class="p6">Products shall not contain items that have been identified by the U.S.
                Consumer Products Safety Commission (CPSC) as hazardous to consumers and therefore
                subject to a recall.</li><br />
            <li class="p6">Products shall not be defamatory, be trade libelous, be unlawfully threatening,
                be unlawfully harassing, impersonate or intimidate any person (including Tweebaa
                staff or other users), or falsely state or otherwise misrepresent your affiliation
                with any person, through for example, the use of similar email address, nicknames,
                or creation of false account(s) or any other method or device.</li><br />
            <li class="p6">Products shall not be obscene, pornographic, sexually explicit or illegal
                in any respect.</li><br />
            <li class="p6">Products shall not host images unrelated to the submission, or link to
                or reference any website or phone number.</li><br />
            <li class="p6">If the same (or substantially similar) product is suggested by multiple
                suggesters, Tweebaa shall have the right to decline submissions based on the competing
                products. </li><br />
            <li class="p6">Tweebaa shall have the absolute right to decline any submission for any
                reason.</li><br />
            <li class="p6"><u>Tweebaa does not accept product from the following categories:</u></li><br />
			<ol>
            <li class="p9">Children & Infant items</li><br />
            <li class="p9">Furniture</li><br />
            <li class="p9">Supplements or Vitamins</li><br />
            <li class="p9">Cosmeceuticals / Topicals</li><br />
            <li class="p9">Pharmaceuticals / Drugs</li><br />
            <li class="p9">Medical products / Devices (other than household use)</li><br />
            <li class="p9">Weapons</li><br />
            <li class="p9">Real estate</li><br />
			</ol></ul>
                            
							</div>
                        </div>
                    </div>
                </div><!--/acc-v1-->
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