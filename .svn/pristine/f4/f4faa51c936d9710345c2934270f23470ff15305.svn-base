<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadPic1.aspx.cs" Inherits="TweebaaWebFile.UploadPic1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="js/jquery.ajaxpost.js" type="text/javascript"></script>
    <script src="js/comm.js" type="text/javascript"></script>
    <link href="css/jquery.upload.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.upload.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            var url = $(".hrootUrl").val();
            $(".upload-box").upload({ actionUrl: url + 'server/upload_json.ashx', uploadUrl: url, 'text': 'dsf' });
        });
    </script>
    <style>
        #d input
        {
            color: Red;
        }
    </style>
</head>
<body>
    <div class="cmdYuan2">
        <div class="recommbox">
            <ul>
                <li class="l1"><em>*&nbsp;</em>产品图片</li>
                <li class="l2"><a href="javascript:void(0)" data-reveal-id="myModal_pic" class="control-label">
                    &nbsp;</a> </li>
                <li style="width: 760px; height: 170px;">
                    <div id="picbox" style="background-color: #F6F8FA; border: dotted 1px #D9DDE3; padding: 10px;">
                        <div id='d' class="upload-box" text="产品主图">
                        </div>
                        <div class="upload-box" text="产品明细图">
                        </div>
                        <div class="upload-box" text="产品明细图">
                        </div>
                        <div class="upload-box" text="产品明细图">
                        </div>
                        <div class="upload-box" text="产品明细图">
                        </div>
                        <div class="clearboth" text="产品明细图">
                        </div>
                        <span style="font-size: 12px;">请单击图片进行上传，可用扩展名: jpg, jpeg, gif, png，单个文件最大 1M，长*宽不小于
                            450px * 430px</span>
                    </div>
                </li>
            </ul>
            <div class="clearboth" style="height: 20px;">
            </div>
            <ul>
                <li class="l1">产品视频</li>
                <li class="l2"><a href="javascript:void(0)" data-reveal-id="myModal_sp" class="control-label">
                    &nbsp;</a> </li>
                <li class="l3" style="width: 187px;">
                    <input class="t1" id="txtVideoUrl" type="text" style="width: 485px;" placeholder="&nbsp;输入展示视频的链接网址"
                        validity="url" errortxt="请输入正确的视频地址！" /></li>
                <li class="l4"></li>
            </ul>
        </div>
    </div>
    <input id="hrootUrl" type="hidden" runat="server" class="hrootUrl" />
</body>
</html>
