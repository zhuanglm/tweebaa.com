﻿
/*
window.fbAsyncInit = function () {
    FB.init({
        appId: '1591110677840145',
        oauth: true,
        status: true,
        cookie: true,  // enable cookies to allow the server to access 
        // the session
        xfbml: true,  // parse social plugins on this page
        version: 'v2.2' // use version 2.2
    });

    // Now that we've initialized the JavaScript SDK, we call 
    // FB.getLoginStatus().  This function gets the state of the
    // person visiting this page and can return one of three states to
    // the callback you provide.  They can be:
    //
    // 1. Logged into your app ('connected')
    // 2. Logged into Facebook, but not your app ('not_authorized')
    // 3. Not logged into Facebook and can't tell if they are logged into
    //    your app or not.
    //
    // These three cases are handled in the callback function.

    //FB.getLoginStatus(function (response) {
    //    FBStatusChangeCallback(response);
    //});

};

// Load the SDK asynchronously
(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
} (document, 'script', 'facebook-jssdk'));
*/

window.fbAsyncInit = function () {
    FB.init({
        appId: '1498416037152658',
        oauth: true,
        status: true,
        cookie: true,  // enable cookies to allow the server to access 
        // the session
        xfbml: true,
        version: 'v2.5'
    });
};

(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
} (document, 'script', 'facebook-jssdk'));

function FBLogout() {
    FB.logout(function (response) {
        // user is now logged out
        // alert(reponse);
    });
}


// This function is called when someone finishes with the Login
// Button.  See the onlogin handler attached to it in the sample
// code below.
function FBCheckLoginState() {
    FB.getLoginStatus(function (response) {
        FBStatusChangeCallback(response);
    });
}


// This is called with the results from FB.getLoginStatus().
function FBStatusChangeCallback(response) {
    // The response object is returned with a status field that lets the
    // app know the current login status of the person.
    // Full docs on the response object can be found in the documentation
    // for FB.getLoginStatus().
    if (response.status === 'connected') {
        // Logged into your app and Facebook.
        BingFaceBooAccount();
    } else if (response.status === 'not_authorized') {
        alert("Facebook login is not successful, please try again later!"); 
        // The person is logged into Facebook, but not your app.
        //document.getElementById('status').innerHTML = 'Please log ' + 'into this app.';
    } else {
            FB.login(function (response) {
                if (response.authResponse) {
                    BingFaceBooAccount();
                } else {
                    console.log('Auth cancelled.')
                }
            }, { scope: 'name,email' });
        //alert("Facebook login is not successful, please try again later!"); 
        // The person is not logged into Facebook, so we're not sure if
        // they are logged into this app or not.
        //document.getElementById('status').innerHTML = 'Please log ' + 'into Facebook.';
    }
}

var fblogin = function () {
    FB.login(function (response) {
        if (response) {
            if (response.authResponse) {
                //successful auth
                //do things like create account, redirect etc.
                /*
                FB.api('/me', { locale: 'en_US', fields: 'name, email' }, function (r) { 
                alert(r.email);
                });*/
                BingFaceBooAccount();
            } else {
                //unsuccessful auth
                //do things like notify user etc.
            }
        }
    }, { scope: 'name,email' });
};

function DoFBLogin() {
    FB.login(function (response) {
        if (response.authResponse) {
            BingFaceBooAccount();
        } else {
            console.log('Auth cancelled.')
        }
    }, { scope: 'name,email' });
}

// Here we run a very simple test of the Graph API after login is
// successful.  See statusChangeCallback() for when this call is made.
function BingFaceBooAccount() {
    //console.log('Welcome!  Fetching your information.... ');
    FB.api('/me', { locale: 'en_US', fields: 'name, email' }, function (response) {  //response = Object {name: "Long Zhou", id: "1498818367113927"
        //console.log(JSON.stringify(response));
        //alert(response.name);
        //alert(response.email);
        //document.getElementById('status').innerHTML =  'Thanks for logging in, ' + response.name + '!' + response.email;
        
        var _data = "{ action:'BindFaceBook"
                    + "',name:'" + response.name
                    + "',email:'" + response.email
                    + "',id:'" + response.id

                    + "'}";
        $.ajax({
            type: "POST",
            url: '/AjaxPages/SNSAjax.aspx',
            data: _data,
            success: function (msg) {
                
                if (msg == 0) {
                    //登录成功
                    window.location.href = "/index.aspx";
                } else if (msg == 1) {
                    alert("You already register as our member , please use this email:" + response.email + " to Login");
                } else if (msg == 2) {
                    alert("Bind Account error!");
                }
            },
            error: function (msg) {
                alert("Bind Account error!");
                //            $("#labMessage").html("用户名或密码错误！");
                //            $("#greybox1").show();
            }
        });

    });
}


