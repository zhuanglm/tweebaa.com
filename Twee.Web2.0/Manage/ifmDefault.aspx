<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ifmDefault.aspx.cs" Inherits="TweebaaWebApp2.Manage.ifmDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=GBK">
    <title>Tweebaa后台管理系统v2.0</title>
  
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <link href="jquery-easyui-1.2.6/themes/gray/easyui.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="jquery-easyui-1.2.6/jquery.easyui.min.js" type="text/javascript"></script>  
    <script src="js/wnTab.js" type="text/javascript"></script>
    <script src="js/getmeaun.js" type="text/javascript"></script>
   
    <style>
        .easyui-accordion div
        {
            text-align: left;
        }
        #dvM div
        {
            text-align: left;
        }
        #dvM div img
        {
            display: block;
            float: right;
            margin-right: 32px;  margin-top:10px;
        }
    </style>
</head>
<body class="easyui-layout">
    <div region="north" border="false" style="height: 42px; overflow: hidden;">
        <div id="myTop">
            <img alt="" src="css/log_adm.png" />
        </div>
        <div class="topRiht" style="display: block; position: absolute; top: 0px; right: 0px;
            text-align: right;" id="myRight">
            <div id="myRight2" style="padding: 10px">
                <a href="javascript:void(0)" onclick="loginOut()">退出</a><img src="css/h_tel.bmp"
                    class="imgLeft" />

            </div>
        </div>
    </div>
    <div id="mainPanle" region="center" border="false" style="height: 1px; overflow: hidden;">
        <div id="tabs" class="easyui-tabs" fit="true" border="false">
        </div>
    </div>
    <div region="west" border="false" split="false" style="width: 118px; text-align: center;
        padding: 0px;">
        <div id="dvM" fit="true" border="false" style="background-color: #F7F7F7;  ">
            读取中…
        </div>
    </div>
    <div id="mm" class="easyui-menu cs-tab-menu" style="width: 120px; display: none;">
        <div id="mm-tabupdate">
            刷新</div>
        <div class="menu-sep">
        </div>
        <div id="mm-tabclose">
            关闭</div>
        <div id="mm-tabcloseother">
            关闭其他</div>
        <div id="mm-tabcloseall">
            关闭全部</div>
    </div>
  
</body>
</html>
