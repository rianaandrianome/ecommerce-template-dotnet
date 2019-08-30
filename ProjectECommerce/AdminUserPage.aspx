<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AdminMasterPage.Master" CodeBehind="AdminUserPage.aspx.vb" Inherits="ProjectECommerce.AdminUserPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <h4> Add/Insert, Edit/Update, Delete Users </h4> 
       <asp:Label ID="lblMsg" runat="server"></asp:Label> 
        
    <table> 
            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSum" ForeColor="Red" HeaderText="Validation Errors"  runat="server" DisplayMode="BulletList" ShowMessageBox="true" ValidationGroup="Registration" />
                </td>
            </tr>
            <tr> 
                <td></td> 
                <td> 
                    <asp:TextBox ID="txtUserID" runat="server" Enabled="false" visible="false" /> 
                </td> 
            </tr>
      
            <tr>
                <td>Last Name</td>
                <td>
                    <asp:textbox ID="txtLastName" runat="server"></asp:textbox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server" ControlToValidate="txtLastName" ValidationGroup="Registration" Text="*" ErrorMessage="Last Name is required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>First Name</td>
                <td>
                    <asp:textbox ID="txtFirstName" runat="server"></asp:textbox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirstName" ValidationGroup="Registration" Text="*" ErrorMessage="First Name is required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Gender</td>
                <td>
                    <%--<asp:textbox ID="txtGender" runat="server"></asp:textbox>--%>

                    <asp:RadioButton ID="RadioButtonMale" GroupName="Gender" runat="server" Text="Male" />
                    <asp:RadioButton ID="RadioButtonFemale" GroupName="Gender" runat="server" Text="Female" />

               </td>
            </tr>
            <tr>
                <td>Date of Birth</td>
                <td>
                    <asp:textbox ID="txtDateOfBirth" runat="server"></asp:textbox>
                </td>
            </tr>
            <tr>
                <td>Address</td>
                <td>
                    <asp:textbox ID="txtAddress" runat="server"></asp:textbox>
                </td>
            </tr>
            <tr>
                <td>City</td>
                <td>
                    <asp:textbox ID="txtCity" runat="server"></asp:textbox>
                </td>
            </tr>
            <tr>
                <td>State</td>
                <td>
                    <asp:DropDownList CssClass="ddl" ID="stateDropDownList" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="stateDropDownList" ValidationGroup="Registration" Text="*" ErrorMessage="Please select a State"></asp:RequiredFieldValidator>
                    
                </td>
            </tr>
            <tr>
                <td>Zip</td>
                <td>
                    <asp:textbox ID="txtZip" runat="server"></asp:textbox>
                </td>
            </tr>
            <tr>
                <td>Phone</td>
                <td>
                    <asp:textbox ID="txtPhone" runat="server"></asp:textbox>
                </td>
            </tr>
            <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" Text="*" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email is Required" ValidationGroup="Registration"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" Text="*" runat="server" Display="Dynamic" ErrorMessage="Invalid Email" ControlToValidate="txtEmail"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ValidationGroup="Registration"></asp:RegularExpressionValidator>
                    
                </td>
            </tr>
            <tr>
                <td>Username</td>
                <td>
                    <asp:textbox ID="txtUsername" runat="server"></asp:textbox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUserName" ValidationGroup="Registration" Text="*" ErrorMessage="Username is required"></asp:RequiredFieldValidator>
                    
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:textbox ID="txtPassword" runat="server" TextMode="Password"></asp:textbox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword" ValidationGroup="Registration" Text="*" ErrorMessage="password is required"></asp:RequiredFieldValidator>
                </td>
            </tr>
           <br /><br />
            <%--BUTTON FOR CRUD--%>            
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
      <asp:GridView ID="gvUsers" DataKeyNames="userID" AutoGenerateColumns="false" OnSelectedIndexChanged="gvUsers_SelectedIndexChanged" runat="server" CssClass="gridView"> 
                <HeaderStyle CssClass="HeaderStyle"/> 
                <AlternatingRowStyle CssClass="AlternatingRowStyle"/> 
                <Columns> 
                        <asp:TemplateField> 
                                <ItemTemplate> 
                                    <asp:LinkButton CssClass="link" ID="lbtnSelect" runat="server" CommandName="Select" Text="Select" /> 
                                </ItemTemplate> 
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Last Name"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelLastName" Text='<%#Eval("userLastName") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="First Name"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelFirstName" Text='<%#Eval("userFirstName") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Gender"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelGender" Text='<%#Eval("userGender") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="DateOfBirth"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelDateOfBirth" Text='<%# DataBinder.Eval(Container.DataItem, "userDateOfBirth", "{0:dd/MMM/yyyy}") %>' runat="server" /> 

                                    
                                </ItemTemplate> 
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Address"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelAddress" Text='<%#Eval("userAddress") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="City"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelCity" Text='<%#Eval("userCity") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="State"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelState" Text='<%#Eval("userState") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Zip"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelZip" Text='<%#Eval("userZip") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Phone"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelPhone" Text='<%#Eval("userPhone") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Email"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelEmail" Text='<%#Eval("userEmail") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Username"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelUsername" Text='<%#Eval("userUsername") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Password"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelPassword" Text='<%#Eval("userPassword") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Blocked Status"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelBlocked" Text='<%#Eval("isBlocked") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 
                </Columns> 
         </asp:GridView> 

</asp:Content>
