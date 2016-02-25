<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Home.Master" AutoEventWireup="true"
    CodeBehind="HomeReview.aspx.cs" Inherits="TweebaaWebApp2.Home.HomeReview" %>

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

     <!-- CSS share box -->
     <link href="../css/shareBox.css" rel="stylesheet" type="text/css" />
     <link href="../css/shareall.css" rel="stylesheet" type="text/css" />

    <!-- CSS Customization -->
    <link rel="stylesheet" href="../css/custom.css">
    <script src="../MethodJs/share.js" type="text/javascript"></script>

    <script src="../MethodJs/homeReview.js" type="text/javascript"></script>
     <%--分页--%>    
    <script src="../js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="../js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <div class="col-md-9">
        <h2>
            <span aria-hidden="true" class="icon-pencil"></span>My Evaluations</h2>
        <!--Profile Body-->
        <div class="profile-body">
            <div class="alert alert-warning fade in">
                <button data-dismiss="alert" class="close" type="button">
                    ×</button>
                Evaluators complete simple, 5-question surveys to help identify new products for
                the Tweebaa Shop. Evaluators assist in the growth and popularity of products, with
                potential to earn commissions! <a class="alert-link" target="_blank" href="../College/evaluate-zone.aspx#collapseOne">
                    Learn more </a>.
            </div>
            <!--Service Block v3-->
            <div class="row content-boxes-v2 margin-bottom-20">
                <div class="col-md-4">
                    <div class="bg-light">
                        <!-- You can delete "bg-light" class. It is just to make background color -->
                        <p class="tc">
                            Successful Rate</p>
                        <div class="counters">
                            <span id="spnGrandSuccessRate" class="counter"></span>%
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="bg-light">
                        <!-- You can delete "bg-light" class. It is just to make background color -->
                        <p class="tc">
                            Earn Gifts</p>
                        <div class="counters">
                            <span id="spnGrandEarnGift" class="counter"></span>
                        </div>
                    </div>
                </div>
                <div class="col-md-4" style="display:none">
                    <div class="bg-light">
                        <!-- You can delete "bg-light" class. It is just to make background color -->
                        <p class="tc">
                            Total Commission</p>
                        <div class="counters">
                            $<span class="counter">12.00</span>
                        </div>
                    </div>
                </div>
            </div>
            <!--Service Block v3-->
            <form class="sky-form" role="form">
            <select class="form-control col col-4" id="optProductStatus" onchange="DoProductStatusChange()">
                <option value ="">Products Status</option>
                <option value ="">All</option>
                <option value ="1">Public Evaluating</option>
                <option value ="4">Tweebaa Evaluating</option>
                <option value ="2">Test-Sale</option>
                <option value ="3">Buy Now</option>
                <option value ="7">Test-Sale Failed</option>
            </select>
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
                            <th class="hidden-sm">
                                Product Information
                            </th>
                            <th>
                            </th>
                            <th>
                                Status
                            </th>
                            <th>
                                Action
                            </th>
                        </tr>
                    </thead>
                    <tbody id="tbData">
                        <%--<tr>
                            <td style="width: 20%" class="hidden-sm">
                                <div>
                                    <a href="product-details.html">
                                        <img src="../images/thumb/02.jpg" alt="" width="100">
                                    </a>
                                </div>
                            </td>
                            <td style="width: 30%">
                                <h5>
                                    <a href="product-details.html">TSHOP Tshirt DO9 </a>
                                </h5>
                                <h6>
                                    $22
                                </h6>
                                <h5>
                                    <small>Submit time : 06/12/2015</small></h5>
                            </td>
                            <td style="width: 25%; vertical-align: middle; padding: 0 20px;">
                                <h3 class="heading-xs">
                                    Draft</h3>
                                <div class="progress progress-u progress-xs">
                                    <div class="progress-bar progress-bar-blue" role="progressbar" aria-valuenow="76"
                                        aria-valuemin="0" aria-valuemax="100" style="width: 76%">
                                    </div>
                                </div>
                                <h3 class="heading-xs">
                                    Evaluators: 0/300</h3>
                            </td>
                            <td style="width: 20%; vertical-align: middle">
                                <button class="btn rounded btn-default btn_mg" type="button">
                                    <i class="fa fa-share-alt"></i>
                                </button>
                                <button class="btn rounded btn-default btn_mg" type="button">
                                    <i class="fa  fa-trash"></i>
                                </button>
                            </td>
                        </tr>--%>
                      
                    </tbody>
                </table>
            </div>
            <%--<div class="text-right">
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

    <div class="greybox" style="margin-top:60px">
        <div id="share-tck2" class="tck">
            <a href="#" class="closeBtn" title="Close"></a>
            <h2 class="t">
                <span>Share</span>
            </h2>
             <div class="box">
                <div class="sharebox clearfix my-dietu">
                    <span class="fl t ">Share to </span>
                    
                        <% // include all share method  %>        
                        <!--#include file="../Include/ShareMethod.inc" -->
                                     
                    <a href="#" style="display:none;" class="share-media-set">Share Binding setting</a>
                </div>
                <div class="ps clearfix">
                    <span class="fr"><a href="#"></a></span><span class="fl">Invite your friends to support this product by taking a short survey.</span>
                </div>
            </div>         
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

    //Close弹出框
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

    //隐藏弹出 框
    function hidePopup() {
        $(".popbox").hide();
    }
      
</script>
</asp:Content>
