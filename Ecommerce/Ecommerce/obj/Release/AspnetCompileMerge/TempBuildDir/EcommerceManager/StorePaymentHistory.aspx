<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="StorePaymentHistory.aspx.cs" Inherits="Ecommerce.EcommerceManager.StorePaymentHistory" %>

<%@ Register Src="~/EcommerceManager/Store/CtrlPaymentHistory.ascx" TagPrefix="uc1" TagName="CtrlPaymentHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlPaymentHistory runat="server" ID="CtrlPaymentHistory" />
</asp:Content>
