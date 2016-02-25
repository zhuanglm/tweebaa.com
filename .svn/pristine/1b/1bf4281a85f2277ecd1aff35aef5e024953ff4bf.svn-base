<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Tweebot.Master" AutoEventWireup="true" CodeBehind="Submit_Suggestion.aspx.cs" Inherits="TweebaaWebApp2.Events.Tweebot.Submit_Suggestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="/plugins/sky-forms/version-2.0.1/css/custom-sky-forms.css"> 

        <link rel="stylesheet" href="/Kindeditor/kindeditor-4.1.10/themes/default/default.css" />
    <link href="/Kindeditor/kindeditor-4.1.10/plugins/code/prettify.css" rel="stylesheet"
        type="text/css" />
    <script charset="utf-8" src="/Kindeditor/kindeditor-4.1.10/kindeditor.js"></script>
    <script charset="utf-8" src="/Kindeditor/kindeditor-4.1.10/lang/zh_CN.js"></script>
    <script charset="utf-8" src="/Kindeditor/kindeditor-4.1.10/plugins/code/prettify.js"></script>
     <script type="text/javascript">
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('#' + document.getElementById('WebContent_txtDec').id, {
                langType: 'en',
                cssPath: '/Kindeditor/kindeditor-4.1.10/plugins/code/prettify.css',
                uploadJson: '/Kindeditor/kindeditor-4.1.10/asp.net/upload_json.ashx',
                fileManagerJson: '/Kindeditor/kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                allowFileManager: false,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                }
            });
            prettyPrint();

        });
      </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

<!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Imorovement</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="/Events/Tweebot/">Home</a></li>
                <li><a href="/Events/Tweebot/Improvement.aspx">Imorovement</a></li>
                <li class="active">Submit Suggestion</li>
            </ul>
        </div>
    </div>
    <!--=== End Breadcrumbs ===-->  
 
     <div class="container content"> 
   <form action="#" class="sky-form"  id="" >
                 <input type="hidden" id="UserGuid" value="<%=_userid %>" />   
                    
                    <fieldset>
    
                    <section>
                            <label class="label">Select classification</label>
                            <label class="select">
                              <select id="seClassify">
                                    <option value="0">Out fit</option>
                                    <option value="1">Sound</option>
                                    <option value="2">Alice</option>
                                    <option value="3">Anastasia</option>
                                    <option value="4">Avelina</option>
                                </select>
                                <i></i>
                            </label>
                        </section>
                         <section>
                                        <label class="label">TITLE</label>
                                        <label class="input">
                                           
                                            <input type="text" id="txtTitle" placeholder="Modern Toaster" name="max">
                                            <b class="tooltip tooltip-top-left">
                                        Enter the product name exactly as you wish it to be displayed on Tweebaa.<br> 
                                        TIP:  A descriptive product name can attract more attention.<br>
                                        <u>Bad &nbsp; example</u>:   Litter Box<br>
                                        <u>Good example</u>:  Kitty Litty - flip-style, fast-cleaning cat litter box<br>
                                 </b>
                                        </label>
                                    </section>
                                   
                                   
                                                  <section>
                                        <label class="label">Detailed Description</label>
                                        <label class="textarea">
                                      <textarea name="txtDescription" placeholder="Sleek, modern electronic toaster with updated features. 
Easy to operate and to clean. 
Color: stainless steel " id="WebContent_txtDec" cols="100" rows="8" style="height: 400px; visibility: hidden;"></textarea>
<!--
                                          <textarea rows="3" id="txtDescription" placeholder="Sleek, modern electronic toaster with updated features. 
Easy to operate and to clean. 
Color: stainless steel " name="max"></textarea> -->
                               </label>
                                    </section>                               
                        </fieldset>
                                 <footer>
                      
                         <button class="btn btn-lg rounded btn-primary" onclick="PostSuggestion()" type="button">Submit</button>
                  
                        
                    </footer>
                        </form>
         </div>    
         
  <script type="text/javascript">
      function PostSuggestion() {
          //get broser type
          var txtClassifed = $("#seClassify option:selected").val();


          var txtTitle = $("#txtTitle").val();
          if (txtTitle.length < 1) {
              alert("Please input  Title");
              return;
          }
          var txtDescription = editor.html(); // $("#WebContent_txtDec").val();
          if (txtDescription.length < 1) {
              alert("Plase write down the description");
              return;
          }
          var txtUserGuid = $("#UserGuid").val();
          console.log("1=" + txtClassifed + " 2=" + txtTitle + " 3=" + txtDescription + " 4=" + txtUserGuid);
          PostASuggestion(txtClassifed, txtTitle, txtDescription, txtUserGuid);
         // PostABug(txtBrowser, bugsType, txtLevel, txtTitle, txtDescription, txtUserGuid);
      }

</script>
              
</asp:Content>
