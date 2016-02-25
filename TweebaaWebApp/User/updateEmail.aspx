<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="updateEmail.aspx.cs" Inherits="TweebaaWebApp.User.updateEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

	<div class="w964">
  <div class="orderp-main">
        <div id="success" runat="server" style="text-align:center;">
        <!--
            <p>Change email successfully,The page will jump to the login page after <span id="mes">5</span> seconds！</p>
        -->

		<div class="orderp-main-box fl">	
			
          <div class=" fl"><img src="/images/mascot_account.png" alt="" /></div>
			<div class="fl right"><h2>Your account email has been changed.</h2>
            <h3>Will jump to login in page in <span id="mes">5</span> seconds</h3>

     
			<div class="box">
			
				
						<input type="button" class="login-btn" value="Login in " />
						
					
					
			</div></div>

		</div>

        </div>
        <div id="fail" style="display:none;" runat="server">
            <p>I'm so sorry, modify email address failed!</p>
        </div>

    </div>
    <%=_script %>
    </div>
</asp:Content>
