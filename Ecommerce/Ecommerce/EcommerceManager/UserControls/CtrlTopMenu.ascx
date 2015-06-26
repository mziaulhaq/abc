<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlTopMenu.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.CtrlTopMenu" %>
<%@ Register Assembly="MenuControl" Namespace="MenuControl" TagPrefix="cc1" %>

<cc1:MyMenuControl ID="TopMyMenuControl" ClientIDMode="Static" runat="server" Orientation="Horizontal" RenderingMode="List" IncludeStyleBlock="False" SkipLinkText=".." EnableViewState="False" Width="95%">
    <Items>
        <asp:MenuItem NavigateUrl="~/EcommerceManager/EcomerceHome.aspx" Text="Home" Value="Home"></asp:MenuItem>
        <asp:MenuItem Text="Manager" Value="Manager">
            <asp:MenuItem NavigateUrl="~/EcommerceManager/Screens.aspx" Text="Screen Manager" Value="Screens.aspx"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/EcommerceManager/Groups.aspx" Text="Group Manager" Value="Groups.aspx"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/EcommerceManager/Users.aspx" Text="User Manager" Value="Users.aspx"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/EcommerceManager/AssignScreenToGroup.aspx" Text="Accessibility Manager" Value="AssignScreenToGroup.aspx"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="Ecommerce" Value="Ecommerce">
            <asp:MenuItem Text="Categories Manager" Value="Categories" NavigateUrl="~/EcommerceManager/Categories.aspx"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/EcommerceManager/CategoriesAddEdit.aspx" Text="New Category" Value="CategoriesAddEdit"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/EcommerceManager/HomeBannerViewAll.aspx" Text="Banner Manager" Value="HomeBannerViewAll"></asp:MenuItem>
            <%--<asp:MenuItem NavigateUrl="~/EcommerceManager/AddHomeBanner.aspx" Text="Add Banner" Value="AddHomeBanner"></asp:MenuItem>--%>
            <asp:MenuItem NavigateUrl="~/EcommerceManager/ProductViewAll.aspx" Text="Product Manager" Value="ProductViewAll"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/EcommerceManager/ProductsAddEdit.aspx" Text="Add Product" Value="Add Product"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/EcommerceManager/OrdersManager.aspx" Text="Order Manager" Value="OrdersManager"></asp:MenuItem>
            <%--<asp:MenuItem NavigateUrl="~/EcommerceManager/.aspx" Text="New Orders" Value="New Orders"></asp:MenuItem>--%>
            <asp:MenuItem NavigateUrl="~/EcommerceManager/ViewConfirmOrders.aspx" Text="Confirmed Order" Value="Confirm Order"></asp:MenuItem>

            <asp:MenuItem NavigateUrl="~/EcommerceManager/BrandManager.aspx" Text="Brand Manager" Value="Brand Manager"></asp:MenuItem>

            <asp:MenuItem NavigateUrl="~/EcommerceManager/BrandsAddEdit.aspx" Text="Add Brand" Value="Add Brand"></asp:MenuItem>

        </asp:MenuItem>

        <asp:MenuItem Text="CMS" Value="CMS">
            <asp:MenuItem NavigateUrl="~/EcommerceManager/AddEditPages.aspx" Text="Add New Page" Value="Add New Page"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/EcommerceManager/PageManager.aspx" Text="Page Manager" Value="Page Manager"></asp:MenuItem>
        </asp:MenuItem>

        <asp:MenuItem Text="Reports" Value="Reports">
            <asp:MenuItem NavigateUrl="~/EcommerceManager/SaleReportByDate.aspx" Text="Sales Report By Date" Value="Sales Report By Date"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/EcommerceManager/SaleReportByProduct.aspx" Text="Sales Report By Product" Value="Sales Report By Product"></asp:MenuItem>
        </asp:MenuItem>

        <%--store menu added by zia on 8th july 14--%>
       <%-- <asp:MenuItem Text="Store Management" Value="Store">
            <asp:MenuItem NavigateUrl="~/EcommerceManager/AllStores.aspx" Text="All Stores" Value="All Stores"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/EcommerceManager/AddPayment.aspx" Text="Add Payment" Value="Add Payment"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/EcommerceManager/PaymentInfo.aspx" Text="Payment Information" Value="Payment Information"></asp:MenuItem>
        </asp:MenuItem>--%>


    </Items>
</cc1:MyMenuControl>


