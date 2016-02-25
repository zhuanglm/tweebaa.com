$(function() {
	
	$('input').placeholder();
	// select 美化
	$(".selects").selectCss();
	//表单美化 
	$('#radiolist').hradio()

	
	//用户中心 侧导航
	// 导航初始化
	$(".home-side-nav").find("i,.item,dl").addClass('hover')
	
	$(".home-side-nav").find("i").click(function(event) {
		if (!$(this).hasClass('hover')) {
			 $(this).addClass('hover').parents(".item").addClass('hover')
		}else{
			$(this).removeClass('hover').parents(".item").removeClass('hover')
		}
	})
	$(".home-side-nav").find("dl").mouseenter(function(event) {
		$(this).addClass('hover')
	})
	$(".home-side-nav").find("dt").click(function(){
		if ($(this).parents("dl").hasClass('hover')) {
			$(this).parents("dl").removeClass('hover')
		}else{
			$(this).parents("dl").addClass('hover')
		}
		
	})

	//站内消息
	$("#s-data").click(function(event) {
		$(this).addClass('active').siblings('.select-list').show();
	})
	$(".select-box").mouseleave(function(event) {
		$(this).find('.select-list').hide();
		$("#s-data").removeClass('active')
	});
	$(".select-list a").click(function(event) {
		$("#s-data").attr('s-data',$(this).attr('s-data'))
		$("#s-data").text($(this).text())
		$(this).parents(".select-list").hide();
		$("#s-data").removeClass('active')
		return false;
	});
	//
	$(".msn-main .look-all").click(function(event) {
		$(this).hide().siblings(".p1").hide().siblings(".txt-all").show();
	});

	//我的供货单
	$(".thistips").each(function(index, el) {
		$(this).css('marginLeft', (- $(this).width() - 10 )/ 2  );
	});
	$(".thistips").parent().hover(function() {
		$(this).find('.thistips').show()
	}, function() {
		$(this).find('.thistips').hide()
	});
});