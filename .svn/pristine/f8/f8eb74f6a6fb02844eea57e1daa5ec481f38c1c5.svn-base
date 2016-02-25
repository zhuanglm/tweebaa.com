<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="issue2.aspx.cs" Inherits="TweebaaWebApp.Product.issue2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <script src="../Js/util.js" type="text/javascript"></script>
    <script src="../Js/xd.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../Css/submit.css" />
    <link rel="stylesheet" href="../Css/selectCss.Css" />
    <script src="../Js/jquery.min.js" type="text/javascript"></script>
    <script src="../Js/jquery.placeholder2.js" type="text/javascript"></script>
    <script src="../Js/biaodan2.js" type="text/javascript"></script>
    <script src="../Js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Js/newfloat.js"></script>
    <link rel="stylesheet" href="../Kindeditor/kindeditor-4.1.10/themes/default/default.css" />
    <link href="../Kindeditor/kindeditor-4.1.10/plugins/code/prettify.css" rel="stylesheet"
        type="text/css" />
    <script charset="utf-8" src="../Kindeditor/kindeditor-4.1.10/kindeditor.js"></script>
    <script charset="utf-8" src="../Kindeditor/kindeditor-4.1.10/lang/zh_CN.js"></script>
    <script charset="utf-8" src="../Kindeditor/kindeditor-4.1.10/plugins/code/prettify.js"></script>
    <script>
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('#' + document.getElementById('<%=txtDec.ClientID %>').id, {
                langType: 'en',
                cssPath: '../Kindeditor/kindeditor-4.1.10/plugins/code/prettify.css',
                uploadJson: '../Kindeditor/kindeditor-4.1.10/asp.net/upload_json.ashx',
                fileManagerJson: '../Kindeditor/kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
    </script>
    <script src="../MethodJs/prd.js" type="text/javascript"></script>
    <script>
        $("input:radio[name='rdSupplier']").click(function () {
            if ($(this).val() == 1) {
                $('#tbSupplier').css('visibility':'collapse');
            }
            {
                $('#tbSupplier').css('visibility':'visible');
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <div class="fabubox">
        <form action="">
        <div class="w950">
            <h1>
                <span class="fr"><a href="../College/College.aspx#nav-fa3" class="ys">Submission Demo</a>
                </span><strong>Product Submission</strong>
            </h1>
            <!-- 产品基本信息 -->
            <div class="basic-infor">
                <span class="title">Product Information </span>
                <table>
                    <tr>
                        <td class="t">
                            <b>＊</b>Product Name
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                        Enter the product name exactly as you wish it to be displayed on Tweebaa.</br> TIP:
                                        A descriptive product name can attract more attention.<br />
                                        <br />
                                        <u>Bad &nbsp; example</u>: Litter Box<br />
                                        <u>Good example</u>: Kitty Litty - flip-style, fast-cleaning cat litter box<br />
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td>
                            <div class="pr">
                                <i class="icon-btn bianji"></i>
                                <input type="text" maxlength="50" class="text jstxt" runat="server" style="width: 605px;"
                                    id="proName" placeholder="Modern Toaster" onkeyup="limitLenth(this,50,'lnametip')" />
                            </div>
                            <div class="tr font1 txtnumertips">
                                Max 50 characters, only<label id="lnametip" style="color: Red">
                                    50
                                </label>
                                characters left.
                            </div>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td class="t">
                            <b>＊</b>Categories
                        </td>
                        <td width="30">
                        </td>
                        <td>
                            <div class="clearfix product-categories">
                                <div class="selectBox pr fl">
                                    <select name="" class="tag_select2" id="prdType1">
                                    </select>
                                </div>
                                <div class="selectBox pr fl">
                                    <select name="" class="tag_select2" id="prdType2">
                                    </select>
                                </div>
                                <div class="selectBox pr fl">
                                    <select name="" class="tag_select2" id="prdType3">
                                    </select>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            <b>＊</b>Brief Description
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                        Consider this section your “headline”. It should grab readers’ attention and make
                                        them want to learn more about the product.
                                        <br />
                                    </p>
                                    <p>
                                        <br />
                                        Example:<br />
                                        1. Patented flip design makes it easy to separate waste and litter.
                                        <br />
                                        2. Saves time with quick 3 step litter cleaning.<br />
                                        3. Uses less litter than ordinary litter boxes.<br />
                                        4. Comes with small tool for easy cleaning.<br />
                                        5. Easy to assemble and disassemble.<br />
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td>
                            <div class="pr" id="tishi">
                                <p class="tishi">
                                    Sleek, modern electronic toaster with updated features.<br />
                                    Easy to operate and to clean.<br />
                                    Colour: stainless steel<br />
                                </p>
                                <textarea name="" id="tese" rows="3" maxlength="450" onkeydown="hideTishi()" onkeyup="hideTishi();limitLenth(this,450,'ltesetip')"
                                    onfocus="hideTishi()" runat="server"></textarea>
                            </div>
                            <div class="tr font1 txtnumertips">
                                <p>
                                    Max 450 characters, only
                                    <label id="ltesetip" style="color: Red">
                                        450</label>
                                characters left.
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            <b>＊</b>Detail Description
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                        <%-- Product description support HTML format, allows you to create and edit font, colour
                                        and layout.
                                        <br />
                                        This description is listed under the product page, please clearly describe your
                                        product style, function and images.

                                        The Product Description is displayed to the public on Tweebaa.  Clearly describe your 
                                        product to help secure positive evaluations and generate purchases.  <br />
                                        HTML is supported so that you can edit the font, color and layout to make an attractive description.


                                        <br />
                                         A complete product description is necessary to attract buyers.
                                        <br />--%>
                                        This is your opportunity to SELL YOUR PRODUCT! The more descriptive you are, the
                                        better chance that the product will catch the attention of Tweebaa members and shoppers
                                        (leading to product SUCCESS). Tell us about the features and benefits… how it works…
                                        and why people should purchase your clever product.
                                        <br />
                                        <br />
                                        For best results:<br />
                                        • Provide an abundance of information to share how great
                                        <br />
                                        &nbsp;&nbsp;&nbsp;the product is<br />
                                        • Use correct grammar<br />
                                        • Take care with punctuation<br />
                                        • Use spell check<br />
                                        <br />
                                        <b>5000 characters limit</b>.
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td>
                            <%--<img src="../../Images/wb.png"  />--%>
                            <textarea id="txtDec" name="txtDec" cols="100" rows="8" runat="server" style="height: 400px;
                                width: 680px; visibility: hidden;"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Features and Benefits
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <p>
                                        Would you like to call attention to particular features/attributes, or provide a
                                        list of product benefits? Please list them here. Include as many features as possible
                                        to help generate more positive evaluations, and bigger sales.<br />
                                        <br />
                                        Example:<br />
                                        • Patented litter box makes clean-up easy!<br />
                                        • Simple to use – just flip it to separate waste from litter<br />
                                        • Economical – saves on litter expense<br />
                                        • Easy assembly<br />
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td>
                            <div class="pr">
                                <i class="icon-btn bianji"></i>
                                <input type="text" maxlength="150" class="text jstxt" runat="server" style="width: 605px;"
                                    id="proDes" onkeyup="limitLenth(this,150,'ldestip')" placeholder="Gives an even and complete toast" />
                            </div>
                            <div class="tr font1 txtnumertips">
                                Max 150 characters, only
                                <label id="ldestip" style="color: Red">
                                    150</label>
                                characters left.
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            <b>＊</b>Suggested Selling Price
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                        Please list a suggested selling price (the price consumers/shoppers will pay for
                                        the product). This might take a little legwork. You can start by researching similar
                                        items, and checking their selling price at other websites or retailers. Another
                                        suggestion is to survey your friends and family to ask what they would pay for the
                                        item.
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td width="570">
                            <div class="pr fl" id="price-rmb">
                                <input type="text" id="txtPrice" class="text price-rmb" style="width: 100px; padding-right: 50px;"
                                    onkeyup="value=value.replace(/[^\d.]/g,'')" runat="server" /><span class="wz">USD</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            <b>＊</b>Supply Price
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                        List Supplier’s price to Tweebaa. If you’re not sure how to find the Supply Price,
                                        we suggest that you research multiple sources (try Alibaba.com to locate qualified
                                        manufacturers, or speak with a product sourcing agent) and choose the one with best
                                        pricing. We recommend that the supply price be about 1/3 the “Suggested Retail Price”
                                        or lower, so that we can pass along the best value to Tweebaa members.
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td width="570">
                            <div class="pr fl" id="price-rmb">
                                <input type="text" id="txtSupplyPrice" class="text price-rmb" style="width: 100px;
                                    padding-right: 50px; height: 13px;" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                    runat="server" /><span class="wz">USD</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            <b>＊</b>MOQ
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                        Please prove the lowest minimum order quantity (MOQ).
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td width="570">
                            <div class="pr fl" id="Div1">
                                <input type="text" id="txtMoq" class="text price-rmb" style="width: 100px; padding-right: 50px;
                                    height: 13px;" onkeyup="value=value.replace(/[^\d.]/g,'')" runat="server" /><span
                                        class="wz">Pieces</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp
                        </td>
                        <td>
                            <span style="font-weight: bold">Are you the Supplier of the product (you can manufacture)?
                                <input type="radio" id="rdSupplierYes" name="rdSupplier" value="1" runat="server">Yes
                                <input type="radio" id="rdSupplierNo" name="rdSupplier" value="0" runat="server">No
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Supplier Name
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td width="570">
                            <input type="text" id="txtSupplierName" value="" runat="server" style="width: 505px;"
                                maxlength="150" />
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Supplier Website
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td width="570">
                            <input type="text" id="txtSupplierWebsite" value="" runat="server" style="width: 505px;"
                                maxlength="150" />
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Supplier Phone
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                        Supplier Phone Number (include the country code)
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td width="570">
                            <input type="text" id="txtSupplierPhone" runat="server" style="width: 305px;" />
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Supplier Email
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td width="570">
                            <input type="text" id="txtSupplierEmail" runat="server" maxlength="150" style="width: 505px;" />
                        </td>
                    </tr>
                      <tr id="supplierQ7" >
                        <td class="t">
                            Supplier address
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td width="570">
                            <input type="text" id="txtSupplierAddress" runat="server" style="width: 305px;" />
                        </td>
                    </tr>                    
                  
                </table>
            </div>
            <!-- 图片信息 -->
            <div class="basic-infor">
                <table>
                    <tr>
                        <td class="t">
                            <b>＊</b>Images
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                        Images to show product features and details. The nicer your image, the more attractive
                                        your product will be for others to purchase.<br />
                                        1.Format: jpg, jpeg, gif, png<br />
                                        2.Size limit 1M<br />
                                        3.Length * Width less than 600px * 600px
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td width="570">
                            <div class="fl font1" style="line-height: 30px;">
                                Support Jpeg , Gif , PNG format，max size 2MB. Prefer white background
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Gallery
                        </td>
                        <td width="30">
                        </td>
                        <td width="605">
                            <dl class="clearfix fengmian">
                                <dd class="first">
                                    <a href="javascript:void(0);" style="cursor: pointer;" class="imglink" onclick="uploadWin('img1')">
                                        <img src=""  id="img1" runat="server" />
                                    </a>
                                    <div class="btn-group">
                                        <a href="#" class="moveLeft fl"></a><a href="#" class="moveRight fr"></a><a href="#"
                                            class="delthis"></a>
                                    </div>
                                </dd>
                                <dd>
                                    <a href="javascript:void(0);" style="cursor: pointer;" class="imglink" onclick="uploadWin('img2')">
                                        <img src=""  id="img2" />
                                    </a>
                                    <div class="btn-group">
                                        <a href="#" class="moveLeft fl"></a><a href="#" class="moveRight fr"></a><a href="#"
                                            class="delthis"></a>
                                    </div>
                                </dd>
                                <dd>
                                    <a href="javascript:void(0);" style="cursor: pointer;" class="imglink" onclick="uploadWin('img3')">
                                        <img src=""  id="img3" />
                                    </a>
                                    <div class="btn-group">
                                        <a href="#" class="moveLeft fl"></a><a href="#" class="moveRight fr"></a><a href="#"
                                            class="delthis"></a>
                                    </div>
                                </dd>
                                <dd>
                                    <a href="javascript:void(0);" style="cursor: pointer;" class="imglink" onclick="uploadWin('img4')">
                                        <img src=""  id="img4" />
                                    </a>
                                    <div class="btn-group">
                                        <a href="#" class="moveLeft fl"></a><a href="#" class="moveRight fr"></a><a href="#"
                                            class="delthis"></a>
                                    </div>
                                </dd>
                                <dd>
                                    <a href="javascript:void(0);" style="cursor: default;" class="imglink" onclick="uploadWin('img5')">
                                        <img src=""  id="img5" />
                                    </a>
                                    <div class="btn-group">
                                        <a href="#" class="moveLeft fl"></a><a href="#" class="moveRight fr"></a><a href="#"
                                            class="delthis"></a>
                                    </div>
                                </dd>
                            </dl>
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                            Video
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                        Although videos are not required, they can help you better explain the features,
                                        functions, solutions of your product help engage buyers to make a purchasing decision.
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td>
                            <div class="pr">
                                <i class="icon-btn bianji"></i>
                                <input type="text" class="text jstxt" placeholder="Please enter product video URL such as a youtube link. Alternatively, you may upload a video file"
                                    id="proWeb" runat="server" style="width: 605px;" />
                            </div>
                            <div class="h10">
                            </div>
                            <iframe src="videoControlEn.aspx" id="iframeVideo" frameborder="0" style="display: none;"
                                onload="getVideo(this.contentWindow.document.body.innerHTML)"></iframe>
                            <div class="line fl">
                                <span class="span" style="display: none;">
                                    <input name="" type="text" id="Text19" onmouseout="document.getElementById('upload').style.display='none';"
                                        class="inputstyle" />
                                </span>
                                <label for="unload" class="file1" onclick="uplod2()">
                                    Upload</label>
                            </div>
                            <div class="fl font1" style="line-height: 30px;">
                                Supports wmv, mov, mp4 and flv formats. Maximum size is 5mb
                            </div>
                        </td>
                    </tr>
                </table>
                <%--<iframe src="https://tweebaa.com/uploadpicEn.aspx" id="frm1" frameborder="0"
                    width="100%" height="250" scrolling="no"></iframe>--%>
                <%--http://localhost:36584/UploadPicEn.aspx#--%>
                <%--https://tweebaa.com/uploadpicEn.aspx--%>
            </div>
            <!-- 价格区间 -->
            <div class="basic-infor price-infor" style="display: none;">
                <span class="title">Pricing Information </span>
                <table>
                    <tr>
                        <td class="t">
                            Unit Cost
                        </td>
                        <td width="30">
                            <em class="showbox">
                                <div class="thistips">
                                    <i></i>
                                    <p>
                                        Please provide different sales pricing based on the various quantity. Tweebaa is
                                        a worldwide selling platform, your price need to be competitive. Please input truth
                                        pricing, when this submission passed public evaluation stage, Tweebaa will verify
                                        the data again. If the pricing is found untruthful, product cannot be advance to
                                        next stage.
                                    </p>
                                </div>
                            </em>
                        </td>
                        <td id="price-section">
                            <div class="h0 pr">
                                <div class="add-sale-btn">
                                    <a href="javascript:;" class="jia">Add</a> <a href="javascript:;" class="jian">Delete</a>
                                </div>
                            </div>
                            <!-- 价格区间 预留10个-->
                            <div class="clearfix price-section" id="divPrice1">
                                <span class="fl wz">From</span>
                                <div class="selectBox pr fl price1">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="txtCountB1" style="width: 70px;" />
                                </div>
                                <span class="fl wz">to</span>
                                <div class="selectBox pr fl price2">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="txtCountE1" style="width: 70px;" />
                                </div>
                                <span class="fl wz">Cost</span>
                                <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')" />
                                <span class="fl wz">USD</span>
                            </div>
                            <!-- 价格区间 -->
                            <!-- 价格区间 预留10个-->
                            <div class="clearfix price-section" id="divPrice2">
                                <span class="fl wz">From</span>
                                <div class="selectBox pr fl price1">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text1" style="width: 70px;" />
                                </div>
                                <span class="fl wz">to</span>
                                <div class="selectBox pr fl price2">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text2" style="width: 70px;" />
                                </div>
                                <span class="fl wz">Cost</span>
                                <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')" />
                                <span class="fl wz">USD</span>
                            </div>
                            <!-- 价格区间 -->
                            <!-- 价格区间 预留10个-->
                            <div class="clearfix price-section" id="divPrice3">
                                <span class="fl wz">From</span>
                                <div class="selectBox pr fl price1">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text3" style="width: 70px;" />
                                </div>
                                <span class="fl wz">to</span>
                                <div class="selectBox pr fl price2">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text4" style="width: 70px;" />
                                </div>
                                <span class="fl wz">Cost</span>
                                <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')" />
                                <span class="fl wz">USD</span>
                            </div>
                            <!-- 价格区间 -->
                            <!-- 价格区间 预留10个-->
                            <div class="clearfix price-section" id="divPrice4">
                                <span class="fl wz">From</span>
                                <div class="selectBox pr fl price1">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text5" style="width: 70px;" />
                                </div>
                                <span class="fl wz">to</span>
                                <div class="selectBox pr fl price2">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text6" style="width: 70px;" />
                                </div>
                                <span class="fl wz">Cost</span>
                                <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')" />
                                <span class="fl wz">USD</span>
                            </div>
                            <!-- 价格区间 -->
                            <!-- 价格区间 预留10个-->
                            <div class="clearfix price-section" id="divPrice5">
                                <span class="fl wz">From</span>
                                <div class="selectBox pr fl price1">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text7" style="width: 70px;" />
                                </div>
                                <span class="fl wz">to</span>
                                <div class="selectBox pr fl price2">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text8" style="width: 70px;" />
                                </div>
                                <span class="fl wz">Cost</span>
                                <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')" />
                                <span class="fl wz">USD</span>
                            </div>
                            <!-- 价格区间 -->
                            <!-- 价格区间 预留10个-->
                            <div class="clearfix price-section" id="divPrice6">
                                <span class="fl wz">From</span>
                                <div class="selectBox pr fl price1">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text9" style="width: 70px;" />
                                </div>
                                <span class="fl wz">to</span>
                                <div class="selectBox pr fl price2">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text10" style="width: 70px;" />
                                </div>
                                <span class="fl wz">Cost</span>
                                <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')" />
                                <span class="fl wz">USD</span>
                            </div>
                            <!-- 价格区间 -->
                            <!-- 价格区间 预留10个-->
                            <div class="clearfix price-section" id="divPrice7">
                                <span class="fl wz">From</span>
                                <div class="selectBox pr fl price1">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text11" style="width: 70px;" />
                                </div>
                                <span class="fl wz">to</span>
                                <div class="selectBox pr fl price2">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text12" style="width: 70px;" />
                                </div>
                                <span class="fl wz">Cost</span>
                                <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')" />
                                <span class="fl wz">USD</span>
                            </div>
                            <!-- 价格区间 -->
                            <!-- 价格区间 预留10个-->
                            <div class="clearfix price-section" id="divPrice8">
                                <span class="fl wz">From</span>
                                <div class="selectBox pr fl price1">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text13" style="width: 70px;" />
                                </div>
                                <span class="fl wz">to</span>
                                <div class="selectBox pr fl price2">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text14" style="width: 70px;" />
                                </div>
                                <span class="fl wz">Cost</span>
                                <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')" />
                                <span class="fl wz">USD</span>
                            </div>
                            <!-- 价格区间 -->
                            <!-- 价格区间 预留10个-->
                            <div class="clearfix price-section" id="divPrice9">
                                <span class="fl wz">From</span>
                                <div class="selectBox pr fl price1">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text15" style="width: 70px;" />
                                </div>
                                <span class="fl wz">to</span>
                                <div class="selectBox pr fl price2">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text16" style="width: 70px;" />
                                </div>
                                <span class="fl wz">Cost</span>
                                <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')" />
                                <span class="fl wz">USD</span>
                            </div>
                            <!-- 价格区间 -->
                            <!-- 价格区间 预留10个-->
                            <div class="clearfix price-section" id="divPrice10">
                                <span class="fl wz">From</span>
                                <div class="selectBox pr fl price1">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text17" style="width: 70px;" />
                                </div>
                                <span class="fl wz">to</span>
                                <div class="selectBox pr fl price2">
                                    <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')"
                                        id="Text18" style="width: 70px;" />
                                </div>
                                <span class="fl wz">Cost</span>
                                <input type="text" class="sale-price fl wz" onkeyup="value=value.replace(/[^\d.]/g,'')" />
                                <span class="fl wz">USD</span>
                            </div>
                            <!-- 价格区间 -->
                        </td>
                    </tr>
                    <tr>
                        <td class="t">
                        </td>
                        <td width="30">
                        </td>
                        <td width="570">
                        </td>
                    </tr>
                </table>
            </div>
            <div class="result tc">
                <a href="#" class="btn clear-btn fr">Clear</a> <a href="javascript:void(0)" class="btn save-btn fr"
                    onclick='addPrd2("save","0")'>Save</a>
                <%--<a href="#" class="btn return-btn fl">Back</a>--%>
                <br />
                <a href="javascript:void(0)" class="yulanbtn" runat="server" onclick="Save_Click">Preview</a>
            </div>
        </div>
        <input type="hidden" id="hidpic1" />
        <input type="hidden" id="hidpic2" />
        <input type="hidden" id="hidpic3" />
        <input type="hidden" id="hidpic4" />
        <input type="hidden" id="hidpic5" />
        <input type="hidden" id="hidvideo" />
        </form>
    </div>
    <!-- 浮动在线咨询 -->
    <%--  <div id="floatALink">
        <a href="#" class="zxzz">在线<br>
            咨询</a> <a href="#" id="gotoTop">返回<br>
                顶部</a>
    </div>--%>
    <!-- 浮动在线咨询 -->
    <!-- 发布成功 -->
    <div class="greybox">
        <div class="clearAllInfor">
            <a href="javascript:;" class="closeBtn"></a>
            <p>
                All fields will be cleared, you will need to re-enter all the data. Confirm to proceed?
            </p>
            <div class="tc">
                <a href="#" class="cancel-btn">Cancel</a> <a href="#" class="enter-btn">Confirm</a>
            </div>
        </div>
    </div>
    <style type="text/css">
        /* .tag_select
        {
            display: block;
            float: left;
            color: black;
            width: 158px;
            height: 34px;
            line-height: 34px;
           background: url(../../Images/dsj.png) white 100% center no-repeat;
            padding: 0 10px;
            color: #7D7D7D;
            font-size: 12px;
            cursor: pointer;
            border: 1px solid #E3E4E8;
            border-radius: 5px;
            margin-right: 8px;
        }*/
        
        .tag_select2
        {
            display: block;
            float: left;
            color: black;
            width: 158px;
            height: 34px;
            line-height: 34px;
            color: #7D7D7D;
            font-size: 12px;
            margin-right: 8px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            //表单提示
            $('.jstxt').placeholder();

            // select 美化
            $(".selects").selectCss();
            // 第一个价格显示
            $(".price-section").eq(0).show()
            //在线咨询 浮动
            $("#zxzz").smartFloat()


        });
    </script>
    <script type="text/javascript">
        $(function () {
            // 封面事件
            $(".fengmian .btn-group").find("a").click(function (event) {


                //获取新的数组
                var fmImgArr = []
                var imglen = $(".fengmian").find("img").length;
                for (var i = 0; i < imglen; i++) {
                    var imgUrl = $(".fengmian").find("img").eq(i).attr("src")
                    fmImgArr.push(imgUrl)
                };

                var nowindex = 0
                var nextindex = 1;

                if ($(this).is(".moveLeft")) {
                    var thisindex = $(".fengmian .moveLeft").index(this);
                    if (thisindex > 0) {
                        nowindex = thisindex
                        nextindex = thisindex - 1;
                        //刷新数组
                        changeArrIndex(fmImgArr, nowindex, nextindex);

                        //图片位置更新
                        for (var ii = 0; ii < fmImgArr.length; ii++) {
                            $(".fengmian").find("img").eq(ii).attr("src", fmImgArr[ii])
                        };
                    };

                };


                if ($(this).is(".moveRight")) {
                    var thisindex = $(".fengmian .moveRight").index(this);
                    if (thisindex < imglen) {
                        nowindex = thisindex
                        nextindex = thisindex + 1;
                        //刷新数组
                        changeArrIndex(fmImgArr, nowindex, nextindex);

                        //图片位置更新
                        for (var ii = 0; ii < fmImgArr.length; ii++) {
                            $(".fengmian").find("img").eq(ii).attr("src", fmImgArr[ii])
                        };
                    };
                }


                //删除图片
                if ($(this).is(".delthis")) {

                    var thisindex = $(".fengmian .delthis").index(this);
                    if (thisindex != 0) {
                        $(this).parents('dd').find("img").remove()
                        $(".fengmian").append($(this).parents('dd'))
                    }
                    else {
                        $(this).parents('dd').find("img").remove()
                        $(".fengmian").append($(this).parents('dd'))

                        $(".fengmian dd:first").addClass('first').siblings('dd').removeClass('first')
                    }

                }
                return false;

            });


            function changeArrIndex(arrr, am, bm) {
                var mm = null;
                mm = arrr[am]
                arrr[am] = arrr[bm]
                arrr[bm] = mm
            }

        })
    </script>
    <script type="text/javascript">
        $(function () {

            //问好提示
            $(".showbox").mouseenter(function (event) {
                $(this).find(".thistips").show();
            }).mouseleave(function (event) {
                $(this).find(".thistips").hide();
            });


            //增加和减少 价格区间
            var jiaObj = $(".add-sale-btn").find('.jia')
            var jianObj = $(".add-sale-btn").find('.jian')
            var sectionNum = 0;
            jiaObj.click(function () {
                sectionNum++
                if (sectionNum >= 9) {
                    sectionNum = 9
                    alert("最多10个区间")
                };
                $(".price-section").eq(sectionNum).show();
                console.log(sectionNum)
            });
            jianObj.click(function () {
                sectionNum--;
                if (sectionNum <= 0) {
                    sectionNum = 0
                };
                $(".price-section").eq(sectionNum + 1).hide();

                console.log(sectionNum)
            })
            for (var iu = 0; iu < $(".price-section").length; iu++) {
                $(".price-section").eq(iu).css({
                    zIndex: $(".price-section").length - iu + 5
                });
            };
            //产品特色
            $("#tishi").click(function () {
                //$(this).find('.tishi').hide();
                $("#tese").focus();
            })
            $("#tese").focus(function (event) {
                $("#tese").keypress(function (event) {
                    $(this).siblings('.tishi').hide();
                });

            });


            $("#tese").blur(function (event) {
                if ($(this).val() == "") {
                    $(this).siblings('.tishi').show();
                };
            });


            //清除弹出
            $(".clear-btn").click(function (event) {
                $(".clearAllInfor").parents(".greybox").show();
                return false;
            });

            $(".closeBtn,.cancel-btn,.enter-btn").click(function (event) {
                $(".greybox").hide();

                if ($(this).is(".enter-btn")) {
                    window.location.reload();
                };
            });
        })


        //图片上传
        function uploadWin(imgid) {
            var url = "picUpload.aspx?imgid=" + imgid;
            window.open(url, 'newwindow', 'width=' + (window.screen.availWidth - 10) + ',height=' + (window.screen.availHeight - 30) + ',top=0,left=0,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no')
        }

        function setImg(imgsrc, imgid) {
            var k = "#" + imgid;
            if (imgsrc != null || imgsrc.length != 0) {
                $(k).attr("src", imgsrc);
            }
        }      
    </script>
</asp:Content>
