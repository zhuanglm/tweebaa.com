<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="TweebaaWebApp.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
At Tweebaa Everybody Earns - earn by shopping, submitting, evaluating, sharing
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="Css/index.css" />
    <link rel="stylesheet" href="Css/index3.css" />
    <link rel="stylesheet" href="Css/main.css" />
    <link rel="stylesheet" href="Css/buyall.css" />
    <link rel="stylesheet" href="Css/shareall.css" />
    <script src="Js/jquery.min.js" type="text/javascript"></script>
    <script src="Js/jquery.SuperSlide.2.1.1.js" type="text/javascript"></script>
    <script type="text/javascript" src="Js/public.js"></script>
    <script type="text/javascript" src="Js/global.js"></script>
    <script type="text/javascript" src="Js/tab.js"></script>
    <script src="MethodJs/index.js" type="text/javascript"></script>
    <script src="MethodJs/share.js" type="text/javascript"></script>

<script type="text/javascript" src="/js/jquery.cookie.js" ></script>

    <!--script src="MethodJs/shareToSocialNetwork.js" type="text/javascript"></script-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <% // include google share  %>
    <!--#include file="./include/googleshare.inc" -->

<!-- find bugs popup -->
<div class="popbox" style="display:none">
<div class="tcksnow" id="popupEvent">
<a href="#" class="closeBtn" title="Close"></a>
<div class="thalfc">
<ul><li class="cr"><img src="Images/Layer_247-bug.png" width="49" height="50" alt=""></li>
<li class="c1 sh">Find Bugs!
</li>
<li class="c5">We invite our friends and family to join Tweebaa and take advantage of Double-Rewards Points and Bonus points <br />for finding and reporting “bugs”, through June 28.</li>
<li class="c3">Before we officially launch our Tweebaa website, and as we continue to work out a few bugs, we’d like to invite the public to join Tweebaa and take advantage of Double-Rewards and Bonus points for finding and reporting “bugs” and suggesting site improvements, through June 28.  
 All you have to do is register, then explore the website! If you find a “bug” – could be a link that doesn’t work, instructions that are unclear, even a misspelled word – just click on the “bug” (it appears on the right-hand side of every page) to let us know. You’ll receive one BONUS point (in each zone) for every valid bug that you report!</li>
</ul>
<div class="btnred"><a href="http://tweebaa.com/User/register.aspx" class="btnred_a"> Register Now for Double-Rewards <br /> and bonus Bug points!</a>
</div>
<div class="btnblue"><a href="/User/login.aspx" class="btnred_a"> Already a Tweebaa Member?<br /> Log In for Double-Rewards and bonus Bug points!</a>
</div>
<div class="c6">TERMS & CONDITIONS OF THIS OFFER:</div>
<ul class="ulo">
<li class="c4">Double-Rewards Points and Bonus Bug points will be rewarded only through June 28, 2015</li>
<li class="c4">To qualify for Double-Rewards points, all you have to do is complete a brief (10 question) survey before July 3, 2015.</li> 
<li class="c4">Your Double-Rewards points will be added to your account during the week of July 5.</li>
<li class="c4">Double-Rewards will be rewarded at the END of this offer</li>
<li class="c4">Bonus Bug points are not subject to double-rewards; they will be rewarded after the bug is confirmed by Tweebaa programmers (usually within 24 hours).</li></ul>
Do not show this message again.<input type="checkbox" name="cbCheck" onclick="PopupClose();SavePopupCookie('event_popshow')" />
</div>
<div class="tanmain clearfix">


</div></div></div>
<script type="text/javascript">

    //snow加landingpage
    $(".closeBtn").click(function () {
        $(this).parents(".popbox").hide();
        return false;
    });


    function PopupClose() {
        $("#popupEvent").parents(".popbox").hide();
    }


    if ("<%=txtLogion %>" == "0") {
        var i = $.cookie("event_popshow");
        console.log("i==" + i + ' nan=' + isNaN(i));
        if (i == undefined || i < 1 || isNaN(i)) {
            if (i == undefined || isNaN(i)) i = 0;
            setTimeout("PopupClose()", 50000);
            i++;
            $.cookie("event_popshow", i,{ expires: 365 });
        } else {
            $("#popupEvent").parents(".popbox").hide();
        }
    }
   
</script>

<!--  Find Bugs Popup EOF -->

<div class="c_vedio">
            <div class="w">
                <a href="javascript:;" class="close">
                    <img src="/Images/close22.png" alt="close">
                </a>
                <div id="vv">
                </div>
                <script type="text/javascript" src="Ckplayer/ckplayer.js" charset="utf-8"></script>
                 <%--
                <script type="text/javascript">
                
                var flashvars={
                    f: 'http://movie.ks.js.cn/flv/other/1_0.flv',
		            c:0,
		            b:1
		        };
	var params={bgcolor:'#FFF',allowFullScreen:true,allowScriptAccess:'always',wmode:'transparent'};
	CKobject.embedSWF('./Ckplayer/ckplayer.swf','vv','ckplayer_a1','600','400',flashvars,params);	
    --%>
               <script type="text/javascript">
                   var flashvars = {
                       p: 0,
                       e: 1, bgcolor: '#3D3D3D', i: "/Images/tweebaa_poster.jpg"
                   };

                   var video = ['/Images/video_home.mp4->video/mp4'];
                   var support = ['all'];
                   CKobject.embedHTML5('vv', 'ckplayer_a1', 1024, 576, video, flashvars, support);
                </script>
            </div>
        </div>

    <!-- Link to Google+ -->
    <a href="https://plus.google.com/108557407856184595801" rel="publisher"></a>
    <!-- 代码开始 -->
    <!--a href="https://plus.google.com/108557407856184595801" rel="publisher">Google+</a-->
    <div id="js_banner" class="banner" style="height: 425px;">
        <div class="start_reg">
            <div class="w">
                <a href="javascript:;" class="close">
                    <img src="Images/close22.png" alt="close">
                </a>
                <br>
                <br>
                <p>
                    <br>
                    <strong>Become a Zero Investment Partner </strong>
                </p>
                <p>
                    become a Tweebaa member, and start earning immediately!
                </p>
                <p>
                    It's fun and easy to <span style="color: #0099ff;">Submit</span> , <span style="color: #00e4ac;">
                        Evaluate</span> and <span style="color: #fb9254;">Share</span> cool products.</p>
                <p style="font-size: 20px; font-weight: bold;">
                    Earn cash and rewards with zero investment ! Everybody Earns with Tweebaa…
                </p>
                <br>
                <br>
                <a href="User/register.aspx" class="reg_btn">Join Now</a>
            </div>
        </div>
        <a href="javascript:;" class="v_button" > <img src="images/video-ic1.png" > Intro Video</a>
        
        <ul id="js_banner_img" class="banner_img">
            <li class="bgli05">
                <div class="banner_inner">
                    <div class="child child1" data-z="2">
                        <img src="Images/5-1.png" style="position: relative; left: 10px; top: 135px;" alt="everybody-earn" /></div>
                    <div class="child child2" data-z="3">
                        <img src="Images/5-3.png" style="position: relative; left: 10px; top: 70px;"alt="everybody-earn"  />
                        <a href="javascript:void(0);">
                            <img src="Images/5-2.png"alt="everybody-earn" /></a> <a href="javascript:void(0)" class="button" onclick="DoGetStartedOne()">Get Started</a>
                        <a href="College/College.aspx#nav2" class="more">Learn More</a>
                    </div>
                </div>
            </li>
            <li class="bgli04">
                <div class="banner_inner">
                    <div class="child child1" data-z="2">
                        <img src="Images/4-1.png" style="position: relative; left: 20px; top: 116px;" alt="market-your-product"/></div>
                    <div class="child child2" data-z="3">
                        <a href="javascript:void(0);">
                            <img src="Images/4-3.png" style="position: relative; left: -280px; top: 70px;" alt="market-your-product"/>
                            <a href="#" target="_blank">
                                <img src="Images/4-2.png" alt="market-your-product"/></a> <a href="Product/issueWelcome.aspx" class="button">Get Started</a>
                            <a href="College/SubmitZone.aspx?page=submit-zone" class="more">Learn More</a>
                    </div>
                </div>
            </li>
            <li class="bgli03">
                <div class="banner_inner">
                    <div class="child child1" data-z="2">
                        <img src="Images/3-1.png" style="position: relative; left: -32px; top: 84px;"alt="your-opinion-evaluate" /></div>
                    <div class="child child2" data-z="3">
                        <a href="javascript:void(0);">
                            <img src="Images/3-2.png" style="position: relative; left: -100px;" alt="your-opinion-evaluate"/></a> <a href="Product/prdReviewAll.aspx"
                                class="button">Get Started</a> <a href="College/EvaluateZone.aspx?page=evaluate-zone" class="more">Learn More</a>
                    </div>
                </div>
            </li>
            <li class="bgli02">
                <div class="banner_inner">
                    <div class="child child1" data-z="2">
                        <img src="Images/2-1.png" style="position: relative; left: -76px; top: 70px;"alt="world-is-your-store" />                        
                    </div>
                    <div class="child child2" data-z="3" >
                        <a href="javascript:void(0);">
                            <img src="Images/2-2.png" style="position: relative; left: 200px;" alt="world-is-your-store"/></a> 
                            <a href="Product/prdSaleAll.aspx" class="button">Get Started</a><a href="College/College.aspx#nav-shop" class="more">Learn More</a>
                    </div>
                </div>
            </li>
            <li class="bgli01">
                <div class="banner_inner">
                    <div class="child child1" data-z="2">
                        <img src="Images/1-1.png" style="position: relative; left: 38px; top: 77px;" alt="share-with-your-friend" />
                    </div>
                    <!-- data-z="2"与data-z="3"表示两个图层进退场的顺序有区别 -->
                    <div class="child child2" data-z="3">   
                        <a href="javascript:;" style="position: relative; left: -40px;">
                            <img src="Images/1-2.png" alt="share-with-your-friend" /></a> <a href="Product/prdSingleShare.aspx" class="button">
                                Get Started</a> <a href="College/College.aspx#nav-share" class="more">Learn More</a>
                    </div>
                </div>
            </li>
        </ul>
        <div class="banner_common">
            <!-- <a id="js_banner_pre" href="javascript:;" class="banner_pre"></a> 
                 <a id="js_banner_next" href="javascript:;" class="banner_next"></a>-->
        </div>
    </div>
    <!-- 代码结束 -->
    <h2 class="title" style="font-family: 'gillsans-lightlight';">
        4 ways to earn with Tweebaa. Let us show you how.</h2>
    <div class="col-4 clearfix">
        <div class="one section">
            <div class="hd">
                <a href="Product/issueWelcome.aspx" style="color: White;font-family: 'gillsans-lightlight';">SUBMIT<span>TO EARN</span></a>
            </div>
            <div class="bd">
             Know of a cool product that needs<br />to reach the masses? Tell us about it<br /> and if
                it advances to the Tweebaa<br />shop you may be richly rewarded! <a href="College/SubmitZone.aspx?page=submit-zone" class="more">
                    Learn More</a>
            </div>
        </div>
        <div class="two section">
            <div class="hd">
                <a href="Product/prdReviewAll.aspx" style="color: White;font-family: 'gillsans-lightlight';">EVALUATE <span>TO EARN</span></a>
            </div>
            <div class="bd" style="font-family: 'open_sansregular';">
                You don't need to have a product to<br />earn cash or prizes with Tweebaa.<br />Evaluate our
                community products<br />in the comfort of your home! <a href="College/EvaluateZone.aspx?page=evaluate-zone" class="more">Learn More</a>
            </div>
        </div>
        <div class="three section">
            <div class="hd">
                <a href="Product/prdSaleAll.aspx" style="color: White;font-family: 'gillsans-lightlight';">SHOP <span>TO EARN</span></a>
            </div>
            <div class="bd">
                Shop directly on Tweebaa for the<br />coolest new products and earn<br />reward points that
                can be redeemed<br />for purchase credit! <a href="/College/Why-tweebaa.html" class="more">Learn More</a>
            </div>
        </div>
        <div class="four section">
            <div class="hd">
                <a href="Product/prdSingleShare.aspx" style="color: White;font-family: 'gillsans-lightlight';">SHARE <span>TO EARN</span></a>
            </div>
            <div class="bd">
                Leverage your social network by<br />sharing Tweebaa products with your friends. You'll
                introduce them to cool new products while you earn! <a href="/College/Why-tweebaa.html" class="more">Learn More</a>
            </div>
        </div>
    </div>
     
     <div class="greybox">
        <div id="share-tck2" class="tck">
            <a href="javascript: hiddenShare();" class="closeBtn" title="Close"></a>
            <h2 class="t">
                <span>Share</span>
            </h2>
             <div class="box">
                <div class="sharebox clearfix my-dietu">
                    <span class="fl t ">Share to </span>
                    <div class="bdsharebuttonbox fl">
                        <% // include all share method  %>        
                        <!--#include file="./include/sharemethod.inc" -->
                    </div>                  
                    <a href="#" style="display:none;" class="share-media-set">Share Binding setting</a>
                </div>
                <div class="ps clearfix">
                    <span class="fr"><a href="#"></a></span><span class="fl">You will earn a commission if anyone makes a purchase from your shared link!</span>
                </div>
            </div>         
        </div>
    </div>   


    <div class="w content">
        <h2 class="title" style="font-family: 'gillsans-lightlight';">
            Check out today's featured Tweebaa products!</h2>
        <div class="w pro-show">
            <a href="javascript:;" class="arrBtn leftBtn prev"></a><a href="javascript:;" class="arrBtn rightBtn next">
            </a>
            <div id="mainsrp-itemlist">
                <div class="m-itemlist">
                    <div class="itemsScreen">
                        <div class="items clearfix">
                            <ul id="ulData">
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            /*jQuery(".picScroll-left").slide({titCell:".hd ul",mainCell:".bd ul",autoPage:false,effect:"left",autoPlay:false,vis:4});*/
            $(".pro-show").slide({ mainCell: "ul", autoPlay: true, effect: "left", vis: 4, scroll: 4, autoPage: true, pnLoop: true });
        </script>
    </div>
    <!-- 浮动在线咨询 -->
    <!-- 浮动在线咨询 -->
    <script>
        $(document).ready(function () {
            $('#fixed .er-b').hover(function () {
                $(this).find('.er').toggle()

            }, function () {
                $(this).find('.er').toggle()

            })

            $('.col-3 .pic').each(function (index, element) {
                $(this).hover(function () {
                    $(this).find('.mask').animate({ 'bottom': '0px' }, 400, '')
                }, function () {
                    $(this).find('.mask').animate({ 'bottom': '-195px' }, 400, '')
                })
            });

            $('.gotop').click(function () {
                $(document).scrollTop(0);
            })

            $('a.close').click(function () {
                $(this).parent().parent().hide()
                CKobject.getObjectById('ckplayer_a1').videoPause();
            })

            $('.bgli04 .button').click(function () {
                $('.start_reg').show();
            })


            $('.banner a.v_button').click(function () {
                $('.c_vedio').show();

            })

            //显示 收藏和分享

            $("#mainsrp-itemlist .box").live('mouseenter', function (event) {
                $(this).addClass('hover')
                $(this).find(".floatDiv").stop().animate({ top: 0 }, 100)
            }).live('mouseleave', function (event) {
                $(this).removeClass('hover')
                $(this).find(".floatDiv").stop().animate({ top: "-110px" }, 100)
            });

            $(".closeBtn").click(function () {
                $(this).parents(".greybox").hide();
            })
        });
    </script>
    <script type="text/javascript">
        $(function () {

            var $window = $(window),
			window_width = $window.width();
            $('#js_banner, #js_banner_img li').width(window_width);

            var urlParam = G.util.parse.url(),
			startFrame = 0;
            if (urlParam.search && ('banner' in urlParam.search)) {
                startFrame = (parseInt(urlParam.search['banner']) - 1) || 0;
            }

            new $.Tab({/*添加圆点按钮*/
                target: $('#js_banner_img li'),
                effect: 'fade',
                animateTime: 1000,
                stay: 7000,
                playTo: startFrame,
                autoPlay: true,
                merge: true,
                prevBtn: $('#js_banner_pre'),
                nextBtn: $('#js_banner_next')
            });
            $('#js_banner_img').css('left', '-' + (window_width * startFrame) + 'px');
        })

      $(window).resize(function () {
      window.location.href = window.location.href });    
    </script>

    <script type="text/javascript">

        function CheckUserLogin() {

            var isUserLogin = false;
            // check if user is login or not\
            var _data = "{ action:'queryuserlogin'}";
            $.ajax({
                type: "POST",
                url: '../AjaxPages/shareAjax.aspx',
                async: false,
                data: _data,
                dataType: "text",
                success: function (record) {
                    if (record == "1") isUserLogin = true;
                }
            });
            return isUserLogin;
        }

        function DoGetStartedOne() {
            // goes to login if user is not login
            // goes to member center is user is login
            var isUserLogin = CheckUserLogin();
            if (isUserLogin) window.location.href = "Home/index.aspx";
            else window.location.href = "User/login.aspx";
        }

        function hiddenShare() {
            $("#share-tck2").parents(".greybox").hide();
        }

        function SharePrd(id, name, img, page, desc, prdPrice) {
            name = unescape(name);
            if (SetShareLink(id, name, img, page, desc, prdPrice) == true) {
                $("#share-tck2").parents(".greybox").show()
                $("#share-tck2").animate({ top: "2%" }, 300)
            }
        }

        //Favorite    
        function FavoritePrd(prdID) {

            var _data = "{ action:'" + 'add' + "',id:'" + prdID + "'}";
            $.ajax({
                type: "POST",
                url: '../AjaxPages/FavoriteAjax.aspx',
                data: _data,
                dataType: "text",
                success: function (resu) {
                    if (resu == "success") {
                        alert("This item has been saved to your Favorites. To access, just log in to your account and select 'My Favorites'.");
                    }
                    else if (resu == "-1") {
                        alert("Please login!");
                    }
                    else {
                        alert("Failed to favorite");
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Failed to favorite");
                }
            });

        }


     </script>

</asp:Content>

