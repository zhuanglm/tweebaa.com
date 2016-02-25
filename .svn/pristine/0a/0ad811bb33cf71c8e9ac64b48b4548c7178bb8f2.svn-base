<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admPrdContentInfo.aspx.cs" Inherits="TweebaaWebApp2.Manage.admPrdContentInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <title></title>
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <script src="../jquery-1.7.2/jquery-1.7.2.min.js" type="text/javascript"></script>
     <link href="../plugins/thems/jquery.upload.css" rel="stylesheet" type="text/css" />
    <script src="../plugins/jquery.upload.js" type="text/javascript"></script>
    <link href="../kindeditor-4.1.10/themes/default/default.css" rel="stylesheet" type="text/css" />
    <script src="../kindeditor-4.1.10/kindeditor-min.js" type="text/javascript"></script>
    <script src="../kindeditor-4.1.10/lang/zh_CN.js" type="text/javascript"></script>
    <link href="../kindeditor-4.1.10/themes/simple/simple.css" rel="stylesheet" type="text/css" />    
    <script charset="utf-8" src="../kindeditor-4.1.10/plugins/code/prettify.js" type="text/javascript"></script>
    <script src="../plugins/jquery.tooltip.js" type="text/javascript"></script>
    <link href="../plugins/thems/jquery.tooltip.css" rel="stylesheet" type="text/css" />
    <script src="../plugins/jquery.tagsinput.js" type="text/javascript"></script>
    <link href="../plugins/thems/jquery.tagsinput.css" rel="stylesheet" type="text/css" />

    <script>
        function load() {
            var divBoxs = $(".upload-box");
            var span = $(".dvTool");
            for (var i = 0; i < 5; i++) {
                //alert(divBoxs[i].innerHTML);              
                if (divBoxs[i].innerHTML == "") {

                    var id = "#" + "divPic" + i;
                    $(id).upload({ actionUrl: '../server/upload_json.ashx', uploadUrl: "http://localhost:4214/web/" });
                }
            }

        }


        $(document).ready(function () {
            //            var divBoxs = $(".upload-box");
            //            alert(divBoxs.length);
            //            for (var i = 0; i < divBoxs.length; i++) {
            //                alert(divBoxs[i].innerText);
            //                if (divBoxs[i].innerText == "") {
            //                   
            //                    $(".upload-box").upload({ actionUrl: '../server/upload_json.ashx', uploadUrl: "http://localhost:4214/web/" });
            //                }
            //            }

        });
        $(document).ready(function () {
            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('textarea[name="txtDesc"]', {
                    resizeType: 1,
                    cssPath: '../kindeditor-4.1.10/plugins/code/prettify.css',
                    allowPreviewEmoticons: false,
                    allowFileManager: true,
                    items: [
						'source', '|', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'emoticons', 'image', 'link']
                , uploadJson: '../kindeditor-4.1.10/asp.net/upload_json.ashx',
                    fileManagerJson: '../kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                    allowFileManager: true,
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
            });



            // $(".upload-box").append('<img src="../uploadfiles/20141026/20141026175716_5000.png"/><span class="dvTool" title="移出" onclick="$(this).prev().remove(); $(this).remove(); ">X</span>');
        });


        function GetPic() {
            var pic = document.getElementById("hidUploadLst").value;
            var hidPic = document.getElementById("<% =hidPic.ClientID %>");
            hidPic.value = pic;


        }
    </script>
</head>
<body style="background-color: #F7F8F9">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
        <ContentTemplate>
        <div id="targetbox">
        
        </div>
            <div style="padding-top: 25px; text-align: center;">
                <table cellspacing="0" cellpadding="0" border="0" class="tableStyle">
                    <tr>
                        <td class="d1">
                            <em>*&nbsp;</em>产品图片
                        </td>
                        <td style="text-align: left;">
                              <div style="background-color: #F6F8FA; border: dotted 1px #D9DDE3; padding: 10px;">                                   
                                  
                                <div class="upload-box" runat="server" id="divPic0">
                                </div>
                                <div class="upload-box" runat="server" id="divPic1">
                                </div>
                                <div class="upload-box" runat="server" id="divPic2">
                                </div>
                                <div class="upload-box" runat="server" id="divPic3">
                                </div>
                                <div class="upload-box" runat="server" id="divPic4">
                                </div>
                                <div class="clearboth">
                                </div>
                                <span style="font-size: 12px;">请单击图片进行上传，可用扩展名: jpg, jpeg, gif, png，单个文件最大 1M</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="d1">
                            产品视频
                        </td>
                        <td style="text-align: left;">
                            <input class="t1" id="txtVideoUrl" type="text" style="width: 485px;" value="&nbsp;输入展示视频的链接网址"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="d1">
                            <em>*&nbsp;</em>产品描述
                        </td>
                        <td style="text-align: left;">
                            <textarea id="txtDesc" name="txtDesc" cols="20" rows="2" runat="server" style="height: 400px;
                                width: 800px;">产品详情</textarea>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="btnSerch" OnClientClick="GetPic()" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:HiddenField ID="hidPic" runat="server" />
    </form>
  
</body>

</html>
