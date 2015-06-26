<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="Screens.aspx.cs" Inherits="Ecommerce.EcommerceManager.Screens" %>

<%@ Register Src="~/EcommerceManager/UserControls/UsersAndScreens/CtrlAddEditScreen.ascx" TagPrefix="uc1" TagName="CtrlAddEditScreen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAddEditScreen runat="server" id="CtrlAddEditScreen" />
</asp:Content>
