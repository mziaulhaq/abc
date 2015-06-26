<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Ecommerce.EcommerceManager.CategoriesInformationAll" %>

<%@ Register Src="~/EcommerceManager/UserControls/CtrlCategories.ascx" TagPrefix="uc1" TagName="CtrlCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
      
    
    <uc1:CtrlCategories runat="server" id="CtrlCategories" />
</asp:Content>
