<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlayVideo.aspx.cs" Inherits="TweebaaWebFile.PlayVideo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="js/swfobject.js"></script>
    <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var playPath = GetQueryString("playPath");
            var imgPath = GetQueryString("imgPath");
            //document.getElementById("hidPlay").value = playPath;
            //document.getElementById("hidImg").value = imgPath;
            //alert(document.getElementById("hidPlay").value);
            //alert(document.getElementById("hidImg").value);
            var so = new SWFObject("PlayerLite.swf", "CuPlayerV4", "520", "325", "9", "#000000");
            so.addParam("allowfullscreen", "true");
            so.addParam("allowscriptaccess", "always");
            so.addParam("wmode", "opaque");
            so.addParam("quality", "high");
            so.addParam("salign", "lt");
            //so.addVariable("videoDefault", document.getElementById("hidPlay").value); //视频文件地址 "UploadVideo/DRAFT web commercial.mp4"
//            so.addVariable("videoDefault", "UploadVideo/a.flv"); 
            so.addVariable("videoDefault", "UploadVideo/Dream leg test video.mp4"); //视频文件地址 "UploadVideo/DRAFT web commercial.mp4" playPath
            so.addVariable("autoHide", "true");
            so.addVariable("hideType", "fade");
            so.addVariable("autoStart", "false");
            so.addVariable("holdImage", imgPath);
            so.addVariable("startVol", "60");
            so.addVariable("hideDelay", "60");
            so.addVariable("bgAlpha", "75");
            so.write("CuPlayer");
        });    

    function GetQueryString(name) 
    {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); 
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null; 
        //URL的参数&参数名1=XXXX&参数名2=XXXX&参数名3=XXXX  
    }  

    </script>  
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hidPlay" />
    <input type="hidden" id="hidImg" />
    <div class="video" id="CuPlayer" style="margin: 0 auto;">
    </div>
    <%--  <script type="text/javascript">
          var so = new SWFObject("PlayerLite.swf", "CuPlayerV4", "520", "325", "9", "#000000");
          so.addParam("allowfullscreen", "true");
          so.addParam("allowscriptaccess", "always");
          so.addParam("wmode", "opaque");
          so.addParam("quality", "high");
          so.addParam("salign", "lt");
          //so.addVariable("videoDefault", document.getElementById("hidPlay").value); //视频文件地址 "UploadVideo/DRAFT web commercial.mp4"
          so.addVariable("videoDefault", "PlayVideo/201411121124368135.mp4"); //视频文件地址 "UploadVideo/DRAFT web commercial.mp4"
          so.addVariable("autoHide", "true");
          so.addVariable("hideType", "fade");
          so.addVariable("autoStart", "false");
          so.addVariable("holdImage", document.getElementById("hidImg").value);
          so.addVariable("startVol", "60");
          so.addVariable("hideDelay", "60");
          so.addVariable("bgAlpha", "75");
          so.write("CuPlayer");
    </script>--%>
   
    </form>
</body>
</html>
