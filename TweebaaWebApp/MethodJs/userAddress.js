var picPath = "https://tweebaa.com/";
$(document).ready(function () {
    $(".saved-address").hide();
    $(".shop-address").hide();
    LoadShopaddress();   
    var guid = $("#hidAddressId").val();    
});


//我的收货地址（购物车改版后仅1个收货地址）
function LoadShopaddress() {
    LoadArea();
    var _data = "{ action:'query'}";
    $.ajax({
        type: "Post",
        url: '../AjaxPages/userAddressAjax.aspx',
        async: false,
        data: _data,
        success: function (resu) {
            if (resu == "-1" || resu == "" || resu == "null" || resu == "[]") {
                //$(".saved-address").hide();               
                $(".shop-address").show();
                $("#btnSave").bind("click", function () { AddAddress() });
                return;
            }
            else if (resu == "0") {
                return;
            }
            else {
                var obj = eval("(" + resu + ")");
                for (var i = 0; i < 1; i++) {
                    var address = obj[i];
                    $("#hidAddressId").val(address.guid);
                    //$("#labName").text(address.username);
                    $("#labName").text(address.username + " " + address.lastName);
                    $("#labAddress").html(address.address + "  " + address.address2 + "<br/>" + address.city + " , " + address.ProName);
                    $("#labCountry").text(address.country);
                    $("#labCountryID").text(address.countyid);
                    $("#labProvinceID").text(address.provinceid);
                    $("#labPhone").text(address.tel);
                    $("#labZip").text(address.zip);
                    if (address.email == null || address.email == "") {
                        $("#labEmTitle").hide();
                    }
                    else {
                        $("#labEmail").text(address.email);
                    }
                    $("#selectCountry option[value=" + address.countyid + "]").attr("selected", "true"); //国家
                    BindProvince(address.countyid, address.provinceid); //加载城市列表
                    //$("#selectProvince option[value=" + obj.provinceid + "]").attr("selected", "true"); //省    

                    $("#txtZip").val(address.zip);
                    $("#txtCity").val(address.city);
                    $("#txtAddress").val(address.address);
                    $("#txtAddress2").val(address.address2);
                    $("#txtName").val(address.username);
                    $("#txtLastName").val(address.lastName);
                    $("#txtPhone").val(address.tel);
                    $("#btnSave").unbind("click");
                    $("#btnSave").bind("click", function () { UpdateAddress(address.guid) });
                    // strSql.Append("select guid,prtguid,provinceid,u.cityid,countyid,zip,address,username,
                    // lastName,phone,tel,isfirst,addtime,p.ProName,city ");
                    if (address.guid != null && address.guid != "") {
                        $(".saved-address").show();
                        $(".shop-address").hide();


                    }
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
        var email = $("#txtEmail").val();
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
        if (email == "") { $("#errorEmail").show(); flag = "false"; } else { $("#errorEmail").hide(); }
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
            url: '../AjaxPages/userAddressAjax.aspx',
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
        var city = $("#txtCity").val(); //城市
        var zip = $("#txtZip").val(); //
        var address = $("#txtAddress").val();
        var address2 = $("#txtAddress2").val();
        var username = $("#txtName").val();
        var lastName = $("#txtLastName").val(); //姓氏
        var phone = $("#txtPhone").val();
        var tel = $("#txtPhone").val();
        var email = $("#txtEmail").val();
        var isfirst = 1;
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
        if (email == "") { $("#errorEmail").show(); flag = "false"; } else { $("#errorEmail").hide(); }
        if (flag == "false") {
            return;
        }
        var _data = "{ action:'add"
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
                    + "',email:'" + email
                    + "',isfirst:'" + isfirst + "'}";
        $.ajax({
            type: "Post",
            url: '../AjaxPages/userAddressAjax.aspx',
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
            url: '../AjaxPages/userAddressAjax.aspx',
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
            url: "../AjaxPages/userAddressAjax.aspx",
            data: "{action:'area',layer:'0'}",
            async: false,
            success: function (obj) {
                var obj = eval(obj);
                $("#selectCountry").empty();
                //$("#selectCountry").append($("<option/>").text("--select--").attr("value", "-1"));
                $(obj).each(function (index) {
                    var val = obj[index];
                    if (index == 0) {
                        BindProvince(val.id, "");
                    }
                    $("#selectCountry").append($("<option/>").text(val.country).attr("value", val.id));
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
            $.ajax({
                type: "POST",
                url: "../AjaxPages/userAddressAjax.aspx",
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
        });
    }
    //编辑地址时绑定省份
    function BindProvince(countryId, proid) {
        $("#selectProvince").empty();
        $("#selectProvince").append($("<option/>").text("--select--").attr("value", "-1"));
        $.ajax({
            type: "POST",
            url: "../AjaxPages/userAddressAjax.aspx",
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

