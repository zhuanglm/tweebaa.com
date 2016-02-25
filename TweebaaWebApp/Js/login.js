// JavaScript Document
$(function(){

         $("form").each(function(index, el) {
                var THIS=$(this)
                //文本框失去焦点后
                THIS.find(':input').blur(function(){
                     //验证密码
                     var psw1=null
                    
                     if( $(this).is('.userPwd') ){
                            psw1=this.value
                            if( this.value=="" || this.value.length < 6 ){
                               // $(".tipsbox").show()
                            }else{
                              // $(".tipsbox").hide()
                            }
                     }
                   
                     //验证邮件  || ( this.value!=""  ) 
                     if( $(this).is('.email') ){
                        if( this.value=="" || ( this.value!="" && !/.+@.+\.[a-zA-Z]{2,4}$/.test(this.value) && !/^1\d{10}$/.test(this.value)) ){
                             $(".tipsbox").show()
                        }else{
                              $(".tipsbox").hide()
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


         });
})
//]]>