//登录
function LogionFuc() {
    var Email = $("#txtEmail").val();
    var Pwd = $("#txtPwd").val();
    var _data = 'Email=' + Email + "&Pwd=" + Pwd ;
    $.ajax({
        type: "POST",
        url: '../../AjaxPages/logionAjax.aspx',
        data: _data,
        success: function (msg) {
            if (msg == "success") {
                var op = $("#redirectTip").val();
                if (op == 'supply') {
                    window.location.href = "../Product/prdReviewStep2.aspx?step=supply";
                } else if (op == 'submit') {
                    window.location.href = "../Product/issue.aspx";
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
                    window.location.href = "../Product/CollageReview.aspx";
                
                } else if (op == "BugsPost") {
                    window.location.href = "/Events/BugsReport/BugsPost.aspx";
                }
                else {
                    window.location.href = "../index.aspx";
                }
                
            }
            else if (msg == "0") {
                alert("Please check your email to activate your account!");
                //$("#labMessage").html("Please check your email to activate your account！");
                //$("#greybox1").show();
                return;
            }
            else if (msg == "error") {
                alert("The user name or password error");
                //$("#labMessage").html("The user name or password error！");
                //$("#greybox1").show();
                return;
            }

        },
        error: function (msg) {
            alert("The user name or password error!");
            //            $("#labMessage").html("用户名或密码错误！");
            //            $("#greybox1").show();
        }
    });
}

function LogionOut() {
    $.ajax({ 
        type: "POST",
        url: '../AjaxPages/logionAjax.aspx',
        data : 'Action=out',
        success: function (msg) {
            window.location.href = "../User/login.aspx";         
        },
        error: function (msg) {
            window.location.href = "../User/login.aspx";         
        }
    });
  }