/*
* @author Lunali
* @email lunali_blog@163.com
* @blog www.lunali.net
* @version 1.0  
* @des 请尊重作者劳动成果，注明出处来源，如有问题，请发致邮箱！
*/

;(function($){
	
	$.fn.scroller = function(options){
	   /*
	   * 默认设置
	   */
	   var defaultSet = {  
		   scrollCon  : '.scrollCon',  //scroll区父级
		   scrollArea : '.scrollArea', //scroll区内容
		   scrollBar  : '.scrollBar',  //滚动条父级
		   scroller   : '.scroller'   //控制滚动按钮
	   }
	   
	   /*
	   * 全局变量
	   */
	   var opts = $.extend({},defaultSet,options),  //合并参数但不覆盖
	       oCon = $(this).find(opts.scrollCon),
	       oArea = $(this).find(opts.scrollArea),
		   oBar = $(this).find(opts.scrollBar),
		   oScroller = $(this).find(opts.scroller),
		   iMaxHeight = oBar.height() - oScroller.height(),
		   T = 0,
		   disY = 0,
		   iScale = 0;
	   	   
	   return $(this).each(function(){
		   
		   /*
		   * oScroller控制
		   */
		   oScroller.on('mousedown',function(e){
			   
			   var elem = $(this);
			   
			   disY = e.clientY - elem.position().top;
			   
			   $(document).on('mousemove',function(e){
				   T = e.clientY - disY;
				   scrollSet();   
			   });
			   
			   $(document).on('mouseup',function(){
				   $(document).off('mousemove', null);
			   });
			   
			   return false;
		   });
		   
		   /*
		   * 鼠标滚轮
		   */
		   oCon[0].onmousewheel = MWScroll;   //绑定鼠标滚轮事件  ----  ie/chrome
		   oBar[0].onmousewheel = MWScroll;
		   
		   if(oCon[0].addEventListener){   //FF
				oCon[0].addEventListener('DOMMouseScroll',MWScroll,false);
				oBar[0].addEventListener('DOMMouseScroll',MWScroll,false);
		   }
		   
		   function MWScroll(ev){    
				var ev = ev || event;
				var btn = true;
				if(ev.wheelDelta){
				   btn = ev.wheelDelta > 0 ? true : false;	   //IE、Opera、Safari、Chrome
				}else{
				   btn = ev.detail < 0 ? true : false;	  //FF
				}
				
				if(btn){
					T = oScroller.position().top - 10;
				}else{
					T = oScroller.position().top + 10;
				}
				
				scrollSet();
				
				if(ev.preventDefault){
				  ev.preventDefault();	
				}
				return false;
		   };
		   
		   /*
		   * Scroller设置(设置滚动条及滚动内容的位置)
		   */
		   function scrollSet(){ 
			  if(T < 0){
				  T = 0;  
			  }else if(T > iMaxHeight){
				  T = iMaxHeight;  
			  }
			  
			  iScale = T / iMaxHeight;
			  oScroller.css({'top':T});
			  oArea.css({'top':(oCon.height() - oArea.height()) * iScale});
			  $(".Scrollbar-Handle-blue").height(T+10)

		   };
		   
	   });
   }
})(jQuery);