<%@ Page Title=""  Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true" CodeBehind="admPrdEdt.aspx.cs" Inherits="TweebaaWebApp2.Manage.admPrdEdt" %>

<%@ Register Src="~/Manage/ascx/admPrdBaseInfo.ascx" TagName="PrdBaseInfo" TagPrefix="ucPrdBaseInfo" %>
<%@ Register Src="~/Manage/ascx/admPrdContentInfo.ascx" TagName="PrdContentInfo"
    TagPrefix="ucPrdContentInfo" %>
<%@ Register Src="~/Manage/ascx/admPrdSpec.ascx" TagName="PrdSpec" TagPrefix="ucPrdSpec" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
   
    <link href="css/orderCss/order.css" rel="stylesheet" type="text/css" />
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <%--选项卡--%>
    <link href="css/orderCss/admTab.css" rel="stylesheet" type="text/css" />
    <script src="../jquery-1.7.2/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="js/admTab.js" type="text/javascript"></script>
    <%-- ----------------------------------------------%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
    当前位置：产品管理 》产品编辑 <a class="aFind" href="admPrd.aspx" target="_self">转至产品列表</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--<div style="padding-left: 20px;">
        <div class="tab">
            <div class="tab_menu">
                <ul>
                    <li class="tab_selected">基本信息</li>
                    <li>评审信息</li>
                    <li>销售数据</li>
                    <li>规格颜色</li>
                </ul>
            </div>
            <div class="tab_box">
                <div>
                    <table>
                        <tr>
                            <td>
                                项目类别
                            </td>
                            <td id='tdc'>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                项目名称
                            </td>
                            <td>
                                <input id="txtName" type="text" runat="server"  class="txtName"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                预估价格
                            </td>
                            <td>
                                <input id="txtPrice" type="text"  runat="server" class="txtPrice"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                图片
                            </td>
                            <td>
                                <div class="upload-box">
                                </div>
                                <div class="upload-box">
                                </div>
                                <div class="upload-box">
                                </div>
                                <div class="upload-box">
                                </div>
                                <div class="upload-box">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                生活中遇到的问题
                            </td>
                            <td>
                                <input id="txtQuestion" type="text"  runat="server" class="txtQuestion"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                解决方案
                            </td>
                            <td>
                                <input id="txtAnswer" type="text"  runat="server" class="txtAnswer"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                项目视频
                            </td>
                            <td>
                                <input id="txtVideoUrl" type="text"  runat="server" class="txtVideoUrl"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                联系人
                            </td>
                            <td>
                                <input id="txtUser" type="text" runat="server" class="txtUser"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                电话
                            </td>
                            <td>
                                <input id="txtPhone" type="text" runat="server" class="txtPhone"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                邮箱
                            </td>
                            <td>
                                <input id="txtEmail" type="text" runat="server" class="txtEmail"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                标签
                            </td>
                            <td>
                                <input id="tags_1" type="text" class="tags" value="foo,bar,baz,roffle" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="tab_displayNone">
                    <table>
                        <tr>
                            <td>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;支持
                            </td>
                            <td>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;反对
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40%; vertical-align: top;">
                                <ol class="zhichilst" id="zhichilst" style="text-align: left;">
                                </ol>
                            </td>
                            <td style="width: 40%; vertical-align: top; padding-left: 20px;">
                                <ol class="zhichilst" id="fanduilst" style="text-align: left;">
                                </ol>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="tab_displayNone">
                    Hello Sliverlight!</div>
                <div class="tab_displayNone">
                    <a onclick="addCol()" href="javascript:void(0)">增加颜色</a>
                    <a onclick="addColor()" href="javascript:void(0)">保存颜色</a>
                    <table id="tab1">
                        <tbody>
                            <tr>
                                <td>
                                    <ul>
                                        <li>
                                            <input class="color" id="Text2" type="text" /></li>
                                        <li>
                                            <div class="upload-box">
                                            </div>
                                            <div class="upload-box">
                                            </div>
                                            <div class="upload-box">
                                            </div>
                                            <div class="upload-box">
                                            </div>
                                        </li>
                                        <li>规格:
                                            <p>
                                                &nbsp;&nbsp;&nbsp;&nbsp;<input id="Text1" type="text" value="规格1" /></p>
                                            <a href="javascript:void(0)" id="aAddrow" onclick="addp(this)">+规格颜色</a></li>
                                    </ul>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>--%>
    <ul class="tabs" id="tabs">
        <li><a href="#">基本信息</a></li>
        <li><a href="#">商品详情</a></li>
        <li><a href="#">规格</a></li>
        <%--<li><a href="#">相关商品</a></li>--%>
    </ul>
    <ul class="tab_conbox" id="tab_conbox" style="height: 900px;">
        <li class="tab_con">
            <ucPrdBaseInfo:PrdBaseInfo ID="prdBaseInfo" runat="server" />
        </li>
        <li style="border: none;">
            <%--<ucPrdContentInfo:PrdContentInfo ID="PrdContentInfo" runat="server" />--%>
            <iframe src="admPrdContentInfo.aspx?id=<%=Request.QueryString["id"] %>" width="100%"
                height="800" frameborder="0" scrolling="yes"></iframe>
        </li>
        <li>
            <ucPrdSpec:PrdSpec ID="ucPrdSpec" runat="server" />
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
    <input id="hprdguid" type="hidden" runat="server" class="hprdid" />
    <input id="hprdguid2" type="hidden" runat="server" class="hprdid2" />
</asp:Content>
