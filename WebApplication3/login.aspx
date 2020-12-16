<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication3.login" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>User Login</h1>
        
    </hgroup>
    <h2>Fill form to login to your account</h2>
    <article>
        <p>        
            <asp:Label ID="Label1" runat="server" Text="Label">Username</asp:Label><asp:TextBox ID="TxtUsername" runat="server"></asp:TextBox>
        </p>

        <p>        
            <asp:Label ID="Label4" runat="server" Text="Label">Password</asp:Label><asp:TextBox ID="TxtPassword" runat="server"></asp:TextBox>
        </p>


        <p>        
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
        </p>
    </article>
</asp:Content>