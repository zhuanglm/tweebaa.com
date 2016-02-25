﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="AddressAddEdit.aspx.cs" Inherits="TweebaaWebApp2.Home.AddressAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
My Address Management
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="../css/index.css" />
    <link rel="stylesheet" href="../css/home.css" />
   <!-- <link rel="stylesheet" href="../css/mycart.css" />  -->
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

    <script src="/js/jquery.mask.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
<input type="hidden" id="pageComeFrom" value="<%=strComeFrom %>" />

            <div class="col-md-9">
            <h2><i class="icon-map"></i> My Shipping Address</h2>
                <!--Profile Body-->
                <div class="profile-body">  
                     <div class="alert alert-warning fade in">
                    <button data-dismiss="alert" class="close" type="button">×</button>       
 Please configure your default billing and delivery addresses when placing an order. You may also add additional addresses, which can be useful for sending gifts or receiving an order at your office.
<a class="alert-link" target="_blank" href="#">Learn more </a> .
                </div>  
                <div class="row">
                  <div class="col-lg-12">
                    <dt> Your addresses are listed below. </dt>

                    <dd> Be sure to update your personal information if it has changed.</dd>
                    <hr>
                </div>
        

                    <div class="col-xs-12 col-sm-6">


                        <div class="form-group required">
                            <label for="InputName">First Name <sup>*</sup> </label>
                            <input required type="text" class="form-control" id="txtName2" placeholder="First Name" />
                            <span class="error" id="errorName" style="margin-bottom:10px">Please input First Name</span>
                        </div>
                        
                        <div class="form-group required">
                            <label for="InputLastName">Last Name <sup>*</sup> </label>
                            <input required type="text" class="form-control" id="txtLastname" placeholder="Last Name">
                            <span class="error" id="errorLastName" style="margin-bottom:10px">Please input Last Name</span>
                        </div>
                       
                        <div class="form-group">
                            <label for="InputCompany">E-Mail <sup>*</sup> </label>
                            <input type="text" class="form-control" id="txtEMail" placeholder="EMail">
                            <span class="error" id="errorEMail" style="margin-bottom:10px">Please input EMail</span>
                        </div>

                        
                        <div class="form-group required">
                            <label for="InputAddress" class="fl">Address <sup>*</sup> </label>
                            <input required type="text" class="form-control" id="txtAddress2" placeholder="Address">
                            <span class="error" id="errorAddress" style="margin-bottom:10px">Please input Address</span> <span class="ok">ok</span>
                        </div>
                        <!--
                        <div class="form-group">
                            <label for="InputAddress2">Address (Line 2) </label>
                            <input type="text" class="form-control" id="InputAddress2" placeholder="Address">
                        </div>
                        -->

                        <div class="form-group required">
                            <label for="InputZip" class="fl">Zip / Postal Code <sup>*</sup> </label>
                            <input required type="text" onchange="GetCityStateByZipCode()" class="form-control" id="txtZip2"
                                   placeholder="Zip / Postal Code"><span class="error" id="errorZip" style="margin-bottom:10px">Please input Zip / Postal Code </span> <span class="ok">ok</span>
                        </div>

                        <div class="form-group required">
                            <label for="InputCity" class="fl">City <sup>*</sup> </label>
                            <input required type="text" class="form-control"  id="txtCity2" placeholder="City">
                             <span class="error" id="errorCity" style="margin-bottom:10px">Please input City</span> <span class="ok">ok</span>
                        </div>


                            <div class="form-group required">
                            <label for="InputCountry" class="fl" >State <sup>*</sup> </label>
                            
                                  <select  id="selectProvince2" class="form-control fl" style="width: 150px;">
                                    </select>
                            </select>
                        </div>





                        <div class="form-group required">
                            <label for="InputCountry" class="fl">Country <sup>*</sup> </label>
                                     <select id="selectCountry2" class="form-control">
                                        <%-- class="selects"--%>
                                        <option selected="selected" value="1" style="width: 150px;">China</option>
                                    </select>
                        </div>

                        <div class="form-group">
                        <label><input id="ckbDefault2" type="checkbox" checked /> My default shipping address</label>
                        </div>


                    </div>


                    <div class="col-xs-12 col-sm-6">

                    <!--
                        <div class="form-group">
                            <label for="InputAdditionalInformation">Additional information</label>
                            <textarea rows="3" cols="26" name="InputAdditionalInformation" class="form-control"
                                      id="InputAdditionalInformation"></textarea>
                        </div>
                    -->
                        <div class="form-group required">
                            <label for="InputMobile">Phone <sup>*</sup></label>
                            <input required type="tel"  class="form-control phone_us" id="txtPhone2">
                            <span class="error" id="errorPhone" style="margin-bottom:10px">Please input Phone Number</span> <span class="ok">ok</span>
                        </div>

                        <!--
                        <div class="form-group required">
                            <label for="addressAlias">Please assign an address title for future reference. <sup>*</sup></label>

                            <input required type="text" value="My address" name="addressAlias" class="form-control"
                                   id="addressAlias">

                        </div>
                        -->

                    </div>

                    <div class="col-lg-12 col-xs-12 clearfix" id="divAddButton" style="display:none">
                        <button type="button" class="btn   btn-primary" id="btnAdd" onclick="AddAddress();return false;" ><i class="fa fa-map-marker"></i> Save New Address
                        </button>
                    </div>

                    <div class="col-lg-12 col-xs-12 clearfix" id="divEditButton" style="display:none">
                        <button type="button" class="btn   btn-primary" id="btnEdit" onclick="DoSaveEditAddress();return false;" ><i class="fa fa-map-marker"></i> Save Address
                        </button>
                    </div>

               
                     <div class="col-lg-12 col-xs-12  clearfix ">

                    <ul class="pager">
                        <li class="previous pull-right"><a href="/Product/prdSaleAll.aspx"> <i class="fa fa-shopping-cart"></i> Go to Shop </a>
                        </li>
                        <li class="next pull-left"><a href="/Home/HomeAddress.aspx">&larr; Back to My Address</a></li>
                    </ul>
                </div>

                    </div>
           
               
              
        
                      </div>
                        </div> 

                </div>
                 </div></div>
<script type="text/javascript" src="/js/plugins/datepicker.js"></script>
<script type="text/javascript" src="/js/plugins/masking.js"></script>
<script type="text/javascript" src="/js/plugins/validation.js"></script>
<script type="text/javascript" src="/js/plugins/style-switcher.js"></script>
<script type="text/javascript" >
    jQuery(document).ready(function () {
        // Datepicker.initDatepicker();
        LoadArea();
        if (location.href.indexOf("?") == -1) {
            btnFlag = "add";
            $("#divAddButton").show();
            $("#divEditButton").hide();

        } else {
            var queryString = location.href.substring(location.href.indexOf("?") + 1); //guid=61a734cb-3fb6-4c08-a0af-71ce26814ca1


            var parameters = queryString.split("=");
            if (parameters[0] == "from") {
                //这是从shop page过来的
                btnFlag = "add";
                $("#divAddButton").show();
                $("#divEditButton").hide();
            } else {
                btnFlag = "update";
                var guid = parameters[1];
                LoadAddressByID(guid);
                $("#divAddButton").hide();
                $("#divEditButton").show();
            }
            //$("#btnSave2").unbind("click");
            //$("#btnSave2").bind("click", function () { UpdateAddress(guid); return false; });
        }

        $('.phone_us').mask('(000) 000-0000');
    });

    function DoSaveEditAddress() {
        var queryString = location.href.substring(location.href.indexOf("?") + 1); //guid=61a734cb-3fb6-4c08-a0af-71ce26814ca1
        var parameters = queryString.split("=");
        var guid = parameters[1];
        UpdateAddress(guid);
    }
    function GetCityStateByZipCode() {
        $("#txtShipCity").val("Getting Data...");
       // Loading(true);
        var txtZip = $("#txtZip2").val();
        if (txtZip.length >= 5) {
            var _data = "{ action:'QueryCityByZip"
                    + "',zip:'" + txtZip + "'}";
            $.ajax({
                type: "Post",
                url: '/AjaxPages/userAddressAjax.aspx',
                data: _data,
                async: false,
                success: function (resu) {
                   // Loading(false);
                    if (resu.length > 0) {
                        var p = resu.split(":");
                        $("#txtCity2").val(p[0]);
                        //Load Country first
                        /*
                        selects = $("#selectCountry");
                        $.each(selects, function (key, activity) {
                        // show me activity seelctec in each case
                        if ($(activity).html() == p[2]) {
                        //selected
                        $(activity).attr('selected', 'selected');
                        //load state/province
                        BindProvince($(activity).id, p[1]);
                        }
                        });*/
                        $("#selectCountry2").children("option").each(function () {
                            //alert(selectName + " " + $(this).html());
                            if ($(this).html() == p[2]) {
                                //selected
                                $(this).attr('selected', 'selected');
                                //load state/province
                                BindProvinceByName($(this).val(), p[1]);
                            }
                        });
                        /*
                        $("#selectCountry option", this).each(function () {

                        //alert($(this).val());
                        if ($(this).html() == p[2]) {
                        //selected
                        $(this).attr('selected', 'selected');
                        //load state/province
                        BindProvince($(this).val(), p[1]);
                        }
                        });*/
                    }
                },
                error: function (obj) {
                    //alert("失败");
                   // Loading(false);
                }
            });
        }

    }
</script>
<script type="text/javascript" >
    jQuery(document).ready(function ($) {
        "use strict";
        $('.contentHolder').perfectScrollbar();
    });
</script>
</asp:Content>
