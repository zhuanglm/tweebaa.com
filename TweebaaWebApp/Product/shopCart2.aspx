<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="shopCart2.aspx.cs" Inherits="TweebaaWebApp.Product.shopCart2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="../Css/buyall.css" />
    <link rel="stylesheet" href="../Css/mycart.css" />
    <script type="text/javascript" src="../Js/addnumber.js"></script>
    <%--<script type="text/javascript" src="../Js/pop-up-cart.js"></script>--%>
    <script type="text/javascript" src="../Js/shopcarFloat.js"></script>
    <%--<script src="../MethodJs/buy.js" type="text/javascript"></script>--%>
    <script src="../MethodJs/calculate.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <!-- 购物车 -->
    <div class="w975 my-favorites">
        <h2 class="t">
            My Shopping Cart
        </h2>
        <div class="clearfix pro-list-t">
            <div class="fr">
                Selected Items(S/H not included)：<strong class="prict-total">$<label id="labPayMoney1"></label></strong><a
                    href="#" onclick="CreateOrder()" class="settlement-btn">Check Out</a>
            </div>
            <div class="tab fl">
                <a href="javascript:;" class="active" onclick="ActiveClass(this,'')">All Items <b>
                    <label id="labSumCount">
                    </label>
                </b></a><a href="javascript:;" onclick="ActiveClass(this,2)">Test-Sale Items <b>
                    <label id="labPreCount">
                    </label>
                </b></a><a href="javascript:;" onclick="ActiveClass(this,3)">Final-Sale Items <b>
                    <label id="labSaleCount">
                    </label>
                </b></a>
            </div>
        </div>
        <div class="pro-list-box">
            <asp:Repeater ID="repData" runat="server">
                <HeaderTemplate>
                    <table id="tabCart">
                        <tr>
                            <th colspan="3" class="first">
                                <label>
                                    <input type="checkbox" onclick="CheckAll(this)" class="all-select-btn" />Select
                                    all
                                </label>
                                <span class="name-t">Product Information</span>
                            </th>
                            <th>
                            </th>
                            <th>
                                Unit Price(USD)
                            </th>
                            <th>
                                Quantity
                            </th>
                            <th>
                                Test/Final-Sale
                            </th>
                            <th>
                                Amount（USD）
                            </th>
                            <th>
                                Action
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="first" style="width: 25px; overflow: hidden">
                            <input type="checkbox" class="checkbox" value='<%#Eval("guid") %>' id='<%# "ckb"+(Container.ItemIndex + 1)%>' checked="checked" onclick="SettleAccounts(this)" />
                            <input type="hidden" id="hidCartGuid" value='<%#Eval("guid") %>' />
                            <input type="hidden" id="hidPrdGuid" value='<%#Eval("prdguid")%>' />
                        </td>
                        <td class="pro-des" colspan="2">                            
                            <div class="pro-des-box">                          
                                <a href="#" class="imglink">
                                    <img src='<%# picPath+Eval("fileurl").ToString().Replace("big", "small") %>' alt="" />
                                </a>
                                <div class="des">
                                    <p class="baobei-name">
                                        <a href="#">
                                            <%#Eval("name") %></a>
                                    </p>
                                    <p class="baobei-num">
                                    </p>
                                </div>
                            </div>
                        </td>
                        <td class="colorsize">
                            <div class="color-size">
                                <p>
                                    <div style="float: left;">
                                        Color：</div>
                                    <div style='float: left; width: 24px; height: 24px; background-color: <%#Eval("color")%>'>
                                    </div>
                                    <br />
                                    <div style="float: left;">
                                        Size :
                                        <%#Eval("prorule") %></div>
                                </p>
                                <i class="icon-bj"></i>
                                <div class="change-colorsize">
                                    <i class="icon-sjx"></i>
                                    <div class="pro-img fr">
                                        <img src="../Images/160x160.jpg" alt="" />
                                    </div>
                                </div>
                            </div>
                        </td>
                        <td class="unit-price">
                            <del>
                                <%#Eval("estimateprice") %></del><br />
                            <strong>
                                <label id='<%#"labPrice"+(Container.ItemIndex + 1) %>'>
                                    <%# Eval("saleprice")%></label>
                            </strong>
                        </td>
                        <td class="baobei-number">
                            <span class="number-box"><a href="javascript:;" class="jian-btn" onclick="AddNum(this,'jian')"></a>
                            <a href="javascript:;" class="jia-btn" guid='<%#Eval("guid")%>' index='<%# Container.ItemIndex + 1 %>' onclick="AddNum(this,'jia')"></a>
                                <input type="text" value='<%# Convert.ToInt32(Eval("quantity")) %>' class="num" id='<%# "num"+(Container.ItemIndex + 1) %>' onkeyup="AddNum(this,'deng')" />
                            </span>
                        </td>
                        <td>
                            <div class="' + stateColor + '">
                             <%#Eval("wnstat").ToString() == "2" ? "Test-Sale" : "Final-Sale"%>
                             </div>
                        </td>
                        <td>
                            <div class="red">
                                <strong>
                                    <label id='<%#"labSum"+(Container.ItemIndex + 1) %>'/>
                                   <%-- <%#Eval("wnstat").ToString() == "2" ? Eval("premoney") : Eval("money")%>--%>
                                    </label></strong></div>
                        </td>
                        <td>
                            <div class="funbtn">
                                <a href="javascript:;" class="delthis" onclick='DeletShopCart(<%#Eval("guid") %>)'>
                                    Delete</a><br />
                                <a href="javascript:;" onclick='FavoritePrd(<%#Eval("prdguid") %>)'>Favorite</a></div>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
               
            </asp:Repeater>
        </div>
        <div class="del-tips">
            Delete one item successfully, you can revoke the delete if it is a mistake. <a href="#">
                Revoke</a>
        </div>
    </div>
    <!-- 结算 -->
    <div class="settlement-box">
        <div class="w975 pr">
            <div class="fr">
                <span class="select-nubmer fl">Selected Items <strong>
                    <label id="labPayCount">
                    </label>
                </strong>Pieces </span><span class="prict-total fl">Grand Total(S/H not included)：<strong>
                    $<label id="labPayMoney2"></label>
                </strong></span><a href="#" onclick="CreateOrder()" class="settlement-btn fl">Check
                    Out </a>
            </div>
            <label>
                <input type="checkbox" class="all-select-btn" onclick="CheckAll(this)" />
                Select all
            </label>
            <a href="javascript:void(0);" onclick="DeletShopCartAll()">Delete</a><a href="javascript:void(0);"
                onclick="FavoritePrdAll()">Move to Favorite</a><a href="#">Share & Earn</a>
            <!-- 购物车弹出框 -->
            <div class="pop-up-cart" style="display: none;">
                <a href="#" class="btn leftBtn"></a><a href="#" class="btn rightBtn"></a><i class="icon-sjx">
                </i>
                <div class="box hid">
                    <ul>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                        <li><a href="#">
                            <img src="../Images/80x80.jpg" alt="" /></a> </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="w975 jstab" style="display: none;">
        <div class="tab-sc clearfix">
            <a href="#" class="fr gotomy">Go to my Favorite>></a>
            <div class="tab fl">
                <a href="javascript:;" class="active">Favorited</a> <a href="javascript:;">Recent Viewed</a>
            </div>
        </div>
    </div>
    <!-- 筛选排序 -->
    <!-- 列表	 -->
    <div class="w964 recent-collection jstabcon" id="mainsrp-itemlist" style="display: none;">
        <div class="m-itemlist">
            <div class="items clearfix">
            </div>
            <div class="down-more tc">
                <a href="#" class="down-mores">View More</a>
            </div>
        </div>
    </div>
    <div class="w964 recent-viewed jstabcon" id="mainsrp-itemlist" style="display: none;">
        <div class="m-itemlist">
            <div class="items clearfix">
            </div>
            <div class="down-more tc">
                <a href="#" class="down-mores">View More</a>
            </div>
        </div>
    </div>
    <!-- 浮动在线咨询 -->
    <div id="floatALink" style="top: 215px">
        <a href="#" class="zxzz">Online<br>
            Help</a> <a href="#" id="gotoTop">Back<br>
                to Top</a>
    </div>
    <!-- 浮动在线咨询 -->
    <!-- 删除商品弹出框 -->
    <div class="del-shop-tck">
        <a href="javascript:;" class="closeBtn"></a><strong>Delete Items</strong>
        <p>
            Confirm to delete the item?
        </p>
        <a href="#" class="enter-del">Confirm </a><a href="#" class="cancel-del">Cancel
        </a>
    </div>
    <!-- 支付方式 -->
    <div class="payment-methods">
        <a href="javascript:;" class="closeBtn"></a>
        <p class="t">
            支付方式选择
        </p>
        <ul class="clearfix">
            <li>
                <label>
                    <input type="radio" name="payGroup" checked="checked" />
                    <img src="../Images/pay1.png" alt="" />
                </label>
            </li>
            <li>
                <label>
                    <input type="radio" name="payGroup" />
                    <img src="../Images/pay2.png" alt="" />
                </label>
            </li>
        </ul>
        <a href="#" class="gotoPay">Pay Now </a>
    </div>
    <div class="greybox">
    </div>
    <script type="text/javascript">
        //表单提示
        $('input, textarea').placeholder();
        //表单美化
        $('.chklist').hcheckbox();

        //编辑 颜色 尺寸
        $(".color-size").mouseenter(function (event) {
            $(this).addClass('on')
        }).mouseleave(function (event) {
            $(this).removeClass('on').find('.change-colorsize').hide();
        });
        $(".icon-bj").click(function (event) {
            $(this).siblings('.change-colorsize').show();
        });
        $(".chima").find("span").click(function (event) {
            $(this).addClass('on').siblings('span').removeClass('on')
        });
        $(".chima").find("a").click(function (event) {
            $(this).parents(".color-size").removeClass('on').find('.change-colorsize').hide();

            return false;
        });
        //显示 收藏和分享

        $("#mainsrp-itemlist .box").live('mouseenter', function (event) {
            $(this).addClass('hover')
            $(this).find(".floatDiv").stop().animate({ top: 0 }, 100)
        }).live('mouseleave', function (event) {
            $(this).removeClass('hover')
            $(this).find(".floatDiv").stop().animate({ top: "-110px" }, 100)
        });

        // 全选
        //        $(".all-select-btn").click(function (event) {
        //            if (!$(this).attr('checked')) {
        //                $(".checkbox,.all-select-btn").attr('checked', false)
        //            } else {

        //                $(".checkbox,.all-select-btn").attr("checked", true);
        //            }
        //        });
		
		
    </script>

    <script type="text/javascript">
        function AddNum(obj,action) {
            var guid, index;
            guid = $(obj).attr("guid");
            index = $(obj).attr("index");

            var objNumber = "num" + index; //数量
            var number = 1;
            if (action=="jia") {
                number = $("#" + objNumber).val() + 1;
            }
            if (action=="jian") {
                number = $("#" + objNumber).val() - 1;
            }
            if (action == "deng") {
                number = $("#" + objNumber).val();
            }

            var p = "#labPrice" + index;
            var price = $(p).text();
            alert(price);
            $("#labSum" + index).html(parseInt(number * price));


//            var _data = "{ action:'" + 'AddNum' + "',guid:'" + guid + "',number:'" + number + "'}";
//            $.ajax({
//                type: "POST",
//                url: '../AjaxPages/shopCartAjax.aspx',
//                data: _data,
//                dataType: "text",
//                success: function (resu) {
//                    if (resu == "1") {
//                        var p = "#labPrice" + index;
//                        var price = $(p).text();
//                        $("#labSum"+index).html(parseInt(number * price));
//                    }
//                    else if (resu == "0") {
//                        alert("false");
//                    }
//                },
//                error: function (XMLHttpRequest, textStatus, errorThrown) {

//                }
//            });
        }

    </script>
</asp:Content>
