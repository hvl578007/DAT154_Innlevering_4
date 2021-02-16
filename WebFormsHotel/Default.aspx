<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsHotel._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="col-md-4">
            <h1>Welcome to hotell exellence booking</h1>
            <p>
                Here you can make a search for available rooms and make a booking at your chosen time. <br />
                Just log in or create a new user to book your room.
            </p>
            <!-- Logger inn eksisterende bruker. må koble seg opp mot databasen og finne brukeren -->
            <fieldset>
                <asp:TextBox ID="UserName" Text="User name" runat="server"></asp:TextBox>
                <asp:Button ID="LoginButton" Text="Log In" OnClick="Login_Click" runat="server"></asp:Button>
            </fieldset>
        </div>

        <div class="row">
        <!-- Lager Ny bruker. må koble seg opp mot databasen og legge til bruker -->
            <h3>Create New User</h3>
             <fieldset>
                <asp:TextBox ID="Name" Text="Name" runat="server"></asp:TextBox>
                <asp:TextBox ID="NewUserName" Text="New User name" runat="server"></asp:TextBox>
                <asp:Button ID="CreateUser" Text="Create User" OnClick="Login_Click" runat="server"></asp:Button>
            </fieldset>
        </div>
    </div>

</asp:Content>