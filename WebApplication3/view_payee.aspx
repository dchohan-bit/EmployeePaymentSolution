<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="view_payee.aspx.cs" Inherits="WebApplication3.view_boards" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <h1 id="title" runat="server">VIEW PAYEE</h1>
    <p runat="server">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="145px" Width="901px" DataKeyNames="payeeID" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
            <Columns>
                <asp:BoundField DataField="payeeID" HeaderText="payeeID" InsertVisible="False" ReadOnly="True" SortExpression="payeeID" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT * FROM [payee] WHERE ([payeeID] = @Id)">
            <SelectParameters>
                <asp:SessionParameter Name="Id" SessionField="currentItem" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <h3>Make Payment</h3>
    <article>
        <p>        
            <asp:Label ID="Label1" runat="server" Text="Label">Amount</asp:Label><asp:TextBox ID="txtAmount" runat="server" Width="651px"></asp:TextBox>
        </p>


        <p>        
            <asp:Button ID="Button1" runat="server" Text="MAKE PAYMENT" OnClick="Button1_Click" />
        </p>
    </article>

</asp:Content>
