var picPath = "https://tweebaa.com/";
$(document).ready(function () {
    LoadShopAddress();
    LoadArea();
});


function CheckAddress(address) {
    // mantis #622 Either put a restriction so if system detects "PO Box" or "P.O. Box" in the ship address field it will create Error message
    //...OR put a bold warning that we cannot deliver to a PO Box.
    var addressLowerCase = address.toLowerCase();
    var patt = /(po|p.o.)\s{1,}(box)/g;
    var result = patt.test(addressLowerCase);
    return (!result);
}

//我的收货地址
function LoadShopAddress() {
    $("#tabAddress").empty();
    $("#tabAddress").append('<tr><th width="55">Receiver</th><th width="90">Country/City</th><th width="190">Detail Address</th><th width="70">Zip Code</th><th width="110">Tel</th><th width="70">Action</th><th></th></tr>');
    var _data = "{ action:'query'}";
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
                return;
            }
            else {
                var obj = eval("(" + resu + ")");
                $("#labcount").html(obj.length);
                for (var i = 0; i < obj.length; i++) {
                    var address = obj[i];
                    var html = "";
                    var guid = "'" + address.guid + "'";

                    // country and city
                    var countryCity = address.country + "/";
                    if (address.city != null) countryCity = countryCity + address.city;

                    //detail address
                    var detailAddress = address.address + " " +  address.ProName;


                    if (address.isfirst == 1) {
                        addressId = address.guid;
                        //html = '<li class="on" ><div class="box"><span class="moren">默认地址</span><div class="address-city">' + address.proName + '  ' + address.cityName + ' (' + address.username + '收)</div><div class="address-area">' + address.address + '  (' + address.zip + ')' + address.tel + ' </div><a href="#" class="change-address-btn" onclick="EditAddress(' + guid + ')">编辑</a></div></li>';
                        html = '<tr><td> <span class="text">' + address.username + '</span></td><td><span class="text">' + countryCity + ' </span></td><td><span class="text">' + detailAddress + '</span></td><td><span class="text">' + address.zip + '</span></td><td><span class="text">' + address.tel + '</span></td><td><span class="text "><span class="modify"><a href="javascript:;" onclick="EditAddress(' + guid + ')">Edit</a></span> | <a href="javascript:void(0);" onclick="DeleAddress(' + guid + ')">Delete</a></span></td><td><span  class="text">Default</span></td></tr>';
                    }
                    else {
                        html = '<tr><td> <span class="text">' + address.username + '</span></td><td><span class="text">' + countryCity + ' </span></td><td><span class="text">' + detailAddress + '</span></td><td><span class="text">' + address.zip + '</span></td><td><span class="text">' + address.tel + '</span></td><td><span class="text "><span class="modify"><a href="javascript:;" onclick="EditAddress(' + guid + ')">Edit</a></span> | <a href="javascript:void(0);" onclick="DeleAddress(' + guid + ')">Delete</a></span></td><td><span class="text"><a href="javascript:void(0);" onclick="SetDefault(' + guid + ')" class="default">Default Address</a></span></td></tr>';
                    }
                    $("#tabAddress").append(html);

                }
                return;
            }

        },
        error: function (msg) {
            alert("error");
        }
    });
}
//新增收货地址
var btnFlag = "add";//add:按钮执行添加操作； update:按钮执行更新操作
function AddAddress() {
    var flag = "true";
    var countyid = $("#selectCountry  option:selected").val();
    var provinceid = $("#selectProvince  option:selected").val();
    //var cityid = $("#selectCity  option:selected").val();
    var city = $("#txtCity").val();
    var zip = $("#txtZip").val();
    var address = $("#txtAddress").val();

    var username = $("#txtName").val();
    var phone = $("#txtPhone").val();
    var tel = $("#txtPhone").val();
    var isfirst = 0;
    if ($("#ckbDefault").is(":checked")) {
        isfirst = 1;
    }
    //if (cityid == "-1" || cityid=="") {
    //    $("#errorArea").show();
    //}
    var bAddressOK = CheckAddress(address);
    if (!bAddressOK) {
        alert("We cannot deliver to a PO Box.\nPlease change your delivery address!");
        $("#txtAddress").focus();  // focus does not work here    
    }

    if (city == "") { $("#errorCity").show(); flag = "false"; }
    if (zip == "") { $("#errorZip").show(); flag = "false"; }
    if (address == "" || !bAddressOK) { $("#errorAddress").show(); flag = "false"; }
    if (username == "") { $("#errorNmae").show(); flag = "false"; }
    if (phone == "") { $("#errorPhone").show(); flag = "false"; }
    if (flag == "false") {
        return;
    }       
    var _data = "{ action:'add"
                    + "',countyid:'" + countyid
                    + "',provinceid:'" + provinceid
                    + "',city:'" + city
                    + "',zip:'" + zip
                    + "',address:'" + address
                    + "',username:'" + username
                    + "',phone:'" + phone
                    + "',tel:'" + tel
                    + "',isfirst:'" + isfirst + "'}";
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
                alert("Add failed！");
                return;
            }
            else {
                alert("Add successful！");                
                $(".greybox,.add-new-address-box").hide();
                LoadShopAddress();
                ClearForm();
                return;
            }
        }
    });
}
//更新收货地址
function UpdateAddress(guid) {
    var flag = "true";
    var countyid = $("#selectCountry2  option:selected").val();
    var provinceid = $("#selectProvince2  option:selected").val();
    //var cityid = $("#selectCity2  option:selected").val();
    var city = $("#txtCity2").val();
    var zip = $("#txtZip2").val();
    var address = $("#txtAddress2").val();
    var username = $("#txtName2").val();
    var phone = $("#txtPhone2").val();
    var tel = $("#txtPhone2").val();
    var isfirst = 0;
    if ($("#ckbDefault2").is(":checked")) {
        isfirst = 1;
    }
    else {
        isfirst = 0;
    }
    //if (cityid == "-1" || cityid == "") {
    //    $("#errorArea").show();
   // }
    var bAddressOK = CheckAddress(address);
    if (!bAddressOK) {
        alert("We cannot deliver to a PO Box.\nPlease change your delivery address!");
        $("#txtAddress2").focus();
    }

    if (city == "") { $("#errorCity").show(); flag = "false"; }
    if (zip == "") { $("#errorZip").show(); flag = "false"; }
    if (address == "" || !bAddressOK) { $("#errorAddress").show(); flag = "false"; }
    if (username == "") { $("#errorNmae").show(); flag = "false"; }
    if (phone == "") { $("#errorPhone").show(); flag = "false"; }
    if (flag == "false") {
        return;
    }
    var _data = "{ action:'update"
                    + "',guid:'" + guid
                    + "',countyid:'" + countyid
                    + "',provinceid:'" + provinceid
                    + "',city:'" + city
                    + "',zip:'" + zip
                    + "',address:'" + address
                    + "',username:'" + username
                    + "',phone:'" + phone
                    + "',tel:'" + tel
                    + "',isfirst:'" + isfirst + "'}";
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
                alert("Update failed");
                return;
            }
            else {
                alert("Update successful！");
                $(".greybox,.add-new-address-box").hide();
                LoadShopAddress();
                ClearForm();
                return;
            }
        }
    });
}

function DeleAddress(guid) {
    var _data = "{ action:'delet" + "',guid:'" + guid + "'}";
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
                alert("Delete failed！");
                return;
            }
            else {
                alert("Delete successful！");
                LoadShopAddress();
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
                alert("Set failed！");
                return;
            }
            else {
                alert("Set successful！");             
                LoadShopAddress();
                return;
            }
        }
    });
    
}
//编辑收货地址
function EditAddress(guid) {
    var id = "'" + guid + "'";
    $("#btnSave2").unbind("click");
    $("#btnSave2").bind("click", function () { UpdateAddress(guid) });
    btnFlag = "update";
    var _data = "{ action:'edit" + "',guid:'" + guid + "'}";
    $.ajax({
        type: "Post",
        url: '../AjaxPages/userAddressAjax.aspx',
        async: false,
        data: _data,
        success: function (resu) {
            if (resu == "-1") {
                alert("Please login！");
                return;
            }
            else if (resu != "") {
                var obj = eval("(" + resu + ")")[0];
                LoadProvince2();
                $("#selectCountry2 option[value=" + obj.countryid + "]").attr("selected", "true"); // country
                $("#selectProvince2 option[value=" + obj.provinceid + "]").attr("selected", "true"); //province

                //BindCity(obj.provinceid, obj.cityid); //加载城市列表
                //$("#selectCity option[value=" + obj.cityid + "]").attr("selected", "true"); //市            
                $("#txtCity2").val(obj.city);
                $("#txtZip2").val(obj.zip);
                $("#txtAddress2").val(obj.address);
                $("#txtName2").val(obj.username);
                $("#txtPhone2").val(obj.phone);
                if (obj.isfirst != 1) {
                    $("#ckbDefault2").attr("checked", false);
                }
            }
        }
    });

    $(".greybox,.add-new-address-box").show();
    $(".add-new-address-box").find('h2').text("Edit the address")
    return false;


//    $(".add-new-address-box").find('h2').text("编辑收货地址")
//    $(".greybox,.add-new-address-box").show();
}
//清空添加地址页面
function ClearForm() {
    $("#selectProvince option[value=-1]").attr("selected", "true");
    //$("#selectCity option[value=-1]").attr("selected", "true"); 
    $("#txtCity").val("");
    $("#txtZip").val("");
    $("#txtAddress").val("");
    $("#txtName").val("");
    $("#txtPhone").val("");
    $("#txtPhone").val("");
    $("#ckbDefault").attr("checked", true);
}

//加载类别列表
function LoadArea() {
    $("#selectCountry").empty();
    $("#selectCountry2").empty();

    $("#selectCountry").append($("<option/>").text("--Please Select--").attr("value", "-1"));
    $.ajax({
        type: "POST",
        url: "../AjaxPages/userAddressAjax.aspx",
        data: "{action:'area',layer:'0'}",
        async: false,
        success: function (obj) {
            var obj = eval(obj);
            $("#selectCountry").empty();
            $("#selectCountry2").empty();
            $(obj).each(function (index) {
                var val = obj[index];
                if (val != null) {
                    $("#selectCountry").append($("<option/>").text(val.country).attr("value", val.id));
                    $("#selectCountry2").append($("<option/>").text(val.country).attr("value", val.id));
                }

            });
            LoadProvince();
        },
        error: function (obj) {
            //alert("失败");
        }
    });


    $("#selectCountry").change(function () {
        LoadProvince();
    });

    $("#selectCountry2").change(function () {
        LoadProvince2();
    });

    //二级下拉联动三级下拉
    /*
    $("#selectProvince").change(function () {        
        $("#selectCity").empty();
        $("#selectCity").append($("<option/>").text("--Please Select--").attr("value", "-1"));
        var prtid = $(this).attr("value");     
        $.ajax({
            type: "POST",
            url: "../AjaxPages/userAddressAjax.aspx",
            data: "{action:'area',layer:'2',proid:'" + prtid + "'}",
            success: function (obj) {
                var obj = eval(obj);
                $(obj).each(function (index) {
                    var val = obj[index];
                    if (val!=null) {
                        $("#selectCity").append($("<option/>").text(val.CityName).attr("value", val.CityID));
                    }
                   
                });
            },
            error: function (obj) {
                //alert("失败");
            }
        });

    });
    */
}


function LoadProvince() {
    $("#selectProvince").empty();
    $("#selectProvince").append($("<option/>").text("--Please Select--").attr("value", "-1"));

    var countryId = $("#selectCountry").val();
    $.ajax({
        type: "POST",
        url: "../AjaxPages/userAddressAjax.aspx",
        data: "{action:'area',layer:'1',countryId:'" + countryId + "'}",
        success: function (obj) {
            var obj = eval(obj);
            //$("#selectProvince").empty();
            //$("#selectProvince2").empty();
            $(obj).each(function (index) {
                var val = obj[index];
                if (val != null) {
                    $("#selectProvince").append($("<option/>").text(val.ProName).attr("value", val.ProID));
                }

            });
        },
        error: function (obj) {
            //alert("失败");
        }
    });
}

function LoadProvince2() {
    $("#selectProvince2").empty();

    var countryId = $("#selectCountry2").val();
    $.ajax({
        type: "POST",
        url: "../AjaxPages/userAddressAjax.aspx",
        data: "{action:'area',layer:'1',countryId:'" + countryId + "'}",
        success: function (obj) {
            var obj = eval(obj);
            //$("#selectProvince").empty();
            //$("#selectProvince2").empty();
            $(obj).each(function (index) {
                var val = obj[index];
                if (val != null) {
                    $("#selectProvince2").append($("<option/>").text(val.ProName).attr("value", val.ProID));
                }

            });
        },
        error: function (obj) {
            //alert("失败");
        }
    });
}



//编辑地址时绑定城市
function BindCity(proid,cityid) { 
    $("#selectCity2").empty();
    $("#selectCity2").append($("<option/>").text("--Please Select--").attr("value", "-1"));   
    $.ajax({
        type: "POST",
        url: "../AjaxPages/userAddressAjax.aspx",
        data: "{action:'area',layer:'2',proid:'" + proid + "'}",
        success: function (obj) {
            var obj = eval(obj);
            $(obj).each(function (index) {
                var val = obj[index];
                if (val.CityID == cityid) {
                    $("#selectCity2").append($("<option  selected='true' />").text(val.CityName).attr("value", val.CityID));
                }
                else {
                    $("#selectCity2").append($("<option/>").text(val.CityName).attr("value", val.CityID));
                }
               
            });
        },
        error: function (obj) {
            //alert("失败");
        }
    });
}