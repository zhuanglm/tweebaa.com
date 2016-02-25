<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="shopOrder.aspx.cs" Inherits="TweebaaWebApp.Product.shopOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
    Check Out - purchase, share and earn on Tweebaa
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="../Css/index.css" />
    <link rel="stylesheet" href="../Css/buyall.css" />
    <link rel="stylesheet" href="../Css/mycart-new.css" />
    <script src="../Js/address.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../Css/selectCss.css" />
    <script src="../Js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/pop-up-cart.js"></script>
    <script type="text/javascript" src="/js/jquery.cookie.js"></script>
    <script type="text/javascript" src="/js/jquery.base64.js"></script>
    <script src="../MethodJs/userAddress.js" type="text/javascript"></script>
    <script src="../MethodJs/order.js" type="text/javascript"></script>
    <script src="../MethodJs/calculate.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <input type="hidden" id="hidAddressId" value="<%=_addressCartGudid %>" />
    <!-- 收货地址 -->
    <div class="your-address w975 clearfix">
        <div class="saved-address">
            <div class="title clearfix" style="text-align: left; padding-bottom: 0px; padding-top: 0px;">
                <h2 class="t">
                    Delivery address
                </h2>
            </div>
            <p id="pAddress">
                <%--Jun cao<br />
                1800 Edmund ave,<br />
                toronto, Ontario, M3N2S5<br />
                Canada<br />
                Phone: 416229999<br />
                Email: cjunjun@gmail.com--%>
                <label id="labName">
                </label>
                <br />
                <label id="labAddress">
                </label>
                <br />
                <label id="labCountry">
                </label>
                <br />
                <label id="labCountryID" style="display: none"></label>
                <label id="labProvinceID" style="display: none"></label>
                Zip:
                <label id="labZip"></label>
                <br />
                Phone:
                <label id="labPhone">
                </label>
                <br />
                <label id="labEmTitle">
                    Email:
                </label>
                <label id="labEmail">
                </label>
            </p>
            <input type="button" value="Change" class="send" onclick="change()" />
            <script type="text/javascript">
                function change() {
                    $(".saved-address").hide();
                    $(".shop-address").show();
                }
                //                $(function () {
                //                    var _displaySaved="<%=_displaySaved %>";                    
                //                    if (_displaySaved=="none") {
                //                        $(".saved-address").hide();
                //                        $(".shop-address").show();
                //                    }
                //                    else {
                //                        $(".saved-address").show();
                //                        $(".shop-address").hide();
                //                 }
                //                 
                //                });
            
            </script>
        </div>
        <div class="w975 shop-address">
            <div class="fir-address-box">
                <div class="title clearfix" style="text-align: left; padding-bottom: 0px; padding-top: 0px;">
                    <h2 class="t">
                        Delivery address
                    </h2>
                </div>
                <table width="100%">
                    <tr>
                        <td class="t">
                            First Name<span class="h">*</span>
                        </td>
                        <td>
                            <input type="text" class="txt name" id="txtName" style="width: 150px;" placeholder="Input your first name" />
                            <span class="error" id="errorNmae">Receiver name have to be 2-25 characters</span>
                            <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Last Name<span class="h">*</span>
                        </td>
                        <td>
                            <input type="text" class="txt name" id="txtLastName" style="width: 150px;" placeholder="Input your last name" />
                            <span class="error" id="errorlastName">Receiver name have to be 2-25 characters</span>
                            <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Address line 1<span class="h">*</span>
                        </td>
                        <td>
                            <%--<textarea name="" class="txt areaall" id="txtAddress" placeholder="Choose from list, between 5-120 characters"></textarea>--%>
                            <input type="text" class="txt2 areaall" id="txtAddress" placeholder="Input your address" />
                            <span class="error" id="errorAddress">5-120 characters</span> <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Address line2<%--<span class="h">*</span>--%>
                        </td>
                        <td>
                            <%--<textarea name="" class="txt areaall" id="txtAddress2" placeholder="Choose from list, between 5-120 characters"></textarea>--%>
                            <input type="text" class="txt2 areaall" id="txtAddress2" placeholder="Input your address" />
                            <span class="error" id="Span1">5-120 characters</span> <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            City<span class="h">*</span>
                        </td>
                        <td>
                            <input type="text" class="txt name" id="txtCity" placeholder="Input city name" />
                            <span class="error" id="errorCity">Input city name</span> <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Zip/Postal Code<span class="h">*</span>
                        </td>
                        <td>
                            <input type="text" class="txt textZip" id="txtZip" />
                            <span class="error" id="errorZip">Input zip/postal code</span> <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Country<span class="h">*</span>
                        </td>
                        <td>
                            <div class="clearfix" style="float: left;">
                                <div class="selectBox pr fl">
                                    <select name="" id="selectCountry" style="width: 150px;">
                                    </select>
                                </div>
                                <div class="selectBox pr fl">
                                    <select name="" id="selectProvince" style="width: 150px;">
                                    </select>
                                </div>
                            </div>
                            <span class="error" id="errorArea" style="float: left;">Please select area</span><span
                                class="ok">ok</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Phone<span class="h">*</span>
                        </td>
                        <td>
                            <input type="text" class="txt phoneNum" id="txtPhone" placeholder="Area code + tel/mobile number" />
                            <span class="error" id="errorPhone">Tel:(027-88888888)or Mobile:416 000 000 </span>
                            <span class="ok">ok</span>
                        </td>
                    </tr>
                     <tr>
                        <td class="t">
                            Email<span class="h">*</span>
                        </td>
                        <td>
                            <input type="text" class="txt phoneNum" id="txtEmail" placeholder="Email" />
                            <span class="error" id="errorEmail">Input email</span>
                            <span class="ok">ok</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td class="t">
                            Set as Default
                        </td>
                        <td>
                            <input type="checkbox" class="checkbox" id="ckbDefault" checked="checked" />
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                        </td>
                        <td>
                            <input type="button" value="Save" id="btnSave" class="send" onclick="btnSaveClick()" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="ship-meth">
            <div class="title clearfix" style="text-align: left; padding-bottom: 0px; padding-top: 0px;">
                <h2 class="t">
                    Cart summary (<label id="labCount2"></label>
                    items)
                </h2>
            </div>
            <p>
                Total: $<label id="labPayMoney"></label><br />
                <a href="javascript:void(0);">
                    <img src="https://www.paypalobjects.com/webstatic/en_US/i/buttons/cc-badges-ppmcvdam.png"
                        alt="Buy now with PayPal" class="gotoPay" />
                </a>
            </p>
        </div>
        <div class="show-all-address">
            <ul>
                <li>
                    <label>
                        <input type="radio" name="all-address" />
                        <span>Jiang Xi 260 Area (Yokee)13576032421 </span>
                    </label>
                    <span class="set-moren">Set as Default </span></li>
                <li>
                    <label>
                        <input type="radio" name="all-address" />
                        <span>Jiang Xi 260 Area (Yokee)13576032421 </span>
                    </label>
                    <span class="set-moren">Set as Default </span></li>
                <li>
                    <label>
                        <input type="radio" name="all-address" />
                        <span>Jiang Xi 260 Area (Yokee)13576032421 </span>
                    </label>
                    <span class="set-moren">Set as Default </span></li>
                <li>
                    <label>
                        <input type="radio" name="all-address" />
                        <span>Jiang Xi 260 Area (Yokee)13576032421 </span>
                    </label>
                    <span class="set-moren">Set as Default </span></li>
            </ul>
        </div>
    </div>
    <!-- 商品清单 -->
    <div class="w975  commodities-list">
        <div class="title clearfix" style="text-align: left; padding-bottom: 0px; padding-top: 0px;">
            <h2 class="t">
                Items List
            </h2>
        </div>
        <%--<div class="list-t clearfix">
            <span class="fl">Ship From China </span><span class="fr">Pay only this seller</span>
        </div>--%>
        <div class="list-con clearfix" id="tableOrderDetails">
            <table id="tableOrder" style="width: 100%; ">
                <tr>
                    <th class="pro-infor" colspan="2">
                        Product Information
                    </th>
                    <%-- <th class="pro-zt">
                        Status
                    </th>--%>
                    <th class="pro-num">
                        Quantity
                    </th>
                    <th class="pro-price">
                        Unit Price
                    </th>
                    <th>
                        Shipping Method
                    </th>
                    <th>
                        Shipping Fee <%     //this is a hidden column %>
                    </th>
                    <th class="pro-total">
                        Sub-Total
                    </th>
                    <th>
                        Shipping Partner <% // this is a hidden column %>
                    </th>
                    <th>
                        Free Shipping <%    // this is a hidden column %>
                    </th>
                </tr>
            </table>
            <!-- 备注 he 快递-->
            <div class="beizhu clearfix" style="width: 818px; display: none">
                <input type="text" class="beizhu-txt fl" placeholder="Buyer's remark" id="txtMessage"
                    style="width: 650px; margin-left: -21px;" />
                <span class="fl select-wuliu-t" style="display: none;">Shipping Fee:</span>
                <div class="fl select-wuliu pr" style="width: 300px; display: none;">
                    <i class="showUl"></i>
                    <h2 style="padding-right: 0px;">
                        <label id="lablogistics">
                        </label>
                        <%-- China  Post 35.7 USD   deliver in 15-40 days--%>
                    </h2>
                    <ul id="ullogistics">
                    </ul>
                </div>
                <div class="kuaidi-price fl" style="width: 130px; text-align: right; display: none;">
                    <b>$ </b>
                    <%--<b style="margin-left:120px;">$ </b>--%>
                    <strong>
                        <label id="lablogistics1">
                            0</label></strong>
                </div>
            </div>
        </div>
        <!-- 订单信息 -->
        <div class="orderInfor clearfix">
            <div class="item1 fr" id="extra_info_table" style=" float:left; width:100%;">
                <table width="100%" border="0" style=" width:390px; float:left;">
                    <tbody>
                       <%-- <tr>
                            <td width="250">
                               Use Shopping Reward Points?
                            </td>
                            <td style="text-align: right; padding-right: 39px; width:140px; font-size:10px;">
                              Avallable 400 points<br />
                              Redemption Value:$5.00
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="2" style=" width:390px; text-align:left; padding-left:20px; float:left; padding-bottom:33px;">
                            <div style="float:left; height:35px;  width:100%;">
                               <p style="padding-top:10px; width:200px; float:left; font-size:14px;">Use Shopping Reward Points?  </p> 
                               <p style="font-size:10px; padding-top:0px;  width:150px; float:right; padding-right:30px; line-height:15px;">Avallable <label id="labPoint"><%=_shoppingPoint%></label> points.<br /> Redemption Value:$<label id="labPointMoney"><%=_shoppingPointMoney %></label></p>
                             </div> <br />                             
                              <div style="float:left;">
                                 <input type="text" placeholder="Enter $ amount" id="txtPointMoney"  style="width:190px;" />&nbsp;&nbsp;
                                 <input type="button" value="Apply All" onclick="ApplyAllPoint()"  style=" width:100px;"/>
                                 <script type="text/javascript">
                                     function ApplyAllPoint() {
                                         var pointMoney = Number($("#labPointMoney").text());
                                         var orderTotal = Number($("#labPayMoney2").text());
                                         if (pointMoney <= orderTotal) {
                                             $("#txtPointMoney").val(pointMoney);
                                         }
                                         else {
                                             $("#txtPointMoney").val(orderTotal);
                                         }
                                     }
                                 </script>
                              </div>
                        </tr>
                        <tr>
                            <td colspan="2" style=" text-align:left; padding-left:20px; padding-bottom:35px;">
                             Use Tweebucks? Current Balance $<label id="labTweebucks" style=" margin-left:1px"><%=_extractionTweebuck %></label><br />
                             <input type="text" placeholder="Enter $ amount" id="txtTweebuck"  style="width:190px;" />&nbsp;&nbsp;
                             <input type="button" value="Apply All" onclick="ApplyAllTweebuck()"  style=" width:100px;"/>
                             <script type="text/javascript">
                                 function ApplyAllTweebuck() {
                                     var tweebucks = Number($("#labTweebucks").text());
                                     var orderTotal = Number($("#labPayMoney2").text());
                                     if (tweebucks <= orderTotal) {
                                         $("#txtTweebuck").val(tweebucks);
                                     }
                                     else {
                                         $("#txtTweebuck").val(orderTotal);
                                     }
                                 }
                                 </script>
                        </tr>
                      
                        <%--<tr id="tr2">
                           <td colspan="2">Have promotional code?</td>
                        </tr>--%>
                      
                    </tbody>
                </table>
                <table width="100%" border="0" style=" width:362px; float:right;">
                    <tbody>
                        <tr>
                            <td width="190">
                                Sub-Total (<label id="labCount"></label>
                                items):
                            </td>
                            <td style="text-align: right; padding-right: 39px;">
                                <%--<td  style="text-align:left; padding-left:102px;">--%>
                                $<label id="labPrdMoney"></label>
                            </td>
                        </tr>
                        <tr id="trShipCost" style="display:none">
                            <td>
                                Shipping Cost:
                            </td>
                            <td style="text-align: right; padding-right: 39px;">
                                $<label id="lablogistics2">0.00</label>
                            </td>
                        </tr>
                        <tr id="trTax">
                            <td>
                                Sales Tax
                                <label id="labTaxRate">
                                    0%</label>:
                            </td>
                            <td style="text-align: right; padding-right: 39px;">
                                $<label id="labTax">0.00</label>
                            </td>
                        </tr>
                        <tr id="trTaxGST">
                            <td>
                                GST
                                <label id="labTaxGSTRate">
                                    0%</label>:
                            </td>
                            <td style="text-align: right; padding-right: 39px;">
                                $<label id="labTaxGST">0.00</label>
                            </td>
                        </tr>
                        <tr id="trTaxHST">
                            <td>
                                HST
                                <label id="labTaxHSTRate">
                                    0%</label>:
                            </td>
                            <td style="text-align: right; padding-right: 39px;">
                                $<label id="labTaxHST">0.00</label>
                            </td>
                        </tr>
                        <tr id="trTaxQST">
                            <td>
                                QST
                                <label id="labTaxQSTRate">
                                    0%</label>:
                            </td>
                            <td style="text-align: right; padding-right: 39px;">
                                $<label id="labTaxQST">0.00</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>Order Total</strong>
                            </td>
                            <td style="text-align: right; padding-right: 39px;">
                                <b>$<label id="labPayMoney2"></label></b>
                                <%--<a style=" font-size:10px;" onclick="UseTweebuck()">Use Tweebuck</a>--%>
                            </td>
                        </tr>
                        <tr id="trTweeBuck">
                           <%-- <td colspan="2" style="padding-left: 0px; text-align:left; padding-left:25px; ">
                                <input type="checkbox" onclick="UseTweebuck()"/>Use Tweebuck                                                     
                                <input type="text" id="txtUse" onkeyup="chgTweebuck()"  style="width: 60px; display:none;" />                                  
                                <label id="lab1" style="display:none;">$</label><label id="labTweebucks" style=" display:none;" ><%=_extractionTweebuck %></label><label id="lab2" style="display:none;"></label>
                                     -<label id="labTweebucksUse"></label>
                              
                            </td>--%>
                            <%-- <td>
                            <div id="divTweebuck" style="display:none;">
                                 <input type="text" id="txtUse" onchange="chgTweebuck()" style="width:80px;" />Tweebucks
                                   &nbsp; &nbsp; -<label id="labTweebucksUse" ></label>
                                 <br />
                               <label id="labTweebucks" ><%=_extractionTweebuck %></label>(Can Use)
                             
                               </div>
                            </td>               --%>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="clear">
            </div>
            <div class="item2 fr">
                *NOTICE: If your order contains TEST-SALE item(s) --- Test-Sale items have a test
                period of 60 days.
                <br />
                If item(s) does not reach the Test-Sale goal, your order for that item(s) will be
                cancelled and refunded 100%.
                <br />
                If your order contains BUY NOW item(s) --- Buy Now items do have an extended delivery
                time during our initial launching stage.
                <br />
                Your order WILL be fulfilled, but longer lead-time will apply.
                <br />
                <strong>CHECK BOX TO INDICATE YOUR ACCEPTANCE OF THESE TERMS:</strong>
                <label>
                    <input type="checkbox" id="Acknowledged" />Acknowledged
                </label>
            </div>
            <div class="item3">
                <a href="javascript:void(0);" class="returnCar" onclick="GoBack()">Back to Cart</a>
                <a href="javascript:void(0);">
                    <img src="https://www.paypalobjects.com/webstatic/en_US/i/buttons/cc-badges-ppmcvdam.png"
                        alt="Buy now with PayPal" class="gotoPay" />
                </a>
            </div>
        </div>
    </div>
    <!-- 支付方式 -->
    <div class="payment-methods">
        <a href="javascript:;" class="closeBtn"></a>
        <p class="t">
            Payment Method
        </p>
        <ul class="clearfix">
            <li>
                <label>
                    <input type="radio" name="payGroup" id="ckbPay1" checked="checked" />
                    <img src="../Images/pay2.png" alt="" />
                </label>
            </li>
            <li>
                <input type="radio" name="payGroup" id="ckbPay2" checked="checked" />
                <img src="../Images/pay1.png" alt="" />
                </label> </li>
        </ul>
        <a href="#" class="gotoPay">Pay Now </a>
    </div>
    <!-- 新建Delivery address 弹出框-->
    <div class="add-new-address-box">
        <a href="javascript:;" class="closeBtn"></a>
        <h2 class="t">
            EditDelivery address</h2>
        <form action="">
        </form>
    </div>
    <!-- 支付结果弹出kuang -->
    <div class="pay-result-tck">
        <a href="javascript:;" class="closeBtn"></a><span class="item pay-ok fl"><span class="icon">
            <strong>Payment Successful！</strong> </span>
            <br />
            <a href="#" class="chakan-order">View Order</a> </span><span class="item pay-no fr">
                <span class="icon"><strong>Payment Failed！</strong> </span>
                <br />
                <a href="#" class="reset-pay">Reselect payment method</a><br />
                <a href="#" class="pay-q">Payment problems</a> </span>
        <div class="clear">
        </div>
        <div class="ps">
            Share my purchase with all my friends！<a href="#" class="yellow-shareBtn">Share & Earn</a>
        </div>
    </div>
    <div class="greybox">
    </div>
    <div id="payform" style="display: none;">
    </div>
    <style type="text/css">
        .tdmoney
        {
            text-align: left;
        }
    </style>
    <script type="text/javascript">

        $("input").placeholder()

        // select 美化
        $(".selects").selectCss();

        //地址边框
        $(".address-list").find("li").mouseenter(function (event) {
            $(this).addClass('cur')
        }).mouseleave(function (event) {
            $(this).removeClass('cur')
        });

        //显示全部地址
        $(".show-all-address-btn").click(function (event) {
            //var show=
            var address = $("#ulAddress2");
            var dis = "";
            if (address != undefined) {
                dis = address.css("display");
                if (dis == "block") {
                    address.hide();
                } else {
                    address.show();
                }
            }

            //$(this).parent().siblings('ul').show();
            return false;
        });

        $(".show-all-address").find("li").mouseenter(function (event) {
            $(this).addClass('on')
        }).mouseleave(function (event) {
            $(this).removeClass('on')
        });

        //物流选择 
        $(".select-wuliu .showUl").click(function (event) {
            $(this).siblings('ul').show();
        });
        //    $(".select-wuliu").find("li").mouseenter(function (event) {
        //        $(this).addClass('on')
        //    }).mouseleave(function (event) {
        //        $(this).removeClass('on')
        //    }).click(function (event) {
        //        var THIS = $(this)
        //        $(this).removeClass('on')
        //        THIS.parent().siblings('h2').text(THIS.text())
        //    });
        $(".select-wuliu").mouseleave(function (event) {
            $(this).find("ul").hide();
        });

        $("#gopay").click(function (event) {
            var addressId = $("#hidAddressId").val();
            if (addressId == "" || addressId == null) {
                alert("Please fill in delivery address ！");
                return;
            }
            PayPalPay();
        });

        //点击结算
        $(".gotoPay").click(function (event) {
            var addressId = $("#hidAddressId").val();
            if (addressId == "" || addressId == null) {
                alert("Please fill and save your delivery address！");
                return;
            }
            if (document.getElementById("Acknowledged").checked == false) {
                alert("Please Acknowledge the reminder ！");
                return;
            }
            var pointMoney = $("#txtPointMoney").val();
            var tweebucks = $("#txtTweebuck").val();
            //产品金额
            var orderTotal = parseFloat($("#labPrdMoney").text()); // parseFloat($("#labPayMoney2").text());   
            var sumTweebucks = parseFloat($("#labTweebucks").text());
            var sumPointMoney = parseFloat($("#labPointMoney").text());
            //alert(pointMoney); alert(sumPointMoney); alert(orderTotal);
            if (pointMoney > orderTotal || pointMoney > sumPointMoney) {
                alert("Your input amount of shopping points is invalid, cannot be larger than the total amount or redemption value.");
                return;
            }
            if (tweebucks > orderTotal || tweebucks > sumTweebucks) {
                alert("Your input tweebucks amount is invalid, cannot be larger than the total amount or total tweebucks.");
                return;
            }
            /*
            var sumUse = eval(pointMoney + tweebucks);
            if (sumUse > orderTotal) {
                alert("Your input amount is invalid, cannot be larger than the total amount.");
                return;
            }
            var discount_amount = pointMoney + tweebucks;   */        
            PayPalPay();


            // $(".pay-result-tck").show();
            //PayPalPay();
            //$(".greybox").show();
            //$(".payment-methods").show();
            //return false;
        });

        //支付方式里面的 去支付
        $(".payment-methods .gotoPay").click(function (event) {
            $(".payment-methods").hide()
            //$(".pay-result-tck").show();

            if ($("#ckbPay1").attr("checked")) {
                AliyPay(); //支付宝支付
            }
            if ($("#ckbPay2").attr("checked")) {
                PayPalPay(); //paypal支付
            }
        });


        //增加地址
        $(".add-new-address > a").click(function (event) {
            $(".greybox,.add-new-address-box").show();
            $(".add-new-address-box").find('h2').text("Add delivery address")
            $("#btnSave").unbind("click")
            $("#btnSave").bind("click", function () { AddAddress() });
            ClearForm();
            return false;
        });
        //    $(".send").click(function (event) {
        //        $(".greybox,.add-new-address-box").hide();
        //    });

        //编辑收货地址
        $(".change-address-btn").live('click', function (event) {
            $(".add-new-address-box").find('h2').text("Edit delivery address")
            $(".greybox,.add-new-address-box").show();
            return false;
        });

        function GoBack() {
            window.location.href = "../Product/shopCart.aspx";
        }

    </script>
    <script>
        function UseTweebuck() {
            /*
            var orderTotal = $("#labPayMoney2").text();
            var tweebuck = $("#labTweebucks").text();
            if (tweebuck == 0) {
            //alert("暂无可用Tweebuck");
            $("#labTweebucksUse").text("暂无可用Tweebuck");
            }
            if (orderTotal <= tweebuck) {
            //alert("可用Tweebuck：$" + orderTotal);
            $("#labTweebucksUse").text(orderTotal);
            }
            if (tweebuck < orderTotal) {
            // alert("可用Tweebuck：$" + tweebuck);
            $("#labTweebucksUse").text(tweebuck);
            }*/
            // $("#divTweebuck").show();
            $("#lab1").show();
            $("#lab2").show();
            $("#labTweebucks").show();
            $("#txtUse").show();
        }
        function chgTweebuck() {
            var used = $("#txtUse").val();
            var sum = Number($("#labTweebucks").text());
            var orderTotal = Number($("#labPayMoney2").text());
            if (used > sum || used > orderTotal) {
                $("#txtUse").val("")
                return;
            }
            if (used <= sum && used > orderTotal) {
                $("#txtUse").val("")
                return;
            }
//            if (used > orderTotal) {
//                alert("最多可以使用：" + orderTotal);
//                $("#txtUse").val("")
//                return;
//            }
//            if (used < orderTotal && used > sum) {
//                alert("最多可以使用：" + sum);
//                $("#txtUse").val("")
//                return;
//            }
//            if (used < sum && used > orderTotal) {
//                alert("最多可以使用：" + orderTotal);
//                $("#txtUse").val("")
//                return;
//            }           
           // $("#labTweebucksUse").text($("#txtUse").val());

        }
    </script>
</asp:Content>
