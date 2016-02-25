function LoadSearchByCate() {

    var prdType1Name = "#prdType1";
    var prdType2Name = "#prdType2";
    var prdType3Name = "#prdType3";

    $(prdType1Name).empty();
    $(prdType2Name).empty();
    $(prdType3Name).empty();
    $(prdType2Name).append($("<option/>").text("-- ALL --").attr("value", "-1"));
    $(prdType3Name).append($("<option/>").text("-- ALL --").attr("value", "-1"));

    //要请求的一级机构JSON获取页面
    varurl = "../AjaxPages/prdCateAjax.aspx";

    $(prdType1Name).append($("<option/>").text("-- ALL --").attr("value", "-1"));
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
        $(prdType2Name).append($("<option/>").text("-- ALL --").attr("value", "-1"));
        $(prdType3Name).append($("<option/>").text("-- ALL --").attr("value", "-1"));

        // search all all
        if (prdType1 == "-1") {
            serch();
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
                $(obj).each(function (index) {
                    var val = obj[index];
                    $(prdType2Name).append($("<option/>").text(val.name).attr("value", val.id));
                    if (val.name == "undefined") {
                        $(prdType2Name).val(val.id).attr("selected", "true");
                    }

                });
                serch();
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
        $(prdType3Name).append($("<option/>").text("-- ALL --").attr("value", "-1"));
        if (prdType2 == "-1") {
            serch();
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
                $(obj).each(function (index) {
                    var val = obj[index];
                    $(prdType3Name).append($("<option/>").text(val.name).attr("value", val.id));
                    if (val.name == "undefined") {
                        $(prdType3Name).val(val.id).attr("selected", "true");
                    }
                });
                serch();
            },
            error: function (obj) {
                //alert("失败");
            }
        });

    });

    // change the 3rd level categorry
    $(prdType3Name).change(function () {
        serch();
    });
}
