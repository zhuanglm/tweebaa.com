<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadPic2.aspx.cs" Inherits="TweebaaWebFile.UploadPic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="css/index.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/submit.css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/newfloat.js"></script>  
   <script src="js/jquery.form.js" type="text/javascript"></script>
    <link href="css/jquery.upload.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.upload.js" type="text/javascript"></script>
   

   <script type="text/javascript">    

   </script>
</head>
<body>
    <%--<form id="form1" runat="server" method="post" action="Server/upload_json.ashx">--%>
     <form id="form1">
      <div class="fabubox">
		<form action="">
		<div class="w950">			
			<h1>
				
			</h1>
			 
			<!-- 图片信息 -->
			<div class="basic-infor">
				 <span class="title">
				 	图片信息
				 </span>
				 <table>
				 	<tr>
				 		<td class="t"><b>＊</b>产品相册</td>
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
                        <iframe src="fileControl.aspx" id="iframeUpload" frameborder="0" style=" display:none;"  onload="getImg(this.contentWindow.document.body.innerHTML)"></iframe>
				 			<div class="line fl">
						    	<span class="span" style="display: none;">
						        	<input name="" type="text" id="viewfile" onmouseout="document.getElementById('upload').style.display='none';" class="inputstyle" />
						        </span>
						       <%-- <label for="unload" onmouseover="document.getElementById('upload').style.display='block';" class="file1">上传</label>--%>
                               <label for="unload" class="file1" onclick="uplod()" >上传</label>
						      <%--  <input type="file" runat="server" onchange="document.getElementById('viewfile').value=this.value;this.style.display='none';" class="file" id="upload" />--%>
						    </div>
						    <div class="fl font1" style="line-height: 30px;">
						    	支持Jpeg , Gif , Png格式，图片大小不超过2兆。最好有一张白色背景图
						    </div>
				 		</td>
				 	</tr>
				 	
					<tr>
				 		<td class="t">商品图片</td>
				 		<td width="30">  
				 			
				 		</td>
				 		<td width="570">
							<dl class="clearfix fengmian">
								<dd class="first">
									<a href="#" class="imglink" >
                                    <%--../Images/small/01.jpg--%>
										<img src="" alt="" id="img1" />                                        
									</a>
									<div class="btn-group">
										<a href="#" class="moveLeft fl"></a>
										<a href="#" class="moveRight fr"></a>
										<a href="#" class="delthis"></a>
									</div>
								</dd>
								<dd>
									<a href="#" class="imglink" >
										<img src="" alt="" id="img2" />
									</a>
									<div class="btn-group">
										<a href="#" class="moveLeft fl"></a>
										<a href="#" class="moveRight fr"></a>
										<a href="#" class="delthis"></a>
									</div>
								</dd>
								<dd>
									<a href="#" class="imglink" >
										<img src="" alt="" id="img3" />
									</a>
									<div class="btn-group">
										<a href="#" class="moveLeft fl"></a>
										<a href="#" class="moveRight fr"></a>
										<a href="#" class="delthis"></a>
									</div>
								</dd>
								<dd>
									<a href="#" class="imglink" >
										<img src="" alt="" id="img4" />
									</a>
									<div class="btn-group">
										<a href="#" class="moveLeft fl"></a>
										<a href="#" class="moveRight fr"></a>
										<a href="#" class="delthis"></a>
									</div>
								</dd>
								<dd>
									<a href="#" class="imglink" >
										<img src="" alt="" id="img5" />
									</a>
									<div class="btn-group">
										<a href="#" class="moveLeft fl"></a>
										<a href="#" class="moveRight fr"></a>
										<a href="#" class="delthis"></a>
									</div>
								</dd>
							</dl>
				 		</td>
				 	</tr>

				 	<tr>
				 		<td class="t">　产品视频</td>
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
				 			<div class="pr" style="width: 390px;">
				 				<i class="icon-btn bianji"></i>
				 				<input type="text" class="text jstxt" placeholder="输入展示视频的链接网址" id="pro-web" style="width:320px;"/>
				 			</div>
				 			<div class="h10"></div>
				 			<div class="line fl">
						    	<span class="span" style="display: none;">
						        	<input name="" type="text" id="viewfile2" onmouseout="document.getElementById('upload2').style.display='none';" class="inputstyle2" />
						        </span>
						        <label for="unload2" onmouseover="document.getElementById('upload2').style.display='block';" class="file1">上传</label>
						        <input type="file" onchange="document.getElementById('viewfile2').value=this.value;this.style.display='none';" class="file" id="upload2" />
						     
                            
                            </div>
						    <div class="h10"></div>
				 		</td>
				 	</tr>
				 	
				 </table>
			</div>			
		</div>
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


        //增加和减少 价格区间
        var jiaObj = $(".add-sale-btn").find('.jia')
        var jianObj = $(".add-sale-btn").find('.jian')
        var sectionNum = 0;
        jiaObj.click(function () {
            sectionNum++
            if (sectionNum >= 9) {
                sectionNum = 9
                alert("最多10个区间")
            };
            $(".price-section").eq(sectionNum).show();
            console.log(sectionNum)
        });
        jianObj.click(function () {
            sectionNum--;
            if (sectionNum <= 0) {
                sectionNum = 0
            };
            $(".price-section").eq(sectionNum + 1).hide();

            console.log(sectionNum)
        })
        for (var iu = 0; iu < $(".price-section").length; iu++) {
            $(".price-section").eq(iu).css({
                zIndex: $(".price-section").length - iu + 5
            });
        };
        //产品特色
        $("#tishi").click(function () {
            $(this).find('.tishi').hide();
            $("#tese").focus();
        })
        $("#tese").focus(function (event) {
            $(this).siblings('.tishi').hide();
        });
        $("#tese").blur(function (event) {
            if ($(this).val() == "") {
                $(this).siblings('.tishi').show();
            };
        });


        //清除弹出
        $(".clear-btn").click(function (event) {
            $(".clearAllInfor").parents(".greybox").show();
            return false;
        });

        $(".closeBtn,.cancel-btn,.enter-btn").click(function (event) {
            $(".greybox").hide();

            if ($(this).is(".enter-btn")) {
                window.location.reload();
            };
        });
    })
</script>
    </form>

    
<!-- 有浮动在线咨询 -->
<a href="javascript:;" id="zxzz">在线<br />咨询</a>
<!-- 有浮动在线咨询 -->

<!-- 发布成功 -->

<div class="greybox">
	<div class="clearAllInfor">
		<a href="javascript:;" class="closeBtn"></a>
		<p>
			表格内容将被全部清除，你需要重新填写。
			确定要继续吗?
		</p>
		<div class="tc">
			<a href="#" class="cancel-btn">取消</a>
			<a href="#" class="enter-btn">确定</a>
		</div>
	</div>
</div>



</body>
</html>





