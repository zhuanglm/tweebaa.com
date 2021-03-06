﻿<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Tweebot.Master" AutoEventWireup="true" CodeBehind="Upload_Video.aspx.cs" Inherits="TweebaaWebApp2.Events.Tweebot.Upload_Video" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="/plugins/sky-forms/version-2.0.1/css/custom-sky-forms.css"> 
    <!-- CSS to style the file input field as button and adjust the Bootstrap progress bars -->
<link rel="stylesheet" href="/jQuery_File_Upload/css/jquery.fileupload.css">
<link rel="stylesheet" href="/jQuery_File_Upload/css/jquery.fileupload-ui.css">
<style>
.fileupload-buttonbar .ui-button input {
  position: absolute;
  top: 0;
  right: 0;
  margin: 0;
  border: solid transparent;
  border-width: 0 0 100px 200px;
  opacity: 0;
  filter: alpha(opacity=0);
  -o-transform: translate(250px, -50px) scale(1);
  -moz-transform: translate(-300px, 0) scale(4);
  direction: ltr;
  cursor: pointer;
}
#progress
{
    float:none;
   /* background-color:Blue;*/
    height:20px;
   /* min-width:40px;*/
}

</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">

 <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Upload Video</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="/Events/Tweebot/">Home</a></li>
                <li><a href="/Events/Tweebot/Vote.aspx">Vote</a></li>
                <li class="active">Upload Video</li>
            </ul>
        </div>
    </div>
    <!--=== End Breadcrumbs ===-->  
 
     <div class="container content"> 
   <form action="#" class="sky-form"  id=""  >
                    <input type="hidden" id="UserGuid" value="<%=_userid %>" />   
  <fieldset>
       <section>
  <div class="tag-box tag-box-v4 margin-bottom-40">
                    <button type="button" class="close" data-dismiss="alert">×</button>                
                
                 <p class="text-primary">   <strong>To enter the $10,000 “Show Us How You TweeBot” Contest, just fill out the below info:</strong></p>
                </div>

                                        <label class="label">Video Name</label>
                                        <label class="input">
                                 <input type="text" placeholder="Example:  TweeBot helps me find guacamole recipes." name="max">
                                            <b class="tooltip tooltip-top-left">
                                        Enter a title for your video; this is how it will be displayed on the VOTE page.<br>
                                      
                                 </b>
                                        </label>
                                    </section>
             
                    
     <section>
     <label class="label">Select Video</label>
       
                            <label for="file" class="input input-file">
  <input type="text" id="txtVideoUrl" placeholder="Supports wmv, mov, mp4 and flv formats. Maximum size is 5mb" readonly>
                                <div class="button">
   
 
   <div id="fileupload">
 <!--
     <form action="/Events/Tweenbot/FileTransferHandler.ashx" method="post" enctype="multipart/form-data">
-->
        <div class="fileupload-buttonbar">
            <label class="fileinput-button">
                <span>Browse</span>
                <input id="fileupload_browse" type="file" name="files[]" multiple="multiple" />
            </label>
            <!--
            <button type="button" class="delete button">Delete all files</button> -->
			
        </div>
        <!--
    </form>
    -->
   </div>  
      </div>                            <!--
                                <input type="file" name="file" multiple onchange="this.parentNode.nextSibling.value = this.value">Browse</div>
                                -->
                                
                                
                                       <b class="tooltip tooltip-top-left">Although videos are not required, they can help you better explain the features,functions, solutions of your product help engage buyers to make a purchasing decision.
                            
                                   </b>
                            </label>
    <!-- The global progress bar -->

    <div id="progress" class="progress">
        <div class="progress-bar progress-bar-success"></div>
    </div>
    <div class="fileupload-content">
        <table class="files"></table>
    </div>
<script id="template-upload" type="text/x-jquery-tmpl">
    <tr class="template-upload{{if error}} ui-state-error{{/if}}">
        <td class="preview"></td>
        <td class="name">${name}</td>
        <td class="size">${sizef}</td>
        {{if error}}
            <td class="error" colspan="2">Error:
                {{if error === 'maxFileSize'}}File is too big
                {{else error === 'minFileSize'}}File is too small
                {{else error === 'acceptFileTypes'}}Filetype not allowed
                {{else error === 'maxNumberOfFiles'}}Max number of files exceeded
                {{else}}${error}
                {{/if}}
            </td>
        {{else}}
            <td class="progress"><div></div></td>
            <td class="start"><button>Start</button></td>
        {{/if}}
        <td class="cancel"><button>Cancel</button></td>
    </tr>
</script>
                        </section>
                                   
                                   
                                                  <section>
                                        <label class="label">Brief Description</label>
                                        <label class="textarea">
                                          <textarea rows="3" id="txtDescription" placeholder="Example:  
I’m on a never-ending quest to find the perfect guacamole recipe.  
When I’m elbow-deep in avocados, TweeBot can come to the rescue HANDS-FREE!
" name="max"></textarea>
                                       
                                        </label>
                                    </section>                               
                        </fieldset>
                                 <footer>
                      
                         <button class="btn btn-lg rounded btn-primary" type="button" onclick="submit_upload()">Submit</button>
                  
                        
                    </footer>
                        </form>
         </div>  
         

<script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.8.13/jquery-ui.min.js"></script>
<script src="//ajax.aspnetcdn.com/ajax/jquery.templates/beta1/jquery.tmpl.min.js"></script>
<script src="/jQuery_File_Upload/scripts/Default/jquery.iframe-transport.js"></script>
<script src="/jQuery_File_Upload/scripts/Default/jquery.fileupload.js"></script>
<script src="/jQuery_File_Upload/scripts/Default/jquery.fileupload-ui.js"></script>
<!--
<script src="/jQuery_File_Upload/scripts/Default/application.js"></script>
-->
<script>
    /*jslint unparam: true */
    /*global window, $ */
    $(function () {
        'use strict';
        // Change this to the location of your server-side upload handler:
        var url = "/Events/Tweebot/FileTransferHandler.ashx";
        $('#fileupload').fileupload({
            url: url,
            dataType: 'json',
            done: function (e, data_f) {

                $.each(data_f.result, function (index, file) {
                    //$('<p/>').text(file.name).appendTo('#files');
                    console.log("file=" + file.name);
                    $("#txtVideoUrl").val(file.name);
                });

                 console.log("done");

            },
            progressall: function (e, data) {
                var progress = parseInt(data.loaded / data.total * 100, 10);
                console.log("progress=" + progress);
                $('#progress .progress-bar').css(
                'width',
                progress + '%'
            );
            }
        });
    });

    function submit_upload() {
        var txtVideoName = $("#txtVideoName").val();
        var txtVideoUrl = $("#txtVideoUrl").val();
        var txtDescription = $("#txtDescription").val();
        var txtUserGuid = $("#UserGuid").val();
        PostAVideo(txtVideoName, txtVideoUrl, txtDescription, txtUserGuid);

    }
</script>                 
</asp:Content>
