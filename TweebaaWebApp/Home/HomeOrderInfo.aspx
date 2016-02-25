<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Home.Master" AutoEventWireup="true"
    CodeBehind="HomeOrderInfo.aspx.cs" Inherits="TweebaaWebApp.Home.HomeOrderInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="../css/index.css" />
    <link rel="stylesheet" href="../css/home.css" />
    <link rel="stylesheet" href="../css/c.css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <script src="../js/selectNav.js" type="text/javascript"></script>
    <script src="../js/homePage.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../css/selectCss.css" />
    <script src="../js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/public.js"></script>
    <script type="text/javascript" src="../js/home-safe.js"></script>
    <script src="../MethodJs/homeOrderInfo.js" type="text/javascript"></script>    
    <script src="../js/jquery.PrintArea.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <!-- 用户中心内容 -->
    <div class="w967 home-page">
     <form id="form1" runat="server">
        <div class="wrap clearfix" id="myPrintArea">
            <div class="home-side-nav fl">
                <div class="details-l">
                    <h2 style="line-height:30px;">Order Tracking: <label id="laborderNo" ></label></h2><br />
                    <div class="section">
                        <p>
                            Delivery address：</p>
                        <p>
                            <strong><label id="labusername"></label></strong></p>
                        <p>
                            <label id="labphone"></label> &nbsp;&nbsp;<label id="labtel"></label></p>
                        <p>
                            <label id="labaddress1"></label></p>
                        <p>
                            <label id="labaddress2"></label></p>
                        <p>
                            <label id="labzip"></label></p>
                    </div>
                    <div class="section write">
                        <p>
                            Order Amount: $<label id="labprdMoney"></label></p>
                        <p>
                            Shipping: <label id="labexpressprice"></label></p>
                        <p>
                            Balance Owe: -$0</p>
                        <p class="f18">
                            Total: <strong class="red">$<label id="laborderMoney"></label></strong></p>
                        <p> Pay by Paypal</p>
                    </div>
                    <a href="javascript:void(0);" class="print">Print</a></div>
                    <script type="text/javascript">
                        $(function () {
                            $(".print").bind("click", function () {
                                $("#myPrintArea").printArea();
                            });
                        });  
                   </script> 
            </div>
            <div class="home-main details  fl">
                <div class="details-main">
                    <!--safe-main-->
                    <h2 class="t">
                        Order Details</h2>
                    <div class="section" style=" display:none;">
                        <p>
                            订单状态: <strong class="f14 blue"><asp:Label ID="laborderState" runat="server"></asp:Label></strong></p>
                        <p>
                            订单金额: <strong class="f14 red">￥<asp:Label ID="orderMoney" runat="server"></asp:Label></strong></p>
                        <p>
                            物流信息：国际小包10-30天 $35.99 快递单号：<a href="#" class="unline blue"><asp:Label ID="labexpressNo" runat="server"></asp:Label></a></p>
                        <h3 class="f14">
                            包裹跟踪</h3>
                        <div class="tracking">
                            <ul class="flow fclear">
                                <li class="complete"><em>1</em>提交订单<span class="icon"></span> <span class="time">2014-12-14
                                    00:29:42</span> </li>
                                <li class="complete"><em>2</em>支付订单<span class="icon"></span> <span class="time">2014-12-14
                                    00:29:42</span> </li>
                                <li><em>3</em>物流发货<span class="icon"></span> </li>
                                <li><em>4</em>确认收货 </li>
                            </ul>
                            <div>
                                <div class="time_line">
                                    <div class="tbox fclear">
                                        <div class="fl t_day">
                                            2014-12-20<br />
                                            15:19:57
                                            <div class="icon">
                                            </div>
                                        </div>
                                        <div class="fl t_address">
                                            已签收 签收人: 王爽
                                            <br />
                                            吉林省长春市汽车产业开发区公司
                                        </div>
                                    </div>
                                    <div class="tbox fclear">
                                        <div class="fl t_day">
                                            2014-12-20<br />
                                            15:19:57
                                            <div class="icon">
                                            </div>
                                        </div>
                                        <div class="fl t_address">
                                            已签收 签收人: 王爽
                                            <br />
                                            吉林省长春市汽车产业开发区公司
                                        </div>
                                    </div>
                                    <div class="tbox fclear">
                                        <div class="fl t_day">
                                            2014-12-20<br />
                                            15:19:57
                                            <div class="icon">
                                            </div>
                                        </div>
                                        <div class="fl t_address">
                                            已签收 签收人: 王爽
                                            <br />
                                            吉林省长春市汽车产业开发区公司
                                        </div>
                                    </div>
                                    <div class="tbox fclear">
                                        <div class="fl t_day">
                                            2014-12-20<br />
                                            15:19:57
                                            <div class="icon">
                                            </div>
                                        </div>
                                        <div class="fl t_address">
                                            已签收 签收人: 王爽
                                            <br />
                                            吉林省长春市汽车产业开发区公司
                                        </div>
                                    </div>
                                    <div class="tbox fclear">
                                        <div class="fl t_day">
                                            2014-12-20<br />
                                            15:19:57
                                            <div class="icon">
                                            </div>
                                        </div>
                                        <div class="fl t_address">
                                            已签收 签收人: 王爽
                                            <br />
                                            吉林省长春市汽车产业开发区公司
                                        </div>
                                    </div>
                                </div>
                                <a href="javascript:;" class="expand button">展开物流详情</a> <a href="javascript:;" class="pack button"
                                    style="display: none;">收起物流详情</a>
                            </div>
                        </div>
                    </div>
                    <div class="section">
                        <h3 class="t">
                            Product Details</h3>
                        <table width="100%" class="table" id="tdData">
                              
                            
                        </table>
                        <div class="pay">
                            <span style=" display:none;">可获积分：<em class="orange"> 15 </em></span><span>Order Amount :<strong class="red"> $<label id="laborderMoney2"></label></strong></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </form>
    </div>

    <script type="text/javascript">
        $(function () {




            //收起物流
            $('.tracking .button').click(function () {
                $('.tracking .button').toggle()


                if ($('.time_line').height() > 180) {
                    $('.time_line').stop().animate({ 'height': '120px' }, 500, '', function () { })
                } else {
                    $('.time_line').stop().animate({ 'height': '345px' }, 500, '', function () { })
                }
            })







            //显示设置内容
            $(".setBtn").each(function (index, el) {
                $(this).click(function () {

                    if (!$(this).hasClass('on')) {
                        $(this).text('收起')
                        $(this).addClass('on').parents("li").find(".setbox").show();
                    } else {
                        $(this).text('设置')
                        $(this).removeClass('on').parents("li").find(".setbox").hide();
                    }
                    return false;
                })

            });
            //问题下拉
            $(".selectBtn").click(function () {
                if (!$(this).siblings('dl').hasClass('db')) {
                    $(this).siblings('dl').addClass('db').show();
                } else {
                    $(this).siblings('dl').removeClass('db').hide();
                }

            })
            $(".safe-q-box").mouseleave(function (event) {
                $(this).find('dl').removeClass('db').hide();
            });
            $(".safe-q-box").find("dl a").click(function (event) {
                $(".safe-q").val($(this).text())

                return false;
            });
        })
</script>
</asp:Content>
