<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeOrderRefund.aspx.cs" Inherits="TweebaaWebApp.Home.HomeOrderRefund" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../css/index.css" />
    <link rel="stylesheet" href="../css/home.css" />
    <link rel="stylesheet" href="../css/c.css" />
    <script src="../Js/jspage/jquery-1.10.2.min.js" type="text/javascript"></script>
    <%--<script src="../js/jquery.min.js" type="text/javascript"></script>--%>
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <script src="../js/selectNav.js" type="text/javascript"></script>   
     <script src="../js/homePage.js" type="text/javascript"></script>

    <link rel="stylesheet" href="../css/selectCss.css" />
    <script src="../js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/public.js"></script>

    <script type="text/javascript" src="../js/home-safe.js"></script>
    <script src="../MethodJs/homeOrderRefund.js" type="text/javascript"></script>
    
    <%--分页--%>
    
    <script src="../Js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="../Js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!-- 用户中心内容 -->
    <div class="home-main order  fl">
        <!-- 搜索 -->
        <div id="selectnav" class="clearfix" style=" display:none;">
            <div class="select-search bdccc fl">
                <input type="text" class="txt" placeholder="请输入搜索产品的名称，关键词">
                <div class="select2 fr bdccc pr">
                    <h2 s-data="0">
                        产品搜索
                    </h2>
                    <ul class="select2-nav bdccc">
                        <li><a href="#" s-data="1">我的发布</a> </li>
                        <li><a href="#" s-data="2">我的评审</a> </li>
                        <li><a href="#" s-data="3">我的分享</a> </li>
                        <li><a href="#" s-data="4">我的订单</a> </li>
                        <li><a href="#" s-data="5">我的收藏</a> </li>
                        <li><a href="#" s-data="6">我的浏览</a> </li>
                    </ul>
                </div>
            </div>
            <div class="search-button fl">
                <button class="btn-search" type="submit">
                </button>
            </div>
        </div>
        <!-- 搜索over -->
        <div class="order-main">
            <!--safe-main-->
            <h2 class="t">
                Return Or Refund</h2>
            <div class="collection-select clearfix">
                <span class="fl">Order Status </span>
                <div class="select-box fl pr">
                    <h3 s-data="0" id="s-data">
                        All</h3>
                    <ul class="select-list">
                        <li><a href="#" s-data="1">Payment Pending</a> </li>
                        <li><a href="#" s-data="2">Paid</a> </li>
                        <li><a href="#" s-data="3">Delivered</a> </li>
                        <li><a href="#" s-data="4">Transaction Completed</a> </li>
                    </ul>
                </div>
                <span class="fr"><span class="fl">Share on</span>
                    <input type="text" value="" class="time-text">
                    <span class="fl">To</span>
                    <input type="text" value="" class="time-text">
                    <input type="submit" class="submit" value="Search" />
                </span>
            </div>
            <table width="100%" class="table">
                <tr>
                    <th width="" style="border-left: #ccc 1px solid;">
                        Product
                    </th>
                    <th width="82">
                        Price($)
                    </th>
                    <th width="72">
                        Quantity
                    </th>
                   <%-- <th width="78">
                        Action
                    </th>--%>
                    <th width="110">
                        Payment($)
                    </th>
                    <th width="120" style="border-right: #ccc 1px solid;">
                       Status/Action
                    </th>
                </tr>
                <tr>
                    <td colspan="6">
                        <input type="checkbox" class="checkbox" /><a href="javascript:;">Select all</a> <a href="javascript:;"
                            class="button simple">Combine Payment</a> <a href="javascript:;" class="simple button">Delete</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" id="tdData">
                    </td>
                </tr>
            </table>
            <%--<div class="page tr">
                <a href="#" class="up">&lt;</a> <a href="#">1</a> <a href="#">2</a> <a href="#" class="on">
                    3</a> <a href="#">4</a> <a href="#">5</a> <a href="#">6</a> <a href="#">7</a>
                <a href="#">8</a> <a href="#" class="down">&gt;</a>
            </div>--%>
            <div style="width: 900px; margin: 0 auto;">
                <div id="kkpager" style="float:right; padding-right:150px;">
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
<script type="text/javascript">
    $(function () {

        $('.order-main .sum').hover(function () {

            $(this).addClass('hover')
        },
		function () {
		    $(this).removeClass('hover')
		})

        //显示设置内容
        $(".setBtn").each(function (index, el) {
            $(this).click(function () {

                if (!$(this).hasClass('on')) {
                    $(this).text('Pack up')
                    $(this).addClass('on').parents("li").find(".setbox").show();
                } else {
                    $(this).text('Set')
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
<script type="text/javascript">
    //init
    //    $(function () {
    //        //生成分页
    //        //有些参数是可选的，比如lang，若不传有默认值
    //        kkpager.generPageHtml({
    //            pno: 1,
    //            //总页码
    //            total: 30,
    //            //总数据条数
    //            totalRecords: 1000,
    //            mode: 'click', //默认值是link，可选link或者click
    //            click: function (n) {               
    //                page = n;
    //                loadMeinv();
    //                //手动选中按钮
    //                this.selectPage(n);
    //                return false;
    //            }
    //            /*
    //            ,lang				: {
    //            firstPageText			: '首页',
    //            firstPageTipText		: '首页',
    //            lastPageText			: '尾页',
    //            lastPageTipText			: '尾页',
    //            prePageText				: '上一页',
    //            prePageTipText			: '上一页',
    //            nextPageText			: '下一页',
    //            nextPageTipText			: '下一页',
    //            totalPageBeforeText		: '共',
    //            totalPageAfterText		: '页',
    //            currPageBeforeText		: '当前第',
    //            currPageAfterText		: '页',
    //            totalInfoSplitStr		: '/',
    //            totalRecordsBeforeText	: '共',
    //            totalRecordsAfterText	: '条数据',
    //            gopageBeforeText		: ' 转到',
    //            gopageButtonOkText		: '确定',
    //            gopageAfterText			: '页',
    //            buttonTipBeforeText		: '第',
    //            buttonTipAfterText		: '页'
    //            }*/
    //        });
    //    });
</script>
</html>
