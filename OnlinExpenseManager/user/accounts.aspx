<%@ Page Title="" Language="C#" MasterPageFile="~/OEM.Master" AutoEventWireup="true" CodeBehind="accounts.aspx.cs" Inherits="OnlinExpenseManager.accounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="label-primary">Welcome<asp:Label ID="lblWelcome" runat="server"></asp:Label></h1>
    <h3>You can update your Account here and check available balance in your accounts</h3>
    <div class="badge" title="Account Info.">
        <h4 class="">
            <asp:Label ID="lblCreditBalance" runat="server" Text="Credit Balance: "></asp:Label>
        </h4>
        <h4 class="">
            <asp:Label ID="lblDebitBalance" runat="server" Text="Debit Balance: "></asp:Label>
        </h4>
    </div>
    <h3>Update your Account</h3>
    <div class="form-group">
        <label for="ddlAccountType" class="col-sm-2">Account Type:</label>
        <asp:DropDownList ID="ddlAccountType" runat="server" AutoPostBack="false">
            <asp:ListItem Text="Credit" Value="Credit"></asp:ListItem>
            <asp:ListItem Text="Debit" Value="Debit"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="txtAmount" class="col-sm-2">Amount</label>
        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
    </div>
    <div class="col-sm-offset-2">
        <asp:Button ID="btnLogin" runat="server" Text="Update Account" CssClass="btn btn-primary"
            OnClick="btnExpense_Click" />
    </div>
</asp:Content>
