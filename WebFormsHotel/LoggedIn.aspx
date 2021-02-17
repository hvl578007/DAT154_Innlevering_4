<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoggedIn.aspx.cs" Inherits="WebFormsHotel.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Button ID="SearchButton" runat="server" Text="Search for rooms" />
    <br />
    <br />
    <asp:GridView ID="GridViewReservations" runat="server"></asp:GridView>
</asp:Content>
