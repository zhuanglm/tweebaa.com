<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="MyCollage.aspx.cs" Inherits="TweebaaWebApp2.Home.MyCollage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">


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
    <link rel="stylesheet" href="../css/theme-colors/default.css">

     <!-- CSS share box -->
     <link href="../css/shareBox.css" rel="stylesheet" type="text/css" />
     <link href="../css/shareall.css" rel="stylesheet" type="text/css" />

    <!-- CSS Customization -->
    <link rel="stylesheet" href="../css/custom.css">
    <script src="../MethodJs/share.js" type="text/javascript"></script>
    <script src="../js/CollageDesign.js" type="text/javascript"></script>
    <script src="../MethodJs/HomeCollage.js?v=20160205" type="text/javascript"></script>
     <%--分页--%>    
    <script src="../js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="../js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">


 <div class="col-md-9">
         <h2><span aria-hidden="true" class="fa fa-paint-brush"></span> My Collage</h2> 
      
         
                <!--Profile Body-->
                <div class="profile-body">
                <div class="alert alert-warning fade in">
                    <button data-dismiss="alert" class="close" type="button">×</button>       
       Perhaps the most exciting part of shopping on Tweebaa is sharing great products with your friends and earning income.<br> 
<a class="alert-link" target="_blank" href="http://getbootstrap.com/css/#tables">Learn more </a> .
                </div> 
                        <!--Service Block v3-->
                    <div class="row content-boxes-v2 margin-bottom-20">
       
                 <div class="col-md-6">
                        <div class="bg-light"><!-- You can delete "bg-light" class. It is just to make background color -->        
                            <p class="tc">Total Click</p>
                           <div class="counters">
                                <span class="counter" id="spanTotalClick"></span>   
                                
                            </div>
                          
                        </div>
                    </div>
                   <div class="col-md-6">
                        <div class="bg-light"><!-- You can delete "bg-light" class. It is just to make background color -->        
                            <p class="tc">Total Sold Amount</p>
                           <div class="counters">
                               $ <span class="counter" id="spanTotalSold"></span>                                   
                            </div>
                        </div>
                    </div>
                    
             </div><!--Service Block v3-->
              <form class="sky-form" role="form" > 
                 
                    <section class="col col-3" style="padding-left:0px;">
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
                                        <button class="btn-u rounded btn-u-blue" type="button" onclick="DoSearch()">Search</button>
                        </form>
                 
 <div class="panel margin-bottom-40">

  <table class="table">
    <thead>
   <tr>
   <th class="hidden-sm" >Collage Information</th> 
                       
   <th>Totally Clicks</th>
   <th>Totally Sold Amount</th>
   <th>Action</th>
  </tr>
  
  </thead>
                                        <tbody id="tbData">
<!--
                                        <tr>
                                         
                                            <td style="width:35%">
                                             <h5><a href="product-details.html"><img src="../images/thumb/02.jpg" alt="" width="100">
                                                </a><br/>Collage name</h5>     
                                            </td>
                                           
                                     <td style="width:15%; "><h5>99 </h5></td>
                                     <td style="width:30%; "><h5>0 </h5></td>
                                     <td style="width:20%; "><button class="btn rounded btn-default btn_mg" type="button"><i class="fa fa-share-alt"></i></button></td>

                                        </tr>
                                     <tr>
                                         
                                            <td style="width:35%">
                                             <h5><a href="product-details.html"><img src="../images/thumb/02.jpg" alt="" width="100">
                                                </a><br/>Collage name</h5>     
                                            </td>
                                           
                                     <td style="width:15%; "><h5>99 </h5></td>
                                     <td style="width:15%; "><h5>0 </h5></td>
                                     <td style="width:20%; "><button class="btn rounded btn-default btn_mg" type="button"><i class="fa fa-share-alt"></i></button></td>

                                        </tr>
 -->                                            
                                        </tbody>
                                    </table> </div>
  <div class="text-right">
  <!--
                                <ul class="pagination">
                                    <li><a href="#">«</a></li>
                                    <li><a href="#">1</a></li>
                                    <li class="active"><a href="#">2</a></li>
                                    <li><a href="#">3</a></li>
                                    <li><a href="#">4</a></li>
                                    <li><a href="#">»</a></li>
                                </ul>
-->
                            <div id="divNoData" style="display:none" >No product found! </div>
                            <div id="kkpager" style="  float:right; padding-right:150px;"></div><br />

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

        //       Datepicker.initDatepicker();
        $(".datepicker").datepicker({
            nextText: ">",
            prevText: "<"
        });


    });
</script>

</asp:Content>
