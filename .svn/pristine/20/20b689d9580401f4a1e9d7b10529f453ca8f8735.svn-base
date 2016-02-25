<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="HomeCollageFavorite.aspx.cs" Inherits="TweebaaWebApp2.Home.HomeCollageFavorite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
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
    <link rel="stylesheet" href="../css/theme-skins/dark.css">
    <!-- Style Switcher -->
    <link rel="stylesheet" href="../css/plugins/style-switcher.css">
    <!-- CSS Theme -->
    <link rel="stylesheet" href="../css/theme-colors/default.css" id="style_color">
    <!-- CSS Customization -->
    <link rel="stylesheet" href="../css/custom.css">

    <!-- share -->
    <link href="../css/shareBox.css" rel="stylesheet" type="text/css" />
    <link href="../css/shareall.css" rel="stylesheet" type="text/css" />

     <script src="../MethodJs/HomeCollageCollection.js" type="text/javascript"></script>
  <!--  <script src="../MethodJs/share.js" type="text/javascript"></script> -->
         <script type="text/javascript" src="/js/CollageDesign.js"></script>
     <%--分页--%>    
    <script src="../js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="../js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">


    <input type="hidden" id="hiduserid" value="<%=_userid %>" />

  <div class="col-md-9">
        <h2>
            <span aria-hidden="true" class="icon-heart"></span>  My  Favorite Collage</h2>
        <!--Profile Body-->
        <div class="profile-body">
            <form class="sky-form" role="form">
            <!--
            <select class="form-control col col-4">
                <option>Product Status</option>
                <option onclick="SetState(-1)">All</option>
                <option onclick="SetState(4)">Tweebaa Evaluating</option>
                <optiononclick="SetState(1)">Public Evaluating</option>
                <option onclick="SetState(2)">Test-Sale</option>
                <option onclick="SetState(3)">Buy Now</option>
                <option onclick="SetState(7)">Test-Sale Failed</option>
            </select>
            -->
            <section class="col col-3">
                                            <label class="input">
                                                <i class="icon-append fa fa-calendar"></i>
                                                <input type="text" name="start" id="txtBeginTime" placeholder="Start date" class="datepicker">
                                            </label>
                                        </section>
            <section class="col col-3">
                                            <label class="input">
                                                <i class="icon-append fa fa-calendar"></i>
                                                <input type="text" name="finish" id="txtEndTime" placeholder="End date" class="datepicker">
                                            </label>
                                        </section>
            <button class="btn-u rounded btn-u-blue" type="button" onclick="DoSearch()">
                Search</button>
            </form>
            <div class="panel margin-bottom-40">
                <table class="table">
                    <thead>
                        <tr>
                            <th colspan="2">
                                Collage Design
                            </th>
                            <th >
                                
                            </th><th></th>
                        </tr>
                    </thead>
                    <tbody id="tbData">
                      <%--  <tr>
                            <td class="hidden-sm" style="width: 20%">
                                <div>
                                    <a href="product-details.html">
                                        <img src="../images/thumb/02.jpg" alt="" width="100">
                                    </a>
                                </div>
                            </td>
                            <td style="width: 40%">
                                <h5>
                                    <a href="product-details.html">TSHOP Tshirt DO9 </a>
                                </h5>
                                <h5>
                                    <small>12 x 1.5 L </small>
                                </h5>
                                <h6>
                                    $22
                                </h6>
                            </td>
                            <td style="width: 20%;" class="vm">
                                <a>
                                    <button class="btn rounded btn-danger" type="button">
                                        Add to cart
                                    </button>
                                </a>
                            </td>
                            <td style="width: 15%" class="vm">
                                <button class="btn rounded btn-default" type="button">
                                    <i class="fa  fa-trash"></i>
                                </button>
                            </td>
                        </tr>--%>
                     
                    </tbody>
                </table>
            </div>
<%--            <div class="text-right">
                <ul class="pagination">
                    <li><a href="#">«</a></li>
                    <li><a href="#">1</a></li>
                    <li class="active"><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">»</a></li>
                </ul>
            </div>--%>
            <div id="divNoData" style="display:none" >No product found! </div>
             <div id="kkpager" style="  float:right; padding-right:150px;"></div><br />
        </div>
    </div>





    <!-- Datepicker Form -->
<script src="/plugins/sky-forms/version-2.0.1/js/jquery-ui.min.js"></script>
<script src="/plugins/counter/waypoints.min.js"></script>
<script src="/plugins/counter/jquery.counterup.min.js"></script>

<script type="text/javascript" src="/js/plugins/datepicker.js"></script>

<script>
    jQuery(document).ready(function () {

        //Datepicker.initDatepicker();
        $(".datepicker").datepicker({
            nextText: ">",
            prevText: "<"
        });


    });

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

    //隐藏弹出 框
    function hidePopup() {
        $(".popbox").hide();
    }

</script>


    <div class="greybox">
        <div id="share-tck2" class="tck">
             <a href="#" class="closeBtn" title="Close"></a>
             <h2 class="t">
                <span>Share & Earn</span>
            </h2>
             <div class="box">
                <div class="sharebox clearfix my-dietu">
                    <span class="fl t ">Share to </span>
                    <div class="bdsharebuttonbox fl">
                                                <a href="javascript:void(0);" target="_blank" id="shareToFacebook" title="Facebook"><img src="../Images/flat-circles_03.png" /></a>&nbsp;&nbsp;
                        <a href="javascript:void(0);" target="_blank" id="shareToTwitter" title="Twitter"><img src="../Images/flat-circles_05.png" /></a>&nbsp;&nbsp;
                        <a href="javascript:void(0);" target="_blank" id="shareToGoogle" title="Google"><img src="../Images/flat-circles_13.png" /></a>&nbsp;&nbsp;
                        <!--a href="javascript:void(0)" target="_blank" id="share4" title="Wechat"><img src="../Images/share-rss.png" /></a>&nbsp;&nbsp;-->
                        <a href="javascript:void(0);" target="_blank" id="shareToPinterest" title="Pinterest"><img src="../Images/share-pin.png" /></a>&nbsp;&nbsp;
                        
                        <a href="javascript:void(0)" target="_blank" id="shareToEmail" title="Email"><img src="../Images/share-mail.png" /></a>

                    </div>                  
                    <!--a href="/Home/Index.aspx" class="share-media-set">Link My Account</a-->
                </div>
                <div class="ps clearfix">
                    <span class="fr"><a href="#"></a></span><span class="fl">You will earn  <!--span id="sharePercent"></span-->commission when your friend makes a purchase from your shared link. </span>
                </div>
            </div>
            
        </div>
</div>

</asp:Content>
