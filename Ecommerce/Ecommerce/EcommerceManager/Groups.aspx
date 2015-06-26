<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="Ecommerce.EcommerceManager.Groups" %>

<%@ Register Src="~/EcommerceManager/UserControls/UsersAndScreens/CtrlAddEditGroups.ascx" TagPrefix="uc1" TagName="CtrlAddEditGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAddEditGroups runat="server" id="CtrlAddEditGroups" />
</asp:Content>

