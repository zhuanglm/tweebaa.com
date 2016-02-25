<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="share-zone.aspx.cs" Inherits="TweebaaWebApp2.College.share_zone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
<!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Share Zone</h1>
            <ul class="pull-right breadcrumb">
       <li><a href="/index.aspx">Home</a></li>
                <li><a href="/College/Education.aspx">Education</a></li>
                <li class="active">Share Zone</li>
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
                                        <li><a href="/College/Suggest-zone.aspx#collapseOne">  About the Suggest Zone</a>
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
                                        <li><a  href="/College/evaluate-zone.aspx#collapseOne">
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
                                        <li ><a href="/College/shop-zone.aspx#collapseOne">
                                         About the SHOP Zone</a> </li>
                                       
                    <li><a href="/College/shop-zone.aspx#collapseTwo">Shop Details</a></li>
                    <li><a href="/College/shop-zone.aspx#collapseThree">More about “Test-Sale”</a></li>
                    <li><a href="/College/shop-zone.aspx#collapseFour">Payment Options</a></li>
                    <li><a href="/College/shop-zone.aspx#ollapseFive">Return Policies</a></li>
                    <li><a href="/College/shop-zone.aspx#collapseSix">Cancellation Policy</a></li>
                    <li><a href="/College/shop-zone.aspx#collapseEight">Wholesale Orders</a></li>
                                       
                                    </ul>
                                </li>

                                 <li class="active dropdown-tree open-tree"><a class="dropdown-tree-a">  Share Zone</a>
                                   <ul class="category-level-2 dropdown-menu-tree">
                                        <li ><a data-parent="#accordion" data-toggle="collapse"  href="#collapseOne">
                                         About Share Zone</a>
                                            
                                        </li>
                   
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseTwo">Share Zone Reward Points</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseFour">What is Share & Earn？</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseFive">How to Share & Earn</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseSix">How to Share a Purchase</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseSeven">Who else benefits from Sharing?</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseEight">Become an "Expert" Sharer</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseNight">Share examples</a></li>
                
                                       
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
                                     <dt class="p4"><span class="icon"></span>About the Share Zone</dt>
                                </a>
                            </h4>
							
                        </div>
						
                        <div id="collapseOne" class="panel-collapse collapse in">
						
						
                            <div class="panel-body">
                            
							<p><span style="color:#177ac0;font-weight:bold;">Tweebaa members</span> can earn cash and reward points while suggesting Tweebaa products to friends. By using the power of the Internet and sharing your favorite products with your social media network, you will earn a commission on every purchase sold on Tweebaa through your shared link.
							a commission on all sales of the product for life!</p>
							<br />
							<img src="../images/college/social-1.jpg" width="60%">
							<br />
							<br />
							<p>We use <b>Facebook</b> to see what’s new with our friends and tell them what’s new with us.</p>

							<p>We use <b>Twitter</b> to share quick updates.  <b>Pinterest</b>, <b>Google+</b>, and email are also great ways to share ideas, inspirations and news with our friends and followers. </p>
 
							<p>The list of social media venues (and ways to share) just keeps growing…<b>Istagram</b>, <b>Linked-In</b>, <b>Flipboard</b>, <b>Tumblr</b>, and even personal <b>blogs</b>…</p>

							<p>Sharing allows you to expose great products to the global market while helping to improve people’s lifestyles.  As a Sharer on Tweebaa, you have the power to earn significant money while helping other members (including Suggestter and Evaluators) to also earn cash rewards.  We call it “Team Tweebaa”--- members helping members every step of the way!</p>

							<p>While we’re on the subject of Social Media, please take a moment to connect with TWEEBAA!</p>
						</div>
                    </div>

					</div>
					
					
                    <div class="panel panel-default">
					
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                                <dt class="p4"><span class="icon"></span>Share Zone Reward Points</dt>
								</a>
                            </h4>
                        </div>
						
                        <div id="collapseTwo" class="panel-collapse collapse">
						
                            <div class="panel-body">
							
            <p>You will earn share zone reward points according to how frequently your friends click on product links that you have shared, and for each purchase transaction that originated from one of your Share & Earn links.</p> 
			<p>There are 10 reward point levels in the Share Zone; a member’s accrued points will determine his/her Share Zone Level.</p>   
			<p>If your friends purchase from Tweebaa from one of your Share & Earn links, you will earn a commission according to your Share Zone level at the time of the purchase transaction*.</p>

            <p style="color:#d60011;font-weight:bold;">*Commission percentage is based upon your Share Zone Level at the time of purchase transaction (not at the time of share). </p>

			<br />
            <h5><strong>Just browsing?  Be our guest!</strong></h5>
           

		   <p>If you browse 10 Tweebaa products per day, you can earn extra Browsing points! </p> 

			<p>Whether you’re looking for great Tweebaa purchases for yourself or seeking items to ‘share & earn’ with your friends, we’d like to reward you for browsing the Tweebaa Shop!</p>

		   <p>It’s easy to get started!  First, log in to your account.  Then each day, open at least ten Tweebaa Shop items (“Product Details” pages).  Stay on each product page for AT LEAST 30 seconds.  Must visit minimum ten items in a day to earn; for each day that you DO, you’ll receive 5 BONUS Share Zone Reward Points.</p>

		   <p>The more often (and the more products) you share, the higher your chance to earn commissions and reward points. </p> 
			
			<br>
		   <h5><strong>The following table describes how to earn Share Zone Reward Points:</strong></h5>
        <div class="panel panel-orange margin-bottom-40">
          <table class="table table-bordered shtab">
                     <tbody>
                    <tr>
                      <th scope="row" width="25%"> 
                            For each 10 clicks on shared links *
                        </th>
                        <td> When you click on a "Share" or "Share & Earn" button within any product detail page (excludes Evaluation), a unique link which is specific to YOUR account will be generated to identify you as the sharer.  Share links with your networks (via email or any social media venue), and you will receive a Share Zone point for every 10 clicks from unique IP addresses.
                                        </td>
                                        <td>
                                            +1 points
                                        </td>
                                    </tr>
                          <tr>
                           <th scope="row" width="25%"> 
                            For each purchase transaction 
                        </th>
                        <td>  Any time a purchase is made from one of your unique, shared links, you will receive 5 reward points.  Points are rewarded for total transaction (not per individual item ordered).  Note:  Tweebaa may deduct points for refund of full order transactions.
                                        </td>
                                        <td>
                                            +5 points
                                        </td>
                       </tr> 
                    <tr>
                          <th scope="row" width="25%"> 
                           Browsing Reward Points
                        </th>
                        <td> Open at least ten Tweebaa Shop items (“Product Details” pages).  Find the “Browse & Earn” logo and CLICK on it.  Must click ten in a day to earn; for each day that you DO, you’ll receive 5 BONUS Share Zone Reward Points.  (Access Browsing Points from "My Account" page.)
                                        </td>
                                        <td>
                                             +5 points
                                        </td>
                         </tr>   
                    </tbody>
                </table>
                </div>
			
               
                <h5><strong>In addition you can earn points in EVERY zone by checking in daily and referring new members.</strong></h5>
                

                <div class="panel panel-orange margin-bottom-40">
          <table class="table table-bordered shtab">
                     <tbody>
                    <tr>
                              <th scope="row" width="25%"> 
                                Daily Check-In
                            </th>
                            <td>Log in to your Member Account every day!  For each day that you click on "Daily Check-In", you will earn one point in each zone.  </td>
                                            <td>
                                                Bonus +1 point
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row" width="25%"> 
                                Daily Check-In
                            </th>
                                            <td >
                                                For each week that you check-in every day, you'll earn a BONUS 10 points in each zone!

                                            </td>
                                            <td>
                                                Bonus +10 point
                                            </td>
                                        </tr>
                                   
                         
                        <tr>
                             <th scope="row" width="25%"> 
                               New member referral
                         
                            </th>
                            <td>  Each time you refer a new Tweebaa member who registers, you will receive 30 points in all three Zones!  New member must either (1) list your email address as the referring friend or (2) register from your shared link.

                                            </td>
                                            <td>
                                                Bonus +30 points
                                            </td>
                                        </tr>
                                
                         </tbody>
                    </table>
                    </div>
                <br />
					 <p style="color:#d60011; font-size:12px;">* Clicks from duplicate IP addresses will count only once per HOUR and maximum 5 PER WEEK.  
					If IP address is unidentifiable, the click will be treated as a duplicate (subject to rule above).
					</p>
                   
        <p style="color:#d60011; font-weight:bold; font-size:10px;">Tweebaa reserves the right to deduct points or revoke membership for failure to abide by terms of service.</p>
							
							
                            </div>
                        </div>
						
                    </div>

					
					
					
					
					
				
					
					    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseFour">
                                    <dt class="p4"><span class="icon"></span>What is Share & Earn？</dt></a>
                            </h4>
                        </div>
                        
                        <div id="collapseFour" class="panel-collapse collapse">
                            <div class="panel-body">

							
							<p> <span style="color:#177ac0;font-weight:bold;">Share</span> your favorite products with your family and friends…if they buy, you’ll earn!</p>
							
							<h5><strong>Types of Share & Earn:</strong></h5>
							<ul>
							<li class="3">One-click Share.  Share via Facebook, Twitter, Google+, Pinterest, Email</li>
							<li class="3">Purchase Share.  Share your Tweebaa purchases with friends…if they purchase, you earn!</li>
							</ul>
							<br />
							<p>Tweebaa allows everyone to earn money online by sharing products with friends, families and followers.</p>  
							<p>Share as frequently… or as seldom as your time and desires permit.</p>  
							<p>You can make a simple gesture to help friends by suggesting products you know they will love… or you can build a lucrative business with zero investment by frequently sharing Tweebaa products via your social network or online store. No matter how you share, if a purchase is made via your shared link, you earn cash and point rewards.</p>
                            </div>
                        </div>
                    </div>
					
					
					
					
					
					
					
					
					
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseFive">
                                    <dt class="p4"><span class="icon"></span>How to Share & Earn (One-Click Sharing):</dt></a>
                            </h4>
                        </div>
                        
                        <div id="collapseFive" class="panel-collapse collapse">
                        <div class="panel-body">
                        <p>1. Browse the Share Zone or Shop Zone on Tweebaa and select the product that you would like to share with your friends.</p>
						<p>2. Click the "Share & Earn" button at the top right corner of the product listing.</p> 
						<p>3.Select the method you would like to use to share the product.</p>
						<p>4. When the “Share & Earn” window pops up, you can customize the message.  Here is an example of sharing with Facebook. </p>
						<p>5. Click to Share (Tweet, Post, Pin or Send) and your product is shared successfully!</p>
                <br />

                <img src="../images/college/process-2.png" width="70%"><br />

                 <p style="color:#d60011;font-weight:bold;">Reminder:</p>
				
				<p>In Tweebaa, each product in the Tweebaa Shop will have a Share & Earn button. Click the button to share the product via your social media accounts such as Facebook, Twitter, Google+ and Pinterest, or share via email.</p>
				
				<p>When you share a product, and your friend follows your shared link to Tweebaa, you will receive cash reward on ALL products purchased by your friend via the share transaction.</p>
            
                            </div>
                        </div>
                    </div>

					
					
					

					
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseSix">
                                    <dt class="p4"><span class="icon"></span>How to Share a Purchase</dt></a>
                            </h4>
                        </div>
                        <div id="collapseSix" class="panel-collapse collapse">
                    <div class="panel-body">
                                <p>After you make a purchase on Tweebaa, tell your friends and followers about it!  The fact that you have made a purchase is the most powerful way to share!  We’ve made it very EASY to share a purchase…and this is another great way to “Share & Earn”!</p>  
								<ul><li>1.	Once you complete a Tweebaa purchase, just click “Share Order” button from within the purchase confirmation<br><br>
                                    <img src="../images/college/share_order_1.png" width="70%" alt="weebaa share order"/><br><br></li>
                                    
                                    <li>2. Add a customized message to your friends, select the social media account on which you’d like to post and click “Share Now” to post your purchase message..<br><br>
                                    <img src="../images/college/share_order_2.png" width="70%" alt="tweebaa share order"/><br><br></li>
                                    
                                     <li>3. Anytime someone purchases an item via your “Purchase Share” link, you will receive a commission of between 5% - 9.5% of the selling price (based on your Share Zone Reward level).<br><br></li>
								</ul>
							</div>

                        </div>
                    </div>

					
					
					
					
					
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseSeven">
                                         <dt class="p4"><span class="icon"></span>Who else benefits from Sharing?<br /></dt>
                                </a>
                            </h4>
                        </div>
                        <div id="collapseSeven" class="panel-collapse collapse">
                            <div class="panel-body">
         <p style="color:#d60011;font-weight:bold;"><small>Your simple action of sharing will help improve many people’s lives!</small></p> 
 
        <b>CONSUMERS</b> get good quality products at competitive prices.<br /><br />
		<b>TWEEBAA MEMBERS</b> earn income. Sharing creates sales --- so Suggestter, Evaluators and Sharers can all earn income and reward points (WIN-WIN-WIN).<br /><br />
		<b>SUPPLIERS</b> benefit from great exposure and faster sales. <br /><br />
		<b>ENTREPRENEURS</b> find new products to sell in their stores. Tweebaa’s zero-investment platform gives e-tailers a catalog of products to promote in their online stores, and Tweebaa’s zero inventory and drop shipping services make it easier than ever to start a business.
                            </div>
                        </div>
                    </div>

					
					
					
					
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseEight">
                                            <dt class="p4"><span class="icon"></span>Become an "Expert" Sharer</dt></a>
                            </h4>
                        </div>
                        <div id="collapseEight" class="panel-collapse collapse">
                            <div class="panel-body">
                           
						   
						   <p>No matter who you are or where you come from, you can earn income by sharing great products with your social network. </p>
						   <p>The more you share, the more you sell. The more you sell, the more reward points you will accumulate until you reach the top reward level of 9.5% commission. </p>
						   
						   <p class="text-danger"><b>Your successful sharing could bring you a second career or even a new career!</b></p>
						   
						   <b>Tips for Social Media Sharing:</b> <br /><br />
						   <ul>
						   <li>In your post, mention a positive attribute of the product (why do you like it?)</li>
						   <li>Does the product solve a problem?  Tell your followers…maybe they can identify with the same problem.</li>
						   <li>Try not to sound too “salesy”.</li>
						   </ul>
						   
						   <br />
						   <br />
					
						   
                            </div>
                        </div>
                    </div>
					
					
					
					
					
					      <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseNight">
                                            <dt class="p4"><span class="icon"></span>Share examples</dt></a>
                            </h4>
                        </div>
                        <div id="collapseNight" class="panel-collapse collapse">
                            <div class="panel-body">

				    	   <strong>Example Facebook Share:</strong>
						   <br />
						   <br />
						   1.  Make sure that you are logged in to your Tweebaa account.  Find a product that you would like to share with your followers.  Click the “Share & Earn” button
						    <br />
						    <img src="../images/college/fb_share.png" width="70%"><br />
							<br />
							2.  Select the Facebook button
						   <br />
						    <img src="../images/college/fb_share_2.png" width="70%"><br />
						   <br />
						   3.  Just type in your message…
						   <br />
						    <img src="../images/college/fb_share_3.png" width="70%"><br />
						   <br />
						   4.  When you’ve finished typing your message, just click on the “Share” button at bottom of the post.  Facebook will pull in a product image, as well as YOUR unique Share & Earn link, which will track any clicks or purchases back to your Tweebaa account (so you will earn!).  Your post will look something like this:
						   <br />
						    <img src="../images/college/fb_share_4.png" width="70%"><br /><br /><br />


                           <strong>Example Pinterest Share:</strong><br /><br />

						   1. Make sure that you are logged in to your Tweebaa account.  Find a product that you would like to share with your followers.  Click the “Share & Earn” button
						   <br />
						    <img src="../images/college/pin_share_1.png" width="70%"><br />
						   <br />
						   2. Select the Pinterest button
						   						   <br />
 <img src="../images/college/pin_share_2.png" width="70%"><br />
						   <br />
						  3. Just type in your message…
						  <br />
						       <img src="../images/college/pin_share_3.png" width="70%"><br />
						  <br />
						  4. Edit the message as you wish, then select which “board” you want to pin the product to (I selected my board called “Products I Love”)
						  <br />
						  <img src="../images/college/pin_share_4.png" width="70%"><br />
						  <br />
						  5. PIN IT!  This is what my pin looks like on Pinterest.
						  
						    <br />
						      <img src="../images/college/pin_share_5.png" width="40%"><br />
						  <br />
						  
						  <strong>Example Google+ Share:</strong><br /><br />

1. Make sure that you are logged in to your Tweebaa account.  Find a product that you would like to share with your followers.  Click the “Share & Earn” button						   <br />
     <img src="../images/college/google_share_1.png" width="70%"><br />
						   <br />
						   2. Select the Google+ button
						    <br />
						       <img src="../images/college/google_share_2.png" width="70%"><br />
						   <br />
						  3. Just type in your message…
						  <br />
						     <img src="../images/college/google_share_3.png" width="40%"><br />
						  <br />
						  4.  PIN IT!  This is what my pin looks like on Google+.
						  <br />
						     <img src="../images/college/google_share_4.png" width="40%"><br />
						  <br />
				
						  
<strong>Example Email Share:</strong><br /><br />

1. Make sure that you are logged in to your Tweebaa account.  Find a product that you would like to share with your followers.  Click the “Share & Earn” button
<br />   <img src="../images/college/email_share_1.png" width="70%"><br /><br />						 
2.Just type in your name, a personal message, and your friend’s email address…					   						   <br />
<img src="../images/college/email_share_2.png" width="70%"><br />
						   <br />
3.SEND IT!  This is what my email to my friend Amy looks like.			  <br />
<img src="../images/college/email_share_3.png" width="70%"><br />
						  <br />
<img src="../images/college/email_share_4.png" width="70%"><br /><br /><br />



<strong>Example Twitter Share:</strong><br /><br />

 1. Make sure that you are logged in to your Tweebaa account.  Find a product that you would like to share with your followers.  Click the “Share & Earn” button
<br /><br />						 
2.  Select the Twitter button				   						   <br />
<img src="../images/college/twitter_share_1.png" width="70%"><br />
						   <br />
3.  Your Share & Earn link will automatically pull into your Tweet… add additional message as space allows		  <br />

						  <br />

4.  TWEET IT!  This is what my tweet looks like on Twitter.			  <br />  <br />  <br />	
				
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
