<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="shoppCartEmpty.aspx.cs" Inherits="TweebaaWebApp.Product.shoppCartEmpty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="../Css/index.css" />
	<script src="../Js/jquery.min.js" type="text/javascript"></script>
	<script src="http://www.web63.cn/jss/apic.js" type="text/javascript"></script>
	<script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
	<link rel="stylesheet" href="../Css/selectCss.css" />
	<script src="../Js/jquery.placeholder2.js" type="text/javascript"></script>
	<script type="text/javascript" src="../Js/public.js"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

<div class="empty-main">
	<div class="w">
		<form action="">
		<div class="empty-main-box fl">	
			
          <div class=" fl"><img src="../Images/tw-cry.png" alt="" /></div>
			<div class=" fl right"><h2>Your Shopping cart is empty</h2>

     
			<div class="box">
			
				
					<div class="submit-box">                  
                    <input type="button" class="submit-btn send" value="Go to Shop" onclick="Redict()" />                 
						
					</div>
					
			</div></div>

		</div>


		</form>


	
	</div>

    
    <script type="text/javascript">
        $(".login-main").apic();
        function Redict() {
            window.location.href = "prdSaleAll.aspx";
        }
    </script>
</div>



</asp:Content>
