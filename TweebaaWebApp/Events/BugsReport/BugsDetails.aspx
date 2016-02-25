<%@ Page Language="C#" MasterPageFile="~/MasterPages/EventsMasterPage.Master" AutoEventWireup="true" CodeBehind="BugsDetails.aspx.cs" Inherits="TweebaaWebApp.Events.BugsReport.BugsDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/Css/index.css" />
    <link rel="stylesheet" href="/Css/home.css" />
    <link href="/Css/shareBox.css" rel="stylesheet" type="text/css" />
    <script src="/Js/jquery.min.js" type="text/javascript"></script>
    <script src="/Js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Js/jquery-hcheckbox.js"></script>
    <script src="/Js/selectNav.js" type="text/javascript"></script>
    <script src="/Js/homePage.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/Css/selectCss.css" />

    <link rel="stylesheet" href="/Css/find-bug.css" />
    <script src="/Js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Js/public.js"></script>
     <script src="/MethodJs/BugsReportAdmin.js" type="text/javascript"></script>
    <script src="/MethodJs/share.js" type="text/javascript"></script>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">  

    <form id="form1" runat="server">
    <input type="hidden" name="Admin_userID" id="Admin_userID" value="<%=_userid %>" />
	<div class="w964 bug_post">
     
<div class="bug-report">
       

        <div id="dvBugsDetails">
        
        </div>

        <div >
        <%=_admin_html%>
        </div>
</div>

</div>

<script type="text/javascript">

    $(document).ready(function () {
        //console.log("ready!");

        LoadBugsDetails(<%=bugs_id %>);
    });
   
    function LoadBugsDetails(bug_id) {
    $.ajax({
        type: "POST",
        url: '/Events/BugsReport/BugsHandler.ashx',
        data: "{'action':'bug_details'"
        + ",'txtID':'" + bug_id
         + "'}",
        success: function (resu) {
            //prdSaleInfo = resu;
            if (resu == "") {
                return;
            }
            var obj = eval("(" + resu + ")");
            var html = "";
            for (var i = 0; i < obj.length; i++) {
                var bugs = obj[i];
                html = '<table><tr><td><div class="txtTitle"><h2>' + bugs.BugsTitle + "</h2></div></td></tr>";
                html += '<tr><td align="right" class="qtitle">Bugs Finder:' + bugs.username + "</td></tr>";
                html += '<tr><td align="right" class="qtitle">Browser:' + bugs.BrowserType + "</td></tr>";
                html += '<tr><td align="right" class="qtitle">Post Time:' + bugs.CreateTime + "</td></tr>";
                html += '<tr><td style="padding-top:20px;"><div class="des">:' + bugs.BugsDescription + "</div></td></tr></table>";
            }
            $("#dvBugsDetails").html(html);
            //return resu;
        },
        error: function (obj) {
            prdSaleInfo = "";
        }
    });

}
</script>
</form>
</asp:Content>