<%@ Page Title="" Language="C#" MasterPageFile="~/OEM.Master" AutoEventWireup="true" CodeBehind="reports.aspx.cs" Inherits="OnlinExpenseManager.reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Text Box to select Date Range-->
    <div class="badge panel-info">
        <label>NOTE:- Select Fields for specific date range for report make sure to select both dates.</label>
    </div>
    <div class="bg-info">
        <label for="txtStartDate">Start Date: </label>
        <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date"></asp:TextBox>
        <label for="txtEndDate">End Date: </label>
        <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date"></asp:TextBox>
        <asp:Button ID="btngo" runat="server" OnClick="btnGo_Click" Text="GO" />
    </div>
    <!-- Grid to Display Report -->
    <div>
        <h1>Report:<asp:Label ID="lblReportType" runat="server"></asp:Label></h1>
        <asp:GridView ID="grdExpense" runat="server" CssClass="table table-striped table-hover"
            AutoGenerateColumns="false" DataKeyNames="ExpID">
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
</asp:Content>
