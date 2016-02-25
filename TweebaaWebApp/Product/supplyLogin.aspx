<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="supplyLogin.aspx.cs" Inherits="TweebaaWebApp.Product.supplyLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
 
	<link rel="stylesheet" href="../css/scroll.css" />
	<script src="../js/jquery.min.js" type="text/javascript"></script>
	<script src="../js/jquery.placeholder.js" type="text/javascript"></script>
	<script src="../js/reg.js" type="text/javascript"></script>
	<script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
	<script type="text/javascript" src="../js/jquery.xScroller.js"></script>
	<script type="text/javascript" src="../js/dragbox.js"></script>
	<link rel="stylesheet" href="../css/selectCss.css" />
	<script src="../js/selectCss.js" type="text/javascript"></script>
	<%--<script type="text/javascript" src="../js/public.js"></script>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
<div class="list-banner ps-supply">
	<ul><li><img src="../images/supply-banner.jpg" width="295" height="129" alt=""/></li>
<li class="p1">Your opinion matters to Tweebaa...</li><li class="p2">Earn cash and points for evaluating new products!</li></ul>
</div>

<div class="sub-wel-main-login">
	<div class="w clearfix">
		<div class="imgtxt fl">
			<img src="../images/406x365.jpg" alt="" />
		</div>
			<div class="infor fl">
			<h1 class="tc">	<strong class="l2"><br/>Supply good products to Tweebaa</strong></h1>
			<p class="ps">	List your products on Tweebaa and let us promote them to customers around the globe.  We'll also handle the credit card processing, customer service, and we'll even fulfill orders for you.   Reach new customers with ZERO INVESTMENT!

 <br/>

			</p>

			<div class="area tc">


				<p class="tc">
					<a href="../User/login.aspx?op=supply" class="goto-login">
						Login Now
					</a>
				</p>
				<p class="tc">
					<a href="#" class="goto-reg">
						Not registered as Tweebaa's Supplier？Register Now.
					</a>
				</p>
			</div>
		</div>
	</div>
</div>
<!-- 发布填写信息 -->
<div class="sub-fill-infor   pr">
	<div class="title">
			<span>
					Please complete the form
			</span>
		</div>
	<div class="w">
		<form action="">
			<div class="reg-main">
			
			 <table width="100%">
					<tbody>
						
					
					<tr>
						<td class="t tr"  style=" width:180px;"><strong>Company Name</strong></td>
						<td>
							<input type="text" class="txt company-name" placeholder="For Example：Tweebaa Inc.">
							<span class="error">Enter correct compnay name</span>
							<span class="ok">ok</span>
						</td>
					</tr>
					<tr>
						<td class="t tr"><strong>Company Address</strong></td>
						<td>
							<div class="selectBox pr fl">
		                            <select name="" class="selects">
		                                <option selected="selected">China</option>
		                                <option>USA</option>
		                                <option>Korea</option>
		                            </select>
		                    </div>
		                    <div class="selectBox pr fl">
		                            <select name="" class="selects">
		                                <option selected="selected">Shanghai</option>
		                                <option>Guangzhou</option>
		                                <option>Tianjin</option>
		                            </select>
		                    </div>
		                    <div class="selectBox pr fl">
		                            <select name="" class="selects">
		                                <option selected="selected">Shanghai</option>
		                                <option>Guangzhou</option>
		                                <option>Shenzhen</option>
		                            </select>
		                    </div>
							<div class="clear h10"></div>
							<input type="text" class="txt company-address" placeholder="For Example：Suite 200, 345 Wellington Street, Shanghai.
">
							<span class="error">Enter complete address</span>
							<span class="ok">ok</span>
						</td>
					</tr>
					<tr>
						<td class="t tr"><strong>Company Website</strong></td>
						<td>
							<input type="text" class="txt company-name" placeholder="For Example : www.tweebaa.com">
							<span class="error">Enter complete company website</span>
							<span class="ok">ok</span>
						</td>
					</tr>
					<tr>
						<td class="t tr"><strong>Way of Supply</strong></td>
						<td>
							<div id="chklist" class="fl">
								<input type="checkbox" value='1' /><label>Manufacturer</label>
								<input type="checkbox" value='2' /><label>Distributor</label>
								<input type="checkbox" value='3' /><label>Middlemen</label>
								<input type="checkbox" value='4' /><label>Wholesaler</label>
								<input type="checkbox" value='5' /><label>Agent</label>
								<input type="checkbox" value='6' /><label>Importer</label>
								<input type="checkbox" value='7' /><label>Others</label>
							</div>

						</td>
					</tr>
					<tr>
						<td class="t tr"><strong>Main Type of business</strong></td>
						<td>
							<div class="selectBox pr fl">
		                            <select name="" class="selects">
		                                <option selected="selected">China</option>
		                                <option>USA</option>
		                                <option>Korea</option>
		                            </select>
		                    </div>
							<input type="text" class="txt" placeholder="Please describe your company main type of business">
							<span class="error">Please describe your company main type of business</span>
							<span class="ok">ok</span>
						</td>
					</tr>
					<tr>
						<td class="t tr"><strong>Contact Name</strong></td>
						<td>
							<input type="text" class="txt" placeholder="For example：Cheng">
							<span class="error">Enter correct contact person name</span>
							<span class="ok">ok</span>
						</td>
					</tr>
					<tr>
						<td class="t tr"><strong>Contact Tel</strong></td>
						<td>
							<input type="text" class="txt tel-phone" placeholder="For example：＋86 134567894321">
							<span class="error">Enter correct company contact person tel. no.</span>
							<span class="ok">ok</span>
						</td>
					</tr>
					<tr>
						<td class="t tr"><strong id="yzm-style">Verification Code</strong></td>
						<td>
							<div class="email-yzm fl yzm-style">
								<input type="text" class="txt yzm">
								<img src="../images/yzm.png" alt="" class="fl">
								<a href="#" class="fl resetYzm">Not clear</a>
							</div>
							<span class="error">Verification code incorrect，please re-enter</span>
							<span class="ok">ok</span>
							
							<div class="tel-yzm fl yzm-style">
								
								<input type="text" class="txt telyzm">
								<a href="javascript:;" class="msnicon fl pr">
									<b>免费获取短信验证码</b>
								</a>
								<a href="javascript:;" class="voiceicon fl pr">
									<b>免费获取语音验证码</b>
								</a>
							</div>

						</td>
					</tr>

					<tr>
						<td class="t tr"></td>
						<td>
							<div class="re-pwd tl">
								<div class="chklist fl">
										<input type="checkbox" value="1" style="display: none;">
										<label class="checkbox">Read and agree Tweebaa</label>
								</div>
								<span class="fl">
									<a href="#" class="fwxy">《Service Agreement》</a>
								</span>
							</div>
						</td>
					</tr>
					<tr>
						<td class="t tr"></td>
						<td>
							<input type="button" class="submit-btn send" value="Submit">
						</td>
					</tr>
				</tbody>
			</table>
			</div>
		</form>
	</div>
</div>

<script type="text/javascript">
    $(function () {
        //表单美化
        // select 美化
        $(".selects").selectCss();
        $('#radiolist').hradio();
        $('#chklist,.zhunze,.chklist').hcheckbox();
        //手机验证码提示
        $(".tel-yzm > a.pr").mouseenter(function (event) {
            $(this).find("b").show()
        }).mouseleave(function (event) {
            $(this).find("b").hide()
        });
        //点击注册弹出下面的
        $(".goto-reg").click(function (event) {
            $(".sub-fill-infor").show();
            return false;
        });
    });
</script>

</asp:Content>
