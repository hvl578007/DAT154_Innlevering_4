<%@ Page Title="Logged in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoggedIn2.aspx.cs" Inherits="WebFormsHotel.LoggedIn2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Button ID="SearchButton" runat="server" Text="Search for rooms" OnClick="Search_Click" />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
