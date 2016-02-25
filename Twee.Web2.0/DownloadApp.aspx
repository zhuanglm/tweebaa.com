<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="DownloadApp.aspx.cs" Inherits="TweebaaWebApp2.DownloadApp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

            <!--=== Breadcrumbs v4 ===-->
    <div class="breadcrumbs-v4 share_back">
        <div class="container">
          <h1> Share products with your friends...</h1>
          <p>Earn cash and points for sharing on your social networks!</p>
            <ul class="breadcrumb-v4-in">
                <li><a href="/index.aspx">Home</a></li>
              <!--  <li><a href="#">Share</a></li> -->
                <li class="active">Download App</li>
            </ul>
        </div><!--/end container-->
    </div> 
    <!--=== End Breadcrumbs v4 ===-->

     <!--=== Content Part ===-->
    <div class="content container">
        <div class="row">
            <div class="col-md-6 filter-by-block margin-bottom-60">
                <h1 class="share1">Download APP</h1>
                 <div class="panel-group" id="accordion">
                
                </div><!--/end panel group-->

		      <div style="margin-top:6px;" class="row">
	         <div class="col-md-6">
               <a  href="https://itunes.apple.com/ca/app/tweebaa/id1027840811?mt=8" 
			     alt="Tweebaa at Apple Store"><img src="/images/app.png" width="100%"></a></div>
			      <div class="col-md-6">
 <a   href="https://play.google.com/store/apps/details?id=com.Tweebaa.App.CollageApp" 
			     alt="Tweebaa at Google Play"><img src="/images/android2.png" width="100%"></a></div></div>
           
            </div>

            <br /><br />
        </div>
    </div>
</asp:Content>
