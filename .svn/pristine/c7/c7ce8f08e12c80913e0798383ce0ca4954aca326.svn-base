var picPath = "https://tweebaa.com/";
$(document).ready(function () {
    $(".saved-address").hide();
    $(".shop-address").hide();
    LoadShopaddress();   
    var guid = $("#hidAddressId").val();    
});

function FillhiddenValue(i) {

    
    $("#hidAddressId").val($("#hidAddressId"+i).val());

    //使用Cookie来记录
    
    $.cookie('hidAddressId', $("#hidAddressId"+i).val(), { expires: 7 });
    $("#hid_countryID").val($("#labCountryID" + i).html());
    $("#hid_stateID").val($("#labProvinceID" + i).html());

    $("#txtZip").val($("#labZip" + i).html()); $("#txtShipZip").val($("#labZip" + i).html());
    $("#txtCity").val($("#CityName"+i).val()); $("#txtShipCity").val($("#CityName"+i).val());
    $("#txtAddress").val($("#Adress1"+i).val()); $("#txtShipAddress").val($("#Adress1"+i).val());
    $("#txtAddress2").val($("#Adress2"+i).val()); $("#txtShipAddress2").val($("#Adress2"+i).val());
    $("#txtName").val($("#FirstName"+i).val()); $("#txtShipName").val($("#FirstName"+i).val());
    $("#txtLastName").val($("#LastName"+i).val()); $("#txtShipLastName").val($("#LastName"+i).val());
    $("#txtPhone").val($("#labPhone" + i).html()); $("#txtShipPhone").val($("#labPhone" + i).html());
    //if (address.email != null) 
    {
        $("#txtEmail").val($("#labEmail" + i).html()); $("#txtShipEmail").val($("#labEmail" + i).html());
    }
    $("#hid_addrCity").val($("#CityName"+i).val());
    $("#hid_addrZip").val($("#labZip" + i).html());
    $("#hid_address1").val($("#Adress1"+i).val());
    $("#hid_address2").val($("#Adress2"+i).val());
    $("#hid_fistname").val($("#FirstName"+i).val());
    $("#hid_lastname").val($("#LastName"+i).val());
    $("#hid_phone").val($("#labPhone" + i).html());
    $("#hid_email").val($("#labEmail" + i).html());

    $("#selectCountry option[value=" + $("#labCountryID" + i).html() + "]").attr("selected", "true"); //国家
    BindProvince($("#labCountryID" + i).html(), $("#labProvinceID" + i).html()); //加载城市列表
    //$("#selectProvince option[value=" + obj.provinceid + "]").attr("selected", "true"); //省    

}
//我的收货地址（购物车改版后仅1个收货地址）
function LoadShopaddress() {
    LoadArea();
    var _data = "{ action:'query'}";
    $.ajax({
        type: "Post",
        url: '/AjaxPages/userAddressAjax.aspx',
        async: false,
        data: _data,
        success: function (resu) {
            if (resu == "-1" || resu == "" || resu == "null" || resu == "[]") {
                //$(".saved-address").hide();               
                $(".shop-address").show();
                $("#btnSave").unbind("click");
                $("#btnSave").bind("click", function () { AddAddress() });
                return;
            }
            else if (resu == "0") {
                return;
            }
            else {
                var obj = eval("(" + resu + ")");

                //modify by Long for multiple shipping address 2015/12/30
                var html = "";
                var iSelected = 0;
                for (var i = 0; i < obj.length; i++) {
                    var address = obj[i];
                    if (address.isfirst == 1 || obj.length == 1) {
                        html += '<table><tr><td valign="middle"><input type="hidden" id="hidAddressId' + i + '" value="' + address.guid + '"><input style="margin-top: 10px;min-height:20px !important;height:20px !important;" type="radio" name="rbSavedAddress" checked onclick="FillhiddenValue(' + i + ')" value="' + i + '">';
                        iSelected = i;
                    } else {
                        html += '<table><tr><td  valign="middle"><input type="hidden" id="hidAddressId' + i + '" value="' + address.guid + '"><input style="margin-top: 10px;min-height:20px !important;height:20px !important;" type="radio" name="rbSavedAddress" onclick="FillhiddenValue(' + i + ')" value="' + i + '">';
                    }
                    var sUserName = address.username;
                    if (address.lastName != null) sUserName = sUserName + " " + address.lastName;
                    var sUserAddress = address.address;
                    if (address.address2 != null) sUserAddress = sUserAddress + " " + address.address2;

                    var email = "";
                    if (address.email == null || address.email == "") {
                        //guest email
                        if (address.guest_e_mail == null || address.guest_e_mail == "") {
                            //$("#labEmail").hide();
                        } else {
                            //$("#labEmail").text(address.guest_e_mail);
                            email = address.guest_e_mail;
                        }
                    } else {
                        email = address.email;
                    }

                    html += '</td><td><input type="hidden" id="CityName' + i + '" value="' + address.city + '"><input type="hidden" id="ProName' + i + '" value="' + address.ProName + '"><label id="labName' + i + '">' + sUserName + '</label></td></tr><tr><td colspan="2"> <label id="labAddress' + i + '">' + sUserAddress + '</label>';
                    html += '</td></tr><tr><td colspan="2">';
                    html += '<label>' + address.city + ' , ' + address.ProName + '</label>';
                    html += '</td></tr><tr><td colspan="2">';
                    html += '<input type="hidden" id="FirstName' + i + '" value="' + address.username + '"><input type="hidden" id="LastName' + i + '" value="' + address.lastName + '">';
                    html += '<input type="hidden" id="Adress1' + i + '" value="' + address.address + '"><input type="hidden" id="Address2' + i + '" value="' + address.address2 + '">';
                    html += '<label id="labCountryID' + i + '" style="display: none">' + address.countyid + '</label>';
                    html += '<label id="labProvinceID' + i + '" style="display: none">' + address.provinceid + '</label>';
                    html += '<label id="labZip' + i + '">' + address.zip + '</label>&nbsp;<label id="labCountry' + i + '">' + address.country + '</label>';

                    html += '</td></tr><tr><td colspan="2"><label id="labPhone' + i + '">' + address.tel + '</label>';
                    html += '';
                    if (email.length > 0) {
                        html += '</td></tr><tr><td colspan="2"><label id="labEmail' + i + '">' + email + '</label>';
                    }
                    html += '</td></tr></table>';



                    /*
                    $("#hidAddressId").val(address.guid);

                    //使用Cookie来记录
                    $.cookie('hidAddressId', address.guid, { expires: 7 });
                    //$("#labName").text(address.username);

                    var sUserName = address.username;
                    if (address.lastName != null) sUserName = sUserName + " " + address.lastName;
                    $("#labName").text(sUserName);

                    var sUserAddress = address.address;
                    if (address.address2 != null) sUserAddress = sUserAddress + " " + address.address2;

                    $("#labAddress").html(sUserAddress + "<br/>" + address.city + " , " + address.ProName);
                    $("#labCountry").text(address.country);
                    $("#labCountryID").text(address.countyid);
                    $("#labProvinceID").text(address.provinceid);
                    $("#labPhone").text(address.tel);
                    $("#labZip").text(address.zip);

                    }
                    else {
                    $("#labEmail").text(address.email);
                    email = address.email;
                    }
                    $("#selectCountry option[value=" + address.countyid + "]").attr("selected", "true"); //国家
                    BindProvince(address.countyid, address.provinceid); //加载城市列表
                    //$("#selectProvince option[value=" + obj.provinceid + "]").attr("selected", "true"); //省    

                    $("#hid_countryID").val(address.countyid);
                    $("#hid_stateID").val(address.provinceid);

                    $("#txtZip").val(address.zip); $("#txtShipZip").val(address.zip);
                    $("#txtCity").val(address.city); $("#txtShipCity").val(address.city);
                    $("#txtAddress").val(address.address); $("#txtShipAddress").val(address.address);
                    $("#txtAddress2").val(address.address2); $("#txtShipAddress2").val(address.address2);
                    $("#txtName").val(address.username); $("#txtShipName").val(address.username);
                    $("#txtLastName").val(address.lastName); $("#txtShipLastName").val(address.lastName);
                    $("#txtPhone").val(address.tel); $("#txtShipPhone").val(address.tel);
                    //if (address.email != null) 
                    {
                    $("#txtEmail").val(email); $("#txtShipEmail").val(email);
                    }
                    $("#hid_addrCity").val(address.city);
                    $("#hid_addrZip").val(address.zip);
                    $("#hid_address1").val(address.address);
                    $("#hid_address2").val(address.address2);
                    $("#hid_fistname").val(address.username);
                    $("#hid_lastname").val(address.lastName);
                    $("#hid_phone").val(address.tel);
                    $("#hid_email").val(email);
                    //Auto Fill Billing Address
                    */

                }
                $("#divSavedAddressList").html(html);


                FillhiddenValue(iSelected);

                $("#btnSave").unbind("click");
                $("#btnSave").bind("click", function () { UpdateAddress(address.guid) });
                // strSql.Append("select guid,prtguid,provinceid,u.cityid,countyid,zip,address,username,
                // lastName,phone,tel,isfirst,addtime,p.ProName,city ");
                if (address.guid != null && address.guid != "") {
                    $(".saved-address").show();
                    $(".shop-address").hide();


                }
                //change address
                var IsChange = $("#hid_action_change").val();
                if (IsChange == 1) {
                    $(".saved-address").hide();
                    $(".shop-address").show();
                }

                return;
            }
        },
        error: function (msg) {
            // alert("请求失败");
        }
    });

    function btnSaveClick() {
        var guid = $("#hidAddressId").val();
        if (guid == null || guid == "") {
            AddAddress();
        }
        else {
            UpdateAddress(guid); 
        }

    }

    function CheckAddress(address) {
        // mantis #622 Either put a restriction so if system detects "PO Box" or "P.O. Box" in the ship address field it will create Error message
        //...OR put a bold warning that we cannot deliver to a PO Box.
        var addressLowerCase = address.toLowerCase();
        var patt = /(po|p.o.)\s{1,}(box)/g;
        var result = patt.test(addressLowerCase);
        return (!result);
    }


    //更新收货地址

  
    //更新收货地址
    function UpdateAddress(guid) {
        var flag = "true";
        var countyid = $("#selectCountry  option:selected").val();
        var provinceid = $("#selectProvince  option:selected").val();
        var cityid = null;//  $("#selectCity  option:selected").val();
        var city = $("#txtCity").val(); //城市
        var zip = $("#txtZip").val();
        var address = $("#txtAddress").val();
        var address2 = $("#txtAddress2").val();
        var username = $("#txtName").val();
        var lastName = $("#txtLastName").val(); //姓氏
        var tel = $("#txtPhone").val();
        var phone = $("#txtPhone").val();
        var isfirst = 1;
        //if ($("#ckbDefault").is(":checked")) { isfirst = 1;} else { isfirst = 0;}       
        //if (cityid == "-1" || cityid == "") { $("#errorArea").show(); }
        var bAddressOK = CheckAddress(address);
        var bAddress2OK = CheckAddress(address2);
        if (!bAddressOK || !bAddress2OK) {
            alert("We cannot deliver to a PO Box.\nPlease change your delivery address!");
            if (!bAddressOK) $("#txtAddress").focus();
            else  $("#txtAddress2").focus();
        }

        if (city == "") { $("#errorCity").show(); flag = "false"; } else { $("#errorCity").hide(); }
        if (zip == "") { $("#errorZip").show(); flag = "false"; } else { $("#errorZip").hide(); }
        if (address == "" || !bAddressOK || !bAddress2OK) { $("#errorAddress").show(); flag = "false"; } else { $("#errorAddress").hide(); }
        if (username == "") { $("#errorNmae").show(); flag = "false"; } else { $("#errorNmae").hide(); }
        if (lastName == "") { $("#errorlastName").show(); flag = "false"; } else { $("#errorlastName").hide(); }
        if (phone == "") { $("#errorPhone").show(); flag = "false"; } else { $("#errorPhone").hide(); }
        if (provinceid == "-1") { $("#errorArea").show(); flag = "false"; } else { $("#errorArea").hide(); }
        if (flag == "false") {
            return;
        }
        var _data = "{ action:'update"
                    + "',guid:'" + guid
                    + "',countyid:'" + countyid
                    + "',provinceid:'" + provinceid
                    + "',cityid:'" + cityid
                    + "',city:'" + city
                    + "',zip:'" + zip
                    + "',address:'" + address
                    + "',address2:'" + address2
                    + "',username:'" + username
                    + "',lastName:'" + lastName
                    + "',phone:'" + phone
                    + "',tel:'" + tel
                    + "',isfirst:'" + isfirst + "'}";
        $.ajax({
            type: "Post",
            url: '/AjaxPages/userAddressAjax.aspx',
            data: _data,
            async: false,
            success: function (resu) {
                if (resu == "-1") {
                    //alert("Please login！");
                    return;
                }
                else if (resu == "0") {
                    alert("Modify the failure！");
                    return;
                }
                else {
                    alert("Successful modification！");
                    $(".greybox,.add-new-address-box").hide();
                    $("#ulAddress1").empty();
                    LoadShopaddress();

                    // after updating, need to re-load the check cart because the counry and Zip will affect the shippping fee
                    LoadCheckCart();

                    //ClearForm();
                    //window.location.href = window.location.href;
                    return;
                }
            }
        });
    }
    //新增收货地址
    var btnFlag = "add"; //add:按钮执行添加操作； update:按钮执行更新操作
    function AddAddress() {
        $("#btnSave").unbind("click");
        $("#btnSave").bind("click", function () { AddAddress() });
        var flag = "true";
        var countyid = $("#selectCountry  option:selected").val();
        var provinceid = $("#selectProvince  option:selected").val();
        var cityid = ""; // $("#selectCity  option:selected").val();
        var city = $("#txtShipCity").val(); //城市
        var zip = $("#txtShipZip").val(); //
        var address = $("#txtShipAddress").val();
        var address2 = $("#txtShipAddress2").val();
        var username = $("#txtShipName").val();
        var lastName = $("#txtShipLastName").val(); //姓氏
        var phone = $("#txtShipPhone").val();
        var tel = $("#txtShipPhone").val();
        var isfirst = 1;

        /////e-mail address add by Long as Guest Checkout can'r receive e-mail
        var e_mail = "";
        if ($("#txtShipEmail").length) {
            e_mail = $("#txtShipEmail").val();
        }

        //if ($("#ckbDefault").is(":checked")) {isfirst = 1;}
        
        var bAddressOK = CheckAddress(address);
        var bAddress2OK = CheckAddress(address2);
        if (!bAddressOK || !bAddress2OK) {
            alert("We cannot deliver to a PO Box.\nPlease change your delivery address!");
            if (!bAddressOK) $("#txtAddress").focus();
            else $("#txtAddress2").focus();
        }

        if (username == "") { $("#errorNmae").show(); flag = "false"; } else { $("#errorNmae").hide(); }
        if (lastName == "") { $("#errorlastName").show(); flag = "false"; } else { $("#errorlastName").hide(); }
        if (city == "") { $("#errorCity").show(); flag = "false"; } else { $("#errorCity").hide(); }
        if (zip == "") { $("#errorZip").show(); flag = "false"; } else { $("#errorZip").hide(); }
        if (address == "" || !bAddressOK || !bAddress2OK ) { $("#errorAddress").show(); flag = "false"; } else { $("#errorAddress").hide(); }       
        if (phone == "") { $("#errorPhone").show(); flag = "false"; } else { $("#errorPhone").hide(); }
        if (provinceid == "-1") { $("#errorArea").show(); flag = "false"; } else { $("#errorArea").hide(); }
        if (flag == "false") {
            return;
        }
        var _data = "";
        if (e_mail.length > 0) {
            _data = "{ action:'add"
                    + "',countyid:'" + countyid
                    + "',provinceid:'" + provinceid
                    + "',cityid:'" + cityid
                    + "',city:'" + city
                    + "',zip:'" + zip
                    + "',address:'" + address
                    + "',address2:'" + address2
                    + "',username:'" + username
                    + "',lastName:'" + lastName
                    + "',phone:'" + phone
                    + "',tel:'" + tel
                    + "',email:'" + e_mail
                    + "',isfirst:'" + isfirst + "'}";
        } else {
            _data = "{ action:'add"
                    + "',countyid:'" + countyid
                    + "',provinceid:'" + provinceid
                    + "',cityid:'" + cityid
                    + "',city:'" + city
                    + "',zip:'" + zip
                    + "',address:'" + address
                    + "',address2:'" + address2
                    + "',username:'" + username
                    + "',lastName:'" + lastName
                    + "',phone:'" + phone
                    + "',tel:'" + tel
                    + "',isfirst:'" + isfirst + "'}";
        }
        $.ajax({
            type: "Post",
            url: '/AjaxPages/userAddressAjax.aspx',
            data: _data,
            async: false,
            success: function (resu) {
                if (resu == "-1") {
                    alert("Please log in！");
                    return;
                }
                else if (resu == "0") {
                    alert("Failed to add！");
                    return;
                }
                else {
                    alert("Added successfully！");
                    //$(".greybox,.add-new-address-box").hide();
                    LoadShopaddress();

                    // after adding address need to re-load the check cart because the counry and Zip will affect the shippping fee
                    LoadCheckCart();

                    ClearForm();
                    return;
                }
            }
        });
    }

    //设为默认收货地址
    function SetDefault(guid) {
        var _data = "{ action:'setdefault" + "',guid:'" + guid + "'}";
        $.ajax({
            type: "Post",
            url: '/AjaxPages/userAddressAjax.aspx',
            data: _data,
            success: function (resu) {
                if (resu == "-1") {
                    alert("Please login！");
                    return;
                }
                else if (resu == "0") {
                    alert("Setup failed！");
                    return;
                }
                else {
                    alert("Set successfully！");
                    LoadShopaddress();
                    return;
                }
            }
        });
    }

    
    //清空添加地址页面
    function ClearForm() {
//        $("#selectCountry option[value=-1]").attr("selected", "true");
//        $("#selectProvince option[value=-1]").attr("selected", "true");
//        $("#txtZip").val("");
//        $("#txtAddress").val("");
//        $("#txtAddress2").val("");
//        $("#txtName").val("");
//        $("#txtLastName").val("");
//        $("#txtPhone").val("");
//        $("#txtPhone").val("");
//        $("#txtCity").val("");
//        $("#ckbDefault").attr("checked", true);

        $("#errorCity").hide();
        $("#errorZip").hide();
        $("#errorAddress").hide();
        $("#errorNmae").hide();
        $("#errorlastName").hide();
        $("#errorPhone").hide();
        $("#errorArea").hide();
       
    }


    //加载国家
    function LoadArea() {
        $.ajax({
            type: "POST",
            url: "/AjaxPages/userAddressAjax.aspx",
            data: "{action:'area',layer:'0'}",
            async: false,
            success: function (obj) {
                var obj = eval(obj);
                $("#selectCountry").empty();
                $("#billing_country").empty();
                //$("#selectCountry").append($("<option/>").text("--select--").attr("value", "-1"));
                $(obj).each(function (index) {
                    var val = obj[index];
                    if (index == 0) {
                        BindProvince(val.id, "");
                        BindBillingProvince(val.id, "");
                    }
                    $("#selectCountry").append($("<option/>").text(val.country).attr("value", val.id));
                    $("#billing_country").append($("<option/>").text(val.country).attr("value", val.id));
                    
                });
            },
            error: function (obj) {
                //alert("失败");
            }
        });

        //二级下拉联动三级下拉
        $("#selectCountry").change(function () {
            $("#selectProvince").empty();
            $("#selectProvince").append($("<option/>").text("--select--").attr("value", "-1"));
            var countryId = $(this).attr("value");
            if (countryId != undefined) {
                $.ajax({
                    type: "POST",
                    url: "/AjaxPages/userAddressAjax.aspx",
                    data: "{action:'area',layer:'1',countryId:'" + countryId + "'}",
                    async: false,
                    success: function (obj) {
                        var obj = eval(obj);
                        $(obj).each(function (index) {
                            var val = obj[index];
                            $("#selectProvince").append($("<option/>").text(val.ProName).attr("value", val.ProID));
                        });
                    },
                    error: function (obj) {
                        //alert("失败");
                    }
                });
            }
        });

        $("#billing_country").change(function () {
            $("#billing_state").empty();
            $("#billing_state").append($("<option/>").text("--select--").attr("value", "-1"));
            var countryId = $(this).attr("value");
            if (countryId != undefined) {
                $.ajax({
                    type: "POST",
                    url: "/AjaxPages/userAddressAjax.aspx",
                    data: "{action:'area',layer:'1',countryId:'" + countryId + "'}",
                    async: false,
                    success: function (obj) {
                        var obj = eval(obj);
                        $(obj).each(function (index) {
                            var val = obj[index];
                            $("#billing_state").append($("<option/>").text(val.ProName).attr("value", val.ProID));
                        });
                    },
                    error: function (obj) {
                        //alert("失败");
                    }
                });
            }
        });
    
    }



}

function BindProvinceByName(countryId, proname,item_id) {
    $("#" + item_id).empty();
    $("#" + item_id).append($("<option/>").text("--select--").attr("value", "-1"));
    if (countryId != undefined) {
        $.ajax({
            type: "POST",
            url: "/AjaxPages/userAddressAjax.aspx",
            data: "{action:'area',layer:'1',countryId:'" + countryId + "'}",
            async: false,
            success: function (obj) {
                var obj = eval(obj);
                $(obj).each(function (index) {
                    var val = obj[index];
                    if (val.ProName == proname) {
                        $("#" + item_id).append($("<option  selected='true' />").text(val.ProName).attr("value", val.ProID));
                    }
                    else {
                        $("#" + item_id).append($("<option/>").text(val.ProName).attr("value", val.ProID));
                    }
                });
            },
            error: function (obj) {
                //alert("失败");
            }
        });
    }
}
//编辑地址时绑定省份
function BindProvince(countryId, proid) {
    $("#selectProvince").empty();
    $("#selectProvince").append($("<option/>").text("--select--").attr("value", "-1"));
    if (countryId != undefined) {
        $.ajax({
            type: "POST",
            url: "/AjaxPages/userAddressAjax.aspx",
            data: "{action:'area',layer:'1',countryId:'" + countryId + "'}",
            async: false,
            success: function (obj) {
                var obj = eval(obj);
                $(obj).each(function (index) {
                    var val = obj[index];
                    if (val.ProID == proid) {
                        $("#selectProvince").append($("<option  selected='true' />").text(val.ProName).attr("value", val.ProID));
                    }
                    else {
                        $("#selectProvince").append($("<option/>").text(val.ProName).attr("value", val.ProID));
                    }
                });
            },
            error: function (obj) {
                //alert("失败");
            }
        });
    }
}

function BindBillingProvince(countryId, proid) {
    $("#billing_state").empty();
    $("#billing_state").append($("<option/>").text("--select--").attr("value", "-1"));
    if (countryId != undefined) {
        $.ajax({
            type: "POST",
            url: "/AjaxPages/userAddressAjax.aspx",
            data: "{action:'area',layer:'1',countryId:'" + countryId + "'}",
            async: false,
            success: function (obj) {
                var obj = eval(obj);
                $(obj).each(function (index) {
                    var val = obj[index];
                    if (val.ProID == proid) {
                        $("#billing_state").append($("<option  selected='true' />").text(val.ProName).attr("value", val.ProID));
                    }
                    else {
                        $("#billing_state").append($("<option/>").text(val.ProName).attr("value", val.ProID));
                    }
                });
            },
            error: function (obj) {
                //alert("失败");
            }
        });
    }
}


