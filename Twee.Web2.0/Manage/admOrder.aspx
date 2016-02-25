<%@ Page Title=""  Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true"
    CodeBehind="admOrder.aspx.cs" Inherits="TweebaaWebApp2.Manage.admOrder" %>

<%@ Register Src="~/Manage/Ascx/orders.ascx" TagName="Orders" TagPrefix="ucOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <%-- <script src="js/admOrder.js" type="text/javascript"></script>--%>
    <link href="css/orderCss/grid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    <%--选项卡--%>
    <link rel="stylesheet" type="text/css" href="css/orderCss/admTab.css" />
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/admTab.js"></script>
    <%--弹出框--%>
    <link href="css/orderCss/jquery-webox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-webox.js" type="text/javascript"></script>
    <script type="text/javascript">

        function showBoxInfo(id) {
            $.webox({
                height: 550,
                width: 980,
                bgvisibel: false,
                title: '订单详情',
                iframe: 'admOrderInfo2.aspx?guid=' + id
            });

        }

        //改价/支付
        function showBoxUpPrice(id, action) {
            $.webox({
                height: 400,
                width: 1000,
                bgvisibel: false,
                title: action == '0' ? '改价' : '支付',
                iframe: 'admOrderUpPrice.aspx?guid=' + id + '&action=' + action
            });

        }

        //发货
        function showBoxSend(id) {
            $.webox({
                height: 580,
                width: 980,
                bgvisibel: false,
                title: '发货',
                iframe: 'admOrderSend.aspx?guid=' + id
            });

        }
        //完成/废除确认
        function showBoxConfirm(id, action) {
            $.webox({
                height: 130,
                width: 300,
                bgvisibel: false,
                title: action == '0' ? '确认完成' : '确认作废',
                iframe: 'admOrderConfirm.aspx?guid=' + id + '&action=' + action
            });

        }

        function mouseOver() {
            document.getElementById("pUpdate").style.visibility = "";
        }
        function mouseOut() {
            document.getElementById("pUpdate").style.visibility = "hidden";
        }

    
    </script>
    <style type="text/css">
        .btnSerch
        {
            width: 50px;
            height: 22px;
            background: #1D3647;
            border: 0;
            color: white;
            text-align: center;
            cursor: pointer;
            font-size: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server" Visible="false">
    <span style="font: 15px;">当前位置：订单管理 》订单列表</span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--   <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>--%>
    <ul class="tabs" id="tabs">
        <li><a href="#">全部</a></li>
        <li><a href="#">未支付</a></li>
        <li><a href="#">待发货</a></li>
        <li><a href="#">已发货</a></li>
        <li><a href="#">已完成</a></li>
        <li><a href="#">已作废</a></li>
    </ul>
    <ul class="tab_conbox" id="tab_conbox">
        <li class="tab_con">
            <ucOrder:Orders ID="Orders0" runat="server" />
        </li>
        <li class="tab_con">
            <ucOrder:Orders ID="Orders1" runat="server" />
        </li>
        <li class="tab_con">
            <ucOrder:Orders ID="Orders2" runat="server" />
        </li>
        <li class="tab_con">
            <ucOrder:Orders ID="Orders3" runat="server" />
        </li>
        <li class="tab_con">
            <ucOrder:Orders ID="Orders4" runat="server" />
        </li>
        <li class="tab_con">
            <ucOrder:Orders ID="Orders5" runat="server" />
        </li>
    </ul>
    <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
</asp:Content>
