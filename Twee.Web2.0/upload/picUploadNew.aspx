﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="picUploadNew.aspx.cs" Inherits="TweebaaWebApp2.upload.picUploadNew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=pageTitle%></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/cropper.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />

     <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/cropper.min.js" type="text/javascript"></script>
    <script src="js/main.js" type="text/javascript"></script>


      <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
  <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
</head>
<body>
    <form id="form1" runat="server" style=" padding-top:20px;">
    
      <!-- Content -->
  <div class="container">
    <div class="row">
      <div class="col-md-9">
        <!-- <h3 class="page-header">Demo:</h3> -->
        <div class="img-container" id="imgDiv">
          <%--<img src="Images/picture.jpg" alt="Picture">--%>
         <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/picture.jpg" alt="Picture"  />
         <div id="divWaite" style=" position:absolute; z-index:90000; margin-left:47%; margin-top:30%; display:none;">
            <img src="Images/quan.gif" />
         </div>
     
        </div>
          
      </div>
      <div class="col-md-3">
        <!-- <h3 class="page-header">Preview:</h3> -->
        <div class="docs-preview clearfix" style="display:none;">
          <div class="img-preview preview-lg"></div>
          <div class="img-preview preview-md"></div>
          <div class="img-preview preview-sm"></div>
          <div class="img-preview preview-xs"></div>
        </div>

        <!-- <h3 class="page-header">Data:</h3> -->
        <div class="docs-data">
          <div style="margin-bottom:5px;text-align:center">Cropping start point (x,y)</div>
          <div class="input-group">
            <label class="input-group-addon" for="dataX">X</label>
            <input class="form-control" id="dataX" type="text" placeholder="x" readonly="readonly" runat="server">
            <span class="input-group-addon">px</span>
          </div>
          <div class="input-group">
            <label class="input-group-addon" for="dataY">Y</label>
            <input class="form-control" id="dataY" type="text" placeholder="y" readonly="readonly" runat="server">
            <span class="input-group-addon">px</span>
          </div>
          <div style="margin-bottom:5px;text-align:center">Cropping size (width/height)</div>
          <div class="input-group">
            <label class="input-group-addon" for="dataWidth">Width</label>
            <input class="form-control" id="dataWidth" type="text" placeholder="width" readonly="readonly" runat="server">
            <span class="input-group-addon">px</span>
          </div>
          <div class="input-group">
            <label class="input-group-addon" for="dataHeight">Height</label>
            <input class="form-control" id="dataHeight" type="text" placeholder="height" readonly="readonly" runat="server">
            <span class="input-group-addon">px</span>
          </div>
<%--          <div class="input-group">
            <label class="input-group-addon" for="dataRotate">Rotate</label>
            <input class="form-control" id="dataRotate" type="text" placeholder="rotate">
            <span class="input-group-addon">deg</span>
          </div>--%>
        </div>

        <div class="col-md-3 docs-toggles">
        <div class="dropdown dropup docs-options">
            <asp:HiddenField ID="hidTip" runat="server" />
           <asp:HiddenField ID="hidBigFilePath" runat="server" />
          <input type="button" value="Upload  Image" style="width:180px; font-size:16px; font-weight:bolder;" onclick="SelectClick()" />
          <script type="text/javascript">
              function SelectClick() {               
                  $("#<%=fileUploadPic.ClientID %>").click();
              }
          </script>
          <div style="display:none;">
             <asp:FileUpload ID="fileUploadPic" runat="server" onload="fileUploadPic_Load"  />       
             <asp:Button ID="btnUpload" runat="server" Text="upload" OnClick="btnUpload_Click"  />
          </div>   
          <div style=" padding-top:10px;">
          <asp:Button ID="btnCutSave" CssClass="btn btn-primary btn-block dropdown-toggle" style=" width:180px;" runat="server" Text="Save Cropped Image" OnClick="btnCutSave_Click" OnClientClick="javascript: return GetImageDataInfo()"/>
          </div>
        </div><!-- /.dropdown -->
               <div style="width:480px;margin-left:0px">

            You may add up to 5 images (at least one image is required).<br>
            Uploaded image must be Min 600x600 pixels; Max 1200x1200 pixels.<br>
            Upload image size limit is 1MB.<br>
            Crop image size must be 600x600 ~ 800x800 pixels.<br>
            White background is preferred.<br>
            Do not include any text on images (no phone numbers, websites or offers).

        </div>
      </div><!-- /.docs-toggles -->


      </div>
    </div>
    <div class="row" style="display:none;">
      <div class="col-md-9 docs-buttons" >
        <!-- <h3 class="page-header">Toolbar:</h3> -->
        <div class="btn-group">
          <button class="btn btn-primary" data-method="setDragMode" data-option="move" type="button" title="Move">
            <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;setDragMode&quot;, &quot;move&quot;)">
              <span class="icon icon-move"></span>
            </span>
          </button>
          <button class="btn btn-primary" data-method="setDragMode" data-option="crop" type="button" title="Crop">
            <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;setDragMode&quot;, &quot;crop&quot;)">
              <span class="icon icon-crop"></span>
            </span>
          </button>
          <button id="btn1" class="btn btn-primary" data-method="zoom" data-option="0.1" type="button" title="Zoom In" onclick="set3()">
            <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;zoom&quot;, 0.1)">
              <span class="icon icon-zoom-in"></span>
            </span>
          </button>
          <script type="text/javascript">
              function set3() {
                  setTimeout("set1()", 300);
              }
              function set1() {
                  var w = $("#dataWidth").val();
                  if (w <= 600) {
                      $("#btn1").attr("disabled", "disabled");
                      $("#btn2").removeAttr("disabled");
                      alert('this picture min size is 600*600');
                      $("#btn2").click();
                  }
                  $("#btn2").removeAttr("disabled");
              }
              function set4() {
                  setTimeout("set2()", 300);
              }
              function set2() {
                  var w = $("#dataWidth").val();
                  if (w >= 800) {
                      $("#btn2").attr("disabled", "disabled");
                      $("#btn1").removeAttr("disabled");
                      alert('this picture max size is 800*800');
                      $("#btn1").click();
                  } else {
                      $("#btn1").removeAttr("disabled");
                  }
              }
          </script>
          <button id="btn2" class="btn btn-primary" data-method="zoom" data-option="-0.1" type="button" title="Zoom Out" onclick="set4()">
            <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;zoom&quot;, -0.1)">
              <span class="icon icon-zoom-out"></span>
            </span>
          </button>
          <button class="btn btn-primary" data-method="rotate" data-option="-45" type="button" title="Rotate Left" style=" display:none;">
            <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;rotate&quot;, -45)">
              <span class="icon icon-rotate-left"></span>
            </span>
          </button>
          <button class="btn btn-primary" data-method="rotate" data-option="45" type="button" title="Rotate Right" style=" display:none;">
            <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;rotate&quot;, 45)">
              <span class="icon icon-rotate-right"></span>
            </span>
          </button>
        </div>

        <div class="btn-group" style=" display:none;">
          <button class="btn btn-primary" data-method="disable" type="button" title="Disable">
            <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;disable&quot;)">
              <span class="icon icon-lock"></span>
            </span>
          </button>
          <button class="btn btn-primary" data-method="enable" type="button" title="Enable" >
            <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;enable&quot;)">
              <span class="icon icon-unlock"></span>
            </span>
          </button>
          
          <button class="btn btn-primary" data-method="clear" type="button" title="Clear">
            <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;clear&quot;)">
              <span class="icon icon-remove"></span>
            </span>
          </button>
          <button class="btn btn-primary" data-method="reset" type="button" title="Reset">
            <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;reset&quot;)">
              <span class="icon icon-refresh"></span>
            </span>
          </button>
          <label class="btn btn-primary btn-upload" for="inputImage" title="Upload image file">
            <input class="sr-only" id="inputImage" name="file" type="file" accept="image/*">
            <span class="docs-tooltip" data-toggle="tooltip" title="Import image with Blob URLs">
              <span class="icon icon-upload"></span>
            </span>
          </label>
          <button class="btn btn-primary" data-method="destroy" type="button" title="Destroy">
            <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;destroy&quot;)">
              <span class="icon icon-off"></span>
            </span>
          </button>
        </div>

        <div class="btn-group btn-group-crop" style=" display:none;">
          <button class="btn btn-primary" data-method="getCroppedCanvas" type="button">
            <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;getCroppedCanvas&quot;)">
              Get Cropped Canvas
            </span>
          </button>
          <button class="btn btn-primary" data-method="getCroppedCanvas" data-option="{ &quot;width&quot;: 160, &quot;height&quot;: 90 }" type="button">
            <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;getCroppedCanvas&quot;, { &quot;width&quot;: 160, &quot;height&quot;: 90 })">
              160 &times; 90
            </span>
          </button>
          <button class="btn btn-primary" data-method="getCroppedCanvas" data-option="{ &quot;width&quot;: 320, &quot;height&quot;: 180 }" type="button">
            <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;getCroppedCanvas&quot;, { &quot;width&quot;: 320, &quot;height&quot;: 180 })">
              320 &times; 180
            </span>
          </button>
        </div>

        <!-- Show the cropped image in modal -->
        <div class="modal fade docs-cropped" style=" display:none;" id="getCroppedCanvasModal" aria-hidden="true" aria-labelledby="getCroppedCanvasTitle" role="dialog" tabindex="-1">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button class="close" data-dismiss="modal" type="button" aria-hidden="true">&times;</button>
                <h4 class="modal-title" id="getCroppedCanvasTitle">Cropped</h4>
              </div>
              <div class="modal-body"></div>
              <!-- <div class="modal-footer">
                <button class="btn btn-primary" data-dismiss="modal" type="button">Close</button>
              </div> -->
            </div>
          </div>
        </div><!-- /.modal -->

        <button class="btn btn-primary" data-method="getData" data-option="" data-target="#putData" type="button" style=" display:none;">
          <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;getData&quot;)">
            Get Data
          </span>
        </button>
        <button class="btn btn-primary" id="getImgData" data-method="getImageData" data-option="" data-target="#putData" type="button" style=" display:none;">
          <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;getImageData&quot;)">
            Get Image Data
          </span>
        </button>
        <button class="btn btn-primary" data-method="getCanvasData" data-option="" data-target="#putData" type="button" style=" display:none;">
          <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;getCanvasData&quot;)">
            Get Canvas Data
          </span>
        </button>
        <button class="btn btn-primary" data-method="setCanvasData" data-target="#putData" type="button" style=" display:none;">
          <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;setCanvasData&quot;, data)">
            Set Canvas Data
          </span>
        </button>
        <button class="btn btn-primary" data-method="getCropBoxData" data-option="" data-target="#putData" type="button" style=" display:none;">
          <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;getCropBoxData&quot;)">
            Get Crop Box Data
          </span>
        </button>
        <button class="btn btn-primary" data-method="setCropBoxData" data-target="#putData" type="button" style=" display:none;">
          <span class="docs-tooltip" data-toggle="tooltip" title="$().cropper(&quot;setCropBoxData&quot;, data)">
            Set Crop Box Data
          </span>
        </button>
        <input class="form-control" id="putData" type="text" placeholder="Get data to here or set data with this value" runat="server" style=" display:none;">

      </div><!-- /.docs-buttons -->

      
    </div>
  </div>


  <input id="sizeBox"  type="button" value="sizeBox" onclick="setBox()" style="display:none;" />

   <script type="text/javascript">
       var reduceRate=<%=reduceRate %>;       
   </script>  
   
    
    <script type="text/javascript">
        $(function () {
            $("#<%=fileUploadPic.ClientID %>").change(function () {
                var path = $(this).val();
                if (path != null && path.length > 0) {
                    $("#<%=btnUpload.ClientID %>").click();
                }
            });
            $("#<%=btnUpload.ClientID %>").hide();


        })

        function GetImageDataInfo() {
            $("#getImgData").click();
            var imgVal = $("#putData").val();
            //alert(imgVal);
        }

        function setImg(imgsrc, imgid) {
            window.opener.setImg(imgsrc, imgid);
            window.close();

        }
       
        //设置裁剪框位置大小
        function setBox() {
            $('.img-container > img').cropper('setCropBoxData', {"left":<%=_left %>,"top":<%=_top %>,"width":<%=_width %>,"height":<%=_height %>});
        }
        $(function () { 
            <%=styleBoxSize %>
        })

    </script>
    <style type="text/css">
      .img-container{min-height:200px; <%=styleCanvas%>}   
       
    </style>
  
    </form>
</body>
</html>