<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Home.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Webpages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   
        <br /><br /><br />
        <div style="border-style: groove; text-align:center; text-align:center">
            <br />
            <asp:Label ID="Label1" runat="server" Text="Enter UserName"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="Label2" runat="server" Text="Enter Password"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember Me" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Height="48px" OnClick="Button1_Click" Text="Login" Width="110px" />
        
    &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Label"></asp:Label>
        
    </div>
</asp:Content>

