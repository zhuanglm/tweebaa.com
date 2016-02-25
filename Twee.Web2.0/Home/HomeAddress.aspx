﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="HomeAddress.aspx.cs" Inherits="TweebaaWebApp2.Home.HomeAdress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
My Home Address
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="../css/index.css" />
    <link rel="stylesheet" href="../css/home.css" />
    <link rel="stylesheet" href="../css/mycart.css" />
    <link rel="stylesheet" href="../css/c.css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <script src="../js/selectNav.js" type="text/javascript"></script>
    <script src="../js/homePage.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../css/selectCss.css" />
    <script src="../js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/public.js"></script>
    <script type="text/javascript" src="../js/home-safe.js"></script>
    <script src="../js/address.js" type="text/javascript"></script>
    <script src="../MethodJs/homeUserAddress.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">


<div class="col-md-9">
            <h2><i class="icon-pointer"></i> My Address</h2>
                <!--Profile Body-->
                <div class="profile-body">  
                     <div class="alert alert-warning fade in">
                    <button data-dismiss="alert" class="close" type="button">×</button>       
 Please configure your default billing and delivery addresses when placing an order. You may also add additional addresses, which can be useful for sending gifts or receiving an order at your office.
<a class="alert-link" target="_blank" href="#">Learn more </a> .
                </div>  
                <div class="row">
                  <div class="col-lg-12 margin-bottom-15">
                    <dt> Your addresses are listed below. </dt>

                    <dd> Be sure to update your personal information if it has changed.</dd>
                    <br />
     <a href="/Home/AddressAddEdit.aspx<%=strComeFrom %>" class="btn btn-sm btn-success">
                     <i class="fa fa-edit"> </i> Add Address </a> 
                      <br />

                 </div>   
                    <hr />
                                    <div id="tabAddress"></div>
                </div>



                <!--

                     <div class="col-xs-12 col-sm-6 col-md-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><strong>My Address</strong></h3>
                            </div>
                            <div class="panel-body">
                            
                                <ul>
                                    <li><span class="address-name"> <strong>Tanim Ahmed</strong></span></li>
                                    <li><span class="address-company"> TanimDesign & Development </span></li>
                                    <li><span class="address-line1"> Gulshan 2 , Road 50, House FO12EO </span></li>
                                    <li><span class="address-line2"> Dhaka, Bangladesh </span></li>
                                    <li><span> <strong>Mobile</strong> : 01670531352 </span></li>
                                    <li><span> <strong>Phone</strong> : 020904 - 85882 </span></li>
                                </ul>
                           
                            <div class="panel-footer panel-footer-address"><a href="/Home/AddressAddEdit.aspx"
                                                                              class="btn btn-sm btn-success"> <i
                                    class="fa fa-edit"> </i> Edit </a> <a class="btn btn-sm btn-danger"> <i
                                    class="fa fa-minus-circle"></i> Delete </a>
                             </div>
                        </div>
                    </div></div>  -->
           
               
              
        
                      </div>
                        </div> 

              

<script type="text/javascript">
    $(document).ready(function () {
        LoadShopAddress();
        LoadArea();
    });

</script>

</asp:Content>
