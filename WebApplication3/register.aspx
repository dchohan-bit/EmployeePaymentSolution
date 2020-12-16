<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebApplication3.register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>User Registration</h1>
        
    </hgroup>
    <h2>Fill form to create an account</h2>
    <article>
        <p>        
            <asp:Label ID="Label3" runat="server" Text="Label">Name</asp:Label><asp:TextBox ID="txtName" runat="server" Width="654px"></asp:TextBox>
        </p>
        <p>        
            <asp:Label ID="Label1" runat="server" Text="Label">Username</asp:Label><asp:TextBox ID="txtUsername" runat="server" Width="651px"></asp:TextBox>
        </p>

        <p>        
            <asp:Label ID="Label4" runat="server" Text="Label">Password</asp:Label><asp:TextBox ID="txtPassword" runat="server" Width="651px"></asp:TextBox>
        </p>
       <p>        
            <asp:Label ID="Label2" runat="server" Text="Label">User Type</asp:Label>
              <asp:DropDownList ID="userType" runat="server" DataTextField="DataSourceField" DataValueField="DataSourceField"  Width="651px" Height="44px">
                <asp:ListItem >Normal</asp:ListItem> 
                <asp:ListItem >Admin</asp:ListItem> 
            </asp:DropDownList>  
        </p>

        <p>        
            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
        </p>
    </article>
</asp:Content>