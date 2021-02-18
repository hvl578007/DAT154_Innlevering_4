<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultNy.aspx.cs" Inherits="WebFormsHotel.DefaultNy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="col-md-4">
            <h1>Welcome to hotell exellence booking</h1>
            <p>
                Here you can make a search for available rooms and make a booking at your chosen time. <br />
                Just log in or create a new user to book your room.
            </p>
        </div>

        <div class="row">
        <!-- Logger inn eksisterende bruker. må koble seg opp mot databasen og finne brukeren -->
            <h3>Log In</h3>
            <fieldset>
                <asp:TextBox ID="UserName" runat="server" Text="User name" ></asp:TextBox>
                <asp:Button ID="LoginButton" runat="server" Text="Log In" OnClick="Login_Click" ></asp:Button>
                <asp:Label ID="UserNotExists" runat="server" Visible="false" >Brukeren finnes ikke!</asp:Label>
            </fieldset>
         </div>

        <div class="row">
        <!-- Lager Ny bruker. må koble seg opp mot databasen og legge til bruker -->
            <h3>Create New User</h3>
             <fieldset>
                 <asp:TextBox ID="Name" runat="server" Text="Name" ></asp:TextBox>
                 <asp:TextBox ID="NewUserName" runat="server" Text="New User name" ></asp:TextBox>
                 <asp:Button ID="CreateUser" runat="server" Text="Create User" OnClick="CreateUser_Click" ></asp:Button>
                 <asp:Label ID="UserExists" runat="server" Visible="false" >Brukeren finnes allerede!</asp:Label>
            </fieldset>
        </div>
    </div>

</asp:Content>