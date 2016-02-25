<%@ Page Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="CollageReview.aspx.cs" Inherits="TweebaaWebApp.Product.CollageReview" %>



<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
	<title>Collage Desing Review</title>
	<link rel="stylesheet" href="../css/index.css" />
	<script src="../js/jquery.min.js" type="text/javascript"></script>
	<script src="../js/qtab.js" type="text/javascript"></script>
	<script type="text/javascript" src="../js/public.js"></script>
	<link rel="stylesheet" href="../css/shareall.css" />

    <script type="text/javascript" src="../js/jquery-ui.js" ></script>
    <script type="text/javascript" src="../js/jquery.cookie.js" ></script>
    <script type="text/javascript" src="../js/jquery.mousewheel.min.js" ></script>

	<script type="text/javascript" src="../js/jquery.iviewer.js" ></script>
	<script type="text/javascript" src="../js/CollageDesign.js" ></script>
    <script type="text/javascript" src="../js/jquery.poshytip.js" ></script>
    <style>
        #design_workarea
        {
        	/*position: relative;
        	float:left;*/
        	width:600px;
        	padding-left:10px;
        }
        .overlay-share div.fr
        {
        	width:220px !important;
        	margin-left:10px;
        }
        div.kuang92{ Z-INDEX: 200;}
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">  




<div class="h10"></div>

    <input type="hidden" id="hidpersent" value="<%=_persent %>" />
    <input type="hidden" id="hiduserid" value="<%=_userid %>" />
    <input type="hidden" id="DesignIsValid" value="<%=IsValidID %>" />
<div class="pingshen-main" id="overlay-share">
	
	<div class="w975 mbx">
		<a href="/index.aspx">Home</a> > <a href="/Product/prdSingleShare.aspx">Share</a> > <b class="l">Collage Review</b>
	</div>
	
	<div class="w975 pingshen-box">
		<!-- 产品描述 -->
		<div class="title">
			<span id="link_share_earn"></span>
			<a  href="javascript:void(0)" onclick="FavoriteCollage('<%=design_id %>')" class="fr sc">Favorite</a>
			<h1 class="fl"><strong><%=sTitle %></strong></h1>
			<span class="fl subtime">
				Designer：<span id="txtDesignerInfo"></span>
			</span>
			
		</div>
		<div class="overlay-share clearfix">
			<div class="fr">
				<h5><strong>Designer Inspiration</strong></h5>
				<p class="inspiration-txt">
					<%=sInspiration %>
				</p>
				<h5><strong>Comment this collage design</strong></h5>
				<textarea name="txtComments" id="txtComments" class="pj-text"></textarea>
				<input type="button" id="btnPostComment" value="Comment" onclick="write_comments()" class="send-pj"/>
				
			</div>
            <input type="hidden" id="userID" name="userID" value="<%=_userid %>" />
            <input type="hidden" id="txtDesignID" name="txtDesignID" value="<%=design_id %>" />
			<input type="hidden" id="txtShareID" name="txtShareID" value="<%=shareID %>" />
            
			<div id="design_workarea" class="bigImgBox">


			</div>

		</div>
	
<!-- product information popup dialog -->
    		<div id="product_popup1" class="kuang92">
					<div class="thisInfor">
						<div class="pro-infor">
							<span id="product1_name"></span>
							<p class="txt" id="product1_desc">
								
							</p>
							<div class="row3 clearfix">
								 <span id="product1_add2cart"></span>
								 <span class="price fl" id="product1_price">
								 	
								 </span>
							</div>
							<div class="tc row4"><!--
								<span class="fr"><a href="javascript:;" class="loveNumber" title="Like">100</a>
								</span>
								<span class="fl">Sold：100 pcs</span> <span class="color">Final-Sale</span> -->
							</div>
						</div>
                        <span id="product1_img"></span>
					</div>
				</div>

    		<div id="product_popup2" class="kuang92">
					<div class="thisInfor">
						<div class="pro-infor">
							<span id="product2_name"></span>
							<p class="txt" id="product2_desc">
								
							</p>
							<div class="row3 clearfix">
								 <span id="product2_add2cart"></span>
								 <span class="price fl" id="product2_price">
								 	
								 </span>
							</div>
							<div class="tc row4"><!--
								<span class="fr"><a href="javascript:;" class="loveNumber" title="Like">100</a>
								</span>
								<span class="fl">Sold：100 pcs</span> <span class="color">Final-Sale</span>-->
							</div>
						</div>
                        <span id="product2_img"></span>
					</div>
				</div>
    		<div id="product_popup3" class="kuang92">
					<div class="thisInfor">
						<div class="pro-infor">
							<span id="product3_name"></span>
							<p class="txt" id="product3_desc">
								
							</p>
							<div class="row3 clearfix">
								 <span id="product3_add2cart"></span>
								 <span class="price fl" id="product3_price">
								 	
								 </span>
							</div>
							<div class="tc row4"><!--
								<span class="fr"><a href="javascript:;" class="loveNumber" title="Like">100</a>
								</span>
								<span class="fl">Sold：100 pcs</span> <span class="color">Final-Sale</span>-->
							</div>
						</div>
                        <span id="product3_img"></span>
					</div>
				</div>
    		<div id="product_popup4" class="kuang92">
					<div class="thisInfor">
						<div class="pro-infor">
							<span id="product4_name"></span>
							<p class="txt" id="product4_desc">
								
							</p>
							<div class="row3 clearfix">
								 <span id="product4_add2cart"></span>
								 <span class="price fl" id="product4_price">
								 	
								 </span>
							</div>
							<div class="tc row4"><!--
								<span class="fr"><a href="javascript:;" class="loveNumber" title="Like">100</a>
								</span>
								<span class="fl">Sold：100 pcs</span> <span class="color">Final-Sale</span>-->
							</div>
						</div>
                        <span id="product4_img"></span>
					</div>
				</div>
    		<div id="product_popup5" class="kuang92">
					<div class="thisInfor">
						<div class="pro-infor">
							<span id="product5_name"></span>
							<p class="txt" id="product5_desc">
								
							</p>
							<div class="row3 clearfix">
								 <span id="product5_add2cart"></span>
								 <span class="price fl" id="product5_price">
								 	
								 </span>
							</div>
							<div class="tc row4"><!--
								<span class="fr"><a href="javascript:;" class="loveNumber" title="Like">100</a>
								</span>
								<span class="fl">Sold：100 pcs</span> <span class="color">Final-Sale</span>-->
							</div>
						</div>
                        <span id="product5_img"></span>
					</div>
				</div>
    		<div id="product_popup6" class="kuang92">
					<div class="thisInfor">
						<div class="pro-infor">
							<span id="product6_name"></span>
							<p class="txt" id="product6_desc">
								
							</p>
							<div class="row3 clearfix">
								 <span id="product6_add2cart"></span>
								 <span class="price fl" id="product6_price">
								 	
								 </span>
							</div>
							<div class="tc row4">
                            <!--
								<span class="fr"><a href="javascript:;" class="loveNumber" title="Like">100</a>
								</span>
								<span class="fl">Sold：100 pcs</span> <span class="color">Final-Sale</span>
                                -->
							</div>
						</div>
                        <span id="product6_img"></span>
					</div>
				</div>
    		<div id="product_popup7" class="kuang92">
					<div class="thisInfor">
						<div class="pro-infor">
							<span id="Span1"></span>
							<p class="txt" id="product7_desc">
								
							</p>
							<div class="row3 clearfix">
								 <span id="product7_add2cart"></span>
								 <span class="price fl" id="product7_price">
								 	
								 </span>
							</div>
							<div class="tc row4">
                            <!--
								<span class="fr"><a href="javascript:;" class="loveNumber" title="Like">100</a>
								</span>
								<span class="fl">Sold：100 pcs</span> <span class="color">Final-Sale</span>
                                -->
							</div>
						</div>
                        <span id="product7_img"></span>
					</div>
				</div>
    		<div id="product_popup8" class="kuang92">
					<div class="thisInfor">
						<div class="pro-infor">
							<span id="product8_name"></span>
							<p class="txt" id="product8_desc">
								
							</p>
							<div class="row3 clearfix">
								 <span id="product8_add2cart"></span>
								 <span class="price fl" id="product8_price">
								 	
								 </span>
							</div>
							<div class="tc row4">
                            <!--
								<span class="fr"><a href="javascript:;" class="loveNumber" title="Like">100</a>
								</span>
								<span class="fl">Sold：100 pcs</span> <span class="color">Final-Sale</span>
                                -->
							</div>
						</div>
                        <span id="product8_img"></span>
					</div>
				</div>
<!-- product information popup dialog EOF-->


		<!-- tab -->
		<div class="w975">
			<div class="tab">
				
					<a href="javascript:;">Collage product list</a>
					<a href="javascript:;">Comment(<span id="comment_count"></span>)</a>
				
			</div>
		</div>
		<!-- tabCon -->
		<div class="tabCon">
			<div class="itembox">
				<div class="w964 recent-collection jstabcon overlay-share-pro" id="mainsrp-itemlist" >
						<div class="m-itemlist">
							<div class="items clearfix" id="products_lists">
							</div>
                            <!--
							<div class="down-more tc">
								<a href="#" class="down-mores">View More</a>
							</div>
                            -->
						</div>
				</div>
			</div>
			<div class="itembox">
				<ul class="pinglun-list" id="ulCommentsList">

				</ul>
				<div class="page tr" id="CommentsPage">
				</div>
			</div>

		</div>


	</div>

</div>

<!--
<div class="w975 tuijian-pro">
	<h2>
		Similar Collage List
	</h2>
</div>
<div class="w964 recent-collection jstabcon" id="mainsrp-itemlist_similar" >
		<div class="m-itemlist">
			<div class="items clearfix">
			</div>
			<div class="down-more tc">
				<a href="#" class="down-mores">View More</a>
			</div>
		</div>
</div>
-->

 
    <div class="greybox">
        <div id="share-tck2" class="tck">
             <a href="#" class="closeBtn" title="Close"></a>
             <h2 class="t">
                <span>Share & Earn</span>
            </h2>
             <div class="box">
                <div class="sharebox clearfix my-dietu">
                    <span class="fl t ">Share to </span>
                    <div class="bdsharebuttonbox fl">
                                                <a href="javascript:void(0);" target="_blank" id="shareToFacebook" title="Facebook"><img src="../Images/flat-circles_03.png" /></a>&nbsp;&nbsp;
                        <a href="javascript:void(0);" target="_blank" id="shareToTwitter" title="Twitter"><img src="../Images/flat-circles_05.png" /></a>&nbsp;&nbsp;
                        <a href="javascript:void(0);" target="_blank" id="shareToGoogle" title="Google"><img src="../Images/flat-circles_13.png" /></a>&nbsp;&nbsp;
                        <!--a href="javascript:void(0)" target="_blank" id="share4" title="Wechat"><img src="../Images/share-rss.png" /></a>&nbsp;&nbsp;-->
                        <a href="javascript:void(0);" target="_blank" id="shareToPinterest" title="Pinterest"><img src="../Images/share-pin.png" /></a>&nbsp;&nbsp;
                        
                        <a href="javascript:void(0)" target="_blank" id="shareToEmail" title="Email"><img src="../Images/share-mail.png" /></a>

                    </div>                  
                    <!--a href="/Home/Index.aspx" class="share-media-set">Link My Account</a-->
                </div>
                <div class="ps clearfix">
                    <span class="fr"><a href="#"></a></span><span class="fl">You will earn  <!--span id="sharePercent"></span-->commission when your friend makes a purchase from your shared link. </span>
                </div>
            </div>
            
        </div>
    </div>















<script type="text/javascript">

    var iTotalPage;
    var iPrevPage = 1;
    var pageDiv = 20;
    var limitTime = null;

    //详情和评价切换
    $(".pingshen-box").qTab({
        tabT: ".tab a", //tab title
        tabCon: ".itembox"//tab Con
    })

    //Expand评论
    $(".open-p").click(function () {
        $(".open-p").show();
        $(".recently-list .auto").removeClass('on')
        $(this).hide().siblings('.auto').addClass('on')
        return false;
    })


    //显示 Favorite和分享

    $("#mainsrp-itemlist .box").live('mouseenter', function (event) {
        $(this).addClass('hover').parent().css('zIndex', '100');
        $(this).find(".floatDiv").stop().animate({ top: 0 }, 100)
    }).live('mouseleave', function (event) {
        $(this).removeClass('hover').parent().css('zIndex', '');
        $(this).find(".floatDiv").stop().animate({ top: "-110px" }, 100)
    });

    $(".share-btn").live('mouseenter', function (event) {
        $(this).siblings().show();
    }).live('mouseleave', function (event) {
        $(this).siblings().hide();
    });

    $(".closeBtn,.go-share-btn").click(function () {
        $(this).parents(".greybox").hide();
        return false;
    })

    //模拟点击分享按钮，随机 登陆 和未登录状态 。

    $(".yellow-share,.share-btn").live('click', function (event) {
        var shareTck = ["#share-tck2", "#share-tck"]
        var thisb = $(shareTck[parseInt(Math.random() * 2)])
        thisb.animate({ top: "2%" }, 300);
        thisb.parent().show()
        return false;
    });

    function write_comments() {
        var sDesignID =<%=design_id %>;// $("#txtDesignID").val();
        var txtComments = $("#txtComments").val();
        
        
        if ("<%=isLogion %>" == "False") {
            //save data and template ID
            //var template_id = $("#templateID").val();
            $.cookie("back2Collage", 3);// post comments
            $.cookie("DesignID", sDesignID);
            $.cookie("txtComments", txtComments);

            window.location.href = "/User/login.aspx?op=CollageReview";
            return;
        }
        var txtUserID = $("#userID").val();

        $.ajax({
            type: "POST",
            url: "CollageComments.ashx",
            data: "{ 'txtComments':'" + txtComments
                + "','action':'" + "save_comment"
                + "','txtUserID':'" + txtUserID
                + "','txtDesignID':'" + sDesignID
                + "'}"
        }).done(function (o) {
            console.log('saved:' + o);
            if (parseInt(o) == 1) {
                $("#txtComments").val("Your Comments Saved");
                limitTime = 20;
                limitComment();
                LoadCommentsTotal();
            }
           
        });

    }

    function limitComment() {
        limitTime = limitTime - 1;
        if (limitTime > 0) {
                $("#txtComments").val('you can post another comment after ' + limitTime + ' seconds');
                $("#txtComments").attr('disabled', 'disabled');
                $("#btnPostComment").attr('disabled', 'disabled');
                setTimeout("limitComment()", 1000);
        } else if (limitTime == 0) {
                $("#txtComments").val('');
                $("#txtComments").removeAttr('disabled');
                $("#btnPostComment").removeAttr('disabled', '');
        }

    }
    

    function LoadCommentsTotal() {
        var sDesignID = <%=design_id %>;//$("#txtDesignID").val();
        $.ajax({
            type: "POST",
            url: "CollageComments.ashx",
            data: "{ 'action':'" + "load_comment_total"
                + "','DesignID':'" + sDesignID
                + "'}"
        }).done(function (xml) {
            var stotal = $(xml).find('total').text();
            console.log("total=" + stotal);
            var iTotal = Math.ceil(stotal / pageDiv);
            //make pages
            var i = 0; var html = '<a href="#" class="up">&lt;</a>';

            for (i = 1; i <= iTotal; i++) {
                if (i == 1) {
                    html += '<a href="#" id="CN_' + i + '" class="on" onclick="CommentPageNavigate(' + i + ')" >' + i + '</a>';
                } else {

                    html += '<a href="#" id="CN_' + i + '" onclick="CommentPageNavigate(' + i + ')">' + i + '</a>';
                }
            }
            html += '<a href="#" class="down">&gt;</a>';
            $("#CommentsPage").html(html);
            $("#comment_count").html(stotal);
            //load first page
            LoadComments(1);

        });
    }

    function CommentPageNavigate(iPage) {
        $("#CN_" + iPrevPageMyDraft).removeClass("on");
        LoadComments(iPage);
        $("#CN_" + iPage).addClass("on");
        iPrevPageMyDraft = iPage;
    }
    function LoadComments(iPage) {
        var sDesignID =<%=design_id %>;// $("#txtDesignID").val();
        $.ajax({
            type: "POST",
            url: "CollageComments.ashx",
            data: "{'action':'" + "load"
                + "','txtDesignID':'" + sDesignID
                + "','page':'" + iPage
                + "'}",
            dataType: "xml"
        }).done(function (xml) {
            var html = "";
            $(xml).find('comment').each(function () {
                var sID = $(this).find('ID').text();
                var comments_text = $(this).find('comments_text').text();
                var user_name = $(this).find('user_name').text();
                var CreateTime = $(this).find('CreateTime').text();
                html += '<li><span class="fr time">';
                html += CreateTime + '</span>';
                html += '<span class="fr people">';
                html += '<a href="" class="vip-lv vip-lv5">' + user_name + '</a>';
                html += '</span>';
                html += '<p class="fl">';
                html += comments_text;
                html += '</p></li>';
                //console.log("html=" + html);
            });
            $("#ulCommentsList").html(html);
        });

    }
</script>






<!-- 无线加载js -->
<script type="text/javascript">
    $(function () {
        //url data function dataType
        var iCommentPage = 1;
        $.cookie("DesignID",0);
       

       //if this link back from SNS ?
       var sLinkback ="<%=shareID %>";
       if(sLinkback.length>10){
            //This is link back, so we should add poits
            //if($.cookie("Collage_Linkback")==null || $.cookie("Collage_Linkback")==0)
            {
                //send request
                
                $.ajax({
                type: "POST",
                url: "CollageShareHandler.ashx",
                data: "{ 'action':'" + "share_link_back"
                    + "','txtShareID':'" + sLinkback
                    + "'}"
                }).done(function (o) {
                    $.cookie("Collage_Linkback",1);

           
                }).error(function (XMLHttpRequest, textStatus, errorThrown) {
                     alert("Failed saved data");
                })
            }

       }

         //Load Design from database
        LoadDesign(<%=design_id%>,2);

        //if come back from login windows, we need to post the comments for the user
        if("<%=isLogion %>"=="True" && $.cookie("back2Collage")==3){

            var txtComments = $.cookie("txtComments");
            var sDesignID = $.cookie("DesignID");
        

            var txtUserID = $("#userID").val();

            $.ajax({
                type: "POST",
                url: "CollageComments.ashx",
                data: "{ 'txtComments':'" + txtComments
                    + "','action':'" + "save_comment"
                    + "','txtUserID':'" + txtUserID
                    + "','txtDesignID':'" + sDesignID
                    + "'}"
            }).done(function (o) {
                $.cookie("back2Collage",0);
                $.cookie("txtComments","");
                $.cookie("DesignID","");
                console.log('saved:' + o);
                if (parseInt(o) == 1) {
                    $("#txtComments").val("Your Comments Saved");
                    limitTime = 10;
                    limitComment();
                    LoadCommentsTotal();
                }
           
            });
        }
        //loadMeinv($(".jstabcon").eq(0));
        //loadMeinv($(".jstabcon").eq(1));
        //无限加载
        $(window).on("scroll", function () {
            $minUl = getMinUl();
            if ($minUl.height() <= $(window).scrollTop() + $(window).height()) {
                //如果要鼠标滚动就加载，
                //loadMeinv();//加载新图片
            }
        })
        function getMinUl(obj) {
            var $arrUl = $(obj).find('.items')
            var $minUl = $arrUl.eq(0);
            $arrUl.each(function (index, elem) {
                if ($(elem).height() < $minUl.height()) {
                    $minUl = $(elem);
                }
            });
            return $minUl;
        }
        //点击更多加载
        $(".down-mores").click(function () {
            $minUl = getMinUl($(this).parents(".w964"));
            loadMeinv($(this).parents(".w964"));
            return false;
        });


        //Load Comments for this Design
        LoadCommentsTotal();

        for(i=1;i<=8;i++){
         $('#product_popup'+i).hide();
        }

    })
</script>
</asp:Content>
