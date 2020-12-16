<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="WebApplication3.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>ADD Employee</h1>
    </hgroup>

    <article>
        <p>        
            <asp:Label ID="Label1" runat="server" Text="Label">Name</asp:Label><asp:TextBox ID="txtName" runat="server" Width="651px"></asp:TextBox>
        </p>
         <p>        
            <asp:Label ID="Label2" runat="server" Text="Label">Email</asp:Label><asp:TextBox ID="txtEmail" runat="server" Width="651px"></asp:TextBox>
        </p>


        <p>        
            <asp:Button ID="Button1" runat="server" Text="ADD Employee" OnClick="Button1_Click" />
        </p>
    </article>
</asp:Content>