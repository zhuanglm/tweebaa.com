<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="submitReview.aspx.cs" Inherits="TweebaaWebApp.Product.submitReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
<%=_model.name%> - Tweebaa needs your opinion
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <script src="../Js/util.js" type="text/javascript"></script>
    <script src="../Js/xd.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../Css/scroll.css?v=1" />
    <link href="../Js/jpager/pagination.css" rel="stylesheet" />
    <link href="../Css/shareBox.css?v=<%=_sCurVer%>" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Js/jquery.xScroller.js"></script>
    <link rel="stylesheet" href="../Css/selectCss.css?v=<%=_sCurVer%>" />    
    <script src="../MethodJs/submitReview.js?v=<%=_sCurVer%>" type="text/javascript"></script>
    <script src="../MethodJs/prd.js?v=<%=_sCurVer%>" type="text/javascript"></script>
    <script src="../MethodJs/share.js?v=<%=_sCurVer%>" type="text/javascript"></script>
    <script src="../MethodJs/VisitTimer.js?v=<%=_sCurVer%>" type="text/javascript"></script>
    <script src="../Js/swfobject.js" type="text/javascript"></script>
    <script src="../MethodJs/videoPlay.js" type="text/javascript"></script>
    <script src="../Js/jpager/jquery.pagination.js"></script>
    <script src="../Js/jpager/members.js"></script>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <input type="hidden" id="hid_proid" value="<%=_proid %>" />
    <input type="hidden" id="hiduserid" value="<%=_userid %>" />
    <div class="h10">
    </div>
    <div class="pingshen-main">
        <div class="w975">
        </div>
        <div class="w975 mbx">
            <a href="../index.aspx">Home ></a> 
            <a href="prdReviewAll.aspx">Evaluate</a> >
            <a href="" style=" display:none;"><label id="labCateTile"></label></a><%-->--%> 
            <b class="l">Product Details</b>
        </div>
        <div class="w975 pingshen-box">
            <!-- 产品描述 -->
            <div class="title">
             <a href="javascript:void(0)" class="fr sharelink" id="hrefShare1" style=" width:55px; margin-left:20px;">Share</a>
              <span class="psjl fr" ><a class="rewardtips" href="#rewardtips">Reward<span>When you evaluate Tweebaa products, you can EARN!<br /> · Reward points for each completed evaluation<br /> 
· You may also receive Free Gifts and Commissions<br /> 
· You can evaluate up to 10 products each day; the more you evaluate, the more you can earn!</span></a></span>
               <%--<div style=" border:solid 1px red; width:450px; word-spacing-break:break; height:80px; text-align:left;">--%>
                <h1 class="fl">                 
                    <strong>                     
                       <label itemprop="name"  id="pro-name" ><% =System.Web.HttpUtility.HtmlEncode(_model.name)%>
                        </label>
                    </strong>                   
                </h1>
                <%-- </div>--%>
                <span class="fl publisher"><%--Submitter--%> 
                    <label id="pro-user">
                    </label>
                </span><span class="fl subtime">Submitted on 
                    <label id="pro-time">
                    </label>
                </span><%--<span class="fl funbtn"><a href="#" class="qubao">Report</a></span>--%>
            </div>
            <div class="des-box clearfix">
                <!-- 描述 -->
                <div class="product-des fr">
                    <div class="des-txt" style="height:auto;">
                        <label itemprop="description" id="pro-jl"><% =System.Web.HttpUtility.HtmlEncode(_model.txtjj) %>
                        </label>
                    </div><br />
                    <div class="product-price">
                    
                    <div class="jdt fr" id="reviewProgress" style="display:none">
                       <div class="jdt-line pr">
                          <b style="left: <%=_leftMargin%>;"><span id="reviewCount" style="<%=_styleMarginLeft%>"><%=_passCount %> Evaluations </span></b>
                        </div>
                        <div class="price-number">
                           <span class="span1">0</span><span class="span2">100</span>
                           <span class="span3">200</span>
                           <span class="span4">300+</span>
                        </div>
                     </div>
                         
                     <span class="fl">Price&nbsp;<strong>$ <label id="pro-price" style=" margin-left:-10px;"></label></strong></span>
                     <span class="fr des-txt" id="lblCurrentStatus" style="display:none" >
						Current Status:
					 </span>
                       
                    </div>
                    <div class="select-submit">
                        <div id="divAlreadyEvaluated" style="<% =_sDispAlreadyEvaluated %>"><p style="color:Blue"><strong><% =_sAlreadyEvaluatedMsg %></strong></p></div>
                        <ul>
                            <li class="clearfix h30"><span class="fl">Would you purchase this product?</span>
                                <script type="text/javascript">
                                    function chkFuc(id1, id2) {
                                        var i = $("#" + id1).attr("checked");
                                        if (i == "checked") {
                                            $('#' + id2).removeAttr('checked')
                                        }
                                    }
                                </script>
                                <div class="chklist fl chklist1">
                                    <input type="checkbox" value="1" id="ckb1" <% =_sYesNoArr[0] %> <%=_disabled %> onclick="chkFuc('ckb1','ckb2')"  /><label> Yes</label>
                                    <input type="checkbox" value="2" id="ckb2" <% =_sYesNoArr[1] %> <%=_disabled %> onclick="chkFuc('ckb2', 'ckb1')"/><label> No</label>
                                </div>                              
                                <strong class="fl" style="color: #f00; display: none">*Please select one</strong>
                            </li>
                            <li class="clearfix h30"><span class="fl" >Do you feel this product is unique?</span>
                                <div class="chklist fl chklist2">
                                    <input type="checkbox" value='3' id="ckb3" <% =_sYesNoArr[2] %> <%=_disabled %> onclick="chkFuc('ckb3', 'ckb4')" /><label> Yes</label>
                                    <input type="checkbox" value='4' id="ckb4" <% =_sYesNoArr[3] %> <%=_disabled %> onclick="chkFuc('ckb4', 'ckb3')" /><label> No</label>
                                </div>                             
                                <strong class="fl" style="color: #f00; display: none">*Please select one</strong>
                            </li>
                            <li class="clearfix h30"><span class="fl">Do you feel this product is needed?</span>
                                <div class="chklist fl chklist3">
                                    <input type="checkbox" value='5' id="ckb5" <% =_sYesNoArr[4] %> <%=_disabled %> onclick="chkFuc('ckb5', 'ckb6')" /><label> Yes</label>
                                    <input type="checkbox" value='6' id="ckb6" <% =_sYesNoArr[5] %> <%=_disabled %> onclick="chkFuc('ckb6', 'ckb5')" /><label> No</label>
                                </div>                             
                                <strong class="fl" style="color: #f00; display: none">*Please select one</strong>
                            </li>
                            <li class="clearfix h30" style="width:510px;"><span class="fl">Do you think this product will go to Tweebaa Shop eventually?</span>
                                <div class="chklist fl chklist4">
                                    <input type="checkbox" value='7' id="ckb7" <% =_sYesNoArr[6] %> <%=_disabled %> onclick="chkFuc('ckb7', 'ckb8')" /><label> Yes</label>
                                    <input type="checkbox" value='8' id="ckb8" <% =_sYesNoArr[7] %> <%=_disabled %> onclick="chkFuc('ckb8', 'ckb7')" /><label> No</label>
                                </div>                             
                                <strong class="fl" style="color: #f00; display: none">*Please select one</strong>
                            </li>
                            <li class="clearfix">
                                <div class="areabox pr">
                                    <textarea rows="5" id="reason-case" name="message" maxlength="200" style=" height:50px;" placeholder="<%=_placeholder %>" <%=_disabled %>></textarea> <br /><br />                
 <strong class="tips" style="color: #f00; display: none; width:510px;">*Please include your reason or suggestion!</strong>                   
                                </div>
                              
                                <%--  <strong class="fl" style="color: #f00; display: none" id="strong3">*请填写评审理由</strong>--%>
                            </li>
                            
                            <li class="tijiao" style=" padding:0px;">
                                <input type="button" class="to-examine  fr" value="Evaluate" id="product-release"
                                    onclick="SubmitReview()" <%=_disabled %> />           
                                  
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
                                </div-->
                            </li>
                        </ul>
                    </div>
                </div>
                <!-- 主图 -->
                <div class="preview fl">
                    <div id="vertical" class="bigImg">
                        <img itemprop="image" src="<% =_imgUrl %>" width="400" height="400" alt="" id="midimg" />
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
                    <a href="javascript:;">Details</a> <a href="javascript:;" id="hrfComments"style="display: inline-block;">Comments(<%=_passCount %>)</a>
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
                    <div class="tc" id="pro-info" style="word-break:break-word;">
                    </div>
                </div>
                <div class="itembox">
                    <ul class="pinglun-list">
                    </ul>

                    <div id="Pagination" class="pagination" style="margin:5px; float:right; padding-right:40px;"></div>
                    <div style="clear:both;"></div>
              <form name="paginationoptions" style=" display:none;">
                <% 
                    // calculate the total links 
                    int iTotalNumberOfLink = int.Parse(_passCount)/10;
                    if ((int.Parse(_passCount) % 10) != 0 )iTotalNumberOfLink ++;
                %>
                <p><label for="items_per_page">Number of items per page</label><input type="text" value="10" name="items_per_page" id="items_per_page" class="numeric"/></p>
                <p><label for="num_display_entries">Number of pagination links shown</label><input type="text" value="<% =iTotalNumberOfLink %>" name="num_display_entries" id="num_display_entries" class="numeric"/></p>
                <p><label for="num">Number of start and end points</label><input type="text" value="0" name="num_edge_entries" id="num_edge_entries" class="numeric"/></p>
                <p><label for="prev_text">"Previous" label</label><input type="text" value="Prev" name="prev_text" id="prev_text"/></p>
                <p><label for="next_text">"Next" label</label><input type="text" value="Next" name="next_text" id="next_text"/></p>
                <input type="button" id="setoptions" value="Set options" />
            </form>

                    <script type="text/javascript">
                        function pageselectCallback(page_index, jq) {
                            //alert(page_index);
                            var pageSize = parseInt($('#items_per_page').val());
                            //alert(pageSize);
                            var index = parseInt(page_index);
                            var startId = pageSize * index + 1;
                            //alert(startId);
                            var endId = startId + pageSize - 1;
                            //alert(endId);

                            LoadReviewInfo(startId,endId);



                            return false;
                        }

                        // The form contains fields for many pagiantion optiosn so you can
                        // quickly see the resuluts of the different options.
                        // This function creates an option object for the pagination function.
                        // This will be be unnecessary in your application where you just set
                        // the options once.
                        function getOptionsFromForm() {
                            var opt = { callback: pageselectCallback };
                            // Collect options from the text fields - the fields are named like their option counterparts
                            $("input:text").each(function () {
                                opt[this.name] = this.className.match(/numeric/) ? parseInt(this.value) : this.value;
                            });
                            // Avoid html injections in this demo
                            var htmlspecialchars = { "&": "&amp;", "<": "&lt;", ">": "&gt;", '"': "&quot;" }
                            $.each(htmlspecialchars, function (k, v) {
                                opt.prev_text = opt.prev_text.replace(k, v);
                                opt.next_text = opt.next_text.replace(k, v);
                            })
                            return opt;
                        }

                        // When document has loaded, initialize pagination and form
                        $(document).ready(function () {
                            // Create pagination element with options from form
                            var optInit = getOptionsFromForm();
                            //$("#Pagination").pagination(members.length, optInit);
                            $("#Pagination").pagination(<% =_passCount %>, optInit);

                            // Event Handler for for button
                            $("#setoptions").click(function () {
                                var opt = getOptionsFromForm();
                                // Re-create pagination content with new parameters
                                //$("#Pagination").pagination(members.length, opt);
                                $("#Pagination").pagination(<% =_passCount %>, opt);
                            });

                        });

        </script>


                    <%--<div class="page tr">
                        <a href="#" class="on"><</a> <a href="javascript:void(0)">1</a> <a href="javascript:void(0)">
                            2</a> <a href="javascript:void(0)">3</a> <a href="javascript:void(0)">4</a>
                        <a href="javascript:void(0)">5</a> <a href="javascript:void(0)">6</a> <a href="javascript:void(0)">
                            7</a> <a href="javascript:void(0)">8</a> <a href="javascript:void(0)" class="down">></a>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
    <!-- 列表	 -->
    <div class="w975" style=" display:none;">
        <p class="product-recommend">
            Recommendation
        </p>
    </div>
    <div class="w975" id="mainsrp-itemlist" style=" display:none;">
        <div class="m-itemlist">
            <div class="items clearfix">
            </div>
            <div class="down-more tc">
                <a href="#" id="down-more">View More</a>
            </div>
        </div>
    </div>
    <div>
    <br /> <br /> <br />
    </div>
  
   <!-- 评审成功 -->
   <div class="greybox">
		<div id="ps-ok" class="ps-ok">
			<div class="ps-ok pr">
				<a href="prdReviewAll.aspx" class="closeBtn2"></a>
                <br /> <br />
				<h1 class="tc fb l3">Thank you for your evaluation<br /><span style=" font-size:12px;">You can review the status of all your Evaluations by logging on to your account.<br />If you want to support this product so it ultimately reaches the Tweebaa Shop, <br />try sharing it with your network.</span></h1>
				<ol class="clearfix">
					<li class=" on">
						<em class="s"></em>						
					</li>
					<li>
						<em class="s"></em>
						
					</li>
                 
					<li class="third">
						<em>
							<b class="fb l3">Free Gift</b>
						</em>
						<i>
							<b class="fb l3">Commission</b>
						</i>
					</li>	
					
				</ol>
				<div class="clear"></div>
				<div class="txt">
					<span style="padding-left:70px;">Evaluate</span><span style="padding-left:10px;">Evaluating Passed</span><span style="padding-left:35px;">Test-Sale Passed</span><span style="padding-left:80px;">Shop - Buy Now</span>
				</div>

			</div>
			<div class="hui" style=" font-size:12px;">
				<span class="ckfb">
					<a href="prdReviewAll.aspx">Evaluate More</a>
				</span>
				<!--span class="jxfb">
					<a href="javascript:void(0)" onclick="$('#pingshenClose').click();cancelSetInterval(); refesh();">All Evaluations</a>
				</span-->
				<span class="fx">
					<a href="../Home/Index.aspx?page=homeReview">My Evaluations</a>
				</span>
                <script type="text/javascript">
                    function refesh() {
                        //location.reload();
                        window.location.href = window.location.href + "&reviewe=all";
                    }
                </script>
			</div>
			<div class="return-index" style="display:none;">
				<a href="prdReviewAll.aspx" class="l3">Back to Evaluate homepage</a>
			</div>
			<div class="dao321 tc" style="display:none;">
				<b class="dao15">25</b> seconds，automatically returns to homepage 			</div>
		</div>
   </div>

    <!-- 评审失败弹出框 -->
    <div class="greybox">
        <div id="tck3" class="tck">
            <div class="pr">
                <a href="#" class="closeBtn" title="关闭"></a>
                <h5>
                    <strong>我有办法</strong></h5>
                <div class="box">
                    <textarea name="" id="" cols="25" rows="7" placeholder="请根据产品评审失败的原因，提交您的解决方案"></textarea>
                    <div>
                        <a href="#" class="iagree fr">提交</a>
                        <p class="fl">
                            如果你没有在个人中心完善过你的个人资料，请在文本框中输入你的联系方式、姓名。提交成功后，客服将会根据你的信息价值与你联系，谢谢。
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
   
   <%-- 分享弹出ydf--%>
     <div class="greybox">
        <div id="share-tck2" class="tck">
            <a href="#" class="closeBtn" title="Close"></a>
            <h2 class="t">
                <span>Share & Earn</span>
            </h2>
             <div class="box">
                <div class="sharebox clearfix my-dietu">
                    <span class="fl t ">Share to </span>
                    <div class="bdsharebuttonbox fl">                          
                        <% // include all share method  %>        
                        <!--#include file="../include/sharemethod.inc" -->
                    </div>                  
                    <a href="#" style="display:none;" class="share-media-set">Share Binding setting</a>
                </div>
                <div class="ps clearfix">
                    <span class="fr"><a href="#"></a></span><span class="fl">Invite your friends to support this product by taking a short survey.</span>
                </div>
            </div>         
        </div>
    </div> 

    <script type="text/javascript">
        //表单提示
        $('input,textarea').placeholder();


        var setIntervalID; //ydf       

        //发布
        function fubuFun(obj, urllink) {
            obj.parents(".greybox").show()
            obj.animate({ top: "5%" }, 300)
            //倒计时开始
            //            setIntervalID = setInterval(function () {
            //                var dao123 = parseInt(obj.find(".dao15").html())
            //                dao123--;
            //                obj.find(".dao15").html(dao123)
            //                if (dao123 == 0) {
            //                    window.location.assign(urllink)
            //                };
            //            }, 1000)
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
        //$('#chklist,.chklist').hcheckbox();

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
                $(".tijiao .chklist > input").attr('checked', true);
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

        //限制字符个数
        function limitLenth(txt, num, tip) {
            var txtid = "#" + txt;
            //var text = $(txtid).val();
            var text = $(txt).val();
            var counter = text.length;
            var tipid = "#" + tip;
            $(tipid).attr("color", "Red");
            $(tipid).text(num - counter);    //每次减去字符长度
            if (parseInt(counter) > parseInt(num)) {
                var str = text.substring(0, num);
                $(txt).val(str);
                $(tipid).text("0");

            }

        };
    </script>
</asp:Content>
