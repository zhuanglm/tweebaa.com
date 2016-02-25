<%@ Page Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true" CodeBehind="Analysis.aspx.cs" Inherits="TweebaaWebApp.Manage.Analysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style>
        .Analysis
        {
            display: block;
            clear: both;
            margin-bottom: 80px;
            margin-top: 20px;
        }
        .Analysis table tr td
        {
            vertical-align: bottom;
        }
        .Analysis table tr td div
        {
            display: block;
            width: 25px;
            margin-right: 10px;
            position: relative;
        }
        .Analysis div h1, .Analysis div h2
        {
            position: absolute;
            top: -22px;
            font-size: 12px;
            font-weight: normal;
            font-style: italic;
        }
        .Analysis div h2
        {
            position: absolute;
        }
        /*div1*/
        .div1 table tr td
        {
            border-bottom: solid 1px #FF0033;
        }
        .div1 table tr td div
        {
            background-color: #FF0033;
        }
        /*div2*/
        .div2 table tr td
        {
            border-bottom: solid 1px #006699;
        }
        .div2 table tr td div
        {
            background-color: #006699;
        }
        /*div3*/
        .div3 table tr td
        {
            border-bottom: solid 1px #009966;
        }
        .div3 table tr td div
        {
            background-color: #009966;
        }
    </style>
    <script>
        function fload(obj) {
            if ($(obj).text() == "-折叠") {
                $(obj).text("+展开");
                $(obj).next().next().hide();
            }
            else {
                $(obj).text("-折叠");
                $(obj).next().next().show();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <ol>
        <li class='Analysis div1'><a href='javascript:void(0)' onclick='fload(this)'>-折叠</a>
            会员注册，<span id="lbUserReg" runat="server"></span>
            <div runat="server" id="dvUserReg">
            </div>
        </li>
        <li class='Analysis div2'><a href='javascript:void(0)' onclick='fload(this)'>-折叠</a>
            会员登录，<span id="lbUserLog" runat="server"></span>
            <div runat="server" id="dvUserLog" class='Analysis'>
            </div>
        </li>
        <li class='Analysis div3'><a href='javascript:void(0)' onclick='fload(this)'>-折叠</a>
            大众评审，<span id="lbUserReview" runat="server"></span>
            <div runat="server" id="dvUserReview" class='Analysis'>
            </div>
        </li>
    </ol>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>
