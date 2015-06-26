<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="HomeBannerViewAll.aspx.cs" Inherits="Ecommerce.EcommerceManager.HomeBannerViewAll" %>

<%@ Register Src="~/EcommerceManager/UserControls/Products/CtrlHomeBannerViewAll.ascx" TagPrefix="uc1" TagName="CtrlHomeBannerViewAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlHomeBannerViewAll runat="server" id="CtrlHomeBannerViewAll" />
</asp:Content>
