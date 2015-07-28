<%@ Page Title="" Language="C#" MasterPageFile="~/OEM.Master" AutoEventWireup="true" CodeBehind="errors.aspx.cs" Inherits="OnlinExpenseManager.errors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Sorry !!!!</h1>
    <h2><asp:Label ID="lblError" runat="server">Something went wrong when we tried to fulfill your request, but we are on it.</asp:Label></h2>
</asp:Content>
