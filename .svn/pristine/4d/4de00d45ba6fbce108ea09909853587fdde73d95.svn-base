<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeAdress.aspx.cs" Inherits="TweebaaWebApp.Home.HomeAdress" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Css/index.css" />
    <link rel="stylesheet" href="../Css/home.css" />
    <link rel="stylesheet" href="../Css/mycart.css" />
    <link rel="stylesheet" href="../Css/c.css" />
    <script src="../Js/jquery.min.js" type="text/javascript"></script>
    <script src="../Js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/jquery-hcheckbox.js"></script>
    <script src="../Js/selectNav.js" type="text/javascript"></script>
    <script src="../Js/homePage.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../Css/selectCss.css" />
    <script src="../Js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/public.js"></script>
    <script type="text/javascript" src="../Js/home-safe.js"></script>
    <script src="../Js/address.js" type="text/javascript"></script>
    <script src="../MethodJs/homeUserAddress.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <!-- 用户中心内容 -->
        <div class="home-main address  fl">
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
            <div class="address-main">
                <!--safe-main-->
                <h2 class="t">
                    Delivery Address Management</h2>
                <form action="">
                <table width="100%">
                    <tr>
                        <td class="t">
                            Country<span class="h">*</span>
                        </td>
                        <td>
                            <div class="clearfix">
                                <div class="selectBox pr fl">
                                    <select id="selectCountry">
                                        <%-- class="selects"--%>
                                        <option selected="selected" value="1" style="width: 150px;">China</option>
                                    </select>
                                </div>
                                <div class="selectBox pr fl">
                                    <%--class="selects"--%>
                                    <select  id="selectProvince" style="width: 150px;">
                                    </select>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            City<span class="h">*</span>
                        </td>
                        <td>
                            <input type="text" class="txt textCity" id="txtCity" style="text-align:left"/>
                            <span class="error" >Please enter City</span> <span class="ok">ok</span>
                        </td>
                    </tr>

                    <tr>
                        <td class="t">
                            Zip Code<span class="h">*</span>
                        </td>
                        <td>
                            <input type="text" class="txt textZip" id="txtZip" style="text-align:left"/>
                            <span class="error">Please enter zip code</span> <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Detail Address<span class="h">*</span>
                        </td>
                        <td>
                            <textarea name="" class="txt areaall" id="txtAddress" placeholder="Between 5 to 120 characters" style="text-align:left"></textarea>
                            <span class="error">Between 5 to 120 characters</span> <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Name<span class="h">*</span>
                        </td>
                        <td>
                            <input type="text" class="txt name" id="txtName" placeholder="Maximum 25 characters" style="text-align:left"/>
                            <span class="error">Receiver name must be in 2 to 25 characters</span> <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Mobile Number／Tel<span class="h">*</span>
                        </td>
                        <td>
                            <input type="text" class="txt phoneNum" id="txtPhone" placeholder="Area code+ phone number/mobile number" style="text-align:left"/>
                            <span class="error">Phone(027-88888888)or mobile 13412345678</span> <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Primary
                        </td>
                        <td>
                            <input type="checkbox" class="checkbox" id="ckbDefault" checked="checked" />
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                        </td>
                        <td>
                            <input type="button" value="Save" id="btnSave" class="send" onclick="AddAddress()" />
                        </td>
                    </tr>
                </table>
                </form>
                <div>
                    <p class="t f14">
                        Already saved<span class="blue">
                            <label id="labcount">
                            </label>
                        </span></p><%--，还能保存 <span class="blue">10</span> 条地址</p>--%>
                        <table width="100%" class="table" id="tabAddress">
                        </table>
                </div>
            </div>
        </div>
    <!-- 新建收货地址 弹出框-->
    <div class="add-new-address-box">
        <a href="javascript:;" class="closeBtn"></a>
        <h2 class="t">
            Edit Delivery Address</h2>
        <form action="">
        <table width="100%">
            <tr>
                <td class="t">
                    Country<span class="h">*</span>
                </td>
                <td>
                    <div class="clearfix">
                        <div class="selectBox pr fl">
                            <select id="selectCountry2">
                                <option selected="selected" value="1">China</option>
                            </select>
                        </div>
                        <div class="selectBox pr fl">
                            <select id="selectProvince2">
                            </select>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="t">
                    City<span class="h">*</span>
                </td>
                <td>
                    <input type="text" class="txt textCity" id="txtCity2" />
                    <span class="error">Enter City</span> <span class="ok">ok</span>
                </td>
            </tr>
            <tr>
                <td class="t">
                    Postal code<span class="h">*</span>
                </td>
                <td>
                    <input type="text" class="txt textZip" id="txtZip2" />
                    <span class="error">Enter postal code</span> <span class="ok">ok</span>
                </td>
            </tr>
            <tr>
                <td class="t">
                    Detailed Address<span class="h">*</span>
                </td>
                <td>
                    <textarea name="" class="txt areaall" id="txtAddress2" placeholder="Must be in 5 to 120 characters" ></textarea>
                    <span class="error">Between 5 to 120 characters</span> <span class="ok">ok</span>
                </td>
            </tr>
            <tr>
                <td class="t">
                    Name<span class="h">*</span>
                </td>
                <td>
                    <input type="text" class="txt name" id="txtName2" placeholder="Maximum 25 characters" />
                    <span class="error">Receiver name must be in 2 to 25 characters</span> <span class="ok">ok</span>
                </td>
            </tr>
            <tr>
                <td class="t">
                    Phone/Mobile number<span class="h">*</span>
                </td>
                <td>
                    <input type="text" class="txt phoneNum" id="txtPhone2" placeholder="Are code + phone number/mobile number" />
                    <span class="error">Phone(027-88888888)or mobile13412345678</span> <span class="ok">ok</span>
                </td>
            </tr>
            <tr>
                <td class="t">
                    Set as default
                </td>
                <td>
                    <input type="checkbox" class="checkbox" id="ckbDefault2" checked="checked" />
                </td>
            </tr>
            <tr>
                <td class="t">
                </td>
                <td>
                    <input type="button" value="Save" class="send" id="btnSave2" />
                </td>
            </tr>
        </table>
        </form>
    </div>
    <div class="greybox">
    </div>
    </form>
    <script type="text/javascript">



        $("input").placeholder()

        // select 美化
        $(".selects").selectCss();

        $(".send").click(function (event) {
            $(".greybox,.add-new-address-box").hide();
        });

        //增加地址
        $(".modify > a").click(function (event) {
            $(".greybox,.add-new-address-box").show();
            $(".add-new-address-box").find('h2').text("Add new shipping address")
            return false;
        });
        $(" .add-new-address-box .send").click(function (event) {
            $(".greybox,.add-new-address-box").hide();
        });

        $(".closeBtn").click(function (event) {
            $(".greybox").hide();
            $(this).parent().hide();
            return false;
        });







        $(function () {
            //显示设置内容
            $(".setBtn").each(function (index, el) {
                $(this).click(function () {

                    if (!$(this).hasClass('on')) {
                        $(this).text('Shrinkage')
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
</body>
</html>
