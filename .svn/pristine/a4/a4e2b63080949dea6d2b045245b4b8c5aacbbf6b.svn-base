<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventorySalePriceArea.aspx.cs" 
Inherits="TweebaaWebApp2.Manage.Inventory.InventorySalePriceArea" ValidateRequest="false" %>

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
    <script src="../js/jquery-1.7.2.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hid_proid" runat="server" />
    <fieldset>
        <legend>供货商的产品规格及价格区间[参考]</legend>
        <table>
           <tr>
              <th style=" width:150px;">规格</th>
              <th style=" width:40px;">颜色</th>
              <th style=" width:150px;">条形码</th>
              <th>供给推吧库存</th>
              <th style=" width:150px;">Unique Id (SKU)</th>
              <th>物流体积</th>
              <th>物流重量</th>
              <th>装箱量</th>
              <th>装箱尺寸</th>
              <th>装箱重量</th>
           </tr>
           <%=ph_ruleList%>
           <%--<tr>
              <td>f规格名称</td>
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
              <td align="right" valign="middle">价格区间：</td>
              <td colspan="9" align="left" valign="middle"></td>
           </tr>--%>

        </table>
        <input type="text" runat="server" id="hidPriceAreaXml" style=" display:none;" />
    </fieldset>
    <div style=" padding:3px; text-align:left;">
        <asp:Button ID="btnSave" runat="server" Text="保存销售价格区间" 
            OnClientClick="javascript:return savePriceArea()" onclick="btnSave_Click" />
    </div>
    <script type="text/javascript">
        //增加价格区间
        function addPriceArea(obj) {
            var table = $(obj).parent().parent().parent();
            var trHtml = "<tr><td class='area'>从：<input type='text' class='from' isnum='true'>到：<input type='text' class='to' isnum='true'>价格：<input type='text' class='price' isnum='true' /> &nbsp;<a style='cursor:pointer;' onclick='deletePriceArea(this);' href='javascript:void(0)'>删除</a></td></tr>";
            $(trHtml).appendTo(table);
        }

        //删除价格区间
        function deletePriceArea(obj) {
            var table = $(obj).parent().parent().parent();
            var trLength = table.find("tr").length;
            if (trLength > 2) {
                $(obj).parent().parent().remove();
            } else {
            alert('必须填写一条价格区间');
            }
    }

    //保存销售价格区间
    function savePriceArea() {
        var pan = true;
        $("input[isnum='true']").each(function () {
            if (!verfyNumber($(this).val())) {
                $(this).css("border-color", "red");
                pan = false;
                alert('红色方框内录入格式有误,只能录入数字');
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
