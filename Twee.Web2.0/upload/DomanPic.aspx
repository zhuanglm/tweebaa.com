<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DomanPic.aspx.cs" Inherits="TweebaaWebFile.DomanPic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=Edge">
<%--    <script type='text/javascript' src='http://crossdomain.sinaapp.com/xd/util.js'></script>
    <script type='text/javascript' src='http://crossdomain.sinaapp.com/xd/xd.js'></script>--%>
    <script src="js/util.js" type="text/javascript"></script>
    <script src="js/xd.js" type="text/javascript"></script>

    <link href="css/index.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/submit.css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/newfloat.js"></script>
    <script src="js/jquery.form.js" type="text/javascript"></script>
    <link href="css/jquery.upload.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.upload.js" type="text/javascript"></script>
</head>
<body style="background-color: #F8F8F8;">
 <p id='info'></p>
    <%--<form id="form1" runat="server" method="post" action="Server/upload_json.ashx">--%>
    <form id="form1" runat="server">
    <div class="fabubox" style="margin-left: 0px; padding-left: 0px; padding-top: 10px;">
        <form action="">
        <!-- 图片信息 -->
    
        <input type="hidden" id="hid1" />
       <input type="button"  value="gte" onclick="getdata()" />
        <table>
            <tr>
                <td class="t">
                    <b>＊</b>产品相册
                </td>
                <td width="30">
                    <em class="showbox">
                        <div class="thistips">
                            <i></i>
                            <p>
                                此处上传产品图片，尽量拍摄清晰的图片，展现更多产品特色及细节。<br />
                                1. 可用扩展名: jpg,jpeg,gif,png;<br />
                                2. 单个文件最大 1M;<br />
                                3. 长*宽不小于 450px * 430px。
                            </p>
                        </div>
                    </em>
                </td>
                <td width="570">
                    <iframe src="fileControl.aspx" id="iframeUpload" frameborder="0" style="display: none;"
                        onload="getImg(this.contentWindow.document.body.innerHTML)"></iframe>
                    <div class="line fl">
                        <span class="span" style="display: none;">
                            <input name="" type="text" id="viewfile" onmouseout="document.getElementById('upload').style.display='none';"
                                class="inputstyle" />
                        </span>
                        <label for="unload" class="file1" onclick="uplod()">
                            上传</label>
                    </div>
                    <div class="fl font1" style="line-height: 30px;">
                        支持Jpeg , Gif , Png格式，图片大小不超过2兆。最好有一张白色背景图
                    </div>
                </td>
            </tr>
            <tr>
                <td class="t">
                    商品图片
                </td>
                <td width="30">
                </td>
                <td width="605">
                    <dl class="clearfix fengmian">
                        <dd class="first">
                            <a href="#" class="imglink">
                                <%--../Images/small/01.jpg--%>
                                <img src="" alt="" id="img1" />
                            </a>
                            <div class="btn-group">
                                <a href="#" class="moveLeft fl"></a><a href="#" class="moveRight fr"></a><a href="#"
                                    class="delthis"></a>
                            </div>
                        </dd>
                        <dd>
                            <a href="#" class="imglink">
                                <img src="" alt="" id="img2" />
                            </a>
                            <div class="btn-group">
                                <a href="#" class="moveLeft fl"></a><a href="#" class="moveRight fr"></a><a href="#"
                                    class="delthis"></a>
                            </div>
                        </dd>
                        <dd>
                            <a href="#" class="imglink">
                                <img src="" alt="" id="img3" />
                            </a>
                            <div class="btn-group">
                                <a href="#" class="moveLeft fl"></a><a href="#" class="moveRight fr"></a><a href="#"
                                    class="delthis"></a>
                            </div>
                        </dd>
                        <dd>
                            <a href="#" class="imglink">
                                <img src="" alt="" id="img4" />
                            </a>
                            <div class="btn-group">
                                <a href="#" class="moveLeft fl"></a><a href="#" class="moveRight fr"></a><a href="#"
                                    class="delthis"></a>
                            </div>
                        </dd>
                        <dd>
                            <a href="#" class="imglink">
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
                    产品视频
                </td>
                <td width="30">
                    <em class="showbox">
                        <div class="thistips">
                            <i></i>
                            <p>
                                好的视频能帮助大家更好的了解产品优点、使用方法，以及如何解决问题，从而更容易让顾客购买。
                            </p>
                        </div>
                    </em>
                </td>
                <td>
                    <%--    <div class="pr" style="width: 605px;">
                        <i class="icon-btn bianji"></i>
                        <input type="text" class="text jstxt" placeholder="输入展示视频的链接网址" id="pro-web" style="width: 605px;" />
                    </div>--%>
                    <%-- <div class="pr">
                        <i class="icon-btn bianji"></i>
                        <input type="text" maxlength="50" class="text jstxt" style="width: 605px;" placeholder="输入展示视频的链接网址" id="pro-des"/>
                    </div>
                    <div class="h10">
                    </div>
                    <div class="line fl" style=" width:500px;">
                        <span class="span" style="display: none;">
                            <input name="" type="text" id="viewfile2" onmouseout="document.getElementById('upload2').style.display='none';"
                                class="inputstyle2" />
                        </span>
                        <label for="unload2"   onclick="upload();"class="file1" >上传</label>                         
                        
                       
                        <asp:FileUpload ID="FileUpload1" runat="server" onchange="upload()"   Width="1,,m00" Height="30"   />
                        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="上传2" Width="78" Font-Size="30" ForeColor="White" BackColor="Blue"  BorderStyle="None"  />
                      
                    </div>
                    <div class="h10">
                    </div>--%>
                    <div class="pr">
                        <i class="icon-btn bianji"></i>
                        <input type="text" class="text jstxt" placeholder="输入展示视频的链接网址" id="pro-web" style="width: 605px;" />
                    </div>
                    <div class="h10">
                    </div>
                    <iframe src="videoControl.aspx" id="iframeVideo" frameborder="0" style="display: none;"
                        onload="getVideo(this.contentWindow.document.body.innerHTML)"></iframe>
                    <div class="line fl">
                        <span class="span" style="display: none;">
                            <input name="" type="text" id="Text1" onmouseout="document.getElementById('upload').style.display='none';"
                                class="inputstyle" />
                        </span>
                        <label for="unload" class="file1" onclick="uplod2()">
                            上传</label>
                    </div>
                    <div class="fl font1" style="line-height: 30px;">
                        支持视频格式：wmv, mov, mp4, flv
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
                    };
                }


                //删除图片
                if ($(this).is(".delthis")) {

                    var thisindex = $(".fengmian .delthis").index(this);
                    if (thisindex != 0) {
                        $(this).parents('dd').find("img").remove()
                        $(".fengmian").append($(this).parents('dd'))
                    }
                    else {
                        $(this).parents('dd').find("img").remove()
                        $(".fengmian").append($(this).parents('dd'))

                        $(".fengmian dd:first").addClass('first').siblings('dd').removeClass('first')
                    }




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
       
    </script>
    </form>
    <input type="text" value="500px" id="val" />
    <button id='trigger'>
        Send Message</button>
    
    <%--	<script type='text/javascript' > 
	    var send = function () {
	        var val = $E('val').value;      
	        var picjson = {
	            'pics': val
	        };
	        XD.sendMessage(parent, picjson); //区别在这里，第一个参数
	    };
	    var callback = function (data) {
	        //为图片文本框赋值
	        $E('info').innerHTML = jsonToStr(data);	      
	    }
	    XD.receiveMessage(callback);
	    addEvent($E('trigger'), 'click', send);
	</script>--%>
</body>
</html>
