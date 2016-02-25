<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryReview.aspx.cs" Inherits="TweebaaWebApp2.Manage.Inventory.InventoryReview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Kindeditor/kindeditor-4.1.10/kindeditor-min.js" type="text/javascript"></script>
    <script src="../../Kindeditor/kindeditor-4.1.10/lang/zh_CN.js" type="text/javascript"></script>
    <style type="text/css">
       fieldset{ padding:5px; margin-bottom:10px;}
       legend{ font-size:14px; font-weight:bold; padding:3px;}
       table{ border:1px solid gray; border-collapse:collapse; width:98%;}
       tr th{ background-color:#b7b7b7; font-size:13px; font-weight:bold;border:1px solid gray; border-collapse:collapse; padding-top:3px; padding-bottom:3px;}
       td{ border:1px solid gray; border-collapse:collapse; font-size:13px; padding:3px; cursor:pointer;}
       .tip{ font-weight:bold;}
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
    <asp:HiddenField ID="hidProID" runat="server" />
    <asp:HiddenField ID="hidUserID" runat="server" />
    <asp:HiddenField ID="hidDetailID" runat="server" />

    <fieldset>
       <legend>产品基本信息</legend>
       <table width="100%">
           <tr>
                 <td width="25%"><span class="tip">产品名称：</span><asp:Label ID="labproName" runat="server" Text=""></asp:Label></td>
                 <td width="25%"><span class="tip">产品类别：</span><asp:Label ID="labproType" runat="server" Text=""></asp:Label></td>
                 <td width="25%"><span class="tip">产权信息：</span><asp:Label ID="labproRight" runat="server" Text=""></asp:Label></td>
                 <td width="25%"><span class="tip">所在地：</span><asp:Label ID="labAddress" runat="server" Text=""></asp:Label></td>
           </tr>
            <tr>
                 <td><span class="tip">产品样品：</span><asp:Label ID="labExample" runat="server" Text=""></asp:Label><asp:Label ID="labproExampleInfo" runat="server" Text=""></asp:Label></td>
                 <td><span class="tip">最小起订量：</span><asp:Label ID="labMin" runat="server" Text=""></asp:Label></td>
                 <td><span class="tip">产品货号：</span><asp:Label ID="labNum" runat="server" Text=""></asp:Label></td>
                 <td><span class="tip">是否有库存：</span><asp:Label ID="labStock" runat="server" Text=""></asp:Label><asp:Label ID="labStockNum" runat="server" Text=""></asp:Label></td>
           </tr>
       </table>
    </fieldset>

    <fieldset>
        <legend>产品规格及价格区间</legend>
        <table>
           <tr>
              <th style=" width:150px;">规格</th>
              <th style=" width:40px;">颜色</th>
              <th style=" width:150px;">条形码</th>
              <th>供给推吧库存</th>
              <th style=" width:150px;">Unique Id (SKU)</th>
              <th>物流体积</th>
              <th>物流重量</th>
              <th>装箱量</th>
              <th>装箱尺寸</th>
              <th>装箱重量</th>
           </tr>
           <%=ph_ruleList%>
           <%--<tr>
              <td>f规格名称</td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
           </tr>
           <tr style=" background-color:#ededed;">
              <td align="right" valign="middle">价格区间：</td>
              <td colspan="9" align="left" valign="middle"></td>
           </tr>--%>

        </table>
    </fieldset>

    <fieldset>
        <legend>仓储信息及产品详情 </legend>
        <table width="100%">
           <tr>
                 <td width="25%"><span class="tip">是否提供一件代发：</span><asp:Label ID="labDaiFa" runat="server" Text=""></asp:Label></td>
                 <td width="25%"><span class="tip">发货范围：</span><asp:Label ID="labFaHuaArea" runat="server" Text=""></asp:Label></td>
           </tr>
           <tr>
                 <td width="25%"><span class="tip">海外仓库：</span><asp:Label ID="labHaiWaiStock" runat="server" Text=""></asp:Label><asp:Label ID="labHaiWaiStockInfo" runat="server" Text=""></asp:Label></td>
                 <td width="25%"><span class="tip">售后服务：</span><asp:Label ID="labService" runat="server" Text=""></asp:Label><asp:Label ID="labServiceInfo" runat="server" Text=""></asp:Label></td>
           </tr>
           <tr>
              <td colspan="2"><span class="tip">材质：</span><asp:Label ID="labCaiZhi" runat="server" Text=""></asp:Label></td>
           </tr>
           <tr>
             <td colspan="2">
                 <span class="tip">产品详情：</span><br />
                <div>
                <textarea id="procaizhicontent"  name="content" style="width:300px;height:250px;"><%=proCaiZhiContent %></textarea>
                                    <script type="text/javascript">
                                        var editor;
                                        KindEditor.ready(function (K) {
                                            editor = K.create('#procaizhicontent', {
                                                allowFileManager: true,
                                                items: ['source', 'fontname', 'fontsize', 'forecolor', 'textcolor', 'bold', 'bgcolor', 'underline', 'removeformat', 'italic', 'insertunorderedlist',
                                                'preview', 'selectall', 'justifyleft', 'justifycenter', 'justifyright', 'emoticons', 'link', 'unlink', 'image']
                                            });
                                        });
                                       
                                    </script>
                </div>
             </td>
           </tr>
        </table>
    </fieldset>

    <div style=" width:98%; text-align:left; padding:5px; vertical-align:middle;">
        <asp:Button ID="btnAccept" runat="server" Text="采纳该产品并填写销售价格区间" 
            onclick="btnAccept_Click" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="拒纳该产品" 
            onclick="btnCancel_Click" />
    </div>
    </form>
</body>
</html>
