<%@ Page Title="Logged in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoggedIn2.aspx.cs" Inherits="WebFormsHotel.LoggedIn2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2><asp:Label ID="WelcomeLabel" runat="server"></asp:Label></h2>
    <br />
    <asp:Button ID="SearchButton" runat="server" Text="Search for rooms" OnClick="Search_Click" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Your bookings:"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="ReservationId" HeaderText="Reservation num " />
            <asp:BoundField DataField="DateStart" HeaderText="Date start" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="DateEnd.Date" HeaderText="Date end" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="CheckedIn" HeaderText="Checked in?" />
            <asp:BoundField DataField="CheckedOut" HeaderText="Checked out?" />
            <asp:BoundField DataField="RoomRoomId" HeaderText="Room num" />
            <asp:BoundField DataField="Room.NumOfBeds" HeaderText="Beds" />
            <asp:BoundField DataField="Room.Size" HeaderText="Quality" />
        </Columns>
    </asp:GridView>
</asp:Content>
