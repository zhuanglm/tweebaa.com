﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/mstMyAdm.Master"  AutoEventWireup="true" CodeBehind="admReviewgradeparam.aspx.cs" Inherits="TweebaaWebApp.Manage.admReviewgradeparam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" Runat="Server">
当前位置：等级管理 》评审区等级积分配置
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphGv" Runat="Server">
<div style=" width:100%;">
 <input type="button" id="btnInsert" runat="server" value="添加等级" class="btnSerch"  style=" width:100px; height:30px;" onserverclick="btnInsert_Click" />

<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
        <br />
            <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="False" DataKeyNames="guid"
                Width="99%" CellPadding="4" ForeColor="#333333" GridLines="Both" RowStyle-HorizontalAlign="Center" OnRowDeleting="gridData_RowDeleting"
                OnRowEditing="gridData_RowEditing" OnRowUpdating="gridData_RowUpdating" OnRowCancelingEdit="gridData_RowCancelingEdit"
                OnRowDataBound="gridData_RowDataBound"  >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="guid" HeaderText="编号" ReadOnly="true" Visible="false" />
                    <asp:BoundField DataField="guid" Visible="false" />
                    <asp:BoundField DataField="grade" HeaderText="等级" />
                    <asp:BoundField DataField="integral" HeaderText="等级积分" />
                    <asp:BoundField DataField="reviewreward" HeaderText="评审奖励积分值" />
                    <asp:BoundField DataField="commissionratio1" HeaderText="佣金比例1 %" />
                    <asp:BoundField DataField="commissionratio2" HeaderText="佣金比例2 %" />
                    <asp:BoundField DataField="commissionratio3" HeaderText="佣金比例3 %" />
                    <asp:CommandField HeaderText="选择" ShowSelectButton="True" />
                    <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" CssClass="Freezing" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPage" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOther" Runat="Server">
</asp:Content>

