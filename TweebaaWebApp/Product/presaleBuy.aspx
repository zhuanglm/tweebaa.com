<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="presaleBuy.aspx.cs" Inherits="TweebaaWebApp.Product.presaleBuy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
Everybody earns at Tweebaa 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="../Css/buyall.css?v=<%=_sCurVer%>" />
    <link rel="stylesheet" href="../Css/sale-page.css?v=<%=_sCurVer%>" />
    <link href="../Css/shareBox.css?v=<%=_sCurVer%>" rel="stylesheet" type="text/css" />
    <link href="../Js/jpager/pagination.css" rel="stylesheet" />
    <script src="../Js/jpager/jquery.pagination.js" type="text/javascript"></script>
    <script src="../Js/jpager/members.js" type="text/javascript"></script>    
    
    <script type="text/javascript" src="../Js/addnumber2.js"></script>
    <script type="text/javascript" src="../Js/zhutu.js"></script>
     <script src="../Js/swfobject.js" type="text/javascript"></script>
    <script src="../MethodJs/videoPlay.js?v=<%=_sCurVer%>" type="text/javascript"></script>
    <script src="../MethodJs/favorite.js?v=<%=_sCurVer%>" type="text/javascript"></script>
    <script src="../MethodJs/saleBuy.js?v=<%=_sCurVer%>" type="text/javascript"></script>
   <%-- <script src="../MethodJs/prdSale.js" type="text/javascript"></script>--%>
    <script src="../MethodJs/share.js?v=<%=_sCurVer%>" type="text/javascript"></script>
     <script src="../MethodJs/VisitTimer.js?v=<%=_sCurVer%>" type="text/javascript"></script>
    <!--script src="../MethodJs/shareToSocialNetwork.js" type="text/javascript"></script-->

    <style type="text/css">
      .selectColor{cursor:pointer; width:21px; height:21px; padding-left:2px; padding-right:1px; padding-top:2px; padding-bottom:1px; margin-right:5px;float:left;}
      .selectColor div{width:20px;height:20px; background:red; margin:0 auto;}
    </style> 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <input type="hidden" id="hid_proid" value="<%=_proid %>" />
    <input type="hidden" id="hiduserid" value="<%=_userid %>" />
   <script type="text/javascript">
       var priceMin = "";
   </script>
    <div class="h10">
    </div>
    
    <div class="pingshen-main" id="sale-page">
        <div class="w975 mbx">
            <a href="#">Home</a> > <a href="prdPreSale.aspx?step=2">Test-Sale</a> > <a href="" style=" display:none;">
                <label id="labCateTile">
                </label>
            </a><%-->--%> <b class="l">Product Details</b>
        </div>
        <div class="w975 pingshen-box presale-ing-box">
            <!-- 产品描述 -->
            <div class="title">
                <a href="#" id="htrfShare" class="yellow-share fr">Share & Earn</a>
                <h1 class="fl">
                    <strong>
                        <label itemprop="name" id="pro-name"><% = HttpUtility.HtmlEncode(_model.name) %>
                        </label>
                    </strong>
                </h1>
                <span class="fl subtime"><%--Release Date--%>
                    <label id="pro-time" style="display:none;">
                    </label>
                </span>
            </div>
            <div class="des-box clearfix">
                <!-- 描述 -->
                <div class="product-des fr">
                    <div class="des-txt" >
                        <div> 
                          <%--  <strong class="fb">Product features： </strong>--%> 
                            <label itemprop="description" id="pro-jl"><% = HttpUtility.HtmlEncode(_model.txtjj) %>
                            </label>
                        </div>
                       
                        <div id="div-question"> 
                            <%--<strong class="fb" id="title-Solution">Solution： </strong>--%> 
                            <label id="pro-question">
                            </label>
                        </div>
                    </div>
                                     
                    <div class="sold-infor clearfix" style="padding-top:15px;">
                        <div class="yushou-jdt">
                            <p class="dao321" style=" padding-left:90px;font-size:12px;" id ="labendDay">
                               <!--strong id="labendDayStrong"><label id="labendDay"></label></strong--><%--<strong>00</strong>时<strong>00</strong>分<strong>00</strong>秒--%>
                            </p>
                            <span class="jdt"><i style="width:1%;"  id="passagerbar"></i></span>
                            <p style="text-align:right; font-size:12px;"><%--<b style="color:Red;">--%>Test-Sale Units left: <strong><label id="labPreSaleLeftUnit"></label></strong>
                            <!--    Sold: <strong><label id="labSaleCount"></label></strong>&nbsp;&nbsp;Target: <strong><label id="labPreSaleForward"></label></strong-->
                            </p>
                           <%--<span class="num"><label id="labPreSaleForward"></label> pieces</span>--%>
                        </div>
                        <div class="fl">
                            <span class="fl">Market price <del>$
                                <label id="pro-price2" style="margin-left:-5px;">
                                </label>
                            </del></span>
                            <div class="clear">
                            </div>
                            <span class="fl">Test-Sale Price <strong class="priceNumber yushouColor">$
                                <label id="pro-price" style="margin-left:-10px;">
                                </label>
                            </strong></span>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <!-- 物流 -->
                    <%--<div class="wuliu fr">
                        <ul>
                            <li><span class="t">送货到: </span><span class="tcon pr"><span id="select-area" area-data="0">
                                北京 </span>
                                <div class="select-area">
                                    <a href="#" area-data="0">北京</a> <a href="#" area-data="1">上海</a> <a href="#" area-data="2">
                                        天津</a> <a href="#" area-data="3">广州</a> <a href="#" area-data="4">天津</a> <a href="#"
                                            area-data="5">广州</a>
                                </div>
                            </span></li>
                            <li><span class="t">物流: </span><span class="tcon pr"><span id="select-wuliu" wuliu-data="0">
                                德邦物流 8-12天</span>
                                <div class="select-wuliu">
                                    <a href="#" wuliu-data="0"><font>德邦物流</font>8-12天</a> <a href="#" wuliu-data="1"><font>
                                        顺风物流</font>8-12天</a> <a href="#" wuliu-data="2"><font>EMS物流</font>8-12天</a>
                                </div>
                            </span></li>
                            <li>退换货政策:7天无理由退换货 </li>
                        </ul>
                    </div>--%>
                    <!-- 尺码 -->
                    <%--<div class="chima fl">
                        <ul>
                            <li>型号:三星S4 </li>
                            <li><span>材质:塑料 </span><i></i><span>重量:322G </span></li>
                            <li>制造国家:中国 </li>
                        </ul>
                    </div>--%>
                    <div class="h22"></div>
                    <!-- Size -->
                    <div class="guige fl">
                        <dl class="fl">
                            <dt class="fl"><%=_proRuleTitle %> </dt>
                            <style type="text/css">
                                #fltemp span {
                                  margin-top:3px;
                                }
                                #proColorArea span {
                                    margin-top:3px;
                                }
                            </style>
                            <dd class="fl" id="fltemp">
                                <%=_ruleName%>
                                <%--<span class="jsclick">S </span><span class="jsclick">M </span><span class="jsclick">
                                    L </span>--%>
                            </dd>
                        </dl>
                    </div>
                    <!-- Color -->
                    <div id="allColor" style=" display:none;">
                    <%=_allColor %>
                    </div>
                    <div class="color fl">
                        <dl class="fl">
                            <dt class="fl">Color </dt>
                            <dd id="proColorArea" class="fl" selectedRuleid="" style="padding-top:2px;">
                                <%=_firstColor%>
                               <%-- <span class="jsclick js-preview" style="background-color: #FFF799;" data-mid-img="">
                                </span><span class="jsclick js-preview" style="background-color: #C69C6D;" data-mid-img="">
                                </span><span class="jsclick js-preview" style="background-color: #998675;" data-mid-img="">
                                </span>--%>
                            </dd>
                        </dl>
                    </div>
                    <!-- 购买Quantity -->
                    <div class="buyNumber">
                        <dl class="fl">
                            <dt class="fl">Quantity </dt>
                            <dd class="fl">
                                <span class="number pr">
                                    <input type="button" class="left-btn btn" value="-">
                                    <input type="button" class="right-btn btn" value="+">
                                    <input type="text" class="num tc" value="1" id="txtQuantity" />
                                </span>
                            </dd>
                             <dd class="fl">
                                <span class="kucun"></span>
                            </dd>
                            <!-- <dd class="fl">
                                <a href="#" class="want-pifa">I want to wholesale</a>
                            </dd>-->
                        </dl>
                    </div> 

                    <div class="btn-group clearfix">
                       <%-- <a href="javascript:void(0);" class="now-buy" onclick="AddShopCartBuyNow()">Pre-order</a> --%>
                        <a href="javascript:void(0);" class="join-car" onclick="AddShopCart()">Add to Cart</a>
                        <% string favoriteClass = "sc";
                           if (_favorite) favoriteClass = "schover";
                           %>
                        <a id="linkFavorite" href="javascript:void(0);" class="<% =favoriteClass %>" onclick="DoFavoritePrdOnOff('#linkFavorite');">Favorite</a>
                      <!--  <a href="#" class="download">Save to Store</a>-->
                    </div>
                    <div class="tips fl">
					Note: This is a Test-Sale item.Your order will put this item one step closer to being “Tweebaa-Approved”.  Your credit card will be charged at checkout, but you’ll receive 100% refund if the Target Quantity is not reached.  Extended shipping time will apply.</div>
                </div>
                <!-- 主图 -->
                <div class="preview fl">
                    <div id="vertical" class="bigImg">
                        <img itemprop="image" src="<% =_imgUrl %>" width="400" height="400" alt="" id="midimg" />
                        <div style="display: none;" id="winSelector">
                        </div>
                        <i class="Magnifier"></i>
                    </div>
                    <!--bigImg end-->
                    <div class="smallImg">
                        <a href="javascript:;" class="btn leftBtn"></a><a href="javascript:;" class="btn rightBtn">
                        </a>
                        <div id="imageMenu">
                            <ul>
                                <li id="onlickImg">
                                    <img src="" id="imgSmall1" width="68" height="68" alt="" />
                                </li>
                                <li>
                                    <img src="" id="imgSmall2" width="68" height="68" alt="" /></li>
                                <li>
                                    <img src="" id="imgSmall3" width="68" height="68" alt="" /></li>
                                <li>
                                    <img src="" id="imgSmall4" width="68" height="68" alt="" /></li>
                                <li>
                                    <img src="" id="imgSmall5" width="68" height="68" alt="" /></li>
                            </ul>
                        </div>
                    </div>
                    <!--smallImg end-->
                    <div id="bigView" style="display: none;">
                        <img width="800" height="800" alt="" src="" id="bigShowImg" /></div>
                </div>
                <!-- 主图 -->
            </div>
            <!-- tab -->
            <div class="w975">
                <div class="tab">
                    <a href="javascript:;">Details</a> <a href="javascript:;" style="display:none;">Reviews(<label id="labReviewCount"><%=_passCount %></label>)</a>
                </div>
            </div>
            <!-- tabCon -->
            <div class="tabCon">
                <div class="itembox">
                    <div class="tc">
                        <div class="video" id="CuPlayer" style="margin: 0 auto;">
                        </div>
                    </div>
                    <div class="tc" id="pro-info">
                    </div>
                </div>
                <div class="itembox">
                    <ul class="pinglun-list">
                    </ul>
                    <div id="Pagination" class="pagination" style="margin:5px; float:right; padding-right:40px;"></div>
                    <div style="clear:both;"></div>
              <form name="paginationoptions" style=" display:none;">
                <% 
                    // calculate the total links 
                    int iTotalNumberOfLink = int.Parse(_passCount)/10;
                    if ((int.Parse(_passCount) % 10) != 0 )iTotalNumberOfLink ++;
                %>
                <p><label for="items_per_page">Number of items per page</label><input type="text" value="10" name="items_per_page" id="items_per_page" class="numeric"/></p>
                <p><label for="num_display_entries">Number of pagination links shown</label><input type="text" value="<% =iTotalNumberOfLink %>" name="num_display_entries" id="num_display_entries" class="numeric"/></p>
                <p><label for="num">Number of start and end points</label><input type="text" value="0" name="num_edge_entries" id="num_edge_entries" class="numeric"/></p>
                <p><label for="prev_text">"Previous" label</label><input type="text" value="Prev" name="prev_text" id="prev_text"/></p>
                <p><label for="next_text">"Next" label</label><input type="text" value="Next" name="next_text" id="next_text"/></p>
                <input type="button" id="setoptions" value="Set options" />
            </form>

                    <script type="text/javascript">
                        function pageselectCallback(page_index, jq) {
                            //alert(page_index);
                            var pageSize = parseInt($('#items_per_page').val());
                            //alert(pageSize);
                            var index = parseInt(page_index);
                            var startId = pageSize * index + 1;
                            //alert(startId);
                            var endId = startId + pageSize - 1;
                            //alert(endId);

                            LoadReviewInfo(startId,endId);



                            return false;
                        }

                        // The form contains fields for many pagiantion optiosn so you can
                        // quickly see the resuluts of the different options.
                        // This function creates an option object for the pagination function.
                        // This will be be unnecessary in your application where you just set
                        // the options once.
                        function getOptionsFromForm() {
                            var opt = { callback: pageselectCallback };
                            // Collect options from the text fields - the fields are named like their option counterparts
                            $("input:text").each(function () {
                                opt[this.name] = this.className.match(/numeric/) ? parseInt(this.value) : this.value;
                            });
                            // Avoid html injections in this demo
                            var htmlspecialchars = { "&": "&amp;", "<": "&lt;", ">": "&gt;", '"': "&quot;" }
                            $.each(htmlspecialchars, function (k, v) {
                                opt.prev_text = opt.prev_text.replace(k, v);
                                opt.next_text = opt.next_text.replace(k, v);
                            })
                            return opt;
                        }

                        // When document has loaded, initialize pagination and form
                        $(document).ready(function () {
                            // Create pagination element with options from form
                            var optInit = getOptionsFromForm();
                            //$("#Pagination").pagination(members.length, optInit);
                            $("#Pagination").pagination(<% =_passCount %>, optInit);

                            // Event Handler for for button
                            $("#setoptions").click(function () {
                                var opt = getOptionsFromForm();
                                // Re-create pagination content with new parameters
                                //$("#Pagination").pagination(members.length, opt);
                                $("#Pagination").pagination(<% =_passCount %>, opt);
                            });

                        });

        </script>

                </div>
            </div>
        </div>
    </div>
    <!-- 列表	 -->
    <div class="w975 tuijian-pro" style="display:none;">
        <h2>
            推荐产品
        </h2>
    </div>
    <div class="w975" id="mainsrp-itemlist" style="display:none;">
        <div class="m-itemlist">
            <div class="items clearfix">
            </div>
            <div class="down-more tc">
                <a href="#" id="down-more">点击下拉查看更多</a>
            </div>
        </div>
    </div>
    <br /> <br />
  
    <!-- 浮动在线咨询 -->
    <script type="text/javascript">
        //表单提示
        $('input, textarea').placeholder();


        //详情和评价切换
        $(".pingshen-box").qTab({
            tabT: ".tab a", //tab title
            tabCon: ".itembox"//tab Con
        })

        //显示 Favorite和分享

        $("#mainsrp-itemlist .box").live('mouseenter', function (event) {
            $(this).addClass('hover')
            $(this).find(".floatDiv").stop().animate({ top: 0 }, 100)
        }).live('mouseleave', function (event) {
            $(this).removeClass('hover')
            $(this).find(".floatDiv").stop().animate({ top: "-110px" }, 100)
        });

        //尺码 Color选中

        //$(".jsclick").live('click', function (event) {

        //    if ($(this).hasClass('on')) {
        //        $(this).removeClass('on')
        //    } else {
        //        $(this).addClass('on').siblings('.jsclick').removeClass('on')
        //    }
        //});

        //显示地区和快递select
        $("#select-area").parent().click(function (event) {
            $(".select-area").show();
        }).css({
            zIndex: '2'
        });
        $("#select-area").parent().mouseleave(function (event) {
            $(".select-area").hide();
        });
        $(".select-area > a").click(function (event) {

            $("#select-area").html($(this).html()).attr({
                "area-data": $(this).attr("area-data")
            });
            $(".select-area").hide();
            return false;
        });

        $("#select-wuliu").parent().click(function (event) {
            $(".select-wuliu").show();
        })
        $("#select-wuliu").parent().mouseleave(function (event) {
            $(".select-wuliu").hide();
        });
        $(".select-wuliu > a").click(function (event) {

            $("#select-wuliu").html($(this).html()).attr({
                "wuliu-data": $(this).attr("wuliu-data")
            });
            $(".select-wuliu").hide();
            return false;
        });

    </script>
    <script type="text/javascript">
        $(function () {
            //url data function dataType
            function loadMeinv() {

                for (var i = 0; i < 4; i++) {//每次加载4条信息
                    //以下是模拟信息
                    var html, zt1, zt2, zt3, zt4;
                    //zt1,zt2,zt3,zt4;对应产品的4中状态 
                    //zt1 预售中 //zt2 销售中 //zt3 预售成功 //zt4预售失败

                    //模拟信息结束
                    zt1 = '<div class="item presale-ing"><div class="box"><div class="pic-box"><a href="#" class="imglink"><img src="../Images/224x224.jpg" alt=""></a><div class="floatDiv"><a href="#" class="love" title="Favorite">Favorite</a> <a href="#" class="down" title="资料下载">资料下载</a> <a href="#" class="share" title="Share & Earn">Share & Earn</a></div></div><div class="row row1"><a href="#">伸缩雨伞桶，车载雨伞收纳桶收纳盒</a></div><div class="row row2">该产品的简述该产品的简述该产品的简述该产品的简述该产品的简述该产品的简述该产品的简述该产品的简述</div><div class="row row3 clearfix"><div class="zt1"><a href="javascript:;" class="gotoShopCar" title="加入购物车">加入购物车</a><del>$577.80</del> <strong class="color">$288.98</strong></div></div><div class="row row4 clearfix"><div class="zt1"><div class="jdt"><span style="width:50%"></span></div><span class="fr">还剩30天</span> <span class="fl">预售:88件</span> <span class="color">预售中</span></div></div><i class="hot"></i></div></div>'
                    html = zt1
                    $minUl = getMinUl();
                    $minUl.append(html);
                }
            }
            loadMeinv();
            //无限加载
            $(window).on("scroll", function () {
                $minUl = getMinUl();
                if ($minUl.height() <= $(window).scrollTop() + $(window).height()) {
                    //如果要鼠标滚动就加载，
                    //loadMeinv();//加载新图片
                }
            })
            function getMinUl() {
                var $arrUl = $("#mainsrp-itemlist .items");
                var $minUl = $arrUl.eq(0);
                $arrUl.each(function (index, elem) {
                    if ($(elem).height() < $minUl.height()) {
                        $minUl = $(elem);
                    }
                });
                return $minUl;
            }
            //点击更多加载
            $("#down-more").click(function () {
                $minUl = getMinUl();
                loadMeinv();
                return false;
            });

        })
    </script>

    <script type="text/javascript">
        var colorArea = '<%=_jsonRuleAndColor %>';
    </script>

     <%-- 分享弹出ydf--%>
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
                        <% // include all share method  %>        
                        <!--#include file="../include/sharemethod.inc" -->
                      </div>                  
                    <a href="#" style="display:none;" class="share-media-set">Share Binding setting</a>
                </div>
                <div class="ps clearfix">
                    <span class="fr"><a href="#"></a></span><span class="fl">You will earn <span id="sharePercent"></span> commission when your friend  makes a purchase from your shared link. </span>
                </div>
            </div>         
        </div>
    </div> 
     <script>
         //关闭弹出框
         $('.closeBtn,.iagree').click(function (event) {
             var obj2 = $(this).parents(".tck")
             obj2.animate({
                 top: "-500px"
             },
				300, function () {
				    obj2.parents(".greybox").hide()

				});
             return false;
         });
    </script>
</asp:Content>
