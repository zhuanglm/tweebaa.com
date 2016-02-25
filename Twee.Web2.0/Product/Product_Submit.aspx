<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Product_Submit.aspx.cs" Inherits="TweebaaWebApp2.Product.Product_Submit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Suggest a Product - earn commissions, cash rewards and points
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">	<link rel="stylesheet" href="../css/scroll.css" />
	<script src="../js/jquery.min.js" type="text/javascript"></script>
	<script src="../js/jquery.placeholder.js" type="text/javascript"></script>
	<script src="../js/reg.js" type="text/javascript"></script>
	<script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
	<script type="text/javascript" src="../js/jquery.xScroller.js"></script>
	<script type="text/javascript" src="../js/dragbox.js"></script>
	<link rel="stylesheet" href="../css/selectCss.css" />
	<script src="../js/selectCss.js" type="text/javascript"></script>
        <!-- CSS Page Style -->
    <link rel="stylesheet" href="/css/pages/log-reg-v3.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
<form id="Form1" runat="server">
 <!--=== Breadcrumbs v4 ===-->
    <div class="breadcrumbs-v4 submit_back">
        <div class="container">
            <h1>
Tell us about <strong> great products…</strong></h1>
<p>Earn cash on every sale when you suggest items to Tweebaa!</p>
            <ul class="breadcrumb-v4-in">
                <li><a href="/index.aspx">Home</a></li>
                <li><a href="#">Suggest</a></li>
                <li class="active">Welcome</li>
            </ul>
        </div><!--/end container-->
    </div> 
    <!--=== End Breadcrumbs v4 ===-->
 <!--=== Registre ===-->
    <div class="suggest-wel content-sm ">
        <div class="container margin-top-20">
            <div class="row">
                <div class="col-md-12 md-margin-bottom-50">
                    <h2 class="welcome-title">Welcome to Suggest</h2>
                    <p>We are relying on suggesters (like YOU) to tell us about emerging items, useful gadgets and must-have consumer products. <br/>
If your product advances to the Tweebaa Shop, you will earn a commission on all sales of the product for life!!</p><br>
  <div class="members-number">
                        <h3>Earn commissions, cash rewards and points.</h3>
                 
                    </div> 
			       <div class="row margin-top-20">
                        <div class="col-sm-6 md-margin-bottom-40">
  	     <a class="btn-u-lg-blue btn-block rounded"  id="A1" href="javascript:void(0)" runat="server" onserverclick="checkLogin_click" >Suggest a Product</a>
                        </div>
                       </div>
                    <div class="row margin-bottom-50 margin-top-20">
			                          <div class="col-sm-12 md-margin-bottom-20">
                         <button class="btn btn-sm rounded btn-default" type="button">   <a href="/College/Suggest-zone.aspx#collapseOne">Learn more about suggesting </a></button>
                             <button class="btn btn-sm rounded btn-default" type="button"><a href="/College/Suggest-zone.aspx#collapseFive">Tips for a great suggestion</a></button>  
                        </div>

                      
                    </div>
                     
                </div>
                
                <!--
                <div class="col-md-5 suggest-block sky-form">
   <a class="btn-u-lg-blue btn-block rounded margin-bottom-20"  id="A2" href="javascript:void(0)" runat="server" onserverclick="checkLogin_click" >Suggest a Product</a>
                        <div class="col-md-12 margin-bottom-10 ">
                          <span><img src="/images/blueman.png">
                         <h3 class="submit-blue"> The Suggester</h3>
                            <p>Trend-setting & resourceful. <br>
Suggesters see a need, 
then find a solution</p></span>


                        </div>
       
                  
                </div> -->
 
            </div><!--/end row-->
        </div><!--/end container-->
    </div>
    <!--=== End Registre ===-->    

</form>
</asp:Content>
