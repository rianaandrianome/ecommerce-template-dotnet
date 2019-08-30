<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/AdminMasterPage.Master" CodeBehind="AdminHomePage.aspx.vb" Inherits="ProjectECommerce.AdminHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br /><br />
       <asp:Label ID="labelApplication" runat="server" Text="Label"></asp:Label>
        </br>
       <asp:Label ID="labelSession" runat="server" Text="Label"></asp:Label>
       <br />

    <asp:Button CssClass="button" ID="ButtonPanelBlock" runat="server" Text="Block/Unblock User" OnClick="ButtonPanelBlock_Click1"/>       
    <asp:Button CssClass="button" ID="ButtonPanelPayment" runat="server" Text="Approve/Reject Payment" OnClick="ButtonPanelPayment_Click"/>
    <asp:Button CssClass="button" ID="ButtonPanelReview" runat="server" Text="Validate/Reply Reviews" OnClick="ButtonPanelReview_Click"/>
    <asp:Button CssClass="buttonHide" ID="ButtonHide" runat="server" Text="Hide" OnClick="ButtonHide_Click" />

 <asp:Panel ID="PanelBlock" runat="server" BorderStyle="Groove" >
        <table>
            <tr>
                <td colspan="2"><asp:DropDownList ID="DDLUsers" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLUsers_SelectedIndexChanged" CssClass="ddl"/></td>
         </tr>
            <tr>
                <td colspan="2"><b>Block/Unblock User</b></td>
            </tr>
            <tr>
                <td>Username</td>
                <td><asp:Label ID="lblUsername" runat="server"/></td>
            </tr>
            <tr>
                <td>Blocked</td>
                <td><asp:Label ID="lblBlocked" runat="server"/></td>
            </tr>
            <tr>
                <td><asp:Button CssClass="button" ID="ButtonBlock" runat="server" Text="Block" Width="150px" OnClick="ButtonBlock_Click" /></td>
                <td><asp:Button CssClass="button" ID="ButtonUnblock" runat="server" Text="UnBlock" Width="150px" OnClick="ButtonUnblock_Click" /></td>
            </tr>
            <tr>
                <td colspan="2"><asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>

        <asp:GridView CssClass="gridView" ID="gvUsers" DataKeyNames="userID" AutoGenerateColumns="false" runat="server"> 
                <HeaderStyle CssClass="HeaderStyle"/> 
                <AlternatingRowStyle CssClass="AlternatingRowStyle"/> 
                <Columns> 
                    <asp:TemplateField HeaderText="Username"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelUsername" Text='<%#Eval("userUsername") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField>     
                    
                    <asp:TemplateField HeaderText="Blocked Status"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelBlocked" Text='<%#Eval("isBlocked") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 
                </Columns> 
         </asp:GridView>

    </asp:Panel>
          
 <asp:Panel ID="PanelPayment" runat="server" BorderStyle="Groove">
            <table>
            <tr>
                <td colspan="2"><b>Approve/Reject Payment</b></td>
            </tr>
            <tr>
                <td>Username</td>
                <td><asp:Label ID="lblUsernameP" runat="server"/></td>
            </tr>
            <tr>
                <td>Payment Status</td>
                <td><asp:Label ID="lblPaymentStatusPT" runat="server"/></td>
            </tr>
             <tr>
                <td></td>
                <td><asp:Label ID="lblUserID" runat="server" Visible="false" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Label ID="lblCartID" runat="server" Visible="false" /></td>
            </tr>
             <tr>
                <td><asp:Button CssClass="button" ID="ButtonApprove" runat="server" Text="Approve" Width="150px" OnClick="ButtonApprove_Click"/></td>
                <td><asp:Button CssClass="button" ID="ButtonReject" runat="server" Text="Reject" Width="150px" OnClick="ButtonReject_Click"/></td>
            </tr>
            <tr>
                <td colspan="2"><asp:Label ID="lblMsg2" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>

        <asp:GridView ID="gvApprovePayment" DataKeyNames="userID" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="gvApprovePayment_SelectedIndexChanged" CssClass="gridView"> 
                <HeaderStyle CssClass="HeaderStyle"/> 
                <AlternatingRowStyle CssClass="AlternatingRowStyle" /> 
                <Columns> 
                    <asp:TemplateField> 
                                <ItemTemplate> 
                                    <asp:LinkButton CssClass="link" ID="lbtnSelect" runat="server" CommandName="Select" Text="Select" /> 
                                </ItemTemplate> 
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Username"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelUsernameGvP" Text='<%#Eval("userUsername") %>' runat="server" /> 
                                    <asp:Label ID="labelUserID" Text='<%#Eval("userID") %>' runat="server" Visible="false" />
                                    <asp:Label ID="labelCartID" Text='<%#Eval("cartID") %>' runat="server" Visible="false" /> 
                                </ItemTemplate> 
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelProduct" Text='<%#Eval("product") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField>  
                    <asp:TemplateField HeaderText="Price"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelPrice" Text='<%#Eval("unitPrice") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelQuantity" Text='<%#Eval("quantity") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shiping address"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelShippingAddress" Text='<%#Eval("shippingAddress") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField>    
                     <asp:TemplateField HeaderText="Payment Status"> 
                                <ItemTemplate> 
                                    <asp:Label ID="labelPaymentStatusGvP" Text='<%#Eval("paymentStatus") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 
                    
                </Columns> 
         </asp:GridView>
    </asp:Panel>
       
<asp:Panel ID="PanelReview" runat="server" BorderStyle="Groove" >
                        <table>
                            <tr>
                                <td colspan="2"><b>Validate Reviews</b></td>
                            </tr>
                            <tr>
                                <td>Username</td>
                                <td><asp:Label ID="lblUsernameReviewPanel" runat="server"/></td>
                            </tr>
                            <tr>
                                <td>Review</td>
                                <td><asp:Label ID="lblReviewPanel" runat="server"/></td>
                            </tr>
                            <tr>
                                <td>Reply</td>
                                <td><asp:TextBox ID="txtReplyPanel" runat="server"/></td>
                            </tr>
                            <tr>
                                <td>Review Status</td>
                                <td><asp:Label ID="lblStatusPanel" runat="server"/></td>
                            </tr>
                            <tr>
                                <td><asp:Button CssClass="button" ID="btnAdminPublish" runat="server" Text="Publish/validate" Width="150px" OnClick="btnAdminPublish_Click" /></td>
                                <td><asp:Button CssClass="button" ID="btnAdminReply" runat="server" Text="Reply" Width="150px" OnClick="btnAdminReply_Click" /></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:Label ID="lblMsgReviewPanel" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table>

                        <asp:Label ID="lblReviewIDPanel" runat="server" visible="false"/>
                        <asp:Label ID="lblMsgRP" runat="server" visible="false"/>

                        <asp:GridView ID="gvReview" DataKeyNames="reviewID" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="gvReview_SelectedIndexChanged" CssClass="gridView"> 
                                <HeaderStyle CssClass="HeaderStyle"/> 
                                <AlternatingRowStyle CssClass="AlternatingRowStyle"/> 
                                <Columns> 
                                    <asp:TemplateField> 
                                                <ItemTemplate> 
                                                    <asp:LinkButton CssClass="link" ID="lbtnSelect" runat="server" CommandName="Select" Text="Reply/Publish" /> 
                                                </ItemTemplate> 
                                        </asp:TemplateField> 

                                    <asp:TemplateField HeaderText="Username"> 
                                                <ItemTemplate> 
                                                    <asp:Label ID="lblUsernameGvReview" Text='<%#Eval("username") %>' runat="server" /> 
                                                    <asp:Label ID="lblReviewIDGv" Text='<%#Eval("reviewID") %>' runat="server" Visible="false"/> 
                                                </ItemTemplate> 
                                        </asp:TemplateField>     
                    
                                    <asp:TemplateField HeaderText="Review"> 
                                                <ItemTemplate> 
                                                    <asp:Label ID="lblReviewGvReview" Text='<%#Eval("review") %>' runat="server" /> 
                                                </ItemTemplate> 
                                        </asp:TemplateField> 

                                    <asp:TemplateField HeaderText="Reply"> 
                                                <ItemTemplate> 
                                                    <asp:Label ID="lblReplyGvReview" Text='<%#Eval("reply") %>' runat="server" /> 
                                                </ItemTemplate> 
                                        </asp:TemplateField> 

                                    <asp:TemplateField HeaderText="Status"> 
                                                <ItemTemplate> 
                                                    <asp:Label ID="lblStatusGvReview" Text='<%#Eval("status") %>' runat="server" /> 
                                                </ItemTemplate> 
                                        </asp:TemplateField> 

                                </Columns> 
                         </asp:GridView>

                 </asp:Panel>


       


    <br /><br />
</asp:Content>
