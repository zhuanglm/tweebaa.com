<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="summitWelcome.aspx.cs" Inherits="TweebaaWebApp.User.summitWelcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

	 
	<link rel="stylesheet" href="css/scroll.css" />
 
	<script src="../Js/reg.js" type="text/javascript"></script>
	<script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
	<script type="text/javascript" src="../Js/jquery.xScroller.js"></script>
	<script type="text/javascript" src="../Js/dragbox.js"></script>
	<link rel="stylesheet" href="../Css/selectCss.css" />


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

<form action="">
<div class="sub-wel-main">
	<div class="w clearfix">
		
		<div class="imgtxt fl">
			<img src="../Images/382x326.jpg" alt="" />
			<p>
				发布者就如同是个“产品星探”，当你发掘的产品在推易吧的土壤里发芽，成长，最终成为畅销产品时，你就是产品专家啦
			</p>
		</div>
		<div class="infor fl">
			<h1>好生活从<strong class="l2">好产品</strong>开始</h1>
			<h2>只要你能发现好产品，并找到供货渠道   ，就可以在此发布</h2>
			<h3>
				你发布的产品一旦产生销售，就可以获得销售额的<strong class="l2">终身分红</strong>。<br />你就是我们的零投资合伙人！
			</h3>
			<div class="xieyi">
				

				<div class="chklist fl">
					<input type="checkbox" value='1' />
					<label>阅读并同意推易吧</label>
				</div>
				<a href="#" class="l2 chakan fl">《产品发布协议》</a>

			</div>
			<div class="area tc">
				<h4>请选择发布区域</h4>
			
				<div id="radiolist" style="padding:10px; font-size:14px; ">
					<input name='r' type="radio" value='11' checked/><label class="hRadio_Checked">中国（中文版）</label>
					<input name='r' type="radio" value='21' /><label>海外（Engilsh Vison）</label>
				</div>

				<p>
					<a href="issue.aspx" class="goto-submitpage">
						立即发布产品
					</a>
				</p>
				<p>
					<a href="#" class="goso-success-pro">
						去看看发布成功的产品 <img src="../Images/gotosuccess.png" alt="" />
					</a>
				</p>
			</div>
		</div>
		
	</div>
</div>

</form>




<!-- 发布协议弹出框 -->
<div class="greybox">
	<div id="tck2" class="tck">
		<div class="pr">
			<a href="#" class="closeBtn" title="关闭"></a>
			<h5><strong>推易吧产品发布协议</strong></h5>
			<div class="scr_con">
				<div id="dv_scroll">
					<div id="dv_scroll_text" class="Scroller-Container">
						<div class="tcCon" id="tcCon">
							<p class="font3">
								推易吧欢迎你发布各种可以改善日常生活所需的创新好产品，或者，超低价格的流行畅销品。<br />
								这样有创意，又功能实效、方便，可以解决实际生活问题的产品更受评审者和消费者青睐。
							</p>
							<br /><br />
							<p>
								1、作为发布者，您应为推易吧的注册用户，完全理解并接受本协议。 <br />
								2、作为发布者的单位应为依法成立并登记备案的企业法人或其他组织；作为发布者的个人，应为年满18周岁并具有完全民事行为能力和民事权利能力的自然人，如发布者未满18周岁，应由其监护人代为履行本协议权利和义务。<br />
								3、您应按照推易吧的要求，进行必要的身份认证和资质认证，包括但不限于身份证、护照、学历证明等的认证。<br />
								4、您应拥有在中国大陆地区开户并接收人民币汇款的银行卡或支付宝账户。（英文版相应调整）<br />
								5、发布表格中必须包含（产品图片，发布价格，供应渠道，描述产品特点和卖点）等重要内容，如有必要需要视频进行介绍。我们的产品发布实行审核机制，文字或图片的缺失都极可能导致您的产品发布被退回。<br />
								6、你对所发布的产品应该有提供货源的方式，包括在其他平台找到供应商信息。例如单纯一个创意想法，一份前期设计草图，无法提供货源等等，都不适合作为创新产品在推易吧平台发布。<br />
								7、你不应抄袭、盗用他人的产品图片，创意类产品必须为原创。<br />
								8、您发起的项目不得包含非法、色情、淫秽、暴力等内容，不得含有攻击性、侮辱性言论，不得含有违反国家法律法规、政策的内容及其他众筹网认为不适宜的内容。<br />
								9、您在推易吧上发起的项目不得涉及种族主义、宗教极端主义、恐怖主义等内容。<br />
								10、您发起的项目不应与第三方存在任何权利纠纷，否则因此导致的一切损失（包括推易吧因此被第三方权利追索而遭受的一切损失）由您本人承担，与推易吧无关。<br />
								11、你可以申请提交对所发布产品的修改编辑权利，但一切文字图片修改需要在原产品基础上，并通过推易吧审核确认修改成功。<br />
								12、发布方表格填写不属实，后期无法提供任何供货信息以及货源渠道，则不享受发布者一次性30美金奖励和销量总额的终身永续收入。<br /><br />

								我已经认真阅读并同意《推易吧产品发布协议》
							</p>

						</div><!--about end-->
					</div>
				</div><!--dv_scroll end-->
				<div id="dv_scroll_bar">
					<div id="dv_scroll_track" class="Scrollbar-Track">
						<div class="Scrollbar-Handle"></div>
						<span class="Scrollbar-Handle-blue"></span>
					</div>
				</div>
			</div>
			<div class="tc">
				<a href="#" class="iagree">我同意</a>
			</div>
		</div>
	</div>
</div>

<script type="text/javascript">
    $(function () {

        //查看协议
        $(".chakan").click(function (event) {
            var objClick = $(this)
            $("#tck2").parents(".greybox").show()
            $("#tck2").animate({ top: "2%" }, 300)
            objClick.siblings().find(".checkbox").addClass('checked')
        });

        //关闭弹出框
        $('.iknow,.closeBtn,.iagree').click(function (event) {
            var obj2 = $(this).parents(".tck")
            obj2.animate({
                top: "-500px"
            },
				300, function () {

				    obj2.parents(".greybox").hide()
				});
            return false;
        });

        //表单美化
        $('.chklist').hcheckbox();
        $('#radiolist').hradio();
    });
</script>


<script type="text/javascript">
    window.onload = window.onresize = function () {

        $('.scr_con').scroller({  //改变类名调用
            scrollCon: '#dv_scroll',
            scrollArea: '#dv_scroll_text',
            scrollBar: '#dv_scroll_bar',
            scroller: '.Scrollbar-Handle'
        });
    }
	
</script>

</asp:Content>
