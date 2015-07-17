<%@ Page Title="" Language="C#" MasterPageFile="~/OEM.Master" AutoEventWireup="true" CodeBehind="expense.aspx.cs" Inherits="OnlinExpenseManager.expense" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Enter your express entry below</h1>
    <h4>All Field Required</h4>
    <h4><asp:Label ID="welcomUser" runat="server"></asp:Label></h4>
    <div class="form-group">
        <label for="ddlExpense" class="col-sm-2">Expense Catagory:</label>
        <asp:DropDownList ID="ddlExpense" runat="server" AutoPostBack="false">
            <asp:ListItem Text="Phone Bill" Value="Phone Bill"></asp:ListItem>
            <asp:ListItem Text="Grocery" Value="Grocery"></asp:ListItem>
            <asp:ListItem Text="Fuel" Value="Fuel"></asp:ListItem>
            <asp:ListItem Text="Insurance" Value="Insurance"></asp:ListItem>
            <asp:ListItem Text="Food" Value="Food"></asp:ListItem>
            <asp:ListItem Text="Drink" Value="Drink"></asp:ListItem>
            <asp:ListItem Text="Hotel" Value="Hotel"></asp:ListItem>
            <asp:ListItem Text="Personal" Value="Personal"></asp:ListItem>
            <asp:ListItem Text="Others" Value="Other"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="ddlAccountType" class="col-sm-2">Account Type:</label>
        <asp:DropDownList ID="ddlAccountType" runat="server" AutoPostBack="false">
            <asp:ListItem Text="Credit" Value="Crdit"></asp:ListItem>
            <asp:ListItem Text="Debit" Value="Debit"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="txtAmount" class="col-sm-2">Amount</label>
        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
    </div>
    <div class="col-sm-offset-2">
        <asp:Button ID="btnLogin" runat="server" Text="Submit Expense" CssClass="btn btn-primary"
            OnClick="btnExpense_Click" />
    </div>
</asp:Content>
