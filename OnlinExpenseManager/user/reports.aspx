﻿<%@ Page Title="" Language="C#" MasterPageFile="~/OEM.Master" AutoEventWireup="true" CodeBehind="reports.aspx.cs" Inherits="OnlinExpenseManager.reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="label-primary">Welcome<asp:Label ID="lblWelcome" runat="server"></asp:Label></h1>
    <!-- Text Box to select Date Range-->
    <div class="badge panel-info">
        <label>NOTE:- Select Fields for specific date range for report make sure to select both dates.</label>
    </div>
    <div class="bg-info">
        <label for="txtStartDate">Start Date: </label>
        <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date"></asp:TextBox>
        <label for="txtEndDate">End Date: </label>
        <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date"></asp:TextBox>
        <!-- Drop Down to filter Report by Account type-->
        <label>Select account type.: </label>
        <asp:DropDownList ID="ddlAccountType" runat="server"
            OnSelectedIndexChanged="ddlAccountType_SelectedIndexChanged">
            <asp:ListItem Text="Credit" Value="Credit"></asp:ListItem>
            <asp:ListItem Text="Debit" Value="Debit"></asp:ListItem>
            <asp:ListItem Text="All Expense" Value="All Expense" Selected="True"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button CssClass="btn-success" ID="btngo" runat="server" OnClick="btnGo_Click" Text="GO" />
    </div>
    <!-- Grid to Display Report -->

    <div>
        <h1>Report:<asp:Label ID="lblReportType" runat="server"></asp:Label></h1>
        <label for="ddlPageSize">Record Per Page:</label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Value="3" Text="3" />
            <asp:ListItem Value="5" Text="5" />
            <asp:ListItem Value="99999" Text="All" />
        </asp:DropDownList>
        <asp:GridView ID="grdExpense" runat="server" CssClass="table table-striped table-hover"
            AutoGenerateColumns="false" DataKeyNames="ExpID" PageSize="3"
            AllowPaging="true" OnPageIndexChanging="grdExpense_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="ExpID" HeaderText="Expense Record NO." />
                <asp:BoundField DataField="ExpType" HeaderText="Expense Type" />
                <asp:BoundField DataField="Date" HeaderText="Expense Date" DataFormatString="{0:MM-dd-yyyy}" />
                <asp:BoundField DataField="ExpAmount" HeaderText="Amount" />
                <asp:BoundField DataField="AccountType" HeaderText="Account Type" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblNoDataGrd" runat="server"></asp:Label>
    </div>

    <!--
    <div>
        <asp:Button ID="btnExport" CssClass="btn-success" runat="server" Text="Export To Word" OnClick="ExportToPDF" />
    </div>
    -->
    <div class="hidden">
        <asp:TextBox ID="ErrorMsgTextBox" runat="server" Visible="false"></asp:TextBox>
    </div>
</asp:Content>
