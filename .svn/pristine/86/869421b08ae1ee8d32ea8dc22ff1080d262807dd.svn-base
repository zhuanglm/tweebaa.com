<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="prdReview.aspx.cs" Inherits="TweebaaWebApp.Product.prdReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">   
    <script src="../Js/util.js" type="text/javascript"></script>
    <script src="../Js/xd.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../Css/scroll.css" />
    <script src="../Js/qtab.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
    <script type="text/javascript" src="../Js/jquery.xScroller.js"></script>
    <link rel="stylesheet" href="../Css/selectCss.css" />
    <script src="../Js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/selectNav.js"></script>
    <script src="../Js/swfobject.js" type="text/javascript"></script>
    <script src="../MethodJs/submitReview.js" type="text/javascript"></script>
    <script src="../MethodJs/prd.js" type="text/javascript"></script>
    <script src="../MethodJs/share.js" type="text/javascript"></script>
    <script src="../MethodJs/videoPlay.js" type="text/javascript"></script>
 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <div class="h10">
    </div>
    <div class="pingshen-main">
        <div class="w975">
        </div>
        <div class="w975 mbx">
            <a href="#">Home</a> > <a href="#">Evaluate</a> > <a href="" style=" display:none;">
                <label id="labCateTile">
                </label>
            </a><%-->--%> <b class="l">Product Details</b>
        </div>
        <div class="w975 pingshen-box">
            <!-- 产品描述 -->
            <div class="title">
         <!--      <a href="javascript:void(0)" class="fr sharelink" id="hrefShare1">Share</a>
              <span class="psjl fr"><a class="rewardtips" href="#rewardtips">Reward<span>Evaluators can earn reward points, free gifts and cash.  Evaluate up to 10 products each day...the more you evaluate, the greater your chances of earning.</span></a></span>-->
                <h1 class="fl">
                    <strong>
                        <label id="pro-name">
                        </label>
                    </strong>
                </h1>
                <span class="fl publisher"><%--By--%>
                    <label id="pro-user">
                    </label>
                </span><span class="fl subtime">Submitted on 
                    <label id="pro-time">
                    </label>
                </span><!--<span class="fl funbtn"><a href="#" class="qubao">Report</a>
                    | <a href="#" class="bianji" onclick="backEdit()">Edit</a> </span> -->
            </div>
            <div class="des-box clearfix">
                <!-- 描述 -->
                <div class="product-des fr">
                    <div class="des-txt" style="word-wrap:break-word;">
                        <label id="pro-jl" style="word-wrap:break-word;">
                        </label>
                    </div>
                    <div class="product-price">
                     <!--    <div class="jdt fr">
                            <div class="jdt-line pr">
                                <b style="left: 10%;"><span id="reviewCount">0 Evaluated </span></b>
                            </div>
                            <div class="price-number">
                                <span class="span1">0</span><span class="span2">100</span><span class="span3">500</span><span
                                    class="span4">1000</span>
                            </div>
                        </div>-->
                        <span class="fl">Price&nbsp;<strong>$
                            <label id="pro-price" style=" margin-left:-12px;">
                            </label>
                        </strong></span>
                    </div>
                    <div class="select-submit" style=" font-size:13px;">
                         <ul class="ul">
                            <li class="clearfix h30"><span class="fl">Would you purchase this product?&nbsp;&nbsp;</span>
                                <div class="chklist fl chklist1" style="display:none;">
                                    <input type="checkbox" value="1" id="ckb1"  /><label>Yes</label>
                                    <input type="checkbox" value="2" id="ckb2" /><label>No</label>
                                </div>                              
                                <strong class="fl" style="color: #f00; display: none">*Please select one</strong>
                            </li>
                            <li class="clearfix h30"><span class="fl">Do you feel this product is unique?&nbsp;</span>
                                <div class="chklist fl chklist2" style="display:none;">
                                    <input type="checkbox" value='3' id="ckb3" onselect="$('#ckb4').removeAttr('checked')" /><label>Yes</label>
                                    <input type="checkbox" value='4' id="ckb4" onselect="$('#ckb3').removeAttr('checked')" /><label>No</label>
                                </div>                             
                                <strong class="fl" style="color: #f00; display: none">*Please select one</strong>
                            </li>
                            <li class="clearfix h30"><span class="fl">Do you feel this product is needed?</span>
                                <div class="chklist fl chklist3" style="display:none;">
                                    <input type="checkbox" value='5' id="ckb5" onselect="$('#ckb4').removeAttr('checked')" /><label>Yes</label>
                                    <input type="checkbox" value='6' id="ckb6" onselect="$('#ckb3').removeAttr('checked')" /><label>No</label>
                                </div>                             
                                <strong class="fl" style="color: #f00; display: none">*Please select one</strong>
                            </li>
                            <li class="clearfix h30"><span class="fl">Do you think this product will go to Tweebaa Shop eventually?</span>
                                <div class="chklist fl chklist4" style="display:none;">
                                    <input type="checkbox" value='7' id="ckb7" onselect="$('#ckb4').removeAttr('checked')" /><label>Yes</label>
                                    <input type="checkbox" value='8' id="ckb8" onselect="$('#ckb3').removeAttr('checked')" /><label>No</label>
                                </div>                             
                                <strong class="fl" style="color: #f00; display: none">*Please select one</strong>
                            </li>
                            <li class="clearfix">
                                <div class="areabox pr">
                                    <textarea rows="5" id="reason-case" name="message" maxlength="200" style=" height:70px;" placeholder="Please includes your reason or suggestion, each person can only evaluate 
once.(Max 200 characters)" onkeyup="hideTishi();limitLenth(this,200,'ltesetip')"></textarea>
                                    <strong class="tips" style="color: #f00; display: none;  margin-right:220px;">*Please includes your reason
                                        or suggestion!</strong>
                                </div>
                            </li>
                            <li class="tijiao" style=" padding:0px; list-style:none;">
                                <input type="button" class="to-examine  fr" value="Evaluate" id="product-release"
                                    onclick="SubmitReview()" style=" display:none;" />
                                <div class="fl chklist chklist5" style="position: relative; left: 0; top: 8px; margin-left: 0; display:none;">
                                    <div style="padding: 0px; margin-top: -15px;">
                                        <div>
                                            <input type="checkbox" value="1" checked="checked" />
                                            <label>
                                                I read and agreed with the terms and conditions in</label></div>
                                        <div class="fl" style="margin-top: -20px;">
                                            <a href="#" class="chakan">《Evaluation Agreement》</a></div>
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
                <!-- 主图 -->
                <div class="preview fl">
                    <div id="vertical" class="bigImg">
                        <img src="" width="400" height="400" alt="" id="midimg" />
                        <div style="display: none;" id="winSelector">
                        </div>
                    </div>
                    <!--bigImg end-->
                    <div class="smallImg">
                        <div id="imageMenu">
                            <ul>
                                <li id="onlickImg">
                                    <img src="" id="imgSmall1" width="68" height="68" alt="" />
                                </li>
                                <li>
                                    <img src="" id="imgSmall2" width="68" height="68" alt="" /></li>
                                <li>
                                    <img src="" id="imgSmall3" width="68" height="68" alt="" /></li>
                                <li>
                                    <img src="" id="imgSmall4" width="68" height="68" alt="" /></li>
                                <li>
                                    <img src="" id="imgSmall5" width="68" height="68" alt="" /></li>
                            </ul>
                        </div>
                    </div>
                    <!--smallImg end-->
                    <div id="bigView" style="display: none;">
                        <img width="800" height="800" alt="" src="" id="bigShowImg" /></div>
                </div>
                <!-- 主图 -->
            </div>
            <!-- tab -->
            <div class="w975">
                <div class="tab">
                    <a href="javascript:;">Details</a> <a href="javascript:;">Comments (<label id="labReviewCount">0</label>)</a>
                </div>
            </div>
            <!-- tabCon -->
            <div class="tabCon">
                <div class="itembox">
                    <div class="tc">
                        <iframe id="videoFrame" src=""  frameborder="5" width="500" height="500"></iframe> 
                        <div class="video" id="CuPlayer" style="margin: 0 auto;">
                        </div>
                    </div>
                    <div class="tc" id="pro-info" style="text-align:left; padding-left:15px; word-break:break-word;"><%--overflow: scroll;--%> 
                    </div>
                    
                </div>
                <div class="itembox">
                    <ul class="pinglun-list">
                    </ul>
                    <div class="page tr">
                        <a href="#" class="on"><</a> <a href="javascript:void(0)">1</a> <a href="javascript:void(0)">
                            2</a> <a href="javascript:void(0)">3</a> <a href="javascript:void(0)">4</a>
                        <a href="javascript:void(0)">5</a> <a href="javascript:void(0)">6</a> <a href="javascript:void(0)">
                            7</a> <a href="javascript:void(0)">8</a> <a href="javascript:void(0)" class="down">></a>
                    </div>
                </div>
            </div>
        </div>
        <div class="btn-Group">
            <a href="javascript:void(0)" class="return-sumbmit" style="width:200px;" onclick="backEdit()">Back to Submission</a><%--Continue editing--%>
            <%--<a href="javascript:void(0)" class="submit-product" id="submit-product" onclick="submitPrd()">
                Submit</a>--%>
        </div>
    </div>
  
    <!-- 发布成功 -->
    <div class="greybox">
		<div id="fabu-ok">
			<div class="fubu-ok pr">
				<a href="#" class="closeBtn"></a>
				<h1 class="tc fb l2">Congratulation！<br />Product submitted successfully, it is in approval stage now.</h1>
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
					<span>Submit Product</span><span>Evaluation Passed</span><span>Test-Sale Passed</span><span>Final-Sale</span>
				</div>
			</div>
			<div class="hui">
				<span class="jxfb">
					<a href="issue.aspx">Submit More</a>
				</span>
				<span class="ckfb">
					<a href="../Home/Index.aspx?page=homeSubmit">See I submitted</a>
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
            $("#bigView").decorateIframe();

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
                    $("#winSelector,#bigView").show();
                }

                $("#winSelector").css(fixedPosition(e));
                e.stopPropagation();
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

            function changeViewImg() {
                $("#bigView img").attr("src", $("#midimg").attr("src").replace("mid", "big"));
            }

            changeViewImg();

            $("#bigView").scrollLeft(0).scrollTop(0);
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
</asp:Content>
