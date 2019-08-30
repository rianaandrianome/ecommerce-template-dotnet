<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ClientMasterPage.Master" CodeBehind="Registration.aspx.vb" Inherits="ProjectECommerce.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <table>
            <tr>
                <td colspan="2"><h2>Registration</h2></td>
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
                    <asp:RadioButton ID="RadioButtonMale" GroupName="Gender" runat="server" Text="Male" />
                    <asp:RadioButton ID="RadioButtonFemale" GroupName="Gender" runat="server" Text="Female" />
                </td>
            </tr>
            <tr>
                <td>Date of Birth</td>
                <td>
                    <asp:textbox ID="txtDateOfBirth" runat="server" TextMode="Date" ></asp:textbox>
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
            <tr>
                <td>Confirm password</td>
                <td>
                    <asp:TextBox ID="txtConfirm" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirm" Text="*" ControlToValidate="txtConfirm" runat="server" Display="Dynamic" ErrorMessage="confirm password is Required" ValidationGroup="Registration"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidatorPassword" Text="*" SetFocusOnError="true" Type="String" Display="Dynamic" ControlToValidate="txtConfirm" runat="server" ControlToCompare="txtPassword" Operator="Equal" ErrorMessage="Password and Confirm Password is not Matching" ValidationGroup="Registration"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="Confirmation message"/>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button CssClass="button" ID="buttonRegister" runat="server" Text="Registration" ValidationGroup="Registration" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:ValidationSummary ID="ValidationSum" ForeColor="Red" HeaderText="Validation Errors"  runat="server" DisplayMode="BulletList" ShowMessageBox="true" ValidationGroup="Registration" />
                </td> 
            </tr>
        </table>
    </div>
</asp:Content>
