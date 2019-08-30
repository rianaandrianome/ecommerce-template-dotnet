<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ClientMasterPage.Master" CodeBehind="ClientPaymentPage.aspx.vb" Inherits="ProjectECommerce.ClientPaymentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



  <asp:DataList ID="DataList1" runat="server" RepeatLayout="Table" RepeatColumns="4" CellPadding="2" CellSpacing="2"> 
    <ItemTemplate> 
        <table cellpadding="2" cellspacing="0" border="1" style="width: 200px; height: 100px; border: solid 2px #04AFEF;"> 
            <tr> 
                <td colspan="2"> 
                    <asp:Image ID="Image1" ImageUrl='<%# Eval("image") %>' runat="server" Height="200" Width="300" /> 
                </td> 
            
            </tr> 
            <tr>
                <td><b>Product </b></td>
                <td><asp:Label ID="labelProduct" runat="server" Text='<%# Eval("product") %>'/></td>
            </tr>
            <tr>
                <td><b>Price </b></td>
                <td><asp:Label ID="labelUnitPrice" runat="server" Text='<%# Eval("unitPrice") %>'/></td>
            </tr>
            <tr>
                <td><b>Quantity </b></td>
                <td><asp:Label ID="labelQuantity" runat="server" Text='<%# Eval("quantity") %>'/></td>
            </tr>
        </table> 
     </ItemTemplate> 
</asp:DataList> 

    <%--invisible label to store current user ID --%>
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" ></asp:Label>


    <br /><br />
    Enter your shipping address <asp:TextBox ID="txtShippingAddress" runat="server"></asp:TextBox>

    <br /><br />
    <asp:Button CssClass="button" ID="ButtonPay" runat="server" Text="Pay Now" OnClick="ButtonPay_Click"/>

    <br /><br />
    <br /><br />
</asp:Content>
