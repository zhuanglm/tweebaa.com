﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadPicEn.aspx.cs" Inherits="TweebaaWebApp2.upload.UploadPicEn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="js/util.js" type="text/javascript"></script>
    <script src="js/xd.js" type="text/javascript"></script>
    <link href="css/index.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="/css/submit.css" />
    <script src="/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/newfloat.js"></script>
    <script src="js/jquery.form.js" type="text/javascript"></script>
    <link href="css/jquery.upload.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.uploadEn.js" type="text/javascript"></script> 
    <link rel="stylesheet" href="/plugins/sky-forms/version-2.0.1/css/custom-sky-forms.css"> 
    <script type="text/javascript">        
    </script>

    <link rel="stylesheet" href="/jQuery_File_Upload/css/jquery.fileupload.css">
    <link rel="stylesheet" href="/jQuery_File_Upload/css/jquery.fileupload-ui.css">
    <style>
    .fileupload-buttonbar .ui-button input {
      position: absolute;
      top: 0;
      right: 0;
      margin: 0;
      border: solid transparent;
      border-width: 0 0 100px 200px;
      opacity: 0;
      filter: alpha(opacity=0);
      -o-transform: translate(250px, -50px) scale(1);
      -moz-transform: translate(-300px, 0) scale(4);
      direction: ltr;
      cursor: pointer;
    }
    #progress
    {
        float:none;
       /* background-color:Blue;*/
        height:20px;
       /* min-width:40px;*/
    }
    #progress .progress-bar
    {
        background-color:blue;
    }
    </style>

</head>
<body style="background-color: #F8F8F8;">
    <%--<form id="form1" runat="server" method="post" action="Server/upload_json.ashx">--%>
    <form id="frmUpload" runat="server" class="sky-form">
    <div class="fabubox" style=" margin-left:10px;">
        <form action="">
        <!-- 图片信息 -->
        <table>
            <tr>
            
                <td width="570">
                    <iframe src="fileControlEn.aspx" id="iframeUpload" frameborder="0" style="display: none;"
                        onload="getImg(this.contentWindow.document.body.innerHTML)"></iframe>
                    <%--<div class="line fl">
                        <span class="span" style="display: none;">
                            <input name="" type="text" id="viewfile" onmouseout="document.getElementById('upload').style.display='none';"
                                class="inputstyle" />
                        </span>
                        <label for="unload" class="file1" onclick="uplod()">
                            Upload</label>
                    </div>--%>
                    <div class="fl font1" >
                        Support Jpeg , Gif , PNG format，max size 2MB. Prefer white background
                    </div>
                </td>
            </tr>
            <tr>
             
                <td width="605">
                    <dl class="clearfix fengmian">
                        <dd class="first">
                            <a href="#" style="cursor: pointer;" class="imglink" onclick="uploadWin('img1')">
                                <%--../Images/small/01.jpg--%>
                                <img src="" alt="" id="img1"  />
                            </a>
                            <div class="btn-group">
                                <a href="#" class="moveLeft fl"></a><a href="#" class="moveRight fr"></a><a href="#"
                                    class="delthis"></a>
                            </div>
                        </dd>
                        <dd>
                            <a href="#" style="cursor: pointer;" class="imglink" onclick="uploadWin('img2')">
                                <img src="" alt="" id="img2" />
                            </a>
                            <div class="btn-group">
                                <a href="#" class="moveLeft fl"></a><a href="#" class="moveRight fr"></a><a href="#"
                                    class="delthis"></a>
                            </div>
                        </dd>
                        <dd>
                            <a href="#" style="cursor: pointer;" class="imglink" onclick="uploadWin('img3')">
                                <img src="" alt="" id="img3" />
                            </a>
                            <div class="btn-group">
                                <a href="#" class="moveLeft fl"></a><a href="#" class="moveRight fr"></a><a href="#"
                                    class="delthis"></a>
                            </div>
                        </dd>
                        <dd>
                            <a href="#" style="cursor: pointer;" class="imglink" onclick="uploadWin('img4')">
                                <img src="" alt="" id="img4" />
                            </a>
                            <div class="btn-group">
                                <a href="#" class="moveLeft fl"></a><a href="#" class="moveRight fr"></a><a href="#"
                                    class="delthis"></a>
                            </div>
                        </dd>
                        <dd>
                            <a href="#" style="cursor: default;" class="imglink" onclick="uploadWin('img5')">
                                <img src="" alt="" id="img5" />
                            </a>
                            <div class="btn-group">
                                <a href="#" class="moveLeft fl"></a><a href="#" class="moveRight fr"></a><a href="#"
                                    class="delthis"></a>
                            </div>
                        </dd>
                    </dl>
                </td>
            </tr>
            <tr>
              
               <!-- <td width="30">
                    <em class="showbox">
                        <div class="thistips">
                            <i></i>
                            <p>
                                Although videos are not required, they can help you better explain the features,
                                functions, solutions of your product help engage buyers to make a purchasing decision.
                            </p>
                        </div>
                    </em>
                </td>-->
                <td> 
<!--

                    <div class="pr">
                        <i class="icon-btn bianji"></i>
                        <input type="text" class="text jstxt" placeholder="Please enter product video URL such as a youtube link. Alternatively, you may upload a video file"
                            id="pro-web" style="width: 605px;" onchange="returnVideo()" />
                        <script type="text/javascript">
                            function returnVideo() {
                                var k = escape($("#pro-web").val());
                                send(k);
                            }
                       </script>
                    </div>
                    <div class="h10">
                    </div>
                    <iframe src="videoControlEn.aspx" id="iframeVideo" frameborder="0" style="display: none;"
                        onload="getVideo(this.contentWindow.document.body.innerHTML)"></iframe>
                    <div class="line fl">
                        <span class="span" style="display: none;">
                            <input name="" type="text" id="Text1" onmouseout="document.getElementById('upload').style.display='none';"
                                class="inputstyle" />
                        </span>
                        <label for="unload" class="file1" onclick="uplod2()">
                            Upload</label>
                    </div>
                    <div class="fl font1" style="line-height: 30px;">                      
                        Supports wmv, mov, mp4 and flv formats.  Maximum size is 5mb
                    </div>
-->

 <section>
     <label class="label">Upload Video</label>
       
                            <label for="file" class="input input-file">
  <input type="text" onchange="UpdateVideoFile()" id="pro-web" placeholder="Please click Browse to upload your video file Or input youtube video link" >
                                <div class="button">
   
 
   <div id="fileupload">
 <!--
     <form action="/Events/Tweenbot/FileTransferHandler.ashx" method="post" enctype="multipart/form-data">
-->
        <div class="fileupload-buttonbar">
            <label class="fileinput-button">
                <span>Browse</span>
                <input id="fileupload_browse" type="file" name="files[]" multiple="multiple" />
            </label>
            <!--
            <button type="button" class="delete button">Delete all files</button> -->
			
        </div>
        <!--
    </form>
    -->
   </div>  
      </div>                            <!--
                                <input type="file" name="file" multiple onchange="this.parentNode.nextSibling.value = this.value">Browse</div>
                                -->
                                
                                <!--
                                       <b class="tooltip tooltip-top-left">Although videos are not required, they can help you better explain the features,functions, solutions of your product help engage buyers to make a purchasing decision.
                            
                                   </b> -->
                            </label>
    <!-- The global progress bar -->

    <div id="progress" class="progress">
        <div class="progress-bar progress-bar-success"></div>
    </div>
    <div class="fileupload-content">
        <table class="files"></table>
    </div>
<script id="template-upload" type="text/x-jquery-tmpl">
    <tr class="template-upload{{if error}} ui-state-error{{/if}}">
        <td class="preview"></td>
        <td class="name">${name}</td>
        <td class="size">${sizef}</td>
        {{if error}}
            <td class="error" colspan="2">Error:
                {{if error === 'maxFileSize'}}File is too big
                {{else error === 'minFileSize'}}File is too small
                {{else error === 'acceptFileTypes'}}Filetype not allowed
                {{else error === 'maxNumberOfFiles'}}Max number of files exceeded
                {{else}}${error}
                {{/if}}
            </td>
        {{else}}
            <td class="progress"><div></div></td>
            <td class="start"><button>Start</button></td>
        {{/if}}
        <td class="cancel"><button>Cancel</button></td>
    </tr>
</script>
                        </section>

                </td>
            </tr>
        </table>      
        
        <input type="hidden" id="hidPics1" />
        <input type="hidden" id="hidPics2" />
        <input type="hidden" id="hidPics3" />
        <input type="hidden" id="hidVideo" />
        </form>
    </div>

<script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.8.13/jquery-ui.min.js"></script>
<script src="//ajax.aspnetcdn.com/ajax/jquery.templates/beta1/jquery.tmpl.min.js"></script>
<script src="/jQuery_File_Upload/scripts/Default/jquery.iframe-transport.js"></script>
<script src="/jQuery_File_Upload/scripts/Default/jquery.fileupload.js"></script>
<script src="/jQuery_File_Upload/scripts/Default/jquery.fileupload-ui.js"></script>

    <script type="text/javascript">
        function matchYoutubeUrl(url) {
            var p = /^(?:https?:\/\/)?(?:www\.)?(?:youtu\.be\/|youtube\.com\/(?:embed\/|v\/|watch\?v=|watch\?.+&v=))((\w|-){11})(?:\S+)?$/;
            return (url.match(p)) ? RegExp.$1 : false;
        }

        function UpdateVideoFile() {
            var playFile = $("#pro-web").val();
            //from youtube.com
            if (playFile.indexOf("youtube.com") >= 0 || playFile.indexOf("youtu.be") >= 0) {
                var videoid = matchYoutubeUrl(playFile);
               // alert(videoid);
                
                var youtube = "https://www.youtube.com/embed/" + videoid + "";
                $("#hidVideo").val(youtube);
                send(youtube);
                //alert(youtube);
            }
        }
        $(function () {
            // 封面事件
            $(".fengmian .btn-group").find("a").click(function (event) {

                //获取新的数组
                var fmImgArr = []
                var imglen = $(".fengmian").find("img").length;
                for (var i = 0; i < imglen; i++) {
                    var imgUrl = $(".fengmian").find("img").eq(i).attr("src")
                    fmImgArr.push(imgUrl)
                };
                var nowindex = 0
                var nextindex = 1;

                if ($(this).is(".moveLeft")) {
                    var thisindex = $(".fengmian .moveLeft").index(this);
                    if (thisindex > 0) {
                        nowindex = thisindex
                        nextindex = thisindex - 1;
                        //刷新数组
                        changeArrIndex(fmImgArr, nowindex, nextindex);

                        //图片位置更新
                        for (var ii = 0; ii < fmImgArr.length; ii++) {
                            $(".fengmian").find("img").eq(ii).attr("src", fmImgArr[ii])
                        };
                        send3(nowindex + "," + nextindex);
                    };

                };


                if ($(this).is(".moveRight")) {
                    var thisindex = $(".fengmian .moveRight").index(this);
                    if (thisindex < imglen) {
                        nowindex = thisindex
                        nextindex = thisindex + 1;
                        //刷新数组
                        changeArrIndex(fmImgArr, nowindex, nextindex);

                        //图片位置更新
                        for (var ii = 0; ii < fmImgArr.length; ii++) {
                            $(".fengmian").find("img").eq(ii).attr("src", fmImgArr[ii])
                        };
                        send3(nowindex + "," + nextindex);
                    };
                }


                //删除图片
                if ($(this).is(".delthis")) {

                    var thisindex = $(".fengmian .delthis").index(this);
                    if (thisindex != 0) {
                        //$(this).parents('dd').find("img").remove();
                        $(this).parents('dd').find("img").attr("src", "");
                        $(this).parents('dd').find("img").attr("onerror", "");
                        //$(".fengmian").append($(this).parents('dd'));
                    }
                    else {
                        //$(this).parents('dd').find("img").remove();
                        $(this).parents('dd').find("img").attr("src", "");
                        $(this).parents('dd').find("img").attr("onerror", "");
                        //$(".fengmian").append($(this).parents('dd'));

                        $(".fengmian dd:first").addClass('first').siblings('dd').removeClass('first')
                    }
                    //alert(thisindex);
                    send2(thisindex); //删除发送

                }


                return false;

            });


            function changeArrIndex(arrr, am, bm) {
                var mm = null;
                mm = arrr[am]
                arrr[am] = arrr[bm]
                arrr[bm] = mm
            }

        })
    </script>
    <script type="text/javascript">
        $(function () {

            //问好提示
            $(".showbox").mouseenter(function (event) {
                $(this).find(".thistips").show();
            }).mouseleave(function (event) {
                $(this).find(".thistips").hide();
            });
        })

        function uploadWin(imgid) {
            //var url = "picUploadNew.aspx?imgid=" + imgid;
            var url = "fileCrop.aspx?imgid=" + imgid;
            //window.showModalDialog(url,'', 'dialogWidth=900px,dialogHeight=900px,status=no,location=no,menubar=no,titlebar=no');
            // window.open(url, "uploadpic","height=100%, width=100%,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=no,status=no");
            window.open(url, 'newwindow', 'width=' + "810px" + ',height=' + "810px" + ',top=0,left=0,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no')
        }

        function setImg(imgsrc, imgid) {
            var k = "#" + imgid;
            if (imgsrc != null || imgsrc.length != 0) {
                $(k).attr("src", imgsrc);
                var kk = "this.src='http://itweebaa.com" + imgsrc+"'";
                $(k).attr("onerror", kk);
                //onError = "this.onerror=null;this.src='/images/noimage.gif';"
                
               // alert(imgsrc);
                send(imgsrc.replace('small', 'big'));
            }
        }      
       


    /*jslint unparam: true */
    /*global window, $ */
        $(function () {
            'use strict';
            // Change this to the location of your server-side upload handler:
            var url = "/Events/Tweebot/FileTransferHandler.ashx";
            $('#fileupload').fileupload({
                url: url,
                dataType: 'json',
                done: function (e, data_f) {

                    $.each(data_f.result, function (index, file) {
                        //$('<p/>').text(file.name).appendTo('#files');
                        //console.log("file=" + file.name);
                        $("#pro-web").val(file.name);
                        $("#hidVideo").val(file.name);
                        /*
                        var k = escape(file.name);
                        send(k);
                        */
                        $('#hidvideo', window.parent.document).val("upload/PlayVideo/" + file.name);
                        /*
                        var p = $("#frmUpload").parent().find("#hidvideo");
                        if (p) {
                        console.log("44444");
                        p.val(file.name);
                        } else {
                        console.log("1133333333333333");
                        }*/
                    });

                    console.log("done");

                },
                progressall: function (e, data) {
                    var progress = parseInt(data.loaded / data.total * 100, 10);
                    console.log("progress=" + progress);
                    var width =progress + '%';
                $('#progress .progress-bar').css( {
                    "background-color": "Blue",
                    "width": width,
                    "height":"20px"
                });
            }
        });
    });
    </script>
    </form>
</body>
</html>
