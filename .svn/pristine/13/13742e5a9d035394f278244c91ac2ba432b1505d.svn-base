<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="saleBuy.aspx.cs" Inherits="TweebaaWebApp2.Product.saleBuy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

<%=sMetaTag%>

    <link rel="stylesheet" href="/css/buyall.css" />
    <link rel="stylesheet" href="/css/sale-page.css" />
    <link href="/css/shareBox.css" rel="stylesheet" type="text/css" />
  <!--  <script type="text/javascript" src="../js/zhutu.js"></script> 
    <script src="/js/swfobject.js" type="text/javascript"></script>
  <script src="/MethodJs/videoPlay.js" type="text/javascript"></script> -->
    <script src="/MethodJs/favorite.js" type="text/javascript"></script>

    <script src="/MethodJs/share.js?v=2016020422" type="text/javascript"></script>
    <script src="/MethodJs/VisitTimer.js" type="text/javascript"></script>

     <script src="/MethodJs/Product_May_like.js" type="text/javascript"></script>
     <script src="/MethodJs/ExtraShipping.js" type="text/javascript"></script>
     <script src="/js/forms/product-quantity.js" type="text/javascript"></script>

     <link rel="stylesheet" href="/plugins/master-slider/quick-start/masterslider/style/masterslider.css">
    <link rel='stylesheet' href="/plugins/master-slider/quick-start/masterslider/skins/default/style.css">

    <style>
    #pro-info ul li
    {
        list-style-type: disc;
    }
    #tabDetails label
    {
        font-weight:normal;
    }
    #divResponsiveVideo
    {
        padding-bottom:60% !important;
    }
    .product-size li
    {
        padding-left:0px !important;
    }
    #pro-info{
		background-color:#ffffff;
		padding:20px;
	}
    </style>

<% if (MobileBrowserFlag == 1)
   { %>

    <style>
        #tweebot_video_iframe
        {
            width:100% !important;
        }
        #pro-info img
        {
            width:100% !important;
        }
     </style>
<%} %>
<!--Start of Zopim Live Chat Script-->
<script type="text/javascript">
    window.$zopim || (function (d, s) {
        var z = $zopim = function (c) { z._.push(c) }, $ = z.s =
d.createElement(s), e = d.getElementsByTagName(s)[0]; z.set = function (o) {
    z.set.
_.push(o)
}; z._ = []; z.set._ = []; $.async = !0; $.setAttribute("charset", "utf-8");
        $.src = "//v2.zopim.com/?3SkhL2CFelNy1xITHgs9PrwP0JnHNM52"; z.t = +new Date; $.
type = "text/javascript"; e.parentNode.insertBefore($, e)
    })(document, "script");
</script>
<!--End of Zopim Live Chat Script-->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

<input type="hidden" name="product_id" id="product_id" value="<%=_proid %>" />
<input type="hidden" name="product_id" id="category_id" value="<%=_model.cateGuid %>" />
<input type="hidden" name="userid" id="userid" value="<%=_userid %>" />
    <div class="wrapper">
        <!--=== Breadcrumbs ===-->
        <div class="breadcrumbs">
            <div class="container">
                <h1 class="pull-left">
                    Product Details</h1>
                <ul class="pull-right breadcrumb">
                    <li><a href="../index.aspx">Home</a></li>
                    <li><a href="/Product/ShopIndex.aspx">Shop</a></li>
                    <%=strCategoryLink%>
                    
                    
                </ul>
            </div>
            <!--/container-->
        </div>
        <!--/breadcrumbs-->
        <!--=== End Breadcrumbs ===-->
        <!--=== Shop Product ===-->
        <div class="shop-product">
            <div class="container">
                <div class="row">
                    <div class="col-md-6 md-margin-bottom-50">
                        <div class="ms-showcase2-template">
                            <!-- Master Slider -->
                            <div class="master-slider ms-skin-default" id="masterslider">
                                <%= strMasterSliders%>	                          													                              					
                            </div>
                            <!-- End Master Slider -->
                        </div>
				      <div class="row">
                        <div class="margin-top-20 col-md-5 whvideo" id="linkWatchVideo">
                       <button class="btn-u rounded-4x btn-u-dark btn-u-lg" type="button"  data-toggle="modal" data-target="#ModalVideo"><i class="fa fa-youtube-play"></i>  Watch Video </button>
              
                
                    </div></div>
                    </div>
                    <div class="col-md-6">
                        <div class="shop-product-heading">
                            <h2>
                                 <label itemprop="name" id="pro-name"><% = HttpUtility.HtmlEncode(_model.name) %>
                        </label></h2>

<% if (_proid.Length >= 36 && _proid.Substring(0, 36) == "670bdf26-a935-4643-ac0e-ba24c2249107")
   { %>
                                 <div>
                                    <button onclick="window.open('/tweebot/tutorial')" class="btn-u btn-u-lg rounded-4x btn-block btn-u-blue" type="button"><i class="fa fa-book"></i>  <strong>Learn more!  TweeBot FAQ, Video tutorial, Manual </strong></button>
                                 </div><br />
<%} %>
                          
                        </div>
                        
                        
                        <ul class="list-inline product-ratings margin-bottom-10">
                        <li>
                        <ul class="list-inline product-ratings" id="ulRating"></ul>
                        </li>


                        <li class="product-review-list">
                            <span>SKU#: <label id="divTweebaaSKU"></label></span>
                        </li>
                    </ul><!--/end shop product ratings-->

                        
                        <ul class="list-inline shop-product-prices margin-bottom-10">
                            <li class="shop-grey">$<label id="pro-price"></label></li>
                            <li class="line-through"><div id="divEstimatePrice" style="display:none">$<% =Math.Round((decimal)_model.estimateprice,2).ToString() %></div></li>
                            <% decimal dPercentOff = (1 -  (decimal)_model.saleprice / (decimal)_model.estimateprice ) * 100; %>
                            <li class="shop-grey"><div id="divPercentOff" style="display:none; font-size:medium">( <% =Math.Round(dPercentOff, 0).ToString()%>% off )</div></li>
                            <% // products in sale status do not need display pre-sale information %>
                            
                        </ul>
                        <div class="margin-bottom-10" style="padding-bottom:10px;"><i class="fa fa-money"></i> Earn <%=_model.saleprice %> Tweebaa Shopping Points   </div>
                        <%
                            string sDisplaySpecName = "display:block";
                            string sDisplaySpecColor = "display:block";
                            if (_model.DisplaySpecName  == 0) sDisplaySpecName  = "display:none";
                            if (_model.DisplaySpecColor == 0) sDisplaySpecColor = "display:none";
                            
                         %>
                        <div style="<%=sDisplaySpecName%>">
                          <h3 ><%=_proRuleTitle %></h3>
                          <ul class="list-inline product-size margin-bottom-10" style="margin-top: -6px;<% =_sRuleNameDisplayStyle %>">
                                        <%=_ruleName%>
                           </ul>
                         </div>
                        <!--/end product size-->
                        <div style="<%=sDisplaySpecColor%>">
                          <h3  >
                            Color</h3>
                          <ul class="list-inline product-color margin-bottom-10" style="margin-top: -6px;" id="proColorArea">
                            <%=_firstColor%>
                            <%--<li>
                                <input type="radio" id="color-1" name="color">
                                <label class="color-one" for="color-1">
                                </label>
                            </li>
                            <li>
                                <input type="radio" id="color-2" name="color" checked>
                                <label class="color-two" for="color-2">
                                </label>
                            </li>
                            <li>
                                <input type="radio" id="color-3" name="color">
                                <label class="color-three" for="color-3">
                                </label>
                            </li>--%>
                          </ul>
                        </div>
                        <!--/end product color-->
                        <h3 >
                            Quantity</h3>
                        <div class="margin-bottom-40" style="margin-top: -6px;">
                            <form name="f1" class="product-quantity sm-margin-bottom-20">
                            <button type='button' class="quantity-button" name='subtract' onclick='javascript: subtractQty();'
                                value='-' id="btnLeft">
                                -</button>
                            <input type="text" class="quantity-field" name="qty" value="1" id="qty" maxlength=3 />
                            <button type="button" class="quantity-button" name="add" onclick="javascript: AddQty();"
                                value="+" id="btnRight">
                                +</button>
                            </form>                            
                            <button type="button" class="btn-u-lg-shop rounded-4x" onclick="AddShopCart()" >
                                Add to Cart</button>
                                <button type="button" class="btn-u-lg-share rounded-4x" id="btnShareAndEarn" >
                                Share & Earn</button>
                        </div>
                        <!--/end product quantity-->
                        <ul class="list-inline add-to-wishlist add-to-wishlist-brd">
                         <% string favoriteHeart = "fa-heart-o";
                            if (_favorite) favoriteHeart = "fa-heart";
                        %>
                            <li class="wishlist-in"><i id="classFavorite" class="fa <% =favoriteHeart %>"></i>
                            <!--
                            <a href="#">Add to Wishlist</a>
                            -->
                        <a href="#" id="linkFavorite" onclick="DoFavoritePrdOnOff('#classFavorite');" >Favorite</a>
                            </li>

                            <!--
                            <li class="compare-in"><i class="fa fa-share-alt"></i>
                            <a href="#" id="htrfShare">Share & Earn</a> 
                           

                            </li> 
                            <li>
                        <span class="label"> 
                      <a href="/College/sharer_commission.aspx" target="_blank"><span class="share"> Share & Earn</span> <span class="earn">Up to 10% commmission</span></a> </span>
                          
                        </li> -->

                        </ul>

                     <div class="tab-v2s">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tabDetails" data-toggle="tab">Details</a></li>
                        <!--    <li><a href="#tabRules" data-toggle="tab"><%=_proRuleTitle %></a></li> -->
                            <li><a href="#tabShipping" data-toggle="tab">Shipping</a></li>
                       
                        </ul>                
                        <div class="tab-content">
                            <div class="tab-pane fade in active" id="tabDetails">
                                 <label  id="pro-jl"><% = HttpUtility.HtmlEncode(_model.txtjj) %>  </label>
                                 <label itemprop="description" id="lblShareText" style="visibility:hidden">
                                 Like this item? If you purchase through this SPECIAL OFFER , you will earn BONUS <%=iRewardPoint%> SHOPPING REWARD POINTS!
                                 </label>

                            </div>
                            <!--
                            <div class="tab-pane fade in" id="tabRules">
                                 <ul class="list-inline product-size margin-bottom-30">
                                        <%=_ruleName%>
                                 </ul>
                            </div> -->
                            <div class="tab-pane fade in" id="tabShipping">
                                <div id="divShipToCountires"></div> 
                            </div>
                        </div>
                    </div>
                        <!--
                        <p class="wishlist-category">=
                            <strong>Categories:</strong> <a href="#">Clothing,</a> <a href="#">Shoes</a></p>
                            -->
                    </div>
                </div>
                <!--/end row-->
            </div>
        </div>
        <!--=== End Shop Product ===-->
        <!--=== Content Medium ===-->
        <div class="content-md container">
            <div class="tab-v5">
                <ul class="nav nav-tabs" role="tablist">
                    <li class="active"><a href="#description" role="tab" data-toggle="tab">Description</a></li>
                    <li><a href="#reviews" role="tab" data-toggle="tab">Reviews (<label id="comment_count"></label>)</a></li> 
                </ul>
                <div class="tab-content">
                    <!-- Description -->
                    <div class="tab-pane fade in active" id="description">
                        <div class="col-md-12" style="height:auto">
                            <div class="row" id="pro-info" >
                            <% =_model.txtinfo %>
                            </div>
                        </div>
                     <!--
                         <div id="divVideo" class="col-md-5" style="float:left; clear:both; margin-top:10px">
                            <div class="shop-details-video">
                 
                        
                        <div class="video" id="CuPlayer" style="margin: 0 auto;">
                        </div>
                            </div>
                            </div>
                          -->
                    </div>
                    <!-- End Description -->
                    <!-- Reviews -->
                    <div class="tab-pane fade" id="reviews">
                        <div class="product-comment margin-bottom-40">
                            <div class="product-comment-in">
                             <!--   <img class="product-comment-img rounded-x" src="../images/team/01.jpg" alt=""> -->
                                <div class="product-comment-dtl" id="ulCommentsList">
                                </div>
                                <div class="page tr" id="CommentsPage">
				                </div>
                            </div>
                        </div>

<% if (_userid.Length < 10)
   { %>
                        <div>
                        <a href="/User/Login.aspx?op=saleBuy&id=<%=_proid %>">Write a Review</a>
                        </div>
<%}
   else
   { %>
                        <div>
                        <h3 class="heading-md margin-bottom-30">
                            Add a review</h3>
                        <form 
                        method="post" id="frmSubmitReview" class="sky-form sky-changes-4">
                        <fieldset>
                        <!--
                            <div class="margin-bottom-30">
                                <label class="label-v2">
                                    Name</label>
                                <label class="input">
                                    <input type="text" name="name" id="name">
                                </label>
                            </div>
                            <div class="margin-bottom-30">
                                <label class="label-v2">
                                    Email</label>
                                <label class="input">
                                    <input type="email" name="email" id="email">
                                </label>
                            </div> -->
                            <div class="margin-bottom-30">
                                <label class="label-v2">
                                    Review</label>
                                <label class="textarea">
                                    <textarea rows="7" name="txtComments" id="txtComments"></textarea>
                                </label>
                            </div>
                        </fieldset>
                        <footer class="review-submit">
                            <label class="label-v2">Review</label>
                            <div class="stars-ratings">
                                <input type="radio" value="5" name="stars-rating" id="stars-rating-5">
                                <label for="stars-rating-5"><i class="fa fa-star"></i></label>
                                <input type="radio" value="4" name="stars-rating" id="stars-rating-4">
                                <label for="stars-rating-4"><i class="fa fa-star"></i></label>
                                <input type="radio" value="3" name="stars-rating" id="stars-rating-3">
                                <label for="stars-rating-3"><i class="fa fa-star"></i></label>
                                <input type="radio" value="2" name="stars-rating" id="stars-rating-2">
                                <label for="stars-rating-2"><i class="fa fa-star"></i></label>
                                <input type="radio" value="1" name="stars-rating" id="stars-rating-1">
                                <label for="stars-rating-1"><i class="fa fa-star"></i></label>
                            </div>
                            <button type="button" id="btnPostComment" onclick="write_comments();return false;" class="btn-u btn-u-sm btn-u-red pull-right">Submit</button>
                        </footer>
                        </form>
                        </div>
<%} %>

                    </div>
                    <!-- End Reviews -->
                </div>
            </div>
        </div>
        <!--=== Illustration v2 ===-->
        <div class="container">
            <div class="illustration-v2 margin-bottom-60">
                <div class="customNavigation margin-bottom-25">
                    <a class="owl-btn prev rounded-x"><i class="fa fa-angle-left"></i></a>
                    <span style="font-size:20px;padding:0px 10px;">Product you may like</span>
                    <a class="owl-btn next rounded-x">
                        <i class="fa fa-angle-right"></i></a>
                </div>
                <ul class="list-inline owl-slider-v4" id="prd_may_like_listings">
                <script type="text/javascript">
                    // Load_Product_May_like();
                    var cate_id = $("#category_id").val();
                    Load_Product_May_like_in_category(cate_id);
                </script>
<!--
                    <li class="item"><a href="#">
                        <img class="img-responsive" src="../images/thumb/09.jpg" alt=""></a>
                        <div class="product-description-v2">
                            <div class="margin-bottom-5">
                                <h4 class="title-price">
                                    <a href="#">Double-breasted</a></h4>
                                <span class="title-price">$95.00</span>
                            </div>
                            <ul class="list-inline product-ratings">
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating fa fa-star"></i></li>
                                <li><i class="rating fa fa-star"></i></li>
                            </ul>
                        </div>
                    </li>
                    <li class="item"><a href="#">
                        <img class="img-responsive" src="../images/thumb/07.jpg" alt=""></a>
                        <div class="product-description-v2">
                            <div class="margin-bottom-5">
                                <h4 class="title-price">
                                    <a href="#">Double-breasted</a></h4>
                                <span class="title-price">$60.00</span> <span class="title-price line-through">$95.00</span>
                            </div>
                            <ul class="list-inline product-ratings">
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating fa fa-star"></i></li>
                                <li><i class="rating fa fa-star"></i></li>
                            </ul>
                        </div>
                    </li>
                    <li class="item"><a href="#">
                        <img class="img-responsive" src="../images/thumb/08.jpg" alt=""></a>
                        <div class="product-description-v2">
                            <div class="margin-bottom-5">
                                <h4 class="title-price">
                                    <a href="#">Double-breasted</a></h4>
                                <span class="title-price">$95.00</span>
                            </div>
                            <ul class="list-inline product-ratings">
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating fa fa-star"></i></li>
                                <li><i class="rating fa fa-star"></i></li>
                            </ul>
                        </div>
                    </li>
                    <li class="item"><a href="#">
                        <img class="img-responsive" src="../images/thumb/06.jpg" alt=""></a>
                        <div class="product-description-v2">
                            <div class="margin-bottom-5">
                                <h4 class="title-price">
                                    <a href="#">Double-breasted</a></h4>
                                <span class="title-price">$95.00</span>
                            </div>
                            <ul class="list-inline product-ratings">
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating fa fa-star"></i></li>
                                <li><i class="rating fa fa-star"></i></li>
                            </ul>
                        </div>
                    </li>
                    <li class="item"><a href="#">
                        <img class="img-responsive" src="../images/thumb/04.jpg" alt=""></a>
                        <div class="product-description-v2">
                            <div class="margin-bottom-5">
                                <h4 class="title-price">
                                    <a href="#">Double-breasted</a></h4>
                                <span class="title-price">$95.00</span>
                            </div>
                            <ul class="list-inline product-ratings">
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating fa fa-star"></i></li>
                                <li><i class="rating fa fa-star"></i></li>
                            </ul>
                        </div>
                    </li>
                    <li class="item"><a href="#">
                        <img class="img-responsive" src="../images/thumb/03.jpg" alt=""></a>
                        <div class="product-description-v2">
                            <div class="margin-bottom-5">
                                <h4 class="title-price">
                                    <a href="#">Double-breasted</a></h4>
                                <span class="title-price">$95.00</span>
                            </div>
                            <ul class="list-inline product-ratings">
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating-selected fa fa-star"></i></li>
                                <li><i class="rating fa fa-star"></i></li>
                                <li><i class="rating fa fa-star"></i></li>
                            </ul>
                        </div>
                    </li>
-->
                </ul>
            </div>
        </div>
        <!--=== End Illustration v2 ===-->
       
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
         var imageRuleID = '<%=_jsonImageRuleID %>';
    
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
             var reduceNumber = $("#btnLeft");
             var addNumber = $("#btnRight");
             var objNumber = $("#qty");

             objNumber.keyup(function (event) {
                 this.value = this.value.replace(/\D/g, '');
                 if (!isPInt(this.value)) {
                     //alert('请输入正整数');
                     this.value = 1;
                 }
                 // alert(this.value);
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
                 if (parseInt(objNumber.val()) >= 999) {
                     objNumber.val(999);
                 };
                 var count = objNumber.val();
                 changePrice(count);
             })
             reduceNumber.click(function () {
                 objNumber.val(parseInt(objNumber.val()) - 1);
                 if (parseInt(objNumber.val()) < 1) {
                     objNumber.val(1);
                 };
                 var count = objNumber.val();
                 changePrice(count);
             })

             //加入购物车
             $(".gotoCar").click(function (event) {
                 $(".car").text(parseInt($(".car").text()) + 1)
                 objBig.eq(isnow).css({ zIndex: '10' }).fadeTo('400', 1).siblings('li').fadeTo('400', 0).css({ zIndex: '1' });
             });

         })
    </script>

<!-- Master Slider -->
<script src="/plugins/master-slider/quick-start/masterslider/masterslider.min.js"></script>
<script src="/plugins/master-slider/quick-start/masterslider/jquery.easing.min.js"></script>
<script src="/js/plugins/master-slider.js"></script>

<script type="text/javascript">
    var iPageDiv = 20;
    $(document).ready(function () {

        // set loging href 
        //$("#hrefLogin").attr("href", document.location.origin + "/user/login.aspx");

        var Request = new Object();
        Request = GetRequest();
        //

        var action = Request["action"];
        if (action != undefined) {
            console.log("action=" + action);
            /*
            if (action.toLowerCase() == "buynow") {
                AddShopCart();

            }*/

        }

        LoadCommentsTotal();

    }); 

 function write_comments() {
        var PrdID = $("#product_id").val();
        var UserID = $("#userid").val();
        var txtComments = $("#txtComments").val();
        var rating = $('input[name="stars-rating"]:checked', '#frmSubmitReview').val(); 
        
        if(txtComments.Length<0){
            alert("Please Write Your comments");
            return
        }
        if(rating==undefined){
            alert("Please Choose A Rate");
            return
        }

        $.ajax({
            type: "POST",
            url: "/AjaxPages/prdSaleAjax.aspx",
            data: "{ 'Comments':'" + escapeHtml(txtComments)
                + "','action':'" + "addRating"
                + "','UserGuid':'" + UserID
                + "','PrdGuid':'" + PrdID
                + "','Rating':'" + rating
                + "'}"
        }).done(function (o) {
            console.log('saved:' + o);
            if (parseInt(o) == 1) {
                $("#txtComments").val("Your Comments Saved");
                limitTime = 20;
                limitComment();
                LoadCommentsTotal();
            }else{
                alert("Sorry, something wrong, please check your comments!");
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
            var PrdID = $("#product_id").val();
            $.ajax({
                type: "POST",
                url: "/AjaxPages/prdSaleAjax.aspx",
                data: "{ 'action':'" + "load_comment_total"
                + "','PrdGuid':'" + PrdID
                + "'}"
            }).done(function (result) {
                
                var ss=result.split(":");
                var stotal = ss[0];
                var TotalRate = ss[1];
                var Ranking =0;
                if(stotal>0){
                  Ranking= Math.floor(TotalRate / stotal);
                }
                /////////////////////
                //show ranking
                var htmlRanking="";
                for(kk=0; kk<Ranking;kk++){
                    htmlRanking+='<li><i class="rating-selected fa fa-star"></i></li>';
                }
                if(Ranking < 5){
                    for(kk=Ranking;kk<5;kk++){
                        htmlRanking+='<li><i class="rating fa fa-star"></i></li>'; 
                    }
                }
                if(stotal > 0){
                    htmlRanking+='<li style="padding-left:20px;padding-right:20px;"><a href="javascript:void(0)" onclick="Jump2Reviews()">Total Reviews: '+stotal+'</a></li>';
                }
                $("#ulRating").html(htmlRanking);
                //console.log("total=" + stotal);
                var iTotal = Math.ceil(stotal / iPageDiv);
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
                if (iTotal > 0) {
                    $("#CommentsPage").html(html);
                    LoadComments(1);
                }
                $("#comment_count").html(stotal);
                //load first page
                

            });
        }

        function CommentPageNavigate(iPage) {
            $("#CN_" + iPrevPageMyDraft).removeClass("on");
            LoadComments(iPage);
            $("#CN_" + iPage).addClass("on");
            iPrevPageMyDraft = iPage;
        }
        function LoadComments(iPage) {
            var PrdID = $("#product_id").val();
            $.ajax({
                type: "POST",
                url: "/AjaxPages/prdSaleAjax.aspx",
                data: "{'action':'" + "load_Comments_By_Page"
                + "','PrdGuid':'" + PrdID
                + "','page':'" + iPage
                + "','pageDiv':'" + iPageDiv
                + "'}",
            }).done(function (resu) {
                var html = "";
                if (resu == "0" || resu == "") {
                    return;
                }
                var obj = eval("(" + resu + ")");
                for (var i = 0; i < obj.length; i++) {
                    var comments = obj[i];


                    //var sID = $(this).find('ID').text();
                    var comments_text = comments.Comments;//').text();
                    var user_name = comments.username;
                    var CreateTime = comments.AddDate;
                    var Rating = comments.Rates;
                    // var timesince = timeSince(CreateTime);
/*
                    html += '<div class="product-comment-dtl">';
                    html += '<h4>' + user_name + '<small>' + CreateTime + '</small></h4>';
                    html += '<p>' + comments_text + '</p>';

                    html += '</div>';
*/

                     html += '<div class="product-comment-in">';
                     html += '<div class="product-comment-dtl">';
                     html += '<h4>'+user_name+' <small>'+CreateTime+'</small></h4>';
                     html += '<p>'+comments_text+'</p>';
                     html += '<ul class="list-inline product-ratings">';
                     html += '<li class="pull-right">';
                     html += '<ul class="list-inline">';
                     for(k=0;k<Rating;k++){
                         html += '<li><i class="rating-selected fa fa-star"></i></li>';
                     }
                     if(Rating <5){
                       for(k=Rating;k<5;k++){
                         html += '<li><i class="rating fa fa-star"></i></li>';
                        }
                     }

                     html += '</ul>';
                     html += '</li>';   
                     html += '</ul>';
                     html += '</div>';
                     html += '</div>';    
                    //console.log("html=" + html);
                }
                $("#ulCommentsList").html(html);
            });

        }

        function formatDate(date) {
            var year = date.getFullYear(),
                month = date.getMonth() + 1, // months are zero indexed
                day = date.getDate(),
                hour = date.getHours(),
                minute = date.getMinutes(),
                second = date.getSeconds(),
                hourFormatted = hour % 12 || 12, // hour returned in 24 hour format
                minuteFormatted = minute < 10 ? "0" + minute : minute,
                morning = hour < 12 ? "am" : "pm";

            return month + "/" + day + "/" + year + " " + hourFormatted + ":" +
                    minuteFormatted + morning;
        }

        function Jump2Reviews(){
             $('html, body').animate({
                    scrollTop: $("#reviews").offset().top
                }, 200);
            $("#description").removeClass("active");
            $("#description").removeClass("in");
            $("#reviews").addClass("in");
            $("#reviews").addClass("active");
        }
        function PauseVideo() {
            $('#divResponsiveVideo').find('video').each(function () {
                this.currentTime = 0;
                this.pause();
            });
        }
 </script> 



<div class="modal fade" style="top:50px;" id="ModalVideo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
            <div class="modal-dialog" style="width:600px;">
                <div class="modal-content">
                    <div class="modal-header">
                        <button aria-hidden="true" data-dismiss="modal" class="close" type="button" onclick="PauseVideo();">×</button>
                        <h4 id="myModalLabel" class="modal-title">Watch Video</h4>
                    </div>
                    <div class="modal-body">
                             
<div class="responsive-video" id="divResponsiveVideo">
<%=strVideoCode%>
<!--
    <iframe id="frmVideo" src="/Product/HomeVideo.aspx" width="840" height="400" frameborder="0" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>
    -->
</div>
                                     
                    </div>
                                 
                    </div>
            </div>
</div>


    <script src="/MethodJs/saleBuy.js?v=20160119" type="text/javascript"></script>
    <script type="text/javascript">
        function playPause() {
            var myVideo = $("#prdVideo"); 
           // if (myVideo.paused)
            myVideo.get(0).play();
                /*
            else
                myVideo.pause();*/
        }
    </script>
</asp:Content>
