<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="AddEditPages.aspx.cs" Inherits="Ecommerce.EcommerceManager.AddEditPages" %>

<%@ Register Src="~/EcommerceManager/UserControls/Pages/CtrlPages.ascx" TagPrefix="uc1" TagName="CtrlPages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlPages runat="server" ID="CtrlPages" />
</asp:Content>
