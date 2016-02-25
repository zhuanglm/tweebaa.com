

function ExtraShippingHandle(proid,sku) {
    var r = confirm("We're sorry,  your shipping address does not qualify for our standard shipping rates.  Would you like to continue?");
    if (r == true) {
        window.location.href = "/Product/ExtraShipping.aspx?proid=" + proid + "&sku="+sku;
    } else {
    window.location.href = '/Product/prdSaleAll.aspx';

    }

}

function ExtraShippingHandleEx(proid, sku, product_name) {
    //Product name: " + products_in_cart[i] + "
    var r = confirm("We're sorry,  your shipping address does not qualify for our standard shipping rates of item:"+product_name+".  Would you like to continue?");
    if (r == true) {
        window.location.href = "/Product/ExtraShipping.aspx?proid=" + proid + "&sku=" + sku;
    } else {
    window.location.href = '/Product/prdSaleAll.aspx';

    }

}