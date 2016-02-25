var picPath = "https://tweebaa.com/";
$(document).ready(function () {
    LoadShopaddress2();
    LoadArea();
});

//我的收货地址(多个列表)
function LoadShopaddress() {
    $("#ulAddress1").empty();
    $("#ulAddress2").empty();
    var _data = "{ action:'query'}";
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
                return;
            }
            else {
                var obj = eval("(" + resu + ")");
                for (var i = 0; i < obj.length; i++) {
                    var address = obj[i];
                    var html = "";
                    var guid = "'" + address.guid + "'";
                    if (address.isfirst == 1) {
                        addressId = address.guid;
                        //html = '<li class="on" ><div class="box"><span class="moren">Default</span><div class="address-city">' + address.ProName + '  ' + address.city + ' (' + address.username + ')</div><div class="address-area">' + address.address + '  (' + address.zip + ')' + address.tel + ' </div><a href="#" class="change-address-btn" onclick="EditAddress(' + guid + ')">Edit</a></div></li>';
                        html = '<li class="on" ><div class="box"><span class="moren">Default</span><div class="address-city">' + address.ProName + '  ' + address.city + '</div><div class="address-area">' + address.address + '  (' + address.zip + ')' + address.username+" " + address.tel + ' </div><a href="#" class="change-address-btn" onclick="EditAddress(' + guid + ')">Edit</a></div></li>';

                        $("#labReciveAddress").text(address.cityName +"  "+ address.address);
                        $("#labReciveUser").text(address.username +"  "+ address.tel);

                    }
                    else {
                        //html = '<li><div class="box"><span class="set-moren"><a href="#" onclick="SetDefault(' + guid + ')">Set to the default</a></span><div class="address-city">' + address.proName + '  ' + address.cityName + ' (' + address.username + ')</div><div class="address-area">' + address.address + '  (' + address.zip + ')' + address.tel + ' </div><a href="#" class="change-address-btn" onclick="EditAddress(' + guid + ')" >Edit</a></div></li>';
                        html = '<li><div class="box"><span class="set-moren"><a href="#" onclick="SetDefault(' + guid + ')">Set to the default</a></span><div class="address-city">' + address.ProName + '  ' + address.city + '</div><div class="address-area">' + address.address + '  (' + address.zip + ')' + address.username + "  " + address.tel + ' </div><a href="#" class="change-address-btn" onclick="EditAddress(' + guid + ')" >Edit</a></div></li>';

                    }
                    $("#ulAddress1").append(html);
                    var addStr = '<li><label><input type="radio" name="all-address"/><span> ' + address.ProName + '  ' + address.city + ' ' + address.address + ' (' + address.username + ') ' + address.tel + '</span></label><span class="set-moren">Set to the default</span></li>';
                    $("#ulAddress2").append(addStr);
                }

                $(".address-list").find("li").mouseenter(function (event) {
                    $(this).addClass('cur')
                }).mouseleave(function (event) {
                    $(this).removeClass('cur')
                });
                return;
            }

        },
        error: function (msg) {
           // alert("请求失败");
        }
    });
}

//我的收货地址（购物车改版后仅1个收货地址）
function LoadShopaddress2() {
    var _data = "{ action:'query'}";
    $.ajax({
        type: "Post",
        url: '/AjaxPages/userAddressAjax.aspx',
        data: _data,
        success: function (resu) {
            if (resu == "-1") {
                //alert("Please login！");
                return;
            }
            else if (resu == "0") {
                return;
            }
            else {
                var obj = eval("(" + resu + ")");
                for (var i = 0; i < obj.length; i++) {
                    var address = obj[i];

                    //                    var address=' <label id="labName"></label><br />'
                    //                                +' 1800 Edmund ave,<br />'
                    //                                +' toronto, Ontario, M3N2S5<br />'
                    //                                +' <label id="labCountry"></label><br />'
                    //                                +' Email: <label id="labEmail"></label>'
                    //                    $("#pAddress").append(address);


                    $("#labName").text(address.username);
                    $("#labAddress").text(address.address);
                    $("#labCountry").text("国家");
                    $("#labPhone").text(address.tel);
                    $("#labEmail").text(address.username);
                    //                    var html = "";
                    //                    var guid = "'" + address.guid + "'";
                    //                    if (address.isfirst == 1) {
                    //                        addressId = address.guid;
                    //                        html = '<li class="on" ><div class="box"><span class="moren">Default</span><div class="address-city">' + address.ProName + '  ' + address.city + '</div><div class="address-area">' + address.address + '  (' + address.zip + ')' + address.username+" " + address.tel + ' </div><a href="#" class="change-address-btn" onclick="EditAddress(' + guid + ')">Edit</a></div></li>';

                    //                        $("#labReciveAddress").text(address.cityName +"  "+ address.address);
                    //                        $("#labReciveUser").text(address.username +"  "+ address.tel);
                    //                    }   
                }
                return;
            }
        },
        error: function (msg) {
            // alert("请求失败");
        }
    });

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
        var isfirst = 0;
        if ($("#ckbDefault").is(":checked")) {
            isfirst = 1;
        }
        if (provinceid == "" || provinceid == "-1") {
            $("#errorArea").show(); flag = "false";
        }
        else {
            $("#errorArea").hide(); flag = "true";
        }
        if (zip == "") {
            $("#errorZip").show(); flag = "false";
        }
        if (address == "") {
            $("#errorAddress").show(); flag = "false";
        }
        //if (username == "") { $("#errorNmae").show(); flag = "false"; }
        //if (lastName == "") { $("#errorlastName").show(); flag = "false"; }
        if (phone == "") {
            $("#errorPhone").show(); flag = "false";
        }
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
                    + "',isfirst:'" + isfirst + "'}";
        $.ajax({
            type: "Post",
            url: '/AjaxPages/userAddressAjax.aspx',
            data: _data,
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
                    $(".greybox,.add-new-address-box").hide();
                    LoadShopaddress();
                    ClearForm();
                    return;
                }
            }
        });
    }
    //更新收货地址
    function UpdateAddress(guid) {
        var flag = "true";
        var countyid = $("#selectCountry  option:selected").val();
        var provinceid = $("#selectProvince  option:selected").val();
        var cityid = $("#selectCity  option:selected").val();
        var city = $("#txtCity").val(); //城市
        var zip = $("#txtZip").val();
        var address = $("#txtAddress").val();
        var address2 = $("#txtAddress2").val();
        var username = $("#txtName").val();
        var lastName = $("#txtLastName").val(); //姓氏
        var phone = $("#txtPhone").val();
        var tel = $("#txtPhone").val();
        var isfirst = 0;
        if ($("#ckbDefault").is(":checked")) {
            isfirst = 1;
        }
        else {
            isfirst = 0;
        }
        //    if (cityid == "-1" || cityid == "") {
        //        $("#errorArea").show();
        //    }
        if (city == "") { $("#errorCity").show(); flag = "false"; }
        if (zip == "") { $("#errorZip").show(); flag = "false"; }
        if (address == "") { $("#errorAddress").show(); flag = "false"; }
        if (username == "") { $("#errorNmae").show(); flag = "false"; }
        if (lastName == "") { $("#errorlastName").show(); flag = "false"; }
        if (phone == "") { $("#errorPhone").show(); flag = "false"; }
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
            success: function (resu) {
                if (resu == "-1") {
                    alert("Please login！");
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
    //编辑收货地址
    function EditAddress(guid) {
        var id = "'" + guid + "'";
        $("#btnSave").unbind("click")
        $("#btnSave").bind("click", function () { UpdateAddress(guid) });
        btnFlag = "update";
        var _data = "{ action:'edit" + "',guid:'" + guid + "'}";
        $.ajax({
            type: "Post",
            url: '/AjaxPages/userAddressAjax.aspx',
            data: _data,
            success: function (resu) {
                if (resu == "-1") {
                    alert("Please log in！");
                    return;
                }
                else if (resu != "") {
                    var obj = eval("(" + resu + ")")[0];
                    $("#selectCountry option[value=" + obj.countyid + "]").attr("selected", "true"); //国家
                    BindProvince(obj.countyid, obj.provinceid); //加载城市列表
                    //$("#selectProvince option[value=" + obj.provinceid + "]").attr("selected", "true"); //省            
                    $("#txtZip").val(obj.zip);
                    $("#txtCity").val(obj.city);
                    $("#txtAddress").val(obj.address);
                    $("#txtAddress2").val(obj.address2);
                    $("#txtName").val(obj.username);
                    $("#txtLastName").val(obj.lastName);
                    $("#txtPhone").val(obj.phone);
                    if (obj.isfirst != 1) {
                        $("#ckbDefault").attr("checked", false);
                    }
                }
            }
        });
        $(".add-new-address-box").find('h2').text("Edit the delivery address")
        $(".greybox,.add-new-address-box").show();
    }
    //清空添加地址页面
    function ClearForm() {
        $("#selectCountry option[value=-1]").attr("selected", "true");
        $("#selectProvince option[value=-1]").attr("selected", "true");
        $("#txtZip").val("");
        $("#txtAddress").val("");
        $("#txtName").val("");
        $("#txtLastName").val("");
        $("#txtPhone").val("");
        $("#txtPhone").val("");
        $("#txtCity").val("");
        $("#ckbDefault").attr("checked", true);
    }

    //加载国家
    function LoadArea() {
        $.ajax({
            type: "POST",
            url: "/AjaxPages/userAddressAjax.aspx",
            data: "{action:'area',layer:'0'}",
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
                url: "/AjaxPages/userAddressAjax.aspx",
                data: "{action:'area',layer:'1',countryId:'" + countryId + "'}",
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
            url: "/AjaxPages/userAddressAjax.aspx",
            data: "{action:'area',layer:'1',countryId:'" + countryId + "'}",
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