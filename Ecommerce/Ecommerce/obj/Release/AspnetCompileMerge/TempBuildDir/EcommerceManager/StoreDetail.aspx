<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="StoreDetail.aspx.cs" Inherits="Ecommerce.EcommerceManager.StoreDetail" %>

<%@ Register Src="~/EcommerceManager/Store/CtrlStoreDetail.ascx" TagPrefix="uc1" TagName="CtrlStoreDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlStoreDetail runat="server" id="CtrlStoreDetail" />
</asp:Content>
