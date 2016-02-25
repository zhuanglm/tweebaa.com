<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="picUpload.aspx.cs" Inherits="TweebaaWebFile.picUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="tapmodo/css/jquery.Jcrop.min.css" rel="stylesheet" type="text/css" />
    <script src="tapmodo/js/jquery.min.js" type="text/javascript"></script>
    <script src="tapmodo/js/jquery.Jcrop.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#<%=fileUploadPic.ClientID %>").change(function () {
                var path = $(this).val();
                if (path != null && path.length > 0) {
                    $("#<%=btnUpload.ClientID %>").click();
                }
            });
            $("#<%=btnUpload.ClientID %>").hide();
        })

        function setImg(imgsrc, imgid) {
            window.opener.setImg(imgsrc, imgid);
            window.close();

        }
    </script>
    <script type="text/javascript">
        
        jQuery(function ($) {
            var jcrop_api; 
            $('#<%=Image1.ClientID %>').Jcrop({
                onChange: showCoords,
                onSelect: showCoords,
                onRelease: clearCoords,
                setSelect: [0, 0, 600, 600],
                maxSize:[1200,1200],
                minSize:[600,600],
                aspectRatio: 1
            }, function () {
                jcrop_api = this;
            });
            $('#coords').on('change', 'input', function (e) {
                var x1 = $('#x1').val(),
                      x2 = $('#x2').val(),
                      y1 = $('#y1').val(),
                      y2 = $('#y2').val();
                jcrop_api.setSelect([x1, y1, x2, y2]);
            });

        });

        // Simple event handler, called from onChange and onSelect
        // event handlers, as per the Jcrop invocation above
        function showCoords(c) {
            $('#x1').val(c.x);
            $('#y1').val(c.y);
            $('#x2').val(c.x2);
            $('#y2').val(c.y2);
            $('#w').val(c.w);
            $('#h').val(c.h);
        };

        function clearCoords() {
            $('#coords input').val('');
        };



</script>

    <style type="text/css">
        .btn {
            background-color: #007fd8;
            border: 0 none;
            border-radius: 5px;
            color: #fff;
            cursor: pointer;
            font-size: 16px;
            height: 30px;
            line-height: 30px;
            text-align: center;
            width: 170px;
            padding-bottom:3px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hidTip" runat="server" />
    <div style=" color:Red; font-size:13px; padding:3px;">
    The default picture shear box is 600 * 600 px and the max size can adjust is 800*800px,<br />you can set the coordinates to adjust or drag the mouse 
    </div>
    <div>
        <div style=" float:left;">
            <asp:HiddenField ID="hidBigFilePath" runat="server" />
            <%--<div style="display:none;">--%><asp:FileUpload ID="fileUploadPic" runat="server" /><%--</div> --%>
            <%--<input type="button" value="Select a picture" onclick="$('#hidBigFilePath').click();" />--%>
            <asp:Button ID="btnUpload" runat="server" Text="upload" OnClick="btnUpload_Click" />
            <asp:Button ID="btnCutSave" CssClass="btn" runat="server" Text="Save cropped picture" OnClick="btnCutSave_Click" />
        </div>
        <div class="inline-labels" id="coords" style="float: left; width: 600px;color:Gray; font-size:13px; padding-left:5px; padding-top:10px; height:30px;">
            <label>
                X1
                <input type="text" size="4" id="x1" name="x1" runat="server"  /></label>
            <label>
                Y1
                <input type="text" size="4" id="y1" name="y1" runat="server" /></label>
            <label>
                X2
                <input type="text" size="4" id="x2" name="x2" runat="server"  /></label>
            <label>
                Y2
                <input type="text" size="4" id="y2" name="y2" runat="server"  /></label>
            <label>
                Width
                <input type="text" size="4" id="w" name="w" runat="server" readonly="readonly" /></label>
            <label>
                Height
                <input type="text" size="4" id="h" name="h" runat="server" readonly="readonly"  /></label>
        </div>
        <div style="clear:both;"></div>
        <fieldset style=" height:600px; height:auto;">
        <legend>&nbsp;Picture View &nbsp;&nbsp;</legend>
        <div style=" margin-top:5px; ">
            <asp:Image ID="Image1" ImageUrl="~/Images/defaultCut.png" runat="server" />
        </div>
        </fieldset>
        
    </div>
    </form>
</body>
</html>
