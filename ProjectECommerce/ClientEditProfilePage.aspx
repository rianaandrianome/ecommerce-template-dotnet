<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ClientMasterPage.Master" CodeBehind="ClientEditProfilePage.aspx.vb" Inherits="ProjectECommerce.ClientEditProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     
   <br />
    <asp:DataList ID="Datalist1" runat="server" RepeatColumns="1" CellPadding="2" CellSpacing="2"> 
    <ItemTemplate> 
            <table>
                <tr>
                    <td colspan="2"><h2>Edit Profile</h2></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:textbox ID="txtUserID" runat="server" Visible="false" Text='<%# Eval("userID") %>'></asp:textbox>
                    </td>
                 </tr>
                 <tr>
                    <td>Last Name</td>
                    <td>
                        <asp:textbox ID="txtLastName" runat="server" Text='<%# Eval("userLastName") %>'></asp:textbox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server" ControlToValidate="txtLastName" ValidationGroup="EditProfile" Text="*" ErrorMessage="Last Name is required"></asp:RequiredFieldValidator>
                    </td>
                 </tr>
                 <tr>
                    <td>First Name</td>
                    <td>
                        <asp:textbox ID="txtFirstName" runat="server" Text='<%# Eval("userFirstName") %>'></asp:textbox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirstName" ValidationGroup="EditProfile" Text="*" ErrorMessage="First Name is required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Gender</td>
                    <td>
                        <asp:textbox ID="txtGender" runat="server" Text='<%# Eval("userGender") %>'></asp:textbox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtGender" Text="*" ErrorMessage="Enter Male or Female" ValidationExpression="^([M][a][l][e]|[F][e][m][a][l][e])$" ValidationGroup="EditProfile" Display="dynamic"></asp:RegularExpressionValidator>
                        <asp:Label ID="Label3" runat="server" Text="Male or Female" ForeColor="#cdcdcd"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Date of Birth</td>
                    <td>
                        <asp:textbox ID="txtDateOfBirth" runat="server" Text='<%# Eval("userDateOfBirth") %>' ></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>Address</td>
                    <td>
                        <asp:textbox ID="txtAddress" runat="server" Text='<%# Eval("userAddress") %>'></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>City</td>
                    <td>
                        <asp:textbox ID="txtCity" runat="server" Text='<%# Eval("userCity") %>'></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>State</td>
                    <td>
                        <asp:textbox ID="txtState" runat="server" Text='<%# Eval("userState") %>'></asp:textbox>
                    </td>
                </tr>

                <tr>
                    <td>Zip</td>
                    <td>
                        <asp:textbox ID="txtZip" runat="server" Text='<%# Eval("userZip") %>'></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>Phone</td>
                    <td>
                        <asp:textbox ID="txtPhone" runat="server" Text='<%# Eval("userPhone") %>'></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("userEmail") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" Text="*" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email is Required" ValidationGroup="EditProfile"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" Text="*" runat="server" Display="Dynamic" ErrorMessage="Invalid Email" ControlToValidate="txtEmail"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ValidationGroup="EditProfile"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Username</td>
                    <td>
                        <asp:textbox ID="txtUsername" runat="server" Text='<%# Eval("userUsername") %>'></asp:textbox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUserName" ValidationGroup="EditProfile" Text="*" ErrorMessage="Username is required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:textbox ID="txtPassword" runat="server" Text='<%# Eval("userPassword") %>' TextMode="Password"></asp:textbox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword" ValidationGroup="EditProfile" Text="*" ErrorMessage="password is required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Confirm password</td>
                    <td>
                        <asp:TextBox ID="txtConfirm" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirm" Text="*" ControlToValidate="txtConfirm" runat="server" Display="Dynamic" ErrorMessage="confirm password is Required" ValidationGroup="EditProfile"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidatorPassword" Text="*" SetFocusOnError="true" Type="String" Display="Dynamic" ControlToValidate="txtConfirm" runat="server" ControlToCompare="txtPassword" Operator="Equal" ErrorMessage="Password and Confirm Password is not Matching" ValidationGroup="EditProfile"></asp:CompareValidator>
                    </td>
                </tr>
            
                <tr>
                    <td colspan="2">
                        <asp:Button CssClass="button" ID="btnEditProfile" runat="server" Text="Update My Information" ValidationGroup="EditProfile" onclick="btnEditProfile_Click"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="ValidationSum" ForeColor="Red" HeaderText="Validation Errors"  runat="server" DisplayMode="BulletList" ShowMessageBox="true" ValidationGroup="EditProfile" />
                    </td> 
                </tr>
        </table>
     </ItemTemplate> 
</asp:DataList> 
       

     
    <br />
    <%--holds the value of current user ID--%>
    <asp:Label ID="Label1" runat="server" Text="" Visible="false"/>
    <%--display successful/unsuccessful message--%>
    <asp:Label ID="Label2" runat="server" Text="" Font-Size="Medium" ForeColor="#009933"/>

    <br />
</asp:Content>
