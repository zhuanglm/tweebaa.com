// JavaScript Document


(function($){
    $.fn.myLv2 = function(options){
       	var defaults={
       		obje1:"obj1",
       		obje2:"obj2"
       	}
        var option = $.extend(defaults, options);
        var obj1=$(this).find(option.obje1)
		var obj2=$(this).find(option.obje2)
		var This=this
		This.timer=setTimeout(Thisa,300)
		$(obj1).mouseenter(function(){
				Thisactive()
		})
		$(obj2).mouseenter(function(){
				Thisactive()
		})
		$(obj1).mouseleave(function(){
				This.timer=setTimeout(Thisa,300)
		})
		$(obj2).mouseleave(function(){
				This.timer=setTimeout(Thisa,300)
		})
		function Thisactive(){
			    This.parents(".luru-t").find(option.obje2).hide()
			    This.parents(".luru-t").find(option.obje1).removeClass('on')
				clearTimeout(This.timer)
				$(obj1).addClass("on")
				$(obj2).show()        
		}
		function Thisa(){
				
				$(obj1).removeClass("on")
				$(obj2).hide()        
		}

    };
})(jQuery);