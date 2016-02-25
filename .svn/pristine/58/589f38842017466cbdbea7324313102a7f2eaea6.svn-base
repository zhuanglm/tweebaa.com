// JavaScript Document
$(function(){
        // $("form :input.required").each(function(){
        //     var $required = $("<strong class='high'> *</strong>"); //创建元素
        //     $(this).parent().append($required); //然后将它追加到文档中
        // });
         $("form").each(function(index, el) {
                var THIS=$(this)
                //文本框失去焦点后
                THIS.find(':input').blur(function(){
                     var $parent = $(this).parent();
                     $parent.find(".error,.ok").hide();
                    
                     if( $(this).is('.email') ){
                        // if( this.value=="" || ( this.value!="" && !/.+@.+\.[a-zA-Z]{2,4}$/.test(this.value) && !/^1\d{10}$/.test(this.value)) ){
                        //     $parent.find(".error").show();
                        // }else{
                        //     $parent.find(".ok").css('display', 'block');
                        // }

                        //判断类型

                        if (/^1\d{10}$/.test(this.value)) {
                            $(".yzm-style").hide();
                            $(".yzm-style").eq(1).show()
                            $("#yzm-style").text('手机验证码')
                        }else{
                            $(".yzm-style").hide();
                            $(".yzm-style").eq(0).show()
                            $("#yzm-style").text('验证码')
                        }




                     }
                }).keyup(function(){
                   $(this).triggerHandler("blur");
                }).focus(function(){
                     $(this).triggerHandler("blur");
                });//end blur

                
                //提交，最终验证。
                 THIS.find('.send').click(function(){
                        THIS.find(" :input").trigger('blur');
                        var numError =THIS.find('.onError').length;
                        if(numError){
                            return false;
                        } 
                        
                 });

                //重置
                 $('#res').click(function(){
                        $(".formtips").remove(); 
                 });


                 function trim(str)
                         { 
                             return str.replace(/(^\s*)|(\s*$)/g, ""); 
                     }


         });
})
