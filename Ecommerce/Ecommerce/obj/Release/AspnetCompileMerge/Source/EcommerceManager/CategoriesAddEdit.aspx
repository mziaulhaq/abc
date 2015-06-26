<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="CategoriesAddEdit.aspx.cs" Inherits="Ecommerce.EcommerceManager.CategoriesAddEdit" %>
<%@ Import Namespace="EcommerceDAL" %>
<%@ Register Src="~/EcommerceManager/UserControls/CtrlCategoriesAddEdit.ascx" TagPrefix="uc1" TagName="CtrlCategoriesAddEdit" %>

<script runat="server">

    
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlCategoriesAddEdit runat="server" id="CtrlCategoriesAddEdit" />
</asp:Content>
