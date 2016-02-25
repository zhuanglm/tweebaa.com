$(function(){
	//登陆之后的菜单
	$(".login-ok").mouseenter(function(event) {
		$(this).addClass('on').find(".login-lv2").show();
    }).mouseleave(function (event) {
        // changed by Jack Cao 2015-10-23  ==> always display "my account" and "logout" when user is login.
		//$(this).removeClass("on").find(".login-lv2").hide();
	});

	//消息
	$(".msn").mouseenter(function(event) {
		$(this).addClass('on').find(".msn-lv2").show();
	}).mouseleave(function(event) {
		$(this).removeClass("on").find(".msn-lv2").hide();
	});
	// 购物车
	$("#miniCar").mouseenter(function(event) {
		$(this).find(".car-lv2").show();
	}).mouseleave(function(event) {
		$(this).find(".car-lv2").hide();
	});
	//top
	for (var i = 0; i < $(".top li").length; i++) {
		$(".top li").eq(i).addClass('li' + i)
	};
	

	// 返回顶部
	$("#gotoTop").click(function(event) {
			$('html,body').animate({scrollTop: 0},300)
	});
	// 返回顶部
	$("#gotop").click(function(event) {
			$('html,body').animate({scrollTop: 0},300)
	});

	//2级导航
	$(".top li").each(function(index, el) {
		lv2Menu($(this))
	});



	//table间隙
	$("table").attr({
	 	border: '0',
	 	cellspacing: '0',
	 	cellpadding: '0'
	});

})


//图片居中
function changeImg(obj){
	var objWidth=parseInt($(obj).css("width"))
	var objHeight=parseInt($(obj).css("height"))
	var imgWidth=parseInt($(obj).find("img").css("width"))
	var imgHeight=parseInt($(obj).find("img").css("height"))
	var marLeft=(objWidth-imgWidth)/ 2;
	var marTop=(objHeight-imgHeight)/ 2;
	$(obj).find("img").css({"margin-top":marTop+"px"})
}

//2及菜单
var _tip = "";
function lv2Menu(obj){

	//obj.get(0).timer=null
    function hideFun() {
        var tid = $(obj).attr("id");
        if (_tip == tid)
            return;
        else
		   obj.find('.lv2').hide();
	}
	function showFun(){
		$(".top").find('.lv2').hide()
		clearTimeout(obj.get(0).timer)
		obj.find('.lv2').show();
	}
	obj.mouseenter(function(event) {
		showFun()
	}).mouseleave(function(event) {
		setTimeout(hideFun,300)
	});

	obj.find('.lv2').mouseenter(function (event) {
	    _tip = $(this).parent().attr("id"); 
	})
	obj.find(".lv2").mouseleave(function (event) {
	    _tip = "";
	    $(this).hide();
	})

}

function SavePopupCookie(cookiename) {

    $.cookie(cookiename, 1, { expires: 365 });

}