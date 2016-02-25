


function DoTwitterLogin() {
    var _data = "action=TwitterLogin";
    Loading(true);
    $.ajax({
        type: "POST",
        url: '/Twitter/TwitterAPI.aspx',
        data: _data,
        success: function (msg) {
            /*
            if (msg == 0) {
            //登录成功
            window.location.href = "/index.aspx";
            } else if (msg == 1) {
            alert("You already register as our member , please use this email:" + response.email + " to Login");
            } else if (msg == 2) {
            alert("Bind Account error!");
            }*/
            console.log(msg);
            Loading(false);
            
            if (msg.length > 10) {
                window.location.href ="https://twitter.com/oauth/authenticate?oauth_token=" + msg;
                //window.location.href = "/Twitter/TwitterCallback.aspx";
            }
        },
        error: function (msg) {
            Loading(false);
            console.log(msg.responseText);
            alert("Bind Account error!");
            //            $("#labMessage").html("用户名或密码错误！");
            //            $("#greybox1").show();
        }
    });

}