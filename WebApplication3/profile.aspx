<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="WebApplication3.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Profile</h2>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Width="790px">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
            <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
            <asp:BoundField DataField="userType" HeaderText="userType" SortExpression="userType" />
            <asp:BoundField DataField="lastLogin" HeaderText="lastLogin" SortExpression="lastLogin" />
        </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT * FROM [users] WHERE ([username] = @username)">
            <SelectParameters>
                <asp:SessionParameter Name="username" SessionField="user" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <h2>Update Profile</h2>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Username"></asp:Label>
     </p>  
    <p>
        <input ID="txtUsername" type="text" runat="server" />
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
     </p>  
    <p>
        <input ID="txtName" type="text" runat="server" />
    </p>

    <p>
        <asp:Label ID="Label1" runat="server" Text="New Password"></asp:Label>
     </p>  
    <p>
        <input ID="txtPassword" type="password" runat="server" />
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Change Password" OnClick="Button1_Click" />
    </p>
</asp:Content>
