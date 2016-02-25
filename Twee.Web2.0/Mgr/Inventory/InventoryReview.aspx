<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryReview.aspx.cs" Inherits="TweebaaWebApp2.Mgr.Inventory.InventoryReview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/jquery-1.7.1.min.js"></script>
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
       <legend>Product Information</legend>
       <table width="100%">
           <tr>
                 <td width="25%"><span class="tip">Product Name：</span><asp:Label ID="labproName" runat="server" Text=""></asp:Label></td>
                 <td width="25%"><span class="tip">Product Categories：</span><asp:Label ID="labproType" runat="server" Text=""></asp:Label></td>
                 <td width="25%"><span class="tip">Intellectual 
                 Property：</span><asp:Label ID="labproRight" runat="server" Text=""></asp:Label></td>
                 <td width="25%"><span class="tip">Country of Origin：</span><asp:Label ID="labAddress" runat="server" Text=""></asp:Label></td>
           </tr>
            <tr>
                 <td><span class="tip">Sample：</span><asp:Label ID="labExample" runat="server" Text=""></asp:Label><asp:Label ID="labproExampleInfo" runat="server" Text=""></asp:Label></td>
                 <td><span class="tip">MOQ：</span><asp:Label ID="labMin" runat="server" Text=""></asp:Label></td>
                 <td><span class="tip">Product ID：</span><asp:Label ID="labNum" runat="server" Text=""></asp:Label></td>
                 <td><span class="tip">Any Inventory：</span><asp:Label ID="labStock" runat="server" Text=""></asp:Label><asp:Label ID="labStockNum" runat="server" Text=""></asp:Label></td>
           </tr>
       </table>
    </fieldset>

    <fieldset>
        <legend>Product Specification and Pricing</legend>
        <table id="tbRuleAndPrice">
           <tr>
              <th style=" width:150px;">Specification</th>
              <th style=" width:40px;">Colour</th>
              <th style=" width:150px;">Barcode</th>
              <th>Supply to Tweebaa</th>
              <th style=" width:150px;">Unique ID (SKU)</th>
              <th>Product volume</th>
              <th>Product weight</th>
              <th>Number of product per master carton</th>
              <th>Master carton DIMS</th>
              <th>Master carton weight</th>
           </tr>
           <%=ph_ruleList%>
           <%--<tr>
              <td>Specification Name</td>
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
              <td align="right" valign="middle">Price Range：</td>
              <td colspan="9" align="left" valign="middle"></td>
           </tr>--%>

        </table>
    </fieldset>

    <fieldset>
        <legend>Inventory and Product Information </legend>
        <table width="100%">
           <tr>
                 <td width="25%"><span class="tip">Drop shipping provided：</span><asp:Label ID="labDaiFa" runat="server" Text=""></asp:Label></td>
                 <td width="25%"><span class="tip">Delivery Zone：</span><asp:Label ID="labFaHuaArea" runat="server" Text=""></asp:Label></td>
           </tr>
           <tr>
                 <td width="25%"><span class="tip">Overseas Warehouse：</span><asp:Label ID="labHaiWaiStock" runat="server" Text=""></asp:Label><asp:Label ID="labHaiWaiStockInfo" runat="server" Text=""></asp:Label></td>
                 <td width="25%"><span class="tip">After Sale Service：</span><asp:Label ID="labService" runat="server" Text=""></asp:Label><asp:Label ID="labServiceInfo" runat="server" Text=""></asp:Label></td>
           </tr>
           <tr>
              <td colspan="2"><span class="tip">Material：</span><asp:Label ID="labCaiZhi" runat="server" Text=""></asp:Label></td>
           </tr>
           <tr>
             <td colspan="2">
                 <span class="tip">Product Details：</span><br />
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
        <asp:Button ID="btnAccept" runat="server" Text="Accept product and set pricing" 
            onclick="btnAccept_Click" OnClientClick="javascript: return verfyIntenory()" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Reject product" 
            onclick="btnCancel_Click" />
    </div>

        <script type="text/javascript">
            function _view(proid) {
                //var id = $(obj).attr("detailid");
                var url = "Inventory/InventorySalePriceArea.aspx?proid=" + proid;
                window.parent._addTab('Supply Review', url);
            }

            function verfyIntenory() {
                var trCount = $("#tbRuleAndPrice tr").length;
                if (trCount <= 2) {
                    alert("Product is missing specs, cannot supply");
                    return false;
                } else {
                    return true;
                }
            }
        </script>
    </form>
</body>
</html>
