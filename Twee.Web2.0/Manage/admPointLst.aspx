<%@ Page Title=""  Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true" CodeBehind="admPointLst.aspx.cs" Inherits="TweebaaWebApp2.Manage.admPointLst" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="js/admPointLst.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
    <table style="padding: 0px; margin: 0px;">
        <tr>
            <td>
                user name：
            </td>
            <td>
                <input id="txtName_s" type="text" class="t1" />
            </td>
            <td style="width: 60px;">
                email：
            </td>
            <td>
                <input id="txtEmail_s" type="text" class="t1" />
            </td>
            <td>
                stat
            </td>
            <td>
                <select id="drpState_s">
                    <option value="">--全部--</option>
                    <option value="0">锁定</option>
                    <option value="1">正常</option>
                    <option value="2">未激活</option>
                </select>
            </td>
            <td style="padding-left: 5px; text-align: left;">
                <a id="aFind" class="aFind" href="javascript:void(0)">Search</a> <a id="aAll" class="aAll"
                    href="javascript:void(0)">Refresh</a>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" runat="Server">
    <div id="jqueryData">
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" runat="Server">
   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" runat="Server">
  
</asp:Content>

