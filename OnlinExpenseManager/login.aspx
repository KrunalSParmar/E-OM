<%@ Page Title="" Language="C#" MasterPageFile="~/OEM.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="OnlinExpenseManager.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Login</h1>
    <div class="form-group-lg">
        <asp:Label ID="lblStatus" runat="server" CssClass="label label-danger" />
    </div>
    <div class="form-group">
        <label for="txtUsername" class="col-sm-2">Email:</label>
        <asp:TextBox ID="txtUsername" runat="server" />
    </div>
    <div class="form-group">
        <label for="txtPassword" class="col-sm-2">Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="password" />
    </div>
    <div class="col-sm-offset-2">
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary"
            OnClick="btnLogin_Click" />
    </div>
    <div class="hidden">
        <asp:TextBox ID="ErrorMsgTextBox" runat="server" Visible="false"></asp:TextBox>
    </div>
</asp:Content>
