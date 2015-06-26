<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="BrandManager.aspx.cs" Inherits="Ecommerce.EcommerceManager.BrandManager" %>

<%@ Register Src="~/EcommerceManager/UserControls/CtrlBrandShow.ascx" TagPrefix="uc1" TagName="CtrlBrandShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlBrandShow runat="server" ID="CtrlBrandShow" />
</asp:Content>
