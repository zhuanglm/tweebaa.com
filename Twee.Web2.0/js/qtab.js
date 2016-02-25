(function($){
    $.fn.qTab = function(options){
        var defaults={
					tabT:".qTab",//tab title
					tabCon:"qCon",//tab Con
					addclass:"active",
          auto:false,
          autoTimer:3000
				}

        var options = $.extend(defaults, options);
        var This=$(this)
        This.each(function(){
           var $tab=This.find(options.tabT)
           var $tabTon=This.find(options.tabCon)
           	   $tab.css('cursor','pointer');
               var thisNum=0;
           	   $tab.removeClass(options.addclass)
           	   $tab.eq(0).addClass(options.addclass)
           	   $tabTon.hide();
           	   $tabTon.eq(0).show();
           	   $tab.click(function(event) {
                    tabFunction($tab.index(this))
           	   })
               if (timeer) {
                   $tab.mouseenter(function(){
                       clearInterval(timeer)
                   })
                   $tab.mouseleave(function(){
                       timeer=setInterval(func,options.autoTimer)
                   })
               };
               function tabFunction(u){
                    $tab.removeClass(options.addclass)
                    $tab.eq(u).addClass(options.addclass)
                    $tabTon.hide()
                    $tabTon.eq(u).show();
               }
               if (options.auto){
                  var timeer=setInterval(func,options.autoTimer)
               };
               function func(){
                  thisNum++;
                  if (thisNum>=$tab.length) {
                     thisNum=0;
                  };
                  tabFunction(thisNum)
               }
           	   
        });
    };
})(jQuery);