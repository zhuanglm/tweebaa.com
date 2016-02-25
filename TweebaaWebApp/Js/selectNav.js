$(function(){
	//select 菜单
	$("#selectnav").find(".select1").mouseenter(function(event) {
		$(this).addClass('hover')
		
	}).mouseleave(function(event) {
		$(this).removeClass('hover')
		
	});


	$("#selectnav").find(".select2").click(function(event) {
		$(this).addClass('hover')
		$(this).find("ul").show();

	}).mouseleave(function(event) {
		$(this).removeClass('hover')		
		$(this).find("ul").hide();

	});


	$(".select1-nav ul > li").mouseenter(function(event) {
		$(this).addClass('hover')
	}).mouseleave(function(event) {
		$(this).removeClass('hover')
	});

	$(".select2-nav").find("a").click(function(event) {
	   var select2Data=$(".select2 > h2")
	   select2Data.attr('s-data',$(this).attr('s-data'));
	   select2Data.text($(this).text())
	   $(".select2-nav").hide();
	   return false;
	});





	
	
})