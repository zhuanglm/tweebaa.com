<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadPicEn.aspx.cs" Inherits="TweebaaWebFile.UploadPicEn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="Js/util.js" type="text/javascript"></script>
    <script src="Js/xd.js" type="text/javascript"></script>
    <link href="Css/index.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Css/submit.css" />
    <script src="../Js/jquery.min.js" type="text/javascript"></script>
    <script src="../Js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/newfloat.js"></script>
    <script src="Js/jquery.form.js" type="text/javascript"></script>
    <link href="Css/jquery.upload.css" rel="stylesheet" type="text/css" />
    <script src="Js/jquery.uploadEn.js" type="text/javascript"></script> 

    <script type="text/javascript">        
    </script>
</head>
<body style="background-color: #F8F8F8;">
    <%--<form id="form1" runat="server" method="post" action="Server/upload_json.ashx">--%>
    <form id="form1" runat="server">
    <div class="fabubox" style="margin-left: 0px; padding-left: 0px; padding-top: 10px;">
        <form action="">
        <!-- 图片信息 -->
        <table>
            <tr>
                <td class="t">
                    <b>＊</b>Images
                </td>
                <td width="30">
                  <%--  <em class="showbox">
                        <div class="thistips">
                            <i></i>
                            <p>
                                Images to show product features and details. The nicer your image, the more attractive
                                your product will be for others to purchase.<br />
                                1.Format: jpg, jpeg, gif, png<br />
                                2.Size limit 1M<br />
                                3.Length * Width less than 600px * 600px
                            </p>
                        </div>
                    </em>--%>
                </td>
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
                    <div class="fl font1" style="line-height: 30px;" >
                        You may add up to 5 images (at least one image is required).Uploaded image must be Min 600x600 pixels; Max 1200x1200 pixels.
                    </div>
                </td>
            </tr>
            <tr>
                <td class="t">
                    Gallery
                </td>
                <td width="30">
                </td>
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
                <td class="t">
                    Video
                </td>
                <td width="30">
                    <em class="showbox">
                        <div class="thistips">
                            <i></i>
                            <p>
                                Although videos are not required, they can help you better explain the features,
                                functions, solutions of your product help engage buyers to make a purchasing decision.
                            </p>
                        </div>
                    </em>
                </td>
                <td>
                    <div class="pr">
                        <i class="icon-btn bianji"></i>
                        <input type="text" class="text jstxt" placeholder="Please enter product video URL such as a youtube link. Alternatively, you may upload a video file"
                            id="pro-web" style="width: 605px;" />
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
                </td>
            </tr>
        </table>      
        
        <input type="hidden" id="hidPics1" />
        <input type="hidden" id="hidPics2" />
        <input type="hidden" id="hidPics3" />
        <input type="hidden" id="hidVideo" />
        </form>
    </div>
    <script type="text/javascript">
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
                        //$(".fengmian").append($(this).parents('dd'));
                    }
                    else {
                        //$(this).parents('dd').find("img").remove();
                        $(this).parents('dd').find("img").attr("src", "");
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
            var url = "picUploadNew.aspx?imgid=" + imgid;
            //window.showModalDialog(url,'', 'dialogWidth=900px,dialogHeight=900px,status=no,location=no,menubar=no,titlebar=no');
            // window.open(url, "uploadpic","height=100%, width=100%,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=no,status=no");
            window.open(url, 'newwindow', 'width=' + (window.screen.availWidth - 10) + ',height=' + (window.screen.availHeight - 30) + ',location=0,top=0,left=0,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no')  
        }

        function setImg(imgsrc, imgid) {
            var k = "#"+imgid;                        
            if (imgsrc != null || imgsrc.length != 0) {
                $(k).attr("src", imgsrc);             
                send(imgsrc.replace('small','big'));              
            }
        }      
       
    </script>
    </form>
</body>
</html>
