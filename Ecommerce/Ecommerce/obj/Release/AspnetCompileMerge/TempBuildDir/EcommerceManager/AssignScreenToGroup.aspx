<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="AssignScreenToGroup.aspx.cs" Inherits="Ecommerce.EcommerceManager.AssignScreenToGroup" %>

<%@ Register Src="~/EcommerceManager/UserControls/UsersAndScreens/CtrlAssignScreenToGroup.ascx" TagPrefix="uc1" TagName="CtrlAssignScreenToGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAssignScreenToGroup runat="server" id="CtrlAssignScreenToGroup" />
</asp:Content>
