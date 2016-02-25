﻿var prdID = "";

var picPath = "https://tweebaa.com/";
$(document).ready(
//加载产品信息
function LoadPrd() {
    var Request = new Object();
    Request = GetRequest();
    prdID = Request["id"];
    if (prdID == null || prdID == "") {
        return;
    }
    // the prdID has two cases: 
    // normal case:  prdID = product Guid
    // share  case:  prdID = Product Guid + "_" + share Guid

    $.ajax({
        type: "Post",
        url: "../AjaxPages/pwdAjax.aspx",
        data: "{'action':'review','id':'" + prdID + "'}",
        success: function (resu) {
            //var obj = eval("(" + resu + ")");
            //var baseInfo = obj.baseInfo[0];
            var baseInfo = eval("(" + resu + ")");
            $("#labCateTile").html(baseInfo.catename);
            $("#pro-name").html(baseInfo.name); //产品名称 
            //$("#pro-user").html(baseInfo.userName); //发布者    

            //            var _usaTime = "";
            //            if (baseInfo.addtime != null && baseInfo.addtime.length > 0) {
            //                var i = baseInfo.addtime.indexOf("T");
            //                var usaFormat = baseInfo.addtime.substring(0, i);
            //                var usaArray = usaFormat.split('-');
            //                var _year = usaArray[0];
            //                var _month = usaArray[1];
            //                var _day = usaArray[2];
            //                _usaTime = _month + "/" + _day + "/" + _year;
            //            }
            //baseInfo.addtime.replace("T", " ")
            //$("#pro-time").html(_usaTime); //发布时间

            $("#pro-jl").html(baseInfo.txtjj); //卖点特色

            $("#pro-question").html(baseInfo.question); //解决的问题   
            if (baseInfo.question == null || baseInfo.question == "") {
                $("#div-question").hide();
            }
            var url = location.href;
            //if (url.indexOf("preSaleBuy") > 0 || url.indexOf("saleBuy") > 0) {
            // do not change price to test-sale price if the the product is final-sale
            if (url.indexOf("presaleBuy") > 0 || url.indexOf("preSaleBuy") > 0) {
                //alert(baseInfo.estimateprice + " " + baseInfo.saleprice );
                $("#pro-price").html(baseInfo.saleprice.toFixed(2)); //售价 
                if ($("#pro-price2") != null) {
                    $("#pro-price2").html(baseInfo.estimateprice.toFixed(2)); //建议零售价（市场价）
                }
                document.title = baseInfo.name + " " + baseInfo.txtTag + " Limited offer ! PreOrder now at Tweebaa";
            }
            else {
                document.title = baseInfo.name + " " + baseInfo.txtTag + " Limited offer ! Order now at Tweebaa";
            }

            if (baseInfo.estimateprice != baseInfo.saleprice) $("#divMSRP").show();

            if ($("#labendDay") != null) {
                var presaleendday = baseInfo.presaleendday;
                if (presaleendday == null) {
                    presaleendday = 0;
                }
                var presaleLeftDayHtml = "";
                //$("#labendDay").text(baseInfo.presaleendday);
                // $("#labendDay").html('<strong><label >5</label> days left </strong>');
                if (presaleendday < 0) presaleLeftDayHtml = "<strong><label></label></strong> Time over";
                else presaleLeftDayHtml = "Days left: <strong><label>" + presaleendday + " </label></strong>";
                $("#labendDay").html(presaleLeftDayHtml);
            }

            var saleCount = 0;
            if ($("#labSaleCount") != null) {
                var saleCount = baseInfo.saleCount;
                if (saleCount == null) {
                    saleCount = 0;
                }
                $("#labSaleCount").text(baseInfo.saleCount); //预售个数
            }
            //lcs
            var _presaleforward = baseInfo.presaleForward; //预售目标
            if (_presaleforward != null) {
                $("#labPreSaleForward").text(_presaleforward);
            } else {
                _presaleforward = 0;
                $("#labPreSaleForward").text(_presaleforward);
            }

            var _pressaleLeftUnit = _presaleforward - saleCount
            $("#labPreSaleLeftUnit").text(_pressaleLeftUnit);

            //控制进度条
            if (_presaleforward != null && _presaleforward != 0) {
                var per = (saleCount / _presaleforward) * 100;
                var perStr = per + "%";
                $("#passagerbar").css("width", perStr);
            } else {
                $("#passagerbar").css("width", "1%");
            }

            var pics = new Array(); //定义一数组 
            pics = baseInfo.pics.split(","); ////产品图片        
            $("#midimg").attr("src", picPath + pics[0].replace("big", "mid"));
            $("#bigShowImg").attr("src", picPath + pics[0]);
            for (i = 0; i < pics.length; i++) {
                $("#imgSmall" + (i + 1)).attr("src", picPath + pics[i].replace("big", "small"));
            }
            for (var j = 5; j >= pics.length + 1; j--) {
                $("#imgSmall" + j).hide();
            }
            // do not need to load reviewInfo here after adding pagenition 20150411 Jack Cao 
            //LoadReviewInfo();      //加载产品的评审信息

            // set full name of picture
            var picFullName = picPath + pics[0];

            $("#htrfShare").bind("click", function () {

                // there are two pages's share come to here test-sale and final-sale  
                var pageUrl = window.location.href;
                var sharePage = "presaleBuy.aspx";
                if (pageUrl.indexOf("/saleBuy.aspx") != -1) sharePage = "saleBuy.aspx";
                SharePrd(prdID, baseInfo.name, picFullName, sharePage, baseInfo.txtjj);
            })
            $("#htrfMySubplay").bind("click", function () {
                window.location.href = "../Home/homeSupply.aspx?id=" + baseInfo.userID;
            })

            //$("#hrefShare1").bind("click", function () {
            //    SharePrd(prdID, baseInfo.name, pics[0]);
            //})
            if (baseInfo.videoEmbed != null && baseInfo.videoEmbed != "") {
                // added by jack cao for embed video like youtube
                $("#CuPlayer").html(baseInfo.videoEmbed); 
            }
            else if (baseInfo.videoUrl != null && baseInfo.videoUrl != "") {
                LoadVideo(picPath + baseInfo.videoUrl);
            }
            else {
                $("#CuPlayer").hide();
            }
            var strtxt = decodeURIComponent(baseInfo.txtinfo);
            strtxt = strtxt.replace(/\+/g, " ");
            $("#pro-info").html(strtxt);


        },
        error: function (obj) {
            alert("Load failed");
        }
    });
}
);

//加载视频
function LoadVideo(videoPath) {
    var so = new SWFObject("../Css/PlayerLite.swf", "CuPlayerV4", "560", "410", "9", "#000000");
    so.addParam("allowfullscreen", "true");
    so.addParam("allowscriptaccess", "always");
    so.addParam("wmode", "opaque");
    so.addParam("quality", "high");
    so.addParam("salign", "lt");
    so.addVariable("videoDefault", videoPath); //视频文件地址
    so.addVariable("autoHide", "true");
    so.addVariable("hideType", "fade");
    so.addVariable("autoStart", "false");
    so.addVariable("holdImage", "start.jpg");
    so.addVariable("startVol", "60");
    so.addVariable("hideDelay", "60");
    so.addVariable("bgAlpha", "75");
    so.write("CuPlayer");


}



//加载评审信息
function LoadReviewInfo(startIdx, endIdx) {
   
    var ul = $(".pinglun-list");
    $.ajax({
        type: "Post",
        url: "../AjaxPages/prdReviewAjax.aspx",
        data: "{'action':'query','id':'" + prdID + "','startIndex':'" + startIdx + "','endIndex':'" + endIdx + "'}",
        success: function (resu) {
            if (resu == "") {
                return;
            }
            var obj = eval("(" + resu + ")");   
            for (var i = 0; i < obj.length; i++) {
                //var t = ul.childNodes.length;
                var li = document.createElement("li");
                var strHtml = "<span class='fr time'>" + obj[i].edttime.replace("T", " ") + "</span><span class='fr people'><a href='#' class='vip-lv vip-lv5'>" + obj[i].username + "kk</a></span><p class='fl'>" + obj[i].cmdtxt + "</p>";
                li.innerHTML = strHtml;
                ul.append(li);
            }
        },
        error: function (resu) {

        }
    });
}

function DoFavoritePrdOnOff(linkFavorite) {
    FavoritePrdOnOff(prdID, linkFavorite);
}


//添加到购物车按钮事件
function AddShopCart() {
    var quantity = $("#txtQuantity").val();
    var ruleid = GetSelectedRuleId();
    var _data = "{ action:'add"
                    + "',prdguid:'" + prdID
                    + "',quantity:'" + quantity
                    + "',ruleid:'" + ruleid
                    + "'}";
    $.ajax({
        type: "POST",
        url: '../AjaxPages/shopCartAjax.aspx',
        data: _data,
        success: function (msg) {
            if (msg == "-1") {
                alert("Please login first！");
                var proid = $("#hid_proid").val();
                var urlStr = window.location.href;
                //alert(urlStr);
                if (urlStr.toLowerCase().indexOf('presalebuy'.toLowerCase()) != -1) {
                    window.location.href = "../User/login.aspx?op=preSaleBuy&id=" + proid;
                }
                else if (urlStr.toLowerCase().indexOf('saleBuy'.toLowerCase()) != -1) {
                    window.location.href = "../User/login.aspx?op=buy&id=" + proid;
                }
                return;
            }
            else if (msg == "-2") {
                alert("Please select a product attribute！");
                return;
            }
            else if (msg == "1") {
                //alert("Added successfully！");
                window.location.href = "../Product/shopCart.aspx";
                return;
            }
            else if (msg == "0") {
                alert("Failed to add");
                return;
            }
        },
        error: function (msg) {
            alert("Failed to add");
        }
    });
}
//立即购买按钮事件
function AddShopCartBuyNow() {
    var quantity = $("#txtQuantity").val();
    var ruleid = GetSelectedRuleId();
    var _data = "{ action:'buynow"
                    + "',prdguid:'" + prdID
                    + "',quantity:'" + quantity
                    + "',ruleid:'" + ruleid
                    + "'}";
    $.ajax({
        type: "POST",
        url: '../AjaxPages/shopCartAjax.aspx',
        data: _data,
        success: function (cartguid) {
            if (cartguid == "-1") {
                alert("Please login first！");
                var proid = $("#hid_proid").val();
                window.location.href = "../User/login.aspx?op=buy&id="+proid;   //http://localhost:28156/Product/saleBuy.aspx?id=beb116b6-dca7-433a-b784-6584bec70f1b
                return;
            }
            if (cartguid == "-2") {
                alert("Please select a product attribute！");
                return;
            }
            if (cartguid != "") {
                cartguid = "'" + cartguid + "'";
                window.location.href = "shopOrder.aspx?cartids=" + escape(cartguid);
                return;
            }
            else {
                alert("The system is busy, please try again later！");
                return;
            }

        },
        error: function (msg) {
            alert("Failed to add");
        }
    });
}

function check1() {
    //alert("111");
    //$('#ckb4').removeAttr('checked');
    $("#ckb2 input").removeAttr("checked");

}

//分享动作
function SharePrd(id, name, img, page, desc) {

    //alert(page);
    
    if (SetShareLink(id, name, img, page, desc, 0.0) == true) {
        $("#share-tck2").parents(".greybox").show();
        $("#share-tck2").animate({ top: "2%" }, 300);
    }
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

//---------------------------------------------------------------------

//改变规格事件
function _ChangeRule(obj) {
   $("#txtQuantity").val("1");
   $(obj).parent().find("span").attr("class","jsclick");
   $(obj).attr("class","jsclick on");
   //获取规格的id集合以逗号分隔
   var ruleids=$(obj).attr("ruleids").split(',');
   //该规格的总库存
   var totalStorage=0;
   
   if (ruleids.length > 0) {
       $("#proColorArea").html("");
       for (var i = 0; i < ruleids.length; i++) {
           if (colorArea != null && colorArea.length > 0) {
               var colorJson = eval(colorArea);
               //选定颜色
               if (colorJson.length > 0) {
                   var colorHtml = "";
                   for (var c = 0; c < colorJson.length; c++) {
                       var ruleid = colorJson[c].ruleid; //获取规格ID
                       var color = colorJson[c].color;  //获取规格颜色
                       if (ruleids[i] == ruleid) {
                           if (color=="#fff") {
                               colorHtml += "<div ruleid=" + ruleid + " onclick=\"_ChangeColor(this)\" class=\"selectColor\"><div style=\" background:" + color + ";border:solid 1px gray; \"></div></div>";
                           }
                           else {
                               colorHtml += "<div ruleid=" + ruleid + " onclick=\"_ChangeColor(this)\" class=\"selectColor\"><div style=\" background:" + color + ";\"></div></div>";
                           }
                           
                           $(colorHtml).appendTo($("#proColorArea"));
                       }
                   }
               }
           }
		 //默认选中第一个颜色
		 var firstColor=$("#proColorArea").find("div").eq(0);
		 firstColor.css("border","1px").css("border-color","red").css("border-style","solid");
		 $("#proColorArea").attr("selectedRuleid", firstColor.attr("ruleid"));

           //获取这个规格的最小价格
		 if (priceMin.length > 0) {
		     var jsonPriceMin=eval(priceMin);
		     for (var item = 0; item < jsonPriceMin.length; item++) {
		         //pro-price
		         var ruleid = jsonPriceMin[item].ruleid;
		         var price = jsonPriceMin[item].minprice;
		         if (ruleid == firstColor.attr("ruleid")) {
		             $("#pro-price").html(price);
		         }
		     }
		 }
		 
           //计算该规格的总库存
		 if (storage != null && storage.length > 0) {
		     var storagJson = eval(storage);
		     if (storagJson.length > 0) {
		         for (var s = 0; s < storagJson.length; s++) {
		             var ruleid = storagJson[s].ruleid;
		             var storagenum = storagJson[s].storage;
		             if (ruleids[i] == ruleid) {
		                 totalStorage += parseInt(storagenum);
		             }
		         }
		     }
		 }
		 
		 
	  }
   }
   $("#storenumSpan").html("").html(totalStorage); //给库存赋值
   
}

//页面加载时默认选中第一个规格的第一个颜色
$(function(){
   var firstColor=$("#proColorArea").find("div").eq(0);
   firstColor.css("border","1px").css("border-color","red").css("border-style","solid");
   $("#proColorArea").attr("selectedRuleid", firstColor.attr("ruleid"));
    //获取这个规格的最小价格
   if (priceMin.length > 0) {
       var jsonPriceMin = eval(priceMin);
       for (var item = 0; item < jsonPriceMin.length; item++) {
           //pro-price
           var ruleid = jsonPriceMin[item].ruleid;
           var price = jsonPriceMin[item].minprice;
           if (ruleid == firstColor.attr("ruleid")) {
               $("#pro-price").html(price);
           }
       }
   }

})

//改变颜色事件
function _ChangeColor(obj) {
  $("#txtQuantity").val("1");
  $("#proColorArea").find("div[class='selectColor']").css("border","0px");
  $(obj).css("border","1px").css("border-color","red").css("border-style","solid");
  $("#proColorArea").attr("selectedRuleid",$(obj).attr("ruleid"));
  var ruleid = $(obj).attr("ruleid");

    //获取这个规格的最小价格
  if (priceMin.length > 0) {
      var jsonPriceMin = eval(priceMin);
      for (var item = 0; item < jsonPriceMin.length; item++) {
          //pro-price
          var sruleid = jsonPriceMin[item].ruleid;
          var price = jsonPriceMin[item].minprice;
          if (sruleid == ruleid) {
              $("#pro-price").html(price);
          }
      }
  }

  if (storage != null && storage.length > 0) {
      var storagJson = eval(storage);
      if (storagJson.length > 0) {
          for (var s = 0; s < storagJson.length; s++) {
              if (ruleid == storagJson[s].ruleid) {
                  //alert(storagJson[s].storage);
                  $("#storenumSpan").html("").html(storagJson[s].storage); //给库存赋值
                  break;
              }
          }
      }
  }
}

//加减微调事件
function changePrice(count){
   //获取当前选中的ruleid
   var selectedRuleid=$("#proColorArea").attr("selectedRuleid");
   var _count=parseFloat(count);
   if (selectedRuleid.length > 0) {
       if (priceArea != null && priceArea.length > 0) {
           var priceAreaJson = eval(priceArea);
           if (priceAreaJson.length > 0) {
               for (var p = 0; p < priceAreaJson.length; p++) {
                   var ruleid = priceAreaJson[p].ruleid;
                   var from = parseFloat(priceAreaJson[p].from);
                   var to = parseFloat(priceAreaJson[p].to);
                   var price = priceAreaJson[p].price;
                   if (ruleid == selectedRuleid) {
                       if (_count >= from && _count <= to) {
                           $("#pro-price").html(price);
                       }
                   }
               }
           }
       }
   }
}

//获取选中颜色的规格ID
function GetSelectedRuleId() {
    var ruleid = $("#proColorArea").attr("selectedruleid");
    if (ruleid == null || ruleid.length == 0) {
        //alert("Please select a product color");
        return "";
    }
    else {
        return ruleid;
    }
}

//以上是购买页面的JS

//以下是预售页面的JS
//改变规格事件
function _PreChangeRule(obj) {
    $(obj).parent().find("span").attr("class", "jsclick");
    $(obj).attr("class", "jsclick on");
    //获取规格的id集合以逗号分隔
    var ruleids = $(obj).attr("ruleids").split(',');
    //该规格的总库存
    var totalStorage = 0;

    if (ruleids.length > 0) {
        $("#proColorArea").html("");
        for (var i = 0; i < ruleids.length; i++) {
            if (colorArea != null && colorArea.length > 0) {
                var colorJson = eval(colorArea);
                //选定颜色
                if (colorJson.length > 0) {
                    var colorHtml = "";
                    for (var c = 0; c < colorJson.length; c++) {
                        var ruleid = colorJson[c].ruleid; //获取规格ID
                        var color = colorJson[c].color;  //获取规格颜色
                        if (ruleids[i] == ruleid) {
                            if (color=="#fff") {
                                colorHtml += "<div ruleid=" + ruleid + " onclick=\"_PreChangeColor(this)\" class=\"selectColor\"><div style=\" background:" + color + ";border:solid 1px gray;\"></div></div>";
                            }
                            else {
                                colorHtml += "<div ruleid=" + ruleid + " onclick=\"_PreChangeColor(this)\" class=\"selectColor\"><div style=\" background:" + color + ";\"></div></div>";
                            }
                            
                            $(colorHtml).appendTo($("#proColorArea"));
                        }
                    }
                }
            }
            //默认选中第一个颜色
            var firstColor = $("#proColorArea").find("div").eq(0);
            firstColor.css("border", "1px").css("border-color", "red").css("border-style", "solid");
            $("#proColorArea").attr("selectedRuleid", firstColor.attr("ruleid"));

        }
    }
    
}

function _PreChangeColor(obj) {
    $("#proColorArea").find("div[class='selectColor']").css("border", "0px");
    $(obj).css("border", "1px").css("border-color", "red").css("border-style", "solid");
    $("#proColorArea").attr("selectedRuleid", $(obj).attr("ruleid"));
    //var ruleid = $(obj).attr("ruleid");

}


