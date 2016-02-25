var picPath = "https://tweebaa.com/";


var products_in_cart = ["", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""];
var sku_in_cart = ["", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""];
var products_name_in_cart = ["", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""];
var rulesID_in_cart = ["", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""];


$(document).ready(function () {
    var str = window.location.href;
    if (str.indexOf("index") > 0) {
        $("#h1").addClass("active");
        //$("#floatALink").hide();
    }
    else if (str.indexOf("issue") > 0) {
        $("#h2").addClass("active");
    }
    else if ((str.indexOf("prdReviewAll") > 0 || str.indexOf("submitReview") > 0 || str.indexOf("prdReviewStep") > 0) && str.indexOf("supply") < 0) {
        $("#h3").addClass("active");
    }
    else if (str.indexOf("prdSingleShare") > 0) {
        $("#h4").addClass("active");
    }
    else if (str.indexOf("prdSaleAll") > 0 || str.indexOf("prdPreSale") > 0 || str.indexOf("prdSale") > 0) {
        $("#h5").addClass("active");
    }
    else if (str.indexOf("supply") > 0) {
        $("#h6").addClass("active");
    }
    else if (str.indexOf("College") > 0) {
        $("#h7").addClass("active");
        //$("#floatALink").hide();
    }

    if (str.indexOf("saleBuy") > 0 || str.indexOf("presaleBuy") > 0 || str.indexOf("submitReview") > 0) {
        $("#divS1").show();
       // $("#divS2").show();
    }
});
