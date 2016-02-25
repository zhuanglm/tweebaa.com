$(function(){

	var obj=$(".settlement-box")
	obj.find(".select-nubmer,.pop-up-cart").mouseenter(function(event) {
		popcartShow()
	}).mouseleave(function(event) {
		popcartHide()
	});

	function popcartShow(){
		clearTimeout(obj.get(0).timer)
		obj.find('.pop-up-cart').show();
		obj.find(".select-nubmer").addClass('on')
	}
	function popcartHide(){
		obj.get(0).timer=setTimeout(function(){
			obj.find('.pop-up-cart').hide();
		},200)
		obj.find(".select-nubmer").removeClass('on')
	}



	var moveobj=obj.find('.box > ul')
	var leftBtn=obj.find(".leftBtn")
	var rightBtn=obj.find(".rightBtn")
	var isnow=0;
	rightBtn.click(function(event) {
		isnow++;
		if(isnow > moveobj.find("li").length - 8){
			isnow=0;
		}
		moveobj.stop().animate({left: -isnow * 110 +"px"}, 500)
		return false;
	});
	leftBtn.click(function(event) {
		isnow--;
		if(isnow < 0){
			isnow=moveobj.find("li").length - 8
		}
		moveobj.stop().animate({left: -isnow * 110 +"px"}, 500)
		return false;
	});


	//单个产品 背景

	$(".pro-list-box").find("table > tr").mouseenter(function(event) {
		$(this).css('background', '#FAF0F1');
	}).mouseleave(function(index, el) {
		$(this).css('background', '');
	});


	//删除商品 
	$(".pro-list-box .delthis").click(function(event) {
		$(".greybox").show();
		$(".del-shop-tck").show();


		return false;
	});

	$(".closeBtn,.cancel-del,.enter-del").click(function(event) {
		$(".greybox").hide();
		$(this).parent().hide();
		if ($(this).is(".enter-del")) {
			$(".del-tips").show()
		};
		return false;
	});



	//收藏夹 和 浏览历史 切换 
	$(".jstabcon").eq(1).hide();
	$(".jstab").find(".tab a").eq(0).addClass('active')
	$(".jstab").find(".tab a").mouseenter(function(event) {
		$(this).addClass('active').siblings('a').removeClass('active');
		$(".jstabcon").eq($(this).index()).show().siblings('.jstabcon').hide();
	});

})