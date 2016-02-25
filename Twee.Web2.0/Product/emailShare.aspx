<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="emailShare.aspx.cs" Inherits="TweebaaWebApp2.Product.emailShare" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Tweebaa Email Share</title>
    <link rel="stylesheet" href="/css/index.css" />
    <script src="/js/jquery.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery-hcheckbox.js"></script>
    <link rel="stylesheet" href="/css/selectCss.css" />
    <script src="/js/jquery.placeholder2.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/public.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            // do not submit form when user presses enter key in the input field
            $('input').keypress(function (event) { return event.keyCode != 13; });
        });
        /*
        function Add(obj) {
             var len = $(".email").length;
             if (len > 20)
             return false;
             var htmlStr = '<div></br><input type=text class=email style="width:250px;"/><a href="javascript:void(0)" onclick="Reduce(this);">&nbsp;Remove</a></div>';
             $(htmlStr).insertAfter($(obj));
         }
        function Reduce(obj) {
             $(obj).parent().remove();
        }
        */
        function checkEmail() {
            var re = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
            var badEmailAddr = "";
            var emailAddrInput = $("#emailAddr").val().trimRight();

            // email addresses are separated by spaces and semicolon
            var emailAddr = emailAddrInput.replace(/ +/g, ';');  // replace one or more spaces to a single senicolon
            var emailAddrArr = emailAddr.split(";");
            for (var i = 0; i < emailAddrArr.length; i++) {
                //alert(emailAddrArr[i]);
                if (!re.test(emailAddrArr[i])) {
                    if (badEmailAddr != "") badEmailAddr = badEmailAddr + "\n";
                    badEmailAddr = badEmailAddr + emailAddrArr[i];
                } 
            }
            
            if (badEmailAddr != "") {
                alert("Email address not correct:\n\n" + badEmailAddr + "\n\nPlease enter valid email address.");
                $('#emailAddr').focus();
            }
            else if (emailAddr == "") {
                alert("Please input email address.");
                $('#emailAddr').focus();
            } 
            else {
                $("#hidEmail").val(emailAddr);
                $("#<%=Button1.ClientID%>").click();
            }
        }
    </script>

    <style type="text/css">
        .ReadMsgBody {width: 100%; background-color: #ffffff;}
        .ExternalClass {width: 100%; background-color: #ffffff;}
        body     {width: 100%; background-color: #ffffff; margin:0; padding:0; -webkit-font-smoothing: antialiased;font-family: Arial, Helvetica, sans-serif}
        table {border-collapse: collapse;}
        
        @media only screen and (max-width: 640px)  {
                        body[yahoo] .deviceWidth {width:440px!important; padding:0;}    
                        body[yahoo] .center {text-align: center!important;}  
                }
                
        @media only screen and (max-width: 479px) {
                        body[yahoo] .deviceWidth {width:420px!important; padding:0;}    
                        body[yahoo] .center {text-align: center!important;}  
                }
	label {
    color: #999;
}
label {
    display: inline-block;
    max-width: 100%;
    margin-bottom: 5px;
    font-weight: 700;
}		
.form-control {
    box-shadow: none;
}
.form-control {
    display: block;
    width: 100%;
    height: 24px;
    padding: 6px 12px;
    font-size: 14px;
    line-height: 1.42857143;
    color: #555;
    background-color: #fff;
    background-image: none;
    border: 1px solid #ccc;
    border-radius: 4px;
    -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
    box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
    -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
    -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
    transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
}
input, button, select, textarea {
    font-family: inherit;
    font-size: inherit;
    line-height: inherit;
}
input {
    line-height: normal;
}

.form-group {
    margin-bottom: 15px;
}

.textarea {
    position: relative;
    display: block;
 border-color: #bbb;
     border-width: 1px;
    font-size: 14px;
    color: #404040;
	width:100%
	
	}
	
.btn-s {
    border: 0;
    color: #fff;
    font-size: 18px;
    cursor: pointer;
    font-weight: 400;
    padding: 6px 13px;
    position: relative;
    background: #e67e22;
    white-space: nowrap;
    display: inline-block;
    text-decoration: none;
	border-radius:5px;
	float:right;
	
}
    </style>

</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" yahoo="fix" style="font-family: Arial, Helvetica, sans-serif">
   <!-- Wrapper -->
    <table width="100%" border="0" cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td width="100%" valign="top" bgcolor="#ffffff" style="padding-top:10px">
                
            <!--Start Header-->
            <table width="700" bgcolor="#fff" border="0" cellpadding="0" cellspacing="0" align="center" class="deviceWidth">
                <tr>
                    <td style="padding: 6px 0px 0px">
                        <table width="680" border="0" cellpadding="0" cellspacing="0" align="center" class="deviceWidth">
                            <tr>
                                <td width="100%" >
                                    <!--Start logo-->
                                    <table  border="0" cellpadding="0" cellspacing="0" align="left" class="deviceWidth">
                                        <tr>
                                            <td class="center" style="padding: 10px 0px 0px 0px">
                                                <a href="#"><img src="/images/logo.png" width="300"></a>
                                            </td>
                                        </tr>
                                    </table><!--End logo-->
                                  <!--Start nav-->
                                 <table  border="0" cellpadding="0" cellspacing="0" align="right" class="deviceWidth">
                                    
                                    </table> 
                                </td>
                            </tr>
                        </table>
                   </td>
                </tr>
            </table> 
            
            <!--End Header-->

            <div id="divMailTable" style="<%=strHideMailDiv %>">
                <!--Start Left Picture-->
                <table width="700" border="0" cellpadding="0" cellspacing="0" align="center" class="deviceWidth">
                    <tr>
                        <td width="100%" >
                            <!-- Left box  -->
                            <table width="45%" align="left"  border="0" cellpadding="1" cellspacing="1" class="deviceWidth" >
                                <tr>
                                    <td valign="top" style="padding: 20px 20px;">
                                    <!--
                                        <a href="#"><img class="deviceWidth"  width="260" hight="260" src="img/block_img/sample.jpg"  style="border:1px #e6e6e6 solid;"></a>
                                    -->
                                     <asp:Image ID="Image1" class="deviceWidth" style="border:1px #e6e6e6 solid;" runat="server" Width="260" Height="260" />
                                    </td>
                                </tr>
                            </table> <!--End left box-->
                            <!--Right box-->
                            <table width="55%" align="left" border="0" cellpadding="0" cellspacing="0"  class="deviceWidth" >
                                <tr>
                                            <td  class="center" style="font-size: 18px; color: #272727; font-weight: light; text-align: center; font-family: Arial, Helvetica, sans-serif; line-height: 25px; vertical-align: middle; padding: 0px 0px 0px 10px;">
                                                <p style=" text-align:left; color:#faa54e; font-weight:bold">Share with your friends by email </p>
                                             
                                                                       
                                           </td>
                                        </tr>
                                <tr>
                                    <td  style="font-size: 16px; color: #303030; font-weight: bold; text-align:left; font-family: Arial, Helvetica, sans-serif; line-height: 25px; vertical-align: middle; padding:5px 10px 0px; ">
                                         <asp:Label ID="labPrdID" runat="server" Text=""   Visible="false"></asp:Label>
                        <asp:Label ID="labShareLink" runat="server" Text=""   Visible="false"></asp:Label> 
                        <asp:Label ID="labPrdName" runat="server" Text=""></asp:Label>                        
                                   </td>
                                </tr>
                                <tr>
                                    <td   style="font-size: 12px; color: #999; text-align:left; font-family: Arial, Helvetica, sans-serif; line-height: 20px; vertical-align: middle; padding: 0 20px 10px 10px; ">
                                    <p style="text-decoration: none; color: #999;"> 
                                    <asp:Label ID="labPrdDesc" runat="server" Text=""></asp:Label>
                                    </p>
   
                                   </td>
                                   
                             
                                </tr>
                 
                            <tr>
                                    <td   style="font-size: 14px; color: #999; text-align:left; font-family: Arial, Helvetica, sans-serif; line-height: 20px; vertical-align: middle; padding: 0 20px 10px 10px; font-weight:bold;">
                               <!--  <p>Designer: Neal</p> -->
   
                                   </td>
                                   
                             
                                </tr>               
                            </table><!--End right box-->
                        </td>
                    </tr>
                    
                </table>
                <!--End Left Picture-->
                
                <!--Start Midlle Picture -->
                <table width="700" border="0" cellpadding="0" cellspacing="0" align="center" class="deviceWidth">
                    <tr>
                        <td class="center">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" align="left" class="deviceWidth" bgcolor="#fff"> 
                             
                                <tr>
                                    <td  class="center" style="font-size: 14px; color: #999; font-weight: bold; text-align: left; font-family: Arial, Helvetica, sans-serif; line-height: 25px; vertical-align: middle; padding: 0px 20px 20px; " >
                                         <div class="panel-body">                                                      
                     
                        <form class="margin-bottom-40" role="form" runat="server">
                        
                            <div class="form-group">
                                <label for="exampleInputEmail1">Please Enter your name ( as you want your friends to see it)</label>
                                <!--
                                <input type="email" class="form-control"  placeholder="Enter Your Name" style="width:30%">
                                -->

                                <input type="text" class="email form-control" laceholder="Enter Your Name" style="width:96.6%" id="txtSender" name="txtSender" runat="server" />

                            </div>
                               <div class="form-group">
                                <label>Please enter a personal message here</label>
                             <label class="textarea" >
                             <!--
                                <textarea rows="7" style="border:#ccc 1px solid; width:100%"></textarea>
                                -->
                                 <textarea id="txtMessage" cols="7" style="border:#ccc 1px solid; width:100%" runat="server"></textarea>
                            </label>
                            </div>
                            <div class="form-group">
                                <label>Please enter your friends' email addresses <br> (if more than one, seperate by semicolon (;) or spaces. )</label>
                                <!--
                                <input type="password" class="form-control" placeholder="Email Address" style="width:97%">
                                -->
                                <input type="hidden" id="hidEmail" runat="server" />
                                <input type="text" class="form-control email" style="width:96.6%" id="emailAddr"/>
                            </div>
                       <!--
                            <button type="submit" class="btn-s">Submit</button>
                            -->
                            <div style="display: none;">
                            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /></div>
                            <input type="button" class="submit-btn send btn-s" value="Send Email" onclick="checkEmail();return false;" />
                           
                        </form> 
                    </div>.
                                      


    
                                   </td>
                                </tr>
                        
                            </table>
                        </td>  
                        </tr>     
                </table>
                <!--End Midlle Picture -->
        
            </div>  
            <div id="divShowMessage">
            <script type="text/javascript">
             <%=strCloseWinDiv%>
            </script>
           
            </div>
                <!-- Footer -->
                <table width="700"  border="0" cellpadding="0" cellspacing="0" align="center" class="deviceWidth">
                 
                      <tr>
                        <td class="center" style="font-size: 12px; color: #687074; font-weight: bold; text-align: center; font-family: Arial, Helvetica, sans-serif; line-height: 25px; vertical-align: middle; padding: 20px 50px 0px 50px; ">
                            Copyright © Tweebaa 2015 - 2016                          
                        </td>
                    </tr>
                </table>
                <!--End Footer-->

                <div style="height:15px">&nbsp;</div><!-- divider-->


            </td>
        </tr>
    </table> 
    <!-- End Wrapper -->
</body>
<script type="text/javascript">
    $(function () {
        //表单提示
        $("input").placeholder();
        //表单美化
        $('.chklist').hcheckbox();
        //关闭登录框
        $(".closeBtn").click(function () {
            $(this).parents(".greybox").hide()
        })
        //弹出登录框
        $("#minilogin").click(function (event) {
            $(".greybox").show();
            return false;
        });

    });
</script>
</html>
