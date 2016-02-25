<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayUnBind.aspx.cs" Inherits="TweebaaWebApp.Home.PayUnBind" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../css/index.css" />
	<link rel="stylesheet" href="../css/home.css" />
    <link rel="stylesheet" href="../css/c.css" />
	<script src="../js/jquery.min.js" type="text/javascript"></script>
	<script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    
     <script src="../js/address.js" type="text/javascript"></script>
    
    
	<script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
	<script src="../js/selectNav.js" type="text/javascript"></script>
	<script src="../js/homePage.js" type="text/javascript"></script>
	<link rel="stylesheet" href="../css/selectCss.css" />
	<script src="../js/selectCss.js" type="text/javascript"></script>
	<script type="text/javascript" src="../js/public.js"></script>
	<script type="text/javascript" src="../js/home-safe.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div class="binding-main"><!--safe-main-->

               <!--成功-->
                <div class="Unbind">
                <h2 class="t">收益账户绑定</h2>
                
                  <br>

                   <form action="">
                	<table cellspacing="0" cellpadding="0" border="0" widht="100%">
                    
                    <tbody><tr>
			<td width="110">
				已绑定支付宝
			</td>
			<td width="160">
			   <img  src="../Images/b_03.png" />
			</td>
            <td width="110">
               <%=account%>
            </td>
		</tr>

		<tr>
			<td colspan="3">
            <asp:Button ID="Button1" runat="server" Text="解除绑定" CssClass="send unbind" 
                    OnClientClick="javascript:unbind()" onclick="Button1_Click" />
            <script type="text/javascript">
                function unbind() {
                    if (confirm('确实要解除绑定吗？')) {
                        return true;
                    } else {
                    return false;
                    }
                }
            </script>
			    </td>
			</tr>

	</tbody></table>
                
                </form>

              </div>
               
			</div>
    </form>
</body>
</html>
