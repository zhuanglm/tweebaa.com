﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proEdit.aspx.cs" Inherits="TweebaaWebApp.Mgr.proManager.proEdit"
    ValidateRequest="false" EnableEventValidation="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title></title>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <script src="../../Js/util.js" type="text/javascript"></script>
    <script src="../../Js/xd.js" type="text/javascript"></script>
   
    <script src="../../Js/jquery.min.js" type="text/javascript"></script>
    <script src="../../Js/jquery.placeholder2.js" type="text/javascript"></script>
    <script src="../../Js/biaodan2.js" type="text/javascript"></script>
    <script src="../../Js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Js/newfloat.js"></script>


   

    <link href="../css/mgr.css" rel="stylesheet" />
    <link href="../css/aspnetpager.css" rel="stylesheet" />
    <link href="../ui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../ui/themes/demo.css" rel="stylesheet" type="text/css" />
    <link href="../ui/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../ui/jquery.min.js" type="text/javascript"></script>
    <script src="../ui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../ui/easyloader.js" type="text/javascript"></script>
    <script src="../../Kindeditor/kindeditor-4.1.10/kindeditor-min.js" type="text/javascript"></script>
    <script charset="utf-8" src="../../Kindeditor/kindeditor-4.1.10/kindeditor.js"></script>
    <script charset="utf-8" src="../../Kindeditor/kindeditor-4.1.10/lang/zh_CN.js"></script>
    <script charset="utf-8" src="../../Kindeditor/kindeditor-4.1.10/plugins/code/prettify.js"></script>
   
    <script src="../../MethodJs/uploadImg.js" type="text/javascript"></script>
</head>
<body style="padding: 2px;">
    <form id="form1" runat="server">
    <table class="tbtable" style="width: 100%;">
        <tr>
            <td class="title" style="width: 120px;">
                Product Name：
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtProName" runat="server" MaxLength="245" Width="400"></asp:TextBox>
                <asp:HiddenField ID="hidProId" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="title" style="width: 120px;">
                Product Categories：
            </td>
            <td colspan="3">
              <% // hidden field are used for server to save categories of the product %>
              <asp:HiddenField ID="hdnPrdCate" runat="server" />
              <asp:HiddenField ID="hdnPrdCate1List" runat="server" />
              <asp:HiddenField ID="hdnPrdCate2List" runat="server" />
              <asp:HiddenField ID="hdnPrdCate3List" runat="server" />

              <% // the table for categories of the product %>
              <table id="tbPrdCate">

              <% // The first category of the product and it cannot be deleted %>
              <% // other categories will be added dynamicly by Add Another Category Button %>
              <tr id="trPrdCate1">
                <td width="25"></td>
                <td><select name="" id="prdType11" style="width:200px"></select></td>
                <td><select name="" id="prdType12" style="width:200px"></select></td>
                <td><select name="" id="prdType13" style="width:200px" ></select></td>
              </tr>
              </table>
            </td>    
        </tr>
        <tr>
          <td class="title"></td>
          <td colspan="3"><input type="button" value="Add Another Category" onclick="AddAnotherCategory()" /></td>
        </tr>
        <script type ="text/javascript">
            function AddAnotherCategory() {
                var idx = 1;
                var trPrdCateName = "";
                
                // find the last category id
                while (true) {
                    trPrdCateName = "trPrdCate" + idx.toString();
                    var htmlTemp = $("#" + trPrdCateName).html();
                    if (htmlTemp == null) break;
                    idx += 1;
                }

                // append a new row for the new category
                var htmlPrdCate = '<tr id="' + trPrdCateName + '">' +
                                        '<td width="25"><input type=button value="X" onclick="DeletePrdCate(' + idx.toString() + ')" /></td>' +
                                        '<td><select name="" id="prdType' + idx + '1" style="width:200px"></select></td>' +
                                        '<td><select name="" id="prdType' + idx + '2" style="width:200px"></select></td>' +
                                        '<td><select name="" id="prdType' + idx + '3" style="width:200px"></select></td>' +
                                  '</tr>';
                $("#tbPrdCate").append(htmlPrdCate);

                // load the new category
                LoadPrdCate(idx);
                
                // return the index of the newly added category
                return idx;
            }

            function DeletePrdCate(idx) {
                // just hide the tr when delete
                $("#trPrdCate" + idx).hide();
            }

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
                        data: "layer=1&&id=" + prdType1,
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
                        data: "layer=2&&id=" + prdType2,
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
                            $(prdType3Name).append($("<option/>").text(val.name).attr("value", val.id));
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
                        data: "layer=1&&id=" + prdType1,
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
                        data: "layer=2&&id=" + prdType2,
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

            function ShowPrdCate(prdID) {
                // get/display/bind all categories
                var _data = "{ action:'GetPrdCate',id:'" + prdID + "'}";
                $.ajax({
                    type: "POST",
                    url: "../../AjaxPages/pwdAjax.aspx",
                    data: _data,
                    async: false,
                    dataType: "text",
                    success: function (ret) {
                        if (ret == null || ret == "" || ret == "[]") {
                            LoadPrdCate(1);
                            return;
                        }
                        var obj = eval(ret);
                        for (var i = 0; i < obj.length; i++) {
                            if (i > 0) AddAnotherCategory();
                            BindPrdCate(obj[i].cateGuid3, i + 1);  // always bind category by the 3rd level category
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Failed to load product categories");
                    }
                });
            }

        </script>
        <tr>
            <td class="title" style="width: 120px;">
                Tags：
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtTags" runat="server" MaxLength="245" Width="400"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title" style="width: 120px;">
                Brief Description ：
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtFeature" runat="server" Width="600" MaxLength="480" Height="70"
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title" style="width: 120px;">
                Features and Benefits：
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtBenefits" runat="server" Width="600" MaxLength="480" Height="50"
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="title" style="width: 120px;">
                Suggested Price：
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtSuggestPrice" runat="server"></asp:TextBox>USD
            </td>
        </tr>
        <tr style="display: none;">
            <td class="title" style="width: 120px;">
                Supply Price：
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtSupplyPrice" runat="server"></asp:TextBox>USD
            </td>
        </tr>
        <tr>
            <td class="title" style="width: 120px;">
                Test-Sale Price：
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtSalePrice" runat="server"></asp:TextBox>USD
            </td>
        </tr>
        <tr>
            <td class="title" style="width: 120px;">
                Images：
                <input type="hidden" id="hidPics" />
            </td>
            <td colspan="3">
                <iframe src="/upload/uploadpicEn.aspx" id="frm1" name="frmpic" frameborder="0"
                    width="100%" height="290" scrolling="no"></iframe>
                <%--https://tweebaa.com/uploadpicEn.aspx--%> 
            </td>
        </tr>
        <tr>
            <td class="title" style="width: 120px;">
                Detail Description：
            </td>
            <td colspan="3">
                <div>
                    <input type="hidden" runat="server" id="hidEditor" />
                    <textarea id="procaizhicontent" style="width: 680px; height: 350px;" runat="server"></textarea>
                    <%--<textarea id="txtDes" runat="server" name="content" style="width:300px;height:250px;"></textarea>--%>
                    <script type="text/javascript">
                        var editor;
                        KindEditor.ready(function (K) {
                            editor = K.create('#' + document.getElementById("procaizhicontent").id, {
                                langType: 'en',
                                cssPath: '../../Kindeditor/kindeditor-4.1.10/plugins/code/prettify.css',
                                uploadJson: '../../Kindeditor/kindeditor-4.1.10/asp.net/upload_json.ashx',
                                fileManagerJson: '../../Kindeditor/kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                                allowFileManager: true,
                                afterCreate: function () {
                                    var self = this;
                                    K.ctrl(document, 13, function () {
                                        self.sync();
                                        K('form[name=example]')[0].submit();
                                    });
                                    K.ctrl(self.edit.doc, 13, function () {
                                        self.sync();
                                        K('form[name=example]')[0].submit();
                                    });
                                }
                            });
                            //prettyPrint();
                        });

                        function getVal() {
                            var htmlStr = editor.html();
                            $("#hidEditor").val(htmlStr);
                            //$("#hidPics").val(piclist);
                            var picss = $("#hidPics").val();
                            alert(picss);

                            //           var img1 = $("#frm1").contents().find("#img1").attr("src");  
                            //            var img2 = $("#frm1").contents().find("#img2").attr("src");
                            //            var img3 = $("#frm1").contents().find("#img3").attr("src");
                            //            var img4 = $("#frm1").contents().find("#img4").attr("src");
                            //            var img5 = $("#frm1").contents().find("#img5").attr("src");
                            //            alert(img1 + ',' + img2 + ',' + img3 + ',' + img4 + ',' + img5);
                            //            $("#hidPics").val(img1 + ',' + img2 + ',' + img3 + ',' + img4 + ',' + img5);


                        }

                    </script>
                </div>
            </td>
        </tr>
          <tr>
            <td class="title" style="width: 120px;">
                Tag：
            </td>
            <td colspan="3">
                Free Shipping :<asp:CheckBox ID="ckbisFreeShipping" runat="server" />&nbsp;&nbsp;
                Limited Time:<asp:CheckBox ID="ckbisLimitedTime" runat="server" />&nbsp;&nbsp;
                Coming Soon :<asp:CheckBox ID="ckbisComingSoon" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <input type="button" value="Save Pictures" onclick="SavePic()" />
                <asp:Button ID="btnEdit" runat="server" Text="Save" OnClick="btnEdit_Click" OnClientClick="javascript:return verfy();" />
                <%--javascript:return verfy();--%>
            </td>
        </tr>
      
    </table>
    <script type="text/javascript">
        $(document).ready(function () {
            ShowPrdCate('<%=_proId %>');
        });
 
        function verfy() {
            var proName = $("#<%=txtProName.ClientID%>").val();
            if (proName == "") {
                alert("please input product name."); return false;
            }

            if (!CheckAndSetPrdCate()) return false;

            // tags  tags are seperated by spaces and comma
            var prdTag = $("#txtTags").val().trim();
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
                    $("#txtTags").focus();
                    return false;
                }

                for (var i = 0; i < arrTag.length; i++) {
                    if (arrTag[i].length <= 0) {
                        alert("Please enter valid tag name!");
                        $("#txtTags").focus();
                        return false;
                    }
                }
            }

            var Feature = $("#<%=txtFeature.ClientID%>").val();
            if (Feature == "") {
                alert("please input product feature."); return false;
            }
            var txtSuggestPrice = $("#<%=txtSuggestPrice.ClientID%>").val();
            if (txtSuggestPrice == "" || checknumber(txtSuggestPrice) == false) {
                alert("please input product suggest price."); return false;
            }

            //var txtSupplyPrice = $("#<%=txtSupplyPrice.ClientID%>").val();
            //if (txtSupplyPrice == "" || checknumber(txtSupplyPrice) == false) {
            //    alert("please input product supply price ."); return false;
            //}
            //return true;

            getVal();
        }


        function checknumber(String) {
            var Letters = "1234567890.";
            var i;
            var c;
            for (i = 0; i < String.length; i++) {
                c = String.charAt(i);
                if (Letters.indexOf(c) == -1) {
                    return false;
                }
            }
            return true;
        }

        function CheckAndSetPrdCate() {
            // check category input and set them to hidden fields for server to save
            var i = 0;
            var prdCate1List = "";
            var prdCate2List = "";
            var prdCate3List = "";
            var prdCate = "";
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
            $("#<%=hdnPrdCate.ClientID%>").val(prdCate);
            $("#<%=hdnPrdCate1List.ClientID%>").val(prdCate1List);
            $("#<%=hdnPrdCate2List.ClientID%>").val(prdCate2List);
            $("#<%=hdnPrdCate3List.ClientID%>").val(prdCate3List);
            return true;
        }


    </script>
    <input type="hidden" id="hidpic1" />
    <input type="hidden" id="hidpic2" />
    <input type="hidden" id="hidpic3" />
    <input type="hidden" id="hidpic4" />
    <input type="hidden" id="hidpic5" />
    <input type="hidden" id="hidvideo" />
    <script type="text/javascript">
        $(function () {
            // 封面事件
            $(".fengmian .btn-group").find("a").click(function (event) {


                //获取新的数组
                var fmImgArr = []
                var imglen = $(".fengmian").find("img").length;
                for (var i = 0; i < imglen; i++) {
                    var imgUrl = $(".fengmian").find("img").eq(i).attr("src")
                    fmImgArr.push(imgUrl)
                };

                var nowindex = 0
                var nextindex = 1;

                if ($(this).is(".moveLeft")) {
                    var thisindex = $(".fengmian .moveLeft").index(this);
                    if (thisindex > 0) {
                        nowindex = thisindex
                        nextindex = thisindex - 1;
                        //刷新数组
                        changeArrIndex(fmImgArr, nowindex, nextindex);

                        //图片位置更新
                        for (var ii = 0; ii < fmImgArr.length; ii++) {
                            $(".fengmian").find("img").eq(ii).attr("src", fmImgArr[ii])
                        };
                    };

                };


                if ($(this).is(".moveRight")) {
                    var thisindex = $(".fengmian .moveRight").index(this);
                    if (thisindex < imglen) {
                        nowindex = thisindex
                        nextindex = thisindex + 1;
                        //刷新数组
                        changeArrIndex(fmImgArr, nowindex, nextindex);

                        //图片位置更新
                        for (var ii = 0; ii < fmImgArr.length; ii++) {
                            $(".fengmian").find("img").eq(ii).attr("src", fmImgArr[ii])
                        };
                    };
                }


                //删除图片
                if ($(this).is(".delthis")) {

                    var thisindex = $(".fengmian .delthis").index(this);
                    if (thisindex != 0) {
                        $(this).parents('dd').find("img").remove()
                        $(".fengmian").append($(this).parents('dd'))
                    }
                    else {
                        $(this).parents('dd').find("img").remove()
                        $(".fengmian").append($(this).parents('dd'))

                        $(".fengmian dd:first").addClass('first').siblings('dd').removeClass('first')
                    }
                }
                return false;

            });

            function changeArrIndex(arrr, am, bm) {
                var mm = null;
                mm = arrr[am]
                arrr[am] = arrr[bm]
                arrr[bm] = mm
            }

        })
    </script>
    </form>
</body>
</html>
