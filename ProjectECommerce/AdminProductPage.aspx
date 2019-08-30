<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AdminMasterPage.Master" CodeBehind="AdminProductPage.aspx.vb" Inherits="ProjectECommerce.AdminProductPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        
         <h4> Add/Insert, Edit/Update, Delete Product </h4> 
        <asp:Label ID="lblMsg" runat="server"></asp:Label> 
        <table> 
            <tr> 
                <td></td> 
                <td><asp:TextBox ID="txtProductId" runat="server" Enabled="false" /></td> 
            </tr> 
            <tr> 
                <td>Product </td> 
                <td> 
                    <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox> 
                    <asp:RequiredFieldValidator ID="rfvProductDescription" runat="server" Text="*" ControlToValidate="txtProductName" ForeColor="Red" ErrorMessage="Enter a product name" ValidationGroup="editProduct" /> 
                </td> 
            </tr> 
            <tr> 
                <td>Category Name:</td> 
                <td><asp:DropDownList CssClass="ddl" ID="ddlCategory" runat="server"></asp:DropDownList></td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvDllCategory" runat="server" ControlToValidate="ddlCategory" ValidationGroup="editProduct" Text="*" ErrorMessage="Select a category"></asp:RequiredFieldValidator>
                </td> 
            </tr> 
            <tr> 
                <td>Image :</td> 
                <td>
                    <asp:TextBox ID="txtImageUrl" runat="server"></asp:TextBox>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button CssClass="button" ID="btnUpload" runat="server" Text="Upload"/>
                    <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
                </td> 
            </tr> 
            
             <tr> 
                <td>Unit Price :</td> 
                <td><asp:TextBox ID="txtUnitPrice" runat="server"></asp:TextBox></td> 
            </tr> 

            <tr>
                <td>Color</td>
                <td> <asp:TextBox ID="txtColor" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>Size</td>
                <td><asp:TextBox ID="txtSize" runat="server"></asp:TextBox> </td>
            </tr>

            <tr>
                <td>Brand</td>
                <td><asp:TextBox ID="txtBrand" runat="server"></asp:TextBox> </td>
            </tr>

            <tr>
                <td>Description</td>
                <td><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox> </td>
            </tr>

            <tr>
                <td colspan="2">
                    <asp:ValidationSummary ID="editProduct" ForeColor="Red" HeaderText="Validation Errors"  runat="server" DisplayMode="BulletList" ShowMessageBox="true" ValidationGroup="Registration" />
                </td> 
            </tr>

            <tr> 
               <td colspan="2"> 
                    <asp:Button CssClass="button" ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" ValidationGroup="vgAdd" /> 
                    <asp:Button CssClass="button" ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" ValidationGroup="vgAdd" /> 
                    <asp:Button CssClass="button" ID="btnDelete" runat="server" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this record?')" Text="Delete" ValidationGroup="vgAdd" /> 
                    <asp:Button CssClass="button" ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" CausesValidation="false" /> 
                </td> 
            </tr> 


        </table> 
        <br /> 

    <%--GRIDVIEW--%>
        <asp:GridView ID="gvProduct" DataKeyNames="productID" AutoGenerateColumns="false" OnSelectedIndexChanged="gvProduct_SelectedIndexChanged" runat="server" CssClass="gridView"> 
                <HeaderStyle CssClass="HeaderStyle"/> 
                <AlternatingRowStyle CssClass="AlternatingRowStyle"/> 
                <Columns> 
                        <asp:TemplateField> 
                                <ItemTemplate> 
                                    <asp:LinkButton CssClass="link" ID="lbtnSelect" runat="server" CommandName="Select" Text="Select" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 
                        
                        <asp:TemplateField HeaderText="Product "> 
                                <ItemTemplate> 
                                    <asp:Label ID="lblProductName" Text='<%#Eval("productName") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Category"> 
                                <ItemTemplate> 
                                    <asp:Label ID="lblCategoryID" Text='<%#Eval("categoryName") %>' runat="server" />
                                     
                                </ItemTemplate> 
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Product image"> 
                                <ItemTemplate> 
                                    <asp:ImageButton ID="lblProductImage" ImageUrl='<%#Eval("imageUrl") %>' runat="server" Width="300px" Height="300"/> 
                                </ItemTemplate> 
                        </asp:TemplateField>  

                     <asp:TemplateField HeaderText="Price"> 
                                <ItemTemplate> 
                                    <asp:Label ID="lblUnitPrice" Text='<%#Eval("unitPrice") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField>  

                    <asp:TemplateField HeaderText="Color"> 
                                <ItemTemplate> 
                                    <asp:Label ID="lblColor" Text='<%#Eval("color") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Size"> 
                                <ItemTemplate> 
                                    <asp:Label ID="lblSize" Text='<%#Eval("size") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Brand"> 
                                <ItemTemplate> 
                                    <asp:Label ID="lblBrand" Text='<%#Eval("brand") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Description"> 
                                <ItemTemplate> 
                                    <asp:Label ID="lblDescription" Text='<%#Eval("description") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 
                    
                </Columns> 
         </asp:GridView> 


</asp:Content>
