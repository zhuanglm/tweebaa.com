﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="admPrdContentInfo.ascx.cs" Inherits="TweebaaWebApp2.Manage.Ascx.admPrdContentInfo" %>
<link href="<%=  System.Configuration.ConfigurationManager.AppSettings["rootUrl"].ToString()%>plugins/thems/jquery.popup.css"
    rel="stylesheet" type="text/css" />
<link href="<%=  System.Configuration.ConfigurationManager.AppSettings["rootUrl"].ToString()%>skin/1/css.css"
    rel="stylesheet" type="text/css" />
<link href="<%=  System.Configuration.ConfigurationManager.AppSettings["rootUrl"].ToString()%>plugins/thems/jquery.combobox.css"
    rel="stylesheet" type="text/css" />
<link href="<%=  System.Configuration.ConfigurationManager.AppSettings["rootUrl"].ToString()%>plugins/thems/jquery.goToTop.css"
    rel="stylesheet" type="text/css" />
<script src="<%=  System.Configuration.ConfigurationManager.AppSettings["rootUrl"].ToString()%>jquery-1.7.2/jquery-1.7.2.min.js"
    type="text/javascript"></script>
<script src="../js/jquery.ajaxpost.js" type="text/javascript"></script>
<link href="../../plugins/thems/jquery.upload.css" rel="stylesheet" type="text/css" />
<script src="../js/jquery.popup.js" type="text/javascript"></script>
<link href="../../plugins/thems/jquery.popup.css" rel="stylesheet" type="text/css" />
<link href="../../plugins/thems/jquery.validity.css" rel="stylesheet" type="text/css" />
<script src="../js/jquery.validity.js" type="text/javascript"></script>
<script src="../../plugins/jquery.upload.js" type="text/javascript"></script>
<link rel="stylesheet" href="../../kindeditor-4.1.10/themes/default/default.css" />
<script charset="utf-8" src="../../kindeditor-4.1.10/kindeditor-min.js"></script>
<script charset="utf-8" src="../../kindeditor-4.1.10/lang/zh_CN.js"></script>
<link href="../../kindeditor-4.1.10/themes/simple/simple.css" rel="stylesheet" type="text/css" />
<script charset="utf-8" src="../../kindeditor-4.1.10/plugins/code/prettify.js"></script>
<fieldset>
    <legend style="color: #666666;">&nbsp;发布产品&nbsp;</legend>
    <div style="padding: 40px;">
        <table>
            <tr>
                <td class="d1">
                    <em>*&nbsp;</em>产品价格
                </td>
                <td>
                    <input id="txtPrice" type="text" validity="request" errortxt="请输入预估价格！" emptytxt="请输入预估价格！"
                        class="inputNumber t1" value="&nbsp;请输入产品价格" />
                </td>
            </tr>
            <tr>
                <td class="d1">
                    <em>*&nbsp;</em>产品图片
                </td>
                <td>
                    <div style="background-color: #F6F8FA; border: dotted 1px #D9DDE3; padding: 10px;">
                        <div class="upload-box">
                        </div>
                        <div class="upload-box">
                        </div>
                        <div class="upload-box">
                        </div>
                        <div class="upload-box">
                        </div>
                        <div class="upload-box">
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
                <td>
                    <input class="t1" id="txtVideoUrl" type="text" style="width: 485px;" value="&nbsp;输入展示视频的链接网址"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td class="d1">
                    <em>*&nbsp;</em>产品描述
                </td>
                <td>
                    <textarea id="txtDesc" runat="server" name="txtDesc" cols="20" rows="2" style="height: 250px;">dsfdf</textarea>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                 <asp:Button ID="btnAdd" runat="server" Text="保存" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
</fieldset>
   