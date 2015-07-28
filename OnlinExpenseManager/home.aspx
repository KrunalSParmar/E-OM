<%@ Page Title="" Language="C#" MasterPageFile="~/OEM.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="OnlinExpenseManager.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Expense Manager</h1>
    <div class="well">
        This online application is for your personal use, No bank information required, please read following before start for guidance.

        <h3>Read Me</h3>
        <ol>
            <li>This application is for your personal use so you can keep record 
                of your expenses and make a budget for month or week.
            </li>
            <li>
                When you register enter your Credit Card balance and Debit Card Balance accurate
                for better reports and statement
                <blockquote>(NOTE:- we don't want any personal account information this is for your betterment).</blockquote>
            </li>
            <li>
                Try to submit all expense at the end of the day, because system keep records for dates automatically.
            </li>
            <li>
                When you receive any kind of money make sure you go to Manage Accounts tab and add it to appropriet account.
                <ul>
                    <li>Income will go to Debit account, such as Salary, Tax-Refund, Etc.</li>
                    <li>Refund will go accordingly, if refunded to Debit put it to Debit account or to Credit Account</li>
                </ul>
            </li>
            <li>
                We will update more feature in future such as.
                <ul>
                    <li>Exporting your statements and reports to Excel and Pdf to download and keep save.</li>
                    <li>Login with Facebook and Gmail account.</li>
                    <li>Get your data E-mail to you.</li>
                </ul>
            </li>
        </ol>
    </div>

    <asp:TextBox ID="ErrorMsgTextBox" runat="server" Visible="false"></asp:TextBox>
</asp:Content>
