﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeVideo.aspx.cs" Inherits="TweebaaWebApp2.Product.HomeVideo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <video  poster="/images/tweebaa_poster.jpg" width="430" height="250" controls>
    <source src="/images/video_home.mp4" type="video/mp4">
  Sorry, your browser doesn't support embedded videos, 
  but don't worry, you can <a href="videofile.ogg">download it</a>
  and watch it with your favorite video player!
</video>
    </div>
    </form>
</body>
</html>
