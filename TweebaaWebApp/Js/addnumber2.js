$(function(){

   var objNumberBox=$(".number")

   objNumberBox.each(function(index, el) {
   	   var reduceNumber=$(this).find(".left-btn")
	   var addNumber=$(this).find(".right-btn")
	   var objNumber=$(this).find(".num")

	   objNumber.keyup(function(event) {
	   	   this.value=this.value.replace(/\D/g,'')
	   }).change(function(event) {
	   	   this.value=this.value.replace(/\D/g,'')
	   	   this.value=parseInt(this.value)
	   });

	   // 增加
	   addNumber.click(function(){
	   		objNumber.val(parseInt(objNumber.val()) +1);
	   })
	   reduceNumber.click(function(){
	   		objNumber.val(parseInt(objNumber.val()) -1);
	   		if (parseInt(objNumber.val())<1) {
	   			objNumber.val(1)
	   		};
	   })

   });



   //加入购物车
   $(".gotoCar").click(function(event) {
   	   $(".car").text(parseInt( $(".car").text()) +1)
   	   objBig.eq(isnow).css({zIndex: '10'}).fadeTo('400',1).siblings('li').fadeTo('400', 0).css({zIndex: '1'});
   });

})