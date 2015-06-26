<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/MasterPages/EcommerceGeneral.Master" AutoEventWireup="true" CodeBehind="StoreRegWizard.aspx.cs" Inherits="Ecommerce.EcommerceManager.StoreRegWizard" %>

<%@ Register Src="~/EcommerceManager/Store/CtrlStoreWizard.ascx" TagPrefix="uc1" TagName="CtrlStoreWizard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlStoreWizard runat="server" id="CtrlStoreWizard" />
</asp:Content>
