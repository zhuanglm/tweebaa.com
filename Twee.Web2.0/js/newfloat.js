(function($){



$.fn.smartFloat = function(f,st,ietop) {
        function GT(o){T=o.offsetTop;if(o.offsetParent!=null)T+=GT(o.offsetParent);return T;}
        var position = function(element) {
                var top = parseInt(GT(element.get(0)))
                if (st) {
                   top=top-parseInt(st)
                };
                
                $(window).scroll(function() {
                        var scrolls = $(this).scrollTop();
                       
                        if (scrolls > top) {
                                if (window.XMLHttpRequest) {
                                        element.css({
                                                position: "fixed",
                                                top: f
                                        });      
                                } else {

                                        element.css({
                                                position: "absolute",
                                                top: scrolls +"px"
                                        }); 
                                        if(ietop){
                                            element.stop().animate({top: scrolls +100 +"px"}, 1000)  
                                        }
                                      
                                }
                        }else {
                                element.css({
                                        position:"",
                                        top:f
                                }); 

                        }
                });
};
        return $(this).each(function() {
                position($(this));                                                 
        });
};
})(jQuery);
