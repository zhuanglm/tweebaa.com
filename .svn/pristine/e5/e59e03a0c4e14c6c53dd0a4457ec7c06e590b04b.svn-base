<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home2.aspx.cs" Inherits="TweebaaWebApp.Home.Home2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Css/index.css" />
    <link rel="stylesheet" href="../Css/home.css" />
    <script src="../Js/jquery.min.js" type="text/javascript"></script>
    <script src="../Js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
    <script src="../Js/selectNav.js" type="text/javascript"></script>
    <script src="../Js/homePage.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../css/selectCss.css" />
    <script src="../Js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/public.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="home-main fl">
        <div class="collection-main">
            <h2 class="t" style="border-bottom:none;">
               Daily Activities</h2>
            <div class="activies fl">
                <div class="daily fl">
                    <h2>
                        Daily Check-In</h2>
                    <h3>
                        Bonus +1 in EVERY ZONE! Just click Earnie each day!</h3>
                    <span class="baab">                   
                        <ul>
                            <li><a class="btn" onclick="qiandaoFuc()" style="text-decoration: none;cursor:pointer ">Click Me</a>
                          
                                <input type="hidden" id="hidQianDaoUserid" value="<%=_qiaoDaoUserid %>" />
                                <script type="text/javascript">
                                    function qiandaoFuc() {
                                        var userid = $("#hidQianDaoUserid").val();
                                        if (userid != "") {
                                            var res = TweebaaWebApp.Home.Home2.SaveQianDao(userid).value;
                                            if (res == "error") {
                                                alert("Sign in failed");
                                            } 
                                            else if (res == "Haved") {
                                                alert("You already checked-in today. Please come back tomorrow!");
                                            }
                                            else if (res == "1") {
                                                alert("Congratulations, you have continuous attendance for a week, get 10 bonus points");
                                                window.location.href = window.location.href;                                   
                                            }
                                            else if (res == "2") {
                                                alert("Congratulations, You've just received your daily check-in points. We hope to see you again tomorrow.");
                                                window.location.href = window.location.href;
                                            }
                                            else {
                                                alert(res);
                                            }
                                        }
                                    }
                                </script>
                            </li>
                        </ul>
                    </span>
                </div>
                <div class="weekly fl">
                    <h2>
                        Full Week Check-In
                    </h2>
                    <h3>
                        Bonus +10 in EVERY ZONE Check-in all 7 days/week</h3>
                    <ul>
                        <li>
                            <img src="Images/sun-g.png" width="51" height="55" id="img1" runat="server"/></li>
                        <li>
                            <img src="Images/mon-g.png" width="51" height="55"  id="img2" runat="server"/></li>  
                        <li>
                            <img src="Images/tue-g.png" width="51" height="55"  id="img3" runat="server"/></li>
                        <li>
                            <img src="Images/wed-g.png" width="51" height="55"  id="img4" runat="server"/></li>
                        <li>
                            <img src="Images/thu-g.png" width="51" height="55"  id="img5" runat="server"/></li>
                        <li>
                            <img src="Images/fri-g.png" width="51" height="55"  id="img6" runat="server"/></li>
                        <li>
                            <img src="Images/sat-g.png" width="51" height="55"  id="img7" runat="server"/></li>
                    </ul>
                    <!--<ul ><li><img src="Images/sun-g.png" width="51" height="55" /></li><li><img src="Images/mon-g.png" width="51" height="55" /></li>
<li><img src="Images/tue-g.png" width="51" height="55" /><li><img src="Images/wed-g.png" width="51" height="55" /><li><img src="Images/thu-g.png" width="51" height="55" /><li><img src="Images/fri-g.png" width="51" height="55" /><li><img src="Images/sat-g.png" width="51" height="55" /></li>
</ul> -->
                    <span class="line"></span>
                    <h2>
                        Browse Shop</h2>
                  <%--  <h3>
                        Earn Shopping Rewards - Just browse <strong>10</strong> items/day                      
                    </h3>--%>
                    <p style="width:100%;"> Bonus Share Zone points - just browse 10 Tweebaa products/day.
                       Must remain on each page AT LEAST 30 seconds for bonus 5 points per day.</p>
                    <a class="btn" href="javascript:void(0);" onclick="Redict('../Product/prdSaleAll.aspx')">
                        Browse Now</a>
                </div>
            </div>
        </div>
        <div class="home-index ">
            <div class="item">
                <h3 style=" width:150px;">
                    <strong>My Submissions</strong>
                </h3>
                <div class="item1">
                    <p class="p1 tc fl">
                        I am at<br />
                        Submit Level<br />
                        <b>
                            <asp:Label ID="labSubLevel" runat="server"></asp:Label></b><br />
                        <strong>
                            <asp:Label ID="labSubPoint" runat="server"></asp:Label>
                            Points</strong>
                    </p>
                    <p class="p2 tc fl">
                        <a href="#">Submissions
                            <br />
                            today
                            <br />
                            eligible to earn<br />
                            <b>
                                <asp:Label ID="labSubRat" runat="server"></asp:Label></b> </a>
                    </p>
                    <br />
                    <br />
                    <br />
                    <p style="text-align:center;">
                        <a class="btn" href="homeSupply.aspx">See my Submissions</a> <br /> 
                        <a class="btn2"  target="_parent" href="../Product/issue.aspx">Submit Now</a>
                    </p>
                   
                    <%-- 
                     <a class="btn2">Task: Submit 10 Products today</a><br />
                    <p class="p3 tr"><a href="#">How to submit？</a> 
                    </p>
                    --%>
                </div>
            </div>
            <div class="item">
                <h3 style="background-color: #18cbac;width:150px;">
                    <strong>My Evaluations</strong>
                </h3>
                <div class="item2">
                    <p class="p1 tc fl">
                        I am at Evaluate Level<br />
                        <b>
                            <asp:Label ID="labEvaluateLevel" runat="server"></asp:Label></b><br />
                        <strong>
                            <asp:Label ID="labEvaluatePoint" runat="server"></asp:Label>
                            Points</strong></p>
                    <p class="p2 tc fl">
                        <a href="#">Evaluations today
                            <br />
                            eligible to earn<br />
                            <b>
                                <asp:Label ID="labEvaluateRat" runat="server"></asp:Label></b> </a>
                    </p>
                    <br />
                    <br />
                    <br />
                    <p style=" text-align:center;">
                        <a class="btn" href="HomeReview.aspx">See my Evaluations</a> <br />
                        <a class="btn2" target="_parent" href="../Product/prdReviewAll.aspx">Evaluate Now</a>
                    </p>
                    <%--<a class="btn2">Task: Submit 10 Products today</a>--%>
                    <%--<p class="p3 tr">
                      <a href="#">How to Evaluate？</a> 
                    </p>--%>
                </div>
            </div>
            <div class="item" style="padding-right: 0px">
                <h3 style="background-color: #f38118;">
                    <strong>My Share</strong>
                </h3>
                <div class="item3">
                    <p class="p1 tc fl">
                        I am at Share Level<br />
                        <b>
                            <asp:Label ID="labShareLevel" runat="server"></asp:Label></b><br />
                        <strong>
                            <asp:Label ID="labSharePoint" runat="server"></asp:Label>
                            Points</strong></p>
                    <p class="p2 tc fl">
                        <a href="#">Share & Earn today
                            <br />
                            eligible to earn<br />
                            <b>
                                <asp:Label ID="labShareRat" runat="server"></asp:Label></b> </a>
                    </p>
                    <br />
                    <br />
                    <br />
                     <p style="text-align:center;">
                        <a class="btn" href="HomeShare.aspx">See my Shares</a>  <br /> 
                        <a class="btn2" target="_parent" href="../Product/prdSingleShare.aspx">Share Now</a>
                    </p>
                   
                   <%-- <a class="btn" href="HomeShare.aspx">See my Shares</a>
                    <a class="btn" href="../Product/prdSingleShare.aspx">Share Now</a>--%>
                    <%--<a class="btn2">Task: Submit 10 Products today</a>
                    <p class="p3 tr">
                        <a href="#">How to Share？</a>
                    </p>--%>
                </div>
            </div>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        function GetMenu(pageUrl) {
            //$("#iframepage").attr("src", pageUrl);
            window.location.href = pageUrl;
        }
        function Redict(url) {
            window.parent.location.href = url;
        }
    
    </script>
</body>
</html>
