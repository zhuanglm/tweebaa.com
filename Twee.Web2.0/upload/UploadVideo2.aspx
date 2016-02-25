<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadVideo2.aspx.cs" Inherits="TweebaaWebApp.upload.UploadVideo2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
        标题：<asp:TextBox ID="txtTitle" runat="server" Width="358px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle"
            ErrorMessage="标题不为空"></asp:RequiredFieldValidator>
       <br />
        <asp:FileUpload ID="FileUpload1" runat="server" Width="339px" />
        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="上传视频" Width="70px" />
        文件类型<span style="color:Red;">(.asf|.flv|.avi|.mpg|.3gp|.mov|.wmv|.rm|.rmvb)</span>
            <asp:RegularExpressionValidator ID="imagePathValidator" runat="server" ErrorMessage="文件类型不正确"
            ValidationGroup="vgValidation" Display="Dynamic" ValidationExpression="^[a-zA-Z]:(\\.+)(.asf|.flv|.avi|.mpg|.3gp|.mov|.wmv|.rm|.rmvb)$"
            ControlToValidate="FileUpload1">
            </asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1"
            ErrorMessage="文件不为空"></asp:RequiredFieldValidator></div>
        <div style=" height:0px; border-top:solid 1px red; font-size:0px;"></div>
        <div>上传列表....</div>
         <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
                SelectCommand="SELECT * FROM [Media] order by FPostDate desc"></asp:SqlDataSource>
                <div class="MailList">
                    <asp:Repeater ID="reMediaList" runat="server" DataSourceID="SqlDataSource1">
                        <ItemTemplate>
                            <div class="ItemCss">
                                <div class="ItemImgCss">
                                    <%--<a href='ViewMedia.aspx?id=<%#Eval("FID") %>' target="_blank"><img src='<%#Eval("FMediaImgPath") %>' alt='<%#Eval("FMediaName") %>'/></a>--%>
                                     <a href='PlayVideo.aspx?playPath=<%#Eval("FMediaPlayPath") %>&imgPath=<%#Eval("FMediaImgPath") %>' target="_blank"><img src='<%#Eval("FMediaImgPath") %>' alt='<%#Eval("FMediaName") %>'/></a>
                              
                                    
                                </div>
                                <div class="ItemTCss"><a href='ViewMedia.aspx?id=<%#Eval("FID") %>' target="_blank"><%#Eval("FMediaName") %></a></div>
                                <%--<div class="ItemTCss"><asp:LinkButton ID="btnDelete" runat="server" Text="删除" OnClientClick="javascript:confirm('你确定要删除些视频吗？');"  OnClick="btnDelete_Click" CommandArgument='<%#Eval("FID") %>'></asp:LinkButton></div>--%>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            
            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" >
            </asp:GridView>
        </div>
    </form>
</body>
</html>
