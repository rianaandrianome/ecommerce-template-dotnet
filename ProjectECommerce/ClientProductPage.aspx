<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ClientMasterPage.Master" CodeBehind="ClientProductPage.aspx.vb" Inherits="ProjectECommerce.ClientProductPage" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br/>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ClientCartPage.aspx" Font-Bold="True" Font-Size="Large" ForeColor="White" BackColor="#003366">Go To My Cart</asp:HyperLink> 
    <br />
    <asp:Button CssClass="button" ID="btnShowAll" runat="server" Text="Show All Products" OnClick="btnShowAll_Click"/>

    <br />
    <asp:DropDownList CssClass="ddl" ID="DDLCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLCategory_SelectedIndexChanged" ></asp:DropDownList>
    <asp:DropDownList CssClass="ddl" ID="DDLBrand" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLBrand_SelectedIndexChanged" ></asp:DropDownList>
    <asp:DropDownList CssClass="ddl" ID="DDLPrice" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLPrice_SelectedIndexChanged" >
             <asp:ListItem ID="PRange" runat="server" Value="0" Text="--Filter By Price--" />
             <asp:ListItem ID="HtoT"   runat="server" Value="1" Text="Rs 1      To Rs 1,000" />
             <asp:ListItem ID="TtoFT"  runat="server" Value="2" Text="Rs 1,000  To Rs 5,000" /> 
             <asp:ListItem ID="FTtoTT" runat="server" Value="3" Text="Rs 5,000  To Rs 10,000" />
             <asp:ListItem ID="TTtoTT" runat="server" Value="4" Text="Rs 10,000 To Rs 20,000" />
             <asp:ListItem ID="TTtoFT" runat="server" Value="5" Text="Rs 20,000 To Rs 50,000" />
             <asp:ListItem ID="FTtoHT" runat="server" Value="6" Text="Rs 50,000 To Rs 100,000" /> 
    </asp:DropDownList> 


    <br />
     
    <br />
 
    <asp:DataList ID="Datalist1" runat="server" RepeatLayout="Table" RepeatColumns="4" CellPadding="2" CellSpacing="2"> 
    <ItemTemplate> 
        <table cellpadding="2" cellspacing="0" style="width: 200px; height: 100px;"> 
            <tr> 
                <td> 
                    <asp:Image ID="Image1" ImageUrl='<%# Eval("imageUrl") %>' runat="server" Height="200" Width="300" /> 
                </td> 
            
            </tr> 
            <tr> 
                <td> 
                    <b>Product: </b>
                    <asp:Label ID="labelProductName" runat="server" Text='<%# Eval("productName") %>'/>
                    <br />
                    <b>Price: </b>
                    <asp:Label ID="labelPrice" runat="server" Text='<%# Eval("unitPrice") %>'/>
                    <br />
                    <asp:Label ID="labelProductID" runat="server" Text='<%# Eval("productID") %>' visible="false"/>
                    <asp:Label ID="labelColor" runat="server" Text='<%# Eval("color") %>' visible="false"/>
                    <asp:Label ID="labelSize" runat="server" Text='<%# Eval("size") %>' visible="false"/>
                    <asp:Label ID="labelBrand" runat="server" Text='<%# Eval("brand") %>' visible="false"/>
                    
                    
                </td> 
            </tr> 
            <tr>
                <td>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/buttonReadMore.jpg" PostBackUrl='<%# Eval("productID", "ClientProductDetailPage.aspx?productID={0}") %>' Width="53%" Height="35px"/> 
                </td>
            </tr>
        </table> 
     </ItemTemplate> 
</asp:DataList> 

    
    
  
        <table>
            <tr><td><asp:TextBox ID="txtProductName" runat="server" visible="false"></asp:TextBox></td></tr>
            <tr><td><asp:TextBox ID="txtImageUrl" runat="server" visible="false"></asp:TextBox></td></tr>
            <tr><td><asp:TextBox ID="txtUnitPrice" runat="server" visible="false"></asp:TextBox></td></tr>
            <tr><td><asp:TextBox ID="txtUserID" runat="server" visible="false"></asp:TextBox></td></tr>
            <tr><td><asp:TextBox ID="txtQuantity" runat="server" visible="false"></asp:TextBox></td></tr>
            <tr><td><asp:TextBox ID="txtPaymentStatus" runat="server" visible="false"></asp:TextBox></td></tr>
            <%--label holding category filter--%>
            <tr><td><asp:TextBox ID="txtCatFilter" runat="server" Visible="false" ></asp:TextBox></td></tr>
        </table>

    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>

    <br /><br />
</asp:Content>
