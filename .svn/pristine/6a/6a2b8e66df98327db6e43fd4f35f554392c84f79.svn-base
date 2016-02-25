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
                     $parent.find(".formtips").remove();
                     //验证用户名  yourname
                     if( $(this).is('.yourname') ){
                            if( this.value=="" || this.value.length < 6 ){
                                var errorMsg = '请输入至少6位字符.';
                                $parent.append('<span class="formtips onError">'+errorMsg+'</span>');
                            }else{
                                var okMsg = '输入正确.';
                                $parent.append('<span class="formtips onSuccess">'+okMsg+'</span>');
                            }
                     }
                     //验证密码
                     var psw1=null
                     var psw2=null
                     if( $(this).is('.userPwd') ){
                            psw1=this.value
                            if( this.value=="" || this.value.length < 6 ){
                                var errorMsg = '请输入至少6位的密码.';
                                $parent.append('<span class="formtips onError">'+errorMsg+'</span>');
                            }else{
                                var okMsg = '输入正确.';
                                $parent.append('<span class="formtips onSuccess">'+okMsg+'</span>');
                            }
                     }
                     if( $(this).is('.userPwd2') ){
                            psw2=this.value
                            if( this.value=="" || this.value.length < 6){
                                var errorMsg = '请输入至少6位的密码.';
                                $parent.append('<span class="formtips onError">'+errorMsg+'</span>');
                            }else{
                                var okMsg = '输入正确.';
                                $parent.append('<span class="formtips onSuccess">'+okMsg+'</span>');
                            }
                            
                     }
                     //验证邮件
                     if( $(this).is('.email') ){
                        if( this.value=="" || ( this.value!="" && !/.+@.+\.[a-zA-Z]{2,4}$/.test(this.value) ) ){
                              var errorMsg = '请输入正确的E-Mail地址.';
                              $parent.append('<span class="formtips onError">'+errorMsg+'</span>');
                        }else{
                              var okMsg = '输入正确.';
                              $parent.append('<span class="formtips onSuccess">'+okMsg+'</span>');
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