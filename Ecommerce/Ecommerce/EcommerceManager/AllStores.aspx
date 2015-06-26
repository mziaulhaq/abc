<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="AllStores.aspx.cs" Inherits="Ecommerce.EcommerceManager.AllStores" %>

<%@ Register Src="~/EcommerceManager/Store/CtrlAllStores.ascx" TagPrefix="uc1" TagName="CtrlAllStores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAllStores runat="server" id="CtrlAllStores" />
</asp:Content>
