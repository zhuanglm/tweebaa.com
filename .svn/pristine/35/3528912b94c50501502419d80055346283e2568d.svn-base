<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeIntegral.aspx.cs" Inherits="TweebaaWebApp.Home.HomeIntegral" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Document</title>
    <link rel="stylesheet" href="../css/index.css" />
    <link rel="stylesheet" href="../css/home.css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/custom.js"></script>
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <script src="../js/selectNav.js" type="text/javascript"></script>
    <script src="../js/homePage.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../css/selectCss.css" />
    <script src="../js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/public.js"></script>
    <script src="../MethodJs/point.js" type="text/javascript"></script>

     <script src="../Js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="../Js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <!-- 用户中心内容 -->
    <div class="home-page">
        <div class="w967">
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
                    jq_tabs("integral");
                });
            </script>
             <div class="home-main fl">
            <div class="collection-main">
                <h2 class="t">
                    My Reward Points</h2>
                <div class="collection-select integral-bar clearfix">
                    <div class="integral-tab fl" id="integralTab">
                        <a href="#" class="on" style="width:150px;">Member points</a><a href="#" style="width:150px;">Shopping points</a></div>
                    <div class="integral-time fr" style="display: none;">
                        <span class="fl" style="height: 30px; line-height: 30px;">Time</span>
                        <input type="text" value="" class="time-text">
                        <span class="fl">to</span>
                        <input type="text" value="" class="time-text">
                        <input type="submit" class="btns btn-1" value="Inquiry" />
                    </div>
                </div>
                <!--积分列表-->
                <div class="integral-item clearfix" id="integralItem0" style="display: block;">
                    <div class="integral-item-main fl ">
                        <table width="100%" cellpadding="0" cellspacing="1" border="0" class="integral-tb"
                            bgcolor="#dddddd">
                            <tr>
                                <th>
                                    Types of point
                                </th>
                                <th>
                                    Current points
                                </th>
                                <th style="display: none;">
                                    Points received
                                </th>
                                <th style="display: none;">
                                    Points used
                                </th>
                                <th>
                                    Member level
                                </th>
                                <th>
                                    Commission (%)
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    Submit
                                </td>
                                <td>
                                    <asp:Label ID="labPIntegral" runat="server"></asp:Label>
                                </td>
                                <td style="display: none;">
                                    <%-- <asp:Label ID="labPIntegral" runat="server"></asp:Label>--%>
                                </td>
                                <td style="display: none;">
                                    <asp:Label ID="labPIntegralRemove" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="labPGrade" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="labPRatio" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Evaluate
                                </td>
                                <td>
                                    <asp:Label ID="labRIntegral" runat="server"></asp:Label>
                                </td>
                                <td style="display: none;">
                                    <%-- <asp:Label ID="labPIntegral" runat="server"></asp:Label>--%>
                                </td>
                                <td style="display: none;">
                                    <asp:Label ID="labRIntegralRemove" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="labRGrade" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="labRRatio" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Share
                                </td>
                                <td>
                                    <asp:Label ID="labSIntegral" runat="server"></asp:Label>
                                </td>
                                <td style="display: none;">
                                    <%-- <asp:Label ID="labPIntegral" runat="server"></asp:Label>--%>
                                </td>
                                <td style="display: none;">
                                    <asp:Label ID="labSIntegralRemove" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="labSGrade" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="labSRatio" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div class="integral-list">
                            <%--下一阶段实现--%>
                            <div class="integral-chk mt20">
                                <input type="checkbox" id="ckb0" value="all" />
                                <label  onclick="serch('ckb0')">All</label>
                                <input type="checkbox" id="ckb1" value="1" />
                                <label  onclick="serch('ckb1')">Submit Reward points</label>
                                <input type="checkbox" id="ckb2" value="2"  />
                                <label  onclick="serch('ckb2')">Evaluate Reward points</label>
                                <input type="checkbox" id="ckb3" value="3"  />
                                <label  onclick="serch('ckb3')">Share Reward points</label>
                            </div>
                            <div class="integral-data mt10">
                        
                                        <table width="100%" class="tb-list" cellpadding="0" cellspacing="1" border="0" bgcolor="#f2f2f2" id="tbPoint">
                                            <tr>
                                                <th>
                                                    Time
                                                </th>
                                                <th>
                                                    <span class="sort" style="width: 40px;">Points</span>
                                                </th>
                                                <th>
                                                    <span class="sort on" style="width: 40px;">Type</span>
                                                </th>
                                                <th>
                                                    <span class="sort">Detail</span>
                                                </th>
                                            </tr>                                 
                                    <tbody id="profit-data">                                          
                                    </tbody>                                   
                               </table>                                
                            </div>
                        </div>
                        <div id="divNoDataRewardPoint" style="display:none" >No data found! </div>
                        <div class="page tr" >
                            <%--下一阶段实现--%>
                                <div id="kkpager" style="float:right; padding-right:150px;">
                                </div>
                          
                        </div>
                    </div>
                    <div class="integral-item-side fl ml10">
                        <div class="integral-tips" style="font-size: 12px;">
                            Learn more about reward points and commission?<br /><a href="../College/ZoneRewardPoints.aspx?page=Zone-reward-points"
                                target="_blank">Click here</a>
                        </div>
                    </div>
                </div>
                <div class="integral-item clearfix" id="integralItem1">
                    <div class="integral-item-main fl">
                        <%--下一阶段实现--%>
                        <div class="integral-info clearfix">
                            <dl class="ml10">
                                <dt>Available points</dt>
                                <dd><asp:Label ID="labAvailablePoint" runat="server"></asp:Label>
                                    </dd>
                            </dl>
                          <%--  <dl class="ml10" style="width: 250px; display:none;">
                                <dt>Expiring Reward points</dt>
                                <dd>
                                    0（Expiry on 2015/01/10）</dd>
                            </dl>--%>
                            <dl class="ml10" style="width: 160px;">
                                <dt>Redemption Value</dt>
                                <dd>
                                    $<asp:Label ID="labSumShop2" runat="server"></asp:Label> USD </dd>
                            </dl>
                        </div>
                        <div class="integral-list">
                            <div class="integral-chk mt20">
                                <input type="checkbox" value='1' />
                                <label>
                                    All</label>
                                <input type="checkbox" value='2' />
                                <label>
                                    Reward points earned</label>
                                <input type="checkbox" value='3' />
                                <label>
                                    Reward points redeemed</label>
                            </div>
                            <div class="integral-data mt10">
                                <table width="100%" class="tb-list" cellpadding="0" cellspacing="1" border="0" bgcolor="#f2f2f2">
                                    <tr>
                                        <th>
                                            Time
                                        </th>
                                        <th>
                                            Reward points
                                        </th>
                                        <th>
                                            Related order
                                        </th>
                                        <th>
                                            Remarks
                                        </th>
                                    </tr>
                                    <tbody id="profit-data2">
                                       
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="page tr">
                             <div id="kkpager2" style="float:right; padding-right:150px;">
                                </div>
                        </div>
                    </div>
                    <div class="integral-item-side fl ml10">
                    </div>
                </div>
                <script type="text/javascript">
                    $('.integral-chk').hcheckbox();
                </script>
                <!--/-->
            </div>
        </div>
    </div></div>
</body>
</html>
