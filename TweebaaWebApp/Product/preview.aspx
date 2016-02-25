<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="preview.aspx.cs" Inherits="TweebaaWebApp.Product.preview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link href="../Css/submit.css" rel="stylesheet" type="text/css" />
    <link href="../Css/selectCss.Css" rel="stylesheet" type="text/css" />
    <script src="../Js/jquery-hcheckbox.js" type="text/javascript"></script>
    <script src="../Js/jquery.placeholder2.js" type="text/javascript"></script>
    <script src="../Js/biaodan2.js" type="text/javascript"></script>
    <script src="../Js/selectCss.js" type="text/javascript"></script>
    <script src="../Js/newfloat.js" type="text/javascript"></script>
    <script src="../Js/myLv2.js" type="text/javascript"></script>
    <script src="../Js/jquery.json-2.2.js" type="text/javascript"></script>
    <script src="../Js/hScrollPane.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

<div class="supply-preview">
	<div class="w">
		<div class="wrap pr">
			 <span class="submit-time">
			 	提交于 <%=proCreateTime%>
			 </span>
			 <h1>
			 	<%=proName %>供货单
			 </h1>
			 <h2>基本信息</h2>
			 <table class="basic-infor">
			 	 <tr>
			 	 	<td>
			 	 		产品货号: <%=proNum %>
			 	 	</td>
			 	 	<td>
			 	 		产权信息：<%=proRight %>
			 	 	</td>
			 	 	<td>
			 	 		最小起订量：<%=smallNum%>
			 	 	</td>
			 	 	<td>
			 	 		海外仓库：<%=proStockout%>
			 	 	</td>
			 	 </tr>
			 	 <tr>
			 	 	<td>
			 	 		<span class="colspan1">
			 	 			材质:<%=proCaiZhi%>
			 	 		</span>
			 	 		<span class="colspan2">
			 	 			
			 	 		</span>
			 	 	</td>
			 	 	<td>
			 	 		产品所在地：<%=proAddress%>
			 	 	</td>
			 	 	<td>
			 	 		是否提供一件代发:<%=proSend%>
			 	 	</td>
			 	 	<td>
			 	 		售后服务：<%=proSaleservice%><%=proSaleserviceinfo%>
			 	 	</td>
			 	 </tr>
			 	 <tr>
			 	 	<td>
			 	 		产品样品：<%=proExample%>
			 	 	</td>
			 	 	<td>
			 	 		发货范围：<%=proSendArea%>
			 	 	</td>
			 	 	<td>
			 	 		库存情况：<%=proStock%><%=proStockNum%>
			 	 	</td>
			 	 	<td>
			 	 		
			 	 	</td>
			 	 </tr>
			 </table>
			 <h2>详细参数</h2>
			 <div id="xtable" class="detailed-arguments clearfix">
			 	 <div class="left-fixbox">
			 	 	 <%--<dl class="color">
			 	 	 	<dt>颜色</dt>
			 	 	 	<dd>
			 	 	 		<i style="background-color: #C4DF9B;"></i>绿色
			 	 	 	</dd>
			 	 	 	<dd>
			 	 	 		<i style="background-color: #C4DF9B;"></i>绿色
			 	 	 	</dd>
			 	 	 	<dd>
			 	 	 		<i style="background-color: #C4DF9B;"></i>绿色
			 	 	 	</dd>
			 	 	 	<dd>
			 	 	 		<i style="background-color: #C4DF9B;"></i>绿色
			 	 	 	</dd>
			 	 	 </dl>--%>
			 	 	 <dl class="spec" style=" width:205px;">
			 	 	 	<dt>规格</dt>
                        <%=_ruleNameHtml %>
			 	 	 	<%--<dd>
			 	 	 		10*10*10cm
			 	 	 	</dd>
			 	 	 	<dd>
			 	 	 		10*10*10cm
			 	 	 	</dd>
			 	 	 	<dd>
			 	 	 		10*10*10cm
			 	 	 	</dd>
			 	 	 	<dd>
			 	 	 		10*10*10cm
			 	 	 	</dd>--%>
			 	 	 </dl>
			 	 </div>	
                 <div class="container thumblist">
					<div class="screen pr">
						 <ul>
							<li>
								<dl class="kucun w90">
						 	 	 	<dt><span>供给推易吧<br />的库存</span></dt>
                                    <%=_stockHtml %>
						 	 	 	<%--<dd>
						 	 	 		300
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		300
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		300
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		300
						 	 	 	</dd>--%>
						 	 	 </dl>
							</li>
							<li>
								<dl class="w118">
						 	 	 	<dt>Unique Id (SKU)</dt>
                                    <%=_sukHtml %>
						 	 	 	<%--<dd>
						 	 	 		bz-343455
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		bz-343455
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		bz-343455
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		bz-343455
						 	 	 	</dd>--%>
						 	 	 </dl>
							</li>
							<li>
								<dl class="w118">
						 	 	 	<dt>物流体积(m3)</dt>
                                    <%=_blukHtml %>
						 	 	 	<%--<dd>
						 	 	 		30.7＊30.8*40.5
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		30.7＊30.8*40.5
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		30.7＊30.8*40.5
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		30.7＊30.8*40.5
						 	 	 	</dd>--%>
						 	 	 </dl>
							</li>
							<li>
								<dl class="w90">
						 	 	 	<dt>物流重量(kg)</dt>
                                    <%=_weightHtml %>
						 	 	 	<%--<dd>
						 	 	 		300
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		300
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		300
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		300
						 	 	 	</dd>--%>
						 	 	 </dl>
							</li>
							<li>
								<dl class="w90">
						 	 	 	<dt>装箱量 </dt>
                                    <%=_boxHtml %>
						 	 	 	<%--<dd>
						 	 	 		24
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		24
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		24
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		24
						 	 	 	</dd>--%>
						 	 	 </dl>
							</li>
							<li>
								<dl class="w118">
						 	 	 	<dt>外箱尺寸(cm)  </dt>
                                    <%=_sizeHtml %>
						 	 	 	<%--<dd>
						 	 	 		30.7＊30.8*40.5
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		30.7＊30.8*40.5
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		30.7＊30.8*40.5
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		30.7＊30.8*40.5
						 	 	 	</dd>--%>
						 	 	 </dl>
							</li>
							<li>
								<dl class="w118">
						 	 	 	<dt>整箱重量(kg) </dt>
                                    <%=_boxweightHtml %>
						 	 	 	<%--<dd>
						 	 	 		30
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		30
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		30
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		30
						 	 	 	</dd>--%>
						 	 	 </dl>
							</li>
							<li>
								<dl class="w303">
						 	 	 	<dt>分区间报价</dt>
                                    <%=_priceHtml %>
						 	 	 	<%--<dd>
						 	 	 		<span>从</span><b>1</b><span>到</span><b>300</b><span>￥</span><b>28.8</b>
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		<span>从</span><b>1</b><span>到</span><b>300</b><span>￥</span><b>28.8</b>
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		<span>从</span><b>1</b><span>到</span><b>300</b><span>￥</span><b>28.8</b>
						 	 	 	</dd>
						 	 	 	<dd>
						 	 	 		<span>从</span><b>1</b><span>到</span><b>300</b><span>￥</span><b>28.8</b>
						 	 	 	</dd>--%>
						 	 	 </dl>
							</li>
						</ul>
					</div>
				</div>
			 </div>

             <script type="text/javascript">
                 $("#xtable dd").css("line-height","");
             </script>

			 <!-- 图片和视频 -->
			 <div class="pic-vedio clearfix">
			 	  <div class="vedio fr">
			 	  	<h2>产品视频</h2>
			 	  	  <div class="box">
                      <embed src='<%=video %>' width="260" height="190"></embed>
			 	  	  	  <%--<embed src="../Images/q.swf" width="260" height="190"></embed>--%>
			 	  	  </div>
			 	  </div>
			 	  <div class="pic-list fl">
			 	  	  <h2>产品图片</h2>
			 	  	  <div class="box">
							<div class="smallImgbox pr">
								<a href="#" class="btn leftBtn"></a>
								<a href="#" class="btn rightBtn"></a>
								<div class="screen">
									<ul>
                                    <%=pics %>
										<%--<li>
						                    <img src="images/small/05.jpg" width="68" height="68" alt="洋妞">
						                </li>
										<li><img src="images/small/02.jpg" width="68" height="68" alt="洋妞"></li>
										<li><img src="images/small/03.jpg" width="68" height="68" alt="洋妞"></li>
										<li><img src="images/small/04.jpg" width="68" height="68" alt="洋妞"></li>
										<li><img src="images/small/01.jpg" width="68" height="68" alt="洋妞"></li>
										<li><img src="images/small/02.jpg" width="68" height="68" alt="洋妞"></li>
										<li><img src="images/small/03.jpg" width="68" height="68" alt="洋妞"></li>
										<li><img src="images/small/04.jpg" width="68" height="68" alt="洋妞"></li>
										<li><img src="images/small/01.jpg" width="68" height="68" alt="洋妞2"></li>
										<li><img src="images/small/03.jpg" width="68" height="68" alt="洋妞"></li>
										<li><img src="images/small/04.jpg" width="68" height="68" alt="洋妞"></li>
										<li><img src="images/small/01.jpg" width="68" height="68" alt="洋妞2"></li>--%>
									</ul>
								</div>
							</div><!--smallImg end-->
			 	  	  </div>
			 	  </div>
			 </div>

			 <!-- 产品详情 -->
			 <div class="product-details">
			 	<h2>
			 		产品详情
			 	</h2>
			 	<div class="txt-box">
			 		<%=content %>
			 	</div>
			 
			 </div>
		</div>

	</div>
	<div class="result tc">
		<a href="#" class="continue-editing">继续编辑</a>
		<a href="#" class="send-confirmation">确定发送</a>
	</div>
</div>
	
	
<!-- 发布供货成功 -->

<div class="greybox">
		<div id="fabu-ok" class="supply-ok">
			<div class="fubu-ok pr">
				<a href="#" class="closeBtn"></a>
				<h1 class="tc">你的供货单已发送成功！</h1>
				<ol class="clearfix">
					<li class=" on">
						<em class="s"></em>
						
					</li>
					<li>
						<em class="s"></em>
						
					</li>
					<li class="third">
						<em>
							<b>$</b>
						</em>
						<i>
							<b>$</b>
						</i>
					</li>	
					
				</ol>
				<div class="clear"></div>
				<div class="txt tc">
					<span>发布供货</span><span>推易吧终审</span><span>预售成功</span><span>正式销售</span>
				</div>
			</div>
			<div class="hui">
				<span class="jxfb">
					<a href="#">继续供货</a>
				</span>
				<span class="ckfb">
					<a href="#">查看所有供货</a>
				</span>
				<span class="fx">
					<a href="#">回到我的供货</a>
				</span>
			</div>
			<div class="return-index">
				<a href="#">返回首页</a>
			</div>
			<div class="dao321 tc">
				<b class="dao15">25</b>秒后，自动返回首页
			</div>
		</div>
</div>











</body>



<script type="text/javascript">
    //滚动条
    $(".container").hScrollPane({
        mover: "ul",
        moverW: function () { return 1052; } (),
        showArrow: true,
        handleCssAlter: "draghandlealter",
        mousewheel: { moveLength: 207 }
    });

    //小图移动事件
    var btnNumber = 0
    $(".pic-list").find(".leftBtn").click(function () {
        btnNumber++
        if (btnNumber >= $(".pic-list li").length - 4) {
            btnNumber = 0
        };
        console.log(btnNumber)
        $(".pic-list  ul").stop().animate({
            left: -btnNumber * 82 + "px"
        },
			300);
        return false;
    })
    $(".pic-list").find(".rightBtn").click(function () {
        btnNumber--
        if (btnNumber < 0) {
            btnNumber = $(".pic-list li").length - 5
        };
        $(".pic-list  ul").stop().animate({
            left: -btnNumber * 82 + "px"
        }, 300);
        return false;
    })

    $(".send-confirmation").click(function (event) {
        fubuFun($("#fabu-ok"), "/")

    });

    $('.closeBtn,.want-gh a').click(function (event) {
        $("#fabu-ok,#ps-ok").animate({
            top: "-500px"
        },
				300, function () {
				    $(this).parents(".greybox").hide()
				});
        return false;
    });



    //发布 弹出框
    function fubuFun(obj, urllink) {
        obj.parents(".greybox").show()
        obj.animate({ top: "5%" }, 300)
        //倒计时开始
        setInterval(function () {
            var dao123 = parseInt(obj.find(".dao15").html())
            dao123--;
            obj.find(".dao15").html(dao123)
            if (dao123 == 0 && urllink) {
                window.location.assign(urllink)
            };
        }, 1000)
    }


</script>

</asp:Content>
