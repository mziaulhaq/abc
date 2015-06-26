<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMainPage.ascx.cs" Inherits="Ecommerce.EcommerceManager.Store.CtrlMainPage" %>
<div>
    <div style="width: 33%; float: left">
        <asp:ListView ID="lstBasic" runat="server" ItemPlaceholderID="plItems">
            <LayoutTemplate>
                <table class="mytable" style="text-align: center; width: 100%">
                    <tbody>
                        <asp:PlaceHolder runat="server" ID="plItems"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <th style="text-align: center">
                    <asp:Label ID="lblPackageName" runat="server" Text='<%# Eval("PackageName") %>'></asp:Label>
                </th>
                <tr>
                    <td>USD
                        <asp:Label ID="lblPackageCost" runat="server" Text='<%# Eval("PackagePerMonthCost") %>'></asp:Label>
                        /Month
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPercentagePerTransaction" runat="server" Text='<%#Eval("PackageTransactionPercentage") %>'></asp:Label>%
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Detail") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Free Setup
                    </td>
                </tr>
                <tr>
                    <td>Unlimited Products
                    </td>
                </tr>
                <tr>
                    <td>Unlimited Bandwidth
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="btnBasic" CssClass="btn btn-primary" Text="Buy Now" CommandName="Basic" CommandArgument='<%#Eval("PackageId") %>' OnCommand="BtnBuyNowClicked"/>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div style="width: 33%; float: left">
        <asp:ListView ID="lstBusiness" runat="server" ItemPlaceholderID="plItems">
            <LayoutTemplate>
                <table class="mytable" style="text-align: center; width: 100%">
                    <tbody>
                        <asp:PlaceHolder runat="server" ID="plItems"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <th style="text-align: center">
                    <asp:Label ID="lblPackageName" runat="server" Text='<%# Eval("PackageName") %>'></asp:Label>
                </th>
                <tr>
                    <td>USD
                        <asp:Label ID="lblPackageCost" runat="server" Text='<%# Eval("PackagePerMonthCost") %>'></asp:Label>
                        /Month
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPercentagePerTransaction" runat="server" Text='<%#Eval("PackageTransactionPercentage") %>'></asp:Label>%
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Detail") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Free Setup
                    </td>
                </tr>
                <tr>
                    <td>Unlimited Products
                    </td>
                </tr>
                <tr>
                    <td>Unlimited Bandwidth
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="btnBasic" CssClass="btn btn-primary" Text="Buy Now" CommandName="Business" CommandArgument='<%#Eval("PackageId") %>' OnCommand="BtnBuyNowClicked"/>
                    </td>
                </tr>
            </ItemTemplate>

        </asp:ListView>
    </div>
    <div style="width: 33%; float: left">
        <asp:ListView ID="lstPlus" runat="server" ItemPlaceholderID="plItems">
            <LayoutTemplate>
                <table class="mytable" style="text-align: center; width: 100%">
                    <tbody>
                        <asp:PlaceHolder runat="server" ID="plItems"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <th style="text-align: center">
                    <asp:Label ID="lblPackageName" runat="server" Text='<%# Eval("PackageName") %>'></asp:Label>
                </th>
                <tr>
                    <td>USD
                        <asp:Label ID="lblPackageCost" runat="server" Text='<%# Eval("PackagePerMonthCost") %>'></asp:Label>
                        /Month
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPercentagePerTransaction" runat="server" Text='<%#Eval("PackageTransactionPercentage") %>'></asp:Label>%
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Detail") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Free Setup
                    </td>
                </tr>
                <tr>
                    <td>Unlimited Products
                    </td>
                </tr>
                <tr>
                    <td>Unlimited Bandwidth
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="btnBasic" CssClass="btn btn-primary" Text="Buy Now" CommandName="Plus" CommandArgument='<%#Eval("PackageId") %>' OnCommand="BtnBuyNowClicked"/>
                    </td>
                </tr>
            </ItemTemplate>

        </asp:ListView>
    </div>
</div>
