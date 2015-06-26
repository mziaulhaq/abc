<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCartItems.ascx.cs" Inherits="Ecommerce.UserControls.CtrlCartItems" %>
<asp:UpdatePanel runat="server" ID="updCartItems" UpdateMode="Always">
    <ContentTemplate>

        <div style="font-weight: bold" class="Red">
            <span>
                <b class="icon-info-sign"></b>
                <asp:Literal ID="Literal1" runat="server" Text="Items in the Cart"></asp:Literal>
        </div>

        <div id="no-more-tables">

            <asp:ListView ID="lstCartItems" runat="server" ItemPlaceholderID="tmpl">
                <LayoutTemplate>
                    <table class="col-sm-12 table-bordered table-striped table-condensed cf" style="width: 100%">

                        <thead class="cf">
                            <tr>
                            <tr>
                                <th>Name</th>
                                <th>Image</th>
                                <th>Qty</th>
                                <th>Price</th>
                                <th>Total</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="tmpl"></asp:PlaceHolder>

                        </tbody>
                    </table>

                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td data-title="Name"><%# Eval("ProductName") %></td>
                        <td data-title="Image">
                            <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# BindProducts(Eval("ProductImage"),Convert.ToInt64(Eval("ProductId").ToString())) %>'></asp:Image></td>
                        <td data-title="Qty"><%# QuantityOfProductInCartItems(Eval("ProductId").ToString()) %></td>
                        <td data-title="Price"><%# UnitPrice(Eval("ProductId").ToString()) %></td>
                        <td data-title="Total"><%# ProductCommulativePrice(Eval("ProductId").ToString(),QuantityOfProductInCartItems(Eval("ProductId").ToString()))
                        %></td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="dl" CommandArgument='<%# Bind("ProductId") %>' Text="Delete"></asp:LinkButton></td>
                    </tr>
                </ItemTemplate>

            </asp:ListView>

        </div>

        <tr>
            <td>
                <asp:Button runat="server" ID="CartCheckOut" Text="Check Out" CssClass="btn" OnClick="CheckOutClicked" />
            </td>
        </tr>


    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdateProgress ID="UpdateProgress1" runat="server">
    <ProgressTemplate>
        <div id="divUpdateProgress" class="divUpdateProgress">
            <img id="imgUpdateProgress" src="../Images/updateProgress.gif" class="imgUpdateProgress" />
        </div>
    </ProgressTemplate>

</asp:UpdateProgress>

