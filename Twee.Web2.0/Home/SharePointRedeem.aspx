﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="SharePointRedeem.aspx.cs" Inherits="TweebaaWebApp2.Home.SharePointRedeem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
My Share Point Redeem
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">

<!-- CSS Global Compulsory -->
    <link rel="stylesheet" href="../plugins/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="../css/shop.style.css">
    <link rel="stylesheet" href="../css/style.css">
     
    <!-- CSS Implementing Plugins -->
    <link rel="stylesheet" href="../plugins/line-icons/line-icons.css">
    <link rel="stylesheet" href="../plugins/font-awesome/css/font-awesome.min.css">
     <link rel="stylesheet" href="../plugins/sky-forms/version-2.0.1/css/custom-sky-forms.css">
    <link rel="stylesheet" href="../plugins/scrollbar/src/perfect-scrollbar.css">

   
   
    <!-- CSS Page Style -->
    <link rel="stylesheet" href="../css/pages/profile.css">

    <!-- Style Switcher -->
    <link rel="stylesheet" href="../css/plugins/style-switcher.css">

    <!-- CSS Theme -->
    <link rel="stylesheet" href="../css/theme-colors/default.css" id="style_color">

    <!-- CSS Customization -->
    <link rel="stylesheet" href="../css/custom.css">

    <!--link rel="stylesheet" href="../css/home.css" />
    <link rel="stylesheet" href="../css/selectCss.css" />
    <link href="../css/shareBox.css" rel="stylesheet" type="text/css" /-->
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <script src="../js/selectNav.js" type="text/javascript"></script>
    <script src="../MethodJs/multiSelect.js" type="text/javascript"></script>
    <script src="../js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/public.js"></script>
    <script type="text/javascript" src="../MethodJs/share.js"></script>
    <script type="text/javascript" src="../MethodJs/HomeSharePointRedeem.js"></script>
    <script>
        /*    
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
        });*/
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
 <form id="form1" runat="server">
<div class="col-md-9">
            <h2><i class="fa fa-money"></i> Share Point Redemption</h2>
                <!--Profile Body-->
                <div class="profile-body">   
                <!--
<div class="alert alert-warning fade in">
                    <button data-dismiss="alert" class="close" type="button">×</button>       
                    We give “everyday people” a way to earn through SHARING. Sharing products in our <span class="color-blue">
                    <a class="color-blue" target="_blank" href="../College/Suggest-zone.aspx#collapseOne">Suggest Zone</a></span> … sharing feedback in the 
                    <a class="color-sea" target="_blank" href="../College/evaluate-zone.aspx#collapseOne">Evaluate Zone</a>… and sharing cool items with your friends in the 
                    <a class="color-orange" target="_blank" href="../College/share-zone.aspx#collapseOne">Share Zone</a>. You can earn with zero investment, and very little effort. 
<a class="alert-link" target="_blank" href="../College/CashRewards.aspx">Learn more </a> .
                </div> -->
<div class="clearfix margin-bottom-10" ></div>
                    <!--Service Block v3-->
                    <div class="row content-boxes-v2 margin-bottom-20">

                   <div class="clearfix margin-bottom-30" ></div>
                  
                 <div class="col-md-4">              
                        <div class="bg-light">  
                         <p class="tc">Available Share Points</p>                 
                                  <div class="counters"><span class="counter color-red"><asp:Label ID="labAvailablePoints" runat="server" Text=""></asp:Label></span> 
                                  <!-- <strong>TweeBucks</strong>  -->
                                  </div>    
                                         <!--           
                                  <div class="row">
                                    <div class="col-xs-12">
                              <div class="counters">Redemption $<span class="counter"><asp:Label ID="labAvailableBalanceValue" runat="server" Text=""></asp:Label> USD</span>  </div>
                                      
                                    </div></div>  
                                    -->
                                        </div></div>

                   <div class="col-md-4">
                        <div class="bg-light">        
                            <p class="tc">Total Redeemed</p>
                           <div class="counters">
                                <span class="counter color-green"><asp:Label ID="labTotalRedeem" runat="server" Text=""></asp:Label></span>
                                <!--
                                 <strong>TweeBucks</strong>
                                -->
                            </div>
           <!--
                            <div class="row">
                                    <div class="col-xs-12">
                              <div class="counters">Redemption $<span class="counter"><asp:Label ID="labTotalWithdrawValue" runat="server" Text=""></asp:Label> USD</span>  </div>
                                      
                                 </div>    </div>  -->
                        </div>
                    </div>
                    <!--
                  <div class="col-md-4">
                        <div class="bg-light">      
                            <p class="tc">Total Earned</p>
                           <div class="counters">
                                <span class="counter"><asp:Label ID="labTotalEarn" runat="server" Text=""></asp:Label></span><strong>TweeBucks</strong> 
                                
                            </div>
                             <div class="row">
                                    <div class="col-xs-12">
                              <div class="counters">Redemption $<span class="counter"><asp:Label ID="labTotalEarnValue" runat="server" Text=""></asp:Label> USD</span>  </div>
                                      
                                 </div>    </div>
                        </div>
                    </div>  -->
                   
                </div>
                <!--Table Bordered--> 
           <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="icon-trophy"></i> Redemption Summary</h3>
                            </div>
                            <div class="panel-body sky-form">        
                               <section class="col-md-3" style="padding-left:0px;">
                                            <label class="input">
                                                <i class="icon-append fa fa-calendar"></i>
                                                <input type="text" name="start" id="txtBeginTime"  placeholder="Start date" class="datepicker">
                                            </label>
                                        </section>
                                        <section class="col-md-3" style="padding-left:0px;">
                                            <label class="input">
                                                <i class="icon-append fa fa-calendar"></i>
                                                <input type="text" name="finish" id="txtEndTime"  placeholder="End date" class="datepicker">
                                            </label>
                                        </section>
                         
                            <section class="col-md-4">
                                <div class="input-group">
                                  <!--  <input type="text" class="form-control" runat="server" id="txtName" placeholder="Product Name" /> -->
                                <span class="input-group-btn"> <button id="btnSearch" class="btn" type="button"
                                        onclick="DoSearch()">Search</button> </span>


                                        
                                        </div>
                            </section>  
 
                             <section class="col-md-12" style="padding-left:0px;"> 
                             <!--
                         <div class="inline-group">
                                <label class="checkbox"><input type="checkbox" name="checkbox-inline" checked><i></i> All</label>
                                <label class="checkbox"><input type="checkbox" name="checkbox-inline"><i></i>Submit</label>
                                <label class="checkbox"><input type="checkbox" name="checkbox-inline"><i></i>Evaluate</label>
                                <label class="checkbox"><input type="checkbox" name="checkbox-inline"><i></i>Share</label>
                               
                            </div>
                            -->
                            </section>
                            <!--
                            <section class="col-md-8">
                             <div class="inline-group">
                                    <label class="checkbox"><input type="checkbox" value='1' runat="server" id="ckb1" /><i></i>All</label>
                                    <label class="checkbox"><input type="checkbox" value='2' runat="server" id="ckb2" /><i></i>Submit Only</label>
                                    <label class="checkbox"><input type="checkbox" value='3' runat="server" id="ckb3" /><i></i>Evaluate Only</label>
                                    <label class="checkbox"><input type="checkbox" value='4' runat="server" id="ckb4" /><i></i>Share Only</label>
                                </div>
                          
                 </section> -->
                              
                 
                            <div class="margin-bottom-10 "></div>
                  <table class="table table-bordered">
       <!--        
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Related Product</th>
                            <th class="hidden-sm">Income Type</th>
                            <th>Amount</th>
                            <th>Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1</td>
                            <td>Kitty Litty</td>
                            <td class="hidden-sm">Submit</td>
                            <td>$22.66</td>
                            <td>Jun / 12 / 2015</td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Kitty Litty</td>
                            <td class="hidden-sm">Submit</td>
                            <td>$22.66</td>
                            <td>Jun/12/2015</td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>Kitty Litty</td>
                            <td class="hidden-sm">Submit</td>
                            <td>$22.66</td>
                            <td>Jun/12/2015</td>
                        </tr>
                        <tr>
                            <td>4</td>
                            <td>Kitty Litty</td>
                            <td class="hidden-sm">Submit</td>
                            <td>$22.66</td>
                            <td>Jun/12/2015</td>
                        </tr>
-->
<tr>
                        <th width="50" style="display: none;">
                            <input type="checkbox" id="chkall" />
                        </th>
                        <th width="300">
                            Reward
                        </th>
                        <th>
                            Detail
                        </th>
                        <th>
                            Date
                        </th>
                        <%-- <th><span class="sort">累计收益</span></th>--%>
                        <th style="display: none;">
                            Action
                        </th>
                    </tr>
                    
                    <tbody id="redeemBody">
                    </tbody>
                    <!--
                    </tbody -->
                </table>
                      </div>
                        </div> 
                       <!--
                  <div class="text-right">
                                <ul class="pagination">
                                    <li><a href="#">«</a></li>
                                    <li><a href="#">1</a></li>
                                    <li class="active"><a href="#">2</a></li>
                                    <li><a href="#">3</a></li>
                                    <li><a href="#">4</a></li>
                                    <li><a href="#">»</a></li>
                                </ul>
                            </div>      
                            -->
                <script src="../js/jspage/kkpager.min.js" type="text/javascript"></script>
                <link href="../js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />
                <div id="kkpager" style="float: right;">
                </div>
                <input id="hidTotalPages" type="hidden" value="10" runat="server" />
                <input id="hidCurrentIndex" type="hidden" value="1" runat="server" />
                <script type="text/javascript">
/*
                    kkpager.generPageHtml({
                        lang: {
                            firstPageText: 'First',
                            firstPageTipText: 'First',
                            lastPageText: 'Last',
                            lastPageTipText: 'Last',
                            prePageText: 'Prev',
                            prePageTipText: 'Prev',
                            buttonTipBeforeText: 'Page ',
                            buttonTipAfterText: '',
                            nextPageText: 'Next',
                            nextPageTipText: 'Next'
                        }
                 ,
                        pno: 1,
                        total: $("#hidTotalPages").val(),
                        //总数据条数
                        //totalRecords: 10,//,recordCount,
                        mode: 'click', //默认值是link，可选link或者click
                        click: function (n) { //这里是当前页码
                            $("#hidCurrentIndex").val(n);
                            $("#btnSearch").click();
                            this.selectPage(n);
                            return false;
                        }
                    });

                    kkpager.selectPage($("#hidCurrentIndex").val());
*/

                </script>

                </div>
                 </div></div></div>
     
 <%-- 分享弹出ydf----%>
                <div id="share-tck2" class="tck">
                    <a href="#" class="closeBtn" title="Close"></a>
                    <h2 class="t">
                        <span>Share & Earn</span>
                    </h2>
                    <div class="box">
                        <div class="sharebox clearfix my-dietu">
                            <span class="fl t ">Share to </span>
                            
                                <% // include all share method  %>
                                <!--#include file="../Include/ShareMethod.inc" -->
                            
                            <a href="#" style="display: none;" class="share-media-set">Share Binding setting</a>
                        </div>
                        <div class="ps clearfix">
                            <span class="fr"><a href="#"></a></span><span class="fl">You will earn
                                <!--span id="sharePercent"></span-->
                                commission when your friend makes a purchase from your shared link. </span>
                        </div>
                    </div>
                </div>
                <script type="text/javascript">
                    $('.profit-chk').hcheckbox();

                </script>
  <!--overlay-->
            <div id="overlay-mask">
            </div>
        </div>
        <script type="text/javascript">
            $(function () {
                $("#chkall").click(function () {
                    if ($(this).attr("checked") == 'checked') {
                        $(".chk").attr("checked", "checked");
                    } else {
                        $(".chk").removeAttr("checked");
                    }
                });
            })

            //关闭弹出框
            $('.closeBtn,.iagree').click(function (event) {
                var obj2 = $(this).parents(".tck")
                obj2.animate({
                    top: "-500px"
                },
               300, function () {
                   obj2.parents(".greybox").hide()

               });
                return false;
            });
            //snow加landingpage
            $(".closeBtn").click(function () {
                $(this).parents(".popbox").hide();
                return false;
            })


            //分享动作
            function SharePrd(id, name, img, page, desc, saleprice) {
                name = unescape(name);
                if (SetShareLink(id, name, img, page, desc, saleprice) == true) {
                    $("#share-tck2").parents(".greybox").removeClass().show();
                    $("#share-tck2").animate({ top: "2%" }, 300);
                }

                //    $("#share4").bind("click", function () {
                //        dofristshare_prdSaleAll("qzone", id, name, img);
                //    });
                //    $("#share5").bind("click", function () {
                //        dofristshare_prdSaleAll("douban", id, name, img);
                //    });
            }

        </script>

<script type="text/javascript">
    function DoApplyMoney() {
        $("#btnExtractMoney").trigger("click");
    }

    function applyMoney() {
        var chkLength = $(".chk:checked").length;
        if (chkLength == 0) {
            alert("Please select at least one");
            return;
        }
        var ids = "";
        $(".chk:checked").each(function () {
            var id = $(this).attr("value");
            ids += "," + id;
        });
        if (ids.length > 0) {
            ids = ids.substring(1);
        }
        var res = TweebaaWebApp.Home.HomeProfit.ApplyCash(ids).value;
        if (res == "error") {
            alert("I'm sorry, withdrawal of failure");
        } else {
            alert(res);
        }
    }
    /*
    function apply() {  
    var res = TweebaaWebApp.Home.HomeProfit.Apply().value;
    if (res == "0") {
    alert("Please enter the amount");
    } else if (res=="1") {
    alert("Wrong value");
    }
    else {
    alert(res);;
    }
                                       
    }*/
                </script>

<!-- Datepicker Form -->
<script src="/plugins/sky-forms/version-2.0.1/js/jquery-ui.min.js"></script>
<script src="/plugins/counter/waypoints.min.js"></script>
<script src="/plugins/counter/jquery.counterup.min.js"></script>

<script type="text/javascript" src="/js/plugins/datepicker.js"></script>

<script>
    jQuery(document).ready(function () {

        //        Datepicker.initDatepicker();
        $(".datepicker").datepicker({
            nextText: ">",
            prevText: "<"
        });


    });
</script>
</form>

</asp:Content>
