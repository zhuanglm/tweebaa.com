<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeProfit.aspx.cs" Inherits="TweebaaWebApp.Home.HomeProfit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../css/index.css" />
    <link rel="stylesheet" href="../css/home.css" />
    <link href="../Css/shareBox.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <script src="../js/selectNav.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../css/selectCss.css" />
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
</head>
<body itemscope itemtype="http://schema.org/Product">
    <% // include google share  %>
    <!--#include file="../include/googleshare.inc" -->
    <form id="form1" runat="server">
    <div class="home-main fl">
        <div class="collection-main">
            <h2 class="t">
                Commission Rewards
            </h2>
             <p>We give “everyday people” a way to earn through SHARING. Sharing

products in our <span style=" color:#007ee0">Submit Zone</span> … sharing feedback in the <span style=" color:##67c0ab">Evaluate zone</span>… and sharing 

cool items with your friends in the <span style=" color:#ff9966">Share zone</span>. You can earn with zero investment, 

and very little effort. <br /><a class="learn" href="../College/CashRewards.aspx?page=commission-rewards" target="_blank">Learn more</a> </p>
            <div class="profit-total mt20">
                <dl class="total">
                    <dt><strong>Available</strong><br/>
                    <strong>Commission</strong><br/>
                    <strong>Balance</strong></dt>
                    <dd><asp:Label ID="labAvailableBalance" runat="server" Text=""></asp:Label></dd>
                    <dt><strong>TweeBucks</strong><br/>
                   <span>redemption value<br/> $<asp:Label ID="labAvailableBalanceValue" runat="server" Text=""></asp:Label> USD</span></dt>
                </dl>
                <dl class="pay">
                    <dt><strong>Total</strong><br/>
                    <strong>Commission</strong><br/>
                    <strong>Withdrawn</strong></dt>
                    <dd><asp:Label ID="labTotalWithdraw" runat="server" Text=""></asp:Label></dd>
                    <dt><strong>TweeBucks</strong><br/>
                   <span>redemption value<br/> $<asp:Label ID="labTotalWithdrawValue" runat="server" Text=""></asp:Label> USD</span></dt>
                </dl>
                <dl class="total">
                    <dt><strong>Total</strong><br/>
                    <strong>Commission</strong><br/>
                    <strong>Earned</strong></dt>
                    <dd><asp:Label ID="labTotalEarn" runat="server" Text=""></asp:Label></dd>
                    <dt><strong>TweeBucks</strong><br/>
                    <span>redemption value<br/> $<asp:Label ID="labTotalEarnValue" runat="server" Text=""></asp:Label> USD</span></dt>
                </dl>
              <!--input type="text" value="" class="time-text"-->

              <asp:TextBox runat="server" ID="txtMoney" placeholder="Enter Amount"></asp:TextBox><br />

              <asp:Button ID="btnExtractMoney" runat="server" class="btns btn-2" OnClick="btnExtract_Click" Text=" Withdraw Cash" height="30px" />
             <p><strong>Minimum withdrawal<br /> 10 Tweebucks</strong>
             <br />Pending Tweebucks<br /><asp:Label id="labPendingTweebuck" runat="server">0</asp:Label></p>             
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
            </div>
            <div class="profit-title mt20">
                Commission Summary</div>
            <div class="profit-chart" style="display: none;">
                <img src="../Images/profit.png" width="750" height="220" />
            </div>
          <%--  <div class="integral-tab fl" id="integralTab"  style="text-align: right;">
            <div class="profit-tab mt20" id="profitTab" style="text-align: right;">--%>
               <%-- <a href="#" class="on" runat="server" onclick="">Pre Income</a><a href="#">Real Income</a>
            </div>--%>
           
            <div style="clear: both">
            </div>
            <!--profit-item-->
            <div class="profit-list" id="integralItem0" style="display: block;">
                <table width="100%" class="tb-list" cellpadding="0" cellspacing="1" border="0" bgcolor="#f2f2f2"
                    id="tbdata">
                    <tr>
                        <td colspan="7">
                            <div class="profit-fm">
                                <div class="profit-chk fl">
                                    <input type="checkbox" value='1' runat="server" id="ckb1" /><label>All</label>
                                    <input type="checkbox" value='2' runat="server" id="ckb2" /><label>Submit Only</label>
                                    <input type="checkbox" value='3' runat="server" id="ckb3" /><label>Evaluate Only</label>
                                    <input type="checkbox" value='4' runat="server" id="ckb4" /><label>Share Only</label>
                                </div>
                                <div class="profit-search fr clearfix">
                                    Product Search
                                    <input type="text" value="" class="time-text" runat="server" id="txtName" />
                                    <input id="btnSearch" type="submit" class="btns btn-1" value="Inquiry" runat="server"
                                        onserverclick="btnServh_Click" /></div>
                            </div>
                        </td>
                    </tr>
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
                    <asp:Repeater ID="repData" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="display: none;">
                                    <input type="checkbox" id="singchk" class="chk" tip="<%# Eval("money") %>" value="<%# Eval("id") %>" />
                                </td>
                                <td>
                                    <dl class="profit-pro">
                                        <dt>
                                            <img src='<%# GetPic( Eval("fileurl").ToString()) %>' width="100%" height="150" />
                                        </dt>
                                        <dd>
                                            <a href="#">
                                                <%# Eval("name") %></a><p>
                                                    <%-- Submitter：<%# Eval("username") %><br />
                                            Submit On：<%# Eval("pubtime") %></p>--%>
                                        </dd>
                                    </dl>
                                </td>
                                <td>
                                    <%# Eval("type") %>
                                </td>
                                <td>
                                    <i class="green">
                                        <%# Eval("money") %></i>
                                </td>
                                <td>
                                    <%# Eval("addtime") %>
                                </td>
                                <td style="display: none;">
                                    <%-- <a href="#">查看明细</a><br />--%>
                                    <a href="javascript:void(0)" onclick="SharePrd('<%#Eval("prdGuid") %>','<%# Escape(Eval("name").ToString()) %>','<%# GetPic( Eval("fileurl").ToString()) %>','saleBuy.aspx','<%# Escape(Eval("txtjj").ToString()) %>',<%# Eval("money") %>)"
                                        class="share">Share Order</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <script src="../Js/jspage/kkpager.min.js" type="text/javascript"></script>
                <link href="../Js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />
                <div id="kkpager" style="float: right;">
                </div>
                <input id="hidTotalPages" type="hidden" value="10" runat="server" />
                <input id="hidCurrentIndex" type="hidden" value="1" runat="server" />
                <script type="text/javascript">

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
                </script>
                <%-- 分享弹出ydf----%>
                <div id="share-tck2" class="tck">
                    <a href="#" class="closeBtn" title="Close"></a>
                    <h2 class="t">
                        <span>Share & Earn</span>
                    </h2>
                    <div class="box">
                        <div class="sharebox clearfix my-dietu">
                            <span class="fl t ">Share to </span>
                            <div class="bdsharebuttonbox fl">
                                <% // include all share method  %>
                                <!--#include file="../include/sharemethod.inc" -->
                            </div>
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
                <!--/-->
            </div>
           <%-- <div class="profit-list" id="integralItem1" style="display: block;">
            aaaaaaaaaaaaaaaaaaaa
            </div>--%>
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
    </div>
    </form>
</body>
</html>
