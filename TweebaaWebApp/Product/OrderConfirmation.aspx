<%@ Page Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="OrderConfirmation.aspx.cs" Inherits="TweebaaWebApp.Product.OrderConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <title>Tweebar Order Confirmation</title>
    <link rel="stylesheet" href="../css/index.css" />
    <script src="/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/qtab.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/public.js"></script>
    <link rel="stylesheet" href="/css/shareall.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
    <div class="orderp-main">
        <div class="w">
            <form action="">
            <div class="orderp-main-box fl">
                <div class=" fl">
                    <img src="/images/mascot_confirm.png" alt="" /></div>
                <div class="fl right">
                    <h2>
                        Thank you, your order has been placed.</h2>
                    <h3>
                        An email confirmation has been sent to you.<br />
                        <br />
                        Order Number:
                        <%=out_trade_no%><br />
                    </h3>
                    <!--
Product name and Estimated delivery: Month dd, yyyy   -need line for each item</h3>
-->
                    <div class="box" style="padding-top: 30px">
                        <%--<div class="gotomc-btn">
						<input type="button" onclick="window.location.href='/Home/Index.aspx'" class="gotomc-btn send" value="Review your order" />						
					</div>--%>
                        <div class="submit-box">
                            <input type="button" onclick="window.location.href='/Product/prdSaleAll.aspx'" class="submit-btn send"
                                value="Return to Shopping" />
                        </div>
                    </div>
                </div>
            </div>
            </form>
        </div>
    </div>
    <</asp:Content>
