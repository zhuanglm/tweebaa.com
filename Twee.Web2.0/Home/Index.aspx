﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TweebaaWebApp2.Home.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <form runat="server" id="sky_form4" >
            <div class="col-md-9">
                <!--Profile Body-->
                <div class="profile-body">
          
                    <!--Service Block v3-->
                    <div class="row margin-bottom-30">
                        <div class="col-sm-4 sm-margin-bottom-20">
                            <div class="service-block-v3 service-block-gold2">
                                <span class="service-heading">Tweebucks Redemption <br />Value</span>
                                <i class="icon-trophy"></i>
                                
                                <span class="counter">$<asp:Label ID="labSumCash2" runat="server"></asp:Label></span>
                                <div class="row">
                                    <div class="col-xs-12 service-in">
                                        <small>You have <asp:Label ID="labSumCash" runat="server"></asp:Label> TweeBucks. </small><br /><br />
                                     (1 TweeBuck = $1.00 USD)   
                                     </div>
                                   
                                </div>
                                        
                            </div>
                        </div>
                        
                        <div class="col-sm-4 sm-margin-bottom-20">
                            <div class="service-block-v3 service-block-gold2">
                            <span class="service-heading"> Shopping Rewards Redemption Value </span>

                                <i class="icon-basket"></i>
                                
                                <span class="counter">$<asp:Label ID="labSumShop2" runat="server"></asp:Label> </span>
                            
                                <div class="row">
                                    <div class="col-xs-12 service-in">
                                        <small>You have <asp:Label ID="labSumShop" runat="server"></asp:Label> points <br />
                                        <asp:Label ID="labSumShopPending" runat="server"></asp:Label> points pending
                                        </small>
                                        <br />(400 points = $5.00)
                                        
                                      
                                    </div>
                                    
                                </div>
                                     
                            </div>
                        </div>
                   
                    </div><!--/end row-->
                      <div class="row margin-bottom-10">
                    <div class="col-md-4 col-sm-6">
                          <!--Striped and Hover Rows-->     
                        <div class="panel margin-bottom-20">
                            <div class="panel-heading-sub">
                                <h3 class="panel-title"><i class="fa fa-pencil-square-o"></i>Suggestion</h3>
                            </div>
                            <table class="table">
                         
                                <tbody>
                                   <tr>
                                       <td >
                                     <div class="row ">
                                    <div class="col-xs-6 service-in">
                                        <small>Suggest Points</small>
                                        <h4 class="counter"><asp:Label ID="labSubPoint" runat="server"></asp:Label> </h4>
                                    </div>
                                    <div class="col-xs-6 text-right service-in">
                                        <small>Commission (%)</small>
                                        <h4 class="counter"><asp:Label ID="labSubRat" runat="server"></asp:Label></h4>
                                    </div>
                                </div>
                                <h3 class="heading-xs">My Suggest Level : <asp:Label ID="labSubLevel" runat="server"></asp:Label></h3>
                                       <div class="progress progress-u progress-xs">
                                       
                    <div style="width: <%=f1 %>%" aria-valuemax="100" aria-valuemin="0" aria-valuenow="85" role="progressbar" class="progress-bar progress-bar-blue"></div>
                    </div>
                                
                                </td></tr></tbody></table>
                        </div> </div>                  
                    <!--End Striped Rows-->
                     <div class="col-md-4 col-sm-6">
                          <!--Striped and Hover Rows-->     
                        <div class="panel margin-bottom-20">
                            <div class="panel-heading-eva">
                                <h3 class="panel-title"><i class="fa fa-check-square-o"></i>Evaluations</h3>
                            </div>
                             <table class="table">
                         
                                <tbody>
                                   <tr>
                                       <td >
                                     <div class="row ">
                                    <div class="col-xs-6 service-in">
                                        <small>Evaluate Points</small>
                                        <h4 class="counter"><asp:Label ID="labEvaluatePoint" runat="server"></asp:Label></h4>
                                    </div>
                                    <div class="col-xs-6 text-right service-in">
                                        <small>Commission (%)</small>
                                        <h4 class="counter"><asp:Label ID="labEvaluateRat" runat="server"></asp:Label></h4>
                                    </div>
                                </div>
                                <h3 class="heading-xs">My Evaluate Level : <asp:Label ID="labEvaluateLevel" runat="server"></asp:Label></h3>
                                       <div class="progress progress-u progress-xs">
                                       <div style="width: <%=f2 %>%" aria-valuemax="100" aria-valuemin="0" aria-valuenow="85" role="progressbar" class="progress-bar progress-bar-u"></div>
                                       </div>
                    
                                
                                </td></tr></tbody></table>
                        </div> </div>                  
                    <!--End Striped Rows-->
                      <div class="col-md-4 col-sm-6">
                          <!--Striped and Hover Rows-->     
                        <div class="panel margin-bottom-20">
                            <div class="panel-heading-sha">
                              <h3 class="panel-title"><em class="fa fa-share-alt"></em> Share</h3>
                            </div>
                          <table class="table">
                         
                                <tbody>
                                   <tr>
                                       <td >
                                     <div class="row ">
                                    <div class="col-xs-6 service-in">
                                        <small>Share Points</small>
                                        <h4 class="counter"><asp:Label ID="labSharePoint" runat="server"></asp:Label> </h4>
                                    </div>
                                    <div class="col-xs-6 text-right service-in">
                                        <small>Commission (%)</small>
                                        <h4 class="counter"><asp:Label ID="labShareRat" runat="server"></asp:Label></h4>
                                    </div>
                                </div>
                                <h3 class="heading-xs">My Share Level : <asp:Label ID="labShareLevel" runat="server"></asp:Label></h3>
                                       <div class="progress progress-u progress-xs">
                                       <div style="width: <%=f3 %>%" aria-valuemax="100" aria-valuemin="0" aria-valuenow="85" role="progressbar" class="progress-bar progress-bar-orange"></div>
                                        </div>
                                
                                </td></tr></tbody></table>
                        </div> </div>                  
                    <!--End Striped Rows-->
                </div>
                <!-- End Service Blcoks Sampe v1 -->
                     <!-- Mixed Icon Styles -->
                      <div class="row margin-bottom-20">
                     <!--Profile Post-->
                        <div class="col-sm-12">
                            <div class="panel panel-profile no-bg">
                                <div class="panel-heading overflow-h">
                                    <h2 class="panel-title heading-sm pull-left"><i class="fa fa-pencil"></i>Task Board</h2>
                                </div>
                                <div id="scrollbar" class="panel-body contentHolder">
                                    <div class="profile-post color-one">
                                        <span class="profile-post-numb">01</span>
                                        <div class="profile-post-in">
                                        <input type="hidden" id="hidQianDaoUserid" value="<%=_qiaoDaoUserid %>" />
                                            <h3 class="heading-xs"><a href="javascript:void(0);" onclick="qiandaoFuc()">Daily Check-In</a></h3>
                                            <p>Bonus +1 in EVERY ZONE! Just click "Check in" to each day!</p>
                                            <a href="javascript:void(0);" class="btn btn-u btn-u-sm btn-u-blue" onclick="qiandaoFuc()">Check in </a>
                                        </div>
                                    </div>
                                    <div class="profile-post color-two">
                                        <span class="profile-post-numb">02</span>
                                        <div class="profile-post-in">
                                            <h3 class="heading-xs"><a href="#">Browse Shop</a></h3>
                                            <p>Bonus Share Zone points - just browse 10 Tweebaa products/day. Must remain on each page AT LEAST 30 seconds for bonus 5 points per day.</p>
                                            <a href="javascript:void(0);" onclick="Redict('../Product/prdSaleAll.aspx')"class="btn btn-u btn-u-sm btn-u-red">Browse Now </a>
                                        </div>
                                    </div>
                                    <div class="profile-post color-three activies">
                                        <span class="profile-post-numb">03</span>
                                        <div class="profile-post-in weekly">
                                            <h3 class="heading-xs"><a href="#">Full Week Check-In</a></h3>
                                            <p>Bonus +10 in EVERY ZONE Check-in all 7 days/week</p>
                                            <!--
                                            <a rel="pop" class="btn btn-u btn-u-sm btn-u-sea disabled">MON</a>
                                            <a rel="pop" class="btn btn-u btn-u-sm btn-u-sea disabled">TUE</a>
                                            <a rel="pop" class="btn btn-u btn-u-sm btn-u-default disabled">WED</a>
                                            <a rel="pop" class="btn btn-u btn-u-sm btn-u-default disabled">THU</a>
                                            <a rel="pop" class="btn btn-u btn-u-sm btn-u-default disabled">FRI</a>
                                            <a rel="pop" class="btn btn-u btn-u-sm btn-u-default disabled">SAT</a>
                                            <a rel="pop" class="btn btn-u btn-u-sm btn-u-default disabled">SUN</a>
                                            -->
                                            <ul>
                                                <li>
                                                    <img src="/Home/Images/sun-g.png" width="51" height="55" id="img1" runat="server"/></li>
                                                <li>
                                                    <img src="/Home/Images/mon-g.png" width="51" height="55"  id="img2" runat="server"/></li>  
                                                <li>
                                                    <img src="/Home/Images/tue-g.png" width="51" height="55"  id="img3" runat="server"/></li>
                                                <li>
                                                    <img src="/Home/Images/wed-g.png" width="51" height="55"  id="img4" runat="server"/></li>
                                                <li>
                                                    <img src="/Home/Images/thu-g.png" width="51" height="55"  id="img5" runat="server"/></li>
                                                <li>
                                                    <img src="/Home/Images/fri-g.png" width="51" height="55"  id="img6" runat="server"/></li>
                                                <li>
                                                    <img src="/Home/Images/sat-g.png" width="51" height="55"  id="img7" runat="server"/></li>
                                            </ul>

                                        </div>
                                    </div>
                                    
                               <!--
                                    <div class="profile-post color-seven">
                                        <span class="profile-post-numb">07</span>
                                        <div class="profile-post-in">
                                            <h3 class="heading-xs"><a href="#">Project Updates</a></h3>
                                            <p>New features of coming update</p>
                                        </div>
                                    </div>
                                    -->
                                </div>
                            </div>        
                        </div> </div>
                        <!--End Profile Post-->

                    <!--End Service Block v3-->
                   

                </div>

                
                                <script type="text/javascript">
                                    function qiandaoFuc() {
                                        var userid = $("#hidQianDaoUserid").val();
                                        if (userid != "") {
                                            var res = TweebaaWebApp2.Home.index.SaveQianDao(userid).value;
                                           // res = 2;
                                            if (res == "error") {
                                                AlertEx("Sign in failed");
                                            }
                                            else if (res == "Haved") {
                                                AlertEx("You already checked-in today. Please come back tomorrow!");
                                            }
                                            else if (res == "1") {
                                                TweebaaWebApp2.Home.index.BindDayImg(userid);
                                                AlertEx("Congratulations, you have continuous attendance for a week, get 10 bonus points");
                                                //location.reload(true);
                                                //Redict(window.location.href);
                                                setTimeout(window.location.reload(true),2000);
                                            }
                                            else if (res == "2") {
                                                TweebaaWebApp2.Home.index.BindDayImg(userid);
                                                AlertEx("Congratulations, You've just received your daily check-in points. We hope to see you again tomorrow.");
                                                //location.reload(true);
                                                //window.location.href = window.location.href;
                                                //Redict(window.location.href);
                                                //window.location.reload(true);
                                                setTimeout(window.location.reload(true), 2000);
                                            }
                                            else {
                                                AlertEx(res);
                                                //window.location.reload(true);
                                            }
                                        }
                                    }

                                    function Redict(url) {
                                        window.parent.location.href = url;
                                    }
                                </script>
             </div>
</form>
</asp:Content>