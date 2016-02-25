<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="CollegeDetail.aspx.cs" Inherits="TweebaaWebApp.College.CollegeDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link href="../Css/home.css" rel="stylesheet" />
    <link href="../Css/selectCss.css" rel="stylesheet" />
    <%-- <link href="../Css/college.css" rel="stylesheet" />--%>
    <link href="../Css/college-new.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery.placeholder.js"></script>
    <script src="../js/jquery-hcheckbox.js"></script>
    <script src="../js/selectNav.js"></script>
    <script src="../js/homePage.js"></script>
    <script src="../js/selectCss.js"></script>
    <script src="../js/public.js"></script>
    <script src="../js/home-safe.js"></script>
    <script src="../js/custom.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <div style="background-color:#F8F8F8;">
        <div class="w975 mbx">
            <a href="../index.aspx">Homepage</a> > <a href="College.aspx">Education</a> > <b
                class="l"><label id="labTitle"></label></b>
        </div>
        <iframe id="win" name="win" width="100%" onload="SetWinHeight(this)" frameborder="0"
            scrolling="no" src="Why-tweebaa.html"></iframe>
        <div class="ebtn clearfix">
            <ul>
                <li><a href="College.aspx" class="bli">Back to Education home page</a></li>
            </ul>
        </div>
    </div>
    
    
    <script type="text/javascript">


        $(document).ready(
            function () {
                var Request = new Object();
                Request = GetRequest();
                var page = Request["page"];
                if (page == "Why-tweebaa") {
                    $("#win").attr("src", "Why-tweebaa.html");
                    $("#labTitle").text("Why Tweebaa?");
                }
                else if (page == "Zone-reward-points") {
                    $("#win").attr("src", "Zone-reward-points.html");
                    $("#labTitle").text("Zone Reward Points");
                }
                else if (page == "Tweebaa-member") {
                    $("#win").attr("src", "Tweebaa-member.html");
                    $("#labTitle").text("Tweebaa Member");
                }
                else if (page == "earn-with-tweebaa") {
                    $("#win").attr("src", "earn-with-tweebaa.html");
                    $("#labTitle").text("Earn With Tweebaa");
                }
                else if (page == "commission-rewards") {
                    $("#win").attr("src", "cash-rewards.html");
                    $("#labTitle").text("Commission Rewards");
                }

                else if (page == "evaluate-zone") {
                    $("#win").attr("src", "evaluate-zone.html");
                    $("#labTitle").text("Evaluate Zone");
                }
                else if (page == "submit-zone") {
                    $("#win").attr("src", "submit-zone.html");
                    $("#labTitle").text("Submit Zone");
                }
            }
        );

        //iframe自适应高度
        function SetWinHeight(obj) {
            var win = obj;
            if (document.getElementById) {
                if (win && !window.opera) {
                    if (win.contentDocument && win.contentDocument.body.offsetHeight)
                        win.height = win.contentDocument.body.offsetHeight + 50;
                    else if (win.Document && win.Document.body.scrollHeight)
                        win.height = win.Document.body.scrollHeight + 50;
                }
            }
        }

        //接收URL参数
        function GetRequest() {
            var url = location.search; //获取url中"?"符后的字串
            var theRequest = new Object();
            if (url.indexOf("?") != -1) {
                var str = url.substr(1);
                strs = str.split("&");
                for (var i = 0; i < strs.length; i++) {
                    theRequest[strs[i].split("=")[0]] = (strs[i].split("=")[1]);
                }
            }
            return theRequest;
        }
    </script>
</asp:Content>
