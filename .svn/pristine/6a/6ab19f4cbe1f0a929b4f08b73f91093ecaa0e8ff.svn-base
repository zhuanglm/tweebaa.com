$(document).ready(function () {
    var videoPath = "https://tweebaa.com/"; //http://192.168.1.10/
 
    var so = new SWFObject("../css/PlayerLite.swf", "CuPlayerV4", "520", "325", "9", "#000000");
    so.addParam("allowfullscreen", "true");
    so.addParam("allowscriptaccess", "always");
    so.addParam("wmode", "opaque");
    so.addParam("quality", "high");
    so.addParam("salign", "lt");
    so.addVariable("videoDefault", videoPath + "css/3D games.mp4"); //视频文件地址  UploadVideo
    so.addVariable("autoHide", "true");
    so.addVariable("hideType", "fade");
    so.addVariable("autoStart", "false");
    so.addVariable("holdImage", "../css/4-0.jpg");
    so.addVariable("startVol", "60");
    so.addVariable("hideDelay", "60");
    so.addVariable("bgAlpha", "75");
    so.write("CuPlayer");
});


