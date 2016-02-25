﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="prdSaleAll.aspx.cs" Inherits="TweebaaWebApp2.Product.prdSaleAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
<%=TweebaaWebApp2.SEOTextDefine.PreSaleAllSEOTitle %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
<%=TweebaaWebApp2.SEOTextDefine.PreSaleAllSEOMeta %>
    <link rel="stylesheet" href="/css/buyall.css" />
 <link rel="stylesheet" href="/css/shareall.css" />
    <link href="/css/multiSelect.css" rel="stylesheet" type="text/css" />
     <link href="/css/submit.css" rel="stylesheet" type="text/css" />
     <link href="/css/shareBox.css" rel="stylesheet" type="text/css" />
     <link href="/css/shareall.css" rel="stylesheet" type="text/css" />

    <script src="../MethodJs/SearchByCate.js" type="text/javascript"></script>
    <script src="../MethodJs/prdByFocusCate.js" type="text/javascript"></script>
    <script src="../MethodJs/favorite.js" type="text/javascript"></script>
    <script src="../MethodJs/share.js?v=20160111" type="text/javascript"></script>
    <script src="../MethodJs/prdSale.js?v=20160118" type="text/javascript"></script>
        <!-- CSS Theme -->
     <link rel="stylesheet" href="/css/theme-skins/dark.css">
          
    <script src="/js/jspage/kkpager.js" type="text/javascript"></script>
    <link href="/js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />

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
<input type="hidden" id="txtCateID" value="<%=strCateID %>" />
<input type="hidden" id="txtKeyword" value="<%=strKeyword %>" />
<input type="hidden" id="txtShowMain" value="0" />
    <!--=== Breadcrumbs v4 ===-->
    <div class="breadcrumbs-v4 shop_back">
        <div class="container">

            <h1>
                EARN SHOPPING REWARDS ON<strong> ALL PURCHASES</strong>
            </h1>
            <p>
                Shop on Tweebaa to find amazing products at great prices!</p>
            <ul class="breadcrumb-v4-in">
                <li><a href="/index.aspx">Home</a></li>
                <li><a href="/Product/prdSaleAll.aspx">Shop</a></li>
                <li class="active">Welcome</li>
            </ul>
        </div>
        <!--/end container-->
    </div>
    <!--=== End Breadcrumbs v4 ===-->
    <!--=== Content Part ===-->
    <div class="content container">
        <div class="row">
            <div class="col-md-3 filter-by-block md-margin-bottom-60">
                <div class="panel-group" id="accordion">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h2 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseStatus">Status 
					  <i  class="fa fa-angle-down"></i></a>
                            </h2>
                        </div>
                        <div id="collapseStatus" class="panel-collapse collapse in">
                            <div class="panel-body">
                                <ul class="list-unstyled checkbox-list">
                                    <li>
                                        <label class="checkbox">
                                            <input type="checkbox" id="ckbAll"  onclick="ckbAll(this)" name="checkbox" checked /><i></i>All <small><a href="javascript:void(0);" ><label id="labSumCount"></label></a></small>
                                        </label>
                                    </li>
                                    <li>
                                        <label class="checkbox">
                                            <input type="checkbox" id="ckbLimited"  onclick="ckbLimeted(this)" name="checkbox"  /><i></i>Test-Sale <small><a href="javascript:void(0);">
                                                <label id="labPreSlaeCount"></label></a></small>
                                        </label>
                                    </li>
                                    <li>
                                        <label class="checkbox">
                                            <input type="checkbox" id="ckbBuyNow"  onclick="ckbBuyNow(this)" name="checkbox"  />
                                            <i></i>Buy Now <small><a href="javascript:void(0);"><label id="saleCount"></label></a></small>
                                        </label>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                           
                <div class="panel-group" id="accordion-v2">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h2 class="panel-title">
                                <a id="a_category" data-toggle="collapse" data-parent="#accordion-v2" href="#collapseCategory">
                                    Categories
                                    <i class="fa fa-angle-down"></i>
                                </a>
                            </h2>
                        </div>
                  
                            <div id="collapseCategory" class="panel-collapse collapse in">
                        <div class="panel-body" id="category_tree">

                        </div>
                    </div>
                        <!--new drop down catoryies end-->
                    </div>
                </div>
                  <div class="panel-group" id="Div1">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h2 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseByFocus">By Focus <i
                                    class="fa fa-angle-down"></i></a>
                            </h2>
                        </div>
                        <div id="collapseByFocus" class="panel-collapse collapse in">
                            <div class="panel-body">
                                <ul class="list-unstyled checkbox-list" id="ulByFocus">
                                    <li>
                                        <label class="checkbox">
                                            <input type="checkbox" name="option[]" value="2" onclick="DoSearch()" /><i>
                                            </i>Ahaaa! <small><a href="#"></a></small>
                                        </label>
                                    </li>
                                    <li>
                                        <label class="checkbox">
                                            <input type="checkbox" name="option[]" value="3" onclick="DoSearch()" />
                                            <i></i>Novel-twee <small><a href="#"></a></small>
                                        </label>
                                    </li>
                                    <li>
                                        <label class="checkbox">                                           
                                            <input type="checkbox" name="option[]" value="1" onclick="DoSearch()" />
                                            <i></i>Twee-Tech <small><a href="#"></a></small>
                                        </label>
                                    </li>
                                    <li>
                                        <label class="checkbox">
                                            <input type="checkbox" name="option[]" value="4" onclick="DoSearch()" />
                                            <i></i>Un-Breathable <small><a href="#"></a></small>
                                        </label>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
               
                 <div class="modal fade" id="responsive" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog modal-lg">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title" id="myModalLabel">Contact us directly via inquiry form</h4>
                                    </div>
                                    <div class="modal-body">
                                                                                           
                        <form role="form">
                        <div class="row">
                            <div class="form-group col-md-6">
                                <label for="inputEmail1" class="control-label">*Name</label>
                             <input type="text" class="form-control" id="txtWholesaleInquiryName"  placeholder="Please enter your name">
                             
                            </div>
                            <div class="form-group col-md-6">
                                <label for="inputPassword1" class="control-label">*Company</label>
                           <input type="text" class="form-control" id="txtWholesaleInquiryCompany" placeholder="Please enter your company">
                              
                            </div>
                            </div>
                           <div class="row">
                            <div class="form-group col-md-6">
                                <label for="inputPassword1" class="control-label">*Phone</label>
                        <input type="text" class="form-control" id="txtWholesaleInquiryPhone" placeholder="Please enter your phone number">
                            </div>
                                  <div class="form-group col-md-6">
                                <label for="inputPassword1" class="control-label">*Email</label>
                                    <input type="text" class="form-control" id="txtWholesaleInquiryEmail" placeholder="Please enter your email">
                            </div>
                            </div>
                            <div class="row">
                            <div class="form-group col-md-6">
                                <label for="inputPassword1" class="control-label">*Product Interested</label>
                                <input type="text" class="form-control" id="txtWholesaleInquiryProduct" placeholder="Which products interest you?">
                               
                            </div>
                                 <div class="form-group col-md-6">
                                <label for="inputPassword1" class="control-label">*Quantity</label>
                                <input type="text" class="form-control" id="txtWholesaleInquiryQty" placeholder="Please enter the quantity">
                               
                            </div>
                            </div>
                              <div class="form-group">
                                <label for="inputPassword1" class="control-label">Description</label>
                                <input type="text" class="form-control" id="txtWholesaleInquiryDesc" placeholder="Please provide further details of your inquiry">
                            </div>
                        </form>
                  
                                            
                                        </div>
                                   
                                    <div class="modal-footer">
                                        <button type="button" class="btn-u btn-u-default" data-dismiss="modal">Close</button>
                                        <button type="button" class="btn-u btn-u-primary" onclick="DoWholesaleInquiry()">Submit</button>
                                    </div>
                                     </div>
                                </div>
                            </div>
            </div>


            <div class="col-md-9">
                <div class="row margin-bottom-5">
                    <div class="col-md-4 ">
                        <div class="input-group sort-list-search">
                            <input type="text" id="txtPrdname" class="form-control" placeholder="Search products...">
                            <span class="input-group-btn">
                                <button class="btn-u" type="button" onclick="DoSearch()">
                                    <i class="fa fa-search"></i>
                                </button>
                            </span>
                        </div>
                    </div>
                    <div class="col-md-8 hidden-col ">
                        <ul class="list-inline clear-both">
                            <li class="grid-list-icons ">
                            <a href="#" onclick="show_by_list()"><i class="fa fa-th-list"></i></a>
                            <a href="#" onclick="show_by_grid()"><i class="fa fa-th"></i></a>
                            </li>

                            <li class="sort-list-btn">
                                <h3 style="margin-top:3px">Sort :</h3>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                     <span id="spnSortBy">By Ranking</span><span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu" role="menu">
                                        <%--<li><a href="#">All</a></li>
                                        <li><a href="#">Best Sales</a></li>
                                        <li><a href="#">Top Last Week Sales</a></li>
                                        <li><a href="#">New Arrived</a></li>--%>
                                        <li><a href="#" sort-data="0" onclick="orderBy(this)">By Ranking</a> </li>
                                        <li><a href="#" sort-data="1" onclick="orderBy(this)">By Time</a> </li>
                                        <li><a href="#" sort-data="2" onclick="orderBy(this)">By Price</a> </li>
                                        <li><a href="#" sort-data="3" onclick="orderBy(this)">By Name</a> </li>

                                    </ul>
                                </div>
                            </li>
                            <li class="sort-list-btn">
                                <h3 style="margin-top:3px">Show :</h3>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                         <span id="spanPageSize">21</span><span class="caret" ></span>
                                    </button>
                                    <ul class="dropdown-menu" role="menu">
                                        <li><a href="javascript:void(0);" onclick="pageSizeSelect(21)">21</a></li>
                                        <li><a href="javascript:void(0);" onclick="pageSizeSelect(12)">12</a></li>
                                        <li><a href="javascript:void(0);" onclick="pageSizeSelect(6)">6</a></li>
                                        <li><a href="javascript:void(0);" onclick="pageSizeSelect(3)">3</a></li>
                                    </ul>
                                </div>
                            </li>
                        </ul>
                    </div>
		
                </div>

           
                
                      <div class="row margin-bottom-15">
<div class="col-md-10">				
			        <span class="text-highlights" id="searchResult"></span>
  </div>                  
  <div class="col-md-2 hidden-col ">	<span style="float:right;"><button class="btn btn-xs btn-primary rounded " type="button"  data-toggle="modal" data-target="#responsive">Wholesale Inquires</button></span></div> </div>
 
                <!--/end result category-->
                <div class="filter-results" id="prd_listings"> <%--id="prd_listings"--%>
                  
                    <%--<div class="row illustration-v2 margin-bottom-30">
                        <div class="col-md-4">
                            <div class="product-img product-img-brd">
                                <a href="#">
                                    <img class="full-width img-responsive" src="../images/blog/10.jpg" alt=""></a>
                                <a class="product-review" href="shop-ui-inner.html">Quick review</a> <a class="add-to-cart add-shop"
                                    href="#"><i class="fa fa-shopping-cart"></i>Add to Cart</a>
                            </div>
                            <div class="product-description product-description-brd margin-bottom-30">
                                <div class="overflow-h">
                                    <div class="pull-left margin-bottom-10">
                                        <h4 class="title-price shop-price">
                                            <a href="shop-ui-inner.html">Double-breasted</a></h4>
                                        <span class="gender">Mother and her Motion Cookies are a family of smart versatile sensors
                                            that take care of your fitness</span></div>
                                    <div class="product-price">
                                        <span class="title-price">$60.00</span> <span class="title-price line-through">$95.00</span>
                                        <span class="like-icon-shop"><a data-original-title="Favorite" data-toggle="tooltip"
                                            data-placement="bottom" class="tooltips" href="#"><i class="fa fa-heart"></i></a>
                                        </span>
                                        <!-- Small modal -->
                                        <span class="like-icon-shop"><a data-toggle="modal" data-target=".bs-example-modal-sm">
                                            <i class="fa fa-share-alt"></i></a></span>
                                        <!-- End Small Modal -->
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="product-img product-img-brd">
                                <a href="#">
                                    <img class="full-width img-responsive" src="images/blog/22.jpg" alt=""></a>
                                <a class="product-review" href="shop-ui-inner.html">Quick review</a> <a class="add-to-cart add-shop"
                                    href="#"><i class="fa fa-shopping-cart"></i>Add to Cart</a>
                            </div>
                            <div class="product-description product-description-brd margin-bottom-30">
                                <div class="overflow-h">
                                    <div class="pull-left margin-bottom-10">
                                        <h4 class="title-price shop-price">
                                            <a href="shop-ui-inner.html">Double-breasted</a></h4>
                                        <span class="gender">Mother and her Motion Cookies are a family of smart versatile sensors
                                            that take care of your fitness</span></div>
                                    <div class="product-price">
                                        <span class="title-price">$60.00</span> <span class="title-price line-through">$95.00</span>
                                        <span class="like-icon-shop"><a data-original-title="Favorite" data-toggle="tooltip"
                                            data-placement="bottom" class="tooltips" href="#"><i class="fa fa-heart"></i></a>
                                        </span>
                                        <!-- Small modal -->
                                        <span class="like-icon-shop"><a data-toggle="modal" data-target=".bs-example-modal-sm">
                                            <i class="fa fa-share-alt"></i></a></span>
                                        <!-- End Small Modal -->
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="product-img product-img-brd">
                                <a href="#">
                                    <img class="full-width img-responsive" src="images/blog/23.jpg" alt=""></a>
                                <a class="product-review" href="shop-ui-inner.html">Quick review</a> <a class="add-to-cart add-shop"
                                    href="#"><i class="fa fa-shopping-cart"></i>Add to Cart</a>
                                <div class="shop-rgba-red rgba-banner">
                                    Out of stock</div>
                            </div>
                            <div class="product-description product-description-brd margin-bottom-30">
                                <div class="overflow-h">
                                    <div class="pull-left margin-bottom-10">
                                        <h4 class="title-price shop-price">
                                            <a href="shop-ui-inner.html">Double-breasted</a></h4>
                                        <span class="gender">Mother and her Motion Cookies are a family of smart versatile sensors
                                            that take care of your fitness</span></div>
                                    <div class="product-price">
                                        <span class="title-price">$60.00</span> <span class="title-price line-through">$95.00</span>
                                        <span class="like-icon-shop"><a data-original-title="Favorite" data-toggle="tooltip"
                                            data-placement="bottom" class="tooltips" href="#"><i class="fa fa-heart"></i></a>
                                        </span>
                                        <!-- Small modal -->
                                        <span class="like-icon-shop"><a data-toggle="modal" data-target=".bs-example-modal-sm">
                                            <i class="fa fa-share-alt"></i></a></span>
                                        <!-- End Small Modal -->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <%--<div class="row illustration-v2" >
                      
                    </div>--%>
                </div>
                <!--/end filter resilts-->
                <div class="text-center">
                <div id="kkpager" style="padding-right:150px;"></div>
                <!--
                    <ul class="pagination pagination-v3">
                        <li><a href="#"><i class="fa fa-angle-left"></i></a></li>
                        <li><a href="#">1</a></li>
                        <li class="active"><a href="#">2</a></li>
                        <li><a href="#">3</a></li>
                        <li><a href="#"><i class="fa fa-angle-right"></i></a></li>
                    </ul>
                -->
                </div>
                <!--/end pagination-->
            </div>
        </div>
        <!--/end row-->
    </div>


  <script type="text/javascript">

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

      function DoWholesaleInquiry() {
          // get input data
          var name = $("#txtWholesaleInquiryName").val().trimRight();
          var company = $("#txtWholesaleInquiryCompany").val().trimRight();
          var phone = $("#txtWholesaleInquiryPhone").val().trimRight();
          var email = $("#txtWholesaleInquiryEmail").val().trimRight();
          var product = $("#txtWholesaleInquiryProduct").val().trimRight();
          var qty = $("#txtWholesaleInquiryQty").val().trimRight();
          var desc = $("#txtWholesaleInquiryDesc").val().trimRight();

          // validate name and company
          if (name == "") { alert("Please enter the Name!"); $("#txtWholesaleInquiryName").focus(); return false; }
          if (company == "") { alert("Please enter the Company!"); $("#txtWholesaleInquiryCompany").focus(); return false; }

          // validate phone number
          if (phone == "") { alert("Please enter the Phone!"); $("#txtWholesaleInquiryPhone").focus(); return false; }
          var regPhone = /^\(\d{3}\) ?\d{3}( |-)?\d{4}|^\d{3}( |-)?\d{3}( |-)?\d{4}$/;
          if (!regPhone.test(phone)) {
              alert("Please enter a valid phone number!");
              $("#txtWholesaleInquiryPhone").focus();
              return false;
          }

          // validate email
          if (email == "") { alert("Please enter the Email!"); $("#txtWholesaleInquiryEmail").focus(); return false; }
          // validate email address
          var regEmail = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
          if (!regEmail.test(email)) {
              alert("Please input a valid email!");
              $("#txtWholesaleInquiryEmail").focus();
              return false;
          }

          // validate product
          if (product == "") { alert("Please enter the Product Interested!"); $("#txtWholesaleInquiryProduct").focus(); return false; }

          // validate qty
          if (qty == "") { alert("Please enter the QUantity!"); $("#txtWholesaleInquiryQty").focus(); return false; }
          if (isNaN(qty) == true) {
              alert("Please input a valid quantity!");
              $("#txtWholesaleInquiryQty").focus();
              return false;
          }

          var nowDate = new Date();
          var emailSubject = FormatDate(nowDate) + " Wholesale Inquiry";
          var emailBody = "<p>Name: " + name + "</p>" +
                            "<p>Company: " + company + "</p>" +
                            "<p>Phone: " + phone + "</p>" +
                            "<p>Email: " + email + "</p>" +
                            "<p>Product Interested: " + product + "</p>" +
                            "<p>Quantity: " + qty + "</p>" +
                            "<p>Description: " + desc + "</p>";
          var emailTo = "wholesale@tweebaa.com";
          //var emailTo = "lidecao@gmail.com";

          var _data = "{action:'WholesaleInquiry',subject:'" + escape(emailSubject) + "',to:'" + escape(emailTo) + "',body:'" + escape(emailBody) + "'}";

          $.ajax({
              type: "POST",
              url: '/AjaxPages/SendWholesaleInquiryEmail.aspx',
              async: false,
              data: _data,
              //contentType: "Application/Json", //; charset=utf-8
              dataType: "text",
              success: function (ret) {
                  if (ret == "1") {
                      alert("Wholesale inquiry email has been sent successfully!");
                      $("#wholesale").parents(".greybox").hide()
                      return true;
                  }
                  else return false;
              },
              error: function (XMLHttpRequest, textStatus, errorThrown) {
                  //alert("status:" + XMLHttpRequest.status);
                  //alert("readyState:" + XMLHttpRequest.readyState);
                  //alert("textStatus:" + textStatus);

                  alert("Failed to send email！");
                  return false;
              }
          });
      }

      function FormatDate(date) {
          var d = new Date(date);
          var month = '' + (d.getMonth() + 1);
          var day = '' + d.getDate();
          var year = d.getFullYear();

          if (month.length < 2) month = '0' + month;
          if (day.length < 2) day = '0' + day;

          return [year, month, day].join('-');
      }

      //if mobile device hide categories
      //if (jQuery.browser.mobile) {
      //    $("#a_category").addClass("Collapsed");
      //}
      var IsMobile = $("#MobileBrowserFlag").val();
      if (IsMobile == 1) {
          //Mobile Browser
          $("#a_category").addClass("Collapsed");
          //panel-collapse collapse
          //panel-collapse collapse in
          $("#collapseCategory").removeClass("in");
          $("#collapseStatus").removeClass("in");
          $("#collapseByFocus").removeClass("in");
      }
    </script>
    <!--/end container-->
</asp:Content>
