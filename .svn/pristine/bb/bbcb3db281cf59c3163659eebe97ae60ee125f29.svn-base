<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true" CodeBehind="admUserInfo.aspx.cs" Inherits="TweebaaWebApp.Manage.admUserInfo" %>


<%@ Register Src="~/Manage/ascx/admPeronReview.ascx" TagName="PeronReview" TagPrefix="ucPeronReview" %>
<%@ Register Src="~/Manage/ascx/admPeronPublish.ascx" TagName="PeronPub" TagPrefix="ucPeronPub" %>
<%@ Register Src="~/Manage/ascx/admPersonShare.ascx" TagName="PeronShare" TagPrefix="ucPeronShare" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
     <%--选项卡--%>
    <link href="css/orderCss/admTab.css" rel="stylesheet" type="text/css" /> 
    <script src="../jquery-1.7.2/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="js/admTab.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(
          function () {
              //              var $id = document.getElementById;
              //              $Id("#IReviewInfo").contentWindow.$Id("#maincont").hide();          
          });       
       
    </script>
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
   当前位置：会员管理 | 会员活动 &nbsp;&nbsp;<a class="aFind" href="admUser.aspx" target="_self">转至用户列表</a>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <input type="hidden" id="txtData" runat="server" />
  
   
      <ul class="tabs" id="tabs">
                <li><a href="">用户信息</a></li>
                <li><a href="">发布记录</a></li>
                <li><a href="">评审记录</a></li>
                <li><a href="">分享记录</a></li>
                <li><a href="">佣金记录</a></li>
            </ul>
      <ul class="tab_conbox" id="tab_conbox">
                <li class="tab_con">
                    <table class="rightcontfont">
                        <tr>
                            <td style="height: 40px;">
                                姓名：
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" CssClass="input_tx" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px;">
                                邮箱：
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" CssClass="input_tx" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px;">
                                性别：
                            </td>
                            <td>
                                <asp:TextBox ID="txtSex" CssClass="input_tx" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px;">
                                电话：
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhone" CssClass="input_tx" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px;">
                                出生日期：
                            </td>
                            <td>
                                <asp:TextBox ID="txtBirth" CssClass="input_tx" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px;">
                                地址：
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddress" CssClass="input_tx" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px;">
                                上次登录时间：
                            </td>
                            <td>
                                <asp:TextBox ID="txtLastLogin" CssClass="input_tx" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px;">
                                注册时间：
                            </td>
                            <td>
                                <asp:TextBox ID="txtRegisTime" CssClass="input_tx" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: right">
                                
                                <input  type="button" id="btnBack" value="返 回" class="btnSerch" onclick="javascript:_history.go(-1);" style=" visibility:hidden;"/>
                            </td>
                        </tr>
                    </table>
                </li>
                <li class="tab_con">
                    <ucPeronPub:PeronPub ID="peronPub" runat="server"></ucPeronPub:PeronPub>
                </li>
                <li class="tab_con">
                     <%-- <iframe id="IReviewInfo" runat="server" src="admPeronReview.aspx?id='<%=GetID()'%>" width="100%" height="600px" frameborder="0" scrolling="no" runat="server"></iframe>--%>
                    <ucPeronReview:PeronReview ID="peronReview" runat="server" />
                </li>
                <li class="tab_con">
                    <ucPeronShare:PeronShare ID="personShare" runat="server" />
                </li>
                <li class="tab_con">
                    
                </li>
                
            </ul>
       
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>
