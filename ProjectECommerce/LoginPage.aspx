<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ClientMasterPage.Master" CodeBehind="LoginPage.aspx.vb" Inherits="ProjectECommerce.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h1>Login Page</h1>
        <table>
            <tr>
                <td>
                        UserName
                </td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username is required" Text="*" ControlToValidate="txtUsername" ValidationGroup="login"/>

                </td>
            </tr>

            <tr>
                <td>
                    Password
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is required" Text="*" ControlToValidate="txtPassword" ValidationGroup="login"/>
                </td>
            </tr>
        </table>
     
       
        <br />

        <asp:Button CssClass="button" ID="btnLogin" runat="server" Text="LogIn" />

        <br />
</asp:Content>
