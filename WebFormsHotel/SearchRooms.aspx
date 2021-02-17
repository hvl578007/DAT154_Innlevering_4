<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchRooms.aspx.cs" Inherits="WebFormsHotel.SearchRooms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:100%">
        <div style="float:left; width:30%">
            <br />
            <asp:Label ID="Label4" runat="server" Text="Date from:"></asp:Label>
            <asp:Calendar ID="CalendarFrom" runat="server"></asp:Calendar>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Date to:"></asp:Label>
            <asp:Calendar ID="CalendarTo" runat="server"></asp:Calendar>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Beds:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxBeds" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Quality:"></asp:Label>
            <br />
            <asp:RadioButtonList ID="RadioQuality" runat="server">
                <asp:ListItem Value="0">Ok</asp:ListItem>
                <asp:ListItem Value="1">Good</asp:ListItem>
                <asp:ListItem Value="2">Amazing</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
        </div>
        <div style="float:right; width=70%">
            <br />
            <asp:Label ID="Label3" runat="server" Text="Avaliable rooms"></asp:Label>
            <asp:GridView ID="GridViewRooms" runat="server" OnSelectedIndexChanged="GridViewRooms_SelectedIndexChanged"></asp:GridView>
            <asp:Button ID="SelectReservation" runat="server" Text="Book" OnClick="SelectReservation_Click" />
        </div>
    </div>
</asp:Content>
