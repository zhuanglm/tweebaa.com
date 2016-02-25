<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload_test.aspx.cs" Inherits="TweebaaWebApp2.Events.Tweebot.upload_test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.13/themes/base/jquery-ui.css" id="theme" />
<link rel="stylesheet" href="/jQuery_File_Upload/styles/Default/jquery.fileupload-ui.css" />
<link rel="stylesheet" href="/jQuery_File_Upload/styles/Default/style.css" />

</style>

</head>
<body>
<!--
    <form id="form1" runat="server">
-->
    <div>

  <div id="fileupload">
    <form action="/Events/Tweebot/FileTransferHandler.ashx" method="post" enctype="multipart/form-data">
        <div class="fileupload-buttonbar">
            <label class="fileinput-button">
                <span>Add files...</span>
                <input type="file" name="files[]" multiple="multiple" />
            </label>
            <button type="button" class="delete button">Delete all files</button>
			<div class="fileupload-progressbar"></div>
        </div>
    </form>
    <div class="fileupload-content">
        <table class="files"></table>
    </div>
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
   
    </div>
    <!--
    </form>
    -->
    <script src="/plugins/jquery/jquery.min.js"></script>
    <!--
<script src="//ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js"></script>
-->
<script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.8.13/jquery-ui.min.js"></script>
<script src="//ajax.aspnetcdn.com/ajax/jquery.templates/beta1/jquery.tmpl.min.js"></script>
<script src="/jQuery_File_Upload/scripts/Default/jquery.iframe-transport.js"></script>
<script src="/jQuery_File_Upload/scripts/Default/jquery.fileupload.js"></script>
<script src="/jQuery_File_Upload/scripts/Default/jquery.fileupload-ui.js"></script>
<script src="/jQuery_File_Upload/scripts/Default/application.js"></script>

</body>
</html>


