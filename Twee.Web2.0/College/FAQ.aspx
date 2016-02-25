<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="TweebaaWebApp2.College.FAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

      <!-- CSS Page Style -->    
    <link rel="stylesheet" href="/css/pages/page_search_inner.css">


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
 <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">FAQ</h1>
            <ul class="pull-right breadcrumb">
           <li><a href="/index.aspx">Home</a></li>
                <li><a href="/College/Education.aspx">Education</a></li>
                <li class="active">FAQ</li>
            </ul>
        </div> 
    </div><!--/breadcrumbs-->
<div class="search-block-v2" style="display:none">
        <div class="container">
            <div class="col-md-6 col-md-offset-3">
                <h2>Search What You Want Ask</h2>
                <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search words with regular expressions ...">
                    <span class="input-group-btn">
                        <button class="btn-u" type="button"><i class="fa fa-search"></i></button>
                    </span>
                </div>
            </div>
        </div>    
    </div>


       <div class="container content">	
 
                   <div class="row job-content">
            <div class="col-md-3">
            <button class="btn-u btn-brd rounded-2x btn-u-dark margin-bottom-10 btn-block" type="button">General</button>
            </div>
            <div class="col-md-3">
                   <button class="btn-u btn-brd rounded-2x btn-u-dark btn-block margin-bottom-10" onclick="window.location.href='#hrefZone'" type="button">Zone</button>
            </div> 
            <div class="col-md-3">
                   <button class="btn-u btn-brd rounded-2x btn-u-dark btn-block margin-bottom-10" onclick="window.location.href='#hrefShop'" type="button">Shop</button>
            </div> 
            
           <div class="col-md-3">
                   <button class="btn-u btn-brd rounded-2x btn-u-dark btn-block margin-bottom-10" onclick="window.location.href='#hrefMember'"  type="button">Member account</button>
            </div>  
            
            </div> 
   
               </div>

      <!--=== Content Part ===-->
    <div class="container content">	
   <div class="row"> 

   <!--new drop down catoryies
    <div class="col-md-3">
             
                <div class="panel-group" id="accordion-v2">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h2 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion-v2" href="#">
                                 General
                                    <i class="fa fa-angle-down"></i>
                                </a>
                            </h2>
                        </div>
                  
                            <div id="collapseCategory" class="panel-collapse collapse in">
                        <div class="panel-body">
                            <ul class="nav nav-pills nav-stacked tree">
                                <li class="active dropdown-tree open-tree">
                                   <ul class="category-level-2 dropdown-menu-tree">
               <li class="dropdown-tree open-tree"><a class="dropdown-tree-a" href="/College/Suggest-zone.aspx#collapseOne">
                                         What is Tweebaa?</a>
                                       
                      <li><a data-parent="#accordion" data-toggle="collapse" href="/Page.aspx?id=3">How do I become a Tweebaa member?</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseFour">How do I make money on Tweebaa?</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseFive">How do I earn points on Tweebaa?</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseSix">Preparing your suggestion</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseSeven">Suggest steps</a></li>
                    <li><a data-parent="#accordion" data-toggle="collapse" href="#collapseEight">Product Guidelines</a></li>
                                       
                                    </ul>
                                </li>
                            
                               
                            </ul>
                        </div>
                    </div>
                      
                    </div>
                </div>
               
            </div>  -->
			
            <div class="col-md-12">
		  <!--General Questions -->
		  <div class="headline"><a id="hrefZone"></a><h2>General Questions</h2></div>
                <div class="panel-group acc-v1 margin-bottom-40" id="accordion">
				
                    <div class="panel panel-default">
					
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseOne">
                                     <dt class="p4"><span class="icon"></span>What is Tweebaa?</dt>
                                </a>
                            </h4>
                        </div>
						
                        <div id="collapseOne" class="panel-collapse collapse">
                            <div class="panel-body">
                     <p> Tweebaa is an e-commerce company with a great selection of products, and allows every member to earn additional income. Tweebaa members can suggest, evaluate, shop, or share products with their social media networks to earn extra money, reward points and even free gifts.</p>
						

							</div>
                   </div>
                 </div>

					
					
					
                    <div class="panel panel-default">
					
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                                <dt class="p4"><span class="icon"></span>How do I become a Tweebaa member?</dt>
								</a>
                            </h4>
                        </div>
						
                        <div id="collapseTwo" class="panel-collapse collapse">
						
                            <div class="panel-body">

							
				<p>
		There’s no cost or obligation to become a Tweebaa member, and you can start earning cash and rewards today!  If you are at least 18 years of age, just click the “Register” button on top-right corner of our homepage.    Fill out a few questions and select a user-ID to represent you within the Tweebaa community.  We’ll never disclose your real identity on the Tweebaa site, just your user-ID --- so you can feel secure in expressing thoughts, evaluations, etc.
				</p>
		

				
							
                            </div>
                        </div>
						
                    </div>

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseFour">
                                    <dt class="p4"><span class="icon"></span>How do I make money on Tweebaa?</dt></a>
                            </h4>
                        </div>
                        
                        <div id="collapseFour" class="panel-collapse collapse">
                            <div class="panel-body">
                             <p>Help us select new items to add to the Tweebaa Shop by submitting products in the Suggest Zone and participating in simple surveys in the Evaluate Zone.  If you love to “shop ‘til you drop” you’ll earn discounts and Shopping Reward Points on all purchases, and when you share Tweebaa items with your friends, you can earn ongoing commissions with every purchase.</p>
          
                            </div>
                        </div>
                    </div>

					
					
					
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseFive">
                                    <dt class="p4"><span class="icon"></span>How do I earn points on Tweebaa?</dt></a>
                            </h4>
                        </div>
                        <div id="collapseFive" class="panel-collapse collapse">
                            <div class="panel-body">
							
                                 <p>There are many ways to earn points on Tweebaa:</p>

                <li class="p6">*  You can receive "Suggest Zone" points for each approved suggestion you submit, with the number of points increasing based on how far each product goes in the Evaluation process.
                  
                    <li class="p6">*  You will receive one point in every zone (Suggest, Evaluate, Share) just by logging in every day and clicking the “Daily Check-In” button.<br />
              
               <li class="p6">*  You will receive 30 points in every zone (Suggest, Evaluate, Share) for each new member that you refer.</li>
                                
                    <li class="p6">*  You will receive "Evaluate Zone" points for each evaluation survey that you complete.</li>    
                    
                   <li class="p6">*  If you suggest a product that eventually advances to "Test-Sale" you will earn 30 Suggest Zone points.</li> 
                     <li class="p6">*  For every dollar you spend on Tweebaa.com, you will earn one Shopping Reward Point.</li> 
                       <li class="p6">*  Play games on the Tweebaa APP to earn Share Zone points.</li> 
                
      
                     </div>
                        </div>
                    </div>


					
					
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseSix">
                                         <dt class="p4"><span class="icon"></span>What is a TweeBuck?</dt>
                                </a>
                            </h4>
                        </div>
                        <div id="collapseSix" class="panel-collapse collapse">
                            <div class="panel-body">

                 <p >TweeBuck is Tweebaa's currency that allows you to convert your points into Cash (One TweeBuck = One US Dollar)</p>
				
					</div>
				</div>
			</div>

					
			
					
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseSeven">
                                            <dt class="p4"><span class="icon"></span>How do I exchange TweeBucks for cash?</dt>
								</a>
                            </h4>
                        </div>
                        <div id="collapseSeven" class="panel-collapse collapse">
                            <div class="panel-body">
                 <p>As you accrue TweeBucks, they will be deposited into your Tweebaa account. When any purchase transaction is completed and TweeBucks are added, they will be listed as "pending status" until product has shipped to the customer and the return period has expired.  At that time, "Pending" TweeBucks will be transferred to "available" status and can be redeemed for cash or purchase credits.  To redeem for cash, all you need to do is create or link a PayPal account and click the "Redeem Now" button in your member account.</p>
                            </div>
                        </div>
                    </div>
					
					 <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseEight">
                         <dt class="p4"><span class="icon"></span>Is it necessary to set up PayPal account to be a Tweebaa member?</dt></a>
                            </h4>
                        </div>
                        <div id="collapseEight" class="panel-collapse collapse">
						
                            <div class="panel-body">
                 <p>NO, it is not necessary, but if you earn TweeBucks on Tweebaa and wish to redeem them for cash, PayPal is the means by which we will send your payment.  You can always redeem your TweeBucks towards purchases at the Tweebaa shop.</p>
                            
							</div>
                        </div>
                    </div>
		 <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapse9">
                         <dt class="p4"><span class="icon"></span>What is the minimum redemption of TweeBucks?</dt></a>
                            </h4>
                        </div>
                        <div id="collapse9" class="panel-collapse collapse">
						
                            <div class="panel-body">
                 <p>The minimum withdrawl amount is $10 (10 TweeBucks) per transaction (maximum one transaction per week.
                 
                 </p>
                            
							</div>
                        </div>
                    </div>
	 <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapse10">
                         <dt class="p4"><span class="icon"></span>Are there any fees to redeem?</dt></a>
                            </h4>
                        </div>
                        <div id="collapse10" class="panel-collapse collapse">
						
                            <div class="panel-body">
                 <p>PayPal may charge a nominal transaction fee, which will be deducted from your redemption amount.
                 
                 </p>
                            
							</div>
                        </div>
                    </div>
 <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapse11">
                         <dt class="p4"><span class="icon"></span>How long will it take to get the cash redemption?</dt></a>
                            </h4>
                        </div>
                        <div id="collapse11" class="panel-collapse collapse">
						
                            <div class="panel-body">
                 <p>It will take up to 48 hours for review and approval of your cash redemption request before funds are deposited in your Paypal account.
                 
                 </p>
                            
							</div>
                        </div>
                    </div>
 <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapse12">
                         <dt class="p4"><span class="icon"></span>How do I earn Shopping Reward points?</dt></a>
                            </h4>
                        </div>
                        <div id="collapse12" class="panel-collapse collapse">
						
                            <div class="panel-body">
                 <p>For every dollar you spend at Tweebaa.com (excluding shipping fees and taxes), you will earn one Shopping Reward Point.  400 points have a redemption value of $5.00 at the Tweebaa shop.  Note:  You must be logged in to your account at checkout time, in order to earn the points (you will be prompted at checkout to register/log-in.
                 </p>
                            
							</div>
                        </div>
                    </div>
 <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapse13">
                         <dt class="p4"><span class="icon"></span>Do Shopping Reward points expire?</dt></a>
                            </h4>
                        </div>
                        <div id="collapse13" class="panel-collapse collapse">
						
                            <div class="panel-body">
                 <p>Shopping Reward Points expire 6 months from purchase.
                 
                 </p>
                            
							</div>
                        </div>
                    </div>
<div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapse14">
                         <dt class="p4"><span class="icon"></span>Where is Tweebaa’s headquarters?</dt></a>
                            </h4>
                        </div>
                        <div id="collapse14" class="panel-collapse collapse">
						
                            <div class="panel-body">
                 <p>Our Headquarters is located at 3601 Hwy 7 East , HSBC Tower Suite 302 , Markham , Ontario L3R 0M3 CANADA
                 
                 </p>
                            
							</div>
                        </div>
                    </div>
<div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapse15">
                         <dt class="p4"><span class="icon"></span>Does Tweebaa have a shopping App?</dt></a>
                            </h4>
                        </div>
                        <div id="collapse15" class="panel-collapse collapse">
						
                            <div class="panel-body">
                 <p>Not yet, we have a game app which can direct you to our website, but not a shopping App yet. Stay tuned! It is in the works!
                 
                 </p>
                            
							</div>
                        </div>
                    </div></div>
			  <!-- End General Questions -->

	<!-- Zone Questions -->
                <div class="headline"><a id="hrefShop"></a><h2>Zone Questions</h2></div>
		
                <div class="panel-group acc-v1 margin-bottom-40" id="accordion-1">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseZ_One">
                                    <dt class="p4"><span class="icon"></span>How can I earn by Suggesting new products?</dt>
                                </a>
                            </h4>
                        </div>
                    
                        <div id="collapseZ_One" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>Suggesters earn by telling Tweebaa about emerging items. <br>
EARN CASH:  Suggester of the product receives a one-time commisison reward of 30 TweeBucks (redemption value $30 USD), and will receive a LIFETIME COMMISSION of 0.5% - 1.0% of product's selling price for purchases from Tweebaa shop.  For commission level, please see Commission Chart. <br>
EARN POINTS:  You will earn suggest zone reward points according to how often you suggest and how successful your products are in reaching the Tweebaa shop.  Please see Education > Suggest Zone for further details.
</p>
                             </div>
                         </div></div>
                                
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseZ_Two">
                                  <dt class="p4"><span class="icon"></span>How can I earn by Evaluating?</dt>
                                </a>
                            </h4>
                        </div>
                    
                        <div id="collapseZ_Two" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>Evaluators earn by taking surveys to rate potential Tweebaa products.<br>
EARN CASH:  When a product is "Tweebaa Approved", two evaluators will receive a lifetime commisison of 0.2% - 0.65% of evaluated product's selling price in Tweebaa shp.  For commisison level, please see Commission Chart.<br>
EARN POINTS:  You will earn evaluate zone reward oints according to how often you evaluate and how accurate your evaluations are.  Each member can evaluate up to 10 products per day.  Please see Education > Evaluate Zone for further details.</p>
                            </div>
                        </div> </div>
                   
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseZ_Three">
                                 <dt class="p4"><span class="icon"></span>How can I earn by Sharing?</dt>
                                </a>
                            </h4>
                        </div>
                                        
                        <div id="collapseZ_Three" class="panel-collapse collapse">
                            <div class="panel-body">
                                <p>Sharers earn by telling friends about Tweebaa products.<br>
EARN CASH:  Sharer will receive a commission of 5% - 10% of product's selling price for every purchase made through the sharer's unique link.  Commisison is earned in TweeBucks and redeemable for cash.  For commission level, please see Commission Chart.<br>
EARN POINTS:  You will earn share zone reward points according to how frequently your friends click on product links that you have shared, and for each purchase transaction that originated from one of your Share & Earn links.   Please see Education > Share Zone for further details.</p>
                            </div>
                        </div> </div>    
                   
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseZ_Four">
                                <dt class="p4"><span class="icon"></span> How do I advance to higher Commission percent?</dt>
                                </a>
                            </h4>
                        </div>
                   
                        <div id="collapseZ_Four" class="panel-collapse collapse">
                            <div class="panel-body">
                               <p>Commission percentages are directly tied to your Zone reward points in each zone.  The more points you accumulate in the Suggest Zone, Evaluate Zone and Share Zone, the higher your reward!  See <u>Commission Chart</u> for levels and percentages.</p>
                            </div>
                        </div> </div>
                  
                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseZ_Five">
                                    <dt class="p4"><span class="icon"></span>How do I earn referral reward points?</dt>
                                </a>
                            </h4>
                        </div>
                     
                        <div id="collapseZ_Five" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>Evaluators earn by taking surveys to rate potential Tweebaa products.<br>
EARN CASH:  When a product is "Tweebaa Approved", two evaluators will receive a lifetime commisison of 0.2% - 0.65% of evaluated product's selling price in Tweebaa shp.  For commisison level, please see Commission Chart.<br>
EARN POINTS:  You will earn evaluate zone reward oints according to how often you evaluate and how accurate your evaluations are.  Each member can evaluate up to 10 products per day.  Please see Education > Evaluate Zone for further details.</p>
                            </div>
                        </div></div>
                        
                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseZ_Six">
                                  <dt class="p4"><span class="icon"></span>Where can I share products?</dt>
                                </a>
                            </h4>
                        </div>
                    
                        <div id="collapseZ_Six" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>You can share Tweebaa products on Facebook, Twitter, Google+, Pinterest, Email or really ANYWHERE that you can post your "share & earn" link.</p>
                            </div>
                        </div> </div>
                                                
                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseZ_Seven">
                                 <dt class="p4"><span class="icon"></span> How long does a product stay in Evaluation stage?</dt>
                                </a>
                            </h4>
                        </div>
                     
                        <div id="collapseZ_Seven" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>A product must receive 300 favorable evaluations before it can advance from the Evaluation stage.  There is no set time limit to receive the 300 evaluations.</p>
                            </div>
                        </div></div>
                        
                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseZ_Eight">
                                   <dt class="p4"><span class="icon"></span>How do I access the Tweebaa collage?</dt>
                                </a>
                            </h4>
                        </div>
                     
                        <div id="collapseZ_Eight" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>Collages can be viewed by clicking “Collage” under the Share button, or you may download the App to view and create your own collages.</p>
                            </div>
                        </div></div>
                        
                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseZ_Nine">
                                  <dt class="p4"><span class="icon"></span> If I share a product with a friend and they purchase it but return it within the warranty period, do I lose my points?</dt>
                                </a>
                            </h4>
                        </div>
                     
                        <div id="collapseZ_Nine" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>Yes, points and rewards are based on the purchase, so if a return happens your points will be subtracted accordingly. </p>
                            </div>
                        </div> </div>
                                                                                                                  <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseZ_Ten">
                                    <dt class="p4"><span class="icon"></span>Are there restrictions on types of product I can Suggest to Tweebaa?</dt>
                                </a>
                            </h4>
                      
                      </div>
                        <div id="collapseZ_Ten" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>suggest any confidential information.  Products shall not be counterfeit or stolen items.  Products shall not knowingly infringe upon any third party's intellectual property rights (patents, trademarks, copyrights).  Products shall not violate any applicable law, statute, ordinance or regulation (including, but not limited to, those governing export control, consumer protection, unfair competition, anti-discrimination or false advertising).  Products shall not contain items that have been identified by the U.S. Consumer Products Safety Commission (CPSC) as hazardous to consumers and therefore subject to a recall.  Products shall not be defamatory, be trade libelous, be unlawfully threatening, be unlawfully harassing, impersonate or intimidate any person (including Tweebaa staff or other users), or falsely state or otherwise misrepresent your affiliation with any person, through for example, the use of similar email address, nicknames, or creation of false account(s) or any other method or device.  Products shall not be obscene, pornographic, sexually explicit or illegal in any respect.  Products shall not host images unrelated to the submission, or link to or reference any website or phone number.  If the same (or substantially similar) product is suggested by multiple suggesters, Tweebaa shall have the right to decline submissions based on the competing products.  Tweebaa shall have the absolute right to decline any suggestion for any reason. Tweebaa does not accept product from the following categories: Supplements or Vitamins, Cosmeceuticals / Topicals, Pharmaceuticals / Drugs, Medical products / Devices (other than household use), Weapons, Real estate.</p>
                            </div>
                        </div>  </div>
                        
                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseZ_11">
                                   <dt class="p4"><span class="icon"></span>What is a Collage?</dt>
                                </a>
                            </h4>
                        </div>
               
                        <div id="collapseZ_11" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>A Tweebaa Collage is a collection of selected products from the Tweebaa Shop that usually center around a theme and are displayed creatively on one page.  You can create your own collages to share with others or you can browse and share collages that other members have designed. Regardless of who creates the collage, the sharer and the designer earn a commission on all purchases that originate from a product link to the shared collage.</p>
                            </div>
                        </div>      </div>
                        
                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseZ_12">
                                 <dt class="p4"><span class="icon"></span>How do I design a Collage?</dt>
                                </a>
                            </h4>
                        </div>
                    
                        <div id="collapseZ_12" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>It’s easy to drag and drop items onto a template and create an attractive collage that can increase your earnings potential.  To get started, you must first download the Tweebaa App.</p>
                            </div>
                        </div> </div>
                        
                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseZ_13">
                                  <dt class="p4"><span class="icon"></span> Where can I look at Collage designs?</dt>
                                </a>
                            </h4>
                        </div>
                  
                        <div id="collapseZ_13" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>Want to see what others are designing?  You can click on Share > Collage in the header bar at tweebaa.com.</p>
                            </div>
                        </div>   </div>
                        
                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseZ_14">
                                  <dt class="p4"><span class="icon"></span>What are Browsing points?</dt>
                                </a>
                            </h4>
                        </div>
                      
                        <div id="collapseZ_14" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>If you browse 10 Tweebaa products per day, you can earn extra Browsing points!  First, log in to your account.  Then each day, open at least ten Tweebaa Shop items (“Product Details” pages) and remain on each page for at least 30 seconds (there is a timer on right side of page); for each day that you DO, you’ll receive 5 BONUS Share Zone Reward Points.</p>
                            </div>
                        </div></div>

                          <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseZ_15">
                                  <dt class="p4"><span class="icon"></span> As a Collage designer, how can I earn?</dt>
                                </a>
                            </h4>
                        </div>
                    
                        <div id="collapseZ_15" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>Collage Designers will earn on ALL SALES which generate from his or her collage designs… Commission is based on one-half of the Designer’s Share Zone commission level at the time of each purchase.  Designers…if you share your own collages, you'll earn at your FULL share-level commission.</p>
                            </div>
                        </div>
				 </div>
                        
                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseZ_16">
                                  <dt class="p4"><span class="icon"></span>How can I earn by sharing other people's Collage?</dt>
                                </a>
                            </h4>
                        </div>
                     
                        <div id="collapseZ_16" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>Members who share Collages can earn one-half of his/her Share Zone commission based on his/her level at the time of each purchase.  (That applies to every product included in the collage!)</p>
                            </div>
                        </div>
				</div>
                        
                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseZ_17">
                                   <dt class="p4"><span class="icon"></span>How do I "Share & Earn"?</dt>
                                </a>
                            </h4>
                        </div>
                    
                        <div id="collapseZ_17" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>Browse the Tweebaa shop and select the product that you would like to share with your friends.  Every product has a "Share & Earn" button.  Just click on it, then select the method you would like to use for sharing the product (select from Facebook, Twitter, Google+, Pinterest or email).  You will be prompted to enter a personal message, then "send".  That's it!</p>
                            </div>
                        </div>
				 </div>
                  </div>
                                                                                             
                <!-- End Zone Questions -->

		      
    			<!-- Shop Questions -->
                <div class="headline"><a id="hrefMember"></a><h2>Shop Questions</h2></div>
                <div class="panel-group acc-v1 margin-bottom-40" id="Shop Questions">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseS_One">
                                   <dt class="p4"><span class="icon"></span>What payment methods can I use?</dt>
                                </a>
                            </h4>
                        </div>
                   
                        <div id="collapseS_One" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>Tweebaa accepts most major credit cards including Mastercard, Visa, Discover, and American Express.   If you prefer, you may pay with an existing PayPal account.  All payments are processed securely using PayPal merchant services.  Tweebaa does NOT store any of your credit-card information.
</p>
                             </div>
                         </div> </div>
                         
                          <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseS_Two">
                                  <dt class="p4"><span class="icon"></span> What types of discounts are available?</dt>
                                </a>
                            </h4>
                        </div>
                 
                        <div id="collapseS_Two" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>It pays to become a Tweebaa member.  Members can accumulate commissions and points, which can be redeemed for merchandise discounts. <br>
* Shopping Reward Points - Members earn Shopping Reward Points with every purchase.  They can be redeemed at checkout (400 points = $5.00). <br>
* TweeBucks – Members earn TweeBucks commissions by suggesting, evaluating or sharing Tweebaa products.  TweeBucks can be redeemed for cash; or they can be applied just like cash at checkout. <br>
* TweeBucks – Members earn TweeBucks commissions by suggesting, evaluating or sharing Tweebaa products.  TweeBucks can be redeemed for cash; or they can be applied just like cash at checkout. <br>
* Share Reward Points – Members earn Share Points by taking part in Tweebaa activities, like sharing products and playing games on Tweebaa APP.  They have a redemption value of $0.01 per point (ex:  1,000 Share points = $1.00 discount). <br>
</p>
                             </div>
                        </div>    </div>
                        
                        <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseS_Three">
                                  <dt class="p4"><span class="icon"></span> What are the shipping rates?</dt>
                                </a>
                            </h4>
                        </div>
                                         
                        <div id="collapseS_Three" class="panel-collapse collapse">
                            <div class="panel-body">
                                <p>Select Tweebaa items have FREE SHIPPING (you may select expedited shipping for additional fee).  For items which do not have FREE SHIPPING, please refer to the following ship rate table:  INSERT TABLE.</p>
                            </div>
                        </div></div>    
                   
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseS_Four">
                                  <dt class="p4"><span class="icon"></span>How long will it take to get my order?</dt>
                                </a>
                            </h4>
                        </div>
                   
                        <div id="collapseS_Four" class="panel-collapse collapse">
                            <div class="panel-body">
                               <p><u>“Test Sale” items</u> – if you ordered a “Test Sale” item, please expect longer lead-times.  Test Sale items are brand-new to the Tweebaa shop, and have 60 days to meet a pre-set sales quota.  If that quota is met within 60 days, all the Test Sale orders are “ON”.  If the quota is NOT met, you will receive a FULL REFUND of the Test Sale purchase.  
<u>“Buy Now” items</u> – these items typically ship out within 24 hours; allow up to 10 days for shipping.</p>
                            </div>
                        </div> </div>
                  
                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseS_Five">
                                <dt class="p4"><span class="icon"></span> What is Tweebaa's return policy?</dt>
                                </a>
                            </h4>
                        </div>
               
                        <div id="collapseS_Five" class="panel-collapse collapse">
                            <div class="panel-body">
                                <p>Tweebaa offers customers a thirty-day satisfaction guarantee. If you are unhappy with your Tweebaa purchase for any reason, you can return it for a full refund.</p>
                            </div>
                        </div>      </div>
                        
                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseS_Six">
                                  <dt class="p4"><span class="icon"></span> What is a "Test Sale" product?</dt>
                                </a>
                            </h4>
                        </div>
                     
                        <div id="collapseS_Six" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>Test-Sale items must sell a certain quota within 60 days in order to advance to the Tweebaa Shop.  Each Test-Sale purchase is a step towards becoming “Tweebaa Approved” and reaching the Tweebaa Shop.  If the Test-Sale quota is met in the designated time frame (60 days), the test sale is a PASS and all the test-sale orders are ON (test-sale orders will be shipped; ship time is normally 30-60 days after the Test-Sale goal is reached).  Tweebaa will notify buyers as soon as the 60-day time frame is over, and if Test-Sale is “Pass”, we will provide an approximate ship date.</p>
                            </div>
                        </div></div>
                                                
                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseS_Seven">
                                   <dt class="p4"><span class="icon"></span>What if a product fails Test-Sale?</dt>
                                </a>
                            </h4>
                        </div>
                    
                        <div id="collapseS_Seven" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>If the Test-Sale quota is NOT met in the designated time, the test sale is a FAIL and all test-sale orders will be cancelled. <u>Buyers will receive full refunds of the purchase price. </u> Tweebaa will notify buyers as soon as the 60-day time frame is over.</p>
                            </div>
                        </div> </div>
                        
                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseS_Eight">
                                    <dt class="p4"><span class="icon"></span>How do I return an order (Tweebaa member)?</dt>
                                </a>
                            </h4>
                        </div>
                     
                        <div id="collapseS_Eight" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>If you are a Tweebaa Member, simply log on to your Member Account and on the menu bar (left side of page) select “Refund/Return” (under “My Shopping Cart”).  Click on the order, and then the item, that you wish to return.  Tweebaa will issue you a return authorization number and label, which should be affixed to the outside of your return package.</p>
                            </div>
                        </div></div>

                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseS_Nine">
                                   <dt class="p4"><span class="icon"></span>How do I return an order (non-member/guest)?</dt>
                                </a>
                            </h4>
                        </div>
                      
                        <div id="collapseS_Nine" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>If you selected “Checkout as Guest” when you placed your order, please notify us by email (service@tweebaa.com) if you wish to return an order/item. Please specify the order number and item you want to return in your request.  Tweebaa will issue you a return authorization number and label, which should be affixed to the outside of your return package. </p>
                            </div>
                        </div></div>

                     <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseS_Ten">
                                   <dt class="p4"><span class="icon"></span>What is Tweebaa's cancellation policy?</dt>
                                </a>
                            </h4>
                        </div>
                    
                        <div id="collapseS_Ten" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>With the exception of “Test-Sale” items, we cannot process cancellations once payment transaction is completed.  Due to the extended lead-times for “Test-Sale” items, you may cancel your order at any time prior to shipment. You will be notified once Test-Sale reaches the “Pass” or “Fail” status, and if Test-Sale has Passed, we will provide an estimated ship date for your general reference.  You may cancel Test-Sale orders at any time during the wait period.</p>
                            </div>
                        </div>  </div>

                          <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseS_11">
                               <dt class="p4"><span class="icon"></span> I'm a wholesaler; can I order from Tweebaa at wholesale rates?</dt>
                                </a>
                            </h4>
                        </div>
                     
                        <div id="collapseS_11" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>Tweebaa would love to work with wholesalers!  If you are a wholesaler and have interest in any Tweebaa products, please contact us for additional information!  On our Shop page, you can simply click on the link for “Wholesale Inquiries”.</p>
                            </div>
                        </div>     </div>           </div>  
					<!-- End Shop Questions -->

  			<!-- Member Account Questions -->
                <div class="headline"><h2>Member Account Questions</h2></div>
                <div class="panel-group acc-v1 margin-bottom-40" id="Member Account Questions">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseM_One">
                                  <dt class="p4"><span class="icon"></span>How do I access my Tweebaa account information?</dt>
                                </a>
                            </h4>
                        
                    </div>
                        <div id="collapseM_One" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>Every Tweebaa member can access important membership data at his or her “My Account” page.  Information like reward summaries, order history, and a listing of favorite items are all just a click away.  To access your account, click “Login” at top-right corner of our website.  (If you are not yet a Tweebaa member, click “Register”).
</p>
                             </div>
                         </div></div>
                         
                          <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseM_Two">
                                 <dt class="p4"><span class="icon"></span>How can I change the email address on my Tweebaa account?</dt>
                                </a>
                            </h4>
                       
                    </div>
                        <div id="collapseM_Two" class="panel-collapse collapse">
                            <div class="panel-body">
                                        <p>Log on to your Tweebaa account, then select My Account > Account Setting > Change email.<br>
</p>
                             </div>
                        </div>  </div>
                        
                        <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseM_Three">
                                    <dt class="p4"><span class="icon"></span>How can I change the password on my Tweebaa account?</dt>
                                </a>
                            </h4>
                        </div>
                                         
                        <div id="collapseM_Three" class="panel-collapse collapse">
                            <div class="panel-body">
                                <p>Log on to your Tweebaa account, then select My Account > Account Setting > Change password.</p>
                            </div>
                        </div>  </div>  
                   
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion-1" href="#collapseM_Four">
                                   <dt class="p4"><span class="icon"></span>How can I change the shipping address listed on my Tweebaa account?</dt>
                                </a>
                            </h4>
                        </div>
                   
                        <div id="collapseM_Four" class="panel-collapse collapse">
                            <div class="panel-body">
                               <p>Log on to your Tweebaa account, then select My Account > My Shipping Address, then either select "Edit" (to change an address) or "Add Address" (to add an additional address).</p>
                            </div>
                        </div> </div>
    </div>	



                </div><!--/acc-v1-->
    		</div><!--/col-md-9-->
            
            		
        </div><!--/row-->

    </div>	
    <!--=== End Content Part ===-->
</asp:Content>
