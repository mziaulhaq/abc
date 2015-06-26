<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlOrderStatus.ascx.cs" Inherits="Ecommerce.UserControls.CtrlOrderStatus" %>
<div style="overflow-x: scroll">

    <h2>Your Order Status With Us</h2>
    <asp:ListView ID="lstOrders" runat="server" DataKeyNames="OrderId">
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="PaymentMethodIdLabel" runat="server" Text='<%# Eval("PaymentMethod") %>' />
                </td>
                <td>
                    <asp:Label ID="OrderDateLabel" runat="server" Text='<%# Convert.ToDateTime(Eval("OrderDate")).ToString("dd/MM/yyyy") %>' />
                </td>
                <td style="display: none">
                    <asp:Label ID="OrderConfirmationDateLabel" runat="server" Text='<%# Eval("OrderConfirmationDate") %>' />
                </td>
                <td>
                    <asp:Label ID="OrderStatusLabel" runat="server" Text='<%# EcommerceUtilities.OrderStatus.StatusDescription(int.Parse(Eval("OrderStatus").ToString())) %>' />
                </td>
                <td style="display: none">
                    <asp:Label ID="OrderStatusUpdateDateLabel" runat="server" Text='<%# Eval("OrderStatusUpdateDate") %>' />
                </td>
                <td>
                    <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductPrice") %>' />
                </td>

                <td>
                    <asp:Label ID="Label3" runat="server" Text='<%# (Convert.ToInt32(Eval("Quantity"))* Convert.ToInt32(Eval("ProductPrice"))).ToString() %>' />
                </td>

                <td>
                    <asp:Image ID="Label2" runat="server" ImageUrl='<%# BindProducts(Eval("ProductImage").ToString()) %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server" class="TableWithNoBorder" style="margin: 0 auto;">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                            <tr runat="server" style="">
                                <th runat="server">Payment Method</th>
                                <th runat="server">OrderDate</th>
                                <th runat="server" style="display: none">OrderConfirmationDate</th>
                                <th runat="server">OrderStatus</th>
                                <th runat="server" style="display: none">OrderStatusUpdateDate</th>
                                <th runat="server">Quantity</th>
                                <th runat="server">Unit Price</th>
                                <th runat="server">Total Amounts</th>
                                <th runat="server">ProductImage</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>

    </asp:ListView>
</div>
<div style="border-top: 1px solid green; text-align: center">
    <asp:Repeater ID="rptPagination" runat="server">
        <HeaderTemplate>
            <table>
                <tr>
        </HeaderTemplate>
        <ItemTemplate>
            <div style="padding: 4px; display: inline; text-align: center;">
                <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                    Enabled='<%# EnableDisablePageNumber(Eval("Value").ToString()) %>' CssClass='<%# EnableDisablePageNumber(Eval("Value").ToString())?"EnablePagingHyperLink":"DisablePagingHyperLink" %>' OnClick="PageIndexChanged" OnClientClick='<%# EnableDisablePageNumber(Eval("Value").ToString())? "return true;" : "return false;" %>'></asp:LinkButton>


            </div>
        </ItemTemplate>
        <FooterTemplate>
            </tr>
                    </table>
        </FooterTemplate>
    </asp:Repeater>
</div>




