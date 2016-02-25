//账户激活
$(document).ready(function () {

    // set loging href 
    $("#hrefLogin").attr("href", document.location.origin + "/user/login.aspx");

    var Request = new Object();
    Request = GetRequest();
    var id = Request["id"];
    var _data = 'id=' + id;
    //alert(id);
    $.ajax({
        type: "GET",
        url: '/AjaxPages/registerAjax.aspx',
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


