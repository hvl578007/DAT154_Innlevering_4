<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebFormsHotel.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your Bookings:</h3>
    <asp:GridView ID="BookingsGrid" runat="server"></asp:GridView>

    <div class="row">
         <asp:Calendar ID="BookingCalendar" runat="server"></asp:Calendar>
         <asp:Button ID="BookingBTN" runat="server" Text="Search" OnClick="BookingBTN_Click" />
    </div>

</asp:Content>
