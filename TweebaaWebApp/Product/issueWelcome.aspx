<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="issueWelcome.aspx.cs" Inherits="TweebaaWebApp.Product.issueWelcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Submit a Product - earn commissions, cash rewards and points
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
 
	<link rel="stylesheet" href="../css/scroll.css" />
	<script src="../js/jquery.min.js" type="text/javascript"></script>
	<script src="../js/jquery.placeholder.js" type="text/javascript"></script>
	<script src="../js/reg.js" type="text/javascript"></script>
	<script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
	<script type="text/javascript" src="../js/jquery.xScroller.js"></script>
	<script type="text/javascript" src="../js/dragbox.js"></script>
	<link rel="stylesheet" href="../css/selectCss.css" />
	<script src="../js/selectCss.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

<div class="list-banner submit">
   <ul><li><img src="../images/submit-banner.jpg" width="295" height="129" /></li>
     <li class="p1">Tell us about great products…</li><li class="p2">Earn cash on every sale when you submit to Tweebaa!</li></ul>
		</div>

<form runat="server">
<div class="ihalfc">
<ul><li class="cr"><img src="../images/Layer_247-1.png" width="49" height="50" ></li>
<li class="c1 s">SUBMIT
</li>
<li class="c2">We are relying on Submitters (like YOU) to tell us about emerging items, useful gadgets and must-have consumer products.  <br>If your product advances to the Tweebaa Shop, you will earn a commission on all sales of the product for life!!</li>
</ul>
</div>
<div class="lanmain clearfix">
<div class="lanleft">
<ul><li class="pb1">Earn commissions, cash rewards and points.</li>
<li> <a href="../College/SubmitZone.aspx" class="btng">Learn more about submitting &gt;</a></li>
<li> <a href="/College/SubmitZone.aspx?page=submit-zone" class="btng">Tips for a great submission &gt;</a></li>
<li> <a href="../College/EarnWithTweebaa.aspx" class="every"></a></li>
</ul>
</div>
<div class="lanright">
<ul><li class="btm-s"><a id="A1" href="javascript:void(0)" runat="server" onserverclick="checkLogin_click" class="bta">Submit a Product</a></li></ul>
<li class="blueman"></li>
<li class="bluetxtb">The Submitter</li>
<li class="stxt">
Trend-setting &amp; resourceful.  <br>
Submitters see a need, <br>then find a solution</li>
</div>
</div>.


</form>

    </a>

</asp:Content>
