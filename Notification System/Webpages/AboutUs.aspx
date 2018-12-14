<%@ Page Title="" Language="C#" MasterPageFile="~/Webpages/Home.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="Webpages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        
    <div id="left1" style="height:100%; float:left; width:3%">

    </div>
    <br /><br />
    <div id="left" style="height:50%; float:left; width:27%; border:dotted; text-align:center">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/3.png"  />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Mohit Kumar" Font-Bold="True" Font-Italic="True"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Email: mohit.singlapup@gmail.com"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Mobile Number: 7696594066"></asp:Label>
    
    </div>
    
    <div id="Center" style="height:50%; float:left; width:27%; border:dotted; text-align:center">
          <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/3.png"  />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Name: "></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="Mohit Bansal" Font-Italic="True" Font-Bold="True"></asp:Label>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Email: mohittbansall@gmail.com"></asp:Label>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Mobile Number: 7837295375"></asp:Label>
    </div>
    
    <div id="Right" style="height:50%; float:left; width:27%; border:dotted; text-align:center">
          <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/3.png"  />
        <br />
        <asp:Label ID="Label9" runat="server" Text="Name: "></asp:Label>
        <asp:Label ID="Label10" runat="server" Text="Sanjib Kumar Mandol" Font-Bold="True" Font-Italic="True"></asp:Label>
        <br />
        <asp:Label ID="Label11" runat="server" Text="Email: mandol9892@gmail.com"></asp:Label>
        <br />
        <asp:Label ID="Label12" runat="server" Text="Mobile Number: 9041819892"></asp:Label>
    </div>
        
</asp:Content>

