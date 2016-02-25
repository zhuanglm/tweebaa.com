


function FavoritePrd(prdID) { 
    var _data = "{ action:'" + 'add' + "',id:'" + prdID + "'}";
    $.ajax({
        type: "POST",
        url: '../AjaxPages/FavoriteAjax.aspx',
        data: _data,
        dataType: "text",
        success: function (resu) {
            if (resu == "success") {
                alert("This item has been saved to your Favorites. To access, just log in to your account and select 'My Favorites'.");
            }
            else if (resu == "-1") {                
                alert("Please log in!");
            }
            else {
                alert("Failed to favorite");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Failed to favorite");
        }
    });

}


//Favorite    
function FavoritePrdOnOff(prdID, linkFavorite) {

    var isFavorite = false;
    var action = "add";

    if ($(linkFavorite).attr("class") == "schover") {
        isFavorite = true;
        action = "deleteByUserPrd";
    }
    var _data = "{ action:'" + action + "',id:'" + prdID + "'}";

    $.ajax({
        type: "POST",
        url: '../AjaxPages/FavoriteAjax.aspx',
        data: _data,
        dataType: "text",
        success: function (resu) {
            if (resu == "success") {
                if (!isFavorite) {
                    $(linkFavorite).attr("class", "schover");  // change to a solid red heart
                    alert("This item has been saved to your Favorites. To access, just log in to your account and select 'My Favorites'.");
                }
                else {
                    $(linkFavorite).attr("class", "sc");  // change to a empty red heart
                    alert("This item has been removed from your Favorites.");
                }
            }
            else if (resu == "-1") {
                alert("Please log in!");
            }
            else {
                alert("Failed to favorite");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Failed to favorite");
        }
    });

}
