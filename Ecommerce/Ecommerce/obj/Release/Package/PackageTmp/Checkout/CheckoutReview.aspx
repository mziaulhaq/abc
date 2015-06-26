<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default/CMSPages.Master" AutoEventWireup="true" CodeBehind="CheckoutReview.aspx.cs" Inherits="Ecommerce.Checkout.CheckoutReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contents" runat="server">

    <h1>Order Review</h1>
    <p></p>
    <h3 style="padding-left: 33px">Products:</h3>
    <%--<asp:GridView ID="OrderItemList" runat="server" AutoGenerateColumns="False" GridLines="Both" CellPadding="10" Width="500" BorderColor="#efeeef" BorderWidth="33">
        <Columns>
            <asp:BoundField DataField="ProductId" HeaderText=" Product ID" />
            <asp:BoundField DataField="Product.ProductName" HeaderText=" Product Name" />
            <asp:BoundField DataField="Product.UnitPrice" HeaderText="Price (each)" DataFormatString="{0:c}" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        </Columns>
    </asp:GridView>--%>
    <asp:GridView ID="GdvCartItems" runat="server" AutoGenerateColumns="False" BorderStyle="None" CssClass="TableWithNoBorder" BorderWidth="0px" Width="700" GridLines="None" ShowHeaderWhenEmpty="True" ShowFooter="True">
        <Columns>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
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
            <%--                    <asp:TemplateField HeaderText="Total Price">
                        <FooterTemplate>
                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPrice" runat="server" Text='<%# ProductCommulativePrice(Eval("ProductId").ToString(),QuantityOfProductInCartItems(Eval("ProductId").ToString()))
                            %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
        </Columns>
        <EmptyDataTemplate>
            <span id="Label3" runat="server" class="well" text="Currently No Item in Your Cart"></span>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:DetailsView ID="dtvShipInfo" runat="server" AutoGenerateRows="false" GridLines="None" CellPadding="10" BorderStyle="None" CommandRowStyle-BorderStyle="None">
        <Fields>
            <asp:TemplateField>
                <ItemTemplate>
                    <h3>Shipping Address:</h3>
                    <br />
                    <asp:Label ID="FirstName" runat="server" Text='<%#: Eval("FirstName") %>'></asp:Label>
                    <asp:Label ID="LastName" runat="server" Text='<%#: Eval("LastName") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Address" runat="server" Text='<%#: Eval("Address") %>'></asp:Label>
                    <br />
                    <%--<asp:Label ID="City" runat="server" Text='<%#: Eval("City") %>'></asp:Label>--%>
                    <asp:Label ID="State" runat="server" Text='<%#: Eval("ProvinceOrState") %>'></asp:Label>
                    <%--<asp:Label ID="PostalCode" runat="server" Text='<%#: Eval("PostalCode") ?? "No Postal Code found" %>'></asp:Label>--%>
                    <p></p>

                    <%--<asp:Label ID="Total" runat="server" Text='<%#: Eval("Total", "{0:C}") %>'></asp:Label>--%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView>
    <h3>Order Total:</h3>
    <asp:Label ID="lblTotal" runat="server"></asp:Label>
    <p></p>
    <hr />
    <asp:Button ID="CheckoutConfirm" runat="server" Text="Complete Order" OnClick="CheckoutConfirm_Click" />
</asp:Content>
