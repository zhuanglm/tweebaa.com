/*
web63.cn
2014-11-27
*/


(function($){
    $.fn.inputFormat = function(options){
        //各种属性、参数
        var defaults={
            c1:"#CCC",
            c2:"#f00"
        }
        var options = $.extend(defaults, options);
        this.each(function(){
            var obj=$(this)
            //设置初始色
            if (obj.attr("type")=="submit" || obj.attr("type")=="reset" || obj.attr("type")=="button") {
                //排除按钮
            }else {
                //设置初始色
                obj.css('color',options.c1);
                //保存初始值
                var thisval=obj.val()
                //非密码执行
                if(obj.attr("type")!="password" ){
                    obj.focus(function(event) {
                     
                     if (obj.val()==thisval) {
                        obj.val("")
                     };
                     obj.css('color',options.c2);
                    });
                    obj.blur(function(event) {
                        if (obj.val()=="") {
                            obj.val(thisval)
                            obj.css('color',options.c1);
                        };
                    });
                }
             
                //如果是密码框 
                if(obj.attr("type")=="password"){
                    var $left=obj.css('paddingLeft');
                    var $top=obj.css('paddingTop');
                    var $height=obj.height()-parseInt($top) *2 ;
                    var lh=obj.outerHeight()
                    var fl=obj.css('float');
                    //清楚密码占位符
                    obj.val("");
                    var $span="<span class='passwordTxt'>" + "20个字母、数字或者符号" + "</span>"
                    obj.before('<span style="position: relative;display: inline-block;" class="passwordDiv"></span>');
                    obj.siblings('.passwordDiv').css('float',fl).append(obj).append($span).find("span").css({
                        position: 'absolute',
                        left: $left,
                        top:$top,
                        lineHeight:lh+ "px",
                        color:options.c1
                    });
                    obj.focus(function(event) {
                        obj.siblings('.passwordTxt').hide();
                        obj.css('color',options.c2);
                    });
                    obj.siblings('.passwordTxt').click(function(event) {
                         obj.focus();
                         obj.siblings('.passwordTxt').hide();
                         obj.css('color',options.c2);
                    });
                    obj.blur(function(){
                        if (obj.val()=="") {
                           obj.siblings('.passwordTxt').show();
                        };
                    })

                }

            }


        });
    };
})(jQuery);