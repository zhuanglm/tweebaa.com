<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="prdReview.aspx.cs" Inherits="TweebaaWebApp2.Product.prdReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <script src="../js/util.js" type="text/javascript"></script>
    <script src="../js/xd.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../css/scroll.css" />
    <script src="../js/qtab.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <script type="text/javascript" src="../js/jquery.xScroller.js"></script>
    <link rel="stylesheet" href="../css/selectCss.css" />
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/selectNav.js"></script>
    <script src="../MethodJs/submitReview.js" type="text/javascript"></script>
    <script src="../MethodJs/prd.js" type="text/javascript"></script>
    <script src="../MethodJs/share.js" type="text/javascript"></script>
        <link rel="stylesheet" href="/plugins/master-slider/quick-start/masterslider/style/masterslider.css" />
    <link rel='stylesheet' href="/plugins/master-slider/quick-start/masterslider/skins/default/style.css" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">



           <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Product details</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="/index.aspx">Home</a></li>
                <li><a href="prdReviewAll.aspx">Evaluate</a></li>
                <li class="active">Product Details</li>
            </ul>
        </div><!--/container-->
    </div><!--/breadcrumbs-->
    <!--=== End Breadcrumbs ===-->
  <!--=== eval Product ===-->
   <div class="shop-product">
  <div class="container">
            <div class="row">
                <div class="col-md-6 md-margin-bottom-50">
                    <div class="ms-showcase2-template">
                        <!-- Master Slider -->
                        <div class="master-slider ms-skin-default" id="masterslider">
                            <div class="ms-slide">
                                <img class="ms-brd" src="/images/blank.gif" id="imgBig1" alt="lorem ipsum dolor sit">
                                <img class="ms-thumb" id="imgSmall1" src="/images/blank.gif" alt="thumb">
                            </div>
                            <div class="ms-slide">
                                <img src="/images/blank.gif" id="imgBig2" alt="lorem ipsum dolor sit">
                                <img class="ms-thumb" id="imgSmall2" src="/images/blank.gif" alt="thumb">
                            </div>
                            <div class="ms-slide">
                                <img src="/images/blank.gif" id="imgBig3" alt="lorem ipsum dolor sit">
                                <img class="ms-thumb"  id="imgSmall3" src="/images/blank.gif" alt="thumb">
                            </div>
                             <div class="ms-slide">
                                <img class="ms-brd" src="/images/blank.gif" id="imgBig4"  alt="lorem ipsum dolor sit">
                                <img class="ms-thumb" id="imgSmall4" src="/images/blank.gif" alt="thumb">
                            </div>
                             <div class="ms-slide">
                                <img class="ms-brd" src="/images/blank.gif" id="imgBig5" alt="lorem ipsum dolor sit">
                                <img class="ms-thumb" id="imgSmall5" src="/images/blank.gif" alt="thumb">
                            </div>
                        </div>
                        <!-- End Master Slider -->
                         <div class="row">
                        <div class="margin-top-20 col-md-5 whvideo" id="linkWatchVideo">
                       <button class="btn-u rounded-4x btn-u-dark btn-u-lg" type="button"  data-toggle="modal" data-target="#ModalVideo"><i class="fa fa-youtube-play"></i>  Watch Video </button>
              
                
                    </div></div>

                    </div>
                </div>

              
               <div class="col-md-6 pingshen-main">
                    <div class="eval-product-heading ">
                        <h2>
                          <strong>                     
                       <label itemprop="name"  id="pro-name" ><% =System.Web.HttpUtility.HtmlEncode(_model.name)%>
                        </label>
                    </strong>
                        </h2>
                        
                   
                    </div><!--/end shop product social-->     
                    <p> <!-- submiter information -->
      <label id="pro-user"> </label>&nbsp;Suggested on&nbsp; <label id="pro-time"></label>

                    </p>  <!-- submiter information EOF-->   
                    
  
              <ul class="list-inline shop-product-prices margin-bottom-10 row">
                        <li class="col-md-4 shop-green">$<span id="pro-price"></span></li>
                      
                     <li class="col-md-8" id="reviewProgress" style="display:none"> 
                                    <h3 class="heading-xs"> <span class="pull-right"><% =_passCount %> Voted</span>Need 300 votes</h3>
                                    <div class="progress progress-u progress-sm rounded">
                                        <div class="progress-bar progress-bar-light-green" role="progressbar" aria-valuenow="<% =_iProgress %>" aria-valuemin="0" aria-valuemax="100" style="width: <% =_iProgress%>%">
                                        </div>
                                 </div> 
                                  </li>
                     
                     
                    </ul>
     <p itemprop="description" id="pro-jl"><% =System.Web.HttpUtility.HtmlEncode(_model.txtjj) %> </p>
           
                    
      <!--    <div class="jdt fr" id="reviewProgress" style="display:none">
                       <div class="jdt-line pr">
                          <b style="left: <%//=_leftMargin%>;">
                          <span id="reviewCount" style="<%//=_styleMarginLeft%>"><%//=_passCount %> Evaluations </span></b>
                        </div>
                        <div class="price-number">
                           <span class="span1">0</span><span class="span2">100</span>
                           <span class="span3">200</span>
                           <span class="span4">300+</span>
                        </div>
                     </div>
                 
                     <span class="fr des-txt" id="lblCurrentStatus" style="display:none" >
						Current Status:
		 </span> -->
         <form action="#" class="sky-form">
                    <div class="row">
 <section class="col">  
 
  <label class="label evacolor" style="<% =_sHideAlreadyEvaluated %>">Please evaluate this product.</label>
  <div class="margin-bottom-10"></div>   

  <div class="inline-group">
 <lable class="txtinline ">Would you purchase this product? </lable>
       <script type="text/javascript">
           function chkFuc(id1, id2, errorid) {
               var i = $("#" + id1).attr("checked");
               if (i == "checked") {
                   $('#' + id2).removeAttr('checked')
               }
               // hide error when user check
               $('#' + errorid).hide();
           }
                                </script>
  <label class="checkbox"> <input type="checkbox"  value="1" id="ckb1" <% =_sYesNoArr[0] %> <%=_disabled %> onclick="chkFuc('ckb1','ckb2', 'ckb12Error')"  /><i></i>Yes</label>
 <label class="checkbox"><input type="checkbox"  value="2" id="ckb2" <% =_sYesNoArr[1] %> <%=_disabled %> onclick="chkFuc('ckb2', 'ckb1', 'ckb12Error')"><i></i>No</label>
 </div>
 <div class="note note-error" id="ckb12Error" style="display: none">Please select Yes or No.</div>
 
       
  <div class="inline-group">
  <lable class="txtinline"><span class="fl" >Do you feel this product is unique?</lable>
    
 <label class="checkbox"> <input type="checkbox" value='3' id="ckb3" <% =_sYesNoArr[2] %> <%=_disabled %> onclick="chkFuc('ckb3', 'ckb4', 'ckb34Error')" /><i></i>Yes</label>
 <label class="checkbox"> <input type="checkbox" value='4' id="ckb4" <% =_sYesNoArr[3] %> <%=_disabled %> onclick="chkFuc('ckb4', 'ckb3', 'ckb34Error')" /><i></i>No</label>
</div><div class="note note-error"  id="ckb34Error" style="display: none">Please select Yes or No.</div>

 <div class="inline-group">
  <lable class="txtinline"><span class="fl" >Do you feel this product is needed?</lable>
    
 <label class="checkbox"><input type="checkbox" value='5' id="ckb5" <% =_sYesNoArr[4] %> <%=_disabled %> onclick="chkFuc('ckb5', 'ckb6', 'ckb56Error')" /><i></i>Yes</label>
 <label class="checkbox"><input type="checkbox" value='6' id="ckb6" <% =_sYesNoArr[5] %> <%=_disabled %> onclick="chkFuc('ckb6', 'ckb5', 'ckb56Error')" /><i></i>No</label>
</div>
<div class="note note-error"  id="ckb56Error" style="display: none">Please select Yes or No.</div> 
<div class="inline-group">
  <lable class="txtinline"><span class="fl" >This product will go to Tweebaa Shop eventually?</lable>
    
 <label class="checkbox"><input type="checkbox" value='7' id="ckb7" <% =_sYesNoArr[6] %> <%=_disabled %> onclick="chkFuc('ckb7', 'ckb8', 'ckb78Error')" /><i></i>Yes</label>
 <label class="checkbox"><input type="checkbox" value='8' id="ckb8" <% =_sYesNoArr[7] %> <%=_disabled %> onclick="chkFuc('ckb8', 'ckb7', 'ckb78Error')" /><i></i>No</label>
</div>
<div class="note note-error"  id="ckb78Error" style="display: none">Please select Yes or No.</div>

<label class="textarea">
<textarea rows="3" id="reason-case"  name="message" maxlength="200" placeholder="<%=_placeholder %>" <%=_disabled %> onkeyup="DoMsgKeyup();"></textarea>
 </label>
<div class="note note-error"  id="msgError" style="display: none;top:0px;">Please input your reason or suggestion</div></div>

 <div class="margin-bottom-10"></div>
<% if (_disabled.Length == 0)
   { %>

    <!--   
 <div class="form-group row">
                                <div class="col-sm-1 control-label"><h5>Verify</h5></div>
                                <div class="col-sm-2">
                                    <input type="text" style="width:80px;height:32px;" id="txtVerify" name="txtVerify" maxlength="6" />
                                </div>
                                  <div class="col-sm-3">
                                   <img  id="imgWaterMark" src="/product/WaterMark.aspx?pn=SubmitReview" />
                                </div>
                                <div class="col-sm-5">
                               <a href="javascript:void(0)" onclick="ReloadWaterMark();return false;"><button class="btn btn-default rounded" type="button">Get another code</button></a>
                                </div>
                            </div>
 <%} %>                        
                         <div class="margin-bottom-15"></div>

                

<% if (_disabled.Length > 0)
   { %>
  <div id="divAlreadyEvaluated" style="<% =_sDispAlreadyEvaluated %>"> <label class="label evacolor"><% =_sAlreadyEvaluatedMsg%></label> </div>
<%}
   else
   { %>
                                <input type="button" class="btn-u btn-u-green rounded btn-u-lg"  value="Evaluate" id="product-release"

                            <input type="button" class="btn-u btn-u-green rounded-4x btn-u-lg"  value="Evaluate" id="product-release"

                                    onclick="SubmitReview()" <%=_disabled %> />    
                                <button type="button" class="btn-u btn-u-default rounded-4x btn-u-lg" style="<% =_sHideAlreadyEvaluated %>" onclick="DoClear(); return false;">Clear</button>            -->
 <%} %>                                 
                                <!--input type="button" class="to-examine  fr" value="Delete" id="Button1" onclick="Delete()" style="display:none;" />
                                <div class="fl chklist chklist5" style="position: relative; left: 0; top: 8px; margin-left: 0; display:none;">
                                    <div style="padding: 0px; margin-top: -15px;">
                                        <div>
                                            <input type="checkbox" value="1" checked="checked" />
                                            <label>
                                                I read and agreed with the terms and conditions in</label></div>
                                        <div class="fl" style="margin-top: -20px;">
                                            <a href="#" class="chakan">《Evaluation Agreement》</a></div>
                                    </div>
                                </div> -->
               
 <div class="margin-bottom-15"></div>

   <ul class="list-inline add-to-myevaluate add-to-wishlist-brd">
                        <li class="wishlist-in">
                        <% string favoriteHeart = "fa-heart-o";
                            if (_favorite) favoriteHeart = "fa-heart";
                        %>

                            <a href="javascript:void(0)" onclick="FavoritePrdOnOff('<%=_proid %>', '#classFavorite');"><i id="classFavorite" class="fa <% =favoriteHeart %>"></i>Favorite</a>
                        </li>
                        <li class="compare-in">
                            <a href="javascript:void(0)" id="hrefShare1"><i class="fa fa-share-alt"></i>share</a>
                        </li>
                    </ul>
                    </section>
                    </div>     

            </div><!--/end row-->
        </div>    
    </div>
    <!--=== End Shop Product ===--> 
     <!--=== Content Medium ===-->
    <div class="content-md container">
        <div class="tab-v6">
            <ul class="nav nav-tabs" role="tablist">
                <li class="active"><a href="#description" role="tab" data-toggle="tab">Description</a></li>
              <!--  <li><a href="#reviews" role="tab" data-toggle="tab">Reviews (1)</a></li>  -->
            </ul>

            <div class="tab-content margin-bottom-40">
                <!-- Description -->
                <div class="tab-pane fade in active" id="description">
                <div class="col-md-11">
                    <div id="pro-info" >

                  
                    </div>
                </div>

                <!--
                                        <div class="col-md-5">
                            <div class="responsive-video">
                    <div class="tc">
                        <iframe id="videoFrame" src=""  frameborder="5" width="500" height="500"></iframe> 
                        <div class="video" id="CuPlayer" style="margin: 0 auto;">
                        </div>
                    </div>
                            </div>
                            </div>
                            -->



                </div>
                <!-- End Description -->

                <!-- Reviews -->   
                <!-- not review right now              
                <div class="tab-pane fade" id="reviews">
                    <div class="product-comment margin-bottom-40">
                        <div class="product-comment-in">
                            <img class="product-comment-img rounded-x" src="images/team/01.jpg" alt="">
                            <div class="product-comment-dtl">
                                <h4>Mickel <small>22 days ago</small></h4>
                                <p>I like the green colour, it's very likeable and reminds me of Hollister. A little loose though but I am very skinny</p>
                                <ul class="list-inline evluate-ratings">
                                    <li class="reply"><a href="#">Reply</a></li>
                                    <li class="pull-right">
                                        <ul class="list-inline">
                                            <li><i class="rating-selected fa fa-star"></i></li>
                                            <li><i class="rating-selected fa fa-star"></i></li>
                                            <li><i class="rating-selected fa fa-star"></i></li>
                                            <li><i class="rating fa fa-star"></i></li>
                                            <li><i class="rating fa fa-star"></i></li>
                                        </ul>
                                    </li>    
                                </ul>
                            </div>
                        </div>    
                    </div>
                    <h3 class="heading-md margin-bottom-30">Add a review</h3>
                    <form action="http://htmlstream.com/preview/unify-v1.6-production/Shop-UI/assets/php/demo-contacts-process.php" method="post" id="sky-form3" class="sky-form sky-changes-4">
                        <fieldset>
                            <div class="margin-bottom-30">
                                <label class="label-v2">Name</label>
                                <label class="input">
                                    <input type="text" name="name" id="name">
                                </label>
                            </div>    
                            
                            <div class="margin-bottom-30">
                                <label class="label-v2">Email</label>
                                <label class="input">
                                    <input type="email" name="email" id="email">
                                </label>
                            </div>    
                            
                            <div class="margin-bottom-30">
                                <label class="label-v2">Review</label>
                                <label class="textarea">
                                    <textarea rows="7" name="message" id="message"></textarea>
                                </label>
                            </div>    
                        </fieldset>    
                            
                        <footer class="review-submit">
                            <label class="label-v2">Review</label>
                            <div class="stars-ratings-eval">
                                <input type="radio" name="stars-rating" id="stars-rating-5">
                                <label for="stars-rating-5"><i class="fa fa-star"></i></label>
                                <input type="radio" name="stars-rating" id="stars-rating-4">
                                <label for="stars-rating-4"><i class="fa fa-star"></i></label>
                                <input type="radio" name="stars-rating" id="stars-rating-3">
                                <label for="stars-rating-3"><i class="fa fa-star"></i></label>
                                <input type="radio" name="stars-rating" id="stars-rating-2">
                                <label for="stars-rating-2"><i class="fa fa-star"></i></label>
                                <input type="radio" name="stars-rating" id="stars-rating-1">
                                <label for="stars-rating-1"><i class="fa fa-star"></i></label>
                            </div>
                            <button type="button" class="btn-u btn-u-sm btn-u-green pull-right">Submit</button>
                        </footer>
                    </form>
                </div>  -->
                <!-- End Reviews -->              
		    

            </div>
				           <div class=" margin-bottom-40 margin-top-20 fr">
            <a href="javascript:void(0)" class="btn-u rounded-4x btn-u-dark-blue"  onclick="backEdit()">Back to Suggestion</a><%--Continue editing--%>
            <%--<a href="javascript:void(0)" class="submit-product" id="submit-product" onclick="submitPrd()">
                Submit</a>--%>
        </div>  
        </div></div>


    

<!-- 发布成功 -->
    <div class="greybox">
		<div id="fabu-ok">
			<div class="fubu-ok pr">
				<a href="#" class="closeBtn"></a>
				<h1 class="tc fb l2">Congratulation！<br />Product suggested successfully, it is in approval stage now.</h1>
				<ol class="clearfix">
					<li class="on">
						<em class="s"></em>						
					</li>
					<li>
						<em class="s"></em>						
					</li>
					<li class="third">
						<em>
							<b class="fb l2">$30Reward</b>
						</em>
						<i>
							<b class="fb l2">Commission</b>
						</i>
					</li>						
				</ol>
				<div class="clear"></div>
				<div class="txt tc">
					<span>Suggest Product</span><span>Evaluation Passed</span><span>Test-Sale Passed</span><span>Final-Sale</span>
				</div>
			</div>
			<div class="hui">
				<span class="jxfb">
					<a href="SubmitForm.aspx">Suggest More</a>
				</span>
				<span class="ckfb">
					<a href="../Home/Index.aspx?page=homeSubmit">See I suggested</a>
				</span>
				<span class="fx">
					<a href="../Home/Index.aspx">Member center</a>
				</span>
			</div>
			<div class="want-gh">
				We have lots of products waiting for you to supply!<a href="prdReviewStep2.aspx?step=supply">I want to Supply</a>
			</div>
			<div class="return-index">
				<a href="../index.aspx">Back to Home</a>
			</div>
			<div class="dao321 tc" style=" display:none;">
				<b class="dao15">15</b></b>seconds，returns to homepage automatically	
			</div>
		</div>
   </div>

    <!-- 协议弹出框 -->
    <!-- 发布协议弹出框 -->
    <div class="greybox">
        <div id="tck2" class="tck  tck-ps">
            <div class="pr">
                <a href="#" class="closeBtn" title="关闭"></a>
                <h5>
                    <strong>推易吧产品评审协议</strong></h5>
                <div class="scr_con">
                    <div id="dv_scroll">
                        <div id="dv_scroll_text" class="Scroller-Container">
                            <div class="tcCon" id="tcCon">
                                <p class="font3">
                                    推易吧欢迎你发布各种可以改善日常生活所需的创新好产品，或者，超低价格的流行畅销品。<br />
                                    这样有创意，又功能实效、方便，可以解决实际生活问题的产品更受评审者和消费者青睐。
                                </p>
                                <br />
                                <br />
                                <p>
                                    1、作为发布者，您应为推易吧的注册用户，完全理解并接受本协议。<br />
                                    2、作为发布者的单位应为依法成立并登记备案的企业法人或其他组织；作为发布者的个人，应为年满18周岁并具有完全民事行为能力和民事权利能力的自然人，如发布者未满18周岁，应由其监护人代为履行本协议权利和义务。<br />
                                    3、您应按照推易吧的要求，进行必要的身份认证和资质认证，包括但不限于身份证、护照、学历证明等的认证。<br />
                                    4、您应拥有在中国大陆地区开户并接收人民币汇款的银行卡或支付宝账户。（英文版相应调整）<br />
                                    5、发布表格中必须包含（产品图片，发布价格，供应渠道，描述产品特点和卖点）等重要内容，如有必要需要视频进行介绍。我们的产品发布实行审核机制，文字或图片的缺失都极可能导致您的产品发布被退回。<br />
                                    6、你对所发布的产品应该有提供货源的方式，包括在其他平台找到供应商信息。例如单纯一个创意想法，一份前期设计草图，无法提供货源等等，都不适合作为创新产品在推易吧平台发布。<br />
                                    7、你不应抄袭、盗用他人的产品图片，创意类产品必须为原创。<br />
                                    8、您发起的项目不得包含非法、色情、淫秽、暴力等内容，不得含有攻击性、侮辱性言论，不得含有违反国家法律法规、政策的内容及其他众筹网认为不适宜的内容。 9、您在推易吧上发起的项目不得涉及种族主义、宗教极端主义、恐怖主义等内容。<br />
                                    10、您发起的项目不应与第三方存在任何权利纠纷，否则因此导致的一切损失（包括推易吧因此被第三方权利追索而遭受的一切损失）由您本人承担，与推易吧无关。<br />
                                    11、你可以申请提交对所发布产品的修改编辑权利，但一切文字图片修改需要在原产品基础上，并通过推易吧审核确认修改成功。<br />
                                    12、发布方表格填写不属实，后期无法提供任何供货信息以及货源渠道，则不享受发布者一次性30美金奖励和销量总额的终身永续收入。<br />
                                    <br />
                                    我已经认真阅读并同意《推易吧产品发布协议》
                                </p>
                            </div>
                            <!--about end-->
                        </div>
                    </div>
                    <!--dv_scroll end-->
                    <div id="dv_scroll_bar">
                        <div id="dv_scroll_track" class="Scrollbar-Track">
                            <div class="Scrollbar-Handle">
                            </div>
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
    
    <%-- 分享弹出ydf--%>
    <div class="greybox">
        <div id="tck4" class="tck">
            <div class="pr">
                <a href="#" class="closeBtn" title="Close"></a>
                <h5>
                    <strong>Share</strong></h5>
                <div class="box" style="text-align: center;">
                    <a target="_blank"  id="share1" href="javascript:void(0)"><img src="../Images/flat-circles_03s.png" alt="facebook" /> </a> &nbsp; &nbsp; &nbsp; &nbsp;
                    <a target="_blank"  id="share2" href="javascript:void(0)"><img src="../Images/flat-circles_05s.png" alt="twitter" /> </a> &nbsp; &nbsp; &nbsp; &nbsp;
                    <a target="_blank"  id="share3" href="javascript:void(0)"><img src="../Images/flat-circles_13s.png" alt="google" /> </a> &nbsp; &nbsp; &nbsp; &nbsp;
                    <%--<a target="_blank"  id="share4" href="javascript:void(0)"><img src="../Images/pluck.png" alt="plurk" /> </a> &nbsp; &nbsp; &nbsp; &nbsp;--%>
                     
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        //表单提示
        $('input, textarea').placeholder();


        var setIntervalID; //ydf       

        //发布
        function fubuFun(obj, urllink) {
            obj.parents(".greybox").show()
            obj.animate({ top: "5%" }, 300)
            //倒计时开始
            setIntervalID = setInterval(function () {
                var dao123 = parseInt(obj.find(".dao15").html())
                dao123--;
                obj.find(".dao15").html(dao123)
                if (dao123 == 0) {
                    //window.location.assign(urllink)
                };
            }, 1000)
        }
        //取消定时 ydf
        function cancelSetInterval() {
            window.clearInterval(setIntervalID);
        }

        $('.closeBtn,.want-gh a').click(function (event) {
            $("#fabu-ok,#ps-ok").animate({
                top: "-500px"
            },
				300, function () {
				    $(this).parents(".greybox").hide()
				});
            return false;
        });

        //详情和评价切换
        $(".pingshen-box").qTab({
            tabT: ".tab a", //tab title
            tabCon: ".itembox"//tab Con
        })
        //阅读前面的input
        $('#chklist,.chklist').hcheckbox();

        $('#product-release').click(function () {
        })

        //确定发送弹出提示
        $("#submit-product").click(function () {
            //fubuFun($("#fabu-ok"), "summit-welcome.html")
        })



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



            if ($(this).is(".iagree")) {
                $(".tijiao .checkbox").addClass('checked')
            };

            return false;
        });
    </script>
    <!-- 主图显示 -->
    <script type="text/javascript">
        $(document).ready(function () {
            // 图片上下滚动
            var count = $("#imageMenu li").length - 5; /* 显示 6 个 li标签内容 */
            var interval = $("#imageMenu li:first").width();
            var curIndex = 0;

            $('.scrollbutton').click(function () {
                if ($(this).hasClass('disabled')) return false;

                if ($(this).hasClass('smallImgUp')) --curIndex;
                else ++curIndex;

                $('.scrollbutton').removeClass('disabled');
                if (curIndex == 0) $('.smallImgUp').addClass('disabled');
                if (curIndex == count - 1) $('.smallImgDown').addClass('disabled');

                $("#imageMenu ul").stop(false, true).animate({ "marginLeft": -curIndex * interval + "px" }, 600);
            });

            // 解决 ie6 select框 问题
            $.fn.decorateIframe = function (options) {
                if ($.browser.msie && $.browser.version < 7) {
                    var opts = $.extend({}, $.fn.decorateIframe.defaults, options);
                    $(this).each(function () {
                        var $myThis = $(this);
                        //创建一个IFRAME
                        var divIframe = $("<iframe />");
                        divIframe.attr("id", opts.iframeId);
                        divIframe.css("position", "absolute");
                        divIframe.css("display", "none");
                        divIframe.css("display", "block");
                        divIframe.css("z-index", opts.iframeZIndex);
                        divIframe.css("border");
                        divIframe.css("top", "0");
                        divIframe.css("left", "0");
                        if (opts.width == 0) {
                            divIframe.css("width", $myThis.width() + parseInt($myThis.css("padding")) * 2 + "px");
                        }
                        if (opts.height == 0) {
                            divIframe.css("height", $myThis.height() + parseInt($myThis.css("padding")) * 2 + "px");
                        }
                        divIframe.css("filter", "mask(color=#fff)");
                        $myThis.append(divIframe);
                    });
                }
            }
            $.fn.decorateIframe.defaults = {
                iframeId: "decorateIframe1",
                iframeZIndex: -1,
                width: 0,
                height: 0
            }
            //放大镜视窗
            //$("#bigView").decorateIframe();

            //点击到中图
            var midChangeHandler = null;

            $("#imageMenu li img").bind("click", function () {
                if ($(this).attr("id") != "onlickImg") {
                    midChange($(this).attr("src").replace("small", "mid"));
                    $("#imageMenu li").removeAttr("id");
                    $(this).parent().attr("id", "onlickImg");
                }
            }).bind("mouseover", function () {
                if ($(this).attr("id") != "onlickImg") {
                    window.clearTimeout(midChangeHandler);
                    midChange($(this).attr("src").replace("small", "mid"));
                    $(this).css({ "border": "3px solid #0A84DA" });
                }
            }).bind("mouseout", function () {
                if ($(this).attr("id") != "onlickImg") {
                    $(this).removeAttr("style");
                    midChangeHandler = window.setTimeout(function () {
                        midChange($("#onlickImg img").attr("src").replace("small", "mid"));
                    }, 1000);
                }
            });

            function midChange(src) {
                $("#midimg").attr("src", src).load(function () {
                    changeViewImg();
                });
            }

            //大视窗看图
            function mouseover(e) {
                if ($("#winSelector").css("display") == "none") {
                    //$("#winSelector,#bigView").show();
                }

                //$("#winSelector").css(fixedPosition(e));
                //e.stopPropagation();
            }


            function mouseOut(e) {
                if ($("#winSelector").css("display") != "none") {
                    $("#winSelector,#bigView").hide();
                }
                e.stopPropagation();
            }


            $("#midimg").mouseover(mouseover); //中图事件
            $("#midimg,#winSelector").mousemove(mouseover).mouseout(mouseOut); //选择器事件

            var $divWidth = $("#winSelector").width(); //选择器宽度
            var $divHeight = $("#winSelector").height(); //选择器高度
            var $imgWidth = $("#midimg").width(); //中图宽度
            var $imgHeight = $("#midimg").height(); //中图高度
            var $viewImgWidth = $viewImgHeight = $height = null; //IE加载后才能得到 大图宽度 大图高度 大图视窗高度

            //function changeViewImg() {
            //    $("#bigView img").attr("src", $("#midimg").attr("src").replace("mid", "big"));
            //}

            //changeViewImg();

            //$("#bigView").scrollLeft(0).scrollTop(0);
            
            function fixedPosition(e) {
                if (e == null) {
                    return;
                }
                var $imgLeft = $("#midimg").offset().left; //中图左边距
                var $imgTop = $("#midimg").offset().top; //中图上边距
                X = e.pageX - $imgLeft - $divWidth / 2; //selector顶点坐标 X
                Y = e.pageY - $imgTop - $divHeight / 2; //selector顶点坐标 Y
                X = X < 0 ? 0 : X;
                Y = Y < 0 ? 0 : Y;
                X = X + $divWidth > $imgWidth ? $imgWidth - $divWidth : X;
                Y = Y + $divHeight > $imgHeight ? $imgHeight - $divHeight : Y;

                if ($viewImgWidth == null) {
                    $viewImgWidth = $("#bigView img").outerWidth();
                    $viewImgHeight = $("#bigView img").height();
                    if ($viewImgWidth < 200 || $viewImgHeight < 200) {
                        $viewImgWidth = $viewImgHeight = 800;
                    }
                    $height = $divHeight * $viewImgHeight / $imgHeight;
                    $("#bigView").width($divWidth * $viewImgWidth / $imgWidth);
                    $("#bigView").height($height);
                }

                var scrollX = X * $viewImgWidth / $imgWidth;
                var scrollY = Y * $viewImgHeight / $imgHeight;
                $("#bigView img").css({ "left": scrollX * -1, "top": scrollY * -1 });
                $("#bigView").css({ "top": 233, "left": $(".preview").offset().left + $(".preview").width() - 18 });

                return { left: X, top: Y };
            }

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


<!-- Master Slider -->
<script src="/plugins/master-slider/quick-start/masterslider/masterslider.min.js"></script>
<script src="/plugins/master-slider/quick-start/masterslider/jquery.easing.min.js"></script>
<script src="/js/plugins/master-slider.js"></script>


<div class="modal fade" style="top:50px;" id="ModalVideo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
            <div class="modal-dialog" style="width:600px;">
                <div class="modal-content">
                    <div class="modal-header">
                        <button aria-hidden="true" data-dismiss="modal" class="close" type="button" onclick="PauseVideo();">×</button>
                        <h4 id="H1" class="modal-title">Watch Video</h4>
                    </div>
                    <div class="modal-body">
                             
<div class="responsive-video" id="divResponsiveVideo">
<%=strVideoCode%>
<!--
    <iframe id="frmVideo" src="/Product/HomeVideo.aspx" width="840" height="400" frameborder="0" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>
    -->
</div>
                                     
                    </div>
                                 
                    </div>
            </div>
</div>

    <script type="text/javascript">
        function playPause() {
            var myVideo = $("#prdVideo");
            // if (myVideo.paused)
            myVideo.get(0).play();
            /*
            else
            myVideo.pause();*/
        }
    </script>

</asp:Content>
