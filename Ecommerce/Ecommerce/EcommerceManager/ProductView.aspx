<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="Ecommerce.EcommerceManager.ProductView" %>
<%@ Register src="UserControls/Products/CtrlProductsView.ascx" tagname="CtrlProductsView" tagprefix="uc1" %>

<%@ Register src="UserControls/Products/CtrlProductColorGenderView.ascx" tagname="CtrlProductColorGenderView" tagprefix="uc3" %>
<%@ Register src="UserControls/Products/CtrlProductDynamicPropertiesView.ascx" tagname="CtrlProductDynamicPropertiesView" tagprefix="uc4" %>
<%@ Register src="UserControls/Products/CtrlProductImagesView.ascx" tagname="CtrlProductImagesView" tagprefix="uc6" %>
<%@ Register Src="~/EcommerceManager/UserControls/Products/CtrlProductCategoriesView.ascx" TagPrefix="uc1" TagName="CtrlProductCategoriesView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="productView">
        <uc1:CtrlProductsView ID="CtrlProductsView1" runat="server" />
    </div>
    <div id="productCategories">
        <uc1:CtrlProductCategoriesView runat="server" ID="CtrlProductCategoriesView" /> 
    </div>
    <div id="productColorGender">
        <uc3:CtrlProductColorGenderView ID="CtrlProductColorGenderView1" runat="server" />
    </div>
    <div id="productDynamicFeatures">
        <uc4:CtrlProductDynamicPropertiesView ID="CtrlProductDynamicPropertiesView1" runat="server" />
    </div>
    <div id="productImages">
        <uc6:CtrlProductImagesView ID="CtrlProductImagesView1" runat="server" />
    </div>
    
</asp:Content>
