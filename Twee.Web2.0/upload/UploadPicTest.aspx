<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadPicTest.aspx.cs" Inherits="TweebaaWebFile.UploadPicTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="JavaScript">
        var AllowVideoImgSize = 2000;        //允许上传图片文件的大小 0为无限制  单位：KB
        var AllowImgWidth = 3000;            //允许上传的图片的宽度  0为无限制　单位：px(像素)
        var AllowImgHeight = 3000;            //允许上传的图片的高度  0为无限制　单位：px(像素)
        function load(Obj) {
            var tempImg = new Image();
            tempImg.onerror = function () {                   //不是图片
                thisform.button.disabled = true;            //提交不可用
                Obj.outerHTML = Obj.outerHTML;              //清除表单
                document.getElementByIdx_x("err_msg").innerHTML = "目标类型格式不正确或者图片已损坏!"
                document.getElementByIdx_x("ErrMsg").innerHTML = ""
            };

            tempImg.onreadystatechange = function () {
                thisform.button.disabled = false;          //提交可用
                document.getElementByIdx_x("err_msg").innerHTML = "&nbsp;&nbsp;&nbsp; 图片宽度：<font color=red>" + this.width + "</font><br>&nbsp;&nbsp;&nbsp; 图片高度：<font color=red>" + this.height + "</font><br>&nbsp;&nbsp;&nbsp; 图片大小：<font color=red>" + parseInt(this.fileSize / 1024) + "K</font>";

                if (AllowImgWidth != 0 && AllowImgWidth < this.width || AllowImgHeight != 0 && AllowImgHeight < this.height || AllowVideoImgSize != 0 && AllowVideoImgSize * 1024 < this.fileSize) {
                    document.execCommand("Delete");
                    Obj.outerHTML = Obj.outerHTML;
                    document.getElementByIdx_x("ErrMsg").innerHTML = "n图片不要超过<font color=red>" + AllowVideoImgSize + "</font>KB。<font color=red>" + AllowImgWidth + "</font>X<font color=red>" + AllowImgHeight + "</font>"
                    thisform.button.disabled = true;
                } else {
                    document.getElementByIdx_x("ErrMsg").innerHTML = ""
                    document.all.err_msg.style.display = '';
                }
            };
            tempImg.src = Obj.value;
        }

        function up() {
            if (thisform.button.disabled) event.returnValue = false;
        }

        var flag = false;
        function DrawImage(ImgD) {
            var image = new Image();
            image.src = ImgD.src;
            if (image.width > 0 && image.height > 0) {
                flag = true;
                if (image.width / image.height >= 350 / 300) {
                    if (image.width > 350) {
                        ImgD.width = 350;
                        ImgD.height = (image.height * 350) / image.width;
                    } else {
                        ImgD.width = image.width;
                        ImgD.height = image.height;
                    }
                }
                else {
                    if (image.height > 300) {
                        ImgD.height = 300;
                        ImgD.width = (image.width * 300) / image.height;
                    }
                    else {
                        ImgD.width = image.width;
                        ImgD.height = image.height;
                    }
                }
            }
        }
        function FileChange(Value) {
            flag = false;
            document.getElementByIdx_x("uploadimage").width = 0;
            document.getElementByIdx_x("uploadimage").height = 0;
            document.getElementByIdx_x("uploadimage").alt = "";
            document.getElementByIdx_x("uploadimage").src = Value;
        }
        function mysub() {
            esave.style.visibility = "visible";
        }

        var i = 11;
        function addNew() {
            tr = document.getElementByIdx_x("t136").insertRow();
            tr.insertCell().innerHTML = '图片说明<input type=text name=fileName>选择<input type=file name=pic' + i + ' style=width:100 content Editable=false value onpropertychange=javascript:load(this); onchange=javascript:FileChange(this.value);><a href=javascript:void(0) onclick=del()>删除</a>'
        }
        function del() {
            document.all.t136.deleteRow(window.event.srcElement.parentElement.parentElement.rowIndex);
        }
</script>
</head>
<body>
   <form name="thisform" action="/system/shopinfo/upimage.jsp" method="POST" onsubmit="javascript:up();" ENCTYPE="multipart/form-data">
<div id="esave" style="position:absolute; top:162px; z-index:10; visibility:hidden; width:210px; height:49px; left:24px">
   <marquee align="middle" scrollamount="5" width="210" height="50" style="background-color: #C0C0C0" behavior="alternate">...图片上传中...请等待...</marquee>
</div>

<table border="0" cellspacing="0" cellpadding="0" id="t136">
<tr>
  <td>
    图片说明<input type=text name=fileName>选择<input type=file name=pic1 style=width:100 content Editable=false onpropertychange=javascript:load(this); onchange=javascript:FileChange(this.value);><a href=javascript:void(0) onclick=del()>删除</a><br>
  </td>
</tr>
<tr>
  <td>
    图片说明<input type=text name=fileName>选择<input type=file name=pic1 style=width:100 content Editable=false onpropertychange=javascript:load(this); onchange=javascript:FileChange(this.value);><a href=javascript:void(0) onclick=del()>删除</a><br>
  </td>
</tr>
<tr>
  <td>
    图片说明<input type=text name=fileName>选择<input type=file name=pic1 style=width:100 content Editable=false onpropertychange=javascript:load(this); onchange=javascript:FileChange(this.value);><a href=javascript:void(0) onclick=del()>删除</a><br>
  </td>
</tr>
<tr>
  <td>
    图片说明<input type=text name=fileName>选择<input type=file name=pic1 style=width:100 content Editable=false onpropertychange=javascript:load(this); onchange=javascript:FileChange(this.value);><a href=javascript:void(0) onclick=del()>删除</a><br>
  </td>
</tr>
</table>
<input type="button" onclick="addNew()" value="增加一个上传>>">
<input type="submit" name="button" value="文件上传" disabled onclick="javascript:mysub()">
</form>
<p>图片说明是您所上所的图片的描叙信息，如果图片说明为空的话默认为文件的名称！</p>

<div id="err_msg">            </div>
<div id="ErrMsg">            </div>
<img id="uploadimage" height="0" width="0" src onload="javascript:DrawImage(uploadimage);">
<br>
（注：加入的图片文件大小不能超过1M，图片的长宽不能超过1280*1280！支持的图片类型有：gif,jpg）

</body>
</html>
