<%@ Page Language="C#" MasterPageFile="~/MasterPages/EventsMasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TweebaaWebApp.Events.Bugs.index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/css/index.css" />
    <link rel="stylesheet" href="/css/home.css" />
    <link href="/css/shareBox.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/jquery.placeholder.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/jquery-hcheckbox.js"></script>
    <script src="/js/selectNav.js" type="text/javascript"></script>
    <script src="/js/homePage.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/css/selectCss.css" />

    <link rel="stylesheet" href="/css/find-bug.css" />
    <script src="/js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/public.js"></script>
    <script src="/MethodJs/BugsReport.js" type="text/javascript"></script>
    <script src="/MethodJs/share.js" type="text/javascript"></script>

       <%--分页--%>    
    <script src="/js/jspage/kkpager.min.js" type="text/javascript"></script>
    <link href="/js/jspage/kkpager_orange.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">  

    <form id="form1" runat="server">

	<div class="w964">
     
<div class="bug-report">
        <h2>Bugs Report </h2>
        <div class="bug-search">
            <span >Bugs Search </span>

            
            <input type="text" value="" class="txt_blank" id="txtKeywords">

            <input type="button" onclick="DoSearch()" class="s_btn" value="Search" />
        </div>

        <div class="bug-btn">
        <button name="btnRankUserList" onclick="GotoTopRanking()" class="top_btn">Top Lists</button> <button onclick="GotoPostBugs()"  class="post_btn">Post a Bug</button>
        </div>
        
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

  
      </div>
  <div style="padding-top:20px">
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

        function GotoPostBugs() {

            window.open("/Events/BugsReport/BugsPost.aspx");
        }
        function GotoTopRanking() {

            window.open("/Events/BugsReport/TopRanking.aspx");
        }

        
    </script>
    </form>
</asp:Content>
