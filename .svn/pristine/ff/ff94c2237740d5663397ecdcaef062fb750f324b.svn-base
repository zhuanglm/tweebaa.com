<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ShopIndex.aspx.cs" Inherits="TweebaaWebApp2.Product.ShopIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

    <!-- CSS Implementing Plugins -->
    <link rel="stylesheet" href="/plugins/line-icons/line-icons.css">
    <link rel="stylesheet" href="/plugins/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="/plugins/scrollbar/src/perfect-scrollbar.css">
    <link rel="stylesheet" href="/plugins/owl-carousel/owl-carousel/owl.carousel.css">
    <link rel="stylesheet" href="/plugins/sky-forms/version-2.0.1/css/custom-sky-forms.css">
    <link rel="stylesheet" href="/plugins/master-slider/quick-start/masterslider/style/masterslider.css">
    <link rel="stylesheet" href="/plugins/master-slider/quick-start/masterslider/skins/default/style.css">
    <!-- CSS Page Style -->
  

    <!-- Style Switcher -->
    <link rel="stylesheet" href="/css/plugins/style-switcher.css">

    <!-- CSS Theme -->
    <link rel="stylesheet" href="/css/theme-colors/default.css" id="style_color">
     <link rel="stylesheet" href="/css/theme-skins/dark.css">

    <!-- CSS Customization -->
    <link rel="stylesheet" href="/css/custom.css">
    <style>
   	    .product-description .gender {
            height: 84px;
            overflow: hidden;
        } 
         .title-v1 h2,.heading h2
        {
            text-transform:capitalize;
        }
        .fa-heart{
			color: #ffbbbc;
		}  
		.product-description-brd
		{
		    height:120px !important;
		}
    </style>
      <script src="/MethodJs/share.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">


    <!--=== End Breadcrumbs v4 ===-->
 <!--=== Content Part ===-
     <div class="carousel slide carousel-v2 margin-bottom-40" id="portfolio-carousel">
                <ol class="carousel-indicators">
                    <li class="active rounded-x" data-target="#portfolio-carousel" data-slide-to="0"></li>
                    <li class="rounded-x" data-target="#portfolio-carousel" data-slide-to="1"></li>
                    <li class="rounded-x" data-target="#portfolio-carousel" data-slide-to="2"></li>
                </ol>
                
                <div class="carousel-inner">
                    <div class="item active">
                        <img class="full-width img-responsive" src="../images/head/tweebot3.jpg">
                    </div>
               <div class="item">
                        <img class="full-width img-responsive" src="../images/head/exerseat.jpg">
                    </div>
                    
                    <div class="item">
                        <img class="full-width img-responsive" src="../images/head/gazoos.jpg">
                    </div>
                </div>
                
                <a class="left carousel-control rounded-x" href="#portfolio-carousel" role="button" data-slide="prev">
                    <i class="fa fa-angle-left arrow-prev"></i>
                </a>
                <a class="right carousel-control rounded-x" href="#portfolio-carousel" role="button" data-slide="next">
                    <i class="fa fa-angle-right arrow-next"></i>
                </a>
            </div> -->
    <div class="content container">


            <div class="row margin-bottom-40 ">
         
                 <div class="col-sm-12">
                 <form id="frmSearch" action="/Product/prdSaleAll.aspx?action=search" method="post">
                 <div class="input-group">

                      <div class="input-group-btn" id="divCategoryDropdown">
                                        <button type="button" class="btn btn-danger dropdown-toggle" data-toggle="dropdown" onclick="ToggleButton()">
                                          <span id="spanCategorySelected">All Category</span> 
                                            <span class="caret"></span>
                                        </button>
                                        <ul class="dropdown-menu" role="menu">
                                            <li><a sort-data="1" href="#" onclick="ChangeCategory('-1','All Category');return false;">All Category</a></li>
                                            <li><a sort-data="2" href="#" onclick="ChangeCategory('1608AC1B-786A-4596-9DEE-04FC45131332','Electronics');return false;">Electronics</a></li>
                                            <li><a sort-data="3" href="#" onclick="ChangeCategory('3EE6A6A4-933A-42BA-9C53-07F6AEE27ED2','Apparel & Accessories');return false;">Apparel & Accessories</a></li>
                                            <li><a sort-data="4" href="#" onclick="ChangeCategory('4036D9BF-F178-45BB-94F0-1693923AE9B5','Garden & Outdoor');return false;">Garden & Outdoor</a></li>
                                            <li><a sort-data="5" href="#" onclick="ChangeCategory('C9590D3C-F179-413A-AC5B-24DB7EEB2A1A','Toys');return false;">Toys</a></li>
                                            <li><a sort-data="6" href="#" onclick="ChangeCategory('5D01EB4D-7E33-4381-B993-45988262CB92','Tools & Hardware');return false;">Tools & Hardware</a></li>
                                            <li><a sort-data="7" href="#" onclick="ChangeCategory('F66C02B2-3441-4D71-8328-5A5129E73D2A','Children/Infant');return false;">Children/Infant</a></li>
                                            <li><a sort-data="8" href="#" onclick="ChangeCategory('B984BDA6-A0A7-4CD2-9EDD-6D1B33EFC3AD','Arts, Crafts & Party');return false;">Arts, Crafts & Party</a></li>
                                            <li><a sort-data="9" href="#" onclick="ChangeCategory('1382D416-6E2D-4708-8557-7F226EDBDC13','Household');return false;">Household</a></li>
                                            <li><a sort-data="10" href="#" onclick="ChangeCategory('C781386B-DBD9-4257-9EB6-8D74ED61A9C1','Health & Beauty');return false;">Health & Beauty</a></li>
                                            <li><a sort-data="11" href="#" onclick="ChangeCategory('F5527740-ED0E-4F9B-B7B9-A8222E5EA31C','Automotive');return false;">Automotive</a></li>
                                            <li><a sort-data="12" href="#" onclick="ChangeCategory('1F728092-0771-431D-81B2-A9B7D3DDE7FE','Pets');return false;">Pets</a></li>
                                            <li><a sort-data="13" href="#" onclick="ChangeCategory('EA786CE8-9664-48CC-A22D-B1BB5957F0E2','Sports & Leisure');return false;">Sports & Leisure</a></li>
                                            <li><a sort-data="14" href="#" onclick="ChangeCategory('1E12E85A-F86C-4243-8446-C5F33B19E454','Office & Stationery');return false;">Office & Stationery</a></li>
                                            <li><a sort-data="15" chref="#" onclick="ChangeCategory('FDAC6A4C-86D4-4DBB-857C-F52831F846B1','Green / Eco Products');return false;">Green / Eco Products</a></li>
                                            <li><a sort-data="16" href="#" onclick="ChangeCategory('7DEE69E4-6103-4E16-A0CC-FB065473183D','Clean & Organize');return false;">Clean & Organize</a></li>
                                         </ul>
                                            <!--
                                        <select class="btn btn-danger dropdown-toggle" id="shopCategory" name="shopCategory">
                                            <option value="-1">All Category</option>
                                            <option value="1608AC1B-786A-4596-9DEE-04FC45131332">Electronics</option>
                                            <option value="3EE6A6A4-933A-42BA-9C53-07F6AEE27ED2">Apparel & Accessories</option>
                                            <option value="4036D9BF-F178-45BB-94F0-1693923AE9B5">Garden & Outdoor</option>
                                            <option value="C9590D3C-F179-413A-AC5B-24DB7EEB2A1A">Toys</option>
                                            <option value="5D01EB4D-7E33-4381-B993-45988262CB92">Tools & Hardware</option>
                                            <option value="F66C02B2-3441-4D71-8328-5A5129E73D2A">Children/Infant</option>
                                            <option value="B984BDA6-A0A7-4CD2-9EDD-6D1B33EFC3AD">Arts, Crafts & Party</option>
                                            <option value="1382D416-6E2D-4708-8557-7F226EDBDC13">Household</option>
                                            <option value="C781386B-DBD9-4257-9EB6-8D74ED61A9C1">Health & Beauty</option>
                                            <option value="F5527740-ED0E-4F9B-B7B9-A8222E5EA31C">Automotive</option>
                                            <option value="1F728092-0771-431D-81B2-A9B7D3DDE7FE">Pets</option>
                                            <option value="EA786CE8-9664-48CC-A22D-B1BB5957F0E2">Sports & Leisure</option>
                                            <option value="1E12E85A-F86C-4243-8446-C5F33B19E454">Office & Stationery</option>
                                            <option value="FDAC6A4C-86D4-4DBB-857C-F52831F846B1">Green / Eco Products</option>
                                            <option value="7DEE69E4-6103-4E16-A0CC-FB065473183D">Clean & Organize</option>
                                        </select>
                                        -->
                                    </div>
                                    <input type="hidden" name="shopCategory" id="shopCategory" />
                                    <input type="text" name="txtKeywords" class="form-control" placeholder="Search products...">
                                     <span class="input-group-btn">
                        <button class="btn-u btn-u-shop" onclick="SubmitForm(): type="button"><i class="fa fa-search"></i></button>
                    </span>
                    
                                </div>
  </form>
                 
                    </div>
                   
                      
                </div><!--/end result category-->
              <!--=== Collection Banner ===--
         
       <div class="row margin-bottom-60">
            <div class="col-md-4 product-service">
              
                <div class="product-service-in">
                    <h3>Share & Earn</h3>
                    <p>Share to your friends <br> when they purchase (up to 10%)!</p>
                    <a href="#">+Read More</a>
                </div>
            </div>
            <div class="col-md-4 product-service">
               
                <div class="product-service-in">
                    <h3>Tweebot event</h3>
                    <p>Integer mattis lacinia felis vel molestie. Ut eu euismod erat.</p>
                    <a href="#">+Read More</a>
                </div>
            </div>
            <div class="col-md-4 product-service">
              
                <div class="product-service-in">
                    <h3>30-50% OFF Full-Price Styles</h3>
                    <p>Big sale items<br>hhhhh</p>
                    <a href="#">+Read More</a>
                </div>
            </div>
        </div> -->




                <!--
       <div class="title-v1 margin-bottom-40">
            <h2>Featured products</h2>
        </div> -->
             <!--=== Illustration v2 Featured products===-->
        <div  class="illustration-v2 margin-bottom-40">
        <div class="customNavigation margin-bottom-20">
                <a class="owl-btn prev fpprev rounded-x"><i class="fa fa-angle-left"></i></a> <span style="font-size:20px;padding:0px 10px;"> Featured products </span>
                <a class="owl-btn next fpnext rounded-x"><i class="fa fa-angle-right"></i></a>
            </div>
           <ul id="owlFeaturedProduct" class="list-inline owl-slider">
            <%=strHTML_Featured%>
            

            </ul>
            

         
        </div> 
        <!--=== End Illustration v2 Featured products ===-->

        <!--=== Illustration v1 ===-
          <div class="collection-banner margin-bottom-60">
        <div class="container">
        
        </div>
    </div>
    
    === End Collection Banner ===-->
        <!--=== End Illustration v1 ===
          <div class="title-v1 margin-bottom-20">
            <h2>Latest products</h2>
        </div>
            === Illustration v2 ===-->
        <div  class="illustration-v2 margin-bottom-40">
            <div class="customNavigation margin-bottom-25">
                <a class="owl-btn prev lpprev rounded-x"><i class="fa fa-angle-left"></i></a> <span style="font-size:20px;padding:0px 10px;"> Latest products </span>
                <a class="owl-btn next lpnext rounded-x"><i class="fa fa-angle-right"></i></a>
            </div>

            <ul id="owlLatestProduct" class="list-inline owl-slider">
   <%=strHTML_Latest%>        
            
            </ul>
        </div> 
        <!--=== End Illustration v2 ===-->   
                <!--=== Illustration v1 ===
        <div class="row margin-bottom-60">
            <div class="col-md-6 md-margin-bottom-30">
                <div class="overflow-h">
                    <div class="illustration-v1 illustration-img1">
                        <div class="illustration-bg">
                            <div class="illustration-ads ad-details-v1">
                                <h3><strong>TWEEBOT EVENT </strong><br> Earn $10000 NOW!</h3>
                                <a class="btn-u btn-brd btn-brd-hover btn-u-light" href="/Product/prdSaleAll.aspx">Shop Now</a>
                            </div>    
                        </div>    
                    </div>
                </div>    
            </div>
                     <div class="col-md-6 md-margin-bottom-30">
                <div class="overflow-h">
                    <div class="illustration-v1 illustration-img2">
                        <div class="illustration-bg">
                            <div class="illustration-ads ad-details-v1">
                                <h3><strong>SHARE & EARN </strong></h3>
                                <a class="btn-u btn-brd btn-brd-hover btn-u-light" href="/Product/prdSaleAll.aspx">Shop Now</a>
                            </div>    
                        </div>    
                    </div>
                </div>    
            </div>

        </div>  end row-->


        <!--=== End Illustration v1 ===-->

        <!--=== Illustration v4 ===-->
        <div class="row illustration-v4 margin-bottom-40">
            <div class="col-md-4">
                <div class="heading margin-bottom-20">
                    <h2>Free Shipping</h2>
                </div>
               <%=strHTML_FreeShipping%> 
            </div>
            <div class="col-md-4">
                <div class="heading margin-bottom-20">
                    <h2>Test-Sale</h2>
                </div>
               
                <%=strHTML_TestSale%>
               
            </div>
            <div class="col-md-4 padding">
                <div class="heading margin-bottom-20">
                    <h2>Inventor Shop</h2>
                </div>
                <%=strHTML_InventorShop %>
                
            </div>
        </div><!--/end row-->




    </div><!--/end container-->    
       
<!-- JS Global Compulsory -->


<script src="/plugins/jquery/jquery-migrate.min.js"></script>
<script src="/plugins/bootstrap/js/bootstrap.min.js"></script>

<!-- Master Slider -->
<script src="/plugins/master-slider/quick-start/masterslider/masterslider.min.js"></script>
<script src="/plugins/master-slider/quick-start/masterslider/jquery.easing.min.js"></script>
<!-- Scrollbar -->
<script src="/plugins/scrollbar/src/jquery.mousewheel.js"></script>
<script src="/plugins/scrollbar/src/perfect-scrollbar.js"></script>
<script src="/plugins/jquery.parallax.js"></script>
<script src="/plugins/revolution-slider/rs-plugin/js/jquery.themepunch.tools.min.js"></script>
<script src="/plugins/revolution-slider/rs-plugin/js/jquery.themepunch.revolution.min.js"></script>

<!-- JS Implementing Plugins -->
<script src="/plugins/back-to-top.js"></script>
<script src="/plugins/owl-carousel/owl-carousel/owl.carousel.js"></script>

<!-- JS Customization -->
<script src="/js/custom.js"></script>
<script src="/plugins/revolution-slider/rs-plugin/js/jquery.themepunch.tools.min.js"></script>
<script src="/plugins/revolution-slider/rs-plugin/js/jquery.themepunch.revolution.min.js"></script>

<!-- JS Page Level -->
<script src="/js/shop.app.js"></script>
<script src="/js/plugins/owl-carousel.js"></script>
<script src="/js/forms/product-quantity.js"></script>
<script src="/js/plugins/revolution-slider.js"></script>
<script src="/js/plugins/master-slider.js"></script>
<script type="text/javascript" src="/js/plugins/style-switcher.js"></script>

 <script src="/MethodJs/favorite.js" type="text/javascript"></script>

<script>
    jQuery(document).ready(function () {
        App.init();
        App.initParallaxBg();
        /*
         $("#owl-demo1").owlCarousel();
         $("#owl-demo2").owlCarousel();
        */
        //OwlCarousel.initOwlCarousel();
        //////////////////////////////////////////////
        var owlfp = jQuery("#owlFeaturedProduct");
		owlfp.owlCarousel({
		    items: [4],
		    itemsDesktop : [1000,3], //3 items between 1000px and 901px
		    itemsDesktopSmall : [979,2], //2 items between 901px
		    itemsTablet: [600,1], //1 items between 600 and 0;
		    slideSpeed: 1000
		});

		    // Custom Navigation Events
		    jQuery(".fpnext").click(function(){
		        owlfp.trigger('owl.next');
		    })
		    jQuery(".fpprev").click(function(){
		        owlfp.trigger('owl.prev');
		    })
	    //});

       var owllp = jQuery("#owlLatestProduct");
		owllp.owlCarousel({
		    items: [4],
		    itemsDesktop : [1000,3], //3 items between 1000px and 901px
		    itemsDesktopSmall : [979,2], //2 items between 901px
		    itemsTablet: [600,1], //1 items between 600 and 0;
		    slideSpeed: 1000
		});

		    // Custom Navigation Events
		    jQuery(".lpnext").click(function(){
		        owllp.trigger('owl.next');
		    })
		    jQuery(".lpprev").click(function(){
		        owllp.trigger('owl.prev');
		    })
		    //});

  //Owl Slider v2
	        jQuery(document).ready(function() {
	        var owl = jQuery(".owl-slider-v2");
	            owl.owlCarousel({
	                items:5,
	                itemsDesktop : [1000,4], //4 items between 1000px and 901px
		            itemsDesktopSmall : [979,3], //3 items between 901px
	                itemsTablet: [600,2], //2 items between 600 and 0;
	            });
		    });
        /////////////////////////////////////
        RevolutionSlider.initRSfullWidth();
        StyleSwitcher.initStyleSwitcher();
        MasterSliderShowcase2.initMasterSliderShowcase2();



    });

    //分享动作
    /*
    function SharePrd(id, name, img, page, desc, saleprice) {
        var cur_url = window.location.href.toLowerCase();

        name = unescape(name);
        var tip = true;
        var userid = $("#hiduserid").val();
        var persent = $("#hidpersent").val();
        if (persent != "") {
            var getP = saleprice * persent;
            $("#sharePercent").html("$" + getP);
        } else {
            $("#sharePercent").html("$0");
        }

        if (SetShareLink(id, name, img, page, desc, saleprice) == true) {
            $("#share-tck2").parents(".greybox").show();
            $("#share-tck2").animate({ top: "2%" }, 300);
        }
    }*/

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

    //隐藏弹出 框
    function hidePopup() {
        $(".popbox").hide();
    }

    function SubmitForm() {
        $("#frmSearch").submit();
    }

    function ChangeCategory(cate_id,cate_name){
        $("#spanCategorySelected").html(cate_name);
        $("#shopCategory").val(cate_id);
        
    }
    function ToggleButton(){
        var css_class=$("#divCategoryDropdown").attr("class").split(' ');
        var hasOpen=0;
        for(var i=0;i< css_class.length;i++){
            if(css_class[i]=="open") hasOpen=1;
        }
        if(hasOpen==1){
            $("#divCategoryDropdown").removeClass("open");
        }else{
            $("#divCategoryDropdown").addClass("open");
        }
    }
</script>


</asp:Content>
