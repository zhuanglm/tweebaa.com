<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestFacebookOAuth.aspx.cs" Inherits="TweebaaWebApp.TestFacebookOAuth" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
	<script type="text/javascript" src="../js/FacebookAPI.js"></script>
<script type="text/javascript">
    // This is called with the results from FB.getLoginStatus().
    function FBStatusChangeCallback(response) {
        alert('statusChangeCallback');
        console.log(response);
        // The response object is returned with a status field that lets the
        // app know the current login status of the person.
        // Full docs on the response object can be found in the documentation
        // for FB.getLoginStatus().
        if (response.status === 'connected') {
            // Logged into your app and Facebook.
            testAPI();
        } else if (response.status === 'not_authorized') {
            // The person is logged into Facebook, but not your app.
            document.getElementById('status').innerHTML = 'Please log ' +
        'into this app.';
        } else {
            // The person is not logged into Facebook, so we're not sure if
            // they are logged into this app or not.
            document.getElementById('status').innerHTML = 'Please log ' +
        'into Facebook.';
        }
    }


    // Here we run a very simple test of the Graph API after login is
    // successful.  See statusChangeCallback() for when this call is made.
    function testAPI() {
        console.log('Welcome!  Fetching your information.... ');
        FB.api('/me', function (response) {
            console.log('Successful login for: ' + response.name);
            console.log('Successful login for: ' + response.email);
            document.getElementById('status').innerHTML =
        'Thanks for logging in, ' + response.name + '!' + response.email;
        });
    }


</script>

<!--
  Below we include the Login Button social plugin. This button uses
  the JavaScript SDK to present a graphical Login button that triggers
  the FB.login() function when clicked.
-->

<fb:login-button scope="public_profile,email" onlogin="FBCheckLoginState();">
</fb:login-button>

<input type="button" onclick = "FBLogout()" />logout

<div id="status">
</div>

</body>
</html>
