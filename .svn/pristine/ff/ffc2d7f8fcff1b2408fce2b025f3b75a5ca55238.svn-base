<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMedia.aspx.cs" Inherits="TweebaaWebApp.upload.ViewMedia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .playCss
        {
            width: 350px;
            height: 300px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Repeater ID="reMediaplay" runat="server" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="480px" height="400px">
                        <param name="movie" value="player.swf" />
                        <param name="quality" value="High" />
                        <param name="FlashVars" value="pURL=<%#Eval("FMediaPlayPath") %>" />
                    </object>
                   　<EMBED SRC="<%#Eval("FMediaPlayPath") %>" autostart="false" loop="false" width="350" height="250">
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
            SelectCommand="SELECT [FID], [FMediaName], [FMediaPlayPath], [FPostDate] FROM [Media] WHERE ([FID] = @FID)">
            <SelectParameters>
                <asp:QueryStringParameter Name="FID" QueryStringField="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
