<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AdminMasterPage.Master" CodeBehind="AdminCategoryPage.aspx.vb" Inherits="ProjectECommerce.AdminCategoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <h4>Add/Insert, Edit/Update, Delete Category</h4> 
        <asp:Label ID="lblMsg" runat="server"></asp:Label> 
        
    <table> 
            <tr> 
                <td></td> 
                <td> 
                    <asp:TextBox ID="txtCategoryID" runat="server" Enabled="false" /> 
                </td> 
            </tr>
            <tr> 
                <td>Category Name:</td> 
                <td> 
                    <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox> 
                    <asp:RequiredFieldValidator ID="rfvSubjectName" runat="server" Text="*" ControlToValidate="txtCategoryName" ForeColor="Red" ValidationGroup="categoryAdd" /> 
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

      <asp:GridView Cssclass="gridView" ID="gvCategory" DataKeyNames="categoryId" AutoGenerateColumns="false" OnSelectedIndexChanged="gvCategory_SelectedIndexChanged" runat="server"> 
                <HeaderStyle CssClass="HeaderStyle"/> 
                <AlternatingRowStyle CssClass="AlternatingRowStyle"/> 
                <Columns> 
                        <asp:TemplateField> 
                                <ItemTemplate> 
                                    <asp:LinkButton CssClass="link" ID="lbtnSelect" runat="server" CommandName="Select" Text="Select" /> 
                                </ItemTemplate> 
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Category Name"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelCategoryName" Text='<%#Eval("CategoryName") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 
                </Columns> 
         </asp:GridView> 
</asp:Content>
