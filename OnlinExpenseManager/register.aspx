<%@ Page Title="" Language="C#" MasterPageFile="~/OEM.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="OnlinExpenseManager.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Register</h1>
    <h5>All fields are required</h5>

    <div class="form-group-lg">
        <asp:label id="lblStatus" runat="server" cssclass="label label-danger" />
    </div>
    <div class="form-group">
        <label for="txtEmail" class="col-sm-2">Email:</label>
        <asp:textbox id="txtEmail" runat="server" />
    </div>
    <div class="form-group">
        <label for="txtPassword" class="col-sm-2">Password:</label>
        <asp:textbox id="txtPassword" runat="server" textmode="password" />
    </div>
    <div class="form-group">
        <label for="txtConfirm" class="col-sm-2">Confirm Password:</label>
        <asp:textbox id="txtConfirm" runat="server" textmode="password" />
        <asp:comparevalidator runat="server" operator="Equal" controltovalidate="txtPassword"
            controltocompare="txtConfirm" cssclass="label label-danger" errormessage="Passwords must match" />
    </div>
     <div class="form-group">
        <label for="txtFName" class="col-sm-2">First Name:</label>
        <asp:textbox id="txtFName" runat="server" />
    </div>
    <div class="form-group">
        <label for="txtLName" class="col-sm-2">Last Name:</label>
        <asp:textbox id="txtLName" runat="server" />
    </div>
    <div class="form-group">
        <label for="txtPhone" class="col-sm-2">Phone:</label>
        <asp:textbox id="txtPhone" runat="server" MaxLength="10" />
    </div>
    <div class="form-group">
        <label for="txtCredit" class="col-sm-2">Credit Account Balance:</label>
        <asp:textbox id="txtCredit" runat="server" />
    </div>
    <div class="form-group">
        <label for="txtDebit" class="col-sm-2">Debit Account Balance:</label>
        <asp:textbox id="txtDebit" runat="server" />
    </div>
    <div class="col-sm-offset-2">
        <asp:button id="btnRegister" runat="server" text="Register" cssclass="btn btn-primary" 
            OnClick="btnRegister_Click" />
    </div>
</asp:Content>
