<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ClientMasterPage.Master" CodeBehind="ClientHomePage.aspx.vb" Inherits="ProjectECommerce.ClientHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br />
    <h2>Client Home page</h2>
    

    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                   <asp:Timer ID="Timer1" Interval="2000" runat="server" />
                        <asp:UpdatePanel ID="up1" runat="server">
                           <Triggers>
                               <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                           </Triggers>
                           <ContentTemplate>
                                 <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/xml/adrotatorXMLFile.xml" Target="_blank" Height="80px" Width="150px" /> 
                          </ContentTemplate>
                       </asp:UpdatePanel>   


    <br /><br /> 


    <asp:Button CssClass="buttonHide" ID="ButtonHide" runat="server" Text="Hide" OnClick="ButtonHide_Click"/>
    <asp:Button CssClass="button" ID="ButtonPurchaseHistory" runat="server" Text="Purchase History" OnClick="ButtonPurchaseHistory_Click"/>
    <asp:Button CssClass="button" ID="ButtonReview" runat="server" Text="Reviews" OnClick="ButtonReview_Click"/>

    <asp:Panel ID="PanelPurchaseHistory" runat="server" BorderStyle="Groove">
        
         <asp:Label ID="lblUserID" runat="server" Visible="false" />
         <asp:Label ID="Label1" runat="server" Text=""/>
        <h2>Purchase history</h2>

        <asp:GridView ID="gvPurchase" DataKeyNames="userID" AutoGenerateColumns="false" runat="server" Cssclass="gridView"> 
                 <HeaderStyle CssClass="HeaderStyle"/> 
                <AlternatingRowStyle CssClass="AlternatingRowStyle"/>
                <Columns> 
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

    <asp:Panel ID="PanelReview" runat="server" BorderStyle="Groove">
         <h2>Review</h2>
        <table>
            <tr>
                <td>Review</td>
                <td><asp:TextBox ID="txtReview" runat="server" TextMode="MultiLine" ></asp:TextBox></td>
            </tr>
            <tr>
                <td>Reply</td>
                <td><asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine" /></td>
            </tr>
            <tr>
                <td><asp:Button CssClass="button" ID="btnAddReview" Text="Add Review" runat="server" OnClick="btnAddReview_Click"/></td>
                <td><asp:Button CssClass="button" ID="btnAddReply" Text="Add Reply" runat="server"  OnClick="btnAddReply_Click"/></td>
            </tr>
        </table>
         
        <br /><br />
         <asp:Label ID="lblReviewIDH" runat="server" Visible="false" />
         <asp:Label ID="lblMsgR" runat="server"/>

          <asp:GridView ID="gvReview" DataKeyNames="reviewID" AutoGenerateColumns="false" OnSelectedIndexChanged="gvReview_SelectedIndexChanged" runat="server" CssClass="gridView"> 
                <HeaderStyle CssClass="HeaderStyle"/> 
                <AlternatingRowStyle CssClass="HeaderStyle"/>
                <Columns> 
                        <asp:TemplateField> 
                                <ItemTemplate> 
                                    <asp:LinkButton CssClass="link" ID="lbtnSelect" runat="server" CommandName="Select" Text="Reply" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 
                        
                        <asp:TemplateField HeaderText="Review "> 
                                <ItemTemplate> 
                                    <asp:Label ID="lblReviewID" Text='<%#Eval("reviewID") %>' runat="server" /> 
                                    <asp:Label ID="lblReview" Text='<%#Eval("review") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Reply "> 
                                <ItemTemplate> 
                                    <asp:Label ID="lblReply" Text='<%#Eval("reply") %>' runat="server" /> 
                                </ItemTemplate> 
                        </asp:TemplateField> 
 
                </Columns> 
         </asp:GridView> 

    </asp:Panel>

</asp:Content>
