﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="HomeShipOrder.aspx.cs" Inherits="TweebaaWebApp2.Home.HomeShipOrder" %>
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

    <%--paging--%>
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


    <script src="../MethodJs/homeShipOrder.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
            <div class="col-md-9">
            <h2>Purchase Order Summary</h2>
                <!--Profile Body-->
                <div class="profile-body"> 
                 <div class="row margin-bottom-20"> 
                 <div class="col-md-3">
                        <div class="bg-light"><!-- You can delete "bg-light" class. It is just to make background color -->        
                            <p class="tc">Waiting to ship</p>
                           <div class="counters">
                                <span class="counter" id="spnToBeShipSum">0</span>   
                                
                            </div>
                       
                        </div>
                    </div>
                        <div class="col-md-3">
                        <div class="bg-light"><!-- You can delete "bg-light" class. It is just to make background color -->        
                            <p class="tc">Shipped</p>
                           <div class="counters">
                                <span class="counter" id="spnShippedSum">0</span>   
                                
                            </div>
                       
                        </div>
                    </div>
                     <div class="col-md-3" style="display:none">
                        <div class="bg-light"><!-- You can delete "bg-light" class. It is just to make background color -->        
                            <p class="tc">Completed</p>
                           <div class="counters">
                                <span class="counter" id="spnCompletedSum">0</span>   
                                
                            </div>
                      
                        </div>
                    </div>
                     <div class="col-md-3">
                        <div class="bg-light"><!-- You can delete "bg-light" class. It is just to make background color -->        
                            <p class="tc">Cancelled</p>
                           <div class="counters">
                                <span class="counter" id="spnCancelSum" >0</span>   
                                
                            </div>
                        </div>
                    </div></div>
                    <div class="row">
          <form class="sky-form" role="form" > 
          <section class="col col-4" style="border-bottom:none">
                                <label class="input">
                                    <input id="txtShipOrderID" type="text" placeholder="Order#" />
                                </label>
                            </section>
            <section class="col col-4" style="border-bottom:none">
                                <label class="input">
                                    <input id="txtTrackingNo" type="text" placeholder="Tracking#" />
                                </label>
                        </section> 
                             <select id="optStatus" class="form-control col col-4">
                                <option value="" selected>All</option>
                                <option value="1">Waiting To Ship</option>
                                <option value="2">Shipped</option>
                                <option value="-1">Cancelled</option>
                    </select>      
                    </form> 
                    </div>
              <div class="row" >     
            <form class="sky-form" role="form" >                       
                    
                    <section class="col col-4"  style="border-bottom:none">
                                            <label class="input">
                                                <i class="icon-append fa fa-calendar"></i>
                                                <input id="txtBeginTime" type="text" name="start" placeholder="Start date" class="datepicker"/>
                                            </label>
                                        </section>
                    
                       <section class="col col-4" style="border-bottom:none">
                                            <label class="input">
                                                <i class="icon-append fa fa-calendar"></i>
                                                <input id="txtEndTime" type="text" name="finish" placeholder="End date" class="datepicker" />
                                            </label>
                                        </section>
                  <button class="btn-u rounded btn-u-blue" type="button" onclick="DoSearch();" >Search</button> 
                  
                  <% // popup for Shipment  %> 
                       <div class="modal fade" id="divShipment" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog modal-sm">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title" id="myModalLabel">Shipment</h4>
                                    </div>
                                    <div class="modal-body">
                                    <div class="row">
                                    <div class="col-md-12">
                                     <label class="input">
                                        <i class="icon-append fa fa-calendar"></i>
                                        <input id="txtShipmentShippedDate" class="form-control col col-4" style="color:Black" type="text" name="start" placeholder="Please enter shipped date" class="datepicker"/>
                                     </label>
                                     </div></div>
                                     <div class="row ">
                                    <div class="col-md-12 margin-bottom-10">
                                        <input type="text" style="color:Black" class="form-control" id="txtShipmentTrackingNo" placeholder="Please enter tracking #" />
                                     </div></div>
                                     <div class="row ">
                                    <div class="col-md-12">
                                        <input type="text" style="color:Black" class="form-control" id="txtShipmentCarrierName" placeholder="Please enter shipment Carrier Name" />
                                        </div> </div>               
                                        </div>
                                   
                                    <div class="modal-footer">
                                        <button type="button" class="btn-u btn-u-default rounded" data-dismiss="modal">Close</button>
                                        <button type="button" class="btn-u btn-u-primary rounded" onclick="DoSaveShipment();" >Save Shipment </button>
                                    </div>
                                     </div>
                                </div>
                            </div>

                  <% // popup for return  %> 
                       <div class="modal fade" id="divReturn" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog modal-sm">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title" id="H1">Return</h4>
                                    </div>
                                    <div class="modal-body">
                                       <div class="row ">
                                    <div class="col-md-12 margin-bottom-10">
                                     <label class="input">
                                        <i class="icon-append fa fa-calendar"></i>
                                        <input id="txtReturnDate" style="color:Black" type="text" name="start" placeholder="Please enter return date" class="datepicker"/>
                                     </label></div></div>
                                     <div class="row ">
                                    <div class="col-md-12 margin-bottom-10">
                                   <select id="optReturnQuality" class="form-control">
                                     <option value="" selected>Please select quality</option>
                                     <option value="0">Damaged</option>
                                     <option value="1">First Quality</option>
                                     <option value="2">Second Quality</option>
                                  </select>      
                                  </div>
                                     </div>

                                     <div class="row ">
                                    <div class="col-md-12 margin-bottom-10">
                                   <select id="optReturnReason" class="form-control">
                                     <option value="" selected>Please select reason</option>
                                     <option value="01">Undeliverable</option>
                                     <option value="02">Defective</option>
                                     <option value="03">Wrong Item</option>
                                     <option value="04">No Longer Wanted</option>
                                     <option value="05">Never Ordered</option>
                                     <option value="06">Refused</option>
                                     <option value="07">No reason given</option>
                                     <option value="08">Wrong size or color</option>
                                     <option value="09">Other</option>
                                  </select>      
                                  </div>
                                     </div>
                                 <div class="row">
                                    <div class="col-md-12 margin-bottom-10">
                                   <select id="optReturnAction" class="form-control">
                                     <option value="" selected>Please select action</option>
                                     <option value="Replace">Replace</option>
                                     <option value="Refund">Refund</option>
                                     <option value="Do Nothing">Do Nothing</option>
                                  </select>     
                                         </div>
                                     </div> 
                                  
                                    <div class="modal-footer">
                                        <button type="button" class="btn-u btn-u-default" data-dismiss="modal">Close</button>
                                        <button type="button" class="btn-u btn-u-primary" onclick="DoSaveReturn();" >Save Return </button>
                                    </div>
                                     </div>
                                </div>
                            </div>



             
                  <% // not used  --- model popup for update status %>
                   <div class="modal fade" id="divUpdateStatus" tabindex="-1" role="dialog" aria-labelledby="Updatehead" aria-hidden="true">
                            <div class="modal-dialog modal-sm">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title" id="Updatehead">Update Status</h4>
                                    </div>
                                    <div class="modal-body">
                                 <select class="form-control" id="optUpdateStatus">
                        <option value="" selected>Please select</option>
                        <option value="1">Waiting To Ship</option>
                        <option value="2">Shipped</option>
                        <option value="-1">Cancelled</option>          
                    </select>
                 <div class="margin-bottom-20">  </div>               
                                        </div>
                                   
                                    <div class="modal-footer">
                                        <button type="button" class="btn-u btn-u-default rounded" data-dismiss="modal">Close</button>
                                        <button type="button" class="btn-u btn-u-primary rounded" onclick="DoUpdateStatus();">Save changes</button>
                                    </div>
                                     </div>
                                </div>
                            </div>
              
                        </form></div>
                 <div class="row margin-bottom-20">
         
              
                    <!-- End Panel -->    
                    <div class="col-md-12">
                       <div class="panel margin-bottom-40 padd0">
                  
                        <table class="table" id="tblShipOrderList">
                        <!--thead>
                        <tr>
                            <th>Order #</th>
                            <th width="140">Customer Order #</th>
                            <th class="hidden-sm">Order Date</th>
                            <th class="hidden-sm">Total Items</th>
                            <th class="hidden-sm">Total Price</th>
                            <th class="hidden-sm">Tracking</th>
                            <th>Status</th>
                             <th>Action</th>
                            
                        </tr>
                    </thead>
                                        <tbody>
                                        <tr>
                                            <td>12345678</td>
                                            <td>Twee1000057</td>
                                            <td class="hidden-sm">5</td> 
                                            <td class="hidden-sm"> $231.00</td>
                                            <td class="hidden-sm"><span>Jun/22/2016</span></td>
                                            <td class="hidden-sm"> UPS897669 </td>
                                            <td><span class="label label-warning">Waitting</span></td>
                                            <td><select class="form-control input-sm">
                         <option value="0">Choose Action</option>
                          <option value="1">Order Details</option>
                          <option value="2">Update Status</option>
                          <option value="3" data-toggle="modal" data-target="#responsive">Add Tracking </option>
                       
              
                    </select></td> </tr>
                                  <tr>
                                            <td>12345678</td>
                                            <td>Twee1000057</td>
                                            <td class="hidden-sm">5</td> <td class="hidden-sm"> $231.00</td>
                                            <td class="hidden-sm"><span>Jun/22/2016</span></td>
                                            <td class="hidden-sm"> UPS897669 </td>
                                            <td><span class="label label-info">Shipping</span></td>
                                            <td><select class="form-control input-sm">
                         <option value="0">Choose Action</option>
                          <option value="1">Order Details</option>
                          <option value="2">Update Status</option>
                          <option value="3">Add Tracking </option>
              
                    </select></td> </tr>
                                             <tr>
                                            <td>12345678</td>
                                            <td>Twee1000057</td>
                                            <td class="hidden-sm">5</td> <td class="hidden-sm"> $231.00</td>
                                            <td class="hidden-sm"><span>Jun/22/2016</span></td>
                                            <td class="hidden-sm"> UPS897669 </td>
                                            <td><span class="label label-success">Complete</span></td>
                                            <td><select class="form-control input-sm">
                         <option value="0">Choose Action</option>
                          <option value="1">Order Details</option>
                          <option value="2">Update Status</option>
                          <option value="3">Add Tracking </option>
     
                    </select></td> </tr>
                                      <tr>
                                            <td>12345678</td>
                                            <td>Twee1000057</td>
                                            <td class="hidden-sm">5</td> <td class="hidden-sm"> $231.00</td>
                                            <td class="hidden-sm"><span>Jun/22/2016</span></td>
                                            <td class="hidden-sm"> UPS897669 </td>
                                            <td><span class="label label-danger">Return</span></td>
                                            <td><select class="form-control input-sm">
                         <option value="0">Choose Action</option>
                          <option value="1">Order Details</option>
                          <option value="2">Update Status</option>
                          <option value="3">Add Tracking </option>
       
                    </select></td> </tr>
                                       
                                        </tbody-->
                                    </table>
                            </div>
              <div id="divNoData" style="display:none" >No data found! </div>
              <div id="kkpager" style="float:right; padding-right:150px;"></div><br />
                  
                </div>
                  
                </div>
              
                      
                      </div>
                        </div> 

   
    <!--=== End Content Part ===-->

</asp:Content>