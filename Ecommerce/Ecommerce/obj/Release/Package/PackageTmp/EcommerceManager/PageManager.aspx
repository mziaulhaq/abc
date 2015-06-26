<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="PageManager.aspx.cs" Inherits="Ecommerce.EcommerceManager.PageManager" %>

<%@ Register Src="~/EcommerceManager/UserControls/Pages/CtrlPageManager.ascx" TagPrefix="uc1" TagName="CtrlPageManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlPageManager runat="server" id="CtrlPageManager" />
</asp:Content>
