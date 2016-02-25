<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Tweebot.Master" AutoEventWireup="true" CodeBehind="Suggestion_Details.aspx.cs" Inherits="TweebaaWebApp2.Events.Tweebot.Suggestion_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

<div id="dvDetails"></div>
<script type="text/javascript">

    $(document).ready(function () {
        //console.log("ready!");

        LoadDetails(<%=_id %>);
    });
   
    function LoadDetails(_id) {
    $.ajax({
        type: "POST",
        url: '/Events/Tweebot/DBHandler.ashx',
        data: "{'action':'load_details'"
        + ",'txtID':'" + _id
         + "'}",
        success: function (resu) {
            //prdSaleInfo = resu;
            if (resu == "") {
                return;
            }
            var obj = eval("(" + resu + ")");
            var html = "";
            for (var i = 0; i < obj.length; i++) {
                var item = obj[i];
                html = '<table><tr><td><div class="txtTitle"><h2>' + item.suggestion_title + "</h2></div></td></tr>";
                html += '<tr><td align="right" class="qtitle">Submiter:' + item.username + "</td></tr>";
                html += '<tr><td style="padding-top:20px;"><div class="des">:' + item.suggestion_description + "</div></td></tr></table>";
            }
            $("#dvDetails").html(html);
            //return resu;
        },
        error: function (obj) {
            prdSaleInfo = "";
        }
    });

}
</script>
</asp:Content>
