<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeShareDetail.aspx.cs" Inherits="TweebaaWebApp.Home.HomeShareDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../css/index.css" />
    <link rel="stylesheet" href="../css/home.css" />
        <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script src="../js/custom.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <script src="../js/selectNav.js" type="text/javascript"></script>
    <script src="../js/homePage.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../css/selectCss.css" />
    <script src="../js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/public.js"></script>


    <script src="../MethodJs/homeShareDetail.js" type="text/javascript"></script>
    <script src="../Manage/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Manage/My97DatePicker/lang/en.js"></script>
    <%--分页--%>
    <script src="../Js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="../Js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />
 
 <style>
       body {
            text-align:center;
            margin:0 auto;
             margin-left:200px;
        }
 </style>
</head>
<body>
    <form id="form1" runat="server">   
    <script>
        //tabs
        $(document).ready(function () {
            function jq_tabs(str) {
                $("#" + str + "Tab a").mouseover(function () {
                    $("#" + str + "Tab a").removeClass("on");
                    $(this).addClass("on");
                    var key = $("#" + str + "Tab a").index(this);
                    $("[id^='" + str + "Item']").hide();
                    $("#" + str + "Item" + key).show();
                });
                $("#" + str + "Tab a").eq(0).trigger("mouseover");
            }
            jq_tabs("share");
        });
        </script>
 <div class="home-main fl" style="text-align:center;width:80%"> 
    <div class="collection-main" style="text-align:center;">
        <h2 class="t" style="width:100%;">My&nbsp;&nbsp;  <label id="labType"></label>&nbsp;&nbsp;  Shares <label id="labCount" style="font-size:small; color:Black;"></label></h2>
        <div class="share-main mt20" style="text-align:center; ">          
           
            <div class="share-item" id="shareItem0" style="display: block; text-align:center;">

                <div class="collection-select clearfix"> 
                <span class="fl">Share Type </span>
                <div class="select-box fl pr">
                <h3 s-data="0" id="s-data">
                    All</h3>
                <ul class="select-list">                    
                    <li><a href="#" s-data="-1" onclick="SetState('-1')">All</a> </li>
                    <li><a href="#" s-data="1" onclick="SetState('Facebook')">Facebook</a> </li>
                    <li><a href="#" s-data="2" onclick="SetState('Google')">Google</a> </li>
                    <li><a href="#" s-data="3" onclick="SetState('Twitter')">Twitter</a> </li>
                    <li><a href="#" s-data="4" onclick="SetState('Pintest')">Pintest</a> </li>
                    <li><a href="#" s-data="5" onclick="SetState('Email')">Email</a> </li>

                </ul>
            </div>
                <span class="fr"><span class="fl">Share Date</span>
                   <input type="text" value="" class="time-text" id="txtBegin" onclick="WdatePicker({ lang: 'en' })" />
                   <span class="fl">To</span>
                   <input type="text" value="" class="time-text" id="txtEnd" onclick="WdatePicker({ lang: 'en' })" />
                   <input type="button" class="submit simple" value="Search"  id="btnSerch" onclick="Serch()" />                
                </span>
            </div>
                <table width="100%" class="tb-list" cellpadding="0" cellspacing="1" border="0" bgcolor="#f2f2f2"
                    id="tableShare">
                    <tr>
                        <th>
                            Date
                        </th>
                        <th>
                            Product Name
                        </th>
                        <th>
                            Promote Via
                        </th>
                        <th>
                            Visits
                        </th>
                        <th>
                            Buyers
                        </th>
                        <th>
                            Income Amount（$）
                        </th>
                         <th>
                           Copy Share Link
                        </th>
                    </tr>
                </table>
                <div id="kkpager" style="float: right; padding-right: 100px;">
                </div>
            </div>

           
        </div>
    </div>
     </div>
    </form>
</body>
</html>
