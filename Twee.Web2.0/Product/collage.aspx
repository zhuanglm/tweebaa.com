﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="collage.aspx.cs" Inherits="TweebaaWebApp2.Product.collage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <script type="text/javascript">
        var phpFilePath = "http://52.90.85.45/design/";
    </script>
    <!-- Slider Form -->
    <script src="/plugins/sky-forms/version-2.0.1/js/jquery-ui.min.js"></script>
    <!-- JS Page Level -->
    <script src="/js/shop.app.js"></script>
    <script src="/js/plugins/owl-carousel.js"></script>
    <script src="/js/app.js"></script>
    <script type="text/javascript" src="/js/plugins/form-sliders.js"></script>
    <script type="text/javascript" src="/js/plugins/style-switcher.js"></script>
    <script type="text/javascript" src="/js/jquery-ui.js"></script>
    <script type="text/javascript" src="/js/html2canvas.js"></script>
    <script type="text/javascript" src="/js/CollageDesign.js?v=20160209"></script>
    <link rel="stylesheet" href="/css/CollageFonts.css">
    <style>
        #divWorkingArea
        {
            overflow: hidden;
        }
        .sky-form .ui-slider
        {
            margin: 0px;
        }
        .sky-form
        {
            margin-bottom: 0px;
        }
        .ItemFocus
        {
            opacity: 0.6;
            border: 1px solid #999;
        }
        .draggable
        {
            width:80px !important;
            height:80px !important;
        }
    </style>
    <!-- Google Webfonts -->
    <link href='https://fonts.googleapis.com/css?family=Gorditas' rel='stylesheet' type='text/css'>
        <!-- Custom iconic font - required -->
    <link href="/design/css/icon-font.css" rel="stylesheet" />
    <!-- External plugins css - required -->
    <link rel="stylesheet" type="text/css" href="/design/css/plugins.min.css" />
    <!-- The CSS for the plugin itself - required -->
	<link rel="stylesheet" type="text/css" href="/design/css/jquery.fancyProductDesigner.css?v=201602091" />

    	<!-- HTML5 canvas library - required -->
	<script src="/design/js/fabric.js" type="text/javascript"></script>
	<!-- The plugin itself - required -->
    <script src="/design/js/jquery.fancyProductDesigner.min.js?v=20160125" type="text/javascript"></script>
    <script type="text/javascript">
        var yourDesigner;

        jQuery(document).ready(function () {

            yourDesigner = $('#divWorkingArea').fancyProductDesigner({
                editorMode: false,
                fonts: ['Arial', 'Fearless', 'Helvetica', 'Times New Roman', 'Verdana', 'Geneva', 'Gorditas'],
                customTextParameters: {
                    colors: false,
                    removable: true,
                    resizable: true,
                    draggable: true,
                    rotatable: true,
                    autoCenter: true,
                    boundingBox: "Base"
                },
                customImageParameters: {
                    draggable: true,
                    removable: true,
                    colors: '#000',
                    autoCenter: true,
                    boundingBox: "Base"
                }
            }).data('fancy-product-designer');

            //print button
            $('#print-button').click(function () {
                yourDesigner.print();
                return false;
            });

            //create an image
            $('#image-button').click(function () {
                var image = yourDesigner.createImage();
                return false;
            });

            //create a pdf with jsPDF
            $('#pdf-button').click(function () {
                var image = new Image();
                image.src = yourDesigner.getProductDataURL('jpeg', '#ffffff');
                image.onload = function () {
                    var doc = new jsPDF();
                    doc.addImage(this.src, 'JPEG', 0, 0, this.width * 0.2, this.height * 0.2);
                    doc.save('Product.pdf');
                }
                return false;
            });

            //checkout button with getProduct()
            $('#checkout-button').click(function () {
                var product = yourDesigner.getProduct();
                console.log(product);
                return false;
            });

            //event handler when the price is changing
            $('#clothing-designer')
			.bind('priceChange', function (evt, price, currentPrice) {
			    $('#thsirt-price').text(currentPrice);
			});

            //recreate button
            $('#recreation-button').click(function () {
                var json1 = yourDesigner.getFabricJSON();
                var fabricJSON = JSON.stringify(yourDesigner.getFabricJSON());
                $('#recreation-form input:first').val(fabricJSON).parent().submit();
                return false;
            });

            //click handler for input upload
            $('#upload-button').click(function () {
                $('#design-upload').click();
                return false;
            });

            //save image on webserver
            $('#save-image-php').click(function () {
                $.post(phpFilePath + "php/save_image.php", { base64_image: yourDesigner.getProductDataURL() });
            });

            //send image via mail
            $('#send-image-mail-php').click(function () {
                $.post(phpFilePath + "php/send_image_via_mail.php", { base64_image: yourDesigner.getProductDataURL() });
            });

            //add decoration
            $('.load_decoration').click(function () {
                yourDesigner.addElement('image', 'http://67.224.94.82/Collage/DesignDecorationImg/LivingRoom/TV4.png', 'my custom design');
            });

            //upload image
            document.getElementById('design-upload').onchange = function (e) {
                if (window.FileReader) {
                    var reader = new FileReader();
                    reader.readAsDataURL(e.target.files[0]);
                    reader.onload = function (e) {

                        var image = new Image;
                        image.src = e.target.result;
                        image.onload = function () {
                            var maxH = 600,
			    				maxW = 600,
			    				imageH = this.height,
			    				imageW = this.width,
			    				scaling = 1;

                            if (imageW > imageH) {
                                if (imageW > maxW) { scaling = maxW / imageW; }
                            }
                            else {
                                if (imageH > maxH) { scaling = maxH / imageH; }
                            }

                            yourDesigner.addElement('image', e.target.result, 'my custom design', { colors: $('#colorizable').is(':checked') ? '#000000' : false, zChangeable: true, removable: true, draggable: true, resizable: true, rotatable: true, autoCenter: true, boundingBox: "Base", scale: scaling });
                        };
                    };
                }
                else {
                    alert('FileReader API is not supported in your browser, please use Firefox, Safari, Chrome or IE10!')
                }
            };
        });
    </script>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <!--=== Content Part ===-->
    <div class="content container">
        <div class="row">
            <div class="col-md-7">
                <input type="hidden" name="imgData" id="imgData" />
                <input type="hidden" name="userID" id="userID" value="<%=_userid %>" />
                <div class="panel panel-yellow margin-bottom-40" style="height: 640px ; width:600px" id="divWorkingArea">

          		<div class="fpd-product" title="Collage">
			</div>



	          	<!-- <div class="fpd-product" title="Shirt Front" data-thumbnail="images/yellow_shirt/front/preview.png">
	    		<img src="/design/images/yellow_shirt/front/base.png" title="Base" data-parameters='{"x": 325, "y": 329, "colors": "#d59211", "price": 20}' />
				<img src="/design/images/yellow_shirt/front/shadows.png" title="Shadow" data-parameters='{"x": 325, "y": 329}' />
				<img src="/design/images/yellow_shirt/front/body.png" title="Hightlights" data-parameters='{"x": 322, "y": 137}' />
				<span title="Any Text" data-parameters='{"boundingBox": "Base", "x": 326, "y": 232, "zChangeable": true, "removable": true, "draggable": true, "rotatable": true, "resizable": true, "colors": "#000000"}' >Default Text</span>
			  		<img src="/design/images/yellow_shirt/back/shadows.png" title="Shadow" data-parameters='{"x": 318, "y": 329}' />
				</div>
			</div>-->



		  	<div class="fpd-design">
		  	</div>
                </div>
                		  	<!-- The form recreation -->
		  	    <input type="file" id="design-upload" style="display: none;" />

            </div>
            <div class="col-md-5">
                <div class="tab-v2">
                    <ul class="nav nav-tabs orange">
                        <li class="active"><a href="#cat-1" data-toggle="tab" onclick="Load_Category_list()">Category</a></li>
                        <li><a href="#dec-1" data-toggle="tab"  onclick="Load_Decoration_html()">Decoration</a></li>
                        <!--  <li><a href="#bg-1" data-toggle="tab">Background</a></li> -->
                        <li><a href="#text-1" data-toggle="tab">Customization</a></li>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="cat-1">
                            <div class="row">
                                <div class="col-md-2">
                                    <button id="btnCategoryBack" onclick="Load_Category_list()" class="btn btn-default"
                                        type="button">
                                        <i class="fa fa-angle-left"></i> Back</button></div>
                                <div class="col-md-10">
                                    <div class="input-group margin-bottom-25">
                                        <input type="text" id="txtCategoryKeywords" class="form-control" ></input>
                                        <span class="input-group-btn">
                                            <button class="btn-u btn-u-dark" type="button" onclick="DoCategorySearch()">
                                                Search!
                                            </button>
                                        </span>
                                    </div>
                                </div>
                            </div>
				    
                            <div id="ProductsList">
                                <div class="row margin-bottom-20">
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_category('1608AC1B-786A-4596-9DEE-04FC45131332')">
                                                        <img class="img-responsive" src="/images/main/Electronics.jpg"  width="100px;"></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_category('3EE6A6A4-933A-42BA-9C53-07F6AEE27ED2')">
                                                        <img class="img-responsive" src="/images/main/Apparel.jpg" alt=""></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_category('4036D9BF-F178-45BB-94F0-1693923AE9B5')">
                                                        <img class="img-responsive" src="/images/main/Garden.jpg" alt=""></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_category('C9590D3C-F179-413A-AC5B-24DB7EEB2A1A')">
                                                        <img class="img-responsive" src="/images/main/Toys.jpg" alt=""></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row margin-bottom-20">
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_category('5D01EB4D-7E33-4381-B993-45988262CB92')">
                                                        <img class="img-responsive" src="/images/main/Tools.jpg" alt=""></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_category('B984BDA6-A0A7-4CD2-9EDD-6D1B33EFC3AD')">
                                                        <img class="img-responsive" src="/images/main/Arts.jpg" alt=""></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_category('1382D416-6E2D-4708-8557-7F226EDBDC13')">
                                                        <img class="img-responsive" src="/images/main/Household.jpg" alt=""></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_category('F5527740-ED0E-4F9B-B7B9-A8222E5EA31C')">
                                                        <img class="img-responsive" src="/images/main/AUTOMOTIVE.jpg" alt="automotive"></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row margin-bottom-20">
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_category('1F728092-0771-431D-81B2-A9B7D3DDE7FE')">
                                                        <img class="img-responsive" src="/images/main/pets.jpg" alt="pets"></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_category('EA786CE8-9664-48CC-A22D-B1BB5957F0E2')">
                                                        <img class="img-responsive" src="/images/main/Sports.jpg" alt="Sports"></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_category('1E12E85A-F86C-4243-8446-C5F33B19E454')">
                                                        <img class="img-responsive" src="/images/main/Office.jpg" alt=""></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_category('FDAC6A4C-86D4-4DBB-857C-F52831F846B1')">
                                                        <img class="img-responsive" src="/images/main/Green.jpg" alt=""></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row margin-bottom-20">
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_category('7DEE69E4-6103-4E16-A0CC-FB065473183D')">
                                                        <img class="img-responsive" src="/images/main/Clean.jpg" alt=""></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_category('F66C02B2-3441-4D71-8328-5A5129E73D2A')">
                                                        <img class="img-responsive" src="/images/main/Children.jpg" alt=""></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_category('C781386B-DBD9-4257-9EB6-8D74ED61A9C1')">
                                                        <img class="img-responsive" src="/images/main/health.jpg" alt=""></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="text-center">
                                <ul class="pagination" id="ProductsPage">
                                    <!--
                            <li><a href="#">«</a></li>
                            <li><a href="#">1</a></li>
                            <li><a href="#">2</a></li>
                            <li class="active"><a href="#">3</a></li>
                            <li><a href="#">4</a></li>
                            <li><a href="#">5</a></li>
                            <li><a href="#">»</a></li> -->
                                </ul>
                            </div>
                        </div>

                        <div class="tab-pane fade in" id="dec-1">
                            <div class="row">
                                <div class="col-md-2">
                                    <div class="input-group margin-bottom-25">
                                    <button id="btnDecorationBack" onclick="Load_Decoration_html()" class="btn btn-default"
                                        type="button">
                                        <i class="fa fa-angle-left"></i> Back</button>
                                    </div>
					  </div>
                            </div>
                            <div id="DecorationList">
                                <div class="row margin-bottom-20">
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_decoration(4)">
                                                        <img class="img-responsive" src="/images/main/events.jpg" alt=""></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_decoration(2)">
                                                        <img class="img-responsive" src="/images/main/dec.jpg" alt=""></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_decoration(3)">
                                                        <img class="img-responsive" src="/images/main/arrows.jpg" alt=""></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                            <div class="thumbnail-img">
                                                <div class="overflow-hidden">
                                                    <a href="#" onclick="load_decoration(5)">
                                                        <img class="img-responsive" src="/images/main/background.jpg" alt=""></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--
                        <div class="row margin-bottom-20">
                  <div class="col-sm-3">
                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                            <div class="thumbnail-img">
                                <div class="overflow-hidden">
                                    <img class="img-responsive" src="/images/main/flower.jpg" alt="">
                                </div>
                                               
                            </div>
                  
                        </div>
                    </div>
                     <div class="col-sm-3">
                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                            <div class="thumbnail-img">
                                <div class="overflow-hidden">
                                    <img class="img-responsive" src="/images/main/flower.jpg" alt="">
                                </div>
                                               
                            </div>
                  
                        </div>
                    </div>
                     <div class="col-sm-3">
                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                            <div class="thumbnail-img">
                                <div class="overflow-hidden">
                                    <img class="img-responsive" src="/images/main/flower.jpg" alt="">
                                </div>
                                               
                            </div>
                  
                        </div>
                    </div>
                     <div class="col-sm-3">
                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                            <div class="thumbnail-img">
                                <div class="overflow-hidden">
                                    <img class="img-responsive" src="/images/main/flower.jpg" alt="">
                                </div>
                                               
                            </div>
                  
                        </div>
                    </div>
        
                </div>
                              <div class="row margin-bottom-20">
                  <div class="col-sm-3">
                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                            <div class="thumbnail-img">
                                <div class="overflow-hidden">
                                    <img class="img-responsive" src="/images/main/flower.jpg" alt="">
                                </div>
                                               
                            </div>
                  
                        </div>
                    </div>
                     <div class="col-sm-3">
                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                            <div class="thumbnail-img">
                                <div class="overflow-hidden">
                                    <img class="img-responsive" src="/images/main/flower.jpg" alt="">
                                </div>
                                               
                            </div>
                  
                        </div>
                    </div>
                     <div class="col-sm-3">
                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                            <div class="thumbnail-img">
                                <div class="overflow-hidden">
                                    <img class="img-responsive" src="/images/main/flower.jpg" alt="">
                                </div>
                                               
                            </div>
                  
                        </div>
                    </div>
                     <div class="col-sm-3">
                        <div class="thumbnails thumbnail-style thumbnail-kenburn">
                            <div class="thumbnail-img">
                                <div class="overflow-hidden">
                                    <img class="img-responsive" src="/images/main/flower.jpg" alt="">
                                </div>
                                               
                            </div>
                  
                        </div>
                    </div>
         
             
                </div> -->
                            <div class="text-center">
                                <ul class="pagination" id="DecorationPage">
                                    <!--
                            <li><a href="#">«</a></li>
                            <li><a href="#">1</a></li>
                            <li><a href="#">2</a></li>
                            <li class="active"><a href="#">3</a></li>
                            <li><a href="#">4</a></li>
                            <li><a href="#">5</a></li>
                            <li><a href="#">»</a></li>  -->
                                </ul>
                            </div>
                        </div>
                        <div class="tab-pane fade in" id="text-1">
                            <div class="row margin-bottom-25">
                                <div class="col-md-12">
					    <p>Input Your Text</p>
                                    <div class="input-group margin-bottom-25">
	
						 <input type="text" id="OwnText" class="form-control"  placeholder="Input Your Text"></input>
						        <span class="input-group-btn">
                                                <button class="btn-u btn-u-dark" type="button" onclick="AddText()">
                                          Submit
                                            </button>
                                        </span>
						
                                    </div>
						  <p>Upload My Own Image</p>
                                    <div class="input-group margin-bottom-25">
						 
                                        <span class="input-group-btn">
						    <button class="btn-u rounded btn-u-dark" type="button" onclick="UploadImg()"><i class="fa fa-folder-open-o"></i> Upload</button>
                             
                                        </span>
                                    </div>


                     <!--           <div class="btn-group">
                                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                            <span id="spanColor"><img src="/images/colors/08.jpg" alt="">  Color</span> <i class="fa fa-angle-down"></i>
                                        </button>
                                        <ul class="dropdown-menu" role="menu">
                                            <li>
                                                <div class="panel-body">
                                                    <ul class="list-inline product-color-list">
                                                        <li><a href="#" onclick="ChooseColor('#ffffff','/images/colors/08.jpg')">
                                                            <img src="/images/colors/08.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#fff572','/images/colors/Color_3.jpg')">
                                                            <img src="/images/colors/Color_3.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#ffce51','/images/colors/Color_4.jpg')">
                                                            <img src="/images/colors/Color_4.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#f8934f','/images/colors/Color_5.jpg')">
                                                            <img src="/images/colors/Color_5.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#f05340','/images/colors/Color_6.jpg')">
                                                            <img src="/images/colors/Color_6.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#ec0089','/images/colors/Color_7.jpg)">
                                                            <img src="/images/colors/Color_7.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#9d3d96','/images/colors/Color_8.jpg')">
                                                            <img src="/images/colors/Color_8.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#b7bde1','/images/colors/Color_9.jpg')">
                                                            <img src="/images/colors/Color_9.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#01b5f0','/images/colors/Color_10.jpg')">
                                                            <img src="/images/colors/Color_10.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#016ca4','/images/colors/Color_11.jpg')">
                                                            <img src="/images/colors/Color_11.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#d2ece3','/images/colors/Color_12.jpg')">
                                                            <img src="/images/colors/Color_12.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#6dc4bc','/images/colors/Color_13.jpg')">
                                                            <img src="/images/colors/Color_13.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#58b948','/images/colors/Color_14.jpg')">
                                                            <img src="/images/colors/Color_14.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#007366','/images/colors/Color_15.jpg"')">
                                                            <img src="/images/colors/Color_15.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#e1c1aa','/images/colors/Color_16.jpg')">
                                                            <img src="/images/colors/Color_16.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#be8769','/images/colors/Color_17.jpg')">
                                                            <img src="/images/colors/Color_17.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#8e532b','/images/colors/Color_18.jpg')">
                                                            <img src="/images/colors/Color_18.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#dfe1de','/images/colors/Color_19.jpg')">
                                                            <img src="/images/colors/Color_19.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#797c81','/images/colors/Color_20.jpg')">
                                                            <img src="/images/colors/Color_20.jpg" alt=""></a></li>
                                                        <li><a href="#" onclick="ChooseColor('#343642','/images/colors/Color_21.jpg')">
                                                            <img src="/images/colors/Color_21.jpg" alt=""></a></li>
                                                    </ul>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>-->



                                   <!-- <div class="btn-group ">
                                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                            <span id="spanSize">Size</span> <i class="fa fa-angle-down"></i>
                                        </button>
                                        <ul class="dropdown-menu" role="menu">
                                            <li><a href="#" onclick="ChooseFontSize(12)">12</a></li>
                                            <li><a href="#" onclick="ChooseFontSize(14)">14</a></li>
                                            <li><a href="#" onclick="ChooseFontSize(16)">16</a></li>
                                            <li><a href="#" onclick="ChooseFontSize(18)">18</a></li>
                                            <li><a href="#" onclick="ChooseFontSize(24)">24</a></li>
                                            <li><a href="#" onclick="ChooseFontSize(30)">30</a></li>
                                            <li><a href="#" onclick="ChooseFontSize(36)">36</a></li>
                                            <li><a href="#" onclick="ChooseFontSize(48)">48</a></li>
                                            <li><a href="#" onclick="ChooseFontSize(60)">60</a></li>
                                            <li><a href="#" onclick="ChooseFontSize(72)">72</a></li>
                                        </ul>
                                    </div> end of size-->

                                </div>
                            </div>
				   <!--
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                        <div class="thumbnail-img">
                                            <div class="overflow-hidden">
                                                <button class="btn btn-sm rounded" type="button" data-toggle="modal" onclick="ChooseFont('80db')"
                                                    data-target=".textmodal">
                                                    <span class="font_80db big_text">Abcd</span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                        <div class="thumbnail-img">
                                            <div class="overflow-hidden">
                                                <button class="btn btn-sm rounded" type="button" data-toggle="modal" onclick="ChooseFont('A Damn Mess')"
                                                    data-target=".textmodal">
                                                    <span class="font_ADamnMess big_text">Abcd</span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                        <div class="thumbnail-img">
                                            <div class="overflow-hidden">
                                                <button class="btn btn-sm rounded" type="button" data-toggle="modal" onclick="ChooseFont('baidu')"
                                                    data-target=".textmodal">
                                                    <span class="font_baidu big_text">Abcd</span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                        <div class="thumbnail-img">
                                            <div class="overflow-hidden">
                                                <button class="btn btn-sm rounded" type="button" data-toggle="modal" onclick="ChooseFont('ASMAN')"
                                                    data-target=".textmodal">
                                                    <span class="font_ASMAN big_text">Abcd</span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>-->

				    <!--
                            <div class="row" style="padding: 20px 0px;">
                                <div class="col-md-3">
                                    <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                        <div class="thumbnail-img">
                                            <div class="overflow-hidden">
                                                <button class="btn btn-sm rounded" type="button" data-toggle="modal" onclick="ChooseFont('colour')"
                                                    data-target=".textmodal">
                                                    <span class="font_colour big_text">Abcd</span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                        <div class="thumbnail-img">
                                            <div class="overflow-hidden">
                                                <button class="btn btn-sm rounded" type="button" data-toggle="modal" onclick="ChooseFont('contrast')"
                                                    data-target=".textmodal">
                                                    <span class="font_contrast big_text">Abcd</span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                        <div class="thumbnail-img">
                                            <div class="overflow-hidden">
                                                <button class="btn btn-sm rounded" type="button" data-toggle="modal" onclick="ChooseFont('fast99')"
                                                    data-target=".textmodal">
                                                    <span class="font_fast99 big_text">Abcd</span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                        <div class="thumbnail-img">
                                            <div class="overflow-hidden">
                                                <button class="btn btn-sm rounded" type="button" data-toggle="modal" onclick="ChooseFont('froufrou')"
                                                    data-target=".textmodal">
                                                    <span class="font_froufrou big_text">Abcd</span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>-->
				    <!--
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                        <div class="thumbnail-img">
                                            <div class="overflow-hidden">
                                                <button class="btn btn-sm rounded" type="button" data-toggle="modal" onclick="ChooseFont('horrendo')"
                                                    data-target=".textmodal">
                                                    <span class="font_horrendo big_text">Abcd</span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                        <div class="thumbnail-img">
                                            <div class="overflow-hidden">
                                                <button class="btn btn-sm rounded" type="button" data-toggle="modal" onclick="ChooseFont('leadcoat')"
                                                    data-target=".textmodal">
                                                    <span class="font_leadcoat big_text">Abcd</span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                        <div class="thumbnail-img">
                                            <div class="overflow-hidden">
                                                <button class="btn btn-sm rounded" type="button" data-toggle="modal" onclick="ChooseFont('Marker Felt')"
                                                    data-target=".textmodal">
                                                    <span class="font_MarkerFelt big_text">Abcd</span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                        <div class="thumbnail-img">
                                            <div class="overflow-hidden">
                                                <button class="btn btn-sm rounded" type="button" data-toggle="modal" onclick="ChooseFont('sewer')"
                                                    data-target=".textmodal">
                                                    <span class="font_sewer big_text">Abcd</span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>-->
				    <!--
                            <div class="row" style="padding: 20px 0px;">
                                <div class="col-md-3">
                                    <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                        <div class="thumbnail-img">
                                            <div class="overflow-hidden">
                                                <button class="btn btn-sm rounded" type="button" data-toggle="modal" onclick="ChooseFont('stocky')"
                                                    data-target=".textmodal">
                                                    <span class="font_stocky big_text">Abcd</span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                        <div class="thumbnail-img">
                                            <div class="overflow-hidden">
                                                <button class="btn btn-sm rounded" type="button" data-toggle="modal" onclick="ChooseFont('valuoldcaps')"
                                                    data-target=".textmodal">
                                                    <span class="font_valuoldcaps big_text">Abcd</span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                        <div class="thumbnail-img">
                                            <div class="overflow-hidden">
                                                <button class="btn btn-sm rounded" type="button" data-toggle="modal" onclick="ChooseFont('Humanst521 BT')"
                                                    data-target=".textmodal">
                                                    <span class="font_Humanst521BT big_text">Abcd</span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="thumbnails thumbnail-style thumbnail-kenburn">
                                        <div class="thumbnail-img">
                                            <div class="overflow-hidden">
                                                <button class="btn btn-sm rounded" type="button" data-toggle="modal" onclick="ChooseFont('HUM521B')"
                                                    data-target=".textmodal">
                                                    <span class="font_HUM521B big_text">Abcd</span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>-->
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/end row-->
    </div>
    <!--/end container-->
    </div>
    <div class="modal fade clearmodal" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-sm" id="dlgClear1">
            <div class="modal-content">
                <div class="modal-header">
                    <button aria-hidden="true" data-dismiss="modal" class="close" type="button">
                        ×</button>
                    <h4 class="modal-title">
                        Clear Collage</h4>
                </div>
                <div class="modal-body">
                    <p>
                        Are you sure to clear this collage?</p>
                </div>
                <div class="modal-footer">
                    <button onclick="clear_working_area(1)" data-dismiss="modal" class="btn-u btn-u-default rounded"
                        type="button">
                        Clear</button>
                    <button class="btn-u rounded" type="button" data-dismiss="modal">
                        Cancel</button>
                </div>
            </div>
        </div>
    </div>
    <div id="dlgClear2" class="modal fade createmodal" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button aria-hidden="true" data-dismiss="modal" class="close" type="button">
                        ×</button>
                    <h4 class="modal-title">
                        Create Collage</h4>
                </div>
                <div class="modal-body">
                    <p>
                        Are you sure you want to discard your changes?</p>
                </div>
                <div class="modal-footer">
                    <button onclick="clear_working_area(2)" data-dismiss="modal" class="btn-u btn-u-default rounded"
                        type="button">
                        Clear</button>
                    <button class="btn-u rounded" type="button" data-dismiss="modal">
                        Cancel</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="publish" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="myModalLabel">
                        Publish Your Collage</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6">
                            <h4 id ="enter_collage_title">
                                Imput Title </h4>
                            <p>
                                <input class="form-control" type="text" id="collage_title" /></p>
                            <h4>
                                Enter Description</h4>
                            <p>
                                <textarea class="form-control" rows="5" id="collage_description"></textarea></p>
                        </div>
                        <div class="col-md-6" id="collage_thumbnail">
                            <img src="images/tbot_event/sitns.png" width="70%">
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn-u btn-u-default rounded" data-dismiss="modal">
                        Cancel</button>
                    <button type="button" class="btn-u btn-u-primary rounded" onclick="PublishCollage()">
                        Publish</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="SaveDraft" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="H1">
                        Save your collage</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6">
                            <h4>
                                Enter title</h4>
                            <p>
                                <input class="form-control" id="txtDraftTitle" type="text" /></p>
                            <h4>
                                Enter description</h4>
                            <p>
                                <textarea class="form-control" id="txtDraftDescription" rows="5"></textarea></p>
                        </div>
                        <div class="col-md-6">
                            <img src="images/tbot_event/sitns.png" width="70%">
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn-u btn-u-default rounded" data-dismiss="modal">
                        Cancel</button>
                    <button type="button" class="btn-u btn-u-primary rounded" data-dismiss="modal" onclick="SaveFreeStyleDraft()">
                        Save</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade textmodal" id="textmodal" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button aria-hidden="true" data-dismiss="modal" class="close" type="button">
                        ×</button>
                    <h4 class="modal-title">
                        Enter your text</h4>
                </div>
                <div class="modal-body">
                    <p>
                        <textarea class="form-control" id="txtCustomText" rows="5"></textarea></p>
                </div>
                <div class="modal-footer">
                    <button class="btn-u rounded" onclick="AddText()" type="button" data-dismiss="modal">
                        Submit</button>
                </div>
            </div>
        </div>
    </div>
    <!-- 叠图模板，Save，Submit -->
    <div class="greybox">
        <div id="dietu-moban" class="tck">
            <a href="#" class="close-Btn" title="Close"></a>
            <div class="tab">
                <span>My Draft</span> <span>My Publish</span>
            </div>
            <div class="tabConBox">
                <div class="tabCon hid">
                    <div class="page2 tr">
                        <ul class="fr" id="MyDraftPageList">
                        </ul>
                    </div>
                    <ul class="pic-list clearfix" id="MyDraftList">
                    </ul>
                    <div class="btn-group">
                        <a href="#" class="enter">Confirm </a><a href="#" class="quxiao js-close">Cancel</a>
                    </div>
                </div>
                <div class="tabCon hid">
                    <div class="page2 tr">
                        <ul class="fr" id="MyPublishPageList">
                        </ul>
                    </div>
                    <ul class="pic-list clearfix" id="MyPublishList">
                    </ul>
                    <div class="btn-group">
                        <a href="#" class="enter">Confirm </a><a href="#" class="quxiao js-close">Cancel</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <div class="modal fade" id="save_and_login" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title">
                        Save draft and login</h4>
                </div>
                <div class="modal-body">
		    <h4 >
			Do you want to log in and publish your masterpiece? 
		    </h4>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn-u btn-u-default rounded" data-dismiss="modal">
                        No Thanks</button>
                    <button type="button" class="btn-u btn-u-primary rounded" onclick="SaveAndLogin()">
                        Save draft and Login</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
