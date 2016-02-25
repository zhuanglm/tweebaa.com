(function($){



$.fn.shopcarFloat = function() {
        function GT(o){T=o.offsetTop;if(o.offsetParent!=null)T+=GT(o.offsetParent);return T;}
        var position = function(element) {
                var top = parseInt(GT(element.get(0)))
                //console.log(top)
                $(window).scroll(function() {
                        var scrolls = $(this).scrollTop();
                         //console.log("__"+scrolls,"__"+top,"__"+$(window).height())
                        if (scrolls > top-$(window).height()) {  
                            element.css({
                                    position: "static",
                                    marginBottom:"25px"
                            }); 
                             //console.log("到了")          
                        }else {
                                element.css({
                                        position:"fixed",
                                        marginBottom:"0px"
                                }); 
                                //console.log("走了")    

                        }
                });
};
        return $(this).each(function() {
                position($(this));                                                 
        });
};
})(jQuery);



$(function(){
    $(".settlement-box").shopcarFloat()

    $(".pro-list-t .tab > a").click(function(){
        $(".settlement-box").shopcarFloat()
    })
})