<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uploadExcelPic2.aspx.cs"
    Inherits="TweebaaWebFile.Server.uploadExcelPic2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;&nbsp;&nbsp;<strong>请选择导入人：</strong> &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlUser" runat="server" Width="120" Height="25">
            <asp:ListItem Value="">--请选择--</asp:ListItem>
            <asp:ListItem Value="lw">李蔚</asp:ListItem>
            <asp:ListItem Value="ls">李松</asp:ListItem>
            <asp:ListItem Value="jy">江艳</asp:ListItem>
            <asp:ListItem Value="lh">柳红</asp:ListItem>
            <asp:ListItem Value="wyy">万园园</asp:ListItem>
            <asp:ListItem Value="Mac">Mac</asp:ListItem>
            <asp:ListItem Value="Mindy">Mindy</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<strong>请选图片日期文件夹：</strong> &nbsp;&nbsp;&nbsp;&nbsp;
         <asp:DropDownList ID="ddlDate" runat="server" Width="120" Height="25">
            <asp:ListItem Value="0">--请选择--</asp:ListItem>
            <asp:ListItem Value="1">20141127</asp:ListItem>
            <asp:ListItem Value="2">20141128</asp:ListItem>
            <asp:ListItem Value="3">20141129</asp:ListItem>
            <asp:ListItem Value="4">20141130</asp:ListItem>
            <asp:ListItem Value="5">20141201</asp:ListItem>
            <asp:ListItem Value="6">20141202</asp:ListItem>
            <asp:ListItem Value="7">20141203</asp:ListItem>
            <asp:ListItem Value="8">20141204</asp:ListItem>
            <asp:ListItem Value="9">20141205</asp:ListItem>
            <asp:ListItem Value="10">20141206</asp:ListItem>
            <asp:ListItem Value="11">20141207</asp:ListItem>
            <asp:ListItem Value="12">20141208</asp:ListItem>
            <asp:ListItem Value="13">20141209</asp:ListItem>
            <asp:ListItem Value="14">20141210</asp:ListItem>
            <asp:ListItem Value="15">20141211</asp:ListItem>
            <asp:ListItem Value="16">20141212</asp:ListItem>
            <asp:ListItem Value="17">20141213</asp:ListItem>
            <asp:ListItem Value="18">20141214</asp:ListItem>
            <asp:ListItem Value="19">20141215</asp:ListItem>
            <asp:ListItem Value="20">20141216</asp:ListItem>
            <asp:ListItem Value="21">20141217</asp:ListItem>
            <asp:ListItem Value="22">20141218</asp:ListItem>
            <asp:ListItem Value="23">20141219</asp:ListItem>
            <asp:ListItem Value="24">20141220</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:DropDownList   ID="ddlDate" runat="server" Width="120" Height="25" AutoPostBack="false">
            <asp:ListItem Value="">--请选择--</asp:ListItem>
            <asp:ListItem Value="">20141127</asp:ListItem>
            <asp:ListItem Value="">20141128</asp:ListItem>
            <asp:ListItem Value="">20141129</asp:ListItem>
            <asp:ListItem Value="">20141130</asp:ListItem>
            <asp:ListItem Value="">20141201</asp:ListItem>
            <asp:ListItem Value="">20141202</asp:ListItem>
            <asp:ListItem Value="">20141203</asp:ListItem>
            <asp:ListItem Value="">20141204</asp:ListItem>
            <asp:ListItem Value="">20141205</asp:ListItem>
            <asp:ListItem Value="">20141206</asp:ListItem>
            <asp:ListItem Value="">20141207</asp:ListItem>
            <asp:ListItem Value="">20141208</asp:ListItem>
            <asp:ListItem Value="">20141209</asp:ListItem>
            <asp:ListItem Value="">20141210</asp:ListItem>
            <asp:ListItem Value="">20141211</asp:ListItem>
            <asp:ListItem Value="">20141212</asp:ListItem>
            <asp:ListItem Value="">20141213</asp:ListItem>
            <asp:ListItem Value="">20141214</asp:ListItem>
            <asp:ListItem Value="">20141215</asp:ListItem>
            <asp:ListItem Value="">20141216</asp:ListItem>
            <asp:ListItem Value="">20141217</asp:ListItem>
            <asp:ListItem Value="">20141218</asp:ListItem>
        </asp:DropDownList>--%>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="导入产品图片" /><br /><br />
         <label id="labErroe" runat="server"></label>
    </div>
    </form>
</body>
</html>
