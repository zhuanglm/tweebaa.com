//登录
function LogionFuc() {

    Loading(true);
    //return;
    var Email = $("#txtEmail").val();
    var Pwd = $("#txtPwd").val();
    if (Email.indexOf("@") != -1) {
        if (Email.length < 8) {
            Loading(false);
            alert("Please input your E-Mail");
            return;
        }
    } else {
        if (Email.length < 2) {
            Loading(false);
            alert("Please input your E-Mail");
            return;
        }
    }
    if (Pwd.length < 2) {
        Loading(false);
        alert("Please input your password");
        return;
    }
    var _data = 'Email=' + Email + "&Pwd=" + Pwd ;
    $.ajax({
        type: "POST",
        url: '/AjaxPages/logionAjax.aspx',
        data: _data,
        success: function (msg) {
            if (msg == "success") {
                var op = $("#redirectTip").val();
                if (op == 'supply') {
                    window.location.href = "../Product/prdReviewStep2.aspx?step=supply";
                } else if (op == 'submit') {
                    window.location.href = "../Product/SubmitForm.aspx";
                } else if (op == "buy") {
                    var args = $("#redirectArg").val();
                    if (args != "") {
                        window.location.href = "../Product/saleBuy.aspx?id=" + args;
                    }
                } else if (op == "submitreview") {
                    var args = $("#redirectArg").val();
                    if (args != "") {
                        window.location.href = "../Product/submitReview.aspx?id=" + args;
                    }
                } else if (op == "shareSingle") {
                    window.location.href = "../Product/prdSingleShare.aspx";
                } else if (op == "prdSaleAll") {
                    window.location.href = "../Product/prdSaleAll.aspx";
                } else if (op == "prdReviewAll") {
                    window.location.href = "../Product/prdReviewAll.aspx";
                } else if (op == "prdSale") {
                    window.location.href = "../Product/prdSale.aspx";
                } else if (op == "prdPreSale") {
                    window.location.href = "../Product/prdPreSale.aspx";
                } else if (op == "preSaleBuy") {
                    var args = $("#redirectArg").val();
                    window.location.href = "../Product/presaleBuy.aspx?id=" + args;
                } else if (op == "saleBuy") {
                    var args = $("#redirectArg").val();
                    window.location.href = "../Product/saleBuy.aspx?id=" + args;
                } else if (op == "shopOrder") {
                    window.location.href = "../Product/shopOrder.aspx";
                } else if (op == "prdSingleShare") {
                    window.location.href = "../Product/prdSingleShare.aspx";
                } else if (op == "homeSupply") {
                    window.location.href = "../Home/Index.aspx?page=homeSupply";
                } else if (op == "homeCollection") {
                    window.location.href = "../Home/Index.aspx?page=homeCollection";
                } else if (op == "homeProfit") {
                    window.location.href = "../Home/Index.aspx?page=homeProfit";
                } else if (op == "CollageCreate") {
                    window.location.href = "../Product/CollageCreate.aspx";
                } else if (op == "CollageReview") {
                    var args = $("#redirectArg").val();
                    if (args != "") {
                        window.location.href = "../Product/CollageReview.aspx?design_id=" + args;
                    } else {
                        window.location.href = "../Product/CollageReview.aspx";
                    }


                } else if (op == "BugsPost") {
                    window.location.href = "/Events/BugsReport/BugsPost.aspx";
                } else if (op == "tweebot_suggestion") {
                    window.location.href = "/Events/Tweebot/Submit_Suggestion.aspx";
                } else if (op == "tweebot_uploadvideo") {
                    window.location.href = "/Events/Tweebot/Upload_Video.aspx";
                } else if (op == "tweebot_vote") {
                    var args = $("#redirectArg").val();
                    if (args != "") {
                        window.location.href = "/Events/Tweebot/vote_details.aspx?id=" + args;
                    } else {
                        window.location.href = "/Events/Tweebot/index.aspx";
                    }
                } else if (op == "HomeProfit") {
                    window.location.href = "/Home/HomeProfit.aspx";
                } else if (op == "HomeAddress") {
                    window.location.href = "/Home/HomeAddress.aspx";
                } else if (op == "SharePointRedeem") {
                    window.location.href = "/Home/SharePointRedeem.aspx";
                } else if (op == "slot_machine") {
                    window.location.href = "/Games/SlotMachine/index.aspx";
                } else if (op == "HomeShipOrder") {
                    window.location.href = "/Home/HomeShipOrder.aspx";
                } else if (op == "CheckoutShipping") {
                    window.location.href = "/Product/CheckoutShipping.aspx";
                } else if (op == "collageshare") {
                    window.location.href = "/Product/CollageShare.aspx";
                }

                
                else {
                    window.location.href = "../index.aspx";
                }

            }
            else if (msg == "0") {
                alert("Please check your email to activate your account!");
                Loading(false);
                //$("#labMessage").html("Please check your email to activate your account！");
                //$("#greybox1").show();
                return;
            }
            else if (msg == "error") {
                alert("The user name or password error");
                Loading(false);
                //$("#labMessage").html("The user name or password error！");
                //$("#greybox1").show();
                return;
            }

        },
        error: function (msg) {
            alert("The user name or password error!");
            Loading(false);
            //            $("#labMessage").html("用户名或密码错误！");
            //            $("#greybox1").show();
        }
    });
}

function LogionOut() {
    $.ajax({ 
        type: "POST",
        url: '/AjaxPages/logionAjax.aspx',
        data : 'Action=out',
        success: function (msg) {
            window.location.href = "/User/login.aspx";         
        },
        error: function (msg) {
            window.location.href = "/User/login.aspx";         
        }
    });
  }