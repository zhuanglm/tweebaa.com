$(document).ready(function(){

	
	//弹窗
	var docHeight = $(document).height();
	var docWidth = $(document).width();
	var winWidth = $(window).width();
	var winHeight = $(window).height();
	var opWidth = $(".overlay-win").width();
	var opHeight = $(".overlay-win").height();
	
	$("#overlay-mask").height(winHeight);
	$(".overlay-win").css({
		'left':(docWidth-opWidth)/2,
		'top':(winHeight-opHeight)/2
	});
	//举报&投诉表单
	$("#btn-jbfm").click(function(){
	  $("#overlay-mask").fadeIn();
	  $("#overlay-jbfm").fadeIn();
	})
	$("#btn-jbfm-close").click(function(){
	  $("#overlay-mask").fadeOut();
	  $("#overlay-jbfm").fadeOut();	
	})
	//举报&投诉详情
	$(".jb-dt").click(function(){
	  $("#overlay-mask").fadeIn();
	  $("#overlay-jbdt").fadeIn();
	})
	$("#btn-jbdt-close").click(function(){
	  $("#overlay-mask").fadeOut();
	  $("#overlay-jbdt").fadeOut();	
	})
	$("#btn-jbdt-close2").click(function(){
	  $("#overlay-mask").fadeOut();
	  $("#overlay-jbdt").fadeOut();	
	})
	
	//提示信息
	$("#btn-refund").click(function(){
	  $("#overlay-mask").fadeIn();
	  $("#overlay-info").fadeIn();
	})
	$("#op-close").click(function(){
	  $("#overlay-mask").fadeOut();
	  $("#overlay-info").fadeOut();	
	})
	$("#btn-ok").click(function(){
	  $("#overlay-mask").fadeOut();
	  $("#overlay-info").fadeOut();	
	})
	
	//收益提现
//	$("#btn-mention").click(function(){
//	  $("#overlay-mask").fadeIn();
//	  $("#overlay-mention").fadeIn();
//	});
//	$("#btn-mention-close").click(function(){
//	  $("#overlay-mask").fadeOut();
//	  $("#overlay-mention").fadeOut();	
//	})
	
	//晒收益
	$(".share").click(function(){
	  $("#overlay-mask").fadeIn();
	  $("#overlay-share").fadeIn();
	});
	$("#btn-share-close").click(function(){
	  $("#overlay-mask").fadeOut();
	  $("#overlay-share").fadeOut();
	});
	
	$(".handle-leaveword-list dl:even").css({"background":"#fff"});
	$("#profit-data tr:odd").addClass("bg");
	$("#profit-data2 tr:odd").addClass("bg");
	
	$(".alipay").click(function(){
	  $(this).addClass("on")	
	});
	
	//学院隐藏菜单
	$("#opNav").click(function(){
	  $(".sideNav").addClass("open");	
	  $(".op").css({"display":"none"});
	  $(".cl").css({"display":"block"});
	});
	$(".op").click(function(){
	  $(".sideNav").addClass("open");
	  $(this).css({"display":"none"});
	  $(".cl").css({"display":"block"});
	});
	
	$("#clNav").click(function(){
	  $(".sideNav").removeClass("open");
	  $(".cl").css({"display":"none"});
	  $(".op").css({"display":"block"});
	});
	$(".cl").click(function(){
	  $(".sideNav").removeClass("open");
	  $(this).css({"display":"none"});
	  $(".op").css({"display":"block"});
	});
	
	$(".sideNavList dl a,span").click(function(){
	  $(".sideNavList").find("dl.cur").removeClass();
	  $(this).closest('dl').addClass('cur');
	})
	$(".sideNavList dl").on("click", "a", function(event) {
		var dl = $(event.delegateTarget);
		dl.toggleClass('on');
	})
	$(".sideNavList dl").on("click", "span", function(event) {
		var dl = $(event.delegateTarget);
		dl.toggleClass('on');
	})
	
	//佣金积分奖励提示
	$(".college-tctrl").hover(function(){
	  $(this).children(".college-tips").css({"display":"block"});	
	},function(){
	  $(this).children(".college-tips").css({"display":"none"});		
	});
	
});


