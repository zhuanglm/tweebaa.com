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
                     //验证邮编
                     if( $(this).is('.textZip') ){
                           var resTel=/^[0-9]+$/;

                            if( (this.value.length==6 || this.value.length==5) && !resTel.test(this)){
                                
                                $parent.find(".ok").show();
                                
                            }else{
                                
                               $parent.find(".error").show();
                                                               
                            }
                     }
                     //areaall 

                     if( $(this).is('.areaall') ){
                          

                            if( this.value.length<5 || this.value.length>120){
                                
                                $parent.find(".error").show();
                                
                            }else{
                                 $parent.find(".ok").show();                                
                                                               
                            }
                     }

                    //验证手机号
                     if( $(this).is('.phoneNum') ){
                           validatemobile2(this.value) 
                           if (this.value.split("")[0]==0) {
                             validatemobile2(this.value) 
                           }else{
                              validatemobile(this.value) 
                           }
                           function validatemobile(phone) 
                               {
                                   var myreg = /^\d{10}$/; 
                                   if(!myreg.test(phone)) 
                                   { 
                                       $parent.find(".error").show();
                                   }else{

                                       $parent.find(".ok").show();
                                   }
                           } 
                          function validatemobile2(phone) 
                               {
                                   var myreg = /^\d{10}$/;
                                   if(!myreg.test(phone)) 
                                   { 
                                       $parent.find(".error").show();
                                   }else{

                                       $parent.find(".ok").show();
                                   }
                               } 
                         }


                    //检验姓名：姓名是2-15字的字符
                    if( $(this).is('.name') ){
//                        if (!isCardName(this.value))
//                         {
//                            $parent.find(".error").show();
//                        }else{

//                          $parent.find(".ok").show();
//                      }
                        if (this.value.length < 2 || this.value.length > 25) {
                          $parent.find(".error").show();
                      }
                      else {
                          $parent.find(".ok").show();
                      }
                        
                        function isCardName(s) 
                        {
                            var patrn = /^\s*[\u4e00-\u9fa5]{1,}[\u4e00-\u9fa5.·]{0,25}[\u4e00-\u9fa5]{1,}\s*$/; 
                            if(!patrn.exec(s))
                            {
                                return false;
                            }
                            return true;
                        }

                    }

                     
                }).keyup(function(){
                   //$(this).triggerHandler("blur");
                }).focus(function(){
                     var $parent = $(this).parent();
                     $parent.find(".error,.ok").hide();
                    // $(this).triggerHandler("blur");
                });//end blur
                //邮箱获取焦点时，灰色提示显示
                $('.email').focus(function(event) {
                     $(".zc-tel-tips").show();
                });
                
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
                // 取文本长度
                function getStrLength(strValue) {
                var strLength = strValue.length;
                    for (var j = 0; j < strValue.length; j++) {
                        if (strValue.charCodeAt(j) > 255) {
                            strLength++;
                        }
                    }
                    return strLength;
                }

                // 判断手机号
                

         });
})
