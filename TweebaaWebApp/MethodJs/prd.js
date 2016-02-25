﻿//$.ajaxSetup({ cache: false });


var i = 0;
var piclist = "";
var videoTemp = "";
var inputError = "InputError";
var ajaxError = "AjaxError";
var prdIDSave = "";  // golbal variable to keep the saved product ID to prevent keep saving new product
var isUseTemp = 0;
function send(value) {
    var picjson = {
        'pics': value 
    };   
    XD.sendMessage($E('frm1').contentWindow, picjson);
}

String.prototype.trim = function () {
    return this.replace(/^\s+|\s+$/g, "");
}
String.prototype.ltrim = function () {
    return this.replace(/^\s+/, "");
}
String.prototype.rtrim = function () {
    return this.replace(/\s+$/, "");
}

var callback = function (data) {
    if (data.pics != null) {
        var resu = jsonToStr(data)
        //alert(resu);
        //添加产品图片
        if (resu.indexOf("UploadImg") > 0) {
            i += 1;
            var id = "hidpic" + i;
            $E(id).value = resu;
            piclist += "," + data.pics;
        }
        if (piclist.substring(0, 1) == ",") {
            piclist = piclist.replace(",", "");
        }
        if (resu.toUpperCase().indexOf("PlayVideo") != -1 || resu.toUpperCase().indexOf("HTTP") != -1 || resu.toUpperCase().indexOf("WWW.") != -1 || resu.indexOf("PlayVideo") != -1) {
            $E("hidvideo").value = data.pics;
            //alert($E("hidvideo").value);
        }    

    }
    //删除产品图片
    else if (data.deleid != null) {
        var index = parseInt(data.deleid) + 1;
        var deleID = "hidpic" + index;
        $E(deleID).value = ""; //传递过来的resu是从0开始传过来的索引
        var list = piclist.split(",");
        if (list.length > index - 1) {
            list = list.del(index - 1);
            piclist = list.join(",");
        }
    }
    //移动产品图片
    else if (data.moveid != null) {
        var nowindex = data.moveid.substr(0, 1);
        var newindex = data.moveid.substr(2, 1);
        var list = piclist.split(",");
        if (list.length >= nowindex && list.length > newindex) {
            var valueTemp = list[newindex];
            list[newindex] = list[nowindex];
            list[nowindex] = valueTemp;
            piclist = list.join(",");
        }
    }
    else {
        $E("hidvideo").value = resu;
    }
};
XD.receiveMessage(callback);

var prdCate1List = "";
var prdCate2List = "";
var prdCate3List = "";
var prdCate = "";

function CheckAndGetPrdCate() {
    var i = 0;
    prdCate1List = "";
    prdCate2List = "";
    prdCate3List = "";
    prdCate = "";
    while (true) {
        i += 1;
        var trPrdCateName = "#trPrdCate" + i.toString();
        var prdType1Name = "#prdType" + i.toString() + "1";
        var prdType2Name = "#prdType" + i.toString() + "2";
        var prdType3Name = "#prdType" + i.toString() + "3";

        var htmlPrdCate = $(trPrdCateName).html();
        if (htmlPrdCate == null) break;

        var isVisible = $(trPrdCateName).is(":visible");
        if (isVisible) { // deleted categories are hidden)
            var prdCate1 = $(prdType1Name + " option:selected").val(); //product level 1 category
            var prdCate2 = $(prdType2Name + " option:selected").val(); //product level 2 category
            var prdCate3 = $(prdType3Name + " option:selected").val(); //product level 3 category
            if (prdCate1 == "" || prdCate1 == null || prdCate1 == "-1") {
                alert("Please select the product category！");
                $(prdType1Name).focus();
                return false;
            }
            if (prdCate2 == "" || prdCate2 == null || prdCate2 == "-1") {
                alert("Please select the product category！");
                $(prdType2Name).focus();
                return false;
            }
            if (prdCate3 == "" || prdCate3 == null || prdCate3 == "-1") {
                alert("Please select the product category！");
                $(prdType3Name).focus();
                return false;
            }
            if (prdCate1List != "") prdCate1List += ",";
            if (prdCate2List != "") prdCate2List += ",";
            if (prdCate3List != "") prdCate3List += ",";
            prdCate1List += prdCate1;
            prdCate2List += prdCate2;
            prdCate3List += prdCate3;
            if (i == 1) prdCate = prdCate3; // set old cate as the level 3 category of the first category
        }
    }
    return true;
}


//添加、保存产品（预览发布）
function doAddPrd(action, type) {
    // TYPE = 0: goto review
    // TyPE = 1: back to sumit panel

    var retValue = "";

    var Request = new Object();
    Request = GetRequest();
    var prdID = Request["id"];
    if (prdID == null || prdID == "") {
        if (prdIDSave != "") prdID = prdIDSave;  // use the saved prdID
        else prdID = "";
    }

    var prdName = $("#pro-name").val(); //产品名称   
    if (prdName == "") {
        alert("Please input the name of the product！");
        $("#pro-name").focus();
        return inputError;
    }

    //20150326 JackCao hiden the submit categary 
    // set a default product categary
    //var prdCate = "00000000-0000-0000-0000-000000000000";
    /*
    var prdCate = $("#prdType13  option:selected").val(); //产品类别
    if (prdCate == "" || prdCate == null || prdCate == "-1") {
        alert("Please select the product category！");
        $("#prdType11").focus();
        return;
    }
    */

    if (!CheckAndGetPrdCate()) return;

    // tags  tags are seperated by spaces and comma
    var prdTag = $("#txtTag").val().trim();
    var prdTagSP = "";

    if (prdTag != null && prdTag != "") {

        // replace all comma to space
        prdTagSP = prdTag.replace(/,/g, " ");

        // pading all spaces to one space
        while (prdTagSP.indexOf("  ") != -1) {
            prdTagSP = prdTagSP.replace("  ", " ");
        }

        var arrTag = prdTagSP.split(" ");
        if (arrTag.length > 10) {
            alert("Max 10 tags are allowed!");
            $("#txtTag").focus();
            return inputError;
        }

        for (var i = 0; i < arrTag.length; i++) {
            if (arrTag[i].length <= 0) {
                alert("Please enter valid tag name!");
                $("#txtTag").focus();
                return inputError;
            }
        }
    }

    var prdAdvantage = $("#tese").val(); //卖点特色
    if (prdAdvantage == "") {
        alert("Please describe the products brief selling point characteristics！");
        $("#tese").focus();
        return inputError;
    }
    var prdAnswer = $("#pro-des").val(); //解决的问题
    var prdContent = editor.html();  //产品描述   var txtDesc = editor.html();
    if (prdContent == "" || prdContent == null) {
        alert("Please describe the products detail selling point characteristics！");
        return inputError;
    }

    var prdPrice = $("#txtPrice").val(); //建议零售价
    if (prdPrice == "" || prdPrice == null) {
        alert("Please input the suggested retail price！");
        $("#txtPrice").focus();
        return inputError;
    }
    //add by lcs
    var supplyPrice = $("#txtSupplyPrice").val(); //供货价格
    if (supplyPrice == "" || supplyPrice == null) {
        alert("Please input the supply price！");
        $("#txtSupplyPrice").focus();
        return inputError;
    }

    //check minimum supply price 
    // minimum is $0.01
    if (parseFloat(supplyPrice) < 0.01) {
        alert("Minumum supply price is $0.01\nPlease enter a valid value!");
        $("#txtSupplyPrice").focus();
        return inputError;
    }

    var moq = $("#txtMoq").val(); //最小供货量
    if (moq == "" || moq == null) {
        alert("Please prove the lowest minimum order quantity!");
        $("#txtMoq").focus();
        return inputError;
    }

    var moq = $("#txtMoq").val(); //最小供货量
    if (moq == "" || moq == null) {
        alert("Please prove the lowest minimum order quantity!");
        $("#txtMoq").focus();
        return inputError;
    }
    //check minimum MOQ 
    // minimum is 1
    if (parseInt(moq) < 1) {
        alert("Min Order Qty is 1\nPlease enter a valid value!");
        $("#txtMoq").focus();
        return inputError;
    }


    //是否是供应商
    var isSupplier = $("input[name=rdSupplier]:checked").val();
    //if ($("#rdSupplierYes").checked) { isSupplier = 1; }
    //else { isSupplier = 0; }
    //alert(isSupplier);

    var supplierName = $("#txtSupplierName").val().rtrim();
    var supplierWebsite = $("#txtSupplierWebsite").val().rtrim();
    var supplierPhone = $("#txtSupplierPhone").val().rtrim();
    var supplierEmail = $("#txtSupplierEmail").val().rtrim();
    var supplierAddress = $("#txtSupplierAddress").val().rtrim();

    if (isSupplier == 0) {
        // supplier name is a MUST field
        if (supplierName == "" || supplierName == null) {
            alert("Please provide the supplier name when you are not the product supplier!");
            $("#txtSupplierName").focus();
            return inputError;
        }

        // submitter is not a supplier
        if ((supplierWebsite == "" || supplierWebsite == null) &&
           (supplierPhone == "" || supplierPhone == null) &&
           (supplierEmail == "" || supplierEmail == null) &&
           (supplierAddress == "" || supplierAddress == null)) {
            alert("Please provide AT LEAST one of supplier website, phone number, email and address!");
            $("#txtSupplierWebsite").focus();
            return inputError;
        }

        //validate website
        var regURL = /^[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;
        if (supplierWebsite != "" && supplierWebsite != null) {
            if (!regURL.test(supplierWebsite)) {
                alert("Please input a valid supplier website!");
                $("#txtSupplierWebsite").focus();
                return inputError;
            }
        }

        // validate phone number
        var regPhone = /^\(\d{3}\) ?\d{3}( |-)?\d{4}|^\d{3}( |-)?\d{3}( |-)?\d{4}$/;
        if (supplierPhone != "" && supplierPhone != null) {
            if (!regPhone.test(supplierPhone)) {
                alert("Please input a valid supplier phone number!");
                $("#txtSupplierPhone").focus();
                return inputError;
            }
        }

        // validate email address
        var regEmail = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
        if (supplierEmail != "" && supplierEmail != null) {
            if (!regEmail.test(supplierEmail)) {
                alert("Please input a valid supplier email!");
                $("#txtSupplierEmail").focus();
                return inputError;
            }
        }
    }

    var prdPic = "";

    var strVideo = $("#hidvideo").val();
    var pic1 = $("#hidpic1").val();
    var pic2 = $("#hidpic2").val();
    var pic3 = $("#hidpic3").val();
    var pic4 = $("#hidpic4").val();
    var pic5 = $("#hidpic5").val();

    var prdVideo = "";
    //if (strVideo != "" && strVideo != null) { prdVideo = eval("(" + strVideo + ")").pics; }
    if (strVideo != "" && strVideo != null) { prdVideo = strVideo; }
    if (piclist.substring(0, 1) == ",") {
        piclist = piclist.replace(",", "");
    }
    if (piclist == "") {
        alert("Please upload at least a product thumbnail");
        return inputError;
    }
    if (prdVideo != "") {
        videoTemp = prdVideo; //该值在回传过来是已经加密过的
    }

    //alert(videoTemp);

    var prdCompany = ""; //公司名称
    var prdCompanyIndus = ""; //主营行业
    var prdCompanyWeb = ""; //公司网址
    var prdSupplyWay = ""; //供应方式  
    var _data = "{ action:'" + action
                    + "',id:'" + prdID
                    + "',prdName:'" + escape(prdName) 
                    + "',prdCate:'" + escape(prdCate)
                    + "',prdCate1List:'" + escape(prdCate1List)
                    + "',prdCate2List:'" + escape(prdCate2List)
                    + "',prdCate3List:'" + escape(prdCate3List)
                    + "',prdTag:'" + escape(prdTagSP)
                    + "',prdAdvantage:'" + escape(prdAdvantage)
                    + "',prdAnswer:'" + escape(prdAnswer)
                    + "',prdContent:'" + escape(prdContent)
                    + "',prdPic:'" + escape(piclist)
    //+ "',prdVideo:'" + escape(videoTemp)
                    + "',prdVideo:'" + videoTemp
                    + "',prdPrice:'" + escape(prdPrice)
                    + "',supplyPrice:'" + escape(supplyPrice)
                    + "',prdSupplyPrice:'" + escape("")
                    + "',prdMoq:'" + escape(moq)
                    + "',prdSupplyWay:'" + escape(prdSupplyWay)
                    + "',prdCompany:'" + escape(prdCompany)
                    + "',prdCompanyIndus:'" + escape(prdCompanyIndus)
                    + "',prdCompanyWeb:'" + escape(prdCompanyWeb)
                    + "',isSupplier:'" + escape(isSupplier)
                    + "',supplierName:'" + escape(supplierName)
                    + "',supplierWebsite:'" + escape(supplierWebsite)
                    + "',supplierPhone:'" + escape(supplierPhone)
                    + "',supplierEmail:'" + escape(supplierEmail)
                    + "',supplierAddress:'" + escape(supplierAddress)
                    + "',isUseTemp:'" + escape(isUseTemp)
                    + "'}";

    $.ajax({
        type: "POST",
        url: '../AjaxPages/pwdAjax.aspx',
        async: false,
        data: _data,
        //contentType: "Application/Json", //; charset=utf-8
        dataType: "text",
        success: function (resu) {
            retValue = resu
            return resu;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //alert("status:" + XMLHttpRequest.status);
            //alert("readyState:" + XMLHttpRequest.readyState);
            //alert("textStatus:" + textStatus);

            alert("Failed to publish！");
            return ajaxError;
        }
    });

    return retValue;
}



//添加、保存产品（预览发布）
function addPrd(action, type) {

    var retDoAddPrd = doAddPrd(action, type)

    if (retDoAddPrd == inputError || retDoAddPrd == ajaxError) {
        return;
    }
    else if (retDoAddPrd == "-2") {
        alert("Logged in to release products！");
        return;
    }
        
    if (retDoAddPrd.length > 5) {
        if (action == "submitAdd") {
            fubuFun($("#fabu-ok"), "../index.aspx");
        }
        else {
            window.location.href = "prdReview.aspx?id=" + retDoAddPrd;
        }
        return;
    }
}

//添加、保存产品（保存草稿：去掉必输项验证）
function addPrd2(action, type) {
    var Request = new Object();
    Request = GetRequest();
    var prdID = Request["id"];
    if (prdID == null || prdID == "") {
        if (prdIDSave != "") prdID = prdIDSave;  // use the saved prdID
        else prdID = "";
    }

    var prdName = $("#pro-name").val(); //产品名称   
    if (prdName == "") {
        alert("Please input the name of the product！");
        return;
    }

    // set a default product categary
    //var prdCate = "00000000-0000-0000-0000-000000000000";
    /*
    var prdCate = $("#prdType3  option:selected").val(); //产品类别
    if (prdCate == "" || prdCate == null || prdCate == "-1") {
        alert("Please select the product category！");
        return;
    }
    */

    if (!CheckAndGetPrdCate()) return;

    // tags
    var prdTag = $("#txtTag").val();
    if (prdTag == null) {
        prdTag = "";
    }

    var prdAdvantage = $("#tese").val(); //卖点特色   
    var prdAnswer = $("#pro-des").val(); //解决的问题
    var prdContent = editor.html();  //产品描述 
    var prdPrice = $("#txtPrice").val(); //建议零售价
    if (prdPrice == "" || prdPrice == null) {
       // alert("Please input the suggested retail price！");
       // return;
    }
    var prdPic = "";   
    var strVideo = $("#hidvideo").val();
    var prdVideo = "";   
    if (strVideo != "" && strVideo != null) { prdVideo = strVideo; }
    if (piclist.substring(0, 1) == ",") {
        piclist = piclist.replace(",", "");
    }
    if (piclist == "") {
        //alert("Please upload at least a product thumbnail！");
        //return;
    }
    if (prdVideo != "") {
        videoTemp = prdVideo;
    }   
    var prdCompany = ""; //公司名称
    var prdCompanyIndus = ""; //主营行业
    var prdCompanyWeb = ""; //公司网址
    var prdSupplyWay = ""; //供应方式     
    var supplyPrice = $("#txtSupplyPrice").val(); //供货价格
    var moq = $("#txtMoq").val(); //最小供货量

    //是否是供应商
    var isSupplier = $("input[name=rdSupplier]:checked").val();
    var supplierName = $("#txtSupplierName").val();
    var supplierWebsite = $("#txtSupplierWebsite").val();
    var supplierPhone = $("#txtSupplierPhone").val();
    var supplierEmail = $("#txtSupplierEmail").val();
    var supplierAddress = $("#txtSupplierAddress").val();

    var _data = "{ action:'" + action
                    + "',id:'" + prdID
                    + "',prdName:'" + escape(prdName)
                    + "',prdCate:'" + escape(prdCate)
                    + "',prdCate1List:'" + escape(prdCate1List)
                    + "',prdCate2List:'" + escape(prdCate2List)
                    + "',prdCate3List:'" + escape(prdCate3List)
                    + "',prdTag:'" + escape(prdTag)
                    + "',prdAdvantage:'" + escape(prdAdvantage)
                    + "',prdAnswer:'" + escape(prdAnswer)
                    + "',prdContent:'" + escape(prdContent)
                    + "',prdPic:'" + escape(piclist)
                    + "',prdVideo:'" + videoTemp
                    + "',prdPrice:'" + escape(prdPrice)
                    + "',supplyPrice:'" + escape(supplyPrice)
                    + "',prdSupplyPrice:'" + escape("")
                    + "',prdMoq:'" + escape(moq)
                    + "',prdSupplyWay:'" + escape(prdSupplyWay)
                    + "',prdCompany:'" + escape(prdCompany)
                    + "',prdCompanyIndus:'" + escape(prdCompanyIndus)
                    + "',prdCompanyWeb:'" + escape(prdCompanyWeb)
                    + "',isSupplier:'" + escape(isSupplier)
                    + "',supplierName:'" + escape(supplierName)
                    + "',supplierWebsite:'" + escape(supplierWebsite)
                    + "',supplierPhone:'" + escape(supplierPhone)
                    + "',supplierEmail:'" + escape(supplierEmail)
                    + "',supplierAddress:'" + escape(supplierAddress)
                    + "',isUseTemp:'" + escape(isUseTemp)
                    + "'}";        

    $.ajax({
        type: "POST",
        url: '../AjaxPages/pwdAjax.aspx',
        data: _data,    
        async: false,
        dataType: "text",
        success: function (resu) {  
            if (resu == "-2") {
                alert("Please login！");
                return;
            }
            if (resu.length > 5) {
                //window.location.href = "prdReview.aspx?id=" + resu;
                prdIDSave = resu;  // save the product ID
                alert("Your work has been saved. To access, just log in to your account and you'll find it in the Submissions section.");
                return;
            }
            else if (resu == "error") {
                alert("Save failed！");
                return;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Save failed！");
        }
    });
}

//预览页面提交产品
function submitPrd() {
    var Request = new Object();
    Request = GetRequest();
    var prdID = Request["id"];
    if (prdID == null || prdID == "") {
        if (prdIDSave != "") prdID = prdIDSave;  // use the saved prdID
        else prdID = "";
    }

    if (prdID == null || prdID == "") {
        addPrd("submitAdd", 0);
        return;
    }


    // first check input and save the input
    var retDoAddPrd = doAddPrd("save", 0);
    if (retDoAddPrd == inputError || retDoAddPrd == ajaxError) {
        return;
    } 

    // update the state of the product
    var _data = "{ action:'add',id:'" + prdID + "'}";
    $.ajax({
        type: "POST",
        url: '../AjaxPages/pwdAjax.aspx',
        data: _data,
        //contentType: "Application/Json", //; charset=utf-8
        dataType: "text",
        success: function (msg) {
            if (msg == "success") {
                fubuFun($("#fabu-ok"), "../index.aspx")
            }
            else {
                //alert("Submitted successfully!");
                alert("Failed  to submit");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Failed  to submit");
        }
    });
}

//返回编辑
function backEdit() {
    var Request = new Object();
    Request = GetRequest();
    var prdID = Request["id"];
    if (prdID == null || prdID == "") {

        return;
    }
    window.location.href = "issue.aspx?action=edit&id=" + prdID;
}

//加载产品信息
$(document).ready(function () {
    var Request = new Object();
    Request = GetRequest();
    var action = Request["action"];
    var prdID = Request["id"];
    if (action == "edit" && prdID != null) {
        $.ajax({
            type: "POST",
            url: '../AjaxPages/pwdAjax.aspx',
            data: "{'action':'edit','id':'" + prdID + "'}",
            success: function (resu) {
                var obj = eval("(" + resu + ")"); //转换为json对象                
                var baseInfo = obj.baseInfo; //基本信息                
                var priceList = obj.priceList; //价格信息     
                //var supplyInfor = obj.supplyInfor[0]; //供应商信息    
                $("#pro-name").val(baseInfo.name); //产品名称  
                limitLenth($("#pro-name"), 50, "lnametip");
                $("#pro-name").focus();

                // tag
                if (baseInfo.txtTag != null && baseInfo.txtTag != "") {
                    $("#txtTag").val(baseInfo.txtTag); //产品名称  
                }
                limitLenth($("#txtTag"), 550, "lenTagTip");

                $("#tese").val(baseInfo.txtjj); //卖点特色
                limitLenth($("#tese"), 450, "ltesetip");
                if (baseInfo.txtjj != null && baseInfo.txtjj != "") {
                    $("#tese").siblings('.tishi').hide();
                    $("#tese").focus();
                    $("#pro-name").focus();
                }

                $("#pro-des").val(baseInfo.question); //解决的问题   
                if (baseInfo.question != null && baseInfo.question != "") {
                    $("#pro-des").focus();
                    $("#pro-name").focus();
                }

                editor.html(baseInfo.txtinfo); //产品描述

                //如下写法在谷歌和火狐下无效
                // $("#frm1").contents().find("#pro-web").val(baseInfo.videoUrl); //产品视频  
                // var loadPics = baseInfo.pics.split(','); //加载产品图片
                // $.each(loadPics, function (i, val) {
                // $("#frm1").contents().find("#img" + (i + 1)).attr("src", val.replace("big", "small"));
                // //alert( $("#frm1").contents().find("#img" + (i + 1)).attr("src"));
                //  });
                //如下支持谷歌和火狐及其它浏览器
                var loadPics = baseInfo.pics.split(','); //加载产品图片           
                piclist = baseInfo.pics;
                $.each(loadPics, function (i, val) {
                    send(val);
                    //alert(val);
                });
                videoTemp = baseInfo.videoUrl;
                send(baseInfo.videoUrl); //产品视频 （是加密的）
                $("#txtPrice").val(baseInfo.estimateprice); //建议零售价   
                $("#txtSupplyPrice").val(baseInfo.supplyPrice);
                $("#txtMoq").val(baseInfo.moq); //最小起订量

                // supplier info
                var supplierDisp = "none";
                if (baseInfo.isSupplier == 0) {
                    $("input[name=rdSupplier][value='0']").prop("checked", true);
                    supplierDisp = "table-row";
                    $("#txtSupplierName").val(baseInfo.supplierName);
                    $("#txtSupplierWebsite").val(baseInfo.supplierWebsite);
                    $("#txtSupplierPhone").val(baseInfo.supplierPhone);
                    $("#txtSupplierEmail").val(baseInfo.supplierEmail);
                    $("#txtSupplierAddress").val(baseInfo.supplierAddress);
                }
                else {
                    $("input[name=rdSupplier][value='1']").prop("checked", true);
                    supplierDisp = "none";
                }
                $("#supplierQ2").css("display", supplierDisp);
                $("#supplierQ3").css("display", supplierDisp);
                $("#supplierQ4").css("display", supplierDisp);
                $("#supplierQ5").css("display", supplierDisp);
                $("#supplierQ6").css("display", supplierDisp);
                $("#supplierQ7").css("display", supplierDisp);
                //

                //价格区间不用
                //var estimateprice = priceList.length;
                //$.each(priceList, function (i, val) {
                //var priceID = "#divPrice" + (i + 1);
                //$(priceID).show();
                //var inputs = new Array();
                //inputs = $(priceID).find("input");
                //inputs[0].value = priceList[i].p1;
                //inputs[1].value = priceList[i].p2;
                //inputs[2].value = priceList[i].price;
                //});

                //$("#txtCompany").val(supplyInfor.txtCompanyName); //公司名称  
                //$("#txtCompanyWeb").val(supplyInfor.txtUrl); //公司网址       
                //$("#txtCompanyIndus option[value=" + supplyInfor.txtIndustry + "]").attr("selected", "selected"); //主营行业     
                // $("#txtCompanyIndus").val(supplyInfor.txtIndustry);            
                //var prdSupplyWay = supplyInfor.typelist; //供应方式     
                //var supplyways = prdSupplyWay.split(';');
                // $.each(supplyways, function (i, val) {
                //   $("#supplyway" + val).attr("checked", "checked")
                //  });               
                //BindPrdCate(baseInfo.cateGuid);
                //alert(prdID);

                //
                ShowPrdCate(prdID);


                isUseTemp = baseInfo.isUseTemp;
                if (baseInfo.isUseTemp == 1) {
                    $("#ckbTemp").attr("checked", true);
                }
                else {
                    $("#ckbTemp").attr("checked", false);
                }
                editor.html(baseInfo.txtinfo); //产品描述      

                // $(".selects").selectCss();               
                XD.receiveMessage(callback);
            },
            error: function (obj) {
                //alert("Load failed");
            }
        });

    }
    else {
        LoadPrdCate(1);  // load first category when submitting a new product
    }

});

//加载类别列表
function LoadPrdCate(idx) {

    var prdType1Name = "#prdType" + idx + "1";
    var prdType2Name = "#prdType" + idx + "2";
    var prdType3Name = "#prdType" + idx + "3";


    //要请求的一级机构JSON获取页面
    varurl = "../AjaxPages/prdCateAjax.aspx";

    $(prdType1Name).append($("<option/>").text("--Please select--").attr("value", "-1"));
    $.ajax({
        type: "GET",
        url: "../../AjaxPages/prdCateAjax.aspx",
        data: "layer=0",
        success: function (obj) {
            var obj = eval(obj);
            $(obj).each(function (index) {
                var val = obj[index];
                $(prdType1Name).append($("<option/>").text(val.name).attr("value", val.id));
                if (val.name == "undefined") {
                    $(prdType1Name).val(val.id).attr("selected", "true");
                }
            });

        },
        error: function (obj) {
            //alert("失败");
        }
    });

    //一级下拉联动二级下拉
    $(prdType1Name).change(function () {
        var prdType1 = $(prdType1Name + " option:selected").val();

        // clear type2 and type 3
        $(prdType2Name).empty();
        $(prdType3Name).empty();

        // select "please select"
        if (prdType1 == "-1") {
            return;
        }

        //清除二级下拉列表
        //$("#prdType2").append($("<option/>").text("--Please select--").attr("value", "-1"));
        //要请求的二级下拉JSON获取页面
        $.ajax({
            type: "GET",
            url: "../../AjaxPages/prdCateAjax.aspx",
            //data: "layer=1&&id=" + $(this).attr("value"),
            data: "layer=1&&id=" + $(prdType1Name).attr("value"),
            success: function (obj) {
                var obj = eval(obj);
                if (obj.length > 0) $(prdType2Name).append($("<option/>").text("--Please select--").attr("value", "-1"));
                $(obj).each(function (index) {
                    var val = obj[index];
                    $(prdType2Name).append($("<option/>").text(val.name).attr("value", val.id));
                    if (val.name == "undefined") {
                        $(prdType2Name).val(val.id).attr("selected", "true");
                    }

                });
            },
            error: function (obj) {
                //alert("失败");
            }
        });
    });

    //二级下拉联动三级下拉
    $(prdType2Name).change(function () {

        var prdType2 = $(prdType2Name + " option:selected").val();
        // clear type 3
        $(prdType3Name).empty();
        if (prdType2 == "-1") {
            // select "Please select"
            return;
        }

        //清除三级下拉列表
        //$("#prdType3").append($("<option/>").text("--Please select--").attr("value", "-1"));
        //要请求的三级下拉JSON获取页面
        $.ajax({
            type: "GET",
            url: "../../AjaxPages/prdCateAjax.aspx",
            data: "layer=2&&id=" + $(this).attr("value"),
            success: function (obj) {
                var obj = eval(obj);
                if (obj.length > 0) $(prdType3Name).append($("<option/>").text("--Please select--").attr("value", "-1"));
                $(obj).each(function (index) {
                    var val = obj[index];
                    $(prdType3Name).append($("<option/>").text(val.name).attr("value", val.id));
                    if (val.name == "undefined") {
                        $(prdType3Name).val(val.id).attr("selected", "true");
                    }
                });

            },
            error: function (obj) {
                //alert("失败");
            }
        });

    });
}

//编辑产品时绑定类别列表
function BindPrdCate(prdCateGuid, idx) {

    var prdType1Name = "#prdType" + idx.toString() + "1";
    var prdType2Name = "#prdType" + idx.toString() + "2";
    var prdType3Name = "#prdType" + idx.toString() + "3";

    //要请求的一级机构JSON获取页面
    varurl = "../AjaxPages/prdCateAjax.aspx?id=" + prdCateGuid;
    $(prdType1Name).append($("<option/>").text("--Please select--").attr("value", "-1"));
    $.ajax({
        type: "GET",
        url: "../../AjaxPages/prdCateAjax.aspx",
        data: "id=" + prdCateGuid,
        success: function (resu) {
            if (resu == null || resu == "") {
                return;
            }
            var obj = eval("(" + resu + ")");
            //alert(obj.listModel0); alert(obj.listModel1); alert(obj.listModel2);
            $(obj.listModel0).each(function (index) {
                var val = obj.listModel0[index];
                $(prdType1Name).append($("<option/>").text(val.name).attr("value", val.id));
            });

            if (obj.listModel1.length > 0) $(prdType2Name).append($("<option/>").text("--Please select--").attr("value", "-1"));
            $(obj.listModel1).each(function (index) {
                var val = obj.listModel1[index];
                $(prdType2Name).append($("<option/>").text(val.name).attr("value", val.id));
            });
            if (obj.listModel2.length > 0) $(prdType3Name).append($("<option/>").text("--Please select--").attr("value", "-1"));
            $(obj.listModel2).each(function (index) {
                var val = obj.listModel2[index];
                $( prdType3Name).append($("<option/>").text(val.name).attr("value", val.id));
            });
            // alert(obj.listModel3[0].levelOneGuid); alert(obj.listModel3[0].levelTwoGuid); alert(obj.listModel3[0].levelThreeGuid);
            $(prdType1Name + " option[value=" + obj.listModel3[0].levelOneGuid + "]").attr("selected", "true"); //产品类别0
            $(prdType2Name + " option[value=" + obj.listModel3[0].levelTwoGuid + "]").attr("selected", "true"); //产品类别1
            $(prdType3Name + " option[value=" + obj.listModel3[0].levelThreeGuid + "]").attr("selected", "true"); //产品类别2
            // $("#prdType1").val("居家日用");
        },
        error: function (obj) {
           // alert("失败");
        }
    });

    //一级下拉联动二级下拉
    $(prdType1Name).change(function () {
        // clear type 2 and type 2
        $(prdType2Name).empty();
        $(prdType3Name).empty();
        var prdType1 = $(prdType1Name + " option:selected").val();
        if (prdType1 == "-1") return;
   
        //要请求的二级下拉JSON获取页面
        $.ajax({
            type: "GET",
            url: "../../AjaxPages/prdCateAjax.aspx",
            data: "layer=1&&id=" + $(this).attr("value"),
            success: function (obj) {
                var obj = eval(obj);
                if (obj.length > 0) $(prdType2Name).append($("<option/>").text("--Please select--").attr("value", "-1"));
                $(obj).each(function (index) {
                    var val = obj[index];
                    $(prdType2Name).append($("<option/>").text(val.name).attr("value", val.id));
                });
            },
            error: function (obj) {
                //alert("失败");
            }
        });
    });

    //二级下拉联动三级下拉
    $(prdType2Name).change(function () {
        //清除三级下拉列表
        $(prdType3Name).empty();
        var prdType2 = $("#prdType2  option:selected").val();
        if (prdType2 == "-1") return;
 
         //要请求的三级下拉JSON获取页面
        $.ajax({
            type: "GET",
            url: "../../AjaxPages/prdCateAjax.aspx",
            data: "layer=2&&id=" + $(this).attr("value"),
            success: function (obj) {
                var obj = eval(obj);
                if (obj.length > 0) $(prdType3Name).append($("<option/>").text("--Please select--").attr("value", "-1"));
                $(obj).each(function (index) {
                    var val = obj[index];
                    $(prdType3Name).append($("<option/>").text(val.name).attr("value", val.id));
                });
            },
            error: function (obj) {
                //alert("失败");
            }
        });
    });
}


//接收URL参数
function GetRequest() {
    var url = location.search; //获取url中"?"符后的字串
    var theRequest = new Object();
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        strs = str.split("&");
        for (var i = 0; i < strs.length; i++) {
            theRequest[strs[i].split("=")[0]] = (strs[i].split("=")[1]);
        }
    }
    return theRequest;
}
//隐藏特色文本框提示
function hideTishi() {
    $("#tese").siblings('.tishi').hide();
}

//限制字符个数
function limitLenth (txt,num,tip) {
    var txtid = "#" + txt;
    //var text = $(txtid).val();
    var text = $(txt).val();
    var counter = text.length;

    // the length count the carriage return as one character
    // we need to count each carriage return as two characters
    var i = 0;
    var cntCRLF = 0;
    for (i = 0; i < text.length ; i++) {
        if (text.substring(i, i+1) == "\n" ) cntCRLF ++;
    }
    counter += cntCRLF;
   
    var tipid = "#" + tip;
    $(tipid).attr("color", "Red");
    $(tipid).text(num - counter);    //每次减去字符长度
    if (parseInt(counter) > parseInt(num)) {
        var str = text.substring(0, num-cntCRLF);
        $(txt).val(str); 
        $(tipid).text("0");     
         
    }

};

function UseTemp() {
    if ($("#ckbTemp").attr("checked") == "checked") {
        //alert("选中");
        isUseTemp = 1;
        $("#labDescriptionTemp").attr("word-break", "break-word");
        $("#labDescriptionTemp").html(editor.html());

//        var imgs = $("#labDescriptionTemp img");       
//        imgs.each(function () {
//            $(this).css('max-width','100%');
//            var width = $(this).width();
//            alert(width);
//            if (width > 650) {
//                $(this).css('width', '90%'); 
//            }
//        });

        var features = $("#pro-des").val();
        $("#labFeaturesTemp").html(features);
        var imgArry = new Array();
        imgArry = piclist.split(",");
        var picPath = "https://tweebaa.com/";
        for (var i = 0; i < imgArry.length; i++) {
            var id = "#imgTemp" + (i + 1);
            $(id).attr("src", picPath + imgArry[i].toString().replace("big", "mid2"));
        }
        var tem = $("#divTemp").html();
        editor.html("");
        editor.html(tem);  
    }
    else {
        //alert("不选中");
        isUseTemp = 0;
    }
   
}

//数组操作
Array.prototype.del = function (n) {//n表示第几项，从0开始算起。
    //prototype为对象原型，注意这里为对象增加自定义方法的方法。
    if (n < 0)//如果n<0，则不进行任何操作。
        return this;
    else
        return this.slice(0, n).concat(this.slice(n + 1, this.length));
    /*
　　　concat方法：返回一个新数组，这个新数组是由两个或更多数组组合而成的。
　　　　　　　　　这里就是返回this.slice(0,n)/this.slice(n+1,this.length)
　　 　　　　　　组成的新数组，这中间，刚好少了第n项。
　　　slice方法： 返回一个数组的一段，两个参数，分别指定开始和结束的位置。
　　*/
}


function ShowPrdCate(prdID) {
    // get all cate
    // update the state of the product
    var _data = "{ action:'GetPrdCate',id:'" + prdID + "'}";
    $.ajax({
        type: "POST",
        url: '../AjaxPages/pwdAjax.aspx',
        data: _data,
        async: false,
        dataType: "text",
        success: function (ret) {
            var obj = eval(ret);
            for (var i = 0; i < obj.length; i++) {
                if (i > 0) AddAnotherCategory();
                BindPrdCate(obj[i].cateGuid3, i + 1);  // always bind category by the 3rd level category
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Failed  to submit");
        }
    });
}


function AddAnotherCategory() {
    var idx = 1;
    var trPrdCateName = "";
    while (true) {
        trPrdCateName = "trPrdCate" + idx.toString();
        var htmlTemp = $("#" + trPrdCateName).html();
        if (htmlTemp == null) break;
        idx += 1;
    }

    var htmlPrdCate = '<tr style=" margin-bottom:20px;" id="' + trPrdCateName + '">' +
                                     '<td width="30">' +
                                     '<em class="delete" onclick="DeletePrdCate(' + idx.toString() + ')">' +
                                     '    </em>' +
                                     '</td>' +
                                     '<td>' +
                                     '   <div class="clearfix product-categories" >' +
                                     '       <div class="selectBox pr fl">' +
                                     '           <select name="" class="tag_select" id="prdType' + idx + '1" >' +
                                     '           </select>' +
                                     '       </div>' +
                                     '       <div class="selectBox pr fl">' +
                                     '           <select name="" class="tag_select" id="prdType' + idx + '2">' +
                                     '           </select>' +
                                     '       </div>' +
                                     '       <div class="selectBox pr fl">' +
                                     '           <select name="" class="tag_select" id="prdType' + idx + '3">' +
                                     '           </select>' +
                                     '       </div>' +
                                     '   </div>' +
                                    '</td></tr>';
    $("#tbPrdCate").append(htmlPrdCate);
    return idx;
}


