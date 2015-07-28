<%@ Page Title="" Language="C#" MasterPageFile="~/OEM.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="OnlinExpenseManager._404" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="has-error">
        <h2 class="danger"><asp:Label ID="lblError" runat="server">The page or Directory you're trying to access is temporary unavailable, Please allow us to maintain it.</asp:Label></h2>
    </div>
</asp:Content>
