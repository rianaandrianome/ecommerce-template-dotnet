<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ClientMasterPage.Master" CodeBehind="ClientProductDetailPage.aspx.vb" Inherits="ProjectECommerce.ClientProductDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <div>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server"  ConnectionString="<%$ ConnectionStrings:ConnStr %>" SelectCommand="SELECT * FROM [Product]  WHERE ([productID] = @productID)"> 
        
                 <SelectParameters> 
                        <asp:QueryStringParameter Name="productID"  QueryStringField="productID"  Type="Int32" /> 
                 </SelectParameters> 

        </asp:SqlDataSource> 
    
    </div> 
    
    <br /><br />
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1"> 
        <ItemTemplate> 
            <table>
                <tr>
                    <td><b></b></td>
                    <td><asp:Image ID="Image1" runat="server"  ImageUrl='<%# Eval("ImageUrl") %>'/></td>
                </tr>
                <tr>
                    <td><b>Product</b></td>
                    <td><asp:Label ID="lblProductName" runat="server"  Text='<%# Eval("productName") %>'/></td>
                </tr>
                <tr>
                    <td><b>Price</b></td>
                    <td><b>$  <asp:Label ID="lblPrice" runat="server"  Text='<%# Eval("unitPrice", "{0:##0.00}") %>'/></b></td>
                </tr>
                <tr>
                    <td><b>Color</b></td>
                    <td><asp:Label ID="lblColor" runat="server"  Text='<%# Eval("color") %>'/> </td>
                </tr>
                <tr>
                    <td><b>Size</b></td>
                    <td><asp:Label ID="lblSize" runat="server"  Text='<%# Eval("size") %>'/></td>
                </tr>
                <tr>
                    <td><b>Brand</b></td>
                    <td><asp:Label ID="lblBrand" runat="server"  Text='<%# Eval("brand") %>'/></td>
                </tr>
                <tr>
                    <td><b>Description</b></td>
                    <td><asp:Label ID="lblDescription" runat="server"  Text='<%# Eval("description") %>'/></td>
                </tr>
            </table>
            </ItemTemplate> 
     </asp:DataList>

    <br /><br />
    <%--label holding current user ID--%>
    <asp:Label ID="Label1" runat="server" Text="" Visible="false" />

     <br /><br />

    <asp:Button CssClass="button" ID="ButtonAddToCart" runat="server" OnClick="ButtonAddToCart_Click" Text="Add To Cart" width="300"/>
    <br />
    <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
    <br /><br />

    <asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl="~/ClientProductPage.aspx">Return to Products Page</asp:HyperLink> 

    <br /><br /><br />

</asp:Content>
