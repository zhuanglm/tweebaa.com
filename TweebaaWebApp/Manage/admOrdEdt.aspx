<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true"
    CodeBehind="admOrdEdt.aspx.cs" Inherits="TweebaaWebApp.Manage.admOrdEdt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link href="../plugins/thems/jquery.tab.css" rel="stylesheet" type="text/css" />
    <script src="../plugins/jquery.tab.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
    当前位置：产品管理 》产品详情 <a class="aFind" href="admPrd.aspx" target="_self">转至产品列表</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <div style="padding-left: 20px;">
        <div class="tab">
            <div class="tab_menu">
                <ul>
                    <li class="tab_selected">基本信息</li>
                    <li>评审信息</li>
                    <li>销售数据</li>
                </ul>
            </div>
            <div class="tab_box">
                <div>
                    Hello JQuery!</div>
                <div class="tab_displayNone">
                    Hello ExtJs!</div>
                <div class="tab_displayNone">
                    Hello Sliverlight!</div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>
