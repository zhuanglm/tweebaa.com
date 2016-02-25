<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="saleBuy.aspx.cs" Inherits="TweebaaWebApp.Product.saleBuy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="../Css/buyall.css?v=<%=_sCurVer%>" />
    <link rel="stylesheet" href="../Css/sale-page.css?v=<%=_sCurVer%>" />
    <link href="../Css/shareBox.css?v=<%=_sCurVer%>" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Js/zhutu.js?v=<%=_sCurVer%>"></script>
    <script src="../Js/swfobject.js?v=<%=_sCurVer%>" type="text/javascript"></script>
    <script src="../MethodJs/videoPlay.js?v=<%=_sCurVer%>" type="text/javascript"></script>
    <script src="../MethodJs/favorite.js?v=<%=_sCurVer%>" type="text/javascript"></script>
    <script src="../MethodJs/saleBuy.js?v=<%=_sCurVer%>" type="text/javascript"></script>
    <script src="../MethodJs/share.js?v=<%=_sCurVer%>" type="text/javascript"></script>
    <script src="../MethodJs/VisitTimer.js?v=<%=_sCurVer%>" type="text/javascript"></script>
    <style type="text/css">
      .selectColor{cursor:pointer; width:21px; height:21px; padding-bottom:1px; padding-top:2px; float:left;}/*  padding-left:2px; padding-right:1px; margin-right:5px;*/
      .selectColor div{width:20px;height:20px; background:red; margin:0 auto;}
    </style> 
   <%-- <script src="../MethodJs/prdCate.js" type="text/javascript"></script>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <input type="hidden" id="hid_proid" value="<%=_proid %>" />
    <input type="hidden" id="hiduserid" value="<%=_userid %>" />
   
    <div class="h10">
    </div>
    <!-- select 筛选 -->
    <div class="w964" style="display:none;">
        <div id="selectnav" class="clearfix">
            <div class="select1 fl pr bdccc">
                <h1> 
                    Category</h1>
                <div class="select1-nav bdccc">
                    <em class="sjx"></em>
                    <ul>
                       
                    </ul>
                </div>
            </div>
            <div class="select-search bdccc fl">
                <input type="text" class="txt" placeholder="Please enter product name and keyword" />
                <div class="select2 fr bdccc pr">
                    <h2 s-data="0">
                        By Category
                    </h2>
                    <ul class="select2-nav bdccc">
                        <li><a href="#" s-data="1">宠物用品</a> </li>
                        <li><a href="#" s-data="2">园艺用品</a> </li>
                        <li><a href="#" s-data="3">厨房收纳</a> </li>
                        <li><a href="#" s-data="4">居家日用</a> </li>
                        <li><a href="#" s-data="5">科技产品</a> </li>
                        <li><a href="#" s-data="6">户外探险</a> </li>
                        <li><a href="#" s-data="7">运动健身</a> </li>
                        <li><a href="#" s-data="8">节日商品</a> </li>
                    </ul>
                </div>
            </div>
            <div class="search-button fl">
                <button class="btn-search" type="submit">
                </button>
            </div>
        </div>
    </div>
    <!-- select 筛选 -->
    <div class="pingshen-main" id="sale-page">
        <div class="w975 mbx">          
            <a href="#">Homepage</a> > <a href="prdSale.aspx?step=3">Buy Now</a> > <a href="" style=" display:none;"><label id="labCateTile"></label></a> <%-->--%> <b class="l">Product Details</b>
        </div>
        <div class="w975 pingshen-box">
            <!-- 产品描述 -->
            <div class="title">
                <a href="#" id="htrfShare" class="yellow-share fr">Share & Earn</a>               
                <h1 class="fl">
                    <strong>
                        <label itemprop="name" id="pro-name"><% = HttpUtility.HtmlEncode(_model.name) %>
                        </label>
                    </strong>
                </h1>
                <span class="fl subtime">
                    <label id="pro-time" style="display:none;">
                    </label>
                </span>
            </div>
            <div class="des-box clearfix">
                <!-- 描述 -->
                <div class="product-des fr">
                    <div class="des-txt">
                        <div>
                            <%--<strong class="fb">Product features： </strong> --%><label itemprop="description" id="pro-jl"><% = HttpUtility.HtmlEncode(_model.txtjj) %>
                        </label>
                          <div class="h22"></div>
                          <% // MSRP will be displayed only when estimate price is not same as sale price %>
                        <div id="divMSRP" style="display:none"><font size="5" ><del><label>MSRP: $<% =Math.Round((decimal)_model.estimateprice,2).ToString() %></label></del></font></div>

                        </div>
                        <div>
                            <%--<strong class="fb" id="title-Solution">Solution： </strong>--%><label id="pro-question"></label>
                        </div>
                    </div>
                   
                    <div class="sold-infor clearfix">
                        <div class="fr" style="display:none;">
                            <span class="sold-num"><label id="labSaleCount"></label><br />Purchases</span>
                            <span class="sold-pj">0<br />Comments</span>
                        </div>
                        <div style="margin-top:10px">Price <strong class="priceNumber">$<label id="pro-price" style="margin-top:10px;">
                            </label>
                        </strong></div>
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
                        <li>型号：三星S4 </li>
                        <li><span>材质:塑料 </span><i></i><span>重量:322G </span></li>
                        <li>制造国家:中国 </li>
                    </div>--%>
                    <div class="h22">
                    </div>
                    <!-- Size -->
                    <style type="text/css">
                                #fltemp span {
                                  margin-top:3px;
                                }
                                #proColorArea span {
                                    margin-top:3px;
                                }
                            </style>
                    <div class="guige fl" style="padding:2px; height:auto;">
                        <dl class="fl">
                            <dt class="fl"><%=_proRuleTitle %> </dt>
                            <dd class="fl" id="fltemp">
                               <%=_ruleName%>
                               <%-- <span class="jsclick">S </span>
                                <span class="jsclick">M </span>
                                <span class="jsclick"> L </span>--%>
                            </dd>
                        </dl>
                    </div>
                    <!-- Color -->
                    <div id="allColor" style=" display:none;">
                    <%=_allColor %>
                    </div>
                    <div class="color fl" style="padding:2px; height:auto;">
                        <dl class="fl" id="tcolor">
                            <dt class="fl">Color </dt>
                            <dd id="proColorArea" class="fl" selectedRuleid="" style="padding-top:2px;">
                            <%=_firstColor%>
                            <%--<div class="selectColor">
	                          <div style=" background:blue;"></div>
	                       </div>
                           <div class="selectColor">
	                          <div style=" background:blue;"></div>
	                       </div>--%>
                                
                            </dd>
                        </dl>
                    </div>
                    <div class="h22">
                    </div>
                    <!-- 购买Quantity -->
                    <div class="buyNumber">
                        <dl class="fl">
                            <dt class="fl">Quantity </dt>
                            <dd class="fl">
                                <span class="number pr">
                                    <input type="button" class="left-btn btn" value="-"  />
                                    <input type="button" class="right-btn btn" value="+"  />
                                    <input type="text" class="num tc" value="1" id="txtQuantity"  />
                                </span>
                            </dd>
                            <dd class="fl" style="display:none;">
                                <span class="kucun">（Stock <span id="storenumSpan"><%=_firstRuleStoreNum %></span> pcs） </span>
                            </dd>
                            <dd class="fl" style="display:none">
                                <a href="#" class="want-pifa">I want to supply</a>
                            </dd>
                        </dl>
                    </div>
                    <div class="h22">
                    </div>
                    <div class="btn-group clearfix">
                        <a href="javascript:void(0);" style="display:none;" class="now-buy" onclick="AddShopCartBuyNow()">Buy now</a> 
                        <a href="javascript:void(0);" class="join-car" onclick="AddShopCart()" >Add to Cart</a>
                        <% string favoriteClass = "sc";
                           if (_favorite) favoriteClass = "schover";
                        %>
                        <a href="#" id="linkFavorite" class="<% =favoriteClass %>" onclick="DoFavoritePrdOnOff('#linkFavorite');" >Favorite</a>
                        <a href="#" style="display:none;" class="download">Save to Store</a>
                    </div>
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
                    <a href="javascript:;">Details</a> 
                    
                    <a href="javascript:;" style="display:none;">Reviews(<label id="labReviewCount"></label>)</a>
                   
                </div>
            </div>
            <!-- tabCon -->
            <div class="tabCon">
                <div class="itembox">
                    <div class="tc">
                        <div class="video" id="CuPlayer" style="margin: 0 auto;">
                        </div>
                    </div>
                    <div class="tl" id="pro-info">
                    </div>
                </div>
                <div class="itembox">
                    <ul class="pinglun-list">
                      
                    </ul>
                    <div class="page tr">
                        <a href="#" class="up"><</a> <a href="#">1</a> <a href="#">2</a> <a href="#" class="on">
                            3</a> <a href="#">4</a> <a href="#">5</a> <a href="#">6</a> <a href="#">7</a>
                        <a href="#">8</a> <a href="#" class="down">></a>
                    </div>
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

    <!-- 无线加载js -->
    <script type="text/javascript">
        $(function () {
            //url data function dataType
            function loadMeinv() {

                for (var i = 0; i < 4; i++) {//每次加载4条信息
                    var html = "";

                    //以下是模拟信息
                    var html, zt1, zt2, zt3, zt4;
                    //zt1,zt2,zt3,zt4;对应产品的4中状态 
                    //zt1 预售中 //zt2 销售中 //zt3 预售成功 //zt4预售失败

                    //模拟信息结束
                    zt2 = '<div class="item sales-ing"><div class="box"><div class="pic-box"><a href="#" class="imglink"><img src="../Images/224x224.jpg" alt=""></a><div class="floatDiv"><a href="#" class="love" title="Favorite">Favorite</a> <a href="#" class="down" title="资料下载">资料下载</a> <a href="#" class="share" title="Share & Earn">Share & Earn</a></div></div><div class="row row1"><a href="#">伸缩雨伞桶，车载雨伞收纳桶收纳盒</a></div><div class="row row2">该产品的简述该产品的简述该产品的简述该产品的简述该产品的简述该产品的简述该产品的简述该产品的简述</div><div class="row row3 clearfix"><div class="zt2"><a href="javascript:;" class="gotoShopCar" title="加入购物车">加入购物车</a> <strong class="color">$288.98</strong></div></div><div class="row row4 clearfix"><div class="zt2"><span class="fr"><a href="javascript:;" class="loveNumber" title="喜欢">100</a></span> <span class="fl">已售：100件</span> <span class="color">销售中</span></div></div></div></div>'
                    html = zt2
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
        //正整数
        function isPInt(str) {
            var g = /^[1-9]*[1-9][0-9]*$/;
            return g.test(str);
        }

        var priceArea = '<%=_jsonRuleAndPrice %>';
        var colorArea = '<%=_jsonRuleAndColor %>';
        var storage = '<%=_jsonRuleAndStorag %>';
        var priceMin = '<%=_jsonpriceMin %>';



//        function changeColor(rulespan) {
//            var ruleid = $(rulespan).attr("ruleid");
//            $("#proColorArea").html("");
//            $("#allColor").find("span[ruleid='" + ruleid + "']").clone().appendTo($("#proColorArea"));
//            var store = 0;
//            $("#allColor").find("span[ruleid='" + ruleid + "']").each(function () {
//                var storenum = $(this).attr("storenum");
//                store += parseInt(storenum);
//            });
//            $("#storenumSpan").html(store);
//        }


        $(function () {

            var objNumberBox = $(".number")

            objNumberBox.each(function (index, el) {
                var reduceNumber = $(this).find(".left-btn")
                var addNumber = $(this).find(".right-btn")
                var objNumber = $(this).find(".num")

                objNumber.keyup(function (event) {
                    this.value = this.value.replace(/\D/g, '');
                    if (!isPInt(this.value)) {
                        //alert('请输入正整数');
                        this.value = 1;
                    }
                }).change(function (event) {
                    this.value = this.value.replace(/\D/g, '')
                    if (!isPInt(this.value)) {
                        //alert('请输入正整数');
                        this.value = 1;
                    } else {
                        this.value = parseInt(this.value);
                        changePrice(this.value);
                    }
                });

                // 增加
                addNumber.click(function () {
                    objNumber.val(parseInt(objNumber.val()) + 1);
                    var count = objNumber.val();
                    changePrice(count);
                })
                reduceNumber.click(function () {
                    objNumber.val(parseInt(objNumber.val()) - 1);
                    if (parseInt(objNumber.val()) < 1) {
                        objNumber.val(1)
                    };
                    var count = objNumber.val();
                    changePrice(count);
                })

            });
            //加入购物车
            $(".gotoCar").click(function (event) {
                $(".car").text(parseInt($(".car").text()) + 1)
                objBig.eq(isnow).css({ zIndex: '10' }).fadeTo('400', 1).siblings('li').fadeTo('400', 0).css({ zIndex: '1' });
            });

        })
    </script>

     <%-- 分享弹出ydf--%>
    <div class="greybox">
        <div id="share-tck2" class="tck">
                <a href="#" class="closeBtn" title="Close"></a>
                    <h2 class="t">
                <span>Share & Earn</span>
                      </h2>
                <div class="box" >  
                    <div class="sharebox clearfix my-dietu">
                        <span class="fl t ">Share to </span>
                        <div class="bdsharebuttonbox fl">                                  
                        <% // include all share method  %>        
                        <!--#include file="../include/sharemethod.inc" -->
                       </div>                  
                       <a href="#" style="display:none;" class="share-media-set">Share Binding setting</a>
                    </div>
                <div>
                <div class="ps clearfix">
                    <span class="fr"><a href="#"></a></span><span class="fl">&nbsp;&nbsp;&nbsp;&nbsp;You will earn <span id="sharePercent"></span> commission when your friend  makes a purchase from your shared link. </span>
                </div>

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
