<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="ProductViewAll.aspx.cs" Inherits="Ecommerce.EcommerceManager.ProductViewAll" %>
<%@ Register src="UserControls/Products/CtrlViewAllProduct.ascx" tagname="CtrlViewAllProduct" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlViewAllProduct ID="CtrlViewAllProduct1" runat="server" />
</asp:Content>
