<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master" AutoEventWireup="true"
 CodeBehind="admPrd.aspx.cs" Inherits="TweebaaWebApp.Manage.admPrd" %>

<%@ Register Src="~/Manage/Ascx/product0.ascx" TagName="Product0" TagPrefix="ucproduct0" %>
<%@ Register Src="~/Manage/ascx/product.ascx" TagName="Product" TagPrefix="ucproduct" %>
<%@ Register Src="~/Manage/ascx/product2.ascx" TagName="ProductSale" TagPrefix="ucproductSale" %>
<%@ Register Src="~/Manage/ascx/product3.ascx" TagName="ProductSale2" TagPrefix="ucproductSale2" %>
<%@ Register  TagPrefix="webdiyer" Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
   
    <link href="css/grid.css" rel="stylesheet" type="text/css" />
    <%--选项卡--%>
   <link href="css/orderCss/admTab.css" rel="stylesheet" type="text/css" />   
    <script src="../jquery-1.7.2/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="js/admTab.js" type="text/javascript"></script>
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
当前位置：产品管理 》产品列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


     <%--<asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>--%>
       
           <%-- <ucproduct:Product ID="Product0" runat="server"  />
            <ucproduct:Product ID="Product1" runat="server" Visible="false" />
            
            <ucproductSale:ProductSale ID="Product2" runat="server" Visible="false" />
            <ucproductSale2:ProductSale2 ID="Product3" runat="server" Visible="false" />  --%>             
     
<%--    <webdiyer:AspNetPager CssClass="anpager" CurrentPageButtonClass="cpb" ID="AspNetPager1" Visible="true" AlwaysShow="true"
        runat="server" HorizontalAlign="Center" Width="100%" PageSize="1" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页，每页%PageSize%条"
        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" ShowCustomInfoSection="Right" OnPageChanging="AspNetPager1_PageChanging" >
    </webdiyer:AspNetPager>--%>

 <%--    <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator"   CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" 
FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"   PrevPageText="上一页"  ShowCustomInfoSection="Left" 
ShowInputBox="Never" OnPageChanging="AspNetPager1_PageChanging"   CustomInfoTextAlign="Left" LayoutType="Table"  >
</webdiyer:AspNetPager>--%>
 
            <ul class="tabs" id="tabs">
               <%-- <li><a href="">全部</a></li>--%>
                <li><a href="javascript:void(0);" id="hrf1">评审中</a></li>
                <li><a href="javascript:void(0);">预售中</a></li>
                <li><a href="javascript:void(0);">销售中</a></li>
            </ul>
            <ul class="tab_conbox" id="tab_conbox">
               <%-- <li class="tab_con">
                  <ucproduct0:Product0 ID="Product0" runat="server" />                 
                </li>--%>
                <li class="tab_con">
                    <ucproduct:Product ID="Product1" runat="server" />
                </li>
                <li class="tab_con">
                    <ucproductSale:ProductSale ID="Product2" runat="server" />
                </li>
                <li class="tab_con">
                    <ucproductSale2:ProductSale2 ID="Product3" runat="server" />
                </li>
            </ul>
     <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">    
   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server"> 
</asp:Content>
