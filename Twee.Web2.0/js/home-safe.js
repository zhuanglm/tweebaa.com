// JavaScript Document
$(function(){
        
         $("form").each(function(index, el) {
                var THIS=$(this)
                //文本框失去焦点后
                THIS.find(':input').blur(function(){
                     var $parent = $(this).parent();
                     $parent.find(".error,.ok").hide();
                     //验证用户名  yourname
                     if( $(this).is('.yourname') ){
                           
                            if( this.value=="" || this.value.length < 5  || this.value.length > 20){
                                
                                $parent.find(".error").show();
                                
                            }else{
                                if (isNaN($.trim(this.value).split("")[0])) {

                                     $parent.find(".ok").css('display', 'block');
                                 }
                                 else{
                                       $parent.find(".error").show();
                                 }
                                
                            }
                     }
                     //验证密码
                     var psw1=0;
                     var psw2=0;
                     if( $(this).is('.set-pwd1') ){
                            psw1=this.value
                            if( this.value=="" || this.value.length < 6 || this.value.length > 20){
                                $parent.find(".error").show();
                            }else{
                                $parent.find(".ok").css('display', 'block');
                            }
                     }
                     if( $(this).is('.set-pwd2') ){
                            psw2=this.value
                            
                            if( this.value=="" || ($(".set-pwd1").val()!=psw2)){
                               $parent.find(".error").show();
                            }else{
                                $parent.find(".ok").css('display', 'block');
                            }
                            
                     }
                     //验证邮件
                     if( $(this).is('.safe-email') ){
                        if( this.value=="" || ( this.value!="" && !/.+@.+\.[a-zA-Z]{2,4}$/.test(this.value)) ){
                            $parent.find(".error").show();
                        }else{
                            $parent.find(".ok").css('display', 'block');
                        }

                     }
					 
					 
					  //验证手机号
                     if( $(this).is('.safe-tel') ){
                        if(!/^1\d{10}$/.test(this.value)){
                            $parent.find(".error").show();
                        }else{
                            $parent.find(".ok").css('display', 'block');
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
