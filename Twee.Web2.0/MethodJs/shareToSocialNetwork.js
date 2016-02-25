function shareToFacebook() {
    window.open('http://www.facebook.com/sharer.php', '_blank');
    return false;
}

function shareToGooglePlus() {
    u = window.location.href;
    window.open('https://plus.google.com/share?url=' + encodeURI(u), '_blank');
    return false;
}

function shareToTwitter() {
    window.open('https://twitter.com/share', '_blank');
    return false;
}

function shareToPinterest() {
    window.open('http://pinterest.com/pin/create/button', '_blank');
    return false;
}
