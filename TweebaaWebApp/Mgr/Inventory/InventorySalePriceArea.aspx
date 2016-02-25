﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventorySalePriceArea.aspx.cs" 
Inherits="TweebaaWebApp.Mgr.Inventory.InventorySalePriceArea" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
       fieldset{ padding:5px; margin-bottom:10px;}
       legend{ font-size:14px; font-weight:bold; padding:3px;}
       table{ border:1px solid gray; border-collapse:collapse; width:98%;}
       tr th{ background-color:#b7b7b7; font-size:13px; font-weight:bold;border:1px solid gray; border-collapse:collapse; padding-top:3px; padding-bottom:3px;}
       td{ border:1px solid gray; border-collapse:collapse; font-size:13px; padding:3px; cursor:pointer;}
       .tip{ font-weight:bold;}
       .from,.to,.price{ height:14px; width:60px;}
       .area{ padding:1px;}
    </style>
    <script src="../js/jquery-1.7.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hid_proid" runat="server" />
    <fieldset>
        <legend>Supplier Product Specification and Pricing [Reference]</legend>
        <table>
           <tr>
              <th style=" width:150px;">Specification</th>
              <th style=" width:40px;">Colour</th>
              <th style=" width:150px;">Barcode</th>
              <th>Supply to Tweebaa</th>
              <th style=" width:150px;">Unique ID (SKU)</th>
              <th>Product volume</th>
              <th>Product weight</th>
              <th>Number of product per master carton</th>
              <th>Master carton DIMS</th>
              <th>Master carton weight</th>
           </tr>
           <%=ph_ruleList%>
           <%--<tr>
              <td>Specification Name</td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
           </tr>
           <tr style=" background-color:#ededed;">
              <td align="right" valign="middle">Price Range：</td>
              <td colspan="9" align="left" valign="middle"></td>
           </tr>--%>

        </table>
        <input type="text" runat="server" id="hidPriceAreaXml" style=" display:none;" />
    </fieldset>
    <div style=" padding:3px; text-align:left;">
        <asp:Button ID="btnSave" runat="server" Text="Save Retail Price Range" 
            OnClientClick="javascript:return savePriceArea()" onclick="btnSave_Click" />
    </div>
    <script type="text/javascript">
        //Add Price Range
        function addPriceArea(obj) {
            var table = $(obj).parent().parent().parent();
            var trHtml = "<tr><td class='area'>From：<input type='text' class='from' isnum='true'>to：<input type='text' class='to' isnum='true'>Price：<input type='text' class='price' isnum='true' /> &nbsp;<a style='cursor:pointer;' onclick='deletePriceArea(this);' href='javascript:void(0)'>Delete</a></td></tr>";
            $(trHtml).appendTo(table);
        }

        //Delete Price Range
        function deletePriceArea(obj) {
            var table = $(obj).parent().parent().parent();
            var trLength = table.find("tr").length;
            if (trLength > 2) {
                $(obj).parent().parent().remove();
            } else {
            alert('At least one price range is required');
            }
    }

    //Save Retail Price Range
    function savePriceArea() {
        var pan = true;
        $("input[isnum='true']").each(function () {
            if (!verfyNumber($(this).val())) {
                $(this).css("border-color", "red");
                pan = false;
                alert('Incorrect formart inside red box, only number is allowed');
                return false;
            }
        });
        //GenerateXml();
        $("#hidPriceAreaXml").val("").val(GenerateXml());
        return pan;
    }

    //生成一个XML字符串
    function GenerateXml() {
        var tables = $(".tbSalePrice");
        var xml = '';
        if (tables.length > 0) {
            xml += "<tb>";
            tables.each(function () {
                var ruleid = $(this).attr('ruleid');
                $(this).find("tr[class!='title']").each(function () {
                    var from = $(this).find("input[class='from']").eq(0).val();
                    var to = $(this).find("input[class='to']").eq(0).val();
                    var price = $(this).find("input[class='price']").eq(0).val();
                    xml += "<tr ruleid=\"" + ruleid + "\" from=\"" + from + "\" to=\"" + to + "\" price=\"" + price + "\" />";
                });
            });
            xml += "</tb>";
        }
        //alert(xml);
        return xml;
    }

    //验证数字
    function verfyNumber(num) {
        var reg = /^\d+(\.\d+)?$/;
        if (!reg.test(num))
            return false;
        else
            return true;
    }

    $(function () {
        $("#hidPriceAreaXml").val("");
    })
    </script>


    </form>
</body>
</html>