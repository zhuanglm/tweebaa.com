


function FavoritePrd(prdID) { 
    var _data = "{ action:'" + 'add' + "',id:'" + prdID + "'}";
    $.ajax({
        type: "POST",
        url: '/AjaxPages/FavoriteAjax.aspx',
        data: _data,
        dataType: "text",
        success: function (resu) {
            if (resu == "success") {
                ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com","This item has been added to your Favorites.\nTo access, just go to 'My Account' and select 'My Favorites'.");
            }
            else if (resu == "-1") {
                // alert("Please log in!");
                var r = confirm('To add this item to your "favorites", first log-in to your account. ');
                if (r == true) {
                    window.location.href = "/User/login.aspx?op=CollageReview&id=" + sDesignID;
                } else {


                }
            }
            else {
                ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com","Failed to favorite");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com","Failed to favorite");
        }
    });

}


//Favorite    
function FavoritePrdOnOff(prdID, classFavorite) {

    var isFavorite = false;
    var action = "add";

    var classHeart = $(classFavorite).attr("class");

    if (classHeart.indexOf("heart-o") != -1) {
        classHeart = classHeart.replace("heart-o", "heart"); // solid heart class = fa-heart
    }

    // always add and never remove favorite

    //if ($(classFavorite).attr("class").indexOf("added") != -1) {
    //    isFavorite = true;
    //    action = "deleteByUserPrd";
    //}

    var _data = "{ action:'" + action + "',id:'" + prdID + "'}";

    $.ajax({
        type: "POST",
        url: '/AjaxPages/FavoriteAjax.aspx',
        data: _data,
        dataType: "text",
        success: function (resu) {
            if (resu == "success") {
                if (!isFavorite) {
                    $(classFavorite).attr("class", classHeart);  // change to a solid red heart
                    ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com","This item has been added to your Favorites.\nTo access, just go to 'My Account' and select 'My Favorites'.");
                }
                else {
                    $(linkFavorite).attr("class", "sc");  // change to a empty red heart  heart-o  - never comes here
                    ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com","This item has been removed from your Favorites.");
                }
            }
            else if (resu == "-1") {
                ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com","Please login before you add a favorite!");
            }
            else {
                ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com", "Failed to add favorite");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ShowPopupDialogMessage("Earn Play Shop --Tweebaa.com", "Failed to add favorite");
        }
    });

}
