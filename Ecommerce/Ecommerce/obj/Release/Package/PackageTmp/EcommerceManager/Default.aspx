<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/MasterPages/EcommerceGeneral.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ecommerce.EcommerceManager.Default" %>

<%@ Register Src="~/EcommerceManager/Store/CtrlMainPage.ascx" TagPrefix="uc1" TagName="CtrlMainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlMainPage runat="server" ID="CtrlMainPage" />
</asp:Content>
