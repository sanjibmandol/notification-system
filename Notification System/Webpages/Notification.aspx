<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Home.master" AutoEventWireup="true" CodeFile="Notification.aspx.cs" Inherits="Webpages_Default" %>


    

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="Button2" runat="server" Text="Logout" OnClick="Button2_Click" /><br /><br />
    <asp:Panel ID="p1" runat="server" BorderStyle="Dashed">
    <p>
        
        <br /><br /><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Select Category"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="1">All</asp:ListItem>
            <asp:ListItem Value="2">Employee Only</asp:ListItem>
            <asp:ListItem Value="3">Customer Only</asp:ListItem>
        </asp:DropDownList>
&nbsp;(Employee, Customer)<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <p style="margin-left: 160px">
        <asp:Label ID="Label4" runat="server" Text="SMS/ Email"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            <asp:ListItem Value="1">Both</asp:ListItem>
            <asp:ListItem Value="2">SMS Only</asp:ListItem>
            <asp:ListItem Value="3">Email Only</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
    </p>
        <p style="margin-left: 160px">
        <asp:Label ID="Label5" runat="server" Text="Email Subject"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </p>

            </ContentTemplate>
    </asp:UpdatePanel>
            <p style="margin-left: 160px">
        <asp:Label ID="Label3" runat="server" Text="Enter Message"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Height="51px" TextMode="MultiLine"></asp:TextBox>
    </p>


    <p style="margin-left: 280px">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send" />
    </p>
    <p style="margin-left: 280px">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    </p>
    </asp:Panel>
</asp:Content>

