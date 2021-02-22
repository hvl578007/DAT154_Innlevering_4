<%@ Page Title="Search for rooms" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchRooms.aspx.cs" Inherits="WebFormsHotel.SearchRooms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="width:100%">
        <div style="float:left; width:40%">
            <div style="float:left; width:46%">
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
            <div style="float:left; width:46%">
                <br />
                <asp:Label ID="Label5" runat="server" Text="Date to:"></asp:Label>
                <asp:Calendar ID="CalendarTo" runat="server"></asp:Calendar>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Quality:"></asp:Label>
                <br />
                <asp:RadioButtonList ID="RadioQuality" runat="server">
                    <asp:ListItem Value="0" Selected="True">Ok (0)</asp:ListItem>
                    <asp:ListItem Value="1">Good (1)</asp:ListItem>
                    <asp:ListItem Value="2">Amazing (2)</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <br />
            <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
        </div>
        <div style="float:right; width:60%">
            <br />
            <asp:Label ID="Label3" runat="server" Text="Avaliable rooms"></asp:Label>
            <asp:GridView ID="GridViewRooms" runat="server" OnSelectedIndexChanged="GridViewRooms_SelectedIndexChanged" OnRowUpdating="GridViewRooms_RowUpdating" OnRowDataBound="GridViewRooms_RowDataBound" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="Update" HeaderText="" ShowHeader="True" Text="Book" />
                    <asp:BoundField DataField="NumOfBeds" HeaderText="Beds" />
                    <asp:BoundField DataField="Size" HeaderText="Quality" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:Button ID="SelectReservation" runat="server" Text="Book" OnClick="SelectReservation_Click" Visible="false" />
        </div>
    </div>
</asp:Content>
