﻿
//Add by Long to get the catehgory tree
function LoadCategoryTree() {
    $.ajax({
        type: "GET",
        url: "/AjaxPages/prdCateAjax.aspx",
        data: "layer=-1",
        success: function (xml) {
            /*
            var obj = eval(obj);
            $(obj).each(function (index) {
            var val = obj[index];
            $(prdType1Name).append($("<option/>").text(val.name).attr("value", val.id));
            if (val.name == "undefined") {
            $(prdType1Name).val(val.id).attr("selected", "true");
            }
            });
            */
            //
            //console.log("xml=" + xml);
            var shtml = '<ul class="nav nav-pills nav-stacked tree">';
            var first1 = 0; var first2 = 0; var first3 = 0;
            $(xml).find('category_1').each(function () {

                var sID = $(this).attr('category_guid');
                var sCount = $(this).attr('category_count');
                var sTitle = $(this).attr("category_name");

                // Jack Cao 2015-10-23
                // do not open first the category by default 
                // if you want, just change first1 == -1 to first1 == 0 
                if (first1 == -1) {
                    // shtml = shtml + '<li class="active dropdown-tree open-tree"><a class="dropdown-tree-a"> <span class="badge pull-right">' + sCount + '</span>' + sTitle + '</a>';
                    //shtml = shtml + '<li class="active dropdown-tree open-tree"><a class="dropdown-tree-a" href="javascript:void(0);" onclick="DoSearchByCategory(\'' + sID + '\',1)">' + sTitle + '</a>';
                    shtml = shtml + '<li class="active dropdown-tree open-tree"><a class="dropdown-tree-a" href="/Product/Category.aspx/' + ReplaceSpecial(sTitle) + '/' + sID + '" >' + sTitle + '</a>';
                    shtml = shtml + '<ul class="category-level-2 dropdown-menu-tree">';
                } else {
                    // shtml = shtml + '<li class="dropdown-tree"><a class="dropdown-tree-a"> <span class="badge pull-right">' + sCount + '</span>' + sTitle + '</a>';
                    //modify by Long shtml = shtml + '<li class="dropdown-tree"><a class="dropdown-tree-a" href="javascript:void(0);" onclick="DoSearchByCategory(\'' + sID + '\',1)" >' + sTitle + '</a>';
                    shtml = shtml + '<li class="dropdown-tree"><a class="dropdown-tree-a" href="javascript:void(0);" onclick="DoSearchByCategory(\'' + sID + '\',1)" >' + sTitle + '</a>';
                    //shtml = shtml + '<li class="dropdown-tree"><a class="dropdown-tree-a" href="/Product/Category.aspx/' + ReplaceSpecial(sTitle) + '/' + sID + '" >' + sTitle + '</a>';
                    //shtml = shtml + '<li class="dropdown-tree"><a class="dropdown-tree-a" href="javascript:void(0);" >' + sTitle + '</a>';
                    shtml = shtml + '<ul class="category-level-2  dropdown-menu-tree">';
                }
                first1++;
                // console.log("category_1=" + sTitle);
                //二级目录
                $(this).find('category_2').each(function () {

                    var sID_2 = $(this).attr('category_guid');
                    //var sCount_2 = $(this).attr('category_count');
                    var sTitle_2 = $(this).attr("category_name");

                    // Jack Cao 2015-10-23
                    // do not open first the category by default
                    // if you want, just change first2 == -1 to first2 == 0 
                    if (first2 == -1) {
                        shtml = shtml + '<li class="dropdown-tree open-tree"><a class="dropdown-tree-a" href="javascript:void(0);" onclick="DoSearchByCategory(\'' + sID_2 + '\',2)">' + sTitle_2 + '</a>';
                        shtml = shtml + '<ul class="category-level-2 dropdown-menu-tree">';
                    } else {
                        shtml = shtml + '<li class="dropdown-tree"><a class="dropdown-tree-a" href="javascript:void(0);" onclick="DoSearchByCategory(\'' + sID_2 + '\',2)">' + sTitle_2 + '</a>';
                        //shtml = shtml + '<li class="dropdown-tree"><a class="dropdown-tree-a" href="javascript:void(0);" >' + sTitle_2 + '</a>';
                        shtml = shtml + '<ul class="category-level-2  dropdown-menu-tree">';
                    }
                    first2++;
                    // console.log("category_2=" + sTitle_2);
                    //三级目录
                    $(this).find('category_3').each(function () {

                        var sID_3 = $(this).attr('category_guid');
                        //var sCount_2 = $(this).attr('category_count');
                        var sTitle_3 = $(this).attr("category_name");
                        //console.log("category_3=" + sTitle_3);
                        shtml = shtml + '<li ><a href="javascript:void(0);" onclick="DoSearchByCategory(\'' + sID_3 + '\',3)">' + sTitle_3 + '</a></li>';
                        /*
                        var seoURL = '/Product/Category.aspx/';
                        seoURL = seoURL + ReplaceSpecial(sTitle);
                        seoURL = seoURL + '/';
                        seoURL = seoURL + ReplaceSpecial(sTitle_2);
                        seoURL = seoURL + '/';
                        seoURL = seoURL + ReplaceSpecial(sTitle_3);
                        seoURL = seoURL + '/';
                        seoURL = seoURL + sID;
                        seoURL = seoURL + '/';
                        seoURL = seoURL + sID_2;
                        seoURL = seoURL + '/';
                        seoURL = seoURL + sID_3;
                        shtml = shtml + '<li><a href="' + seoURL + '">' + sTitle_3 + '</a></li>';
                        */
                    });
                    //三级目录 EOF
                    shtml = shtml + '</ul></li>';


                });
                shtml = shtml + '</ul></li>';
                //二级目录 EOF  
            });

            shtml = shtml + '</ul>';


            $("#category_tree").html(shtml);

            $(".dropdown-tree-a").click(function () { //use a class, since your ID gets mangled
                $(this).parent('.dropdown-tree').toggleClass("open-tree active"); //add the class to the clicked element
            });

            //console.log("1=" + sID + " 2=" + sCount + " 3=" + sTitle);


            // html += '<li><a href="#" onclick="LoadDesign(' + sID + ',0)"><img width="153" src="' + picDesignImgPath + sImage + '" alt=""></a></li>';



        },
        error: function (obj) {
            //alert("失败");
        }
    });

}

function LoadCategoryTreeNodeOpen(sCateID1, sCateID2, sCateID3) {
    $.ajax({
        type: "GET",
        url: "/AjaxPages/prdCateAjax.aspx",
        data: "layer=-1",
        success: function (xml) {
            //console.log("xml=" + xml);
            sCateID1 = sCateID1.toLowerCase();
            sCateID2 = sCateID2.toLowerCase();
            sCateID3 = sCateID3.toLowerCase();

            var shtml = '<ul class="nav nav-pills nav-stacked tree">';
            var first1 = 0; var first2 = 0; var first3 = 0;
            $(xml).find('category_1').each(function () {

                var sID = $(this).attr('category_guid');
                var sCount = $(this).attr('category_count');
                var sTitle = $(this).attr("category_name");

                // Jack Cao 2015-10-23
                // do not open first the category by default 
                // if you want, just change first1 == -1 to first1 == 0 
                if (sID === sCateID1) {
                    shtml = shtml + '<li class="active dropdown-tree open-tree"><a class="dropdown-tree-a" href="javascript:void(0);" onclick="DoSearchByCategory(\'' + sID + '\',1)" >' + sTitle + '</a>';
                    shtml = shtml + '<ul class="category-level-2 dropdown-menu-tree">';
                } else {
                    shtml = shtml + '<li class="dropdown-tree"><a class="dropdown-tree-a" href="javascript:void(0);" onclick="DoSearchByCategory(\'' + sID + '\',1)" >' + sTitle + '</a>';
                    shtml = shtml + '<ul class="category-level-2  dropdown-menu-tree">';
                }
                first1++;
                // console.log("category_1=" + sTitle);
                //二级目录
                $(this).find('category_2').each(function () {
                    var sID_2 = $(this).attr('category_guid');
                    var sTitle_2 = $(this).attr("category_name");

                    if (sID_2 === sCateID2) {
                        shtml = shtml + '<li class="dropdown-tree open-tree"><a class="dropdown-tree-a" href="javascript:void(0);" onclick="DoSearchByCategory(\'' + sID_2 + '\',2)">' + sTitle_2 + '</a>';
                        shtml = shtml + '<ul class="category-level-2 dropdown-menu-tree">';
                    } else {
                        shtml = shtml + '<li class="dropdown-tree"><a class="dropdown-tree-a" href="javascript:void(0);" onclick="DoSearchByCategory(\'' + sID_2 + '\',2)">' + sTitle_2 + '</a>';
                        shtml = shtml + '<ul class="category-level-2  dropdown-menu-tree">';
                    }
                    first2++;
                    // console.log("category_2=" + sTitle_2);
                    //三级目录
                    $(this).find('category_3').each(function () {
                        var sID_3 = $(this).attr('category_guid');
                        var sTitle_3 = $(this).attr("category_name");
                        if (sID_3 === sCateID3) {
                            shtml = shtml + '<li ><a href="javascript:void(0);" onclick="DoSearchByCategory(\'' + sID_3 + '\',3)">' + sTitle_3 + '</a></li>';
                        } else {
                            shtml = shtml + '<li ><a href="javascript:void(0);" onclick="DoSearchByCategory(\'' + sID_3 + '\',3)">' + sTitle_3 + '</a></li>';
                        }
                    });
                    //三级目录 EOF
                    shtml = shtml + '</ul></li>';


                });
                shtml = shtml + '</ul></li>';
                //二级目录 EOF  
            });

            shtml = shtml + '</ul>';


            $("#category_tree").html(shtml);

            $(".dropdown-tree-a").click(function () { //use a class, since your ID gets mangled
                $(this).parent('.dropdown-tree').toggleClass("open-tree active"); //add the class to the clicked element
            });

            //console.log("1=" + sID + " 2=" + sCount + " 3=" + sTitle);


            // html += '<li><a href="#" onclick="LoadDesign(' + sID + ',0)"><img width="153" src="' + picDesignImgPath + sImage + '" alt=""></a></li>';



        },
        error: function (obj) {
            //alert("失败");
        }
    });

}
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
    varurl = "/AjaxPages/prdCateAjax.aspx";

    $(prdType1Name).append($("<option/>").text("-- ALL --").attr("value", "-1"));
    $.ajax({
        type: "GET",
        url: "/AjaxPages/prdCateAjax.aspx",
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
            url: "/AjaxPages/prdCateAjax.aspx",
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
            url: "/AjaxPages/prdCateAjax.aspx",
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
