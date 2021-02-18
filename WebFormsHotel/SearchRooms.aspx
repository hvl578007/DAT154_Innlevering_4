<%@ Page Title="Search for rooms" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchRooms.aspx.cs" Inherits="WebFormsHotel.SearchRooms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:100%">
        <div style="float:left; width:30%">
            <div style="float:left; width:50%">
                <br />
                <asp:Label ID="Label4" runat="server" Text="Date from:"></asp:Label>
                <asp:Calendar ID="CalendarFrom" runat="server"></asp:Calendar>
                <br />
                <asp:Label ID="Label1" runat="server" Text="Beds:"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownBeds" runat="server">
                    <asp:ListItem Value="1" Selected="True">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5 (error)</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="float:right; width:49%">
                <br />
                <asp:Label ID="Label5" runat="server" Text="Date to:"></asp:Label>
                <asp:Calendar ID="CalendarTo" runat="server"></asp:Calendar>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Quality:"></asp:Label>
                <br />
                <asp:RadioButtonList ID="RadioQuality" runat="server">
                    <asp:ListItem Value="0" Selected="True">Ok</asp:ListItem>
                    <asp:ListItem Value="1">Good</asp:ListItem>
                    <asp:ListItem Value="2">Amazing</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <br />
            <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
        </div>
        <div style="float:right; width:70%">
            <br />
            <asp:Label ID="Label3" runat="server" Text="Avaliable rooms"></asp:Label>
            <asp:GridView ID="GridViewRooms" runat="server" OnSelectedIndexChanged="GridViewRooms_SelectedIndexChanged" OnRowUpdating="GridViewRooms_RowUpdating">
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="Update" HeaderText="BookButton" ShowHeader="True" Text="Book" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="SelectReservation" runat="server" Text="Book" OnClick="SelectReservation_Click" Visible="false" />
        </div>
    </div>
</asp:Content>
