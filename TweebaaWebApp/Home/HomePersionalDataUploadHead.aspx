<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePersionalDataUploadHead.aspx.cs" Inherits="TweebaaWebApp.Home.HomePersionalDataUploadHead" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />
    <title>个人头像</title>
    <link rel="stylesheet" href="../css/index.css" />
    <link rel="stylesheet" href="../css/home.css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script src="../js/selectNav.js" type="text/javascript"></script>
    <script src="../js/homePage.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <link rel="stylesheet" href="../css/selectCss.css" />
    <script src="../js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/public.js"></script>
    <script type="text/javascript" src="../MethodJs/homePersonalData.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#upload").change(function () {
                $("#upload-state").show();
                $("#personal-upload-form").submit();
            });
        });
    </script>
    <style type="text/css">
    body { 
    overflow-x : hidden;   
     overflow-y : hidden;    
} 

    </style>
</head>
<body>
    <div class="home-main fl" style="width: 250px">
        <div class="personal-main">
            <form id="personal-upload-form" method="post" enctype="multipart/form-data">
                <div class="tx-box">
                    <asp:Image ID="imgUserHead" runat="server" ImageUrl="images/102x102.png" />
                </div>
                <div class="uploadBox clearfix">
                    <div class="line fl">
                        <span class="span" style="display: none;">
                            <input name="" type="text" id="viewfile" onmouseout="document.getElementById('upload').style.display='none';" class="inputstyle" />
                        </span>
                        <label for="unload" onmouseover="document.getElementById('upload').style.display='block';" class="file1">Upload</label>
                        <input type="file" name="upload" onchange="document.getElementById('viewfile').value=this.value;this.style.display='none';" class="file" id="upload" />
                    </div>
                    <strong id="upload-state" style="display: none">re uploading, please wait...</strong>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
