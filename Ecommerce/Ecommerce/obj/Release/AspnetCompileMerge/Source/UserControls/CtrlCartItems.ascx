<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCartItems.ascx.cs" Inherits="Ecommerce.UserControls.CtrlCartItems" %>
<asp:UpdatePanel runat="server" ID="updCartItems" UpdateMode="Always">
    <ContentTemplate>
    <table class="auto-style1">
    <tr>
        <td><span class="well">
            <b class="icon-info-sign"></b>
            <asp:Literal ID="ltHeaderMessage" runat="server" Text="Items in the Cart"></asp:Literal>
        </span>
        </td>

    </tr>
   
    <tr>
        <td class="well">
            <asp:GridView ID="GdvCartItems" runat="server" AutoGenerateColumns="False" BorderStyle="None" CssClass="TableWithNoBorder" BorderWidth="0px"  Width="100%"  OnRowCommand="GdvCartItemsRowCommand" GridLines="None" ShowHeaderWhenEmpty="True" ShowFooter="True">
                <Columns>
                    <asp:TemplateField>
                       <ItemTemplate>
                           
                                                          <%# Container.DataItemIndex + 1 %>
                              

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                       <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image">
                       <ItemTemplate>
                            <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# BindProducts(Eval("ProductImage"),Convert.ToInt64(Eval("ProductId").ToString())) %>'></asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                       <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# QuantityOfProductInCartItems(Eval("ProductId").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unit Price">
                      <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# UnitPrice(Eval("ProductId").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Price">
                       <FooterTemplate>
                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPrice" runat="server" Text='<%# ProductCommulativePrice(Eval("ProductId").ToString(),QuantityOfProductInCartItems(Eval("ProductId").ToString()))
                            %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="dl" CommandArgument='<%# Bind("ProductId") %>' Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <span ID="Label3" runat="server" class="well" Text="Currently No Item in Your Cart"></span>
                </EmptyDataTemplate>
            </asp:GridView>
            <table runat="server"  class="TableWithNoBorder" cellspacing="0"  Id="cartItemsEmpty" style="border-width:0px;border-style:None;width:100%;border-collapse:collapse;">
			<tbody><tr>
				<th scope="col">&nbsp;</th><th scope="col">Name</th><th scope="col">Image</th><th scope="col">Quantity</th><th scope="col">&nbsp;</th>
			</tr>
		</tbody></table>
        </td>
        <tr><td>
                <asp:Button runat="server" ID="CartCheckOut" Text="Check Out" CssClass="btn" OnClick="CheckOutClicked" />
            </td></tr>
    </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>

         <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div id="divUpdateProgress" class="divUpdateProgress">
                <img id="imgUpdateProgress" src="../Images/updateProgress.gif" class="imgUpdateProgress"/>
                </div>
            </ProgressTemplate>
            
        </asp:UpdateProgress>
   
