<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ClientMasterPage.Master" CodeBehind="ClientBlockedPage.aspx.vb" Inherits="ProjectECommerce.ClientBlockedPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <h4 style="color:red;">Sorry! Your Access has been blocked</h4>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/blocked.png" Width="500px" Height="250px"/>

    <br />
</asp:Content>
