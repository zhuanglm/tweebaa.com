﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="HomeProfit.aspx.cs" Inherits="TweebaaWebApp2.Home.HomeProfit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
  My Commission Reward
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

   
   
    <!-- CSS Page Style 
    <link rel="stylesheet" href="../css/pages/profile.css">
     <link rel="stylesheet" href="../css/index.css" />
    -->

    <!-- Style Switcher -->
    <link rel="stylesheet" href="../css/plugins/style-switcher.css">

    <!-- CSS Theme -->
    <link rel="stylesheet" href="../css/theme-colors/default.css" id="style_color">

    <!-- CSS Customization -->
    <link rel="stylesheet" href="../css/custom.css">


    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <script src="../js/selectNav.js" type="text/javascript"></script>
    <script src="../MethodJs/multiSelect.js" type="text/javascript"></script>
    <script src="../js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/public.js"></script>
    <script type="text/javascript" src="../MethodJs/share.js"></script>
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
    <style>
    

.tooltip{
    position:absolute;
    z-index:1020;
    display:block;
    visibility:visible;
    padding:5px;
    font-size:11px;
    opacity:0;
    filter:alpha(opacity=0);
     border-bottom:1px solid #ffffff
}
.tooltip.in{
    opacity:.8;
    filter:alpha(opacity=80)
}
.tooltip.top{
    margin-top:-2px
}
.tooltip.right{
    margin-left:2px
}
.tooltip.bottom{
    margin-top:2px
}
.tooltip.left{
    margin-left:-2px
}
.tooltip.top .tooltip-arrow{
    bottom:0;
    left:50%;
    margin-left:-5px;
    border-left:5px solid transparent;
    border-right:5px solid transparent;
    border-top:5px solid #000
}
.tooltip.left .tooltip-arrow{
    top:50%;
    right:0;
    margin-top:-5px;
    border-top:5px solid transparent;
    border-bottom:5px solid transparent;
    border-left:5px solid #000
}
.tooltip.bottom .tooltip-arrow{
    top:0;
    left:50%;
    margin-left:-5px;
    border-left:5px solid transparent;
    border-right:5px solid transparent;
    border-bottom:5px solid #ff0000
}
.tooltip.right .tooltip-arrow{
    top:50%;
    left:0;
    margin-top:-5px;
    border-top:5px solid transparent;
    border-bottom:5px solid transparent;
    border-right:5px solid #000
}
.tooltip-inner{
    max-width:200px;
    /*padding:3px 8px;*/
    margin-top:40px;
    color:#fff;
    text-align:center;
    text-decoration:none;
    background-color:#000;
    -webkit-border-radius:4px;
    -moz-border-radius:4px;
    border-radius:4px
}
.tooltip-arrow{
    position:absolute;
    width:0;
    height:0
}

    </style>

                    <script src="../js/jspage/kkpager.min.js" type="text/javascript"></script>
                <link href="../js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <form id="form1" runat="server">
<div class="col-md-9">
            <h2><i class="fa fa-money"></i> Commission Rewards</h2>
                <!--Profile Body-->
                <div class="profile-body">   
<div class="alert alert-warning fade in">
                    <button data-dismiss="alert" class="close" type="button">×</button>       
                    We give “everyday people” a way to earn through SHARING. Sharing products in our <span class="color-blue">
                    <a class="color-blue" target="_blank" href="../College/Suggest-zone.aspx#collapseOne">Suggest Zone</a></span> … sharing feedback in the 
                    <a class="color-sea" target="_blank" href="../College/evaluate-zone.aspx#collapseOne">Evaluate Zone</a>… and sharing cool items with your friends in the 
                    <a class="color-orange" target="_blank" href="../College/share-zone.aspx#collapseOne">Share Zone</a>. You can earn with zero investment, and very little effort. 
<a class="alert-link" target="_blank" href="../College/CashRewards.aspx">Learn more </a> .
                </div>
<div class="clearfix margin-bottom-10" ></div>
                    <!--Service Block v3-->
                    <div class="row content-boxes-v2 margin-bottom-20">
                        <div class="col-md-12">
                        
                  
                    <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox runat="server" ID="txtMoney" class="form-control" placeholder="Enter Amount, 10 Tweebucks at least "></asp:TextBox>
                                    <!--
                                    <input type="text" class="form-control" placeholder="Enter Amount , 
10 Tweebucks at least "> -->
                                    <span class="input-group-btn">
                                     <asp:Button ID="btnExtractMoney" runat="server" class="btn btn-danger round" OnClick="btnExtract_Click" Text=" Withdraw Cash"  />
                                      <!--  <button class="btn btn-danger" type="button"> Withdraw Cash</button> -->
                                    </span>
                                </div>
                                <div class="note"><strong>Note:</strong>It may take up to two business day to process your request before funds are deposited in your Paypal account.</div>
                                
                                </div>
                   <div class="clearfix margin-bottom-30" ></div>
                  
                 <div class="col-md-3">              
                        <div class="bg-light">  
                          <p class="tc">
                          <span class="text-border text-border-red tooltips" data-toggle="tooltip" data-original-title="This is your current balance (not including any “pending” TweeBucks). ">Available Balance</span></p>                  
                                  <div class="counters"><span class="counter color-red"><asp:Label ID="labAvailableBalance" runat="server" Text=""></asp:Label></span> 
                                  <br /><strong>TweeBucks</strong> </div>                      
                                  <div class="row">
                                    <div class="col-xs-12">
                              <div class="counters">Redemption $<span class="counter"><asp:Label ID="labAvailableBalanceValue" runat="server" Text=""></asp:Label></span>USD</div>
                                      
                                    </div></div>      </div></div>

                 <div class="col-md-3">              
                        <div class="bg-light">  
                        <p class="tc"><span class="text-border text-border-red tooltips" data-toggle="tooltip" data-original-title="This amount will transfer to your “Available Balance” after merchandise is received and 7-day return period has expired.">Pending Tweebucks</span></p>             
                                  <div class="counters"><span class="counter color-red"><asp:Label id="labPendingTweebuck" runat="server">0</asp:Label></span> 
                                  <br /><strong>TweeBucks</strong> </div>                      
                                  <div class="row">
                                    <div class="col-xs-12">
                              <div class="counters">Redemption $<span class="counter"><asp:Label ID="labPendingTweebuckValue" runat="server" Text=""></asp:Label></span>USD</div>
                                      
                                    </div></div>      </div></div>

                   <div class="col-md-3">
                        <div class="bg-light">        
                          <p class="tc"><span class="text-border text-border-green tooltips" data-toggle="tooltip" data-original-title="To date, you have withdrawn this amount from your Tweebaa account (either as Cash or Merchandise Credit). ">Total Withdrawn</span></p>
                           <div class="counters">
                                <span class="counter color-green"><asp:Label ID="labTotalWithdraw" runat="server" Text=""></asp:Label></span><br /> <strong>TweeBucks</strong>
                                
                            </div>
           
                            <div class="row">
                                    <div class="col-xs-12">
                              <div class="counters">Redemption $<span class="counter"><asp:Label ID="labTotalWithdrawValue" runat="server" Text=""></asp:Label></span>USD</div>
                                      
                                 </div>    </div>
                        </div>
                    </div>
                  <div class="col-md-3">
                        <div class="bg-light"><!-- You can delete "bg-light" class. It is just to make background color -->        
                        <p class="tc"><span class="text-border text-border-g tooltips" data-toggle="tooltip" data-original-title="To date, you have earned this amount from Tweebaa (reflects Available Balance + Pending TweeBucks + Total Withdrawn)">Total Earned</span></p>
                           <div class="counters">
                                <span class="counter"><asp:Label ID="labTotalEarn" runat="server" Text=""></asp:Label></span><br /><strong>TweeBucks</strong> 
                                
                            </div>
                             <div class="row">
                                    <div class="col-xs-12">
                              <div class="counters">Redemption $<span class="counter"><asp:Label ID="labTotalEarnValue" runat="server" Text=""></asp:Label></span>USD</div>
                                      
                                 </div>    </div>
                        </div>
                    </div>
                   
                </div>
                <!--Table Bordered--> 
           <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="icon-trophy"></i> Commission Summary</h3>
                            </div>
                            <div class="panel-body sky-form">        
                               <section class="col-md-3" style="padding-left:0px;">
                                            <label class="input">
                                                <i class="icon-append fa fa-calendar"></i>
                                                <input type="text" name="start" id="txtBeginTime"   placeholder="Start date" class="datepicker">
                                            </label>
                                        </section>
                                        <section class="col-md-3" style="padding-left:0px;">
                                            <label class="input">
                                                <i class="icon-append fa fa-calendar"></i>
                                                <input type="text" name="finish" id="txtEndTime"   placeholder="End date" class="datepicker">
                                            </label>
                                        </section>
                         
                            <section class="col-md-4">
                                <div class="input-group">
                                    <input type="text" class="form-control"   id="txtName" placeholder="Product Name" />
                                <span class="input-group-btn"> <button class="btn" type="button" onclick="DoSearch()"
                                       >Search</button> </span>

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
                            <!--  如何区分????
                            <section class="col-md-8">
                             <div class="inline-group">
                                    <label class="radio"><input type="radio" value='1'  id="ckb1" /><i></i>All</label>
                                    <label class="radio"><input type="radio" value='2'  id="ckb2" /><i></i>Submit Only</label>
                                    <label class="radio"><input type="radio" value='3'  id="ckb3" /><i></i>Evaluate Only</label>
                                    <label class="radio"><input type="radio" value='4'  id="ckb4" /><i></i>Share Only</label>
                                </div>
                          
                 </section> -->
                              
                 
                            <div class="margin-bottom-10 "></div>
                  <table class="table table-bordered">
    
<tr>
                        <th width="50" style="display: none;">
                            <input type="checkbox" id="chkall" />
                        </th>
                        <th width="300">
                            Related Product
                        </th>
                        <th>
                            Category
                        </th>
                        <th>
                            Level/%
                        </th>
                        <th>
                            Amount
                        </th>
                        <th>
                            Date
                        </th>
                        <%-- <th><span class="sort">累计收益</span></th>--%>
                        <th style="display: none;">
                            Action
                        </th>
                    </tr>
                    <tbody id="tbData">
                 <!-- modify by Long as paging doesn't work, and style is different with others -->   
                    </tbody>


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

<!--
                <script src="../js/jspage/kkpager.min.js" type="text/javascript"></script>
                <link href="../js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />
-->
             <div id="divNoData" style="display:none" >No order found! </div>
             <div id="kkpager" style="  float:right; padding-right:150px;"></div><br />
<!--
                <input id="hidTotalPages" type="hidden" value="10" runat="server" />
                <input id="hidCurrentIndex" type="hidden" value="1" runat="server" />
                <script type="text/javascript">
            $( document ).ready(function() {
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
                });
                </script>
-->
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

    var page = 1;
    var recordCount = 0;
    var pageCount = 10;
    var begTime = $("#txtBeginTime").val();
    var endTime = $("#txtEndTime").val();
    var state = "";
    DoSearch();
    function DoSearch() {
        $("#divNoData").hide();

        begTime = $("#txtBeginTime").val();
        endTime = $("#txtEndTime").val();


        //loadCount();
        loadTotal();
        LoadProfit();
        //LoadPrd();
    }

    //获取总记录数、页数
    function loadTotal() {
        var prdName = $("#txtName").val();
        $.ajax({
            type: "Post",
            url: "/AjaxPages/homeProfitAjax.aspx",
            data: "{'action':'queryhomecount','type':'" + state +
                    "','prdName':'" + prdName +
                    "','beginTime':'" + begTime +
                    "','endTime':'" + endTime + "'}",
            async: false,
            success: function (resu) {
                if (resu == "") {
                    return;
                }

                recordCount = resu;
                pageCount = Math.ceil(recordCount / 10);
                //pageCount = arry[1];
                kkpager.generPageHtml({
                    lang: {
                        firstPageText: 'First',
                        firstPageTipText: 'First',
                        lastPageText: 'Last',
                        lastPageTipText: 'Last',
                        prePageText: 'Prev',
                        prePageTipText: 'Prev',
                        nextPageText: 'Next',
                        nextPageTipText: 'Next',
                        currPageBeforeText: 'Current page ',
                        currPageAfterText: '',
                        totalInfoSplitStr: '/',
                        totalRecordsBeforeText: 'Total: ',
                        totalRecordsAfterText: '',
                        buttonTipBeforeText: 'Page ',
                        buttonTipAfterText: ''
                    },
                    pno: 1,
                    total: pageCount, //总页码                //总数据条数
                    totalRecords: recordCount,
                    mode: 'click', //默认值是link，可选link或者click
                    click: function (n) {
                        page = n;
                        LoadProfit();
                        this.selectPage(n); //手动选中按钮
                        return false;
                    }
                });
            },
            error: function (obj) {
                // alert("Load failed");
            }
        });
    }



    function LoadProfit() {
        $("#tbData").empty();
        var prdName = $("#txtName").val();
        $.ajax({
            type: "POST",
            url: '/AjaxPages/homeProfitAjax.aspx',
            data: "{'action':'query','type':'" + state +
                    "','page':'" + page +
                    "','prdName':'" + prdName +
                    "','beginTime':'" + begTime +
                    "','endTime':'" + endTime + "'}",
            async: false,
            success: function (resu) {
                if (resu == "" || resu == "[]") {
                    $("#kkpager").empty();
                    $("#divNoData").show();
                    return;
                }
                $("#tbData").html("");
                var obj = eval("(" + resu + ")");
                var html="";
                for (var i = 0; i < obj.length; i++) {
                    var profit=obj[i];
                    var fileUrl = profit.fileurl;
                    var my_money = parseFloat(profit.money);
                    if(fileUrl.Length >0) fileUrl=fileUrl.replace("/big/","/Small");
                    html+='<tr>';

                    html+='<td>';
                    html+='<dl class="profit-pro">';
                    html+='<dt>';
                    html += '<img src="' + fileUrl + '" width="100%" height="150" />';
                    html+='</dt>';
                    html+='<dd>';
                    html+='<a href="#">';
                    html+=' '+ profit.name+'</a><p>';
                    html+='</dd>';
                    html+='</dl>';
                    html+='</td>';
                    html+='<td>';
                    html+=' '+profit.type +'';
                    html+='</td>';
                    html+='<td>';
                    html+='<i class="green">';
                    html+=' '+profit.shareLevel+' / '+profit.CommissionRate /10 + '%</i>';
                    html+='</td>';
                    html+='<td>';
                    html+='<i class="green">';
                    html += ' ' + my_money.toFixed(2) + '</i>';
                    html+='</td>';
                    html+='<td>';
                    html += ' ' + profit.AddDate + '';
                    html+='</td>';
                    html+='</tr>';
                }
                $("#tbData").html(html);

            },
            error: function (obj) {
                // alert("Load failed");
            }
        });
    }
</script>
</form>
</asp:Content>
