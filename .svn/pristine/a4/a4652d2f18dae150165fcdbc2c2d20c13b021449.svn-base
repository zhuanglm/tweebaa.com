<%@ Page Language="C#" MasterPageFile="~/MasterPages/EventsMasterPage.Master"  AutoEventWireup="true" CodeBehind="BugsPost.aspx.cs" Inherits="TweebaaWebApp.Events.BugsReport.BugsReportPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/css/index.css" />
    <link rel="stylesheet" href="/css/home.css" />
    <link href="/css/shareBox.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/jquery-hcheckbox.js"></script>
    <script src="/js/selectNav.js" type="text/javascript"></script>
    <script src="/js/homePage.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/css/selectCss.css" />

     <link rel="stylesheet" href="/css/find-bug.css" />

    <script src="/js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/public.js"></script>
    <script src="/MethodJs/BugsReport.js" type="text/javascript"></script>
    <script src="/MethodJs/share.js" type="text/javascript"></script>

       <%--分页--%>    
    <script src="/js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="/js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="/Kindeditor/kindeditor-4.1.10/themes/default/default.css" />
    <link href="/Kindeditor/kindeditor-4.1.10/plugins/code/prettify.css" rel="stylesheet"
        type="text/css" />
    <script charset="utf-8" src="/Kindeditor/kindeditor-4.1.10/kindeditor.js"></script>
    <script charset="utf-8" src="/Kindeditor/kindeditor-4.1.10/lang/zh_CN.js"></script>
    <script charset="utf-8" src="/Kindeditor/kindeditor-4.1.10/plugins/code/prettify.js"></script>

    <style>
        .close_Btn_TC{
              display: inline-block;
          width: 32px;
          height: 32px;
          background: url(/images/x2.png) no-repeat;
          position: absolute;
          z-index: 1001;
          right: 10px;
          top: 10px;
  }
    </style>
    <script type="text/javascript">
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('#' + document.getElementById('WebContent_txtDec').id, {
                langType: 'en',
                cssPath: '/Kindeditor/kindeditor-4.1.10/plugins/code/prettify.css',
                uploadJson: '/Kindeditor/kindeditor-4.1.10/asp.net/upload_json.ashx',
                fileManagerJson: '/Kindeditor/kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                allowFileManager: false,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                }
            });
            prettyPrint();

        });

        function OpenT_C() {
            $("#T_C_Div").parent(".greybox").show();
            $("#T_C_Divlo").animate({ top: "2%" }, 300);
        }
        function close_tc() {
            $("#T_C_Div").parent(".greybox").hide();
        }
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">  


<div class="greybox">
	<div id="T_C_Div" class="popbox">
   
<div class="tcksnow">
 <a href="#" class="close_Btn_TC" onclick="close_tc()" title="Close"></a>

<div style="padding:30px">
    Before we officially launch our Tweebaa website to the public, and as we continue to work out a few bugs, we’d like to invite you to join Tweebaa and take advantage of Double-Rewards Points and Bonus points for finding and reporting “bugs” and suggesting site improvements, through June 28. All you have to do is register, then explore the website! If you find a “bug” – could be a link that doesn’t work, instructions that are unclear, even a misspelled word – just click on the “bug” (it appears on the right-hand side of every page) to let us know. You’ll receive one BONUS point (in each zone) for every valid bug that you report!
 <br /><br />
<p><strong>TERMS & CONDITIONS OF THIS OFFER:</strong></p>
<ul>
<li>Double-Rewards Points and Bonus Bug points will be rewarded only through June 28, 2015</li>
<li>To qualify for Double-Rewards points, all you have to do is complete a brief (10 question) survey before July 3, 2015.</li>
<li>Your Double-Rewards points will be added to your account during the week of July 5.</li>
<li>Double-Rewards will be rewarded at the END of this offer</li>
<li>Bonus Bug points are not subject to double-rewards; they will be rewarded after the bug is confirmed by Tweebaa programmers (usually within 24 hours).</li>
</ul>
</div>

</div>


    </div>
</div>
	<div class="w964">
    <input type="hidden" id="UserGuid" value="<%=_userid %>" />
<div class="w964 bug_post">
        <h2>Bug Post Form</h2>
<table >
<tr><td colspan="2" align="right" style="text-align:right">
<a href="#" onclick="OpenT_C()">Bug Report Terms and Condition  &nbsp;</a>
</td></tr>

<tr><td colspan="2" class="top_notice">
    Please read the previous post before you post a bugs, duplicate or similar, whichever was first published 
    <br /><a href="index.aspx" class="read_post"> Read Posts</a>
    
</td></tr>
<tr>
<td colspan="2"  class="qtitle">1. Please Select your browser</td>
</tr>
<tr>
<td colspan="2" class="adash" >
<input type="radio" name="rdbrowser" value="IE"  /> IE 
<input type="radio" name="rdbrowser" value="Chrome" class="input_td"/> Chrome 
<input type="radio" name="rdbrowser" value="FireFox" class="input_td"/> FireFox 
<input type="radio" name="rdbrowser" value="Safari" class="input_td"/> Safari 
<input type="radio" name="rdbrowser" value="Others" class="input_td"/> Others , please input here &nbsp;&nbsp; &nbsp;&nbsp; 
<input type="text" name="txtBrowser" id="txtBrowser" />
</td>
</tr>
<tr><td colspan="2"  class="qtitle">2. Please Select Bugs Type</td></tr>
<tr><td colspan="2" class="adash">
<input type="radio" name="rdbugsType" value="1" /> User Interface Design 
<input type="radio" name="rdbugsType" value="2" class="input_td"/> Function
<input type="radio" name="rdbugsType" value="3" class="input_td"/> Suggestion 
<input type="radio" name="rdbugsType" value="4" class="input_td"/> User Experience 
</td></tr>

<tr>
<td colspan="2"  class="qtitle">3. Please Select Bugs Level</td></tr>
<tr>
<td colspan="2" class="adash"> <select name="level" id="slLevel" style="width:60px; font-size:14px; ">
<option value="1">1</option>
<option value="2">2</option>
<option value="3">3</option>
<option value="4">4</option>
<option value="5">5</option>
<option value="6">6</option>
<option value="7">7</option>
<option value="8">8</option>
<option value="9">9</option>
<option value="10">10</option>
</select> (1-10,10 is heighest) </td></tr>

<tr>
<td colspan="2"  class="qtitle">4. Please input the title</td></tr>
<tr>
<td colspan="2" class="adash"> <input type="text" name="txtTitle" id="txtTitle" class="txt_l" /></td></tr>

<tr>
<td colspan="2"  class="qtitle">5. Please describe the bug in detail ( you can attach an image, just click the <img src="/Images/image1_01.png" border="0" /> &nbsp; Or <img src="/Images/image1_02.gif" border="0" /> button )</td></tr>
<tr>
<td> 

                            <textarea name="txtDescription" id="WebContent_txtDec" cols="100" rows="8" style="height: 400px; width: 680px;
                                visibility: hidden;"></textarea>
</td></tr>

<tr><td colspan="2" align="center">
<!--
<br /><a href="EventsDetails.aspx" class="read_post"> Read Terms and Conditions&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a>
-->
<br /><br />
<a href="javascript:void(0)" onclick="PostBugs()"  class="btns btn-2" >Submit Bugs &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></td></tr>
<br />
</table>
    </div>    
</div>
<script type="text/javascript">
    function PostBugs() {
        //get broser type
        var txtBrowser = $("input[name='rdbrowser']:checked").val();
        if (txtBrowser == null) {
            alert("Please choose a Browser");
            return;
        }
        if (txtBrowser == "Others") {
            txtBrowser = $("#txtBrowser").val();
        }
        //get bugs type
        var bugsType = $("input[name='rdbugsType']:checked").val();
        if (bugsType == null) {
            alert("please choose a bug type");
            return;
        }
        //slLevel
        var txtLevel = $("#slLevel").val();
        var txtTitle = $("#txtTitle").val();
        if (txtTitle.length < 1) {
            alert("Please input bugs Title");
            return;
        }
        var txtDescription = editor.html();// $("#WebContent_txtDec").val();
        if (txtDescription.length < 1) {
            alert("Plase write down the bugs description");
            return;
        }
        var txtUserGuid = $("#UserGuid").val();

        PostABug(txtBrowser, bugsType, txtLevel, txtTitle, txtDescription, txtUserGuid);
    }

</script>
</asp:Content>
