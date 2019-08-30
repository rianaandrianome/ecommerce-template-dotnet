<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ClientMasterPage.Master" CodeBehind="ClientCartPage.aspx.vb" Inherits="ProjectECommerce.ClientCartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:GridView ID="GridView1" runat="server" 
    AutoGenerateColumns="False" 
    onrowcancelingedit="GridView1_RowCancelingEdit" 
    onrowediting="GridView1_RowEditing" 
    onrowupdating="GridView1_RowUpdating" 
    onrowDeleting="GridView1_RowDeleting" CssClass="gridView"
    PageSize="4"
    AllowPaging="true"
    OnPageIndexChanging="GridView1_PageIndexChanging" > 
     <HeaderStyle CssClass="HeaderStyle"/> 
                <AlternatingRowStyle CssClass="AlternatingRowStyle"/> 
                <Columns> 
                    
                    <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowCancelButton="true" ShowDeleteButton="true" /> 
                    
                    <asp:TemplateField HeaderText="Product "> 
                                <ItemTemplate> 
                                    <asp:Label ID="LblCartID" Text='<%#Eval("cartID") %>' runat="server" visible="false" />
                                    <asp:Label ID="lblProduct" Text='<%#Eval("product") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Product image"> 
                                <ItemTemplate> 
                                    <asp:ImageButton ID="lblImage" ImageUrl='<%#Eval("image") %>' runat="server" Width="300" Height="200" /> 
                                </ItemTemplate> 
                        </asp:TemplateField>  

                     <asp:TemplateField HeaderText="Price"> 
                                <ItemTemplate> 
                                    $<asp:Label ID="lblUnitPrice" Text='<%#Eval("unitPrice") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField>  

                    <asp:TemplateField HeaderText="User"> 
                                <ItemTemplate> 
                                     <asp:Label ID="lblUserID" Text='<%#Eval("userID") %>' runat="server" visible="false"/> 
                                </ItemTemplate> 
                        </asp:TemplateField>  

                     <asp:TemplateField HeaderText="Quantity"> 
                                <ItemTemplate> 
                                    <asp:TextBox ID="txtQuantity" Text='<%#Eval("quantity") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField>  

                     <asp:TemplateField HeaderText="PaymentStatus"> 
                                <ItemTemplate> 
                                    <asp:Label ID="lblStatus" Text='<%#Eval("paymentStatus") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField>  


                </Columns> 
</asp:GridView> 

    <%--label to retreive current user ID--%>
    <asp:Label ID="Label1" runat="server" Text="" Visible="false" Font-Bold="true" font-Size="Large" ></asp:Label>

      <br /><br />
     <%--label to display total amount--%>
    Total all: $ <asp:Label ID="LabelTotalAmount" runat="server" Text=""></asp:Label>

    <br /><br />

    <%--Go to payment page --%>
    <asp:Button CssClass="button" ID="ButtonProceedToCheckout" runat="server" Text="Proceed To Checkout" PostBackUrl="~/ClientPaymentPage.aspx" />

    <br />
</asp:Content>
