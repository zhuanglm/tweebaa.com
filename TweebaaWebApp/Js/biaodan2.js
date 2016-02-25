// JavaScript Document
$(function(){
        // $("form :input.required").each(function(){
        //     var $required = $("<strong class='high'> *</strong>"); //创建元素
        //     $(this).parent().append($required); //然后将它追加到文档中
        // });
         $("form").each(function(index, el) {
                var THIS=$(this)
                THIS.find('.jstxt').focus(function(event) {
                    var $parent = $(this).parent();
                     $parent.find(".icon-btn").remove();
                     $parent.append('<i class="icon-btn bianji"></i>');
                });
                //文本框失去焦点后
                THIS.find(':input').blur(function(){
                     var $parent = $(this).parent();
                     $parent.find(".icon-btn").remove();
                     //验证名称
                     if( $(this).is('#pro-name') ){
                            if( this.value=="" || this.value.length < 6 ){
                                var errorMsg = '请输入至少6位字符.';
                                $parent.append('<i class="icon-btn cuo"></i>');
                            }else{
                                var okMsg = '输入正确.';
                                $parent.append('<i class="icon-btn dui"></i>');
                            }
                     }
                     //验证描述
                     if( $(this).is('#pro-des') ){
                            if( this.value=="" || this.value.length < 6 ){
                                var errorMsg = '请输入至少6位字符.';
                                $parent.append('<i class="icon-btn cuo"></i>');
                            }else{
                                var okMsg = '输入正确.';
                                $parent.append('<i class="icon-btn dui"></i>');
                            }
                     }
                     //验证网址
                     var urlreg=/^[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/

                     if( $(this).is('#pro-web') ){
                       var url=this.value;
                        if( this.value=="" || (!urlreg.test(url)) ){
                              var errorMsg = '请输入正确的网址.';
                              // this.value=""
                              $parent.append('<i class="icon-btn cuo"></i>');
                        }else{
                              var okMsg = '输入正确.';
                              $parent.append('<i class="icon-btn dui"></i>');
                        }
                     }
                     //验证价格 
                     if( $(this).is('.price-rmb') ){
                        var pricereg=/^\d+(\.{0,1}\d+){0,1}$/
                        if( this.value=="" || (!pricereg.test(this.value)) ){
                              var errorMsg = '请输入正确的价格';
                              $parent.append('<i class="icon-btn cuo"></i>');
                        }else{
                              var okMsg = '输入正确.';
                              $parent.append('<i class="icon-btn dui"></i>');
                        }
                     }
                     
                }).keyup(function(){
                   $(this).triggerHandler("blur");

                }).focus(function(){
                     //$(this).triggerHandler("blur");
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


                 function check(){ 
                    var price=$(".price-rmb").val();
                    if (isNaN(price)) {
                        alert("非法价格！"); 
                        price.value="";
                    } 
                } 
                

         });
})
//]]>