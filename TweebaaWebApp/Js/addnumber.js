$(function(){

   var objNumberBox=$(".number-box")

   objNumberBox.each(function(index, el) {
   	   var reduceNumber=$(this).find(".jia-btn")
	   var addNumber=$(this).find(".jian-btn")
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


})