<%@ Page Language="C#"  MasterPageFile="~/MasterPages/EventsMasterPage.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="TweebaaWebApp.Events.BugsReport.admin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/Css/index.css" />
    <link rel="stylesheet" href="/Css/home.css" />
    <link href="/Css/shareBox.css" rel="stylesheet" type="text/css" />
    <script src="/Js/jquery.min.js" type="text/javascript"></script>
    <script src="/Js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Js/jquery-hcheckbox.js"></script>
    <script src="/Js/selectNav.js" type="text/javascript"></script>
    <script src="/Js/homePage.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/Css/selectCss.css" />
    <script src="/Js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Js/public.js"></script>
    <script src="/MethodJs/BugsReportAdmin.js" type="text/javascript"></script>
    <script src="/MethodJs/share.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/Css/find-bug.css" />
       <%--分页--%>    
    <script src="/Js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="/Js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">  

    <form id="form1" runat="server">

	<div class="w964">
     <input type="hidden" name="Admin_userID" id="Admin_userID" value="<%=_userid %>" />
<div class="bug-report">
        <h2>Bugs Report Admin </h2>
        <div class="bug-search">
            <span >Bugs Search </span>

            
            <input type="text" value="" class="txt_blank" id="txtKeywords">

            <input type="button" onclick="DoSearch()" class="s_btn" value="Search" />
        </div>

         <div class="bug-btn"></div>
        
<div class="bug_table" >
                <table  id="tabCollection">
                    <tr>
                        <td width="200">
                            Type
                        </td>
                        <td >
                           User Name
                        </td>
                        <td width="400">
                            Title
                        </td>
                        <td>
                            Publish Time
                        </td>
                        <td>
                            Status
                        </td>
                    </tr>
        </table>

            <div id="kkpager" >
           </div>     
      </div>
    

   


    </div>

</div>

    <script type="text/javascript">

        //关闭弹出框
        $('.closeBtn,.iagree').click(function (event) {
            var obj2 = $(this).parents(".tck")
            obj2.animate({
                top: "-500px"
            },
				300, function () {
				    obj2.parents(".greybox").hide()

				});
            return false;
        });

        $(document).ready(function () {
            loadBugsCount();
            LoadBugs();
        }
        );

    </script>
    </form>
</asp:Content>
