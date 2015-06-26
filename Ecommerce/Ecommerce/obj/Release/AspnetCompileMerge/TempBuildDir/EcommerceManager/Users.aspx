<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Ecommerce.EcommerceManager.Users" %>

<%@ Register Src="~/EcommerceManager/UserControls/UsersAndScreens/CtrlCreateUser.ascx" TagPrefix="uc1" TagName="CtrlCreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlCreateUser runat="server" id="CtrlCreateUser" />
</asp:Content>
