<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="AddHomeBanner.aspx.cs" Inherits="Ecommerce.EcommerceManager.AddHomeBanner" %>
<%@ Register src="UserControls/Products/CtrlHomeBanner.ascx" tagname="CtrlHomeBanner" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlHomeBanner ID="CtrlHomeBanner1" runat="server" />
</asp:Content>
