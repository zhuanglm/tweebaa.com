//账户激活
$(document).ready(function () {
    var Request = new Object();
    Request = GetRequest();
    var id = Request["id"];
    var _data = 'id=' + id;
    //alert(id);
    $.ajax({
        type: "GET",
        url: '../AjaxPages/registerAjax.aspx',
        data: _data,
        success: function (msg) {
            //alert(msg);
            if (msg != "Activation failed") {
                $("#pName").html("Dear " + msg);
            }
            else {
                $("#pName").html("Dear " + "");
            }

        },
        error: function (msg) {
            alert("Activation failed");

        }
    });
}); 

//接收URL参数
function GetRequest() {
  
  var url = location.search; //获取url中"?"符后的字串
   var theRequest = new Object();
   if (url.indexOf("?") != -1) {
      var str = url.substr(1);
      strs = str.split("&");
      for(var i = 0; i < strs.length; i ++) {
         theRequest[strs[i].split("=")[0]]=(strs[i].split("=")[1]);
      }
   }
   return theRequest;
}
