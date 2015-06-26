<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="BrandsUpdationInformation.aspx.cs" Inherits="Ecommerce.EcommerceManager.BrandsUpdationInformation" %>

<%@ Register Src="~/EcommerceManager/UserControls/CtrlBrandUpdateInformation.ascx" TagPrefix="uc1" TagName="ctrlBrandUpdateInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ctrlBrandUpdateInformation runat="server" id="BrandUpdateInformation" />
</asp:Content>
