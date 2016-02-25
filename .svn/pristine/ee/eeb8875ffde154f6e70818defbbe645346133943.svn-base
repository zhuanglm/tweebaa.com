<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Home.Master" AutoEventWireup="true"
    CodeBehind="HomeShare.aspx.cs" Inherits="TweebaaWebApp2.Home.HomeShare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    
    
    <!-- CSS Global Compulsory -->
    <link rel="stylesheet" href="../plugins/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/shop.style.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <!-- CSS Implementing Plugins -->
    <link rel="stylesheet" href="../plugins/line-icons/line-icons.css" />
    <link rel="stylesheet" href="../plugins/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../plugins/sky-forms/version-2.0.1/css/custom-sky-forms.css" />
    <link rel="stylesheet" href="../plugins/scrollbar/src/perfect-scrollbar.css" />
    <!-- CSS Page Style -->
    <link rel="stylesheet" href="../css/pages/profile.css" />
    <link rel="stylesheet" href="../css/theme-skins/dark.css" />
    <!-- Style Switcher -->
    <link rel="stylesheet" href="../css/plugins/style-switcher.css" />
    <!-- CSS Theme -->
    <link rel="stylesheet" href="../css/theme-colors/default.css" id="style_color" />
    <!-- CSS Customization -->
    <link rel="stylesheet" href="../css/custom.css" />

    <% //分页%>
    <script src="../js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="../js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />

        <!-- JS Global Compulsory -->
    <script src="../plugins/jquery/jquery.min.js"></script>
    <script src="../plugins/jquery/jquery-migrate.min.js"></script>
    <script src="../plugins/bootstrap/js/bootstrap.min.js"></script>
    <!-- JS Implementing Plugins -->
    <script src="../plugins/back-to-top.js"></script>
    <script src="../plugins/counter/waypoints.min.js"></script>
    <script src="../plugins/counter/jquery.counterup.min.js"></script>

    <!-- Datepicker Form -->
    <script src="../plugins/sky-forms/version-2.0.1/js/jquery-ui.min.js"></script>

    <!-- Scrollbar -->
    <script src="../plugins/scrollbar/src/jquery.mousewheel.js"></script>
    <script src="../plugins/scrollbar/src/perfect-scrollbar.js"></script>

    <!-- JS Customization -->
    <script type="text/javascript" src="../js/custom.js"></script>

    <!-- JS Page Level -->
    <script src="../js/shop.app.js"></script>
    <script src="../js/app.js"></script>
    <script type="text/javascript" src="../js/plugins/datepicker.js"></script>
    <script type="text/javascript" src="../js/plugins/masking.js"></script>
    <script type="text/javascript" src="../js/plugins/validation.js"></script>
    <script type="text/javascript" src="../js/plugins/style-switcher.js"></script>

    <script src="../MethodJs/homeShare.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
  <div class="col-md-9">
    <h2><span aria-hidden="true" class="fa fa-share-alt"></span> My Share</h2> 
      <!--Profile Body-->
      <div class="profile-body">
      <div class="alert alert-warning fade in">
        <button data-dismiss="alert" class="close" type="button">×</button>       
          Perhaps the most exciting part of shopping on Tweebaa is sharing great products with your friends and earning income.<br> 
          <a class="alert-link" target="_blank" href="../College/share-zone.aspx#collapseOne">Learn more </a> .
      </div> 
      
      <!--Service Block v3-->
      <div class="row content-boxes-v2 margin-bottom-20">
        <div class="col-md-4">
          <div class="bg-light"><!-- You can delete "bg-light" class. It is just to make background color -->        
            <p class="tc">Total Click</p>
            <div class="counters">
               <span class="counter" id="spnGrandTotalShareClick"></span>    
            </div>
          </div>
        </div>
        <div class="col-md-4">
          <div class="bg-light"><!-- You can delete "bg-light" class. It is just to make background color -->        
             <p class="tc">Total Sold QTY</p>
             <div class="counters">
                <span class="counter" id="spnGrandTotalShareSoldQty"></span>                                   
             </div>
           </div>
         </div>
         <div class="col-md-4">
           <div class="bg-light"><!-- You can delete "bg-light" class. It is just to make background color -->        
             <p class="tc">Total Share Commission</p>
             <div class="counters">$<span class="counter color-red" id="spnGrandTotalShareCommission"></span></div>
           </div>
         </div>  
       </div><!--Service Block v3-->
       
       <form class="sky-form" role="form" > 
         <span class="fl" style="margin-left:10px; margin-top:6px">Share Type:&nbsp;&nbsp;</span>
         <select class="form-control col col-3" style="width:auto" id="optShareType" onchange="DoShareTypeChange();">
                <option value="">All</option>
                <option value="Facebook">Facebook</option>
                <option value="Google">Google</option>
                <option value="Twitter">Twitter</option>
                <option value="Pinterest">Pinterest</option>
                <option value="Email">Email</option>
         </select>
         <section class="col col-3">
            <label class="input">
              <i class="icon-append fa fa-calendar"></i>
              <input type="text" name="start" id="txtBeginTime" placeholder="Start date"  class="datepicker">
            </label>
         </section>
                      
         <section class="col col-3">
           <label class="input">
             <i class="icon-append fa fa-calendar"></i>
             <input type="text" name="finish" id="txtEndTime" placeholder="End date" class="datepicker">
           </label>
         </section>
         <button class="btn-u rounded btn-u-blue" type="button" onclick="DoSearchProductShare()">Search</button>
       </form>
                 
   <div class="panel margin-bottom-40">

     <table class="table" id="tblShareList">
      <thead>
        <tr>
          <th class="hidden-sm" >Product</th> 
          <th style="text-align:center">Social Media</th>                        
          <th style="text-align:center">Clicks</th>
          <th style="text-align:center">QTY Sold</th>
          <th style="text-align:center">Copy Link</th>
        </tr>
      </thead>
      <tbody>
      <!--
        <tr>
          <td style="width:35%">
                <h5><a href="product-details.html"> TSHOP Tshirt DO9 </a></h5>     
          </td>
          <td style="width:15%;">
            <h5>Sub-Total</h5>
          </td>
          <td style="width:15%; "><h5>99 </h5></td>
          <td style="width:15%; "><h5>0 </h5></td>
          <td style="width:20%; "><h5>Copy</h5></td>
        </tr>
        <tr>
          <td style="width:35%">
                <h5><a href="product-details.html"> TSHOP Tshirt DO9 </a></h5>     
          </td>
          <td style="width:15%;">
            <h5>Sub-Total</h5>
          </td>
          <td style="width:15%; "><h5>99 </h5></td>
          <td style="width:15%; "><h5>0 </h5></td>
          <td style="width:20%; "><h5>Copy</h5></td>
        </tr>
        -->
      </tbody>
    </table>
  </div>
  <div class="text-right">
    <div id="divNoData" style="display:none" >No data found! </div>
    <div id="kkpager" style="float:right; padding-right:150px;"></div><br />
  </div>                                  
</div>
</div>

</asp:Content>
